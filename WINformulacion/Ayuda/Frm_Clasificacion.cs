using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infragistics.Win;
using System.IO;

namespace WINformulacion
{
    public partial class Frm_Clasificacion : DevExpress.XtraEditors.XtraForm
    {
        public bool blnEligio = false;
        public string strNomClaseGasto = "";
        public string strCodClasificacion = "";
        public string strNomClasificacion = "";
        public string strCodCuentaContable = "";
        public string strNomCuentaContable;

        private SRformulacion.WCFformulacionEClient objWCF = new SRformulacion.WCFformulacionEClient();

        public Frm_Clasificacion()
        {
            InitializeComponent();
        }

        public bool blnMostrarFormato = true;
        public DataTable DT_Clasificador = new DataTable();

        public void Showme(string strCodCompañia, string strCodProyecto, int Fila, string strCodClaseGasto, string strCodCentroCosto )
        {
            this.Text = "Seleccionar Clasificador y Cuenta para la fila: " + Convert.ToString(Fila);
            Service.Clasificador SC = new Service.Clasificador();

            switch (strCodClaseGasto)
            {
                case "":
                    strCodClaseGasto = "01/02/";
                    break;
                case "01":
                    strCodClaseGasto = "01/";
                    break;
                case "02":
                    strCodClaseGasto = "02/";
                    break;
            }

            if (MyStuff.UsaWCF == true)
            {
                DT_Clasificador = objWCF.Ayuda_Clasificador_inversion(strCodCompañia, strCodProyecto, strCodClaseGasto, strCodCentroCosto).Tables[0];
            }
            else
            {
                DT_Clasificador = SC.Ayuda_Clasificador_inversion(strCodCompañia, strCodProyecto, strCodClaseGasto, strCodCentroCosto).Tables[0];
            }

            //DT_Clasificador = SC.Ayuda_Clasificador_inversion(strCodCompañia, strCodProyecto, strCodClaseGasto, strCodCentroCosto).Tables[0];
            if (DT_Clasificador.Rows.Count > 0)
            {
                Grd_Buscados.DataSource = DT_Clasificador;
                if (blnMostrarFormato == true)
                {
                    blnMostrarFormato = false;
                    FormatoGrid();
                }

            }
            ShowDialog();
        }
       
 
        private void FormatoGrid()
        {
            Grd_Buscados.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            Grd_Buscados.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;

            Infragistics.Win.UltraWinGrid.UltraGridBand oBandPantalla;
            oBandPantalla = Grd_Buscados.DisplayLayout.Bands[0];

            oBandPantalla.Columns[1].Header.Caption = "Clase Gasto";
            oBandPantalla.Columns[1].Width = 110;
            oBandPantalla.Columns[2].Header.Caption = "Clasificador";
            oBandPantalla.Columns[2].Width = 100;
            oBandPantalla.Columns[3].Header.Caption = "Nombre";
            oBandPantalla.Columns[3].Width = 250;
            oBandPantalla.Columns[4].Header.Caption = "Cuenta Contable";
            oBandPantalla.Columns[4].Width = 100;
            oBandPantalla.Columns[5].Header.Caption = "Nombre";
            oBandPantalla.Columns[5].Width = 290;

            oBandPantalla.Columns[0].Hidden = true;
        }

         
        private void Aceptar()
        {
            Infragistics.Win.UltraWinGrid.UltraGridRow oRow;
            oRow = this.Grd_Buscados.ActiveRow;
            strNomClaseGasto = Convert.ToString(oRow.Cells[1].Value);
            strCodClasificacion = Convert.ToString(oRow.Cells[2].Value);
            strNomClasificacion = Convert.ToString(oRow.Cells[3].Value);
            strCodCuentaContable = Convert.ToString(oRow.Cells[4].Value);
            strNomCuentaContable = Convert.ToString(oRow.Cells[5].Value);
            blnEligio = true;
            this.Close();
        }

      

        private void Grd_Buscados_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Override.FilterUIType = FilterUIType.FilterRow;

            FilterOperatorDropDownItems val = FilterOperatorDropDownItems.Contains;
            Grd_Buscados.DisplayLayout.Override.FilterOperatorDropDownItems = val;

            FilterOperatorDefaultValue val1 = FilterOperatorDefaultValue.Contains;
            Grd_Buscados.DisplayLayout.Override.FilterOperatorDefaultValue = val1;

            Grd_Buscados.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            Grd_Buscados.DisplayLayout.Scrollbars = Scrollbars.Both;
            Grd_Buscados.DisplayLayout.ColumnScrollbarSmallChange = 100;
            Grd_Buscados.DisplayLayout.UseScrollWindow = UseScrollWindow.None;
            //Grd_Buscados.DisplayLayout.UseFixedHeaders = true;
        }

        private void Grd_Buscados_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            this.Aceptar();
        }

        private void Btn_Aceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.blnEligio = false;
            Close();
        }

        private void Grd_Buscados_ClickCellButton(object sender, CellEventArgs e)
        {
            this.Btn_Aceptar.Enabled = true;
        }

        private void Grd_Buscados_Click(object sender, EventArgs e)
        {
            this.Btn_Aceptar.Enabled = true;
        }
    }
}
