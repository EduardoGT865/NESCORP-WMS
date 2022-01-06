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
    public partial class DistribuirPartida : Form
    {
        private WMDBContext dbContext;
        private string TipoTransc;
        private DSWorkOrderTableAdapters.PartidasTableAdapter taPartida = new DSWorkOrderTableAdapters.PartidasTableAdapter();
        private DSWorkOrderTableAdapters.tpoPurchOrderTableAdapter taPO = new DSWorkOrderTableAdapters.tpoPurchOrderTableAdapter();
        private DSWorkOrderTableAdapters.timwmsPartidasTableAdapter taPartidas = new DSWorkOrderTableAdapters.timwmsPartidasTableAdapter();
        private DSWorkOrderTableAdapters.timwmsOrdenTrabajoTableAdapter taOT = new DSWorkOrderTableAdapters.timwmsOrdenTrabajoTableAdapter();
        private DSDevolucionesTableAdapters.vdvCustomerReturnLineModfTableAdapter taCustomerDevline = new DSDevolucionesTableAdapters.vdvCustomerReturnLineModfTableAdapter();
        public DistribuirPartida(ref SageSession session, int TranID,string tran,string tipo)
        {
            InitializeComponent();
            SysSession.InitializeSession(session);
            LoadContext();
            TipoTransc = tipo;
            if (TipoTransc == "Compra")
            {
                CargarPartida(TranID);
            }
            else if(TipoTransc == "Devoluciones")
            {
                CargarDevolucion(TranID);
            }
            txtTranid.Text = tran;
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
        #region COMPRAS
        private void CargarDevolucion(int ShipKey)
        {
            grdPartida.Rows.Clear();
            DSDevoluciones.vdvCustomerReturnLineModfDataTable dtCustomerDevLine = taCustomerDevline.GetData(ShipKey);
            DataRow[] rowsDev = dtCustomerDevLine.Select();
            for (int i = 0; i < rowsDev.Length; i++)
            {
                //Se consulta a la tabla timwmsPartidas para validar si ya existe una partida para esta transaccion
                DSWorkOrder.timwmsPartidasDataTable dtPartidas = taPartidas.GetData_ExistPartida(ShipKey, Convert.ToInt32(rowsDev[i]["SOLineKey"].ToString()));
                int IndexPartidas = 0;
                if (dtPartidas.Count > 0 && Convert.ToDecimal(dtPartidas[0]["Cant_Recibida"].ToString()) > 0)
                {
                    DSWorkOrder.timwmsOrdenTrabajoDataTable dtOT = taOT.GetData(ShipKey, Convert.ToInt32(rowsDev[i]["SOLineKey"].ToString()));
                    //Si existen ots entonces la cantidad total se convierte en la cantidad pendiente de la transaccion
                    if (dtOT.Count > 0)
                    {
                        grdPartida.Rows.Add(
                            true,
                            rowsDev[i]["SOLineNo"].ToString(),
                            rowsDev[i]["ItemID"].ToString(),
                            rowsDev[i]["ShortDesc"].ToString(),
                            rowsDev[i]["UnitMeasID"].ToString(),
                            Math.Abs(Convert.ToDecimal(dtPartidas.Rows[IndexPartidas]["Cant_Pendiente"].ToString())),
                            Math.Abs(Convert.ToDecimal(dtPartidas.Rows[IndexPartidas]["Cant_Recibiendo"].ToString())),
                            rowsDev[i]["ItemKey"].ToString(),
                            rowsDev[i]["ShipUnitMeasKey"].ToString(),
                            rowsDev[i]["WhseKey"].ToString(),
                            rowsDev[i]["WhseID"].ToString(),
                            rowsDev[i]["SOLineKey"].ToString()
                        );
                    }
                    //Si ya existe una partida se va a tomar la cantidad de la partida
                    else
                    {
                        grdPartida.Rows.Add(
                            true,
                            rowsDev[i]["SOLineNo"].ToString(),
                            rowsDev[i]["ItemID"].ToString(),
                            rowsDev[i]["ShortDesc"].ToString(),
                            rowsDev[i]["UnitMeasID"].ToString(),
                            rowsDev[i]["QtyShipped"].ToString(),
                            Math.Abs(Convert.ToDecimal(dtPartidas.Rows[IndexPartidas]["Cant_Recibiendo"].ToString())),
                            rowsDev[i]["ItemKey"].ToString(),
                            rowsDev[i]["ShipUnitMeasKey"].ToString(),
                            rowsDev[i]["WhseKey"].ToString(),
                            rowsDev[i]["WhseID"].ToString(),
                            rowsDev[i]["SOLineKey"].ToString()
                        );
                    }
                    IndexPartidas++;
                }
                else
                {

                    grdPartida.Rows.Add
                        (
                            false,
                            rowsDev[i]["SOLineNo"].ToString(),
                            rowsDev[i]["ItemID"].ToString(),
                            rowsDev[i]["ShortDesc"].ToString(),
                            rowsDev[i]["UnitMeasID"].ToString(),
                            Math.Abs(Convert.ToDecimal(rowsDev[i]["QtyShipped"].ToString())),
                            0,
                            rowsDev[i]["ItemKey"].ToString(),
                            rowsDev[i]["ShipUnitMeasKey"].ToString(),
                            rowsDev[i]["WhseKey"].ToString(),
                            rowsDev[i]["WhseID"].ToString(),
                            rowsDev[i]["SOLineKey"].ToString()
                        );
                }
            }
        }
        private void CargarPartida(int PO)
        {
            grdPartida.Rows.Clear();
            DSWorkOrder.PartidasDataTable dtPartida = taPartida.GetData(PO);
            DataRow[] rowsPartidas = dtPartida.Select();
            for (int i = 0; i < rowsPartidas.Length; i++)
            {
                //Se consulta a la tabla timwmsPartidas para validar si ya existe una partida para esta transaccion
                DSWorkOrder.timwmsPartidasDataTable dtPartidas = taPartidas.GetData_ExistPartida(PO, Convert.ToInt32(rowsPartidas[i]["POLineKey"].ToString()));
                int IndexPartidas = 0;
                if (dtPartidas.Count > 0 && Convert.ToDecimal(dtPartidas[0]["Cant_Recibida"].ToString()) > 0)
                {
                    DSWorkOrder.timwmsOrdenTrabajoDataTable dtOT = taOT.GetData(PO, Convert.ToInt32(rowsPartidas[i]["POLineKey"].ToString()));
                    //Si existen ots entonces la cantidad total se convierte en la cantidad pendiente de la transaccion
                    if (dtOT.Count > 0)
                    {
                        grdPartida.Rows.Add(
                            true,
                            rowsPartidas[i]["POLineNo"].ToString(),
                            rowsPartidas[i]["ItemID"].ToString(),
                            rowsPartidas[i]["Description"].ToString(),
                            rowsPartidas[i]["UnitMeasID"].ToString(),
                            dtPartidas.Rows[IndexPartidas]["Cant_Pendiente"].ToString(),
                            dtPartidas.Rows[IndexPartidas]["Cant_Recibiendo"].ToString(),
                            rowsPartidas[i]["ItemKey"].ToString(),
                            rowsPartidas[i]["UnitMeasKey"].ToString(),
                            rowsPartidas[i]["ShipToWhseKey"].ToString(),
                            rowsPartidas[i]["WhseID"].ToString(),
                            rowsPartidas[i]["POLineKey"].ToString()
                        );
                    }
                    //Si ya existe una partida se va a tomar la cantidad de la partida
                    else
                    {
                        grdPartida.Rows.Add(
                            true,
                            rowsPartidas[i]["POLineNo"].ToString(),
                            rowsPartidas[i]["ItemID"].ToString(),
                            rowsPartidas[i]["Description"].ToString(),
                            rowsPartidas[i]["UnitMeasID"].ToString(),
                            rowsPartidas[i]["QtyOrd"].ToString(),
                            dtPartidas.Rows[IndexPartidas]["Cant_Recibiendo"].ToString(),
                            rowsPartidas[i]["ItemKey"].ToString(),
                            rowsPartidas[i]["UnitMeasKey"].ToString(),
                            rowsPartidas[i]["ShipToWhseKey"].ToString(),
                            rowsPartidas[i]["WhseID"].ToString(),
                            rowsPartidas[i]["POLineKey"].ToString()
                        );
                    }
                    IndexPartidas++;
                }
                else
                {

                    grdPartida.Rows.Add
                        (
                            false,
                            rowsPartidas[i]["POLineNo"].ToString(),
                            rowsPartidas[i]["ItemID"].ToString(),
                            rowsPartidas[i]["Description"].ToString(),
                            rowsPartidas[i]["UnitMeasID"].ToString(),
                            rowsPartidas[i]["QtyOrd"].ToString(),
                            0,
                            rowsPartidas[i]["ItemKey"].ToString(),
                            rowsPartidas[i]["UnitMeasKey"].ToString(),
                            rowsPartidas[i]["ShipToWhseKey"].ToString(),
                            rowsPartidas[i]["WhseID"].ToString(),
                            rowsPartidas[i]["POLineKey"].ToString()
                        );
                }
            }
        }
        #endregion
        private void GrdPartida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            {
                e.Handled = true;

            }
            //allow only one dot
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;

            }
        }
        private void MenuBar1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            List<Distribuir> DistribuirArt = new List<Distribuir>();
            if (e.ClickedItem.Name == "mibFinish")
            {
                try
                {
                    if (ValidarRecibido() == true)
                    {
                        foreach (DataGridViewRow Row in grdPartida.Rows)
                        {
                            bool isCellChecked = (bool)grdPartida.Rows[Row.Index].Cells[0].Value;
                            if (isCellChecked)
                            {
                                DistribuirArt.Add(new Distribuir
                                {
                                    Partida = Convert.ToInt32(Row.Cells["Partida"].Value),
                                    Articulo = Row.Cells["Articulo2"].Value.ToString(),
                                    Descripcion = Row.Cells["Descripcion"].Value.ToString(),
                                    UM = Row.Cells["UM2"].Value.ToString(),
                                    CantTotal = Convert.ToDecimal(Row.Cells["CantTotal"].Value),
                                    CantRecibida = Convert.ToDecimal(Row.Cells["CantRecibir"].Value),
                                    ItemKey = Convert.ToInt32(Row.Cells["ItemKey"].Value),
                                    umkey = Convert.ToInt32(Row.Cells["MeasKey"].Value),
                                    WhseKey = Convert.ToInt32(Row.Cells["Whskey"].Value),
                                    WhseID = Row.Cells["WhseID"].Value.ToString(),
                                    POLineKey = Convert.ToInt32(Row.Cells["POLineKey"].Value)
                                });
                            }
                        }
                        WorkOrder frm = Application.OpenForms.Cast<WorkOrder>().FirstOrDefault(x => x is WorkOrder);
                        if (frm != null)
                        {
                            //si la instancia existe puedo acceder a sus miembros
                            frm.CargarPartida(DistribuirArt);
                            this.Close();
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        bool ValidarRecibido()
        {
            try
            {
                foreach (DataGridViewRow row in grdPartida.Rows)
                {
                    //if ((bool)grdPartida.Rows[row.Index].Cells[0].Value == true && Convert.ToDecimal(grdPartida.Rows[row.Index].Cells[6].Value) > 0 && Convert.ToDecimal(grdPartida.Rows[row.Index].Cells["CantRecibir"].Value) <= Convert.ToDecimal(grdPartida.Rows[row.Index].Cells["CantTotal"].Value))

                    if ((bool)grdPartida.Rows[row.Index].Cells[0].Value == true && Convert.ToDecimal(grdPartida.Rows[row.Index].Cells["CantRecibir"].Value) <= Convert.ToDecimal(grdPartida.Rows[row.Index].Cells["CantTotal"].Value))
                    {
                        return true;
                    }
                    //else if ((bool)grdPartida.Rows[row.Index].Cells[0].Value == true && Convert.ToDecimal(grdPartida.Rows[row.Index].Cells[6].Value) <= 0)
                    //{
                    //    MessageBox.Show("Ingrese la cantidad a recibir", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                    //    break;
                    //}
                    else if ((bool)grdPartida.Rows[row.Index].Cells[0].Value == true && Convert.ToDecimal(grdPartida.Rows[row.Index].Cells["CantRecibir"].Value) > Convert.ToDecimal(grdPartida.Rows[row.Index].Cells["CantTotal"].Value))
                    {
                        MessageBox.Show("La cantidad a recibir no puede ser mayor a la cantidad total", "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void GrdPartida_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdPartida.IsCurrentCellDirty)
                {
                    grdPartida.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Sage MAS 500", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in grdPartida.Rows)
            {
                grdPartida.Rows[row.Index].Cells["SelecItem"].Value = true;
            }
        }
        private void SelectCleanAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in grdPartida.Rows)
            {
                grdPartida.Rows[row.Index].Cells["SelecItem"].Value = false;
                grdPartida.Rows[row.Index].Cells["CantRecibir"].Value = "";
            }
        }
    }
}
