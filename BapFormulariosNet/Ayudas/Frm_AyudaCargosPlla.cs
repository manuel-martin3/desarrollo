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
using BapFormulariosNet;
using BapFormulariosNet.Seguridadlog;
using BapFormulariosNet.Ayudas;
using BapFormulariosNet.Codigo;

namespace BapFormulariosNet.Ayudas
{
    public partial class Frm_AyudaCargosPlla : Form
    {
        public delegate void PasaCentroCostoDelegate(string codigo, string nombre, string codcosto, string nomcosto);
        public PasaCentroCostoDelegate _PasaDelegado;
        public string _ccosto = "";
        //private DataTable Tabla;
        DataTable tmpTabla;
        private bool Inicializa = true;
        string j_ccosto = "";

        public Frm_AyudaCargosPlla()
        {
            InitializeComponent();

            Load += Frm_AyudaCargosPlla_Load;
            KeyDown += Frm_AyudaCargosPlla_KeyDown;
            Activated += Frm_AyudaCargosPlla_Activated;

            txtccosto.GotFocus += new System.EventHandler(txtccosto_GotFocus);
            txtccosto.LostFocus += new System.EventHandler(txtccosto_LostFocus);
            txtdescripcion.GotFocus += new System.EventHandler(txtdescripcion_GotFocus);
        }

        private void Frm_AyudaCargosPlla_Activated(object sender, EventArgs e)
        {
            if (Inicializa)
            {
                Inicializa = false;
                if (_ccosto.Trim().Length > 0)
                {
                    chkccosto.Checked = true;
                    txtccosto.Text = _ccosto;
                    ValidaCcosto();
                }
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
        private void Frm_AyudaCargosPlla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void Frm_AyudaCargosPlla_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            u_RefrescaControles();
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

        private void Filtrar()
        {
            SortOrder sorted = default(SortOrder);
            string xnomcolumna = "";
            if ((dgProveedor.SortedColumn != null))
            {
                xnomcolumna = dgProveedor.Columns[dgProveedor.SortedColumn.Index].Name;
                sorted = dgProveedor.SortOrder;
            }

            string xpalabra1 = "";
            string xpalabra2 = "";
            string xpalabra3 = "";
            if (txtdescripcion.Enabled)
            {
                xpalabra1 = VariablesPublicas.Palabras(txtdescripcion.Text, 1);
                xpalabra2 = VariablesPublicas.Palabras(txtdescripcion.Text, 2);
                xpalabra3 = VariablesPublicas.Palabras(txtdescripcion.Text, 3);
            }
            string xcosto = "";
            if (txtccosto.Enabled)
            {
                xcosto = txtccosto.Text;
            }
            dgProveedor.DataSource = null;
            dgProveedor.AutoGenerateColumns = false;
            tb_plla_cargosBL BL = new tb_plla_cargosBL();
            tb_plla_cargos BE = new tb_plla_cargos();
            BE.cencosid = xcosto;
            BE.nomlike1 = xpalabra1;
            BE.nomlike2 = xpalabra2;
            BE.nomlike3 = xpalabra3;
            dgProveedor.DataSource = BL.GetAll_CONSULTA_Cargos(VariablesPublicas.EmpresaID, BE).Tables[0];
            //dgProveedor.DataSource = oCapa.CaeSoft_GetCargos(GlobalVars.GetInstance.Company, xcosto, "", xpalabra1, xpalabra2, xpalabra3);
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
        }

        public void u_RefrescaControles()
        {
            txtccosto.Enabled = chkccosto.Checked;
            txtdescripcion.Enabled = chkdescripcion.Checked;
            dgProveedor.Columns["cencosid"].Visible = !chkccosto.Checked;
            dgProveedor.Columns["cencosname"].Visible = !chkccosto.Checked;
        }
        
        public void u_SeleccionaRegistro()
        {
            if ((dgProveedor.CurrentRow != null))
            {
                if ((_PasaDelegado != null))
                {
                    _PasaDelegado(dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["cargoid"].Value.ToString(), 
                                  dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["cargoname"].Value.ToString(), 
                                  dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["cencosid"].Value.ToString(), 
                                  dgProveedor.Rows[dgProveedor.CurrentCell.RowIndex].Cells["cencosname"].Value.ToString());
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

        private void chkdescripcion_CheckedChanged(object sender, EventArgs e)
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

        private void txtccosto_GotFocus(object sender, System.EventArgs e)
        {
            j_ccosto = txtccosto.Text;
        }
        private void txtccosto_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_ccosto == txtccosto.Text) & !Inicializa)
            {
                ValidaCcosto();
            }
        }
        public void ValidaCcosto()
        {
            if (txtccosto.Text.Trim().Length == 0)
            {
                txtdcosto.Text = "";
            }
            else
            {
                txtccosto.Text = VariablesPublicas.PADL(txtccosto.Text.Trim(), txtccosto.MaxLength, "0");
                centrocostoBL BL = new centrocostoBL();
                tb_centrocosto BE = new tb_centrocosto();
                BE.cencosid = txtccosto.Text.Trim();
                BE.norden = 1;
                BE.ver_blanco = 0;
                tmpTabla = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
                //tmpTabla = oCapa.CaeSoft_GetAllAyudaCentrodeCosto(GlobalVars.GetInstance.Company, txtccosto.Text, 1, "", "", "", "");
                if (BL.Sql_Error.Length == 0)
                {
                    if (tmpTabla.Rows.Count > 0)
                    {
                        txtccosto.Text = tmpTabla.Rows[0]["cencosid"].ToString().Trim();
                        txtdcosto.Text = tmpTabla.Rows[0]["cencosname"].ToString().Trim();
                    }
                    else
                    {
                        txtccosto.Text = j_ccosto;
                    }
                }
                else
                {
                    txtccosto.Text = j_ccosto;
                }
            }
            u_RefrescaControles();
        }
        private void txtccosto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaCcosto();
            }
        }
        public void AyudaCcosto()
        {
            Frm_AyudaCCostoPlla oform = new Frm_AyudaCCostoPlla();
            oform._PasaDelegado = RecibeCCOSTO;
            oform.Owner = this;
            oform.ShowDialog();
        }
        public void RecibeCCOSTO(string Codigo, string nombre)
        {
            txtccosto.Text = Codigo.Trim();
            txtdcosto.Text = nombre.Trim();
            u_RefrescaControles();
        }

        private void chkccosto_CheckedChanged(object sender, EventArgs e)
        {
            if (!Inicializa)
            {
                u_RefrescaControles();
            }
        }

        private void dgProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            u_SeleccionaRegistro();
        }
    }
}
