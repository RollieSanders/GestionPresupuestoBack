using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Proyecto
    {
        private string strConnection = "";
        public Proyecto()
        {
            Repository.DataAccess DA = new Repository.DataAccess();
            strConnection = DA.ReturnConnectionString_Formulacion();
        }
        public DataSet Ayuda_Proyecto_Spring_Help(string strCodCompañia
                                                
                                            )
        {
            return SqlHelper.ExecuteDataset(strConnection, "Formulacion.spp_help_msto_Proyecto_Spring_Ayuda", strCodCompañia);
        }

        
    }
}
