using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using BapFormulariosNet.Codigo;

namespace BapFormulariosNet.Ayudas
{
    public partial class Frm_PllaAyutaTrabajadores : Form
    {
        public delegate void PasaProveedorDelegateSigla(string codigo, bool zselect);
        public PasaProveedorDelegateSigla PasaProveedor;
        public string _codDetalle = string.Empty;
        public bool _Habilitar = true;
        public string _Lpccia = VariablesPublicas.EmpresaID;
        public string _LptipoPlanilla = string.Empty;
        public string _LpNombre = string.Empty;
        private bool zseleccionando = false;
        private bool sw_Load = true;
        private DataTable tabla;

        public Frm_PllaAyutaTrabajadores()
        {
            InitializeComponent();

            KeyDown += Frm_PllaAyutaTrabajadores_KeyDown;
            Load += Frm_PllaAyutaTrabajadores_Load;
            Activated += Frm_PllaAyutaTrabajadores_Activated;
        }

        private void Llenar_cboTipoPlanilla()
        {
            try
            {
                cmbtipoplanilla.DataSource = NewMethoTP();
                cmbtipoplanilla.DisplayMember = "Value";
                cmbtipoplanilla.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethoTP()
        {
            var BL = new tb_plla_tipoplanillaBL();
            var BE = new tb_plla_tipoplanilla();
            BE.norden = 1;
            BE.ver_blanco = 0;
            BE.solopdt = 0;
            var table = BL.GetAll_Consulta(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            var rows = table.Rows;

            object[] cell;
            var dic = new Dictionary<string, string>();
            var binding = new BindingSource();

            foreach (DataRow item in rows)
            {
                cell = item.ItemArray;
                dic.Add(cell[0].ToString(), cell[0].ToString() + " - " + cell[1].ToString());
                cell = null;
            }
            binding.DataSource = dic;
            return binding;
        }
        private void Frm_PllaAyutaTrabajadores_Activated(object sender, EventArgs e)
        {
            if (sw_Load)
            {
                Llenar_cboTipoPlanilla();
                if (_LptipoPlanilla.Trim().Length > 0)
                {
                    cmbtipoplanilla.SelectedValue = _LptipoPlanilla;
                }
                sw_Load = false;
                U_CargaDatos(false);
            }
        }
        private void Frm_PllaAyutaTrabajadores_Load(object sender, EventArgs e)
        {
            if (_LpNombre.Trim().Length > 0)
            {
                chknombre.Checked = true;
                txtnombre.Text = _LpNombre;
            }
            U_RefrescaControles();
        }

        private void pintar()
        {
            var i = 0;
            var j = 0;
            dynamic celdaactual = dgProveedor.CurrentCell;
            for (i = 0; i <= dgProveedor.Rows.Count - 1; i++)
            {
                if (dgProveedor["activo", i].Value.ToString() == "0")
                {
                    for (j = 0; j <= dgProveedor.ColumnCount - 1; j++)
                    {
                        dgProveedor[j, i].Style.ForeColor = lblanulado.ForeColor;
                        dgProveedor[j, i].Style.BackColor = lblanulado.BackColor;
                    }
                }
                else
                {
                    for (j = 0; j <= dgProveedor.ColumnCount - 1; j++)
                    {
                        dgProveedor[j, i].Style.ForeColor = Color.Black;
                        dgProveedor[j, i].Style.BackColor = Color.White;
                    }
                }
            }
            try
            {
                dgProveedor.CurrentCell = celdaactual;
            }
            catch (Exception ex)
            {
                if (dgProveedor.Rows.Count > 0)
                {
                    dgProveedor.CurrentCell = dgProveedor.Rows[0].Cells["fichaid"];
                }
            }
        }

        private void dgProveedor_DoubleClick(object sender, EventArgs e)
        {
            U_SeleccionaRegistros();
        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_CargaDatos(true);
            }
        }

        private void dgProveedor_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            pintar();
        }

        private void dgProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                U_SeleccionaRegistros();
            }
        }

        public void U_CargaDatos(bool nofocusgrid)
        {
            lbltotalregistros.Text = string.Empty;
            var nestado = 0;
            var xtipoplanilla = string.Empty;
            if (cmbtipoplanilla.Enabled)
            {
                if ((cmbtipoplanilla.SelectedValue != null))
                {
                    xtipoplanilla = cmbtipoplanilla.SelectedValue.ToString();
                }
            }
            if (rbtodos1.Checked)
            {
                nestado = 0;
            }
            if (rbtodos2.Checked)
            {
                nestado = 1;
            }
            if (rbtodos3.Checked)
            {
                nestado = 2;
            }
            var xpalabra1 = string.Empty;
            var xpalabra2 = string.Empty;
            var xpalabra3 = string.Empty;
            if (txtnombre.Enabled)
            {
                xpalabra1 = VariablesPublicas.Palabras(txtnombre.Text.Trim(), 1);
                xpalabra2 = VariablesPublicas.Palabras(txtnombre.Text.Trim(), 2);
                xpalabra3 = VariablesPublicas.Palabras(txtnombre.Text.Trim(), 3);
            }
            var BL = new tb_plla_fichatrabajadoresBL();
            var BE = new tb_plla_fichatrabajadores();
            BE.Norden = 1;
            BE.Nomlike1 = xpalabra1;
            BE.Nomlike2 = xpalabra2;
            BE.Nomlike3 = xpalabra3;
            BE.Estado_trabaj = nestado;
            BE.Tipoplla = xtipoplanilla;
            tabla = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
            if (BL.Sql_Error.Length > 0)
            {
                sw_Load = false;
                Frm_Class.ShowError(BL.Sql_Error, this);
            }
            else
            {
                lbltotalregistros.Text = (tabla.Rows.Count).ToString() + " Registro(s)";
                var sorted = default(SortOrder);
                var xnomcolumna = string.Empty;
                if ((dgProveedor.SortedColumn != null))
                {
                    xnomcolumna = dgProveedor.Columns[dgProveedor.SortedColumn.Index].Name;
                    sorted = dgProveedor.SortOrder;
                }
                dgProveedor.AutoGenerateColumns = false;
                dgProveedor.DataSource = tabla;
                dgProveedor.AllowUserToResizeRows = false;
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
                    dgProveedor.Sort(dgProveedor.Columns["nombrelargo"], System.ComponentModel.ListSortDirection.Ascending);
                }
                if (dgProveedor.Rows.Count > 0)
                {
                    if (nofocusgrid)
                    {
                    }
                    else
                    {
                        dgProveedor.CurrentCell = dgProveedor.Rows[0].Cells["fichaid"];
                        dgProveedor.Focus();
                        dgProveedor.BeginEdit(true);
                    }
                }
                pintar();
            }
        }

        private void rbtodos1_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_CargaDatos(false);
            }
        }

        private void rbtodos2_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_CargaDatos(false);
            }
        }

        private void rbtodos3_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_CargaDatos(false);
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            U_SeleccionaRegistros();
        }
        public void U_SeleccionaRegistros()
        {
            if ((dgProveedor.CurrentRow != null))
            {
                if (!zseleccionando)
                {
                    zseleccionando = true;
                    PasaProveedor(dgProveedor.Rows[dgProveedor.CurrentRow.Index].Cells["fichaid"].Value.ToString(), true);
                    Close();
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            PasaProveedor(string.Empty, false);
            Close();
        }

        private void btnrefrescar_Click(object sender, EventArgs e)
        {
            U_CargaDatos(false);
        }

        private void chknombre_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_RefrescaControles();
            }
        }
        public void U_RefrescaControles()
        {
            cmbtipoplanilla.Enabled = chktipoplanilla.Checked;
            txtnombre.Enabled = chknombre.Checked;
        }

        private void dgProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            U_SeleccionaRegistros();
        }

        private void Frm_PllaAyutaTrabajadores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCerrar_Click(sender, e);
            }
        }

        private void chktipoplanilla_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_RefrescaControles();
                U_CargaDatos(false);
            }
        }

        private void cmbtipoplanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_RefrescaControles();
                U_CargaDatos(false);
            }
        }
    }
}
