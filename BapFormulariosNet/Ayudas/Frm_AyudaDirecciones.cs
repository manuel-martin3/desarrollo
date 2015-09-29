using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.Ayudas
{
    public partial class Frm_AyudaDirecciones : Form
    {
        public delegate void PasaTipoSubDiarioDelegate(string direccion);

        public PasaTipoSubDiarioDelegate _PasaDelegado;
        public string _ctacte = string.Empty;
        public string _nmruc = string.Empty;
        public string _nombre = string.Empty;
        private bool Inicializa = true;
        public Frm_AyudaDirecciones()
        {
            Load += Frm_AyudaDirecciones_Load;
            KeyDown += Frm_AyudaDirecciones_KeyDown;
            Activated += Frm_AyudaDirecciones_Activated;

            InitializeComponent();

            txtCadenaBuscar.GotFocus += new System.EventHandler(txtCadenaBuscar_GotFocus);
        }

        private void Frm_AyudaDirecciones_Activated(object sender, EventArgs e)
        {
            if (Inicializa)
            {
                Inicializa = false;
                FormBorderStyle = FormBorderStyle.Sizable;
                Filtrar();

                if (dgProveedor.RowCount > 0)
                {
                    dgProveedor.Focus();
                    dgProveedor.BeginEdit(true);
                }
            }
        }
        private void Frm_AyudaDirecciones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void Frm_AyudaDirecciones_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            if (_ctacte.Trim().Length > 0)
            {
                txtCtacte.Text = _ctacte;
                txtRuc.Text = _nmruc;
                txtCtactename.Text = _nombre;
            }
            u_RefrescaControles();
        }

        private void dgProveedor_DoubleClick(object sender, EventArgs e)
        {
            u_SeleccionaRegistro();
        }

        private void txtCadenaBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Filtrar();
            }
        }
        private void txtCadenaBuscar_GotFocus(object sender, System.EventArgs e)
        {
            txtCadenaBuscar.SelectAll();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Filtrar()
        {
            var sorted = default(SortOrder);
            var xnomcolumna = string.Empty;
            var xctacte = string.Empty;
            xctacte = txtCtacte.Text;
            if ((dgProveedor.SortedColumn != null))
            {
                xnomcolumna = dgProveedor.Columns[dgProveedor.SortedColumn.Index].Name;
                sorted = dgProveedor.SortOrder;
            }

            var xpalabra1 = string.Empty;
            var xpalabra2 = string.Empty;
            var xpalabra3 = string.Empty;
            xpalabra1 = VariablesPublicas.Palabras(txtCadenaBuscar.Text, 1);
            xpalabra2 = VariablesPublicas.Palabras(txtCadenaBuscar.Text, 2);
            xpalabra3 = VariablesPublicas.Palabras(txtCadenaBuscar.Text, 3);

            dgProveedor.DataSource = null;
            dgProveedor.AutoGenerateColumns = false;
            try
            {
                var BL = new cliente_direcBL();
                var BE = new tb_cliente_direc();

                BE.ctacte = xctacte;
                BE.nombrelike1 = xpalabra1;
                BE.nombrelike2 = xpalabra2;
                BE.nombrelike3 = xpalabra3;
                dgProveedor.DataSource = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                dgProveedor.Sort(dgProveedor.Columns["direcdeta"], System.ComponentModel.ListSortDirection.Ascending);
            }
            VariablesPublicas.PintaEncabezados(dgProveedor);
        }

        public void u_RefrescaControles()
        {
        }

        public void u_SeleccionaRegistro()
        {
            if ((dgProveedor.CurrentRow != null))
            {
                if ((_PasaDelegado != null))
                {
                    _PasaDelegado(dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["direcdeta"].Value.ToString());
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

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            u_SeleccionaRegistro();
        }

        private void dgProveedor_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((dgProveedor.CurrentRow != null))
            {
                dgProveedor.Rows[dgProveedor.CurrentRow.Index].Selected = true;
            }
        }
    }
}
