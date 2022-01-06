using Net4Sage.Controls.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMModuleUtils
{
    [LookupFormTitle("Buscar Orden Pendiente")]
    public class WorkOrderView
    {
        [LookupHideColumn]
        [LookupKeyReturn]
        public int WOLineKey { get; set; }
        [LookupTextReturn]
        [LookupShowColumn]
        [LookupColumnHeader("Orden de Trabajo")]
        public string WOID { get; set; }
        [LookupColumnHeader("Artículo")]
        [LookupShowColumn]
        public string ItemID { get; set; }
        [LookupStaticColumn("twmWorkOrders", "Type")]
        [LookupColumnHeader("Tipo")]
        [LookupShowColumn]
        public int Type { get; set; }
        [LookupColumnHeader("Desde")]
        [LookupShowColumn]
        public string From { get; set; }
        [LookupColumnHeader("Hasta")]
        [LookupShowColumn]
        public string To { get; set; }
        [LookupColumnHeader("LPN")]
        [LookupShowColumn]
        public string LPN { get; set; }
        [LookupColumnHeader("Cantidad")]
        [LookupShowColumn]
        public decimal QTY { get; set; }
    }
}
