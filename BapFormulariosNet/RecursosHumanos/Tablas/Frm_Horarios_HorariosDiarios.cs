using System;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.RecursosHumanos.Tablas
{
    public partial class Frm_Horarios_HorariosDiarios : plantilla
    {
        private AccionEnum _accion = AccionEnum.Eliminar;
        private int sw;
        private string J_Codigo = " ";
        private DataTable _Detalletabla = new DataTable();
        private DataTable _Cabeceratabla = new DataTable();
        private int indice = 0;
        private TextBox txtHoraDesde = null;
        private TextBox txtHoraHasta = null;
        private TextBox txtevento = null;

        public Frm_Horarios_HorariosDiarios()
        {
            InitializeComponent();

            Load += Frm_Horarios_HorariosDiarios_Load;
        }

        private void Frm_Horarios_HorariosDiarios_Load(object sender, EventArgs e)
        {
            GroupBox(false);
            ValidaTexboxs();
            BindingData(true);
            POnedatos();
        }

        private void GroupBox(bool enable)
        {
            GroupBox1.Enabled = !enable;
            gpCabecera.Enabled = enable;
            GroupBox2.Enabled = enable;
            GroupBox3.Enabled = enable;
            dgIngresos.ReadOnly = !enable;
            dgRubroGastos.Enabled = !enable;
        }

        private void BindingData(bool Binding)
        {
            if (Binding)
            {
                sw = 0;
                var LcFilaAct = -1;
                if ((dgRubroGastos != null))
                {
                    if (dgRubroGastos.Rows.Count > 0)
                    {
                        if (dgRubroGastos.CurrentRow == null)
                        {
                            LcFilaAct = 0;
                        }
                        else
                        {
                        }
                    }
                }

                dgRubroGastos.AutoGenerateColumns = false;
                var BL = new tb_plla_turnoscabBL();
                var BE = new tb_plla_turnoscab();
                BE.norden = 1;
                _Cabeceratabla = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                _Cabeceratabla.Columns[0].ReadOnly = true;
                _Cabeceratabla.AcceptChanges();
                dgRubroGastos.DataSource = _Cabeceratabla;

                gpCabecera.Enabled = false;
                gbDetalle.Enabled = true;
                try
                {
                    if (LcFilaAct >= 0 & dgRubroGastos.Rows.Count > 0)
                    {
                    }
                }
                catch
                {
                }
            }
            else
            {
                sw = 1;
                txtNombre.DataBindings.Clear();
                txtHoraInicio.DataBindings.Clear();
                ckInactivo.DataBindings.Clear();
                txtHoraFin.DataBindings.Clear();
                txtTotalHoras.DataBindings.Clear();
                txtTotalMinutos.DataBindings.Clear();
                txtCodigo.DataBindings.Clear();
                gpCabecera.Enabled = true;
            }
        }

        private void EnabledTool(bool enabled)
        {
            btnNuevo.Enabled = enabled;
            btnMod.Enabled = enabled;
            btnElimina.Enabled = enabled;
            btnGraba.Enabled = !enabled;
            btnCancel.Enabled = !enabled;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CleanText()
        {
            txtNombre.Text = string.Empty;
            txtTotalHoras.Text = string.Empty;
            txtTotalMinutos.Text = string.Empty;
            txtHoraInicio.Text = string.Empty;
            txtHoraFin.Text = string.Empty;
            ckInactivo.Checked = false;
            gpCabecera.Enabled = true;
            txtHoraInicio.Text = Convert.ToString("00:00");
            txtHoraFin.Text = Convert.ToString("00:00");
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            var i = 0;
            switch (e.KeyChar)
            {
                case (char)13:
                case (char)9:
                    txtCodigo.Text = VariablesPublicas.FormateaNumeroaCadena2(txtCodigo.Text.Trim(), 3, '0', true);
                    var zhallado = false;
                    for (i = 0; i <= dgRubroGastos.Rows.Count - 1; i++)
                    {
                        if (dgRubroGastos[0, i].Value.ToString() == txtCodigo.Text.Trim())
                        {
                            dgRubroGastos[0, i].Selected = true;
                            dgRubroGastos.CurrentCell = dgRubroGastos.Rows[i].Cells[0];
                            gpCabecera.Enabled = false;
                            gbDetalle.Enabled = true;
                            zhallado = true;
                            break;
                        }
                    }

                    if (!zhallado)
                    {
                        _accion = AccionEnum.Nuevo;
                        PerformAction(_accion);
                        BorraGrillaDetalleOS();
                        GroupBox(true);
                        dgRubroGastos.Enabled = false;
                        txtCodigo.Enabled = false;
                        ckInactivo.Checked = true;
                    }
                    break;
            }
        }

        private void PerformAction(AccionEnum accion)
        {
            switch (accion)
            {
                case AccionEnum.Nuevo:
                    EnabledTool(false);
                    BindingData(false);
                    CleanText();
                    break;
                case AccionEnum.Actualizar:
                    Save();
                    break;
                case AccionEnum.Eliminar:
                    if (dgRubroGastos.Rows.Count > 0)
                    {
                        anula();
                    }
                    break;
                case AccionEnum.Save:
                    Save();
                    break;
                case AccionEnum.Modificar:
                    txtCodigo.Enabled = false;
                    break;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = string.Empty;
            _accion = AccionEnum.Nuevo;
            PerformAction(_accion);
            J_Codigo = ".....";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se perdera la información modificada !!", "Mensaje", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _accion = AccionEnum.Eliminar;
                EnabledTool(true);
                if (sw == 1)
                {
                    BindingData(true);
                }
                if (dgRubroGastos.Rows.Count > 0)
                {
                    dgRubroGastos.CurrentCell = dgRubroGastos.Rows[indice].Cells[0];
                }
                GroupBox(false);
                txtCodigo.Enabled = true;
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (dgRubroGastos.Rows.Count > 0)
            {
                EnabledTool(false);
                BindingData(false);
                GroupBox(true);
                dgRubroGastos.Enabled = false;
                _accion = AccionEnum.Modificar;
                PerformAction(_accion);
            }
        }

        private void btnGraba_Click(object sender, EventArgs e)
        {
            _accion = AccionEnum.Save;
            PerformAction(_accion);
        }

        private void Save()
        {
            var retorno = false;
            decimal totminutos = 0;
            var estado = 0;
            txtCodigo.Text.Trim();
            if (ckInactivo.Checked == true)
            {
                estado = 1;
            }
            else
            {
                estado = 0;
            }
            if (txtTotalMinutos.Text.Trim() == string.Empty)
            {
                totminutos = 0;
            }
            else
            {
                totminutos = Convert.ToDecimal(txtTotalMinutos.Text);
            }
            var BL = new tb_plla_turnoscabBL();
            var BE = new tb_plla_turnoscab();
            BE.cdiario = txtCodigo.Text.Trim();
            BE.descripcion = txtNombre.Text.Trim();
            BE.horaini = txtHoraInicio.Text.Trim();
            BE.horafin = txtHoraFin.Text.Trim();
            BE.tothor = txtTotalHoras.Text.Trim();
            BE.totmin = totminutos;
            BE.status = estado;
            BE.Tipo_Actualizacion = 1;
            switch (_accion)
            {
                case AccionEnum.Save:
                    retorno = BL.Insert_Update(VariablesPublicas.EmpresaID, BE, _Cabeceratabla, _Detalletabla);
                    break;
                case AccionEnum.Actualizar:
                    retorno = BL.Insert_Update(VariablesPublicas.EmpresaID, BE, _Cabeceratabla, _Detalletabla);
                    break;
            }
            if (retorno)
            {
                MessageBox.Show("Los Datos se guardaron perfectamente");
                _accion = AccionEnum.Eliminar;
                EnabledTool(true);
                GroupBox(false);
                if (sw == 1)
                {
                    BindingData(true);
                }
                txtCodigo.Enabled = true;
            }
            else
            {
            }
        }

        private void anula()
        {
            if (MessageBox.Show("Desea Eliminar este registro permanentemente ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                var retorno = false;
                var BL = new tb_plla_turnoscabBL();
                var BE = new tb_plla_turnoscab();
                BE.cdiario = txtCodigo.Text.Trim();
                retorno = BL.Delete(VariablesPublicas.EmpresaID, BE);

                if (retorno)
                {
                    _accion = AccionEnum.Eliminar;
                    EnabledTool(true);
                    if (sw == 0)
                    {
                        BindingData(false);
                    }
                    if (sw == 1)
                    {
                        BindingData(true);
                    }
                }
                else
                {
                    MessageBox.Show("Hubo problemas al eliminar !!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            _accion = AccionEnum.Eliminar;
            PerformAction(_accion);
        }

        private void dgIngresos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var desde = string.Empty;
            var hasta = string.Empty;

            if (dgIngresos.CurrentCell != null)
            {
                if (dgIngresos.CurrentCell.IsInEditMode)
                {
                }
                desde = Convert.ToString(dgIngresos.CurrentRow.Cells[1].Value).Trim();
                hasta = Convert.ToString(dgIngresos.CurrentRow.Cells[2].Value).Trim();

                var valuesDesde = getValuesHour(desde);

                var horaDesde = Convert.ToInt32(valuesDesde[0]);
                var minDesde = Convert.ToInt32(valuesDesde[1]);

                if (!(horaDesde <= 23 & minDesde <= 59))
                {
                    MessageBox.Show("Error en dato");
                    dgIngresos.CancelEdit();
                    return;
                }

                var valuesHasta = getValuesHour(hasta);

                var horaHasta = Convert.ToInt32(valuesHasta[0]);
                var minHasta = Convert.ToInt32(valuesHasta[1]);

                if (!(horaDesde >= 0 & horaHasta <= 23) & (minDesde >= 0 & minHasta <= 59))
                {
                    MessageBox.Show("Error en dato");
                    dgIngresos.CancelEdit();
                    return;
                }

                dgIngresos.CurrentRow.Cells[5].Value = getDifferenceTime(ref desde, ref hasta);
                dgIngresos.CurrentRow.Cells[1].Value = desde;
                dgIngresos.CurrentRow.Cells[2].Value = hasta;
                if (dgIngresos.CurrentRow.Cells[5].Value.ToString() != string.Empty)
                {
                    dgIngresos.CurrentRow.Cells[6].Value = Convert.ToInt64(Strings.Mid(dgIngresos.CurrentRow.Cells[5].Value.ToString().Trim(), 1, 2)) * 60 + (Convert.ToInt64(Strings.Mid(dgIngresos.CurrentRow.Cells[5].Value.ToString().Trim(), 4, 2)));
                }
                else
                {
                    dgIngresos.CurrentRow.Cells[6].Value = 0;
                }
            }
            if (e.ColumnIndex == 3)
            {
                ValidaEventos(e.RowIndex, true);
            }
            dgIngresos.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private bool ValidaEventos(int fila, bool b)
        {
            var prove = string.Empty;
            var trab = new DataTable();
            if ((!object.ReferenceEquals(dgIngresos.Rows[fila].Cells[3].Value, DBNull.Value)))
            {
                if (dgIngresos.Rows[fila].Cells[3].Value.ToString() != string.Empty)
                {
                    var BL = new tb_plla_geneventospermisoBL();
                    var BE = new tb_plla_geneventospermiso();
                    prove = VariablesPublicas.FormateaNumeroaCadena2(dgIngresos.Rows[fila].Cells[3].Value.ToString().Trim(), 3, '0', true);
                    dgIngresos.Rows[fila].Cells[3].Value = prove;
                    BE.eventoperid = prove;
                    trab = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                }
            }
            if (trab.Rows.Count > 0)
            {
                dgIngresos.Rows[dgIngresos.CurrentRow.Index].Cells[4].Value = trab.Rows[0]["eventopername"].ToString().Trim();
                return true;
            }
            else
            {
                if (b)
                {
                    MessageBox.Show("Codigo no existe !!!");
                }
                return false;
            }
        }
        private void validaHorario()
        {
            var desde = string.Empty;
            var hasta = string.Empty;
            desde = txtHoraInicio.Text.Trim();
            hasta = txtHoraFin.Text.Trim();

            var valuesDesde = getValuesHour(desde);
            var horaDesde = Convert.ToInt32(valuesDesde[0]);
            var minDesde = Convert.ToInt32(valuesDesde[1]);

            if (!(horaDesde <= 23 & minDesde <= 59))
            {
                MessageBox.Show("Error en dato");
                dgIngresos.CancelEdit();
                return;
            }
            var valuesHasta = getValuesHour(hasta);

            var horaHasta = Convert.ToInt32(valuesHasta[0]);
            var minHasta = Convert.ToInt32(valuesHasta[1]);

            if (!(horaDesde >= 0 & horaHasta <= 23) & (minDesde >= 0 & minHasta <= 59))
            {
                MessageBox.Show("Error en dato");
                dgIngresos.CancelEdit();
                return;
            }
            txtTotalHoras.Text = getDifferenceTime(ref desde, ref hasta);
            txtHoraInicio.Text = desde;
            txtHoraFin.Text = hasta;
            if (txtTotalHoras.Text.Trim() != string.Empty)
            {
                txtTotalMinutos.Text = (Convert.ToInt64(Equivalencias.Mid(txtTotalHoras.Text.Trim(), 1, 2)) * 60 + Convert.ToInt64(Equivalencias.Mid(txtTotalHoras.Text.Trim(), 4, 2))).ToString();
            }
            else
            {
                txtTotalMinutos.Text = "0";
            }
        }
        private string getFormatHour(string text)
        {
            var desdeArray = text.Split(':');
            if (desdeArray.Length == 1)
            {
                text = VariablesPublicas.FormateaNumeroaCadena2(desdeArray[0], 2, '0', true);
                text = text + ":00";
            }
            else
            {
                if (desdeArray.Length == 2)
                {
                    text = VariablesPublicas.FormateaNumeroaCadena2(desdeArray[0], 2, '0', true);
                    text = text + ":";
                    var min = VariablesPublicas.FormateaNumeroaCadena2(desdeArray[1], 2, '0', true);
                    text = text + min;
                }
            }
            return text;
        }
        private string[] getValuesHour(string text)
        {
            return getFormatHour(text).Split(':');
        }
        private string getDifferenceTime(ref string desde, ref string hasta)
        {
            var functionReturnValue = (string )null;
            var difference = string.Empty;
            var horaD = 0;
            var minD = 0;
            var horaH = 0;
            var minH = 0;
            var horaDiff = 0;
            var minDiff = 0;

            desde = getFormatHour(desde);
            hasta = getFormatHour(hasta);

            horaD = Convert.ToInt32(desde.Substring(0, 2));
            minD = Convert.ToInt32(desde.Substring(3, 2));
            horaH = Convert.ToInt32(hasta.Substring(0, 2));
            minH = Convert.ToInt32(hasta.Substring(3, 2));

            if (horaH >= 00 & horaH <= 12 & horaD > 12 & horaD < 24)
            {
                var fecIni = new DateTime(1900, 1, 1, horaD, minD, 0);
                var fecFin = new DateTime(1900, 1, 2, horaH, minH, 0);

                horaDiff = Convert.ToInt32(DateAndTime.DateDiff(DateInterval.Hour, fecIni, fecFin));
                minDiff = Convert.ToInt32(DateAndTime.DateDiff(DateInterval.Minute, fecIni, fecFin));
            }
            else
            {
                if (horaH == 00 & horaD >= 00 & horaD <= 12)
                {
                    var fecIni = new DateTime(1900, 1, 1, horaD, minD, 0);
                    var fecFin = new DateTime(1900, 1, 2, horaH, minH, 0);

                    horaDiff = Convert.ToInt32(DateAndTime.DateDiff(DateInterval.Hour, fecIni, fecFin));
                    minDiff = Convert.ToInt32(DateAndTime.DateDiff(DateInterval.Minute, fecIni, fecFin));
                }
                else
                {
                    var fecIni = new DateTime(1900, 1, 1, horaD, minD, 0);
                    var fecFin = new DateTime(1900, 1, 1, horaH, minH, 0);

                    horaDiff = Convert.ToInt32(DateAndTime.DateDiff(DateInterval.Hour, fecIni, fecFin));
                    minDiff = Convert.ToInt32(DateAndTime.DateDiff(DateInterval.Minute, fecIni, fecFin));
                }
            }

            if (horaDiff < 0 | minDiff < 0)
            {
                MessageBox.Show("Error en dato");
                dgIngresos.CancelEdit();
                return string.Empty;
                return functionReturnValue;
            }

            if (horaDiff > 0)
            {
                minDiff = minDiff - (horaDiff * 60);
            }

            difference = horaDiff.ToString() + ":" + minDiff.ToString();
            return getFormatHour(difference);
        }
        public void BorraGrillaDetalleOS()
        {
            dgIngresos.ReadOnly = false;
            var n = 0;
            if (dgIngresos.Rows.Count > 0)
            {
                for (n = 0; n <= dgIngresos.Rows.Count - 1; n++)
                {
                    dgIngresos.Rows.RemoveAt(dgIngresos.CurrentRow.Index);
                }
            }
        }

        private void dgIngresos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var paraHoraDesde = new ParametrosTextBox();
            paraHoraDesde.LengthReal = 2;
            paraHoraDesde.LengthDecimal = 2;
            paraHoraDesde.CharDecimal = ':';

            var paraHoraHasta = new ParametrosTextBox();
            paraHoraHasta.LengthReal = 2;
            paraHoraHasta.LengthDecimal = 2;
            paraHoraHasta.CharDecimal = ':';

            var paraevento = new ParametrosTextBox();
            paraevento.LengthReal = 3;
            paraevento.LengthDecimal = 0;
            paraevento.LengthText = 3;

            if (dgIngresos.CurrentCell.IsInEditMode)
            {
                if (dgIngresos.CurrentCell.ColumnIndex == 1)
                {
                    txtHoraDesde = (TextBox)e.Control;
                    txtHoraDesde.Tag = paraHoraDesde;
                    txtHoraDesde.Text.Trim();
                    txtHoraDesde.KeyPress += VariablesPublicas.IngresaMoneda_KeyPress;
                    txtHoraDesde.TextChanged += VariablesPublicas.TextDecimal_Changed;
                }
                else
                {
                    if (dgIngresos.CurrentCell.ColumnIndex == 2)
                    {
                        txtHoraHasta = (TextBox)e.Control;
                        txtHoraHasta.Tag = paraHoraHasta;
                        txtHoraHasta.Text.Trim();
                        txtHoraHasta.KeyPress += VariablesPublicas.IngresaMoneda_KeyPress;
                        txtHoraHasta.TextChanged += VariablesPublicas.TextDecimal_Changed;
                    }
                }
                if (dgIngresos.CurrentCell.ColumnIndex == 3)
                {
                    txtevento = (TextBox)e.Control;
                    txtevento.Tag = paraevento;
                    txtevento.Text.Trim();
                    txtevento.KeyPress += VariablesPublicas.IngresaMoneda_KeyPress;
                    txtevento.TextChanged += VariablesPublicas.TextDecimal_Changed;
                }
            }
        }

        private void ValidaTexboxs()
        {
            var paraHoraDesde = new ParametrosTextBox();
            paraHoraDesde.LengthReal = 2;
            paraHoraDesde.LengthDecimal = 2;
            paraHoraDesde.CharDecimal = ':';

            var paraHoraHasta = new ParametrosTextBox();
            paraHoraHasta.LengthReal = 2;
            paraHoraHasta.LengthDecimal = 2;
            paraHoraHasta.CharDecimal = ':';

            txtHoraInicio.Tag = paraHoraDesde;
            txtHoraInicio.Text.Trim();
            txtHoraInicio.MaxLength = 5;
            txtHoraInicio.KeyPress += VariablesPublicas.IngresaMoneda_KeyPress;
            txtHoraInicio.TextChanged += VariablesPublicas.TextDecimal_Changed;

            txtHoraFin.Tag = paraHoraHasta;
            txtHoraFin.Text.Trim();
            txtHoraFin.MaxLength = 5;
            txtHoraFin.KeyPress += VariablesPublicas.IngresaMoneda_KeyPress;
            txtHoraFin.TextChanged += VariablesPublicas.TextDecimal_Changed;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgIngresos.Rows.Count > 0)
            {
                dgIngresos.Rows.RemoveAt(dgIngresos.CurrentRow.Index);
                _Detalletabla = (DataTable)dgIngresos.DataSource;
                if ((dgIngresos.CurrentRow != null))
                {
                    var lc_filaact = dgIngresos.CurrentRow.Index;
                    var n_fila = 0;
                    for (n_fila = 0; n_fila <= dgIngresos.Rows.Count - 1; n_fila++)
                    {
                        dgIngresos.Rows[n_fila].Cells[0].Value = VariablesPublicas.FormateaNumeroaCadena2(Convert.ToString(n_fila + 1), 2, '0', true);
                    }

                    try
                    {
                        dgIngresos.CurrentCell = dgIngresos.Rows[lc_filaact].Cells[0];
                    }
                    catch (Exception ex)
                    {
                        dgIngresos.CurrentCell = dgIngresos.Rows[dgIngresos.Rows.Count - 1].Cells[0];
                    }
                }
                _Detalletabla.AcceptChanges();
            }
        }

        private int MaximoItem()
        {
            var lc_Mayor = -1;
            var l_cont = 0;
            for (l_cont = 0; l_cont <= dgIngresos.Rows.Count - 1; l_cont++)
            {
                if (Convert.ToInt32(dgIngresos.Rows[l_cont].Cells[0].Value) > lc_Mayor)
                {
                    lc_Mayor = Convert.ToInt32(dgIngresos.Rows[l_cont].Cells[0].Value);
                }
            }
            return (lc_Mayor == -1 ? 1 : lc_Mayor + 1);
        }
        private void redefineItem(int item)
        {
            var n = 0;
            if (_Detalletabla.Rows.Count > 1)
            {
                for (n = 0; n <= _Detalletabla.Rows.Count - 2; n++)
                {
                    if (n >= item - 1)
                    {
                        _Detalletabla.Rows[n]["item"] = VariablesPublicas.FormateaNumeroaCadena2(Convert.ToString(n + 2), 2, '0', true);
                    }
                    else
                    {
                        _Detalletabla.Rows[n]["item"] = VariablesPublicas.FormateaNumeroaCadena2(Convert.ToString(n + 1), 2, '0', true);
                    }
                }
            }
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            _Detalletabla = (DataTable)dgIngresos.DataSource;
            if (_Detalletabla == null)
            {
                var BL = new tb_plla_turnoscabBL();
                var BE = new tb_plla_turnoscab();
                BE.cdiario = txtCodigo.Text.Trim();
                _Detalletabla = BL.GetAll_GetAllCONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                _Detalletabla.Columns["des_evento"].ReadOnly = false;
            }
            var fila = _Detalletabla.NewRow();
            var item = 0;
            var desde = string.Empty;
            var hasta = string.Empty;
            desde = Convert.ToString("00:00");
            hasta = Convert.ToString("00:00");

            item = MaximoItem();
            fila[0] = txtCodigo.Text.Trim();
            fila[1] = VariablesPublicas.FormateaNumeroaCadena2(Convert.ToString(item), 2, '0', true);
            fila[2] = string.Empty;
            fila[3] = string.Empty;
            fila[4] = desde;
            fila[5] = hasta;
            fila[6] = string.Empty;
            fila[7] = 0;

            _Detalletabla.Rows.Add(fila);
            _Detalletabla.AcceptChanges();

            dgIngresos.AutoGenerateColumns = false;

            _Detalletabla.Columns[0].AllowDBNull = true;
            _Detalletabla.Columns[1].AllowDBNull = true;
            _Detalletabla.Columns[2].AllowDBNull = true;
            _Detalletabla.Columns[3].AllowDBNull = true;
            _Detalletabla.Columns[4].AllowDBNull = true;
            _Detalletabla.Columns[5].AllowDBNull = true;
            _Detalletabla.Columns[6].AllowDBNull = true;
            _Detalletabla.Columns[7].AllowDBNull = true;
            _Detalletabla.Columns["des_evento"].ReadOnly = false;
            _Detalletabla.AcceptChanges();
            dgIngresos.DataSource = _Detalletabla;
            var l_ubica = 0;
            for (l_ubica = 0; l_ubica <= dgIngresos.Rows.Count - 1; l_ubica++)
            {
                if (Convert.ToInt32(item) == Convert.ToInt32(dgIngresos.Rows[l_ubica].Cells[0].Value))
                {
                    dgIngresos.CurrentCell = dgIngresos.Rows[l_ubica].Cells[1];
                    dgIngresos.BeginEdit(true);
                    break;
                }
            }
        }

        private void txtHoraInicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                validaHorario();
            }
        }

        private void txtHoraFin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                validaHorario();
            }
        }

        private void dgRubroGastos_CurrentCellChanged(object sender, EventArgs e)
        {
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (dgIngresos.Rows.Count > 1)
            {
                _Detalletabla = (DataTable)dgIngresos.DataSource;
                var fila = _Detalletabla.NewRow();
                var item = 0;
                var desde = string.Empty;
                var hasta = string.Empty;
                desde = Convert.ToString("00:00");
                hasta = Convert.ToString("00:00");

                item = dgIngresos.CurrentRow.Index + 1;
                fila[0] = txtCodigo.Text.Trim();
                fila[1] = VariablesPublicas.FormateaNumeroaCadena2(Convert.ToString(item), 2, '0', true);
                fila[2] = string.Empty;
                fila[3] = string.Empty;
                fila[4] = desde;
                fila[5] = hasta;
                fila[6] = string.Empty;
                fila[7] = 0;

                _Detalletabla.Rows.Add(fila);
                _Detalletabla.AcceptChanges();

                dgIngresos.AutoGenerateColumns = false;

                _Detalletabla.Columns[0].AllowDBNull = true;
                _Detalletabla.Columns[1].AllowDBNull = true;
                _Detalletabla.Columns[2].AllowDBNull = true;
                _Detalletabla.Columns[3].AllowDBNull = true;
                _Detalletabla.Columns[4].AllowDBNull = true;
                _Detalletabla.Columns[5].AllowDBNull = true;
                _Detalletabla.Columns[6].AllowDBNull = true;
                _Detalletabla.Columns[7].AllowDBNull = true;
                _Detalletabla.Columns["des_evento"].ReadOnly = false;
                redefineItem(item);
                _Detalletabla.AcceptChanges();

                dgIngresos.DataSource = _Detalletabla;
                dgIngresos.Sort(dgIngresos.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                var l_ubica = 0;
                for (l_ubica = 0; l_ubica <= dgIngresos.Rows.Count - 1; l_ubica++)
                {
                    if (Convert.ToInt32(item) == Convert.ToInt32(dgIngresos.Rows[l_ubica].Cells[0].Value))
                    {
                        dgIngresos.CurrentCell = dgIngresos.Rows[l_ubica].Cells[1];
                        dgIngresos.BeginEdit(true);
                        break;
                    }
                }
            }
        }

        private void dgRubroGastos_SelectionChanged(object sender, EventArgs e)
        {
            POnedatos();
        }

        private void Blanquear()
        {
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtTotalHoras.Text = string.Empty;
            txtTotalMinutos.Text = string.Empty;
            ckInactivo.Checked = false;
            txtHoraInicio.Text = Convert.ToString("00:00");
            txtHoraFin.Text = Convert.ToString("00:00");
        }
        private void POnedatos()
        {
            Blanquear();
            if ((dgRubroGastos.CurrentRow != null))
            {
                txtCodigo.Text = dgRubroGastos.Rows[dgRubroGastos.CurrentRow.Index].Cells["CODIGO"].Value.ToString();
                txtNombre.Text = dgRubroGastos.Rows[dgRubroGastos.CurrentRow.Index].Cells["DESCRIPCION"].Value.ToString();
                ckInactivo.Checked = Convert.ToInt32(dgRubroGastos.Rows[dgRubroGastos.CurrentRow.Index].Cells["inactivo"].Value) == 1;
                txtHoraInicio.Text = dgRubroGastos.Rows[dgRubroGastos.CurrentRow.Index].Cells["Hora_inicial"].Value.ToString().Trim();
                txtHoraFin.Text = dgRubroGastos.Rows[dgRubroGastos.CurrentRow.Index].Cells["Hora_final"].Value.ToString().Trim();
                txtTotalHoras.Text = dgRubroGastos.Rows[dgRubroGastos.CurrentRow.Index].Cells["Total_horas"].Value.ToString();
                txtTotalMinutos.Text = dgRubroGastos.Rows[dgRubroGastos.CurrentRow.Index].Cells["Total_minutos"].Value.ToString();

                var BL = new tb_plla_turnoscabBL();
                var BE = new tb_plla_turnoscab();
                BE.cdiario = txtCodigo.Text.Trim();
                _Detalletabla = BL.GetAll_GetAllCONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                _Detalletabla.Columns["des_evento"].ReadOnly = false;
                dgIngresos.AutoGenerateColumns = false;
                dgIngresos.DataSource = _Detalletabla;
            }
        }
    }
}
