using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using BapFormulariosNet.Codigo;

namespace BapFormulariosNet.RecursosHumanos.Tablas
{
    public partial class Frm_UnidadImpositivaTributaria : plantilla
    {
        private DataTable Tabla;
        private bool Sw_LOad = true;
        private int u_n_opsel = 0;
        private DataTable tmpcursor = new DataTable();
        private string xnomcampo;
        private int lc_cont = 0;

        public Frm_UnidadImpositivaTributaria()
        {
            InitializeComponent();

            KeyDown += Frm_UnidadImpositivaTributaria_KeyDown;
            FormClosing += Frm_UnidadImpositivaTributaria_FormClosing;
            Load += Frm_UnidadImpositivaTributaria_Load;

            cmbmes.GotFocus += new System.EventHandler(cmbmes_GotFocus);
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
        private void Frm_UnidadImpositivaTributaria_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            WindowState = FormWindowState.Normal;
            llenar_cboMeses();
            u_LoadComboMes();
            CargaDatos();

            POnedatos();
            Sw_LOad = false;
            if (Examinar.RowCount > 0)
            {
                Examinar.Focus();
                Examinar.BeginEdit(true);
            }
            U_RefrescaControles();
        }

        public void u_LoadComboMes()
        {
        }

        private void cmbmes_GotFocus(object sender, System.EventArgs e)
        {
            if (u_n_opsel > 0)
            {
                u_LoadComboMes();
            }
        }

        private void CargaDatos()
        {
            var sorted = default(SortOrder);
            var xnomcolumna = string.Empty;
            if ((Examinar.SortedColumn != null))
            {
                xnomcolumna = Examinar.Columns[Examinar.SortedColumn.Index].Name;
                sorted = Examinar.SortOrder;
            }
            var BL = new tb_plla_valor_uitBL();
            var BE = new tb_plla_valor_uit();
            Tabla = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
            Examinar.AutoGenerateColumns = false;
            Examinar.DataSource = Tabla;
            if (xnomcolumna.Trim().Length > 0)
            {
                if (sorted == SortOrder.Ascending)
                {
                    Examinar.Sort(Examinar.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Ascending);
                }
                else
                {
                    Examinar.Sort(Examinar.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Descending);
                }
            }
            else
            {
                Examinar.Sort(Examinar.Columns["perianio"], System.ComponentModel.ListSortDirection.Descending);
            }
        }

        private void U_RefrescaControles()
        {
            var xcoduser = string.Empty;
            decimal npos = -1;
            if ((Examinar.CurrentRow != null))
            {
                xcoduser = Examinar.Rows[Examinar.CurrentCell.RowIndex].Cells["perianio"].Value.ToString();
                if (xcoduser.Trim().Length > 0)
                {
                    npos = VariablesPublicas.BuscarEnTable(xcoduser, "perianio", Tabla);
                }
            }
            txtvaloruit.Enabled = u_n_opsel > 0;
            txtsueldomin.Enabled = u_n_opsel > 0;
            cmbmes.Enabled = u_n_opsel > 0;
            cmbmes.Enabled = u_n_opsel > 0;
            txtcodigo.Enabled = u_n_opsel == 1;
            btnnuevo.Enabled = u_n_opsel == 0;
            btngrabar.Enabled = u_n_opsel > 0;
            btnmod.Enabled = u_n_opsel == 0 & npos > -1;
            btneliminar.Enabled = u_n_opsel == 0 & npos > -1;
            btncancelar.Enabled = u_n_opsel > 0;
            btncerrar.Enabled = u_n_opsel == 0;
            btnload.Enabled = u_n_opsel == 0;
            Examinar.Enabled = u_n_opsel == 0;
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
                if ((tmpcursor != null))
                {
                    try
                    {
                        var filaactual = 0;
                        filaactual = Examinar.CurrentRow.Index;
                        xtmpuser = Examinar.Rows[filaactual].Cells["perianio"].Value.ToString();
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
                        if (Examinar.Rows[lc_cont].Cells["perianio"].Value.ToString() == xtmpuser.ToString())
                        {
                            Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["perianio"];
                            break;
                        }
                    }
                }
            }
            POnedatos();
            Examinar.Focus();
            if ((Examinar.CurrentCell != null))
            {
                Examinar.BeginEdit(true);
            }
        }

        private void btngrabar_Click(object sender, EventArgs e)
        {
            save();
        }

        private void Frm_UnidadImpositivaTributaria_FormClosing(object sender, FormClosingEventArgs e)
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

        private bool u_Validate()
        {
            var xmsg = string.Empty;
            var xobjeto = new object();
            if (txtvaloruit.Enabled & txtvaloruit.Text.Trim().Length == 0)
            {
                xmsg = "Ingrese descripción";
                xobjeto = txtvaloruit;
            }
            else
            {
            }

            if (!(xmsg.Trim().Length == 0))
            {
                MessageBox.Show(xmsg, "VALIDACION");
                if ((xobjeto != null))
                {
                    xobjeto = Focus();
                }
            }
            return xmsg.Trim().Length == 0;
        }
        private void POnedatos()
        {
            Blanquear();
            if ((Examinar.CurrentRow != null))
            {
                txtcodigo.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["perianio"].Value.ToString();
                txtvaloruit.Text = String.Format(Examinar.Rows[Examinar.CurrentRow.Index].Cells["valoruit"].Value.ToString(), "###,###.00");
                cmbmes.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["perimes"].Value;
                txtsueldomin.Text = String.Format(Examinar.Rows[Examinar.CurrentRow.Index].Cells["sdomin"].Value.ToString(), "###,###.00");
            }
        }

        private void Examinar_SelectionChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad & u_n_opsel == 0)
            {
                POnedatos();
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

        private void btneliminar_Click(object sender, EventArgs e)
        {
            Accion(3);
        }

        private void Frm_UnidadImpositivaTributaria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (btnnuevo.Enabled)
                {
                    Accion(1);
                }
            }
            if (e.KeyCode == Keys.F3)
            {
                if (btnmod.Enabled)
                {
                    Accion(2);
                }
            }
            if (e.KeyCode == Keys.F8)
            {
                if (btneliminar.Enabled)
                {
                    Accion(3);
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

        private void Accion(int naccion)
        {
            switch (naccion)
            {
                case 1:
                    u_n_opsel = 1;
                    U_RefrescaControles();
                    Blanquear();
                    txtcodigo.Text = VariablesPublicas.perianio;
                    if ((Examinar.CurrentRow != null))
                    {
                        Examinar.CurrentRow.Selected = false;
                    }
                    break;
                case 2:
                    POnedatos();
                    u_n_opsel = 2;
                    U_RefrescaControles();
                    Examinar.CurrentRow.Selected = true;
                    break;
                case 3:
                    xnomcampo = "";
                    if ((Examinar.CurrentRow != null))
                    {
                        if (xnomcampo.Length == 0)
                        {
                            var message = "Desea Eliminar Registro ...?";
                            var caption = "Mensaje del Sistema";
                            var buttons = MessageBoxButtons.YesNo;
                            DialogResult result;
                            result = MessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.Yes)
                            {
                                var BL = new tb_plla_valor_uitBL();
                                var BE = new tb_plla_valor_uit();
                                BE.perianio = Examinar.Rows[Examinar.CurrentRow.Index].Cells["perianio"].Value.ToString().Trim();
                                tmpcursor = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                                if (BL.Sql_Error.Length == 0)
                                {
                                    if (BL.Eliminar(VariablesPublicas.EmpresaID, tmpcursor))
                                    {
                                        for (lc_cont = 0; lc_cont <= Tabla.Rows.Count - 1; lc_cont++)
                                        {
                                            if (Tabla.Rows[lc_cont]["perianio"].ToString() == Examinar.Rows[Examinar.CurrentRow.Index].Cells["perianio"].Value.ToString())
                                            {
                                                Tabla.Rows[lc_cont].Delete();
                                                Tabla.AcceptChanges();
                                                break;
                                            }
                                        }
                                        Examinar.Refresh();
                                    }
                                    else
                                    {
                                        Frm_Class.ShowError(BL.Sql_Error, this);
                                    }
                                }
                                else
                                {
                                    Frm_Class.ShowError(BL.Sql_Error, this);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(xnomcampo, "IMPOSIBLE ELIMINAR REGISTRO");
                        }
                    }
                    break;
            }
        }
        private void save()
        {
            if (u_Validate())
            {
                tmpcursor = null;
                var BL = new tb_plla_valor_uitBL();
                var BE = new tb_plla_valor_uit();
                BE.perianio = txtcodigo.Text.Trim();
                tmpcursor = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (BL.Sql_Error.Length > 0)
                {
                    Frm_Class.ShowError(BL.Sql_Error, this);
                    return;
                }
                if (tmpcursor.Rows.Count == 0)
                {
                    tmpcursor.Rows.Add(VariablesPublicas.INSERTINTOTABLE(tmpcursor));
                }
                tmpcursor.Rows[tmpcursor.Rows.Count - 1]["perianio"] = txtcodigo.Text.Trim();
                tmpcursor.Rows[tmpcursor.Rows.Count - 1]["perimes"] = cmbmes.SelectedValue;
                tmpcursor.Rows[tmpcursor.Rows.Count - 1]["valoruit"] = VariablesPublicas.StringtoDecimal(txtvaloruit.Text);
                tmpcursor.Rows[tmpcursor.Rows.Count - 1]["status"] = '0';
                tmpcursor.Rows[tmpcursor.Rows.Count - 1]["sdomin"] = VariablesPublicas.StringtoDecimal(txtsueldomin.Text);
                tmpcursor.AcceptChanges();
                if (BL.Insert_Update(VariablesPublicas.EmpresaID, BE, tmpcursor))
                {
                    U_CancelarEdicion(0);
                }
                else
                {
                    Frm_Class.ShowError(BL.Sql_Error, this);
                }
            }
        }
        public void Blanquear()
        {
            txtcodigo.Text = string.Empty;
            txtvaloruit.Text = string.Empty;
            cmbmes.SelectedValue = string.Empty;
            txtsueldomin.Text = string.Empty;
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if ((Examinar.CurrentRow != null))
                {
                    if (Examinar.Focused)
                    {
                        return true;
                    }
                    else
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
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            Accion(1);
        }

        private void btnmod_Click(object sender, EventArgs e)
        {
            Accion(2);
        }
    }
}
