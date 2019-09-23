using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TipoDocumento
    {
        public DataSet Combo_TipoDocumento()
        {
            Repository.TipoDocumento obj = new Repository.TipoDocumento();

            return obj.Combo_TipoDocumento();

        }
    }
}
