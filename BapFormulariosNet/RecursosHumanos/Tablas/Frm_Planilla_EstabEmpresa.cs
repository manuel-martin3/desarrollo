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

namespace BapFormulariosNet.RecursosHumanos.Tablas
{
    public partial class Frm_Planilla_EstabEmpresa : plantilla
    {
        private DataTable tablaclientes;
        private string xnomcampo = string.Empty;
        private string VM_DESCRIPCION = string.Empty;
        private DataTable tmpcursor;
        private string j_xFiltronom = string.Empty;
        private bool sw_EmpiezaEdicion = false;
        private DataTable tmptabla;
        private bool Sw_LOad = true;
        private int u_n_opsel = 0;
        private int lc_cont;
        private int cdClave = 0;

        public Frm_Planilla_EstabEmpresa()
        {
            InitializeComponent();

            KeyDown += Frm_Planilla_EstabEmpresa_KeyDown;
            FormClosing += Frm_Planilla_EstabEmpresa_FormClosing;
            Load += Frm_Planilla_EstabEmpresa_Load;
            Activated += Frm_Planilla_EstabEmpresa_Activated;

            txtfiltronombre.GotFocus += new System.EventHandler(txtfiltronombre_GotFocus);
            txtfiltronombre.LostFocus += new System.EventHandler(txtfiltronombre_LostFocus);

            txtcodigo.LostFocus += new System.EventHandler(txtcodigo_LostFocus);

            txtdescripcion.GotFocus += new System.EventHandler(txtdescripcion_GotFocus);
        }

        private void Frm_Planilla_EstabEmpresa_Activated(object sender, EventArgs e)
        {
            if (Sw_LOad)
            {
                U_RefrescaControles();
                CargaDatos();
                U_RefrescaControles();
                Sw_LOad = false;
            }
        }
        private void Frm_Planilla_EstabEmpresa_Load(object sender, EventArgs e)
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

        public void Llenar_cboTipoEstab()
        {
            try
            {
                cmbtipo.DataSource = NewMethodoTE();
                cmbtipo.DisplayMember = "Value";
                cmbtipo.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethodoTE()
        {
            var BL = new tb_plla_pdt_tabla02BL();
            var BE = new tb_plla_pdt_tabla02();

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

        private void CargaDatos()
        {
            Llenar_cboTipoEstab();
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
            if ((Examinar.CurrentRow != null))
            {
                xcodcliente = Examinar.Rows[Examinar.CurrentRow.Index].Cells["estabid"].Value.ToString();
            }
            if ((Examinar.SortedColumn != null))
            {
                nposcolumnasortear = Examinar.SortedColumn.Index;
                PrvSotOrder = Examinar.SortOrder;
                zordenado = true;
            }
            var BL = new tb_plla_establecimientosBL();
            var BE = new tb_plla_establecimientos();
            BE.empresaid = VariablesPublicas.EmpresaID;
            BE.nomlike1 = xpalabra1;
            BE.nomlike3 = xpalabra2;
            BE.nomlike2 = xpalabra3;
            BE.norden = 1;
            BE.ver_blanco = 0;
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
                Examinar.Sort(Examinar.Columns["estabid"], System.ComponentModel.ListSortDirection.Ascending);
            }
            if (Examinar.CurrentRow == null)
            {
                if (Examinar.RowCount > 0)
                {
                    Examinar.CurrentCell = Examinar.Rows[0].Cells["estabname"];
                }
            }
            for (lc_cont = 0; lc_cont <= Examinar.Rows.Count - 1; lc_cont++)
            {
                if (Examinar.Rows[lc_cont].Cells["estabid"].Value.ToString() == xcodcliente)
                {
                    Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["estabname"];
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
            btnpdt.Enabled = u_n_opsel == 0;
            txtcodigo.Enabled = u_n_opsel == 1;
            txtdescripcion.Enabled = u_n_opsel > 0;
            cmbtipo.Enabled = u_n_opsel > 0;
            btnload.Enabled = u_n_opsel == 0;
            btnprimero.Enabled = u_n_opsel == 0;
            btnultimo.Enabled = u_n_opsel == 0;
            btnsiguiente.Enabled = u_n_opsel == 0;
            btnanterior.Enabled = u_n_opsel == 0;

            var xcodcliente = string.Empty;
            if ((Examinar.CurrentRow != null))
            {
                xcodcliente = Examinar.Rows[Examinar.CurrentCell.RowIndex].Cells["estabid"].Value.ToString();
            }

            btnnuevo.Enabled = u_n_opsel == 0;
            btngrabar.Enabled = u_n_opsel > 0;
            btnmod.Enabled = u_n_opsel == 0 & xcodcliente.Length > 0;
            btneliminar.Enabled = u_n_opsel == 0 & xcodcliente.Length > 0;
            btncancelar.Enabled = u_n_opsel > 0;
            btncerrar.Enabled = u_n_opsel == 0;
            barramain.Enabled = cdClave == 0;
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
            var BL = new tb_plla_establecimientosBL();
            var BE = new tb_plla_establecimientos();
            BE.empresaid = VariablesPublicas.EmpresaID;
            txtcodigo.Text = BL.GetAll_MaxCodigo(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0].Rows[0]["maximo_codigo"].ToString();
            txtdescripcion.Focus();
        }

        private void Blanquear()
        {
            txtcodigo.Text = string.Empty;
            txtdescripcion.Text = string.Empty;
            cmbtipo.SelectedValue = string.Empty;
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
                        if (Examinar.Rows[lc_cont].Cells["estabid"].Value.ToString() == xtmpuser)
                        {
                            Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["estabname"];
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
            VM_DESCRIPCION = txtdescripcion.Text;
            txtdescripcion.Focus();
        }

        private void btngrabar_Click(object sender, EventArgs e)
        {
            if (U_Validacion())
            {
                var BL = new tb_plla_establecimientosBL();
                var BE = new tb_plla_establecimientos();
                BE.empresaid = VariablesPublicas.EmpresaID;
                BE.estabid = txtcodigo.Text.Trim();
                BE.norden = 1;
                BE.ver_blanco = 0;
                tmpcursor = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (u_n_opsel == 1)
                {
                    while (1 == 1)
                    {
                        tmpcursor = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                        if (BL.Sql_Error.Length > 0)
                        {
                            Frm_Class.ShowError(BL.Sql_Error + "\r" + "Error al buscar código", this);
                            return;
                        }
                        if (tmpcursor.Rows.Count > 0)
                        {
                            var BLMX = new tb_plla_establecimientosBL();
                            var BEMX = new tb_plla_establecimientos();
                            BEMX.empresaid = VariablesPublicas.EmpresaID;
                            txtcodigo.Text = BLMX.GetAll_MaxCodigo(VariablesPublicas.EmpresaID.ToString(), BEMX).Tables[0].Rows[0]["maximo_codigo"].ToString();
                        }
                        else
                        {
                            break;
                        }
                    }
                    tmpcursor = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                    tmpcursor.Rows.Add(VariablesPublicas.InsertIntoTable(tmpcursor));
                    tmpcursor.Rows[0]["estabid"] = txtcodigo.Text;
                }
                tmpcursor.Rows[0]["estabname"] = txtdescripcion.Text.Trim();
                tmpcursor.Rows[0]["estabrtps"] = cmbtipo.SelectedValue;
                tmpcursor.Rows[0]["empresaid"] = VariablesPublicas.EmpresaID;
                tmpcursor.Rows[0]["status"] = chkActivo.Checked;
                tmpcursor.AcceptChanges();
                if (BL.Insert_Update(VariablesPublicas.EmpresaID, BE, tmpcursor))
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
            var xclave = VariablesPublicas.EmpresaID + txtcodigo.Text;
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
                var BLIR = new tb_plla_establecimientosBL();
                var BEIR = new tb_plla_establecimientos();
                BEIR.empresaid = Examinar.Rows[Examinar.CurrentRow.Index].Cells["empresaid"].Value.ToString();
                BEIR.estabid = Examinar.Rows[Examinar.CurrentRow.Index].Cells["estabid"].Value.ToString();
                tmpcursor = BLIR.GetAll_CONSULTAIR(VariablesPublicas.EmpresaID, BEIR).Tables[0];
                if (BLIR.Sql_Error.Length > 0)
                {
                    xnomcampo = BLIR.Sql_Error;
                    Frm_Class.ShowError(BLIR.Sql_Error, this);
                }
                else
                {
                    if (tmpcursor.Rows.Count == 0)
                    {
                    }
                    else
                    {
                        for (lc_cont = 0; lc_cont <= tmpcursor.Rows.Count - 1; lc_cont++)
                        {
                            xnomcampo = xnomcampo + tmpcursor.Rows[lc_cont]["relacion"] + "\r";
                            if (lc_cont + 1 == 10)
                            {
                                break;
                            }
                        }
                    }
                }
                if (xnomcampo.Length == 0)
                {
                    var BL = new tb_plla_establecimientosBL();
                    var BE = new tb_plla_establecimientos();
                    BE.empresaid = Examinar.Rows[Examinar.CurrentRow.Index].Cells["empresaid"].Value.ToString();
                    BE.estabid = Examinar.Rows[Examinar.CurrentRow.Index].Cells["estabid"].Value.ToString();
                    BE.norden = 1;
                    BE.ver_blanco = 0;
                    tmptabla = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                    if (BL.Sql_Error.Length == 0)
                    {
                        var message = "Desea eliminar datos  " + tmptabla.Rows[0]["estabid"].ToString().Trim() + "-" + tmptabla.Rows[0]["estabname"].ToString().Trim() + " ...?";
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
                                BEL.clave = VariablesPublicas.EmpresaID + Examinar.Rows[Examinar.CurrentRow.Index].Cells["estabid"].Value.ToString();
                                BEL.cuser = VariablesPublicas.Usuar;
                                BEL.fecha = DateTime.Now;
                                BEL.pc = VariablesPublicas.userip;
                                BEL.accion = "B";
                                BEL.detalle = "Cargo: " + txtdescripcion.Text;
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

        private void Frm_Planilla_EstabEmpresa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (u_n_opsel > 0)
            {
                MessageBox.Show("Finalice edición para cerrar formulario", string.Empty);
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
            if (!(VM_DESCRIPCION == txtdescripcion.Text) & u_n_opsel > 1)
            {
                xnomcampo = string.Empty;
                var BL = new tb_plla_establecimientosBL();
                var BE = new tb_plla_establecimientos();
                BE.empresaid = VariablesPublicas.EmpresaID;
                BE.estabid = txtcodigo.Text.Trim();
                tmpcursor = BL.GetAll_CONSULTAIR(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (BL.Sql_Error.Length > 0)
                {
                    xnomcampo = BL.Sql_Error;
                    Frm_Class.ShowError(BL.Sql_Error, this);
                    return false;
                }
                else
                {
                    if (tmpcursor.Rows.Count == 0)
                    {
                    }
                    else
                    {
                        for (lc_cont = 0; lc_cont <= tmpcursor.Rows.Count - 1; lc_cont++)
                        {
                            xnomcampo = xnomcampo + tmpcursor.Rows[lc_cont]["relacion"] + "\r";
                            if (lc_cont + 1 == 10)
                            {
                                break;
                            }
                        }
                    }
                }
                if (xnomcampo.Length > 0)
                {
                    if (!(MessageBox.Show("DESCRIPCION ANTERIOR :" + VM_DESCRIPCION + " SE USA EN " + "\r" + xnomcampo + "\r" + "DESEA REEMPLAZAR DESCRIPCION ...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes))
                    {
                        return false;
                    }
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

        private void Frm_Planilla_EstabEmpresa_KeyDown(object sender, KeyEventArgs e)
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
                oform._ClaveForm = VariablesPublicas.EmpresaID + Examinar.Rows[Examinar.CurrentRow.Index].Cells["estabid"].Value;
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
                        txtdescripcion.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["estabname"].Value.ToString();
                        txtcodigo.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["estabid"].Value.ToString();
                        cmbtipo.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["estabrtps"].Value;
                        chkActivo.Checked = Convert.ToBoolean(Examinar.Rows[Examinar.CurrentRow.Index].Cells["status"].Value);
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
            VariablesPublicas.RoleoGrid(Examinar, xtipo, "estabname");
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

        private void txtcodigo_LostFocus(object sender, System.EventArgs e)
        {
            if (u_n_opsel > 0)
            {
                if (txtcodigo.Text.Trim().Length > 0)
                {
                    txtcodigo.Text = VariablesPublicas.PADL(txtcodigo.Text.Trim(), txtcodigo.MaxLength, "0");
                    if (txtcodigo.Text == "0000")
                    {
                        txtdescripcion.Text = "DOMICILIO FISCAL";
                    }
                }
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
            if ((Examinar.CurrentRow != null))
            {
                TabControl1.SelectedIndex = 1;
            }
        }

        private void Examinar_Paint(object sender, PaintEventArgs e)
        {
            U_pINTAR();
        }

        private void txtdescripcion_GotFocus(object sender, System.EventArgs e)
        {
            if (txtdescripcion.Text.Trim().Length > 0)
            {
                txtdescripcion.SelectAll();
            }
        }

        private void btnpdt_Click(object sender, EventArgs e)
        {
            var vmtxtcarpeta = System.IO.Directory.GetCurrentDirectory();
            if (tmpcursor.Rows.Count == 0)
            {
                Frm_Class.u_NoHayInfo();
            }
            else
            {
                var _with1 = FolderBrowserDialog1;
                _with1.Reset();
                _with1.Description = "Seleccionar Carpeta";

                _with1.ShowNewFolderButton = false;
                var ret = _with1.ShowDialog();
                if (ret == System.Windows.Forms.DialogResult.OK)
                {
                    vmtxtcarpeta = _with1.SelectedPath;
                }
                _with1.Dispose();

                if (vmtxtcarpeta.Trim().Length > 0)
                {
                    var xtmpstring = string.Empty;
                    var xvmfile = VariablesPublicas.Addbs(vmtxtcarpeta) + tmpcursor.Rows[0]["ruc_empresa"] + ".esp";
                    if (xtmpstring.Trim().Length > 0)
                    {
                        MessageBox.Show(xtmpstring, "Error al Generar Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Archivo " + xvmfile + "\r" + "Generado Satisfactoriamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione carpeta donde generar archivo", "Mensaje del Sistema");
                }
            }
        }
    }
}
