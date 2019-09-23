using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DataGeneral
    {
        #region Concepto
        public DataSet Ayuda_Concepto()
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Ayuda_Concepto();
        }
        #endregion


        #region Proyecto

        public DataSet Combo_TipoFormulacion()
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Combo_TipoFormulacion();

        }

        public DataSet Combo_Proyecto_FuenteFinanciamiento_Todos(string strCodCompañia)
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Combo_Proyecto_FuenteFinanciamiento_Todos(strCodCompañia);

        }

        public DataSet Combo_Proyecto_FuenteFinanciamiento(string strCodCompañia,
                                                            string strCodProyecto
                                                          )
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Combo_Proyecto_FuenteFinanciamiento(strCodCompañia, strCodProyecto);

        }

        public DataSet Ayuda_Proyecto_FuenteFinanciamiento(string strCodCompañia,
                                                            string strCodProyecto
                                                          )
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Ayuda_Proyecto_FuenteFinanciamiento(strCodCompañia, strCodProyecto);

        }

        public DataSet Combo_Tarea_FuenteFinanciamiento(string strCodCompañia,
                                                            string strCodProyecto
                                                          )
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Combo_Tarea_FuenteFinanciamiento(strCodCompañia, strCodProyecto);

        }

        public DataSet Ayuda_Proyecto_Spring(   string strCodCompañia,
                                                string strCodCentroCosto)
        {

            Repository.DataGeneral objDs = new Repository.DataGeneral();

            return objDs.Ayuda_Proyecto_Spring( strCodCompañia, strCodCentroCosto);

        }

        public DataSet Ayuda_Proyecto_Componente_Spring(string strCodCompañia,
                                                string strCodProyecto)
        {

            Repository.DataGeneral objDs = new Repository.DataGeneral();

            return objDs.Ayuda_Proyecto_Componente_Spring(strCodCompañia, strCodProyecto);

        }

        public DataSet Ayuda_Proyecto_Componente_Todos_Spring(string strCodCompañia)
        {

            Repository.DataGeneral objDs = new Repository.DataGeneral();

            return objDs.Ayuda_Proyecto_Componente_Todos_Spring(strCodCompañia);

        }

        #endregion

        #region Contabilidad
        public DataSet Ayuda_PlanContable_Spring()
        {

            Repository.DataGeneral objDs = new Repository.DataGeneral();

            return objDs.Ayuda_PlanContable_Spring();

        }
        #endregion

        #region Formulacion


        public DataSet Combo_FuenteFinanciamiento_Reporte(string strCodCompañia )
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Combo_FuenteFinanciamiento_Reporte(strCodCompañia);
        }

        public DataSet Combo_CentroCosto_Reporte(string strCodFuenteFinanciamiento)
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Combo_CentroCosto_Reporte(strCodFuenteFinanciamiento);
        }

        public DataSet Combo_Proyecto_Reporte(string strCodCentroCosto)
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Combo_Proyecto_Reporte(strCodCentroCosto);
        }

        public DataSet Ayuda_FuenteFinanciamiento_Reporte(string strCodCompañia)
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Ayuda_FuenteFinanciamiento_Reporte(strCodCompañia);
        }

        public DataSet Ayuda_CentroCosto_Reporte(string strCodFuenteFinanciamiento)
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Ayuda_CentroCosto_Reporte(strCodFuenteFinanciamiento);
        }

        public DataSet Ayuda_Proyecto_Reporte( string strCodFuenteFinanciamiento,
                                               string strCodCentroCosto
                                             )
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Ayuda_Proyecto_Reporte( strCodFuenteFinanciamiento,  strCodCentroCosto);
        }

        public DataSet Combo_ClaseIngreso()
        {

            Repository.DataGeneral objDs = new Repository.DataGeneral();

            return objDs.Combo_ClaseIngreso();

        }

        public DataSet Ayuda_ClaseIngreso()
        {

            Repository.DataGeneral objDs = new Repository.DataGeneral();

            return objDs.Ayuda_ClaseIngreso();

        }

        public DataSet Graba_Proyecto_OrdenTemporal(string strCodEmpleado,
                                                    string strTipoOrden,
                                                    string strNumeroOrden
                                                  )
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Graba_Proyecto_OrdenTemporal(strCodEmpleado, strTipoOrden, strNumeroOrden);
        }

        public DataSet Elimina_Proyecto_OrdenTemporal(string strCodEmpleado,
                                                    string strTipoOrden,
                                                    string strNumeroOrden
                                                  )
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Elimina_Proyecto_OrdenTemporal(strCodEmpleado, strTipoOrden, strNumeroOrden);
        }

        public DataSet Ayuda_Proyecto_CentroCosto(string strCodCentroGestor, int intDigito)
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Ayuda_Proyecto_CentroCosto(strCodCentroGestor, intDigito);
        }

        public DataSet Combo_ClaseGasto()
        {

            Repository.DataGeneral objDs = new Repository.DataGeneral();

            return objDs.Combo_ClaseGasto();

        }

        public DataSet Combo_ClaseGasto_Clasificador(string strCodCompañia,
                                                        string strCodCentroCosto,
                                                        string strCodTipoFormulacion
                                                    )
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();

            return objDs.Combo_ClaseGasto_Clasificador( strCodCompañia,
                                                        strCodCentroCosto,
                                                        strCodTipoFormulacion
                                                      );
        }

        public DataSet Combo_ClaseGasto_Inversion(string strCodCompañia,
                                                   string strCodProyecto,
                                                        string strCodCentroCosto
                                                    )
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();

            return objDs.Combo_ClaseGasto_Inversion(strCodCompañia,
                                                    strCodProyecto,
                                                        strCodCentroCosto
                                                      );
        }

        public DataSet Combo_ClaseGasto_Otros(string strCodCompañia,
                                                   string strCodProyecto,
                                                        string strCodCentroCosto
                                                    )
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();

            return objDs.Combo_ClaseGasto_Otros(strCodCompañia,
                                                    strCodProyecto,
                                                        strCodCentroCosto
                                                      );
        }

        public DataSet Combo_ClaseGasto_Tarea(string strCodCompañia,
                                                   string strCodProyecto,
                                                        string strCodCentroCosto
                                                    )
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();

            return objDs.Combo_ClaseGasto_Tarea(strCodCompañia,
                                                    strCodProyecto,
                                                        strCodCentroCosto
                                                      );
        }

        public DataSet Ayuda_ClaseGasto()
        {

            Repository.DataGeneral objDs = new Repository.DataGeneral();

            return objDs.Ayuda_ClaseGasto();

        }
        public DataSet Combo_MetodoDistribucion()
        {

            Repository.DataGeneral obj = new Repository.DataGeneral();

            return obj.Combo_MetodoDistribucion();
        }

        public DataSet Ayuda_MetodoDistribucion()
        {

            Repository.DataGeneral obj = new Repository.DataGeneral();

            return obj.Ayuda_MetodoDistribucion();
        }
        #endregion

        #region Logistica
        public DataSet Lista_Proyecto_SaldoAñoAnterior( string strCodCompañia,
                                                        string strCodProyecto,
                                                        string strCodCentroCosto,
                                                        double dblImporte,
                                                        string strOrdenesElegidas
                                                      )
        {

            Repository.DataGeneral obj = new Repository.DataGeneral();

            return obj.Lista_Proyecto_SaldoAñoAnterior(strCodCompañia, strCodProyecto, strCodCentroCosto, dblImporte,strOrdenesElegidas);
        }

        public DataSet Lista_Proyecto_SaldoAñoAnterior_Clasificador(string strCodCompañia,
                                                        string strCodClasificador,
                                                        double dblImporte,
                                                        string strOrdenesElegidas
                                                      )
        {

            Repository.DataGeneral obj = new Repository.DataGeneral();

            return obj.Lista_Proyecto_SaldoAñoAnterior_Clasificador(strCodCompañia, strCodClasificador, dblImporte, strOrdenesElegidas);
        }

        public DataSet Lista_Proyecto_IncorporaSaldoAñoAnterior_OS( string strCodCompañia,
                                                                    string strCodProyecto,
                                                                    string strCodCentroCosto,
                                                                    string strNumeroOrden
                                                                  )
        {

            Repository.DataGeneral obj = new Repository.DataGeneral();

            return obj.Lista_Proyecto_IncorporaSaldoAñoAnterior_OS(strCodCompañia, strCodProyecto, strCodCentroCosto, strNumeroOrden);
        }

        public DataSet Lista_Proyecto_IncorporaSaldoAñoAnterior_OC(string strCodCompañia,
                                                                    string strCodProyecto,
                                                                    string strCodCentroCosto,
                                                                    string strNumeroOrden
                                                                  )
        {

            Repository.DataGeneral obj = new Repository.DataGeneral();

            return obj.Lista_Proyecto_IncorporaSaldoAñoAnterior_OC(strCodCompañia, strCodProyecto, strCodCentroCosto, strNumeroOrden);
        }




        public DataSet Lista_Proyecto_IncorporaSaldoAñoAnterior_OS_Clasificador(string strCodCompañia,
                                                                    string strCodClasificador,
                                                                    string strCodCentroCosto,
                                                                    string strNumeroOrden
                                                                  )
        {

            Repository.DataGeneral obj = new Repository.DataGeneral();

            return obj.Lista_Proyecto_IncorporaSaldoAñoAnterior_OS_Clasificador(strCodCompañia, strCodClasificador, strCodCentroCosto, strNumeroOrden);
        }

        public DataSet Lista_Proyecto_IncorporaSaldoAñoAnterior_OC_Clasificador(string strCodCompañia,
                                                                    string strCodClasificador,
                                                                    string strCodCentroCosto,
                                                                    string strNumeroOrden
                                                                  )
        {

            Repository.DataGeneral obj = new Repository.DataGeneral();

            return obj.Lista_Proyecto_IncorporaSaldoAñoAnterior_OC_Clasificador(strCodCompañia, strCodClasificador, strCodCentroCosto, strNumeroOrden);
        }

        public DataSet Lista_Conformidad_Pago(string strCodCompañia,
                                string strTipoOrden,
                                string strNumeroOrden
                     )
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Lista_Conformidad_Pago(strCodCompañia,
                                        strTipoOrden,
                                        strNumeroOrden
                                                         );
        }

        public DataSet Formato_Conformidad(string strCodCompañia,
                        string strNumConformidad,
                        string strTipoOrden,
                        string strNumOrden
                     )
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Formato_Conformidad(strCodCompañia,
                                        strNumConformidad,
                                        strTipoOrden,
                                        strNumOrden
                                                         );
        }


        #endregion

    }
}
