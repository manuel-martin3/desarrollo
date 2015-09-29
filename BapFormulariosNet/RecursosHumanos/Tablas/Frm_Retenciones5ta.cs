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

namespace BapFormulariosNet.RecursosHumanos.Tablas
{
    public partial class Frm_Retenciones5ta : plantilla
    {
        private DataTable Tabla;
        private bool Sw_LOad = true;
        private int u_n_opsel = 0;
        private DataTable tmpcursor = new DataTable();
        private int lc_cont = 0;

        public Frm_Retenciones5ta()
        {
            InitializeComponent();

            KeyDown += Frm_Retenciones5ta_KeyDown;
            FormClosing += Frm_Retenciones5ta_FormClosing;
            Load += Frm_Retenciones5ta_Load;
            Activated += Frm_Retenciones5ta_Activated;
        }

        private void llenar_cboMeses()
        {
            try
            {
                cbMes.DataSource = NewMethodMeses();
                cbMes.DisplayMember = "Value";
                cbMes.ValueMember = "Key";
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

        private void Frm_Retenciones5ta_Activated(object sender, EventArgs e)
        {
            if (Sw_LOad)
            {
                llenar_cboMeses();
                cbMes.SelectedValue = "01";
                spnperiodo.Value = Convert.ToInt16(VariablesPublicas.perianio);
                CargaDatos();
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
        private void Frm_Retenciones5ta_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            WindowState = FormWindowState.Normal;
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
            var BL = new tb_plla_retencionquintaBL();
            var BE = new tb_plla_retencionquinta();
            BE.perianio = spnperiodo.Value.ToString();
            Tabla = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
            Examinar.AutoGenerateColumns = false;
            Examinar.DataSource = Tabla;

            VariablesPublicas.PintaEncabezados(Examinar);

            Examinar.Sort(Examinar.Columns["nombrelargo"], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void U_RefrescaControles()
        {
            cbMes.Enabled = u_n_opsel > 0;
            btnCalcular.Enabled = u_n_opsel > 0;
            var vmxficha = string.Empty;
            if ((Examinar.CurrentRow != null))
            {
                vmxficha = Examinar.Rows[Examinar.CurrentRow.Index].Cells["fichaid"].Value.ToString();
            }
            btngrabar.Enabled = u_n_opsel > 0;
            btnmod.Enabled = u_n_opsel == 0;
            btncancelar.Enabled = u_n_opsel > 0;
            btncerrar.Enabled = u_n_opsel == 0;
            btnload.Enabled = u_n_opsel == 0;
            spnperiodo.Enabled = u_n_opsel == 0;
            spnperiodo.ReadOnly = false;
            Examinar.Enabled = true;
            Examinar.ReadOnly = u_n_opsel == 0;
            Examinar.Columns["fichaid"].ReadOnly = true;
            Examinar.Columns["nombrelargo"].ReadOnly = true;
            btnNuevaFila.Enabled = u_n_opsel > 0;
            btnEliminarFila.Enabled = u_n_opsel > 0 & vmxficha.Trim().Length > 0;
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
                sw_prosigue = MessageBox.Show("Desea cancelar ingreso de datos...?", "Mensaje del Sistema", MessageBoxButtons.YesNo) == DialogResult.Yes;
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
                        xtmpuser = Examinar.Rows[filaactual].Cells["fichaid"].Value.ToString();
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
                        if (Examinar.Rows[lc_cont].Cells["fichaid"].Value.ToString() == xtmpuser)
                        {
                            Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["nombrelargo"];
                            break;
                        }
                    }
                }
            }
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

        private void Frm_Retenciones5ta_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Frm_Retenciones5ta_KeyDown(object sender, KeyEventArgs e)
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

        private void Accion(int naccion)
        {
            switch (naccion)
            {
                case 1:
                    u_n_opsel = 1;
                    U_RefrescaControles();
                    if ((Examinar.CurrentRow != null))
                    {
                        Examinar.CurrentRow.Selected = false;
                    }
                    break;
                case 2:
                    u_n_opsel = 2;
                    U_RefrescaControles();
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
                }
                Tabla.AcceptChanges();

                var BL = new tb_plla_retencionquintaBL();
                var BE = new tb_plla_retencionquinta();
                BE.perianio = spnperiodo.Value.ToString();
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
            Accion(2);
        }

        private void spnperiodo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("\t");
                U_CancelarEdicion(0);
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
            var oform = new Frm_PllaAyutaTrabajadores();
            oform.PasaProveedor = RecibetrabajadorIni;
            oform.Owner = this;
            oform.ShowDialog();
        }
        public void RecibetrabajadorIni(string codigo, bool zselect)
        {
            if (zselect)
            {
                var BL = new tb_plla_fichatrabajadoresBL();
                var BE = new tb_plla_fichatrabajadores();
                BE.Fichaid = codigo;
                BE.Norden = 2;
                BE.Estado_trabaj = 0;
                tmpcursor = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (BL.Sql_Error.Length == 0)
                {
                    if (tmpcursor.Rows.Count > 0)
                    {
                        Tabla.Rows.Add(VariablesPublicas.INSERTINTOTABLE(Tabla));
                        Tabla.Rows[Tabla.Rows.Count - 1]["fichaid"] = tmpcursor.Rows[0]["fichaid"];
                        Tabla.Rows[Tabla.Rows.Count - 1]["nombrelargo"] = tmpcursor.Rows[0]["nombrelargo"].ToString().Trim();
                        Tabla.AcceptChanges();
                        U_RefrescaControles();
                        Examinar.Focus();
                        for (lc_cont = 0; lc_cont <= Examinar.Rows.Count - 1; lc_cont++)
                        {
                            if (Examinar.Rows[lc_cont].Cells["fichaid"].Value.ToString() == tmpcursor.Rows[0]["fichaid"].ToString())
                            {
                                Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["nombrelargo"];
                                Examinar.BeginEdit(true);
                                Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["salxretener"];
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void btnEliminarFila_Click(object sender, EventArgs e)
        {
            if ((Examinar.CurrentRow != null))
            {
                for (lc_cont = 0; lc_cont <= Tabla.Rows.Count - 1; lc_cont++)
                {
                    if (Tabla.Rows[lc_cont]["fichaid"] == Examinar.Rows[Examinar.CurrentRow.Index].Cells["fichaid"].Value)
                    {
                        Tabla.Rows[lc_cont].Delete();
                    }
                }
                Tabla.AcceptChanges();
                U_RefrescaControles();
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            var xvmmes = string.Empty;
            if ((cbMes.SelectedValue != null))
            {
                xvmmes = cbMes.SelectedValue.ToString();
            }
            if (xvmmes.Trim().Length == 0)
            {
                MessageBox.Show("Seleccione mes", "Mensaje del Sistema");
                return;
            }

            if (MessageBox.Show("Desea recalcular Renta Quinta" + "\r" + "La información existente será eliminada...?", string.Empty, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var BL = new tb_plla_retencionquintaBL();
                var BE = new tb_plla_retencionquinta();
                BE.perianio = spnperiodo.Value.ToString();
                BE.perimes = xvmmes;
                BE.ntipo = 1;
                tmpcursor = BL.CalcularRta5ta(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (BL.Sql_Error.Length > 0)
                {
                    Frm_Class.ShowError(BL.Sql_Error, this);
                    return;
                }
                else
                {
                    if (tmpcursor.Rows.Count > 0)
                    {
                        Tabla.AcceptChanges();
                        for (lc_cont = 0; lc_cont <= Tabla.Rows.Count - 1; lc_cont++)
                        {
                            Tabla.Rows[lc_cont].Delete();
                        }
                        for (lc_cont = 0; lc_cont <= tmpcursor.Rows.Count - 1; lc_cont++)
                        {
                            Tabla.ImportRow(tmpcursor.Rows[lc_cont]);
                        }
                        Tabla.AcceptChanges();
                    }
                }
            }
        }
    }
}
