using System.Windows.Forms;

namespace WMCP001
{
    partial class MaintenanceParameter : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaintenanceParameter));
            this.SysSession = new Net4Sage.SageSession();
            this.statusBar1 = new Net4Sage.Controls.StatusBar();
            this.strMenuBar = new Net4Sage.Controls.MenuBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbSKU = new System.Windows.Forms.CheckBox();
            this.cbCategoria = new System.Windows.Forms.CheckBox();
            this.cbxSalvage = new System.Windows.Forms.ComboBox();
            this.cbxFrescura = new System.Windows.Forms.ComboBox();
            this.lkuCodigo = new Net4Sage.Controls.Lookup.TextLookup();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lkuItem = new Net4Sage.Controls.Lookup.TextLookup();
            this.label1 = new System.Windows.Forms.Label();
            this.lkuCateg = new Net4Sage.Controls.Lookup.TextLookup();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dvParameters = new System.Windows.Forms.DataGridView();
            this.ColCodMercancia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSkU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFrescura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTiempoSalvage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColParameterKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BS = new System.Windows.Forms.BindingSource(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvParameters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).BeginInit();
            this.SuspendLayout();
            // 
            // SysSession
            // 
            this.SysSession.Parameters = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("SysSession.Parameters")));
            // 
            // statusBar1
            // 
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar1.Location = new System.Drawing.Point(0, 484);
            this.statusBar1.Margin = new System.Windows.Forms.Padding(4);
            this.statusBar1.MinimumSize = new System.Drawing.Size(0, 31);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Navigator = null;
            this.statusBar1.Padding = new System.Windows.Forms.Padding(0, 3, 5, 3);
            this.statusBar1.Size = new System.Drawing.Size(599, 31);
            this.statusBar1.SysSession = this.SysSession;
            this.statusBar1.TabIndex = 0;
            // 
            // strMenuBar
            // 
            this.strMenuBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.strMenuBar.Location = new System.Drawing.Point(0, 0);
            this.strMenuBar.Mode = Net4Sage.Controls.MenuBarMode.Mantaince;
            this.strMenuBar.Name = "strMenuBar";
            this.strMenuBar.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.strMenuBar.ShowItemToolTips = true;
            this.strMenuBar.Size = new System.Drawing.Size(599, 28);
            this.strMenuBar.SysSession = null;
            this.strMenuBar.TabIndex = 1;
            this.strMenuBar.Text = "menuBar1";
            this.strMenuBar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.StrMenuBar_ItemClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(587, 144);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Parámetro";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbSKU);
            this.panel1.Controls.Add(this.cbCategoria);
            this.panel1.Controls.Add(this.cbxSalvage);
            this.panel1.Controls.Add(this.cbxFrescura);
            this.panel1.Controls.Add(this.lkuCodigo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lkuItem);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lkuCateg);
            this.panel1.Location = new System.Drawing.Point(6, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 119);
            this.panel1.TabIndex = 3;
            // 
            // cbSKU
            // 
            this.cbSKU.AutoSize = true;
            this.cbSKU.Location = new System.Drawing.Point(282, 39);
            this.cbSKU.Name = "cbSKU";
            this.cbSKU.Size = new System.Drawing.Size(91, 20);
            this.cbSKU.TabIndex = 40;
            this.cbSKU.Text = "Incluir SKU";
            this.cbSKU.UseVisualStyleBackColor = true;
            this.cbSKU.CheckedChanged += new System.EventHandler(this.CbSKU_CheckedChanged);
            // 
            // cbCategoria
            // 
            this.cbCategoria.AutoSize = true;
            this.cbCategoria.Location = new System.Drawing.Point(282, 11);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(123, 20);
            this.cbCategoria.TabIndex = 39;
            this.cbCategoria.Text = "Incluir Categoria";
            this.cbCategoria.UseVisualStyleBackColor = true;
            this.cbCategoria.CheckedChanged += new System.EventHandler(this.CbCategoria_CheckedChanged);
            // 
            // cbxSalvage
            // 
            this.cbxSalvage.FormattingEnabled = true;
            this.cbxSalvage.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbxSalvage.Location = new System.Drawing.Point(318, 87);
            this.cbxSalvage.Name = "cbxSalvage";
            this.cbxSalvage.Size = new System.Drawing.Size(51, 24);
            this.cbxSalvage.TabIndex = 38;
            // 
            // cbxFrescura
            // 
            this.cbxFrescura.FormattingEnabled = true;
            this.cbxFrescura.Location = new System.Drawing.Point(97, 87);
            this.cbxFrescura.Name = "cbxFrescura";
            this.cbxFrescura.Size = new System.Drawing.Size(47, 24);
            this.cbxFrescura.TabIndex = 37;
            // 
            // lkuCodigo
            // 
            this.lkuCodigo.Enabled = false;
            this.lkuCodigo.ErrorMessage = null;
            this.lkuCodigo.Key = 0;
            this.lkuCodigo.Location = new System.Drawing.Point(154, 15);
            this.lkuCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.lkuCodigo.Mask = "";
            this.lkuCodigo.MinimumSize = new System.Drawing.Size(27, 23);
            this.lkuCodigo.Name = "lkuCodigo";
            this.lkuCodigo.Protected = false;
            this.lkuCodigo.Size = new System.Drawing.Size(75, 23);
            this.lkuCodigo.SysSession = null;
            this.lkuCodigo.TabIndex = 36;
            this.lkuCodigo.TextOnlyLookup = false;
            this.lkuCodigo.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.LkuCodigo_OnLookupReturn);
            //this.lkuCodigo.Load += new System.EventHandler(this.LkuCodigo_Load);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "Tiempo Salvage(meses)*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 29;
            this.label2.Text = "% Frescura *";
            // 
            // lkuItem
            // 
            this.lkuItem.Enabled = false;
            this.lkuItem.ErrorMessage = null;
            this.lkuItem.Key = 0;
            this.lkuItem.Location = new System.Drawing.Point(408, 39);
            this.lkuItem.Margin = new System.Windows.Forms.Padding(4);
            this.lkuItem.Mask = "";
            this.lkuItem.MinimumSize = new System.Drawing.Size(27, 23);
            this.lkuItem.Name = "lkuItem";
            this.lkuItem.Protected = false;
            this.lkuItem.Size = new System.Drawing.Size(159, 23);
            this.lkuItem.SysSession = null;
            this.lkuItem.TabIndex = 28;
            this.lkuItem.TextOnlyLookup = false;
            this.lkuItem.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.LkuItem_OnLookupReturn);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Codigo de Mercancia *";
            // 
            // lkuCateg
            // 
            this.lkuCateg.Enabled = false;
            this.lkuCateg.ErrorMessage = null;
            this.lkuCateg.Key = 0;
            this.lkuCateg.Location = new System.Drawing.Point(408, 11);
            this.lkuCateg.Margin = new System.Windows.Forms.Padding(4);
            this.lkuCateg.Mask = "";
            this.lkuCateg.MinimumSize = new System.Drawing.Size(27, 23);
            this.lkuCateg.Name = "lkuCateg";
            this.lkuCateg.Protected = false;
            this.lkuCateg.Size = new System.Drawing.Size(159, 23);
            this.lkuCateg.SysSession = null;
            this.lkuCateg.TabIndex = 2;
            this.lkuCateg.TextOnlyLookup = false;
            this.lkuCateg.OnLookupReturn += new Net4Sage.Controls.Lookup.LookupReturnEventHandler(this.LkuCateg_OnLookupReturn);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dvParameters);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(8, 194);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(585, 283);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parámetros definidos";
            // 
            // dvParameters
            // 
            this.dvParameters.AllowUserToAddRows = false;
            this.dvParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvParameters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCodMercancia,
            this.ColCategoria,
            this.ColSkU,
            this.ColFrescura,
            this.ColTiempoSalvage,
            this.ColParameterKey});
            this.dvParameters.Location = new System.Drawing.Point(5, 29);
            this.dvParameters.Margin = new System.Windows.Forms.Padding(2);
            this.dvParameters.MultiSelect = false;
            this.dvParameters.Name = "dvParameters";
            this.dvParameters.RowHeadersWidth = 51;
            this.dvParameters.RowTemplate.Height = 24;
            this.dvParameters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvParameters.Size = new System.Drawing.Size(574, 248);
            this.dvParameters.TabIndex = 0;
            this.dvParameters.Click += new System.EventHandler(this.DvParameters_Click);
            // 
            // ColCodMercancia
            // 
            this.ColCodMercancia.HeaderText = "Código de Mercancía";
            this.ColCodMercancia.MinimumWidth = 6;
            this.ColCodMercancia.Name = "ColCodMercancia";
            this.ColCodMercancia.ReadOnly = true;
            this.ColCodMercancia.Width = 125;
            // 
            // ColCategoria
            // 
            this.ColCategoria.HeaderText = "Categoría";
            this.ColCategoria.MinimumWidth = 6;
            this.ColCategoria.Name = "ColCategoria";
            this.ColCategoria.ReadOnly = true;
            this.ColCategoria.Width = 125;
            // 
            // ColSkU
            // 
            this.ColSkU.HeaderText = "SKU";
            this.ColSkU.MinimumWidth = 6;
            this.ColSkU.Name = "ColSkU";
            this.ColSkU.ReadOnly = true;
            this.ColSkU.Width = 125;
            // 
            // ColFrescura
            // 
            this.ColFrescura.HeaderText = "% Frescura";
            this.ColFrescura.MinimumWidth = 6;
            this.ColFrescura.Name = "ColFrescura";
            this.ColFrescura.ReadOnly = true;
            this.ColFrescura.Width = 125;
            // 
            // ColTiempoSalvage
            // 
            this.ColTiempoSalvage.HeaderText = "Tiempo Salvage";
            this.ColTiempoSalvage.MinimumWidth = 6;
            this.ColTiempoSalvage.Name = "ColTiempoSalvage";
            this.ColTiempoSalvage.ReadOnly = true;
            this.ColTiempoSalvage.Width = 125;
            // 
            // ColParameterKey
            // 
            this.ColParameterKey.HeaderText = "ParameterKey";
            this.ColParameterKey.MinimumWidth = 6;
            this.ColParameterKey.Name = "ColParameterKey";
            this.ColParameterKey.Visible = false;
            this.ColParameterKey.Width = 125;
            // 
            // BS
            // 
            this.BS.DataSource = typeof(WMDataAccess.Datamodel.WMSParameter);
            // 
            // MaintenanceParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 515);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.strMenuBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.strMenuBar;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaintenanceParameter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento Parametros";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MaintenanceParameter_FormClosing);
            this.Shown += new System.EventHandler(this.Form_Show);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvParameters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Net4Sage.SageSession SysSession;
        private Net4Sage.Controls.StatusBar statusBar1;
        private Net4Sage.Controls.MenuBar strMenuBar;
        private System.Windows.Forms.BindingSource BS;
        private System.Windows.Forms.DataGridViewTextBoxColumn pickingKeyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pickingIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseUbicationsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wMSInventariesDataGridViewTextBoxColumn;
        private GroupBox groupBox1;
        private Panel panel1;
        private Label label3;
        private Label label2;
        private Net4Sage.Controls.Lookup.TextLookup lkuItem;
        private Label label1;
        private Net4Sage.Controls.Lookup.TextLookup lkuCateg;
        private GroupBox groupBox2;
        private DataGridView dvParameters;
        private Net4Sage.Controls.Lookup.TextLookup lkuCodigo;
        private DataGridViewTextBoxColumn ColCodMercancia;
        private DataGridViewTextBoxColumn ColCategoria;
        private DataGridViewTextBoxColumn ColSkU;
        private DataGridViewTextBoxColumn ColFrescura;
        private DataGridViewTextBoxColumn ColTiempoSalvage;
        private DataGridViewTextBoxColumn ColParameterKey;
        private ComboBox cbxFrescura;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ComboBox cbxSalvage;
        private CheckBox cbSKU;
        private CheckBox cbCategoria;
    }
}

