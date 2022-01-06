namespace WMCP001
{
    partial class ConfParameterWMSForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfParameterWMSForm));
            this.SysSession = new Net4Sage.SageSession();
            this.tcConfiguracion = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lkuUbiArtOP = new Net4Sage.Controls.Lookup.TextLookup();
            this.lblDescripcionArt = new System.Windows.Forms.Label();
            this.lkuArticulo = new Net4Sage.Controls.Lookup.TextLookup();
            this.cbSKU = new System.Windows.Forms.CheckBox();
            this.grdConf = new System.Windows.Forms.DataGridView();
            this.btnEliminarArt = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lkuUbiDev = new Net4Sage.Controls.Lookup.TextLookup();
            this.lkuUbiResSec = new Net4Sage.Controls.Lookup.TextLookup();
            this.lkuUbiResxDefecto = new Net4Sage.Controls.Lookup.TextLookup();
            this.lkuUbiSec = new Net4Sage.Controls.Lookup.TextLookup();
            this.lkuUbixDefecto = new Net4Sage.Controls.Lookup.TextLookup();
            this.label11 = new System.Windows.Forms.Label();
            this.lblUbicsec = new System.Windows.Forms.Label();
            this.lblUbicdef = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtIdPallet = new System.Windows.Forms.TextBox();
            this.cbxPallDefec = new System.Windows.Forms.ComboBox();
            this.cbPallDef = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.grdPallet = new System.Windows.Forms.DataGridView();
            this.btnEliminarPall = new System.Windows.Forms.Button();
            this.btnAgregarPall = new System.Windows.Forms.Button();
            this.nudTamaño = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.nudDiasDev = new System.Windows.Forms.NumericUpDown();
            this.nudDiasEst = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.twmWarehouseUbicationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.confWMS = new WMCP001.ConfWMS();
            this.lblalmacen = new System.Windows.Forms.Label();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.fkItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.confWMS1 = new WMCP001.ConfWMS();
            this.lookupNavigator1 = new Net4Sage.Controls.Navigators.LookupNavigator(this.components);
            this.lkuAlmacen = new Net4Sage.Controls.Lookup.TextLookup();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.timItemBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.confWMS3 = new WMCP001.ConfWMS();
            this.timWarehouseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timWarehouseTableAdapter = new WMCP001.ConfWMSTableAdapters.timWarehouseTableAdapter();
            this.timItemTableAdapter = new WMCP001.ConfWMSTableAdapters.timItemTableAdapter();
            this.timwmsAlmacenArtTableAdapter = new WMCP001.ConfWMSTableAdapters.timwmsAlmacenArtTableAdapter();
            this.confWMS2 = new WMCP001.ConfWMS();
            this.statusBar1 = new Net4Sage.Controls.StatusBar();
            this.btnParamFresc = new System.Windows.Forms.Button();
            this.tcConfiguracion.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdConf)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPallet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTamaño)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasDev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasEst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.twmWarehouseUbicationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.confWMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fkItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.confWMS1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timItemBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.confWMS3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timWarehouseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.confWMS2)).BeginInit();
            this.SuspendLayout();
            // 
            // SysSession
            // 
            this.SysSession.Parameters = null;
            // 
            // tcConfiguracion
            // 
            this.tcConfiguracion.Controls.Add(this.tabPage1);
            this.tcConfiguracion.Controls.Add(this.tabPage2);
            this.tcConfiguracion.Controls.Add(this.tabPage3);
            this.tcConfiguracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcConfiguracion.Location = new System.Drawing.Point(12, 74);
            this.tcConfiguracion.Name = "tcConfiguracion";
            this.tcConfiguracion.SelectedIndex = 0;
            this.tcConfiguracion.Size = new System.Drawing.Size(624, 486);
            this.tcConfiguracion.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lkuUbiArtOP);
            this.tabPage1.Controls.Add(this.lblDescripcionArt);
            this.tabPage1.Controls.Add(this.lkuArticulo);
            this.tabPage1.Controls.Add(this.cbSKU);
            this.tabPage1.Controls.Add(this.grdConf);
            this.tabPage1.Controls.Add(this.btnEliminarArt);
            this.tabPage1.Controls.Add(this.btnAgregar);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(616, 460);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Almacenamiento";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lkuUbiArtOP
            // 
            this.lkuUbiArtOP.Enabled = false;
            this.lkuUbiArtOP.ErrorMessage = null;
            this.lkuUbiArtOP.Key = 0;
            this.lkuUbiArtOP.Location = new System.Drawing.Point(409, 15);
            this.lkuUbiArtOP.Mask = "";
            this.lkuUbiArtOP.MinimumSize = new System.Drawing.Size(27, 23);
            this.lkuUbiArtOP.Name = "lkuUbiArtOP";
            this.lkuUbiArtOP.Protected = false;
            this.lkuUbiArtOP.Size = new System.Drawing.Size(180, 23);
            this.lkuUbiArtOP.SysSession = null;
            this.lkuUbiArtOP.TabIndex = 17;
            this.lkuUbiArtOP.TextOnlyLookup = false;
            this.lkuUbiArtOP.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.LkuUbiArtOP_OnLookupReturn);
            // 
            // lblDescripcionArt
            // 
            this.lblDescripcionArt.AutoSize = true;
            this.lblDescripcionArt.Location = new System.Drawing.Point(64, 43);
            this.lblDescripcionArt.Name = "lblDescripcionArt";
            this.lblDescripcionArt.Size = new System.Drawing.Size(0, 13);
            this.lblDescripcionArt.TabIndex = 28;
            // 
            // lkuArticulo
            // 
            this.lkuArticulo.Enabled = false;
            this.lkuArticulo.ErrorMessage = null;
            this.lkuArticulo.Key = 0;
            this.lkuArticulo.Location = new System.Drawing.Point(59, 15);
            this.lkuArticulo.Mask = "";
            this.lkuArticulo.MinimumSize = new System.Drawing.Size(27, 23);
            this.lkuArticulo.Name = "lkuArticulo";
            this.lkuArticulo.Protected = false;
            this.lkuArticulo.Size = new System.Drawing.Size(185, 23);
            this.lkuArticulo.SysSession = null;
            this.lkuArticulo.TabIndex = 27;
            this.lkuArticulo.TextOnlyLookup = false;
            this.lkuArticulo.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.LkuArticulo_OnLookupReturn);
            this.lkuArticulo.Load += new System.EventHandler(this.LkuArticulo_Load);
            // 
            // cbSKU
            // 
            this.cbSKU.AutoSize = true;
            this.cbSKU.Location = new System.Drawing.Point(286, 20);
            this.cbSKU.Name = "cbSKU";
            this.cbSKU.Size = new System.Drawing.Size(15, 14);
            this.cbSKU.TabIndex = 24;
            this.cbSKU.UseVisualStyleBackColor = true;
            this.cbSKU.CheckedChanged += new System.EventHandler(this.CbSKU_CheckedChanged);
            // 
            // grdConf
            // 
            this.grdConf.AllowUserToAddRows = false;
            this.grdConf.AllowUserToDeleteRows = false;
            this.grdConf.AllowUserToOrderColumns = true;
            this.grdConf.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdConf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdConf.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdConf.Enabled = false;
            this.grdConf.Location = new System.Drawing.Point(21, 113);
            this.grdConf.MultiSelect = false;
            this.grdConf.Name = "grdConf";
            this.grdConf.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdConf.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdConf.Size = new System.Drawing.Size(568, 339);
            this.grdConf.TabIndex = 21;
            // 
            // btnEliminarArt
            // 
            this.btnEliminarArt.Location = new System.Drawing.Point(488, 76);
            this.btnEliminarArt.Name = "btnEliminarArt";
            this.btnEliminarArt.Size = new System.Drawing.Size(101, 31);
            this.btnEliminarArt.TabIndex = 20;
            this.btnEliminarArt.Text = "Eliminar Articulo";
            this.btnEliminarArt.UseVisualStyleBackColor = true;
            this.btnEliminarArt.Click += new System.EventHandler(this.BtnEliminarArt_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(21, 76);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(101, 30);
            this.btnAgregar.TabIndex = 19;
            this.btnAgregar.Text = "Agregar Articulo";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(302, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Ubicación opcional:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "SKU:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lkuUbiDev);
            this.tabPage2.Controls.Add(this.lkuUbiResSec);
            this.tabPage2.Controls.Add(this.lkuUbiResxDefecto);
            this.tabPage2.Controls.Add(this.lkuUbiSec);
            this.tabPage2.Controls.Add(this.lkuUbixDefecto);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.lblUbicsec);
            this.tabPage2.Controls.Add(this.lblUbicdef);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(616, 460);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Generales";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lkuUbiDev
            // 
            this.lkuUbiDev.Enabled = false;
            this.lkuUbiDev.ErrorMessage = null;
            this.lkuUbiDev.Key = 0;
            this.lkuUbiDev.Location = new System.Drawing.Point(253, 291);
            this.lkuUbiDev.Mask = "";
            this.lkuUbiDev.MinimumSize = new System.Drawing.Size(31, 27);
            this.lkuUbiDev.Name = "lkuUbiDev";
            this.lkuUbiDev.Protected = false;
            this.lkuUbiDev.Size = new System.Drawing.Size(210, 27);
            this.lkuUbiDev.SysSession = null;
            this.lkuUbiDev.TabIndex = 34;
            this.lkuUbiDev.TextOnlyLookup = false;
            this.lkuUbiDev.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.LkuUbiDev_OnLookupReturn);
            // 
            // lkuUbiResSec
            // 
            this.lkuUbiResSec.Enabled = false;
            this.lkuUbiResSec.ErrorMessage = null;
            this.lkuUbiResSec.Key = 0;
            this.lkuUbiResSec.Location = new System.Drawing.Point(253, 204);
            this.lkuUbiResSec.Mask = "";
            this.lkuUbiResSec.MinimumSize = new System.Drawing.Size(31, 27);
            this.lkuUbiResSec.Name = "lkuUbiResSec";
            this.lkuUbiResSec.Protected = false;
            this.lkuUbiResSec.Size = new System.Drawing.Size(210, 27);
            this.lkuUbiResSec.SysSession = null;
            this.lkuUbiResSec.TabIndex = 33;
            this.lkuUbiResSec.TextOnlyLookup = false;
            this.lkuUbiResSec.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.LkuUbiResSec_OnLookupReturn);
            // 
            // lkuUbiResxDefecto
            // 
            this.lkuUbiResxDefecto.Enabled = false;
            this.lkuUbiResxDefecto.ErrorMessage = null;
            this.lkuUbiResxDefecto.Key = 0;
            this.lkuUbiResxDefecto.Location = new System.Drawing.Point(253, 163);
            this.lkuUbiResxDefecto.Mask = "";
            this.lkuUbiResxDefecto.MinimumSize = new System.Drawing.Size(31, 27);
            this.lkuUbiResxDefecto.Name = "lkuUbiResxDefecto";
            this.lkuUbiResxDefecto.Protected = false;
            this.lkuUbiResxDefecto.Size = new System.Drawing.Size(210, 27);
            this.lkuUbiResxDefecto.SysSession = null;
            this.lkuUbiResxDefecto.TabIndex = 32;
            this.lkuUbiResxDefecto.TextOnlyLookup = false;
            this.lkuUbiResxDefecto.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.LkuUbiResxDefecto_OnLookupReturn);
            // 
            // lkuUbiSec
            // 
            this.lkuUbiSec.Enabled = false;
            this.lkuUbiSec.ErrorMessage = null;
            this.lkuUbiSec.Key = 0;
            this.lkuUbiSec.Location = new System.Drawing.Point(253, 87);
            this.lkuUbiSec.Mask = "";
            this.lkuUbiSec.MinimumSize = new System.Drawing.Size(31, 27);
            this.lkuUbiSec.Name = "lkuUbiSec";
            this.lkuUbiSec.Protected = false;
            this.lkuUbiSec.Size = new System.Drawing.Size(210, 27);
            this.lkuUbiSec.SysSession = null;
            this.lkuUbiSec.TabIndex = 31;
            this.lkuUbiSec.TextOnlyLookup = false;
            this.lkuUbiSec.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.LkuUbiSec_OnLookupReturn);
            // 
            // lkuUbixDefecto
            // 
            this.lkuUbixDefecto.Enabled = false;
            this.lkuUbixDefecto.ErrorMessage = null;
            this.lkuUbixDefecto.Key = 0;
            this.lkuUbixDefecto.Location = new System.Drawing.Point(253, 46);
            this.lkuUbixDefecto.Mask = "";
            this.lkuUbixDefecto.MinimumSize = new System.Drawing.Size(31, 27);
            this.lkuUbixDefecto.Name = "lkuUbixDefecto";
            this.lkuUbixDefecto.Protected = false;
            this.lkuUbixDefecto.Size = new System.Drawing.Size(210, 27);
            this.lkuUbixDefecto.SysSession = null;
            this.lkuUbixDefecto.TabIndex = 18;
            this.lkuUbixDefecto.TextOnlyLookup = false;
            this.lkuUbixDefecto.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.LkuUbixDefecto_OnLookupReturn);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(30, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Pallets Parciales";
            // 
            // lblUbicsec
            // 
            this.lblUbicsec.AutoSize = true;
            this.lblUbicsec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUbicsec.Location = new System.Drawing.Point(133, 92);
            this.lblUbicsec.Name = "lblUbicsec";
            this.lblUbicsec.Size = new System.Drawing.Size(113, 13);
            this.lblUbicsec.TabIndex = 28;
            this.lblUbicsec.Text = "Ubicación secundaria:";
            // 
            // lblUbicdef
            // 
            this.lblUbicdef.AutoSize = true;
            this.lblUbicdef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUbicdef.Location = new System.Drawing.Point(133, 53);
            this.lblUbicdef.Name = "lblUbicdef";
            this.lblUbicdef.Size = new System.Drawing.Size(115, 13);
            this.lblUbicdef.TabIndex = 27;
            this.lblUbicdef.Text = "Ubicación por defecto:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(37, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Devolución:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(52, 296);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(169, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Ubicación de entrada por defecto:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Resurtido:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(88, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Ubicación origen secundaria:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(85, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Ubicación origen por defecto:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtIdPallet);
            this.tabPage3.Controls.Add(this.cbxPallDefec);
            this.tabPage3.Controls.Add(this.cbPallDef);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.grdPallet);
            this.tabPage3.Controls.Add(this.btnEliminarPall);
            this.tabPage3.Controls.Add(this.btnAgregarPall);
            this.tabPage3.Controls.Add(this.nudTamaño);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.nudDiasDev);
            this.tabPage3.Controls.Add(this.nudDiasEst);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(616, 460);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Recepción y despacho";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtIdPallet
            // 
            this.txtIdPallet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdPallet.Location = new System.Drawing.Point(133, 157);
            this.txtIdPallet.Name = "txtIdPallet";
            this.txtIdPallet.Size = new System.Drawing.Size(120, 20);
            this.txtIdPallet.TabIndex = 33;
            // 
            // cbxPallDefec
            // 
            this.cbxPallDefec.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbxPallDefec.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbxPallDefec.DropDownHeight = 200;
            this.cbxPallDefec.Enabled = false;
            this.cbxPallDefec.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbxPallDefec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxPallDefec.FormattingEnabled = true;
            this.cbxPallDefec.IntegralHeight = false;
            this.cbxPallDefec.ItemHeight = 13;
            this.cbxPallDefec.Location = new System.Drawing.Point(169, 404);
            this.cbxPallDefec.Name = "cbxPallDefec";
            this.cbxPallDefec.Size = new System.Drawing.Size(173, 21);
            this.cbxPallDefec.TabIndex = 32;
            // 
            // cbPallDef
            // 
            this.cbPallDef.AutoSize = true;
            this.cbPallDef.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPallDef.Location = new System.Drawing.Point(32, 408);
            this.cbPallDef.Name = "cbPallDef";
            this.cbPallDef.Size = new System.Drawing.Size(15, 14);
            this.cbPallDef.TabIndex = 31;
            this.cbPallDef.UseVisualStyleBackColor = true;
            this.cbPallDef.CheckedChanged += new System.EventHandler(this.CbPallDef_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(48, 407);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(115, 13);
            this.label15.TabIndex = 30;
            this.label15.Text = "Usar Pallet por defecto";
            // 
            // grdPallet
            // 
            this.grdPallet.AllowUserToAddRows = false;
            this.grdPallet.AllowUserToDeleteRows = false;
            this.grdPallet.AllowUserToOrderColumns = true;
            this.grdPallet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdPallet.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.grdPallet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPallet.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdPallet.Location = new System.Drawing.Point(32, 238);
            this.grdPallet.MultiSelect = false;
            this.grdPallet.Name = "grdPallet";
            this.grdPallet.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdPallet.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPallet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPallet.Size = new System.Drawing.Size(482, 150);
            this.grdPallet.TabIndex = 29;
            this.grdPallet.Click += new System.EventHandler(this.GrdPallet_Click);
            // 
            // btnEliminarPall
            // 
            this.btnEliminarPall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarPall.Location = new System.Drawing.Point(441, 203);
            this.btnEliminarPall.Name = "btnEliminarPall";
            this.btnEliminarPall.Size = new System.Drawing.Size(75, 29);
            this.btnEliminarPall.TabIndex = 28;
            this.btnEliminarPall.Text = "Eliminar";
            this.btnEliminarPall.UseVisualStyleBackColor = true;
            this.btnEliminarPall.Click += new System.EventHandler(this.BtnEliminarPall_Click);
            // 
            // btnAgregarPall
            // 
            this.btnAgregarPall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarPall.Location = new System.Drawing.Point(30, 203);
            this.btnAgregarPall.Name = "btnAgregarPall";
            this.btnAgregarPall.Size = new System.Drawing.Size(75, 29);
            this.btnAgregarPall.TabIndex = 27;
            this.btnAgregarPall.Text = "Agregar";
            this.btnAgregarPall.UseVisualStyleBackColor = true;
            this.btnAgregarPall.Click += new System.EventHandler(this.BtnAgregarPall_Click);
            // 
            // nudTamaño
            // 
            this.nudTamaño.DecimalPlaces = 1;
            this.nudTamaño.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTamaño.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudTamaño.Location = new System.Drawing.Point(396, 158);
            this.nudTamaño.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudTamaño.Name = "nudTamaño";
            this.nudTamaño.Size = new System.Drawing.Size(120, 20);
            this.nudTamaño.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(319, 158);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "Tamaño:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(54, 160);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "ID Pallet:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(29, 124);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(198, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Configuración de Pallets para despacho:";
            // 
            // nudDiasDev
            // 
            this.nudDiasDev.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDiasDev.Location = new System.Drawing.Point(301, 79);
            this.nudDiasDev.Name = "nudDiasDev";
            this.nudDiasDev.Size = new System.Drawing.Size(120, 20);
            this.nudDiasDev.TabIndex = 21;
            // 
            // nudDiasEst
            // 
            this.nudDiasEst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDiasEst.Location = new System.Drawing.Point(301, 38);
            this.nudDiasEst.Name = "nudDiasEst";
            this.nudDiasEst.Size = new System.Drawing.Size(120, 20);
            this.nudDiasEst.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(29, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Recepción de contenedores:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(139, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Días de devolución:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(158, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Días de estadía:";
            // 
            // twmWarehouseUbicationsBindingSource
            // 
            this.twmWarehouseUbicationsBindingSource.DataMember = "twmWarehouseUbications";
            this.twmWarehouseUbicationsBindingSource.DataSource = this.confWMS;
            // 
            // confWMS
            // 
            this.confWMS.DataSetName = "ConfWMS";
            this.confWMS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblalmacen
            // 
            this.lblalmacen.AutoSize = true;
            this.lblalmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblalmacen.Location = new System.Drawing.Point(16, 35);
            this.lblalmacen.Name = "lblalmacen";
            this.lblalmacen.Size = new System.Drawing.Size(55, 13);
            this.lblalmacen.TabIndex = 1;
            this.lblalmacen.Text = "Almacén";
            // 
            // menuBar1
            // 
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.Mode = Net4Sage.Controls.MenuBarMode.Mantaince;
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuBar1.ShowItemToolTips = true;
            this.menuBar1.Size = new System.Drawing.Size(668, 24);
            this.menuBar1.SysSession = this.SysSession;
            this.menuBar1.TabIndex = 11;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.OnSave += new System.EventHandler(this.MenuBar1_OnSave);
            this.menuBar1.OnCancel += new System.EventHandler(this.MenuBar1_OnCancel);
            this.menuBar1.OnDelete += new Net4Sage.Controls.ValidationEvenHandler(this.MenuBar1_OnDelete);
            // 
            // fkItemBindingSource
            // 
            this.fkItemBindingSource.DataMember = "fk_Item";
            this.fkItemBindingSource.DataSource = this.timItemBindingSource;
            // 
            // timItemBindingSource
            // 
            this.timItemBindingSource.DataMember = "timItem";
            this.timItemBindingSource.DataSource = this.confWMS1;
            // 
            // confWMS1
            // 
            this.confWMS1.DataSetName = "ConfWMS";
            this.confWMS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lookupNavigator1
            // 
            this.lookupNavigator1.Source = null;
            // 
            // lkuAlmacen
            // 
            this.lkuAlmacen.Enabled = false;
            this.lkuAlmacen.ErrorMessage = null;
            this.lkuAlmacen.Key = 0;
            this.lkuAlmacen.Location = new System.Drawing.Point(71, 30);
            this.lkuAlmacen.Mask = "";
            this.lkuAlmacen.MinimumSize = new System.Drawing.Size(27, 23);
            this.lkuAlmacen.Name = "lkuAlmacen";
            this.lkuAlmacen.Protected = false;
            this.lkuAlmacen.Size = new System.Drawing.Size(186, 23);
            this.lkuAlmacen.SysSession = null;
            this.lkuAlmacen.TabIndex = 13;
            this.lkuAlmacen.TextOnlyLookup = false;
            this.lkuAlmacen.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.LkuAlmacen_OnLookupReturn);
            this.lkuAlmacen.Load += new System.EventHandler(this.LkuAlmacen_Load);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(266, 36);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(0, 13);
            this.lblDescripcion.TabIndex = 14;
            // 
            // timItemBindingSource1
            // 
            this.timItemBindingSource1.DataMember = "timItem";
            this.timItemBindingSource1.DataSource = this.confWMS3;
            // 
            // confWMS3
            // 
            this.confWMS3.DataSetName = "ConfWMS";
            this.confWMS3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // timWarehouseBindingSource
            // 
            this.timWarehouseBindingSource.DataMember = "timWarehouse";
            this.timWarehouseBindingSource.DataSource = this.confWMS;
            // 
            // timWarehouseTableAdapter
            // 
            this.timWarehouseTableAdapter.ClearBeforeFill = true;
            // 
            // timItemTableAdapter
            // 
            this.timItemTableAdapter.ClearBeforeFill = true;
            // 
            // timwmsAlmacenArtTableAdapter
            // 
            this.timwmsAlmacenArtTableAdapter.ClearBeforeFill = true;
            // 
            // confWMS2
            // 
            this.confWMS2.DataSetName = "ConfWMS";
            this.confWMS2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // statusBar1
            // 
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar1.Location = new System.Drawing.Point(0, 601);
            this.statusBar1.MinimumSize = new System.Drawing.Size(0, 31);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Navigator = null;
            this.statusBar1.Padding = new System.Windows.Forms.Padding(0, 3, 5, 3);
            this.statusBar1.Size = new System.Drawing.Size(668, 31);
            this.statusBar1.SysSession = this.SysSession;
            this.statusBar1.TabIndex = 15;
            // 
            // btnParamFresc
            // 
            this.btnParamFresc.Location = new System.Drawing.Point(504, 30);
            this.btnParamFresc.Name = "btnParamFresc";
            this.btnParamFresc.Size = new System.Drawing.Size(128, 23);
            this.btnParamFresc.TabIndex = 16;
            this.btnParamFresc.Text = "Parametros de Frescura";
            this.btnParamFresc.UseVisualStyleBackColor = true;
            this.btnParamFresc.Click += new System.EventHandler(this.BtnParamFresc_Click);
            // 
            // ConfParameterWMSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(668, 632);
            this.Controls.Add(this.btnParamFresc);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lkuAlmacen);
            this.Controls.Add(this.lblalmacen);
            this.Controls.Add(this.tcConfiguracion);
            this.Controls.Add(this.menuBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConfParameterWMSForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración general de WMS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfParameterWMSForm_FormClosing);
            this.Load += new System.EventHandler(this.ConfParameterWMSForm_Load);
            this.tcConfiguracion.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdConf)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPallet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTamaño)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasDev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasEst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.twmWarehouseUbicationsBindingSource)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.confWMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fkItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timItemBindingSource)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.confWMS1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timItemBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.confWMS3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timWarehouseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.confWMS2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.BindingSource DetailsBS;
        private Net4Sage.SageSession SysSession;
        private System.Windows.Forms.TabControl tcConfiguracion;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblalmacen;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grdConf;
        private System.Windows.Forms.Button btnEliminarArt;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private ConfWMS confWMS;
        private System.Windows.Forms.BindingSource timWarehouseBindingSource;
        private ConfWMSTableAdapters.timWarehouseTableAdapter timWarehouseTableAdapter;
        private System.Windows.Forms.BindingSource twmWarehouseUbicationsBindingSource;
        private ConfWMS confWMS1;
        private System.Windows.Forms.BindingSource timItemBindingSource;
        private ConfWMSTableAdapters.timItemTableAdapter timItemTableAdapter;
        private System.Windows.Forms.CheckBox cbSKU;
        private Net4Sage.Controls.MenuBar menuBar1;
        private System.Windows.Forms.NumericUpDown nudDiasDev;
        private System.Windows.Forms.NumericUpDown nudDiasEst;
        private System.Windows.Forms.ComboBox cbxPallDefec;
        private System.Windows.Forms.CheckBox cbPallDef;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView grdPallet;
        private System.Windows.Forms.Button btnEliminarPall;
        private System.Windows.Forms.Button btnAgregarPall;
        private System.Windows.Forms.NumericUpDown nudTamaño;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.BindingSource fkItemBindingSource;
        private ConfWMSTableAdapters.timwmsAlmacenArtTableAdapter timwmsAlmacenArtTableAdapter;
        private ConfWMS confWMS2;
        private ConfWMS confWMS3;
        private System.Windows.Forms.BindingSource timItemBindingSource1;
        private System.Windows.Forms.TextBox txtIdPallet;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblUbicsec;
        private System.Windows.Forms.Label lblUbicdef;
        private Net4Sage.Controls.Navigators.LookupNavigator lookupNavigator1;
        private Net4Sage.Controls.Lookup.TextLookup lkuAlmacen;
        private System.Windows.Forms.Label lblDescripcion;
        private Net4Sage.Controls.Lookup.TextLookup lkuArticulo;
        private System.Windows.Forms.Label lblDescripcionArt;
        private Net4Sage.Controls.StatusBar statusBar1;
        private System.Windows.Forms.Button btnParamFresc;
        private Net4Sage.Controls.Lookup.TextLookup lkuUbiArtOP;
        private Net4Sage.Controls.Lookup.TextLookup lkuUbiDev;
        private Net4Sage.Controls.Lookup.TextLookup lkuUbiResSec;
        private Net4Sage.Controls.Lookup.TextLookup lkuUbiResxDefecto;
        private Net4Sage.Controls.Lookup.TextLookup lkuUbiSec;
        private Net4Sage.Controls.Lookup.TextLookup lkuUbixDefecto;
    }
}

