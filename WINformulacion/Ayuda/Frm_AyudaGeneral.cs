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
using Infragistics.Win.UltraWinGrid;

namespace WINformulacion
{
    public partial class Frm_AyudaGeneral : DevExpress.XtraEditors.XtraForm
    {

    
        public string strValorDevueltoTexto = "";
        public string strValorDevuelto = "";
        public string strValorDevueltoVarios = "";


        string[] Registros = new string[11];
        int[] lnAnchoColumnas = new int[11];
        private string strAnchoColumnasAyuda = "150,70";
        int intPosicionCampoTexto = 1;
        int intPosicionValue = 1;
        bool blnPintaFormato = true;
        int[] arrayAnchoColumnas = new int[11];
        private DataTable DT_Grilla = new DataTable();
        public Boolean blnEligio = false;


        public Frm_AyudaGeneral()
        {
            InitializeComponent();
        }

        public void ShowMe(DataSet nombreDS,
                           string strCampoFiltro,
                           string strValorFiltro,
                           int iPosicionCampoTexto,
                           int iPosicionValue,
                           string vAnchoColumnasAyuda,
                           string strTextoAyuda,
                           int intLinea
                          )
        {
            
            this.Text = strTextoAyuda.TrimEnd() + " de la Linea: " + Convert.ToString(intLinea);
             strAnchoColumnasAyuda = vAnchoColumnasAyuda;
            intPosicionCampoTexto = iPosicionCampoTexto;
            intPosicionValue = iPosicionValue;
            DataTable nombreDT = new DataTable();
            
            if ( !string.IsNullOrEmpty(  strValorFiltro) )
            {
                try
                {
                    nombreDT = nombreDS.Tables[0].AsEnumerable().Where(row => row.Field<String>(strCampoFiltro) == strValorFiltro).CopyToDataTable();
                }
                catch
                {

                }
            }
            else
            {
                nombreDT = nombreDS.Tables[0];
            }
            this.grd_buscados.DataSource = nombreDT;

                if (nombreDT.Rows.Count > 0)
                {
                    this.cmdAceptar.Enabled = true;
                }
                else
                {
                    this.cmdAceptar.Enabled = false;
                }

                if (blnPintaFormato == true)
                {
                    blnPintaFormato = false;
                    FormatoGrid(nombreDT);
                }

            this.ShowDialog();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }


        private void Aceptar()
        {
            Infragistics.Win.UltraWinGrid.UltraGridRow oRow;
            oRow = this.grd_buscados.ActiveRow;
            strValorDevuelto = oRow.Cells[intPosicionValue].Text;
            strValorDevueltoTexto = oRow.Cells[intPosicionCampoTexto].Text;
            blnEligio = true;
            this.Close();
        }

        private void FormatoGrid(DataTable dt)
        {

            this.grd_buscados.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False; //'Infragistics.Win.DefaultableBoolean.Default
            string strColumna = "";
            int i = 0;
            int intRegistro = 0;

            if (this.strAnchoColumnasAyuda.Trim() != "")
            {
                strColumna = "";
                for (i = 0; i < this.strAnchoColumnasAyuda.TrimEnd().Length; i++)
                {
                    if (this.strAnchoColumnasAyuda.TrimEnd().Substring( i, 1) == ",")
                    {
                        arrayAnchoColumnas[intRegistro] = Convert.ToInt32(strColumna);
                        intRegistro = intRegistro + 1;
                        strColumna = "";
                    }
                    else
                    {
                        strColumna = strColumna + this.strAnchoColumnasAyuda.TrimEnd().Substring(i, 1);
                    }
                }
                arrayAnchoColumnas[intRegistro] = Convert.ToInt32(strColumna);
            }

            Infragistics.Win.UltraWinGrid.UltraGridBand oBand0;
            oBand0 = this.grd_buscados.DisplayLayout.Bands[0];
            int intCampos = 0;

            intCampos = (dt.Columns.Count - 1);

            for (i = 0; i <= intCampos; i++)
            {
                oBand0.Columns[i].Header.Caption = dt.Columns[i].ColumnName;
                oBand0.Columns[i].Width = arrayAnchoColumnas[i];
            }

        }


        private void grd_buscados_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
                this.cmdAceptar.Enabled = true;
        }

        private void grd_buscados_DoubleClickCell(object sender, Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs e)
        {
                this.Aceptar();
        }

        private void grd_buscados_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Override.FilterUIType = FilterUIType.FilterRow;
            FilterOperatorDropDownItems Val = FilterOperatorDropDownItems.Contains;
            grd_buscados.DisplayLayout.Override.FilterOperatorDropDownItems = Val;
            FilterOperatorDefaultValue val1 = FilterOperatorDefaultValue.Contains;
            grd_buscados.DisplayLayout.Override.FilterOperatorDefaultValue = val1;
            grd_buscados.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            grd_buscados.DisplayLayout.Scrollbars = Scrollbars.Both;
            grd_buscados.DisplayLayout.ColumnScrollbarSmallChange = 100;
            grd_buscados.DisplayLayout.UseScrollWindow = UseScrollWindow.None;
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            blnEligio = false;
            this.Close();
        }
    }
}