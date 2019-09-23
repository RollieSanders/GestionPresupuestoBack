using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Formulacion_Cabecera_Ceco
    {
        private string strConnection = "";
        public Formulacion_Cabecera_Ceco()
        {
            Repository.DataAccess DA = new Repository.DataAccess();
            strConnection = DA.ReturnConnectionString_Formulacion();
        }

        public bool Graba_mvto_Formulacion_Cabecera_Ceco(Model.Formulacion_Cabecera_Ceco obj)
        {
            bool blnResultado = true;
            try
            {
                SqlHelper.ExecuteNonQuery(strConnection,
                                          "[Formulacion].[spp_ins_mvto_Formulacion_Cabecera_Ceco]", 
                                                                                                                obj.CañoProceso,
                                                                                                                obj.Cversion,
                                                                                                                obj.cCodCeco,
                                                                                                                obj.Tnota,
                                                                                                                obj.DfecFormulacion,
                                                                                                                obj.cUsuarioCierre);
            }
            catch (Exception)
            {
                blnResultado = false;
                throw;
            }
            return blnResultado;
        }

        public DataSet Lista_FormulacionCabecera_Ceco(string strAñoProceso, string strCeco, int digito)
        {
            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection, "[Formulacion].[spp_lst_mvto_Formulacion_Cabecera_Ceco]", strAñoProceso, strCeco, digito))
            {
                return ds;
            }
        }
        public Model.Formulacion_Cabecera_Ceco Recupera_FormulacionCabecera_CeCo(string strAñoProceso,
                                                                            string strVersion,
                                                                            string strCodCentroCosto
                                                                           )
        {
            DataTable dt; // = new DataTable();
            Model.Formulacion_Cabecera_Ceco obj = new Model.Formulacion_Cabecera_Ceco();

            dt = SqlHelper.ExecuteDataTable(strConnection, "Formulacion.spp_sel_mvto_Formulacion_Cabecera_CeCo", strAñoProceso,
                                                                                                                 strVersion,
                                                                                                                 strCodCentroCosto
                                           );

            if (dt.Rows.Count == 0)
            {

                obj.IidFormulacion_Cabecera_Ceco = 0;
                obj.CañoProceso = "";
                obj.Cversion = "";
                obj.DfecFormulacion = DateTime.Today;
                obj.Tnota = "";
                obj.cCodCeco = "";
            }
            else
            {
                obj.IidFormulacion_Cabecera_Ceco = Convert.ToInt32(dt.Rows[0][0]); ;
                obj.CañoProceso = Convert.ToString(dt.Rows[0][1]);
                obj.Cversion = Convert.ToString(dt.Rows[0][2]);
                obj.DfecFormulacion = Convert.ToDateTime(dt.Rows[0][3]);
                obj.Tnota = Convert.ToString(dt.Rows[0][4]);
                obj.cCodCeco = Convert.ToString(dt.Rows[0][5]);
            }
            return obj;
        }
        public DataSet Lista_Formulacion_Aprobacion_Ceco(string strAñoProceso, string strCeGe,string strVersion, int digito)
        {
            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection, "[Formulacion].[spp_lst_mvto_Formulacion_Aprobacion_Ceco]", strAñoProceso, strCeGe,strVersion, digito))
            {
                return ds;
            }
        }

        public DataSet Lista_Version(string strAñoProceso)
        {
            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection, "[Formulacion].[spp_lst_mvto_Formulacion_Version]", strAñoProceso))
            {
                return ds;
            }
        }
    }
}
