namespace WINformulacion
{
    partial class Frm_Asignar_CeCo_Clasificador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Asignar_CeCo_Clasificador));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.Appearance Appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance Appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance Appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance Appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance Appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance Appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook2 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.Txt_NomCeCo = new gnUserControl.gnTextBox_Simple();
            this.Txt_CentroCosto = new gnUserControl.gnTextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.Grd_mvto_ClasXAsignar = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.Grd_mvto_ClasAsignados = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.btnAgregar = new DevExpress.XtraEditors.SimpleButton();
            this.btnQuitar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_NomCeCo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_CentroCosto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd_mvto_ClasXAsignar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd_mvto_ClasAsignados)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnBuscar);
            this.groupControl1.Controls.Add(this.Txt_NomCeCo);
            this.groupControl1.Controls.Add(this.Txt_CentroCosto);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(774, 66);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(635, 23);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // Txt_NomCeCo
            // 
            this.Txt_NomCeCo.Enabled = false;
            this.Txt_NomCeCo.enabledFocusColor = System.Drawing.Color.Lavender;
            this.Txt_NomCeCo.enterFocusColor = System.Drawing.Color.PapayaWhip;
            this.Txt_NomCeCo.exigirCampoLleno = false;
            this.Txt_NomCeCo.leaveFocusColor = System.Drawing.Color.White;
            this.Txt_NomCeCo.Location = new System.Drawing.Point(222, 23);
            this.Txt_NomCeCo.LongitudTexto = 200;
            this.Txt_NomCeCo.Name = "Txt_NomCeCo";
            this.Txt_NomCeCo.resaltarCampoOmitido = false;
            this.Txt_NomCeCo.resaltarCampoOmitidoColor = System.Drawing.Color.LightCoral;
            this.Txt_NomCeCo.Size = new System.Drawing.Size(407, 22);
            this.Txt_NomCeCo.TabIndex = 94;
            this.Txt_NomCeCo.tipoDato = gnUserControl.gnTextBox_Simple.Tipo.Ninguno;
            this.Txt_NomCeCo.tipoDatoC = gnUserControl.gnTextBox_Simple.TipoC.Ninguno;
            // 
            // Txt_CentroCosto
            // 
            this.Txt_CentroCosto.anchoColumnasAyuda = "150, 210, 210";
            this.Txt_CentroCosto.DatoAnterior = "";
            this.Txt_CentroCosto.EligevariosElementos = false;
            this.Txt_CentroCosto.enabledFocusColor = System.Drawing.Color.Lavender;
            this.Txt_CentroCosto.enterFocusColor = System.Drawing.Color.PapayaWhip;
            this.Txt_CentroCosto.exigirCampoLleno = false;
            this.Txt_CentroCosto.InputMask = "";
            this.Txt_CentroCosto.leaveFocusColor = System.Drawing.Color.White;
            this.Txt_CentroCosto.Location = new System.Drawing.Point(113, 23);
            this.Txt_CentroCosto.LongitudTexto = 200;
            this.Txt_CentroCosto.mensajeExisteDatoSP = "";
            this.Txt_CentroCosto.mensajeNoExisteDatoSP = "";
            this.Txt_CentroCosto.Name = "Txt_CentroCosto";
            this.Txt_CentroCosto.nombreDS = null;
            this.Txt_CentroCosto.nombreExisteDatoSP = "";
            this.Txt_CentroCosto.nombreNoExisteDatoSP = "";
            this.Txt_CentroCosto.nombreSP = "";
            this.Txt_CentroCosto.parametrosExisteDatoSP = "";
            this.Txt_CentroCosto.parametrosNoExisteDatoSP = "";
            this.Txt_CentroCosto.parametrosSP = "";
            this.Txt_CentroCosto.PosicionCampo = 1;
            this.Txt_CentroCosto.PosicionCampoTexto = 1;
            this.Txt_CentroCosto.PosicionValue = 1;
            this.Txt_CentroCosto.resaltarCampoOmitido = false;
            this.Txt_CentroCosto.resaltarCampoOmitidoColor = System.Drawing.Color.LightCoral;
            this.Txt_CentroCosto.Size = new System.Drawing.Size(103, 22);
            this.Txt_CentroCosto.TabIndex = 1;
            this.Txt_CentroCosto.tipoAyuda = gnUserControl.gnTextBox.Ayuda.ConAyudaInicial;
            this.Txt_CentroCosto.tipoDato = gnUserControl.gnTextBox.Tipo.Ninguno;
            this.Txt_CentroCosto.tipoDatoC = gnUserControl.gnTextBox.TipoC.Ninguno;
            this.Txt_CentroCosto.tipoextraccion = gnUserControl.gnTextBox.TipoExtra.DataSet;
            this.Txt_CentroCosto.valorDevueltoVarios = "";
            this.Txt_CentroCosto.ValorDigitado = "";
            this.Txt_CentroCosto.Leave += new System.EventHandler(this.Txt_CentroCosto_Leave);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(39, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Centro Costo:";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.Grd_mvto_ClasXAsignar);
            this.groupControl2.Location = new System.Drawing.Point(13, 97);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(340, 331);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Clasificador por Asignar";
            // 
            // Grd_mvto_ClasXAsignar
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.Grd_mvto_ClasXAsignar.DisplayLayout.Appearance = appearance1;
            this.Grd_mvto_ClasXAsignar.DisplayLayout.InterBandSpacing = 10;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.Grd_mvto_ClasXAsignar.DisplayLayout.Override.CardAreaAppearance = appearance2;
            this.Grd_mvto_ClasXAsignar.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Left";
            appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.Grd_mvto_ClasXAsignar.DisplayLayout.Override.HeaderAppearance = appearance3;
            this.Grd_mvto_ClasXAsignar.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.Grd_mvto_ClasXAsignar.DisplayLayout.Override.RowAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Grd_mvto_ClasXAsignar.DisplayLayout.Override.RowSelectorAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.ForeColor = System.Drawing.Color.Black;
            this.Grd_mvto_ClasXAsignar.DisplayLayout.Override.SelectedRowAppearance = appearance6;
            this.Grd_mvto_ClasXAsignar.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.Grd_mvto_ClasXAsignar.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            scrollBarLook1.ScrollBarArrowStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarArrowStyle.BothAtRightBottom;
            scrollBarLook1.ShowMinMaxButtons = Infragistics.Win.DefaultableBoolean.True;
            this.Grd_mvto_ClasXAsignar.DisplayLayout.ScrollBarLook = scrollBarLook1;
            this.Grd_mvto_ClasXAsignar.DisplayLayout.UseFixedHeaders = true;
            this.Grd_mvto_ClasXAsignar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grd_mvto_ClasXAsignar.Location = new System.Drawing.Point(2, 20);
            this.Grd_mvto_ClasXAsignar.Name = "Grd_mvto_ClasXAsignar";
            this.Grd_mvto_ClasXAsignar.Size = new System.Drawing.Size(336, 309);
            this.Grd_mvto_ClasXAsignar.TabIndex = 55;
            this.Grd_mvto_ClasXAsignar.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.Grd_mvto_ClasXAsignar_InitializeLayout);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.Grd_mvto_ClasAsignados);
            this.groupControl3.Location = new System.Drawing.Point(446, 97);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(340, 330);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "Clasificador Asignados";
            // 
            // Grd_mvto_ClasAsignados
            // 
            Appearance1.BackColor = System.Drawing.Color.Transparent;
            this.Grd_mvto_ClasAsignados.DisplayLayout.Appearance = Appearance1;
            this.Grd_mvto_ClasAsignados.DisplayLayout.InterBandSpacing = 10;
            Appearance2.BackColor = System.Drawing.Color.Transparent;
            this.Grd_mvto_ClasAsignados.DisplayLayout.Override.CardAreaAppearance = Appearance2;
            this.Grd_mvto_ClasAsignados.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            Appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            Appearance3.ForeColor = System.Drawing.Color.Black;
            Appearance3.TextHAlignAsString = "Left";
            Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.Grd_mvto_ClasAsignados.DisplayLayout.Override.HeaderAppearance = Appearance3;
            this.Grd_mvto_ClasAsignados.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            Appearance4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.Grd_mvto_ClasAsignados.DisplayLayout.Override.RowAppearance = Appearance4;
            Appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            Appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Grd_mvto_ClasAsignados.DisplayLayout.Override.RowSelectorAppearance = Appearance5;
            Appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            Appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            Appearance6.ForeColor = System.Drawing.Color.Black;
            this.Grd_mvto_ClasAsignados.DisplayLayout.Override.SelectedRowAppearance = Appearance6;
            this.Grd_mvto_ClasAsignados.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.Grd_mvto_ClasAsignados.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            scrollBarLook2.ScrollBarArrowStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarArrowStyle.BothAtRightBottom;
            scrollBarLook2.ShowMinMaxButtons = Infragistics.Win.DefaultableBoolean.True;
            this.Grd_mvto_ClasAsignados.DisplayLayout.ScrollBarLook = scrollBarLook2;
            this.Grd_mvto_ClasAsignados.DisplayLayout.UseFixedHeaders = true;
            this.Grd_mvto_ClasAsignados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grd_mvto_ClasAsignados.Location = new System.Drawing.Point(2, 20);
            this.Grd_mvto_ClasAsignados.Name = "Grd_mvto_ClasAsignados";
            this.Grd_mvto_ClasAsignados.Size = new System.Drawing.Size(336, 308);
            this.Grd_mvto_ClasAsignados.TabIndex = 56;
            this.Grd_mvto_ClasAsignados.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.Grd_mvto_ClasAsignados_InitializeLayout);
            this.Grd_mvto_ClasAsignados.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.Grd_mvto_ClasAsignados_CellChange);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(362, 215);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = ">>";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(362, 275);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(75, 23);
            this.btnQuitar.TabIndex = 4;
            this.btnQuitar.Text = "<<";
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // Frm_Asignar_CeCo_Clasificador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "Frm_Asignar_CeCo_Clasificador";
            this.ShowIcon = false;
            this.Text = "Asignar Centro Costo a Clasificador";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_NomCeCo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_CentroCosto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grd_mvto_ClasXAsignar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grd_mvto_ClasAsignados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        internal Infragistics.Win.UltraWinGrid.UltraGrid Grd_mvto_ClasXAsignar;
        internal Infragistics.Win.UltraWinGrid.UltraGrid Grd_mvto_ClasAsignados;
        private DevExpress.XtraEditors.SimpleButton btnAgregar;
        private DevExpress.XtraEditors.SimpleButton btnQuitar;
        private gnUserControl.gnTextBox Txt_CentroCosto;
        private gnUserControl.gnTextBox_Simple Txt_NomCeCo;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
    }
}