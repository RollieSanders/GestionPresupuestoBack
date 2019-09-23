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
    public partial class Frm_Reporte_Formulacion_Proyecto : DevExpress.XtraEditors.XtraForm
    {
        public DataTable DT_Proyecto = new DataTable();
        public DataTable DT_Tipo_Formulacion = new DataTable();

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

        public Frm_Reporte_Formulacion_Proyecto()
        {
            InitializeComponent();
        }

        public void ShowMe(  string strCodTipoFormulacion, string strCodProyecto, string strNomProyecto  )
        {
            this.Cargadatos();
            this.cbo_CodTipoFormulacion.SelectedValue = strCodTipoFormulacion;
            this.Txt_CodProyecto.Value = strCodProyecto;
            this.Txt_NomProyecto.Value = strNomProyecto;
            MostrarProyectos();
            this.ShowDialog();

        }

        private void Txt_CodProyecto_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(this.Txt_CodProyecto.Value)))
            {
                this.Txt_NomProyecto.Value = "";
            }
            else
            {
                this.Txt_NomProyecto.Value = FS.TraerDescripcion_DataTable(DS_Proyecto.Tables[0],
                                                                                                    0,
                                                                                                    1,
                                                                                                    Convert.ToString(this.Txt_CodProyecto.Value)
                                                                                                    );

            }
        }



        private void Frm_Reporte_Formulacion_Proyecto_Load(object sender, EventArgs e)
        {
            this.Cargadatos();
        }

        private void Cargadatos()
        {
            Service.DataGeneral SDG = new Service.DataGeneral();
            Service.Reporte SDR = new Service.Reporte();
            Model.Formulacion_Cabecera MFC = new Model.Formulacion_Cabecera();
            Service.Formulacion_Cabecera SFC = new Service.Formulacion_Cabecera();
            string strCodCentroCosto = MyStuff.CodigoCentroCosto;

            if (MyStuff.UsaWCF == true)
            {
                this.Cbo_AñoProceso.CargaDT(objWCF.Combo_AñoProceso("000000"));
                if (string.IsNullOrEmpty(Convert.ToString(this.Cbo_AñoProceso.SelectedValue)))
                {
                    this.Cbo_Version.CargaDT(objWCF.Combo_Version(MyStuff.AñoProceso));
                }
                else
                {
                    this.Cbo_Version.CargaDT(objWCF.Combo_Version(Convert.ToString(this.Cbo_AñoProceso.SelectedValue)));
                }
            }
            else
            {
                this.Cbo_AñoProceso.CargaDT(SFC.Combo_AñoProceso("000000"));
                if (string.IsNullOrEmpty(Convert.ToString(this.Cbo_AñoProceso.SelectedValue)))
                {
                    this.Cbo_Version.CargaDT(SFC.Combo_Version(MyStuff.AñoProceso));
                }
                else
                {
                    this.Cbo_Version.CargaDT(SFC.Combo_Version(Convert.ToString(this.Cbo_AñoProceso.SelectedValue)));
                }
            }

            if (MyStuff.UsaWCF == true)
            {
                DT_Tipo_Formulacion = objWCF.Combo_TipoFormulacion().Tables[0];
                MFC = objWCF.Recupera_FormulacionCabecera(MyStuff.AñoProceso);
                DS_Proyecto = objWCF.Ayuda_Proyecto_Spring("000000", strCodCentroCosto);


            }
            else
            {
                DT_Tipo_Formulacion = SDG.Combo_TipoFormulacion().Tables[0];
                MFC = SFC.Recupera_FormulacionCabecera(MyStuff.AñoProceso);
                DS_Proyecto = SDG.Ayuda_Proyecto_Spring("000000", strCodCentroCosto);

            }

            this.Txt_CodProyecto.nombreDS = DS_Proyecto;
            this.cbo_CodTipoFormulacion.CargaDT(DT_Tipo_Formulacion);



        }

        private void Btn_Mostrar_Click(object sender, EventArgs e)
        {
            if (  !string.IsNullOrEmpty(  Convert.ToString(  this.cbo_CodTipoFormulacion.SelectedValue ) ) )
            {
                if (!string.IsNullOrEmpty(Convert.ToString(this.Txt_CodProyecto.Value)))
                {
                    MostrarProyectos();
                }
                else
                {
                    XtraMessageBox.Show("Seleccione el código del Proyecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                    
            }
            else
            {
                XtraMessageBox.Show("Seleccione el tipo del Proyecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MostrarProyectos()
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            SplashScreenManager.Default.SetWaitFormDescription("Recopilando informaciòn...");
            string cCodCompañia = "000000";
            string cAñoProceso = Convert.ToString(this.Cbo_AñoProceso.SelectedValue);
            string cVersion = Convert.ToString(this.Cbo_Version.SelectedValue);
            string cCodTipoFormulacion = Convert.ToString(this.cbo_CodTipoFormulacion.SelectedValue);
            string CodProyecto = Convert.ToString(this.Txt_CodProyecto.Value);
            Service.Reporte SDG = new Service.Reporte();
            if (MyStuff.UsaWCF == true)
            {
                DT_Proyecto = objWCF.Lista_FormulacionReporteProyecto(cCodCompañia, cAñoProceso, cVersion, cCodTipoFormulacion, CodProyecto).Tables[0];
            }
            else
            {
                DT_Proyecto = SDG.Lista_FormulacionReporteProyecto(cCodCompañia, cAñoProceso, cVersion, cCodTipoFormulacion, CodProyecto).Tables[0];
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