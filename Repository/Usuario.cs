using System;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Repository
{
    public class Usuario
    {
        private readonly string strConnection_Acceso = "";
        public Usuario()
        {
            Repository.DataAccess DA = new Repository.DataAccess();
            strConnection_Acceso = DA.ReturnConnectionString_Acceso();
        }
        public Model.Usuario Recupera_Usuario(int intIdeUsuario)
        {
            DataTable dt = new DataTable();
            Model.Usuario obj = new Model.Usuario();

            using (dt = SqlHelper.ExecuteDataTable(strConnection_Acceso, "Login.spp_Sel_Cnfg_Usuario", intIdeUsuario))
            {
                if (dt.Rows.Count == 0)
                {
                    obj.iIdUsuario = 0;
                    obj.vLogUsuario = "";
                    obj.tClaUsuario = "";
                    obj.tPasUsuario = "";
                    obj.tVecUsuario = "";
                    obj.cCodTipoEmpleado = "";
                    obj.cCodEmpleado = "";
                    obj.vDesEmpleado = "";
                    obj.bEstado = false;
                }
                else
                {
                    obj.iIdUsuario = Convert.ToInt32(dt.Rows[0][0]);
                    obj.vLogUsuario = Convert.ToString(dt.Rows[0][1]);
                    obj.tClaUsuario = Convert.ToString(dt.Rows[0][2]);
                    obj.tPasUsuario = Convert.ToString(dt.Rows[0][3]);
                    obj.tVecUsuario = Convert.ToString(dt.Rows[0][4]);
                    obj.cCodTipoEmpleado = Convert.ToString(dt.Rows[0][5]);
                    obj.cCodEmpleado = Convert.ToString(dt.Rows[0][6]);
                    obj.vDesEmpleado = Convert.ToString(dt.Rows[0][7]);
                    obj.bEstado = Convert.ToBoolean(dt.Rows[0][8]);
                }
            }
            return obj;
        }

        public Model.Usuario Recupera_Usuario_Codigo(string strCodEmpresa,
                                                         string strLogUsuario)
        {
            DataTable dt = new DataTable();
            Model.Usuario obj = new Model.Usuario();

            using (dt = SqlHelper.ExecuteDataTable(strConnection_Acceso, "Login.spp_Sel_Cnfg_Usuario_Codigo", strCodEmpresa, strLogUsuario))
            {
                if (dt.Rows.Count == 0)
                {
                    obj.iIdUsuario = 0;
                    obj.vLogUsuario = "";
                    obj.tClaUsuario = "";
                    obj.tPasUsuario = "";
                    obj.tVecUsuario = "";
                    obj.cCodTipoEmpleado = "";
                    obj.cCodEmpleado = "";
                    obj.vDesEmpleado = "";
                    obj.bEstado = false;
                }
                else
                {
                    obj.iIdUsuario = Convert.ToInt32(dt.Rows[0][0]);
                    obj.vLogUsuario = Convert.ToString(dt.Rows[0][1]);
                    obj.tClaUsuario = Convert.ToString(dt.Rows[0][2]);
                    obj.tPasUsuario = Convert.ToString(dt.Rows[0][3]);
                    obj.tVecUsuario = Convert.ToString(dt.Rows[0][4]);
                    obj.cCodTipoEmpleado = Convert.ToString(dt.Rows[0][5]);
                    obj.cCodEmpleado = Convert.ToString(dt.Rows[0][6]);
                    obj.vDesEmpleado = Convert.ToString(dt.Rows[0][7]);
                    obj.bEstado = Convert.ToBoolean(dt.Rows[0][8]);
                }
            }


            return obj;

        }

        public DataSet Combo_Usuario_Modulo_DataTable(string strCodEmpresa, string strLogUsuario)
        {
            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection_Acceso, "Login.spp_Cbo_Cnfg_Usuario_Modulo", strCodEmpresa, strLogUsuario))
            {
                return ds;
            }

        }

        public DataSet OpcionesMenu_Top(string strCodEmpresa,
                                    string strCodUsuario,
                                    string strCodModulo)
        {
            DataSet ds = new DataSet();

            using (ds = SqlHelper.ExecuteDataset(strConnection_Acceso,
                                "Login.spp_lst_cnfg_Usuario_Opcion_Menu_Top",
                                strCodEmpresa,
                                strCodUsuario,
                                strCodModulo
                             ))
            {
                return ds;
            }


        }

        public DataSet OpcionesMenu_Lateral(string strCodEmpresa,
                                    string strCodUsuario,
                                    string strCodModulo)
        {
            DataSet ds = new DataSet();

            using (ds = SqlHelper.ExecuteDataset(strConnection_Acceso,
                                                "Login.spp_lst_cnfg_Usuario_Opcion_Menu_Left",
                                                strCodEmpresa,
                                                strCodUsuario,
                                                strCodModulo
                                             ))
            {
                return ds;
            }


        }

    }
}
