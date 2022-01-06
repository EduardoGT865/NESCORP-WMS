using Net4Sage;
using Net4Sage.Controls;
using Net4Sage.Controls.Lookup;
using Net4Sage.DataAccessModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WMDataAccess.Datamodel;
using WMCP001;

namespace WMCP001
{
    public partial class MaintenanceParameter : Form
    {
        private Context context;
        private WMDBContext dbContext;
        int Cancelar = 0;
        List<int> Multiplos = new List<int>();
        public MaintenanceParameter(ref SageSession session)
        {
            InitializeComponent();
            SysSession.InitializeSession(session); 
            //Change to Use your personal Data Model           
            System.Data.EntityClient.EntityConnectionStringBuilder connectionString = new System.Data.EntityClient.EntityConnectionStringBuilder()
            {
                Metadata = "res://*/DataModel.csdl|res://*/DataModel.ssdl|res://*/DataModel.msl",
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = SysSession.GetConnectionString()
            };
            dbContext = new WMDBContext(connectionString.ToString());
            context = new Context(connectionString.ToString());
            //conection = connectionString.ToString();
        }
        //public MaintenanceParameter()
        //{
        //    InitializeComponent();
        //}
        //public MaintenanceParameter(ref SageSession session) : this()
        //{
        //    SysSession.InitializeSession(session);
        //    //Change to Use your personal Data Model           
        //    System.Data.EntityClient.EntityConnectionStringBuilder connectionString = new System.Data.EntityClient.EntityConnectionStringBuilder()
        //    {
        //        Metadata = "res://*/DataModel.csdl|res://*/DataModel.ssdl|res://*/DataModel.msl",
        //        Provider = "System.Data.SqlClient",
        //        ProviderConnectionString = SysSession.GetConnectionString()
        //    };
        //    dbContext = new WMDBContext(connectionString.ToString());
        //    context = new Context(connectionString.ToString());
        //    //conection = connectionString.ToString();
        //}
        private void Form_Show(object sender, EventArgs e)
        {
            UpdateLookup();
            UpdateDatagridview();
            //DisableControl();            
            generarCombos();
            foreach (int multi in Multiplos)
            {
                cbxFrescura.Items.Add(multi);
            }
        }
        private void UpdateDatagridview()
        {
            var parameters = dbContext.WMSParameters.ToList();
            if (parameters.Count > 0)
            {
                dvParameters.Rows.Clear();
                foreach (WMSParameter item in parameters)
                {
                    var codigo = context.CommodityCodes.Where(p => p.CommodityCodeKey == item.CommodityCodeKey).FirstOrDefault();
                    var categoria = context.ProductCategories.Where(p => p.ProdCategoryKey == item.ProdCategoryKey).FirstOrDefault();
                    var articulo = context.Items.Where(p => p.ItemKey == item.ItemKey).FirstOrDefault();
                    dvParameters.Rows.Add(codigo.CommodityCodeID, categoria is null ? "" : categoria.ProdCategoryID, articulo is null ? "" : articulo.ItemID, item.FreshTime, item.SavageMonth, item.WMSParameterKey);
                }
                dvParameters.AllowUserToAddRows = false;
            }
            else { dvParameters.Rows.Clear(); }

        }
        private void EnableControl()
        {
            if(lkuCodigo.Text == "PT")
            {
                cbxFrescura.Enabled = false;
            }
            else
            {
                cbxFrescura.Enabled = true;
            }
            lkuCodigo.Enabled = true;        
            cbxSalvage.Enabled = true;
            cbCategoria.Enabled = true;
            cbSKU.Enabled = true;
            //lkuCateg.Enabled = true;
            //lkuItem.Enabled = true;
        }
        private void DisableControl()
        {
            lkuCodigo.Enabled = true;
            lkuCodigo.Text = "";
            cbxFrescura.Text = "";
            cbxSalvage.Text = "";
            lkuItem.Key = 0;
            lkuCateg.Key = 0;
            lkuCateg.Text = "";
            lkuItem.Text = "";
            lkuCateg.Tag = null;
            lkuItem.Tag = null;
            BS.Clear();
            lkuCateg.Enabled = false;
            lkuItem.Enabled = false;
            cbxFrescura.Enabled = false;
            cbxSalvage.Enabled = false;
            cbCategoria.Enabled = false;
            cbSKU.Enabled = false;
            cbCategoria.Checked = false;
            cbSKU.Checked = false;
        }
        bool ValidacionForm()
        {
            if (lkuCodigo.Key == 0)
            {
                MessageBox.Show("Seleccione un codigo de mercancia", "Sage MAS 500");
                lkuCodigo.Focus();
                Cancelar = 1;
                return false;
            }
            else if (cbCategoria.Checked == true && lkuCateg.Text == "")
            {
                MessageBox.Show("La categoria es obligatoria", "Sage MAS 500");
                cbCategoria.Focus();
                Cancelar = 1;
                return false;
            }
            else if (cbSKU.Checked == true && lkuItem.Text == "")
            {
                MessageBox.Show("La SKU es obligatorio", "Sage MAS 500");
                cbSKU.Focus();
                Cancelar = 1;
                return false;
            }
            else if(cbxFrescura.Enabled == true && cbxFrescura.Text == "")
            {
                MessageBox.Show("El % de frescura es obligatorio", "Sage MAS 500");
                cbxFrescura.Focus();
                Cancelar = 1;
                return false;
            }
            else if (cbxSalvage.Enabled == true && cbxSalvage.Text == "")
            {
                MessageBox.Show("El tiempo salvage es obligatorio", "Sage MAS 500");
                cbxSalvage.Focus();
                Cancelar = 1;
                return false;
            }
            return true;
        }
        private void DvParameters_Click(object sender, EventArgs e)
        {
            lkuCodigo.Text = dvParameters.CurrentRow.Cells[0].Value.ToString();
            //lkuCodigo.Text = dvParameters.Rows[dvParameters.CurrentRow.Cells[0].Value.ToString();
            //var codigo = context.CommodityCodes.Where(p => p.CommodityCodeID == lkuCodigo.Text).FirstOrDefault();
            lkuCateg.Text = dvParameters.CurrentRow.Cells[1].Value.ToString();
            var categoria = context.ProductCategories.Where(p => p.ProdCategoryID == lkuCateg.Text).FirstOrDefault();
            lkuItem.Text = dvParameters.CurrentRow.Cells[2].Value.ToString();
            var item = context.Items.Where(p => p.ItemID == lkuItem.Text).FirstOrDefault();
            cbxFrescura.Text = dvParameters.CurrentRow.Cells[3].Value.ToString();
            cbxSalvage.Text = dvParameters.CurrentRow.Cells[4].Value.ToString();
            if (item != null)
            {
                lkuItem.Key = item.ItemKey;
                cbSKU.Checked = true;
            }
            else { cbSKU.Checked = false; }
            if (categoria != null)
            {
                lkuCateg.Key = categoria.ProdCategoryKey;
                cbCategoria.Checked = true;
            }
            else { cbCategoria.Checked = false; }
            int parameterKey = Convert.ToInt32(dvParameters.CurrentRow.Cells[5].Value.ToString());
            WMSParameter data = dbContext.WMSParameters.Where(p => p.WMSParameterKey == parameterKey).FirstOrDefault();
            EnableControl();
            BS.Clear();
            BS.Add(data);
            Cancelar = 0;
        }        
        public void MostrarDatos(WMSParameter data)
        {
            cbxFrescura.Text = data.FreshTime.ToString();
            cbxSalvage.Text = data.SavageMonth.ToString();
        }
        private void generarCombos()
        {
            int n1 = 5, n2 = 20;

            for (int frescura = n1; frescura <= (n1 * n2); frescura += n1)
            {
                Multiplos.Add(frescura);
            }
        }
        private void CbCategoria_CheckedChanged(object sender, EventArgs e)
        {
            if(cbCategoria.Checked == true)
            {
                lkuCateg.Enabled = true;
            }
            else
            {
                lkuCateg.Enabled = false;
            }
        }
        private void CbSKU_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSKU.Checked == true)
            {
                lkuItem.Enabled = true;
            }
            else
            {
                lkuItem.Enabled = false;
            }
        }
        private void LkuCodigo_OnLookupReturn(object sender, LookupReturnEventArgs eventArgs)
        {
            //if (lkuCodigo.Tag != null) return;
            BS.Clear();
            //if (lkuCodigo.Text.Length > 0)
            //{
                lkuCodigo.Tag = lkuCodigo.Text;
                WMSParameter data = dbContext.WMSParameters.Where(p => p.CommodityCodeKey == lkuCodigo.Key && p.ProdCategoryKey == lkuCateg.Key && p.ItemKey == lkuItem.Key).FirstOrDefault();
                if (data != null)
                {
                    BS.Add(data);
                    statusBar1.SetFormStatus(FormBindingStatus.Editing);
                    MostrarDatos(data);
                }
                else
                {
                    BS.AddNew();
                    statusBar1.SetFormStatus(FormBindingStatus.Adding);
                }
                UpdateLookup();
                //EnableControl();
                if (lkuCodigo.Text == "PT") { cbxFrescura.Enabled = false; }
            //}
            lkuCodigo.Tag = lkuCodigo.Text;
        }
        private void LkuCateg_OnLookupReturn(object sender, LookupReturnEventArgs eventArgs)
        {
            //if (lkuCateg.Tag != null) return;
            BS.Clear();
            //if (lkuCateg.Text.Length > 0)
            //{
                lkuCateg.Tag = lkuCateg.Text;
                WMSParameter data = dbContext.WMSParameters.Where(p => p.CommodityCodeKey == lkuCodigo.Key && p.ProdCategoryKey == lkuCateg.Key && p.ItemKey == lkuItem.Key).FirstOrDefault();
                if (data != null)
                {
                    BS.Add(data);
                    statusBar1.SetFormStatus(FormBindingStatus.Editing);
                    MostrarDatos(data);
                }
                else
                {
                    BS.AddNew();
                    statusBar1.SetFormStatus(FormBindingStatus.Adding);
                }
                UpdateLookup();
                //EnableControl();
            //}
            lkuCateg.Tag = lkuCateg.Text;
        }
        private void LkuItem_OnLookupReturn(object sender, LookupReturnEventArgs eventArgs)
        {
            BS.Clear();
            //if (lkuCateg.Text.Length > 0)
            //{
                lkuItem.Tag = lkuItem.Text;
                //EnableControl();
                WMSParameter data = dbContext.WMSParameters.Where(p => p.CommodityCodeKey == lkuCodigo.Key && p.ProdCategoryKey == lkuCateg.Key && p.ItemKey == lkuItem.Key).FirstOrDefault();
                if (data != null)
                {
                    BS.Add(data);
                    statusBar1.SetFormStatus(FormBindingStatus.Editing);
                    MostrarDatos(data);
                }
                else
                {
                    BS.AddNew();
                    statusBar1.SetFormStatus(FormBindingStatus.Adding);
                }
            //}
            lkuItem.Tag = lkuItem.Text;
        }
        private void UpdateLookup()
        {
            //BS.Clear();
            lkuCodigo.SetData(context.CommodityCodes.Where(p => p.CommodityCodeKey == 9 || p.CommodityCodeKey == 10).ToList());
            //lkuCodigo.SetData(context.CommodityCodes.ToList());
            lkuCateg.SetData(context.ProductCategories.ToList());
            if (lkuCateg.Text.Length > 0 && lkuCodigo.Text.Length > 0)
            {
                List<int> CategItem = context.ProductCategoryItems.Where(b => b.ProdCategoryKey == lkuCateg.Key).Select(p => p.ItemKey).ToList();
                lkuItem.SetData(context.Items.Where(p => p.CommodityCodeKey == lkuCodigo.Key && CategItem.Contains(p.ItemKey)).ToList());
                //lkuItem.SetData(context.Items.Where(p => p.CommodityCodeKey == lkuCodigo.Key).ToList());
            }
            else { lkuItem.SetData(context.Items.ToList()); }
            EnableControl();
        }
        //private void LkuCodigo_Load(object sender, EventArgs e)
        //{
        //    lkuCodigo.SetData(context.CommodityCodes.Where(p => p.CommodityCodeKey == 9 || p.CommodityCodeKey == 10).ToList());
        //    //lkuCodigo.SetData(context.CommodityCodes.ToList());
        //    lkuCateg.SetData(context.ProductCategories.ToList());
        //    if (lkuCateg.Text.Length > 0 && lkuCodigo.Text.Length > 0)
        //    {
        //        List<int> CategItem = context.ProductCategoryItems.Where(b => b.ProdCategoryKey == lkuCateg.Key).Select(p => p.ItemKey).ToList();
        //        lkuItem.SetData(context.Items.Where(p => p.CommodityCodeKey == lkuCodigo.Key && CategItem.Contains(p.ItemKey)).ToList());
        //    }
        //    else { lkuItem.SetData(context.Items.ToList()); }
        //    EnableControl();
        //}
        private void StrMenuBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == "mibFinish")
            {
                try
                {
                    WMSParameter data = BS.Current as WMSParameter;
                    if (data != null && ValidacionForm() == true)
                    {
                        int CodeK = data.CommodityCodeKey = data.CommodityCodeKey;
                        switch (data.EntityState)
                        {
                            case EntityState.Detached:
                                if (CodeK != 0)
                                {
                                    data.CommodityCodeKey = data.CommodityCodeKey;
                                }
                                else
                                {
                                    data.CommodityCodeKey = lkuCodigo.Key;
                                }
                                data.ItemKey = lkuItem.Key;
                                data.ProdCategoryKey = lkuCateg.Key;
                                if (lkuCodigo.Text == "PT")
                                {
                                    data.FreshTime = 0;
                                }
                                else { data.FreshTime = Convert.ToInt32(cbxFrescura.Text); }
                                data.SavageMonth = Convert.ToInt32(cbxSalvage.Text);
                                data.CompanyID = SysSession.CompanyID;
                                dbContext.WMSParameters.AddObject(data);
                                break;
                            case EntityState.Unchanged:
                                if (CodeK != 0)
                                {
                                    data.CommodityCodeKey = data.CommodityCodeKey;
                                }
                                else
                                {
                                    data.CommodityCodeKey = lkuCodigo.Key;
                                }
                                data.ProdCategoryKey = lkuCateg.Key;
                                data.ItemKey = lkuItem.Key;
                                if (lkuCodigo.Text == "PT")
                                {
                                    data.FreshTime = 0;
                                }
                                else { data.FreshTime = Convert.ToInt32(cbxFrescura.Text); }
                                data.SavageMonth = Convert.ToInt32(cbxSalvage.Text);
                                break;
                        }
                        try
                        {
                            dbContext.SaveChanges();
                            dvParameters.Rows.Clear();
                            DisableControl();
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        statusBar1.SetFormStatus(FormBindingStatus.Editing);
                        UpdateDatagridview();
                        BS.Clear();
                    }
                        ConfParameterWMSForm frm = Application.OpenForms.Cast<ConfParameterWMSForm>().FirstOrDefault(x => x is ConfParameterWMSForm);
                    if (frm != null)
                    {
                        //si la instancia existe puedo acceder a sus miembros
                        frm.Show();
                        this.Close();
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (e.ClickedItem.Name == "mibSave")
            {
                try
                {
                    WMSParameter data = BS.Current as WMSParameter;
                    if (data != null && ValidacionForm() == true)
                    {
                        int CodeK = data.CommodityCodeKey = data.CommodityCodeKey;
                        switch (data.EntityState)
                        {
                            case EntityState.Detached:
                                if (CodeK != 0)
                                {
                                    data.CommodityCodeKey = data.CommodityCodeKey;
                                }
                                else
                                {
                                    data.CommodityCodeKey = lkuCodigo.Key;
                                }
                                data.ItemKey = lkuItem.Key;
                                data.ProdCategoryKey = lkuCateg.Key;
                                if (lkuCodigo.Text == "PT")
                                {
                                    data.FreshTime = 0;
                                }
                                else { data.FreshTime = Convert.ToInt32(cbxFrescura.Text); }
                                data.SavageMonth = Convert.ToInt32(cbxSalvage.Text);
                                data.CompanyID = SysSession.CompanyID;
                                dbContext.WMSParameters.AddObject(data);
                                break;
                            case EntityState.Unchanged:
                                if (CodeK != 0)
                                {
                                    data.CommodityCodeKey = data.CommodityCodeKey;
                                }
                                else
                                {
                                    data.CommodityCodeKey = lkuCodigo.Key;
                                }
                                data.ProdCategoryKey = lkuCateg.Key;
                                data.ItemKey = lkuItem.Key;
                                if (lkuCodigo.Text == "PT")
                                {
                                    data.FreshTime = 0;
                                }
                                else { data.FreshTime = Convert.ToInt32(cbxFrescura.Text); }
                                data.SavageMonth = Convert.ToInt32(cbxSalvage.Text);
                                break;
                        }
                        try
                        {
                            dbContext.SaveChanges();
                            dvParameters.Rows.Clear();
                            DisableControl();
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        statusBar1.SetFormStatus(FormBindingStatus.Editing);
                        UpdateDatagridview();
                        BS.Clear();
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.ClickedItem.Name == "mibDelete")
            {
                try
                {
                    WMSParameter data = BS.Current as WMSParameter;
                    if (data != null && data.EntityState != EntityState.Detached)
                    {
                        dbContext.WMSParameters.DeleteObject(data);
                        dbContext.SaveChanges();
                        UpdateDatagridview();                        
                        //CleanControls();
                        //UpdateLookup();
                        //return true;                        
                    }
                    //return false;
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(e.ClickedItem.Name == "mibCancel")
            {
                DisableControl();
            }
        }
        private void MaintenanceParameter_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ConfParameterWMSForm frm = Application.OpenForms.Cast<ConfParameterWMSForm>().FirstOrDefault(x => x is ConfParameterWMSForm);
                if (frm != null)
                {
                    //si la instancia existe puedo acceder a sus miembros
                    frm.Show();
                    e.Cancel = false;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}