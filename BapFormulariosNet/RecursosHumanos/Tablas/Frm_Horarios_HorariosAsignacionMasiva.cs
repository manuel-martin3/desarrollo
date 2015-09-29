using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using bapFunciones;

namespace BapFormulariosNet.RecursosHumanos.Tablas
{
    public partial class Frm_Horarios_HorariosAsignacionMasiva : plantilla
    {
        private DataTable _DetalleFiltrado = new DataTable();
        private DataTable _DetalleCM = new DataTable();
        private bool _flag = false;

        public Frm_Horarios_HorariosAsignacionMasiva()
        {
            InitializeComponent();

            Load += Frm_Horarios_HorariosAsignacionMasiva_Load;
        }

        private void Frm_Horarios_HorariosAsignacionMasiva_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            CargarCombos();
            cbHorarioDestino.SelectedValue = string.Empty;
            cbCargo.SelectedValue = string.Empty;
            cbplanilla.SelectedValue = string.Empty;
            cbHorario.SelectedValue = string.Empty;
            cbCCosto.SelectedValue = string.Empty;
            btnDesmarcar.Enabled = false;
            CargaTablas();
        }

        private void CargarCombos()
        {
            CargarHorarioDestino();
            CargarCentroCosto();
            CargarTipPLanilla();
            CargarHorario();
            CargarCargos();
        }

        private void CargarHorarioDestino()
        {
            cbHorarioDestino.DisplayMember = "descripcion";
            cbHorarioDestino.ValueMember = "codigo";
        }
        private void CargarCentroCosto()
        {
            cbCCosto.DisplayMember = "nomb_7k";
            cbCCosto.ValueMember = "ccos_7k";
        }
        private void CargarTipPLanilla()
        {
            cbplanilla.DisplayMember = "nomb_3t";
            cbplanilla.ValueMember = "tpla_3t";
        }
        private void CargarCargos()
        {
            cbCargo.DisplayMember = "NOMB_21";
            cbCargo.ValueMember = "CARGO_21";
        }
        private void CargarHorario()
        {
            cbHorario.DisplayMember = "descripcion";
            cbHorario.ValueMember = "codigo";
        }
        public void BorraGrillaDetalleOS()
        {
            _flag = true;
            dgColores.ReadOnly = false;
            var n = 0;
            if (dgColores.Rows.Count > 0)
            {
                for (n = 0; n <= dgColores.Rows.Count - 1; n++)
                {
                    dgColores.Rows.RemoveAt(dgColores.CurrentRow.Index);
                }
            }
            _flag = false;
        }

        private void CargaTablas()
        {
            _DetalleCM.Columns["seleccionar"].ReadOnly = false;
            _DetalleCM.AcceptChanges();
            dgColores.AutoGenerateColumns = false;
            dgColores.DataSource = _DetalleCM;
        }

        private void TotalItem()
        {
            if (dgColores.Rows.Count > 0)
            {
                dgColores.Columns[0].ReadOnly = false;
                var n = 0;
                for (n = 0; n <= dgColores.Rows.Count - 1; n++)
                {
                    dgColores.Rows[n].Cells[0].Value = VariablesPublicas.FormateaNumeroaCadena2(Conversion.Str(n + 1), 2, '0', true);
                }
                dgColores.Columns[0].ReadOnly = true;
            }
        }

        private bool ValidaDato()
        {
            var valor = true;
            var mensaje = string.Empty;

            if (cbHorarioDestino.SelectedValue == null)
            {
                mensaje = mensaje + Constants.vbCrLf + "* Debe Ingresar el Horario Destino";
                valor = false;
            }

            if (!valor)
            {
                MessageBox.Show(mensaje, "Asignacion Masiva de Horarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return valor;
        }

        private void TablaFiltrada()
        {
            if (_DetalleCM.Rows.Count > 0)
            {
                var n = 0;
                _DetalleFiltrado = _DetalleCM.Copy();
                for (n = 0; n <= _DetalleCM.Rows.Count - 1; n++)
                {
                    if (_DetalleFiltrado.Rows[n]["seleccionar"] != "true")
                    {
                        _DetalleFiltrado.Rows[n].Delete();
                    }
                }
                _DetalleFiltrado.AcceptChanges();
            }
        }
        private void Marcar(bool b)
        {
            if (_DetalleCM.Rows.Count > 0)
            {
                var n = 0;

                for (n = 0; n <= _DetalleCM.Rows.Count - 1; n++)
                {
                    if (b)
                    {
                        _DetalleCM.Rows[n]["seleccionar"] = "true";
                    }
                    else
                    {
                        _DetalleCM.Rows[n]["seleccionar"] = "false";
                    }
                }
                _DetalleCM.AcceptChanges();
            }
        }
        private bool Validatablafiltrada()
        {
            var functionReturnValue = false;
            var n = 0;
            var j = 0;
            var tabla = (DataTable )null;
            var returnbool = true;
            if (_DetalleFiltrado.Rows.Count > 0)
            {
                if (rbasignacion.Checked)
                {
                    for (n = 0; n <= _DetalleFiltrado.Rows.Count - 1; n++)
                    {
                        if (tabla.Rows.Count > 0)
                        {
                            for (j = 0; j <= tabla.Rows.Count - 1; j++)
                            {
                                if (dtpFechaEmision.Value.ToShortDateString() == tabla.Rows[j]["Fec_ini"] & cbHorarioDestino.SelectedValue == tabla.Rows[j]["cod_horario"])
                                {
                                    MessageBox.Show("Trabajador ya tine Horario en esa fecha. " + "Ficha : " + tabla.Rows[j]["Ficha"] + " " + tabla.Rows[j]["dficha"]);
                                    return returnbool == false;
                                    return functionReturnValue;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No existen Registros marcados");
                return returnbool == false;
            }
            return returnbool;
        }

        private void btnDesmarcar_Click(object sender, EventArgs e)
        {
            Marcar(false);
            btnDesmarcar.Enabled = false;
            btnMarcar.Enabled = true;
        }

        private void ChkCCosto_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkCCosto.Checked == true)
            {
                cbCCosto.Enabled = true;
            }
            else
            {
                cbCCosto.Enabled = false;
                cbCCosto.SelectedValue = string.Empty;
            }
        }

        private void Chkcargo_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkcargo.Checked == true)
            {
                cbCargo.Enabled = true;
            }
            else
            {
                cbCargo.Enabled = false;
                cbCargo.SelectedValue = string.Empty;
            }
        }

        private void ChkHorario_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkHorario.Checked == true)
            {
                cbHorario.Enabled = true;
            }
            else
            {
                cbHorario.Enabled = false;
                cbHorario.SelectedValue = string.Empty;
            }
        }

        private void ChkPlanilla_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkPlanilla.Checked == true)
            {
                cbplanilla.Enabled = true;
            }
            else
            {
                cbplanilla.Enabled = false;
                cbplanilla.SelectedValue = string.Empty;
            }
        }

        private void cbplanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaTablas();
        }

        private void cbCCosto_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaTablas();
        }

        private void cbHorario_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaTablas();
        }

        private void cbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaTablas();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (ValidaDato())
            {
            }
            else
            {
                return;
            }
            var retorno = false;
            TablaFiltrada();
            if (Validatablafiltrada())
            {
            }
            else
            {
                return;
            }
            if (rbasignacion.Checked)
            {
            }
            else
            {
            }
            if (retorno)
            {
                MessageBox.Show("La Asignacion se Realizó con Exito. ");
                CargaTablas();
            }
        }

        private void btnMarcar_Click(object sender, EventArgs e)
        {
            Marcar(true);
            btnMarcar.Enabled = false;
            btnDesmarcar.Enabled = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
