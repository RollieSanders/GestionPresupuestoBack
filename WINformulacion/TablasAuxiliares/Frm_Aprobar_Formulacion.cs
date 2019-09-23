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
    public partial class Frm_Aprobar_Formulacion : DevExpress.XtraEditors.XtraForm
    {
        private SRformulacion.WCFformulacionEClient objWCF = new SRformulacion.WCFformulacionEClient();

        public Frm_Aprobar_Formulacion()
        {
            InitializeComponent();
            this.txt_AñoProceso.Text = MyStuff.AñoProceso;
            this.txt_AñoProceso.Enabled = false;

            Carga_Combo_Version();

        }

        public void pintarGrilla()
        {
            this.grd_mvto_ListaVersiones.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grd_mvto_ListaVersiones.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;

            this.grd_mvto_ListaVersiones.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            Infragistics.Win.UltraWinGrid.UltraGridBand oBand0;
            oBand0 = this.grd_mvto_ListaVersiones.DisplayLayout.Bands[0];

            oBand0.Columns[0].Header.Caption = "Cod. Ceco";
            oBand0.Columns[0].Width = 60;
            oBand0.Columns[1].Header.Caption = "Nombre Ceco";
            oBand0.Columns[1].Width = 250;
            oBand0.Columns[2].Header.Caption = "Fec. Aprobación";
            oBand0.Columns[2].Width = 100;
            oBand0.Columns[3].Header.Caption = "Nota";
            oBand0.Columns[3].Width = 250;
            oBand0.Columns[4].Header.Caption = "Aprobado";
            oBand0.Columns[5].Width = 60;

            oBand0.Columns[5].Hidden = true;
            oBand0.Columns[6].Hidden = true;

        }

        private void Carga_Combo_Version()
        {
            string strAnio = this.txt_AñoProceso.Text.Trim();
            Service.Formulacion_Cabecera_Ceco SFCC = new Service.Formulacion_Cabecera_Ceco();

            try
            {
                if (MyStuff.UsaWCF == true)
                {
                    cbo_Version.DataSource = objWCF.Lista_Version(strAnio);
                }
                else
                {
                    cbo_Version.DataSource = SFCC.Lista_Version(strAnio);
                }
                cbo_Version.DisplayMember = "cVersion";
                cbo_Version.ValueMember = "cVersion";
            }
            catch (Exception exd)
            {
                throw exd;
            }


        }

        DataSet DS_Aprobacion = new DataSet();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Service.Formulacion_Cabecera_Ceco SFCC = new Service.Formulacion_Cabecera_Ceco();
           if (MyStuff.UsaWCF == true)
            {
                 DS_Aprobacion = objWCF.Lista_Formulacion_Aprobacion_Ceco(txt_AñoProceso.Text.Trim(), MyStuff.CodigoCentroGestor, cbo_Version.Text.Trim(), MyStuff.DigitoCentroGestor);
            }
            else
            {
                DS_Aprobacion = SFCC.Lista_Formulacion_Aprobacion_Ceco(txt_AñoProceso.Text.Trim(), MyStuff.CodigoCentroGestor, cbo_Version.Text.Trim(), MyStuff.DigitoCentroGestor);
            }

            grd_mvto_ListaVersiones.DataSource = DS_Aprobacion;
          
            if (DS_Aprobacion.Tables[0].Rows.Count > 0)
            {
                pintarGrilla();
            }

        }

        private void grd_mvto_ListaVersiones_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
        {
            if (DS_Aprobacion.Tables[0].Rows.Count > 0)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow oRow;
                oRow = this.grd_mvto_ListaVersiones.ActiveRow;

                if (!Convert.ToBoolean(oRow.Cells[4].Value))
                {
                    Frm_Cierra_Version frm = new Frm_Cierra_Version();
                    frm.Envia_Datos(txt_AñoProceso.Text.Trim(), oRow.Cells[0].Value.ToString().Trim(), cbo_Version.Text.Trim());
                    frm.ShowDialog();

                    if (frm.BResultado)
                    {
                        Infragistics.Win.UltraWinGrid.UltraGridRow oRow2;
                        oRow2 = grd_mvto_ListaVersiones.ActiveRow;
                        oRow2.Cells[0].Value = frm.CcodCeco;
                        oRow2.Cells[1].Value = frm.VnomCeco;
                        oRow2.Cells[2].Value = frm.VfechaAprobacion;
                        oRow2.Cells[3].Value = frm.Vnota;
                        oRow2.Cells[4].Value = frm.Baprobado;
                        oRow2.Cells[5].Value = frm.Vanio;
                        oRow2.Cells[6].Value = frm.Vversion;
                    }
                }
                else
                {
                    MessageBox.Show("El Ceco y Versión seleccionado ya se encuentra aprobado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Frm_Aprobar_Formulacion_Load(object sender, EventArgs e)
        {

        }
    }
}
