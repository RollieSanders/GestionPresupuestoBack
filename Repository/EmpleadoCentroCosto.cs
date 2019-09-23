using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EmpleadoCentroCosto
    {
        private readonly string strConnection_Formulacion = "";
        public EmpleadoCentroCosto()
        {
            Repository.DataAccess DA = new Repository.DataAccess();

            strConnection_Formulacion = DA.ReturnConnectionString_Formulacion();

        }

        public DataSet Arbol_Empleado()
        {
            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection_Formulacion, "Formulacion.spp_Arbol_Empleado_CentroCosto"))
            {
                return ds;
            }

        }
        public int Graba_Empleado_CentroCosto(int iCodEmpleado, string strCodCeco)
        {
            int resultado = 0;
            DataTable dt = new DataTable();
            try
            {
                resultado = Convert.ToInt32(SqlHelper.ExecuteScalar(strConnection_Formulacion, "Formulacion.spp_ins_Empleado_CentroCosto", iCodEmpleado,
                                                                                                                strCodCeco
                                                          ));
                
            }
            catch
            {
                resultado = 0;
            }
            return resultado;
        }

        public int Modifica_Empleado_CentroCosto(int iCodEmpleado, string strCodCeco)
        {
            int resultado = 0;
            DataTable dt = new DataTable();
            try
            {
                resultado = Convert.ToInt32(SqlHelper.ExecuteScalar(strConnection_Formulacion, "Formulacion.spp_upd_Empleado_CentroCosto", iCodEmpleado,
                                                                                                                strCodCeco
                                                          ));

            }
            catch
            {
                resultado = 0;
            }
            return resultado;
        }

        public DataSet Recupera_Empleado_CentroCosto(int iCodEmpleado) {

            DataSet ds = new DataSet();
            using (ds = SqlHelper.ExecuteDataset(strConnection_Formulacion, "Formulacion.spp_Recupera_Empleado_CentroCosto", iCodEmpleado))
            {
                return ds;
            }

        }
    }
}
