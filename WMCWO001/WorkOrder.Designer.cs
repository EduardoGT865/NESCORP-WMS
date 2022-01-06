namespace WMCWO001
{
    partial class WorkOrder
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
            this.SysSession = new Net4Sage.SageSession();
            this.lblWorkOrderNo = new System.Windows.Forms.Label();
            this.lblWorkOrderType = new System.Windows.Forms.Label();
            this.lkuTransaccion = new Net4Sage.Controls.Lookup.TextLookup();
            this.strStatusBar = new Net4Sage.Controls.StatusBar();
            this.cbxTipoOrden = new System.Windows.Forms.ComboBox();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label18 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnDistribuir = new System.Windows.Forms.Button();
            this.btnGenerarOT = new System.Windows.Forms.Button();
            this.grdArtSelect = new System.Windows.Forms.DataGridView();
            this.Partida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Articulo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UM2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recibido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantARecibir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantPend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemKeyOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UmKey2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Whsekey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WhseID2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POLineKey2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantRecibida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtAlmacen = new System.Windows.Forms.TextBox();
            this.cbxUMPartida = new System.Windows.Forms.ComboBox();
            this.txtCantRecibida = new System.Windows.Forms.TextBox();
            this.lkuArticulo1 = new Net4Sage.Controls.Lookup.TextLookup();
            this.txtPartida = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.grdPallets = new System.Windows.Forms.DataGridView();
            this.OT_Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LotKeyOt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LnKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LPN2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Umkey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbxUM = new System.Windows.Forms.ComboBox();
            this.lkuPuerta = new Net4Sage.Controls.Lookup.TextLookup();
            this.textLookup6 = new Net4Sage.Controls.Lookup.TextLookup();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtLPN = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFrescura = new System.Windows.Forms.TextBox();
            this.dtpFechaFabricacion = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.lkuLote = new Net4Sage.Controls.Lookup.TextLookup();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lkuAlmacenDestino = new Net4Sage.Controls.Lookup.TextLookup();
            this.label4 = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.lkuGaveta = new Net4Sage.Controls.Lookup.TextLookup();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdOt = new System.Windows.Forms.TextBox();
            this.grdOT = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_Vencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_Fabricacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frescura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cant_Cajas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gabeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ubicacion_Desde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ubicacion_Hasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lkuArticulo = new Net4Sage.Controls.Lookup.TextLookup();
            this.lblItem = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lkuFromGate = new Net4Sage.Controls.Lookup.TextLookup();
            this.dtpOT = new System.Windows.Forms.DateTimePicker();
            this.lkuReceipt = new Net4Sage.Controls.Lookup.TextLookup();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblReceipt = new System.Windows.Forms.Label();
            this.lkuFromUbication = new Net4Sage.Controls.Lookup.TextLookup();
            this.lblFromUbication = new System.Windows.Forms.Label();
            this.lkuUbiHasta = new Net4Sage.Controls.Lookup.TextLookup();
            this.lblToUbication = new System.Windows.Forms.Label();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.lkuWarehouse = new Net4Sage.Controls.Lookup.TextLookup();
            this.btnImportar = new System.Windows.Forms.Button();
            this.cbxEstado = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdArtSelect)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPallets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOT)).BeginInit();
            this.SuspendLayout();
            // 
            // SysSession
            // 
            this.SysSession.Parameters = null;
            // 
            // lblWorkOrderNo
            // 
            this.lblWorkOrderNo.AutoSize = true;
            this.lblWorkOrderNo.Location = new System.Drawing.Point(227, 27);
            this.lblWorkOrderNo.Name = "lblWorkOrderNo";
            this.lblWorkOrderNo.Size = new System.Drawing.Size(66, 13);
            this.lblWorkOrderNo.TabIndex = 14;
            this.lblWorkOrderNo.Text = "Transacción";
            // 
            // lblWorkOrderType
            // 
            this.lblWorkOrderType.AutoSize = true;
            this.lblWorkOrderType.Location = new System.Drawing.Point(22, 29);
            this.lblWorkOrderType.Name = "lblWorkOrderType";
            this.lblWorkOrderType.Size = new System.Drawing.Size(75, 13);
            this.lblWorkOrderType.TabIndex = 16;
            this.lblWorkOrderType.Text = "Tipo de Orden";
            // 
            // lkuTransaccion
            // 
            this.lkuTransaccion.Enabled = false;
            this.lkuTransaccion.ErrorMessage = null;
            this.lkuTransaccion.Key = 0;
            this.lkuTransaccion.Location = new System.Drawing.Point(223, 42);
            this.lkuTransaccion.Mask = "";
            this.lkuTransaccion.MinimumSize = new System.Drawing.Size(27, 23);
            this.lkuTransaccion.Name = "lkuTransaccion";
            this.lkuTransaccion.Protected = false;
            this.lkuTransaccion.Size = new System.Drawing.Size(147, 23);
            this.lkuTransaccion.SysSession = null;
            this.lkuTransaccion.TabIndex = 44;
            this.lkuTransaccion.TextOnlyLookup = false;
            this.lkuTransaccion.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.LkuTransaccion_OnLookupReturn);
            // 
            // strStatusBar
            // 
            this.strStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.strStatusBar.Location = new System.Drawing.Point(0, 716);
            this.strStatusBar.MinimumSize = new System.Drawing.Size(0, 31);
            this.strStatusBar.Name = "strStatusBar";
            this.strStatusBar.Navigator = null;
            this.strStatusBar.Padding = new System.Windows.Forms.Padding(0, 3, 5, 3);
            this.strStatusBar.Size = new System.Drawing.Size(837, 31);
            this.strStatusBar.SysSession = this.SysSession;
            this.strStatusBar.TabIndex = 63;
            // 
            // cbxTipoOrden
            // 
            this.cbxTipoOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoOrden.FormattingEnabled = true;
            this.cbxTipoOrden.Location = new System.Drawing.Point(19, 44);
            this.cbxTipoOrden.Name = "cbxTipoOrden";
            this.cbxTipoOrden.Size = new System.Drawing.Size(154, 21);
            this.cbxTipoOrden.TabIndex = 65;
            this.cbxTipoOrden.SelectedIndexChanged += new System.EventHandler(this.CbxTipoOrden_SelectedIndexChanged);
            // 
            // menuBar1
            // 
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.Mode = Net4Sage.Controls.MenuBarMode.Transaction;
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuBar1.ShowItemToolTips = true;
            this.menuBar1.Size = new System.Drawing.Size(837, 24);
            this.menuBar1.SysSession = this.SysSession;
            this.menuBar1.TabIndex = 67;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuBar1_ItemClicked);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 74);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(803, 642);
            this.tabControl1.TabIndex = 70;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.btnDistribuir);
            this.tabPage1.Controls.Add(this.btnGenerarOT);
            this.tabPage1.Controls.Add(this.grdArtSelect);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.txtAlmacen);
            this.tabPage1.Controls.Add(this.cbxUMPartida);
            this.tabPage1.Controls.Add(this.txtCantRecibida);
            this.tabPage1.Controls.Add(this.lkuArticulo1);
            this.tabPage1.Controls.Add(this.txtPartida);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(795, 616);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Partidas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(743, 523);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(15, 13);
            this.label18.TabIndex = 86;
            this.label18.Text = "%";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 518);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(726, 23);
            this.progressBar1.TabIndex = 85;
            // 
            // btnDistribuir
            // 
            this.btnDistribuir.Enabled = false;
            this.btnDistribuir.Location = new System.Drawing.Point(701, 22);
            this.btnDistribuir.Name = "btnDistribuir";
            this.btnDistribuir.Size = new System.Drawing.Size(75, 23);
            this.btnDistribuir.TabIndex = 84;
            this.btnDistribuir.Text = "Distribuir";
            this.btnDistribuir.UseVisualStyleBackColor = true;
            this.btnDistribuir.Click += new System.EventHandler(this.BtnDistribuir_Click);
            // 
            // btnGenerarOT
            // 
            this.btnGenerarOT.Enabled = false;
            this.btnGenerarOT.Location = new System.Drawing.Point(701, 80);
            this.btnGenerarOT.Name = "btnGenerarOT";
            this.btnGenerarOT.Size = new System.Drawing.Size(75, 23);
            this.btnGenerarOT.TabIndex = 83;
            this.btnGenerarOT.Text = "Generar OT";
            this.btnGenerarOT.UseVisualStyleBackColor = true;
            this.btnGenerarOT.Click += new System.EventHandler(this.BtnGenerarOT_Click);
            // 
            // grdArtSelect
            // 
            this.grdArtSelect.AllowUserToAddRows = false;
            this.grdArtSelect.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdArtSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdArtSelect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Partida,
            this.Articulo2,
            this.Descripcion,
            this.UM2,
            this.Recibido,
            this.CantARecibir,
            this.CantPend,
            this.ItemKeyOT,
            this.UmKey2,
            this.Whsekey,
            this.WhseID2,
            this.POLineKey2,
            this.CantRecibida});
            this.grdArtSelect.Location = new System.Drawing.Point(9, 112);
            this.grdArtSelect.Name = "grdArtSelect";
            this.grdArtSelect.Size = new System.Drawing.Size(780, 405);
            this.grdArtSelect.TabIndex = 82;
            this.grdArtSelect.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdArtSelect_CellClick);
            this.grdArtSelect.CurrentCellDirtyStateChanged += new System.EventHandler(this.GrdArtSelect_CurrentCellDirtyStateChanged);
            // 
            // Partida
            // 
            this.Partida.HeaderText = "Partida";
            this.Partida.Name = "Partida";
            // 
            // Articulo2
            // 
            this.Articulo2.HeaderText = "Articulo";
            this.Articulo2.Name = "Articulo2";
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            // 
            // UM2
            // 
            this.UM2.HeaderText = "UM";
            this.UM2.Name = "UM2";
            // 
            // Recibido
            // 
            this.Recibido.HeaderText = "Cantidad Recibida";
            this.Recibido.Name = "Recibido";
            // 
            // CantARecibir
            // 
            this.CantARecibir.HeaderText = "Cantidad a recibir";
            this.CantARecibir.Name = "CantARecibir";
            // 
            // CantPend
            // 
            this.CantPend.HeaderText = "Cantidad Pendiente";
            this.CantPend.Name = "CantPend";
            // 
            // ItemKeyOT
            // 
            this.ItemKeyOT.HeaderText = "ItemKeyOT";
            this.ItemKeyOT.Name = "ItemKeyOT";
            this.ItemKeyOT.Visible = false;
            // 
            // UmKey2
            // 
            this.UmKey2.HeaderText = "UmKey";
            this.UmKey2.Name = "UmKey2";
            this.UmKey2.Visible = false;
            // 
            // Whsekey
            // 
            this.Whsekey.HeaderText = "Whsekey";
            this.Whsekey.Name = "Whsekey";
            this.Whsekey.Visible = false;
            // 
            // WhseID2
            // 
            this.WhseID2.HeaderText = "WhseID";
            this.WhseID2.Name = "WhseID2";
            this.WhseID2.Visible = false;
            // 
            // POLineKey2
            // 
            this.POLineKey2.HeaderText = "POLineKey";
            this.POLineKey2.Name = "POLineKey2";
            this.POLineKey2.Visible = false;
            // 
            // CantRecibida
            // 
            this.CantRecibida.HeaderText = "CantRecibida";
            this.CantRecibida.Name = "CantRecibida";
            this.CantRecibida.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(311, 67);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 13);
            this.label17.TabIndex = 81;
            this.label17.Text = "Almacen";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(206, 66);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(24, 13);
            this.label16.TabIndex = 80;
            this.label16.Text = "UM";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 63);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 13);
            this.label15.TabIndex = 79;
            this.label15.Text = "Cantidad Recibida";
            // 
            // txtAlmacen
            // 
            this.txtAlmacen.Location = new System.Drawing.Point(309, 83);
            this.txtAlmacen.Name = "txtAlmacen";
            this.txtAlmacen.Size = new System.Drawing.Size(100, 20);
            this.txtAlmacen.TabIndex = 76;
            // 
            // cbxUMPartida
            // 
            this.cbxUMPartida.FormattingEnabled = true;
            this.cbxUMPartida.Location = new System.Drawing.Point(203, 82);
            this.cbxUMPartida.Name = "cbxUMPartida";
            this.cbxUMPartida.Size = new System.Drawing.Size(75, 21);
            this.cbxUMPartida.TabIndex = 75;
            // 
            // txtCantRecibida
            // 
            this.txtCantRecibida.Location = new System.Drawing.Point(14, 83);
            this.txtCantRecibida.Name = "txtCantRecibida";
            this.txtCantRecibida.Size = new System.Drawing.Size(172, 20);
            this.txtCantRecibida.TabIndex = 74;
            // 
            // lkuArticulo1
            // 
            this.lkuArticulo1.Enabled = false;
            this.lkuArticulo1.ErrorMessage = null;
            this.lkuArticulo1.Key = 0;
            this.lkuArticulo1.Location = new System.Drawing.Point(131, 21);
            this.lkuArticulo1.Mask = "";
            this.lkuArticulo1.MinimumSize = new System.Drawing.Size(27, 23);
            this.lkuArticulo1.Name = "lkuArticulo1";
            this.lkuArticulo1.Protected = false;
            this.lkuArticulo1.Size = new System.Drawing.Size(147, 23);
            this.lkuArticulo1.SysSession = null;
            this.lkuArticulo1.TabIndex = 73;
            this.lkuArticulo1.TextOnlyLookup = false;
            // 
            // txtPartida
            // 
            this.txtPartida.Location = new System.Drawing.Point(14, 24);
            this.txtPartida.Name = "txtPartida";
            this.txtPartida.Size = new System.Drawing.Size(100, 20);
            this.txtPartida.TabIndex = 72;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 13);
            this.label13.TabIndex = 71;
            this.label13.Text = "Partida OC";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(128, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Articulo";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.grdPallets);
            this.tabPage2.Controls.Add(this.cbxUM);
            this.tabPage2.Controls.Add(this.lkuPuerta);
            this.tabPage2.Controls.Add(this.textLookup6);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.txtLPN);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.txtFrescura);
            this.tabPage2.Controls.Add(this.dtpFechaFabricacion);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.dtpFechaVencimiento);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.lkuLote);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.lkuAlmacenDestino);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.nudCantidad);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.lkuGaveta);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txtIdOt);
            this.tabPage2.Controls.Add(this.grdOT);
            this.tabPage2.Controls.Add(this.lkuArticulo);
            this.tabPage2.Controls.Add(this.lblItem);
            this.tabPage2.Controls.Add(this.btnConfirm);
            this.tabPage2.Controls.Add(this.lkuFromGate);
            this.tabPage2.Controls.Add(this.dtpOT);
            this.tabPage2.Controls.Add(this.lkuReceipt);
            this.tabPage2.Controls.Add(this.lblDate);
            this.tabPage2.Controls.Add(this.lblReceipt);
            this.tabPage2.Controls.Add(this.lkuFromUbication);
            this.tabPage2.Controls.Add(this.lblFromUbication);
            this.tabPage2.Controls.Add(this.lkuUbiHasta);
            this.tabPage2.Controls.Add(this.lblToUbication);
            this.tabPage2.Controls.Add(this.lblWarehouse);
            this.tabPage2.Controls.Add(this.lkuWarehouse);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(795, 616);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Ordenes de trabajo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 442);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 13);
            this.label12.TabIndex = 108;
            this.label12.Text = "Pallets Generados";
            // 
            // grdPallets
            // 
            this.grdPallets.AllowUserToAddRows = false;
            this.grdPallets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdPallets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPallets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OT_Key,
            this.LotKeyOt,
            this.LnKey,
            this.LPN2,
            this.Cantidad2,
            this.Umkey,
            this.CompanyId});
            this.grdPallets.Location = new System.Drawing.Point(6, 458);
            this.grdPallets.Name = "grdPallets";
            this.grdPallets.Size = new System.Drawing.Size(783, 152);
            this.grdPallets.TabIndex = 107;
            // 
            // OT_Key
            // 
            this.OT_Key.HeaderText = "OT_Key";
            this.OT_Key.Name = "OT_Key";
            // 
            // LotKeyOt
            // 
            this.LotKeyOt.HeaderText = "LotKeyOt";
            this.LotKeyOt.Name = "LotKeyOt";
            // 
            // LnKey
            // 
            this.LnKey.HeaderText = "LnKey";
            this.LnKey.Name = "LnKey";
            this.LnKey.Visible = false;
            // 
            // LPN2
            // 
            this.LPN2.HeaderText = "LPN";
            this.LPN2.Name = "LPN2";
            // 
            // Cantidad2
            // 
            this.Cantidad2.HeaderText = "Cantidad";
            this.Cantidad2.Name = "Cantidad2";
            // 
            // Umkey
            // 
            this.Umkey.HeaderText = "Umkey";
            this.Umkey.Name = "Umkey";
            // 
            // CompanyId
            // 
            this.CompanyId.HeaderText = "CompanyId";
            this.CompanyId.Name = "CompanyId";
            // 
            // cbxUM
            // 
            this.cbxUM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUM.FormattingEnabled = true;
            this.cbxUM.Location = new System.Drawing.Point(715, 74);
            this.cbxUM.Name = "cbxUM";
            this.cbxUM.Size = new System.Drawing.Size(68, 21);
            this.cbxUM.TabIndex = 106;
            // 
            // lkuPuerta
            // 
            this.lkuPuerta.Enabled = false;
            this.lkuPuerta.ErrorMessage = null;
            this.lkuPuerta.Key = 0;
            this.lkuPuerta.Location = new System.Drawing.Point(224, 211);
            this.lkuPuerta.Mask = "";
            this.lkuPuerta.MinimumSize = new System.Drawing.Size(27, 23);
            this.lkuPuerta.Name = "lkuPuerta";
            this.lkuPuerta.Protected = false;
            this.lkuPuerta.Size = new System.Drawing.Size(147, 23);
            this.lkuPuerta.SysSession = null;
            this.lkuPuerta.TabIndex = 104;
            this.lkuPuerta.TextOnlyLookup = false;
            // 
            // textLookup6
            // 
            this.textLookup6.Enabled = false;
            this.textLookup6.ErrorMessage = null;
            this.textLookup6.Key = 0;
            this.textLookup6.Location = new System.Drawing.Point(224, 210);
            this.textLookup6.Mask = "";
            this.textLookup6.MinimumSize = new System.Drawing.Size(27, 23);
            this.textLookup6.Name = "textLookup6";
            this.textLookup6.Protected = false;
            this.textLookup6.Size = new System.Drawing.Size(140, 23);
            this.textLookup6.SysSession = null;
            this.textLookup6.TabIndex = 102;
            this.textLookup6.TextOnlyLookup = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(227, 192);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 103;
            this.label11.Text = "Puerta";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 193);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 101;
            this.label10.Text = "LPN";
            // 
            // txtLPN
            // 
            this.txtLPN.Location = new System.Drawing.Point(3, 213);
            this.txtLPN.Name = "txtLPN";
            this.txtLPN.Size = new System.Drawing.Size(154, 20);
            this.txtLPN.TabIndex = 100;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(646, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 99;
            this.label9.Text = "% de Frescura";
            // 
            // txtFrescura
            // 
            this.txtFrescura.Location = new System.Drawing.Point(643, 165);
            this.txtFrescura.Name = "txtFrescura";
            this.txtFrescura.Size = new System.Drawing.Size(59, 20);
            this.txtFrescura.TabIndex = 98;
            // 
            // dtpFechaFabricacion
            // 
            this.dtpFechaFabricacion.CustomFormat = "dd-MM-yyyy";
            this.dtpFechaFabricacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFabricacion.Location = new System.Drawing.Point(441, 165);
            this.dtpFechaFabricacion.Name = "dtpFechaFabricacion";
            this.dtpFechaFabricacion.Size = new System.Drawing.Size(140, 20);
            this.dtpFechaFabricacion.TabIndex = 97;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(443, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 96;
            this.label8.Text = "Fecha Fabricación";
            // 
            // dtpFechaVencimiento
            // 
            this.dtpFechaVencimiento.CustomFormat = "dd-MM-yyyy";
            this.dtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaVencimiento.Location = new System.Drawing.Point(224, 165);
            this.dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            this.dtpFechaVencimiento.Size = new System.Drawing.Size(147, 20);
            this.dtpFechaVencimiento.TabIndex = 95;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(226, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 94;
            this.label7.Text = "Fecha Vencimiento";
            // 
            // lkuLote
            // 
            this.lkuLote.Enabled = false;
            this.lkuLote.ErrorMessage = null;
            this.lkuLote.Key = 0;
            this.lkuLote.Location = new System.Drawing.Point(3, 162);
            this.lkuLote.Mask = "";
            this.lkuLote.MinimumSize = new System.Drawing.Size(27, 23);
            this.lkuLote.Name = "lkuLote";
            this.lkuLote.Protected = false;
            this.lkuLote.Size = new System.Drawing.Size(154, 23);
            this.lkuLote.SysSession = null;
            this.lkuLote.TabIndex = 93;
            this.lkuLote.TextOnlyLookup = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 92;
            this.label6.Text = "No. Lote";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 91;
            this.label5.Text = "Almacén Destino";
            // 
            // lkuAlmacenDestino
            // 
            this.lkuAlmacenDestino.Enabled = false;
            this.lkuAlmacenDestino.ErrorMessage = null;
            this.lkuAlmacenDestino.Key = 0;
            this.lkuAlmacenDestino.Location = new System.Drawing.Point(3, 118);
            this.lkuAlmacenDestino.Mask = "";
            this.lkuAlmacenDestino.MinimumSize = new System.Drawing.Size(27, 23);
            this.lkuAlmacenDestino.Name = "lkuAlmacenDestino";
            this.lkuAlmacenDestino.Protected = false;
            this.lkuAlmacenDestino.Size = new System.Drawing.Size(154, 23);
            this.lkuAlmacenDestino.SysSession = null;
            this.lkuAlmacenDestino.TabIndex = 90;
            this.lkuAlmacenDestino.TextOnlyLookup = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(712, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 89;
            this.label4.Text = "UM";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(643, 74);
            this.nudCantidad.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(59, 20);
            this.nudCantidad.TabIndex = 88;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 87;
            this.label3.Text = "ID Gaveta";
            // 
            // lkuGaveta
            // 
            this.lkuGaveta.Enabled = false;
            this.lkuGaveta.ErrorMessage = null;
            this.lkuGaveta.Key = 0;
            this.lkuGaveta.Location = new System.Drawing.Point(224, 71);
            this.lkuGaveta.Mask = "";
            this.lkuGaveta.MinimumSize = new System.Drawing.Size(27, 23);
            this.lkuGaveta.Name = "lkuGaveta";
            this.lkuGaveta.Protected = false;
            this.lkuGaveta.Size = new System.Drawing.Size(147, 23);
            this.lkuGaveta.SysSession = null;
            this.lkuGaveta.TabIndex = 86;
            this.lkuGaveta.TextOnlyLookup = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(645, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 85;
            this.label2.Text = "Cantidad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 84;
            this.label1.Text = "ID OT";
            // 
            // txtIdOt
            // 
            this.txtIdOt.Location = new System.Drawing.Point(3, 25);
            this.txtIdOt.Name = "txtIdOt";
            this.txtIdOt.Size = new System.Drawing.Size(154, 20);
            this.txtIdOt.TabIndex = 83;
            // 
            // grdOT
            // 
            this.grdOT.AllowUserToAddRows = false;
            this.grdOT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdOT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdOT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Articulo,
            this.LPN,
            this.Lote,
            this.Fecha_Vencimiento,
            this.Fecha_Fabricacion,
            this.Frescura,
            this.Cant_Cajas,
            this.UM,
            this.Cantidad,
            this.Gabeta,
            this.Ubicacion_Desde,
            this.Ubicacion_Hasta});
            this.grdOT.Location = new System.Drawing.Point(6, 268);
            this.grdOT.Name = "grdOT";
            this.grdOT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdOT.Size = new System.Drawing.Size(783, 169);
            this.grdOT.TabIndex = 82;
            this.grdOT.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdOT_CellClick);
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.No.HeaderText = "No";
            this.No.Name = "No";
            // 
            // Articulo
            // 
            this.Articulo.HeaderText = "Articulo";
            this.Articulo.Name = "Articulo";
            // 
            // LPN
            // 
            this.LPN.HeaderText = "LPN";
            this.LPN.Name = "LPN";
            // 
            // Lote
            // 
            this.Lote.HeaderText = "Lote";
            this.Lote.Name = "Lote";
            // 
            // Fecha_Vencimiento
            // 
            this.Fecha_Vencimiento.HeaderText = "Fecha_Vencimiento";
            this.Fecha_Vencimiento.Name = "Fecha_Vencimiento";
            // 
            // Fecha_Fabricacion
            // 
            this.Fecha_Fabricacion.HeaderText = "Fecha_Fabricacion";
            this.Fecha_Fabricacion.Name = "Fecha_Fabricacion";
            // 
            // Frescura
            // 
            this.Frescura.HeaderText = "Frescura";
            this.Frescura.Name = "Frescura";
            // 
            // Cant_Cajas
            // 
            this.Cant_Cajas.HeaderText = "Cant_Cajas";
            this.Cant_Cajas.Name = "Cant_Cajas";
            // 
            // UM
            // 
            this.UM.HeaderText = "UM";
            this.UM.Name = "UM";
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // Gabeta
            // 
            this.Gabeta.HeaderText = "Gabeta";
            this.Gabeta.Name = "Gabeta";
            // 
            // Ubicacion_Desde
            // 
            this.Ubicacion_Desde.HeaderText = "Ubicacion_Desde";
            this.Ubicacion_Desde.Name = "Ubicacion_Desde";
            // 
            // Ubicacion_Hasta
            // 
            this.Ubicacion_Hasta.HeaderText = "Ubicacion_Hasta";
            this.Ubicacion_Hasta.Name = "Ubicacion_Hasta";
            // 
            // lkuArticulo
            // 
            this.lkuArticulo.Enabled = false;
            this.lkuArticulo.ErrorMessage = null;
            this.lkuArticulo.Key = 0;
            this.lkuArticulo.Location = new System.Drawing.Point(441, 71);
            this.lkuArticulo.Mask = "";
            this.lkuArticulo.MinimumSize = new System.Drawing.Size(27, 23);
            this.lkuArticulo.Name = "lkuArticulo";
            this.lkuArticulo.Protected = false;
            this.lkuArticulo.Size = new System.Drawing.Size(143, 23);
            this.lkuArticulo.SysSession = null;
            this.lkuArticulo.TabIndex = 81;
            this.lkuArticulo.TextOnlyLookup = false;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(445, 53);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(44, 13);
            this.lblItem.TabIndex = 80;
            this.lblItem.Text = "Artículo";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(686, 241);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(97, 23);
            this.btnConfirm.TabIndex = 79;
            this.btnConfirm.Text = "Aceptar";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // lkuFromGate
            // 
            this.lkuFromGate.Enabled = false;
            this.lkuFromGate.ErrorMessage = null;
            this.lkuFromGate.Key = 0;
            this.lkuFromGate.Location = new System.Drawing.Point(441, 212);
            this.lkuFromGate.Mask = "";
            this.lkuFromGate.MinimumSize = new System.Drawing.Size(27, 23);
            this.lkuFromGate.Name = "lkuFromGate";
            this.lkuFromGate.Protected = false;
            this.lkuFromGate.Size = new System.Drawing.Size(140, 23);
            this.lkuFromGate.SysSession = null;
            this.lkuFromGate.TabIndex = 77;
            this.lkuFromGate.TextOnlyLookup = false;
            // 
            // dtpOT
            // 
            this.dtpOT.CustomFormat = "dd-MM-yyyy";
            this.dtpOT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOT.Location = new System.Drawing.Point(441, 25);
            this.dtpOT.Name = "dtpOT";
            this.dtpOT.Size = new System.Drawing.Size(140, 20);
            this.dtpOT.TabIndex = 75;
            // 
            // lkuReceipt
            // 
            this.lkuReceipt.Enabled = false;
            this.lkuReceipt.ErrorMessage = null;
            this.lkuReceipt.Key = 0;
            this.lkuReceipt.Location = new System.Drawing.Point(224, 118);
            this.lkuReceipt.Mask = "";
            this.lkuReceipt.MinimumSize = new System.Drawing.Size(27, 23);
            this.lkuReceipt.Name = "lkuReceipt";
            this.lkuReceipt.Protected = false;
            this.lkuReceipt.Size = new System.Drawing.Size(147, 23);
            this.lkuReceipt.SysSession = null;
            this.lkuReceipt.TabIndex = 78;
            this.lkuReceipt.TextOnlyLookup = false;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(443, 5);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(37, 13);
            this.lblDate.TabIndex = 74;
            this.lblDate.Text = "Fecha";
            // 
            // lblReceipt
            // 
            this.lblReceipt.AutoSize = true;
            this.lblReceipt.Location = new System.Drawing.Point(228, 98);
            this.lblReceipt.Name = "lblReceipt";
            this.lblReceipt.Size = new System.Drawing.Size(76, 13);
            this.lblReceipt.TabIndex = 76;
            this.lblReceipt.Text = "Isla de Picking";
            // 
            // lkuFromUbication
            // 
            this.lkuFromUbication.Enabled = false;
            this.lkuFromUbication.ErrorMessage = null;
            this.lkuFromUbication.Key = 0;
            this.lkuFromUbication.Location = new System.Drawing.Point(441, 211);
            this.lkuFromUbication.Mask = "";
            this.lkuFromUbication.MinimumSize = new System.Drawing.Size(27, 23);
            this.lkuFromUbication.Name = "lkuFromUbication";
            this.lkuFromUbication.Protected = false;
            this.lkuFromUbication.Size = new System.Drawing.Size(140, 23);
            this.lkuFromUbication.SysSession = null;
            this.lkuFromUbication.TabIndex = 70;
            this.lkuFromUbication.TextOnlyLookup = false;
            // 
            // lblFromUbication
            // 
            this.lblFromUbication.AutoSize = true;
            this.lblFromUbication.Location = new System.Drawing.Point(444, 193);
            this.lblFromUbication.Name = "lblFromUbication";
            this.lblFromUbication.Size = new System.Drawing.Size(89, 13);
            this.lblFromUbication.TabIndex = 71;
            this.lblFromUbication.Text = "Ubicacion Desde";
            // 
            // lkuUbiHasta
            // 
            this.lkuUbiHasta.Enabled = false;
            this.lkuUbiHasta.ErrorMessage = null;
            this.lkuUbiHasta.Key = 0;
            this.lkuUbiHasta.Location = new System.Drawing.Point(643, 212);
            this.lkuUbiHasta.Mask = "";
            this.lkuUbiHasta.MinimumSize = new System.Drawing.Size(27, 23);
            this.lkuUbiHasta.Name = "lkuUbiHasta";
            this.lkuUbiHasta.Protected = false;
            this.lkuUbiHasta.Size = new System.Drawing.Size(140, 23);
            this.lkuUbiHasta.SysSession = null;
            this.lkuUbiHasta.TabIndex = 73;
            this.lkuUbiHasta.TextOnlyLookup = false;
            // 
            // lblToUbication
            // 
            this.lblToUbication.AutoSize = true;
            this.lblToUbication.Location = new System.Drawing.Point(646, 196);
            this.lblToUbication.Name = "lblToUbication";
            this.lblToUbication.Size = new System.Drawing.Size(86, 13);
            this.lblToUbication.TabIndex = 72;
            this.lblToUbication.Text = "Ubicacion Hasta";
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Location = new System.Drawing.Point(6, 52);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(48, 13);
            this.lblWarehouse.TabIndex = 68;
            this.lblWarehouse.Text = "Almacén";
            // 
            // lkuWarehouse
            // 
            this.lkuWarehouse.Enabled = false;
            this.lkuWarehouse.ErrorMessage = null;
            this.lkuWarehouse.Key = 0;
            this.lkuWarehouse.Location = new System.Drawing.Point(3, 71);
            this.lkuWarehouse.Mask = "";
            this.lkuWarehouse.MinimumSize = new System.Drawing.Size(27, 23);
            this.lkuWarehouse.Name = "lkuWarehouse";
            this.lkuWarehouse.Protected = false;
            this.lkuWarehouse.Size = new System.Drawing.Size(154, 23);
            this.lkuWarehouse.SysSession = null;
            this.lkuWarehouse.TabIndex = 67;
            this.lkuWarehouse.TextOnlyLookup = false;
            // 
            // btnImportar
            // 
            this.btnImportar.Enabled = false;
            this.btnImportar.Location = new System.Drawing.Point(717, 40);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(75, 23);
            this.btnImportar.TabIndex = 78;
            this.btnImportar.Text = "Importar";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.BtnImportar_Click);
            // 
            // cbxEstado
            // 
            this.cbxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEstado.FormattingEnabled = true;
            this.cbxEstado.Location = new System.Drawing.Point(427, 42);
            this.cbxEstado.Name = "cbxEstado";
            this.cbxEstado.Size = new System.Drawing.Size(147, 21);
            this.cbxEstado.TabIndex = 107;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(430, 26);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 106;
            this.lblStatus.Text = "Estado";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker1_ProgressChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(620, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 108;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // WorkOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(854, 661);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbxEstado);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.menuBar1);
            this.Controls.Add(this.cbxTipoOrden);
            this.Controls.Add(this.strStatusBar);
            this.Controls.Add(this.lkuTransaccion);
            this.Controls.Add(this.lblWorkOrderNo);
            this.Controls.Add(this.lblWorkOrderType);
            this.Name = "WorkOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ordenes de Trabajo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorkOrder_FormClosing);
            this.Load += new System.EventHandler(this.WorkOrder_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdArtSelect)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPallets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Net4Sage.SageSession SysSession;
        private System.Windows.Forms.Label lblWorkOrderNo;
        private System.Windows.Forms.Label lblWorkOrderType;
        private Net4Sage.Controls.Lookup.TextLookup lkuTransaccion;
        private Net4Sage.Controls.StatusBar strStatusBar;
        private System.Windows.Forms.ComboBox cbxTipoOrden;
        private Net4Sage.Controls.MenuBar menuBar1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView grdPallets;
        private System.Windows.Forms.ComboBox cbxUM;
        private Net4Sage.Controls.Lookup.TextLookup lkuPuerta;
        private Net4Sage.Controls.Lookup.TextLookup textLookup6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtLPN;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFrescura;
        private System.Windows.Forms.DateTimePicker dtpFechaFabricacion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpFechaVencimiento;
        private System.Windows.Forms.Label label7;
        private Net4Sage.Controls.Lookup.TextLookup lkuLote;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Net4Sage.Controls.Lookup.TextLookup lkuAlmacenDestino;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label label3;
        private Net4Sage.Controls.Lookup.TextLookup lkuGaveta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdOt;
        private System.Windows.Forms.DataGridView grdOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn LPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_Vencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_Fabricacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frescura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cant_Cajas;
        private System.Windows.Forms.DataGridViewTextBoxColumn UM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gabeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ubicacion_Desde;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ubicacion_Hasta;
        private Net4Sage.Controls.Lookup.TextLookup lkuArticulo;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Button btnConfirm;
        private Net4Sage.Controls.Lookup.TextLookup lkuFromGate;
        private System.Windows.Forms.DateTimePicker dtpOT;
        private Net4Sage.Controls.Lookup.TextLookup lkuReceipt;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblReceipt;
        private Net4Sage.Controls.Lookup.TextLookup lkuFromUbication;
        private System.Windows.Forms.Label lblFromUbication;
        private Net4Sage.Controls.Lookup.TextLookup lkuUbiHasta;
        private System.Windows.Forms.Label lblToUbication;
        private System.Windows.Forms.Label lblWarehouse;
        private Net4Sage.Controls.Lookup.TextLookup lkuWarehouse;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.TextBox txtAlmacen;
        private System.Windows.Forms.ComboBox cbxUMPartida;
        private System.Windows.Forms.TextBox txtCantRecibida;
        private Net4Sage.Controls.Lookup.TextLookup lkuArticulo1;
        private System.Windows.Forms.TextBox txtPartida;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbxEstado;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridView grdArtSelect;
        private System.Windows.Forms.Button btnDistribuir;
        private System.Windows.Forms.Button btnGenerarOT;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Partida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articulo2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn UM2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recibido;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantARecibir;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantPend;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemKeyOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn UmKey2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Whsekey;
        private System.Windows.Forms.DataGridViewTextBoxColumn WhseID2;
        private System.Windows.Forms.DataGridViewTextBoxColumn POLineKey2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantRecibida;
        private System.Windows.Forms.DataGridViewTextBoxColumn OT_Key;
        private System.Windows.Forms.DataGridViewTextBoxColumn LotKeyOt;
        private System.Windows.Forms.DataGridViewTextBoxColumn LnKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn LPN2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Umkey;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyId;
        private System.Windows.Forms.Button button1;
    }
}

