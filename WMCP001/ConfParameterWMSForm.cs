using System.Windows.Forms;
using Net4Sage;
using WMDataAccess.Datamodel;
using Net4Sage.CIUtils;
using Net4Sage.Controls.Lookup;
using Net4Sage.DataAccessModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMModuleUtils;
using System.Configuration;
using System;

namespace WMCP001
{
    public partial class ConfParameterWMSForm : Form
    {
        private List<Lookup> ListAlmacen = new List<Lookup>();
        private List<Articulo> ListArt = new List<Articulo>();
        private List<Ubicacion> ListUbicacion = new List<Ubicacion>();
        private WMDBContext dbContext;
        int IDConfiguracion, Cierre, IDPall = 0;
        int? Ubicacion_Por_Defecto, Ubicacion_Art_Defecto, Ubicacion_Secundaria, Ubicacion_ResurtifoD, Ubicacion_ResurtifoSec, Ubicacion_Devolucion;
        private int Almacen, Cancelar,ArticuloID;
        private ConfWMSTableAdapters.timWarehouseTableAdapter taAlmacen = new ConfWMSTableAdapters.timWarehouseTableAdapter();
        private ConfWMSTableAdapters.timwmsUbicacionTableAdapter taUbicacion = new ConfWMSTableAdapters.timwmsUbicacionTableAdapter();
        private ConfWMSTableAdapters.timItemTableAdapter taArticulo = new ConfWMSTableAdapters.timItemTableAdapter();
        private ConfWMSTableAdapters.timwmsAlmacenArtTableAdapter taAlmArt = new ConfWMSTableAdapters.timwmsAlmacenArtTableAdapter();
        private ConfWMSTableAdapters.ListarAlmArtWMSTableAdapter ListaArt = new ConfWMSTableAdapters.ListarAlmArtWMSTableAdapter();
        private ConfWMSTableAdapters.UltimoRegistroTableAdapter taUltimoReg = new ConfWMSTableAdapters.UltimoRegistroTableAdapter();
        private ConfWMSTableAdapters.timwmsConfAlmacenTableAdapter taConfAlm = new ConfWMSTableAdapters.timwmsConfAlmacenTableAdapter();
        private ConfWMSTableAdapters.EliminarConfigTableAdapter Eliminar = new ConfWMSTableAdapters.EliminarConfigTableAdapter();
        private ConfWMSTableAdapters.timwmsAlmacenPalletTableAdapter taPallet = new ConfWMSTableAdapters.timwmsAlmacenPalletTableAdapter();
        private ConfWMSTableAdapters.ListarPalletsTableAdapter taListaPall = new ConfWMSTableAdapters.ListarPalletsTableAdapter();
        private ConfWMSTableAdapters.ExistAlmPalletTableAdapter taExistPall = new ConfWMSTableAdapters.ExistAlmPalletTableAdapter();
        public ConfParameterWMSForm()
        {
            InitializeComponent();
        }
        public ConfParameterWMSForm(ref SageSession session) : this()
        {
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
                Conexion.SaveConnectionString("WMCP001.Properties.Settings.sage500_app_recetasConnectionString", connectionString.ProviderConnectionString.ToString());
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void ConfParameterWMSForm_Load(object sender, EventArgs e)
        {
            try
            {
                DisableControls();
                //int Ubicacion, Articulo, Almacen;
                //Obtener las ubicaciones
                //ConfWMS.timwmsUbicacionDataTable datosUbications = taUbicacion.GetData(Almacen);
                //Obtener los articulos
                ConfWMS.timItemDataTable datosArticulo = taArticulo.GetData();
                //Obtener los almacenes de la tabla timwarehouse
                ConfWMS.timWarehouseDataTable datosAlmacen = taAlmacen.GetData(SysSession.CompanyID);
                Almacen = taAlmacen.Fill(datosAlmacen, SysSession.CompanyID);
                if ( datosArticulo.Count > 0 && Almacen > 0)//datosUbications.Count > 0 &&
                {
                    //ValidarConfiguracion();
                    menuBar1.Enabled = false;
                }
                //if (datosUbications.Count <= 0)
                //{
                //    MessageBox.Show("Las ubicaciones aun no han sido configuradas, por favor configuré las ubicaciones y vuelva a intentar", "Sage MAS 500");
                //    this.Close();
                //}
                if (datosArticulo.Count <= 0)
                {
                    MessageBox.Show("Los articulos aun no han sido configuradas, por favor configuré el master de articulos y vuelva a intentar", "Sage MAS 500");
                    this.Close();
                }
                if (Almacen <= 0)
                {
                    MessageBox.Show("El almacen aun no han sido configurado, por favor configuré el almacen y vuelva a intentar", "Sage MAS 500");
                    this.Close();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void MenuBar1_OnSave(object sender, EventArgs e)
        {
            if (IDConfiguracion == 0 && Validacion() == true)
            {
                try
                {
                    DateTime thisDay = DateTime.Now;
                    taConfAlm.InsertConfAlm
                        (
                            Almacen,
                            Ubicacion_Por_Defecto, 
                            Ubicacion_Secundaria, 
                            Ubicacion_ResurtifoD, 
                            Ubicacion_ResurtifoSec, 
                            Ubicacion_Devolucion,
                            (short)nudDiasEst.Value,
                            (short)nudDiasDev.Value,
                            SysSession.CompanyID,
                            SysSession.UserID,
                            thisDay.ToString(),
                            null,
                            "1"
                        );
                    DisableControls();                    
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
            else if(IDConfiguracion != 0 && Validacion() == true)
            {
                try
                {
                    DateTime thisDay = DateTime.Now;
                    ConfWMS.timwmsConfAlmacenDataTable DatosConfAlm = taConfAlm.GetDataFkAlm(Almacen, "1");
                    taConfAlm.UpdateConfAlm
                        (
                            //Convert.ToInt32(cbxAlmacen.GetItemText(cbxAlmacen.SelectedValue)),
                            Almacen,
                            Ubicacion_Por_Defecto,
                            Ubicacion_Secundaria,
                            Ubicacion_ResurtifoD,
                            Ubicacion_ResurtifoSec,
                            Ubicacion_Devolucion,
                            (short)nudDiasEst.Value,
                            (short)nudDiasDev.Value,
                            SysSession.CompanyID,
                            SysSession.UserID,
                            DatosConfAlm.Rows[0]["Fecha_Creacion"].ToString(),
                            thisDay.ToString(),
                            "1",IDConfiguracion
                        );
                    DisableControls();
                }                
                //tcConfiguracion.TabPages.IndexOf(tabPage1);
                catch (Exception exc)
                {
                    MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
        }
        bool Validacion()
        {
            try
            {
                //Articulos
                ConfWMS.timwmsAlmacenArtDataTable ExistDatos = taAlmArt.GetData(IDConfiguracion);
                //Pallets
                ConfWMS.timwmsAlmacenPalletDataTable DatosPall = taPallet.GetData(IDConfiguracion);
                if (taAlmArt.Fill(ExistDatos, IDConfiguracion) <= 0)
                {
                    MessageBox.Show("Por favor configuere los Articulos");
                    lkuArticulo.Text = "";
                    lkuArticulo.Focus();
                    Cancelar = 1;
                    return false;
                }
                //Pestaña almacenamiento
                else if (lkuAlmacen.Text == "")
                {
                    MessageBox.Show("El almacen es obligatorio", "Sage MAS 500");
                    tcConfiguracion.SelectedIndex = 0;
                    lkuAlmacen.Focus();
                    Cancelar = 1;
                    return false;
                }
                //else if (cbxUbDef.Text == "0")
                //{
                //    MessageBox.Show("La ubicacion por defecto es obligatorio", "Sage MAS 500");
                //    //tabPage3.Focus();
                //    cbxUbDef.Focus();
                //    Cancelar = 1;
                //    return false;
                //}
                //else if (cbxUbSec.Text == "0")
                //{
                //    MessageBox.Show("La ubicacion secundaria es obligatoria", "Sage MAS 500");
                //    cbxUbSec.Focus();
                //    Cancelar = 1;
                //    return false;
                //}
                ////Pestaña Resurtido y Devolución
                //else if (cbxUbDefRes.Text == "0")
                //{
                //    MessageBox.Show("La Ubicación Origen por Defecto es obligatoria", "Sage MAS 500");
                //    cbxUbDefRes.Focus();
                //    Cancelar = 1;
                //    return false;
                //}
                //else if (cbxUbDefDev.Text == "0")
                //{
                //    MessageBox.Show("La Ubicación de Entrada por Defecto es obligatoria", "Sage MAS 500");
                //    cbxUbDefDev.Focus();
                //    Cancelar = 1;
                //    return false;
                //}
                //Pestaña otros
                else if (nudDiasEst.Value <= 0)
                {
                    MessageBox.Show("Los dias de estadia son obligatorios", "Sage MAS 500");
                    tcConfiguracion.SelectedIndex = 2;
                    nudDiasEst.Focus();
                    Cancelar = 1;
                    return false;
                }
                else if (nudDiasDev.Value <= 0)
                {
                    MessageBox.Show("Los dias de devolución son obligatorios", "Sage MAS 500");
                    tcConfiguracion.SelectedIndex = 2;
                    nudDiasDev.Focus();
                    Cancelar = 1;
                    return false;
                }            
                else if (taPallet.Fill(DatosPall, IDConfiguracion) <= 0)
                {
                    MessageBox.Show("Por favor configuere los Pallets");
                    tcConfiguracion.SelectedIndex = 2;
                    txtIdPallet.Focus();
                    Cancelar = 1;
                    return false;
                }                
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }
        bool ValidarPallet()
        {
            try
            {
                if (Convert.ToInt32(txtIdPallet.TextLength) <= 0)
                {
                    MessageBox.Show("El Id Pallet es obligatorio");
                    txtIdPallet.Focus();
                    return false;
                }
                else if (nudTamaño.Value <= 0)
                {
                    MessageBox.Show("El tamaño es obligatorio");
                    nudTamaño.Focus();
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
        private void CbSKU_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbSKU.Checked == true)
                {
                    lkuUbiArtOP.Enabled = true;
                }
                else
                {
                    lkuUbiArtOP.Enabled = false;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnAgregarPall_Click(object sender, EventArgs e)
        {
            try
            {
                //ValidarConfiguracion();
                DateTime thisDay = DateTime.Now;
                if (IDConfiguracion == 0 && ValidarPallet() == true)
                {
                    taConfAlm.InsertConfAlm
                        (
                            //Convert.ToInt32(cbxAlmacen.GetItemText(cbxAlmacen.SelectedValue)),
                            Almacen,
                            null,
                            null,
                            null,
                            null,
                            null,
                            null,
                            null,
                            SysSession.CompanyID,
                            SysSession.UserID,
                            thisDay.ToString(),
                            null,
                            "1"
                        );
                    ConfWMS.UltimoRegistroDataTable dtUltimoReg= taUltimoReg.GetData_ID();
                    IDConfiguracion = Convert.ToInt32(dtUltimoReg.Rows[0]["PKeywmscf"].ToString());
                    if (cbPallDef.Checked == true)
                    {
                        taPallet.InsertAlmPall
                        (
                            IDConfiguracion,
                            txtIdPallet.Text,
                            nudTamaño.Value,
                            cbxPallDefec.Text,
                            SysSession.UserID,
                            thisDay.ToString(),
                            null,
                            "1"
                        );
                    }
                    else if (cbPallDef.Checked == false)
                    {
                        taPallet.InsertAlmPall
                        (
                            IDConfiguracion,
                            txtIdPallet.Text,
                            nudTamaño.Value,
                            null,
                            SysSession.UserID,
                            thisDay.ToString(),
                            null,
                            "1"
                        );
                    }
                    ListarPallets();
                    txtIdPallet.Text = "";
                    nudTamaño.Value = 0;
                    cbxPallDefec.Text = "";
                    cbxPallDefec.Enabled = false;
                    cbPallDef.Checked = false;
                    IDPall = 0;                                      
                }
                else if(IDConfiguracion != 0 && ValidarPallet() == true)
                {
                    ConfWMS.ExistAlmPalletDataTable ExistDatos = taExistPall.GetDataExist(IDPall);
                    if (taExistPall.FillExist(ExistDatos, IDPall) <= 0 && ValidarPallet() == true)
                    {
                        if (cbPallDef.Checked == true)
                        {
                            taPallet.InsertAlmPall
                            (
                                IDConfiguracion,
                                txtIdPallet.Text,
                                nudTamaño.Value,
                                cbxPallDefec.Text,
                                SysSession.UserID,
                                thisDay.ToString(),
                                null,
                                "1"
                            );
                        }
                        else if (cbPallDef.Checked == false)
                        {
                            taPallet.InsertAlmPall
                            (
                                IDConfiguracion,
                                txtIdPallet.Text,
                                nudTamaño.Value,
                                null,
                                SysSession.UserID,
                                thisDay.ToString(),
                                null,
                                "1"
                            );
                        }
                        ListarPallets();
                        txtIdPallet.Text = "";
                        nudTamaño.Value = 0;
                        cbxPallDefec.Text = "";
                        cbxPallDefec.Enabled = false;
                        cbPallDef.Checked = false;
                        IDPall = 0;
                    }
                    else if (taExistPall.FillExist(ExistDatos, IDPall) > 0 && ValidarPallet() == true)
                    {
                        if (cbPallDef.Checked == true)
                        {
                            taPallet.UpdatePallet
                            (
                                IDConfiguracion,
                                txtIdPallet.Text,
                                nudTamaño.Value,
                                cbxPallDefec.Text,
                                SysSession.UserID,
                                thisDay.ToString(),
                                null,
                                "1", IDPall
                            );
                        }
                        else if (cbPallDef.Checked == false)
                        {
                            taPallet.UpdatePallet
                            (
                                IDConfiguracion,
                                txtIdPallet.Text,
                                nudTamaño.Value,
                                null,
                                SysSession.UserID,
                                thisDay.ToString(),
                                null,
                                "1", IDPall
                            );
                        }
                        ListarPallets();
                        txtIdPallet.Text = "";
                        nudTamaño.Value = 0;
                        cbxPallDefec.Text = "";
                        cbxPallDefec.Enabled = false;
                        cbPallDef.Checked = false;
                        IDPall = 0;
                    }
                }
            }               
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime thisDay = DateTime.Now;
                if (IDConfiguracion == 0)
                {
                    taConfAlm.InsertConfAlm
                        (
                            //Convert.ToInt32(cbxAlmacen.GetItemText(cbxAlmacen.SelectedValue)),
                            Almacen,
                            null,
                            null,
                            null,
                            null,
                            null,
                            null,
                            null,
                            SysSession.CompanyID,
                            SysSession.UserID,
                            thisDay.ToString(),
                            null,
                            "1"
                        );
                ConfWMS.UltimoRegistroDataTable dtUltimoReg = taUltimoReg.GetData_ID();
                IDConfiguracion = Convert.ToInt32(dtUltimoReg.Rows[0]["PKeywmscf"].ToString());
                }
                //Obtener datos de la tabla timitem
                ConfWMS.timItemDataTable datosItem = taArticulo.GetDataByItemKey(ArticuloID);                              
                //Validar si el articulo exite en la configuracion
                ConfWMSTableAdapters.ExistArtAlmTableAdapter ExistArt = new ConfWMSTableAdapters.ExistArtAlmTableAdapter();
                ConfWMS.ExistArtAlmDataTable ExistDatos = ExistArt.GetDataExisArt(ArticuloID, IDConfiguracion);
                if (lkuArticulo.Text != "")
                {
                    if (ExistArt.FillExisArt(ExistDatos, ArticuloID, IDConfiguracion) <= 0)
                    {
                        if (cbSKU.Checked == true)
                        {
                            taAlmArt.InsertAlmArt
                                (
                                    ArticuloID,
                                    IDConfiguracion,
                                    datosItem.Rows[0]["ItemID"].ToString(),
                                    datosItem.Rows[0]["LongDesc"].ToString(),
                                    ArticuloID.ToString(),
                                    Ubicacion_Art_Defecto,
                                    SysSession.UserID,
                                    thisDay.ToString(),
                                    thisDay.ToString(),
                                    "1"
                                );
                        }
                        else
                        {
                            taAlmArt.InsertAlmArt
                                (
                                    ArticuloID,
                                    IDConfiguracion,
                                    datosItem.Rows[0]["ItemID"].ToString(),
                                    datosItem.Rows[0]["LongDesc"].ToString(),
                                    ArticuloID.ToString(),
                                    null,
                                    SysSession.UserID,
                                    thisDay.ToString(),
                                    thisDay.ToString(),
                                    "1"
                                );
                        }
                    }
                    else
                    {
                        MessageBox.Show("El articulo ya existe en esta configuración", "Sage MAS 500");
                    }
                    lkuArticulo.Text = "";
                    cbSKU.Checked = false;
                    lkuUbiArtOP.Text = "";
                    lblDescripcionArt.Text = "";
                    ListaArticulos();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un articulo", "Sage MAS 500");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }
        private void ValidarConfiguracion()
        {
            try
            {
                //Se cargan las ubicaciones para los lokuups
                ConfWMS.timwmsUbicacionDataTable dtUbicacion = taUbicacion.GetData(Almacen);
                DataRow[] rows = dtUbicacion.Select();
                if (dtUbicacion.Count > 0)
                {
                    for (int i = 0; i < rows.Length; i++)
                    {
                        ListUbicacion.Add(new Ubicacion
                        {
                            UbicationKey = Convert.ToInt32(rows[i]["UbicationKey"].ToString()),
                            NumUbicacionID = rows[i]["NumUbicacionID"].ToString()
                        });
                    }
                    lkuUbixDefecto.SetData(ListUbicacion);
                    lkuUbixDefecto.Enabled = true;
                    lkuUbiSec.SetData(ListUbicacion);
                    lkuUbiSec.Enabled = true;
                    lkuUbiResxDefecto.SetData(ListUbicacion);
                    lkuUbiResxDefecto.Enabled = true;
                    lkuUbiResSec.SetData(ListUbicacion);
                    lkuUbiResSec.Enabled = true;
                    lkuUbiDev.SetData(ListUbicacion);
                    lkuUbiDev.Enabled = true;
                    lkuUbiArtOP.SetData(ListUbicacion);
                    //Validar si exite una configuracion en la tabla timwmsConfAlmacen
                    ConfWMS.timwmsConfAlmacenDataTable DatosConfAlm = taConfAlm.GetDataFkAlm(Almacen, "1");
                    if (taConfAlm.FillFkAlm(DatosConfAlm, Almacen, "1") <= 0)
                    {
                        IDConfiguracion = 0;
                    }
                    else
                    {
                        IDConfiguracion = Convert.ToInt32(DatosConfAlm.Rows[0]["PKeywmscf"].ToString());
                        nudDiasEst.Value = Convert.ToInt32(DatosConfAlm.Rows[0]["Dias_Estadia"].ToString());
                        nudDiasDev.Value = Convert.ToInt32(DatosConfAlm.Rows[0]["Dias_Devolucion"].ToString());
                        //lkuUbixDefecto.Key = Convert.ToInt32(DatosConfAlm.Rows[0]["FkUbicacion_Default_PP"].ToString());
                        for (int i = 0; i < ListUbicacion.Count; i++)
                        {
                            if (DatosConfAlm.Rows[0]["FkUbicacion_Default_PP"].ToString() != "" && ListUbicacion[i].UbicationKey == Convert.ToInt32(DatosConfAlm.Rows[0]["FkUbicacion_Default_PP"].ToString()))
                            {
                                lkuUbixDefecto.Text = ListUbicacion[i].NumUbicacionID;
                                Ubicacion_Por_Defecto = ListUbicacion[i].UbicationKey; // , , , , ;

                            }
                            else if (DatosConfAlm.Rows[0]["FkUbicacion_Sec_PP"].ToString() != "" && ListUbicacion[i].UbicationKey == Convert.ToInt32(DatosConfAlm.Rows[0]["FkUbicacion_Sec_PP"].ToString()))
                            {
                                lkuUbiSec.Text = ListUbicacion[i].NumUbicacionID;
                                Ubicacion_Secundaria = ListUbicacion[i].UbicationKey;
                            }
                            else if (DatosConfAlm.Rows[0]["FkUbicacion_Default_Res"].ToString() != "" && ListUbicacion[i].UbicationKey == Convert.ToInt32(DatosConfAlm.Rows[0]["FkUbicacion_Default_Res"].ToString()))
                            {
                                lkuUbiResxDefecto.Text = ListUbicacion[i].NumUbicacionID;
                                Ubicacion_ResurtifoD = ListUbicacion[i].UbicationKey;
                            }
                            else if (DatosConfAlm.Rows[0]["FkUbicacion_Sec_Res"].ToString() != "" && ListUbicacion[i].UbicationKey == Convert.ToInt32(DatosConfAlm.Rows[0]["FkUbicacion_Sec_Res"].ToString()))
                            {
                                lkuUbiResSec.Text = ListUbicacion[i].NumUbicacionID;
                                Ubicacion_ResurtifoSec = ListUbicacion[i].UbicationKey;
                            }
                            else if (DatosConfAlm.Rows[0]["FkUbicacion_EntDef"].ToString() != "" && ListUbicacion[i].UbicationKey == Convert.ToInt32(DatosConfAlm.Rows[0]["FkUbicacion_EntDef"].ToString()))
                            {
                                lkuUbiDev.Text = ListUbicacion[i].NumUbicacionID;
                                Ubicacion_Devolucion = ListUbicacion[i].UbicationKey;
                                break;
                            }
                        }
                    }
                    //Validar si exiten articulos ligados a una configuracion en la tabla timwmsAlmacenArt 
                    ListaArticulos();
                    //Validar si exiten pallets ligados a una configuracion en la tabla timwmsAlmacenPallet 
                    ListarPallets();
                    EneableControls();
                }
                else
                {
                    MessageBox.Show("Las ubicaciones aun no han sido configuradas, por favor configuré las ubicaciones para este almacén", "Sage MAS 500");
                    DisableControls();
                }                
                
            }
            catch(Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void CbPallDef_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPallDef.Checked == true)
            {
                cbxPallDefec.Enabled = true;
            }
            else
                cbxPallDefec.Enabled = false;
        }
        private void BtnEliminarArt_Click(object sender, EventArgs e)
        {
            try
            {
                int IdArt2 = Convert.ToInt32(grdConf.CurrentRow.Cells[0].Value);
                int IdKey2 = Convert.ToInt32(grdConf.CurrentRow.Cells[5].Value);
                taAlmArt.UpdateArt("0", IdArt2, IdKey2);
                MessageBox.Show("El articulo: " + grdConf.CurrentRow.Cells[1].Value + " ha sido eliminado", "Sage MAS 500");
                ListaArticulos();
            }
            catch (Exception)
            {
                MessageBox.Show("Debe seleccionar un articulo para eliminarlo", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ListaArticulos()
        {
            try
            {
                ConfWMS.ListarAlmArtWMSDataTable DatosArt = ListaArt.GetData(Almacen);
                grdConf.DataSource = DatosArt;
                grdConf.Columns["PkeywmsAlmArt"].Visible = false;
                grdConf.Columns["FKeywmscf"].Visible = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ListarPallets()
        {
            try
            {
                ConfWMS.ListarPalletsDataTable DatosPall = taListaPall.GetData(Almacen);
                grdPallet.DataSource = DatosPall;
                grdPallet.ClearSelection();
                grdPallet.Columns["PkeywmsAlmPall"].Visible = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        private void BtnEliminarPall_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime thisDay = DateTime.Now;
                int Id_Pall = Convert.ToInt32(grdPallet.CurrentRow.Cells[2].Value.ToString());
                int Tam_Pall = Convert.ToInt32(grdPallet.CurrentRow.Cells[1].Value);
                taPallet.DeletPall("0", Id_Pall);
                MessageBox.Show("Pallet eliminado " + grdPallet.CurrentRow.Cells[0].Value.ToString(), "Sage MAS 500");
                txtIdPallet.Text = "";
                nudTamaño.Value = Tam_Pall = Id_Pall = 0;
                ConfWMS.ListarPalletsDataTable DatosPall = taListaPall.GetData(Almacen);
                grdPallet.DataSource = DatosPall;
                grdPallet.ClearSelection();

            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }               
        }
        private void GrdPallet_Click(object sender, EventArgs e)
        {
            try
            {
                IDPall = Convert.ToInt32(grdPallet.CurrentRow.Cells[2].Value);
                string IdPall2 = grdPallet.CurrentRow.Cells[0].Value.ToString();
                decimal TamPall =Convert.ToDecimal(grdPallet.CurrentRow.Cells[1].Value);
                txtIdPallet.Text = IdPall2;
                nudTamaño.Value = TamPall;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfParameterWMSForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(Cierre == 0)
            {
                e.Cancel = false;
            }
            else
            {
                MessageBox.Show("Aun se encuentra pendiente la configuración actual", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
        private bool MenuBar1_OnDelete(object sender, EventArgs e)
        {
            try
            {
                //Validar si exite una configuracion en la tabla timwmsConfAlmacen
                ConfWMS.timwmsConfAlmacenDataTable DatosConfAlm = taConfAlm.GetDataFkAlm(Almacen, "1");
                if (taConfAlm.FillFkAlm(DatosConfAlm, Almacen, "1") <= 0)
                {
                    MessageBox.Show("No hay ninguna configuracion para el almacen" + lkuAlmacen.Text, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    IDConfiguracion = Convert.ToInt32(DatosConfAlm.Rows[0]["PKeywmscf"].ToString());
                    Eliminar.GetData(IDConfiguracion);
                    MessageBox.Show("Configuracion eliminada", "Sage MAS 500");
                    lkuAlmacen.Enabled = true;
                    DisableControls();
                }
                return true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }            
        }
        private void MenuBar1_OnCancel(object sender, EventArgs e)
        {
            if(Cancelar == 0)
            {
                DisableControls();                
            }
        }
        private void DisableControls()
        {
            lkuAlmacen.Enabled = true;
            tcConfiguracion.Enabled = false;
            grdConf.Enabled = false;
            grdConf.DataSource = null;
            grdConf.Columns.Clear();
            grdConf.Rows.Clear();
            nudDiasDev.Value = 0;
            nudDiasEst.Value = 0;
            nudTamaño.Value = 0;
            menuBar1.Enabled = false;
            grdPallet.Enabled = false;
            grdPallet.DataSource = null;
            grdPallet.Columns.Clear();
            grdPallet.Rows.Clear();
            IDConfiguracion = 0;
            Cierre = 0;
            Cancelar = 0;
            Almacen = 0;
            lkuArticulo.Text = "";
            lkuUbiArtOP.Text = "";            
            lkuAlmacen.Text = lblDescripcion.Text = "";
            tcConfiguracion.SelectedIndex = 0;
            lkuUbixDefecto.Text = "";
            lkuUbiSec.Text = "";
            lkuUbiResxDefecto.Text = "";
            lkuUbiResSec.Text = "";
            lkuUbiDev.Text = "";
        }
        private void EneableControls()
        {
            Cierre = 1;
            Cancelar = 0;
            tcConfiguracion.Enabled = true;
            grdConf.Enabled = true;
            grdPallet.Enabled = true;
            lkuAlmacen.Enabled = false;
            menuBar1.Enabled = true;
            lkuUbixDefecto.Enabled = true;
            lkuUbiSec.Enabled = true;
            lkuUbiResxDefecto.Enabled = true;
            lkuUbiResSec.Enabled = true;
            lkuUbiDev.Enabled = true;
        }
        private void LkuArticulo_OnLookupReturn(object sender, LookupReturnEventArgs eventArgs)
        {
            try
            {
                for (int i = 0; i < ListArt.Count; i++)
                {
                    if (ListArt[i].ItemID == lkuArticulo.Text)
                    {
                        ArticuloID = ListArt[i].ItemKey;
                        lblDescripcionArt.Text = ListArt[i].LongDesc;
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LkuAlmacen_OnLookupReturn(object sender, LookupReturnEventArgs eventArgs)
        {
            try
            {
                for (int i = 0; i < ListAlmacen.Count; i++)
                {
                    if (ListAlmacen[i].WhseID == lkuAlmacen.Text)
                    {
                        Almacen = ListAlmacen[i].WhseKey;
                        ValidarConfiguracion();
                        //EneableControls();
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LkuUbixDefecto_OnLookupReturn(object sender, LookupReturnEventArgs eventArgs)
        {
            try
            {
                for (int i = 0; i < ListUbicacion.Count; i++)
                {
                    if (ListUbicacion[i].NumUbicacionID == lkuUbixDefecto.Text)
                    {
                        Ubicacion_Por_Defecto = ListUbicacion[i].UbicationKey;
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LkuUbiDev_OnLookupReturn(object sender, LookupReturnEventArgs eventArgs)
        {
            try
            {
                for (int i = 0; i < ListUbicacion.Count; i++)
                {
                    if (ListUbicacion[i].NumUbicacionID == lkuUbiDev.Text)
                    {
                        Ubicacion_Devolucion = ListUbicacion[i].UbicationKey;
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LkuUbiResSec_OnLookupReturn(object sender, LookupReturnEventArgs eventArgs)
        {
            try
            {
                for (int i = 0; i < ListUbicacion.Count; i++)
                {
                    if (ListUbicacion[i].NumUbicacionID == lkuUbiResSec.Text)
                    {
                        Ubicacion_ResurtifoSec = ListUbicacion[i].UbicationKey;
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LkuUbiResxDefecto_OnLookupReturn(object sender, LookupReturnEventArgs eventArgs)
        {
            try
            {
                for (int i = 0; i < ListUbicacion.Count; i++)
                {
                    if (ListUbicacion[i].NumUbicacionID == lkuUbiResxDefecto.Text)
                    {
                        Ubicacion_ResurtifoD = ListUbicacion[i].UbicationKey;
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LkuUbiSec_OnLookupReturn(object sender, LookupReturnEventArgs eventArgs)
        {
            try
            {
                for (int i = 0; i < ListUbicacion.Count; i++)
                {
                    if (ListUbicacion[i].NumUbicacionID == lkuUbiSec.Text)
                    {
                        Ubicacion_Secundaria = ListUbicacion[i].UbicationKey;
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LkuUbiArtOP_OnLookupReturn(object sender, LookupReturnEventArgs eventArgs)
        {
            try
            {
                for (int i = 0; i < ListUbicacion.Count; i++)
                {
                    if (ListUbicacion[i].NumUbicacionID == lkuUbiArtOP.Text)
                    {
                        Ubicacion_Art_Defecto = ListUbicacion[i].UbicationKey;
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LkuArticulo_Load(object sender, EventArgs e)
        {            
            try
            {
                ConfWMS.timItemDataTable dtArticulo = taArticulo.GetData();
                DataRow[] rows = dtArticulo.Select();
                for (int i = 0; i < rows.Length; i++)
                {
                    ListArt.Add(new Articulo
                    {
                        ItemKey = Convert.ToInt32(rows[i]["ItemKey"].ToString()),
                        ItemID = rows[i]["ItemID"].ToString(),
                        LongDesc = rows[i]["LongDesc"].ToString()
                    });
                }
                lkuArticulo.SetData(ListArt);
                lkuArticulo.Enabled = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnParamFresc_Click(object sender, EventArgs e)
        {
            try
            {
                WMCP001.MaintenanceParameter FMP = new MaintenanceParameter(ref SysSession);
                FMP.Show(this);
                this.Hide();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LkuAlmacen_Load(object sender, EventArgs e)
        {
            try
            {
                ConfWMS.timWarehouseDataTable dtAlmacen = taAlmacen.GetData(SysSession.CompanyID);
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
                lkuAlmacen.SetData(ListAlmacen);
                lkuAlmacen.Enabled = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
