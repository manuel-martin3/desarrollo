using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.Ayudas
{
    public partial class Frm_AyudaRubroDescuentoPlla : Form
    {
        public delegate void PasaCentroCostoDelegate(string codigo, string nombre, string TipoPlanilla, string nomplanilla, string ccia);
        public PasaCentroCostoDelegate _PasaDelegado;
        public string _Planilla = string.Empty;
        public string _LPdescartacciatiporubro = string.Empty;
        private bool Inicializa = true;
        private bool swSelecciona = false;

        public Frm_AyudaRubroDescuentoPlla()
        {
            InitializeComponent();

            Load += Frm_AyudaRubroDescuentoPlla_Load;
            KeyDown += Frm_AyudaRubroDescuentoPlla_KeyDown;
            Activated += Frm_AyudaRubroDescuentoPlla_Activated;

            txtdescripcion.GotFocus += new System.EventHandler(txtdescripcion_GotFocus);
        }

        private void llenar_cboTipoPlla()
        {
            try
            {
                cmbtipoplanilla.DataSource = NewMethodTPlla();
                cmbtipoplanilla.DisplayMember = "Value";
                cmbtipoplanilla.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethodTPlla()
        {
            var BL = new tb_plla_tipoplanillaBL();
            var BE = new tb_plla_tipoplanilla();

            BE.norden = 2;
            BE.consolidar = 0;
            var table = BL.GetAll_ConsultaTipo(VariablesPublicas.EmpresaID, BE).Tables[0];
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

        private void Frm_AyudaRubroDescuentoPlla_Activated(object sender, EventArgs e)
        {
            if (Inicializa)
            {
                Inicializa = false;

                llenar_cboTipoPlla();
                if (_Planilla.Trim().Length > 0)
                {
                    chktipoplanilla.Checked = true;
                    cmbtipoplanilla.SelectedValue = _Planilla;
                }
                u_RefrescaControles();
                Filtrar();
                txtdescripcion.Enabled = false;
                chkdescripcion.Checked = false;

                if (dgProveedor.RowCount > 0)
                {
                    dgProveedor.Focus();
                    dgProveedor.BeginEdit(true);
                }
            }
        }
        private void Frm_AyudaRubroDescuentoPlla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
            {
                Close();
            }
        }
        private void Frm_AyudaRubroDescuentoPlla_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            u_RefrescaControles();
        }

        private void chkdescripcion_CheckedChanged(object sender, EventArgs e)
        {
            if (!Inicializa)
            {
                u_RefrescaControles();
            }
        }

        private void dgProveedor_DoubleClick(object sender, EventArgs e)
        {
            u_SeleccionaRegistro();
        }

        private void txtdescripcion_GotFocus(object sender, System.EventArgs e)
        {
            txtdescripcion.SelectAll();
        }
        private void txtdescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Filtrar();
            }
        }

        private void Filtrar()
        {
            var sorted = default(SortOrder);
            var xnomcolumna = string.Empty;
            if (dgProveedor.SortedColumn != null)
            {
                xnomcolumna = dgProveedor.Columns[dgProveedor.SortedColumn.Index].Name;
                sorted = dgProveedor.SortOrder;
            }

            var xpalabra1 = string.Empty;
            var xpalabra2 = string.Empty;
            var xpalabra3 = string.Empty;
            if (txtdescripcion.Enabled)
            {
                xpalabra1 = VariablesPublicas.Palabras(txtdescripcion.Text, 1);
                xpalabra2 = VariablesPublicas.Palabras(txtdescripcion.Text, 2);
                xpalabra3 = VariablesPublicas.Palabras(txtdescripcion.Text, 3);
            }
            var xtipoplla = string.Empty;
            if (_Planilla.Trim().Length == 0)
            {
                if (cmbtipoplanilla.Enabled)
                {
                    xtipoplla = cmbtipoplanilla.SelectedValue.ToString();
                }
            }
            else
            {
                xtipoplla = _Planilla;
            }

            dgProveedor.DataSource = null;
            dgProveedor.AutoGenerateColumns = false;
            var BL = new tb_plla_rubrosdescuentosBL();
            var BE = new tb_plla_rubrosdescuentos();

            BE.tipoplla = xtipoplla;
            BE.descriplike1 = xpalabra1;
            BE.descriplike2 = xpalabra2;
            BE.descriplike3 = xpalabra3;
            BE.LPdescartacciatiporubro = _LPdescartacciatiporubro;
            dgProveedor.DataSource = BL.GetAll_CONSULTA_PLLA(VariablesPublicas.EmpresaID, BE).Tables[0];
            if (xnomcolumna.Trim().Length > 0)
            {
                if (sorted == SortOrder.Ascending)
                {
                    dgProveedor.Sort(dgProveedor.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Ascending);
                }
                else
                {
                    dgProveedor.Sort(dgProveedor.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Descending);
                }
            }
            else
            {
                dgProveedor.Sort(dgProveedor.Columns["rubroid"], System.ComponentModel.ListSortDirection.Ascending);
            }
            VariablesPublicas.PintaEncabezados(dgProveedor);
        }

        public void u_RefrescaControles()
        {
            txttpla.Enabled = false;
            cmbtipoplanilla.Enabled = chktipoplanilla.Checked;
            txtdescripcion.Enabled = chkdescripcion.Checked;
            dgProveedor.Columns["tipoplla"].Visible = !chktipoplanilla.Checked;
            dgProveedor.Columns["tipopllaname"].Visible = !chktipoplanilla.Checked;
        }
        public void u_SeleccionaRegistro()
        {
            if ((dgProveedor.CurrentRow != null) & !swSelecciona)
            {
                if ((_PasaDelegado != null))
                {
                    swSelecciona = true;
                    _PasaDelegado(dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["rubroid"].Value.ToString(), dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["rubroname"].Value.ToString(), dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["tipoplla"].Value.ToString(), dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["tipopllaname"].Value.ToString(), VariablesPublicas.EmpresaID);
                }
                Close();
            }
        }

        private void dgProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                u_SeleccionaRegistro();
            }
        }

        private void btnrefrescar_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            u_SeleccionaRegistro();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgProveedor_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgProveedor.CurrentRow != null)
            {
                dgProveedor.Rows[dgProveedor.CurrentRow.Index].Selected = true;
            }
        }

        private void dgProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            u_SeleccionaRegistro();
        }

        private void chktipoplanilla_CheckedChanged(object sender, EventArgs e)
        {
            if (!Inicializa)
            {
                u_RefrescaControles();
                Filtrar();
            }
        }

        private void cmbtipoplanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbtipoplanilla.SelectedValue != null)
            {
                txttpla.Text = cmbtipoplanilla.SelectedValue.ToString();
            }
            if (!Inicializa)
            {
                Filtrar();
            }
        }
    }
}
