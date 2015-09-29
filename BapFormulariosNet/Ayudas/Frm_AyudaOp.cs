using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using bapFunciones;

namespace BapFormulariosNet.Ayudas
{
    public partial class Frm_AyudaOp : Form
    {
        public delegate void pasaPedidoDelegado(string codigo);
        private bool sw_Load = true;
        private string j_String = string.Empty;
        public string Cliente = string.Empty;
        public pasaPedidoDelegado PasaPedido;
        public string Pedido = string.Empty;
        public string Programa = string.Empty;
        public string _Pedido = string.Empty;

        public Frm_AyudaOp()
        {
            InitializeComponent();
            Load += Frm_AyudaOp_Load;
            KeyDown += Frm_AyudaOp_KeyDown;
            Activated += Frm_AyudaOp_Activated;
        }

        private void Frm_AyudaOp_Activated(object sender, EventArgs e)
        {
            if (sw_Load)
            {
                CargaData();
                if (GridExaminar.Rows.Count > 0)
                {
                    GridExaminar.Focus();
                    GridExaminar.BeginEdit(true);
                }
                else
                {
                    btnCerrar.Focus();
                }
                sw_Load = false;
            }
        }
        private void Frm_AyudaOp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void Frm_AyudaOp_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MinimizeBox = false;
            MaximizeBox = false;
            var xmes = VariablesPublicas.PADL(DateTime.Now.Month.ToString(), 2, "0");
            var xperiodo = DateTime.Now.Year.ToString();
            if (DateTime.Now.Month == 1)
            {
                xmes = "12";
                xperiodo = (DateTime.Now.Year - 1).ToString();
            }
            else
            {
                xmes = VariablesPublicas.PADL((DateTime.Now.Month - 1).ToString(), 2, "0");
            }
            Fechaini.Value = Convert.ToDateTime("01/" + xmes + "/" + xperiodo);
            if (_Pedido.Trim().Length > 0)
            {
                chkPedido.Checked = true;
                txtPedido.Text = _Pedido;
            }
            U_RefrescaControles();
        }

        public void CargaData()
        {
            var xfecha1 = string.Empty;
            var xOPLIKE = string.Empty;
            var xcodcli = string.Empty;
            var xfecha2 = string.Empty;
            if (txtRuc.Enabled)
            {
                xcodcli = txtRuc.Text;
            }
            if (Fechaini.Enabled)
            {
                xfecha1 = VariablesPublicas.DTOS(Fechaini.Value);
            }
            if (Fechafin.Enabled)
            {
                xfecha2 = VariablesPublicas.DTOS(Fechafin.Value);
            }
            if (txtOp.Enabled)
            {
                xOPLIKE = txtOp.Text;
            }
            var xpedido = string.Empty;
            if (txtPedido.Enabled)
            {
                xpedido = txtPedido.Text;
            }
        }
        public void SeleccionaRegistro()
        {
            if ((GridExaminar.CurrentRow != null))
            {
                PasaPedido(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells[0].Value.ToString());
                Close();
            }
        }
        public void U_RefrescaControles()
        {
            txtPedido.Enabled = chkPedido.Checked;
            txtCtactename.Enabled = false;
            txtRuc.Enabled = chkRuc.Checked;
            txtOp.Enabled = chkOp.Checked;
            Fechaini.Enabled = rbFecha.Checked;
            Fechafin.Enabled = rbFecha.Checked;
            txtOp.Enabled = chkOp.Checked;
        }

        private void GridExaminar_DoubleClick(object sender, EventArgs e)
        {
            SeleccionaRegistro();
        }
        private void GridExaminar_KeyDown(object sender, KeyEventArgs e)
        {
            var k = default(Keys);
            k = e.KeyCode;
            switch (k)
            {
                case Keys.Enter:
                    SeleccionaRegistro();
                    break;
                default:
                    break;
            }
        }
        private void GridExaminar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionaRegistro();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            btnRefrescar.Enabled = false;
            CargaData();
            btnRefrescar.Enabled = true;
        }
        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            SeleccionaRegistro();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            PasaPedido(string.Empty);
            Close();
        }

        private void rbFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_RefrescaControles();
            }
        }
        private void rbNumero_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_RefrescaControles();
            }
        }

        private void txtPedido_LostFocus(object sender, System.EventArgs e)
        {
            if (!sw_Load)
            {
                if (txtPedido.Text.Trim().Length > 0)
                {
                    txtPedido.Text = VariablesPublicas.PADL(txtPedido.Text.Trim(), 10, "0");
                }
            }
        }
        private void txtOp_LostFocus(object sender, System.EventArgs e)
        {
            if (!sw_Load)
            {
                if (txtOp.Text.Trim().Length > 0)
                {
                    txtOp.Text = txtOp.Text.Trim();
                }
            }
        }
        private void txtRuc_GotFocus(object sender, System.EventArgs e)
        {
            j_String = txtRuc.Text;
        }
        private void txtRuc_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_String == txtRuc.Text) & !sw_Load)
            {
                ValidaDetalle();
            }
        }
        public void ValidaDetalle()
        {
            if (txtRuc.Text.Trim().Length > 0)
            {
            }
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (keyData == Keys.Enter & !btnSeleccion.Focused & !btnCerrar.Focused & !btnRefrescar.Focused)
            {
                SendKeys.Send("\t");
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtRuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
            }
        }
        private void AyudaProveedor()
        {
        }
        private void RecibeProveedor(string codigo, string nombre, string direccion)
        {
            if (codigo.Trim().Length > 0)
            {
                txtRuc.Text = codigo;
                txtCtactename.Text = nombre;
                CargaData();
            }
        }

        private void chkRuc_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_RefrescaControles();
            }
        }
        private void chkOp_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_RefrescaControles();
            }
        }
        private void chkPedido_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_RefrescaControles();
            }
        }
    }
}
