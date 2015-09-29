using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using BapFormulariosNet.Ayudas;
using BapFormulariosNet.Codigo;

namespace BapFormulariosNet.RecursosHumanos.Tablas
{
    public partial class Frm_ConfiguracionTareo : plantilla
    {
        private AccionEnum _accion = AccionEnum.Eliminar;
        private TextBox txtPosicion = null;
        private DataTable tabla;
        private int lc_contador = 0;
        public Frm_ConfiguracionTareo()
        {
            InitializeComponent();

            Load += Frm_ConfiguracionTareo_Load;
            KeyDown += Frm_ConfiguracionTareo_KeyDown;
        }

        private void llenar_cboTipoRubro()
        {
            try
            {
                cboTipoRubro.DataSource = NewMethodTRT();
                cboTipoRubro.DisplayMember = "Value";
                cboTipoRubro.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethodTRT()
        {
            var BL = new tb_plla_tab0100BL();
            var BE = new tb_plla_tab0100();
            var table = BL.TipoRubroTareo(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
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
                cbPlanilla.DataSource = NewMethoTP();
                cbPlanilla.DisplayMember = "Value";
                cbPlanilla.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethoTP()
        {
            var BL = new tb_plla_tipoplanillaBL();
            var BE = new tb_plla_tipoplanilla();
            BE.norden = 1;
            BE.ver_blanco = 0;
            BE.solopdt = 0;
            var table = BL.GetAll_Consulta(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
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

        private void Frm_ConfiguracionTareo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true)
            {
                switch (e.KeyCode)
                {
                    case Keys.N:
                        if (btnNuevaFila.Enabled == true)
                        {
                            btnNuevaFila_Click(sender, e);
                        }
                        break;
                    case Keys.U:
                        if (btnmod.Enabled == true)
                        {
                            tstActuallizar_Click(sender, e);
                        }
                        break;
                    case Keys.E:
                        if (btnBorraFila.Enabled == true)
                        {
                            btnBorraFila_Click(sender, e);
                        }
                        break;
                    case Keys.G:
                        if (btngrabar.Enabled == true)
                        {
                            btngrabar_Click(sender, e);
                        }
                        break;
                    case Keys.Q:
                        if (btncancelar.Enabled == true)
                        {
                            tstCancelar_Click(sender, e);
                        }
                        break;
                }
            }
            else
            {
                if (e.KeyCode == Keys.Escape & btncancelar.Enabled)
                {
                    btncancelar_Click(sender, e);
                }
                else
                {
                    if (e.KeyCode == Keys.Escape & btncerrar.Enabled)
                    {
                        btncerrar_Click(sender, e);
                    }
                }
            }
        }
        private void Frm_ConfiguracionTareo_Load(object sender, EventArgs e)
        {
            Llenar_cboTipoPlanilla();
            cbPlanilla.SelectedValue = "B";
            llenar_cboTipoRubro();
            cboTipoRubro.SelectedValue = "I";
            EnabledTool(true);
            dgIngresos.ReadOnly = true;
            GroupBox2.Enabled = false;

            btnmod.ToolTipText = "CTRL + U";
            btngrabar.ToolTipText = "CTRL + G";
            btncancelar.ToolTipText = "CTRL + Q";
        }

        private void cbPlanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaRubroIngreso();
        }

        private void tstActuallizar_Click(System.Object sender, System.EventArgs e)
        {
            EnabledTool(false);
            dgIngresos.ReadOnly = true;
            GroupBox2.Enabled = true;
        }

        private void tstCancelar_Click(System.Object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Se Pérdera la info", "Mensaje", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                _accion = AccionEnum.Eliminar;
                EnabledTool(true);
                CargaRubroIngreso();
                dgIngresos.ReadOnly = true;
                GroupBox2.Enabled = false;
            }
        }

        private void EnabledTool(bool enabled)
        {
            btnmod.Enabled = enabled;
            btnload.Enabled = !enabled;
            btngrabar.Enabled = !enabled;
            btncancelar.Enabled = !enabled;
            cbPlanilla.Enabled = enabled;
            btnload.Enabled = enabled;
            btncerrar.Enabled = enabled;
            cboTipoRubro.Enabled = enabled;
        }

        private void CargaRubroIngreso()
        {
            if (Convert.ToString(cbPlanilla.SelectedValue) != string.Empty & Convert.ToString(cboTipoRubro.SelectedValue) != string.Empty)
            {
                FormatoGrilla();
                if (_accion != AccionEnum.Nuevo | _accion != AccionEnum.Modificar)
                {
                }
            }
        }

        private void FormatoGrilla()
        {
            dgIngresos.AutoGenerateColumns = false;
            var xvmtipoplanilla = "..";
            var xvmtiporubro = "..";
            if ((cbPlanilla.SelectedValue != null))
            {
                xvmtipoplanilla = cbPlanilla.SelectedValue.ToString();
            }
            if ((cboTipoRubro.SelectedValue != null))
            {
                xvmtiporubro = cboTipoRubro.SelectedValue.ToString();
            }
            var BL = new tb_plla_tab0100BL();
            var BE = new tb_plla_tab0100();
            BE.ctab = xvmtipoplanilla;
            BE.cele = xvmtiporubro;
            tabla = BL.GetAllConfiguracionRubroTareo(VariablesPublicas.EmpresaID, BE).Tables[0];
            dgIngresos.DataSource = tabla;
        }

        public string FormateaNumeroaCadena(string S1, int nlen, char cfill)
        {
            var i = 0;
            for (i = 1; i <= nlen - S1.Trim().Length; i++)
            {
                S1 = cfill + S1;
            }
            return S1;
        }

        private void btnNuevaFila_Click(object sender, EventArgs e)
        {
            var f = new Frm_AyudaConfiguracionPlla();
            f.Owner = this;
            f.Formulario = this;
            f.TipoPlanilla = cbPlanilla.SelectedValue.ToString();
            f.TipoRubro = cboTipoRubro.SelectedValue.ToString();
            f.PasaRubro2 = Rubros;
            f.ShowDialog();
        }
        public void Rubros(string _codigo, string _nombre, int nestado)
        {
            tabla.Rows.Add(VariablesPublicas.INSERTINTOTABLE(tabla));
            tabla.Rows[tabla.Rows.Count - 1]["crubro"] = _codigo.ToString().Trim();
            tabla.Rows[tabla.Rows.Count - 1]["drubro"] = _nombre.ToString().Trim();
            tabla.Rows[tabla.Rows.Count - 1]["nestado"] = nestado;
            for (lc_contador = 0; lc_contador <= tabla.Rows.Count - 1; lc_contador++)
            {
                tabla.Rows[lc_contador]["porrubro"] = lc_contador + 1;
            }
            tabla.AcceptChanges();
        }

        private void btnBorraFila_Click(object sender, EventArgs e)
        {
            if (dgIngresos.CurrentRow == null)
            {
                return;
            }
            if (dgIngresos.Rows.Count > 0)
            {
                if (MessageBox.Show("Realmente desea borrar la fila seleccionada ?", "eliminacion de rubro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dgIngresos.Rows.RemoveAt(dgIngresos.CurrentRow.Index);
                    if ((dgIngresos.CurrentRow != null))
                    {
                        var lc_filaact = dgIngresos.CurrentRow.Index;
                        tabla.AcceptChanges();
                        var n_fila = 0;
                        for (n_fila = 0; n_fila <= dgIngresos.Rows.Count - 1; n_fila++)
                        {
                            dgIngresos.Rows[n_fila].Cells["porrubro"].Value = n_fila + 1;
                        }
                        try
                        {
                            dgIngresos.CurrentCell = dgIngresos.Rows[lc_filaact].Cells["drubro"];
                        }
                        catch (Exception ex)
                        {
                            dgIngresos.CurrentCell = dgIngresos.Rows[dgIngresos.Rows.Count - 1].Cells["drubro"];
                        }
                    }
                    else
                    {
                    }
                }
            }
        }

        private void cboTipoRubro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaRubroIngreso();
        }

        private void dgIngresos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            txtPosicion = (TextBox)e.Control;
            var para = default(ParametrosTextBox);

            para.CharDecimal = '.';
            para.LengthReal = 4;
            para.LengthDecimal = 2;

            txtPosicion.Tag = para;

            txtPosicion.MaxLength = 8;
            txtPosicion.KeyPress += VariablesPublicas.IngresaMoneda_KeyPress;
            txtPosicion.TextChanged += VariablesPublicas.TextDecimal_Changed;
        }

        private void btnmod_Click(object sender, EventArgs e)
        {
            EnabledTool(false);
            dgIngresos.ReadOnly = true;
            GroupBox2.Enabled = true;
        }

        private void btngrabar_Click(object sender, EventArgs e)
        {
            if (dgIngresos.IsCurrentCellInEditMode)
            {
                dgIngresos.EndEdit();
            }
            tabla.AcceptChanges();
            var BL = new tb_plla_tab0100BL();
            var BE = new tb_plla_tab0100();
            BE.ctab = cbPlanilla.SelectedValue.ToString();
            BE.cele = cboTipoRubro.SelectedValue.ToString();
            if (BL.ConfiguracionRubrotareoInsert(VariablesPublicas.EmpresaID, BE, tabla))
            {
                CargaRubroIngreso();
                dgIngresos.ReadOnly = true;
                EnabledTool(true);
                GroupBox2.Enabled = false;
            }
            else
            {
                Frm_Class.ShowError(BL.Sql_Error, this);
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se Pérdera la info", "Mensaje del Sistema", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                _accion = AccionEnum.Eliminar;
                EnabledTool(true);
                CargaRubroIngreso();
                dgIngresos.ReadOnly = true;
                GroupBox2.Enabled = false;
            }
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            CargaRubroIngreso();
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
