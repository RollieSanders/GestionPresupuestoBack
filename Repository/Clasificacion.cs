using System;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Repository
{
    public class Clasificacion
    {
        private readonly string strConnection = "";
        public Clasificacion()
        {
            Repository.DataAccess DA = new Repository.DataAccess();
            strConnection = DA.ReturnConnectionString_Formulacion();
        }
        public DataSet Ayuda_Clasificacion()
        {

            DataSet ds = new DataSet();

            ds = SqlHelper.ExecuteDataset(strConnection,
                                      "Formulacion.spp_help_msto_Clasificacion"
                                     );

            return ds;
        }

        public DataSet Ayuda_Clasificacion_Formulacion(string strAñoProceso)
        {

            DataSet ds = new DataSet();

            ds = SqlHelper.ExecuteDataset(strConnection,
                                      "Formulacion.spp_help_msto_Clasificacion_Formulacion", strAñoProceso
                                     );

            return ds;
        }
    }
}
