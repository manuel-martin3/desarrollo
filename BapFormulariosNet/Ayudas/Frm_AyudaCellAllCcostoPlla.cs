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
    public partial class Frm_AyudaCellAllCcostoPlla : Form
    {
        public delegate void pasaresultado(bool zselect, DataTable tabla);
        public pasaresultado _PasaDelegado;
        public string _Lpcciaccostodescartar = string.Empty;
        public string _LpCcia = string.Empty;
        private bool Inicializa = true;
        private bool SwSeleccion = false;
        private DataTable crsdatos;
        private int lc_contador;

        public Frm_AyudaCellAllCcostoPlla()
        {
            InitializeComponent();

            Load += Frm_AyudaCellAllCcostoPlla_Load;
            KeyDown += Frm_AyudaCellAllCcostoPlla_KeyDown;
            Activated += Frm_AyudaCellAllCcostoPlla_Activated;

            txtdescripcion.GotFocus += new System.EventHandler(txtdescripcion_GotFocus);
        }

        private void llenar_cboEmpresas()
        {
            try
            {
                var BE = new tb_empresa();

                BE.empresaid = null;
                BE.empresaname = null;

                cmbempresa.DataSource = NewMethod();
                cmbempresa.DisplayMember = "Value";
                cmbempresa.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethod()
        {
            var BL = new empresasBL();
            var BE = new tb_empresa();

            var table = BL.GetAll(BE).Tables[0];
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

        private void Frm_AyudaCellAllCcostoPlla_Activated(object sender, EventArgs e)
        {
            if (Inicializa)
            {
                Inicializa = false;

                if (_LpCcia.Trim().Length == 0)
                {
                    llenar_cboEmpresas();
                }
                else
                {
                    llenar_cboEmpresas();
                }

                u_RefrescaControles();
                Filtrar();
                txtdescripcion.Enabled = false;
                chkdescripcion.Checked = false;

                if (dgProveedor.RowCount > 0)
                {
                    dgProveedor.Focus();
                    dgProveedor.BeginEdit(true);
                }
            }
        }
        private void Frm_AyudaCellAllCcostoPlla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void Frm_AyudaCellAllCcostoPlla_Load(object sender, EventArgs e)
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
                u_RefrescaControles();
            }
        }

        private void dgProveedor_DoubleClick(object sender, EventArgs e)
        {
            u_SeleccionaRegistro();
        }

        private void txtdescripcion_GotFocus(object sender, System.EventArgs e)
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Filtrar()
        {
            var sorted = default(SortOrder);
            var xnomcolumna = string.Empty;
            if (dgProveedor.SortedColumn != null)
            {
                xnomcolumna = dgProveedor.Columns[dgProveedor.SortedColumn.Index].Name;
                sorted = dgProveedor.SortOrder;
            }

            var xpalabra1 = string.Empty;
            var xpalabra2 = string.Empty;
            var xpalabra3 = string.Empty;
            var xpalabra4 = string.Empty;
            if (txtdescripcion.Enabled)
            {
                xpalabra1 = VariablesPublicas.Palabras(txtdescripcion.Text, 1);
                xpalabra2 = VariablesPublicas.Palabras(txtdescripcion.Text, 2);
                xpalabra3 = VariablesPublicas.Palabras(txtdescripcion.Text, 3);
                xpalabra4 = VariablesPublicas.Palabras(txtdescripcion.Text, 4);
            }
            var xvmccia = "..";
            if (cmbempresa.Enabled)
            {
                if (cmbempresa.SelectedValue != null)
                {
                    xvmccia = cmbempresa.SelectedValue.ToString();
                }
            }
            dgProveedor.DataSource = null;
            dgProveedor.AutoGenerateColumns = false;

            var BL = new tb_plla_ccostogenBL();
            var BE = new tb_plla_ccostogen();

            BE.empresaid = VariablesPublicas.EmpresaID;
            BE.nomlike1 = xpalabra1;
            BE.nomlike2 = xpalabra2;
            BE.nomlike3 = xpalabra3;
            BE.ccostodescartar = _Lpcciaccostodescartar;
            crsdatos = BL.GetAll_CONSULTACCOSTO(VariablesPublicas.EmpresaID, BE).Tables[0];
            if (BL.Sql_Error.Length > 0)
            {
                Frm_Class.ShowError(BL.Sql_Error, this);
                return;
            }
            dgProveedor.DataSource = crsdatos;
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

        private void U_pINTAR()
        {
            var ntotanaliticos = 0;
            int LC_CONT;
            int LC_NCOLUMNA;
            for (LC_CONT = 0; (LC_CONT <= (dgProveedor.RowCount - 1)); LC_CONT++)
            {
                var analitica = Convert.ToBoolean(dgProveedor.Rows[LC_CONT].Cells["cencosanalitica"].Value);
                if (analitica == true)
                {
                    ntotanaliticos++;
                    for (LC_NCOLUMNA = 0; (LC_NCOLUMNA <= (dgProveedor.ColumnCount - 1)); LC_NCOLUMNA++)
                    {
                        dgProveedor.Rows[LC_CONT].DefaultCellStyle.BackColor = Color.FromArgb(232, 232, 255);
                    }
                }
                else
                {
                    for (LC_NCOLUMNA = 0; (LC_NCOLUMNA <= (dgProveedor.ColumnCount - 1)); LC_NCOLUMNA++)
                    {
                        dgProveedor.Rows[LC_CONT].DefaultCellStyle.BackColor = Color.FromArgb(208, 218, 223);
                        dgProveedor.Rows[LC_CONT].DefaultCellStyle.Font = new Font("Thahoma", 7, FontStyle.Bold);
                    }
                }
            }
            if (ntotanaliticos > 0)
            {
                lblRegistros.Text = "Total Reg.  " + ntotanaliticos.ToString("###,###");
            }
        }

        public void u_RefrescaControles()
        {
            txtpla.Enabled = false;
            chkempresa.Enabled = false;
            cmbempresa.Enabled = false;
            dgProveedor.ReadOnly = false;
            dgProveedor.Columns["seleccionar"].ReadOnly = false;
            dgProveedor.Columns["empresaid"].ReadOnly = true;
            dgProveedor.Columns["cencosid"].ReadOnly = true;
            dgProveedor.Columns["cencosname"].ReadOnly = true;
            txtdescripcion.Enabled = chkdescripcion.Checked;
        }
        public bool u_Seleccionado()
        {
            var zok = false;
            for (lc_contador = 0; lc_contador <= crsdatos.Rows.Count - 1; lc_contador++)
            {
                if (Convert.ToBoolean(crsdatos.Rows[lc_contador]["Seleccionar"]) == true)
                {
                    zok = true;
                }
            }
            return zok;
        }

        public void u_SeleccionaRegistro()
        {
            if (!u_Seleccionado())
            {
                MessageBox.Show("Seleccione al menos 1 Registro !!!", "Mensaje del Sistema");
                return;
            }
            if (dgProveedor.CurrentRow != null)
            {
                if (!SwSeleccion)
                {
                    SwSeleccion = true;
                    if (_PasaDelegado != null)
                    {
                        DataTable dtclone = null;
                        dtclone = crsdatos.Clone();
                        for (lc_contador = 0; lc_contador <= crsdatos.Rows.Count - 1; lc_contador++)
                        {
                            if (Convert.ToBoolean(crsdatos.Rows[lc_contador]["Seleccionar"]) == true & Convert.ToBoolean(crsdatos.Rows[lc_contador]["cencosanalitica"]) == true)
                            {
                                dtclone.ImportRow(crsdatos.Rows[lc_contador]);
                            }
                        }
                        dtclone.AcceptChanges();
                        _PasaDelegado(true, dtclone);
                    }
                    Close();
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

        private void btnrefrescar_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void brnSeleccionar_Click(object sender, EventArgs e)
        {
            u_SeleccionaRegistro();
        }

        private void dgProveedor_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgProveedor.CurrentRow != null)
            {
                dgProveedor.Rows[dgProveedor.CurrentRow.Index].Selected = true;
            }
        }

        private void dgProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            u_SeleccionaRegistro();
        }

        private void chkempresa_CheckedChanged(object sender, EventArgs e)
        {
            if (!Inicializa)
            {
                u_RefrescaControles();
                Filtrar();
            }
        }

        private void cmbempresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Inicializa)
            {
                Filtrar();
            }
        }
    }
}
