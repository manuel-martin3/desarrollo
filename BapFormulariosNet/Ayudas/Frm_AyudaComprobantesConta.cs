using System;
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

namespace BapFormulariosNet.Ayudas
{
    public partial class Frm_AyudaComprobantesConta : Form
    {
        public delegate void PasaComprobanteContaDelegate(string xperiodo, string xperimes, string xmoduloid, string xlocal, string xdiarioid, string xasiento);

        #region "Fields"
        //private  _ccia = GlobalVars.GetInstance.Company();
        private string _periodo = VariablesPublicas.perianio;
        public PasaComprobanteContaDelegate PasaComprobanteConta;
        public string _TipComprobante = string.Empty;
        public bool _Tesoreria = false;
        public bool _Contabilidad = false;
        public bool _SeleccionaTipoComprobante = false;
        bool sw_load = true;
	    #endregion
        
        public Frm_AyudaComprobantesConta()
        {
            InitializeComponent();

            Load += Frm_AyudaComprobantesConta_Load;
            KeyDown += Frm_AyudaComprobantesConta_KeyDown;
            Activated += Frm_AyudaComprobantesConta_Activated;
        }

        void llenar_cboSubdiario()
        {
            try
            {
                cboSubdiario.DataSource = NewMethod();
                cboSubdiario.DisplayMember = "Value";
                cboSubdiario.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethod()
        {
            tb_co_tipodiarioBL BL = new tb_co_tipodiarioBL();
            tb_co_tipodiario BE = new tb_co_tipodiario();

            BE.perianio = VariablesPublicas.perianio;
            if (_Contabilidad & _Tesoreria)
            {
                BE.contabilidad = true;
                BE.tesoreria = true;
            }
            else
            {
                if (_Contabilidad)
                {
                    BE.contabilidad = true;
                }
                else
                {
                    BE.tesoreria = true;
                }
            }

            DataTable table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            DataRowCollection rows = table.Rows;

            object[] cell;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            BindingSource binding = new BindingSource();

            foreach (DataRow item in rows)
            {
                cell = item.ItemArray;
                dic.Add(cell[1].ToString(), cell[1].ToString() + " - " + cell[3].ToString());
                cell = null;
            }
            binding.DataSource = dic;
            return binding;
        }

        void llenar_cboToperacion()
        {
            try
            {
                cboTipooperacion.DataSource = NewMethodOp();
                cboTipooperacion.DisplayMember = "Value";
                cboTipooperacion.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethodOp()
        {
            tb_co_OperacionescontabilidadBL BL = new tb_co_OperacionescontabilidadBL();
            tb_co_Operacionescontabilidad BE = new tb_co_Operacionescontabilidad();

            DataTable table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            DataRowCollection rows = table.Rows;

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
        //private void CargarCombo()
        //{
        //    this.cboSubdiario.DisplayMember = "descripcion";
        //    this.cboSubdiario.ValueMember = "codigo";
        //    int nfiltrodocu = 0;
        //    if (this._Contabilidad & this._Tesoreria)
        //    {
        //        nfiltrodocu = GlobalVars.GetInstance.TipoDocumentoContableTesoreriaContabilidad;
        //    }
        //    else
        //    {
        //        if (this._Contabilidad)
        //        {
        //            nfiltrodocu = GlobalVars.GetInstance.TipoDocumentoContableContabilidad;
        //        }
        //        else
        //        {
        //            nfiltrodocu = GlobalVars.GetInstance.TipoDocumentoContableTesoreria;
        //        }
        //    }
        //    this.cboSubdiario.DataSource = ocapa.CaeSoft_GetAllDocumentosContabilidad(GlobalVars.GetInstance.Company, "", "", 2, nfiltrodocu, "", "", "");

        //    this.cmbtipooperacion.DisplayMember = "toc_descripcion";
        //    this.cmbtipooperacion.ValueMember = "toc_codigo";
        //    this.cmbtipooperacion.DataSource = ocapa.tipooperacioncontable_consulta("", 2);
        //    if (this._TipComprobante == string.Empty)
        //    {
        //    }
        //    else
        //    {
        //        this.cboSubdiario.SelectedValue = _TipComprobante;
        //    }
        //}

        private void Frm_AyudaComprobantesConta_Activated(object sender, EventArgs e)
        {
            if (sw_load)
            {              
                u_CargaData();
                sw_load = false;
                if (dgComprobantesConta.Rows.Count > 0)
                {
                    dgComprobantesConta.Focus();
                    dgComprobantesConta.BeginEdit(true);
                }
            }
            Fecha1.Value = Convert.ToDateTime("01/01/" + VariablesPublicas.perianio);
        }
        private void Frm_AyudaComprobantesConta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCerrar_Click(sender, e);
            }
        }
        private void Frm_AyudaComprobantesConta_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Sizable;
            ControlBox = true;
            llenar_cboSubdiario();
            llenar_cboToperacion();       
            if (_TipComprobante.Trim().Length > 0)
            {
                chktipocomprobante.Checked = true;
                cboSubdiario.SelectedValue = _TipComprobante;
            }
            u_refrescaControles();
        }

        private void cboSubdiario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!sw_load)
            {
                u_CargaData();
            }
        }

        private void dgComprobantesConta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            u_SeleccionaRegistro();
        }

        private void dgComprobantesConta_KeyDown(object sender, KeyEventArgs e)
        {
            string at = string.Empty;
            Keys k = default(Keys);
            k = e.KeyCode;
            switch (k)
            {
                case Keys.Enter:
                    u_SeleccionaRegistro();
                    break;
                default:
                    break;
            }
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            u_SeleccionaRegistro();
        }

        public void u_SeleccionaRegistro()
        {
            if (dgComprobantesConta.CurrentRow != null)
            {
                PasaComprobanteConta(dgComprobantesConta.Rows[dgComprobantesConta.CurrentRow.Index].Cells["perianio"].Value.ToString().Trim(), 
                                          dgComprobantesConta.Rows[dgComprobantesConta.CurrentRow.Index].Cells["perimes"].Value.ToString().Trim(),
                                          dgComprobantesConta.Rows[dgComprobantesConta.CurrentRow.Index].Cells["moduloid"].Value.ToString().Trim(),
                                          dgComprobantesConta.Rows[dgComprobantesConta.CurrentRow.Index].Cells["local"].Value.ToString().Trim(),
                                          dgComprobantesConta.Rows[dgComprobantesConta.CurrentRow.Index].Cells["diarioid"].Value.ToString().Trim(), 
                                          dgComprobantesConta.Rows[dgComprobantesConta.CurrentRow.Index].Cells["asiento"].Value.ToString().Trim());
                Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkFechas_CheckedChanged(object sender, EventArgs e)
        {
            u_refrescaControles();
        }

        public void u_refrescaControles()
        {
            cboTipooperacion.Enabled = chktipooperacion.Checked;
            Fecha1.Enabled = chkFechas.Checked;
            Fecha2.Enabled = chkFechas.Checked;
            chktipocomprobante.Enabled = _SeleccionaTipoComprobante;
            if (_SeleccionaTipoComprobante)
            {
                cboSubdiario.Enabled = chktipocomprobante.Checked;
            }
            else
            {
                cboSubdiario.Enabled = _TipComprobante.Trim().Length == 0 & chktipocomprobante.Checked;
            }
        }
        
        public void u_CargaData()
        {
            SortOrder sorted = default(SortOrder);
            string xnomcolumna = "";
            if ((dgComprobantesConta.SortedColumn != null))
            {
                xnomcolumna = dgComprobantesConta.Columns[dgComprobantesConta.SortedColumn.Index].Name;
                sorted = dgComprobantesConta.SortOrder;
            }

            if (cboSubdiario.SelectedIndex > -1)
            {
                lbCodigo.Text = cboSubdiario.SelectedValue.ToString().Trim();
            }
            else
            {
                lbCodigo.Text = "";
            }

            DataTable oData = null;
            string xfecha1 = "";
            string xfecha2 = "";
            string xtipocomprobante = "";
            if (Fecha1.Enabled)
            {
                xfecha1 = VariablesPublicas.DTOS(Fecha1.Value);
            }
            if (Fecha2.Enabled)
            {
                xfecha2 = VariablesPublicas.DTOS(Fecha2.Value);
            }
            if (cboSubdiario.Enabled)
            {
                if ((cboSubdiario.SelectedValue != null))
                {
                    xtipocomprobante = cboSubdiario.SelectedValue.ToString();
                }
            }
            else
            {
                if (_TipComprobante.Trim().Length > 0 & !chktipocomprobante.Enabled)
                {
                    xtipocomprobante = _TipComprobante.Trim();
                }
            }
            string xtipooperacion = "";
            if (cboTipooperacion.Enabled)
            {
                if (cboTipooperacion.SelectedValue != null)
                {
                    xtipooperacion = cboTipooperacion.SelectedValue.ToString();
                }
            }
            tb_co_MovimientoscabBL BL = new tb_co_MovimientoscabBL();
            tb_co_Movimientoscab BE = new tb_co_Movimientoscab();

            BE.perianio = VariablesPublicas.perianio;
            //BE.perimes = this.txtMes.Text;
            BE.diarioid = xtipocomprobante;
            //BE.asiento = this.txtAsiento.Text;
            BE.tipooperacion = xtipooperacion;
            try
            {
                oData = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //oData = ocapa.CaeSoft_GetAllCabeceraMovimientosContables(GlobalVars.GetInstance.Company, GlobalVars.GetInstance.Periodo, xtipocomprobante, "", "", xfecha1, xfecha2, (this._Contabilidad ? 1 : 0), (this._Tesoreria ? 1 : 0), (this._Tesoreria & this._Contabilidad ? 1 : 0), xtipooperacion);
            //if (ocapa.sql_error.Length == 0)
            //{
                dgComprobantesConta.AutoGenerateColumns = false;
                dgComprobantesConta.DataSource = oData;
                if (xnomcolumna.Trim().Length > 0)
                {
                    if (sorted == SortOrder.Ascending)
                    {
                        dgComprobantesConta.Sort(dgComprobantesConta.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Ascending);
                    }
                    else
                    {
                        dgComprobantesConta.Sort(dgComprobantesConta.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Descending);

                    }
                }
                else
                {
                    dgComprobantesConta.Sort(dgComprobantesConta.Columns["fechregistro"], System.ComponentModel.ListSortDirection.Descending);
                }
            //}
            //else
            //{
            //    ERP_CAESOFT_FORMS.frmclass.ShowError(ocapa.sql_error, this);
            //}
        }

        private void btnrefrescar_Click(object sender, EventArgs e)
        {
            u_CargaData();
        }

        private void chktipooperacion_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_load)
            {
                u_refrescaControles();
            }
        }

        private void chktipocomprobante_CheckedChanged(object sender, EventArgs e)
        {
            u_refrescaControles();
        }
    }
}
