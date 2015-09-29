using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using BapFormulariosNet.Codigo;

namespace BapFormulariosNet.Ayudas
{
    public partial class Frm_AyudaReciboHonorarios : Form
    {
        public delegate void PasaCuentaDelegate(string regmes, string regnumero, string detalle);
        public PasaCuentaDelegate _PasaRegCompras;
        public string _Mes = string.Empty;
        private bool sw_Load = true;
        private DataTable tabla;
        private DataTable tmptabla;
        private string j_String = string.Empty;
        private bool sw_Select = false;

        public Frm_AyudaReciboHonorarios()
        {
            InitializeComponent();

            Load += Frm_AyudaReciboHonorarios_Load;
            Activated += Frm_AyudaReciboHonorarios_Activated;

            txtdetalle.LostFocus += new System.EventHandler(txtdetalle_LostFocus);
            txtdetalle.GotFocus += new System.EventHandler(txtdetalle_GotFocus);

            txtregmes.LostFocus += new System.EventHandler(txtregmes_LostFocus);
        }

        private void Frm_AyudaReciboHonorarios_Activated(object sender, EventArgs e)
        {
            if (sw_Load)
            {
                sw_Load = false;
                U_CargaDatos();
            }
        }
        private void Frm_AyudaReciboHonorarios_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Fixed3D;
            if (_Mes.Trim().Length > 0)
            {
                chkregmes.Checked = true;
                txtregmes.Text = _Mes;
            }
            fechaini.Value = Convert.ToDateTime("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString());
            U_RefrescaControles();
        }

        private void pintar()
        {
            var i = 0;
            var j = 0;
            dynamic celdaactual = dgProveedor.CurrentCell;
            for (i = 0; i <= dgProveedor.Rows.Count - 1; i++)
            {
                if (dgProveedor["status", i].Value.ToString() == "9")
                {
                    for (j = 0; j <= dgProveedor.ColumnCount - 1; j++)
                    {
                        dgProveedor[j, i].Style.ForeColor = LNLANULADOS.ForeColor;
                        dgProveedor[j, i].Style.BackColor = LNLANULADOS.BackColor;
                    }
                }
                else
                {
                    for (j = 0; j <= dgProveedor.ColumnCount - 1; j++)
                    {
                        dgProveedor[j, i].Style.ForeColor = System.Drawing.Color.Black;
                        dgProveedor[j, i].Style.BackColor = System.Drawing.Color.White;
                    }
                }
            }
            try
            {
                dgProveedor.CurrentCell = celdaactual;
            }
            catch (Exception ex)
            {
                if (dgProveedor.Rows.Count > 0)
                {
                    dgProveedor.CurrentCell = dgProveedor.Rows[0].Cells["mes_reg"];
                }
            }
        }

        private void dgProveedor_DoubleClick(object sender, EventArgs e)
        {
            U_SeleccionaRegistros();
        }

        private void txtglosa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                U_SeleccionaRegistros();
            }
        }

        private void dgProveedor_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            pintar();
        }
        private void dgProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                U_SeleccionaRegistros();
            }
        }

        public void U_CargaDatos()
        {
            var xpalabra1 = string.Empty;
            var xpalabra2 = string.Empty;
            var xpalabra3 = string.Empty;
            var xpalabra4 = string.Empty;
            if (txtglosa.Enabled)
            {
                xpalabra1 = VariablesPublicas.Palabras(txtglosa.Text.Trim(), 1);
                xpalabra2 = VariablesPublicas.Palabras(txtglosa.Text.Trim(), 2);
                xpalabra3 = VariablesPublicas.Palabras(txtglosa.Text.Trim(), 3);
                xpalabra4 = VariablesPublicas.Palabras(txtglosa.Text.Trim(), 4);
            }
            var xfechaini = string.Empty;
            var xfechafin = string.Empty;
            var xdetalle = string.Empty;
            if (fechaini.Enabled)
            {
                xfechaini = VariablesPublicas.DTOS(fechaini.Value);
            }
            if (fechafin.Enabled)
            {
                xfechafin = VariablesPublicas.DTOS(fechafin.Value);
            }
            var xcodmes = string.Empty;
            if (txtregmes.Enabled)
            {
                xcodmes = txtregmes.Text;
            }
            if (txtdetalle.Enabled)
            {
                xdetalle = txtdetalle.Text;
            }
            var xnumdoc = string.Empty;
            if (txtnumdoc.Enabled)
            {
                xnumdoc = txtnumdoc.Text;
            }
            var BL = new tb_co_recibosporhonorariosBL();
            var BE = new tb_co_recibosporhonorarios();

            BE.perianio = VariablesPublicas.perianio;
            BE.perimes = xcodmes;
            BE.fechaini = xfechaini;
            BE.fechafin = xfechafin;
            BE.nmruc = xdetalle;
            BE.numdoc = xnumdoc;
            BE.glosa = xpalabra1;
            BE.nOrden = 1;

            tabla = BL.GetAllAyuda(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            if (BL.Sql_Error.Length > 0)
            {
                sw_Load = false;
                Frm_Class.ShowError(BL.Sql_Error, this);
            }
            else
            {
                var sorted = default(SortOrder);
                var xnomcolumna = string.Empty;
                if ((dgProveedor.SortedColumn != null))
                {
                    xnomcolumna = dgProveedor.Columns[dgProveedor.SortedColumn.Index].Name;
                    sorted = dgProveedor.SortOrder;
                }
                dgProveedor.AutoGenerateColumns = false;
                dgProveedor.DataSource = tabla;
                dgProveedor.AllowUserToResizeRows = false;
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
                    dgProveedor.Sort(dgProveedor.Columns["fecha"], System.ComponentModel.ListSortDirection.Descending);
                }
                if (dgProveedor.Rows.Count > 0)
                {
                    dgProveedor.CurrentCell = dgProveedor.Rows[0].Cells["registro"];
                    dgProveedor.Focus();
                    dgProveedor.BeginEdit(true);
                }
                pintar();
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            U_SeleccionaRegistros();
        }
        public void U_SeleccionaRegistros()
        {
            if ((dgProveedor.CurrentRow != null))
            {
                sw_Select = true;
                _PasaRegCompras(dgProveedor.Rows[dgProveedor.CurrentRow.Index].Cells["mes_reg"].Value.ToString(),
                                     dgProveedor.Rows[dgProveedor.CurrentRow.Index].Cells["nro_reg"].Value.ToString(),
                                     dgProveedor.Rows[dgProveedor.CurrentRow.Index].Cells["DETALLE"].Value.ToString());
                Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            _PasaRegCompras(string.Empty, string.Empty, string.Empty);
            Close();
        }

        private void btnrefrescar_Click(object sender, EventArgs e)
        {
            U_CargaDatos();
        }

        private void chkglosa_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_RefrescaControles();
            }
        }

        public void U_RefrescaControles()
        {
            txtnumdoc.Enabled = chknumdoc.Checked;
            txtglosa.Enabled = chkglosa.Checked;
            txtregmes.Enabled = chkregmes.Checked;
            txtdetalle.Enabled = chkdetalle.Checked;
            fechaini.Enabled = chkfechas.Checked;
            fechafin.Enabled = chkfechas.Checked;
            txtdcuentamayor.Enabled = false;
            txtglosa.Enabled = chkglosa.Checked;
        }

        private void chkdetalle_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_RefrescaControles();
            }
        }

        private void txtdetalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaProveedor();
            }
        }
        private void txtdetalle_GotFocus(object sender, System.EventArgs e)
        {
            j_String = txtdetalle.Text;
        }
        private void txtdetalle_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_String == txtdetalle.Text) & !sw_Load)
            {
                ValidaDetalle();
            }
        }
        private void AyudaProveedor()
        {
            var frmayuda = new Frm_AyudaProveedor();
            frmayuda._Valores = "<< Ayuda Proveedores >>";
            frmayuda.Owner = this;
            frmayuda.PasaProveedor = RecibeProveedor;
            frmayuda.ShowDialog();
        }
        private void RecibeProveedor(string codigo, string nombre, string direccion)
        {
            if (codigo.Trim().Length > 0)
            {
                txtdetalle.Text = codigo.Trim();
                txtdetalle.Text = nombre.Trim();
                U_CargaDatos();
            }
        }
        public void ValidaDetalle()
        {
            if (txtdetalle.Text.Trim().Length > 0)
            {
                var BL = new clienteBL();
                var BE = new tb_cliente();

                BE.nmruc = txtdetalle.Text.Trim();
                tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                if (BL.Sql_Error.Length == 0)
                {
                    if (tmptabla.Rows.Count > 0)
                    {
                        txtdcuentamayor.Text = tmptabla.Rows[0]["ctactename"].ToString();
                        U_CargaDatos();
                    }
                }
            }
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (keyData == Keys.Enter & !btnSeleccionar.Focused)
            {
                if ((dgProveedor.CurrentCell != null))
                {
                    if (dgProveedor.Focused)
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
            return base.ProcessCmdKey( ref msg, keyData);
        }

        private void chkfechas_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_RefrescaControles();
            }
        }

        private void chkregmes_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_RefrescaControles();
            }
        }
        private void txtregmes_LostFocus(object sender, System.EventArgs e)
        {
            if (!sw_Load)
            {
                if (txtregmes.Text.Trim().Length > 0)
                {
                    txtregmes.Text = VariablesPublicas.PADL(txtregmes.Text.Trim(), 2, "0");
                }
            }
        }

        private void chknumdoc_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_RefrescaControles();
            }
        }
    }
}
