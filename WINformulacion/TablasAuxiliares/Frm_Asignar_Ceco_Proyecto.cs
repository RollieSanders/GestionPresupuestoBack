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
    public partial class Frm_Asignar_Ceco_Proyecto : DevExpress.XtraEditors.XtraForm
    {
        private SRformulacion.WCFformulacionEClient objWCF = new SRformulacion.WCFformulacionEClient();

        public Frm_Asignar_Ceco_Proyecto()
        {
            InitializeComponent();
            CargaInicial();
        }

        public DataTable DT_CentroCosto = new DataTable();
        public DataSet DS_Proyecto = new DataSet();
        private void CargaInicial()
        {
            Service.Proyecto SC = new Service.Proyecto();

            if (MyStuff.UsaWCF == true)
            {
                DS_Proyecto = objWCF.Ayuda_Proyecto_Spring_Help("000000");
            }
            else
            {
                DS_Proyecto = SC.Ayuda_Proyecto_Spring_Help("000000");
            }

          
            this.Txt_Proyecto.nombreDS = DS_Proyecto;

        }

        private void Txt_Proyecto_Leave(object sender, EventArgs e)
        {
            SeleccionaCentroCosto();

            Grd_mvto_CCAsignados.DataSource = null;
            Grd_mvto_CCXAsignar.DataSource = null;
        }

        private void ValorControl(string strNomProyecto)
        {
            Txt_NomProyecto.Text = strNomProyecto;
        }
        private void SeleccionaCentroCosto()
        {
            if (string.IsNullOrEmpty(Convert.ToString(this.Txt_Proyecto.Value)))
            {
                ValorControl(string.Empty);
            }
            else
            {
                if (DS_Proyecto.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DS_Proyecto.Tables[0].Rows)
                    {
                        if (Convert.ToString(row[0]) == Convert.ToString(this.Txt_Proyecto.Value))
                        {
                            //blnEncontrado = true;
                            ValorControl(Convert.ToString(row[1]).TrimEnd());
                            break;
                        }
                    }

                }
            }
        }

        public DataSet DS_CentroCosto_x_Elegir = new DataSet();
        public DataSet DS_CentroCostoElegidos = new DataSet();
        private void Lista_CentroCosto_x_Elegir()
        {
            Service.CentroCosto SC = new Service.CentroCosto();

            //Por Asignar
         
            if (MyStuff.UsaWCF == true)
            {
                 DS_CentroCosto_x_Elegir = objWCF.Lista_Ceco_Proyecto_x_Elegir("000000", Txt_Proyecto.Text.Trim());
            }
            else
            {
                DS_CentroCosto_x_Elegir = SC.Lista_Ceco_Proyecto_x_Elegir("000000", Txt_Proyecto.Text.Trim());
            }


            if (DS_CentroCosto_x_Elegir.Tables[0].Rows.Count > 0)
            {
                Grd_mvto_CCXAsignar.DataSource = DS_CentroCosto_x_Elegir.Tables[0];
                FormatoCCxAsignar();
            }
            else
            {
                Grd_mvto_CCXAsignar.DataSource = DS_CentroCosto_x_Elegir;
                FormatoCCxAsignar();
            }
        }
        private void Lista_CentroCosto_Elegidos()
        {
            Service.CentroCosto SC = new Service.CentroCosto();
            //Asignados
            

            if (MyStuff.UsaWCF == true)
            {
               DS_CentroCostoElegidos = objWCF.Lista_Ceco_Proyecto_Elegidos("000000", Txt_Proyecto.Text.Trim());
            }
            else
            {
                DS_CentroCostoElegidos = SC.Lista_Ceco_Proyecto_Elegidos("000000", Txt_Proyecto.Text.Trim());
            }

            if (DS_CentroCostoElegidos.Tables[0].Rows.Count > 0)
            {
                Grd_mvto_CCAsignados.DataSource = DS_CentroCostoElegidos.Tables[0];
                FormatoGridCCAsignados();
            }
            else
            {
                Grd_mvto_CCAsignados.DataSource = DS_CentroCostoElegidos;
                FormatoGridCCAsignados();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Lista_CentroCosto_Elegidos();
            Lista_CentroCosto_x_Elegir();
        }

        #region Formato Grid Fuente de Financiamiento por Asignar

        private void FormatoCCxAsignar()
        {
            this.Grd_mvto_CCXAsignar.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False; //'Infragistics.Win.DefaultableBoolean.Default
            //this.Grd_mvto_ClasXAsignar.DisplayLayout.Bands[0].Override.CellClickAction = CellClickAction.RowSelect;
            Infragistics.Win.UltraWinGrid.UltraGridBand oBand0;
            oBand0 = this.Grd_mvto_CCXAsignar.DisplayLayout.Bands[0];

            oBand0.Columns[0].Header.Caption = "Elegir";
            oBand0.Columns[0].Width = 40;
            oBand0.Columns[1].Header.Caption = "Cod. Clas.";
            oBand0.Columns[1].Width = 70;
            oBand0.Columns[2].Header.Caption = "Nombre";
            oBand0.Columns[2].Width = 200;
        }

        private void Grd_mvto_CCXAsignar_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Override.FilterUIType = FilterUIType.FilterRow;

            FilterOperatorDropDownItems val = FilterOperatorDropDownItems.Contains;
            Grd_mvto_CCXAsignar.DisplayLayout.Override.FilterOperatorDropDownItems = val;

            FilterOperatorDefaultValue val1 = FilterOperatorDefaultValue.Contains;
            Grd_mvto_CCXAsignar.DisplayLayout.Override.FilterOperatorDefaultValue = val1;

            Grd_mvto_CCXAsignar.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            Grd_mvto_CCXAsignar.DisplayLayout.Scrollbars = Scrollbars.Both;
            Grd_mvto_CCXAsignar.DisplayLayout.ColumnScrollbarSmallChange = 100;
            Grd_mvto_CCXAsignar.DisplayLayout.UseScrollWindow = UseScrollWindow.None;
            this.Grd_mvto_CCXAsignar.UseOsThemes = DefaultableBoolean.False;
        }
        #endregion
        #region Formato Grid Fuente de Financiamiento por Asignar

        private void FormatoGridCCAsignados()
        {
            this.Grd_mvto_CCAsignados.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False; //'Infragistics.Win.DefaultableBoolean.Default


            Infragistics.Win.UltraWinGrid.UltraGridBand oBand0;
            oBand0 = this.Grd_mvto_CCAsignados.DisplayLayout.Bands[0];

            oBand0.Columns[0].Header.Caption = "Elegir";
            oBand0.Columns[0].Width = 40;
            oBand0.Columns[1].Header.Caption = "Cod. Clas.";
            oBand0.Columns[1].Width = 70;
            oBand0.Columns[2].Header.Caption = "Nombre";
            oBand0.Columns[2].Width = 200;

        }
        private void Grd_mvto_CCAsignados_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Override.FilterUIType = FilterUIType.FilterRow;

            FilterOperatorDropDownItems val = FilterOperatorDropDownItems.Contains;
            Grd_mvto_CCAsignados.DisplayLayout.Override.FilterOperatorDropDownItems = val;

            FilterOperatorDefaultValue val1 = FilterOperatorDefaultValue.Contains;
            Grd_mvto_CCAsignados.DisplayLayout.Override.FilterOperatorDefaultValue = val1;

            Grd_mvto_CCAsignados.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            Grd_mvto_CCAsignados.DisplayLayout.Scrollbars = Scrollbars.Both;
            Grd_mvto_CCAsignados.DisplayLayout.ColumnScrollbarSmallChange = 100;
            Grd_mvto_CCAsignados.DisplayLayout.UseScrollWindow = UseScrollWindow.None;
            this.Grd_mvto_CCAsignados.UseOsThemes = DefaultableBoolean.False;
        }

        #endregion

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool bPase;
            Service.CentroCosto SC = new Service.CentroCosto();
            int UltimaFila = Grd_mvto_CCXAsignar.Rows.Count;
            int ContadorRecorrido = 0;
            if (UltimaFila <= 0)
            {
                MessageBox.Show("No es posible Agregar Clasificador",
                                 "Mensaje",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                return;

            }

            UltraGridColumn columnPase = Grd_mvto_CCXAsignar.DisplayLayout.Bands[0].Columns[0];
            UltraGridColumn columnNomCeco = Grd_mvto_CCXAsignar.DisplayLayout.Bands[0].Columns[2];
            UltraGridColumn columnCodCeco = Grd_mvto_CCXAsignar.DisplayLayout.Bands[0].Columns[1];
            UltraGridRow rowNew;
            List<Lista> oLista = new List<Lista>();
            foreach (UltraGridRow item in Grd_mvto_CCXAsignar.Rows)
            {
                ContadorRecorrido = ContadorRecorrido + 1;
                bPase = (bool)item.GetCellValue(columnPase);
                if (bPase)
                {
                    Lista lista = new Lista();
                    lista.strCodProyecto = (string)Txt_Proyecto.Text.Trim();
                    lista.strCodCeco = (string)item.GetCellValue(columnCodCeco);
                    oLista.Add(lista);
                    //SC.Graba_Proyecto_FuenteFinanciamiento((string)Txt_Proyecto.Text.Trim(), (string)item.GetCellValue(columnCodFuente));
                    //rowNew = this.Grd_mvto_FFAsignados.DisplayLayout.Bands[0].AddNew();
                    //rowNew.Cells[0].Value = false;
                    //rowNew.Cells[1].Value = (string)item.GetCellValue(columnCodFuente);
                    //rowNew.Cells[2].Value = (string)item.GetCellValue(columnNomFuente);
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
                    objWCF.Graba_CentroCosto_Proyecto(item.strCodCeco, item.strCodProyecto);
                }
                else
                {
                    SC.Graba_CentroCosto_Proyecto(item.strCodCeco, item.strCodProyecto);
                }
            }

            Lista_CentroCosto_Elegidos();
            Lista_CentroCosto_x_Elegir();
        }
        public class Lista
        {
            public bool dPaso { get; set; }
            public string strCodProyecto { get; set; }
            public string strCodCeco { get; set; }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            bool bPase;
            Service.CentroCosto SC = new Service.CentroCosto();
            int UltimaFila = Grd_mvto_CCAsignados.Rows.Count;

            if (UltimaFila <= 0)
            {
                MessageBox.Show("No es posible quitar Clasificador",
                                 "Mensaje",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                return;

            }
            UltraGridColumn columnPase = Grd_mvto_CCAsignados.DisplayLayout.Bands[0].Columns[0];
            UltraGridColumn columnNomCeco = Grd_mvto_CCAsignados.DisplayLayout.Bands[0].Columns[2];
            UltraGridColumn columnCodCeco = Grd_mvto_CCAsignados.DisplayLayout.Bands[0].Columns[1];

            UltraGridRow rowNew;

            List<Lista> oLista = new List<Lista>();
            int ContadorRecorrido = 0;
            foreach (UltraGridRow item in Grd_mvto_CCAsignados.Rows)
            {
                ContadorRecorrido = ContadorRecorrido + 1;
                bPase = (bool)item.GetCellValue(columnPase);
                if (bPase)
                {
                    Lista lista = new Lista();
                    lista.strCodProyecto = (string)Txt_Proyecto.Text.Trim();
                    lista.strCodCeco = (string)item.GetCellValue(columnCodCeco);
                    oLista.Add(lista);
                    //SC.Elimina_CentroCosto_Clasificador((string)Txt_Proyecto.Text.Trim(), (string)item.GetCellValue(columnCodFuente));
                    //rowNew = this.Grd_mvto_FFXAsignar.DisplayLayout.Bands[0].AddNew();
                    //rowNew.Cells[0].Value = false;
                    //rowNew.Cells[1].Value = (string)item.GetCellValue(columnCodFuente);
                    //rowNew.Cells[2].Value = (string)item.GetCellValue(columnNomFuente);
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
                    objWCF.Elimina_CentroCosto_Proyecto(item.strCodCeco, item.strCodProyecto);
                }
                else
                {
                    SC.Elimina_CentroCosto_Proyecto(item.strCodCeco, item.strCodProyecto);
                }
               
            }

            Lista_CentroCosto_Elegidos();
            Lista_CentroCosto_x_Elegir();
        }

        
    }
}
