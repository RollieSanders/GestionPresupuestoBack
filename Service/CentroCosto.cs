using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CentroCosto
    {
        public DataSet Ayuda_CentroCosto(string strCodCompañia)
        {

            Repository.CentroCosto obj = new Repository.CentroCosto();

            return obj.Ayuda_CentroCosto(strCodCompañia);
        }

        public DataSet Ayuda_CentroCosto_Todos()
        {

            Repository.CentroCosto obj = new Repository.CentroCosto();

            return obj.Ayuda_CentroCosto_Todos();
        }

        public DataSet Lista_Ceco_Clasificador_Elegidos(string strCodCompañia,
                                                        string strCeco

                             )
        {
            Repository.CentroCosto obj = new Repository.CentroCosto();

            return obj.Lista_Ceco_Clasificador_Elegidos(strCodCompañia, strCeco);
        }

        public DataSet Lista_Ceco_Clasificador_x_Elegir(string strCodCompañia,
                                                        string strCeco

                             )
        {
            Repository.CentroCosto obj = new Repository.CentroCosto();

            return obj.Lista_Ceco_Clasificador_x_Elegir(strCodCompañia, strCeco);
        }

        public int Graba_CentroCosto_Clasificador(string strCodCeco, string strCodClasificador)
        {

            Repository.CentroCosto objDs = new Repository.CentroCosto();

            return objDs.Graba_CentroCosto_Clasificador(strCodCeco, strCodClasificador);

        }

        public int Elimina_CentroCosto_Clasificador(string strCodCeco, string strCodClasificador)
        {

            Repository.CentroCosto objDs = new Repository.CentroCosto();

            return objDs.Elimina_CentroCosto_Clasificador(strCodCeco, strCodClasificador);

        }

        //Ceco de Proyecto
        public DataSet Lista_Ceco_Proyecto_Elegidos(string strCodCompañia,
                                                        string strCodProyecto

                             )
        {
            Repository.CentroCosto obj = new Repository.CentroCosto();

            return obj.Lista_Ceco_Proyecto_Elegidos(strCodCompañia, strCodProyecto);
        }

        public DataSet Lista_Ceco_Proyecto_x_Elegir(string strCodCompañia,
                                                        string strCodProyecto

                             )
        {
            Repository.CentroCosto obj = new Repository.CentroCosto();

            return obj.Lista_Ceco_Proyecto_x_Elegir(strCodCompañia, strCodProyecto);
        }

        public int Graba_CentroCosto_Proyecto(string strCodCeco, string strCodProyecto)
        {

            Repository.CentroCosto objDs = new Repository.CentroCosto();

            return objDs.Graba_CentroCosto_Proyecto(strCodCeco, strCodProyecto);

        }

        public int Elimina_CentroCosto_Proyecto(string strCodCeco, string strCodProyecto)
        {

            Repository.CentroCosto objDs = new Repository.CentroCosto();

            return objDs.Elimina_CentroCosto_Proyecto(strCodCeco, strCodProyecto);

        }
    }
}
