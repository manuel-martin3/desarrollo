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
    public partial class Frm_Telecredito : plantilla
    {
        private DataTable Tabla;
        private DataTable tmpcursor;
        private bool Sw_LOad = true;
        private int u_n_opsel = 0;
        private string xnomcampo;
        private int lc_cont = 0;

        public Frm_Telecredito()
        {
            InitializeComponent();

            KeyDown += Frm_Telecredito_KeyDown;
            FormClosing += Frm_Telecredito_FormClosing;
            Load += Frm_Telecredito_Load;
        }

        private void Frm_Telecredito_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            WindowState = FormWindowState.Normal;
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

        private void CargaDatos()
        {
            var sorted = default(SortOrder);
            var xnomcolumna = string.Empty;
            if ((Examinar.SortedColumn != null))
            {
                xnomcolumna = Examinar.Columns[Examinar.SortedColumn.Index].Name;
                sorted = Examinar.SortOrder;
            }
            var BL = new tb_plla_tab0100BL();
            var BE = new tb_plla_tab0100();
            BE.norden = 0;
            Tabla = BL.TeleCredito_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
            if (BL.Sql_Error.Length == 0)
            {
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
                    Examinar.Sort(Examinar.Columns["codigo"], System.ComponentModel.ListSortDirection.Ascending);
                }
            }
            else
            {
                Sw_LOad = false;
                Frm_Class.ShowError(BL.Sql_Error, this);
            }
            VariablesPublicas.PintaEncabezados(Examinar);
        }

        private void U_RefrescaControles()
        {
            var xcoduser = string.Empty;
            decimal npos = -1;
            if ((Examinar.CurrentRow != null))
            {
                xcoduser = Examinar.Rows[Examinar.CurrentCell.RowIndex].Cells["codigo"].Value.ToString();
                if (xcoduser.Trim().Length > 0)
                {
                    npos = VariablesPublicas.BuscarEnTable(xcoduser, "codigo", Tabla);
                }
            }

            txtDescripcion.Enabled = u_n_opsel > 0;
            txtvalor.Enabled = u_n_opsel > 0;
            txtcodigo.Enabled = u_n_opsel == 1;
            btngrabar.Enabled = u_n_opsel > 0;
            btnmod.Enabled = u_n_opsel == 0 & npos > -1;
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
                        xtmpuser = Examinar.Rows[filaactual].Cells["codigo"].Value.ToString();
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
                        if (Examinar.Rows[lc_cont].Cells["codigo"].Value.ToString() == xtmpuser.ToString())
                        {
                            Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["codigo"];
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

        private void Frm_Telecredito_FormClosing(object sender, FormClosingEventArgs e)
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
            if (txtDescripcion.Enabled & txtDescripcion.Text.Trim().Length == 0)
            {
                xmsg = "Ingrese descripción";
                xobjeto = txtDescripcion;
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
                txtDescripcion.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["descripcion"].Value.ToString();
                txtcodigo.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["codigo"].Value.ToString();
                txtvalor.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["valor"].Value.ToString();
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

        private void Frm_Telecredito_KeyDown(object sender, KeyEventArgs e)
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
                case 2:
                    POnedatos();
                    u_n_opsel = 2;
                    U_RefrescaControles();
                    if ((Examinar.CurrentRow != null))
                    {
                        Examinar.CurrentRow.Selected = true;
                    }
                    break;
            }
        }

        private void save()
        {
            if (u_Validate())
            {
                tmpcursor = null;
                var BL = new tb_plla_tab0100BL();
                var BE = new tb_plla_tab0100();
                BE.norden = 0;
                tmpcursor = BL.TeleCredito_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                var ofila = tmpcursor.NewRow();
                ofila = VariablesPublicas.INSERTINTOTABLE(tmpcursor);
                ofila["codigo"] = Examinar.Rows[Examinar.CurrentRow.Index].Cells["codigo"].Value;
                for (lc_cont = 0; lc_cont <= Examinar.ColumnCount - 1; lc_cont++)
                {
                    xnomcampo = Examinar.Columns[lc_cont].Name;
                    ofila[xnomcampo] = Examinar.Rows[Examinar.CurrentRow.Index].Cells[lc_cont].Value;
                }
                ofila["codigo"] = txtcodigo.Text.Trim();
                ofila["descripcion"] = txtDescripcion.Text.Trim();
                ofila["valor"] = txtvalor.Text.Trim();
                tmpcursor.Rows.Add(ofila);
                if (BL.TeleCredito_InsertUpdate(VariablesPublicas.EmpresaID, BE, tmpcursor))
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
            txtDescripcion.Text = string.Empty;
            txtcodigo.Text = string.Empty;
            txtvalor.Text = string.Empty;
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

        private void btnmod_Click(object sender, EventArgs e)
        {
            Accion(2);
        }
    }
}
