using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using BapFormulariosNet.Seguridadlog;
using BapFormulariosNet.Ayudas;
using BapFormulariosNet.D20Comercial.Ayudas;
//using BapFormulariosNet.D20Comercial.Contabilidad;
//using BapFormulariosNet.D20Comercial.ReportesContabilidad;
using BapFormulariosNet.Codigo;

namespace BapFormulariosNet.D20Comercial
{
    public partial class Frm_CanjeLetrasMovimiento : plantilla
    {
        DataTable CabFacturacion = new DataTable();
        DataTable DetFacturacion = new DataTable();
        DataTable DetMovimiento = new DataTable();

        DataTable DetLetras = new DataTable();
        DataTable letradet = new DataTable();
        // Parámetros
        public string _Mes = "";
        public string _Registro = "";
        public bool _Tesoreria = true;
        public bool _Contabilidad = true;
        public string _Codvoucher = "";
        //bool sELECCIONAaYUDA = false;

        int lc_contador = 0;
        int lc_contLetras = 0;
        int filasaimprimir = 0;

        string j_txtnumpagoinicial = "";
        string j_txttotletras = "";
        string j_detalle = "";
        private string j_Ctacte = "";
        string j_dfreferencia = "";
        public bool _LpVariosDetalles = false;
        string _NameCOlumna = "";
        bool SwsELECCIONAaYUDA = false;
        // Uso esto para que no se ejecuten eventos de interactive change cuando se cambia x codigo
        //bool zinteractivechange = true;

        bool sw_novaluechange = false;
        // controla si 1 ADICION 2 MODIFICACION
        private int u_n_opsel = 0;
        private string j_String = "";
        private bool sw_load = true;
        private string W_KEY0001 = "";

        private TextBox txtCArti = null;
        DataTable tmptablacab = new DataTable();
        DataTable tmptabladet = new DataTable();
        DataTable tmptabla = new DataTable();
        //string xnum;
        //Variables de Identidad del Cliente
        private string xtipopersona = "";
        private string xtipodocidentidad = "";
        private string xctacte = "";
        private string xdirec = "";
        private string xubige = "";
        private string xBanco = "";
        private string xctacteaval = "";
        int n_contador;
        decimal sumadebesoles = 0;
        decimal sumahabersoles = 0;
        decimal sumadebedolares = 0;
        decimal sumahaberdolares = 0;

        //private string xDiarioid = "1700";

        public Frm_CanjeLetrasMovimiento()
        {
            InitializeComponent();

            txtMes.LostFocus += new System.EventHandler(txtMes_LostFocus);
            txtMes.GotFocus += new System.EventHandler(txtMes_GotFocus);
            txtAsiento.GotFocus += new System.EventHandler(txtAsiento_GotFocus);

            txtRuc.LostFocus += new System.EventHandler(txtRuc_LostFocus);
            txtRuc.GotFocus += new System.EventHandler(txtRuc_GotFocus);

            txtRucAval.LostFocus += new System.EventHandler(txtRucAval_LostFocus);
            txtRucAval.GotFocus += new System.EventHandler(txtRucAval_GotFocus);

            txtTipdoc.LostFocus += new System.EventHandler(txtTipdoc_LostFocus);
            txtSerdoc.LostFocus += new System.EventHandler(txtSerdoc_LostFocus);
            //txtNumdoc.LostFocus += new System.EventHandler(txtNumdoc_LostFocus);
            ////txtNumOpe.LostFocus += new System.EventHandler(txtNumOpe_LostFocus);

            txtCantlet.LostFocus += new System.EventHandler(txtCantlet_LostFocus);
            txtCantlet.GotFocus += new System.EventHandler(txtCantlet_GotFocus);

            txtNumdoc.LostFocus += new System.EventHandler(txtNumdoc_LostFocus);
            txtNumdoc.GotFocus += new System.EventHandler(txtNumdoc_GotFocus);

            tmptablacab = null;
            tmptabladet = null;
            letradet = null;
        }

        #region "Llenado de Combobox"
        private void llenar_cboSubdiario()
        {
            try
            {
                cboSubdiario.DataSource = NewMethod();
                cboSubdiario.DisplayMember = "Value";
                cboSubdiario.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethod()
        {
            tb_co_tipodiarioBL BL = new tb_co_tipodiarioBL();
            tb_co_tipodiario BE = new tb_co_tipodiario();

            BE.perianio = VariablesPublicas.perianio;
            BE.canjeletra = true;
            //BE.diarioid = xDiarioid;

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

        private void llenar_cboMonedaO()
        {
            try
            {
                cboMoneda.DataSource = NewMethodMonedaO();
                cboMoneda.DisplayMember = "Value";
                cboMoneda.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethodMonedaO()
        {
            tb_co_tabla04_tipomonedaBL BL = new tb_co_tabla04_tipomonedaBL();
            tb_co_tabla04_tipomoneda BE = new tb_co_tabla04_tipomoneda();

            DataTable table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            DataRowCollection rows = table.Rows;

            object[] cell;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            BindingSource binding = new BindingSource();

            foreach (DataRow item in rows)
            {
                cell = item.ItemArray;
                dic.Add(cell[0].ToString(), cell[0].ToString() + " - " + cell[3].ToString());
                cell = null;
            }
            binding.DataSource = dic;
            return binding;
        }

        //private void llenar_cboMonedaP()
        //{
        //    try
        //    {
        //        cboMonedaP.DataSource = NewMethodMonedaP();
        //        cboMonedaP.DisplayMember = "Value";
        //        cboMonedaP.ValueMember = "Key";
        //    }
        //    catch (Exception ex)
        //    {
        //        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        //private BindingSource NewMethodMonedaP()
        //{
        //    tb_co_tabla04_tipomonedaBL BL = new tb_co_tabla04_tipomonedaBL();
        //    tb_co_tabla04_tipomoneda BE = new tb_co_tabla04_tipomoneda();

        //    DataTable table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
        //    DataRowCollection rows = table.Rows;

        //    object[] cell;
        //    Dictionary<string, string> dic = new Dictionary<string, string>();
        //    BindingSource binding = new BindingSource();

        //    foreach (DataRow item in rows)
        //    {
        //        cell = item.ItemArray;
        //        dic.Add(cell[0].ToString(), cell[0].ToString() + " - " + cell[3].ToString());
        //        cell = null;
        //    }
        //    binding.DataSource = dic;
        //    return binding;
        //}

        //void llenar_cboTcambuso()
        //{
        //try
        //{
        //    cboTcamuso.DataSource = NewMethodTcamb();
        //    cboTcamuso.DisplayMember = "Value";
        //    cboTcamuso.ValueMember = "Key";
        //}
        //catch (Exception ex)
        //{
        //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}
        //}
        //private BindingSource NewMethodTcamb()
        //{
        //    tb_co_percepcionesBL BL = new tb_co_percepcionesBL();
        //    tb_co_percepciones BE = new tb_co_percepciones();

        //    DataTable table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
        //    DataRowCollection rows = table.Rows;

        //    object[] cell;
        //    Dictionary<string, string> dic = new Dictionary<string, string>();
        //    BindingSource binding = new BindingSource();

        //    foreach (DataRow item in rows)
        //    {
        //        cell = item.ItemArray;
        //        dic.Add(cell[0].ToString(), cell[0].ToString() + "  (" + cell[2].ToString() + "%) -  " + cell[1].ToString());
        //        cell = null;
        //    }
        //    binding.DataSource = dic;
        //    return binding;
        //}

        private void llenar_cboFormapago()
        {
            try
            {
                cboMedioPago.DataSource = NewMethodFpago();
                cboMedioPago.DisplayMember = "Value";
                cboMedioPago.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethodFpago()
        {
            tb_co_tabla01_mediopagoBL BL = new tb_co_tabla01_mediopagoBL();
            tb_co_tabla01_mediopago BE = new tb_co_tabla01_mediopago();

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
        #endregion

        private void Frm_CanjeLetrasMovimiento_Activated(object sender, EventArgs e)
        {
            if (sw_load)
            {
                llenar_cboSubdiario();
                //llenar_cboSubdiarioB();
                llenar_cboMonedaO();
                //llenar_cboMonedaP();
                llenar_cboFormapago();

                txtPeriodo.Value = Convert.ToDecimal(VariablesPublicas.perianio);
                fRegistro.Value = DateTime.Now;
                fecVenc.Value = DateTime.Now;

                //fRegistro.Value = DateTime.Now;
                dtpVctoap.Value = DateTime.Now;
                txtMes.Focus();

                UltimoNumeroRegistro();
                refrescacontroles();

                if (_Registro.Length > 0)
                {
                    txtMes.Text = _Mes;
                    txtAsiento.Text = _Registro;
                    CargaDatos();
                }
                sw_load = false;
            }
        }
        private void Frm_CanjeLetrasMovimiento_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (u_n_opsel > 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Finalice edición para cerrar formulario", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
        private void Frm_CanjeLetrasMovimiento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (btnEdit.Enabled)
                {
                    btnEdit_Click(sender, e);
                }
            }
            if (e.KeyCode == Keys.F8)
            {
                if (btnDelete.Enabled)
                {
                    btnDelete_Click(sender, e);
                }
            }
            if (e.Control & (e.KeyCode == Keys.G))
            {
                if (btnSave.Enabled)
                {
                    btnSave_Click(sender, e);
                    //Grabar(false);
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (btnRetro.Enabled)
                {
                    U_CancelarEdicion(1);
                }
                else
                {
                    btnExit_Click(sender, e);
                }
            }
            if (e.KeyCode == Keys.F5)
            {
                if (btnLoad.Enabled)
                {
                    Accion(5, "", "");
                }
            }
            if ((e.KeyCode == Keys.F2) & btnNew.Enabled)
            {
                btnNew_Click(sender, e);
            }

            if (e.Control & (e.KeyCode == Keys.Delete) & (!Examinar.IsCurrentCellInEditMode & btnDelFila.Enabled))
            {
                btnDelFila_Click(sender, e);
            }
            if (e.Control & (e.KeyCode == Keys.B))
            {
                AyudaRetenciones(0);
            }
            if (e.KeyCode == Keys.F6)
            {
                btnPrint_Click(sender, e);
            }
        }
        private void Frm_CanjeLetrasMovimiento_Load(object sender, EventArgs e)
        {
            VariablesPublicas.PintaEncabezados(Examinar);
            txtMes.Text = VariablesPublicas.PADL(DateTime.Now.Month.ToString(), 2, "0");
            Decimal _porcRetencion1 = TasaRretencion();
            btnCalcular.Text = "Cálcular Retención " + _porcRetencion1.ToString("##.00") + "% - IGV";

            refrescacontroles("load");
        }

        #region Metodos MANTENIMIENTO DE ASIENTO
        private void txtMes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                j_String = "..";
                txtAsiento.Focus();
            }
        }
        private void txtMes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                procesanumero();
            }
            if (((e.KeyChar) >= '0' & e.KeyChar <= '9') & !(e.KeyChar == '.'))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back | e.KeyChar == (char)Keys.Delete & !(e.KeyChar == '.'))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
        private void txtMes_GotFocus(object sender, System.EventArgs e)
        {
            j_String = txtMes.Text.Trim();
        }
        private void txtMes_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_String == txtMes.Text.Trim()) & u_n_opsel == 0)
            {
                txtMes.Text = (txtMes.Text.Trim().Length == 0 ? j_String : VariablesPublicas.PADL(txtMes.Text.Trim(), 2, "0"));
                UltimoNumeroRegistro();
                blanquear(false);
                refrescacontroles("Deshacer");
            }
        }

        private void txtAsiento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("\t");
            }
        }
        private void txtAsiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                procesanumero();
            }
            if ((e.KeyChar) >= '0' & e.KeyChar <= '9' & !(e.KeyChar == '.'))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back | e.KeyChar == (char)Keys.Delete & !(e.KeyChar == '.'))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
        private void txtAsiento_GotFocus(object sender, System.EventArgs e)
        {
            if (u_n_opsel == 0)
            {
                if (!SwsELECCIONAaYUDA)
                {
                    UltimoNumeroRegistro();
                    CargaDatos();
                }
                else
                {
                    SwsELECCIONAaYUDA = false;
                }
            }
        }
        #endregion

        private void procesanumero()
        {
            //SubDiarioRetencion();
            //SubDiarioCajaBancos();
            bool zprocede = false;
            if (VariablesPublicas.StringtoDecimal(txtMes.Text) > 0 & VariablesPublicas.StringtoDecimal(txtAsiento.Text) > 0)
            {
                zprocede = true;
            }
            if (zprocede)
            {
                txtAsiento.Text = VariablesPublicas.PADL(txtAsiento.Text.Trim(), txtAsiento.MaxLength, "0");
                CargaDatos();
                refrescacontroles("Deshacer");
                if (CabFacturacion.Rows.Count == 0)
                {
                    u_n_opsel = 1;
                    refrescacontroles();
                    blanquear(true);
                    actualizatipocambio();
                    //NumeracionComprobante();
                    //rbnPagos.Checked = true;
                    txtRuc.Focus();
                }
            }
            else
            {
                if (VariablesPublicas.StringtoDecimal(txtMes.Text) == 0)
                {
                    txtMes.Text = VariablesPublicas.PADL(DateTime.Now.Month.ToString(), 2, "0");
                }
                if (VariablesPublicas.StringtoDecimal(txtAsiento.Text) == 0)
                {
                    UltimoNumeroRegistro();
                }
            }
        }
        public void UltimoNumeroRegistro()
        {
            tb_co_retencionescabBL BL = new tb_co_retencionescabBL();
            tb_co_retencionescab BE = new tb_co_retencionescab();

            BE.perianio = VariablesPublicas.perianio;
            BE.perimes = txtMes.Text;
            BE.moduloid = VariablesDominio.VarTesoreria.Moduloid;
            BE.local = VariablesDominio.VarTesoreria.Local;
            BE.diarioid = cboSubdiario.SelectedValue.ToString();

            try
            {
                txtAsiento.Text = BL.GetAsientoNume(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0].Rows[0]["asiento"].ToString();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refrescacontroles(string pEvento = null)
        {
            btnInicio.Enabled = u_n_opsel == 0;
            btnAnterior.Enabled = u_n_opsel == 0;
            btnSiguiente.Enabled = u_n_opsel == 0;
            btnFinal.Enabled = u_n_opsel == 0;

            string xcondedor = "";
            //string xnroitem = "";
            if (CabFacturacion != null)
            {
                if (CabFacturacion.Rows.Count > 0)
                {
                    xcondedor = CabFacturacion.Rows[0]["asiento"].ToString().Trim();
                }
            }
            Examinar.ReadOnly = u_n_opsel == 0;
            Examinar.Columns["cuentaid"].ReadOnly = true;
            Examinar.Columns["tipdoc"].ReadOnly = true;
            Examinar.Columns["serdoc"].ReadOnly = true;
            Examinar.Columns["numdoc"].ReadOnly = true;
            Examinar.Columns["fechdoc"].ReadOnly = false;
            Examinar.Columns["fechvcto"].ReadOnly = true;
            Examinar.Columns["moneda"].ReadOnly = true;
            Examinar.Columns["tipcamb"].ReadOnly = true;
            Examinar.Columns["tipcambuso"].ReadOnly = true;
            Examinar.Columns["importeorigensoles"].ReadOnly = true;
            Examinar.Columns["importeorigendolares"].ReadOnly = true;
            Examinar.Columns["importedifcambio"].ReadOnly = true;
            Examinar.Columns["importeorigen"].ReadOnly = true;   //ojo activado
            Examinar.Columns["importepago"].ReadOnly = false;
            Examinar.Columns["tasa"].ReadOnly = true;
            Examinar.Columns["importeretencionsoles"].ReadOnly = false; //ojo activado
            //btnBuscardetalles.Enabled = false;
            //if (Examinar.CurrentRow != null)
            //{
            //    btnBuscardetalles.Enabled = true;
            //    if (Examinar.Rows[Examinar.CurrentRow.Index].Cells["statusdestino"].ToString() == "1")
            //    {
            //        Examinar.ReadOnly = true;
            //    }
            //}

            //if (pEvento == "Deshacer") { cboPtoemision.Enabled = false; btnEstablecimiento.Enabled = false; } else { cboPtoemision.Enabled = u_n_opsel == 0; btnEstablecimiento.Enabled = u_n_opsel == 0; }

            txtPeriodo.Enabled = false;
            chkActivo.Enabled = u_n_opsel > 0;
            btnPllaLetras.Enabled = u_n_opsel > 0;

            //txtMes.Enabled = u_n_opsel == 0 & btnEstablecimiento.Enabled == false;
            //txtAsiento.Enabled = u_n_opsel == 0 & btnEstablecimiento.Enabled == false;

            txtMes.Enabled = u_n_opsel == 0; //&btnEstablecimiento.Enabled == false;
            txtAsiento.Enabled = u_n_opsel == 0; //&btnEstablecimiento.Enabled == false;

            cboSubdiario.Enabled = false;
            //txtCuentanameR.Enabled = false;
            //gpoModo.Enabled = u_n_opsel > 0;

            txtCuentaname.Enabled = false;

            //cboTipdoc.Enabled = false;
            //txtSerie.Enabled = false;//u_n_opsel > 0;
            //txtNumero.Enabled = false;//u_n_opsel > 0;
            txtRuc.Enabled = u_n_opsel > 0;
            txtCtactename.Enabled = false;
            btnGenerar.Enabled = u_n_opsel > 0;
            //txtDireccion.Enabled = false;
            //cboDpto.Enabled = false;
            //cboProv.Enabled = false;
            //cboDistr.Enabled = false;
            fRegistro.Enabled = u_n_opsel > 0;
            cboMoneda.Enabled = false;
            cboTcamuso.Enabled = false;
            txtTipocambio.Enabled = false;
            //txtTipocambio.Enabled = u_n_opsel > 0 & n_OperacionTesoreria == 1;
            fecVenc.Enabled = u_n_opsel > 0;
            txtGlosa.Enabled = u_n_opsel > 0;
            //dpTasa.Enabled = false; // u_n_opsel > 0;
            //dpTasa.Checked = false;
            btnCalcular.Enabled = u_n_opsel > 0;
            //cboMonedaP.Enabled = u_n_opsel > 0;
            //cboFlujoefectivo.Enabled = false;
            //if (rbnPagos.Checked)
            //{
            //    cboSubdiarioP.Enabled = u_n_opsel > 0;
            //    txtNumOpe.Enabled = u_n_opsel > 0;
            //    //Operaciones de Caja y Bancos               
                cboMedioPago.Enabled = u_n_opsel > 0;
            //}

            if (DetFacturacion != null)
            {
                btnDelFila.Enabled = DetFacturacion.Rows.Count > 0 & u_n_opsel > 0;
            }
            else
            {
                btnDelFila.Enabled = false;
            }

            #region Toolbar Botones Principales

            if (pEvento == "load") { btnNew.Enabled = false; } else { btnNew.Enabled = u_n_opsel == 0; }

            if (CabFacturacion == null)
            {
                btnEdit.Enabled = false;
            }
            else
            {
                btnEdit.Enabled = u_n_opsel == 0 & CabFacturacion.Rows.Count > 0;
            }

            if (CabFacturacion == null)
            {
                btnDelete.Enabled = false;
            }
            else
            {
                btnDelete.Enabled = u_n_opsel == 0 & CabFacturacion.Rows.Count > 0;
            }

            btnSave.Enabled = u_n_opsel > 0;
            btnRetro.Enabled = u_n_opsel > 0;
            btnPrint.Enabled = u_n_opsel == 0 & xcondedor.Trim().Length > 0;
            btnVoucher.Enabled = u_n_opsel == 0 & xcondedor.Trim().Length > 0;
            #endregion

            btnLoad.Enabled = u_n_opsel == 0;
            btnExit.Enabled = u_n_opsel == 0;
            btnLog.Enabled = u_n_opsel == 0 & xcondedor.Trim().Length > 0;
            btnBusqueda.Enabled = u_n_opsel == 0;
            btnBuscar.Enabled = u_n_opsel == 0;

            txtRegistros.Enabled = false;
            txtImpOrigen.Enabled = false;
            txtImpPago.Enabled = false;
            txtImpRetencion.Enabled = false;

            //Datos para Canje de Letras
            btnPllaLetras.Enabled = u_n_opsel > 0; //&rbnLetras.Checked;
            txtCantlet.Enabled = u_n_opsel > 0; //&rbnLetras.Checked;
            dtpVctoap.Enabled = u_n_opsel > 0; //&rbnLetras.Checked;
            txtDias.Enabled = u_n_opsel > 0; //&rbnLetras.Checked;
            txtTipdoc.Enabled = false;
            txtSerdoc.Enabled = u_n_opsel > 0; //&rbnLetras.Checked;
            txtNumdoc.Enabled = u_n_opsel > 0; //&rbnLetras.Checked;
            txtImportesoles.Enabled = false;
            txtImportedolares.Enabled = false;
            btnGenletras.Enabled = u_n_opsel > 0 & txtCantlet.Enabled;
            txtRucAval.Enabled = u_n_opsel > 0; //&rbnLetras.Checked;
            txtCtactenameAval.Enabled = false;
            txtLetrasoles.Enabled = false;
            txtLetraDolares.Enabled = false;
            txtDireccionAval.Enabled = false;
            txtTelefAval.Enabled = u_n_opsel > 0; //&rbnLetras.Checked;
            txtConcepto.Enabled = false;
            txtReferencia.Enabled = u_n_opsel > 0; //&rbnLetras.Checked;
            txtDiarioletra.Enabled = u_n_opsel > 0; //&rbnLetras.Checked;
            txtDdiarioletra.Enabled = false;
            txtLugargiro.Enabled = u_n_opsel > 0; //&rbnLetras.Checked;
            btnImprimeLetras.Enabled = u_n_opsel > 0 & txtCantlet.Enabled;

        }
        private void CargaDatos()
        {
            string xnumero = "..";
            if (txtAsiento.Text.Trim().Length > 0)
            {
                xnumero = txtAsiento.Text;
            }
            if (tmptablacab != null)
            {
                CabFacturacion = tmptablacab;
            }
            else
            {
                tb_co_canjeletracabBL BL = new tb_co_canjeletracabBL();
                tb_co_canjeletracab BE = new tb_co_canjeletracab();

                //tb_co_retencionescabBL BL = new tb_co_retencionescabBL();
                //tb_co_retencionescab BE = new tb_co_retencionescab();

                BE.perianio = VariablesPublicas.perianio;
                BE.perimes = txtMes.Text;
                BE.moduloid = VariablesDominio.VarTesoreria.Moduloid;
                BE.local = VariablesDominio.VarTesoreria.Local;
                BE.diarioid = cboSubdiario.SelectedValue.ToString();
                BE.asiento = txtAsiento.Text;
                try
                {
                    CabFacturacion = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (tmptabladet != null)
            {
                DetFacturacion = tmptabladet;
            }
            else
            {
                tb_co_retencionesdetBL BL = new tb_co_retencionesdetBL();
                tb_co_retencionesdet BE = new tb_co_retencionesdet();

                BE.perianio = VariablesPublicas.perianio;
                BE.perimes = txtMes.Text;
                BE.moduloid = VariablesDominio.VarTesoreria.Moduloid;
                BE.local = VariablesDominio.VarTesoreria.Local;
                BE.diarioid = cboSubdiario.SelectedValue.ToString();
                BE.asiento = txtAsiento.Text;
                try
                {
                    DetFacturacion = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                    DetFacturacion.Columns.Add(new DataColumn("tasa"));
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (letradet != null)
            {
                DetLetras = letradet;
            }
            else
            {
                tb_co_canjeletradetBL BL = new tb_co_canjeletradetBL();
                tb_co_canjeletradet BE = new tb_co_canjeletradet();

                BE.perianio = VariablesPublicas.perianio;
                BE.perimes = txtMes.Text;
                BE.moduloid = VariablesDominio.VarTesoreria.Moduloid;
                BE.local = VariablesDominio.VarTesoreria.Local;
                BE.diarioid = cboSubdiario.SelectedValue.ToString();
                BE.asiento = txtAsiento.Text;
                try
                {
                    DetLetras = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (CabFacturacion != null)
            {
            }
            if (CabFacturacion.Rows.Count > 0)
            {
                if (CabFacturacion.Rows[0]["status"].ToString() == "0")
                {
                    chkActivo.Checked = true;
                }
                else
                {
                    chkActivo.Checked = false;
                }
                //if (CabFacturacion.Rows[0]["tiporegistro"].ToString() == "1")
                //{
                //    rbnPagos.Checked = true;
                //    rbnEmision.Checked = false;
                //    rbnLetras.Checked = false;
                //}
                //else
                //{
                //    if (CabFacturacion.Rows[0]["tiporegistro"].ToString() == "2")
                //    {
                //        rbnPagos.Checked = false;
                //        rbnEmision.Checked = true;
                //        rbnLetras.Checked = false;
                //    }
                //    else
                //    {
                //        if (CabFacturacion.Rows[0]["tiporegistro"].ToString() == "3")
                //        {
                //            rbnPagos.Checked = false;
                //            rbnEmision.Checked = false;
                //            rbnLetras.Checked = true;
                //        }
                //    }
                //}
                txtRuc.Text = CabFacturacion.Rows[0]["nmruc"].ToString();
                ValidaProveedor();
                txtTipdoc.Text = CabFacturacion.Rows[0]["tipdoc"].ToString().Trim();
                txtSerdoc.Text = CabFacturacion.Rows[0]["serdoc"].ToString().Trim();
                txtNumdoc.Text = CabFacturacion.Rows[0]["numdoc"].ToString().Trim();
                //cboFlujoefectivo.SelectedValue = CabFacturacion.Rows[0]["flujoefectivo"];

                fRegistro.Value = Convert.ToDateTime(CabFacturacion.Rows[0]["fechdoc"]);
                Decimal _porcRetenciony = TasaRretencion();
                btnCalcular.Text = "Cálcular Retención " + _porcRetenciony.ToString("##.00") + "% - IGV";

                fecVenc.Value = Convert.ToDateTime(CabFacturacion.Rows[0]["fechvcto"]);
                //cboSubdiarioP.SelectedValue = CabFacturacion.Rows[0]["diadioidpago"];
                cboMedioPago.SelectedValue = CabFacturacion.Rows[0]["mediopago"];
                cboMoneda.SelectedValue = CabFacturacion.Rows[0]["moneda"];
                //cboMonedaP.SelectedValue = CabFacturacion.Rows[0]["monedap"];
                txtTipocambio.Text = String.Format(CabFacturacion.Rows[0]["tipcamb"].ToString(), "##.0000");
                //txtNumOpe.Text = CabFacturacion.Rows[0]["numdocpago"].ToString().Trim();
                txtGlosa.Text = CabFacturacion.Rows[0]["glosa"].ToString().Trim();
            }
            else
            {
                blanquear(false);
            }
            DetFacturacion.AcceptChanges();
            if (Examinar.DataSource != null)
            {
                lc_contador = 0;
                while (lc_contador < Examinar.RowCount)
                {
                    Examinar.Rows.Remove(Examinar.Rows[lc_contador]);
                }
            }
            Examinar.AutoGenerateColumns = false;
            Examinar.DataSource = DetFacturacion;
            for (lc_contador = 0; lc_contador <= Examinar.Columns.Count - 1; lc_contador++)
            {
                Examinar.Columns[lc_contador].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //U_pINTAR();

            VariablesPublicas.PintaEncabezados(Examinar);
            if (CabFacturacion != null)
            {
                if (CabFacturacion.Rows.Count > 0)
                {
                    lblAnulado.Text = (chkActivo.Checked ? "" : "ANULADO");
                    lblAuditoria.Text = CabFacturacion.Rows[0]["usuar"].ToString().ToUpper().Trim() + " - " + CabFacturacion.Rows[0]["feact"].ToString();
                }
            }
            else
            {
                lblAnulado.Text = "";
                lblAuditoria.Text = "";
            }
            totalizar();
            u_ShowGets();
        }
        private void blanquear(bool Inicializar)
        {
            xtipopersona = "";
            xtipodocidentidad = "";
            xctacte = "";
            xdirec = "";
            xubige = "";
            xBanco = "";
            xctacteaval = "";
            if (Inicializar)
            {
                lblAuditoria.Text = "";
                chkActivo.Checked = true;
                //cboSubdiarioR.SelectedValue = "";
                //txtCuentaidR.Text = "";
                //cboSubdiarioB.SelectedValue = "";
                //txtCuentaidB.Text = "";
                txtTipdoc.Text = "";
                //txtSerie.Text = "";
                //txtNumero.Text = "";
                txtRuc.Text = "";
                txtCtactename.Text = "";
                //txtDireccion.Text = "";
                cboMoneda.SelectedValue = "1";
                cboTcamuso.SelectedIndex = 0;
                txtTipocambio.Text = "";
                txtGlosa.Text = "";
                //chkRetencion.Checked = false;
                //cboMonedaP.SelectedValue = "1";
                //txtNumOpe.Text = "";
                //cboFlujoefectivo.SelectedValue = "O110";
                cboMedioPago.SelectedValue = "011";
            }
            else
            {
                lblAuditoria.Text = "";
                chkActivo.Checked = false;
                //cboSubdiarioR.SelectedValue = "";
                //txtCuentaidR.Text = "";
                //cboSubdiarioB.SelectedValue = "";
                //txtCuentaidB.Text = "";
                txtTipdoc.Text = "";
                //txtSerie.Text = "";
                //txtNumero.Text = "";
                txtRuc.Text = "";
                txtCtactename.Text = "";
                //txtDireccion.Text = "";
                cboMoneda.SelectedValue = "1";
                cboTcamuso.SelectedIndex = -1;
                txtTipocambio.Text = "";
                txtGlosa.Text = "";
                //chkRetencion.Checked = false;
                //cboMonedaP.SelectedValue = "";
                //txtNumOpe.Text = "";
                //cboFlujoefectivo.SelectedValue = "O110";
                cboMedioPago.SelectedValue = "";
            }
            txtRegistros.Text = "";
            txtImpOrigen.Text = "";
            txtImpPago.Text = "";
            txtImpRetencion.Text = "";

            if (Examinar.DataSource != null)
            {
                lc_contador = 0;
                while (lc_contador < Examinar.RowCount)
                {
                    Examinar.Rows.Remove(Examinar.Rows[lc_contador]);
                }
            }
            if (gridLetras.DataSource != null)
            {
                lc_contador = 0;
                while (lc_contador < gridLetras.RowCount)
                {
                    gridLetras.Rows.Remove(gridLetras.Rows[lc_contador]);
                }
            }
            //Datos Para Canje de Letras
            txtCantlet.Text = "";
            txtDias.Text = "";
            txtSerdoc.Text = "";
            txtNumdoc.Text = "";
            txtImportesoles.Text = "";
            txtImportedolares.Text = "";
            txtRucAval.Text = "";
            txtCtactenameAval.Text = "";
            txtLetrasoles.Text = "";
            txtLetraDolares.Text = "";
            txtDireccionAval.Text = "";
            txtTelefAval.Text = "";
            txtConcepto.Text = "";
            txtReferencia.Text = "";
            txtDiarioletra.Text = "";
            txtDdiarioletra.Text = "";
            txtLugargiro.Text = "";

            if (gridLetras.DataSource != null)
            {
                lc_contLetras = 0;
                while (lc_contLetras < gridLetras.RowCount)
                {
                    gridLetras.Rows.Remove(gridLetras.Rows[lc_contLetras]);
                }
            }
        }

        private void totalizar()
        {
            decimal vImpOrigen = 0;
            decimal vImpPago = 0;
            decimal vImpRetencion = 0;

            decimal vImporteSoles = 0;
            decimal vImporteDolares = 0;

            decimal vRegistros = 0;

            if (DetFacturacion != null)
            {
                int n = 0;
                for (n = 0; n <= Examinar.Rows.Count - 1; n++)
                {
                    vImpOrigen = vImpOrigen + Convert.ToDecimal(Examinar.Rows[n].Cells["importeorigen"].Value);
                    vImpPago = vImpPago + Convert.ToDecimal(Examinar.Rows[n].Cells["importepago"].Value);
                    vImpRetencion = vImpRetencion + Convert.ToDecimal(Examinar.Rows[n].Cells["importeretencionsoles"].Value);

                    vImporteSoles = vImporteSoles + Convert.ToDecimal(Examinar.Rows[n].Cells["importenetosoles"].Value);
                    vImporteDolares = vImporteDolares + Convert.ToDecimal(Examinar.Rows[n].Cells["importenetodolares"].Value);
                }

                vRegistros = Examinar.Rows.Count;

                txtImpOrigen.Text = vImpOrigen.ToString("###,###,###.#0");
                txtImpPago.Text = vImpPago.ToString("###,###,###.#0");
                txtImpRetencion.Text = vImpRetencion.ToString("###,###,###.#0");
                txtImportesoles.Text = vImporteSoles.ToString("###,###,###.#0");
                txtImportedolares.Text = vImporteDolares.ToString("###,###,###.#0");
                txtRegistros.Text = vRegistros.ToString("###");
            }
        }
        private void totalizarItem()
        {
            if (u_n_opsel > 0)
            {
                //decimal vmimportecambio = 0;
                //decimal vmtcambio = VariablesPublicas.StringtoDecimal(txtTipocambio.Text);
                sw_novaluechange = false;
                //if (object.ReferenceEquals(Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipcamb"].Value, DBNull.Value))
                //{
                //    Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipcamb"].Value = 0;
                //}
                //if (Convert.ToDecimal(Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipcamb"].Value) > 0)
                //{
                //    vmtcambio = Convert.ToDecimal(Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipcamb"].Value);
                //}
                //if (object.ReferenceEquals(Examinar.Rows[Examinar.CurrentRow.Index].Cells["importe"].Value, DBNull.Value))
                //{
                //    Examinar.Rows[Examinar.CurrentRow.Index].Cells["importe"].Value = 0;
                //}
                //if (object.ReferenceEquals(Examinar.Rows[Examinar.CurrentRow.Index].Cells["moneda"].Value, DBNull.Value))
                //{
                //    Examinar.Rows[Examinar.CurrentRow.Index].Cells["moneda"].Value = cboMoneda.SelectedValue.ToString();
                //}
                //if (Examinar.Rows[Examinar.CurrentRow.Index].Cells["moneda"].Value.ToString() == VariablesPublicas.MonedaCodSoles)
                //{
                //    if (vmtcambio == 0)
                //    {
                //        vmimportecambio = 0;
                //    }
                //    else
                //    {
                //        vmimportecambio = Math.Round(Convert.ToDecimal(Examinar.Rows[Examinar.CurrentRow.Index].Cells["importe"].Value) / vmtcambio, 2);
                //    }
                //}
                //if (Examinar.Rows[Examinar.CurrentRow.Index].Cells["moneda"].Value.ToString() == VariablesPublicas.MonedaCodDolares)
                //{
                //    vmimportecambio = Math.Round((vmtcambio == 0 ? 0 : Convert.ToDecimal(Examinar.Rows[Examinar.CurrentRow.Index].Cells["importe"].Value) * vmtcambio), 2);
                //}
                //Examinar.Rows[Examinar.CurrentRow.Index].Cells["importecambio"].Value = vmimportecambio;
                totalizar();
                Examinar.Refresh();
            }
        }

        #region Validacion de Cuenta Corriente
        private void txtRuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaProveedor();
            }
        }
        private void txtRuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void txtRuc_LostFocus(object sender, System.EventArgs e)
        {
            if (!sw_load)
            {
                if (u_n_opsel > 0)
                {
                    if (!(j_String == txtRuc.Text))
                    {
                        ValidaProveedor();
                    }
                }
            }
        }
        private void txtRuc_GotFocus(object sender, System.EventArgs e)
        {
            if (!sw_load)
            {
                if (u_n_opsel > 0)
                {
                    j_Ctacte = xctacte;
                    j_String = txtRuc.Text;
                }
            }
        }
        private void AyudaProveedor()
        {
            Ayudas.Frm_AyudaProveedor frmNew = new Ayudas.Frm_AyudaProveedor();
            frmNew._Valores = "<< Ayuda Proveedores >>";
            frmNew.Owner = this;
            frmNew.PasaProveedor = RecibeProveedor;
            frmNew.ShowDialog();
        }
        private void RecibeProveedor(string xruc, string xnombre, string xdirec)
        {
            if (xruc.Trim().Length > 0)
            {
                txtRuc.Text = xruc;
                ValidaProveedor();
            }
        }
        private void ValidaProveedor()
        {
            if (txtRuc.Text.Trim().Length > 0)
            {
                clienteBL BL = new clienteBL();
                tb_cliente BE = new tb_cliente();

                BE.nmruc = txtRuc.Text;
                DataTable tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                if (tmptabla.Rows.Count == 0)
                {
                    xctacte = j_Ctacte;
                    txtRuc.Text = j_String;
                }
                else
                {
                    xtipopersona = tmptabla.Rows[0]["tpperson"].ToString();
                    xtipodocidentidad = tmptabla.Rows[0]["docuidentid"].ToString();
                    xctacte = tmptabla.Rows[0]["ctacte"].ToString();
                    txtRuc.Text = tmptabla.Rows[0]["nmruc"].ToString();
                    txtCtactename.Text = tmptabla.Rows[0]["ctactename"].ToString().Trim();
                    //txtDireccion.Text = tmptabla.Rows[0]["direc"].ToString().Trim();
                    xdirec = tmptabla.Rows[0]["direc"].ToString().Trim();
                    xubige = tmptabla.Rows[0]["ubige"].ToString().Trim();
                    //cboDpto.SelectedValue = Equivalencias.Left(xubige, 2);
                    //LlenarProvi(cboProv, cboDistr, cboDpto.SelectedValue.ToString());
                    //LlenarDistr(cboDistr, cboProv.SelectedValue.ToString());

                    //cboProv.SelectedValue = Equivalencias.Left(xubige, 4);
                    //cboDistr.SelectedValue = xubige;

                    if (object.ReferenceEquals(tmptabla.Rows[0]["agerent"], DBNull.Value))
                    {
                        rbagenteretencionsi.Checked = false;
                        rbagenteretencionno.Checked = true;
                    }
                    else
                    {
                        rbagenteretencionsi.Checked = Convert.ToBoolean(tmptabla.Rows[0]["agerent"]) == true;
                        rbagenteretencionno.Checked = Convert.ToBoolean(tmptabla.Rows[0]["agerent"]) == false;
                    }

                    if (object.ReferenceEquals(tmptabla.Rows[0]["buencontr"], DBNull.Value))
                    {
                        rbbuencontribuyentesi.Checked = false;
                        rbbuencontribuyenteno.Checked = true;
                    }
                    else
                    {
                        rbbuencontribuyentesi.Checked = Convert.ToBoolean(tmptabla.Rows[0]["buencontr"]) == true;
                        rbbuencontribuyenteno.Checked = Convert.ToBoolean(tmptabla.Rows[0]["buencontr"]) == false;
                    }

                    if (object.ReferenceEquals(tmptabla.Rows[0]["buencontr"], DBNull.Value))
                    {
                        rbpercepcionsi.Checked = false;
                        rbpercepcionno.Checked = true;
                    }
                    else
                    {
                        rbpercepcionsi.Checked = Convert.ToBoolean(tmptabla.Rows[0]["agenperc"]) == true;
                        rbpercepcionno.Checked = Convert.ToBoolean(tmptabla.Rows[0]["agenperc"]) == false;
                    }
                }
            }
            else
            {
                xctacte = j_Ctacte;
                txtRuc.Text = j_String;
            }
        }

        private void txtRucAval_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaProveedorAval();
            }
        }
        private void txtRucAval_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void txtRucAval_LostFocus(object sender, System.EventArgs e)
        {
            if (!sw_load)
            {
                if (u_n_opsel > 0)
                {
                    if (!(j_String == txtRucAval.Text))
                    {
                        ValidaProveedor();
                    }
                }
            }
        }
        private void txtRucAval_GotFocus(object sender, System.EventArgs e)
        {
            if (!sw_load)
            {
                if (u_n_opsel > 0)
                {
                    j_String = txtRucAval.Text;
                }
            }
        }
        private void AyudaProveedorAval()
        {
            Ayudas.Frm_AyudaProveedor frmNew = new Ayudas.Frm_AyudaProveedor();
            frmNew._Valores = "<< Ayuda Proveedores >>";
            frmNew.Owner = this;
            frmNew.PasaProveedor = RecibeProveedorAval;
            frmNew.ShowDialog();
        }
        private void RecibeProveedorAval(string xruc, string xnombre, string xdirec)
        {
            if (xruc.Trim().Length > 0)
            {
                txtRucAval.Text = xruc;
                ValidaProveedorAval();
            }
        }
        private void ValidaProveedorAval()
        {
            if (txtRucAval.Text.Trim().Length > 0)
            {
                clienteBL BL = new clienteBL();
                tb_cliente BE = new tb_cliente();

                BE.nmruc = txtRucAval.Text;
                DataTable tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                if (tmptabla.Rows.Count == 0)
                {
                    txtRucAval.Text = j_String;
                }
                else
                {
                    xctacteaval = tmptabla.Rows[0]["ctacte"].ToString();
                    txtRucAval.Text = tmptabla.Rows[0]["nmruc"].ToString().Trim();
                    txtCtactenameAval.Text = tmptabla.Rows[0]["ctactename"].ToString().Trim();
                    txtDireccionAval.Text = tmptabla.Rows[0]["direc"].ToString().Trim();
                    txtTelefAval.Text = tmptabla.Rows[0]["telef1"].ToString().Trim();
                }
            }
            else
            {
                txtRuc.Text = j_String;
            }
        }
        #endregion

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (PuedeEditarEliminar("EDITAR", VariablesPublicas.PADL(fRegistro.Value.Month.ToString(), 2, "0")))
            {
                u_n_opsel = 2;
                refrescacontroles();
                //W_KEY0001 = txtRuc.Text;
                W_KEY0001 = "";
                //if (cboTipdoc.SelectedValue != null)
                //{
                //    W_KEY0001 = W_KEY0001 + cboTipdoc.SelectedValue.ToString().Trim();
                //}
                W_KEY0001 = W_KEY0001 + txtMes.Text.Trim() + txtAsiento.Text.Trim();
                txtRuc.Focus();
            }
        }
        private bool PuedeEditarEliminar(string glosamensaje, string codmes)
        {
            bool zpuede = true;
            tb_co_cierremensualesBL BL = new tb_co_cierremensualesBL();
            tb_co_cierremensuales BE = new tb_co_cierremensuales();

            BE.periano = VariablesPublicas.perianio;
            BE.moduloid = VariablesPublicas.tipocierremensualTesoreria;
            BE.perimes = codmes;
            tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            if (tmptabla.Rows.Count > 0)
            {
                if (!(Convert.ToBoolean(tmptabla.Rows[0]["status"]) == false))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Mes Cerrado ...Imposible " + glosamensaje.Trim(), "Mensaje delSistema", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    zpuede = false;
                }
            }
            else
            {
                zpuede = false;
            }
            return zpuede;
        }

        private void btnRetro_Click(object sender, EventArgs e)
        {
            U_CancelarEdicion(1);
        }
        private void U_CancelarEdicion(int SwConfirmacion)
        {
            //  Ojo Poner este codigo para que al momento de cancelar el ingreso de datos no valide la celda
            if (Examinar.IsCurrentCellInEditMode)
            {
                Examinar.CancelEdit();
            }
            bool sw_prosigue = true;
            if (SwConfirmacion == 1)
            {
                sw_prosigue = (DevExpress.XtraEditors.XtraMessageBox.Show("Desea cancelar ingreso de datos...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
            }
            else
            {
                sw_prosigue = true;
            }
            if (sw_prosigue)
            {
                u_n_opsel = 0;
                CargaDatos();
                refrescacontroles("Deshacer");
                txtMes.Enabled = true;
                txtAsiento.Enabled = true;
                txtAsiento.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validacion_Grabar())
            {
                generaVoucherRetencion(false);
            }
        }

        public void generaVoucherRetencion(bool nopideimpresion)
        {
            if (u_n_opsel == 1)
            {
                UltimoNumeroRegistro();
            }
            ValidarCursor();
            InsertRetenciones();

            decimal vmtcambio = VariablesPublicas.StringtoDecimal(txtTipocambio.Text);

            // Variables de Cabecera
            tb_co_MovimientosBL BL = new tb_co_MovimientosBL();
            tb_co_Movimientos BE = new tb_co_Movimientos();

            // Variables para Detalle
            tb_co_Movimientos.Item Detalle = new tb_co_Movimientos.Item();
            List<tb_co_Movimientos.Item> ListaItems = new List<tb_co_Movimientos.Item>();

            #region **ingreso movimiento cabecera***
            //caso Cobranzas/pagos - automatizacion
            string activo = "0"; //Activo
            string anulad = "9"; //Anulado
            string xMoneda = Equivalencias.Left(cboMoneda.SelectedValue.ToString(), 1);

            BE.perianio = VariablesPublicas.perianio;
            BE.perimes = VariablesPublicas.PADL(txtMes.Text.Trim(), 2, "0");
            BE.moduloid = VariablesDominio.VarTesoreria.Moduloid;
            BE.local = VariablesDominio.VarTesoreria.Local;
            BE.diarioid = cboSubdiario.SelectedValue.ToString();
            BE.asiento = VariablesPublicas.PADL(txtAsiento.Text.Trim(), 6, "0");
            BE.tipooperacion = "2";
            BE.tipocomprobante = "2"; //2-Normal
            BE.tipomovimiento = (Equivalencias.Left(txtCuentaid.Text, 1) == "4" ? "" : "11"); //(BE.tipooperacion == "1" ? "01" : "11"); //01-ingresos a caja, 11-egresos a caja
            BE.cuentaid = txtCuentaid.Text;

            //Puede ser null
            if (cboMedioPago.Text.Length > 0)
            { BE.mediopago = cboMedioPago.SelectedValue.ToString(); }
            else
            { BE.mediopago = ""; }

            //BE.numdocpago = txtNumOpe.Text;
            BE.bancoid = xBanco;
            BE.fechregistro = Convert.ToDateTime(fRegistro.Text.Trim());
            BE.fechdoc = Convert.ToDateTime(fRegistro.Text.Trim());
            BE.tipcamuso = "V";
            BE.tipcamb = Convert.ToDecimal(txtTipocambio.Text.Trim());
            BE.glosa = txtGlosa.Text;
            BE.moneda = cboMoneda.SelectedValue.ToString();
            //Puede ser null
            //if (cboFlujoefectivo.Text.Length > 0)
            //{ BE.flujoefectivo = cboFlujoefectivo.SelectedValue.ToString(); }
            //else
            //{ BE.flujoefectivo = ""; }
            BE.debesoles = sumadebesoles;
            BE.debedolares = sumadebedolares;
            BE.habersoles = sumahabersoles;
            BE.haberdolares = sumahaberdolares;

            BE.difcambio = false;
            BE.redondeo = false;

            if (chkActivo.Checked == true)
            {
                BE.status = activo;
            }
            if (chkActivo.Checked == false)
            {
                BE.status = anulad;
            }

            BE.usuar = VariablesPublicas.Usuar;
            #endregion

            #region ****ingreso movimiento detalle***

            int item = 0;
            foreach (DataRow fila in DetMovimiento.Rows)
            {
                Detalle = new tb_co_Movimientos.Item();

                item++;

                Detalle.perianio = VariablesPublicas.perianio;
                Detalle.perimes = BE.perimes;
                Detalle.moduloid = BE.moduloid;
                Detalle.local = BE.local;
                Detalle.diarioid = BE.diarioid;
                Detalle.asiento = txtAsiento.Text.PadLeft(6, '0'); // BE.asiento;
                Detalle.asientoitems = item.ToString().PadLeft(5, '0');
                Detalle.cuentaid = fila["cuentaid"].ToString();
                Detalle.cuentaorigen = fila["cuentaorigen"].ToString(); ;
                Detalle.cuentaname = fila["cuentaname"].ToString();
                Detalle.glosa = txtGlosa.Text.Trim().ToUpper().ToString();

                if (Equivalencias.Left(Detalle.cuentaid.ToString(), 1) == "9")
                { Detalle.cencosid = fila["cencosid"].ToString(); }
                else { Detalle.cencosid = ""; }

                Detalle.debehaber = fila["debehaber"].ToString();
                Detalle.ctacte = xctacte; //fila["ctacte"].ToString();
                Detalle.nmruc = fila["nmruc"].ToString();
                Detalle.ctactename = fila["ctactename"].ToString();
                Detalle.tipdoc = fila["tipdoc"].ToString();
                Detalle.serdoc = fila["serdoc"].ToString();
                Detalle.numdoc = fila["numdoc"].ToString();
                Detalle.fechregistro = Convert.ToDateTime(BE.fechregistro);

                if (object.ReferenceEquals(fila["fechdoc"], DBNull.Value))
                {
                    Detalle.fechdoc = Convert.ToDateTime(fRegistro.Text.Trim());
                }
                else
                {
                    Detalle.fechdoc = Convert.ToDateTime(fila["fechdoc"].ToString());
                }

                if (object.ReferenceEquals(fila["fechvenc"], DBNull.Value))
                {
                    Detalle.fechvenc = Convert.ToDateTime(fRegistro.Text.Trim());
                }
                else
                {
                    Detalle.fechvenc = Convert.ToDateTime(fila["fechvenc"].ToString());
                }

                Detalle.tipref = fila["tipref"].ToString();
                Detalle.serref = fila["serref"].ToString();
                Detalle.numref = fila["numref"].ToString();

                try { Detalle.fechref = Convert.ToDateTime(fila["fechref"].ToString()); }
                catch { Detalle.fechref = Convert.ToDateTime("01/01/1900"); }

                Detalle.moneda = fila["moneda"].ToString();
                Detalle.importe = Convert.ToDecimal(fila["importe"].ToString());
                Detalle.importecambio = Convert.ToDecimal(fila["importecambio"].ToString());
                Detalle.soles = Convert.ToDecimal(fila["soles"].ToString());
                Detalle.dolares = Convert.ToDecimal(fila["dolares"].ToString());

                if (Convert.ToDecimal(fila["tipcamb"]) > 0)
                {
                    Detalle.tipcamb = Convert.ToDecimal(fila["tipcamb"].ToString());
                }
                else
                {
                    Detalle.tipcamb = Convert.ToDecimal(txtTipocambio.Text.Trim());
                }

                Detalle.tipcambuso = BE.tipcamuso;

                try { Detalle.tipcambfech = Convert.ToDateTime(fila["tipcambfech"].ToString()); }
                catch { Detalle.tipcambfech = Convert.ToDateTime(fRegistro.Text.Trim()); }

                Detalle.afectoretencion = false;
                Detalle.afectopercepcion = false;
                Detalle.percepcionid = fila["percepcionid"].ToString();
                Detalle.serperc = fila["serperc"].ToString();
                Detalle.numperc = fila["numperc"].ToString();
                //Detalle.numdocpago = txtNumOpe.Text;
                Detalle.bancoid = BE.bancoid;
                Detalle.pagocta = fila["pagocta"].ToString();
                Detalle.mediopago = BE.mediopago;
                Detalle.fechpago = Convert.ToDateTime(fRegistro.Text.Trim());
                if (Equivalencias.Left(Detalle.cuentaid.ToString(), 2) == "10")
                { Detalle.flujoefectivo = BE.flujoefectivo; }
                else { Detalle.flujoefectivo = ""; }
                Detalle.asientovinculante = fila["asientovinculante"].ToString();
                Detalle.cancelacionvinculante = fila["cancelacionvinculante"].ToString();
                Detalle.productid = fila["productid"].ToString();
                Detalle.pedidoid = fila["pedidoid"].ToString();
                Detalle.tipOp = fila["tip_op"].ToString();
                Detalle.serOp = fila["ser_op"].ToString();
                Detalle.numOp = fila["num_op"].ToString();
                Detalle.tipooperacion = BE.tipooperacion;
                Detalle.tipocomprobante = BE.tipocomprobante;
                Detalle.tipomovimiento = BE.tipomovimiento;
                Detalle.statusdestino = fila["statusdestino"].ToString();
                if (chkActivo.Checked == true)
                {
                    Detalle.status = activo;
                }
                if (chkActivo.Checked == false)
                {
                    Detalle.status = anulad;
                }
                Detalle.usuar = VariablesPublicas.Usuar;

                ListaItems.Add(Detalle);
            }
            BE.ListaItems = ListaItems;
            #endregion

            #region ** Save BD
            //string nasiento = ""; // nlastreg = "";
            string xcodmes = fRegistro.Value.Month.ToString().Trim();
            xcodmes = VariablesPublicas.PADL(xcodmes, 2, "0");
            //nasiento = ocapa.CaeSoft_GetAllMaximoMovimientoContable(cac3g00.Rows[0]["ccia_3"], cac3g00.Rows[0]["cperiodo_3"], txtcodsubdiario.Text, xcodmes);
            //tmptabla = ocapa.cac3p00_consulta(GlobalVars.GetInstance.Company, GlobalVars.GetInstance.Periodo, txtcodsubdiario.Text, xcodmes, nlastreg, "", "");
            //if (ocapa.sql_error.Length > 0)
            //{
            //    ERP_CAESOFT_FORMS.frmclass.ShowError(ocapa.sql_error, this);
            //    return;
            //}
            dynamic nvmindice = 0;
            //while (tmptabla.Rows.Count > 0)
            //{
            //    //nlastreg = ocapa.CaeSoft_GetAllMaximoMovimientoContable(cac3g00.Rows[0]["ccia_3"], cac3g00.Rows[0]["cperiodo_3"], txtcodsubdiario.Text, xcodmes);
            //    //tmptabla = ocapa.cac3p00_consulta(GlobalVars.GetInstance.Company, GlobalVars.GetInstance.Periodo, txtcodsubdiario.Text, xcodmes, nlastreg, "", "");
            //    nvmindice = nvmindice + 1;
            //    if (nvmindice > 999999)
            //    {
            //        MessageBox.Show("Error letal se alcanzó el tope de registro para este tipo de vouchers... Consulta a Sistemas", "");
            //        return;
            //    }
            //}
            try
            {
                if (u_n_opsel == 1)  //Si es nuevo
                {
                    if (BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE))
                    {
                        if (!nopideimpresion)
                        {
                            string message = "Desea Imprimir Documento Nro: " + cboSubdiario.SelectedValue.ToString() + "/" + txtMes.Text + "-" + txtAsiento.Text + " ...?";
                            string caption = "Impresión de Comprobante de Retención";
                            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                            DialogResult result;

                            // Muestra el cuadro de mensaje.
                            result = DevExpress.XtraEditors.XtraMessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.Yes)
                            {
                                //Accion(6, "", xnum);
                                //impresionCRetencion();
                                //llamarformimpresion();
                            }
                        }
                        tmptablacab = null;
                        tmptabladet = null;
                        letradet = null;
                        U_CancelarEdicion(0);
                    }
                }
                else if (u_n_opsel == 2)  //Si NO es nuevo
                {
                    if (BL.Update(VariablesPublicas.EmpresaID.ToString(), BE))
                    {
                        seguridadlog();
                        if (!nopideimpresion)
                        {
                            string message = "Desea Imprimir Documento Nro: " + cboSubdiario.SelectedValue.ToString() + "/" + txtMes.Text + "-" + txtAsiento.Text + " ...?";
                            string caption = "Impresión de Comprobante de Retención";
                            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                            DialogResult result;

                            // Muestra el cuadro de mensaje.
                            result = DevExpress.XtraEditors.XtraMessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.Yes)
                            {
                                //Accion(6, "", xnum);
                                //impresionCRetencion();
                                //llamarformimpresion();
                            }
                        }
                        tmptablacab = null;
                        tmptabladet = null;
                        letradet = null;
                        U_CancelarEdicion(0);
                    }
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion

            InsertRetencionesLetras();
        }
        public void InsertRetenciones()
        {
            decimal vmtcambio = VariablesPublicas.StringtoDecimal(txtTipocambio.Text);

            // Variables de Cabecera
            tb_co_retencionesBL BL = new tb_co_retencionesBL();
            tb_co_retenciones BE = new tb_co_retenciones();

            // Variables para Detalle
            tb_co_retenciones.Item Detalle = new tb_co_retenciones.Item();
            List<tb_co_retenciones.Item> ListaItems = new List<tb_co_retenciones.Item>();

            #region **ingreso movimiento cabecera***
            //caso Retenciones
            string activo = "0"; //Activo
            string anulad = "9"; //Anulado
            string xMoneda = Equivalencias.Left(cboMoneda.SelectedValue.ToString(), 1);

            BE.perianio = VariablesPublicas.perianio;
            BE.perimes = VariablesPublicas.PADL(txtMes.Text.Trim(), 2, "0");
            BE.moduloid = VariablesDominio.VarTesoreria.Moduloid;
            BE.local = VariablesDominio.VarTesoreria.Local;
            BE.diarioid = cboSubdiario.SelectedValue.ToString();
            BE.asiento = VariablesPublicas.PADL(txtAsiento.Text.Trim(), 6, "0");
            //if (rbnPagos.Checked == true)
            //{
            //    BE.tiporegistro = "1";
            //}
            //else if (rbnEmision.Checked == true)
            //{
            //    BE.tiporegistro = "2";
            //}
            //else if (rbnLetras.Checked == true)
            //{
            //    BE.tiporegistro = "3";
            //}
            BE.ctacte = xctacte;
            BE.nmruc = txtRuc.Text.Trim();
            BE.ctactename = txtCtactename.Text.Trim();
            //BE.direc = txtDireccion.Text.Trim();
            BE.ubige = xubige;
            //BE.tipdoc = cboTipdoc.SelectedValue.ToString();
            //BE.serdoc = txtSerie.Text.Trim();
            //BE.numdoc = txtNumero.Text.Trim();
            BE.fechdoc = Convert.ToDateTime(fRegistro.Text.Trim());
            BE.fechvcto = Convert.ToDateTime(fecVenc.Text.Trim());
            BE.moneda = cboMoneda.SelectedValue.ToString();
            BE.tipcamb = Convert.ToDecimal(txtTipocambio.Text.Trim());
            BE.tipcambuso = "V";
            BE.glosa = txtGlosa.Text.Trim();
            //if (cboSubdiarioP.Text.Length > 0)
            //{ BE.diarioidpago = cboSubdiarioP.SelectedValue.ToString(); }
            //else
            //{ BE.diarioidpago = ""; }

            //BE.monedap = cboMonedaP.SelectedValue.ToString();
            //BE.numdocpago = txtNumOpe.Text;
            //Puede ser null
            //if (cboFlujoefectivo.Text.Length > 0)
            //{ BE.flujoefectivo = cboFlujoefectivo.SelectedValue.ToString(); }
            //else
            //{ BE.flujoefectivo = ""; }
            //Puede ser null
            if (cboMedioPago.Text.Length > 0)
            { BE.mediopago = cboMedioPago.SelectedValue.ToString(); }
            else
            { BE.mediopago = ""; }
            BE.importeoriginal = Convert.ToDecimal(txtImpOrigen.Text);
            BE.importepago = Convert.ToDecimal(txtImpPago.Text);
            BE.importeretencion = Convert.ToDecimal(txtImpRetencion.Text);
            if (chkActivo.Checked == true)
            {
                BE.status = activo;
            }
            if (chkActivo.Checked == false)
            {
                BE.status = anulad;
            }

            BE.usuar = VariablesPublicas.Usuar;
            #endregion

            #region ****ingreso movimiento detalle***

            int item = 0;
            foreach (DataRow fila in DetFacturacion.Rows)
            {
                Detalle = new tb_co_retenciones.Item();

                item++;

                Detalle.perianio = VariablesPublicas.perianio;
                Detalle.perimes = BE.perimes;
                Detalle.moduloid = BE.moduloid;
                Detalle.local = BE.local;
                Detalle.diarioid = BE.diarioid;
                Detalle.asiento = txtAsiento.Text.PadLeft(6, '0'); // BE.asiento;
                Detalle.asientoitems = item.ToString().PadLeft(5, '0');
                Detalle.cuentaid = fila["cuentaid"].ToString();
                Detalle.ctacte = xctacte;
                Detalle.nmruc = fila["nmruc"].ToString();
                Detalle.tipdoc = fila["tipdoc"].ToString();
                Detalle.serdoc = fila["serdoc"].ToString();
                Detalle.numdoc = fila["numdoc"].ToString();
                if (object.ReferenceEquals(fila["fechdoc"], DBNull.Value))
                {
                    Detalle.fechdoc = Convert.ToDateTime(fRegistro.Text.Trim());
                }
                else
                {
                    Detalle.fechdoc = Convert.ToDateTime(fila["fechdoc"].ToString());
                }

                if (object.ReferenceEquals(fila["fechvcto"], DBNull.Value))
                {
                    Detalle.fechvcto = Convert.ToDateTime(fRegistro.Text.Trim());
                }
                else
                {
                    Detalle.fechvcto = Convert.ToDateTime(fila["fechvcto"].ToString());
                }
                if (object.ReferenceEquals(fila["fechpago"], DBNull.Value))
                {
                    Detalle.fechpago = Convert.ToDateTime(fRegistro.Text.Trim());
                }
                else
                {
                    Detalle.fechpago = Convert.ToDateTime(fila["fechpago"].ToString());
                }
                Detalle.moneda = fila["moneda"].ToString();
                if (Convert.ToDecimal(fila["tipcamb"]) > 0)
                {
                    Detalle.tipcamb = Convert.ToDecimal(fila["tipcamb"].ToString());
                }
                else
                {
                    Detalle.tipcamb = Convert.ToDecimal(txtTipocambio.Text.Trim());
                }

                Detalle.tipcambuso = BE.tipcambuso;
                Detalle.motivo = fila["motivo"].ToString();
                Detalle.importeorigendolares = Convert.ToDecimal(fila["importeorigendolares"].ToString());
                Detalle.importepagodolares1 = Convert.ToDecimal(fila["importepagodolares1"].ToString());
                Detalle.importepagodolares2 = Convert.ToDecimal(fila["importepagodolares2"].ToString());
                Detalle.importeretenciondolares = Convert.ToDecimal(fila["importeretenciondolares"].ToString());
                Detalle.importenetodolares = Convert.ToDecimal(fila["importenetodolares"].ToString());

                Detalle.importedifcambio = Convert.ToDecimal(fila["importedifcambio"].ToString());

                Detalle.importeorigensoles = Convert.ToDecimal(fila["importeorigensoles"].ToString());
                Detalle.importepagosoles = Convert.ToDecimal(fila["importepagosoles"].ToString());
                Detalle.importeorigen = Convert.ToDecimal(fila["importeorigen"].ToString());
                Detalle.importepago = Convert.ToDecimal(fila["importepago"].ToString());
                Detalle.importeretencionsoles = Convert.ToDecimal(fila["importeretencionsoles"].ToString());
                Detalle.importenetosoles = Convert.ToDecimal(fila["importenetosoles"].ToString());
                Detalle.retencion = true;
                if (chkActivo.Checked == true)
                {
                    Detalle.status = activo;
                }
                if (chkActivo.Checked == false)
                {
                    Detalle.status = anulad;
                }
                Detalle.usuar = VariablesPublicas.Usuar;

                ListaItems.Add(Detalle);
            }
            BE.ListaItems = ListaItems;
            #endregion

            #region ** Save BD
            try
            {
                if (u_n_opsel == 1)  //Si es nuevo
                {
                    if (BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE))
                    {
                        // Impresion
                        //ReportesContabilidad.Frm_ReporteVouchers frm = new ReportesContabilidad.Frm_ReporteVouchers();
                        //frm._tipComprobante = cboSubdiarioR.SelectedValue.ToString();
                        //frm._xModulo = BE.moduloid;
                        //frm._xLocal = BE.local;
                        //frm._nroComprobante = BE.perimes + txtAsiento.Text; //nAsiento;//xcodmes + nlastreg;
                        //frm._tipoOperacion = BE.tipooperacion; //cac3g00.Rows[0]["tasien_3"].ToString();
                        //frm.Owner = this;
                        //frm.ShowInTaskbar = false;
                        //frm.ShowDialog();
                    }
                }
                else if (u_n_opsel == 2)  //Si NO es nuevo
                {
                    if (BL.Update(VariablesPublicas.EmpresaID.ToString(), BE))
                    {
                        //seguridadlog();
                        //if (!nopideimpresion)
                        //{
                        //    string message = "Desea Imprimir Documento Nro: " + txtMes.Text + "-" + txtAsiento.Text + " ...?";
                        //    string caption = "Impresión";
                        //    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        //    DialogResult result;

                        //    // Muestra el cuadro de mensaje.
                        //    result = MessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        //    if (result == DialogResult.Yes)
                        //    {
                        //        Accion(6, "", xnum);
                        //    }
                        //}
                        //tmptablacab = null;
                        //tmptabladet = null;
                        //U_CancelarEdicion(0);
                    }
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
        }
        public void InsertRetencionesLetras()
        {
            //if (rbnLetras.Checked == true)
            //{
                decimal vmtcambio = VariablesPublicas.StringtoDecimal(txtTipocambio.Text);

                // Variables de Cabecera
                tb_co_canjeletraretencionBL BL = new tb_co_canjeletraretencionBL();
                tb_co_canjeletraretencion BE = new tb_co_canjeletraretencion();

                // Variables para Detalle
                tb_co_canjeletraretencion.Item Detalle = new tb_co_canjeletraretencion.Item();
                List<tb_co_canjeletraretencion.Item> ListaItems = new List<tb_co_canjeletraretencion.Item>();

                #region **ingreso movimiento cabecera***
                //caso Retenciones
                string activo = "0"; //Activo
                string anulad = "9"; //Anulado
                string xMoneda = Equivalencias.Left(cboMoneda.SelectedValue.ToString(), 1);

                BE.perianio = VariablesPublicas.perianio;
                BE.perimes = VariablesPublicas.PADL(txtMes.Text.Trim(), 2, "0");
                BE.moduloid = VariablesDominio.VarTesoreria.Moduloid;
                BE.local = VariablesDominio.VarTesoreria.Local;
                BE.diarioid = cboSubdiario.SelectedValue.ToString();
                BE.asiento = VariablesPublicas.PADL(txtAsiento.Text.Trim(), 6, "0");
                //if (rbnPagos.Checked == true)
                //{
                //    BE.tiporegistro = "1";
                //}
                //else if (rbnEmision.Checked == true)
                //{
                //    BE.tiporegistro = "2";
                //}
                //else if (rbnLetras.Checked == true)
                //{
                //    BE.tiporegistro = "3";
                //}
                BE.ctacte = xctacte;
                BE.nmruc = txtRuc.Text.Trim();
                BE.ctactename = txtCtactename.Text.Trim();
                //BE.direc = txtDireccion.Text.Trim();
                BE.ubige = xubige;
                //BE.tipdoc = cboTipdoc.SelectedValue.ToString();
                //BE.serdoc = txtSerie.Text.Trim();
                //BE.numdoc = txtNumero.Text.Trim();
                BE.fechdoc = Convert.ToDateTime(fRegistro.Text.Trim());
                BE.fechvcto = Convert.ToDateTime(fecVenc.Text.Trim());
                BE.moneda = cboMoneda.SelectedValue.ToString();
                BE.tipcamb = Convert.ToDecimal(txtTipocambio.Text.Trim());
                BE.tipcambuso = "V";
                BE.glosa = txtGlosa.Text.Trim();
                //BE.diarioidpago = cboSubdiarioP.SelectedValue.ToString();
                //BE.monedap = cboMonedaP.SelectedValue.ToString();
                //BE.numdocpago = txtNumOpe.Text;
                //Puede ser null
                //if (cboFlujoefectivo.Text.Length > 0)
                //{ BE.flujoefectivo = cboFlujoefectivo.SelectedValue.ToString(); }
                //else
                //{ BE.flujoefectivo = ""; }
                //Puede ser null
                if (cboMedioPago.Text.Length > 0)
                { BE.mediopago = cboMedioPago.SelectedValue.ToString(); }
                else
                { BE.mediopago = ""; }
                BE.importesoles = Convert.ToDecimal(txtLetrasoles.Text);
                BE.importedolares = Convert.ToDecimal(txtLetraDolares.Text);
                BE.importeotros = 0;
                BE.ctacteaval = xctacteaval;
                BE.nmrucaval = txtRucAval.Text.Trim();
                BE.referencia = txtReferencia.Text.Trim();
                BE.lugargiro = txtLugargiro.Text.Trim();
                if (chkActivo.Checked == true)
                {
                    BE.status = activo;
                }
                if (chkActivo.Checked == false)
                {
                    BE.status = anulad;
                }

                BE.usuar = VariablesPublicas.Usuar.Trim();
                #endregion

                #region ****ingreso movimiento detalle***

                int item = 0;
                foreach (DataRow fila in DetLetras.Rows)
                {
                    Detalle = new tb_co_canjeletraretencion.Item();

                    item++;

                    Detalle.perianio = VariablesPublicas.perianio;
                    Detalle.perimes = BE.perimes;
                    Detalle.moduloid = BE.moduloid;
                    Detalle.local = BE.local;
                    Detalle.diarioid = BE.diarioid;
                    Detalle.asiento = txtAsiento.Text.PadLeft(6, '0'); // BE.asiento;
                    Detalle.asientoitems = item.ToString().PadLeft(5, '0');
                    Detalle.cuentaid = fila["cuentaid"].ToString();
                    Detalle.ctacte = xctacte; //fila["ctacte"].ToString();
                    Detalle.nmruc = fila["nmruc"].ToString();
                    Detalle.tipdoc = fila["tipdoc"].ToString();
                    Detalle.serdoc = fila["serdoc"].ToString();
                    Detalle.numdoc = fila["numdoc"].ToString();
                    if (object.ReferenceEquals(fila["fechdoc"], DBNull.Value))
                    {
                        Detalle.fechdoc = Convert.ToDateTime(fRegistro.Text.Trim());
                    }
                    else
                    {
                        Detalle.fechdoc = Convert.ToDateTime(fila["fechdoc"].ToString());
                    }

                    if (object.ReferenceEquals(fila["fechvcto"], DBNull.Value))
                    {
                        Detalle.fechvcto = Convert.ToDateTime(fRegistro.Text.Trim());
                    }
                    else
                    {
                        Detalle.fechvcto = Convert.ToDateTime(fila["fechvcto"].ToString());
                    }
                    if (object.ReferenceEquals(fila["fechpago"], DBNull.Value))
                    {
                        Detalle.fechpago = Convert.ToDateTime(fRegistro.Text.Trim());
                    }
                    else
                    {
                        Detalle.fechpago = Convert.ToDateTime(fila["fechpago"].ToString());
                    }
                    Detalle.moneda = fila["moneda"].ToString();

                    Detalle.importe1 = Convert.ToDecimal(fila["importe1"].ToString());
                    Detalle.total1 = Convert.ToDecimal(fila["total1"].ToString());
                    Detalle.importe2 = Convert.ToDecimal(fila["importe2"].ToString());
                    Detalle.total2 = Convert.ToDecimal(fila["total2"].ToString());
                    Detalle.ctacte1 = fila["ctacte1"].ToString();
                    Detalle.nmruc1 = fila["nmruc1"].ToString();
                    Detalle.ctactename1 = fila["ctactename1"].ToString();
                    Detalle.direc1 = fila["direc1"].ToString();
                    Detalle.ctacte2 = fila["ctacte2"].ToString();
                    Detalle.nmruc2 = fila["nmruc2"].ToString();
                    Detalle.ctactename2 = fila["ctactename2"].ToString();
                    Detalle.direc2 = fila["direc2"].ToString();
                    Detalle.importeenletras = fila["importeenletras"].ToString();
                    Detalle.telefaval = txtTelefAval.Text.Trim();
                    Detalle.cantletras = Convert.ToDecimal(txtCantlet.Text.ToString());
                    Detalle.cantdias = Convert.ToDecimal(txtDias.Text.ToString());
                    if (chkActivo.Checked == true)
                    {
                        Detalle.status = activo;
                    }
                    if (chkActivo.Checked == false)
                    {
                        Detalle.status = anulad;
                    }
                    Detalle.usuar = VariablesPublicas.Usuar.Trim();

                    ListaItems.Add(Detalle);
                }
                BE.ListaItems = ListaItems;
                #endregion

                #region ** Save BD
                try
                {
                    if (u_n_opsel == 1)  //Si es nuevo
                    {
                        if (BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE))
                        {
                            // Impresion
                            //ReportesContabilidad.Frm_ReporteVouchers frm = new ReportesContabilidad.Frm_ReporteVouchers();
                            //frm._tipComprobante = cboSubdiarioR.SelectedValue.ToString();
                            //frm._xModulo = BE.moduloid;
                            //frm._xLocal = BE.local;
                            //frm._nroComprobante = BE.perimes + txtAsiento.Text; //nAsiento;//xcodmes + nlastreg;
                            //frm._tipoOperacion = BE.tipooperacion; //cac3g00.Rows[0]["tasien_3"].ToString();
                            //frm.Owner = this;
                            //frm.ShowInTaskbar = false;
                            //frm.ShowDialog();
                        }
                    }
                    else if (u_n_opsel == 2)  //Si NO es nuevo
                    {
                        if (BL.Update(VariablesPublicas.EmpresaID.ToString(), BE))
                        {
                            //seguridadlog();
                            //if (!nopideimpresion)
                            //{
                            //    string message = "Desea Imprimir Documento Nro: " + txtMes.Text + "-" + txtAsiento.Text + " ...?";
                            //    string caption = "Impresión";
                            //    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                            //    DialogResult result;

                            //    // Muestra el cuadro de mensaje.
                            //    result = MessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            //    if (result == DialogResult.Yes)
                            //    {
                            //        Accion(6, "", xnum);
                            //    }
                            //}
                            //tmptablacab = null;
                            //tmptabladet = null;
                            //U_CancelarEdicion(0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion
            //}
        }

        private String CuentaName(string perianio, string cuentaid)
        {
            tb_co_plancontableBL BL = new tb_co_plancontableBL();
            tb_co_plancontable BE = new tb_co_plancontable();

            DataTable tablecuenta = new DataTable();

            BE.perianio = perianio;
            BE.cuentaid = cuentaid;
            try
            {
                tablecuenta = BL.GetOne(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return tablecuenta.Rows[0]["cuentaname"].ToString().Trim();
        }

        private void ValidarCursor()
        {
            DataRow orow = null;
            int ncont = 0;
            int lc_contador = 0;

            decimal vmtcambio = VariablesPublicas.StringtoDecimal(txtTipocambio.Text);
            try
            {
                tb_co_MovimientosdetBL BL = new tb_co_MovimientosdetBL();
                tb_co_Movimientosdet BE = new tb_co_Movimientosdet();

                BE.perianio = VariablesPublicas.perianio;
                BE.perimes = VariablesPublicas.PADL(txtMes.Text.Trim(), 2, "0");
                BE.moduloid = VariablesDominio.VarTesoreria.Moduloid;
                BE.local = VariablesDominio.VarTesoreria.Local;
                BE.diarioid = "XXXX";
                BE.asiento = "XXXXXX"; //VariablesPublicas.PADL(txtAsiento.Text.Trim(), 6, "0");

                DetMovimiento = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //if (rbnPagos.Checked == true | rbnLetras.Checked == true)
            //{
                #region // Detalles a Amortizar / Pagar
                decimal vmdebesoles = 0;
                decimal vmdebedolares = 0;
                decimal vmhabersoles = 0;
                decimal vmhaberdolares = 0;
                decimal vmdebesoles10 = 0;
                decimal vmdebedolares10 = 0;
                decimal vmhabersoles10 = 0;
                decimal vmhaberdolares10 = 0;
                decimal ndifsoles = 0;
                for (ncont = 0; ncont <= DetFacturacion.Rows.Count - 1; ncont++)
                {
                    orow = VariablesPublicas.InsertIntoTable(DetMovimiento);
                    for (lc_contador = 0; lc_contador <= DetFacturacion.Rows.Count - 1; lc_contador++)
                    {
                        orow["cuentaid"] = DetFacturacion.Rows[ncont]["cuentaid"];
                        orow["cuentaname"] = CuentaName(VariablesPublicas.perianio, DetFacturacion.Rows[ncont]["cuentaid"].ToString());
                        orow["ctacte"] = DetFacturacion.Rows[ncont]["ctacte"];
                        orow["nmruc"] = DetFacturacion.Rows[ncont]["nmruc"];
                        orow["ctactename"] = txtCtactename.Text;
                        orow["tipdoc"] = DetFacturacion.Rows[ncont]["tipdoc"];
                        orow["serdoc"] = DetFacturacion.Rows[ncont]["serdoc"];
                        orow["numdoc"] = DetFacturacion.Rows[ncont]["numdoc"];
                        orow["fechdoc"] = DetFacturacion.Rows[ncont]["fechdoc"];
                        orow["fechvenc"] = DetFacturacion.Rows[ncont]["fechvcto"];
                        orow["importe"] = (DetFacturacion.Rows[ncont]["moneda"].ToString() == "1" ? Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importepagosoles"])) : Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importepagodolares1"])));
                        orow["importecambio"] = (DetFacturacion.Rows[ncont]["moneda"].ToString() == "1" ? Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importepagodolares1"])) : Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importepagosoles"])));
                        orow["soles"] = Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importepagosoles"]));
                        orow["dolares"] = Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importepagodolares1"]));
                        orow["moneda"] = DetFacturacion.Rows[ncont]["moneda"];
                        orow["tipcamb"] = DetFacturacion.Rows[ncont]["tipcamb"];
                        orow["tipcambuso"] = "V";
                        orow["tipcambfech"] = DetFacturacion.Rows[ncont]["fechdoc"];
                        orow["debehaber"] = (DetFacturacion.Rows[ncont]["tipdoc"].ToString() == "07" ? "H" : "D");
                        //orow["pedidoid"] = DetFacturacion.Rows[ncont]["pedidoid"];
                        //orow["tip_op"] = DetFacturacion.Rows[ncont]["tip_op"];
                        //orow["ser_op"] = DetFacturacion.Rows[ncont]["ser_op"];
                        //orow["num_op"] = DetFacturacion.Rows[ncont]["num_op"];
                    }
                    if (DetFacturacion.Rows[ncont]["tipdoc"].ToString() == "07") //VariablesPublicas.ContabilidadIdCargo)
                    {
                        vmhabersoles = vmhabersoles + Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importenetosoles"]));
                        vmhaberdolares = vmhaberdolares + Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importenetodolares"]));
                    }
                    else
                    {
                        vmdebesoles = vmdebesoles + Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importenetosoles"]));
                        vmdebedolares = vmdebedolares + Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importenetodolares"]));
                    }
                    DetMovimiento.Rows.Add(orow);
                //}
                #endregion
                #region// Detalle Cuenta bancos o Letras
                //if (rbnLetras.Checked == true)
                //{
                    //completa demas datos a letras generadas
                    for (ncont = 0; ncont <= DetLetras.Rows.Count - 1; ncont++)
                    {
                        orow = VariablesPublicas.InsertIntoTable(DetMovimiento);
                        for (lc_contador = 0; lc_contador <= DetLetras.Rows.Count - 1; lc_contador++)
                        {
                            orow["cuentaid"] = DetLetras.Rows[ncont]["cuentaid"];
                            orow["cuentaname"] = txtCuentaname.Text;
                            orow["ctacte"] = DetLetras.Rows[ncont]["ctacte"];
                            orow["nmruc"] = DetLetras.Rows[ncont]["nmruc"];
                            orow["ctactename"] = txtCtactename.Text;
                            orow["tipdoc"] = DetLetras.Rows[ncont]["tipdoc"];
                            orow["serdoc"] = DetLetras.Rows[ncont]["serdoc"];
                            orow["numdoc"] = DetLetras.Rows[ncont]["numdoc"];
                            orow["fechdoc"] = DetLetras.Rows[ncont]["fechdoc"];
                            orow["fechvenc"] = DetLetras.Rows[ncont]["fechvcto"];
                            orow["importe"] = (DetLetras.Rows[ncont]["moneda"].ToString() == "1" ? Math.Abs(Convert.ToDecimal(DetLetras.Rows[ncont]["importe1"])) : Math.Abs(Convert.ToDecimal(DetLetras.Rows[ncont]["importe1"])));
                            orow["importecambio"] = (DetLetras.Rows[ncont]["moneda"].ToString() == "1" ? Math.Abs(Convert.ToDecimal(DetLetras.Rows[ncont]["importe2"])) : Math.Abs(Convert.ToDecimal(DetLetras.Rows[ncont]["importe2"])));
                            orow["soles"] = (DetLetras.Rows[ncont]["moneda"].ToString() == "1" ? Math.Abs(Convert.ToDecimal(DetLetras.Rows[ncont]["importe1"])) : Math.Abs(Convert.ToDecimal(DetLetras.Rows[ncont]["importe2"])));
                            orow["dolares"] = (DetLetras.Rows[ncont]["moneda"].ToString() == "1" ? Math.Abs(Convert.ToDecimal(DetLetras.Rows[ncont]["importe2"])) : Math.Abs(Convert.ToDecimal(DetLetras.Rows[ncont]["importe1"])));
                            orow["moneda"] = DetLetras.Rows[ncont]["moneda"];
                            orow["tipcamb"] = txtTipocambio.Text;
                            orow["tipcambuso"] = "V";
                            orow["tipcambfech"] = fRegistro.Text;
                            orow["debehaber"] = "H";
                        }
                        DetMovimiento.Rows.Add(orow);
                    }
                //}
                //else
                //{
                //    //DetMovimiento.Rows.Add(VariablesPublicas.InsertIntoTable(DetMovimiento));
                //    DetMovimiento.ImportRow(DetMovimiento.Rows[0]);  // Duplicar la primera fila

                //    DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cuentaname"] = "";
                //    DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["debehaber"] = "";
                //    DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["importe"] = 0;
                //    DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["importecambio"] = 0;
                //    DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["soles"] = 0;
                //    DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["dolares"] = 0;

                //    DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cuentaid"] = txtCuentaidP.Text;
                //    DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cuentaname"] = txtCuentanameP.Text;
                //    DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["moneda"] = cboMonedaP.SelectedValue;

                //    if (vmdebesoles > vmhabersoles)
                //    {
                //        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["debehaber"] = VariablesPublicas.ContabilidadIdAbono;
                //        vmdebesoles10 = Math.Abs(vmdebesoles - vmhabersoles);
                //        vmdebedolares10 = Math.Abs(vmdebedolares - vmhaberdolares);
                //    }
                //    else
                //    {
                //        vmhabersoles10 = Math.Abs(vmdebesoles - vmhabersoles);
                //        vmhaberdolares10 = Math.Abs(vmdebedolares - vmhaberdolares);

                //        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["debehaber"] = VariablesPublicas.ContabilidadIdCargo;
                //    }
                //    DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["soles"] = Math.Round(Math.Abs(vmdebesoles - vmhabersoles), 2);
                //    DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["dolares"] = Math.Round(Math.Abs(vmdebedolares - vmhaberdolares), 2);
                //    DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["ctacte"] = xctacte;
                //    DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["ctactename"] = txtCtactename.Text;
                //    DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["nmruc"] = txtRuc.Text;
                //    DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["fechdoc"] = fRegistro.Text;
                //    DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["fechvenc"] = fRegistro.Text;
                //    DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["tipcamb"] = txtTipocambio.Text;
                //    DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["tipcambuso"] = "V";
                //    DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["tipcambfech"] = fRegistro.Text;

                //    if (cboMonedaP.SelectedValue.ToString() == "2")
                //    {
                //        if (vmtcambio == 0)
                //        {
                //            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["soles"] = 0;
                //        }
                //        else
                //        {
                //            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["importe"] = Math.Round(Convert.ToDecimal(DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["dolares"]), 2);
                //            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["importecambio"] = Math.Round(Convert.ToDecimal(DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["dolares"]) * vmtcambio, 2);
                //            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["soles"] = Math.Round(Convert.ToDecimal(DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["dolares"]) * vmtcambio, 2);
                //        }
                //    }
                //    else
                //    {
                //        if (vmtcambio == 0)
                //        {
                //            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["doalres"] = 0;
                //        }
                //        else
                //        {
                //            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["importe"] = Math.Round(Convert.ToDecimal(DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["soles"]), 2);
                //            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["importecambio"] = Math.Round(Convert.ToDecimal(DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["soles"]) / vmtcambio, 2);
                //            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["dolares"] = Math.Round(Convert.ToDecimal(DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["soles"]) / vmtcambio, 2);
                //        }
                //    }
                //}
                #endregion
                #region// Cuenta Retencion IGV
                for (ncont = 0; ncont <= DetFacturacion.Rows.Count - 1; ncont++)
                {
                    orow = VariablesPublicas.InsertIntoTable(DetMovimiento);
                    for (lc_contador = 0; lc_contador <= DetFacturacion.Rows.Count - 1; lc_contador++)
                    {
                        orow["cuentaid"] = txtCuentaid.Text;
                        orow["cuentaname"] = txtCuentaname.Text;
                        orow["ctacte"] = DetFacturacion.Rows[ncont]["ctacte"];
                        orow["nmruc"] = DetFacturacion.Rows[ncont]["nmruc"];
                        orow["ctactename"] = txtCtactename.Text;
                        orow["tipdoc"] = DetFacturacion.Rows[ncont]["tipdoc"];
                        orow["serdoc"] = DetFacturacion.Rows[ncont]["serdoc"];
                        orow["numdoc"] = DetFacturacion.Rows[ncont]["numdoc"];
                        orow["fechdoc"] = DetFacturacion.Rows[ncont]["fechdoc"];
                        orow["fechvenc"] = DetFacturacion.Rows[ncont]["fechvcto"];
                        orow["importe"] = (DetFacturacion.Rows[ncont]["moneda"].ToString() == "1" ? Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretencionsoles"])) : Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretenciondolares"])));
                        orow["importecambio"] = (DetFacturacion.Rows[ncont]["moneda"].ToString() == "1" ? Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretenciondolares"])) : Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretencionsoles"])));
                        orow["soles"] = Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretencionsoles"]));
                        orow["dolares"] = Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretenciondolares"]));
                        orow["moneda"] = DetFacturacion.Rows[ncont]["moneda"];
                        orow["tipcamb"] = DetFacturacion.Rows[ncont]["tipcamb"];
                        orow["tipcambuso"] = "V";
                        orow["tipcambfech"] = DetFacturacion.Rows[ncont]["fechdoc"];
                        orow["debehaber"] = (DetFacturacion.Rows[ncont]["tipdoc"].ToString() == "07" ? "D" : "H");
                    }
                    DetMovimiento.Rows.Add(orow);
                }
                #endregion
                #region // SUMATORIA SOLES/DOLARES ( EN DEBE HABER )
                vmdebesoles = 0;
                vmhabersoles = 0;
                vmdebedolares = 0;
                vmhaberdolares = 0;
                for (ncont = 0; ncont <= DetMovimiento.Rows.Count - 1; ncont++)
                {
                    DetMovimiento.Rows[ncont]["soles"] = Math.Round(Convert.ToDecimal(DetMovimiento.Rows[ncont]["soles"]), 2);
                    DetMovimiento.Rows[ncont]["dolares"] = Math.Round(Convert.ToDecimal(DetMovimiento.Rows[ncont]["dolares"]), 2);
                    if (DetMovimiento.Rows[ncont]["debehaber"].ToString() == VariablesPublicas.ContabilidadIdCargo)
                    {
                        vmdebesoles = vmdebesoles + Math.Abs(Convert.ToDecimal(DetMovimiento.Rows[ncont]["soles"]));
                        vmdebedolares = vmdebedolares + Math.Abs(Convert.ToDecimal(DetMovimiento.Rows[ncont]["dolares"]));
                    }
                    else
                    {
                        vmhabersoles = vmhabersoles + Math.Abs(Convert.ToDecimal(DetMovimiento.Rows[ncont]["soles"]));
                        vmhaberdolares = vmhaberdolares + Math.Abs(Convert.ToDecimal(DetMovimiento.Rows[ncont]["dolares"]));
                    }
                }
                #endregion
                #region // AJUSTES X DIFERENCIA DE CAMBIO
                tb_co_ConfigcuentasrhredBL BiL = new tb_co_ConfigcuentasrhredBL();
                tb_co_Configcuentasrhred BiE = new tb_co_Configcuentasrhred();

                DataTable tmptablaconfig = BiL.GetAll(VariablesPublicas.EmpresaID.ToString(), BiE).Tables[0];
                string xcuentaganancia = "";
                string xcuentaperdida = "";
                decimal ndifdolares = 0;
                string xccostoganancia = "";
                string xccostoperdida = "70101";

                if (tmptablaconfig.Rows.Count > 0)
                {
                    xcuentaganancia = tmptablaconfig.Rows[0]["cuentaiddifganancia"].ToString();
                    xcuentaperdida = tmptablaconfig.Rows[0]["cuentaiddifperdida"].ToString();
                    //xccostoganancia = tmptablaconfig.Rows[0]["CCOSTO_DIFCAMGAN"].ToString();
                    //xccostoperdida = tmptablaconfig.Rows[0]["CCOSTO_DIFCAMPER"].ToString();
                }
                //Ajustes DIF.CAMBIO EN DOLARES
                if ((!(vmhaberdolares == vmdebedolares)) & Math.Abs(vmdebedolares - vmhaberdolares) > 0)
                {
                    if (xcuentaganancia.Trim().Length > 0 & xcuentaperdida.Trim().Length > 0)
                    {
                        //DetFacturacion.Rows.Add(VariablesPublicas.InsertIntoTable(DetFacturacion));
                        DetMovimiento.ImportRow(DetMovimiento.Rows[0]);  // Duplicar la primera fila

                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cuentaname"] = "";
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["debehaber"] = "";
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["importe"] = 0;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["importecambio"] = 0;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["soles"] = 0;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["dolares"] = 0;

                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["ctacte"] = xctacte;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["nmruc"] = txtRuc.Text;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["ctactename"] = txtCtactename.Text;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["fechdoc"] = fRegistro.Text;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["fechvenc"] = fRegistro.Text;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["tipcamb"] = txtTipocambio.Text;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["tipcambuso"] = "V";
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["tipcambfech"] = fRegistro.Text;

                        ndifdolares = Math.Round(Math.Abs(vmdebedolares - vmhaberdolares), 2);
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["moneda"] = cboMoneda.SelectedValue;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["debehaber"] = (vmdebedolares > vmhaberdolares ? "H" : "D");
                        // perdida
                        if ((vmdebedolares - vmhaberdolares) < 0)
                        {
                            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cuentaid"] = xcuentaperdida;
                            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cuentaname"] = CuentaName(VariablesPublicas.perianio, xcuentaperdida);
                            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cencosid"] = xccostoperdida;
                        }
                        else
                        {
                            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cuentaid"] = xcuentaganancia;
                            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cuentaname"] = CuentaName(VariablesPublicas.perianio, xcuentaganancia);
                            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cencosid"] = xccostoganancia;
                        }
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["importe"] = 0;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["importecambio"] = Math.Abs(ndifdolares);
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["soles"] = 0;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["dolares"] = Math.Abs(ndifdolares);
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("El asiento se va a generar con diferencia... Falta Configurar cuentas de ajuste x dif.cambio", "");
                    }
                }
                //Ajustes DIF.CAMBIO EN SOLES
                if ((!(vmdebesoles == vmhabersoles)) & Math.Abs(vmdebesoles - vmhabersoles) > 0)
                {
                    if (xcuentaganancia.Trim().Length > 0 & xcuentaperdida.Trim().Length > 0)
                    {
                        //DetMovimiento.Rows.Add(VariablesPublicas.InsertIntoTable(DetMovimiento));
                        DetMovimiento.ImportRow(DetMovimiento.Rows[0]);  // Duplicar la primera fila

                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cuentaname"] = "";
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["debehaber"] = "";
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["importe"] = 0;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["importecambio"] = 0;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["soles"] = 0;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["dolares"] = 0;

                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["ctacte"] = xctacte;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["nmruc"] = txtRuc.Text;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["ctactename"] = txtCtactename.Text;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["fechdoc"] = fRegistro.Text;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["fechvenc"] = fRegistro.Text;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["tipcamb"] = txtTipocambio.Text;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["tipcambuso"] = "V";
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["tipcambfech"] = fRegistro.Text;
                        ndifsoles = Math.Abs(vmdebesoles - vmhabersoles);
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["moneda"] = cboMoneda.SelectedValue;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["debehaber"] = (vmdebesoles > vmhabersoles ? "H" : "D");
                        // perdida
                        if ((vmdebesoles - vmhabersoles) < 0)
                        {
                            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cuentaid"] = xcuentaperdida;
                            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cuentaname"] = CuentaName(VariablesPublicas.perianio, xcuentaperdida);
                            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cencosid"] = xccostoperdida;
                        }
                        else
                        {
                            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cuentaid"] = xcuentaganancia;
                            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cuentaname"] = CuentaName(VariablesPublicas.perianio, xcuentaganancia);
                            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cencosid"] = xccostoganancia;
                        }
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["importe"] = Math.Abs(ndifsoles);
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["importecambio"] = 0;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["dolares"] = 0;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["soles"] = Math.Abs(ndifsoles);
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("El asiento se va a generar con diferencia... Falta Configurar cuentas de ajuste x dif.cambio", "");
                    }
                }
                #endregion
                #region // Sumatoria para los totales Cabecera
                vmdebesoles = 0;
                vmdebedolares = 0;
                vmhabersoles = 0;
                vmhaberdolares = 0;

                for (ncont = 0; ncont <= DetMovimiento.Rows.Count - 1; ncont++)
                {
                    if (DetMovimiento.Rows[ncont]["debehaber"].ToString() == VariablesPublicas.ContabilidadIdCargo)
                    {
                        vmdebesoles = vmdebesoles + Math.Abs(Convert.ToDecimal(DetMovimiento.Rows[ncont]["soles"]));
                        sumadebesoles = vmdebesoles;
                        vmdebedolares = vmdebedolares + Math.Abs(Convert.ToDecimal(DetMovimiento.Rows[ncont]["dolares"]));
                        sumadebedolares = vmdebedolares;
                    }
                    else
                    {
                        vmhabersoles = vmhabersoles + Math.Abs(Convert.ToDecimal(DetMovimiento.Rows[ncont]["soles"]));
                        sumahabersoles = vmhabersoles;
                        vmhaberdolares = vmhaberdolares + Math.Abs(Convert.ToDecimal(DetMovimiento.Rows[ncont]["dolares"]));
                        sumahaberdolares = vmhaberdolares;
                    }
                }
                #endregion
            //}
            //else if (rbnEmision.Checked == true)
            //{
            //    #region // Detalles a Amortizar / Pagar
            //    decimal vmdebesoles = 0;
            //    decimal vmdebedolares = 0;
            //    decimal vmhabersoles = 0;
            //    decimal vmhaberdolares = 0;
            //    decimal ndifsoles = 0;
            //    for (ncont = 0; ncont <= DetFacturacion.Rows.Count - 1; ncont++)
            //    {
            //        orow = VariablesPublicas.InsertIntoTable(DetMovimiento);
            //        for (lc_contador = 0; lc_contador <= DetFacturacion.Rows.Count - 1; lc_contador++)
            //        {
            //            orow["cuentaid"] = DetFacturacion.Rows[ncont]["cuentaid"];
            //            orow["cuentaname"] = CuentaName(VariablesPublicas.perianio, DetFacturacion.Rows[ncont]["cuentaid"].ToString());
            //            orow["ctacte"] = DetFacturacion.Rows[ncont]["ctacte"];
            //            orow["nmruc"] = DetFacturacion.Rows[ncont]["nmruc"];
            //            orow["ctactename"] = txtCtactename.Text;
            //            orow["tipdoc"] = DetFacturacion.Rows[ncont]["tipdoc"];
            //            orow["serdoc"] = DetFacturacion.Rows[ncont]["serdoc"];
            //            orow["numdoc"] = DetFacturacion.Rows[ncont]["numdoc"];
            //            orow["fechdoc"] = DetFacturacion.Rows[ncont]["fechdoc"];
            //            orow["fechvenc"] = DetFacturacion.Rows[ncont]["fechvcto"];
            //            //orow["importe"] = (DetFacturacion.Rows[ncont]["moneda"].ToString() == "1" ? Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretencionsoles"])) : Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretenciondolares"])));
            //            //orow["importecambio"] = (DetFacturacion.Rows[ncont]["moneda"].ToString() == "1" ? Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretenciondolares"])) : Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretencionsoles"])));
            //            //orow["soles"] = Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretencionsoles"]));
            //            //orow["dolares"] = Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretenciondolares"]));

            //            if (DetFacturacion.Rows[ncont]["moneda"].ToString() == "1")
            //            {
            //                orow["importe"] = Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretencionsoles"]));
            //                orow["importecambio"] = Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretenciondolares"]));
            //                orow["soles"] = Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretencionsoles"]));
            //                orow["dolares"] = Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretenciondolares"]));
            //            }
            //            else if (DetFacturacion.Rows[ncont]["moneda"].ToString() == "2")
            //            {
            //                orow["importe"] = Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretenciondolares"]));
            //                orow["importecambio"] = Math.Round(Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretenciondolares"]) * Convert.ToDecimal(DetFacturacion.Rows[ncont]["tipcamb"])), 2);
            //                orow["dolares"] = Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretenciondolares"]));
            //                orow["soles"] = Math.Round(Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretenciondolares"]) * Convert.ToDecimal(DetFacturacion.Rows[ncont]["tipcamb"])), 2);
            //            }

            //            orow["moneda"] = DetFacturacion.Rows[ncont]["moneda"];
            //            orow["tipcamb"] = DetFacturacion.Rows[ncont]["tipcamb"];
            //            orow["tipcambuso"] = "V";
            //            orow["tipcambfech"] = DetFacturacion.Rows[ncont]["fechdoc"];
            //            orow["debehaber"] = (DetFacturacion.Rows[ncont]["tipdoc"].ToString() == "07" ? "H" : "D");
            //            //orow["pedidoid"] = DetFacturacion.Rows[ncont]["pedidoid"];
            //            //orow["tip_op"] = DetFacturacion.Rows[ncont]["tip_op"];
            //            //orow["ser_op"] = DetFacturacion.Rows[ncont]["ser_op"];
            //            //orow["num_op"] = DetFacturacion.Rows[ncont]["num_op"];
            //        }
            //        if (DetFacturacion.Rows[ncont]["tipdoc"].ToString() == "07") //VariablesPublicas.ContabilidadIdCargo)
            //        {
            //            //vmhabersoles = vmhabersoles + Convert.ToDecimal(DetFacturacion.Rows[ncont]["importenetosoles"]);
            //            //vmhaberdolares = vmhaberdolares + Convert.ToDecimal(DetFacturacion.Rows[ncont]["importenetodolares"]);
            //            vmhabersoles = vmhabersoles + Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importenetosoles"]));
            //            vmhaberdolares = vmhaberdolares + Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importenetodolares"]));
            //        }
            //        else
            //        {
            //            //vmdebesoles = vmdebesoles + Convert.ToDecimal(DetFacturacion.Rows[ncont]["importenetosoles"]);
            //            //vmdebedolares = vmdebedolares + Convert.ToDecimal(DetFacturacion.Rows[ncont]["importenetodolares"]);
            //            vmdebesoles = vmdebesoles + Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importenetosoles"]));
            //            vmdebedolares = vmdebedolares + Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importenetodolares"]));
            //        }
            //        DetMovimiento.Rows.Add(orow);
            //    }
            //    #endregion
            //    #region// Cuenta Retencion IGV
            //    for (ncont = 0; ncont <= DetFacturacion.Rows.Count - 1; ncont++)
            //    {
            //        orow = VariablesPublicas.InsertIntoTable(DetMovimiento);
            //        for (lc_contador = 0; lc_contador <= DetFacturacion.Rows.Count - 1; lc_contador++)
            //        {
            //            orow["cuentaid"] = txtCuentaidR.Text;
            //            orow["cuentaname"] = txtCuentanameR.Text;
            //            orow["ctacte"] = DetFacturacion.Rows[ncont]["ctacte"];
            //            orow["nmruc"] = DetFacturacion.Rows[ncont]["nmruc"];
            //            orow["ctactename"] = txtCtactename.Text;
            //            orow["tipdoc"] = DetFacturacion.Rows[ncont]["tipdoc"];
            //            orow["serdoc"] = DetFacturacion.Rows[ncont]["serdoc"];
            //            orow["numdoc"] = DetFacturacion.Rows[ncont]["numdoc"];
            //            //orow["fechdoc"] = DetFacturacion.Rows[ncont]["fechdoc"];
            //            //orow["fechvenc"] = DetFacturacion.Rows[ncont]["fechvcto"];
            //            orow["fechdoc"] = fRegistro.Text;
            //            orow["fechvenc"] = fRegistro.Text;
            //            //orow["importe"] = (DetFacturacion.Rows[ncont]["moneda"].ToString() == "1" ? Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretencionsoles"])) : Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretenciondolares"])));
            //            //orow["importecambio"] = (DetFacturacion.Rows[ncont]["moneda"].ToString() == "1" ? Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretenciondolares"])) : Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretencionsoles"])));
            //            //orow["soles"] = Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretencionsoles"]));
            //            //orow["dolares"] = Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretenciondolares"]));
            //            if (DetFacturacion.Rows[ncont]["moneda"].ToString() == "1")
            //            {
            //                orow["importe"] = Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretencionsoles"]));
            //                orow["importecambio"] = Math.Round(Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretencionsoles"])) / Convert.ToDecimal(txtTipocambio.Text), 2);
            //                orow["soles"] = Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretencionsoles"]));
            //                orow["dolares"] = Math.Round(Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretencionsoles"])) / Convert.ToDecimal(txtTipocambio.Text), 2);
            //                //if (Convert.ToDecimal(DetFacturacion.Rows[ncont]["importedifcambio"]) > 0)
            //                //{

            //                //    orow["dolares"] = Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretenciondolares"])) - Convert.ToDecimal(DetFacturacion.Rows[ncont]["importedifcambio"]);
            //                //}
            //                //else if (Convert.ToDecimal(DetFacturacion.Rows[ncont]["importedifcambio"]) < 0)
            //                //{
            //                //    orow["dolares"] = Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretenciondolares"])) + Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importedifcambio"]));
            //                //}
            //                //else
            //                //{
            //                //    orow["dolares"] = 0;
            //                //}
            //            }
            //            else if (DetFacturacion.Rows[ncont]["moneda"].ToString() == "2")
            //            {
            //                orow["importe"] = Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretenciondolares"]));
            //                orow["importecambio"] = Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretencionsoles"]));
            //                orow["dolares"] = Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretenciondolares"]));
            //                orow["soles"] = Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretencionsoles"]));
            //                //if (Convert.ToDecimal(DetFacturacion.Rows[ncont]["importedifcambio"]) > 0)
            //                //{

            //                //    orow["soles"] = Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretencionsoles"])) - Convert.ToDecimal(DetFacturacion.Rows[ncont]["importedifcambio"]);
            //                //}
            //                //else if (Convert.ToDecimal(DetFacturacion.Rows[ncont]["importedifcambio"]) < 0)
            //                //{
            //                //    orow["soles"] = Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importeretencionsoles"])) + Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["importedifcambio"]));
            //                //}
            //                //else
            //                //{
            //                //    orow["soles"] = 0;
            //                //}
            //            }
            //            orow["moneda"] = DetFacturacion.Rows[ncont]["moneda"];
            //            orow["tipcamb"] = txtTipocambio.Text;
            //            orow["tipcambuso"] = "V";
            //            orow["tipcambfech"] = fRegistro.Text;
            //            orow["debehaber"] = (DetFacturacion.Rows[ncont]["tipdoc"].ToString() == "07" ? "D" : "H");
            //        }
            //        DetMovimiento.Rows.Add(orow);
                //}
                //#endregion
                #region // SUMATORIA SOLES/DOLARES ( EN DEBE HABER )
                vmdebesoles = 0;
                vmhabersoles = 0;
                vmdebedolares = 0;
                vmhaberdolares = 0;
                for (ncont = 0; ncont <= DetMovimiento.Rows.Count - 1; ncont++)
                {
                    DetMovimiento.Rows[ncont]["soles"] = Math.Round(Convert.ToDecimal(DetMovimiento.Rows[ncont]["soles"]), 2);
                    DetMovimiento.Rows[ncont]["dolares"] = Math.Round(Convert.ToDecimal(DetMovimiento.Rows[ncont]["dolares"]), 2);
                    if (DetMovimiento.Rows[ncont]["debehaber"].ToString() == VariablesPublicas.ContabilidadIdCargo)
                    {
                        vmdebesoles = vmdebesoles + Math.Abs(Convert.ToDecimal(DetMovimiento.Rows[ncont]["soles"]));
                        vmdebedolares = vmdebedolares + Math.Abs(Convert.ToDecimal(DetMovimiento.Rows[ncont]["dolares"]));
                    }
                    else
                    {
                        vmhabersoles = vmhabersoles + Math.Abs(Convert.ToDecimal(DetMovimiento.Rows[ncont]["soles"]));
                        vmhaberdolares = vmhaberdolares + Math.Abs(Convert.ToDecimal(DetMovimiento.Rows[ncont]["dolares"]));
                    }
                }
                #endregion
                #region // AJUSTES X DIFERENCIA DE CAMBIO
                //tb_co_ConfigcuentasrhredBL BiL = new tb_co_ConfigcuentasrhredBL();
                //tb_co_Configcuentasrhred BiE = new tb_co_Configcuentasrhred();

                tmptablaconfig = BiL.GetAll(VariablesPublicas.EmpresaID.ToString(), BiE).Tables[0];
                //string xcuentaganancia = "";
                //string xcuentaperdida = "";
                //decimal ndifdolares = 0;
                //string xccostoganancia = "";
                //string xccostoperdida = "70101";

                if (tmptablaconfig.Rows.Count > 0)
                {
                    xcuentaganancia = tmptablaconfig.Rows[0]["cuentaiddifganancia"].ToString();
                    xcuentaperdida = tmptablaconfig.Rows[0]["cuentaiddifperdida"].ToString();
                    //xccostoganancia = tmptablaconfig.Rows[0]["CCOSTO_DIFCAMGAN"].ToString();
                    //xccostoperdida = tmptablaconfig.Rows[0]["CCOSTO_DIFCAMPER"].ToString();
                }
                //Ajustes DIF.CAMBIO EN DOLARES
                if ((!(vmhaberdolares == vmdebedolares)) & Math.Abs(vmdebedolares - vmhaberdolares) > 0)
                {
                    if (xcuentaganancia.Trim().Length > 0 & xcuentaperdida.Trim().Length > 0)
                    {
                        //DetFacturacion.Rows.Add(VariablesPublicas.InsertIntoTable(DetFacturacion));
                        DetMovimiento.ImportRow(DetMovimiento.Rows[0]);  // Duplicar la primera fila

                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cuentaname"] = "";
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["debehaber"] = "";
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["importe"] = 0;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["importecambio"] = 0;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["soles"] = 0;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["dolares"] = 0;

                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["ctacte"] = xctacte;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["nmruc"] = txtRuc.Text;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["ctactename"] = txtCtactename.Text;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["fechdoc"] = fRegistro.Text;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["fechvenc"] = fRegistro.Text;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["tipcamb"] = txtTipocambio.Text;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["tipcambuso"] = "V";
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["tipcambfech"] = fRegistro.Text;
                        ndifdolares = Math.Round(Math.Abs(vmdebedolares - vmhaberdolares), 2);
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["moneda"] = cboMoneda.SelectedValue;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["debehaber"] = (vmdebedolares > vmhaberdolares ? "H" : "D");
                        // perdida
                        if ((vmdebedolares - vmhaberdolares) < 0)
                        {
                            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cuentaid"] = xcuentaperdida;
                            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cuentaname"] = CuentaName(VariablesPublicas.perianio, xcuentaperdida);
                            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cencosid"] = xccostoperdida;
                        }
                        else
                        {
                            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cuentaid"] = xcuentaganancia;
                            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cuentaname"] = CuentaName(VariablesPublicas.perianio, xcuentaganancia);
                            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cencosid"] = xccostoganancia;
                        }
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["importe"] = 0;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["importecambio"] = Math.Abs(ndifdolares);
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["soles"] = 0;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["dolares"] = Math.Abs(ndifdolares);
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("El asiento se va a generar con diferencia... Falta Configurar cuentas de ajuste x dif.cambio", "");
                    }
                }
                //Ajustes DIF.CAMBIO EN SOLES
                else if ((!(vmdebesoles == vmhabersoles)) & Math.Abs(vmdebesoles - vmhabersoles) > 0)
                {
                    if (xcuentaganancia.Trim().Length > 0 & xcuentaperdida.Trim().Length > 0)
                    {
                        //DetMovimiento.Rows.Add(VariablesPublicas.InsertIntoTable(DetMovimiento));
                        DetMovimiento.ImportRow(DetMovimiento.Rows[0]);  // Duplicar la primera fila

                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cuentaname"] = "";
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["debehaber"] = "";
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["importe"] = 0;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["importecambio"] = 0;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["soles"] = 0;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["dolares"] = 0;

                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["ctacte"] = xctacte;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["nmruc"] = txtRuc.Text;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["ctactename"] = txtCtactename.Text;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["fechdoc"] = fRegistro.Text;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["fechvenc"] = fRegistro.Text;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["tipcamb"] = txtTipocambio.Text;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["tipcambuso"] = "V";
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["tipcambfech"] = fRegistro.Text;
                        ndifsoles = Math.Abs(vmdebesoles - vmhabersoles);
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["moneda"] = cboMoneda.SelectedValue;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["debehaber"] = (vmdebesoles > vmhabersoles ? "H" : "D");
                        // perdida
                        if ((vmdebesoles - vmhabersoles) < 0)
                        {
                            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cuentaid"] = xcuentaperdida;
                            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cuentaname"] = CuentaName(VariablesPublicas.perianio, xcuentaperdida);
                            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cencosid"] = xccostoperdida;
                        }
                        else
                        {
                            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cuentaid"] = xcuentaganancia;
                            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cuentaname"] = CuentaName(VariablesPublicas.perianio, xcuentaganancia);
                            DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["cencosid"] = xccostoganancia;
                        }
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["importe"] = Math.Abs(ndifsoles);
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["importecambio"] = 0;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["dolares"] = 0;
                        DetMovimiento.Rows[DetMovimiento.Rows.Count - 1]["soles"] = Math.Abs(ndifsoles);
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("El asiento se va a generar con diferencia... Falta Configurar cuentas de ajuste x dif.cambio", "");
                    }
                }
                #endregion
                #region // Sumatoria para los totales Cabecera
                vmdebesoles = 0;
                vmdebedolares = 0;
                vmhabersoles = 0;
                vmhaberdolares = 0;

                for (ncont = 0; ncont <= DetMovimiento.Rows.Count - 1; ncont++)
                {
                    if (DetMovimiento.Rows[ncont]["debehaber"].ToString() == VariablesPublicas.ContabilidadIdCargo)
                    {
                        vmdebesoles = vmdebesoles + Math.Abs(Convert.ToDecimal(DetMovimiento.Rows[ncont]["soles"]));
                        sumadebesoles = vmdebesoles;
                        vmdebedolares = vmdebedolares + Math.Abs(Convert.ToDecimal(DetMovimiento.Rows[ncont]["dolares"]));
                        sumadebedolares = vmdebedolares;
                    }
                    else
                    {
                        vmhabersoles = vmhabersoles + Math.Abs(Convert.ToDecimal(DetMovimiento.Rows[ncont]["soles"]));
                        sumahabersoles = vmhabersoles;
                        vmhaberdolares = vmhaberdolares + Math.Abs(Convert.ToDecimal(DetMovimiento.Rows[ncont]["dolares"]));
                        sumahaberdolares = vmhaberdolares;
                    }
                }
                #endregion
            }
        }
        private void seguridadlog()
        {
            //string xclave = VariablesPublicas.EmpresaID + VariablesPublicas.perianio + cboSubdiario.SelectedValue.ToString() + txtMes.Text + txtSerie.Text + txtNumero.Text;
            //string xclave = VariablesPublicas.EmpresaID + VariablesPublicas.perianio + cboSubdiario.SelectedValue.ToString() + txtMes.Text + txtAsiento.Text;
            string xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio + "/" + cboSubdiario.SelectedValue.ToString() + "/" + txtMes.Text + "-" + txtAsiento.Text;
            try
            {
                tb_co_seguridadlogBL BL = new tb_co_seguridadlogBL();
                tb_co_seguridadlog BE = new tb_co_seguridadlog();

                BE.moduloid = Name;
                BE.clave = xclave;
                BE.cuser = VariablesPublicas.Usuar;
                BE.fecha = DateTime.Now;
                BE.pc = VariablesPublicas.userip;
                BE.accion = (u_n_opsel == 1 ? "N" : "M");
                //BE.detalle = txtGlosa.Text + "/" +txtRuc.Text + " - " + txtCtactename.Text;
                BE.detalle = txtGlosa.Text.Trim() + "/" + txtTipdoc.Text + "-" + txtSerdoc.Text + "-" + txtNumdoc.Text + "/" + txtRuc.Text.Trim() + "-" + txtCtactename.Text.Trim();

                BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Validacion_Grabar()
        {
            object xobjeto = null;
            int lc_cont = 0;
            string xmsgstring = "";
            DataTable tmptabla = new DataTable();
            dynamic xfill = "###...";
            if (txtCuentaid.Text.Trim().Length == 0)
            {
                xmsgstring = (xmsgstring + ("\r\n" + "Configure Cuenta para retención del IGV !!!"));
                xobjeto = txtCuentaid;
            }
            //if (txtCuentaidP.Text.Trim().Length == 0)
            //{
            //    if (rbnPagos.Checked == true | rbnLetras.Checked == true)
            //    {
            //        xmsgstring = (xmsgstring + ("\r\n" + "Configure Cuenta para el pago o canje en letras !!!"));
            //        xobjeto = txtCuentaidP;
            //    }
            //}
            if (txtRuc.Text.Trim().Length == 0)
            {
                xmsgstring = (xmsgstring + ("\r\n" + "Ingrese Proveedor !!!"));
                xobjeto = txtRuc;
            }
            else
            {
                try
                {
                    clienteBL BL = new clienteBL();
                    tb_cliente BE = new tb_cliente();

                    BE.nmruc = txtRuc.Text.Trim();
                    tmptabla = BL.GetAll(VariablesPublicas.EmpresaID, BE).Tables[0];
                    if ((BL.Sql_Error.Length > 0))
                    {
                        Frm_Class.ShowError(("Error al validar datos de proveedor" + ("\r\n" + BL.Sql_Error)), this);
                        return false;
                    }
                    if ((tmptabla.Rows.Count == 0))
                    {
                        xmsgstring = (xmsgstring + ("\r\n" + "Proveedor no existe"));
                        xobjeto = txtRuc;
                    }
                    //if ((BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0]).Rows.Count == 0)
                    //{
                    //    xmsgstring = (xmsgstring + ('\r' + "Proveedor no existe !!!"));
                    //    xobjeto = txtRuc;
                    //}
                    else
                    {
                        if ((!object.ReferenceEquals(tmptabla.Rows[0]["agerent"], DBNull.Value)))
                        {
                            if (Convert.ToBoolean(tmptabla.Rows[0]["agerent"]))
                            {
                                xmsgstring = (xmsgstring + ("\r\n" + "No se puede aplicar retención sobre un Agente de Retención"));
                                xobjeto = txtRuc;
                            }
                        }
                        if ((!object.ReferenceEquals(tmptabla.Rows[0]["buencontr"], DBNull.Value)))
                        {
                            if (Convert.ToBoolean(tmptabla.Rows[0]["buencontr"]))
                            {
                                xmsgstring = (xmsgstring + ("\r\n" + "No se puede aplicar retención sobre un buen contribuyente"));
                                xobjeto = txtRuc;
                            }
                        }
                        if ((!object.ReferenceEquals(tmptabla.Rows[0]["agenperc"], DBNull.Value)))
                        {
                            if (Convert.ToBoolean(tmptabla.Rows[0]["agenperc"]))
                            {
                                xmsgstring = (xmsgstring + ("\r\n" + "No se puede aplicar retención sobre un Agente de Percepción"));
                                xobjeto = txtRuc;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            decimal vmncambio = VariablesPublicas.StringtoDecimal(txtTipocambio.Text);
            if (vmncambio == 0)
            {
                xmsgstring = (xmsgstring + ("\r\n" + "Ingrese Tipo de Cambio !!!"));
                xobjeto = fRegistro;
            }

            if ((txtGlosa.Text.Trim()).Trim().Length == 0)
            {
                xmsgstring = (xmsgstring + ("\r\n" + "Ingrese glosa !!!"));
                xobjeto = txtGlosa;
            }
            //if ((txtNumOpe.Text.Trim()).Trim().Length == 0)
            //{
            //    xmsgstring = (xmsgstring + ("\r\n" + "Ingrese Número Cheque u Operación !!!"));
            //    xobjeto = txtNumOpe;
            //}
            decimal montoretencion = VariablesPublicas.StringtoDecimal(txtImpRetencion.Text);
            if (montoretencion == 0)
            {
                xmsgstring = (xmsgstring + ("\r\n" + "Click en Botón Cálcular Retención !!!"));
                xobjeto = btnCalcular;
            }
            if ((xmsgstring.Trim().Length == 0))
            {
                for (lc_cont = 0; (lc_cont <= (DetFacturacion.Rows.Count - 1)); lc_cont++)
                {
                    if (((Convert.ToDecimal(DetFacturacion.Rows[lc_cont]["importeretencionsoles"]) == 0))) //&& (Convert.ToDecimal(DetFacturacion.Rows[lc_cont]["impretencion1"]) == 0)))
                    {
                        xmsgstring = (xmsgstring + ("\r\n" + "Ingrese Retención del documento"));
                    }
                    if (((DetFacturacion.Rows[lc_cont]["tipdoc"].ToString().Trim().Length > 0) && (DetFacturacion.Rows[lc_cont]["numdoc"].ToString().Trim().Length > 0)))
                    {
                        tb_co_ComprascabBL BLCO = new tb_co_ComprascabBL();
                        tb_co_Comprascab BECO = new tb_co_Comprascab();

                        BECO.nmruc = txtRuc.Text.Trim();
                        BECO.tipodoc = DetFacturacion.Rows[lc_cont]["tipdoc"].ToString();
                        BECO.serdoc = DetFacturacion.Rows[lc_cont]["serdoc"].ToString();
                        BECO.numdoc = DetFacturacion.Rows[lc_cont]["numdoc"].ToString();
                        tmptabla = BLCO.GetAll(VariablesPublicas.EmpresaID.ToString(), BECO).Tables[0];
                        //tmptabla = ocapa.KAG0300_consulta(GlobalVars.GetInstance.Company, "", "", "", "", "", TXTCODCLIENTE.Text, DetFacturacion.Rows[lc_cont]["tipdoc_3a"], DetFacturacion.Rows[lc_cont]["numdoc"].Substring(0, 4), DetFacturacion.Rows[lc_cont]["numdoc"].Substring(5, 8));
                        if ((BLCO.Sql_Error.Length > 0))
                        {
                            Frm_Class.ShowError(("Error al validar documento de Compra " + ("\r\n" + BLCO.Sql_Error)), this);
                            return false;
                        }
                        if ((tmptabla.Rows.Count > 0))
                        {
                            if ((Convert.ToBoolean(tmptabla.Rows[0]["afecdetraccion"]) == true))
                            {
                                xmsgstring = (xmsgstring + "\r\n"
                                            + "Asiento R/C N°: " + tmptabla.Rows[0]["diarioid"].ToString() + "/" + tmptabla.Rows[0]["perimes"].ToString() + "-" + tmptabla.Rows[0]["asiento"].ToString() + "\r\n"

                                            + "Comprobante N°: "
                                            + DetFacturacion.Rows[lc_cont]["tipdoc"].ToString() + "/" + DetFacturacion.Rows[lc_cont]["serdoc"].ToString() + "-" + DetFacturacion.Rows[lc_cont]["numdoc"].ToString() + "\r\n"
                                            + "Tiene Detracción ... Imposible Aplicar Retención");
                            }
                        }
                    }
                }
            }

            if (xmsgstring.Trim().Length == 0)
            {
                //if (u_n_opsel == 1 | (W_KEY0001 != cboTipdoc.SelectedValue.ToString().Trim() + txtSerie.Text.Trim() + txtNumero.Text.Trim()))
                //{
                //    tmptabla = null;
                //    try
                //    {
                //        tb_co_retencionescabBL BL = new tb_co_retencionescabBL();
                //        tb_co_retencionescab BE = new tb_co_retencionescab();

                //        //BE.nmruc = txtRuc.Text;
                //        BE.tipdoc = cboTipdoc.SelectedValue.ToString().Trim();
                //        BE.serdoc = txtSerie.Text.Trim();
                //        BE.numdoc = txtNumero.Text.Trim();

                //        tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                //        if (!(tmptabla == null))
                //        {
                //            if (tmptabla.Rows.Count > 0)
                //            {
                //                xmsgstring = ("Documento Ya registrado en Periodo : " + tmptabla.Rows[0]["perianio"] + " Registro Nº "
                //                            + tmptabla.Rows[0]["perimes"] + "-" + tmptabla.Rows[0]["asiento"]);
                //                xobjeto = txtNumero;
                //            }
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}
            }
            if (!(xobjeto == null))
            {
                try
                {
                    xobjeto = Focus();
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (xmsgstring.Trim().Length > 0 & xmsgstring.Trim() != xfill)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(xmsgstring, "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (xmsgstring.Trim().Length == 0)
            {
                if (!PuedeEditarEliminar("Grabar Nuevo Registro", VariablesPublicas.PADL(fRegistro.Value.Month.ToString(), 2, "0")))
                {
                    xmsgstring = "...";
                }
            }
            if (xmsgstring.Trim().Length == 0)
            {
                return VariablesPublicas.U_ValidaFechaRegistroProvision(VariablesPublicas.perianio, txtMes.Text, fRegistro.Value);
            }
            else
            {
                return xmsgstring.Trim().Length == 0;
            }
        }

        private void actualizatipocambio()
        {
            tipocambioBL BL = new tipocambioBL();
            tb_tipocambio BE = new tb_tipocambio();

            BE.fecha = Convert.ToDateTime(fRegistro.Text);
            DataTable tcambio = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

            if (tcambio.Rows.Count > 0)
            {
                txtTipocambio.Text = tcambio.Rows[0]["venta"].ToString();
            }
            else
            {
                txtTipocambio.Text = "";
            }

            //tipocambioBL BL = new tipocambioBL();
            //tb_tipocambio BE = new tb_tipocambio();

            //if (cboTcamuso.Text.Substring(0, 1) != "E")
            //{
            //    txtTipocambio.Enabled = false;

            //    BE.fecha = Convert.ToDateTime(fRegistro.Text);
            //    DataTable tcambio = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

            //    if (tcambio.Rows.Count > 0)
            //    {
            //        if (cboTcamuso.Text.Substring(0, 1) == "V")
            //        { txtTipocambio.Text = tcambio.Rows[0]["venta"].ToString(); }
            //        if (cboTcamuso.Text.Substring(0, 1) == "C")
            //        { txtTipocambio.Text = tcambio.Rows[0]["compra"].ToString(); }
            //        if (cboTcamuso.Text.Substring(0, 1) == "P")
            //        { txtTipocambio.Text = tcambio.Rows[0]["promedio"].ToString(); }
            //    }
            //    else
            //    {
            //        txtTipocambio.Text = "0";
            //        decimal TipoCambio = VariablesPublicas.StringtoDecimal(txtTipocambio.Text);
            //        txtTipocambio.Text = TipoCambio.ToString("##.0000");
            //        //XtraMessageBox.Show("Actualice el Tipo de Cambio?", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //else
            //{
            //    txtTipocambio.Enabled = true;
            //    decimal TipoCambio = VariablesPublicas.StringtoDecimal(txtTipocambio.Text);
            //    txtTipocambio.Text = TipoCambio.ToString("##.00000");
            //}
        }

        private void fRegistro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("\t");
            }
        }
        private void fRegistro_ValueChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0)
            {
                Decimal _porcRetencionX = TasaRretencion();
                actualizatipocambio();
                totalizarItem();
                fecVenc.Text = fRegistro.Text;
                btnCalcular.Text = "Cálcular Retención " + _porcRetencionX.ToString("##.00") + "% - IGV";
            }
        }

        private void Accion(int Naccion, string xmes, string xnumero)
        {
            switch (Naccion)
            {
                case 1:
                    UltimoNumeroRegistro();
                    procesanumero();
                    break;
                case 2:
                    CargaDatos();
                    u_n_opsel = 2;
                    refrescacontroles();
                    break;
                case 3:
                    // eliminar
                    DataTable tmptabla = new DataTable();
                    tb_co_retencionescabBL BL = new tb_co_retencionescabBL();
                    tb_co_retencionescab BE = new tb_co_retencionescab();

                    BE.perianio = VariablesPublicas.perianio;
                    BE.perimes = VariablesPublicas.PADL(txtMes.Text.Trim(), 2, "0");
                    BE.moduloid = VariablesDominio.VarTesoreria.Moduloid;
                    BE.local = VariablesDominio.VarTesoreria.Local;
                    BE.diarioid = cboSubdiario.SelectedValue.ToString();
                    BE.asiento = VariablesPublicas.PADL(txtAsiento.Text.Trim(), 6, "0");
                    tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                    //DataTable tmptabla;
                    //txtAsiento.Text = VariablesPublicas.PADL(txtAsiento.Text.Trim(), 8, "0");
                    //xnum = txtAsiento.Text;
                    //tmptabla = ocapa.KAG0300_consulta(GlobalVars.GetInstance.Company, GlobalVars.GetInstance.Periodo, txtmes.Text, xnum, "", "", "", "", "", "");
                    if (tmptabla.Rows.Count > 0)
                    {
                        string message = "Desea eliminar Registro de Percepciones " + tmptabla.Rows[0]["perianio"] + "/" + tmptabla.Rows[0]["diarioid"] + "/" + tmptabla.Rows[0]["perimes"] + "-" + tmptabla.Rows[0]["asiento"] + " ...?";
                        string caption = "Mensaje del Sistema";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;
                        // Muestra el cuadro de mensaje.
                        result = DevExpress.XtraEditors.XtraMessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                            tb_co_retencionesBL BL1 = new tb_co_retencionesBL();
                            tb_co_retenciones BE1 = new tb_co_retenciones();

                            BE1.perianio = VariablesPublicas.perianio;
                            BE1.perimes = VariablesPublicas.PADL(txtMes.Text.Trim(), 2, "0");
                            BE1.moduloid = VariablesDominio.VarTesoreria.Moduloid;
                            BE1.local = VariablesDominio.VarTesoreria.Local;
                            BE1.diarioid = cboSubdiario.SelectedValue.ToString();
                            BE1.asiento = VariablesPublicas.PADL(txtAsiento.Text.Trim(), 6, "0");
                            if (BL1.Delete(VariablesPublicas.EmpresaID.ToString(), BE1))
                            {
                                txtAsiento.Focus();
                            }
                            else
                            {
                                Frm_Class.ShowError(BL1.Sql_Error, this);
                            }
                        }
                    }
                    CargaDatos();
                    break;
                case 5:
                    CargaDatos();
                    refrescacontroles();
                    break;
                //case 6:
                    //// Impresion de Comprobante de Percepcion
                    //ReportesContabilidad.Frm_ReporteVouchers frm = new ReportesContabilidad.Frm_ReporteVouchers();
                    //frm._tipComprobante = cboSubdiario.SelectedValue.ToString();
                    //frm._nroComprobante = (xmes.Trim().Length == 0 ? txtMes.Text : xmes) + (xnumero.Trim().Length == 0 ? txtAsiento.Text : xnumero);
                    //frm._xModulo = VariablesDominio.VarTesoreria.Moduloid;
                    //frm._xLocal = VariablesDominio.VarTesoreria.Local;
                    ////frm._tipoOperacion = txtcodoperacion.Text;
                    //frm._tipoOperacion = "1";
                    //frm.Owner = this;
                    //frm.ShowInTaskbar = false;
                    //frm.ShowDialog();
                    //break;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            AyudaRetenciones(1);
        }
        private void AyudaRetenciones(int nivel)
        {
            //Ayudas.Frm_AyudaRegistrocompras Form = new Ayudas.Frm_AyudaRegistrocompras();
            //Form._Mes = ((nivel == 1) ? txtMes.Text.Trim() : "");
            //Form._PasaRegCompras = RegCompras;
            //Form.Owner = this;
            //Form.ShowDialog();
        }
        private void RegCompras(string regmes, string regdiario, string regnumero, string detalle)
        {
            txtMes.Text = regmes;
            txtAsiento.Text = regnumero;
            //sELECCIONAaYUDA = true;
            procesanumero();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (1 == 1)
            {
                Frm_Identificacion xxxform = new Frm_Identificacion();
                xxxform.TipoProceso = "CO02"; //Eliminar Asiento Contable
                xxxform.Owner = this;
                xxxform.PasaIdentificacionDelegado = PasaIdentificacionXX;
                xxxform.ShowDialog();
            }
            else
            {
                //Frm_RegimenRetenciones OFORM = new Frm_RegimenRetenciones();
                VariablesPublicas.ExistForm(this, new Frm_CanjeLetrasMovimiento(), true);
            }
        }
        private void PasaIdentificacionXX(string CodUSer)
        {
            //Aca Llamar a Eliminar Asiento Contable
            //DataTable xData = new DataTable();
            if (CodUSer.Trim().Length > 0)
            {
                if (PuedeEditarEliminar("ELIMINAR", VariablesPublicas.PADL(fRegistro.Value.Month.ToString(), 2, "0")))
                {
                    Accion(3, "", "");
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Usuario No Autorizado... Consulte a Sistemas?", "Mensaje del Sistema");
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (u_n_opsel == 0)
            {
                FrmSeguridad frmNew = new FrmSeguridad();
                //string xclave = VariablesPublicas.EmpresaID + VariablesPublicas.perianio + cboSubdiario.SelectedValue.ToString() + txtMes.Text + txtSerie.Text + txtNumero.Text;
                string xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio + "/" + cboSubdiario.SelectedValue.ToString() + "/" + txtMes.Text + "-" + txtAsiento.Text;
                frmNew._Nombre = Name;
                frmNew._ClaveForm = xclave;
                frmNew.Owner = this;
                frmNew.ShowDialog();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Accion(1, "", "");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (DevExpress.XtraEditors.XtraMessageBox.Show("Quieres cerrar el formulario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        #region Metodos PADL
        private void txtTipdoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("\t");
            }
        }
        private void txtTipdoc_LostFocus(object sender, System.EventArgs e)
        {
            //if (u_n_opsel > 0)
            //{
            if (txtTipdoc.Text.Trim().Length > 0)
            {
                txtTipdoc.Text = txtTipdoc.Text.Trim().PadLeft(txtTipdoc.MaxLength, '0');
                //txtSerie.Text = VariablesPublicas.PADL(txtSerie.Text.Trim(), txtSerie.MaxLength, "0");
            }
            //}
        }

        private void txtSerdoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("\t");
            }
        }
        private void txtSerdoc_LostFocus(object sender, System.EventArgs e)
        {
            //if (u_n_opsel > 0)
            //{
            if (txtSerdoc.Text.Trim().Length > 0)
            {
                txtSerdoc.Text = txtSerdoc.Text.Trim().PadLeft(txtSerdoc.MaxLength, '0');
                //txtSerie.Text = VariablesPublicas.PADL(txtSerie.Text.Trim(), txtSerie.MaxLength, "0");
            }
            //}
        }

        private void txtNumdoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("\t");
            }
            if (e.KeyCode == Keys.F1)
            {
                AyudaRetenciones(1);
            }
        }
        private void txtNumdoc_LostFocus(object sender, System.EventArgs e)
        {
            //if (u_n_opsel > 0)
            //{
            if (txtNumdoc.Text.Trim().Length > 0)
            {
                //txtNumero.Text = txtNumero.Text.Trim().PadLeft(txtNumero.MaxLength, '0');
                txtNumdoc.Text = VariablesPublicas.PADL(txtNumdoc.Text.Trim(), 10, "0");
            }
            //}
        }
        #endregion

        private void u_ShowGets()
        {
            lblAnulado.Text = "";
            if (!(CabFacturacion == null))
            {
                if (CabFacturacion.Rows.Count > 0)
                {
                    lblAnulado.Text = (chkActivo.Checked ? "" : "ANULADO");
                }
            }
            lblAnulado.Visible = (!chkActivo.Checked & (lblAnulado.Text.Trim().Length > 0));

            lblAuditoria.Text = "";
            if (!(CabFacturacion == null))
            {
                if (CabFacturacion.Rows.Count > 0)
                {
                    lblAuditoria.Text = CabFacturacion.Rows[0]["Usuar"].ToString().ToUpper().Trim() + " - " + CabFacturacion.Rows[0]["feact"].ToString();
                }
            }
            lblAuditoria.Visible = (lblAuditoria.Text.Trim().Length > 0);
        }

        private void chkActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0)
            {
                u_ShowGets();
            }
        }

        private void btnDelFila_Click(object sender, EventArgs e)
        {
            string xcoditem = "";
            Int16 lc_cont;
            if (!(Examinar.CurrentRow == null))
            {
                xcoditem = Examinar.Rows[Examinar.CurrentCell.RowIndex].Cells["asientoitems"].Value.ToString();
                for (lc_cont = 0; (lc_cont <= (DetFacturacion.Rows.Count - 1)); lc_cont++)
                {
                    if (DetFacturacion.Rows[lc_cont]["asientoitems"].ToString() == xcoditem)
                    {
                        //  ubique el item a borrar
                        DetFacturacion.Rows[lc_cont].Delete();
                        DetFacturacion.AcceptChanges();
                        break;
                    }
                }
                //  regenerar el nro de item
                for (lc_cont = 0; (lc_cont <= (DetFacturacion.Rows.Count - 1)); lc_cont++)
                {
                    DetFacturacion.Rows[lc_cont]["asientoitems"] = VariablesPublicas.PADL(Convert.ToString(lc_cont + 1), 5, "0");
                }
                totalizar();
                refrescacontroles();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Ayudas.Frm_AyudaBuscarregistrocompras oform = new Ayudas.Frm_AyudaBuscarregistrocompras();
            //oform._diario = xDiarioid;
            //oform.Owner = this;
            //oform._PasaRegCOMPRAS = reciberegistrocompra;
            //oform.ShowDialog();
        }
        private void reciberegistrocompra(string mes, string diario, string numero)
        {
            if (mes.Trim().Length > 0)
            {
                //sELECCIONAaYUDA = true;
                txtMes.Text = mes;
                txtAsiento.Text = numero;
                procesanumero();
            }
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            //  Si el control tiene el foco...
            if ((keyData == Keys.Enter) & !txtAsiento.Focused)
            {
                if (!(Examinar.CurrentCell == null))
                {
                    //if (Examinar.Columns[Examinar.CurrentCell.ColumnIndex].Name.ToUpper() == "numguia".ToUpper())
                    //{

                    //}
                    //else
                    //{
                    SendKeys.Send("\t");
                    return true;
                    //}
                }
                else if (Examinar.Focused)
                {
                    if (!Examinar.IsCurrentCellInEditMode)
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
            else if (txtAsiento.Focused)
            {
                if (keyData == Keys.Tab)
                {
                    procesanumero();
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnVoucher_Click(object sender, EventArgs e)
        {
            Accion(6, "", "");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Accion(5, "", "");
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            u_Roleo(Genericas.toprecord);
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            u_Roleo(Genericas.prevrecord);
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            u_Roleo(Genericas.nextrecord);
        }
        private void btnFinal_Click(object sender, EventArgs e)
        {
            u_Roleo(Genericas.bottrecord);
        }
        private void u_Roleo(string xtipo)
        {
            string vmnum = "";
            tb_co_retencionescabBL BL = new tb_co_retencionescabBL();
            tb_co_retencionescab BE = new tb_co_retencionescab();

            BE.perianio = VariablesPublicas.perianio;
            BE.perimes = txtMes.Text.Trim();
            BE.moduloid = VariablesDominio.VarTesoreria.Moduloid;
            BE.local = VariablesDominio.VarTesoreria.Local;
            BE.diarioid = cboSubdiario.SelectedValue.ToString();
            BE.asiento = txtAsiento.Text.Trim();
            BE.tipo = xtipo.Trim();
            vmnum = BL.GetAsientoRoleo(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0].Rows[0]["numero"].ToString();

            if (vmnum.Trim().Length > 0)
            {
                txtMes.Focus();
                txtAsiento.Text = vmnum.Trim();
                procesanumero();
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (txtRuc.Text.Trim().Trim().Length == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Ingrese R.U.C.", "Mensaje del Sistema");
                txtRuc.Focus();
                return;
            }
            //Frm_SeleccionarPendientes oform = new Frm_SeleccionarPendientes();
            //oform.Owner = this;
            //oform._PasarMovimiento = SeleccionaPendientes;
            //oform._CodDetalle = txtRuc.Text.Trim();
            //oform.ShowDialog();
            //cboMoneda_SelectedIndexChanged(sender, e);
        }
        public void SeleccionaPendientes(DataTable DataClonadaMap030f, bool zselecciona)
        {
            Decimal xacuenta = 0;
            Decimal xorigen = 0;
            Decimal xsoles = 0;
            Decimal xdolares = 0;

            if (zselecciona)
            {
                if (DataClonadaMap030f != null)
                {
                    if (DataClonadaMap030f.Rows.Count > filasaimprimir)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Se excedió número de filas a imprimir = " + Convert.ToString(filasaimprimir), "Aviso");
                        return;
                    }

                    if (DataClonadaMap030f.Rows.Count > 0)
                    {
                        int vmfilas = 0;
                        int nContador = 0;
                        int vmcolumnas = 0;
                        DetFacturacion.AcceptChanges();
                        while (DetFacturacion.Rows.Count > 0)
                        {
                            DetFacturacion.Rows[DetFacturacion.Rows.Count - 1].Delete();
                            DetFacturacion.AcceptChanges();
                        }
                        DataClonadaMap030f.AcceptChanges();
                        for (nContador = 0; nContador <= DataClonadaMap030f.Rows.Count - 1; nContador++)
                        {
                            if (DataClonadaMap030f.Rows[nContador].RowState != DataRowState.Deleted)
                            {
                                if (!(Convert.ToBoolean(DataClonadaMap030f.Rows[nContador]["selecciona"]) == true))
                                {
                                    DataClonadaMap030f.Rows[nContador].Delete();
                                }
                            }
                        }
                        DataClonadaMap030f.AcceptChanges();

                        DetFacturacion.AcceptChanges();
                        for (vmfilas = 0; vmfilas <= DataClonadaMap030f.Rows.Count - 1; vmfilas++)
                        {
                            DetFacturacion.Rows.Add(VariablesPublicas.InsertIntoTable(DetFacturacion));
                            for (vmcolumnas = 0; vmcolumnas <= DataClonadaMap030f.Columns.Count - 1; vmcolumnas++)
                            {
                                if (VariablesPublicas.SeekNameColumn(DetFacturacion, DataClonadaMap030f.Columns[vmcolumnas].ColumnName))
                                {
                                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1][DataClonadaMap030f.Columns[vmcolumnas].ColumnName] = DataClonadaMap030f.Rows[vmfilas][vmcolumnas];
                                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cuentaid"] = DataClonadaMap030f.Rows[vmfilas]["cuentaid"];
                                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["ctacte"] = DataClonadaMap030f.Rows[vmfilas]["ctacte"];
                                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["nmruc"] = DataClonadaMap030f.Rows[vmfilas]["nmruc"];
                                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["tipdoc"] = DataClonadaMap030f.Rows[vmfilas]["tipdoc"];
                                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["serdoc"] = DataClonadaMap030f.Rows[vmfilas]["serdoc"];
                                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["numdoc"] = DataClonadaMap030f.Rows[vmfilas]["numdoc"];
                                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["fechdoc"] = DataClonadaMap030f.Rows[vmfilas]["fechdoc"];
                                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["fechvcto"] = DataClonadaMap030f.Rows[vmfilas]["fechvenc"];
                                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["moneda"] = DataClonadaMap030f.Rows[vmfilas]["moneda"];
                                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["tipcamb"] = DataClonadaMap030f.Rows[vmfilas]["tipcamb"];
                                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["tipcambuso"] = "V";
                                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["motivo"] = "COMPRA";

                                    if (DataClonadaMap030f.Rows[vmfilas]["moneda"].ToString() == "1")
                                    {
                                        xacuenta = Math.Round(Convert.ToDecimal(DataClonadaMap030f.Rows[vmfilas]["pagosoles"]), 2);
                                    }
                                    else if (DataClonadaMap030f.Rows[vmfilas]["moneda"].ToString() == "2")
                                    {
                                        xacuenta = Math.Round(Convert.ToDecimal(DataClonadaMap030f.Rows[vmfilas]["pagodolares"]) * Convert.ToDecimal(DataClonadaMap030f.Rows[vmfilas]["tipcamb"]), 2);
                                    }

                                    ////if (DataClonadaMap030f.Rows[vmfilas]["tipdoc"].ToString() == "07")
                                    ////{
                                    ////    xorigen = -Math.Abs(Convert.ToDecimal(DataClonadaMap030f.Rows[vmfilas]["debe1"]));
                                    ////}
                                    ////else
                                    ////{
                                    ////    xorigen = Convert.ToDecimal(DataClonadaMap030f.Rows[vmfilas]["habe1"]);
                                    ////}
                                    ////if (DataClonadaMap030f.Rows[vmfilas]["moneda"].ToString() == "1")
                                    ////{
                                    ////    if (DataClonadaMap030f.Rows[vmfilas]["tipdoc"].ToString() == "07")
                                    ////    {
                                    ////        xsoles = -Math.Abs(Convert.ToDecimal(DataClonadaMap030f.Rows[vmfilas]["debe1"]));
                                    ////    }
                                    ////    else
                                    ////    {
                                    ////        xsoles = Convert.ToDecimal(DataClonadaMap030f.Rows[vmfilas]["habe1"]);
                                    ////    }
                                    ////}
                                    ////else
                                    ////{
                                    ////    xsoles = 0;
                                    ////}
                                    //////
                                    ////if (DataClonadaMap030f.Rows[vmfilas]["moneda"].ToString() == "2")
                                    ////{
                                    ////    if (DataClonadaMap030f.Rows[vmfilas]["tipdoc"].ToString() == "07")
                                    ////    {
                                    ////        xdolares = -Math.Abs(Convert.ToDecimal(DataClonadaMap030f.Rows[vmfilas]["debe2"]));
                                    ////    }
                                    ////    else
                                    ////    {
                                    ////        xdolares = Convert.ToDecimal(DataClonadaMap030f.Rows[vmfilas]["habe2"]);
                                    ////    }
                                    ////}
                                    ////else
                                    ////{
                                    ////    xdolares = 0;
                                    ////}
                                    //////

                                    ////DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importeorigendolares"] = xdolares;

                                    ////if (DataClonadaMap030f.Rows[vmfilas]["moneda"].ToString() == "2")
                                    ////{
                                    ////    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importepagodolares1"] = Math.Round(Convert.ToDecimal(DataClonadaMap030f.Rows[vmfilas]["pagodolares"]), 2);
                                    ////}

                                    ////DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importeorigensoles"] = xsoles;

                                    ////if (DataClonadaMap030f.Rows[vmfilas]["tipdoc"].ToString() == "07" & xacuenta > 0)
                                    ////{
                                    ////    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importepagosoles"] = -Math.Abs(xacuenta);
                                    ////}
                                    ////else
                                    ////{
                                    ////    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importepagosoles"] = xacuenta;
                                    ////}

                                    ////DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importeorigen"] = xorigen;
                                    ////if (DataClonadaMap030f.Rows[vmfilas]["tipdoc"].ToString() == "07" & xacuenta > 0)
                                    ////{
                                    ////    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importepago"] = -Math.Abs(xacuenta);
                                    ////}
                                    ////else
                                    ////{
                                    ////    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importepago"] = xacuenta;
                                    ////}


                                    if (DataClonadaMap030f.Rows[vmfilas]["moneda"].ToString() == "1")
                                    {
                                        xorigen = Convert.ToDecimal(DataClonadaMap030f.Rows[vmfilas]["original1"]);
                                        xsoles = Convert.ToDecimal(DataClonadaMap030f.Rows[vmfilas]["original1"]);
                                        xdolares = Convert.ToDecimal(DataClonadaMap030f.Rows[vmfilas]["original2"]);
                                    }
                                    else if (DataClonadaMap030f.Rows[vmfilas]["moneda"].ToString() == "2")
                                    {
                                        xorigen = Convert.ToDecimal(DataClonadaMap030f.Rows[vmfilas]["original1"]);
                                        xsoles = Convert.ToDecimal(DataClonadaMap030f.Rows[vmfilas]["original1"]);
                                        xdolares = Convert.ToDecimal(DataClonadaMap030f.Rows[vmfilas]["original2"]);
                                    }
                                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importeorigendolares"] = xdolares;

                                    if (DataClonadaMap030f.Rows[vmfilas]["moneda"].ToString() == "2")
                                    {
                                        DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importepagodolares1"] = Math.Round(Convert.ToDecimal(DataClonadaMap030f.Rows[vmfilas]["pagodolares"]), 2);
                                    }

                                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importeorigensoles"] = xsoles;

                                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importepagosoles"] = xacuenta;

                                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importeorigen"] = xorigen;
                                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importepago"] = xacuenta;
                                }
                            }
                        }
                        int nfila = 0;
                        DetFacturacion.AcceptChanges();
                        for (nfila = 0; nfila <= DetFacturacion.Rows.Count - 1; nfila++)
                        {
                            DetFacturacion.Rows[nfila]["asientoitems"] = VariablesPublicas.PADL(Convert.ToString(nfila + 1), 5, "0");
                        }
                        DetFacturacion.AcceptChanges();
                        Examinar.Refresh();
                        totalizar();
                        refrescacontroles();
                    }
                }
            }
        }

        private Decimal TasaRretencion()
        {
            DataTable ttributo = new DataTable();
            string xfecha = null;
            //if (dpTasa.Checked)
            //{
            //    xfecha = Convert.ToDateTime(dpTasa.Text).ToString();
            //}
            //else
            //{
                xfecha = Convert.ToDateTime(fRegistro.Text).ToString();
            //}
            tributotasaBL BL = new tributotasaBL();
            tb_tributotasa BE = new tb_tributotasa();

            BE.tributoid = "1032";
            //BE.tributofecha = Convert.ToDateTime(fRegistro.Text);
            BE.tributofecha = Convert.ToDateTime(xfecha);
            ttributo = BL.GetAll2(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            decimal xtasaigv = 0;
            if (ttributo.Rows.Count > 0)
            {
                xtasaigv += Convert.ToDecimal(ttributo.Rows[0]["tributotasa"]);
                return xtasaigv;
            }
            else
            {
                return 0;
            }
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (Examinar.Rows.Count > 0)
            //{
            //    if (u_n_opsel > 0)
            //    {
            //        cboMoneda.SelectedValue = DetFacturacion.Rows[0]["moneda"].ToString();
            //    }
            //}
        }

        private void txtCantlet_GotFocus(object sender, System.EventArgs e)
        {
            j_txttotletras = txtCantlet.Text;
        }
        private void txtCantlet_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_txttotletras == txtCantlet.Text) & !sw_load)
            {
                decimal ncuantos = VariablesPublicas.StringtoDecimal(txtCantlet.Text);
                if (ncuantos > 0)
                {
                    txtCantlet.Text = VariablesPublicas.PADL(ncuantos.ToString(), 2, "0");
                }
                else
                {
                    txtCantlet.Text = j_txttotletras;
                }
            }
        }

        private void txtNumdoc_GotFocus(object sender, System.EventArgs e)
        {
            j_txtnumpagoinicial = txtNumdoc.Text;
        }
        //private void txtNumdoc_LostFocus(object sender, System.EventArgs e)
        //{
        //    if (!(j_txtnumpagoinicial == txtNumdoc.Text) & !sw_load)
        //    {
        //        decimal ncuantos = VariablesPublicas.StringtoDecimal(txtNumdoc.Text);
        //        if (ncuantos > 0)
        //        {
        //            txtNumdoc.Text = VariablesPublicas.PADL(txtNumdoc.Text, 10, "0");
        //        }
        //    }
        //}

        private void btnGenletras_Click(object sender, EventArgs e)
        {
            int n_contador;

            if (ValidacionLetras())
            {
                for (n_contador = 0; n_contador <= DetLetras.Rows.Count - 1; n_contador++)
                {
                    DetLetras.Rows[n_contador].Delete();
                }
                decimal vmtotletras = VariablesPublicas.StringtoDecimal(txtCantlet.Text);
                string vmnroletra = "";
                decimal vmfactordolares = 0;
                decimal vmfactorsoles = 0;
                if (cboMoneda.SelectedValue.ToString() == "1")
                {
                    if (!(vmtotletras == 0))
                    {
                        vmfactorsoles = Math.Round((vmtotletras == 0 ? 0 : Convert.ToDecimal(txtImportesoles.Text) / vmtotletras), 2);
                    }

                    if (Convert.ToDecimal(txtTipocambio.Text) > 0)
                    {
                        vmfactordolares = Math.Round(vmfactorsoles / Convert.ToDecimal(txtTipocambio.Text), 2);
                    }
                }
                else
                {
                    if (!(vmtotletras == 0))
                    {
                        vmfactordolares = Math.Round((vmtotletras == 0 ? 0 : Convert.ToDecimal(txtImportedolares.Text) / vmtotletras), 2);
                    }
                    if (Convert.ToDecimal(txtTipocambio.Text) > 0)
                    {
                        vmfactorsoles = Math.Round(vmfactordolares * Convert.ToDecimal(txtTipocambio.Text), 2);
                    }
                }
                DetLetras.AcceptChanges();
                vmnroletra = txtNumdoc.Text;
                //xfechvcto = Equivalencias.Mid(dtpVctoap.Value.AddDays(Convert.ToDouble(txtDias.Text) * (n_contador - 1)).ToString(), 1, 10);
                //xbfeve=This.Parent.diasl.Value - This.Parent.periodo.Value
                decimal vmsumtotsoles = 0;
                decimal vmsumtotdolares = 0;
                for (n_contador = 1; n_contador <= vmtotletras; n_contador++)
                {
                    //xbfeve=xbfeve+This.Parent.periodo.Value

                    DetLetras.Rows.Add(VariablesPublicas.InsertIntoTable(DetLetras));
                    DetLetras.Rows[DetLetras.Rows.Count - 1]["cuentaid"] = txtCuentaid.Text.Trim();
                    DetLetras.Rows[DetLetras.Rows.Count - 1]["ctacte"] = xctacte.Trim();
                    DetLetras.Rows[DetLetras.Rows.Count - 1]["nmruc"] = txtRuc.Text.Trim();
                    DetLetras.Rows[DetLetras.Rows.Count - 1]["tipdoc"] = "62";
                    DetLetras.Rows[DetLetras.Rows.Count - 1]["serdoc"] = txtSerdoc.Text;
                    DetLetras.Rows[DetLetras.Rows.Count - 1]["numdoc"] = vmnroletra;
                    DetLetras.Rows[DetLetras.Rows.Count - 1]["fechdoc"] = fRegistro.Text.Trim();
                    DetLetras.Rows[DetLetras.Rows.Count - 1]["fechvcto"] = Equivalencias.Mid(dtpVctoap.Value.AddDays(Convert.ToDouble(txtDias.Text) * (n_contador - 1)).ToString(), 1, 10); //Equivalencias.Mid(dtpVctoap.Value.AddDays(30 * (n_contador - 1)).ToString(), 1, 10);
                    DetLetras.Rows[DetLetras.Rows.Count - 1]["fechpago"] = fRegistro.Text.Trim();
                    DetLetras.Rows[DetLetras.Rows.Count - 1]["moneda"] = cboMoneda.SelectedValue.ToString();

                    if (cboMoneda.SelectedValue.ToString() == "1")
                    {
                        DetLetras.Rows[DetLetras.Rows.Count - 1]["Importe1"] = vmfactorsoles;
                        DetLetras.Rows[DetLetras.Rows.Count - 1]["Importe2"] = vmfactordolares;
                    }
                    else
                    {
                        DetLetras.Rows[DetLetras.Rows.Count - 1]["Importe1"] = vmfactordolares;
                        DetLetras.Rows[DetLetras.Rows.Count - 1]["Importe2"] = vmfactorsoles;
                    }

                    if (vmnroletra.Trim().Length > 0)
                    {
                        vmnroletra = VariablesPublicas.PADL((VariablesPublicas.StringtoDecimal(vmnroletra) + 1).ToString(), txtNumdoc.MaxLength, "0");
                    }
                }
                DetLetras.AcceptChanges();
                for (n_contador = 0; n_contador <= DetLetras.Rows.Count - 1; n_contador++)
                {
                    if (cboMoneda.SelectedValue.ToString() == "1")
                    {
                        vmsumtotsoles = vmsumtotsoles + Convert.ToDecimal(DetLetras.Rows[n_contador]["Importe1"]);
                        vmsumtotdolares = vmsumtotdolares + Convert.ToDecimal(DetLetras.Rows[n_contador]["Importe2"]);
                    }
                    else
                    {
                        vmsumtotsoles = vmsumtotsoles + Convert.ToDecimal(DetLetras.Rows[n_contador]["Importe2"]);
                        vmsumtotdolares = vmsumtotdolares + Convert.ToDecimal(DetLetras.Rows[n_contador]["Importe1"]);
                    }
                }
                if (vmtotletras > 0)
                {
                    if (cboMoneda.SelectedValue.ToString() == "1")
                    {
                        //SE AJUSTE AL ULTIMO REGISTRO
                        if (!(vmsumtotsoles == Convert.ToDecimal(txtImportesoles.Text)))
                        {
                            DetLetras.Rows[DetLetras.Rows.Count - 1]["Importe1"] = Convert.ToDecimal(DetLetras.Rows[DetLetras.Rows.Count - 1]["Importe1"]) + (Convert.ToDecimal(txtImportesoles.Text) - vmsumtotsoles);
                        }
                        if (Convert.ToDecimal(txtTipocambio.Text) == 0)
                        {
                            DetLetras.Rows[DetLetras.Rows.Count - 1]["Importe2"] = 0;
                        }
                        else
                        {
                            DetLetras.Rows[DetLetras.Rows.Count - 1]["Importe2"] = Math.Round(Convert.ToDecimal(DetLetras.Rows[DetLetras.Rows.Count - 1]["Importe1"]) / Convert.ToDecimal(txtTipocambio.Text), 2);
                        }
                    }
                    else
                    {
                        //SE AJUSTE AL ULTIMO REGISTRO
                        if (!(vmsumtotdolares == Convert.ToDecimal(txtImportedolares.Text)))
                        {
                            DetLetras.Rows[DetLetras.Rows.Count - 1]["Importe1"] = Convert.ToDecimal(DetLetras.Rows[DetLetras.Rows.Count - 1]["Importe1"]) + (Convert.ToDecimal(txtImportedolares.Text) - vmsumtotdolares);
                        }
                        if (Convert.ToDecimal(txtTipocambio.Text) == 0)
                        {
                            DetLetras.Rows[DetLetras.Rows.Count - 1]["Importe2"] = 0;
                        }
                        else
                        {
                            DetLetras.Rows[DetLetras.Rows.Count - 1]["Importe2"] = Math.Round(Convert.ToDecimal(DetLetras.Rows[DetLetras.Rows.Count - 1]["Importe1"]) * Convert.ToDecimal(txtTipocambio.Text), 2);
                        }
                    }
                }
                DetLetras.AcceptChanges();
                gridLetras.AutoGenerateColumns = false;
                gridLetras.DataSource = DetLetras;

                for (n_contador = 0; n_contador <= gridLetras.ColumnCount - 1; n_contador++)
                {
                    if (gridLetras.Columns[n_contador].Visible)
                    {
                        gridLetras.Columns[n_contador].SortMode = DataGridViewColumnSortMode.NotSortable;
                        if (!(gridLetras.Columns[n_contador].Name.ToUpper() == "fechvcto_doc".ToUpper()) & !(gridLetras.Columns[n_contador].Name.ToUpper() == "numdoc_doc".ToUpper()) & !(gridLetras.Columns[n_contador].Name.ToUpper() == "importe1".ToUpper()))
                        {
                            if (!(gridLetras.Columns[n_contador].Name.ToUpper() == "nmruc".ToUpper()))
                            {
                                gridLetras.Columns[n_contador].ReadOnly = !_LpVariosDetalles;
                            }
                            else
                            {
                                gridLetras.Columns[n_contador].ReadOnly = true;
                            }
                            if (gridLetras.Columns[n_contador].ReadOnly)
                            {
                                gridLetras.Columns[n_contador].DefaultCellStyle.BackColor = Color.LightGray;
                                gridLetras.Columns[n_contador].DefaultCellStyle.ForeColor = Color.Black;
                            }
                        }
                        else
                        {
                            gridLetras.Columns[n_contador].ReadOnly = false;
                        }
                    }
                }
                int lc_cont = 0;
                //regenerar el nro de item
                for (lc_cont = 0; lc_cont <= DetLetras.Rows.Count - 1; lc_cont++)
                {
                    DetLetras.Rows[lc_cont]["asientoitems"] = VariablesPublicas.PADL(Convert.ToString(lc_cont + 1), 5, "0");
                }
                DetLetras.AcceptChanges();
            }
            totalizarLetras();
        }
        private void totalizarItemLetras()
        {
            decimal vmimportecambio = 0;
            decimal vmtcambio = Convert.ToDecimal(txtTipocambio.Text);
            sw_novaluechange = false;
            if (object.ReferenceEquals(gridLetras.Rows[gridLetras.CurrentRow.Index].Cells["importe1"].Value, DBNull.Value))
            {
                gridLetras.Rows[gridLetras.CurrentRow.Index].Cells["importe1"].Value = 0;
            }
            if (gridLetras.Rows[gridLetras.CurrentRow.Index].Cells["moneda_doc"].Value.ToString() == "1")
            {
                if (vmtcambio == 0)
                {
                    vmimportecambio = 0;
                }
                else
                {
                    vmimportecambio = Math.Round(Convert.ToDecimal(gridLetras.Rows[gridLetras.CurrentRow.Index].Cells["importe1"].Value) / vmtcambio, 2);
                }
            }
            if (gridLetras.Rows[gridLetras.CurrentRow.Index].Cells["moneda_doc"].Value.ToString() == "2")
            {
                vmimportecambio = Math.Round((vmtcambio == 0 ? 0 : Convert.ToDecimal(gridLetras.Rows[gridLetras.CurrentRow.Index].Cells["importe1"].Value) * vmtcambio), 2);
            }
            gridLetras.Rows[gridLetras.CurrentRow.Index].Cells["importe2"].Value = vmimportecambio;
            gridLetras.Refresh();
            totalizarLetras();
        }
        private void totalizarLetras()
        {
            decimal vmsumtotsol = 0;
            decimal vmsumtotdol = 0;
            //decimal ztotalsoles = 0;
            //decimal ztotaldolar = 0;
            for (n_contador = 0; n_contador <= DetLetras.Rows.Count - 1; n_contador++)
            {
                if (DetLetras.Rows[n_contador]["moneda"].ToString() == "1")
                {
                    vmsumtotsol = vmsumtotsol + Convert.ToDecimal(DetLetras.Rows[n_contador]["Importe1"]);
                    vmsumtotdol = vmsumtotdol + Convert.ToDecimal(DetLetras.Rows[n_contador]["Importe2"]);
                    txtLetrasoles.Text = vmsumtotsol.ToString("###,###,###.00");
                    txtLetraDolares.Text = vmsumtotdol.ToString("###,###,###.00");
                    //ztotalsoles = _TotalDeudaSoles - vmsumtotsol;
                    //txtDif.Text = ztotalsoles.ToString("###,###,###.00");
                }
                else
                {
                    vmsumtotsol = vmsumtotsol + Convert.ToDecimal(DetLetras.Rows[n_contador]["Importe2"]);
                    vmsumtotdol = vmsumtotdol + Convert.ToDecimal(DetLetras.Rows[n_contador]["Importe1"]);
                    txtLetraDolares.Text = vmsumtotdol.ToString("###,###,###.00");
                    txtLetrasoles.Text = vmsumtotsol.ToString("###,###,###.00");
                    //ztotaldolar = _TotalDeudaDolares - vmsumtotdol;
                    //txtDif.Text = ztotaldolar.ToString("###,###,###.00");
                }
            }

        }
        public bool ValidacionLetras()
        {
            string xmsg = "";
            if (Convert.ToDecimal(txtTipocambio.Text) == 0)
            {
                xmsg = "No Registra Tipo de Cambio";
            }
            if (txtNumdoc.Text.Trim().Length == 0)
            {
                xmsg = "Ingrese Número de Letra Inicial";
                txtNumdoc.Focus();
            }
            if (txtSerdoc.Text.Trim().Length == 0)
            {
                xmsg = "Ingrese la serie de la letra de cambio";
                txtSerdoc.Focus();
            }
            if (txtCantlet.Text.Trim().Length == 0)
            {
                xmsg = "Ingrese la cantidad de Letras a generar";
                txtCantlet.Focus();
            }
            if (xmsg.Length > 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(xmsg, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            return xmsg.Length == 0;
        }

        private void cboSubdiario_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubDiarioLetra();
        }
        private void SubDiarioLetra()
        {
            tb_co_tipodiarioBL BL = new tb_co_tipodiarioBL();
            tb_co_tipodiario BE = new tb_co_tipodiario();

            BE.perianio = VariablesPublicas.perianio;
            BE.diarioid = cboSubdiario.SelectedValue.ToString();

            DataTable DiarioRetencion = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            if (DiarioRetencion.Rows.Count == 0)
            {
                txtCuentaid.Text = "";
            }
            else
            {
                txtCuentaid.Text = DiarioRetencion.Rows[0]["cuentaid"].ToString().Trim();
                txtCuentaname.Text = DiarioRetencion.Rows[0]["cuentaname"].ToString().Trim();
            }
        }

        private void gridLetras_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (VariablesPublicas.PulsaAyudaArticulos)
            {
                switch (_NameCOlumna.ToUpper())
                {
                    case "nmruc":
                        AyudaProveedor();
                        break;
                }
            }
            VariablesPublicas.PulsaAyudaArticulos = false;
            if ((gridLetras.CurrentCell != null) & 1 == 0)
            {
                int nfila = gridLetras.CurrentCell.RowIndex;
                int ncolumna = gridLetras.CurrentCell.ColumnIndex;
                DetLetras.AcceptChanges();
                try
                {
                    gridLetras.CurrentCell = gridLetras.Rows[nfila].Cells[ncolumna];

                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "BapSoft");
                }
            }
        }
        private void gridLetras_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((gridLetras.CurrentRow != null) & !sw_novaluechange)
            {
                if (gridLetras.Columns[e.ColumnIndex].Name.ToUpper() == "importe1".ToUpper())
                {
                    totalizarItemLetras();
                }
                //if (gridLetras.Columns[e.ColumnIndex].Name.ToUpper() == "importecambio".ToUpper())
                //{
                //    totalizar();
                //}
                if (gridLetras.Columns[e.ColumnIndex].Name.ToUpper() == "fechvcto".ToUpper())
                {
                    validaFechaDetalle();
                    totalizarLetras();
                }
                if (gridLetras.Columns[e.ColumnIndex].Name.ToUpper() == "nmruc".ToUpper())
                {
                    ValidaProveedor();
                }
                if (gridLetras.Columns[e.ColumnIndex].Name.ToUpper() == "numdoc".ToUpper())
                {
                    ValidaNumDocumento();
                    totalizarLetras();
                }
            }
        }
        private void gridLetras_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (gridLetras.CurrentRow != null)
            {
                if (gridLetras.Columns[e.ColumnIndex].Name.ToUpper() == "fechvcto".ToUpper())
                {
                    j_dfreferencia = gridLetras.CurrentCell.Value.ToString();
                }
                if (gridLetras.Columns[e.ColumnIndex].Name.ToUpper() == "nmruc".ToUpper())
                {
                    j_detalle = gridLetras.CurrentCell.Value.ToString();
                }
            }
        }
        private void gridLetras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            }
            // Ayudas
            if (e.KeyCode == Keys.F1)
            {
                if (gridLetras.CurrentCell != null)
                {
                    if (gridLetras.CurrentCell.ReadOnly == false)
                    {
                        if (gridLetras.Columns[Examinar.CurrentCell.ColumnIndex].Name.ToUpper() == "nmruc".ToUpper())
                        {
                            AyudaProveedor();
                        }
                    }
                }
            }
        }
        private void gridLetras_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (gridLetras.Columns[gridLetras.CurrentCell.ColumnIndex].Name.ToUpper() == "nmruc".ToUpper())
            {
                txtCArti = (TextBox)e.Control;
                txtCArti.MaxLength = 11; // tmpTablaContable.Columns["nmruc"].MaxLength;
                txtCArti.CharacterCasing = CharacterCasing.Upper;
                txtCArti.Text.Trim();
                e.Control.KeyDown += VariablesPublicas.CapturarTeclaGRID;
            }
            if (gridLetras.Columns[gridLetras.CurrentCell.ColumnIndex].Name.ToUpper() == "numdoc".ToUpper())
            {
                txtCArti = (TextBox)e.Control;
                txtCArti.MaxLength = 10; //tmpTablaContable.Columns["numdoc"].MaxLength;
                txtCArti.CharacterCasing = CharacterCasing.Upper;
                txtCArti.Text.Trim();
                e.Control.KeyDown += VariablesPublicas.CapturarTeclaGRID;
            }
            _NameCOlumna = gridLetras.Columns[gridLetras.CurrentCell.ColumnIndex].Name.ToUpper();
        }

        private void validaFechaDetalle()
        {
            sw_novaluechange = true;
            bool zhallado = false;
            string VMNROITEM = gridLetras.Rows[gridLetras.CurrentRow.Index].Cells["asientoitems"].Value.ToString();
            string xcodartic = "..";
            if (!object.ReferenceEquals(gridLetras.Rows[gridLetras.CurrentRow.Index].Cells["fechvcto"].Value, DBNull.Value))
            {
                xcodartic = gridLetras.Rows[gridLetras.CurrentRow.Index].Cells["fechvcto"].Value.ToString();
            }
            if (xcodartic.Trim().Length == 0)
            {
                DetLetras.Rows[gridLetras.CurrentRow.Index]["fechvcto"] = DBNull.Value;
                zhallado = true;
            }
            else
            {
                zhallado = VariablesPublicas.ValidarFecha(xcodartic);

                if (zhallado)
                {
                    DetLetras.Rows[gridLetras.CurrentRow.Index]["fechvcto"] = Convert.ToDateTime(xcodartic);
                }
            }
            if (!zhallado & xcodartic.Length > 0)
            {
                gridLetras.Rows[gridLetras.CurrentRow.Index].Cells["fechvcto"].Value = j_dfreferencia;
            }
            gridLetras.Refresh();
            sw_novaluechange = false;
        }

        public void ValidaNumDocumento()
        {
            sw_novaluechange = true;
            if (!object.ReferenceEquals(gridLetras.Rows[Examinar.CurrentRow.Index].Cells["numdoc"].Value, DBNull.Value))
            {
                gridLetras.Rows[gridLetras.CurrentRow.Index].Cells["nmruc"].Value = gridLetras.Rows[gridLetras.CurrentRow.Index].Cells["nmruc"].Value.ToString().Trim();
            }
            sw_novaluechange = false;
        }

        private void Examinar_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            totalizarItem();
        }

        private void cboTcamuso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0)
            {
                actualizatipocambio();
                totalizarItem();
            }
        }

        
    }
}
