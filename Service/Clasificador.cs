using System;
using System.Data;

namespace Service
{
    public class Clasificador
    {
        public DataSet Ayuda_Clasificador(string strCodCompañia, string strCodClasificador, string strCodCentroCosto )
        {

            Repository.Clasificador obj = new Repository.Clasificador();

            return obj.Ayuda_Clasificador( strCodCompañia, strCodClasificador, strCodCentroCosto );
        }

        public DataSet Ayuda_Clasificador_inversion(string strCodCompañia, string strCodProyecto, string strCodClasificador, string strCodCentroCosto)
        {

            Repository.Clasificador obj = new Repository.Clasificador();

            return obj.Ayuda_Clasificador_Inversion(strCodCompañia, strCodProyecto, strCodClasificador, strCodCentroCosto);
        }

        public DataSet Ayuda_Clasificador_Otro(string strCodCompañia, string strCodClasificador, string strCodCentroCosto)
        {

            Repository.Clasificador obj = new Repository.Clasificador();

            return obj.Ayuda_Clasificador_Otro(strCodCompañia, strCodClasificador, strCodCentroCosto);
        }


        public DataSet Ayuda_Clasificador_tarea(string strCodCompañia, string strCodProyecto, string strCodClasificador, string strCodCentroCosto)
        {

            Repository.Clasificador obj = new Repository.Clasificador();

            return obj.Ayuda_Clasificador_Tarea(strCodCompañia, strCodProyecto, strCodClasificador, strCodCentroCosto);
        }

        public DataSet Ayuda_Clasificador_Ingreso(string strCodCompañia, string strCodCentroCosto)
        {

            Repository.Clasificador obj = new Repository.Clasificador();

            return obj.Ayuda_Clasificador_Ingreso(strCodCompañia, strCodCentroCosto);
        }


    }
}
