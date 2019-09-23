using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Formulacion_Cabecera_Ceco
    {
        public bool Graba_mvto_Formulacion_Cabecera_Ceco(Model.Formulacion_Cabecera_Ceco obj)
        {
            Repository.Formulacion_Cabecera_Ceco objDs = new Repository.Formulacion_Cabecera_Ceco();
            return objDs.Graba_mvto_Formulacion_Cabecera_Ceco(obj);
        }
        public DataSet Lista_FormulacionCabecera_Ceco(string strAñoProceso, string strCeco, int digito)
        {
            Repository.Formulacion_Cabecera_Ceco objDs = new Repository.Formulacion_Cabecera_Ceco();
            return objDs.Lista_FormulacionCabecera_Ceco(strAñoProceso, strCeco, digito);
        }

        public Model.Formulacion_Cabecera_Ceco Recupera_FormulacionCabecera_CeCo(string strAñoProceso,
                                                                            string strVersion,
                                                                            string strCodCentroCosto
                                                                           )
        {
            Repository.Formulacion_Cabecera_Ceco objDs = new Repository.Formulacion_Cabecera_Ceco();
            return objDs.Recupera_FormulacionCabecera_CeCo(strAñoProceso, strVersion, strCodCentroCosto);
        }

        public DataSet Lista_Formulacion_Aprobacion_Ceco(string strAñoProceso, string strCeGe, string strVersion, int digito)
        {
            Repository.Formulacion_Cabecera_Ceco objDs = new Repository.Formulacion_Cabecera_Ceco();
            return objDs.Lista_Formulacion_Aprobacion_Ceco(strAñoProceso, strCeGe, strVersion, digito);
        }

        public DataSet Lista_Version(string strAñoProceso){
            Repository.Formulacion_Cabecera_Ceco objDs = new Repository.Formulacion_Cabecera_Ceco();
            return objDs.Lista_Version(strAñoProceso);
        }
    }
}
