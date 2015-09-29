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
    public partial class Frm_AyudaPedidoComercial : Form
    {
        public delegate void pasaPedidoFCDelegado(string codigo);
        public pasaPedidoFCDelegado PasaPedidoFC;
        private bool SwLoad = true;
        public int nOrden = 1;
        private DataTable pTabla = new DataTable();

        public Frm_AyudaPedidoComercial()
        {
            InitializeComponent();
            Load += Frm_AyudaPedidoComercial_Load;
            Activated += Frm_AyudaPedidoComercial_Activated;
        }

        private void LllenarVendedor()
        {
            try
            {
                var BE = new tb_vendedor_corporativo();

                BE.vendorid = null;
                BE.vendorname = null;

                cboVendedor.DataSource = NewMethodov();
                cboVendedor.DisplayMember = "Value";
                cboVendedor.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethodov()
        {
            var BL = new vendedor_corporativoBL();
            var BE = new tb_vendedor_corporativo();

            var table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
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

        private void LlenarGrilla()
        {
            try
            {
                var BL = new tb_cp_comercialcabBL();
                var BE = new tb_cp_comercialcab();

                if (cboVendedor.Enabled)
                {
                    if ((cboVendedor.SelectedValue != null))
                    {
                        BE.vendedorid = cboVendedor.SelectedValue.ToString();
                    }
                }
                if (Fechaini.Enabled)
                {
                }
                if (txtEstilo.Enabled)
                {
                }

                pTabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_AyudaPedidoComercial_Activated(object sender, EventArgs e)
        {
            if (SwLoad)
            {
                CargaData();
                SwLoad = false;
            }
        }
        private void Frm_AyudaPedidoComercial_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MinimizeBox = false;
            MaximizeBox = false;
            var xperiodo = DateTime.Now.Year;
            var xmes = DateTime.Now.Month;
            if (xmes - 3 >= 1 & xmes - 3 <= 12)
            {
                xmes = xmes - 3;
            }
            else
            {
                xmes = 12 - xmes;
                xperiodo = xperiodo - 1;
            }
            chkFechas.Checked = true;
            Fechaini.Value = Convert.ToDateTime("01/" + xmes.ToString() + "/" + xperiodo.ToString());
            u_Refrescacontroles();
            LllenarVendedor();
        }

        private void CargaData()
        {
            var sorted = default(SortOrder);
            var xnomcolumna = string.Empty;

            if ((GridExaminar.SortedColumn != null))
            {
                xnomcolumna = GridExaminar.Columns[GridExaminar.SortedColumn.Index].Name;
                sorted = GridExaminar.SortOrder;
            }

            LlenarGrilla();
            GridExaminar.AutoGenerateColumns = false;
            GridExaminar.DataSource = pTabla;
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
                GridExaminar.Sort(GridExaminar.Columns["fechemision"], System.ComponentModel.ListSortDirection.Descending);
            }
        }
        public void u_Refrescacontroles()
        {
            Fechaini.Enabled = chkFechas.Checked;
            Fechafin.Enabled = chkFechas.Checked;
            cboVendedor.Enabled = chkVendedor.Checked;
            txtEstilo.Enabled = chkEstilo.Checked;
        }

        private void GridExaminar_DoubleClick(object sender, EventArgs e)
        {
            seleccionaRegistros();
        }
        private void GridExaminar_KeyDown(object sender, KeyEventArgs e)
        {
            var k = default(Keys);
            k = e.KeyCode;
            switch (k)
            {
                case Keys.Enter:
                    seleccionaRegistros();
                    break;
                default:
                    break;
            }
        }
        private void GridExaminar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionaRegistros();
        }

        public void seleccionaRegistros()
        {
            if ((GridExaminar.CurrentRow != null))
            {
                PasaPedidoFC(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["asiento"].Value.ToString());
                Close();
            }
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            seleccionaRegistros();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            PasaPedidoFC(string.Empty);
            Close();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargaData();
        }

        private void chkFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (!SwLoad)
            {
                u_Refrescacontroles();
            }
        }
        private void chkVendedor_CheckedChanged(object sender, EventArgs e)
        {
            if (!SwLoad)
            {
                u_Refrescacontroles();
            }
        }
        private void chkEstilo_CheckedChanged(object sender, EventArgs e)
        {
            if (!SwLoad)
            {
                u_Refrescacontroles();
            }
        }
    }
}
