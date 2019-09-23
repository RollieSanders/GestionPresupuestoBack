using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Requerimiento_Detalle_Bien
    {
        public int IidRequerimiento_Detalle { get; set; } = 0;
        public int IidRequerimiento_Detalle_Bien { get; set; } = 0;
        public string CcodMaterial { get; set; } = "";
        public double dblStock { get; set; } = 0.0;
        public double dblCantidad { get; set; } = 0.0;
        public double dblPrecioUnitario { get; set; } = 0.0;
        public string CcodUnidadMedida { get; set; } = "";
    }
}
