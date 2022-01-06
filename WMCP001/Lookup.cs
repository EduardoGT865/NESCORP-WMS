using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net4Sage.Controls.Lookup;

namespace WMCP001
{
    [LookupFormTitle("Buscar almacén")]
    class Lookup
    {
        //Filtros y columnas para el almacen
        [LookupKeyReturn]
            [LookupHideColumn]
            [LookupColumnFilter("Warehouse Key")]
            [LookupColumnHeader("Warehouse Key")]
            public int WhseKey { get; set; }
        [LookupTextReturn]
        //Columnas para el filtrado de informacion

        [LookupColumnFilter("Almacén")]
        [LookupColumnHeader("Almacén")]
        public string WhseID { get; set; }

        [LookupColumnFilter("Descripción")]
        [LookupColumnHeader("Descripción")]
        public string Description { get; set; }       
    }
    [LookupFormTitle("Buscar Articulo")]
    class Articulo
    {
        //Filtros y columnas para los articulos      
        [LookupKeyReturn]

        [LookupHideColumn]

        [LookupColumnFilter("Item Key")]
        [LookupColumnHeader("Item Key")]
        public int ItemKey { get; set; }

        [LookupTextReturn]

        [LookupColumnFilter("Codigo")]
        [LookupColumnHeader("Codigo")]
        public string ItemID { get; set; }

        [LookupColumnFilter("Descripción")]
        [LookupColumnHeader("Descripción")]
        public string LongDesc { get; set; }
    }
    [LookupFormTitle("Buscar Ubicación")]
    class Ubicacion
    {
        //Filtros y columnas para los articulos      
        [LookupKeyReturn]
        [LookupHideColumn]
        [LookupColumnHeader("UbicationKey")]
        public int UbicationKey { get; set; }

        [LookupTextReturn]

        [LookupColumnFilter("NumUbicacionID")]
        [LookupColumnHeader("NumUbicacionID")]
        public string NumUbicacionID { get; set; }

    }
}
