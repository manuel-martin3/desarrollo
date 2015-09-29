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

namespace BapFormulariosNet.RecursosHumanos
{
    public partial class Frm_NumeracionPlanilla : plantilla
    {
        private DataTable tablaclientes;
        private DataTable tmpcursor;
        private string j_xFiltronom = string.Empty;
        private bool sw_EmpiezaEdicion = false;
        private DataTable tmptabla;
        private string vm_formapago = string.Empty;
        private bool Sw_LOad = true;
        private int u_n_opsel = 0;
        private int lc_cont;
        private int cdClave = 0;

        public Frm_NumeracionPlanilla()
        {
            InitializeComponent();

            KeyDown += Frm_NumeracionPlanilla_KeyDown;
            FormClosing += Frm_NumeracionPlanilla_FormClosing;
            Load += Frm_NumeracionPlanilla_Load;
            Activated += Frm_NumeracionPlanilla_Activated;

            txtfiltronombre.LostFocus += new System.EventHandler(txtfiltronombre_LostFocus);
            txtfiltronombre.GotFocus += new System.EventHandler(txtfiltronombre_GotFocus);

            txtcodigo.LostFocus += new System.EventHandler(txtcodigo_LostFocus);
        }

        private void Llenar_cboTipoPlanillaFil()
        {
            var BL = new tb_plla_tipoplanillaBL();
            var BE = new tb_plla_tipoplanilla();
            BE.norden = 1;
            BE.ver_blanco = 0;
            cmbfiltrotipoplanilla.ValueMember = "tipoplla";
            cmbfiltrotipoplanilla.DisplayMember = "tipopllaname";
            tmpcursor = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
            cmbfiltrotipoplanilla.SelectedValue = string.Empty;
            if (BL.Sql_Error.Length == 0)
            {
                cmbfiltrotipoplanilla.DataSource = tmpcursor;
                if (tmpcursor.Rows.Count > 0)
                {
                    cmbfiltrotipoplanilla.SelectedValue = tmpcursor.Rows[0]["tipoplla"];
                }
            }
        }
        private void Llenar_cboTipoPlanilla()
        {
            try
            {
                cmbtipoplanilla.DataSource = NewMethoTP();
                cmbtipoplanilla.DisplayMember = "Value";
                cmbtipoplanilla.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethoTP()
        {
            var BL = new tb_plla_tipoplanillaBL();
            var BE = new tb_plla_tipoplanilla();

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

        private void Llenar_cboModalidadPlla()
        {
            var BL = new tb_plla_tab0100BL();
            var BE = new tb_plla_tab0100();
            cmbmodalidad.ValueMember = "cele";
            cmbmodalidad.DisplayMember = "descrip";
            cmbmodalidad.DataSource = BL.ModalidadPlanilla_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
        }

        private void llenar_cboMeses()
        {
            try
            {
                cmbmes.DataSource = NewMethodMeses();
                cmbmes.DisplayMember = "Value";
                cmbmes.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethodMeses()
        {
            var BL = new tb_co_mesesBL();
            var BE = new tb_co_meses();

            BE.ntipo = 1;
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

        private void Llenar_cboTipoQuincena()
        {
            var BL = new tb_plla_tab0100BL();
            var BE = new tb_plla_tab0100();
            cmbtipoquincena.ValueMember = "codigo";
            cmbtipoquincena.DisplayMember = "descrip";
            cmbtipoquincena.DataSource = BL.TipoQuincena_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
        }

        private void Frm_NumeracionPlanilla_Activated(object sender, EventArgs e)
        {
            if (Sw_LOad)
            {
                Llenar_cboTipoPlanillaFil();
                cmbfiltrotipoplanilla.SelectedValue = "B";

                Llenar_cboModalidadPlla();

                llenar_cboMeses();

                Llenar_cboTipoQuincena();

                Llenar_cboTipoPlanilla();

                U_RefrescaControles();
                CargaDatos();
                U_RefrescaControles();
                Sw_LOad = false;
            }
        }
        private void Frm_NumeracionPlanilla_Load(object sender, EventArgs e)
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
            var xtipoplanilla = string.Empty;
            if (cmbfiltrotipoplanilla.Enabled)
            {
                if ((cmbfiltrotipoplanilla.SelectedValue != null))
                {
                    xtipoplanilla = cmbfiltrotipoplanilla.SelectedValue.ToString();
                }
            }
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
                xcodcliente = Examinar.Rows[Examinar.CurrentRow.Index].Cells["asiento"].Value.ToString();
            }
            if ((Examinar.SortedColumn != null))
            {
                nposcolumnasortear = Examinar.SortedColumn.Index;
                PrvSotOrder = Examinar.SortOrder;
                zordenado = true;
            }
            var BL = new tb_plla_numeracionpllaBL();
            var BE = new tb_plla_numeracionplla();
            BE.perianio = VariablesPublicas.perianio;
            BE.tipoplla = xtipoplanilla;
            BE.nomlike1 = xpalabra1;
            BE.nomlike2 = xpalabra2;
            BE.nomlike3 = xpalabra3;
            BE.norden = 1;
            tablaclientes = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
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
                Examinar.Sort(Examinar.Columns["asiento"], System.ComponentModel.ListSortDirection.Ascending);
            }
            if (Examinar.CurrentRow == null)
            {
                if (Examinar.RowCount > 0)
                {
                    Examinar.CurrentCell = Examinar.Rows[0].Cells["asiento"];
                }
            }
            for (lc_cont = 0; lc_cont <= Examinar.Rows.Count - 1; lc_cont++)
            {
                if (Examinar.Rows[lc_cont].Cells["asiento"].Value.ToString() == xcodcliente)
                {
                    Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["asiento"];
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
            txtcodigo.Enabled = u_n_opsel == 1;
            txtdescripcion.Enabled = u_n_opsel > 0;
            cmbtipoplanilla.Enabled = u_n_opsel == 1;
            cmbmodalidad.Enabled = u_n_opsel > 0;
            cmbtipoquincena.Enabled = u_n_opsel > 0 & vm_formapago == "2";
            cmbmes.Enabled = u_n_opsel > 0;
            txtsemana.Enabled = u_n_opsel > 0 & vm_formapago == "3";

            frangolabini.Enabled = u_n_opsel > 0;
            frangolabfin.Enabled = u_n_opsel > 0;
            frangotrabini.Enabled = u_n_opsel > 0 & vm_formapago != "3";
            frangotrabfin.Enabled = u_n_opsel > 0 & vm_formapago != "3";

            btnload.Enabled = u_n_opsel == 0;
            btnprimero.Enabled = u_n_opsel == 0;
            btnultimo.Enabled = u_n_opsel == 0;
            btnsiguiente.Enabled = u_n_opsel == 0;
            btnanterior.Enabled = u_n_opsel == 0;
            cmbfiltrotipoplanilla.Enabled = u_n_opsel == 0;
            var xcodcliente = string.Empty;
            if ((Examinar.CurrentRow != null))
            {
                xcodcliente = Examinar.Rows[Examinar.CurrentCell.RowIndex].Cells["asiento"].Value.ToString();
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
            txtcodigo.Text = string.Empty;
            cmbtipoplanilla.SelectedValue = cmbfiltrotipoplanilla.SelectedValue;
            cmbmodalidad.SelectedValue = "1";
            cmbtipoquincena.SelectedValue = string.Empty;
            cmbmes.SelectedValue = VariablesPublicas.PADL(DateTime.Now.Month.ToString(), 2, "0");
            U_RefrescaControles();
            txtdescripcion.Focus();
        }

        private void Blanquear()
        {
            txtcodigo.Text = string.Empty;
            txtdescripcion.Text = string.Empty;
            cmbmodalidad.SelectedValue = string.Empty;
            cmbtipoquincena.SelectedValue = string.Empty;
            cmbmes.SelectedValue = VariablesPublicas.PADL(DateTime.Now.Month.ToString(), 2, "0");
            txtsemana.Text = string.Empty;
            vm_formapago = string.Empty;
            frangolabini.Value = DateTime.Now;
            frangolabfin.Value = DateTime.Now;
            frangotrabini.Checked = false;
            frangotrabfin.Checked = false;
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
                sw_prosigue = MessageBox.Show("Desea cancelar ingreso de datos...?", "Mensaje del Sistema", MessageBoxButtons.YesNo) == DialogResult.Yes;
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
                        if (Examinar.Rows[lc_cont].Cells["asiento"].Value.ToString() == xtmpuser)
                        {
                            Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["asiento"];
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
            txtdescripcion.Focus();
        }

        private void btngrabar_Click(object sender, EventArgs e)
        {
            if (U_Validacion())
            {
                var tmpcursor = new DataTable();
                var BL = new tb_plla_numeracionpllaBL();
                var BE = new tb_plla_numeracionplla();
                BE.perianio = VariablesPublicas.perianio;
                BE.asiento = txtcodigo.Text.Trim();
                BE.norden = 1;
                tmpcursor = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (u_n_opsel == 1)
                {
                    tmpcursor = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                    if (tmpcursor.Rows.Count > 0)
                    {
                        MessageBox.Show("Número de planilla ya existente", "Mensaje del Sistema");
                    }

                    tmpcursor.Rows.Add(VariablesPublicas.INSERTINTOTABLE(tmpcursor));
                    tmpcursor.Rows[0]["perianio"] = VariablesPublicas.perianio;
                    tmpcursor.Rows[0]["asiento"] = txtcodigo.Text.Trim();
                }
                tmpcursor.Rows[0]["perimes"] = cmbmes.SelectedValue;
                tmpcursor.Rows[0]["tipoplla"] = cmbtipoplanilla.SelectedValue;
                if ((cmbmodalidad.SelectedValue != null))
                {
                    tmpcursor.Rows[0]["planit"] = Convert.ToInt16(cmbmodalidad.SelectedValue);
                }
                tmpcursor.Rows[0]["glosa"] = txtdescripcion.Text.Trim();
                if (frangolabini.Checked)
                {
                    tmpcursor.Rows[0]["fechaini"] = frangolabini.Value;
                }
                else
                {
                    tmpcursor.Rows[0]["fechaini"] = DBNull.Value;
                }
                if (frangolabfin.Checked)
                {
                    tmpcursor.Rows[0]["fechafin"] = frangolabfin.Value;
                }
                else
                {
                    tmpcursor.Rows[0]["fechafin"] = DBNull.Value;
                }
                tmpcursor.Rows[0]["nsemana"] = VariablesPublicas.StringtoDecimal(txtsemana.Text);
                tmpcursor.Rows[0]["status"] = '0';
                if (frangotrabini.Checked)
                {
                    tmpcursor.Rows[0]["fechpini"] = frangotrabini.Value;
                }
                else
                {
                    tmpcursor.Rows[0]["fechpini"] = DBNull.Value;
                }
                if (frangotrabfin.Checked)
                {
                    tmpcursor.Rows[0]["fechpfin"] = frangotrabfin.Value;
                }
                else
                {
                    tmpcursor.Rows[0]["fechpfin"] = DBNull.Value;
                }
                if ((cmbtipoquincena.SelectedValue != null))
                {
                    tmpcursor.Rows[0]["tipoquincena"] = cmbtipoquincena.SelectedValue;
                }

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
            var xclave = VariablesPublicas.EmpresaID + VariablesPublicas.perianio + txtcodigo.Text.Trim();
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
                BE.detalle = "NUMERO DE PLANILA: " + txtcodigo.Text.Trim() + " | " + txtdescripcion.Text.Trim();

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
                var xnomcampo = string.Empty;
                var BL = new tb_plla_numeracionpllaBL();
                var BE = new tb_plla_numeracionplla();
                BE.perianio = Examinar.Rows[Examinar.CurrentRow.Index].Cells["perianio"].Value.ToString();
                BE.asiento = Examinar.Rows[Examinar.CurrentRow.Index].Cells["asiento"].Value.ToString();
                tmpcursor = BL.GetAll_CONSULTAIR(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (BL.Sql_Error.Length > 0)
                {
                    xnomcampo = BL.Sql_Error;
                    Frm_Class.ShowError(BL.Sql_Error, this);
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
                    BE.norden = 1;
                    tmptabla = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                    if (BL.Sql_Error.Length == 0)
                    {
                        var message = "Desea eliminar datos de la Numeración " + tmptabla.Rows[0]["asiento"].ToString().Trim() + "-" + tmptabla.Rows[0]["glosa"].ToString().Trim() + " ...?";
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
                                BEL.clave = VariablesPublicas.EmpresaID + Examinar.Rows[Examinar.CurrentRow.Index].Cells["perianio"].Value.ToString() + Examinar.Rows[Examinar.CurrentRow.Index].Cells["asiento"].Value.ToString();
                                BEL.cuser = VariablesPublicas.Usuar;
                                BEL.fecha = DateTime.Now;
                                BEL.pc = VariablesPublicas.userip;
                                BEL.accion = "B";
                                BEL.detalle = "NUMERO DE PLANILA: " + txtcodigo.Text.Trim() + " | " + txtdescripcion.Text.Trim();
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

        private void Frm_NumeracionPlanilla_FormClosing(object sender, FormClosingEventArgs e)
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

            if (txtcodigo.Text.Trim().Length == 0)
            {
                xmsg = xmsg + "\r" + "Ingrese Código";
                objeto = txtcodigo;
            }
            else
            {
                if (u_n_opsel > 0)
                {
                    txtcodigo.Text = VariablesPublicas.PADL(txtcodigo.Text, txtcodigo.MaxLength, "0");
                }
            }

            if (txtdescripcion.Text.Trim().Length == 0)
            {
                xmsg = "Ingrese Descripción";
                objeto = txtdescripcion;
            }
            var xvarrr = string.Empty;
            if ((cmbtipoplanilla.SelectedValue != null))
            {
                if (cmbtipoplanilla.SelectedValue.ToString().Trim().Length > 0)
                {
                    xvarrr = cmbtipoplanilla.SelectedValue.ToString();
                }
            }
            if (xvarrr.Trim().Length == 0)
            {
                xmsg = "Ingrese Tipo de Planilla";
                objeto = cmbtipoplanilla;
            }
            if (txtsemana.Enabled & VariablesPublicas.StringtoDecimal(txtsemana.Text) == 0)
            {
                xmsg = xmsg + "\r" + "Ingrese Nº Semana";
                objeto = txtsemana;
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

        private void Frm_NumeracionPlanilla_KeyDown(object sender, KeyEventArgs e)
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
                oform._ClaveForm = VariablesPublicas.EmpresaID + Examinar.Rows[Examinar.CurrentRow.Index].Cells["perianio"].Value + Examinar.Rows[Examinar.CurrentRow.Index].Cells["asiento"].Value;
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
                if (btnfiltro.Focused)
                {
                }
                else
                {
                    SendKeys.Send("\t");
                    return true;
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
                        txtdescripcion.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["glosa"].Value.ToString();
                        txtcodigo.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["asiento"].Value.ToString();
                        cmbmodalidad.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["planit"].Value.ToString();
                        cmbtipoquincena.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipoquincena"].Value.ToString();
                        cmbtipoplanilla.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipoplla"].Value;
                        txtsemana.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["nsemana"].Value.ToString();
                        vm_formapago = Examinar.Rows[Examinar.CurrentRow.Index].Cells["formapago"].Value.ToString();
                        cmbmes.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["perimes"].Value;
                        if ((!object.ReferenceEquals(Examinar.Rows[Examinar.CurrentRow.Index].Cells["fechaini"].Value, DBNull.Value)))
                        {
                            frangolabini.Value = Convert.ToDateTime(Examinar.Rows[Examinar.CurrentRow.Index].Cells["fechaini"].Value);
                            frangolabfin.Value = Convert.ToDateTime(Examinar.Rows[Examinar.CurrentRow.Index].Cells["fechafin"].Value);
                        }
                        else
                        {
                            frangolabini.Checked = false;
                            frangolabfin.Checked = false;
                        }

                        if ((!object.ReferenceEquals(Examinar.Rows[Examinar.CurrentRow.Index].Cells["fechpini"].Value, DBNull.Value)))
                        {
                            frangotrabini.Value = Convert.ToDateTime(Examinar.Rows[Examinar.CurrentRow.Index].Cells["fechpini"].Value);
                            frangotrabfin.Value = Convert.ToDateTime(Examinar.Rows[Examinar.CurrentRow.Index].Cells["fechpfin"].Value);
                        }
                        else
                        {
                            frangotrabini.Checked = false;
                            frangotrabfin.Checked = false;
                        }
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
            VariablesPublicas.RoleoGrid(Examinar, xtipo, "asiento");
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

        private void cmbfiltrotipoplanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad)
            {
                CargaDatos();
            }
        }

        public void RequeryTipoPlanilla()
        {
        }

        private void cmbtipoplanilla_GotFocus(object sender, System.EventArgs e)
        {
            if (!Sw_LOad)
            {
            }
        }

        private void cmbtipoplanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0)
            {
                var BL = new tb_plla_tipoplanillaBL();
                var BE = new tb_plla_tipoplanilla();
                BE.Tipoplla = cmbtipoplanilla.SelectedValue.ToString();
                BE.norden = 1;
                BE.ver_blanco = 0;
                BE.solopdt = 0;
                tmptabla = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (BL.Sql_Error.Length == 0)
                {
                    if (tmptabla.Rows.Count > 0)
                    {
                        vm_formapago = tmptabla.Rows[0]["formapago"].ToString();
                        if (vm_formapago == "3")
                        {
                            frangotrabini.Checked = false;
                            frangotrabfin.Checked = false;
                        }
                        txtsemana.Text = string.Empty;
                        cmbtipoquincena.SelectedValue = string.Empty;
                        U_RefrescaControles();
                    }
                }
            }
        }

        private void Examinar_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((Examinar.CurrentRow != null))
            {
                TabControl1.SelectedIndex = 1;
            }
        }
    }
}
