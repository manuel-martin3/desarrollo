using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using BapFormulariosNet.Seguridadlog;
using BapFormulariosNet.Ayudas;
using BapFormulariosNet.Codigo;

namespace BapFormulariosNet.RecursosHumanos.Configuraciones
{
    public partial class Frm_CcostoGeneralesPlanilla : plantilla
    {
        private DataTable tablacabprestamos;
        private DataTable tabladetprestamos;
        private DataTable tmptabla;
        private string j_xFiltronom = string.Empty;
        private bool sw_EmpiezaEdicion = false;
        private bool Sw_LOad = true;
        private bool sw_novaluechange = false;
        private int u_n_opsel = 0;
        private int lc_contador = 0;

        public Frm_CcostoGeneralesPlanilla()
        {
            InitializeComponent();

            KeyDown += Frm_CcostoGeneralesPlanilla_KeyDown;
            FormClosing += Frm_CcostoGeneralesPlanilla_FormClosing;
            Load += Frm_CcostoGeneralesPlanilla_Load;
            Activated += Frm_CcostoGeneralesPlanilla_Activated;

            txtfiltronombre.LostFocus += new System.EventHandler(txtfiltronombre_LostFocus);
            txtfiltronombre.GotFocus += new System.EventHandler(txtfiltronombre_GotFocus);
        }

        private void Frm_CcostoGeneralesPlanilla_Activated(object sender, EventArgs e)
        {
            if (Sw_LOad)
            {
                for (lc_contador = 0; lc_contador <= DataGridView1.ColumnCount - 1; lc_contador++)
                {
                    DataGridView1.Columns[lc_contador].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                U_RefrescaControles();
                CargaDatos();
                U_RefrescaControles();
                Sw_LOad = false;
            }
        }
        private void Frm_CcostoGeneralesPlanilla_Load(object sender, EventArgs e)
        {
            var arreglobotones = new object[] { btnnuevo,
            btnmod,
            btngrabar,
            btncancelar,
            btneliminar,
            btnload,
            null,
            btncerrar };
            VariablesPublicas.ConfiguraToolbar(arreglobotones);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            WindowState = FormWindowState.Normal;
        }

        private void CargaDatos()
        {
            var xcodactual = string.Empty;
            if (Examinar.CurrentRow != null)
            {
                xcodactual = Examinar.Rows[Examinar.CurrentRow.Index].Cells["codigo"].Value.ToString();
            }
            var nposcolumnasortear = 0;
            var PrvSotOrder = default(SortOrder);
            var zordenado = false;
            var xcodcliente = "..";
            var xpalabra1 = string.Empty;
            var xpalabra2 = string.Empty;
            var xpalabra3 = string.Empty;

            if (txtfiltronombre.Text.Trim().Length > 0 & txtfiltronombre.Enabled)
            {
                xpalabra1 = VariablesPublicas.Palabras(txtfiltronombre.Text, 1);
                xpalabra2 = VariablesPublicas.Palabras(txtfiltronombre.Text, 2);
                xpalabra3 = VariablesPublicas.Palabras(txtfiltronombre.Text, 3);
            }
            var xvmcodigo = string.Empty;
            if (Examinar.CurrentRow != null)
            {
                xcodcliente = Examinar.Rows[Examinar.CurrentRow.Index].Cells["codigo"].Value.ToString();
            }
            if (Examinar.SortedColumn != null)
            {
                nposcolumnasortear = Examinar.SortedColumn.Index;
                PrvSotOrder = Examinar.SortOrder;
                zordenado = true;
            }

            var BL = new tb_plla_ccostogenBL();
            var BE = new tb_plla_ccostogen();

            BE.codigo = xvmcodigo;
            BE.nomlike1 = xpalabra1;
            BE.nomlike2 = xpalabra2;
            BE.nomlike3 = xpalabra3;
            tablacabprestamos = BL.GetAll_CONSULTACAB(VariablesPublicas.EmpresaID, BE).Tables[0];
            if (BL.Sql_Error.Length > 0)
            {
                Frm_Class.ShowError(BL.Sql_Error, this);
                return;
            }
            lbltotaltrab.Text = "Sin Registros";
            if (BL.Sql_Error.Length == 0)
            {
                lbltotaltrab.Text = "Total Registros " + tablacabprestamos.Rows.Count.ToString();
            }
            Examinar.AutoGenerateColumns = false;
            Examinar.DataSource = tablacabprestamos;

            VariablesPublicas.PintaEncabezados(Examinar);
            if (zordenado)
            {
                if (PrvSotOrder == SortOrder.Ascending)
                {
                    Examinar.Sort(Examinar.Columns[nposcolumnasortear], System.ComponentModel.ListSortDirection.Ascending);
                }
                else
                {
                    Examinar.Sort(Examinar.Columns[nposcolumnasortear], System.ComponentModel.ListSortDirection.Descending);
                }
            }
            else
            {
                Examinar.Sort(Examinar.Columns["codigo"], System.ComponentModel.ListSortDirection.Ascending);
            }
            if (Examinar.CurrentRow == null)
            {
                if (Examinar.RowCount > 0)
                {
                    Examinar.CurrentCell = Examinar.Rows[0].Cells["descripcion"];
                }
            }
            for (lc_contador = 0; lc_contador <= Examinar.Rows.Count - 1; lc_contador++)
            {
                if (Examinar.Rows[lc_contador].Cells["codigo"].Value.ToString() == xcodactual)
                {
                    Examinar.CurrentCell = Examinar.Rows[lc_contador].Cells["descripcion"];
                    break;
                }
            }
            U_RefrescaControles();
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            u_PintaDatos();
        }

        private void U_RefrescaControles()
        {
            txtfiltronombre.Enabled = chkapenom.Checked;
            txttipoplanilla.Enabled = false;
            btnload.Enabled = u_n_opsel == 0;
            txtcodigo.Enabled = u_n_opsel == 1;
            txtdescripcion.Enabled = u_n_opsel > 0;

            btnprimero.Enabled = u_n_opsel == 0;
            btnultimo.Enabled = u_n_opsel == 0;
            btnsiguiente.Enabled = u_n_opsel == 0;
            btnanterior.Enabled = u_n_opsel == 0;
            var xcodcliente = string.Empty;
            if (Examinar.CurrentRow != null)
            {
                xcodcliente = Examinar.Rows[Examinar.CurrentCell.RowIndex].Cells["codigo"].Value.ToString();
            }
            btnnuevo.Enabled = u_n_opsel == 0;
            btngrabar.Enabled = u_n_opsel > 0;
            btnmod.Enabled = u_n_opsel == 0 & xcodcliente.Length > 0;
            btneliminar.Enabled = u_n_opsel == 0 & xcodcliente.Length > 0;
            btncancelar.Enabled = u_n_opsel > 0;
            btncerrar.Enabled = u_n_opsel == 0;
            DataGridView1.Enabled = u_n_opsel == 0;
            btnlog.Enabled = u_n_opsel == 0;

            DataGridView1.ReadOnly = true;
            DataGridView1.ReadOnly = u_n_opsel == 0;
            for (lc_contador = 0; lc_contador <= DataGridView1.ColumnCount - 1; lc_contador++)
            {
                if (DataGridView1.Columns[lc_contador].Name.ToUpper() == "importe_8a".ToUpper())
                {
                    DataGridView1.Columns[lc_contador].ReadOnly = u_n_opsel == 0;
                }
                else
                {
                    DataGridView1.Columns[lc_contador].ReadOnly = true;
                }
            }
            DataGridView1.Enabled = true;
            btnaddfila.Enabled = u_n_opsel > 0;
            btndelfila.Enabled = u_n_opsel > 0;
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            if (!(TabControl1.SelectedIndex == 0))
            {
                TabControl1.SelectedIndex = 0;
            }
            u_n_opsel = 1;
            Blanquear();
            TabControl1.SelectedIndex = 0;
            TabControl1.SelectedIndex = 1;
            var BL = new tb_plla_ccostogenBL();
            var BE = new tb_plla_ccostogen();
            txtcodigo.Text = BL.GetAll_MaxCCosto(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0].Rows[0]["maximo_codigo"].ToString();
            txtdescripcion.Text = string.Empty;
            u_CargaAnexos();
            txtdescripcion.Focus();
        }

        private void Blanquear()
        {
            txtcodigo.Text = string.Empty;
            txtdescripcion.Text = string.Empty;
            if (tabladetprestamos != null)
            {
                tabladetprestamos.AcceptChanges();
                if (tabladetprestamos.Rows.Count > 0)
                {
                    for (lc_contador = 0; lc_contador <= tabladetprestamos.Rows.Count - 1; lc_contador++)
                    {
                        tabladetprestamos.Rows[lc_contador].Delete();
                    }
                    tabladetprestamos.AcceptChanges();
                }
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            U_CancelarEdicion(1);
        }

        private void U_CancelarEdicion(int SwConfirmacion)
        {
            var sw_prosigue = true;

            if (SwConfirmacion == 1)
            {
                sw_prosigue = (MessageBox.Show("Desea cancelar ingreso de datos...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
            }
            else
            {
                sw_prosigue = true;
            }

            if (sw_prosigue)
            {
                var xtmpuser = txtcodigo.Text;
                u_n_opsel = 0;
                TabControl1.SelectedIndex = 0;
                U_RefrescaControles();
                CargaDatos();
                if (Examinar.RowCount > 0)
                {
                    for (lc_contador = 0; lc_contador <= Examinar.Rows.Count - 1; lc_contador++)
                    {
                        if (Examinar.Rows[lc_contador].Cells["codigo"].Value.ToString() == xtmpuser)
                        {
                            Examinar.CurrentCell = Examinar.Rows[lc_contador].Cells["descripcion"];
                            break;
                        }
                    }
                }
            }
        }

        private void btnmod_Click(object sender, EventArgs e)
        {
            if (!(TabControl1.SelectedIndex == 0))
            {
                TabControl1.SelectedIndex = 0;
            }
            u_n_opsel = 2;
            sw_EmpiezaEdicion = true;
            TabControl1.SelectedIndex = 0;
            TabControl1.SelectedIndex = 1;
            sw_EmpiezaEdicion = false;
            txtdescripcion.Focus();
        }

        private void btngrabar_Click(object sender, EventArgs e)
        {
            if (U_Validacion())
            {
                if (u_n_opsel == 1)
                {
                    var BL = new tb_plla_ccostogenBL();
                    var BE = new tb_plla_ccostogen();

                    BE.codigo = txtcodigo.Text.Trim();
                    tmptabla = BL.GetAll_CONSULTACAB(VariablesPublicas.EmpresaID, BE).Tables[0];
                    if (tmptabla.Rows.Count > 0)
                    {
                        var BLMX = new tb_plla_ccostogenBL();
                        var BEMX = new tb_plla_ccostogen();
                        txtcodigo.Text = BLMX.GetAll_MaxCCosto(VariablesPublicas.EmpresaID.ToString(), BEMX).Tables[0].Rows[0]["maximo_codigo"].ToString();
                    }
                    tmptabla.Rows.Add(VariablesPublicas.InsertIntoTable(tmptabla));
                    tmptabla.Rows[0]["codigo"] = txtcodigo.Text.Trim();
                }
                else
                {
                    var BL = new tb_plla_ccostogenBL();
                    var BE = new tb_plla_ccostogen();

                    BE.codigo = txtcodigo.Text.Trim();
                    tmptabla = BL.GetAll_CONSULTACAB(VariablesPublicas.EmpresaID, BE).Tables[0];
                }

                for (lc_contador = 0; lc_contador <= tabladetprestamos.Rows.Count - 1; lc_contador++)
                {
                    tabladetprestamos.Rows[lc_contador]["codigo"] = txtcodigo.Text.Trim();
                }
                tmptabla.Rows[0]["descripcion"] = txtdescripcion.Text;
                tmptabla.AcceptChanges();
                tabladetprestamos.AcceptChanges();

                var BLIU = new tb_plla_ccostogenBL();
                var BEIU = new tb_plla_ccostogen();
                if (BLIU.Insert_Update(VariablesPublicas.EmpresaID, BEIU, tmptabla, tabladetprestamos))
                {
                    seguridadlog();
                    U_CancelarEdicion(0);
                }
                else
                {
                    Frm_Class.ShowError(BLIU.Sql_Error, this);
                }
            }
        }
        private void seguridadlog()
        {
            var xclave = VariablesPublicas.EmpresaID + txtcodigo.Text.Trim();
            try
            {
                var BL = new tb_co_seguridadlogBL();
                var BE = new tb_co_seguridadlog();

                BE.moduloid = Name;
                BE.clave = xclave;
                BE.cuser = VariablesPublicas.Usuar;
                BE.fecha = DateTime.Now;
                BE.pc = VariablesPublicas.userip;
                BE.accion = (u_n_opsel == 1 ? "N" : "M");
                BE.detalle = "DESCRIPCION: " + txtdescripcion.Text;

                BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Examinar.CurrentRow != null)
            {
                var xnomcampo = string.Empty;
                if (xnomcampo.Length == 0)
                {
                    var BL = new tb_plla_ccostogenBL();
                    var BE = new tb_plla_ccostogen();

                    BE.codigo = Examinar.Rows[Examinar.CurrentRow.Index].Cells["codigo"].Value.ToString();
                    tmptabla = BL.GetAll_CONSULTACAB(VariablesPublicas.EmpresaID, BE).Tables[0];
                    if (BL.Sql_Error.Length == 0)
                    {
                        var message = "Desea eliminar Código  " + tmptabla.Rows[0]["codigo"].ToString().Trim() + " - " + tmptabla.Rows[0]["descripcion"].ToString().Trim() + " ...?";
                        var caption = "Mensaje del Sistema";
                        var buttons = MessageBoxButtons.YesNo;
                        DialogResult result;
                        result = MessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                            if (BL.Eliminar(VariablesPublicas.EmpresaID, tmptabla))
                            {
                                var BLL = new tb_co_seguridadlogBL();
                                var BEL = new tb_co_seguridadlog();

                                BEL.moduloid = Name;
                                BEL.clave = VariablesPublicas.EmpresaID + Examinar.Rows[Examinar.CurrentRow.Index].Cells["codigo"].Value.ToString();
                                BEL.cuser = VariablesPublicas.Usuar;
                                BEL.fecha = DateTime.Now;
                                BEL.pc = VariablesPublicas.userip;
                                BEL.accion = "B";
                                BEL.detalle = "DESCRIPCION :  BORRADO - ELIMINADO";

                                BLL.Insert(VariablesPublicas.EmpresaID.ToString(), BEL);
                                Examinar.Rows.Remove(Examinar.CurrentRow);
                                Examinar.Refresh();
                            }
                            else
                            {
                                Frm_Class.ShowError(BL.Sql_Error, this);
                            }
                        }
                    }
                    else
                    {
                        Frm_Class.ShowError(BL.Sql_Error, this);
                    }
                }
                else
                {
                    MessageBox.Show(xnomcampo, "IMPOSIBLE ELIMINAR REGISTRO");
                }
            }
            U_RefrescaControles();
        }

        private void Frm_CcostoGeneralesPlanilla_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (u_n_opsel > 0)
            {
                MessageBox.Show("Finalice edición para cerrar formulario !!!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            CargaDatos();
            U_RefrescaControles();
            u_PintaDatos();
        }

        public bool U_Validacion()
        {
            var xmsg = string.Empty;
            var objeto = new object();
            objeto = null;
            if (txtcodigo.Text.Trim().Length == 0)
            {
                xmsg = xmsg + "\r" + "Ingrese Código";
                objeto = txtcodigo;
            }
            if (txtdescripcion.Text.Trim().Length == 0)
            {
                xmsg = xmsg + "\r" + "Ingrese Descripción del Centro de Costo";
                objeto = txtdescripcion;
            }
            if (xmsg.Trim().Length > 0)
            {
                MessageBox.Show(xmsg.Trim(), "Error en Ingreso de Datos");
                if ((objeto != null))
                {
                    objeto = Focus();
                }
            }
            return xmsg.Trim().Length == 0;
        }

        private void Frm_CcostoGeneralesPlanilla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 & btnnuevo.Enabled)
            {
                btnnuevo_Click(sender, e);
            }
            if (e.KeyCode == Keys.F3 & btnmod.Enabled)
            {
                btnmod_Click(sender, e);
            }
            if (e.KeyCode == Keys.G & e.Control & btngrabar.Enabled)
            {
                btngrabar_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (btncancelar.Enabled)
                {
                    btncancelar_Click(sender, e);
                }
                else
                {
                    btncerrar_Click(sender, e);
                }
            }
            if (e.KeyCode == Keys.F8 & btneliminar.Enabled)
            {
                btneliminar_Click(sender, e);
            }
            if (e.KeyCode == Keys.F5 & btnload.Enabled)
            {
                btnload_Click(sender, e);
            }
        }

        private void btnlog_Click(object sender, EventArgs e)
        {
            if (Examinar.CurrentRow != null)
            {
                var oform = new FrmSeguridad();
                oform._Nombre = Name;
                oform._ClaveForm = VariablesPublicas.EmpresaID + Examinar.Rows[Examinar.CurrentRow.Index].Cells["codigo"].Value.ToString();
                oform.Owner = this;
                oform.ShowDialog();
            }
        }

        private void TabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (u_n_opsel > 0)
            {
                if (TabControl1.Controls[e.TabPageIndex].Name.ToUpper() == "TABPAGE1")
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnfiltro_Click(object sender, EventArgs e)
        {
            CargaDatos();
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (DataGridView1.CurrentCell != null)
                {
                    SendKeys.Send("\t");
                    return true;
                }
                else
                {
                    if (TabControl1.SelectedIndex == 1)
                    {
                        if (!DataGridView1.IsCurrentCellInEditMode)
                        {
                            SendKeys.Send("\t");
                            return true;
                        }
                    }
                    else
                    {
                        SendKeys.Send("\t");
                        return true;
                    }
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void u_PintaDatos()
        {
            if (!Sw_LOad)
            {
                if (u_n_opsel != 1)
                {
                    if (Examinar.CurrentRow == null)
                    {
                        txtcodigo.Text = "..";
                    }
                    else
                    {
                        txtcodigo.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["codigo"].Value.ToString();
                    }
                    if (TabControl1.SelectedIndex == 1)
                    {
                        if (Examinar.CurrentRow != null)
                        {
                            txtcodigo.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["codigo"].Value.ToString();
                            txtdescripcion.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["descripcion"].Value.ToString();
                        }
                        else
                        {
                            Blanquear();
                        }
                    }
                    u_CargaAnexos();
                }
                else
                {
                }
                U_RefrescaControles();
            }
        }

        private void btnprimero_Click(object sender, EventArgs e)
        {
            u_Roleo(GlobalVars.GetInstance().TOPRECORD);
        }
        private void btnanterior_Click(object sender, EventArgs e)
        {
            u_Roleo(GlobalVars.GetInstance().PREVRECORD);
        }
        private void btnsiguiente_Click(object sender, EventArgs e)
        {
            u_Roleo(GlobalVars.GetInstance().NEXTRECORD);
        }
        private void btnultimo_Click(object sender, EventArgs e)
        {
            u_Roleo(GlobalVars.GetInstance().BOTTRECORD);
        }
        public void u_Roleo(string xtipo)
        {
            VariablesPublicas.RoleoGrid(Examinar, xtipo, "codigo_6");
            u_PintaDatos();
        }

        private void txtfiltronombre_GotFocus(object sender, System.EventArgs e)
        {
            j_xFiltronom = txtfiltronombre.Text;
        }
        private void txtfiltronombre_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_xFiltronom == txtfiltronombre.Text))
            {
                CargaDatos();
            }
        }

        public void u_CargaAnexos()
        {
            var xvmcodigo = "..-";
            if (txtcodigo.Text.Trim().Length > 0)
            {
                xvmcodigo = txtcodigo.Text.Trim();
            }
            var BL = new tb_plla_ccostogenBL();
            var BE = new tb_plla_ccostogen();

            BE.empresaid = VariablesPublicas.EmpresaID;
            BE.codigo = xvmcodigo;
            tabladetprestamos = BL.GetAll_CONSULTADET(VariablesPublicas.EmpresaID, BE).Tables[0];
            if (BL.Sql_Error.Length > 0)
            {
                Frm_Class.ShowError(BL.Sql_Error, this);
            }
            DataGridView1.AutoGenerateColumns = false;
            DataGridView1.DataSource = tabladetprestamos;
        }

        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' & (e.KeyChar) <= '9')
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back | (e.KeyChar) == (char)Keys.Delete)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!Sw_LOad)
            {
                if ((DataGridView1.CurrentRow != null))
                {
                    sw_novaluechange = true;
                    if (DataGridView1.Columns[e.ColumnIndex].Name.ToUpper() == "importe_8a".ToUpper())
                    {
                        if (object.ReferenceEquals(DataGridView1.Rows[DataGridView1.CurrentRow.Index].Cells["importe_8a"].Value, DBNull.Value))
                        {
                            DataGridView1.Rows[DataGridView1.CurrentRow.Index].Cells["importe_8a"].Value = 0;
                        }
                        if (Convert.ToDecimal(DataGridView1.Rows[DataGridView1.CurrentRow.Index].Cells["importe_8a"].Value) < 0)
                        {
                            DataGridView1.Rows[DataGridView1.CurrentRow.Index].Cells["importe_8a"].Value = 0;
                        }
                    }
                    sw_novaluechange = false;
                }
            }
        }

        private void btnaddfila_Click(object sender, EventArgs e)
        {
            var f = new Frm_AyudaCellAllCcostoPlla();
            var xvmdescartartipoplanillarubroa = string.Empty;
            for (lc_contador = 0; lc_contador <= tabladetprestamos.Rows.Count - 1; lc_contador++)
            {
                if (!(tabladetprestamos.Rows[lc_contador].RowState == DataRowState.Deleted))
                {
                    xvmdescartartipoplanillarubroa = xvmdescartartipoplanillarubroa + tabladetprestamos.Rows[lc_contador]["cencosid"] + "_";
                }
            }
            f.Owner = this;
            f._Lpcciaccostodescartar = xvmdescartartipoplanillarubroa;
            f._PasaDelegado = Rubros;
            f.ShowDialog();
        }
        public void Rubros(bool zselect, DataTable tabla)
        {
            if (zselect)
            {
                var nfila = 0;
                for (nfila = 0; nfila <= tabla.Rows.Count - 1; nfila++)
                {
                    tabladetprestamos.Rows.Add(VariablesPublicas.InsertIntoTable(tabladetprestamos));
                    tabladetprestamos.Rows[tabladetprestamos.Rows.Count - 1]["empresaid"] = tabla.Rows[nfila]["empresaid"];
                    tabladetprestamos.Rows[tabladetprestamos.Rows.Count - 1]["cencosid"] = tabla.Rows[nfila]["cencosid"];
                    tabladetprestamos.Rows[tabladetprestamos.Rows.Count - 1]["cencosname"] = tabla.Rows[nfila]["cencosname"];
                    tabladetprestamos.AcceptChanges();
                }
            }
        }

        private void btndelfila_Click(object sender, EventArgs e)
        {
            var xvmnroitem = string.Empty;
            if (DataGridView1.CurrentRow != null)
            {
                xvmnroitem = DataGridView1.Rows[DataGridView1.CurrentRow.Index].Cells["empresaid"].Value.ToString() + DataGridView1.Rows[DataGridView1.CurrentRow.Index].Cells["cencosid"].Value.ToString();
                for (lc_contador = 0; lc_contador <= tabladetprestamos.Rows.Count - 1; lc_contador++)
                {
                    if (tabladetprestamos.Rows[lc_contador].RowState == DataRowState.Deleted)
                    {
                    }
                    else
                    {
                        if (tabladetprestamos.Rows[lc_contador]["empresaid"].ToString() + tabladetprestamos.Rows[lc_contador]["cencosid"].ToString() == xvmnroitem)
                        {
                            tabladetprestamos.Rows[lc_contador].Delete();
                        }
                    }
                }
            }
            tabladetprestamos.AcceptChanges();
        }

        private void Examinar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Examinar_DoubleClick(sender, e);
        }

        private void Examinar_DoubleClick(object sender, EventArgs e)
        {
            if ((Examinar.CurrentRow != null))
            {
            }
        }

        private void chkapenom_CheckedChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad)
            {
                txtfiltronombre.Text = string.Empty;
                U_RefrescaControles();
            }
        }
    }
}
