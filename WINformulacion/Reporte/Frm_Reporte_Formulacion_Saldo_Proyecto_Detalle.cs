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
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System.IO;
using DevExpress.XtraReports.UI;

namespace WINformulacion
{
    public partial class Frm_Reporte_Formulacion_Saldo_Proyecto_Detalle : DevExpress.XtraEditors.XtraForm
    {
        public DataTable DT_Proyecto = new DataTable();
        public DataTable DT_Tipo_Formulacion = new DataTable();

        public Boolean blnProcesaExcel = false;
        DataSet DS_Proyecto;
        DataSet DS_CentroCosto;
        private Framework FS = new Framework();
        public Boolean blnEligio = false;

        public string NroOrden = "";
        public string TipoOrden = "";
        public Frm_Reporte_Formulacion_Proyecto Frm_Reporte_Formulacion_Proyecto;

        public Frm_Reporte_Formulacion_Saldo_Proyecto_Detalle(Frm_Reporte_Formulacion_Proyecto Frm_Reporte_Formulacion_Proyecto)
        {
            InitializeComponent();
            this.Frm_Reporte_Formulacion_Proyecto = Frm_Reporte_Formulacion_Proyecto;
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            if (blnEligio == true)
            {
                if (MessageBox.Show("Si Sale perdera las ordenes elegidas, realmente desea salir ? ",
                                    "Salir", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question
                                ) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void Frm_Reporte_Formulacion_Saldo_Proyecto_Detalle_Load(object sender, EventArgs e)
        {
            if (NroOrden.Length > 0 && TipoOrden.Length > 0)
            {
                MostrarContrato();
            }
            else
            {
                XtraMessageBox.Show("Seleccione el código del Proyecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MostrarContrato()
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            SplashScreenManager.Default.SetWaitFormDescription("Recopilando informaciòn...");
            string cCodCompañia = "000000";
            string cNumeroOrden = NroOrden.TrimEnd();
            string cTipoOrden = TipoOrden.TrimEnd();
            if (MyStuff.UsaWCF == true)
            {

            }
            else
            {
                Service.Reporte SDG = new Service.Reporte();
                DT_Proyecto = SDG.Lista_FormulacionReporteContrato(cCodCompañia, cNumeroOrden, cTipoOrden).Tables[0];
            }
            this.gridControlData.DataSource = DT_Proyecto;
            gridViewData.ExpandAllGroups();
            SplashScreenManager.CloseForm();
        }
    }
}