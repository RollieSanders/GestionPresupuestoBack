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
    

    public partial class Frm_Formulacion_Detalle : DevExpress.XtraEditors.XtraForm
    {
        IWorkbook workbook;
        private SRformulacion.WCFformulacionEClient objWCF = new SRformulacion.WCFformulacionEClient();
        DataSet DS_Detalle;
        DataView DV_Detalle;
        DataSet DS_Proyecto;
        DataSet DS_FuenteFinanciamiento;
        DataSet DS_CentroCosto;
        private string strDato_FuenteFinaniamiento = "";
        private string strDato_CentroCosto = "";
        private string strDato_Proyecto = "";
        private Framework FS = new Framework();

        public Frm_Formulacion_Detalle()
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
                DS_Proyecto = objWCF.Ayuda_Proyecto_Reporte("");
            }
            else
            {
                Service.DataGeneral SDG = new Service.DataGeneral();
                DS_FuenteFinanciamiento = SDG.Ayuda_FuenteFinanciamiento_Reporte("000000");
                DS_CentroCosto = SDG.Ayuda_CentroCosto_Reporte("");
                DS_Proyecto = SDG.Ayuda_Proyecto_Reporte("");
            }
            this.Txt_CodFuenteFinanciamiento.nombreDS = DS_FuenteFinanciamiento;
            this.Txt_CodCentroCosto.nombreDS = DS_CentroCosto;
            this.Txt_CodProyecto.nombreDS = DS_Proyecto;

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
                if (string.IsNullOrEmpty(Convert.ToString(this.Txt_CodCentroCosto.Value)) == false)
                {
                    if (MyStuff.UsaWCF == true)
                    {
                        DS_Proyecto = objWCF.Ayuda_Proyecto_Reporte(Convert.ToString(this.Txt_CodCentroCosto.Value));
                    }
                    else
                    {
                        Service.DataGeneral objSDG = new Service.DataGeneral();
                        DS_Proyecto = objSDG.Ayuda_Proyecto_Reporte(Convert.ToString(this.Txt_CodCentroCosto.Value));

                    }
                    this.Txt_CodProyecto.nombreDS = DS_Proyecto;
                }
                else
                {
                    if (MyStuff.UsaWCF == true)
                    {
                        DS_Proyecto = objWCF.Ayuda_Proyecto_Reporte("");
                    }
                    else
                    {
                        Service.DataGeneral objSDG = new Service.DataGeneral();
                        DS_Proyecto = objSDG.Ayuda_Proyecto_Reporte("");

                    }
                    this.Txt_CodProyecto.nombreDS = DS_Proyecto;
                }
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

            if (MyStuff.UsaWCF == true)
            {
                DS_Detalle = objWCF.Reporte_Detalle_Formulacion("000000",
                                                    Convert.ToString(this.Cbo_AñoProceso.SelectedValue),
                                                    Convert.ToString(this.Cbo_Version.SelectedValue),
                                                    Convert.ToString(this.Txt_CodFuenteFinanciamiento.Value),
                                                    Convert.ToString(this.Txt_CodCentroCosto.Value),
                                                    Convert.ToString(this.Txt_CodProyecto.Value)
                                                );
            }
            else
            {
                Service.Reporte SR = new Service.Reporte();
                DS_Detalle = SR.Reporte_Detalle_Formulacion("000000",
                                                    Convert.ToString(this.Cbo_AñoProceso.SelectedValue),
                                                    Convert.ToString(this.Cbo_Version.SelectedValue),
                                                    Convert.ToString(this.Txt_CodFuenteFinanciamiento.Value),
                                                    Convert.ToString(this.Txt_CodCentroCosto.Value),
                                                    Convert.ToString(this.Txt_CodProyecto.Value)
                                                );
            }


            workbook = spreadsheetControl.Document;
            string sRutaInterna = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Excel\FormulacionDetalle.xlsx");
            workbook.LoadDocument(sRutaInterna, DocumentFormat.Xlsx);
            Worksheet worksheet_Detalle = workbook.Worksheets[0];

            DV_Detalle = DS_Detalle.Tables[0].DefaultView;
            worksheet_Detalle.DataBindings.BindToDataSource(DV_Detalle, 6, 0);

            worksheet_Detalle.Cells[2, 1].Value = Convert.ToString(this.Cbo_AñoProceso.SelectedValue);
            worksheet_Detalle.Cells[3, 1].Value = Convert.ToString(this.Cbo_Version.SelectedValue);

            Range boundrange_Detalle = worksheet_Detalle.DataBindings[0].Range;
            int intFilaInicial = boundrange_Detalle.TopRowIndex + 1;
            int intFila = boundrange_Detalle.BottomRowIndex + 1;
            string strRango = "";
            string strCelda = "";
            string strLetra = "";
            for (var c = 15; c < 32; c++)
            {
                strLetra = traeLetraColumna (  c );
                strRango = strLetra.TrimEnd() + Convert.ToString(intFilaInicial) + ":" + strLetra.TrimEnd() + Convert.ToString(intFila);
                strCelda = strLetra.TrimEnd() + Convert.ToString(intFila + 2);
                worksheet_Detalle.Cells[strCelda].Formula = "= SUM(" + strRango.TrimEnd() + ")";
                worksheet_Detalle.Cells[strCelda].Font.Bold = true;

            }

            ////Creamos una nueva hoja
            //Worksheet pivotWorksheet = workbook.Worksheets.Add();

            //Worksheet worksheetPivot = workbook.Worksheets[1];

            //worksheetPivot.Name = "Pivot";

            ////Creamos un pivot table

            //string strLetraColumnaInicial = traeLetraColumna(boundrange_Detalle.LeftColumnIndex + 1);
            //string strLetraColumnaFinal = traeLetraColumna(boundrange_Detalle.RightColumnIndex + 1);

            //strRango = strLetraColumnaInicial.TrimEnd() + Convert.ToString(intFilaInicial) + ":" + strLetraColumnaFinal.TrimEnd() + Convert.ToString(intFila);

            //PivotTable pivottable = pivotWorksheet.PivotTables.Add(worksheet_Detalle[strRango], pivotWorksheet["A7"]);

            //PivotTable pt = workbook.Worksheets[1].PivotTables[0] as PivotTable;
            //pt.Cache.Refresh();

            //SplashScreenManager.CloseForm();
        }

        private string traeLetraColumna(int y1)
        {
            char columna1;
            string letra = "";
            

            if (y1 > 25)
            {
                y1 = y1 - 25;
                letra = "A";
            }

            columna1 = Convert.ToChar(64 + y1);

            return letra + Convert.ToString(columna1).TrimEnd();
        }
    }
}