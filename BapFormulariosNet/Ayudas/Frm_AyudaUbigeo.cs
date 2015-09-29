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
    public partial class Frm_AyudaUbigeo : Form
    {
        public delegate void PasaCuentaDelegate(string ubigeo, string dpto, string prov, string dist);
        public PasaCuentaDelegate _PasaRegistro;
        private bool sw_Load = true;
        private DataTable tabla;
        private string j_String = string.Empty;
        private bool sw_Select = false;

        public Frm_AyudaUbigeo()
        {
            InitializeComponent();
            KeyDown += Frm_AyudaUbigeo_KeyDown;
            Load += Frm_AyudaUbigeo_Load;
            Activated += Frm_AyudaUbigeo_Activated;

            txtNombre.LostFocus += new System.EventHandler(txtNombre_LostFocus);
            txtNombre.GotFocus += new System.EventHandler(txtNombre_GotFocus);
        }

        private void Frm_AyudaUbigeo_Activated(object sender, EventArgs e)
        {
            if (sw_Load)
            {
                sw_Load = false;
                U_CargaDatos();
            }
        }
        private void Frm_AyudaUbigeo_Load(object sender, EventArgs e)
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            U_RefrescaControles();
        }
        private void Frm_AyudaUbigeo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCerrar_Click(sender, e);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            _PasaRegistro(string.Empty, string.Empty, string.Empty, string.Empty);
            Close();
        }
        private void Examinar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                U_SeleccionaRegistros();
            }
        }
        private void Examinar_DoubleClick(object sender, EventArgs e)
        {
            U_SeleccionaRegistros();
        }

        public void U_CargaDatos()
        {
            var xpalabra1 = string.Empty;
            var xpalabra2 = string.Empty;
            var xpalabra3 = string.Empty;
            if (txtNombre.Enabled)
            {
                xpalabra1 = VariablesPublicas.Palabras(txtNombre.Text.Trim(), 1);
                xpalabra2 = VariablesPublicas.Palabras(txtNombre.Text.Trim(), 2);
                xpalabra3 = VariablesPublicas.Palabras(txtNombre.Text.Trim(), 3);
            }
            var BL = new ubigeoBL();
            var BE = new tb_ubigeo();

            BE.nombrelike1 = xpalabra1;
            BE.nombrelike2 = xpalabra2;
            BE.nombrelike3 = xpalabra3;
            tabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

            btnRefrescar.Enabled = true;
            var sorted = default(SortOrder);
            var xnomcolumna = string.Empty;
            if ((Examinar.SortedColumn != null))
            {
                xnomcolumna = Examinar.Columns[Examinar.SortedColumn.Index].Name;
                sorted = Examinar.SortOrder;
            }
            Examinar.AutoGenerateColumns = false;
            Examinar.DataSource = tabla;
            Examinar.AllowUserToResizeRows = false;
            if (xnomcolumna.Trim().Length > 0)
            {
                if (sorted == SortOrder.Ascending)
                {
                    Examinar.Sort(Examinar.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Ascending);
                }
                else
                {
                    Examinar.Sort(Examinar.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Descending);
                }
            }
            else
            {
                Examinar.Sort(Examinar.Columns["ubige"], System.ComponentModel.ListSortDirection.Ascending);
            }
            if (Examinar.Rows.Count > 0)
            {
                Examinar.CurrentCell = Examinar.Rows[0].Cells["depar"];
                Examinar.Focus();
                Examinar.BeginEdit(true);
            }
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            U_SeleccionaRegistros();
        }
        public void U_SeleccionaRegistros()
        {
            if ((Examinar.CurrentRow != null))
            {
                sw_Select = true;
                _PasaRegistro(Examinar.Rows[Examinar.CurrentRow.Index].Cells["ubige"].Value.ToString(), Examinar.Rows[Examinar.CurrentRow.Index].Cells["depar"].Value.ToString(), Examinar.Rows[Examinar.CurrentRow.Index].Cells["provi"].Value.ToString(), Examinar.Rows[Examinar.CurrentRow.Index].Cells["distr"].Value.ToString());
                Close();
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            U_CargaDatos();
        }

        public void U_RefrescaControles()
        {
            Examinar.ReadOnly = true;
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (keyData == Keys.Enter & !btnSeleccion.Focused)
            {
                if ((Examinar.CurrentCell != null))
                {
                    if (Examinar.Focused)
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

        private void txtNombre_GotFocus(object sender, System.EventArgs e)
        {
            j_String = txtNombre.Text;
        }
        private void txtNombre_LostFocus(object sender, System.EventArgs e)
        {
            if (!sw_Load & !(j_String == txtNombre.Text))
            {
                U_CargaDatos();
            }
        }
    }
}
