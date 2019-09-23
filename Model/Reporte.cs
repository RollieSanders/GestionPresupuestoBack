using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Reporte
    {
        public int IidFormulacion_Cabecera { get; set; } = 0;
        public string CañoProceso { get; set; } = "";
        public string Cversion { get; set; } = "";
        public DateTime DfecFormulacion { get; set; } = DateTime.Today;
        public string Tnota { get; set; } = "";
        public Boolean Bactivo { get; set; } = false;
        public int IidFormulacion_Detalle { get; set; } = 0;
        public string CcodTipoFormulacion_Item { get; set; } = "";
        public string CcodCentro { get; set; } = "";
        public string CcodCege { get; set; } = "";
        public string CcodCeco { get; set; } = "";
        public string CcodSubActividad { get; set; } = "";
        public string CcodPosPre { get; set; } = "";
        public string vNroCuenta { get; set; } = "";
        public string vNombreCuenta { get; set; } = "";
        public decimal FvalorPosPre { get; set; } = 0;
        public int IcodTipoInserccion { get; set; } = 0;
        public int IidFormulacion_Detalle_Proyecto { get; set; } = 0;
        public string CcodCeCo { get; set; } = "";
        public string cCodClasificador { get; set; } = "";
        public string CcodFuenteFinanciamiento { get; set; } = "";
        public string CcodTipoFormulacion { get; set; } = "";
        public string CcodProyecto { get; set; } = "";
        public string vProyecto { get; set; } = "";
        public string vTipoInserccion { get; set; } = "";
        public string vMacroProyecto { get; set; } = "";
        public string CcodClaseGasto { get; set; } = "";
        public string  vNomClaseGasto { get; set; } = "";
        public string CNumeroOrden { get; set; } = "";
        public string TdescripcionGasto { get; set; } = "";
        public double fValorAnterior { get; set; } = 0;
        public double fValorRestoActual { get; set; } = 0;
        public double fValorFormulacion { get; set; } = 0;
        public double fValorFormulacionUno { get; set; } = 0;
        public double fValorFormulacionDos { get; set; } = 0;
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
        public string vNomCeCo { get; set; } = "";

        public string cCodFuenteFinanciamiento { get; set; } = "";
        public string vNomFuenteFinanciamiento { get; set; } = "";
        public string vNomTipoFormulacion { get; set; }
        public bool bPase { get; set; }
        public string Compañia { get; set; }
        public string TipoOrden { get; set; }
        public string NumeroOrden { get; set; }
        public string Contrato { get; set; }
        public DateTime FechaOrden { get; set; }
        public string ObjetoContratacion { get; set; }
        public double MontoOrden { get; set; }
        public double MontoConformidad { get; set; }
        public double Saldo { get; set; }
    }
}
