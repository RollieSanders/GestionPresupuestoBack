using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Proyecto
    {
        public DataSet Ayuda_Proyecto_Spring_Help(string strCodCompañia)
        {

            Repository.Proyecto obj = new Repository.Proyecto();

            return obj.Ayuda_Proyecto_Spring_Help(strCodCompañia);
        }
    }
}
