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
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinEditors.UltraWinCalc;
using Infragistics.Win;

namespace WINformulacion
{
    public partial class Frm_ActualizaDistribucion : DevExpress.XtraEditors.XtraForm
    {

        private double dblImporte = 0.0;
        public double dblSaldoAnteior;
        public double dblImporte_2019;
        public double dblImporte_2020;
        public double dblImporte_2021;
        public double dblImporte_2022;
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
        public Frm_ActualizaDistribucion()
        {
            InitializeComponent();
        }


        public void ShowMe(int Linea,
                    double dSaldoAnterior,
                    double dImporte_2019,
                    double dImporte_2020,
                    double dImporte_2021,
                    double dImporte_2022,
                    double dEnero,
                    double dFebrero,
                    double dMarzo,
                    double dAbril,
                    double dMayo,
                    double dJunio,
                    double dJulio,
                    double dAgosto,
                    double dSetiembre,
                    double dOctubre,
                    double dNoviembre,
                    double dDiciembre
                    )
        {
            dblSaldoAnteior = dSaldoAnterior;
            dblImporte_2019 = dImporte_2019;
            dblImporte_2020 = dImporte_2020;
            dblImporte_2021 = dImporte_2021;
            dblImporte_2022 = dImporte_2022;
            dblEnero = dEnero;
            dblFebrero = dFebrero;
            dblMarzo = dMarzo;
            dblAbril = dAbril;
            dblMayo = dMayo;
            dblJunio = dJunio;
            dblJulio = dJulio;
            dblAgosto = dAgosto;
            dblSetiembre = dSetiembre;
            dblOctubre = dOctubre;
            dblNoviembre = dNoviembre;
            dblDiciembre = dDiciembre;

            this.Txt_SaldoAnterior.Value = dSaldoAnterior;
            this.Txt_Importe_2019.Value = dImporte_2019;
            this.Txt_Importe_2020.Value = dImporte_2020;
            this.Txt_Importe_2021.Value = dImporte_2021;
            this.Txt_Importe_2022.Value = dImporte_2022;

            if (dblSaldoAnteior> 0)
            {
                this.Lbl_SaldoAnterior.Visible = true;
                this.Lbl_Importe_2019.Visible = true;
                this.Lbl_PorDistribuir.Visible = true;

                this.Txt_SaldoAnterior.Visible = true;
                this.Txt_Importe_2019.Visible = true;
                this.Txt_SaldoPorDistribuir.Visible = true;
            }
            else
            {
                this.Lbl_SaldoAnterior.Visible = false;
                this.Lbl_Importe_2019.Visible = false;
                this.Lbl_PorDistribuir.Visible = false;

                this.Txt_SaldoAnterior.Visible = false;
                this.Txt_Importe_2019.Visible = false;
                this.Txt_SaldoPorDistribuir.Visible = false;
            }
            PintarSumas();
        }



        private void Btn_Aceptar_Click(object sender, EventArgs e)
        {

            Double fSaldoPorDistribuir = Convert.ToDouble(Txt_SaldoPorDistribuir.Text);

            if (dblSaldoAnteior>0)
            {
                if (fSaldoPorDistribuir >= 0)
                {
                    dblSaldoAnteior = Convert.ToDouble(this.Txt_SaldoAnterior.Value);
                    dblImporte_2019 = Convert.ToDouble(this.Txt_Importe_2019.Value);
                    dblImporte_2020 = Convert.ToDouble(this.Txt_Importe_2020.Value);
                    dblImporte_2021 = Convert.ToDouble(this.Txt_Importe_2021.Value);
                    dblImporte_2022 = Convert.ToDouble(this.Txt_Importe_2022.Value);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El Saldo por Distribuir no puede ser negativo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                    dblSaldoAnteior = Convert.ToDouble(this.Txt_SaldoAnterior.Value);
                    dblImporte_2019 = Convert.ToDouble(this.Txt_Importe_2019.Value);
                    dblImporte_2020 = Convert.ToDouble(this.Txt_Importe_2020.Value);
                    dblImporte_2021 = Convert.ToDouble(this.Txt_Importe_2021.Value);
                    dblImporte_2022 = Convert.ToDouble(this.Txt_Importe_2022.Value);
                    this.Close();
            }

        }

        private void Btn_Distribuir_Click(object sender, EventArgs e)
        {
            WINformulacion.Frm_ActualizaDistribucion_Meses frm = new WINformulacion.Frm_ActualizaDistribucion_Meses();

            frm.ShowMe(Convert.ToDouble(this.Txt_Importe_2020.Value), dblEnero, dblFebrero, dblMarzo, dblAbril, dblMayo, dblJunio,
                                   dblJulio, dblAgosto, dblSetiembre, dblOctubre, dblNoviembre, dblDiciembre);

            if (frm.blnDistribuyo == true)
            {
                this.Txt_Importe_2020.Value = frm.dblTotalDistribucion;
                dblEnero = frm.dblEnero;
                dblFebrero = frm.dblFebrero;
                dblMarzo = frm.dblMarzo;
                dblAbril = frm.dblAbril;
                dblMayo = frm.dblMayo;
                dblJunio = frm.dblJunio;
                dblJulio = frm.dblJulio;
                dblAgosto = frm.dblAgosto;
                dblSetiembre = frm.dblSetiembre;
                dblOctubre = frm.dblOctubre;
                dblNoviembre = frm.dblNoviembre;
                dblDiciembre = frm.dblDiciembre;
                blnDistribuyo = frm.blnDistribuyo;
            }
        }

        private void PintarSumas()
        {
            this.Txt_TotalDistribuido.Value = Convert.ToDouble(this.Txt_Importe_2019.Value) +
                                              Convert.ToDouble(this.Txt_Importe_2020.Value) +
                                              Convert.ToDouble(this.Txt_Importe_2021.Value) +
                                              Convert.ToDouble(this.Txt_Importe_2022.Value);

            if ( Convert.ToDouble( this.Txt_SaldoAnterior.Value ) > 0  )
            {
                this.Txt_SaldoPorDistribuir.Text  = Convert.ToString(   Convert.ToDouble( this.Txt_SaldoAnterior.Value ) - 
                                                                        Convert.ToDouble(this.Txt_TotalDistribuido.Value )
                                                                    );
            }

        }

        private void Txt_Importe_2019_Leave(object sender, EventArgs e)
        {
            this.PintarSumas();
        }

        private void Txt_Importe_2020_Leave(object sender, EventArgs e)
        {
            this.PintarSumas();
        }

        private void Txt_Importe_2021_Leave(object sender, EventArgs e)
        {
            this.PintarSumas();
        }

        private void Txt_Importe_2022_Leave(object sender, EventArgs e)
        {
            this.PintarSumas();
        }

        private void Txt_TotalDistribuido_Leave(object sender, EventArgs e)
        {

        }

        private void Txt_SaldoAnterior_Leave(object sender, EventArgs e)
        {
            if ( Convert.ToDouble ( this.Txt_SaldoAnterior.Value ) > 0 )
            {
                this.Txt_Importe_2019.Enabled = true;
                this.Txt_Importe_2021.Enabled = true;
                this.Txt_Importe_2022.Enabled = true;
            }
            else
            {
                this.Txt_Importe_2019.Enabled = false;
                this.Txt_Importe_2021.Enabled = false;
                this.Txt_Importe_2022.Enabled = false;
                this.Txt_Importe_2019.Value = 0;
                this.Txt_Importe_2021.Value = 0;
                this.Txt_Importe_2022.Value = 0;
            }
            this.PintarSumas();
        }

        private void Frm_ActualizaDistribucion_Load(object sender, EventArgs e)
        {

        }

        private void Txt_SaldoAnterior_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}