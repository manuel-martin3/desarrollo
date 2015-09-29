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
using BapFormulariosNet.D20Comercial.Ayudas;
using BapFormulariosNet.Ayudas;
using BapFormulariosNet.Codigo;
using DevExpress.XtraEditors;

namespace BapFormulariosNet.D20Comercial
{
    public partial class Frm_CancelacionesCobranzas : plantilla
    {
        // Variables
        private TextBox txtCArti = null;
        bool sw_novaluechange = false;
        //string j_codbanco = "";
        //string UltimoNumVoucher = "";
        //string UltimoMesVoucher = "";
        string UltimoTipoVoucher = "";
        string j_TipDocGasAdic = "";
        bool swLoad = true;
        string j_ruc = "";
        //string j_nombre = "";
        string j_Cuenta = "";
        string j_Ncambio = "";
        string j_SiglaSubDiario = "";
        string j_nvalorapagar = "";
        string j_CcostoAdic = "";
        string j_nmonedadetalle = "";
        int nContador = 0;
        decimal sumadebesoles = 0;
        decimal sumahabersoles = 0;
        decimal sumadebedolares = 0;
        decimal sumahaberdolares = 0;
        DataTable tmptabla = new DataTable();
        DataTable DocumentosPendientes = new DataTable();
        DataTable TablaDetallesaSeleccionar = new DataTable();
        //DataTable cac3p00 = new DataTable();
        DataTable cac3g00 = new DataTable();
        DataTable TabCac3p00GastosAdic = new DataTable();

        //DataTable CabFacturacion = new DataTable();
        DataTable DetFacturacion = new DataTable();
        //DataTable tmptablacab = new DataTable();
        //DataTable tmptabladet = new DataTable();
        //string j_codPago = "";
        string _NameColumna = "";
        string J_debehaber = "";
        string j_CuentaContable = "";
        string j_Detalle = "";
        private string xctacte = "";
        public string nAsiento = "";

        public Frm_CancelacionesCobranzas()
        {
            InitializeComponent();

            //Load += Frm_CancelacionesCobranzas_Load;
            //KeyDown += Frm_CancelacionesCobranzas_KeyDown;
            //Activated += Frm_CancelacionesCobranzas_Activated;

            txtCodsubdiario.LostFocus += new System.EventHandler(txtCodsubdiario_LostFocus);
            txtCodsubdiario.GotFocus += new System.EventHandler(txtCodsubdiario_GotFocus);

            txtRuc.LostFocus += new System.EventHandler(txtRuc_LostFocus);
            txtRuc.GotFocus += new System.EventHandler(txtRuc_GotFocus);

            txtCuenta.LostFocus += new System.EventHandler(txtCuenta_LostFocus);
            txtCuenta.GotFocus += new System.EventHandler(txtCuenta_GotFocus);

            txtNumpago.LostFocus += new System.EventHandler(txtNumpago_LostFocus);

            txtTipCamb.LostFocus += new System.EventHandler(txtCambio_LostFocus);
            txtTipCamb.GotFocus += new System.EventHandler(txtCambio_GotFocus);

            cboModalidad.SelectedIndex = 0;
        }

        #region "Llenado de Combobox"
        void llenar_cboMoneda()
        {
            try
            {
                cboMoneda.DataSource = NewMethodMoneda();
                cboMoneda.DisplayMember = "Value";
                cboMoneda.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethodMoneda()
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
                dic.Add(cell[0].ToString(), cell[0].ToString() + " - " + cell[2].ToString());
                cell = null;
            }
            binding.DataSource = dic;
            return binding;
        }

        void llenar_cboFlujoefectivo()
        {
            try
            {
                cboFefectivo.DataSource = NewMethodFlujoe();
                cboFefectivo.DisplayMember = "Value";
                cboFefectivo.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethodFlujoe()
        {
            tb_co_FlujoefectivoBL BL = new tb_co_FlujoefectivoBL();
            tb_co_Flujoefectivo BE = new tb_co_Flujoefectivo();

            DataTable table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            DataRowCollection rows = table.Rows;

            object[] cell;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            BindingSource binding = new BindingSource();

            foreach (DataRow item in rows)
            {
                cell = item.ItemArray;
                dic.Add(cell[0].ToString(), cell[0].ToString() + " - " + cell[2].ToString());
                cell = null;
            }
            binding.DataSource = dic;
            return binding;
        }

        void llenar_cboFormapago()
        {
            try
            {
                cboFpago.DataSource = NewMethodFpago();
                cboFpago.DisplayMember = "Value";
                cboFpago.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        void llenar_cboBanco()
        {
            try
            {
                cboBanco.DataSource = NewMethodBanco();
                cboBanco.DisplayMember = "Value";
                cboBanco.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethodBanco()
        {
            tb_co_tabla03_bancoBL BL = new tb_co_tabla03_bancoBL();
            tb_co_tabla03_banco BE = new tb_co_tabla03_banco();

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

        private void Frm_CancelacionesCobranzas_Activated(object sender, EventArgs e)
        {
            if (swLoad)
            {
                swLoad = false;
                try
                {
                    tb_co_MovimientosdetBL BL = new tb_co_MovimientosdetBL();
                    tb_co_Movimientosdet BE = new tb_co_Movimientosdet();

                    BE.perianio = VariablesPublicas.perianio;
                    BE.perimes = "xx";
                    BE.diarioid = "xx";
                    BE.asiento = "xx";

                    TabCac3p00GastosAdic = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                gridgastos.AutoGenerateColumns = false;
                gridgastos.DataSource = TabCac3p00GastosAdic;

                try
                {
                    tb_co_tipodiarioBL BL = new tb_co_tipodiarioBL();
                    tb_co_tipodiario BE = new tb_co_tipodiario();

                    BE.perianio = VariablesPublicas.perianio;
                    BE.tesoreria = true;
                    tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                    //tmptabla = ocapa.CaeSoft_GetallFormaPagoContabilidad("", 1, 0, "", "", "", GlobalVars.GetInstance.Company);
                    //if (ocapa.sql_error.Length == 0)
                    //{
                    //if (tmptabla.Rows.Count > 0)
                    //{
                    //txtcodpago.Text = tmptabla.Rows[0]["codigo"];
                    //txtdpago.Text = tmptabla.Rows[0]["descripcion"];

                    //tmptabla = ocapa.CaeSoft_GetAllDocumentosContabilidad(GlobalVars.GetInstance.Company, "", "", 2, GlobalVars.GetInstance.TipoDocumentoContableTesoreria, "", "", "");
                    //if (ocapa.sql_error.Length == 0)
                    //{
                    if (tmptabla.Rows.Count > 0)
                    {
                        txtCodsubdiario.Text = tmptabla.Rows[0]["diarioid"].ToString();
                        txtDsubdiario.Text = tmptabla.Rows[0]["diarioname"].ToString();
                        txtDsubdiario.Text = txtDsubdiario.Text.Trim();
                        txtSiglasubdiario.Text = tmptabla.Rows[0]["sigla"].ToString();
                        txtcuentaid.Text = tmptabla.Rows[0]["cuentaid"].ToString();
                    }
                    //}
                    //}
                    //}
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                actualizatipocambio();
                txtRuc.Focus();
            }
        }
        private void Frm_CancelacionesCobranzas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (!examinar.IsCurrentCellInEditMode)
                {
                    btnSalir_Click(sender, e);
                }
            }
        }
        private void Frm_CancelacionesCobranzas_Load(object sender, EventArgs e)
        {
            llenar_cboMoneda();
            llenar_cboFlujoefectivo();
            llenar_cboFormapago();
            llenar_cboBanco();

            cboBanco.SelectedIndex = -1;
            cboFefectivo.SelectedIndex = -1;
            //cboFpago.SelectedIndex = -1;

            u_RefrescaControles();
            VariablesPublicas.PintaEncabezados(examinar);
        }

        private void btnGenerarPendientes_Click(object sender, EventArgs e)
        {
            U_GeneraPendientes();
        }
        public void U_GeneraPendientes()
        {
            if (validaParametros())
            {
                btnGenerarPendientes.Enabled = false;
                GroupBox4.Enabled = false;
                GenerarInfo();
                btnGenerarPendientes.Enabled = true;
                GroupBox4.Enabled = true;
            }
        }

        private void Sumatoria()
        {
            decimal totsoles = 0;
            decimal totdolares = 0;
            decimal totsolesseleccionado = 0;
            decimal totdolaresseleccionado = 0;
            int nmarcados = 0;
            decimal totsaldosolesseleccionado = 0;
            decimal totsaldodolaresseleccionado = 0;
            int n = 0;
            for (n = 0; n <= examinar.Rows.Count - 1; n++)
            {
                totsoles = totsoles + Convert.ToDecimal(examinar.Rows[n].Cells["saldo1"].Value);
                totdolares = totdolares + Convert.ToDecimal(examinar.Rows[n].Cells["saldo2"].Value);
                if (Convert.ToBoolean(examinar.Rows[n].Cells["selecciona"].Value) == true)
                {
                    totsolesseleccionado = totsolesseleccionado + Convert.ToDecimal(examinar.Rows[n].Cells["pagosoles"].Value);
                    totdolaresseleccionado = totdolaresseleccionado + Convert.ToDecimal(examinar.Rows[n].Cells["pagodolares"].Value);
                    totsaldosolesseleccionado += Convert.ToDecimal(examinar.Rows[n].Cells["saldo1"].Value);
                    totsaldodolaresseleccionado += Convert.ToDecimal(examinar.Rows[n].Cells["saldo2"].Value);
                    nmarcados += 1;
                }
            }
            lbTotalS.Text = totsoles.ToString("###,###,###.#0");
            lbTotalD.Text = totdolares.ToString("###,###,###.#0");
            lbltotalpagosoles.Text = totsolesseleccionado.ToString("###,###,###.#0");
            lbltotalpagodolares.Text = totdolaresseleccionado.ToString("###,###,###.#0");
            lbltotregistros.Text = nmarcados.ToString("###,###,###");
            lblsolesseleccionado.Text = totsaldosolesseleccionado.ToString("###,###,###.#0");
            lbldolaresseleccionado.Text = totsaldodolaresseleccionado.ToString("###,###,###.#0");
        }
        private void GenerarInfo()
        {
            string xcoddetalle = "";
            string xcuenta = "";
            if (txtCuenta.Enabled)
            {
                xcuenta = txtCuenta.Text;
            }
            if (txtRuc.Enabled)
            {
                xcoddetalle = txtRuc.Text;
            }
            examinar.DataSource = null;
            dynamic nmodalidadanalisis = VariablesPublicas.CtaCteCUEDETTIPNUMPEDOPCCOSTo;
            if (rbAnalisis1.Checked)
            {
                nmodalidadanalisis = VariablesPublicas.CtaCteCUEDETTIPNUM;
            }
            if (rbMultiplesdetalles.Checked)
            {
                xcoddetalle = "";
                tb_co_MovimientosBL BL = new tb_co_MovimientosBL();
                tb_co_Movimientos BE = new tb_co_Movimientos();

                BE.perianio = VariablesPublicas.perianio;
                //BE.perimes = xmescontable;
                //BE.tiprepo = xtiprepo;
                //BE.fechaini = xfechaini;
                //BE.fechafin = xfechafin;
                BE.nmruc = xcoddetalle;
                BE.cuentaini = xcuenta;
                BE.cuentafin = xcuenta;
                //BE.cuentaid = xcuenta;
                //BE.tipdoc = xtipdoc;
                //BE.serdoc = xserdoc;
                //BE.numdoc = xnumdoc;
                BE.saldos = 3;
                BE.tipmodal = 2;
                //BE.tanalisis = xtanalisis;
                BE.relctas = VariablesPublicas.relctas;

                DocumentosPendientes = BL.GetGeneraCuentaCorriente(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                //DocumentosPendientes = ocapa.spu_cuentacorriente(GlobalVars.GetInstance.Company, GlobalVars.GetInstance.Periodo,"",xcuenta,xcuenta,xcoddetalle,"","",3,0,
                //GlobalVars.GetInstance.CuentaCorrientecac3p00,"","",TablaDetallesaSeleccionar,GlobalVars.GetInstance.RelCuentasCancelacionesCobranzas,"",0, nmodalidadanalisis,"");
            }
            else
            {
                tb_co_MovimientosBL BL = new tb_co_MovimientosBL();
                tb_co_Movimientos BE = new tb_co_Movimientos();

                BE.perianio = VariablesPublicas.perianio;
                //BE.perimes = xmescontable;
                //BE.tiprepo = xtiprepo;
                //BE.fechaini = xfechaini;
                //BE.fechafin = xfechafin;
                BE.nmruc = xcoddetalle;
                BE.cuentaini = xcuenta;
                BE.cuentafin = xcuenta;
                //BE.cuentaid = xcuenta;
                //BE.tipdoc = xtipdoc;
                //BE.serdoc = xserdoc;
                //BE.numdoc = xnumdoc;
                BE.saldos = 3;
                BE.tipmodal = 2;
                //BE.tanalisis = xtanalisis;
                BE.relctas = VariablesPublicas.relctas;

                DocumentosPendientes = BL.GetGeneraCuentaCorriente(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                //DocumentosPendientes = ocapa.spu_cuentacorriente(GlobalVars.GetInstance.Company, GlobalVars.GetInstance.Periodo, "", xcuenta, xcuenta, xcoddetalle, "", "", 3, 0,
                //GlobalVars.GetInstance.CuentaCorrientecac3p00, "", "", null, GlobalVars.GetInstance.RelCuentasCancelacionesCobranzas, "", 0, nmodalidadanalisis, "");

            }

            //if (ocapa.sql_error.Length > 0)
            //{
            //    ERP_CAESOFT_FORMS.frmclass.ShowError(ocapa.sql_error, this);
            //    return;
            //}
            examinar.AutoGenerateColumns = false;
            examinar.DataSource = DocumentosPendientes;
            txtGlosa.Text = (txtGlosa.Text.Trim().Length > 0 ? txtGlosa.Text.Trim() : "PAGOS VARIOS");
            u_RefrescaControles();
            Sumatoria();
        }
        public void u_RefrescaControles()
        {
            cboBanco.Enabled = true;
            if ((gridgastos.DataSource != null))
            {
                gridgastos.ReadOnly = false;
                gridgastos.Columns["gasto_cuentaname"].ReadOnly = true;
                gridgastos.Columns["ImporteCambio"].ReadOnly = true;
            }

            rbDolares.Enabled = true;
            rbSoles.Enabled = true;
            txtRuc.Enabled = true;
            examinar.ReadOnly = false;
            txtCtactename.Enabled = false;
            txtCuenta.Enabled = chkCuenta.Checked;
            txtRuc.Enabled = rbDetalle.Checked;
            txtCuentaname.Enabled = false;
            btnSeleccionarproveedores.Enabled = rbMultiplesdetalles.Checked;
            txtTipCamb.Enabled = false;
            txtCodsubdiario.Enabled = true;
            txtDsubdiario.Enabled = false;
            txtSiglasubdiario.Enabled = false;
            txtcuentaid.Enabled = false;
            txtTipCamb.Enabled = true;
            txtmontoapagar.Enabled = false;
            cboMoneda.Enabled = false;
            btnPagoauto.Enabled = false;
            for (nContador = 0; nContador <= examinar.ColumnCount - 1; nContador++)
            {
                if (examinar.Columns[nContador].Name.ToUpper() == "selecciona".ToUpper() | examinar.Columns[nContador].Name.ToUpper() == "pagosoles".ToUpper() | examinar.Columns[nContador].Name.ToUpper() == "pagodolares".ToUpper() | examinar.Columns[nContador].Name.ToUpper() == "monedap".ToUpper())
                {
                    examinar.Columns[nContador].ReadOnly = false;
                    if ((examinar.CurrentRow != null))
                    {
                        examinar.Columns["pagodolares"].ReadOnly = !(examinar.Rows[examinar.CurrentRow.Index].Cells["monedap"].Value.ToString() == "2" & Convert.ToBoolean(examinar.Rows[examinar.CurrentRow.Index].Cells["selecciona"].Value) == true);
                        examinar.Columns["pagosoles"].ReadOnly = !(examinar.Rows[examinar.CurrentRow.Index].Cells["monedap"].Value.ToString() == "1" & Convert.ToBoolean(examinar.Rows[examinar.CurrentRow.Index].Cells["selecciona"].Value) == true);
                    }
                    else
                    {
                        examinar.Columns["pagodolares"].ReadOnly = true;
                        examinar.Columns["pagosoles"].ReadOnly = true;
                    }
                }
                else
                {
                    examinar.Columns[nContador].ReadOnly = true;
                }
            }
            if ((examinar.DataSource != null))
            {
                for (nContador = 0; nContador <= examinar.Rows.Count - 1; nContador++)
                {
                    if (Convert.ToBoolean(examinar.Rows[nContador].Cells["selecciona"].Value))
                    {
                        txtmontoapagar.Enabled = true;
                        cboMoneda.Enabled = true;
                        btnPagoauto.Enabled = true;
                        break;
                    }
                }
            }
        }

        public void U_pINTAR()
        {
            if (1 == 1)
            {
                int LC_CONT = 0;
                dynamic LC_NCOLUMNA = null;
                for (LC_CONT = 0; LC_CONT <= examinar.RowCount - 1; LC_CONT++)
                {
                    if (Convert.ToBoolean(examinar.Rows[LC_CONT].Cells["selecciona"].Value) == true)
                    {
                        for (LC_NCOLUMNA = 0; LC_NCOLUMNA <= examinar.ColumnCount - 1; LC_NCOLUMNA++)
                        {
                            if (examinar.Columns[LC_NCOLUMNA].Name.ToUpper() == "numdoc".ToUpper())
                            {
                                examinar.Rows[LC_CONT].DefaultCellStyle.BackColor = lblregseleccionado.BackColor;
                                examinar.Rows[LC_CONT].DefaultCellStyle.ForeColor = lblregseleccionado.ForeColor;
                            }
                        }
                    }
                    else
                    {
                        for (LC_NCOLUMNA = 0; LC_NCOLUMNA <= examinar.ColumnCount - 1; LC_NCOLUMNA++)
                        {
                            examinar.Rows[LC_CONT].DefaultCellStyle.BackColor = Color.White;
                            examinar.Rows[LC_CONT].DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                }
            }
        }

        private Decimal TasaRretencion(DateTime xfecha)
        {
            DataTable ttributo = new DataTable();
            tributotasaBL BL = new tributotasaBL();
            tb_tributotasa BE = new tb_tributotasa();

            BE.tributoid = "1032";
            BE.tributofecha = Convert.ToDateTime(xfecha);
            //BE.tributofecha = Convert.ToDateTime(fEmision.Text);

            ttributo = BL.GetAll2(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            decimal xtasaigv = 0;
            if ((ttributo.Rows.Count > 0))
            {
                xtasaigv += Convert.ToDecimal(ttributo.Rows[0]["tributotasa"]);
                return xtasaigv;
            }
            else
            {
                return 0;
            }
        }

        private void examinar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((examinar.CurrentRow != null))
            {
                if (examinar.Columns[e.ColumnIndex].Name.ToUpper() == "selecciona".ToUpper())
                {
                    examinar.Rows[examinar.CurrentRow.Index].Cells["selecciona"].Value = !Convert.ToBoolean(examinar.Rows[examinar.CurrentRow.Index].Cells["selecciona"].Value);
                    U_pINTAR();

                    #region
                    bool lselecciona;
                    decimal _porcdetraccion;
                    decimal _porcretencion;

                    int LC_CONT = e.RowIndex;
                    int nmodalidad = cboModalidad.SelectedIndex;

                    if (Convert.ToBoolean(examinar.Rows[e.RowIndex].Cells["selecciona"].Value) == true)
                    {
                        lselecciona = true;
                        if ((Convert.ToDecimal(examinar.Rows[LC_CONT].Cells["pagosoles"].Value) == 0) && (Convert.ToDecimal(examinar.Rows[LC_CONT].Cells["pagodolares"].Value) == 0))
                        {
                            switch (nmodalidad)
                            {
                                case 0:
                                    examinar.Rows[LC_CONT].Cells["pagosoles"].Value = Math.Round((lselecciona ? Math.Round(Convert.ToDecimal(examinar.Rows[LC_CONT].Cells["saldo1"].Value), 2) : 0), 2);
                                    examinar.Rows[LC_CONT].Cells["pagodolares"].Value = Math.Round((lselecciona ? Math.Round(Convert.ToDecimal(examinar.Rows[LC_CONT].Cells["saldo2"].Value), 2) : 0), 2);
                                    DocumentosPendientes.Rows[LC_CONT]["pagosoles"] = Math.Round(Convert.ToDecimal(DocumentosPendientes.Rows[LC_CONT]["pagosoles"]), 2);
                                    DocumentosPendientes.Rows[LC_CONT]["pagodolares"] = Math.Round(Convert.ToDecimal(DocumentosPendientes.Rows[LC_CONT]["pagodolares"]), 2);
                                    break;
                                case 1:
                                    if ((!object.ReferenceEquals(examinar.Rows[LC_CONT].Cells["porcdetraccion"].Value, DBNull.Value)))
                                    {
                                        _porcdetraccion = Convert.ToDecimal(examinar.Rows[LC_CONT].Cells["porcdetraccion"].Value);
                                    }
                                    else
                                    {
                                        _porcdetraccion = 0;
                                    }
                                    examinar.Rows[LC_CONT].Cells["pagosoles"].Value = (_porcdetraccion > 0 ? Math.Round(Convert.ToDecimal(examinar.Rows[LC_CONT].Cells["original1"].Value) * _porcdetraccion / 100, 2) : examinar.Rows[LC_CONT].Cells["saldo1"].Value);
                                    examinar.Rows[LC_CONT].Cells["pagodolares"].Value = (_porcdetraccion > 0 ? Math.Round(Convert.ToDecimal(examinar.Rows[LC_CONT].Cells["original2"].Value) * _porcdetraccion / 100, 2) : examinar.Rows[LC_CONT].Cells["saldo2"].Value);
                                    DocumentosPendientes.Rows[LC_CONT]["pagosoles"] = Math.Round(Convert.ToDecimal(DocumentosPendientes.Rows[LC_CONT]["pagosoles"]), 2);
                                    DocumentosPendientes.Rows[LC_CONT]["pagodolares"] = Math.Round(Convert.ToDecimal(DocumentosPendientes.Rows[LC_CONT]["pagodolares"]), 2);
                                    break;
                                case 2:
                                    if ((!object.ReferenceEquals(examinar.Rows[LC_CONT].Cells["porcdetraccion"].Value, DBNull.Value)))
                                    {
                                        _porcdetraccion = Convert.ToDecimal(examinar.Rows[LC_CONT].Cells["porcdetraccion"].Value);
                                    }
                                    else
                                    {
                                        _porcdetraccion = 0;
                                    }
                                    examinar.Rows[LC_CONT].Cells["pagosoles"].Value = (_porcdetraccion > 0 ? Convert.ToDecimal(examinar.Rows[LC_CONT].Cells["original1"].Value) - Math.Round(Convert.ToDecimal(examinar.Rows[LC_CONT].Cells["original1"].Value) * _porcdetraccion / 100, 2) : examinar.Rows[LC_CONT].Cells["saldo1"].Value);
                                    examinar.Rows[LC_CONT].Cells["pagodolares"].Value = (_porcdetraccion > 0 ? Convert.ToDecimal(examinar.Rows[LC_CONT].Cells["original2"].Value) - Math.Round(Convert.ToDecimal(examinar.Rows[LC_CONT].Cells["original2"].Value) * _porcdetraccion / 100, 2) : examinar.Rows[LC_CONT].Cells["saldo2"].Value);
                                    DocumentosPendientes.Rows[LC_CONT]["pagosoles"] = Math.Round(Convert.ToDecimal(DocumentosPendientes.Rows[LC_CONT]["pagosoles"]), 2);
                                    DocumentosPendientes.Rows[LC_CONT]["pagodolares"] = Math.Round(Convert.ToDecimal(DocumentosPendientes.Rows[LC_CONT]["pagodolares"]), 2);
                                    break;
                                case 3:
                                    _porcretencion = TasaRretencion(Convert.ToDateTime(examinar.Rows[LC_CONT].Cells["fechdoc"].Value));
                                    examinar.Rows[LC_CONT].Cells["pagosoles"].Value = Math.Round(Convert.ToDecimal(examinar.Rows[LC_CONT].Cells["original1"].Value) * _porcretencion / 100, 2);
                                    examinar.Rows[LC_CONT].Cells["pagodolares"].Value = Math.Round(Convert.ToDecimal(examinar.Rows[LC_CONT].Cells["original2"].Value) * _porcretencion / 100, 2);
                                    DocumentosPendientes.Rows[LC_CONT]["pagosoles"] = Math.Round(Convert.ToDecimal(DocumentosPendientes.Rows[LC_CONT]["pagosoles"]), 2);
                                    DocumentosPendientes.Rows[LC_CONT]["pagodolares"] = Math.Round(Convert.ToDecimal(DocumentosPendientes.Rows[LC_CONT]["pagodolares"]), 2);
                                    break;
                                case 4:
                                    _porcretencion = TasaRretencion(Convert.ToDateTime(examinar.Rows[LC_CONT].Cells["fechdoc"].Value));
                                    examinar.Rows[LC_CONT].Cells["pagosoles"].Value = Math.Round(Convert.ToDecimal(examinar.Rows[LC_CONT].Cells["original1"].Value) - Math.Round(Convert.ToDecimal(examinar.Rows[LC_CONT].Cells["original1"].Value) * _porcretencion / 100, 2), 2);
                                    examinar.Rows[LC_CONT].Cells["pagodolares"].Value = Math.Round(Convert.ToDecimal(examinar.Rows[LC_CONT].Cells["original2"].Value) - Math.Round(Convert.ToDecimal(examinar.Rows[LC_CONT].Cells["original2"].Value) * _porcretencion / 100, 2), 2);
                                    DocumentosPendientes.Rows[LC_CONT]["pagosoles"] = Math.Round(Convert.ToDecimal(DocumentosPendientes.Rows[LC_CONT]["pagosoles"]), 2);
                                    DocumentosPendientes.Rows[LC_CONT]["pagodolares"] = Math.Round(Convert.ToDecimal(DocumentosPendientes.Rows[LC_CONT]["pagodolares"]), 2);
                                    break;
                            }
                        }
                        //examinar.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Beige;
                    }
                    else
                    {
                        switch (nmodalidad)
                        {
                            case 0:
                                examinar.Rows[LC_CONT].Cells["pagosoles"].Value = 0;
                                examinar.Rows[LC_CONT].Cells["pagodolares"].Value = 0;
                                break;
                            case 1:
                                examinar.Rows[LC_CONT].Cells["pagosoles"].Value = 0;
                                examinar.Rows[LC_CONT].Cells["pagodolares"].Value = 0;
                                break;
                            case 2:
                                examinar.Rows[LC_CONT].Cells["pagosoles"].Value = 0;
                                examinar.Rows[LC_CONT].Cells["pagodolares"].Value = 0;
                                break;
                            case 3:
                                examinar.Rows[LC_CONT].Cells["pagosoles"].Value = 0;
                                examinar.Rows[LC_CONT].Cells["pagodolares"].Value = 0;
                                break;
                            case 4:
                                examinar.Rows[LC_CONT].Cells["pagosoles"].Value = 0;
                                examinar.Rows[LC_CONT].Cells["pagodolares"].Value = 0;
                                break;
                        }
                    }
                    #endregion
                    Sumatoria();
                    u_RefrescaControles();
                }
            }
        }
        private void examinar_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if ((examinar.CurrentRow != null))
            {
                if (examinar.Columns[e.ColumnIndex].Name.ToUpper() == "monedap".ToUpper())
                {
                    j_nmonedadetalle = examinar.CurrentCell.Value.ToString();
                }
            }
        }
        private void examinar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (examinar.Columns[examinar.CurrentCell.ColumnIndex].Name.ToUpper() == "selecciona".ToUpper())
                {
                    examinar.Rows[examinar.CurrentRow.Index].Cells["selecciona"].Value = !Convert.ToBoolean(examinar.Rows[examinar.CurrentRow.Index].Cells["selecciona"].Value);
                    U_pINTAR();
                    Sumatoria();
                    u_RefrescaControles();
                }
            }
        }
        private void examinar_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((examinar.CurrentRow != null) & !sw_novaluechange)
            {
                if (examinar.Columns[e.ColumnIndex].Name.ToUpper() == "pagosoles".ToUpper() | examinar.Columns[e.ColumnIndex].Name.ToUpper() == "pagodolares".ToUpper())
                {
                    validaImportespagos();
                }
                if (examinar.Columns[e.ColumnIndex].Name.ToUpper() == "monedap".ToUpper())
                {
                    validaMonedaDetalle();
                }
                if (examinar.Columns[e.ColumnIndex].Name.ToUpper() == "tipdoc".ToUpper())
                {
                    validaTipoDocumento();
                }
            }
        }
        private void examinar_SelectionChanged(object sender, EventArgs e)
        {
            txtconcepto.Text = "";
            txtnomdetalle.Text = "";
            if ((examinar.CurrentCell != null))
            {
                txtglosacampo.Text = "";
                if (examinar.Columns[examinar.CurrentCell.ColumnIndex].Name.ToUpper() == "cuentaid".ToUpper())
                {
                    txtglosacampo.Text = examinar.Rows[examinar.CurrentRow.Index].Cells["cuentaname"].Value.ToString();
                }
                if (examinar.Columns[examinar.CurrentCell.ColumnIndex].Name.ToUpper() == "monedap".ToUpper())
                {
                    txtglosacampo.Text = "[1] Soles [2] Dólares";
                }
                txtnomdetalle.Text = examinar.Rows[examinar.CurrentRow.Index].Cells["ctactename"].Value.ToString();
                txtconcepto.Text = examinar.Rows[examinar.CurrentRow.Index].Cells["glosa"].Value.ToString();
                u_RefrescaControles();
            }
        }
        private void examinar_Paint(object sender, PaintEventArgs e)
        {
            //U_pINTAR();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //private void txtCtactename_GotFocus(object sender, System.EventArgs e)
        //{
        //    j_nombre = txtCtactename.Text;
        //}
        //private void txtCtactename_LostFocus(object sender, System.EventArgs e)
        //{
        //    if (!(j_nombre == txtCtactename.Text) & !swLoad)
        //    {
        //        if (txtCtactename.Text.Trim().Length > 0)
        //        {
        //            string xpalabra1 = "";
        //            string xpalabra2 = "";
        //            string xpalabra3 = "";
        //            xpalabra1 = UtilitariosInterface.Palabras(txtCtactename.Text, 1);
        //            xpalabra2 = UtilitariosInterface.Palabras(txtCtactename.Text, 2);
        //            xpalabra3 = UtilitariosInterface.Palabras(txtCtactename.Text, 3);
        //            //tmptabla = ocapa.cag1000_CONSULTA(GlobalVars.GetInstance.CompanyGeneral, "", "", xpalabra1, "", "", "", "", 1, "", 0, xpalabra2, xpalabra3);
        //            //if (ocapa.sql_error.Length == 0)
        //            //{
        //                if (tmptabla.Rows.Count == 1)
        //                {
        //                    txtCtactename.Text = tmptabla.Rows[0]["nomb_10"].ToString();
        //                    txtRuc.Text = tmptabla.Rows[0]["fich_10"].ToString();
        //                    //txtgirado.Text = tmptabla.Rows[0]["nomb_10"];
        //                }
        //                else
        //                {
        //                    if (tmptabla.Rows.Count > 1)
        //                    {
        //                        AyudaProveedores(txtCtactename.Text);
        //                    }
        //                    else
        //                    {
        //                        txtCtactename.Text = j_nombre;
        //                    }
        //                }
        //            }
        //        //}
        //    }
        //}

        private void txtRuc_GotFocus(object sender, System.EventArgs e)
        {
            j_ruc = txtRuc.Text;
        }
        private void txtRuc_LostFocus(object sender, System.EventArgs e)
        {
            //if (!(j_ruc == txtRuc.Text) & !swLoad)
            //{
                ValidaDetalle();
            //}
        }
        private void txtRuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaProveedores("");
            }
        }
        private void proveedor(string codigo, string nombre, string Direccion)
        {
            txtRuc.Text = codigo;
            txtCtactename.Text = nombre;
        }
        public void AyudaProveedores(string lpnomlike)
        {
            //Frm_AyudaProveedor Form = new Frm_AyudaProveedor();
            //Form.Owner = this;
            //Form.PasaProveedor = proveedor;
            //Form._NombreDetalle = lpnomlike;
            //Form.ShowDialog();
        }
        public void ValidaDetalle()
        {
            sw_novaluechange = true;
            Int16 lc_cont = default(Int16);
            bool zhallado = false;
            string xcodartic = "..";
            if (txtRuc.Text.Trim().Length > 0)
            {
                xcodartic = txtRuc.Text;
            }
            if (xcodartic.Trim().Length == 0)
            {
                txtCtactename.Text = "";
                zhallado = true;
            }
            else
            {
                clienteBL BL = new clienteBL();
                tb_cliente BE = new tb_cliente();

                BE.nmruc = xcodartic;
                tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                if (tmptabla.Rows.Count > 0)
                {
                    txtRuc.Text = tmptabla.Rows[lc_cont]["nmruc"].ToString();
                    txtCtactename.Text = tmptabla.Rows[lc_cont]["ctactename"].ToString();
                    xctacte = tmptabla.Rows[0]["ctacte"].ToString();
                    zhallado = true;
                }
            }
            if (!zhallado)
            {
                txtRuc.Text = j_ruc;
            }
            sw_novaluechange = false;
        }

        private void chkCuenta_CheckedChanged(object sender, EventArgs e)
        {
            if (!swLoad)
            {
                u_RefrescaControles();
            }
        }
        private void txtCuenta_GotFocus(object sender, System.EventArgs e)
        {
            j_Cuenta = txtCuenta.Text;
        }
        private void txtCuenta_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_Cuenta == txtCuenta.Text) & !swLoad)
            {
                validacuenta(txtCuenta.Text.Trim());
            }
        }
        private void txtCuenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaCuenta();
            }
        }
        private void validacuenta(string xcuenta)
        {
            sw_novaluechange = true;
            bool zhallado = false;
            string xcodartic = txtCuenta.Text.Trim();
            if (xcuenta.Trim().Length == 0)
            {
                txtCuenta.Text = "";
                txtCuentaname.Text = "";
                zhallado = true;
            }
            else
            {
                tb_co_plancontableBL BL = new tb_co_plancontableBL();
                tb_co_plancontable BE = new tb_co_plancontable();

                BE.perianio = VariablesPublicas.perianio;
                BE.cuentaid = xcuenta; //xcodartic;
                tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                //tmptabla = ocapa.cag0200_consulta(GlobalVars.GetInstance.Company, xcodartic, "", "", "", "", "", 1, GlobalVars.GetInstance.CuentasContablesTodas, "");
                if (tmptabla.Rows.Count > 0)
                {
                    txtCuenta.Text = tmptabla.Rows[0]["cuentaid"].ToString().Trim();
                    txtCuentaname.Text = tmptabla.Rows[0]["cuentaname"].ToString().Trim();
                    cboBanco.SelectedValue = tmptabla.Rows[0]["bancoid"].ToString().Trim();
                    zhallado = true;
                }
                if (!zhallado & xcodartic.Length > 0)
                {
                    txtCuenta.Text = j_Cuenta.Trim();
                }
            }
            sw_novaluechange = false;
        }
        private void AyudaCuenta()
        {
            Frm_AyudaCuentas frmayuda = new Frm_AyudaCuentas();
            frmayuda.Owner = this;
            frmayuda._CUENTA_MAYOR = "";
            frmayuda._activaCta = true;
            frmayuda.Owner = this;

            frmayuda.PasaCuenta = RecibeCuenta;
            frmayuda.ShowDialog();
        }
        private void RecibeCuenta(string codigo, string descripcion)
        {
            if (codigo.Trim().Length > 0)
            {
                txtCuenta.Text = codigo;
                txtCuentaname.Text = descripcion;
            }
        }

        private void btnSeleccionarproveedores_Click(object sender, EventArgs e)
        {
            Frm_SeleccionVariosClientes oform = new Frm_SeleccionVariosClientes();
            oform._Cuenta = txtCuenta.Text;
            oform._TablaProveedores = TablaDetallesaSeleccionar;
            oform.Owner = this;
            oform.ShowInTaskbar = false;
            oform._Delegado = PasaTabla;
            oform.ShowDialog();
        }
        public void PasaTabla(DataTable tablaDetalles)
        {
            if ((tablaDetalles != null))
            {
                TablaDetallesaSeleccionar = tablaDetalles;
            }
        }

        private void rbDetalle_CheckedChanged(object sender, EventArgs e)
        {
            if (!swLoad)
            {
                u_RefrescaControles();
            }
        }

        private void rbMultiplesdetalles_CheckedChanged(object sender, EventArgs e)
        {
            if (!swLoad)
            {
                u_RefrescaControles();
            }
        }

        private void txtCodsubdiario_GotFocus(object sender, System.EventArgs e)
        {
            j_SiglaSubDiario = txtCodsubdiario.Text;
        }
        private void txtCodsubdiario_LostFocus(object sender, System.EventArgs e)
        {
            if (!swLoad)
            {
                if (!(j_SiglaSubDiario == txtCodsubdiario.Text))
                {
                    validaTipoDiario();
                }
            }
        }
        private void txtCodsubdiario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaSiglaSubDiario();
            }
        }
        public void AyudaSiglaSubDiario()
        {
            Frm_AyudaTipoSubdiario frmAyuda = new Frm_AyudaTipoSubdiario();
            //frmAyuda._nFiltroDocumento = VariablesPublicas.TipoDocumentoContableTesoreria;
            frmAyuda._VerTipoVoucher = false;
            frmAyuda._conta = false;
            frmAyuda._tesor = true;
            frmAyuda._PasaDelegado = RecibeTipoSubDiario;
            frmAyuda.ShowDialog();
        }
        public void RecibeTipoSubDiario(string codigo, string nombre, string Sigla)
        {
            if (codigo.Trim().Length > 0)
            {
                txtCodsubdiario.Text = codigo;
                validaTipoDiario();
            }
        }
        public void validaTipoDiario()
        {
            string xcodigo = "";
            int ncont = 0;
            sw_novaluechange = true;
            xcodigo = txtCodsubdiario.Text;
            if (xcodigo.Trim().Length > 0)
            {
                try
                {
                    tb_co_tipodiarioBL BL = new tb_co_tipodiarioBL();
                    tb_co_tipodiario BE = new tb_co_tipodiario();

                    BE.perianio = VariablesPublicas.perianio;
                    BE.diarioid = xcodigo;

                    tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //if (ocapa.sql_error.Length == 0)
                //{
                if (tmptabla.Rows.Count > 0)
                {
                    txtCodsubdiario.Text = tmptabla.Rows[0]["diarioid"].ToString();
                    txtDsubdiario.Text = tmptabla.Rows[0]["diarioname"].ToString();
                    txtDsubdiario.Text = txtDsubdiario.Text.Trim();
                    txtSiglasubdiario.Text = tmptabla.Rows[0]["sigla"].ToString();
                    txtcuentaid.Text = tmptabla.Rows[0]["cuentaid"].ToString();
                    validacuenta(txtcuentaid.Text.Trim());
                    if (txtDsubdiario.Text.IndexOf(" MN") > 0)
                    {
                        rbSoles.Checked = true;
                        rbDolares.Checked = false;
                        for (ncont = 0; ncont <= examinar.Rows.Count - 1; ncont++)
                        {
                            examinar.Rows[ncont].Cells["monedap"].Value = "1";
                        }
                    }
                    else
                    {
                        rbSoles.Checked = false;
                        rbDolares.Checked = true;
                        for (ncont = 0; ncont <= examinar.Rows.Count - 1; ncont++)
                        {
                            examinar.Rows[ncont].Cells["monedap"].Value = "2";
                        }
                    }
                }
                else
                {
                    txtCodsubdiario.Text = j_SiglaSubDiario;
                }
                //}
            }
            else
            {
                txtCodsubdiario.Text = j_SiglaSubDiario;
            }
            sw_novaluechange = false;
        }

        private void txtNumpago_LostFocus(object sender, System.EventArgs e)
        {
            if (!swLoad)
            {
                if (txtNumpago.Text.Trim().Length > 0)
                {
                    txtNumpago.Text = VariablesPublicas.PADL(txtNumpago.Text.Trim(), txtNumpago.MaxLength, "0");
                }
            }
        }

        private void actualizatipocambio()
        {
            tipocambioBL BL = new tipocambioBL();
            tb_tipocambio BE = new tb_tipocambio();

            //BE.anio = Convert.ToInt16(VariablesPublicas.perianio.ToString());
            BE.fecha = Convert.ToDateTime(fEmision.Text);

            DataTable tcambio = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

            if (tcambio.Rows.Count > 0)
            {
                if (Convert.ToDecimal(tcambio.Rows[0]["compra"]) > Convert.ToDecimal(tcambio.Rows[0]["venta"]))
                {
                    txtTipCamb.Text = tcambio.Rows[0]["compra"].ToString();
                }
                else
                {
                    txtTipCamb.Text = tcambio.Rows[0]["venta"].ToString();
                }

                //if (cboTcamuso.Text.Substring(0, 1) == "V")
                //{ txtCambio.Text = tcambio.Rows[0]["venta"].ToString(); }
                //if (cboTcamuso.Text.Substring(0, 1) == "C")
                //{ txtCambio.Text = tcambio.Rows[0]["compra"].ToString(); }
                //if (cboTcamuso.Text.Substring(0, 1) == "P")
                //{ txtCambio.Text = tcambio.Rows[0]["promedio"].ToString(); }
                //if (cboTcamuso.Text.Substring(0, 1) == "E")
                //{ txtCambio.Enabled = true; }
                //else
                //{ txtCambio.Enabled = false; }
            }
            else
            {
                txtTipCamb.Text = "0.00";
                //XtraMessageBox.Show("Actualice el Tipo de Cambio?", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void fEmision_ValueChanged(object sender, EventArgs e)
        {
            if (!swLoad)
            {
                actualizatipocambio();
            }
        }

        private void txtCambio_GotFocus(System.Object sender, System.EventArgs e)
        {
            j_Ncambio = txtTipCamb.Text;
        }
        private void txtCambio_LostFocus(System.Object sender, System.EventArgs e)
        {
            if (!(j_Ncambio == txtTipCamb.Text) & !swLoad)
            {
                decimal ncambio = VariablesPublicas.StringtoDecimal(txtTipCamb.Text);
                txtTipCamb.Text = ncambio.ToString("##.00000");
            }
        }

        public void validaImportespagos()
        {
            //int ncampomoneda = 0;
            decimal vmtcambio = 0;
            //decimal vmnvalor = 0;
            sw_novaluechange = true;
            if ((!object.ReferenceEquals(examinar.Rows[examinar.CurrentRow.Index].Cells["tipcamb"].Value, DBNull.Value)))
            {
                vmtcambio = Convert.ToDecimal(examinar.Rows[examinar.CurrentRow.Index].Cells["tipcamb"].Value);
            }

            if (object.ReferenceEquals(examinar.Rows[examinar.CurrentRow.Index].Cells["pagosoles"].Value, DBNull.Value))
            {
                examinar.Rows[examinar.CurrentRow.Index].Cells["pagosoles"].Value = 0;
            }
            if (object.ReferenceEquals(examinar.Rows[examinar.CurrentRow.Index].Cells["pagodolares"].Value, DBNull.Value))
            {
                examinar.Rows[examinar.CurrentRow.Index].Cells["pagodolares"].Value = 0;
            }

            if (examinar.Rows[examinar.CurrentRow.Index].Cells["monedap"].Value.ToString() == "2")
            {
                if (vmtcambio > 0)
                {
                    examinar.Rows[examinar.CurrentRow.Index].Cells["pagosoles"].Value = Math.Round(Convert.ToDecimal(examinar.Rows[examinar.CurrentRow.Index].Cells["pagodolares"].Value) * vmtcambio,2);
                }
                else
                {
                    examinar.Rows[examinar.CurrentRow.Index].Cells["pagosoles"].Value = 0;
                }
            }
            else
            {
                if (vmtcambio > 0)
                {
                    examinar.Rows[examinar.CurrentRow.Index].Cells["pagodolares"].Value = Math.Round(Convert.ToDecimal(examinar.Rows[examinar.CurrentRow.Index].Cells["pagosoles"].Value) / vmtcambio,2);
                }
                else
                {
                    examinar.Rows[examinar.CurrentRow.Index].Cells["pagodolares"].Value = 0;
                }
            }

            Sumatoria();
            sw_novaluechange = false;
        }

        public void validaMonedaDetalle()
        {
            //int ncampomoneda = 0;
            sw_novaluechange = true;
            //decimal vmnvalor = 0;
            if (object.ReferenceEquals(examinar.Rows[examinar.CurrentRow.Index].Cells["pagosoles"].Value, DBNull.Value))
            {
                examinar.Rows[examinar.CurrentRow.Index].Cells["pagosoles"].Value = 0;
            }
            if (object.ReferenceEquals(examinar.Rows[examinar.CurrentRow.Index].Cells["pagodolares"].Value, DBNull.Value))
            {
                examinar.Rows[examinar.CurrentRow.Index].Cells["pagodolares"].Value = 0;
            }
            if (object.ReferenceEquals(examinar.Rows[examinar.CurrentRow.Index].Cells["monedap"].Value, DBNull.Value))
            {
                examinar.Rows[examinar.CurrentRow.Index].Cells["monedap"].Value = (rbDolares.Checked ? "2" : "1");
            }
            if (examinar.Rows[examinar.CurrentRow.Index].Cells["monedap"].Value.ToString() == VariablesPublicas.MonedaCodSoles | examinar.Rows[examinar.CurrentRow.Index].Cells["monedap"].Value.ToString() == VariablesPublicas.MonedaCodDolares)
            {
            }
            else
            {
                examinar.Rows[examinar.CurrentRow.Index].Cells["monedap"].Value = j_nmonedadetalle;
            }

            sw_novaluechange = false;
        }

        private void btnGeneravoucher_Click(object sender, EventArgs e)
        {
            if (Validacion())
            {
                if (XtraMessageBox.Show("Desea Generar Voucher de Tesoreria", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    generaVoucherTesoreria();
                }
            }
        }
        public bool Validacion()
        {
            string xmsg = "";
            decimal ntotmarcados = VariablesPublicas.StringtoDecimal(lbltotregistros.Text);
            string xcodigo = "...";
            decimal vmnpagosoles = 0;
            decimal vmnpagodolares = 0;
            int ncontador = 0;
            decimal vmncambio = VariablesPublicas.StringtoDecimal(txtTipCamb.Text);
            if (ntotmarcados == 0)
            {
                xmsg = "Seleccione al menos 1 documento a cancelar";
            }
            else
            {
                vmnpagosoles = VariablesPublicas.StringtoDecimal(lbltotalpagosoles.Text);
                vmnpagodolares = VariablesPublicas.StringtoDecimal(lbltotalpagodolares.Text);
                if (vmnpagosoles == 0 & vmnpagodolares == 0)
                {
                    xmsg = "Digite montos a cancelar";
                }
                else
                {
                    if (txtCodsubdiario.Text.Trim().Length > 0)
                    {
                        xcodigo = txtCodsubdiario.Text;
                    }
                    try
                    {
                        DataTable cursortipvoucher = new DataTable();
                        tb_co_tipodiarioBL BL = new tb_co_tipodiarioBL();
                        tb_co_tipodiario BE = new tb_co_tipodiario();

                        BE.perianio = VariablesPublicas.perianio;
                        BE.diarioid = xcodigo;

                        cursortipvoucher = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (tmptabla.Rows.Count == 0)
                    {
                        xmsg = "Ingrese Sub-Diario ";
                    }
                    if (txtcuentaid.Text.Trim().Length == 0)
                    {
                        xmsg = "Sub-Diario no relacinado con cuenta contable";
                    }
                }
            }
            if (vmncambio == 0)
            {
                xmsg = "Ingrese tipo de cambio";
                txtTipCamb.Focus();
            }
            DataTable cursorformaspagos = new DataTable();
            try
            {
                tb_co_tabla01_mediopagoBL BL = new tb_co_tabla01_mediopagoBL();
                tb_co_tabla01_mediopago BE = new tb_co_tabla01_mediopago();

                BE.codigoid = cboFpago.SelectedValue.ToString();
                cursorformaspagos = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (cursorformaspagos.Rows.Count == 0)
            {
                xmsg = "Seleccione Medio de Pago";
                cboFpago.Focus();
            }
            if (txtNumpago.Text.Trim().Length == 0)
            {
                xmsg = "Ingrese Nº de Cheque/Operación";
                txtNumpago.Focus();
            }
            DataTable cursorfefectivo = new DataTable();
            string xFefectivo = "..";
            if (cboFefectivo.Text.ToString().Trim().Length > 0)
            {
                xFefectivo = cboFefectivo.SelectedValue.ToString();
            }
            try
            {
                tb_co_FlujoefectivoBL BL = new tb_co_FlujoefectivoBL();
                tb_co_Flujoefectivo BE = new tb_co_Flujoefectivo();

                BE.fefectivoid = xFefectivo;
                cursorfefectivo = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (cursorfefectivo.Rows.Count == 0)
            {
                xmsg = "Seleccione Flujo de Efectivo";
                cboFefectivo.Focus();
            }
            // Validan Detalles seleccinados
            if (xmsg.Length == 0)
            {
                for (ncontador = 0; ncontador <= DocumentosPendientes.Rows.Count - 1; ncontador++)
                {
                    if (Convert.ToBoolean(DocumentosPendientes.Rows[ncontador]["selecciona"]) == true)
                    {
                        if (Convert.ToDecimal(DocumentosPendientes.Rows[ncontador]["pagosoles"]) == 0 & Convert.ToDecimal(DocumentosPendientes.Rows[ncontador]["pagodolares"]) == 0)
                        {
                            xmsg = "Ingrese monto a cancelar";
                            if (DocumentosPendientes.Rows[ncontador]["monedap"].ToString() == "1")
                            {
                                examinar.CurrentCell = examinar.Rows[ncontador].Cells["pagosoles"];
                            }
                            else
                            {
                                examinar.CurrentCell = examinar.Rows[ncontador].Cells["pagodolares"];
                            }
                            examinar.CurrentCell.ReadOnly = true;
                            examinar.BeginEdit(true);
                            examinar.CurrentCell.ReadOnly = false;
                            break;
                        }
                    }
                }
            }
            if (xmsg.Length == 0)
            {
                if (!PuedeEditarEliminar(" Grabar Asiento Tesoreria ", VariablesPublicas.PADL(fEmision.Value.Month.ToString(), 2, "0")))
                {
                    xmsg = "...";
                }
            }
            if (xmsg.Length > 0 & !(xmsg == "..."))
            {
                XtraMessageBox.Show(xmsg, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            return xmsg.Length == 0;
        }

        public String gettipoper()
        {
            string xReturn = "";
            int LC_CONT = 0;
            for (LC_CONT = 0; LC_CONT <= examinar.RowCount - 1; LC_CONT++)
            {
                if (Convert.ToBoolean(examinar.Rows[LC_CONT].Cells["selecciona"].Value) == true)
                {
                    xReturn = Equivalencias.Left(Convert.ToString(examinar.Rows[LC_CONT].Cells["cuentaid"].Value), 1);
                    break;
                }
            }
            return xReturn;
        }

        public void generaVoucherTesoreria()
        {
            UltimoNumeroRegistro();
            actulizarcursor();

            decimal vmtcambio = VariablesPublicas.StringtoDecimal(txtTipCamb.Text);

            // Variables de Cabecera
            tb_co_MovimientosBL BL = new tb_co_MovimientosBL();
            tb_co_Movimientos BE = new tb_co_Movimientos();

            // Variables para Detalle
            tb_co_Movimientos.Item Detalle = new tb_co_Movimientos.Item();
            List<tb_co_Movimientos.Item> ListaItems = new List<tb_co_Movimientos.Item>();

            #region **ingreso movimiento cabecera***
            //caso Cobranzas/pagos - automatizacion
            string activo = "0"; //Activo
            //string anulad = "9"; //Anulado
            string xMoneda = Equivalencias.Left(cboMoneda.SelectedValue.ToString(), 1);

            BE.perianio = VariablesPublicas.perianio;
            BE.perimes = VariablesPublicas.PADL(fEmision.Value.Month.ToString().Trim(), 2, "0"); // VariablesPublicas.PADL(txtMes.Text.Trim(), 2, "0");
            BE.moduloid = VariablesDominio.VarTesoreria.Moduloid;
            BE.local = VariablesDominio.VarTesoreria.Local;
            BE.diarioid = VariablesPublicas.PADL(txtCodsubdiario.Text, 4, "0");
            BE.asiento = ""; //VariablesPublicas.PADL(txtAsiento.Text.Trim(), 6, "0");
            BE.tipooperacion = gettipoper() == "4" ? "2" : "1";
            BE.tipocomprobante = "2"; //2-Normal
            BE.tipomovimiento = BE.tipooperacion == "1" ? "01" : "11"; //01-ingresos a caja, 11-egresos a caja
            BE.cuentaid = txtcuentaid.Text;

            //Puede ser null
            if (cboFpago.Text.Length > 0)
            { BE.mediopago = cboFpago.SelectedValue.ToString(); }
            else
            { BE.mediopago = ""; }

            BE.numdocpago = txtNumpago.Text;
            //Puede ser null
            if (cboBanco.Text.Length > 0)
            { BE.bancoid = cboBanco.SelectedValue.ToString(); }
            else
            { BE.bancoid = ""; }

            BE.fechregistro = Convert.ToDateTime(fEmision.Text.Trim());
            BE.fechdoc = Convert.ToDateTime(fEmision.Text.Trim());
            BE.tipcamuso = "V";
            BE.tipcamb = Convert.ToDecimal(txtTipCamb.Text.Trim());
            BE.glosa = txtGlosa.Text;
            BE.moneda = (rbDolares.Checked ? "2" : "1");
            //Puede ser null
            if (cboFefectivo.Text.Length > 0)
            { BE.flujoefectivo = cboFefectivo.SelectedValue.ToString(); }
            else
            { BE.flujoefectivo = ""; }

            BE.debesoles = sumadebesoles;
            BE.debedolares = sumadebedolares;
            BE.habersoles = sumahabersoles;
            BE.haberdolares = sumahaberdolares;

            BE.difcambio = false;
            BE.redondeo = false;

            BE.status = activo;

            BE.usuar = VariablesPublicas.Usuar;
            #endregion

            #region ****ingreso movimiento detalle***

            int item = 0;
            foreach (DataRow fila in DetFacturacion.Rows)
            {
                Detalle = new tb_co_Movimientos.Item();

                item++;

                Detalle.perianio = VariablesPublicas.perianio;
                Detalle.perimes = BE.perimes;
                Detalle.moduloid = BE.moduloid;
                Detalle.local = BE.local;
                Detalle.diarioid = BE.diarioid;
                Detalle.asiento = nAsiento.PadLeft(6, '0'); // BE.asiento;
                Detalle.asientoitems = item.ToString().PadLeft(5, '0');
                Detalle.cuentaid = fila["cuentaid"].ToString();
                Detalle.cuentaorigen = fila["cuentaorigen"].ToString(); ;
                Detalle.cuentaname = fila["cuentaname"].ToString();
                Detalle.glosa = txtGlosa.Text.Trim().ToUpper().ToString();

                if (Equivalencias.Left(Detalle.cuentaid.ToString(), 1) == "9")
                { Detalle.cencosid = fila["cencosid"].ToString(); }
                else { Detalle.cencosid = ""; }

                Detalle.debehaber = fila["debehaber"].ToString();
                Detalle.ctacte = fila["ctacte"].ToString();
                Detalle.nmruc = fila["nmruc"].ToString();
                Detalle.ctactename = fila["ctactename"].ToString();
                Detalle.tipdoc = fila["tipdoc"].ToString();
                Detalle.serdoc = fila["serdoc"].ToString();
                Detalle.numdoc = fila["numdoc"].ToString();
                Detalle.fechregistro = Convert.ToDateTime(fEmision.Text.Trim());

                if (object.ReferenceEquals(fila["fechdoc"], DBNull.Value))
                {
                    Detalle.fechdoc = Convert.ToDateTime(fEmision.Text.Trim());
                }
                else
                {
                    Detalle.fechdoc = Convert.ToDateTime(fila["fechdoc"].ToString());
                }

                if (object.ReferenceEquals(fila["fechvenc"], DBNull.Value))
                {
                    Detalle.fechvenc = Convert.ToDateTime(fEmision.Text.Trim());
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
                    Detalle.tipcamb = Convert.ToDecimal(txtTipCamb.Text.Trim());
                }

                Detalle.tipcambuso = BE.tipcamuso;

                try { Detalle.tipcambfech = Convert.ToDateTime(fila["tipcambfech"].ToString()); }
                catch { Detalle.tipcambfech = Convert.ToDateTime(fEmision.Text.Trim()); }

                Detalle.afectoretencion = false;
                Detalle.afectopercepcion = false;
                Detalle.percepcionid = fila["percepcionid"].ToString();
                Detalle.serperc = fila["serperc"].ToString();
                Detalle.numperc = fila["numperc"].ToString();
                Detalle.numdocpago = txtNumpago.Text;
                Detalle.bancoid = BE.bancoid;
                Detalle.pagocta = fila["pagocta"].ToString();
                Detalle.mediopago = BE.mediopago;
                Detalle.fechpago = Convert.ToDateTime(fEmision.Text.Trim());
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
                Detalle.status = activo;
                Detalle.usuar = VariablesPublicas.Usuar;

                ListaItems.Add(Detalle);
            }
            BE.ListaItems = ListaItems;
            #endregion

            #region ** Save BD
            //string nasiento = ""; // nlastreg = "";
            string xcodmes = fEmision.Value.Month.ToString().Trim();
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
            //        XtraMessageBox.Show("Error letal se alcanzó el tope de registro para este tipo de vouchers... Consulta a Sistemas", "");
            //        return;
            //    }
            //}
            try
            {
                if (BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE))
                {
                    // BLOQUEADO TEMPORALMENTE
                    // Impresion 
                    //ReportesContabilidad.Frm_ReporteVouchers frm = new ReportesContabilidad.Frm_ReporteVouchers();
                    //frm._tipComprobante = txtCodsubdiario.Text;
                    //frm._xModulo = BE.moduloid;
                    //frm._xLocal = BE.local;
                    //frm._nroComprobante = BE.perimes + nAsiento;//xcodmes + nlastreg;
                    //frm._tipoOperacion = BE.tipooperacion; //cac3g00.Rows[0]["tasien_3"].ToString();
                    //frm.Owner = this;
                    //frm.ShowInTaskbar = false;
                    //frm.ShowDialog();
                    //U_GeneraPendientes();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
        }
        public void UltimoNumeroRegistro()
        {
            tb_co_MovimientoscabBL BL = new tb_co_MovimientoscabBL();
            tb_co_Movimientoscab BE = new tb_co_Movimientoscab();

            BE.perianio = VariablesPublicas.perianio;
            BE.perimes = fEmision.Value.Month.ToString().Trim().PadLeft(2, '0');
            BE.moduloid = VariablesDominio.VarTesoreria.Moduloid;
            BE.local = VariablesDominio.VarTesoreria.Local;
            BE.diarioid = txtCodsubdiario.Text;

            try
            {
                nAsiento = BL.GetAsientoNume(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0].Rows[0]["asiento"].ToString();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void actulizarcursor()
        {
            DataRow orow = null;

            int nfila = 0;
            for (nfila = 0; nfila <= DocumentosPendientes.Rows.Count - 1; nfila++)
            {
                if (Convert.ToDecimal(DocumentosPendientes.Rows[nfila]["pagosoles"]) < 0)
                {
                    DocumentosPendientes.Rows[nfila]["debehaber"] = (DocumentosPendientes.Rows[nfila]["debehaber"].ToString() == VariablesPublicas.ContabilidadIdCargo ? VariablesPublicas.ContabilidadIdAbono : VariablesPublicas.ContabilidadIdCargo);
                }
            }

            int ncont = 0;
            int lc_contador = 0;
            int lccontcampos = 0;
            //string xnomcolumna = "";
            decimal vmtcambio = VariablesPublicas.StringtoDecimal(txtTipCamb.Text);
            try
            {
                tb_co_MovimientosdetBL BL = new tb_co_MovimientosdetBL();
                tb_co_Movimientosdet BE = new tb_co_Movimientosdet();

                BE.perianio = VariablesPublicas.perianio;
                BE.perimes = VariablesPublicas.PADL(fEmision.Value.Month.ToString().Trim(), 2, "0"); // VariablesPublicas.PADL(txtMes.Text.Trim(), 2, "0");
                BE.moduloid = VariablesDominio.VarTesoreria.Moduloid;
                BE.local = VariablesDominio.VarTesoreria.Local;
                BE.diarioid = "XXXX";
                BE.asiento = "XXXXXX"; //VariablesPublicas.PADL(txtAsiento.Text.Trim(), 6, "0");

                DetFacturacion = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Detalles a Amortizar / Pagar
            decimal vmdebesoles = 0;
            decimal vmdebedolares = 0;
            decimal vmhabersoles = 0;
            decimal vmhaberdolares = 0;
            decimal vmdebesoles10 = 0;
            decimal vmdebedolares10 = 0;
            decimal vmhabersoles10 = 0;
            decimal vmhaberdolares10 = 0;
            decimal ndifsoles = 0;
            for (ncont = 0; ncont <= DocumentosPendientes.Rows.Count - 1; ncont++)
            {
                if (Convert.ToBoolean(DocumentosPendientes.Rows[ncont]["selecciona"]) == true)
                {
                    orow = VariablesPublicas.InsertIntoTable(DetFacturacion);
                    for (lc_contador = 0; lc_contador <= DocumentosPendientes.Rows.Count - 1; lc_contador++)
                    {
                        #region Caso 1: Si no es Nota de Credito
                        orow["debehaber"] = DocumentosPendientes.Rows[ncont]["debehaber"];
                        #endregion
                        #region Caso 1: Si es Nota de Credito
                        if (DocumentosPendientes.Rows[ncont]["tipdoc"].ToString() == "07")
                        {
                            if (Equivalencias.Left(DocumentosPendientes.Rows[ncont]["cuentaid"].ToString(), 1) == "1")
                            {
                                orow["debehaber"] = "D";
                            }
                            else if (Equivalencias.Left(DocumentosPendientes.Rows[ncont]["cuentaid"].ToString(), 1) == "4")
                            {
                                orow["debehaber"] = "H";
                            }
                        }
                        #endregion

                        orow["cuentaid"] = DocumentosPendientes.Rows[ncont]["cuentaid"];
                        orow["cuentaname"] = DocumentosPendientes.Rows[ncont]["cuentaname"];
                        orow["ctacte"] = DocumentosPendientes.Rows[ncont]["ctacte"];
                        orow["nmruc"] = DocumentosPendientes.Rows[ncont]["nmruc"];
                        orow["ctactename"] = DocumentosPendientes.Rows[ncont]["ctactename"];
                        orow["tipdoc"] = DocumentosPendientes.Rows[ncont]["tipdoc"];
                        orow["serdoc"] = DocumentosPendientes.Rows[ncont]["serdoc"];
                        orow["numdoc"] = DocumentosPendientes.Rows[ncont]["numdoc"];
                        orow["fechdoc"] = DocumentosPendientes.Rows[ncont]["fechdoc"];
                        orow["fechvenc"] = DocumentosPendientes.Rows[ncont]["fechvenc"];
                        orow["importe"] = (DocumentosPendientes.Rows[ncont]["moneda"].ToString() == "1" ? Math.Abs(Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagosoles"])) : Math.Abs(Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagodolares"])));
                        orow["importecambio"] = (DocumentosPendientes.Rows[ncont]["moneda"].ToString() == "1" ? Math.Abs(Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagodolares"])) : Math.Abs(Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagosoles"])));
                        orow["soles"] = Math.Abs(Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagosoles"]));
                        orow["dolares"] = Math.Abs(Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagodolares"]));
                        orow["moneda"] = DocumentosPendientes.Rows[ncont]["moneda"];
                        orow["tipcamb"] = DocumentosPendientes.Rows[ncont]["tipcamb"];
                        orow["tipcambuso"] = "V"; // DocumentosPendientes.Rows[ncont]["tipcambuso"];
                        orow["tipcambfech"] = DocumentosPendientes.Rows[ncont]["fechdoc"];
                        orow["pedidoid"] = DocumentosPendientes.Rows[ncont]["pedidoid"];
                        orow["tip_op"] = DocumentosPendientes.Rows[ncont]["tip_op"];
                        orow["ser_op"] = DocumentosPendientes.Rows[ncont]["ser_op"];
                        orow["num_op"] = DocumentosPendientes.Rows[ncont]["num_op"];
                    }

                    //for (lccontcampos = 0; lccontcampos <= DetFacturacion.Columns.Count - 1; lccontcampos++)
                    //{
                    //    orow[DetFacturacion.Columns[lccontcampos].ColumnName] = DocumentosPendientes.Rows[ncont][DetFacturacion.Columns[lccontcampos].ColumnName];
                    //}

                    if (DocumentosPendientes.Rows[ncont]["debehaber"].ToString() == VariablesPublicas.ContabilidadIdCargo) //GlobalVars.ContabilidadIdCargo)
                    {
                        vmdebesoles = vmdebesoles + Math.Abs(Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagosoles"]));
                        vmdebedolares = vmdebedolares + Math.Abs(Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagodolares"]));
                    }
                    else
                    {
                        vmhabersoles = vmhabersoles + Math.Abs(Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagosoles"]));
                        vmhaberdolares = vmhaberdolares + Math.Abs(Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagodolares"]));
                    }
                    DetFacturacion.Rows.Add(orow);
                }
            }
            // Gastos Adicionales
            for (ncont = 0; ncont <= TabCac3p00GastosAdic.Rows.Count - 1; ncont++)
            {
                if ((!object.ReferenceEquals(TabCac3p00GastosAdic.Rows[ncont]["cuentaid"], DBNull.Value)))
                {
                    if (TabCac3p00GastosAdic.Rows[ncont]["cuentaid"].ToString().Trim().Length > 0)
                    {
                        orow = VariablesPublicas.InsertIntoTable(DetFacturacion);
                        for (lccontcampos = 0; lccontcampos <= DetFacturacion.Columns.Count - 1; lccontcampos++)
                        {
                            orow[DetFacturacion.Columns[lccontcampos].ColumnName] = TabCac3p00GastosAdic.Rows[ncont][DetFacturacion.Columns[lccontcampos].ColumnName];
                        }
                        orow["ctacte"] = xctacte;
                        orow["nmruc"] = txtRuc.Text;
                        orow["ctactename"] = txtCtactename.Text;

                        if (TabCac3p00GastosAdic.Rows[ncont]["moneda"].ToString() == "1")
                        {
                            orow["importe"] = TabCac3p00GastosAdic.Rows[ncont]["Importe"];
                            orow["importecambio"] = TabCac3p00GastosAdic.Rows[ncont]["ImporteCambio"];
                            orow["soles"] = TabCac3p00GastosAdic.Rows[ncont]["Importe"];
                            orow["dolares"] = TabCac3p00GastosAdic.Rows[ncont]["ImporteCambio"];
                        }
                        else
                        {
                            orow["importe"] = TabCac3p00GastosAdic.Rows[ncont]["Importe"];
                            orow["importecambio"] = TabCac3p00GastosAdic.Rows[ncont]["ImporteCambio"];
                            orow["dolares"] = TabCac3p00GastosAdic.Rows[ncont]["Importe"];
                            orow["soles"] = TabCac3p00GastosAdic.Rows[ncont]["ImporteCambio"];
                        }
                        DetFacturacion.Rows.Add(orow);
                        if (TabCac3p00GastosAdic.Rows[ncont]["debehaber"].ToString() == VariablesPublicas.ContabilidadIdCargo)
                        {
                            vmdebesoles = vmdebesoles + Math.Abs(Convert.ToDecimal(orow["soles"]));
                            vmdebedolares = vmdebedolares + Math.Abs(Convert.ToDecimal(orow["dolares"]));
                        }
                        else
                        {
                            vmhabersoles = vmhabersoles + Math.Abs(Convert.ToDecimal(orow["soles"]));
                            vmhaberdolares = vmhaberdolares + Math.Abs(Convert.ToDecimal(orow["dolares"]));
                        }
                    }
                }
            }
            // Detalle Cuenta bancos
            //DetFacturacion.Rows.Add(VariablesPublicas.InsertIntoTable(DetFacturacion));

            DetFacturacion.ImportRow(DetFacturacion.Rows[0]);  // Duplicar la primera fila

            DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cuentaname"] = "";
            DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["debehaber"] = "";
            DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importe"] = 0;
            DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importecambio"] = 0;
            DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["soles"] = 0;
            DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["dolares"] = 0;

            DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cuentaid"] = txtcuentaid.Text.Trim();
            DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cuentaname"] = CuentaName(VariablesPublicas.perianio, txtcuentaid.Text.Trim());
            DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["moneda"] = (rbDolares.Checked ? 2 : 1);

            if (vmdebesoles > vmhabersoles)
            {
                DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["debehaber"] = VariablesPublicas.ContabilidadIdAbono;
                vmdebesoles10 = Math.Abs(vmdebesoles - vmhabersoles);
                vmdebedolares10 = Math.Abs(vmdebedolares - vmhaberdolares);
            }
            else
            {
                vmhabersoles10 = Math.Abs(vmdebesoles - vmhabersoles);
                vmhaberdolares10 = Math.Abs(vmdebedolares - vmhaberdolares);

                DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["debehaber"] = VariablesPublicas.ContabilidadIdCargo;
            }
            DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["soles"] = Math.Round(Math.Abs(vmdebesoles - vmhabersoles), 2);
            DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["dolares"] = Math.Round(Math.Abs(vmdebedolares - vmhaberdolares), 2);
            DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["ctacte"] = xctacte;
            DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["ctactename"] = txtCtactename.Text;
            DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["nmruc"] = txtRuc.Text;
            DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["fechdoc"] = fEmision.Text;
            DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["fechvenc"] = fEmision.Text;
            DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["tipcamb"] = txtTipCamb.Text;
            DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["tipcambuso"] = "V";
            DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["tipcambfech"] = fEmision.Text;

            if (rbDolares.Checked)
            {
                if (vmtcambio == 0)
                {
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["soles"] = 0;
                }
                else
                {
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importe"] = Math.Round(Convert.ToDecimal(DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["dolares"]), 2);
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importecambio"] = Math.Round(Convert.ToDecimal(DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["dolares"]) * vmtcambio, 2);
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["soles"] = Math.Round(Convert.ToDecimal(DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["dolares"]) * vmtcambio, 2);
                }
            }
            else
            {
                if (vmtcambio == 0)
                {
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["doalres"] = 0;
                }
                else
                {
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importe"] = Math.Round(Convert.ToDecimal(DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["soles"]), 2);
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importecambio"] = Math.Round(Convert.ToDecimal(DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["soles"]) / vmtcambio, 2);
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["dolares"] = Math.Round(Convert.ToDecimal(DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["soles"]) / vmtcambio, 2);
                }
            }

            vmdebesoles = 0;
            vmhabersoles = 0;
            vmdebedolares = 0;
            vmhaberdolares = 0;
            for (ncont = 0; ncont <= DetFacturacion.Rows.Count - 1; ncont++)
            {
                DetFacturacion.Rows[ncont]["soles"] = Math.Round(Convert.ToDecimal(DetFacturacion.Rows[ncont]["soles"]), 2);
                DetFacturacion.Rows[ncont]["dolares"] = Math.Round(Convert.ToDecimal(DetFacturacion.Rows[ncont]["dolares"]), 2);
                if (DetFacturacion.Rows[ncont]["debehaber"].ToString() == VariablesPublicas.ContabilidadIdCargo)
                {
                    vmdebesoles = vmdebesoles + Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["soles"]));
                    vmdebedolares = vmdebedolares + Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["dolares"]));
                }
                else
                {
                    vmhabersoles = vmhabersoles + Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["soles"]));
                    vmhaberdolares = vmhaberdolares + Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["dolares"]));
                }
            }

            tb_co_ConfigcuentasrhredBL BiL = new tb_co_ConfigcuentasrhredBL();
            tb_co_Configcuentasrhred BiE = new tb_co_Configcuentasrhred();

            DataTable tmptablaconfig = BiL.GetAll(VariablesPublicas.EmpresaID.ToString(), BiE).Tables[0]; //ocapa.FagRHP_ConfigCuentas_consulta(GlobalVars.GetInstance.Company);
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
                    DetFacturacion.ImportRow(DetFacturacion.Rows[0]);  // Duplicar la primera fila

                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cuentaname"] = "";
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["debehaber"] = "";
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importe"] = 0;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importecambio"] = 0;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["soles"] = 0;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["dolares"] = 0;

                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["ctacte"] = xctacte;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["nmruc"] = txtRuc.Text;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["ctactename"] = txtCtactename.Text;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["fechdoc"] = fEmision.Text;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["fechvenc"] = fEmision.Text;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["tipcamb"] = txtTipCamb.Text;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["tipcambuso"] = "V";
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["tipcambfech"] = fEmision.Text;
                    //DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["dolares"] = 0;
                    ndifdolares = Math.Round(Math.Abs(vmdebedolares - vmhaberdolares), 2);
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["moneda"] = (rbDolares.Checked ? 2 : 1);
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["debehaber"] = (vmdebedolares > vmhaberdolares ? "H" : "D");
                    // perdida
                    if ((vmdebedolares - vmhaberdolares) < 0)
                    {
                        DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cuentaid"] = xcuentaperdida;
                        DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cuentaname"] = CuentaName(VariablesPublicas.perianio, xcuentaperdida);
                        DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cencosid"] = xccostoperdida;
                    }
                    else
                    {
                        DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cuentaid"] = xcuentaganancia;
                        DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cuentaname"] = CuentaName(VariablesPublicas.perianio, xcuentaganancia);
                        DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cencosid"] = xccostoganancia;
                    }
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importe"] = 0;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importecambio"] = Math.Abs(ndifdolares);
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["soles"] = 0;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["dolares"] = Math.Abs(ndifdolares);
                }
                else
                {
                    XtraMessageBox.Show("El asiento se va a generar con diferencia... Falta Configurar cuentas de ajuste x dif.cambio", "");
                }
            }
            //Ajustes DIF.CAMBIO EN SOLES
            if ((!(vmdebesoles == vmhabersoles)) & Math.Abs(vmdebesoles - vmhabersoles) > 0)
            {
                if (xcuentaganancia.Trim().Length > 0 & xcuentaperdida.Trim().Length > 0)
                {
                    //DetFacturacion.Rows.Add(VariablesPublicas.InsertIntoTable(DetFacturacion));
                    DetFacturacion.ImportRow(DetFacturacion.Rows[0]);  // Duplicar la primera fila

                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cuentaname"] = "";
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["debehaber"] = "";
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importe"] = 0;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importecambio"] = 0;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["soles"] = 0;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["dolares"] = 0;

                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["ctacte"] = xctacte;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["nmruc"] = txtRuc.Text;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["ctactename"] = txtCtactename.Text;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["fechdoc"] = fEmision.Text;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["fechvenc"] = fEmision.Text;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["tipcamb"] = txtTipCamb.Text;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["tipcambuso"] = "V";
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["tipcambfech"] = fEmision.Text;
                    ndifsoles = Math.Abs(vmdebesoles - vmhabersoles);
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["moneda"] = (rbDolares.Checked ? 2 : 1);
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["debehaber"] = (vmdebesoles > vmhabersoles ? "H" : "D");
                    // perdida
                    if ((vmdebesoles - vmhabersoles) < 0)
                    {
                        DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cuentaid"] = xcuentaperdida;
                        DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cuentaname"] = CuentaName(VariablesPublicas.perianio, xcuentaperdida);
                        DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cencosid"] = xccostoperdida;
                    }
                    else
                    {
                        DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cuentaid"] = xcuentaganancia;
                        DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cuentaname"] = CuentaName(VariablesPublicas.perianio, xcuentaganancia);
                        DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cencosid"] = xccostoganancia;
                    }
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importe"] = Math.Abs(ndifsoles);
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importecambio"] = 0;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["dolares"] = 0;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["soles"] = Math.Abs(ndifsoles);
                }
                else
                {
                    XtraMessageBox.Show("El asiento se va a generar con diferencia... Falta Configurar cuentas de ajuste x dif.cambio", "");
                }
            }
            // Sumatoria para los totales Cabecera
            vmdebesoles = 0;
            vmdebedolares = 0;
            vmhabersoles = 0;
            vmhaberdolares = 0;

            for (ncont = 0; ncont <= DetFacturacion.Rows.Count - 1; ncont++)
            {
                if (DetFacturacion.Rows[ncont]["debehaber"].ToString() == VariablesPublicas.ContabilidadIdCargo)
                {
                    vmdebesoles = vmdebesoles + Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["soles"]));
                    sumadebesoles = vmdebesoles;
                    vmdebedolares = vmdebedolares + Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["dolares"]));
                    sumadebedolares = vmdebedolares;
                }
                else
                {
                    vmhabersoles = vmhabersoles + Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["soles"]));
                    sumahabersoles = vmhabersoles;
                    vmhaberdolares = vmhaberdolares + Math.Abs(Convert.ToDecimal(DetFacturacion.Rows[ncont]["dolares"]));
                    sumahaberdolares = vmhaberdolares;
                }
            }
            #region
            //// Cabecera
            //cac3g00.Rows[0]["ccia_3"] = GlobalVars.GetInstance.Company;
            //cac3g00.Rows[0]["cperiodo_3"] = GlobalVars.GetInstance.Periodo;
            //cac3g00.Rows[0]["ccom_3"] = txtcodsubdiario.Text;
            //cac3g00.Rows[0]["tcom_3"] = 2;
            //cac3g00.Rows[0]["tmov_3"] = "22";
            //cac3g00.Rows[0]["tasien_3"] = 1;
            //cac3g00.Rows[0]["mone_3"] = (rbDolares.Checked ? 2 : 1);
            //cac3g00.Rows[0]["fcom_3"] = femision.Value;
            //cac3g00.Rows[0]["fcome_3"] = femision.Value;
            //cac3g00.Rows[0]["tcam_3"] = VariablesPublicas.StringtoDecimal(txtcambio.Text);
            //cac3g00.Rows[0]["totd1_3"] = vmdebesoles;
            //cac3g00.Rows[0]["totd2_3"] = vmdebedolares;
            //cac3g00.Rows[0]["toth1_3"] = vmhabersoles;
            //cac3g00.Rows[0]["toth2_3"] = vmhaberdolares;
            //cac3g00.Rows[0]["cuenb_3"] = cursortipvoucher.Rows[0]["cuenb_3i"];
            //cac3g00.Rows[0]["glosa_3"] = Strings.Mid(txtglosa.Text, 1, cac3g00.Columns["glosa_3"].MaxLength);
            //cac3g00.Rows[0]["girado_3"] = Strings.Mid(txtgirado.Text, 1, cac3g00.Columns["girado_3"].MaxLength);
            //cac3g00.Rows[0]["flag_3"] = 1;
            //cac3g00.Rows[0]["usuario_3"] = Strings.Mid(GlobalVars.GetInstance.UserSigla, 1, cac3g00.Columns["usuario_3"].MaxLength);
            //cac3g00.Rows[0]["fpago_3"] = txtcodpago.Text;



            //string nlastreg = "";
            //string xcodmes = femision.Value.Month.ToString.Trim;
            //xcodmes = VariablesPublicas.PADL(xcodmes, 2, "0");
            //nlastreg = ocapa.CaeSoft_GetAllMaximoMovimientoContable(cac3g00.Rows[0]["ccia_3"], cac3g00.Rows[0]["cperiodo_3"], txtcodsubdiario.Text, xcodmes);
            //tmptabla = ocapa.cac3p00_consulta(GlobalVars.GetInstance.Company, GlobalVars.GetInstance.Periodo, txtcodsubdiario.Text, xcodmes, nlastreg, "", "");
            //if (ocapa.sql_error.Length > 0)
            //{
            //    ERP_CAESOFT_FORMS.frmclass.ShowError(ocapa.sql_error, this);
            //    return;
            //}
            //dynamic nvmindice = 0;
            //while (tmptabla.Rows.Count > 0)
            //{
            //    nlastreg = ocapa.CaeSoft_GetAllMaximoMovimientoContable(cac3g00.Rows[0]["ccia_3"], cac3g00.Rows[0]["cperiodo_3"], txtcodsubdiario.Text, xcodmes);
            //    tmptabla = ocapa.cac3p00_consulta(GlobalVars.GetInstance.Company, GlobalVars.GetInstance.Periodo, txtcodsubdiario.Text, xcodmes, nlastreg, "", "");
            //    nvmindice = nvmindice + 1;
            //    if (nvmindice > 999999)
            //    {
            //        Interaction.MsgBox("ERROR LETAL SE ALCANZO EL ToPE DE REGiSTRO PARA ESTE TIPO DE VOUCHER.. CONSULTA A SISTEMAS", 16, "");
            //        return;
            //    }
            //}
            //UltimoNumVoucher = nlastreg;
            //UltimoMesVoucher = xcodmes;
            //UltimoTipoVoucher = txtcodsubdiario.Text;
            //cac3g00.AcceptChanges();
            //cac3p00.AcceptChanges();
            ////Claves Principales
            //for (ncont = 0; ncont <= cac3g00.Rows.Count - 1; ncont++)
            //{
            //    cac3g00.Rows[ncont]["ncom_3"] = xcodmes + nlastreg;
            //    cac3g00.Rows[ncont]["ccia_3"] = GlobalVars.GetInstance.Company;
            //    cac3g00.Rows[ncont]["cperiodo_3"] = GlobalVars.GetInstance.Periodo;
            //    cac3g00.Rows[ncont]["ccom_3"] = txtcodsubdiario.Text;
            //    cac3g00.Rows[ncont]["flag_3"] = 1;

            //}

            //for (ncont = 0; ncont <= cac3p00.Rows.Count - 1; ncont++)
            //{
            //    cac3p00.Rows[ncont]["ncom_3a"] = xcodmes + nlastreg;
            //    cac3p00.Rows[ncont]["ccia_3a"] = GlobalVars.GetInstance.Company;
            //    cac3p00.Rows[ncont]["cperiodo_3a"] = GlobalVars.GetInstance.Periodo;
            //    cac3p00.Rows[ncont]["ccom_3a"] = txtcodsubdiario.Text;
            //    cac3p00.Rows[ncont]["flag_3a"] = 1;
            //}

            //if (!ocapa.cac3g00_update(cac3g00, cac3p00))
            //{
            //    ERP_CAESOFT_FORMS.frmclass.ShowError(ocapa.sql_error, this);
            //    UltimoTipoVoucher = "";
            //}
            //else
            //{
            //    if (!ocapa.CaeSoft_GetAllAsientoAutomaticoDestino(cac3g00.Rows[0]["ccia_3"], cac3g00.Rows[0]["cperiodo_3"], "", cac3g00.Rows[0]["ccom_3"], cac3g00.Rows[0]["ncom_3"], 2, "", ""))
            //    {
            //        ERP_CAESOFT_FORMS.frmclass.ShowError(ocapa.sql_error, this);
            //    }

            //    // Impresion
            //    FRMImpresionMovimientos frm = new FRMImpresionMovimientos();
            //    frm._tipComprobante = txtcodsubdiario.Text;
            //    frm._nroComprobante = xcodmes + nlastreg;
            //    frm._tipoOperacion = cac3g00.Rows[0]["tasien_3"].ToString();
            //    frm.Owner = this;
            //    frm.ShowInTaskbar = false;
            //    frm.ShowDialog();
            //    U_GeneraPendientes();
            //}
            #endregion
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
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return tablecuenta.Rows[0]["cuentaname"].ToString().Trim();
        }

        public bool validaParametros()
        {
            string xmsg = "";
            if (rbDetalle.Checked & txtRuc.Text.Trim().Length == 0)
            {
                xmsg = "Ingrese Ruc-Cód Cuenta Corriente (Proveedores, Clientes, Etc.)";
                txtRuc.Focus();
            }
            if (rbMultiplesdetalles.Checked)
            {
                if (TablaDetallesaSeleccionar == null)
                {
                    xmsg = "Ingrese Ruc-Cód Cuenta Corriente (Proveedores, Clientes, Etc.)";
                    btnSeleccionarproveedores.Focus();
                }
            }
            if (xmsg.Length == 0)
            {
                if (txtCuenta.Enabled & txtCuenta.Text.Trim().Length == 0)
                {
                    //   xmsg = "Seleccione al menos 1 cuenta"
                }
            }
            if (xmsg.Length > 0)
            {
                //Interaction.MsgBox(xmsg, 64, "Validación");
                XtraMessageBox.Show(xmsg, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            return xmsg.Length == 0;
        }

        private void txtmontoapagar_GotFocus(System.Object sender, System.EventArgs e)
        {
            j_nvalorapagar = txtmontoapagar.Text;
        }
        private void txtmontoapagar_LostFocus(System.Object sender, System.EventArgs e)
        {
            if (!(j_nvalorapagar == txtmontoapagar.Text))
            {
                decimal nvalor = VariablesPublicas.StringtoDecimal(txtmontoapagar.Text);
                txtmontoapagar.Text = nvalor.ToString("###,###,###.00");
            }
        }

        private void btnPagoauto_Click(object sender, EventArgs e)
        {
            string vmxmoneda = "";
            int ncont = 0;
            decimal ndeuda = default(decimal);
            decimal ntotalapagar = 0;
            decimal nvalorapagar = default(decimal);
            decimal vmncambio = default(decimal);
            sw_novaluechange = true;
            if ((cboMoneda.SelectedValue != null))
            {
                vmxmoneda = cboMoneda.SelectedValue.ToString();
                ntotalapagar = VariablesPublicas.StringtoDecimal(txtmontoapagar.Text);
                for (ncont = 0; ncont <= DocumentosPendientes.Rows.Count - 1; ncont++)
                {
                    if (Convert.ToBoolean(DocumentosPendientes.Rows[ncont]["selecciona"]) == true)
                    {
                        vmncambio = Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["tipcamb"]);
                        if (vmxmoneda == "1")
                        {
                            ndeuda = Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["saldo1"]);
                        }
                        if (vmxmoneda == "2")
                        {
                            ndeuda = Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["saldo2"]);
                        }
                        if (!(DocumentosPendientes.Rows[ncont]["monedap"].ToString() == vmxmoneda))
                        {
                            if (vmxmoneda == "1")
                            {
                                nvalorapagar = ndeuda * vmncambio;
                            }
                            else
                            {
                                nvalorapagar = (vmncambio == 0 ? 0 : ndeuda / vmncambio);
                            }
                        }
                        else
                        {
                            nvalorapagar = ndeuda;
                        }
                        if (vmxmoneda == "1")
                        {
                            DocumentosPendientes.Rows[ncont]["pagosoles"] = Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagosoles"]) + (ntotalapagar <= ndeuda ? ntotalapagar : ndeuda);
                            if (vmncambio == 0)
                            {
                                DocumentosPendientes.Rows[ncont]["pagodolares"] = Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagodolares"]) + 0;
                            }
                            else
                            {
                                DocumentosPendientes.Rows[ncont]["pagodolares"] = Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagodolares"]) + Math.Round((Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagosoles"]) / vmncambio),2);
                            }
                        }
                        else
                        {
                            DocumentosPendientes.Rows[ncont]["pagodolares"] = Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagodolares"]) + (ntotalapagar <= ndeuda ? ntotalapagar : ndeuda);
                            if (vmncambio == 0)
                            {
                                DocumentosPendientes.Rows[ncont]["pagosoles"] = Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagosoles"]) + 0;
                            }
                            else
                            {
                                DocumentosPendientes.Rows[ncont]["pagosoles"] = Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagosoles"]) + Math.Round((Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagodolares"]) * vmncambio),2);
                            }
                        }
                        DocumentosPendientes.Rows[ncont]["pagosoles"] = Math.Round(Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagosoles"]), 2);
                        DocumentosPendientes.Rows[ncont]["pagodolares"] = Math.Round(Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagodolares"]), 2);

                        if (vmxmoneda == "1")
                        {
                            ntotalapagar = ntotalapagar - Math.Round(Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagosoles"]),2);
                        }
                        else
                        {
                            ntotalapagar = ntotalapagar - Math.Round(Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagodolares"]),2);
                        }
                        if (ntotalapagar > 0)
                        {
                            ncont = ncont - 1;
                        }
                    }
                }
            }
            Sumatoria();
            sw_novaluechange = false;
        }

        private void btnVervoucher_Click(object sender, EventArgs e)
        {
            if (UltimoTipoVoucher.Trim().Length > 0)
            {
                //frm_mov_contables_nuevo oform = new frm_mov_contables_nuevo();
                //oform._Mes = UltimoMesVoucher;
                //oform._Registro = UltimoNumVoucher;
                //oform._Codvoucher = UltimoTipoVoucher;
                //oform._Tesoreria = true;
                //oform.Owner = this;
                //oform.ShowInTaskbar = false;
                //oform.Show();
            }
            else
            {
                //Interaction.MsgBox("Aún no se ha generado ningún voucher de cancelación", 64, "");
                XtraMessageBox.Show("Aún no se ha generado ningún voucher de cancelación", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void btnaddfila_Click(object sender, EventArgs e)
        {
            adicionagastoadicional();
        }
        public void adicionagastoadicional()
        {
            string xvalorcargo = VariablesPublicas.ContabilidadIdCargo;
            //if ((examinar.CurrentRow != null))
            //{
            //    if ((!object.ReferenceEquals(examinar.Rows[examinar.CurrentRow.Index].Cells["debehaber"].Value, DBNull.Value)))
            //    {
            //        xvalorcargo = examinar.Rows[examinar.CurrentRow.Index].Cells["debehaber"].Value.ToString();
            //    }
            //}
            string nmoneda = "";
            if ((cboMoneda.SelectedValue != null))
            {
                nmoneda = cboMoneda.SelectedValue.ToString();
            }
            TabCac3p00GastosAdic.Rows.Add(VariablesPublicas.InsertIntoTable(TabCac3p00GastosAdic));
            TabCac3p00GastosAdic.Rows[TabCac3p00GastosAdic.Rows.Count - 1]["asientoitems"] = VariablesPublicas.CalcMaxField(TabCac3p00GastosAdic, "asientoitems", 5);
            //TabCac3p00GastosAdic.Rows[TabCac3p00GastosAdic.Rows.Count - 1]["lee_detalle"] = 0;
            TabCac3p00GastosAdic.Rows[TabCac3p00GastosAdic.Rows.Count - 1]["debehaber"] = xvalorcargo;
            TabCac3p00GastosAdic.Rows[TabCac3p00GastosAdic.Rows.Count - 1]["moneda"] = nmoneda;
            gridgastos.CurrentCell = gridgastos.Rows[gridgastos.RowCount - 1].Cells["gasto_cuentaid"];
            TabCac3p00GastosAdic.AcceptChanges();
            gridgastos.BeginEdit(true);
            u_RefrescaControles();
        }

        private void btndelfila_Click(object sender, EventArgs e)
        {
            string xcoditem = "";
            Int16 lc_cont = default(Int16);
            if ((gridgastos.CurrentRow != null))
            {
                xcoditem = gridgastos.Rows[gridgastos.CurrentCell.RowIndex].Cells["asientoitems"].Value.ToString();
                for (lc_cont = 0; lc_cont <= TabCac3p00GastosAdic.Rows.Count - 1; lc_cont++)
                {
                    // ubique el item a borrar
                    if (TabCac3p00GastosAdic.Rows[lc_cont]["asientoitems"].ToString() == xcoditem)
                    {
                        TabCac3p00GastosAdic.Rows[lc_cont].Delete();
                        TabCac3p00GastosAdic.AcceptChanges();
                        break;
                    }
                }
                // regenerar el nro de item
                for (lc_cont = 0; lc_cont <= TabCac3p00GastosAdic.Rows.Count - 1; lc_cont++)
                {
                    TabCac3p00GastosAdic.Rows[lc_cont]["asientoitems"] = VariablesPublicas.PADL(Convert.ToString(lc_cont) + 1, 5, "0");
                }
                TabCac3p00GastosAdic.AcceptChanges();
                u_RefrescaControles();
                totalizar();
            }
        }
        //GRID GASTOS ADICIONALES
        private void gridgastos_SelectionChanged(object sender, EventArgs e)
        {
            txtdescripcampo.Text = "";
            string prvcod = "";
            if ((gridgastos.CurrentCell != null))
            {
                if (gridgastos.Columns[gridgastos.CurrentCell.ColumnIndex].Name.ToUpper() == "gasto_cuentaid".ToUpper())
                {
                    txtdescripcampo.Text = gridgastos.Rows[gridgastos.CurrentCell.RowIndex].Cells["gasto_cuentaname"].Value.ToString();
                }
                if (gridgastos.Columns[gridgastos.CurrentCell.ColumnIndex].Name.ToUpper() == "gasto_moneda".ToUpper())
                {
                    txtdescripcampo.Text = "[1] SOLES [2] DOLARES";
                }
                if (gridgastos.Columns[gridgastos.CurrentCell.ColumnIndex].Name.ToUpper() == "gasto_tipdoc".ToUpper())
                {
                    if ((!object.ReferenceEquals(gridgastos.Rows[gridgastos.CurrentCell.RowIndex].Cells["gasto_tipdoc"].Value, DBNull.Value)))
                    {
                        prvcod = gridgastos.Rows[gridgastos.CurrentCell.RowIndex].Cells["gasto_tipdoc"].Value.ToString();
                    }
                    if (prvcod.Trim().Length == 0)
                    {
                        prvcod = "...";
                    }
                    tb_co_tabla10_comprobantesBL BL = new tb_co_tabla10_comprobantesBL();
                    tb_co_tabla10_comprobantes BE = new tb_co_tabla10_comprobantes();

                    BE.codigoid = prvcod;
                    tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                    //tmptabla = ocapa.cag3i00_consulta(GlobalVars.GetInstance.Company, prvcod, "", 1, GlobalVars.GetInstance.TipDocusTodos, "", "", "");
                    //if (ocapa.sql_error.Length == 0)
                    //{
                    if (tmptabla.Rows.Count > 0)
                    {
                        txtdescripcampo.Text = tmptabla.Rows[0]["descripcion"].ToString();
                    }
                    //}
                }
                //Centro de Costo
                if (gridgastos.Columns[gridgastos.CurrentCell.ColumnIndex].Name.ToUpper() == "gasto_cencosid".ToUpper())
                {
                    if ((!object.ReferenceEquals(gridgastos.Rows[gridgastos.CurrentCell.RowIndex].Cells["gasto_cencosid"].Value, DBNull.Value)))
                    {
                        prvcod = gridgastos.Rows[gridgastos.CurrentCell.RowIndex].Cells["gasto_cencosid"].Value.ToString();
                    }
                    if (prvcod.Trim().Length == 0)
                    {
                        prvcod = "...";
                    }
                    centrocostoBL BL = new centrocostoBL();
                    tb_centrocosto BE = new tb_centrocosto();

                    BE.cencosid = prvcod;
                    //BE.cencosdivi = xclasecuenta;

                    tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                    //tmptabla = ocapa.pag0101_consulta(GlobalVars.GetInstance.Company, prvcod, "", 2, 1, "", "", "", "");
                    //if (ocapa.sql_error.Length == 0)
                    //{
                    if (tmptabla.Rows.Count > 0)
                    {
                        txtdescripcampo.Text = tmptabla.Rows[0]["cencosname"].ToString();
                    }
                    //}
                }
            }
            u_RefrescaControles();
        }
        private void gridgastos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if ((gridgastos.CurrentRow != null))
            {
                if (gridgastos.Columns[e.ColumnIndex].Name.ToUpper() == "gasto_debehaber".ToUpper())
                {
                    J_debehaber = gridgastos.CurrentCell.Value.ToString();
                }
                if (gridgastos.Columns[e.ColumnIndex].Name.ToUpper() == "gasto_cuentaid".ToUpper())
                {
                    j_CuentaContable = gridgastos.CurrentCell.Value.ToString();
                }
                if (gridgastos.Columns[e.ColumnIndex].Name.ToUpper() == "gasto_nmruc".ToUpper())
                {
                    j_Detalle = gridgastos.CurrentCell.Value.ToString();
                }
                if (gridgastos.Columns[e.ColumnIndex].Name.ToUpper() == "gasto_cencosid".ToUpper())
                {
                    j_CcostoAdic = gridgastos.CurrentCell.Value.ToString();
                }
                if (gridgastos.Columns[e.ColumnIndex].Name.ToUpper() == "gasto_moneda".ToUpper())
                {
                    j_nmonedadetalle = gridgastos.CurrentCell.Value.ToString();
                }
                if (gridgastos.Columns[e.ColumnIndex].Name.ToUpper() == "gasto_tipdoc".ToUpper())
                {
                    j_TipDocGasAdic = gridgastos.CurrentCell.Value.ToString();
                }
            }
        }
        private void gridgastos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((gridgastos.CurrentRow != null) & !sw_novaluechange & !swLoad)
            {
                if (gridgastos.Columns[e.ColumnIndex].Name.ToUpper() == "gasto_debehaber".ToUpper())
                {
                    sw_novaluechange = true;
                    if (!(gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_debehaber"].Value.ToString() == VariablesPublicas.ContabilidadIdAbono | gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_debehaber"].Value.ToString() == VariablesPublicas.ContabilidadIdCargo))
                    {
                        gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_debehaber"].Value = J_debehaber;
                    }
                    sw_novaluechange = false;
                    totalizar();
                }
                if (gridgastos.Columns[e.ColumnIndex].Name.ToUpper() == "gasto_cuentaid".ToUpper())
                {
                    validacuentaGastoAdicional();
                }
                if (gridgastos.Columns[e.ColumnIndex].Name.ToUpper() == "gasto_cencosid".ToUpper())
                {
                    validaCentroCosto();
                }
                if (gridgastos.Columns[e.ColumnIndex].Name.ToUpper() == "Importe".ToUpper())
                {
                    totalizarItem();
                }
                if (gridgastos.Columns[e.ColumnIndex].Name.ToUpper() == "ImporteCambio".ToUpper())
                {
                    totalizarItem();
                }
                if (gridgastos.Columns[e.ColumnIndex].Name.ToUpper() == "gasto_moneda".ToUpper())
                {
                    validaMonedaDetalle();
                }
                if (gridgastos.Columns[e.ColumnIndex].Name.ToUpper() == "gasto_tipdoc".ToUpper())
                {
                    validaTipoDocumento();
                }
                if (gridgastos.Columns[e.ColumnIndex].Name.ToUpper() == "gasto_serdoc".ToUpper())
                {
                    validaSeriedocumento();
                }
                if (gridgastos.Columns[e.ColumnIndex].Name.ToUpper() == "gasto_numdoc".ToUpper())
                {
                    validaNumerodocumento();
                }
                if (gridgastos.Columns[e.ColumnIndex].Name.ToUpper() == "gasto_fechdoc".ToUpper())
                {
                    ValidaFechaGasto();
                }
            }
        }
        private void gridgastos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (gridgastos.Columns[gridgastos.CurrentCell.ColumnIndex].Name.ToUpper() == "gasto_debehaber".ToUpper())
            {
                txtCArti = (TextBox)e.Control;
                txtCArti.MaxLength = 1;
                txtCArti.CharacterCasing = CharacterCasing.Upper;
                txtCArti.Text.Trim();
                e.Control.KeyDown += VariablesPublicas.CapturarTeclaGRID;
            }
            if (gridgastos.Columns[gridgastos.CurrentCell.ColumnIndex].Name.ToUpper() == "gasto_cuentaid".ToUpper())
            {
                txtCArti = (TextBox)e.Control;
                txtCArti.MaxLength = 10;
                txtCArti.CharacterCasing = CharacterCasing.Upper;
                txtCArti.Text.Trim();
                e.Control.KeyDown += VariablesPublicas.CapturarTeclaGRID;
            }
            if (gridgastos.Columns[gridgastos.CurrentCell.ColumnIndex].Name.ToUpper() == "gasto_tipdoc".ToUpper())
            {
                txtCArti = (TextBox)e.Control;
                txtCArti.MaxLength = 2;
                txtCArti.CharacterCasing = CharacterCasing.Upper;
                txtCArti.Text.Trim();
                e.Control.KeyDown += VariablesPublicas.CapturarTeclaGRID;
            }
            if (gridgastos.Columns[gridgastos.CurrentCell.ColumnIndex].Name.ToUpper() == "gasto_numdoc".ToUpper())
            {
                txtCArti = (TextBox)e.Control;
                txtCArti.MaxLength = 10;
                txtCArti.CharacterCasing = CharacterCasing.Upper;
                txtCArti.Text.Trim();
                e.Control.KeyDown += VariablesPublicas.CapturarTeclaGRID;
            }
            if (gridgastos.Columns[gridgastos.CurrentCell.ColumnIndex].Name.ToUpper() == "gasto_cencosid".ToUpper())
            {
                txtCArti = (TextBox)e.Control;
                txtCArti.MaxLength = 5;
                txtCArti.CharacterCasing = CharacterCasing.Upper;
                txtCArti.Text.Trim();
                e.Control.KeyDown += VariablesPublicas.CapturarTeclaGRID;
            }
            _NameColumna = gridgastos.Columns[gridgastos.CurrentCell.ColumnIndex].Name.ToUpper();
        }
        private void gridgastos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (gridgastos.Columns[gridgastos.CurrentCell.ColumnIndex].Name.ToUpper() == "gasto_numdoc".ToUpper())
                {
                    adicionagastoadicional();
                }
            }

            if (e.KeyCode == Keys.F1)
            {
                if ((gridgastos.CurrentCell != null))
                {
                    if (gridgastos.CurrentCell.ReadOnly == false)
                    {
                        if (gridgastos.Columns[gridgastos.CurrentCell.ColumnIndex].Name.ToUpper() == "gasto_cuentaid".ToUpper())
                        {
                            AyudaCuentaGastoAdicional();
                        }
                        if (gridgastos.Columns[gridgastos.CurrentCell.ColumnIndex].Name.ToUpper() == "gasto_tipdoc".ToUpper())
                        {
                            AyudaTipoDocumento();
                        }
                        if (gridgastos.Columns[gridgastos.CurrentCell.ColumnIndex].Name.ToUpper() == "gasto_cencosid".ToUpper())
                        {
                            AyudaCentroCosto();
                        }
                    }
                }
            }
        }
        private void gridgastos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (VariablesPublicas.PulsaAyudaArticulos)
            {
                if (_NameColumna.ToUpper() == "gasto_cuentaid".ToUpper())
                {
                    AyudaCuentaGastoAdicional();
                }
                if (_NameColumna.ToUpper() == "gasto_tipdoc".ToUpper())
                {
                    AyudaTipoDocumento();
                }
                if (_NameColumna.ToUpper() == "gasto_cencosid".ToUpper())
                {
                    AyudaCentroCosto();
                }
            }
            VariablesPublicas.PulsaAyudaArticulos = false;
            if ((gridgastos.CurrentCell != null) & 1 == 0)
            {
                int nfila = gridgastos.CurrentCell.RowIndex;
                int ncolumna = gridgastos.CurrentCell.ColumnIndex;
                TabCac3p00GastosAdic.AcceptChanges();
                try
                {
                    gridgastos.CurrentCell = gridgastos.Rows[nfila].Cells[ncolumna];
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "BapSoft");
                }
            }
        }

        private void totalizar()
        {
            int lcont = 0;
            decimal vmdebesoles = 0;
            decimal vmdebedolares = 0;
            decimal vmhabersoles = 0;
            decimal vmhaberdolares = 0;
            //decimal vmtotal = 0;
            if ((TabCac3p00GastosAdic != null))
            {
                sw_novaluechange = true;
                for (lcont = 0; lcont <= TabCac3p00GastosAdic.Rows.Count - 1; lcont++)
                {
                    if (object.ReferenceEquals(TabCac3p00GastosAdic.Rows[lcont]["importe"], DBNull.Value))
                    {
                        TabCac3p00GastosAdic.Rows[lcont]["importe"] = 0;
                    }
                    if (object.ReferenceEquals(TabCac3p00GastosAdic.Rows[lcont]["importecambio"], DBNull.Value))
                    {
                        TabCac3p00GastosAdic.Rows[lcont]["importecambio"] = 0;
                    }
                    if (object.ReferenceEquals(TabCac3p00GastosAdic.Rows[lcont]["moneda"], DBNull.Value))
                    {
                        TabCac3p00GastosAdic.Rows[lcont]["moneda"] = cboMoneda.SelectedValue.ToString();
                    }

                    if (TabCac3p00GastosAdic.Rows[lcont]["moneda"].ToString() == VariablesPublicas.MonedaCodSoles)
                    {
                        vmdebesoles += (TabCac3p00GastosAdic.Rows[lcont]["debehaber"].ToString() == VariablesPublicas.ContabilidadIdCargo ? Convert.ToDecimal(TabCac3p00GastosAdic.Rows[lcont]["Importe"]) : 0);
                        vmdebedolares += (TabCac3p00GastosAdic.Rows[lcont]["debehaber"].ToString() == VariablesPublicas.ContabilidadIdCargo ? Convert.ToDecimal(TabCac3p00GastosAdic.Rows[lcont]["ImporteCambio"]) : 0);
                        vmhabersoles += (TabCac3p00GastosAdic.Rows[lcont]["debehaber"].ToString() == VariablesPublicas.ContabilidadIdAbono ? Convert.ToDecimal(TabCac3p00GastosAdic.Rows[lcont]["Importe"]) : 0);
                        vmhaberdolares += (TabCac3p00GastosAdic.Rows[lcont]["debehaber"].ToString() == VariablesPublicas.ContabilidadIdAbono ? Convert.ToDecimal(TabCac3p00GastosAdic.Rows[lcont]["ImporteCambio"]) : 0);
                    }
                    else
                    {
                        vmdebesoles += (TabCac3p00GastosAdic.Rows[lcont]["debehaber"].ToString() == VariablesPublicas.ContabilidadIdCargo ? Convert.ToDecimal(TabCac3p00GastosAdic.Rows[lcont]["ImporteCambio"]) : 0);
                        vmdebedolares += (TabCac3p00GastosAdic.Rows[lcont]["debehaber"].ToString() == VariablesPublicas.ContabilidadIdCargo ? Convert.ToDecimal(TabCac3p00GastosAdic.Rows[lcont]["Importe"]) : 0);
                        vmhabersoles += (TabCac3p00GastosAdic.Rows[lcont]["debehaber"].ToString() == VariablesPublicas.ContabilidadIdAbono ? Convert.ToDecimal(TabCac3p00GastosAdic.Rows[lcont]["ImporteCambio"]) : 0);
                        vmhaberdolares += (TabCac3p00GastosAdic.Rows[lcont]["debehaber"].ToString() == VariablesPublicas.ContabilidadIdAbono ? Convert.ToDecimal(TabCac3p00GastosAdic.Rows[lcont]["Importe"]) : 0);
                    }
                }
                txttotaldebesoles.Text = vmdebesoles.ToString("###,###,###.00");
                txttotaldebedolares.Text = vmdebedolares.ToString("###,###,###.00");

                txttotalhabersoles.Text = vmhabersoles.ToString("###,###,###.00");
                txttotalhaberdolares.Text = vmhaberdolares.ToString("###,###,###.00");
                sw_novaluechange = false;
            }
        }

        private void totalizarItem()
        {
            decimal vmimportecambio = 0;
            decimal vmtcambio = Convert.ToDecimal(txtTipCamb.Text);
            sw_novaluechange = false;
            if (object.ReferenceEquals(gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["Importe"].Value, DBNull.Value))
            {
                gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["Importe"].Value = 0;
            }
            if (object.ReferenceEquals(gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_moneda"].Value, DBNull.Value))
            {
                gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_moneda"].Value = (rbSoles.Checked ? "1" : "2");
            }
            if (gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_moneda"].Value.ToString() == VariablesPublicas.MonedaCodSoles)
            {
                if (vmtcambio == 0)
                {
                    vmimportecambio = 0;
                }
                else
                {
                    vmimportecambio = Math.Round(Convert.ToDecimal(gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["importe"].Value) / vmtcambio, 2);
                }
            }
            if (gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_moneda"].Value.ToString() == VariablesPublicas.MonedaCodDolares)
            {
                vmimportecambio = Math.Round((vmtcambio == 0 ? 0 : Convert.ToDecimal(gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["importe"].Value) * vmtcambio), 2);
            }
            gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["importecambio"].Value = vmimportecambio;
            totalizar();
            gridgastos.Refresh();
        }
        public void validacuentaGastoAdicional()
        {
            sw_novaluechange = true;
            Int16 lc_cont = default(Int16);
            bool zhallado = false;
            string VMNROITEM = gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["asientoitems"].Value.ToString();
            string xcodartic = "..";
            if ((!object.ReferenceEquals(gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_cuentaid"].Value, DBNull.Value)))
            {
                xcodartic = gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_cuentaid"].Value.ToString();
            }
            if (xcodartic.Trim().Length == 0)
            {
                gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_cuentaid"].Value = "";
                gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_cuentaname"].Value = "";
                zhallado = true;
            }
            else
            {
                tb_co_plancontableBL BL = new tb_co_plancontableBL();
                tb_co_plancontable BE = new tb_co_plancontable();

                BE.perianio = VariablesPublicas.perianio;
                BE.cuentaid = xcodartic;
                tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                //tmptabla = ocapa.cag0200_consulta(GlobalVars.GetInstance.Company, xcodartic, "", "", "", "", "", 1, GlobalVars.GetInstance.CuentasContablesTodas, "");
                for (lc_cont = 0; lc_cont <= TabCac3p00GastosAdic.Rows.Count - 1; lc_cont++)
                {
                    if (TabCac3p00GastosAdic.Rows[lc_cont]["asientoitems"].ToString() == VMNROITEM)
                    {
                        if (tmptabla.Rows.Count > 0)
                        {
                            TabCac3p00GastosAdic.Rows[lc_cont]["cuentaid"] = tmptabla.Rows[0]["cuentaid"];
                            TabCac3p00GastosAdic.Rows[lc_cont]["cuentaname"] = tmptabla.Rows[0]["cuentaname"];
                            zhallado = true;
                            break;
                        }
                        break;
                    }
                }
            }
            if (!zhallado & xcodartic.Length > 0)
            {
                gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_cuentaid"].Value = j_CuentaContable;
            }
            gridgastos.Refresh();
            sw_novaluechange = false;
        }
        public void AyudaCuentaGastoAdicional()
        {
            Frm_AyudaCuentas frmayuda = new Frm_AyudaCuentas();
            frmayuda.Owner = this;
            frmayuda._CUENTA_MAYOR = "";
            frmayuda._activaCta = true;
            frmayuda.Owner = this;

            frmayuda.PasaCuenta = RecibeCuentaContablegastoAdicional;
            frmayuda.ShowDialog();
        }
        private void RecibeCuentaContablegastoAdicional(string codigo, string descripcion)
        {
            if (codigo.Trim().Length > 0)
            {
                gridgastos.Rows[gridgastos.CurrentCell.RowIndex].Cells["gasto_cuentaid"].Value = codigo;
            }
        }

        private void TabCancelaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!swLoad)
            {
                if (TabCancelaciones.SelectedIndex == 0)
                {
                    if ((examinar.CurrentRow != null))
                    {
                        examinar.CurrentCell = examinar.Rows[examinar.CurrentRow.Index].Cells["numdoc"];
                        examinar.Focus();
                        examinar.BeginEdit(true);
                    }
                }
                if (TabCancelaciones.SelectedIndex == 1)
                {
                    if ((gridgastos.CurrentRow != null))
                    {
                        gridgastos.CurrentCell = gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_cuentaname"];
                        gridgastos.Focus();
                        gridgastos.BeginEdit(true);
                    }
                }
            }
        }

        private void validaTipoDocumento()
        {
            sw_novaluechange = true;
            Int16 lc_cont = default(Int16);
            bool zhallado = false;
            string VMNROITEM = gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["asientoitems"].Value.ToString();
            string xcodartic = "..";
            //me.gas
            if ((!object.ReferenceEquals(gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_tipdoc"].Value, DBNull.Value)))
            {
                xcodartic = gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_tipdoc"].Value.ToString();
            }
            if (xcodartic.Trim().Length == 0)
            {
                TabCac3p00GastosAdic.Rows[gridgastos.CurrentRow.Index]["gasto_tipdoc"] = "";
                zhallado = true;
            }
            else
            {
                xcodartic = VariablesPublicas.PADL(xcodartic, 2, "0");
                tb_co_tabla10_comprobantesBL BL = new tb_co_tabla10_comprobantesBL();
                tb_co_tabla10_comprobantes BE = new tb_co_tabla10_comprobantes();

                BE.codigoid = xcodartic;
                tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                //tmptabla = ocapa.cag3i00_consulta(GlobalVars.GetInstance.Company, xcodartic, "", 1, GlobalVars.GetInstance.TipoDocumentoContableTodos, "", "", "");
                for (lc_cont = 0; lc_cont <= TabCac3p00GastosAdic.Rows.Count - 1; lc_cont++)
                {
                    if (TabCac3p00GastosAdic.Rows[lc_cont]["asientoitems"].ToString() == VMNROITEM)
                    {
                        if (tmptabla.Rows.Count > 0)
                        {
                            TabCac3p00GastosAdic.Rows[lc_cont]["tipdoc"] = tmptabla.Rows[0]["codigoid"];
                            zhallado = true;
                            break;
                        }
                        break;
                    }
                }
            }
            if (!zhallado & xcodartic.Length > 0)
            {
                gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_tipdoc"].Value = j_TipDocGasAdic;
            }
            gridgastos.Refresh();
            sw_novaluechange = false;
        }
        private void AyudaTipoDocumento()
        {
            Frm_AyudaTipoDocumentos frmayuda = new Frm_AyudaTipoDocumentos();
            frmayuda.Owner = this;
            frmayuda.Owner = this;
            string xcodcuenta = "   ";
            if ((!object.ReferenceEquals(gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_cuentaid"].Value, DBNull.Value)))
            {
                xcodcuenta = gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_cuentaid"].Value.ToString();
            }
            if (Equivalencias.Mid(xcodcuenta, 1, 2) == "10")
            {
                //frmayuda._LpTipoDocu = GlobalVars.GetInstance.TipDocusPagos;
            }
            frmayuda._PasaValor = RecibeTipoDocumento;
            frmayuda.ShowDialog();
        }
        private void RecibeTipoDocumento(string codigo, string descripcion)
        {
            if (codigo.Trim().Length > 0)
            {
                gridgastos.Rows[gridgastos.CurrentCell.RowIndex].Cells["gasto_tipdoc"].Value = codigo;
            }
        }
        public void validaSeriedocumento()
        {
            sw_novaluechange = true;
            if (object.ReferenceEquals(gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_serdoc"].Value, DBNull.Value))
            {
                gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_serdoc"].Value = "";
            }
            gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_serdoc"].Value = VariablesPublicas.PADL(gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_serdoc"].Value.ToString(), 4, "0");
            sw_novaluechange = false;
        }
        public void validaNumerodocumento()
        {
            sw_novaluechange = true;
            if (object.ReferenceEquals(gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_numdoc"].Value, DBNull.Value))
            {
                gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_numdoc"].Value = "";
            }
            gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_numdoc"].Value = VariablesPublicas.PADL(gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["Gasto_numdoc"].Value.ToString(), 10, "0");
            //gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["numdoc"].Value = VariablesPublicas.JustificarDocumento(gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["numdoc"].Value.ToString(), 4, 8, true);
            sw_novaluechange = false;
        }

        private void AyudaCentroCosto()
        {
            string xcodcuenta = "";
            if ((examinar.CurrentRow != null))
            {
                xcodcuenta = gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_cuentaid"].Value.ToString();
            }
            Frm_CentrocostoTesoreria frmayuda = new Frm_CentrocostoTesoreria();
            frmayuda._ClaseCuenta = Equivalencias.Mid(xcodcuenta, 1, 2);
            frmayuda.Owner = this;
            frmayuda.Owner = this;
            frmayuda.PasaCCTesoreria = RecibeCcosto;
            frmayuda.ShowDialog();
        }
        private void RecibeCcosto(string codigo, string descripcion)
        {
            if (codigo.Trim().Length > 0)
            {
                gridgastos.Rows[gridgastos.CurrentCell.RowIndex].Cells["gasto_cencosid"].Value = codigo;
            }
        }
        private void validaCentroCosto()
        {
            sw_novaluechange = true;
            Int16 lc_cont = default(Int16);
            bool zhallado = false;
            string xclasecuenta = "";
            string VMNROITEM = gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["asientoitems"].Value.ToString();
            string xcodartic = "..";
            if ((!object.ReferenceEquals(gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_cencosid"].Value, DBNull.Value)))
            {
                xcodartic = gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_cencosid"].Value.ToString();
            }
            if (xcodartic.Trim().Length == 0)
            {
                gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_cencosid"].Value = "";
                zhallado = true;
            }
            else
            {
                if ((!object.ReferenceEquals(gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_cuentaid"].Value, DBNull.Value)))
                {
                    xclasecuenta = Equivalencias.Mid(gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_cuentaid"].Value.ToString(), 1, 2);
                }
                centrocostoBL BL = new centrocostoBL();
                tb_centrocosto BE = new tb_centrocosto();

                BE.cencosid = xcodartic;
                BE.cencosdivi = xclasecuenta;
                tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                //tmptabla = ocapa.pag0101_consulta(GlobalVars.GetInstance.Company, xcodartic, "", 1, 1, "", "", "", xclasecuenta);
                for (lc_cont = 0; lc_cont <= TabCac3p00GastosAdic.Rows.Count - 1; lc_cont++)
                {
                    if (TabCac3p00GastosAdic.Rows[lc_cont]["asientoitems"].ToString() == VMNROITEM)
                    {
                        if (tmptabla.Rows.Count > 0)
                        {
                            TabCac3p00GastosAdic.Rows[lc_cont]["cencosid"] = tmptabla.Rows[0]["cencosid"];
                            zhallado = true;
                            break;
                        }
                    }
                }
            }
            if (!zhallado)
            {
                gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_cencosid"].Value = j_CcostoAdic;
            }
            gridgastos.Refresh();
            sw_novaluechange = false;
        }
        public void ValidaFechaGasto()
        {
            sw_novaluechange = true;
            //bool zhallado = false;
            //string xclasecuenta = "";
            DateTime prvdfecha = default(DateTime);
            string VMNROITEM = gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["asientoitems"].Value.ToString();
            string xcodartic = "..";
            if ((!object.ReferenceEquals(gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_fechdoc"].Value, DBNull.Value)))
            {
                xcodartic = gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_fechdoc"].Value.ToString();
            }
            if (xcodartic.Trim().Length > 0)
            {
                try
                {
                    prvdfecha = Convert.ToDateTime(xcodartic);
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    xcodartic = "";
                }
                if (xcodartic.Trim().Length == 0)
                {
                    gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_fechdoc"].Value = prvdfecha;
                    //gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_fechdoc"].Value = "";
                    //gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_fref_3a"].Value = DBNull.Value;
                }
                else
                {
                    gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_fechdoc"].Value = xcodartic;
                    //gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_fref_3a"].Value = prvdfecha;
                }
            }
            else
            {
                //gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_fref_3a"].Value = DBNull.Value;
            }
            gridgastos.Refresh();
            sw_novaluechange = false;
        }

        private void rbAnalisis1_CheckedChanged(object sender, EventArgs e)
        {
            if (!swLoad)
            {
                U_GeneraPendientes();
            }
        }

        private void rbAnalisis2_CheckedChanged(object sender, EventArgs e)
        {
            if (!swLoad)
            {
                U_GeneraPendientes();
            }
        }

        public bool PuedeEditarEliminar(string glosamensaje, string codmes)
        {
            bool zpuede = true;
            tb_co_cierremensualesBL BL = new tb_co_cierremensualesBL();
            tb_co_cierremensuales BE = new tb_co_cierremensuales();

            BE.periano = VariablesPublicas.perianio;
            BE.moduloid = VariablesPublicas.tipocierremensualcontable;
            BE.perimes = codmes;
            tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

            //tmptabla = ocapa.Getall_CierreMensual(GlobalVars.GetInstance.Company, GlobalVars.GetInstance.Periodo, GlobalVars.GetInstance.tipocierremensualcontable, codmes);
            //if (ocapa.sql_error.Length > 0)
            //{
            //    zpuede = false;
            //    ERP_CAESOFT_FORMS.frmclass.ShowError(ocapa.sql_error, this);
            //}
            //else
            //{
            if (tmptabla.Rows.Count > 0)
            {
                if (!(Convert.ToBoolean(tmptabla.Rows[0]["status"]) == false))
                {
                    XtraMessageBox.Show("Mes Cerrado ...Imposible " + glosamensaje.Trim(), "Mensaje delSistema", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    zpuede = false;
                }
            }
            else
            {
                zpuede = false;
            }
            //}
            return zpuede;
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            // Si el control tiene el foco...
            if (keyData == Keys.Enter & !examinar.Focused & !btnSalir.Focused & !btnSeleccionarproveedores.Focused & !btnGenerarPendientes.Focused)
            {
                if (gridgastos.Focused)
                {
                    if (!(gridgastos.Columns[gridgastos.CurrentCell.ColumnIndex].Name.ToUpper() == "NDOC_3A"))
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

        private void examinar_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

        }
    }
}
