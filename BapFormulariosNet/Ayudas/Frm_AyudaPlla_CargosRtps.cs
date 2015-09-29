using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.Ayudas
{
    public partial class Frm_AyudaPlla_CargosRtps : Form
    {
        public delegate void PasaTipoSubDiarioDelegate(string codigo, string nombre);
        public PasaTipoSubDiarioDelegate _PasaDelegado;
        public string _Ocurrencias = string.Empty;
        private bool Inicializa = true;

        public Frm_AyudaPlla_CargosRtps()
        {
            InitializeComponent();

            Load += Frm_AyudaPlla_CargosRtps_Load;
            KeyDown += Frm_AyudaPlla_CargosRtps_KeyDown;
            Activated += Frm_AyudaPlla_CargosRtps_Activated;

            txtdescripcion.GotFocus += new System.EventHandler(txtdescripcion_GotFocus);
        }

        private void Frm_AyudaPlla_CargosRtps_Activated(object sender, EventArgs e)
        {
            if (Inicializa)
            {
                if (_Ocurrencias.Trim().Length > 0)
                {
                    chkdescripcion.Checked = true;
                    chkdescripcion.Enabled = true;
                    txtdescripcion.Text = _Ocurrencias;
                    txtdescripcion.Enabled = true;
                }
                else
                {
                    txtdescripcion.Enabled = false;
                    chkdescripcion.Checked = false;
                }
                Inicializa = false;
                FormBorderStyle = FormBorderStyle.Fixed3D;
                Filtrar();
                if (dgProveedor.RowCount > 0)
                {
                    dgProveedor.Focus();
                    dgProveedor.BeginEdit(true);
                }
            }
        }
        private void Frm_AyudaPlla_CargosRtps_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void Frm_AyudaPlla_CargosRtps_Load(object sender, EventArgs e)
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Filtrar()
        {
            var sorted = default(SortOrder);
            var xnomcolumna = string.Empty;
            if ((dgProveedor.SortedColumn != null))
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
            dgProveedor.DataSource = null;
            dgProveedor.AutoGenerateColumns = false;
            var BL = new tb_plla_pdt_tabla10BL();
            var BE = new tb_plla_pdt_tabla10();
            BE.nomlike1 = xpalabra1;
            BE.nomlike2 = xpalabra2;
            BE.nomlike3 = xpalabra3;
            BE.norden = 1;
            BE.ver_blanco = 0;
            dgProveedor.DataSource = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
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
                dgProveedor.Sort(dgProveedor.Columns["ocupaid"], System.ComponentModel.ListSortDirection.Ascending);
            }
            VariablesPublicas.PintaEncabezados(dgProveedor);
        }

        public void u_RefrescaControles()
        {
            txtdescripcion.Enabled = chkdescripcion.Checked;
        }

        public void u_SeleccionaRegistro()
        {
            if ((dgProveedor.CurrentRow != null))
            {
                if ((_PasaDelegado != null))
                {
                    _PasaDelegado(dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["ocupaid"].Value.ToString(), dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["ocupaname"].Value.ToString());
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
            if ((dgProveedor.CurrentRow != null))
            {
                dgProveedor.Rows[dgProveedor.CurrentRow.Index].Selected = true;
            }
        }

        private void dgProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            u_SeleccionaRegistro();
        }
    }
}
