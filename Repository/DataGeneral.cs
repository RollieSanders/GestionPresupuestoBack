using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Repository
{
    public class DataGeneral
    {
        private string strConnection = "";
        public DataGeneral()
        {
            Repository.DataAccess DA = new Repository.DataAccess();
            strConnection = DA.ReturnConnectionString_Formulacion();
        }

        #region Concepto
        public DataSet Ayuda_Concepto()
        {
            return SqlHelper.ExecuteDataset(strConnection, "Personal.spp_help_msto_Concepto" );
        }
        #endregion

        #region Proyecto

        public DataSet Ayuda_Proyecto_Spring(   string strCodCompañia,
                                                string strCodCentroCosto
                                            )
        {
            return SqlHelper.ExecuteDataset(strConnection, "Formulacion.spp_help_msto_Proyecto_Spring", strCodCompañia, strCodCentroCosto);
        }

        public DataSet Ayuda_Proyecto_Componente_Spring(string strCodCompañia,
                                                string strCodProyecto
                                            )
        {
            return SqlHelper.ExecuteDataset(strConnection, "Proyecto.spp_help_msto_Componente", strCodCompañia, strCodProyecto);
        }

        public DataSet Ayuda_Proyecto_Componente_Todos_Spring(string strCodCompañia )
        {
            return SqlHelper.ExecuteDataset(strConnection, "Proyecto.spp_help_msto_Componente_Todos", strCodCompañia );
        }

        #endregion

        #region Contabilidad
        public DataSet Ayuda_PlanContable_Spring()
        {
            return SqlHelper.ExecuteDataset(strConnection, "Contabilidad.spp_help_msto_PlanContable_Spring");
        }
        #endregion

        #region Formulacion

        public DataSet Combo_FuenteFinanciamiento_Reporte(string strCodCompañia)
        {
            return SqlHelper.ExecuteDataset(strConnection, "Formulacion.spp_cbo_msto_FuenteFinanciamiento_Reporte", strCodCompañia);
        }

        public DataSet Combo_CentroCosto_Reporte( string strCodFuenteFinanciamiento )
        {
            return SqlHelper.ExecuteDataset(strConnection, "Formulacion.spp_cbo_msto_CentroCosto_Reporte");
        }

        public DataSet Combo_Proyecto_Reporte(string strCodCentroCosto)
        {
            return SqlHelper.ExecuteDataset(strConnection, "Formulacion.spp_cbo_msto_Proyecto_Reporte", strCodCentroCosto);
        }

        public DataSet Ayuda_FuenteFinanciamiento_Reporte(string strCodCompañia)
        {
            return SqlHelper.ExecuteDataset(strConnection, "Formulacion.spp_help_msto_FuenteFinanciamiento_Reporte", strCodCompañia);
        }

        public DataSet Ayuda_CentroCosto_Reporte(string strCodFuenteFinanciamiento)
        {
            return SqlHelper.ExecuteDataset(strConnection, "Formulacion.spp_help_msto_CentroCosto_Reporte", strCodFuenteFinanciamiento);
        }

        public DataSet Ayuda_Proyecto_Reporte( string strCodFuenteFinanciamiento,
                                               string strCodCentroCosto
                                             )
        {
            return SqlHelper.ExecuteDataset(strConnection, "Formulacion.spp_help_msto_Proyecto_Reporte", strCodFuenteFinanciamiento, strCodCentroCosto);
        }


        public DataSet Graba_Proyecto_OrdenTemporal(string strCodEmpleado, 
                                                    string strTipoOrden,
                                                    string strNumeroOrden
                                                  )
        {
            return SqlHelper.ExecuteDataset(strConnection, "Formulacion.spp_ins_mvto_OrdenTemporal", strCodEmpleado, strTipoOrden, strNumeroOrden );
        }

        public DataSet Elimina_Proyecto_OrdenTemporal(string strCodEmpleado,
                                                    string strTipoOrden,
                                                    string strNumeroOrden
                                                  )
        {
            return SqlHelper.ExecuteDataset(strConnection, "Formulacion.spp_del_mvto_OrdenTemporal", strCodEmpleado, strTipoOrden, strNumeroOrden);
        }

        public DataSet Ayuda_Proyecto_CentroCosto( string strCodCentroGestor, int intDigito  )
        {
            return SqlHelper.ExecuteDataset(strConnection, "Formulacion.spp_help_msto_Proyecto_CentroCosto", strCodCentroGestor, intDigito);
        }
        public DataSet Combo_ClaseGasto()
        {
            return SqlHelper.ExecuteDataset(strConnection, "Formulacion.spp_cbo_ClaseGasto");
        }

        public DataSet Combo_Proyecto_FuenteFinanciamiento( string strCodCompañia,
                                                            string strCodProyecto 
                                                          )
        {
            return SqlHelper.ExecuteDataset(strConnection, "Proyecto.spp_cbo_Proyecto_FuenteFinanciamiento", strCodCompañia, strCodProyecto
                                            );
        }

        public DataSet Combo_Proyecto_FuenteFinanciamiento_Todos(string strCodCompañia )
        {
            return SqlHelper.ExecuteDataset(strConnection, "Proyecto.spp_cbo_Proyecto_FuenteFinanciamiento_Todos", strCodCompañia
                                            );
        }

        public DataSet Ayuda_Proyecto_FuenteFinanciamiento(string strCodCompañia,
                                                            string strCodProyecto
                                                          )
        {
            return SqlHelper.ExecuteDataset(strConnection, "Proyecto.spp_help_Proyecto_FuenteFinanciamiento", strCodCompañia, strCodProyecto
                                            );
        }

        public DataSet Combo_Tarea_FuenteFinanciamiento(string strCodCompañia,
                                                            string strCodProyecto
                                                          )
        {
            return SqlHelper.ExecuteDataset(strConnection, "Proyecto.spp_cbo_Tarea_FuenteFinanciamiento", strCodCompañia, strCodProyecto
                                            );
        }

        public DataSet Combo_ClaseGasto_Clasificador(   string strCodCompañia,
                                                        string strCodCentroCosto,
                                                        string strCodTipoFormulacion
                                                    )
        {
            return SqlHelper.ExecuteDataset(strConnection, "Formulacion.spp_cbo_ClaseGasto_clasificador", strCodCompañia, 
                                                                                                          strCodCentroCosto,
                                                                                                          strCodTipoFormulacion
                                            );
        }

        public DataSet Combo_ClaseGasto_Inversion(string strCodCompañia,
                                                  string strCodProyecto,
                                                  string strCodCentroCosto
                                                    )
        {
            return SqlHelper.ExecuteDataset(strConnection, "Formulacion.spp_cbo_ClaseGasto_Inversion", strCodCompañia,
                                                                                                       strCodProyecto,
                                                                                                          strCodCentroCosto
                                            );
        }

        public DataSet Combo_ClaseGasto_Otros(string strCodCompañia,
                                          string strCodProyecto,
                                          string strCodCentroCosto
                                            )
        {
            return SqlHelper.ExecuteDataset(strConnection, "Formulacion.spp_cbo_ClaseGasto_Otros", strCodCompañia,
                                                                                                       strCodProyecto,
                                                                                                          strCodCentroCosto
                                            );
        }


        public DataSet Combo_ClaseGasto_Tarea(string strCodCompañia,
                                                  string strCodProyecto,
                                                  string strCodCentroCosto
                                                    )
        {
            return SqlHelper.ExecuteDataset(strConnection, "Formulacion.spp_cbo_ClaseGasto_Tarea", strCodCompañia,
                                                                                                       strCodProyecto,
                                                                                                          strCodCentroCosto
                                            );
        }

        public DataSet Ayuda_ClaseGasto()
        {
            return SqlHelper.ExecuteDataset(strConnection, "Formulacion.spp_help_ClaseGasto" );
        }

        public DataSet Ayuda_ClaseIngreso()
        {
            return SqlHelper.ExecuteDataset(strConnection, "Formulacion.spp_help_ClaseIngreso");
        }

        public DataSet Combo_ClaseIngreso()
        {
            return SqlHelper.ExecuteDataset(strConnection, "Formulacion.spp_cbo_ClaseIngreso");
        }

        public DataSet Combo_TipoFormulacion()
        {
            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection, "Formulacion.spp_cbo_ctrl_TipoFormulacion"))
            {
                return ds;
            }
        }


        public DataSet Combo_MetodoDistribucion()
        {
            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection, "Formulacion.spp_cbo_ctrl_MetodoDistribucion"))
            {
                return ds;
            }

        }
        public DataSet Ayuda_MetodoDistribucion()
        {
            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection, "Formulacion.spp_help_ctrl_MetodoDistribucion"))
            {
                return ds;
            }

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



            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("Logistica.spp_lst_mvto_SaldoProyecto", strConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@cCodCompañia", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodProyecto", SqlDbType.VarChar);
            da.SelectCommand.Parameters.Add("@cCodCentroCosto", SqlDbType.VarChar);
            da.SelectCommand.Parameters.Add("@fImporte", SqlDbType.Float);
            da.SelectCommand.Parameters.Add("@vOrdenesElegidas", SqlDbType.VarChar);


            da.SelectCommand.Parameters["@cCodCompañia"].Value = strCodCompañia;
            da.SelectCommand.Parameters["@cCodProyecto"].Value = strCodProyecto;
            da.SelectCommand.Parameters["@cCodCentroCosto"].Value = strCodCentroCosto;
            da.SelectCommand.Parameters["@fImporte"].Value = dblImporte;
            da.SelectCommand.Parameters["@vOrdenesElegidas"].Value = strOrdenesElegidas;

            da.SelectCommand.CommandTimeout = 600000000;
            da.Fill(ds);

            return ds;

        }

        public DataSet Lista_Proyecto_SaldoAñoAnterior_Clasificador(string strCodCompañia,
                                                                    string strCodClasificador,
                                                                    double dblImporte,
                                                                    string strOrdenesElegidas
                                                                  )
        {



            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("Logistica.spp_lst_mvto_SaldoProyecto_Clasificador", strConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@cCodCompañia", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodClasificador", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@fImporte", SqlDbType.Float);
            da.SelectCommand.Parameters.Add("@vOrdenesElegidas", SqlDbType.VarChar);


            da.SelectCommand.Parameters["@cCodCompañia"].Value = strCodCompañia;
            da.SelectCommand.Parameters["@cCodClasificador"].Value = strCodClasificador;
            da.SelectCommand.Parameters["@fImporte"].Value = dblImporte;
            da.SelectCommand.Parameters["@vOrdenesElegidas"].Value = strOrdenesElegidas;

            da.SelectCommand.CommandTimeout = 600000000;
            da.Fill(ds);

            return ds;

        }


        public DataSet Lista_Proyecto_IncorporaSaldoAñoAnterior_OS( string strCodCompañia,
                                                                    string strCodProyecto,
                                                                    string strCodCentroCosto,
                                                                    string strNumeroOrden
                                                                  )
        {



            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("Logistica.spp_ins_mvto_SaldoProyecto_OrdenServicio", strConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@cCodCompañia", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodProyecto", SqlDbType.VarChar);
            da.SelectCommand.Parameters.Add("@cCodCentroCosto", SqlDbType.VarChar);
            da.SelectCommand.Parameters.Add("@cNumeroOrden", SqlDbType.VarChar);


            da.SelectCommand.Parameters["@cCodCompañia"].Value = strCodCompañia;
            da.SelectCommand.Parameters["@cCodProyecto"].Value = strCodProyecto;
            da.SelectCommand.Parameters["@cCodCentroCosto"].Value = strCodCentroCosto;
            da.SelectCommand.Parameters["@cNumeroOrden"].Value = strNumeroOrden;

            da.SelectCommand.CommandTimeout = 600000000;
            da.Fill(ds);

            return ds;

        }

        public DataSet Lista_Proyecto_IncorporaSaldoAñoAnterior_OC(string strCodCompañia,
                                                                    string strCodProyecto,
                                                                    string strCodCentroCosto,
                                                                    string strNumeroOrden
                                                                  )
        {



            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("Logistica.spp_ins_mvto_SaldoProyecto_OrdenCompra", strConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@cCodCompañia", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodProyecto", SqlDbType.VarChar);
            da.SelectCommand.Parameters.Add("@cCodCentroCosto", SqlDbType.VarChar);
            da.SelectCommand.Parameters.Add("@cNumeroOrden", SqlDbType.VarChar);


            da.SelectCommand.Parameters["@cCodCompañia"].Value = strCodCompañia;
            da.SelectCommand.Parameters["@cCodProyecto"].Value = strCodProyecto;
            da.SelectCommand.Parameters["@cCodCentroCosto"].Value = strCodCentroCosto;
            da.SelectCommand.Parameters["@cNumeroOrden"].Value = strNumeroOrden;

            da.SelectCommand.CommandTimeout = 600000000;
            da.Fill(ds);

            return ds;

        }


        public DataSet Lista_Proyecto_IncorporaSaldoAñoAnterior_OS_Clasificador(string strCodCompañia,
                                                                    string strCodClasificador,
                                                                    string strCodCentroCosto,
                                                                    string strNumeroOrden
                                                                  )
        {



            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("Logistica.spp_ins_mvto_SaldoProyecto_OrdenServicio_Clasificador", strConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@cCodCompañia", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodClasificador", SqlDbType.VarChar);
            da.SelectCommand.Parameters.Add("@cCodCentroCosto", SqlDbType.VarChar);
            da.SelectCommand.Parameters.Add("@cNumeroOrden", SqlDbType.VarChar);


            da.SelectCommand.Parameters["@cCodCompañia"].Value = strCodCompañia;
            da.SelectCommand.Parameters["@cCodClasificador"].Value = strCodClasificador;
            da.SelectCommand.Parameters["@cCodCentroCosto"].Value = strCodCentroCosto;
            da.SelectCommand.Parameters["@cNumeroOrden"].Value = strNumeroOrden;

            da.SelectCommand.CommandTimeout = 600000000;
            da.Fill(ds);

            return ds;

        }

        public DataSet Lista_Proyecto_IncorporaSaldoAñoAnterior_OC_Clasificador(string strCodCompañia,
                                                                    string strCodClasificador,
                                                                    string strCodCentroCosto,
                                                                    string strNumeroOrden
                                                                  )
        {



            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("Logistica.spp_ins_mvto_SaldoProyecto_OrdenCompra_Clasificador", strConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@cCodCompañia", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodClasificador", SqlDbType.VarChar);
            da.SelectCommand.Parameters.Add("@cCodCentroCosto", SqlDbType.VarChar);
            da.SelectCommand.Parameters.Add("@cNumeroOrden", SqlDbType.VarChar);


            da.SelectCommand.Parameters["@cCodCompañia"].Value = strCodCompañia;
            da.SelectCommand.Parameters["@cCodClasificador"].Value = strCodClasificador;
            da.SelectCommand.Parameters["@cCodCentroCosto"].Value = strCodCentroCosto;
            da.SelectCommand.Parameters["@cNumeroOrden"].Value = strNumeroOrden;

            da.SelectCommand.CommandTimeout = 600000000;
            da.Fill(ds);

            return ds;

        }

        public DataSet Lista_Conformidad_Pago(string strCodCompañia,
                                string strTipoOrden,
                                string strNumeroOrden
                             )
        {

            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("Logistica.spp_lst_mvto_SeguimientoConformidad_Pagos", strConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@cCodCompañia", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cTipoOrden", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cNumOrden", SqlDbType.Char);


            da.SelectCommand.Parameters["@cCodCompañia"].Value = strCodCompañia;
            da.SelectCommand.Parameters["@cTipoOrden"].Value = strTipoOrden;
            da.SelectCommand.Parameters["@cNumOrden"].Value = strNumeroOrden;

            da.SelectCommand.CommandTimeout = 600000000;
            da.Fill(ds);

            return ds;

        }

        public DataSet Formato_Conformidad(string strCodCompañia,
                        string strNumConformidad,
                        string strTipoOrden,
                        string strNumOrden
                     )
        {



            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("Logistica.spp_frt_mvto_Conformidad", strConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@cCodCompañia", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cNumConformidad", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cTipoOrden", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cNumOrden", SqlDbType.Char);

            da.SelectCommand.Parameters["@cCodCompañia"].Value = strCodCompañia;
            da.SelectCommand.Parameters["@cNumConformidad"].Value = strNumConformidad;
            da.SelectCommand.Parameters["@cTipoOrden"].Value = strTipoOrden;
            da.SelectCommand.Parameters["@cNumOrden"].Value = strNumOrden;

            da.SelectCommand.CommandTimeout = 600000000;
            da.Fill(ds);

            return ds;

        }


        #endregion

    }
}
