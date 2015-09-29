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
    public partial class Frm_AyudaCuentasMayor : Form
    {
        public delegate void PasaCuentaDelegate(string codigo, string nombre);
        public PasaCuentaDelegate PasaCuenta;
        public bool _SEL_CTA_GENERICA = false;
        public string _CUENTA_MAYOR = string.Empty;
        public bool _activaCta = false;
        public string _cuentaEEFF = string.Empty;
        private bool sw_Load = true;
        private DataTable tabla;
        private bool sw_Select = false;

        public Frm_AyudaCuentasMayor()
        {
            InitializeComponent();
            cboCriterioBusqueda.SelectedIndex = 0;
        }

        private void Frm_AyudaCuentas_Activated(object sender, EventArgs e)
        {
            if (sw_Load)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                sw_Load = false;
                if (_CUENTA_MAYOR.Trim().Length > 0)
                {
                    txtCadenaBuscar.Text = _CUENTA_MAYOR.Trim();
                }
                llenar_GridExaminar();

                U_CargaDatos();
            }
        }
        private void Frm_AyudaCuentas_Load(object sender, EventArgs e)
        {
            U_RefrescaControles();
        }
        private void Frm_AyudaCuentas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCerrar_Click(sender, e);
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
            if ( xnomcolumna.Trim().Length > 0 )
            {
                if ( sorted == SortOrder.Ascending )
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
                GridExaminar.Sort(GridExaminar.Columns["cuentaid"], System.ComponentModel.ListSortDirection.Ascending);
            }
            if (GridExaminar.Rows.Count > 0)
            {
                GridExaminar.CurrentCell = GridExaminar.Rows[0].Cells["cuentaid"];
                GridExaminar.Focus();
                GridExaminar.BeginEdit(true);
            }
            pintar();
        }
        private void pintar()
        {
            for (var i = 0; i < GridExaminar.Rows.Count; ++i)
            {
                var estado = Convert.ToBoolean(GridExaminar.Rows[i].Cells["escuentaanalitica"].Value);
                if (estado == true)
                {
                    GridExaminar.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(232, 232, 255);
                }
                else
                {
                    GridExaminar.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(208, 218, 223);
                    GridExaminar.Rows[i].DefaultCellStyle.Font = new Font("Thahoma", 7, FontStyle.Bold);
                }
            }
        }
        public void U_RefrescaControles()
        {
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            llenar_GridExaminar();
        }

        private void llenar_GridExaminar()
        {
            try
            {
                var BL = new tb_co_plancontableBL();
                var BE = new tb_co_plancontable();

                BE.perianio = VariablesPublicas.perianio;
                if (_cuentaEEFF == "SI")
                {
                }
                else
                {
                    BE.cuentadigito = "2";
                }
                if (txtCadenaBuscar.Text.Length > 0)
                {
                    switch (cboCriterioBusqueda.SelectedItem.ToString())
                    {
                        case "Cuenta":
                            BE.cuentaid = txtCadenaBuscar.Text.Trim().ToUpper();
                            break;
                        case "Descripción":
                            BE.cuentaname = txtCadenaBuscar.Text.Trim().ToUpper();
                            break;
                        default:
                            BE.cuentaid = txtCadenaBuscar.Text.Trim().ToUpper();
                            break;
                    }
                }
                tabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pintar();
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            U_SeleccionaRegistros();
        }

        public void U_SeleccionaRegistros()
        {
            if ((GridExaminar.CurrentRow != null))
            {
                sw_Select = true;
                PasaCuenta(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["cuentaid"].Value.ToString(), GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["cuentaname"].Value.ToString());
                Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            PasaCuenta(string.Empty, string.Empty);
            Close();
        }

        private void GridExaminar_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            pintar();
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
                llenar_GridExaminar();
                U_CargaDatos();
                btnBuscar.Focus();
            }
        }

        private void txtCadenaBuscar_TextChanged(object sender, EventArgs e)
        {
            llenar_GridExaminar();
            U_CargaDatos();
            txtCadenaBuscar.Focus();
        }
    }
}
