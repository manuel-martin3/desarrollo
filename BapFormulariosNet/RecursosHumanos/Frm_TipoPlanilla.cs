using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using BapFormulariosNet.Seguridadlog;
using BapFormulariosNet.Codigo;

namespace BapFormulariosNet.RecursosHumanos
{
    public partial class Frm_TipoPlanilla : plantilla
    {
        private DataTable tablaclientes;
        private string j_xFiltronom = string.Empty;
        private bool sw_EmpiezaEdicion = false;
        private DataTable tmptabla;
        private bool Sw_LOad = true;
        private int u_n_opsel = 0;
        private int lc_cont;
        private int cdClave = 0;

        public Frm_TipoPlanilla()
        {
            InitializeComponent();
            KeyDown += Frm_TipoPlanilla_KeyDown;
            FormClosing += Frm_TipoPlanilla_FormClosing;
            Load += Frm_TipoPlanilla_Load;
            Activated += Frm_TipoPlanilla_Activated;

            txtfiltronombre.LostFocus += new System.EventHandler(txtfiltronombre_LostFocus);
            txtfiltronombre.GotFocus += new System.EventHandler(txtfiltronombre_GotFocus);
        }

        public void llenar_PeriodicidadPago()
        {
            try
            {
                cboFormapago.DataSource = NewMethodoP();
                cboFormapago.DisplayMember = "Value";
                cboFormapago.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethodoP()
        {
            var BL = new tb_plla_pdt_tabla13BL();
            var BE = new tb_plla_pdt_tabla13();

            var table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            var rows = table.Rows;

            object[] cell;
            var dic = new Dictionary<string, string>();
            var binding = new BindingSource();

            foreach (DataRow item in rows)
            {
                cell = item.ItemArray;
                dic.Add(cell[0].ToString(), cell[0].ToString() + " - " + cell[1].ToString());
                cell = null;
            }
            binding.DataSource = dic;
            return binding;
        }

        private void llenar_cboRubroRtps()
        {
            try
            {
                cboRubrorpts.DataSource = NewMethod();
                cboRubrorpts.DisplayMember = "Value";
                cboRubrorpts.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethod()
        {
            var BL = new tb_plla_pdt_tabla08BL();
            var BE = new tb_plla_pdt_tabla08();

            var table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            var rows = table.Rows;

            object[] cell;
            var dic = new Dictionary<string, string>();
            var binding = new BindingSource();

            foreach (DataRow item in rows)
            {
                cell = item.ItemArray;
                dic.Add(cell[0].ToString(), cell[0].ToString() + " - " + cell[1].ToString());
                cell = null;
            }
            binding.DataSource = dic;
            return binding;
        }

        private void Frm_TipoPlanilla_Activated(object sender, EventArgs e)
        {
            if (Sw_LOad)
            {
                llenar_PeriodicidadPago();
                llenar_cboRubroRtps();
                U_RefrescaControles();
                CargaDatos();
                U_RefrescaControles();
                Sw_LOad = false;
            }
        }
        private void Frm_TipoPlanilla_Load(object sender, EventArgs e)
        {
            var arreglobotones = new object[] { btnNew,
            btnEdit,
            btnSave,
            btnRetro,
            btnDelete,
            btnLoad,
            btnExit };
            VariablesPublicas.ConfiguraToolbar(arreglobotones);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
        }

        private void CargaDatos()
        {
            var nposcolumnasortear = 0;
            var PrvSotOrder = default(SortOrder);
            var zordenado = false;
            var xcodcliente = "..";
            var xpalabra1 = string.Empty;
            var xpalabra2 = string.Empty;
            var xpalabra3 = string.Empty;
            if (txtfiltronombre.Text.Trim().Length > 0)
            {
                xpalabra1 = VariablesPublicas.Palabras(txtfiltronombre.Text, 1);
                xpalabra2 = VariablesPublicas.Palabras(txtfiltronombre.Text, 2);
                xpalabra3 = VariablesPublicas.Palabras(txtfiltronombre.Text, 3);
            }
            if (Examinar.CurrentRow != null)
            {
                xcodcliente = Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipoplla"].Value.ToString();
            }
            if (Examinar.SortedColumn != null)
            {
                nposcolumnasortear = Examinar.SortedColumn.Index;
                PrvSotOrder = Examinar.SortOrder;
                zordenado = true;
            }
            var BL = new tb_plla_tipoplanillaBL();
            var BE = new tb_plla_tipoplanilla();

            if (txtfiltronombre.Text.Trim().Length > 0)
            {
                BE.nomlike1 = xpalabra1;
                BE.nomlike2 = xpalabra2;
                BE.nomlike3 = xpalabra3;
            }
            BE.norden = 1;
            BE.ver_blanco = 0;
            BE.solopdt = 0;
            tablaclientes = BL.GetAll_Consulta(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

            Examinar.AutoGenerateColumns = false;
            Examinar.DataSource = tablaclientes;

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
                Examinar.Sort(Examinar.Columns["tipoplla"], System.ComponentModel.ListSortDirection.Ascending);
            }
            if (Examinar.CurrentRow == null)
            {
                if (Examinar.RowCount > 0)
                {
                    Examinar.CurrentCell = Examinar.Rows[0].Cells["tipoplla"];
                }
            }
            for (lc_cont = 0; lc_cont <= Examinar.Rows.Count - 1; lc_cont++)
            {
                if (Examinar.Rows[lc_cont].Cells["tipoplla"].Value.ToString() == xcodcliente)
                {
                    Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["tipoplla"];
                    break;
                }
            }
        }
        private void U_RefrescaControles()
        {
            txtCodigo.Enabled = u_n_opsel == 1;
            txtdescripcion.Enabled = u_n_opsel > 0;
            txtidconta.Enabled = u_n_opsel > 0;
            txtdiasplanilla.Enabled = u_n_opsel > 0;
            txtdescriptrab.Enabled = u_n_opsel > 0;
            txttituloboleta.Enabled = u_n_opsel > 0;
            chkactivo.Enabled = u_n_opsel > 0;
            chkgratificacion.Enabled = u_n_opsel > 0;
            chkcts.Enabled = u_n_opsel > 0;
            chkpdt.Enabled = u_n_opsel > 0;
            cboFormapago.Enabled = u_n_opsel > 0;

            cboRubrorpts.Enabled = u_n_opsel > 0;

            btnLoad.Enabled = u_n_opsel == 0;
            btnPrimero.Enabled = u_n_opsel == 0;
            btnUltimo.Enabled = u_n_opsel == 0;
            btnSiguiente.Enabled = u_n_opsel == 0;
            btnAnterior.Enabled = u_n_opsel == 0;

            var xcodcliente = string.Empty;
            if (Examinar.CurrentRow != null)
            {
                xcodcliente = Examinar.Rows[Examinar.CurrentCell.RowIndex].Cells["tipoplla"].Value.ToString();
            }

            btnNew.Enabled = u_n_opsel == 0;
            btnSave.Enabled = u_n_opsel > 0;
            btnEdit.Enabled = u_n_opsel == 0 & xcodcliente.Length > 0;
            btnDelete.Enabled = u_n_opsel == 0 & xcodcliente.Length > 0;
            btnRetro.Enabled = u_n_opsel > 0;
            btnExit.Enabled = u_n_opsel == 0;
            barramain.Enabled = cdClave == 0;
            Examinar.Enabled = u_n_opsel == 0;
            btnLog.Enabled = u_n_opsel == 0;
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            u_PintaDatos();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!(TabControl1.SelectedIndex == 0))
            {
                TabControl1.SelectedIndex = 0;
            }
            u_n_opsel = 1;
            Blanquear();
            U_RefrescaControles();
            TabControl1.SelectedIndex = 0;
            TabControl1.SelectedIndex = 1;
            txtCodigo.Text = string.Empty;

            chkpdt.Checked = false;
            chkactivo.Checked = true;
            txtCodigo.Focus();
        }

        private void Blanquear()
        {
            txtCodigo.Text = string.Empty;
            txtdescripcion.Text = string.Empty;
            txtidconta.Text = string.Empty;
            txtdescriptrab.Text = string.Empty;
            txttituloboleta.Text = string.Empty;
            txtdiasplanilla.Value = 0;
            chkactivo.Checked = false;
            chkcts.Checked = false;
            chkgratificacion.Checked = false;
            cboFormapago.SelectedValue = string.Empty;
            cboRubrorpts.SelectedValue = string.Empty;
        }

        private void btnRetro_Click(object sender, EventArgs e)
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
                var xtmpuser = txtCodigo.Text.Trim();
                u_n_opsel = 0;
                TabControl1.SelectedIndex = 0;
                U_RefrescaControles();
                CargaDatos();
                if (Examinar.RowCount > 0)
                {
                    for (lc_cont = 0; lc_cont <= Examinar.Rows.Count - 1; lc_cont++)
                    {
                        if (Examinar.Rows[lc_cont].Cells["tipoplla"].Value.ToString() == xtmpuser)
                        {
                            Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["tipoplla"];
                            break;
                        }
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!(TabControl1.SelectedIndex == 0))
            {
                TabControl1.SelectedIndex = 0;
            }
            u_n_opsel = 2;
            sw_EmpiezaEdicion = true;
            TabControl1.SelectedIndex = 1;
            sw_EmpiezaEdicion = false;
            U_RefrescaControles();
            txtdescripcion.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (U_Validacion())
            {
                try
                {
                    var BL = new tb_plla_tipoplanillaBL();
                    var BE = new tb_plla_tipoplanilla();

                    BE.Tipoplla = txtCodigo.Text.Trim();
                    BE.Tipopllaname = txtdescripcion.Text.Trim();
                    BE.Diasplla = Convert.ToDecimal(txtdiasplanilla.Text);
                    if (cboFormapago.Text.Length > 0)
                    {
                        BE.Formapago = cboFormapago.SelectedValue.ToString();
                    }
                    else
                    {
                        BE.Formapago = string.Empty;
                    }
                    BE.Tituloboleta = txttituloboleta.Text.Trim();
                    BE.Tipopllaemple = txtdescriptrab.Text.Trim();
                    BE.Gratificacion = chkgratificacion.Checked;
                    BE.Pdt = chkpdt.Checked;
                    BE.Cts = chkcts.Checked;
                    if (cboRubrorpts.Text.Length > 0)
                    {
                        BE.Tiptrabid = cboRubrorpts.SelectedValue.ToString();
                    }
                    else
                    {
                        BE.Tiptrabid = string.Empty;
                    }
                    BE.Modoplla = txtidconta.Text.Trim();
                    if (chkactivo.Checked == true)
                    {
                        BE.Status = "0";
                    }
                    if (chkactivo.Checked == false)
                    {
                        BE.Status = "9";
                    }

                    if (u_n_opsel == 1)
                    {
                        if (BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE))
                        {
                            seguridadlog();
                        }
                        else
                        {
                            Frm_Class.ShowError(BL.Sql_Error, this);
                        }
                    }
                    else
                    {
                        if (BL.Update(VariablesPublicas.EmpresaID.ToString(), BE))
                        {
                            seguridadlog();
                        }
                        else
                        {
                            Frm_Class.ShowError(BL.Sql_Error, this);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                U_CancelarEdicion(0);
            }
        }

        private void seguridadlog()
        {
            var xclave = VariablesPublicas.EmpresaID + txtCodigo.Text;
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
                BE.detalle = "Descripción:" + txtdescripcion.Text.Trim();

                BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Examinar.CurrentRow != null)
            {
                var xnomcampo = string.Empty;
                if (xnomcampo.Length == 0)
                {
                    var BL = new tb_plla_tipoplanillaBL();
                    var BE = new tb_plla_tipoplanilla();

                    BE.Tipoplla = Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipoplla"].Value.ToString();
                    BE.norden = 1;
                    BE.ver_blanco = 0;
                    BE.solopdt = 0;
                    tmptabla = BL.GetAll_Consulta(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                    if (BL.Sql_Error.Length == 0)
                    {
                        var message = "Desea eliminar datos " + tmptabla.Rows[0]["tipoplla"].ToString().Trim() + " - " + tmptabla.Rows[0]["tipopllaname"].ToString().Trim() + " ...?";
                        var caption = "Mensaje del Sistema";
                        var buttons = MessageBoxButtons.YesNo;
                        DialogResult result;
                        result = MessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                            var BL1 = new tb_plla_tipoplanillaBL();
                            var BE1 = new tb_plla_tipoplanilla();

                            BE1.Tipoplla = BE.Tipoplla;
                            if (BL1.Delete(VariablesPublicas.EmpresaID.ToString(), BE1))
                            {
                                if (BL1.Sql_Error.Length == 0)
                                {
                                    var BLS = new tb_co_seguridadlogBL();
                                    var BES = new tb_co_seguridadlog();

                                    BES.moduloid = Name;
                                    BES.clave = VariablesPublicas.EmpresaID + Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipoplla"].Value.ToString();
                                    BES.cuser = VariablesPublicas.Usuar;
                                    BES.fecha = DateTime.Now;
                                    BES.pc = VariablesPublicas.userip;
                                    BES.accion = "B";
                                    BES.detalle = "Descripción:" + txtdescripcion.Text.Trim();

                                    BLS.Insert(VariablesPublicas.EmpresaID.ToString(), BES);
                                    Examinar.Rows.Remove(Examinar.CurrentRow);
                                    Examinar.Refresh();
                                    u_PintaDatos();
                                }
                                else
                                {
                                    Frm_Class.ShowError(BL1.Sql_Error, this);
                                }
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
                    MessageBox.Show(xnomcampo, "Imposible Eliminar Registro !!!");
                }
            }
            U_RefrescaControles();
        }

        private void Frm_TipoPlanilla_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (u_n_opsel > 0)
            {
                MessageBox.Show("Finalice edición para cerrar formulario", "Mensaje del Sistema");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            CargaDatos();
            u_PintaDatos();
        }

        public bool U_Validacion()
        {
            var xmsg = string.Empty;
            var objeto = new object();

            if (txtdescripcion.Text.Trim().Length == 0)
            {
                xmsg = "Ingrese Descripción !!!";
                objeto = txtdescripcion;
            }
            var xvarrr = string.Empty;
            if (cboFormapago.SelectedValue != null)
            {
                if (cboFormapago.SelectedValue.ToString().Trim().Length > 0)
                {
                    xvarrr = cboFormapago.SelectedValue.ToString();
                }
            }
            if (xvarrr.Trim().Length == 0)
            {
                xmsg = "Ingrese forma de pago !!!";
                objeto = cboFormapago;
            }
            if (xmsg.Trim().Length > 0)
            {
                MessageBox.Show(xmsg.Trim(), "Error en Ingreso de Datos !!!");
                if (objeto != null)
                {
                    objeto = Focus();
                }
            }
            return xmsg.Trim().Length == 0;
        }

        private void Frm_TipoPlanilla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 & btnNew.Enabled)
            {
                btnNew_Click(sender, e);
            }
            if (e.KeyCode == Keys.F3 & btnEdit.Enabled)
            {
                btnEdit_Click(sender, e);
            }
            if (e.KeyCode == Keys.G & e.Control & btnSave.Enabled)
            {
                btnSave_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (btnRetro.Enabled)
                {
                    btnRetro_Click(sender, e);
                }
                else
                {
                    btnExit_Click(sender, e);
                }
            }
            if (e.KeyCode == Keys.F8 & btnDelete.Enabled)
            {
                btnDelete_Click(sender, e);
            }
            if (e.KeyCode == Keys.F5 & btnLoad.Enabled)
            {
                btnLoad_Click(sender, e);
            }
            if (e.KeyCode == Keys.F4 & Examinar.Enabled)
            {
                TabControl1.SelectedIndex = 0;
                Examinar.Focus();
                Examinar.BeginEdit(true);
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (Examinar.CurrentRow != null)
            {
                var oform = new FrmSeguridad();
                oform._Nombre = Name;
                oform._ClaveForm = VariablesPublicas.EmpresaID + Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipoplla"].Value;
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
                if (Examinar.CurrentCell != null)
                {
                    SendKeys.Send("\t");
                    return true;
                }
                else
                {
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void u_PintaDatos()
        {
            if (!Sw_LOad)
            {
                if (TabControl1.SelectedIndex == 1)
                {
                    if ((Examinar.CurrentRow != null) & !(u_n_opsel == 1))
                    {
                        txtCodigo.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipoplla"].Value.ToString();
                        txtdescripcion.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipopllaname"].Value.ToString();
                        txtdiasplanilla.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["diasplla"].Value.ToString();
                        cboFormapago.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["formapago"].Value.ToString();

                        txttituloboleta.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["tituloboleta"].Value.ToString();
                        txtdescriptrab.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipopllaemple"].Value.ToString();
                        chkgratificacion.Checked = Convert.ToBoolean(Examinar.Rows[Examinar.CurrentRow.Index].Cells["gratificacion"].Value);
                        chkpdt.Checked = Convert.ToBoolean(Examinar.Rows[Examinar.CurrentRow.Index].Cells["pdt"].Value);
                        chkcts.Checked = Convert.ToBoolean(Examinar.Rows[Examinar.CurrentRow.Index].Cells["cts"].Value);
                        chkactivo.Checked = Convert.ToBoolean(Examinar.Rows[Examinar.CurrentRow.Index].Cells["status"].Value);
                        cboRubrorpts.SelectedValue = Equivalencias.Left(Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipotrabpdt"].Value.ToString(), 2);
                        txtidconta.Text = Equivalencias.Mid(Examinar.Rows[Examinar.CurrentRow.Index].Cells["modoplla"].Value.ToString(), 1, 1);
                    }
                }
            }
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            u_Roleo(GlobalVars.GetInstance().TOPRECORD);
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            u_Roleo(GlobalVars.GetInstance().PREVRECORD);
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            u_Roleo(GlobalVars.GetInstance().NEXTRECORD);
        }
        private void btnUltimo_Click(object sender, EventArgs e)
        {
            u_Roleo(GlobalVars.GetInstance().BOTTRECORD);
        }
        public void u_Roleo(string xtipo)
        {
            VariablesPublicas.RoleoGrid(Examinar, xtipo, "tipoplla");
            u_PintaDatos();
        }

        private void txtfiltronombre_GotFocus(object sender, System.EventArgs e)
        {
            j_xFiltronom = txtfiltronombre.Text;
        }
        private void txtfiltronombre_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_xFiltronom == txtfiltronombre.Text) & !Sw_LOad)
            {
                CargaDatos();
            }
        }

        public void U_pINTAR()
        {
            if (1 == 1)
            {
                var LC_NCOLUMNA = 0;
                for (lc_cont = 0; lc_cont <= Examinar.RowCount - 1; lc_cont++)
                {
                    if (Convert.ToBoolean(Examinar.Rows[lc_cont].Cells["status"].Value) == false)
                    {
                        for (LC_NCOLUMNA = 0; LC_NCOLUMNA <= Examinar.ColumnCount - 1; LC_NCOLUMNA++)
                        {
                            Examinar.Rows[lc_cont].DefaultCellStyle.BackColor = lblanulado.BackColor;
                            Examinar.Rows[lc_cont].DefaultCellStyle.ForeColor = lblanulado.ForeColor;
                        }
                    }
                    else
                    {
                        for (LC_NCOLUMNA = 0; LC_NCOLUMNA <= Examinar.ColumnCount - 1; LC_NCOLUMNA++)
                        {
                            Examinar.Rows[lc_cont].DefaultCellStyle.BackColor = Color.White;
                            Examinar.Rows[lc_cont].DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                }
            }
        }

        private void Examinar_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Examinar.CurrentRow != null)
            {
                TabControl1.SelectedIndex = 1;
            }
        }

        private void Examinar_Paint(object sender, PaintEventArgs e)
        {
            U_pINTAR();
        }

        private void Examinar_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Examinar.CurrentRow != null)
            {
                TabControl1.SelectedIndex = 1;
            }
        }

        private void txtidconta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' & e.KeyChar <= '9')
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back | e.KeyChar == (char)Keys.Delete)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            if (e.KeyChar == Convert.ToChar(13))
            {
                SendKeys.Send("\t");
            }
        }
    }
}
