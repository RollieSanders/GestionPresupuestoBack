using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Formulacion_Detalle
    {
        public int Graba_FormulacionDetalle(Model.Formulacion_Detalle obj)
        {

            Repository.Formulacion_Detalle objDs = new Repository.Formulacion_Detalle();

            return objDs.Graba_FormulacionDetalle(obj);

        }
    }
}
