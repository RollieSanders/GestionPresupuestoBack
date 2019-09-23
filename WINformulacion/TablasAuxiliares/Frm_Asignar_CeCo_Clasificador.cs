using Infragistics.Win;
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

namespace WINformulacion
{
    public partial class Frm_Asignar_CeCo_Clasificador : DevExpress.XtraEditors.XtraForm
    {
        private SRformulacion.WCFformulacionEClient objWCF = new SRformulacion.WCFformulacionEClient();

        public Frm_Asignar_CeCo_Clasificador()
        {
            InitializeComponent();
            CargaInicial();
        }

        public DataTable DT_Clasificador = new DataTable();
        public DataSet DS_CentroCosto = new DataSet();
        private void CargaInicial()
        {
            Service.CentroCosto SC = new Service.CentroCosto();
            if (MyStuff.UsaWCF == true)
            {
                DS_CentroCosto = objWCF.Ayuda_CentroCosto("000000");
            }
            else
            {
                DS_CentroCosto = SC.Ayuda_CentroCosto("000000");
            }

            this.Txt_CentroCosto.nombreDS = DS_CentroCosto;

        }
        private void Txt_CentroCosto_Leave(object sender, EventArgs e)
        {
            SeleccionaCentroCosto();

            Grd_mvto_ClasAsignados.DataSource = null;
            Grd_mvto_ClasXAsignar.DataSource = null;
        }

        private void ValorControl(string strNomCeco)
        {
            Txt_NomCeCo.Text = strNomCeco;
        }

        private void SeleccionaCentroCosto()
        {
            if (string.IsNullOrEmpty(Convert.ToString(this.Txt_CentroCosto.Value)))
            {
                ValorControl(string.Empty);
            }
            else
            {
                if (DS_CentroCosto.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DS_CentroCosto.Tables[0].Rows)
                    {
                        if (Convert.ToString(row[1]) == Convert.ToString(this.Txt_CentroCosto.Value))
                        {
                            //blnEncontrado = true;
                            ValorControl(Convert.ToString(row[2]).TrimEnd());
                            break;
                        }
                    }

                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }
        public DataSet DS_CentroCostoClasificador_x_Elegir = new DataSet();
        public DataSet DS_CentroCostoClasificador_Elegidos = new DataSet();

        private void Lista_Ceco_Clasificador_x_Elegir()
        {
            Service.CentroCosto SC = new Service.CentroCosto();

            //Por Asignar
           
            if (MyStuff.UsaWCF == true)
            {
                 DS_CentroCostoClasificador_x_Elegir = objWCF.Lista_Ceco_Clasificador_x_Elegir("000000", Txt_CentroCosto.Text.Trim());
            }
            else
            {
                DS_CentroCostoClasificador_x_Elegir = SC.Lista_Ceco_Clasificador_x_Elegir("000000", Txt_CentroCosto.Text.Trim());
            }

            if (DS_CentroCostoClasificador_x_Elegir.Tables[0].Rows.Count > 0)
            {
                Grd_mvto_ClasXAsignar.DataSource = DS_CentroCostoClasificador_x_Elegir.Tables[0];
                FormatoGridClasxAsignar();
            }
            else
            {
                Grd_mvto_ClasXAsignar.DataSource = DS_CentroCostoClasificador_x_Elegir;
                FormatoGridClasxAsignar();
            }
        }
        private void Lista_Ceco_Clasificador_Elegidos()
        {
            Service.CentroCosto SC = new Service.CentroCosto();
            //Asignados
            

            if (MyStuff.UsaWCF == true)
            {
                 DS_CentroCostoClasificador_Elegidos = objWCF.Lista_Ceco_Clasificador_Elegidos("000000", Txt_CentroCosto.Text.Trim());
            }
            else
            {
                DS_CentroCostoClasificador_Elegidos = SC.Lista_Ceco_Clasificador_Elegidos("000000", Txt_CentroCosto.Text.Trim());
            }

            if (DS_CentroCostoClasificador_Elegidos.Tables[0].Rows.Count > 0)
            {
                Grd_mvto_ClasAsignados.DataSource = DS_CentroCostoClasificador_Elegidos.Tables[0];
                FormatoGridClasAsignados();
            }
            else
            {
                Grd_mvto_ClasAsignados.DataSource = DS_CentroCostoClasificador_Elegidos;
                FormatoGridClasAsignados();
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {


            Lista_Ceco_Clasificador_Elegidos();
            Lista_Ceco_Clasificador_x_Elegir();
        }

        #region Formato Grid Clasificador por Asignar

        private void FormatoGridClasxAsignar()
        {
            this.Grd_mvto_ClasXAsignar.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False; //'Infragistics.Win.DefaultableBoolean.Default
            //this.Grd_mvto_ClasXAsignar.DisplayLayout.Bands[0].Override.CellClickAction = CellClickAction.RowSelect;
            Infragistics.Win.UltraWinGrid.UltraGridBand oBand0;
            oBand0 = this.Grd_mvto_ClasXAsignar.DisplayLayout.Bands[0];

            oBand0.Columns[0].Header.Caption = "Elegir";
            oBand0.Columns[0].Width = 40;
            oBand0.Columns[1].Header.Caption = "Cod. Clas.";
            oBand0.Columns[1].Width = 70;
            oBand0.Columns[2].Header.Caption = "Nombre";
            oBand0.Columns[2].Width = 200;




        }
        private void Grd_mvto_ClasXAsignar_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Override.FilterUIType = FilterUIType.FilterRow;

            FilterOperatorDropDownItems val = FilterOperatorDropDownItems.Contains;
            Grd_mvto_ClasXAsignar.DisplayLayout.Override.FilterOperatorDropDownItems = val;

            FilterOperatorDefaultValue val1 = FilterOperatorDefaultValue.Contains;
            Grd_mvto_ClasXAsignar.DisplayLayout.Override.FilterOperatorDefaultValue = val1;

            Grd_mvto_ClasXAsignar.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            Grd_mvto_ClasXAsignar.DisplayLayout.Scrollbars = Scrollbars.Both;
            Grd_mvto_ClasXAsignar.DisplayLayout.ColumnScrollbarSmallChange = 100;
            Grd_mvto_ClasXAsignar.DisplayLayout.UseScrollWindow = UseScrollWindow.None;
            this.Grd_mvto_ClasXAsignar.UseOsThemes = DefaultableBoolean.False;


        }

        #endregion

        #region Formato Grid Clasificador por Asignar

        private void FormatoGridClasAsignados()
        {
            this.Grd_mvto_ClasAsignados.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False; //'Infragistics.Win.DefaultableBoolean.Default


            Infragistics.Win.UltraWinGrid.UltraGridBand oBand0;
            oBand0 = this.Grd_mvto_ClasAsignados.DisplayLayout.Bands[0];

            oBand0.Columns[0].Header.Caption = "Elegir";
            oBand0.Columns[0].Width = 40;
            oBand0.Columns[1].Header.Caption = "Cod. Clas.";
            oBand0.Columns[1].Width = 70;
            oBand0.Columns[2].Header.Caption = "Nombre";
            oBand0.Columns[2].Width = 200;




        }
        private void Grd_mvto_ClasAsignados_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Override.FilterUIType = FilterUIType.FilterRow;

            FilterOperatorDropDownItems val = FilterOperatorDropDownItems.Contains;
            Grd_mvto_ClasAsignados.DisplayLayout.Override.FilterOperatorDropDownItems = val;

            FilterOperatorDefaultValue val1 = FilterOperatorDefaultValue.Contains;
            Grd_mvto_ClasAsignados.DisplayLayout.Override.FilterOperatorDefaultValue = val1;

            Grd_mvto_ClasAsignados.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            Grd_mvto_ClasAsignados.DisplayLayout.Scrollbars = Scrollbars.Both;
            Grd_mvto_ClasAsignados.DisplayLayout.ColumnScrollbarSmallChange = 100;
            Grd_mvto_ClasAsignados.DisplayLayout.UseScrollWindow = UseScrollWindow.None;
            this.Grd_mvto_ClasAsignados.UseOsThemes = DefaultableBoolean.False;

            //e.Layout.Bands[0].Columns[0].CellAppearance.BackColor = Color.LightGray;
            //e.Layout.Bands[0].Columns[0].CellAppearance.ForeColor = Color.Blue;
            //e.Layout.Bands[0].Columns[0].CellButtonAppearance.BackColor = Color.LightGray;

            //e.Layout.Bands[0].Columns[1].CellAppearance.BackColor = Color.LightGray;
            //e.Layout.Bands[0].Columns[1].CellAppearance.ForeColor = Color.Blue;
            //e.Layout.Bands[0].Columns[1].CellButtonAppearance.BackColor = Color.LightGray;
        }
        #endregion

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool bPase;
            Service.CentroCosto SC = new Service.CentroCosto();
            int UltimaFila = Grd_mvto_ClasXAsignar.Rows.Count;
            int ContadorRecorrido = 0;
            if (UltimaFila <= 0)
            {
                MessageBox.Show("No es posible Agregar Clasificador",
                                 "Mensaje",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                return;

            }

            UltraGridColumn columnPase = Grd_mvto_ClasXAsignar.DisplayLayout.Bands[0].Columns[0];
            UltraGridColumn columnNomClasificador = Grd_mvto_ClasXAsignar.DisplayLayout.Bands[0].Columns[2];
            UltraGridColumn columnCodClasificador = Grd_mvto_ClasXAsignar.DisplayLayout.Bands[0].Columns[1];
            UltraGridRow rowNew;
            List<Lista> oLista = new List<Lista>();

            foreach (UltraGridRow item in Grd_mvto_ClasXAsignar.Rows)
            {
                ContadorRecorrido = ContadorRecorrido + 1;
                bPase = (bool)item.GetCellValue(columnPase);
                if (bPase)
                {
                    Lista lista = new Lista();
                    lista.dPaso = false;
                    lista.strCodCeco = (string)Txt_CentroCosto.Text.Trim();
                    lista.strCodClasificador = (string)item.GetCellValue(columnCodClasificador);
                    oLista.Add(lista);
                    //SC.Graba_CentroCosto_Clasificador((string)Txt_CentroCosto.Text.Trim(), (string)item.GetCellValue(columnCodClasificador));
                    //rowNew = this.Grd_mvto_ClasAsignados.DisplayLayout.Bands[0].AddNew();
                    //rowNew.Cells[0].Value = false;
                    //rowNew.Cells[1].Value = (string)item.GetCellValue(columnCodClasificador);
                    //rowNew.Cells[2].Value = (string)item.GetCellValue(columnNomClasificador);
                    //item.Delete(false);
                    //if (ContadorRecorrido == UltimaFila)
                    //{

                    //    return;
                    //}
                    //this.Grd_mvto_ClasXAsignar.PerformAction(UltraGridAction.CommitRow);
                }


            }

            foreach (Lista item in oLista)
            {
                if (MyStuff.UsaWCF == true)
                {
                    objWCF.Graba_CentroCosto_Clasificador(item.strCodCeco, item.strCodClasificador);
                }
                else
                {
                    SC.Graba_CentroCosto_Clasificador(item.strCodCeco, item.strCodClasificador);
                }
            }



            Lista_Ceco_Clasificador_Elegidos();
            Lista_Ceco_Clasificador_x_Elegir();

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            bool bPase;
            Service.CentroCosto SC = new Service.CentroCosto();
            int UltimaFila = Grd_mvto_ClasAsignados.Rows.Count;

            if (UltimaFila <= 0)
            {
                MessageBox.Show("No es posible quitar Clasificador",
                                 "Mensaje",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                return;

            }
            UltraGridColumn columnPase = Grd_mvto_ClasAsignados.DisplayLayout.Bands[0].Columns[0];
            UltraGridColumn columnNomClasificador = Grd_mvto_ClasAsignados.DisplayLayout.Bands[0].Columns[2];
            UltraGridColumn columnCodClasificador = Grd_mvto_ClasAsignados.DisplayLayout.Bands[0].Columns[1];

            UltraGridRow rowNew;

            List<Lista> oLista = new List<Lista>();

            int ContadorRecorrido = 0;
            foreach (UltraGridRow item in Grd_mvto_ClasAsignados.Rows)
            {
                ContadorRecorrido = ContadorRecorrido + 1;
                bPase = (bool)item.GetCellValue(columnPase);
                if (bPase)
                {
                    Lista lista = new Lista();
                    lista.dPaso = false;
                    lista.strCodCeco = (string)Txt_CentroCosto.Text.Trim();
                    lista.strCodClasificador = (string)item.GetCellValue(columnCodClasificador);
                    oLista.Add(lista);
                    //SC.Elimina_CentroCosto_Clasificador((string)Txt_CentroCosto.Text.Trim(), (string)item.GetCellValue(columnCodClasificador));
                    //rowNew = this.Grd_mvto_ClasXAsignar.DisplayLayout.Bands[0].AddNew();
                    //rowNew.Cells[0].Value = false;
                    //rowNew.Cells[1].Value = (string)item.GetCellValue(columnCodClasificador);
                    //rowNew.Cells[2].Value = (string)item.GetCellValue(columnNomClasificador);
                    //item.Delete(false);
                    //if (ContadorRecorrido == UltimaFila)
                    //{
                    //    return;
                    //}
                }
            }

            foreach (Lista item in oLista)
            {
                if (MyStuff.UsaWCF == true)
                {
                    objWCF.Elimina_CentroCosto_Clasificador(item.strCodCeco, item.strCodClasificador);
                }
                else
                {
                    SC.Elimina_CentroCosto_Clasificador(item.strCodCeco, item.strCodClasificador);
                }
               
            }

            Lista_Ceco_Clasificador_Elegidos();
            Lista_Ceco_Clasificador_x_Elegir();
        }
        public class Lista
        {
            public bool dPaso { get; set; }
            public string strCodCeco { get; set; }
            public string strCodClasificador { get; set; }
        }

        private void Grd_mvto_ClasXAsignar_CellChange(object sender, CellEventArgs e)
        {

        }

        private void Grd_mvto_ClasAsignados_CellChange(object sender, CellEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridRow oRow;
            oRow = this.Grd_mvto_ClasAsignados.ActiveRow;
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

            }
        }
    }
}
