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
using Net4Sage.Controls;
using Net4Sage.Controls.Lookup;
using Net4Sage.DataAccessModel;
using WMDataAccess.Datamodel;
using WMModuleUtils;

namespace WMCWO001
{
    public partial class Distribuir_Inventario : Form
    {
        private WMDBContext dbContext;
        private List<Puerta> ListPuerta = new List<Puerta>();
        private List<Lookup> ListAlmacen = new List<Lookup>();
        private List<Gaveta> ListGaveta = new List<Gaveta>();
        private List<CargarLote> ListLote = new List<CargarLote>();
        private DSWorkOrderTableAdapters.timWhseBinTableAdapter taBin = new DSWorkOrderTableAdapters.timWhseBinTableAdapter();
        private DSWorkOrderTableAdapters.timwmsDetallePuertasTableAdapter taDetPuerta = new DSWorkOrderTableAdapters.timwmsDetallePuertasTableAdapter();
        private DSWorkOrderTableAdapters.DistribuirTableAdapter taDistribuir = new DSWorkOrderTableAdapters.DistribuirTableAdapter();
        private DSWorkOrderTableAdapters.timWarehouseTableAdapter taAlmacen = new DSWorkOrderTableAdapters.timWarehouseTableAdapter();
        private DSWorkOrderTableAdapters.tciSurrogateKeyTableAdapter taSurrogate = new DSWorkOrderTableAdapters.tciSurrogateKeyTableAdapter();
        private DSWorkOrderTableAdapters.timwmsLoteTableAdapter taLote = new DSWorkOrderTableAdapters.timwmsLoteTableAdapter();
        private DSWorkOrderTableAdapters.timwmsDistribucionTableAdapter taDistribucion = new DSWorkOrderTableAdapters.timwmsDistribucionTableAdapter();
        private DSWorkOrderTableAdapters.UltimaTransaccionTableAdapter taUltimaTran = new DSWorkOrderTableAdapters.UltimaTransaccionTableAdapter();
        private DSWorkOrderTableAdapters.UltimoLoteTableAdapter taUltimoLote = new DSWorkOrderTableAdapters.UltimoLoteTableAdapter();
        private DSWorkOrderTableAdapters.twmParametersTableAdapter taParameter = new DSWorkOrderTableAdapters.twmParametersTableAdapter();
        private DSDevolucionesTableAdapters.DistribuirDevolucionesTableAdapter taDistDev = new DSDevolucionesTableAdapters.DistribuirDevolucionesTableAdapter();
        int Almacen, VidaItem, NPartida, IDLote,ItemKey,WhseKey,Pokey,Fkline, TranINV, Puertaid, GavetaID = 0;
        decimal CanP, Cantidad,CantidadDistri, CantAnterior;
        public Distribuir_Inventario(ref SageSession session, int TranKey, int Itemkey, decimal CantPendiente, String Tipo)
        {
            InitializeComponent();
            SysSession.InitializeSession(session);
            LoadContext();            
            nudCantidad.Value = CantPendiente;
            nudCantidad.Maximum = CantPendiente;
            txtDistribuido.Text = CantPendiente.ToString();
            CanP = CantPendiente;
            if(Tipo == "Compra")
            {
                CargarArtDistribucion(TranKey, Itemkey);
            }
            else if(Tipo == "Devoluciones")
            {
                CargarArtDistDevolucion(TranKey, Itemkey);
            }
        }
        private void LkuWarehouse_OnLookupReturn(object sender, LookupReturnEventArgs eventArgs)
        {
            try
            {
                for (int i = 0; i < ListAlmacen.Count; i++)
                {
                    if (ListAlmacen[i].WhseID == lkuWarehouse.Text)
                    {
                        ListGaveta.RemoveRange(0, ListGaveta.Count);
                        ListPuerta.RemoveRange(0, ListPuerta.Count);
                        //ListUbicacion.RemoveRange(0, ListUbicacion.Count);
                        Almacen = ListAlmacen[i].WhseKey;
                        //CargarGaveta(Almacen);
                        CargarPuerta(Almacen);
                        //CargarUbicaciones(Almacen);
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LkuGaveta_OnLookupReturn(object sender, LookupReturnEventArgs eventArgs)
        {
            try
            {
                for (int i = 0; i < ListGaveta.Count; i++)
                {
                    if (ListGaveta[i].WhseBinID == lkuGaveta.Text)
                    {
                        GavetaID = ListGaveta[i].WhseBinKey;
                        break;
                    }
                }
            }            
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GrdDI_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lkuArticulo.Tag = grdDI.CurrentRow.Cells["Articulo"].Value.ToString();
            nudCantidad.Value = Convert.ToDecimal(grdDI.CurrentRow.Cells["CantDistribuida"].Value.ToString());
            lkuPuerta.Tag = grdDI.CurrentRow.Cells["PuertaEntrada"].Value.ToString();
            if (grdDI.CurrentRow.Cells["CertCalidad"].Value.ToString() == "Si")
            {
                cbCertificado.Checked = true;
            }
            else { cbCertificado.Checked = false; }
            lkuGaveta.Tag = grdDI.CurrentRow.Cells["Gabeta"].Value.ToString();
            txtLote.Text = grdDI.CurrentRow.Cells["NoLote"].Value.ToString();
            dtpFechaVencimiento.Value = Convert.ToDateTime(grdDI.CurrentRow.Cells["FechVencimiento"].Value.ToString());
            txtFrescura.Text = grdDI.CurrentRow.Cells["Frescura"].Value.ToString();
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
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        public void CargarArtDistDevolucion(int shipkey, int itemkey)
        {
            try
            {
                DSDevoluciones.DistribuirDevolucionesDataTable dtDistDev = taDistDev.GetData(shipkey, itemkey);
                Fkline = Convert.ToInt32(dtDistDev.Rows[0]["SOLineKey"].ToString());
                ItemKey = itemkey;
                NPartida = Convert.ToInt32(dtDistDev.Rows[0]["SOLineNo"].ToString());
                txtArt.Text = dtDistDev.Rows[0]["ShortDesc"].ToString();
                DSWorkOrder.timwmsDistribucionDataTable dtDistribucion = taDistribucion.GetData(shipkey, Fkline);
                if (dtDistribucion.Count > 0)
                {
                    IDLote = Convert.ToInt32(dtDistribucion.Rows[0]["Fk_Lote"].ToString());
                    CargarLote(IDLote);
                    CantAnterior = Convert.ToDecimal(dtDistribucion.Rows[0]["Cant_Distribuida"].ToString());
                    TranINV = Convert.ToInt32(dtDistribucion.Rows[0]["Fk_TrankeyInv"].ToString());
                    DSWorkOrder.timwmsDetallePuertasDataTable dtDetPuerta = taDetPuerta.GetData_PuertaExist(Convert.ToInt32(dtDistribucion.Rows[0]["Fk_Puerta"].ToString()));
                    //grdDI.Rows.Add(NPartida, txtArt.Text, nudCantidad.Value, lkuPuerta.Text, Certificado, lkuGaveta.Text, txtLote.Text, dtpFechaVencimiento.Value, dtpFechaFabricacion.Value, txtFrescura.Text);
                    string certificado;
                    if (dtDistribucion.Rows[0]["Certf_Calidad"].ToString() == "1")
                    {
                        certificado = "Si";
                    }
                    else { certificado = "No"; }
                    DSWorkOrder.timWhseBinDataTable dtBin = taBin.GetData_GavetaExist(Convert.ToInt32(dtDistribucion.Rows[0]["Fk_Gaveta_Destino"].ToString()));
                    DSWorkOrder.timwmsLoteDataTable dtLote = taLote.GetDataExistLote(Convert.ToInt32(dtDistribucion.Rows[0]["Fk_Lote"].ToString()));
                    CantidadDistri = Convert.ToDecimal(dtDistribucion.Rows[0]["Cant_Distribuida"].ToString());
                    grdDI.Rows.Add(
                        NPartida,
                        txtArt.Text,
                        CantidadDistri,
                        dtDetPuerta.Rows[0]["Puerta"].ToString(),
                        certificado,
                        dtBin.Rows[0]["WhseBinID"].ToString(),
                        dtLote.Rows[0]["Num_Lote"].ToString(),
                        dtLote.Rows[0]["Fecha_Vencimiento"].ToString(),
                        dtLote.Rows[0]["Fecha_Fabricacion"].ToString(),
                        dtLote.Rows[0]["Porcentaje_Frescura"].ToString()
                        );
                }
                dtpFechaVencimiento.MinDate = DateTime.Now;
                txtAlm.Text = dtDistDev.Rows[0]["WhseID"].ToString();
                lkuWarehouse.Text = dtDistDev.Rows[0]["WhseID"].ToString();
                txtCantPend.Text = (Convert.ToDecimal(dtDistDev.Rows[0]["QtyShipped"].ToString()) - CanP).ToString();
                cbxUM.Text = dtDistDev.Rows[0]["UnitMeasID"].ToString();
                cbxUM.Enabled = false;
                lkuArticulo.Text = dtDistDev.Rows[0]["ShortDesc"].ToString();
                VidaItem = Convert.ToInt32(dtDistDev.Rows[0]["ShelfLife"].ToString());
                WhseKey = Convert.ToInt32(dtDistDev.Rows[0]["WhseKey"].ToString());
                Cantidad = Convert.ToDecimal(dtDistDev.Rows[0]["QtyShipped"].ToString());
                Pokey = Convert.ToInt32(dtDistDev.Rows[0]["ShipKey"].ToString());
                DSWorkOrder.timWarehouseDataTable dtAlmacen = taAlmacen.GetDataBy(SysSession.CompanyID, dtDistDev.Rows[0]["WhseID"].ToString());
                CargarPuerta(Convert.ToInt32(dtAlmacen.Rows[0]["WhseKey"].ToString()));
                Almacen = Convert.ToInt32(dtAlmacen.Rows[0]["WhseKey"].ToString());

            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CargarArtDistribucion(int po, int itemk)
        {
            try
            {
                DSWorkOrder.DistribuirDataTable dtDistribuir = taDistribuir.GetData(po, itemk);
                Fkline = Convert.ToInt32(dtDistribuir.Rows[0]["POLineKey"].ToString());
                ItemKey = itemk;
                NPartida = Convert.ToInt32(dtDistribuir.Rows[0]["POLineNo"].ToString());
                txtArt.Text = dtDistribuir.Rows[0]["Description"].ToString();
                DSWorkOrder.timwmsDistribucionDataTable dtDistribucion = taDistribucion.GetData(po, Fkline);
                if(dtDistribucion.Count > 0)
                {                    
                    IDLote = Convert.ToInt32(dtDistribucion.Rows[0]["Fk_Lote"].ToString());
                    CargarLote(IDLote);
                    CantAnterior = Convert.ToDecimal(dtDistribucion.Rows[0]["Cant_Distribuida"].ToString());
                    TranINV = Convert.ToInt32(dtDistribucion.Rows[0]["Fk_TrankeyInv"].ToString());
                    DSWorkOrder.timwmsDetallePuertasDataTable dtDetPuerta = taDetPuerta.GetData_PuertaExist(Convert.ToInt32(dtDistribucion.Rows[0]["Fk_Puerta"].ToString()));
                    //grdDI.Rows.Add(NPartida, txtArt.Text, nudCantidad.Value, lkuPuerta.Text, Certificado, lkuGaveta.Text, txtLote.Text, dtpFechaVencimiento.Value, dtpFechaFabricacion.Value, txtFrescura.Text);
                    string certificado;
                    if (dtDistribucion.Rows[0]["Certf_Calidad"].ToString() == "1")
                    {
                        certificado = "Si";
                    }
                    else { certificado = "No"; }
                    DSWorkOrder.timWhseBinDataTable dtBin = taBin.GetData_GavetaExist(Convert.ToInt32(dtDistribucion.Rows[0]["Fk_Gaveta_Destino"].ToString()));
                    DSWorkOrder.timwmsLoteDataTable dtLote = taLote.GetDataExistLote(Convert.ToInt32(dtDistribucion.Rows[0]["Fk_Lote"].ToString()));
                    CantidadDistri = Convert.ToDecimal(dtDistribucion.Rows[0]["Cant_Distribuida"].ToString());
                    grdDI.Rows.Add(
                        NPartida,
                        txtArt.Text,
                        CantidadDistri,
                        dtDetPuerta.Rows[0]["Puerta"].ToString(),
                        certificado,
                        dtBin.Rows[0]["WhseBinID"].ToString(),
                        dtLote.Rows[0]["Num_Lote"].ToString(),
                        dtLote.Rows[0]["Fecha_Vencimiento"].ToString(),
                        dtLote.Rows[0]["Fecha_Fabricacion"].ToString(),
                        dtLote.Rows[0]["Porcentaje_Frescura"].ToString()
                        );
                }               
                dtpFechaVencimiento.MinDate = DateTime.Now;                
                txtAlm.Text = dtDistribuir.Rows[0]["WhseID"].ToString();
                lkuWarehouse.Text = dtDistribuir.Rows[0]["WhseID"].ToString();                
                txtCantPend.Text = (Convert.ToDecimal(dtDistribuir.Rows[0]["QtyOrd"].ToString()) - CanP).ToString();
                cbxUM.Text = dtDistribuir.Rows[0]["UnitMeasID"].ToString();
                cbxUM.Enabled = false;
                lkuArticulo.Text = dtDistribuir.Rows[0]["Description"].ToString();
                VidaItem = Convert.ToInt32(dtDistribuir.Rows[0]["ShelfLife"].ToString());                
                WhseKey = Convert.ToInt32(dtDistribuir.Rows[0]["ShipToWhseKey"].ToString());
                Cantidad = Convert.ToDecimal(dtDistribuir.Rows[0]["QtyOrd"].ToString());
                Pokey = Convert.ToInt32(dtDistribuir.Rows[0]["POKey"].ToString());                
                DSWorkOrder.timWarehouseDataTable dtAlmacen = taAlmacen.GetDataBy(SysSession.CompanyID, dtDistribuir.Rows[0]["WhseID"].ToString());                
                CargarPuerta(Convert.ToInt32(dtAlmacen.Rows[0]["WhseKey"].ToString()));
                Almacen = Convert.ToInt32(dtAlmacen.Rows[0]["WhseKey"].ToString());
                DSWorkOrder.twmParametersDataTable dtParameter = taParameter.GetData(itemk);                
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        private void LkuLote_OnLookupReturn(object sender, LookupReturnEventArgs eventArgs)
        {
            txtLote.Text = lkuLote.Text;
            nudCantidad.Enabled = false;
            dtpFechaVencimiento.Value =Convert.ToDateTime(grdDI.Rows[0].Cells["FechVencimiento"].Value.ToString());
            lkuPuerta.Text = grdDI.Rows[0].Cells["PuertaEntrada"].Value.ToString();
            lkuGaveta.Text = grdDI.Rows[0].Cells["Gabeta"].Value.ToString();
            //lkuLote.Text = lkuLote.Tag.ToString();
            //MessageBox.Show(lkuLote.Key.ToString());
            //try
            //{
            //    for (int i = 0; i < ListLote.Count; i++)
            //    {
            //        if (ListLote[i].Num_Lote == lkuPuerta.Text)
            //        {
            //            Puertaid = ListGaveta[i].PkeyDetPuerta;
            //            break;
            //        }
            //    }
            //}
            //catch (Exception exc)
            //{
            //    MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        public void CargarLote(int FKlote)
        {
            try
            {
                DSWorkOrder.timwmsLoteDataTable dtLote = taLote.GetDataExistLote(FKlote);
                DataRow[] rows = dtLote.Select();
                for (int i = 0; i < rows.Length; i++)
                {
                    ListLote.Add(new CargarLote
                    {
                        LoteKey = Convert.ToInt32(rows[i]["Lote_Key"].ToString()),
                        Num_Lote = rows[i]["Num_Lote"].ToString()
                    });                    
                }
                
                lkuLote.SetData(ListLote);
                lkuLote.Enabled = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LkuPuerta_OnLookupReturn(object sender, LookupReturnEventArgs eventArgs)
        {
            try
            {
                for (int i = 0; i < ListPuerta.Count; i++)
                {
                    if (ListPuerta[i].Puerta1 == lkuPuerta.Text)
                    {
                        Puertaid = ListPuerta[i].PkeyDetPuerta;
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarPuerta(int Puerta)
        {
            try
            {
                DSWorkOrder.timwmsDetallePuertasDataTable dtDetPuerta = taDetPuerta.GetData(Puerta);
                DataRow[] rows = dtDetPuerta.Select();
                for (int i = 0; i < rows.Length; i++)
                {
                    ListPuerta.Add(new Puerta
                    {
                        PkeyDetPuerta = Convert.ToInt32(rows[i]["PkeyDetPuerta"].ToString()),
                        Puerta1 = rows[i]["Puerta"].ToString(),
                        Tipo = rows[i]["Tipo"].ToString()
                    });
                }
                lkuPuerta.SetData(ListPuerta);
                lkuPuerta.Enabled = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarGaveta(string binid, int Alm)
        {
            try
            {
                ListGaveta.RemoveRange(0, ListGaveta.Count);
                DSWorkOrder.timWhseBinDataTable dtBin = taBin.GetData(binid, Alm);
                DataRow[] rows = dtBin.Select();                
                for (int j = 0; j < rows.Length; j++)
                {
                    
                    ListGaveta.Add(new Gaveta
                    {
                        WhseBinKey = Convert.ToInt32(rows[j]["WhseBinKey"].ToString()),
                        WhseBinID = rows[j]["WhseBinID"].ToString(),
                        Location = rows[j]["Location"].ToString()
                    });
                }
                lkuGaveta.SetData(ListGaveta);
                lkuGaveta.Enabled = true;

            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DtpFechaVencimiento_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if(Almacen == 0) { return; }
                if (VidaItem == 0)
                {
                    MessageBox.Show("El articulo no tiene configurado la vida util", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DSWorkOrder.twmParametersDataTable dtParameter = taParameter.GetData(ItemKey);
                    if (dtParameter.Count > 0)
                    {
                        var Fecha = (dtpFechaVencimiento.Value - DateTime.Now);
                        decimal Frescura = Convert.ToDecimal(Fecha.TotalDays.ToString()) / VidaItem;
                        txtFrescura.Text = Frescura.ToString();
                        if (dtParameter.Rows[0]["CommodityCodeID"].ToString() == "PTI" && Convert.ToDecimal(dtParameter.Rows[0]["FreshTime"].ToString()) >= Frescura)
                        {
                            CargarGaveta("ME", Almacen);
                        }
                        //&& Frescura > Convert.ToDecimal(dtParameter.Rows[0]["FreshTime"].ToString())
                        else if (dtParameter.Rows[0]["CommodityCodeID"].ToString() == "PTI" || dtParameter.Rows[0]["CommodityCodeID"].ToString() == "PT")
                        {
                            CargarGaveta("BE", Almacen);
                        }
                        else if (dtParameter.Rows[0]["CommodityCodeID"].ToString() == "MP" && Convert.ToDecimal(dtParameter.Rows[0]["FreshTime"].ToString()) >= Frescura || dtParameter.Rows[0]["CommodityCodeID"].ToString() == "ME" && Convert.ToDecimal(dtParameter.Rows[0]["FreshTime"].ToString()) >= Frescura)
                        {
                            CargarGaveta("Bloqueado", Almacen);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: El articulo " + lkuArticulo.Text + " aun no tiene parametros de frescura ", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
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
            if (e.ClickedItem.Name == "mibNextNumber")
            {
                //Siguiente();                
                //lkuLote.Text = IDLote.ToString("D10");                
            }
            else if(e.ClickedItem.Name == "mibFinish")
            {
                try
                {
                    if(ValidarDatos() == true && grdDI.Rows.Count > 0)
                    {
                        int Certificado;
                        if (txtLote.Text != lkuLote.Text)
                        {
                            taLote.InsertLote(
                                    Convert.ToInt32(txtLote.Text),
                                    WhseKey,
                                    ItemKey,
                                    dtpFechaVencimiento.Value.ToString(),
                                    dtpFechaFabricacion.Value.ToString(),
                                    Convert.ToDecimal(txtFrescura.Text),
                                    "1",
                                    nudCantidad.Value,
                                    SysSession.CompanyID
                                );
                            DSWorkOrder.UltimaTransaccionDataTable dtUltimo = taUltimaTran.GetData();
                            DSWorkOrder.UltimoLoteDataTable dtUltimoLote = taUltimoLote.GetData();                            
                            if (cbCertificado.Checked == true)
                            {
                                Certificado = 1;
                            }
                            else
                            {
                                Certificado = 0;
                            }
                            taDistribucion.InsertDistribucion
                            (
                                Convert.ToInt32(dtUltimo.Rows[0]["TableTransaccion"].ToString()),
                                Pokey,
                                Fkline,
                                ItemKey,
                                nudCantidad.Value,
                                Certificado,
                                Puertaid,
                                null,
                                null,
                                Convert.ToInt32(dtUltimoLote.Rows[0]["TableLote"].ToString()),
                                Almacen,
                                GavetaID,
                                null
                            );
                        }
                        else
                        {
                            taLote.UpdateLote(
                                        //Convert.ToInt32(grdDI.CurrentRow.Cells["NoLote"].Value.ToString()),
                                        Convert.ToInt32(txtLote.Text),
                                        WhseKey,
                                        ItemKey,
                                        dtpFechaVencimiento.Value.ToString(),
                                        dtpFechaFabricacion.Value.ToString(),
                                        Convert.ToDecimal(txtFrescura.Text),
                                        "1",
                                        CantAnterior + nudCantidad.Value,
                                        //nudCantidad.Value,
                                        IDLote
                                    );
                            if (cbCertificado.Checked == true)
                            {
                                Certificado = 1;
                            }
                            else
                            {
                                Certificado = 0;
                            }
                            taDistribucion.UpdateDistribucion(
                                    CantAnterior + nudCantidad.Value,
                                    Certificado,
                                    TranINV,
                                    Pokey,
                                    Fkline
                                );
                        }                       
                        bool ban = true;
                        WorkOrder frm = Application.OpenForms.Cast<WorkOrder>().FirstOrDefault(x => x is WorkOrder);
                        if (frm != null)
                        {
                            //si la instancia existe puedo acceder a sus miembros
                            frm.CargarOT(ban);
                            this.Close();
                        }
                    }                    
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(e.ClickedItem.Name == "mibSave")
            {

            }
        }
        public void Siguiente()
        {
            DSWorkOrder.tciSurrogateKeyDataTable dtSurrogate = taSurrogate.GetData();
            IDLote = 1 + Convert.ToInt32(dtSurrogate.Rows[0]["NextKey"].ToString());
        }
        private void BtnAceptarDI_Click(object sender, EventArgs e)
        {
            try
            {
                if(ValidarDatos() == true)
                {
                    string Certificado;
                    if (cbCertificado.Checked == true)
                    {
                        Certificado = "Si";
                    }
                    else
                    {
                        Certificado = "No";
                    }
                    grdDI.Rows.Add(NPartida, txtArt.Text, nudCantidad.Value, lkuPuerta.Text, Certificado, lkuGaveta.Text, txtLote.Text, dtpFechaVencimiento.Value, dtpFechaFabricacion.Value, txtFrescura.Text);
                }                
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        private void LkuWarehouse_Load(object sender, EventArgs e)
        {
            try
            {
                DSWorkOrder.timWarehouseDataTable dtAlmacen = taAlmacen.GetData(SysSession.CompanyID);
                DataRow[] rows = dtAlmacen.Select();
                for (int i = 0; i < rows.Length; i++)
                {
                    ListAlmacen.Add(new Lookup
                    {
                        WhseKey = Convert.ToInt32(rows[i]["WhseKey"].ToString()),
                        WhseID = rows[i]["WhseID"].ToString(),
                        Description = rows[i]["Description"].ToString()
                    });
                }
                lkuWarehouse.SetData(ListAlmacen);
                lkuWarehouse.Enabled = true;
                //lkuAlmacenDestino.SetData(ListAlmacen);
                //lkuAlmacenDestino.Enabled = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        bool ValidarDatos()
        {
            if(cbxUM.Text == "")
            {
                MessageBox.Show("Error: La unidad de medida es obligatoria", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(txtLote.Text == "")
            {
                MessageBox.Show("Error: El lote es obligatorio", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txtFrescura.Text == "")
            {
                MessageBox.Show("Error: El porcentaje de frescura es obligatorio", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(lkuPuerta.Text == "")
            {
                MessageBox.Show("Error: La puerta de entrada es obligatoria", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(lkuGaveta.Text == "")
            {
                MessageBox.Show("Error: La gaveta es obligatoria", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
