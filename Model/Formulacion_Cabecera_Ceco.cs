using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Formulacion_Cabecera_Ceco
    {
        public int IidFormulacion_Cabecera_Ceco { get; set; } = 0;
        public string CañoProceso { get; set; } = "";
        public string Cversion { get; set; } = "";
        public DateTime DfecFormulacion { get; set; } = DateTime.Today;
        public string Tnota { get; set; } = "";
        public string cCodCeco { get; set; } = "";
        public string cUsuarioCierre { get; set; } = "";
    }
}
