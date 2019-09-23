using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Formulacion_Detalle_Ingreso
    {
        public int IidFormulacion_Detalle_Ingreso { get; set; } = 0;
        public int IidFormulacion_Detalle { get; set; } = 0;
        public string CañoProceso { get; set; } = "";
        public string Cversion { get; set; } = "";
        public string CcodCeCo { get; set; } = "";
        public string CcodCeCo_Gestor { get; set; } = "";
        public string CcodPosPre { get; set; } = "";
        public string CcodFuenteFinanciamiento { get; set; } = "";
        public string CcodComponente { get; set; } = "";
        public string CcodTipoFormulacion { get; set; } = "";
        public string CcodProyecto { get; set; } = "";
        public string CcodClaseIngreso { get; set; } = "";
        public string CTipoOrden { get; set; } = "";
        public string CNumeroOrden { get; set; } = "";
        public string TdescripcionIngreso { get; set; } = "";
        public int IcodTipoInserccion { get; set; } = 0;
        public double FvalorAnterior { get; set; } = 0.0;
        public double FvalorRestoActual { get; set; } = 0.0;
        public double Fmes_01 { get; set; } = 0.0;
        public double Fmes_02 { get; set; } = 0.0;
        public double Fmes_03 { get; set; } = 0.0;
        public double Fmes_04 { get; set; } = 0.0;
        public double Fmes_05 { get; set; } = 0.0;
        public double Fmes_06 { get; set; } = 0.0;
        public double Fmes_07 { get; set; } = 0.0;
        public double Fmes_08 { get; set; } = 0.0;
        public double Fmes_09 { get; set; } = 0.0;
        public double Fmes_10 { get; set; } = 0.0;
        public double Fmes_11 { get; set; } = 0.0;
        public double Fmes_12 { get; set; } = 0.0;
        public double FvalorFormulacion { get; set; } = 0;
        public double FvalorFormulacionUno { get; set; } = 0;
        public double FvalorFormulacionDos { get; set; } = 0;
        public string Cusuario { get; set; } = "";
    }
}
