using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WINformulacion
{
    public partial class Frm_ActualizaFormulacion_Proyecto_Inversion_FF : DevExpress.XtraEditors.XtraForm
    {
        private SRformulacion.WCFformulacionEClient objWCF = new SRformulacion.WCFformulacionEClient();

        DataSet DS_Proyecto;
        DataSet DS_FuenteFinanciamiento;
        private Framework FS = new Framework();

        public string strCodProyecto = "";
        public string strNomProyecto = "";
        public string strCodFuenteFinanciamiento = "";
        public string strNomFuenteFinanciamiento = "";
        public Boolean blnEligio = false;

        private string strDato_FuenteFinanciamiento = "";
        private string strDato_Proyecto = "";
        private string strCodCompañia;

        public Frm_ActualizaFormulacion_Proyecto_Inversion_FF()
        {
            InitializeComponent();
        }

        public void ShowMe( string cCodCompañia,
                            string  strcodCentroCosto,
                            string strNomCentroCosto,
                            int intLinea
                            )
        {

            this.Text = "Proyecto y Fuente de Financiamiento para la linea: " + Convert.ToString(intLinea);

            strCodCompañia = cCodCompañia;

            string strCodCentroCosto = MyStuff.CodigoCentroCosto;

            Service.DataGeneral SDG = new Service.DataGeneral();
            if (MyStuff.UsaWCF == true)
            {
                DS_Proyecto = objWCF.Ayuda_Proyecto_Spring(strCodCompañia, strCodCentroCosto);
                this.Txt_CodProyecto.nombreDS = DS_Proyecto;
                //DS_FuenteFinanciamiento = objWCF.Ayuda_Proyecto_FuenteFinanciamiento( "00000", "NULL");
                this.Txt_CodFuenteFinanciamiento.nombreDS = DS_FuenteFinanciamiento;
            }
            else
            {

                DS_Proyecto = SDG.Ayuda_Proyecto_Spring(strCodCompañia, strCodCentroCosto);
                this.Txt_CodProyecto.nombreDS = DS_Proyecto;
                DS_FuenteFinanciamiento = SDG.Ayuda_Proyecto_FuenteFinanciamiento(strCodCompañia, "NULL");
                this.Txt_CodFuenteFinanciamiento.nombreDS = DS_FuenteFinanciamiento;
            }

            this.ShowDialog();
        }


        private void Txt_CodProyecto_Leave(object sender, EventArgs e)
        {
            this.BuscarProyecto();
        }


        private void BuscarProyecto()
        {
            if (strDato_Proyecto.TrimEnd() != Convert.ToString(this.Txt_CodProyecto.Value).TrimEnd())
            {
                if (string.IsNullOrEmpty(Convert.ToString(this.Txt_CodProyecto.Value)) == false)
                {
                    if (MyStuff.UsaWCF == true)
                    {
                        DS_FuenteFinanciamiento = objWCF.Ayuda_Proyecto_FuenteFinanciamiento(strCodCompañia, Convert.ToString(this.Txt_CodProyecto.Value));
                    }
                    else
                    {
                        Service.DataGeneral objSDG = new Service.DataGeneral();
                        DS_FuenteFinanciamiento = objSDG.Ayuda_Proyecto_FuenteFinanciamiento(strCodCompañia, Convert.ToString(this.Txt_CodProyecto.Value));

                    }
                    this.Txt_CodCentroCosto.nombreDS = DS_FuenteFinanciamiento;
                }
                else
                {
                    if (MyStuff.UsaWCF == true)
                    {
                        DS_FuenteFinanciamiento = objWCF.Ayuda_Proyecto_FuenteFinanciamiento(strCodCompañia, "NULL");
                    }
                    else
                    {
                        Service.DataGeneral objSDG = new Service.DataGeneral();
                        DS_FuenteFinanciamiento = objSDG.Ayuda_Proyecto_FuenteFinanciamiento(strCodCompañia, "NULL");

                    }
                    this.Txt_CodFuenteFinanciamiento.nombreDS = DS_FuenteFinanciamiento;
                }
                this.Txt_NomProyecto.Value = FS.TraerDescripcion_DataTable(DS_Proyecto.Tables[0],
                                                                            0,
                                                                            1,
                                                                            Convert.ToString(this.Txt_CodProyecto.Value)
                                                                            );
            }

        }

    
        private void Btn_Aceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(this.Txt_CodProyecto.Value)))
            {
                MessageBox.Show("Ingrese el Codigo del Proyecto");
            }
            else
            {
                if (string.IsNullOrEmpty(Convert.ToString(this.Txt_CodFuenteFinanciamiento.Value)))
                {
                    MessageBox.Show("Ingrese el Codigo de Fuente de Financiamiento");
                }
                else
                {
                    strCodProyecto = Convert.ToString(this.Txt_CodProyecto.Value);
                    strNomProyecto = Convert.ToString(this.Txt_NomProyecto.Value);
                    strCodFuenteFinanciamiento = Convert.ToString(this.Txt_CodFuenteFinanciamiento.Value);
                    strNomFuenteFinanciamiento = Convert.ToString(this.Txt_NomFuenteFinanciamiento.Value);
                    blnEligio = true;
                    this.Close();
                }
            }
        }

        private void Txt_CodFuenteFinanciamiento_Leave(object sender, EventArgs e)
        {
            this.BuscarFuenteFinanciamiento();
        }

        private void BuscarFuenteFinanciamiento()
        {
            if (string.IsNullOrEmpty(Convert.ToString(this.Txt_CodFuenteFinanciamiento.Value)))
            {
                this.Txt_NomFuenteFinanciamiento.Value = "";
            }
            else
            {
                this.Txt_NomFuenteFinanciamiento.Value = FS.TraerDescripcion_DataTable(DS_FuenteFinanciamiento.Tables[0],
                                                                                                    0,
                                                                                                    1,
                                                                                                    Convert.ToString(this.Txt_CodFuenteFinanciamiento.Value)
                                                                                                    );

            }
        }
    }
}