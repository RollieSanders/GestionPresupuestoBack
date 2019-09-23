using System;
using System.Data;

namespace Service
{
    public class PeriodoProceso
    {
        public DataSet Combo_PeriodoProceso_DataTable()
        {
            Repository.PeriodoProceso objRPeriodoProceso = new Repository.PeriodoProceso();
            return objRPeriodoProceso.Combo_PeriodoProceso_DataTable();
        }
    }
}
