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
    public partial class Frm_AyudaBancos : Form
    {
        public delegate void PasaCuentaDelegate(string codigo, string nombre);
        public PasaCuentaDelegate _PasaRegistro;
        private bool sw_Load = true;
        private DataTable tabla;
        private string j_String = string.Empty;
        private bool sw_Select = false;

        public Frm_AyudaBancos()
        {
            InitializeComponent();

            KeyDown += Frm_AyudaBancos_KeyDown;
            Load += Frm_AyudaBancos_Load;
            Activated += Frm_AyudaBancos_Activated;

            txtFilter.LostFocus += new System.EventHandler(txtFilter_LostFocus);
            txtFilter.GotFocus += new System.EventHandler(txtFilter_GotFocus);

            cboFiltro.SelectedIndex = 0;
        }

        private void Frm_AyudaBancos_Activated(object sender, EventArgs e)
        {
            if (sw_Load)
            {
                sw_Load = false;
                U_CargaDatos();
            }
        }
        private void Frm_AyudaBancos_Load(object sender, EventArgs e)
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            U_RefrescaControles();
        }
        private void Frm_AyudaBancos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCerrar_Click(sender, e);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            _PasaRegistro(string.Empty, string.Empty);
            Close();
        }

        private void gridExaminar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                U_SeleccionaRegistros();
            }
        }
        private void gridExaminar_DoubleClick(object sender, EventArgs e)
        {
            U_SeleccionaRegistros();
        }

        public void U_CargaDatos()
        {
            var xpalabra1 = string.Empty;
            var xpalabra2 = string.Empty;
            var xpalabra3 = string.Empty;
            if (txtFilter.Enabled)
            {
                xpalabra1 = VariablesPublicas.Palabras(txtFilter.Text.Trim(), 1);
                xpalabra2 = VariablesPublicas.Palabras(txtFilter.Text.Trim(), 2);
                xpalabra3 = VariablesPublicas.Palabras(txtFilter.Text.Trim(), 3);
            }

            try
            {
                var BL = new tb_co_tabla03_bancoBL();
                var BE = new tb_co_tabla03_banco();

                switch (cboFiltro.SelectedItem.ToString())
                {
                    case "Nombre":
                        BE.descripcion = txtFilter.Text.Trim().ToUpper();
                        break;
                    case "Código":
                        BE.codigoid = txtFilter.Text.Trim().ToUpper();
                        break;
                    default:
                        BE.codigoid = txtFilter.Text.Trim().ToUpper();
                        break;
                }
                tabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnBuscar.Enabled = true;
            var sorted = default(SortOrder);
            var xnomcolumna = string.Empty;
            if ((gridExaminar.SortedColumn != null))
            {
                xnomcolumna = gridExaminar.Columns[gridExaminar.SortedColumn.Index].Name;
                sorted = gridExaminar.SortOrder;
            }
            gridExaminar.AutoGenerateColumns = false;
            gridExaminar.DataSource = tabla;
            gridExaminar.AllowUserToResizeRows = false;
            if (xnomcolumna.Trim().Length > 0)
            {
                if (sorted == SortOrder.Ascending)
                {
                    gridExaminar.Sort(gridExaminar.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Ascending);
                }
                else
                {
                    gridExaminar.Sort(gridExaminar.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Descending);
                }
            }
            else
            {
                gridExaminar.Sort(gridExaminar.Columns["codigoid"], System.ComponentModel.ListSortDirection.Ascending);
            }
            if (gridExaminar.Rows.Count > 0)
            {
                gridExaminar.CurrentCell = gridExaminar.Rows[0].Cells["descripcion"];
                gridExaminar.Focus();
                gridExaminar.BeginEdit(true);
            }
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            U_SeleccionaRegistros();
        }
        public void U_SeleccionaRegistros()
        {
            if ((gridExaminar.CurrentRow != null))
            {
                sw_Select = true;
                _PasaRegistro(gridExaminar.Rows[gridExaminar.CurrentRow.Index].Cells["codigoid"].Value.ToString(),
                                   gridExaminar.Rows[gridExaminar.CurrentRow.Index].Cells["descripcion"].Value.ToString());
                Close();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            U_CargaDatos();
        }

        public void U_RefrescaControles()
        {
            gridExaminar.ReadOnly = true;
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (keyData == Keys.Enter & !btnSeleccion.Focused)
            {
                if ((gridExaminar.CurrentCell != null))
                {
                    if (gridExaminar.Focused)
                    {
                        U_SeleccionaRegistros();
                        return true;
                    }
                    else
                    {
                        SendKeys.Send("\t");
                        return true;
                    }
                }
                else
                {
                    SendKeys.Send("\t");
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtFilter_GotFocus(object sender, System.EventArgs e)
        {
            j_String = txtFilter.Text;
        }
        private void txtFilter_LostFocus(object sender, System.EventArgs e)
        {
            if (!sw_Load & !(j_String == txtFilter.Text))
            {
                U_CargaDatos();
            }
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                U_CargaDatos();
                btnBuscar.Focus();
            }
        }
    }
}
