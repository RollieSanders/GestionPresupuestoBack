namespace WINformulacion
{
    partial class Frm_Empleado_CentroCosto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Panel1 = new System.Windows.Forms.Panel();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.trv_ctrl_Empleado = new gnGroupControl.gnGroupTreeView();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.lueCentroCosto = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Empleado = new gnUserControl.gnTextBox_Simple();
            this.StatusStrip2 = new System.Windows.Forms.StatusStrip();
            this.MenuStrip2 = new System.Windows.Forms.MenuStrip();
            this.GuardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueCentroCosto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Empleado)).BeginInit();
            this.MenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.SplitContainer1);
            this.Panel1.Controls.Add(this.MenuStrip1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(800, 450);
            this.Panel1.TabIndex = 1;
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 24);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.trv_ctrl_Empleado);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.GroupBox1);
            this.SplitContainer1.Panel2.Controls.Add(this.StatusStrip2);
            this.SplitContainer1.Panel2.Controls.Add(this.MenuStrip2);
            this.SplitContainer1.Size = new System.Drawing.Size(800, 426);
            this.SplitContainer1.SplitterDistance = 369;
            this.SplitContainer1.TabIndex = 3;
            // 
            // trv_ctrl_Empleado
            // 
            this.trv_ctrl_Empleado.Auxiliar = "";
            this.trv_ctrl_Empleado.DataSource = null;
            this.trv_ctrl_Empleado.DisplayMember = null;
            this.trv_ctrl_Empleado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trv_ctrl_Empleado.LenString = 0;
            this.trv_ctrl_Empleado.Location = new System.Drawing.Point(0, 0);
            this.trv_ctrl_Empleado.Name = "trv_ctrl_Empleado";
            this.trv_ctrl_Empleado.nombreDS = null;
            this.trv_ctrl_Empleado.nombreSP = "";
            this.trv_ctrl_Empleado.parametrosSP = "";
            this.trv_ctrl_Empleado.RowSource = null;
            this.trv_ctrl_Empleado.Size = new System.Drawing.Size(365, 422);
            this.trv_ctrl_Empleado.TabIndex = 1;
            this.trv_ctrl_Empleado.tipoConsumo = gnGroupControl.Tipo.DataSet;
            this.trv_ctrl_Empleado.TypeFind = gnGroupControl.TypeFind.LetraxLetra;
            this.trv_ctrl_Empleado.ValueMember = null;
            this.trv_ctrl_Empleado.ZeroAligment = gnGroupControl.TypeZeroAligment.None;
            this.trv_ctrl_Empleado.afterselect += new gnGroupControl.gnGroupTreeView.afterselectEventHandler(this.trv_ctrl_Empleado_afterselect);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.lueCentroCosto);
            this.GroupBox1.Controls.Add(this.labelControl2);
            this.GroupBox1.Controls.Add(this.labelControl1);
            this.GroupBox1.Controls.Add(this.txt_Empleado);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupBox1.Location = new System.Drawing.Point(0, 24);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(423, 182);
            this.GroupBox1.TabIndex = 5;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Empleado Centro Costo";
            // 
            // lueCentroCosto
            // 
            this.lueCentroCosto.Location = new System.Drawing.Point(110, 55);
            this.lueCentroCosto.Name = "lueCentroCosto";
            this.lueCentroCosto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueCentroCosto.Size = new System.Drawing.Size(307, 20);
            this.lueCentroCosto.TabIndex = 37;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(18, 55);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 13);
            this.labelControl2.TabIndex = 36;
            this.labelControl2.Text = "Centro Costo";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(18, 20);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 13);
            this.labelControl1.TabIndex = 35;
            this.labelControl1.Text = "Empleado";
            // 
            // txt_Empleado
            // 
            this.txt_Empleado.enabledFocusColor = System.Drawing.Color.Lavender;
            this.txt_Empleado.enterFocusColor = System.Drawing.Color.PapayaWhip;
            this.txt_Empleado.exigirCampoLleno = false;
            this.txt_Empleado.leaveFocusColor = System.Drawing.Color.White;
            this.txt_Empleado.Location = new System.Drawing.Point(110, 20);
            this.txt_Empleado.LongitudTexto = 200;
            this.txt_Empleado.Name = "txt_Empleado";
            this.txt_Empleado.resaltarCampoOmitido = false;
            this.txt_Empleado.resaltarCampoOmitidoColor = System.Drawing.Color.LightCoral;
            this.txt_Empleado.Size = new System.Drawing.Size(307, 22);
            this.txt_Empleado.TabIndex = 32;
            this.txt_Empleado.tipoDato = gnUserControl.gnTextBox_Simple.Tipo.Ninguno;
            this.txt_Empleado.tipoDatoC = gnUserControl.gnTextBox_Simple.TipoC.Ninguno;
            // 
            // StatusStrip2
            // 
            this.StatusStrip2.Location = new System.Drawing.Point(0, 400);
            this.StatusStrip2.Name = "StatusStrip2";
            this.StatusStrip2.Size = new System.Drawing.Size(423, 22);
            this.StatusStrip2.TabIndex = 3;
            this.StatusStrip2.Text = "StatusStrip2";
            // 
            // MenuStrip2
            // 
            this.MenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GuardarToolStripMenuItem});
            this.MenuStrip2.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip2.Name = "MenuStrip2";
            this.MenuStrip2.Size = new System.Drawing.Size(423, 24);
            this.MenuStrip2.TabIndex = 4;
            this.MenuStrip2.Text = "MenuStrip2";
            // 
            // GuardarToolStripMenuItem
            // 
            this.GuardarToolStripMenuItem.Name = "GuardarToolStripMenuItem";
            this.GuardarToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.GuardarToolStripMenuItem.Text = "Guardar";
            this.GuardarToolStripMenuItem.Click += new System.EventHandler(this.GuardarToolStripMenuItem_Click);
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MenuStrip1.Size = new System.Drawing.Size(800, 24);
            this.MenuStrip1.TabIndex = 0;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // Frm_Empleado_CentroCosto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Panel1);
            this.Name = "Frm_Empleado_CentroCosto";
            this.ShowIcon = false;
            this.Text = "Empleado Centro Costo";
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            this.SplitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueCentroCosto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Empleado)).EndInit();
            this.MenuStrip2.ResumeLayout(false);
            this.MenuStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        internal gnGroupControl.gnGroupTreeView trv_ctrl_Empleado;
        internal System.Windows.Forms.GroupBox GroupBox1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        internal gnUserControl.gnTextBox_Simple txt_Empleado;
        internal System.Windows.Forms.StatusStrip StatusStrip2;
        internal System.Windows.Forms.MenuStrip MenuStrip2;
        internal System.Windows.Forms.ToolStripMenuItem GuardarToolStripMenuItem;
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lueCentroCosto;
    }
}