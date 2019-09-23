using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Repository
{
    public class Reporte
    {
        private string strConnection = "";
        public Reporte()
        {
            Repository.DataAccess DA = new Repository.DataAccess();
            strConnection = DA.ReturnConnectionString_Formulacion();
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
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("Formulacion.spp_lst_mvto_Formulacion_Detalle_ResumenClasificador_Gasto", strConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@cCodCompañia", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cAñoProceso", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cVersion", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodFuenteFinanciamiento", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodCentroCosto", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodProyecto", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@iTipoAgrupacion", SqlDbType.Int);

            da.SelectCommand.Parameters["@cCodCompañia"].Value = strCodCompañia;
            da.SelectCommand.Parameters["@cAñoProceso"].Value = strAñoProceso;
            da.SelectCommand.Parameters["@cVersion"].Value = strVersion;
            da.SelectCommand.Parameters["@cCodFuenteFinanciamiento"].Value = strCodFuenteFinanciamiento;
            da.SelectCommand.Parameters["@cCodCentroCosto"].Value = strCodCentroCosto;
            da.SelectCommand.Parameters["@cCodProyecto"].Value = strCodProyecto;
            da.SelectCommand.Parameters["@iTipoAgrupacion"].Value = intTipoAgrupacion;

            da.SelectCommand.CommandTimeout = 600000000;
            da.Fill(ds);

            return ds;

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
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("Formulacion.spp_lst_mvto_Formulacion_Detalle_HojaTrabajo_Gasto", strConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@cCodCompañia", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cAñoProceso", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cVersion", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodFuenteFinanciamiento", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodCentroCosto", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodProyecto", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@iTipoAgrupacion", SqlDbType.Int);

            da.SelectCommand.Parameters["@cCodCompañia"].Value = strCodCompañia;
            da.SelectCommand.Parameters["@cAñoProceso"].Value = strAñoProceso;
            da.SelectCommand.Parameters["@cVersion"].Value = strVersion;
            da.SelectCommand.Parameters["@cCodFuenteFinanciamiento"].Value = strCodFuenteFinanciamiento;
            da.SelectCommand.Parameters["@cCodCentroCosto"].Value = strCodCentroCosto;
            da.SelectCommand.Parameters["@cCodProyecto"].Value = strCodProyecto;
            da.SelectCommand.Parameters["@iTipoAgrupacion"].Value = intTipoAgrupacion;

            da.SelectCommand.CommandTimeout = 600000000;
            da.Fill(ds);

            return ds;

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
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("Formulacion.spp_lst_mvto_Formulacion_Detalle_ResumenClasificador_Ingreso", strConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@cCodCompañia", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cAñoProceso", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cVersion", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodFuenteFinanciamiento", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodCentroCosto", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodProyecto", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@iTipoAgrupacion", SqlDbType.Int);

            da.SelectCommand.Parameters["@cCodCompañia"].Value = strCodCompañia;
            da.SelectCommand.Parameters["@cAñoProceso"].Value = strAñoProceso;
            da.SelectCommand.Parameters["@cVersion"].Value = strVersion;
            da.SelectCommand.Parameters["@cCodFuenteFinanciamiento"].Value = strCodFuenteFinanciamiento;
            da.SelectCommand.Parameters["@cCodCentroCosto"].Value = strCodCentroCosto;
            da.SelectCommand.Parameters["@cCodProyecto"].Value = strCodProyecto;
            da.SelectCommand.Parameters["@iTipoAgrupacion"].Value = intTipoAgrupacion;

            da.SelectCommand.CommandTimeout = 600000000;
            da.Fill(ds);

            return ds;

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
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("Formulacion.spp_lst_mvto_Formulacion_Detalle_HojaTrabajo_Ingreso", strConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@cCodCompañia", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cAñoProceso", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cVersion", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodFuenteFinanciamiento", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodCentroCosto", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodProyecto", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@iTipoAgrupacion", SqlDbType.Int);

            da.SelectCommand.Parameters["@cCodCompañia"].Value = strCodCompañia;
            da.SelectCommand.Parameters["@cAñoProceso"].Value = strAñoProceso;
            da.SelectCommand.Parameters["@cVersion"].Value = strVersion;
            da.SelectCommand.Parameters["@cCodFuenteFinanciamiento"].Value = strCodFuenteFinanciamiento;
            da.SelectCommand.Parameters["@cCodCentroCosto"].Value = strCodCentroCosto;
            da.SelectCommand.Parameters["@cCodProyecto"].Value = strCodProyecto;
            da.SelectCommand.Parameters["@iTipoAgrupacion"].Value = intTipoAgrupacion;

            da.SelectCommand.CommandTimeout = 600000000;
            da.Fill(ds);

            return ds;

        }


        public DataSet Lista_FormulacionReporteProyecto(string cCodCompañia, string strAñoProceso, string strVersion,  string cCodTipoFormulacion, string cCodProyecto)
        {
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("Formulacion.spp_sel_mvto_Formulacion_Detalle_Proyecto_cod_proyecto", strConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@cCodCompañia", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cAñoProceso", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cVersion", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodTipoFormulacion", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodProyecto", SqlDbType.Char);

            da.SelectCommand.Parameters["@cCodCompañia"].Value = cCodCompañia;
            da.SelectCommand.Parameters["@cAñoProceso"].Value = strAñoProceso;
            da.SelectCommand.Parameters["@cVersion"].Value = strVersion;
            da.SelectCommand.Parameters["@cCodTipoFormulacion"].Value = cCodTipoFormulacion;
            da.SelectCommand.Parameters["@cCodProyecto"].Value = cCodProyecto;

            da.SelectCommand.CommandTimeout = 600000000;
            da.Fill(ds);

            return ds;
        }

        public DataSet Lista_FormulacionReporteProyecto_CentroCosto(string cCodCompañia, 
                                                                    string cCodTipoFormulacion, 
                                                                    string cCodProyecto,
                                                                    string cCodCentroCosto_Gestor
            )
        {
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("Formulacion.spp_lst_mvto_Formulacion_Detalle_Proyecto_CentroCosto", strConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@cCodCompañia", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodTipoFormulacion", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodProyecto", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodCentroCosto", SqlDbType.Char);

            da.SelectCommand.Parameters["@cCodCompañia"].Value = cCodCompañia;
            da.SelectCommand.Parameters["@cCodTipoFormulacion"].Value = cCodTipoFormulacion;
            da.SelectCommand.Parameters["@cCodProyecto"].Value = cCodProyecto;
            da.SelectCommand.Parameters["@cCodCentroCosto"].Value = cCodCentroCosto_Gestor;

            da.SelectCommand.CommandTimeout = 600000000;
            da.Fill(ds);

            return ds;
        }


        public DataSet Lista_FormulacionReporteContrato(string cCodCompañia, string cNumeroOrden, string cTipoOrden)
        {
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("Formulacion.spp_sel_mvto_Formulacion_Detalle_Proyecto_cod_proyecto", strConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@cCodCompañia", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cNumeroOrden", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cTipoOrden", SqlDbType.Char);
            da.SelectCommand.Parameters["@cCodCompañia"].Value = cCodCompañia;
            da.SelectCommand.Parameters["@cNumeroOrden"].Value = cNumeroOrden;
            da.SelectCommand.Parameters["@cTipoOrden"].Value = cTipoOrden;

            da.SelectCommand.CommandTimeout = 600000000;
            da.Fill(ds);

            return ds;
        }
        

        public DataSet Help_FormulacionTipoFormulacion()
        {
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("Formulacion.spp_help_tipo_Formulacion", strConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.CommandTimeout = 600000000;
            da.Fill(ds);

            return ds;
        }

        public DataSet Lista_FormulacionReporteProyecto_Ceco(string cCodCompañia, string strAñoProceso, string strVersion, string cCodTipoFormulacion, string CodCentroCosto)
        {
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("Formulacion.spp_sel_mvto_Formulacion_Detalle_Proyecto_cod_proyecto_ceco", strConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@cCodCompañia", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cAñoProceso", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cVersion", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodTipoFormulacion", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@CodCentroCosto", SqlDbType.Char);

            da.SelectCommand.Parameters["@cCodCompañia"].Value = cCodCompañia;
            da.SelectCommand.Parameters["@cAñoProceso"].Value = strAñoProceso;
            da.SelectCommand.Parameters["@cVersion"].Value = strVersion;
            da.SelectCommand.Parameters["@cCodTipoFormulacion"].Value = cCodTipoFormulacion;
            da.SelectCommand.Parameters["@CodCentroCosto"].Value = CodCentroCosto;

            da.SelectCommand.CommandTimeout = 600000000;
            da.Fill(ds);

            return ds;

        }

        public DataSet Formato_4P(string strCodCompañia, 
                                  string strAñoProceso, 
                                  string strVersion,
                                  string strCodFuenteFinanciamiento,
                                  string strCodCentroCosto,
                                  string strCodProyecto
                                )
        {
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("Formulacion.spp_lst_mvto_Formulacion_Detalle_Formato4P", strConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@cCodCompañia", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cAñoProceso", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cVersion", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodFuenteFinanciamiento", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodCentroCosto", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodProyecto", SqlDbType.Char);

            da.SelectCommand.Parameters["@cCodCompañia"].Value = strCodCompañia;
            da.SelectCommand.Parameters["@cAñoProceso"].Value = strAñoProceso;
            da.SelectCommand.Parameters["@cVersion"].Value = strVersion;
            da.SelectCommand.Parameters["@cCodFuenteFinanciamiento"].Value = strCodFuenteFinanciamiento;
            da.SelectCommand.Parameters["@cCodCentroCosto"].Value = strCodCentroCosto;
            da.SelectCommand.Parameters["@cCodProyecto"].Value = strCodProyecto;

            da.SelectCommand.CommandTimeout = 600000000;
            da.Fill(ds);

            return ds;

        }

        public DataSet Reporte_Detalle_Formulacion(string strCodCompañia,
                                  string strAñoProceso,
                                  string strVersion,
                                  string strCodFuenteFinanciamiento,
                                  string strCodCentroCosto,
                                  string strCodProyecto
                                )
        {
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("Formulacion.spp_rpt_mvto_Formulacion_Detalle", strConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@cCodCompañia", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cAñoProceso", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cVersion", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodFuenteFinanciamiento", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodCentroCosto", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodProyecto", SqlDbType.Char);

            da.SelectCommand.Parameters["@cCodCompañia"].Value = strCodCompañia;
            da.SelectCommand.Parameters["@cAñoProceso"].Value = strAñoProceso;
            da.SelectCommand.Parameters["@cVersion"].Value = strVersion;
            da.SelectCommand.Parameters["@cCodFuenteFinanciamiento"].Value = strCodFuenteFinanciamiento;
            da.SelectCommand.Parameters["@cCodCentroCosto"].Value = strCodCentroCosto;
            da.SelectCommand.Parameters["@cCodProyecto"].Value = strCodProyecto;

            da.SelectCommand.CommandTimeout = 600000000;
            da.Fill(ds);

            return ds;

        }

        public DataSet Lista_FormulacionReporteProyecto_Saldo(string cCodCompañia)
        {
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("Logistica.spp_lst_mvto_SaldoProyecto_NoIncluidosEnConfiguracion", strConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@cCodCompañia", SqlDbType.Char);


            da.SelectCommand.Parameters["@cCodCompañia"].Value = cCodCompañia;

            da.SelectCommand.CommandTimeout = 600000000;
            da.Fill(ds);

            return ds;

        }
    }
}
