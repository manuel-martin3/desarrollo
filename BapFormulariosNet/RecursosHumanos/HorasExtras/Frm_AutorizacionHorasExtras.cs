using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using bapFunciones;
using BapFormulariosNet.Seguridadlog;

namespace BapFormulariosNet.RecursosHumanos.HorasExtras
{
    public partial class Frm_AutorizacionHorasExtras : plantilla
    {
        private int modo = 0;
        public string _ccia = VariablesPublicas.EmpresaID;
        public string _cperiodo = VariablesPublicas.perianio;
        private AccionEnum _accion = AccionEnum.Eliminar;
        public int u_N_Opsel = 0;
        private TextBox txtHoraDesde = null;
        private TextBox txtHoraHasta = null;
        private bool swedicion = false;
        private string _Caption = string.Empty;

        public Frm_AutorizacionHorasExtras()
        {
            InitializeComponent();

            Load += Frm_AutorizacionHorasExtras_Load;

            var paraNumAutorizacion = new ParametrosTextBox();
            paraNumAutorizacion.LengthReal = 3;

            txtNumAutorizacion.Tag = paraNumAutorizacion;
            txtNumAutorizacion.MaxLength = 3;
            txtNumAutorizacion.KeyPress += VariablesPublicas.IngresaMoneda_KeyPress;
            txtNumAutorizacion.TextChanged += VariablesPublicas.TextDecimal_Changed;
        }

        private void Frm_AutorizacionHorasExtras_Load(object sender, EventArgs e)
        {
            CargarTipoPlanilla();
            CargaRubroIngreso();
            EnabledTool(true);
            GroupBox2.Enabled = false;
            GroupBox5.Enabled = false;
            btnAgregatrabajador.Enabled = false;
            btnQuitaTrabajador.Enabled = false;
            btnAgregatrabajador.Enabled = false;
            _Caption = Text + "-";
        }

        private void cbPlanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tstSave.Enabled == false)
            {
                CargaRubroIngreso();
            }
        }

        private void tstActuallizar_Click(object sender, EventArgs e)
        {
            if (!HojaCerrada())
            {
                u_N_Opsel = 2;
                EnabledTool(false);
                dgIngresos.ReadOnly = false;
                dgIngresos.Columns[0].ReadOnly = true;
                dgIngresos.Columns[2].ReadOnly = true;
                dgIngresos.Columns[5].ReadOnly = true;
                GroupBox1.Enabled = false;
                GroupBox2.Enabled = true;
                GroupBox5.Enabled = true;
                btnAgregatrabajador.Enabled = true;
                btnQuitaTrabajador.Enabled = true;
                btnAgregatrabajador.Enabled = true;
                dtFregistro.Enabled = false;
                modo = 1;
            }
        }

        private void tstSave_Click(object sender, EventArgs e)
        {
            if (HojaCerrada())
            {
                return;
            }
            var LcCOdCosto = string.Empty;
            var a = 0;
            var B = 0;
            var C = 0;
            a = 0;
            B = 0;
            C = 0;
            var aa = string.Empty;
            var bb = string.Empty;
            var retorno = false;
            if (string.IsNullOrEmpty(txtAutorizadopor.Text.Trim().ToString()))
            {
                aa = Constants.vbCrLf + "**Ingrese el nombre de la persona que autoriza.";
                a = 0;
            }
            else
            {
                a = 1;
            }
            if (dgIngresos.Rows.Count == 0)
            {
                bb = Constants.vbCrLf + "**Para Grabar la Autorización debe contener al menos a un trabajador.";
                B = 0;
            }
            else
            {
                B = 1;
            }
            if (HorasExtrasCerrada())
            {
                MessageBox.Show("Planilla De Horas Extras cerrada .. Consulte con Recursos Humanos", "Imposible Grabar");
                return;
            }
            if (!Existe_Autorizacion())
            {
                C = 1;
            }
            else
            {
                bb = bb + "\r" + "No se puede Asignar Numero de Autorización.. Consulte A Sistemas";
            }
            if (B == 1 & a == 1)
            {
                if (!ValidaDatos())
                {
                    return;
                }
                if ((cboCCosto.SelectedValue != null))
                {
                    LcCOdCosto = cboCCosto.SelectedValue.ToString();
                }
                var Data = new DataTable();
                dgIngresos.DataSource = Data;
                Data.AcceptChanges();
            }
            if (retorno)
            {
                MessageBox.Show("Se Grabó Autorización Nº " + txtNumAutorizacion.Text, "Mensaje del Sistema");
                CargaRubroIngreso();
                dgIngresos.ReadOnly = true;
                EnabledTool(true);
                GroupBox1.Enabled = true;
                GroupBox2.Enabled = false;
                GroupBox5.Enabled = false;
                btnAgregatrabajador.Enabled = false;
                btnQuitaTrabajador.Enabled = false;
                btnAgregatrabajador.Enabled = false;
                txtNumAutorizacion.Enabled = true;
                dtFregistro.Enabled = false;
                u_N_Opsel = 0;
            }
            else
            {
                Interaction.MsgBox("Para Grabar corrija lo siguiente :" + Constants.vbCrLf + aa + bb, MsgBoxStyle.Information);
            }
        }

        private void tstCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("No se guardarán los datos modificados !!!", "Mensaje del Sistema", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _accion = AccionEnum.Eliminar;
                CargaRubroIngreso();
                EnabledTool(true);
                dgIngresos.ReadOnly = true;
                GroupBox1.Enabled = true;
                GroupBox2.Enabled = false;
                GroupBox5.Enabled = false;
                btnAgregatrabajador.Enabled = false;
                btnQuitaTrabajador.Enabled = false;
                btnAgregatrabajador.Enabled = false;
                dtFregistro.Enabled = false;
                u_N_Opsel = 0;
            }
        }

        private void CargarTipoPlanilla()
        {
            cbPlanilla.DisplayMember = "dplanilla";
            cbPlanilla.ValueMember = "ncom_3p";
            cboCCosto.DisplayMember = "nomb_7k";
            cboCCosto.ValueMember = "ccos_7k";
        }

        private void EnabledTool(bool enabled)
        {
            tstActuallizar.Enabled = enabled;
            tstSave.Enabled = !enabled;
            btnborrartodo.Enabled = enabled;
            tstCancelar.Enabled = !enabled;
            btnReporte.Enabled = enabled;
            tsEliminar.Enabled = enabled;
        }

        private void CargaRubroIngreso()
        {
            if (Convert.ToString(cbPlanilla.SelectedValue) != string.Empty)
            {
                var tabla = new DataTable();
                txtNumAutorizacion.Text = FormateaNumeroaCadena(txtNumAutorizacion.Text.Trim(), 3, '0');
                TextBox3.Text = tabla.Rows[0][1] + Constants.vbCrLf + tabla.Rows[0][2] + Constants.vbCrLf + tabla.Rows[0][3];
                if (_accion != AccionEnum.Nuevo | _accion != AccionEnum.Modificar)
                {
                }
            }
            swedicion = dgIngresos.Rows.Count > -1;
        }

        private void MuestraCabecera(DataTable tabla)
        {
            if (tabla.Rows.Count > 0)
            {
                chkRegularizacion.Checked = Convert.ToBoolean(tabla.Rows[0][2]);
                cboCCosto.SelectedValue = tabla.Rows[0][3];
                dtFemision.Value = Convert.ToDateTime(tabla.Rows[0][4]);
                txtAutorizadopor.Text = tabla.Rows[0][5].ToString();
                dtFregistro.Value = Convert.ToDateTime(tabla.Rows[0][6]);
                txtMotivo.Text = tabla.Rows[0][7].ToString();

                txtTippla.Text = tabla.Rows[0][8].ToString().Trim();

                EnabledTool(true);
                dgIngresos.ReadOnly = true;
                GroupBox2.Enabled = false;
                GroupBox5.Enabled = false;
                btnAgregatrabajador.Enabled = false;
                btnQuitaTrabajador.Enabled = false;
                btnAgregatrabajador.Enabled = false;
            }
            else
            {
                Limpiar();
            }
        }
        private void Limpiar()
        {
            chkRegularizacion.Checked = false;
            dtFemision.Text = string.Empty;
            txtAutorizadopor.Text = string.Empty;
            dtFregistro.Text = string.Empty;
            txtMotivo.Text = string.Empty;

            EnabledTool(false);
            dgIngresos.ReadOnly = false;
            GroupBox2.Enabled = true;
            GroupBox5.Enabled = true;
            btnAgregatrabajador.Enabled = true;
            btnQuitaTrabajador.Enabled = true;
            btnAgregatrabajador.Enabled = true;

            try
            {
                cboCCosto.SelectedItem = cboCCosto.Items[1].ToString();
            }
            catch (Exception ex)
            {
            }
        }
        public bool ValidaDatos()
        {
            var tabla1 = new DataTable();
            string s = null;
            string s1 = null;
            string s2 = null;
            string s3 = null;
            var i = 0;
            var n = 0;
            var retorno = true;
            s = Strings.Mid(dtFemision.Text.Trim(), 1, 2);
            s1 = Strings.Mid(dtFemision.Text.Trim(), 4, 2);
            s2 = Strings.Mid(dtFemision.Text.Trim(), 7, 4);
            s3 = s2 + s1 + s;
            for (n = 0; n <= dgIngresos.RowCount - 1; n++)
            {
                for (i = 0; i <= tabla1.Rows.Count - 1; i++)
                {
                    if ((!object.ReferenceEquals(tabla1.Rows[i]["FICHA_3p"], DBNull.Value)))
                    {
                        if (dgIngresos.Rows[n].Cells[1].Value.ToString() == tabla1.Rows[i]["FICHA_3p"].ToString())
                        {
                            Interaction.MsgBox("Trabajador " + tabla1.Rows[i]["FICHA_3p"] + " " + "ya tiene autorizacion de hora extra en la secuencia " + tabla1.Rows[i]["secuen_3c"] + " " + tabla1.Rows[i]["NOMB_10"]);
                            retorno = false;
                            return retorno;
                            break;
                        }
                    }
                }
            }
            return retorno;
        }

        public void Rubros(string _codigo, string _nombre)
        {
            dgIngresos.Focus();
            var cont = 0;
            var sw = 0;
            for (cont = 0; cont <= dgIngresos.Rows.Count - 1; cont++)
            {
                sw = 0;
                if (_codigo.Trim().ToString() == dgIngresos[1, cont].Value.ToString())
                {
                    Interaction.MsgBox("Este Trabajador ya esta registrado en esta autorización", MsgBoxStyle.Information);
                    sw = 1;
                    agregaTrabajador();
                    break;
                }
            }

            if (sw == 0)
            {
                var tabla = (DataTable)dgIngresos.DataSource;
                var fila = tabla.NewRow();
                var item = 0;
                var desde = string.Empty;
                var hasta = string.Empty;
                desde = Convert.ToString("00:00");
                hasta = Convert.ToString("00:00");

                item = MaximoItem();
                fila[1] = _codigo;
                fila[2] = _nombre;
                fila[0] = FormateaNumeroaCadena(Convert.ToString(item), 3, '0');
                fila[3] = desde;
                fila[4] = hasta;
                fila[5] = string.Empty;
                fila[6] = string.Empty;

                tabla.Rows.Add(fila);
                tabla.AcceptChanges();

                dgIngresos.AutoGenerateColumns = false;
                dgIngresos.Columns[0].DataPropertyName = "item_3p";
                dgIngresos.Columns[1].DataPropertyName = "ficha_3p";
                dgIngresos.Columns[2].DataPropertyName = "nomb_10";

                tabla.Columns[0].AllowDBNull = true;
                tabla.Columns[1].AllowDBNull = true;
                tabla.Columns[2].AllowDBNull = true;
                tabla.Columns[3].AllowDBNull = true;
                tabla.Columns[5].AllowDBNull = true;
                tabla.Columns[6].AllowDBNull = true;
                tabla.AcceptChanges();
                dgIngresos.DataSource = tabla;
                var l_ubica = 0;
                for (l_ubica = 0; l_ubica <= dgIngresos.Rows.Count - 1; l_ubica++)
                {
                    if (Convert.ToInt32(item) == Convert.ToInt32(dgIngresos.Rows[l_ubica].Cells[0].Value))
                    {
                        dgIngresos.CurrentCell = dgIngresos.Rows[l_ubica].Cells[3];
                        break;
                    }
                }
            }
        }

        private void btnAgregatrabajador_Click(object sender, EventArgs e)
        {
            agregaTrabajador();
        }
        private void agregaTrabajador()
        {
        }

        private void btnQuitaTrabajador_Click(object sender, EventArgs e)
        {
            if (dgIngresos.Rows.Count > 0)
            {
                dgIngresos.Rows.RemoveAt(dgIngresos.CurrentRow.Index);
                if ((dgIngresos.CurrentRow != null))
                {
                    var lc_filaact = dgIngresos.CurrentRow.Index;
                    var n_fila = 0;
                    for (n_fila = 0; n_fila <= dgIngresos.Rows.Count - 1; n_fila++)
                    {
                        dgIngresos.Rows[n_fila].Cells[0].Value = FormateaNumeroaCadena(Convert.ToString(n_fila + 1), 3, '0');
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
            }
        }
        private static string FormateaNumeroaCadena(string S1, int nlen, char cfill)
        {
            var i = 0;
            for (i = 1; i <= nlen - S1.Trim().Length; i++)
            {
                S1 = cfill + S1;
            }
            return S1;
        }

        private void txtNumAutorizacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13 | Strings.Asc(e.KeyChar) == 9)
            {
                if (txtNumAutorizacion.Text.Trim() == string.Empty)
                {
                    var oData = new DataTable();
                    if (oData.Rows.Count > 0)
                    {
                        txtNumAutorizacion.Text = oData.Rows[0][0].ToString();
                    }
                }
                txtNumAutorizacion.Text = FormateaNumeroaCadena(txtNumAutorizacion.Text, 3, '0');
                CargaDatos();
                CargaRubroIngreso();
                if (tstActuallizar.Enabled == false)
                {
                    GroupBox1.Enabled = false;
                    u_N_Opsel = 1;
                }
                if (dgIngresos.Rows.Count > 0)
                {
                    dgIngresos.Focus();
                }
                else
                {
                    CargaMarcas(",.,,");
                }
            }
        }

        private void RefrescaObjetos()
        {
            txtNumAutorizacion.Enabled = swedicion;
        }

        private void dgIngresos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var fila = -1;
            var desde = string.Empty;
            var hasta = string.Empty;

            if (dgIngresos.CurrentCell != null)
            {
                if (dgIngresos.CurrentCell.IsInEditMode)
                {
                }

                fila = dgIngresos.CurrentCell.RowIndex;

                desde = Convert.ToString(dgIngresos.CurrentRow.Cells[3].Value);
                hasta = Convert.ToString(dgIngresos.CurrentRow.Cells[4].Value);

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
                dgIngresos.CurrentRow.Cells[3].Value = desde;
                dgIngresos.CurrentRow.Cells[4].Value = hasta;
            }
            dgIngresos.CommitEdit(DataGridViewDataErrorContexts.Commit);
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

            if (dgIngresos.CurrentCell.IsInEditMode)
            {
                if (dgIngresos.CurrentCell.ColumnIndex == 3)
                {
                    txtHoraDesde = (TextBox)e.Control;
                    txtHoraDesde.Tag = paraHoraDesde;
                    txtHoraDesde.Text.Trim();
                    txtHoraDesde.KeyPress += VariablesPublicas.IngresaMoneda_KeyPress;
                    txtHoraDesde.TextChanged += VariablesPublicas.TextDecimal_Changed;
                }
                else
                {
                    if (dgIngresos.CurrentCell.ColumnIndex == 4)
                    {
                        txtHoraHasta = (TextBox)e.Control;
                        txtHoraHasta.Tag = paraHoraHasta;
                        txtHoraHasta.Text.Trim();
                        txtHoraHasta.KeyPress += VariablesPublicas.IngresaMoneda_KeyPress;
                        txtHoraHasta.TextChanged += VariablesPublicas.TextDecimal_Changed;
                    }
                }
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("No hay datos por procesar", MsgBoxStyle.Information);
            }
        }

        private void txtNumAutorizacion_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtNumAutorizacion.Text) == 0)
            {
                txtNumAutorizacion.Text = "001";
            }
        }

        private void trabajador(string codigo)
        {
            txtNumAutorizacion.Text = codigo;
            txtNumAutorizacion.Focus();
            txtNumAutorizacion.Text = FormateaNumeroaCadena(txtNumAutorizacion.Text, 3, '0');
            CargaDatos();
            CargaRubroIngreso();
            if (tstActuallizar.Enabled == false)
            {
                GroupBox1.Enabled = false;
            }
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            if (cbPlanilla.SelectedValue != null)
            {
            }
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            if (HorasExtrasCerrada())
            {
                MessageBox.Show("Planilla De Horas Extras cerrada .. Consulte con Recursos Humanos", "Imposible Eliminar");
            }
            else
            {
                if (!HojaCerrada())
                {
                    var retorno = false;
                    if (MessageBox.Show("Realmente desea Eliminar el Numero de Autorización..?", "eliminacion de Autorizacion de Horas Extras", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (retorno)
                        {
                            MessageBox.Show("Accion realizada con exito");
                            CargaRubroIngreso();
                            EnabledTool(true);
                            GroupBox2.Enabled = false;
                            GroupBox5.Enabled = false;
                            btnAgregatrabajador.Enabled = false;
                            btnQuitaTrabajador.Enabled = false;
                            btnAgregatrabajador.Enabled = false;
                        }
                    }
                }
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

        private void btnImportHE_Click(object sender, EventArgs e)
        {
        }

        private bool Existe_Autorizacion()
        {
            var zRETURN = false;
            var oData = new System.Data.DataTable();
            if (u_N_Opsel == 1)
            {
                if (oData.Rows.Count > 0)
                {
                    if (!(oData.Rows[0]["NUMERO_AUTORIZACION"] == string.Empty))
                    {
                        txtNumAutorizacion.Text = oData.Rows[0]["NUMERO_AUTORIZACION"].ToString();
                        zRETURN = true;
                    }
                }
            }
            return zRETURN;
        }
        private bool HorasExtrasCerrada()
        {
            var zReturn = false;
            var oData = new System.Data.DataTable();
            if (oData.Rows.Count > 0)
            {
                zReturn = Convert.ToBoolean(oData.Rows[0]["CIERRE_01"]) == true;
            }
            else
            {
                zReturn = true;
            }
            return zReturn;
        }

        private void btnborrartodo_Click(object sender, EventArgs e)
        {
            if (HorasExtrasCerrada())
            {
                MessageBox.Show("Planilla De Horas Extras cerrada .. Consulte con Recursos Humanos", "Imposible Eliminar");
            }
            else
            {
                var retorno = false;
                if (MessageBox.Show("Realmente desea Eliminar Todas Las Autorizaciones de esta planilla..?", cbPlanilla.SelectedValue.ToString(), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (retorno)
                    {
                        MessageBox.Show("Accion realizada con exito");
                        CargaRubroIngreso();
                        EnabledTool(true);
                        GroupBox2.Enabled = false;
                        GroupBox5.Enabled = false;
                        btnAgregatrabajador.Enabled = false;
                        btnQuitaTrabajador.Enabled = false;
                        btnAgregatrabajador.Enabled = false;
                    }
                }
            }
        }

        private void dgIngresos_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgIngresos.RowCount > 0)
            {
                if (dgIngresos.CurrentCell == null)
                {
                    return;
                }
                CargaMarcas(dgIngresos["Column2", dgIngresos.CurrentRow.Index].Value.ToString());
            }
        }

        private void CargaMarcas(string Ficha)
        {
            var oData = new DataTable();
            dtFemision.Value.AddDays(-1);
            dtFemision.Value.AddDays(1);

            var xPLanilla = string.Empty;
            if ((cbPlanilla.SelectedValue != null))
            {
                xPLanilla = cbPlanilla.SelectedValue.ToString();
            }
            GridAsistencia.AutoGenerateColumns = false;
            GridAsistencia.DataSource = oData;
        }

        private void btnCAAutorizacion_Click(object sender, EventArgs e)
        {
            string SwCerrado = null;
            if (!tstSave.Enabled)
            {
                var oData = (DataTable )null;
                if (oData.Rows.Count > 0)
                {
                    if (oData.Rows.Count > 0)
                    {
                        SwCerrado = (oData.Rows[0]["CERRADO"] == "1" ? "APERTURA" : "CIERRE");

                        if (oData.Rows.Count > 0)
                        {
                            var LcActualiza = false;
                            if (LcActualiza)
                            {
                                MessageBox.Show("Cierre/Apertura de Hoja De Trabajo Satisfactoria", "Mensaje del Sistema");
                                CargaDatos();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Usuario No Autorizado... CONSULTE A RECURSOS HUMANOS", "Mensaje del Sistema");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hoja de Autorización Nro" + txtNumAutorizacion.Text + " Inválida.. VERIFIQUE", "Mensaje del Sistema");
                    }
                }
                else
                {
                    MessageBox.Show("No HAY USUARIOS AUTORIZADOS PARA ESTE PROCESO.. Consulte A Sistemas ", "Mensaje del Sistema");
                }
            }
        }

        private void CargaDatos()
        {
            var oData = new DataTable();
            if (oData.Rows.Count > 0)
            {
                Text = _Caption + (Convert.ToBoolean(oData.Rows[0]["Cerrado"]) == false ? "ABIERTO" : "CERRADO");
            }
            else
            {
                Text = _Caption;
                modo = 2;
            }
        }
        public bool HojaCerrada()
        {
            var LCNUMPLANILLA = string.Empty;
            if ((cbPlanilla.SelectedValue != null) & (!object.ReferenceEquals(cbPlanilla.SelectedValue, DBNull.Value)))
            {
                LCNUMPLANILLA = cbPlanilla.SelectedValue.ToString();
            }
            var Flag_Cierre = true;
            var oData = new DataTable();
            if (oData.Rows.Count > 0)
            {
                if (Convert.ToBoolean(oData.Rows[0]["Cerrado"]) == true)
                {
                    MessageBox.Show("Hoja de Autorización Cerrada.. Consulte a Recursos Humanos", "Mensaje del Sistema");
                }
                else
                {
                    Flag_Cierre = false;
                }
            }
            else
            {
                Flag_Cierre = false;
            }
            return Flag_Cierre;
        }

        private void tsSeguridad_Click(object sender, EventArgs e)
        {
            var frm = new FrmSeguridad();
            frm._Nombre = Name.Trim();
            frm._ClaveForm = VariablesPublicas.EmpresaID + VariablesPublicas.perianio + cbPlanilla.SelectedValue.ToString().Trim() + txtNumAutorizacion.Text.Trim();
            frm.ShowDialog();
        }
    }
}
