using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class FuenteFinanciamiento
    {
        public DataSet Lista_Proyecto_FuenteFinanciamiento_Elegidos(string strCodCompañia,
                                                        string strCodProyecto

                             )
        {
            Repository.FuenteFinanciamiento obj = new Repository.FuenteFinanciamiento();

            return obj.Lista_Proyecto_FuenteFinanciamiento_Elegidos(strCodCompañia, strCodProyecto);
        }

        public DataSet Lista_Proyecto_FuenteFinanciamiento_x_Elegir(string strCodCompañia,
                                                        string strCodProyecto

                             )
        {
            Repository.FuenteFinanciamiento obj = new Repository.FuenteFinanciamiento();

            return obj.Lista_Proyecto_FuenteFinanciamiento_x_Elegir(strCodCompañia, strCodProyecto);
        }

        public int Graba_Proyecto_FuenteFinanciamiento(string strCodProyecto, string strCodFuenteFinanciamiento)
        {

            Repository.FuenteFinanciamiento objDs = new Repository.FuenteFinanciamiento();

            return objDs.Graba_Proyecto_FuenteFinanciamiento(strCodProyecto, strCodFuenteFinanciamiento);

        }

        public int Elimina_Proyecto_FuenteFinanciamiento(string strCodProyecto, string strCodFuenteFinanciamiento)
        {

            Repository.FuenteFinanciamiento objDs = new Repository.FuenteFinanciamiento();

            return objDs.Elimina_Proyecto_FuenteFinanciamiento(strCodProyecto, strCodFuenteFinanciamiento);

        }
    }
}
