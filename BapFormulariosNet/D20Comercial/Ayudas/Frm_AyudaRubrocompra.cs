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
    public partial class Frm_AyudaRubrocompra : plantilla
    {
        DataTable PCGCURSOR = new DataTable();

        public delegate void PasaCodigoDocumento(string codigo, string rubroname);
        public PasaCodigoDocumento _PasaValor;
        bool sw_load = true;
        int xestado = 1;

        public Frm_AyudaRubrocompra()
        {
            InitializeComponent();
        }

        private void Frm_AyudaRubrocompra_Activated(object sender, EventArgs e)
        {
            if (sw_load)
            {
                u_refrescaControles();
                POnerDatos();
                if ((GridExaminar.RowCount > 0))
                {
                    GridExaminar.Focus();
                    GridExaminar.BeginEdit(true);
                }
                sw_load = false;
            }
        }
        private void Frm_AyudaRubrocompra_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

            //KeyPreview = true;
            //if ((_LPDESCRIPCION.Trim().Length > 0))
            //{
            //    txtdescrip.Text = _LPDESCRIPCION;
            //}
            //if ((_LPCODIGOLIKE.Trim().Length > 0))
            //{
            //    chkid.Checked = true;
            //    txtcodigo.Text = _LPCODIGOLIKE;
            //}
            VariablesPublicas.PintaEncabezados(GridExaminar);
        }

        private void POnerDatos()
        {
            string xCuenta = "";
            if (txtCuenta.Enabled)
            {
                xCuenta = txtCuenta.Text;
            }

            string xRubro = "";
            if (txtRubro.Enabled)
            {
                xRubro = txtRubro.Text;
            }

            string xDescripcion = "";
            if (txtDescripcion.Enabled)
            {
                xDescripcion = txtDescripcion.Text;
            }
            
            try
            {
                tb_co_rubrocomprasBL BL = new tb_co_rubrocomprasBL();
                tb_co_rubrocompras BE = new tb_co_rubrocompras();

                BE.rubroid = xRubro;
                BE.rubroname = xDescripcion;
                BE.cuentaid = xCuenta;
                BE.nestado = xestado;
                PCGCURSOR = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                      
            if ((PCGCURSOR.Rows.Count > 0))  
            {              
                GridExaminar.AutoGenerateColumns = false;
                GridExaminar.DataSource = PCGCURSOR;
                CargaDatos();
                Ponedatos();
            }
            else
            {
                sw_load = false;
            }
        }
        private void CargaDatos()
        {
            SortOrder sorted = default(SortOrder);
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
                GridExaminar.Sort(GridExaminar.Columns["cuentaid"], System.ComponentModel.ListSortDirection.Ascending);
            }
        }
        private void Ponedatos()
        {
            //if ((GridExaminar.CurrentRow != null))
            //{
            //    if (GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["status"].Value.ToString() == "0")
            //    {
            //        rbTitulo.Checked = true;
            //        rbActivo.Checked = false;
            //        rbBaja.Checked = false;
            //    }
            //    if (GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["status"].Value.ToString() == "1")
            //    {
            //        rbTitulo.Checked = false;
            //        rbActivo.Checked = true;
            //        rbBaja.Checked = false;
            //    }
            //    if (GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["status"].Value.ToString() == "2")
            //    {
            //        rbTitulo.Checked = false;
            //        rbActivo.Checked = false;
            //        rbBaja.Checked = true;
            //    }
            //}
        }
        private void u_refrescaControles()
        {
            txtCuenta.Enabled = chkCuenta.Checked;
            txtRubro.Enabled = chkRubro.Checked;
            txtDescripcion.Enabled = chkDescripcion.Checked;
        }

        private void Frm_AyudaRubrocompra_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape))
            {
                Close();
            }
        }

        private void txtCuenta_TextChanged(object sender, EventArgs e)
        {
            if (!sw_load)
            {
                POnerDatos();
                txtCuenta.Focus();
            }
        }

        private void chkCuenta_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_load)
            {
                u_refrescaControles();
                POnerDatos();
            }
        }

        private void chkRubro_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_load)
            {
                u_refrescaControles();
                POnerDatos();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GridExaminar_KeyDown(object sender, KeyEventArgs e)
        {
            //string at = string.Empty;
            Keys k = default(Keys);
            k = e.KeyCode;
            switch (k)
            {
                case Keys.Enter:
                    if (GridExaminar.CurrentCell != null)
                    {
                        _PasaValor(GridExaminar.Rows[GridExaminar.CurrentCell.RowIndex].Cells["rubroid"].Value.ToString().Trim(),
                                   GridExaminar.Rows[GridExaminar.CurrentCell.RowIndex].Cells["rubroname"].Value.ToString().Trim());
                    }
                    Close();
                    break;
                default:
                    break;
            }
        }
        private void GridExaminar_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            u_SeleccionaRegistro();
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            u_SeleccionaRegistro();
        }

        private void u_SeleccionaRegistro()
        {
            if (!(GridExaminar.CurrentRow == null))
            {
                if (!(_PasaValor == null))
                {
                    _PasaValor(GridExaminar.Rows[GridExaminar.CurrentCell.RowIndex].Cells["rubroid"].Value.ToString().Trim(),
                                   GridExaminar.Rows[GridExaminar.CurrentCell.RowIndex].Cells["rubroname"].Value.ToString().Trim());
                }
                Close();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            POnerDatos();
        }

        private void GridExaminar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            u_SeleccionaRegistro();
        }
        private void GridExaminar_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i <= GridExaminar.Rows.Count - 1; ++i)
            {
                string estado = GridExaminar.Rows[i].Cells["status"].Value.ToString();
                if (estado == "2")
                {
                    //gridcentrocostos.Rows[i].DefaultCellStyle.BackColor = Color.Lavender; //Claro
                    //gridcentrocostos.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
                    //GridExaminar.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 0, 0);
                    GridExaminar.Rows[i].DefaultCellStyle.ForeColor = Color.FromArgb(255, 0, 0);
                }
                if (estado == "0")
                {
                    //gridcentrocostos.Rows[i].DefaultCellStyle.BackColor = Color.LightGray; //Oscuro
                    //gridcentrocostos.Rows[i].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                    GridExaminar.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(208, 218, 223);
                    GridExaminar.Rows[i].DefaultCellStyle.Font = new Font("Thahoma", 7, FontStyle.Bold);
                }
            }
        }
        private void GridExaminar_SelectionChanged(object sender, EventArgs e)
        {
            Ponedatos();
        }

        private void chkDescripcion_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_load)
            {
                u_refrescaControles();
                POnerDatos();
            }
        }

        private void rbTitulo_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_load)
            {
                xestado = 0;
                POnerDatos();
            }
        }

        private void rbActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_load)
            {
                xestado = 1;
                POnerDatos();
            }
        }

        private void rbBaja_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.sw_load)
            {
                xestado = 2;
                POnerDatos();
            }
        }

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    xestado = 1;
            //    POnerDatos();
            //    btnBuscar.Focus();
            //}
        }

        private void txtRubro_TextChanged(object sender, EventArgs e)
        {
            if (!sw_load)
            {
                POnerDatos();
                txtRubro.Focus();
            }
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            if (!sw_load)
            {
                POnerDatos();
                txtDescripcion.Focus();
            }
        }
    }
}
