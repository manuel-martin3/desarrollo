using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using BapFormulariosNet.Seguridadlog;
using BapFormulariosNet.Codigo;

namespace BapFormulariosNet.RecursosHumanos.Tablas
{
    public partial class Frm_PeriodosVacacionales : plantilla
    {
        private DataTable tablaclientes;
        private DataTable tmptabla;
        private string xnomcampo = string.Empty;
        private bool sw_EmpiezaEdicion = false;
        private string j_xFiltronom = string.Empty;
        private bool Sw_LOad = true;
        private int u_n_opsel = 0;
        private int lc_cont;
        private string j_periodoinicial = string.Empty;
        private string j_periodofinal = string.Empty;

        public Frm_PeriodosVacacionales()
        {
            InitializeComponent();

            KeyDown += Frm_PeriodosVacacionales_KeyDown;
            FormClosing += Frm_PeriodosVacacionales_FormClosing;
            Load += Frm_PeriodosVacacionales_Load;
            Activated += Frm_PeriodosVacacionales_Activated;

            txtfiltronombre.GotFocus += new System.EventHandler(txtfiltronombre_GotFocus);
            txtfiltronombre.LostFocus += new System.EventHandler(txtfiltronombre_LostFocus);

            txtcodigo.LostFocus += new System.EventHandler(txtcodigo_LostFocus);
        }

        private void Frm_PeriodosVacacionales_Activated(object sender, EventArgs e)
        {
            if (Sw_LOad)
            {
                cmbperiodoinicial.ValueMember = "periodo";
                cmbperiodoinicial.DisplayMember = "periodo";
                var BL = new tb_plla_periodovacacionalBL();
                var BE = new tb_plla_periodovacacional();
                cmbperiodoinicial.DataSource = BL.GetAll_PERIODOS(VariablesPublicas.EmpresaID, BE).Tables[0];

                cmbperiodofinal.ValueMember = "periodo";
                cmbperiodofinal.DisplayMember = "periodo";
                cmbperiodofinal.DataSource = BL.GetAll_PERIODOS(VariablesPublicas.EmpresaID, BE).Tables[0];

                U_RefrescaControles();
                CargaDatos();
                U_RefrescaControles();
                Sw_LOad = false;
            }
        }
        private void Frm_PeriodosVacacionales_Load(object sender, EventArgs e)
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
            MaximizeBox = false;
            WindowState = FormWindowState.Normal;
        }

        private void CargaDatos()
        {
            var nposcolumnasortear = 0;
            var PrvSotOrder = default(SortOrder);
            var zordenado = false;
            var xcodcliente = "..";
            var xpalabra1 = string.Empty;

            if (txtfiltronombre.Text.Trim().Length > 0)
            {
                xpalabra1 = txtfiltronombre.Text.Trim();
            }
            if ((Examinar.CurrentRow != null))
            {
                xcodcliente = Examinar.Rows[Examinar.CurrentRow.Index].Cells["idperiodo"].Value.ToString();
            }
            if ((Examinar.SortedColumn != null))
            {
                nposcolumnasortear = Examinar.SortedColumn.Index;
                PrvSotOrder = Examinar.SortOrder;
                zordenado = true;
            }
            var BL = new tb_plla_periodovacacionalBL();
            var BE = new tb_plla_periodovacacional();
            BE.nomlike = xpalabra1;
            tablaclientes = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
            if (BL.Sql_Error.Length > 0)
            {
                Frm_Class.ShowError(BL.Sql_Error, this);
                return;
            }
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
                Examinar.Sort(Examinar.Columns["idperiodo"], System.ComponentModel.ListSortDirection.Ascending);
            }
            if (Examinar.CurrentRow == null)
            {
                if (Examinar.RowCount > 0)
                {
                    Examinar.CurrentCell = Examinar.Rows[0].Cells["idperiodo"];
                }
            }
            if (Examinar.RowCount > 0)
            {
                lbltotalregistros.Text = Examinar.RowCount.ToString() + " Registro(s)";
            }
            else
            {
                lbltotalregistros.Text = string.Empty;
            }
            for (lc_cont = 0; lc_cont <= Examinar.Rows.Count - 1; lc_cont++)
            {
                if (Examinar.Rows[lc_cont].Cells["idperiodo"].Value.ToString() == xcodcliente.ToString())
                {
                    Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["glosa"];
                    break;
                }
            }
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            u_PintaDatos();
        }

        private void U_RefrescaControles()
        {
            txtdescripcion.Enabled = false;
            cmbperiodoinicial.Enabled = u_n_opsel == 1;
            cmbperiodofinal.Enabled = u_n_opsel == 1;
            txtcodigo.Enabled = u_n_opsel == 1;
            btnload.Enabled = u_n_opsel == 0;
            btnprimero.Enabled = u_n_opsel == 0;
            btnultimo.Enabled = u_n_opsel == 0;
            btnsiguiente.Enabled = u_n_opsel == 0;
            btnanterior.Enabled = u_n_opsel == 0;

            var xcodcliente = string.Empty;
            if ((Examinar.CurrentRow != null))
            {
                xcodcliente = Examinar.Rows[Examinar.CurrentCell.RowIndex].Cells["idperiodo"].Value.ToString();
            }

            btnnuevo.Enabled = u_n_opsel == 0;
            btngrabar.Enabled = u_n_opsel > 0;
            btnmod.Enabled = u_n_opsel == 0 & xcodcliente.Length > 0;
            btneliminar.Enabled = u_n_opsel == 0 & xcodcliente.Length > 0;
            btncancelar.Enabled = u_n_opsel > 0;
            btncerrar.Enabled = u_n_opsel == 0;

            Examinar.Enabled = u_n_opsel == 0;
            btnlog.Enabled = u_n_opsel == 0;
        }

        private void btnnuevo_Click(object sender, EventArgs e)
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
            chkactivo.Checked = true;
            var BL = new tb_plla_periodovacacionalBL();
            var BE = new tb_plla_periodovacacional();
            txtcodigo.Text = BL.GetAll_MaxCodigo(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0].Rows[0]["maximo_codigo"].ToString();
            txtdescripcion.Focus();
        }

        private void Blanquear()
        {
            txtcodigo.Text = string.Empty;
            cmbperiodoinicial.SelectedValue = string.Empty;
            cmbperiodofinal.SelectedValue = string.Empty;
            txtdescripcion.Text = string.Empty;
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
                    for (lc_cont = 0; lc_cont <= Examinar.Rows.Count - 1; lc_cont++)
                    {
                        if (Examinar.Rows[lc_cont].Cells["idperiodo"].Value.ToString() == xtmpuser.ToString())
                        {
                            Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["glosa"];
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

            TabControl1.SelectedIndex = 1;
            sw_EmpiezaEdicion = false;
            U_RefrescaControles();
            j_periodoinicial = cmbperiodoinicial.SelectedValue.ToString();
            j_periodofinal = cmbperiodofinal.SelectedValue.ToString();
            txtdescripcion.Focus();
        }

        private void btngrabar_Click(object sender, EventArgs e)
        {
            if (U_Validacion())
            {
                var BL = new tb_plla_periodovacacionalBL();
                var BE = new tb_plla_periodovacacional();
                BE.idperiodo = txtcodigo.Text.Trim();
                tmptabla = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (tmptabla.Rows.Count == 0)
                {
                    tmptabla.Rows.Add(VariablesPublicas.INSERTINTOTABLE(tmptabla));
                }
                tmptabla.Rows[0]["idperiodo"] = txtcodigo.Text;
                tmptabla.Rows[0]["periodo"] = cmbperiodoinicial.SelectedValue + "-" + cmbperiodofinal.SelectedValue;
                tmptabla.Rows[0]["glosa"] = txtdescripcion.Text;
                tmptabla.Rows[0]["status"] = (chkactivo.Checked ? 1 : 0);
                tmptabla.AcceptChanges();

                if (BL.Insert_Update(VariablesPublicas.EmpresaID, BE, tmptabla))
                {
                    seguridadlog();
                    U_CancelarEdicion(0);
                }
                else
                {
                    Frm_Class.ShowError(BL.Sql_Error, this);
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
                BE.detalle = "Descripción: " + txtdescripcion.Text;

                BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if ((Examinar.CurrentRow != null))
            {
                xnomcampo = string.Empty;

                if (xnomcampo.Length == 0)
                {
                    var BL = new tb_plla_periodovacacionalBL();
                    var BE = new tb_plla_periodovacacional();
                    BE.idperiodo = Examinar.Rows[Examinar.CurrentRow.Index].Cells["idperiodo"].Value.ToString();
                    tmptabla = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                    if (BL.Sql_Error.Length == 0)
                    {
                        var message = "Desea eliminar datos  " + tmptabla.Rows[0]["idperiodo"].ToString().Trim() + "-" + tmptabla.Rows[0]["glosa"].ToString().Trim() + " ...?";
                        var caption = "Mensaje del Sistema";
                        var buttons = MessageBoxButtons.YesNo;
                        DialogResult result;
                        result = MessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                            BL.Eliminar(VariablesPublicas.EmpresaID, tmptabla);
                            if (BL.Sql_Error.Length == 0)
                            {
                                var BLL = new tb_co_seguridadlogBL();
                                var BEL = new tb_co_seguridadlog();

                                BEL.moduloid = Name;
                                BEL.clave = VariablesPublicas.EmpresaID + Examinar.Rows[Examinar.CurrentRow.Index].Cells["idperiodo"].Value.ToString();
                                BEL.cuser = VariablesPublicas.Usuar;
                                BEL.fecha = DateTime.Now;
                                BEL.pc = VariablesPublicas.userip;
                                BEL.accion = "B";
                                BEL.detalle = "Descripción: " + txtdescripcion.Text;
                                BLL.Insert(VariablesPublicas.EmpresaID.ToString(), BEL);
                                Examinar.Rows.Remove(Examinar.CurrentRow);

                                Examinar.Refresh();
                                u_PintaDatos();
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

        private void Frm_PeriodosVacacionales_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnload_Click(object sender, EventArgs e)
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
                xmsg = "Ingrese Descripción";
                objeto = txtdescripcion;
            }
            if (VariablesPublicas.ComboBoxValor(cmbperiodoinicial, false).Length == 0)
            {
                xmsg = xmsg + "\r" + "Ingrese Periodo Inicial";
                objeto = cmbperiodoinicial;
            }
            else
            {
                if (VariablesPublicas.ComboBoxValor(cmbperiodofinal, false).Length == 0)
                {
                    xmsg = xmsg + "\r" + "Ingrese Periodo Final";
                    objeto = cmbperiodofinal;
                }
                else
                {
                    if (!(Convert.ToInt32(cmbperiodofinal.SelectedValue) >= Convert.ToInt32(cmbperiodoinicial.SelectedValue)))
                    {
                        xmsg = xmsg + "\r" + "Periodo Final debe ser mayor o igual al periodo inicial";
                        objeto = cmbperiodoinicial;
                    }
                    else
                    {
                        if (u_n_opsel == 1 | (j_periodoinicial != cmbperiodoinicial.SelectedValue.ToString() | j_periodofinal != cmbperiodofinal.SelectedValue.ToString()))
                        {
                            var BL = new tb_plla_periodovacacionalBL();
                            var BE = new tb_plla_periodovacacional();
                            BE.periodoini = cmbperiodoinicial.SelectedValue.ToString();
                            BE.periodofin = cmbperiodofinal.SelectedValue.ToString();
                            tmptabla = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                            if (BL.Sql_Error.Length == 0)
                            {
                                if (tmptabla.Rows.Count > 0)
                                {
                                    xmsg = xmsg + "\r" + "Periodo ya registrado En Código " + tmptabla.Rows[0]["idperiodo"];
                                    objeto = cmbperiodoinicial;
                                }
                            }
                            else
                            {
                                xmsg = BL.Sql_Error;
                            }
                        }
                    }
                }
            }
            if (u_n_opsel == 1)
            {
                var BL = new tb_plla_periodovacacionalBL();
                var BE = new tb_plla_periodovacacional();
                BE.idperiodo = txtcodigo.Text.Trim();
                tmptabla = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (BL.Sql_Error.Length == 0)
                {
                    if (tmptabla.Rows.Count > 0)
                    {
                        xmsg = xmsg + "\r" + "Código ya registrado";
                        txtcodigo.Text = string.Empty;
                        objeto = txtcodigo;
                    }
                }
                else
                {
                    xmsg = BL.Sql_Error;
                }
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

        private void Frm_PeriodosVacacionales_KeyDown(object sender, KeyEventArgs e)
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
            if (e.KeyCode == Keys.F4 & Examinar.Enabled)
            {
                TabControl1.SelectedIndex = 0;
                Examinar.Focus();
                Examinar.BeginEdit(true);
            }
        }

        private void btnlog_Click(object sender, EventArgs e)
        {
            if ((Examinar.CurrentRow != null))
            {
                var oform = new FrmSeguridad();
                oform._Nombre = Name;
                oform._ClaveForm = VariablesPublicas.EmpresaID + Examinar.Rows[Examinar.CurrentRow.Index].Cells["idperiodo"].Value;
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
                if ((Examinar.CurrentCell != null))
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
                        txtcodigo.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["idperiodo"].Value.ToString();
                        txtdescripcion.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["glosa"].Value.ToString();
                        cmbperiodoinicial.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["periodo_inicial"].Value;
                        cmbperiodofinal.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["periodo_final"].Value;
                        chkactivo.Checked = Convert.ToInt32(Examinar.Rows[Examinar.CurrentRow.Index].Cells["status"].Value) == 1;
                    }
                }
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
            VariablesPublicas.RoleoGrid(Examinar, xtipo, "idperiodo");
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

        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        public void U_pINTAR()
        {
        }

        private void Examinar_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((Examinar.CurrentRow != null))
            {
                TabControl1.SelectedIndex = 1;
            }
        }

        private void Examinar_Paint(object sender, PaintEventArgs e)
        {
            U_pINTAR();
        }

        private void txtcodigo_LostFocus(object sender, System.EventArgs e)
        {
            if (u_n_opsel > 0)
            {
                if (txtcodigo.Text.Trim().Length > 0)
                {
                    txtcodigo.Text = VariablesPublicas.PADL(txtcodigo.Text.Trim(), txtcodigo.MaxLength, "0");
                }
                else
                {
                    var BL = new tb_plla_periodovacacionalBL();
                    var BE = new tb_plla_periodovacacional();
                    txtcodigo.Text = BL.GetAll_MaxCodigo(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0].Rows[0]["maximo_codigo"].ToString();
                }
            }
        }

        public void u_Armadescripcion()
        {
            var xvar = "PERIODO VACACIONAL ";
            if (!(VariablesPublicas.ComboBoxValor(cmbperiodoinicial, false).Length == 0))
            {
                xvar = xvar + cmbperiodoinicial.SelectedValue + "-";
            }
            if (!(VariablesPublicas.ComboBoxValor(cmbperiodofinal, false).Length == 0))
            {
                xvar = xvar + cmbperiodofinal.SelectedValue;
            }
            txtdescripcion.Text = xvar;
        }

        private void cmbperiodoinicial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0)
            {
                u_Armadescripcion();
            }
        }

        private void cmbperiodofinal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0)
            {
                u_Armadescripcion();
            }
        }
    }
}
