namespace WMSPAS001
{
    partial class MantPasillos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MantPasillos));
            this.SysSession = new Net4Sage.SageSession();
            this.menuBar1 = new Net4Sage.Controls.MenuBar();
            this.statusBar1 = new Net4Sage.Controls.StatusBar();
            this.grdPasillo = new System.Windows.Forms.DataGridView();
            this.Pasillo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdPasillo)).BeginInit();
            this.SuspendLayout();
            // 
            // SysSession
            // 
            this.SysSession.Parameters = null;
            // 
            // menuBar1
            // 
            this.menuBar1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.Mode = Net4Sage.Controls.MenuBarMode.Mantaince;
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuBar1.ShowItemToolTips = true;
            this.menuBar1.Size = new System.Drawing.Size(479, 24);
            this.menuBar1.SysSession = null;
            this.menuBar1.TabIndex = 12;
            this.menuBar1.Text = "menuBar1";
            this.menuBar1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuBar1_ItemClicked);
            // 
            // statusBar1
            // 
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar1.Location = new System.Drawing.Point(0, 320);
            this.statusBar1.MinimumSize = new System.Drawing.Size(0, 31);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Padding = new System.Windows.Forms.Padding(0, 3, 5, 3);
            this.statusBar1.Size = new System.Drawing.Size(479, 31);
            this.statusBar1.SysSession = this.SysSession;
            this.statusBar1.TabIndex = 13;
            // 
            // grdPasillo
            // 
            this.grdPasillo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPasillo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPasillo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPasillo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pasillo,
            this.Nombre,
            this.Key});
            this.grdPasillo.Location = new System.Drawing.Point(25, 42);
            this.grdPasillo.Name = "grdPasillo";
            this.grdPasillo.Size = new System.Drawing.Size(433, 256);
            this.grdPasillo.TabIndex = 14;
            this.grdPasillo.CurrentCellDirtyStateChanged += new System.EventHandler(this.GrdPasillo_CurrentCellDirtyStateChanged);
            // 
            // Pasillo
            // 
            this.Pasillo.HeaderText = "Pasillo";
            this.Pasillo.Name = "Pasillo";
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Key
            // 
            this.Key.HeaderText = "Key";
            this.Key.Name = "Key";
            this.Key.Visible = false;
            // 
            // MantPasillos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 351);
            this.Controls.Add(this.grdPasillo);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.menuBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MantPasillos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento a pasillos";
            this.Load += new System.EventHandler(this.MantPasillos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdPasillo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Net4Sage.SageSession SysSession;
        private Net4Sage.Controls.MenuBar menuBar1;
        private Net4Sage.Controls.StatusBar statusBar1;
        private System.Windows.Forms.DataGridView grdPasillo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pasillo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key;
    }
}

