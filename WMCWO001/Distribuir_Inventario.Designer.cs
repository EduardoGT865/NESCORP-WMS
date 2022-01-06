namespace WMCWO001
{
    partial class Distribuir_Inventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Distribuir_Inventario));
            this.SysSession = new Net4Sage.SageSession();
            this.statusBar1 = new Net4Sage.Controls.StatusBar();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxUM = new System.Windows.Forms.ComboBox();
            this.lkuPuerta = new Net4Sage.Controls.Lookup.TextLookup();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFrescura = new System.Windows.Forms.TextBox();
            this.dtpFechaFabricacion = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.lkuLote = new Net4Sage.Controls.Lookup.TextLookup();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.lkuGaveta = new Net4Sage.Controls.Lookup.TextLookup();
            this.label14 = new System.Windows.Forms.Label();
            this.lkuArticulo = new Net4Sage.Controls.Lookup.TextLookup();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.lkuWarehouse = new Net4Sage.Controls.Lookup.TextLookup();
            this.cbCertificado = new System.Windows.Forms.CheckBox();
            this.btnAceptarDI = new System.Windows.Forms.Button();
            this.grdDI = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantDistribuida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PuertaEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CertCalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gabeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_Fabricacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frescura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAlm = new System.Windows.Forms.TextBox();
            this.txtArt = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtDistribuido = new System.Windows.Forms.TextBox();
            this.txtCantPend = new System.Windows.Forms.TextBox();
            this.txtLote = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDI)).BeginInit();
            this.SuspendLayout();
            // 
            // SysSession
            // 
            this.SysSession.Parameters = null;
            // 
            // statusBar1
            // 
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar1.Location = new System.Drawing.Point(0, 419);
            this.statusBar1.MinimumSize = new System.Drawing.Size(0, 31);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Navigator = null;
            this.statusBar1.Padding = new System.Windows.Forms.Padding(0, 3, 5, 3);
            this.statusBar1.Size = new System.Drawing.Size(800, 31);
            this.statusBar1.SysSession = this.SysSession;
            this.statusBar1.TabIndex = 17;
            // 
            // menuBar1
            // 
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.Mode = Net4Sage.Controls.MenuBarMode.Transaction;
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuBar1.ShowItemToolTips = true;
            this.menuBar1.Size = new System.Drawing.Size(800, 24);
            this.menuBar1.SysSession = null;
            this.menuBar1.TabIndex = 69;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuBar1_ItemClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 71;
            this.label2.Text = "Articulo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 70;
            this.label1.Text = "Almacen:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(518, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 73;
            this.label3.Text = "Distribuido:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(469, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 72;
            this.label4.Text = "Cantidad Transferida:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(474, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 74;
            this.label5.Text = "Cantidad Pendiente:";
            // 
            // cbxUM
            // 
            this.cbxUM.FormattingEnabled = true;
            this.cbxUM.Location = new System.Drawing.Point(655, 126);
            this.cbxUM.Name = "cbxUM";
            this.cbxUM.Size = new System.Drawing.Size(68, 21);
            this.cbxUM.TabIndex = 130;
            // 
            // lkuPuerta
            // 
            this.lkuPuerta.Enabled = false;
            this.lkuPuerta.ErrorMessage = null;
            this.lkuPuerta.Key = 0;
            this.lkuPuerta.Location = new System.Drawing.Point(10, 222);
            this.lkuPuerta.Mask = "";
            this.lkuPuerta.MinimumSize = new System.Drawing.Size(27, 23);
            this.lkuPuerta.Name = "lkuPuerta";
            this.lkuPuerta.Protected = false;
            this.lkuPuerta.Size = new System.Drawing.Size(154, 23);
            this.lkuPuerta.SysSession = null;
            this.lkuPuerta.TabIndex = 129;
            this.lkuPuerta.TextOnlyLookup = false;
            this.lkuPuerta.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.LkuPuerta_OnLookupReturn);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 203);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 128;
            this.label11.Text = "Puerta";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(585, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 127;
            this.label9.Text = "% de Frescura";
            // 
            // txtFrescura
            // 
            this.txtFrescura.Location = new System.Drawing.Point(583, 173);
            this.txtFrescura.Name = "txtFrescura";
            this.txtFrescura.Size = new System.Drawing.Size(59, 20);
            this.txtFrescura.TabIndex = 126;
            // 
            // dtpFechaFabricacion
            // 
            this.dtpFechaFabricacion.CustomFormat = "dd-MM-yyyy";
            this.dtpFechaFabricacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFabricacion.Location = new System.Drawing.Point(410, 173);
            this.dtpFechaFabricacion.Name = "dtpFechaFabricacion";
            this.dtpFechaFabricacion.Size = new System.Drawing.Size(140, 20);
            this.dtpFechaFabricacion.TabIndex = 125;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(412, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 124;
            this.label8.Text = "Fecha Fabricación";
            // 
            // dtpFechaVencimiento
            // 
            this.dtpFechaVencimiento.CustomFormat = "dd-MM-yyyy";
            this.dtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaVencimiento.Location = new System.Drawing.Point(212, 174);
            this.dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            this.dtpFechaVencimiento.Size = new System.Drawing.Size(147, 20);
            this.dtpFechaVencimiento.TabIndex = 123;
            this.dtpFechaVencimiento.ValueChanged += new System.EventHandler(this.DtpFechaVencimiento_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(214, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 122;
            this.label7.Text = "Fecha Vencimiento";
            // 
            // lkuLote
            // 
            this.lkuLote.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.lkuLote.Enabled = false;
            this.lkuLote.ErrorMessage = null;
            this.lkuLote.Key = 0;
            this.lkuLote.Location = new System.Drawing.Point(10, 170);
            this.lkuLote.Mask = "";
            this.lkuLote.MinimumSize = new System.Drawing.Size(27, 23);
            this.lkuLote.Name = "lkuLote";
            this.lkuLote.Protected = false;
            this.lkuLote.Size = new System.Drawing.Size(154, 23);
            this.lkuLote.SysSession = null;
            this.lkuLote.TabIndex = 121;
            this.lkuLote.TextOnlyLookup = false;
            this.lkuLote.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.LkuLote_OnLookupReturn);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 120;
            this.label6.Text = "No. Lote";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(652, 106);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 13);
            this.label12.TabIndex = 117;
            this.label12.Text = "UM";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(583, 126);
            this.nudCantidad.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(59, 20);
            this.nudCantidad.TabIndex = 116;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(216, 104);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 115;
            this.label13.Text = "ID Gaveta";
            // 
            // lkuGaveta
            // 
            this.lkuGaveta.Enabled = false;
            this.lkuGaveta.ErrorMessage = null;
            this.lkuGaveta.Key = 0;
            this.lkuGaveta.Location = new System.Drawing.Point(212, 123);
            this.lkuGaveta.Mask = "";
            this.lkuGaveta.MinimumSize = new System.Drawing.Size(27, 23);
            this.lkuGaveta.Name = "lkuGaveta";
            this.lkuGaveta.Protected = false;
            this.lkuGaveta.Size = new System.Drawing.Size(147, 23);
            this.lkuGaveta.SysSession = null;
            this.lkuGaveta.TabIndex = 114;
            this.lkuGaveta.TextOnlyLookup = false;
            this.lkuGaveta.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.LkuGaveta_OnLookupReturn);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(585, 106);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 113;
            this.label14.Text = "Cantidad";
            // 
            // lkuArticulo
            // 
            this.lkuArticulo.Enabled = false;
            this.lkuArticulo.ErrorMessage = null;
            this.lkuArticulo.Key = 0;
            this.lkuArticulo.Location = new System.Drawing.Point(407, 123);
            this.lkuArticulo.Mask = "";
            this.lkuArticulo.MinimumSize = new System.Drawing.Size(27, 23);
            this.lkuArticulo.Name = "lkuArticulo";
            this.lkuArticulo.Protected = false;
            this.lkuArticulo.Size = new System.Drawing.Size(143, 23);
            this.lkuArticulo.SysSession = null;
            this.lkuArticulo.TabIndex = 112;
            this.lkuArticulo.TextOnlyLookup = false;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(411, 105);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(44, 13);
            this.lblItem.TabIndex = 111;
            this.lblItem.Text = "Artículo";
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Location = new System.Drawing.Point(13, 104);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(48, 13);
            this.lblWarehouse.TabIndex = 108;
            this.lblWarehouse.Text = "Almacén";
            // 
            // lkuWarehouse
            // 
            this.lkuWarehouse.Enabled = false;
            this.lkuWarehouse.ErrorMessage = null;
            this.lkuWarehouse.Key = 0;
            this.lkuWarehouse.Location = new System.Drawing.Point(10, 123);
            this.lkuWarehouse.Mask = "";
            this.lkuWarehouse.MinimumSize = new System.Drawing.Size(27, 23);
            this.lkuWarehouse.Name = "lkuWarehouse";
            this.lkuWarehouse.Protected = false;
            this.lkuWarehouse.Size = new System.Drawing.Size(154, 23);
            this.lkuWarehouse.SysSession = null;
            this.lkuWarehouse.TabIndex = 107;
            this.lkuWarehouse.TextOnlyLookup = false;
            this.lkuWarehouse.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.LkuWarehouse_OnLookupReturn);
            this.lkuWarehouse.Load += new System.EventHandler(this.LkuWarehouse_Load);
            // 
            // cbCertificado
            // 
            this.cbCertificado.AutoSize = true;
            this.cbCertificado.Location = new System.Drawing.Point(212, 228);
            this.cbCertificado.Name = "cbCertificado";
            this.cbCertificado.Size = new System.Drawing.Size(129, 17);
            this.cbCertificado.TabIndex = 131;
            this.cbCertificado.Text = "Certificado de Calidad";
            this.cbCertificado.UseVisualStyleBackColor = true;
            // 
            // btnAceptarDI
            // 
            this.btnAceptarDI.Location = new System.Drawing.Point(713, 222);
            this.btnAceptarDI.Name = "btnAceptarDI";
            this.btnAceptarDI.Size = new System.Drawing.Size(75, 23);
            this.btnAceptarDI.TabIndex = 132;
            this.btnAceptarDI.Text = "Aceptar";
            this.btnAceptarDI.UseVisualStyleBackColor = true;
            this.btnAceptarDI.Click += new System.EventHandler(this.BtnAceptarDI_Click);
            // 
            // grdDI
            // 
            this.grdDI.AllowUserToAddRows = false;
            this.grdDI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdDI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDI.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Articulo,
            this.CantDistribuida,
            this.PuertaEntrada,
            this.CertCalidad,
            this.Gabeta,
            this.NoLote,
            this.FechVencimiento,
            this.Fecha_Fabricacion,
            this.Frescura});
            this.grdDI.Location = new System.Drawing.Point(5, 254);
            this.grdDI.Name = "grdDI";
            this.grdDI.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdDI.Size = new System.Drawing.Size(783, 169);
            this.grdDI.TabIndex = 134;
            this.grdDI.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdDI_CellClick);
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.No.HeaderText = "No Partida";
            this.No.Name = "No";
            // 
            // Articulo
            // 
            this.Articulo.HeaderText = "Articulo";
            this.Articulo.Name = "Articulo";
            // 
            // CantDistribuida
            // 
            this.CantDistribuida.HeaderText = "Cant. Distribuida";
            this.CantDistribuida.Name = "CantDistribuida";
            // 
            // PuertaEntrada
            // 
            this.PuertaEntrada.HeaderText = "Puerta Entrada";
            this.PuertaEntrada.Name = "PuertaEntrada";
            // 
            // CertCalidad
            // 
            this.CertCalidad.HeaderText = "Cert. Calidad";
            this.CertCalidad.Name = "CertCalidad";
            // 
            // Gabeta
            // 
            this.Gabeta.HeaderText = "Gabeta";
            this.Gabeta.Name = "Gabeta";
            // 
            // NoLote
            // 
            this.NoLote.HeaderText = "No Lote";
            this.NoLote.Name = "NoLote";
            // 
            // FechVencimiento
            // 
            this.FechVencimiento.HeaderText = "Fecha Vencimiento";
            this.FechVencimiento.Name = "FechVencimiento";
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
            // txtAlm
            // 
            this.txtAlm.Enabled = false;
            this.txtAlm.Location = new System.Drawing.Point(71, 27);
            this.txtAlm.Name = "txtAlm";
            this.txtAlm.Size = new System.Drawing.Size(162, 20);
            this.txtAlm.TabIndex = 135;
            // 
            // txtArt
            // 
            this.txtArt.Enabled = false;
            this.txtArt.Location = new System.Drawing.Point(71, 53);
            this.txtArt.Name = "txtArt";
            this.txtArt.Size = new System.Drawing.Size(288, 20);
            this.txtArt.TabIndex = 136;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(583, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(140, 20);
            this.textBox1.TabIndex = 137;
            // 
            // txtDistribuido
            // 
            this.txtDistribuido.Enabled = false;
            this.txtDistribuido.Location = new System.Drawing.Point(583, 53);
            this.txtDistribuido.Name = "txtDistribuido";
            this.txtDistribuido.Size = new System.Drawing.Size(140, 20);
            this.txtDistribuido.TabIndex = 138;
            // 
            // txtCantPend
            // 
            this.txtCantPend.Enabled = false;
            this.txtCantPend.Location = new System.Drawing.Point(583, 79);
            this.txtCantPend.Name = "txtCantPend";
            this.txtCantPend.Size = new System.Drawing.Size(140, 20);
            this.txtCantPend.TabIndex = 139;
            // 
            // txtLote
            // 
            this.txtLote.Location = new System.Drawing.Point(12, 171);
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(123, 20);
            this.txtLote.TabIndex = 140;
            // 
            // Distribuir_Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtLote);
            this.Controls.Add(this.txtCantPend);
            this.Controls.Add(this.txtDistribuido);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtArt);
            this.Controls.Add(this.txtAlm);
            this.Controls.Add(this.grdDI);
            this.Controls.Add(this.btnAceptarDI);
            this.Controls.Add(this.cbCertificado);
            this.Controls.Add(this.cbxUM);
            this.Controls.Add(this.lkuPuerta);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtFrescura);
            this.Controls.Add(this.dtpFechaFabricacion);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpFechaVencimiento);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lkuLote);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.nudCantidad);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lkuGaveta);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lkuArticulo);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.lblWarehouse);
            this.Controls.Add(this.lkuWarehouse);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuBar1);
            this.Controls.Add(this.statusBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Distribuir_Inventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Distribuir Inventario";
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDI)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Net4Sage.SageSession SysSession;
        private Net4Sage.Controls.StatusBar statusBar1;
        private Net4Sage.Controls.MenuBar menuBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxUM;
        private Net4Sage.Controls.Lookup.TextLookup lkuPuerta;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFrescura;
        private System.Windows.Forms.DateTimePicker dtpFechaFabricacion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpFechaVencimiento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label label13;
        private Net4Sage.Controls.Lookup.TextLookup lkuGaveta;
        private System.Windows.Forms.Label label14;
        private Net4Sage.Controls.Lookup.TextLookup lkuArticulo;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblWarehouse;
        private Net4Sage.Controls.Lookup.TextLookup lkuWarehouse;
        private System.Windows.Forms.CheckBox cbCertificado;
        private System.Windows.Forms.Button btnAceptarDI;
        private System.Windows.Forms.DataGridView grdDI;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantDistribuida;
        private System.Windows.Forms.DataGridViewTextBoxColumn PuertaEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn CertCalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gabeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_Fabricacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frescura;
        private System.Windows.Forms.TextBox txtAlm;
        private System.Windows.Forms.TextBox txtArt;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtDistribuido;
        private System.Windows.Forms.TextBox txtCantPend;
        private Net4Sage.Controls.Lookup.TextLookup lkuLote;
        private System.Windows.Forms.TextBox txtLote;
    }
}