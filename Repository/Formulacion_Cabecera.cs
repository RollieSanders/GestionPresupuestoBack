using System;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Repository
{
    public class Formulacion_Cabecera
    {
        private string strConnection = "";
        public Formulacion_Cabecera()
        {
            Repository.DataAccess DA = new Repository.DataAccess();
            strConnection = DA.ReturnConnectionString_Formulacion();
        }

        public DataTable Combo_AñoProceso(string strCodCompañia)
        {
            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection, "[Formulacion].[spp_cbo_mvto_AÑoProceso]", strCodCompañia))
            {
                return ds.Tables[0];
            }
        }

        public DataTable Combo_Version(string strAñoProceso)
        {
            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection, "[Formulacion].[spp_cbo_mvto_Version]", strAñoProceso))
            {
                return ds.Tables[0];
            }
        }

        public Model.Formulacion_Cabecera Recupera_FormulacionCabecera(string strAñoProceso)
        {
            DataTable dt; // = new DataTable();
            Model.Formulacion_Cabecera obj = new Model.Formulacion_Cabecera();

    
            dt = SqlHelper.ExecuteDataTable(strConnection, "Formulacion.spp_sel_mvto_Formulacion_Cabecera", strAñoProceso);

            if (dt.Rows.Count == 0)
            {
                obj.IidFormulacion_Cabecera = 0;
                obj.CañoProceso = "";
                obj.Cversion = "";
                obj.DfecFormulacion = DateTime.Today;
                obj.Tnota = "";
                obj.Bactivo = false;
            }
            else
            {
                obj.IidFormulacion_Cabecera = Convert.ToInt32(dt.Rows[0][0]); ;
                obj.CañoProceso = Convert.ToString(dt.Rows[0][1]);
                obj.Cversion = Convert.ToString(dt.Rows[0][2]);
                obj.DfecFormulacion = Convert.ToDateTime(dt.Rows[0][3]);
                obj.Tnota = Convert.ToString(dt.Rows[0][4]);
                obj.Bactivo = Convert.ToBoolean(dt.Rows[0][5]);
            }
            return obj;
        }

        public int Graba_FormulacionCabecera( Model.Formulacion_Cabecera obj )
        {
            int intIdFormulacion_Cabecera = 0;
            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataTable(strConnection, "Formulacion.spp_ins_mvto_Formulacion_Cabecera", 
                                                                                                                obj.CañoProceso,
                                                                                                                obj.Cversion,
                                                                                                                obj.cCodTipoDocumento,
                                                                                                                obj.cNumDocumento,
                                                                                                                obj.Tnota,
                                                                                                                obj.Bactivo
                                                          );
                intIdFormulacion_Cabecera = Convert.ToInt32(dt.Rows[0][0]);
            }
            catch
            {
                intIdFormulacion_Cabecera = 0;
            }
            return intIdFormulacion_Cabecera;
        }

        //Agregado
        public DataSet Lista_FormulacionCabecera(string strAñoProceso)
        {
            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection, "[Formulacion].[spp_lst_mvto_Formulacion_Cabecera]", strAñoProceso))
            {
                return ds;
            }
        }

        public bool elimina_mvto_Formulacion_Cabecera(int intiIdFormulacion_Cabecera) {
            bool blnResultado = true;
            try
            {
                SqlHelper.ExecuteNonQuery(strConnection,
                                          "[Formulacion].[spp_del_mvto_Formulacion_Cabecera]",
                                        intiIdFormulacion_Cabecera
                                       );
            }
            catch (Exception)
            {
                blnResultado = false;
                throw;
            }
            return blnResultado;
        }

        public DataSet Graba_FormulacionCabecera_DataSet(Model.Formulacion_Cabecera obj)
        {
            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection, "Formulacion.spp_ins_mvto_Formulacion_Cabecera",
                                                                                                                obj.CañoProceso,
                                                                                                                obj.Cversion,
                                                                                                                obj.cCodTipoDocumento,
                                                                                                                obj.cNumDocumento,
                                                                                                                obj.Tnota,
                                                                                                                obj.Bactivo)) 
            {
                return ds;
            }
            
        }

        public bool Modifica_mvto_Formulacion_Cabecera(Model.Formulacion_Cabecera obj)
        {
            bool blnResultado = true;
            try
            {
                SqlHelper.ExecuteNonQuery(strConnection,
                                          "[Formulacion].[spp_upd_mvto_Formulacion_Cabecera]", obj.IidFormulacion_Cabecera,
                                                                                                                obj.CañoProceso,
                                                                                                                obj.Cversion,
                                                                                                                obj.cCodTipoDocumento,
                                                                                                                obj.cNumDocumento,
                                                                                                                obj.Tnota,
                                                                                                                obj.Bactivo);
            }
            catch (Exception)
            {
                blnResultado = false;
                throw;
            }
            return blnResultado;
        }

    }
}
