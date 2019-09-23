using System;
using System.Data;
using System.ServiceModel;

namespace WCFformulacion
{
    [ServiceContract]
    public interface IWCFformulacionE
    {
        //---------------------------------------------------------------------------------

        #region Concepto
        [OperationContract]
        DataSet Ayuda_Concepto();
        #endregion

        #region CentroCosto
        [OperationContract]
        DataSet Ayuda_CentroCosto_Todos();
        [OperationContract]
        DataSet Ayuda_CentroCosto(string strCodCompañia);
        [OperationContract]
        DataSet Lista_Ceco_Clasificador_Elegidos(string strCodCompañia, string strCeco);
        [OperationContract]
        DataSet Lista_Ceco_Clasificador_x_Elegir(string strCodCompañia, string strCeco);
        [OperationContract]
        int Graba_CentroCosto_Clasificador(string strCodCeco, string strCodClasificador);
        [OperationContract]
        int Elimina_CentroCosto_Clasificador(string strCodCeco, string strCodClasificador);
        [OperationContract]
        DataSet Lista_Ceco_Proyecto_Elegidos(string strCodCompañia, string strCodProyecto);
        [OperationContract]
        DataSet Lista_Ceco_Proyecto_x_Elegir(string strCodCompañia, string strCodProyecto);
        [OperationContract]
        int Graba_CentroCosto_Proyecto(string strCodCeco, string strCodProyecto);
        [OperationContract]
        int Elimina_CentroCosto_Proyecto(string strCodCeco, string strCodProyecto);
        #endregion

        //Clasificador---------------------------------------------------------------------------------
        #region Clasificador
        [OperationContract]
        DataSet Lista_Proyecto_IncorporaSaldoAñoAnterior_OS_Clasificador(string strCodCompañia,
                                                                string strCodClasificador,
                                                                string strCodCentroCosto,
                                                                string strNumeroOrden
                                                              );
        [OperationContract]
        DataSet Lista_Proyecto_IncorporaSaldoAñoAnterior_OC_Clasificador(string strCodCompañia,
                                                                    string strCodClasificador,
                                                                    string strCodCentroCosto,
                                                                    string strNumeroOrden
                                                                  );


        [OperationContract]
        DataSet Ayuda_Clasificador_Otro(string strCodCompañia, string strCodClasificador, string strCodCentroCosto);
        [OperationContract]
        DataSet Ayuda_Clasificador_Ingreso(string strCodCompañia, string strCodCentroCosto);
        [OperationContract]
        DataSet Ayuda_Clasificador(string strCodCompañia, string strCodClasificador, string strCodCentroCosto);
        [OperationContract]
        DataSet Ayuda_Clasificador_inversion(string strCodCompañia, string strCodProyecto, string strCodClasificador, string strCodCentroCosto);
        [OperationContract]
        DataSet Ayuda_Clasificador_tarea(string strCodCompañia, string strCodProyecto, string strCodClasificador, string strCodCentroCosto);
        #endregion

        //DataGeneral---------------------------------------------------------------------------------
        #region DataGeneral
        #region Proyecto
        [OperationContract]
        DataSet Combo_ClaseIngreso();
        [OperationContract]
        DataSet Ayuda_ClaseIngreso();
        [OperationContract]
        DataSet Combo_TipoFormulacion();
        [OperationContract]
        DataSet Combo_Proyecto_FuenteFinanciamiento_Todos(string strCodCompañia);
        [OperationContract]
        DataSet Ayuda_Proyecto_Componente_Todos_Spring(string strCodCompañia);
        [OperationContract]
        DataSet Ayuda_Proyecto_Componente_Spring(string strCodCompañia,
                                        string strCodProyecto);

        [OperationContract]
        DataSet Combo_Proyecto_FuenteFinanciamiento(string strCodCompañia, string strCodProyecto);
        [OperationContract]
        DataSet Combo_Tarea_FuenteFinanciamiento(string strCodCompañia, string strCodProyecto);
        [OperationContract]
        DataSet Ayuda_Proyecto_Spring(string strCodCompañia, string strCodCentroCosto);
        #endregion

        #region Contabilidad
        [OperationContract]
        DataSet Ayuda_PlanContable_Spring();
        #endregion

        #region Formulacion
        [OperationContract]
        DataSet Ayuda_FuenteFinanciamiento_Reporte(string strCodCompañia);
        [OperationContract]
        DataSet Ayuda_CentroCosto_Reporte(string strCodFuenteFinanciamiento);
        [OperationContract]
        DataSet Ayuda_Proyecto_Reporte( string strCodFuenteFinanciamiento, string strCodCentroCosto);

        [OperationContract]
        DataSet Combo_FuenteFinanciamiento_Reporte(string strCodCompañia);
        [OperationContract]
        DataSet Combo_CentroCosto_Reporte(string strCodFuenteFinanciamiento);
        [OperationContract]
        DataSet Combo_Proyecto_Reporte(string strCodCentroCosto);

        [OperationContract]
        DataSet Ayuda_Proyecto_FuenteFinanciamiento(string strCodCompañia,
                                                            string strCodProyecto
                                                          );

        [OperationContract]
        DataSet Combo_ClaseGasto_Otros(string strCodCompañia,
                                                   string strCodProyecto,
                                                        string strCodCentroCosto
                                                    );
        [OperationContract]
        DataSet Graba_Proyecto_OrdenTemporal(string strCodEmpleado, string strTipoOrden, string strNumeroOrden);
        [OperationContract]
        DataSet Elimina_Proyecto_OrdenTemporal(string strCodEmpleado, string strTipoOrden, string strNumeroOrden);
        [OperationContract]
        DataSet Ayuda_Proyecto_CentroCosto(string strCodCentroGestor, int intDigito);
        [OperationContract]
        DataSet Combo_ClaseGasto();
        [OperationContract]
        DataSet Combo_ClaseGasto_Clasificador(string strCodCompañia, string strCodCentroCosto, string strCodTipoFormulacion);
        [OperationContract]
        DataSet Combo_ClaseGasto_Inversion(string strCodCompañia, string strCodProyecto, string strCodCentroCosto);
        [OperationContract]
        DataSet Combo_ClaseGasto_Tarea(string strCodCompañia, string strCodProyecto, string strCodCentroCosto);
        [OperationContract]
        DataSet Ayuda_ClaseGasto();
        [OperationContract]
        DataSet Combo_MetodoDistribucion();
        [OperationContract]
        DataSet Ayuda_MetodoDistribucion();
        #endregion

        #region Logistica
        [OperationContract]
        DataSet Lista_Proyecto_SaldoAñoAnterior_Clasificador(string strCodCompañia,
                                                        string strCodClasificador,
                                                        double dblImporte,
                                                        string strOrdenesElegidas
                                                      );
        [OperationContract]
        DataSet Lista_Proyecto_SaldoAñoAnterior(string strCodCompañia, string strCodProyecto, string strCodCentroCosto, double dblImporte, string strOrdenesElegidas);
        [OperationContract]
        DataSet Lista_Proyecto_IncorporaSaldoAñoAnterior_OS(string strCodCompañia, string strCodProyecto, string strCodCentroCosto, string strNumeroOrden);
        [OperationContract]
        DataSet Lista_Proyecto_IncorporaSaldoAñoAnterior_OC(string strCodCompañia, string strCodProyecto, string strCodCentroCosto, string strNumeroOrden);
        [OperationContract]
        DataSet Lista_Conformidad_Pago(string strCodCompañia, string strTipoOrden, string strNumeroOrden);
        [OperationContract]
        DataSet Formato_Conformidad(string strCodCompañia, string strNumConformidad, string strTipoOrden, string strNumOrden);
        #endregion
        #endregion

        //---------------------------------------------------------------------------------
        #region Empleado
        [OperationContract]
        DataSet Ayuda_Empleado_Jefatura();
        [OperationContract]
        Model.Empleado Recupera_Empleado_Codigo(string strCodEmpleado);
        [OperationContract]
        DataSet Ayuda_Empleado();
        #endregion

        //EmpleadoCentroCosto------------------------------------------------------------------------------------
        #region EmpleadoCentroCosto
        [OperationContract]
        DataSet Arbol_Empleado();
        [OperationContract]
        int Graba_Empleado_CentroCosto(int iCodEmpleado, string strCodCeco);
        [OperationContract]
        int Modifica_Empleado_CentroCosto(int iCodEmpleado, string strCodCeco);
        [OperationContract]
        DataSet Recupera_Empleado_CentroCosto(int iCodEmpleado);
        #endregion

        //Empresa------------------------------------------------------------------------------------
        #region Empresa
        [OperationContract]
        DataSet Combo_Empresa_DataTable();
        #endregion

        //Formulacion_Cabecera------------------------------------------------------------------------------------
        #region Formulacion_Cabecera
        [OperationContract]
        DataTable Combo_AñoProceso(string strCodCompañia);
        [OperationContract]
        DataTable Combo_Version(string strAñoProceso);
        [OperationContract]
        Model.Formulacion_Cabecera Recupera_FormulacionCabecera(string strAñoProceso);
        [OperationContract]
        int Graba_FormulacionCabecera(Model.Formulacion_Cabecera obj);
        [OperationContract]
        DataSet Lista_FormulacionCabecera(string strAñoProceso);
        [OperationContract]
        bool elimina_mvto_Formulacion_Cabecera(int intiIdFormulacion_Cabecera);
        [OperationContract]
        DataSet Graba_FormulacionCabecera_DataSet(Model.Formulacion_Cabecera obj);
        [OperationContract]
        bool Modifica_mvto_Formulacion_Cabecera(Model.Formulacion_Cabecera obj);
        #endregion

        //Formulacion_Cabecera_Ceco------------------------------------------------------------------------------------
        #region Formulacion_Cabecera_Ceco
        [OperationContract]
        bool Graba_mvto_Formulacion_Cabecera_Ceco(Model.Formulacion_Cabecera_Ceco obj);
        [OperationContract]
        DataSet Lista_FormulacionCabecera_Ceco(string strAñoProceso, string strCeco, int digito);
        [OperationContract]
        Model.Formulacion_Cabecera_Ceco Recupera_FormulacionCabecera_CeCo(string strAñoProceso, string strVersion, string strCodCentroCosto);
        [OperationContract]
        DataSet Lista_Formulacion_Aprobacion_Ceco(string strAñoProceso, string strCeGe, string strVersion, int digito);
        [OperationContract]
        DataSet Lista_Version(string strAñoProceso);
        #endregion

        //Formulacion_Detalle------------------------------------------------------------------------------------------------------
        #region Formulacion_Detalle
        [OperationContract]
        int Graba_FormulacionDetalle(Model.Formulacion_Detalle obj);
        #endregion

        //Formulacion_Detalle_Personal
        [OperationContract]
        Boolean Elimina_FormulacionDetalle_Personal(int intIdFormulacion_Detalle_Personal);
        [OperationContract]
        int Graba_FormulacionDetalle_Personal(Model.Formulacion_Detalle_Personal obj);
        [OperationContract]
        int Modifica_FormulacionDetalle_Personal(Model.Formulacion_Detalle_Personal obj);
        [OperationContract]
        DataSet Lista_FormulacionDetalle_Personal(string strCodCompañia,
                                                         string strCodCentroCosto,
                                                         string strCodTipoFormulacion
                                        );


        //Formulacion_Detalle_Proyecto--------------------------------------------------------------------------------------------------
        #region Formulacion_Detalle_Proyecto

        [OperationContract]
        DataSet Lista_FormulacionReporteProyecto_CentroCosto(string cCodCompañia,
                                                            string cCodTipoFormulacion,
                                                            string cCodProyecto,
                                                            string cCodCentroCosto_Gestor
                                                           );
        [OperationContract]
        DataSet Lista_FormulacionDetalle_Proyecto_Otros(string strCodCompañia,
                                                 string strCodCentroCosto,
                                                 string strCodTipoFormulacion
                                );
        [OperationContract]
        Boolean Elimina_FormulacionDetalle_Proyecto(int intIdFormulacion_Detalle_Proyecto);
        [OperationContract]
        int Graba_FormulacionDetalle_Proyecto(Model.Formulacion_Detalle_Proyecto obj);
        [OperationContract]
        int Modifica_FormulacionDetalle_Proyecto(Model.Formulacion_Detalle_Proyecto obj);
        [OperationContract]
        DataSet Lista_FormulacionDetalle_Proyecto(string strCodCompañia, string strCodProyecto, string strCodCentroCosto, string strCodTipoFormulacion);
        #endregion

        //Formulacion_Detalle_Ingreso
        [OperationContract]
        Boolean Elimina_FormulacionDetalle_Ingreso(int intIdFormulacion_Detalle_Ingreso);
        [OperationContract]
        int Graba_FormulacionDetalle_Ingreso(Model.Formulacion_Detalle_Ingreso obj);
        [OperationContract]
        int Modifica_FormulacionDetalle_Ingreso(Model.Formulacion_Detalle_Ingreso obj);
        [OperationContract]
        DataSet Lista_FormulacionDetalle_Ingreso(string strCodCompañia,
                                                         string strCodProyecto,
                                                         string strCodCentroCosto,
                                                         string strCodTipoFormulacion
                                        );
        //FuenteFinanciamiento--------------------------------------------------------------------------------------------------
        #region FuenteFinanciamiento
        [OperationContract]
        DataSet Lista_Proyecto_FuenteFinanciamiento_Elegidos(string strCodCompañia, string strCodProyecto);
        [OperationContract]
        DataSet Lista_Proyecto_FuenteFinanciamiento_x_Elegir(string strCodCompañia, string strCodProyecto);
        [OperationContract]
        int Graba_Proyecto_FuenteFinanciamiento(string strCodProyecto, string strCodFuenteFinanciamiento);
        [OperationContract]
        int Elimina_Proyecto_FuenteFinanciamiento(string strCodProyecto, string strCodFuenteFinanciamiento);
        #endregion

        //PeriodoProceso------------------------------------------------------------------------------------
        #region PeriodoProceso
        [OperationContract]
        DataSet Combo_PeriodoProceso_DataTable();
        #endregion

        //Proyecto------------------------------------------------------------------------------------
        #region Proyecto
        //[OperationContract]
        //DataSet Ayuda_Proyecto_Spring(string strCodCompañia);
        #endregion

        //Reporte------------------------------------------------------------------------------------
        #region Reporte
        [OperationContract]
        DataSet Reporte_Detalle_Formulacion(string strCodCompañia,
                          string strAñoProceso,
                          string strVersion,
                          string strCodFuenteFinanciamiento,
                          string strCodCentroCosto,
                          string strCodProyecto
                        );
        [OperationContract]
        DataSet Lista_Formulacion_HojaTrabajo_Gasto(string strCodCompañia,
                  string strAñoProceso,
                  string strVersion,
                  string strCodFuenteFinanciamiento,
                  string strCodCentroCosto,
                  string strCodProyecto,
                  int intTipoAgrupacion
                );

        [OperationContract]
        DataSet Lista_Formulacion_HojaTrabajo_Ingreso(string strCodCompañia,
                          string strAñoProceso,
                          string strVersion,
                          string strCodFuenteFinanciamiento,
                          string strCodCentroCosto,
                          string strCodProyecto,
                          int intTipoAgrupacion
                        );


        [OperationContract]
        DataSet Lista_Formulacion_ResumenClasificador_Gasto(string strCodCompañia,
                              string strAñoProceso,
                              string strVersion,
                              string strCodFuenteFinanciamiento,
                              string strCodCentroCosto,
                              string strCodProyecto,
                              int intTipoAgrupacion
                            );

        [OperationContract]
        DataSet Lista_Formulacion_ResumenClasificador_Ingreso(string strCodCompañia,
                                  string strAñoProceso,
                                  string strVersion,
                                  string strCodFuenteFinanciamiento,
                                  string strCodCentroCosto,
                                  string strCodProyecto,
                                  int intTipoAgrupacion
                                );
        

        [OperationContract]
        DataSet Formato_4P(string strCodCompañia,
                          string strAñoProceso,
                          string strVersion,
                          string strCodFuenteFinanciamiento,
                          string strCodCentroCosto,
                          string strCodProyecto
                        );
        [OperationContract]
        DataSet Lista_FormulacionReporteProyecto(string cCodCompañia, string cAñoProceso, string cVersion, string cCodTipoFormulacion, string cCodProyecto);
        [OperationContract]
        DataSet Lista_FormulacionReporteContrato(string cCodCompañia, string cNumeroOrden, string cTipoOrden);
        [OperationContract]
        DataSet Help_FormulacionTipoFormulacion();
        [OperationContract]
        DataSet Lista_FormulacionReporteProyecto_Ceco(string cCodCompañia, string cAñoProceso, string cVersion, string cCodTipoFormulacion, string CodCentroCosto);
        [OperationContract]
        DataSet Lista_FormulacionReporteProyecto_Saldo(string cCodCompañia);
        #endregion

        //TipoDocumento------------------------------------------------------------------------------------
        #region TipoDocumento
        [OperationContract]
        DataSet Combo_TipoDocumento();
        #endregion

        //Usuario------------------------------------------------------------------------------------
        #region Usuario
        [OperationContract]
        Model.Usuario Recupera_Usuario(int intIdeUsuario);
        [OperationContract]
        Model.Usuario Recupera_Usuario_Codigo(string strCodempresa, string strLogUsuario);
        [OperationContract]
        DataSet Combo_Usuario_Modulo_DataTable(string strCodempresa, string strLogUsuario);
        [OperationContract]
        DataSet OpcionesMenu_Top(string strCodempresa, string strCodUsuario, string strCodModulo);
        [OperationContract]
        DataSet OpcionesMenu_Lateral(string strCodempresa, string strCodUsuario, string strCodModulo);
        [OperationContract]
        DataSet Ayuda_Proyecto_Spring_Help(string strCodCompañia);

        #endregion
    }
}
