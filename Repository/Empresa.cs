using System;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Repository
{
    public class Empresa
    {
        private readonly string strConnection_Acceso = "";
        public Empresa()
        {
            Repository.DataAccess DA = new Repository.DataAccess();

            strConnection_Acceso = DA.ReturnConnectionString_Acceso();

        }
        public DataSet Combo_Empresa_DataTable()
        {
            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection_Acceso, "Login.spp_cbo_msto_Empresa"))
            {
                return ds;
            }

        }

    }
}
