using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Net4Sage;
using Net4Sage.CIUtils;
using Net4Sage.Controls.Lookup;
using WMModuleUtils;
using WMDataAccess.Datamodel;

namespace WMSPAS001
{
    public partial class MantPasillos : Form
    {
        private WMDBContext dbContext;
        private int Cont;
        private DSPasillosTableAdapters.timwmsPasillosTableAdapter taPasillos = new DSPasillosTableAdapters.timwmsPasillosTableAdapter();
        private DSPasillosTableAdapters.timwmsEstructuraAlmacenTableAdapter taEstructura = new DSPasillosTableAdapters.timwmsEstructuraAlmacenTableAdapter();
        private DSPasillosTableAdapters.timwmsUbicacionTableAdapter taUbicacion = new DSPasillosTableAdapters.timwmsUbicacionTableAdapter();
        public MantPasillos(ref SageSession session)
        {
            InitializeComponent();
            SysSession.InitializeSession(session);
            LoadContext();
        }
        private void LoadContext()
        {
            try
            {
                System.Data.EntityClient.EntityConnectionStringBuilder connectionString = new System.Data.EntityClient.EntityConnectionStringBuilder()
                {
                    Metadata = "res://*/DataModel.csdl|res://*/DataModel.ssdl|res://*/DataModel.msl",
                    Provider = "System.Data.SqlClient",
                    ProviderConnectionString = SysSession.GetConnectionString()
                };
                dbContext = new WMDBContext(connectionString.ToString());
                Conexion.SaveConnectionString("WMSPAS001.Properties.Settings.sage500_app_recetasConnectionString", connectionString.ProviderConnectionString.ToString());
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        bool Validacion()
        {
            try
            {
                foreach (DataGridViewRow row in grdPasillo.Rows)
                {
                    
                    if (row.Index == grdPasillo.Rows.Count-1 && grdPasillo.Rows[row.Index].Cells[0].Value == null && grdPasillo.Rows[row.Index].Cells[1].Value == null)
                    {
                        return true;
                    }
                    else if (grdPasillo.Rows[row.Index].Cells[0].Value == null)
                    {
                        MessageBox.Show("El campo Pasillo es obligatorio", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //grdPasillo.Rows[row.Index].DefaultCellStyle.BackColor = Color.Red;
                        break;                                      
                    }
                    else if(grdPasillo.Rows[row.Index].Cells[1].Value == null)
                    {
                        MessageBox.Show("El campo Nombre es obligatorio", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //grdPasillo.Rows[row.Index].DefaultCellStyle.BackColor = Color.Red;
                        break;                        
                    }                
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return false;
        }
        private void GrdPasillo_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdPasillo.IsCurrentCellDirty)
                {
                    grdPasillo.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CargarPasillos()
        {
            try
            {
                grdPasillo.Rows.Clear();
                DSPasillos.timwmsPasillosDataTable dtPasillo = taPasillos.GetData();
                if (taPasillos.Fill(dtPasillo) > 0)
                {
                    for (int i = 0; i < taPasillos.Fill(dtPasillo); i++)
                    {
                        Cont = i + 1;
                        grdPasillo.Rows.Add(dtPasillo.Rows[i]["Pasillo"].ToString(), dtPasillo.Rows[i]["Nombre"].ToString(), dtPasillo.Rows[i]["Pkey_Pasillo"].ToString());
                        grdPasillo.Rows[i].DefaultCellStyle.BackColor = Color.Azure;
                        grdPasillo.Rows[i].Cells[0].ReadOnly = true;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MenuBar1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == "mibFinish")
            {
                //Insertar Pasillo
                try
                {
                    if (Validacion() == true)
                    {
                        DateTime thisDay = DateTime.Now;
                        foreach (DataGridViewRow row in grdPasillo.Rows)
                        {
                            if (grdPasillo.Rows[row.Index].Cells[0].Value == null && grdPasillo.Rows[row.Index].Cells[1].Value == null)
                            {
                                break;
                            }
                            else
                            {
                                DSPasillos.timwmsPasillosDataTable dtPasillo = taPasillos.GetDataExisPasillo(grdPasillo.Rows[row.Index].Cells[0].Value.ToString());
                                if (dtPasillo.Count > 0 && grdPasillo.Rows[row.Index].DefaultCellStyle.BackColor != Color.Azure)//&& row.Index >= Cont
                                {
                                    DialogResult result = MessageBox.Show("El pasillo: " + grdPasillo.Rows[row.Index].Cells[0].Value.ToString() + " ya existe, ¿desea modificarlo?", "Sage MAS 500", MessageBoxButtons.YesNo);
                                    //DialogResult result = MessageBox.Show("El pasillo ya existe, ¿desea modificarlo?", "Sage MAS 500", MessageBoxButtons.YesNo);
                                    if (result == DialogResult.Yes)
                                    {
                                        taPasillos.UpdatePasillo(
                                            grdPasillo.Rows[row.Index].Cells[0].Value.ToString(),
                                            grdPasillo.Rows[row.Index].Cells[1].Value.ToString(),
                                            SysSession.UserID,
                                            SysSession.CompanyID,
                                            thisDay.ToString(),
                                            "1",
                                            Convert.ToInt32(dtPasillo.Rows[0]["Pkey_Pasillo"].ToString())
                                        );
                                        //MessageBox.Show("El pasillo: " + grdPasillo.CurrentRow.Cells[0].Value.ToString() + " ha sido modificado", "Sage MAS 500", MessageBoxButtons.OK);
                                        CargarPasillos();
                                    }
                                }
                                else if(grdPasillo.Rows[row.Index].DefaultCellStyle.BackColor != Color.Azure)//(row.Index >= Cont)
                                {
                                    taPasillos.InsertPasillos(
                                        grdPasillo.Rows[row.Index].Cells[0].Value.ToString(),
                                        grdPasillo.Rows[row.Index].Cells[1].Value.ToString(),
                                        SysSession.UserID,
                                        SysSession.CompanyID,
                                        thisDay.ToString(),
                                        null,
                                        "1"
                                    );
                                    MessageBox.Show("El pasillo: " + grdPasillo.Rows[row.Index].Cells[0].Value + " se cargo con exito", "Sage MAS 500", MessageBoxButtons.OK);
                                    CargarPasillos();                                    
                                }
                            }
                        }
                        this.Close();
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                        
            }
            else if(e.ClickedItem.Name == "mibSave")
            {
                //Actualizar Pasillo
                try
                {
                    if (Validacion() == true)
                    {
                        DateTime thisDay = DateTime.Now;
                        foreach (DataGridViewRow row in grdPasillo.Rows)
                        {
                            if (grdPasillo.Rows[row.Index].Cells[0].Value == null && grdPasillo.Rows[row.Index].Cells[1].Value == null)
                            {
                                break;
                            }
                            else
                            {
                                DSPasillos.timwmsPasillosDataTable dtPasillo = taPasillos.GetDataExisPasillo(grdPasillo.Rows[row.Index].Cells[0].Value.ToString());
                                if (dtPasillo.Count > 0 && grdPasillo.Rows[row.Index].DefaultCellStyle.BackColor != Color.Azure)//&& row.Index >= Cont
                                {
                                    DialogResult result = MessageBox.Show("El pasillo: " + grdPasillo.Rows[row.Index].Cells[0].Value.ToString() + " ya existe, ¿desea modificarlo?", "Sage MAS 500", MessageBoxButtons.YesNo);
                                    //DialogResult result = MessageBox.Show("El pasillo ya existe, ¿desea modificarlo?", "Sage MAS 500", MessageBoxButtons.YesNo);
                                    if (result == DialogResult.Yes)
                                    {
                                        taPasillos.UpdatePasillo(
                                            grdPasillo.Rows[row.Index].Cells[0].Value.ToString(),
                                            grdPasillo.Rows[row.Index].Cells[1].Value.ToString(),
                                            SysSession.UserID,
                                            SysSession.CompanyID,
                                            thisDay.ToString(),
                                            "1",
                                            Convert.ToInt32(dtPasillo.Rows[0]["Pkey_Pasillo"].ToString())
                                        );
                                        //MessageBox.Show("El pasillo: " + grdPasillo.CurrentRow.Cells[0].Value.ToString() + " ha sido modificado", "Sage MAS 500", MessageBoxButtons.OK);
                                    }
                                }
                                else if (grdPasillo.Rows[row.Index].DefaultCellStyle.BackColor != Color.Azure)//(row.Index >= Cont)
                                {
                                    taPasillos.InsertPasillos(
                                        grdPasillo.Rows[row.Index].Cells[0].Value.ToString(),
                                        grdPasillo.Rows[row.Index].Cells[1].Value.ToString(),
                                        SysSession.UserID,
                                        SysSession.CompanyID,
                                        thisDay.ToString(),
                                        null,
                                        "1"
                                    );
                                    MessageBox.Show("El pasillo: " + grdPasillo.Rows[row.Index].Cells[0].Value + " se cargo con exito", "Sage MAS 500", MessageBoxButtons.OK);
                                    
                                }
                            }
                        }
                        CargarPasillos();
                    }
                    //if(Validacion() == true)
                    //{
                    //    DateTime thisDay = DateTime.Now;
                    //    DSPasillos.timwmsPasillosDataTable dtPasillo = taPasillos.GetDataExisPasillo(grdPasillo.CurrentRow.Cells[0].Value.ToString());
                    //    if (dtPasillo.Count > 0)
                    //    {
                    //        DialogResult result= MessageBox.Show("El pasillo ya existe, ¿desea modificarlo?", "Sage MAS 500", MessageBoxButtons.YesNo);
                    //        if (result == DialogResult.Yes)
                    //        {
                    //            taPasillos.UpdatePasillo(
                    //                grdPasillo.CurrentRow.Cells[0].Value.ToString(),
                    //                grdPasillo.CurrentRow.Cells[1].Value.ToString(),
                    //                SysSession.UserID,
                    //                SysSession.CompanyID,
                    //                thisDay.ToString(),
                    //                "1",
                    //                Convert.ToInt32(dtPasillo.Rows[0]["Pkey_Pasillo"].ToString())
                    //            );
                    //            MessageBox.Show("El pasillo: " + grdPasillo.CurrentRow.Cells[0].Value.ToString() + " ha sido modificado", "Sage MAS 500", MessageBoxButtons.OK);
                    //            CargarPasillos();
                    //        }
                    //        else if (result == DialogResult.No)
                    //        {
                    //        }
                    //        else if (result == DialogResult.Cancel)
                    //        {
                    //        }                            
                    //    }
                    //    else //(dtPasillo.Count > 0)
                    //    {
                    //        taPasillos.InsertPasillos(
                    //                        grdPasillo.CurrentRow.Cells[0].Value.ToString(),
                    //                        grdPasillo.CurrentRow.Cells[1].Value.ToString(),
                    //                        SysSession.UserID,
                    //                        SysSession.CompanyID,
                    //                        thisDay.ToString(),
                    //                        null,
                    //                        "1"
                    //                    );
                    //        MessageBox.Show("El pasillo: " + grdPasillo.CurrentRow.Cells[0].Value.ToString() + " se generó con exito", "Sage MAS 500", MessageBoxButtons.OK);
                    //        CargarPasillos();
                    //        //MessageBox.Show("El pasillo: " + grdPasillo.CurrentRow.Cells[0].Value.ToString() + " ya existe", "Sage MAS 500", MessageBoxButtons.OK);                       
                    //    }
                    //}                                                   
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(e.ClickedItem.Name == "mibDelete")
            {
                //Eliminar Pasillo
                try
                {
                    DSPasillos.timwmsEstructuraAlmacenDataTable dtEstructura = taEstructura.GetData(Convert.ToInt32(grdPasillo.CurrentRow.Cells[2].Value.ToString()));
                    DSPasillos.timwmsUbicacionDataTable dtUbicacion = taUbicacion.GetData(Convert.ToInt32(grdPasillo.CurrentRow.Cells[2].Value.ToString()));
                    if (taEstructura.Fill(dtEstructura, Convert.ToInt32(grdPasillo.CurrentRow.Cells[2].Value.ToString())) > 0)
                    {
                        MessageBox.Show("No se puede eliminar el pasillo cuando esta asginado a una estructura", "Sage MAS 500", MessageBoxButtons.OK);
                    }
                    else if (taUbicacion.Fill(dtUbicacion, Convert.ToInt32(grdPasillo.CurrentRow.Cells[2].Value.ToString())) > 0)
                    {
                        MessageBox.Show("No se puede eliminar el pasillo cuando esta asginado a una ubicacion", "Sage MAS 500", MessageBoxButtons.OK);
                    }
                    else
                    {
                        taPasillos.DeletePas(
                            "0",
                            Convert.ToInt32(grdPasillo.CurrentRow.Cells[2].Value.ToString())
                        );
                        MessageBox.Show("El pasillo: " + grdPasillo.CurrentRow.Cells[0].Value.ToString() + " se elimino con exito", "Sage MAS 500", MessageBoxButtons.OK);
                        CargarPasillos();
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void MantPasillos_Load(object sender, EventArgs e)
        {
            CargarPasillos();
        }       
    }
}
