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
using DevExpress.XtraSplashScreen;

namespace WINformulacion
{
    public partial class Frt_FormulacionProyecto_Resumen : DevExpress.XtraEditors.XtraForm
    {
        private Model.Formulacion_Cabecera MFC = new Model.Formulacion_Cabecera();
        private Service.Formulacion_Cabecera SFC = new Service.Formulacion_Cabecera();

        public Frt_FormulacionProyecto_Resumen()
        {
            InitializeComponent();
        }

        private void Frt_FormulacionProyecto_Resumen_Load(object sender, EventArgs e)
        {

            MFC = SFC.Recupera_FormulacionCabecera(MyStuff.AñoProceso);

            this.Txt_Año.Value = MFC.CañoProceso;
            this.Txt_Version.Value = MFC.Cversion;

        }

        private void Btn_Mostrar_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            SplashScreenManager.Default.SetWaitFormDescription("Recopilando informaciòn...");

            Service.ReporteFormulacion SRF = new Service.ReporteFormulacion();
            DataSet DS_Proyecto = new DataSet();


            if (MyStuff.UsaWCF == true)
            {
            }
            else
            {
                DS_Proyecto = SRF.Lista_FormulacionProyecto_Resumen(MFC.CañoProceso,
                                                                    MFC.Cversion,
                                                                    "000000",
                                                                    Convert.ToString( this.Txt_CodProyecto.Value ),
                                                                    "01"
                                                                 );
            }


            Formato.CrystalReport.Rpt_FormulacionProyecto_Resumen crpt = new Formato.CrystalReport.Rpt_FormulacionProyecto_Resumen();

            crpt.Database.Tables["Proyecto"].SetDataSource(DS_Proyecto.Tables[0]);
            Crv_Formulacion_Proyecto.ReportSource = null;
            Crv_Formulacion_Proyecto.ReportSource = crpt;
            SplashScreenManager.CloseForm();

        }
    }
}