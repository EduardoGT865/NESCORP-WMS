using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net4Sage.Controls.Lookup;

namespace WMCP001
{
    class Lookup
    {
            [LookupFormTitle("Buscar almacén")]
            [LookupKeyReturn]
            [LookupHideColumn]
            [LookupColumnFilter("Warehouse Key")]
            [LookupColumnHeader("Warehouse Key")]
            public int WhseKey { get; set; }

            [LookupTextReturn]
            [LookupColumnFilter("Almacén")]
            [LookupColumnHeader("Almacén")]
            public string WhseID { get; set; }

            [LookupColumnFilter("Descripción")]
            [LookupColumnHeader("Descripción")]
            public string Description { get; set; }

            //[LookupColumnFilter("Compania")]
            //[LookupColumnHeader("Compania")]
            //public string CompanyID { get; set; }
    }
}
