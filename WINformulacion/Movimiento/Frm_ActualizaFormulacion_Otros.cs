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
    public partial class Frm_ActualizaFormulacion_Otros : Form
    {
        private SRformulacion.WCFformulacionEClient objWCF = new SRformulacion.WCFformulacionEClient();

        IWorkbook workbook;
        private DataSet DS_Formulacion;
        private DataSet DS_ClaseGasto;
        private DataSet DS_FuenteFinanciamiento;
        private DataSet DS_Proyecto;
        private DataSet DS_Componente;

        private int intInicioEvento = 0;
        private int intRegistrosEvento = 0;

        private string strAñoProceso = "";
        private string strVersion = "";
        private string strCodProyecto = "";
        private string strCodCentroCosto = "";
        private string strNomCentroCosto = "";
        private string strCodTipoFormulacion = "";
        private string strListaOrdenes = "";
        private int intNumeroOrdenes = 0;
        public DataView DV_Excel;

        private Boolean blnEliminaRegistros = true;
        private Boolean blnCanceloEliminacionRegistros = false;

        private DataView DV_Proyecto;
        private DataView DV_Componente;
        private DataView DV_FuenteFinanciamiento;


        private Framework FS = new Framework();

        public Frm_ActualizaFormulacion_Otros()
        {
            InitializeComponent();
        }
        #region Presentar datos en excel
        private void MostrarFiltro(Boolean blnSalir)
        {
            WINformulacion.Movimiento.Frm_ActualizaFormulacion_Otros_Filtro frm = new WINformulacion.Movimiento.Frm_ActualizaFormulacion_Otros_Filtro();
            frm.ShowMe();
            if (frm.blnProcesaExcel == true)
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                SplashScreenManager.Default.SetWaitFormDescription("Recopilando informaciòn...");

                //Habilita Opciones

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
                strCodTipoFormulacion = "04";
                strCodCentroCosto = frm.strCodCentroCosto;

                //-- Recuperar Datos



   
                    Service.DataGeneral SDG = new Service.DataGeneral();
                    //DS_PlanContable = SDG.Ayuda_PlanContable_Spring();
                    if (MyStuff.UsaWCF == true)
                    {
                    DS_Proyecto = objWCF.Ayuda_Proyecto_Spring("000000", strCodCentroCosto);

                    DS_ClaseGasto = objWCF.Combo_ClaseGasto_Otros("000000",
                                                                 strCodProyecto,
                                                                   MyStuff.CodigoCentroCosto
                                                                 );
                    }
                    else
                    {
                    DS_Proyecto = SDG.Ayuda_Proyecto_Spring("000000", strCodCentroCosto);

                    DS_ClaseGasto = SDG.Combo_ClaseGasto_Otros("000000",
                                                                      strCodProyecto,
                                                                        MyStuff.CodigoCentroCosto
                                                                      );
                    }

                if (MyStuff.UsaWCF == true)
                {
                    DS_Componente = objWCF.Ayuda_Proyecto_Componente_Todos_Spring("000000");
                }
                else
                {
                    DS_Componente = SDG.Ayuda_Proyecto_Componente_Todos_Spring("000000");
                }

                if (MyStuff.UsaWCF == true)
                    {
                         DS_FuenteFinanciamiento = objWCF.Combo_Proyecto_FuenteFinanciamiento_Todos("000000");
                    }
                    else
                    {
                        DS_FuenteFinanciamiento = SDG.Combo_Proyecto_FuenteFinanciamiento_Todos("000000");
                }

                    
                    Service.Formulacion_Detalle_Proyecto SFDP = new Service.Formulacion_Detalle_Proyecto();
                    if (MyStuff.UsaWCF == true)
                    {
                         DS_Formulacion = objWCF.Lista_FormulacionDetalle_Proyecto_Otros("000000", strCodCentroCosto, strCodTipoFormulacion);
                    }
                    else
                    {
                        DS_Formulacion = SFDP.Lista_FormulacionDetalle_Proyecto_Otros("000000", strCodCentroCosto, strCodTipoFormulacion);
                    }

                workbook = spreadsheetControl.Document;
                string sRutaInterna = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Excel\Formulacion_Otros.xlsx");
                //workbook.LoadDocument(@"Excel\Formulacion_Proyecto_Inversion.xlsx", DocumentFormat.Xlsx);
                workbook.LoadDocument(sRutaInterna, DocumentFormat.Xlsx);

                Worksheet worksheet_HojaTrabajo = workbook.Worksheets[0];

                worksheet_HojaTrabajo.Cells[4, 2].Value = frm.strNomCentroCosto;



                worksheet_HojaTrabajo.Cells[2, 29].Value = MFC.CañoProceso;
                worksheet_HojaTrabajo.Cells[3, 29].Value = MFC.Cversion;
                worksheet_HojaTrabajo.Cells[4, 29].Value = "Servicios Varios";

                DV_Excel = DS_Formulacion.Tables[0].DefaultView;
                worksheet_HojaTrabajo.DataBindings.BindToDataSource(DV_Excel, 9, 1);

                int intLinea = 9;
                int intFinLinea = DS_Formulacion.Tables[0].Rows.Count;
                string Rango = traeRangoCelda(1, intLinea + 1, 1, intLinea + intFinLinea );
                workbook = spreadsheetControl.Document;
                Range range = worksheet_HojaTrabajo.Range[Rango];
                Formatting rangeFormatting = range.BeginUpdateFormatting();
                rangeFormatting.Fill.BackgroundColor = Color.Green;
                range.EndUpdateFormatting(rangeFormatting);

                this.FormatoCeldas(intLinea, intFinLinea);

                //foreach (DataRow oRow1 in DS_Formulacion.Tables[0].Rows)
                //{
                //    string Rango = traeRangoCelda(1, intLinea + 1, 1, intLinea + 1);
                //    workbook = spreadsheetControl.Document;
                //    Range range = worksheet_HojaTrabajo.Range[Rango];
                //    Formatting rangeFormatting = range.BeginUpdateFormatting();
                //    rangeFormatting.Fill.BackgroundColor = Color.Green;
                //    range.EndUpdateFormatting(rangeFormatting);

                //    worksheet_HojaTrabajo.Cells[intLinea, 1].Value = Convert.ToString(oRow1["vNomTipoInserccion"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 2].Value = Convert.ToString(oRow1["vNomClaseGasto"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 3].Value = Convert.ToString(oRow1["cCodClasificador"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 4].Value = Convert.ToString(oRow1["vNomClasificador"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 5].Value = Convert.ToString(oRow1["cCodPosPre"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 6].Value = Convert.ToString(oRow1["vNomPosPre"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 7].Value = Convert.ToString(oRow1["vNomProyecto"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 8].Value = Convert.ToString(oRow1["vNomFuenteFinanciamiento"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 9].Value = Convert.ToString(oRow1["vNomComponente"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 10].Value = Convert.ToString(oRow1["Orden"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 11].Value = Convert.ToString(oRow1["tDescripcionGasto"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 12].Value = Convert.ToDouble(oRow1["fValorAnterior"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 13].Value = Convert.ToDouble(oRow1["fValorRestoActual"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 14].Value = Convert.ToDouble(oRow1["fMes_01"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 15].Value = Convert.ToDouble(oRow1["fMes_02"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 16].Value = Convert.ToDouble(oRow1["fMes_03"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 17].Value = Convert.ToDouble(oRow1["fMes_04"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 18].Value = Convert.ToDouble(oRow1["fMes_05"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 19].Value = Convert.ToDouble(oRow1["fMes_06"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 20].Value = Convert.ToDouble(oRow1["fMes_07"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 21].Value = Convert.ToDouble(oRow1["fMes_08"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 22].Value = Convert.ToDouble(oRow1["fMes_09"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 23].Value = Convert.ToDouble(oRow1["fMes_10"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 24].Value = Convert.ToDouble(oRow1["fMes_11"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 25].Value = Convert.ToDouble(oRow1["fMes_12"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 26].Value = Convert.ToDouble(oRow1["fValorFormulacion"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 27].Value = Convert.ToDouble(oRow1["fValorFormulacionUno"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 28].Value = Convert.ToDouble(oRow1["fValorFormulacionDos"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 29].Value = Convert.ToDouble(oRow1["Distribucion"]);
                //    worksheet_HojaTrabajo.Cells[intLinea, 30].Value = Convert.ToInt32(oRow1["iidFormulacion_Detalle_Proyecto"]);

                //    //worksheet_HojaTrabajo.Cells[intLinea, 1000].Value = Convert.ToString(oRow1["vNomFuenteFinanciamiento"]);

                //this.FormatoCeldas(intLinea);
                //intLinea = intLinea + 1;
                //    //}
                //}

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
            //DataValidation validation_worksheet_Importe =
            //                    worksheet_HojaTrabajo.DataValidations.Add(worksheet_HojaTrabajo["K10:K500"],
            //                                                                DataValidationType.Custom, "=AND(ISNUMBER(K10))"
            //                                                             );

            DataValidation validation_worksheet_Importe =
                    worksheet_HojaTrabajo.DataValidations.Add(worksheet_HojaTrabajo["M10:AD2000"],
                                                                DataValidationType.Custom, "=AND( M10 >= 0, ISNUMBER(M10))"
                                                             );
            validation_worksheet_Importe.ErrorTitle = "Advertencia";
            validation_worksheet_Importe.ErrorMessage = "El Dato no es correcto";
            validation_worksheet_Importe.ShowErrorMessage = true;


        }

        private void ValidarColumnas()
        {
            Worksheet worksheet_HojaTrabajo = workbook.Worksheets[0];
            DataValidation validation_worksheet_Importe =
                    worksheet_HojaTrabajo.DataValidations.Add(worksheet_HojaTrabajo["M10:AD2000"],
                                                                DataValidationType.Custom, "=AND( M10 >= 0, ISNUMBER(M10))"
                                                             );

            validation_worksheet_Importe.ErrorTitle = "Advertencia";
            validation_worksheet_Importe.ErrorMessage = "El Dato no es correcto";
            validation_worksheet_Importe.ShowErrorMessage = true;


            //- Proyecto
            Worksheet worksheet_Proyecto = workbook.Worksheets[3];
            worksheet_Proyecto.Visible = false;
            DV_Proyecto = DS_Proyecto.Tables[0].DefaultView;
            worksheet_Proyecto.DataBindings.BindToDataSource(DV_Proyecto, 1, 0);

            //- Componente
            Worksheet worksheet_Componente = workbook.Worksheets[4];
            //worksheet_Componente.Visible = false;
            DV_Componente = DS_Componente.Tables[0].DefaultView;
            worksheet_Componente.DataBindings.BindToDataSource(DV_Componente, 1, 0);

            //-- Fuente de Financiamiento

            Worksheet worksheet_FuenteFinanciamiento = workbook.Worksheets[2];
            worksheet_FuenteFinanciamiento.Visible = false;
            DV_FuenteFinanciamiento = DS_FuenteFinanciamiento.Tables[0].DefaultView;
            worksheet_FuenteFinanciamiento.DataBindings.BindToDataSource(DV_FuenteFinanciamiento, 1, 0);

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

                if (string.IsNullOrEmpty(Convert.ToString(worksheet_HojaTrabajo.Cells[intLinea, 1].Value.TextValue)))
                    break;

                if (Convert.ToString(worksheet_HojaTrabajo.Cells[intLinea, 1].Value.TextValue).TrimEnd() == "Año Actual")
                    break;

                if (!string.IsNullOrEmpty(Convert.ToString(worksheet_HojaTrabajo.Cells[intLinea, 10].Value.TextValue)))
                {
                    strOrdenes = strOrdenes + 
                                 Convert.ToString(worksheet_HojaTrabajo.Cells[intLinea, 10].Value.TextValue).TrimEnd() + "/";
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

        private string traeRangoCelda_Proyecto(int y1, int x1, int y2, int x2)
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
            if (y2 > 25)
            {
                y2 = y2 - 25;
                letra = "A";
            }

            columna2 = Convert.ToChar(64 + y2);

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


        private Boolean ValidaLineaGrabacion(Model.Formulacion_Detalle_Proyecto MFDP, int Linea)
        {
            Boolean blnFilaErrada = false;
            workbook = spreadsheetControl.Document;
            Worksheet worksheet_HojaTrabajo = workbook.Worksheets[0];

            if (string.IsNullOrEmpty(Convert.ToString(worksheet_HojaTrabajo.Cells[Linea, 10].Value.TextValue)))
            {
                if (MFDP.FvalorFormulacion == 0)
                {
                    pintarError(Linea, "AA", true);
                    blnFilaErrada = true;
                }
                else
                {
                    pintarError(Linea, "AA", false);
                }
            }
            else
            {
                pintarError(Linea, "AA", false);
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

            if (string.IsNullOrEmpty(Convert.ToString(worksheet_HojaTrabajo.Cells[Linea, 4].Value.TextValue)))
            {
                pintarError(Linea, "E", true);
                blnFilaErrada = true;
            }
            else
            {
                pintarError(Linea, "E", false);
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

            if (string.IsNullOrEmpty(Convert.ToString(worksheet_HojaTrabajo.Cells[Linea, 6].Value.TextValue)))
            {
                pintarError(Linea, "G", true);
                blnFilaErrada = true;
            }
            else
            {
                pintarError(Linea, "G", false);
            }

            if (string.IsNullOrEmpty(Convert.ToString(worksheet_HojaTrabajo.Cells[Linea, 7].Value.TextValue)))
            {
                pintarError(Linea, "H", true);
                blnFilaErrada = true;
            }
            else
            {
                pintarError(Linea, "H", false);
            }

            if (string.IsNullOrEmpty(Convert.ToString(worksheet_HojaTrabajo.Cells[Linea, 8].Value.TextValue)))
            {
                pintarError(Linea, "I", true);
                blnFilaErrada = true;
            }
            else
            {
                pintarError(Linea, "I", false);
            }

            if (string.IsNullOrEmpty(Convert.ToString(worksheet_HojaTrabajo.Cells[Linea, 8].Value.TextValue)))
            {
                pintarError(Linea, "I", true);
                blnFilaErrada = true;
            }
            else
            {
                pintarError(Linea, "I", false);
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

            if (string.IsNullOrEmpty(Convert.ToString(worksheet_HojaTrabajo.Cells[Linea, 11].Value.TextValue)))
            {
                pintarError(Linea, "L", true);
                blnFilaErrada = true;
            }
            else
            {
                pintarError(Linea, "L", false);
            }

            if (!string.IsNullOrEmpty(Convert.ToString(worksheet_HojaTrabajo.Cells[Linea, 10].Value.TextValue)))
            {
                if (Math.Round(Convert.ToDouble(worksheet_HojaTrabajo.Cells[Linea, 29].Value.NumericValue), 2) != 0)
                {
                    pintarError(Linea, "AD", true);
                    blnFilaErrada = true;
                }
                else
                {
                    pintarError(Linea, "AD", false);
                }
            }
            else
            {
                pintarError(Linea, "AD", false);
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



        private void FormatoCeldas(int intLinea, int intFinLinea )
        {
                //string Rango = traeRangoCelda(15, intLinea + 1, 25, intLinea + 1);
            workbook = spreadsheetControl.Document;

            Worksheet worksheet_HojaTrabajo = workbook.Worksheets[0];


            //worksheet_HojaTrabajo.Cells[intLinea, 12].NumberFormat = "#,##0.00";
            //worksheet_HojaTrabajo.Cells[intLinea, 13].NumberFormat = "#,##0.00";
            //worksheet_HojaTrabajo.Cells[intLinea, 14].NumberFormat = "#,##0.00";
            //worksheet_HojaTrabajo.Cells[intLinea, 15].NumberFormat = "#,##0.00";
            //worksheet_HojaTrabajo.Cells[intLinea, 16].NumberFormat = "#,##0.00";
            //worksheet_HojaTrabajo.Cells[intLinea, 17].NumberFormat = "#,##0.00";
            //worksheet_HojaTrabajo.Cells[intLinea, 18].NumberFormat = "#,##0.00";
            //worksheet_HojaTrabajo.Cells[intLinea, 19].NumberFormat = "#,##0.00";
            //worksheet_HojaTrabajo.Cells[intLinea, 20].NumberFormat = "#,##0.00";
            //worksheet_HojaTrabajo.Cells[intLinea, 21].NumberFormat = "#,##0.00";
            //worksheet_HojaTrabajo.Cells[intLinea, 22].NumberFormat = "#,##0.00";
            //worksheet_HojaTrabajo.Cells[intLinea, 23].NumberFormat = "#,##0.00";
            //worksheet_HojaTrabajo.Cells[intLinea, 24].NumberFormat = "#,##0.00";
            //worksheet_HojaTrabajo.Cells[intLinea, 25].NumberFormat = "#,##0.00";
            //worksheet_HojaTrabajo.Cells[intLinea, 26].NumberFormat = "#,##0.00";
            //worksheet_HojaTrabajo.Cells[intLinea, 27].NumberFormat = "#,##0.00";
            //worksheet_HojaTrabajo.Cells[intLinea, 28].NumberFormat = "#,##0.00";
            //worksheet_HojaTrabajo.Cells[intLinea, 29].NumberFormat = "#,##0.00";

            string strLinea = Convert.ToString(intLinea + 1).TrimEnd();
            string strFinLinea = Convert.ToString(intFinLinea + 1).TrimEnd();
            string strMeses = "O" + strLinea + ":" + "Z" + strFinLinea;
            //worksheet_HojaTrabajo.Cells[strMeses].NumberFormat = "#,##0.00";
            worksheet_HojaTrabajo[strMeses].NumberFormat = "#,##0.00";
            //o a z

            string strSuma_2020 = "=SUM(" + "O" + strLinea + ":Z" + strFinLinea + ")";
            string strPorDistribuir = "=" + "SI(M" + strLinea + "=0;0;" + "M" + strLinea + "-(N" + strLinea + "+AA" + strLinea + "+AB" + strLinea + "+AC" + strFinLinea + "))";

            //SI(K10 = 0; 0; K10 - (L10 + Y10 + Z10 + AA10) )

            worksheet_HojaTrabajo.Cells[intLinea, 26].Formula = strSuma_2020;
            worksheet_HojaTrabajo.Cells[intLinea, 29].Formula = strPorDistribuir;


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

                
                {
                    {
                        string strNomClaseGasto = Convert.ToString(worksheet_HojaTrabajo.Cells[intLinea, 2].Value.TextValue); ;
                        if (string.IsNullOrEmpty(strNomClaseGasto))
                        {
                            strNomClaseGasto = "";
                        }
                        string strCodClaseGasto = FS.TraerDescripcion_DataTable(DS_ClaseGasto.Tables[0],
                                                                                                               1,
                                                                                                               0,
                                                                                                               strNomClaseGasto
                                                                                                             );

                        WINformulacion.Frm_Clasificacion_Otro frm = new WINformulacion.Frm_Clasificacion_Otro();
                        frm.Showme("000000", intLinea + 1, strCodClaseGasto, strCodCentroCosto);
                        if (frm.blnEligio == true)
                        {
                            worksheet_HojaTrabajo.Cells[intLinea, 2].Value = frm.strNomClaseGasto;
                            worksheet_HojaTrabajo.Cells[intLinea, 3].Value = frm.strCodClasificacion;
                            worksheet_HojaTrabajo.Cells[intLinea, 4].Value = frm.strNomClasificacion;
                            worksheet_HojaTrabajo.Cells[intLinea, 5].Value = frm.strCodCuentaContable;
                            worksheet_HojaTrabajo.Cells[intLinea, 6].Value = frm.strNomCuentaContable;
                            worksheet_HojaTrabajo.Cells[intLinea, 12].Value = 0;
                            worksheet_HojaTrabajo.Cells[intLinea, 13].Value = 0;
                            this.FormatoCeldas(intLinea, intLinea);
                        }

                    }

                }
            }
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            //-- Boton Guardar Documento

            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            SplashScreenManager.Default.SetWaitFormDescription("Grabando información...");

            Model.Formulacion_Detalle_Proyecto MFDP = new Model.Formulacion_Detalle_Proyecto();
            Service.Formulacion_Detalle_Proyecto SFDP = new Service.Formulacion_Detalle_Proyecto();

            workbook = spreadsheetControl.Document;
            Worksheet worksheet_HojaTrabajo = workbook.Worksheets[0];

            int _Rows = 9;
            int intIdFormulacion_Detalle_Proyecto = 0;
            int intLongitudOrden = 0;

            while (true)
            {

                if (string.IsNullOrEmpty(Convert.ToString(worksheet_HojaTrabajo.Cells[_Rows, 3].Value.TextValue)))
                    break;





                MFDP.IidFormulacion_Detalle_Proyecto = Convert.ToInt32(worksheet_HojaTrabajo.Cells[_Rows, 30].Value.NumericValue);
                MFDP.CañoProceso = strAñoProceso;
                MFDP.Cversion = strVersion;
                MFDP.CcodCeCo = strCodCentroCosto;
                MFDP.CcodCeCo_Gestor = strCodCentroCosto;
                MFDP.CcodPosPre = Convert.ToString(worksheet_HojaTrabajo.Cells[_Rows, 5].Value.TextValue);
                //MFDP.CcodComponente = Convert.ToString(worksheet_HojaTrabajo.Cells[_Rows, 9].Value.TextValue);
                MFDP.CcodComponente = FS.TraerDescripcion_DataTable(DS_Componente.Tables[0],
                                                                                                       1,
                                                                                                       0,
                                                                                                       Convert.ToString(worksheet_HojaTrabajo.Cells[_Rows, 9].Value.TextValue)
                                                                                                     );
                if (string.IsNullOrEmpty(Convert.ToString(worksheet_HojaTrabajo.Cells[_Rows, 10].Value.TextValue)))
                {
                    MFDP.CTipoOrden = "";
                    MFDP.CNumeroOrden = "";
                }
                else
                {
                    intLongitudOrden = Convert.ToString(worksheet_HojaTrabajo.Cells[_Rows, 10].Value.TextValue).TrimEnd().Length;
                    MFDP.CTipoOrden = Convert.ToString(worksheet_HojaTrabajo.Cells[_Rows, 10].Value.TextValue).Substring(0, 2);
                    MFDP.CNumeroOrden = Convert.ToString(worksheet_HojaTrabajo.Cells[_Rows, 10].Value.TextValue).Substring(3, intLongitudOrden - 3);
                    //SO-2018-0187
                }


                MFDP.CcodFuenteFinanciamiento = FS.TraerDescripcion_DataTable(DS_FuenteFinanciamiento.Tables[0],
                                                                                                       1,
                                                                                                       0,
                                                                                                       Convert.ToString(worksheet_HojaTrabajo.Cells[_Rows, 8].Value.TextValue)
                                                                                                     );
                MFDP.CcodTipoFormulacion = strCodTipoFormulacion;

                //MFDP.CcodProyecto = strCodProyecto;
                MFDP.CcodProyecto = FS.TraerDescripcion_DataTable(DS_Proyecto.Tables[0],
                                                                                                       1,
                                                                                                       0,
                                                                                                       Convert.ToString(worksheet_HojaTrabajo.Cells[_Rows, 7].Value.TextValue)
                                                                                                     );



                MFDP.CcodClaseGasto = FS.TraerDescripcion_DataTable(DS_ClaseGasto.Tables[0],
                                                                                                       1,
                                                                                                       0,
                                                                                                       Convert.ToString(worksheet_HojaTrabajo.Cells[_Rows, 2].Value.TextValue)
                                                                                                     );
                MFDP.TdescripcionGasto = Convert.ToString(worksheet_HojaTrabajo.Cells[_Rows, 11].Value.TextValue);
                MFDP.FvalorAnterior = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 12].Value.NumericValue);
                MFDP.FvalorRestoActual = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 13].Value.NumericValue);
                MFDP.FvalorFormulacion = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 26].Value.NumericValue);
                MFDP.FvalorFormulacionUno = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 27].Value.NumericValue);
                MFDP.FvalorFormulacionDos = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 28].Value.NumericValue);

                if (Convert.ToString(worksheet_HojaTrabajo.Cells[_Rows, 1].Value.TextValue) == "Año Anterior")
                {
                    MFDP.IcodTipoInserccion = 2; // 2 Automatico 
                }
                else
                {
                    MFDP.IcodTipoInserccion = 1; //- 1 Manual
                }
                MFDP.Cusuario = MyStuff.CodigoEmpleado;

                MFDP.Fmes_01 = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 14].Value.NumericValue);
                MFDP.Fmes_02 = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 15].Value.NumericValue);
                MFDP.Fmes_03 = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 16].Value.NumericValue);
                MFDP.Fmes_04 = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 17].Value.NumericValue);
                MFDP.Fmes_05 = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 18].Value.NumericValue);
                MFDP.Fmes_06 = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 19].Value.NumericValue);
                MFDP.Fmes_07 = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 20].Value.NumericValue);
                MFDP.Fmes_08 = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 21].Value.NumericValue);
                MFDP.Fmes_09 = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 22].Value.NumericValue);
                MFDP.Fmes_10 = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 23].Value.NumericValue);
                MFDP.Fmes_11 = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 24].Value.NumericValue);
                MFDP.Fmes_12 = Convert.ToDouble(worksheet_HojaTrabajo.Cells[_Rows, 25].Value.NumericValue);

                if (ValidaLineaGrabacion(MFDP, _Rows) == false)
                {
                    if (MFDP.IidFormulacion_Detalle_Proyecto == 0)
                    {

                        try
                        {
                            if (MyStuff.UsaWCF == true)
                            {
                                intIdFormulacion_Detalle_Proyecto = objWCF.Graba_FormulacionDetalle_Proyecto(MFDP);
                            }
                            else
                            {
                                intIdFormulacion_Detalle_Proyecto = SFDP.Graba_FormulacionDetalle_Proyecto(MFDP);
                            }
                        }
                        catch
                        {
                            intIdFormulacion_Detalle_Proyecto = 0;
                        }

                        if (intIdFormulacion_Detalle_Proyecto != 0)
                        {
                            string Rango = traeRangoCelda(1, _Rows + 1, 1, _Rows + 1);
                            workbook = spreadsheetControl.Document;
                            Range range = worksheet_HojaTrabajo.Range[Rango];
                            Formatting rangeFormatting = range.BeginUpdateFormatting();
                            rangeFormatting.Fill.BackgroundColor = Color.Green;
                            range.EndUpdateFormatting(rangeFormatting);
                        }
                        

                        worksheet_HojaTrabajo.Cells[_Rows, 30].Value = intIdFormulacion_Detalle_Proyecto;
                    }
                    else
                    {
                        if (MyStuff.UsaWCF == true)
                        {
                             intIdFormulacion_Detalle_Proyecto = objWCF.Modifica_FormulacionDetalle_Proyecto(MFDP);
                        }
                        else
                        {
                            intIdFormulacion_Detalle_Proyecto = SFDP.Modifica_FormulacionDetalle_Proyecto(MFDP);
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
                    WINformulacion.Frm_ActualizaDistribucion frm = new WINformulacion.Frm_ActualizaDistribucion();
                    frm.ShowMe(intLinea,
                                Convert.ToDouble(worksheet_HojaTrabajo.Cells[intLinea, 12].Value.NumericValue),
                                Convert.ToDouble(worksheet_HojaTrabajo.Cells[intLinea, 13].Value.NumericValue),
                                Convert.ToDouble(worksheet_HojaTrabajo.Cells[intLinea, 26].Value.NumericValue),
                                Convert.ToDouble(worksheet_HojaTrabajo.Cells[intLinea, 27].Value.NumericValue),
                                Convert.ToDouble(worksheet_HojaTrabajo.Cells[intLinea, 28].Value.NumericValue),
                                worksheet_HojaTrabajo.Cells[intLinea, 14].Value.NumericValue,
                                worksheet_HojaTrabajo.Cells[intLinea, 15].Value.NumericValue,
                                worksheet_HojaTrabajo.Cells[intLinea, 16].Value.NumericValue,
                                worksheet_HojaTrabajo.Cells[intLinea, 17].Value.NumericValue,
                                worksheet_HojaTrabajo.Cells[intLinea, 18].Value.NumericValue,
                                worksheet_HojaTrabajo.Cells[intLinea, 19].Value.NumericValue,
                                worksheet_HojaTrabajo.Cells[intLinea, 20].Value.NumericValue,
                                worksheet_HojaTrabajo.Cells[intLinea, 21].Value.NumericValue,
                                worksheet_HojaTrabajo.Cells[intLinea, 22].Value.NumericValue,
                                worksheet_HojaTrabajo.Cells[intLinea, 23].Value.NumericValue,
                                worksheet_HojaTrabajo.Cells[intLinea, 24].Value.NumericValue,
                                worksheet_HojaTrabajo.Cells[intLinea, 25].Value.NumericValue
                             );
                    frm.ShowDialog();

                    if (frm.blnDistribuyo == true)
                    {
                        worksheet_HojaTrabajo.Cells[intLinea, 12].Value = frm.dblSaldoAnteior;
                        worksheet_HojaTrabajo.Cells[intLinea, 13].Value = frm.dblImporte_2019;
                        worksheet_HojaTrabajo.Cells[intLinea, 26].Value = frm.dblImporte_2020;
                        worksheet_HojaTrabajo.Cells[intLinea, 27].Value = frm.dblImporte_2021;
                        worksheet_HojaTrabajo.Cells[intLinea, 28].Value = frm.dblImporte_2022;
                        worksheet_HojaTrabajo.Cells[intLinea, 14].Value = frm.dblEnero;
                        worksheet_HojaTrabajo.Cells[intLinea, 15].Value = frm.dblFebrero;
                        worksheet_HojaTrabajo.Cells[intLinea, 16].Value = frm.dblMarzo;
                        worksheet_HojaTrabajo.Cells[intLinea, 17].Value = frm.dblAbril;
                        worksheet_HojaTrabajo.Cells[intLinea, 18].Value = frm.dblMayo;
                        worksheet_HojaTrabajo.Cells[intLinea, 19].Value = frm.dblJunio;
                        worksheet_HojaTrabajo.Cells[intLinea, 20].Value = frm.dblJulio;
                        worksheet_HojaTrabajo.Cells[intLinea, 21].Value = frm.dblAgosto;
                        worksheet_HojaTrabajo.Cells[intLinea, 22].Value = frm.dblSetiembre;
                        worksheet_HojaTrabajo.Cells[intLinea, 23].Value = frm.dblOctubre;
                        worksheet_HojaTrabajo.Cells[intLinea, 24].Value = frm.dblNoviembre;
                        worksheet_HojaTrabajo.Cells[intLinea, 25].Value = frm.dblDiciembre;
                        worksheet_HojaTrabajo.Cells[intLinea, 26].Value = frm.dblTotalDistribucion;
                        this.FormatoCeldas(intLinea, intLinea);
                    }
            }
        }

        private void Btn_MostarOrdenesPendientes_Click(object sender, EventArgs e)
        {
            workbook = spreadsheetControl.Document;
            Worksheet worksheet_HojaTrabajo = workbook.Worksheets[0];
            int intLinea1 = worksheet_HojaTrabajo.SelectedCell.TopRowIndex;

            
            {
                
                strListaOrdenes = this.juntaOrdenes();
                WINformulacion.Frm_ActualizaFormulacion_Proyecto_Inversion_AñoAnterior_Clasificdor frm = new WINformulacion.Frm_ActualizaFormulacion_Proyecto_Inversion_AñoAnterior_Clasificdor();
                frm.ShowMe("000000", strCodCentroCosto,
                                     strListaOrdenes
                                     );  //jesus


                if (frm.blnEligio == true)
                {

                    SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                    SplashScreenManager.Default.SetWaitFormDescription("Procesando información Año Anterior...");

                    string strTipoOrden = "";
                    string strNumeroOrden = "";
                    string strCodClasificador = frm.strCodClasificador;

                    int intLinea = 9;

                    DataSet DS = new DataSet();
                    Service.DataGeneral SDG = new Service.DataGeneral();
                    worksheet_HojaTrabajo.Rows.Insert(9 + (intNumeroOrdenes), (frm.intNumeroOrdenes));
                    
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
                                    DS = objWCF.Lista_Proyecto_IncorporaSaldoAñoAnterior_OS_Clasificador("000000",
                                                                                     strCodClasificador,
                                                                                     strCodCentroCosto,
                                                                                     strNumeroOrden
                                                                                   );
                                }
                                else
                                {
                                    DS = SDG.Lista_Proyecto_IncorporaSaldoAñoAnterior_OS_Clasificador("000000",
                                                                                     strCodClasificador,
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
                                    DS = objWCF.Lista_Proyecto_IncorporaSaldoAñoAnterior_OC_Clasificador("000000",
                                                                                     strCodClasificador,
                                                                                     strCodCentroCosto,
                                                                                     strNumeroOrden
                                                                                   );
                                }
                                else
                                {
                                    DS = SDG.Lista_Proyecto_IncorporaSaldoAñoAnterior_OC_Clasificador("000000",
                                                                                     strCodClasificador,
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
                                worksheet_HojaTrabajo.Cells[intLinea, 10].Value = strTipoOrden.TrimEnd() + "-" + strNumeroOrden;
                                worksheet_HojaTrabajo.Cells[intLinea, 11].Value = Convert.ToString(oRow1["ObjetoContratacion"]);
                                worksheet_HojaTrabajo.Cells[intLinea, 12].Value = Convert.ToDouble(oRow1["Saldo"]);
                                worksheet_HojaTrabajo.Cells[intLinea, 30].Value = 0;
                                worksheet_HojaTrabajo.Cells[intLinea, 1].Value = "Año Anterior";
                                worksheet_HojaTrabajo["AB10:AC205"].NumberFormat = "[Black]#,##0.00;";
                                this.FormatoCeldas(intLinea, intLinea);
                                intLinea = intLinea + 1;
                                //}
                            }
                        }
                    }
                    this.ValidarColumnas_Orden();
                    SplashScreenManager.CloseForm();
                }
            }
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
                    int intIdFormulacion_Detalle_Proyecto = Convert.ToInt32(worksheet_HojaTrabajo.Cells[intLinea, 30].Value.NumericValue);
                    if (intIdFormulacion_Detalle_Proyecto == 0)
                    {
                        MessageBox.Show("Esta Linea no se puede eliminar porque todavia no ha sido grabada");
                    }
                    else
                    {
                        Boolean blnResult = false;
                        string Rango = traeRangoCelda(1, intLinea + 1, 28, intLinea + 1);
                        if (MyStuff.UsaWCF == true)
                        {
                            blnResult = objWCF.Elimina_FormulacionDetalle_Proyecto(intIdFormulacion_Detalle_Proyecto);
                            if (blnResult == true)
                            {
                                
                                worksheet_HojaTrabajo.DeleteCells(worksheet_HojaTrabajo.Range[Rango], DeleteMode.ShiftCellsUp);
                            }
                        }
                        else
                        {
                            Service.Formulacion_Detalle_Proyecto SFDP = new Service.Formulacion_Detalle_Proyecto();
                            blnResult = SFDP.Elimina_FormulacionDetalle_Proyecto(intIdFormulacion_Detalle_Proyecto);
                            if (blnResult == true)
                            {
                                worksheet_HojaTrabajo.DeleteCells(worksheet_HojaTrabajo.Range[Rango], DeleteMode.ShiftCellsUp);
                            }

                        }
                    }
                }
            }
        }

        //private void Btn_Proyecto_Click(object sender, EventArgs e)
        //{
        //    workbook = spreadsheetControl.Document;
        //    Worksheet worksheet_HojaTrabajo = workbook.Worksheets[0];
        //    int intLinea = worksheet_HojaTrabajo.SelectedCell.TopRowIndex;

        //    if (intLinea < 9)
        //    {
        //        MessageBox.Show("Debe posicionarse en la fila 10 o superior");
        //    }
        //    else
        //    {
             

        //        WINformulacion.Frm_ActualizaFormulacion_Proyecto_Inversion_FF frm = new WINformulacion.Frm_ActualizaFormulacion_Proyecto_Inversion_FF();
        //        frm.ShowMe("000000", strCodCentroCosto, strNomCentroCosto , intLinea + 1);
        //        if (frm.blnEligio == true)
        //        {
        //            worksheet_HojaTrabajo.Cells[intLinea, 2].Value = frm.strNomProyecto;
        //            worksheet_HojaTrabajo.Cells[intLinea, 8].Value = frm.strNomFuenteFinanciamiento;
        //        }

        //    }
        //}

        private void AyudadeCelda( int intRowIndex, int intColumnIndex )
        {
            if (intRowIndex >= 9)
            {
                workbook = spreadsheetControl.Document;
                Worksheet worksheet_HojaTrabajo = workbook.Worksheets[0];

                switch (intColumnIndex)
                {
                    case 7:

                        //if (!string.IsNullOrEmpty(Convert.ToString(worksheet_HojaTrabajo.Cells[intRowIndex, intColumnIndex].Value.TextValue)))
                        {
                            //if (Convert.ToString(worksheet_HojaTrabajo.Cells[intRowIndex, intColumnIndex].Value.TextValue).TrimEnd() == "*")
                            {
                                WINformulacion.Frm_AyudaGeneral frm = new WINformulacion.Frm_AyudaGeneral();
                                frm.ShowMe(DS_Proyecto,
                                           "",
                                           "",
                                           1,
                                           0,
                                           "70,500",
                                           "Seleccione un Proyecto",
                                           intRowIndex + 1
                                          );
                                if (frm.blnEligio == true)
                                {
                                    worksheet_HojaTrabajo.Cells[intRowIndex, intColumnIndex].Value = frm.strValorDevueltoTexto;
                                }
                                //else
                                //{
                                //    worksheet_HojaTrabajo.Cells[intRowIndex, intColumnIndex].Value = "";
                                //}
                            }
                        }
                        break;
                    case 8:

                        if (!string.IsNullOrEmpty(Convert.ToString(worksheet_HojaTrabajo.Cells[intRowIndex, 7].Value.TextValue)))
                        {
                            //if (!string.IsNullOrEmpty(Convert.ToString(worksheet_HojaTrabajo.Cells[intRowIndex, intColumnIndex].Value.TextValue)))
                            {
                                //if (Convert.ToString(worksheet_HojaTrabajo.Cells[intRowIndex, intColumnIndex].Value.TextValue).TrimEnd() == "*")
                                {
                                    string strCodProyecto = FS.TraerDescripcion_DataTable(DS_Proyecto.Tables[0],
                                                                                                           1,
                                                                                                           0,
                                                                                                           Convert.ToString(worksheet_HojaTrabajo.Cells[intRowIndex, 7].Value.TextValue)
                                                                                                         );

                                    WINformulacion.Frm_AyudaGeneral frm = new WINformulacion.Frm_AyudaGeneral();
                                    frm.ShowMe(DS_FuenteFinanciamiento,
                                               "cCodProyecto",
                                               strCodProyecto,
                                               1,
                                               0,
                                               "70,500",
                                               "Seleccione una Fuente de Financiamiento",
                                               intRowIndex + 1
                                              );
                                    if (frm.blnEligio == true)
                                    {
                                        worksheet_HojaTrabajo.Cells[intRowIndex, intColumnIndex].Value = frm.strValorDevueltoTexto;
                                    }
                                    //else
                                    //{
                                    //    worksheet_HojaTrabajo.Cells[intRowIndex, intColumnIndex].Value = "";
                                    //}
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Debe Elegir un Proyecto para visualizar sus fuentes de Financiamiento");
                        }
                        break;
                    case 9:

                        if (!string.IsNullOrEmpty(Convert.ToString(worksheet_HojaTrabajo.Cells[intRowIndex, 7].Value.TextValue)))
                        {
                            //if (!string.IsNullOrEmpty(Convert.ToString(worksheet_HojaTrabajo.Cells[intRowIndex, intColumnIndex].Value.TextValue)))
                            {
                                //if (Convert.ToString(worksheet_HojaTrabajo.Cells[intRowIndex, intColumnIndex].Value.TextValue).TrimEnd() == "*")
                                {
                                    string strCodProyecto = FS.TraerDescripcion_DataTable(DS_Proyecto.Tables[0],
                                                                                                           1,
                                                                                                           0,
                                                                                                           Convert.ToString(worksheet_HojaTrabajo.Cells[intRowIndex, 7].Value.TextValue)
                                                                                                         );

                                    WINformulacion.Frm_AyudaGeneral frm = new WINformulacion.Frm_AyudaGeneral();
                                    frm.ShowMe(DS_Componente,
                                               "cCodProyecto",
                                               strCodProyecto,
                                               1,
                                               0,
                                               "70,500",
                                               "Seleccione un Componente",
                                               intRowIndex + 1
                                              );
                                    if (frm.blnEligio == true)
                                    {
                                        worksheet_HojaTrabajo.Cells[intRowIndex, intColumnIndex].Value = frm.strValorDevueltoTexto;
                                    }
                                    //else
                                    //{
                                    //    worksheet_HojaTrabajo.Cells[intRowIndex, intColumnIndex].Value = "";
                                    //}
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Debe Elegir un Proyecto para visualizar sus Componentes");
                        }
                        break;
                }
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
                worksheet_HojaTrabajo.Cells[intLinea, 28].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 28].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 29].Value = worksheet_HojaTrabajo.Cells[intInicioEvento, 29].Value;
                worksheet_HojaTrabajo.Cells[intLinea, 30].Value = 0;
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
                intIdFormulacion_Detalle_Proyecto = Convert.ToInt32(worksheet_HojaTrabajo.Cells[elementos[i] - 1, 30].Value.NumericValue);
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



        #endregion

        private void spreadsheetControl_CellBeginEdit(object sender, DevExpress.XtraSpreadsheet.SpreadsheetCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 9)
                e.Cancel = true;

            if (e.ColumnIndex == 1 && e.RowIndex >= 9)
                e.Cancel = true;

            if (e.ColumnIndex == 3 && e.RowIndex >= 9)
                e.Cancel = true;

            if (e.ColumnIndex == 4 && e.RowIndex >= 9)
                e.Cancel = true;

            if (e.ColumnIndex == 5 && e.RowIndex >= 9)
                e.Cancel = true;

            if (e.ColumnIndex == 6 && e.RowIndex >= 9)
                e.Cancel = true;
            if (e.ColumnIndex == 7 && e.RowIndex >= 9)
                e.Cancel = true;


            if (e.ColumnIndex == 10 && e.RowIndex >= 9)
                e.Cancel = true;

            if (e.ColumnIndex == 12 && e.RowIndex >= 9)
                e.Cancel = true;

            if (e.ColumnIndex == 26 && e.RowIndex >= 9)
                e.Cancel = true;

            if (e.ColumnIndex == 29 && e.RowIndex >= 9)
                e.Cancel = true;
        }

        private void spreadsheetControl_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Btn_Pegar.Visible = false;
                    intInicioEvento = 0;
                    intRegistrosEvento = 0;
                    break;
                case Keys.F11:
                    workbook = spreadsheetControl.Document;
                    Worksheet worksheet_HojaTrabajo = workbook.Worksheets[0];
                    int intLinea = worksheet_HojaTrabajo.SelectedCell.TopRowIndex;
                    int intColumna = worksheet_HojaTrabajo.SelectedCell.LeftColumnIndex;
                    this.AyudadeCelda(intLinea, intColumna);
                    break;
            }

        }

        private void spreadsheetControl_RangeCopying(object sender, RangeCopyingEventArgs e)
        {
            intInicioEvento = e.Range.TopRowIndex;
            intRegistrosEvento = e.Range.RowCount;

            //MessageBox.Show(Convert.ToString(intInicioEvento) + ":" + Convert.ToString(intRegistrosEvento));

            this.Btn_Pegar.Visible = true;

        }

        private void spreadsheetControl_SelectionChanged(object sender, EventArgs e)
        {
            blnEliminaRegistros = true;
            blnCanceloEliminacionRegistros = false;
            

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
    }
}
