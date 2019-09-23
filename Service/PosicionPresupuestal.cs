using System;
using System.Data;

namespace Service
{
    public class PosicionPresupuestal
    {
        public DataSet Ayuda_PosicionPresupuestal()
        {
            Repository.PosicionPresupuestal obj = new Repository.PosicionPresupuestal();
            return obj.Ayuda_PosicionPresupuestal();
        }

        public DataSet Ayuda_PosicionPresupuestal_Formulacion( string strAñoProceso )
        {
            Repository.PosicionPresupuestal obj = new Repository.PosicionPresupuestal();
            return obj.Ayuda_PosicionPresupuestal_Formulacion( strAñoProceso );
        }


        public Model.PosicionPresupuestal Recupera_PosicionPresupuestal(string strCodPosPre)
        {
            Repository.PosicionPresupuestal obj = new Repository.PosicionPresupuestal();
            return obj.Recupera_PosicionPresupuestal(strCodPosPre);
        }

        public int Graba_PosicionPresupuestal(Model.PosicionPresupuestal obj)
        {
            Repository.PosicionPresupuestal objDS = new Repository.PosicionPresupuestal();
            return objDS.Graba_PosicionPresupuestal(obj);
        }

        public int Modifica_PosicionPresupuestal(Model.PosicionPresupuestal obj)
        {
            Repository.PosicionPresupuestal objDS = new Repository.PosicionPresupuestal();
            return objDS.Modifica_PosicionPresupuestal(obj);
        }

        public int Elimina_PosicionPresupuestal(int intIdPosPre)
        {
            Repository.PosicionPresupuestal obj = new Repository.PosicionPresupuestal();
            return obj.Elimina_PosicionPresupuestal(intIdPosPre);
        }
    }
}
