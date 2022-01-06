namespace WMCWO001
{
    partial class DistribuirPartida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DistribuirPartida));
            this.SysSession = new Net4Sage.SageSession();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.SelectCleanAll = new System.Windows.Forms.Button();
            this.statusBar1 = new Net4Sage.Controls.StatusBar();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.txtTranid = new System.Windows.Forms.TextBox();
            this.grdPartida = new System.Windows.Forms.DataGridView();
            this.SelecItem = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Partida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Articulo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UM2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantRecibir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeasKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Whskey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WhseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POLineKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdPartida)).BeginInit();
            this.SuspendLayout();
            // 
            // SysSession
            // 
            this.SysSession.Parameters = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Orden Compra:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Proveedor";
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(15, 408);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(103, 23);
            this.btnSelectAll.TabIndex = 3;
            this.btnSelectAll.Text = "Selecionar todo";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.BtnSelectAll_Click);
            // 
            // SelectCleanAll
            // 
            this.SelectCleanAll.Location = new System.Drawing.Point(165, 408);
            this.SelectCleanAll.Name = "SelectCleanAll";
            this.SelectCleanAll.Size = new System.Drawing.Size(75, 23);
            this.SelectCleanAll.TabIndex = 4;
            this.SelectCleanAll.Text = "Limpiar todo";
            this.SelectCleanAll.UseVisualStyleBackColor = true;
            this.SelectCleanAll.Click += new System.EventHandler(this.SelectCleanAll_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar1.Location = new System.Drawing.Point(0, 437);
            this.statusBar1.MinimumSize = new System.Drawing.Size(0, 31);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Navigator = null;
            this.statusBar1.Padding = new System.Windows.Forms.Padding(0, 3, 5, 3);
            this.statusBar1.Size = new System.Drawing.Size(800, 31);
            this.statusBar1.SysSession = null;
            this.statusBar1.TabIndex = 16;
            // 
            // menuBar1
            // 
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.Mode = Net4Sage.Controls.MenuBarMode.Mantaince;
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuBar1.ShowItemToolTips = true;
            this.menuBar1.Size = new System.Drawing.Size(800, 24);
            this.menuBar1.SysSession = null;
            this.menuBar1.TabIndex = 68;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuBar1_ItemClicked);
            // 
            // txtTranid
            // 
            this.txtTranid.Enabled = false;
            this.txtTranid.Location = new System.Drawing.Point(96, 33);
            this.txtTranid.Name = "txtTranid";
            this.txtTranid.Size = new System.Drawing.Size(195, 20);
            this.txtTranid.TabIndex = 69;
            // 
            // grdPartida
            // 
            this.grdPartida.AllowUserToAddRows = false;
            this.grdPartida.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdPartida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPartida.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelecItem,
            this.Partida,
            this.Articulo2,
            this.Descripcion,
            this.UM2,
            this.CantTotal,
            this.CantRecibir,
            this.ItemKey,
            this.MeasKey,
            this.Whskey,
            this.WhseID,
            this.POLineKey});
            this.grdPartida.Location = new System.Drawing.Point(15, 68);
            this.grdPartida.Name = "grdPartida";
            this.grdPartida.Size = new System.Drawing.Size(759, 334);
            this.grdPartida.TabIndex = 78;
            this.grdPartida.CurrentCellDirtyStateChanged += new System.EventHandler(this.GrdPartida_CurrentCellDirtyStateChanged);
            this.grdPartida.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GrdPartida_KeyPress);
            // 
            // SelecItem
            // 
            this.SelecItem.HeaderText = "Seleccionar Articulo";
            this.SelecItem.Name = "SelecItem";
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
            // CantTotal
            // 
            this.CantTotal.HeaderText = "Cantidad Total";
            this.CantTotal.Name = "CantTotal";
            // 
            // CantRecibir
            // 
            this.CantRecibir.HeaderText = "Cantidad a recibir";
            this.CantRecibir.Name = "CantRecibir";
            // 
            // ItemKey
            // 
            this.ItemKey.HeaderText = "ItemKey";
            this.ItemKey.Name = "ItemKey";
            this.ItemKey.Visible = false;
            // 
            // MeasKey
            // 
            this.MeasKey.HeaderText = "MeasKey";
            this.MeasKey.Name = "MeasKey";
            this.MeasKey.Visible = false;
            // 
            // Whskey
            // 
            this.Whskey.HeaderText = "Whskey";
            this.Whskey.Name = "Whskey";
            this.Whskey.Visible = false;
            // 
            // WhseID
            // 
            this.WhseID.HeaderText = "WhseID";
            this.WhseID.Name = "WhseID";
            this.WhseID.Visible = false;
            // 
            // POLineKey
            // 
            this.POLineKey.HeaderText = "POLineKey";
            this.POLineKey.Name = "POLineKey";
            this.POLineKey.Visible = false;
            // 
            // DistribuirPartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 468);
            this.Controls.Add(this.grdPartida);
            this.Controls.Add(this.txtTranid);
            this.Controls.Add(this.menuBar1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.SelectCleanAll);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DistribuirPartida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Distribuir Partida";
            ((System.ComponentModel.ISupportInitialize)(this.grdPartida)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Net4Sage.SageSession SysSession;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button SelectCleanAll;
        private Net4Sage.Controls.StatusBar statusBar1;
        private Net4Sage.Controls.MenuBar menuBar1;
        private System.Windows.Forms.TextBox txtTranid;
        private System.Windows.Forms.DataGridView grdPartida;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelecItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Partida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articulo2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn UM2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantRecibir;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeasKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn Whskey;
        private System.Windows.Forms.DataGridViewTextBoxColumn WhseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn POLineKey;
    }
}