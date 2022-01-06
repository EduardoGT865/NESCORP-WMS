using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net4Sage.Controls.Lookup;

namespace WMCWO001
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

    [LookupFormTitle("Buscar Gaveta")]
    class Gaveta
    {
        //Filtros y columnas para la Gaveta 
        [LookupKeyReturn]
        [LookupHideColumn]
        [LookupColumnFilter("WhseBinKey")]
        [LookupColumnHeader("Whse Bin Key")]
        public int WhseBinKey { get; set; }

        [LookupTextReturn]

        [LookupColumnFilter("WhseBinID")]
        [LookupColumnHeader("Whse Bin ID")]
        public string WhseBinID { get; set; }

        [LookupColumnFilter("Location")]
        [LookupColumnHeader("Location")]
        public string Location { get; set; }
    }

    [LookupFormTitle("Buscar Orden de Compra")]
    class OrdenCompra
    {
        [LookupKeyReturn]
        [LookupHideColumn]              
        [LookupColumnFilter("POKey")]
        [LookupColumnHeader("POKey")]
        public int POKey { get; set; }
        [LookupTextReturn]

        [LookupColumnFilter("TranID")]
        [LookupColumnHeader("TranID")]
        public string TranID { get; set; }
        
        [LookupColumnFilter("ChngOrdNo")]
        [LookupColumnHeader("ChngOrdNo")]
        public string ChngOrdNo { get; set; }

        [LookupColumnFilter("CreateUserID")]
        [LookupColumnHeader("CreateUserID")]
        public string CreateUserID { get; set; }

        [LookupColumnHeader("ChngReason")]
        public string ChngReason { get; set; }

        [LookupColumnHeader("PurchAmt")]
        public string PurchAmt { get; set; }

        [LookupHideColumn]
        [LookupColumnHeader("ChngOrdDate")]
        public string ChngOrdDate { get; set; }
    }

    [LookupFormTitle("Buscar Articulo de orden de compra")]
    class ArticuloPO
    {
        //Filtros y columnas para los articulos      
        [LookupKeyReturn]
        [LookupHideColumn]
        [LookupColumnFilter("Item Key")]
        [LookupColumnHeader("ItemKey")]
        public int ItemKey { get; set; }
        [LookupTextReturn]

        [LookupColumnFilter("Descripción")]
        [LookupColumnHeader("Descripción")]
        public string LongDesc { get; set; }

        [LookupColumnFilter("POKey")]
        [LookupColumnHeader("POKey")]
        public int POKey { get; set; }        

        [LookupColumnHeader("Total")]
        public string ExtAmt { get; set; }

        [LookupColumnHeader("Costo unitario")]
        public string UnitCost { get; set; }

        [LookupColumnHeader("Cantidad")]
        public string QtyOrd { get; set; }

        [LookupColumnHeader("UnitMeasKey")]
        public string UnitMeasKey { get; set; }
             
    }

    [LookupFormTitle("Buscar Puerta")]
    class Puerta
    {
        //Filtros y columnas para los articulos      
        [LookupKeyReturn]
        //[LookupHideColumn]
        [LookupColumnFilter("PkeyDetPuerta")]
        [LookupColumnHeader("PkeyDetPuerta")]
        public int PkeyDetPuerta { get; set; }

        [LookupTextReturn]

        [LookupColumnFilter("Puerta")]
        [LookupColumnHeader("Puerta")]
        public string Puerta1 { get; set; }

        [LookupColumnFilter("Tipo")]
        [LookupColumnHeader("Tipo")]
        public string Tipo { get; set; }
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

    [LookupFormTitle("Buscar Lote")]
    class CargarLote
    {
        //Filtros y columnas para los articulos      
        [LookupKeyReturn]
        [LookupHideColumn]
        [LookupColumnHeader("Lote_key")]
        public int LoteKey { get; set; }

        [LookupTextReturn]

        [LookupColumnFilter("Num_Lote")]
        [LookupColumnHeader("Numero Lote")]
        public string Num_Lote { get; set; }
    }

    [LookupFormTitle("Buscar Devoluciones")]
    class Devoluciones
    {
        [LookupKeyReturn]
        [LookupHideColumn]
        [LookupColumnFilter("ShipKey")]
        [LookupColumnHeader("ShipKey")]
        public int ShipKey { get; set; }
        [LookupTextReturn]

        [LookupColumnFilter("TranID")]
        [LookupColumnHeader("TranID")]
        public string TranID { get; set; }

        [LookupColumnHeader("TranCmnt")]
        public string TranCmnt { get; set; }
    }
}
