using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using System.IO;
using System.Net;
using System.Xml;
using System.Diagnostics;


namespace BapFormulariosNet.D60Tienda
{
    public partial class Frm_ventas : plantilla
    {
        DatoSUNAT myInfoSunat = new DatoSUNAT();

        private String EmpresaID = string.Empty;
        private String dominio = string.Empty;
        private String modulo = string.Empty;
        private String local = string.Empty;
        private String perianio = string.Empty;
        private String perimes = string.Empty;
        private bool novalidastock = false;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable Tabladetallemov;
        private DataTable TablaTarjetas;

        private DataRow row;
        private TextBox txtCDetalle = null;

        private String xxferfil = string.Empty;
        private String almacaccionid = string.Empty;
        private String statcostopromed = string.Empty;
        private String tiptransac = string.Empty;
        private Boolean fechadocedit = false;
        private Boolean tipodocautomatico = false;
        private Boolean tipodocmanejaserie = false;
        private Boolean statusDoc = true;
        private Boolean xnostock = false;
        private Boolean ManejaListPrec = false;

        private String tipimptoid = string.Empty;
        private String tip_operacion = string.Empty;
        private Decimal igv = 0;
        private String direcnume = string.Empty;
        private String incprec = "S";
        private String ssModo = "NEW";
        private static Decimal xprecventa = 0, xcostoultimo = 0;

        private String _cajanume = string.Empty;
        private String _perimes = string.Empty;
        private String _xtarjnumoper = "";
        private Int32 _xtarjetaid = 0;


        public Frm_ventas()
        {
            InitializeComponent();

            numdoc.LostFocus += new System.EventHandler(numdoc_LostFocus);
            serguia.LostFocus += new System.EventHandler(serguia_LostFocus);
            sernotac.LostFocus += new System.EventHandler(sernotac_LostFocus);
            numnotac.LostFocus += new System.EventHandler(numnotac_LostFocus);
            fechdoc.LostFocus += new System.EventHandler(fechdoc_LostFocus);
            ctacte.LostFocus += new System.EventHandler(ctacte_LostFocus);
            nmruc.LostFocus += new System.EventHandler(nmruc_LostFocus);
        }

        private void PARAMETROS_TABLA()
        {

            var f = (MainTienda)MdiParent;
            xxferfil = f.perfil.ToString();

            if (xxferfil.Trim().Length != 9)
            {
                MessageBox.Show("::: NO TIENE PERFIL !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PERFILID = xxferfil;
            var XTABLA_PERFIL = string.Empty;
            XTABLA_PERFIL = VariablesPublicas.GET_PARAMETROS_TABLA(xxferfil, Name);
            if (XTABLA_PERFIL.Trim().Length > 0 && XTABLA_PERFIL.Trim() != "0")
            {
                if (XTABLA_PERFIL.Trim().Length == 2)
                {
                    dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
                }
                else
                {
                    if (XTABLA_PERFIL.Trim().Length == 6)
                    {
                        dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
                        modulo = XTABLA_PERFIL.Trim().Substring(2, 4);
                    }
                    else
                    {
                        if (XTABLA_PERFIL.Trim().Length == 9)
                        {
                            dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
                            modulo = XTABLA_PERFIL.Trim().Substring(2, 4);
                            local = XTABLA_PERFIL.Trim().Substring(6, 3);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("::: No puede accede a FORMULARIO. \n::: Es necesario DOMINIO, MODULO Y LOCAL !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NIVEL_FORMS()
        {
            XNIVEL = VariablesPublicas.Get_nivelperfil(PERFILID, Name).Substring(0, 1);
            if (XNIVEL != "0")
            {
                btn_clave.Image = global::BapFormulariosNet.Properties.Resources.btn_Lock20;
            }
            else
            {
                btn_clave.Image = global::BapFormulariosNet.Properties.Resources.btn_Un_Lock20;
            }
        }

        private void btn_clave_Click(object sender, EventArgs e)
        {
            try
            {
                var miForma = new Ayudas.Form_user_admin();
                miForma.Owner = this;
                miForma.PasaDatos = RecibePermiso;
                var sw = false;
                sw = Convert.ToBoolean(miForma.ShowDialog());

                if (sw)
                {
                    btn_detanadir.Enabled = true;
                }
                else
                {
                    btn_detanadir.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RecibePermiso(Boolean resultado1, String resultado2)
        {
            if (resultado1)
            {
                XNIVEL = "0";
                XGLOSA = resultado2.Trim();
                btn_clave.Image = global::BapFormulariosNet.Properties.Resources.btn_Un_Lock20;
            }
        }

        private void select_tipodoc()
        {
            try
            {
                if (tipodoc.SelectedValue.ToString() != "00" && tipodoc.SelectedIndex != 0)
                {
                    var BL = new modulo_local_tipodocBL();
                    var BE = new tb_modulo_local_tipodoc();
                    var dt = new DataTable();

                    BE.dominioid = dominio;
                    BE.moduloid = modulo;
                    BE.local = local;
                    BE.tipodoc = tipodoc.SelectedValue.ToString().Trim();
                    BE.visiblealmac = true;

                    dt = BL.GetAll(EmpresaID, BE).Tables[0];

                    almacaccionid = dt.Rows[0]["almacaccionid"].ToString().Trim();

                    tipodocautomatico = Convert.ToBoolean(dt.Rows[0]["tipodocautomatico"]);
                    tipodocmanejaserie = Convert.ToBoolean(dt.Rows[0]["tipodocmanejaserie"]);

                    if (almacaccionid.Trim().Length > 0)
                    {
                        if (tipodocautomatico)
                        {
                            if (tipodocmanejaserie)
                            {
                                get_autoCS_numMov();
                            }
                            else
                            {
                                MessageBox.Show("Documento debe manejar Serie", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                statusDoc = false;
                            }
                        }
                        else
                        {
                            if (tipodocmanejaserie)
                            {
                                get_autoCS_numMov();
                                numdoc.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("Documento debe manejar Serie", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                statusDoc = false;
                            }
                        }
                        if (almacaccionid.Substring(0, 1) == "2")
                        {
                            tipoclieprov.Text = "Cliente:";
                            lbl_valor.Text = "Cost.Prom";
                        }
                        else
                        {
                            lbl_valor.Text = "Cost.Ultm";
                            tipoclieprov.Text = "Proveedor:";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Asignar la Accion del Documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        statusDoc = false;
                    }
                }
                else
                {
                    serdoc.Text = string.Empty;
                    numdoc.Text = string.Empty;
                    statusDoc = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusDoc = false;
            }
        }

        private void get_val_fechadoc()
        {
            try
            {
                var BL = new constantesgeneralesBL();
                var dt = new DataTable();

                dt = BL.GetOne(EmpresaID, dominio, modulo, local).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    perianio = dt.Rows[0]["perianio"].ToString().Trim();

                    var BL2 = new sys_localBL();
                    var BE2 = new tb_sys_local();
                    var dt2 = new DataTable();
                    BE2.dominioid = dominio.ToString();
                    BE2.moduloid = modulo.ToString();
                    ;
                    BE2.local = local.ToString();
                    dt2 = BL2.GetAll(VariablesPublicas.EmpresaID, BE2).Tables[0];
                    if (dt2.Rows.Count > 0)
                    {
                        // Lo que esta comentado es para validar con el perimes del  => BapConfig.cfg

                        //if (Convert.ToBoolean(dt2.Rows[0]["perimeslocal"]))
                        //{
                        //    perimes = _perimes;
                        //}
                        //else
                        //{
                            perimes = dt.Rows[0]["perimes"].ToString().Trim();
                        //}
                    }
                    if (dt.Rows[0]["fechadocedit"].ToString().Trim().Length > 0)
                    {
                        fechadocedit = Convert.ToBoolean(dt.Rows[0]["fechadocedit"]);
                    }
                }

                var fechaactual = DateTime.Today;
                var fechaperiodo = Convert.ToDateTime("01" + "/" + perimes + "/" + perianio);

                if (fechadocedit)
                {
                    var primerdia = new DateTime(fechaperiodo.Year, fechaperiodo.Month, 1);
                    var ultimodia = primerdia.AddMonths(1).AddDays(-1);
                    if (fechaactual.Day <= ultimodia.Day)
                    {
                        fechdoc.Value = Convert.ToDateTime(fechaactual.Day + "/" + perimes + "/" + perianio);
                    }
                    else
                    {
                        fechdoc.Value = Convert.ToDateTime(ultimodia.Day + "/" + perimes + "/" + perianio);
                    }
                    fechdoc.MaxDate = ultimodia;
                    fechdoc.MinDate = primerdia;
                }
                else
                {
                    if (fechaactual.Month == fechaperiodo.Month && fechaactual.Year == fechaperiodo.Year)
                    {
                        fechdoc.Value = fechaactual;
                    }
                    else
                    {
                        MessageBox.Show("Actualizar a periodo actual en tabla constantes generales !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        statusDoc = false;
                    }
                }
                get_tipocambio(fechdoc.Text);
                get_tipimptoid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusDoc = false;
            }
        }

        private void get_autoCS_numMov()
        {
            try
            {
                var BL = new modulo_local_tipodocseriesBL();
                var BE = new tb_modulo_local_tipodocseries();
                var dt = new DataTable();
                BE.dominioid = dominio;
                BE.moduloid = modulo;
                BE.local = local;
                BE.tipodoc = tipodoc.SelectedValue.ToString().Trim();
                BE.ncaja = _cajanume.ToString();

                dt = BL.GetAll_nuevonumero2(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    serdoc.Text = dt.Rows[0]["serdoc2"].ToString();
                    numdoc.Text = dt.Rows[0]["numero"].ToString();
                }
                else
                {
                    serdoc.Text = string.Empty;
                    numdoc.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void get_tipimptoid()
        {
            try
            {
                var BL = new tb_tipimptoBL();
                var BE = new tb_tipimpto();
                var dt = new DataTable();

                BE.status = true;
                dt = BL.GetAll(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    tipimptotasa.DataSource = dt;
                    tipimptotasa.DisplayMember = "tipimptotasa";
                    tipimptotasa.ValueMember = "tipimptoid";
                    tipimptotasa.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Active la tasa de impuesto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void get_tipocambio(string fecha)
        {
            try
            {
                var BL = new tipocambioBL();
                var dt = new DataTable();

                dt = BL.GetOne(EmpresaID, Convert.ToDateTime(fecha)).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    tcamb.Text = Convert.ToDecimal(dt.Rows[0]["venta"]).ToString("###,##0.0000");
                }
                else
                {
                    tcamb.Text = "1";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void form_bloqueado(Boolean var)
        {
            try
            {
                if (var == false)
                {
                    tipodoc.Enabled = !var;
                    numdoc.Enabled = !var;
                }
                else
                {
                    tipodoc.Enabled = !var;
                    numdoc.Enabled = !var;
                }

                serdoc.Enabled = false;
                moneda.Enabled = var;
                tcamb.Enabled = var;
                tcamb.ReadOnly = true;
                tipimptotasa.Enabled = var;
                nmruc.Enabled = var;
                ctacte.Enabled = var;
                ctactename.Enabled = var;

                direc.Enabled = true;
                telef.Enabled = true;
                importtarj.Enabled = false;

                lstListaprec.Enabled = var;
                lstTarjGroup.Enabled = var;
                btn_add.Enabled = var;
                btn_del.Enabled = var;

                btnextraersunat.Enabled = var;
                vendperid.Enabled = var;
                vendpername.Enabled = false;

                chkFA.Enabled = var;
                chkGR.Enabled = var;
                chkNC.Enabled = var;

                tipfac.Enabled = false;
                serfac.Enabled = false;
                numfac.Enabled = false;
                fechfac.Enabled = false;
                //fechfac.Checked = false;

                tipguia.Enabled = false;
                serguia.Enabled = false;
                numguia.Enabled = false;
                fechguia.Enabled = false;

                tipnotac.Enabled = false;
                sernotac.Enabled = false;
                numnotac.Enabled = false;
                fechnotac.Enabled = false;

                recep_name.Enabled = false;
                recep_dni.Enabled = false;
                recep_fecha.Enabled = false;

                itemsT.Enabled = var;
                itemsT.ReadOnly = true;
                totpzas.Enabled = var;
                totpzas.ReadOnly = true;
                bruto.Enabled = var;
                bruto.ReadOnly = true;
                totdscto1.Enabled = var;
                totdscto1.ReadOnly = true;
                valventa.Enabled = var;
                valventa.ReadOnly = true;
                totimpto.Enabled = var;
                totimpto.ReadOnly = true;
                totimporte.Enabled = var;
                totimporte.ReadOnly = true;
                glosa.Enabled = var;
                princombo.Enabled = var;

                griddetallemov.ReadOnly = !var;
                griddetallemov.Columns["item"].ReadOnly = true;
                griddetallemov.Columns["productname"].ReadOnly = true;
                griddetallemov.Columns["stock"].ReadOnly = true;
                griddetallemov.Columns["importfac"].ReadOnly = true;
                griddetallemov.Columns["unmed"].ReadOnly = true;

                btn_nuevo.Enabled = false;
                btn_editar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_grabar.Enabled = false;
                btn_upload.Enabled = false;
                btn_eliminar.Enabled = false;
                btn_imprimir.Enabled = false;
                btnImprimirNoval.Enabled = false;

                btn_primero.Enabled = false;
                btn_anterior.Enabled = false;
                btn_siguiente.Enabled = false;
                btn_ultimo.Enabled = false;

                btn_detanadir.Enabled = false;
                btn_deteliminar.Enabled = false;
                btn_clave.Enabled = true;
                btn_log.Enabled = true;
                btn_salir.Enabled = !var;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void form_accion_cancelEdicion(int confirnar)
        {
            var sw_prosigue = true;
            if (confirnar == 1)
            {
                sw_prosigue = (MessageBox.Show("Desea cancelar ingreso de datos...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
            }
            else
            {
                sw_prosigue = true;
            }
            if (sw_prosigue)
            {
                if (chkfijar.Checked == false)
                {
                    tipodoc.SelectedIndex = 0;
                    tipodoc.Enabled = false;
                }
                limpiar_documento();
                form_bloqueado(false);
                get_val_fechadoc();
                btn_nuevo.Enabled = true;
                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;
                ssModo = "NEW";
                fechdoc.MinDate = new DateTime(2000, 1, 1);
                fechdoc.MaxDate = new DateTime(2999, 12, 12);
                fechdoc.Value = DateTime.Today;

                nmruc.Focus();
            }
        }

        private void form_cargar_datos(String posicion)
        {
            try
            {
                ControlName();
                limpiar_documento();
                var BL = new tb_ad_movimientosBL();
                var BE = new tb_ad_movimientos();
                var dt = new DataTable();

                BE.moduloid = modulo;
                BE.local = local;
                BE.tipodoc = tipodoc.SelectedValue.ToString().Trim();

                if (serdoc.Text.Trim().Length > 0)
                {
                    BE.serdoc = serdoc.Text.Trim().PadLeft(4, '0');
                    BE.numdoc = numdoc.Text.Trim().PadLeft(10, '0');
                }
                else
                {
                    if (posicion.Trim().Length > 0)
                    {
                        MessageBox.Show("Seleccionar el Tipo de Documento !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }
                if (numdoc.Text.Trim().Length > 0)
                {
                    BE.numdoc = numdoc.Text.Trim().PadLeft(10, '0');
                }
                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    ssModo = "EDIT";
                    serdoc.Text = dt.Rows[0]["serdoc"].ToString().Trim();
                    numdoc.Text = dt.Rows[0]["numdoc"].ToString().Trim();
                    fechdoc.Text = dt.Rows[0]["fechdoc"].ToString().Trim();

                    tipimptoid = dt.Rows[0]["tipimptoid"].ToString().Trim();
                    direcnume = dt.Rows[0]["direcnume"].ToString().Trim();
                    incprec = dt.Rows[0]["incprec"].ToString().Trim();
                    if (incprec.ToString() == "N")
                    {
                        cbo_incprec.SelectedIndex = 1;
                    }
                    else
                    {
                        cbo_incprec.SelectedIndex = 0;
                    }

                    moneda.SelectedValue = dt.Rows[0]["moneda"].ToString().Trim();
                    tcamb.Text = dt.Rows[0]["tcamb"].ToString().Trim();

                    if (dt.Rows[0]["tipimptoid"].ToString().Trim().Length > 0)
                    {
                        tipimptotasa.SelectedValue = dt.Rows[0]["tipimptoid"].ToString().Trim();
                    }
                    else
                    {
                        tipimptotasa.SelectedIndex = 0;
                    }
                    ctacte.Text = dt.Rows[0]["ctacte"].ToString().Trim();
                    nmruc.Text = dt.Rows[0]["nmruc"].ToString().Trim();
                    ctactename.Text = dt.Rows[0]["ctactename"].ToString().Trim();
                    direc.Text = dt.Rows[0]["direc"].ToString().Trim();

                    vendperid.Text = dt.Rows[0]["vendorid"].ToString().Trim();
                    vendpername.Text = dt.Rows[0]["vendorname"].ToString().Trim();

                    if (dt.Rows[0]["serfac"].ToString().Trim().Length > 0 && dt.Rows[0]["numfac"].ToString().Trim().Length > 0)
                    {
                        tipfac.Text = dt.Rows[0]["tipfac"].ToString().Trim();
                        serfac.Text = dt.Rows[0]["serfac"].ToString().Trim();
                        numfac.Text = dt.Rows[0]["numfac"].ToString().Trim();
                        //fechfac.Value = DateTime.Parse(dt.Rows[0]["fechfac"].ToString().Trim());
                        fechfac.Text = dt.Rows[0]["fechfac"].ToString().Trim();

                        recep_name.Text = dt.Rows[0]["recep_name"].ToString().Trim();
                        recep_dni.Text = dt.Rows[0]["recep_dni"].ToString().Trim();
                        recep_fecha.Text = dt.Rows[0]["recep_fecha"].ToString().Trim();
                    }
                    else
                    {
                        tipfac.SelectedIndex = 0;
                    }

                    if (dt.Rows[0]["serguia"].ToString().Trim().Length > 0 && dt.Rows[0]["numguia"].ToString().Trim().Length > 0)
                    {
                        serguia.Text = dt.Rows[0]["serguia"].ToString().Trim();
                        numguia.Text = dt.Rows[0]["numguia"].ToString().Trim();
                        fechguia.Text = dt.Rows[0]["fechguia"].ToString().Trim();
                    }

                    if (dt.Rows[0]["sernotac"].ToString().Trim().Length > 0 && dt.Rows[0]["numnotac"].ToString().Trim().Length > 0)
                    {
                        sernotac.Text = dt.Rows[0]["sernotac"].ToString().Trim();
                        numnotac.Text = dt.Rows[0]["numnotac"].ToString().Trim();
                        fechnotac.Text = dt.Rows[0]["fechnotac"].ToString().Trim();
                    }

                    tip_operacion = dt.Rows[0]["tipoperacionid"].ToString().Trim();

                    itemsT.Text = dt.Rows[0]["items"].ToString().Trim();
                    totpzas.Text = dt.Rows[0]["totpzas"].ToString().Trim();
                    bruto.Text = dt.Rows[0]["bruto"].ToString().Trim();
                    totdscto1.Text = dt.Rows[0]["totdscto1"].ToString().Trim();
                    valventa.Text = dt.Rows[0]["valventa"].ToString().Trim();
                    totimpto.Text = dt.Rows[0]["totimpto"].ToString().Trim();
                    totimporte.Text = dt.Rows[0]["totimporte"].ToString().Trim();
                    glosa.Text = dt.Rows[0]["glosa"].ToString().Trim();
                    // Venta en Combo
                    princombo.Checked = Convert.ToBoolean(dt.Rows[0]["princombo"].ToString() == "True" ? 1 : 0);
                    canticombo.Value = Convert.ToInt32(dt.Rows[0]["cantcombo"].ToString() == "" ? "0" : dt.Rows[0]["cantcombo"].ToString()) == 0 ? 1 : Convert.ToInt32(dt.Rows[0]["cantcombo"].ToString() == "" ? "0" : dt.Rows[0]["cantcombo"].ToString());
                    preccombo.Text = Convert.ToDecimal(dt.Rows[0]["preccombo"].ToString() == "" ? "0" : dt.Rows[0]["preccombo"].ToString()).ToString("###,##0.00");
                    //
                    importtarj.Text = dt.Rows[0]["tarjimporte1"].ToString().Trim();
                    txtefectivo.Text = dt.Rows[0]["efectivo"].ToString().Trim();

                    if (dt.Rows[0]["tarjetaid"].ToString() != "")
                    { _xtarjetaid = Convert.ToInt32(dt.Rows[0]["tarjetaid"].ToString()); }

                    if (dt.Rows[0]["tarjnumoper"].ToString() != "")
                    { _xtarjnumoper = dt.Rows[0]["tarjnumoper"].ToString().Trim(); }

                    data_Tabladetallemovmov();
                    data_TablaTarjetas();

                    if (dt.Rows[0]["status"].ToString().Trim() != "9")
                    {
                        btn_editar.Enabled = true;
                        btn_eliminar.Enabled = true;
                        btn_imprimir.Enabled = true;
                        btnImprimirNoval.Enabled = true;

                        btn_primero.Enabled = true;
                        btn_anterior.Enabled = true;
                        btn_siguiente.Enabled = true;
                        btn_ultimo.Enabled = true;

                        btn_salir.Enabled = true;
                        griddetallemov.Focus();
                        griddetallemov.Rows[0].Selected = false;
                        pdtimagen.Visible = false;

                        princombo.Enabled = false;
                        canticombo.Enabled = false;
                    }
                    else
                    {
                        ssModo = "ANULADO";
                        pdtimagen.Visible = true;
                        btn_editar.Enabled = false;
                        btn_eliminar.Enabled = false;
                        btn_imprimir.Enabled = true;
                        btnImprimirNoval.Enabled = true;

                        btn_primero.Enabled = true;
                        btn_anterior.Enabled = true;
                        btn_siguiente.Enabled = true;
                        btn_ultimo.Enabled = true;
                        btn_salir.Enabled = true;

                        princombo.Enabled = false;
                        canticombo.Enabled = false;
                    }
                }
                calcular_totales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void data_cbo_tipodoc()
        {
            try
            {
                var BL = new modulo_local_tipodocBL();
                var BE = new tb_modulo_local_tipodoc();
                DataTable dt = new DataTable();
                BE.dominioid = dominio;
                BE.moduloid = modulo;
                BE.local = local;
                BE.visiblealmac = true;
                BE.status = string.Empty;
                BE.tipodoctipotransac = "V";
                dt = BL.GetAll_mov(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    tipodoc.DataSource = dt;
                    tipodoc.ValueMember = "tipodoc";
                    tipodoc.DisplayMember = "tipodocname";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void data_cbo_moneda()
        {
            try
            {
                var BL = new tb_co_tabla04_tipomonedaBL();
                var BE = new tb_co_tabla04_tipomoneda();
                var dt = new DataTable();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                moneda.DataSource = dt;
                moneda.ValueMember = "monedaid";
                moneda.DisplayMember = "sigla";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidaCliente()
        {
            if (nmruc.Text.Trim().Length > 0 || ctacte.Text.Trim().Length > 0)
            {
                var BL = new clienteBL();
                var BE = new tb_cliente();
                var dt = new DataTable();

                BE.ctacte = ctacte.Text.Trim().PadLeft(7, '0');
                if (nmruc.Text.Trim().Length > 0)
                {
                    BE.nmruc = nmruc.Text.Trim();
                }
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    ctacte.Text = dt.Rows[0]["ctacte"].ToString().Trim();
                    nmruc.Text = dt.Rows[0]["nmruc"].ToString().Trim();
                    ctactename.Text = dt.Rows[0]["ctactename"].ToString().Trim();
                    direc.Text = dt.Rows[0]["direc"].ToString().Trim();
                }
                else
                {
                    ctacte.Text = string.Empty;
                    nmruc.Text = string.Empty;
                    ctactename.Text = string.Empty;
                    direc.Text = string.Empty;

                    direcnume = string.Empty;
                    nmruc.Focus();
                }
            }
        }


        private void solo_numero_enteros(object control, KeyPressEventArgs e)
        {
            if (((e.KeyChar) >= '0' && e.KeyChar <= '9') && !(e.KeyChar == '.'))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete && !(e.KeyChar == '.'))
                {
                    e.Handled = false;
                }
                else
                {
                    if ((e.KeyChar) == (char)Keys.Tab)
                    {
                        e.Handled = false;
                    }

                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        public bool IsNumeric(String Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        private String get_tipimptotasa(String tipimptoid)
        {
            try
            {
                var BL = new tb_tipimptoBL();
                var BE = new tb_tipimpto();
                var dt = new DataTable();
                BE.tipimptoid = tipimptoid.Trim();

                dt = BL.GetOne(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return Math.Round(Convert.ToDecimal(dt.Rows[0]["tipimptotasa"]), 0).ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static KeyEventHandler CapturarTeclaGRID
        {
            get
            {
                KeyEventHandler keypress = new KeyEventHandler(LecturaTecla);
                return keypress;
            }
        }

        private static void LecturaTecla(System.Object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                VariablesPublicas.PulsaAyudaArticulos = true;
                SendKeys.Send("\t");
            }
            if (e.KeyCode == Keys.F2)
            {
                VariablesPublicas.PulsaTeclaF2 = true;
                SendKeys.Send("\t");
            }
            if (e.KeyCode == Keys.F3)
            {
                VariablesPublicas.PulsaTeclaF3 = true;
                SendKeys.Send("\t");
            }
            if (e.KeyCode == Keys.Enter)
            {
                VariablesPublicas.Enter = true;
                SendKeys.Send("\t");
            }
        }

        private void AyudaClientes(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "Ayuda Cliente/Proveedor";
                frmayuda.sqlquery = "select ctacte, ctactename, nmruc, direc from tb_cliente";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where";
                frmayuda.sqland = string.Empty;
                frmayuda.criteriosbusqueda = new string[] { "CLIENTE", "RUC", "CODIGO" };
                frmayuda.columbusqueda = "ctactename,nmruc,ctacte";
                frmayuda.returndatos = "0,2,1,3";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeClientes;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }

        private void RecibeClientes(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                ctacte.Text = resultado1.Trim();
                nmruc.Text = resultado2.Trim();
                ctactename.Text = resultado3.Trim();
                direc.Text = resultado4.Trim();
            }
        }

        private void AyudaClientesDireccion(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all";
                frmayuda.titulo = "Ayuda Dirección";
                frmayuda.sqlquery = "select direcnume, direcname, direcdeta from tb_cliente_direc";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where ctacte = '" + ctacte.Text.Trim() + "'";
                frmayuda.sqland = "and";
                frmayuda.criteriosbusqueda = new string[] { "NOM DIRECCIÓN", "DIRECCIÓN" };
                frmayuda.columbusqueda = "direcname,direcdeta";
                frmayuda.returndatos = "0,1,2";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeClientesDireccion;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }

        private void RecibeClientesDireccion(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                direcnume = resultado1.Trim();
            }
        }

        private void AyudaProductoListaprecios(String lpdescrlike)
        {
            try
            {
                var modd = string.Empty;
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();

                BE.dominioid = dominio;
                BE.moduloid = modulo;
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();
                        var frmayuda = new Ayudas.Frm_help_gridproductoLista_vlx();

                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA PRODUCTO >>";


                        frmayuda.sqlquery = " SELECT TOP 100  " +
                                " LS.productid, " +
                                " PR.productname , " +
                                " PR.unmed , ";
                        if (moneda.SelectedValue.ToString() == "2")
                        {
                            frmayuda.sqlquery = frmayuda.sqlquery + " LP.precunit2 as precunit, ";
                        }
                        else
                        {
                            frmayuda.sqlquery = frmayuda.sqlquery + " LP.precunit1 as precunit, ";
                        }
                        frmayuda.sqlquery = frmayuda.sqlquery + " LS.stock, " + " LI.nostock  " +
                                                                " FROM   tb_ad_local_stock  AS LS ";

                        frmayuda.sqlinner = " INNER JOIN tb_ad_productos PR " +
                                               " ON  PR.moduloid = LS.moduloid " +
                                               " AND PR.productid = LS.productid " +
                               " INNER JOIN tb_ad_listapreciosdet LP " +
                                   " ON  LP.listaprecid = '" + lstListaprec.SelectedValue.ToString() + "' " +
                                   " AND LP.codigo = LEFT(LS.productid,10) " +
                               " LEFT JOIN tb_ad_linea li ON PR.lineaid = li.lineaid and PR.moduloid = li.moduloid";

                        frmayuda.sqlwhere = " WHERE  LS.moduloid = '" + modulo + "' " +
                               " AND LS.LOCAL ='" + local + "' ";

                        frmayuda.sqland = "and";
                        frmayuda.criteriosbusqueda = new string[] { "PRODUCTO", "CODIGO" };
                        frmayuda.columbusqueda = "PR.productname,PR.productid";
                        frmayuda.returndatos = "0,1,2";

                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeProductoListPrec;
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RecibeProductoListPrec(DataTable dtresultado)
        {
            try
            {
                if (dtresultado.Rows.Count > 0)
                {
                    var cont = 0;
                    foreach (DataRow fila in dtresultado.Rows)
                    {
                        cont = cont + 1;
                        if (griddetallemov.Rows.Count > 0)
                        {
                            var nFilaAnt = griddetallemov.RowCount - 1;
                            var xProductid = fila["productid"].ToString();
                            var xProductname = fila["productname"].ToString();
                            var xunmed = fila["unmed"].ToString();
                            xnostock = Convert.ToBoolean(fila["nostock"].ToString());

                            if (cont > 1)
                            {
                                Tabladetallemov.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetallemov));
                                Tabladetallemov.Rows[Tabladetallemov.Rows.Count - 1]["items"] = VariablesPublicas.CalcMaxField(Tabladetallemov, "items", 5);
                                griddetallemov.Rows[nFilaAnt + 1].Cells["productid"].Value = xProductid;
                                griddetallemov.Rows[nFilaAnt + 1].Cells["productname"].Value = xProductname;
                                griddetallemov.Rows[nFilaAnt + 1].Cells["nostock"].Value = xnostock;
                            }
                            else
                            {
                                griddetallemov.Rows[nFilaAnt].Cells["productid"].Value = xProductid;
                                griddetallemov.Rows[nFilaAnt].Cells["productname"].Value = xProductname;
                                griddetallemov.Rows[nFilaAnt].Cells["unmed"].Value = xunmed;
                                griddetallemov.Rows[nFilaAnt].Cells["nostock"].Value = xnostock;
                            }

                            griddetallemov.CurrentCell = griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["cantidad"];
                            griddetallemov.BeginEdit(true);
                            CargarDetalle(xProductid);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AyudaProducto(String lpdescrlike)
        {
            try
            {
                var modd = string.Empty;
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();

                BE.dominioid = dominio;
                BE.moduloid = modulo;
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();
                        var frmayuda = new Ayudas.Form_help_gridproducto_vlx();
                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA PRODUCTO (100 - PRIMEROS)>>";
                        frmayuda.sqlquery = " Select TOP 100 tb1.productid, tb1.productname,tb1.unmed,tb2.stock, tb2.costoultimo as precventa, tb2.[local],li.nostock From tb_ad_productos tb1 ";
                        frmayuda.sqlinner = " Left Join tb_ad_local_stock tb2 on tb1.moduloid=tb2.moduloid and tb1.productid = tb2.productid " +
                                            " LEFT join tb_ad_linea li on tb1.lineaid = li.lineaid and tb1.moduloid = li.moduloid ";
                        frmayuda.sqlwhere = "where tb2.moduloid ='" + modulo + "'  AND local ='" + local + "'";
                        frmayuda.sqland = "and";
                        frmayuda.criteriosbusqueda = new string[] { "PRODUCTO", "CODIGO" };
                        frmayuda.columbusqueda = "tb1.productname,tb1.productid";
                        frmayuda.returndatos = "0,1,2";

                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeProducto;
                        frmayuda.txt_busqueda.Focus();
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RecibeProducto(DataTable dtresultado)
        {
            try
            {
                if (dtresultado.Rows.Count > 0)
                {
                    var cont = 0;

                    foreach (DataRow fila in dtresultado.Rows)
                    {
                        cont = cont + 1;
                        if (griddetallemov.Rows.Count > 0)
                        {
                            var nFilaAnt = griddetallemov.RowCount - 1;
                            var xProductid = fila["productid"].ToString();
                            var xProductname = fila["productname"].ToString();
                            var xunmed = fila["unmed"].ToString();
                            xnostock = Convert.ToBoolean(fila["nostock"].ToString());


                            if (cont > 1)
                            {
                                Tabladetallemov.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetallemov));
                                Tabladetallemov.Rows[Tabladetallemov.Rows.Count - 1]["items"] = VariablesPublicas.CalcMaxField(Tabladetallemov, "items", 5);
                                griddetallemov.Rows[nFilaAnt + 1].Cells["productid"].Value = xProductid;
                                griddetallemov.Rows[nFilaAnt + 1].Cells["productname"].Value = xProductname;
                                griddetallemov.Rows[nFilaAnt + 1].Cells["nostock"].Value = xnostock;
                            }
                            else
                            {
                                griddetallemov.Rows[nFilaAnt].Cells["productid"].Value = xProductid;
                                griddetallemov.Rows[nFilaAnt].Cells["productname"].Value = xProductname;
                                griddetallemov.Rows[nFilaAnt].Cells["unmed"].Value = xunmed;
                                griddetallemov.Rows[nFilaAnt].Cells["nostock"].Value = xnostock;
                            }

                            griddetallemov.CurrentCell = griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["cantidad"];
                            griddetallemov.BeginEdit(true);
                            ValidaTabladetallemovmov(xProductid);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SEGURIDAD_LOG(String accion)
        {
            var xclave = VariablesPublicas.EmpresaID + "-" + modulo + "-" + tipodoc.Text.Trim() + "-" + serdoc.Text.Trim() + "-" + numdoc.Text.Trim();
            try
            {
                var BL = new tb_co_seguridadlogBL();
                var BE = new tb_co_seguridadlog();

                BE.moduloid = Name;
                BE.clave = xclave;
                BE.cuser = VariablesPublicas.Usuar;


                BE.fecha = DateTime.Now;
                BE.pc = VariablesPublicas.userip;
                BE.accion = accion.Trim();
                BE.detalle = tipodoc.Text.Trim() + "-" + serdoc.Text.Trim() + "-" + numdoc.Text.Trim() + "/" + XGLOSA;

                BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiar_documento()
        {
            try
            {
                NIVEL_FORMS();

                tipimptoid = string.Empty;
                direcnume = string.Empty;
                incprec = "S";
                ssModo = "NEW";

                fechdoc.Text = string.Empty;
                moneda.SelectedValue = "S";
                tcamb.Text = "1";
                tipimptotasa.Text = string.Empty;
                ctacte.Text = string.Empty;
                nmruc.Text = string.Empty;
                ctactename.Text = string.Empty;
                direc.Text = string.Empty;

                tipfac.SelectedIndex = -1;
                serfac.Text = string.Empty;
                numfac.Text = string.Empty;
                fechfac.Text = string.Empty;

                tipguia.Text = "GR";
                serguia.Text = string.Empty;
                numguia.Text = string.Empty;
                fechguia.Text = string.Empty;

                vendperid.Text = string.Empty;
                vendpername.Text = string.Empty;

                tipnotac.Text = "NC";
                sernotac.Text = string.Empty;
                numnotac.Text = string.Empty;
                fechnotac.Text = string.Empty;

                recep_name.Text = string.Empty;
                recep_dni.Text = string.Empty;
                recep_fecha.Text = string.Empty;

                itemsT.Text = "0";
                totpzas.Text = "0";
                bruto.Text = "0";
                telef.Text = string.Empty;
                totdscto1.Text = "0";
                valventa.Text = "0";
                totimpto.Text = "0";
                totimporte.Text = "0";
                txt_valor.Text = "0";
                txt_stock.Text = "0";

                importtarj.Text = "0";
                txtefectivo.Text = "0";
                _xtarjnumoper = "";
                _xtarjetaid = 0;

                if (TablaTarjetas != null)
                    if (TablaTarjetas.Rows != null)
                    {
                        TablaTarjetas.Clear();
                    }

                data_Tabladetallemovmov();
                glosa.Text = string.Empty;
                // Venta en Combo
                princombo.Checked = false;
                canticombo.Enabled = false;
                canticombo.Value = 1;
                preccombo.Text = "0.00";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Blanquear()
        {
            try
            {
                NIVEL_FORMS();
                tipimptoid = string.Empty;
                direcnume = string.Empty;
                incprec = "N";
                ssModo = "NEW";
                moneda.SelectedValue = "S";
                tcamb.Text = "1";
                tipimptotasa.Text = string.Empty;
                ctacte.Text = string.Empty;
                nmruc.Text = string.Empty;
                ctactename.Text = string.Empty;
                direc.Text = string.Empty;

                tipfac.SelectedIndex = 0;
                serfac.Text = string.Empty;
                numfac.Text = string.Empty;
                fechfac.Text = string.Empty;

                recep_name.Text = string.Empty;
                recep_dni.Text = string.Empty;
                recep_fecha.Text = string.Empty;

                tipguia.Text = "GR";
                serguia.Text = string.Empty;
                numguia.Text = string.Empty;
                fechguia.Text = string.Empty;

                tipnotac.Text = "NC";
                sernotac.Text = string.Empty;
                numnotac.Text = string.Empty;
                fechnotac.Text = string.Empty;

                vendperid.Text = string.Empty;
                vendpername.Text = string.Empty;
                itemsT.Text = "0";
                totpzas.Text = "0";
                bruto.Text = "0";
                totdscto1.Text = "0";
                valventa.Text = "0";
                totimpto.Text = "0";
                totimporte.Text = "0";
                txt_valor.Text = "0";
                txt_stock.Text = "0";
                importtarj.Text = "0";

                if (Tabladetallemov.Rows.Count > 0) { Tabladetallemov.Rows.Clear(); griddetallemov.DataSource = Tabladetallemov; }
                else { griddetallemov.DataSource = Tabladetallemov; }

                if (TablaTarjetas.Rows.Count > 0) { TablaTarjetas.Rows.Clear(); dgbtarjetas.DataSource = TablaTarjetas; }
                else { dgbtarjetas.DataSource = TablaTarjetas; }

                glosa.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }

        private void calcular_totales()
        {
            decimal stotal = 0;
            if (Tabladetallemov != null)
            {
                if (Tabladetallemov.Rows.Count != 0)
                {
                    _cal_Igv();
                    itemsT.Text = Tabladetallemov.Rows.Count.ToString();
                    totpzas.Text = Convert.ToDecimal(Tabladetallemov.Compute("sum(cantidad)", string.Empty)).ToString("##,###,##0.00");
                    bruto.Text = Math.Round(Convert.ToDecimal(Tabladetallemov.Compute("sum(importfac)", string.Empty)), 2).ToString("##,###,##0.00");

                    stotal = Math.Round(Convert.ToDecimal(Tabladetallemov.Compute("sum(importfac)", string.Empty)), 2);
                    if (Equivalencias.Left(cbo_incprec.Text.Trim(), 1) == "S")
                    {
                        valventa.Text = Math.Round(stotal * (100 / (100 + igv)), 2).ToString("###,###,##0.00");
                        totimpto.Text = Math.Round(stotal * (100 / (100 + igv)) * (igv / 100), 2).ToString("###,###,##0.00");
                        totimporte.Text = stotal.ToString("###,###,##0.00");
                    }
                    else
                    {
                        valventa.Text = stotal.ToString("###,###,##0.00");
                        totimpto.Text = Math.Round(stotal * (igv / 100), 2).ToString("###,###,##0.00");
                        totimporte.Text = Math.Round(stotal + (stotal * (igv / 100)), 2).ToString("###,###,##0.00");
                    }

                    if (canticombo.Value > 0)
                    {
                        preccombo.Text = Convert.ToDecimal(Convert.ToDecimal(totimporte.Text) / canticombo.Value).ToString("###,###,##0.00");
                    }
                    else
                    {
                        preccombo.Text = "0.00";
                    }


                }
                else
                {
                    itemsT.Text = Tabladetallemov.Rows.Count.ToString();
                    totpzas.Text = "0";
                    bruto.Text = "0";
                    valventa.Text = "0";
                    totimpto.Text = "0";
                    totimporte.Text = "0";
                    canticombo.Value = 0;
                    preccombo.Text = "0.00";
                }
            }
        }

        private void nuevo()
        {
            tipodoc.SelectedIndex = 0;
            lstTarjGroup.SelectedIndex = -1;
            limpiar_documento();
            tipimptotasa.SelectedIndex = 0;
            form_bloqueado(false);
            get_val_fechadoc();
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_upload.Enabled = true;
            btn_detanadir.Enabled = true;
            btn_deteliminar.Enabled = true;

            ssModo = "NEW";
            serdoc.Enabled = false;
            numdoc.Enabled = false;
        }

        private void nuevo_Fijado()
        {
            lstTarjGroup.SelectedIndex = -1;
            limpiar_documento();
            tipimptotasa.SelectedIndex = 0;
            form_bloqueado(false);
            get_val_fechadoc();
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_upload.Enabled = true;
            btn_detanadir.Enabled = true;
            btn_deteliminar.Enabled = true;

            ssModo = "NEW";
            serdoc.Enabled = false;
            numdoc.Enabled = false;
        }

        private bool cabecera_valida()
        {
            bool lSigo = true;

            if (cajacerrada())
            {
                MessageBox.Show("Caja cerrada para fecha del documento, solicite apertura de caja !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lSigo = false;
            }
            if (ctacte.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese Proveedor/Cliente !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lSigo = false;
            }
            if (vendperid.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese Vendedor !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lSigo = false;
            }
            if (Tabladetallemov.Rows.Count == 0)
            {
                MessageBox.Show("Documento no tiene Items !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lSigo = false;
            }
            if (tcamb.Text.Trim() == "1")
            {
                MessageBox.Show("Actualize el Tipo de Cambio !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lSigo = false;
            }
            if (numdoc.Text.Trim().Length != 10)
            {
                MessageBox.Show("Error en númro de digitos del documento !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lSigo = false;
            }
            return lSigo;
        }

        private bool cajacerrada()
        {
            bool lSigo = false;
            try
            {
                var BE = new tb_t1_caja();
                var BL = new tb_t1_cajaBL();

                DataTable dt = new DataTable();

                BE.moduloid = modulo.ToString();
                BE.local = local.ToString();
                BE.fecha = Convert.ToDateTime(fechdoc.Text);

                dt = BL.GetAllCab(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (dt.Rows.Count>0)
                {
                    lSigo = Convert.ToBoolean(dt.Rows[0]["cerrado"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return lSigo;
        }


        private void Insert()
        {
            _cal_Igv();
            try
            {
                if (cabecera_valida())
                {
                    #region Datos de Cabecera 
                    var BL = new tb_ad_movimientosBL();
                    var BE = new tb_ad_movimientos();

                    var Detalle = new tb_ad_movimientos.Item();
                    var ListaItems = new List<tb_ad_movimientos.Item>();

                    var Detalle2 = new tb_ad_movimientos.Tarjetas();
                    var ListaTarjetas = new List<tb_ad_movimientos.Tarjetas>();
                    
                    BE.moduloid = modulo;
                    BE.local = local;
                    BE.tipodoc = tipodoc.SelectedValue.ToString();
                    BE.serdoc = serdoc.Text.Trim();
                    BE.numdoc = numdoc.Text.ToString();
                    BE.fechdoc = Convert.ToDateTime(fechdoc.Text);
                    BE.moneda = moneda.SelectedValue.ToString().Trim();
                    BE.tcamb = Convert.ToDecimal(tcamb.Text.Trim());

                    if (tipguia.Text.Trim().Length > 0 && serguia.Text.Trim().Length > 0 && numguia.Text.Trim().Length > 0)
                    {
                        almacaccionid = "21";
                        BE.almacaccionid = almacaccionid.ToString();
                    }
                    else
                    {
                        BE.almacaccionid = almacaccionid.Trim();
                    }

                    BE.tipoperacionid = tip_operacion.ToString();
                    BE.ctacteaccionid = string.Empty;
                    BE.ctacte = ctacte.Text.Trim().ToUpper();
                    BE.nmruc = nmruc.Text.Trim();
                    BE.ctactename = ctactename.Text.Trim().ToUpper();                  
                    BE.direcnume = direcnume.Trim().ToUpper();
                    BE.vendorid = vendperid.Text.ToString();

                    if (serfac.Text.Trim().Length > 0 && numfac.Text.Trim().Length > 0)
                    {
                        BE.tipfac = tipfac.SelectedItem.ToString();
                        BE.serfac = serfac.Text.Trim().ToString().PadLeft(4, '0');
                        BE.numfac = numfac.Text.Trim().ToString().PadLeft(10, '0');
                        if (!fechfac.IsEmpty)
                        {
                            BE.fechfac = Convert.ToDateTime(fechfac.Text.Trim());
                        }

                        //BE.recep_name = recep_name.Text.Trim();
                        //BE.recep_dni = recep_dni.Text.Trim();
                        //if (!recep_fecha.IsEmpty)
                        //{
                        //    BE.recep_fecha = Convert.ToDateTime(recep_fecha.Text.Trim());
                        //}
                    }

                    if (serguia.Text.Trim().Length > 0 && numguia.Text.Trim().Length > 0)
                    {
                        BE.tipguia = tipguia.Text.Trim();
                        BE.serguia = serguia.Text.Trim().ToString().PadLeft(4, '0');
                        BE.numguia = numguia.Text.Trim().ToString().PadLeft(10, '0');
                        if (!fechguia.IsEmpty)
                        {
                            BE.fechguia = Convert.ToDateTime(fechguia.Text.Trim());
                        }
                    }

                    if (sernotac.Text.Trim().Length > 0 && numnotac.Text.Trim().Length > 0)
                    {
                        BE.tipnotac = tipnotac.Text.Trim();
                        BE.sernotac = sernotac.Text.Trim().ToString().PadLeft(4, '0');
                        BE.numnotac = numnotac.Text.Trim().ToString().PadLeft(10, '0');
                        if (!fechnotac.IsEmpty)
                        {
                            BE.fechnotac = Convert.ToDateTime(fechnotac.Text.Trim());
                        }
                    }                  

                    BE.tipimptoid = tipimptotasa.SelectedValue.ToString().Trim();
                    BE.incprec = Equivalencias.Left(cbo_incprec.Text.Trim(), 1);
                    BE.items = Convert.ToDecimal(itemsT.Text.Trim());
                    BE.totpzas = Convert.ToDecimal(totpzas.Text.Trim());                
                    BE.tasaigv = igv;
                    BE.totimpto = Convert.ToDecimal(totimpto.Text.Trim());
                    BE.valventa = Convert.ToDecimal(valventa.Text.Trim());
                    BE.totimporte = Convert.ToDecimal(totimporte.Text.Trim());                   
                    BE.glosa = glosa.Text.Trim().ToUpper().ToString();
                    // Venta en Combo
                    // BE.princombo = princombo.Checked;
                    // BE.cantcombo = Convert.ToInt32(canticombo.Text.ToString());
                    // BE.preccombo = Convert.ToDecimal(preccombo.Text.ToString());
                    //
                    //try
                    //{
                    //    BE.fechcancel = Convert.ToDateTime("01/01/1900");
                    //}
                    //catch
                    //{
                    //    BE.fechcancel = Convert.ToDateTime("01/01/1900");
                    //}

                    BE.tipdid = string.Empty;
                    //BE.statborrado = string.Empty;
                    //BE.clientetipo = string.Empty;
                    //BE.modofactu = string.Empty;
                    //BE.tipodocmanejaserie = tipodocmanejaserie;
                    BE.ncaja = _cajanume.ToString();
                    BE.perianio = fechdoc.Value.Year.ToString();
                    BE.perimes = fechdoc.Value.Month.ToString().PadLeft(2, '0');
                    BE.status = "0";
                    BE.usuar = VariablesPublicas.Usuar;

                    // Agregando Datos de Cabecera 
                    if (TablaTarjetas.Rows.Count > 0)
                    {
                        //BE.Tarjetaid = Convert.ToInt32(TablaTarjetas.Rows[0]["tarjetaid"].ToString());
                        //BE.Tarjnumoper = TablaTarjetas.Rows[0]["tarjetanume"].ToString();
                        BE.tarjimporte = Convert.ToDecimal(importtarj.Text);
                    }

                    if (txtefectivo.Text.Length > 0)
                    { BE.efectivo = Convert.ToDecimal(txtefectivo.Text); }
                    else { BE.efectivo = 0; }

                    #endregion

                    /*****************************************************/

                    #region Detalle - Movimientos
                    var item = 0;
                    foreach (DataRow fila in Tabladetallemov.Rows)
                    {
                        Detalle = new tb_ad_movimientos.Item();
                        item++;
                        Detalle.fechdoc = Convert.ToDateTime(fechdoc.Text);                       
                        Detalle.tipoperacionid = "01";                     
                        Detalle.ctacte = ctacte.Text.Trim().ToUpper();                      
                        Detalle.direcnume = direcnume.Trim().ToUpper();                                            
                        Detalle.itemref = fila["itemref"].ToString();                                         
                        Detalle.productid = fila["productid"].ToString();
                        Detalle.productname = fila["productname"].ToString();
                        Detalle.ubicacion = fila["ubicacion"].ToString();
                        Detalle.unmed = fila["unmed"].ToString();

                        Detalle.cantidad = Convert.ToDecimal(fila["cantidad"].ToString());

                        Detalle.valor = Convert.ToDecimal(fila["valor"].ToString());
                        Detalle.importe = Convert.ToDecimal(fila["importe"].ToString());

                        Detalle.precioanterior = Convert.ToDecimal(fila["precioanterior"].ToString());

                        Detalle.precunit = Convert.ToDecimal(fila["precunit"].ToString());
                        Detalle.importfac = Convert.ToDecimal(fila["importfac"].ToString());
                        Detalle.totimpto = Convert.ToDecimal(fila["totimpto"].ToString());

                        Detalle.almacaccionid = almacaccionid;
                        Detalle.statcostopromed = statcostopromed.Trim();                      
                        Detalle.tasaigv = igv;
                                                                    
                        Detalle.status = "0";
                        Detalle.usuar = VariablesPublicas.Usuar;

                        if (fila["productid"].ToString().Trim().Length == 13
                            && Convert.ToDecimal(fila["cantidad"]) > 0
                            && Convert.ToDecimal(fila["importfac"]) > 0)
                        {
                            ListaItems.Add(Detalle);
                        }
                        else
                        {
                            if (Convert.ToBoolean(fila["nostock"]) == true)
                            {
                                ListaItems.Add(Detalle);
                            }
                            else
                            {
                                MessageBox.Show("Documento DETALLE EN FORMATO INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    if (ListaItems.Count == 0)
                    {
                        MessageBox.Show("DOCUMENTO SIN DETALLE Y/O DETALLE INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    #endregion

                    BE.ListaItems = ListaItems;

                    #region Detalle - Tarjetas
                    foreach (DataRow fila in TablaTarjetas.Rows)
                    {
                        Detalle2 = new tb_ad_movimientos.Tarjetas();
                        Detalle2.tarjetaid = Convert.ToInt32(fila["tarjetaid"].ToString());
                        Detalle2.tarjnumoper = fila["tarjetanume"].ToString();
                        Detalle2.moneda = moneda.SelectedValue.ToString();
                        Detalle2.tcamb = Convert.ToDecimal(tcamb.Text);
                        Detalle2.tarjimporte = Convert.ToDecimal(fila["tarjetaimpo"].ToString());                        
                        Detalle2.status = "0";
                        Detalle2.usuar = VariablesPublicas.Usuar.ToString();


                        if (Convert.ToInt32(fila["tarjetaimpo"].ToString()) > 0)
                        {
                            ListaTarjetas.Add(Detalle2);
                        }
                        else
                        {
                            MessageBox.Show("Documento DETALLE TARJETAS EN FORMATO INCORRECTO ...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    BE.ListaTarjetas = ListaTarjetas;

                    #endregion

                    if (BL.Insert(EmpresaID, BE))
                    {
                        NIVEL_FORMS();
                        //Blanquear();
                        form_bloqueado(false);
                        tipodoc.Enabled = false;
                        btn_nuevo.Enabled = true;
                        btn_grabar.Enabled = false;
                        btn_imprimir.Enabled = true;
                        btnImprimirNoval.Enabled = true;

                        btn_primero.Enabled = true;
                        btn_anterior.Enabled = true;
                        btn_siguiente.Enabled = true;
                        btn_ultimo.Enabled = true;
                        btn_salir.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Update()
        {
            _cal_Igv();
            try
            {
                if (cabecera_valida())
                {
                    #region Datos de Cabecera
                    var BL = new tb_ad_movimientosBL();
                    var BE = new tb_ad_movimientos();

                    var Detalle = new tb_ad_movimientos.Item();
                    var ListaItems = new List<tb_ad_movimientos.Item>();

                    var Detalle2 = new tb_ad_movimientos.Tarjetas();
                    var ListaTarjetas = new List<tb_ad_movimientos.Tarjetas>();

                    BE.moduloid = modulo;
                    BE.local = local;
                    BE.tipodoc = tipodoc.SelectedValue.ToString();
                    BE.serdoc = serdoc.Text.Trim();
                    BE.numdoc = numdoc.Text.ToString();
                    BE.fechdoc = Convert.ToDateTime(fechdoc.Text);
                    BE.moneda = moneda.SelectedValue.ToString().Trim();
                    BE.tcamb = Convert.ToDecimal(tcamb.Text.Trim());

                    if (tipguia.Text.Trim().Length > 0 && serguia.Text.Trim().Length > 0 && numguia.Text.Trim().Length > 0)
                    {
                        almacaccionid = "21";
                        BE.almacaccionid = almacaccionid.ToString();
                    }
                    else
                    {
                        BE.almacaccionid = almacaccionid.Trim();
                    }

                    BE.tipoperacionid = tip_operacion.ToString();
                    BE.ctacteaccionid = string.Empty;
                    BE.ctacte = ctacte.Text.Trim().ToUpper();
                    BE.nmruc = nmruc.Text.Trim();
                    BE.ctactename = ctactename.Text.Trim().ToUpper();
                    BE.direcnume = direcnume.Trim().ToUpper();
                    BE.vendorid = vendperid.Text.ToString();

                    if (serfac.Text.Trim().Length > 0 && numfac.Text.Trim().Length > 0)
                    {
                        BE.tipfac = tipfac.SelectedItem.ToString();
                        BE.serfac = serfac.Text.Trim().ToString().PadLeft(4, '0');
                        BE.numfac = numfac.Text.Trim().ToString().PadLeft(10, '0');
                        if (!fechfac.IsEmpty)
                        {
                            BE.fechfac = Convert.ToDateTime(fechfac.Text.Trim());
                        }

                        //BE.recep_name = recep_name.Text.Trim();
                        //BE.recep_dni = recep_dni.Text.Trim();
                        //if (!recep_fecha.IsEmpty)
                        //{
                        //    BE.recep_fecha = Convert.ToDateTime(recep_fecha.Text.Trim());
                        //}
                    }

                    if (serguia.Text.Trim().Length > 0 && numguia.Text.Trim().Length > 0)
                    {
                        BE.tipguia = tipguia.Text.Trim();
                        BE.serguia = serguia.Text.Trim().ToString().PadLeft(4, '0');
                        BE.numguia = numguia.Text.Trim().ToString().PadLeft(10, '0');
                        if (!fechguia.IsEmpty)
                        {
                            BE.fechguia = Convert.ToDateTime(fechguia.Text.Trim());
                        }
                    }

                    if (sernotac.Text.Trim().Length > 0 && numnotac.Text.Trim().Length > 0)
                    {
                        BE.tipnotac = tipnotac.Text.Trim();
                        BE.sernotac = sernotac.Text.Trim().ToString().PadLeft(4, '0');
                        BE.numnotac = numnotac.Text.Trim().ToString().PadLeft(10, '0');
                        if (!fechnotac.IsEmpty)
                        {
                            BE.fechnotac = Convert.ToDateTime(fechnotac.Text.Trim());
                        }
                    }

                    BE.tipimptoid = tipimptotasa.SelectedValue.ToString().Trim();
                    BE.incprec = Equivalencias.Left(cbo_incprec.Text.Trim(), 1);
                    BE.items = Convert.ToDecimal(itemsT.Text.Trim());
                    BE.totpzas = Convert.ToDecimal(totpzas.Text.Trim());
                    BE.tasaigv = igv;
                    BE.totimpto = Convert.ToDecimal(totimpto.Text.Trim());
                    BE.valventa = Convert.ToDecimal(valventa.Text.Trim());
                    BE.totimporte = Convert.ToDecimal(totimporte.Text.Trim());
                    BE.glosa = glosa.Text.Trim().ToUpper().ToString();
                    // Venta en Combo
                    // BE.princombo = princombo.Checked;
                    // BE.cantcombo = Convert.ToInt32(canticombo.Text.ToString());
                    // BE.preccombo = Convert.ToDecimal(preccombo.Text.ToString());
                    //
                    //try
                    //{
                    //    BE.fechcancel = Convert.ToDateTime("01/01/1900");
                    //}
                    //catch
                    //{
                    //    BE.fechcancel = Convert.ToDateTime("01/01/1900");
                    //}

                    BE.tipdid = string.Empty;
                    //BE.statborrado = string.Empty;
                    //BE.clientetipo = string.Empty;
                    //BE.modofactu = string.Empty;
                    //BE.tipodocmanejaserie = tipodocmanejaserie;
                    BE.ncaja = _cajanume.ToString();
                    BE.perianio = fechdoc.Value.Year.ToString();
                    BE.perimes = fechdoc.Value.Month.ToString().PadLeft(2, '0');
                    BE.status = "0";
                    BE.usuar = VariablesPublicas.Usuar;

                    // Agregando Datos de Cabecera 
                    if (TablaTarjetas.Rows.Count > 0)
                    {
                        //BE.Tarjetaid = Convert.ToInt32(TablaTarjetas.Rows[0]["tarjetaid"].ToString());
                        //BE.Tarjnumoper = TablaTarjetas.Rows[0]["tarjetanume"].ToString();
                        BE.tarjimporte = Convert.ToDecimal(importtarj.Text);
                    }

                    if (txtefectivo.Text.Length > 0)
                    { BE.efectivo = Convert.ToDecimal(txtefectivo.Text); }
                    else { BE.efectivo = 0; }
                    #endregion

                    /*****************************************************/

                    #region Movimientos - Detalle

                    var item = 0;
                    foreach (DataRow fila in Tabladetallemov.Rows)
                    {
                        Detalle = new tb_ad_movimientos.Item();
                        item++;
                        Detalle.fechdoc = Convert.ToDateTime(fechdoc.Text);
                        Detalle.tipoperacionid = "01";
                        Detalle.ctacte = ctacte.Text.Trim().ToUpper();
                        Detalle.direcnume = direcnume.Trim().ToUpper();
                        Detalle.itemref = fila["itemref"].ToString();
                        Detalle.productid = fila["productid"].ToString();
                        Detalle.productname = fila["productname"].ToString();
                        Detalle.ubicacion = fila["ubicacion"].ToString();
                        Detalle.unmed = fila["unmed"].ToString();

                        Detalle.cantidad = Convert.ToDecimal(fila["cantidad"].ToString());

                        Detalle.valor = Convert.ToDecimal(fila["valor"].ToString());
                        Detalle.importe = Convert.ToDecimal(fila["importe"].ToString());

                        Detalle.precioanterior = Convert.ToDecimal(fila["precioanterior"].ToString());

                        Detalle.precunit = Convert.ToDecimal(fila["precunit"].ToString());
                        Detalle.importfac = Convert.ToDecimal(fila["importfac"].ToString());
                        Detalle.totimpto = Convert.ToDecimal(fila["totimpto"].ToString());

                        Detalle.almacaccionid = almacaccionid;
                        Detalle.statcostopromed = statcostopromed.Trim();
                        Detalle.tasaigv = igv;

                        Detalle.status = "0";
                        Detalle.usuar = VariablesPublicas.Usuar;

                        if (fila["productid"].ToString().Trim().Length == 13
                            && Convert.ToDecimal(fila["cantidad"]) > 0
                            && Convert.ToDecimal(fila["importfac"]) > 0)
                        {
                            ListaItems.Add(Detalle);
                        }
                        else
                        {
                            if (Convert.ToBoolean(fila["nostock"]) == true)
                            {
                                ListaItems.Add(Detalle);
                            }
                            else
                            {
                                MessageBox.Show("Documento DETALLE EN FORMATO INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    if (ListaItems.Count == 0)
                    {
                        MessageBox.Show("DOCUMENTO SIN DETALLE Y/O DETALLE INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    #endregion

                    BE.ListaItems = ListaItems;

                    #region Detalle - Tarjetas
                    foreach (DataRow fila in TablaTarjetas.Rows)
                    {
                        Detalle2 = new tb_ad_movimientos.Tarjetas();
                        Detalle2.tarjetaid = Convert.ToInt32(fila["tarjetaid"].ToString());
                        Detalle2.tarjnumoper = fila["tarjetanume"].ToString();
                        Detalle2.moneda = moneda.SelectedValue.ToString();
                        Detalle2.tcamb = Convert.ToDecimal(tcamb.Text);
                        Detalle2.tarjimporte = Convert.ToDecimal(fila["tarjetaimpo"].ToString());                       
                        Detalle2.status = "0";
                        Detalle2.usuar = VariablesPublicas.Usuar.ToString();

                        if (Convert.ToInt32(fila["tarjetaimpo"]) > 0)
                        {
                            ListaTarjetas.Add(Detalle2);
                        }
                        else
                        {
                            MessageBox.Show("Documento DETALLE TARJETAS EN FORMATO INCORRECTO ...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    BE.ListaTarjetas = ListaTarjetas;

                    #endregion


                    if (BL.Update(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("M");
                        NIVEL_FORMS();
                        MessageBox.Show("Datos Modificados Correctamente !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        form_bloqueado(false);
                        Blanquear();
                        tipodoc.Enabled = false;
                        btn_nuevo.Enabled = true;
                        btn_imprimir.Enabled = true;
                        btnImprimirNoval.Enabled = true;

                        btn_primero.Enabled = true;
                        btn_anterior.Enabled = true;
                        btn_siguiente.Enabled = true;
                        btn_ultimo.Enabled = true;
                        btn_salir.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Delete()
        {
            try
            {
                if (ctacte.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Proveedor/Cliente !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (Tabladetallemov.Rows.Count == 0)
                    {
                        MessageBox.Show("Documento no tiene Items !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (numdoc.Text.Trim().Length == 10)
                        {
                            var BL = new tb_ad_movimientosBL();
                            var BE = new tb_ad_movimientos();

                            //BE.dominioid = dominio;
                            BE.moduloid = modulo;
                            BE.local = local;
                            BE.tipodoc = tipodoc.SelectedValue.ToString();
                            BE.serdoc = serdoc.Text.Trim();
                            BE.numdoc = numdoc.Text.Trim();
                            BE.status = "9";
                            BE.usuar = VariablesPublicas.Usuar;

                            if (BL.Delete(EmpresaID, BE))
                            {
                                SEGURIDAD_LOG("E");
                                NIVEL_FORMS();
                                MessageBox.Show("Datos eliminados correctamente !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                limpiar_documento();
                                form_bloqueado(false);
                                tipodoc.Enabled = false;
                                numdoc.Enabled = false;

                                btn_nuevo.Enabled = true;

                                btn_primero.Enabled = true;
                                btn_anterior.Enabled = true;
                                btn_siguiente.Enabled = true;
                                btn_ultimo.Enabled = true;
                                btn_salir.Enabled = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_ventas_Load(object sender, EventArgs e)
        {
            EmpresaID = VariablesPublicas.EmpresaID.Trim();
            dominio = ((D60Tienda.MainTienda)MdiParent).dominioid;
            modulo = ((D60Tienda.MainTienda)MdiParent).moduloid;
            local = ((D60Tienda.MainTienda)MdiParent).local;
            novalidastock = ((D60Tienda.MainTienda)MdiParent).novalidastock;


            data_cbo_tipodoc();
            data_cbo_moneda();
            get_tipimptoid();
            _cal_Igv();
            CargarTarjetas();
            //_ManejaListPrec(); -- bloqueado temporalmente
            Crear_CurDetalle();
            Crear_CurTarjetas();
            limpiar_documento();
            form_bloqueado(false);
            //CargarListaPrecios();
            btn_nuevo.Enabled = true;
            btn_primero.Enabled = true;
            btn_anterior.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_ultimo.Enabled = true;
            btn_salir.Enabled = true;
            pdtimagen.Visible = false;
        }

        private void _ManejaListPrec()
        {
            var BL = new sys_localBL();
            var BE = new tb_sys_local();
            var dt = new DataTable();
            BE.dominioid = dominio.ToString();
            BE.moduloid = modulo.ToString();
            BE.local = local.ToString();

            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                ManejaListPrec = Convert.ToBoolean(dt.Rows[0]["manejalistprec"].ToString());
            }
        }

        private void Crear_CurDetalle()
        {
            Tabladetallemov = new DataTable("detallemov");

            Tabladetallemov.Columns.Add("items", typeof(String));
            Tabladetallemov.Columns.Add("itemref", typeof(String));
            Tabladetallemov.Columns.Add("productid", typeof(String));
            Tabladetallemov.PrimaryKey = new DataColumn[] { Tabladetallemov.Columns["productid"] };
            Tabladetallemov.Columns["productid"].Unique = true;

            Tabladetallemov.Columns.Add("productname", typeof(String));
            Tabladetallemov.Columns.Add("rollo", typeof(String));

            Tabladetallemov.Columns.Add("stock", typeof(Decimal));
            Tabladetallemov.Columns["stock"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("stock_old", typeof(Decimal));
            Tabladetallemov.Columns["stock_old"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("precventa", typeof(Decimal));
            Tabladetallemov.Columns["precventa"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("costoultimo", typeof(Decimal));
            Tabladetallemov.Columns["costoultimo"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("costopromed", typeof(Decimal));
            Tabladetallemov.Columns["costopromed"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("cantidad", typeof(Decimal));
            Tabladetallemov.Columns["cantidad"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("cantidad_old", typeof(Decimal));
            Tabladetallemov.Columns["cantidad_old"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("valor", typeof(Decimal));
            Tabladetallemov.Columns["valor"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("importe", typeof(Decimal));
            Tabladetallemov.Columns["importe"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("precioanterior", typeof(Decimal));
            Tabladetallemov.Columns["precioanterior"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("precunit", typeof(Decimal));
            Tabladetallemov.Columns["precunit"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("importfac", typeof(Decimal));
            Tabladetallemov.Columns["importfac"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("totimpto", typeof(Decimal));
            Tabladetallemov.Columns["totimpto"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("almacaccionid", typeof(String));
            Tabladetallemov.Columns.Add("ubicacion", typeof(String));
            Tabladetallemov.Columns.Add("unmed", typeof(String));
            Tabladetallemov.Columns.Add("nostock", typeof(Boolean));
            Tabladetallemov.Columns["nostock"].DefaultValue = false;
        }

        private void Crear_CurTarjetas()
        {
            TablaTarjetas = new DataTable("curTarjetas");

            TablaTarjetas.Columns.Add("tarjetaid", typeof(int));
            TablaTarjetas.Columns.Add("tarjetaname", typeof(String));
            TablaTarjetas.Columns.Add("ddnni", typeof(String));
            TablaTarjetas.Columns.Add("tarjetanume", typeof(String));
            TablaTarjetas.Columns.Add("tarjetaimpo", typeof(Decimal));
            TablaTarjetas.Columns.Add("tarjetalogo", typeof(System.Byte[]));
        }

        private void Frm_movimiento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                if (!griddetallemov.ReadOnly)
                {
                    btn_detanadir_Click(sender, e);
                }
            }


            if (e.KeyCode == Keys.Delete)
            {
                if (!griddetallemov.ReadOnly)
                {
                    btn_deteliminar_Click(sender, e);
                }
            }


            if (e.Control && e.KeyCode == Keys.G)
            {
                if (btn_grabar.Enabled)
                {
                    btn_grabar_Click(sender, e);
                }
            }

            if (e.Control && e.KeyCode == Keys.N)
            {
                if (btn_nuevo.Enabled)
                {
                    btn_nuevo_Click(sender, e);
                }
            }

            if (e.Control && e.KeyCode == Keys.Enter)
            {
            }

            if (e.KeyCode == Keys.Escape)
            {
                if (btn_cancelar.Enabled)
                {
                    form_accion_cancelEdicion(1);
                }
                else
                {
                    btn_salir_Click(sender, e);
                }
            }
        }

        private void CargarTarjetas()
        {
            try
            {
                var BE = new tb_t1_tarjeta();
                var BL = new tb_t1_tarjetaBL();
                var table = BL.GetAll(EmpresaID, BE).Tables[0];

                lstTarjGroup.DataSource = table;
                lstTarjGroup.ValueMember = "tarjgrupoid";
                lstTarjGroup.DisplayMember = "tarjgruponame";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarListaPrecios()
        {
            //try
            //{
            //    var BE = new tb_ad_ListaPrecio();
            //    var BL = new tb_ad_ListaPrecioBL();

            //    BE.moduloid = modulo;
            //    BE.local = local;
            //    BE.fecha = Convert.ToDateTime(fechdoc.Text);

            //    var table = BL.GetVigentes(EmpresaID, BE).Tables[0];
            //    if (table.Rows.Count > 0)
            //    {
            //        lstListaprec.DataSource = table;
            //        lstListaprec.ValueMember = "listaprecid";
            //        lstListaprec.DisplayMember = "listaprecname";
            //        lstListaprec.SelectedIndex = 0;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void Frm_movimiento_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btn_grabar.Enabled)
            {
                MessageBox.Show("Finalice edición para cerrar formulario", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void _RecuperarNcaja()
        {
            var xDoc = new XmlDocument();
            var xArchivo = @"c:\ErpBapSoftNet_Config\BapConfig.cfg";
            xDoc.Load(xArchivo);

            var configuration = xDoc.GetElementsByTagName("configuration");
            var lista = ((XmlElement)configuration[0]).GetElementsByTagName("Paramlocal");

            foreach (XmlElement nodo in lista)
            {
                var i = 0;
                var ncajanume = nodo.GetElementsByTagName("cajanume");
                var nperimes = nodo.GetElementsByTagName("perimes");
                _cajanume = ncajanume[i].InnerText;
                _perimes = nperimes[i].InnerText;
            }
        }

        private void tipodoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RecuperarNcaja();
            perianio = string.Empty;
            almacaccionid = string.Empty;
            statcostopromed = string.Empty;
            tiptransac = string.Empty;
            fechadocedit = false;
            tipodocautomatico = false;
            tipodocmanejaserie = false;
            cbo_incprec.SelectedIndex = 0;
            statusDoc = true;

            if (btn_nuevo.Enabled == false)
            {
                limpiar_documento();
                select_tipodoc();
                get_val_fechadoc();
                ValControls();
                if (statusDoc)
                {
                    form_bloqueado(true);
                    btn_cancelar.Enabled = true;
                    btn_grabar.Enabled = true;
                    btn_upload.Enabled = true;
                    btn_detanadir.Enabled = true;
                    btn_deteliminar.Enabled = true;
                    ctacte.Focus();
                }
            }
            else
            {
                select_tipodoc();
                numdoc.Text = string.Empty;
            }
        }

        private void serdoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(numdoc, e);
        }

        private void numdoc_LostFocus(object sender, System.EventArgs e)
        {
            form_cargar_datos(string.Empty);
        }

        private void numdoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(numdoc, e);
        }

        private void fechdoc_ValueChanged(object sender, EventArgs e)
        {
            get_tipocambio(fechdoc.Text);
        }

        private void fechdoc_LostFocus(object sender, System.EventArgs e)
        {
            get_tipocambio(fechdoc.Text);
        }

        private void ctacte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaClientes(string.Empty);
            }
            if (e.KeyCode == Keys.Enter)
            {
                nmruc.Focus();
            }
        }

        private void ctacte_LostFocus(object sender, System.EventArgs e)
        {
            ValidaCliente();
        }

        private void nmruc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaClientes(string.Empty);
            }
            if (e.KeyCode == Keys.Enter)
            {
                glosa.Focus();
            }
        }

        private void nmruc_LostFocus(object sender, System.EventArgs e)
        {
            if (tipodoc.SelectedValue.ToString() == "TK")
            {
                btnextraersunat.Image = global::BapFormulariosNet.Properties.Resources.go_reniec;
                lblruc.Text = "DNI/RUC:";
                lbltitulo.Text = "TICKET";

                if (nmruc.ToString().Trim().Length == 8 || nmruc.ToString().Trim().Length == 8)
                {
                    if (nmruc.ToString().Trim().Length == 11)
                    {
                        btnextraersunat.Image = global::BapFormulariosNet.Properties.Resources.go_sunat1;
                    }
                    else
                    {
                        btnextraersunat.Image = global::BapFormulariosNet.Properties.Resources.go_reniec;
                    }
                }
            }
        }

        private void direcname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaClientesDireccion(string.Empty);
            }
        }

        private void serguia_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(numdoc, e);
        }

        private void serguia_LostFocus(object sender, System.EventArgs e)
        {
            var numdo = string.Empty;
            if (serguia.Text.Trim().Length > 0)
            {
                numdo = serguia.Text.Trim().PadLeft(4, '0');
            }
            serguia.Text = numdo;
        }

        private void sernotac_LostFocus(object sender, System.EventArgs e)
        {
            var numdo = string.Empty;
            if (sernotac.Text.Trim().Length > 0)
            {
                numdo = sernotac.Text.Trim().PadLeft(4, '0');
            }
            sernotac.Text = numdo;
        }


        private void numguia_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(numdoc, e);
        }


        private void numguia_LostFocus(object sender, System.EventArgs e)
        {
        }

        private void numnotac_LostFocus(object sender, System.EventArgs e)
        {
            var numdo = string.Empty;
            if (numnotac.Text.Trim().Length > 0)
            {
                numdo = numnotac.Text.Trim().PadLeft(10, '0');
            }
            numnotac.Text = numdo;
        }


        private void sernotac_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(numdoc, e);
        }
        private void numnotac_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(numdoc, e);
        }

        private void fechguia_ValueChanged(object sender, EventArgs e)
        {

        }

        private void fechnotac_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
            {
                if (chkfijar.Checked == true)
                {
                    nuevo_Fijado();
                    tipodoc_SelectedIndexChanged(sender, e);
                    if (Tabladetallemov.Rows.Count > 0)
                    {
                        Tabladetallemov.Rows.Clear();
                    }
                }
                else
                {
                    nuevo();
                }
            }
        }


        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0")
            {
                ssModo = "EDIT";
                form_bloqueado(true);
                nmruc.Focus();

                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
                btn_upload.Enabled = true;
                btn_detanadir.Enabled = true;
                btn_deteliminar.Enabled = true;
            }
        }


        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            form_accion_cancelEdicion(1);
        }



        private void btn_grabar_Click(object sender, EventArgs e)
        {
            var sw_prosigue = false;
            if (ssModo == "NEW")
            {
                if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
                {
                    Insert();
                }
            }
            else
            {
                if (XNIVEL == "0" || XNIVEL == "1")
                {
                    sw_prosigue = (MessageBox.Show("¿Desea Modificar Documento Actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                    if (sw_prosigue)
                    {
                        Update();
                    }
                }
            }
        }



        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0")
            {
                var sw_prosigue = false;
                sw_prosigue = (MessageBox.Show("¿Desea Eliminar Documento Actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                if (sw_prosigue)
                {
                    Delete();
                }
            }
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            if (ssModo == "NEW")
            {
                if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
                {
                    Insert();
                }
            }

            var MiProceso = new System.Diagnostics.Process();
            MiProceso.StartInfo.WorkingDirectory = @"C:\ErpBapSoftNet_Config\dosprint";
            MiProceso.StartInfo.FileName = "printdoc.exe";

            MiProceso.StartInfo.Arguments = dominio.Trim()
                + modulo.Trim()
                + local.Trim()
                + tipodoc.SelectedValue.ToString()
                + serdoc.Text.Trim().PadLeft(4, '0')
                + numdoc.Text.Trim().PadLeft(10, '0')
                + "S" + " "
                + "gspTbMeMovimientos_PRINTDOC" + " "
                + VariablesPublicas.EmpresaID + " "
                + tipodoc.SelectedValue.ToString() + ".FMT";

            MiProceso.Start();
            MiProceso.WaitForExit();
            MiProceso.Close();
            MiProceso.Dispose();
        }


        private void btn_primero_Click(object sender, EventArgs e)
        {
            form_cargar_datos(Genericas.primero);
        }
        private void btn_anterior_Click(object sender, EventArgs e)
        {
            form_cargar_datos(Genericas.anterior);
        }
        private void btn_siguiente_Click(object sender, EventArgs e)
        {
            form_cargar_datos(Genericas.siguiente);
        }
        private void btn_ultimo_Click(object sender, EventArgs e)
        {
            form_cargar_datos(Genericas.ultimo);
        }
        private void btn_detanadir_Click(object sender, EventArgs e)
        {
            try
            {
                if (almacaccionid.Trim().Length == 0)
                {
                    MessageBox.Show("Seleccione Tipo de Documento !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (tcamb.Text.Trim() == "1")
                {
                    MessageBox.Show("Actualize el Tipo de Cambio !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (griddetallemov.Enabled)
                {
                    if (griddetallemov.Rows.Count > 0)
                    {
                        if (griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["productid"].Value.ToString().Trim().Length > 0)
                        {
                            griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["productid"].Value.ToString();
                            griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["productname"].Value.ToString();
                            Tabladetallemov.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetallemov));
                            Tabladetallemov.Rows[Tabladetallemov.Rows.Count - 1]["items"] = VariablesPublicas.CalcMaxField(Tabladetallemov, "items", 5);

                            griddetallemov.CurrentCell = griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["productid"];
                            griddetallemov.BeginEdit(true);
                        }
                        else
                        {
                            MessageBox.Show("Ingrese producto !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        Tabladetallemov.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetallemov));
                        Tabladetallemov.Rows[Tabladetallemov.Rows.Count - 1]["items"] = VariablesPublicas.CalcMaxField(Tabladetallemov, "items", 5);
                        griddetallemov.CurrentCell = griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["productid"];
                        griddetallemov.BeginEdit(true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_deteliminar_Click(object sender, EventArgs e)
        {
            var lc_cont = 0;
            var xcoditem = string.Empty;
            if ((griddetallemov.CurrentRow != null))
            {
                xcoditem = griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["item"].Value.ToString();
                for (lc_cont = 0; lc_cont <= Tabladetallemov.Rows.Count - 1; lc_cont++)
                {
                    if (Tabladetallemov.Rows[lc_cont]["items"].ToString() == xcoditem)
                    {
                        Tabladetallemov.Rows[lc_cont].Delete();
                        Tabladetallemov.AcceptChanges();
                        break;
                    }
                }
                for (lc_cont = 0; lc_cont <= Tabladetallemov.Rows.Count - 1; lc_cont++)
                {
                    Tabladetallemov.Rows[lc_cont]["items"] = VariablesPublicas.PADL(Convert.ToString(lc_cont + 1), 5, "0");
                }
                calcular_totales();
            }
        }

        private void Recibedetallemov(DataTable resultado)
        {
            if (resultado.Rows.Count > 0)
            {
                Tabladetallemov = resultado;
                griddetallemov.DataSource = Tabladetallemov;
                calcular_totales();
            }
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
            var oform = new Seguridadlog.FrmSeguridad();
            var xclave = VariablesPublicas.EmpresaID + "-" + modulo + "-" + tipodoc.Text.Trim() + "-" + serdoc.Text.Trim() + "-" + numdoc.Text.Trim();
            oform._Nombre = Name;
            oform._ClaveForm = xclave;
            oform.Owner = this;
            oform.ShowDialog();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quieres cerrar el formulario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void data_TablaTarjetas()
        {
            try
            {
                var BL = new tb_ad_movimientostarjBL();
                var BE = new tb_ad_movimientostarj();
                var dt = new DataTable();
                BE.moduloid = modulo;
                BE.local = local;
                BE.tipodoc = tipodoc.SelectedValue.ToString().Trim();
                BE.serdoc = serdoc.Text.Trim().PadLeft(4, '0');
                BE.numdoc = numdoc.Text.Trim().PadLeft(6, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];

                foreach (DataRow fila in dt.Rows)
                {
                    row = TablaTarjetas.NewRow();
                    row["tarjetaid"] = fila["tarjetaid"].ToString();
                    row["tarjetaimpo"] = fila["tarjimporte"].ToString();
                    row["tarjetanume"] = fila["tarjnumoper"].ToString().Trim();
                    row["tarjetaname"] = fila["tarjetaname"].ToString().Trim();
                    row["tarjetalogo"] = fila["tarjetalogo"];
                    TablaTarjetas.Rows.Add(row);
                }
                dgbtarjetas.DataSource = TablaTarjetas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void data_Tabladetallemovmov()
        {
            try
            {
                Decimal xxprecventa = 0;
                Decimal xxcostoultimo = 0;
                Decimal xxstock = 0;
                Decimal xxcostopromed = 0;
                griddetallemov.AutoGenerateColumns = false;

                var BL = new tb_ad_movimientosBL();
                var BE = new tb_ad_movimientos();
                var dt = new DataTable();
                BE.moduloid = modulo;
                BE.local = local;
                BE.tipodoc = tipodoc.SelectedValue.ToString().Trim();
                BE.serdoc = serdoc.Text.Trim().PadLeft(4, '0');
                BE.numdoc = numdoc.Text.Trim().PadLeft(6, '0');

                dt = BL.GetAll_datosdetalle(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    statcostopromed = dt.Rows[0]["statcostopromed"].ToString();
                    tiptransac = dt.Rows[0]["tiptransac"].ToString();
                    incprec = dt.Rows[0]["incprec"].ToString().Trim();
                }

                if (Tabladetallemov != null)
                {
                    Tabladetallemov.Clear();
                }

                foreach (DataRow fila in dt.Rows)
                {
                    var BL2 = new tb_ad_local_stockBL();
                    var BE2 = new tb_ad_local_stock();
                    var dt2 = new DataTable();
                    BE2.moduloid = modulo;
                    BE2.productid = fila["productid"].ToString();
                    dt2.Clear();
                    dt2 = BL2.GetAll(EmpresaID, BE2).Tables[0];

                    if (dt2.Rows.Count > 0)
                    {
                        if (almacaccionid.Trim() == "20" || almacaccionid.Trim() == "21")
                        {
                            lbl_valor.Text = "Cost.Prom";
                            xxprecventa = 0;
                            xxcostopromed = Convert.ToDecimal(dt2.Rows[0]["costopromed"]);
                        }
                        else
                        {
                            if (almacaccionid.Trim() == "10" || almacaccionid.Trim() == "11")
                            {
                                lbl_valor.Text = "Cost.Ultm";
                                xxcostoultimo = Convert.ToDecimal(dt2.Rows[0]["costoultimo"]);
                            }
                        }
                        xxstock = Convert.ToDecimal(dt2.Rows[0]["stock"]);
                    }

                    row = Tabladetallemov.NewRow();
                    row["itemref"] = fila["itemref"].ToString();
                    row["items"] = fila["items"].ToString();
                    row["productid"] = fila["productid"].ToString().Trim();
                    row["productname"] = fila["productname"].ToString().Trim();
                    row["rollo"] = fila["rollo"].ToString();
                    row["stock"] = xxstock;
                    row["stock_old"] = xxstock;
                    row["precventa"] = xxprecventa;
                    row["costoultimo"] = xxcostoultimo;
                    row["costopromed"] = xxcostopromed;

                    var cantidad = Math.Round(Convert.ToDecimal(fila["cantidad"]), 4);
                    var cantidadcta = Math.Round(Convert.ToDecimal(fila["cantidadcta"]), 4);
                    Decimal total;
                    total = cantidad - cantidadcta;

                    row["cantidad"] = total;

                    row["cantidad_old"] = Math.Round(Convert.ToDecimal(fila["cantidad"]), 4);
                    row["precunit"] = Math.Round(Convert.ToDecimal(Convert.ToDecimal(fila["precunit"]).ToString("###,###,##0.000000")), 6);
                    row["importfac"] = Math.Round(Convert.ToDecimal(fila["importfac"]), 2);
                    row["valor"] = Math.Round(Convert.ToDecimal(fila["valor"]), 6);
                    row["importe"] = Math.Round(Convert.ToDecimal(fila["importe"]), 6);
                    row["totimpto"] = Math.Round(Math.Round(Convert.ToDecimal(fila["importe"]), 6) * (Convert.ToDecimal(18) / 100), 6);
                    row["almacaccionid"] = almacaccionid.Trim();
                    row["unmed"] = fila["unmed"].ToString().Trim();
                    row["ubicacion"] = fila["ubicacion"].ToString().Trim();
                    row["nostock"] = xnostock;
                    Tabladetallemov.Rows.Add(row);
                }
                griddetallemov.DataSource = Tabladetallemov;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidaTabladetallemovmov(String xproductid)
        {
            Decimal xprecio = 0, xprecunit = 0, xcantidad = 0, xcostoprom = 0, tipcamb = 0;
            var desct1 = 0;
            Decimal imporfac = 0;
            Decimal import = 0;
            Decimal totimpx = 0;

            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productname"].Value = string.Empty;
            txt_stock.Text = "0";
            txt_valor.Text = "0";
            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["precunit"].Value = "0";
            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["importfac"].Value = "0";

            if (xproductid.Trim().Length == 13)
            {
                var BL = new tb_ad_local_stockBL();
                var BE = new tb_ad_local_stock();
                var DT = new DataTable();

                BE.moduloid = modulo;
                BE.local = local;
                BE.productid = xproductid;

                DT = BL.GetAll(EmpresaID, BE).Tables[0];

                if (DT.Rows.Count > 0)
                {
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productid"].Value = DT.Rows[0]["productid"].ToString().Trim();
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productname"].Value = DT.Rows[0]["productname"].ToString().Trim();
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["unmed"].Value = DT.Rows[0]["unmed"].ToString().Trim();


                    Decimal lsStock = 0, dtCantidad = 0, mvCantidad = 0, dtstock = 0;

                    lsStock = Convert.ToDecimal(DT.Rows[0]["stock"].ToString().Trim().PadLeft(1, '0'));
                    dtCantidad = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad"].Value);
                    mvCantidad = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad_old"].Value);

                    if (almacaccionid.Substring(0, 1) == "1")
                    {
                        dtstock = lsStock + dtCantidad - mvCantidad;
                    }
                    else
                    {
                        if (almacaccionid.Substring(0, 1) == "2")
                        {
                            dtstock = lsStock - dtCantidad + mvCantidad;
                        }
                    }

                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["stock_old"].Value = lsStock;
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["stock"].Value = dtstock;
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["dalmacaccionid"].Value = almacaccionid.ToString().Trim();
                    txt_stock.Text = Convert.ToString(dtstock);

                    if (almacaccionid.Substring(0, 1) == "2")
                    {
                        xprecventa = Convert.ToDecimal(Convert.ToDecimal(DT.Rows[0]["precventa"]).ToString("###,###,##0.000000"));
                        xprecio = Convert.ToDecimal(Convert.ToDecimal(DT.Rows[0]["costoultimo"]).ToString("###,###,##0.000000"));
                        txt_valor.Text = Convert.ToDecimal(DT.Rows[0]["costopromed"].ToString().Trim().PadLeft(1, '0')).ToString("###,###,##0.0000");
                        xcostoprom = Convert.ToDecimal(DT.Rows[0]["costopromed"].ToString().Trim().PadLeft(1, '0'));
                    }
                    else
                    {
                        if (almacaccionid.Substring(0, 1) == "1")
                        {
                            xcostoultimo = Convert.ToDecimal(Convert.ToDecimal(DT.Rows[0]["costoultimo"]).ToString("###,###,##0.000000"));
                            xprecio = Convert.ToDecimal(Convert.ToDecimal(DT.Rows[0]["costoultimo"]).ToString("###,###,##0.000000"));
                            txt_valor.Text = Convert.ToDecimal(DT.Rows[0]["costoultimo"].ToString().Trim().PadLeft(1, '0')).ToString("###,###,##0.0000");
                        }
                    }

                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["precventa"].Value = xprecventa;
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["costoultimo"].Value = xcostoultimo;
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["costopromed"].Value = xcostoprom;

                    xcantidad = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad"].Value);

                    imporfac = Math.Round(xcantidad * Convert.ToDecimal(xprecio), 6);
                    tipcamb = Convert.ToDecimal(tcamb.Text.Trim());

                    if (tipcamb <= 0)
                    {
                        tipcamb = 1;
                    }

                    if (moneda.SelectedValue.ToString() == "S")
                    {
                        xprecunit = xprecio;
                    }
                    else
                    {
                        xprecunit = xprecio / tipcamb;
                    }

                    _cal_Igv();


                    desct1 = 0;
                    import = imporfac * (1 - (desct1 / 100));
                    if (Equivalencias.Left(cbo_incprec.Text.Trim(), 1) == "S")
                    {
                        totimpx = Math.Round(import * (Convert.ToDecimal(igv) / (100 + Convert.ToDecimal(igv))), 6);
                    }
                    else
                    {
                        totimpx = Math.Round(import * (Convert.ToDecimal(igv) / 100), 6);
                    }

                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["valor"].Value = xprecunit;
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["importe"].Value = Math.Round(xcantidad * xprecunit, 6);
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["dtotimpto"].Value = totimpx;

                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad"].Value = xcantidad;
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["precunit"].Value = xprecunit;
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["importfac"].Value = Math.Round(imporfac, 2);
                    Tabladetallemov.AcceptChanges();
                    griddetallemov.CurrentCell = griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["cantidad"];
                }
                else
                {
                    MessageBox.Show("Producto no existe en tabla LOCAL_STOCK !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Producto no existe !!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidaTabladetallemovcopia(String vaproductid)
        {
            var xproductid = string.Empty;
            Decimal xprecio = 0, xprecunit = 0, xcantidad = 0, xcostoprom = 0, tipcamb = 0;
            var desct1 = 0;
            Decimal imporfac = 0;
            Decimal import = 0;
            Decimal totimpx = 0;

            xproductid = vaproductid.Trim();

            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productname"].Value = string.Empty;
            txt_stock.Text = "0";
            txt_valor.Text = "0";
            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["precunit"].Value = "0";
            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["importfac"].Value = "0";

            if (xproductid.Trim().Length == 13)
            {
                var BL = new tb_ad_local_stockBL();
                var BE = new tb_ad_local_stock();
                var DT = new DataTable();
                BE.moduloid = modulo;
                BE.productid = xproductid;

                DT = BL.GetAll(EmpresaID, BE).Tables[0];

                if (DT.Rows.Count > 0)
                {
                    foreach (DataGridViewRow fila in griddetallemov.Rows)
                    {
                        foreach (DataGridViewColumn col in griddetallemov.Columns)
                        {
                            if (fila.Index >= 0)
                            {
                                if (Convert.ToString(griddetallemov.Rows[fila.Index].Cells["productid"].Value) == vaproductid.ToString())
                                {
                                    griddetallemov.Rows[fila.Index].Cells["productid"].Value = DT.Rows[0]["productid"].ToString().Trim();
                                    griddetallemov.Rows[fila.Index].Cells["productname"].Value = DT.Rows[0]["productname"].ToString().Trim();
                                    griddetallemov.Rows[fila.Index].Cells["rollo"].Value = string.Empty;

                                    Decimal lsStock = 0, dtCantidad = 0, mvCantidad = 0, dtstock = 0;

                                    lsStock = Convert.ToDecimal(DT.Rows[0]["stock"].ToString().Trim().PadLeft(1, '0'));
                                    dtCantidad = Convert.ToDecimal(griddetallemov.Rows[fila.Index].Cells["cantidad"].Value);
                                    mvCantidad = Convert.ToDecimal(griddetallemov.Rows[fila.Index].Cells["cantidad_old"].Value);

                                    if (almacaccionid.Substring(0, 1) == "1")
                                    {
                                        dtstock = lsStock + dtCantidad - mvCantidad;
                                    }
                                    else
                                    {
                                        if (almacaccionid.Substring(0, 1) == "2")
                                        {
                                            dtstock = lsStock - dtCantidad + mvCantidad;
                                        }
                                    }
                                    griddetallemov.Rows[fila.Index].Cells["stock_old"].Value = lsStock;
                                    griddetallemov.Rows[fila.Index].Cells["stock"].Value = dtstock;


                                    griddetallemov.Rows[fila.Index].Cells["dalmacaccionid"].Value = almacaccionid.ToString().Trim();
                                    txt_stock.Text = Convert.ToString(dtstock);

                                    if (almacaccionid.Substring(0, 1) == "2")
                                    {
                                        xprecventa = Convert.ToDecimal(Convert.ToDecimal(DT.Rows[0]["precventa"]).ToString("###,###,##0.000000"));
                                        xprecio = Convert.ToDecimal(Convert.ToDecimal(DT.Rows[0]["costoultimo"]).ToString("###,###,##0.000000"));
                                        txt_valor.Text = Convert.ToDecimal(DT.Rows[0]["costopromed"].ToString().Trim().PadLeft(1, '0')).ToString("###,###,##0.0000");
                                        xcostoprom = Convert.ToDecimal(DT.Rows[0]["costopromed"].ToString().Trim().PadLeft(1, '0'));
                                    }
                                    else
                                    {
                                        if (almacaccionid.Substring(0, 1) == "1")
                                        {
                                            xcostoultimo = Convert.ToDecimal(Convert.ToDecimal(DT.Rows[0]["costoultimo"]).ToString("###,###,##0.000000"));
                                            xprecio = Convert.ToDecimal(Convert.ToDecimal(DT.Rows[0]["costoultimo"]).ToString("###,###,##0.000000"));
                                            txt_valor.Text = Convert.ToDecimal(DT.Rows[0]["costoultimo"].ToString().Trim().PadLeft(1, '0')).ToString("###,###,##0.0000");
                                        }
                                    }
                                    griddetallemov.Rows[fila.Index].Cells["precventa"].Value = xprecventa;
                                    griddetallemov.Rows[fila.Index].Cells["costoultimo"].Value = xcostoultimo;
                                    griddetallemov.Rows[fila.Index].Cells["costopromed"].Value = xcostoprom;

                                    xcantidad = Convert.ToDecimal(griddetallemov.Rows[fila.Index].Cells["cantidad"].Value);

                                    imporfac = Math.Round(xcantidad * Convert.ToDecimal(xprecio), 6);

                                    tipcamb = Convert.ToDecimal(tcamb.Text.Trim());
                                    if (tipcamb <= 0)
                                    {
                                        tipcamb = 1;
                                    }

                                    if (moneda.SelectedValue.ToString() == "S")
                                    {
                                        xprecunit = xprecio;
                                    }
                                    else
                                    {
                                        xprecunit = xprecio / tipcamb;
                                    }

                                    _cal_Igv();


                                    desct1 = 0;
                                    import = imporfac * (1 - (desct1 / 100));
                                    if (Equivalencias.Left(cbo_incprec.Text.Trim(), 1) == "S")
                                    {
                                        totimpx = Math.Round(import * (Convert.ToDecimal(igv) / (100 + Convert.ToDecimal(igv))), 6);
                                    }
                                    else
                                    {
                                        totimpx = Math.Round(import * (Convert.ToDecimal(igv) / 100), 6);
                                    }

                                    griddetallemov.Rows[fila.Index].Cells["valor"].Value = xprecunit;
                                    griddetallemov.Rows[fila.Index].Cells["importe"].Value = Math.Round(xcantidad * xprecunit, 6);
                                    griddetallemov.Rows[fila.Index].Cells["dtotimpto"].Value = totimpx;

                                    griddetallemov.Rows[fila.Index].Cells["cantidad"].Value = xcantidad;
                                    griddetallemov.Rows[fila.Index].Cells["precunit"].Value = xprecunit;
                                    griddetallemov.Rows[fila.Index].Cells["importfac"].Value = Math.Round(imporfac, 2);
                                    Tabladetallemov.AcceptChanges();
                                    griddetallemov.CurrentCell = griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["cantidad"];
                                }
                            }
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Producto no existe en tabla LOCAL_STOCK !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Producto no existe !!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void griddetallemov_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    if ((griddetallemov.CurrentCell != null))
                    {
                        if (griddetallemov.CurrentCell.ReadOnly == false)
                        {
                            if (griddetallemov.Columns[griddetallemov.CurrentCell.ColumnIndex].Name.ToUpper() == "productid".ToUpper())
                            {
                                if (ManejaListPrec)
                                {
                                    AyudaProductoListaprecios(string.Empty);
                                }
                                else
                                {
                                    AyudaProducto(string.Empty);
                                }
                            }
                        }
                    }
                }


                if (e.KeyCode == (Keys.Back | Keys.LButton))
                {
                    if ((griddetallemov.CurrentCell != null))
                    {
                        if (griddetallemov.CurrentCell.ReadOnly == true)
                        {
                            var prod = Convert.ToString(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productid"].Value);
                            if (prod != string.Empty)
                            {
                                CargarDetalle(prod);
                            }
                        }
                    }
                }


                if (e.KeyCode == Keys.F3)
                {
                    var frmayuda = new Popup.Frm_upload();
                    if (lstListaprec.SelectedIndex != -1)
                    {
                        frmayuda.listaprecid = Convert.ToInt32(lstListaprec.SelectedValue.ToString());
                    }
                    frmayuda.moneda = moneda.SelectedValue.ToString().Trim();
                    frmayuda.Owner = this;
                    frmayuda.PasarTabla = Recibedetalle;
                    frmayuda.ShowDialog();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void griddetallemov_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (VariablesPublicas.PulsaAyudaArticulos)
                {
                    if (griddetallemov.Columns[griddetallemov.CurrentCell.ColumnIndex].Name.ToUpper() == "productid".ToUpper())
                    {
                        if (ManejaListPrec)
                        {
                            AyudaProductoListaprecios(string.Empty);
                        }
                        else
                        {
                            AyudaProducto(string.Empty);
                        }
                    }
                    VariablesPublicas.PulsaAyudaArticulos = false;
                    Tabladetallemov.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void griddetallemov_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (griddetallemov.Columns[griddetallemov.CurrentCell.ColumnIndex].Name.ToUpper() == "productid".ToUpper())
            {
                txtCDetalle = (TextBox)e.Control;
                txtCDetalle.MaxLength = 13;
                txtCDetalle.CharacterCasing = CharacterCasing.Upper;
                txtCDetalle.Text.Trim();
                e.Control.KeyDown += CapturarTeclaGRID;
            }
        }

        private void _RecalculoGrid()
        {
            if (almacaccionid.Length > 0)
            {
                try
                {
                    foreach (DataGridViewRow fila in griddetallemov.Rows)
                    {
                        Decimal preunit = 0, tipcamb = 0;
                        Decimal imporfac = 0;
                        var desct1 = 0;
                        Decimal totimpx = 0;
                        Decimal import = 0;
                        Decimal valor = 0;
                        Decimal xcantidad = 0, xprecio = 0, xstock = 0, xcostopromed = 0;

                        xcantidad = Convert.ToDecimal(griddetallemov.Rows[fila.Index].Cells["cantidad"].Value);
                        xprecio = Convert.ToDecimal(griddetallemov.Rows[fila.Index].Cells["precunit"].Value);
                        xstock = Convert.ToDecimal(griddetallemov.Rows[fila.Index].Cells["stock"].Value);
                        xcostopromed = Convert.ToDecimal(griddetallemov.Rows[fila.Index].Cells["costopromed"].Value);


                        if (xcantidad < 0)
                        {
                            MessageBox.Show("Cantidad no puede ser negativo!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            xcantidad = 0;
                            griddetallemov.Rows[fila.Index].Cells["cantidad"].Value = xcantidad;
                            return;
                        }

                        if (xprecio < 0)
                        {
                            MessageBox.Show("Precio no puede ser negativo!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            xprecio = 0;
                            griddetallemov.Rows[fila.Index].Cells["precunit"].Value = xprecio;
                            return;
                        }

                        preunit = Math.Round(Convert.ToDecimal(xprecio), 6);
                        tipcamb = Convert.ToDecimal(tcamb.Text.Trim());

                        if (tipcamb <= 0)
                        {
                            tipcamb = 1;
                        }

                        imporfac = Math.Round(xcantidad * Convert.ToDecimal(preunit), 6);

                        _cal_Igv();

                        desct1 = 0;
                        import = imporfac * (1 - (desct1 / 100));
                        if (Equivalencias.Left(cbo_incprec.Text.Trim(), 1) == "S")
                        {
                            totimpx = Math.Round(import * (Convert.ToDecimal(igv) / (100 + Convert.ToDecimal(igv))), 6);
                        }
                        else
                        {
                            totimpx = Math.Round(import * (Convert.ToDecimal(igv) / 100), 6);
                        }


                        if (almacaccionid.Trim().Substring(0, 1) == "2")
                        {
                            if (xcantidad <= xstock)
                            {
                                valor = Math.Round(Convert.ToDecimal(xcostopromed), 6);
                            }
                            else
                            {
                                MessageBox.Show("Cantidad fuera de rango!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                xcantidad = 0;
                                griddetallemov.Rows[fila.Index].Cells["cantidad"].Value = xcantidad;
                                return;
                            }
                        }
                        else
                        {
                            if (almacaccionid.Trim().Substring(0, 1) == "1")
                            {
                                valor = preunit;
                            }
                        }
                        if (moneda.SelectedValue.ToString() == "$")
                        {
                            preunit = preunit * tipcamb;
                        }

                        griddetallemov.Rows[fila.Index].Cells["valor"].Value = preunit;
                        griddetallemov.Rows[fila.Index].Cells["importe"].Value = Math.Round(xcantidad * preunit, 6);
                        griddetallemov.Rows[fila.Index].Cells["precunit"].Value = preunit;
                        griddetallemov.Rows[fila.Index].Cells["dtotimpto"].Value = totimpx;
                        griddetallemov.Rows[fila.Index].Cells["importfac"].Value = Math.Round(imporfac, 2);
                        calcular_totales();
                    }
                }
                catch (Exception ex)
                {
                    var error = string.Empty;
                    error = ex.GetType().ToString();
                    if (error == "System.Data.ConstraintException")
                    {
                        MessageBox.Show("Producto ya existe!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void _CalculosInternos()
        {
            _RecalculoGrid();
        }

        private void griddetallemov_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //second column
            //if (e.ColumnIndex == 1)
            //{
            //    object value = griddetallemov.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            //    if (value != null && value.ToString() != string.Empty)
            //    {
            //        griddetallemov.Rows[e.RowIndex].Cells[2].ReadOnly = false;
            //    }
            //    else
            //    {
            //        griddetallemov.Rows[e.RowIndex].Cells[2].ReadOnly = true;
            //    }
            //}

            try
            {
                if (griddetallemov.CurrentRow != null)
                {
                    if (griddetallemov.Columns[e.ColumnIndex].Name.ToLower() == "productid")
                    {
                        var xrollo = string.Empty;
                        xrollo = (griddetallemov.Rows[griddetallemov.CurrentRow.Index].Cells["rollo"].Value.ToString().Trim()).PadLeft(13, '0');
                        if (xrollo != "0000000000000")
                        {
                            ValidaTabladetallemovmov(xrollo);
                        }

                        // Habilitando columna productname si productid='*'
                        object nostock = griddetallemov.Rows[e.RowIndex].Cells["nostock"].Value;
                        if (nostock != null && Convert.ToBoolean(nostock.ToString()) != true)
                        {
                            griddetallemov.Rows[e.RowIndex].Cells["productname"].ReadOnly = false;
                        }
                        else
                        {
                            griddetallemov.Rows[e.RowIndex].Cells["productname"].ReadOnly = true;
                        }

                    }

                    if (griddetallemov.Columns[e.ColumnIndex].Name.ToLower() == "cantidad" || griddetallemov.Columns[e.ColumnIndex].Name.ToLower() == "precunit")
                    {
                        Decimal preunit = 0, tipcamb = 0;
                        Decimal imporfac = 0;
                        var desct1 = 0;
                        Decimal totimpx = 0;
                        Decimal import = 0;
                        Decimal valor = 0;
                        Decimal xcantidad = 0, xprecio = 0, xstock = 0, xcostopromed = 0;

                        xcantidad = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad"].Value);
                        xprecio = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["precunit"].Value);

                        if (xcantidad < 0)
                        {
                            MessageBox.Show("Cantidad no puede ser negativo!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            xcantidad = 0;
                            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad"].Value = xcantidad;
                            return;
                        }

                        if (xprecio < 0)
                        {
                            MessageBox.Show("Precio no puede ser negativo!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            xprecio = 0;
                            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["precunit"].Value = xprecio;
                            return;
                        }


                        Decimal xprecioanterior = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["precioanterior"].Value);
                        if (lstListaprec.SelectedIndex > 0)
                        {
                            if (xprecio < xprecioanterior)
                            {
                                MessageBox.Show("Precio no puede ser Menor al precio de Lista!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                xprecio = xprecioanterior;
                                griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["precunit"].Value = xprecio;
                                return;
                            }
                        }

                        Decimal lsStock = 0, dtCantidad = 0, mvCantidad = 0, dtstock = 0;
                        lsStock = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["stock_old"].Value);
                        dtCantidad = xcantidad;
                        mvCantidad = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad_old"].Value);
                        if (almacaccionid.Substring(0, 1) == "1")
                        {
                            dtstock = lsStock + dtCantidad - mvCantidad;
                        }
                        else
                        {
                            if (Convert.ToBoolean(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["nostock"].Value))
                            {
                                dtstock = 0;
                            }
                            else
                            {
                                if (almacaccionid.Substring(0, 1) == "2")
                                {
                                    dtstock = lsStock + mvCantidad;
                                    if (!novalidastock)
                                        if (dtCantidad > dtstock)
                                        {
                                            MessageBox.Show("Cantidad fuera de rango!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            xcantidad = 0;
                                            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad"].Value = xcantidad;
                                            return;
                                        }
                                    dtstock = lsStock - dtCantidad + mvCantidad;
                                }
                            }
                        }

                        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["stock"].Value = dtstock;
                        _cal_Igv();

                        xstock = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["stock"].Value);
                        xcostopromed = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["costopromed"].Value);


                        imporfac = Math.Round(xcantidad * Convert.ToDecimal(xprecio), 6);

                        if (almacaccionid.Trim().Substring(0, 1) == "2")
                        {
                            valor = Math.Round(Convert.ToDecimal(xcostopromed), 6);
                        }
                        else
                        {
                            if (almacaccionid.Trim().Substring(0, 1) == "1")
                            {
                                valor = preunit;
                            }
                        }
                        preunit = Math.Round(Convert.ToDecimal(xprecio), 6);
                        tipcamb = Convert.ToDecimal(tcamb.Text.Trim());

                        if (tipcamb <= 0)
                        {
                            tipcamb = 1;
                        }

                        if (moneda.SelectedValue.ToString() == "$")
                        {
                            preunit = preunit * tipcamb;
                        }


                        desct1 = 0;
                        import = imporfac * (1 - (desct1 / 100));
                        if (Equivalencias.Left(cbo_incprec.Text.Trim(), 1) == "S")
                        {
                            totimpx = Math.Round(import * (Convert.ToDecimal(igv) / (100 + Convert.ToDecimal(igv))), 6);
                        }
                        else
                        {
                            totimpx = Math.Round(import * (Convert.ToDecimal(igv) / 100), 6);
                        }

                        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["valor"].Value = preunit;
                        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["importe"].Value = Math.Round(xcantidad * preunit, 6);

                        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["dtotimpto"].Value = totimpx;
                        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["importfac"].Value = Math.Round(imporfac, 2);
                    }
                }
                calcular_totales();
                // calcularVuelto();
            }
            catch (Exception ex)
            {
                var error = string.Empty;
                error = ex.GetType().ToString();
                if (error == "System.Data.ConstraintException")
                {
                    MessageBox.Show("Producto ya existe!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void _cal_Igv()
        {
            int xval_igv = Convert.ToInt16(tipimptotasa.Text == "" ? "0" : tipimptotasa.Text);
            //igv = xval_igv == 1 ? 18 : 0;
            igv = xval_igv;
        }

        private void griddetallemov_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                if (almacaccionid.Trim().Substring(0, 1) == "1")
                {
                    txt_valor.Text = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentRow.Index].Cells["costoultimo"].Value).ToString("#,###,##0.000").Trim();
                }
                else
                {
                    txt_valor.Text = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentRow.Index].Cells["costopromed"].Value).ToString("#,###,##0.000").Trim();
                }
                txt_stock.Text = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentRow.Index].Cells["stock"].Value).ToString("#,###,##0.00").Trim();
            }
        }

        private void griddetallemov_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            griddetallemov[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            griddetallemov[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            griddetallemov.EnableHeadersVisualStyles = false;
            griddetallemov.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            griddetallemov.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void griddetallemov_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            griddetallemov[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }

        private void num_op_Enter(object sender, EventArgs e)
        {
        }

        private void moneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (moneda.Text == "US$")
            {
                totimporte.BackColor = System.Drawing.Color.YellowGreen;
                _RecalculoGrid();
            }
            else
            {
                if (moneda.Text == "S/.")
                {
                    totimporte.BackColor = System.Drawing.Color.Yellow;
                    _RecalculoGrid();
                }
                else
                {
                    totimporte.BackColor = System.Drawing.Color.White;
                    _RecalculoGrid();
                }
            }
        }

        private void tipimptotasa_SelectedIndexChanged(object sender, EventArgs e)
        {
            calcular_totales();
        }

        private void ser_op_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
        }

        private void numdoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                form_cargar_datos(String.Empty);
                calcular_totales();
                griddetallemov.Focus();
                ControlName();
            }
        }

        private void ControlName()
        {
            if (tipodoc.SelectedValue.ToString() == "FA")
            {
                btnextraersunat.Image = global::BapFormulariosNet.Properties.Resources.go_sunat1;
                lblruc.Text = "RUC:";
                lbltitulo.Text = "FACTURA";
                nmruc.MaxLength = 11;
            }
            else
            {
                if (tipodoc.SelectedValue.ToString() == "BV")
                {
                    btnextraersunat.Image = global::BapFormulariosNet.Properties.Resources.go_reniec;
                    lblruc.Text = "DNI:";
                    lbltitulo.Text = "BOLETA";
                    nmruc.MaxLength = 8;
                }
                else
                {
                    btnextraersunat.Image = global::BapFormulariosNet.Properties.Resources.go_reniec;
                    lblruc.Text = "DNI/RUC:";
                    lbltitulo.Text = "NOTA CREDITO";
                    nmruc.MaxLength = 11;
                }
            }
        }

        private void serguia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                numguia.Focus();
            }
        }

        private void numguia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var numdo = string.Empty;
                if (numguia.Text.Trim().Length > 0)
                {
                    numdo = numguia.Text.Trim().PadLeft(10, '0');
                }
                numguia.Text = numdo;
                ObtenemosCab();
                Tabla_DetGuia();
                fechguia.Focus();
            }
        }

        private void ObtenemosCab()
        {
            if (tipguia.Text.Trim().Length > 0)
            {
                var BL = new tb_ad_movimientosBL();
                var BE = new tb_ad_movimientos();

                var dt = new DataTable();
                BE.moduloid = modulo;
                BE.local = local;
                BE.tipodoc = tipguia.Text.ToString();
                BE.serdoc = serguia.Text.Trim();
                BE.numdoc = numguia.Text;

                dt = BL.GetOne(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    dt.Rows[0]["numdoc"].ToString().Trim();
                    fechguia.Value = Convert.ToDateTime(dt.Rows[0]["fechdoc"]);
                    ctacte.Text = dt.Rows[0]["ctacte"].ToString().Trim();
                    nmruc.Text = dt.Rows[0]["nmruc"].ToString().Trim();
                    ctactename.Text = dt.Rows[0]["ctactename"].ToString().Trim();
                    var BL2 = new clienteBL();
                    var BE2 = new tb_cliente();
                    var dt2 = new DataTable();
                    BE2.ctacte = ctacte.Text;
                    dt2 = BL2.GetAll(EmpresaID, BE2).Tables[0];
                    direc.Text = dt2.Rows[0]["direc"].ToString().Trim();


                    moneda.SelectedValue = dt.Rows[0]["moneda"].ToString().Trim();
                }
            }
        }

        private void Tabla_DetGuia()
        {
            Decimal xxprecventa = 0, xxcostoultimo = 0, xxstock = 0, xxcostopromed = 0;
            griddetallemov.AutoGenerateColumns = false;

            var BL = new tb_ad_movimientosBL();
            var BE = new tb_ad_movimientos();
            var dt = new DataTable();

            BE.moduloid = modulo;
            BE.local = local;
            BE.tipodoc = tipguia.Text.ToString();
            BE.serdoc = serguia.Text.Trim();
            BE.numdoc = numguia.Text;


            dt = BL.GetAll(EmpresaID, BE).Tables[0];

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow fila in dt.Rows)
                {
                    var BL2 = new tb_ad_local_stockBL();
                    var BE2 = new tb_ad_local_stock();
                    var dt2 = new DataTable();

                    BE2.moduloid = modulo;
                    BE2.local = local;
                    BE2.productid = fila["productid"].ToString();

                    dt2 = BL2.GetAll(EmpresaID, BE2).Tables[0];

                    if (dt2.Rows.Count > 0)
                    {
                        if (almacaccionid.Trim() == "20" || almacaccionid.Trim() == "21")
                        {
                            lbl_valor.Text = "Cost.Prom";
                            xxprecventa = Convert.ToDecimal(dt2.Rows[0]["precventa"]);
                            xxcostopromed = Convert.ToDecimal(dt2.Rows[0]["costopromed"]);
                        }
                        else
                        {
                            if (almacaccionid.Trim() == "10" || almacaccionid.Trim() == "11")
                            {
                                lbl_valor.Text = "Cost.Ultm";
                                xxcostoultimo = Convert.ToDecimal(dt2.Rows[0]["costoultimo"]);
                            }
                        }
                        xxstock = Convert.ToDecimal(dt2.Rows[0]["stock"]);
                        if (xxstock == 0)
                        {
                            xxstock = Convert.ToDecimal(dt2.Rows[0]["stockini"]);
                        }
                    }

                    row = Tabladetallemov.NewRow();
                    row["itemref"] = fila["itemref"].ToString();
                    row["items"] = fila["items"].ToString();
                    row["productid"] = fila["productid"].ToString().Trim();
                    row["productname"] = fila["productname"].ToString().Trim();

                    var cantidad = Math.Round(Convert.ToDecimal(fila["cantidad"]), 4);

                    row["stock"] = xxstock;

                    row["precventa"] = xxprecventa;
                    row["costoultimo"] = xxcostoultimo;
                    row["costopromed"] = xxcostopromed;


                    row["cantidad"] = cantidad;
                    row["cantidad_old"] = Math.Round(Convert.ToDecimal(fila["cantidad"]), 4);
                    row["precunit"] = Math.Round(Convert.ToDecimal(Convert.ToDecimal(fila["precunit"]).ToString("###,###,##0.000000")), 6);
                    var precunit = Math.Round(Convert.ToDecimal(Convert.ToDecimal(fila["precunit"]).ToString("###,###,##0.000000")), 6);
                    Decimal importe;
                    importe = cantidad * precunit;

                    row["importfac"] = importe;
                    row["valor"] = Math.Round(Convert.ToDecimal(fila["valor"]), 6);
                    row["importe"] = Math.Round(Convert.ToDecimal(fila["importe"]), 6);
                    row["totimpto"] = Math.Round(Math.Round(Convert.ToDecimal(fila["importe"]), 6) * (Convert.ToDecimal(18) / 100), 6);
                    row["almacaccionid"] = almacaccionid.Trim();
                    Tabladetallemov.Rows.Add(row);
                    griddetallemov.DataSource = Tabladetallemov;
                }

                _RecalculoGrid();
            }
            else
            {
                return;
            }
        }

        private void btn_Calculadora_Click(object sender, EventArgs e)
        {
            var Proceso = new Process();
            Proceso.StartInfo.FileName = "calc.exe";
            Proceso.StartInfo.Arguments = string.Empty;
            Proceso.Start();
        }

        private void fechfac_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void fechguia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sernotac.Focus();
            }
        }

        private void sernotac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                numnotac.Focus();
            }
        }

        private void numnotac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fechnotac.Focus();
            }
        }

        private void fechnotac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                glosa.Focus();
            }
        }

        private void Botonera_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in griddetallemov.Rows)
            {
                var xproductid = griddetallemov.Rows[fila.Index].Cells["productid"].Value.ToString();
                if (xproductid.Trim().Length == 13)
                {
                    var BL = new tb_ad_local_stockBL();
                    var BE = new tb_ad_local_stock();
                    var DT = new DataTable();

                    BE.moduloid = modulo;
                    BE.productid = xproductid;

                    DT = BL.GetAll(EmpresaID, BE).Tables[0];

                    if (DT.Rows.Count > 0)
                    {
                        griddetallemov.Rows[fila.Index].Cells["productname"].Value = DT.Rows[0]["productname"].ToString().Trim();
                    }
                    else
                    {
                        MessageBox.Show("Producto no existe !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Producto no existe !!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Recibedetallemov2(DataTable resultado)
        {
            if (resultado.Rows.Count > 0)
            {
                Tabladetallemov = resultado;
                griddetallemov.DataSource = Tabladetallemov;
                _RecalculoGrid();
            }
        }

        private void DatosSunat()
        {
            string rucc;
            rucc = nmruc.Text;
            var oHTTP = string.Empty;
            try
            {
                var baseUri = ("http://www.sunat.gob.pe/w/wapS01Alias?ruc=" + rucc);
                var connection = (HttpWebRequest)HttpWebRequest.Create(baseUri);
                connection.Method = "GET";
                var response = (HttpWebResponse)connection.GetResponse();
                var sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                oHTTP = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Conectarse a Internet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                oHTTP = string.Empty;
            }

            var p1 = string.Empty;
            var p2 = string.Empty;
            var p3 = string.Empty;
            var p4 = string.Empty;
            var p5 = string.Empty;
            var p6 = string.Empty;
            var p7 = string.Empty;
            var p8 = string.Empty;
            var p9 = string.Empty;
            var F1 = string.Empty;
            var F2 = string.Empty;
            var F3 = string.Empty;
            var F4 = string.Empty;
            var F5 = string.Empty;
            var F6 = string.Empty;
            var F7 = string.Empty;
            var F8 = string.Empty;
            var F9 = string.Empty;
            int P10;
            int P11;
            var besta = string.Empty;
            var baret = string.Empty;

            int P50;
            int P51;
            int P40;
            int P41;
            int P31;
            var braso = string.Empty;
            var bcond = string.Empty;
            int P70;
            int P71;
            int P21;
            int P20;
            var btele = string.Empty;
            var btipo = string.Empty;
            var bfena = string.Empty;
            var bndni = string.Empty;
            var bdire = string.Empty;
            int p90;
            int p30;
            int P60;
            int P61;
            int p80;
            int p81;
            int p91;

            if ((oHTTP.Trim().Length > 0))
            {
                p1 = rucc;
                F1 = " <br/></small>";
                p2 = "Estado.";
                F2 = "Agente";
                p3 = "Situaci";
                F3 = "Tel";
                p4 = "Direcci";
                F4 = "Situaci";
                p5 = "Retenci";
                F5 = "Nombre";
                p6 = "Tipo";
                F6 = "DNI";
                p7 = "Nacimiento.";
                F7 = "Act.";
                p8 = "DNI";
                F8 = "Nacimiento.";
                p9 = "fono(s).";
                F9 = "Dependencia.";
                if (((oHTTP.IndexOf("El numero Ruc ingresado es inv") + 1) > 0))
                {
                    MessageBox.Show(oHTTP, "Error en búsqueda de Ruc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nmruc.Focus();
                }
                else
                {
                    string pvalornombreComercial;
                    var pglosanombreComercial = "Comercial.</b><br/>";
                    pvalornombreComercial = oHTTP.Substring(((oHTTP.IndexOf(pglosanombreComercial) + 1) + 18));

                    P10 = (oHTTP.IndexOf(p1) + 1);
                    P11 = (oHTTP.IndexOf(F1) + 1);
                    braso = oHTTP.Substring((P10 + 13), ((P11 - P10) - 14));
                    P20 = (oHTTP.IndexOf(p2) + 1);
                    P21 = (oHTTP.IndexOf(F2) + 1);
                    besta = oHTTP.Substring((P20 + 10), ((P21 - P20) - 53));
                    p30 = (oHTTP.IndexOf(p3) + 1);
                    P31 = (oHTTP.IndexOf(F3) + 1);
                    bcond = oHTTP.Substring((p30 + 18), ((P31 - p30) - 54));
                    P40 = (oHTTP.IndexOf(p4) + 1);
                    P41 = (oHTTP.IndexOf(F4) + 1);
                    bdire = oHTTP.Substring((P40 + 23), ((P41 - P40) - 52));
                    P50 = (oHTTP.IndexOf(p5) + 1);
                    P51 = (oHTTP.IndexOf(F5) + 1);
                    baret = oHTTP.Substring((P50 + 57), ((P51 - P50) - 110));
                    if ((rucc.Substring(0, 1) == "1"))
                    {
                        P60 = (oHTTP.IndexOf(p6) + 1);
                        P61 = (oHTTP.IndexOf(F6) + 1);
                        btipo = oHTTP.Substring((P60 + 14), ((P61 - P60) - 66));
                        P70 = (oHTTP.IndexOf(p7) + 1);
                        P71 = (oHTTP.IndexOf(F7) + 1);
                        bfena = oHTTP.Substring((P70 + 15), ((P71 - P70) - 74));
                        p80 = (oHTTP.IndexOf(p8) + 1);
                        p81 = (oHTTP.IndexOf(F8) + 1);
                        bndni = oHTTP.Substring((p80 + 9), ((p81 - p80) - 52));
                    }
                    else
                    {
                        btipo = "PERSONA JURIDICA";
                        bfena = string.Empty;
                        bndni = string.Empty;
                    }
                    p90 = (oHTTP.IndexOf(p9) + 1);
                    p91 = (oHTTP.IndexOf(F9) + 1);
                    btele = oHTTP.Substring((p90 + 16), ((p91 - p90) - 46));

                    nmruc.Text = rucc;

                    ctactename.Text = braso;
                    direc.Text = bdire;
                    telef.Text = ((btele == "-</") ? string.Empty : btele);
                }
            }
        }

        private void btnextraersunat_Click(object sender, EventArgs e)
        {
            //if (tipodoc.SelectedValue.ToString() == "FA")
            //{
            //    //DatosSunat();

            //    myInfoSunat.GetInfo(nmruc.Text.Trim(), txtCapcha.Text);
            //    // Rellenando Datos Devueltos
            //    nmruc.Text = myInfoSunat.Ruc;
            //    ctactename.Text = myInfoSunat.RazonSocial;
            //    direc.Text = myInfoSunat.Direccion;
            //    telef.Text = ((myInfoSunat.Telefonos == "-</") ? string.Empty : myInfoSunat.Telefonos);
            //}
            //else
            //{
            //    if (tipodoc.SelectedValue.ToString() == "BV")
            //    {
            //        Fmr_ReniecNombres(string.Empty);
            //    }
            //}

            switch (tipodoc.SelectedValue.ToString())
            {
                case "FA":
                    Fmr_SunatDatos(string.Empty);
                    break;
                case "BV":
                    Fmr_ReniecDatos(string.Empty);
                    break;
                case "NC":
                    if (nmruc.Text.Trim().Length == 11)
                    {
                        Fmr_SunatDatos(string.Empty);
                    }
                    else
                    {
                        Fmr_ReniecDatos(string.Empty);
                    }
                    break;
                default:
                    break;
            }

            //if (tipodoc.SelectedValue.ToString() == "FA")
            //{
            //    Fmr_SunatDatos(string.Empty);
            //}
            //else
            //{
            //    if (tipodoc.SelectedValue.ToString() == "BV")
            //    {
            //        Fmr_ReniecDatos(string.Empty);
            //    }
            //}
        }

        private void Fmr_ReniecDatos(String lpdescrlike)
        {
            try
            {
                var frmreniec = new Popup.Frm_reniec();
                frmreniec.dni = nmruc.Text.ToString();
                frmreniec.PasaDni = RecibeReniec;
                frmreniec.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }

        private void RecibeReniec(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                ctactename.Text = resultado1.Trim();
            }
        }


        private void Fmr_SunatDatos(String lpdescrlike)
        {
            try
            {
                // var frmSunat = new Popup.Frm_Popup_sunat();
                var frmSunat = new Generales.Frm_popup_sunat();
                frmSunat.Ruc = nmruc.Text.ToString();
                frmSunat.PasaRuc = RecibeSunat;
                frmSunat.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }

        private void RecibeSunat(Info _Info)
        {
            if (_Info.RazonSocial.Trim().Length > 0)
            {
                ctactename.Text = _Info.RazonSocial.Trim();
                direc.Text = _Info.Direccion.Trim();
                telef.Text = _Info.Telefono.Trim();
            }
        }


        private void vendperid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaVendedor(string.Empty);
            }

            if (e.KeyCode == Keys.Enter)
            {
                ValidaVendedor(vendperid.Text.ToString(), true);
            }
        }

        private void AyudaVendedor(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "Ayuda Vendedor";
                frmayuda.sqlquery = "select vendorid, vendorname from Tb_t1_vendedor ";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where ";
                frmayuda.criteriosbusqueda = new string[] { "VENDEDOR", "CÓDIGO" };
                frmayuda.columbusqueda = "vendorname,vendorid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeVendedor;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ValidaVendedor(String xvendedorid, Boolean retrn)
        {
            if (xvendedorid.Trim().Length > 0)
            {
                var BL = new tb_t1_vendedorBL();
                var BE = new tb_t1_vendedor();
                var dt = new DataTable();
                BE.vendorid = xvendedorid.Trim().PadLeft(4, '0');
                BE.local = local.ToString();

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    vendperid.Text = dt.Rows[0]["vendorid"].ToString().Trim();
                    vendpername.Text = dt.Rows[0]["vendorname"].ToString().Trim();
                }
                else
                {
                    if (!retrn)
                    {
                        vendperid.Text = string.Empty;
                        vendpername.Text = string.Empty;
                        vendperid.Focus();
                    }
                }
            }
        }

        private void RecibeVendedor(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                vendperid.Text = resultado1.Trim();
                vendpername.Text = resultado2.Trim();
            }
        }

        private void ValControls()
        {
            var BL = new clienteBL();
            var BE = new tb_cliente();
            var dt = new DataTable();

            BE.defacliepub = true;
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (tipodoc.SelectedValue.ToString() == "FA" ||
                tipodoc.SelectedValue.ToString() == "TK")
            {
                btnextraersunat.Image = global::BapFormulariosNet.Properties.Resources.go_sunat1;
                lblruc.Text = "RUC:";
                lbltitulo.Text = "FACTURA";
                nmruc.MaxLength = 11;
                lbltitulo.Location = new Point(422, 9);
                tip_operacion = "01";

                if (dt.Rows.Count > 0)
                {
                    ctacte.Text = dt.Rows[0]["ctacte"].ToString();
                    ctactename.Text = dt.Rows[0]["ctactename"].ToString();
                }
                else
                {
                    ctacte.Text = string.Empty;
                    ctactename.Text = string.Empty;
                }

                if (tipodoc.SelectedValue.ToString() == "TK")
                {
                    lblruc.Text = "DNI/RUC:";
                    lbltitulo.Text = "TICKET";
                    lbltitulo.Location = new Point(422, 9);
                }
            }
            else
            {
                if (tipodoc.SelectedValue.ToString() == "BV")
                {
                    btnextraersunat.Image = global::BapFormulariosNet.Properties.Resources.go_reniec;
                    lblruc.Text = "DNI:";
                    lbltitulo.Text = "BOLETA";
                    nmruc.MaxLength = 8;
                    lbltitulo.Location = new Point(422, 9);
                    tip_operacion = "01";

                    if (dt.Rows.Count > 0)
                    {
                        ctacte.Text = dt.Rows[0]["ctacte"].ToString();
                        ctactename.Text = dt.Rows[0]["ctactename"].ToString();
                    }
                    else
                    {
                        ctacte.Text = string.Empty;
                        ctactename.Text = string.Empty;
                    }
                }
                else
                {
                    if (tipodoc.SelectedValue.ToString() == "NC")
                    {
                        lblruc.Text = "DNI/RUC:";
                        lbltitulo.Text = "NOTA DE CREDITO";
                        lbltitulo.Location = new Point(350, 9);
                        tip_operacion = "05";
                    }
                }
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(totimporte.Text) > 0)
                {
                    var frm = new Popup.Frm_tarjetas()
                    {
                        PasaDatos = RecibeDatosTarj
                    };
                    frm.ShowDialog();
                }              
            }
            catch (Exception ex)
            {
            }
        }

        private void RecibeDatosTarj(DataTable Datos)
        {
            try
            {
                foreach (DataRow fila in Datos.Rows)
                {
                    var BL = new tb_t1_tarjetaBL();
                    var BE = new tb_t1_tarjeta();
                    var dt = new DataTable();

                    BE.filtro = "2";
                    BE.tarjetaid = Convert.ToInt32(fila["tarjetaid"].ToString());

                    dt = BL.GetAll2(VariablesPublicas.EmpresaID, BE).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        row = TablaTarjetas.NewRow();
                        row["tarjetaid"] = Datos.Rows[0]["tarjetaid"].ToString();
                        row["tarjetaimpo"] = Datos.Rows[0]["tarjetaimpo"].ToString();
                        row["tarjetanume"] = Datos.Rows[0]["tarjetanume"].ToString();
                        row["tarjetaname"] = dt.Rows[0]["tarjetaname"].ToString();
                        row["tarjetalogo"] = dt.Rows[0]["tarjetalogo"];
                        row["ddnni"] = Datos.Rows[0]["ddnni"].ToString();
                    }

                    TablaTarjetas.Rows.Add(row);
                }
                dgbtarjetas.DataSource = TablaTarjetas;

                if (TablaTarjetas != null)
                {
                    if (TablaTarjetas.Rows.Count != 0)
                    {
                        importtarj.Text = Convert.ToDecimal(TablaTarjetas.Compute("sum(tarjetaimpo)", string.Empty)).ToString("##,###,##0.00");
                    }
                    else
                    {
                        importtarj.Text = "0";
                    }
                }
                else
                {
                    importtarj.Text = "0";
                }

                //calcularVuelto();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private void btn_del_Click(object sender, EventArgs e)
        {
            var lc_cont = 0;
            var xcoditem = string.Empty;
            if ((dgbtarjetas.CurrentRow != null))
            {
                xcoditem = dgbtarjetas.Rows[dgbtarjetas.CurrentCell.RowIndex].Cells["_tarjetaid"].Value.ToString();
                for (lc_cont = 0; lc_cont <= TablaTarjetas.Rows.Count - 1; lc_cont++)
                {
                    if (TablaTarjetas.Rows[lc_cont]["tarjetaid"].ToString() == xcoditem)
                    {
                        TablaTarjetas.Rows[lc_cont].Delete();
                        TablaTarjetas.AcceptChanges();
                        break;
                    }
                }

                if (TablaTarjetas != null)
                {
                    if (TablaTarjetas.Rows.Count != 0)
                    {
                        importtarj.Text = Convert.ToDecimal(TablaTarjetas.Compute("sum(tarjetaimpo)", string.Empty)).ToString("##,###,##0.00");
                    }
                    else
                    {
                        importtarj.Text = "0";
                    }
                }
                else
                {
                    importtarj.Text = "0";
                }
            }
        }

        private void cbo_incprec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Equivalencias.Left(cbo_incprec.Text, 1) == "N")
            {
                incprec = "N";
                calcular_totales();
            }
            else
            {
                if (Equivalencias.Left(cbo_incprec.Text, 1) == "S")
                {
                    incprec = "S";
                    calcular_totales();
                }
            }
        }

        private void numfac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tipodoc.SelectedValue.ToString() == "NC")
                {
                    form_cargar_datos_referencia(String.Empty);
                    calcular_totales();
                }
                griddetallemov.Focus();
                ControlName();
            }
        }

        private void serfac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var numdo = string.Empty;
                if (serfac.Text.Trim().Length > 0)
                {
                    numdo = serfac.Text.Trim().PadLeft(4, '0');
                }
                serfac.Text = numdo;
                numfac.Focus();
            }
        }


        private void ValidaDocref()
        {
            if (tipfac.SelectedIndex != -1)
            {
                var BL = new tb_ad_movimientosBL();
                var BE = new tb_ad_movimientos();

                var dt = new DataTable();
                BE.moduloid = modulo;
                BE.local = local;
                BE.tipodoc = tipfac.Text.ToString();
                BE.serdoc = serfac.Text.Trim();
                BE.numdoc = numfac.Text;
                dt = BL.GetOne(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    dt.Rows[0]["numdoc"].ToString().Trim();

                    fechfac.Value = Convert.ToDateTime(dt.Rows[0]["fechdoc"]);
                    ctacte.Text = dt.Rows[0]["ctacte"].ToString().Trim();
                    nmruc.Text = dt.Rows[0]["nmruc"].ToString().Trim();
                    ctactename.Text = dt.Rows[0]["ctactename"].ToString().Trim();
                    direc.Text = dt.Rows[0]["direc"].ToString().Trim();
                    moneda.SelectedValue = dt.Rows[0]["moneda"].ToString().Trim();
                }
            }
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            //var frmayuda = new Popup.Frm_upload();
            //if (lstListaprec.SelectedIndex != -1)
            //{
            //    frmayuda.listaprecid = Convert.ToInt32(lstListaprec.SelectedValue.ToString());
            //}
            //frmayuda.moneda = moneda.SelectedValue.ToString().Trim();
            //frmayuda.Owner = this;
            //frmayuda.PasarTabla = Recibedetalle;
            //frmayuda.ShowDialog();

            var frmayuda = new Popup.Frm_barcode();
            frmayuda.modulo = modulo;
            frmayuda.local = local;
            frmayuda.moneda = moneda.SelectedValue.ToString().Trim();
            frmayuda.tcamb = Convert.ToDecimal(tcamb.Text);
            frmayuda.tipodoc = tipodoc.SelectedValue.ToString();
            frmayuda.Owner = this;
            frmayuda.PasarTabla = Recibedetalle;
            frmayuda.ShowDialog();

        }

        private void Recibedetalle(DataTable DataResult)
        {
            if (DataResult.Rows.Count > 0)
            {
                var xxproductid = string.Empty;
                for (var i = 0; i < DataResult.Rows.Count; i++)
                {
                    int n = 1;
                    xxproductid = DataResult.Rows[i]["productid"].ToString();

                    if (Search(xxproductid))
                    {
                        UpdateDetalle(xxproductid, n + 1);
                        calcular_totales();
                    }
                    else
                    {
                        AddRowDatable();
                        CargarDetalle2(xxproductid);
                        calcular_totales();
                    }
                }
            }
        }

        Boolean Search(String xprod)
        {
            Boolean valor = false;

            foreach (DataGridViewRow row in griddetallemov.Rows)
            {
                if (xprod.ToString() == row.Cells["productid"].Value.ToString())
                {
                    valor = true;
                }
                else { valor = false; }
            }
            return valor;
        }

        private void UpdateDetalle(String xprod, int n)
        {
            foreach (DataGridViewRow row in griddetallemov.Rows)
            {
                String xproductid = row.Cells["productid"].Value.ToString();
                if (xprod.ToString() == xproductid.ToString())
                { row.Cells["cantidad"].Value = n; }
            }
        }

        private void AddRowDatable()
        {
            if (griddetallemov.Enabled)
            {
                if (griddetallemov.Rows.Count > 0)
                {
                    if (griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["productid"].Value.ToString().Trim().Length > 0)
                    {
                        griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["productid"].Value.ToString();
                        griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["productname"].Value.ToString();
                        Tabladetallemov.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetallemov));
                        Tabladetallemov.Rows[Tabladetallemov.Rows.Count - 1]["items"] = VariablesPublicas.CalcMaxField(Tabladetallemov, "items", 5);

                        griddetallemov.CurrentCell = griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["productid"];
                        griddetallemov.BeginEdit(true);
                    }
                }
                else
                {
                    Tabladetallemov.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetallemov));
                    Tabladetallemov.Rows[Tabladetallemov.Rows.Count - 1]["items"] = VariablesPublicas.CalcMaxField(Tabladetallemov, "items", 5);
                    griddetallemov.CurrentCell = griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["productid"];
                    griddetallemov.BeginEdit(true);
                }
            }
        }

        private void CargarDetalle(String xxproductid)
        {
            //Decimal xprecio = 0, xvalor = 0, xcantidad = 0, tipcamb = 0;
            //var desct1 = 0;
            //Decimal imporfac = 0;
            //Decimal import = 0;
            //Decimal totimpx = 0;

            //if (xxproductid.Trim().Length == 13)
            //{
            //    var BE = new tb_ad_productos();
            //    var BL = new tb_ad_productosBL();
            //    var dt = new DataTable();

            //    BE.moduloid = modulo;
            //    BE.local = local;
            //    BE.productid = xxproductid;
            //    BE.moneda = moneda.SelectedValue.ToString();
            //    BE.listaprecid = Convert.ToInt32(lstListaprec.SelectedValue.ToString());

            //    dt = BL.GetPrecList(VariablesPublicas.EmpresaID, BE).Tables[0];

            //    if (dt.Rows.Count > 0)
            //    {
            //        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productid"].Value = dt.Rows[0]["productid"].ToString().Trim();
            //        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productname"].Value = dt.Rows[0]["productname"].ToString().Trim();
            //        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["unmed"].Value = dt.Rows[0]["unmed"].ToString().Trim();

            //        Decimal lsStock = 0, dtCantidad = 0, mvCantidad = 0, dtstock = 0;

            //        lsStock = Convert.ToDecimal(dt.Rows[0]["stock"].ToString().Trim());
            //        dtCantidad = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad"].Value);
            //        mvCantidad = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad_old"].Value);

            //        if (almacaccionid.Substring(0, 1) == "1")
            //        {
            //            dtstock = lsStock + dtCantidad - mvCantidad;
            //        }
            //        else
            //        {
            //            if (almacaccionid.Substring(0, 1) == "2")
            //            {
            //                dtstock = lsStock - dtCantidad + mvCantidad;
            //            }
            //        }

            //        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["stock_old"].Value = lsStock;
            //        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["stock"].Value = dtstock;
            //        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["dalmacaccionid"].Value = almacaccionid.ToString().Trim();
            //        txt_stock.Text = Convert.ToString(dtstock);

            //        xprecio = Convert.ToDecimal(dt.Rows[0]["precunit"].ToString().Trim());
            //        xcantidad = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad"].Value);

            //        imporfac = Math.Round(xcantidad * Convert.ToDecimal(xprecio), 6);
            //        tipcamb = Convert.ToDecimal(tcamb.Text.Trim());

            //        if (tipcamb <= 0)
            //        {
            //            tipcamb = 1;
            //        }

            //        if (moneda.SelectedValue.ToString() == "S")
            //        {
            //            xvalor = xprecio;
            //        }
            //        else
            //        {
            //            xvalor = xprecio / tipcamb;
            //        }

            //        _cal_Igv();


            //        desct1 = 0;
            //        import = imporfac * (1 - (desct1 / 100));
            //        if (Equivalencias.Left(cbo_incprec.Text.Trim(), 1) == "S")
            //        {
            //            totimpx = Math.Round(import * (Convert.ToDecimal(igv) / (100 + Convert.ToDecimal(igv))), 6);
            //        }
            //        else
            //        {
            //            totimpx = Math.Round(import * (Convert.ToDecimal(igv) / 100), 6);
            //        }

            //        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["valor"].Value = xvalor;
            //        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["importe"].Value = Math.Round(xcantidad * xvalor, 6);
            //        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["dtotimpto"].Value = totimpx;

            //        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["precioanterior"].Value = xprecio;

            //        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad"].Value = xcantidad;
            //        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["precunit"].Value = xprecio;
            //        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["importfac"].Value = Math.Round(imporfac, 2);
            //        Tabladetallemov.AcceptChanges();
            //        griddetallemov.CurrentCell = griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["cantidad"];
            //    }
            //    else
            //    {
            //        MessageBox.Show("Producto no existe en Tabla LISTA DE PRECIOS !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Producto no existe !!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void CargarDetalle2(String xxproductid)
        {
            //Decimal xprecio = 0, xvalor = 0, xcantidad = 0, tipcamb = 0;
            //var desct1 = 0;
            //Decimal imporfac = 0;
            //Decimal import = 0;
            //Decimal totimpx = 0;

            //if (xxproductid.Trim().Length == 13)
            //{
            //    var BE = new tb_ad_productos();
            //    var BL = new tb_ad_productosBL();
            //    var dt = new DataTable();

            //    BE.moduloid = modulo;
            //    BE.local = local;
            //    BE.productid = xxproductid;
            //    BE.moneda = moneda.SelectedValue.ToString();
            //    BE.tcamb = Convert.ToDecimal(tcamb.Text);
            //    BE.tipodoc = tipodoc.SelectedValue.ToString();

            //    dt = BL.GetPrecCostoUltimo(VariablesPublicas.EmpresaID, BE).Tables[0];

            //    if (dt.Rows.Count > 0)
            //    {
            //        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productid"].Value = dt.Rows[0]["productid"].ToString().Trim();
            //        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productname"].Value = dt.Rows[0]["productname"].ToString().Trim();
            //        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["unmed"].Value = dt.Rows[0]["unmed"].ToString().Trim();

            //        Decimal lsStock = 0, dtCantidad = 0, mvCantidad = 0, dtstock = 0;

            //        lsStock = Convert.ToDecimal(dt.Rows[0]["stock"].ToString().Trim());
            //        dtCantidad = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad"].Value);
            //        mvCantidad = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad_old"].Value);

            //        if (almacaccionid.Substring(0, 1) == "1")
            //        {
            //            dtstock = lsStock + dtCantidad - mvCantidad;
            //        }
            //        else
            //        {
            //            if (almacaccionid.Substring(0, 1) == "2")
            //            {
            //                dtstock = lsStock - dtCantidad + mvCantidad;
            //            }
            //        }

            //        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["stock_old"].Value = lsStock;
            //        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["stock"].Value = dtstock;
            //        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["dalmacaccionid"].Value = almacaccionid.ToString().Trim();
            //        txt_stock.Text = Convert.ToString(dtstock);

            //        xprecio = Convert.ToDecimal(dt.Rows[0]["precunit"].ToString().Trim());
            //        xcantidad = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad"].Value);

            //        imporfac = Math.Round(xcantidad * Convert.ToDecimal(xprecio), 6);
            //        tipcamb = Convert.ToDecimal(tcamb.Text.Trim());

            //        if (tipcamb <= 0)
            //        {
            //            tipcamb = 1;
            //        }

            //        //El Precio ya Lo Traigo sea Dolar O Soles
            //        xvalor = xprecio;

            //        _cal_Igv();


            //        desct1 = 0;
            //        import = imporfac * (1 - (desct1 / 100));
            //        if (Equivalencias.Left(cbo_incprec.Text.Trim(), 1) == "S")
            //        {
            //            totimpx = Math.Round(import * (Convert.ToDecimal(igv) / (100 + Convert.ToDecimal(igv))), 6);
            //        }
            //        else
            //        {
            //            totimpx = Math.Round(import * (Convert.ToDecimal(igv) / 100), 6);
            //        }

            //        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["valor"].Value = xvalor;
            //        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["importe"].Value = Math.Round(xcantidad * xvalor, 6);
            //        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["dtotimpto"].Value = totimpx;

            //        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["precioanterior"].Value = xprecio;

            //        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad"].Value = xcantidad;
            //        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["precunit"].Value = xprecio;
            //        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["importfac"].Value = Math.Round(imporfac, 2);
            //        Tabladetallemov.AcceptChanges();
            //        griddetallemov.CurrentCell = griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["cantidad"];
            //    }
            //    else
            //    {
            //        MessageBox.Show("Producto no existe en Tabla Local Stock !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Producto no Existe !!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btn_information_Click(object sender, EventArgs e)
        {
            var BL = new sys_formulariosBL();
            var BE = new tb_sys_formulario();
            var DataFunc = new DataTable();

            BE.dominioid = dominio;
            BE.moduloid = modulo;
            BE.formname = Name;
            DataFunc = BL.GetAll(VariablesPublicas.EmpresaID, BE).Tables[0];
            if (DataFunc.Rows.Count > 0)
            {
                var frm = new Popup.Frm_webbrowser_single();
                frm.webBrowser1.DocumentText = DataFunc.Rows[0]["formfunc"].ToString().Trim();
                frm.ShowDialog();
            }
        }

        private void chkfijar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkfijar.Checked == true)
            {
                tipodoc.Enabled = false;
            }
            else
            {
                tipodoc.Enabled = true;
            }
        }

        private void btn_refresh_tcamb_Click(object sender, EventArgs e)
        {
            get_tipocambio(fechdoc.Text);
        }

        private void txtefectivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtefectivo.Text.Length > 0)
                {
                    calcularVuelto();
                }
            }
        }

        void calcularVuelto()
        {
            Decimal ximporttarj = 0, xefectivo = 0;
            if (txtefectivo.Text.Length > 0) { xefectivo = Convert.ToDecimal(txtefectivo.Text.ToString()); }
            if (importtarj.Text.Length > 0) { ximporttarj = Convert.ToDecimal(importtarj.Text.ToString()); }
            Decimal xtotimporte = Convert.ToDecimal(totimporte.Text.ToString());

            txtvuelto.Text = (xefectivo - (xtotimporte - ximporttarj)).ToString("##,###,##0.00");
        }

        private void princombo_CheckedChanged(object sender, EventArgs e)
        {
            this.canticombo.Enabled = this.princombo.Checked;

            if (this.canticombo.Enabled)
            {
                this.canticombo.Value = this.canticombo.Value == 0 ? 1 : this.canticombo.Value;
                this.calcular_totales();
            }

        }

        private void canticombo_EditValueChanged(object sender, EventArgs e)
        {
            this.calcular_totales();
        }

        private void form_cargar_datos_referencia(String posicion)
        {
            try
            {
                ControlName();
                limpiar_documento_referencia();
                var BL = new tb_ad_movimientosBL();
                var BE = new tb_ad_movimientos();
                var dt = new DataTable();

                BE.moduloid = modulo;
                BE.local = local;
                BE.tipodoc = tipfac.Text.ToString().Trim();

                if (serfac.Text.Trim().Length > 0)
                {
                    BE.serdoc = serfac.Text.Trim().PadLeft(4, '0');
                    BE.numdoc = numfac.Text.Trim().PadLeft(10, '0');
                }
                else
                {
                    if (posicion.Trim().Length > 0)
                    {
                        MessageBox.Show("Seleccionar el Tipo de Documento de Referencia !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }
                if (numfac.Text.Trim().Length > 0)
                {
                    BE.numdoc = numfac.Text.Trim().PadLeft(10, '0');
                }
                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["status"].ToString().Trim() == "9")
                    {
                        MessageBox.Show("Documento de Referencia ANULADO!!...verifique", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dt.Clear();
                        return;
                    }
                    //ssModo = "EDIT";
                    serfac.Text = dt.Rows[0]["serdoc"].ToString().Trim();
                    numfac.Text = dt.Rows[0]["numdoc"].ToString().Trim();
                    //fechfac.Checked = true;
                    fechfac.Text = dt.Rows[0]["fechdoc"].ToString().Trim();

                    recep_name.Text = dt.Rows[0]["recep_name"].ToString().Trim();
                    recep_dni.Text = dt.Rows[0]["recep_dni"].ToString().Trim();
                    recep_fecha.Text = dt.Rows[0]["recep_fecha"].ToString().Trim();

                    tipimptoid = dt.Rows[0]["tipimptoid"].ToString().Trim();
                    direcnume = dt.Rows[0]["direcnume"].ToString().Trim();
                    incprec = dt.Rows[0]["incprec"].ToString().Trim();
                    if (incprec.ToString() == "N")
                    {
                        cbo_incprec.SelectedIndex = 1;
                    }
                    else
                    {
                        cbo_incprec.SelectedIndex = 0;
                    }

                    moneda.SelectedValue = dt.Rows[0]["moneda"].ToString().Trim();
                    tcamb.Text = dt.Rows[0]["tcamb"].ToString().Trim();

                    if (dt.Rows[0]["tipimptoid"].ToString().Trim().Length > 0)
                    {
                        tipimptotasa.SelectedValue = dt.Rows[0]["tipimptoid"].ToString().Trim();
                    }
                    else
                    {
                        tipimptotasa.SelectedIndex = 0;
                    }
                    ctacte.Text = dt.Rows[0]["ctacte"].ToString().Trim();
                    nmruc.Text = dt.Rows[0]["nmruc"].ToString().Trim();
                    ctactename.Text = dt.Rows[0]["ctactename"].ToString().Trim();
                    direc.Text = dt.Rows[0]["direc"].ToString().Trim();

                    vendperid.Text = dt.Rows[0]["vendorid"].ToString().Trim();
                    vendpername.Text = dt.Rows[0]["vendorname"].ToString().Trim();

                    //if (dt.Rows[0]["serfac"].ToString().Trim().Length > 0 && dt.Rows[0]["numfac"].ToString().Trim().Length > 0)
                    //{
                    //    tipfac.Text = dt.Rows[0]["tipfac"].ToString().Trim();
                    //    serfac.Text = dt.Rows[0]["serfac"].ToString().Trim();
                    //    numfac.Text = dt.Rows[0]["numfac"].ToString().Trim();
                    //    fechfac.Format = DateTimePickerFormat.Short;
                    //    fechfac.Text = dt.Rows[0]["fechfac"].ToString().Trim();
                    //}
                    //else
                    //{
                    //    tipfac.SelectedIndex = 0;
                    //}

                    //if (dt.Rows[0]["serguia"].ToString().Trim().Length > 0 && dt.Rows[0]["numguia"].ToString().Trim().Length > 0)
                    //{
                    //    serguia.Text = dt.Rows[0]["serguia"].ToString().Trim();
                    //    numguia.Text = dt.Rows[0]["numguia"].ToString().Trim();
                    //    fechguia.Format = DateTimePickerFormat.Short;
                    //    fechguia.Text = dt.Rows[0]["fechguia"].ToString().Trim();
                    //}

                    //if (dt.Rows[0]["sernotac"].ToString().Trim().Length > 0 && dt.Rows[0]["numnotac"].ToString().Trim().Length > 0)
                    //{
                    //    sernotac.Text = dt.Rows[0]["sernotac"].ToString().Trim();
                    //    numnotac.Text = dt.Rows[0]["numnotac"].ToString().Trim();
                    //    fechnotac.Format = DateTimePickerFormat.Short;
                    //    fechnotac.Text = dt.Rows[0]["fechnotac"].ToString().Trim();
                    //}

                    tip_operacion = "05"; //dt.Rows[0]["tipoperacionid"].ToString().Trim();

                    itemsT.Text = dt.Rows[0]["items"].ToString().Trim();
                    totpzas.Text = dt.Rows[0]["totpzas"].ToString().Trim();
                    bruto.Text = dt.Rows[0]["bruto"].ToString().Trim();
                    totdscto1.Text = dt.Rows[0]["totdscto1"].ToString().Trim();
                    valventa.Text = dt.Rows[0]["valventa"].ToString().Trim();
                    totimpto.Text = dt.Rows[0]["totimpto"].ToString().Trim();
                    totimporte.Text = dt.Rows[0]["totimporte"].ToString().Trim();
                    glosa.Text = dt.Rows[0]["glosa"].ToString().Trim();
                    // Venta en Combo
                    princombo.Checked = Convert.ToBoolean(dt.Rows[0]["princombo"].ToString() == "True" ? 1 : 0);
                    canticombo.Value = Convert.ToInt32(dt.Rows[0]["cantcombo"].ToString() == "" ? "0" : dt.Rows[0]["cantcombo"].ToString()) == 0 ? 1 : Convert.ToInt32(dt.Rows[0]["cantcombo"].ToString() == "" ? "0" : dt.Rows[0]["cantcombo"].ToString());
                    preccombo.Text = Convert.ToDecimal(dt.Rows[0]["preccombo"].ToString() == "" ? "0" : dt.Rows[0]["preccombo"].ToString()).ToString("###,##0.00");
                    //
                    importtarj.Text = dt.Rows[0]["tarjimporte1"].ToString().Trim();
                    txtefectivo.Text = dt.Rows[0]["efectivo"].ToString().Trim();

                    if (dt.Rows[0]["tarjetaid"].ToString() != "")
                    { _xtarjetaid = Convert.ToInt32(dt.Rows[0]["tarjetaid"].ToString()); }

                    if (dt.Rows[0]["tarjnumoper"].ToString() != "")
                    { _xtarjnumoper = dt.Rows[0]["tarjnumoper"].ToString().Trim(); }

                    data_Tabladetallemovmov_referencia();
                    //data_TablaTarjetas();

                    //if (dt.Rows[0]["status"].ToString().Trim() != "9")
                    //{
                    //    btn_editar.Enabled = true;
                    //    btn_eliminar.Enabled = true;
                    //    btn_imprimir.Enabled = true;
                    //    btnImprimirNoval.Enabled = true;

                    //    btn_primero.Enabled = true;
                    //    btn_anterior.Enabled = true;
                    //    btn_siguiente.Enabled = true;
                    //    btn_ultimo.Enabled = true;

                    //    btn_salir.Enabled = true;
                    //    griddetallemov.Focus();
                    //    griddetallemov.Rows[0].Selected = false;
                    //    pdtimagen.Visible = false;

                    //    princombo.Enabled = false;
                    //    canticombo.Enabled = false;
                    //}
                    //else
                    //{
                    //    ssModo = "ANULADO";
                    //    pdtimagen.Visible = true;
                    //    btn_editar.Enabled = false;
                    //    btn_eliminar.Enabled = false;
                    //    btn_imprimir.Enabled = true;
                    //    btnImprimirNoval.Enabled = true;

                    //    btn_primero.Enabled = true;
                    //    btn_anterior.Enabled = true;
                    //    btn_siguiente.Enabled = true;
                    //    btn_ultimo.Enabled = true;
                    //    btn_salir.Enabled = true;

                    //    princombo.Enabled = false;
                    //    canticombo.Enabled = false;
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiar_documento_referencia()
        {
            try
            {

                itemsT.Text = "0";
                totpzas.Text = "0";
                bruto.Text = "0";
                telef.Text = string.Empty;
                totdscto1.Text = "0";
                valventa.Text = "0";
                totimpto.Text = "0";
                totimporte.Text = "0";
                txt_valor.Text = "0";
                txt_stock.Text = "0";

                importtarj.Text = "0";
                txtefectivo.Text = "0";
                _xtarjnumoper = "";
                _xtarjetaid = 0;

                if (TablaTarjetas != null)
                    if (TablaTarjetas.Rows != null)
                    {
                        TablaTarjetas.Clear();
                    }

                //data_Tabladetallemovmov();
                glosa.Text = string.Empty;
                // Venta en Combo
                princombo.Checked = false;
                canticombo.Enabled = false;
                canticombo.Value = 1;
                preccombo.Text = "0.00";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void data_Tabladetallemovmov_referencia()
        {
            try
            {
                Decimal xxprecventa = 0;
                Decimal xxcostoultimo = 0;
                Decimal xxstock = 0;
                Decimal xxcostopromed = 0;
                griddetallemov.AutoGenerateColumns = false;

                var BL = new tb_ad_movimientosBL();
                var BE = new tb_ad_movimientos();
                var dt = new DataTable();
                BE.moduloid = modulo;
                BE.local = local;
                BE.tipodoc = tipfac.Text.Trim();
                BE.serdoc = serfac.Text.Trim().PadLeft(4, '0');
                BE.numdoc = numfac.Text.Trim().PadLeft(6, '0');

                dt = null; //BL.GetAll_datosdetalle(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    statcostopromed = dt.Rows[0]["statcostopromed"].ToString();
                    tiptransac = dt.Rows[0]["tiptransac"].ToString();
                    incprec = dt.Rows[0]["incprec"].ToString().Trim();
                }

                if (Tabladetallemov != null)
                {
                    Tabladetallemov.Clear();
                }

                foreach (DataRow fila in dt.Rows)
                {
                    var BL2 = new tb_ad_local_stockBL();
                    var BE2 = new tb_ad_local_stock();
                    var dt2 = new DataTable();
                    BE2.moduloid = modulo;
                    BE2.productid = fila["productid"].ToString();
                    dt2.Clear();
                    dt2 = BL2.GetAll(EmpresaID, BE2).Tables[0];

                    if (dt2.Rows.Count > 0)
                    {

                        if (almacaccionid.Trim() == "20" || almacaccionid.Trim() == "21")
                        {
                            lbl_valor.Text = "Cost.Prom";
                            xxprecventa = 0;
                            xxcostopromed = Convert.ToDecimal(dt2.Rows[0]["costopromed"]);
                        }
                        else
                        {
                            if (almacaccionid.Trim() == "10" || almacaccionid.Trim() == "11")
                            {
                                lbl_valor.Text = "Cost.Ultm";
                                xxcostoultimo = Convert.ToDecimal(dt2.Rows[0]["costoultimo"]);
                            }
                        }
                        xxstock = Convert.ToDecimal(dt2.Rows[0]["stock"]);
                    }

                    row = Tabladetallemov.NewRow();
                    row["itemref"] = fila["itemref"].ToString();
                    row["items"] = fila["items"].ToString();
                    row["productid"] = fila["productid"].ToString().Trim();
                    row["productname"] = fila["productname"].ToString().Trim();
                    row["rollo"] = fila["rollo"].ToString();
                    row["stock"] = xxstock;
                    row["stock_old"] = xxstock;
                    row["precventa"] = xxprecventa;
                    row["costoultimo"] = xxcostoultimo;
                    row["costopromed"] = xxcostopromed;

                    var cantidad = Math.Round(Convert.ToDecimal(fila["cantidad"]), 4);
                    var cantidadcta = Math.Round(Convert.ToDecimal(fila["cantidadcta"]), 4);
                    Decimal total;
                    total = cantidad - cantidadcta;

                    row["cantidad"] = total;

                    row["cantidad_old"] = Math.Round(Convert.ToDecimal(fila["cantidad"]), 4);
                    row["precunit"] = Math.Round(Convert.ToDecimal(Convert.ToDecimal(fila["precunit"]).ToString("###,###,##0.000000")), 6);
                    row["importfac"] = Math.Round(Convert.ToDecimal(fila["importfac"]), 2);
                    row["valor"] = Math.Round(Convert.ToDecimal(fila["valor"]), 6);
                    row["importe"] = Math.Round(Convert.ToDecimal(fila["importe"]), 6);
                    row["totimpto"] = Math.Round(Math.Round(Convert.ToDecimal(fila["importe"]), 6) * (Convert.ToDecimal(18) / 100), 6);
                    row["almacaccionid"] = almacaccionid.Trim();
                    row["unmed"] = fila["unmed"].ToString().Trim();
                    row["ubicacion"] = fila["ubicacion"].ToString().Trim();
                    row["nostock"] = xnostock;
                    Tabladetallemov.Rows.Add(row);
                }
                griddetallemov.DataSource = Tabladetallemov;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkFA_CheckedChanged(object sender, EventArgs e)
        {
            tipfac.Enabled = chkFA.Checked;
            serfac.Enabled = chkFA.Checked;
            numfac.Enabled = chkFA.Checked;
            fechfac.Enabled = chkFA.Checked;
            recep_name.Enabled = chkFA.Checked;
            recep_dni.Enabled = chkFA.Checked;
            recep_fecha.Enabled = chkFA.Checked;
        }

        private void chkGR_CheckedChanged(object sender, EventArgs e)
        {
            serguia.Enabled = chkGR.Checked;
            numguia.Enabled = chkGR.Checked;
            fechguia.Enabled = chkGR.Checked;
        }

        private void chkNC_CheckedChanged(object sender, EventArgs e)
        {
            sernotac.Enabled = chkNC.Checked;
            numnotac.Enabled = chkNC.Checked;
            fechnotac.Enabled = chkNC.Checked;
        }


        //private void cmdReloadCapcha_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //            CargarImagen();
        //            txtCapcha.Text = "";
        //            txtCapcha.Focus();
        //            txtCapcha.SelectAll();
        //    }
        //    catch (Exception ex)
        //    {
        //        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
        //    }
        //}

        //private void CargarImagen()
        //{
        //    if (VariablesPublicas.compruebaConexion() == true)
        //    {
        //        try
        //        {
        //            myInfoSunat = new DatoSUNAT();
        //            ImagenSunat.Image = myInfoSunat.GetCapchaSunat;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //    else
        //    {
        //        //    DevExpress.XtraEditors.XtraMessageBox.Show("Sin conexión a Internet", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        ctactename.Text = "Sin conexión a Internet";
        //    }
        //}
    }
}
