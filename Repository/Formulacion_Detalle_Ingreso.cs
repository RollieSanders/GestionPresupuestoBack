using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Formulacion_Detalle_Ingreso
    {
        private string strConnection = "";
        public Formulacion_Detalle_Ingreso()
        {
            Repository.DataAccess DA = new Repository.DataAccess();
            strConnection = DA.ReturnConnectionString_Formulacion();
        }

        public Boolean Elimina_FormulacionDetalle_Ingreso(int intIdFormulacion_Detalle_Proyecto)
        {

            Boolean blnResult = false;

            try
            {
                SqlHelper.ExecuteNonQuery(strConnection, "Formulacion.spp_del_mvto_Formulacion_Detalle_Ingreso",
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


        public int Graba_FormulacionDetalle_Ingreso(Model.Formulacion_Detalle_Ingreso obj)
        {
            int intIdFormulacion_Detalle_Ingreso = 0;
            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataTable(strConnection, "Formulacion.spp_ins_mvto_Formulacion_Detalle_Ingreso", obj.IidFormulacion_Detalle,
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
                                                                                                                        obj.CcodClaseIngreso,
                                                                                                                        obj.TdescripcionIngreso,
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
                intIdFormulacion_Detalle_Ingreso = Convert.ToInt32(dt.Rows[0][0]);
            }
            catch
            {
                intIdFormulacion_Detalle_Ingreso = 0;
            }
            return intIdFormulacion_Detalle_Ingreso;
        }

        public int Modifica_FormulacionDetalle_Ingreso(Model.Formulacion_Detalle_Ingreso obj)
        {
            int intIdFormulacion_Detalle_Ingreso = obj.IidFormulacion_Detalle_Ingreso;
            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataTable(strConnection, "Formulacion.spp_upd_mvto_Formulacion_Detalle_Ingreso", obj.IidFormulacion_Detalle_Ingreso,
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
                                                                                                                        obj.CcodClaseIngreso,
                                                                                                                        obj.TdescripcionIngreso,
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
                intIdFormulacion_Detalle_Ingreso = 0;
            }
            return intIdFormulacion_Detalle_Ingreso;
        }


        public DataSet Lista_FormulacionDetalle_Ingreso(string strCodCompañia,
                                                         string strCodProyecto,
                                                         string strCodCentroCosto,
                                                         string strCodTipoFormulacion
                                        )
        {



            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("Formulacion.spp_lst_mvto_Formulacion_Detalle_Ingreso", strConnection);
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


    }
}
