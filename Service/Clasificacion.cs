using System;
using System.Data;

namespace Service
{
    public class Clasificacion
    {
        public DataSet Ayuda_Clasificacion()
        {
            Repository.Clasificacion obj = new Repository.Clasificacion();
            return obj.Ayuda_Clasificacion();
        }

        public DataSet Ayuda_Clasificacion_Formulacion(string strAñoProceso)
        {
            Repository.Clasificacion obj = new Repository.Clasificacion();
            return obj.Ayuda_Clasificacion_Formulacion(strAñoProceso);
        }
    }
}
