using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WINformulacion
{
    public partial class Frm_Empleado_CentroCosto : DevExpress.XtraEditors.XtraForm
    {
        private SRformulacion.WCFformulacionEClient objWCF = new SRformulacion.WCFformulacionEClient();

        public Frm_Empleado_CentroCosto()
        {
            InitializeComponent();
            CargarCentroCosto();
            Cargar_Arbol_Empleado();
            
        }
        DataSet DS_CentroCosto = new DataSet();
        DataSet DS_Empleado = new DataSet();
        public void CargarCentroCosto() {
            Service.CentroCosto CC = new Service.CentroCosto();
            if (MyStuff.UsaWCF == true)
            {
                 DS_CentroCosto = objWCF.Ayuda_CentroCosto("000000");
            }
            else
            {
                DS_CentroCosto = CC.Ayuda_CentroCosto("000000");
            }

           

            lueCentroCosto.Properties.DataSource = DS_CentroCosto.Tables[0];
            lueCentroCosto.Properties.DisplayMember = "vNomCeCo";
            lueCentroCosto.Properties.ValueMember = "CodigoCeCo";
            
            LookUpColumnInfoCollection coll = lueCentroCosto.Properties.Columns;
            coll.Add(new LookUpColumnInfo("CodigoCeCo", "Codigo"));
            coll.Add(new LookUpColumnInfo("vNomCeCo", "Nombre Centro Costo"));
            lueCentroCosto.Properties.Columns[0].Visible = false;
            lueCentroCosto.Properties.AutoSearchColumnIndex = 2;
            lueCentroCosto.Properties.NullText = "";

        }

        public void Cargar_Arbol_Empleado() {
            Service.EmpleadoCentroCosto ECC = new Service.EmpleadoCentroCosto();
            if (MyStuff.UsaWCF == true)
            {
                 DS_Empleado = objWCF.Arbol_Empleado();
            }
            else
            {
                DS_Empleado = ECC.Arbol_Empleado();
            }

        
            trv_ctrl_Empleado.CargaDS(DS_Empleado);
            trv_ctrl_Empleado.ValueMember = "iCodEmpleado";
            trv_ctrl_Empleado.DisplayMember = "NombreCompleto";
        }

        int iCodEmpleado = 0;
        int iCodEmpleadoCentroCosto = 0;
        private void trv_ctrl_Empleado_afterselect(object sender, gnGroupControl.leafTreeViewEventArgs e)
        {
            iCodEmpleado = Convert.ToInt32(e.Node.Value.ToString());
            txt_Empleado.Text = Obtiene_Nombre_Empleado(iCodEmpleado);
        }

        DataSet DS_Empleado_CentroCosto = new DataSet();
        public string Obtiene_Nombre_Empleado(int iCodEmpleadoVal) {
            string resultado = string.Empty;
            if (iCodEmpleadoVal > 0)
            {
                if (DS_Empleado.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DS_Empleado.Tables[0].Rows)
                    {
                        if (Convert.ToString(row[1]).Trim() == Convert.ToString(iCodEmpleadoVal))
                        {
                            //blnEncontrado = true;
                            resultado = Convert.ToString(row[0]).TrimEnd();
                            break;
                        }
                    }

                }
                Service.EmpleadoCentroCosto ECC = new Service.EmpleadoCentroCosto();

                if (MyStuff.UsaWCF == true)
                {
                     DS_Empleado_CentroCosto = objWCF.Recupera_Empleado_CentroCosto(iCodEmpleadoVal);
                }
                else
                {
                    DS_Empleado_CentroCosto = ECC.Recupera_Empleado_CentroCosto(iCodEmpleadoVal);
                }


             
                if (DS_Empleado_CentroCosto.Tables[0].Rows.Count > 0)
                {
                    iCodEmpleadoCentroCosto = Convert.ToInt32(DS_Empleado_CentroCosto.Tables[0].Rows[0].ItemArray[0].ToString().Trim());
                    lueCentroCosto.EditValue = DS_Empleado_CentroCosto.Tables[0].Rows[0].ItemArray[1].ToString().Trim();

                }
                else {
                    iCodEmpleadoCentroCosto = 0;
                    lueCentroCosto.EditValue = lueCentroCosto.Properties.NullText;
                }

            }
            
            return resultado;
        }

        private void GuardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (iCodEmpleadoCentroCosto > 0)
                {
                    Service.EmpleadoCentroCosto ECC = new Service.EmpleadoCentroCosto();
                    if (MyStuff.UsaWCF == true)
                    {
                        objWCF.Modifica_Empleado_CentroCosto(iCodEmpleadoCentroCosto, lueCentroCosto.EditValue.ToString().Trim());
                    }
                    else
                    {
                        ECC.Modifica_Empleado_CentroCosto(iCodEmpleadoCentroCosto, lueCentroCosto.EditValue.ToString().Trim());
                    }
                }
                else
                {
                    Service.EmpleadoCentroCosto ECC = new Service.EmpleadoCentroCosto();
                    if (MyStuff.UsaWCF == true)
                    {
                        objWCF.Graba_Empleado_CentroCosto(iCodEmpleado, lueCentroCosto.EditValue.ToString().Trim());
                    }
                    else
                    {
                        ECC.Graba_Empleado_CentroCosto(iCodEmpleado, lueCentroCosto.EditValue.ToString().Trim());
                    }

                    
                }

                Cargar_Arbol_Empleado();
            }
            catch (Exception)
            {
                MessageBox.Show("Datos Guardados Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            

        }
    }
}
