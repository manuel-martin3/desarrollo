using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.Ayudas
{
    public partial class Frm_CentrocostoTesoreria : Form
    {
        public delegate void PasaCentroCostoTesoreriaDelegate(string codigo, string nombre);
        public PasaCentroCostoTesoreriaDelegate PasaCCTesoreria;
        public string _ClaseCuenta = string.Empty;
        public bool _SeleccionaGenerico = false;
        private bool Inicializa = true;

        public Frm_CentrocostoTesoreria()
        {
            InitializeComponent();

            Load += Frm_CentrocostoTesoreria_Load;
            KeyDown += Frm_CentrocostoTesoreria_KeyDown;
            Activated += Frm_CentrocostoTesoreria_Activated;
        }

        private void Frm_CentrocostoTesoreria_Activated(object sender, EventArgs e)
        {
            if (Inicializa)
            {
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                Inicializa = false;
                Filtrar();
                chkcodigolike.Checked = true;
                txtcodigolike.Enabled = true;

                txtcodigolike.Focus();
            }
        }
        private void Frm_CentrocostoTesoreria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void Frm_CentrocostoTesoreria_Load(object sender, EventArgs e)
        {
            if (_ClaseCuenta.Trim().Length > 0)
            {
                chkclasecuenta.Checked = true;
                txtcuenta.Text = _ClaseCuenta;
            }
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            u_RefrescaControles();
        }

        private void dgProveedor_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            u_SeleccionaRegistro();
        }
        private void dgProveedor_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            U_pINTAR();
        }
        private void dgProveedor_DoubleClick(object sender, EventArgs e)
        {
            u_SeleccionaRegistro();
        }

        private void txtBusqueda_GotFocus(object sender, System.EventArgs e)
        {
            txtdescriplike.SelectAll();
        }

        private void txtdescriplike_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Filtrar();
            }
        }

        private void Filtrar()
        {
            var sorted = default(System.Windows.Forms.SortOrder);
            var xnomcolumna = string.Empty;
            if ((dgProveedor.SortedColumn != null))
            {
                xnomcolumna = dgProveedor.Columns[dgProveedor.SortedColumn.Index].Name;
                sorted = dgProveedor.SortOrder;
            }
            var nestado = string.Empty;
            if (rbactivo1.Checked)
            {
                nestado = "0";
            }
            if (rbactivo2.Checked)
            {
                nestado = "1";
            }
            if (rbactivo3.Checked)
            {
                nestado = "2";
            }
            var xpalabra1 = string.Empty;
            var xpalabra2 = string.Empty;
            var xpalabra3 = string.Empty;
            if (txtdescriplike.Enabled)
            {
                xpalabra1 = VariablesPublicas.Palabras(txtdescriplike.Text, 1);
            }
            if (txtdescriplike.Enabled)
            {
                xpalabra2 = VariablesPublicas.Palabras(txtdescriplike.Text, 2);
            }
            if (txtdescriplike.Enabled)
            {
                xpalabra3 = VariablesPublicas.Palabras(txtdescriplike.Text, 3);
            }
            var xcodlike = string.Empty;
            if (txtcodigolike.Enabled)
            {
                xcodlike = txtcodigolike.Text;
            }
            var xclasecuenta = string.Empty;
            if (txtcuenta.Enabled)
            {
                xclasecuenta = txtcuenta.Text;
            }

            dgProveedor.DataSource = null;
            dgProveedor.AutoGenerateColumns = false;

            try
            {
                var BL = new centrocostoBL();
                var BE = new tb_centrocosto();

                BE.cencosid = xcodlike;
                BE.cencosname = xpalabra1;
                BE.cencosdivi = xclasecuenta;
                dgProveedor.DataSource = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
                dgProveedor.Sort(dgProveedor.Columns["cencosid"], System.ComponentModel.ListSortDirection.Ascending);
            }
            VariablesPublicas.PintaEncabezados(dgProveedor);
            U_pINTAR();
        }
        public void u_RefrescaControles()
        {
            txttotregistrosanaliticos.Enabled = false;
            txtcuenta.Enabled = chkclasecuenta.Checked;
            txtdescriplike.Enabled = chkdescriplike.Checked;
            txtcodigolike.Enabled = chkcodigolike.Checked;
        }
        public void u_SeleccionaRegistro()
        {
            if ((dgProveedor.CurrentRow != null))
            {
                if ((PasaCCTesoreria != null))
                {
                    if (Convert.ToBoolean(dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["cencosanalitica"].Value) == false)
                    {
                        if (_SeleccionaGenerico)
                        {
                            PasaCCTesoreria(dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["cencosid"].Value.ToString(), dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["cencosname"].Value.ToString());
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Solo puede seleccionar costos analíticos", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        PasaCCTesoreria(dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["cencosid"].Value.ToString(), dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["cencosname"].Value.ToString());
                        Close();
                    }
                }
            }
        }

        private void dgProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                u_SeleccionaRegistro();
            }
        }

        private void chkcodigolike_CheckedChanged(object sender, EventArgs e)
        {
            if (!Inicializa)
            {
                u_RefrescaControles();
                Filtrar();
            }
        }
        private void chkdescriplike_CheckedChanged(object sender, EventArgs e)
        {
            if (!Inicializa)
            {
                u_RefrescaControles();
            }
        }

        private void btnrefrescar_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        public void U_pINTAR()
        {
            var ntotanaliticos = 0;
            if (1 == 1)
            {
                var LC_CONT = 0;
                var LC_NCOLUMNA = (dynamic )null;
                for (LC_CONT = 0; LC_CONT <= dgProveedor.RowCount - 1; LC_CONT++)
                {
                    if (dgProveedor.Rows[LC_CONT].Cells["status"].Value.ToString() == "1")
                    {
                        for (LC_NCOLUMNA = 0; LC_NCOLUMNA <= dgProveedor.ColumnCount - 1; LC_NCOLUMNA++)
                        {
                            dgProveedor.Rows[LC_CONT].DefaultCellStyle.BackColor = lblregseleccionado.BackColor;
                            dgProveedor.Rows[LC_CONT].DefaultCellStyle.ForeColor = lblregseleccionado.ForeColor;
                        }
                    }
                    else
                    {
                        if (Convert.ToBoolean(dgProveedor.Rows[LC_CONT].Cells["cencosanalitica"].Value) == false)
                        {
                            ntotanaliticos += 1;

                            for (LC_NCOLUMNA = 0; LC_NCOLUMNA <= dgProveedor.ColumnCount - 1; LC_NCOLUMNA++)
                            {
                                dgProveedor.Rows[LC_CONT].DefaultCellStyle.BackColor = Color.FromArgb(208, 218, 223);
                                dgProveedor.Rows[LC_CONT].DefaultCellStyle.Font = new Font("Thahoma", 7, FontStyle.Bold);
                            }
                        }
                        else
                        {
                            for (LC_NCOLUMNA = 0; LC_NCOLUMNA <= dgProveedor.ColumnCount - 1; LC_NCOLUMNA++)
                            {
                                dgProveedor.Rows[LC_CONT].DefaultCellStyle.BackColor = Color.FromArgb(232, 232, 255);
                            }
                        }
                    }
                }
            }
            if (ntotanaliticos > 0)
            {
                txttotregistrosanaliticos.Text = ntotanaliticos.ToString("###,###");
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            u_SeleccionaRegistro();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgProveedor_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((dgProveedor.CurrentRow != null))
            {
                dgProveedor.Rows[dgProveedor.CurrentRow.Index].Selected = true;
            }
        }

        private void txtcodigolike_TextChanged(object sender, EventArgs e)
        {
            if (!Inicializa)
            {
                Filtrar();
                txtcodigolike.Focus();
            }
        }

        private void chkclasecuenta_CheckedChanged(object sender, EventArgs e)
        {
            u_RefrescaControles();
        }

        private void dgProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            u_SeleccionaRegistro();
        }
    }
}
