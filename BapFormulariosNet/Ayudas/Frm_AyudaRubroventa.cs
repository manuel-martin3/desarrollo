using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.Ayudas
{
    public partial class Frm_AyudaRubroventa : Form
    {
        private DataTable PCGCURSOR = new DataTable();

        public delegate void PasaCodigoDocumento(string Codigo);
        public PasaCodigoDocumento _PasaValor;
        private bool sw_load = true;

        public Frm_AyudaRubroventa()
        {
            InitializeComponent();
        }

        private void Frm_AyudaRubrocompra_Activated(object sender, EventArgs e)
        {
            if (sw_load)
            {
                u_refrescaControles();
                POnerDatos();
                if ((GridExaminar.RowCount > 0))
                {
                    GridExaminar.Focus();
                    GridExaminar.BeginEdit(true);
                }
                sw_load = false;
            }
        }

        private void Frm_AyudaRubrocompra_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            KeyPreview = true;
        }

        private void POnerDatos()
        {
            var xCuenta = string.Empty;
            if (txtCuenta.Enabled)
            {
                xCuenta = txtCuenta.Text;
            }

            var xRubro = string.Empty;
            if (txtRubro.Enabled)
            {
                xRubro = txtRubro.Text;
            }

            var xDescripcion = string.Empty;
            if (txtDescripcion.Enabled)
            {
                xDescripcion = txtDescripcion.Text;
            }
            try
            {
                var BL = new tb_co_rubroventasBL();
                var BE = new tb_co_rubroventas();

                BE.rubroid = xRubro;
                BE.rubroname = xDescripcion;
                BE.cuentaid = xCuenta;
                PCGCURSOR = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if ((PCGCURSOR.Rows.Count > 0))
            {
                GridExaminar.AutoGenerateColumns = false;
                GridExaminar.DataSource = PCGCURSOR;
                CargaDatos();
                Ponedatos();
            }
            else
            {
                sw_load = false;
            }
        }
        private void CargaDatos()
        {
            var sorted = default(System.Windows.Forms.SortOrder);
            var xnomcolumna = string.Empty;
            if ((GridExaminar.SortedColumn != null))
            {
                xnomcolumna = GridExaminar.Columns[GridExaminar.SortedColumn.Index].Name;
                sorted = GridExaminar.SortOrder;
            }

            if (xnomcolumna.Trim().Length > 0)
            {
                if (sorted == SortOrder.Ascending)
                {
                    GridExaminar.Sort(GridExaminar.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Ascending);
                }
                else
                {
                    GridExaminar.Sort(GridExaminar.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Descending);
                }
            }
            else
            {
                GridExaminar.Sort(GridExaminar.Columns["rubroid"], System.ComponentModel.ListSortDirection.Ascending);
            }
        }
        private void Ponedatos()
        {
            if ((GridExaminar.CurrentRow != null))
            {
                if (GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["status"].Value.ToString() == "0")
                {
                    rbTitulo.Checked = true;
                    rbActivo.Checked = false;
                    rbBaja.Checked = false;
                }
                if (GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["status"].Value.ToString() == "1")
                {
                    rbTitulo.Checked = false;
                    rbActivo.Checked = true;
                    rbBaja.Checked = false;
                }
                if (GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["status"].Value.ToString() == "2")
                {
                    rbTitulo.Checked = false;
                    rbActivo.Checked = false;
                    rbBaja.Checked = true;
                }
            }
        }
        private void u_refrescaControles()
        {
            txtCuenta.Enabled = chkCuenta.Checked;
            txtRubro.Enabled = chkRubro.Checked;
            txtDescripcion.Enabled = chkDescripcion.Checked;
        }

        private void Frm_AyudaRubrocompra_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape))
            {
                Close();
            }
        }

        private void txtCuenta_TextChanged(object sender, EventArgs e)
        {
            if (!sw_load)
            {
                POnerDatos();
                txtCuenta.Focus();
            }
        }

        private void chkCuenta_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_load)
            {
                u_refrescaControles();
                POnerDatos();
            }
        }

        private void chkRubro_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_load)
            {
                u_refrescaControles();
                POnerDatos();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GridExaminar_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void GridExaminar_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            u_SeleccionaRegistro();
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            u_SeleccionaRegistro();
        }

        private void u_SeleccionaRegistro()
        {
            if (!(GridExaminar.CurrentRow == null))
            {
                if (!(_PasaValor == null))
                {
                    _PasaValor(GridExaminar.Rows[GridExaminar.CurrentCell.RowIndex].Cells["rubroid"].Value.ToString());
                }
                Close();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            POnerDatos();
        }

        private void GridExaminar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            u_SeleccionaRegistro();
        }

        private void GridExaminar_Paint(object sender, PaintEventArgs e)
        {
            for (var i = 0; i < GridExaminar.Rows.Count - 1; ++i)
            {
                var estado = GridExaminar.Rows[i].Cells["status"].Value.ToString();
                if (estado == "2")
                {
                    GridExaminar.Rows[i].DefaultCellStyle.ForeColor = Color.FromArgb(255, 0, 0);
                }
                if (estado == "0")
                {
                    GridExaminar.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(208, 218, 223);
                    GridExaminar.Rows[i].DefaultCellStyle.Font = new Font("Thahoma", 7, FontStyle.Bold);
                }
            }
        }

        private void GridExaminar_SelectionChanged(object sender, EventArgs e)
        {
            Ponedatos();
        }

        private void chkDescripcion_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_load)
            {
                u_refrescaControles();
            }
        }
    }
}
