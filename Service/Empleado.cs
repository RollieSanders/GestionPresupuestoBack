using System;
using System.Data;

namespace Service
{
    public class Empleado
    {
        public DataSet Ayuda_Empleado_Jefatura()
        {

            Repository.Empleado obj = new Repository.Empleado();

            return obj.Ayuda_Empleado_Jefatura();
        }

        public Model.Empleado Recupera_Empleado_Codigo(string strCodEmpleado)
        {
            Repository.Empleado objE = new Repository.Empleado();
            return objE.Recupera_Empleado_Codigo(strCodEmpleado);
        }

        public DataSet Ayuda_Empleado()
        {
            Repository.Empleado objE = new Repository.Empleado();
            return objE.Ayuda_Empleado();
        }
    }
}
