using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using BapFormulariosNet.Codigo;

namespace BapFormulariosNet.RecursosHumanos.Configuraciones
{
    public partial class Frm_PorcentajeLeyTrabajador : plantilla
    {
        private DataTable Tabla;
        private bool Sw_LOad = true;
        private int u_n_opsel = 0;
        private DataTable tmpcursor = new DataTable();
        private int lc_cont;

        public Frm_PorcentajeLeyTrabajador()
        {
            InitializeComponent();
        }

        private void Frm_PorcentajeLeyTrabajador_Activated(object sender, EventArgs e)
        {
            if (Sw_LOad)
            {
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
        private void Frm_PorcentajeLeyTrabajador_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            WindowState = FormWindowState.Normal;
            FormBorderStyle = FormBorderStyle.Fixed3D;
        }
        private void Frm_PorcentajeLeyTrabajador_KeyDown(object sender, KeyEventArgs e)
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

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CargaDatos()
        {
            var sorted = default(SortOrder);
            var xnomcolumna = string.Empty;
            if (Examinar.SortedColumn != null)
            {
                xnomcolumna = Examinar.Columns[Examinar.SortedColumn.Index].Name;
                sorted = Examinar.SortOrder;
            }
            var BL = new tb_plla_porcentleyesBL();
            var BE = new tb_plla_porcentleyes();

            BE.perianio = spnperiodo.Value.ToString();
            Tabla = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
            Examinar.AutoGenerateColumns = false;
            Examinar.DataSource = Tabla;
            Examinar.Sort(Examinar.Columns["perimes"], System.ComponentModel.ListSortDirection.Ascending);
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
            Examinar.Enabled = true;
            Examinar.ReadOnly = u_n_opsel == 0;
            Examinar.Columns["mesname"].ReadOnly = true;
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
                        xtmpuser = Examinar.Rows[filaactual].Cells["perimes"].Value.ToString();
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
                        if (Examinar.Rows[lc_cont].Cells["perimes"].Value.ToString() == xtmpuser)
                        {
                            Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["mesname"];
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

        private void Frm_PorcentajeLeyTrabajador_FormClosing(object sender, FormClosingEventArgs e)
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
                    Examinar.CurrentRow.Selected = true;
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

                var BL = new tb_plla_porcentleyesBL();
                var BE = new tb_plla_porcentleyes();

                BE.perianio = spnperiodo.Value.ToString();
                if (BL.BapSoft_PorcentajesLeyesInsert(VariablesPublicas.EmpresaID, BE, Tabla))
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
    }
}
