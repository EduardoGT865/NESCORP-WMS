using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMCWO001
{
    public class Distribuir
    {
        private int partida;
        private string articulo;
        private string descripcion;
        private string um;
        private decimal cant;
        public int Partida { get; set; }
        public int ItemKey { get; set; }
        public string Articulo { get; set; }
        public string Descripcion { get; set; }
        public string UM { get; set; }
        public int umkey { get; set; }
        public decimal CantTotal { get; set; }
        public decimal CantRecibida { get; set; }
        public string WhseID { get; set; }
        public int WhseKey { get; set; }
        public int POLineKey { get; set; }
        
    }
}
