using Net4Sage;
using Net4Sage.CIUtils;
using Net4Sage.DataAccessModel;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMDataAccess.Datamodel;
using WorkOrder = WMDataAccess.Datamodel.WorkOrder;

namespace WMModuleUtils
{
    public enum WOTranTypes
    {
        SalesOrderOut = 5,
        ReceipIn = 1,
        TransferIn = 2,
        Movement = 4,
        TransferOut = 3,
        Restocked = 6
    }
    public enum WOOutMethods
    {
        Standard = 0,
        Guide = 1,
        Expiration = 2
    }
    public enum MovementRequestTypes
    {
        FromStorage = 1,
        FromPicking = 2,
        FromAny = 3
    }
    public class WarehouseWorkOrderHandler : TransactionHandler
    {
        private WMDBContext dbContext;
        private int? _ubicationUMKey;
        public int? UbicationUMKey
        {
            get
            {
                if (!_ubicationUMKey.HasValue)
                    _ubicationUMKey = dbContext.WMOptions.Where(p => p.CompanyID == SysSession.CompanyID).FirstOrDefault().UbicationUMKey;
                return _ubicationUMKey;
            }
        }
        public WarehouseWorkOrderHandler(ref SageSession session) : base(ref session)
        {
            TranType = 7001;
        }
        protected override void LoadContext()
        {
            System.Data.EntityClient.EntityConnectionStringBuilder connectionString = new System.Data.EntityClient.EntityConnectionStringBuilder()
            {
                Metadata = "res://*/DataModel.csdl|res://*/DataModel.ssdl|res://*/DataModel.msl",
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = SysSession.GetConnectionString()
            };
            dbContext = new WMDBContext(connectionString.ToString());
            base.LoadContext();
        }

        public WarehouseUbicationStatus GetWarehouseUbicationStatus(int WarehouseUbicationKey)
        {
            //throw new NotImplementedException();
            decimal sizeqty = 0;
            WarehouseUbication ubication = dbContext.WarehouseUbications.Where(p => p.WhseUbicationKey == WarehouseUbicationKey).FirstOrDefault();
            WarehouseUbicationStatus status = new WarehouseUbicationStatus(ubication.UbicationType.LevelQty, ubication.UbicationType.Capacity.GetHashCode());
                        
            foreach (var i in dbContext.WorkOrderLines.Where(p => p.FromWhseUbicationKey == ubication.WhseUbicationKey || p.ToWhseUbicationKey == ubication.WhseUbicationKey).OrderBy(p => p.CompleteDate).ToList())
            {
                if (status.ItemKey == null || status.ItemKey != i.ItemKey)
                    sizeqty = GetStorageConvertion(i.ItemKey);

                switch (i.WorkOrder.Type)
                {
                    case (int)WOTranTypes.ReceipIn:

                        break;
                    case (int)WOTranTypes.TransferIn:
                        if (i.ToWhseUbicationKey == WarehouseUbicationKey)
                        {
                            if (i.Status == 2)
                            {
                                if (status.Avaliable)
                                {
                                    if (status.Qty > 0)
                                    {
                                        if (status.ItemKey != i.ItemKey)
                                            throw new Exception("itemoverrideexception");
                                        status.Qty = i.Qty;
                                    }
                                    else
                                    {
                                        status.ItemKey = i.ItemKey;
                                        status.SizeQty = sizeqty;
                                        status.Qty = i.Qty;
                                    }
                                }
                            }
                            else if (i.WorkOrder.Status == 2)
                            {
                                status.QtyPendingToDecrease += i.Qty;
                            }

                        }
                        break;
                    case (int)WOTranTypes.Movement:
                        if (i.FromWhseUbicationKey == ubication.WhseUbicationKey)
                        {
                            if (i.Status == 2)
                            {
                                if (i.Qty <= status.Qty)
                                    status.Qty -= i.Qty;
                                else
                                {
                                    status.Qty -= i.Qty;
                                    status.ItemKey = null;
                                }

                            }
                            else if (i.WorkOrder.Status == 2)
                                status.QtyPendingToDecrease += i.Qty;

                        }
                        else
                        {
                            if (i.Status == 2)
                            {
                                if (status.Avaliable)
                                {
                                    status.ItemKey = i.ItemKey;
                                    status.SizeQty = sizeqty;
                                    if (status.Qty > 0)
                                        status.Qty = i.Qty;
                                    else
                                        status.Qty = i.Qty;
                                }
                            }
                            else if (i.WorkOrder.Status == 2)
                                status.QtyPendingToIncrease += i.Qty;

                        }
                        break;
                    case (int)WOTranTypes.TransferOut:
                        if (i.FromWhseUbicationKey == ubication.WhseUbicationKey)
                        {
                            if (i.Qty == status.Qty)
                                status.Qty = 0;
                            else
                                status.Qty = 0;
                        }
                        break;
                }
            }

            return status;
        }
        public void UpdateStorageLog(int WhseKey)
        {
            //WarehouseUbicationStatus status;
            //foreach (WarehouseUbication i in dbContext.WarehouseUbications.Where(p => p.WhseKey == WhseKey))
            //{
            //    status = GetWarehouseUbicationStatus(i.WhseUbicationKey);
            //    if (status.ItemKey.HasValue)
            //    {
            //        i.WarehouseUbicationsLog.ItemKey =
            //    }
            //}
        }
        /// <summary>
        /// Método que retorna una lista de Órdenes de Trabajo Pendientes.
        /// </summary>
        /// <returns>Retorna una lista de Órdenes de Trabajo Pendientes.</returns>
        public IEnumerable<WorkOrderView> GetPendingWorkOrderView()
        {
            List<WorkOrderLine> answer = new List<WorkOrderLine>(from p in dbContext.WorkOrderLines
                                                                 where p.Status == 1 && p.WorkOrder.Status == 2
                                                                 select p);
            var a = (
                from p in answer
                join s in context.Items on p.ItemKey equals s.ItemKey
                select new WorkOrderView()
                {
                    WOLineKey = p.WOLineKey,
                    ItemID = s.ItemID,
                    WOID = (p.WorkOrder.Type == (int)WOTranTypes.Movement ? p.WorkOrder.WorkOrderID : p.WorkOrder.WorkOrderID + "-" + p.LineNo),
                    Type = p.WorkOrder.Type,
                    From = (p.WorkOrder.Type == (int)WOTranTypes.ReceipIn || p.WorkOrder.Type == (int)WOTranTypes.TransferIn ? p.WorkOrder.From.Gates.FirstOrDefault().GateID : p.FromWarehouseUbication.WhseUbicationID),
                    To = (p.WorkOrder.Type == (int)WOTranTypes.SalesOrderOut || p.WorkOrder.Type == (int)WOTranTypes.TransferOut ? p.WorkOrder.To.Gates.FirstOrDefault().GateID : p.ToWarehouseUbication.WhseUbicationID),
                    LPN = p.LPN.LPN,
                    QTY = p.Qty
                });
            return a;
        }
        /// <summary>
        /// Método que retorna la cantidad de pallet que se utilizará dada la cantidad de un artículo.
        /// </summary>
        /// <param name="ItemKey"></param>
        /// <param name="Qty"></param>
        /// <param name="FromUMKey"></param>
        /// <returns>Retorna la cantidad de pallet que se utilizará dada la cantidad de un artículo.</returns>
        public decimal GetStorageQty(int ItemKey, decimal Qty, int? FromUMKey = null)
        {
            decimal convFact = GetStorageConvertion(ItemKey, FromUMKey), ptl;
            if (convFact == 0) 
                convFact = 1;
            ptl = Qty / convFact;
            if (ptl % 1 != 0) 
                ptl = ((int)ptl / 1) + 1;
            return ptl;
        }
        /// <summary>
        /// Método que retorna el factor de conversión de un artículo.
        /// </summary>
        /// <param name="ItemKey"></param>
        /// <param name="FromUMKey"></param>
        /// <returns>Retorna el factor de conversión de un artículo.</returns>
        public decimal GetStorageConvertion(int ItemKey, int? FromUMKey = null)
        {
            decimal convFact;
            try
            {
                convFact = context.ItemUMs.Where(p => p.ItemKey == ItemKey && p.TargetUnitMeasKey == UbicationUMKey.Value).Select(p => p.ConversionFactor).FirstOrDefault();
            }
            catch
            {
                convFact = 1;
            }
            return convFact;
        }
        public void SetStorageUbications(int WhseKey, IEnumerable<WorkOrderLine> lines)
        {
            int WhseUbicationKey;
            WMSInventary inventary;
            WarehouseUbicationLog ubicationLog;
            Dictionary<int, List<int>> storagePatterns = new Dictionary<int, List<int>>();
            Dictionary<int, int> levels = new Dictionary<int, int>();
            LoadContext();

            foreach (WorkOrderLine line in lines)
            {
                if (!storagePatterns.ContainsKey(line.ItemKey))
                {
                    if ((inventary = dbContext.WMSInventaries.Where(p => p.ItemKey == line.ItemKey && p.WhseKey == WhseKey).FirstOrDefault()) != null)
                        storagePatterns.Add(line.ItemKey, inventary.StoragePattern.StoragePatterUbications.OrderBy(p => p.No).Select(p => p.UbicationTypeKey).ToList());
                    else
                        storagePatterns.Add(line.ItemKey, new List<int>());
                }

                while (storagePatterns[line.ItemKey].Count > 0)
                {
                    WhseUbicationKey = storagePatterns[line.ItemKey].FirstOrDefault();
                    if (!levels.ContainsKey(WhseUbicationKey))
                        levels.Add(WhseUbicationKey, 1);
                    if ((ubicationLog = dbContext.WarehouseUbicationLogs.Where(p => p.WhseUbicationKey == WhseUbicationKey).FirstOrDefault()) != null && ubicationLog.WarehouseUbication.Status < 3 && ubicationLog.AvaliableIn)
                    {
                        while (levels[WhseUbicationKey] <= ubicationLog.WarehouseUbication.UbicationType.LevelQty)
                        {
                            if (ubicationLog.IsLevelAvaliableIn(levels[WhseUbicationKey]))
                            {
                                line.ToLevelNo = levels[WhseUbicationKey];
                                line.ToWhseUbicationKey = WhseUbicationKey;
                                ubicationLog.PushLPN(line.ItemKey, line.LPNKey, levels[WhseUbicationKey]);
                                break;
                            }
                            levels[WhseUbicationKey]++;
                        }
                        if (levels[WhseUbicationKey] > ubicationLog.WarehouseUbication.UbicationType.LevelQty)
                            storagePatterns[line.ItemKey].RemoveAt(0);
                        else
                            break;
                    }
                    break;
                }
            }
        }

        #region "WorkOrder Automatic Generation"
        public bool CreateShipmentWorkOrder(int ShipKey, WOOutMethods method = WOOutMethods.Standard)
        {
            //throw new NotImplementedException();
            Net4Sage.DataAccessModel.ShipmentLog shipment = context.ShipmentLogs.Where(p => p.ShipKey == ShipKey).FirstOrDefault();
            List<Net4Sage.DataAccessModel.ShipLine> sLines = shipment.ShipLines.ToList();
            List<WorkOrderLine> lines = new List<WorkOrderLine>();
            WorkOrderLine temp;
            DispatchLine dispatchLine;
            Dispatch dispatch;
            WMSInventary inventary;
            decimal qty, tempQty;
            List<Tuple<WarehouseUbication, WarehouseUbicationStatus>> ubications;
            int itemKey, whseKey = shipment.Shipment != null ? shipment.Shipment.WhseKey.Value : shipment.PendShipment.WhseKey.Value;
            int tempLinekey, movementWO, tempLPNKey;
            tempLinekey = sLines.FirstOrDefault().SOLineKey.Value;
            dispatchLine = dbContext.DeliveryLines.Where(p => p.SOLineKey == tempLinekey).Select(p => p.DispatchLines).FirstOrDefault().Where(p => p.Dispatch.Status == 1).FirstOrDefault();

            //if (dispatchLine == null) return false;
            dispatch = dispatchLine.Dispatch;

            foreach (var g in sLines.GroupBy(p => p.ItemKey))
            {
                itemKey = g.Key.Value;
                inventary = dbContext.WMSInventaries.Where(p => p.ItemKey == itemKey && p.WhseKey == whseKey).FirstOrDefault();
                ubications = dbContext.WarehouseUbications.Where(p => p.UbicationType.UbicType == UbicType.Picking && p.PickingKey.HasValue && p.PickingKey == dispatch.Picking && ((p.WarehouseUbicationsLog.ItemKey.HasValue && p.WarehouseUbicationsLog.ItemKey.Value == itemKey) || !p.WarehouseUbicationsLog.ItemKey.HasValue)).ToList().Select(p => new Tuple<WarehouseUbication, WarehouseUbicationStatus>(p, GetWarehouseUbicationStatus(p.WhseUbicationKey))).ToList();
                if (ubications.Count == 0) return false;
                foreach (var l in g)
                {
                    qty = l.ShipLineDists.Sum(p => p.QtyShipped);
                    if (l.SOLineKey.HasValue)
                    {
                        dispatchLine = dbContext.DeliveryLines.Where(p => p.SOLineKey == l.SOLineKey.Value).Select(p => p.DispatchLines).FirstOrDefault().Where(p => p.Dispatch.Status == 1).FirstOrDefault();
                        while (qty > 0)
                        {
                            for (var i = 0; i < ubications.Count; i++)
                            {
                                if (ubications[0].Item2.Qty > 0)
                                {
                                    if (ubications[0].Item2.Qty > 0 && qty > 0)
                                    {
                                        temp = new WorkOrderLine()
                                        {
                                            FromWhseUbicationKey = ubications[i].Item1.WhseUbicationKey,
                                            Qty = ubications[0].Item2.Qty > qty ? qty : ubications[0].Item2.Qty,
                                            Status = 1,
                                            ItemKey = itemKey,
                                            LPNKey = ubications[i].Item1.WarehouseUbicationsLog.WarehouseUbicationLogLevels.FirstOrDefault().LPNKey.Value,
                                            InvtLotKey = ubications[i].Item1.WarehouseUbicationsLog.WarehouseUbicationLogLevels.FirstOrDefault().LPNRelation.LotKey.Value,
                                        };
                                        qty -= temp.Qty;
                                        ubications[0].Item2.Qty -= temp.Qty;
                                        lines.Add(temp);
                                    }

                                    if (ubications[0].Item2.Qty > 0 && qty > 0)
                                    {
                                        temp = new WorkOrderLine()
                                        {
                                            FromWhseUbicationKey = ubications[i].Item1.WhseUbicationKey,
                                            Qty = ubications[0].Item2.Qty > qty ? qty : ubications[0].Item2.Qty,
                                            Status = 1,
                                            ItemKey = itemKey,
                                            LPNKey = ubications[i].Item1.WarehouseUbicationsLog.WarehouseUbicationLogLevels.FirstOrDefault().LPNKey.Value,
                                            InvtLotKey = ubications[i].Item1.WarehouseUbicationsLog.WarehouseUbicationLogLevels.FirstOrDefault().LPNRelation.LotKey.Value,
                                        };
                                        qty -= temp.Qty;
                                        ubications[0].Item2.Qty -= temp.Qty;
                                        lines.Add(temp);
                                    }
                                }
                            }

                            if (qty > 0)
                            {
                                tempQty = qty;
                                for (var i = 0; i < ubications.Count && tempQty > 0; i++)
                                {
                                    if (ubications[i].Item2.QtyPendingToIncrease == 0)
                                    {
                                        if ((movementWO = CreateMovementOrder(itemKey, ubications[i].Item1.WhseUbicationKey, 1, MovementRequestTypes.FromStorage)) > 0)
                                        {
                                            ubications[i].Item2.Qty = dbContext.WorkOrderLines.Where(p => p.WorkOrderKey == movementWO).Select(p => p.Qty).First();
                                            tempLPNKey = dbContext.WorkOrderLines.Where(p => p.WorkOrderKey == movementWO).Select(p => p.LPNKey).First();
                                            ubications[i].Item1.WarehouseUbicationsLog.WarehouseUbicationLogLevels.FirstOrDefault().LPNKey = tempLPNKey;
                                            ubications[i].Item1.WarehouseUbicationsLog.WarehouseUbicationLogLevels.FirstOrDefault().LPNRelation = dbContext.LPNRelations.Where(p => p.LPNKey == tempLPNKey).First();
                                            tempQty -= ubications[i].Item2.Qty;
                                            ubications[i].Item2.QtyPendingToIncrease = -1;
                                        }
                                        if (tempQty > 0  && (movementWO = CreateMovementOrder(itemKey, ubications[i].Item1.WhseUbicationKey, 1, MovementRequestTypes.FromStorage)) > 0)
                                        {
                                            ubications[i].Item2.Qty = dbContext.WorkOrderLines.Where(p => p.WorkOrderKey == movementWO).Select(p => p.Qty).First();
                                            tempLPNKey = dbContext.WorkOrderLines.Where(p => p.WorkOrderKey == movementWO).Select(p => p.LPNKey).First();
                                            ubications[i].Item1.WarehouseUbicationsLog.WarehouseUbicationLogLevels.FirstOrDefault().LPNKey = tempLPNKey;
                                            ubications[i].Item1.WarehouseUbicationsLog.WarehouseUbicationLogLevels.FirstOrDefault().LPNRelation = dbContext.LPNRelations.Where(p => p.LPNKey == tempLPNKey).First();
                                            tempQty -= ubications[i].Item2.Qty;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }

            LoadContext();
            WorkOrder answer = new WorkOrder()
            {
                CompanyID = SysSession.CompanyID,
                Date = shipment.TranDate.Value,
                Type = (short)WOTranTypes.SalesOrderOut,
                WhseKey = whseKey,
                WorkOrderID = GetNextTransactionNumber(),
                Status = 1,
                ToUbicationKey = dispatch.Gate.WarehouseUbication.Gates.FirstOrDefault().WhseUbicationKey,
            };
            var no = 1;
            foreach (WorkOrderLine i in lines)
            {
                i.LineNo = no;
                answer.WorkOrderLines.Add(i);
                no++;
            }
            dbContext.WorkOrders.AddObject(answer);
            dbContext.SaveChanges();
            return true;
        }
        public bool CreateOutWorkOrder(int DispatchKey, WOOutMethods method = WOOutMethods.Standard)
        {
            //Inicializar variables
            int itemKey;
            WorkOrderLine temp;
            Dispatch dispatch;
            List<int> sLineKey = new List<int>();
            List<SOLine> sLines = new List<SOLine>();
            List<Tuple<WarehouseUbication, WarehouseUbicationStatus>> ubications;


            if ((dispatch = dbContext.Dispatches.Where(p => p.DispatchKey == DispatchKey).FirstOrDefault()) == null) return false;

            foreach (var item in dispatch.DispatchLines)
                sLineKey.Add(item.DeliveryLine.SOLineKey);

            foreach (var item in sLineKey)
                sLines.Add(context.SOLines.Where(p => p.SOLineKey == item).FirstOrDefault());

            foreach (var line in sLines.GroupBy(p => p.ItemKey))
            {
                itemKey = line.Key.Value;
                ubications = dbContext.WarehouseUbications.Where
                    (p => p.UbicationType.UbicType.Equals(UbicType.Picking)
                    && p.PickingKey.HasValue
                    && p.PickingKey == dispatch.Picking
                    && ((p.WarehouseUbicationsLog.ItemKey.HasValue && p.WarehouseUbicationsLog.ItemKey.Value == itemKey) || !p.WarehouseUbicationsLog.ItemKey.HasValue))
                    .ToList()
                    .Select(p => new Tuple<WarehouseUbication, WarehouseUbicationStatus>(p, GetWarehouseUbicationStatus(p.WhseUbicationKey)))
                    .ToList();

                foreach (var item1 in line)
                {
                    var qty = 0;
                    for (int i = 0; i < ubications.Count; i++)
                    {
                        if (ubications[i].Item2.Qty > qty)
                        {
                            var lpn = ubications[i].Item1.WarehouseUbicationsLog.GetLPNFromItemInLevel(ubications[i].Item2.LevelNo, itemKey).First();
                            temp = new WorkOrderLine()
                            {
                                FromWhseUbicationKey = ubications[i].Item1.WhseUbicationKey,
                                Qty = qty,
                                Status = 1,
                                ItemKey = itemKey,
                                LPNKey = lpn,
                                InvtLotKey = ubications[i].Item1.WarehouseUbicationsLog.WarehouseUbicationLogLevels.Where(p => p.LPNKey == lpn).Select(p => p.LPNRelation.LotKey).First()
                            };
                        }
                    }

                }
            }


            return true;
        }
        public int CreateMovementOrder(int ItemKey, int To, int toLvl, MovementRequestTypes type /*= MovementRequestTypes.FromAny*/)
        {
            //Inicializar variables
            WarehouseUbication ubication;
            List<WarehouseUbication> froms;
            WarehouseUbicationLogLevel logInstance;
            int WhseKey;

            if ((ubication = dbContext.WarehouseUbications
                                .Where(p => p.WhseUbicationKey == To).FirstOrDefault()) != null)
            {
                WhseKey = ubication.WhseKey;
                froms = dbContext.WarehouseUbications
                            .Where(p => p.WhseKey == WhseKey && p.Gates.Count == 0
                                        && p.BlockStatus < 3 && p.Status > 1
                                        && p.WarehouseUbicationsLog.ItemKey == ItemKey).ToList();

                if (type == MovementRequestTypes.FromPicking)
                    froms.RemoveAll(p => p.UbicationType.UbicType == UbicType.Almacenamiento);

                else if (type == MovementRequestTypes.FromStorage)
                    froms.RemoveAll(p => p.UbicationType.UbicType == UbicType.Picking);

                foreach (WarehouseUbication i in froms)
                {
                    logInstance = i.WarehouseUbicationsLog.WarehouseUbicationLogLevels.Where(p => p.ItemKey == ItemKey && p.LPNKey.HasValue).OrderBy(p => p.LPNRelation.Qty).FirstOrDefault();
                    return CreateMovementOrder(ItemKey, To, toLvl, logInstance.WhseUbicationKey, logInstance.LevelNo, logInstance.LPNKey.Value);
                }
            }
            return -1;
        }
        public int CreateMovementOrder(int ItemKey, int To, int ToLvl, int From, int FromLvl, int LPNKey)
        {
            return CreateMovementOrder(ItemKey, To, ToLvl, From, ToLvl, LPNKey, SysSession.BusinessDate);
        }
        public int CreateMovementOrder(int ItemKey, int To, int ToLvl, int From, int FromLvl, int LPNKey, DateTime date)
        {
            WarehouseUbication _from, _to;
            LPNRelation lpn;
            //WarehouseUbicationStatus _fromStatus, _toStatus;

            if ((_from = dbContext.WarehouseUbications.Where(p => p.WhseUbicationKey == From).FirstOrDefault()) == null || (_to = dbContext.WarehouseUbications.Where(p => p.WhseUbicationKey == To).FirstOrDefault()) == null)
                throw new ArgumentException("Ubication not Exist");
            if (_from.BlockStatus > 2)
                throw new ArgumentException("Origen Ubication Block");
            if (_from.WarehouseUbicationsLog.ItemKey != ItemKey)
                throw new ArgumentException("Origen Ubication not have item");
            if (_to.WarehouseUbicationsLog.ItemKey.HasValue && _to.WarehouseUbicationsLog.ItemKey != ItemKey)
                throw new ArgumentException("Destination Ubication not allow item");
            if (_from.BlockStatus == 2 || _from.BlockStatus == 4)
                throw new ArgumentException("Destination Ubication Block");
            if (!_from.WarehouseUbicationsLog.IsLevelAvaliableOut(FromLvl, ItemKey, LPNKey))
                throw new ArgumentException("Origen Ubication not Enougth Q");

            lpn = dbContext.LPNRelations.Where(p => p.LPNKey == LPNKey).FirstOrDefault();

            try
            {
                WMDataAccess.Datamodel.WorkOrder order = new WMDataAccess.Datamodel.WorkOrder()
                {
                    Type = (short)WOTranTypes.Movement,
                    FromUbicationKey = From,
                    ToUbicationKey = To,
                    Status = 2,
                    WhseKey = _from.WhseKey,
                    WorkOrderID = GetNextWorkOrder(),
                    CompanyID = SysSession.CompanyID,
                    Date = date,
                    SourceKey = 0
                };
                order.WorkOrderLines.Add(new WorkOrderLine()
                {
                    Status = 1,
                    ItemKey = ItemKey,
                    LineNo = 1,
                    FromWhseUbicationKey = From,
                    ToWhseUbicationKey = To,
                    LPNKey = LPNKey,
                    InvtLotKey = lpn.LotKey,
                    Qty = lpn.Qty,
                    FromLevelNo = FromLvl,
                    ToLevelNo = ToLvl
                });
                dbContext.WorkOrders.AddObject(order);
                dbContext.SaveChanges();
                return order.WorkOrderKey;
            }
            catch (Exception e)
            {
                throw new Exception("Error creating Order", e);
            }
        }
        public int CreateRestockedOrder(int ItemKey, int To, int ToLvl, int From, int FromLvl, int LPNKey, DateTime date)
        {
            throw new NotImplementedException();
            //WarehouseUbication _from, _to;
            //LPNRelation lpn;
            ////WarehouseUbicationStatus _fromStatus, _toStatus;

            //if ((_from = dbContext.WarehouseUbications.Where(p => p.WhseUbicationKey == From).FirstOrDefault()) == null || (_to = dbContext.WarehouseUbications.Where(p => p.WhseUbicationKey == To).FirstOrDefault()) == null)
            //    throw new ArgumentException("Ubication not Exist");
            //if (_from.BlockStatus > 2)
            //    throw new ArgumentException("Origen Ubication Block");
            //if (_from.WarehouseUbicationsLog.ItemKey != ItemKey)
            //    throw new ArgumentException("Origen Ubication not have item");
            //if (_to.WarehouseUbicationsLog.ItemKey.HasValue && _to.WarehouseUbicationsLog.ItemKey != ItemKey)
            //    throw new ArgumentException("Destination Ubication not allow item");
            //if (_from.BlockStatus == 2 || _from.BlockStatus == 4)
            //    throw new ArgumentException("Destination Ubication Block");
            //if (!_from.WarehouseUbicationsLog.IsLevelAvaliableOut(FromLvl, ItemKey, LPNKey))
            //    throw new ArgumentException("Origen Ubication not Enougth Q");

            //lpn = dbContext.LPNRelations.Where(p => p.LPNKey == LPNKey).FirstOrDefault();

            //try
            //{
            //    WMDataAccess.Datamodel.WorkOrder order = new WMDataAccess.Datamodel.WorkOrder()
            //    {
            //        Type = (short)WOTranTypes.Restocked,
            //        FromUbicationKey = From,
            //        ToUbicationKey = To,
            //        Status = 2,
            //        WhseKey = _from.WhseKey,
            //        WorkOrderID = GetNextWorkOrder(),
            //        CompanyID = SysSession.CompanyID,
            //        Date = date,
            //        SourceKey = 0
            //    };
            //    order.WorkOrderLines.Add(new WorkOrderLine()
            //    {
            //        Status = 1,
            //        ItemKey = ItemKey,
            //        LineNo = 1,
            //        FromWhseUbicationKey = From,
            //        ToWhseUbicationKey = To,
            //        LPNKey = LPNKey,
            //        InvtLotKey = lpn.LotKey,
            //        Qty = lpn.Qty,
            //        FromLevelNo = FromLvl,
            //        ToLevelNo = ToLvl
            //    });
            //    dbContext.WorkOrders.AddObject(order);
            //    dbContext.SaveChanges();
            //    return order.WorkOrderKey;
            //}
            //catch (Exception e)
            //{
            //    throw new Exception("Error creating Order", e);
            //}
        }
        #endregion    

        #region "WorkOrder Operations"
        public string GetNextWorkOrder()
        {
            return GetNextTransactionNumber();
        }
        public bool ConfirmWorkOrder(int workOrderKey)
        {
            WorkOrder order;
            if ((order = dbContext.WorkOrders.Where(p => p.WorkOrderKey == workOrderKey).FirstOrDefault()) != null && order.Status == 1)
            {
                order.Status = 2;
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public bool CompleteWorkOrderLine(int woLineKey)
        {
            LoadContext();
            WorkOrderLine woLine = dbContext.WorkOrderLines.Where(p => p.WOLineKey == woLineKey).FirstOrDefault();
            WarehouseUbication ubication;
            WarehouseUbicationLog log = null, backlog = null;
            if (woLine.Status == 2 || woLine.WorkOrder.Status != 2)
                return false;
            switch (woLine.WorkOrder.Type)
            {
                case 1:
                    ubication = woLine.ToWarehouseUbication;
                    log = ubication.WarehouseUbicationsLog;
                    if (ubication.Status == 3 || !log.IsLevelAvaliableIn(woLine.ToLevelNo.Value))
                        return false;
                    if (!log.PushLPN(woLine.ItemKey, woLine.LPNKey, woLine.ToLevelNo.Value))
                        return false;
                    break;
                case 4:
                    ubication = woLine.FromWarehouseUbication;
                    backlog = ubication.WarehouseUbicationsLog;
                    if (ubication.Status == 1 || !backlog.IsLevelAvaliableOut(woLine.FromLevelNo.Value, woLine.ItemKey, woLine.LPNKey, woLine.Qty))
                        return false;
                    if (!backlog.PopLPN(woLine.ItemKey, woLine.LPNKey, woLine.FromLevelNo.Value))
                        return false;
                    ubication = woLine.ToWarehouseUbication;
                    log = ubication.WarehouseUbicationsLog;
                    if (ubication.Status == 3 || !log.IsLevelAvaliableIn(woLine.ToLevelNo.Value))
                        return false;
                    if (!log.PushLPN(woLine.ItemKey, woLine.LPNKey, woLine.ToLevelNo.Value))
                        return false;
                    break;
            }
            try
            {
                if (log != null)
                    log.UpdateStatus();
                if (backlog != null)
                    backlog.UpdateStatus();
                woLine.Status = 2;
                woLine.CompleteDate = DateTime.Now;
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void UpdatekWorkOrderCompleteStatus(int WorkOrderKey)
        {
            WorkOrder order;
            if ((order = dbContext.WorkOrders.Where(p => p.WorkOrderKey == WorkOrderKey).FirstOrDefault()) != null)
            {
                if (order.Status != 2) return;
                foreach (WorkOrderLine i in order.WorkOrderLines)
                    if (i.Status == 1)
                        return;
            }
            order.Status = 3;
            dbContext.SaveChanges();
        }
        #endregion
    }
}
