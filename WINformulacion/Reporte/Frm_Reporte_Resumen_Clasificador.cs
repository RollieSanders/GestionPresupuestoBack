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
using DevExpress.Spreadsheet;
using System.IO;
using DevExpress.XtraSplashScreen;

namespace WINformulacion
{
    

    public partial class Frm_Reporte_Resumen_Clasificador : DevExpress.XtraEditors.XtraForm
    {
        IWorkbook workbook;
        private SRformulacion.WCFformulacionEClient objWCF = new SRformulacion.WCFformulacionEClient();
        DataSet DS_Formato4P;
        DataView DV_Formato4P;
        DataSet DS_Proyecto;
        DataSet DS_FuenteFinanciamiento;
        DataSet DS_CentroCosto;
        private string strDato_FuenteFinaniamiento = "";
        private string strDato_CentroCosto = "";
        private string strDato_Proyecto = "";
        private Framework FS = new Framework();

        public Frm_Reporte_Resumen_Clasificador()
        {
            InitializeComponent();
        }

  
         private void MostrarDataFiltro()
        {



            if (MyStuff.UsaWCF == true)
            {
                this.Cbo_AñoProceso.CargaDT( objWCF.Combo_AñoProceso("000000") );
                if  ( string.IsNullOrEmpty( Convert.ToString( this.Cbo_AñoProceso.SelectedValue ) ) )
                {
                    this.Cbo_Version.CargaDT( objWCF.Combo_Version(MyStuff.AñoProceso)  );
                }
                else
                {
                    this.Cbo_Version.CargaDT(objWCF.Combo_Version(Convert.ToString(this.Cbo_AñoProceso.SelectedValue)));
                }
            }
            else
            {
                Service.Formulacion_Cabecera SFC = new Service.Formulacion_Cabecera();
                this.Cbo_AñoProceso.CargaDT(SFC.Combo_AñoProceso("000000"));
                if (string.IsNullOrEmpty(Convert.ToString(this.Cbo_AñoProceso.SelectedValue)))
                {
                    this.Cbo_Version.CargaDT(SFC.Combo_Version(MyStuff.AñoProceso));
                }
                else
                {
                    this.Cbo_Version.CargaDT(SFC.Combo_Version(Convert.ToString(this.Cbo_AñoProceso.SelectedValue)));
                }
            }

            if (  MyStuff.UsaWCF == true )
            {
                DS_FuenteFinanciamiento = objWCF.Ayuda_FuenteFinanciamiento_Reporte("000000");
                DS_CentroCosto = objWCF.Ayuda_CentroCosto_Reporte("");
                DS_Proyecto = objWCF.Ayuda_Proyecto_Reporte("","");
            }
            else
            {
                Service.DataGeneral SDG = new Service.DataGeneral();
                DS_FuenteFinanciamiento = SDG.Ayuda_FuenteFinanciamiento_Reporte("000000");
                DS_CentroCosto = SDG.Ayuda_CentroCosto_Reporte("");
                DS_Proyecto = SDG.Ayuda_Proyecto_Reporte("","");
            }
            this.Txt_CodFuenteFinanciamiento.nombreDS = DS_FuenteFinanciamiento;
            this.Txt_CodCentroCosto.nombreDS = DS_CentroCosto;
            this.Txt_CodProyecto.nombreDS = DS_Proyecto;
            this.Opt_Grupo.CheckedIndex = 0;

        }

        private void Frm_Formato_4P_Load(object sender, EventArgs e)
        {
            this.Txt_Empresa.Value = MyStuff.Empresa;
            this.MostrarDataFiltro();
        }

        private void Txt_CodFuenteFinanciamiento_Leave(object sender, EventArgs e)
        {
            if (strDato_FuenteFinaniamiento.TrimEnd() != Convert.ToString(this.Txt_CodFuenteFinanciamiento.Value).TrimEnd())
            {
                if (string.IsNullOrEmpty(Convert.ToString(this.Txt_CodFuenteFinanciamiento.Value)) == false)
                {
                    if (MyStuff.UsaWCF == true)
                    {
                        DS_CentroCosto = objWCF.Ayuda_CentroCosto_Reporte(Convert.ToString(this.Txt_CodFuenteFinanciamiento.Value));
                    }
                    else
                    {
                        Service.DataGeneral objSDG = new Service.DataGeneral();
                        DS_CentroCosto = objSDG.Ayuda_CentroCosto_Reporte(Convert.ToString(this.Txt_CodFuenteFinanciamiento.Value));

                    }
                    this.Txt_CodCentroCosto.nombreDS = DS_CentroCosto;
                }
                else
                {
                    if (MyStuff.UsaWCF == true)
                    {
                        DS_CentroCosto = objWCF.Ayuda_CentroCosto_Reporte("");
                    }
                    else
                    {
                        Service.DataGeneral objSDG = new Service.DataGeneral();
                        DS_CentroCosto =objSDG.Ayuda_CentroCosto_Reporte("");

                    }
                    this.Txt_CodCentroCosto.nombreDS = DS_CentroCosto;
                }
                this.Txt_NomFuenteFinanciamiento.Value = FS.TraerDescripcion_DataTable(DS_FuenteFinanciamiento.Tables[0],
                                                                                                       0,
                                                                                                       1,
                                                                                                       Convert.ToString(this.Txt_CodFuenteFinanciamiento.Value)
                                                                                                     );
                string strNomCentroCosto = FS.TraerDescripcion_DataTable(DS_CentroCosto.Tables[0],
                                                                                                       0,
                                                                                                       1,
                                                                                                       Convert.ToString(this.Txt_CodCentroCosto.Value)
                                                                                                     );
                if (string.IsNullOrEmpty(strNomCentroCosto))
                {
                    this.Txt_CodCentroCosto.Value = "";
                    this.Txt_NomCentroCosto.Value = "";

                    this.Txt_CodProyecto.Value = "";
                    this.Txt_NomProyecto.Value = "";

                    if (MyStuff.UsaWCF == true)
                    {
                        DS_Proyecto = objWCF.Ayuda_CentroCosto_Reporte("");
                    }
                    else
                    {
                        Service.DataGeneral objSDG = new Service.DataGeneral();
                        DS_Proyecto = objSDG.Ayuda_CentroCosto_Reporte("");

                    }
                    this.Txt_CodProyecto.nombreDS = DS_Proyecto;

                }
                strDato_FuenteFinaniamiento = Convert.ToString(this.Txt_CodFuenteFinanciamiento.Value);
            }
        }

     

        private void Txt_CodCentroCosto_Leave(object sender, EventArgs e)
        {
            if (strDato_CentroCosto.TrimEnd() != Convert.ToString(this.Txt_CodCentroCosto.Value).TrimEnd())
            {
                //if (string.IsNullOrEmpty(Convert.ToString(this.Txt_CodCentroCosto.Value)) == false)
                //{
                if (MyStuff.UsaWCF == true)
                {
                    DS_Proyecto = objWCF.Ayuda_Proyecto_Reporte(Convert.ToString(this.Txt_CodFuenteFinanciamiento.Value),
                                                                    Convert.ToString(this.Txt_CodCentroCosto.Value)
                                                                );
                }
                else
                {
                    Service.DataGeneral objSDG = new Service.DataGeneral();
                    DS_Proyecto = objSDG.Ayuda_Proyecto_Reporte(Convert.ToString(this.Txt_CodFuenteFinanciamiento.Value),
                                                                    Convert.ToString(this.Txt_CodCentroCosto.Value)
                                                                );

                }
                this.Txt_CodProyecto.nombreDS = DS_Proyecto;
                //}
                //else
                //{
                //    if (MyStuff.UsaWCF == true)
                //    {
                //        DS_Proyecto = objWCF.Ayuda_Proyecto_Reporte("");
                //    }
                //    else
                //    {
                //        Service.DataGeneral objSDG = new Service.DataGeneral();
                //        DS_Proyecto = objSDG.Ayuda_Proyecto_Reporte("");

                //    }
                //    this.Txt_CodProyecto.nombreDS = DS_Proyecto;
                //}
                this.Txt_NomCentroCosto.Value = FS.TraerDescripcion_DataTable(DS_CentroCosto.Tables[0],
                                                                                                       0,
                                                                                                       1,
                                                                                                       Convert.ToString(this.Txt_CodCentroCosto.Value)
                                                                                                     );
                string strNomProyecto = FS.TraerDescripcion_DataTable(DS_Proyecto.Tables[0],
                                                                                       0,
                                                                                       1,
                                                                                       Convert.ToString(this.Txt_CodProyecto.Value)
                                                                                     );

                if (string.IsNullOrEmpty(strNomProyecto))
                {
                    this.Txt_CodProyecto.Value = "";
                    this.Txt_NomProyecto.Value = "";
                }
                strDato_CentroCosto = Convert.ToString(this.Txt_CodCentroCosto.Value);
            }
        }

        private void Txt_CodProyecto_Leave(object sender, EventArgs e)
        {
            this.Txt_NomProyecto.Value = FS.TraerDescripcion_DataTable(DS_Proyecto.Tables[0],
                                                                                   0,
                                                                                   1,
                                                                                   Convert.ToString(this.Txt_CodProyecto.Value)
                                                                                 );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            SplashScreenManager.Default.SetWaitFormDescription("Recopilando informaciòn...");
            string strTipoMovimiento = "";
            if (this.Opt_Gasto.Checked == true)
            {
                strTipoMovimiento = "GASTO";

                if (MyStuff.UsaWCF == true)
                {
                    DS_Formato4P = objWCF.Lista_Formulacion_ResumenClasificador_Gasto("000000",
                                                        Convert.ToString(this.Cbo_AñoProceso.SelectedValue),
                                                        Convert.ToString(this.Cbo_Version.SelectedValue),
                                                        Convert.ToString(this.Txt_CodFuenteFinanciamiento.Value),
                                                        Convert.ToString(this.Txt_CodCentroCosto.Value),
                                                        Convert.ToString(this.Txt_CodProyecto.Value),
                                                        this.Opt_Grupo.CheckedIndex
                                                    );
                }
                else
                {
                    Service.Reporte SR = new Service.Reporte();
                    DS_Formato4P = SR.Lista_Formulacion_ResumenClasificador_Gasto("000000",
                                                        Convert.ToString(this.Cbo_AñoProceso.SelectedValue),
                                                        Convert.ToString(this.Cbo_Version.SelectedValue),
                                                        Convert.ToString(this.Txt_CodFuenteFinanciamiento.Value),
                                                        Convert.ToString(this.Txt_CodCentroCosto.Value),
                                                        Convert.ToString(this.Txt_CodProyecto.Value),
                                                        this.Opt_Grupo.CheckedIndex
                                                    );
                }
            }
            else
            {
                strTipoMovimiento = "INGRESO";
                if (MyStuff.UsaWCF == true)
                {
                    DS_Formato4P = objWCF.Lista_Formulacion_ResumenClasificador_Ingreso("000000",
                                                        Convert.ToString(this.Cbo_AñoProceso.SelectedValue),
                                                        Convert.ToString(this.Cbo_Version.SelectedValue),
                                                        Convert.ToString(this.Txt_CodFuenteFinanciamiento.Value),
                                                        Convert.ToString(this.Txt_CodCentroCosto.Value),
                                                        Convert.ToString(this.Txt_CodProyecto.Value),
                                                        this.Opt_Grupo.CheckedIndex
                                                    );
                }
                else
                {
                    Service.Reporte SR = new Service.Reporte();
                    DS_Formato4P = SR.Lista_Formulacion_ResumenClasificador_Ingreso("000000",
                                                        Convert.ToString(this.Cbo_AñoProceso.SelectedValue),
                                                        Convert.ToString(this.Cbo_Version.SelectedValue),
                                                        Convert.ToString(this.Txt_CodFuenteFinanciamiento.Value),
                                                        Convert.ToString(this.Txt_CodCentroCosto.Value),
                                                        Convert.ToString(this.Txt_CodProyecto.Value),
                                                        this.Opt_Grupo.CheckedIndex
                                                    );
                }
            }

            string strNombreFuenteFinanciamiento = Convert.ToString(this.Txt_NomFuenteFinanciamiento.Text);
            if (string.IsNullOrEmpty(Convert.ToString(this.Txt_NomFuenteFinanciamiento.Value)) == true)
            {
                strNombreFuenteFinanciamiento = "Todos";
            }

            string strNombreCentroCosto = Convert.ToString(this.Txt_NomCentroCosto.Text);
            if (string.IsNullOrEmpty(Convert.ToString(this.Txt_NomCentroCosto.Value)) == true)
            {
                strNombreCentroCosto = "Todos";
            }

            string strNombreProyecto = Convert.ToString(this.Txt_NomProyecto.Text);
            if (string.IsNullOrEmpty(Convert.ToString(this.Txt_NomProyecto.Value)) == true)
            {
                strNombreProyecto = "Todos";
            }

            switch (this.Opt_Grupo.CheckedIndex)
            {
                case 0:
                    this.Grupo_Clasificador( strTipoMovimiento, 
                                             strNombreFuenteFinanciamiento,
                                             strNombreCentroCosto,
                                             strNombreProyecto
                                             );
                    break;
                case 1:
                    this.Grupo_CentroCostoClasificador(strTipoMovimiento,
                                             strNombreFuenteFinanciamiento,
                                             strNombreCentroCosto,
                                             strNombreProyecto
                                             );
                    break;
                default:
                    this.Grupo_ProyectoClasificador(strTipoMovimiento,
                                             strNombreFuenteFinanciamiento,
                                             strNombreCentroCosto,
                                             strNombreProyecto
                                             );
                    break;
            }
            SplashScreenManager.CloseForm();
        }


        private void Grupo_Clasificador( string strTipoMovimiento,
                               string strNombreFuenteFinanciamiento,
                               string strNombreCentroCosto,
                               string strNombreProyecto
                             )
        {
            Formato.CrystalReport.Rpt_FormulacionProyecto_Resumen crpt = new Formato.CrystalReport.Rpt_FormulacionProyecto_Resumen();
            crpt.Database.Tables["Proyecto"].SetDataSource(DS_Formato4P.Tables[0]);
            crpt.SetParameterValue("@TipoMovimiento", strTipoMovimiento);
            crpt.SetParameterValue("@pFuenteFinanciamiento", strNombreFuenteFinanciamiento);
            crpt.SetParameterValue("@NomProyecto", strNombreProyecto);
            crpt.SetParameterValue("@NomCentroCosto", strNombreCentroCosto);
            crpt.SetParameterValue("@AñoProceso", Convert.ToString(this.Cbo_AñoProceso.SelectedValue));
            crpt.SetParameterValue("@Version", Convert.ToString(this.Cbo_Version.SelectedValue));
            Crv_Resumen.ReportSource = null;
            Crv_Resumen.ReportSource = crpt;
        }

        private void Grupo_CentroCostoClasificador(string strTipoMovimiento,
                               string strNombreFuenteFinanciamiento,
                               string strNombreCentroCosto,
                               string strNombreProyecto
                             )
        {
            Formato.CrystalReport.Rpt_FormulacionProyecto_Resumen_CentroCosto crpt = new Formato.CrystalReport.Rpt_FormulacionProyecto_Resumen_CentroCosto();
            crpt.Database.Tables["Proyecto"].SetDataSource(DS_Formato4P.Tables[0]);
            crpt.SetParameterValue("@TipoMovimiento", strTipoMovimiento);
            crpt.SetParameterValue("@pFuenteFinanciamiento", strNombreFuenteFinanciamiento);
            crpt.SetParameterValue("@NomProyecto", strNombreProyecto);
            crpt.SetParameterValue("@NomCentroCosto", strNombreCentroCosto);
            crpt.SetParameterValue("@AñoProceso", Convert.ToString(this.Cbo_AñoProceso.SelectedValue));
            crpt.SetParameterValue("@Version", Convert.ToString(this.Cbo_Version.SelectedValue));
            Crv_Resumen.ReportSource = null;
            Crv_Resumen.ReportSource = crpt;
        }

        private void Grupo_ProyectoClasificador(string strTipoMovimiento,
                               string strNombreFuenteFinanciamiento,
                               string strNombreCentroCosto,
                               string strNombreProyecto
                             )
        {
            Formato.CrystalReport.Rpt_FormulacionProyecto_Resumen_Proyecto crpt = new Formato.CrystalReport.Rpt_FormulacionProyecto_Resumen_Proyecto();
            crpt.Database.Tables["Proyecto"].SetDataSource(DS_Formato4P.Tables[0]);
            crpt.SetParameterValue("@TipoMovimiento", strTipoMovimiento);
            crpt.SetParameterValue("@pFuenteFinanciamiento", strNombreFuenteFinanciamiento);
            crpt.SetParameterValue("@NomProyecto", strNombreProyecto);
            crpt.SetParameterValue("@NomCentroCosto", strNombreCentroCosto);
            crpt.SetParameterValue("@AñoProceso", Convert.ToString(this.Cbo_AñoProceso.SelectedValue));
            crpt.SetParameterValue("@Version", Convert.ToString(this.Cbo_Version.SelectedValue));
            Crv_Resumen.ReportSource = null;
            Crv_Resumen.ReportSource = crpt;
        }


    }
}