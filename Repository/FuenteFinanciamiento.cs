using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class FuenteFinanciamiento
    {
        private string strConnection_Formulacion = "";
        public FuenteFinanciamiento()
        {
            Repository.DataAccess DA = new Repository.DataAccess();
            strConnection_Formulacion = DA.ReturnConnectionString_Formulacion();
        }

        public DataSet Lista_Proyecto_FuenteFinanciamiento_x_Elegir(string strCodCompañia,
                                                        string strCodProyecto

                             )
        {
            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection_Formulacion, "Formulacion.spp_Lista_FuenteFinanciamiento_Proyecto_x_Elegir", strCodCompañia, strCodProyecto))
            {
                return ds;
            }
        }

        public DataSet Lista_Proyecto_FuenteFinanciamiento_Elegidos(string strCodCompañia,
                                                        string strCodProyecto

                             )
        {
            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection_Formulacion, "Formulacion.spp_Lista_FuenteFinanciamiento_Proyecto_Elegidos", strCodCompañia, strCodProyecto))
            {
                return ds;
            }
        }

        public int Graba_Proyecto_FuenteFinanciamiento(string strCodProyecto, string strCodFuenteFinanciamiento)
        {
            int intIdProyecto_FuenteFinanciamiento = 0;
            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataTable(strConnection_Formulacion, "[Formulacion].[spp_ins_mvto_FuenteFinanciamiento_Proyecto]", strCodProyecto
                                                                                                                           , strCodFuenteFinanciamiento
                                                          );
                intIdProyecto_FuenteFinanciamiento = Convert.ToInt32(dt.Rows[0][0]);
            }
            catch
            {
                intIdProyecto_FuenteFinanciamiento = 0;
            }
            return intIdProyecto_FuenteFinanciamiento;
        }

        public int Elimina_Proyecto_FuenteFinanciamiento(string strCodProyecto, string strCodFuenteFinanciamiento)
        {
            int resultado = 0;

            try
            {
                resultado = Convert.ToInt32(SqlHelper.ExecuteScalar(strConnection_Formulacion, "[Formulacion].[spp_del_mvto_FuenteFinancimiento_Proyecto]", strCodProyecto
                                                                                                                           , strCodFuenteFinanciamiento
                                                          ));

            }
            catch
            {
                resultado = 0;
            }
            return resultado;
        }
    }
}
