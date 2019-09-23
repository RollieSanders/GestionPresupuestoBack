using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WINgestion.Movimiento
{
    public partial class Frm_ActualizaRequerimiento_Nuevo_D : DevExpress.XtraEditors.XtraForm
    {
        DataSet DS_FuenteFinanciamiento = new DataSet();
        DataSet DS_CentroCosto = new DataSet();
        DataSet DS_Proyecto = new DataSet();
        DataSet DS_Componente = new DataSet();

        DataSet DS_PosicionPresupuestal = new DataSet();
        DataSet DS_Clasificacion = new DataSet();
        DataSet DS_TipoGasto = new DataSet();

        DataSet DS_Bien = new DataSet();
        DataSet DS_Servicio = new DataSet();

        //private SRformulacion.WCFformulacionEClient objWCF = new SRformulacion.WCFformulacionEClient();

        private Infragistics.Win.UltraWinGrid.UltraGrid m_Grid;

        public Frm_ActualizaRequerimiento_Nuevo_D()
        {
            InitializeComponent();
        }

        public void ShowMe( Model.Requerimiento_Cabecera _MRC,
                            Model.Requerimiento_Detalle _MRD,
                            Model.Requerimiento_Detalle_Bien _MRB,
                            Model.Requerimiento_Detalle_Servicio _MRS,
                            Infragistics.Win.UltraWinGrid.UltraGrid Grid

                          )
        {

            Model.PosicionPresupuestal MPP = new Model.PosicionPresupuestal();
            Service.PosicionPresupuestal SPP = new Service.PosicionPresupuestal();
            Service.Clasificacion SC = new Service.Clasificacion();

            if (MyStuff.UsaWCF == true)
            {
                //DS_FuenteFinanciamiento = objWCF.Ayuda_FuenteFinanciamiento_Reporte("000000");
                //DS_CentroCosto = objWCF.Ayuda_CentroCosto_Reporte("");
                //DS_Proyecto = objWCF.Ayuda_Proyecto_Reporte("", "");
            }
            else
            {
                Service.DataGeneral SDG = new Service.DataGeneral();
                DS_FuenteFinanciamiento = SDG.Ayuda_FuenteFinanciamiento_Reporte("000000");
                DS_CentroCosto = SDG.Ayuda_CentroCosto_Reporte("");
                DS_Proyecto = SDG.Ayuda_Proyecto_Reporte("", "");

                DS_PosicionPresupuestal = SPP.Ayuda_PosicionPresupuestal_Formulacion(MyStuff.AñoProceso);
                DS_Clasificacion = SC.Ayuda_Clasificacion_Formulacion(MyStuff.AñoProceso);
                DS_TipoGasto = SPP.Ayuda_PosicionPresupuestal_Formulacion(MyStuff.AñoProceso);

            }

            this.Txt_CodFuenteFinanciamiento.nombreDS = DS_FuenteFinanciamiento;
            this.Txt_CodCentroCosto.nombreDS = DS_CentroCosto;
            this.Txt_CodProyecto.nombreDS = DS_Proyecto;

            if ( MyStuff.UsaWCF == true )
            {

            }
            else
            {
                if ( _MRD.IidRequerimiento_Detalle != 0 )
                {
                    MPP = SPP.Recupera_PosicionPresupuestal(_MRD.CcodPosPre);
                }
                if (MPP.CcodTipoAdquisicion.TrimEnd() == "B")
                {
                    this.UTC_Principal.SelectedTab = this.UTC_Principal.Tabs["Bien"];
                }
                else
                {
                    this.UTC_Principal.SelectedTab = this.UTC_Principal.Tabs["Servicio"];
                }
            }
        }

        private void btn_Grabar_Salir_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Txt_CodClaseDocumento_Leave(object sender, EventArgs e)
        {

        }

        private void Txt_CodProveedor_Leave(object sender, EventArgs e)
        {

        }

        private void Txt_CodConcepto_Leave(object sender, EventArgs e)
        {

        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {

        }

        private void btn_Grabar_Click(object sender, EventArgs e)
        {

        }
    }
}