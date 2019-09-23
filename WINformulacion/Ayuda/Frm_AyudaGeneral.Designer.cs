namespace WINformulacion
{
    partial class Frm_AyudaGeneral
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
            Infragistics.Win.Appearance Appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance Appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance Appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance Appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance Appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance Appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance Appearance14 = new Infragistics.Win.Appearance();
            this.grd_buscados = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grd_buscados)).BeginInit();
            this.SuspendLayout();
            // 
            // grd_buscados
            // 
            Appearance1.BackColor = System.Drawing.Color.Transparent;
            Appearance1.BackColor2 = System.Drawing.Color.Transparent;
            Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.BackwardDiagonal;
            this.grd_buscados.DisplayLayout.Appearance = Appearance1;
            this.grd_buscados.DisplayLayout.InterBandSpacing = 10;
            Appearance8.BackColor = System.Drawing.Color.PowderBlue;
            Appearance8.BackColor2 = System.Drawing.Color.PowderBlue;
            this.grd_buscados.DisplayLayout.Override.ActiveCellAppearance = Appearance8;
            Appearance10.BackColor = System.Drawing.Color.Transparent;
            this.grd_buscados.DisplayLayout.Override.CardAreaAppearance = Appearance10;
            Appearance11.BackColor = System.Drawing.Color.Transparent;
            Appearance11.BackColor2 = System.Drawing.Color.Transparent;
            Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            Appearance11.ForeColor = System.Drawing.Color.Black;
            Appearance11.TextHAlignAsString = "Center";
            Appearance11.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grd_buscados.DisplayLayout.Override.HeaderAppearance = Appearance11;
            Appearance12.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.grd_buscados.DisplayLayout.Override.RowAppearance = Appearance12;
            Appearance13.BackColor = System.Drawing.Color.PapayaWhip;
            Appearance13.BackColor2 = System.Drawing.Color.PapayaWhip;
            Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grd_buscados.DisplayLayout.Override.RowSelectorAppearance = Appearance13;
            this.grd_buscados.DisplayLayout.Override.RowSelectorWidth = 12;
            this.grd_buscados.DisplayLayout.Override.RowSpacingBefore = 2;
            Appearance14.BackColor = System.Drawing.Color.PapayaWhip;
            Appearance14.BackColor2 = System.Drawing.Color.PapayaWhip;
            Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            Appearance14.ForeColor = System.Drawing.Color.Black;
            this.grd_buscados.DisplayLayout.Override.SelectedRowAppearance = Appearance14;
            this.grd_buscados.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(184)))), ((int)(((byte)(131)))));
            this.grd_buscados.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.grd_buscados.Location = new System.Drawing.Point(11, 12);
            this.grd_buscados.Name = "grd_buscados";
            this.grd_buscados.Size = new System.Drawing.Size(603, 287);
            this.grd_buscados.TabIndex = 50;
            this.grd_buscados.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grd_buscados_InitializeLayout);
            this.grd_buscados.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.grd_buscados_ClickCellButton);
            this.grd_buscados.DoubleClickCell += new Infragistics.Win.UltraWinGrid.DoubleClickCellEventHandler(this.grd_buscados_DoubleClickCell);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.Location = new System.Drawing.Point(323, 314);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(120, 23);
            this.cmdCancelar.TabIndex = 52;
            this.cmdCancelar.Text = "&Cancelar";
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Enabled = false;
            this.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAceptar.Location = new System.Drawing.Point(197, 314);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(120, 23);
            this.cmdAceptar.TabIndex = 51;
            this.cmdAceptar.Text = "&Aceptar";
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // Frm_AyudaGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 349);
            this.ControlBox = false;
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.grd_buscados);
            this.Name = "Frm_AyudaGeneral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_AyudaGeneral";
            ((System.ComponentModel.ISupportInitialize)(this.grd_buscados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal Infragistics.Win.UltraWinGrid.UltraGrid grd_buscados;
        internal System.Windows.Forms.Button cmdCancelar;
        internal System.Windows.Forms.Button cmdAceptar;
    }
}