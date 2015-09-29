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
    public partial class Frm_Planilla_RubrosIngreso : plantilla
    {
        private DataTable tablaclientes;
        private DataTable tmpcursor;
        private string j_xFiltronom = string.Empty;
        private bool sw_EmpiezaEdicion = false;
        private DataTable tmptabla;
        private bool Sw_LOad = true;
        private int u_n_opsel = 0;
        private int lc_cont;
        private int cdClave = 0;

        public Frm_Planilla_RubrosIngreso()
        {
            InitializeComponent();

            KeyDown += Frm_Planilla_RubrosIngreso_KeyDown;
            FormClosing += Frm_Planilla_RubrosIngreso_FormClosing;
            Load += Frm_Planilla_RubrosIngreso_Load;
            Activated += Frm_Planilla_RubrosIngreso_Activated;

            txtfiltronombre.LostFocus += new System.EventHandler(txtfiltronombre_LostFocus);
            txtfiltronombre.GotFocus += new System.EventHandler(txtfiltronombre_GotFocus);

            txtcodigo.LostFocus += new System.EventHandler(txtcodigo_LostFocus);

            cmbtipoplanilla.GotFocus += new System.EventHandler(cmbtipoplanilla_GotFocus);
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

            BE.ver_blanco = 1;
            BE.solopdt = 0;
            var table = BL.GetAll_Consulta(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            var rows = table.Rows;

            object[] cell;
            var dic = new Dictionary<string, string>();
            var binding = new BindingSource();

            foreach (DataRow item in rows)
            {
                cell = item.ItemArray;
                dic.Add(cell[0].ToString(), cell[0].ToString() + "    " + cell[1].ToString());
                cell = null;
            }
            binding.DataSource = dic;
            return binding;
        }

        private void RequeryTipoPlanilla()
        {
        }

        private void Llenar_cboModalidad()
        {
            try
            {
                cmbmodalidad.DataSource = NewMethoMod();
                cmbmodalidad.DisplayMember = "Value";
                cmbmodalidad.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethoMod()
        {
            var BL = new tb_plla_tab0100BL();
            var BE = new tb_plla_tab0100();

            BE.ver_blanco = 1;
            var table = BL.gspTbPllaModalidadRubros(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            var rows = table.Rows;

            object[] cell;
            var dic = new Dictionary<string, string>();
            var binding = new BindingSource();

            foreach (DataRow item in rows)
            {
                cell = item.ItemArray;
                dic.Add(cell[0].ToString(), cell[0].ToString() + "    " + cell[1].ToString());
                cell = null;
            }
            binding.DataSource = dic;
            return binding;
        }

        private void Llenar_cboTipoCalculo()
        {
            try
            {
                cmbtipocalculo.DataSource = NewMethoTC();
                cmbtipocalculo.DisplayMember = "Value";
                cmbtipocalculo.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethoTC()
        {
            var BL = new tb_plla_tab0100BL();
            var BE = new tb_plla_tab0100();

            BE.ver_blanco = 1;
            var table = BL.gspTbPllaTipoCalculoRubros(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            var rows = table.Rows;

            object[] cell;
            var dic = new Dictionary<string, string>();
            var binding = new BindingSource();

            foreach (DataRow item in rows)
            {
                cell = item.ItemArray;
                dic.Add(cell[0].ToString(), cell[0].ToString() + "    " + cell[1].ToString());
                cell = null;
            }
            binding.DataSource = dic;
            return binding;
        }

        private void Llenar_cboTipo()
        {
            try
            {
                cmbtipo.DataSource = NewMethoT();
                cmbtipo.DisplayMember = "Value";
                cmbtipo.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethoT()
        {
            var BL = new tb_plla_tab0100BL();
            var BE = new tb_plla_tab0100();

            BE.ver_blanco = 1;
            var table = BL.gspTbPllaTipoEnRubros(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            var rows = table.Rows;

            object[] cell;
            var dic = new Dictionary<string, string>();
            var binding = new BindingSource();

            foreach (DataRow item in rows)
            {
                cell = item.ItemArray;
                dic.Add(cell[0].ToString(), cell[0].ToString() + "    " + cell[1].ToString());
                cell = null;
            }
            binding.DataSource = dic;
            return binding;
        }

        private void Llenar_cboRubroRtps()
        {
            try
            {
                cmbrubrorpts.DataSource = NewMethoRRtps();
                cmbrubrorpts.DisplayMember = "Value";
                cmbrubrorpts.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethoRRtps()
        {
            var BL = new tb_plla_pdt_tabla22BL();
            var BE = new tb_plla_pdt_tabla22();

            var table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            var rows = table.Rows;

            object[] cell;
            var dic = new Dictionary<string, string>();
            var binding = new BindingSource();

            foreach (DataRow item in rows)
            {
                cell = item.ItemArray;
                dic.Add(cell[0].ToString(), cell[0].ToString() + "   " + cell[1].ToString());
                cell = null;
            }
            binding.DataSource = dic;
            return binding;
        }

        private void Frm_Planilla_RubrosIngreso_Activated(object sender, EventArgs e)
        {
            if (Sw_LOad)
            {
                cboTipoplanilla.ValueMember = "tipoplla";
                cboTipoplanilla.DisplayMember = "tipopllaname";
                var BL = new tb_plla_tipoplanillaBL();
                var BE = new tb_plla_tipoplanilla();
                BE.norden = 1;
                BE.ver_blanco = 0;
                tmpcursor = BL.GetAll_Consulta(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                cboTipoplanilla.SelectedValue = string.Empty;

                if (BL.Sql_Error.Length == 0)
                {
                    cboTipoplanilla.DataSource = tmpcursor;
                    if (tmpcursor.Rows.Count > 0)
                    {
                        cboTipoplanilla.SelectedValue = tmpcursor.Rows[0]["tipoplla"].ToString();
                    }
                }

                cmbmodalidad.ValueMember = "cele";
                cmbmodalidad.DisplayMember = "descripcion";
                var BL1 = new tb_plla_tab0100BL();
                var BE1 = new tb_plla_tab0100();
                BE1.ver_blanco = 1;
                cmbmodalidad.DataSource = BL1.gspTbPllaModalidadRubros(VariablesPublicas.EmpresaID.ToString(), BE1).Tables[0];

                cmbtipocalculo.ValueMember = "cele";
                cmbtipocalculo.DisplayMember = "descripcion";
                var BL2 = new tb_plla_tab0100BL();
                var BE2 = new tb_plla_tab0100();
                BE2.ver_blanco = 1;
                cmbtipocalculo.DataSource = BL2.gspTbPllaTipoCalculoRubros(VariablesPublicas.EmpresaID.ToString(), BE2).Tables[0];

                cmbtipo.ValueMember = "cele";
                cmbtipo.DisplayMember = "descripcion";
                var BL3 = new tb_plla_tab0100BL();
                var BE3 = new tb_plla_tab0100();
                BE3.ver_blanco = 1;
                cmbtipo.DataSource = BL3.gspTbPllaTipoEnRubros(VariablesPublicas.EmpresaID.ToString(), BE3).Tables[0];

                Llenar_cboTipoPlanilla();

                cmbrubrorpts.ValueMember = "rubroid";
                cmbrubrorpts.DisplayMember = "descripcion";
                var BL4 = new tb_plla_pdt_tabla22BL();
                var BE4 = new tb_plla_pdt_tabla22();
                BE4.relrubroidtipo = GlobalVars.GetInstance().RubrosIngresoRPTS;
                BE4.detallado = 1;
                BE4.norden = 1;
                BE4.incluir_blanco = 1;
                cmbrubrorpts.DataSource = BL4.GetAll_Consulta(VariablesPublicas.EmpresaID, BE4).Tables[0];

                U_RefrescaControles();
                CargaDatos();
                U_RefrescaControles();
                Sw_LOad = false;
            }
        }
        private void Frm_Planilla_RubrosIngreso_KeyDown(object sender, KeyEventArgs e)
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
        private void Frm_Planilla_RubrosIngreso_Load(object sender, EventArgs e)
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
            lbltotalregistros.Text = string.Empty;
            var xtipoplanilla = string.Empty;
            var nestado = 1;
            if (rbestado2.Checked)
            {
                nestado = 2;
            }
            if (rbestado3.Checked)
            {
                nestado = 3;
            }
            if (cboTipoplanilla.Enabled)
            {
                if (cboTipoplanilla.SelectedValue != null)
                {
                    xtipoplanilla = cboTipoplanilla.SelectedValue.ToString();
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
            if (Examinar.CurrentRow != null)
            {
                xcodcliente = Examinar.Rows[Examinar.CurrentRow.Index].Cells["rubroid"].Value.ToString();
            }
            if (Examinar.SortedColumn != null)
            {
                nposcolumnasortear = Examinar.SortedColumn.Index;
                PrvSotOrder = Examinar.SortOrder;
                zordenado = true;
            }
            var BL = new tb_plla_rubrosingresoBL();
            var BE = new tb_plla_rubrosingreso();

            BE.tipoplla = xtipoplanilla;
            BE.descriplike1 = xpalabra1;
            BE.descriplike2 = xpalabra2;
            BE.descriplike3 = xpalabra3;
            BE.norden = 0;
            BE.incluir_blanco = 0;
            BE.nestado = nestado;
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
                Examinar.Sort(Examinar.Columns["rubroid"], System.ComponentModel.ListSortDirection.Ascending);
            }
            if (Examinar.CurrentRow == null)
            {
                if (Examinar.RowCount > 0)
                {
                    Examinar.CurrentCell = Examinar.Rows[0].Cells["rubroid"];
                }
            }
            for (lc_cont = 0; lc_cont <= Examinar.Rows.Count - 1; lc_cont++)
            {
                if (Examinar.Rows[lc_cont].Cells["rubroid"].Value.ToString() == xcodcliente)
                {
                    Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["rubroid"];
                    break;
                }
            }

            if (Examinar.RowCount > 0)
            {
                lbltotalregistros.Text = Examinar.RowCount.ToString() + " Registro(s)";
            }
            else
            {
                lbltotalregistros.Text = "NINGUN REGISTRO";
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
            txtsigla.Enabled = false;
            btncopiar.Enabled = u_n_opsel == 0;
            txtdescripcion.Enabled = u_n_opsel > 0;
            chkeditable.Enabled = u_n_opsel > 0;
            chkvisible.Enabled = u_n_opsel > 0;
            chkactivo.Enabled = u_n_opsel > 0;
            txtmontofijo.Enabled = u_n_opsel > 0;
            txtredondeo.Enabled = u_n_opsel > 0;
            cmbtipoplanilla.Enabled = u_n_opsel == 1;
            cmbmodalidad.Enabled = u_n_opsel > 0;
            cmbtipo.Enabled = u_n_opsel > 0;
            cmbrubrorpts.Enabled = u_n_opsel > 0;
            cmbtipocalculo.Enabled = u_n_opsel > 0;

            btnload.Enabled = u_n_opsel == 0;
            btnprimero.Enabled = u_n_opsel == 0;
            btnultimo.Enabled = u_n_opsel == 0;
            btnsiguiente.Enabled = u_n_opsel == 0;
            btnanterior.Enabled = u_n_opsel == 0;
            cboTipoplanilla.Enabled = u_n_opsel == 0;
            var xcodcliente = string.Empty;
            if (Examinar.CurrentRow != null)
            {
                xcodcliente = Examinar.Rows[Examinar.CurrentCell.RowIndex].Cells["rubroid"].Value.ToString();
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
            var BL = new tb_plla_rubrosingresoBL();
            var BE = new tb_plla_rubrosingreso();
            BE.tipo = GlobalVars.GetInstance().TipoRubroPlanillaIngreso;
            BE.tipoplla = cboTipoplanilla.SelectedValue.ToString();
            txtcodigo.Text = BL.GetMAX_CODIGORUBROPLANILLA(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0].Rows[0]["maximo_codigo"].ToString();
            cmbtipoplanilla.SelectedValue = cboTipoplanilla.SelectedValue;
            txtsigla.Text = GlobalVars.GetInstance().TipoRubroPlanillaIngreso;
            chkactivo.Checked = true;
            txtdescripcion.Focus();
        }

        private void Blanquear()
        {
            txtcodigo.Text = string.Empty;
            txtdescripcion.Text = string.Empty;
            chkactivo.Checked = false;
            chkeditable.Checked = false;
            cmbmodalidad.SelectedValue = string.Empty;
            cmbtipo.SelectedValue = string.Empty;
            cmbrubrorpts.SelectedValue = string.Empty;
            cmbtipocalculo.SelectedValue = string.Empty;
            txtmontofijo.Text = string.Empty;
            txtredondeo.Text = string.Empty;
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
                        if (Examinar.Rows[lc_cont].Cells["rubroid"].Value.ToString() == xtmpuser)
                        {
                            Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["rubroid"];
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
                var BL = new tb_plla_rubrosingresoBL();
                var BE = new tb_plla_rubrosingreso();

                BE.rubroid = txtsigla.Text.ToString().Trim() + txtcodigo.Text.ToString().Trim();
                BE.tipoplla = cmbtipoplanilla.SelectedValue.ToString();
                BE.norden = 1;
                BE.incluir_blanco = 0;
                BE.nestado = 1;
                tmpcursor = BL.GetAll_CONSULTA1(VariablesPublicas.EmpresaID, BE).Tables[0];

                if (u_n_opsel == 1)
                {
                    var BL1 = new tb_plla_rubrosingresoBL();
                    var BE1 = new tb_plla_rubrosingreso();

                    BE1.rubroid = txtsigla.Text.ToString().Trim() + txtcodigo.Text.ToString().Trim();
                    BE1.tipoplla = cmbtipoplanilla.SelectedValue.ToString();
                    BE1.norden = 1;
                    BE1.incluir_blanco = 0;
                    BE1.nestado = 1;
                    tmpcursor = BL1.GetAll_CONSULTA1(VariablesPublicas.EmpresaID, BE1).Tables[0];

                    if (tmpcursor.Rows.Count > 0)
                    {
                        var BLm = new tb_plla_rubrosingresoBL();
                        var BEm = new tb_plla_rubrosingreso();
                        BEm.tipo = GlobalVars.GetInstance().TipoRubroPlanillaIngreso;
                        BEm.tipoplla = cboTipoplanilla.SelectedValue.ToString();
                        txtcodigo.Text = BLm.GetMAX_CODIGORUBROPLANILLA(VariablesPublicas.EmpresaID.ToString(), BEm).Tables[0].Rows[0]["maximo_codigo"].ToString();
                    }
                    tmpcursor.Rows.Add(VariablesPublicas.InsertIntoTable(tmpcursor));
                    tmpcursor.Rows[0]["rubroid"] = txtsigla.Text + txtcodigo.Text;
                    tmpcursor.Rows[0]["status"] = "0";
                }
                tmpcursor.Rows[0]["rubroname"] = txtdescripcion.Text;
                tmpcursor.Rows[0]["status"] = (chkactivo.Checked ? "0" : "9");
                tmpcursor.Rows[0]["tipoplla"] = cmbtipoplanilla.SelectedValue;
                tmpcursor.Rows[0]["edita"] = (chkeditable.Checked ? 1 : 0);
                tmpcursor.Rows[0]["visible"] = (chkvisible.Checked ? 1 : 0);
                tmpcursor.Rows[0]["modalidad"] = cmbmodalidad.SelectedValue;
                tmpcursor.Rows[0]["tipocalculo"] = cmbtipocalculo.SelectedValue;
                tmpcursor.Rows[0]["tiporubro"] = cmbtipo.SelectedValue;
                tmpcursor.Rows[0]["rubropdt"] = cmbrubrorpts.SelectedValue;
                tmpcursor.Rows[0]["montofijo"] = VariablesPublicas.StringtoDecimal(txtmontofijo.Text);
                tmpcursor.Rows[0]["redondeo"] = VariablesPublicas.StringtoDecimal(txtredondeo.Text);
                tmpcursor.AcceptChanges();

                var BLIU = new tb_plla_rubrosingresoBL();

                if (BLIU.Insert_Update(VariablesPublicas.EmpresaID, tmpcursor))
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
            var xclave = VariablesPublicas.EmpresaID + cmbtipoplanilla.SelectedValue + txtsigla.Text + txtcodigo.Text;
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
                BE.detalle = "Rubro: " + txtdescripcion.Text;

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
                var BL = new tb_plla_rubrosingresoBL();
                var BE = new tb_plla_rubrosingreso();

                BE.rubroid = Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipoplla"].Value.ToString() + Examinar.Rows[Examinar.CurrentRow.Index].Cells["rubroid"].Value.ToString();
                tmpcursor = BL.GetAll_IR(VariablesPublicas.EmpresaID, BE).Tables[0];
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
                    var BL1 = new tb_plla_rubrosingresoBL();
                    var BE1 = new tb_plla_rubrosingreso();

                    BE1.rubroid = Examinar.Rows[Examinar.CurrentRow.Index].Cells["rubroid"].Value.ToString();
                    BE1.tipoplla = Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipoplla"].Value.ToString();
                    BE1.norden = 1;
                    BE1.incluir_blanco = 0;
                    BE1.nestado = 1;
                    tmptabla = BL1.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE1).Tables[0];
                    if (BL1.Sql_Error.Length == 0)
                    {
                        var message = "Desea eliminar datos del rubro  " + tmptabla.Rows[0]["rubroid"].ToString().Trim() + "-" + tmptabla.Rows[0]["rubroname"].ToString().Trim() + " ...?";
                        var caption = "Mensaje del Sistema";
                        var buttons = MessageBoxButtons.YesNo;
                        DialogResult result;
                        result = MessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                            var BLE = new tb_plla_rubrosingresoBL();

                            BLE.Eliminar(VariablesPublicas.EmpresaID, tmptabla);
                            if (BLE.Sql_Error.Length == 0)
                            {
                                var BLL = new tb_co_seguridadlogBL();
                                var BEL = new tb_co_seguridadlog();

                                BEL.moduloid = Name;
                                BEL.clave = VariablesPublicas.EmpresaID + Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipoplla"].Value.ToString() + Examinar.Rows[Examinar.CurrentRow.Index].Cells["rubroid"].Value.ToString();
                                BEL.cuser = VariablesPublicas.Usuar;
                                BEL.fecha = DateTime.Now;
                                BEL.pc = VariablesPublicas.userip;
                                BEL.accion = "B";
                                BEL.detalle = "Rubro: " + txtdescripcion.Text;

                                BLL.Insert(VariablesPublicas.EmpresaID.ToString(), BEL);
                                Examinar.Rows.Remove(Examinar.CurrentRow);
                                Examinar.Refresh();
                                u_PintaDatos();
                            }
                            else
                            {
                                Frm_Class.ShowError(BLE.Sql_Error, this);
                            }
                        }
                    }
                    else
                    {
                        Frm_Class.ShowError(BL1.Sql_Error, this);
                    }
                }
                else
                {
                    MessageBox.Show(xnomcampo, "IMPOSIBLE ELIMINAR REGISTRO");
                }
            }
            U_RefrescaControles();
        }

        private void Frm_Planilla_RubrosIngreso_FormClosing(object sender, FormClosingEventArgs e)
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
            var xvarrr = string.Empty;
            if (cmbtipoplanilla.SelectedValue != null)
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
            if (xmsg.Trim().Length > 0)
            {
                MessageBox.Show(xmsg.Trim(), "Error en Ingreso de Datos");
                if (objeto != null)
                {
                    objeto = Focus();
                }
            }
            return xmsg.Trim().Length == 0;
        }

        private void btnlog_Click(object sender, EventArgs e)
        {
            if (Examinar.CurrentRow != null)
            {
                var oform = new FrmSeguridad();
                oform._Nombre = Name;
                oform._ClaveForm = VariablesPublicas.EmpresaID + Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipoplla"].Value + Examinar.Rows[Examinar.CurrentRow.Index].Cells["rubroid"].Value;
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
                        txtcodigo.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["codrubro"].Value.ToString();
                        txtsigla.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["siglarubro"].Value.ToString();
                        txtdescripcion.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["rubroname"].Value.ToString();
                        cmbtipoplanilla.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipoplla"].Value;
                        chkvisible.Checked = Convert.ToBoolean(Examinar.Rows[Examinar.CurrentRow.Index].Cells["visible"].Value);
                        chkeditable.Checked = Convert.ToBoolean(Examinar.Rows[Examinar.CurrentRow.Index].Cells["edita"].Value);
                        chkactivo.Checked = Convert.ToBoolean(Examinar.Rows[Examinar.CurrentRow.Index].Cells["status"].Value);
                        cmbmodalidad.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["modalidad"].Value;
                        cmbtipocalculo.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipocalculo"].Value;
                        cmbtipo.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["tiporubro"].Value;
                        cmbrubrorpts.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["rubropdt"].Value;

                        if (Convert.ToDecimal(Examinar.Rows[Examinar.CurrentRow.Index].Cells["montofijo"].Value) > 0)
                        {
                            txtmontofijo.Text = String.Format(Examinar.Rows[Examinar.CurrentRow.Index].Cells["montofijo"].Value.ToString(), "###,###.00");
                        }
                        else
                        {
                            txtmontofijo.Text = "0.00";
                        }
                        if (Convert.ToDecimal(Examinar.Rows[Examinar.CurrentRow.Index].Cells["redondeo"].Value) > 0)
                        {
                            txtredondeo.Text = String.Format(Examinar.Rows[Examinar.CurrentRow.Index].Cells["redondeo"].Value.ToString(), "##");
                        }
                        else
                        {
                            txtredondeo.Text = "0";
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
            VariablesPublicas.RoleoGrid(Examinar, xtipo, "rubroid");
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
                if (e.KeyChar == (Char)Keys.Back | e.KeyChar == (Char)Keys.Delete)
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

        private void cboTipoplanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad)
            {
                CargaDatos();
            }
        }
        private void cmbtipoplanilla_GotFocus(object sender, System.EventArgs e)
        {
            if (!Sw_LOad)
            {
            }
        }

        private void Examinar_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Examinar.CurrentRow != null)
            {
                TabControl1.SelectedIndex = 1;
            }
        }

        private void btncopiar_Click(object sender, EventArgs e)
        {
            var oform = new Frm_Planilla_RubrosCopiar();
            oform.ShowInTaskbar = false;
            oform._LpTipoRubro = "I";
            oform._LpPlanillaDestino = cboTipoplanilla.SelectedValue.ToString();
            oform.Owner = this;
            oform.ShowDialog();
        }

        private void rbestado1_CheckedChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad)
            {
                CargaDatos();
            }
        }

        private void rbestado2_CheckedChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad)
            {
                CargaDatos();
            }
        }

        private void rbestado3_CheckedChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad)
            {
                CargaDatos();
            }
        }
    }
}
