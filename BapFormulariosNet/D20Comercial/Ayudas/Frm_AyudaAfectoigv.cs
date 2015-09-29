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
    public partial class Frm_AyudaAfectoigv : plantilla
    {
        public delegate void PasaCodigoDestino(string codigo, string destinoname);
        public PasaCodigoDestino _PasaValor;
        bool sw_load = true;

        public Frm_AyudaAfectoigv()
        {
            InitializeComponent();
        }

        private void Frm_AyudaAfectoigv_Activated(object sender, EventArgs e)
        {
            if (sw_load)
            {
                POnerDatos();

                if (dgAyuda.RowCount > 0)
                {
                    dgAyuda.Focus();
                    dgAyuda.BeginEdit(true);
                }
                sw_load = false;
            }
        }

        private void Frm_AyudaAfectoigv_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

            KeyPreview = true;
            VariablesPublicas.PintaEncabezados(dgAyuda);
        }

        private void POnerDatos()
        {
            SortOrder sorted = default(SortOrder);
            string xnomcolumna = "";

            //DataTable Tipoigv = new DataTable();

            tb_co_tributoafectocomprasBL BL = new tb_co_tributoafectocomprasBL();
            tb_co_tributoafectocompras BE = new tb_co_tributoafectocompras();

            DataTable Tipoigv = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            DataRowCollection rows = Tipoigv.Rows;
            //PCGCURSOR = oCapa.CaeSoft_GetAllTipoDestino(GlobalVars.GetInstance.CompanyGeneral, "");
            dgAyuda.AutoGenerateColumns = false;
            dgAyuda.DataSource = Tipoigv;
            if (xnomcolumna.Trim().Length > 0)
            {
                if (sorted == SortOrder.Ascending)
                {
                    dgAyuda.Sort(dgAyuda.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Ascending);
                }
                else
                {
                    dgAyuda.Sort(dgAyuda.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Descending);
                }
            }
            else
            {
                dgAyuda.Sort(dgAyuda.Columns["destinoid"], System.ComponentModel.ListSortDirection.Ascending);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgAyuda_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            u_SeleccionaRegistro();
        }
        private void dgAyuda_KeyDown(object sender, KeyEventArgs e)
        {
            //string at = String.Empty;
            Keys k;
            k = e.KeyCode;
            switch (k)
            {
                case Keys.Enter:
                    if (Convert.ToBoolean(dgAyuda.CurrentCell) != null)
                    {
                        _PasaValor(dgAyuda.Rows[dgAyuda.CurrentCell.RowIndex].Cells["destinoid"].Value.ToString().Trim(),
                                   dgAyuda.Rows[dgAyuda.CurrentCell.RowIndex].Cells["destinoname"].Value.ToString().Trim());
                    }
                    Close();
                    break;
                default:
                    break;
            }
        }
        
        private void Frm_AyudaAfectoigv_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape)) 
            {
                 Close();
            }
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            u_SeleccionaRegistro();
        }

        private void u_SeleccionaRegistro()
        {
            if (!(dgAyuda.CurrentRow == null))
            {
                if (!(_PasaValor == null))
                {
                    _PasaValor(dgAyuda.Rows[dgAyuda.CurrentCell.RowIndex].Cells["destinoid"].Value.ToString().Trim(),
                               dgAyuda.Rows[dgAyuda.CurrentCell.RowIndex].Cells["destinoname"].Value.ToString().Trim());
                }
                Close();
            }
        }

        private void btnrefrescar_Click(object sender, EventArgs e)
        {
            POnerDatos();
        }
    }
}
