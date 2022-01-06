namespace WMCP001
{
    partial class GenerarPuertas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerarPuertas));
            this.SysSession = new Net4Sage.SageSession();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxTipo = new System.Windows.Forms.ComboBox();
            this.NudCantidad = new System.Windows.Forms.NumericUpDown();
            this.grdPuertas = new System.Windows.Forms.DataGridView();
            this.Puerta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activa = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Pkey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.lkuAlmacen = new Net4Sage.Controls.Lookup.TextLookup();
            this.statusBar1 = new Net4Sage.Controls.StatusBar();
            this.chkLetras = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.NudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPuertas)).BeginInit();
            this.SuspendLayout();
            // 
            // SysSession
            // 
            this.SysSession.Parameters = null;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(397, 52);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(168, 20);
            this.txtDescripcion.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Almacen:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(323, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descripción:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(337, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Cantidad:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tipo:";
            // 
            // cbxTipo
            // 
            this.cbxTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTipo.FormattingEnabled = true;
            this.cbxTipo.Items.AddRange(new object[] {
            "Entrada",
            "Salida"});
            this.cbxTipo.Location = new System.Drawing.Point(71, 103);
            this.cbxTipo.Name = "cbxTipo";
            this.cbxTipo.Size = new System.Drawing.Size(210, 21);
            this.cbxTipo.TabIndex = 5;
            // 
            // NudCantidad
            // 
            this.NudCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NudCantidad.Location = new System.Drawing.Point(397, 104);
            this.NudCantidad.Maximum = new decimal(new int[] {
            675,
            0,
            0,
            0});
            this.NudCantidad.Name = "NudCantidad";
            this.NudCantidad.Size = new System.Drawing.Size(168, 20);
            this.NudCantidad.TabIndex = 9;
            // 
            // grdPuertas
            // 
            this.grdPuertas.AllowUserToAddRows = false;
            this.grdPuertas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdPuertas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPuertas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Puerta,
            this.Tipo,
            this.Activa,
            this.Pkey});
            this.grdPuertas.Location = new System.Drawing.Point(19, 183);
            this.grdPuertas.MultiSelect = false;
            this.grdPuertas.Name = "grdPuertas";
            this.grdPuertas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdPuertas.Size = new System.Drawing.Size(546, 276);
            this.grdPuertas.TabIndex = 10;
            this.grdPuertas.CurrentCellDirtyStateChanged += new System.EventHandler(this.GrdPuertas_CurrentCellDirtyStateChanged);
            // 
            // Puerta
            // 
            this.Puerta.HeaderText = "Puerta";
            this.Puerta.Name = "Puerta";
            this.Puerta.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Puerta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            // 
            // Activa
            // 
            this.Activa.HeaderText = "Activa";
            this.Activa.Name = "Activa";
            this.Activa.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Activa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Pkey
            // 
            this.Pkey.HeaderText = "Pkey";
            this.Pkey.Name = "Pkey";
            this.Pkey.Visible = false;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Location = new System.Drawing.Point(467, 142);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(98, 28);
            this.btnGenerar.TabIndex = 11;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.BtnGenerar_Click);
            // 
            // menuBar1
            // 
            this.menuBar1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.Mode = Net4Sage.Controls.MenuBarMode.Mantaince;
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.ShowItemToolTips = true;
            this.menuBar1.Size = new System.Drawing.Size(585, 24);
            this.menuBar1.SysSession = this.SysSession;
            this.menuBar1.TabIndex = 12;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.OnSave += new System.EventHandler(this.MenuBar1_OnSave);
            this.menuBar1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuBar1_ItemClicked);
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(32, 19);
            // 
            // lkuAlmacen
            // 
            this.lkuAlmacen.Enabled = false;
            this.lkuAlmacen.ErrorMessage = null;
            this.lkuAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkuAlmacen.Key = 0;
            this.lkuAlmacen.Location = new System.Drawing.Point(71, 51);
            this.lkuAlmacen.Mask = "";
            this.lkuAlmacen.MinimumSize = new System.Drawing.Size(27, 23);
            this.lkuAlmacen.Name = "lkuAlmacen";
            this.lkuAlmacen.Protected = false;
            this.lkuAlmacen.Size = new System.Drawing.Size(210, 23);
            this.lkuAlmacen.SysSession = null;
            this.lkuAlmacen.TabIndex = 13;
            this.lkuAlmacen.TextOnlyLookup = false;
            this.lkuAlmacen.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.LkuAlmacen_OnLookupReturn);
            this.lkuAlmacen.Load += new System.EventHandler(this.LkuAlmacen_Load);
            // 
            // statusBar1
            // 
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar1.Location = new System.Drawing.Point(0, 484);
            this.statusBar1.MinimumSize = new System.Drawing.Size(0, 31);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Navigator = null;
            this.statusBar1.Padding = new System.Windows.Forms.Padding(0, 3, 5, 3);
            this.statusBar1.Size = new System.Drawing.Size(585, 31);
            this.statusBar1.SysSession = this.SysSession;
            this.statusBar1.TabIndex = 14;
            // 
            // chkLetras
            // 
            this.chkLetras.AutoSize = true;
            this.chkLetras.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLetras.Location = new System.Drawing.Point(19, 149);
            this.chkLetras.Name = "chkLetras";
            this.chkLetras.Size = new System.Drawing.Size(151, 17);
            this.chkLetras.TabIndex = 15;
            this.chkLetras.Text = "Generar puertas con letras";
            this.chkLetras.UseVisualStyleBackColor = true;
            // 
            // GenerarPuertas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 515);
            this.Controls.Add(this.chkLetras);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.lkuAlmacen);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.grdPuertas);
            this.Controls.Add(this.NudCantidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxTipo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.menuBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar1;
            this.Name = "GenerarPuertas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar puertas de almacen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GenerarPuertas_FormClosing);
            this.Load += new System.EventHandler(this.GenerarPuertas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPuertas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Net4Sage.SageSession SysSession;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxTipo;
        private System.Windows.Forms.NumericUpDown NudCantidad;
        private System.Windows.Forms.DataGridView grdPuertas;
        private System.Windows.Forms.Button btnGenerar;
        public System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        public Net4Sage.Controls.MenuBar menuBar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Puerta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Activa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pkey;
        private Net4Sage.Controls.Lookup.TextLookup lkuAlmacen;
        private Net4Sage.Controls.StatusBar statusBar1;
        private System.Windows.Forms.CheckBox chkLetras;
    }
}

