using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Formulacion_Detalle_Personal
    {
        public Boolean Elimina_FormulacionDetalle_Personal(int intIdFormulacion_Detalle_Personal)
        {

            Repository.Formulacion_Detalle_Personal objDs = new Repository.Formulacion_Detalle_Personal();

            return objDs.Elimina_FormulacionDetalle_Personal(intIdFormulacion_Detalle_Personal);

        }

        public int Graba_FormulacionDetalle_Personal(Model.Formulacion_Detalle_Personal obj)
        {

            Repository.Formulacion_Detalle_Personal objDs = new Repository.Formulacion_Detalle_Personal();

            return objDs.Graba_FormulacionDetalle_Personal(obj);

        }

        public int Modifica_FormulacionDetalle_Personal(Model.Formulacion_Detalle_Personal obj)
        {

            Repository.Formulacion_Detalle_Personal objDs = new Repository.Formulacion_Detalle_Personal();

            return objDs.Modifica_FormulacionDetalle_Personal(obj);

        }

        public DataSet Lista_FormulacionDetalle_Personal(string strCodCompañia,
                                                         string strCodCentroCosto,
                                                         string strCodTipoFormulacion
                                        )
        {
            Repository.Formulacion_Detalle_Personal objDs = new Repository.Formulacion_Detalle_Personal();
            return objDs.Lista_FormulacionDetalle_Personal(strCodCompañia, strCodCentroCosto, strCodTipoFormulacion);
        }


    }
}
