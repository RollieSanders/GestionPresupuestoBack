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

namespace WINformulacion
{
    public partial class Frm_ActualizaDistribucion_Meses : DevExpress.XtraEditors.XtraForm
    {
        private double dblImporte_2020 = 0.0;
        public string strNomMetodoDistribucion = "";
        public double dblEnero = 0.0;
        public double dblFebrero = 0.0;
        public double dblMarzo = 0.0;
        public double dblAbril = 0.0;
        public double dblMayo = 0.0;
        public double dblJunio = 0.0;
        public double dblJulio = 0.0;
        public double dblAgosto = 0.0;
        public double dblSetiembre = 0.0;
        public double dblOctubre = 0.0;
        public double dblNoviembre = 0.0;
        public double dblDiciembre = 0.0;
        public double dblTotalDistribucion = 0.0;
        public Boolean blnDistribuyo = false;

        private SRformulacion.WCFformulacionEClient objWCF = new SRformulacion.WCFformulacionEClient();

        public Frm_ActualizaDistribucion_Meses()
        {
            InitializeComponent();
        }

        public void ShowMe( double dImporte_2020,
                            double dblEnero,
                            double dblFebrero,
                            double dblMarzo,
                            double dblAbril,
                            double dblMayo,
                            double dblJunio,
                            double dblJulio,
                            double dblAgosto,
                            double dblSetiembre,
                            double dblOctubre,
                            double dblNoviembre,
                            double dblDiciembre
                            )
        {
            dblImporte_2020 = dImporte_2020;
            this.Txt_Importe_2020.Value = dblImporte_2020;
            this.Txt_Enero.Value = dblEnero;
            //if (dblEnero>0)
            //{
            //    this.Txt_Enero.Appearance.BackColor = Color.FromArgb(128, 255, 128);
            //}
            this.Txt_Febrero.Value = dblFebrero;
            //if (dblFebrero > 0)
            //{
            //    this.Txt_Enero.Appearance.BackColor = Color.FromArgb(128, 255, 128);
            //}
            this.Txt_Marzo.Value = dblMarzo;
            //if (dblMarzo > 0)
            //{
            //    this.Txt_Marzo.Appearance.BackColor = Color.FromArgb(128, 255, 128);
            //}
            this.Txt_Abril.Value = dblAbril;
            //if (dblAbril > 0)
            //{
            //    this.Txt_Abril.Appearance.BackColor = Color.FromArgb(128, 255, 128);
            //}
            this.Txt_Mayo.Value = dblMayo;
            //if (dblMayo > 0)
            //{
            //    this.Txt_Mayo.Appearance.BackColor = Color.FromArgb(128, 255, 128);
            //}
            this.Txt_Junio.Value = dblJunio;
            //if (dblJunio > 0)
            //{
            //    this.Txt_Junio.Appearance.BackColor = Color.FromArgb(128, 255, 128);
            //}
            this.Txt_Julio.Value = dblJulio;
            //if (dblJulio > 0)
            //{
            //    this.Txt_Julio.Appearance.BackColor = Color.FromArgb(128, 255, 128);
            //}
            this.Txt_Agosto.Value = dblAgosto;
            //if (dblAgosto > 0)
            //{
            //    this.Txt_Agosto.Appearance.BackColor = Color.FromArgb(128, 255, 128);
            //}
            this.Txt_Setiembre.Value = dblSetiembre;
            //if (dblSetiembre > 0)
            //{
            //    this.Txt_Setiembre.Appearance.BackColor = Color.FromArgb(128, 255, 128);
            //}
            this.Txt_Octubre.Value = dblOctubre;
            //if (dblOctubre > 0)
            //{
            //    this.Txt_Octubre.Appearance.BackColor = Color.FromArgb(128, 255, 128);
            //}
            this.Txt_Noviembre.Value = dblNoviembre;
            //if (dblNoviembre > 0)
            //{
            //    this.Txt_Noviembre.Appearance.BackColor = Color.FromArgb(128, 255, 128);
            //}
            this.Txt_Diciembre.Value = dblDiciembre;
            //if (dblDiciembre > 0)
            //{
            //    this.Txt_Diciembre.Appearance.BackColor = Color.FromArgb(128, 255, 128);
            //}
            this.PintaTotal();
            this.CambiarEstadoMeses(true);
            this.ShowDialog();
        }

        private void PintaTotal()
        {
            this.Txt_TotalDistribuido.Value = (Convert.ToDouble(this.Txt_Enero.Value) +
                                                Convert.ToDouble(this.Txt_Febrero.Value) +
                                                Convert.ToDouble(this.Txt_Marzo.Value) +
                                                Convert.ToDouble(this.Txt_Abril.Value) +
                                                Convert.ToDouble(this.Txt_Mayo.Value) +
                                                Convert.ToDouble(this.Txt_Junio.Value) +
                                                Convert.ToDouble(this.Txt_Julio.Value) +
                                                Convert.ToDouble(this.Txt_Agosto.Value) +
                                                Convert.ToDouble(this.Txt_Setiembre.Value) +
                                                Convert.ToDouble(this.Txt_Octubre.Value) +
                                                Convert.ToDouble(this.Txt_Noviembre.Value) +
                                                Convert.ToDouble(this.Txt_Diciembre.Value)
                                            );
            dblTotalDistribucion = Convert.ToDouble(this.Txt_TotalDistribuido.Value);
            this.Txt_SaldoPorDistribuir.Value = Convert.ToDouble(this.Txt_Importe_2020.Value) - dblTotalDistribucion;
        }

        private void BlanqueoDatos()
        {
            this.Txt_Enero.Value = 0;
            this.Txt_Febrero.Value = 0;
            this.Txt_Marzo.Value = 0;
            this.Txt_Abril.Value = 0;
            this.Txt_Mayo.Value = 0;
            this.Txt_Junio.Value = 0;
            this.Txt_Julio.Value = 0;
            this.Txt_Agosto.Value = 0;
            this.Txt_Setiembre.Value = 0;
            this.Txt_Octubre.Value = 0;
            this.Txt_Noviembre.Value = 0;
            this.Txt_Diciembre.Value = 0;

            this.Txt_Enero.Appearance.BackColor = Color.White;
            this.Txt_Febrero.Appearance.BackColor = Color.White;
            this.Txt_Marzo.Appearance.BackColor = Color.White;
            this.Txt_Abril.Appearance.BackColor = Color.White;
            this.Txt_Mayo.Appearance.BackColor = Color.White;
            this.Txt_Junio.Appearance.BackColor = Color.White;
            this.Txt_Julio.Appearance.BackColor = Color.White;
            this.Txt_Agosto.Appearance.BackColor = Color.White;
            this.Txt_Setiembre.Appearance.BackColor = Color.White;
            this.Txt_Octubre.Appearance.BackColor = Color.White;
            this.Txt_Noviembre.Appearance.BackColor = Color.White;
            this.Txt_Diciembre.Appearance.BackColor = Color.White;

        }

        private void LlenarMesMarcado(int intMes, double dblDivision)
        {
            if (dblDivision > 0)
            {
                switch (intMes)
                {
                    case 1:
                        this.Txt_Enero.Value = dblDivision;
                        this.Txt_Enero.Appearance.BackColor = Color.FromArgb(128, 255, 128);
                        break;
                    case 2:
                        this.Txt_Febrero.Value = dblDivision;
                        this.Txt_Febrero.Appearance.BackColor = Color.FromArgb(128, 255, 128);
                        break;
                    case 3:
                        this.Txt_Marzo.Value = dblDivision;
                        this.Txt_Marzo.Appearance.BackColor = Color.FromArgb(128, 255, 128);
                        break;
                    case 4:
                        this.Txt_Abril.Value = dblDivision;
                        this.Txt_Abril.Appearance.BackColor = Color.FromArgb(128, 255, 128);
                        break;
                    case 5:
                        this.Txt_Mayo.Value = dblDivision;
                        this.Txt_Mayo.Appearance.BackColor = Color.FromArgb(128, 255, 128);
                        break;
                    case 6:
                        this.Txt_Junio.Value = dblDivision;
                        this.Txt_Junio.Appearance.BackColor = Color.FromArgb(128, 255, 128);
                        break;
                    case 7:
                        this.Txt_Julio.Value = dblDivision;
                        this.Txt_Julio.Appearance.BackColor = Color.FromArgb(128, 255, 128);
                        break;
                    case 8:
                        this.Txt_Agosto.Value = dblDivision;
                        this.Txt_Agosto.Appearance.BackColor = Color.FromArgb(128, 255, 128);
                        break;
                    case 9:
                        this.Txt_Setiembre.Value = dblDivision;
                        this.Txt_Setiembre.Appearance.BackColor = Color.FromArgb(128, 255, 128);
                        break;
                    case 10:
                        this.Txt_Octubre.Value = dblDivision;
                        this.Txt_Octubre.Appearance.BackColor = Color.FromArgb(128, 255, 128);
                        break;
                    case 11:
                        this.Txt_Noviembre.Value = dblDivision;
                        this.Txt_Noviembre.Appearance.BackColor = Color.FromArgb(128, 255, 128);
                        break;
                    case 12:
                        this.Txt_Diciembre.Value = dblDivision;
                        this.Txt_Diciembre.Appearance.BackColor = Color.FromArgb(128, 255, 128);

                        break;
                }

            }

        }


        private void Btn_MesesDistribucion_Click(object sender, EventArgs e)
        {
            WINformulacion.Frm_DistribucionMeses frm = new WINformulacion.Frm_DistribucionMeses();
            frm.ShowDialog();

            if (frm.intMesesMarcados > 0)
            {
                this.BlanqueoDatos();
                double dblResto = 0;
                int intCuentaMes = 0;
                double dblDivision = Math.Round(dblImporte_2020 / frm.intMesesMarcados, 2);
                int intMes = 0;
                for (intMes = 0; intMes <= 11; intMes++)
                {
                    if (frm.blnMeses[intMes] == true)
                    {
                        intCuentaMes = intCuentaMes + 1;
                        if (intCuentaMes == frm.intMesesMarcados)
                        {
                            dblDivision = dblImporte_2020 - dblResto;
                        }
                        LlenarMesMarcado(intMes + 1, dblDivision);
                        dblResto = dblResto + dblDivision;

                    }
                }
                this.PintaTotal();
            }
        }

        private void CambiarEstadoMeses(Boolean blnEstado)
        {
            this.Txt_Enero.Enabled = blnEstado;
            this.Txt_Febrero.Enabled = blnEstado;
            this.Txt_Marzo.Enabled = blnEstado;
            this.Txt_Abril.Enabled = blnEstado;
            this.Txt_Mayo.Enabled = blnEstado;
            this.Txt_Junio.Enabled = blnEstado;
            this.Txt_Julio.Enabled = blnEstado;
            this.Txt_Agosto.Enabled = blnEstado;
            this.Txt_Setiembre.Enabled = blnEstado;
            this.Txt_Octubre.Enabled = blnEstado;
            this.Txt_Noviembre.Enabled = blnEstado;
            this.Txt_Diciembre.Enabled = blnEstado;
        }

        private void Igual_A(double blnFormulacion)
        {
            this.BlanqueoDatos();
            double dblResto = 0;
            int intCuentaMes = 0;
            double dblDivision = Math.Round(blnFormulacion / 12, 2);
            int intMes = 0;
            for (intMes = 0; intMes <= 11; intMes++)
            {
                intCuentaMes = intCuentaMes + 1;
                if (intCuentaMes == 11)
                {
                    dblDivision = blnFormulacion - dblResto;
                }
                LlenarMesMarcado(intMes + 1, dblDivision);
                dblResto = dblResto + dblDivision;
            }
        }


        private void Btn_Aceptar_Click(object sender, EventArgs e)
        {
            dblEnero = Convert.ToDouble(this.Txt_Enero.Value);
            dblFebrero = Convert.ToDouble(this.Txt_Febrero.Value);
            dblMarzo = Convert.ToDouble(this.Txt_Marzo.Value);
            dblAbril = Convert.ToDouble(this.Txt_Abril.Value);
            dblMayo = Convert.ToDouble(this.Txt_Mayo.Value);
            dblJunio = Convert.ToDouble(this.Txt_Junio.Value);
            dblJulio = Convert.ToDouble(this.Txt_Julio.Value);
            dblAgosto = Convert.ToDouble(this.Txt_Agosto.Value);
            dblSetiembre = Convert.ToDouble(this.Txt_Setiembre.Value);
            dblOctubre = Convert.ToDouble(this.Txt_Octubre.Value);
            dblNoviembre = Convert.ToDouble(this.Txt_Noviembre.Value);
            dblDiciembre = Convert.ToDouble(this.Txt_Diciembre.Value);
            dblImporte_2020 = dblTotalDistribucion;
            blnDistribuyo = true;
            this.Close();
        }


        #region Meses


        #endregion

        private void Txt_Enero_Leave(object sender, EventArgs e)
        {
            if ( Convert.ToDouble(this.Txt_Enero.Value) == 0 )
            {
                this.Txt_Enero.Appearance.BackColor = Color.White;
            }
            else
            {
                this.Txt_Enero.Appearance.BackColor = Color.FromArgb(128, 255, 128);
            }
            this.PintaTotal();

        }

        private void Txt_Febrero_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(this.Txt_Febrero.Value) == 0)
            {
                this.Txt_Febrero.Appearance.BackColor = Color.White;
            }
            else
            {
                this.Txt_Febrero.Appearance.BackColor = Color.FromArgb(128, 255, 128);
            }
            this.PintaTotal();

        }

        private void Txt_Marzo_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(this.Txt_Marzo.Value) == 0)
            {
                this.Txt_Marzo.Appearance.BackColor = Color.White;
            }
            else
            {
                this.Txt_Marzo.Appearance.BackColor = Color.FromArgb(128, 255, 128);
            }
            this.PintaTotal();

        }

        private void Txt_Abril_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(this.Txt_Abril.Value) == 0)
            {
                this.Txt_Abril.Appearance.BackColor = Color.White;
            }
            else
            {
                this.Txt_Abril.Appearance.BackColor = Color.FromArgb(128, 255, 128);
            }
            this.PintaTotal();

        }

        private void Txt_Mayo_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(this.Txt_Mayo.Value) == 0)
            {
                this.Txt_Mayo.Appearance.BackColor = Color.White;
            }
            else
            {
                this.Txt_Mayo.Appearance.BackColor = Color.FromArgb(128, 255, 128);
            }
            this.PintaTotal();

        }

        private void Txt_Junio_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(this.Txt_Junio.Value) == 0)
            {
                this.Txt_Junio.Appearance.BackColor = Color.White;
            }
            else
            {
                this.Txt_Junio.Appearance.BackColor = Color.FromArgb(128, 255, 128);
            }
            this.PintaTotal();

        }

        private void Txt_Julio_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(this.Txt_Julio.Value) == 0)
            {
                this.Txt_Julio.Appearance.BackColor = Color.White;
            }
            else
            {
                this.Txt_Julio.Appearance.BackColor = Color.FromArgb(128, 255, 128);
            }
            this.PintaTotal();

        }

        private void Txt_Agosto_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(this.Txt_Agosto.Value) == 0)
            {
                this.Txt_Agosto.Appearance.BackColor = Color.White;
            }
            else
            {
                this.Txt_Agosto.Appearance.BackColor = Color.FromArgb(128, 255, 128);
            }
            this.PintaTotal();

        }

        private void Txt_Setiembre_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(this.Txt_Setiembre.Value) == 0)
            {
                this.Txt_Setiembre.Appearance.BackColor = Color.White;
            }
            else
            {
                this.Txt_Setiembre.Appearance.BackColor = Color.FromArgb(128, 255, 128);
            }
            this.PintaTotal();

        }

        private void Txt_Octubre_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(this.Txt_Octubre.Value) == 0)
            {
                this.Txt_Octubre.Appearance.BackColor = Color.White;
            }
            else
            {
                this.Txt_Octubre.Appearance.BackColor = Color.FromArgb(128, 255, 128);
            }
            this.PintaTotal();

        }

        private void Txt_Noviembre_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(this.Txt_Noviembre.Value) == 0)
            {
                this.Txt_Noviembre.Appearance.BackColor = Color.White;
            }
            else
            {
                this.Txt_Noviembre.Appearance.BackColor = Color.FromArgb(128, 255, 128);
            }
            this.PintaTotal();

        }

        private void Txt_Diciembre_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(this.Txt_Diciembre.Value) == 0)
            {
                this.Txt_Diciembre.Appearance.BackColor = Color.White;
            }
            else
            {
                this.Txt_Diciembre.Appearance.BackColor = Color.FromArgb(128, 255, 128);
            }
            this.PintaTotal();

        }
    }
}