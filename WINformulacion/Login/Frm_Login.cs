using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Configuration;
using System.Security.Cryptography;
using System.IO;
//using DevExpress.XtraSplashScreen;

namespace WINformulacion
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
        }

        public SymmetricAlgorithm mCSP; 
        Model.Usuario objMUsuario = new Model.Usuario();
        Service.Usuario objSUsuario = new Service.Usuario();

        

        private SRformulacion.WCFformulacionEClient objWCF = new SRformulacion.WCFformulacionEClient();


        private void IngresarBtn_Click(object sender, EventArgs e)
        {
            string strLogUsuario = "";
            string strUsuario = Convert.ToString(this.txt_Usuario.Value).TrimEnd().ToUpper();
            string strContraseña = Convert.ToString(this.txt_Contraseña.Value).TrimEnd().ToUpper();
            string strAñoProceso = Convert.ToString(this.cbo_AñoProceso.Value);
            string strCodEmpresa = Convert.ToString(this.cbo_Empresa.Value);
            string strNomEmpresa = Convert.ToString(this.cbo_Empresa.Text);

            if (strContraseña != "" & strUsuario != "")
            {
                strLogUsuario = FN.Framework.Funciones.FN_CifradoDato.encripta(strUsuario, strUsuario.Length);

                Model.Usuario objMU = new Model.Usuario();
                Service.Usuario objSU = new Service.Usuario();
                Service.Usuario wsSU = new Service.Usuario();

                if (  MyStuff.UsaWCF == true )
                {
                    objMU = objWCF.Recupera_Usuario_Codigo(strCodEmpresa, strLogUsuario);
                }
                else
                {
                    objMU = objSU.Recupera_Usuario_Codigo(strCodEmpresa, strLogUsuario);
                }

                

                //objMU = objService.Recupera_Usuario_Codigo(strLogUsuario);


                if (objMU.tPasUsuario.TrimEnd() != "")
                {
                    string strClave = "";
                    strClave =  FN.Framework.Funciones.FN_RecoveryData.Desencripta_Contraseña( objMU.tPasUsuario.TrimEnd(),
                                                           objMU.tClaUsuario.Trim(),
                                                           objMU.tVecUsuario
                                                      );
                    if (strClave.TrimEnd() != strContraseña)
                    {
                        MessageBox.Show("La contraseña no corresponde al Usuario");
                        this.txt_Contraseña.Focus();
                    }
                    else
                    {
                        
                        
                        
                        //SplashScreenManager.ShowForm(typeof(Movimiento.WaitForm1));
                        Frm_Principal frm = new Frm_Principal();

                        frm.ShowMe ( strUsuario, "232", strLogUsuario, strCodEmpresa, strNomEmpresa, strAñoProceso);
                        //SplashScreenManager.CloseForm();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("El Usuario No esta Registrado");
                    this.txt_Usuario.Focus();
                }
            }
        }


        private void Login_Load(object sender, EventArgs e)
        {
            try
            {

                //Framework SF = new Framework();

                //if (SF.IsConnectionAvailable() == true)
                //{

                //    if (SF.Ping("198.150.0.53", 10) == true)
                //    {
                //        WINreport.MyStuff.UsaWCF = false;
                //    }
                //    else
                //    {
                //        WINreport.MyStuff.UsaWCF = true;
                //    }

                //}
                //else
                //{
                //    WINreport.MyStuff.UsaWCF = false;
                //}


                DataTable dt = new DataTable();
                DataTable dtE = new DataTable();

                if (MyStuff.UsaWCF == true)
                {
                    dt = objWCF.Combo_PeriodoProceso_DataTable().Tables[0];
                }
                else
                {
                    Service.PeriodoProceso objSPeriodoProceso = new Service.PeriodoProceso();
                    dt = objSPeriodoProceso.Combo_PeriodoProceso_DataTable().Tables[0];
                }

                //dt = objService.Combo_PeriodoProceso_DataTable().Tables[0];

                if (dt.Rows.Count > 0)
                {
                    this.cbo_AñoProceso.DataSource = dt;
                    this.cbo_AñoProceso.DisplayMember = "cPeriodo";
                    this.cbo_AñoProceso.ValueMember = "cValor";
                    //this.cbo_AñoProceso.Refresh();
                    this.cbo_AñoProceso.SelectedIndex = 0;
                }

                if (MyStuff.UsaWCF == true)
                {
                    dtE = objWCF.Combo_Empresa_DataTable().Tables[0];
                }
                else
                {
                    Service.Empresa objSEmpresa = new Service.Empresa();
                    dtE = objSEmpresa.Combo_Empresa_DataTable().Tables[0];
                }


                //dt = objService.Combo_PeriodoProceso_DataTable().Tables[0];

                if (dtE.Rows.Count > 0)
                {
                    this.cbo_Empresa.DataSource = dtE;
                    this.cbo_Empresa.DisplayMember = "vNomEmpresa";
                    this.cbo_Empresa.ValueMember = "cCodEmpresa";
                    //this.cbo_AñoProceso.Refresh();
                    this.cbo_Empresa.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString(), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hyperlinkLabelControlManual_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://aplicacion.amsac.pe/pFORMULACION/Manual.pdf");
            }
            catch (Exception ex)
            { }
        }
    }
}
