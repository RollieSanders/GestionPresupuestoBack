using System;
using System.Data;

namespace Service
{
    public class Formulacion_Cabecera
    {
        public DataTable Combo_AñoProceso(string strCodCompañia)
        {
            Repository.Formulacion_Cabecera objDs = new Repository.Formulacion_Cabecera();
            return objDs.Combo_AñoProceso(strCodCompañia);
        }

        public DataTable Combo_Version(string strAñoProceso)
        {
            Repository.Formulacion_Cabecera objDs = new Repository.Formulacion_Cabecera();
            return objDs.Combo_Version(strAñoProceso);
        }


        public Model.Formulacion_Cabecera Recupera_FormulacionCabecera(string strAñoProceso)
        {
            Repository.Formulacion_Cabecera objDs = new Repository.Formulacion_Cabecera();
            return objDs.Recupera_FormulacionCabecera(strAñoProceso);
        }

        public int Graba_FormulacionCabecera(Model.Formulacion_Cabecera obj)
        {

            Repository.Formulacion_Cabecera objDs = new Repository.Formulacion_Cabecera();

            return objDs.Graba_FormulacionCabecera(obj);

        }
        //Agregado
        public DataSet Lista_FormulacionCabecera(string strAñoProceso)
        {
            Repository.Formulacion_Cabecera objDs = new Repository.Formulacion_Cabecera();

            return objDs.Lista_FormulacionCabecera(strAñoProceso);
        }

        public bool elimina_mvto_Formulacion_Cabecera(int intiIdFormulacion_Cabecera)
        {
            Repository.Formulacion_Cabecera objDs = new Repository.Formulacion_Cabecera();

            return objDs.elimina_mvto_Formulacion_Cabecera(intiIdFormulacion_Cabecera);
        }

        public DataSet Graba_FormulacionCabecera_DataSet(Model.Formulacion_Cabecera obj) {
            Repository.Formulacion_Cabecera objDs = new Repository.Formulacion_Cabecera();

            return objDs.Graba_FormulacionCabecera_DataSet(obj); 
        }

        public bool Modifica_mvto_Formulacion_Cabecera(Model.Formulacion_Cabecera obj) {
            Repository.Formulacion_Cabecera objDs = new Repository.Formulacion_Cabecera();

            return objDs.Modifica_mvto_Formulacion_Cabecera(obj);
        }
    }
}
