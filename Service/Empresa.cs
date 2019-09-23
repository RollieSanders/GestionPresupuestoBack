using System;
using System.Data;

namespace Service
{
    public class Empresa
    {
        public DataSet Combo_Empresa_DataTable()
        {
            Repository.Empresa obj = new Repository.Empresa();
            return obj.Combo_Empresa_DataTable();
        }
    }
}
