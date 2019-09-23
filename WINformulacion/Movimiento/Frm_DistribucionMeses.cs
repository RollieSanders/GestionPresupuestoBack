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
    public partial class Frm_DistribucionMeses : DevExpress.XtraEditors.XtraForm
    {
        public int intMesesMarcados = 0;
        public bool[] blnMeses = new bool[12];

        private SRformulacion.WCFformulacionEClient objWCF = new SRformulacion.WCFformulacionEClient();

        public Frm_DistribucionMeses()
        {
            InitializeComponent();
        }

        public void ShowMe( double dblEnero,
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
            if ( dblEnero > 0  )
            {
                this.Chk_Enero.Checked = true;
            }
            if (dblFebrero > 0)
            {
                this.Chk_Febrero.Checked = true;
            }
            if (dblMarzo > 0)
            {
                this.Chk_Marzo.Checked = true;
            }
            if (dblAbril > 0)
            {
                this.Chk_Abril.Checked = true;
            }
            if (dblMayo > 0)
            {
                this.Chk_Mayo.Checked = true;
            }
            if (dblJunio > 0)
            {
                this.Chk_Junio.Checked = true;
            }
            if (dblJulio > 0)
            {
                this.Chk_Julio.Checked = true;
            }
            if (dblAgosto > 0)
            {
                this.Chk_Agosto.Checked = true;
            }
            if (dblSetiembre > 0)
            {
                this.Chk_Setiembre.Checked = true;
            }
            if (dblOctubre > 0)
            {
                this.Chk_Octubre.Checked = true;
            }
            if (dblNoviembre > 0)
            {
                this.Chk_Noviembre.Checked = true;
            }
            if (dblDiciembre > 0)
            {
                this.Chk_Diciembre.Checked = true;
            }
        }


        private void Btn_Distribuir_Click(object sender, EventArgs e)
        {
            blnMeses[0] = this.Chk_Enero.Checked;
            blnMeses[1] = this.Chk_Febrero.Checked;
            blnMeses[2] = this.Chk_Marzo.Checked;
            blnMeses[3] = this.Chk_Abril.Checked;
            blnMeses[4] = this.Chk_Mayo.Checked;
            blnMeses[5] = this.Chk_Junio.Checked;
            blnMeses[6] = this.Chk_Julio.Checked;
            blnMeses[7] = this.Chk_Agosto.Checked;
            blnMeses[8] = this.Chk_Setiembre.Checked;
            blnMeses[9] = this.Chk_Octubre.Checked;
            blnMeses[10] = this.Chk_Noviembre.Checked;
            blnMeses[11] = this.Chk_Diciembre.Checked;
            intMesesMarcados = ObtenerDiasMarcados();
            this.Close();
        }

        private void Chk_Todo_CheckedChanged(object sender, EventArgs e)
        {
            this.MarcarMes(this.Chk_Todo.Checked);
        }

        private void MarcarMes(bool blnMarca)
        {
            this.Chk_Enero.Checked = blnMarca;
            this.Chk_Febrero.Checked = blnMarca;
            this.Chk_Marzo.Checked = blnMarca;
            this.Chk_Abril.Checked = blnMarca;
            this.Chk_Mayo.Checked = blnMarca;
            this.Chk_Junio.Checked = blnMarca;
            this.Chk_Julio.Checked = blnMarca;
            this.Chk_Agosto.Checked = blnMarca;
            this.Chk_Setiembre.Checked = blnMarca;
            this.Chk_Octubre.Checked = blnMarca;
            this.Chk_Noviembre.Checked = blnMarca;
            this.Chk_Diciembre.Checked = blnMarca;
        }

        private int ObtenerDiasMarcados()
        {
            int intMeses = 0;
            if (Chk_Enero.Checked == true)
            {
                intMeses = intMeses + 1;
            }
            if (Chk_Febrero.Checked == true)
            {
                intMeses = intMeses + 1;
            }
            if (Chk_Marzo.Checked == true)
            {
                intMeses = intMeses + 1;
            }
            if (Chk_Abril.Checked == true)
            {
                intMeses = intMeses + 1;
            }
            if (Chk_Mayo.Checked == true)
            {
                intMeses = intMeses + 1;
            }
            if (Chk_Junio.Checked == true)
            {
                intMeses = intMeses + 1;
            }
            if (Chk_Julio.Checked == true)
            {
                intMeses = intMeses + 1;
            }
            if (Chk_Agosto.Checked == true)
            {
                intMeses = intMeses + 1;
            }
            if (Chk_Setiembre.Checked == true)
            {
                intMeses = intMeses + 1;
            }
            if (Chk_Octubre.Checked == true)
            {
                intMeses = intMeses + 1;
            }
            if (Chk_Noviembre.Checked == true)
            {
                intMeses = intMeses + 1;
            }
            if (Chk_Diciembre.Checked == true)
            {
                intMeses = intMeses + 1;
            }
            return intMeses;
        }

    }
}