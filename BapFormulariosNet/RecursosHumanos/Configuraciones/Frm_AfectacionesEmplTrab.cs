using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using BapFormulariosNet.Ayudas;
using BapFormulariosNet.Codigo;

namespace BapFormulariosNet.RecursosHumanos.Configuraciones
{
    public partial class Frm_AfectacionesEmplTrab : plantilla
    {
        private DataTable Tabla;
        private bool Sw_LOad = true;
        private int u_n_opsel = 0;
        private DataTable tmpcursor = new DataTable();
        private int lc_cont;

        public Frm_AfectacionesEmplTrab()
        {
            InitializeComponent();

            KeyDown += Frm_AfectacionesEmplTrab_KeyDown;
            FormClosing += Frm_AfectacionesEmplTrab_FormClosing;
            Load += Frm_AfectacionesEmplTrab_Load;
            Activated += Frm_AfectacionesEmplTrab_Activated;
        }

        private void Frm_AfectacionesEmplTrab_Activated(object sender, EventArgs e)
        {
            if (Sw_LOad)
            {
                spnperiodo.Value = Convert.ToInt16(VariablesPublicas.perianio);
                u_CargaCombos();
                CargaDatos();
                cboMes.SelectedValue = VariablesPublicas.PADL(DateTime.Now.Month.ToString(), 2, "0");
                Sw_LOad = false;
                if (Examinar.RowCount > 0)
                {
                    Examinar.Focus();
                    Examinar.BeginEdit(true);
                }
                U_RefrescaControles();
                Sw_LOad = false;
            }
        }
        private void Frm_AfectacionesEmplTrab_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            WindowState = FormWindowState.Normal;
            Examinar.Columns["onpt"].HeaderText = "Trabajador" + '\r' + "ONP";
            Examinar.Columns["essalude"].HeaderText = "Empleador" + '\r' + "ESSALUD";
            Examinar.Columns["senatie"].HeaderText = "Empleador" + '\r' + "SENATI";
            Examinar.Columns["sctre"].HeaderText = "Empleador" + '\r' + "SCTR";
            for (lc_cont = 0; lc_cont <= Examinar.Columns.Count - 1; lc_cont++)
            {
                Examinar.Columns[lc_cont].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            FormBorderStyle = FormBorderStyle.Fixed3D;
        }
        private void Frm_AfectacionesEmplTrab_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (btnmod.Enabled)
                {
                    Accion(2);
                }
            }
            if (e.Control & e.KeyCode == Keys.G)
            {
                if (btngrabar.Enabled)
                {
                    save();
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (btncancelar.Enabled)
                {
                    U_CancelarEdicion(1);
                }
                else
                {
                    Close();
                }
            }
            if (e.KeyCode == Keys.F4)
            {
                if (Examinar.Enabled)
                {
                    Examinar.Focus();
                }
            }
            if (e.KeyCode == Keys.F5)
            {
                if (btnload.Enabled)
                {
                    U_CancelarEdicion(0);
                }
            }
        }

        private void CargaDatos()
        {
            var xcodmes = "99";
            var xtipoplanilla = ".";
            var sorted = default(SortOrder);
            var xnomcolumna = string.Empty;
            if (cboMes.SelectedValue != null)
            {
                xcodmes = cboMes.SelectedValue.ToString();
            }
            if (cboTipoplanilla.SelectedValue != null)
            {
                xtipoplanilla = cboTipoplanilla.SelectedValue.ToString();
            }
            if (Examinar.SortedColumn != null)
            {
                xnomcolumna = Examinar.Columns[Examinar.SortedColumn.Index].Name;
                sorted = Examinar.SortOrder;
            }
            var BL = new tb_plla_rubrosafectosleyestrabemplBL();
            var BE = new tb_plla_rubrosafectosleyestrabempl();
            BE.perianio = spnperiodo.Value.ToString();
            BE.perimes = xcodmes;
            BE.tipoplla = xtipoplanilla;
            Tabla = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
            Examinar.AutoGenerateColumns = false;
            Examinar.DataSource = Tabla;
        }

        private void U_RefrescaControles()
        {
            btngrabar.Enabled = u_n_opsel > 0;
            btnmod.Enabled = u_n_opsel == 0;
            btncancelar.Enabled = u_n_opsel > 0;
            btncerrar.Enabled = u_n_opsel == 0;
            btnload.Enabled = u_n_opsel == 0;
            spnperiodo.Enabled = u_n_opsel == 0;
            spnperiodo.ReadOnly = false;
            cboTipoplanilla.Enabled = u_n_opsel == 0;
            cboMes.Enabled = u_n_opsel == 0;
            Examinar.Enabled = true;
            Examinar.ReadOnly = u_n_opsel == 0;
            Examinar.Columns["rubroname"].ReadOnly = true;
            var zeof = true;
            if (Examinar.DataSource != null)
            {
                if (Examinar.RowCount > 0)
                {
                    zeof = false;
                }
            }
            btnNuevaFila.Enabled = u_n_opsel > 0;
            btnEliminarFila.Enabled = !zeof & u_n_opsel > 0;
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            U_CancelarEdicion(1);
        }
        private void U_CancelarEdicion(int SwConfirmacion)
        {
            var xtmpuser = string.Empty;
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
                if (tmpcursor != null)
                {
                    try
                    {
                        var filaactual = 0;
                        filaactual = Examinar.CurrentRow.Index;
                        xtmpuser = Examinar.Rows[filaactual].Cells["rubroid"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        xtmpuser = "..11";
                    }
                }
                u_n_opsel = 0;
                U_RefrescaControles();
                CargaDatos();
                if (Examinar.RowCount > 0)
                {
                    for (lc_cont = 0; lc_cont <= Examinar.Rows.Count - 1; lc_cont++)
                    {
                        if (Examinar.Rows[lc_cont].Cells["rubroid"].Value.ToString() == xtmpuser)
                        {
                            Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["rubroname"];
                            break;
                        }
                    }
                }
            }
            Examinar.Focus();
            if (Examinar.CurrentCell != null)
            {
                Examinar.BeginEdit(true);
            }
        }

        private void btngrabar_Click(object sender, EventArgs e)
        {
            save();
        }

        private void Frm_AfectacionesEmplTrab_FormClosing(object sender, FormClosingEventArgs e)
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

        private bool u_Validate()
        {
            var xmsg = string.Empty;
            var xobjeto = new object();
            if (!(xmsg.Trim().Length == 0))
            {
                MessageBox.Show(xmsg, "VALIDACION");
                if (xobjeto != null)
                {
                    xobjeto = Focus();
                }
            }
            return xmsg.Trim().Length == 0;
        }

        private void Examinar_SelectionChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad & u_n_opsel == 0)
            {
                U_RefrescaControles();
            }
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            U_CancelarEdicion(0);
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Accion(int naccion)
        {
            switch (naccion)
            {
                case 1:
                    u_n_opsel = 1;
                    U_RefrescaControles();
                    if (Examinar.CurrentRow != null)
                    {
                        Examinar.CurrentRow.Selected = false;
                    }
                    break;
                case 2:
                    u_n_opsel = 2;
                    U_RefrescaControles();
                    if (Examinar.CurrentRow != null)
                    {
                        Examinar.CurrentRow.Selected = true;
                    }
                    break;
                case 3:
                    break;
            }
        }
        private void save()
        {
            if (u_Validate())
            {
                if (Examinar.IsCurrentCellInEditMode)
                {
                    Examinar.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                Tabla.AcceptChanges();
                for (lc_cont = 0; lc_cont <= Tabla.Rows.Count - 1; lc_cont++)
                {
                    Tabla.Rows[lc_cont]["perianio"] = spnperiodo.Value.ToString();
                    Tabla.Rows[lc_cont]["perimes"] = cboMes.SelectedValue;
                    Tabla.Rows[lc_cont]["tipoplla"] = cboTipoplanilla.SelectedValue;
                }
                Tabla.AcceptChanges();

                var BL = new tb_plla_rubrosafectosleyestrabemplBL();
                var BE = new tb_plla_rubrosafectosleyestrabempl();

                BE.perianio = spnperiodo.Value.ToString();
                BE.perimes = cboMes.SelectedValue.ToString();
                BE.tipoplla = cboTipoplanilla.SelectedValue.ToString();
                if (BL.Insert_Update(VariablesPublicas.EmpresaID, BE, Tabla))
                {
                    U_CancelarEdicion(0);
                }
                else
                {
                    Frm_Class.ShowError(BL.Sql_Error, this);
                }
            }
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnmod_Click(object sender, EventArgs e)
        {
            if (!VariablesPublicas.u_Cerrado(VariablesPublicas.EmpresaID, VariablesPublicas.perianio, cboMes.SelectedValue.ToString(), "01", cboTipoplanilla.SelectedValue.ToString(), string.Empty))
            {
                Accion(2);
            }
        }

        private void spnperiodo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("\t");
                U_CancelarEdicion(0);
            }
        }
        private void spnperiodo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
            }
        }
        private void spnperiodo_ValueChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad)
            {
                U_CancelarEdicion(0);
            }
        }

        private void btnNuevaFila_Click(object sender, EventArgs e)
        {
            var f = new Frm_AyudaConfiguracionPlla();
            f.Owner = this;
            f.Formulario = this;
            f.TipoPlanilla = cboTipoplanilla.SelectedValue.ToString();
            f.PasaRubro2 = Rubros;
            f._DescartaRubros = string.Empty;
            for (lc_cont = 0; lc_cont <= Tabla.Rows.Count - 1; lc_cont++)
            {
                if (!object.ReferenceEquals(Tabla.Rows[lc_cont]["rubroid"], DBNull.Value))
                {
                    if (Tabla.Rows[lc_cont]["rubroid"].ToString().Trim().Length > 0)
                    {
                        f._DescartaRubros = f._DescartaRubros + Tabla.Rows[lc_cont]["rubroid"] + "_";
                    }
                }
            }
            f.ShowDialog();
        }
        public void Rubros(string _codigo, string _nombre, int nestado)
        {
            if (_codigo.Trim().Length > 0)
            {
                Tabla.Rows.Add(VariablesPublicas.InsertIntoTable(Tabla));
                Tabla.AcceptChanges();

                Tabla.Rows[Tabla.Rows.Count - 1]["rubroid"] = _codigo.Trim();
                Tabla.Rows[Tabla.Rows.Count - 1]["rubroname"] = _nombre.Trim();
                Examinar.Refresh();
                U_RefrescaControles();
            }
        }
        public void u_CargaCombos()
        {
            object xvalor = null;
            xvalor = null;
            Sw_LOad = true;
            if (cboTipoplanilla.SelectedValue != null)
            {
                xvalor = cboTipoplanilla.SelectedValue;
            }
            Llenar_cboTipoPlanilla();
            if (xvalor != null)
            {
                cboTipoplanilla.SelectedValue = xvalor;
            }

            xvalor = null;
            if (cboMes.SelectedValue != null)
            {
                xvalor = cboMes.SelectedValue;
            }
            llenar_cboMeses();
            if (xvalor != null)
            {
                cboMes.SelectedValue = xvalor;
            }
            Sw_LOad = false;
        }

        private void llenar_cboMeses()
        {
            try
            {
                cboMes.DataSource = NewMethodMeses();
                cboMes.DisplayMember = "Value";
                cboMes.ValueMember = "Key";
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

        private void Llenar_cboTipoPlanilla()
        {
            try
            {
                cboTipoplanilla.DataSource = NewMethoTP();
                cboTipoplanilla.DisplayMember = "Value";
                cboTipoplanilla.ValueMember = "Key";
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

            BE.norden = 2;
            BE.ver_blanco = 0;
            BE.solopdt = 1;
            var table = BL.GetAll_Consulta(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
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

        private void btnEliminarFila_Click(object sender, EventArgs e)
        {
            if (Examinar.CurrentRow != null)
            {
                Examinar.Rows.Remove(Examinar.CurrentRow);
                Tabla.AcceptChanges();
                U_RefrescaControles();
            }
        }

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad)
            {
                U_CancelarEdicion(0);
            }
        }

        private void cboTipoplanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad)
            {
                U_CancelarEdicion(0);
            }
        }
    }
}
