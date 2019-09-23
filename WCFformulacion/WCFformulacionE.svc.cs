using System;
using System.Data;

namespace WCFformulacion
{
    public class WCFformulacionE : IWCFformulacionE
    {

        #region Concepto
        public DataSet Ayuda_Concepto()
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Ayuda_Concepto();
        }
        #endregion

        //CentroCosto---------------------------------------------------------------------------------

        #region CentroCosto
        public DataSet Ayuda_CentroCosto_Todos()
        {

            Repository.CentroCosto obj = new Repository.CentroCosto();

            return obj.Ayuda_CentroCosto_Todos();
        }
        public DataSet Ayuda_CentroCosto(string strCodCompañia)
        {
            Repository.CentroCosto obj = new Repository.CentroCosto();
            return obj.Ayuda_CentroCosto(strCodCompañia);
        }

        public DataSet Lista_Ceco_Clasificador_Elegidos(string strCodCompañia, string strCeco)
        {
            Repository.CentroCosto obj = new Repository.CentroCosto();
            return obj.Lista_Ceco_Clasificador_Elegidos(strCodCompañia, strCeco);
        }

        public DataSet Lista_Ceco_Clasificador_x_Elegir(string strCodCompañia, string strCeco)
        {
            Repository.CentroCosto obj = new Repository.CentroCosto();
            return obj.Lista_Ceco_Clasificador_x_Elegir(strCodCompañia, strCeco);
        }

        public int Graba_CentroCosto_Clasificador(string strCodCeco, string strCodClasificador)
        {
            Repository.CentroCosto objDs = new Repository.CentroCosto();
            return objDs.Graba_CentroCosto_Clasificador(strCodCeco, strCodClasificador);
        }

        public int Elimina_CentroCosto_Clasificador(string strCodCeco, string strCodClasificador)
        {
            Repository.CentroCosto objDs = new Repository.CentroCosto();
            return objDs.Elimina_CentroCosto_Clasificador(strCodCeco, strCodClasificador);
        }

        public DataSet Lista_Ceco_Proyecto_Elegidos(string strCodCompañia, string strCodProyecto)
        {
            Repository.CentroCosto obj = new Repository.CentroCosto();
            return obj.Lista_Ceco_Proyecto_Elegidos(strCodCompañia, strCodProyecto);
        }

        public DataSet Lista_Ceco_Proyecto_x_Elegir(string strCodCompañia, string strCodProyecto)
        {
            Repository.CentroCosto obj = new Repository.CentroCosto();
            return obj.Lista_Ceco_Proyecto_x_Elegir(strCodCompañia, strCodProyecto);
        }

        public int Graba_CentroCosto_Proyecto(string strCodCeco, string strCodProyecto)
        {
            Repository.CentroCosto objDs = new Repository.CentroCosto();
            return objDs.Graba_CentroCosto_Proyecto(strCodCeco, strCodProyecto);
        }

        public int Elimina_CentroCosto_Proyecto(string strCodCeco, string strCodProyecto)
        {
            Repository.CentroCosto objDs = new Repository.CentroCosto();
            return objDs.Elimina_CentroCosto_Proyecto(strCodCeco, strCodProyecto);
        }
        #endregion

        //Clasificador---------------------------------------------------------------------------------
        #region Clasificador

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


        public DataSet Ayuda_Clasificador_Otro(string strCodCompañia, string strCodClasificador, string strCodCentroCosto)
        {

            Repository.Clasificador obj = new Repository.Clasificador();

            return obj.Ayuda_Clasificador_Otro(strCodCompañia, strCodClasificador, strCodCentroCosto);
        }
        public DataSet Ayuda_Clasificador_Ingreso(string strCodCompañia, string strCodCentroCosto)
        {

            Repository.Clasificador obj = new Repository.Clasificador();

            return obj.Ayuda_Clasificador_Ingreso(strCodCompañia, strCodCentroCosto);
        }
        public DataSet Ayuda_Clasificador(string strCodCompañia, string strCodClasificador, string strCodCentroCosto)
        {
            Repository.Clasificador obj = new Repository.Clasificador();
            return obj.Ayuda_Clasificador(strCodCompañia, strCodClasificador, strCodCentroCosto);
        }

        public DataSet Ayuda_Clasificador_inversion(string strCodCompañia, string strCodProyecto, string strCodClasificador, string strCodCentroCosto)
        {
            Repository.Clasificador obj = new Repository.Clasificador();
            return obj.Ayuda_Clasificador_Inversion(strCodCompañia, strCodProyecto, strCodClasificador, strCodCentroCosto);
        }

        public DataSet Ayuda_Clasificador_tarea(string strCodCompañia, string strCodProyecto, string strCodClasificador, string strCodCentroCosto)
        {
            Repository.Clasificador obj = new Repository.Clasificador();
            return obj.Ayuda_Clasificador_Tarea(strCodCompañia, strCodProyecto, strCodClasificador, strCodCentroCosto);
        }
        #endregion

        //DataGeneral---------------------------------------------------------------------------------
        #region DataGeneral
        #region Proyecto

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

        public DataSet Combo_TipoFormulacion()
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();

            return objDs.Combo_TipoFormulacion();
        }

        public DataSet Ayuda_Proyecto_Componente_Todos_Spring(string strCodCompañia)
        {

            Repository.DataGeneral objDs = new Repository.DataGeneral();

            return objDs.Ayuda_Proyecto_Componente_Todos_Spring(strCodCompañia);

        }
        public DataSet Ayuda_Proyecto_Componente_Spring(string strCodCompañia,
                                            string strCodProyecto)
        {

            Repository.DataGeneral objDs = new Repository.DataGeneral();

            return objDs.Ayuda_Proyecto_Componente_Spring(strCodCompañia, strCodProyecto);

        }

        public DataSet Combo_Proyecto_FuenteFinanciamiento_Todos(string strCodCompañia)
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Combo_Proyecto_FuenteFinanciamiento_Todos(strCodCompañia);

        }

        public DataSet Combo_Proyecto_FuenteFinanciamiento(string strCodCompañia, string strCodProyecto)
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Combo_Proyecto_FuenteFinanciamiento(strCodCompañia, strCodProyecto);
        }

        public DataSet Combo_Tarea_FuenteFinanciamiento(string strCodCompañia,string strCodProyecto)
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Combo_Tarea_FuenteFinanciamiento(strCodCompañia, strCodProyecto);
        }

        public DataSet Ayuda_Proyecto_Spring(string strCodCompañia, string strCodCentroCosto)
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Ayuda_Proyecto_Spring(strCodCompañia, strCodCentroCosto);
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

        public DataSet Ayuda_Proyecto_Reporte( string strCodFuenteFinanciamiento, string strCodCentroCosto)
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Ayuda_Proyecto_Reporte( strCodFuenteFinanciamiento, strCodCentroCosto);
        }

        public DataSet Combo_FuenteFinanciamiento_Reporte(string strCodCompañia)
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

        public DataSet Ayuda_Proyecto_FuenteFinanciamiento(string strCodCompañia,
                                                            string strCodProyecto
                                                          )
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Ayuda_Proyecto_FuenteFinanciamiento(strCodCompañia, strCodProyecto);

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

        public DataSet Graba_Proyecto_OrdenTemporal(string strCodEmpleado,string strTipoOrden, string strNumeroOrden)
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Graba_Proyecto_OrdenTemporal(strCodEmpleado, strTipoOrden, strNumeroOrden);
        }

        public DataSet Elimina_Proyecto_OrdenTemporal(string strCodEmpleado,string strTipoOrden, string strNumeroOrden)
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

        public DataSet Combo_ClaseGasto_Clasificador(string strCodCompañia,string strCodCentroCosto,string strCodTipoFormulacion)
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Combo_ClaseGasto_Clasificador(strCodCompañia,strCodCentroCosto,strCodTipoFormulacion);
        }

        public DataSet Combo_ClaseGasto_Inversion(string strCodCompañia, string strCodProyecto,string strCodCentroCosto)
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Combo_ClaseGasto_Inversion(strCodCompañia, strCodProyecto,strCodCentroCosto);
        }

        public DataSet Combo_ClaseGasto_Tarea(string strCodCompañia,string strCodProyecto,string strCodCentroCosto)
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Combo_ClaseGasto_Tarea(strCodCompañia, strCodProyecto, strCodCentroCosto);
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

        public DataSet Lista_Proyecto_SaldoAñoAnterior_Clasificador(string strCodCompañia,
                                                        string strCodClasificador,
                                                        double dblImporte,
                                                        string strOrdenesElegidas
                                                      )
        {

            Repository.DataGeneral obj = new Repository.DataGeneral();

            return obj.Lista_Proyecto_SaldoAñoAnterior_Clasificador(strCodCompañia, strCodClasificador, dblImporte, strOrdenesElegidas);
        }

        public DataSet Lista_Proyecto_SaldoAñoAnterior(string strCodCompañia,string strCodProyecto,string strCodCentroCosto,double dblImporte,string strOrdenesElegidas)
        {
            Repository.DataGeneral obj = new Repository.DataGeneral();
            return obj.Lista_Proyecto_SaldoAñoAnterior(strCodCompañia, strCodProyecto, strCodCentroCosto, dblImporte, strOrdenesElegidas);
        }

        public DataSet Lista_Proyecto_IncorporaSaldoAñoAnterior_OS(string strCodCompañia,string strCodProyecto, string strCodCentroCosto, string strNumeroOrden)
        {
            Repository.DataGeneral obj = new Repository.DataGeneral();
            return obj.Lista_Proyecto_IncorporaSaldoAñoAnterior_OS(strCodCompañia, strCodProyecto, strCodCentroCosto, strNumeroOrden);
        }

        public DataSet Lista_Proyecto_IncorporaSaldoAñoAnterior_OC(string strCodCompañia,string strCodProyecto, string strCodCentroCosto, string strNumeroOrden)
        {
            Repository.DataGeneral obj = new Repository.DataGeneral();
            return obj.Lista_Proyecto_IncorporaSaldoAñoAnterior_OC(strCodCompañia, strCodProyecto, strCodCentroCosto, strNumeroOrden);
        }

        public DataSet Lista_Conformidad_Pago(string strCodCompañia,string strTipoOrden,string strNumeroOrden)
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Lista_Conformidad_Pago(strCodCompañia,strTipoOrden,strNumeroOrden);
        }

        public DataSet Formato_Conformidad(string strCodCompañia,string strNumConformidad,string strTipoOrden,string strNumOrden)
        {
            Repository.DataGeneral objDs = new Repository.DataGeneral();
            return objDs.Formato_Conformidad(strCodCompañia,strNumConformidad,strTipoOrden, strNumOrden);
        }

        #endregion
        #endregion

        //Empleado------------------------------------------------------------------------------------
        #region Empleado
        public DataSet Ayuda_Empleado_Jefatura()
        {
            Repository.Empleado obj = new Repository.Empleado();
            return obj.Ayuda_Empleado_Jefatura();
        }

        public Model.Empleado Recupera_Empleado_Codigo(string strCodEmpleado)
        {
            Repository.Empleado objE = new Repository.Empleado();
            return objE.Recupera_Empleado_Codigo(strCodEmpleado);
        }

        public DataSet Ayuda_Empleado()
        {
            Repository.Empleado objE = new Repository.Empleado();
            return objE.Ayuda_Empleado();
        }
        #endregion

        //EmpleadoCentroCosto------------------------------------------------------------------------------------
        #region EmpleadoCentroCosto
        public DataSet Arbol_Empleado()
        {
            Repository.EmpleadoCentroCosto obj = new Repository.EmpleadoCentroCosto();
            return obj.Arbol_Empleado();
        }
        public int Graba_Empleado_CentroCosto(int iCodEmpleado, string strCodCeco)
        {
            Repository.EmpleadoCentroCosto obj = new Repository.EmpleadoCentroCosto();
            return obj.Graba_Empleado_CentroCosto(iCodEmpleado, strCodCeco);
        }

        public int Modifica_Empleado_CentroCosto(int iCodEmpleado, string strCodCeco)
        {
            Repository.EmpleadoCentroCosto obj = new Repository.EmpleadoCentroCosto();
            return obj.Modifica_Empleado_CentroCosto(iCodEmpleado, strCodCeco);
        }
        public DataSet Recupera_Empleado_CentroCosto(int iCodEmpleado)
        {
            Repository.EmpleadoCentroCosto obj = new Repository.EmpleadoCentroCosto();
            return obj.Recupera_Empleado_CentroCosto(iCodEmpleado);
        }
        #endregion

        //Empresa--------------------------------------------------------------------------------------------------
        #region Empresa
        public DataSet Combo_Empresa_DataTable()
        {
            Repository.Empresa obj = new Repository.Empresa();
            return obj.Combo_Empresa_DataTable();
        }
        #endregion

      

        //Formulacion_Cabecera------------------------------------------------------------------------------------
        #region Formulacion_Cabecera
        public DataTable Combo_AñoProceso(string strCodCompañia)
        {
            Repository.Formulacion_Cabecera objDs = new Repository.Formulacion_Cabecera();
            return objDs.Combo_AñoProceso(strCodCompañia);
        }

        public DataTable Combo_Version(string strAñoProceso)
        {
            Repository.Formulacion_Cabecera objDs = new Repository.Formulacion_Cabecera();
            return objDs.Combo_Version(strAñoProceso);
        }
        public Model.Formulacion_Cabecera Recupera_FormulacionCabecera(string strAñoProceso)
        {
            Repository.Formulacion_Cabecera objDs = new Repository.Formulacion_Cabecera();
            return objDs.Recupera_FormulacionCabecera(strAñoProceso);
        }

        public int Graba_FormulacionCabecera(Model.Formulacion_Cabecera obj)
        {
            Repository.Formulacion_Cabecera objDs = new Repository.Formulacion_Cabecera();
            return objDs.Graba_FormulacionCabecera(obj);
        }

        public DataSet Lista_FormulacionCabecera(string strAñoProceso)
        {
            Repository.Formulacion_Cabecera objDs = new Repository.Formulacion_Cabecera();
            return objDs.Lista_FormulacionCabecera(strAñoProceso);
        }

        public bool elimina_mvto_Formulacion_Cabecera(int intiIdFormulacion_Cabecera)
        {
            Repository.Formulacion_Cabecera objDs = new Repository.Formulacion_Cabecera();
            return objDs.elimina_mvto_Formulacion_Cabecera(intiIdFormulacion_Cabecera);
        }

        public DataSet Graba_FormulacionCabecera_DataSet(Model.Formulacion_Cabecera obj)
        {
            Repository.Formulacion_Cabecera objDs = new Repository.Formulacion_Cabecera();
            return objDs.Graba_FormulacionCabecera_DataSet(obj);
        }

        public bool Modifica_mvto_Formulacion_Cabecera(Model.Formulacion_Cabecera obj)
        {
            Repository.Formulacion_Cabecera objDs = new Repository.Formulacion_Cabecera();
            return objDs.Modifica_mvto_Formulacion_Cabecera(obj);
        }
        #endregion

        //Formulacion_Cabecera_Ceco------------------------------------------------------------------------------------
        #region Formulacion_Cabecera_Ceco
        public bool Graba_mvto_Formulacion_Cabecera_Ceco(Model.Formulacion_Cabecera_Ceco obj)
        {
            Repository.Formulacion_Cabecera_Ceco objDs = new Repository.Formulacion_Cabecera_Ceco();
            return objDs.Graba_mvto_Formulacion_Cabecera_Ceco(obj);
        }
        public DataSet Lista_FormulacionCabecera_Ceco(string strAñoProceso, string strCeco, int digito)
        {
            Repository.Formulacion_Cabecera_Ceco objDs = new Repository.Formulacion_Cabecera_Ceco();
            return objDs.Lista_FormulacionCabecera_Ceco(strAñoProceso, strCeco, digito);
        }

        public Model.Formulacion_Cabecera_Ceco Recupera_FormulacionCabecera_CeCo(string strAñoProceso,string strVersion,string strCodCentroCosto)
        {
            Repository.Formulacion_Cabecera_Ceco objDs = new Repository.Formulacion_Cabecera_Ceco();
            return objDs.Recupera_FormulacionCabecera_CeCo(strAñoProceso, strVersion, strCodCentroCosto);
        }

        public DataSet Lista_Formulacion_Aprobacion_Ceco(string strAñoProceso, string strCeGe, string strVersion, int digito)
        {
            Repository.Formulacion_Cabecera_Ceco objDs = new Repository.Formulacion_Cabecera_Ceco();
            return objDs.Lista_Formulacion_Aprobacion_Ceco(strAñoProceso, strCeGe, strVersion, digito);
        }

        public DataSet Lista_Version(string strAñoProceso)
        {
            Repository.Formulacion_Cabecera_Ceco objDs = new Repository.Formulacion_Cabecera_Ceco();
            return objDs.Lista_Version(strAñoProceso);
        }
        #endregion

        //Formulacion_Detalle------------------------------------------------------------------------------------------------------
        #region Formulacion_Detalle
        public int Graba_FormulacionDetalle(Model.Formulacion_Detalle obj)
        {
            Repository.Formulacion_Detalle objDs = new Repository.Formulacion_Detalle();
            return objDs.Graba_FormulacionDetalle(obj);
        }
        #endregion

        //Formulacion_Detalle_Personal
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




        //Formulacion_Detalle_Proyecto--------------------------------------------------------------------------------------------------
        #region Formulacion_Detalle_Proyecto


        public DataSet Lista_FormulacionReporteProyecto_CentroCosto(string cCodCompañia,
                                                                string cCodTipoFormulacion,
                                                                string cCodProyecto,
                                                                string cCodCentroCosto_Gestor
                                                               )
        {
            Repository.Reporte objDs = new Repository.Reporte();
            return objDs.Lista_FormulacionReporteProyecto_CentroCosto(cCodCompañia, cCodTipoFormulacion, cCodProyecto, cCodCentroCosto_Gestor);
        }

        public DataSet Lista_FormulacionDetalle_Proyecto_Otros(string strCodCompañia,
                                                     string strCodCentroCosto,
                                                     string strCodTipoFormulacion
                                    )
        {
            Repository.Formulacion_Detalle_Proyecto objDs = new Repository.Formulacion_Detalle_Proyecto();
            return objDs.Lista_FormulacionDetalle_Proyecto_Otros(strCodCompañia, strCodCentroCosto, strCodTipoFormulacion);
        }
        public Boolean Elimina_FormulacionDetalle_Proyecto(int intIdFormulacion_Detalle_Proyecto)
        {

            Repository.Formulacion_Detalle_Proyecto objDs = new Repository.Formulacion_Detalle_Proyecto();

            return objDs.Elimina_FormulacionDetalle_Proyecto(intIdFormulacion_Detalle_Proyecto);

        }

        public int Graba_FormulacionDetalle_Proyecto(Model.Formulacion_Detalle_Proyecto obj)
        {
            Repository.Formulacion_Detalle_Proyecto objDs = new Repository.Formulacion_Detalle_Proyecto();
            return objDs.Graba_FormulacionDetalle_Proyecto(obj);
        }

        public int Modifica_FormulacionDetalle_Proyecto(Model.Formulacion_Detalle_Proyecto obj)
        {
            Repository.Formulacion_Detalle_Proyecto objDs = new Repository.Formulacion_Detalle_Proyecto();
            return objDs.Modifica_FormulacionDetalle_Proyecto(obj);
        }

        public DataSet Lista_FormulacionDetalle_Proyecto(string strCodCompañia, string strCodProyecto,string strCodCentroCosto,string strCodTipoFormulacion)
        {
            Repository.Formulacion_Detalle_Proyecto objDs = new Repository.Formulacion_Detalle_Proyecto();
            return objDs.Lista_FormulacionDetalle_Proyecto(strCodCompañia, strCodProyecto, strCodCentroCosto, strCodTipoFormulacion);
        }
        #endregion

        //Formulacion_Detalle_Ingreso
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

        //FuenteFinanciamiento--------------------------------------------------------------------------------------------------
        #region FuenteFinanciamiento
        public DataSet Lista_Proyecto_FuenteFinanciamiento_Elegidos(string strCodCompañia, string strCodProyecto)
        {
            Repository.FuenteFinanciamiento obj = new Repository.FuenteFinanciamiento();
            return obj.Lista_Proyecto_FuenteFinanciamiento_Elegidos(strCodCompañia, strCodProyecto);
        }

        public DataSet Lista_Proyecto_FuenteFinanciamiento_x_Elegir(string strCodCompañia,string strCodProyecto )
        {
            Repository.FuenteFinanciamiento obj = new Repository.FuenteFinanciamiento();
            return obj.Lista_Proyecto_FuenteFinanciamiento_x_Elegir(strCodCompañia, strCodProyecto);
        }

        public int Graba_Proyecto_FuenteFinanciamiento(string strCodProyecto, string strCodFuenteFinanciamiento)
        {
            Repository.FuenteFinanciamiento objDs = new Repository.FuenteFinanciamiento();
            return objDs.Graba_Proyecto_FuenteFinanciamiento(strCodProyecto, strCodFuenteFinanciamiento);
       }

        public int Elimina_Proyecto_FuenteFinanciamiento(string strCodProyecto, string strCodFuenteFinanciamiento)
        {
            Repository.FuenteFinanciamiento objDs = new Repository.FuenteFinanciamiento();
            return objDs.Elimina_Proyecto_FuenteFinanciamiento(strCodProyecto, strCodFuenteFinanciamiento);
        }
        #endregion

        //PeriodoProceso------------------------------------------------------------------------------------
        #region PeriodoProceso
        public DataSet Combo_PeriodoProceso_DataTable()
        {
            Repository.PeriodoProceso objRPeriodoProceso = new Repository.PeriodoProceso();
            return objRPeriodoProceso.Combo_PeriodoProceso_DataTable();
        }
        #endregion

        //Proyecto------------------------------------------------------------------------------------
        #region Proyecto
        //public DataSet Ayuda_Proyecto_Spring(string strCodCompañia)
        //{
        //    Repository.Proyecto obj = new Repository.Proyecto();
        //    return obj.Ayuda_Proyecto_Spring(strCodCompañia);
        //}
        #endregion

        //Reporte------------------------------------------------------------------------------------
        #region Reporte

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

        public DataSet Lista_FormulacionReporteProyecto(string cCodCompañia, string cAñoProceso, string cVersion, string cCodTipoFormulacion, string cCodProyecto)
        {
            Repository.Reporte objDs = new Repository.Reporte();
            return objDs.Lista_FormulacionReporteProyecto(cCodCompañia, cAñoProceso, cVersion, cCodTipoFormulacion, cCodProyecto);
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

        public DataSet Lista_FormulacionReporteProyecto_Ceco(string cCodCompañia, string cAñoProceso, string cVersion, string cCodTipoFormulacion, string CodCentroCosto)
        {
            Repository.Reporte objDs = new Repository.Reporte();
            return objDs.Lista_FormulacionReporteProyecto_Ceco(cCodCompañia, cAñoProceso, cVersion, cCodTipoFormulacion, CodCentroCosto);
        }

        public DataSet Lista_FormulacionReporteProyecto_Saldo(string cCodCompañia)
        {
            Repository.Reporte objDs = new Repository.Reporte();
            return objDs.Lista_FormulacionReporteProyecto_Saldo(cCodCompañia);
        }
        #endregion

        //TipoDocumento------------------------------------------------------------------------------------
        #region TipoDocumento
        public DataSet Combo_TipoDocumento()
        {
            Repository.TipoDocumento obj = new Repository.TipoDocumento();
            return obj.Combo_TipoDocumento();
        }
        #endregion

        //Usuario------------------------------------------------------------------------------------
        #region Usuario
        public Model.Usuario Recupera_Usuario(int intIdeUsuario)
        {
            Repository.Usuario obj = new Repository.Usuario();
            return obj.Recupera_Usuario(intIdeUsuario);
        }

        public Model.Usuario Recupera_Usuario_Codigo(string strCodempresa, string strLogUsuario)
        {
            Repository.Usuario obj = new Repository.Usuario();
            return obj.Recupera_Usuario_Codigo(strCodempresa, strLogUsuario);
        }
        public DataSet Combo_Usuario_Modulo_DataTable(string strCodempresa, string strLogUsuario)
        {
            Repository.Usuario obj = new Repository.Usuario();
            return obj.Combo_Usuario_Modulo_DataTable(strCodempresa, strLogUsuario);
        }

        public DataSet OpcionesMenu_Top(string strCodempresa, string strCodUsuario,string strCodModulo)
        {
            Repository.Usuario obj = new Repository.Usuario();
            return obj.OpcionesMenu_Top(strCodempresa, strCodUsuario, strCodModulo);
        }
        public DataSet OpcionesMenu_Lateral(string strCodempresa, string strCodUsuario, string strCodModulo)
        {
            Repository.Usuario obj = new Repository.Usuario();
            return obj.OpcionesMenu_Lateral(strCodempresa, strCodUsuario, strCodModulo);
        }
        public DataSet Ayuda_Proyecto_Spring_Help(string strCodCompañia)
        {
            Repository.Proyecto obj = new Repository.Proyecto();
            return obj.Ayuda_Proyecto_Spring_Help(strCodCompañia);
        }
        #endregion
    }
}
