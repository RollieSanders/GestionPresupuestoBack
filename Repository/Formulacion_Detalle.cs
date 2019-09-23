using System;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Repository
{
    public class Formulacion_Detalle
    {
        private string strConnection = "";
        public Formulacion_Detalle()
        {
            Repository.DataAccess DA = new Repository.DataAccess();
            strConnection = DA.ReturnConnectionString_Formulacion();
        }

        public int Graba_FormulacionDetalle(Model.Formulacion_Detalle obj)
        {
            int intIdFormulacion_Detalle = 0;
            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataTable(strConnection, "Formulacion.spp_ins_mvto_Formulacion_Detalle",  obj.IidFormulacion_Cabecera,
                                                                                                                obj.CcodTipoFormulacion_Item,
                                                                                                                obj.CcodCentro,
                                                                                                                obj.CcodCege,
                                                                                                                obj.CcodCeco,
                                                                                                                obj.CcodSubActividad,
                                                                                                                obj.CcodPosPre,
                                                                                                                obj.FvalorPosPre,
                                                                                                                obj.IcodTipoInserccion
                                                );
                intIdFormulacion_Detalle = Convert.ToInt32(dt.Rows[0][0]);
            }
            catch
            {
                intIdFormulacion_Detalle = 0;
            }
            return intIdFormulacion_Detalle;
        }
    }
}
