using System;
using System.Data;

namespace Service
{
    public class ReporteFormulacion
    {
        public DataSet Lista_FormulacionProyecto_Resumen(string strAñoProceso,
                                                            string strVersion,
                                                            string strCodCompañia,
                                                            string strCodProyecto,
                                                            string strCodTipoProyecto
                                                        )
        {
            Repository.ReporteFormulacion RRF = new Repository.ReporteFormulacion();
            return RRF.Lista_FormulacionProyecto_Resumen(strAñoProceso,
                                                         strVersion,
                                                         strCodCompañia,
                                                         strCodProyecto,
                                                         strCodTipoProyecto
                                                        );
        }
    }
}
