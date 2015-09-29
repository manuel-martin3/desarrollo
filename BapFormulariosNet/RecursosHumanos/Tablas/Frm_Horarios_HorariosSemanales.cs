using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using bapFunciones;

namespace BapFormulariosNet.RecursosHumanos.Tablas
{
    public partial class Frm_Horarios_HorariosSemanales : plantilla
    {
        public Frm_Horarios_HorariosSemanales()
        {
            InitializeComponent();

            Load += Frm_Horarios_HorariosSemanales_Load;
            KeyDown += Frm_Horarios_HorariosSemanales_KeyDown;
        }

        private void Frm_Horarios_HorariosSemanales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true)
            {
                switch (e.KeyCode)
                {
                    case Keys.N:
                        if (tsNuevo.Enabled == true)
                        {
                            tsNuevo_Click(sender, e);
                        }
                        break;
                    case Keys.U:
                        if (tsEditar.Enabled == true)
                        {
                            tsEditar_Click(sender, e);
                        }
                        break;
                    case Keys.E:
                        if (tsEliminar.Enabled == true)
                        {
                            tsEliminar_Click(sender, e);
                        }
                        break;
                    case Keys.G:
                        if (tsGrabar.Enabled == true)
                        {
                            tsGrabar_Click(sender, e);
                        }
                        break;
                    case Keys.Q:
                        if (tsCancelar.Enabled == true)
                        {
                            tsCancelar_Click(sender, e);
                        }
                        break;
                    case Keys.S:
                        if (tsSalir.Enabled == true)
                        {
                            tsSalir_Click(sender, e);
                        }
                        break;
                }
            }
        }
        private void Frm_Horarios_HorariosSemanales_Load(object sender, EventArgs e)
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;

            tsNuevo.ToolTipText = "CTRL + N";
            tsEditar.ToolTipText = "CTRL + U";
            tsEliminar.ToolTipText = "CTRL + E";
            tsGrabar.ToolTipText = "CTRL + G";
            tsCancelar.ToolTipText = "CTRL + Q";
            tsSalir.ToolTipText = "CTRL + S";

            Grilla();
            HabilitarBotones(true);
            HabilitarControles(true);
            Combos();
            BINDEO(true);
        }

        public void Limpiar()
        {
            txtDescripcion.Clear();
            chkActivo.Checked = false;
            cboLunes.SelectedValue = string.Empty;
            cboMartes.SelectedValue = string.Empty;
            cboMiercoles.SelectedValue = string.Empty;
            cboJueves.SelectedValue = string.Empty;
            cboViernes.SelectedValue = string.Empty;
            cboSabado.SelectedValue = string.Empty;
            cboDomingo.SelectedValue = string.Empty;
        }

        public void Eliminar()
        {
        }
        private string MaxCodigo()
        {
            return string.Empty;
        }

        public void GuardarActualizar()
        {
            string cod = null;
            cod = txtMCodigo.Text.Trim();
            var inac = 0;

            if (chkActivo.Checked == true)
            {
                inac = 1;
            }
            else
            {
                inac = 0;
            }
        }

        public void Combos()
        {
            var dt = new DataTable();

            cboLunes.DataSource = dt.Copy();
            cboLunes.ValueMember = "CODIGO";
            cboLunes.DisplayMember = "DESCRIPCION";

            cboMartes.DataSource = dt.Copy();
            cboMartes.ValueMember = "CODIGO";
            cboMartes.DisplayMember = "DESCRIPCION";

            cboMiercoles.DataSource = dt.Copy();
            cboMiercoles.ValueMember = "CODIGO";
            cboMiercoles.DisplayMember = "DESCRIPCION";

            cboJueves.DataSource = dt.Copy();
            cboJueves.ValueMember = "CODIGO";
            cboJueves.DisplayMember = "DESCRIPCION";

            cboViernes.DataSource = dt.Copy();
            cboViernes.ValueMember = "CODIGO";
            cboViernes.DisplayMember = "DESCRIPCION";

            cboSabado.DataSource = dt.Copy();
            cboSabado.ValueMember = "CODIGO";
            cboSabado.DisplayMember = "DESCRIPCION";

            cboDomingo.DataSource = dt.Copy();
            cboDomingo.ValueMember = "CODIGO";
            cboDomingo.DisplayMember = "DESCRIPCION";
        }
        public void HabilitarBotones(bool b)
        {
            tsNuevo.Enabled = b;
            tsEditar.Enabled = b;
            tsEliminar.Enabled = b;
            tsGrabar.Enabled = !b;
            tsCancelar.Enabled = !b;
        }
        public void HabilitarControles(bool b)
        {
            txtMCodigo.Enabled = b;
            txtDescripcion.Enabled = !b;
            chkActivo.Enabled = !b;
            cboLunes.Enabled = !b;
            cboLunes.Enabled = !b;
            cboMartes.Enabled = !b;
            cboMiercoles.Enabled = !b;
            cboJueves.Enabled = !b;
            cboViernes.Enabled = !b;
            cboSabado.Enabled = !b;
            cboDomingo.Enabled = !b;
        }
        public void Grilla()
        {
            dgHorarios.AutoGenerateColumns = false;
            if (dgHorarios.Rows.Count >= 1)
            {
                tsEditar.Enabled = true;
                tsEliminar.Enabled = true;
            }
            else
            {
                tsEditar.Enabled = false;
                tsEliminar.Enabled = false;
            }
        }

        private void BINDEO(bool binding)
        {
            if (binding == true)
            {
                txtMCodigo.DataBindings.Add("Text", dgHorarios.DataSource, "CODIGO");
                txtDescripcion.DataBindings.Add("Text", dgHorarios.DataSource, "DESCRIPCION");

                cboLunes.DataBindings.Add("SelectedValue", dgHorarios.DataSource, "HORARIO_LUN");
                cboMartes.DataBindings.Add("SelectedValue", dgHorarios.DataSource, "HORARIO_MAR");
                cboMiercoles.DataBindings.Add("SelectedValue", dgHorarios.DataSource, "HORARIO_MIE");
                cboJueves.DataBindings.Add("SelectedValue", dgHorarios.DataSource, "HORARIO_JUE");
                cboViernes.DataBindings.Add("SelectedValue", dgHorarios.DataSource, "HORARIO_VIE");
                cboSabado.DataBindings.Add("SelectedValue", dgHorarios.DataSource, "HORARIO_SAB");
                cboDomingo.DataBindings.Add("SelectedValue", dgHorarios.DataSource, "HORARIO_DOM");

                chkActivo.DataBindings.Add("Checked", dgHorarios.DataSource, "ESTADO");
            }
            else
            {
                txtMCodigo.DataBindings.Clear();
                txtDescripcion.DataBindings.Clear();

                cboLunes.DataBindings.Clear();
                cboMartes.DataBindings.Clear();
                cboMiercoles.DataBindings.Clear();
                cboJueves.DataBindings.Clear();
                cboViernes.DataBindings.Clear();
                cboSabado.DataBindings.Clear();
                cboDomingo.DataBindings.Clear();

                chkActivo.DataBindings.Clear();
            }
        }

        private void cboLunes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cboLunes.SelectedValue != null))
            {
                txtLu.Text = cboLunes.SelectedValue.ToString().Trim();
            }
            else
            {
                txtLu.Text = string.Empty;
            }
        }

        private void cboMartes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cboMartes.SelectedValue != null))
            {
                txtMa.Text = cboMartes.SelectedValue.ToString().Trim();
            }
            else
            {
                txtMa.Text = string.Empty;
            }
        }

        private void cboMiercoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cboMiercoles.SelectedValue != null))
            {
                txtMi.Text = cboMiercoles.SelectedValue.ToString().Trim();
            }
            else
            {
                txtMi.Text = string.Empty;
            }
        }

        private void cboJueves_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cboJueves.SelectedValue != null))
            {
                txtJu.Text = cboJueves.SelectedValue.ToString().Trim();
            }
            else
            {
                txtJu.Text = string.Empty;
            }
        }

        private void cboViernes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cboViernes.SelectedValue != null))
            {
                txtVi.Text = cboViernes.SelectedValue.ToString().Trim();
            }
            else
            {
                txtVi.Text = string.Empty;
            }
        }

        private void cboSabado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cboSabado.SelectedValue != null))
            {
                txtSa.Text = cboSabado.SelectedValue.ToString().Trim();
            }
            else
            {
                txtSa.Text = string.Empty;
            }
        }

        private void cboDomingo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cboDomingo.SelectedValue != null))
            {
                txtDo.Text = cboDomingo.SelectedValue.ToString().Trim();
            }
            else
            {
                txtDo.Text = string.Empty;
            }
        }

        private void tsEditar_Click(object sender, EventArgs e)
        {
            txtMCodigo.Text = dgHorarios["CODIGO", dgHorarios.CurrentRow.Index].Value.ToString();
            BINDEO(false);
            dgHorarios.Enabled = false;
            HabilitarControles(false);
            HabilitarBotones(false);
            txtDescripcion.Focus();
        }

        private void tsCancelar_Click(object sender, EventArgs e)
        {
            BINDEO(true);
            dgHorarios.Enabled = true;
            HabilitarControles(true);
            HabilitarBotones(true);
            txtMCodigo.Focus();
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            txtMCodigo.Text = dgHorarios["CODIGO", dgHorarios.CurrentRow.Index].Value.ToString();
            BINDEO(false);
            if (MessageBox.Show("Desea Eliminar este Registro", "Informacion del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                Eliminar();
            }
            else
            {
                BINDEO(true);
            }
        }

        private void tsGrabar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar la Descripcion", "Informacion del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescripcion.Focus();
            }
            else
            {
                GuardarActualizar();
            }
        }

        private void txtMCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMCodigo.Text = VariablesPublicas.FormateaNumeroaCadena2(txtMCodigo.Text.Trim(), 3, '0', true);

                string cod = null;
                cod = txtMCodigo.Text.Trim();
                var a = 0;

                if (dgHorarios.Rows.Count >= 1)
                {
                    for (a = 0; a <= dgHorarios.Rows.Count - 1; a++)
                    {
                        if (dgHorarios[0, a].Value.ToString() == cod.Trim())
                        {
                            dgHorarios.CurrentCell = dgHorarios.Rows[a].Cells[0];
                            break;
                        }
                        if (a == dgHorarios.Rows.Count - 1)
                        {
                            Limpiar();
                            BINDEO(false);
                            HabilitarBotones(false);
                            HabilitarControles(false);
                            dgHorarios.Enabled = false;
                            txtDescripcion.Focus();
                            txtMCodigo.Text = MaxCodigo().Trim();
                        }
                    }
                }
                else
                {
                    Limpiar();
                    BINDEO(false);
                    HabilitarBotones(false);
                    HabilitarControles(false);
                    dgHorarios.Enabled = false;
                    txtDescripcion.Focus();
                    txtMCodigo.Text = MaxCodigo().Trim();
                    chkActivo.Checked = true;
                }
            }
        }

        private void tsNuevo_Click(object sender, EventArgs e)
        {
            BINDEO(false);
            HabilitarBotones(false);
            HabilitarControles(false);
            Limpiar();
            dgHorarios.Enabled = false;
            txtMCodigo.Text = MaxCodigo();
            txtMCodigo.Enabled = false;
            txtDescripcion.Focus();
        }
    }
}
