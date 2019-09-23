namespace WINformulacion
{
    partial class Frm_ActualizaFormulacion_Tarea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ActualizaFormulacion_Tarea));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Mnu_Proyecto = new System.Windows.Forms.ToolStripDropDownButton();
            this.Btn_Nuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_Guardar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.Btn_Imprimir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Mnu_Ayuda = new System.Windows.Forms.ToolStripDropDownButton();
            this.Btn_BuscaClasificador = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_DistribuyeLineaFormulada = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_MostarOrdenesPendientes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Btn_Pegar = new System.Windows.Forms.ToolStripButton();
            this.Btn_EliminarFilas = new System.Windows.Forms.ToolStripButton();
            this.spreadsheetControl = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            this.spreadsheetFormulaBar1 = new DevExpress.XtraSpreadsheet.SpreadsheetFormulaBar();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Mnu_Proyecto,
            this.toolStripSeparator1,
            this.Mnu_Ayuda,
            this.toolStripSeparator2,
            this.Btn_Pegar,
            this.Btn_EliminarFilas});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Mnu_Proyecto
            // 
            this.Mnu_Proyecto.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Btn_Nuevo,
            this.Btn_Guardar,
            this.toolStripMenuItem1,
            this.Btn_Imprimir});
            this.Mnu_Proyecto.Image = global::WINformulacion.Properties.Resources.Financiamiento32;
            this.Mnu_Proyecto.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Mnu_Proyecto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Mnu_Proyecto.Name = "Mnu_Proyecto";
            this.Mnu_Proyecto.Size = new System.Drawing.Size(80, 36);
            this.Mnu_Proyecto.Text = "Tarea";
            this.Mnu_Proyecto.Click += new System.EventHandler(this.Mnu_Proyecto_Click);
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.Image = global::WINformulacion.Properties.Resources.Nuevo32;
            this.Btn_Nuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(222, 38);
            this.Btn_Nuevo.Text = "&Nueva Tarea";
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click);
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.Enabled = false;
            this.Btn_Guardar.Image = global::WINformulacion.Properties.Resources.Guardar32;
            this.Btn_Guardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(222, 38);
            this.Btn_Guardar.Text = "&Guardar Tarea";
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(219, 6);
            // 
            // Btn_Imprimir
            // 
            this.Btn_Imprimir.Enabled = false;
            this.Btn_Imprimir.Image = global::WINformulacion.Properties.Resources.Imprimir32;
            this.Btn_Imprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Btn_Imprimir.Name = "Btn_Imprimir";
            this.Btn_Imprimir.Size = new System.Drawing.Size(222, 38);
            this.Btn_Imprimir.Text = "Im&primir Hoja de Trabajo";
            this.Btn_Imprimir.Click += new System.EventHandler(this.Btn_Imprimir_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // Mnu_Ayuda
            // 
            this.Mnu_Ayuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Btn_BuscaClasificador,
            this.Btn_DistribuyeLineaFormulada,
            this.Btn_MostarOrdenesPendientes});
            this.Mnu_Ayuda.Image = global::WINformulacion.Properties.Resources.Formulacion32;
            this.Mnu_Ayuda.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Mnu_Ayuda.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Mnu_Ayuda.Name = "Mnu_Ayuda";
            this.Mnu_Ayuda.Size = new System.Drawing.Size(86, 36);
            this.Mnu_Ayuda.Text = "Ayuda";
            // 
            // Btn_BuscaClasificador
            // 
            this.Btn_BuscaClasificador.Enabled = false;
            this.Btn_BuscaClasificador.Image = global::WINformulacion.Properties.Resources.Buscar32;
            this.Btn_BuscaClasificador.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Btn_BuscaClasificador.Name = "Btn_BuscaClasificador";
            this.Btn_BuscaClasificador.Size = new System.Drawing.Size(239, 38);
            this.Btn_BuscaClasificador.Text = "&Buscar Clasificador";
            this.Btn_BuscaClasificador.Click += new System.EventHandler(this.Btn_BuscaClasificador_Click);
            // 
            // Btn_DistribuyeLineaFormulada
            // 
            this.Btn_DistribuyeLineaFormulada.Enabled = false;
            this.Btn_DistribuyeLineaFormulada.Image = ((System.Drawing.Image)(resources.GetObject("Btn_DistribuyeLineaFormulada.Image")));
            this.Btn_DistribuyeLineaFormulada.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Btn_DistribuyeLineaFormulada.Name = "Btn_DistribuyeLineaFormulada";
            this.Btn_DistribuyeLineaFormulada.Size = new System.Drawing.Size(239, 38);
            this.Btn_DistribuyeLineaFormulada.Text = "&Distribuir Linea Formulada";
            this.Btn_DistribuyeLineaFormulada.Click += new System.EventHandler(this.Btn_DistribuyeLineaFormulada_Click);
            // 
            // Btn_MostarOrdenesPendientes
            // 
            this.Btn_MostarOrdenesPendientes.Enabled = false;
            this.Btn_MostarOrdenesPendientes.Image = global::WINformulacion.Properties.Resources.Lista32;
            this.Btn_MostarOrdenesPendientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Btn_MostarOrdenesPendientes.Name = "Btn_MostarOrdenesPendientes";
            this.Btn_MostarOrdenesPendientes.Size = new System.Drawing.Size(239, 38);
            this.Btn_MostarOrdenesPendientes.Text = "&Mostrar Ordenes Pendientes";
            this.Btn_MostarOrdenesPendientes.Click += new System.EventHandler(this.Btn_MostarOrdenesPendientes_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // Btn_Pegar
            // 
            this.Btn_Pegar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Pegar.Image")));
            this.Btn_Pegar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Btn_Pegar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btn_Pegar.Name = "Btn_Pegar";
            this.Btn_Pegar.Size = new System.Drawing.Size(73, 36);
            this.Btn_Pegar.Text = "Pegar";
            this.Btn_Pegar.Visible = false;
            this.Btn_Pegar.Click += new System.EventHandler(this.Btn_Pegar_Click);
            // 
            // Btn_EliminarFilas
            // 
            this.Btn_EliminarFilas.Enabled = false;
            this.Btn_EliminarFilas.Image = global::WINformulacion.Properties.Resources.Eliminar32;
            this.Btn_EliminarFilas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Btn_EliminarFilas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btn_EliminarFilas.Name = "Btn_EliminarFilas";
            this.Btn_EliminarFilas.Size = new System.Drawing.Size(86, 36);
            this.Btn_EliminarFilas.Text = "&Eliminar";
            this.Btn_EliminarFilas.Visible = false;
            this.Btn_EliminarFilas.Click += new System.EventHandler(this.Btn_EliminarFilas_Click);
            // 
            // spreadsheetControl
            // 
            this.spreadsheetControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spreadsheetControl.Location = new System.Drawing.Point(0, 63);
            this.spreadsheetControl.Name = "spreadsheetControl";
            this.spreadsheetControl.Options.Import.Csv.Encoding = ((System.Text.Encoding)(resources.GetObject("spreadsheetControl.Options.Import.Csv.Encoding")));
            this.spreadsheetControl.Options.Import.Txt.Encoding = ((System.Text.Encoding)(resources.GetObject("spreadsheetControl.Options.Import.Txt.Encoding")));
            this.spreadsheetControl.Size = new System.Drawing.Size(800, 387);
            this.spreadsheetControl.TabIndex = 5;
            this.spreadsheetControl.Text = "spreadsheetControl1";
            this.spreadsheetControl.SelectionChanged += new System.EventHandler(this.spreadsheetControl_SelectionChanged);
            this.spreadsheetControl.CellBeginEdit += new DevExpress.XtraSpreadsheet.CellBeginEditEventHandler(this.spreadsheetControl_CellBeginEdit);
            this.spreadsheetControl.CellValueChanged += new DevExpress.XtraSpreadsheet.CellValueChangedEventHandler(this.spreadsheetControl_CellValueChanged);
            this.spreadsheetControl.RowsRemoving += new DevExpress.Spreadsheet.RowsChangingEventHandler(this.spreadsheetControl_RowsRemoving);
            this.spreadsheetControl.RangeCopying += new DevExpress.Spreadsheet.RangeCopyingEventHandler(this.spreadsheetControl_RangeCopying);
            this.spreadsheetControl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.spreadsheetControl_KeyUp);
            // 
            // spreadsheetFormulaBar1
            // 
            this.spreadsheetFormulaBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.spreadsheetFormulaBar1.Location = new System.Drawing.Point(0, 39);
            this.spreadsheetFormulaBar1.MinimumSize = new System.Drawing.Size(0, 24);
            this.spreadsheetFormulaBar1.Name = "spreadsheetFormulaBar1";
            this.spreadsheetFormulaBar1.Size = new System.Drawing.Size(800, 24);
            this.spreadsheetFormulaBar1.SpreadsheetControl = this.spreadsheetControl;
            this.spreadsheetFormulaBar1.TabIndex = 4;
            // 
            // Frm_ActualizaFormulacion_Tarea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.spreadsheetControl);
            this.Controls.Add(this.spreadsheetFormulaBar1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Frm_ActualizaFormulacion_Tarea";
            this.ShowIcon = false;
            this.Text = "Formulación de Tareas";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton Mnu_Proyecto;
        private System.Windows.Forms.ToolStripMenuItem Btn_Nuevo;
        private System.Windows.Forms.ToolStripMenuItem Btn_Guardar;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem Btn_Imprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton Mnu_Ayuda;
        private System.Windows.Forms.ToolStripMenuItem Btn_BuscaClasificador;
        private System.Windows.Forms.ToolStripMenuItem Btn_DistribuyeLineaFormulada;
        private System.Windows.Forms.ToolStripMenuItem Btn_MostarOrdenesPendientes;
        private DevExpress.XtraSpreadsheet.SpreadsheetControl spreadsheetControl;
        private DevExpress.XtraSpreadsheet.SpreadsheetFormulaBar spreadsheetFormulaBar1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton Btn_EliminarFilas;
        private System.Windows.Forms.ToolStripButton Btn_Pegar;
    }
}