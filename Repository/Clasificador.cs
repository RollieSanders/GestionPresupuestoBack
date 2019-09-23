using System;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Repository
{
    public class Clasificador
    {
        private readonly string strConnection_Formulacion = "";
        public Clasificador()
        {
            Repository.DataAccess DA = new Repository.DataAccess();

            strConnection_Formulacion = DA.ReturnConnectionString_Formulacion();

        }
        public DataSet Ayuda_Clasificador(string strCodCompañia, string strCodClasificador, string strCodCentroCosto)
        {
            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection_Formulacion, "Formulacion.spp_help_mvto_Clasificador_Gasto", strCodCompañia, strCodClasificador, strCodCentroCosto))
            {
                return ds;
            }

        }
        public DataSet Ayuda_Clasificador_Inversion(string strCodCompañia, string strCodProyecto, string strCodClasificador, string strCodCentroCosto )
        {
            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection_Formulacion, "Formulacion.spp_help_mvto_Clasificador_Gasto_Inversion", strCodCompañia, strCodProyecto, strCodClasificador, strCodCentroCosto))
            {
                return ds;
            }

        }

        public DataSet Ayuda_Clasificador_Otro(string strCodCompañia, string strCodClasificador, string strCodCentroCosto)
        {
            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection_Formulacion, "Formulacion.spp_help_mvto_Clasificador_Gasto_Otro", strCodCompañia, strCodClasificador, strCodCentroCosto))
            {
                return ds;
            }

        }

        public DataSet Ayuda_Clasificador_Tarea(string strCodCompañia, string strCodProyecto, string strCodClasificador, string strCodCentroCosto)
        {
            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection_Formulacion, "Formulacion.spp_help_mvto_Clasificador_Gasto_Tarea", strCodCompañia, strCodProyecto, strCodClasificador, strCodCentroCosto))
            {
                return ds;
            }

        }

        public DataSet Ayuda_Clasificador_Ingreso(string strCodCompañia, string strCodCentroCosto)
        {
            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection_Formulacion, "Formulacion.spp_help_mvto_Clasificador_Ingreso", strCodCompañia, strCodCentroCosto))
            {
                return ds;
            }

        }

    }
}
