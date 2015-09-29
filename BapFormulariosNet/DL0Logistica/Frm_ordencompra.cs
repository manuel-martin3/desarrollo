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
using System.Diagnostics;

namespace BapFormulariosNet.DL0Logistica
{
    public partial class Frm_ordencompra : plantilla
    {
        /*** variables de cabecera del documento actual ***/
        String EmpresaID = VariablesPublicas.EmpresaID;
        String dominio = "L0";
        String modulo = ""; 
        String moduloid = "";
        String local = "";

        String perianio = "";
        String perimes = "";
        String tipodoc = "OC";
        String dominioiddes = "60";

        String XNIVEL = "";
        String XGLOSA = "";
        String PERFILID = "";

        DataTable Tabladetalleocompra;
        private DataRow row;
        private TextBox txtCDetalle = null;
        private DateTimePicker txtCFecha = null;
        private ComboBox CmbEquiv = null;

        String almacaccionid = "";
        Boolean fechadocedit = false;
        Boolean tipodocautomatico = false;
        Boolean tipodocmanejaserie = false;
        Boolean statusDoc = true;
        Boolean activeDoc = false;

        String tipimptoid = "";
        Decimal pigv = 0;        
        String incprec = "N";
        String ssModo = "NEW";
        static Decimal xprecventa = 0, xcostoultimo = 0;


        #region
        // Variables Para Generar Orden de CompraDet_Aux
        String CodigoPROD = "", NombrePROD = "",AniosemanaPROD="",ItemrefPROD="",AlmaccionidPROD= "";
        Decimal CantidadPROD = 0, ImportfacPROD = 0, PrecunitPROD = 0,PrecioanteriorPROD = 0, EquivPROD = 0; 
        Int32 itemPROD = 1;
        DateTime FechentregaPROD ;
        Decimal TotimptoPROD = 0;
        Decimal CantPROD = 0;



        #endregion


        public Frm_ordencompra()
        {
            InitializeComponent();

            numdoc.LostFocus += new System.EventHandler(numdoc_LostFocus);
            fechdoc.LostFocus += new System.EventHandler(fechdoc_LostFocus);
            ctacte.LostFocus += new System.EventHandler(ctacte_LostFocus);
            nmruc.LostFocus += new System.EventHandler(nmruc_LostFocus);
            compradorid.LostFocus += new System.EventHandler(compradorid_LostFocus);
        }

        #region $$$ ADMINISTRADOR
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
                Ayudas.Form_user_admin miForma = new Ayudas.Form_user_admin();
                miForma.Owner = this;
                miForma.PasaDatos = RecibePermiso;
                miForma.ShowDialog();
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
        #endregion

        #region *** Metodos generales
        private void select_tipodoc()
        {
            try
            {
                //Boolean tipodocautomatico, tipodocmanejaserie;
                if (tipodoc.Trim().Length == 2)
                {
                    modulo_local_tipodocBL BL = new modulo_local_tipodocBL();
                    tb_modulo_local_tipodoc BE = new tb_modulo_local_tipodoc();
                    DataTable dt = new DataTable();
                    BE.dominioid = dominio;
                    BE.moduloid = modulo;
                    BE.local = local;
                    BE.tipodoc = tipodoc.Trim();
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
                                get_CmDocSeries_numOCompra();
                                //get_autoCS_numOCompra();
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
                                get_autoCS_numOCompra();
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
                            tipoclieprov.Text = "Cliente RUC: ";
                            lbl_valor.Text = "Cost.Prom";
                        }
                        else
                        {
                            lbl_valor.Text = "Cost.Ultm";
                            tipoclieprov.Text = "Proveedor RUC: ";

                        }
                        data_cbo_tiporeferencia(almacaccionid);
                    }
                    else
                    {
                        MessageBox.Show("Asignar la Accion del Documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        statusDoc = false;
                    }
                }
                else
                {
                    serdoc.Text = "";
                    numdoc.Text = "";
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
                constantesgeneralesBL BL = new constantesgeneralesBL();
                tb_constantesgenerales BE = new tb_constantesgenerales();
                DataTable dt = new DataTable();

                dt = BL.GetOne(EmpresaID, dominio, modulo, local).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    perianio = dt.Rows[0]["perianio"].ToString().Trim();
                    perimes = dt.Rows[0]["perimes"].ToString().Trim();
                    fechadocedit = Convert.ToBoolean(dt.Rows[0]["fechadocedit"]);
                }

                DateTime fechaactual = DateTime.Today;
                DateTime fechaperiodo = Convert.ToDateTime("01" + "/" + perimes + "/" + perianio);

                if (fechadocedit)
                {
                    DateTime primerdia = new DateTime(fechaperiodo.Year, fechaperiodo.Month, 1);
                    DateTime ultimodia = primerdia.AddMonths(1).AddDays(-1);
                    if (fechaactual.Day <= ultimodia.Day)
                    {
                        fechdoc.Value = Convert.ToDateTime(fechaactual.Day + "/" + perimes + "/" + perianio);
                    }
                    else
                    {
                        fechdoc.Value = Convert.ToDateTime(ultimodia.Day + "/" + perimes + "/" + perianio);
                    }
                    //fechdoc.MaxDate = ultimodia;
                    //fechdoc.MinDate = primerdia;
                }
                else
                {
                    if (fechaactual.Month == fechaperiodo.Month && fechaactual.Year == fechaperiodo.Year)
                    {
                        fechdoc.Value = fechaactual;
                        fechdoc.Enabled = false;
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


        private void get_CmDocSeries_numOCompra()
        {
            try
            {
                modulo_local_tipodocseriesBL BL = new modulo_local_tipodocseriesBL();
                tb_modulo_local_tipodocseries BE = new tb_modulo_local_tipodocseries();
                DataTable dt = new DataTable();

                BE.moduloid = moduloid;
                BE.perianio = VariablesPublicas.perianio.ToString(); //((DL0Logistica.MainLogistica)MdiParent).perianio;

                dt = BL.CmDocSeries_nuevonumero(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    serdoc.Text = dt.Rows[0]["moduloid"].ToString();
                    numdoc2.Text = dt.Rows[0]["perianio"].ToString();
                    numdoc.Text = dt.Rows[0]["numero"].ToString();
                }
                else
                {
                    serdoc.Text = "";
                    numdoc.Text = "";
                    numdoc2.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void get_autoCS_numOCompra()
        {
            try
            {
                modulo_local_tipodocseriesBL BL = new modulo_local_tipodocseriesBL();
                tb_modulo_local_tipodocseries BE = new tb_modulo_local_tipodocseries();
                DataTable dt = new DataTable();
                BE.dominioid = dominio;
                BE.moduloid = modulo;
                BE.local = local;
                BE.tipodoc = tipodoc.Trim();

                dt = BL.GetAll_nuevonumero(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    serdoc.Text = dt.Rows[0]["serdoc"].ToString();
                    numdoc.Text = dt.Rows[0]["numero"].ToString();
                }
                else
                {
                    serdoc.Text = "";
                    numdoc.Text = "";
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
                tb_tipimptoBL BL = new tb_tipimptoBL();
                tb_tipimpto BE = new tb_tipimpto();
                DataTable dt = new DataTable();
                BE.status = true;

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    //tipimptoid = dt.Rows[0]["tipimptoid"].ToString();
                    //igv = Convert.ToDecimal(dt.Rows[0]["tipimptotasa"]);
                    //tipimptotasa.Text = dt.Rows[0]["tipimptotasa"].ToString() + "%";

                    tipimptotasa.DataSource = dt;
                    tipimptotasa.ValueMember = "tipimptoid";
                    tipimptotasa.DisplayMember = "tipimptotasa";
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
        private void get_tipocambio(String fecha)
        {
            try
            {
                //genera tipo de cambio dependiendo la fech del documento
                tipocambioBL BL = new tipocambioBL();
                tb_tipocambio BE = new tb_tipocambio();
                DataTable dt = new DataTable();

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
        private void get_pdetraccion(String detraccionid)
        {
            try
            {
                //genera tipo de cambio dependiendo la fech del documento
                tb_co_detraccionBL BL = new tb_co_detraccionBL();
                tb_co_detraccion BE = new tb_co_detraccion();
                DataTable dt = new DataTable();

                dt = BL.GetOne(EmpresaID, detraccionid).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    pdetraccion.Text = dt.Rows[0]["detraccionporcent"].ToString().Trim();
                }
                else
                {
                    tcamb.Text = "0";
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
                    moduloiddes.Enabled = !var;
                    numdoc.Enabled = !var;
                }
                else
                {
                    moduloiddes.Enabled = !var;
                    numdoc.Enabled = !var;
                }

                if (VariablesPublicas.EmpresaRuc == "20471861619") //RUC IMPORTACIONES VIALEX S.A.C
                {
                    groupBox1.Enabled = false;
                }
                else {
                    groupBox1.Enabled = true;
                }


                serdoc.Enabled = false;
                numdoc2.Enabled = false;
                fechdoc.Enabled = false;
                fechaulting.Enabled = var;
                moneda.Enabled = var;
                tcamb.Enabled = var;
                tcamb.ReadOnly = true;
                tipimptotasa.Enabled = var;
                //tipimptotasa.ReadOnly = true;
                localdes.Enabled = var;
                fechentrega.Enabled = var;
                fechpago.Enabled = var;
                nmruc.Enabled = var;
                ctacte.Enabled = var;
                ctactename.Enabled = var;
                ctactename.ReadOnly = true;
                direc.Enabled = var;
                direc.ReadOnly = true;
                condpagoid.Enabled = var;
                tipref.Enabled = var;
                serref.Enabled = var;
                numref.Enabled = var;
                fechref.Enabled = var;
                serped.Enabled = var;
                numped.Enabled = var;
                compradorid.Enabled = var;
                compradorname.Enabled = var;
                compradorname.ReadOnly = true;
                afecdetraccion.Enabled = var;
                detraccionid.Enabled = var;
                pdetraccion.Enabled = var;
                pdetraccion.ReadOnly = true;
                atencion.Enabled = var;
                puntollegada.Enabled = var;
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

                griddetalleocompra.ReadOnly = !var;
                griddetalleocompra.Columns["item"].ReadOnly = true;
                griddetalleocompra.Columns["productname"].ReadOnly = true;
                griddetalleocompra.Columns["stock"].ReadOnly = true;
                griddetalleocompra.Columns["importfac"].ReadOnly = true;

                btn_nuevo.Enabled = false;
                btn_editar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_grabar.Enabled = false;
                btn_GenerarOrden.Enabled = false;

                btn_eliminar.Enabled = false;
                btn_imprimir.Enabled = false;
                btn_imprimiraux.Enabled = false;


                btn_primero.Enabled = false;
                btn_anterior.Enabled = false;
                btn_siguiente.Enabled = false;
                btn_ultimo.Enabled = false;

                btn_detanadir.Enabled = false;
                btn_deteliminar.Enabled = false;

                btn_canculadora.Enabled = true;
                btn_clave.Enabled = true;
                btn_log.Enabled = true;
                btn_salir.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void form_accion_cancelEdicion(int confirnar)
        {
            bool sw_prosigue = true;
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
                limpiar_documento();
                moduloiddes.SelectedIndex = 0;
                moduloiddes.Enabled = false;
                form_bloqueado(false);
                numdoc.Text = "";                
                btn_nuevo.Enabled = true;
                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;
                btn_canculadora.Enabled = true;
                btn_salir.Enabled = true;

                ssModo = "NEW";
                //fechdoc.MinDate = new DateTime(2000, 1, 1);
                //fechdoc.MaxDate = new DateTime(2999, 12, 12);
                fechdoc.Value = DateTime.Today;
                fechaulting.Value = DateTime.Today;
                nmruc.Focus();
            }
        }

        private void form_cargar_datos(String posicion)
        {
            try
            {
               
                limpiar_documento();
                tb_cm_ordendecompracabBL BL = new tb_cm_ordendecompracabBL();
                tb_cm_ordendecompracab BE = new tb_cm_ordendecompracab();
                DataTable dt = new DataTable();

                BE.moduloid = modulo;
                BE.local = local;
                BE.tipodoc = tipodoc.Trim();

                
                BE.serdoc = serdoc.Text.ToString();

                String n_doc = "";
                if (numdoc.Text.Trim().Length > 0)
                {
                    n_doc = numdoc.Text.Trim().PadLeft(6, '0');
                }

                BE.numdoc = numdoc2.Text.ToString() + "" + n_doc.ToString();

                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    activeDoc = false;
                    limpiar_documento();
                    form_bloqueado(false);
                    ssModo = "EDIT";
                    //data_cbo_tiporeferencia(almacaccionid);
                    serdoc.Text = dt.Rows[0]["serdoc"].ToString().Trim();

                    String n = dt.Rows[0]["numdoc"].ToString().Trim();

                    numdoc2.Text = Equivalencias.Left(n, 4);
                    numdoc.Text = Equivalencias.Right(n, 6);

                    fechdoc.Text = dt.Rows[0]["fechdoc"].ToString().Trim();

                    moduloiddes.SelectedValue = dt.Rows[0]["moduloiddes"].ToString().Trim();
                    data_cbo_localdes(dominioiddes, moduloiddes.SelectedValue.ToString());
                    localdes.SelectedValue = dt.Rows[0]["localdes"].ToString().Trim();

                    if (dt.Rows[0]["fechentrega"].ToString().Trim().Length > 0 && dt.Rows[0]["fechentrega"].ToString().Trim().Substring(0, 10) != "01/01/1900")
                    {
                        fechentrega.Format = DateTimePickerFormat.Short;
                        fechentrega.Text = dt.Rows[0]["fechentrega"].ToString().Trim();
                    }
                    if (dt.Rows[0]["fechpago"].ToString().Trim().Length > 0 && dt.Rows[0]["fechpago"].ToString().Trim().Substring(0, 10) != "01/01/1900")
                    {
                        fechpago.Format = DateTimePickerFormat.Short;
                        fechpago.Text = dt.Rows[0]["fechpago"].ToString().Trim();
                    }
                    incprec = dt.Rows[0]["incprec"].ToString().Trim();
                    moneda.SelectedValue = dt.Rows[0]["moneda"].ToString().Trim();
                    tcamb.Text = dt.Rows[0]["tcamb"].ToString().Trim();
                    pigv = Convert.ToDecimal(dt.Rows[0]["pigv"]);
                    tipimptotasa.Text = Math.Round(pigv, 0).ToString();// + "%";
                    ctacte.Text = dt.Rows[0]["ctacte"].ToString().Trim();
                    nmruc.Text = dt.Rows[0]["nmruc"].ToString().Trim();
                    ctactename.Text = dt.Rows[0]["ctactename"].ToString().Trim();
                    direc.Text = dt.Rows[0]["direc"].ToString().Trim();
                    if (dt.Rows[0]["condpagoid"] != null)
                        condpagoid.SelectedValue = dt.Rows[0]["condpagoid"].ToString().Trim();
                    if (dt.Rows[0]["tipref"].ToString().Trim().Length > 0 && dt.Rows[0]["serref"].ToString().Trim().Length > 0)
                    {
                        tipref.SelectedValue = dt.Rows[0]["tipref"].ToString().Trim();
                        serref.Text = dt.Rows[0]["serref"].ToString().Trim();
                        numref.Text = dt.Rows[0]["numref"].ToString().Trim();
                        fechref.Format = DateTimePickerFormat.Short;
                    }
                    if (dt.Rows[0]["serped"].ToString().Trim().Length > 0 && dt.Rows[0]["numped"].ToString().Trim().Length > 0)
                    {
                        serped.Text = dt.Rows[0]["serped"].ToString().Trim();
                        numped.Text = dt.Rows[0]["numped"].ToString().Trim();
                    }
                    //compradorid, compradorname
                    ValidaComprador(dt.Rows[0]["compradorid"].ToString(), true);
                    if (dt.Rows[0]["afecdetraccion"].ToString().Trim().Length > 0)
                        afecdetraccion.Checked = Convert.ToBoolean(dt.Rows[0]["afecdetraccion"]);
                    if (dt.Rows[0]["detraccionid"].ToString().Trim().Length > 0)
                        detraccionid.SelectedValue = dt.Rows[0]["detraccionid"].ToString().Trim();
                    pdetraccion.Text = dt.Rows[0]["pdetraccion"].ToString().Trim();
                    atencion.Text = dt.Rows[0]["atencion"].ToString().Trim();
                    puntollegada.Text = dt.Rows[0]["puntollegada"].ToString().Trim();
                    itemsT.Text = dt.Rows[0]["items"].ToString().Trim();
                    totpzas.Text = dt.Rows[0]["totpzas"].ToString().Trim();
                    bruto.Text = dt.Rows[0]["bruto"].ToString().Trim();
                    //totdscto1.Text = dt.Rows[0]["totdscto1"].ToString().Trim();
                    valventa.Text = dt.Rows[0]["valventa"].ToString().Trim();
                    totimpto.Text = dt.Rows[0]["totimpto"].ToString().Trim();
                    totimporte.Text = dt.Rows[0]["totimporte"].ToString().Trim();
                    glosa.Text = dt.Rows[0]["glosa"].ToString().Trim();

                    //Tabladetalleocompra DEL DOCUMENTO
                    data_Tabladetalleocompra();


                    btn_nuevo.Enabled = true;
                    pictureEdit1.Visible = false;
                    if (dt.Rows[0]["status"].ToString().Trim() != "9")
                    {
                        btn_editar.Enabled = true;
                        btn_eliminar.Enabled = true;
                        btn_imprimir.Enabled = true;
                        btn_imprimiraux.Enabled = true;
                    }
                    else
                    {
                        pictureEdit1.Visible = true;
                    }
                    btn_primero.Enabled = true;
                    btn_anterior.Enabled = true;
                    btn_siguiente.Enabled = true;
                    btn_ultimo.Enabled = true;

                    btn_canculadora.Enabled = true;
                    btn_log.Enabled = true;
                    btn_salir.Enabled = true;
                    griddetalleocompra.Focus();
                    //griddetalleocompra.Rows[0].Selected = false;
                }
                Cambiar_Icono();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region $$$ Llenado de Combobox
        void data_cbo_moduloiddes()
        {
            try
            {
                sys_moduloBL BL = new sys_moduloBL();
                tb_sys_modulo BE = new tb_sys_modulo();
                BE.dominioid = dominioiddes.Trim();

                DataTable dt = new DataTable();
                BE.status = "0";
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                moduloiddes.DataSource = dt;
                moduloiddes.ValueMember = "moduloid";
                moduloiddes.DisplayMember = "moduloname";
                //moduloiddes.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void data_cbo_localdes(String dominioid, String moduloid)
        {
            try
            {
                sys_localBL BL = new sys_localBL();
                tb_sys_local BE = new tb_sys_local();
                BE.dominioid = dominioid;
                BE.moduloid = moduloid;

                DataTable dt = new DataTable();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0) {
                    VariablesPublicas.localdirec = dt.Rows[0]["localdirec"].ToString();
                    //VariablesPublicas.numruc = dt.Rows[0]["nmruc"].ToString();
                    VariablesPublicas.telef = dt.Rows[0]["telef"].ToString();
                }                

                localdes.DataSource = dt;
                localdes.ValueMember = "local";
                localdes.DisplayMember = "localname";
                localdes.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void data_cbo_moneda()
        {
            try
            {
                tb_co_tabla04_tipomonedaBL BL = new tb_co_tabla04_tipomonedaBL();
                tb_co_tabla04_tipomoneda BE = new tb_co_tabla04_tipomoneda();
                moneda.DataSource = BL.GetAll(EmpresaID, BE).Tables[0];
                moneda.ValueMember = "monedaid";
                moneda.DisplayMember = "sigla";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void data_cbo_condpagoid()
        {
            try
            {
                tb_condpagoBL BL = new tb_condpagoBL();
                tb_condpago BE = new tb_condpago();
                condpagoid.DataSource = BL.GetAll(EmpresaID, BE).Tables[0];
                condpagoid.ValueMember = "condpagoid";
                condpagoid.DisplayMember = "condpagoname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void data_cbo_tiporeferencia(string accion)
        {           
            try
            {
                modulo_local_tipodocBL BL = new modulo_local_tipodocBL();
                tb_modulo_local_tipodoc BE = new tb_modulo_local_tipodoc();
                BE.dominioid = dominio;
                BE.moduloid = modulo;
                BE.local = local;
                BE.almacaccionid = Convert.ToString(Convert.ToInt16(accion) + 1);
                BE.visiblealmac = true;

                DataTable dt = new DataTable();

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                tipref.DataSource = dt;
                tipref.ValueMember = "tipodoc";
                tipref.DisplayMember = "tipodocname";
                tipref.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void data_cbo_detraccionid()
        {
            try
            {
                tb_co_detraccionBL BL = new tb_co_detraccionBL();
                tb_co_detraccion BE = new tb_co_detraccion();
                detraccionid.DataSource = BL.GetAll(EmpresaID, BE).Tables[0];
                detraccionid.ValueMember = "detraccionid";
                detraccionid.DisplayMember = "detraccionname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void ValidaCliente()
        {
            if (ctacte.Text.Trim().Length > 0)
            {
                clienteBL BL = new clienteBL();
                tb_cliente BE = new tb_cliente();
                DataTable dt = new DataTable();
                BE.ctacte = ctacte.Text.Trim().PadLeft(7, '0');
                if (nmruc.Text.Trim().Length > 0)
                    BE.nmruc = nmruc.Text.Trim();

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
                    ctacte.Text = "";
                    nmruc.Text = "";
                    ctactename.Text = "";
                    direc.Text = "";
                    nmruc.Focus();
                }
            }
        }

        private void ValidaComprador(String xcompradorid, Boolean retrn)
        {
            if (xcompradorid.Trim().Length > 0)
            {
                tb_comprador_corporativoBL BL = new tb_comprador_corporativoBL();
                tb_comprador_corporativo BE = new tb_comprador_corporativo();
                DataTable dt = new DataTable();
                BE.compradorid = xcompradorid.Trim().PadLeft(4, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    compradorid.Text = dt.Rows[0]["compradorid"].ToString().Trim();
                    compradorname.Text = dt.Rows[0]["compradorname"].ToString().Trim();
                }
                else
                {
                    if (!retrn)
                    {
                        compradorid.Text = "";
                        compradorname.Text = "";
                        compradorid.Focus();
                    }
                }
            }
        }

        private string get_aniosemana(String fechentrega)
        {
            try
            {
                if (Equivalencias.IsDate(fechentrega))
                {
                    tipocambioBL BL = new tipocambioBL();
                    tb_tipocambio BE = new tb_tipocambio();
                    DataTable dt = new DataTable();
                    dt = BL.GetOne(EmpresaID, Convert.ToDateTime(fechentrega)).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        return dt.Rows[0]["aniosemana"].ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }

            }
            catch (Exception ex)
            {
                return "";
            }
        }
        #endregion

        #region *** Eventos
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
        
        //protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData /*KeyEventArgs keyData*/)
        //{
        //    if (keyData == Keys.Enter)
        //    {
        //        SendKeys.Send("\t");
        //        return true;
        //    }

        //    return base.ProcessCmdKey(ref msg, keyData);
        //}

        #endregion

        #region *** Metodos que retornan datos
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
                tb_tipimptoBL BL = new tb_tipimptoBL();
                tb_tipimpto BE = new tb_tipimpto();
                DataTable dt = new DataTable();
                BE.tipimptoid = tipimptoid.Trim();

                dt = BL.GetOne(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return Math.Round(Convert.ToDecimal(dt.Rows[0]["tipimptotasa"]), 0).ToString();// +"%";
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region *** Grid Ayuda general forms
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
        }

        private void AyudaClientes(String lpdescrlike)
        {
            try
            {
                Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql"; //sql,tabla
                frmayuda.titulo = "Ayuda Cliente/Proveedor";
                frmayuda.sqlquery = "select ctacte, ctactename, nmruc, direc from tb_cliente";
                frmayuda.sqlinner = ""; //inner
                frmayuda.sqlwhere = "where"; //where
                frmayuda.sqland = "";//and
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

        private void Ayudacomprador(String lpdescrlike)
        {
            try
            {
                Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql"; //sql,tabla
                frmayuda.titulo = "Ayuda Comprador";
                frmayuda.sqlquery = "select compradorid, compradorname from tb_comprador_corporativo";
                frmayuda.sqlinner = ""; //inner
                frmayuda.sqlwhere = "where"; //where
                frmayuda.sqland = "";//and
                frmayuda.criteriosbusqueda = new string[] { "COMPRADOR", "CÓDIGO" };
                frmayuda.columbusqueda = "compradorname,compradorid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = Recibecomprador;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }
        private void Recibecomprador(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                compradorid.Text = resultado1.Trim();
                compradorname.Text = resultado2.Trim();
            }
        }

        private void AyudaProducto(String lpdescrlike)
        {
            try
            {
                String modd = "";
                sys_moduloBL BL = new sys_moduloBL();
                tb_sys_modulo BE = new tb_sys_modulo();
                DataTable dt = new DataTable();

                BE.dominioid = dominioiddes.Trim();
                BE.moduloid = moduloiddes.SelectedValue.ToString();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();

                        Ayudas.Form_help_gridproducto_cm frmayuda = new Ayudas.Form_help_gridproducto_cm();

                        frmayuda.tipoo = "sql"; //sql,tabla
                        frmayuda.titulo = "<< AYUDA  TABLA PRODUCTOS (100 - PRIMEROS)>>";
                        frmayuda.sqlquery = "SELECT TOP 100 tb1.productid, tb1.productname, Sum(tb2.stock) stock,AVG(tb2.costoultimo) costoultimo FROM tb_" + modd + "_productos AS tb1 ";
                        frmayuda.sqlinner = "inner join tb_" + modd + "_local_stock as tb2 on tb1.productid = tb2.productid"; //inner
                        if (moduloiddes.SelectedValue.ToString() == "0500") { frmayuda.sqlwhere = "where tb1.status = '0'  and tb1.nserie = ' ' "; }
                        else { frmayuda.sqlwhere = "where tb1.status = '0' AND tb2.moduloid = " + moduloiddes.SelectedValue.ToString() +" "; }
                        frmayuda.sqland = "AND ";//and
                        frmayuda.sqlgroupby = "GROUP BY "+
                                            " tb1.productid,"+
                                            " tb1.productname ";
                        frmayuda.criteriosbusqueda = new string[] { "PRODUCTO", "CODIGO" };
                        frmayuda.columbusqueda = "tb1.productname,tb1.productid";
                        frmayuda.returndatos = "0,1";

                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeProducto;
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

                    int cont = 0;
                    foreach (DataRow fila in dtresultado.Rows)
                    {
                        cont = cont + 1;
                        if (this.griddetalleocompra.Rows.Count > 0)
                        {
                            int nFilaAnt = griddetalleocompra.RowCount - 1;
                            String xProductid = fila["productid"].ToString();
                            String xProductname = fila["productname"].ToString();
                            //String unmed = fila["unmed"].ToString();

                            if (cont > 1)
                            {
                                this.Tabladetalleocompra.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetalleocompra));
                                Tabladetalleocompra.Rows[this.griddetalleocompra.Rows.Count - 1]["items"] = VariablesPublicas.CalcMaxField(this.Tabladetalleocompra, "items", 5);
                                this.griddetalleocompra.Rows[nFilaAnt + 1].Cells["productid"].Value = xProductid;
                                this.griddetalleocompra.Rows[nFilaAnt + 1].Cells["productname"].Value = xProductname;
                            }
                            else
                            {
                                this.griddetalleocompra.Rows[nFilaAnt].Cells["productid"].Value = xProductid;
                                this.griddetalleocompra.Rows[nFilaAnt].Cells["productname"].Value = xProductname;
                            }

                            this.griddetalleocompra.CurrentCell = this.griddetalleocompra.Rows[griddetalleocompra.RowCount - 1].Cells["cantidad"];
                            this.griddetalleocompra.BeginEdit(true);
                            ValidaTabladetalleocompra(xProductid);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ModoEdicion(String prodid, String prodname)
        {
            try
            {
                tb_cm_ordendecompraBL BL = new tb_cm_ordendecompraBL();
                tb_cm_ordendecompra.Item BE = new tb_cm_ordendecompra.Item();

                BE.productid = prodid;
                BE.moduloiddes = moduloiddes.SelectedValue.ToString();

                DataTable dt = new DataTable();
                dt = BL.Get_ctactename(VariablesPublicas.EmpresaID , BE).Tables[0];
                Ayudas.Form_Edicion frmedicion = new Ayudas.Form_Edicion();

                if (dt.Rows.Count > 0)
                {
                    frmedicion.ctactename = dt.Rows[0]["productname"].ToString();
                }
                else
                    frmedicion.ctactename = "No Existe Producto";
                                
                frmedicion.productid = prodid;
                frmedicion.ctactenamedetalle = prodname.ToString();
                frmedicion.moduloid = moduloiddes.SelectedValue.ToString();
                frmedicion.Owner = this;                
                frmedicion.PasaName = RecibeCtacteName;                                                                
                frmedicion.ShowDialog();                               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void RecibeCtacteName(String resultado1, String prodid)
        {

            String modd = "";
            tb_cm_ordendecompradetBL BL = new tb_cm_ordendecompradetBL();
            //tb_cm_ordendecompraBL BL = new tb_cm_ordendecompraBL();
            tb_cm_ordendecompradet BE = new tb_cm_ordendecompradet();

            try
            {
                if (resultado1.Trim().Length > 0)
                {
                    // Procedimientos Para Modificar el ctactename de la orden de compra                    
                    BE.moduloid = modulo;
                    BE.productid = prodid;
                    BE.numdoc = numdoc2.Text.ToString() +""+ numdoc.Text.ToString();
                    BE.tipodoc = tipodoc;
                    BE.serdoc = moduloiddes.SelectedValue.ToString();
                    BE.ctactename = resultado1.ToString();

                    if (BL.Updatectacte(VariablesPublicas.EmpresaID.ToString(), BE))
                    {                        
                        MessageBox.Show("Datos modificado correctamente !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        form_cargar_datos("");
                    }                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        #endregion

        #region *** Metodos mantenimiento de datos
        private void SEGURIDAD_LOG(String accion)
        {
            String xclave = VariablesPublicas.EmpresaID + "-" + modulo + "-" + tipodoc.Trim() + "-" + serdoc.Text.Trim() + "-" + numdoc.Text.Trim();
            try
            {
                tb_co_seguridadlogBL BL = new tb_co_seguridadlogBL();
                tb_co_seguridadlog BE = new tb_co_seguridadlog();

                BE.moduloid = Name;
                BE.clave = xclave;
                BE.cuser = VariablesPublicas.Usuar;
                BE.fecha = DateTime.Now;
                BE.pc = VariablesPublicas.userip;
                BE.accion = accion.Trim();
                BE.detalle = tipodoc.Trim() + "-" + serdoc.Text.Trim() + "-" + numdoc.Text.Trim() + "/" + XGLOSA;

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

                tipimptoid = "";
                incprec = "N";
                ssModo = "NEW";

                fechdoc.Text = "";
                moneda.SelectedValue = "S";
                tcamb.Text = "1";
                tipimptotasa.Text = "";
                localdes.SelectedIndex = -1;
                //fechentrega.CustomFormat = " ";
                //fechentrega.Format = DateTimePickerFormat.Custom;
                fechentrega.Text = "";
                fechentrega.Text = System.DateTime.Today.ToShortDateString();
                
                //fechpago.CustomFormat = " ";
                //fechpago.Format = DateTimePickerFormat.Custom;
                fechdoc.Text = "";
                fechdoc.Text = System.DateTime.Today.ToShortDateString();

                fechpago.CustomFormat = " ";
                fechpago.Text = System.DateTime.Today.ToShortDateString();

                fechaulting.CustomFormat = "";
                fechaulting.Text = System.DateTime.Today.ToShortDateString();

                ctacte.Text = "";
                nmruc.Text = "";
                ctactename.Text = "";
                direc.Text = "";
                condpagoid.SelectedIndex = -1;
                tipref.DataSource = null;
                serref.Text = "";
                numref.Text = "";
                fechref.CustomFormat = " ";
//                fechref.Format = DateTimePickerFormat.Custom;
                fechaulting.Text = System.DateTime.Today.ToShortDateString();

                serped.Text = "";
                numped.Text = "";
                compradorid.Text = "";
                compradorname.Text = "";
                afecdetraccion.Checked = false;
                detraccionid.SelectedIndex = -1;
                pdetraccion.Text = "0";
                atencion.Text = "";
                puntollegada.Text = "";
                itemsT.Text = "0";
                totpzas.Text = "0";
                bruto.Text = "0";
                totdscto1.Text = "0";
                valventa.Text = "0";
                totimpto.Text = "0";
                totimporte.Text = "0";
                txt_valor.Text = "0";
                txt_stock.Text = "0";

                if (Tabladetalleocompra != null)
                {
                    Tabladetalleocompra.Rows.Clear();
                    griddetalleocompra.DataSource = Tabladetalleocompra;
                }

               data_Tabladetalleocompra();                

                glosa.Text = "";
                pictureEdit1.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Blanqueo()
        {
            try
            {
                NIVEL_FORMS();

                tipimptoid = "";
                incprec = "N";
                ssModo = "NEW";

                fechdoc.Text = "";
                moneda.SelectedValue = "S";
                tcamb.Text = "1";
                tipimptotasa.Text = "";
                localdes.SelectedIndex = -1;
                fechentrega.Text = "";
                fechentrega.Text = System.DateTime.Today.ToShortDateString();
                fechdoc.Text = "";
                fechdoc.Text = System.DateTime.Today.ToShortDateString();
                fechpago.CustomFormat = " ";
                fechpago.Text = System.DateTime.Today.ToShortDateString();
                fechaulting.CustomFormat = "";
                fechaulting.Text = System.DateTime.Today.ToShortDateString();
                ctacte.Text = "";
                nmruc.Text = "";
                ctactename.Text = "";
                direc.Text = "";
                condpagoid.SelectedIndex = -1;
                tipref.DataSource = null;
                serref.Text = "";
                numref.Text = "";
                fechref.CustomFormat = " ";
                fechaulting.Text = System.DateTime.Today.ToShortDateString();
                serped.Text = "";
                numped.Text = "";
                compradorid.Text = "";
                compradorname.Text = "";
                afecdetraccion.Checked = false;
                detraccionid.SelectedIndex = -1;
                pdetraccion.Text = "0";
                atencion.Text = "";
                puntollegada.Text = "";
                itemsT.Text = "0";
                totpzas.Text = "0";
                bruto.Text = "0";
                totdscto1.Text = "0";
                valventa.Text = "0";
                totimpto.Text = "0";
                totimporte.Text = "0";
                txt_valor.Text = "0";
                txt_stock.Text = "0";

                if (Tabladetalleocompra != null)
                {
                    Tabladetalleocompra.Rows.Clear();
                    griddetalleocompra.DataSource = Tabladetalleocompra;
                }

                glosa.Text = "";
                pictureEdit1.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void _cal_Igv()
        {

            int xval_igv = Convert.ToInt32(tipimptotasa.SelectedValue);
            if (xval_igv == 1)
            {
                pigv = 18;
            }
            else
            {
                pigv = 0;
            }
        }


        private void calcular_totales()
        {
            decimal stotal = 0;            
            if (Tabladetalleocompra != null)
            {
                if (Tabladetalleocompra.Rows.Count != 0)
                {

                    _cal_Igv();
                    //Calcular total items
                    itemsT.Text = Tabladetalleocompra.Rows.Count.ToString();
                    //Calcular total piezas
                    totpzas.Text = Convert.ToDecimal(Tabladetalleocompra.Compute("sum(cantidad)", "")).ToString("##,###,##0.00");
                    //Calcular total bruto
                    bruto.Text = Math.Round(Convert.ToDecimal(Tabladetalleocompra.Compute("sum(importfac)", "")), 2).ToString("##,###,##0.00");

                    //obteniendo el importfac
                    stotal = Math.Round(Convert.ToDecimal(Tabladetalleocompra.Compute("sum(importfac)", "")), 2);
                    if (incprec.Trim() == "S")
                    {
                        //calcular valor de venta
                        valventa.Text = Math.Round(stotal * (100 / (100 + pigv)), 2).ToString("###,###,##0.00");
                        //Calcular impuesto
                        totimpto.Text = Math.Round(stotal * (100 / (100 + pigv)) * (pigv / 100), 2).ToString("###,###,##0.00");
                        //Calcular total a pagar
                        totimporte.Text = stotal.ToString("###,###,##0.00");
                    }
                    else
                    {
                        //valventa.Text = Math.Round(Convert.ToDecimal(Tabladetalleocompra.Compute("sum(importfac)", "")), 4).ToString("###,###,##0.00");
                        ////Calcular impuesto
                        //totimpto.Text = Math.Round(Convert.ToDecimal(Tabladetalleocompra.Compute("sum(totimpto)", "")), 4).ToString("###,###,##0.00");
                        ////Calcular total a pagar
                        //totimporte.Text = Math.Round(Convert.ToDecimal(valventa.Text) + Convert.ToDecimal(totimpto.Text), 4).ToString("###,###,##0.00");
                        //calcular valor de venta
                        valventa.Text = stotal.ToString("###,###,##0.00");
                        //Calcular impuesto
                        totimpto.Text = Math.Round(stotal * (pigv / 100), 2).ToString("###,###,##0.00");
                        //Calcular total a pagar                    
                        totimporte.Text = Math.Round(stotal + (stotal * (pigv / 100)), 2).ToString("###,###,##0.00");
                    }
                }
                else
                {
                    //Calcular total items
                    itemsT.Text = Tabladetalleocompra.Rows.Count.ToString();
                    //Calcular total piezas
                    totpzas.Text = "0";
                    //Calcular total bruto
                    bruto.Text = "0";
                    //Calcular valor de venta
                    valventa.Text = "0";
                    //Calcular impuesto
                    totimpto.Text = "0";
                    //Calcular total a pagar
                    totimporte.Text = "0";
                }
            }
        }

        private void nuevo()
        {
            moduloiddes.SelectedIndex = 0;
            limpiar_documento();
            form_bloqueado(false);
            get_val_fechadoc();
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_GenerarOrden.Enabled = true;
            btn_detanadir.Enabled = true;
            btn_deteliminar.Enabled = true;
          
            ssModo = "NEW";
            serdoc.Enabled = false;

            numdoc.Enabled = VariablesPublicas.editnumdoc;
            fechdoc.Enabled = VariablesPublicas.editnumdoc;

        }

        private void Insert()
        {
            try
            {
                _cal_Igv();

                if (ctacte.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Proveedor/Cliente !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (Tabladetalleocompra.Rows.Count == 0)
                {
                    MessageBox.Show("Documento no tiene Items !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (tcamb.Text.Trim() == "1")
                {

                    MessageBox.Show("Actualize el Tipo de Cambio !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    _RecalculoGrid();

                    if ((numdoc2.Text.ToString() + numdoc.Text.Trim()).Length == 10)
                    {

                        // Variables de Cabecera
                        tb_cm_ordendecompraBL BL = new tb_cm_ordendecompraBL();
                        tb_cm_ordendecompra BE = new tb_cm_ordendecompra();

                        // Variables para Detalle
                        tb_cm_ordendecompra.Item Detalle = new tb_cm_ordendecompra.Item();
                        List<tb_cm_ordendecompra.Item> ListaItems = new List<tb_cm_ordendecompra.Item>();

                        #region **ingreso ordencompra cabecera***
                        // LOGISTICA SIEMPRE SERA 
                        BE.dominioid = "L0";    
                        BE.moduloid = "0100";
                        BE.local = "001";


                        BE.tipodoc = tipodoc.Trim();
                        BE.serdoc = serdoc.Text.Trim();
                        BE.numdoc = numdoc2.Text.ToString() + "" + numdoc.Text.ToString();
                        BE.fechdoc = Convert.ToDateTime(fechdoc.Text);
                        BE.moneda = moneda.SelectedValue.ToString().Trim();
                        BE.tcamb = Convert.ToDecimal(tcamb.Text.Trim());
                        //accion del alamacen dependiendo del tipo de documento
                        BE.almacaccionid = almacaccionid.Trim();


                        // Modulo y local de Referencia 
                        BE.moduloiddes = moduloiddes.SelectedValue.ToString();
                        BE.localdes = localdes.SelectedValue.ToString();



                        //datos condicion de pago
                        try { BE.fechcancel = Convert.ToDateTime("01/01/1900"); }
                        catch { BE.fechcancel = Convert.ToDateTime("01/01/1900"); }
                        try { BE.fechentrega = Convert.ToDateTime(fechentrega.Text.Trim()); }
                        catch { BE.fechentrega = Convert.ToDateTime("01/01/1900"); }
                        try { BE.fechpago = Convert.ToDateTime(fechpago.Text.Trim()); }
                        catch { BE.fechpago = Convert.ToDateTime("01/01/1900"); }

                        try { BE.fechaulting = Convert.ToDateTime(fechaulting.Text.Trim()); }
                        catch { BE.fechaulting = Convert.ToDateTime("01/01/1900"); }
                        

                        //datos proveedor y/o cliente
                        BE.ctacteaccionid = "";
                        BE.ctacte = ctacte.Text.Trim().ToUpper();
                        BE.nmruc = nmruc.Text.Trim();
                        BE.ctactename = ctactename.Text.Trim().ToUpper();
                        BE.direc = direc.Text.Trim().ToUpper();
                        if (condpagoid.SelectedIndex != -1)
                            BE.condpagoid = condpagoid.SelectedValue.ToString();
                        //datos documento de referencia
                        if (tipref.SelectedValue != null && serref.Text.Trim().Length > 0)
                        {
                            BE.tipref = tipref.SelectedValue.ToString();
                            BE.serref = serref.Text.Trim().PadLeft(4, '0');
                            BE.numref = numref.Text.Trim().PadLeft(10, '0');
                            try { BE.fechref = Convert.ToDateTime(fechref.Text.Trim()); }
                            catch { BE.fechref = Convert.ToDateTime("01/01/1900"); }
                        }
                        //referencia pedido
                        if (serped.Text.Trim().Length > 0 && numped.Text.Trim().Length > 0)
                        {
                            BE.tipped = "PP";
                            BE.serped = serped.Text.Trim().PadLeft(4, '0');
                            BE.numped = numped.Text.Trim().PadLeft(10, '0');
                        }
                        //datos de comprador
                        if (compradorid.Text.Trim().Length > 0) { BE.compradorid = compradorid.Text.Trim().ToString(); };
                        //detraccion
                        if (afecdetraccion.Checked)
                        {
                            BE.afecdetraccion = afecdetraccion.Checked;
                            BE.detraccionid = detraccionid.SelectedValue.ToString();
                            BE.pdetraccion = Convert.ToDecimal(pdetraccion.Text.Trim());
                        }
                        BE.atencion = atencion.Text.Trim().ToUpper();
                        BE.puntollegada = puntollegada.Text.Trim().ToUpper();
                        //datos glosa
                        BE.glosa = glosa.Text.Trim().ToUpper().ToString();
                        //datos ubigeo
                        BE.ubige = "000000";
                        //datos incluido IGV
                        BE.incprec = incprec.Trim();
                        //datos totales calculados
                        BE.items = Convert.ToDecimal(itemsT.Text.Trim());
                        BE.totpzas = Convert.ToDecimal(totpzas.Text.Trim());
                        BE.bruto = Convert.ToDecimal(bruto.Text.Trim());
                        BE.pigv = pigv;
                        BE.totimpto = Convert.ToDecimal(totimpto.Text.Trim());
                        BE.valventa = Convert.ToDecimal(valventa.Text.Trim());
                        BE.totimporte = Convert.ToDecimal(totimporte.Text.Trim());
                        //otros
                        BE.tipdid = "";
                        //opt
                        BE.tipodocmanejaserie = tipodocmanejaserie;
                        //datos de usuario
                        BE.perianio = perianio;
                        BE.perimes = perimes;
                        BE.status = "0";
                        BE.usuar = VariablesPublicas.Usuar;
                        #endregion

                        #region ****ingreso ordencompra detalle***
                        int item = 0;
                        foreach (DataRow fila in Tabladetalleocompra.Rows)
                        {
                            Detalle = new tb_cm_ordendecompra.Item();

                            item++;

                            //Modulo y Local de referencia
                            Detalle.moduloiddes = moduloiddes.SelectedValue.ToString().Trim();
                            Detalle.localdes = localdes.SelectedValue.ToString().Trim();                            
                            Detalle.fechdoc = Convert.ToDateTime(fechdoc.Text);
                            Detalle.fechentrega = Convert.ToDateTime(fechentrega.Text);
                            Detalle.moneda = moneda.SelectedValue.ToString().Trim();
                            Detalle.tcamb = Convert.ToDecimal(tcamb.Text.Trim());                            
                            Detalle.ctacte = ctacte.Text.Trim().ToUpper();
                            Detalle.ctactename = ctactename.Text.Trim().ToUpper();                            
                            if (tipref.SelectedValue != null && serref.Text.Trim().Length > 0)
                            {
                                Detalle.tipref = tipref.SelectedValue.ToString();
                                Detalle.serref = serref.Text.Trim().PadLeft(4, '0');
                                Detalle.numref = numref.Text.Trim().PadLeft(10, '0');
                                try { Detalle.fechref = Convert.ToDateTime(fechref.Text.Trim()); }
                                catch { Detalle.fechref = Convert.ToDateTime("01/01/1900"); }
                            }
                            //referencia pedido
                            if (serped.Text.Trim().Length > 0 && numped.Text.Trim().Length > 0)
                            {
                                Detalle.tipped = "PP";
                                Detalle.serped = serped.Text.Trim().PadLeft(4, '0');
                                Detalle.numped = numped.Text.Trim().PadLeft(10, '0');
                            }
                            //datos de comprador
                            if (compradorid.Text.Trim().Length > 0) { Detalle.compradorid = compradorid.Text.Trim().ToString(); };
                            //datos calculados de detalle de movimiento obtenidos de memoria
                            Detalle.itemref = fila["itemref"].ToString();
                            Detalle.itemsdet = item.ToString().PadLeft(5, '0');
                            Detalle.productid = fila["productid"].ToString();
                            Detalle.productname = fila["productname"].ToString();


                            // Primero Verificamos la Fila el Producto id 
                            Decimal fil_n = Convert.ToDecimal(fila["equiv_id"]);
                            tb_cm_equivalenciaBL equivalenciaBL = new tb_cm_equivalenciaBL();


                            Detalle.Cantidadcta_c = 0;

                            if (fil_n != null)
                                Detalle.equivid =(int) fil_n;
                            else
                                //Detalle.equivid = 0;

                            //if (Equivalencias.IsDate(fila["fechentrega"]))
                            //    Detalle.fechentrega = Convert.ToDateTime(fila["fechentrega"]);

                            Detalle.aniosemana = fila["aniosemana"].ToString();
                            Detalle.precioanterior = Convert.ToDecimal(fila["precioanterior"]);
                            Detalle.precunit = Convert.ToDecimal(fila["precunit"]);
                            //caputaramos el precio unitario en una variable
                            Decimal precunit = Convert.ToDecimal(fila["precunit"]);


                            Decimal importfac = Convert.ToDecimal(fila["importfac"]);

                            if (moneda.SelectedValue.ToString()=="$")
                            {
                                Decimal tcambio = Convert.ToDecimal( tcamb.Text);
                                
                                //hallamos el valor 
                                
                                Detalle.valor = precunit * tcambio;
                                Detalle.importe = importfac * tcambio;
                            }
                            else if (moneda.SelectedValue.ToString()=="S")
                            {
                                Detalle.valor = Convert.ToDecimal(fila["valor"]);
                                Detalle.importe = Convert.ToDecimal(fila["importfac"]);
                            }
                            Detalle.cantidad = Convert.ToDecimal(fila["cantidad"]);
                            
                            Detalle.importfac = Convert.ToDecimal(fila["importfac"]);
                            //importe 
                           
                            Detalle.totimpto = Convert.ToDecimal(fila["totimpto"]);
                            Detalle.cantidad_c = Convert.ToDecimal(fila["cantidad_c"]);                            

                            Detalle.precunit_c = Convert.ToDecimal(fila["precunit_c"]);
                            //accion del alamacen dependiendo del tipo de documento
                            Detalle.almacaccionid = fila["almacaccionid"].ToString();
                            //datos si es incluido IGV
                            Detalle.incprec = incprec.Trim();
                            Detalle.pigv = pigv;
                            //glosa - observacion
                            Detalle.glosa = glosa.Text.Trim().ToUpper().ToString();
                            //dato de usuario
                            Detalle.perianio = perianio;
                            Detalle.perimes = perimes;
                            Detalle.status = "0";
                            Detalle.usuar = VariablesPublicas.Usuar;

                            //if (fila["productid"].ToString().Trim().Length == 13)
                            if (fila["productid"].ToString().Trim().Length == 13 && Convert.ToDecimal(fila["cantidad"]) > 0 && Convert.ToDecimal(fila["importfac"]) > 0)                            
                            {
                                ListaItems.Add(Detalle);
                            }
                            else
                            {
                                MessageBox.Show("Documento DETALLE EN FORMATO INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        if (ListaItems.Count == 0)
                        {
                            MessageBox.Show("Documento SIN DETALLE Y/O DETALLE INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        BE.ListaItems = ListaItems;
                        if (BL.Insert(EmpresaID, BE))
                        {
                            NIVEL_FORMS();

                            MessageBox.Show("Datos grabados correctamente !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            form_bloqueado(false);
                            Blanqueo();
                            btn_nuevo.Enabled = true;
                            btn_imprimir.Enabled = true;
                            btn_imprimiraux.Enabled = true;

                            btn_primero.Enabled = true;
                            btn_anterior.Enabled = true;
                            btn_siguiente.Enabled = true;
                            btn_ultimo.Enabled = true;

                            btn_canculadora.Enabled = true;
                            btn_salir.Enabled = true;
                        }
                        #endregion
                        
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
            try
            {
                _cal_Igv();

                if (ctacte.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Proveedor/Cliente !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (Tabladetalleocompra.Rows.Count == 0)
                {
                    MessageBox.Show("Documento no tiene Items !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (tcamb.Text.Trim() == "1")
                {

                    MessageBox.Show("Actualize el Tipo de Cambio !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {

                    //_RecalculoGrid();

                    if ((numdoc2.Text.ToString() + numdoc.Text.Trim()).Length == 10)
                    {

                        // Variables de Cabecera
                        tb_cm_ordendecompraBL BL = new tb_cm_ordendecompraBL();
                        tb_cm_ordendecompra BE = new tb_cm_ordendecompra();

                        // Variables para Detalle
                        tb_cm_ordendecompra.Item Detalle = new tb_cm_ordendecompra.Item();
                        List<tb_cm_ordendecompra.Item> ListaItems = new List<tb_cm_ordendecompra.Item>();


                        #region **ingreso ordencompra cabecera***

                        // LOGISTICA SIEMPRE SERA 
                        BE.dominioid = "L0";
                        BE.moduloid = "0100";
                        BE.local = "001";


                        BE.tipodoc = tipodoc.Trim();
                        BE.serdoc = serdoc.Text.Trim();
                        BE.numdoc = numdoc2.Text.ToString() + "" + numdoc.Text.ToString();
                        BE.fechdoc = Convert.ToDateTime(fechdoc.Text);
                        BE.moneda = moneda.SelectedValue.ToString().Trim();
                        BE.tcamb = Convert.ToDecimal(tcamb.Text.Trim());
                        //accion del alamacen dependiendo del tipo de documento
                        BE.almacaccionid = almacaccionid.Trim();



                        // Modulo y local de Referencia
                        BE.moduloiddes = moduloiddes.SelectedValue.ToString();
                        BE.localdes = localdes.SelectedValue.ToString();



                        //datos condicion de pago
                        try { BE.fechcancel = Convert.ToDateTime("01/01/1900"); }
                        catch { BE.fechcancel = Convert.ToDateTime("01/01/1900"); }
                        try { BE.fechentrega = Convert.ToDateTime(fechentrega.Text.Trim()); }
                        catch { BE.fechentrega = Convert.ToDateTime("01/01/1900"); }
                        try { BE.fechpago = Convert.ToDateTime(fechpago.Text.Trim()); }
                        catch { BE.fechpago = Convert.ToDateTime("01/01/1900"); }
                        //datos proveedor y/o cliente
                        BE.ctacteaccionid = "";
                        BE.ctacte = ctacte.Text.Trim().ToUpper();
                        BE.nmruc = nmruc.Text.Trim();
                        BE.ctactename = ctactename.Text.Trim().ToUpper();
                        BE.direc = direc.Text.Trim().ToUpper();
                        if (condpagoid.SelectedIndex != -1)
                            BE.condpagoid = condpagoid.SelectedValue.ToString();
                        //datos documento de referencia
                        if (tipref.SelectedValue != null && serref.Text.Trim().Length > 0)
                        {
                            BE.tipref = tipref.SelectedValue.ToString();
                            BE.serref = serref.Text.Trim().PadLeft(4, '0');
                            BE.numref = numref.Text.Trim().PadLeft(10, '0');
                            try { BE.fechref = Convert.ToDateTime(fechref.Text.Trim()); }
                            catch { BE.fechref = Convert.ToDateTime("01/01/1900"); }
                        }
                        //referencia pedido
                        if (serped.Text.Trim().Length > 0 && numped.Text.Trim().Length > 0)
                        {
                            BE.tipped = "PP";
                            BE.serped = serped.Text.Trim().PadLeft(4, '0');
                            BE.numped = numped.Text.Trim().PadLeft(10, '0');
                        }
                        //datos de comprador
                        if (compradorid.Text.Trim().Length > 0) { BE.compradorid = compradorid.Text.Trim().ToString(); };
                        //detraccion
                        if (afecdetraccion.Checked)
                        {
                            BE.afecdetraccion = afecdetraccion.Checked;
                            BE.detraccionid = detraccionid.SelectedValue.ToString();
                            BE.pdetraccion = Convert.ToDecimal(pdetraccion.Text.Trim());
                        }
                        BE.atencion = atencion.Text.Trim().ToUpper();
                        BE.puntollegada = puntollegada.Text.Trim().ToUpper();
                        //datos glosa
                        BE.glosa = glosa.Text.Trim().ToUpper().ToString();
                        //datos ubigeo
                        BE.ubige = "000000";
                        //datos incluido IGV
                        BE.incprec = incprec.Trim();
                        //datos totales calculados
                        BE.items = Convert.ToDecimal(itemsT.Text.Trim());
                        BE.totpzas = Convert.ToDecimal(totpzas.Text.Trim());
                        BE.bruto = Convert.ToDecimal(bruto.Text.Trim());
                        BE.pigv = pigv;
                        BE.totimpto = Convert.ToDecimal(totimpto.Text.Trim());
                        BE.valventa = Convert.ToDecimal(valventa.Text.Trim());
                        BE.totimporte = Convert.ToDecimal(totimporte.Text.Trim());
                        //otros
                        BE.tipdid = "";
                        //opt
                        BE.tipodocmanejaserie = tipodocmanejaserie;
                        //datos de usuario
                        BE.perianio = perianio;
                        BE.perimes = perimes;
                        BE.status = "0";
                        BE.usuar = VariablesPublicas.Usuar;
                        #endregion

                        #region ****ingreso ordencompra detalle***
                        int item = 0;
                        foreach (DataRow fila in Tabladetalleocompra.Rows)
                        {
                            Detalle = new tb_cm_ordendecompra.Item();

                            item++;

                            //Modulo y Local de referencia
                            Detalle.moduloiddes = moduloiddes.SelectedValue.ToString().Trim();
                            Detalle.localdes = localdes.SelectedValue.ToString().Trim();
                            //datos documento cabecera importante [todos]
                            Detalle.fechdoc = Convert.ToDateTime(fechdoc.Text);
                            Detalle.fechentrega = Convert.ToDateTime(fechentrega.Text);
                            Detalle.moneda = moneda.SelectedValue.ToString().Trim();
                            Detalle.tcamb = Convert.ToDecimal(tcamb.Text.Trim());
                            //datos proveedor y/o cliente
                            Detalle.ctacte = ctacte.Text.Trim().ToUpper();
                            Detalle.ctactename = ctactename.Text.Trim().ToUpper();
                            //datos documento de referencia
                            if (tipref.SelectedValue != null && serref.Text.Trim().Length > 0)
                            {
                                Detalle.tipref = tipref.SelectedValue.ToString();
                                Detalle.serref = serref.Text.Trim().PadLeft(4, '0');
                                Detalle.numref = numref.Text.Trim().PadLeft(10, '0');
                                try { Detalle.fechref = Convert.ToDateTime(fechref.Text.Trim()); }
                                catch { Detalle.fechref = Convert.ToDateTime("01/01/1900"); }
                            }
                            //referencia pedido
                            if (serped.Text.Trim().Length > 0 && numped.Text.Trim().Length > 0)
                            {
                                Detalle.tipped = "PP";
                                Detalle.serped = serped.Text.Trim().PadLeft(4, '0');
                                Detalle.numped = numped.Text.Trim().PadLeft(10, '0');
                            }
                            //datos de comprador
                            if (compradorid.Text.Trim().Length > 0) { Detalle.compradorid = compradorid.Text.Trim().ToString(); };
                            //datos calculados de detalle de movimiento obtenidos de memoria
                            Detalle.itemref = fila["itemref"].ToString();
                            Detalle.itemsdet = item.ToString().PadLeft(5, '0');
                            Detalle.productid = fila["productid"].ToString();
                            Detalle.productname = fila["productname"].ToString();

                            // Esta Fecha Tddba no Stamos Usando Es FechaEntrega por cada item del detalle
                            //if (Equivalencias.IsDate(fila["fechentrega"]))
                            //    Detalle.fechentrega = Convert.ToDateTime(fila["fechentrega"]);

                            Detalle.aniosemana = fila["aniosemana"].ToString();
                            Detalle.precioanterior = Convert.ToDecimal(fila["precioanterior"]);
                            
                            // Primero Verificamos la Fila el Producto id 
                            Int32 fil_n = Convert.ToInt32(fila["equiv_id"]);                            

                            if ((Convert.ToInt32(fila["equiv_id"])) != null)
                                Detalle.equivid = Convert.ToInt32(fila["equiv_id"]);
                            else
                                Detalle.equivid = 0;

                            /* PARA OBTENER EL VALOR SELECCIONADO Y EL TEXTO DE UN COMBOBOX DENTRO DEL DATAGRIDVIEW
                            string SelectedText = Convert.ToString((griddetalleocompra.Rows[0].Cells["equiv_id"] as DataGridViewComboBoxCell).FormattedValue.ToString());
                            int SelectedVal = Convert.ToInt32(griddetalleocompra.Rows[0].Cells["equiv_id"].Value);
                             * */
                           //  CurrencyManager cm = (CurrencyManager)griddetalleocompra.BindingContext[((System.Windows.Forms.DataGridViewComboBoxColumn)griddetalleocompra.Columns["equiv_id"]).DataSource];                                                                                       
                            

                            //Detalle.cantidad_c = Convert.ToDecimal(fila["cantidad_c"]);
                            Detalle.cantidad = Convert.ToDecimal(fila["cantidad"]);
                            //Detalle.precunit_c = Convert.ToDecimal(fila["precunit_c"]);
                            Detalle.precunit = Convert.ToDecimal(fila["precunit"]);
                            
                            Decimal precunit = Convert.ToDecimal(fila["precunit"]);

                            Detalle.importfac = Convert.ToDecimal(fila["importfac"]);

                            Decimal importfac = Convert.ToDecimal(fila["importfac"]);
                            tb_cm_ordendecompra BE3 = new tb_cm_ordendecompra();
                            tb_cm_ordendecompraBL BL3 = new tb_cm_ordendecompraBL();
                            DataTable dt3 = new DataTable();
                            Decimal Equivalencia;

                            BE3.Equivalencia = Convert.ToInt32(fila["equiv_id"]);
                            dt3 = BL3.GetAll(EmpresaID, BE3).Tables[0];

                            if (dt3.Rows.Count > 0)
                            {
                                Equivalencia = Convert.ToDecimal(dt3.Rows[0]["equivalencia"].ToString());                                
                                //Detalle.cantidad = (Convert.ToDecimal(fila["cantidad_c"])) * Equivalencia;
                                Detalle.cantidad_c = (Convert.ToDecimal(fila["cantidad"])) * Equivalencia;
                                Decimal cantidad_c = Detalle.cantidad_c;
                                Detalle.precunit_c = (Detalle.importfac / cantidad_c); //(Convert.ToDecimal(fila["precunit_c"]));// 

                            }

                         
                            Detalle.Cantidadcta_c = Convert.ToDecimal(fila["cantidadcta_c"]);

                            if (moneda.SelectedValue.ToString() == "$")
                            {
                                Decimal tcambio = Convert.ToDecimal(tcamb.Text);

                                //hallamos el valor 

                                Detalle.valor = precunit * tcambio;
                                Detalle.importe = importfac * tcambio;
                            }
                            else if (moneda.SelectedValue.ToString() == "S")
                            {
                                Detalle.valor = Convert.ToDecimal(fila["valor"]);
                                Detalle.importe = Convert.ToDecimal(fila["importfac"]);
                            }


                            
                            Detalle.totimpto = Convert.ToDecimal(fila["totimpto"]);
                            //accion del alamacen dependiendo del tipo de documento

                            //Detalle.Cantidadcta_c = (Convert.ToDecimal(fila["cantidad_c"]));
                            Detalle.almacaccionid = fila["almacaccionid"].ToString();
                            //datos si es incluido IGV
                            Detalle.incprec = incprec.Trim();
                            Detalle.pigv = pigv;
                            //glosa - observacion
                            Detalle.glosa = glosa.Text.Trim().ToUpper().ToString();

                            //dato de usuario
                            Detalle.perianio = perianio;
                            Detalle.perimes = perimes;
                            Detalle.status = "0";
                            Detalle.usuar = VariablesPublicas.Usuar;

                            
                            //if (fila["productid"].ToString().Trim().Length == 13)
                            if (fila["productid"].ToString().Trim().Length == 13 && Convert.ToDecimal(fila["cantidad"]) > 0 && Convert.ToDecimal(fila["importfac"]) > 0)
                            {
                                ListaItems.Add(Detalle);
                            }
                            else
                            {
                                MessageBox.Show("Documento DETALLE EN FORMATO INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        if (ListaItems.Count == 0)
                        {
                            MessageBox.Show("Documento SIN DETALLE Y/O DETALLE INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        BE.ListaItems = ListaItems;
                        if (BL.Update(EmpresaID, BE))
                        {
                            SEGURIDAD_LOG("M");
                            NIVEL_FORMS();
                            MessageBox.Show("Datos modificado correctamente !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            form_bloqueado(false);
                            Blanqueo();
                            btn_nuevo.Enabled = true;
                            btn_imprimir.Enabled = true;
                            btn_imprimiraux.Enabled = true;

                            btn_primero.Enabled = true;
                            btn_anterior.Enabled = true;
                            btn_siguiente.Enabled = true;
                            btn_ultimo.Enabled = true;

                            btn_canculadora.Enabled = true;
                            btn_salir.Enabled = true;
                        }
                        #endregion
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
                else if (Tabladetalleocompra.Rows.Count == 0)
                {
                    MessageBox.Show("Documento no tiene Items !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (numdoc.Text.Trim().Length == 6)
                    {

                        // Variables de Cabecera
                        tb_cm_ordendecompraBL BL = new tb_cm_ordendecompraBL();
                        tb_cm_ordendecompra BE = new tb_cm_ordendecompra();

                        // Variables para Detalle
                        tb_cm_ordendecompra.Item Detalle = new tb_cm_ordendecompra.Item();
                        List<tb_cm_ordendecompra.Item> ListaItems = new List<tb_cm_ordendecompra.Item>();

                        #region *** movimiento ***
                        BE.dominioid = dominio;
                        BE.moduloid = modulo;
                        BE.local = local;
                        BE.tipodoc = tipodoc.Trim();
                        BE.serdoc = serdoc.Text.Trim();
                        BE.numdoc = numdoc2.Text.Trim()+numdoc.Text.Trim();
                        BE.status = "9";
                        BE.usuar = VariablesPublicas.Usuar;

                        if (BL.Delete(EmpresaID, BE))
                        {
                            SEGURIDAD_LOG("E");
                            NIVEL_FORMS();
                            MessageBox.Show("Datos Eliminados Correctamente !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Blanqueo();
                            form_bloqueado(false);
                            numdoc.Enabled = false;

                            btn_nuevo.Enabled = true;

                            btn_primero.Enabled = true;
                            btn_anterior.Enabled = true;
                            btn_siguiente.Enabled = true;
                            btn_ultimo.Enabled = true;

                            btn_canculadora.Enabled = true;
                            btn_salir.Enabled = true;
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region *** Controles de usuarios
        private void Frm_ordencompra_Activated(object sender, EventArgs e)
        {

        }

        private void PARAMETROS_TABLA()
        {
            String xxferfil = "";
            DL0Logistica.MainLogistica f = (DL0Logistica.MainLogistica)this.MdiParent;
            xxferfil = f.perfil.ToString();
            if (xxferfil.Trim().Length != 9)
            {
                MessageBox.Show("::: NO TIENE PERFIL !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PERFILID = xxferfil;
            String XTABLA_PERFIL = "";
            XTABLA_PERFIL = VariablesPublicas.GET_PARAMETROS_TABLA(xxferfil, Name);
            if (XTABLA_PERFIL.Trim().Length > 0 && XTABLA_PERFIL.Trim() != "0")
            {
                if (XTABLA_PERFIL.Trim().Length == 2)
                {
                    dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
                }
                else if (XTABLA_PERFIL.Trim().Length == 6)
                {
                    dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
                    modulo = XTABLA_PERFIL.Trim().Substring(2, 4);
                }
                else if (XTABLA_PERFIL.Trim().Length == 9)
                {
                    dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
                    modulo = XTABLA_PERFIL.Trim().Substring(2, 4);
                    local = XTABLA_PERFIL.Trim().Substring(6, 3);
                }
            }
            else
            {
                MessageBox.Show("::: No puede accede a FORMULARIO. \n::: Es necesario DOMINIO, MODULO Y LOCAL !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        void CargarComboGrid_Equiv()
        {
            DataGridViewComboBoxColumn comboboxColumn = griddetalleocompra.Columns["equiv_id"] as DataGridViewComboBoxColumn;
            tb_cm_ordendecompra BE3 = new tb_cm_ordendecompra();
            tb_cm_ordendecompraBL BL3 = new tb_cm_ordendecompraBL();
            DataTable dt3 = new DataTable();

            dt3 = BL3.GetAll(EmpresaID, BE3).Tables[0];

            comboboxColumn.DataSource = dt3;
            comboboxColumn.Width = 150;
            comboboxColumn.Selected = true;
            comboboxColumn.DisplayMember = "equiv_name";
            comboboxColumn.ValueMember = "equiv_id";            
            griddetalleocompra.AutoGenerateColumns = false;

            //DataGridViewComboBoxCell
        }

        private void Frm_ordencompra_Load(object sender, EventArgs e)
        {
            try
            {

                modulo = ((DL0Logistica.MainLogistica)MdiParent).moduloid;
                local = ((DL0Logistica.MainLogistica)MdiParent).local;
                PERFILID = ((DL0Logistica.MainLogistica)MdiParent).perfil;

                NIVEL_FORMS();
                //PARAMETROS_TABLA();

                CargarComboGrid_Equiv();
                data_cbo_moneda();
                _cal_Igv();
                get_tipimptoid();

                data_cbo_moduloiddes();
                data_cbo_condpagoid();
                data_cbo_detraccionid();

                //--- Definir campos del datatable de detalle
                Tabladetalleocompra = new DataTable("detallocompra");
                Tabladetalleocompra.Columns.Add("itemref", typeof(String));
                Tabladetalleocompra.Columns.Add("items", typeof(String));
                //Tabladetalleocompra.Columns.Add("productid", typeof(String));

                Tabladetalleocompra.Columns.Add("productid", typeof(String));
                Tabladetalleocompra.PrimaryKey = new DataColumn[] { Tabladetalleocompra.Columns["productid"] };
                Tabladetalleocompra.Columns["productid"].Unique = true;

                Tabladetalleocompra.Columns.Add("productname", typeof(String));
                Tabladetalleocompra.Columns.Add("equiv_id", typeof(Int32)); Tabladetalleocompra.Columns["equiv_id"].DefaultValue = 1;    
                Tabladetalleocompra.Columns.Add("fechentrega", typeof(String)); Tabladetalleocompra.Columns["fechentrega"].DefaultValue = "";
                Tabladetalleocompra.Columns.Add("aniosemana", typeof(String));
                Tabladetalleocompra.Columns.Add("aniosemanaconfirm", typeof(String));
                Tabladetalleocompra.Columns.Add("precioanterior", typeof(Decimal)); Tabladetalleocompra.Columns["precioanterior"].DefaultValue = 0;
                Tabladetalleocompra.Columns.Add("stock", typeof(Decimal)); Tabladetalleocompra.Columns["stock"].DefaultValue = 0;
                Tabladetalleocompra.Columns.Add("stock_old", typeof(Decimal)); Tabladetalleocompra.Columns["stock_old"].DefaultValue = 0;
                Tabladetalleocompra.Columns.Add("precventa", typeof(Decimal)); Tabladetalleocompra.Columns["precventa"].DefaultValue = 0;
                Tabladetalleocompra.Columns.Add("costoultimo", typeof(Decimal)); Tabladetalleocompra.Columns["costoultimo"].DefaultValue = 0;
                Tabladetalleocompra.Columns.Add("costopromed", typeof(Decimal)); Tabladetalleocompra.Columns["costopromed"].DefaultValue = 0;
                Tabladetalleocompra.Columns.Add("cantidad", typeof(Decimal)); Tabladetalleocompra.Columns["cantidad"].DefaultValue = 0;
                Tabladetalleocompra.Columns.Add("cantidad_c", typeof(Decimal)); Tabladetalleocompra.Columns["cantidad_c"].DefaultValue = 0;
                Tabladetalleocompra.Columns.Add("precunit_c", typeof(Decimal)); Tabladetalleocompra.Columns["precunit_c"].DefaultValue = 0;                
                Tabladetalleocompra.Columns.Add("cantidad_old", typeof(Decimal)); Tabladetalleocompra.Columns["cantidad_old"].DefaultValue = 0;
                Tabladetalleocompra.Columns.Add("cantidadcta_c", typeof(Decimal)); Tabladetalleocompra.Columns["cantidadcta_c"].DefaultValue = 0;
                
                Tabladetalleocompra.Columns.Add("precunit", typeof(Decimal)); Tabladetalleocompra.Columns["precunit"].DefaultValue = 0;
                Tabladetalleocompra.Columns.Add("valor", typeof(Decimal)); Tabladetalleocompra.Columns["valor"].DefaultValue = 0;
                Tabladetalleocompra.Columns.Add("importe", typeof(Decimal)); Tabladetalleocompra.Columns["importe"].DefaultValue = 0;
                Tabladetalleocompra.Columns.Add("totimpto", typeof(Decimal)); Tabladetalleocompra.Columns["totimpto"].DefaultValue = 0;
                Tabladetalleocompra.Columns.Add("importfac", typeof(Decimal)); Tabladetalleocompra.Columns["importfac"].DefaultValue = 0;
                Tabladetalleocompra.Columns.Add("almacaccionid", typeof(String));

                limpiar_documento();
                form_bloqueado(false);      
                numdoc.Text = "";
                btn_nuevo.Enabled = true;
                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;
                btn_canculadora.Enabled = true;
                btn_salir.Enabled = true;

                txtCFecha = new DateTimePicker();
                txtCFecha.Format = DateTimePickerFormat.Short;
                txtCFecha.Visible = false;
                txtCFecha.Width = 80;
                griddetalleocompra.Controls.Add(txtCFecha);
                txtCFecha.ValueChanged += new EventHandler(txtCFecha_ValueChanged);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_ordencompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                if (!griddetalleocompra.ReadOnly)
                    this.btn_detanadir_Click(sender, e);
            }

            if (e.KeyCode == Keys.Delete)
            {
                if (!griddetalleocompra.ReadOnly)
                    this.btn_deteliminar_Click(sender, e);
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

            if (e.KeyCode == Keys.Escape)
            {
                if (this.btn_cancelar.Enabled)
                {
                    form_accion_cancelEdicion(1);
                }
                else
                {
                    btn_salir_Click(sender, e);
                }
            }
        }

        private void serdoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(numdoc, e);
        }
        private void numdoc_LostFocus(object sender, System.EventArgs e)
        {
            //if (ssModo != "NEW")
            //    form_cargar_datos("");
        }

        private void numdoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo_numero_enteros(numdoc, e);
        }

        private void fechdoc_ValueChanged(object sender, EventArgs e)
        {
            get_tipocambio(fechdoc.Text);
            fechaulting.Focus();
        }
        private void fechdoc_LostFocus(object sender, System.EventArgs e)
        {
            get_tipocambio(fechdoc.Text);
        }
        private void moduloiddes_SelectedIndexChanged(object sender, EventArgs e)
        {
            perianio = "";
            perimes = "";
            almacaccionid = "";
            fechadocedit = false;
            tipodocautomatico = false;
            tipodocmanejaserie = false;
            statusDoc = true;

            localdes.SelectedIndexChanged -= new EventHandler(localdes_SelectedIndexChanged);

            if (btn_nuevo.Enabled == false)
            {
                //if (moduloiddes.SelectedIndex != -1)
                //{
                    data_cbo_localdes(dominioiddes, moduloiddes.SelectedValue.ToString());
                    moduloid = moduloiddes.SelectedValue.ToString();
                    //limpiar_documento();
                    select_tipodoc();
                    get_val_fechadoc();

                    if (localdes.Items.Count > 0)
                    {
                        if (activeDoc)
                        {
                            moduloiddes.Enabled = false;
                            localdes.Enabled = true;
                            localdes.Focus();
                        }
                    }
                    localdes.SelectedIndexChanged += new EventHandler(localdes_SelectedIndexChanged);
                //}
            }
            else
            {
                moduloid = moduloiddes.SelectedValue.ToString();
                select_tipodoc();
                numdoc.Text = "";
            }        
        }


        private void localdes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (localdes.SelectedIndex != -1)
            {
                if (statusDoc)
                {
                    if (activeDoc)
                    {
                        form_bloqueado(true);
                        moduloiddes.Enabled = false;
                        localdes.Enabled = false;
                        detraccionid.Enabled = false;

                        btn_cancelar.Enabled = true;
                        btn_grabar.Enabled = true;
                        btn_GenerarOrden.Enabled = true;
                        btn_detanadir.Enabled = true;
                        btn_deteliminar.Enabled = true;

                        numdoc.Enabled = VariablesPublicas.editnumdoc;
                        fechdoc.Enabled = VariablesPublicas.editnumdoc;

                        //ctacte.Focus();
                        fechdoc.Focus();

                    }
                }
            }
        }
        private void ctacte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaClientes("");
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
                AyudaClientes("");
            }
        }
        private void nmruc_LostFocus(object sender, System.EventArgs e)
        {
            ValidaCliente();
        }
        private void fechentrega_ValueChanged(object sender, EventArgs e)
        {
            //fechentrega.Format = DateTimePickerFormat.Short;
            //moneda.Focus();
        }
        private void fechpago_ValueChanged(object sender, EventArgs e)
        {
            //fechpago.Format = DateTimePickerFormat.Short;
            //ctacte.Focus();
        }
        private void fechref_ValueChanged(object sender, EventArgs e)
        {
            fechref.Format = DateTimePickerFormat.Short;
        }
        private void serref_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(numdoc, e);
        }
        private void numref_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(numdoc, e);
        }
        private void serped_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(numdoc, e);
        }
        private void numped_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(numdoc, e);
        }
        private void compradorid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Ayudacomprador("");
            }
        }
        private void compradorid_LostFocus(object sender, System.EventArgs e)
        {
            ValidaComprador(compradorid.Text, false);
        }
        private void afecdetraccion_CheckedChanged(object sender, EventArgs e)
        {
            detraccionid.Enabled = false;
            if (afecdetraccion.Checked)
            {
                if (activeDoc)
                {
                    detraccionid.Enabled = true;
                }
            }
            else
            {
                detraccionid.SelectedIndex = -1;
                pdetraccion.Text = "0";
            }
        }

        private void detraccionid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (detraccionid.SelectedIndex != -1)
            {
                if (afecdetraccion.Checked)
                {
                    get_pdetraccion(detraccionid.SelectedValue.ToString());
                }
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
            {
                activeDoc = true;
                nuevo();
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            //if (XNIVEL == "0" || XNIVEL == "1")
            if (XNIVEL == "0")
            {
                ssModo = "EDIT";
                activeDoc = true;
                form_bloqueado(true);
                moduloiddes.Enabled = false;
                localdes.Enabled = false;
                if (afecdetraccion.Checked == false)
                {
                    detraccionid.Enabled = false;
                }
                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
                btn_GenerarOrden.Enabled = true;
                btn_detanadir.Enabled = true;
                btn_deteliminar.Enabled = true;
                nmruc.Focus();
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            form_accion_cancelEdicion(1);
        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {
            bool sw_prosigue = false;
            //if (Tabladetalleocompra.Rows.Count != 0)
            //{
            if (ssModo == "NEW")
            {
                if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
                    
                    sw_prosigue = (MessageBox.Show("¿Desea Guardar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                    if (sw_prosigue)
                    {
                        this.griddetalleocompra.CurrentCell = this.griddetalleocompra.Rows[this.griddetalleocompra.RowCount - 1].Cells["item"];
                        Insert();
                    }
                
            }
            else
            {
                //if (XNIVEL == "0" || XNIVEL == "1")
                if (XNIVEL == "0" || XNIVEL == "1")
                {
                    sw_prosigue = (MessageBox.Show("¿Desea Modificar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                    if (sw_prosigue)
                    {
                        this.griddetalleocompra.CurrentCell = this.griddetalleocompra.Rows[this.griddetalleocompra.RowCount - 1].Cells["item"];
                        Update();
                    }
                }
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0")
            {
                bool sw_prosigue = false;
                sw_prosigue = (MessageBox.Show("¿Desea Eliminar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                if (sw_prosigue)
                {
                    Delete();
                }
            }
        }


        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Tabladetalleocompra.Rows.Count > 0)
                {
                    Reportes.Frm_reportes miForma = new Reportes.Frm_reportes();

                    miForma.dominioid = dominio.Trim();
                    miForma.moduloid = modulo.Trim();
                    miForma.local = local.Trim();
                    miForma.Text = "Reporte Orden de Compra";
                    miForma.formulario = Name.Trim();
                    miForma.tipdoc = tipodoc.Trim().ToString();
                    miForma.serdoc = serdoc.Text.ToString();
                    miForma.numdoc = numdoc2.Text.ToString() +""+ numdoc.Text.Trim().PadLeft(6, '0');
                    miForma.localdes = localdes.SelectedValue.ToString();
                    // Pasamos el Local Direc
                    sys_localBL BL = new sys_localBL();
                    tb_sys_local BE = new tb_sys_local();
                    BE.dominioid = "60";
                    BE.moduloid = moduloiddes.SelectedValue.ToString();
                    BE.local = localdes.SelectedValue.ToString();
                    DataTable dt = new DataTable();
                    dt = BL.GetAll(EmpresaID, BE).Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        miForma.localdestino = dt.Rows[0]["localdirec"].ToString();
                        //VariablesPublicas.localdirec = dt.Rows[0]["localdirec"].ToString();                         
                    }    
                    miForma.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        // Generamos la OrdendeCompradet_Aux

        private void Genera_OrdencompraDetaux()                         
        {
            try
            {

                #region

                // Variables de Cabecera
                tb_cm_ordendecompraBL BL2 = new tb_cm_ordendecompraBL();
                tb_cm_ordendecompra BE2 = new tb_cm_ordendecompra();

                // Variables para Detalle
                tb_cm_ordendecompra.Item Detalle = new tb_cm_ordendecompra.Item();
                List<tb_cm_ordendecompra.Item> ListaItems = new List<tb_cm_ordendecompra.Item>();

                String _moduloid = "0100", _local = "001";
                                     
                // ***********************************************************************************

                BE2.moduloid = _moduloid;
                BE2.local = _local;
                BE2.tipodoc = tipodoc.Trim();
                BE2.serdoc = serdoc.Text.Trim();
                BE2.numdoc = numdoc2.Text.ToString() + "" + numdoc.Text.ToString();

                Detalle.moduloiddes = moduloiddes.SelectedValue.ToString().Trim();
                Detalle.localdes = localdes.SelectedValue.ToString().Trim();
                Detalle.fechdoc = Convert.ToDateTime(fechdoc.Text);
                Detalle.fechentrega = Convert.ToDateTime(fechentrega.Text);
                Detalle.moneda = moneda.SelectedValue.ToString().Trim();
                Detalle.tcamb = Convert.ToDecimal(tcamb.Text.Trim());
                Detalle.ctacte = ctacte.Text.Trim().ToUpper();
                Detalle.ctactename = ctactename.Text.Trim().ToUpper();

                if (tipref.SelectedValue != null && serref.Text.Trim().Length > 0)
                {
                    Detalle.tipref = tipref.SelectedValue.ToString();
                    Detalle.serref = serref.Text.Trim().PadLeft(4, '0');
                    Detalle.numref = numref.Text.Trim().PadLeft(10, '0');
                    try { Detalle.fechref = Convert.ToDateTime(fechref.Text.Trim()); }
                    catch { Detalle.fechref = Convert.ToDateTime("01/01/1900"); }
                }

                //referencia pedido
                if (serped.Text.Trim().Length > 0 && numped.Text.Trim().Length > 0)
                {
                    Detalle.tipped = "PP";
                    Detalle.serped = serped.Text.Trim().PadLeft(4, '0');
                    Detalle.numped = numped.Text.Trim().PadLeft(10, '0');
                }

                //Datos de comprador
                        
                if (compradorid.Text.Trim().Length > 0) { Detalle.compradorid = compradorid.Text.Trim().ToString(); };

                //Datos calculados de detalle de movimiento obtenidos de memoria
                Detalle.itemref = ItemrefPROD;

                // Creamos el Correlativo
                //if (itemPROD <= CantidadPROD)
                //{
                    Detalle.itemsdet = itemPROD.ToString().PadLeft(5, '0');
                    itemPROD++;
                //}

                Detalle.productid = CodigoPROD.ToString();
                Detalle.productname = NombrePROD.ToString();

                // Primero Verificamos la fila2 el Producto id 
                Decimal fil_n = EquivPROD;
                tb_cm_equivalenciaBL equivalenciaBL = new tb_cm_equivalenciaBL();

                Detalle.Cantidadcta_c = 0;

                if (fil_n != null)
                    Detalle.equivid = (int)fil_n;
                else
                    Detalle.equivid = 0;

                Detalle.fechentrega = FechentregaPROD;
                Detalle.aniosemana = AniosemanaPROD;
                Detalle.precioanterior = PrecioanteriorPROD;

                Detalle.precunit = ImportfacPROD / CantidadPROD;
                //caputaramos el precio unitario en una variable

                Decimal precunit = Detalle.precunit;
                Decimal importfac = Detalle.precunit * 1;

                if (moneda.SelectedValue.ToString() == "$")
                {
                    Decimal tcambio = Convert.ToDecimal(tcamb.Text);
                    //Hallamos el valor 
                    Detalle.valor = precunit * tcambio;
                    Detalle.importe = importfac * tcambio;
                }
                else if (moneda.SelectedValue.ToString() == "S")
                {
                    Detalle.valor = precunit;
                    Detalle.importe = importfac;
                }


                Detalle.cantidad = CantidadPROD;
                Detalle.cantidad_c = CantidadPROD;


                Detalle.importfac = importfac;
                Detalle.totimpto = TotimptoPROD;
                Detalle.precunit_c = (Detalle.importfac / Detalle.cantidad_c);

                // Accion del alamacen dependiendo del tipo de documento

                Detalle.almacaccionid = AlmaccionidPROD;

                // Datos si es Incluido IGV
                Detalle.incprec = incprec.Trim();
                Detalle.pigv = pigv;
                // Glosa - Observacion
                Detalle.glosa = glosa.Text.Trim().ToUpper().ToString();
                // Datos de Usuario
                Detalle.perianio = perianio;
                Detalle.perimes = perimes;
                Detalle.status = "0";
                Detalle.usuar = VariablesPublicas.Usuar;

                if (CantidadPROD > 0)
                {
                    ListaItems.Add(Detalle);
                }
                else
                {
                    MessageBox.Show("Documento DETALLE EN FORMATO INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ListaItems.Count == 0)
                {
                    MessageBox.Show("Documento SIN DETALLE Y/O DETALLE INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                BE2.ListaItems = ListaItems;

                if (BL2.Insert_det(EmpresaID, BE2))
                {
                   
                }
              
                // ***************************************************************************************************************************
                
                #endregion               
                   
            //string mensaje = string.Format("Evento CellContentClick.\n\nSe ha seccionado, \nCodigo: '{0}', \nProducto: '{1}', \nCantidad: '{2}'",
            //_productid,
            //_productname,
            //_cantidad);
            //MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);                        

            }
            catch (Exception ex)
            {
                throw ex;
            }    

        }


        private void Genera_OrdencompraDetaux2()
        {
            try
            {

                #region

                // Variables de Cabecera
                tb_cm_ordendecompraBL BL2 = new tb_cm_ordendecompraBL();
                tb_cm_ordendecompra BE2 = new tb_cm_ordendecompra();

                // Variables para Detalle
                tb_cm_ordendecompra.Item Detalle = new tb_cm_ordendecompra.Item();
                List<tb_cm_ordendecompra.Item> ListaItems = new List<tb_cm_ordendecompra.Item>();

                String _moduloid = "0100", _local = "001";

                // ***********************************************************************************

                BE2.moduloid = _moduloid;
                BE2.local = _local;
                BE2.tipodoc = tipodoc.Trim();
                BE2.serdoc = serdoc.Text.Trim();
                BE2.numdoc = numdoc2.Text.ToString() + "" + numdoc.Text.ToString();

                Detalle.moduloiddes = moduloiddes.SelectedValue.ToString().Trim();
                Detalle.localdes = localdes.SelectedValue.ToString().Trim();
                Detalle.fechdoc = Convert.ToDateTime(fechdoc.Text);
                Detalle.fechentrega = Convert.ToDateTime(fechentrega.Text);
                Detalle.moneda = moneda.SelectedValue.ToString().Trim();
                Detalle.tcamb = Convert.ToDecimal(tcamb.Text.Trim());
                Detalle.ctacte = ctacte.Text.Trim().ToUpper();
                Detalle.ctactename = ctactename.Text.Trim().ToUpper();

                if (tipref.SelectedValue != null && serref.Text.Trim().Length > 0)
                {
                    Detalle.tipref = tipref.SelectedValue.ToString();
                    Detalle.serref = serref.Text.Trim().PadLeft(4, '0');
                    Detalle.numref = numref.Text.Trim().PadLeft(10, '0');
                    try { Detalle.fechref = Convert.ToDateTime(fechref.Text.Trim()); }
                    catch { Detalle.fechref = Convert.ToDateTime("01/01/1900"); }
                }

                //referencia pedido
                if (serped.Text.Trim().Length > 0 && numped.Text.Trim().Length > 0)
                {
                    Detalle.tipped = "PP";
                    Detalle.serped = serped.Text.Trim().PadLeft(4, '0');
                    Detalle.numped = numped.Text.Trim().PadLeft(10, '0');
                }

                //Datos de comprador

                if (compradorid.Text.Trim().Length > 0) { Detalle.compradorid = compradorid.Text.Trim().ToString(); };

                //Datos calculados de detalle de movimiento obtenidos de memoria
                Detalle.itemref = ItemrefPROD;

                // Creamos el Correlativo
                //if (itemPROD <= CantidadPROD)
                //{
                Detalle.itemsdet = itemPROD.ToString().PadLeft(5, '0');
                itemPROD++;
                //}

                Detalle.productid = CodigoPROD.ToString();
                Detalle.productname = NombrePROD.ToString();

                // Primero Verificamos la fila2 el Producto id 
                Decimal fil_n = EquivPROD;
                tb_cm_equivalenciaBL equivalenciaBL = new tb_cm_equivalenciaBL();

                Detalle.Cantidadcta_c = 0;

                if (fil_n != null)
                    Detalle.equivid = (int)fil_n;
                else
                    Detalle.equivid = 0;

                Detalle.fechentrega = FechentregaPROD;
                Detalle.aniosemana = AniosemanaPROD;
                Detalle.precioanterior = PrecioanteriorPROD;

                Detalle.precunit = ImportfacPROD / CantidadPROD;
                //caputaramos el precio unitario en una variable

                Decimal precunit = Detalle.precunit;
                Decimal importfac = Detalle.precunit * 1;

                if (moneda.SelectedValue.ToString() == "$")
                {
                    Decimal tcambio = Convert.ToDecimal(tcamb.Text);
                    //Hallamos el valor 
                    Detalle.valor = precunit * tcambio;
                    Detalle.importe = importfac * tcambio;
                }
                else if (moneda.SelectedValue.ToString() == "S")
                {
                    Detalle.valor = precunit;
                    Detalle.importe = importfac;
                }


                Detalle.cantidad = CantPROD;
                Detalle.cantidad_c = CantPROD;


                Detalle.importfac = importfac;
                Detalle.totimpto = TotimptoPROD;
                Detalle.precunit_c = (Detalle.importfac / Detalle.cantidad_c);

                // Accion del alamacen dependiendo del tipo de documento

                Detalle.almacaccionid = AlmaccionidPROD;

                // Datos si es Incluido IGV
                Detalle.incprec = incprec.Trim();
                Detalle.pigv = pigv;
                // Glosa - Observacion
                Detalle.glosa = glosa.Text.Trim().ToUpper().ToString();
                // Datos de Usuario
                Detalle.perianio = perianio;
                Detalle.perimes = perimes;
                Detalle.status = "0";
                Detalle.usuar = VariablesPublicas.Usuar;

                if (CantidadPROD > 0)
                {
                    ListaItems.Add(Detalle);
                }
                else
                {
                    MessageBox.Show("Documento DETALLE EN FORMATO INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ListaItems.Count == 0)
                {
                    MessageBox.Show("Documento SIN DETALLE Y/O DETALLE INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                BE2.ListaItems = ListaItems;

                if (BL2.Insert_det(EmpresaID, BE2))
                {

                }

                // ***************************************************************************************************************************

                #endregion

                //string mensaje = string.Format("Evento CellContentClick.\n\nSe ha seccionado, \nCodigo: '{0}', \nProducto: '{1}', \nCantidad: '{2}'",
                //_productid,
                //_productname,
                //_cantidad);
                //MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);                        

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //

        void _RecalculoGrid()
        {
            try
            {
                foreach (DataGridViewRow fila in griddetalleocompra.Rows)
                {
                    foreach (DataGridViewColumn col in griddetalleocompra.Columns)
                    {
                        //if (griddetalleocompra.Columns[col.Index].Name.ToUpper() == "productid".ToUpper())
                        //{
                        //    //String xrollo = "";
                        //    //xrollo = (this.griddetalleocompra.Rows[this.griddetalleocompra.CurrentRow.Index].Cells["rollo"].Value.ToString().Trim()).PadLeft(13, '0');
                        //    //if (xrollo != "0000000000000")
                        //    //{
                        //    //    ValidaTabladetallemovmov(xrollo);
                        //    //}

                        //    string valproductid = this.griddetalleocompra.Rows[this.griddetalleocompra.CurrentRow.Index].Cells["productid"].Value.ToString().Trim();
                        //    ValidaTabladetallemovcopia(valproductid);
                        //}

                        if (griddetalleocompra.Columns[col.Index].Name.ToUpper() == "Cantidad".ToUpper() || griddetalleocompra.Columns[col.Index].Name.ToUpper() == "Precunit".ToUpper())
                        {
                            //*** Declarando Variables
                            Decimal precunit = 0, tipcamb = 0, equiv = 0; //variables de movimiento
                            Decimal imporfac = 0, desct1 = 0, totimpx = 0, import = 0, valor = 0; //variables si es incluido igv
                            Decimal cantidad = 0, precio_c = 0, xstock = 0, xcostopromed = 0;
                            Decimal _cantidad = 0; //variable dolares
                            cantidad = Convert.ToDecimal(griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["cantidad"].Value);
                            precio_c = Convert.ToDecimal(griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["precunit"].Value);
                            xstock = Convert.ToDecimal(griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["stock"].Value);
                            xcostopromed = Convert.ToDecimal(griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["costopromed"].Value);

                            equiv = Convert.ToDecimal(griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["equiv_id"].Value);

                            tb_cm_equivalenciaBL equivalenciaBL = new tb_cm_equivalenciaBL();

                            DataTable ds = new DataTable();
                            ds = equivalenciaBL.GetOne_Shear(EmpresaID, equiv);
                            Decimal equivalencia = Convert.ToDecimal(ds.Rows[0]["equivalencia"]);

                            //*** ASIGNANDO DATOS A VARIABLES
                            precunit = Math.Round(Convert.ToDecimal(precio_c), 6);
                            tipcamb = Convert.ToDecimal(tcamb.Text.Trim());

                            //*** EVALUAR SI TIPO DE CAMBIO ES MENOR A 0
                            if (tipcamb <= 0)
                            {
                                tipcamb = 1;
                            }

                            //*** CALCULA EN IMPORTE FACTURADO
                            imporfac = Math.Round(cantidad * Convert.ToDecimal(precunit), 6);

                            //*** EVALUAR SI LA MONEDA ES DORALES($)
                            if (moneda.SelectedValue.ToString() == "$")
                            {
                                precunit = precunit * tipcamb;
                            }

                            _cal_Igv();


                            //*** EVALUAR SI ES INCLUIDO O NO IGV        
                            desct1 = 0;
                            import = imporfac * (1 - (desct1 / 100));
                            if (incprec.Trim() == "S")
                            {
                                totimpx = Math.Round(import * (Convert.ToDecimal(pigv) / (100 + Convert.ToDecimal(pigv))), 6);
                            }
                            else
                            {
                                totimpx = Math.Round(import * (Convert.ToDecimal(pigv) / 100), 6);
                            }

                            //*** VALOR DEPENDIENDO DE LA ACCION DE ALMACEN Y EVALUA PRECIO/STOCK
                            if (almacaccionid.Trim().Substring(0, 1) == "2")
                            {
                                if (cantidad <= xstock)
                                {
                                    valor = Math.Round(Convert.ToDecimal(xcostopromed), 6);
                                }
                                else
                                {
                                    MessageBox.Show("Cantidad fuera de rango!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            else if (almacaccionid.Trim().Substring(0, 1) == "1")
                            {
                                valor = precunit;
                            }

                            griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["valor"].Value = valor;
                            griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["importe"].Value = Math.Round(cantidad * valor, 6);
                            griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["dtotimpto"].Value = totimpx;
                            griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["importfac"].Value = Math.Round(imporfac, 2);
                            //griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["cantidad_c"].Value = Math.Round(equivalencia * imporfac);
                            griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["cantidad_c"].Value = (equivalencia * cantidad);
                            decimal prec = (imporfac / (equivalencia * cantidad));
                            griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["precunit_c"].Value = (imporfac / (equivalencia * cantidad));
                        }
                    }
                }
                calcular_totales();
            }
            catch (Exception ex)
            {
                String error = "";
                error = ex.GetType().ToString();
                if (error == "System.Data.ConstraintException")
                {
                    MessageBox.Show("Producto ya existe!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }               
        }

        private void ValidaTabladetallemovmov(String valproductid)
        {
            try
            {
                String xproductid = "";
                //xprecio == valor
                Decimal xprecio = 0, xprecunit_c = 0, xcantidad_c = 0, xcostoprom = 0, tipcamb = 0,
                    desct1 = 0, imporfac = 0, import = 0, totimpx = 0;

                xproductid = valproductid.Trim();            

                griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["productname"].Value = "";
                txt_stock.Text = "0";
                txt_valor.Text = "0";
                //griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["cantidad"].Value = "0";
                griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["precunit_c"].Value = "0";
                griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["importfac"].Value = "0";

                if (xproductid.Trim().Length == 13)
                {
                    tb_60local_stockBL BL = new tb_60local_stockBL();
                    tb_60local_stock BE = new tb_60local_stock();

                    // Modificamos el  DataTable por DataSet 

                    DataSet ds = new DataSet();
                    BE.moduloid = moduloiddes.SelectedValue.ToString().Trim();
                    BE.productid = xproductid;

                    ds = BL.GetAll(EmpresaID, BE);

                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow fila in ds.Tables[0].Rows)
                            {
                                griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["productid"].Value = fila["productid"].ToString().Trim();
                                griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["productname"].Value = fila["productname"].ToString().Trim();
                                

                                Decimal lsStock = 0, dtCantidad = 0, mvCantidad = 0, dtstock = 0, equiv = 0;

                                lsStock = Convert.ToDecimal(fila["stock"].ToString().Trim().PadLeft(1, '0'));
                                dtCantidad = Convert.ToDecimal(griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["cantidad_c"].Value);
                                mvCantidad = Convert.ToDecimal(griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["cantidad_old"].Value);
                               

                                if (almacaccionid.Substring(0, 1) == "1")
                                {
                                    dtstock = lsStock + dtCantidad - mvCantidad;
                                }
                                else if (almacaccionid.Substring(0, 1) == "2")
                                {
                                    dtstock = lsStock - dtCantidad + mvCantidad;
                                }

                                griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["stock_old"].Value = lsStock;
                                griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["stock"].Value = dtstock;

                                //griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["stock"].Value = Convert.ToDecimal(DT.Rows[0]["stock"].ToString().Trim().PadLeft(1, '0'));

                                griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["dalmacaccionid"].Value = almacaccionid.ToString().Trim();
                                //txt_stock.Text = Math.Round(Convert.ToDecimal(DT.Rows[0]["stock"].ToString().Trim().PadLeft(1, '0')), 2).ToString();
                                txt_stock.Text = Convert.ToString(dtstock);

                                if (almacaccionid.Substring(0, 1) == "2")
                                {
                                    xprecventa = Convert.ToDecimal(Convert.ToDecimal(fila["precventa"]).ToString("###,###,##0.000000"));
                                    xprecio = Convert.ToDecimal(Convert.ToDecimal(fila["costoultimo"]).ToString("###,###,##0.000000"));
                                    txt_valor.Text = Convert.ToDecimal(fila["costopromed"].ToString().Trim().PadLeft(1, '0')).ToString("###,###,##0.0000");
                                    xcostoprom = Convert.ToDecimal(fila["costopromed"].ToString().Trim().PadLeft(1, '0'));
                                }
                                else if (almacaccionid.Substring(0, 1) == "1")
                                {
                                    xcostoultimo = Convert.ToDecimal(Convert.ToDecimal(fila["costoultimo"]).ToString("###,###,##0.000000"));
                                    xprecio = Convert.ToDecimal(Convert.ToDecimal(fila["costoultimo"]).ToString("###,###,##0.000000"));
                                    txt_valor.Text = Convert.ToDecimal(fila["costoultimo"].ToString().Trim().PadLeft(1, '0')).ToString("###,###,##0.0000");
                                }

                                griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["precventa"].Value = xprecventa;
                                griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["costoultimo"].Value = xcostoultimo;
                                griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["costopromed"].Value = xcostoprom;

                                // valida si el precio de producto es ingresado o biene de local_stock
                                //xcantidad = Convert.ToDecimal(DT.Rows[0]["stock"].ToString().Trim().PadLeft(1, '0'));
                                xcantidad_c = Convert.ToDecimal(griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["cantidad"].Value);

                                //*** CALCULA EN IMPORTE FACTURADO
                                imporfac = Math.Round(xcantidad_c * Convert.ToDecimal(xprecio), 6);

                                //*** EVALUAR SI TIPO DE CAMBIO ES MENOR A 0
                                tipcamb = Convert.ToDecimal(tcamb.Text.Trim());
                                if (tipcamb <= 0)
                                {
                                    tipcamb = 1;
                                }

                                //muestra el precion segun moneda para producto 
                                if (moneda.SelectedValue.ToString() == "S")
                                {
                                    xprecunit_c = xprecio;

                                }
                                else
                                {
                                    xprecunit_c = xprecio / tipcamb;
                                }

                                _cal_Igv();


                                //*** EVALUAR SI ES INCLUIDO O NO IGV        
                                desct1 = 0;
                                import = imporfac * (1 - (desct1 / 100));
                                if (incprec.Trim() == "S")
                                {
                                    totimpx = Math.Round(import * (Convert.ToDecimal(pigv) / (100 + Convert.ToDecimal(pigv))), 6);
                                }
                                else
                                {
                                    totimpx = Math.Round(import * (Convert.ToDecimal(pigv) / 100), 6);
                                }

                                // Aqui Tenemos que Validar de Como se Debe de Ingresar la cantidad,precunit

                                griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["valor"].Value = xprecunit_c;
                                griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["importe"].Value = Math.Round(xcantidad_c * xprecunit_c, 6);
                                griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["dtotimpto"].Value = totimpx;

                                griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["cantidad_c"].Value = xcantidad_c;
                                griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["precunit_c"].Value = xprecunit_c;
                                griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["importfac"].Value = Math.Round(imporfac, 2);
                                Tabladetalleocompra.AcceptChanges();
                                griddetalleocompra.CurrentCell = griddetalleocompra.Rows[griddetalleocompra.RowCount - 1].Cells["cantidad_c"];
                            }

                        }
                        else
                        {
                            MessageBox.Show("Producto no existe en tabla LOCAL_STOCK !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }                   
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        private void ValidaTabladetallemovcopia(String vaproductid)
        {
            String xproductid = "";
            Decimal xprecio = 0, xprecunit_c = 0, xcantidad_c = 0, xcostoprom = 0, tipcamb = 0,
                desct1 = 0, imporfac = 0, import = 0, totimpx = 0;

            xproductid = vaproductid.Trim();

            griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["productname"].Value = "";
            txt_stock.Text = "0";
            txt_valor.Text = "0";
            griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["precunit_c"].Value = "0";
            griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["importfac"].Value = "0";

            if (xproductid.Trim().Length == 13)
            {
                tb_60local_stockBL BL = new tb_60local_stockBL();
                tb_60local_stock BE = new tb_60local_stock();
                DataTable DT = new DataTable();
                BE.moduloid = moduloiddes.SelectedValue.ToString().Trim(); // Orden de Compra Para Ingreso -------------------- modulo
                BE.productid = xproductid;

                DT = BL.GetAll(EmpresaID, BE).Tables[0];

                if (DT.Rows.Count > 0)
                {

                    foreach (DataGridViewRow fila in griddetalleocompra.Rows)
                    {
                        foreach (DataGridViewColumn col in griddetalleocompra.Columns)
                        {
                            if (fila.Index >= 0)
                            {
                                if (Convert.ToString(griddetalleocompra.Rows[fila.Index].Cells["productid"].Value) == vaproductid.ToString())
                                {
                                    griddetalleocompra.Rows[fila.Index].Cells["productid"].Value = DT.Rows[0]["productid"].ToString().Trim();
                                    griddetalleocompra.Rows[fila.Index].Cells["productname"].Value = DT.Rows[0]["productname"].ToString().Trim();
                                    //griddetalleocompra.Rows[fila.Index].Cells["rollo"].Value = "";

                                    Decimal lsStock = 0, dtCantidad = 0, mvCantidad = 0, dtstock = 0;

                                    lsStock = Convert.ToDecimal(DT.Rows[0]["stock"].ToString().Trim().PadLeft(1, '0'));
                                    dtCantidad = Convert.ToDecimal(griddetalleocompra.Rows[fila.Index].Cells["cantidad_c"].Value);
                                    mvCantidad = Convert.ToDecimal(griddetalleocompra.Rows[fila.Index].Cells["cantidad_old"].Value);

                                    if (almacaccionid.Substring(0, 1) == "1")
                                    {
                                        dtstock = lsStock + dtCantidad - mvCantidad;
                                    }
                                    else if (almacaccionid.Substring(0, 1) == "2")
                                    {
                                        dtstock = lsStock - dtCantidad + mvCantidad;
                                    }

                                    griddetalleocompra.Rows[fila.Index].Cells["stock_old"].Value = lsStock;
                                    griddetalleocompra.Rows[fila.Index].Cells["stock"].Value = dtstock;


                                    griddetalleocompra.Rows[fila.Index].Cells["dalmacaccionid"].Value = almacaccionid.ToString().Trim();
                                    txt_stock.Text = Convert.ToString(dtstock);

                                    if (almacaccionid.Substring(0, 1) == "2")
                                    {
                                        xprecventa = Convert.ToDecimal(Convert.ToDecimal(DT.Rows[0]["precventa"]).ToString("###,###,##0.000000"));
                                        xprecio = Convert.ToDecimal(Convert.ToDecimal(DT.Rows[0]["costoultimo"]).ToString("###,###,##0.000000"));
                                        txt_valor.Text = Convert.ToDecimal(DT.Rows[0]["costopromed"].ToString().Trim().PadLeft(1, '0')).ToString("###,###,##0.0000");
                                        xcostoprom = Convert.ToDecimal(DT.Rows[0]["costopromed"].ToString().Trim().PadLeft(1, '0'));
                                    }
                                    else if (almacaccionid.Substring(0, 1) == "1")
                                    {
                                        xcostoultimo = Convert.ToDecimal(Convert.ToDecimal(DT.Rows[0]["costoultimo"]).ToString("###,###,##0.000000"));
                                        xprecio = Convert.ToDecimal(Convert.ToDecimal(DT.Rows[0]["costoultimo"]).ToString("###,###,##0.000000"));
                                        txt_valor.Text = Convert.ToDecimal(DT.Rows[0]["costoultimo"].ToString().Trim().PadLeft(1, '0')).ToString("###,###,##0.0000");
                                    }

                                    griddetalleocompra.Rows[fila.Index].Cells["precventa"].Value = xprecventa;
                                    griddetalleocompra.Rows[fila.Index].Cells["costoultimo"].Value = xcostoultimo;
                                    griddetalleocompra.Rows[fila.Index].Cells["costopromed"].Value = xcostoprom;

                                    xcantidad_c = Convert.ToDecimal(griddetalleocompra.Rows[fila.Index].Cells["cantidad_c"].Value);

                                    //*** CALCULA EN IMPORTE FACTURADO
                                    imporfac = Math.Round(xcantidad_c * Convert.ToDecimal(xprecio), 6);

                                    //*** EVALUAR SI TIPO DE CAMBIO ES MENOR A 0
                                    tipcamb = Convert.ToDecimal(tcamb.Text.Trim());
                                    if (tipcamb <= 0)
                                    {
                                        tipcamb = 1;
                                    }

                                    //muestra el precion segun moneda para producto 
                                    if (moneda.SelectedValue.ToString() == "S")
                                    {
                                        xprecunit_c = xprecio;

                                    }
                                    else
                                    {
                                        xprecunit_c = xprecio / tipcamb;
                                    }

                                    _cal_Igv();


                                    //*** EVALUAR SI ES INCLUIDO O NO IGV        
                                    desct1 = 0;
                                    import = imporfac * (1 - (desct1 / 100));
                                    if (incprec.Trim() == "S")
                                    {
                                        totimpx = Math.Round(import * (Convert.ToDecimal(pigv) / (100 + Convert.ToDecimal(pigv))), 6);
                                    }
                                    else
                                    {
                                        totimpx = Math.Round(import * (Convert.ToDecimal(pigv) / 100), 6);
                                    }

                                    griddetalleocompra.Rows[fila.Index].Cells["valor"].Value = xprecunit_c;
                                    griddetalleocompra.Rows[fila.Index].Cells["importe"].Value = Math.Round(xcantidad_c * xprecunit_c, 6);
                                    griddetalleocompra.Rows[fila.Index].Cells["dtotimpto"].Value = totimpx;

                                    griddetalleocompra.Rows[fila.Index].Cells["cantidad_c"].Value = xcantidad_c;
                                    griddetalleocompra.Rows[fila.Index].Cells["precunit_c"].Value = xprecunit_c;
                                    griddetalleocompra.Rows[fila.Index].Cells["importfac"].Value = Math.Round(imporfac, 2);
                                    Tabladetalleocompra.AcceptChanges();
                                    griddetalleocompra.CurrentCell = griddetalleocompra.Rows[griddetalleocompra.RowCount - 1].Cells["cantidad_c"];
                                }
                            }
                            break;
                        }
                        //break;
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

        private void btn_primero_Click(object sender, EventArgs e)
        {
            activeDoc = false;
            form_cargar_datos(Genericas.primero);
        }
        private void btn_anterior_Click(object sender, EventArgs e)
        {
            activeDoc = false;
            form_cargar_datos(Genericas.anterior);
        }
        private void btn_siguiente_Click(object sender, EventArgs e)
        {
            activeDoc = false;
            form_cargar_datos(Genericas.siguiente);
        }
        private void btn_ultimo_Click(object sender, EventArgs e)
        {
            activeDoc = false;
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

                if (griddetalleocompra.Enabled)
                {
                    if (this.griddetalleocompra.Rows.Count > 0)
                    {
                        int nFilaAnt = griddetalleocompra.RowCount - 1;

                        if (griddetalleocompra.Rows[griddetalleocompra.RowCount - 1].Cells["productid"].Value.ToString().Trim().Length > 0)
                        {
                            //this.Tabladetalleocompra.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetalleocompra));
                            //Tabladetalleocompra.Rows[this.Tabladetalleocompra.Rows.Count - 1]["items"] = VariablesPublicas.CalcMaxField(this.Tabladetalleocompra, "items", 5);
                           
                            this.griddetalleocompra.CurrentCell = this.griddetalleocompra.Rows[this.griddetalleocompra.RowCount  -1].Cells["productid"];
                            this.griddetalleocompra.BeginEdit(true);
                     

                            String xProductid = griddetalleocompra.Rows[griddetalleocompra.RowCount - 1].Cells["productid"].Value.ToString();
                            String xProductname = griddetalleocompra.Rows[griddetalleocompra.RowCount - 1].Cells["productname"].Value.ToString();
                            Int32 xequiv = Convert.ToInt32(griddetalleocompra.Rows[griddetalleocompra.RowCount - 1].Cells["equiv_id"].Value);

                            this.Tabladetalleocompra.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetalleocompra));

                            Tabladetalleocompra.Rows[this.Tabladetalleocompra.Rows.Count - 1]["items"] = VariablesPublicas.CalcMaxField(this.Tabladetalleocompra, "items", 5);

                            //this.griddetalleocompra.Rows[nFilaAnt + 1].Cells["productid"].Value = xProductid;
                            //this.griddetalleocompra.Rows[nFilaAnt + 1].Cells["productname"].Value = xProductname;
                            //this.griddetalleocompra.Rows[nFilaAnt + 1].Cells["equiv_id"].Value = xequiv;
                            this.griddetalleocompra.CurrentCell = this.griddetalleocompra.Rows[griddetalleocompra.RowCount - 1].Cells["productid"];
                            this.griddetalleocompra.BeginEdit(true);                            
                        }
                        else
                        {
                            MessageBox.Show("Ingrese rollo y/o producto !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        this.Tabladetalleocompra.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetalleocompra));
                        Tabladetalleocompra.Rows[this.Tabladetalleocompra.Rows.Count - 1]["items"] = VariablesPublicas.CalcMaxField(this.Tabladetalleocompra, "items", 5);
                        this.griddetalleocompra.CurrentCell = this.griddetalleocompra.Rows[this.griddetalleocompra.RowCount - 1].Cells["productid"];
                        this.griddetalleocompra.BeginEdit(true);
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
            int lc_cont = 0;
            String xcoditem = "";
            if ((griddetalleocompra.CurrentRow != null))
            {
                xcoditem = this.griddetalleocompra.Rows[this.griddetalleocompra.CurrentCell.RowIndex].Cells["item"].Value.ToString();
                for (lc_cont = 0; lc_cont <= this.Tabladetalleocompra.Rows.Count - 1; lc_cont++)
                {
                    // ubique el item a borrar
                    if (this.Tabladetalleocompra.Rows[lc_cont]["items"].ToString() == xcoditem)
                    {
                        this.Tabladetalleocompra.Rows[lc_cont].Delete();
                        this.Tabladetalleocompra.AcceptChanges();
                        break;
                    }
                }
                // regenerar el nro de item
                for (lc_cont = 0; lc_cont <= this.Tabladetalleocompra.Rows.Count - 1; lc_cont++)
                {
                    Tabladetalleocompra.Rows[lc_cont]["items"] = VariablesPublicas.PADL(Convert.ToString(lc_cont + 1), 5, "0");
                }
                calcular_totales();
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quieres cerrar el formulario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               Frm_reporte_ordcompra frm  =new Frm_reporte_ordcompra ();
               frm.Show();
                Close();
            }
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
            Seguridadlog.FrmSeguridad oform = new Seguridadlog.FrmSeguridad();
            String xclave = VariablesPublicas.EmpresaID + "-" + modulo + "-" + tipodoc.Trim() + "-" + serdoc.Text.Trim() + "-" + numdoc.Text.Trim();
            oform._Nombre = Name;
            oform._ClaveForm = xclave;
            oform.Owner = this;
            oform.ShowDialog();
        }

        #region $$$ Pestaña Tabladetalleocompra movimiento

        private void data_Tabladetalleocompra()
        {
            try
            {
                Decimal xxprecventa = 0, xxcostoultimo = 0, xxstock = 0, xxcostopromed = 0;
                griddetalleocompra.AutoGenerateColumns = false;
                tb_cm_ordendecompradetBL BL = new tb_cm_ordendecompradetBL();
                tb_cm_ordendecompradet BE = new tb_cm_ordendecompradet();
                DataTable dt = new DataTable();

                BE.moduloid = modulo;
                BE.local = local;
                BE.tipodoc = tipodoc.Trim();
                BE.serdoc = serdoc.Text.Trim().PadLeft(4, '0');

                BE.numdoc = numdoc2.Text.ToString() +""+ numdoc.Text.PadLeft(6,'0').ToString();

                dt = BL.GetAll_datosdetalle(EmpresaID, BE).Tables[0];

                //datos incluido IGV
                if (dt.Rows.Count > 0)
                {
                    incprec = dt.Rows[0]["incprec"].ToString().Trim();
                    //tipoperef = dt.Rows[0]["tipoperef"].ToString();
                }

                if (Tabladetalleocompra != null)
                {
                    Tabladetalleocompra.Clear();
                }

                foreach (DataRow fila in dt.Rows)
                {
                    tb_60local_stockBL BL2 = new tb_60local_stockBL();
                    tb_60local_stock BE2 = new tb_60local_stock();
                    DataTable dt2 = new DataTable();

                    BE2.moduloid = fila["moduloiddes"].ToString();
                    BE2.productid = fila["productid"].ToString();
                    dt2 = BL2.GetAll(EmpresaID, BE2).Tables[0];

                    if (dt2.Rows.Count > 0)
                    {
                        //xxstock = Convert.ToDecimal(dt2.Rows[0]["stock"]);

                        if (almacaccionid.Trim() == "20" || almacaccionid.Trim() == "21")
                        {
                            lbl_valor.Text = "Cost.Prom";
                            xxprecventa = Convert.ToDecimal(dt.Rows[0]["precventa"]);
                            xxcostopromed = Convert.ToDecimal(dt2.Rows[0]["costopromed"]);

                        }
                        else if (almacaccionid.Trim() == "10" || almacaccionid.Trim() == "11")
                        {
                            lbl_valor.Text = "Cost.Ultm";
                            xxcostoultimo = Convert.ToDecimal(dt2.Rows[0]["costoultimo"]);
                        }
                        xxstock = Convert.ToDecimal(dt2.Rows[0]["stock"]);
                    }
                                      
                    row = Tabladetalleocompra.NewRow();

                    row["itemref"] = fila["itemref"].ToString();
                    row["items"] = fila["items"].ToString();
                    row["productid"] = fila["productid"].ToString().Trim();
                    row["productname"] = fila["productname"].ToString().Trim();

                    if (Convert.ToInt32(fila["equiv_id"]) != 0)
                        row["equiv_id"] = Convert.ToInt32(fila["equiv_id"]);
                    else
                        row["equiv_id"] = 0;
                                
                    row["stock"] = xxstock;
                    if (fila["fechentrega"].ToString().Trim().Substring(0, 10) != "01/01/1900")
                        row["fechentrega"] = fila["fechentrega"].ToString().Trim().Substring(0, 10);

                    row["aniosemana"] = fila["aniosemana"].ToString();
                    row["precioanterior"] = Math.Round(Convert.ToDecimal(fila["precioanterior"]), 4);
                    row["precventa"] = xxprecventa;
                    row["costoultimo"] = xxcostoultimo;
                    row["costopromed"] = xxcostopromed;

                    //row["cantidad_c"] = Math.Round(Convert.ToDecimal(fila["cantidad_c"]), 4);
                    row["cantidad"] = Math.Round(Convert.ToDecimal(fila["cantidad"]), 4);
                    //row["precunit_c"] = Math.Round(Convert.ToDecimal(Convert.ToDecimal(fila["precunit_c"]).ToString("###,###,##0.000000")), 6);
                    row["precunit"] = Math.Round(Convert.ToDecimal(Convert.ToDecimal(fila["precunit"]).ToString("###,###,##0.000000")), 6);
                    row["importfac"] = Math.Round(Convert.ToDecimal(fila["importfac"]), 2);
                    row["valor"] = Math.Round(Convert.ToDecimal(fila["valor"]), 6);
                    row["importe"] = Math.Round(Convert.ToDecimal(fila["importe"]), 6);
                    row["totimpto"] = Math.Round(Math.Round(Convert.ToDecimal(fila["importe"]), 6) * (Convert.ToDecimal(18) / 100), 6);
                    row["almacaccionid"] = almacaccionid.Trim();

                   // Decimal a= Math.Round( Equivalencias.getDecimal (fila["cantidadcta_c"]), 6);
                  
                    
                    row["cantidadcta_c"] = Math.Round(Convert.ToDecimal(fila["cantidadcta_c"]), 6);
                    Tabladetalleocompra.Rows.Add(row);
                }

                griddetalleocompra.DataSource = Tabladetalleocompra;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidaTabladetalleocompra(String valproductid)
        {
            try
            {
                griddetalleocompra.Focus();
                String xproductid = "";
                //xprecio == valor
                Decimal xprecio = 0, xprecunit_c = 0, xcantidad_c = 0, xcostoprom = 0, tipcamb = 0,
                desct1 = 0, imporfac = 0, import = 0, totimpx = 0;

                //DataRow[] rowrollo = Tabladetalleocompra.Select("productid='" + valproductid + "'");
                //if (rowrollo.Length > 0)
                //{
                //    MessageBox.Show("Producto ya existe !!!!!!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["productname"].Value = "";
                txt_stock.Text = "0";
                txt_valor.Text = "0";
                griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["cantidad_c"].Value = "0";
                griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["precunit_c"].Value = "0";
                griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["importfac"].Value = "0";

                tb_60local_stockBL BL = new tb_60local_stockBL();
                tb_60local_stock BE = new tb_60local_stock();
                DataTable DT = new DataTable();
                BE.moduloid = moduloiddes.SelectedValue.ToString().Trim();
                BE.productid = valproductid.Trim();
                DT = BL.GetAll(EmpresaID, BE).Tables[0];

                if (DT.Rows.Count > 0)
                {
                    xproductid = DT.Rows[0]["productid"].ToString();
                    if (xproductid.Trim().Length == 13)
                    {
                        griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["productid"].Value = DT.Rows[0]["productid"].ToString().Trim();
                        griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["productname"].Value = DT.Rows[0]["productname"].ToString().Trim();
                        griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["stock"].Value = Math.Round(Convert.ToDecimal(DT.Rows[0]["stock"]), 2);
                        griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["dalmacaccionid"].Value = almacaccionid.ToString().Trim();
                        txt_stock.Text = Math.Round(Convert.ToDecimal(DT.Rows[0]["stock"]), 2).ToString();
                        
                         /*
                         *El Costo ultimo biene de la tabla ---------tb_av_local_stock--------- y se va a mostrar como precunit_c
                         *Presionando el F1 MUESTRO estos datos stock,costoultimo                         
                         */

                        if (almacaccionid.Substring(0, 1) == "2")
                        {
                            xprecventa = Convert.ToDecimal(Convert.ToDecimal(DT.Rows[0]["precventa"]).ToString("###,###,##0.000000"));
                            xprecio = Convert.ToDecimal(Convert.ToDecimal(DT.Rows[0]["costoultimo"]).ToString("###,###,##0.000000"));
                            txt_valor.Text = Convert.ToDecimal(DT.Rows[0]["costopromed"].ToString().Trim().PadLeft(1, '0')).ToString("###,###,##0.0000");
                            xcostoprom = Convert.ToDecimal(DT.Rows[0]["costopromed"].ToString().Trim().PadLeft(1, '0'));
                        }
                        else if (almacaccionid.Substring(0, 1) == "1")
                        {
                            xcostoultimo = Convert.ToDecimal(Convert.ToDecimal(DT.Rows[0]["costoultimo"]).ToString("###,###,##0.000000"));
                            xprecio = Convert.ToDecimal(Convert.ToDecimal(DT.Rows[0]["costoultimo"]).ToString("###,###,##0.000000"));
                            txt_valor.Text = Convert.ToDecimal(DT.Rows[0]["costoultimo"].ToString().Trim().PadLeft(1, '0')).ToString("###,###,##0.0000");
                        }

                        griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["precventa"].Value = xprecventa;
                        griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["costoultimo"].Value = xcostoultimo;
                        griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["costopromed"].Value = xcostoprom;

                        // valida si el precio de rollo es ingresado o biene de local_stock
                        xcantidad_c = Convert.ToDecimal(DT.Rows[0]["stock"].ToString().Trim().PadLeft(1, '0'));


                        //*** EVALUAR SI TIPO DE CAMBIO ES MENOR A 0
                        tipcamb = Convert.ToDecimal(tcamb.Text.Trim());
                        if (tipcamb <= 0)
                        {
                            tipcamb = 1;
                        }

                        //muestra el precion segun moneda para rollo 
                        if (moneda.SelectedValue.ToString() == "S")
                        {
                            xprecunit_c = xprecio;
                        }
                        else
                        {
                            xprecunit_c = xprecio / tipcamb;
                        }
                        
                        _cal_Igv();


                        //*** CALCULA EN IMPORTE FACTURADO
                        imporfac = Math.Round(xcantidad_c * Convert.ToDecimal(xprecunit_c), 6);
                        //*** EVALUAR SI ES INCLUIDO O NO IGV        
                        desct1 = 0;
                        import = imporfac * (1 - (desct1 / 100));
                        if (incprec.Trim() == "S")
                        {
                            totimpx = Math.Round(import * (Convert.ToDecimal(pigv) / (100 + Convert.ToDecimal(pigv))), 6);
                        }
                        else
                        {
                            totimpx = Math.Round(import * (Convert.ToDecimal(pigv) / 100), 6);
                        }

                        griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["valor"].Value = xprecio;
                        griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["importe"].Value = Math.Round(xcantidad_c * xprecio, 6);
                        griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["dtotimpto"].Value = totimpx;

                        griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["cantidad_c"].Value = xcantidad_c;
                        griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["precunit_c"].Value = xprecunit_c;
                        griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["importfac"].Value = Math.Round(imporfac, 2);
                        Tabladetalleocompra.AcceptChanges();
                        griddetalleocompra.CurrentCell = griddetalleocompra.Rows[griddetalleocompra.RowCount - 1].Cells["cantidad"];

                    }
                    else
                    {
                        griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["productid"].Value = "";
                        //MessageBox.Show("Producto no existe en tabla LOCAL_STOCK  !!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        AyudaProducto("");
                    }
                }
                else
                {
                    griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["productid"].Value = "";
                    //MessageBox.Show("Producto no Existe en tabla PRODUCTOS!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AyudaProducto("");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCFecha_ValueChanged(object sender, EventArgs e)
        {
            griddetalleocompra.CurrentCell.Value = txtCFecha.Text;
        }
        private void griddetalleocompra_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // Ayudas
                if (e.KeyCode == Keys.F1)
                {
                    if ((griddetalleocompra.CurrentCell != null))
                    {
                        //if (griddetalleocompra.CurrentCell.ReadOnly == false)
                        //{
                            if (griddetalleocompra.Columns[griddetalleocompra.CurrentCell.ColumnIndex].Name.ToUpper() == "productid".ToUpper())
                            {
                                AyudaProducto("");
                            }

                            if (griddetalleocompra.Columns[griddetalleocompra.CurrentCell.ColumnIndex].Name.ToUpper() == "productname".ToUpper())
                            {
                                String prodid = Convert.ToString(griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["productid"].Value);
                                String prodname = Convert.ToString(griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["productname"].Value);

                                ModoEdicion(prodid,prodname);
                            }

                        //}
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void griddetalleocompra_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (griddetalleocompra.Focused && griddetalleocompra.CurrentCell.ColumnIndex == 7)
                {
                    txtCFecha.Location = griddetalleocompra.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                    txtCFecha.Visible = true;
                    if (griddetalleocompra.CurrentCell.Value != DBNull.Value)
                    {
                        if (Equivalencias.IsDate(griddetalleocompra.CurrentCell.Value))
                        {
                            txtCFecha.Value = Convert.ToDateTime(griddetalleocompra.CurrentCell.Value);
                        }
                    }
                    else
                    {
                        txtCFecha.Value = DateTime.Today;
                    }
                }
                else
                {
                    txtCFecha.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void griddetalleocompra_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (VariablesPublicas.PulsaAyudaArticulos)
                {
                    if (griddetalleocompra.Columns[griddetalleocompra.CurrentCell.ColumnIndex].Name.ToUpper() == "productid".ToUpper())
                    {
                        AyudaProducto("");
                    }
                    VariablesPublicas.PulsaAyudaArticulos = false;
                    Tabladetalleocompra.AcceptChanges();
                }

                if (griddetalleocompra.Columns[griddetalleocompra.CurrentCell.ColumnIndex].Name.ToUpper() == "dfechentrega".ToUpper())
                {
                    griddetalleocompra.CurrentCell.Value = txtCFecha.Text.Substring(0, 10);
                    griddetalleocompra.Rows[e.RowIndex].Cells[5].Value = get_aniosemana(txtCFecha.Text.Substring(0, 10));
                    txtCFecha.Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void griddetalleocompra_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (griddetalleocompra.Columns[griddetalleocompra.CurrentCell.ColumnIndex].Name.ToUpper() == "productid".ToUpper())
            {
                txtCDetalle = (TextBox)e.Control;
                txtCDetalle.MaxLength = 13;
                txtCDetalle.CharacterCasing = CharacterCasing.Upper;
                txtCDetalle.Text.Trim();
                e.Control.KeyDown += CapturarTeclaGRID;
            }

            //DataGridViewComboBoxEditingControl dgvCombo = e.Control as DataGridViewComboBoxEditingControl;

            //if (dgvCombo != null)
            //{
            //    /* se remueve el handler previo que pudiera tener asociado, a causa ediciones previas de la celda
            //     evitando asi que se ejecuten varias veces el evento
            //    */

            //    dgvCombo.SelectedIndexChanged -= new EventHandler(dvgCombo_SelectedIndexChanged);
            //    dgvCombo.SelectedIndexChanged += new EventHandler(dvgCombo_SelectedIndexChanged);
            //}
        }

        private void griddetalleocompra_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (griddetalleocompra.CurrentRow != null)
                {                   
                    
                    if (griddetalleocompra.Columns[e.ColumnIndex].Name.ToUpper() == "productid".ToUpper())
                    {
                        String xproductid = "";
                        xproductid = (this.griddetalleocompra.Rows[this.griddetalleocompra.CurrentRow.Index].Cells["productid"].Value.ToString().Trim()).PadLeft(13, '0');
                        if (xproductid != "0000000000000")
                        {
                            ValidaTabladetalleocompra(xproductid);
                        }
                    }

                    if (griddetalleocompra.Columns[e.ColumnIndex].Name.ToUpper() == "cantidad".ToUpper() || griddetalleocompra.Columns[e.ColumnIndex].Name.ToUpper() == "precunit".ToUpper()||
                        griddetalleocompra.Columns[e.ColumnIndex].Name.ToUpper() == "equiv_id")
                    {
                        //*** Declarando Variables
                        Decimal precunit_c = 0, tipcamb = 0, equiv = 0; //variables de movimiento
                        Decimal imporfac = 0, desct1 = 0, totimpx = 0, import = 0, valor = 0; //variables si es incluido igv
                        Decimal cantidad_c = 0, precio_c = 0, xstock = 0, xcostopromed = 0;
                        Decimal _cantidad=0; //variable dolares
                        cantidad_c = Convert.ToDecimal(griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["cantidad"].Value);
                        precio_c = Convert.ToDecimal(griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["precunit"].Value);
                        xstock = Convert.ToDecimal(griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["stock"].Value);
                        xcostopromed = Convert.ToDecimal(griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["costopromed"].Value);

                        equiv = Convert.ToDecimal(griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["equiv_id"].Value);

                        tb_cm_equivalenciaBL equivalenciaBL = new tb_cm_equivalenciaBL();

                        DataTable ds = new DataTable();
                        ds = equivalenciaBL.GetOne_Shear(EmpresaID, equiv);
                        Decimal equivalencia = Convert.ToDecimal(ds.Rows[0]["equivalencia"]);

                        //*** ASIGNANDO DATOS A VARIABLES
                        precunit_c = Math.Round(Convert.ToDecimal(precio_c), 6);
                        tipcamb = Convert.ToDecimal(tcamb.Text.Trim());
                        
                        //*** EVALUAR SI TIPO DE CAMBIO ES MENOR A 0
                        if (tipcamb <= 0)
                        {
                            tipcamb = 1;
                        }

                        //*** CALCULA EN IMPORTE FACTURADO
                        imporfac = Math.Round(cantidad_c * Convert.ToDecimal(precunit_c), 6);

                        //*** EVALUAR SI LA MONEDA ES DORALES($)
                        if (moneda.SelectedValue.ToString() == "$")
                        {
                            precunit_c = precunit_c * tipcamb;
                        }                       

                        _cal_Igv();

                        
                        //*** EVALUAR SI ES INCLUIDO O NO IGV        
                        desct1 = 0;
                        import = imporfac * (1 - (desct1 / 100));
                        if (incprec.Trim() == "S")
                        {
                            totimpx = Math.Round(import * (Convert.ToDecimal(pigv) / (100 + Convert.ToDecimal(pigv))), 6);
                        }
                        else
                        {
                            totimpx = Math.Round(import * (Convert.ToDecimal(pigv) / 100), 6);
                        }

                        //*** VALOR DEPENDIENDO DE LA ACCION DE ALMACEN Y EVALUA PRECIO/STOCK
                        if (almacaccionid.Trim().Substring(0, 1) == "2")
                        {
                            if (cantidad_c <= xstock)
                            {
                                valor = Math.Round(Convert.ToDecimal(xcostopromed), 6);
                            }
                            else
                            {
                                MessageBox.Show("Cantidad fuera de rango!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else if (almacaccionid.Trim().Substring(0, 1) == "1")
                        {
                            valor = precunit_c;
                        }

                        griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["valor"].Value = valor;
                        griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["importe"].Value = Math.Round(cantidad_c * valor, 6);
                        griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["dtotimpto"].Value = totimpx;
                        griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["importfac"].Value = Math.Round(imporfac, 2);
                        //griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["cantidad_c"].Value = Math.Round(equivalencia * imporfac);
                        griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["cantidad_c"].Value = (equivalencia * cantidad_c);
                        decimal prec = (imporfac / (equivalencia * cantidad_c));
                        griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["precunit_c"].Value = Math.Round((imporfac / (equivalencia * cantidad_c)),6);
                         
                        //Decimal resultado = Math.Round(equivalencia * imporfac);
                        //Decimal a = (equivalencia * imporfac);
                        //griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["cantidad"].Value = Math.Round(_cantidad);

                    }
                }
                calcular_totales();
            }
            catch (Exception ex)
            {
                String error = "";
                error = ex.GetType().ToString();
                if (error == "System.Data.ConstraintException")
                {
                    MessageBox.Show("Rollo ya existe!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void griddetalleocompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (griddetalleocompra.CurrentRow != null)
                {
                    if (almacaccionid.Trim().Substring(0, 1) == "1")
                    {
                        txt_valor.Text = Convert.ToDecimal(griddetalleocompra.Rows[e.RowIndex].Cells["costoultimo"].Value).ToString("#,###,##0.000").Trim();
                    }
                    else
                    {
                        txt_valor.Text = Convert.ToDecimal(griddetalleocompra.Rows[e.RowIndex].Cells["costopromed"].Value).ToString("#,###,##0.000").Trim();
                    }
                    txt_stock.Text = Convert.ToDecimal(griddetalleocompra.Rows[e.RowIndex].Cells["stock"].Value).ToString("#,###,##0.00").Trim();
                }
            }
            catch (Exception ex)
            {
             
            }
        }

        private void griddetalleocompra_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                if (almacaccionid.Trim().Substring(0, 1) == "1")
                {
                    txt_valor.Text = Convert.ToDecimal(griddetalleocompra.Rows[griddetalleocompra.CurrentRow.Index].Cells["costoultimo"].Value).ToString("#,###,##0.000").Trim();
                }
                else
                {
                    txt_valor.Text = Convert.ToDecimal(griddetalleocompra.Rows[griddetalleocompra.CurrentRow.Index].Cells["costopromed"].Value).ToString("#,###,##0.000").Trim();
                }
                txt_stock.Text = Convert.ToDecimal(griddetalleocompra.Rows[griddetalleocompra.CurrentRow.Index].Cells["stock"].Value).ToString("#,###,##0.00").Trim();
            }
        }

        private void griddetalleocompra_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            griddetalleocompra[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            griddetalleocompra[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            griddetalleocompra.EnableHeadersVisualStyles = false;
            griddetalleocompra.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            griddetalleocompra.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void griddetalleocompra_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            griddetalleocompra[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }

        #endregion

        private void moneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RecalculoGrid();
            tipimptotasa.Focus();
        }       

        #endregion

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            Process Proceso = new Process();
            Proceso.StartInfo.FileName = "calc.exe";
            Proceso.StartInfo.Arguments = "";
            Proceso.Start();
        }

        // Cargar Datos al comboBox del Factor
        void data_cbo_unmed()
        {
            try
            {
                tb_co_tabla06_unidadmedidaBL BL = new tb_co_tabla06_unidadmedidaBL();
                tb_co_tabla06_unidadmedida BE = new tb_co_tabla06_unidadmedida();
                DataTable dt = new DataTable();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                // Primer Combo Unidad De Medida
                //unmed.DataSource = dt;
                //unmed.ValueMember = "sigla";
                //unmed.DisplayMember = "descripcion";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Shear()
        {
            tb_cm_ordendecompra BE3 = new tb_cm_ordendecompra();
            tb_cm_ordendecompraBL BL3 = new tb_cm_ordendecompraBL();
            DataTable dt3 = new DataTable();
            
            dt3 = BL3.GetAll(EmpresaID, BE3).Tables[0];

            if (dt3.Rows.Count > 0)
            {
                //equiv = Convert.ToDecimal(dt3.Rows[0]["equivalencia"].ToString());                
            }
            else
            {
                
            }
        }

        private void griddetalleocompra_ColumnDataPropertyNameChanged(object sender, DataGridViewColumnEventArgs e)
        {

        }

        private void griddetalleocompra_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
           
        }

        private void griddetalleocompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {                   
                // Detecta si se ha seleccionado el header de la grilla                                
                if (e.RowIndex == -1)                
                return;

                if (griddetalleocompra.Columns[e.ColumnIndex].Name == "generar")
                {
                    // Se toma la fila seleccionada
                    DataGridViewRow row = griddetalleocompra.Rows[e.RowIndex];

                    // Se selecciona la celda del checkbox
                    DataGridViewCheckBoxCell cellSelecion = row.Cells["generar"] as DataGridViewCheckBoxCell;


                    if (Convert.ToBoolean(cellSelecion.Value))
                    {
                        //row.DefaultCellStyle.BackColor = Color.Green;
                        //genera_ordencompradetaux();
                    }
                    else
                    {
                        //row.DefaultCellStyle.BackColor = Color.White;
                        //genera_ordencompradetaux();
                    }



                    if (Convert.ToBoolean(cellSelecion.Value))
                    {
                        //string mensaje = string.Format("Evento CellContentClick.\n\nSe ha seccionado, \nCodigo: '{0}', \nProducto: '{1}', \nCantidad: '{2}'",
                        //row.Cells["productid"].Value,
                        //row.Cells["productname"].Value,
                        //row.Cells["cantidad"].Value);
                        //MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Al Hacer Check Debo de Star                        
                    }
                    else
                    {
                        //string mensaje = string.Format("Evento CellContentClick.\n\nSe ha quitado la seleccion, \nCodigo: '{0}', \nProducto: '{1}', \nCantidad: '{2}'",
                        //row.Cells["productid"].Value,
                        //row.Cells["productname"].Value,
                        //row.Cells["cantidad"].Value);
                        //MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
        }

        private void dvgCombo_SelectedIndexChanged(object sender, EventArgs e)
        {            
            
        }

        private void btn_attachedfile_Click(object sender, EventArgs e)
        {
            Frm_attachedfile attached = new Frm_attachedfile();
            attached.numdoc =numdoc2.Text.ToString() + "" + numdoc.Text.ToString();
            attached.moduloiddes = moduloiddes.SelectedValue.ToString();
            attached.serdoc = serdoc.Text;
            attached.ShowDialog();
        }
                
        private void tipimptotasa_SelectedIndexChanged(object sender, EventArgs e)
        {
            fechpago.Focus();
            calcular_totales();
        }

        private void glosa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                SendKeys.Send("\t");
            }
        }        

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            CargarComboGrid_Equiv();
        }

        private void griddetalleocompra_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (griddetalleocompra.IsCurrentCellDirty)
            {
                griddetalleocompra.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btn_GenerarOrden_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0")
            {
                #region ***** Verificamos si la Orden Existe en la Tabla OrdendeCompradet_Aux

                tb_cm_ordendecompraBL BL3 = new tb_cm_ordendecompraBL();
                tb_cm_ordendecompra BE3 = new tb_cm_ordendecompra();
                DataTable data = new DataTable();

                BE3.moduloid = modulo;
                BE3.local = local;
                BE3.tipodoc = "OC";
                BE3.serdoc = serdoc.Text.ToString();
                BE3.numdoc = numdoc2.Text.ToString() + numdoc.Text.ToString();
                BE3.filtro = "1";

                data = BL3.BuscarOrden(EmpresaID, BE3).Tables[0];

                if (data.Rows.Count > 0)
                {
                    MessageBox.Show("   !!! ...La Orden de Compra ya Fue Detallada... !!!  ");
                    return;
                }
                else
                {
                    #region ***** Recorremos el Detalle
                    Decimal _cantidad = 0, num = 1, _precunit = 0, _importfac = 0;

                    foreach (DataGridViewRow fila in griddetalleocompra.Rows)
                    {              
                        DataGridViewRow row = griddetalleocompra.Rows[fila.Index];
                        // Se selecciona la celda del checkbox
                        DataGridViewCheckBoxCell cellSelecion = row.Cells["generar"] as DataGridViewCheckBoxCell;

                        if (Convert.ToBoolean(cellSelecion.Value))
                        {
                            row.DefaultCellStyle.BackColor = Color.Green;                           
                            String _productid = "", _productname = "";
                            String _moduloid = "0100", _local = "001";

                            // Primero Verificamos la Cantidad Para Generar los Productos que Vamos A Crear
                            // Insertar el Primer Producto Señalado  en la ordendecompradet_aux
                            // Los  Demas productos de acuerdo a la Cantidad                        

                            #region ********* Condicion IF
                            FechentregaPROD = Convert.ToDateTime(griddetalleocompra.Rows[fila.Index].Cells["dfechentrega"].Value);
                            AniosemanaPROD = Convert.ToString(griddetalleocompra.Rows[fila.Index].Cells["aniosemana"].Value);
                            PrecioanteriorPROD = Convert.ToDecimal(griddetalleocompra.Rows[fila.Index].Cells["precioanterior"].Value);
                            ItemrefPROD = Convert.ToString(griddetalleocompra.Rows[fila.Index].Cells["itemref"].Value);
                            EquivPROD = Convert.ToDecimal(griddetalleocompra.Rows[fila.Index].Cells["equiv_id"].Value);
                            AlmaccionidPROD = Convert.ToString(griddetalleocompra.Rows[fila.Index].Cells["dalmacaccionid"].Value);
                            TotimptoPROD = Convert.ToDecimal(griddetalleocompra.Rows[fila.Index].Cells["dtotimpto"].Value);

                            _cantidad = Convert.ToDecimal(griddetalleocompra.Rows[fila.Index].Cells["cantidad"].Value);
                            CantidadPROD = _cantidad;
                            _precunit = Convert.ToDecimal(griddetalleocompra.Rows[fila.Index].Cells["precunit"].Value);
                            PrecunitPROD = _precunit;
                            _importfac = Convert.ToDecimal(griddetalleocompra.Rows[fila.Index].Cells["importfac"].Value);
                            ImportfacPROD = _importfac;
                            _productid = Convert.ToString(griddetalleocompra.Rows[fila.Index].Cells["productid"].Value);
                            CodigoPROD = _productid;
                            _productname = Convert.ToString(griddetalleocompra.Rows[fila.Index].Cells["productname"].Value);
                            NombrePROD = _productname;

                            // Creo que nos Ahorraremos Todo Este Codigo Porque lo Haremos por BASE DE DATOS
                            // LLamaremos solo a aun procedimiento que haga toda esa funcion

                            tb_cm_ordendecompra BE = new tb_cm_ordendecompra();
                            tb_cm_ordendecompraBL BL = new tb_cm_ordendecompraBL();

                            BE.productid = _productid.ToString().Trim();                        
                            BE.numdoc = numdoc2.Text.ToString() + numdoc.Text.ToString();
                            BE.moduloid = moduloiddes.SelectedValue.ToString();
                            BE.local = localdes.SelectedValue.ToString();

                            if (BL.GenerarOrdenDetallado(EmpresaID, BE))
                            {
                                num = num + 1;                               
                            }

                            //tb_60productosBL BL = new tb_60productosBL();
                            //tb_60productos BE = new tb_60productos();
                            //DataTable dt = new DataTable();
                           
                            #region **** Inserciones de Orden de Compra -- Productos
                            //if (_cantidad > num)
                            //{
                            //    CantPROD = 1;
                            //    Genera_OrdencompraDetaux2();

                            //    while (num < _cantidad)
                            //    {
                            //        BE.moduloid = moduloiddes.SelectedValue.ToString();
                            //        BE.lineaid = Equivalencias.Left(_productid, 3);
                            //        BE.grupoid = Equivalencias.Mid(_productid, 4, 4);
                            //        BE.subgrupoid = Equivalencias.Mid(_productid, 8, 3);

                            //        // Aca Vamos A Generar un Nuevo Item Para La misma -linea, -grupo, -subgrupo
                            //        dt = BL.GetAll_nuevocodprod(EmpresaID, BE).Tables[0];
                            //        if (dt.Rows.Count > 0)
                            //        {
                            //            //String _item = dt.Rows[0]["item"].ToString().Substring(10, 3);
                            //            BE.item = dt.Rows[0]["productid"].ToString().Substring(10, 3);
                            //            //BE.productid = BE.lineaid + BE.grupoid + BE.subgrupoid + _item.ToString();
                            //            BE.productid = dt.Rows[0]["productid"].ToString();
                            //            CodigoPROD = BE.productid;
                            //        }
                            //        CantPROD = 1;
                            //        BE.productname = _productname.ToString();

                            //        if (moneda.SelectedValue != null)
                            //            BE.moneda = moneda.SelectedValue.ToString();

                            //        BE.productidold = "0";
                            //        BE.unmed = "UND";
                            //        BE.fepialmac = DateTime.Today;
                            //        BE.feuialmac = DateTime.Today;
                            //        BE.precioenvase = Convert.ToDecimal(0);
                            //        BE.unmedenvase = "UND";
                            //        BE.procedenciaid = "0".ToString();
                            //        BE.unidenvase = Convert.ToDecimal(1);
                            //        BE.usuar = VariablesPublicas.Usuar.Trim();
                            //        BE.nserie = "";
                            //        BE.status = "0";
                            //        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                            //        BE.Foto = ms.GetBuffer();

                            //        // INSERCION DE PRODUCTOS
                            //        BL.Insert(EmpresaID, BE);
                            //        num++;

                            //        Genera_OrdencompraDetaux2();
                            //    }
                            //}

                            #endregion

                            #endregion

                        }
                        else if (Convert.ToBoolean(cellSelecion.Value) == false)
                        {
                            //  Verificar Tambien Cuando No Esten Seleccionados las Demas Filas
                            //  Deberia de Insertar Solo Detalle de Orden de Compra

                            #region ***** Condicion Else
                            //Decimal _cantidad = 0, num = 1, _precunit = 0, _importfac = 0;
                            String _productid = "", _productname = "";

                            FechentregaPROD = Convert.ToDateTime(griddetalleocompra.Rows[fila.Index].Cells["dfechentrega"].Value);
                            AniosemanaPROD = Convert.ToString(griddetalleocompra.Rows[fila.Index].Cells["aniosemana"].Value);
                            PrecioanteriorPROD = Convert.ToDecimal(griddetalleocompra.Rows[fila.Index].Cells["precioanterior"].Value);
                            ItemrefPROD = Convert.ToString(griddetalleocompra.Rows[fila.Index].Cells["itemref"].Value);
                            EquivPROD = Convert.ToDecimal(griddetalleocompra.Rows[fila.Index].Cells["equiv_id"].Value);
                            AlmaccionidPROD = Convert.ToString(griddetalleocompra.Rows[fila.Index].Cells["dalmacaccionid"].Value);
                            TotimptoPROD = Convert.ToDecimal(griddetalleocompra.Rows[fila.Index].Cells["dtotimpto"].Value);

                            _cantidad = Convert.ToDecimal(griddetalleocompra.Rows[fila.Index].Cells["cantidad"].Value);
                            CantidadPROD = _cantidad;
                            _precunit = Convert.ToDecimal(griddetalleocompra.Rows[fila.Index].Cells["precunit"].Value);
                            PrecunitPROD = _precunit;
                            _importfac = Convert.ToDecimal(griddetalleocompra.Rows[fila.Index].Cells["importfac"].Value);
                            ImportfacPROD = _importfac;
                            _productid = Convert.ToString(griddetalleocompra.Rows[fila.Index].Cells["productid"].Value);
                            CodigoPROD = _productid;
                            _productname = Convert.ToString(griddetalleocompra.Rows[fila.Index].Cells["productname"].Value);
                            NombrePROD = _productname;



                            tb_cm_ordendecompra BE = new tb_cm_ordendecompra();
                            tb_cm_ordendecompraBL BL = new tb_cm_ordendecompraBL();

                            BE.productid = _productid.ToString().Trim();
                            BE.numdoc = numdoc2.Text.ToString() + numdoc.Text.ToString();
                            BE.moduloid = moduloiddes.SelectedValue.ToString();
                            BE.local = localdes.SelectedValue.ToString();
                            BE.filtro = "2";

                            if (BL.GenerarOrdenDetallado(EmpresaID, BE))
                            {
                                num = num + 1;
                            }

                            //try
                            //{
                            //    Genera_OrdencompraDetaux();
                            //    num = num + 1;
                            //}
                            //catch (Exception ex)
                            //{
                            //    throw ex;
                            //}
                            #endregion
                        }

                    }

                    MessageBox.Show("Numero de Operaciones Realizadas : "+Convert.ToString(num)+" Correctamente","Procesando...!!!");

                    #endregion
                }

                #endregion
            }
        }


        private void btn_imprimiraux_Click(object sender, EventArgs e)
        {
            try
            {
                if (Tabladetalleocompra.Rows.Count > 0)
                {
                    Reportes.Frm_reportes miForma = new Reportes.Frm_reportes();

                    miForma.dominioid = dominio.Trim();
                    miForma.moduloid = modulo.Trim();
                    miForma.local = local.Trim();
                    miForma.Text = "Reporte Orden de Compra";
                    miForma.formulario = "Frm_ordencompra2";
                    miForma.tipdoc = tipodoc.Trim().ToString();
                    miForma.serdoc = serdoc.Text.ToString();
                    miForma.numdoc = numdoc2.Text.ToString() + "" + numdoc.Text.Trim().PadLeft(6, '0');
                    miForma.localdes = localdes.SelectedValue.ToString();

                    // Pasamos el Local Direc
                    sys_localBL BL = new sys_localBL();
                    tb_sys_local BE = new tb_sys_local();
                    BE.dominioid = "60";
                    BE.moduloid = moduloiddes.SelectedValue.ToString();
                    BE.local = localdes.SelectedValue.ToString();
                    DataTable dt = new DataTable();
                    dt = BL.GetAll(EmpresaID, BE).Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        miForma.localdestino = dt.Rows[0]["localdirec"].ToString();
                        //VariablesPublicas.localdirec = dt.Rows[0]["localdirec"].ToString();                         
                    }    
                    miForma.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void Cambiar_Icono()
        {
            tb_cm_ordendecompraBL BL3 = new tb_cm_ordendecompraBL();
            tb_cm_ordendecompra BE3 = new tb_cm_ordendecompra();
            DataTable data = new DataTable();

            BE3.moduloid = modulo;
            BE3.local = local;
            BE3.tipodoc = "OC";
            BE3.serdoc = serdoc.Text.ToString();
            BE3.numdoc = numdoc2.Text.ToString() + numdoc.Text.ToString();
            BE3.filtro = "1";

            data = BL3.BuscarOrden(EmpresaID, BE3).Tables[0];

            if (data.Rows.Count > 0)
            {
                //btn_GenerarOrden.Visible = false;
            }
            else {
                btn_GenerarOrden.Visible = true;
            }

        }

        private void btn_refresh_tcamb_Click(object sender, EventArgs e)
        {
            get_tipocambio(fechdoc.Text);
        }

        private void numdoc_KeyDown(object sender, KeyEventArgs e)
        {
            //numdoc.Text = numdoc.Text.Trim().PadLeft(6, '0');
            //if (ssModo != "NEW")
            if (e.KeyCode == Keys.Enter)
            {
                form_cargar_datos("");
            }
        }

    }
}