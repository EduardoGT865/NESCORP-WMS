using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMDataAccess.Datamodel
{
    public partial class UbicationType
    {
        public override string ToString()
        {
            return this.UbicationTypeID;
        }
    }

    public partial class WarehouseUbicationLog
    {
        public bool AvaliableOut
        {
            get
            {
                if (WarehouseUbication.BlockStatus == (short)WarehouseUbicationBlockStatus.BlockOut || WarehouseUbication.BlockStatus == (short)WarehouseUbicationBlockStatus.FullBlock)
                    return false;
                return true;
            }
        }

        public bool AvaliableIn {
            get
            {
                if (WarehouseUbication.BlockStatus == (short)WarehouseUbicationBlockStatus.BlockIn || WarehouseUbication.BlockStatus == (short)WarehouseUbicationBlockStatus.FullBlock)
                    return false;
                return true;
            }
        }

        public bool Contains(int ItemKey)
        {
            return WarehouseUbicationLogLevels.Where(p => p.ItemKey == ItemKey).Any();
        }

        public IEnumerable<int> GetItemsFromLevel(int LevelNo)
        {
            List<int> answer = new List<int>();
            foreach (int i in this.WarehouseUbicationLogLevels.Where(p => p.ItemKey.HasValue && p.LPNKey.HasValue && p.LevelNo == LevelNo).Select(p => p.ItemKey.Value))
                answer.Add(i);
            return answer;
        }

        public IEnumerable<int> GetLPNFromItemInLevel(int LevelNo, int ItemKey)
        {
            List<int> answer = new List<int>();
            foreach (int i in this.WarehouseUbicationLogLevels.Where(p => p.ItemKey.HasValue && p.LPNKey.HasValue && p.LevelNo == LevelNo).Select(p => p.LPNKey.Value))
                answer.Add(i);
            return answer;
        }

        public bool IsLevelAvaliableIn(int LevelNo)
        {
            return AvaliableIn && WarehouseUbicationLogLevels.Where(p => p.LevelNo == LevelNo && p.ItemKey == null && p.LPNKey == null).Any();
        }
        public bool IsLevelAvaliableOut(int LevelNo, int ItemKey, int LPNKey, decimal Qty)
        {
            return AvaliableOut && WarehouseUbicationLogLevels.Where(p => p.LevelNo == LevelNo && p.ItemKey == ItemKey && p.LPNKey == LPNKey && p.LPNRelation.Qty >= Qty).Any();
        }
        public bool IsLevelAvaliableOut(int LevelNo, int ItemKey, int LPNKey)
        {
            return IsLevelAvaliableOut(LevelNo, ItemKey, LPNKey, 0);
        }

        public bool PushLPN(int itemKey, int LPNKey, int LevelNo)
        {
            WarehouseUbicationLogLevel temp;
            if ((temp = WarehouseUbicationLogLevels.Where(p => p.LevelNo == LevelNo && p.ItemKey == null && p.LPNKey == null).OrderBy(p => p.CapacityNo).FirstOrDefault()) == null)
                return false;
            temp.LPNKey = LPNKey;
            temp.ItemKey = itemKey;
            return true;
        }

        public bool PopLPN(int ItemKey, int LPNKey, int LevelNo)
        {
            WarehouseUbicationLogLevel temp;
            if ((temp = WarehouseUbicationLogLevels.Where(p => p.LevelNo == LevelNo && p.ItemKey == ItemKey && p.LPNKey == LPNKey).OrderBy(p => p.CapacityNo).FirstOrDefault()) == null)
                return false;
            temp.LPNKey = null;
            temp.ItemKey = null;
            return true;
        }

        public bool PopLPN(int ItemKey, int LPNKey, int LevelNo, decimal Qty)
        {
            throw new NotImplementedException();
        }

        public void UpdateStatus()
        {
            if (WarehouseUbicationLogLevels.Where(p => p.ItemKey.HasValue && p.LPNKey.HasValue).Any())
            {
                if(WarehouseUbicationLogLevels.Where(p => !p.ItemKey.HasValue && !p.LPNKey.HasValue).Any())
                    WarehouseUbication.Status = 2;
                else
                    WarehouseUbication.Status = 3;
            }
            else
                WarehouseUbication.Status = 1;
        }
    }
}
