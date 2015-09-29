using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
    public partial class Frm_AyudaProveedor : plantilla  
    {
        public delegate void PasaProveedorDelegate(string xruc, string xnombre, string xdirec);

        public PasaProveedorDelegate PasaProveedor;
        public bool _LeerCombo = true;
        public string _NombreDetalle = "";

        private bool Inicializa = true;

        private string Valores;
        public string _Valores
        {
            get { return Valores; }
            set { Valores = value; }
        }

        //bool Sw_LOad = true;    

        public Frm_AyudaProveedor()
        {
            InitializeComponent();
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            //DevExpress.Skins.SkinManager.EnableFormSkins();

            GridExaminar.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(GridExaminar_RowHeaderMouseClick);
            cboCriterioBusqueda.SelectedIndex = 0;
        }

        private void Frm_AyudaProveedor_Activated(object sender, EventArgs e)
        {
            if (Inicializa)
            {
                Inicializa = false;
                Text = Valores;
                txtCadenaBuscar.Focus();
            }
        }
        private void FRMAyudaProveedores_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape))
            {
                Close();
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            llenar_GridExaminar();
        }
        private void txtCadenaBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                llenar_GridExaminar();
                btnbuscar.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        void llenar_GridExaminar()
        {
            try
            {
                clienteBL BL = new clienteBL();
                tb_cliente BE = new tb_cliente();

                switch (cboCriterioBusqueda.SelectedItem.ToString())
                {
                    case "Razón Social":
                        BE.ctactename = txtCadenaBuscar.Text.Trim().ToUpper();
                        break;
                    case "Ruc":
                        BE.nmruc = txtCadenaBuscar.Text.Trim().ToUpper();
                        break;
                    case "Código":
                        BE.ctacte = txtCadenaBuscar.Text.Trim().ToUpper();
                        break;
                    default:
                        BE.ctactename = txtCadenaBuscar.Text.Trim().ToUpper();
                        break;
                }

                //Sw_LOad = false;
                if (GridExaminar.RowCount > 0)
                {
                    GridExaminar.Focus();
                    GridExaminar.BeginEdit(true);
                }
                GridExaminar.AutoGenerateColumns = false;
                GridExaminar.DataSource = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                U_pINTAR();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargaDatos()
        {
            System.Windows.Forms.SortOrder sorted = default(System.Windows.Forms.SortOrder);
            string xnomcolumna = "";
            if ((GridExaminar.SortedColumn != null))
            {
                xnomcolumna = GridExaminar.Columns[GridExaminar.SortedColumn.Index].Name;
                sorted = GridExaminar.SortOrder;
            }

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
                GridExaminar.Sort(GridExaminar.Columns["Ctacte"], System.ComponentModel.ListSortDirection.Ascending);
            }
        }
        
        private void Frm_AyudaProveedor_Load(object sender, EventArgs e)
        {
            VariablesPublicas.PintaEncabezados(GridExaminar);
        }

        //void U_pINTAR()
        //{
        //    if (1 == 1)
        //    {
        //        int LC_CONT, LC_NCOLUMNA;
        //        for (LC_CONT = 0; LC_CONT < GridExaminar.RowCount; LC_CONT++)
        //        {
        //            if (GridExaminar.Rows[LC_CONT].Cells["status"].Value.ToString() == "9")
        //            {
        //                for (LC_NCOLUMNA = 0; LC_NCOLUMNA < GridExaminar.ColumnCount; LC_NCOLUMNA++)
        //                {
        //                    GridExaminar.Rows[LC_CONT].DefaultCellStyle.BackColor = lblregseleccionado.BackColor;
        //                    GridExaminar.Rows[LC_CONT].DefaultCellStyle.ForeColor = lblregseleccionado.ForeColor;
        //                }
        //            }
        //            else
        //            {
        //                for (LC_NCOLUMNA = 0; LC_NCOLUMNA < GridExaminar.ColumnCount; LC_NCOLUMNA++)
        //                {
        //                    //GridExaminar.Rows[LC_CONT].DefaultCellStyle.BackColor = Color.White;
        //                    //GridExaminar.Rows[LC_CONT].DefaultCellStyle.ForeColor = Color.Black;                          
        //                }
        //            }
        //        }
        //    }
        //}
        public void U_pINTAR()
        {
            if (1 == 1)
            {
                int lc_cont = 0;
                int LC_NCOLUMNA = 0;
                for (lc_cont = 0; lc_cont <= GridExaminar.RowCount - 1; lc_cont++)
                {
                    if (GridExaminar.Rows[lc_cont].Cells["status"].Value.ToString() != "0")
                    {
                        for (LC_NCOLUMNA = 0; LC_NCOLUMNA <= GridExaminar.ColumnCount - 1; LC_NCOLUMNA++)
                        {
                            GridExaminar.Rows[lc_cont].DefaultCellStyle.BackColor = lblregseleccionado.BackColor;
                            GridExaminar.Rows[lc_cont].DefaultCellStyle.ForeColor = lblregseleccionado.ForeColor;
                        }
                    }
                    //else if (GridExaminar.Rows[lc_cont].Cells["status"].Value.ToString() == "1")
                    //{
                    //    for (LC_NCOLUMNA = 0; LC_NCOLUMNA <= GridExaminar.ColumnCount - 1; LC_NCOLUMNA++)
                    //    {
                    //        GridExaminar.Rows[lc_cont].DefaultCellStyle.BackColor = lblregseleccionado.BackColor;
                    //        GridExaminar.Rows[lc_cont].DefaultCellStyle.ForeColor = lblregseleccionado.ForeColor;
                    //    }
                    //}
                    //else
                    //{
                    //    //for (LC_NCOLUMNA = 0; LC_NCOLUMNA <= GridExaminar.ColumnCount - 1; LC_NCOLUMNA++)
                    //    //{
                    //    //    GridExaminar.Rows[lc_cont].DefaultCellStyle.BackColor = Color.White;
                    //    //    GridExaminar.Rows[lc_cont].DefaultCellStyle.ForeColor = Color.Black;
                    //    //}
                    //}
                }
            }
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            u_SeleccionaRegistro();
        }
        private void GridExaminar_DoubleClick(object sender, EventArgs e)
        {
            u_SeleccionaRegistro();
        }
        private void GridExaminar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                u_SeleccionaRegistro();
            }
        }
      
        public void u_SeleccionaRegistro()
        {
            if ((GridExaminar.CurrentRow != null))
            {
                if ((PasaProveedor != null))
                {
                    PasaProveedor(GridExaminar.Rows[GridExaminar.CurrentCell.RowIndex].Cells["nmruc"].Value.ToString(),
                        GridExaminar.Rows[GridExaminar.CurrentCell.RowIndex].Cells["ctactename"].Value.ToString(),
                        GridExaminar.Rows[GridExaminar.CurrentCell.RowIndex].Cells["direc"].Value.ToString());
                }
                Close();
            }
        }

        private void GridExaminar_RowHeaderMouseClick(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            if (GridExaminar.CurrentRow != null)
            {
                GridExaminar.Rows[GridExaminar.CurrentRow.Index].Selected = true;
            }
        }
    }
}
