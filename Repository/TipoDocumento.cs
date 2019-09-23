using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TipoDocumento
    {
        private readonly string strConnection_Formulacion = "";
        public TipoDocumento()
        {
            Repository.DataAccess DA = new Repository.DataAccess();

            strConnection_Formulacion = DA.ReturnConnectionString_Formulacion();

        }
        public DataSet Combo_TipoDocumento()
        {
            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection_Formulacion, "[Formulacion].[spp_cbo_ctrl_TipoDocumento]"))
            {
                return ds;
            }

        }
    }
}
