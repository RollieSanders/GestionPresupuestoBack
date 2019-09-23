namespace WINformulacion
{
    partial class Frm_ActualizaDistribucion
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.Btn_Aceptar = new System.Windows.Forms.Button();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.Txt_SaldoPorDistribuir = new System.Windows.Forms.TextBox();
            this.Lbl_PorDistribuir = new Infragistics.Win.Misc.UltraLabel();
            this.Txt_TotalDistribuido = new gnUserControl.gnNumericEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.Btn_Distribuir = new System.Windows.Forms.Button();
            this.Txt_Importe_2020 = new gnUserControl.gnNumericEditor();
            this.Txt_Importe_2021 = new gnUserControl.gnNumericEditor();
            this.Txt_Importe_2022 = new gnUserControl.gnNumericEditor();
            this.Lbl_Importe_2022 = new Infragistics.Win.Misc.UltraLabel();
            this.Lbl_Importe_2021 = new Infragistics.Win.Misc.UltraLabel();
            this.Txt_Importe_2019 = new gnUserControl.gnNumericEditor();
            this.Lbl_Importe_2019 = new Infragistics.Win.Misc.UltraLabel();
            this.Lbl_SaldoAnterior = new Infragistics.Win.Misc.UltraLabel();
            this.Txt_SaldoAnterior = new gnUserControl.gnNumericEditor();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_TotalDistribuido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Importe_2020)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Importe_2021)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Importe_2022)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Importe_2019)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_SaldoAnterior)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Aceptar
            // 
            this.Btn_Aceptar.Image = global::WINformulacion.Properties.Resources.Aceptar_16x16;
            this.Btn_Aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Aceptar.Location = new System.Drawing.Point(181, 285);
            this.Btn_Aceptar.Name = "Btn_Aceptar";
            this.Btn_Aceptar.Size = new System.Drawing.Size(72, 23);
            this.Btn_Aceptar.TabIndex = 2;
            this.Btn_Aceptar.Text = "Aceptar";
            this.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_Aceptar.UseVisualStyleBackColor = true;
            this.Btn_Aceptar.Click += new System.EventHandler(this.Btn_Aceptar_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.groupControl2.Controls.Add(this.Txt_SaldoPorDistribuir);
            this.groupControl2.Controls.Add(this.Lbl_PorDistribuir);
            this.groupControl2.Controls.Add(this.Txt_TotalDistribuido);
            this.groupControl2.Controls.Add(this.ultraLabel1);
            this.groupControl2.Controls.Add(this.Btn_Distribuir);
            this.groupControl2.Controls.Add(this.Txt_Importe_2020);
            this.groupControl2.Controls.Add(this.Txt_Importe_2021);
            this.groupControl2.Controls.Add(this.Txt_Importe_2022);
            this.groupControl2.Controls.Add(this.Lbl_Importe_2022);
            this.groupControl2.Controls.Add(this.Lbl_Importe_2021);
            this.groupControl2.Controls.Add(this.Txt_Importe_2019);
            this.groupControl2.Controls.Add(this.Lbl_Importe_2019);
            this.groupControl2.Location = new System.Drawing.Point(11, 58);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(263, 217);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Distribución del periodo 2020 y otros años";
            // 
            // Txt_SaldoPorDistribuir
            // 
            this.Txt_SaldoPorDistribuir.Enabled = false;
            this.Txt_SaldoPorDistribuir.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Txt_SaldoPorDistribuir.Location = new System.Drawing.Point(142, 181);
            this.Txt_SaldoPorDistribuir.Name = "Txt_SaldoPorDistribuir";
            this.Txt_SaldoPorDistribuir.Size = new System.Drawing.Size(100, 21);
            this.Txt_SaldoPorDistribuir.TabIndex = 130;
            this.Txt_SaldoPorDistribuir.Text = "0.0";
            this.Txt_SaldoPorDistribuir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Txt_SaldoPorDistribuir.Visible = false;
            // 
            // Lbl_PorDistribuir
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_PorDistribuir.Appearance = appearance1;
            this.Lbl_PorDistribuir.AutoSize = true;
            this.Lbl_PorDistribuir.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Lbl_PorDistribuir.Location = new System.Drawing.Point(18, 183);
            this.Lbl_PorDistribuir.Name = "Lbl_PorDistribuir";
            this.Lbl_PorDistribuir.Size = new System.Drawing.Size(115, 15);
            this.Lbl_PorDistribuir.TabIndex = 129;
            this.Lbl_PorDistribuir.Text = "Saldo por Distribuir";
            this.Lbl_PorDistribuir.Visible = false;
            // 
            // Txt_TotalDistribuido
            // 
            this.Txt_TotalDistribuido.Enabled = false;
            this.Txt_TotalDistribuido.enabledFocusColor = System.Drawing.Color.Lavender;
            this.Txt_TotalDistribuido.enterFocusColor = System.Drawing.Color.PapayaWhip;
            this.Txt_TotalDistribuido.exigirCampoLleno = false;
            this.Txt_TotalDistribuido.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Txt_TotalDistribuido.leaveFocusColor = System.Drawing.Color.White;
            this.Txt_TotalDistribuido.Location = new System.Drawing.Point(142, 151);
            this.Txt_TotalDistribuido.Name = "Txt_TotalDistribuido";
            this.Txt_TotalDistribuido.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.Txt_TotalDistribuido.resaltarCampoOmitido = false;
            this.Txt_TotalDistribuido.resaltarCampoOmitidoColor = System.Drawing.Color.LightCoral;
            this.Txt_TotalDistribuido.Size = new System.Drawing.Size(100, 22);
            this.Txt_TotalDistribuido.TabIndex = 4;
            this.Txt_TotalDistribuido.Leave += new System.EventHandler(this.Txt_TotalDistribuido_Leave);
            // 
            // ultraLabel1
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel1.Appearance = appearance6;
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ultraLabel1.Location = new System.Drawing.Point(34, 155);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(99, 15);
            this.ultraLabel1.TabIndex = 127;
            this.ultraLabel1.Text = "Total Distribuido";
            // 
            // Btn_Distribuir
            // 
            this.Btn_Distribuir.Location = new System.Drawing.Point(30, 57);
            this.Btn_Distribuir.Name = "Btn_Distribuir";
            this.Btn_Distribuir.Size = new System.Drawing.Size(100, 23);
            this.Btn_Distribuir.TabIndex = 121;
            this.Btn_Distribuir.Text = "Importe 2020";
            this.Btn_Distribuir.UseVisualStyleBackColor = true;
            this.Btn_Distribuir.Click += new System.EventHandler(this.Btn_Distribuir_Click);
            // 
            // Txt_Importe_2020
            // 
            this.Txt_Importe_2020.enabledFocusColor = System.Drawing.Color.Lavender;
            this.Txt_Importe_2020.enterFocusColor = System.Drawing.Color.PapayaWhip;
            this.Txt_Importe_2020.exigirCampoLleno = false;
            this.Txt_Importe_2020.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Txt_Importe_2020.leaveFocusColor = System.Drawing.Color.White;
            this.Txt_Importe_2020.Location = new System.Drawing.Point(142, 57);
            this.Txt_Importe_2020.Name = "Txt_Importe_2020";
            this.Txt_Importe_2020.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.Txt_Importe_2020.resaltarCampoOmitido = false;
            this.Txt_Importe_2020.resaltarCampoOmitidoColor = System.Drawing.Color.LightCoral;
            this.Txt_Importe_2020.Size = new System.Drawing.Size(100, 22);
            this.Txt_Importe_2020.TabIndex = 1;
            this.Txt_Importe_2020.Leave += new System.EventHandler(this.Txt_Importe_2020_Leave);
            // 
            // Txt_Importe_2021
            // 
            this.Txt_Importe_2021.enabledFocusColor = System.Drawing.Color.Lavender;
            this.Txt_Importe_2021.enterFocusColor = System.Drawing.Color.PapayaWhip;
            this.Txt_Importe_2021.exigirCampoLleno = false;
            this.Txt_Importe_2021.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Txt_Importe_2021.leaveFocusColor = System.Drawing.Color.White;
            this.Txt_Importe_2021.Location = new System.Drawing.Point(142, 85);
            this.Txt_Importe_2021.Name = "Txt_Importe_2021";
            this.Txt_Importe_2021.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.Txt_Importe_2021.resaltarCampoOmitido = false;
            this.Txt_Importe_2021.resaltarCampoOmitidoColor = System.Drawing.Color.LightCoral;
            this.Txt_Importe_2021.Size = new System.Drawing.Size(100, 22);
            this.Txt_Importe_2021.TabIndex = 2;
            this.Txt_Importe_2021.Leave += new System.EventHandler(this.Txt_Importe_2021_Leave);
            // 
            // Txt_Importe_2022
            // 
            this.Txt_Importe_2022.enabledFocusColor = System.Drawing.Color.Lavender;
            this.Txt_Importe_2022.enterFocusColor = System.Drawing.Color.PapayaWhip;
            this.Txt_Importe_2022.exigirCampoLleno = false;
            this.Txt_Importe_2022.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Txt_Importe_2022.leaveFocusColor = System.Drawing.Color.White;
            this.Txt_Importe_2022.Location = new System.Drawing.Point(142, 113);
            this.Txt_Importe_2022.Name = "Txt_Importe_2022";
            this.Txt_Importe_2022.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.Txt_Importe_2022.resaltarCampoOmitido = false;
            this.Txt_Importe_2022.resaltarCampoOmitidoColor = System.Drawing.Color.LightCoral;
            this.Txt_Importe_2022.Size = new System.Drawing.Size(100, 22);
            this.Txt_Importe_2022.TabIndex = 3;
            this.Txt_Importe_2022.Leave += new System.EventHandler(this.Txt_Importe_2022_Leave);
            // 
            // Lbl_Importe_2022
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_Importe_2022.Appearance = appearance4;
            this.Lbl_Importe_2022.AutoSize = true;
            this.Lbl_Importe_2022.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Lbl_Importe_2022.Location = new System.Drawing.Point(57, 117);
            this.Lbl_Importe_2022.Name = "Lbl_Importe_2022";
            this.Lbl_Importe_2022.Size = new System.Drawing.Size(76, 15);
            this.Lbl_Importe_2022.TabIndex = 125;
            this.Lbl_Importe_2022.Text = "Importe 2022:";
            // 
            // Lbl_Importe_2021
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_Importe_2021.Appearance = appearance3;
            this.Lbl_Importe_2021.AutoSize = true;
            this.Lbl_Importe_2021.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Lbl_Importe_2021.Location = new System.Drawing.Point(57, 89);
            this.Lbl_Importe_2021.Name = "Lbl_Importe_2021";
            this.Lbl_Importe_2021.Size = new System.Drawing.Size(76, 15);
            this.Lbl_Importe_2021.TabIndex = 124;
            this.Lbl_Importe_2021.Text = "Importe 2021:";
            // 
            // Txt_Importe_2019
            // 
            this.Txt_Importe_2019.enabledFocusColor = System.Drawing.Color.Lavender;
            this.Txt_Importe_2019.enterFocusColor = System.Drawing.Color.PapayaWhip;
            this.Txt_Importe_2019.exigirCampoLleno = false;
            this.Txt_Importe_2019.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Txt_Importe_2019.leaveFocusColor = System.Drawing.Color.White;
            this.Txt_Importe_2019.Location = new System.Drawing.Point(142, 29);
            this.Txt_Importe_2019.Name = "Txt_Importe_2019";
            this.Txt_Importe_2019.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.Txt_Importe_2019.resaltarCampoOmitido = false;
            this.Txt_Importe_2019.resaltarCampoOmitidoColor = System.Drawing.Color.LightCoral;
            this.Txt_Importe_2019.Size = new System.Drawing.Size(100, 22);
            this.Txt_Importe_2019.TabIndex = 0;
            this.Txt_Importe_2019.Visible = false;
            this.Txt_Importe_2019.Leave += new System.EventHandler(this.Txt_Importe_2019_Leave);
            // 
            // Lbl_Importe_2019
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_Importe_2019.Appearance = appearance5;
            this.Lbl_Importe_2019.AutoSize = true;
            this.Lbl_Importe_2019.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Lbl_Importe_2019.Location = new System.Drawing.Point(57, 33);
            this.Lbl_Importe_2019.Name = "Lbl_Importe_2019";
            this.Lbl_Importe_2019.Size = new System.Drawing.Size(76, 15);
            this.Lbl_Importe_2019.TabIndex = 122;
            this.Lbl_Importe_2019.Text = "Importe 2019:";
            this.Lbl_Importe_2019.Visible = false;
            // 
            // Lbl_SaldoAnterior
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_SaldoAnterior.Appearance = appearance2;
            this.Lbl_SaldoAnterior.AutoSize = true;
            this.Lbl_SaldoAnterior.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Lbl_SaldoAnterior.Location = new System.Drawing.Point(45, 32);
            this.Lbl_SaldoAnterior.Name = "Lbl_SaldoAnterior";
            this.Lbl_SaldoAnterior.Size = new System.Drawing.Size(105, 15);
            this.Lbl_SaldoAnterior.TabIndex = 123;
            this.Lbl_SaldoAnterior.Text = "Importe Anterior:";
            this.Lbl_SaldoAnterior.Visible = false;
            // 
            // Txt_SaldoAnterior
            // 
            this.Txt_SaldoAnterior.Enabled = false;
            this.Txt_SaldoAnterior.enabledFocusColor = System.Drawing.Color.Lavender;
            this.Txt_SaldoAnterior.enterFocusColor = System.Drawing.Color.PapayaWhip;
            this.Txt_SaldoAnterior.exigirCampoLleno = false;
            this.Txt_SaldoAnterior.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Txt_SaldoAnterior.leaveFocusColor = System.Drawing.Color.White;
            this.Txt_SaldoAnterior.Location = new System.Drawing.Point(153, 30);
            this.Txt_SaldoAnterior.Name = "Txt_SaldoAnterior";
            this.Txt_SaldoAnterior.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.Txt_SaldoAnterior.resaltarCampoOmitido = false;
            this.Txt_SaldoAnterior.resaltarCampoOmitidoColor = System.Drawing.Color.LightCoral;
            this.Txt_SaldoAnterior.Size = new System.Drawing.Size(100, 22);
            this.Txt_SaldoAnterior.TabIndex = 0;
            this.Txt_SaldoAnterior.Visible = false;
            this.Txt_SaldoAnterior.ValueChanged += new System.EventHandler(this.Txt_SaldoAnterior_ValueChanged);
            this.Txt_SaldoAnterior.Leave += new System.EventHandler(this.Txt_SaldoAnterior_Leave);
            // 
            // Frm_ActualizaDistribucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 321);
            this.Controls.Add(this.Lbl_SaldoAnterior);
            this.Controls.Add(this.Txt_SaldoAnterior);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.Btn_Aceptar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ActualizaDistribucion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Distribución de la formulación";
            this.Load += new System.EventHandler(this.Frm_ActualizaDistribucion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_TotalDistribuido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Importe_2020)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Importe_2021)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Importe_2022)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Importe_2019)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_SaldoAnterior)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Btn_Aceptar;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.Button Btn_Distribuir;
        private gnUserControl.gnNumericEditor Txt_Importe_2020;
        private gnUserControl.gnNumericEditor Txt_Importe_2021;
        private gnUserControl.gnNumericEditor Txt_Importe_2022;
        private Infragistics.Win.Misc.UltraLabel Lbl_Importe_2022;
        private Infragistics.Win.Misc.UltraLabel Lbl_Importe_2021;
        private gnUserControl.gnNumericEditor Txt_Importe_2019;
        private Infragistics.Win.Misc.UltraLabel Lbl_Importe_2019;
        private gnUserControl.gnNumericEditor Txt_TotalDistribuido;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel Lbl_SaldoAnterior;
        private gnUserControl.gnNumericEditor Txt_SaldoAnterior;
        private Infragistics.Win.Misc.UltraLabel Lbl_PorDistribuir;
        private System.Windows.Forms.TextBox Txt_SaldoPorDistribuir;
    }
}