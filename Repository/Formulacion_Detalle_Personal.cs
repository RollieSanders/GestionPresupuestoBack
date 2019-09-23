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
    public class Formulacion_Detalle_Personal
    {
        private string strConnection = "";
        public Formulacion_Detalle_Personal()
        {
            Repository.DataAccess DA = new Repository.DataAccess();
            strConnection = DA.ReturnConnectionString_Formulacion();
        }

        public Boolean Elimina_FormulacionDetalle_Personal(int intIdFormulacion_Detalle_Proyecto)
        {

            Boolean blnResult = false;

            try
            {
                SqlHelper.ExecuteNonQuery(strConnection, "Formulacion.spp_del_mvto_Formulacion_Detalle_Personal",
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


        public int Graba_FormulacionDetalle_Personal(Model.Formulacion_Detalle_Personal obj)
        {
            int intIdFormulacion_Detalle_Personal = 0;
            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataTable(strConnection, "Formulacion.spp_ins_mvto_Formulacion_Detalle_Personal", obj.IidFormulacion_Detalle,
                                                                                                                        obj.CañoProceso,
                                                                                                                        obj.Cversion,
                                                                                                                        obj.CcodCeCo,
                                                                                                                        obj.CcodCeCo_Gestor,
                                                                                                                        obj.CcodPosPre,
                                                                                                                        obj.CTipoOrden,
                                                                                                                        obj.CNumeroOrden,
                                                                                                                        obj.CcodFuenteFinanciamiento,
                                                                                                                        obj.CcodConcepto,
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
                intIdFormulacion_Detalle_Personal = Convert.ToInt32(dt.Rows[0][0]);
            }
            catch
            {
                intIdFormulacion_Detalle_Personal = 0;
            }
            return intIdFormulacion_Detalle_Personal;
        }

        public int Modifica_FormulacionDetalle_Personal(Model.Formulacion_Detalle_Personal obj)
        {
            int intIdFormulacion_Detalle_Personal = obj.IidFormulacion_Detalle_Personal;
            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataTable(strConnection, "Formulacion.spp_upd_mvto_Formulacion_Detalle_Personal", obj.IidFormulacion_Detalle_Personal,
                                                                                                                        obj.CañoProceso,
                                                                                                                        obj.Cversion,
                                                                                                                        obj.CcodCeCo,
                                                                                                                        obj.CcodCeCo_Gestor,
                                                                                                                        obj.CcodPosPre,
                                                                                                                        obj.CTipoOrden,
                                                                                                                        obj.CNumeroOrden,
                                                                                                                        obj.CcodFuenteFinanciamiento,
                                                                                                                        obj.CcodConcepto,
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
                intIdFormulacion_Detalle_Personal = 0;
            }
            return intIdFormulacion_Detalle_Personal;
        }


        public DataSet Lista_FormulacionDetalle_Personal(string strCodCompañia,
                                                         string strCodCentroCosto,
                                                         string strCodTipoFormulacion
                                        )
        {



            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("Formulacion.spp_lst_mvto_Formulacion_Detalle_Personal", strConnection);
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
