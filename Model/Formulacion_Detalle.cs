using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Formulacion_Detalle
    {
        public int IidFormulacion_Detalle {get;set;} = 0;
        public int IidFormulacion_Cabecera { get;set;} = 0;
        public string CcodTipoFormulacion_Item { get;set;} = "";
        public string CcodCentro { get;set;} = "";
        public string CcodCege { get;set;} = "";
        public string CcodCeco { get;set;} = "";
        public string CcodSubActividad { get;set;} = "";
        public string CcodPosPre {get;set;} = "";
        public decimal FvalorPosPre {get;set;} = 0;
        public int IcodTipoInserccion {get;set;} = 0;
    }
}
