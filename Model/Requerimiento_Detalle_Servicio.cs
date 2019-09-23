using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Requerimiento_Detalle_Servicio
    {
        public int IidRequerimiento_Detalle { get; set; } = 0;
        public int IidRequerimiento_Detalle_Bien { get; set; } = 0;
        public string CcodServicio { get; set; } = "";
    }
}
