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
    public partial class Frm_AyudaTallasClientes : Form
    {
        public delegate void PasaCodTalla(string codigo, string descripcion);
        public PasaCodTalla _PasaValor;
        public string _CodCliente = string.Empty;
        public string _LPDESCRIPCION = string.Empty;
        private bool sw_load = true;

        private DataTable PCGCURSOR = new DataTable();

        public Frm_AyudaTallasClientes()
        {
            InitializeComponent();
            KeyUp += Frm_AyudaTallasClientes_KeyUp;
            Load += Frm_AyudaTallasClientes_Load;
            Activated += Frm_AyudaTallasClientes_Activated;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Frm_AyudaTallasClientes_Activated(object sender, EventArgs e)
        {
            if (sw_load)
            {
                if (_CodCliente.Trim().Length > 0)
                {
                }
                u_refrescaControles();
                POnerDatos();
                if (dgAyuda.RowCount > 0)
                {
                    dgAyuda.Focus();
                    dgAyuda.BeginEdit(true);
                }
                sw_load = false;
            }
        }
        private void Frm_AyudaTallasClientes_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            KeyPreview = true;
            if (_LPDESCRIPCION.Trim().Length > 0)
            {
                chkDescrip.Checked = true;
                txtDescrip.Text = _LPDESCRIPCION;
            }
        }

        private void llenar_GridExaminar()
        {
            try
            {
                var BL = new pt_tallaBL();
                var BE = new tb_pt_talla();

                BE.coltall = txtDescrip.Text;

                PCGCURSOR = BL.GetAll_vertical(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void POnerDatos()
        {
            var xvalor = string.Empty;
            if (txtDescrip.Enabled & txtDescrip.Text.Trim().Length > 0)
            {
                xvalor = txtDescrip.Text.ToUpper();
            }
            var xcodcli = "...2";
            if (_CodCliente.Trim().Length > 0)
            {
                xcodcli = _CodCliente;
            }
            var sorted = default(SortOrder);
            var xnomcolumna = string.Empty;
            if ((dgAyuda.SortedColumn != null))
            {
                xnomcolumna = dgAyuda.Columns[dgAyuda.SortedColumn.Index].Name;
                sorted = dgAyuda.SortOrder;
            }

            llenar_GridExaminar();
            dgAyuda.AutoGenerateColumns = false;
            dgAyuda.DataSource = PCGCURSOR;
            if (xnomcolumna.Trim().Length > 0)
            {
                if (sorted == SortOrder.Ascending)
                {
                    dgAyuda.Sort(dgAyuda.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Ascending);
                }
                else
                {
                    dgAyuda.Sort(dgAyuda.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Descending);
                }
            }
            else
            {
                dgAyuda.Sort(dgAyuda.Columns["tallaidcol"], System.ComponentModel.ListSortDirection.Ascending);
            }
        }

        private void dgAyuda_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            u_SeleccionaRegistro();
        }

        private void dgAyuda_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void Frm_AyudaTallasClientes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void txtDescrip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '\r'))
            {
                POnerDatos();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            u_SeleccionaRegistro();
        }

        public void u_SeleccionaRegistro()
        {
            if ((dgAyuda.CurrentRow != null))
            {
                if ((_PasaValor != null))
                {
                    _PasaValor(dgAyuda.Rows[dgAyuda.CurrentCell.RowIndex].Cells["tallaidcol"].Value.ToString(), dgAyuda.Rows[dgAyuda.CurrentCell.RowIndex].Cells["talla"].Value.ToString());
                }

                Close();
            }
        }

        public void u_refrescaControles()
        {
            txtDescrip.Enabled = chkDescrip.Checked;
        }

        private void chkDescrip_CheckedChanged(object sender, EventArgs e)
        {
            u_refrescaControles();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            POnerDatos();
        }

        private void dgAyuda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            u_SeleccionaRegistro();
        }
    }
}
