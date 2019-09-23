using DevExpress.Spreadsheet;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WINformulacion
{
    public partial class Frm_ActualizaFormulacion_Ingreso : Form
    {
        private SRformulacion.WCFformulacionEClient objWCF = new SRformulacion.WCFformulacionEClient();

        IWorkbook workbook;
        private DataSet DS_Formulacion;
        private DataTable DT_Formulacion;
        private DataSet DS_ClaseIngreso;
        private DataSet DS_FuenteFinanciamiento;

        private int intInicioEvento = 0;
        private int intRegistrosEvento = 0;


        private string strAñoProceso = "";
        private string strVersion = "";
        private string strCodProyecto = "";
        private string strCodCentroCosto = "";
        private string strCodTipoFormulacion = "";
        private string strListaOrdenes = "";
        private int intNumeroOrdenes = 0;
        public DataView DV_Excel;


        private DataView DV_FuenteFinanciamiento;
        private DataView DV_ClaseIngreso;
        private string strCelda_FuenteFinanciamiento = "";

        private string strCodMetodoDistribucion = "";
        private Framework FS = new Framework();

        private Boolean blnEliminaRegistros = true;
        private Boolean blnCanceloEliminacionRegistros = false;


        public Frm_ActualizaFormulacion_Ingreso()
        {
            InitializeComponent();
        }
        #region Presentar datos en excel
        private void MostrarFiltro(Boolean blnSalir)
        {
            WINformulacion.Movimiento.Frm_ActualizaFormulacion_Ingreso_Filtro frm = new WINformulacion.Movimiento.Frm_ActualizaFormulacion_Ingreso_Filtro();
            frm.ShowMe();
            if (frm.blnProcesaExcel == true)
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                SplashScreenManager.Default.SetWaitFormDescription("Recopilando informaciòn...");

                //Habilitar Opciones
                this.Btn_BuscaClasificador.Enabled = true;
                this.Btn_DistribuyeLineaFormulada.Enabled = true;
                this.Btn_MostarOrdenesPendientes.Enabled = true;
                this.Btn_Guardar.Enabled = true;
                this.Btn_Imprimir.Enabled = true;
                this.Btn_EliminarFilas.Enabled = true;


                //Traer Dato de la tabla




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
               
                strAñoProceso = MFC.CañoProceso;
                strVersion = MFC.Cversion;
                strCodTipoFormulacion = "11";
                strCodProyecto = frm.strCodProyecto;
                strCodCentroCosto = frm.strCodCentroCosto;

                //-- Recuperar Datos

                Service.DataGeneral SDG = new Service.DataGeneral();

                if (MyStuff.UsaWCF == true)
                {
                    DS_ClaseIngreso = objWCF.Combo_ClaseIngreso();

                    DS_FuenteFinanciamiento = objWCF.Combo_Tarea_FuenteFinanciamiento("000000", strCodProyecto);
                    Service.Formulacion_Detalle_Ingreso SFDP = new Service.Formulacion_Detalle_Ingreso();
                    DS_Formulacion = objWCF.Lista_FormulacionDetalle_Ingreso("000000", strCodProyecto, strCodCentroCosto, strCodTipoFormulacion);
                }
                else
                {
                    DS_ClaseIngreso = SDG.Combo_ClaseIngreso();

                    DS_FuenteFinanciamiento = SDG.Combo_Tarea_FuenteFinanciamiento("000000", strCodProyecto);
                    Service.Formulacion_Detalle_Ingreso SFDP = new Service.Formulacion_Detalle_Ingreso();
                    DS_Formulacion = SFDP.Lista_FormulacionDetalle_Ingreso("000000", strCodProyecto, strCodCentroCosto, strCodTipoFormulacion);
                }


                workbook = spreadsheetControl.Document;
                string sRutaInterna = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Excel\Formulacion_Ingreso.xlsx");
                workbook.LoadDocument(sRutaInterna, DocumentFormat.Xlsx);


                Worksheet worksheet_HojaTrabajo = workbook.Worksheets[0];
                worksheet_HojaTrabajo["AB10:AB205"].NumberFormat = "[Black]#,##0.00;";
                worksheet_HojaTrabajo["I10:I200"].Protection.Locked = false;


                worksheet_HojaTrabajo.Cells[2, 2].Value = frm.strNomProyecto;
                worksheet_HojaTrabajo.Cells[3, 2].Value = frm.strNomCentroCosto;

                worksheet_HojaTrabajo.Cells[2, 26].Value = MFC.CañoProceso;
                worksheet_HojaTrabajo.Cells[3, 26].Value = MFC.Cversion;
                worksheet_HojaTrabajo.Cells[4, 26].Value = "Ingreso";



                //DV_Excel = DS_Formulacion.Tables[0].DefaultView;
                //worksheet_HojaTrabajo.DataBindings.BindToDataSource(DV_Excel, 9, 1);

                int intLinea = 9;
                foreach (DataRow oRow1 in DS_Formulacion.Tables[0].Rows)
                {
                    string Rango = traeRangoCelda(1, intLinea + 1, 1, intLinea + 1);
                    workbook = spreadsheetControl.Document;
                    Range range = worksheet_HojaTrabajo.Range[Rango];
                    Formatting rangeFormatting = range.BeginUpdateFormatting();
                    rangeFormatting.Fill.BackgroundColor = Color.Green;
                    range.EndUpdateFormatting(rangeFormatting);

                    worksheet_HojaTrabajo.Cells[intLinea, 1].Value = Convert.ToString(oRow1["vNomTipoInserccion"]);
                    worksheet_HojaTrabajo.Cells[intLinea, 2].Value = Convert.ToString(oRow1["vNomClaseIngreso"]);
                    worksheet_HojaTrabajo.Cells[intLinea, 3].Value = Convert.ToString(oRow1["cCodClasificador"]);
                    worksheet_HojaTrabajo.Cells[intLinea, 4].Value = Convert.ToString(oRow1["vNomClasificador"]);
                    worksheet_HojaTrabajo.Cells[intLinea, 5].Value = Convert.ToString(oRow1["cCodPosPre"]);
                    worksheet_HojaTrabajo.Cells[intLinea, 6].Value = Convert.ToString(oRow1["vNomPosPre"]);
                    worksheet_HojaTrabajo.Cells[intLinea, 7].Value = Convert.ToString(oRow1["vNomFuenteFinanciamiento"]);
                    worksheet_HojaTrabajo.Cells[intLinea, 8].Value = Convert.ToString(oRow1["Orden"]);
                    worksheet_HojaTrabajo.Cells[intLinea, 9].Value = Convert.ToString(oRow1["tDescripcionIngreso"]);
                    worksheet_HojaTrabajo.Cells[intLinea, 10].Value = Convert.ToDouble(oRow1["fValorAnterior"]);
                    worksheet_HojaTrabajo.Cells[intLinea, 11].Value = Convert.ToDouble(oRow1["fValorRestoActual"]);
                    worksheet_HojaTrabajo.Cells[intLinea, 12].Value = Convert.ToDouble(oRow1["fMes_01"]);
                    worksheet_HojaTrabajo.Cells[intLinea, 13].Value = Convert.ToDouble(oRow1["fMes_02"]);
                    worksheet_HojaTrabajo.Cells[intLinea, 14].Value = Convert.ToDouble(oRow1["fMes_03"]);
                    worksheet_HojaTrabajo.Cells[intLinea, 15].Value = Convert.ToDouble(oRow1["fMes_04"]);
                    worksheet_HojaTrabajo.Cells[intLinea, 16].Value = Convert.ToDouble(oRow1["fMes_05"]);
                    worksheet_HojaTrabajo.Cells[intLinea, 17].Value = Convert.ToDouble(oRow1["fMes_06"]);
                    worksheet_HojaTrabajo.Cells[intLinea, 18].Value = Convert.ToDouble(oRow1["fMes_07"]);
                    worksheet_HojaTrabajo.Cells[intLinea, 19].Value = Convert.ToDouble(oRow1["fMes_08"]);
                    worksheet_HojaTrabajo.Cells[intLinea, 20].Value = Convert.ToDouble(oRow1["fMes_09"]);
                    worksheet_HojaTrabajo.Cells[intLinea, 21].Value = Convert.ToDouble(oRow1["fMes_10"]);
                    worksheet_HojaTrabajo.Cells[intLinea, 22].Value = Convert.ToDouble(oRow1["fMes_11"]);
                    worksheet_HojaTrabajo.Cells[intLinea, 23].Value = Convert.ToDouble(oRow1["fMes_12"]);
                    worksheet_HojaTrabajo.Cells[intLinea, 24].Value = Convert.ToDouble(oRow1["fValorFormulacion"]);
                    worksheet_HojaTrabajo.Cells[intLinea, 25].Value = Convert.ToDouble(oRow1["fValorFormulacionUno"]);
                    worksheet_HojaTrabajo.Cells[intLinea, 26].Value = Convert.ToDouble(oRow1["fValorFormulacionDos"]);
                    worksheet_HojaTrabajo.Cells[intLinea, 27].Value = Convert.ToDouble(oRow1["Distribucion"]);
                    worksheet_HojaTrabajo.Cells[intLinea, 28].Value = Convert.ToInt32(oRow1["iidFormulacion_Detalle_Ingreso"]);

                    worksheet_HojaTrabajo.Cells[intLinea, 1000].Value = Convert.ToString(oRow1["vNomFuenteFinanciamiento"]);

                    this.FormatoCeldas(intLinea);
                    intLinea = intLinea + 1;
                    //}
                }

                this.ValidarColumnas();
                
                SplashScreenManager.CloseForm();

            }
            else
            {
                //if (blnSalir == true)
                //this.Close();
            }
        }

        private void ValidarColumnas_Orden()
        {
            Worksheet worksheet_HojaTrabajo = workbook.Worksheets[0];

            DataValidation validation_worksheet_Importe =
                    worksheet_HojaTrabajo.DataValidations.Add(worksheet_HojaTrabajo["K10:AA500"],
                                                                DataValidationType.Custom, "=AND( K10 >= 0, ISNUMBER(K10) )"
                                                             );

 
            validation_worksheet_Importe.ErrorTitle = "Advertencia";
            validation_worksheet_Importe.ErrorMessage = "El Dato no es correcto";
            validation_worksheet_Importe.ShowErrorMessage = true;

            //-- Fuente de Financiamiento

            Worksheet worksheet_FuenteFinanciamiento = workbook.Worksheets[2];
            worksheet_HojaTrabajo.DataValidations.Add(worksheet_HojaTrabajo["H10:H500"], DataValidationType.List, ValueObject.FromRange(worksheet_FuenteFinanciamiento[strCelda_FuenteFinanciamiento].GetRangeWithAbsoluteReference()));

        }

        private void ValidarColumnas()
        {
            Worksheet worksheet_HojaTrabajo = workbook.Worksheets[0];

            DataValidation validation_worksheet_Importe =
                    worksheet_HojaTrabajo.DataValidations.Add(worksheet_HojaTrabajo["K10:AA500"],
                                                                DataValidationType.Custom, "=AND( K10 >= 0, ISNUMBER(K10))"
                                                             );

            validation_worksheet_Importe.ErrorTitle = "Advertencia";
            validation_worksheet_Importe.ErrorMessage = "El Dato no es correcto";
            validation_worksheet_Importe.ShowErrorMessage = true;

            //-- Fuente de Financiamiento

            Worksheet worksheet_FuenteFinanciamiento = workbook.Worksheets[2];
            worksheet_FuenteFinanciamiento.Visible = false;
            DV_FuenteFinanciamiento = DS_FuenteFinanciamiento.Tables[0].DefaultView;
            worksheet_FuenteFinanciamiento.DataBindings.BindToDataSource(DV_FuenteFinanciamiento, 1, 0);

            Range boundrange_FuenteFinanciamiento = worksheet_FuenteFinanciamiento.DataBindings[0].Range;
            strCelda_FuenteFinanciamiento = traeRangoCelda_FuenteFinanciamiento(boundrange_FuenteFinanciamiento.LeftColumnIndex + 1,
                                                           boundrange_FuenteFinanciamiento.TopRowIndex + 1,
                                                           boundrange_FuenteFinanciamiento.RightColumnIndex + 1,
                                                           boundrange_FuenteFinanciamiento.BottomRowIndex + 1
                                            );


            worksheet_HojaTrabajo.DataValidations.Add(worksheet_HojaTrabajo["H10:H500"], DataValidationType.List, ValueObject.FromRange(worksheet_FuenteFinanciamiento[strCelda_FuenteFinanciamiento].GetRangeWithAbsoluteReference()));
        }

        private string juntaOrdenes()
        {
            string strOrdenes = "";
            intNumeroOrdenes = 0;
            int intLinea = 9;
            workbook = spreadsheetControl.Document;
            Worksheet worksheet_HojaTrabajo = workbook.Worksheets[0];
            
            while (true)
            {

                if (string.IsNullOrEmpty(Convert.ToString(worksheet_HojaTrabajo.Cells[ intLinea, 1].Value.TextValue)))
                    break;

                if (Convert.ToString(worksheet_HojaTrabajo.Cells[intLinea, 1].Value.TextValue).TrimEnd() == "Año Actual")
                    break;

                if (!string.IsNullOrEmpty(  Convert.ToString(worksheet_HojaTrabajo.Cells[intLinea, 8].Value.TextValue)) )
                {
                    strOrdenes = strOrdenes + 
                                 strCodProyecto.TrimEnd() + 
                                 Convert.ToString(worksheet_HojaTrabajo.Cells[intLinea, 8].Value.TextValue).TrimEnd() + "/";
                    intNumeroOrdenes = intNumeroOrdenes + 1;
                }
                intLinea = intLinea + 1;
            }

            return strOrdenes;

        }

        #endregion

        #region Inicio de Formulario

        private void Frm_ActualizaFormulacion_Proyecto_Load(object sender, EventArgs e)
        {
            //this.Show();
            //this.MostrarFiltro(true);
        }
        #endregion


        #region Encontrar rango de datos

        private string traeRangoCelda_FuenteFinanciamiento(int y1, int x1, int y2, int x2)
        {
            string strCelda = "";
            char columna1;
            string fila1;
            columna1 = Convert.ToChar(64 + y1);
            fila1 = Convert.ToString(x1).TrimEnd();
            char columna2;
            string fila2;
            columna2 = Convert.ToChar(64 + y2);
            fila2 = Convert.ToString(x2).TrimEnd();

            strCelda = Convert.ToString(columna1).TrimEnd() +
                       fila1.TrimEnd() + ":" +
                       Convert.ToString(columna1).TrimEnd() +
                       fila2.TrimEnd();

            return strCelda;
        }

        private string traeRangoCelda(int y1, int x1, int y2, int x2)
        {
            string strCelda = "";
            char columna1;
            string fila1;
            string letra = "";
            columna1 = Convert.ToChar(64 + y1);
            fila1 = Convert.ToString(x1).TrimEnd();
            char columna2;
            string fila2;
            if (y2>25)
            {
                y2 = y2 - 25;
                letra = "A";
            }

            columna2 = Convert.ToChar(64 + y2 );
            
            fila2 = Convert.ToString(x2).TrimEnd();

            strCelda = Convert.ToString(columna1).TrimEnd() +
                       fila1.TrimEnd() + ":" +
                       letra + Convert.ToString(columna2).TrimEnd() +
                       fila2.TrimEnd();

            return strCelda;
        }


        private string traeRangoCelda_ClaseGasto(int y1, int x1, int y2, int x2)
        {
            string strCelda = "";
            char columna1;
            string fila1;
            columna1 = Convert.ToChar(64 + y1);
            fila1 = Convert.ToString(x1).TrimEnd();
            char columna2;
            string fila2;
            columna2 = Convert.ToChar(64 + y2);
            fila2 = Convert.ToString(x2).TrimEnd();

            strCelda = Convert.ToString(columna2).TrimEnd() +
                       fila1.TrimEnd() + ":" +
                       Convert.ToString(columna2).TrimEnd() +
                       fila2.TrimEnd();

            return strCelda;
        }

        private string traeRangoCelda_PlanContable(int y1, int x1, int y2, int x2)
        {
            string strCelda = "";
            char columna1;
            string fila1;
            columna1 = Convert.ToChar(64 + y1);
            fila1 = Convert.ToString(x1).TrimEnd();
            char columna2;
            string fila2;
            columna2 = Convert.ToChar(64 + y2);
            fila2 = Convert.ToString(x2).TrimEnd();

            strCelda = Convert.ToString(columna1).TrimEnd() +
                       fila1.TrimEnd() + ":" +
                       Convert.ToString(columna1).TrimEnd() +
                       fila2.TrimEnd();

            return strCelda;
        }

        #endregion


        private Boolean ValidaLineaGrabacion(Model.Formulacion_Detalle_Ingreso MFDP, int Linea)
        {
            Boolean blnFilaErrada = false;
            workbook = spreadsheetControl.Document;
            Worksheet worksheet_HojaTrabajo = workbook.Worksheets[0];

            if (MFDP.FvalorFormulacion == 0)
            {
                pintarError(Linea, "Y", true);
                blnFilaErrada = true;
            }
            else
            {
                pintarError(Linea, "Y", false);
            }

            if (string.IsNullOrEmpty(Convert.ToString(worksheet_HojaTrabajo.Cells[Linea, 2].Value.TextValue)))
            {
                pintarError(Linea, "C", true);
                blnFilaErrada = true;
            }
            else
            {
                pintarError(Linea, "C", false);
            }

            if (string.IsNullOrEmpty(Convert.ToString(worksheet_HojaTrabajo.Cells[Linea, 3].Value.TextValue)))
            {
                pintarError(Linea, "D", true);
                blnFilaErrada = true;
            }
            else
            {
                pintarError(Linea, "D", false);
            }

            if (string.IsNullOrEmpty(Convert.ToString(worksheet_HojaTrabajo.Cells[Linea, 5].Value.TextValue)))
            {
                pintarError(Linea, "F", true);
                blnFilaErrada = true;
            }
            else
            {
                pintarError(Linea, "F", false);
            }

            if (string.IsNullOrEmpty(Convert.ToString(worksheet_HojaTrabajo.Cells[Linea, 9].Value.TextValue)))
            {
                pintarError(Linea, "J", true);
                blnFilaErrada = true;
            }
            else
            {
                pintarError(Linea, "J", false);
            }

            if (!string.IsNullOrEmpty(Convert.ToString(worksheet_HojaTrabajo.Cells[Linea, 8].Value.TextValue)))
            {
                if (worksheet_HojaTrabajo.Cells[Linea, 27].Value.NumericValue != 0 )
                {
                    pintarError(Linea, "AB", true);
                    blnFilaErrada = true;
                }
                else
                {
                    pintarError(Linea, "AB", false);
                }
            }
            else
            {
                pintarError(Linea, "AB", false);
            }

            return blnFilaErrada;

        }

        private void pintarError(int intFila, string strColumna, Boolean blnError)
        {
            string strFila = Convert.ToString(intFila + 1);
            strColumna = strColumna.TrimEnd();
            string Rango = strColumna + strFila;
            workbook = spreadsheetControl.Document;
            Worksheet worksheet_HojaTrabajo = workbook.Worksheets[0];
            Range range = worksheet_HojaTrabajo.Range[Rango];
            Formatting rangeFormatting = range.BeginUpdateFormatting();
            if (blnError == true)
            {
                rangeFormatting.Fill.BackgroundColor = Color.Yellow;
            }
            else
            {
                rangeFormatting.Fill.BackgroundColor = Color.White;
            }

            range.EndUpdateFormatting(rangeFormatting);
        }




        private void FormatoCeldas(int intLinea)
        {
            //string Rango = traeRangoCelda(13, intLinea + 1, 24, intLinea + 1);
            workbook = spreadsheetControl.Document;
            Worksheet worksheet_HojaTrabajo = workbook.Worksheets[0];
            worksheet_HojaTrabajo.Cells[intLinea, 10].NumberFormat = "#,##0.00";
            worksheet_HojaTrabajo.Cells[intLinea, 11].NumberFormat = "#,##0.00";
            worksheet_HojaTrabajo.Cells[intLinea, 12].NumberFormat = "#,##0.00";
            worksheet_HojaTrabajo.Cells[intLinea, 13].NumberFormat = "#,##0.00";
            worksheet_HojaTrabajo.Cells[intLinea, 14].NumberFormat = "#,##0.00";
            worksheet_HojaTrabajo.Cells[intLinea, 15].NumberFormat = "#,##0.00";
            worksheet_HojaTrabajo.Cells[intLinea, 16].NumberFormat = "#,##0.00";
            worksheet_HojaTrabajo.Cells[intLinea, 17].NumberFormat = "#,##0.00";
            worksheet_HojaTrabajo.Cells[intLinea, 18].NumberFormat = "#,##0.00";
            worksheet_HojaTrabajo.Cells[intLinea, 19].NumberFormat = "#,##0.00";
            worksheet_HojaTrabajo.Cells[intLinea, 20].NumberFormat = "#,##0.00";
            worksheet_HojaTrabajo.Cells[intLinea, 21].NumberFormat = "#,##0.00";
            worksheet_HojaTrabajo.Cells[intLinea, 22].NumberFormat = "#,##0.00";
            worksheet_HojaTrabajo.Cells[intLinea, 23].NumberFormat = "#,##0.00";
            worksheet_HojaTrabajo.Cells[intLinea, 24].NumberFormat = "#,##0.00";
            worksheet_HojaTrabajo.Cells[intLinea, 25].NumberFormat = "#,##0.00";
            worksheet_HojaTrabajo.Cells[intLinea, 26].NumberFormat = "#,##0.00";

            string strLinea = Convert.ToString(intLinea + 1).TrimEnd();

            string strSuma_2020 = "=SUM(" + "M" + strLinea + ":X" + strLinea + ")";
            string strPorDistribuir = "=" + "SI(K" + strLinea + "=0;0;" + "K" + strLinea + "-(L" + strLinea + "+Y" + strLinea + "+Z" + strLinea + "+AA" + strLinea + "))";
            worksheet_HojaTrabajo.Cells[intLinea, 24].Formula = strSuma_2020;
            worksheet_HojaTrabajo.Cells[intLinea, 27].Formula = strPorDistribuir;

        }

        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            this.MostrarFiltro(false);
        }

        private void Btn_BuscaClasificador_Click(object sender, EventArgs e)
        {
            workbook = spreadsheetControl.Document;
            Worksheet worksheet_HojaTrabajo = workbook.Worksheets[0];
            int intLinea = worksheet_HojaTrabajo.SelectedCell.TopRowIndex;

            if (intLinea < 9)
            {
                MessageBox.Show("Debe posicionarse en la fila 10 o superior");
            }
            else
            {
                string strNomClaseIngreso = Convert.ToString(worksheet_HojaTrabajo.Cells[intLinea, 1].Value.TextValue); ;
                if (string.IsNullOrEmpty(strNomClaseIngreso))
                {
                    strNomClaseIngreso = "";
                }
                string strCodClaseIngreso = FS.TraerDescripcion_DataTable(DS_ClaseIngreso.Tables[0],
                                                                                                       1,
                                                                                                       0,
                                                                                                       strNomClaseIngreso
                                                                                                     );

                WINformulacion.Frm_Clasificacion_Ingreso frm = new WINformulacion.Frm_Clasificacion_Ingreso();
                frm.Showme("000000", strCodProyecto, intLinea + 1, "01", strCodCentroCosto);
                if (frm.blnEligio == true)
                {
                    worksheet_HojaTrabajo.Cells[intLinea, 2].Value = frm.strNomClaseIngreso;
                    worksheet_HojaTrabajo.Cells[intLinea, 3].Value = frm.strCodClasificacion;
                    worksheet_HojaTrabajo.Cells[intLinea, 4].Value = frm.strNomClasificacion;
                    worksheet_HojaTrabajo.Cells[intLinea, 5].Value = frm.strCodCuentaContable;
                    worksheet_HojaTrabajo.Cells[intLinea, 6].Value = frm.strNomCuentaContable;
                    this.FormatoCeldas(intLinea);
                }

            }
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            //-- Boton Guardar Documento

            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            SplashScreenManager.Default.SetWaitFormDescription("Grabando información...");

            Model.Formulacion_Detalle_Ingreso MFDP = new Model.Formulacion_Detalle_Ingreso();
            Service.Formulacion_Detalle_Ingreso SFDP = new Service.Formulacion_Detalle_Ingreso();

            workbook = spreadsheetControl.Document;
            Worksheet worksheet_HojaTrabajo = workbook.Worksheets[0];

            int _Rows = 9;
            int intIdFormulacion_Detalle_Ingreso = 0;

            while (true)
            {

                if (string.IsNullOrEmpty(Convert.ToString(worksheet_HojaTrabajo.Cells[_Rows, 2].Value.TextValue)))
                    break;





                MFDP.IidFormulacion_Detalle_Ingreso = Convert.ToInt32(worksheet_HojaTrabajo.Cells[_Rows, 28].Value.NumericValue);
                MFDP.CañoProceso = strAñoProceso;
                MFDP.Cversion = strVersion;
                MFDP.CcodCeCo = strCodCentroCosto;
                MFDP.CcodCeCo_Gestor = strCodCentroCosto;
                MFDP.CcodPosPre = Convert.ToString(worksheet_HojaTrabajo.Cells[_Rows, 5].Value.TextValue);

                if ( string.IsNullOrEmpty( Convert.ToString(worksheet_HojaTrabajo.Cells[_Rows, 8].Value.TextValue)) )
                {
                    MFDP.CTipoOrden = "";
                    MFDP.CNumeroOrden = "";
                }
                else
                {
                    MFDP.CTipoOrden = Convert.ToString(worksheet_HojaTrabajo.Cells[_Rows, 8].Value.TextValue).Substring(0, 2);
                    MFDP.CNumeroOrden = Convert.ToString(worksheet_HojaTrabajo.Cells[_Rows, 8].Value.TextValue).Substring(3, 10);
                }


                MFDP.CcodFuenteFinanciamiento = "001";
                MFDP.CcodTipoFormulacion = strCodTipoFormulacion;
                MFDP.CcodProyecto = strCodProyecto;
                MFDP.CcodClaseIngreso = FS.TraerDescripcion_DataTable(DS_ClaseIngreso.Tables[0],
                                                                                                       0,
                                                                                                       1,
                                                                                                       Convert.ToString(worksheet_HojaTrabajo.Cells[_Rows, 2].Value.TextValue)
                                                                                                     );
                //MFDP.CcodClaseGasto = "01";
                MFDP.TdescripcionIngreso = Convert.ToString(worksheet_HojaTrabajo.Cells[_Rows, 9].Value.TextValue);
                MFDP.FvalorAnterior = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 10].Value.NumericValue);
                MFDP.FvalorRestoActual = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 11].Value.NumericValue);
                MFDP.FvalorFormulacion = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 24].Value.NumericValue);
                MFDP.FvalorFormulacionUno = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 25].Value.NumericValue);
                MFDP.FvalorFormulacionDos = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 26].Value.NumericValue);

                if (Convert.ToString(worksheet_HojaTrabajo.Cells[_Rows, 1].Value.TextValue) == "Año Anterior")
                {
                    MFDP.IcodTipoInserccion = 2; // 2 Automatico 
                }
                else
                {
                    MFDP.IcodTipoInserccion = 1; //- 1 Manual
                }

                MFDP.Cusuario = MyStuff.CodigoEmpleado;

                MFDP.Fmes_01 = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 12].Value.NumericValue);
                MFDP.Fmes_02 = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 13].Value.NumericValue);
                MFDP.Fmes_03 = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 14].Value.NumericValue);
                MFDP.Fmes_04 = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 15].Value.NumericValue);
                MFDP.Fmes_05 = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 16].Value.NumericValue);
                MFDP.Fmes_06 = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 17].Value.NumericValue);
                MFDP.Fmes_07 = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 18].Value.NumericValue);
                MFDP.Fmes_08 = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 19].Value.NumericValue);
                MFDP.Fmes_09 = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 20].Value.NumericValue);
                MFDP.Fmes_10 = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 21].Value.NumericValue);
                MFDP.Fmes_11 = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 22].Value.NumericValue);
                MFDP.Fmes_12 = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 23].Value.NumericValue);

                if (ValidaLineaGrabacion(MFDP, _Rows) == false)
                {
                    if (MFDP.IidFormulacion_Detalle_Ingreso == 0)
                    {
                        if (MyStuff.UsaWCF == true)
                        {
                             intIdFormulacion_Detalle_Ingreso = objWCF.Graba_FormulacionDetalle_Ingreso(MFDP);
                        }
                        else
                        {
                            intIdFormulacion_Detalle_Ingreso = SFDP.Graba_FormulacionDetalle_Ingreso(MFDP);
                        }

                        string Rango = traeRangoCelda(1, _Rows + 1, 1, _Rows + 1);
                        workbook = spreadsheetControl.Document;
                        Range range = worksheet_HojaTrabajo.Range[Rango];
                        Formatting rangeFormatting = range.BeginUpdateFormatting();
                        rangeFormatting.Fill.BackgroundColor = Color.Green;
                        range.EndUpdateFormatting(rangeFormatting);

                        worksheet_HojaTrabajo.Cells[_Rows, 28].Value = intIdFormulacion_Detalle_Ingreso;
                    }
                    else
                    {
                        if (MyStuff.UsaWCF == true)
                        {
                             intIdFormulacion_Detalle_Ingreso = objWCF.Modifica_FormulacionDetalle_Ingreso(MFDP);
                        }
                        else
                        {
                            intIdFormulacion_Detalle_Ingreso = SFDP.Modifica_FormulacionDetalle_Ingreso(MFDP);
                        }
                        
                    }
                    
                }

                _Rows++;



            }

            SplashScreenManager.CloseForm();

        }

        private void Btn_DistribuyeLineaFormulada_Click(object sender, EventArgs e)
        {
            workbook = spreadsheetControl.Document;
            Worksheet worksheet_HojaTrabajo = workbook.Worksheets[0];
            int intLinea = worksheet_HojaTrabajo.SelectedCell.TopRowIndex;

            if (intLinea < 9)
            {
                MessageBox.Show("Debe posicionarse en la fila 10 o superior");
            }
            else
            {

                //if (worksheet_HojaTrabajo.Cells[intLinea, 9].Value.NumericValue == 0)
                //{
                //    MessageBox.Show("Debe ingresar el valor de la formulación");
                //}
                //else
                {
                    //strCodMetodoDistribucion = "";
                    //if ( !string.IsNullOrEmpty( Convert.ToString( worksheet_HojaTrabajo.Cells[intLinea, 9].Value.TextValue ) ) )
                    //{
                    //    strCodMetodoDistribucion = FS.TraerDescripcion_DataTable(DS_MetodoDistribucion.Tables[0],
                    //                                                                                   1,
                    //                                                                                   0,
                    //                                                                                   Convert.ToString(worksheet_HojaTrabajo.Cells[intLinea, 9].Value.TextValue)
                    //                                                                                 );
                    //}

                    WINformulacion.Frm_ActualizaDistribucion frm = new WINformulacion.Frm_ActualizaDistribucion();
                    frm.ShowMe(intLinea,
                                Convert.ToDouble(worksheet_HojaTrabajo.Cells[intLinea, 10].Value.NumericValue),
                                Convert.ToDouble(worksheet_HojaTrabajo.Cells[intLinea, 11].Value.NumericValue),
                                Convert.ToDouble(worksheet_HojaTrabajo.Cells[intLinea, 24].Value.NumericValue),
                                Convert.ToDouble(worksheet_HojaTrabajo.Cells[intLinea, 25].Value.NumericValue),
                                Convert.ToDouble(worksheet_HojaTrabajo.Cells[intLinea, 26].Value.NumericValue),
                                worksheet_HojaTrabajo.Cells[intLinea, 12].Value.NumericValue,
                                worksheet_HojaTrabajo.Cells[intLinea, 13].Value.NumericValue,
                                worksheet_HojaTrabajo.Cells[intLinea, 14].Value.NumericValue,
                                worksheet_HojaTrabajo.Cells[intLinea, 15].Value.NumericValue,
                                worksheet_HojaTrabajo.Cells[intLinea, 16].Value.NumericValue,
                                worksheet_HojaTrabajo.Cells[intLinea, 17].Value.NumericValue,
                                worksheet_HojaTrabajo.Cells[intLinea, 18].Value.NumericValue,
                                worksheet_HojaTrabajo.Cells[intLinea, 19].Value.NumericValue,
                                worksheet_HojaTrabajo.Cells[intLinea, 20].Value.NumericValue,
                                worksheet_HojaTrabajo.Cells[intLinea, 21].Value.NumericValue,
                                worksheet_HojaTrabajo.Cells[intLinea, 22].Value.NumericValue,
                                worksheet_HojaTrabajo.Cells[intLinea, 23].Value.NumericValue
                             );
                    frm.ShowDialog();

                    if (frm.blnDistribuyo == true)
                    {
                        worksheet_HojaTrabajo.Cells[intLinea, 10].Value = frm.dblSaldoAnteior;
                        worksheet_HojaTrabajo.Cells[intLinea, 11].Value = frm.dblImporte_2019;
                        worksheet_HojaTrabajo.Cells[intLinea, 24].Value = frm.dblImporte_2020;
                        worksheet_HojaTrabajo.Cells[intLinea, 25].Value = frm.dblImporte_2021;
                        worksheet_HojaTrabajo.Cells[intLinea, 26].Value = frm.dblImporte_2022;
                        worksheet_HojaTrabajo.Cells[intLinea, 12].Value = frm.dblEnero;
                        worksheet_HojaTrabajo.Cells[intLinea, 12].Value = frm.dblEnero;
                        worksheet_HojaTrabajo.Cells[intLinea, 13].Value = frm.dblFebrero;
                        worksheet_HojaTrabajo.Cells[intLinea, 14].Value = frm.dblMarzo;
                        worksheet_HojaTrabajo.Cells[intLinea, 15].Value = frm.dblAbril;
                        worksheet_HojaTrabajo.Cells[intLinea, 16].Value = frm.dblMayo;
                        worksheet_HojaTrabajo.Cells[intLinea, 17].Value = frm.dblJunio;
                        worksheet_HojaTrabajo.Cells[intLinea, 18].Value = frm.dblJulio;
                        worksheet_HojaTrabajo.Cells[intLinea, 19].Value = frm.dblAgosto;
                        worksheet_HojaTrabajo.Cells[intLinea, 20].Value = frm.dblSetiembre;
                        worksheet_HojaTrabajo.Cells[intLinea, 21].Value = frm.dblOctubre;
                        worksheet_HojaTrabajo.Cells[intLinea, 22].Value = frm.dblNoviembre;
                        worksheet_HojaTrabajo.Cells[intLinea, 23].Value = frm.dblDiciembre;
                        worksheet_HojaTrabajo.Cells[intLinea, 24].Value = frm.dblTotalDistribucion;
                        this.FormatoCeldas(intLinea);
                    }
                }
            }
        }

        private void Btn_MostarOrdenesPendientes_Click(object sender, EventArgs e)
        {
            workbook = spreadsheetControl.Document;
            Worksheet worksheet_HojaTrabajo = workbook.Worksheets[0];
            string strNomProyecto = worksheet_HojaTrabajo.Cells[2, 2].Value.TextValue;
            strListaOrdenes = this.juntaOrdenes();
            WINformulacion.Frm_ActualizaFormulacion_Proyecto_Inversion_AñoAnterior frm = new WINformulacion.Frm_ActualizaFormulacion_Proyecto_Inversion_AñoAnterior();
            frm.ShowMe("000000", strCodProyecto, strCodCentroCosto, strNomProyecto, strListaOrdenes);  //jesus


            if (frm.blnEligio == true)
            {

                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                SplashScreenManager.Default.SetWaitFormDescription("Procesando información Año Anterior...");

                string strTipoOrden = "";
                string strNumeroOrden = "";

                int intLinea = 9;

                DataSet DS = new DataSet();
                Service.DataGeneral SDG = new Service.DataGeneral();

                worksheet_HojaTrabajo.Rows.Insert(9 + intNumeroOrdenes, frm.intNumeroOrdenes);
                intLinea = 9 + intNumeroOrdenes;

                int intRegistro = 0;
                foreach (DataRow oRow in frm.DT_Proyecto.Rows)
                {
                    intRegistro = intRegistro + 1;
  
                    if (Convert.ToBoolean(oRow["bPase"]) == true)
                    {
                        strTipoOrden = Convert.ToString(oRow["TipoOrden"]);
                        strNumeroOrden = Convert.ToString(oRow["NumeroOrden"]);
                        if (strTipoOrden.TrimEnd() == "SO")
                        {
                            if (MyStuff.UsaWCF == true)
                            {
                                 DS = objWCF.Lista_Proyecto_IncorporaSaldoAñoAnterior_OS("000000",
                                                                                  strCodProyecto,
                                                                                  strCodCentroCosto,
                                                                                  strNumeroOrden
                                                                                );
                            }
                            else
                            {
                                DS = SDG.Lista_Proyecto_IncorporaSaldoAñoAnterior_OS("000000",
                                                                                 strCodProyecto,
                                                                                 strCodCentroCosto,
                                                                                 strNumeroOrden
                                                                               );
                            }
                           
                            //SDG.Graba_Proyecto_OrdenTemporal(MyStuff.CodigoEmpleado, strTipoOrden, strNumeroOrden);
                        }
                        else
                        {
                            if (MyStuff.UsaWCF == true)
                            {
                                 DS = objWCF.Lista_Proyecto_IncorporaSaldoAñoAnterior_OC("000000",
                                                                                  strCodProyecto,
                                                                                  strCodCentroCosto,
                                                                                  strNumeroOrden
                                                                                );
                            }
                            else
                            {
                                DS = SDG.Lista_Proyecto_IncorporaSaldoAñoAnterior_OC("000000",
                                                                     strCodProyecto,
                                                                     strCodCentroCosto,
                                                                     strNumeroOrden
                                                                   );
                            }
               
                            //SDG.Graba_Proyecto_OrdenTemporal(MyStuff.CodigoEmpleado, strTipoOrden, strNumeroOrden);
                        }

                        foreach (DataRow oRow1 in DS.Tables[0].Rows)
                        {
                            //if (Convert.ToDouble(oRow1["Saldo"]) != 0)
                            //{
                                worksheet_HojaTrabajo.Cells[intLinea, 2].Value = "Gasto Capital";
                                worksheet_HojaTrabajo.Cells[intLinea, 3].Value = Convert.ToString(oRow1["Clasificador"]);
                                worksheet_HojaTrabajo.Cells[intLinea, 4].Value = Convert.ToString(oRow1["NombreClasificador"]);
                                worksheet_HojaTrabajo.Cells[intLinea, 5].Value = Convert.ToString(oRow1["CuentaContable"]);
                                worksheet_HojaTrabajo.Cells[intLinea, 6].Value = Convert.ToString(oRow1["NombreCuentaContable"]);
                                worksheet_HojaTrabajo.Cells[intLinea, 8].Value = strTipoOrden.TrimEnd() + "-" +  strNumeroOrden;
                                worksheet_HojaTrabajo.Cells[intLinea, 1000].Value = strTipoOrden.TrimEnd() + "-" + strNumeroOrden;
                                worksheet_HojaTrabajo.Cells[intLinea, 9].Value = Convert.ToString(oRow1["ObjetoContratacion"]);
                                worksheet_HojaTrabajo.Cells[intLinea, 10].Value = Convert.ToDouble(oRow1["Saldo"]);
                                worksheet_HojaTrabajo.Cells[intLinea, 28].Value = 0;
                                worksheet_HojaTrabajo.Cells[intLinea, 1].Value = "Año Anterior";
                            worksheet_HojaTrabajo["AB10:AB205"].NumberFormat = "[Black]#,##0.00;";
                            this.FormatoCeldas(intLinea);
                                intLinea = intLinea + 1;
                            //}
                        }
                        

                    }
                    
                }
                this.ValidarColumnas_Orden();
                SplashScreenManager.CloseForm();

            }

        }

        private void spreadsheetControl_CellValueChanged(object sender, DevExpress.XtraSpreadsheet.SpreadsheetCellEventArgs e)
        {
        }

        private void spreadsheetControl_CellBeginEdit(object sender, DevExpress.XtraSpreadsheet.SpreadsheetCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 9)
                e.Cancel = true;

            if (e.ColumnIndex == 1 && e.RowIndex >= 9)
                e.Cancel = true;

            if (e.ColumnIndex == 2 && e.RowIndex >= 9)
                e.Cancel = true;

            if (e.ColumnIndex == 3 && e.RowIndex >= 9)
                e.Cancel = true;
            if (e.ColumnIndex == 4 && e.RowIndex >= 9)
                e.Cancel = true;
            if (e.ColumnIndex == 5 && e.RowIndex >= 9)
                e.Cancel = true;
            if (e.ColumnIndex == 6 && e.RowIndex >= 9)
                e.Cancel = true;

            if (e.ColumnIndex == 8 && e.RowIndex>=9  )
                e.Cancel = true;

            if (e.ColumnIndex == 10 && e.RowIndex >= 9)
                e.Cancel = true;

            if (e.ColumnIndex == 24 && e.RowIndex >= 9)
                e.Cancel = true;

            if (e.ColumnIndex == 27 && e.RowIndex >= 9)
                e.Cancel = true;

        }

        private void Btn_EliminarFilas_Click(object sender, EventArgs e)
        {
            workbook = spreadsheetControl.Document;
            Worksheet worksheet_HojaTrabajo = workbook.Worksheets[0];
            int intLinea = worksheet_HojaTrabajo.SelectedCell.TopRowIndex;

            if (intLinea < 9)
            {
                MessageBox.Show("Debe posicionarse en la fila 10 o superior");
            }
            else
            {
                DialogResult intEliminaRegistro = MessageBox.Show("Desea Eliminar la Linea: " + Convert.ToString(intLinea + 1),
                                                                "Advertencia", MessageBoxButtons.YesNo,
                                                                MessageBoxIcon.Exclamation
                                                               );


                if (intEliminaRegistro == DialogResult.Yes)
                {
                    int intIdFormulacion_Detalle_Ingreso = Convert.ToInt32(worksheet_HojaTrabajo.Cells[intLinea, 28].Value.NumericValue);
                    if (intIdFormulacion_Detalle_Ingreso == 0)
                    {
                        MessageBox.Show("Esta Linea no se puede eliminar porque todavia no ha sido grabada");
                    }
                    else
                    {
                        Boolean blnResult = false;
                        string Rango = traeRangoCelda(1, intLinea + 1, 28, intLinea + 1);
                        if (MyStuff.UsaWCF == true)
                        {
                            blnResult = objWCF.Elimina_FormulacionDetalle_Ingreso(intIdFormulacion_Detalle_Ingreso);
                            if (blnResult == true)
                            {

                                worksheet_HojaTrabajo.DeleteCells(worksheet_HojaTrabajo.Range[Rango], DeleteMode.ShiftCellsUp);
                            }
                        }
                        else
                        {
                            Service.Formulacion_Detalle_Ingreso SFDP = new Service.Formulacion_Detalle_Ingreso();
                            blnResult = SFDP.Elimina_FormulacionDetalle_Ingreso(intIdFormulacion_Detalle_Ingreso);
                            if (blnResult == true)
                            {
                                worksheet_HojaTrabajo.DeleteCells(worksheet_HojaTrabajo.Range[Rango], DeleteMode.ShiftCellsUp);
                            }

                        }
                    }
                }
            }
        }

        private void Mnu_Proyecto_Click(object sender, EventArgs e)
        {

        }

        private void spreadsheetControl_RangeCopying(object sender, RangeCopyingEventArgs e)
        {
            intInicioEvento = e.Range.TopRowIndex;
            intRegistrosEvento = e.Range.RowCount;

            //MessageBox.Show(Convert.ToString(intInicioEvento) + ":" + Convert.ToString(intRegistrosEvento));

            this.Btn_Pegar.Visible = true;

        }

        private void spreadsheetControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Btn_Pegar.Visible = false;
                intInicioEvento = 0;
                intRegistrosEvento = 0;
            }

        }

        private void Btn_Pegar_Click(object sender, EventArgs e)
        {
            workbook = spreadsheetControl.Document;
            Worksheet worksheet_HojaTrabajo = workbook.Worksheets[0];
            int intLinea = worksheet_HojaTrabajo.SelectedCell.TopRowIndex;
            int intFinRegistro = (intInicioEvento + intRegistrosEvento);

            while (intInicioEvento < intFinRegistro)
            {
                worksheet_HojaTrabajo.Cells[intLinea, 1].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 1].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 2].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 2].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 3].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 3].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 4].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 4].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 5].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 5].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 6].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 6].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 7].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 7].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 8].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 8].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 9].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 9].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 10].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 10].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 11].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 11].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 12].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 12].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 13].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 13].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 14].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 14].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 15].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 15].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 16].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 16].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 17].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 17].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 18].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 18].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 19].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 19].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 20].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 20].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 21].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 21].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 22].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 22].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 23].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 23].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 24].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 24].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 25].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 25].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 26].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 26].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 27].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 27].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 28].Value = 0;
                intLinea = intLinea + 1;
                intInicioEvento = intInicioEvento + 1;
            }
            this.Btn_Pegar.Visible = false;
            intInicioEvento = 0;
            intRegistrosEvento = 0;


        }

        #region EliminarRegistros
        private List<int> ObtenerFilasMarcadas()
        {

            workbook = spreadsheetControl.Document;
            Worksheet worksheet_HojaTrabajo = workbook.Worksheets[0];
            string strRango = worksheet_HojaTrabajo.Selection.ToString().TrimEnd();



            int index1 = strRango.IndexOf("worksheet");
            if (index1 > 0)
            {
                strRango = strRango.Substring(0, index1).TrimEnd();
            }

            strRango = strRango.Replace("Range:", "");
            strRango = strRango.Replace(",", "");
            strRango = strRango.Replace(";", "");
            strRango = strRango.Replace("\"", "").TrimStart() + ":";




            int intLongitud = strRango.TrimEnd().Length;
            List<int> elementos = new List<int>();
            List<int> elementos01 = new List<int>();
            List<int> elementos02 = new List<int>();

            string strCaracter;
            string strFila = "";
            string strFilaAnterior = "";
            int i = 0;

            while (i < intLongitud)
            {
                strCaracter = strRango.Substring(i, 1).TrimEnd();
                if (strCaracter != "$" && strCaracter != ":")
                {
                    strFila = strFila + strRango.Substring(i, 1);
                }

                if ((strCaracter == "$" || strCaracter == ":") && strFila.TrimEnd().Length > 0)
                {
                    if (strFila.TrimEnd() != strFilaAnterior.TrimEnd())
                    {
                        strFilaAnterior = strFila;
                        elementos01.Add(Convert.ToInt32(strFila));
                    }
                    strFila = "";
                }

                i++;

            }

            if (strRango.Length == 6 && elementos01.Count == 2)
            {
                int inicio = elementos01[0];
                int fin = elementos01[1];

                while (inicio <= fin)
                {
                    elementos02.Add(Convert.ToInt32(inicio));
                    inicio++;
                }
            }

            if (elementos02.Count > 0)
            {
                elementos = elementos02;
            }
            else
            {
                elementos = elementos01;
            }

            return elementos;
        }


        private void EliminarFilas(List<int> elementos)
        {
            workbook = spreadsheetControl.Document;
            Worksheet worksheet_HojaTrabajo = workbook.Worksheets[0];
            int intNumeroElementos = elementos.Count;

            int intIdFormulacion_Detalle_Proyecto = 0;
            for (int i = 0; i < intNumeroElementos; i++)
            {
                intIdFormulacion_Detalle_Proyecto = Convert.ToInt32(worksheet_HojaTrabajo.Cells[elementos[i] - 1, 28].Value.NumericValue);
                if (intIdFormulacion_Detalle_Proyecto > 0)
                {
                    Boolean blnResult = false;
                    if (MyStuff.UsaWCF == true)
                    {
                        blnResult = objWCF.Elimina_FormulacionDetalle_Proyecto(intIdFormulacion_Detalle_Proyecto);
                    }
                    else
                    {
                        Service.Formulacion_Detalle_Proyecto SFDP = new Service.Formulacion_Detalle_Proyecto();
                        blnResult = SFDP.Elimina_FormulacionDetalle_Proyecto(intIdFormulacion_Detalle_Proyecto);
                    }
                }
            }
        }

        private void spreadsheetControl_RowsRemoving(object sender, RowsChangingEventArgs e)
        {
            if (blnEliminaRegistros == true)
            {
                blnEliminaRegistros = false;
                DialogResult intEliminaRegistro = MessageBox.Show("Desea Eliminar las lineas elegidas ",
                                                               "Advertencia", MessageBoxButtons.YesNo,
                                                               MessageBoxIcon.Exclamation
                                                              );


                if (intEliminaRegistro == DialogResult.Yes)
                {
                    blnCanceloEliminacionRegistros = false;
                    List<int> elementos = new List<int>();
                    elementos = this.ObtenerFilasMarcadas();
                    if (elementos.Count > 0)
                    {
                        this.EliminarFilas(elementos);
                    }
                }
                else
                {
                    blnCanceloEliminacionRegistros = true;
                }
            }

            if (blnCanceloEliminacionRegistros == true)
            {
                e.Cancel = true;
            }
        }

        private void spreadsheetControl_SelectionChanged(object sender, EventArgs e)
        {
            blnEliminaRegistros = true;
            blnCanceloEliminacionRegistros = false;
        }

        #endregion


    }
}
