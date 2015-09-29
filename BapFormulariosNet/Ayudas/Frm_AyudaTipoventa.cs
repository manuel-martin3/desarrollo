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
    public partial class Frm_AyudaTipoventa : Form
    {
        public delegate void PasaTipocompraDelegate(string codigo, string nombre);
        public PasaTipocompraDelegate PasaTipoventa;
        public bool _SEL_CTA_GENERICA = false;
        public string _CUENTA_MAYOR = string.Empty;
        public bool _activaCta = false;
        private DataTable tabla;

        private Boolean Sw_LOad = true;

        public Frm_AyudaTipoventa()
        {
            InitializeComponent();
            cboCriterioBusqueda.SelectedIndex = 0;
            llenar_Tipocompra();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            llenar_Tipocompra();
        }

        private void llenar_Tipocompra()
        {
            try
            {
                var BL = new tb_co_tipoventasBL();
                var BE = new tb_co_tipoventas();

                switch (cboCriterioBusqueda.SelectedItem.ToString())
                {
                    case "Código":
                        BE.tipoid = txtCadenaBuscar.Text.Trim().ToUpper();
                        break;
                    case "Descripción":
                        BE.tiponame = txtCadenaBuscar.Text.Trim().ToUpper();
                        break;
                    default:
                        BE.tipoid = txtCadenaBuscar.Text.Trim().ToUpper();
                        break;
                }
                Sw_LOad = false;
                if (GridExaminar.RowCount > 0)
                {
                    GridExaminar.Focus();
                    GridExaminar.BeginEdit(true);
                }
                GridExaminar.AutoGenerateColumns = false;
                GridExaminar.DataSource = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void U_CargaDatos()
        {
            var sorted = default(System.Windows.Forms.SortOrder);
            var xnomcolumna = string.Empty;
            if (GridExaminar.SortedColumn != null)
            {
                xnomcolumna = GridExaminar.Columns[GridExaminar.SortedColumn.Index].Name;
                sorted = GridExaminar.SortOrder;
            }
            GridExaminar.AutoGenerateColumns = false;
            GridExaminar.DataSource = tabla;
            GridExaminar.AllowUserToResizeRows = false;
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
                GridExaminar.Sort(GridExaminar.Columns["tipoid"], System.ComponentModel.ListSortDirection.Ascending);
            }
            if (GridExaminar.Rows.Count > 0)
            {
                GridExaminar.CurrentCell = GridExaminar.Rows[0].Cells["tipoid"];
                GridExaminar.Focus();
                GridExaminar.BeginEdit(true);
            }
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            U_SeleccionaRegistros();
        }

        public void U_SeleccionaRegistros()
        {
            if ((GridExaminar.CurrentRow != null))
            {
                PasaTipoventa(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["tipoid"].Value.ToString(), GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["tiponame"].Value.ToString());
                Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            PasaTipoventa(string.Empty, string.Empty);
            Close();
        }

        private void GridExaminar_DoubleClick(object sender, EventArgs e)
        {
            U_SeleccionaRegistros();
        }

        private void GridExaminar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                U_SeleccionaRegistros();
            }
        }

        private void Frm_AyudaTipocompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCerrar_Click(sender, e);
            }
        }

        private void cboCriterioBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCadenaBuscar.Focus();
            }
        }

        private void txtCadenaBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                llenar_Tipocompra();
                btnBuscar.Focus();
            }
        }

        private void txtCadenaBuscar_TextChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad)
            {
            }
        }
    }
}
