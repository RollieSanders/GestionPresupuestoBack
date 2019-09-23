using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Formulacion_Detalle_Ingreso
    {
        public Boolean Elimina_FormulacionDetalle_Ingreso(int intIdFormulacion_Detalle_Ingreso)
        {

            Repository.Formulacion_Detalle_Ingreso objDs = new Repository.Formulacion_Detalle_Ingreso();

            return objDs.Elimina_FormulacionDetalle_Ingreso(intIdFormulacion_Detalle_Ingreso);

        }

        public int Graba_FormulacionDetalle_Ingreso(Model.Formulacion_Detalle_Ingreso obj)
        {

            Repository.Formulacion_Detalle_Ingreso objDs = new Repository.Formulacion_Detalle_Ingreso();

            return objDs.Graba_FormulacionDetalle_Ingreso(obj);

        }

        public int Modifica_FormulacionDetalle_Ingreso(Model.Formulacion_Detalle_Ingreso obj)
        {

            Repository.Formulacion_Detalle_Ingreso objDs = new Repository.Formulacion_Detalle_Ingreso();

            return objDs.Modifica_FormulacionDetalle_Ingreso(obj);

        }

        public DataSet Lista_FormulacionDetalle_Ingreso(string strCodCompañia,
                                                         string strCodProyecto,
                                                         string strCodCentroCosto,
                                                         string strCodTipoFormulacion
                                        )
        {
            Repository.Formulacion_Detalle_Ingreso objDs = new Repository.Formulacion_Detalle_Ingreso();
            return objDs.Lista_FormulacionDetalle_Ingreso(strCodCompañia, strCodProyecto, strCodCentroCosto, strCodTipoFormulacion);
        }
    }
}
