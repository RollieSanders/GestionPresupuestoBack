using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EmpleadoCentroCosto
    {
        public DataSet Arbol_Empleado()
        {
            Repository.EmpleadoCentroCosto obj = new Repository.EmpleadoCentroCosto();

            return obj.Arbol_Empleado();

        }
        public int Graba_Empleado_CentroCosto(int iCodEmpleado, string strCodCeco)
        {
            Repository.EmpleadoCentroCosto obj = new Repository.EmpleadoCentroCosto();

            return obj.Graba_Empleado_CentroCosto(iCodEmpleado,strCodCeco);
        }

        public int Modifica_Empleado_CentroCosto(int iCodEmpleado, string strCodCeco)
        {
            Repository.EmpleadoCentroCosto obj = new Repository.EmpleadoCentroCosto();

            return obj.Modifica_Empleado_CentroCosto(iCodEmpleado, strCodCeco);
        }
        public DataSet Recupera_Empleado_CentroCosto(int iCodEmpleado)
        {

            Repository.EmpleadoCentroCosto obj = new Repository.EmpleadoCentroCosto();

            return obj.Recupera_Empleado_CentroCosto(iCodEmpleado);

        }
    }
}
