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
    public partial class Frm_AyudaRegistrocompras : plantilla
    {
        public delegate void PasaCuentaDelegate(string regmes, string regdiario, string regnumero, string detalle);
        public PasaCuentaDelegate _PasaRegCompras;
        public string _Mes = "";
        //string j_TipDoc = "";
        bool sw_Load = true;
        DataTable tabla = new DataTable();
        DataTable tmptabla = new DataTable();
        string j_String = "";
        //bool sw_Select = false;
 
        public Frm_AyudaRegistrocompras()
        {
            InitializeComponent();
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            //DevExpress.Skins.SkinManager.EnableFormSkins();

            txtRuc.LostFocus += new System.EventHandler(txtRuc_LostFocus);
            txtRuc.GotFocus += new System.EventHandler(txtRuc_GotFocus);

            txtRegmes.LostFocus += new System.EventHandler(txtRegmes_LostFocus);
        }

        void llenar_cboTipocompra()
        {
            try
            {
                cboTipocompra.DataSource = NewMethodDoc();
                cboTipocompra.DisplayMember = "Value";
                cboTipocompra.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethodDoc()
        {
            tb_co_tipocomprasBL BL = new tb_co_tipocomprasBL();
            tb_co_tipocompras BE = new tb_co_tipocompras();

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

        private void Frm_AyudaRegistrocompras_Activated(object sender, EventArgs e)
        {
            if (sw_Load)
            {
                cboOrigen.SelectedIndex = 0;
                llenar_cboTipocompra();
                llenar_cboTipdoc();
                cboTipocompra.SelectedIndex = 0;
                sw_Load = false;
                U_CargaDatos();
            }
        }
        private void Frm_AyudaRegistrocompras_Load(object sender, EventArgs e)
        {
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            //DevExpress.Skins.SkinManager.EnableFormSkins();

            if ((_Mes.Trim().Length > 0))
            {
                chkRegmes.Checked = true;
                txtRegmes.Text = _Mes;
            }
            fechaIni.Value = Convert.ToDateTime(("01/" + (DateTime.Now.Month.ToString() + ("/" + DateTime.Now.Year.ToString()))));
            U_RefrescaControles();
            VariablesPublicas.PintaEncabezados(dgProveedor);
        }
        private void Frm_AyudaRegistrocompras_KeyDown(object sender, KeyEventArgs e)
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
            //celdaactual = dgProveedor.CurrentCell;
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

        private void chkFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_RefrescaControles();
            }
        }
        private void chkTipocompra_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_RefrescaControles();
            }
        }

        private void chkRuc_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_RefrescaControles();
            }
        }
        private void txtRuc_GotFocus(object sender, System.EventArgs e)
        {
            j_String = txtRuc.Text;
        }
        private void txtRuc_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_String == txtRuc.Text) & !sw_Load)
            {
                ValidaDetalle();
            }
        }
        private void txtRuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaProveedor();
            }
        }
        private void AyudaProveedor()
        {
            Frm_AyudaProveedor frmayuda = new Frm_AyudaProveedor();
            frmayuda.Owner = this;
            frmayuda.PasaProveedor = RecibeProveedor;
            frmayuda.ShowDialog();
        }
        private void RecibeProveedor(string xruc, string xnombre, string xdirec)
        {
            if (xruc.Trim().Length > 0)
            {
                txtRuc.Text = xruc;
                txtCtactename.Text = xnombre;
                U_CargaDatos();
            }
        }
        public void ValidaDetalle()
        {
            if (txtRuc.Text.Trim().Length > 0)
            {
                clienteBL BL = new clienteBL();
                tb_cliente BE = new tb_cliente();

                BE.nmruc = txtRuc.Text;
                DataTable tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                if (tmptabla.Rows.Count == 0)
                {
                    txtRuc.Text = j_String;
                }
                else
                {
                    //txtRuc.Text = tmptabla.Rows[0]["nmruc"].ToString();
                    txtCtactename.Text = tmptabla.Rows[0]["ctactename"].ToString();
                    U_CargaDatos();
                }
            }
            else
            {
                txtRuc.Text = j_String;
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

        private void chkTipdoc_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_RefrescaControles();
            }
        }
        //private void txtTipdoc_GotFocus(object sender, System.EventArgs e)
        //{
        //    j_TipDoc = txtTipdoc.Text;
        //}
        //private void txtTipdoc_LostFocus(object sender, System.EventArgs e)
        //{
        //    if (!(j_TipDoc == txtTipdoc.Text))
        //    {
        //        validaTipodocumento();
        //    }
        //}
        //private void txtTipdoc_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if ((e.KeyCode == Keys.F1))
        //    {
        //        AyudaTipoDocumento();
        //    }
        //}

        //private void AyudaTipoDocumento()
        //{
        //    Frm_AyudaTipoDocumentos frmayuda = new Frm_AyudaTipoDocumentos();
        //    frmayuda.Owner = this;
        //    frmayuda.Owner = this;
        //    //string xcodcuenta = "   ";
        //    //frmayuda._LpTipoDocu = GlobalVars.GetInstance.TipDocusCompras;
        //    frmayuda._PasaValor = RecibeTipoDocumento;
        //    frmayuda.ShowDialog();
        //}
        //private void RecibeTipoDocumento(string codigo)
        //{
        //    if ((codigo.Trim().Length > 0))
        //    {
        //        txtTipdoc.Text = codigo;
        //        validaTipodocumento();
        //    }
        //}
        //void validaTipodocumento()
        //{
        //    if ((txtTipdoc.Text.Trim().Length > 0))
        //    {
        //        txtTipdoc.Text = VariablesPublicas.PADL(txtTipdoc.Text.Trim(), txtTipdoc.MaxLength, "0");
        //        tb_co_tabla10_comprobantesBL BL = new tb_co_tabla10_comprobantesBL();
        //        tb_co_tabla10_comprobantes BE = new tb_co_tabla10_comprobantes();

        //        BE.codigoid = txtTipdoc.Text;
        //        DataTable tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
        //        if ((tmptabla.Rows.Count > 0))
        //        {
        //            txtDocname.Text = tmptabla.Rows[0]["descripcion"].ToString();
        //        }
        //    }
        //}

        private void txtGlosa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                U_SeleccionaRegistros();
            }
        }
        private void chkGlosa_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_Load)
            {
                U_RefrescaControles();
            }
        }

        private void chkOrigen_CheckedChanged(object sender, EventArgs e)
        {
            U_RefrescaControles();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            U_CargaDatos();
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            U_SeleccionaRegistros();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            _PasaRegCompras("", "", "", "");
            Close();
        }

        private void dgProveedor_DoubleClick(object sender, EventArgs e)
        {
            U_SeleccionaRegistros();
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
        private void dgProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            U_SeleccionaRegistros();
        }

        void U_CargaDatos()
        {
            string xpalabra4 = "";
            string xpalabra1 = "";
            string xpalabra2 = "";
            string xpalabra3 = "";
            string xtipocompra = "";
            if (cboTipocompra.Enabled)
            {
                if (!(cboTipocompra.SelectedValue == null))
                {
                    xtipocompra = cboTipocompra.SelectedValue.ToString();
                }
            }
            if (txtGlosa.Enabled)
            {
                xpalabra1 = VariablesPublicas.Palabras(txtGlosa.Text.Trim(), 1);
                xpalabra2 = VariablesPublicas.Palabras(txtGlosa.Text.Trim(), 2);
                xpalabra3 = VariablesPublicas.Palabras(txtGlosa.Text.Trim(), 3);
                xpalabra4 = VariablesPublicas.Palabras(txtGlosa.Text.Trim(), 4);
            }
            string xdetalle = "";
            string xfechaini = "";
            string xfechafin = "";
            if (fechaIni.Enabled)
            {
                xfechaini = Convert.ToDateTime(fechaIni.Text).ToString();
            }
            if (fechaFin.Enabled)
            {
                xfechafin = Convert.ToDateTime(fechaFin.Text).ToString();
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
            if (txtRuc.Enabled)
            {
                xdetalle = txtRuc.Text;
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
            string xtipdoc = "";
            if (cboTipdoc.Enabled)
            {
                xtipdoc = cboTipdoc.Text;
            }

            try
            {
                tb_co_ComprascabBL BL = new tb_co_ComprascabBL();
                tb_co_Comprascab BE = new tb_co_Comprascab();

                BE.perianio = VariablesPublicas.perianio;
                BE.perimes = xcodmes;
                //BE.diarioid = cboSubdiario.Text.Substring(0, 4);
                //BE.asiento = txtAsiento.Text;
                BE.nmruc = xdetalle;
                BE.tipodoc = xtipdoc;
                BE.origen = xorigen;
                BE.tipoid = xtipocompra;
                BE.glosa = xpalabra1;
            
                tabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //tabla = ocapa.CaeSoft_GetAllRegistroCompraCabecera(GlobalVars.GetInstance.Company, GlobalVars.GetInstance.Periodo, xcodmes, "", xfechaini, xfechafin, xdetalle, xpalabra1, xpalabra2, xpalabra3, xorigen, xtipdoc, xtipocompra);
            btnRefrescar.Enabled = true;
           
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
                if ((xnomcolumna.Trim().Length > 0))
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
        }

        void U_SeleccionaRegistros()
        {
            if (!(dgProveedor.CurrentRow == null))
            {
                //sw_Select = true;
                _PasaRegCompras(dgProveedor.Rows[dgProveedor.CurrentRow.Index].Cells["perimes"].Value.ToString(),
                                     dgProveedor.Rows[dgProveedor.CurrentRow.Index].Cells["diarioid"].Value.ToString(),
                                     dgProveedor.Rows[dgProveedor.CurrentRow.Index].Cells["asiento"].Value.ToString(), 
                                     dgProveedor.Rows[dgProveedor.CurrentRow.Index].Cells["nmruc"].Value.ToString());
                Close();
            }
        }

        void U_RefrescaControles()
        {
            cboTipocompra.Enabled = chkTipocompra.Checked;
            cboTipdoc.Enabled = chkTipdoc.Checked;
            //txtDocname.Enabled = false;
            cboOrigen.Enabled = chkOrigen.Checked;
            txtGlosa.Enabled = chkGlosa.Checked;
            txtRegmes.Enabled = chkRegmes.Checked;
            txtRuc.Enabled = chkRuc.Checked;
            fechaIni.Enabled = chkFechas.Checked;
            fechaFin.Enabled = chkFechas.Checked;
            txtCtactename.Enabled = false;
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
    }
}
