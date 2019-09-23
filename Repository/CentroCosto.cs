using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CentroCosto
    {
        private readonly string strConnection_Formulacion = "";
        public CentroCosto()
        {
            Repository.DataAccess DA = new Repository.DataAccess();

            strConnection_Formulacion = DA.ReturnConnectionString_Formulacion();

        }

        public DataSet Ayuda_CentroCosto(string strCodCompañia)
        {
            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection_Formulacion, "Formulacion.spp_help_msto_CentroCosto", strCodCompañia))
            {
                return ds;
            }

        }

        public DataSet Ayuda_CentroCosto_Todos()
        {
            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection_Formulacion, "Formulacion.spp_help_msto_CentroCosto_Todos"))
            {
                return ds;
            }

        }

        public DataSet Lista_Ceco_Clasificador_x_Elegir(string strCodCompañia,
                                                        string strCeco

                             )
        {
            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection_Formulacion, "Formulacion.spp_Lista_Ceco_Clasificador_x_Elegir", strCodCompañia, strCeco))
            {
                return ds;
            }
        }

        public DataSet Lista_Ceco_Clasificador_Elegidos(string strCodCompañia,
                                                        string strCeco

                             )
        {
            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection_Formulacion, "Formulacion.spp_Lista_Ceco_Clasificador_x_Elegidos", strCodCompañia, strCeco))
            {
                return ds;
            }
        }

        public int Graba_CentroCosto_Clasificador(string strCodCeco, string strCodClasificador)
        {
            int intIdCentroCosto_Clasificador = 0;
            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataTable(strConnection_Formulacion, "[Formulacion].[spp_ins_mvto_CentroCosto_Clasificador]", strCodCeco
                                                                                                                           , strCodClasificador
                                                          );
                intIdCentroCosto_Clasificador = Convert.ToInt32(dt.Rows[0][0]);
            }
            catch
            {
                intIdCentroCosto_Clasificador = 0;
            }
            return intIdCentroCosto_Clasificador;
        }

        public int Elimina_CentroCosto_Clasificador(string strCodCeco, string strCodClasificador)
        {
            int resultado = 0;
            
            try
            {
                resultado = Convert.ToInt32(SqlHelper.ExecuteScalar(strConnection_Formulacion, "[Formulacion].[spp_del_mvto_CentroCosto_Clasificador]", strCodCeco
                                                                                                                           , strCodClasificador
                                                          ));
                
            }
            catch
            {
                resultado = 0;
            }
            return resultado;
        }


        public DataSet Lista_Ceco_Proyecto_x_Elegir(string strCodCompañia,
                                                        string strCodProyecto

                             )
        {
            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection_Formulacion, "Formulacion.spp_Lista_CentroCosto_Proyecto_x_Elegir", strCodCompañia, strCodProyecto))
            {
                return ds;
            }
        }

        public DataSet Lista_Ceco_Proyecto_Elegidos(string strCodCompañia,
                                                        string strCodProyecto

                             )
        {
            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection_Formulacion, "Formulacion.spp_Lista_CentroCosto_Proyecto_Elegidos", strCodCompañia, strCodProyecto))
            {
                return ds;
            }
        }

        public int Graba_CentroCosto_Proyecto(string strCodCeco, string strCodProyecto)
        {
            int intIdCentroCosto_Clasificador = 0;
            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataTable(strConnection_Formulacion, "[Formulacion].[spp_ins_mvto_CentroCosto_Proyecto]", strCodProyecto
                                                                                                                           , strCodCeco 
                                                          );
                intIdCentroCosto_Clasificador = Convert.ToInt32(dt.Rows[0][0]);
            }
            catch
            {
                intIdCentroCosto_Clasificador = 0;
            }
            return intIdCentroCosto_Clasificador;
        }

        public int Elimina_CentroCosto_Proyecto(string strCodCeco, string strCodProyecto)
        {
            int resultado = 0;

            try
            {
                resultado = Convert.ToInt32(SqlHelper.ExecuteScalar(strConnection_Formulacion, "[Formulacion].[spp_del_mvto_Centro_Proyecto]", strCodProyecto
                                                                                                                           , strCodCeco
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
