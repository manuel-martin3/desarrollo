using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using bapFunciones;

namespace BapFormulariosNet.RecursosHumanos.Tablas
{
    public partial class Frm_Horarios_HorariosAsignacion : plantilla
    {
        private int k;

        public Frm_Horarios_HorariosAsignacion()
        {
            InitializeComponent();

            Load += Frm_Horarios_HorariosAsignacion_Load;
            KeyDown += Frm_Horarios_HorariosAsignacion_KeyDown;
        }

        private void Frm_Horarios_HorariosAsignacion_KeyDown(object sender, KeyEventArgs e)
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
                        if (btnSalir.Enabled == true)
                        {
                            btnSalir_Click(sender, e);
                        }
                        break;
                    case Keys.B:
                        if (btnBuscar.Enabled == true)
                        {
                            btnBuscar_Click(sender, e);
                        }
                        break;
                }
            }
        }
        private void Frm_Horarios_HorariosAsignacion_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Fixed3D;
            ComboHorariosDiario();
            ComboHorariosSemanal();

            ComboTipoHorarios();

            GRILLATRABAJADOR(1);
            BINDEOTRABAJADOR(true);

            HabilitarBotones(true);
            HabilitarControles(true);

            chkVigente.Enabled = false;

            tsNuevo.ToolTipText = "CTRL + N";
            tsEditar.ToolTipText = "CTRL + U";
            tsEliminar.ToolTipText = "CTRL + E";
            tsGrabar.ToolTipText = "CTRL + G";
            tsCancelar.ToolTipText = "CTRL + Q";
        }

        public void ComboHorariosDiario()
        {
            cboCodHorarioDiario.ValueMember = "CODIGO";
            cboCodHorarioDiario.DisplayMember = "DESCRIPCION";
        }

        public void ComboHorariosSemanal()
        {
            cboCodHorarioSemanal.ValueMember = "CODIGO";
            cboCodHorarioSemanal.DisplayMember = "DESCRIPCION";
        }

        public void ComboTipoHorarios()
        {
            cboTHorario.ValueMember = "CODIGo";
            cboTHorario.DisplayMember = "DESCRIPCION";
        }

        public void GRILLATRABAJADOR(int vigen)
        {
            dgTrabajador.AutoGenerateColumns = false;

            if (vigen == 0)
            {
                var r = 0;
                for (r = 0; r <= dgTrabajador.Rows.Count - 1; r++)
                {
                    if (Convert.ToBoolean(dgTrabajador["VIGENTE", r].Value) == false)
                    {
                        dgTrabajador["FICHA", r].Style.ForeColor = Color.Red;
                        dgTrabajador["DTRABAJADOR", r].Style.ForeColor = Color.Red;
                    }
                }
            }
        }

        public void BINDEOTRABAJADOR(bool binding)
        {
            if (binding == true)
            {
                txtCodigo.DataBindings.Add("Text", dgTrabajador.DataSource, "FICHA");
                txtNombres.DataBindings.Add("Text", dgTrabajador.DataSource, "DTRABAJADOR");
                txtFIngreso.DataBindings.Add("Text", dgTrabajador.DataSource, "F_INGRESO");
                txtPlanilla.DataBindings.Add("Text", dgTrabajador.DataSource, "TIPO_PLANILLA");
                txtCargo.DataBindings.Add("Text", dgTrabajador.DataSource, "DCARGO");
                txtArea.DataBindings.Add("Text", dgTrabajador.DataSource, "DAREA");
                chkActivo.DataBindings.Add("Checked", dgTrabajador.DataSource, "VIGENTE");
            }
            else
            {
                txtCodigo.DataBindings.Clear();
                txtNombres.DataBindings.Clear();
                txtFIngreso.DataBindings.Clear();
                txtPlanilla.DataBindings.Clear();
                txtCargo.DataBindings.Clear();
                txtArea.DataBindings.Clear();
                chkActivo.DataBindings.Clear();
            }
        }

        private void tsVigente_Click(object sender, EventArgs e)
        {
            cdResaltadoVigentes.ShowDialog();
            tsVigente.BackColor = cdResaltadoVigentes.Color;

            if (tsVigente.BackColor == Color.White)
            {
                tsVigente.ForeColor = Color.Black;
            }
            else
            {
                tsVigente.ForeColor = Color.White;
            }

            if (dgTurno.Rows.Count > 0)
            {
                var c = 0;

                for (c = 0; c <= dgTurno.Columns.Count - 1; c++)
                {
                    dgTurno.Rows[0].Cells[c].Style.ForeColor = tsVigente.ForeColor;
                    dgTurno.Rows[0].Cells[c].Style.BackColor = tsVigente.BackColor;
                }
            }
        }

        private void chkVerInactivos_CheckedChanged(object sender, EventArgs e)
        {
            string cod = null;
            cod = txtCodigo.Text.Trim();

            BINDEOTRABAJADOR(false);
            if (chkVerInactivos.Checked == true)
            {
                GRILLATRABAJADOR(0);
            }
            else
            {
                GRILLATRABAJADOR(1);
            }
            BINDEOTRABAJADOR(true);

            var a = 0;
            if (dgTrabajador.Rows.Count >= 1)
            {
                for (a = 0; a <= dgTrabajador.Rows.Count - 1; a++)
                {
                    if (dgTrabajador[0, a].Value.ToString() == cod.Trim())
                    {
                        dgTrabajador.CurrentCell = dgTrabajador.Rows[a].Cells[0];
                        break;
                    }
                }
            }
        }

        public void Eliminar()
        {
        }

        public bool ValidarFecha(string fec)
        {
            var val = true;
            var fIni = default(System.DateTime);
            fIni = Convert.ToDateTime(fec);
            var a = 0;
            for (a = 0; a <= dgTurno.Rows.Count - 1; a++)
            {
                if (Convert.ToDateTime(dgTurno.Rows[a].Cells["FEC_INI"].Value) <= fIni & Convert.ToDateTime(dgTurno.Rows[a].Cells["FEC_FIN"].Value) >= fIni)
                {
                    return false;
                }
            }
            return val;
        }

        public void GuardarActualizar()
        {
            var fec = string.Empty;
            var vigen = 0;
            string fIni = null;
            string fech = null;

            fIni = dtpFechaIni.Value.ToShortDateString().ToString().Trim();
            fech = dtpFechaIni.Value.ToString().Trim();

            if (k == 1)
            {
                fec = DateTime.Now.ToShortDateString().ToString().Trim();
            }
            else
            {
                if (k == 2)
                {
                    fec = dgTurno.Rows[dgTurno.CurrentRow.Index].Cells["FEC_ASIGNACION"].Value.ToString().Trim();
                }
            }
            if (chkVigente.Checked == true)
            {
                vigen = 1;
            }
            else
            {
                vigen = 0;
            }

            string dia = null;
            string sem = null;
            dia = string.Empty;
            sem = string.Empty;

            if (cboTHorario.SelectedValue == "D")
            {
                if (cboCodHorarioDiario.SelectedValue == null)
                {
                    dia = string.Empty;
                }
                else
                {
                    dia = cboCodHorarioDiario.SelectedValue.ToString().Trim();
                }
            }

            if (cboTHorario.SelectedValue == "S")
            {
                if (cboCodHorarioSemanal.SelectedValue == null)
                {
                    sem = string.Empty;
                }
                else
                {
                    sem = cboCodHorarioSemanal.SelectedValue.ToString().Trim();
                }
            }

            if (k == 1 & ValidarFecha(fIni) == false)
            {
                MessageBox.Show("Existe un Turno Asignado a esta Fecha", "Informacion del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
            }
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
            dtpFechaIni.Enabled = !b;
            dtpFechaFin.Enabled = !b;
            cboTHorario.Enabled = !b;
            cboCodHorarioDiario.Enabled = !b;
            cboCodHorarioSemanal.Enabled = !b;
        }

        public void GRILLATURNO()
        {
            if (dgTurno.Rows.Count >= 1)
            {
                tsEditar.Enabled = true;
                tsEliminar.Enabled = true;
            }
            else
            {
                tsEditar.Enabled = false;
                tsEliminar.Enabled = false;
            }

            if (dgTurno.Rows.Count > 0)
            {
                var c = 0;

                for (c = 0; c <= dgTurno.Columns.Count - 1; c++)
                {
                    dgTurno.Rows[0].Cells[c].Style.ForeColor = tsVigente.ForeColor;
                    dgTurno.Rows[0].Cells[c].Style.BackColor = tsVigente.BackColor;
                }
            }
        }

        public void BINDEOTURNO(bool binding)
        {
            if (binding == true)
            {
                dtpFechaIni.DataBindings.Add("Text", dgTurno.DataSource, "FEC_INI");
                dtpFechaFin.DataBindings.Add("Text", dgTurno.DataSource, "FEC_FIN");
                cboTHorario.DataBindings.Add("SelectedValue", dgTurno.DataSource, "TIPO_HORARIO");
                cboCodHorarioDiario.DataBindings.Add("SelectedValue", dgTurno.DataSource, "COD_HORARIO_DIARIO");
                cboCodHorarioSemanal.DataBindings.Add("SelectedValue", dgTurno.DataSource, "COD_HORARIO_SEMANAL");
                chkVigente.DataBindings.Add("Checked", dgTurno.DataSource, "VIGENTE");
            }
            else
            {
                dtpFechaIni.DataBindings.Clear();
                dtpFechaFin.DataBindings.Clear();
                cboTHorario.DataBindings.Clear();
                cboCodHorarioDiario.DataBindings.Clear();
                cboCodHorarioSemanal.DataBindings.Clear();
                chkVigente.DataBindings.Clear();
            }
        }

        private void tsEditar_Click(object sender, EventArgs e)
        {
            BINDEOTURNO(false);
            dgTurno.Enabled = false;
            dgTrabajador.Enabled = false;

            txtMBuscar.Enabled = false;
            btnBuscar.Enabled = false;
            chkVerInactivos.Enabled = false;


            HabilitarControles(false);
            HabilitarBotones(false);

            dtpFechaIni.Enabled = false;
            dtpFechaFin.Enabled = false;

            dtpFechaIni.Focus();

            k = 2;
        }

        private void tsCancelar_Click(object sender, EventArgs e)
        {
            BINDEOTURNO(true);
            dgTurno.Enabled = true;
            dgTrabajador.Enabled = true;

            txtMBuscar.Enabled = true;
            btnBuscar.Enabled = true;
            chkVerInactivos.Enabled = true;


            HabilitarControles(true);
            HabilitarBotones(true);
            dtpFechaIni.Focus();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            BINDEOTURNO(false);
            if (MessageBox.Show("Desea Eliminar este Registro", "Informacion del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                Eliminar();
            }
            else
            {
                BINDEOTURNO(true);
            }
        }

        private void tsGrabar_Click(object sender, EventArgs e)
        {
            GuardarActualizar();
        }

        private void tsNuevo_Click(object sender, EventArgs e)
        {
            BINDEOTURNO(false);
            HabilitarBotones(false);
            HabilitarControles(false);

            dgTurno.Enabled = false;
            dgTrabajador.Enabled = false;

            txtMBuscar.Enabled = false;
            btnBuscar.Enabled = false;
            chkVerInactivos.Enabled = false;

            chkVigente.Checked = true;
            dtpFechaIni.Focus();

            k = 1;

            cboTHorario.SelectedValue = "D";
            if (dgTurno.RowCount > 0)
            {
                dtpFechaIni.Value = Convert.ToDateTime(dgTurno.Rows[0].Cells["FEC_FIN"].Value);
            }

            dtpFechaIni.Value = dtpFechaIni.Value.AddDays(1);
            dtpFechaFin.Value = dtpFechaIni.Value.AddMonths(1);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtMBuscar.Text = VariablesPublicas.FormateaNumeroaCadena2(txtMBuscar.Text.Trim(), 5, '0', true);
            string cod = null;
            cod = txtMBuscar.Text.Trim();
            var a = 0;
            if (dgTrabajador.Rows.Count >= 1)
            {
                for (a = 0; a <= dgTrabajador.Rows.Count - 1; a++)
                {
                    if (dgTrabajador[0, a].Value.ToString() == cod.Trim())
                    {
                        dgTrabajador.CurrentCell = dgTrabajador.Rows[a].Cells[0];
                        break;
                    }
                }
            }
        }

        private void txtMBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(sender, e);
            }
        }

        private void txtMBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtMBuscar.Text.Trim().Length > 0)
            {
                btnBuscar.Enabled = true;
            }
            else
            {
                btnBuscar.Enabled = false;
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            BINDEOTURNO(false);
            GRILLATURNO();
            BINDEOTURNO(true);
        }

        private void cboTHorario_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboTHorario.SelectedValue.ToString())
            {
                case "D":
                    lblDia.Visible = true;
                    cboCodHorarioDiario.Visible = true;
                    if ((cboCodHorarioDiario.SelectedValue != null))
                    {
                        cboCodHorarioDiario.SelectedIndex = 0;
                    }
                    lblSem.Visible = false;
                    cboCodHorarioSemanal.Visible = false;
                    break;
                case "S":
                    lblDia.Visible = false;
                    cboCodHorarioDiario.Visible = false;
                    lblSem.Visible = true;
                    cboCodHorarioSemanal.Visible = true;
                    if ((cboCodHorarioSemanal.SelectedValue != null))
                    {
                        cboCodHorarioSemanal.SelectedIndex = 0;
                    }
                    break;
            }
        }
    }
}
