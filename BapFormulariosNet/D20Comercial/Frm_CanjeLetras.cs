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
using BapFormulariosNet.D20Comercial.Ayudas;
using BapFormulariosNet.Ayudas;
using DevExpress.XtraEditors;

namespace BapFormulariosNet.D20Comercial
{
    public partial class Frm_CanjeLetras : plantilla
    {
        // Variables
        private TextBox txtCArti = null;
        DataTable tablavariasletras = new DataTable();
        bool sw_novaluechange = false;
        //string j_codbanco = "";
        string j_TipDocGasAdic = "";
        string UltimoNumVoucher = "";
        //string UltimoMesVoucher = "";
        //string UltimoTipoVoucher = "";
        bool swLoad = true;
        string j_CuentaContable = "";
        string j_Detalle = "";
        string J_codh_3a = "";
        string _NameCOlumna = "";
        string j_ruc = "";
        //string j_nombre = "";
        string j_CuentaLetra = "";
        string j_Cuenta = "";
        string j_Ncambio = "";
        string j_SiglaSubDiario = "";
        string j_nvalorapagar = "";
        string j_nmonedadetalle = "";
        string j_CcostoAdic = "";
        int nContador = 0;
        DataTable tmptabla = new DataTable();
        DataTable DocumentosPendientes = new DataTable();
        DataTable TablaDetallesaSeleccionar = new DataTable();
        DataTable TabCac3p00GastosAdic = new DataTable();
        DataTable DetFacturacion = new DataTable();
        //string j_codPago = "";
        string xctacte = "";
        string xNumLetra = "";
        decimal sumadebesoles = 0;
        decimal sumahabersoles = 0;
        decimal sumadebedolares = 0;
        decimal sumahaberdolares = 0;
        public string nAsiento = "";

        public Frm_CanjeLetras()
        {
            InitializeComponent();

            txtCodsubdiario.LostFocus += new System.EventHandler(txtCodsubdiario_LostFocus);
            txtCodsubdiario.GotFocus += new System.EventHandler(txtCodsubdiario_GotFocus);

            txtRuc.LostFocus += new System.EventHandler(txtRuc_LostFocus);
            txtRuc.GotFocus += new System.EventHandler(txtRuc_GotFocus);

            txtCuenta.LostFocus += new System.EventHandler(txtCuenta_LostFocus);
            txtCuenta.GotFocus += new System.EventHandler(txtCuenta_GotFocus);

            txtCambio.LostFocus += new System.EventHandler(txtCambio_LostFocus);
            txtCambio.GotFocus += new System.EventHandler(txtCambio_GotFocus);
            
            txtCuentaletra.LostFocus += new System.EventHandler(txtCuentaletra_LostFocus);
            txtCuentaletra.GotFocus += new System.EventHandler(txtCuentaletra_GotFocus);

            txtNumpago.LostFocus += new System.EventHandler(txtNumpago_LostFocus);
            txtSerie.LostFocus += new System.EventHandler(txtSerie_LostFocus);

            txtmontoapagar.LostFocus += new System.EventHandler(txtmontoapagar_LostFocus);
            txtmontoapagar.GotFocus += new System.EventHandler(txtmontoapagar_GotFocus);

            cboModalidad.SelectedIndex = 0;

            tablavariasletras = null;
            TabCac3p00GastosAdic = null;
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
        #endregion

        private void Frm_CanjeLetras_Activated(object sender, EventArgs e)
        {
            if (swLoad)
            {
                llenar_cboMoneda();
                llenar_cboFormapago();

                swLoad = false;
                //tmptabla = ocapa.CaeSoft_GetallFormaPagoContabilidad("011", 1, 0, "", "", "", GlobalVars.GetInstance.Company);
                cboFpago.SelectedValue = "011"; 
                //TabCac3p00GastosAdic = ocapa.cac3p00_consulta("xx", "xx", "", "", "", "", "");
                InicializarTabla();
                //try
                //{
                //    tb_co_MovimientosdetBL BL = new tb_co_MovimientosdetBL();
                //    tb_co_Movimientosdet BE = new tb_co_Movimientosdet();

                //    BE.perianio = VariablesPublicas.perianio;
                //    BE.perimes = "xx";
                //    BE.diarioid = "xx";
                //    BE.asiento = "xx";
                
                //    TabCac3p00GastosAdic = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                //}
                //catch (Exception ex)
                //{
                //    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //tablavariasletras = TabCac3p00GastosAdic.Clone();
                //gridgastos.AutoGenerateColumns = false;
                //gridgastos.DataSource = TabCac3p00GastosAdic;
                //if (BL.Sql_Error.Length == 0)
                //{
                try
                {
                    tb_co_tipodiarioBL BL = new tb_co_tipodiarioBL();
                    tb_co_tipodiario BE = new tb_co_tipodiario();

                    BE.perianio = VariablesPublicas.perianio;
                    BE.canjeletra = true;
                    //BE.diarioid = "0503";

                    tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (tmptabla.Rows.Count > 0)
                    {
                        //txtCodpago.Text = tmptabla.Rows[0]["codigo"].ToString();
                        //txtDpago.Text = tmptabla.Rows[0]["descripcion"].ToString();
                        //cboFpago.SelectedValue = tmptabla.Rows[0]["codigo"].ToString();

                        //tmptabla = ocapa.CaeSoft_GetAllDocumentosContabilidad(GlobalVars.GetInstance.Company, "548", "", 2, GlobalVars.GetInstance.TipoDocumentoContableTesoreriaContabilidad, "", "", "");
                        //if (ocapa.sql_error.Length == 0)
                        //{
                            if (tmptabla.Rows.Count > 0)
                            {
                                txtSiglasubdiario.Text = tmptabla.Rows[0]["sigla"].ToString().Trim();
                                txtCodsubdiario.Text = tmptabla.Rows[0]["diarioid"].ToString();
                                txtDsubdiario.Text = tmptabla.Rows[0]["diarioname"].ToString();
                                txtDsubdiario.Text = txtDsubdiario.Text.Trim();
                                txtCuentaletra.Text = tmptabla.Rows[0]["cuentaid"].ToString().Trim();
                                txtDcuentaletra.Text = tmptabla.Rows[0]["cuentaname"].ToString().Trim();
                            }
                        //}
                    }
                //}
                actualizatipocambio();
                txtRuc.Focus();
            }
        }
        private void Frm_CanjeLetras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (!examinar.IsCurrentCellInEditMode)
                {
                    btnSalir_Click(sender, e);
                }
            }
        }
        private void Frm_CanjeLetras_Load(object sender, EventArgs e)
        {
            u_RefrescaControles();
            VariablesPublicas.PintaEncabezados(examinar);
        }

        private void InicializarTabla()
        {
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
            tablavariasletras = TabCac3p00GastosAdic.Clone();
            gridgastos.AutoGenerateColumns = false;
            gridgastos.DataSource = TabCac3p00GastosAdic;
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
                grpbotonesvoucher.Enabled = false;
                GenerarInfo();
                btnGenerarPendientes.Enabled = true;
                grpbotonesvoucher.Enabled = true;
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

        private void txtSerie_LostFocus(object sender, System.EventArgs e)
        {
            if (!swLoad)
            {
                if (txtSerie.Text.Trim().Length > 0)
                {
                    txtSerie.Text = VariablesPublicas.PADL(txtSerie.Text.Trim(), 4, "0");
                }
            }
        }
        private void txtNumpago_LostFocus(object sender, System.EventArgs e)
        {
            if (!swLoad)
            {
                if (txtNumpago.Text.Trim().Length > 0)
                {
                    txtNumpago.Text = VariablesPublicas.PADL(txtNumpago.Text.Trim(), 10, "0");
                }
            }
        }
        private void GenerarInfo()
        {
            string xcoddetalle = "";
            string xcuenta = "";
            dynamic nmodoanalisis = VariablesPublicas.CtaCteCUEDETTIPNUMPEDOPCCOSTo;
            if (rbAnalisis2.Checked)
            {
                nmodoanalisis = VariablesPublicas.CtaCteCUEDETTIPNUM;
            }
            if (txtCuenta.Enabled)
            {
                xcuenta = txtCuenta.Text;
            }
            if (txtRuc.Enabled)
            {
                xcoddetalle = txtRuc.Text;
            }

            examinar.DataSource = null;
            if (rbMultiplesdetalles.Checked)
            {
                xcoddetalle = "";
                //DocumentosPendientes = ocapa.spu_cuentacorriente(GlobalVars.GetInstance.Company, GlobalVars.GetInstance.Periodo, "", xcuenta, xcuenta, xcoddetalle, "", "", 3, 0,
                //GlobalVars.GetInstance.CuentaCorrientecac3p00, "", "", TablaDetallesaSeleccionar, GlobalVars.GetInstance.RelCuentasCancelacionesCobranzas, "", 0, nmodoanalisis, "");
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
                //GlobalVars.GetInstance.CuentaCorrientecac3p00, "", "", null, GlobalVars.GetInstance.RelCuentasCancelacionesCobranzas, "", 0, nmodoanalisis, "");
            }

            //if (BL.Sql_Error.Length > 0)
            //{
            //    Frm_Class.ShowError(BL.Sql_Error, this);
            //    return;
            //}
            examinar.AutoGenerateColumns = false;
            examinar.DataSource = DocumentosPendientes;
            txtGlosa.Text = "CANJE DE FACTURAS POR LETRAS";
            txtSerie.Text = "LT01";
            u_RefrescaControles();
            Sumatoria();
        }

        public void u_RefrescaControles()
        {
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
            txtDcuentaletra.Enabled = false;
            txtCuenta.Enabled = chkCuenta.Checked;
            txtRuc.Enabled = rbDetalle.Checked;
            btnSeleccionarproveedores.Enabled = rbMultiplesdetalles.Checked;
            txtCambio.Enabled = false;
            txtCodsubdiario.Enabled = true;
            txtDsubdiario.Enabled = false;
            cboFpago.Enabled = false;
            txtCambio.Enabled = true;
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
            btnVariasletras.Enabled = rbVariasletras.Checked;
            txtSerie.Enabled = rbUnaletra.Checked;
            txtNumpago.Enabled = rbUnaletra.Checked;
            fechaVenc.Enabled = rbUnaletra.Checked;
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
                    #region Cuando se selecciona pinta cantidades a pagar
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
                                case 0: //Sin Detraccion ni Retención
                                    examinar.Rows[LC_CONT].Cells["pagosoles"].Value = Math.Round((lselecciona ? Math.Round(Convert.ToDecimal(examinar.Rows[LC_CONT].Cells["saldo1"].Value), 2) : 0),2);
                                    examinar.Rows[LC_CONT].Cells["pagodolares"].Value =  Math.Round((lselecciona ? Math.Round(Convert.ToDecimal(examinar.Rows[LC_CONT].Cells["saldo2"].Value), 2) : 0),2);
                                    DocumentosPendientes.Rows[LC_CONT]["pagosoles"] = Math.Round(Convert.ToDecimal(DocumentosPendientes.Rows[LC_CONT]["pagosoles"]), 2);
                                    DocumentosPendientes.Rows[LC_CONT]["pagodolares"] = Math.Round(Convert.ToDecimal(DocumentosPendientes.Rows[LC_CONT]["pagodolares"]), 2);
                                    break;
                                case 1: //Menos Detraccion
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
                                case 2: //Menos Retención
                                    _porcretencion = TasaRretencion(Convert.ToDateTime(examinar.Rows[LC_CONT].Cells["fechdoc"].Value));
                                    examinar.Rows[LC_CONT].Cells["pagosoles"].Value =  Math.Round(Convert.ToDecimal(examinar.Rows[LC_CONT].Cells["original1"].Value) - Math.Round(Convert.ToDecimal(examinar.Rows[LC_CONT].Cells["original1"].Value) * _porcretencion / 100, 2),2);
                                    examinar.Rows[LC_CONT].Cells["pagodolares"].Value =  Math.Round(Convert.ToDecimal(examinar.Rows[LC_CONT].Cells["original2"].Value) - Math.Round(Convert.ToDecimal(examinar.Rows[LC_CONT].Cells["original2"].Value) * _porcretencion / 100, 2),2);
                                    DocumentosPendientes.Rows[LC_CONT]["pagosoles"] = Math.Round(Convert.ToDecimal(DocumentosPendientes.Rows[LC_CONT]["pagosoles"]), 2);
                                    DocumentosPendientes.Rows[LC_CONT]["pagodolares"] = Math.Round(Convert.ToDecimal(DocumentosPendientes.Rows[LC_CONT]["pagodolares"]), 2);
                                    break;
                            }
                        }
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

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            // Si el control tiene el foco...
            if (keyData == Keys.Enter & !examinar.Focused & !btnSalir.Focused & !btnSeleccionarproveedores.Focused & !btnGenerarPendientes.Focused)
            {
                if (gridgastos.Focused)
                {
                    if (!(gridgastos.Columns[gridgastos.CurrentCell.ColumnIndex].Name.ToUpper() == "gasto_numdoc"))
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

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
                    xctacte = tmptabla.Rows[lc_cont]["ctacte"].ToString();
                    txtRuc.Text = tmptabla.Rows[lc_cont]["nmruc"].ToString();
                    txtCtactename.Text = tmptabla.Rows[lc_cont]["ctactename"].ToString().Trim();
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
        private void txtCuenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaCuenta();
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
                validacuenta();
            }
        }
        private void validacuenta()
        {
            sw_novaluechange = true;
            bool zhallado = false;
            string xcodartic = txtCuenta.Text;
            if (xcodartic.Trim().Length == 0)
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
                BE.cuentaid = xcodartic;
                tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (tmptabla.Rows.Count > 0)
                {
                    txtCuenta.Text = tmptabla.Rows[0]["cuentaid"].ToString();
                    txtCuentaname.Text = tmptabla.Rows[0]["cuentaname"].ToString();
                    zhallado = true;
                }
                if (!zhallado & xcodartic.Length > 0)
                {
                    txtCuenta.Text = j_Cuenta;
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
                    txtglosacampo.Text = "[1] SOLES [2] DOLARES";
                }
                txtconcepto.Text = examinar.Rows[examinar.CurrentRow.Index].Cells["glosa"].Value.ToString();
                txtnomdetalle.Text = examinar.Rows[examinar.CurrentRow.Index].Cells["ctactename"].Value.ToString();
                u_RefrescaControles();
            }
        }

        private void txtCodsubdiario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaSiglaSubDiario();
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
        public void AyudaSiglaSubDiario()
        {
            Frm_AyudaTipoSubdiario frmAyuda = new Frm_AyudaTipoSubdiario();
            frmAyuda._VerTipoVoucher = false;
            frmAyuda._tesor = false;
            frmAyuda._conta = false;
            frmAyuda._letras = true;
            
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
            sw_novaluechange = true;
            xcodigo = txtCodsubdiario.Text;
            if (xcodigo.Trim().Length > 0)
            {
                //tmptabla = ocapa.CaeSoft_GetAllDocumentosContabilidad(GlobalVars.GetInstance.Company, "", xcodigo, 1, GlobalVars.GetInstance.TipoDocumentoContableTodos, "", "", "");
                try
                {
                    tb_co_tipodiarioBL BL = new tb_co_tipodiarioBL();
                    tb_co_tipodiario BE = new tb_co_tipodiario();

                    BE.perianio = VariablesPublicas.perianio;
                    BE.canjeletra = true;
                    BE.diarioid = xcodigo;

                    tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                    if (BL.Sql_Error.Length == 0)
                    {
                        if (tmptabla.Rows.Count > 0)
                        {
                            txtSiglasubdiario.Text = tmptabla.Rows[0]["sigla"].ToString();
                            txtCodsubdiario.Text = tmptabla.Rows[0]["diarioid"].ToString();
                            txtDsubdiario.Text = tmptabla.Rows[0]["diarioname"].ToString();
                            txtDsubdiario.Text = txtDsubdiario.Text.Trim();
                            txtCuentaletra.Text = tmptabla.Rows[0]["cuentaid"].ToString().Trim();
                            txtDcuentaletra.Text = tmptabla.Rows[0]["cuentaname"].ToString().Trim();
                            if (txtDsubdiario.Text.IndexOf(" MN") > 0)
                            {
                                rbSoles.Checked = true;
                                rbDolares.Checked = false;
                            }
                            else
                            {
                                rbSoles.Checked = false;
                                rbDolares.Checked = true;
                            }
                        }
                        else
                        {
                            txtCodsubdiario.Text = j_SiglaSubDiario;
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                txtCodsubdiario.Text = j_SiglaSubDiario;
            }
            sw_novaluechange = false;
        }
        
        private void actualizatipocambio()
        {
            //string fecha = null;
            //fecha = Strings.Mid(femision.Text, 7, 4) + Strings.Mid(femision.Text, 4, 2) + Strings.Mid(femision.Text, 1, 2);
            //DataTable tcambio = new DataTable();
            //tcambio = ocapa.fa23i00_consulta(fecha, "", "", GlobalVars.GetInstance.Company);
            //if (tcambio.Rows.Count > 0)
            //{
            //    if (tcambio.Rows[0]["tcam_23i"] > tcambio.Rows[0]["tcamv_23i"])
            //    {
            //        txtcambio.Text = tcambio.Rows[0]["tcam_23i"];
            //    }
            //    else
            //    {
            //        txtcambio.Text = tcambio.Rows[0]["tcamv_23i"];
            //    }
            //}
            //else
            //{
            //    txtcambio.Text = "";
            //}
            tipocambioBL BL = new tipocambioBL();
            tb_tipocambio BE = new tb_tipocambio();

            BE.anio = Convert.ToInt16(VariablesPublicas.perianio.ToString());
            BE.fecha = Convert.ToDateTime(fEmision.Text);

            DataTable tcambio = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

            if (tcambio.Rows.Count > 0)
            {
                if (Convert.ToDecimal(tcambio.Rows[0]["compra"]) > Convert.ToDecimal(tcambio.Rows[0]["venta"]))
                {
                    txtCambio.Text = tcambio.Rows[0]["compra"].ToString();
                }
                else
                {
                    txtCambio.Text = tcambio.Rows[0]["venta"].ToString();
                }
            }
            else
            {
                txtCambio.Text = "0.0000";
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
            j_Ncambio = txtCambio.Text;
        }
        private void txtCambio_LostFocus(System.Object sender, System.EventArgs e)
        {
            if (!(j_Ncambio == txtCambio.Text) & !swLoad)
            {
                decimal ncambio = VariablesPublicas.StringtoDecimal(txtCambio.Text);
                txtCambio.Text = ncambio.ToString("##.0000");
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
                    examinar.Rows[examinar.CurrentRow.Index].Cells["pagosoles"].Value =  Math.Round(Convert.ToDecimal(examinar.Rows[examinar.CurrentRow.Index].Cells["pagodolares"].Value) * vmtcambio,2);
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
                    examinar.Rows[examinar.CurrentRow.Index].Cells["pagodolares"].Value =  Math.Round(Convert.ToDecimal(examinar.Rows[examinar.CurrentRow.Index].Cells["pagosoles"].Value) / vmtcambio,2);
                }
                else
                {
                    examinar.Rows[examinar.CurrentRow.Index].Cells["pagodolares"].Value = 0;
                }
            }
            Sumatoria();
            sw_novaluechange = false;
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
            }
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
                if (XtraMessageBox.Show("Desea Generar Voucher de Canje...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    generaVoucherTesoreria();
                    tablavariasletras = null;
                    TabCac3p00GastosAdic = null;
                    InicializarTabla();
                }
            }
        }
        public bool Validacion()
        {
            string xmsg = "";
            decimal ntotmarcados = VariablesPublicas.StringtoDecimal(lbltotregistros.Text);
            string xcodigo = ".";
            decimal vmnpagosoles = 0;
            decimal vmnpagodolares = 0;
            int ncontador = 0;
            decimal vmncambio = VariablesPublicas.StringtoDecimal(txtCambio.Text);
            if (ntotmarcados == 0)
            {
                xmsg = "Seleccione al menos 1 documento a cancelar ...?";
            }
            else
            {
                vmnpagosoles = VariablesPublicas.StringtoDecimal(lbltotalpagosoles.Text);
                vmnpagodolares = VariablesPublicas.StringtoDecimal(lbltotalpagodolares.Text);
                if (vmnpagosoles == 0 & vmnpagodolares == 0)
                {
                    xmsg = "Digite montos a cancelar ...?";
                }
                else
                {
                    if (txtCodsubdiario.Text.Trim().Length > 0)
                    {
                        xcodigo = txtCodsubdiario.Text;
                    }
                    try
                    {
                        tb_co_tipodiarioBL BL = new tb_co_tipodiarioBL();
                        tb_co_tipodiario BE = new tb_co_tipodiario();

                        BE.perianio = VariablesPublicas.perianio;
                        BE.diarioid = xcodigo;

                        tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                        if (BL.Sql_Error.Length > 0)
                        {
                            xmsg = BL.Sql_Error;
                        }
                        else
                        {
                            if (tmptabla.Rows.Count == 0)
                            {
                                xmsg = "Ingrese Sub-Diario ...?";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //tmptabla = ocapa.CaeSoft_GetAllDocumentosContabilidad(GlobalVars.GetInstance.Company, "", xcodigo, 1, GlobalVars.GetInstance.TipoDocumentoContableTesoreriaContabilidad, "", "", "");                   
                }
            }
            if (vmncambio == 0)
            {
                xmsg = "Ingrese tipo de cambio  ...?";
                txtCambio.Focus();
            }
            if (txtCuentaletra.Text.Trim().Length == 0)
            {
                xmsg = "Ingrese Cuenta Contable asociada a la Letra  ...?";
                txtCuentaletra.Focus();
            }
            if (rbUnaletra.Checked)
            {
                if (txtNumpago.Text.Trim().Length == 0)
                {
                    xmsg = "Ingrese Número de la Letra de Cambio ...?";
                    txtNumpago.Focus();
                }
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
            if (xmsg.Length > 0)
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
            actulizarCursor();

            decimal vmtcambio = VariablesPublicas.StringtoDecimal(txtCambio.Text);

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
            BE.cuentaid = txtCuentaletra.Text;

            //Puede ser null
            if (cboFpago.Text.Length > 0)
            { BE.mediopago = cboFpago.SelectedValue.ToString(); }
            else
            { BE.mediopago = ""; }

            BE.numdocpago = txtNumpago.Text;
            //Puede ser null
            //if (cboBanco.Text.Length > 0)
            //{ BE.bancoid = cboBanco.SelectedValue.ToString(); }
            //else
            //{ BE.bancoid = ""; }
            BE.bancoid = "";
            BE.fechregistro = Convert.ToDateTime(fEmision.Text.Trim());
            BE.fechdoc = Convert.ToDateTime(fEmision.Text.Trim());
            BE.tipcamuso = "V";
            BE.tipcamb = Convert.ToDecimal(txtCambio.Text.Trim());
            BE.glosa = txtGlosa.Text;
            BE.moneda = (rbDolares.Checked ? "2" : "1");
            //Puede ser null
            //if (cboFefectivo.Text.Length > 0)
            //{ BE.flujoefectivo = cboFefectivo.SelectedValue.ToString(); }
            //else
            //{ BE.flujoefectivo = ""; }
            BE.flujoefectivo = "";
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
                Detalle.fechregistro = Convert.ToDateTime(BE.fechregistro);

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
                    Detalle.tipcamb = Convert.ToDecimal(txtCambio.Text.Trim());
                }

                Detalle.tipcambuso = BE.tipcamuso;

                try { Detalle.tipcambfech = Convert.ToDateTime(fila["tipcambfech"].ToString()); }
                catch { Detalle.tipcambfech = Convert.ToDateTime(fEmision.Text.Trim()); }

                Detalle.afectoretencion = false;
                Detalle.afectopercepcion = false;
                Detalle.percepcionid = fila["percepcionid"].ToString();
                Detalle.serperc = fila["serperc"].ToString();
                Detalle.numperc = fila["numperc"].ToString();
                Detalle.numdocpago = (rbUnaletra.Checked ? txtNumpago.Text : xNumLetra);
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
            //    frmclass.ShowError(ocapa.sql_error, this);
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
                    //seguridadlog();
                    //// Impresion
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
        private void seguridadlog()
        {
            string xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio + "/" + txtCodsubdiario.Text + "/" + VariablesPublicas.PADL(fEmision.Value.Month.ToString().Trim(), 2, "0") + "-" + nAsiento;
            try
            {
                tb_co_seguridadlogBL BL = new tb_co_seguridadlogBL();
                tb_co_seguridadlog BE = new tb_co_seguridadlog();

                BE.moduloid = "Frm_Registro_Contabilidad";
                BE.clave = xclave;
                BE.cuser = VariablesPublicas.Usuar;
                BE.fecha = DateTime.Now;
                BE.pc = VariablesPublicas.userip;
                BE.accion = "N";
                BE.detalle = txtGlosa.Text;

                BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                UltimoNumVoucher = (Convert.ToDecimal(nAsiento) - 1).ToString();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void actulizarCursor()
        {
            DataRow orow = null;
            //DataTable cursortipvoucher = new DataTable();
            //cursortipvoucher = ocapa.cag3i00_consulta(GlobalVars.GetInstance.Company, txtcodsubdiario.Text, "", 1, GlobalVars.GetInstance.TipoDocumentoContableTodos, "", "", "");
            //if (ocapa.sql_error.Length > 0)
            //{
            //    frmclass.ShowError(ocapa.sql_error, this);
            //    return;
            //}
            //if (cursortipvoucher.Rows.Count == 0)
            //{
            //    Interaction.MsgBox("Problemas al hallar tipo de voucher", 64, "");
            //    return;
            //}
            
            //DataTable cursorformaspagos = new DataTable();
            //cursorformaspagos = ocapa.CaeSoft_GetallFormaPagoContabilidad(txtcodpago.Text, 1, 0, "", "", "", GlobalVars.GetInstance.Company);
            //if (ocapa.sql_error.Length > 0)
            //{
            //    frmclass.ShowError(ocapa.sql_error, this);
            //    return;
            //}
            //if (cursorformaspagos.Rows.Count == 0)
            //{
            //    return;
            //}

            int nfila = 0;
            for (nfila = 0; nfila <= DocumentosPendientes.Rows.Count - 1; nfila++)
            {
                if (Convert.ToDecimal(DocumentosPendientes.Rows[nfila]["pagosoles"]) < 0)
                {
                    DocumentosPendientes.Rows[nfila]["debehaber"] = (DocumentosPendientes.Rows[nfila]["debehaber"].ToString() == VariablesPublicas.ContabilidadIdCargo ? VariablesPublicas.ContabilidadIdAbono : VariablesPublicas.ContabilidadIdCargo);
                }
            }

            int lc_contador = 0;
            int ncont = 0;
            int lccontcampos = 0;
            //string xnomcolumna = "";
            decimal vmtcambio = VariablesPublicas.StringtoDecimal(txtCambio.Text);

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
            //cac3p00 = ocapa.cac3p00_consulta("", "xxx", "", "", "", "", "");
            //cac3g00 = ocapa.cac3g00_consulta("xx", "xx", "", "", "", "", "");
            //cac3g00.Rows.Add(VariablesPublicas.INSERTINTOTABLE(cac3g00));
            //if (ocapa.sql_error.Length > 0)
            //{
            //    frmclass.ShowError(ocapa.sql_error, this);
            //    return;
            //}
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

                    //for (lccontcampos = 0; lccontcampos <= DocumentosPendientes.Columns.Count - 1; lccontcampos++)
                    //{
                    //    if (DocumentosPendientes.Columns[lccontcampos].ColumnName.ToUpper() == "pagosoles" | DocumentosPendientes.Columns[lccontcampos].ColumnName.ToUpper() == "pagodolares" | DocumentosPendientes.Columns[lccontcampos].ColumnName.ToUpper() == "fechdoc")
                    //    {
                    //        xnomcolumna = DocumentosPendientes.Columns[lccontcampos].ColumnName.ToUpper();
                    //        if (xnomcolumna == "pagosoles" | xnomcolumna == "pagodolares")
                    //        {
                    //            if (xnomcolumna == "pagosoles")
                    //            {
                    //                if (Convert.ToDecimal(DocumentosPendientes.Rows[ncont][DocumentosPendientes.Columns[lccontcampos].ColumnName]) > Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["saldosoles"]))
                    //                {
                    //                    orow["imp1_3a"] = DocumentosPendientes.Rows[ncont]["saldosoles"];
                    //                }
                    //                else
                    //                {
                    //                    orow["imp1_3a"] = DocumentosPendientes.Rows[ncont][DocumentosPendientes.Columns[lccontcampos].ColumnName];
                    //                }
                    //            }
                    //            else
                    //            {
                    //                if (Convert.ToDecimal(DocumentosPendientes.Rows[ncont][DocumentosPendientes.Columns[lccontcampos].ColumnName]) > Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["saldodolares"]))
                    //                {
                    //                    orow["imp2_3a"] = DocumentosPendientes.Rows[ncont]["saldodolares"];
                    //                }
                    //                else
                    //                {
                    //                    orow["imp2_3a"] = DocumentosPendientes.Rows[ncont][DocumentosPendientes.Columns[lccontcampos].ColumnName];
                    //                }
                    //            }
                    //        }
                            //if (xnomcolumna == "fechdoc")
                            //{
                            //    orow["fref_3a"] = DocumentosPendientes.Rows[ncont][DocumentosPendientes.Columns[lccontcampos].ColumnName];
                            //}
                        //}
                    //}
                    if (DocumentosPendientes.Rows[ncont]["debehaber"].ToString() == VariablesPublicas.ContabilidadIdCargo)
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
            // Un Registro de Letra
            if (rbUnaletra.Checked)
            {
                tablavariasletras = DetFacturacion.Clone();
                tablavariasletras.Rows.Add(VariablesPublicas.InsertIntoTable(tablavariasletras));
                tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["cuentaid"] = txtCuentaletra.Text;
                tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["tipdoc"] = "62";
                tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["cuentaid"] = txtCuentaletra.Text;
                tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["cuentaname"] = txtDcuentaletra.Text;
                tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["serdoc"] = txtSerie.Text;
                tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["ctacte"] = xctacte;
                tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["nmruc"] = txtRuc.Text;
                tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["ctactename"] = txtCtactename.Text;
                tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["numdoc"] = txtNumpago.Text;
                tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["fechdoc"] = fEmision.Value.Date;
                if (fechaVenc.Checked)
                {
                    tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["fechvenc"] = fechaVenc.Value.Date;
                }
                if (vmdebesoles > vmhabersoles)
                {
                    tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["debehaber"] = VariablesPublicas.ContabilidadIdAbono;
                }
                else
                {
                    tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["debehaber"] = VariablesPublicas.ContabilidadIdCargo;
                }
                tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["soles"] = Math.Abs(vmdebesoles - vmhabersoles);
                tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["dolares"] = Math.Abs(vmdebedolares - vmhaberdolares);
                tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["moneda"] = (rbDolares.Checked ? 2 : 1);
                if (rbDolares.Checked)
                {
                    if (vmtcambio == 0)
                    {
                        tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["soles"] = 0;
                    }
                    else
                    {
                        tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["importe"] = Math.Round(Convert.ToDecimal(tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["dolares"]), 2);
                        tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["importecambio"] = Math.Round(Convert.ToDecimal(tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["dolares"]) * vmtcambio, 2);
                        tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["soles"] = Math.Round(Convert.ToDecimal(tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["dolares"]) * vmtcambio, 2);
                        //tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["soles"] = Math.Round(Convert.ToDecimal(tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["imp2_3a"]) * vmtcambio, 2);
                    }
                }
                else
                {
                    if (vmtcambio == 0)
                    {
                        tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["dolares"] = 0;
                    }
                    else
                    {
                        tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["importe"] = Math.Round(Convert.ToDecimal(tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["soles"]), 2);
                        tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["importecambio"] = Math.Round(Convert.ToDecimal(tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["soles"]) / vmtcambio, 2);
                        tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["dolares"] = Math.Round(Convert.ToDecimal(tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["soles"]) / vmtcambio, 2);
                        //tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["dolares"] = Math.Round(Convert.ToDecimal(tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["imp1_3a"]) / vmtcambio, 2);
                    }
                }
                tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["tipcamb"] = txtCambio.Text;
                tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["tipcambuso"] = "V";
                tablavariasletras.Rows[tablavariasletras.Rows.Count - 1]["tipcambfech"] = fEmision.Text;
            }
            else
            {
                //completa demas datos a letras generadas
                for (ncont = 0; ncont <= tablavariasletras.Rows.Count - 1; ncont++)
                {
                    tablavariasletras.Rows[ncont]["cuentaid"] = txtCuentaletra.Text;
                    tablavariasletras.Rows[ncont]["cuentaname"] = txtDcuentaletra.Text;
                    tablavariasletras.Rows[ncont]["fechdoc"] = fEmision.Value.Date;
                    tablavariasletras.Rows[ncont]["moneda"] = (rbDolares.Checked ? 2 : 1);
                    tablavariasletras.Rows[ncont]["tipcamb"] = txtCambio.Text;
                    tablavariasletras.Rows[ncont]["tipcambuso"] = "V";
                    tablavariasletras.Rows[ncont]["tipcambfech"] = fEmision.Text;
                    if (vmdebesoles > vmhabersoles)
                    {
                        tablavariasletras.Rows[ncont]["debehaber"] = VariablesPublicas.ContabilidadIdAbono;
                    }
                    else
                    {
                        tablavariasletras.Rows[ncont]["debehaber"] = VariablesPublicas.ContabilidadIdCargo;
                    }
                    //tablavariasletras.Rows[ncont]["codbanco_3a"] = txtcodbanco.Text;
                }
            }
            tablavariasletras.AcceptChanges();

            if (vmdebesoles > vmhabersoles)
            {
                vmdebesoles10 = Math.Abs(vmdebesoles - vmhabersoles);
                vmdebedolares10 = Math.Abs(vmdebedolares - vmhaberdolares);
            }
            else
            {
                vmhabersoles10 = Math.Abs(vmdebesoles - vmhabersoles);
                vmhaberdolares10 = Math.Abs(vmdebedolares - vmhaberdolares);
            }

            for (ncont = 0; ncont <= tablavariasletras.Rows.Count - 1; ncont++)
            {
                DetFacturacion.Rows.Add(VariablesPublicas.InsertIntoTable(DetFacturacion));
                for (lccontcampos = 0; lccontcampos <= tablavariasletras.Columns.Count - 1; lccontcampos++)
                {
                    if (VariablesPublicas.SeekNameColumn(DetFacturacion, tablavariasletras.Columns[lccontcampos].ColumnName.ToUpper()))
                    {
                        DetFacturacion.Rows[DetFacturacion.Rows.Count - 1][tablavariasletras.Columns[lccontcampos].ColumnName] = tablavariasletras.Rows[ncont][tablavariasletras.Columns[lccontcampos].ColumnName];
                    }
                }
            }

            //SUMATORIA SOLES/DOLARES ( EN DEBE HABER )
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
            //AJUSTES
            tb_co_ConfigcuentasrhredBL BiL = new tb_co_ConfigcuentasrhredBL();
            tb_co_Configcuentasrhred BiE = new tb_co_Configcuentasrhred();

            DataTable tmptablaconfig = BiL.GetAll(VariablesPublicas.EmpresaID.ToString(), BiE).Tables[0]; //ocapa.FagRHP_ConfigCuentas_consulta(GlobalVars.GetInstance.Company);

            //DataTable tmptablaconfig = ocapa.FagRHP_ConfigCuentas_consulta(GlobalVars.GetInstance.Company);
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

            //Ajustes DIF.CAMBIO DOLARES
            if ((!(vmhaberdolares == vmdebedolares)))
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
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["tipcamb"] = txtCambio.Text;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["tipcambuso"] = "V";
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["tipcambfech"] = fEmision.Text;
                    //DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["dolares"] = 0;

                    ndifdolares = vmdebedolares - vmhaberdolares;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["moneda"] = (rbDolares.Checked ? 2 : 1);
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["debehaber"] = (ndifdolares < 0 ? "D" : "H");
                    // perdida
                    if ((vmdebedolares - vmhaberdolares) < 0)
                    {
                        DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cuentaid"] = xcuentaperdida;
                        DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cuentaname"] = CuentaNombre(VariablesPublicas.perianio, xcuentaperdida);
                        DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cencosid"] = xccostoperdida;
                    }
                    else
                    {
                        DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cuentaid"] = xcuentaganancia;
                        DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cuentaname"] = CuentaNombre(VariablesPublicas.perianio, xcuentaganancia);
                        DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cencosid"] = xccostoganancia;
                    }
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importe"] = 0;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importecambio"] = Math.Abs(ndifdolares);
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["soles"] = 0;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["dolares"] = Math.Abs(ndifdolares);

                    //DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cdoc_3a"] = cursorformaspagos.Rows[0]["CDOCPAGO"];
                    //DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["ndoc_3a"] = txtnumpago.Text;
                    //DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["codbanco_3a"] = txtcodbanco.Text;
                    //DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["fref_3a"] = femision.Value;
                }
                else
                {
                    XtraMessageBox.Show("El asiento se va a generar con diferencia... Falta Configurar cuentas de ajuste x dif.cambio", "");
                }
            }
            //Ajustes DIF.CAMBIO SOLES
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
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["tipcamb"] = txtCambio.Text;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["tipcambuso"] = "V";
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["tipcambfech"] = fEmision.Text;

                    ndifsoles = vmdebesoles - vmhabersoles;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["moneda"] = (rbDolares.Checked ? 2 : 1);
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["debehaber"] = (ndifsoles < 0 ? "D" : "H");
                    // perdida
                    if ((vmdebesoles - vmhabersoles) < 0)
                    {
                        DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cuentaid"] = xcuentaperdida;
                        DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cuentaname"] = CuentaNombre(VariablesPublicas.perianio, xcuentaperdida);
                        DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cencosid"] = xccostoperdida;
                    }
                    else
                    {
                        DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cuentaid"] = xcuentaganancia;
                        DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cuentaname"] = CuentaNombre(VariablesPublicas.perianio, xcuentaganancia);
                        DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["cencosid"] = xccostoganancia;
                    }
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importe"] = Math.Abs(ndifsoles);
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["importecambio"] = 0;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["dolares"] = 0;
                    DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["soles"] = Math.Abs(ndifsoles);

                    //DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["dolares"] = 0;
                    //DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["soles"] = Math.Abs(ndifsoles);
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
            //cac3g00.Rows[0]["tmov_3"] = "";
            //cac3g00.Rows[0]["tasien_3"] = 3;
            //cac3g00.Rows[0]["mone_3"] = (rbDolares.Checked ? 2 : 1);
            //cac3g00.Rows[0]["fcom_3"] = femision.Value;
            //cac3g00.Rows[0]["fcome_3"] = femision.Value;
            //cac3g00.Rows[0]["tcam_3"] = VariablesPublicas.StringtoDecimal(txtcambio.Text);
            //cac3g00.Rows[0]["totd1_3"] = vmdebesoles + vmdebesoles10;
            //cac3g00.Rows[0]["totd2_3"] = vmdebedolares + vmdebedolares10;
            //cac3g00.Rows[0]["toth1_3"] = vmhabersoles + vmhabersoles10;
            //cac3g00.Rows[0]["toth2_3"] = vmhaberdolares + vmhaberdolares10;
            //cac3g00.Rows[0]["cuenb_3"] = "";
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
            //    tablavariasletras = VariablesPublicas.Zap(tablavariasletras);
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

        private String CuentaNombre(string perianio, string cuentaid)
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
                xmsg = "Ingrese Detalle Cuenta Corriente ( Proveedores , Clientes , ETC )";
                txtRuc.Focus();
            }
            if (rbMultiplesdetalles.Checked)
            {
                //If Me.TablaDetallesaSeleccionar Is Nothing Then
                //xmsg = "Ingrese Detalles Cuenta Corriente ( Proveedores , Clientes , ETC )"
                //   Me.btnseleccionarproveedores.Focus()
                //End If
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
            sw_novaluechange = true;
            if (VariablesPublicas.StringtoDecimal(txtmontoapagar.Text) == 0)
            {
                U_CancelaDeudaxRegistroSeleccionado();
            }
            else
            {
                string vmxmoneda = "";
                int ncont = 0;
                decimal ndeuda = default(decimal);
                decimal ntotalapagar = 0;
                decimal nvalorapagar = default(decimal);
                decimal vmncambio = default(decimal);

                if ((cboMoneda.SelectedValue != null))
                {
                    vmxmoneda = cboMoneda.SelectedValue.ToString();
                    ntotalapagar = VariablesPublicas.StringtoDecimal(txtmontoapagar.Text);
                    for (ncont = 0; ncont <= DocumentosPendientes.Rows.Count - 1; ncont++)
                    {
                        if (Convert.ToBoolean(DocumentosPendientes.Rows[ncont]["selecciona"]) == true)
                        {
                            vmncambio = Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["tcambio"]);
                            if (vmxmoneda == "1")
                            {
                                ndeuda = Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["saldosoles"]);
                            }
                            if (vmxmoneda == "2")
                            {
                                ndeuda = Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["saldodolares"]);
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
                                    DocumentosPendientes.Rows[ncont]["pagodolares"] = Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagodolares"]) +  Math.Round((Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagosoles"]) / vmncambio),2);
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
                                    DocumentosPendientes.Rows[ncont]["pagosoles"] = Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagosoles"]) +  Math.Round((Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagodolares"]) * vmncambio),2);
                                }
                            }
                            DocumentosPendientes.Rows[ncont]["pagosoles"] = Math.Round(Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagosoles"]), 2);
                            DocumentosPendientes.Rows[ncont]["pagodolares"] = Math.Round(Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagodolares"]), 2);

                            if (vmxmoneda == "1")
                            {
                                ntotalapagar = ntotalapagar - Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagosoles"]);
                            }
                            else
                            {
                                ntotalapagar = ntotalapagar - Convert.ToDecimal(DocumentosPendientes.Rows[ncont]["pagodolares"]);
                            }
                            if (ntotalapagar > 0)
                            {
                                ncont = ncont - 1;
                            }
                        }
                    }
                }
            }
            Sumatoria();
            sw_novaluechange = false;
        }

        private void examinar_Paint(object sender, PaintEventArgs e)
        {
            //U_pINTAR();
        }

        private void btnVervoucher_Click(object sender, EventArgs e)
        {
            UltimoNumeroRegistro();
            //if (UltimoTipoVoucher.Trim().Length > 0)
            if (UltimoNumVoucher != "0")
            {
                //Contabilidad.Frm_Registro_Contabilidad oform = new Contabilidad.Frm_Registro_Contabilidad();
                //oform._Mes = fEmision.Value.Month.ToString().Trim().PadLeft(2, '0'); //UltimoMesVoucher;
                //oform._Registro = UltimoNumVoucher.ToString().Trim().PadLeft(6, '0');
                //oform._Codvoucher = txtCodsubdiario.Text; //UltimoTipoVoucher;
                //oform._Tesoreria = true;
                //oform.Owner = this;
                //oform.ShowInTaskbar = false;
                //oform.Show();
            }
            else
            {
                XtraMessageBox.Show("Aún no se ha generado ningún voucher de Canje", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void txtCuentaletra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaCuentaLetra();
            }
        }
        private void txtCuentaletra_GotFocus(object sender, System.EventArgs e)
        {
            j_CuentaLetra = txtCuentaletra.Text;
        }
        private void txtCuentaletra_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_CuentaLetra == txtCuentaletra.Text) & !swLoad)
            {
                validacuentaLetra();
            }
        }
        private void validacuentaLetra()
        {
            sw_novaluechange = true;
            bool zhallado = false;
            string xcodartic = txtCuentaletra.Text;
            if (xcodartic.Trim().Length == 0)
            {
                txtCuentaletra.Text = "";
                txtDcuentaletra.Text = "";
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
                if (tmptabla.Rows.Count > 0)
                {
                    txtCuentaletra.Text = tmptabla.Rows[0]["cuentaid"].ToString();
                    txtDcuentaletra.Text = tmptabla.Rows[0]["cuentaname"].ToString();
                    zhallado = true;
                }
                if (!zhallado & xcodartic.Length > 0)
                {
                    txtCuentaletra.Text = j_CuentaLetra;
                }
            }
            sw_novaluechange = false;
        }
        private void AyudaCuentaLetra()
        {
            Frm_AyudaCuentas frmayuda = new Frm_AyudaCuentas();
            frmayuda.Owner = this;
            frmayuda._CUENTA_MAYOR = "";
            frmayuda._activaCta = true;
            frmayuda.Owner = this;
            frmayuda.PasaCuenta = RecibeCuentaLetra;
            frmayuda.ShowDialog();
        }
        private void RecibeCuentaLetra(string codigo, string descripcion)
        {
            if (codigo.Trim().Length > 0)
            {
                txtCuentaletra.Text = codigo;
                txtDcuentaletra.Text = descripcion;
            }
        }

        //GASTOS ADICIONALES
        private void btnAddfila_Click(object sender, EventArgs e)
        {
            adicionagastoadicional();
        }
        public void adicionagastoadicional()
        {
            string xvalorcargo = VariablesPublicas.ContabilidadIdCargo;
            if ((examinar.CurrentRow != null))
            {
                if ((!object.ReferenceEquals(examinar.Rows[examinar.CurrentRow.Index].Cells["debehaber"].Value, DBNull.Value)))
                {
                    xvalorcargo = examinar.Rows[examinar.CurrentRow.Index].Cells["debehaber"].Value.ToString();
                }
            }
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

        private void btnDelfila_Click(object sender, EventArgs e)
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
            string prvcod = "";
            txtdescripcampo.Text = "";
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
                    J_codh_3a = gridgastos.CurrentCell.Value.ToString();
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
                    j_Cuenta = gridgastos.CurrentCell.Value.ToString();
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
                        gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_debehaber"].Value = J_codh_3a;
                    }
                    sw_novaluechange = false;
                    totalizar();
                }
                if (gridgastos.Columns[e.ColumnIndex].Name.ToUpper() == "gasto_cuentaid".ToUpper())
                {
                    validacuentaGastoAdicional();
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
                    validaSerieDocumento();
                }
                if (gridgastos.Columns[e.ColumnIndex].Name.ToUpper() == "gasto_numdoc".ToUpper())
                {
                    validaNumerodocumento();
                }
            }
        }
        private void gridgastos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (gridgastos.Columns[gridgastos.CurrentCell.ColumnIndex].Name.ToUpper() == "gasto_debehaber".ToUpper())
            {
                txtCArti = (TextBox)e.Control;
                txtCArti.MaxLength = 1;//TabCac3p00GastosAdic.Columns["debehaber"].MaxLength;
                txtCArti.CharacterCasing = CharacterCasing.Upper;
                txtCArti.Text.Trim();
                e.Control.KeyDown += VariablesPublicas.CapturarTeclaGRID;
            }
            if (gridgastos.Columns[gridgastos.CurrentCell.ColumnIndex].Name.ToUpper() == "gasto_cuentaid".ToUpper())
            {
                txtCArti = (TextBox)e.Control;
                txtCArti.MaxLength = 10;// TabCac3p00GastosAdic.Columns["cuen_3a"].MaxLength;
                txtCArti.CharacterCasing = CharacterCasing.Upper;
                txtCArti.Text.Trim();
                e.Control.KeyDown += VariablesPublicas.CapturarTeclaGRID;
            }
            if (gridgastos.Columns[gridgastos.CurrentCell.ColumnIndex].Name.ToUpper() == "gasto_tipdoc".ToUpper())
            {
                txtCArti = (TextBox)e.Control;
                txtCArti.MaxLength = 2;// TabCac3p00GastosAdic.Columns["cdoc_3a"].MaxLength;
                txtCArti.CharacterCasing = CharacterCasing.Upper;
                txtCArti.Text.Trim();
                e.Control.KeyDown += VariablesPublicas.CapturarTeclaGRID;
            }
            if (gridgastos.Columns[gridgastos.CurrentCell.ColumnIndex].Name.ToUpper() == "gasto_serdoc".ToUpper())
            {
                txtCArti = (TextBox)e.Control;
                txtCArti.MaxLength = 4;
                txtCArti.CharacterCasing = CharacterCasing.Upper;
                txtCArti.Text.Trim();
                e.Control.KeyDown += VariablesPublicas.CapturarTeclaGRID;
            }
            if (gridgastos.Columns[gridgastos.CurrentCell.ColumnIndex].Name.ToUpper() == "gasto_numdoc".ToUpper())
            {
                txtCArti = (TextBox)e.Control;
                txtCArti.MaxLength = 10;// TabCac3p00GastosAdic.Columns["ndoc_3a"].MaxLength;
                txtCArti.CharacterCasing = CharacterCasing.Upper;
                txtCArti.Text.Trim();
                e.Control.KeyDown += VariablesPublicas.CapturarTeclaGRID;
            }
            _NameCOlumna = gridgastos.Columns[gridgastos.CurrentCell.ColumnIndex].Name.ToUpper();
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
                //switch (_NameCOlumna.ToUpper())
                //{
                    //case "gasto_cuen_3a".ToUpper():
                        //AyudaCuentaGastoAdicional();
                        //break;
                    //case "cdoc_3a".ToUpper():
                        //AyudaTipoDocumento();
                        //break;
                //}
                if (_NameCOlumna.ToUpper() == "gasto_cuentaid".ToUpper())
                {
                    AyudaCuentaGastoAdicional();
                }
                if (_NameCOlumna.ToUpper() == "gasto_tipdoc".ToUpper())
                {
                    AyudaTipoDocumento();
                }
                if (_NameCOlumna.ToUpper() == "gasto_cencosid".ToUpper())
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
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "BapSoft");
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
                    if (object.ReferenceEquals(TabCac3p00GastosAdic.Rows[lcont]["Importe"], DBNull.Value))
                    {
                        TabCac3p00GastosAdic.Rows[lcont]["Importe"] = 0;
                    }
                    if (object.ReferenceEquals(TabCac3p00GastosAdic.Rows[lcont]["ImporteCambio"], DBNull.Value))
                    {
                        TabCac3p00GastosAdic.Rows[lcont]["ImporteCambio"] = 0;
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
            decimal vmtcambio = Convert.ToDecimal(txtCambio.Text);
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
                    vmimportecambio = Math.Round(Convert.ToDecimal(gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["Importe"].Value) / vmtcambio, 2);
                }
            }
            if (gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_moneda"].Value.ToString() == VariablesPublicas.MonedaCodDolares)
            {
                vmimportecambio = Math.Round((vmtcambio == 0 ? 0 : Convert.ToDecimal(gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["Importe"].Value) * vmtcambio), 2);
            }
            gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["ImporteCambio"].Value = vmimportecambio;
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
            if ((!object.ReferenceEquals(gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["Gasto_cuentaid"].Value, DBNull.Value)))
            {
                xcodcuenta = gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["Gasto_cuentaid"].Value.ToString();
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

        public void validaSerieDocumento()
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
            gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_numdoc"].Value = VariablesPublicas.PADL(gridgastos.Rows[gridgastos.CurrentRow.Index].Cells["gasto_numdoc"].Value.ToString(), 10, "0");
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
                            txtdescripcampo.Text = tmptabla.Rows[0]["cencosname"].ToString();
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

        private void btnVariasletras_Click(object sender, EventArgs e)
        {
            if (VariablesPublicas.StringtoDecimal(lbltotalpagosoles.Text) > 0)
            {
                Frm_CanjeLetras_Cronograma oform = new Frm_CanjeLetras_Cronograma();
                oform._TotalDeudaDolares = Convert.ToDecimal(lbltotalpagodolares.Text);
                oform._TotalDeudaSoles = Convert.ToDecimal(lbltotalpagosoles.Text);
                oform._nMoneda = (rbSoles.Checked ? "1" : "2");
                oform._TablaContable = TabCac3p00GastosAdic;
                oform._TipoCambio = Convert.ToDecimal(txtCambio.Text);
                oform._TablaContable = tablavariasletras; 
                oform._PasaDelegado = PasaDatosVoucher;
                oform._LpVariosDetalles = rbMultiplesdetalles.Checked;
                oform._DelegadoLetra = Pasanumeroletra;
                if (!oform._LpVariosDetalles)
                {
                    oform._xctacte = xctacte;
                    oform._LpCodDetalle = txtRuc.Text;
                    oform._LpNomDetalle = txtCtactename.Text;
                }
                oform.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("Seleccione deuda a cancelar", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        public void Pasanumeroletra(string txtnumpagoinicial)
        {
            xNumLetra = txtnumpagoinicial;
        }
        public void PasaDatosVoucher(DataTable ListaLetrascac3p00) //ListaLetrascac3p00
        {
            if ((ListaLetrascac3p00 != null))
            {
                if ((tablavariasletras != null))
                {
                    for (nContador = 0; nContador <= tablavariasletras.Rows.Count - 1; nContador++)
                    {
                        tablavariasletras.Rows[nContador].Delete();
                    }
                    tablavariasletras.AcceptChanges();
                }
                for (nContador = 0; nContador <= ListaLetrascac3p00.Rows.Count - 1; nContador++)
                {
                    tablavariasletras.ImportRow(ListaLetrascac3p00.Rows[nContador]);
                }
                tablavariasletras.AcceptChanges();
            }
        }

        private void rbUnaletra_CheckedChanged(object sender, EventArgs e)
        {
            if (!swLoad)
            {
                u_RefrescaControles();
            }
        }

        public void U_CancelaDeudaxRegistroSeleccionado()
        {
            int ncont = 0;
            for (ncont = 0; ncont <= DocumentosPendientes.Rows.Count - 1; ncont++)
            {
                if (Convert.ToBoolean(DocumentosPendientes.Rows[ncont]["selecciona"]) == true)
                {
                    DocumentosPendientes.Rows[ncont]["pagosoles"] = DocumentosPendientes.Rows[ncont]["saldosoles"];
                    DocumentosPendientes.Rows[ncont]["pagodolares"] = DocumentosPendientes.Rows[ncont]["saldodolares"];
                }
            }
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
    }
}
