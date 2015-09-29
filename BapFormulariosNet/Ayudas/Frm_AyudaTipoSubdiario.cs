using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.Ayudas
{
    public partial class Frm_AyudaTipoSubdiario : Form
    {
        public delegate void PasaTipoSubDiarioDelegate(string codigo, string nombre, string Sigla);

        public PasaTipoSubDiarioDelegate _PasaDelegado;
        public bool _VerTipoVoucher = true;
        public bool _conta = true;
        public bool _tesor = true;
        public bool _letras = false;
        private bool Inicializa = true;

        public Frm_AyudaTipoSubdiario()
        {
            InitializeComponent();

            Load += Frm_AyudaTipoSubdiario_Load;
            KeyDown += Frm_AyudaTipoSubdiario_KeyDown;
            Activated += Frm_AyudaTipoSubdiario_Activated;

            cboFiltro.SelectedIndex = 0;
        }

        private void Frm_AyudaTipoSubdiario_Activated(object sender, EventArgs e)
        {
            if (Inicializa)
            {
                Inicializa = false;
                FormBorderStyle = FormBorderStyle.Sizable;
                Filtrar();

                if (dgProveedor.RowCount > 0)
                {
                    dgProveedor.Focus();
                    dgProveedor.BeginEdit(true);
                }
            }
        }
        private void Frm_AyudaTipoSubdiario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void Frm_AyudaTipoSubdiario_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            u_RefrescaControles();
        }

        private void chkdescripcion_CheckedChanged(object sender, EventArgs e)
        {
            if (!Inicializa)
            {
                Filtrar();
            }
        }

        private void dgProveedor_DoubleClick(object sender, EventArgs e)
        {
            u_SeleccionaRegistro();
        }

        private void txtBusqueda_GotFocus(object sender, System.EventArgs e)
        {
            txtdescripcion.SelectAll();
        }

        private void txtdescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Filtrar();
            }
        }

        private void LlenarGrilla()
        {
            try
            {
                var BL = new tb_co_tipodiarioBL();
                var BE = new tb_co_tipodiario();

                if (_conta & _tesor)
                {
                    BE.contabilidad = true;
                }
                else
                {
                    if (_conta & !_tesor)
                    {
                        BE.contabilidad = true;
                    }
                    else
                    {
                        if (_letras == true)
                        {
                            BE.canjeletra = true;
                        }
                        else
                        {
                            BE.tesoreria = true;
                        }
                    }
                }
                switch (cboFiltro.SelectedItem.ToString())
                {
                    case "Código":
                        BE.diarioid = txtdescripcion.Text.Trim().ToUpper();
                        break;
                    case "Descripcción":
                        BE.diarioname = txtdescripcion.Text.Trim().ToUpper();
                        break;
                    default:
                        BE.diarioid = txtdescripcion.Text.Trim().ToUpper();
                        break;
                }
                BE.perianio = VariablesPublicas.perianio;
                dgProveedor.DataSource = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Filtrar()
        {
            var sorted = default(SortOrder);
            var xnomcolumna = string.Empty;
            if ((dgProveedor.SortedColumn != null))
            {
                xnomcolumna = dgProveedor.Columns[dgProveedor.SortedColumn.Index].Name;
                sorted = dgProveedor.SortOrder;
            }

            dgProveedor.DataSource = null;
            dgProveedor.AutoGenerateColumns = false;
            LlenarGrilla();
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
                dgProveedor.Sort(dgProveedor.Columns["diarioid"], System.ComponentModel.ListSortDirection.Ascending);
            }
        }

        public void u_RefrescaControles()
        {
        }
        public void u_SeleccionaRegistro()
        {
            if ((dgProveedor.CurrentRow != null))
            {
                if ((_PasaDelegado != null))
                {
                    _PasaDelegado(dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["diarioid"].Value.ToString(), dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["diarioname"].Value.ToString(), dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["sigla"].Value.ToString());
                }
                Close();
            }
        }

        private void dgProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                u_SeleccionaRegistro();
            }
        }

        private void btnrefrescar_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
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

        private void dgProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            u_SeleccionaRegistro();
        }
    }
}
