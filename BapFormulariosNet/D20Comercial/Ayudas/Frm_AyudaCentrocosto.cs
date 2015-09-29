using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using DevExpress.XtraEditors;

namespace BapFormulariosNet.D20Comercial.Ayudas
{
    public partial class Frm_AyudaCentrocosto : plantilla
    {
        public delegate void PasaCentroCostoDelegate(string codigo, string nombre, string sigla);

        #region "Fields" //-- Parámetros
        public PasaCentroCostoDelegate PasaCentroCosto;
        public string _ClaseCuenta = "";
        public bool _SeleccionaGenerico = false;
        //--- Variables
        private DataTable Tabla;
        private bool Inicializa = true;
        #endregion

        int ntotanaliticos = 0;

        public Frm_AyudaCentrocosto()
        {
            InitializeComponent();
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            //DevExpress.Skins.SkinManager.EnableFormSkins();

            txtdescriplike.GotFocus += new System.EventHandler(txtdescriplike_GotFocus);
        }

        private void Frm_AyudaCentrocosto_Activated(object sender, EventArgs e)
        {
            if (Inicializa)
            {
                Inicializa = false;
                Filtrar();
                chkcodigolike.Checked = true;
                txtcodigolike.Enabled = true;

                txtcodigolike.Focus();
            }
        }
        private void Frm_AyudaCentrocosto_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape))
            {
                Close();
            }
        }
        private void Frm_AyudaCentrocosto_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            //DevExpress.Skins.SkinManager.EnableFormSkins();

            if ((_ClaseCuenta.Trim().Length > 0))
            {
                chkclasecuenta.Checked = true;
                txtcuenta.Text = _ClaseCuenta;
            }
            u_RefrescaControles();
        }

        private void Filtrar()
        {
            SortOrder sorted = default(SortOrder);
            string xnomcolumna = "";
            if ((dgProveedor.SortedColumn != null))
            {
                xnomcolumna = dgProveedor.Columns[dgProveedor.SortedColumn.Index].Name;
                sorted = dgProveedor.SortOrder;
            }
            //string xTipoDeta = "";
            int nestado = 0;
            ntotanaliticos = 0;
            if (rbActivo.Checked)
            {
                nestado = 0;             
            }
            if (rbInactivo.Checked)
            {
                nestado = 1;
            }
            string xpalabra1 = "";
            string xpalabra2 = "";
            string xpalabra3 = "";
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
            string xcodlike = "";
            if (txtcodigolike.Enabled)
            {
                xcodlike = txtcodigolike.Text;
            }
            string xclasecuenta = "";
            if (txtcuenta.Enabled)
            {
                xclasecuenta = txtcuenta.Text;
            }

            dgProveedor.DataSource = null;
            dgProveedor.AutoGenerateColumns = false;

            centrocostoBL BL = new centrocostoBL();
            tb_centrocosto BE = new tb_centrocosto();

            BE.cencosid = xcodlike;
            BE.cencosname = xpalabra1;
            BE.cencosdivi = xclasecuenta;
            BE.status = Convert.ToBoolean(nestado);

            dgProveedor.DataSource = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            //dgProveedor.DataSource = oCapa.pag0101_consulta(GlobalVars.GetInstance.Company, "", xcodlike, 1, nestado, xpalabra1, xpalabra2, xpalabra3, xclasecuenta);
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

        private void PoneDatos()
        {

            if ((dgProveedor.CurrentRow != null))
            {
                if (dgProveedor.Rows[dgProveedor.CurrentRow.Index].Cells["status"].Value.ToString() == "0")
                {
                    rbActivo.Checked = true;
                    rbInactivo.Checked = false;
                }
                else
                {
                    rbActivo.Checked = false;
                    rbInactivo.Checked = true;
                }
            }
        }

        void u_RefrescaControles()
        {
            txttotregistrosanaliticos.Enabled = false;
            txtcuenta.Enabled = chkclasecuenta.Checked;
            txtdescriplike.Enabled = chkdescriplike.Checked;
            txtcodigolike.Enabled = chkcodigolike.Checked;
        }

        void U_pINTAR()
        {
            if ((1 == 1))
            {
                int LC_CONT;
                int LC_NCOLUMNA;
                for (LC_CONT = 0; (LC_CONT <= (dgProveedor.RowCount - 1)); LC_CONT++)
                {
                    if (dgProveedor.Rows[dgProveedor.CurrentRow.Index].Cells["status"].Value.ToString() == "1")
                    {
                        ntotanaliticos++;
                        for (LC_NCOLUMNA = 0; (LC_NCOLUMNA <= (dgProveedor.ColumnCount - 1)); LC_NCOLUMNA++)
                        {
                            dgProveedor.Rows[LC_CONT].DefaultCellStyle.BackColor = lblregseleccionado.BackColor;
                            dgProveedor.Rows[LC_CONT].DefaultCellStyle.ForeColor = lblregseleccionado.ForeColor;
                        }
                    }
                    else
                    {
                        bool analitica = Convert.ToBoolean(dgProveedor.Rows[LC_CONT].Cells["cencosanalitica"].Value);
                        if (analitica == true)
                        {
                            ntotanaliticos++;
                            for (LC_NCOLUMNA = 0; (LC_NCOLUMNA <= (dgProveedor.ColumnCount - 1)); LC_NCOLUMNA++)
                            {
                                //dgProveedor.Rows[LC_CONT].DefaultCellStyle.BackColor = lblanalitico.BackColor;
                                //dgProveedor.Rows[LC_CONT].DefaultCellStyle.ForeColor = lblanalitico.ForeColor;
                                dgProveedor.Rows[LC_CONT].DefaultCellStyle.BackColor = Color.FromArgb(232, 232, 255);
                                //dgProveedor.Rows[LC_CONT].DefaultCellStyle.BackColor = Color.FromArgb(102, 163, 210);
                                //dgProveedor.Rows[LC_CONT].DefaultCellStyle.ForeColor = Color.FromArgb(20, 20, 20);
                            }
                        }
                        else
                        {
                            ntotanaliticos++;
                            for (LC_NCOLUMNA = 0; (LC_NCOLUMNA <= (dgProveedor.ColumnCount - 1)); LC_NCOLUMNA++)
                            {
                                //dgProveedor.Rows[LC_CONT].DefaultCellStyle.BackColor = Color.White;
                                //dgProveedor.Rows[LC_CONT].DefaultCellStyle.ForeColor = Color.Black;
                                //dgProveedor.Rows[LC_CONT].DefaultCellStyle.ForeColor = Color.FromArgb(20, 20, 20);
                                //dgProveedor.Rows[LC_CONT].DefaultCellStyle.BackColor = Color.FromArgb(63, 146, 210);
                                dgProveedor.Rows[LC_CONT].DefaultCellStyle.BackColor = Color.FromArgb(208, 218, 223);                               
                                dgProveedor.Rows[LC_CONT].DefaultCellStyle.Font = new Font("Thahoma", 7, FontStyle.Bold);
                            }
                        }
                    }
                }
            }
            if ((ntotanaliticos > 0))
            {
                txttotregistrosanaliticos.Text = ntotanaliticos.ToString("###,###");
            }
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

        private void txtdescriplike_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Filtrar();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        void u_SeleccionaRegistro()
        {
            if (!(dgProveedor.CurrentRow == null))
            {
                if (!(PasaCentroCosto == null))
                {
                    //if ((dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["cencosanalitica"].Value == 0))
                    bool analitica = Convert.ToBoolean(dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["cencosanalitica"].Value);
                    if (analitica == true)
                    {
                        if (!_SeleccionaGenerico)
                        {
                            PasaCentroCosto(dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["cencosid"].Value.ToString(), dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["cencosname"].Value.ToString(), dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["cencosdivi"].Value.ToString());
                            Close();
                        }
                        else
                        {
                            XtraMessageBox.Show("Solo puede seleccionar C.Costo analíticos", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Solo puede seleccionar C.Costo analíticos", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    //{
                    //    PasaCentroCosto(dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["cencosid"].Value.ToString(), dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["cencosname"].Value.ToString(), dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["cencosdivi"].Value.ToString());
                    //    Close();
                    //}
                }
            }
        }

        private void dgProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
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

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            u_SeleccionaRegistro();
        }

        private void dgProveedor_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!(dgProveedor.CurrentRow == null))
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

        private void txtdescriplike_GotFocus(object sender, System.EventArgs e)
        {
            txtdescriplike.SelectAll();
        }

        private void dgProveedor_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void rbActivo_CheckedChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void rbInactivo_CheckedChanged(object sender, EventArgs e)
        {
            Filtrar();
        }
    }
}
