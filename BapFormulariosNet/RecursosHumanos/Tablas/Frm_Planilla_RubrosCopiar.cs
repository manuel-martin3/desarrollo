using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using BapFormulariosNet.Codigo;

namespace BapFormulariosNet.RecursosHumanos.Tablas
{
    public partial class Frm_Planilla_RubrosCopiar : Form
    {
        private bool sw_Load = true;
        public string _LpPlanillaOrigen = string.Empty;
        public string _LpPlanillaDestino = string.Empty;
        public string _LpTipoRubro = string.Empty;

        public Frm_Planilla_RubrosCopiar()
        {
            InitializeComponent();

            Load += Frm_Planilla_RubrosCopiar_Load;
            KeyDown += Frm_Planilla_RubrosCopiar_KeyDown;
            Activated += Frm_Planilla_RubrosCopiar_Activated;
        }

        private void Frm_Planilla_RubrosCopiar_Activated(object sender, EventArgs e)
        {
            if (sw_Load)
            {
                cmbtiporubro.ValueMember = "codigo";
                cmbtiporubro.DisplayMember = "descripcion";
                var BLI = new tb_plla_tab0100BL();
                var BEI = new tb_plla_tab0100();

                BEI.norden = 2;
                cmbtiporubro.DataSource = BLI.gspTbPllaTipoRubro(VariablesPublicas.EmpresaID.ToString(), BEI).Tables[0];

                cmbtipoplanillaorigen.ValueMember = "tipoplla";
                cmbtipoplanillaorigen.DisplayMember = "tipopllaname";
                var BL = new tb_plla_tipoplanillaBL();
                var BE = new tb_plla_tipoplanilla();

                BE.norden = 1;
                BE.ver_blanco = 0;
                cmbtipoplanillaorigen.DataSource = BL.GetAll_Consulta(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                cmbtipoplanilladestino.ValueMember = "tipoplla";
                cmbtipoplanilladestino.DisplayMember = "tipopllaname";
                cmbtipoplanilladestino.DataSource = BL.GetAll_Consulta(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (_LpTipoRubro.Trim().Length > 0)
                {
                    cmbtiporubro.SelectedValue = _LpTipoRubro;
                }
                if (_LpPlanillaOrigen.Trim().Length > 0)
                {
                    cmbtipoplanillaorigen.SelectedValue = _LpTipoRubro;
                }
                if (_LpPlanillaDestino.Trim().Length > 0)
                {
                    cmbtipoplanilladestino.SelectedValue = _LpPlanillaDestino;
                }
                U_RefrescaControles();
                sw_Load = false;
            }
        }
        private void Frm_Planilla_RubrosCopiar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnsalir_Click(sender, e);
            }
        }
        private void Frm_Planilla_RubrosCopiar_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            WindowState = FormWindowState.Normal;
        }

        private void U_RefrescaControles()
        {
            cmbtipoplanilladestino.Enabled = _LpPlanillaDestino.Trim().Length == 0;
            cmbtipoplanillaorigen.Enabled = _LpPlanillaOrigen.Trim().Length == 0;
            cmbtiporubro.Enabled = _LpTipoRubro.Trim().Length == 0;
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btncopiar_Click(object sender, EventArgs e)
        {
            if (cmbtipoplanillaorigen.SelectedValue == null)
            {
                MessageBox.Show("Seleccione Tipo de Planilla Origen", "Mensaje del Sistema");
                return;
            }
            if (cmbtipoplanillaorigen.SelectedValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show("Seleccione Tipo de Planilla Origen", "Mensaje del Sistema");
                return;
            }
            if (cmbtipoplanilladestino.SelectedValue == null)
            {
                MessageBox.Show("Seleccione Tipo de Planilla Destino", "Mensaje del Sistema");
                return;
            }
            if (cmbtipoplanilladestino.SelectedValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show("Seleccione Tipo de Planilla Destino", "Mensaje del Sistema");
                return;
            }
            if (cmbtiporubro.SelectedValue == null)
            {
                MessageBox.Show("Seleccione Tipo de Rubro", "Mensaje del Sistema");
                return;
            }
            if (cmbtiporubro.SelectedValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show("Seleccione Tipo de Rubro", "Mensaje del Sistema");
                return;
            }

            var message = "Desea copiar  Rubros desde planilla: " + cmbtipoplanillaorigen.Text + "\r" + "A: " + cmbtipoplanilladestino.Text + "...?" + "\r" + "\r" + "Los rubros existentes serán reemplazados";
            var caption = "Mensaje del Sistema";
            var buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                var BL = new tb_plla_rubrosingresoBL();
                var BE = new tb_plla_rubrosingreso();

                BE.tipoplanillaorigen = cmbtipoplanillaorigen.SelectedValue.ToString();
                BE.tipoplanilladestino = cmbtipoplanilladestino.SelectedValue.ToString();
                BE.tiporubro = cmbtiporubro.SelectedValue.ToString();
                if (!BL.Copiar(VariablesPublicas.EmpresaID, BE))
                {
                    Frm_Class.ShowError(BL.Sql_Error, this);
                }
                else
                {
                    MessageBox.Show("Rubros copiados satisfactoriamente", "Mensaje del Sistema");
                    btnsalir_Click(sender, e);
                }
            }
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (btnsalir.Focused | btncopiar.Focused)
                {
                }
                else
                {
                    SendKeys.Send("\t");
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
