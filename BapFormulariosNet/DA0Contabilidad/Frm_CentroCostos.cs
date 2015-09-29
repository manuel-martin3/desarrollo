using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using BapFormulariosNet.Codigo;

namespace BapFormulariosNet.DA0Contabilidad
{
    public partial class Frm_CentroCostos : plantilla
    {
        private DataTable Tabla = new DataTable();
        private DataTable tmpcursor = new DataTable();
        private DataTable tmptabla = new DataTable();

        private Boolean Sw_LOad = true;
        private int u_n_opsel = 0;
        private int lc_cont;
        private String xnomcampo = string.Empty;
        private string j_Sigla = string.Empty;

        public Frm_CentroCostos()
        {
            InitializeComponent();

            txtcodigo.LostFocus += new System.EventHandler(txtcodigo_LostFocus);
            txtcodigo.GotFocus += new System.EventHandler(txtcodigo_GotFocus);
        }

        private void Frm_CentroCostos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (u_n_opsel > 0)
            {
                MessageBox.Show("Finalice edición para cerrar formulario", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
        private void Frm_CentroCostos_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            CargaDatos();
            txtcodigo.MaxLength = 5;
            txtdescripcion.MaxLength = 80;
            txtclasecuenta.MaxLength = 2;
            Ponedatos();
            Sw_LOad = false;
            if (gridcentrocostos.RowCount > 0)
            {
                gridcentrocostos.Focus();
                gridcentrocostos.BeginEdit(true);
            }
            U_RefrescaControles();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quieres cerrar el formulario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void llenar_gridcentrocostos()
        {
            try
            {
                var BL = new centrocostoBL();
                var BE = new tb_centrocosto();

                Ponedatos();
                Sw_LOad = false;
                if (gridcentrocostos.RowCount > 0)
                {
                    gridcentrocostos.Focus();
                    gridcentrocostos.BeginEdit(true);
                }
                U_RefrescaControles();
                gridcentrocostos.AutoGenerateColumns = false;
                Tabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                gridcentrocostos.DataSource = Tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargaDatos()
        {
            var sorted = default(SortOrder);
            var xnomcolumna = string.Empty;
            if ((gridcentrocostos.SortedColumn != null))
            {
                xnomcolumna = gridcentrocostos.Columns[gridcentrocostos.SortedColumn.Index].Name;
                sorted = gridcentrocostos.SortOrder;
            }
            llenar_gridcentrocostos();
            if (xnomcolumna.Trim().Length > 0)
            {
                if (sorted == SortOrder.Ascending)
                {
                    gridcentrocostos.Sort(gridcentrocostos.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Ascending);
                }
                else
                {
                    gridcentrocostos.Sort(gridcentrocostos.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Descending);
                }
            }
            else
            {
                gridcentrocostos.Sort(gridcentrocostos.Columns["cencosid"], System.ComponentModel.ListSortDirection.Ascending);
            }
        }
        private void Ponedatos()
        {
            Blanquear();
            if ((gridcentrocostos.CurrentRow != null))
            {
                txtcodigo.Text = gridcentrocostos.Rows[gridcentrocostos.CurrentRow.Index].Cells["cencosid"].Value.ToString();
                txtdescripcion.Text = gridcentrocostos.Rows[gridcentrocostos.CurrentRow.Index].Cells["cencosname"].Value.ToString();
                txtclasecuenta.Text = gridcentrocostos.Rows[gridcentrocostos.CurrentRow.Index].Cells["cencosdivi"].Value.ToString();
                chkanalitica.Checked = Convert.ToBoolean(gridcentrocostos.Rows[gridcentrocostos.CurrentRow.Index].Cells["cencosanalitica"].Value.ToString());
                if (gridcentrocostos.Rows[gridcentrocostos.CurrentRow.Index].Cells["status"].Value.ToString() == "0")
                {
                    rbactivo.Checked = true;
                    rbanulado.Checked = false;
                }
                else
                {
                    rbactivo.Checked = false;
                    rbanulado.Checked = true;
                }
            }
        }
        private void U_RefrescaControles()
        {
            var xcoduser = string.Empty;
            decimal npos = -1;
            if ((gridcentrocostos.CurrentRow != null))
            {
                xcoduser = gridcentrocostos.Rows[gridcentrocostos.CurrentCell.RowIndex].Cells["cencosid"].Value.ToString();
                if (xcoduser.Trim().Length > 0)
                {
                    npos = VariablesPublicas.BuscarEnTable(xcoduser, "cencosid", Tabla);
                }
            }

            var xEnabled = Convert.ToBoolean(u_n_opsel == 0);
            var xEnabled1 = Convert.ToBoolean(u_n_opsel != 0);

            txtcodigo.Enabled = xEnabled1;
            txtdescripcion.Enabled = xEnabled1;
            txtclasecuenta.Enabled = xEnabled1;
            chkanalitica.Enabled = false;
            rbactivo.Enabled = xEnabled1;
            rbanulado.Enabled = xEnabled1;
            btnnew.Enabled = xEnabled;
            btnedit.Enabled = xEnabled;
            btnsave.Enabled = xEnabled1;
            btnredo.Enabled = xEnabled1;
            btndelete.Enabled = xEnabled;
            btnprint.Enabled = xEnabled;
            btnexit.Enabled = xEnabled;
            btninicial.Enabled = xEnabled;
            btnanterior.Enabled = xEnabled;
            btnsiguiente.Enabled = xEnabled;
            btnultimo.Enabled = xEnabled;
            gridcentrocostos.Enabled = xEnabled;
        }
        public void Blanquear()
        {
            txtcodigo.Text = string.Empty;
            txtdescripcion.Text = string.Empty;
            txtclasecuenta.Text = string.Empty;
            chkanalitica.Checked = false;
            rbactivo.Checked = true;
            rbanulado.Checked = false;
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            Accion(1);
        }

        private void Accion(int naccion)
        {
            switch (naccion)
            {
                case 1:
                    u_n_opsel = 1;
                    U_RefrescaControles();
                    Blanquear();
                    j_Sigla = txtcodigo.Text;
                    if ((gridcentrocostos.CurrentRow != null))
                    {
                        gridcentrocostos.CurrentRow.Selected = false;
                    }
                    break;

                case 2:
                    Ponedatos();
                    u_n_opsel = 2;
                    U_RefrescaControles();
                    gridcentrocostos.CurrentRow.Selected = true;
                    j_Sigla = txtcodigo.Text;
                    break;

                case 3:
                    xnomcampo = "";
                    if ((gridcentrocostos.CurrentRow != null))
                    {
                        var BL = new centrocostoBL();
                        var BE = new tb_centrocosto();

                        BE.cencosid = gridcentrocostos.Rows[gridcentrocostos.CurrentRow.Index].Cells["cencosid"].Value.ToString();
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
                                    xnomcampo = xnomcampo + tmpcursor.Rows[lc_cont]["relacion"] + '\r';
                                    if (lc_cont + 1 == 10)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (xnomcampo.Length == 0)
                    {
                        if (MessageBox.Show("Desea eliminar registro ...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            var BL = new centrocostoBL();
                            var BE = new tb_centrocosto();
                            BE.cencosid = gridcentrocostos.Rows[gridcentrocostos.CurrentRow.Index].Cells["cencosid"].Value.ToString();
                            tmpcursor = BL.GetAll(VariablesPublicas.EmpresaID, BE).Tables[0];
                            if (BL.Sql_Error.Length == 0)
                            {
                                if (BL.Delete(VariablesPublicas.EmpresaID.ToString(), BE))
                                {
                                    for (lc_cont = 0; lc_cont <= Tabla.Rows.Count - 1; lc_cont++)
                                    {
                                        if (Tabla.Rows[lc_cont]["cencosid"] == gridcentrocostos.Rows[gridcentrocostos.CurrentRow.Index].Cells["cencosid"].Value)
                                        {
                                            Tabla.Rows[lc_cont].Delete();
                                            Tabla.AcceptChanges();
                                            break;
                                        }
                                    }
                                    gridcentrocostos.Rows.Remove(gridcentrocostos.Rows[gridcentrocostos.CurrentRow.Index]);
                                    gridcentrocostos.Refresh();
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
                        MessageBox.Show(xnomcampo, "Imposible eliminar registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                default:
                    break;
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            Accion(2);
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            save();
        }
        private void save()
        {
            if (u_Validate())
            {
                var trueInt = 0;
                var falseInt = 1;

                try
                {
                    var BL = new centrocostoBL();
                    var BE = new tb_centrocosto();

                    BE.cencosid = txtcodigo.Text;
                    BE.cencosname = txtdescripcion.Text;
                    BE.cencosdivi = txtclasecuenta.Text;
                    BE.cencosanalitica = chkanalitica.Checked;

                    if (rbactivo.Checked == true)
                    {
                        BE.status = Convert.ToBoolean(trueInt);
                    }
                    if (rbanulado.Checked == true)
                    {
                        BE.status = Convert.ToBoolean(falseInt);
                    }

                    BE.usuar = VariablesPublicas.Usuar.Trim();

                    if (u_n_opsel == 1)
                    {
                        if (BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE))
                        {
                            MessageBox.Show("Se grabó con éxito", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Contacte con sistemas", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        if (BL.Update(VariablesPublicas.EmpresaID.ToString(), BE))
                        {
                            MessageBox.Show("Se grabó con éxito", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Contacte con sistemas", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private bool u_Validate()
        {
            var xmsg = string.Empty;
            var xobjeto = new object();

            if ((txtdescripcion.Enabled && (txtcodigo.Text.ToString().Length == 0)))
            {
                xmsg = xmsg + "Ingrese código del centro de costo";
                xobjeto = txtcodigo.Text;
            }

            if ((txtdescripcion.Enabled && (txtdescripcion.Text.ToString().Length == 0)))
            {
                xmsg = xmsg + "Ingrese descripción del centro de costo";
                xobjeto = txtdescripcion.Text;
            }

            if ((txtdescripcion.Enabled && (txtclasecuenta.Text.ToString().Length == 0)))
            {
                xmsg = xmsg + "Ingrese cuenta de costo";
                xobjeto = txtclasecuenta.Text;
            }

            if ((u_n_opsel == 1))
            {
                var BL = new centrocostoBL();
                var BE = new tb_centrocosto();

                BE.cencosid = txtcodigo.Text.Trim().ToUpper();
                tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                if ((tmptabla.Rows.Count > 0))
                {
                    xmsg = ("Código ya registrado ") + (tmptabla.Rows[0]["cencosid"] + (" (" + (tmptabla.Rows[0]["cencosname"] + ")")));
                    xobjeto = txtcodigo;
                }
            }
            if (!(xmsg.Trim().Length == 0))
            {
                MessageBox.Show(xmsg, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (Controls.ContainsKey("txtcodigo"))
                {
                    Controls["txtcodigo"].Focus();
                }
            }
            return xmsg.Trim().Length == 0;
        }

        private void btnredo_Click(object sender, EventArgs e)
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
                    tmpcursor = Tabla;
                    try
                    {
                        var filaactual = 0;
                        filaactual = gridcentrocostos.CurrentRow.Index;
                        xtmpuser = gridcentrocostos.Rows[filaactual].Cells["cencosid"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        xtmpuser = "..11";
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                u_n_opsel = 0;
                U_RefrescaControles();
                CargaDatos();
                if (gridcentrocostos.RowCount > 0)
                {
                    for (lc_cont = 0; lc_cont <= gridcentrocostos.Rows.Count - 1; lc_cont++)
                    {
                        if (gridcentrocostos.Rows[lc_cont].Cells["cencosid"].Value.ToString() == xtmpuser)
                        {
                            gridcentrocostos.CurrentCell = gridcentrocostos.Rows[lc_cont].Cells["cencosid"];
                            break;
                        }
                    }
                }
                Ponedatos();
                gridcentrocostos.Focus();
                if (gridcentrocostos.CurrentCell != null)
                {
                    gridcentrocostos.BeginEdit(true);
                }
            }
        }

        private void gridcentrocostos_SelectionChanged(object sender, EventArgs e)
        {
            if (!(Sw_LOad) & (u_n_opsel == 0))
            {
                Ponedatos();
                U_RefrescaControles();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            Accion(3);
        }

        private void btninicial_Click(object sender, EventArgs e)
        {
            u_Roleo(VariablesPublicas.toprecord);
        }
        private void btnanterior_Click(object sender, EventArgs e)
        {
            u_Roleo(VariablesPublicas.prevrecord);
        }
        private void btnsiguiente_Click(object sender, EventArgs e)
        {
            u_Roleo(VariablesPublicas.nextrecord);
        }
        private void btnultimo_Click(object sender, EventArgs e)
        {
            u_Roleo(VariablesPublicas.bottrecord);
        }
        public void u_Roleo(string xTipo)
        {
            RoleoGrid(gridcentrocostos, xTipo, "cencosid");
            Ponedatos();
        }
        public void RoleoGrid(System.Windows.Forms.DataGridView Grid, string xTipo, string xnamecolumna)
        {
            var nposreg = 0;
            var ncurrentfila = 0;
            var ncurrentcol = 0;
            try
            {
                nposreg = Grid.CurrentRow.Index;
                ncurrentfila = Grid.CurrentRow.Index;
                ncurrentcol = Grid.CurrentCell.ColumnIndex;
                if (xTipo == VariablesPublicas.toprecord)
                {
                    nposreg = 0;
                }
                if (xTipo == VariablesPublicas.bottrecord)
                {
                    nposreg = Grid.RowCount - 1;
                }
                if (xTipo == VariablesPublicas.nextrecord)
                {
                    if (nposreg < Grid.RowCount - 1)
                    {
                        nposreg = nposreg + 1;
                    }
                }
                if (xTipo == VariablesPublicas.prevrecord)
                {
                    if (nposreg > 0)
                    {
                        nposreg = nposreg - 1;
                    }
                }
                Grid.CurrentCell = Grid.Rows[nposreg].Cells[Grid.CurrentCell.ColumnIndex];
            }
            catch (Exception ex)
            {
                Grid.CurrentCell = Grid.Rows[ncurrentfila].Cells[ncurrentcol];
            }
        }

        private void gridcentrocostos_Paint(object sender, PaintEventArgs e)
        {
            for (var i = 0; i < gridcentrocostos.Rows.Count; ++i)
            {
                var estado = Convert.ToBoolean(gridcentrocostos.Rows[i].Cells["cencosanalitica"].Value);
                if (estado == true)
                {
                    gridcentrocostos.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(232, 232, 255);
                }
                else
                {
                    gridcentrocostos.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(208, 218, 223);
                    gridcentrocostos.Rows[i].DefaultCellStyle.Font = new Font("Thahoma", 7, FontStyle.Bold);
                }

                if (gridcentrocostos.Rows[i].Cells["status"].Value.ToString() == "0")
                {
                }
                else
                {
                    gridcentrocostos.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void txtcodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtdescripcion.Focus();
            }
        }

        private void txtdescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtclasecuenta.Focus();
            }
        }

        private void txtclasecuenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chkanalitica.Focus();
            }
        }

        private void rbactivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rbactivo.Focus();
            }
        }

        private void rbanulado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtcodigo.Focus();
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
        }

        private void txtcodigo_GotFocus(object sender, System.EventArgs e)
        {
            if (txtcodigo.Text.Trim().Length.ToString() == "5")
            {
                chkanalitica.Checked = true;
            }
            else
            {
                chkanalitica.Checked = false;
            }
        }
        private void txtcodigo_LostFocus(object sender, System.EventArgs e)
        {
            if (txtcodigo.Text.Trim().Length.ToString() == "5")
            {
                chkanalitica.Checked = true;
            }
            else
            {
                chkanalitica.Checked = false;
            }
        }
    }
}
