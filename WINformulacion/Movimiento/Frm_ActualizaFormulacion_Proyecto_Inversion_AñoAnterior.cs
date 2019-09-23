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
    public partial class Frm_ActualizaFormulacion_Proyecto_Inversion_AñoAnterior : DevExpress.XtraEditors.XtraForm
    {
        public Boolean blnEligio = false;
        public int intNumeroOrdenes = 0;
        public DataTable DT_Proyecto = new DataTable();
        private Boolean blnMuestraFormato = true;
        private string strCodProyecto;
        private string strCodCentroCosto;
        private string strCodCompañia;
        private string strOrdenesElegidas;
        private SRformulacion.WCFformulacionEClient objWCF = new SRformulacion.WCFformulacionEClient();
        public Frm_ActualizaFormulacion_Proyecto_Inversion_AñoAnterior()
        {
            InitializeComponent();
        }

        public void ShowMe( string cCodCompañia,
                             string cCodProyecto,
                             string cCodCentroCosto,
                             string strNomProyecto,
                             string OrdenesElegidas
                            )
        {
            strCodCompañia = cCodCompañia;
            strCodProyecto = cCodProyecto;
            strCodCentroCosto = cCodCentroCosto;
            strOrdenesElegidas = OrdenesElegidas;
            this.Txt_Importe.Value = 0.01;
            this.Txt_NomProyecto.Value = cCodProyecto.TrimEnd() + "- " + strNomProyecto;
            this.Cbo_NomCompañia.Value = MyStuff.Empresa;
            this.Text = "Ordenes del Proyecto " + strNomProyecto;

            MostrarOrdenes();
            this.ShowDialog();


        }

        private void MostrarOrdenes()
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            SplashScreenManager.Default.SetWaitFormDescription("Recopilando informaciòn...");

            double dblImporte = Convert.ToDouble(this.Txt_Importe.Value);
            Service.DataGeneral SDG = new Service.DataGeneral();
            if (MyStuff.UsaWCF == true)
            {
                DT_Proyecto = objWCF.Lista_Proyecto_SaldoAñoAnterior(strCodCompañia,
                                                                                strCodProyecto,
                                                                                strCodCentroCosto,
                                                                                dblImporte,
                                                                                strOrdenesElegidas
                                                          ).Tables[0];
            }
            else
            {
                DT_Proyecto = SDG.Lista_Proyecto_SaldoAñoAnterior(strCodCompañia,
                                                                  strCodProyecto,
                                                                  strCodCentroCosto,
                                                                  dblImporte,
                                                                  strOrdenesElegidas
                                            ).Tables[0];
            }
            this.Grd_mvto_Mayor_FuenteFinanciamiento.DataSource = DT_Proyecto;
            if ( blnMuestraFormato == true  )
            {
                blnMuestraFormato = false;
                this.FormatoGrid();
            }
            
            this.AdicionaImagenesGrilla();
            SplashScreenManager.CloseForm();
        }

        #region "Formato"
        private void FormatoGrid()
        {
            //this.Grd_mvto_Mayor_FuenteFinanciamiento.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            //this.Grd_mvto_Mayor_FuenteFinanciamiento.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridBand oBand in this.Grd_mvto_Mayor_FuenteFinanciamiento.DisplayLayout.Bands)
            {
                if (oBand.Columns.Exists("MontoOrden"))
                {
                    oBand.Summaries.Add("Sum_MontoOrden", Infragistics.Win.UltraWinGrid.SummaryType.Sum, oBand.Columns["MontoOrden"], Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn);
                    oBand.Summaries["Sum_MontoOrden"].DisplayFormat = "{0:#,###,###,###,###.00}";
                    oBand.Summaries["Sum_MontoOrden"].Appearance.TextHAlign = HAlign.Right;
                }

                if (oBand.Columns.Exists("MontoConformidad"))
                {
                    oBand.Summaries.Add("Sum_MontoConformidad", Infragistics.Win.UltraWinGrid.SummaryType.Sum, oBand.Columns["MontoConformidad"], Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn);
                    oBand.Summaries["Sum_MontoConformidad"].DisplayFormat = "{0:#,###,###,###,###.00}";
                    oBand.Summaries["Sum_MontoConformidad"].Appearance.TextHAlign = HAlign.Right;
                }

                if (oBand.Columns.Exists("Saldo"))
                {
                    oBand.Summaries.Add("Sum_Saldo", Infragistics.Win.UltraWinGrid.SummaryType.Sum, oBand.Columns["Saldo"], Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn);
                    oBand.Summaries["Sum_Saldo"].DisplayFormat = "{0:#,###,###,###,###.00}";
                    oBand.Summaries["Sum_Saldo"].Appearance.TextHAlign = HAlign.Right;
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

            oBand0.Columns[0].Header.Caption = "Elegir";
            oBand0.Columns[0].Width = 40;
            oBand0.Columns[1].Header.Caption = "Compañia";
            oBand0.Columns[1].Width = 100;
            oBand0.Columns[2].Header.Caption = "Tipo";
            oBand0.Columns[2].Width = 50;
            oBand0.Columns[3].Header.Caption = "Número";
            oBand0.Columns[3].Width = 90;
            oBand0.Columns[4].Header.Caption = "Contrato";
            oBand0.Columns[4].Width = 110;
            oBand0.Columns[5].Header.Caption = "Fecha";
            oBand0.Columns[5].Width = 80;
            oBand0.Columns[6].Header.Caption = "Objeto Contratación";
            oBand0.Columns[6].Width = 350;
            oBand0.Columns[7].Header.Caption = "Orden";
            oBand0.Columns[7].Width = 100;
            oBand0.Columns[8].Header.Caption = "Conformidad";
            oBand0.Columns[8].Width = 100;
            oBand0.Columns[9].Header.Caption = "Saldo";
            oBand0.Columns[9].Width = 100;

            oBand0.Columns[1].Hidden = true;

        }

        private void AdicionaImagenesGrilla()
        {

            UltraGridBand band = this.Grd_mvto_Mayor_FuenteFinanciamiento.DisplayLayout.Bands[0];

            foreach (UltraGridRow row in band.GetRowEnumerator(GridRowType.DataRow))
            {
                RefrescarCeldaGrilla(row);
            }

        }

        private void RefrescarCeldaGrilla(Infragistics.Win.UltraWinGrid.UltraGridRow oRow)
        {
            //if (Convert.ToInt32(oRow.Cells[7].Value) !=0 )  // Monto Orden
            //{
            //    oRow.Cells[7].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            //    oRow.Cells[7].Appearance.Image = this.imageList2.Images[0];
            //    oRow.Cells[7].ButtonAppearance.Image = this.imageList2.Images[0];
            //    oRow.Cells[7].ButtonAppearance.TextHAlign = HAlign.Right;
            //}
            if (Convert.ToDouble(oRow.Cells[9].Value) != 0) // Monto Conformidad
            {
                oRow.Cells[8].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
                oRow.Cells[8].Appearance.Image = this.imageList2.Images[0];
                oRow.Cells[8].ButtonAppearance.Image = this.imageList2.Images[0];
                oRow.Cells[8].ButtonAppearance.TextHAlign = HAlign.Right;
            }

        }

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
            this.Grd_mvto_Mayor_FuenteFinanciamiento.UseOsThemes = DefaultableBoolean.False;

            e.Layout.Bands[0].Columns[7].CellAppearance.BackColor = Color.LightGray;
            e.Layout.Bands[0].Columns[7].CellAppearance.ForeColor = Color.Blue;
            e.Layout.Bands[0].Columns[7].CellButtonAppearance.BackColor = Color.LightGray;

            e.Layout.Bands[0].Columns[8].CellAppearance.BackColor = Color.LightGray;
            e.Layout.Bands[0].Columns[8].CellAppearance.ForeColor = Color.Blue;
            e.Layout.Bands[0].Columns[8].CellButtonAppearance.BackColor = Color.LightGray;

            e.Layout.Bands[0].Columns[9].CellAppearance.BackColor = Color.LightGray;
            e.Layout.Bands[0].Columns[9].CellAppearance.ForeColor = Color.Blue;
            e.Layout.Bands[0].Columns[9].CellButtonAppearance.BackColor = Color.LightGray;

        }





        #endregion

        private void Grd_mvto_Mayor_FuenteFinanciamiento_ClickCellButton(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.Index == 8)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow oRow;
                oRow = this.Grd_mvto_Mayor_FuenteFinanciamiento.ActiveRow;
                string strCodCompañia = "000000"; // Convert.ToString(oRow.Cells[1].Value);
                string strTipoOrden = Convert.ToString(oRow.Cells[2].Value);
                string strNumeroOrden = Convert.ToString(oRow.Cells[3].Value);
                //-- Lamar a conformidades
                WINformulacion.Frm_ActualizaFormulacion_Proyecto_Inversion_AñoAnterior_Conformidad frm = new WINformulacion.Frm_ActualizaFormulacion_Proyecto_Inversion_AñoAnterior_Conformidad();

                frm.ShowMe(strCodCompañia,
                            strTipoOrden,
                            strNumeroOrden
                          );
            }
        }

        private void Grd_mvto_Mayor_FuenteFinanciamiento_CellChange(object sender, CellEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridRow oRow;
            oRow = this.Grd_mvto_Mayor_FuenteFinanciamiento.ActiveRow;
            if (e.Cell.Column.Index == 0)
            {
                if (Convert.ToBoolean(oRow.Cells[0].Value) == false)
                {
                    oRow.Cells[0].Value = true;
                }
                else
                {
                    oRow.Cells[0].Value = false;
                }
                blnEligio = true;
                this.Btn_Aceptar.Enabled = true;
            }
        }

        private void Btn_Aceptar_Click(object sender, EventArgs e)
        {
            foreach (DataRow oRow in DT_Proyecto.Rows)
            {

                if (Convert.ToBoolean(oRow["bPase"]) == true)
                {
                    blnEligio = true;
                    intNumeroOrdenes = intNumeroOrdenes + 1;
                    //break;
                }
            }
            this.Close();

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
                    blnEligio = false;
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
            MostrarOrdenes();
        }

        private void Btn_Exportar_Click(object sender, EventArgs e)
        {
            this.Exportar();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

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


    }
}