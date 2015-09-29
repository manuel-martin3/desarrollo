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
using System.Net.Mail;
using BapFormulariosNet.DL0Logistica;
using Excel = Microsoft.Office.Interop.Excel;

using System.Data.OleDb;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Reflection; //para el valor missing

using System.IO;
using System.Net;
using System.Xml;
using System.Diagnostics;


namespace BapFormulariosNet.MERCADERIA
{
    public partial class Frm_movimiento : plantilla
    {
        /*** variables de cabecera del documento actual ***/
        String EmpresaID = VariablesPublicas.EmpresaID.Trim();
        String dominio = string.Empty;
        String modulo = string.Empty;
        String local = string.Empty;
        String perianio = "";
        String perimes = "";
        private bool novalidastock = false;

        String XNIVEL = "";
        String XGLOSA = "";
        String PERFILID = "";

        DataTable Tabladetallemov;
        private DataRow row;
        private TextBox txtCDetalle = null;

        String xxferfil = "";
        String almacaccionid = "";
        String statcostopromed = "";
        String tiptransac = "";
        Boolean fechadocedit = false;
        Boolean tipodocautomatico = false;
        Boolean tipodocmanejaserie = false;
        Boolean statusDoc = true;
        Boolean xnostock = false;

        String tipimptoid = "";
        String producid = "";
        Decimal igv = 0;
        String direcnume = "";
        String incprec = "N";
        String ssModo = "NEW";
        String _perimes = "";

        static Decimal xprecventa = 0, xcostoultimo = 0;

        public Frm_movimiento()
        {
            InitializeComponent();

            numdoc.LostFocus += new System.EventHandler(numdoc_LostFocus);
            num_op.LostFocus += new System.EventHandler(num_op_LostFocus);
            serfac.LostFocus += new System.EventHandler(serfac_LostFocus);
            serguia.LostFocus += new System.EventHandler(serguia_LostFocus);
            sernotac.LostFocus += new System.EventHandler(sernotac_LostFocus);
            //numfac.LostFocus += new System.EventHandler(numfac_LostFocus);
            numguia.LostFocus += new System.EventHandler(numguia_LostFocus);
            numnotac.LostFocus += new System.EventHandler(numnotac_LostFocus);
            fechdoc.LostFocus += new System.EventHandler(fechdoc_LostFocus);
            ctacte.LostFocus += new System.EventHandler(ctacte_LostFocus);
            nmruc.LostFocus += new System.EventHandler(nmruc_LostFocus);
            cencosid.LostFocus += new System.EventHandler(cencosid_LostFocus);
            vendperid.LostFocus += new System.EventHandler(vendedorid_LostFocus);
            transpid.LostFocus += new System.EventHandler(transpid_LostFocus);

        }

        #region $$$ ADMINISTRADOR
        private void PARAMETROS_TABLA()
        {
            if (modulo == "0500")
            {
                xxferfil = "600500000";
            }
            else if (modulo == "0520")
            {
                xxferfil = "600520000";
            }
            else
            {
                MainMercaderia f = (MainMercaderia)this.MdiParent;
                xxferfil = f.perfil.ToString();
            }

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

                bool sw = false;
                sw = Convert.ToBoolean(miForma.ShowDialog());

                if (sw)
                {
                    btn_detanadir.Enabled = true;
                }
                else btn_detanadir.Enabled = false;
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
                if (tipodoc.SelectedValue.ToString() != "00" && tipodoc.SelectedIndex != 0)
                {
                    modulo_local_tipodocBL BL = new modulo_local_tipodocBL();
                    tb_modulo_local_tipodoc BE = new tb_modulo_local_tipodoc();
                    DataTable dt = new DataTable();

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
                        data_cbo_tipooperacion(almacaccionid.Substring(0, 1));
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
                constantesgeneralesBL BL = new constantesgeneralesBL();
                tb_constantesgenerales BE = new tb_constantesgenerales();
                DataTable dt = new DataTable();

                dt = BL.GetOne(EmpresaID, dominio, modulo, local).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    perianio = dt.Rows[0]["perianio"].ToString().Trim();
                    // Vamos Obtener el Check de Perimes Local Para Usar el Perimes de Constanantes o del Bapconfig
                    var BL2 = new sys_localBL();
                    var BE2 = new tb_sys_local();
                    DataTable dt2 = new DataTable();
                    BE2.dominioid = dominio.ToString();
                    BE2.moduloid = modulo.ToString(); ;
                    BE2.local = local.ToString();
                    dt2 = BL2.GetAll(VariablesPublicas.EmpresaID, BE2).Tables[0];
                    if (dt2.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dt2.Rows[0]["perimeslocal"]))
                        {
                            // Hemos Fijado el Perimes en BapConfig
                            perimes = _perimes;
                        }
                        else
                        {
                            // Ponemos el Perimes de Constantes Generales
                            perimes = dt.Rows[0]["perimes"].ToString().Trim();
                        }
                    }
                    if (dt.Rows[0]["fechadocedit"].ToString().Trim().Length > 0)
                    {
                        fechadocedit = Convert.ToBoolean(dt.Rows[0]["fechadocedit"]);
                    }
                }

                DateTime fechaactual = DateTime.Today;
                DateTime fechaperiodo = Convert.ToDateTime("01" + "/" + perimes + "/" + perianio);

                if (fechadocedit)
                {
                    //DateTime primerdia = new DateTime(fechaperiodo.Year, fechaperiodo.Month, 1);
                    //DateTime ultimodia = primerdia.AddMonths(1).AddDays(-1);
                    //if (fechaactual.Day <= ultimodia.Day)
                    //{
                    //    fechdoc.Value = Convert.ToDateTime(fechaactual.Day + "/" + perimes + "/" + perianio);
                    //}
                    //else
                    //{
                    //    fechdoc.Value = Convert.ToDateTime(ultimodia.Day + "/" + perimes + "/" + perianio);
                    //}
                    //fechdoc.MaxDate = ultimodia;
                    //fechdoc.MinDate = primerdia;
                }
                else
                {
                    if (fechaactual.Month == fechaperiodo.Month && fechaactual.Year == fechaperiodo.Year)
                    {
                        fechdoc.Value = fechaactual;
                        //fechdoc.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Actualizar a Periodo Actual en Tabla Constantes Generales !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                modulo_local_tipodocseriesBL BL = new modulo_local_tipodocseriesBL();
                tb_modulo_local_tipodocseries BE = new tb_modulo_local_tipodocseries();
                DataTable dt = new DataTable();
                BE.dominioid = dominio;
                BE.moduloid = modulo;
                BE.local = local;
                BE.tipodoc = tipodoc.SelectedValue.ToString().Trim();

                // Falta pasar el serdoc

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
                    tipimptotasa.DisplayMember = "tipimptotasa";
                    tipimptotasa.ValueMember = "tipimptoid";
                    tipimptotasa.SelectedIndex = 1;
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

        private void _RecuperarNcaja()
        {

            XmlDocument xDoc = new XmlDocument();
            //La ruta del documento XML permite rutas relativas 
            string xArchivo = @"c:\ErpBapSoftNet_Config\BapConfig.cfg";
            xDoc.Load(xArchivo);

            XmlNodeList configuration = xDoc.GetElementsByTagName("configuration");
            XmlNodeList lista = ((XmlElement)configuration[0]).GetElementsByTagName("Paramlocal");

            foreach (XmlElement nodo in lista)
            {
                int i = 0;
                //XmlNodeList ncajanume = nodo.GetElementsByTagName("cajanume");
                XmlNodeList nperimes = nodo.GetElementsByTagName("perimes");
                //_cajanume = ncajanume[i].InnerText;
                _perimes = nperimes[i].InnerText;
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
                //fechdoc.Enabled = ;
                moneda.Enabled = var;
                tcamb.Enabled = var;
                tcamb.ReadOnly = true;
                tipimptotasa.Enabled = var;
                nmruc.Enabled = var;
                ctacte.Enabled = var;
                ctactename.Enabled = var;
                ctactename.ReadOnly = true;
                direc.Enabled = var;
                direc.ReadOnly = true;
                mottrasladointid.Enabled = var;
                btnRefresh.Enabled = var;
                direcname.Enabled = var;
                direcdeta.Enabled = var;
                tipoperacionid.Enabled = var;
                motivotrasladoid.Enabled = var;

                tipref.Enabled = var;
                serref.Enabled = false;
                //numref.Enabled = var;
                fechref.Enabled = false;

                tipfac.Enabled = false;
                serfac.Enabled = false;
                numfac.Enabled = false;
                fechfac.Enabled = var;
                fechfac.Checked = false;

                tipguia.Enabled = false;
                serguia.Enabled = false;
                numguia.Enabled = false;
                fechguia.Enabled = var;
                fechguia.Checked = false;

                tipnotac.Enabled = false;
                sernotac.Enabled = false;
                numnotac.Enabled = false;
                fechnotac.Enabled = var;
                fechnotac.Checked = false;

                ser_op.Enabled = var;
                num_op.Enabled = var;
                cencosid.Enabled = var;
                cencosname.Enabled = var;
                cencosname.ReadOnly = true;
                vendperid.Enabled = var;
                vendpername.Enabled = var;
                vendpername.ReadOnly = true;
                fechentrega.Enabled = var;
                fechpago.Enabled = var;
                transpid.Enabled = var;
                transpname.Enabled = var;
                transpname.ReadOnly = true;
                transpplaca.Enabled = var;
                transpplaca.ReadOnly = true;
                transpcertificado.Enabled = var;
                transpcertificado.ReadOnly = true;
                transplicencia.Enabled = var;
                transplicencia.ReadOnly = true;
                ddnni.Enabled = var;
                ddnniname.Enabled = var;
                ddnniname.ReadOnly = true;
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

                griddetallemov.ReadOnly = !var;
                griddetallemov.Columns["item"].ReadOnly = true;
                griddetallemov.Columns["nostock"].ReadOnly = true;
                griddetallemov.Columns["productname"].ReadOnly = true;
                griddetallemov.Columns["stock"].ReadOnly = true;
                griddetallemov.Columns["importfac"].ReadOnly = true;
                griddetallemov.Columns["unmed"].ReadOnly = true;
                //griddetallemov.Columns["importe"].ReadOnly = true;

                btn_export.Enabled = var;
                btn_import.Enabled = var;

                btn_nuevo.Enabled = false;
                btn_editar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_grabar.Enabled = false;
                btn_barcode.Enabled = false;
                btn_eliminar.Enabled = false;
                btn_imprimir.Enabled = false;
                btnImprimirNoval.Enabled = false;

                btn_primero.Enabled = false;
                btn_anterior.Enabled = false;
                btn_siguiente.Enabled = false;
                btn_ultimo.Enabled = false;

                btn_detanadir.Enabled = false;
                btn_deteliminar.Enabled = false;
                btn_attachedfile.Enabled = false;
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
                tipodoc.SelectedIndex = 0;
                tipodoc.Enabled = false;
                limpiar_documento();
                form_bloqueado(false);
                get_val_fechadoc();
                btn_nuevo.Enabled = true;
                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;
                numdococ.Enabled = false;
                ssModo = "NEW";
                //fechdoc.MinDate = new DateTime(2000, 1, 1);
                //fechdoc.MaxDate = new DateTime(2999, 12, 12);
                //fechdoc.Value = DateTime.Today;
                tabdatos.SelectedIndex = 0;

                nmruc.Focus();
            }
        }

        private void form_cargar_datos(String posicion)
        {
            try
            {
                limpiar_documento();
                tb_me_movimientoscabBL BL = new tb_me_movimientoscabBL();
                tb_me_movimientoscab BE = new tb_me_movimientoscab();
                DataTable dt = new DataTable();

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
                    if (posicion.Trim().Length > 0) MessageBox.Show("Seleccionar el Tipo de Documento !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    data_cbo_tiporeferencia(almacaccionid);
                    serdoc.Text = dt.Rows[0]["serdoc"].ToString().Trim();
                    numdoc.Text = dt.Rows[0]["numdoc"].ToString().Trim();
                    fechdoc.Text = dt.Rows[0]["fechdoc"].ToString().Trim();

                    tipimptoid = dt.Rows[0]["tipimptoid"].ToString().Trim();
                    direcnume = dt.Rows[0]["direcnume"].ToString().Trim();
                    lbllocal.Text = dt.Rows[0]["direcnume"].ToString().Trim();
                    incprec = dt.Rows[0]["incprec"].ToString().Trim();

                    moneda.SelectedValue = dt.Rows[0]["moneda"].ToString().Trim();
                    txtmoneda.Text = dt.Rows[0]["moneda"].ToString().Trim();
                    tcamb.Text = dt.Rows[0]["tcamb"].ToString().Trim();

                    // Modificaciones tipimptotasa.text = 

                    if (dt.Rows[0]["tipimptoid"].ToString().Trim().Length > 0)
                    {
                        tipimptotasa.SelectedValue = dt.Rows[0]["tipimptoid"].ToString().Trim();
                    }
                    else
                    {
                        tipimptotasa.SelectedIndex = -1;
                    }

                    ctacte.Text = dt.Rows[0]["ctacte"].ToString().Trim();
                    nmruc.Text = dt.Rows[0]["nmruc"].ToString().Trim();
                    ctactename.Text = dt.Rows[0]["ctactename"].ToString().Trim();
                    direc.Text = dt.Rows[0]["direc"].ToString().Trim();

                    if (dt.Rows[0]["mottrasladointid"].ToString().Trim().Length > 0 && dt.Rows[0]["mottrasladointid"].ToString().Trim() != "00")
                    {
                        mottrasladointid.SelectedValue = dt.Rows[0]["mottrasladointid"].ToString().Trim();
                    }
                    else
                    {
                        mottrasladointid.SelectedIndex = -1;
                    }
                    direcname.Text = dt.Rows[0]["direcname"].ToString().Trim();
                    direcdeta.Text = dt.Rows[0]["direcdeta"].ToString().Trim();
                    if (dt.Rows[0]["tipoperacionid"].ToString().Trim().Length > 0)
                    {
                        tipoperacionid.SelectedValue = dt.Rows[0]["tipoperacionid"].ToString().Trim();
                    }
                    else
                    {
                        tipoperacionid.SelectedIndex = -1;
                    }

                    if (dt.Rows[0]["motivotrasladoid"].ToString().Trim().Length > 0 & dt.Rows[0]["motivotrasladoid"].ToString().Trim() != "00")
                    {
                        motivotrasladoid.SelectedValue = dt.Rows[0]["motivotrasladoid"].ToString().Trim();
                    }
                    else
                    {
                        motivotrasladoid.SelectedIndex = -1;
                    }

                    if (dt.Rows[0]["tipref"].ToString().Trim().Length > 0 && dt.Rows[0]["serref"].ToString().Trim().Length > 0)
                    {
                        tipref.SelectedValue = dt.Rows[0]["tipref"].ToString().Trim();
                        serref.Text = dt.Rows[0]["serref"].ToString().Trim();

                        //numdococ.Text = dt.Rows[0]["numref"].ToString().Trim();

                        String n = dt.Rows[0]["numref"].ToString().Trim();

                        numdococ1.Text = Equivalencias.Left(n, 4);
                        numdococ.Text = Equivalencias.Right(n, 6);

                        fechref.Format = DateTimePickerFormat.Short;
                        fechref.Text = dt.Rows[0]["fechref"].ToString().Trim();
                    }
                    else
                    {
                        tipref.SelectedIndex = -1;
                    }

                    if (dt.Rows[0]["serfac"].ToString().Trim().Length > 0 && dt.Rows[0]["numfac"].ToString().Trim().Length > 0)
                    {
                        tipfac.Text = dt.Rows[0]["tipfac"].ToString().Trim();
                        serfac.Text = dt.Rows[0]["serfac"].ToString().Trim();
                        numfac.Text = dt.Rows[0]["numfac"].ToString().Trim();
                        fechfac.Format = DateTimePickerFormat.Short;
                        fechfac.Text = dt.Rows[0]["fechfac"].ToString().Trim();
                    }
                    else
                    {
                        tipfac.SelectedIndex = 0;
                    }

                    if (dt.Rows[0]["serguia"].ToString().Trim().Length > 0 && dt.Rows[0]["numguia"].ToString().Trim().Length > 0)
                    {
                        serguia.Text = dt.Rows[0]["serguia"].ToString().Trim();
                        numguia.Text = dt.Rows[0]["numguia"].ToString().Trim();
                        fechguia.Format = DateTimePickerFormat.Short;
                        fechguia.Text = dt.Rows[0]["fechguia"].ToString().Trim();
                    }

                    if (dt.Rows[0]["sernotac"].ToString().Trim().Length > 0 && dt.Rows[0]["numnotac"].ToString().Trim().Length > 0)
                    {
                        sernotac.Text = dt.Rows[0]["sernotac"].ToString().Trim();
                        numnotac.Text = dt.Rows[0]["numnotac"].ToString().Trim();
                        fechnotac.Format = DateTimePickerFormat.Short;
                        fechnotac.Text = dt.Rows[0]["fechnotac"].ToString().Trim();
                    }

                    if (dt.Rows[0]["ser_op"].ToString().Trim().Length > 0 && dt.Rows[0]["num_op"].ToString().Trim().Length > 0)
                    {
                        ser_op.Text = dt.Rows[0]["ser_op"].ToString().Trim();
                        num_op.Text = dt.Rows[0]["num_op"].ToString().Trim();
                    }

                    //cencosid, cencosname
                    ValidaCentroCosto(dt.Rows[0]["cencosid"].ToString(), true);
                    //vendedorid, vendedorname                    
                    //Valida Dependiendo del Dni de la Persona
                    ValidaPersona(dt.Rows[0]["perdni"].ToString(), true);
                    //ValidaVendedor(dt.Rows[0]["vendorid"].ToString(), true);

                    if (dt.Rows[0]["fechentrega"].ToString().Trim().Substring(0, 10) != "01/01/1900")
                    {
                        fechentrega.Format = DateTimePickerFormat.Short;
                        fechentrega.Text = dt.Rows[0]["fechentrega"].ToString().Trim();
                    }

                    if (dt.Rows[0]["fechpago"].ToString().Trim().Substring(0, 10) != "01/01/1900")
                    {
                        fechpago.Format = DateTimePickerFormat.Short;
                        fechpago.Text = dt.Rows[0]["fechpago"].ToString().Trim();
                    }

                    //transpid, transpname, transpplaca, transpcertificado, transplicencia
                    ValidaTransportista(dt.Rows[0]["transpid"].ToString(), false);
                    ddnni.Text = dt.Rows[0]["ddnni"].ToString().Trim();
                    //dnimane.Text = "";
                    itemsT.Text = dt.Rows[0]["items"].ToString().Trim();
                    totpzas.Text = dt.Rows[0]["totpzas"].ToString().Trim();
                    bruto.Text = dt.Rows[0]["bruto"].ToString().Trim();
                    totdscto1.Text = dt.Rows[0]["totdscto1"].ToString().Trim();
                    valventa.Text = dt.Rows[0]["valventa"].ToString().Trim();
                    totimpto.Text = dt.Rows[0]["totimpto"].ToString().Trim();
                    totimporte.Text = dt.Rows[0]["totimporte"].ToString().Trim();
                    glosa.Text = dt.Rows[0]["glosa"].ToString().Trim();

                    //Tabladetallemov DEL DOCUMENTO
                    data_Tabladetallemovmov();
                    if (dt.Rows[0]["status"].ToString().Trim() != "9")
                    {
                        btn_editar.Enabled = true;
                        btn_eliminar.Enabled = true;
                        btn_imprimir.Enabled = true;
                        btnImprimirNoval.Enabled = true;
                        btn_attachedfile.Enabled = true;

                        btn_primero.Enabled = true;
                        btn_anterior.Enabled = true;
                        btn_siguiente.Enabled = true;
                        btn_ultimo.Enabled = true;


                        btn_salir.Enabled = true;
                        griddetallemov.Focus();
                        griddetallemov.Rows[0].Selected = false;
                        pdtimagen.Visible = false;
                        //numdococ1.Enabled = false;
                    }
                    else
                    {


                        ssModo = "ANULADO";
                        txt_status.Text = "ANULADO";
                        //btn_clave.Image = global::BapFormulariosNet.Properties.Resources.btn_Lock20;
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

                        //numdococ1.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region $$$ Llenado de Combobox

        void data_cbo_tipodoc()
        {
            try
            {
                modulo_local_tipodocBL BL = new modulo_local_tipodocBL();
                tb_modulo_local_tipodoc BE = new tb_modulo_local_tipodoc();
                BE.dominioid = dominio;
                BE.moduloid = modulo;
                BE.local = local;
                BE.visiblealmac = true;
                BE.status = "";
                BE.tipodoctipotransac = "A";

                tipodoc.DataSource = BL.GetAll_mov(EmpresaID, BE).Tables[0];
                tipodoc.ValueMember = "tipodoc";
                tipodoc.DisplayMember = "tipodocname";
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
                DataTable dt = new DataTable();
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

        void data_cbo_motivotrasladoid()
        {
            try
            {
                tb_co_motivodeltrasladoBL BL = new tb_co_motivodeltrasladoBL();
                tb_co_motivodeltraslado BE = new tb_co_motivodeltraslado();
                motivotrasladoid.DataSource = BL.GetAll(EmpresaID, BE).Tables[0];
                motivotrasladoid.ValueMember = "motivotrasladoid";
                motivotrasladoid.DisplayMember = "motivotrasladoname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void data_cbo_mottrasladointid()
        {
            try
            {
                tb_mottrasladointBL BL = new tb_mottrasladointBL();
                tb_mottrasladoint BE = new tb_mottrasladoint();
                BE.moduloid = modulo;
                BE.tipmov = almacaccionid.Trim().PadLeft(1, '0').Substring(0, 1);
                mottrasladointid.DataSource = BL.GetAll(EmpresaID, BE).Tables[0];
                mottrasladointid.ValueMember = "mottrasladointid";
                mottrasladointid.DisplayMember = "mottrasladointname";
                mottrasladointid.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void data_cbo_tipooperacion(String almacaccion)
        {
            try
            {
                tb_co_tabla12_toperacionalmacenBL BL = new tb_co_tabla12_toperacionalmacenBL();
                tb_co_tabla12_toperacionalmacen BE = new tb_co_tabla12_toperacionalmacen();
                BE.almacenaccionid = almacaccion.Trim();
                tipoperacionid.DataSource = BL.GetAll(EmpresaID, BE).Tables[0];
                tipoperacionid.ValueMember = "codigoid";
                tipoperacionid.DisplayMember = "descripcion";
                tipoperacionid.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void data_cbo_tiporeferencia(string accion)
        {
            modulo_local_tipodocBL BL = new modulo_local_tipodocBL();
            tb_modulo_local_tipodoc BE = new tb_modulo_local_tipodoc();
            BE.dominioid = dominio;
            BE.moduloid = modulo;
            BE.local = local;
            BE.almacaccionid = Convert.ToString(Convert.ToInt16(accion) + 1);
            BE.visiblealmac = true;
            try
            {
                tipref.DataSource = BL.GetAll(EmpresaID, BE).Tables[0];
                tipref.ValueMember = "tipodoc";
                tipref.DisplayMember = "tipodocname";
                tipref.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void ValidaCliente()
        {
            if (nmruc.Text.Trim().Length > 0 || ctacte.Text.Trim().Length > 0)
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

                    direcnume = "";
                    direcname.Text = "";
                    direcdeta.Text = "";
                    nmruc.Focus();
                }
            }
        }

        private void ValidaDocref()
        {
            if (tipref.SelectedIndex != -1 && serref.Text.Trim().Length == 4 && numdococ.Text.Trim().Length == 6)
            {
                tb_cm_ordendecompracabBL BL = new tb_cm_ordendecompracabBL();
                tb_cm_ordendecompracab BE = new tb_cm_ordendecompracab();

                DataTable dt = new DataTable();
                BE.moduloid = "0100";
                BE.local = "001";
                BE.tipodoc = tipref.SelectedValue.ToString();
                BE.serdoc = serref.Text.Trim();
                BE.numdoc = numdococ1.Text.ToString() + numdococ.Text.Trim();
                //BE.numdoc =  numdococ.Text.Trim();
                dt = BL.GetOne(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (local == dt.Rows[0]["localdes"].ToString().Trim())
                    {
                        serref.Text = dt.Rows[0]["serdoc"].ToString().Trim();
                        String numdoc = dt.Rows[0]["numdoc"].ToString().Trim();

                        numdococ1.Text = Equivalencias.Left(numdoc, 4);
                        numdococ.Text = Equivalencias.Right(numdoc, 6);

                        fechref.Format = DateTimePickerFormat.Short;
                        fechref.Value = Convert.ToDateTime(dt.Rows[0]["fechdoc"]);
                        ctacte.Text = dt.Rows[0]["ctacte"].ToString().Trim();
                        nmruc.Text = dt.Rows[0]["nmruc"].ToString().Trim();
                        ctactename.Text = dt.Rows[0]["ctactename"].ToString().Trim();
                        direc.Text = dt.Rows[0]["direc"].ToString().Trim();
                        moneda.SelectedValue = dt.Rows[0]["moneda"].ToString().Trim();

                        String s = dt.Rows[0]["sigla"].ToString().Trim();
                        txtmoneda.Text = dt.Rows[0]["sigla"].ToString().Trim();
                    }
                    else
                    {
                        MessageBox.Show("La Orden de Compra : "
                                            + dt.Rows[0]["numdoc"].ToString().Trim() + "\n"
                                             + "  Esta Destinada a Otro Local !!!");
                        return;
                    }
                }
            }
        }

        private void Tabla_detOC()
        {
            _cal_Igv();

            Decimal xxprecventa = 0, xxcostoultimo = 0, xxstock = 0, xxcostopromed = 0;
            griddetallemov.AutoGenerateColumns = false;

            tb_cm_ordendecompradetBL BL = new tb_cm_ordendecompradetBL();
            tb_cm_ordendecompradet BE = new tb_cm_ordendecompradet();
            DataTable dt = new DataTable();

            BE.moduloid = "0100";
            BE.local = "001";
            BE.tipodoc = tipref.SelectedValue.ToString();
            BE.serdoc = serref.Text.Trim();   // Vendria Ser el Modulo de Cada Almacen
            BE.numdoc = numdococ1.Text.Trim() + numdococ.Text.Trim();  // Correlativo de Cada Orden de Compra

            dt = BL.GetAll(EmpresaID, BE).Tables[0];

            if (dt.Rows.Count > 0)
            {

                if (local == dt.Rows[0]["localdes"].ToString().Trim())
                {

                    Decimal cantidadcta_cc = (Decimal)(dt.Rows[0]["cantidadcta_c"]);
                    Decimal cantidad_cc = (Decimal)(dt.Rows[0]["cantidad_c"]);

                    foreach (DataRow fila in dt.Rows)
                    {
                        //if (cantidadcta_cc < cantidad_cc)
                        //{
                        tb_me_local_stockBL BL2 = new tb_me_local_stockBL();
                        tb_me_local_stock BE2 = new tb_me_local_stock();
                        DataTable dt2 = new DataTable();

                        BE2.moduloid = modulo;
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
                            else if (almacaccionid.Trim() == "10" || almacaccionid.Trim() == "11")
                            {
                                lbl_valor.Text = "Cost.Ultm";
                                xxcostoultimo = Convert.ToDecimal(dt2.Rows[0]["costoultimo"]);
                            }

                            xxstock = Convert.ToDecimal(dt2.Rows[0]["stock"]);
                        }

                        tipoperacionid.Text = "COMPRA";
                        row = Tabladetallemov.NewRow();
                        row["itemref"] = fila["itemref"].ToString();
                        row["items"] = fila["items"].ToString();
                        row["productid"] = fila["productid"].ToString().Trim();
                        row["productname"] = fila["productname"].ToString().Trim();
                        //row["rollo"] = fila["rollo"].ToString();

                        Decimal cantidad_c = Math.Round(Convert.ToDecimal(fila["cantidad_c"]), 4);
                        Decimal cantidadcta_c = Math.Round(Convert.ToDecimal(fila["cantidadcta_c"]), 4);

                        if (tipref.SelectedIndex != -1)
                        {
                            Decimal stock_old = Math.Round(Convert.ToDecimal(fila["cantidad_c"]), 4);
                            Decimal total = cantidad_c - cantidadcta_c;
                            row["stock_old"] = total;
                            row["stock"] = stock_old - total;
                        }
                        else
                        {
                            row["stock"] = xxstock;
                            row["stock_old"] = xxstock;
                        }

                        row["precventa"] = xxprecventa;
                        row["costoultimo"] = xxcostoultimo;
                        row["costopromed"] = xxcostopromed;

                        Decimal saldo;
                        saldo = cantidad_c - cantidadcta_c;
                        row["cantidad"] = saldo;
                        row["cantidad_old"] = Math.Round(Convert.ToDecimal(fila["cantidad"]), 4);
                        row["precunit"] = Math.Round(Convert.ToDecimal(Convert.ToDecimal(fila["precunit_c"]).ToString("###,###,##0.000000")), 6);
                        Decimal precunit = Math.Round(Convert.ToDecimal(Convert.ToDecimal(fila["precunit_c"]).ToString("###,###,##0.000000")), 6);
                        Decimal importe;
                        importe = cantidad_c * precunit;

                        row["importfac"] = importe;
                        row["valor"] = Math.Round(Convert.ToDecimal(fila["valor"]), 6);
                        row["importe"] = Math.Round(Convert.ToDecimal(fila["importe"]), 6);
                        row["totimpto"] = Math.Round(Math.Round(Convert.ToDecimal(fila["importe"]), 6) * (Convert.ToDecimal(igv) / 100), 6);
                        row["almacaccionid"] = almacaccionid.Trim();
                        //row["ubicacion"] = fila["ubicacion"].ToString().Trim();
                        Tabladetallemov.Rows.Add(row);
                        // }
                        griddetallemov.DataSource = Tabladetallemov;
                    }

                    _RecalculoGrid();
                }
                else
                {
                    tipref.Enabled = true;
                    tipref.SelectedIndex = -1;
                    tipref.Enabled = true;
                    numdococ1.Text = "";
                    numdococ.Text = "";
                    return;
                }
            }
            else
            {
                MessageBox.Show("    !!!... Informacion de la Orden ...!!! \n" +
                                "\n » La Orden Todabia no ha Sido Generada " +
                                "\n » O la Orden esta Generada en Otra Guia " +
                                "\n\n »» Verifica Tus Ordenes Pendientes  ", "Localizando Orden", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                tipref.Enabled = true;
                tipref.SelectedIndex = -1;
                tipref.Enabled = true;
                numdococ1.Text = "";
                numdococ.Text = "";
                return;
            }

        }

        private void Tabla_detOC2()
        {

            Decimal xxprecventa = 0, xxcostoultimo = 0, xxstock = 0, xxcostopromed = 0;
            griddetallemov.AutoGenerateColumns = false;

            tb_cm_ordendecompradetBL BL = new tb_cm_ordendecompradetBL();
            tb_cm_ordendecompradet BE = new tb_cm_ordendecompradet();
            DataTable dt = new DataTable();

            BE.moduloid = "0100";
            BE.local = "001";
            BE.tipodoc = tipref.SelectedValue.ToString();
            BE.serdoc = serref.Text.Trim();   // Vendria Ser el Modulo de Cada Almacen
            BE.numdoc = numdococ1.Text.Trim() + numdococ.Text.Trim();  // Correlativo de Cada Orden de Compra

            Tabladetallemov = BL.GetAll2(EmpresaID, BE).Tables[0];

            if (Tabladetallemov.Rows.Count > 0)
            {
                if (local == Tabladetallemov.Rows[0]["localdes"].ToString().Trim())
                {
                    #region *** Bloqueo Temporal

                    //foreach (DataRow fila in dt.Rows)
                    //{
                    //    tb_60local_stockBL BL2 = new tb_60local_stockBL();
                    //    tb_60local_stock BE2 = new tb_60local_stock();
                    //    DataTable dt2 = new DataTable();

                    //    BE2.moduloid = modulo;
                    //    BE2.productid = fila["productid"].ToString();

                    //    dt2 = BL2.GetAll(EmpresaID, BE2).Tables[0];

                    //    if (dt2.Rows.Count > 0)
                    //    {
                    //        if (almacaccionid.Trim() == "20" || almacaccionid.Trim() == "21")
                    //        {
                    //            lbl_valor.Text = "Cost.Prom";
                    //            xxprecventa = Convert.ToDecimal(dt2.Rows[0]["precventa"]);
                    //            xxcostopromed = Convert.ToDecimal(dt2.Rows[0]["costopromed"]);

                    //        }
                    //        else if (almacaccionid.Trim() == "10" || almacaccionid.Trim() == "11")
                    //        {
                    //            lbl_valor.Text = "Cost.Ultm";
                    //            xxcostoultimo = Convert.ToDecimal(dt2.Rows[0]["costoultimo"]);
                    //        }

                    //        xxstock = Convert.ToDecimal(dt2.Rows[0]["stock"]);
                    //    }

                    //    tipoperacionid.Text = "COMPRA";
                    //    row = Tabladetallemov.NewRow();
                    //    row["itemref"] = fila["itemref"].ToString();
                    //    row["items"] = fila["items"].ToString();
                    //    row["productid"] = fila["productid"].ToString().Trim();
                    //    row["productname"] = fila["productname"].ToString().Trim();
                    //    //row["rollo"] = fila["rollo"].ToString();

                    //    Decimal cantidad_c = Math.Round(Convert.ToDecimal(fila["cantidad_c"]), 4);
                    //    Decimal cantidadcta_c = Math.Round(Convert.ToDecimal(fila["cantidadcta_c"]), 4);

                    //    if (tipref.SelectedIndex != -1)
                    //    {
                    //        Decimal stock_old = Math.Round(Convert.ToDecimal(fila["cantidad_c"]), 4);
                    //        Decimal total = cantidad_c - cantidadcta_c;
                    //        row["stock_old"] = total;
                    //        row["stock"] = stock_old - total;
                    //    }
                    //    else
                    //    {
                    //        row["stock"] = xxstock;
                    //        row["stock_old"] = xxstock;
                    //    }

                    //    row["precventa"] = xxprecventa;
                    //    row["costoultimo"] = xxcostoultimo;
                    //    row["costopromed"] = xxcostopromed;

                    //    Decimal saldo;
                    //    saldo = cantidad_c - cantidadcta_c;
                    //    row["cantidad"] = saldo;
                    //    row["cantidad_old"] = Math.Round(Convert.ToDecimal(fila["cantidad"]), 4);
                    //    row["precunit"] = Math.Round(Convert.ToDecimal(Convert.ToDecimal(fila["precunit_c"]).ToString("###,###,##0.000000")), 6);
                    //    Decimal precunit = Math.Round(Convert.ToDecimal(Convert.ToDecimal(fila["precunit_c"]).ToString("###,###,##0.000000")), 6);
                    //    Decimal importe;
                    //    importe = cantidad_c * precunit;

                    //    row["importfac"] = importe;
                    //    row["valor"] = Math.Round(Convert.ToDecimal(fila["valor"]), 6);
                    //    row["importe"] = Math.Round(Convert.ToDecimal(fila["importe"]), 6);
                    //    row["totimpto"] = Math.Round(Math.Round(Convert.ToDecimal(fila["importe"]), 6) * (Convert.ToDecimal(18) / 100), 6);
                    //    row["almacaccionid"] = almacaccionid.Trim();
                    //    //row["ubicacion"] = fila["ubicacion"].ToString().Trim();
                    //    Tabladetallemov.Rows.Add(row);                        
                    //}
                    #endregion

                    griddetallemov.DataSource = Tabladetallemov;
                    //_RecalculoGrid();
                    calcular_totales();
                }
                else
                {
                    MessageBox.Show("    !!!... Informacion de la Orden ...!!! \n" +
                                    "\n » La Orden Todabia no ha Sido Generada " +
                                    "\n » O la Orden esta Generada en Otra Guia " +
                                    "\n\n »» Verifica Tus Ordenes Pendientes  ", "Localizando Orden", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    tipref.Enabled = true;
                    tipref.SelectedIndex = -1;
                    tipref.Enabled = true;
                    numdococ1.Text = Convert.ToString(DateTime.Today.Year);
                    numdococ.Text = "";
                    return;
                }
            }
        }


        private void ValidaCentroCosto(String xcencosid, Boolean retrn)
        {
            if (xcencosid.Trim().Length == 5)
            {
                tb_centrocostoBL BL = new tb_centrocostoBL();
                tb_centrocosto BE = new tb_centrocosto();
                DataTable dt = new DataTable();
                BE.cencosid = xcencosid.Trim();

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    cencosid.Text = dt.Rows[0]["cencosid"].ToString().Trim();
                    cencosname.Text = dt.Rows[0]["cencosname"].ToString().Trim();
                }
                else
                {
                    if (!retrn)
                    {
                        cencosid.Text = "";
                        cencosname.Text = "";
                        cencosid.Focus();
                    }
                }
            }
            else
            {
                cencosid.Text = "";
                cencosname.Text = "";
            }
        }

        private void ValidaPersona(String xPersonadni, Boolean retrn)
        {
            if (xPersonadni.Trim().Length > 0)
            {
                tb_co_persona_cencosBL BL = new tb_co_persona_cencosBL();
                tb_co_persona_cencosBE BE = new tb_co_persona_cencosBE();

                DataTable dt = new DataTable();

                BE.perdni = xPersonadni.Trim().ToString();
                BE.cencosid = cencosid.Text.ToString();
                BE.filtro = "2";

                dt = BL.GetDNI(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    vendperid.Text = dt.Rows[0]["nrodni"].ToString().Trim();
                    vendpername.Text = dt.Rows[0]["nombrelargo"].ToString().Trim();
                }
                else
                {
                    if (!retrn)
                    {
                        vendperid.Text = "";
                        vendpername.Text = "";
                        vendperid.Focus();
                    }
                }
            }
        }

        private void ValidaTransportista(String xtranspid, Boolean retrn)
        {
            if (xtranspid.Trim().Length > 0)
            {
                tb_transportistaBL BL = new tb_transportistaBL();
                tb_transportista BE = new tb_transportista();
                DataTable dt = new DataTable();
                BE.transpid = xtranspid.Trim();

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    transpid.Text = dt.Rows[0]["transpid"].ToString().Trim();
                    transpname.Text = dt.Rows[0]["transpname"].ToString().Trim();
                    transplicencia.Text = dt.Rows[0]["transplicencia"].ToString().Trim();
                    transpcertificado.Text = dt.Rows[0]["transpcertificado"].ToString().Trim();
                    transpplaca.Text = dt.Rows[0]["transpplaca"].ToString().Trim();
                }
                else
                {
                    if (!retrn)
                    {
                        transpid.Text = "";
                        transpname.Text = "";
                        transplicencia.Text = "";
                        transpcertificado.Text = "";
                        transpplaca.Text = "";
                        transpid.Focus();
                    }
                }
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
        //        if (GetNextControl(ActiveControl, true) != null)
        //        {
        //            //keyData.Handled = true;
        //            //MessageBox.Show(ActiveControl.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            //GetNextControl(ActiveControl, true).Focus();
        //            //SendKeys.Send("{TAB}");
        //            SendKeys.Send("\t");
        //            return true;
        //        }
        //    }

        //    return base.ProcessCmdKey(ref msg, keyData);
        //   // return false;
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
                    return Math.Round(Convert.ToDecimal(dt.Rows[0]["tipimptotasa"]), 0).ToString();
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
                Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql"; //sql,tabla
                frmayuda.titulo = "Ayuda Cliente/Proveedor (100 - PRIMEROS)";
                frmayuda.sqlquery = "select TOP 100 ctacte, ctactename, nmruc, direc from tb_cliente";
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

        private void AyudaClientesDireccion(String lpdescrlike)
        {
            try
            {
                Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all"; //sql,tabla
                frmayuda.titulo = "Ayuda Dirección";
                frmayuda.sqlquery = "select direcnume, direcname, direcdeta from tb_cliente_direc";
                frmayuda.sqlinner = ""; //inner
                frmayuda.sqlwhere = "where ctacte = '" + ctacte.Text.Trim() + "'"; //where
                frmayuda.sqland = "and";//and
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

        private void AyudaClientesDireccion2(String lpdescrlike)
        {
            try
            {
                Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all"; //sql,tabla
                frmayuda.titulo = "Ayuda Dirección";
                frmayuda.sqlquery = "select direcnume, direcname, direcdeta from tb_cliente_direc";
                frmayuda.sqlinner = ""; //inner
                frmayuda.sqlwhere = "where ctacte = '" + ((MERCADERIA.MainMercaderia)MdiParent).ctacte
                                + "' and direcnume != '" + ((MERCADERIA.MainMercaderia)MdiParent).direcnume + "'"; //where
                frmayuda.sqland = "and";//and
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
                lbllocal.Text = resultado1.Trim();
                direcnume = resultado1.Trim();
                direcname.Text = resultado2.Trim();
                direcdeta.Text = resultado3.Trim();
            }
        }

        private void AyudaDocref(String lpdescrlike)
        {
            try
            {
                Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql"; //sql,tabla
                frmayuda.titulo = "Ayuda Ordenes de compra";
                frmayuda.sqlquery = "select fechdoc, serdoc, numdoc, nmruc, ctactename, totpzas, totimporte from tb_cm_ordendecompracab tb1";
                frmayuda.sqlinner = ""; //inner
                frmayuda.sqlwhere = "where moduloiddes='" + modulo + "' and localdes='" + local + "' and tb1.tipodoc='OC' and status <> 9"; //where
                frmayuda.sqland = " and";//and
                frmayuda.criteriosbusqueda = new string[] { "CLIENTE", "RUC", "NÚMERO DOC" };
                frmayuda.columbusqueda = "ctactename,nmruc,numdoc";
                frmayuda.returndatos = "1,2,0";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeDocref;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RecibeDocref(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0 && resultado2.Trim().Length > 0)
            {
                serref.Text = resultado1.Trim();
                numdococ.Text = resultado2.Trim();
                ValidaDocref();
            }
        }

        private void AyudaOrdenProduccion(String lpdescrlike)
        {
            try
            {
                Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql"; //sql,tabla
                frmayuda.titulo = "Ayuda Orden de Produción";
                frmayuda.sqlquery = "select serdoc,numdoc,nmruc,ctactename,articname,fechdoc from tb_pp_ordenproduccioncab";
                frmayuda.sqlinner = ""; //inner
                frmayuda.sqlwhere = "where"; //where
                frmayuda.sqland = "";//and
                frmayuda.criteriosbusqueda = new string[] { "NÚMERO", "RUC", "CLIENTE", "ARTICULO" };
                frmayuda.columbusqueda = "numdoc,nmruc,ctactename,articname";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeOrdenProduccion;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RecibeOrdenProduccion(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                ser_op.Text = resultado1.Trim();
                num_op.Text = resultado2.Trim();
            }
        }

        private void AyudaCentroCosto(String lpdescrlike)
        {
            try
            {
                Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql"; //sql,tabla
                frmayuda.titulo = "Ayuda Centro de Costo";
                frmayuda.sqlquery = "select cencosid, cencosname From tb_centrocosto where cencosdivi = 2 ";
                frmayuda.sqlinner = ""; //inner
                frmayuda.sqlwhere = ""; //where
                frmayuda.sqland = "and";//and
                frmayuda.criteriosbusqueda = new string[] { "CENTRO COSTO", "CÓDIGO" };
                frmayuda.columbusqueda = "cencosname,cencosid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeCentroCosto;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RecibeCentroCosto(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                cencosid.Text = resultado1.Trim();
                cencosname.Text = resultado2.Trim();
            }
        }

        private void AyudaOrdenCompra(String lpdescrlike)
        {
            try
            {
                Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql"; //sql,tabla
                frmayuda.titulo = "Ayuda Vendedor";
                frmayuda.sqlquery = "select vendorid, vendorname from tb_vendedor_corporativo";
                frmayuda.sqlinner = ""; //inner
                frmayuda.sqlwhere = "where"; //where
                frmayuda.sqland = "";//and
                frmayuda.criteriosbusqueda = new string[] { "VENDEDOR", "CÓDIGO" };
                frmayuda.columbusqueda = "vendorname,vendorid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeOrdenCompra;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        private void RecibeOrdenCompra(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                vendperid.Text = resultado1.Trim();
                vendpername.Text = resultado2.Trim();
            }
        }





        private void AyudaPersonal(String lpdescrlike)
        {
            try
            {
                Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql"; //sql,tabla
                frmayuda.titulo = "Ayuda Vendedor";
                frmayuda.sqlquery = "select nrodni,nombrelargo from tb_plla_fichatrabajadores ";
                frmayuda.sqlinner = ""; //inner
                frmayuda.sqlwhere = "where cencosid = '" + cencosid.Text.ToString() + "' "; //where
                frmayuda.sqland = "and";//and
                frmayuda.criteriosbusqueda = new string[] { "NOMBRE", "DNI" };
                frmayuda.columbusqueda = "nombrelargo,nrodni";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibePer_O_Vend;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RecibePer_O_Vend(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                vendperid.Text = resultado1.Trim();
                vendpername.Text = resultado2.Trim();
            }
        }

        private void AyudaTransportista(String lpdescrlike)
        {
            try
            {
                Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql"; //sql,tabla
                frmayuda.titulo = "Ayuda Transportista";
                frmayuda.sqlquery = "select transpid,transpname,transpplaca,transpcertificado,transplicencia from tb_transportista";
                frmayuda.sqlinner = ""; //inner
                frmayuda.sqlwhere = "where"; //where
                frmayuda.sqland = "";//and
                frmayuda.criteriosbusqueda = new string[] { "NOM TRANSPORTISTA", "CÓDIGO" };
                frmayuda.columbusqueda = "transpname,transpid";
                frmayuda.returndatos = "0,1,2,3,4";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeTransportista;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        private void RecibeTransportista(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                transpid.Text = resultado1.Trim();
                transpname.Text = resultado2.Trim();
                transpplaca.Text = resultado3.Trim();
                transpcertificado.Text = resultado4.Trim();
                transplicencia.Text = resultado5.Trim();
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

                BE.dominioid = dominio;
                BE.moduloid = modulo;
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();
                        Ayudas.Form_help_gridproducto_vlx frmayuda = new Ayudas.Form_help_gridproducto_vlx();

                        frmayuda.tipoo = "sql"; //sql,tabla
                        frmayuda.titulo = "<< AYUDA PRODUCTO (100 - PRIMEROS)>>";
                        frmayuda.sqlquery = " Select TOP 100 tb1.productid, tb1.productname,tb1.unmed,tb2.stock, tb2.costoultimo as precventa, tb2.[local],li.nostock From tb_me_productos tb1 ";
                        frmayuda.sqlinner = " Left Join tb_me_local_stock tb2 on tb1.moduloid=tb2.moduloid and tb1.productid = tb2.productid " +
                                            " LEFT join tb_me_linea li on tb1.lineaid = li.lineaid and tb1.moduloid = li.moduloid "; //inner
                        //frmayuda.sqlinner = "left join tb_" + modd + "_local_stock tb2 on tb1.moduloid=tb2.moduloid and tb1.productid=tb2.productid"; //inner
                        frmayuda.sqlwhere = "where tb2.moduloid ='" + modulo + "'  AND local ='" + local + "'";
                        frmayuda.sqland = "and";//and
                        frmayuda.criteriosbusqueda = new string[] { "PRODUCTO", "CODIGO" };
                        frmayuda.columbusqueda = "tb1.productname,tb1.productid";
                        frmayuda.returndatos = "0,1,2";

                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeProductoRollo;
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RecibeProductoRollo(DataTable dtresultado)
        {
            try
            {
                if (dtresultado.Rows.Count > 0)
                {

                    int cont = 0;

                    foreach (DataRow fila in dtresultado.Rows)
                    {
                        cont = cont + 1;
                        if (this.griddetallemov.Rows.Count > 0)
                        {
                            int nFilaAnt = griddetallemov.RowCount - 1;
                            String xProductid = fila["productid"].ToString();
                            String xProductname = fila["productname"].ToString();
                            String xunmed = fila["unmed"].ToString();
                            xnostock = Convert.ToBoolean(fila["nostock"].ToString());


                            if (cont > 1)
                            {
                                this.Tabladetallemov.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetallemov));
                                Tabladetallemov.Rows[this.Tabladetallemov.Rows.Count - 1]["items"] = VariablesPublicas.CalcMaxField(this.Tabladetallemov, "items", 5);
                                this.griddetallemov.Rows[nFilaAnt + 1].Cells["productid"].Value = xProductid;
                                this.griddetallemov.Rows[nFilaAnt + 1].Cells["productname"].Value = xProductname;
                                this.griddetallemov.Rows[nFilaAnt + 1].Cells["nostock"].Value = xnostock;
                            }
                            else
                            {
                                this.griddetallemov.Rows[nFilaAnt].Cells["productid"].Value = xProductid;
                                this.griddetallemov.Rows[nFilaAnt].Cells["productname"].Value = xProductname;
                                this.griddetallemov.Rows[nFilaAnt].Cells["unmed"].Value = xunmed;
                                this.griddetallemov.Rows[nFilaAnt].Cells["nostock"].Value = xnostock;
                            }

                            this.griddetallemov.CurrentCell = this.griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["cantidad"];
                            this.griddetallemov.BeginEdit(true);
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

        #endregion

        #region *** Metodos mantenimiento de datos

        private void SEGURIDAD_LOG(String accion)
        {
            String xclave = VariablesPublicas.EmpresaID + "-" + modulo + "-" + tipodoc.Text.Trim() + "-" + serdoc.Text.Trim() + "-" + numdoc.Text.Trim();
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
                BE.detalle = tipodoc.Text.Trim() + "-" + serdoc.Text.Trim() + "-" + numdoc.Text.Trim() + "/" + XGLOSA;

                BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region *** Limpiar_Doc

        private void limpiar_documento()
        {
            try
            {
                NIVEL_FORMS();

                tipimptoid = "";
                direcnume = "";
                incprec = "N";
                ssModo = "NEW";

                numdococ1.Text = VariablesPublicas.perianio;

                //fechdoc.Text = DateTime.Today.ToString("d");
                fechdoc.Text = DateTime.Today.ToShortDateString();
                moneda.SelectedValue = "S";
                tcamb.Text = "1";
                tipimptotasa.Text = "";
                ctacte.Text = "";
                lbllocal.Text = "";

                nmruc.Text = "";
                ctactename.Text = "";
                direc.Text = "";
                mottrasladointid.SelectedIndex = -1;
                direcname.Text = "";
                direcdeta.Text = "";
                tipoperacionid.SelectedIndex = -1;
                motivotrasladoid.SelectedIndex = -1;
                tipref.DataSource = null;
                serref.Text = modulo;
                numdococ.Text = "";
                fechref.Text = DateTime.Today.ToShortDateString();

                tipfac.SelectedIndex = 0;
                serfac.Text = "";
                numfac.Text = "";
                fechfac.Text = DateTime.Today.ToShortDateString();

                tipguia.Text = "GR";
                serguia.Text = "";
                numguia.Text = "";
                fechguia.Text = DateTime.Today.ToShortDateString();

                tipnotac.Text = "NC";
                sernotac.Text = "";
                numnotac.Text = "";
                fechnotac.Text = DateTime.Today.ToShortDateString();

                ser_op.Text = "";
                num_op.Text = "";
                cencosid.Text = "";
                cencosname.Text = "";
                vendperid.Text = "";
                vendpername.Text = "";
                fechentrega.Text = DateTime.Today.ToShortDateString();

                fechpago.Text = DateTime.Today.ToShortDateString();

                transpid.Text = "";
                transpname.Text = "";
                transpplaca.Text = "";
                transpcertificado.Text = "";
                transplicencia.Text = "";
                ddnni.Text = "";
                ddnniname.Text = "";
                itemsT.Text = "0";
                totpzas.Text = "0";
                bruto.Text = "0";
                totdscto1.Text = "0";
                valventa.Text = "0";
                totimpto.Text = "0";

                totimporte.Text = "0";
                txt_valor.Text = "0";
                txt_stock.Text = "0";

                //data_Tabladetallemovmov();
                data_Tabladetallemovmov();

                glosa.Text = "";
                txt_status.Text = "";
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.Write(ex.ToString());
            }
        }


        private void Blanquear()
        {
            try
            {
                NIVEL_FORMS();
                tipimptoid = "";
                direcnume = "";
                incprec = "N";
                ssModo = "NEW";
                numdococ1.Text = VariablesPublicas.perianio;
                //fechdoc.Text = DateTime.Today.ToString("d");
                moneda.SelectedValue = "S";
                tcamb.Text = "1";
                tipimptotasa.Text = "";
                ctacte.Text = "";
                lbllocal.Text = "";
                nmruc.Text = "";
                ctactename.Text = "";
                direc.Text = "";
                mottrasladointid.SelectedIndex = -1;
                direcname.Text = "";
                direcdeta.Text = "";
                tipoperacionid.SelectedIndex = -1;
                motivotrasladoid.SelectedIndex = -1;
                tipref.DataSource = null;
                serref.Text = modulo;
                numdococ.Text = "";
                fechref.Text = "";
                fechref.CustomFormat = " ";
                fechref.Format = DateTimePickerFormat.Custom;
                tipfac.SelectedIndex = 0;
                serfac.Text = "";
                numfac.Text = "";
                tipguia.Text = "GR";
                serguia.Text = "";
                numguia.Text = "";
                tipnotac.Text = "NC";
                sernotac.Text = "";
                numnotac.Text = "";
                ser_op.Text = "";
                num_op.Text = "";
                cencosid.Text = "";
                cencosname.Text = "";
                vendperid.Text = "";
                vendpername.Text = "";
                fechentrega.Text = "";
                fechentrega.CustomFormat = " ";
                fechentrega.Format = DateTimePickerFormat.Custom;
                fechpago.Text = "";
                fechpago.CustomFormat = " ";
                fechpago.Format = DateTimePickerFormat.Custom;
                transpid.Text = "";
                transpname.Text = "";
                transpplaca.Text = "";
                transpcertificado.Text = "";
                transplicencia.Text = "";
                ddnni.Text = "";
                ddnniname.Text = "";
                itemsT.Text = "0";
                totpzas.Text = "0";
                bruto.Text = "0";
                totdscto1.Text = "0";
                valventa.Text = "0";
                totimpto.Text = "0";
                totimporte.Text = "0";
                txt_valor.Text = "0";
                txt_stock.Text = "0";
                if (Tabladetallemov.Rows.Count > 0)
                {
                    Tabladetallemov.Rows.Clear();
                    griddetallemov.DataSource = Tabladetallemov;
                }
                glosa.Text = "";
                txt_status.Text = "";
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }


        #endregion

        private void calcular_totales()
        {
            decimal stotal = 0;
            if (Tabladetallemov != null)
            {
                _cal_Igv();

                if (Tabladetallemov.Rows.Count != 0)
                {
                    //Calcular total items
                    itemsT.Text = Tabladetallemov.Rows.Count.ToString();
                    //Calcular total piezas
                    totpzas.Text = Convert.ToDecimal(Tabladetallemov.Compute("sum(cantidad)", "")).ToString("##,###,##0.00");
                    //Calcular total bruto
                    bruto.Text = Math.Round(Convert.ToDecimal(Tabladetallemov.Compute("sum(importfac)", "")), 2).ToString("##,###,##0.00");

                    //obteniendo el importfac
                    stotal = Math.Round(Convert.ToDecimal(Tabladetallemov.Compute("sum(importfac)", "")), 2);
                    if (incprec == "S")
                    {
                        //calcular valor de venta
                        valventa.Text = Math.Round(stotal * (100 / (100 + igv)), 2).ToString("###,###,##0.00");
                        //Calcular impuesto
                        totimpto.Text = Math.Round(stotal * (100 / (100 + igv)) * (igv / 100), 2).ToString("###,###,##0.00");
                        //Calcular total a pagar
                        totimporte.Text = stotal.ToString("###,###,##0.00");
                    }
                    else
                    {
                        //valventa.Text = Math.Round(Convert.ToDecimal(Tabladetallemov.Compute("sum(importfac)", "")), 4).ToString("###,###,##0.00");
                        ////Calcular impuesto
                        //totimpto.Text = Math.Round(Convert.ToDecimal(Tabladetallemov.Compute("sum(totimpto)", "")), 4).ToString("###,###,##0.00");
                        ////Calcular total a pagar
                        //totimporte.Text = Math.Round(Convert.ToDecimal(valventa.Text) + Convert.ToDecimal(totimpto.Text), 4).ToString("###,###,##0.00");
                        //calcular valor de venta
                        valventa.Text = stotal.ToString("###,###,##0.00");
                        //Calcular impuesto
                        totimpto.Text = Math.Round(stotal * (igv / 100), 2).ToString("###,###,##0.00");
                        //Calcular total a pagar                    
                        totimporte.Text = Math.Round(stotal + (stotal * (igv / 100)), 2).ToString("###,###,##0.00");
                    }
                }
                else
                {
                    //Calcular total items
                    itemsT.Text = Tabladetallemov.Rows.Count.ToString();
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
            tipodoc.SelectedIndex = 0;
            limpiar_documento();
            form_bloqueado(false);
            //get_val_fechadoc();
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_barcode.Enabled = true;
            btn_detanadir.Enabled = true;
            btn_deteliminar.Enabled = true;
            btn_attachedfile.Enabled = true;

            ssModo = "NEW";
            tabdatos.SelectedIndex = 0;
            serdoc.Enabled = false;
            numdoc.Enabled = false;
            numdococ.Enabled = false;
            //numdococ1.Enabled = false;

        }


        private void nuevo_fijado()
        {
            //tipodoc.SelectedIndex = 0;
            limpiar_documento();
            form_bloqueado(false);
            get_val_fechadoc();
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_barcode.Enabled = true;
            btn_detanadir.Enabled = true;
            btn_deteliminar.Enabled = true;
            btn_attachedfile.Enabled = true;

            ssModo = "NEW";
            tabdatos.SelectedIndex = 0;
            serdoc.Enabled = false;
            numdoc.Enabled = false;
            numdococ.Enabled = false;
            //numdococ1.Enabled = false;

        }

        private bool cabecera_valida()
        {
            bool lSigo = true;

            if (ctacte.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese Proveedor/Cliente !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lSigo = false;
            }
            if (Tabladetallemov.Rows.Count == 0)
            {
                MessageBox.Show("Documento no tiene Items !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lSigo = false;
            }
            if (!_ValidaDocuOP())
            {
                ser_op.Text = "";
                num_op.Text = "";
                lSigo = false;
            }
            if (!_ValidaMotivoContable())
            {
                MessageBox.Show("Seleccione Motivo Contable !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lSigo = false;
            }
            if (!_ValidaDirecNume())
            {
                MessageBox.Show("Seleccione Una Direccion !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void Insert()
        {
            _cal_Igv();
            try
            {
                if (cabecera_valida())
                {

                    // Variables de Cabecera
                    tb_me_movimientosBL BL = new tb_me_movimientosBL();
                    tb_me_movimientos BE = new tb_me_movimientos();

                    // Variables para Detalle
                    tb_me_movimientos.Item Detalle = new tb_me_movimientos.Item();
                    List<tb_me_movimientos.Item> ListaItems = new List<tb_me_movimientos.Item>();

                    #region **ingreso movimiento cabecera***
                    BE.dominioid = dominio;
                    BE.moduloid = modulo;
                    BE.local = local;
                    BE.tipodoc = tipodoc.SelectedValue.ToString();
                    BE.serdoc = serdoc.Text.Trim();
                    BE.numdoc = numdoc.Text.ToString();
                    BE.fechdoc = Convert.ToDateTime(fechdoc.Text);
                    BE.moneda = moneda.SelectedValue.ToString().Trim();
                    BE.tcamb = Convert.ToDecimal(tcamb.Text.Trim());
                    //accion del alamacen dependiendo del tipo de documento

                    if (tipfac.Text.Trim().Length > 0 && serfac.Text.Trim().Length > 0 && numfac.Text.Trim().Length > 0)
                    {
                        if (almacaccionid.Substring(0, 1) == "2")
                        {
                            almacaccionid = "21";
                        }
                        BE.almacaccionid = almacaccionid.ToString();
                    }
                    else { BE.almacaccionid = almacaccionid.Trim(); }

                    BE.tipoperacionid = tipoperacionid.SelectedValue.ToString();
                    //datos proveedor y/o cliente
                    BE.ctacteaccionid = "";
                    BE.ctacte = ctacte.Text.Trim().ToUpper();
                    BE.nmruc = nmruc.Text.Trim();
                    BE.ctactename = ctactename.Text.Trim().ToUpper();
                    BE.direc = direc.Text.Trim().ToUpper();
                    BE.direcnume = direcnume.Trim().ToUpper();
                    BE.direcname = direcname.Text.Trim().ToUpper();
                    BE.direcdeta = direcdeta.Text.Trim().ToUpper();
                    //datos documento de referencia
                    if (tipref.SelectedValue != null && serref.Text.Trim().Length > 0)
                    {
                        if (tipref.SelectedValue.ToString() == "OC")
                        {
                            BE.tipref = tipref.SelectedValue.ToString();
                            BE.serref = serref.Text.Trim().PadLeft(4, '0');

                            BE.numref = numdococ1.Text.Trim() + numdococ.Text.Trim().PadLeft(6, '0');

                            try { BE.fechref = Convert.ToDateTime(fechref.Text.Trim()); }
                            catch { BE.fechref = Convert.ToDateTime("01/01/1900"); }
                        }
                        else if (tipref.SelectedValue.ToString() == "SO")
                        {
                            BE.tipref = "";
                            BE.serref = "";
                            BE.numref = "";
                            try { BE.fechref = Convert.ToDateTime(fechref.Text.Trim()); }
                            catch { BE.fechref = Convert.ToDateTime("01/01/1900"); }
                        }
                    }
                    //orden de produccion
                    if (ser_op.Text.Trim().Length > 0 && num_op.Text.Trim().Length > 0)
                    {
                        BE.tip_op = "OP";
                        BE.ser_op = ser_op.Text.Trim().PadLeft(4, '0');
                        BE.num_op = num_op.Text.Trim().PadLeft(10, '0');
                    }
                    //datos ducumento factura
                    if (serfac.Text.Trim().Length > 0 && numfac.Text.Trim().Length > 0)
                    {
                        BE.tipfac = tipfac.SelectedItem.ToString();
                        BE.serfac = serfac.Text.Trim().ToString().PadLeft(4, '0');
                        BE.numfac = numfac.Text.Trim().ToString().PadLeft(10, '0');
                        try { BE.fechfac = Convert.ToDateTime(fechfac.Text.Trim()); }
                        catch { BE.fechfac = Convert.ToDateTime("01/01/1900"); }
                    }
                    //datos ducumento guia
                    if (serguia.Text.Trim().Length > 0 && numguia.Text.Trim().Length > 0)
                    {
                        BE.tipguia = tipguia.Text.Trim();
                        BE.serguia = serguia.Text.Trim().ToString().PadLeft(4, '0');
                        BE.numguia = numguia.Text.Trim().ToString().PadLeft(10, '0');
                        try { BE.fechguia = Convert.ToDateTime(fechguia.Text.Trim()); }
                        catch { BE.fechguia = Convert.ToDateTime("01/01/1900"); }
                    }
                    //datos ducumento nota de credito
                    if (sernotac.Text.Trim().Length > 0 && numnotac.Text.Trim().Length > 0)
                    {
                        BE.tipnotac = tipnotac.Text.Trim();
                        BE.sernotac = sernotac.Text.Trim().ToString().PadLeft(4, '0');
                        BE.numnotac = numnotac.Text.Trim().ToString().PadLeft(10, '0');
                        try { BE.fechnotac = Convert.ToDateTime(fechnotac.Text.Trim()); }
                        catch { BE.fechnotac = Convert.ToDateTime("01/01/1900"); }
                    }
                    //datos empleado vendedor
                    //if (vendperid.Text.Trim().Length > 0) { BE.vendorid = vendperid.Text.Trim().ToString(); };
                    if (vendperid.Text.Trim().Length > 0) { BE.perdni = vendperid.Text.Trim().ToString(); };  // modificado
                    //datos ubigeo
                    BE.ubige = "000000";
                    //datos centro de costo
                    BE.cencosid = cencosid.Text.Trim().ToString();
                    //datos condicion de pago
                    //BE.condpago = condventa.SelectedValue.Trim().ToString();
                    //datos gastos varios
                    try { BE.totdscto1 = Convert.ToDecimal(totdscto1.Text.Trim()); }
                    catch { BE.totdscto1 = Convert.ToDecimal(0); }
                    //Try { BE.transporte = Convert.ToDecimal(transporte.Text.Trim()); }
                    //Catch { BE.transporte = Convert.ToDecimal(0); }
                    //Try { BE.embalaje = Convert.ToDecimal(embalaje.Text.Trim()); }
                    //Catch { BE.embalaje = Convert.ToDecimal(0); }
                    //Try { BE.otros = Convert.ToDecimal(otros.Text.Trim()); }
                    //Catch { BE.otros = Convert.ToDecimal(0); }
                    //Tipo de impuesto
                    BE.tipimptoid = tipimptotasa.SelectedValue.ToString().Trim();
                    //Datos incluido IGV
                    BE.incprec = incprec.Trim();
                    //Datos tipo periodo impuesto
                    //BE.tipoperimptoid = "";
                    //Datos totales calculados
                    BE.items = Convert.ToDecimal(itemsT.Text.Trim());
                    BE.totpzas = Convert.ToDecimal(totpzas.Text.Trim());
                    BE.bruto = Convert.ToDecimal(bruto.Text.Trim());
                    BE.igv = igv;
                    BE.totimpto = Convert.ToDecimal(totimpto.Text.Trim());
                    BE.valventa = Convert.ToDecimal(valventa.Text.Trim());
                    BE.totimporte = Convert.ToDecimal(totimporte.Text.Trim());
                    //Datos cuenta haber y debe 
                    BE.codctadebe = "";
                    BE.codctahaber = "";
                    //Datos glosa
                    BE.glosa = glosa.Text.Trim().ToUpper().ToString();
                    //Fechas de movimiento del documento
                    try { BE.fechcancel = Convert.ToDateTime("01/01/1900"); }
                    catch { BE.fechcancel = Convert.ToDateTime("01/01/1900"); }
                    try { BE.fechentrega = Convert.ToDateTime(fechentrega.Text.Trim()); }
                    catch { BE.fechentrega = Convert.ToDateTime("01/01/1900"); }
                    try { BE.fechpago = Convert.ToDateTime(fechpago.Text.Trim()); }
                    catch { BE.fechpago = Convert.ToDateTime("01/01/1900"); }

                    //Datos transporte
                    BE.transpid = transpid.Text.Trim().ToString();
                    if (motivotrasladoid.SelectedValue != null)
                        BE.motivotrasladoid = motivotrasladoid.SelectedValue.ToString();
                    if (mottrasladointid.SelectedValue != null)
                        BE.mottrasladointid = mottrasladointid.SelectedValue.ToString();
                    //Datos cliente y/o empleado
                    BE.ddnni = ddnni.Text.Trim();
                    //Otros
                    BE.tipdid = "";
                    BE.statborrado = "";
                    BE.clientetipo = "";
                    BE.modofactu = "";
                    //opt
                    BE.tipodocmanejaserie = tipodocmanejaserie;

                    //Datos de usuario
                    Detalle.perianio = fechdoc.Value.Year.ToString();
                    Detalle.perimes = fechdoc.Value.Month.ToString().PadLeft(2, '0');
                    Detalle.status = "0";
                    Detalle.usuar = VariablesPublicas.Usuar;

                    #endregion

                    #region ****ingreso movimiento detalle***
                    int item = 0;
                    foreach (DataRow fila in Tabladetallemov.Rows)
                    {
                        Detalle = new tb_me_movimientos.Item();

                        item++;

                        //datos documento cabecera importante [todos]
                        Detalle.fechdoc = Convert.ToDateTime(fechdoc.Text);
                        Detalle.moneda = moneda.SelectedValue.ToString().Trim();
                        Detalle.tcamb = Convert.ToDecimal(tcamb.Text.Trim());
                        //accion del alamacen dependiendo del tipo de documento
                        Detalle.tipoperacionid = tipoperacionid.SelectedValue.ToString();
                        //datos proveedor y/o cliente
                        Detalle.ctacteaccionid = "";
                        Detalle.ctacte = ctacte.Text.Trim().ToUpper();
                        Detalle.ctactename = ctactename.Text.Trim().ToUpper();
                        Detalle.direcnume = direcnume.Trim().ToUpper();
                        Detalle.direcname = direcname.Text.Trim().ToUpper();
                        //datos documento de referencia
                        if (tipref.SelectedValue != null && serref.Text.Trim().Length > 0)
                        {
                            Detalle.tipref = tipref.SelectedValue.ToString();
                            Detalle.serref = serref.Text.Trim().PadLeft(4, '0');
                            Detalle.numref = numdococ1.Text.Trim() + numdococ.Text.Trim().PadLeft(6, '0');
                            try { Detalle.fechref = Convert.ToDateTime(fechref.Text.Trim()); }
                            catch { Detalle.fechref = Convert.ToDateTime("01/01/1900"); }
                        }
                        //orden de produccion
                        if (ser_op.Text.Trim().Length > 0 && num_op.Text.Trim().Length > 0)
                        {
                            Detalle.tip_op = "OP";
                            Detalle.ser_op = ser_op.Text.Trim().PadLeft(4, '0');
                            Detalle.num_op = num_op.Text.Trim().PadLeft(10, '0');
                        }
                        //datos ducumento factura
                        if (serfac.Text.Trim().Length > 0 && numfac.Text.Trim().Length > 0)
                        {
                            Detalle.tipfac = tipfac.SelectedItem.ToString();
                            Detalle.serfac = serfac.Text.Trim().ToString().PadLeft(4, '0');
                            Detalle.numfac = numfac.Text.Trim().ToString().PadLeft(10, '0');
                            try { Detalle.fechfac = Convert.ToDateTime(fechfac.Text.Trim()); }
                            catch { Detalle.fechfac = Convert.ToDateTime("01/01/1900"); }
                        }
                        //datos ducumento guia
                        if (serguia.Text.Trim().Length > 0 && numguia.Text.Trim().Length > 0)
                        {
                            Detalle.tipguia = tipguia.Text.Trim();
                            Detalle.serguia = serguia.Text.Trim().ToString().PadLeft(4, '0');
                            Detalle.numguia = numguia.Text.Trim().ToString().PadLeft(10, '0');
                            try { Detalle.fechguia = Convert.ToDateTime(fechguia.Text.Trim()); }
                            catch { Detalle.fechguia = Convert.ToDateTime("01/01/1900"); }
                        }
                        //datos ducumento nota de credito
                        if (sernotac.Text.Trim().Length > 0 && numnotac.Text.Trim().Length > 0)
                        {
                            Detalle.tipnotac = tipnotac.Text.Trim();
                            Detalle.sernotac = sernotac.Text.Trim().ToString().PadLeft(4, '0');
                            Detalle.numnotac = numnotac.Text.Trim().ToString().PadLeft(10, '0');
                            try { Detalle.fechnotac = Convert.ToDateTime(fechnotac.Text.Trim()); }
                            catch { Detalle.fechnotac = Convert.ToDateTime("01/01/1900"); }
                        }
                        //centro de costo
                        Detalle.cencosid = cencosid.Text.Trim();
                        //empleado vendedor
                        if (vendperid.Text.Trim().Length > 0)
                        {

                            BE.vendorid = vendperid.Text.Trim().ToString();
                        };

                        //datos calculados de detalle de movimiento obtenidos de memoria
                        Detalle.itemref = "";//fila["itemref"].ToString();
                        Detalle.itemsdet = item.ToString().PadLeft(5, '0');
                        Detalle.rollo = "";//fila["rollo"].ToString();
                        Detalle.productid = fila["productid"].ToString();
                        Detalle.productname = fila["productname"].ToString();
                        Detalle.Ubicacion = "";//fila["ubicacion"].ToString();
                        Detalle.unmed = fila["unmed"].ToString();
                        Detalle.nserie = fila["nserie"].ToString().Trim();

                        Detalle.cantidad = Convert.ToDecimal(fila["cantidad"].ToString());
                        Detalle.valor = Convert.ToDecimal(fila["valor"].ToString()); // Siempre: Moneda Nacional
                        Detalle.importe = Convert.ToDecimal(fila["importe"].ToString()); // Siempre: Moneda Nacional
                        Detalle.precunit = Convert.ToDecimal(fila["precunit"].ToString());  // Moneda de Transacción           
                        Detalle.importfac = Convert.ToDecimal(fila["importfac"].ToString()); // Moneda de Transacción
                        Detalle.totimpto = Convert.ToDecimal(fila["totimpto"].ToString()); // Moneda de Transacción (Impuesto)

                        //accion del alamacen dependiendo del tipo de documento
                        Detalle.almacaccionid = almacaccionid;// fila["almacaccionid"].ToString();
                        //motivo del traslado
                        if (motivotrasladoid.SelectedValue != null)
                            Detalle.motivotrasladoid = motivotrasladoid.SelectedValue.ToString();
                        if (mottrasladointid.SelectedValue != null)
                            Detalle.mottrasladointid = mottrasladointid.SelectedValue.ToString();
                        //datos de costo promedio
                        Detalle.statcostopromed = statcostopromed.Trim();
                        //datos de tipo de trasaccion
                        Detalle.tiptransac = tiptransac.Trim();
                        //datos si es incluido IGV
                        Detalle.incprec = incprec.Trim();
                        Detalle.igv = igv;
                        //glosa - observacion
                        Detalle.glosa = glosa.Text.Trim().ToUpper().ToString();
                        //dato cuenta haber y debe 
                        Detalle.codctadebe = "";
                        Detalle.codctahaber = "";

                        //dato de usuario
                        Detalle.perianio = fechdoc.Value.Year.ToString();
                        Detalle.perimes = fechdoc.Value.Month.ToString().PadLeft(2, '0');
                        Detalle.status = "0";
                        Detalle.usuar = VariablesPublicas.Usuar;

                        //if (fila["productid"].ToString().Trim().Length == 13 && Convert.ToDecimal(fila["cantidad"]) > 0 && Convert.ToDecimal(fila["importfac"]) > 0)
                        //{
                        ListaItems.Add(Detalle);
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Documento DETALLE EN FORMATO INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    return;
                        //}

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
                        //MessageBox.Show("Datos Grabados Correctamente !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Blanquear();
                        form_bloqueado(false);
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
                    #endregion
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

                    // Variables de Cabecera
                    tb_me_movimientosBL BL = new tb_me_movimientosBL();
                    tb_me_movimientos BE = new tb_me_movimientos();

                    // Variables para Detalle
                    tb_me_movimientos.Item Detalle = new tb_me_movimientos.Item();
                    List<tb_me_movimientos.Item> ListaItems = new List<tb_me_movimientos.Item>();

                    #region **ingreso movimiento cabecera***
                    BE.dominioid = dominio;
                    BE.moduloid = modulo;
                    BE.local = local;
                    BE.tipodoc = tipodoc.SelectedValue.ToString();
                    BE.serdoc = serdoc.Text.Trim();
                    BE.numdoc = numdoc.Text.Trim();
                    BE.fechdoc = Convert.ToDateTime(fechdoc.Text);
                    BE.moneda = moneda.SelectedValue.ToString().Trim();
                    BE.tcamb = Convert.ToDecimal(tcamb.Text.Trim());

                    //accion del alamacen dependiendo del tipo de documento
                    if (tipfac.Text.Trim().Length > 0 && serfac.Text.Trim().Length > 0 && numfac.Text.Trim().Length > 0)
                    {
                        if (almacaccionid.Substring(0, 1) == "2")
                        {
                            almacaccionid = "21";
                        }
                        BE.almacaccionid = almacaccionid.ToString();
                    }
                    else { BE.almacaccionid = almacaccionid.Trim(); }

                    BE.tipoperacionid = tipoperacionid.SelectedValue.ToString();
                    //datos proveedor y/o cliente
                    BE.ctacteaccionid = "";
                    BE.ctacte = ctacte.Text.Trim().ToUpper();
                    BE.nmruc = nmruc.Text.Trim();
                    BE.ctactename = ctactename.Text.Trim().ToUpper();
                    BE.direc = direc.Text.Trim().ToUpper();
                    BE.direcnume = direcnume.Trim().ToUpper();
                    BE.direcname = direcname.Text.Trim().ToUpper();
                    BE.direcdeta = direcdeta.Text.Trim().ToUpper();
                    //datos documento de referencia
                    if (tipref.SelectedValue != null && serref.Text.Trim().Length > 0)
                    {
                        if (tipref.SelectedValue.ToString() == "OC")
                        {
                            BE.tipref = tipref.SelectedValue.ToString();
                            BE.serref = serref.Text.Trim().PadLeft(4, '0');

                            BE.numref = numdococ1.Text.Trim() + numdococ.Text.Trim().PadLeft(6, '0');

                            try { BE.fechref = Convert.ToDateTime(fechref.Text.Trim()); }
                            catch { BE.fechref = Convert.ToDateTime("01/01/1900"); }
                        }
                        else if (tipref.SelectedValue.ToString() == "SO")
                        {
                            BE.tipref = "";
                            BE.serref = "";
                            BE.numref = "";
                            try { BE.fechref = Convert.ToDateTime(fechref.Text.Trim()); }
                            catch { BE.fechref = Convert.ToDateTime("01/01/1900"); }
                        }
                    }
                    //orden de produccion
                    if (ser_op.Text.Trim().Length > 0 && num_op.Text.Trim().Length > 0)
                    {
                        BE.tip_op = "OP";
                        BE.ser_op = ser_op.Text.Trim().PadLeft(4, '0');
                        BE.num_op = num_op.Text.Trim().PadLeft(10, '0');
                    }
                    //datos ducumento factura
                    if (serfac.Text.Trim().Length > 0 && numfac.Text.Trim().Length > 0)
                    {
                        BE.tipfac = tipfac.SelectedItem.ToString();
                        BE.serfac = serfac.Text.Trim().ToString().PadLeft(4, '0');
                        BE.numfac = numfac.Text.Trim().ToString().PadLeft(10, '0');
                        try { BE.fechfac = Convert.ToDateTime(fechfac.Text.Trim()); }
                        catch { BE.fechfac = Convert.ToDateTime("01/01/1900"); }
                    }
                    //datos ducumento guia
                    if (serguia.Text.Trim().Length > 0 && numguia.Text.Trim().Length > 0)
                    {
                        BE.tipguia = tipguia.Text.Trim();
                        BE.serguia = serguia.Text.Trim().ToString().PadLeft(4, '0');
                        BE.numguia = numguia.Text.Trim().ToString().PadLeft(10, '0');
                        try { BE.fechguia = Convert.ToDateTime(fechguia.Text.Trim()); }
                        catch { BE.fechguia = Convert.ToDateTime("01/01/1900"); }
                    }
                    //datos ducumento nota de credito
                    if (sernotac.Text.Trim().Length > 0 && numnotac.Text.Trim().Length > 0)
                    {
                        BE.tipnotac = tipnotac.Text.Trim();
                        BE.sernotac = sernotac.Text.Trim().ToString().PadLeft(4, '0');
                        BE.numnotac = numnotac.Text.Trim().ToString().PadLeft(10, '0');
                        try { BE.fechnotac = Convert.ToDateTime(fechnotac.Text.Trim()); }
                        catch { BE.fechnotac = Convert.ToDateTime("01/01/1900"); }
                    }
                    //datos empleado vendedor
                    //if (vendperid.Text.Trim().Length > 0) { BE.vendorid = vendperid.Text.Trim().ToString(); };
                    if (vendperid.Text.Trim().Length > 0) { BE.perdni = vendperid.Text.Trim().ToString(); };  // modificado
                    //datos ubigeo
                    BE.ubige = "000000";
                    //datos centro de costo
                    BE.cencosid = cencosid.Text.Trim().ToString();
                    //datos condicion de pago
                    //BE.condpago = condventa.SelectedValue.Trim().ToString();
                    //datos gastos varios
                    try { BE.totdscto1 = Convert.ToDecimal(totdscto1.Text.Trim()); }
                    catch { BE.totdscto1 = Convert.ToDecimal(0); }
                    //try { BE.transporte = Convert.ToDecimal(transporte.Text.Trim()); }
                    //catch { BE.transporte = Convert.ToDecimal(0); }
                    //try { BE.embalaje = Convert.ToDecimal(embalaje.Text.Trim()); }
                    //catch { BE.embalaje = Convert.ToDecimal(0); }
                    //try { BE.otros = Convert.ToDecimal(otros.Text.Trim()); }
                    //catch { BE.otros = Convert.ToDecimal(0); }
                    //tipo de impuesto
                    BE.tipimptoid = tipimptotasa.SelectedValue.ToString().Trim();
                    //datos incluido IGV
                    BE.incprec = incprec.Trim();
                    //datos tipo periodo impuesto
                    //BE.tipoperimptoid = "";
                    //datos totales calculados
                    BE.items = Convert.ToDecimal(itemsT.Text.Trim());
                    BE.totpzas = Convert.ToDecimal(totpzas.Text.Trim());
                    BE.bruto = Convert.ToDecimal(bruto.Text.Trim());
                    BE.igv = igv;
                    BE.totimpto = Convert.ToDecimal(totimpto.Text.Trim());
                    BE.valventa = Convert.ToDecimal(valventa.Text.Trim());
                    BE.totimporte = Convert.ToDecimal(totimporte.Text.Trim());
                    //datos cuenta haber y debe 
                    BE.codctadebe = "";
                    BE.codctahaber = "";
                    //datos glosa
                    BE.glosa = glosa.Text.Trim().ToUpper().ToString();
                    //fechas de movimiento del documento
                    try { BE.fechcancel = Convert.ToDateTime("01/01/1900"); }
                    catch { BE.fechcancel = Convert.ToDateTime("01/01/1900"); }
                    try { BE.fechentrega = Convert.ToDateTime(fechentrega.Text.Trim()); }
                    catch { BE.fechentrega = Convert.ToDateTime("01/01/1900"); }
                    try { BE.fechpago = Convert.ToDateTime(fechpago.Text.Trim()); }
                    catch { BE.fechpago = Convert.ToDateTime("01/01/1900"); }
                    //datos transporte
                    BE.transpid = transpid.Text.Trim().ToString();
                    if (motivotrasladoid.SelectedValue != null)
                        BE.motivotrasladoid = motivotrasladoid.SelectedValue.ToString();
                    if (mottrasladointid.SelectedValue != null)
                        BE.mottrasladointid = mottrasladointid.SelectedValue.ToString();
                    //datos cliente y/o empleado
                    BE.ddnni = ddnni.Text.Trim();
                    //otros
                    BE.tipdid = "";
                    BE.statborrado = "";
                    BE.clientetipo = "";
                    BE.modofactu = "";
                    //opt
                    BE.tipodocmanejaserie = tipodocmanejaserie;

                    //Datos del Usuario                                                
                    BE.perianio = fechdoc.Value.Year.ToString();
                    BE.perimes = fechdoc.Value.Month.ToString().PadLeft(2, '0');
                    BE.status = "0";
                    BE.usuar = VariablesPublicas.Usuar;

                    #endregion

                    #region ****ingreso movimiento detalle***
                    int item = 0;

                    foreach (DataRow fila in Tabladetallemov.Rows)
                    {
                        Detalle = new tb_me_movimientos.Item();

                        item++;

                        //datos documento cabecera importante [todos]
                        Detalle.fechdoc = Convert.ToDateTime(fechdoc.Text);
                        Detalle.moneda = moneda.SelectedValue.ToString().Trim();
                        Detalle.tcamb = Convert.ToDecimal(tcamb.Text.Trim());
                        //accion del alamacen dependiendo del tipo de documento
                        Detalle.tipoperacionid = tipoperacionid.SelectedValue.ToString();
                        //datos proveedor y/o cliente
                        Detalle.ctacteaccionid = "";
                        Detalle.ctacte = ctacte.Text.Trim().ToUpper();
                        Detalle.ctactename = ctactename.Text.Trim().ToUpper();
                        Detalle.direcnume = direcnume.Trim().ToUpper();
                        Detalle.direcname = direcname.Text.Trim().ToUpper();
                        //datos documento de referencia
                        if (tipref.SelectedValue != null && serref.Text.Trim().Length > 0)
                        {
                            Detalle.tipref = tipref.SelectedValue.ToString();
                            Detalle.serref = serref.Text.Trim().PadLeft(4, '0');
                            Detalle.numref = numdococ1.Text.Trim() + numdococ.Text.Trim().PadLeft(6, '0');
                            try { Detalle.fechref = Convert.ToDateTime(fechref.Text.Trim()); }
                            catch { Detalle.fechref = Convert.ToDateTime("01/01/1900"); }
                        }
                        //orden de produccion
                        if (ser_op.Text.Trim().Length > 0 && num_op.Text.Trim().Length > 0)
                        {
                            Detalle.tip_op = "OP";
                            Detalle.ser_op = ser_op.Text.Trim().PadLeft(4, '0');
                            Detalle.num_op = num_op.Text.Trim().PadLeft(10, '0');
                        }
                        //datos ducumento factura
                        if (serfac.Text.Trim().Length > 0 && numfac.Text.Trim().Length > 0)
                        {
                            Detalle.tipfac = tipfac.SelectedItem.ToString();
                            Detalle.serfac = serfac.Text.Trim().ToString().PadLeft(4, '0');
                            Detalle.numfac = numfac.Text.Trim().ToString().PadLeft(10, '0');
                            try { Detalle.fechfac = Convert.ToDateTime(fechfac.Text.Trim()); }
                            catch { Detalle.fechfac = Convert.ToDateTime("01/01/1900"); }
                        }
                        //datos ducumento guia
                        if (serguia.Text.Trim().Length > 0 && numguia.Text.Trim().Length > 0)
                        {
                            Detalle.tipguia = tipguia.Text.Trim();
                            Detalle.serguia = serguia.Text.Trim().ToString().PadLeft(4, '0');
                            Detalle.numguia = numguia.Text.Trim().ToString().PadLeft(10, '0');
                            try { Detalle.fechguia = Convert.ToDateTime(fechguia.Text.Trim()); }
                            catch { Detalle.fechguia = Convert.ToDateTime("01/01/1900"); }
                        }
                        //datos ducumento nota de credito
                        if (sernotac.Text.Trim().Length > 0 && numnotac.Text.Trim().Length > 0)
                        {
                            Detalle.tipnotac = tipnotac.Text.Trim();
                            Detalle.sernotac = sernotac.Text.Trim().ToString().PadLeft(4, '0');
                            Detalle.numnotac = numnotac.Text.Trim().ToString().PadLeft(10, '0');
                            try { Detalle.fechnotac = Convert.ToDateTime(fechnotac.Text.Trim()); }
                            catch { Detalle.fechnotac = Convert.ToDateTime("01/01/1900"); }
                        }
                        //centro de costo
                        Detalle.cencosid = cencosid.Text.Trim();
                        //empleado vendedor
                        if (vendperid.Text.Trim().Length > 0)
                        {
                            BE.vendorid = vendperid.Text.Trim().ToString();
                        };
                        //datos calculados de detalle de movimiento obtenidos de memoria
                        Detalle.itemref = fila["itemref"].ToString();
                        Detalle.itemsdet = item.ToString().PadLeft(5, '0');
                        Detalle.rollo = "";//fila["rollo"].ToString();
                        Detalle.productid = fila["productid"].ToString();
                        Detalle.productname = fila["productname"].ToString();

                        //Decimal cantidad = Convert.ToDecimal(fila["cantidad"].ToString());
                        //Decimal cantidadcta = Convert.ToDecimal(fila["cantidadcta"].ToString());

                        Detalle.cantidad = Convert.ToDecimal(fila["cantidad"].ToString());
                        Detalle.valor = Convert.ToDecimal(fila["valor"].ToString());
                        Detalle.importe = Convert.ToDecimal(fila["importe"].ToString());
                        if (tipoperacionid.SelectedValue.ToString() == "02")
                        {
                            if (moneda.SelectedValue.ToString() == "$")
                            {
                                Detalle.valor = Convert.ToDecimal(fila["precunit"].ToString()) * Convert.ToDecimal(tcamb.Text);
                            }
                            else
                            {
                                Detalle.valor = Convert.ToDecimal(fila["precunit"].ToString());
                            }

                            Detalle.importe = Detalle.cantidad * Detalle.valor;
                        }

                        Detalle.precunit = Convert.ToDecimal(fila["precunit"].ToString());
                        Detalle.importfac = Convert.ToDecimal(fila["importfac"].ToString());
                        Detalle.totimpto = Convert.ToDecimal(fila["totimpto"].ToString());
                        Detalle.Ubicacion = "";//fila["ubicacion"].ToString().ToUpper();
                        Detalle.unmed = fila["unmed"].ToString().Trim();
                        Detalle.nserie = fila["nserie"].ToString().Trim();

                        //accion del alamacen dependiendo del tipo de documento
                        Detalle.almacaccionid = almacaccionid;//fila["almacaccionid"].ToString();
                        //motivo del traslado
                        if (motivotrasladoid.SelectedValue != null)
                            Detalle.motivotrasladoid = motivotrasladoid.SelectedValue.ToString();
                        if (mottrasladointid.SelectedValue != null)
                            Detalle.mottrasladointid = mottrasladointid.SelectedValue.ToString();
                        //datos de costo promedio
                        Detalle.statcostopromed = statcostopromed.Trim();
                        //datos de tipo de trasaccion
                        Detalle.tiptransac = tiptransac.Trim();
                        //datos si es incluido IGV
                        Detalle.incprec = incprec.Trim();
                        Detalle.igv = igv;
                        //glosa - observacion
                        Detalle.glosa = glosa.Text.Trim().ToUpper().ToString();
                        //dato cuenta haber y debe 
                        Detalle.codctadebe = "";
                        Detalle.codctahaber = "";

                        //Datos del Usuario
                        //Detalle.perianio = fechdoc.Value.Year.ToString();
                        //Detalle.perimes = fechdoc.Value.Month.ToString();
                        Detalle.perianio = fechdoc.Value.Year.ToString();
                        Detalle.perimes = fechdoc.Value.Month.ToString().PadLeft(2, '0');
                        Detalle.status = "0";
                        Detalle.usuar = VariablesPublicas.Usuar;

                        if (ssModo != "EDIT")
                        {
                            String prod = fila["productid"].ToString();
                            String can = fila["cantidad"].ToString();
                            String impo = fila["importfac"].ToString();


                            //if (fila["productid"].ToString().Trim().Length == 13 && Convert.ToDecimal(fila["cantidad"]) > 0 && Convert.ToDecimal(fila["importfac"]) > 0)
                            //{
                            ListaItems.Add(Detalle);
                            //}
                            //else
                            //{
                            //    MessageBox.Show("Documento DETALLE EN FORMATO INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    return;
                            //}
                        }
                        else
                        {

                            ListaItems.Add(Detalle);
                        }
                    }
                    if (ListaItems.Count == 0)
                    {
                        MessageBox.Show("Documento SIN DETALLE Y/O DETALLE INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Verificacion de Fechas 

                    //if (Detalle.perianio.ToString() != VariablesPublicas.perianio.ToString() 
                    //    || Detalle.perimes.ToString() != VariablesPublicas.perimes.ToString()) 
                    //    {
                    //        MessageBox.Show("Verifique Fecha Modificacion !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        return;                        
                    //    }


                    BE.ListaItems = ListaItems;
                    if (BL.Update(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("M");
                        NIVEL_FORMS();
                        //MessageBox.Show("Datos modificados correctamente !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        form_bloqueado(false);
                        //limpiar_documento();
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
                    #endregion
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
                else if (Tabladetallemov.Rows.Count == 0)
                {
                    MessageBox.Show("Documento no tiene Items !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (numdoc.Text.Trim().Length == 10)
                    {

                        // Variables de Cabecera
                        tb_me_movimientosBL BL = new tb_me_movimientosBL();
                        tb_me_movimientos BE = new tb_me_movimientos();

                        // Variables para Detalle
                        tb_me_movimientos.Item Detalle = new tb_me_movimientos.Item();
                        List<tb_me_movimientos.Item> ListaItems = new List<tb_me_movimientos.Item>();

                        #region *** movimiento ***
                        BE.dominioid = dominio;
                        BE.moduloid = modulo;
                        BE.local = local;
                        BE.tipodoc = tipodoc.SelectedValue.ToString();
                        BE.serdoc = serdoc.Text.Trim();
                        BE.numdoc = numdoc.Text.Trim();
                        BE.status = "9";
                        BE.usuar = VariablesPublicas.Usuar;
                        BE.numref = numdococ1.Text.Trim() + numdococ.Text.Trim();

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

        private void Frm_movimiento_Load(object sender, EventArgs e)
        {
            dominio = ((MERCADERIA.MainMercaderia)MdiParent).dominioid;
            modulo = ((MERCADERIA.MainMercaderia)MdiParent).moduloid;
            local = ((MERCADERIA.MainMercaderia)MdiParent).local;
            novalidastock = ((MERCADERIA.MainMercaderia)MdiParent).novalidastock;


            //if (modulo == "0500" || modulo == "0520")
            //{
            //    btn_pestacion.Visible = true;
            //}

            //  PARAMETROS_TABLA();
            data_cbo_tipodoc();
            data_cbo_motivotrasladoid();
            data_cbo_moneda();
            get_tipimptoid();
            _cal_Igv();

            Tabladetallemov = new DataTable("detallemov");

            Tabladetallemov.Columns.Add("items", typeof(String));
            Tabladetallemov.Columns.Add("itemref", typeof(String));
            Tabladetallemov.Columns.Add("productid", typeof(String));
            Tabladetallemov.Columns.Add("productname", typeof(String));
            Tabladetallemov.Columns.Add("rollo", typeof(String));

            Tabladetallemov.Columns.Add("stock", typeof(Decimal)); Tabladetallemov.Columns["stock"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("stock_old", typeof(Decimal)); Tabladetallemov.Columns["stock_old"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("precventa", typeof(Decimal)); Tabladetallemov.Columns["precventa"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("costoultimo", typeof(Decimal)); Tabladetallemov.Columns["costoultimo"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("costopromed", typeof(Decimal)); Tabladetallemov.Columns["costopromed"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("cantidad", typeof(Decimal)); Tabladetallemov.Columns["cantidad"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("cantidad_old", typeof(Decimal)); Tabladetallemov.Columns["cantidad_old"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("valor", typeof(Decimal)); Tabladetallemov.Columns["valor"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("importe", typeof(Decimal)); Tabladetallemov.Columns["importe"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("precunit", typeof(Decimal)); Tabladetallemov.Columns["precunit"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("importfac", typeof(Decimal)); Tabladetallemov.Columns["importfac"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("totimpto", typeof(Decimal)); Tabladetallemov.Columns["totimpto"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("almacaccionid", typeof(String));
            //Tabladetallemov.PrimaryKey = new DataColumn[] { Tabladetallemov.Columns["productid"] };
            Tabladetallemov.Columns.Add("ubicacion", typeof(String));
            Tabladetallemov.Columns.Add("unmed", typeof(String));
            Tabladetallemov.Columns.Add("nserie", typeof(String));
            Tabladetallemov.Columns.Add("nostock", typeof(Boolean)); Tabladetallemov.Columns["stock"].DefaultValue = false;
            //Tabladetallemov.Columns["rollo"].Unique = true;

            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_primero.Enabled = true;
            btn_anterior.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_ultimo.Enabled = true;
            btn_salir.Enabled = true;
            numdococ.Enabled = false;
            pdtimagen.Visible = false;
            //numdococ1.Enabled = false;
        }

        private void Frm_movimiento_KeyDown(object sender, KeyEventArgs e)
        {
            if (tipref.SelectedIndex != 0)
            {
                if (e.KeyCode == Keys.Insert)
                {
                    if (!griddetallemov.ReadOnly)
                        this.btn_detanadir_Click(sender, e);
                }
            }


            if (e.KeyCode == Keys.Delete)
            {
                if (!griddetallemov.ReadOnly)
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

            if (e.Control && e.KeyCode == Keys.Enter)
            {

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

        private void tipodoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RecuperarNcaja();
            perianio = "";
            perimes = "";
            almacaccionid = "";
            statcostopromed = "";
            tiptransac = "";
            fechadocedit = false;
            tipodocautomatico = false;
            tipodocmanejaserie = false;

            statusDoc = true;

            if (btn_nuevo.Enabled == false)
            {
                limpiar_documento();
                select_tipodoc();
                get_val_fechadoc();
                if (statusDoc)
                {
                    form_bloqueado(true);
                    //fechdoc.Enabled = false;
                    btn_cancelar.Enabled = true;
                    btn_grabar.Enabled = true;
                    btn_barcode.Enabled = true;
                    btn_detanadir.Enabled = true;
                    btn_deteliminar.Enabled = true;
                    btn_attachedfile.Enabled = true;
                    ctacte.Focus();
                }
            }
            else
            {
                select_tipodoc();
                numdoc.Text = "";
                numdococ.Enabled = false;
            }
            data_cbo_mottrasladointid();
        }

        private void serdoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(numdoc, e);
        }
        private void numdoc_LostFocus(object sender, System.EventArgs e)
        {
            form_cargar_datos("");
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
                AyudaClientes("");
            }

            if (e.KeyCode == Keys.Enter)
            {
                direcname.Focus();
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

        private void direcname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {

                if (tipoperacionid.SelectedIndex != -1)
                {
                    if (tipoperacionid.SelectedValue.ToString() == "62")//Codigo De TransFerencia Entre Almacenes
                    {
                        AyudaClientesDireccion2("");
                    }
                    else
                    {
                        AyudaClientesDireccion("");
                    }
                }

                if (tipoperacionid.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione Tipo de Operación...");
                }

            }

            if (e.KeyCode == Keys.Enter)
            {
                tipoperacionid.Focus();
            }


        }

        private void tipoperacionid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tipoperacionid.SelectedIndex != -1)
            {
                if (tipoperacionid.SelectedValue.ToString().Trim() != "System.Data.DataRowView")
                {
                    tb_co_tabla12_toperacionalmacenBL BL = new tb_co_tabla12_toperacionalmacenBL();
                    tb_co_tabla12_toperacionalmacen BE = new tb_co_tabla12_toperacionalmacen();
                    DataTable dt = new DataTable();
                    BE.codigoid = tipoperacionid.SelectedValue.ToString().Trim();
                    dt = BL.GetOne(EmpresaID, BE).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        statcostopromed = dt.Rows[0]["statcostopromed"].ToString().Trim();
                        tiptransac = dt.Rows[0]["tiptransac"].ToString().Trim();
                    }
                    else
                    {
                        MessageBox.Show("Falta asignar [statcostopromed,tiptransac] !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }



                //Codigo de Transferencia Entre Almacenes Cambia Deacuerdo al Tipo de Documento
                //Ejemplo :
                // INGRESOS = 11-transferencia entre almacenes
                // SALIDAS  = 62-transferencia entre almacenes


                if (tipodoc.SelectedValue.ToString() == "GS")
                {
                    if (tipoperacionid.SelectedValue.ToString() == "62".ToString())
                    {
                        ctacte.Text = ((MERCADERIA.MainMercaderia)MdiParent).ctacte;
                        //ctacte.Text = VariablesPublicas.xctacte.ToString();
                        ValidaCliente();
                        //AyudaClientesDireccion2("");
                    }
                }



            }
        }

        private void serref_KeyDown(object sender, KeyEventArgs e)
        {
            if (tipref.SelectedIndex != -1)
            {
                if (e.KeyCode == Keys.F1)
                {
                    AyudaDocref("");
                }
            }
        }
        private void serref_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(numdoc, e);
        }


        private void numdococ_KeyDown(object sender, KeyEventArgs e)
        {
            if (tipref.SelectedIndex != -1)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    String numdo = "";
                    if (numdococ.Text.Trim().Length > 0)
                    {
                        numdo = numdococ.Text.Trim().PadLeft(6, '0');
                    }

                    numdococ.Text = numdo.ToString();
                    serref.Text = modulo;

                    ValidaDocref();

                    if (modulo == "0100")
                    {
                        Tabla_detOC2();
                    }
                    else
                    {
                        Tabla_detOC();
                    }
                    calcular_totales();

                    numdococ.Enabled = false;
                    btn_detanadir.Enabled = false;
                    moneda.Enabled = false;

                    serfac.Focus();
                }
            }
        }


        private void numdococ_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(numdoc, e);

        }

        private void serfac_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(numdoc, e);
        }

        private void serfac_LostFocus(object sender, System.EventArgs e)
        {
            String numdo = "";
            if (serfac.Text.Trim().Length > 0)
            {
                numdo = serfac.Text.Trim().PadLeft(4, '0');
            }
            serfac.Text = numdo;
        }

        private void numfac_LostFocus(object sender, System.EventArgs e)
        {
            String numdo = "";
            if (numfac.Text.Trim().Length > 0)
            {
                numdo = numfac.Text.Trim().PadLeft(10, '0');
            }
            numfac.Text = numdo;
        }


        private void serguia_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(numdoc, e);
        }

        private void serguia_LostFocus(object sender, System.EventArgs e)
        {
            String numdo = "";
            if (serguia.Text.Trim().Length > 0)
            {
                numdo = serguia.Text.Trim().PadLeft(4, '0');
            }
            serguia.Text = numdo;
        }

        private void sernotac_LostFocus(object sender, System.EventArgs e)
        {
            String numdo = "";
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
            String numdo = "";
            if (numguia.Text.Trim().Length > 0)
            {
                numdo = numguia.Text.Trim().PadLeft(10, '0');
            }
            numguia.Text = numdo;
        }

        private void numnotac_LostFocus(object sender, System.EventArgs e)
        {
            String numdo = "";
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
        private void fechref_ValueChanged(object sender, EventArgs e)
        {
            fechref.Format = DateTimePickerFormat.Short;
        }

        private void fechfac_ValueChanged(object sender, EventArgs e)
        {
            if (fechfac.Checked)
            {
                tipfac.Enabled = true;
                serfac.Enabled = true;
                numfac.Enabled = true;
                serfac.Focus();
            }
            else
            {
                tipfac.Enabled = false;
                serfac.Enabled = false; serfac.Text = "";
                numfac.Enabled = false; numfac.Text = "";
            }
        }
        private void fechguia_ValueChanged(object sender, EventArgs e)
        {
            if (fechguia.Checked)
            {
                serguia.Enabled = true;
                numguia.Enabled = true;
                serguia.Focus();
            }
            else
            {
                serguia.Enabled = false; serguia.Text = "";
                numguia.Enabled = false; numguia.Text = "";
            }
        }
        private void fechnotac_ValueChanged(object sender, EventArgs e)
        {
            if (fechnotac.Checked)
            {
                sernotac.Enabled = true;
                numnotac.Enabled = true;
                sernotac.Focus();
            }
            else
            {
                sernotac.Enabled = false; sernotac.Text = "";
                numnotac.Enabled = false; numnotac.Text = "";
            }
        }


        private void fechentrega_ValueChanged(object sender, EventArgs e)
        {
            fechentrega.Format = DateTimePickerFormat.Short;
        }
        private void fechpago_ValueChanged(object sender, EventArgs e)
        {
            fechpago.Format = DateTimePickerFormat.Short;
        }
        private void ser_op_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo_numero_enteros(numdoc, e);
        }

        private void numdococ_LostFocus(object sender, System.EventArgs e)
        {
            //if (tipref.SelectedIndex != -1)
            //{
            //    String numdo = "";
            //    if (numdococ.Text.Trim().Length > 0)
            //    {
            //        numdo = numdococ.Text.Trim().PadLeft(6, '0');

            //    }
            //    numdococ.Text = numdo.ToString();
            //    serref.Text = modulo;
            //    numdococ1.Text = VariablesPublicas.perianio;
            //    ValidaDocref();
            //    //si esta activo

            //    if (serref.Enabled)
            //    {
            //        Tabla_detOC();
            //    }

            //    numdococ.Enabled = false;
            //    btn_detanadir.Enabled = false;
            //    moneda.Enabled = false;
            //}

        }


        public bool _ValidaDocuOP()
        {

            bool xsigo = true;

            try
            {
                tb_me_movimientosdetBL BL = new tb_me_movimientosdetBL();
                tb_me_movimientosdet BE = new tb_me_movimientosdet();
                DataSet ds = new DataSet();

                BE.moduloid = modulo;
                BE.local = local;
                BE.ser_op = ser_op.Text.Trim();
                BE.num_op = num_op.Text.Trim();
                BE.tipodoc = tipodoc.SelectedValue.ToString();
                BE.serdoc = serdoc.Text.Trim();
                BE.numdoc = numdoc.Text.Trim();
                BE.almacaccionid = almacaccionid;

                // Consultar a la Capa 

                ds = BL.Get_DocOP(EmpresaID, BE);

                if (ds.Tables.Count > 0)
                {
                    //datos incluido IGV
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        String msg = "Error Ord.Prod Habilitado en:\n" +
                                     "----------------------------\n";
                        String msg2 = "";
                        foreach (DataRow fila in ds.Tables[0].Rows)
                        {
                            msg2 = msg2 +
                                "Fecha :" + fila["fechdoc"].ToString() +
                                "\nDocumento :" + fila["numdoc"].ToString() +
                                "\nDestino :" + fila["ctactename"].ToString() + "\n\n";
                        }
                        xsigo = (MessageBox.Show(msg + msg2, "Desea Proseguir !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return xsigo;
        }


        public bool _ValidaMotivoContable()
        {

            bool xsigo = true;
            if (tipodoc.SelectedValue.ToString() == "GR")
            {
                if (motivotrasladoid.SelectedIndex == -1)
                {
                    xsigo = false;
                }
                else { xsigo = true; }
            }
            return xsigo;
        }

        public bool _ValidaDirecNume()
        {

            bool xsigo = true;

            if (tipoperacionid.SelectedValue.ToString() == "62")
            {
                if (lbllocal.Text.Length == 0)
                {
                    xsigo = false;
                }
                else { xsigo = true; }
            }

            return xsigo;
        }


        //*************************************************************
        private void num_op_LostFocus(object sender, System.EventArgs e)
        {
            String numdo = "";
            if (num_op.Text.Trim().Length > 0)
            {
                numdo = num_op.Text.Trim().PadLeft(10, '0');
            }

            num_op.Text = numdo;

            if (!_ValidaDocuOP())
            {
                ser_op.Text = "";
                num_op.Text = "";
            }
        }

        private void num_op_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(num_op, e);
        }

        private void cencosid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaCentroCosto("");
            }
            if (e.KeyCode == Keys.Enter)
            {
                vendperid.Focus();
            }
        }

        private void cencosid_LostFocus(object sender, System.EventArgs e)
        {
            ValidaCentroCosto(cencosid.Text, false);
        }

        private void vendedorid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaPersonal("");
            }
        }

        private void vendedorid_LostFocus(object sender, System.EventArgs e)
        {
            ValidaPersona(vendperid.Text, false);
        }

        private void transpid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaTransportista("");
            }
        }

        private void transpid_LostFocus(object sender, System.EventArgs e)
        {
            ValidaTransportista(transpid.Text, false);
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
            {
                if (chkfijar.Checked == true)
                {
                    nuevo_fijado();
                    tipodoc_SelectedIndexChanged(sender, e);
                    if (Tabladetallemov.Rows.Count > 0) { Tabladetallemov.Rows.Clear(); }
                }
                else
                {
                    nuevo();
                }
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            //if (XNIVEL == "0" || XNIVEL == "1")
            if (XNIVEL == "0")
            {
                ssModo = "EDIT";
                form_bloqueado(true);
                nmruc.Focus();

                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
                btn_barcode.Enabled = true;
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
            bool sw_prosigue = false;
            //if (dtlis.Rows.Count != 0)
            //{
            if (ssModo == "NEW")
            {
                if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")

                    //    sw_prosigue = (MessageBox.Show("¿Desea Guardar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
                    //if (sw_prosigue)
                    //{
                    // _RecalculoGrid();
                    Insert();
                //}
            }
            else
            {
                //if (XNIVEL == "0" || XNIVEL == "1")
                if (XNIVEL == "0" || XNIVEL == "1")
                {
                    sw_prosigue = (MessageBox.Show("¿Desea Modificar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                    if (sw_prosigue)
                    {
                        //_RecalculoGrid();
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
                if (Tabladetallemov.Rows.Count > 0)
                {
                    REPORTES.Frm_reportes miForma = new REPORTES.Frm_reportes();

                    miForma.dominioid = dominio.Trim();
                    miForma.moduloid = modulo.Trim();
                    miForma.local = local.Trim();

                    miForma.Text = "Reporte Movimientos de Productos";
                    miForma.formulario = "Frm_movimiento";
                    miForma.tipdoc = tipodoc.SelectedValue.ToString();
                    miForma.serdoc = serdoc.Text.Trim().PadLeft(4, '0');
                    miForma.numdoc = numdoc.Text.Trim().PadLeft(10, '0');
                    miForma.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_imprimir2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Tabladetallemov.Rows.Count > 0)
                {
                    //REPORTES.Frm_reportes miForma = new REPORTES.Frm_reportes();

                    //miForma.dominioid = dominio.Trim();
                    //miForma.moduloid = modulo.Trim();
                    //miForma.local = local.Trim();

                    //miForma.Text = "Reporte Movimientos de Productos";
                    //miForma.formulario = "Frm_movimiento_rollos2";
                    //miForma.tipdoc = tipodoc.SelectedValue.ToString();
                    //miForma.serdoc = serdoc.Text.Trim().PadLeft(4, '0');
                    //miForma.numdoc = numdoc.Text.Trim().PadLeft(10, '0');
                    //miForma.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                if (tipoperacionid.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccionar el tipo de operación !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (tcamb.Text.Trim() == "1")
                {

                    MessageBox.Show("Actualize el Tipo de Cambio !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (griddetallemov.Enabled)
                {
                    if (this.griddetallemov.Rows.Count > 0)
                    {
                        int nFilaAnt = griddetallemov.RowCount - 1;
                        if (griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["productid"].Value.ToString().Trim().Length > 0)
                        {
                            String xProductid = griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["productid"].Value.ToString();
                            String xProductname = griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["productname"].Value.ToString();
                            this.Tabladetallemov.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetallemov));
                            Tabladetallemov.Rows[this.Tabladetallemov.Rows.Count - 1]["items"] = VariablesPublicas.CalcMaxField(this.Tabladetallemov, "items", 5);
                            //this.griddetallemov.CurrentCell = this.griddetallemov.Rows[this.griddetallemov.RowCount - 1].Cells["productid"];
                            //this.griddetallemov.CurrentCell = xProductid;



                            //this.griddetallemov.Rows[nFilaAnt + 1].Cells["productid"].Value = xProductid;
                            //this.griddetallemov.Rows[nFilaAnt + 1].Cells["productname"].Value = xProductname;


                            this.griddetallemov.CurrentCell = this.griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["productid"];
                            this.griddetallemov.BeginEdit(true);
                        }
                        else
                        {
                            MessageBox.Show("Ingrese producto !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        this.Tabladetallemov.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetallemov));
                        Tabladetallemov.Rows[this.Tabladetallemov.Rows.Count - 1]["items"] = VariablesPublicas.CalcMaxField(this.Tabladetallemov, "items", 5);
                        this.griddetallemov.CurrentCell = this.griddetallemov.Rows[this.griddetallemov.RowCount - 1].Cells["productid"];
                        this.griddetallemov.BeginEdit(true);
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
            if ((griddetallemov.CurrentRow != null))
            {
                xcoditem = this.griddetallemov.Rows[this.griddetallemov.CurrentCell.RowIndex].Cells["item"].Value.ToString();
                for (lc_cont = 0; lc_cont <= this.Tabladetallemov.Rows.Count - 1; lc_cont++)
                {
                    // ubique el item a borrar
                    if (this.Tabladetallemov.Rows[lc_cont]["items"].ToString() == xcoditem)
                    {
                        this.Tabladetallemov.Rows[lc_cont].Delete();
                        this.Tabladetallemov.AcceptChanges();
                        break;
                    }
                }
                // regenerar el nro de item
                for (lc_cont = 0; lc_cont <= this.Tabladetallemov.Rows.Count - 1; lc_cont++)
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
            Seguridadlog.FrmSeguridad oform = new Seguridadlog.FrmSeguridad();
            String xclave = VariablesPublicas.EmpresaID + "-" + modulo + "-" + tipodoc.Text.Trim() + "-" + serdoc.Text.Trim() + "-" + numdoc.Text.Trim();
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

        #region $$$ Pestaña Tabladetallemov movimiento
        private void data_Tabladetallemovmov()
        {
            _cal_Igv();
            try
            {
                Decimal xxprecventa = 0, xxcostoultimo = 0, xxstock = 0, xxcostopromed = 0;
                griddetallemov.AutoGenerateColumns = false;

                tb_me_movimientosdetBL BL = new tb_me_movimientosdetBL();
                tb_me_movimientosdet BE = new tb_me_movimientosdet();
                DataTable dt = new DataTable();

                BE.moduloid = modulo;
                BE.local = local;
                BE.tipodoc = tipodoc.SelectedValue.ToString().Trim();
                BE.serdoc = serdoc.Text.Trim().PadLeft(4, '0');
                BE.numdoc = numdoc.Text.Trim().PadLeft(6, '0');

                dt = BL.GetAll_datosdetalle(EmpresaID, BE).Tables[0];

                //datos incluido IGV
                if (dt.Rows.Count > 0)
                {
                    statcostopromed = dt.Rows[0]["statcostopromed"].ToString();
                    tiptransac = dt.Rows[0]["tiptransac"].ToString();
                    incprec = dt.Rows[0]["incprec"].ToString().Trim();
                    //tipoperef = dt.Rows[0]["tipoperef"].ToString();
                }

                if (Tabladetallemov != null)
                {
                    Tabladetallemov.Clear();
                }

                foreach (DataRow fila in dt.Rows)
                {
                    tb_me_local_stockBL BL2 = new tb_me_local_stockBL();
                    tb_me_local_stock BE2 = new tb_me_local_stock();
                    DataTable dt2 = new DataTable();
                    BE2.moduloid = modulo;
                    BE2.local = local;
                    BE2.productid = fila["productid"].ToString();
                    dt2.Clear();
                    dt2 = BL2.GetAll(EmpresaID, BE2).Tables[0];

                    if (dt2.Rows.Count > 0)
                    {
                        if (almacaccionid.Trim() == "20" || almacaccionid.Trim() == "21")
                        {
                            lbl_valor.Text = "Cost.Prom";
                            xxprecventa = 0;// Convert.ToDecimal(dt2.Rows[0]["precventa"]);
                            xxcostopromed = Convert.ToDecimal(dt2.Rows[0]["costopromed"]);

                        }
                        else if (almacaccionid.Trim() == "10" || almacaccionid.Trim() == "11")
                        {
                            lbl_valor.Text = "Cost.Ultm";
                            xxcostoultimo = Convert.ToDecimal(dt2.Rows[0]["costoultimo"]);
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
                    //row["cantidad"] = Math.Round(Convert.ToDecimal(fila["cantidad"]), 4);
                    //row["cantidad_c"] = Math.Round(Convert.ToDecimal(fila["cantidad_c"]), 4);

                    Decimal cantidad = Math.Round(Convert.ToDecimal(fila["cantidad"]), 4);
                    Decimal cantidadcta = Math.Round(Convert.ToDecimal(fila["cantidadcta"]), 4);
                    Decimal total;
                    total = cantidad - cantidadcta;

                    row["cantidad"] = total;

                    //row["cantidad_old"] = Math.Round(Convert.ToDecimal(fila["cantidad"]), 4);
                    row["cantidad_old"] = Convert.ToDecimal(fila["cantidad"]);

                    row["precunit"] = Math.Round(Convert.ToDecimal(Convert.ToDecimal(fila["precunit"]).ToString("###,###,##0.000000")), 6);

                    row["importfac"] = Math.Round(Convert.ToDecimal(fila["importfac"]), 2);

                    row["valor"] = Math.Round(Convert.ToDecimal(fila["valor"]), 6);
                    row["importe"] = Math.Round(Convert.ToDecimal(fila["importe"]), 6);
                    row["totimpto"] = Math.Round(Math.Round(Convert.ToDecimal(fila["importe"]), 6) * (Convert.ToDecimal(igv) / 100), 6);

                    row["almacaccionid"] = almacaccionid.Trim();
                    row["unmed"] = fila["unmed"].ToString().Trim();
                    row["nserie"] = fila["nserie"].ToString().Trim();
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

        private void ValidaTabladetallemovmov(String valproductid)
        {
            String xproductid = "";
            //xprecio == valor
            Decimal xprecio = 0, xprecunit = 0, xcantidad = 0, xcostoprom = 0, tipcamb = 0,
                desct1 = 0, imporfac = 0, import = 0, totimpx = 0;

            xproductid = valproductid.Trim();

            //DataRow[] rowproductid = Tabladetallemov.Select("productid='" + xproductid + "'");
            //if (rowproductid.Length > 0)
            //{
            //    MessageBox.Show("Producto ya existe !!!!!!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productname"].Value = "";
            txt_stock.Text = "0";
            txt_valor.Text = "0";
            //griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad"].Value = "0";
            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["precunit"].Value = "0";
            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["importfac"].Value = "0";
            // griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["nostock"].Value = 0;

            if (xproductid.Trim().Length == 13)
            {
                tb_me_local_stockBL BL = new tb_me_local_stockBL();
                tb_me_local_stock BE = new tb_me_local_stock();
                DataTable DT = new DataTable();
                BE.moduloid = modulo;
                BE.local = local;
                BE.productid = xproductid;

                DT = BL.GetAll(EmpresaID, BE).Tables[0];

                if (DT.Rows.Count > 0)
                {
                    //foreach (DataGridViewRow fila in griddetallemov.Rows)
                    //{
                    //foreach (DataGridViewColumn col in griddetallemov.Columns)
                    //{
                    //    if (griddetallemov.Rows[col.Index].Cells["productid"].Value.ToString().ToUpper() == valproductid.ToUpper())
                    //    {
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productid"].Value = DT.Rows[0]["productid"].ToString().Trim();
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productname"].Value = DT.Rows[0]["productname"].ToString().Trim();
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["unmed"].Value = DT.Rows[0]["unmed"].ToString().Trim();
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["rollo"].Value = "";

                    Decimal lsStock = 0, dtCantidad = 0, mvCantidad = 0, dtstock = 0;

                    lsStock = Convert.ToDecimal(DT.Rows[0]["stock"].ToString().Trim().PadLeft(1, '0'));
                    dtCantidad = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad"].Value);
                    mvCantidad = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad_old"].Value);

                    if (almacaccionid.Substring(0, 1) == "1")
                    {
                        dtstock = lsStock + dtCantidad - mvCantidad;
                    }
                    else if (almacaccionid.Substring(0, 1) == "2")
                    {
                        dtstock = lsStock - dtCantidad + mvCantidad;
                    }

                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["stock_old"].Value = lsStock;
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["stock"].Value = dtstock;

                    //griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["stock"].Value = Convert.ToDecimal(DT.Rows[0]["stock"].ToString().Trim().PadLeft(1, '0'));

                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["dalmacaccionid"].Value = almacaccionid.ToString().Trim();
                    //txt_stock.Text = Math.Round(Convert.ToDecimal(DT.Rows[0]["stock"].ToString().Trim().PadLeft(1, '0')), 2).ToString();
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

                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["precventa"].Value = xprecventa;
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["costoultimo"].Value = xcostoultimo;
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["costopromed"].Value = xcostoprom;

                    // valida si el precio de producto es ingresado o biene de local_stock
                    //xcantidad = Convert.ToDecimal(DT.Rows[0]["stock"].ToString().Trim().PadLeft(1, '0'));
                    xcantidad = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad"].Value);

                    //*** CALCULA EN IMPORTE FACTURADO
                    imporfac = Math.Round(xcantidad * Convert.ToDecimal(xprecio), 6);

                    //*** EVALUAR SI TIPO DE CAMBIO ES MENOR A 0
                    tipcamb = Convert.ToDecimal(tcamb.Text.Trim());
                    if (tipcamb <= 0)
                    {
                        tipcamb = 1;
                    }

                    //muestra el precion segun moneda para producto 
                    if (moneda.SelectedValue.ToString() == "S")
                    {
                        xprecunit = xprecio;

                    }
                    else
                    {
                        xprecunit = xprecio / tipcamb;
                    }

                    _cal_Igv();


                    //*** EVALUAR SI ES INCLUIDO O NO IGV        
                    desct1 = 0;
                    import = imporfac * (1 - (desct1 / 100));
                    if (incprec.Trim() == "S")
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

                    //if (Convert.ToBoolean(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["nostock"].Value))
                    //{
                    //    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad"].Value = "1";
                    //    griddetallemov.Columns["cantidad"].ReadOnly = true;
                    //}
                    //else
                    //{
                    //    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad"].Value = xcantidad;
                    //    griddetallemov.Columns["cantidad"].ReadOnly = false;
                    //}

                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad"].Value = xcantidad;
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["precunit"].Value = xprecunit;
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["importfac"].Value = Math.Round(imporfac, 2);
                    Tabladetallemov.AcceptChanges();
                    griddetallemov.CurrentCell = griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["cantidad"];
                    //    }else
                    //    break;
                    //}
                    //    break;
                    //}
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
            String xproductid = "";
            Decimal xprecio = 0, xprecunit = 0, xcantidad = 0, xcostoprom = 0, tipcamb = 0,
                desct1 = 0, imporfac = 0, import = 0, totimpx = 0;

            xproductid = vaproductid.Trim();

            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productname"].Value = "";
            txt_stock.Text = "0";
            txt_valor.Text = "0";
            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["precunit"].Value = "0";
            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["importfac"].Value = "0";

            if (xproductid.Trim().Length == 13)
            {
                tb_me_local_stockBL BL = new tb_me_local_stockBL();
                tb_me_local_stock BE = new tb_me_local_stock();
                DataTable DT = new DataTable();
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
                                    griddetallemov.Rows[fila.Index].Cells["rollo"].Value = "";

                                    Decimal lsStock = 0, dtCantidad = 0, mvCantidad = 0, dtstock = 0;

                                    lsStock = Convert.ToDecimal(DT.Rows[0]["stock"].ToString().Trim().PadLeft(1, '0'));
                                    dtCantidad = Convert.ToDecimal(griddetallemov.Rows[fila.Index].Cells["cantidad"].Value);
                                    mvCantidad = Convert.ToDecimal(griddetallemov.Rows[fila.Index].Cells["cantidad_old"].Value);

                                    if (almacaccionid.Substring(0, 1) == "1")
                                    {
                                        dtstock = lsStock + dtCantidad - mvCantidad;
                                    }
                                    else if (almacaccionid.Substring(0, 1) == "2")
                                    {
                                        dtstock = lsStock - dtCantidad + mvCantidad;
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
                                    else if (almacaccionid.Substring(0, 1) == "1")
                                    {
                                        xcostoultimo = Convert.ToDecimal(Convert.ToDecimal(DT.Rows[0]["costoultimo"]).ToString("###,###,##0.000000"));
                                        xprecio = Convert.ToDecimal(Convert.ToDecimal(DT.Rows[0]["costoultimo"]).ToString("###,###,##0.000000"));
                                        txt_valor.Text = Convert.ToDecimal(DT.Rows[0]["costoultimo"].ToString().Trim().PadLeft(1, '0')).ToString("###,###,##0.0000");
                                    }

                                    griddetallemov.Rows[fila.Index].Cells["precventa"].Value = xprecventa;
                                    griddetallemov.Rows[fila.Index].Cells["costoultimo"].Value = xcostoultimo;
                                    griddetallemov.Rows[fila.Index].Cells["costopromed"].Value = xcostoprom;

                                    xcantidad = Convert.ToDecimal(griddetallemov.Rows[fila.Index].Cells["cantidad"].Value);

                                    //*** CALCULA EN IMPORTE FACTURADO
                                    imporfac = Math.Round(xcantidad * Convert.ToDecimal(xprecio), 6);

                                    //*** EVALUAR SI TIPO DE CAMBIO ES MENOR A 0
                                    tipcamb = Convert.ToDecimal(tcamb.Text.Trim());
                                    if (tipcamb <= 0)
                                    {
                                        tipcamb = 1;
                                    }

                                    //muestra el precion segun moneda para producto 
                                    if (moneda.SelectedValue.ToString() == "S")
                                    {
                                        xprecunit = xprecio;

                                    }
                                    else
                                    {
                                        xprecunit = xprecio / tipcamb;
                                    }

                                    _cal_Igv();


                                    //*** EVALUAR SI ES INCLUIDO O NO IGV        
                                    desct1 = 0;
                                    import = imporfac * (1 - (desct1 / 100));
                                    if (incprec.Trim() == "S")
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

        private void griddetallemov_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // Ayudas
                if (e.KeyCode == Keys.F1)
                {
                    if ((griddetallemov.CurrentCell != null))
                    {
                        if (griddetallemov.CurrentCell.ReadOnly == false)
                        {
                            if (griddetallemov.Columns[griddetallemov.CurrentCell.ColumnIndex].Name.ToUpper() == "productid".ToUpper())
                            {
                                AyudaProducto("");
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
                            String prod = Convert.ToString(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productid"].Value);
                            if (prod != "")
                            {
                                ValidaTabladetallemovmov(prod);
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

        private void griddetallemov_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (VariablesPublicas.PulsaAyudaArticulos)
                {
                    if (griddetallemov.Columns[griddetallemov.CurrentCell.ColumnIndex].Name.ToUpper() == "productid".ToUpper())
                    {
                        AyudaProducto("");
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

        #region _Calculos_Valores_Internos_Externos

        void _RecalculoGrid()
        {
            if (almacaccionid.Length > 0)
            {
                try
                {
                    foreach (DataGridViewRow fila in griddetallemov.Rows)
                    {
                        //foreach (DataGridViewColumn col in griddetallemov.Columns)
                        // {                            
                        //*** DECLARANDO VARIABLES
                        Decimal preunit = 0, tipcamb = 0; //variables de movimiento
                        Decimal imporfac = 0, desct1 = 0, totimpx = 0, import = 0, valor = 0; //variables si es incluido igv
                        Decimal xcantidad = 0, xprecio = 0, xstock = 0, xcostopromed = 0;

                        xcantidad = Convert.ToDecimal(this.griddetallemov.Rows[fila.Index].Cells["cantidad"].Value);
                        xprecio = Convert.ToDecimal(this.griddetallemov.Rows[fila.Index].Cells["precunit"].Value);
                        xstock = Convert.ToDecimal(this.griddetallemov.Rows[fila.Index].Cells["stock"].Value);
                        xcostopromed = Convert.ToDecimal(this.griddetallemov.Rows[fila.Index].Cells["costopromed"].Value);


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

                        //*** ASIGNANDO DATOS A VARIABLES
                        preunit = Math.Round(Convert.ToDecimal(xprecio), 6);
                        tipcamb = Convert.ToDecimal(tcamb.Text.Trim());

                        //*** EVALUAR SI TIPO DE CAMBIO ES MENOR A 0
                        if (tipcamb <= 0)
                        {
                            tipcamb = 1;
                        }

                        //*** CALCULA EN IMPORTE FACTURADO
                        imporfac = Math.Round(xcantidad * Convert.ToDecimal(preunit), 6);

                        //*** Traer el Valor del IGV                        

                        _cal_Igv();

                        //*** EVALUAR SI ES INCLUIDO O NO IGV        
                        desct1 = 0;
                        import = imporfac * (1 - (desct1 / 100));
                        if (incprec.Trim() == "S")
                        {
                            totimpx = Math.Round(import * (Convert.ToDecimal(igv) / (100 + Convert.ToDecimal(igv))), 6);
                        }
                        else
                        {
                            totimpx = Math.Round(import * (Convert.ToDecimal(igv) / 100), 6);
                        }


                        //*** VALOR DEPENDIENDO DE LA ACCION DE ALMACEN Y EVALUA PRECIO/STOCK
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
                        else if (almacaccionid.Trim().Substring(0, 1) == "1")
                        {
                            valor = preunit;
                        }

                        //*** EVALUAR SI LA MONEDA ES DORALES($)
                        if (moneda.SelectedValue.ToString() == "$")
                        {
                            preunit = preunit * tipcamb;
                        }

                        griddetallemov.Rows[fila.Index].Cells["valor"].Value = preunit; // valor
                        griddetallemov.Rows[fila.Index].Cells["importe"].Value = Math.Round(xcantidad * preunit, 6);
                        griddetallemov.Rows[fila.Index].Cells["precunit"].Value = preunit;
                        griddetallemov.Rows[fila.Index].Cells["dtotimpto"].Value = totimpx;
                        griddetallemov.Rows[fila.Index].Cells["importfac"].Value = Math.Round(imporfac, 2);

                        calcular_totales();
                    }
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
        }



        private void _CalculosInternos()
        {
            _RecalculoGrid();
        }
        #endregion

        private void griddetallemov_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (griddetallemov.CurrentRow != null)
                {
                    if (griddetallemov.Columns[e.ColumnIndex].Name.ToUpper() == "productid".ToUpper())
                    {
                        String xrollo = "";
                        xrollo = (this.griddetallemov.Rows[this.griddetallemov.CurrentRow.Index].Cells["rollo"].Value.ToString().Trim()).PadLeft(13, '0');
                        if (xrollo != "0000000000000")
                        {
                            ValidaTabladetallemovmov(xrollo);
                        }
                    }

                    if (griddetallemov.Columns[e.ColumnIndex].Name.ToUpper() == "cantidad".ToUpper() || griddetallemov.Columns[e.ColumnIndex].Name.ToUpper() == "precunit".ToUpper())
                    {
                        //*** DECLARANDO VARIABLES
                        Decimal preunit = 0, tipcamb = 0; //variables de movimiento
                        Decimal imporfac = 0, desct1 = 0, totimpx = 0, import = 0, valor = 0; //variables si es incluido igv
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

                        #region *** Calculo de Stock Disponible
                        Decimal lsStock = 0, dtCantidad = 0, mvCantidad = 0, dtstock = 0;
                        lsStock = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["stock_old"].Value);
                        dtCantidad = xcantidad;
                        mvCantidad = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad_old"].Value);
                        //hallar

                        if (tipref.SelectedIndex != -1)
                        {
                            //hallamos el stcok
                            dtstock = Convert.ToDecimal(lsStock) - Convert.ToDecimal(dtCantidad);
                        }
                        else
                        {
                            if (almacaccionid.Substring(0, 1) == "1")
                            {
                                dtstock = lsStock + dtCantidad - mvCantidad;
                            }
                            else if (almacaccionid.Substring(0, 1) == "2")
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

                                //dtstock = lsStock + mvCantidad;
                                //if (dtCantidad > dtstock)
                                //{
                                //    MessageBox.Show("Cantidad fuera de rango!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //    xcantidad = 0;
                                //    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad"].Value = xcantidad;
                                //    return;
                                //}
                                //dtstock = lsStock - dtCantidad + mvCantidad;
                            }
                        }

                        //if (almacaccionid.Substring(0, 1) == "1")
                        //{
                        //    dtstock = lsStock + dtCantidad - mvCantidad;
                        //}
                        //else if (almacaccionid.Substring(0, 1) == "2")
                        //{
                        //    dtstock = lsStock + mvCantidad;
                        //    if (dtCantidad > dtstock)
                        //    {
                        //        MessageBox.Show("Cantidad fuera de rango!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        xcantidad = 0;
                        //        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad"].Value = xcantidad;
                        //        return;
                        //    }
                        //    dtstock = lsStock - dtCantidad + mvCantidad;
                        //}



                        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["stock"].Value = dtstock;
                        #endregion

                        //*** Traer el Valor del IGV                        
                        _cal_Igv();

                        xstock = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["stock"].Value);
                        xcostopromed = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["costopromed"].Value);


                        //*** CALCULA EN IMPORTE FACTURADO
                        imporfac = Math.Round(xcantidad * Convert.ToDecimal(xprecio), 6);

                        //*** VALOR DEPENDIENDO DE LA ACCION DE ALMACEN Y EVALUA PRECIO/STOCK
                        if (almacaccionid.Trim().Substring(0, 1) == "2")
                        {
                            valor = Math.Round(Convert.ToDecimal(xcostopromed), 6);

                            //if (xcantidad <= xstock)
                            //{
                            //    valor = Math.Round(Convert.ToDecimal(xcostopromed), 6);
                            //}
                            //else
                            //{
                            //    MessageBox.Show("Cantidad fuera de rango!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    xcantidad = 0;
                            //    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad"].Value = xcantidad;
                            //    return;
                            //}

                            //Decimal xxstock = 0;
                            //tb_me_local_stockBL BL2 = new tb_me_local_stockBL();
                            //tb_me_local_stock BE2 = new tb_me_local_stock();
                            //DataTable dt2 = new DataTable();
                            //BE2.moduloid = modulo;
                            //BE2.productid = (String)griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productid"].Value;

                            //dt2 = BL2.GetAll(EmpresaID, BE2).Tables[0];

                            //if (dt2.Rows.Count > 0)
                            //{                                  
                            //    xxstock = Convert.ToDecimal(dt2.Rows[0]["stock"]);                                
                            //}
                        }
                        else if (almacaccionid.Trim().Substring(0, 1) == "1")
                        {
                            valor = preunit;
                        }

                        //*** ASIGNANDO DATOS A VARIABLES
                        preunit = Math.Round(Convert.ToDecimal(xprecio), 6);
                        tipcamb = Convert.ToDecimal(tcamb.Text.Trim());

                        //*** EVALUAR SI TIPO DE CAMBIO ES MENOR A 0
                        if (tipcamb <= 0)
                        {
                            tipcamb = 1;
                        }

                        //*** EVALUAR SI LA MONEDA ES DORALES($)
                        if (moneda.SelectedValue.ToString() == "$")
                        {
                            preunit = preunit * tipcamb;
                        }


                        //*** EVALUAR SI ES INCLUIDO O NO IGV        
                        desct1 = 0;
                        import = imporfac * (1 - (desct1 / 100));
                        if (incprec.Trim() == "S")
                        {
                            totimpx = Math.Round(import * (Convert.ToDecimal(igv) / (100 + Convert.ToDecimal(igv))), 6);
                        }
                        else
                        {
                            totimpx = Math.Round(import * (Convert.ToDecimal(igv) / 100), 6);
                        }

                        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["valor"].Value = preunit; // valor
                        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["importe"].Value = Math.Round(xcantidad * preunit, 6);

                        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["dtotimpto"].Value = totimpx;
                        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["importfac"].Value = Math.Round(imporfac, 2);
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

        private void griddetallemov_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (griddetallemov.CurrentRow != null)
                {
                    if (almacaccionid.Trim().Substring(0, 1) == "1")
                    {
                        txt_valor.Text = Convert.ToDecimal(griddetallemov.Rows[e.RowIndex].Cells["costoultimo"].Value).ToString("#,###,##0.000").Trim();
                    }
                    else
                    {
                        txt_valor.Text = Convert.ToDecimal(griddetallemov.Rows[e.RowIndex].Cells["costopromed"].Value).ToString("#,###,##0.000").Trim();
                    }
                    txt_stock.Text = Convert.ToDecimal(griddetallemov.Rows[e.RowIndex].Cells["stock"].Value).ToString("#,###,##0.00").Trim();
                }
            }
            catch (Exception)
            {

            }
        }

        private void _cal_Igv()
        {

            int xval_igv = Convert.ToInt32(tipimptotasa.Text);
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

        #endregion

        #endregion

        private void num_op_Enter(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            data_cbo_mottrasladointid();
        }

        private void ser_opp_TextChanged(object sender, EventArgs e)
        {
            ser_op.Text = ser_op.Text.Trim().ToUpper();
        }

        private void btnImprimirNoval_Click(object sender, EventArgs e)
        {
            try
            {
                if (Tabladetallemov.Rows.Count > 0)
                {
                    REPORTES.Frm_reportes miForma = new REPORTES.Frm_reportes();

                    miForma.dominioid = dominio.Trim();
                    miForma.moduloid = modulo.Trim();
                    miForma.local = local.Trim();

                    miForma.Text = "Reporte Movimientos de Productos";
                    miForma.formulario = "Frm_movimiento_noval";
                    miForma.tipdoc = tipodoc.SelectedValue.ToString();
                    miForma.serdoc = serdoc.Text.Trim().PadLeft(4, '0');
                    miForma.numdoc = numdoc.Text.Trim().PadLeft(10, '0');
                    miForma.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            //_RecalculoGrid();
            calcular_totales();
        }

        private void ser_op_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btn_attachedfile_Click(object sender, EventArgs e)
        {
            //Frm_attachedfile attached = new Frm_attachedfile();
            //attached.numdoc = numdoc.Text;
            //attached.tipdoc = tipodoc.SelectedValue.ToString();
            //attached.serdoc = serdoc.Text;
            //attached.ShowDialog();
        }

        private void tipref_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tipref.SelectedIndex != -1)
            {
                if (tipref.SelectedValue.ToString() == "SO")
                {
                    numdococ.Enabled = false;
                    numdococ1.Enabled = false;
                    serfac.Focus();
                }
                else if (tipref.SelectedValue.ToString() == "OC")
                {
                    numdococ.Enabled = true;
                    numdococ1.Enabled = true;
                    numdococ1.Text = perianio;
                    numdococ.Focus();
                }
            }
        }


        #region Eventos de Focus()

        private void numdococ1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                numdococ.Focus();
            }
        }

        private void serfac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                numfac.Focus();
            }
        }

        private void numfac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String numdo = "";
                if (numfac.Text.Trim().Length > 0)
                {
                    numdo = numfac.Text.Trim().PadLeft(10, '0');
                }
                numfac.Text = numdo;

                ValidaCabDoc();
                Valida_DetDoc();
                fechfac.Focus();
            }
        }

        private void ValidaCabDoc()
        {
            if (tipfac.SelectedIndex != -1 && serfac.Text.Trim().Length == 4 && numfac.Text.Trim().Length == 10)
            {
                tb_me_movimientoscabBL BL = new tb_me_movimientoscabBL();
                tb_me_movimientoscab BE = new tb_me_movimientoscab();

                DataTable dt = new DataTable();

                BE.moduloid = modulo;
                BE.local = local;
                BE.tipodoc = tipfac.Text.ToString();
                BE.serdoc = serfac.Text.Trim();
                BE.numdoc = numfac.Text.ToString();
                dt = BL.GetOne(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {

                    serfac.Text = dt.Rows[0]["serdoc"].ToString().Trim();
                    String numdoc = dt.Rows[0]["numdoc"].ToString().Trim();

                    fechfac.Value = Convert.ToDateTime(dt.Rows[0]["fechdoc"]);
                    ctacte.Text = dt.Rows[0]["ctacte"].ToString().Trim();
                    nmruc.Text = dt.Rows[0]["nmruc"].ToString().Trim();
                    ctactename.Text = dt.Rows[0]["ctactename"].ToString().Trim();
                    direc.Text = dt.Rows[0]["direc"].ToString().Trim();
                    moneda.SelectedValue = dt.Rows[0]["moneda"].ToString().Trim();

                    //string s = dt.Rows[0]["sigla"].ToString().Trim();
                    //txtmoneda.Text = dt.Rows[0]["sigla"].ToString().Trim();

                }
            }
        }

        private void Valida_DetDoc()
        {
            _cal_Igv();

            Decimal xxprecventa = 0, xxcostoultimo = 0, xxstock = 0, xxcostopromed = 0;
            griddetallemov.AutoGenerateColumns = false;

            tb_me_movimientosdetBL BL = new tb_me_movimientosdetBL();
            tb_me_movimientosdet BE = new tb_me_movimientosdet();

            DataTable dt = new DataTable();

            BE.moduloid = modulo;
            BE.local = local;
            BE.tipodoc = tipfac.Text.ToString();
            BE.serdoc = serfac.Text.Trim();
            BE.numdoc = numfac.Text.ToString();

            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            try
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {
                        tb_me_local_stockBL BL2 = new tb_me_local_stockBL();
                        tb_me_local_stock BE2 = new tb_me_local_stock();
                        DataTable dt2 = new DataTable();

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
                            else if (almacaccionid.Trim() == "10" || almacaccionid.Trim() == "11")
                            {
                                lbl_valor.Text = "Cost.Ultm";
                                xxcostoultimo = Convert.ToDecimal(dt2.Rows[0]["costoultimo"]);
                            }

                            xxstock = Convert.ToDecimal(dt2.Rows[0]["stock"]);
                            if (xxstock == 0)
                            { xxstock = Convert.ToDecimal(dt2.Rows[0]["stockini"]); }
                        }

                        row = Tabladetallemov.NewRow();
                        row["itemref"] = fila["itemref"].ToString();
                        row["items"] = fila["items"].ToString();
                        row["productid"] = fila["productid"].ToString().Trim();
                        row["productname"] = fila["productname"].ToString().Trim();

                        Decimal cantidad = Math.Round(Convert.ToDecimal(fila["cantidad"]), 4);
                        row["stock"] = xxstock;
                        row["precventa"] = xxprecventa;
                        row["costoultimo"] = xxcostoultimo;
                        row["costopromed"] = xxcostopromed;

                        row["cantidad"] = cantidad;
                        row["cantidad_old"] = Math.Round(Convert.ToDecimal(fila["cantidad"]), 4);
                        row["precunit"] = Math.Round(Convert.ToDecimal(Convert.ToDecimal(fila["precunit"]).ToString("###,###,##0.000000")), 6);
                        Decimal precunit = Math.Round(Convert.ToDecimal(Convert.ToDecimal(fila["precunit"]).ToString("###,###,##0.000000")), 6);
                        Decimal importe;
                        importe = cantidad * precunit;

                        row["importfac"] = importe;
                        row["valor"] = Math.Round(Convert.ToDecimal(fila["valor"]), 6);
                        row["importe"] = Math.Round(Convert.ToDecimal(fila["importe"]), 6);
                        row["totimpto"] = Math.Round(Math.Round(Convert.ToDecimal(fila["importe"]), 6) * (Convert.ToDecimal(igv) / 100), 6);
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
            catch (Exception ex)
            {
                throw ex;
            }

        }


        private void tipoperacionid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mottrasladointid.Focus();
            }
        }

        private void numdoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                griddetallemov.Focus();
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
                fechguia.Focus();
            }
        }

        private void btn_Calculadora_Click(object sender, EventArgs e)
        {
            Process Proceso = new Process();
            Proceso.StartInfo.FileName = "calc.exe";
            Proceso.StartInfo.Arguments = "";
            Proceso.Start();
        }

        private void mottrasladointid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                motivotrasladoid.Focus();
            }
        }

        private void motivotrasladoid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tipref.Focus();
            }
        }

        private void tipref_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                numdococ1.Focus();
            }
        }

        private void fechfac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                serguia.Focus();
            }
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

        private void glosa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ser_op.Focus();
            }
        }

        private void ser_op_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaOrdenProduccion("");
            }

            if (e.KeyCode == Keys.Enter)
            {
                num_op.Focus();
            }
        }

        private void num_op_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cencosid.Focus();
            }
        }

        #endregion

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in griddetallemov.Rows)
            {
                String xproductid = griddetallemov.Rows[fila.Index].Cells["productid"].Value.ToString();
                if (xproductid.Trim().Length == 13)
                {
                    tb_me_local_stockBL BL = new tb_me_local_stockBL();
                    tb_me_local_stock BE = new tb_me_local_stock();
                    DataTable DT = new DataTable();

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

        private void btn_pestacion_Click(object sender, EventArgs e)
        {
            //CATALOGO.Frm_persona_cencos frmPersona = new CATALOGO.Frm_persona_cencos();
            //frmPersona.ShowDialog();
        }


        private void btn_upload_Click(object sender, EventArgs e)
        {
            try
            {
                if (almacaccionid.Trim().Length == 0)
                {
                    MessageBox.Show("Seleccionar Tipo de Documento !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (tipoperacionid.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccionar el tipo de Operación !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Frm_movimiento_upload frmayuda = new Frm_movimiento_upload();
                frmayuda.titulo = "CARGA MASIVA ROLLOS DE TELA";
                //frmayuda.detallemov = Tabladetallemov.Copy();
                frmayuda.moduloid = modulo.ToString();
                frmayuda.almacaccionid = almacaccionid;
                frmayuda.tipoperacionid = tipoperacionid.SelectedValue.ToString();
                frmayuda.moneda = moneda.SelectedValue.ToString();
                frmayuda.tcamb = tcamb.Text.Trim();
                frmayuda.incprec = incprec.Trim();
                frmayuda.igv = igv;
                frmayuda.Owner = this;
                frmayuda.PasarTabla = Recibedetallemov2;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        private void Recibedetallemov2(DataTable resultado)
        {
            if (resultado.Rows.Count > 0)
            {
                Tabladetallemov = resultado;
                griddetallemov.DataSource = Tabladetallemov;
                _RecalculoGrid();
                //calcular_totales();               
            }

        }

        private void griddetallemov_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            //MessageBox.Show(anError.RowIndex + " " + anError.ColumnIndex);
            //MessageBox.Show("Error happened " + anError.Context.ToString());

            //if (anError.Context == DataGridViewDataErrorContexts.Commit)
            //{
            //    MessageBox.Show("Commit error");
            //}
            //if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            //{
            //    MessageBox.Show("Cell change");
            //}
            //if (anError.Context == DataGridViewDataErrorContexts.Parsing)
            //{
            //    MessageBox.Show("parsing error");
            //}
            //if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
            //{
            //    MessageBox.Show("leave control error");
            //}

            //if ((anError.Exception) is ConstraintException)
            //{
            //    DataGridView view = (DataGridView)sender;
            //    view.Rows[anError.RowIndex].ErrorText = "an error";
            //    view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";

            //    anError.ThrowException = false;
            //}
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            Exportar_Excel();
        }

        private void Exportar_Excel()
        {
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;

            try
            {
                //Start Excel and get Application object.
                oXL = new Excel.Application();
                oXL.Visible = false;

                //Get a new workbook.
                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                // Primero Cargaremos las Cabeceras Estaticas
                oSheet.Cells[1, 1] = "Item";
                oSheet.Cells[1, 2] = "Codigo";
                oSheet.Cells[1, 3] = "Producto";
                oSheet.Cells[1, 4] = "N-Serie";

                oSheet.get_Range("A1", "D1").Font.Bold = true;
                oSheet.get_Range("A1", "D1").Font.Color = Color.White;
                oSheet.get_Range("A1", "D1").Interior.ColorIndex = 14; // 14=Teal
                oSheet.get_Range("A1", "D1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                int IndiceFila = 0;

                // Dando El Formato de Texto a Las Columnas
                oRng = oSheet.get_Range("A2", "D" + griddetallemov.Rows.Count + 1);
                oRng.NumberFormat = "@";

                foreach (DataGridViewRow row in griddetallemov.Rows)
                {
                    IndiceFila++;
                    for (int column = 1; column < 5; column++)
                    {
                        oSheet.Cells[IndiceFila + 1, column] = row.Cells[column].Value;
                    }
                }

                //AutoFit columns A:D.
                oRng = oSheet.get_Range("A1", "D1");
                oRng.EntireColumn.AutoFit();

                oXL.Visible = true;
                oXL.UserControl = true;
            }
            catch (Exception ex)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, ex.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, ex.Source);

                MessageBox.Show(errorMessage, "Error");
            }
        }




        private void btn_import_Click(object sender, EventArgs e)
        {
            Importar_Excel();
        }

        private void Importar_Excel()
        {
            OpenFileDialog CuadroDialogo = new OpenFileDialog();
            CuadroDialogo.DefaultExt = "xls";
            CuadroDialogo.Filter = "xls file(*.xls)|*.xlsx";
            CuadroDialogo.AddExtension = true;
            CuadroDialogo.RestoreDirectory = true;
            CuadroDialogo.Title = "Seleccionar Archivo";

            if (CuadroDialogo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Instancia de Excel
                    Excel.Application excelApp = new Excel.Application();
                    // Abrimos el libro.
                    Excel.Workbook excelBook = excelApp.Workbooks.Open(CuadroDialogo.FileName, Type.Missing, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    // Obtener primera hoja del libro actual
                    Excel._Worksheet excelWorksheet = (Excel._Worksheet)excelBook.Worksheets.get_Item(1);
                    // Visible o no Excel de preferencia falso
                    excelApp.Visible = false;

                    // Leer el valor dela Celda Especificada en el rango
                    int x = 2;//Inicio de la iteraccion para recorrer el archivo. Nota: A diferencia del Array, en el libro de excel se empieza en 1
                    DataTable DatosExcel = new DataTable("DatosExcel");
                    DatosExcel.Columns.Add("items", typeof(String));
                    DatosExcel.Columns.Add("productid", typeof(String));
                    DatosExcel.Columns.Add("productname", typeof(String));
                    DatosExcel.Columns.Add("nserie", typeof(String));

                    excelWorksheet.get_Range("A");

                    while (excelWorksheet.get_Range("A" + x).Value2 != null)
                    {
                        DatosExcel.Rows.Add(excelWorksheet.get_Range("A" + x).Value2.ToString(),
                                                  excelWorksheet.get_Range("B" + x).Value2.ToString(),
                                                  excelWorksheet.get_Range("C" + x).Value2.ToString(),
                                                  excelWorksheet.get_Range("D" + x).Value2.ToString());
                        x++;
                    }

                    //Salimos de la Instancia de Excel.
                    excelApp.Quit();

                    Boolean sw_prosigue = false;
                    sw_prosigue = (MessageBox.Show("¿Desea Modificar las Series ...!!!", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
                    if (sw_prosigue)
                    {
                        //Recorremos la Tabla Temporal y Modificamos la Serie Segun el Excel
                        foreach (DataRow fila in DatosExcel.Rows)
                        {
                            String xxproductid = fila["productid"].ToString();
                            String xxnserie = fila["nserie"].ToString();

                            for (int i = 0; i < griddetallemov.Rows.Count; i++)
                            {
                                String _prod = griddetallemov.Rows[i].Cells["productid"].Value.ToString();
                                if (xxproductid == _prod) { griddetallemov.Rows[i].Cells["nserie"].Value = xxnserie; }
                            }

                        }
                        MessageBox.Show("Modificación de Series Completada ...!!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception sms)
                {
                    MessageBox.Show(sms.Message);
                }
            }
        }

        private void btn_information_Click(object sender, EventArgs e)
        {
            sys_formulariosBL BL = new sys_formulariosBL();
            tb_sys_formulario BE = new tb_sys_formulario();
            DataTable DataFunc = new DataTable();

            BE.dominioid = dominio;
            BE.moduloid = modulo;
            BE.formname = this.Name;
            DataFunc = BL.GetAll(VariablesPublicas.EmpresaID, BE).Tables[0];

            if (DataFunc.Rows.Count > 0)
            {
                POPUP.Frm_webbrowser_single frm = new POPUP.Frm_webbrowser_single();
                frm.webBrowser1.DocumentText = DataFunc.Rows[0]["formfunc"].ToString().Trim();
                frm.ShowDialog();
            }
        }

        private void chkfijar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkfijar.Checked == true) { tipodoc.Enabled = false; } else { tipodoc.Enabled = true; }
        }

        private void btn_refresh_tcamb_Click(object sender, EventArgs e)
        {
            get_tipocambio(fechdoc.Text);
        }



        // Codigo Agregado

        private void btn_barcode_Click(object sender, EventArgs e)
        {
            var frmayuda = new POPUP.Frm_barcode();
            frmayuda.moneda = moneda.SelectedValue.ToString().Trim();
            frmayuda.tcamb = Convert.ToDecimal(tcamb.Text);
            frmayuda.tipodoc = tipodoc.SelectedValue.ToString();
            frmayuda.Owner = this;
            frmayuda.PasarTabla = Recibedetalle;
            frmayuda.ShowDialog();
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
                        CargarDetalle(xxproductid);
                        calcular_totales();
                    }
                }
            }
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
            Decimal xprecio = 0, xvalor = 0, xcantidad = 0, tipcamb = 0;
            var desct1 = 0;
            Decimal imporfac = 0;
            Decimal import = 0;
            Decimal totimpx = 0;

            if (xxproductid.Trim().Length == 13)
            {
                var BE = new tb_me_productos();
                var BL = new tb_me_productosBL();
                var dt = new DataTable();

                BE.moduloid = modulo;
                BE.local = local;
                BE.productid = xxproductid;
                BE.moneda = moneda.SelectedValue.ToString();
                BE.tcamb = Convert.ToDecimal(tcamb.Text);
                BE.tipodoc = tipodoc.SelectedValue.ToString();

                dt = BL.GetPrecCostoUltimo(VariablesPublicas.EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productid"].Value = dt.Rows[0]["productid"].ToString().Trim();
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productname"].Value = dt.Rows[0]["productname"].ToString().Trim();
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["unmed"].Value = dt.Rows[0]["unmed"].ToString().Trim();

                    Decimal lsStock = 0, dtCantidad = 0, mvCantidad = 0, dtstock = 0;

                    lsStock = Convert.ToDecimal(dt.Rows[0]["stock"].ToString().Trim());
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

                    xprecio = Convert.ToDecimal(dt.Rows[0]["precunit"].ToString().Trim());
                    xcantidad = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad"].Value);

                    imporfac = Math.Round(xcantidad * Convert.ToDecimal(xprecio), 6);
                    tipcamb = Convert.ToDecimal(tcamb.Text.Trim());

                    if (tipcamb <= 0)
                    {
                        tipcamb = 1;
                    }

                    //El Precio ya Lo Traigo sea Dolar O Soles
                    xvalor = xprecio;

                    _cal_Igv();


                    desct1 = 0;
                    import = imporfac * (1 - (desct1 / 100));
                    //if (Equivalencias.Left(cbo_incprec.Text.Trim(), 1) == "S")
                    //{
                    //    totimpx = Math.Round(import * (Convert.ToDecimal(igv) / (100 + Convert.ToDecimal(igv))), 6);
                    //}
                    //else
                    //{
                    totimpx = Math.Round(import * (Convert.ToDecimal(igv) / 100), 6);
                    //}

                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["valor"].Value = xvalor;
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["importe"].Value = Math.Round(xcantidad * xvalor, 6);
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["dtotimpto"].Value = totimpx;

                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["precioanterior"].Value = xprecio;

                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad"].Value = xcantidad;
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["precunit"].Value = xprecio;
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["importfac"].Value = Math.Round(imporfac, 2);
                    Tabladetallemov.AcceptChanges();
                    griddetallemov.CurrentCell = griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["cantidad"];
                }
                else
                {
                    MessageBox.Show("Producto no existe en Tabla Local Stock !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Producto no Existe !!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }

}