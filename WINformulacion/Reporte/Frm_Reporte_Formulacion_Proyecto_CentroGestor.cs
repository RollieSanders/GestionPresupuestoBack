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
    public partial class Frm_Reporte_Formulacion_Proyecto_CentroGestor : DevExpress.XtraEditors.XtraForm
    {
        private DataTable DT_Proyecto;
        private Framework FS = new Framework();
        public string strVersion = "";
        public string strCodTipoFormulacion;
        public string strCodProyecto = "";
        public string strCodCentroCosto = "";

        private SRformulacion.WCFformulacionEClient objWCF = new SRformulacion.WCFformulacionEClient();

        public Frm_Reporte_Formulacion_Proyecto_CentroGestor()
        {
            InitializeComponent();
        }

        public void ShowMe(  string cCodTipoFormulacion, 
                             string strNomTipoFormulacion,
                             string cCodProyecto, 
                             string strNomProyecto,
                             string cCodCentroCosto,
                             string strNomCentroCosto
                          )
        {

            strCodTipoFormulacion = cCodTipoFormulacion;
            strCodCentroCosto = cCodCentroCosto;
            strCodProyecto = cCodProyecto;

            this.Txt_NomTipoFormulacion.Value = strNomTipoFormulacion;
            this.Txt_NomProyecto.Value = strNomProyecto;
            this.Txt_NomCentroCosto.Value = strNomCentroCosto;
    
            MostrarProyectos();
            this.ShowDialog();
        }


        private void MostrarProyectos()
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            SplashScreenManager.Default.SetWaitFormDescription("Recopilando informaciòn...");
            string cCodCompañia = "000000";
                      Service.Reporte SDG = new Service.Reporte();
            if (MyStuff.UsaWCF == true)
            {
                DT_Proyecto = objWCF.Lista_FormulacionReporteProyecto_CentroCosto(cCodCompañia, 
                                                                                  strCodTipoFormulacion, 
                                                                                  strCodProyecto,
                                                                                  strCodCentroCosto
                                                                                  ).Tables[0];
            }
            else
            {
                DT_Proyecto = SDG.Lista_FormulacionReporteProyecto_CentroCosto(cCodCompañia,
                                                                                  strCodTipoFormulacion,
                                                                                  strCodProyecto,
                                                                                  strCodCentroCosto
                                                                                  ).Tables[0];
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

        private void navBarItemReporte_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                Frm_Reporte_Dev_Formulacion_Proyecto Frm_Reporte_Dev_Formulacion_Proyecto = new Frm_Reporte_Dev_Formulacion_Proyecto();
                Frm_Reporte_Dev_Formulacion_Proyecto.xrLabelTitulo.Text = "REPORTE POR PROYECTO";
                Frm_Reporte_Dev_Formulacion_Proyecto.DataSource = DT_Proyecto;
                Frm_Reporte_Dev_Formulacion_Proyecto.ShowRibbonPreview();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Select_Imprimir_Reporte()
        {
            try
            {

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void repositoryItemButtonEditOpcion_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Index == 0)
                {
                    //using (Frm_Reporte_Formulacion_Saldo_Proyecto_Detalle Frm_Reporte_Formulacion_Saldo_Proyecto_Detalle = new Frm_Reporte_Formulacion_Saldo_Proyecto_Detalle(this))
                    //{
                    //    Frm_Reporte_Formulacion_Saldo_Proyecto_Detalle.NroOrden = gridViewData.GetFocusedRowCellValue("cNumeroOrden").ToString().TrimEnd();
                    //    Frm_Reporte_Formulacion_Saldo_Proyecto_Detalle.TipoOrden = gridViewData.GetFocusedRowCellValue("cTipoOrden").ToString().TrimEnd();
                    //    Frm_Reporte_Formulacion_Saldo_Proyecto_Detalle.ShowDialog();
                    //}
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dockPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}