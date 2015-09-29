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
    public partial class Frm_AyudaCuentas : plantilla
    {
        public delegate void PasaCuentaDelegate(string codigo, string nombre);
        #region "Fields"
            //Parametros
            public PasaCuentaDelegate PasaCuenta;
            public bool _SEL_CTA_GENERICA = false;
            public string _CUENTA_MAYOR = "";
            public bool _activaCta = false;
            // Variables
            bool sw_Load = true;
            DataTable tabla = new DataTable();
            DataTable tmptabla = new DataTable();
            //string j_String = "";
            //bool sw_Select = false;
	    #endregion

        public Frm_AyudaCuentas()
        {
            InitializeComponent();
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            //DevExpress.Skins.SkinManager.EnableFormSkins();

            cboCriterioBusqueda.SelectedIndex = 0;
            //llenar_GridExaminar();
        }

        private void Frm_AyudaCuentas_Activated(object sender, EventArgs e)
        {
            if (sw_Load)
            {
                sw_Load = false;
                if (_CUENTA_MAYOR.Trim().Length > 0)
                {
                    txtCadenaBuscar.Text = _CUENTA_MAYOR.Trim();
                }
                //chkcuentamayor.Checked = _activaCta & _CUENTA_MAYOR.Trim().Length > 0;
                //if (txtCadenaBuscar.Text.Trim().Length > 0)
                //{
                    tb_co_plancontableBL BL = new tb_co_plancontableBL();
                    tb_co_plancontable BE = new tb_co_plancontable();

                    BE.perianio = VariablesPublicas.perianio;

                    switch (cboCriterioBusqueda.SelectedItem.ToString())
                    {
                        case "Código":
                            BE.cuentaid = txtCadenaBuscar.Text.Trim().ToUpper();
                            break;
                        case "Descripción":
                            BE.cuentaname = txtCadenaBuscar.Text.Trim().ToUpper();
                            break;
                        default:
                            BE.cuentaid = txtCadenaBuscar.Text.Trim().ToUpper();
                            break;
                    }
                    
                    tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                    if (tmptabla.Rows.Count > 0)
                    {
                        txtCadenaBuscar.Text = tmptabla.Rows[0]["cuentaid"].ToString().Trim();
                    }
                //}
                U_CargaDatos();
            }
        }

        internal void U_CargaDatos() 
        {
            SortOrder sorted = default(SortOrder);
            string xnomcolumna = "";
            if (GridExaminar.SortedColumn != null)
            {
                xnomcolumna = GridExaminar.Columns[GridExaminar.SortedColumn.Index].Name;
                sorted = GridExaminar.SortOrder;
            }
            GridExaminar.AutoGenerateColumns = false;
            GridExaminar.DataSource = tmptabla;
            GridExaminar.AllowUserToResizeRows = false;
            if(xnomcolumna.Trim().Length > 0)
            {
                if(sorted == SortOrder.Ascending)
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
                GridExaminar.Sort(GridExaminar.Columns["cuentaid"], System.ComponentModel.ListSortDirection.Ascending);
            }
            if (GridExaminar.Rows.Count > 0)
            {
                GridExaminar.CurrentCell = GridExaminar.Rows[0].Cells["cuentaid"];
                GridExaminar.Focus();
                GridExaminar.BeginEdit(true);
            }
            pintar();
        }

        private void Frm_AyudaCuentas_Load(object sender, EventArgs e)
        {
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            //DevExpress.Skins.SkinManager.EnableFormSkins();

            U_RefrescaControles();
            VariablesPublicas.PintaEncabezados(GridExaminar);
        }

        private void pintar()
        {
            //int i = 0;
            //int j = 0;
            //dynamic celdaactual = GridExaminar.CurrentCell;
            //for (i = 0; i <= GridExaminar.Rows.Count - 1; i++)
            //{
            //    if (Convert.ToBoolean(GridExaminar["escuentaanalitica", i].Value) == false)
            //    {
            //        for (j = 0; j <= GridExaminar.ColumnCount - 1; j++)
            //        {
            //            //GridExaminar[j, i].Style.ForeColor = lblanalitica.ForeColor;
            //            //GridExaminar[j, i].Style.BackColor = lblanalitica.BackColor;
            //            GridExaminar[j, i].Style.ForeColor = Color.FromArgb(20, 20, 20);
            //            GridExaminar[j, i].Style.BackColor = Color.FromArgb(63, 146, 210);
            //        }
            //    }
            //    else
            //    {
            //        for (j = 0; j <= GridExaminar.ColumnCount - 1; j++)
            //        {
            //            //GridExaminar[j, i].Style.ForeColor = System.Drawing.Color.Black;
            //            //GridExaminar[j, i].Style.BackColor = System.Drawing.Color.White;
            //            GridExaminar[j, i].Style.ForeColor = Color.FromArgb(20, 20, 20);
            //            GridExaminar[j, i].Style.BackColor = Color.FromArgb(102, 163, 210);
            //        }
            //    }
            //}
            //try
            //{
            //    GridExaminar.CurrentCell = celdaactual;
            //}
            //catch (Exception ex)
            //{
            //    if (GridExaminar.Rows.Count > 0)
            //    {
            //        GridExaminar.CurrentCell = GridExaminar.Rows[0].Cells["cuentaid"];
            //    }
            //}

            for (int i = 0; i < GridExaminar.Rows.Count; ++i)
            {
                bool estado = Convert.ToBoolean(GridExaminar.Rows[i].Cells["escuentaanalitica"].Value);
                if (estado == true)
                {
                    //gridcentrocostos.Rows[i].DefaultCellStyle.BackColor = Color.Lavender; //Claro
                    //gridcentrocostos.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
                    GridExaminar.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(232, 232, 255);
                }
                else
                {
                    //gridcentrocostos.Rows[i].DefaultCellStyle.BackColor = Color.LightGray; //Oscuro
                    //gridcentrocostos.Rows[i].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                    GridExaminar.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(208, 218, 223);
                    GridExaminar.Rows[i].DefaultCellStyle.Font = new Font("Thahoma", 7, FontStyle.Bold);
                }
            }
        }

        public void U_RefrescaControles()
        {
            //txtnombre.Enabled = chknombre.Checked;
            //txtcuentalike.Enabled = chkcuentalike.Checked;
            //if (_CUENTA_MAYOR.Trim().Length == 0)
            //{
            //    txtcuentamayor.Enabled = chkcuentamayor.Checked;
            //}
            //else
            //{
            //    txtcuentamayor.Enabled = _CUENTA_MAYOR.Trim.Length == 0 | _activaCta;
            //}
            //chkcuentamayor.Enabled = _activaCta;
            //txtdcuentamayor.Enabled = false;
            //txtnombre.Enabled = chknombre.Checked;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            llenar_GridExaminar();
        }

        void llenar_GridExaminar()
        {
            try
            {
                tb_co_plancontableBL BL = new tb_co_plancontableBL();
                tb_co_plancontable BE = new tb_co_plancontable();

                BE.perianio = VariablesPublicas.perianio;

                switch (cboCriterioBusqueda.SelectedItem.ToString())
                {
                    case "Cuenta":
                        BE.cuentaid = txtCadenaBuscar.Text.Trim().ToUpper();
                        break;
                    case "Descripción":
                        BE.cuentaname = txtCadenaBuscar.Text.Trim().ToUpper();
                        break;
                    default:
                        BE.cuentaid = txtCadenaBuscar.Text.Trim().ToUpper();
                        break;
                }
                if (GridExaminar.RowCount > 0)
                {
                    GridExaminar.Focus();
                    GridExaminar.BeginEdit(true);
                }
                U_RefrescaControles();
                GridExaminar.AutoGenerateColumns = false;
                GridExaminar.DataSource = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pintar();
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            U_SeleccionaRegistros();
        }

        public void U_SeleccionaRegistros()
        {
            if ((GridExaminar.CurrentRow != null))
            {
                if (Convert.ToBoolean(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["escuentaanalitica"].Value.ToString()) ==  true)
                {
                    //sw_Select = true;
                    PasaCuenta(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["cuentaid"].Value.ToString(), 
                               GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["cuentaname"].Value.ToString());
                    Close();
                }
                else
                {
                    XtraMessageBox.Show("No puede seleccionar cuenta Genérica", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            PasaCuenta("", "");
            Close();
        }

        private void GridExaminar_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            pintar();
        }

        private void GridExaminar_DoubleClick(object sender, EventArgs e)
        {
            U_SeleccionaRegistros();
        }

        private void GridExaminar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                U_SeleccionaRegistros();
            }
        }

        private void Frm_AyudaCuentas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCerrar_Click(sender, e);
            }
        }

        //protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        //{ //  Si el control tiene el foco...
        //    if (keyData == Keys.Enter)
        //    {
        //        SendKeys.Send("\t");
        //        return true;
        //    }
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}

        private void cboCriterioBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCadenaBuscar.Focus();
            }
        }
        private void txtCadenaBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                llenar_GridExaminar();
                btnBuscar.Focus();
            }
        }

        private void txtCadenaBuscar_TextChanged(object sender, EventArgs e)
        {
            llenar_GridExaminar();
            txtCadenaBuscar.Focus();
        }       
    }
}
