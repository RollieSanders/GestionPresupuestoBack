using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Empleado
    {
        public string CCodPersonal { get; set; } = "";
        public string VApePersonal { get; set; } = "";
        public string CCodEscalaViaje { get; set; } = "";
        public string VNomEscalaViaje { get; set; } = "";
        public string CCodCargo { get; set; } = "";
        public string VDesCargo { get; set; } = "";
        public string CDni { get; set; } = "";
        public string CCodTipoEmpleado { get; set; } = "";
        public string VDesTipoEmpleado { get; set; } = "";
        public string CCodCentroCosto { get; set; } = "";
        public string VNomCentroCosto { get; set; } = "";
        public string CCodCentroGestor { get; set; } = "";
        public string VNomCentroGestor { get; set; } = "";
        public int Idigito { get; set; } = 2;
        public string CCodCentroBeneficio { get; set; } = "";
        public string VNomCentroBeneficio { get; set; } = "";
        public string CCodCentro { get; set; } = "";
        public string VNomCentro { get; set; } = "";
        public string CCodZona { get; set; } = "";
        public string VNomzona { get; set; } = "";
    }
}
