using Net4Sage.Controls.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMDataAccess
{
    public class LPNUbicationView
    {
        public int ItemKey { get; set; }
        [LookupKeyReturn]
        public int LPNKey { get; set; }
        public int LotKey { get; set; }
        public string ItemID { get; set; }
        [LookupTextReturn]
        public string LPN { get; set; }
        public string Lot { get; set; }
        public decimal Qty { get; set; }
    }
}
