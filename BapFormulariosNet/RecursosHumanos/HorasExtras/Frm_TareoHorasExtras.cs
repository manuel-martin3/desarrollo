using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using bapFunciones;

namespace BapFormulariosNet.RecursosHumanos.HorasExtras
{
    public partial class Frm_TareoHorasExtras : plantilla
    {
        public string _ccia = VariablesPublicas.EmpresaID;
        public string _cperiodo = VariablesPublicas.perianio;
        private AccionEnum _accion = AccionEnum.Eliminar;
        private bool swedicion = false;

        public Frm_TareoHorasExtras()
        {
            InitializeComponent();

            Load += Frm_TareoHorasExtras_Load;
        }

        private void Frm_TareoHorasExtras_Load(object sender, EventArgs e)
        {
            CargarTipoPlanilla();
            EnabledTool(true);
            dgIngresos.Columns[0].ReadOnly = true;
            dgIngresos.Columns[1].ReadOnly = true;
            dgIngresos.Columns[9].ReadOnly = true;
            dgIngresos.Columns[10].ReadOnly = true;
            dgIngresos.Columns[11].ReadOnly = true;
            dgIngresos.Columns[12].ReadOnly = true;

            GroupBox2.Enabled = true;
            tstActuallizar.Enabled = false;
        }

        private void tstActuallizar_Click(object sender, EventArgs e)
        {
            EnabledTool(false);
            dgIngresos.ReadOnly = false;
            GroupBox1.Enabled = false;
        }

        private void tstSave_Click(object sender, EventArgs e)
        {
        }

        private void tstCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se Pérdera la info", "Mensaje", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                _accion = AccionEnum.Eliminar;
                EnabledTool(true);
                CargaRubroIngreso();
                dgIngresos.ReadOnly = true;
                GroupBox1.Enabled = true;
            }
        }

        private void CargarTipoPlanilla()
        {
            cbPlanilla1.DisplayMember = "dplanilla";
            cbPlanilla1.ValueMember = "ncom_3p";

            cbplanilla.DisplayMember = "dplanilla";
            cbplanilla.ValueMember = "ncom_3p";
        }

        private void EnabledTool(bool enabled)
        {
            tstActuallizar.Enabled = enabled;
            tstSave.Enabled = !enabled;
            tstCancelar.Enabled = !enabled;
        }

        private void CargaRubroIngreso()
        {
            if (Convert.ToString(cbplanilla.SelectedValue) != string.Empty)
            {
                if (_accion != AccionEnum.Nuevo | _accion != AccionEnum.Modificar)
                {
                }
            }
            swedicion = dgIngresos.Rows.Count > -1;
        }

        public void Rubros(string _codigo, string _nombre)
        {
            dgIngresos.Focus();

            var tabla = (DataTable)dgIngresos.DataSource;
            var fila = tabla.NewRow();

            fila[1] = _codigo;
            fila[2] = _nombre;
            fila[0] = FormateaNumeroaCadena(Convert.ToString(tabla.Rows.Count + 1), 3, '0');
            fila[3] = string.Empty;
            fila[4] = string.Empty;
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
            tabla.Columns[4].AllowDBNull = true;
            tabla.Columns[5].AllowDBNull = true;
            tabla.Columns[6].AllowDBNull = true;

            tabla.AcceptChanges();

            dgIngresos.DataSource = tabla;
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

        private void btnfiltrar_Click(object sender, EventArgs e)
        {
            CargaRubroIngreso();
        }

        private void btnGenerarHojaTrab_Click(object sender, EventArgs e)
        {
        }

        private void cbplanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tabla = new DataTable();
            TextBox3.Text = tabla.Rows[0][1] + "\r" + tabla.Rows[0][2] + "\r" + tabla.Rows[0][3];
        }
    }
}
