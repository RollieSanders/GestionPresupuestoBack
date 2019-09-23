using System;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Repository
{
    public class PeriodoProceso
    {
        private readonly string strConnection = "";
        public PeriodoProceso()
        {
            Repository.DataAccess DA = new Repository.DataAccess();
            strConnection = DA.ReturnConnectionString_Formulacion();

        }


        public DataSet Combo_PeriodoProceso_DataTable()
        {
            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection, "Contabilidad.spp_cbo_ctrl_PeriodoProceso"))
            {
                return ds;
            }

        }
    }
}
