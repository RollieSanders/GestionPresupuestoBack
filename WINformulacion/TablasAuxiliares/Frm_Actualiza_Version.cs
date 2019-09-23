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
using Infragistics.Win.UltraWinGrid;

namespace WINformulacion
{
    public partial class Frm_Actualiza_Version : DevExpress.XtraEditors.XtraForm
    {
        DataSet DS_Grilla = new DataSet();
        Model.Formulacion_Cabecera oFC_Modelo = new Model.Formulacion_Cabecera();
        int intIidFormulacion_Cabecera = 0;

        private SRformulacion.WCFformulacionEClient objWCF = new SRformulacion.WCFformulacionEClient();

        public Frm_Actualiza_Version()
        {
            InitializeComponent();

            btn_Nuevo.Image = imageCollection16.Images[0];
            btn_Grabar.Image = imageCollection16.Images[1];
            btn_Eliminar.Image = imageCollection16.Images[2];
            btn_DesHacer.Image = imageCollection16.Images[3];
            btn_Listar.Image = imageCollection16.Images[4];
            Mostra_Combo_TipoDocumento();
            Service.Formulacion_Cabecera FC = new Service.Formulacion_Cabecera();
            if (MyStuff.UsaWCF == true)
            {
                 DS_Grilla = objWCF.Lista_FormulacionCabecera(MyStuff.AñoProceso);
            }
            else
            {
                DS_Grilla = FC.Lista_FormulacionCabecera(MyStuff.AñoProceso);
            }
          

            if (DS_Grilla.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow oRow in DS_Grilla.Tables[0].Rows)
                {
                    oFC_Modelo.IidFormulacion_Cabecera = (int)oRow["iIdFormulacion_Cabecera"];
                    oFC_Modelo.CañoProceso = (string)oRow["cAñoProceso"];
                    oFC_Modelo.Cversion = (string)oRow["cVersion"];
                    oFC_Modelo.DfecFormulacion = (DateTime)oRow["dFecFormulacion"];
                    oFC_Modelo.Tnota = (string)oRow["tNota"];
                    oFC_Modelo.Bactivo = (bool)oRow["bActivo"];
                    oFC_Modelo.cCodTipoDocumento = (string)(oRow["cCodTipoDocumento"]);
                    oFC_Modelo.cNumDocumento = (string)(oRow["cNumDocumento"]);
                    intIidFormulacion_Cabecera = oFC_Modelo.IidFormulacion_Cabecera;
                    mostrarDocumento(oFC_Modelo);
                    break;
                }
            }
            else
            {
                AccionBotones(true, true, true, true, true);
                this.txt_AñoProceso.Text = MyStuff.AñoProceso;
                this.txt_AñoProceso.Focus();
            }

            this.grd_mvto_ListaVersiones.DataSource = DS_Grilla;
            pintarGrilla();
            MostrarIconoGrilla();
        }

        public void mostrarDocumento(Model.Formulacion_Cabecera obj) {
            this.txt_AñoProceso.Text = MyStuff.AñoProceso;// obj.CañoProceso;
            this.txt_Version.Value = obj.Cversion;
            this.cbo_CodTipoDocumento.SelectedValue = obj.cCodTipoDocumento;
            this.txt_NumDocumento.Value = obj.cNumDocumento;
            this.edt_Nota.Value = obj.Tnota;
            if (obj.Bactivo) {
                this.btn_Grabar.Enabled = false;
                this.btn_Nuevo.Enabled = false;
                this.btn_Eliminar.Enabled = false;
                this.btn_DesHacer.Enabled = false;
            }
            else {
                this.btn_Grabar.Enabled = true;
                this.btn_Nuevo.Enabled = true;
                this.btn_Eliminar.Enabled = true;
                this.btn_DesHacer.Enabled = true;
            }
        }
        public void pintarGrilla() {
            this.grd_mvto_ListaVersiones.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grd_mvto_ListaVersiones.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;

            this.grd_mvto_ListaVersiones.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False;


            Infragistics.Win.UltraWinGrid.UltraGridBand oBand0;
            oBand0 = this.grd_mvto_ListaVersiones.DisplayLayout.Bands[0];


            //oBand0.Columns[0].Header.Caption = "";
            //oBand0.Columns[0].Width = 20;
            //oBand0.Columns[0].Header.Appearance.ImageBackgroundAlpha = Infragistics.Win.Alpha.Transparent;
            //oBand0.Columns[0].Header.Appearance.Image = this.imageList2.Images[3];
            //oBand0.Columns[0].Header.Appearance.ImageHAlign = Infragistics.Win.HAlign.Right;
            oBand0.Columns[1].Header.Caption = "Periodo";
            oBand0.Columns[1].Width = 40;
            oBand0.Columns[2].Header.Caption = "Versión";
            oBand0.Columns[2].Width = 50;
            oBand0.Columns[3].Header.Caption = "Fec. Formulación";
            oBand0.Columns[3].Width = 100;
            oBand0.Columns[7].Header.Caption = "Tipo Documento";
            oBand0.Columns[7].Width = 140;
            oBand0.Columns[8].Header.Caption = "Número";
            oBand0.Columns[8].Width = 100;
            oBand0.Columns[4].Header.Caption = "Nota";
            oBand0.Columns[4].Width = 285;
            oBand0.Columns[0].Hidden = true;
            oBand0.Columns[5].Hidden = true;
            oBand0.Columns[6].Hidden = true;
        }

        public void Mostra_Combo_TipoDocumento() {
            Service.TipoDocumento TD = new Service.TipoDocumento();

            
            if (MyStuff.UsaWCF == true)
            {
                 this.cbo_CodTipoDocumento.CargaDS(objWCF.Combo_TipoDocumento());
            }
            else
            {
                this.cbo_CodTipoDocumento.CargaDS(TD.Combo_TipoDocumento());
            }
        }

        private void RegistroMovConceptos() {
            grd_mvto_ListaVersiones.DisplayLayout.Bands[0].AddNew();
            PintarDatosRegistro();
        }

        public void AccionBotones(bool blnNuevo,
                                  bool blnGrabar,
                                  bool blnDesHacer,
                                  bool blnEliminar,
                                  bool blnListar) {
            this.btn_Nuevo.Enabled = blnNuevo;
            this.btn_Grabar.Enabled = blnGrabar;
            this.btn_DesHacer.Enabled = blnDesHacer;
            this.btn_Eliminar.Enabled = blnEliminar;
            this.btn_Listar.Enabled = blnListar;
        }

        private bool VerificaIngresoMovimiento() {
            bool blnVerifica = true;
            const int iTipoMensaje = 0;
            string strMensaje = string.Empty;
            try
            {
                if (String.IsNullOrWhiteSpace(txt_AñoProceso.Text.Trim()))
                {
                    blnVerifica = false;
                    strMensaje = "Debe ingresar el Periodo del Documento";
                }

                if (String.IsNullOrWhiteSpace(cbo_CodTipoDocumento.SelectedValue.ToString().Trim()))
                {
                    blnVerifica = false;
                    strMensaje = "Debe ingresar el Tipo del Documento";
                }

                if (String.IsNullOrWhiteSpace(txt_NumDocumento.Text.ToString().Trim()))
                {
                    blnVerifica = false;
                    strMensaje = "Debe ingresar el Número del Documento";
                }

                if (!blnVerifica)
                {
                    if (iTipoMensaje == 0)
                    {
                        MessageBox.Show(strMensaje,
                                    "Error", MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Error
                                   );
                    }
                    else
                    {
                        DialogResult dialog = MessageBox.Show(strMensaje, "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                        if (dialog == DialogResult.Yes)
                        {
                            blnVerifica = true;
                        }

                    }
                }


            }
            catch (Exception exp)
            {

                MessageBox.Show(exp.Message.ToString(), "Mensaje");
            }
            return blnVerifica;
        }

        public void PintarDatosRegistro() {
            Infragistics.Win.UltraWinGrid.UltraGridRow oRow;
            oRow = grd_mvto_ListaVersiones.ActiveRow;
            oRow.Cells[0].Value = oFC_Modelo.IidFormulacion_Cabecera;
            oRow.Cells[1].Value = oFC_Modelo.CañoProceso;
            oRow.Cells[2].Value = oFC_Modelo.Cversion;
            oRow.Cells[3].Value = oFC_Modelo.DfecFormulacion;
            oRow.Cells[4].Value = oFC_Modelo.Tnota;
            oRow.Cells[5].Value = oFC_Modelo.Bactivo;
            oRow.Cells[6].Value = oFC_Modelo.cCodTipoDocumento;
            oRow.Cells[7].Value = cbo_CodTipoDocumento.Text;
            oRow.Cells[8].Value = oFC_Modelo.cNumDocumento;
            
        }
        private void MostrarIconoGrilla() {

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow oRow in this.grd_mvto_ListaVersiones.Rows)
            {
                if (!Convert.ToBoolean(oRow.Cells[5].Value))
                {
                    MostrarIconoGrilla_Row(oRow);
                }
            }

        }
        private void MostrarIconoGrilla_Row(Infragistics.Win.UltraWinGrid.UltraGridRow oRow) {
            oRow.Cells[0].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            oRow.Cells[0].Appearance.Image = this.imageList2.Images[3];
            oRow.Cells[0].ButtonAppearance.Image = this.imageList2.Images[3];
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            intIidFormulacion_Cabecera = 0;
            mostrarDocumento(new Model.Formulacion_Cabecera());
            AccionBotones(false, true, true, false, false);
            this.txt_AñoProceso.Focus();
        }

        private void btn_DesHacer_Click(object sender, EventArgs e)
        {
            mostrarDocumento(oFC_Modelo);
            if (oFC_Modelo.cCodTipoDocumento.Trim() == string.Empty) {
                intIidFormulacion_Cabecera = 0;
                AccionBotones(false, true, true, false, false);
            }
            else {
                intIidFormulacion_Cabecera = oFC_Modelo.IidFormulacion_Cabecera;
                AccionBotones(true, true, true, true, true);
            }
            this.txt_AñoProceso.Focus();
        }

        private void grd_mvto_ListaVersiones_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridRow oRow;
            oRow = this.grd_mvto_ListaVersiones.ActiveRow;
            if (e.Cell.Column.Index == 0) {
                //string strRuta = "" + oFC_Modelo.CañoProceso.Trim();
                //Dim frm As New frm_Adjunto
                //frm.ShowMe(intIdPac_Cabecera, 1, strRuta, grd_mvto_DocumntoComite)

            }
        }

        private void grd_mvto_ListaVersiones_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
        {
            if (DS_Grilla.Tables[0].Rows.Count > 0) {
                Infragistics.Win.UltraWinGrid.UltraGridRow oRow;
                oRow = this.grd_mvto_ListaVersiones.ActiveRow;
                if (!(oRow.Cells[0].Value == DBNull.Value)) {
                    if ((int)(oRow.Cells[0].Value) > 0) {
                        oFC_Modelo.IidFormulacion_Cabecera = Convert.ToInt32(oRow.Cells[0].Text);
                        oFC_Modelo.CañoProceso = (string)(oRow.Cells[1].Text);
                        oFC_Modelo.Cversion = (string)(oRow.Cells[2].Text);
                        oFC_Modelo.DfecFormulacion = Convert.ToDateTime(oRow.Cells[3].Text);
                        oFC_Modelo.cCodTipoDocumento = (string)(oRow.Cells[6].Text);
                        oFC_Modelo.cNumDocumento = (string)(oRow.Cells[8].Text);
                        oFC_Modelo.Tnota = (string)(oRow.Cells[4].Text);
                        oFC_Modelo.Bactivo = Convert.ToBoolean(oRow.Cells[5].Text);
                        intIidFormulacion_Cabecera = oFC_Modelo.IidFormulacion_Cabecera;
                        mostrarDocumento(oFC_Modelo);
                    }
                    //}
                }
            }

            
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            DialogResult intEliminaRegistro = MessageBox.Show("Desea Eliminar el Registro",
                                                                "Advertencia", MessageBoxButtons.YesNo,
                                                                MessageBoxIcon.Exclamation
                                                               );
            if (intEliminaRegistro == DialogResult.Yes)
            {
                Service.Formulacion_Cabecera oFC_Service = new Service.Formulacion_Cabecera();
                Infragistics.Win.UltraWinGrid.UltraGridRow oRow;
                oRow = this.grd_mvto_ListaVersiones.ActiveRow;
                bool blnResultado;
                if (MyStuff.UsaWCF == true)
                {
                     blnResultado = objWCF.elimina_mvto_Formulacion_Cabecera(oFC_Modelo.IidFormulacion_Cabecera);//metodo
                }
                else
                {
                    blnResultado = oFC_Service.elimina_mvto_Formulacion_Cabecera(oFC_Modelo.IidFormulacion_Cabecera);//metodo
                }
                
                if (!blnResultado)
                {
                    MessageBox.Show("Error: No se pudo eliminar el registro");
                }
                else
                {
                    oRow.Delete(false);
                }
                    if (grd_mvto_ListaVersiones.Rows.Count > 0)
                    {
                        oRow = this.grd_mvto_ListaVersiones.ActiveRow;
                        if (oRow is null)
                        {
                            oRow = this.grd_mvto_ListaVersiones.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.First);
                        }
                        intIidFormulacion_Cabecera = oFC_Modelo.IidFormulacion_Cabecera;
                        oFC_Modelo.IidFormulacion_Cabecera = Convert.ToInt32(oRow.Cells[0].Text);
                        oFC_Modelo.CañoProceso = Convert.ToString(oRow.Cells[1].Text);
                        oFC_Modelo.Cversion = Convert.ToString(oRow.Cells[2].Text);
                        oFC_Modelo.DfecFormulacion = Convert.ToDateTime(oRow.Cells[3].Text);
                        oFC_Modelo.cCodTipoDocumento = Convert.ToString(oRow.Cells[6].Text);
                        oFC_Modelo.cNumDocumento = Convert.ToString(oRow.Cells[8].Text);
                        oFC_Modelo.Tnota = Convert.ToString(oRow.Cells[4].Text);
                        mostrarDocumento(oFC_Modelo);
                        AccionBotones(true, true, true, true, true);
                    }
                    else
                    {
                        intIidFormulacion_Cabecera = 0;
                        mostrarDocumento(new Model.Formulacion_Cabecera());
                        AccionBotones(false, true, true, false, false);
                        this.txt_AñoProceso.Focus();
                    }
                


            }
        }

        private void grd_mvto_ListaVersiones_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Override.FilterEvaluationTrigger = FilterEvaluationTrigger.OnCellValueChange;
            e.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand;
            e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.StartsWith;
            e.Layout.Override.FilterClearButtonLocation = FilterClearButtonLocation.RowAndCell;
            e.Layout.Override.FilterRowAppearance.BackColor = Color.LightYellow;
            e.Layout.Override.FilterRowPromptAppearance.BackColorAlpha = Alpha.Opaque;
            e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.FilterRow;
            e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(233, 242, 199);
            e.Layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;

            this.grd_mvto_ListaVersiones.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            this.grd_mvto_ListaVersiones.DisplayLayout.Scrollbars = Scrollbars.Both;
            this.grd_mvto_ListaVersiones.DisplayLayout.ColumnScrollbarSmallChange = 100;
            this.grd_mvto_ListaVersiones.DisplayLayout.UseScrollWindow = UseScrollWindow.None;
            this.grd_mvto_ListaVersiones.DisplayLayout.UseFixedHeaders = true;

            this.grd_mvto_ListaVersiones.DisplayLayout.ScrollBarLook.MinMaxButtonsVisible = true;

            this.grd_mvto_ListaVersiones.DisplayLayout.ScrollBarLook.ScrollBarArrowStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarArrowStyle.BothAtRightBottom;
            this.grd_mvto_ListaVersiones.DisplayLayout.ScrollBarLook.Appearance.BackGradientStyle = GradientStyle.Vertical;
        }

        private void btn_Grabar_Click(object sender, EventArgs e)
        {
            bool blnActualiza =false;
            if (VerificaIngresoMovimiento())
            {

                if (!btn_Nuevo.Enabled)
                {
                    oFC_Modelo.IidFormulacion_Cabecera = 0;
                }

                oFC_Modelo.CañoProceso = Convert.ToString(this.txt_AñoProceso.Text);
                oFC_Modelo.Cversion = this.txt_Version.Text;
                oFC_Modelo.cCodTipoDocumento = Convert.ToString(this.cbo_CodTipoDocumento.SelectedValue);
                oFC_Modelo.cNumDocumento = Convert.ToString(this.txt_NumDocumento.Value);
                oFC_Modelo.Tnota = Convert.ToString(this.edt_Nota.Value);
                Service.Formulacion_Cabecera oFC_Service = new Service.Formulacion_Cabecera();
                if (intIidFormulacion_Cabecera == 0)
                {
                    if (MyStuff.UsaWCF == true)
                    {
                         DataSet DS_GrabaFC = objWCF.Graba_FormulacionCabecera_DataSet(oFC_Modelo);
                        oFC_Modelo.IidFormulacion_Cabecera = Convert.ToInt32(DS_GrabaFC.Tables[0].Rows[0][0]);
                        oFC_Modelo.Cversion = Convert.ToString(DS_GrabaFC.Tables[0].Rows[0][1]);
                        oFC_Modelo.Bactivo = false;
                        RegistroMovConceptos();
                    }
                    else
                    {
                        DataSet DS_GrabaFC = oFC_Service.Graba_FormulacionCabecera_DataSet(oFC_Modelo);
                        oFC_Modelo.IidFormulacion_Cabecera = Convert.ToInt32(DS_GrabaFC.Tables[0].Rows[0][0]);
                        oFC_Modelo.Cversion = Convert.ToString(DS_GrabaFC.Tables[0].Rows[0][1]);
                        oFC_Modelo.Bactivo = false;
                        RegistroMovConceptos();
                    }

                    
                    //int[] intResult = new int[1];
                    //intResult = [0];//objBC_Pac_Cabecera.graba_mvto_pac_Cabecera(objBEC_Pac_Cabecera
                    //)

                
                }
                else
                {
                    if (MyStuff.UsaWCF == true)
                    {
                         blnActualiza = objWCF.Modifica_mvto_Formulacion_Cabecera(oFC_Modelo);
                    }
                    else
                    {
                        blnActualiza = oFC_Service.Modifica_mvto_Formulacion_Cabecera(oFC_Modelo);
                    }
                  
                    PintarDatosRegistro();
                }


                if (intIidFormulacion_Cabecera == 0)
                    MessageBox.Show("Error: No se grabaron los datos");
                else
                {
                    MessageBox.Show("OK: Los datos se actualiza´ron correctamente");
                    intIidFormulacion_Cabecera = oFC_Modelo.IidFormulacion_Cabecera;
                    AccionBotones(true, true, true, true, true);
                }

            }
        }

        private void btn_Listar_Click(object sender, EventArgs e)
        {
            string strFile = string.Empty;
            if (this.SaveDocumento.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                strFile = this.SaveDocumento.FileName;
                DateTime start;
                TimeSpan timespan;
                start = DateTime.Now;
                try
                {
                    timespan = DateTime.Now.Subtract(start);
                    this.UltraGridExcelExporter1.Export(this.grd_mvto_ListaVersiones, strFile);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error", "Error");
                    throw;
                }
            }
        }
    }
}
