using System;
using System.Data;

namespace Service
{
    public class Usuario
    {
        public Model.Usuario Recupera_Usuario(int intIdeUsuario)
        {
            Repository.Usuario obj = new Repository.Usuario();
            return obj.Recupera_Usuario(intIdeUsuario);
        }

        public Model.Usuario Recupera_Usuario_Codigo(string strCodempresa, string strLogUsuario)
        {
            Repository.Usuario obj = new Repository.Usuario();
            return obj.Recupera_Usuario_Codigo(strCodempresa, strLogUsuario);
        }
        public DataSet Combo_Usuario_Modulo_DataTable(string strCodempresa, string strLogUsuario)
        {
            Repository.Usuario obj = new Repository.Usuario();
            return obj.Combo_Usuario_Modulo_DataTable(strCodempresa, strLogUsuario);
        }

        public DataSet OpcionesMenu_Top(string strCodempresa, string strCodUsuario,
                                    string strCodModulo)
        {
            Repository.Usuario obj = new Repository.Usuario();
            return obj.OpcionesMenu_Top(strCodempresa, strCodUsuario, strCodModulo);
        }
        public DataSet OpcionesMenu_Lateral(string strCodempresa, string strCodUsuario,
                                    string strCodModulo)
        {
            Repository.Usuario obj = new Repository.Usuario();
            return obj.OpcionesMenu_Lateral(strCodempresa, strCodUsuario, strCodModulo);
        }

    }
}
