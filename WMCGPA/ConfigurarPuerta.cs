using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMDataAccess.Datamodel;
using WMModuleUtils;
using Net4Sage;
using Net4Sage.CIUtils;
using Net4Sage.Controls.Lookup;
using Net4Sage.DataAccessModel;
using System.Configuration;

namespace WMCP001
{
    public partial class GenerarPuertas : Form
    {
        private List<Lookup> res = new List<Lookup>();
        private WMDBContext dbContext;
        private int idPuerta = 0;
        private int Almacen;
        private ConfPuertasTableAdapters.timWarehouseTableAdapter taAlmacen = new ConfPuertasTableAdapters.timWarehouseTableAdapter();
        private ConfPuertasTableAdapters.timwmsPuertasTableAdapter taPuerta = new ConfPuertasTableAdapters.timwmsPuertasTableAdapter();
        private ConfPuertasTableAdapters.timwmsDetallePuertasTableAdapter taDetalle = new ConfPuertasTableAdapters.timwmsDetallePuertasTableAdapter();
        public GenerarPuertas(ref SageSession session)
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
                Conexion.SaveConnectionString("WMCGPA.Properties.Settings.sage500_app_recetasConnectionString", connectionString.ProviderConnectionString.ToString());
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private int NumeroP = 0;
        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarCampos() == true)
                {
                    if(chkLetras.Checked == true)
                    {
                        if(cbxTipo.Text == "Entrada")
                        {
                            for (int i = 0; i < NudCantidad.Value; i++)
                            {
                                NumeroP++;
                                grdPuertas.Rows.Add("Puerta-Ent" + 0 + NumeroP + ObtenerValor().Skip(i).First(), cbxTipo.Text, Activa.TrueValue = true, 0);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < NudCantidad.Value; i++)
                            {
                                NumeroP++;
                                grdPuertas.Rows.Add("Puerta-Sal" + 0 + NumeroP + ObtenerValor().Skip(i).First(), cbxTipo.Text, Activa.TrueValue = true, 0);
                            }
                        }
                    }
                    else
                    {
                        if(cbxTipo.Text == "Entrada")
                        {
                            for (int i = 0; i < NudCantidad.Value; i++)
                            {
                                NumeroP++;
                                grdPuertas.Rows.Add("Puerta-Ent" + NumeroP, cbxTipo.Text, Activa.TrueValue = true, 0);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < NudCantidad.Value; i++)
                            {
                                NumeroP++;
                                grdPuertas.Rows.Add("Puerta-Sal" + NumeroP, cbxTipo.Text, Activa.TrueValue = true, 0);
                            }
                        }
                    }                    
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static IEnumerable<string> ObtenerValor()
        {
            var letras = Enumerable.Range('A', 'Z' - 'A' + 1).Select(c => (char)c).ToArray();
            var combinaciones = new List<string>();

            for (int i = 0; i < letras.Length; i++)
            {
                combinaciones.Add(letras[i].ToString());
            }
            var numeros = Enumerable.Range(0, 26).ToList();

            for (int i = 0; i < letras.Length; i++)
            {
                for (int k = 0; k < numeros.Count; k++)
                {
                    string valor = combinaciones[i] + letras[k];
                    yield return valor;                                      
                }
            }            
        }
        private void MenuBar1_OnSave(object sender, EventArgs e)
        {
            try
            {
                if (grdPuertas.RowCount > 0)
                {
                    DateTime thisDay = DateTime.Now;
                    if (idPuerta == 0)
                    {
                        taPuerta.InsertPuerta(
                                txtDescripcion.Text,
                                grdPuertas.RowCount,
                                SysSession.CompanyID,
                                Almacen,
                                SysSession.UserID,
                                thisDay.ToString(),
                                null,
                                "1"
                            );
                        ConfPuertas.timwmsPuertasDataTable DatosPuerta = taPuerta.GetDataID();
                        idPuerta = Convert.ToInt32(DatosPuerta.Rows[0]["PkeyPuerta"]);
                        MessageBox.Show("Se generaron las puertas para el almacen: " + txtDescripcion.Text, "Sage MAS 500", MessageBoxButtons.OK);
                    }
                    else
                    {
                        taPuerta.UpdatePuerta(
                                txtDescripcion.Text,
                                grdPuertas.RowCount,
                                SysSession.CompanyID,
                                Almacen,
                                SysSession.UserID,
                                thisDay.ToString(),
                                "1",
                                idPuerta
                            );
                        MessageBox.Show("Se modificaron las puertas para el almacen: " + txtDescripcion.Text, "Sage MAS 500", MessageBoxButtons.OK);
                    }
                    foreach (DataGridViewRow row in grdPuertas.Rows)
                    {
                        String Activo = "";
                        bool isCellChecked = (bool)grdPuertas.Rows[row.Index].Cells[2].Value;
                        if (isCellChecked)
                        {
                            Activo = "1";
                        }
                        else
                        {
                            Activo = "0";
                        }
                        ConfPuertas.timwmsDetallePuertasDataTable dtDetalleP = taDetalle.GetDataRow(idPuerta,Convert.ToInt32(grdPuertas.Rows[row.Index].Cells[3].Value.ToString()));
                        if(taDetalle.FillRow(dtDetalleP,idPuerta, Convert.ToInt32(grdPuertas.Rows[row.Index].Cells[3].Value.ToString())) <= 0)
                        {
                            
                            taDetalle.InsertDetalle(
                                idPuerta,
                                grdPuertas.Rows[row.Index].Cells[0].Value.ToString(),
                                grdPuertas.Rows[row.Index].Cells[1].Value.ToString(),
                                Activo
                            );
                        }
                        else
                        {
                            taDetalle.UpdateDetalle(
                                idPuerta,
                                grdPuertas.Rows[row.Index].Cells[0].Value.ToString(),
                                grdPuertas.Rows[row.Index].Cells[1].Value.ToString(),
                                Activo,
                                Convert.ToInt32(dtDetalleP.Rows[0]["PkeyDetPuerta"])
                                );
                        }
                    }
                    Deshabilitar();
                    LimpiarControles();
                    lkuAlmacen.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Debe generar minimo una puerta", "Sage MAS 500");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GenerarPuertas_Load(object sender, EventArgs e)
        {
            Deshabilitar();
        }
        public void ValidarPuerta(int almacen)
        {
            try
            {
                ConfPuertas.timwmsPuertasDataTable dtPuerta = taPuerta.GetDataExist(almacen, SysSession.CompanyID.ToString());
                if(taPuerta.FillExist(dtPuerta,almacen, SysSession.CompanyID.ToString()) <= 0)
                {
                    lkuAlmacen.Enabled = false;
                }
                else
                {
                    lkuAlmacen.Enabled = false;
                    idPuerta = Convert.ToInt32(dtPuerta.Rows[0]["PkeyPuerta"].ToString());
                    ConfPuertas.timwmsDetallePuertasDataTable dtDetallePuerta = taDetalle.GetDataExistDetalle(Convert.ToInt32(dtPuerta.Rows[0]["PkeyPuerta"].ToString()));
                    for (int i = 0; i < taDetalle.FillExistDetalle(dtDetallePuerta, Convert.ToInt32(dtPuerta.Rows[0]["PkeyPuerta"].ToString())); i++)
                    {
                        bool band;
                        if(dtDetallePuerta.Rows[i]["Blogica"].ToString() == "1")
                        {
                            band = true;
                        }
                        else
                        {
                            band = false;
                        }
                        grdPuertas.Rows.Add(dtDetallePuerta.Rows[i]["Puerta"].ToString(), dtDetallePuerta.Rows[i]["Tipo"].ToString(), band, dtDetallePuerta.Rows[i]["PkeyDetPuerta"].ToString());
                        grdPuertas.Rows[i].Cells[0].ReadOnly = true;
                        grdPuertas.Rows[i].Cells[1].ReadOnly = true;
                        grdPuertas.Rows[i].DefaultCellStyle.BackColor = Color.Azure;
                        NumeroP = i;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Deshabilitar()
        {
            cbxTipo.Enabled = NudCantidad.Enabled = grdPuertas.Enabled = btnGenerar.Enabled = chkLetras.Enabled = menuBar1.Enabled = false;
        }
        private void Habilitar()
        {
            cbxTipo.Enabled = NudCantidad.Enabled = grdPuertas.Enabled = btnGenerar.Enabled = chkLetras.Enabled = menuBar1.Enabled = true;
        }
        private void GrdPuertas_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdPuertas.IsCurrentCellDirty)
                {
                    grdPuertas.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }        
        private void LimpiarControles()
        {
            NudCantidad.Value = 0;
            txtDescripcion.Text = cbxTipo.Text = "";
            grdPuertas.Rows.Clear();
            idPuerta = 0;
            lkuAlmacen.Text = "";
            Almacen = 0;
            NumeroP = 0;
        }
        bool validarCampos()
        {
            try
            {
                if (cbxTipo.Text == "")
                {
                    MessageBox.Show("El campo tipo es obligatorio", "Sage MAS 500");
                    cbxTipo.Focus();
                    return false;
                }
                else if (NudCantidad.Value == 0)
                {
                    MessageBox.Show("El campo cantidad es obligatorio", "Sage MAS 500");
                    NudCantidad.Focus();
                    return false;
                }
                return true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }            
        }
        private void LkuAlmacen_Load(object sender, EventArgs e)
        {
            try
            {                
                ConfPuertas.timWarehouseDataTable dtAlmacen = taAlmacen.GetData(SysSession.CompanyID);
                DataRow[] rows = dtAlmacen.Select();
                for (int i = 0; i < rows.Length; i++)
                {
                    res.Add(new Lookup
                        {
                            WhseKey = Convert.ToInt32(rows[i]["WhseKey"].ToString()),
                            WhseID = rows[i]["WhseID"].ToString(),
                            Description = rows[i]["Description"].ToString()
                        });
                }
                lkuAlmacen.SetData(res);
                lkuAlmacen.Enabled = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GenerarPuertas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (grdPuertas.Rows.Count == 0)
            {
                e.Cancel = false;
            }
            else
            {
                MessageBox.Show("Guarde los cambios antes de cerrar", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
        private void LkuAlmacen_OnLookupReturn(object sender, LookupReturnEventArgs eventArgs)
        {
            for (int i = 0; i < res.Count; i++)
            {
                if (res[i].WhseID == lkuAlmacen.Text)
                {
                    txtDescripcion.Text = res[i].Description;
                    Almacen = res[i].WhseKey;
                    ValidarPuerta(Almacen);
                    break;
                }
            }
            Habilitar();
        }
        private void MenuBar1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {           
            if (e.ClickedItem.Name == "mibCancel")
            {
                LimpiarControles();
                Deshabilitar();
                lkuAlmacen.Enabled = true;
            }
            else if(e.ClickedItem.Name == "mibDelete")
            {
                try
                {
                    taPuerta.UpdatePuert(
                                "0",
                                idPuerta
                            );
                    taDetalle.UpdateDetalles(
                            "0",
                            idPuerta
                            );
                    MessageBox.Show("Se eliminaron las puertas del almacen: " + txtDescripcion.Text, "Sage MAS 500", MessageBoxButtons.OK);
                    LimpiarControles();
                    Deshabilitar();
                    lkuAlmacen.Enabled = true;
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
        }
    }
}
