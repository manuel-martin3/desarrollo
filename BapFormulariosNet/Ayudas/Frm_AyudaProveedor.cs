using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.Ayudas
{
    public partial class Frm_AyudaProveedor : Form
    {
        public delegate void PasaProveedorDelegate(string xruc, string xnombre, string xdirec);

        public PasaProveedorDelegate PasaProveedor;
        public bool _LeerCombo = true;
        public string _NombreDetalle = string.Empty;

        private bool Inicializa = true;
        public string _Valores { get; set; }

        private bool Sw_LOad = true;

        public Frm_AyudaProveedor()
        {
            InitializeComponent();

            GridExaminar.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(GridExaminar_RowHeaderMouseClick);
            cboCriterioBusqueda.SelectedIndex = 0;
        }

        private void Frm_AyudaProveedor_Activated(object sender, EventArgs e)
        {
            if (Inicializa)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                Inicializa = false;
                Text = _Valores;
                txtCadenaBuscar.Focus();
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            llenar_GridExaminar();
        }
        private void txtCadenaBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                llenar_GridExaminar();
                btnbuscar.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FRMAyudaProveedores_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape))
            {
                Close();
            }
        }
        private void llenar_GridExaminar()
        {
            try
            {
                var BL = new clienteBL();
                var BE = new tb_cliente();

                switch (cboCriterioBusqueda.SelectedItem.ToString())
                {
                    case "Razón Social":
                        BE.ctactename = txtCadenaBuscar.Text.Trim().ToUpper();
                        break;
                    case "Ruc":
                        BE.nmruc = txtCadenaBuscar.Text.Trim().ToUpper();
                        break;
                    case "Código":
                        BE.ctacte = txtCadenaBuscar.Text.Trim().ToUpper();
                        break;
                    default:
                        BE.ctactename = txtCadenaBuscar.Text.Trim().ToUpper();
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
                U_pINTAR();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                GridExaminar.Sort(GridExaminar.Columns["Ctacte"], System.ComponentModel.ListSortDirection.Ascending);
            }
        }
        private void Frm_AyudaProveedor_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void U_pINTAR()
        {
            if (1 == 1)
            {
                int LC_CONT, LC_NCOLUMNA;
                for (LC_CONT = 0; LC_CONT < GridExaminar.RowCount; LC_CONT++)
                {
                    if (GridExaminar.Rows[LC_CONT].Cells["status"].Value.ToString() == "9")
                    {
                        for (LC_NCOLUMNA = 0; LC_NCOLUMNA < GridExaminar.ColumnCount; LC_NCOLUMNA++)
                        {
                            GridExaminar.Rows[LC_CONT].DefaultCellStyle.BackColor = lblregseleccionado.BackColor;
                            GridExaminar.Rows[LC_CONT].DefaultCellStyle.ForeColor = lblregseleccionado.ForeColor;
                        }
                    }
                    else
                    {
                        for (LC_NCOLUMNA = 0; LC_NCOLUMNA < GridExaminar.ColumnCount; LC_NCOLUMNA++)
                        {
                        }
                    }
                }
            }
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            u_SeleccionaRegistro();
        }
        private void GridExaminar_DoubleClick(object sender, EventArgs e)
        {
            u_SeleccionaRegistro();
        }
        private void GridExaminar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                u_SeleccionaRegistro();
            }
        }
        public void u_SeleccionaRegistro()
        {
            if ((GridExaminar.CurrentRow != null))
            {
                if ((PasaProveedor != null))
                {
                    PasaProveedor(GridExaminar.Rows[GridExaminar.CurrentCell.RowIndex].Cells["nmruc"].Value.ToString(),
                        GridExaminar.Rows[GridExaminar.CurrentCell.RowIndex].Cells["ctactename"].Value.ToString(),
                        GridExaminar.Rows[GridExaminar.CurrentCell.RowIndex].Cells["direc"].Value.ToString());
                }
                Close();
            }
        }

        private void GridExaminar_RowHeaderMouseClick(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            if (GridExaminar.CurrentRow != null)
            {
                GridExaminar.Rows[GridExaminar.CurrentRow.Index].Selected = true;
            }
        }
    }
}
