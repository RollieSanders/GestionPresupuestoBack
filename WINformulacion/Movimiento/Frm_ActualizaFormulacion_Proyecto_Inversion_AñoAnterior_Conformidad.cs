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

namespace WINformulacion
{
    public partial class Frm_ActualizaFormulacion_Proyecto_Inversion_AñoAnterior_Conformidad : DevExpress.XtraEditors.XtraForm
    {
        private string strCodCompañia = "";
        private string strTipoOrden = "";
        private string strNumeroOrden = "";

        private bool blnMuestraFormato = false;
        private SRformulacion.WCFformulacionEClient objWCF = new SRformulacion.WCFformulacionEClient();

        public Frm_ActualizaFormulacion_Proyecto_Inversion_AñoAnterior_Conformidad()
        {
            InitializeComponent();
        }

        public void ShowMe(string cCodCompañia,
                            string cTipoOrden,
                            string cNumeroOrden
                          )
        {


            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            SplashScreenManager.Default.SetWaitFormDescription("Recopilando informaciòn...");

            this.Text = "Lista de Conformidades de la Orden " + cNumeroOrden;
            strCodCompañia = cCodCompañia;
            strTipoOrden = cTipoOrden;
            strNumeroOrden = cNumeroOrden;

            Service.DataGeneral SDG = new Service.DataGeneral();

            DataTable DT = new DataTable();

            if (MyStuff.UsaWCF == true)
            {
                DT = objWCF.Lista_Conformidad_Pago(strCodCompañia,
                                                        strTipoOrden,
                                                        strNumeroOrden
                                            ).Tables[0];
            }
            else
            {
                DT = SDG.Lista_Conformidad_Pago(strCodCompañia,
                                                        strTipoOrden,
                                                        strNumeroOrden
                                            ).Tables[0];
            }

            this.Grd_mvto_Mayor_FuenteFinanciamiento.DataSource = DT;
            if (blnMuestraFormato == false)
            {
                this.FormatoGrid();
                this.blnMuestraFormato = true;
            }
            SplashScreenManager.CloseForm();

            this.ShowDialog();
        }

        #region "Formato"
        private void FormatoGrid()
        {
            //Infragistics.Win.UltraWinGrid.UltraGridBand oBand;
            //Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn;
            this.Grd_mvto_Mayor_FuenteFinanciamiento.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.Grd_mvto_Mayor_FuenteFinanciamiento.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridBand oBand in this.Grd_mvto_Mayor_FuenteFinanciamiento.DisplayLayout.Bands)
            {
                if (oBand.Columns.Exists("Importe"))
                {
                    oBand.Summaries.Add("Sum_Importe", Infragistics.Win.UltraWinGrid.SummaryType.Sum, oBand.Columns["Importe"], Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn);
                    oBand.Summaries["Sum_Importe"].DisplayFormat = "{0:#,###,###,###,###.00}";
                    oBand.Summaries["Sum_Importe"].Appearance.TextHAlign = HAlign.Right;
                }
            }

            this.Grd_mvto_Mayor_FuenteFinanciamiento.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False; //'Infragistics.Win.DefaultableBoolean.Default


            foreach (Infragistics.Win.UltraWinGrid.UltraGridBand oBand in this.Grd_mvto_Mayor_FuenteFinanciamiento.DisplayLayout.Bands)
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in oBand.Columns)
                {
                    if (oColumn.DataType.ToString() == "System.Double")
                    {
                        oColumn.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        oColumn.Format = "#,###,###,###,###.00";
                    }

                    if (oColumn.DataType.ToString() == "System.Decimal")
                    {
                        oColumn.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        oColumn.Format = "#,###,###,###,###.00";
                    }
                }
            }

            Infragistics.Win.UltraWinGrid.UltraGridBand oBand0;
            oBand0 = this.Grd_mvto_Mayor_FuenteFinanciamiento.DisplayLayout.Bands[0];
            oBand0.Columns[0].Header.Caption = "Conformidad";
            oBand0.Columns[0].Width = 120;
            oBand0.Columns[1].Header.Caption = "Fecha";
            oBand0.Columns[1].Width = 100;
            oBand0.Columns[2].Header.Caption = "Importe";
            oBand0.Columns[2].Width = 110;
        }
        #endregion

        private void Grd_mvto_Mayor_FuenteFinanciamiento_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Override.FilterUIType = FilterUIType.FilterRow;

            FilterOperatorDropDownItems val = FilterOperatorDropDownItems.Contains;
            Grd_mvto_Mayor_FuenteFinanciamiento.DisplayLayout.Override.FilterOperatorDropDownItems = val;

            FilterOperatorDefaultValue val1 = FilterOperatorDefaultValue.Contains;
            Grd_mvto_Mayor_FuenteFinanciamiento.DisplayLayout.Override.FilterOperatorDefaultValue = val1;

            Grd_mvto_Mayor_FuenteFinanciamiento.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            Grd_mvto_Mayor_FuenteFinanciamiento.DisplayLayout.Scrollbars = Scrollbars.Both;
            Grd_mvto_Mayor_FuenteFinanciamiento.DisplayLayout.ColumnScrollbarSmallChange = 100;
            Grd_mvto_Mayor_FuenteFinanciamiento.DisplayLayout.UseScrollWindow = UseScrollWindow.None;
        }

        private void Exportar()
        {
            string strFile = "";
            if (this.SaveDocumento.ShowDialog() == DialogResult.OK)
            {
                strFile = this.SaveDocumento.FileName;
                DateTime start;
                TimeSpan timespan;

                start = DateTime.Now;

                try
                {
                    timespan = DateTime.Now.Subtract(start);

                    this.UltraGridExcelExporter1.Export(this.Grd_mvto_Mayor_FuenteFinanciamiento, strFile);

                }
                catch
                {
                    MessageBox.Show("Error", "Error");
                }
            }
        }

        private void Btn_ImprimirFormato_Click(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridRow oRow;
            oRow = this.Grd_mvto_Mayor_FuenteFinanciamiento.ActiveRow;
            string strNumConformidad = Convert.ToString(oRow.Cells[0].Value);

            Frt_Conformidad frt = new Frt_Conformidad();
            frt.ShowMe(strCodCompañia, strNumConformidad, strTipoOrden, strNumeroOrden);
        }

        private void Btn_Listar_Click(object sender, EventArgs e)
        {
            this.Exportar();
        }
    }
}