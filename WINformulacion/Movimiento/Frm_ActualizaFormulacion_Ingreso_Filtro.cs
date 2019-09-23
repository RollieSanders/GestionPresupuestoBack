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

namespace WINformulacion.Movimiento
{
    public partial class Frm_ActualizaFormulacion_Ingreso_Filtro : DevExpress.XtraEditors.XtraForm
    {
        private SRformulacion.WCFformulacionEClient objWCF = new SRformulacion.WCFformulacionEClient();

        public Boolean blnProcesaExcel = false;
        DataSet DS_CentroCosto;
        private Framework FS = new Framework();

        public string strVersion = "";
        public string strCodProyecto = "CORPORATIVOS";
        public string strNomProyecto = "CORPORATIVOS";
        public string strNomMacroProyecto = "";
        public string strCodCentroCosto = "";
        public string strNomCentroCosto = "";

        public Frm_ActualizaFormulacion_Ingreso_Filtro()
        {
            InitializeComponent();
        }

        public void ShowMe()
        {

            Model.Formulacion_Cabecera MFC = new Model.Formulacion_Cabecera();
            Service.Formulacion_Cabecera SFC = new Service.Formulacion_Cabecera();

            if (MyStuff.UsaWCF == true)
            {
                MFC = objWCF.Recupera_FormulacionCabecera(MyStuff.AñoProceso);
            }
            else
            {
                MFC = SFC.Recupera_FormulacionCabecera(MyStuff.AñoProceso);
            }
            

            string strCodCentroCosto = MyStuff.CodigoCentroCosto;
            this.Txt_Año.Value = MyStuff.AñoProceso;
            this.Txt_Empresa.Value = MyStuff.Empresa;
            this.Txt_Version.Value = MFC.Cversion;

            this.Txt_CodProyecto.Value = strCodProyecto;
            this.Txt_NomProyecto.Value = strNomProyecto;

            Service.DataGeneral SDG = new Service.DataGeneral();

            if (  MyStuff.UsaWCF == true )
            {
                DS_CentroCosto = objWCF.Ayuda_Proyecto_CentroCosto(MyStuff.CodigoCentroGestor, MyStuff.DigitoCentroGestor);
                this.Txt_CodCentroCosto.nombreDS = DS_CentroCosto;
            }
            else
            {
                
                DS_CentroCosto = SDG.Ayuda_Proyecto_CentroCosto(MyStuff.CodigoCentroGestor, MyStuff.DigitoCentroGestor);
                this.Txt_CodCentroCosto.nombreDS = DS_CentroCosto;
            }
            if ( DS_CentroCosto.Tables[0].Rows.Count > 1  )
            {
                this.Txt_CodCentroCosto.Enabled = true;
            }
            else
            {
                this.Txt_CodCentroCosto.Enabled = false;
                this.Txt_CodCentroCosto.Value = Convert.ToString(DS_CentroCosto.Tables[0].Rows[0][0]);
                this.Txt_NomCentroCosto.Value = Convert.ToString(DS_CentroCosto.Tables[0].Rows[0][1]);
            }

            this.ShowDialog();
        }

      
      
        private void PintarDatoEcontrado(   string strCodProyecto,
                                            string strNomProyecto,
                                            string strNomMacroProyecto,
                                            Boolean blnEncontrado
                                        )
        {

            this.Btn_Aceptar.Enabled =  blnEncontrado;

            this.Txt_NomProyecto.Value = strNomProyecto;
        }

        private void Btn_Aceptar_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(Convert.ToString(this.Txt_CodProyecto.Value)))
            {
                MessageBox.Show("Ingrese el Codigo del Proyecto");
            }
            else
            {
                if (string.IsNullOrEmpty(Convert.ToString(this.Txt_CodCentroCosto.Value)))
                {
                    MessageBox.Show("Ingrese el Codigo del Centro de Costo");
                }
                else
                {
                    strVersion = Convert.ToString(this.Txt_Version.Value);
                    strCodProyecto = Convert.ToString(this.Txt_CodProyecto.Value);
                    strNomProyecto = Convert.ToString(this.Txt_NomProyecto.Value);
                    strCodCentroCosto = Convert.ToString(this.Txt_CodCentroCosto.Value);
                    strNomCentroCosto = Convert.ToString(this.Txt_NomCentroCosto.Value);

                    Model.Formulacion_Cabecera_Ceco MFCC = new Model.Formulacion_Cabecera_Ceco();
                    Service.Formulacion_Cabecera_Ceco SFCC = new Service.Formulacion_Cabecera_Ceco();

                    if (MyStuff.UsaWCF == true)
                    {
                         MFCC = objWCF.Recupera_FormulacionCabecera_CeCo(Convert.ToString(this.Txt_Año.Value),
                                                                                     strVersion,
                                                                                     strCodCentroCosto
                                                                                   );
                    }
                    else
                    {
                        MFCC = SFCC.Recupera_FormulacionCabecera_CeCo(Convert.ToString(this.Txt_Año.Value),
                                                                                     strVersion,
                                                                                     strCodCentroCosto
                                                                                   );
                    }

                    

                    if (string.IsNullOrEmpty(MFCC.CañoProceso))
                    {
                        blnProcesaExcel = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("La formulacion del Centro de Costo ha sido Cerrado el dia: " + Convert.ToString(MFCC.DfecFormulacion));
                    }

                }
            }



            //strVersion = Convert.ToString(this.Txt_Version.Value);
            //strCodProyecto = Convert.ToString(this.Txt_CodProyecto.Value);
            //strNomProyecto = Convert.ToString( this.Txt_NomProyecto.Value );
            //strCodCentroCosto = Convert.ToString(this.Txt_CodCentroCosto.Value);
            //strNomCentroCosto = Convert.ToString(this.Txt_NomCentroCosto.Value);

            //blnProcesaExcel = true;
            //this.Close();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Txt_CodCentroCosto_Leave(object sender, EventArgs e)
        {
            if ( string.IsNullOrEmpty(Convert.ToString(this.Txt_CodCentroCosto.Value))  )
            {
                this.Txt_NomCentroCosto.Value = "";
            }
            else
            {
                this.Txt_NomCentroCosto.Value = FS.TraerDescripcion_DataTable(DS_CentroCosto.Tables[0],
                                                                                                    0,
                                                                                                    1,
                                                                                                    Convert.ToString( this.Txt_CodCentroCosto.Value )
                                                                                                    );

            }
        }
    }
}