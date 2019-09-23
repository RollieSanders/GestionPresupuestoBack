using System;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Repository
{
    public class PosicionPresupuestal
    {
        private readonly string strConnection = "";
        public PosicionPresupuestal()
        {
            Repository.DataAccess DA = new Repository.DataAccess();
            strConnection = DA.ReturnConnectionString_Formulacion();
        }
        public DataSet Ayuda_PosicionPresupuestal()
        {

            DataSet ds = new DataSet();

            ds = SqlHelper.ExecuteDataset(strConnection,
                                      "Formulacion.spp_help_msto_PosicionPresupuestal"
                                     );

            return ds;
        }

        public DataSet Ayuda_PosicionPresupuestal_Formulacion( string strAñoProceso )
        {

            DataSet ds = new DataSet();

            ds = SqlHelper.ExecuteDataset(strConnection,
                                      "Formulacion.spp_help_msto_PosicionPresupuestal_Formulacion", strAñoProceso
                                     );

            return ds;
        }


        public Model.PosicionPresupuestal Recupera_PosicionPresupuestal(string strCodPosPre )
        {
            DataTable dt = new DataTable();
            Model.PosicionPresupuestal obj = new Model.PosicionPresupuestal();

            dt = SqlHelper.ExecuteDataTable(strConnection, "Formulacion.spp_sel_msto_PosicionPresupuestal_Codigo", strCodPosPre);

            if (dt.Rows.Count == 0)
            {
                obj.IidPosPre = 0;
                obj.CcodPosPre = "";
                obj.VnomPosPre = "";
                obj.CcodTipoAdquisicion = "";
            }
            else
            {
                obj.IidPosPre = Convert.ToInt32(dt.Rows[0][0]);
                obj.CcodPosPre = Convert.ToString(dt.Rows[0][1]);
                obj.VnomPosPre = Convert.ToString(dt.Rows[0][2]);
                obj.CcodTipoAdquisicion = Convert.ToString(dt.Rows[0][3]);
            }

            return obj;

        }

        public int Graba_PosicionPresupuestal( Model.PosicionPresupuestal obj )
        {
            int intIdPosPre = 0;
            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataTable(strConnection, "Formulacion.spp_ins_msto_PosicionPresupuestal", obj.CcodPosPre,
                                                                                                                        obj.VnomPosPre,
                                                                                                                        obj.CcodTipoAdquisicion
                                                          );
                intIdPosPre = Convert.ToInt32(dt.Rows[0][0]);
            }
            catch
            {
                intIdPosPre = 0;
            }
            return intIdPosPre;
        }

        public int Modifica_PosicionPresupuestal(Model.PosicionPresupuestal obj)
        {
            int intIdPosPre = 0;

            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataTable(strConnection, "Formulacion.spp_upd_msto_PosicionPresupuestal", obj.IidPosPre,
                                                                                                                obj.CcodPosPre,
                                                                                                                obj.VnomPosPre,
                                                                                                                obj.CcodTipoAdquisicion
                                                          );
                intIdPosPre = obj.IidPosPre;
            }
            catch
            {
                intIdPosPre = 0;
            }
            return intIdPosPre;
        }

        public int Elimina_PosicionPresupuestal( int intIdPosPre  )
        {
            int intResultado = 0;

            try
            {
                intResultado = Convert.ToInt32(SqlHelper.ExecuteScalar( strConnection, "Formulacion.spp_del_msto_PosicionPresupuestal", intIdPosPre ));

            }
            catch
            {
                intResultado = 0;
            }
            return intResultado;
        }


    }
}
