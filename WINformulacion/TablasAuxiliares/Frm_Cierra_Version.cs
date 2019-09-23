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
    public partial class Frm_Cierra_Version : DevExpress.XtraEditors.XtraForm
    {
        private SRformulacion.WCFformulacionEClient objWCF = new SRformulacion.WCFformulacionEClient();

        public string CcodCeco = string.Empty;
        public string VnomCeco = string.Empty;
        public string VfechaAprobacion = string.Empty;
        public string Vnota = string.Empty;
        public bool Baprobado = false;
        public string Vanio = string.Empty;
        public string Vversion = string.Empty;
        public bool BResultado = false;

        public Frm_Cierra_Version()
        {
            InitializeComponent();
            Service.DataGeneral SDG = new Service.DataGeneral();
            if (MyStuff.UsaWCF == true)
            {
                DS_CentroCosto = objWCF.Ayuda_Proyecto_CentroCosto(MyStuff.CodigoCentroGestor, MyStuff.DigitoCentroGestor);
            }
            else
            {
                DS_CentroCosto = SDG.Ayuda_Proyecto_CentroCosto(MyStuff.CodigoCentroGestor, MyStuff.DigitoCentroGestor);
            }
            this.Txt_CodCentroCosto.nombreDS = DS_CentroCosto;
            txt_Fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txt_Fecha.Enabled = false;
            btn_Grabar.ImageOptions.Image = imageCollection16.Images[1];
            btn_Cancelar.ImageOptions.Image = imageCollection16.Images[2];
        }

        public void Envia_Datos(string strAnio, string strCodCeco, string strVersion)
        {
            txt_AñoProceso.Text = strAnio;
            txt_AñoProceso.Enabled = false;

            txt_Version.Text = strVersion;
            Txt_CodCentroCosto.Text = strCodCeco;
            Txt_CodCentroCosto_Leave(null, null);
            Txt_CodCentroCosto.Enabled = false;
            edt_Nota.Text = string.Empty;
        }

        private bool VerificaIngresoMovimiento()
        {
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

                if (String.IsNullOrWhiteSpace(Txt_CodCentroCosto.Text.ToString().Trim()))
                {
                    blnVerifica = false;
                    strMensaje = "Debe ingresar el Centro de Costo";
                }

                //if (String.IsNullOrWhiteSpace(edt_Nota.Value.ToString().Trim()))
                //{
                //    blnVerifica = false;
                //    strMensaje = "Debe ingresar ";
                //}

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
        private Framework FS = new Framework();
        DataSet DS_CentroCosto;
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

        private void btn_Grabar_Click(object sender, EventArgs e)
        {
            Service.Formulacion_Cabecera_Ceco obj_Service = new Service.Formulacion_Cabecera_Ceco();
            Model.Formulacion_Cabecera_Ceco obj_Model = new Model.Formulacion_Cabecera_Ceco();

            bool bResultado = false;

            if (VerificaIngresoMovimiento())
            {
                obj_Model.CañoProceso = txt_AñoProceso.Text.Trim();
                obj_Model.Cversion = txt_Version.Text.Trim();
                obj_Model.cCodCeco = Txt_CodCentroCosto.Value.ToString().Trim();
                obj_Model.Tnota = this.edt_Nota.Text.ToString().Trim();
                obj_Model.Cversion = txt_Version.Text.Trim();
                obj_Model.cUsuarioCierre = MyStuff.CodigoEmpleado;

                if (MyStuff.UsaWCF == true)
                {
                    bResultado = objWCF.Graba_mvto_Formulacion_Cabecera_Ceco(obj_Model);
                }
                else
                {
                    bResultado = obj_Service.Graba_mvto_Formulacion_Cabecera_Ceco(obj_Model);
                }


                if (bResultado)
                {
                    CcodCeco = Txt_CodCentroCosto.Value.ToString().Trim();
                    VnomCeco = Txt_NomCentroCosto.Text.Trim();
                    VfechaAprobacion = txt_Fecha.Text.Trim();
                    Vnota = edt_Nota.Text.Trim();
                    Baprobado = true;
                    Vanio = txt_AñoProceso.Text.Trim();
                    Vversion = txt_Version.Text.Trim();
                    BResultado = true;

                }
                this.Close();

            }

        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
