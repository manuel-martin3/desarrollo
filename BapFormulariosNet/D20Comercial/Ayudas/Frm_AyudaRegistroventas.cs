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
using DevExpress.XtraEditors;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.D20Comercial.Ayudas
{
    public partial class Frm_AyudaRegistroventas : plantilla
    {
        public delegate void PasaCuentaDelegate(string regmes, string regdiario, string regnumero, string detalle);
        #region "Fields"
        //Parametros
        public PasaCuentaDelegate _PasaRegVentas;
        public string _Mes = "";
        // Variables
        //string j_TipDoc = "";
        bool sw_Load = true;
        DataTable tabla;
        DataTable tmptabla;
        string j_String = "";
        #endregion
        //bool sw_Select = false;

        public Frm_AyudaRegistroventas()
        {
            InitializeComponent();
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            //DevExpress.Skins.SkinManager.EnableFormSkins();

            //KeyDown += Frm_AyudaRegistroventas_KeyDown;;
            //Load += Frm_AyudaRegistroventas_Load;
            //Activated += Frm_AyudaRegistroventas_Activated;

            txtDetalle.LostFocus += new System.EventHandler(txtDetalle_LostFocus);
            txtDetalle.GotFocus += new System.EventHandler(txtDetalle_GotFocus);

            txtRegmes.LostFocus += new System.EventHandler(txtRegmes_LostFocus);

            txtNumdocu.LostFocus += new System.EventHandler(txtNumdocu_LostFocus);
        }

        void llenar_cboTipocompra()
        {
            try
            {
                cboTipoventa.DataSource = NewMethodTV();
                cboTipoventa.DisplayMember = "Value";
                cboTipoventa.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethodTV()
        {
            tb_co_tipoventasBL BL = new tb_co_tipoventasBL();
            tb_co_tipoventas BE = new tb_co_tipoventas();

            DataTable tcompra = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            DataRowCollection rows = tcompra.Rows;

            object[] cell;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            BindingSource binding = new BindingSource();

            foreach (DataRow item in rows)
            {
                cell = item.ItemArray;
                dic.Add(cell[0].ToString(), cell[0].ToString() + " - " + cell[1].ToString());
                cell = null;
            }
            binding.DataSource = dic;
            return binding;
        }

        void llenar_cboTipdoc()
        {
            try
            {
                cboTipdoc.DataSource = NewMethodTD();
                cboTipdoc.DisplayMember = "Value";
                cboTipdoc.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethodTD()
        {
            tb_co_tabla10_comprobantesBL BL = new tb_co_tabla10_comprobantesBL();
            tb_co_tabla10_comprobantes BE = new tb_co_tabla10_comprobantes();

            DataTable tipdoc = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            DataRowCollection rows = tipdoc.Rows;

            object[] cell;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            BindingSource binding = new BindingSource();

            foreach (DataRow item in rows)
            {
                cell = item.ItemArray;
                dic.Add(cell[0].ToString(), cell[0].ToString() + " - " + cell[1].ToString());
                cell = null;
            }
            binding.DataSource = dic;
            return binding;
        }

        private void Frm_AyudaRegistroventas_Activated(object sender, EventArgs e)
        {
            if (sw_Load)
            {
                llenar_cboTipocompra();
                llenar_cboTipdoc();
                cboOrigen.SelectedIndex = 0;
                sw_Load = false;
                U_CargaDatos();
            }
        }
        private void Frm_AyudaRegistroventas_Load(object sender, EventArgs e)
        {
            if (_Mes.Trim().Length > 0)
            {
                chkRegmes.Checked = true;
                txtRegmes.Text = _Mes;
            }
            Fechaini.Value = Convert.ToDateTime("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString());
            U_RefrescaControles();
            VariablesPublicas.PintaEncabezados(dgProveedor);
        }
        private void Frm_AyudaRegistroventas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCerrar_Click(sender, e);
            }
        }

        private void pintar()
        {
            int i;
            int j;
            dynamic celdaactual = dgProveedor.CurrentCell;
            for (i = 0; (i <= (dgProveedor.Rows.Count - 1)); i++)
            {
                if ((dgProveedor["status", i].Value.ToString() == "9"))
                {
                    for (j = 0; (j <= (dgProveedor.ColumnCount - 1)); j++)
                    {
                        dgProveedor[j, i].Style.ForeColor = LNLANULADOS.ForeColor;
                        dgProveedor[j, i].Style.BackColor = LNLANULADOS.BackColor;
                    }
                }
                else
                {
                    for (j = 0; (j <= (dgProveedor.ColumnCount - 1)); j++)
                    {
                        dgProveedor[j, i].Style.ForeColor = Color.Black;
                        dgProveedor[j, i].Style.BackColor = Color.White;
                    }
                }
            }
            try
            {
                dgProveedor.CurrentCell = celdaactual;
            }
            catch (Exception ex)
            {
                ex.ToString();
                if ((dgProveedor.Rows.Count > 0))
                {
                    dgProveedor.CurrentCell = dgProveedor.Rows[0].Cells["perimes"];
                }
            }
        }

        //private void pintar()
        //{
        //    int i = 0;
        //    int j = 0;
        //    dynamic celdaactual = dgProveedor.CurrentCell;
        //    for (i = 0; i <= dgProveedor.Rows.Count - 1; i++)
        //    {
        //        if (dgProveedor["status", i].Value == "1")
        //        {
        //            for (j = 0; j <= dgProveedor.ColumnCount - 1; j++)
        //            {
        //                dgProveedor[j, i].Style.ForeColor = LNLANULADOS.ForeColor;
        //                dgProveedor[j, i].Style.BackColor = LNLANULADOS.BackColor;
        //            }
        //        }
        //        else
        //        {
        //            for (j = 0; j <= dgProveedor.ColumnCount - 1; j++)
        //            {
        //                dgProveedor[j, i].Style.ForeColor = System.Drawing.Color.Black;
        //                dgProveedor[j, i].Style.BackColor = System.Drawing.Color.White;
        //            }
        //        }
        //    }
        //    try
        //    {
        //        dgProveedor.CurrentCell = celdaactual;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (dgProveedor.Rows.Count > 0)
        //        {
        //            dgProveedor.CurrentCell = dgProveedor.Rows[0].Cells["perimes"];
        //        }
        //    }
        //}

        private void dgProveedor_DoubleClick(object sender, EventArgs e)
        {
            U_SeleccionaRegistros();
        }

        private void txtGlosa_KeyDown(object sender, KeyEventArgs e)
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
            string xvmtipocompra = "";
            if (cboTipoventa.Enabled)
            {
                if ((cboTipoventa.SelectedValue != null))
                {
                    xvmtipocompra = cboTipoventa.SelectedValue.ToString();
                }
            }
            string xpalabra1 = "";
            string xpalabra2 = "";
            string xpalabra3 = "";
            string xpalabra4 = "";
            string xtipdoc = "";
            if (txtGlosa.Enabled)
            {
                xpalabra1 = VariablesPublicas.Palabras(txtGlosa.Text.Trim(), 1);
                xpalabra2 = VariablesPublicas.Palabras(txtGlosa.Text.Trim(), 2);
                xpalabra3 = VariablesPublicas.Palabras(txtGlosa.Text.Trim(), 3);
                xpalabra4 = VariablesPublicas.Palabras(txtGlosa.Text.Trim(), 4);
            }
            if (cboTipdoc.Enabled)
            {
                xtipdoc = cboTipdoc.SelectedValue.ToString();
            }
            string xnumdoc = "";
            string xserdoc = "";
            if (txtNumdocu.Enabled)
            {
                xserdoc = Equivalencias.Left(txtNumdocu.Text, 4); 
                xnumdoc = Equivalencias.Right(txtNumdocu.Text, 10);               
            }

            string xfechaini = "";
            string xfechafin = "";
            string xdetalle = "";
            if (Fechaini.Enabled)
            {
                xfechaini = Convert.ToDateTime(Fechaini.Text).ToString();
            }
            if (Fechafin.Enabled)
            {
                xfechafin = Convert.ToDateTime(Fechafin.Text).ToString();
            }
            string xcodmes = "";
            if (txtRegmes.Enabled)
            {
                xcodmes = txtRegmes.Text;
            }
            else
            {
                xcodmes = _Mes;
            }
            if (txtDetalle.Enabled)
            {
                xdetalle = txtDetalle.Text;
            }
            string xorigen = "";
            if (cboOrigen.Enabled)
            {
                if ((cboOrigen.Text.Substring(0, 2) != ""))
                {
                    xorigen = cboOrigen.Text.Substring(0, 2);
                }
            }
            btnRefrescar.Enabled = false;
            try
            {
                tb_co_VentascabBL BL = new tb_co_VentascabBL();
                tb_co_Ventascab BE = new tb_co_Ventascab();

                BE.perianio = VariablesPublicas.perianio;
                BE.perimes = xcodmes;
                //BE.diarioid = cboSubdiario.Text.Substring(0, 4);
                //BE.asiento = txtAsiento.Text;
                BE.nmruc = xdetalle;
                BE.tipdoc = xtipdoc;
                BE.origen = xorigen;
                BE.serdoc = xserdoc;
                BE.numdoc = xnumdoc;
                BE.tipoventa = xvmtipocompra;
                BE.glosa = xpalabra1;

                tabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //tabla = ocapa.spu_AyudaRegVentas(GlobalVars.GetInstance.Company, GlobalVars.GetInstance.Periodo, xcodmes, "", xfechaini, xfechafin, xdetalle, xpalabra1, xpalabra2, xpalabra3, xorigen, xnumdoculike, xtipdoc, xvmtipocompra);
            btnRefrescar.Enabled = true;
            //if (ocapa.sql_error.Length > 0)
            //{
            //    sw_Load = false;
            //    frmclass.ShowError(ocapa.sql_error, this);
            //}
            //else
            //{
                SortOrder sorted = default(SortOrder);
                string xnomcolumna = "";
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
                    dgProveedor.Sort(dgProveedor.Columns["fechdoc"], System.ComponentModel.ListSortDirection.Descending);
                }
                if (dgProveedor.Rows.Count > 0)
                {
                    dgProveedor.CurrentCell = dgProveedor.Rows[0].Cells["asiento"];
                    dgProveedor.Focus();
                    dgProveedor.BeginEdit(true);
                }
                pintar();
            //}
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            U_SeleccionaRegistros();
        }

        public void U_SeleccionaRegistros()
        {
            if ((dgProveedor.CurrentRow != null))
            {
                //sw_Select = true;
                _PasaRegVentas(dgProveedor.Rows[dgProveedor.CurrentRow.Index].Cells["perimes"].Value.ToString(),
                                    dgProveedor.Rows[dgProveedor.CurrentRow.Index].Cells["diarioid"].Value.ToString(),
                                    dgProveedor.Rows[dgProveedor.CurrentRow.Index].Cells["asiento"].Value.ToString(), 
                                    dgProveedor.Rows[dgProveedor.CurrentRow.Index].Cells["nmruc"].Value.ToString());
                Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            _PasaRegVentas("", "", "", "");
            Close();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            U_CargaDatos();
        }

        private void chkGlosa_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_RefrescaControles();
            }
        }

        public void U_RefrescaControles()
        {
            cboTipoventa.Enabled = chkTipoventa.Checked;
            cboTipdoc.Enabled = chkTipdoc.Checked;
            txtNumdocu.Enabled = chkNumdocu.Checked;
            cboOrigen.Enabled = chkOrigen.Checked;
            txtGlosa.Enabled = chkGlosa.Checked;
            txtRegmes.Enabled = chkRegmes.Checked;
            txtDetalle.Enabled = chkDetalle.Checked;
            Fechaini.Enabled = chkFechas.Checked;
            Fechafin.Enabled = chkFechas.Checked;
            txtNomdetalle.Enabled = false;
        }

        private void chkDetalle_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_RefrescaControles();
            }
        }
        private void txtDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaProveedor();
            }
        }
        private void txtDetalle_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_String == txtDetalle.Text) & !sw_Load)
            {
                ValidaDetalle();
            }
        }
        private void txtDetalle_GotFocus(object sender, System.EventArgs e)
        {
            j_String = txtDetalle.Text;
        }
        private void AyudaProveedor()
        {
            Frm_AyudaProveedor frmayuda = new Frm_AyudaProveedor();
            frmayuda.Owner = this;
            frmayuda.PasaProveedor = RecibeProveedor;
            frmayuda.ShowDialog();
        }
        private void RecibeProveedor(string codigo, string nombre, string direccion)
        {
            if (codigo.Trim().Length > 0)
            {
                txtDetalle.Text = codigo;
                txtNomdetalle.Text = nombre;
                U_CargaDatos();
            }
        }     
        public void ValidaDetalle()
        {
            if (txtDetalle.Text.Trim().Length > 0)
            {
                clienteBL BL = new clienteBL();
                tb_cliente BE = new tb_cliente();

                BE.nmruc = txtDetalle.Text.Trim();
                tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                //tmptabla = ocapa.cag1000_CONSULTA(GlobalVars.GetInstance.CompanyGeneral, txtdetalle.Text, "", "", "", "", "", "", 1, "", 0, "", "");
                if (BL.Sql_Error.Length == 0)
                {
                    if (tmptabla.Rows.Count > 0)
                    {
                        txtNomdetalle.Text = tmptabla.Rows[0]["ctactename"].ToString().Trim();
                        U_CargaDatos();
                    }
                }
            }
        }
        
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            // Si el control tiene el foco...
            if (keyData == Keys.Enter & !btnSeleccion.Focused)
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
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void chkFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_RefrescaControles();
            }
        }

        private void chkRegmes_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_RefrescaControles();
            }
        }
        private void txtRegmes_LostFocus(object sender, System.EventArgs e)
        {
            if (!sw_Load)
            {
                if (txtRegmes.Text.Trim().Length > 0)
                {
                    txtRegmes.Text = VariablesPublicas.PADL(txtRegmes.Text.Trim(), 2, "0");
                }
            }
        }

        private void chkOrigen_CheckedChanged(object sender, EventArgs e)
        {
            U_RefrescaControles();
        }

        private void chkNumdocu_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_RefrescaControles();
            }
        }
        private void txtNumdocu_LostFocus(object sender, System.EventArgs e)
        {
            if (!sw_Load)
            {
                if (txtNumdocu.Text.Trim().Length > 0)
                {
                    txtNumdocu.Text = VariablesPublicas.JustificarDocumento(txtNumdocu.Text, 4, 10, true);
                }
            }
        }
        
        private void chkTipdoc_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_RefrescaControles();
            }
        }

        private void dgProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            U_SeleccionaRegistros();
        }

        private void chkTipoventa_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_RefrescaControles();
            }
        }
    }
}
