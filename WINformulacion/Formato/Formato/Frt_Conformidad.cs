using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WINformulacion
{
    public partial class Frt_Conformidad : Form
    {
        private SRformulacion.WCFformulacionEClient objWCF = new SRformulacion.WCFformulacionEClient();
        public Frt_Conformidad()
        {
            InitializeComponent();
        }

        public void ShowMe(string strCodCompañia,
                            string strNumConformidad,
                            string strTipoOrden,
                            string strNumOrden
                          )
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            SplashScreenManager.Default.SetWaitFormDescription("Recopilando informaciòn...");

            Service.DataGeneral SDG = new Service.DataGeneral();
            DataSet DS_Conformidad = new DataSet();


            if (MyStuff.UsaWCF == true)
            {
                DS_Conformidad = objWCF.Formato_Conformidad(strCodCompañia,
                                       strNumConformidad,
                                       strTipoOrden,
                                       strNumOrden
                                    );
            }
            else
            {
                DS_Conformidad = SDG.Formato_Conformidad(strCodCompañia,
                                            strNumConformidad,
                                            strTipoOrden,
                                            strNumOrden
                                         );
            }
            

            Formato.CrystalReport.Rpt_Conformidad crpt = new Formato.CrystalReport.Rpt_Conformidad();

            crpt.Database.Tables["Orden"].SetDataSource(DS_Conformidad.Tables[0]);
            crpt.Database.Tables["Conformidad"].SetDataSource(DS_Conformidad.Tables[1]);
            crpt.Database.Tables["ConformidadProceso"].SetDataSource(DS_Conformidad.Tables[2]);
            crpt.Database.Tables["ConformidadDetalle"].SetDataSource(DS_Conformidad.Tables[3]);
            Crv_Requerimiento.ReportSource = null;
            Crv_Requerimiento.ReportSource = crpt;
            SplashScreenManager.CloseForm();
            this.ShowDialog();
        }

        private void Frt_Requerimiento_Load(object sender, EventArgs e)
        {

        }
    }
}
