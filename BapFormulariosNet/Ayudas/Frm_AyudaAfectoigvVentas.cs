using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.Ayudas
{
    public partial class Frm_AyudaAfectoigvVentas : Form
    {
        public delegate void PasaCodigoDestino(string codigo);
        public PasaCodigoDestino _PasaValor;
        private bool sw_load = true;

        public Frm_AyudaAfectoigvVentas()
        {
            InitializeComponent();
        }

        private void Frm_AyudaAfectoigv_Activated(object sender, EventArgs e)
        {
            if (sw_load)
            {
                FormBorderStyle = FormBorderStyle.Sizable;

                POnerDatos();

                if (dgAyuda.RowCount > 0)
                {
                    dgAyuda.Focus();
                    dgAyuda.BeginEdit(true);
                }
                sw_load = false;
            }
        }

        private void Frm_AyudaAfectoigv_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            KeyPreview = true;
        }

        private void POnerDatos()
        {
            var sorted = default(SortOrder);
            var xnomcolumna = string.Empty;

            var BL = new tb_co_tributoafectoventasBL();
            var BE = new tb_co_tributoafectoventas();

            var Tipoigv = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

            dgAyuda.AutoGenerateColumns = false;
            dgAyuda.DataSource = Tipoigv;
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
                dgAyuda.Sort(dgAyuda.Columns["destinoid"], System.ComponentModel.ListSortDirection.Ascending);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgAyuda_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            u_SeleccionaRegistro();
        }

        private void dgAyuda_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void Frm_AyudaAfectoigv_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape))
            {
                Close();
            }
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            u_SeleccionaRegistro();
        }

        private void u_SeleccionaRegistro()
        {
            if (!(dgAyuda.CurrentRow == null))
            {
                if (!(_PasaValor == null))
                {
                    _PasaValor(dgAyuda.Rows[dgAyuda.CurrentCell.RowIndex].Cells["destinoid"].Value.ToString());
                }
                Close();
            }
        }

        private void btnrefrescar_Click(object sender, EventArgs e)
        {
            POnerDatos();
        }
    }
}
