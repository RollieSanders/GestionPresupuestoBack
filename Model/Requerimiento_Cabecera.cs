using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Requerimiento_Cabecera
    {
        public int IidRequerimiento_Cabecera { get; set; } = 0;
        public DateTime DfecRequerimiento { get; set; } = DateTime.Today;
        public string CnumRequerimiento { get; set; } = "";
        public string Tnota { get; set; } = "";
    }
}
