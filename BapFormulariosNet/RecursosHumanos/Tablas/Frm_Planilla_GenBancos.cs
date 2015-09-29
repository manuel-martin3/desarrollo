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
    public partial class Frm_Planilla_GenBancos : plantilla
    {
        private DataTable Tabla;
        private bool Sw_LOad = true;
        private int u_n_opsel = 0;
        private DataTable tmpcursor = new DataTable();
        private DataTable tmptabla = new DataTable();
        private string xnomcampo;
        private int lc_cont;

        public Frm_Planilla_GenBancos()
        {
            InitializeComponent();

            KeyDown += Frm_Planilla_GenTipoContrato_KeyDown;
            FormClosing += Frm_Planilla_GenTipoContrato_FormClosing;
            Load += Frm_Planilla_GenTipoContrato_Load;
        }

        private void Frm_Planilla_GenTipoContrato_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            WindowState = FormWindowState.Normal;
            FormBorderStyle = FormBorderStyle.Fixed3D;

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

            if (Examinar.SortedColumn != null)
            {
                xnomcolumna = Examinar.Columns[Examinar.SortedColumn.Index].Name;
                sorted = Examinar.SortOrder;
            }

            var BL = new tb_co_tabla03_bancoBL();
            var BE = new tb_co_tabla03_banco();
            BE.descripcion = txtBuscar.Text.Trim();
            Tabla = BL.GetAll(VariablesPublicas.EmpresaID, BE).Tables[0];
            Examinar.AutoGenerateColumns = false;
            Examinar.DataSource = Tabla;
            VariablesPublicas.PintaEncabezados(Examinar);

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
                Examinar.Sort(Examinar.Columns["codigoid"], System.ComponentModel.ListSortDirection.Ascending);
            }
        }

        private void U_RefrescaControles()
        {
            var xcoduser = string.Empty;
            decimal npos = -1;
            if ((Examinar.CurrentRow != null))
            {
                xcoduser = Examinar.Rows[Examinar.CurrentCell.RowIndex].Cells["codigoid"].Value.ToString();
                if (xcoduser.Trim().Length > 0)
                {
                    npos = VariablesPublicas.BuscarEnTable(xcoduser, "codigoid", Tabla);
                }
            }
            txtcodigo.Enabled = u_n_opsel == 1;
            txtDescripcion.Enabled = u_n_opsel > 0;
            txtSigla.Enabled = u_n_opsel > 0;
            txtBuscar.Enabled = u_n_opsel == 0;
            btnfiltro.Enabled = u_n_opsel == 0;
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
                        xtmpuser = Examinar.Rows[filaactual].Cells["codigoid"].Value.ToString();
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
                        if (Examinar.Rows[lc_cont].Cells["codigoid"].Value.ToString() == xtmpuser)
                        {
                            Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["codigoid"];
                            break;
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
        }

        private void btngrabar_Click(object sender, EventArgs e)
        {
            save();
        }

        private void Frm_Planilla_GenTipoContrato_FormClosing(object sender, FormClosingEventArgs e)
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
            if (txtDescripcion.Enabled & txtDescripcion.Text.Trim().Length == 0)
            {
                xmsg = "Ingrese descripción";
                xobjeto = txtDescripcion;
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
                txtcodigo.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["codigoid"].Value.ToString();
                txtDescripcion.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["descripcion"].Value.ToString();
                txtSigla.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["sigla"].Value.ToString();
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

        private void Frm_Planilla_GenTipoContrato_KeyDown(object sender, KeyEventArgs e)
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
                    var BL = new tb_co_tabla03_bancoBL();
                    var BE = new tb_co_tabla03_banco();
                    txtcodigo.Text = BL.GetAllMaxCodigo(VariablesPublicas.EmpresaID, BE).Tables[0].Rows[0]["maximo_codigo"].ToString();
                    if (Examinar.CurrentRow != null)
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
                    if (xnomcampo.Length == 0)
                    {
                        if (MessageBox.Show("Desea Eliminar Registro ..?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            var BLCO = new tb_co_tabla03_bancoBL();
                            var BECO = new tb_co_tabla03_banco();
                            BECO.codigoid = Examinar.Rows[Examinar.CurrentRow.Index].Cells["codigoid"].Value.ToString();
                            tmpcursor = BLCO.GetAll(VariablesPublicas.EmpresaID, BECO).Tables[0];
                            if (BLCO.Sql_Error.Length == 0)
                            {
                                if (BLCO.Delete(VariablesPublicas.EmpresaID, BECO))
                                {
                                    for (lc_cont = 0; lc_cont <= Tabla.Rows.Count - 1; lc_cont++)
                                    {
                                        if (Tabla.Rows[lc_cont]["codigoid"] == Examinar.Rows[Examinar.CurrentRow.Index].Cells["codigoid"].Value)
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
                                    Frm_Class.ShowError(BLCO.Sql_Error, this);
                                }
                            }
                            else
                            {
                                Frm_Class.ShowError(BLCO.Sql_Error, this);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(xnomcampo, "Imposible Eliminar Registro");
                    }
                    break;
            }
        }
        private void save()
        {
            if (u_Validate())
            {
                tmpcursor = null;
                var BL = new tb_co_tabla03_bancoBL();
                var BE = new tb_co_tabla03_banco();
                BE.codigoid = txtcodigo.Text.Trim();

                if (u_n_opsel == 1)
                {
                    tmptabla = BL.GetAll(VariablesPublicas.EmpresaID, BE).Tables[0];
                    if (tmptabla.Rows.Count > 0)
                    {
                        txtcodigo.Text = BL.GetAllMaxCodigo(VariablesPublicas.EmpresaID, BE).Tables[0].Rows[0]["maximo_codigo"].ToString();
                    }
                    BE.codigoid = txtcodigo.Text.Trim();
                    BE.descripcion = txtDescripcion.Text.Trim();
                    BE.sigla = txtSigla.Text.Trim();
                    BE.usuar = VariablesPublicas.Usuar.Trim();
                    if (BL.Insert(VariablesPublicas.EmpresaID, BE))
                    {
                        U_CancelarEdicion(0);
                    }
                    else
                    {
                        Frm_Class.ShowError(BL.Sql_Error, this);
                    }
                }
                else
                {
                    BE.codigoid = txtcodigo.Text.Trim();
                    BE.descripcion = txtDescripcion.Text.Trim();
                    BE.sigla = txtSigla.Text.Trim();
                    BE.usuar = VariablesPublicas.Usuar.Trim();
                    if (BL.Update(VariablesPublicas.EmpresaID, BE))
                    {
                        U_CancelarEdicion(0);
                    }
                    else
                    {
                        Frm_Class.ShowError(BL.Sql_Error, this);
                    }
                }
            }
        }

        public void Blanquear()
        {
            txtDescripcion.Text = string.Empty;
            txtcodigo.Text = string.Empty;
            txtSigla.Text = string.Empty;
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

        private void btnfiltro_Click(object sender, EventArgs e)
        {
            CargaDatos();
        }
    }
}
