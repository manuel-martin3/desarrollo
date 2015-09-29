using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.RecursosHumanos
{
    public partial class Frm_RegistroTrabajadoresAutocontrol : plantilla
    {
        private DataTable tablaclientes;
        private DataTable tmpcursor;
        private string j_xFiltronom = string.Empty;
        private string j_xfiltrocod = string.Empty;
        private string j_xfiltronumdoc = string.Empty;
        private bool Sw_LOad = true;
        private int u_n_opsel = 0;
        private int lc_cont;

        public Frm_RegistroTrabajadoresAutocontrol()
        {
            InitializeComponent();

            FormClosing += Frm_RegistroTrabajadoresAutocontrol_FormClosing;
            Load += Frm_RegistroTrabajadoresAutocontrol_Load;
            Activated += Frm_RegistroTrabajadoresAutocontrol_Activated;

            txtfiltronombre.GotFocus += new System.EventHandler(txtfiltronombre_GotFocus);
            txtfiltronombre.LostFocus += new System.EventHandler(txtfiltronombre_LostFocus);

            txtfiltrocodigo.GotFocus += new System.EventHandler(txtfiltrocodigo_GotFocus);
            txtfiltrocodigo.LostFocus += new System.EventHandler(txtfiltrocodigo_LostFocus);

            txtfiltronumdoc.GotFocus += new System.EventHandler(txtfiltronumdoc_GotFocus);
            txtfiltronumdoc.LostFocus += new System.EventHandler(txtfiltronumdoc_LostFocus);
        }

        private void Llenar_cboTipoPlanillaFil()
        {
            var BL = new tb_plla_tipoplanillaBL();
            var BE = new tb_plla_tipoplanilla();
            BE.norden = 1;
            BE.ver_blanco = 0;
            cmbfiltrotipoplanilla.ValueMember = "tipoplla";
            cmbfiltrotipoplanilla.DisplayMember = "tipopllaname";
            cmbfiltrotipoplanilla.DataSource = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
        }

        private void Llenar_cboEstadTrabjFil()
        {
            cmbfiltroestado.ValueMember = "cele";
            cmbfiltroestado.DisplayMember = "descripcion";
            var BL = new tb_plla_fichatrabajadoresBL();
            var BE = new tb_plla_fichatrabajadores();
            cmbfiltroestado.DataSource = BL.GetAll_EstadoTrabj(VariablesPublicas.EmpresaID, BE).Tables[0];
        }

        private void Frm_RegistroTrabajadoresAutocontrol_Activated(object sender, EventArgs e)
        {
            if (Sw_LOad)
            {
                Llenar_cboTipoPlanillaFil();

                Llenar_cboEstadTrabjFil();

                U_RefrescaControles();
                CargaDatos();
                U_RefrescaControles();
                Sw_LOad = false;
            }
        }
        private void Frm_RegistroTrabajadoresAutocontrol_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            WindowState = FormWindowState.Normal;
        }

        private void CargaDatos()
        {
            var xtipoplanilla = string.Empty;
            var xestadotrab = string.Empty;
            var xtipolocal = string.Empty;
            if (cmbfiltroestado.Enabled)
            {
                if ((cmbfiltroestado.SelectedValue != null))
                {
                    xestadotrab = cmbfiltroestado.SelectedValue.ToString();
                }
            }
            if (cmbfiltrotipolocal.Enabled)
            {
                if ((cmbfiltrotipolocal.SelectedValue != null))
                {
                    xtipolocal = cmbfiltrotipolocal.SelectedValue.ToString();
                }
            }

            if (cmbfiltrotipoplanilla.Enabled)
            {
                if ((cmbfiltrotipoplanilla.SelectedValue != null))
                {
                    xtipoplanilla = cmbfiltrotipoplanilla.SelectedValue.ToString();
                }
            }

            var xxxswload = Sw_LOad;
            Sw_LOad = true;
            var BLES = new tb_plla_establecimientosBL();
            var BEES = new tb_plla_establecimientos();
            BEES.empresaid = VariablesPublicas.EmpresaID;
            BEES.norden = 1;
            BEES.ver_blanco = 0;
            cmbfiltrotipolocal.DisplayMember = "estabname";
            cmbfiltrotipolocal.ValueMember = "estabid";
            cmbfiltrotipolocal.DataSource = BLES.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BEES).Tables[0];

            Sw_LOad = xxxswload;

            var nposcolumnasortear = 0;
            var PrvSotOrder = default(SortOrder);
            var xnumdoclike = txtfiltronumdoc.Text;
            var xcodlike = txtfiltrocodigo.Text;
            var zordenado = false;
            var xcodcliente = "..";
            var xpalabra1 = string.Empty;
            var xpalabra2 = string.Empty;
            var xpalabra3 = string.Empty;
            if (txtfiltronombre.Text.Trim().Length > 0)
            {
                xpalabra1 = VariablesPublicas.Palabras(txtfiltronombre.Text, 1);
                xpalabra2 = VariablesPublicas.Palabras(txtfiltronombre.Text, 2);
                xpalabra3 = VariablesPublicas.Palabras(txtfiltronombre.Text, 3);
            }
            if ((Examinar.CurrentRow != null))
            {
                xcodcliente = Examinar.Rows[Examinar.CurrentRow.Index].Cells["fichaid"].Value.ToString();
            }
            if ((Examinar.SortedColumn != null))
            {
                nposcolumnasortear = Examinar.SortedColumn.Index;
                PrvSotOrder = Examinar.SortOrder;
                zordenado = true;
            }
            var nestadotrab = 1;
            if (txtfiltronumdoc.Enabled)
            {
                xnumdoclike = txtfiltronumdoc.Text;
            }
            if (chkvercesados.Checked)
            {
                nestadotrab = 0;
            }
            if (txtfiltrocodigo.Enabled)
            {
                xcodlike = txtfiltrocodigo.Text;
            }
            var BL = new tb_plla_fichatrabajadoresBL();
            var BE = new tb_plla_fichatrabajadores();
            BE.Fichaid = xcodlike;
            BE.Nrodni = xnumdoclike;
            BE.Norden = 1;
            BE.Nomlike1 = xpalabra1;
            BE.Nomlike2 = xpalabra2;
            BE.Nomlike3 = xpalabra3;
            BE.Estado_trabaj = nestadotrab;
            BE.Tipoplla = xtipoplanilla;
            BE.Situtrabid = xestadotrab;
            BE.Establec = xtipolocal;
            tablaclientes = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];

            lbltotaltrab.Text = string.Empty;
            if (BL.Sql_Error.Length == 0)
            {
                lbltotaltrab.Text = "Total Trabajadores " + tablaclientes.Rows.Count.ToString();
            }
            Examinar.AutoGenerateColumns = false;
            Examinar.DataSource = tablaclientes;

            VariablesPublicas.PintaEncabezados(Examinar);

            if (zordenado)
            {
                if (PrvSotOrder == SortOrder.Ascending)
                {
                    Examinar.Sort(Examinar.Columns[nposcolumnasortear], System.ComponentModel.ListSortDirection.Ascending);
                }
                else
                {
                    Examinar.Sort(Examinar.Columns[nposcolumnasortear], System.ComponentModel.ListSortDirection.Descending);
                }
            }
            else
            {
                Examinar.Sort(Examinar.Columns["nombrelargo"], System.ComponentModel.ListSortDirection.Ascending);
            }
            if (Examinar.CurrentRow == null)
            {
                if (Examinar.RowCount > 0)
                {
                    Examinar.CurrentCell = Examinar.Rows[0].Cells["fichaid"];
                }
            }
            for (lc_cont = 0; lc_cont <= Examinar.Rows.Count - 1; lc_cont++)
            {
                if (Examinar.Rows[lc_cont].Cells["fichaid"].Value.ToString() == xcodcliente.ToString())
                {
                    Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["fichaid"];
                    break;
                }
            }
        }

        private void U_RefrescaControles()
        {
            cmbfiltroestado.Enabled = chkestado.Checked;
            cmbfiltrotipolocal.Enabled = chkfiltrotipolocal.Checked;
            cmbfiltrotipoplanilla.Enabled = u_n_opsel == 0 & chkfiltroplanilla.Checked;
        }

        private void Frm_RegistroTrabajadoresAutocontrol_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (u_n_opsel > 0)
            {
                MessageBox.Show("Finalice edición para cerrar formulario", "Mensaje del Sistema");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void btnfiltro_Click(object sender, EventArgs e)
        {
            CargaDatos();
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if ((Examinar.CurrentCell != null))
                {
                    SendKeys.Send("\t");
                    return true;
                }
                else
                {
                    if (TabControl1.SelectedIndex == 1)
                    {
                    }
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtfiltronombre_GotFocus(object sender, System.EventArgs e)
        {
            j_xFiltronom = txtfiltronombre.Text;
        }
        private void txtfiltronombre_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_xFiltronom == txtfiltronombre.Text))
            {
                CargaDatos();
            }
        }
        private void txtfiltrocodigo_GotFocus(object sender, System.EventArgs e)
        {
            j_xfiltrocod = txtfiltrocodigo.Text;
        }
        private void txtfiltrocodigo_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_xfiltrocod == txtfiltrocodigo.Text))
            {
                CargaDatos();
            }
        }
        private void txtfiltronumdoc_GotFocus(object sender, System.EventArgs e)
        {
            j_xfiltronumdoc = txtfiltronumdoc.Text;
        }
        private void txtfiltronumdoc_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_xfiltronumdoc == txtfiltronumdoc.Text))
            {
                CargaDatos();
            }
        }

        public void U_pINTAR()
        {
            if (1 == 1)
            {
                var LC_NCOLUMNA = 0;
                for (lc_cont = 0; lc_cont <= Examinar.RowCount - 1; lc_cont++)
                {
                    if (Examinar.Rows[lc_cont].Cells["activo"].Value.ToString() == "0")
                    {
                        for (LC_NCOLUMNA = 0; LC_NCOLUMNA <= Examinar.ColumnCount - 1; LC_NCOLUMNA++)
                        {
                            Examinar.Rows[lc_cont].DefaultCellStyle.BackColor = lblanulado.BackColor;
                            Examinar.Rows[lc_cont].DefaultCellStyle.ForeColor = lblanulado.ForeColor;
                        }
                    }
                    else
                    {
                        if (Convert.ToBoolean(Examinar.Rows[lc_cont].Cells["autocontrol"].Value))
                        {
                            for (LC_NCOLUMNA = 0; LC_NCOLUMNA <= Examinar.ColumnCount - 1; LC_NCOLUMNA++)
                            {
                                Examinar.Rows[lc_cont].DefaultCellStyle.BackColor = Label1.BackColor;
                                Examinar.Rows[lc_cont].DefaultCellStyle.ForeColor = Label1.ForeColor;
                            }
                        }
                        else
                        {
                            for (LC_NCOLUMNA = 0; LC_NCOLUMNA <= Examinar.ColumnCount - 1; LC_NCOLUMNA++)
                            {
                                Examinar.Rows[lc_cont].DefaultCellStyle.BackColor = Color.White;
                                Examinar.Rows[lc_cont].DefaultCellStyle.ForeColor = Color.Black;
                            }
                        }
                    }
                }
            }
        }

        private void Examinar_Paint(object sender, PaintEventArgs e)
        {
            U_pINTAR();
        }

        private void chkestado_CheckedChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad)
            {
                U_RefrescaControles();
            }
        }

        private void cmbfiltroestado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad)
            {
                CargaDatos();
            }
        }

        private void cmbfiltrotipolocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad & cmbfiltroestado.Enabled)
            {
                CargaDatos();
            }
        }

        private void chkfiltrotipolocal_CheckedChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad)
            {
                U_RefrescaControles();
                CargaDatos();
            }
        }

        private void btnAutocontrol_Click(object sender, EventArgs e)
        {
            if ((Examinar.CurrentRow != null))
            {
                tmpcursor = null;
                var nindice = 0;
                for (nindice = 0; nindice <= tablaclientes.Rows.Count - 1; nindice++)
                {
                    if (tablaclientes.Rows[nindice]["fichaid"] == Examinar.Rows[Examinar.CurrentRow.Index].Cells["fichaid"].Value)
                    {
                        tablaclientes.Rows[nindice]["autocontrol"] = !Convert.ToBoolean(tablaclientes.Rows[nindice]["autocontrol"]);
                        tmpcursor = tablaclientes.Clone();
                        tmpcursor.ImportRow(tablaclientes.Rows[nindice]);
                        tmpcursor.AcceptChanges();
                        break;
                    }
                }
                if (!VariablesPublicas.EofTable(tmpcursor))
                {
                    var BL = new tb_plla_fichatrabajadoresBL();
                    if (BL.Insert_Update(VariablesPublicas.EmpresaID, tmpcursor, null, null))
                    {
                        Examinar.Rows[Examinar.CurrentRow.Index].Cells["autocontrol"].Value = tmpcursor.Rows[0]["autocontrol"];
                    }
                }
            }
        }

        private void chkfiltroplanilla_CheckedChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad)
            {
                U_RefrescaControles();
                CargaDatos();
            }
        }

        private void cmbfiltrotipoplanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad & cmbfiltrotipoplanilla.Enabled)
            {
                CargaDatos();
            }
        }
    }
}
