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
    public partial class Frm_Reporte_Formulacion_Proyecto_Ceco : DevExpress.XtraEditors.XtraForm
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

        public Frm_Reporte_Formulacion_Proyecto_Ceco()
        {
            InitializeComponent();
        }

        public void ShowMe()
        {

            Model.Formulacion_Cabecera MFC = new Model.Formulacion_Cabecera();
            Service.Formulacion_Cabecera SFC = new Service.Formulacion_Cabecera();

            if (MyStuff.UsaWCF == true)
            {
                MFC = objWCF.Recupera_FormulacionCabecera(MyStuff.AñoProceso);
            }
            else
            {

                MFC = SFC.Recupera_FormulacionCabecera(MyStuff.AñoProceso);
            }
           

            string strCodCentroCosto = MyStuff.CodigoCentroCosto;
            Service.DataGeneral SDG = new Service.DataGeneral();

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
                DS_CentroCosto = objWCF.Ayuda_Proyecto_CentroCosto(MyStuff.CodigoCentroGestor, MyStuff.DigitoCentroGestor);
                this.Txt_CodCentroCosto.nombreDS = DS_CentroCosto;
            }
            else
            {

                DS_CentroCosto = SDG.Ayuda_Proyecto_CentroCosto(MyStuff.CodigoCentroGestor, MyStuff.DigitoCentroGestor);
                this.Txt_CodCentroCosto.nombreDS = DS_CentroCosto;
            }
            if (DS_CentroCosto.Tables[0].Rows.Count > 1)
            {
                this.Txt_CodCentroCosto.Enabled = true;
            }
            else
            {
                this.Txt_CodCentroCosto.Enabled = true;
                this.Txt_CodCentroCosto.Value = Convert.ToString(DS_CentroCosto.Tables[0].Rows[0][0]);
                this.Txt_NomCentroCosto.Value = Convert.ToString(DS_CentroCosto.Tables[0].Rows[0][1]);
            }

            //this.ShowDialog();
        }

        private void Frm_Reporte_Formulacion_Proyecto_Ceco_Load(object sender, EventArgs e)
        {
            ShowMe();
            Select_Tipo_Formulacion();
            lookUpEditTipoFormulacion.EditValue = "01            ";
        }
        public void Select_Tipo_Formulacion()
        {
            try
            {
                Service.Reporte SDG = new Service.Reporte();
                if (MyStuff.UsaWCF == true)
                {
                    DT_Tipo_Formulacion = objWCF.Help_FormulacionTipoFormulacion().Tables[0];
                }
                else
                {
                    DT_Tipo_Formulacion = SDG.Help_FormulacionTipoFormulacion().Tables[0];
                }
                lookUpEditTipoFormulacion.Properties.DataSource = DT_Tipo_Formulacion;
                lookUpEditTipoFormulacion.Properties.ValueMember = "cCodTipoFormulacion";
                lookUpEditTipoFormulacion.Properties.DisplayMember = "cCodTipoFormulacion";
                lookUpEditTipoFormulacion.Properties.DisplayMember = "vNomTipoFormulacion";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Txt_CodCentroCosto_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(this.Txt_CodCentroCosto.Value)))
            {
                this.Txt_NomCentroCosto.Value = "";
            }
            else
            {
                this.Txt_NomCentroCosto.Value = FS.TraerDescripcion_DataTable(DS_CentroCosto.Tables[0],
                                                                                                    0,
                                                                                                    1,
                                                                                                    Convert.ToString(this.Txt_CodCentroCosto.Value)
                                                                                                    );

            }
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
            if (Txt_CodCentroCosto.Text.Length > 0 && this.lookUpEditTipoFormulacion.EditValue != null)
            {
                MostrarProyectos();
            }
            else
            {
                XtraMessageBox.Show("Seleccione el centro de costo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void MostrarProyectos()
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            SplashScreenManager.Default.SetWaitFormDescription("Recopilando informaciòn...");
            string cCodCompañia = "000000";
            string cAñoProceso = Convert.ToString(this.Cbo_AñoProceso.SelectedValue);
            string cVersion = Convert.ToString(this.Cbo_Version.SelectedValue);
            string cCodTipoFormulacion = this.lookUpEditTipoFormulacion.EditValue.ToString();
            string CodCentroCosto = this.Txt_CodCentroCosto.Value.ToString();
            Service.Reporte SDG = new Service.Reporte();
            if (MyStuff.UsaWCF == true)
            {
                DT_Proyecto = objWCF.Lista_FormulacionReporteProyecto_Ceco(cCodCompañia, cAñoProceso, cVersion, cCodTipoFormulacion, CodCentroCosto).Tables[0];
            }
            else
            {
                DT_Proyecto = SDG.Lista_FormulacionReporteProyecto_Ceco(cCodCompañia, cAñoProceso, cVersion, cCodTipoFormulacion, CodCentroCosto).Tables[0];
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
                Frm_Reporte_Dev_Formulacion_Proyecto.xrLabelTitulo.Text = "REPORTE POR CECO";
                Frm_Reporte_Dev_Formulacion_Proyecto.xrLabelLabelProyecto.Visible = false;
                Frm_Reporte_Dev_Formulacion_Proyecto.xrLabelNombreProyecto.Visible = false;
                Frm_Reporte_Dev_Formulacion_Proyecto.xrLabelLabelMacroProyecto.Visible = false;
                Frm_Reporte_Dev_Formulacion_Proyecto.xrLabelNombreMacroProyecto.Visible = false;
                Frm_Reporte_Dev_Formulacion_Proyecto.DataSource = DT_Proyecto;
                Frm_Reporte_Dev_Formulacion_Proyecto.ShowRibbonPreview();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}