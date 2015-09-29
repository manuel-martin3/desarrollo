using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.Ayudas
{
    public partial class Frm_AyudaUsuarios : Form
    {
        public delegate void PasaUsuariosDelegate(string Codigo, string Nombre, string Sigla, string Usuario, string Clave);

        public PasaUsuariosDelegate _PasaUsuarios;
        public string _LpNOmbreUsuario = string.Empty;

        private bool Inicializa = true;

        public Frm_AyudaUsuarios()
        {
            InitializeComponent();
            Load += Frm_AyudaUsuarios_Load;
            KeyDown += Frm_AyudaUsuarios_KeyDown;
            Activated += Frm_AyudaUsuarios_Activated;
        }

        private void Frm_AyudaUsuarios_Activated(object sender, EventArgs e)
        {
            if (Inicializa)
            {
                if (_LpNOmbreUsuario.Trim().Length > 0)
                {
                    chkdescripcion.Checked = true;
                    txtdescripcion.Text = _LpNOmbreUsuario;
                    chkdescripcion.Enabled = true;
                    txtdescripcion.Enabled = true;
                }
                else
                {
                    txtdescripcion.Enabled = false;
                    chkdescripcion.Checked = false;
                }
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
        private void Frm_AyudaUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void Frm_AyudaUsuarios_Load(object sender, EventArgs e)
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

        private void txtdescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Filtrar();
            }
        }
        private void txtBusqueda_GotFocus(object sender, System.EventArgs e)
        {
            txtdescripcion.SelectAll();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Filtrar()
        {
            var sorted = default(SortOrder);
            var nestado = true;
            if (rblistatodos.Checked)
            {
                nestado = true;
            }
            var xnomcolumna = string.Empty;
            if (dgProveedor.SortedColumn != null)
            {
                xnomcolumna = dgProveedor.Columns[dgProveedor.SortedColumn.Index].Name.ToString();
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

            dgProveedor.DataSource = null;
            dgProveedor.AutoGenerateColumns = false;

            var BL = new usuariosBL();
            var BE = new tb_usuarios();

            BE.nombr = xpalabra1;
            BE.activo = nestado;
            dgProveedor.DataSource = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
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
                dgProveedor.Sort(dgProveedor.Columns["usuar"], System.ComponentModel.ListSortDirection.Ascending);
            }
            VariablesPublicas.PintaEncabezados(dgProveedor);
        }

        public void u_RefrescaControles()
        {
            txtdescripcion.Enabled = chkdescripcion.Checked;
        }
        public void u_SeleccionaRegistro()
        {
            if (dgProveedor.CurrentRow != null)
            {
                if (_PasaUsuarios != null)
                {
                    _PasaUsuarios(dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["usuar"].Value.ToString().Trim(),
                                  dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["nombr"].Value.ToString().Trim(),
                                  dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["usuar"].Value.ToString().Trim(),
                                  dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["usuar"].Value.ToString().Trim(),
                                  dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["clave"].Value.ToString().Trim());
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

        private void dgProveedor_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgProveedor.CurrentRow != null)
            {
                dgProveedor.Rows[dgProveedor.CurrentRow.Index].Selected = true;
            }
        }

        private void rblistatodos_CheckedChanged(object sender, EventArgs e)
        {
            if (!Inicializa)
            {
                Filtrar();
            }
        }

        private void rblistaactivos_CheckedChanged(object sender, EventArgs e)
        {
            if (!Inicializa)
            {
                Filtrar();
            }
        }

        private void dgProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            u_SeleccionaRegistro();
        }
    }
}
