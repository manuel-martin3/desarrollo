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
    public partial class Frm_AyudaTipoDocumentos : plantilla
    {
        public delegate void pasaTipoConcepto(string codigo, string descripcion);
        public pasaTipoConcepto _PasaValor;
        bool sw_load = true;
        DataTable PCGCURSOR = new DataTable();

        public Frm_AyudaTipoDocumentos()
        {
            InitializeComponent();
            cboCriterioBusqueda.SelectedIndex = 0;
        }

        private void Frm_AyudaTipoDocumentos_Activated(object sender, EventArgs e)
        {
            if (sw_load)
            {
                POnerDatos();
                if ((dgAyuda.RowCount > 0))
                {
                    dgAyuda.Focus();
                    dgAyuda.BeginEdit(true);
                }
                sw_load = false;
            }
        }
        private void Frm_AyudaTipoDocumentos_Load(object sender, EventArgs e)
        {
            VariablesPublicas.PintaEncabezados(dgAyuda);
        }
        private void Frm_AyudaTipoDocumentos_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape))
            {
                Close();
            }
        }

        private void POnerDatos()
        {
            SortOrder sorted = default(SortOrder);
            string xnomcolumna = "";
            if (!(dgAyuda.SortedColumn == null))
            {
                xnomcolumna = dgAyuda.Columns[dgAyuda.SortedColumn.Index].Name;
                sorted = dgAyuda.SortOrder;
            }
            
            tb_co_tabla10_comprobantesBL BL = new tb_co_tabla10_comprobantesBL();
            tb_co_tabla10_comprobantes BE = new tb_co_tabla10_comprobantes();

            switch (cboCriterioBusqueda.SelectedItem.ToString())
            {
                case "Código":
                    BE.codigoid = txtBuscar.Text.Trim().ToUpper();
                    break;
                case "Descripción":
                    BE.descripcion = txtBuscar.Text.Trim().ToUpper();
                    break;
                default:
                    BE.codigoid = txtBuscar.Text.Trim().ToUpper();
                    break;
            }
            PCGCURSOR = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            dgAyuda.AutoGenerateColumns = false;
            dgAyuda.DataSource = PCGCURSOR;
            if ((xnomcolumna.Trim().Length > 0))
            {
                if ((sorted == SortOrder.Ascending))
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
                dgAyuda.Sort(dgAyuda.Columns["codigoid"], System.ComponentModel.ListSortDirection.Ascending);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            u_SeleccionaRegistro();
        }

        private void dgAyuda_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            u_SeleccionaRegistro();
        }
        private void dgAyuda_KeyDown(object sender, KeyEventArgs e)
        {
            //string at = String.Empty;
            //Keys k;
            //k = e.KeyCode;
            //switch (k)
            //{
            //    case Keys.Enter & dgAyuda.CurrentCell == null:
            //        _PasaValor(dgAyuda.Rows[dgAyuda.CurrentCell.RowIndex].Cells["codigo"].Value.ToString());
            //        Close();

            //        break;
            //    default:
            //        break;
            //}
        }
        private void dgAyuda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            u_SeleccionaRegistro();
        }

        private void txtdescrip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '\r'))
            {
                POnerDatos();
            }
        }

        void u_SeleccionaRegistro()
        {
            if (!(dgAyuda.CurrentRow == null))
            {
                if (!(_PasaValor == null))
                {
                    _PasaValor(dgAyuda.Rows[dgAyuda.CurrentCell.RowIndex].Cells["codigoid"].Value.ToString(),
                                    dgAyuda.Rows[dgAyuda.CurrentCell.RowIndex].Cells["descripcion"].Value.ToString());
                }
                Close();
            }
        }

        private void btnrefrescar_Click(object sender, EventArgs e)
        {
            POnerDatos();
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            // Si el control tiene el foco...
            if (keyData == Keys.Enter & !btnrefrescar.Focused & !btnSeleccion.Focused & !btnCerrar.Focused)
            {
                SendKeys.Send("\t");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
