namespace WINformulacion
{
    partial class Frm_Actualiza_Version
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance Appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance Appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance Appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance Appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance Appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance Appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance Appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance Appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance Appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance Appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance Appearance6 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Actualiza_Version));
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_Listar = new System.Windows.Forms.ToolStripButton();
            this.UltraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
            this.txt_Version = new gnUserControl.gnTextBox_Simple();
            this.edt_Nota = new gnUserControl.gnEditBox();
            this.txt_NumDocumento = new gnUserControl.gnTextBox_Simple();
            this.txt_AñoProceso = new gnUserControl.gnMaskedTextBox();
            this.UltraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.cbo_CodTipoDocumento = new gnUserControl.gnComboBox();
            this.UltraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.UltraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.grp_Catalogo = new Infragistics.Win.Misc.UltraGroupBox();
            this.grd_mvto_ListaVersiones = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.imageCollection16 = new DevExpress.Utils.ImageCollection(this.components);
            this.UltraGridExcelExporter1 = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
            this.SaveDocumento = new System.Windows.Forms.SaveFileDialog();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btn_Nuevo = new System.Windows.Forms.ToolStripButton();
            this.btn_Grabar = new System.Windows.Forms.ToolStripButton();
            this.btn_DesHacer = new System.Windows.Forms.ToolStripButton();
            this.btn_Eliminar = new System.Windows.Forms.ToolStripButton();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox3)).BeginInit();
            this.UltraGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Version)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_Nota)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_NumDocumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grp_Catalogo)).BeginInit();
            this.grp_Catalogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_mvto_ListaVersiones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection16)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Nuevo,
            this.btn_Grabar,
            this.btn_DesHacer,
            this.ToolStripSeparator1,
            this.btn_Eliminar,
            this.btn_Listar});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(800, 25);
            this.ToolStrip1.TabIndex = 4;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_Listar
            // 
            this.btn_Listar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_Listar.Image = global::WINformulacion.Properties.Resources.Lista_16x16;
            this.btn_Listar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Listar.Name = "btn_Listar";
            this.btn_Listar.Size = new System.Drawing.Size(55, 22);
            this.btn_Listar.Text = "Listar";
            this.btn_Listar.Click += new System.EventHandler(this.btn_Listar_Click);
            // 
            // UltraGroupBox3
            // 
            this.UltraGroupBox3.Controls.Add(this.txt_Version);
            this.UltraGroupBox3.Controls.Add(this.edt_Nota);
            this.UltraGroupBox3.Controls.Add(this.txt_NumDocumento);
            this.UltraGroupBox3.Controls.Add(this.txt_AñoProceso);
            this.UltraGroupBox3.Controls.Add(this.UltraLabel10);
            this.UltraGroupBox3.Controls.Add(this.UltraLabel6);
            this.UltraGroupBox3.Controls.Add(this.UltraLabel5);
            this.UltraGroupBox3.Controls.Add(this.cbo_CodTipoDocumento);
            this.UltraGroupBox3.Controls.Add(this.UltraLabel4);
            this.UltraGroupBox3.Controls.Add(this.UltraLabel3);
            this.UltraGroupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.UltraGroupBox3.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.LeftOutsideBorder;
            this.UltraGroupBox3.Location = new System.Drawing.Point(0, 25);
            this.UltraGroupBox3.Name = "UltraGroupBox3";
            this.UltraGroupBox3.Size = new System.Drawing.Size(800, 181);
            this.UltraGroupBox3.TabIndex = 5;
            this.UltraGroupBox3.Text = "1. Datos de la Versión";
            this.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // txt_Version
            // 
            this.txt_Version.Enabled = false;
            this.txt_Version.enabledFocusColor = System.Drawing.Color.Lavender;
            this.txt_Version.enterFocusColor = System.Drawing.Color.PapayaWhip;
            this.txt_Version.exigirCampoLleno = false;
            this.txt_Version.leaveFocusColor = System.Drawing.Color.White;
            this.txt_Version.Location = new System.Drawing.Point(164, 31);
            this.txt_Version.LongitudTexto = 200;
            this.txt_Version.Name = "txt_Version";
            this.txt_Version.resaltarCampoOmitido = false;
            this.txt_Version.resaltarCampoOmitidoColor = System.Drawing.Color.LightCoral;
            this.txt_Version.Size = new System.Drawing.Size(55, 22);
            this.txt_Version.TabIndex = 84;
            this.txt_Version.tipoDato = gnUserControl.gnTextBox_Simple.Tipo.Ninguno;
            this.txt_Version.tipoDatoC = gnUserControl.gnTextBox_Simple.TipoC.Ninguno;
            // 
            // edt_Nota
            // 
            this.edt_Nota.enterFocusColor = System.Drawing.Color.LemonChiffon;
            this.edt_Nota.exigirCampoLleno = false;
            this.edt_Nota.KeyDownUp = "";
            this.edt_Nota.leaveFocusColor = System.Drawing.Color.White;
            this.edt_Nota.Location = new System.Drawing.Point(164, 103);
            this.edt_Nota.Multiline = true;
            this.edt_Nota.Name = "edt_Nota";
            this.edt_Nota.resaltarCampoOmitido = false;
            this.edt_Nota.resaltarCampoOmitidoColor = System.Drawing.Color.LightCoral;
            this.edt_Nota.Size = new System.Drawing.Size(477, 70);
            this.edt_Nota.TabIndex = 4;
            this.edt_Nota.tipoDatoC = gnUserControl.gnEditBox.TipoC.Ninguno;
            // 
            // txt_NumDocumento
            // 
            this.txt_NumDocumento.enabledFocusColor = System.Drawing.Color.Lavender;
            this.txt_NumDocumento.enterFocusColor = System.Drawing.Color.PapayaWhip;
            this.txt_NumDocumento.exigirCampoLleno = false;
            this.txt_NumDocumento.leaveFocusColor = System.Drawing.Color.White;
            this.txt_NumDocumento.Location = new System.Drawing.Point(164, 79);
            this.txt_NumDocumento.LongitudTexto = 200;
            this.txt_NumDocumento.Name = "txt_NumDocumento";
            this.txt_NumDocumento.resaltarCampoOmitido = false;
            this.txt_NumDocumento.resaltarCampoOmitidoColor = System.Drawing.Color.LightCoral;
            this.txt_NumDocumento.Size = new System.Drawing.Size(182, 22);
            this.txt_NumDocumento.TabIndex = 3;
            this.txt_NumDocumento.tipoDato = gnUserControl.gnTextBox_Simple.Tipo.Ninguno;
            this.txt_NumDocumento.tipoDatoC = gnUserControl.gnTextBox_Simple.TipoC.Ninguno;
            // 
            // txt_AñoProceso
            // 
            this.txt_AñoProceso.enabledFocusColor = System.Drawing.Color.Gainsboro;
            this.txt_AñoProceso.enterFocusColor = System.Drawing.Color.LemonChiffon;
            this.txt_AñoProceso.exigirCampoLleno = false;
            this.txt_AñoProceso.leaveFocusColor = System.Drawing.Color.White;
            this.txt_AñoProceso.Location = new System.Drawing.Point(164, 10);
            this.txt_AñoProceso.Mask = "9999";
            this.txt_AñoProceso.Name = "txt_AñoProceso";
            this.txt_AñoProceso.resaltarCampoOmitido = false;
            this.txt_AñoProceso.resaltarCampoOmitidoColor = System.Drawing.Color.LightCoral;
            this.txt_AñoProceso.Size = new System.Drawing.Size(55, 21);
            this.txt_AñoProceso.TabIndex = 0;
            // 
            // UltraLabel10
            // 
            Appearance19.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel10.Appearance = Appearance19;
            this.UltraLabel10.AutoSize = true;
            this.UltraLabel10.Location = new System.Drawing.Point(126, 107);
            this.UltraLabel10.Name = "UltraLabel10";
            this.UltraLabel10.Size = new System.Drawing.Size(32, 15);
            this.UltraLabel10.TabIndex = 83;
            this.UltraLabel10.Text = "Nota:";
            // 
            // UltraLabel6
            // 
            Appearance8.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel6.Appearance = Appearance8;
            this.UltraLabel6.AutoSize = true;
            this.UltraLabel6.Location = new System.Drawing.Point(111, 12);
            this.UltraLabel6.Name = "UltraLabel6";
            this.UltraLabel6.Size = new System.Drawing.Size(46, 15);
            this.UltraLabel6.TabIndex = 81;
            this.UltraLabel6.Text = "Periodo:";
            // 
            // UltraLabel5
            // 
            Appearance27.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel5.Appearance = Appearance27;
            this.UltraLabel5.AutoSize = true;
            this.UltraLabel5.Location = new System.Drawing.Point(111, 32);
            this.UltraLabel5.Name = "UltraLabel5";
            this.UltraLabel5.Size = new System.Drawing.Size(45, 15);
            this.UltraLabel5.TabIndex = 78;
            this.UltraLabel5.Text = "Versión:";
            // 
            // cbo_CodTipoDocumento
            // 
            this.cbo_CodTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_CodTipoDocumento.enterFocusColor = System.Drawing.Color.LemonChiffon;
            this.cbo_CodTipoDocumento.FormattingEnabled = true;
            this.cbo_CodTipoDocumento.leaveFocusColor = System.Drawing.Color.White;
            this.cbo_CodTipoDocumento.Location = new System.Drawing.Point(164, 55);
            this.cbo_CodTipoDocumento.Name = "cbo_CodTipoDocumento";
            this.cbo_CodTipoDocumento.nombreDS = null;
            this.cbo_CodTipoDocumento.nombreSP = "";
            this.cbo_CodTipoDocumento.parametrosSP = "";
            this.cbo_CodTipoDocumento.resaltarCampoOmitido = false;
            this.cbo_CodTipoDocumento.resaltarCampoOmitidoColor = System.Drawing.Color.LightCoral;
            this.cbo_CodTipoDocumento.Size = new System.Drawing.Size(182, 21);
            this.cbo_CodTipoDocumento.TabIndex = 2;
            this.cbo_CodTipoDocumento.tipoConsumo = gnUserControl.gnComboBox.Tipo.DataSet;
            // 
            // UltraLabel4
            // 
            Appearance7.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel4.Appearance = Appearance7;
            this.UltraLabel4.AutoSize = true;
            this.UltraLabel4.Location = new System.Drawing.Point(34, 83);
            this.UltraLabel4.Name = "UltraLabel4";
            this.UltraLabel4.Size = new System.Drawing.Size(124, 15);
            this.UltraLabel4.TabIndex = 67;
            this.UltraLabel4.Text = "Numero de Documento:";
            // 
            // UltraLabel3
            // 
            Appearance23.BackColor = System.Drawing.Color.Transparent;
            this.UltraLabel3.Appearance = Appearance23;
            this.UltraLabel3.AutoSize = true;
            this.UltraLabel3.Location = new System.Drawing.Point(51, 59);
            this.UltraLabel3.Name = "UltraLabel3";
            this.UltraLabel3.Size = new System.Drawing.Size(106, 15);
            this.UltraLabel3.TabIndex = 24;
            this.UltraLabel3.Text = "Tipo de Documento:";
            // 
            // grp_Catalogo
            // 
            this.grp_Catalogo.Controls.Add(this.grd_mvto_ListaVersiones);
            this.grp_Catalogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_Catalogo.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.LeftOutsideBorder;
            this.grp_Catalogo.Location = new System.Drawing.Point(0, 206);
            this.grp_Catalogo.Name = "grp_Catalogo";
            this.grp_Catalogo.Size = new System.Drawing.Size(800, 244);
            this.grp_Catalogo.TabIndex = 6;
            this.grp_Catalogo.Text = "2. Lista de Versiones";
            this.grp_Catalogo.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // grd_mvto_ListaVersiones
            // 
            Appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.grd_mvto_ListaVersiones.DisplayLayout.Appearance = Appearance1;
            this.grd_mvto_ListaVersiones.DisplayLayout.InterBandSpacing = 10;
            Appearance2.BackColor = System.Drawing.Color.Transparent;
            this.grd_mvto_ListaVersiones.DisplayLayout.Override.CardAreaAppearance = Appearance2;
            this.grd_mvto_ListaVersiones.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            Appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            Appearance3.ForeColor = System.Drawing.Color.Black;
            Appearance3.TextHAlignAsString = "Left";
            Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grd_mvto_ListaVersiones.DisplayLayout.Override.HeaderAppearance = Appearance3;
            this.grd_mvto_ListaVersiones.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            Appearance4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.grd_mvto_ListaVersiones.DisplayLayout.Override.RowAppearance = Appearance4;
            Appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            Appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grd_mvto_ListaVersiones.DisplayLayout.Override.RowSelectorAppearance = Appearance5;
            Appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            Appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            Appearance6.ForeColor = System.Drawing.Color.Black;
            this.grd_mvto_ListaVersiones.DisplayLayout.Override.SelectedRowAppearance = Appearance6;
            this.grd_mvto_ListaVersiones.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.grd_mvto_ListaVersiones.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.grd_mvto_ListaVersiones.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grd_mvto_ListaVersiones.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grd_mvto_ListaVersiones.DisplayLayout.UseFixedHeaders = true;
            this.grd_mvto_ListaVersiones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd_mvto_ListaVersiones.Location = new System.Drawing.Point(23, 3);
            this.grd_mvto_ListaVersiones.Name = "grd_mvto_ListaVersiones";
            this.grd_mvto_ListaVersiones.Size = new System.Drawing.Size(774, 238);
            this.grd_mvto_ListaVersiones.TabIndex = 49;
            this.grd_mvto_ListaVersiones.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grd_mvto_ListaVersiones_InitializeLayout);
            this.grd_mvto_ListaVersiones.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.grd_mvto_ListaVersiones_AfterSelectChange);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // imageCollection16
            // 
            this.imageCollection16.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection16.ImageStream")));
            this.imageCollection16.InsertGalleryImage("0", "grayscaleimages/actions/add_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("grayscaleimages/actions/add_16x16.png"), 0);
            this.imageCollection16.Images.SetKeyName(0, "0");
            this.imageCollection16.InsertGalleryImage("1", "grayscaleimages/save/save_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("grayscaleimages/save/save_16x16.png"), 1);
            this.imageCollection16.Images.SetKeyName(1, "1");
            this.imageCollection16.InsertGalleryImage("2", "grayscaleimages/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("grayscaleimages/actions/cancel_16x16.png"), 2);
            this.imageCollection16.Images.SetKeyName(2, "2");
            this.imageCollection16.InsertGalleryImage("3", "grayscaleimages/history/undo_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("grayscaleimages/history/undo_16x16.png"), 3);
            this.imageCollection16.Images.SetKeyName(3, "3");
            this.imageCollection16.InsertGalleryImage("4", "devav/print/tasklist_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("devav/print/tasklist_16x16.png"), 4);
            this.imageCollection16.Images.SetKeyName(4, "4");
            // 
            // SaveDocumento
            // 
            this.SaveDocumento.DefaultExt = "XLS";
            this.SaveDocumento.Filter = "Excel (*.xls)|*.xls";
            this.SaveDocumento.RestoreDirectory = true;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Signoexclamacion_cabecera.png");
            this.imageList2.Images.SetKeyName(1, "campana_cabecera.png");
            this.imageList2.Images.SetKeyName(2, "email_respondido.png");
            this.imageList2.Images.SetKeyName(3, "Adjuntar_cabecera.png");
            this.imageList2.Images.SetKeyName(4, "Seguimiento_Detalle.png");
            this.imageList2.Images.SetKeyName(5, "Leido.png");
            this.imageList2.Images.SetKeyName(6, "esfera_ambar.png");
            this.imageList2.Images.SetKeyName(7, "esfera_roja.jpg");
            this.imageList2.Images.SetKeyName(8, "esfera_verde.png");
            this.imageList2.Images.SetKeyName(9, "Pasos.png");
            this.imageList2.Images.SetKeyName(10, "Formularios.png");
            this.imageList2.Images.SetKeyName(11, "lupa.png");
            // 
            // btn_Nuevo
            // 
            this.btn_Nuevo.Image = global::WINformulacion.Properties.Resources.Nuevo_16x16;
            this.btn_Nuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Nuevo.Name = "btn_Nuevo";
            this.btn_Nuevo.Size = new System.Drawing.Size(62, 22);
            this.btn_Nuevo.Text = "Nuevo";
            this.btn_Nuevo.Click += new System.EventHandler(this.btn_Nuevo_Click);
            // 
            // btn_Grabar
            // 
            this.btn_Grabar.Image = global::WINformulacion.Properties.Resources.Guardar_16x16;
            this.btn_Grabar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Grabar.Name = "btn_Grabar";
            this.btn_Grabar.Size = new System.Drawing.Size(62, 22);
            this.btn_Grabar.Text = "Grabar";
            this.btn_Grabar.Click += new System.EventHandler(this.btn_Grabar_Click);
            // 
            // btn_DesHacer
            // 
            this.btn_DesHacer.Image = global::WINformulacion.Properties.Resources.Undo_16x16;
            this.btn_DesHacer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_DesHacer.Name = "btn_DesHacer";
            this.btn_DesHacer.Size = new System.Drawing.Size(75, 22);
            this.btn_DesHacer.Text = "Deshacer";
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Image = global::WINformulacion.Properties.Resources.Eliminar_16x16;
            this.btn_Eliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(70, 22);
            this.btn_Eliminar.Text = "Eliminar";
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // Frm_Actualiza_Version
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grp_Catalogo);
            this.Controls.Add(this.UltraGroupBox3);
            this.Controls.Add(this.ToolStrip1);
            this.Name = "Frm_Actualiza_Version";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualiza Version";
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGroupBox3)).EndInit();
            this.UltraGroupBox3.ResumeLayout(false);
            this.UltraGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Version)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_Nota)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_NumDocumento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grp_Catalogo)).EndInit();
            this.grp_Catalogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_mvto_ListaVersiones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection16)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton btn_Nuevo;
        internal System.Windows.Forms.ToolStripButton btn_Grabar;
        internal System.Windows.Forms.ToolStripButton btn_DesHacer;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton btn_Eliminar;
        internal System.Windows.Forms.ToolStripButton btn_Listar;
        internal Infragistics.Win.Misc.UltraGroupBox UltraGroupBox3;
        internal gnUserControl.gnTextBox_Simple txt_Version;
        internal gnUserControl.gnEditBox edt_Nota;
        internal gnUserControl.gnTextBox_Simple txt_NumDocumento;
        internal gnUserControl.gnMaskedTextBox txt_AñoProceso;
        internal Infragistics.Win.Misc.UltraLabel UltraLabel10;
        internal Infragistics.Win.Misc.UltraLabel UltraLabel6;
        internal Infragistics.Win.Misc.UltraLabel UltraLabel5;
        internal gnUserControl.gnComboBox cbo_CodTipoDocumento;
        internal Infragistics.Win.Misc.UltraLabel UltraLabel4;
        internal Infragistics.Win.Misc.UltraLabel UltraLabel3;
        internal Infragistics.Win.Misc.UltraGroupBox grp_Catalogo;
        internal Infragistics.Win.UltraWinGrid.UltraGrid grd_mvto_ListaVersiones;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.Utils.ImageCollection imageCollection16;
        internal Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter UltraGridExcelExporter1;
        internal System.Windows.Forms.SaveFileDialog SaveDocumento;
        private System.Windows.Forms.ImageList imageList2;
    }
}