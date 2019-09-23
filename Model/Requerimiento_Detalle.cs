using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Requerimiento_Detalle
    {
        public int IidRequerimiento_Cabecera { get; set; } = 0;
        public int IidRequerimiento_Detalle { get; set; } = 0;
        public string CcodCeCo { get; set; } = "";
        public string CcodProyecto { get; set; } = "";
        public string CcodComponente { get; set; } = "";

        public string CcodPosPre { get; set; } = "";
        public string CcodClasificador { get; set; } = "";
        public string CcodTipoGasto { get; set; } = "";

        public string CcodTipoAdquisicion { get; set; } = "";
        public string TespecificacionTecnica { get; set; } = "";
        public double DblImporteTotal { get; set; } = 0.0;
    }
}
