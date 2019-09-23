using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Repository
{
    public class Formulacion_Detalle_Proyecto
    {
        private string strConnection = "";
        public Formulacion_Detalle_Proyecto()
        {
            Repository.DataAccess DA = new Repository.DataAccess();
            strConnection = DA.ReturnConnectionString_Formulacion();
        }

        public Boolean Elimina_FormulacionDetalle_Proyecto(int intIdFormulacion_Detalle_Proyecto )
        {

            Boolean blnResult = false;

            try
            {
                SqlHelper.ExecuteNonQuery(strConnection, "Formulacion.spp_del_mvto_Formulacion_Detalle_Proyecto", 
                                                intIdFormulacion_Detalle_Proyecto
                                                );
                blnResult = true;
            }
            catch
            {
                blnResult = false;
            }
            return blnResult;
        }


        public int Graba_FormulacionDetalle_Proyecto(Model.Formulacion_Detalle_Proyecto obj)
        {
            int intIdFormulacion_Detalle_Proyecto = 0;
            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataTable(strConnection, "Formulacion.spp_ins_mvto_Formulacion_Detalle_Proyecto", obj.IidFormulacion_Detalle,
                                                                                                                        obj.CañoProceso,
                                                                                                                        obj.Cversion,
                                                                                                                        obj.CcodCeCo,
                                                                                                                        obj.CcodCeCo_Gestor,
                                                                                                                        obj.CcodPosPre,
                                                                                                                        obj.CTipoOrden,
                                                                                                                        obj.CNumeroOrden,
                                                                                                                        obj.CcodFuenteFinanciamiento,
                                                                                                                        obj.CcodComponente,
                                                                                                                        obj.CcodTipoFormulacion,
                                                                                                                        obj.CcodProyecto,
                                                                                                                        obj.CcodClaseGasto,
                                                                                                                        obj.TdescripcionGasto,
                                                                                                                        obj.IcodTipoInserccion,
                                                                                                                        obj.FvalorAnterior,
                                                                                                                        obj.FvalorRestoActual,
                                                                                                                        obj.Fmes_01,
                                                                                                                        obj.Fmes_02,
                                                                                                                        obj.Fmes_03,
                                                                                                                        obj.Fmes_04,
                                                                                                                        obj.Fmes_05,
                                                                                                                        obj.Fmes_06,
                                                                                                                        obj.Fmes_07,
                                                                                                                        obj.Fmes_08,
                                                                                                                        obj.Fmes_09,
                                                                                                                        obj.Fmes_10,
                                                                                                                        obj.Fmes_11,
                                                                                                                        obj.Fmes_12,
                                                                                                                        obj.FvalorFormulacion,
                                                                                                                        obj.FvalorFormulacionUno,
                                                                                                                        obj.FvalorFormulacionDos,
                                                                                                                        obj.Cusuario
                                                );
                intIdFormulacion_Detalle_Proyecto = Convert.ToInt32(dt.Rows[0][0]);
            }
            catch
            {
                intIdFormulacion_Detalle_Proyecto = 0;
            }
            return intIdFormulacion_Detalle_Proyecto;
        }

        public int Modifica_FormulacionDetalle_Proyecto(Model.Formulacion_Detalle_Proyecto obj)
        {
            int intIdFormulacion_Detalle_Proyecto = obj.IidFormulacion_Detalle_Proyecto;
            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataTable(strConnection, "Formulacion.spp_upd_mvto_Formulacion_Detalle_Proyecto", obj.IidFormulacion_Detalle_Proyecto,
                                                                                                                        obj.CañoProceso,
                                                                                                                        obj.Cversion,
                                                                                                                        obj.CcodCeCo,
                                                                                                                        obj.CcodCeCo_Gestor,
                                                                                                                        obj.CcodPosPre,
                                                                                                                        obj.CTipoOrden,
                                                                                                                        obj.CNumeroOrden,
                                                                                                                        obj.CcodFuenteFinanciamiento,
                                                                                                                        obj.CcodComponente,
                                                                                                                        obj.CcodTipoFormulacion,
                                                                                                                        obj.CcodProyecto,
                                                                                                                        obj.CcodClaseGasto,
                                                                                                                        obj.TdescripcionGasto,
                                                                                                                        obj.IcodTipoInserccion,
                                                                                                                        obj.FvalorAnterior,
                                                                                                                        obj.FvalorRestoActual,
                                                                                                                        obj.Fmes_01,
                                                                                                                        obj.Fmes_02,
                                                                                                                        obj.Fmes_03,
                                                                                                                        obj.Fmes_04,
                                                                                                                        obj.Fmes_05,
                                                                                                                        obj.Fmes_06,
                                                                                                                        obj.Fmes_07,
                                                                                                                        obj.Fmes_08,
                                                                                                                        obj.Fmes_09,
                                                                                                                        obj.Fmes_10,
                                                                                                                        obj.Fmes_11,
                                                                                                                        obj.Fmes_12,
                                                                                                                        obj.FvalorFormulacion,
                                                                                                                        obj.FvalorFormulacionUno,
                                                                                                                        obj.FvalorFormulacionDos,
                                                                                                                        obj.Cusuario
                                                );
            }
            catch
            {
                intIdFormulacion_Detalle_Proyecto = 0;
            }
            return intIdFormulacion_Detalle_Proyecto;
        }


        public DataSet Lista_FormulacionDetalle_Proyecto(string strCodCompañia,
                                                         string strCodProyecto,
                                                         string strCodCentroCosto,
                                                         string strCodTipoFormulacion
                                        )
        {



            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("Formulacion.spp_lst_mvto_Formulacion_Detalle_Proyecto", strConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@cCodCompañia", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodProyecto", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodCentroCosto", SqlDbType.VarChar);
            da.SelectCommand.Parameters.Add("@cCodTipoFormulacion", SqlDbType.VarChar);

            da.SelectCommand.Parameters["@cCodCompañia"].Value = strCodCompañia;
            da.SelectCommand.Parameters["@cCodProyecto"].Value = strCodProyecto;
            da.SelectCommand.Parameters["@cCodCentroCosto"].Value = strCodCentroCosto;
            da.SelectCommand.Parameters["@cCodTipoFormulacion"].Value = strCodTipoFormulacion;

            da.SelectCommand.CommandTimeout = 600000000;
            da.Fill(ds);

            return ds;

        }


        public DataSet Lista_FormulacionDetalle_Proyecto_Otros(string strCodCompañia,
                                                         string strCodCentroCosto,
                                                         string strCodTipoFormulacion
                                        )
        {



            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("Formulacion.spp_lst_mvto_Formulacion_Detalle_Proyecto_Otros", strConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@cCodCompañia", SqlDbType.Char);
            da.SelectCommand.Parameters.Add("@cCodCentroCosto", SqlDbType.VarChar);
            da.SelectCommand.Parameters.Add("@cCodTipoFormulacion", SqlDbType.VarChar);

            da.SelectCommand.Parameters["@cCodCompañia"].Value = strCodCompañia;
            da.SelectCommand.Parameters["@cCodCentroCosto"].Value = strCodCentroCosto;
            da.SelectCommand.Parameters["@cCodTipoFormulacion"].Value = strCodTipoFormulacion;

            da.SelectCommand.CommandTimeout = 600000000;
            da.Fill(ds);

            return ds;

        }


    }
}
