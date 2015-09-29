using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.RecursosHumanos.Tareo
{
    public partial class Frm_TareoQuincenal : plantilla
    {
        private TextBox txtDias = null;
        private TextBox txtPorcent = null;
        private TextBox txtComedor = null;
        private DataTable _adelantoQuincena;
        private DataTable _descuentosAQ = new DataTable();
        private int _contador = 0;

        public Frm_TareoQuincenal()
        {
            InitializeComponent();

            Load += Frm_TareoQuincenal_Load;

            dgvAdelanto.AutoGenerateColumns = false;
        }

        private void Frm_TareoQuincenal_Load(object sender, EventArgs e)
        {
            tsbCancelarADE.Enabled = false;
            tsbGrabarADE.Enabled = false;
            tsbEditarADE.Enabled = false;
            tsbEliminarADE.Enabled = false;
            tsbImprimirADE.Enabled = false;
            cargarCombos();
        }

        private void cargarCombos()
        {
            lblPeriodoADE.Text = VariablesPublicas.perianio;
            CargarMeses();
            Llenar_cboTipoPlanilla();
            Llenar_cboModalidadPlla();
        }
        private void llenar_cboMeses()
        {
            try
            {
                cboMesADE.DataSource = NewMethodMeses();
                cboMesADE.DisplayMember = "Value";
                cboMesADE.ValueMember = "Key";
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

        private void Llenar_cboTipoPlanilla()
        {
            try
            {
                cboTipoPlanillaADE.DataSource = NewMethoTP();
                cboTipoPlanillaADE.DisplayMember = "Value";
                cboTipoPlanillaADE.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethoTP()
        {
            var BL = new tb_plla_tab0100BL();
            var BE = new tb_plla_tab0100();

            var table = BL.Quincenal_CONSULTA(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
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

        private void Llenar_cboModalidadPlla()
        {
            var BL = new tb_plla_tab0100BL();
            var BE = new tb_plla_tab0100();
            cboModalidadPlanillaADE.ValueMember = "cele";
            cboModalidadPlanillaADE.DisplayMember = "descrip";
            cboModalidadPlanillaADE.DataSource = BL.ModalidadPlanilla_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
        }
        private void CargarMeses()
        {
            var xMes = DateTime.Now.Month.ToString().Trim();
            xMes = VariablesPublicas.FormateaNumeroaCadena2(xMes, 2, '0', true);
            llenar_cboMeses();
            cboMesADE.SelectedValue = xMes;
        }

        private void ActivaControles(int flag)
        {
            dgvAdelanto.Enabled = true;
            if (flag == 1)
            {
                tsbEditarADE.Enabled = false;
                tsbEliminarADE.Enabled = false;
                tsbSalirADE.Enabled = false;
                tsbImprimirADE.Enabled = false;
                tsbGrabarADE.Enabled = true;
                tsbCancelarADE.Enabled = true;
                dgvAdelanto.ReadOnly = false;
                Panel1.Enabled = false;
            }
            if (flag == 0)
            {
                tsbEditarADE.Enabled = true;
                tsbEliminarADE.Enabled = true;
                tsbSalirADE.Enabled = true;
                tsbImprimirADE.Enabled = true;
                tsbGrabarADE.Enabled = false;
                tsbCancelarADE.Enabled = false;
                dgvAdelanto.ReadOnly = true;
                Panel1.Enabled = true;
            }
        }

        private void CargarGrilla(string tipoPlanilla)
        {
            if (_adelantoQuincena.Rows.Count > 0)
            {
                if (Convert.ToInt32(_adelantoQuincena.Rows[0]["NUEVO"]) == 1 & dtpFecProcesoADE.Value.Month != Convert.ToInt32(cboMesADE.SelectedValue))
                {
                    MessageBox.Show("Fecha de Proceso no corresponde al mes seleccionado !!!! ", "Mensaje del Sistema");
                    dtpFecProcesoADE.Focus();
                    return;
                }
                dgvAdelanto.DataSource = _adelantoQuincena;
                dtpFecProcesoADE.Text = _adelantoQuincena.Rows[0]["F_PROCESO"].ToString();
                ActivaControles(Convert.ToInt32(_adelantoQuincena.Rows[0]["NUEVO"]));
            }
        }

        private void MostrarDescuentos()
        {
            string ficha = null;
            string mes = null;
            string mes1 = null;
            string nombres = null;
            string fecIngreso = null;
            string area = null;

            ficha = dgvAdelanto.CurrentRow.Cells["Codigo"].Value.ToString();
            mes = cboMesADE.Text + " - " + lblPeriodoADE.Text;
            mes1 = VariablesPublicas.FormateaNumeroaCadena(cboMesADE.SelectedValue.ToString(), 2, '0', DirectionText.left);

            nombres = dgvAdelanto.CurrentRow.Cells["Nombres"].Value.ToString();
            fecIngreso = dgvAdelanto.CurrentRow.Cells["FecIngreso"].Value.ToString();
            area = dgvAdelanto.CurrentRow.Cells["Area"].Value.ToString();
        }
        private DataTable CargaTabla(DataTable tabla)
        {
            var n = 0;
            for (n = 0; n <= tabla.Rows.Count - 1; n++)
            {
                DataRow fila = null;
                fila = _descuentosAQ.NewRow();
                fila["company"] = tabla.Rows[n]["company"];
                fila["periodo"] = tabla.Rows[n]["periodo"];
                fila["mes"] = tabla.Rows[n]["mes"];
                fila["ficha"] = tabla.Rows[n]["ficha"];
                fila["rubro"] = tabla.Rows[n]["rubro"];
                fila["importe"] = tabla.Rows[n]["importe"];
                _descuentosAQ.Rows.Add(fila);
            }
            return _descuentosAQ;
        }
        private void Totdescuentos(double TotalDescuento, DataTable tabla)
        {
            dgvAdelanto.SelectedRows[0].Cells[10].Value = TotalDescuento;
            if (_contador == 0)
            {
                _descuentosAQ = tabla;
            }
            else
            {
                CargaTabla(tabla);
            }
            _contador = _contador + 1;
        }

        private void dgvAdelanto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAdelanto.Columns[e.ColumnIndex].Name == "Descuentos")
            {
                MostrarDescuentos();
            }
        }

        private void tsbDescuentos_Click(object sender, EventArgs e)
        {
            if (dgvAdelanto.CurrentRow != null)
            {
                MostrarDescuentos();
            }
        }

        private void btnExtraerADE_Click(object sender, EventArgs e)
        {
            if (cboTipoPlanillaADE.SelectedValue != null)
            {
                CargarGrilla(cboTipoPlanillaADE.SelectedValue.ToString());
            }
        }

        private void dgvAdelanto_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAdelanto.CurrentCell != null)
            {
                if (dgvAdelanto.CurrentCell.IsInEditMode)
                {
                }
                var dias = 0;
                var diasc = 0;
                dias = Convert.ToInt32(dgvAdelanto.CurrentRow.Cells[5].Value);
                diasc = Convert.ToInt32(Equivalencias.Mid(dtpFecProcesoADE.Text, 1, 2));
                if (dias > diasc & 1 == 0)
                {
                    MessageBox.Show("El Numero de dias no puede exeder a " + Convert.ToString(diasc) + " Dias.");
                    dgvAdelanto.CurrentRow.Cells[5].Value = 0;
                }
            }
            dgvAdelanto.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void tsbGrabarADE_Click(object sender, EventArgs e)
        {
            var retorno = false;
            var retorno1 = false;
            var retorno2 = false;
            var n = 0;
            var i = 0;
            if (dgvAdelanto.Rows.Count > 0)
            {
                for (i = 0; i <= dgvAdelanto.Rows.Count - 1; i++)
                {
                    if (!retorno1)
                    {
                        break;
                    }
                }
                retorno2 = (_descuentosAQ.Rows.Count > 0 ? false : true);
                for (n = 0; n <= _descuentosAQ.Rows.Count - 1; n++)
                {
                    if (Convert.ToInt32(_descuentosAQ.Rows[n]["importe"]) > 0)
                    {
                    }
                }
                if (retorno & retorno1 & retorno2)
                {
                    MessageBox.Show("La Operación se relizó con éxito.");
                    tsbCancelarADE_Click(sender, e);
                }
                else
                {
                }
            }
        }

        private void tsbImprimirADE_Click(object sender, EventArgs e)
        {
        }

        private void tsbEliminarADE_Click(object sender, EventArgs e)
        {
            var retorno = false;
            if (MessageBox.Show("Esta seguro de Eliminar Planilla ? ", "Mensaje", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (!retorno)
                {
                    MessageBox.Show("Problemas al Eliminar", "Mensaje del Sistema");
                }
                else
                {
                    tsbCancelarADE_Click(sender, e);
                }
            }
        }

        private void tsbDiasTrab_Click(object sender, EventArgs e)
        {
            if (dgvAdelanto.Rows.Count > 0)
            {
            }
        }

        private void tsbSalirADE_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvAdelanto_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var parD = new ParametrosTextBox();
            var parPorcent = new ParametrosTextBox();
            var parComedor = new ParametrosTextBox();
            parD.LengthReal = 2;
            parD.LengthText = 2;

            parPorcent.LengthReal = 1;
            parPorcent.LengthDecimal = 2;
            parPorcent.CharDecimal = '.';
            parPorcent.LengthText = 4;

            parComedor.LengthReal = 4;
            parComedor.LengthDecimal = 2;
            parComedor.CharDecimal = '.';
            parComedor.LengthText = 7;


            if (dgvAdelanto.CurrentCell.IsInEditMode)
            {
                if (dgvAdelanto.CurrentCell.ColumnIndex == 5)
                {
                    txtDias = (TextBox)e.Control;
                    txtDias.Tag = parD;
                    txtDias.Text.Trim();
                    txtDias.KeyPress += VariablesPublicas.IngresaMoneda_KeyPress;
                    txtDias.TextChanged += VariablesPublicas.TextDecimal_Changed;
                }
                if (dgvAdelanto.CurrentCell.ColumnIndex == 6)
                {
                    txtPorcent = (TextBox)e.Control;
                    txtPorcent.Tag = parPorcent;
                    txtPorcent.Text.Trim();
                    txtPorcent.KeyPress += VariablesPublicas.IngresaMoneda_KeyPress;
                    txtPorcent.TextChanged += VariablesPublicas.TextDecimal_Changed;
                }
                if (dgvAdelanto.CurrentCell.ColumnIndex == 9)
                {
                    txtComedor = (TextBox)e.Control;
                    txtComedor.Tag = parComedor;
                    txtComedor.Text.Trim();
                    txtComedor.KeyPress += VariablesPublicas.IngresaMoneda_KeyPress;
                    txtComedor.TextChanged += VariablesPublicas.TextDecimal_Changed;
                }
            }
        }

        private void dgvAdelanto_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Celda en Blanco !!!!!");
        }

        private void tsbCancelarADE_Click(object sender, EventArgs e)
        {
            dgvAdelanto.DataSource = null;
            tsbCancelarADE.Enabled = false;
            tsbGrabarADE.Enabled = false;
            tsbEditarADE.Enabled = false;
            tsbEliminarADE.Enabled = false;
            tsbImprimirADE.Enabled = false;
            tsbSalirADE.Enabled = true;
            Panel1.Enabled = true;
            btnExtraerADE.Focus();
        }

        private void tsbEditarADE_Click(object sender, EventArgs e)
        {
            tsbCancelarADE.Enabled = true;
            tsbGrabarADE.Enabled = true;
            tsbEditarADE.Enabled = false;
            tsbEliminarADE.Enabled = false;
            tsbImprimirADE.Enabled = false;
            tsbSalirADE.Enabled = false;
            Panel1.Enabled = false;
            dgvAdelanto.Enabled = true;
            dgvAdelanto.ReadOnly = false;
            dgvAdelanto.Focus();
        }
    }
}
