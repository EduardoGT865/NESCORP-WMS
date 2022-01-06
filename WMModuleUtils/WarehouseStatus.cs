using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMModuleUtils
{
    public class WarehouseUbicationStatus
    {
        public WarehouseUbicationStatus(int lvl, int cap)
        {
            LevelNo = lvl;
            Capacity = cap;
        }
        public int? ItemKey { get; set; }
        public decimal [][] Quantities { get; set; }

        public decimal QtyPendingToIncrease { get; set; }

        public decimal QtyPendingToDecrease { get; set; }

        public bool Avaliable
        {
            get
            {
                for (var i = 0; i < LevelNo; i++)
                    for (var j = 0; j < Capacity; j++)
                        if (Quantities[i][j] > 0)
                            return true;
                return false;
            }
            set
            {

            }
        }
        public decimal Qty {
            get
            {
                decimal answer = 0;
                for (var i = 0; i < LevelNo; i++)
                    for (var j = 0; j < Capacity; j++)
                        answer += Quantities[i][j];
                return answer;
            }
            set
            { 

            }            
        }
        public decimal SizeQty { get; set; }
        public int LevelNo { get; set; }
        public int Capacity { get; set; }
    }
}
