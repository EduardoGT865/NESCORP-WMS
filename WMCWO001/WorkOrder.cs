using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Net4Sage;
using WMDataAccess.Datamodel;
using Net4Sage.CIUtils;
using Net4Sage.Controls.Lookup;
using Net4Sage.DataAccessModel;
using WMModuleUtils;
using System.Configuration;
using System.Threading;
using System.Configuration;

namespace WMCWO001
{
    public partial class WorkOrder : Form
    {
        public List<Distribuir> Distribucion = new List<Distribuir>();
        private WMDBContext dbContext;
        private int Almacen, Tran_Key,AlmacenDestino,ID_OT, itemID,GavetaID, PuertaID, AlmacenHasta,IDLote, PartidaID;
        int PosDisponibles = 0;
        decimal? sumaOTs, CantidadOrg;
        decimal qtyord, Pendiente;
        String TranID, Areaid;
        private decimal Conversion, PesoTotal;
        private List<Lookup> ListAlmacen = new List<Lookup>();
        private List<Articulo> ListArt = new List<Articulo>();
        private List<Gaveta> ListGaveta = new List<Gaveta>();
        private List<OrdenCompra> ListPO = new List<OrdenCompra>();
        private List<ArticuloPO> ListPOArt = new List<ArticuloPO>();
        private List<Devoluciones> ListDev = new List<Devoluciones>();
        //private List<Puerta> ListPuerta = new List<Puerta>();
        private List<Ubicacion> ListUbicacion = new List<Ubicacion>();
        private DSWorkOrderTableAdapters.tpoPurchOrderTableAdapter taPO = new DSWorkOrderTableAdapters.tpoPurchOrderTableAdapter();
        private DSWorkOrderTableAdapters.timwmsEstadosTableAdapter taEstados = new DSWorkOrderTableAdapters.timwmsEstadosTableAdapter();
        private DSWorkOrderTableAdapters.timwmsTipoOrdenTableAdapter taTipoOrden = new DSWorkOrderTableAdapters.timwmsTipoOrdenTableAdapter();
        private DSWorkOrderTableAdapters.timWarehouseTableAdapter taAlmacen = new DSWorkOrderTableAdapters.timWarehouseTableAdapter();
        private DSWorkOrderTableAdapters.timItemTableAdapter taArticulo = new DSWorkOrderTableAdapters.timItemTableAdapter();
        private DSWorkOrderTableAdapters.tciUnitMeasureTableAdapter taMeasure = new DSWorkOrderTableAdapters.tciUnitMeasureTableAdapter();
        private DSWorkOrderTableAdapters.timWhseBinTableAdapter taBin = new DSWorkOrderTableAdapters.timWhseBinTableAdapter();
        private DSWorkOrderTableAdapters.timwmsDetallePuertasTableAdapter taDetPuerta = new DSWorkOrderTableAdapters.timwmsDetallePuertasTableAdapter();
        private DSWorkOrderTableAdapters.timwmsUbicacionTableAdapter taUbicaciones = new DSWorkOrderTableAdapters.timwmsUbicacionTableAdapter();
        private DSWorkOrderTableAdapters.tciSurrogateKeyTableAdapter taSurrogate = new DSWorkOrderTableAdapters.tciSurrogateKeyTableAdapter();
        private DSWorkOrderTableAdapters.tciItemUnitMeasureTableAdapter taUnitMeasure = new DSWorkOrderTableAdapters.tciItemUnitMeasureTableAdapter();
        private DSWorkOrderTableAdapters.PartidasTableAdapter taPartida = new DSWorkOrderTableAdapters.PartidasTableAdapter();
        private DSWorkOrderTableAdapters.timwmsTransaccionTableAdapter taTransaccion = new DSWorkOrderTableAdapters.timwmsTransaccionTableAdapter();
        private DSWorkOrderTableAdapters.timwmsPartidasTableAdapter taPartidas = new DSWorkOrderTableAdapters.timwmsPartidasTableAdapter();
        private DSWorkOrderTableAdapters.UltimaTransaccionTableAdapter taUltimaTran = new DSWorkOrderTableAdapters.UltimaTransaccionTableAdapter();
        private DSWorkOrderTableAdapters.timwmsLoteTableAdapter taLote = new DSWorkOrderTableAdapters.timwmsLoteTableAdapter();
        private DSWorkOrderTableAdapters.timwmsDistribucionTableAdapter taDistribucion = new DSWorkOrderTableAdapters.timwmsDistribucionTableAdapter();
        private DSWorkOrderTableAdapters.timwmsOrdenTrabajoTableAdapter taOT = new DSWorkOrderTableAdapters.timwmsOrdenTrabajoTableAdapter();
        private DSWorkOrderTableAdapters.UltimoOTTableAdapter taUltimoOT = new DSWorkOrderTableAdapters.UltimoOTTableAdapter();
        private DSWorkOrderTableAdapters.timwmsDetalleOTTableAdapter taDetalleOT = new DSWorkOrderTableAdapters.timwmsDetalleOTTableAdapter();
        private DSWorkOrderTableAdapters.timwmsProfundidadTableAdapter taProfundiad = new DSWorkOrderTableAdapters.timwmsProfundidadTableAdapter();
        private DSWorkOrderTableAdapters.timwmsRestringirArticulosTableAdapter taRestriccionArt = new DSWorkOrderTableAdapters.timwmsRestringirArticulosTableAdapter();
        private DSWorkOrderTableAdapters.timwmsAlmacenArtTableAdapter taAlmacenArt = new DSWorkOrderTableAdapters.timwmsAlmacenArtTableAdapter();
        private DSWorkOrderTableAdapters.timwmsDispUbicacionesTableAdapter taUbiDisponibles = new DSWorkOrderTableAdapters.timwmsDispUbicacionesTableAdapter();
        private DSWorkOrderTableAdapters.ExistUbicacionTableAdapter taExistUbicacion = new DSWorkOrderTableAdapters.ExistUbicacionTableAdapter();
        private DSWorkOrderTableAdapters.UltimoDetalleOTTableAdapter taUltimoDetalleOT = new DSWorkOrderTableAdapters.UltimoDetalleOTTableAdapter();
        private DSWorkOrderTableAdapters.OTyPalletsExistentesTableAdapter taOTPallets = new DSWorkOrderTableAdapters.OTyPalletsExistentesTableAdapter();
        private DSWorkOrderTableAdapters.twmParametersTableAdapter taParameter = new DSWorkOrderTableAdapters.twmParametersTableAdapter();
        private DSWorkOrderTableAdapters.timwmsPesoNivelTableAdapter taPesoNivel = new DSWorkOrderTableAdapters.timwmsPesoNivelTableAdapter();
        private DSWorkOrderTableAdapters.SumaOTTableAdapter taSumaOT = new DSWorkOrderTableAdapters.SumaOTTableAdapter();
        private DSWorkOrderTableAdapters.SumaDistribucionTableAdapter taSumaDistribucion = new DSWorkOrderTableAdapters.SumaDistribucionTableAdapter();
        private DSDevolucionesTableAdapters.vdvCustomerReturnTableAdapter taCustomerDev = new DSDevolucionesTableAdapters.vdvCustomerReturnTableAdapter();
        private DSDevolucionesTableAdapters.DistribuirDevolucionesTableAdapter taDistDev = new DSDevolucionesTableAdapters.DistribuirDevolucionesTableAdapter();

        public WorkOrder(ref SageSession session)
        {
            InitializeComponent();
            SysSession.InitializeSession(session);            
            LoadContext();          
        }        
        private void LoadContext()
        {
            try
            {
                System.Data.EntityClient.EntityConnectionStringBuilder connectionString = new System.Data.EntityClient.EntityConnectionStringBuilder()
                {
                    Metadata = "res://*/DataModel.csdl|res://*/DataModel.ssdl|res://*/DataModel.msl",
                    Provider = "System.Data.SqlClient",
                    ProviderConnectionString = SysSession.GetConnectionString()
                };
                dbContext = new WMDBContext(connectionString.ToString());
                Conexion.SaveConnectionString("WMCWO001.Properties.Settings.sage500_app_recetasConnectionString", connectionString.ProviderConnectionString.ToString());
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void CbxTipoOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTipoOrden.Text == "Compra")
            {
                CargarCompras();
                cbxTipoOrden.Enabled = false;
                lkuTransaccion.Enabled = true;
            }
            else if(cbxTipoOrden.Text == "Devoluciones")
            {
                CargarDevoluciones();
                cbxTipoOrden.Enabled = false;
                lkuTransaccion.Enabled = true;
            }
            else
            {
                ////Obtener la unidad de medida y cargarlos al ComboBox
                DSWorkOrder.tciUnitMeasureDataTable dtMeasure = taMeasure.GetData(SysSession.CompanyID);
                DataRow RowMeasure = dtMeasure.NewRow();
                RowMeasure["UnitMeasKey"] = 0;
                RowMeasure["UnitMeasID"] = "UM";
                dtMeasure.Rows.InsertAt(RowMeasure, 0);
                cbxUM.ValueMember = "UnitMeasKey";
                cbxUM.DisplayMember = "UnitMeasID";
                cbxUM.DataSource = dtMeasure;
            }
        }
        #region METODOS COMPRAS
        public void CargarPartida(List<Distribuir> Lista)
        {
            try
            {                
                Distribucion.AddRange(Lista);
                if (Distribucion.Count > 0)
                {
                    for (int i = 0; i < Distribucion.Count; i++)
                    {
                        int cantrows = grdArtSelect.RowCount;
                        if (grdArtSelect.RowCount > 0 && i < cantrows)
                        {
                            DSWorkOrder.timwmsPartidasDataTable dtPartidas = taPartidas.GetData_ExistPartida(Tran_Key, Convert.ToInt32(grdArtSelect.Rows[i].Cells["POLineKey2"].Value.ToString()));
                            decimal total = Convert.ToDecimal(dtPartidas.Rows[0]["Cant_Recibida"].ToString());
                            if(total != 0)
                            {
                                total = total + Convert.ToDecimal(Distribucion[i].CantRecibida.ToString());
                            }
                            else { total = 0; }
                            grdArtSelect.Rows[i].Cells["Partida"].Value = Distribucion[i].Partida.ToString();
                            grdArtSelect.Rows[i].Cells["Articulo2"].Value = Distribucion[i].Articulo.ToString();
                            grdArtSelect.Rows[i].Cells["Descripcion"].Value = Distribucion[i].Descripcion.ToString();
                            grdArtSelect.Rows[i].Cells["UM2"].Value = Distribucion[i].UM.ToString();
                            grdArtSelect.Rows[i].Cells["Recibido"].Value = total;
                            grdArtSelect.Rows[i].Cells["CantARecibir"].Value = Distribucion[i].CantRecibida.ToString();
                            grdArtSelect.Rows[i].Cells["CantPend"].Value = Convert.ToDecimal(Distribucion[i].CantTotal.ToString()) - Convert.ToDecimal(Distribucion[i].CantRecibida.ToString());
                            grdArtSelect.Rows[i].Cells["ItemKeyOT"].Value = Convert.ToInt32(Distribucion[i].ItemKey.ToString());
                            grdArtSelect.Rows[i].Cells["UmKey2"].Value = Convert.ToInt32(Distribucion[i].umkey.ToString());
                            grdArtSelect.Rows[i].Cells["Whsekey"].Value = Convert.ToInt32(Distribucion[i].WhseKey.ToString());
                            grdArtSelect.Rows[i].Cells["WhseID2"].Value = Distribucion[i].WhseID.ToString();
                            grdArtSelect.Rows[i].Cells["POLineKey2"].Value = Convert.ToInt32(Distribucion[i].POLineKey.ToString());
                            grdArtSelect.Rows[i].Cells["CantRecibida"].Value = Convert.ToDecimal(grdArtSelect.Rows[i].Cells["Recibido"].Value.ToString());
                        }
                        else
                        {
                            grdArtSelect.Rows.Add
                            (
                                Distribucion[i].Partida.ToString(),
                                Distribucion[i].Articulo.ToString(),
                                Distribucion[i].Descripcion.ToString(),
                                Distribucion[i].UM.ToString(),
                                //Distribucion[i].CantTotal.ToString(),
                                0,
                                Distribucion[i].CantRecibida.ToString(),
                                Convert.ToDecimal(Distribucion[i].CantTotal.ToString()) - Convert.ToDecimal(Distribucion[i].CantRecibida.ToString()),
                                Convert.ToInt32(Distribucion[i].ItemKey.ToString()),
                                Convert.ToInt32(Distribucion[i].umkey.ToString()),
                                Convert.ToInt32(Distribucion[i].WhseKey.ToString()),
                                Distribucion[i].WhseID.ToString(),
                                Convert.ToInt32(Distribucion[i].POLineKey.ToString()),
                                Convert.ToDecimal(Distribucion[i].CantRecibida.ToString())
                            );
                            
                        }
                    }                   
                    btnDistribuir.Enabled = true;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PartidasExistentes(int Trankey)
        {
            DSWorkOrder.timwmsPartidasDataTable dtPartidas = taPartidas.GetData(Trankey);
            if (dtPartidas.Count > 0)
            {
                grdArtSelect.Rows.Clear();
                PartidaID = Convert.ToInt32(dtPartidas.Rows[0]["Fk_TranKeyInv"].ToString());
                DSWorkOrder.PartidasDataTable dtPartida = taPartida.GetData(Trankey);
                DataRow[] rows = dtPartida.Select();
                for (int i = 0; i < dtPartidas.Count; i++)
                {
                    qtyord = Convert.ToDecimal(rows[i]["QtyOrd"].ToString());
                    Pendiente = Convert.ToDecimal(dtPartidas.Rows[i]["Cant_Pendiente"].ToString());
                    grdArtSelect.Rows.Add
                        (
                            rows[i]["POLineNo"].ToString(),
                            rows[i]["ItemID"].ToString(),
                            rows[i]["Description"].ToString(),
                            rows[i]["UnitMeasID"].ToString(),
                            //qtyord - Pendiente,
                            dtPartidas.Rows[i]["Cant_Recibida"].ToString(),
                            dtPartidas.Rows[i]["Cant_Recibiendo"].ToString(),
                            dtPartidas.Rows[i]["Cant_Pendiente"].ToString(),
                            dtPartidas.Rows[i]["Fk_Articulo"].ToString(),
                            dtPartidas.Rows[i]["Fk_Um"].ToString(),
                            dtPartidas.Rows[i]["Fk_Almacen"].ToString(),
                            rows[i]["WhseID"].ToString(),
                            dtPartidas.Rows[i]["Fk_LineKey"].ToString(),
                            qtyord
                        );
                }
                //btnDistribuir.Enabled = true;
                //lkuWarehouse.Text = dtPartida.Rows[0]["WhseID"].ToString();
            }
        }
        public void CargarOT(bool Bandera)
        {
            btnGenerarOT.Enabled = Bandera;
        }
        public void PalletsExistentes(string Transaccion)
        {
            grdOT.Rows.Clear();
            grdPallets.Rows.Clear();
            DSWorkOrder.OTyPalletsExistentesDataTable dtOTPallets = taOTPallets.GetData(Transaccion);
            DataRow[] RowsOTP = dtOTPallets.Select();
            for (int i = 0; i < dtOTPallets.Count; i++)
            {
                grdOT.Rows.Add
                    (
                        RowsOTP[i]["Ot_ID"].ToString(),
                        RowsOTP[i]["Art_Descripcion"].ToString(),
                        RowsOTP[i]["LPN"].ToString(),
                        RowsOTP[i]["Num_Lote"].ToString(),
                        RowsOTP[i]["Fecha_Vencimiento"].ToString(),
                        RowsOTP[i]["Fecha_Fabricacion"].ToString(),
                        RowsOTP[i]["Porcentaje_Frescura"].ToString(),
                        RowsOTP[i]["Cantidad"].ToString(),
                        RowsOTP[i]["UnitMeasID"].ToString(),
                        RowsOTP[i]["Cantidad_Destino"].ToString(),
                        RowsOTP[i]["WhseBinID"].ToString(),
                        null,
                        RowsOTP[i]["NumUbicacionID"].ToString()
                    );
                grdPallets.Rows.Add
                    (
                        RowsOTP[i]["Ot_ID"].ToString(),
                        RowsOTP[i]["Det_Ot_ID"].ToString(),
                        RowsOTP[i]["LPNKey"].ToString(),
                        RowsOTP[i]["LPN"].ToString(),
                        RowsOTP[i]["Cantidad_Destino"].ToString(),
                        RowsOTP[i]["UnitMeasID"].ToString(),
                        RowsOTP[i]["Fk_Compania"].ToString()
                    );
            }
        }
        private void CargarCompras()
        {
            try
            {
                DSWorkOrder.tpoPurchOrderDataTable dtPO = taPO.GetData();
                DataRow[] rows = dtPO.Select();
                for (int i = 0; i < rows.Length; i++)
                {
                    ListPO.Add(new OrdenCompra
                    {
                        TranID = rows[i]["TranID"].ToString(),
                        POKey = Convert.ToInt32(rows[i]["POKey"].ToString()),
                        ChngOrdNo = rows[i]["ChngOrdNo"].ToString(),
                        CreateUserID = rows[i]["CreateUserID"].ToString(),
                        ChngReason = rows[i]["ChngReason"].ToString(),
                        PurchAmt = rows[i]["PurchAmt"].ToString(),
                        ChngOrdDate = rows[i]["ChngOrdDate"].ToString()
                    });
                }
                lkuTransaccion.SetData(ListPO);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region METODOS DEVOLUCIONES
        public void CargarDevoluciones()
        {
            try
            {
                DSDevoluciones.vdvCustomerReturnDataTable dtCustomerDev = taCustomerDev.GetData();
                DataRow[] rows = dtCustomerDev.Select();
                for (int i = 0; i < rows.Length; i++)
                {
                    ListDev.Add(new Devoluciones
                    {
                        TranID = rows[i]["TranID"].ToString(),
                        ShipKey = Convert.ToInt32(rows[i]["ShipKey"].ToString()),
                        TranCmnt = rows[i]["TranCmnt"].ToString()
                    });
                }
                lkuTransaccion.SetData(ListDev);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void DevolucionesExistentes(int shipkey)
        {
            DSWorkOrder.timwmsPartidasDataTable dtPartidas = taPartidas.GetData(shipkey);
            if (dtPartidas.Count > 0)
            {
                grdArtSelect.Rows.Clear();
                PartidaID = Convert.ToInt32(dtPartidas.Rows[0]["Fk_TranKeyInv"].ToString());
                DSDevoluciones.DistribuirDevolucionesDataTable dtDistDev = taDistDev.GetData_ExistDev(shipkey);
                //DSWorkOrder.PartidasDataTable dtPartida = taPartida.GetData(shipkey);
                DataRow[] rows = dtDistDev.Select();
                for (int i = 0; i < dtPartidas.Count; i++)
                {
                    qtyord = Math.Abs(Convert.ToDecimal(rows[i]["QtyShipped"].ToString()));
                    Pendiente = Convert.ToDecimal(dtPartidas.Rows[i]["Cant_Pendiente"].ToString());
                    grdArtSelect.Rows.Add
                        (
                            rows[i]["SOLineNo"].ToString(),
                            rows[i]["ItemID"].ToString(),
                            rows[i]["ShortDesc"].ToString(),
                            rows[i]["UnitMeasID"].ToString(),
                            //qtyord - Pendiente,
                            dtPartidas.Rows[i]["Cant_Recibida"].ToString(),
                            dtPartidas.Rows[i]["Cant_Recibiendo"].ToString(),
                            dtPartidas.Rows[i]["Cant_Pendiente"].ToString(),
                            dtPartidas.Rows[i]["Fk_Articulo"].ToString(),
                            dtPartidas.Rows[i]["Fk_Um"].ToString(),
                            dtPartidas.Rows[i]["Fk_Almacen"].ToString(),
                            rows[i]["WhseID"].ToString(),
                            dtPartidas.Rows[i]["Fk_LineKey"].ToString(),
                            qtyord
                        );
                }
            }
        }
        #endregion
        private void WorkOrder_Load(object sender, EventArgs e)
        {
            //Obtener los estados y cargarlos al ComboBox
            DSWorkOrder.timwmsEstadosDataTable dtEstados = taEstados.GetData();
            //DataRow RowEstado = dtEstados.NewRow();
            //RowEstado["Pkey_Estados"] = 0;
            //RowEstado["Estado"] = "Seleccione_Estado";
            //dtEstados.Rows.InsertAt(RowEstado, 0);
            cbxEstado.ValueMember = "Pkey_Estados";
            cbxEstado.DisplayMember = "Estado";
            cbxEstado.DataSource = dtEstados;
            //cbxEstado.ValueMember = dtPartidas.Rows[0]["Fk_Estatus"].ToString();

            //Obtener los tipos de orden y cargarlos al ComboBox
            DSWorkOrder.timwmsTipoOrdenDataTable dtTipoOrden = taTipoOrden.GetData();
            DataRow RowTipo = dtTipoOrden.NewRow();
            RowTipo["Pkey_Tipo_Orden"] = 0;
            RowTipo["Tipo"] = "Tipo Orden";
            dtTipoOrden.Rows.InsertAt(RowTipo, 0);
            cbxTipoOrden.ValueMember = "Pkey_Tipo_Orden";
            cbxTipoOrden.DisplayMember = "Tipo";
            cbxTipoOrden.DataSource = dtTipoOrden;
            //dtpFechaVencimiento.MinDate = DateTime.Now;
        }
        private void BtnImportar_Click(object sender, EventArgs e)
        {
            if(cbxTipoOrden.Text == "Compra")
            {
                //grdArtSelect.Rows.Clear();
                Distribucion.RemoveRange(0, Distribucion.Count);
                WMCWO001.DistribuirPartida Dist = new DistribuirPartida(ref SysSession, Tran_Key, lkuTransaccion.Text,"Compra");
                Dist.ShowDialog();
                //this.Hide();
            }
            else if(cbxTipoOrden.Text == "Devoluciones")
            {
                WMCWO001.DistribuirPartida Dist = new DistribuirPartida(ref SysSession, Tran_Key, lkuTransaccion.Text, "Devoluciones");
                Dist.ShowDialog();
            }

        }
        private void BtnDistribuir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(grdArtSelect.CurrentRow.Cells["CantARecibir"].Value.ToString()) > 0)
                {
                    DateTime thisDay = DateTime.Now;
                    DSWorkOrder.timwmsTransaccionDataTable dtTransaccion = taTransaccion.GetData(Tran_Key);
                    if (dtTransaccion.Count <= 0)
                    {
                        taTransaccion.InsertTransaccion
                        (
                            Tran_Key,
                            TranID,
                            Convert.ToInt32(cbxTipoOrden.GetItemText(cbxTipoOrden.SelectedValue)),
                            Convert.ToInt32(cbxEstado.GetItemText(cbxEstado.SelectedValue)),
                            SysSession.CompanyID,
                            SysSession.UserID,
                            thisDay,
                            "1"
                        );
                    }
                    else
                    {
                        taTransaccion.UpdateTransaccion
                        (
                            Tran_Key,
                            TranID,
                            Convert.ToInt32(cbxTipoOrden.GetItemText(cbxTipoOrden.SelectedValue)),
                            Convert.ToInt32(cbxEstado.GetItemText(cbxEstado.SelectedValue)),
                            SysSession.CompanyID,
                            SysSession.UserID,
                            thisDay.ToString(),
                            "1",
                            Convert.ToUInt16(dtTransaccion.Rows[0]["TrankeyInv"].ToString())
                        );
                    }                    
                    foreach (DataGridViewRow Row in grdArtSelect.Rows)
                        {
                            DSWorkOrder.timwmsPartidasDataTable dtPartidas = taPartidas.GetData_Line(Tran_Key, Convert.ToInt32(grdArtSelect.Rows[Row.Index].Cells["POLineKey2"].Value.ToString()));
                            if (dtPartidas.Count <= 0)
                            {
                                if (PartidaID != 0)
                                {
                                    taPartidas.InsertPartida
                                    (
                                        PartidaID,
                                        Tran_Key,
                                        Convert.ToInt32(grdArtSelect.Rows[Row.Index].Cells["POLineKey2"].Value.ToString()),
                                        Convert.ToInt32(grdArtSelect.Rows[Row.Index].Cells["Partida"].Value.ToString()),
                                        Convert.ToInt32(grdArtSelect.Rows[Row.Index].Cells["ItemKeyOT"].Value.ToString()),
                                        grdArtSelect.Rows[Row.Index].Cells["Descripcion"].Value.ToString(),
                                        Convert.ToDecimal(grdArtSelect.Rows[Row.Index].Cells["Recibido"].Value.ToString()),
                                        Convert.ToDecimal(grdArtSelect.Rows[Row.Index].Cells["CantARecibir"].Value.ToString()),
                                        Convert.ToDecimal(grdArtSelect.Rows[Row.Index].Cells["CantPend"].Value.ToString()),
                                        Convert.ToInt32(grdArtSelect.Rows[Row.Index].Cells["UmKey2"].Value.ToString()),
                                        Convert.ToInt32(grdArtSelect.Rows[Row.Index].Cells["Whsekey"].Value.ToString()),
                                        SysSession.UserID,
                                        thisDay.ToString(),
                                        "1"
                                    );
                                }
                                else
                                {
                                    DSWorkOrder.UltimaTransaccionDataTable dtUltimo = taUltimaTran.GetData();
                                    taPartidas.InsertPartida
                                    (
                                        Convert.ToInt32(dtUltimo.Rows[0]["TableTransaccion"].ToString()),
                                        Tran_Key,
                                        Convert.ToInt32(grdArtSelect.Rows[Row.Index].Cells["POLineKey2"].Value.ToString()),
                                        Convert.ToInt32(grdArtSelect.Rows[Row.Index].Cells["Partida"].Value.ToString()),
                                        Convert.ToInt32(grdArtSelect.Rows[Row.Index].Cells["ItemKeyOT"].Value.ToString()),
                                        grdArtSelect.Rows[Row.Index].Cells["Descripcion"].Value.ToString(),
                                        Convert.ToDecimal(grdArtSelect.Rows[Row.Index].Cells["Recibido"].Value.ToString()),
                                        Convert.ToDecimal(grdArtSelect.Rows[Row.Index].Cells["CantARecibir"].Value.ToString()),
                                        Convert.ToDecimal(grdArtSelect.Rows[Row.Index].Cells["CantPend"].Value.ToString()),
                                        Convert.ToInt32(grdArtSelect.Rows[Row.Index].Cells["UmKey2"].Value.ToString()),
                                        Convert.ToInt32(grdArtSelect.Rows[Row.Index].Cells["Whsekey"].Value.ToString()),
                                        SysSession.UserID,
                                        thisDay.ToString(),
                                        "1"
                                    );
                                }
                            }
                            else
                            {
                                taPartidas.UpdatePartidas
                                (
                                    Convert.ToInt32(grdArtSelect.Rows[Row.Index].Cells["Partida"].Value.ToString()),
                                    Convert.ToInt32(grdArtSelect.Rows[Row.Index].Cells["ItemKeyOT"].Value.ToString()),
                                    grdArtSelect.Rows[Row.Index].Cells["Descripcion"].Value.ToString(),
                                    Convert.ToDecimal(grdArtSelect.Rows[Row.Index].Cells["Recibido"].Value.ToString()),
                                    Convert.ToDecimal(grdArtSelect.Rows[Row.Index].Cells["CantARecibir"].Value.ToString()),                                    
                                    Convert.ToDecimal(grdArtSelect.Rows[Row.Index].Cells["CantPend"].Value.ToString()),
                                    Convert.ToInt32(grdArtSelect.Rows[Row.Index].Cells["UmKey2"].Value.ToString()),
                                    Convert.ToInt32(grdArtSelect.Rows[Row.Index].Cells["Whsekey"].Value.ToString()),
                                    SysSession.UserID,
                                    thisDay.ToString(),
                                    "1",
                                    PartidaID,
                                    Tran_Key,
                                    Convert.ToInt32(grdArtSelect.Rows[Row.Index].Cells["POLineKey2"].Value.ToString())
                                );
                            }

                        }
                    if(cbxTipoOrden.Text == "Compra")
                    {
                        WMCWO001.Distribuir_Inventario DistInv = new Distribuir_Inventario(ref SysSession, Tran_Key, Convert.ToInt32(grdArtSelect.CurrentRow.Cells["ItemKeyOT"].Value.ToString()), Convert.ToDecimal(grdArtSelect.CurrentRow.Cells["CantARecibir"].Value.ToString()),"Compra");
                        DistInv.ShowDialog();
                    }
                    else if(cbxTipoOrden.Text == "Devoluciones")
                    {
                        WMCWO001.Distribuir_Inventario DistInv = new Distribuir_Inventario(ref SysSession, Tran_Key, Convert.ToInt32(grdArtSelect.CurrentRow.Cells["ItemKeyOT"].Value.ToString()), Convert.ToDecimal(grdArtSelect.CurrentRow.Cells["CantARecibir"].Value.ToString()), "Devoluciones");
                        DistInv.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Debe importar la cantidad a distribuir", "Sage MAS 500");
                }                
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }               
        private void WorkOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool ban = false;
            foreach(DataGridViewRow OT in grdArtSelect.Rows)
            {
                if(Convert.ToDecimal(grdArtSelect.Rows[OT.Index].Cells["CantARecibir"].Value.ToString()) == 0 && Convert.ToDecimal(grdArtSelect.Rows[OT.Index].Cells["CantPend"].Value.ToString()) == 0)
                {
                    ban = true;
                }
                else
                {
                    ban = false;
                    break;
                }
            }
            if(ban == true)
            {
                taTransaccion.UpdateStatus(3, PartidaID);
            }
            else
            {
                taTransaccion.UpdateStatus(2, PartidaID);
            }
        }
        private void LkuTransaccion_OnLookupReturn(object sender, LookupReturnEventArgs eventArgs)
        {
            try
            {
                if(cbxTipoOrden.Text == "Compra")
                {
                    for (int i = 0; i < ListPO.Count; i++)
                    {
                        if (Convert.ToString(ListPO[i].TranID) == lkuTransaccion.Text)
                        {
                            ListPOArt.RemoveRange(0, ListPOArt.Count);
                            Tran_Key = ListPO[i].POKey;
                            TranID = ListPO[i].TranID;
                            PartidasExistentes(Tran_Key);
                            PalletsExistentes(TranID);
                            //dtpOT.Value = Convert.ToDateTime(ListPO[i].ChngOrdDate);
                            btnImportar.Enabled = true;
                            break;
                        }
                    }
                }
                else if(cbxTipoOrden.Text == "Devoluciones")
                {
                    for (int i = 0; i < ListDev.Count; i++)
                    {
                        if (Convert.ToString(ListDev[i].TranID) == lkuTransaccion.Text)
                        {
                            Tran_Key = ListDev[i].ShipKey;
                            TranID = ListDev[i].TranID;                            
                            btnImportar.Enabled = true;
                            DevolucionesExistentes(Tran_Key);
                            break;
                        }
                    }
                }                
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //for(int i = 1; i<=100; i++)
            //{
            //    Thread.Sleep(10);
            //    backgroundWorker1.WorkerReportsProgress = true;
            //    backgroundWorker1.ReportProgress(i);
            //}
        }
        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBar1.Value = e.ProgressPercentage;
            //label18.Text = e.ProgressPercentage.ToString() + "%";
        }
        private void GrdOT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdOt.Text = grdOT.CurrentRow.Cells["No"].Value.ToString();
            lkuArticulo.Text = grdOT.CurrentRow.Cells["Articulo"].Value.ToString();
            txtLPN.Text = grdOT.CurrentRow.Cells["LPN"].Value.ToString();
            lkuLote.Text = grdOT.CurrentRow.Cells["Lote"].Value.ToString();
            dtpFechaVencimiento.Value = Convert.ToDateTime(grdOT.CurrentRow.Cells["Fecha_Vencimiento"].Value);
            dtpFechaFabricacion.Value = Convert.ToDateTime(grdOT.CurrentRow.Cells["Fecha_Fabricacion"].Value);
            txtFrescura.Text =  grdOT.CurrentRow.Cells["Frescura"].Value.ToString();
            nudCantidad.Value = Convert.ToDecimal(grdOT.CurrentRow.Cells["Cantidad"].Value.ToString());
            cbxUM.Text = grdOT.CurrentRow.Cells["UM"].Value.ToString();
            lkuGaveta.Text = grdOT.CurrentRow.Cells["Gabeta"].Value.ToString();
            lkuUbiHasta.Text = grdOT.CurrentRow.Cells["Ubicacion_Hasta"].Value.ToString();
        }                    
        private void BtnGenerarOT_Click(object sender, EventArgs e)
        {
            try
            {                
                foreach (DataGridViewRow OT in grdArtSelect.Rows)
                {//Validar ubicacion del articulo en configuracion del WMS
                    progressBar1.Value = 50;
                    DSWorkOrder.timwmsAlmacenArtDataTable dtAlmacenart = taAlmacenArt.GetData(SysSession.CompanyID, Convert.ToInt32(grdArtSelect.Rows[OT.Index].Cells["ItemKeyOT"].Value.ToString()), Convert.ToInt32(grdArtSelect.Rows[OT.Index].Cells["Whsekey"].Value.ToString()));
                    //Validar ubicacion del articulo en la tabla de restricciones
                    DSWorkOrder.timwmsRestringirArticulosDataTable dtRestriccionArt = taRestriccionArt.GetData(Convert.ToInt32(grdArtSelect.Rows[OT.Index].Cells["ItemKeyOT"].Value.ToString()), Convert.ToInt32(grdArtSelect.Rows[OT.Index].Cells["Whsekey"].Value.ToString()));
                    if (dtAlmacenart.Count > 0 || dtRestriccionArt.Count > 0)
                    {//Validar que exista una distribucion generada para ese articulo
                        DSWorkOrder.timwmsDistribucionDataTable dtDistribucion = taDistribucion.GetData(Tran_Key, Convert.ToInt32(grdArtSelect.Rows[OT.Index].Cells["POLineKey2"].Value.ToString()));
                        DSWorkOrder.SumaDistribucionDataTable dtSumaDistribucion = taSumaDistribucion.GetData(Tran_Key, Convert.ToInt32(grdArtSelect.Rows[OT.Index].Cells["POLineKey2"].Value.ToString()));
                        if (dtDistribucion.Count > 0 && Convert.ToDecimal(grdArtSelect.Rows[OT.Index].Cells["Recibido"].Value.ToString()) <= Convert.ToDecimal(dtSumaDistribucion.Rows[0]["Suma"].ToString()))
                        {//Se crea la fila para almacenar las ubicaciones
                            Queue Fila = new Queue();
                            int ocupados, Ubicacionestotal = 0;
                            //Validar la gaveta para enviar a una ubicacion
                            DSWorkOrder.timWhseBinDataTable dtBin = taBin.GetData_GavetaExist(Convert.ToInt32(dtDistribucion.Rows[0]["Fk_Gaveta_Destino"].ToString()));
                            DSWorkOrder.twmParametersDataTable dtParameter = taParameter.GetData(Convert.ToInt32(grdArtSelect.Rows[OT.Index].Cells["ItemKeyOT"].Value.ToString()));
                            DSWorkOrder.tciItemUnitMeasureDataTable dtUnitMeasure = taUnitMeasure.GetData(SysSession.CompanyID, Convert.ToInt32(grdArtSelect.Rows[OT.Index].Cells["ItemKeyOT"].Value.ToString()));
                            if (dtUnitMeasure.Count >= 3)                            {
                                decimal peso = Convert.ToDecimal(dtUnitMeasure.Rows[1]["ConversionFactor"].ToString());
                                Conversion = Convert.ToDecimal(dtUnitMeasure.Rows[2]["ConversionFactor"].ToString());
                                decimal cantpall = Math.Ceiling(Convert.ToDecimal(grdArtSelect.Rows[OT.Index].Cells["CantARecibir"].Value.ToString()) / Conversion);
                                if (cantpall != 0)
                                {
                                    
                                    if (dtBin.Rows[0]["WhseBinID"].ToString() == "BE")
                                    {
                                        PesoTotal = cantpall * peso;
                                        if (dtAlmacenart.Count > 0)
                                        {
                                            //Consultar a la tabla de ubicaciones disponibles
                                            DSWorkOrder.timwmsDispUbicacionesDataTable dtUbiDisponibles = taUbiDisponibles.GetData(Convert.ToInt32(dtAlmacenart.Rows[0]["FkUbicacionOpcional"].ToString()));
                                            //MessageBox.Show(dtAlmacenart.Rows[0]["FkUbicacionOpcional"].ToString());
                                            PosDisponibles = Convert.ToInt32(dtUbiDisponibles.Rows[0]["Pos_Disponibles"].ToString());
                                            ocupados = Convert.ToInt32(dtUbiDisponibles.Rows[0]["Post_Ocupados"].ToString());
                                            if (PosDisponibles > 0)
                                            {
                                                DSWorkOrder.timwmsPesoNivelDataTable dtPesoNivel = taPesoNivel.GetData(Convert.ToInt32(dtAlmacenart.Rows[0]["FkUbicacionOpcional"].ToString()));
                                                decimal PesoSoportado = Convert.ToDecimal(dtPesoNivel.Rows[0]["Peso"].ToString());
                                                if (PesoSoportado >= PesoTotal)
                                                {
                                                    Fila.Enqueue(new Ubicaciones()
                                                    {
                                                        UbicationKey = Convert.ToInt32(dtUbiDisponibles.Rows[0]["Fk_UbicacionKey"].ToString()),
                                                        Tamaño = Convert.ToInt32(dtUbiDisponibles.Rows[0]["Pos_Disponibles"].ToString())
                                                    });
                                                }
                                                else
                                                {
                                                    decimal parcial = PosDisponibles / PesoSoportado;
                                                    int ContadorPesos = 0;
                                                    while (PesoTotal > parcial)
                                                    {
                                                        parcial = parcial + parcial;
                                                        ContadorPesos++;
                                                    }
                                                    Fila.Enqueue(new Ubicaciones()
                                                    {
                                                        UbicationKey = Convert.ToInt32(dtUbiDisponibles.Rows[0]["Fk_UbicacionKey"].ToString()),
                                                        Tamaño = ContadorPesos
                                                    });
                                                    MessageBox.Show("El peso de los pallets no es soportado por la ubicacion por default del articulo", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                            }
                                            if (PosDisponibles == 0)
                                            {
                                                MessageBox.Show("La ubicacion por default esta totalmente ocupada los pallets seran ubicados en las otras ubicaciones disponibles", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                Ubicacionestotal = 0;
                                            }
                                            else { Ubicacionestotal = 1; }
                                        }
                                        else if (dtRestriccionArt.Count > 0)
                                        {
                                            //Consultar a la tabla de ubicaciones disponibles
                                            DSWorkOrder.timwmsDispUbicacionesDataTable dtUbiDisponibles = taUbiDisponibles.GetData(Convert.ToInt32(dtRestriccionArt.Rows[0]["UbicationKey"].ToString()));
                                            PosDisponibles = Convert.ToInt32(dtUbiDisponibles.Rows[0]["Pos_Disponibles"].ToString());
                                            ocupados = Convert.ToInt32(dtUbiDisponibles.Rows[0]["Post_Ocupados"].ToString());
                                            if (PosDisponibles > 0)
                                            {
                                                DSWorkOrder.timwmsPesoNivelDataTable dtPesoNivel = taPesoNivel.GetData(Convert.ToInt32(dtAlmacenart.Rows[0]["FkUbicacionOpcional"].ToString()));
                                                decimal PesoSoportado = Convert.ToDecimal(dtPesoNivel.Rows[0]["Peso"].ToString());
                                                if (PesoSoportado >= PesoTotal)
                                                {
                                                    Fila.Enqueue(new Ubicaciones()
                                                    {
                                                        UbicationKey = Convert.ToInt32(dtUbiDisponibles.Rows[0]["Fk_UbicacionKey"].ToString()),
                                                        Tamaño = Convert.ToInt32(dtUbiDisponibles.Rows[0]["Pos_Disponibles"].ToString())
                                                    });
                                                }
                                                else
                                                {
                                                    decimal parcial = PosDisponibles / PesoSoportado;
                                                    int ContadorPesos = 0;
                                                    while (PesoTotal > parcial)
                                                    {
                                                        parcial = parcial + parcial;
                                                        ContadorPesos++;
                                                    }
                                                    Fila.Enqueue(new Ubicaciones()
                                                    {
                                                        UbicationKey = Convert.ToInt32(dtUbiDisponibles.Rows[0]["Fk_UbicacionKey"].ToString()),
                                                        Tamaño = ContadorPesos
                                                    });
                                                    MessageBox.Show("El peso de los pallets no es soportado por la ubicacion por default del articulo", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                            }
                                            if (PosDisponibles == 0)
                                            {
                                                MessageBox.Show("La ubicacion restringida para el articulo  esta totalmente ocupada los pallets seran ubicados en las otras ubicaciones disponibles", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                Ubicacionestotal = 0;
                                            }
                                            else { Ubicacionestotal = 1; }
                                        }
                                        Areaid = "Almacenamiento";
                                    }
                                    else if (dtBin.Rows[0]["WhseBinID"].ToString() == "ME" && dtParameter.Rows[0]["CommodityCodeID"].ToString() == "MP")
                                    {
                                        Areaid = "Mal estado";
                                    }
                                    else if (dtBin.Rows[0]["WhseBinID"].ToString() == "ME" && dtParameter.Rows[0]["CommodityCodeID"].ToString() == "PTI")
                                    {
                                        Areaid = "Salvage";
                                    }
                                    DateTime thisDay = DateTime.Now;
                                    //MessageBox.Show(dtUnitMeasure.Rows[0]["UnitWeight"].ToString());
                                    DSWorkOrder.timwmsOrdenTrabajoDataTable dtOT = taOT.GetData(Tran_Key, Convert.ToInt32(grdArtSelect.Rows[OT.Index].Cells["POLineKey2"].Value.ToString()));
                                    int TrankeyInv = Convert.ToInt32(dtDistribucion.Rows[0]["Fk_TrankeyInv"].ToString());
                                    DSWorkOrder.SumaOTDataTable dtSumaOT = taSumaOT.GetData(TrankeyInv, Tran_Key, Convert.ToInt32(grdArtSelect.Rows[OT.Index].Cells["POLineKey2"].Value.ToString()));
                                    if (dtOT.Count > 0)
                                    {
                                        sumaOTs = cantpall + dtOT.Count;
                                        CantidadOrg = Convert.ToDecimal(dtSumaOT.Rows[0]["Cantidad_Origen"].ToString());
                                    }
                                    //Validar si existen ubicaciones en los almacenes Convert.ToInt32(grdArtSelect.Rows[OT.Index].Cells["Whsekey"].Value.ToString())   
                                    DSWorkOrder.ExistUbicacionDataTable dtExistUbi = taExistUbicacion.GetData(Convert.ToInt32(dtDistribucion.Rows[0]["Fk_Alm_Destino"].ToString()), Areaid);
                                    if (dtExistUbi.Count > 0)
                                    {
                                        DataRow[] rows = dtExistUbi.Select();
                                        while (PosDisponibles <= cantpall)
                                        {
                                            if (Ubicacionestotal == dtExistUbi.Count || PosDisponibles == cantpall)
                                            {
                                                break;
                                            }
                                            DSWorkOrder.timwmsPesoNivelDataTable dtPesoNivel = taPesoNivel.GetData(Convert.ToInt32(dtAlmacenart.Rows[0]["FkUbicacionOpcional"].ToString()));
                                            decimal PesoSoportado = Convert.ToDecimal(dtPesoNivel.Rows[0]["Peso"].ToString());
                                            if (PesoSoportado >= PesoTotal)
                                            {
                                                Fila.Enqueue(new Ubicaciones()
                                                {
                                                    UbicationKey = Convert.ToInt32(rows[Ubicacionestotal]["UbicationKey"].ToString()),
                                                    Tamaño = Convert.ToInt32(rows[Ubicacionestotal]["Pos_Disponibles"].ToString())
                                                });
                                            }
                                            else
                                            {
                                                decimal parcial = PosDisponibles / PesoSoportado;
                                                int ContadorPesos = 0;
                                                while (PesoTotal > parcial)
                                                {
                                                    parcial = parcial + parcial;
                                                    ContadorPesos++;
                                                }
                                                Fila.Enqueue(new Ubicaciones()
                                                {
                                                    UbicationKey = Convert.ToInt32(rows[Ubicacionestotal]["UbicationKey"].ToString()),
                                                    Tamaño = Convert.ToInt32(rows[Ubicacionestotal]["Pos_Disponibles"].ToString())
                                                });
                                                MessageBox.Show("El peso de los pallets no es soportado por la ubicacion", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                            //Fila.Enqueue(new Ubicaciones()
                                            //{
                                            //    UbicationKey = Convert.ToInt32(rows[Ubicacionestotal]["UbicationKey"].ToString()),
                                            //    Tamaño = Convert.ToInt32(rows[Ubicacionestotal]["Pos_Disponibles"].ToString())
                                            //});
                                            PosDisponibles = PosDisponibles + Convert.ToInt32(rows[Ubicacionestotal]["Pos_Disponibles"].ToString());
                                            Ubicacionestotal++;
                                        }
                                        if (PosDisponibles < cantpall)
                                        {
                                            MessageBox.Show("Se necesitan " + (cantpall - PosDisponibles) + " ubicaciones para generar las OT faltantes", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        //validar la cantidad de ubicaciones disponibles para el item,
                                        int Contador = dtOT.Count + 1;
                                        DSWorkOrder.timwmsPartidasDataTable dtPartidas = taPartidas.GetData(Tran_Key);
                                        decimal SumaOT = 0;
                                        
                                        for (int j = 0; j < Ubicacionestotal; j++)
                                        {
                                            Ubicaciones Ubicacion = (Ubicaciones)Fila.Dequeue();
                                            int Profundidad = Ubicacion.Tamaño;
                                            int PosOcupadas = 0;
                                            for (int i = 0; i < Ubicacion.Tamaño; i++)
                                            {
                                                taOT.InsertOT
                                                    (//Enviar trankey de la tabla transaccion
                                                        Convert.ToInt32(dtPartidas.Rows[0]["Fk_TrankeyInv"].ToString()), Tran_Key,
                                                        Convert.ToInt32(grdArtSelect.Rows[OT.Index].Cells["POLineKey2"].Value.ToString()),
                                                        "OT-" + (Convert.ToInt32(dtOT.Count) + Contador),
                                                        Convert.ToInt32(cbxTipoOrden.GetItemText(cbxTipoOrden.SelectedValue)),
                                                        null,
                                                        Convert.ToInt32(cbxEstado.GetItemText(cbxEstado.SelectedValue)),
                                                        thisDay.ToString(),
                                                        lkuTransaccion.Text,
                                                        Convert.ToInt32(dtDistribucion.Rows[0]["Certf_Calidad"].ToString()),
                                                        Convert.ToInt32(dtDistribucion.Rows[0]["Fk_Alm_Destino"].ToString()),
                                                        null, null,
                                                        "1", SysSession.UserID, SysSession.CompanyID
                                                    );
                                                DSWorkOrder.UltimoOTDataTable dtUltimoOT = taUltimoOT.GetData();
                                                DSWorkOrder.timwmsLoteDataTable dtLote = taLote.GetDataExistLote(Convert.ToInt32(dtDistribucion.Rows[0]["Fk_Lote"].ToString()));
                                                decimal residuo = Convert.ToDecimal(grdArtSelect.Rows[OT.Index].Cells["CantARecibir"].Value.ToString()) % Conversion;                                                                                          
                                                if (cantpall == Contador & residuo != 0)
                                                {
                                                    taDetalleOT.InsertDetalleOT
                                                    (
                                                        Convert.ToInt32(dtUltimoOT.Rows[0]["TableOT"].ToString()),
                                                        "Pall-" + (Contador),
                                                        Convert.ToInt32(grdArtSelect.Rows[OT.Index].Cells["ItemKeyOT"].Value.ToString()),
                                                        null,
                                                        grdArtSelect.Rows[OT.Index].Cells["Descripcion"].Value.ToString().Substring(0, 4) + "-" + "LOT-" + dtLote.Rows[0]["Num_Lote"].ToString() + "-" + Contador,
                                                        Convert.ToInt32(dtDistribucion.Rows[0]["Fk_Lote"].ToString()),
                                                        Convert.ToDecimal(grdArtSelect.Rows[OT.Index].Cells["CantRecibida"].Value.ToString()),
                                                        Math.Round(residuo, 5),
                                                        null, Convert.ToInt32(grdArtSelect.Rows[OT.Index].Cells["UmKey2"].Value.ToString()),
                                                        null, Convert.ToInt32(dtDistribucion.Rows[0]["Fk_Gaveta_Destino"].ToString()),
                                                        Convert.ToInt32(dtDistribucion.Rows[0]["Fk_Puerta"].ToString()),
                                                        null, null, null, Ubicacion.UbicationKey
                                                    );
                                                    SumaOT = SumaOT + residuo;
                                                    DSWorkOrder.UltimoDetalleOTDataTable dtUltimoDetOTt = taUltimoDetalleOT.GetData();
                                                    taProfundiad.Insert
                                                        (
                                                            Convert.ToInt32(dtUltimoDetOTt.Rows[0]["TableDetalleOT"].ToString()),
                                                            Convert.ToInt32(grdArtSelect.Rows[OT.Index].Cells["Whsekey"].Value.ToString()),
                                                            Convert.ToInt32(grdArtSelect.Rows[OT.Index].Cells["ItemKeyOT"].Value.ToString()),
                                                            Ubicacion.UbicationKey,
                                                            Profundidad,
                                                            Convert.ToInt32(grdArtSelect.Rows[OT.Index].Cells["UmKey2"].Value.ToString()),
                                                            thisDay,
                                                            "1"
                                                        );
                                                    PosOcupadas++;
                                                    Profundidad--;
                                                    break;
                                                }
                                                else
                                                {
                                                    taDetalleOT.InsertDetalleOT
                                                    (
                                                        Convert.ToInt32(dtUltimoOT.Rows[0]["TableOT"].ToString()),
                                                        "Pall-" + (Contador),
                                                        Convert.ToInt32(grdArtSelect.Rows[OT.Index].Cells["ItemKeyOT"].Value.ToString()),
                                                        null,
                                                        grdArtSelect.Rows[OT.Index].Cells["Descripcion"].Value.ToString().Substring(0, 4) + "-" + "LOT-" + dtLote.Rows[0]["Num_Lote"].ToString() + "-" + Contador,
                                                        Convert.ToInt32(dtDistribucion.Rows[0]["Fk_Lote"].ToString()),
                                                        Convert.ToDecimal(grdArtSelect.Rows[OT.Index].Cells["CantRecibida"].Value.ToString()),
                                                        Conversion,
                                                        null, Convert.ToInt32(grdArtSelect.Rows[OT.Index].Cells["UmKey2"].Value.ToString()),
                                                        null, Convert.ToInt32(dtDistribucion.Rows[0]["Fk_Gaveta_Destino"].ToString()),
                                                        Convert.ToInt32(dtDistribucion.Rows[0]["Fk_Puerta"].ToString()),
                                                        null, null, null, Ubicacion.UbicationKey
                                                    );
                                                    SumaOT = SumaOT + Conversion;
                                                }
                                                DSWorkOrder.UltimoDetalleOTDataTable dtUltimoDetOT = taUltimoDetalleOT.GetData();
                                                taProfundiad.InsertProfundidad
                                                    (
                                                        Convert.ToInt32(dtUltimoDetOT.Rows[0]["TableDetalleOT"].ToString()),
                                                        Convert.ToInt32(grdArtSelect.Rows[OT.Index].Cells["Whsekey"].Value.ToString()),
                                                        Convert.ToInt32(grdArtSelect.Rows[OT.Index].Cells["ItemKeyOT"].Value.ToString()),
                                                        Ubicacion.UbicationKey,
                                                        Profundidad,
                                                        Convert.ToInt32(grdArtSelect.Rows[OT.Index].Cells["UmKey2"].Value.ToString()),
                                                        thisDay.ToString(),
                                                        "1"
                                                    );
                                                if (cantpall == Contador || sumaOTs == Contador)
                                                {
                                                    break;
                                                }                                                
                                                Profundidad--;
                                                Contador++;
                                                PosOcupadas++;
                                            }
                                            taUbiDisponibles.UpdateDispUbicacionesOcupadas(Profundidad, PosOcupadas, Ubicacion.UbicationKey);
                                        }
                                        progressBar1.Value = 100;
                                        //MessageBox.Show(dtPartidas.Rows[0]["Fk_TrankeyInv"].ToString());
                                        taPartidas.UpdateCantPendiente(
                                                    Convert.ToDecimal(grdArtSelect.Rows[OT.Index].Cells["CantRecibida"].Value.ToString()),
                                                    Convert.ToDecimal(grdArtSelect.Rows[OT.Index].Cells["CantPend"].Value.ToString()),
                                                    0,                                                    
                                                    Convert.ToInt32(dtPartidas.Rows[0]["Fk_TrankeyInv"].ToString()),
                                                    Tran_Key,
                                                    Convert.ToInt32(grdArtSelect.Rows[OT.Index].Cells["POLineKey2"].Value.ToString())
                                                );
                                        //backgroundWorker1.RunWorkerAsync();
                                        MessageBox.Show("Ordenes de trabajo para el articulo " + grdArtSelect.Rows[OT.Index].Cells["Descripcion"].Value.ToString() + " generadas con exito", "Sage MAS 500");
                                        qtyord = 0; Pendiente = 0; sumaOTs = 0;peso = 0;
                                    }
                                    else
                                    { MessageBox.Show("Ya no se encuentran ubicaciones disponibles para este almacen: " + (grdArtSelect.Rows[OT.Index].Cells["WhseID2"].Value.ToString()), "Sage MAS 500"); }
                                }
                                else { MessageBox.Show("No hay mas Ordenes de trabajo por procesar para el articulo: " + grdArtSelect.Rows[OT.Index].Cells["Descripcion"].Value.ToString(), "Sage MAS 500"); }
                            }
                            else
                            {
                                MessageBox.Show("La configuracion de las unidades de medida CJ,Kg y PL para el articulo " + grdArtSelect.Rows[OT.Index].Cells["Descripcion"].Value.ToString() + " son obligatorios", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else { MessageBox.Show("El articulo " + grdArtSelect.Rows[OT.Index].Cells["Descripcion"].Value.ToString() + " Aun no cuenta con una distribución", "Sage MAS 500"); }
                    }
                    else
                    {
                        MessageBox.Show("El articulo " + grdArtSelect.Rows[OT.Index].Cells["Descripcion"].Value.ToString() + " no tiene configurado una ubicación por defecto", "Sage MAS 500");
                    }
                }                
                grdArtSelect.Rows.Clear();
                PartidasExistentes(Tran_Key);
                btnDistribuir.Enabled = btnGenerarOT.Enabled = false;
                PalletsExistentes(TranID);
                tabControl1.SelectedIndex = 1;                
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void MenuBar1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == "mibNextNumber")
            {
                //DSWorkOrder.tciSurrogateKeyDataTable dtSurrogate = taSurrogate.GetData();
                //int ID = 1 + Convert.ToInt32(dtSurrogate.Rows[0]["NextKey"].ToString());
                //txtIdOt.Text = "OT-" + ID.ToString("D10");
                //lkuLote.Text = ID.ToString("D3");
            }
            else if (e.ClickedItem.Name == "mibCancel")
            {
                LimpiarControles();
            }
            else if (e.ClickedItem.Name == "mibFinish")
            {
                this.Close();                
            }
        }
        private void GrdArtSelect_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdArtSelect.IsCurrentCellDirty)
                {
                    grdArtSelect.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarControles()
        {
            cbxTipoOrden.Enabled = true;
            cbxTipoOrden.Text = "Tipo Orden";
            lkuTransaccion.Enabled = lkuWarehouse.Enabled = lkuGaveta.Enabled = lkuArticulo.Enabled = lkuAlmacenDestino.Enabled = lkuReceipt.Enabled = lkuLote.Enabled = lkuPuerta.Enabled = lkuFromGate.Enabled = lkuUbiHasta.Enabled = false;
            lkuTransaccion.Text = lkuWarehouse.Text = lkuGaveta.Text = lkuArticulo.Text = lkuAlmacenDestino.Text = lkuReceipt.Text = lkuLote.Text = lkuPuerta.Text = lkuFromGate.Text = lkuUbiHasta.Text = "";
            txtIdOt.Text = txtFrescura.Text = txtLPN.Text = "";
            cbxEstado.Text = "Seleccione_Estado";
            nudCantidad.Value = 0;
            cbxUM.DataSource = null;
            grdOT.Rows.Clear();
            grdPallets.Rows.Clear();
            grdArtSelect.Rows.Clear();
            txtPartida.Text = lkuArticulo1.Text = txtCantRecibida.Text = txtAlmacen.Text = cbxUM.Text = "";            
        }
        private void GrdArtSelect_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(Convert.ToDecimal(grdArtSelect.CurrentRow.Cells["CantARecibir"].Value.ToString()) > 0)
            {
                btnDistribuir.Enabled = true;
            }
            else { btnDistribuir.Enabled = false; }
            txtPartida.Text = grdArtSelect.CurrentRow.Cells["Partida"].Value.ToString();
            lkuArticulo1.Text = grdArtSelect.CurrentRow.Cells["Descripcion"].Value.ToString();
            txtCantRecibida.Text = grdArtSelect.CurrentRow.Cells["Recibido"].Value.ToString();
            cbxUMPartida.Text = grdArtSelect.CurrentRow.Cells["UM2"].Value.ToString();
            txtAlmacen.Text = grdArtSelect.CurrentRow.Cells["WhseID2"].Value.ToString();
            DSWorkOrder.timwmsDistribucionDataTable dtDistribucion = taDistribucion.GetData(Tran_Key, Convert.ToInt32(grdArtSelect.CurrentRow.Cells["POLineKey2"].Value.ToString()));
            if(dtDistribucion.Count>0)
            {
                btnGenerarOT.Enabled = true;
            }
        }
    }
}
