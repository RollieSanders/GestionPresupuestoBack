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

namespace WINformulacion
{
    public partial class Frm_Reporte_Formulacion_Proyecto_Saldo : DevExpress.XtraEditors.XtraForm
    {
        public DataTable DT_Proyecto = new DataTable();

        public Boolean blnProcesaExcel = false;
        DataSet DS_Proyecto;
        DataSet DS_CentroCosto;
        private Framework FS = new Framework();
        public Boolean blnEligio = false;
        public string strVersion = "";
        public string strCodProyecto = "";
        public string strNomProyecto = "";
        public string strNomMacroProyecto = "";
        public string strCodCentroCosto = "";
        public string strNomCentroCosto = "";
        private SRformulacion.WCFformulacionEClient objWCF = new SRformulacion.WCFformulacionEClient();

        public Frm_Reporte_Formulacion_Proyecto_Saldo()
        {
            InitializeComponent();
        }

        //public void ShowMe()
        //{

        //    Model.Formulacion_Cabecera MFC = new Model.Formulacion_Cabecera();
        //    Service.Formulacion_Cabecera SFC = new Service.Formulacion_Cabecera();

        //    MFC = SFC.Recupera_FormulacionCabecera(MyStuff.AñoProceso);

        //    string strCodCentroCosto = MyStuff.CodigoCentroCosto;
        //    //this.Txt_Año.Value = MyStuff.AñoProceso;
        //    //this.Txt_Empresa.Value = MyStuff.Empresa;
        //    //this.Txt_Version.Value = MFC.Cversion;

        //    if (MyStuff.UsaWCF == true)
        //    {

        //    }
        //    else
        //    {
        //        Service.DataGeneral SDG = new Service.DataGeneral();
        //        //DS_Proyecto = SDG.Ayuda_Proyecto_Spring("000000", strCodCentroCosto);
        //        //this.Txt_CodProyecto.nombreDS = DS_Proyecto;
        //        DS_CentroCosto = SDG.Ayuda_Proyecto_CentroCosto(MyStuff.CodigoCentroGestor, MyStuff.DigitoCentroGestor);
        //        this.Txt_CodCentroCosto.nombreDS = DS_CentroCosto;
        //    }
        //    if (DS_CentroCosto.Tables[0].Rows.Count > 1)
        //    {
        //        this.Txt_CodCentroCosto.Enabled = true;
        //    }
        //    else
        //    {
        //        this.Txt_CodCentroCosto.Enabled = true;
        //        this.Txt_CodCentroCosto.Value = Convert.ToString(DS_CentroCosto.Tables[0].Rows[0][0]);
        //        this.Txt_NomCentroCosto.Value = Convert.ToString(DS_CentroCosto.Tables[0].Rows[0][1]);
        //    }

        //    //this.ShowDialog();
        //}

        private void Frm_Reporte_Formulacion_Proyecto_Saldo_Load(object sender, EventArgs e)
        {
            //ShowMe();
        }

        private void Txt_CodCentroCosto_Leave(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(Convert.ToString(this.Txt_CodCentroCosto.Value)))
            //{
            //    this.Txt_NomCentroCosto.Value = "";
            //}
            //else
            //{
            //    this.Txt_NomCentroCosto.Value = FS.TraerDescripcion_DataTable(DS_CentroCosto.Tables[0],
            //                                                                                        0,
            //                                                                                        1,
            //                                                                                        Convert.ToString(this.Txt_CodCentroCosto.Value)
            //                                                                                        );

            //}
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

        private void Btn_Mostrar_Click(object sender, EventArgs e)
        {

                MostrarSaldo();
        }

        private void MostrarSaldo()
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            SplashScreenManager.Default.SetWaitFormDescription("Recopilando informaciòn...");
            string cCodCompañia = "000000";
            Service.Reporte SDG = new Service.Reporte();

            if (MyStuff.UsaWCF == true)
            {
                DT_Proyecto = objWCF.Lista_FormulacionReporteProyecto_Saldo(cCodCompañia).Tables[0];
            }
            else
            {
                DT_Proyecto = SDG.Lista_FormulacionReporteProyecto_Saldo(cCodCompañia).Tables[0];
            }
            this.gridControlData.DataSource = DT_Proyecto;
            gridViewData.ExpandAllGroups();
            SplashScreenManager.CloseForm();
        }

        private void navBarItemImprimir_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            gridControlData.ShowRibbonPrintPreview();
        }

        private void navBarItemExportar_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                ExportarExcel();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ExportarExcel()
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".xls":
                            gridControlData.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            gridControlData.ExportToXlsx(exportFilePath);
                            break;
                        case ".rtf":
                            gridControlData.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            gridControlData.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            gridControlData.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            gridControlData.ExportToMht(exportFilePath);
                            break;
                        default:
                            break;
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch
                        {
                            String msg = "El archivo no puede ser abierto." + Environment.NewLine + Environment.NewLine + "Ubicación: " + exportFilePath;
                            XtraMessageBox.Show(msg, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "El archivo no puede ser guardado." + Environment.NewLine + Environment.NewLine + "Ubicación: " + exportFilePath;
                        XtraMessageBox.Show(msg, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}