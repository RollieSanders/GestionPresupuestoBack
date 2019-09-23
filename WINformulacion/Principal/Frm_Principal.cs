using Microsoft.Win32;
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.Xml.Schema;

//using Infragistics.UltraChart.Resources.Appearance;
//using Infragistics.UltraChart.Shared.Styles;
using Infragistics.Win.UltraWinExplorerBar;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinToolbars;
using Microsoft.VisualBasic;

namespace WINformulacion
{
	public class Frm_Principal : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private Infragistics.Win.Misc.UltraButton btnLaunch;
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar ultraExplorerBar1;
		private Infragistics.Win.UltraWinDock.UltraDockManager ultraDockManager1;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _Form1UnpinnedTabAreaLeft;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _Form1UnpinnedTabAreaRight;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _Form1UnpinnedTabAreaTop;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _Form1UnpinnedTabAreaBottom;
		private Infragistics.Win.UltraWinDock.AutoHideControl _Form1AutoHideControl;
		private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea2;
		private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow1;
		private Infragistics.Win.UltraWinTabbedMdi.UltraTabbedMdiManager ultraTabbedMdiManager1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Form1_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Form1_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Form1_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Form1_Toolbars_Dock_Area_Bottom;
		private System.Windows.Forms.ImageList imageListExplorerBar;
		private System.Windows.Forms.ImageList imageListTreeView;
        internal Infragistics.Win.UltraWinStatusBar.UltraStatusBar USB_Barra;
        private System.ComponentModel.IContainer components;

        #region "Variables Iniciales"
        //private SRmate.WCFmateEClient objService = new SRmate.WCFmateEClient();
        const int LargeImageIndexOpen = 0;
        const int LargeImageIndexNew = 1;
        const int LargeImageIndexClose = 2;
        const int LargeImageIndexSave = 3;
        const int LargeImageIndexSaveAs = 4;
        const int LargeImageIndexPaste = 5;
        const int LargeImageIndexFirstChart = 6;
        private DataSet Ds_cnfg_Opciones = new DataSet();
        DataTable Dt_Modulo = new DataTable();
        DataTable Dt_SubModulo = new DataTable();
        DataView Dv_SubModulo = new DataView();
        DataTable Dt_Grupo = new DataTable();
        DataView Dv_Grupo = new DataView();
        DataTable Dt_Opciones = new DataTable();
        DataView Dv_Opciones = new DataView();
        DataTable Dt_SubOpciones = new DataTable();
        DataView Dv_SubOpciones = new DataView();
        DataSet dsModulo = new DataSet();
        DataTable dtModulo = new DataTable();
        DataTable dtSubModulo = new DataTable();
        DataTable dtGrupo = new DataTable();
        DataTable dtOpcion = new DataTable();
        string[] datos = { "0", "0" };
        string strLogUsuario = "";
        string strCodModulo = "";
        internal ImageList ImageList1;
        private string strCodempresa = "";
        private string strCodEmpleado = "";
        internal ImageList ilLarge;
        DataTable menuTable = new DataTable("Menu");

        #endregion

        private SRformulacion.WCFformulacionEClient objWCF = new SRformulacion.WCFformulacionEClient();

        public Frm_Principal()
		{
			InitializeComponent();
		}

        public void ShowMe(string strCodUsuario, 
                            string cCodModulo, 
                            string cLogUsuario,
                            string cCodEmpresa, 
                            string strNomEmpresa, 
                            string strAñoProceso
                          )
        {
            strCodempresa = cCodEmpresa;
            strCodModulo = cCodModulo;
            strLogUsuario = cLogUsuario;

            Service.Usuario objSU = new Service.Usuario();
            Model.Usuario objMU = new Model.Usuario();

            Service.Empleado objSE = new Service.Empleado();
            Model.Empleado objME = new Model.Empleado();

            if (MyStuff.UsaWCF == true)
            {
                objMU = objWCF.Recupera_Usuario_Codigo(strCodempresa, strLogUsuario);
            }
            else
            {
                objMU = objSU.Recupera_Usuario_Codigo(strCodempresa, strLogUsuario);
            }
                
            strCodEmpleado = objMU.cCodEmpleado;

            if (MyStuff.UsaWCF == true)
            {
                objME = objWCF.Recupera_Empleado_Codigo(objMU.cCodEmpleado);
            }
            else
            {
                objME = objSE.Recupera_Empleado_Codigo(objMU.cCodEmpleado);
            }
                

            MyStuff.CodigoEmpleado = strCodEmpleado;
            MyStuff.CodigoCentroGestor = objME.CCodCentroGestor;
            MyStuff.CodigoCentroCosto = objME.CCodCentroCosto;
            MyStuff.AñoProceso = strAñoProceso;
            MyStuff.DigitoCentroGestor = objME.Idigito;


            this.USB_Barra.Panels[0].Text = objMU.vDesEmpleado;
            this.USB_Barra.Panels[1].Text = strNomEmpresa;
            this.USB_Barra.Panels[2].Text = "Año:" + strAñoProceso;
            this.USB_Barra.Panels[3].Text = "CeCo:" + objME.VNomCentroCosto;
            this.USB_Barra.Panels[4].Text = "CeGe:" + objME.VNomCentroGestor;
            if ( MyStuff.UsaWCF == true  )
            {
                this.USB_Barra.Panels[5].Text = "Conexion: Remota";
            }
            else
            {
                this.USB_Barra.Panels[5].Text = "Conexion: Local";
            }



            CreaTablaMenu();
            CargarCabeceraRibbon();
            CargarBarraLateral();
            this.Show();
        }

        private void samplestree_AfterSelect(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e)
        {
            //bool blnProcesaDatosPersonal = false;
            string strPrograma = e.NewSelections[0].Tag.ToString();
            if (strPrograma.Trim() != "")
            {
                //strPrograma = strPrograma;
                try
                {
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.GetType().ToString() == strPrograma)
                        {
                            f.Show();
                            f.Focus();
                            return;
                        }
                    }

                    System.Type t = System.Type.GetType(strPrograma.Replace("WinGaugeSamplesExplorerCS", "WinGaugeSamplesExplorerVB"), true);
                    System.Windows.Forms.Form sample = ((System.Windows.Forms.Form)System.Activator.CreateInstance(t, true));
                    sample.MdiParent = this;
                    sample.Show();
                }
                catch (Exception)
                {
                }
            }
        }   //samplestree_AfterSelect

        protected void ClickOnTools(System.Object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {


            string strCodigo = e.Tool.Key;

            string strFormulario = "";
            string strParametro = "";

            DataRow dr;
            dr = menuTable.Rows.Find(strCodigo);
            if (dr != null)
            {
                strFormulario = "WINformulacion." + Convert.ToString(dr[1]).Trim();
                //strFormulario = Convert.ToString(dr[1]).Trim();

                if (Convert.ToString(dr[2]).Trim() != "")
                {
                    strParametro = Convert.ToString(dr[2]).Trim();
                }
            }


            //bool blnProcesaDatosPersonal = false;
            string strPrograma = strFormulario;

            //Esto tiene que ser una variable publica----- strCodTipoFormulacion_Publico = strParametro;

            if (strPrograma.Trim() != "")
            {
                try
                {

                    foreach (Form  f in this.MdiChildren)
                    {
                        if (f.GetType().ToString() == strPrograma)
                        {
                            f.Show();
                            f.Focus();
                            return;
                        }
                    }

                    //Dim formulario As Form
                    //Dim tipoObjeto As Type = Type.GetType(strPrograma)
                    //Dim parametros() As Object = {strParametro}
                    //'fijate que al ser object, puedes meter cualquier objeto y no sólo cádenas como en el ejemplo
                    //Dim objeto As Object = Activator.CreateInstance(tipoObjeto, parametros)
                    //formulario = DirectCast(objeto, Form)
                    //formulario.Show()


                    System.Type t = System.Type.GetType(strPrograma);
                    object[] parametros = { strParametro };
                    Form sample = ((Form)System.Activator.CreateInstance(t, true));
                    sample.MdiParent = this;

                    sample.Show();


                }
                catch 
                {
                   
                }
            }
        }

        internal void OrdenarTablas()
        {

            Dt_Modulo = Ds_cnfg_Opciones.Tables[0];

            Dt_SubModulo = Ds_cnfg_Opciones.Tables[1];
            Dv_SubModulo = Dt_SubModulo.DefaultView;

            Dt_Grupo = Ds_cnfg_Opciones.Tables[2];
            Dv_Grupo = Dt_Grupo.DefaultView;

            Dt_Opciones = Ds_cnfg_Opciones.Tables[3];
            Dv_Opciones = Dt_Opciones.DefaultView;

            Dt_SubOpciones = Ds_cnfg_Opciones.Tables[4];
            Dv_SubOpciones = Dt_SubOpciones.DefaultView;

            //string strEsquema = "";

        }

        private void CargarBarraLateral()
        {
            UltraExplorerBarContainerControl container = new UltraExplorerBarContainerControl();
            this.ultraExplorerBar1.Controls.Add(container);
            UltraTree samplestree = new UltraTree();
            samplestree.Dock = DockStyle.Fill;

            samplestree.AfterSelect += new Infragistics.Win.UltraWinTree.AfterNodeSelectEventHandler(this.samplestree_AfterSelect);

            samplestree.NodeConnectorStyle = NodeConnectorStyle.None;
            samplestree.Override.ActiveNodeAppearance.BackColor = Color.DarkBlue;
            samplestree.Override.ActiveNodeAppearance.ForeColor = Color.Yellow;
            samplestree.Override.ActiveNodeAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
            samplestree.Override.NodeAppearance.ImageBackgroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel;

            container.Controls.Add(samplestree);

            if (MyStuff.UsaWCF == true)
            {
                Ds_cnfg_Opciones = objWCF.OpcionesMenu_Lateral(strCodempresa, strLogUsuario, strCodModulo);
            }
            else
            {
                Service.Usuario objSU = new Service.Usuario();
                Ds_cnfg_Opciones = objSU.OpcionesMenu_Lateral(strCodempresa, strLogUsuario, strCodModulo);
            }
            

            //Ds_cnfg_Opciones = objService.opcionesMenu_Lateral(strLogUsuario, strCodModulo);

            //DataRow dr_Modulo;
            //DataRowView dr_SubModulo;
            //DataRowView dr_Grupo;
            //DataRowView dr_Opciones;
            //DataRowView dr_SubOpciones;
            string strFiltroModulo = "";
            string strFiltroSubModulo = "";
            string strFiltroGrupo = "";
            string strFiltroOpciones = "";
            string strFiltroSubOpciones = "";

            OrdenarTablas();


            foreach (DataRow dr_Modulo in this.Dt_Modulo.Rows)
            {
                //
                // Modulos
                //

                strFiltroModulo = Convert.ToString(dr_Modulo["cCodModulo"]);
                this.Dv_SubModulo.RowFilter = "cCodModulo = " + strFiltroModulo;



                UltraExplorerBarGroup group = new UltraExplorerBarGroup();
                group.Text = Convert.ToString(dr_Modulo["vDesModulo"]);
                group.Key = strFiltroModulo;

                group.Settings.Style = GroupStyle.ControlContainer;
                group.Container = container;
                group.Tag = "";
                this.ultraExplorerBar1.Groups.Add(group);

                //bool blnExpandedProducts = true;


                foreach (DataRowView dr_SubModulo in this.Dv_SubModulo)
                {
                    strFiltroSubModulo = Convert.ToString(dr_SubModulo["cCodsubModulo"]);

                    UltraTreeNode productnode = new UltraTreeNode(strFiltroModulo.TrimEnd() + "_" + 
                                                                  strFiltroSubModulo.TrimEnd(), 
                                                                  Convert.ToString(dr_SubModulo["vDesSubModulo"] ).TrimEnd()
                                                                 );
                    productnode.LeftImages.Add(this.imageListTreeView.Images[1]);
                    productnode.Expanded = true;
                    productnode.Override.NodeAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;

                    productnode.Tag = "";
                    samplestree.Nodes.Add(productnode);

                    this.Dv_Grupo.RowFilter = "cCodModulo =" + strFiltroModulo + " And " + "cCodSubModulo=" + strFiltroSubModulo;

                    foreach (DataRowView dr_Grupo in this.Dv_Grupo)
                    {
                        //
                        // Grupos
                        //
                        strFiltroGrupo = Convert.ToString(dr_Grupo["cCodGrupo"]);

                        this.Dv_Opciones.RowFilter = "cCodModulo =" + strFiltroModulo + " And " + "cCodSubModulo=" + strFiltroSubModulo + " and " + "cCodGrupo=" + strFiltroGrupo;

                        UltraTreeNode categorynode = new UltraTreeNode(strFiltroModulo.TrimEnd() + "_" + 
                                                                       strFiltroSubModulo.TrimEnd() + "_" + 
                                                                       strFiltroGrupo.TrimEnd(), 
                                                                       Convert.ToString(dr_Grupo["vDesGrupo"]).TrimEnd()
                                                                       );
                        categorynode.Override.NodeAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;

                        categorynode.Tag = "";
                        productnode.Nodes.Add(categorynode);

                        foreach (DataRowView dr_Opciones in this.Dv_Opciones)
                        {
                            strFiltroOpciones = Convert.ToString(dr_Opciones["cCodOpcion"]);
                            UltraTreeNode samplenode = new UltraTreeNode(strFiltroModulo.TrimEnd() + "_" + 
                                                                         strFiltroSubModulo.TrimEnd() + "_" + 
                                                                         strFiltroGrupo.TrimEnd() + "_" + 
                                                                         strFiltroOpciones, Convert.ToString(dr_Opciones["vDesOpcion"]).TrimEnd()
                                                                         );

                            this.Dv_SubOpciones.RowFilter = "cCodModulo =" + strFiltroModulo + " And " + "cCodSubModulo=" + strFiltroSubModulo + " and " + "cCodGrupo=" + strFiltroGrupo + " and " + "cCodOpcion=" + strFiltroOpciones;

                            if (this.Dv_SubOpciones.Count > 0)
                            {
                                if (!(this.imageListTreeView.Images[1] == null))
                                {
                                    samplenode.LeftImages.Add(this.imageListTreeView.Images[1]);
                                }
                                samplenode.Tag = "";
                                categorynode.Nodes.Add(samplenode);

                                foreach (DataRowView  dr_SubOpciones in this.Dv_SubOpciones)
                                {
                                    strFiltroSubOpciones = Convert.ToString(dr_SubOpciones["cCodSubOpcion"]);
                                    UltraTreeNode samplenode1 = new UltraTreeNode(strFiltroModulo.TrimEnd() + "_" + 
                                                                                  strFiltroSubModulo.TrimEnd() + "_" + 
                                                                                  strFiltroGrupo.TrimEnd() + "_" + 
                                                                                  strFiltroOpciones.TrimEnd() + "_" + 
                                                                                  strFiltroSubOpciones.TrimEnd(), 
                                                                                  Convert.ToString(dr_SubOpciones["vDesSubOpcion"]).TrimEnd()
                                                                                  );

                                    if (!(this.imageListTreeView.Images[0] == null))
                                    {
                                        samplenode1.LeftImages.Add(this.imageListTreeView.Images[0]);
                                    }
                                    samplenode1.Tag = "WINformulacion." +  Convert.ToString(dr_SubOpciones["vDesFormulario"]);
                                    samplenode.Nodes.Add(samplenode1);
                                }
                            }
                            else
                            {
                                if (!(this.imageListTreeView.Images[0] == null))
                                {
                                    samplenode.LeftImages.Add(this.imageListTreeView.Images[0]);
                                }
                                samplenode.Tag = "WINformulacion." + Convert.ToString(dr_Opciones["vDesFormulario"]);
                                categorynode.Nodes.Add(samplenode);
                            }
                        }
                    }
                }
            }
        }
        private void CreaTablaMenu()
        {
            DataColumn menuCol = menuTable.Columns.Add("Codigo", Type.GetType("System.String"));
            menuCol.AllowDBNull = false;
            menuCol.Unique = true;
            menuTable.Columns.Add("Formulario", Type.GetType("System.String"));
            menuTable.Columns.Add("Parametro", Type.GetType("System.String"));
            menuTable.PrimaryKey = new DataColumn[] { menuTable.Columns["Codigo"] };
        }

        private void CargarCabeceraRibbon()
        {
            //
            // Imprimir la Cabecera
            //

            //create the new explorerbar group and assign the container to it
            //
            // Imprimir las opciones
            //


            if (MyStuff.UsaWCF == true)
            {
                Ds_cnfg_Opciones = objWCF.OpcionesMenu_Top(strCodempresa, strLogUsuario, strCodModulo);
            }
            else
            {
                Service.Usuario objSU = new Service.Usuario();
                Ds_cnfg_Opciones = objSU.OpcionesMenu_Top(strCodempresa, strLogUsuario, strCodModulo);
            }

            

            //Ds_cnfg_Opciones = objService.opcionesMenu_Top( strCodempresa, strLogUsuario, strCodModulo);

            //DataRow dr_Modulo;
            //DataRowView dr_SubModulo;
            //DataRowView dr_Grupo;
            //DataRowView dr_Opciones;
            //DataRowView dr_SubOpciones;
            string strFiltroModulo = "";
            string strFiltroSubModulo = "";
            string strFiltroGrupo = "";
            string strFiltroOpciones = "";
            string strFiltroSubOpciones = "";


            OrdenarTablas();


            foreach (DataRow dr_Modulo in this.Dt_Modulo.Rows)
            {
                strFiltroModulo = Convert.ToString(dr_Modulo["cCodModulo"]);
                this.Dv_SubModulo.RowFilter = "cCodModulo = " + strFiltroModulo;

                this.Text = Convert.ToString(dr_Modulo["vDesModulo"]);
                //LoadImage();
                this.ultraToolbarsManager1.BeginUpdate();
                this.ultraToolbarsManager1.ImageListLarge = this.ImageList1;
                this.ultraToolbarsManager1.ImageListSmall = this.ImageList1;

                foreach (DataRowView dr_SubModulo in this.Dv_SubModulo)
                {

                    //
                    // Sub - Modulos
                    //
                    strFiltroSubModulo = Convert.ToString(dr_SubModulo["cCodsubModulo"]);

                    RibbonTab tab = ultraToolbarsManager1.Ribbon.Tabs.Add(Convert.ToString(dr_SubModulo["cCodsubModulo"]));
                    tab.Caption = Convert.ToString(dr_SubModulo["vDesSubModulo"]);

                    this.Dv_Grupo.RowFilter = "cCodModulo =" + strFiltroModulo + " And " + 
                                              "cCodSubModulo=" + strFiltroSubModulo;

                    foreach (DataRowView dr_Grupo in this.Dv_Grupo)
                    {
                        //
                        // Grupos
                        //
                        strFiltroGrupo = Convert.ToString(dr_Grupo["cCodGrupo"]);

                        this.Dv_Opciones.RowFilter = "cCodModulo =" + strFiltroModulo + " And " +
                                                     "cCodSubModulo=" + strFiltroSubModulo + " and " +
                                                     "cCodGrupo=" + strFiltroGrupo;

                        RibbonGroup groupWithLargeTools = tab.Groups.Add(Convert.ToString(dr_Grupo["cCodGrupo"]));
                        groupWithLargeTools.Caption = Convert.ToString(dr_Grupo["vDesGrupo"]);
                        foreach (DataRowView  dr_Opciones in this.Dv_Opciones)
                        {
                            strFiltroOpciones = Convert.ToString(dr_Opciones["cCodOpcion"]);

                            this.Dv_SubOpciones.RowFilter = "cCodModulo =" + strFiltroModulo + " And " +
                                                            "cCodSubModulo=" + strFiltroSubModulo + " and " +
                                                            "cCodGrupo=" + strFiltroGrupo + " and " +
                                                            "cCodOpcion=" + strFiltroOpciones;

                            int intNumeroImagen = 0;
                            bool blnEsInicioGrupo = false;

                            if (this.Dv_SubOpciones.Count > 0)
                            {
                                PopupMenuTool boton = new PopupMenuTool(Convert.ToString(dr_Opciones["cCodOpcion"]));
                                boton.SharedProps.Caption = Convert.ToString(dr_Opciones["vDesOpcion"]);
                                intNumeroImagen = Convert.ToInt32(dr_Opciones["iNumeroImagen"]);
                                blnEsInicioGrupo = Convert.ToBoolean(dr_Opciones["bEsInicioGrupo"]);
                                if (!this.ultraToolbarsManager1.Tools.Exists(boton.Key))
                                {
                                    this.ultraToolbarsManager1.Tools.Add(boton);
                                    ToolBase tool = groupWithLargeTools.Tools.AddTool(Convert.ToString(dr_Opciones["cCodOpcion"]));
                                    tool.InstanceProps.PreferredSizeOnRibbon = RibbonToolSize.Large;
                                    tool.InstanceProps.IsFirstInGroup = blnEsInicioGrupo;
                                    tool.SharedProps.AppearancesLarge.Appearance.Image = ilLarge.Images[intNumeroImagen];
                                }

                                foreach (DataRowView dr_SubOpciones in this.Dv_SubOpciones)
                                {
                                    strFiltroSubOpciones = Convert.ToString(dr_SubOpciones["cCodSubOpcion"]);
                                    StateButtonTool subboton = new StateButtonTool(strFiltroSubOpciones);
                                    intNumeroImagen = Convert.ToInt32(dr_SubOpciones["iNumeroImagen"]);
                                    blnEsInicioGrupo = Convert.ToBoolean(dr_SubOpciones["bEsInicioGrupo"]);
                                    subboton.SharedProps.Caption = Convert.ToString(dr_SubOpciones["vDesSubOpcion"]);

                                    if (!this.ultraToolbarsManager1.Tools.Exists(subboton.Key))
                                    {
                                        this.ultraToolbarsManager1.Tools.Add(subboton);
                                        ToolBase tool = boton.Tools.AddTool(strFiltroSubOpciones);
                                        //'tool.Tag = CStr(dr_SubOpciones("vDesFormulario")).Trim
                                        AñadeRegistroMenu(Convert.ToString(dr_SubOpciones["cCodsubOpcion"]), Convert.ToString(dr_SubOpciones["vDesFormulario"]).Trim());
                                        tool.InstanceProps.PreferredSizeOnRibbon = RibbonToolSize.Default;
                                        tool.InstanceProps.IsFirstInGroup = blnEsInicioGrupo;

                                        tool.SharedProps.AppearancesSmall.Appearance.Image = ilLarge.Images[intNumeroImagen];
                                        //tool.ToolClick += new /* TODO: Comprobar el tipo de delegado */ EventHandler(ClickOnTools);
                                        tool.ToolClick += new ToolClickEventHandler(ClickOnTools);

                                        //AddHandler tool.ToolClick, AddressOf ClickOnTools;
                                    }
                                }
                            }
                            else
                            {
                                ButtonTool boton = new ButtonTool(Convert.ToString(dr_Opciones["cCodOpcion"]));
                                boton.SharedProps.Caption = Convert.ToString(dr_Opciones["vDesOpcion"]);
                                intNumeroImagen = Convert.ToInt32(dr_Opciones["iNumeroImagen"]);
                                blnEsInicioGrupo = Convert.ToBoolean(dr_Opciones["bEsInicioGrupo"]);
                                if (!this.ultraToolbarsManager1.Tools.Exists(boton.Key))
                                {
                                    this.ultraToolbarsManager1.Tools.Add(boton);
                                    ToolBase tool = groupWithLargeTools.Tools.AddTool(Convert.ToString(dr_Opciones["cCodOpcion"]));
                                    //'tool.Tag = "Formulacion." & CStr(dr_Opciones("vDesFormulario")).Trim
                                    //'tool.Tag = CStr(dr_Opciones("vDesFormulario")).Trim
                                    AñadeRegistroMenu(Convert.ToString(dr_Opciones["cCodOpcion"]), Convert.ToString(dr_Opciones["vDesFormulario"]).Trim());
                                    tool.InstanceProps.PreferredSizeOnRibbon = RibbonToolSize.Large;
                                    tool.InstanceProps.IsFirstInGroup = blnEsInicioGrupo;
                                    if ( intNumeroImagen < ilLarge.Images.Count)
                                    {
                                        tool.SharedProps.AppearancesLarge.Appearance.Image = ilLarge.Images[intNumeroImagen];
                                    }
                                    
                                    //tool.ToolClick += new /* TODO: Comprobar el tipo de delegado */ EventHandler(ClickOnTools);
                                    tool.ToolClick += new ToolClickEventHandler(ClickOnTools);
                                }
                            }
                        }
                    }
                }
            }
            this.ultraToolbarsManager1.EndUpdate();
        }

        private void AñadeRegistroMenu(string strCodigo, string strFormulario)
        {
            int TestPos = 0;
            string strParametro = "";
            int intLongitud = strFormulario.Trim().Length;
            TestPos = strFormulario.IndexOf("@"); //  InStr(strFormulario, "@");
            if (TestPos > 0)
            {
                strParametro = strFormulario.Trim().Substring(TestPos, intLongitud - TestPos);
                strFormulario = strFormulario.Trim().Substring(0, TestPos - 1);
            }
            DataRow contactoRow;
            contactoRow = menuTable.NewRow();
            contactoRow["Codigo"] = strCodigo;
            contactoRow["Formulario"] = strFormulario;
            contactoRow["Parametro"] = strParametro;
            menuTable.Rows.Add(contactoRow);

        }

        protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
	
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Principal));
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("d9f71001-af1e-4005-b53c-a329bd7cabe6"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("f8a7d748-8373-4d71-8f5e-8ae70ffc69cd"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("d9f71001-af1e-4005-b53c-a329bd7cabe6"), -1);
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MainMenu");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Exit");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Exit");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Window");
            Infragistics.Win.UltraWinToolbars.MdiWindowListTool mdiWindowListTool1 = new Infragistics.Win.UltraWinToolbars.MdiWindowListTool("WindowList");
            Infragistics.Win.UltraWinToolbars.MdiWindowListTool mdiWindowListTool2 = new Infragistics.Win.UltraWinToolbars.MdiWindowListTool("WindowList");
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance Appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance Appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance Appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel5 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel6 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            this.ultraExplorerBar1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.imageListExplorerBar = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLaunch = new Infragistics.Win.Misc.UltraButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.ultraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._Form1UnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._Form1UnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._Form1UnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._Form1UnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._Form1AutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.dockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.ultraTabbedMdiManager1 = new Infragistics.Win.UltraWinTabbedMdi.UltraTabbedMdiManager(this.components);
            this._Form1_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._Form1_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Form1_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Form1_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.imageListTreeView = new System.Windows.Forms.ImageList(this.components);
            this.USB_Barra = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ilLarge = new System.Windows.Forms.ImageList(this.components);
            this.windowDockingArea2 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExplorerBar1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDockManager1)).BeginInit();
            this._Form1AutoHideControl.SuspendLayout();
            this.dockableWindow1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraExplorerBar1
            // 
            this.ultraExplorerBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ultraExplorerBar1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraExplorerBar1.ImageListLarge = this.imageListExplorerBar;
            this.ultraExplorerBar1.Location = new System.Drawing.Point(0, 25);
            this.ultraExplorerBar1.Name = "ultraExplorerBar1";
            this.ultraExplorerBar1.Size = new System.Drawing.Size(321, 327);
            this.ultraExplorerBar1.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.OutlookNavigationPane;
            this.ultraExplorerBar1.TabIndex = 5;
            this.ultraExplorerBar1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // imageListExplorerBar
            // 
            this.imageListExplorerBar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListExplorerBar.ImageStream")));
            this.imageListExplorerBar.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListExplorerBar.Images.SetKeyName(0, "");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLaunch);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 3;
            // 
            // btnLaunch
            // 
            this.btnLaunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaunch.Location = new System.Drawing.Point(0, 0);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(75, 23);
            this.btnLaunch.TabIndex = 2;
            this.btnLaunch.Text = "Launch Sample";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(100, 96);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "richTextBox1";
            // 
            // ultraDockManager1
            // 
            dockAreaPane1.ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.TabGroup;
            dockableControlPane1.Control = this.ultraExplorerBar1;
            dockableControlPane1.FlyoutSize = new System.Drawing.Size(321, -1);
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(0, 0, 236, 414);
            dockableControlPane1.Pinned = false;
            dockableControlPane1.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            appearance1.FontData.SizeInPoints = 7.75F;
            dockableControlPane1.Settings.CaptionAppearance = appearance1;
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "Módulos";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.True;
            dockAreaPane1.Size = new System.Drawing.Size(321, 352);
            this.ultraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1});
            this.ultraDockManager1.HostControl = this;
            this.ultraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2003;
            // 
            // _Form1UnpinnedTabAreaLeft
            // 
            this._Form1UnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._Form1UnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Form1UnpinnedTabAreaLeft.Location = new System.Drawing.Point(4, 51);
            this._Form1UnpinnedTabAreaLeft.Name = "_Form1UnpinnedTabAreaLeft";
            this._Form1UnpinnedTabAreaLeft.Owner = this.ultraDockManager1;
            this._Form1UnpinnedTabAreaLeft.Size = new System.Drawing.Size(21, 352);
            this._Form1UnpinnedTabAreaLeft.TabIndex = 6;
            // 
            // _Form1UnpinnedTabAreaRight
            // 
            this._Form1UnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._Form1UnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Form1UnpinnedTabAreaRight.Location = new System.Drawing.Point(672, 51);
            this._Form1UnpinnedTabAreaRight.Name = "_Form1UnpinnedTabAreaRight";
            this._Form1UnpinnedTabAreaRight.Owner = this.ultraDockManager1;
            this._Form1UnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 352);
            this._Form1UnpinnedTabAreaRight.TabIndex = 7;
            // 
            // _Form1UnpinnedTabAreaTop
            // 
            this._Form1UnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._Form1UnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Form1UnpinnedTabAreaTop.Location = new System.Drawing.Point(25, 51);
            this._Form1UnpinnedTabAreaTop.Name = "_Form1UnpinnedTabAreaTop";
            this._Form1UnpinnedTabAreaTop.Owner = this.ultraDockManager1;
            this._Form1UnpinnedTabAreaTop.Size = new System.Drawing.Size(647, 0);
            this._Form1UnpinnedTabAreaTop.TabIndex = 8;
            // 
            // _Form1UnpinnedTabAreaBottom
            // 
            this._Form1UnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._Form1UnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Form1UnpinnedTabAreaBottom.Location = new System.Drawing.Point(25, 403);
            this._Form1UnpinnedTabAreaBottom.Name = "_Form1UnpinnedTabAreaBottom";
            this._Form1UnpinnedTabAreaBottom.Owner = this.ultraDockManager1;
            this._Form1UnpinnedTabAreaBottom.Size = new System.Drawing.Size(647, 0);
            this._Form1UnpinnedTabAreaBottom.TabIndex = 9;
            // 
            // _Form1AutoHideControl
            // 
            this._Form1AutoHideControl.Controls.Add(this.dockableWindow1);
            this._Form1AutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Form1AutoHideControl.Location = new System.Drawing.Point(25, 51);
            this._Form1AutoHideControl.Name = "_Form1AutoHideControl";
            this._Form1AutoHideControl.Owner = this.ultraDockManager1;
            this._Form1AutoHideControl.Size = new System.Drawing.Size(16, 352);
            this._Form1AutoHideControl.TabIndex = 10;
            // 
            // dockableWindow1
            // 
            this.dockableWindow1.Controls.Add(this.ultraExplorerBar1);
            this.dockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.dockableWindow1.Name = "dockableWindow1";
            this.dockableWindow1.Owner = this.ultraDockManager1;
            this.dockableWindow1.Size = new System.Drawing.Size(321, 352);
            this.dockableWindow1.TabIndex = 35;
            // 
            // ultraTabbedMdiManager1
            // 
            this.ultraTabbedMdiManager1.MdiParent = this;
            this.ultraTabbedMdiManager1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ultraTabbedMdiManager1.ViewStyle = Infragistics.Win.UltraWinTabbedMdi.ViewStyle.VisualStudio2005;
            // 
            // _Form1_Toolbars_Dock_Area_Left
            // 
            this._Form1_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form1_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._Form1_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._Form1_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form1_Toolbars_Dock_Area_Left.InitialResizeAreaExtent = 4;
            this._Form1_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 51);
            this._Form1_Toolbars_Dock_Area_Left.Name = "_Form1_Toolbars_Dock_Area_Left";
            this._Form1_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(4, 352);
            this._Form1_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ultraToolbarsManager1
            // 
            this.ultraToolbarsManager1.DesignerFlags = 1;
            this.ultraToolbarsManager1.DockWithinContainer = this;
            this.ultraToolbarsManager1.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.ultraToolbarsManager1.Ribbon.Visible = true;
            this.ultraToolbarsManager1.ShowFullMenusDelay = 500;
            this.ultraToolbarsManager1.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2007;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.IsMainMenuBar = true;
            ultraToolbar1.Text = "MainMenu";
            this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            popupMenuTool3.SharedProps.Caption = "&File";
            popupMenuTool3.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1});
            buttonTool2.SharedProps.Caption = "E&xit";
            popupMenuTool4.SharedProps.Caption = "&Window";
            popupMenuTool4.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            mdiWindowListTool1});
            mdiWindowListTool2.SharedProps.Caption = "WindowList";
            this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool3,
            buttonTool2,
            popupMenuTool4,
            mdiWindowListTool2});
            this.ultraToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager1_ToolClick);
            // 
            // _Form1_Toolbars_Dock_Area_Right
            // 
            this._Form1_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form1_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._Form1_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._Form1_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form1_Toolbars_Dock_Area_Right.InitialResizeAreaExtent = 4;
            this._Form1_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(672, 51);
            this._Form1_Toolbars_Dock_Area_Right.Name = "_Form1_Toolbars_Dock_Area_Right";
            this._Form1_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(4, 352);
            this._Form1_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _Form1_Toolbars_Dock_Area_Top
            // 
            this._Form1_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form1_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._Form1_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._Form1_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form1_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._Form1_Toolbars_Dock_Area_Top.Name = "_Form1_Toolbars_Dock_Area_Top";
            this._Form1_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(676, 51);
            this._Form1_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _Form1_Toolbars_Dock_Area_Bottom
            // 
            this._Form1_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form1_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._Form1_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._Form1_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form1_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 403);
            this._Form1_Toolbars_Dock_Area_Bottom.Name = "_Form1_Toolbars_Dock_Area_Bottom";
            this._Form1_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(676, 0);
            this._Form1_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // imageListTreeView
            // 
            this.imageListTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTreeView.ImageStream")));
            this.imageListTreeView.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTreeView.Images.SetKeyName(0, "");
            this.imageListTreeView.Images.SetKeyName(1, "");
            // 
            // USB_Barra
            // 
            this.USB_Barra.Location = new System.Drawing.Point(0, 403);
            this.USB_Barra.Name = "USB_Barra";
            Appearance15.FontData.BoldAsString = "True";
            ultraStatusPanel1.Appearance = Appearance15;
            ultraStatusPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4Thick;
            ultraStatusPanel1.Key = "Key_User";
            ultraStatusPanel1.Width = 250;
            ultraStatusPanel1.WrapText = Infragistics.Win.DefaultableBoolean.False;
            Appearance16.FontData.BoldAsString = "True";
            ultraStatusPanel2.Appearance = Appearance16;
            ultraStatusPanel2.Key = "Key_Crp";
            ultraStatusPanel2.Width = 180;
            Appearance17.FontData.BoldAsString = "True";
            ultraStatusPanel3.Appearance = Appearance17;
            ultraStatusPanel3.Key = "Key_Con";
            appearance2.FontData.BoldAsString = "True";
            ultraStatusPanel4.Appearance = appearance2;
            ultraStatusPanel4.Key = "Key_CentroCosto";
            ultraStatusPanel4.Width = 350;
            appearance13.FontData.BoldAsString = "True";
            ultraStatusPanel5.Appearance = appearance13;
            ultraStatusPanel5.Key = "Key_CentroGestor";
            ultraStatusPanel5.Width = 350;
            appearance14.FontData.BoldAsString = "True";
            ultraStatusPanel6.Appearance = appearance14;
            ultraStatusPanel6.Key = "KeyConexion";
            this.USB_Barra.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3,
            ultraStatusPanel4,
            ultraStatusPanel5,
            ultraStatusPanel6});
            this.USB_Barra.Size = new System.Drawing.Size(676, 26);
            this.USB_Barra.TabIndex = 33;
            this.USB_Barra.Text = "UltraStatusBar1";
            this.USB_Barra.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2007;
            // 
            // ImageList1
            // 
            this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
            this.ImageList1.TransparentColor = System.Drawing.Color.Silver;
            this.ImageList1.Images.SetKeyName(0, "ActualizarVersion.png");
            this.ImageList1.Images.SetKeyName(1, "Ceco.png");
            this.ImageList1.Images.SetKeyName(2, "CecoProyecto.png");
            this.ImageList1.Images.SetKeyName(3, "Empleado.png");
            this.ImageList1.Images.SetKeyName(4, "Financiamiento.png");
            this.ImageList1.Images.SetKeyName(5, "Formulacion.png");
            this.ImageList1.Images.SetKeyName(6, "Interno.png");
            this.ImageList1.Images.SetKeyName(7, "Inversion.png");
            this.ImageList1.Images.SetKeyName(8, "Proyecto.png");
            this.ImageList1.Images.SetKeyName(9, "ReporteCeco.png");
            this.ImageList1.Images.SetKeyName(10, "ReporteProyecto.png");
            this.ImageList1.Images.SetKeyName(11, "Saldo.png");
            this.ImageList1.Images.SetKeyName(12, "Tarea.png");
            // 
            // ilLarge
            // 
            this.ilLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilLarge.ImageStream")));
            this.ilLarge.TransparentColor = System.Drawing.Color.Silver;
            this.ilLarge.Images.SetKeyName(0, "ActualizarVersion.png");
            this.ilLarge.Images.SetKeyName(1, "Buscar.png");
            this.ilLarge.Images.SetKeyName(2, "Calcular.png");
            this.ilLarge.Images.SetKeyName(3, "Ceco.png");
            this.ilLarge.Images.SetKeyName(4, "CecoProyecto.png");
            this.ilLarge.Images.SetKeyName(5, "Cerrar.png");
            this.ilLarge.Images.SetKeyName(6, "Detalle.png");
            this.ilLarge.Images.SetKeyName(7, "Eliminar.png");
            this.ilLarge.Images.SetKeyName(8, "Empleado.png");
            this.ilLarge.Images.SetKeyName(9, "Financiamiento.png");
            this.ilLarge.Images.SetKeyName(10, "Formulacion.png");
            this.ilLarge.Images.SetKeyName(11, "Imprimir.png");
            this.ilLarge.Images.SetKeyName(12, "Interno.png");
            this.ilLarge.Images.SetKeyName(13, "Inversion.png");
            this.ilLarge.Images.SetKeyName(14, "Lista.png");
            this.ilLarge.Images.SetKeyName(15, "Proyecto.png");
            this.ilLarge.Images.SetKeyName(16, "ReporteCeco.png");
            this.ilLarge.Images.SetKeyName(17, "ReporteProyecto.png");
            this.ilLarge.Images.SetKeyName(18, "Saldo.png");
            this.ilLarge.Images.SetKeyName(19, "Tarea.png");
            // 
            // windowDockingArea2
            // 
            this.windowDockingArea2.Dock = System.Windows.Forms.DockStyle.Left;
            this.windowDockingArea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowDockingArea2.Location = new System.Drawing.Point(4, 51);
            this.windowDockingArea2.Name = "windowDockingArea2";
            this.windowDockingArea2.Owner = this.ultraDockManager1;
            this.windowDockingArea2.Size = new System.Drawing.Size(326, 352);
            this.windowDockingArea2.TabIndex = 11;
            // 
            // Frm_Principal
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(676, 429);
            this.Controls.Add(this._Form1AutoHideControl);
            this.Controls.Add(this.windowDockingArea2);
            this.Controls.Add(this._Form1UnpinnedTabAreaTop);
            this.Controls.Add(this._Form1UnpinnedTabAreaBottom);
            this.Controls.Add(this._Form1UnpinnedTabAreaRight);
            this.Controls.Add(this._Form1UnpinnedTabAreaLeft);
            this.Controls.Add(this._Form1_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._Form1_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._Form1_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._Form1_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.USB_Barra);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Frm_Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SPRINGreport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Principal_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraExplorerBar1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraDockManager1)).EndInit();
            this._Form1AutoHideControl.ResumeLayout(false);
            this.dockableWindow1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		//protected void samplestree_AfterSelect(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e)
		//{
		//	if (e.NewSelections[0].Tag.ToString().Length>0)
		//	{

		//		try
		//		{
		//			foreach (Form f in this.MdiChildren)
		//			{
		//				if ( f.GetType().ToString() == e.NewSelections[0].Tag.ToString() )
		//				{
		//					f.Show();
		//					f.Focus();
		//					return;
		//				}
		//			}

		//			System.Type t = System.Type.GetType(e.NewSelections[0].Tag.ToString(),true);
		//			System.Windows.Forms.Form sample = (System.Windows.Forms.Form)System.Activator.CreateInstance(t,true);
		//			sample.MdiParent = this;
		//			sample.Show();
		//		}
		//		catch(Exception exc)
		//		{
		//			MessageBox.Show(this,exc.Message);
		//		}
		//	}
		//}

       private void Form1_Load(object sender, System.EventArgs e)
		{
		}

		private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "Exit":    // ButtonTool
					Application.Exit();
					break;

				case "Refresh Navigation":    // ButtonTool
					//LoadSamplesNavigationTree();
					break;

			}

		}

        private void Frm_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Esta por finalizar el acceso a la aplicacion, realmente desea salir ? ",
                                        "Salir", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question
                                    ) == System.Windows.Forms.DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        //private void LoadSamplesNavigationTree()
        //{
        //	this.ultraExplorerBar1.Groups.Clear();

        //	XmlDocument doc;

        //	try
        //	{
        //		doc = Config.NavigationXml;
        //	}
        //	catch (System.IO.FileNotFoundException)
        //	{
        //		MessageBox.Show(this, String.Format("The samples browser data file could not be found here: {0}",System.IO.Path.GetFullPath(System.Configuration.ConfigurationSettings.AppSettings["DataPath"])));
        //		return;
        //	}

        //	XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
        //	nsmgr.AddNamespace("d","http://tempuri.org/Samples.xsd");

        //	//load the ultra explorerbar groups
        //	XmlNodeList productgroups = doc.SelectNodes("//d:samples/d:productgroup", nsmgr);
        //	foreach (XmlNode productgroup in productgroups)
        //	{
        //		System.Diagnostics.Debug.WriteLine("Product Group Node: " + ((XmlElement)productgroup).GetAttribute("id"));

        //		//if the visibility attribute is false, continue to the next product group
        //		if ( !Convert.ToBoolean(((XmlElement)productgroup).GetAttribute("visible")) ) 
        //		{ continue; }

        //		//create the new control container and add to the explorer bar
        //		UltraExplorerBarContainerControl container = new UltraExplorerBarContainerControl();
        //		this.ultraExplorerBar1.Controls.Add(container);

        //		//create and add a tree to the container
        //		UltraTree samplestree = new UltraTree();
        //		samplestree.Dock = DockStyle.Fill;
        //		samplestree.AfterSelect += new Infragistics.Win.UltraWinTree.AfterNodeSelectEventHandler(this.samplestree_AfterSelect);
        //		samplestree.NodeConnectorStyle = NodeConnectorStyle.None;
        //		samplestree.Override.ActiveNodeAppearance.BackColor=Color.FromArgb(23, 141, 205);
        //		samplestree.Override.ActiveNodeAppearance.ForeColor=Color.White;
        //		samplestree.Override.ActiveNodeAppearance.FontData.Bold=Infragistics.Win.DefaultableBoolean.False;
        //		samplestree.Override.NodeAppearance.ImageBackgroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel;

        //		container.Controls.Add(samplestree);

        //		//create the new explorerbar group and assign the container to it
        //		UltraExplorerBarGroup group = new UltraExplorerBarGroup();
        //		group.Text = ((XmlElement)productgroup).GetAttribute("name");
        //		group.Key = ((XmlElement)productgroup).GetAttribute("id");

        //		if ( ((XmlElement)productgroup).GetAttribute("iconindex") !=null)
        //		{
        //			if ( this.imageListExplorerBar.Images[ int.Parse( ((XmlElement)productgroup).GetAttribute("iconindex") ) ] != null)
        //			{
        //				group.Settings.AppearancesLarge.HeaderAppearance.Image=this.imageListExplorerBar.Images[ int.Parse( ((XmlElement)productgroup).GetAttribute("iconindex") ) ];
        //				group.Settings.AppearancesLarge.SelectedHeaderAppearance.Image = this.imageListExplorerBar.Images[ int.Parse( ((XmlElement)productgroup).GetAttribute("iconindex") ) ];
        //			}
        //		}

        //		group.Settings.Style = GroupStyle.ControlContainer;
        //		group.Container = container;
        //		this.ultraExplorerBar1.Groups.Add(group);

        //		XmlNodeList products = productgroup.SelectNodes("d:product",nsmgr);
        //		foreach (XmlNode product in products)
        //		{
        //			System.Diagnostics.Debug.WriteLine("Product Node: " + ((XmlElement)product).GetAttribute("id"));

        //			//if the visibility attribute is false, continue to the next product group
        //			if ( !Convert.ToBoolean(((XmlElement)product).GetAttribute("visible")) ) 
        //			{ continue; }

        //			UltraTreeNode productnode = new UltraTreeNode( ((XmlElement)product).GetAttribute("id"), ((XmlElement)product).GetAttribute("name") );
        //			productnode.Tag = ((XmlElement)product).GetAttribute("type");
        //			if (this.imageListTreeView.Images[1]!=null)
        //			{ productnode.LeftImages.Add( this.imageListTreeView.Images[1] ); }
        //			productnode.Expanded=true;
        //			productnode.Override.NodeAppearance.FontData.Bold=Infragistics.Win.DefaultableBoolean.False;
        //			samplestree.Nodes.Add(productnode);

        //			#region Enumerate Product Categories
        //			XmlNodeList categories = product.SelectNodes("d:category",nsmgr);
        //			foreach (XmlNode category in categories)
        //			{
        //				System.Diagnostics.Debug.WriteLine("Category Node: " + ((XmlElement)category).GetAttribute("id"));

        //				//if the visibility attribute is false, continue to the next product group
        //				if ( !Convert.ToBoolean(((XmlElement)category).GetAttribute("visible")) ) 
        //				{ continue; }

        //				UltraTreeNode categorynode = new UltraTreeNode( ((XmlElement)category).GetAttribute("id"), ((XmlElement)category).GetAttribute("name") );
        //				categorynode.Tag = ((XmlElement)category).GetAttribute("type");
        //				if (this.imageListTreeView.Images[1]!=null)
        //				{ categorynode.LeftImages.Add( this.imageListTreeView.Images[1] ); }
        //				categorynode.Override.NodeAppearance.FontData.Bold=Infragistics.Win.DefaultableBoolean.False;
        //				productnode.Nodes.Add(categorynode);

        //				#region Enumerate Feature Nodes
        //				XmlNodeList features = category.SelectNodes("d:feature",nsmgr);
        //				foreach (XmlNode feature in features)
        //				{
        //					System.Diagnostics.Debug.WriteLine("Feature Node: " + ((XmlElement)feature).GetAttribute("id"));

        //					//if the visibility attribute is false, continue to the next product group
        //					if ( !Convert.ToBoolean(((XmlElement)feature).GetAttribute("visible")) ) 
        //					{ continue; }

        //					UltraTreeNode featurenode = new UltraTreeNode( ((XmlElement)feature).GetAttribute("id"), ((XmlElement)feature).GetAttribute("name") );
        //					featurenode.Tag = ((XmlElement)feature).GetAttribute("type");
        //					if (this.imageListTreeView.Images[1]!=null)
        //					{ featurenode.LeftImages.Add( this.imageListTreeView.Images[1] ); }
        //					featurenode.Override.NodeAppearance.FontData.Bold=Infragistics.Win.DefaultableBoolean.False;
        //					categorynode.Nodes.Add(featurenode);

        //					#region Enumerate Feature Sample Nodes
        //					XmlNodeList featuresamples = feature.SelectNodes("d:sample",nsmgr);
        //					foreach (XmlNode sample in featuresamples)
        //					{
        //						System.Diagnostics.Debug.WriteLine("Sample Node: " + ((XmlElement)sample).GetAttribute("id") + " Type: " + ((XmlElement)sample).GetAttribute("type"));

        //						if ( !Convert.ToBoolean(((XmlElement)sample).GetAttribute("visible")) ) 
        //						{ continue; }

        //						UltraTreeNode samplenode = new UltraTreeNode( ((XmlElement)sample).GetAttribute("id"), ((XmlElement)sample).GetAttribute("name") );
        //						if (this.imageListTreeView.Images[0]!=null)
        //						{ samplenode.LeftImages.Add( this.imageListTreeView.Images[0] ); }
        //						samplenode.Tag = ((XmlElement)sample).GetAttribute("type");
        //						featurenode.Nodes.Add(samplenode);
        //					}
        //					#endregion
        //				}
        //				#endregion

        //				#region Enumerate Category Sample Nodes
        //				XmlNodeList categorysamples = category.SelectNodes("d:sample",nsmgr);

        //				foreach (XmlNode sample in categorysamples)
        //				{
        //					UltraTreeNode samplenode = new UltraTreeNode( ((XmlElement)sample).GetAttribute("id"), ((XmlElement)sample).GetAttribute("name") );
        //					if (this.imageListTreeView.Images[0]!=null)
        //					{ samplenode.LeftImages.Add( this.imageListTreeView.Images[0] ); }
        //					samplenode.Tag = ((XmlElement)sample).GetAttribute("type");
        //					categorynode.Nodes.Add(samplenode);
        //				}
        //				#endregion

        //			}
        //			#endregion					
        //		}

        //		samplestree.ActiveNode=null;
        //		samplestree.SelectedNodes.Clear();

        //	}
        //}
    }
}
