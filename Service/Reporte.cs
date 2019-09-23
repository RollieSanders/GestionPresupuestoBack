using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Reporte
    {
        

        public DataSet Lista_Formulacion_ResumenClasificador_Gasto(string strCodCompañia,
                                  string strAñoProceso,
                                  string strVersion,
                                  string strCodFuenteFinanciamiento,
                                  string strCodCentroCosto,
                                  string strCodProyecto,
                                  int intTipoAgrupacion
                                )
        {
            Repository.Reporte objDs = new Repository.Reporte();
            return objDs.Lista_Formulacion_ResumenClasificador_Gasto(strCodCompañia, 
                                                                     strAñoProceso, 
                                                                     strVersion, 
                                                                     strCodFuenteFinanciamiento, 
                                                                     strCodCentroCosto, 
                                                                     strCodProyecto,
                                                                     intTipoAgrupacion
                                                                     );
        }

        public DataSet Lista_Formulacion_HojaTrabajo_Gasto(string strCodCompañia,
                          string strAñoProceso,
                          string strVersion,
                          string strCodFuenteFinanciamiento,
                          string strCodCentroCosto,
                          string strCodProyecto,
                          int intTipoAgrupacion
                        )
        {
            Repository.Reporte objDs = new Repository.Reporte();
            return objDs.Lista_Formulacion_HojaTrabajo_Gasto(strCodCompañia,
                                                                     strAñoProceso,
                                                                     strVersion,
                                                                     strCodFuenteFinanciamiento,
                                                                     strCodCentroCosto,
                                                                     strCodProyecto,
                                                                     intTipoAgrupacion
                                                                     );
        }


        public DataSet Lista_Formulacion_ResumenClasificador_Ingreso(string strCodCompañia,
                                  string strAñoProceso,
                                  string strVersion,
                                  string strCodFuenteFinanciamiento,
                                  string strCodCentroCosto,
                                  string strCodProyecto,
                                  int intTipoAgrupacion
                                )
        {
            Repository.Reporte objDs = new Repository.Reporte();
            return objDs.Lista_Formulacion_ResumenClasificador_Ingreso(strCodCompañia,
                                                                     strAñoProceso,
                                                                     strVersion,
                                                                     strCodFuenteFinanciamiento,
                                                                     strCodCentroCosto,
                                                                     strCodProyecto,
                                                                     intTipoAgrupacion
                                                                     );
        }

        public DataSet Lista_Formulacion_HojaTrabajo_Ingreso(string strCodCompañia,
                          string strAñoProceso,
                          string strVersion,
                          string strCodFuenteFinanciamiento,
                          string strCodCentroCosto,
                          string strCodProyecto,
                          int intTipoAgrupacion
                        )
        {
            Repository.Reporte objDs = new Repository.Reporte();
            return objDs.Lista_Formulacion_HojaTrabajo_Ingreso(strCodCompañia,
                                                                     strAñoProceso,
                                                                     strVersion,
                                                                     strCodFuenteFinanciamiento,
                                                                     strCodCentroCosto,
                                                                     strCodProyecto,
                                                                     intTipoAgrupacion
                                                                     );
        }


        public DataSet Formato_4P(string strCodCompañia,
                                  string strAñoProceso,
                                  string strVersion,
                                  string strCodFuenteFinanciamiento,
                                  string strCodCentroCosto,
                                  string strCodProyecto
                                )
        {
            Repository.Reporte objDs = new Repository.Reporte();
            return objDs.Formato_4P(strCodCompañia, strAñoProceso, strVersion, strCodFuenteFinanciamiento, strCodCentroCosto, strCodProyecto);
        }

        public DataSet Reporte_Detalle_Formulacion(string strCodCompañia,
                                  string strAñoProceso,
                                  string strVersion,
                                  string strCodFuenteFinanciamiento,
                                  string strCodCentroCosto,
                                  string strCodProyecto
                                )
        {
            Repository.Reporte objDs = new Repository.Reporte();
            return objDs.Reporte_Detalle_Formulacion(strCodCompañia, strAñoProceso, strVersion, strCodFuenteFinanciamiento, strCodCentroCosto, strCodProyecto);
        }

        public DataSet Lista_FormulacionReporteProyecto(string cCodCompañia, string strAñoProceso, string strVersion, string cCodTipoFormulacion, string cCodProyecto)
        {
            Repository.Reporte objDs = new Repository.Reporte();
            return objDs.Lista_FormulacionReporteProyecto(cCodCompañia, strAñoProceso, strVersion, cCodTipoFormulacion, cCodProyecto);
        }

        public DataSet Lista_FormulacionReporteProyecto_CentroCosto(string cCodCompañia,
                                                                    string cCodTipoFormulacion,
                                                                    string cCodProyecto,
                                                                    string cCodCentroCosto_Gestor
                                                                   )
        {
            Repository.Reporte objDs = new Repository.Reporte();
            return objDs.Lista_FormulacionReporteProyecto_CentroCosto(cCodCompañia, cCodTipoFormulacion, cCodProyecto, cCodCentroCosto_Gestor);
        }

        public DataSet Lista_FormulacionReporteContrato(string cCodCompañia, string cNumeroOrden, string cTipoOrden)
        {
            Repository.Reporte objDs = new Repository.Reporte();
            return objDs.Lista_FormulacionReporteContrato(cCodCompañia, cNumeroOrden, cTipoOrden);
        }

        public DataSet Help_FormulacionTipoFormulacion()
        {
            Repository.Reporte objDs = new Repository.Reporte();
            return objDs.Help_FormulacionTipoFormulacion();
        }

        public DataSet Lista_FormulacionReporteProyecto_Ceco(string cCodCompañia, string strAñoProceso, string strVersion, string cCodTipoFormulacion, string CodCentroCosto)
        {
            Repository.Reporte objDs = new Repository.Reporte();
            return objDs.Lista_FormulacionReporteProyecto_Ceco(cCodCompañia, strAñoProceso, strVersion, cCodTipoFormulacion, CodCentroCosto);
        }
        
            public DataSet Lista_FormulacionReporteProyecto_Saldo(string cCodCompañia)
        {
            Repository.Reporte objDs = new Repository.Reporte();
            return objDs.Lista_FormulacionReporteProyecto_Saldo(cCodCompañia);
        }
    }
}
