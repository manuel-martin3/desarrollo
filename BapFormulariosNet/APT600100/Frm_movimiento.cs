using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using System.Diagnostics;

namespace BapFormulariosNet.APT600100
{
    public partial class Frm_movimiento : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String perianio = string.Empty;
        private String perimes = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable Tabladetallemov;
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

        private String tipimptoid = string.Empty;
        private Decimal igv = 0;
        private String direcnume = string.Empty;
        private String incprec = "N";
        private String ssModo = "NEW";

        private static Decimal xprecventa = 0, xcostoultimo = 0;

        public Frm_movimiento()
        {
            InitializeComponent();

            numdoc.LostFocus += new System.EventHandler(numdoc_LostFocus);
            num_op.LostFocus += new System.EventHandler(num_op_LostFocus);
            serfac.LostFocus += new System.EventHandler(serfac_LostFocus);
            serguia.LostFocus += new System.EventHandler(serguia_LostFocus);
            sernotac.LostFocus += new System.EventHandler(sernotac_LostFocus);
            numfac.LostFocus += new System.EventHandler(numfac_LostFocus);
            numguia.LostFocus += new System.EventHandler(numguia_LostFocus);
            numnotac.LostFocus += new System.EventHandler(numnotac_LostFocus);
            fechdoc.LostFocus += new System.EventHandler(fechdoc_LostFocus);
            ctacte.LostFocus += new System.EventHandler(ctacte_LostFocus);
            nmruc.LostFocus += new System.EventHandler(nmruc_LostFocus);
            cencosid.LostFocus += new System.EventHandler(cencosid_LostFocus);
            vendperid.LostFocus += new System.EventHandler(vendedorid_LostFocus);
            transpid.LostFocus += new System.EventHandler(transpid_LostFocus);
        }

        private void PARAMETROS_TABLA()
        {
            if (modulo == "0500")
            {
                xxferfil = "600500000";
            }
            else
            {
                if (modulo == "0520")
                {
                    xxferfil = "600520000";
                }
                else
                {
                    var f = (MainAlmacenPT)MdiParent;
                    xxferfil = f.perfil.ToString();
                }
            }
            if (xxferfil.Trim().Length != 9)
            {
                MessageBox.Show("::: NO TIENE PERFIL !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PERFILID = xxferfil;
            var XTABLA_PERFIL = string.Empty;
            XTABLA_PERFIL = VariablesPublicas.GET_PARAMETROS_TABLA(xxferfil, Name);
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
                sw = Convert.ToBoolean (miForma.ShowDialog());

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
                chk_activarColumn.Enabled = true;
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
                    perimes = dt.Rows[0]["perimes"].ToString().Trim();
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

                dt = BL.GetAll_nuevonumero(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    serdoc.Text = dt.Rows[0]["serdoc"].ToString();
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
                fechref.Enabled = var;

                chk_activarColumn.Enabled = false;

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
                vendperid.Enabled = false;
                vendpername.Enabled = var;
                estacion.Enabled = var;
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
                fechdoc.MinDate = new DateTime(2000, 1, 1);
                fechdoc.MaxDate = new DateTime(2999, 12, 12);
                fechdoc.Value = DateTime.Today;
                tabdatos.SelectedIndex = 0;

                nmruc.Focus();
            }
        }

        private void form_cargar_datos(String posicion)
        {
            try
            {
                limpiar_documento();
                var BL = new tb_60movimientoscabBL();
                var BE = new tb_60movimientoscab();
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
                    data_cbo_tiporeferencia(almacaccionid);
                    serdoc.Text = dt.Rows[0]["serdoc"].ToString().Trim();
                    numdoc.Text = dt.Rows[0]["numdoc"].ToString().Trim();
                    fechdoc.Text = dt.Rows[0]["fechdoc"].ToString().Trim();

                    tipimptoid = dt.Rows[0]["tipimptoid"].ToString().Trim();
                    direcnume = dt.Rows[0]["direcnume"].ToString().Trim();
                    incprec = dt.Rows[0]["incprec"].ToString().Trim();

                    moneda.SelectedValue = dt.Rows[0]["moneda"].ToString().Trim();
                    txtmoneda.Text = dt.Rows[0]["moneda"].ToString().Trim();
                    tcamb.Text = dt.Rows[0]["tcamb"].ToString().Trim();

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

                        var n = dt.Rows[0]["numref"].ToString().Trim();

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
                        tipfac.SelectedValue = dt.Rows[0]["tipfac"].ToString().Trim();
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
                    ValidaCentroCosto(dt.Rows[0]["cencosid"].ToString(), true);
                    estacion.Text = dt.Rows[0]["estacion"].ToString();
                    ValidaPersona(dt.Rows[0]["perdni"].ToString(), true);

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
                    ValidaTransportista(dt.Rows[0]["transpid"].ToString(), false);
                    ddnni.Text = dt.Rows[0]["ddnni"].ToString().Trim();
                    itemsT.Text = dt.Rows[0]["items"].ToString().Trim();
                    totpzas.Text = dt.Rows[0]["totpzas"].ToString().Trim();
                    bruto.Text = dt.Rows[0]["bruto"].ToString().Trim();
                    totdscto1.Text = dt.Rows[0]["totdscto1"].ToString().Trim();
                    valventa.Text = dt.Rows[0]["valventa"].ToString().Trim();
                    totimpto.Text = dt.Rows[0]["totimpto"].ToString().Trim();
                    totimporte.Text = dt.Rows[0]["totimporte"].ToString().Trim();
                    glosa.Text = dt.Rows[0]["glosa"].ToString().Trim();

                    //data_Tabladetallemovmov();
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
                    }
                    else
                    {
                        ssModo = "ANULADO";
                        txt_status.Text = "ANULADO";
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
                    }
                }
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
                BE.tipodoctipotransac = "A";

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

        private void data_cbo_motivotrasladoid()
        {
            try
            {
                var BL = new tb_co_motivodeltrasladoBL();
                var BE = new tb_co_motivodeltraslado();
                motivotrasladoid.DataSource = BL.GetAll(EmpresaID, BE).Tables[0];
                motivotrasladoid.ValueMember = "motivotrasladoid";
                motivotrasladoid.DisplayMember = "motivotrasladoname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void data_cbo_mottrasladointid()
        {
            try
            {
                var BL = new tb_mottrasladointBL();
                var BE = new tb_mottrasladoint();
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

        private void data_cbo_tipooperacion(String almacaccion)
        {
            try
            {
                var BL = new tb_co_tabla12_toperacionalmacenBL();
                var BE = new tb_co_tabla12_toperacionalmacen();
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

        private void data_cbo_tiporeferencia(string accion)
        {
            var BL = new modulo_local_tipodocBL();
            var BE = new tb_modulo_local_tipodoc();
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


        private void data_cbo_tipodocalt()
        {
            try
            {
                var BL = new modulo_local_tipodocBL();
                var BE = new tb_modulo_local_tipodoc();
                BE.dominioid = dominio;
                BE.moduloid = modulo;
                BE.local = local;
                BE.visiblealmac = true;
                BE.status = string.Empty;
                BE.tipodoctipotransac = "A";

                cmbtipdocalt.DataSource = BL.GetAll_mov(EmpresaID, BE).Tables[0];
                cmbtipdocalt.ValueMember = "tipodoc";
                cmbtipdocalt.DisplayMember = "tipodocname";
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
                    direcname.Text = string.Empty;
                    direcdeta.Text = string.Empty;
                    nmruc.Focus();
                }
            }
        }

        private void ValidaDocref()
        {
            if (tipref.SelectedIndex != -1 && serref.Text.Trim().Length == 4 && numdococ.Text.Trim().Length == 6)
            {
                var BL = new tb_cm_ordendecompracabBL();
                var BE = new tb_cm_ordendecompracab();

                var dt = new DataTable();
                BE.moduloid = "0100";
                BE.local = "001";
                BE.tipodoc = tipref.SelectedValue.ToString();
                BE.serdoc = serref.Text.Trim();
                BE.numdoc = numdococ1.Text.ToString() + numdococ.Text.Trim();
                dt = BL.GetOne(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    serref.Text = dt.Rows[0]["serdoc"].ToString().Trim();
                    var numdoc = dt.Rows[0]["numdoc"].ToString().Trim();
                    numdococ1.Text = Equivalencias.Left(numdoc, 4);
                    numdococ.Text = Equivalencias.Right(numdoc, 6);

                    fechref.Format = DateTimePickerFormat.Short;
                    fechref.Value = Convert.ToDateTime(dt.Rows[0]["fechdoc"]);
                    ctacte.Text = dt.Rows[0]["ctacte"].ToString().Trim();
                    nmruc.Text = dt.Rows[0]["nmruc"].ToString().Trim();
                    ctactename.Text = dt.Rows[0]["ctactename"].ToString().Trim();
                    direc.Text = dt.Rows[0]["direc"].ToString().Trim();
                    moneda.SelectedValue = dt.Rows[0]["moneda"].ToString().Trim();

                    dt.Rows[0]["sigla"].ToString().Trim();
                    txtmoneda.Text = dt.Rows[0]["sigla"].ToString().Trim();
                }
            }
        }

        private void Tabla_detOC()
        {
            Decimal xxprecventa = 0, xxcostoultimo = 0, xxstock = 0, xxcostopromed = 0;
            griddetallemov.AutoGenerateColumns = false;

            var BL = new tb_cm_ordendecompradetBL();
            var BE = new tb_cm_ordendecompradet();
            var dt = new DataTable();

            BE.moduloid = "0100";
            BE.local = "001";
            BE.tipodoc = tipref.SelectedValue.ToString();
            BE.serdoc = serref.Text.Trim();
            BE.numdoc = numdococ1.Text.Trim() + numdococ.Text.Trim();

            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow fila in dt.Rows)
                {
                    var BL2 = new tb_60local_stockBL();
                    var BE2 = new tb_60local_stock();
                    var dt2 = new DataTable();
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

                    tipoperacionid.Text = "COMPRA";
                    row = Tabladetallemov.NewRow();
                    row["itemref"] = fila["itemref"].ToString();
                    row["items"] = fila["items"].ToString();
                    row["productid"] = fila["productid"].ToString().Trim();
                    row["productname"] = fila["productname"].ToString().Trim();

                    var cantidad_c = Math.Round(Convert.ToDecimal(fila["cantidad_c"]), 4);
                    var cantidadcta_c = Math.Round(Convert.ToDecimal(fila["cantidadcta_c"]), 4);
                    if (tipref.SelectedIndex != -1)
                    {
                        var stock_old = Math.Round(Convert.ToDecimal(fila["cantidad_c"]), 4);
                        var total = cantidad_c - cantidadcta_c;
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
                    var precunit = Math.Round(Convert.ToDecimal(Convert.ToDecimal(fila["precunit_c"]).ToString("###,###,##0.000000")), 6);
                    Decimal importe;
                    importe = cantidad_c * precunit;
                    row["importfac"] = importe;
                    row["valor"] = Math.Round(Convert.ToDecimal(fila["valor"]), 6);
                    row["importe"] = Math.Round(Convert.ToDecimal(fila["importe"]), 6);
                    row["totimpto"] = Math.Round(Math.Round(Convert.ToDecimal(fila["importe"]), 6) * (Convert.ToDecimal(18) / 100), 6);
                    row["almacaccionid"] = almacaccionid.Trim();
                    Tabladetallemov.Rows.Add(row);
                    griddetallemov.DataSource = Tabladetallemov;
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
                numdococ1.Text = string.Empty;
                numdococ.Text = string.Empty;
                return;
            }
        }

        private void Tabla_detOC2()
        {
            Decimal xxprecventa = 0, xxcostoultimo = 0, xxstock = 0, xxcostopromed = 0;
            griddetallemov.AutoGenerateColumns = false;

            var BL = new tb_cm_ordendecompradetBL();
            var BE = new tb_cm_ordendecompradet();
            var dt = new DataTable();

            BE.moduloid = "0100";
            BE.local = "001";
            BE.tipodoc = tipref.SelectedValue.ToString();
            BE.serdoc = serref.Text.Trim();
            BE.numdoc = numdococ1.Text.Trim() + numdococ.Text.Trim();

            dt = BL.GetAll2(EmpresaID, BE).Tables[0];

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow fila in dt.Rows)
                {
                    var BL2 = new tb_60local_stockBL();
                    var BE2 = new tb_60local_stock();
                    var dt2 = new DataTable();

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

                    tipoperacionid.Text = "COMPRA";
                    row = Tabladetallemov.NewRow();
                    row["itemref"] = fila["itemref"].ToString();
                    row["items"] = fila["items"].ToString();
                    row["productid"] = fila["productid"].ToString().Trim();
                    row["productname"] = fila["productname"].ToString().Trim();

                    var cantidad_c = Math.Round(Convert.ToDecimal(fila["cantidad_c"]), 4);
                    var cantidadcta_c = Math.Round(Convert.ToDecimal(fila["cantidadcta_c"]), 4);

                    if (tipref.SelectedIndex != -1)
                    {
                        var stock_old = Math.Round(Convert.ToDecimal(fila["cantidad_c"]), 4);
                        var total = cantidad_c - cantidadcta_c;
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
                    var precunit = Math.Round(Convert.ToDecimal(Convert.ToDecimal(fila["precunit_c"]).ToString("###,###,##0.000000")), 6);
                    Decimal importe;
                    importe = cantidad_c * precunit;

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
                MessageBox.Show("    !!!... Informacion de la Orden ...!!! \n" +
                                "\n » La Orden Todabia no ha Sido Generada " +
                                "\n » O la Orden esta Generada en Otra Guia " +
                                "\n\n »» Verifica Tus Ordenes Pendientes  ", "Localizando Orden", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                tipref.Enabled = true;
                tipref.SelectedIndex = -1;
                tipref.Enabled = true;
                numdococ1.Text = "2014";
                numdococ.Text = string.Empty;
                return;
            }
        }

        private void ValidaCentroCosto(String xcencosid, Boolean retrn)
        {
            if (xcencosid.Trim().Length == 5)
            {
                var BL = new tb_centrocostoBL();
                var BE = new tb_centrocosto();
                var dt = new DataTable();
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
                        cencosid.Text = string.Empty;
                        cencosname.Text = string.Empty;
                        cencosid.Focus();
                    }
                }
            }
            else
            {
                cencosid.Text = string.Empty;
                cencosname.Text = string.Empty;
            }
        }

        private void ValidaPersona(String xPersonadni, Boolean retrn)
        {
            if (xPersonadni.Trim().Length > 0)
            {
                var BL = new tb_co_persona_cencosBL();
                var BE = new tb_co_persona_cencosBE();

                var dt = new DataTable();

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
                        vendperid.Text = string.Empty;
                        vendpername.Text = string.Empty;
                        vendperid.Focus();
                    }
                }
            }
        }

        private void ValidaTransportista(String xtranspid, Boolean retrn)
        {
            if (xtranspid.Trim().Length > 0)
            {
                var BL = new tb_transportistaBL();
                var BE = new tb_transportista();
                var dt = new DataTable();
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
                        transpid.Text = string.Empty;
                        transpname.Text = string.Empty;
                        transplicencia.Text = string.Empty;
                        transpcertificado.Text = string.Empty;
                        transpplaca.Text = string.Empty;
                        transpid.Focus();
                    }
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
                direcname.Text = resultado2.Trim();
                direcdeta.Text = resultado3.Trim();
            }
        }

        private void AyudaDocref(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "Ayuda Ordenes de compra";
                frmayuda.sqlquery = "select fechdoc, serdoc, numdoc, nmruc, ctactename, totpzas, totimporte from tb_cm_ordendecompracab tb1";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where moduloiddes='" + modulo + "' and localdes='" + local + "' and tb1.tipodoc='OC' and status <> 9";
                frmayuda.sqland = " and";
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
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "Ayuda Orden de Produción";
                frmayuda.sqlquery = "select serdoc,numdoc,nmruc,ctactename,articname,fechdoc from tb_pp_ordenproduccioncab";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where";
                frmayuda.sqland = string.Empty;
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
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "Ayuda Centro de Costo";
                frmayuda.sqlquery = "select cencosid, cencosname From tb_centrocosto where cencosdivi = 2 ";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = string.Empty;
                frmayuda.sqland = "and";
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
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "Ayuda Vendedor";
                frmayuda.sqlquery = "select vendorid, vendorname from tb_vendedor_corporativo";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where";
                frmayuda.sqland = string.Empty;
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
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "Ayuda Vendedor";
                frmayuda.sqlquery = "select nrodni,nombrelargo from tb_plla_fichatrabajadores ";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where cencosid = '" + cencosid.Text.ToString() + "' ";
                frmayuda.sqland = "and";
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
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "Ayuda Transportista";
                frmayuda.sqlquery = "select transpid,transpname,transpplaca,transpcertificado,transplicencia from tb_transportista";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where";
                frmayuda.sqland = string.Empty;
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
                        var frmayuda = new Ayudas.Form_help_gridproducto();
                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA PRODUCTO >>";
                        if (modulo == "0500")
                        {
                            frmayuda.sqlquery = " select tb1.productid, tb1.productname,tb1.unmed, "+
                                                " SUM(IIF(mdet.almacaccionid = '10',mdet.cantidad * 1,mdet.cantidad *-1)) AS stock, " +
                                                " tb2.costoultimo as precventa, tb2.[local],tb1.nserie from tb_" + modd + "_productos tb1 ";
                        }
                        else
                        {
                            frmayuda.sqlquery = " select tb1.productid, tb1.productname,tb1.unmed, "+
                                                " SUM(IIF(mdet.almacaccionid = '10',mdet.cantidad * 1,mdet.cantidad *-1)) AS stock, " +
                                                " tb2.costoultimo as precventa, tb2.[local] from tb_" + modd + "_productos tb1 ";
                        }

                        frmayuda.sqlinner = " LEFT JOIN tb_" + modd + "_local_stock tb2 on tb1.moduloid = tb2.moduloid "+
                                            " AND tb1.productid = tb2.productid "+
                                            " LEFT JOIN tb_" + modd + "_movimientosdet mdet ON tb1.productid = mdet.productid "+
                                            " AND tb2.local = mdet.local "; 

                        if (modulo == "0500")
                        {
                            frmayuda.sqlwhere = "where tb2.[local] ='" + local + "' ";
                        }
                        else
                        {
                            frmayuda.sqlwhere = "where tb2.[local] ='" + local + "' and tb1.status = '0' ";
                        }

                        frmayuda.sqland = "and";

                        if (modulo == "0500")
                        {
                            frmayuda.sqlgroupby = " GROUP BY tb1.productid " +
                                    ", tb1.productname " +
                                    ", tb1.unmed " +
                                    ", tb2.costoultimo " +
                                    ", tb2.local " +
                                    ", tb1.nserie ";
                        }
                        else {
                            frmayuda.sqlgroupby = " GROUP BY tb1.productid " +
                                    ", tb1.productname " +
                                    ", tb1.unmed " +
                                    ", tb2.costoultimo " +
                                    ", tb2.[local] ";
                        }

                        frmayuda.criteriosbusqueda = new string[] { "PRODUCTO", "CODIGO" };
                        frmayuda.columbusqueda = "tb1.productname,tb1.productid";
                        frmayuda.returndatos = "0,1,2,6";

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
                            var xnserie = string.Empty;
                            if (modulo == "0500")
                            {
                                xnserie = fila["nserie"].ToString();
                            }

                            if (cont > 1)
                            {
                                Tabladetallemov.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetallemov));
                                Tabladetallemov.Rows[Tabladetallemov.Rows.Count - 1]["items"] = VariablesPublicas.CalcMaxField(Tabladetallemov, "items", 5);
                                griddetallemov.Rows[nFilaAnt + 1].Cells["productid"].Value = xProductid;
                                griddetallemov.Rows[nFilaAnt + 1].Cells["productname"].Value = xProductname;
                            }
                            else
                            {
                                griddetallemov.Rows[nFilaAnt].Cells["productid"].Value = xProductid;
                                griddetallemov.Rows[nFilaAnt].Cells["productname"].Value = xProductname;
                                griddetallemov.Rows[nFilaAnt].Cells["unmed"].Value = xunmed;
                                if (modulo == "0500")
                                {
                                    griddetallemov.Rows[nFilaAnt].Cells["nserie"].Value = xnserie;
                                }
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
                incprec = "N";
                ssModo = "NEW";

                numdococ1.Text = VariablesPublicas.perianio;

                fechdoc.Text = DateTime.Today.ToShortDateString();
                moneda.SelectedValue = "S";
                tcamb.Text = "1";
                tipimptotasa.Text = string.Empty;
                ctacte.Text = string.Empty;
                nmruc.Text = string.Empty;
                ctactename.Text = string.Empty;
                direc.Text = string.Empty;
                mottrasladointid.SelectedIndex = -1;
                direcname.Text = string.Empty;
                direcdeta.Text = string.Empty;
                tipoperacionid.SelectedIndex = -1;
                motivotrasladoid.SelectedIndex = -1;
                tipref.DataSource = null;
                serref.Text = modulo;
                numdococ.Text = string.Empty;
                numdocalt.Text = string.Empty;

                fechref.Text = DateTime.Today.ToShortDateString();

                tipfac.SelectedIndex = 0;
                serfac.Text = string.Empty;
                numfac.Text = string.Empty;
                fechfac.Text = DateTime.Today.ToShortDateString();

                tipguia.Text = "GR";
                serguia.Text = string.Empty;
                numguia.Text = string.Empty;
                fechguia.Text = DateTime.Today.ToShortDateString();

                tipnotac.Text = "NC";
                sernotac.Text = string.Empty;
                numnotac.Text = string.Empty;
                fechnotac.Text = DateTime.Today.ToShortDateString();

                ser_op.Text = string.Empty;
                num_op.Text = string.Empty;
                cencosid.Text = string.Empty;
                cencosname.Text = string.Empty;
                vendperid.Text = string.Empty;
                vendpername.Text = string.Empty;
                estacion.Text = string.Empty;
                fechentrega.Text = DateTime.Today.ToShortDateString();
                fechpago.Text = DateTime.Today.ToShortDateString();
                transpid.Text = string.Empty;
                transpname.Text = string.Empty;
                transpplaca.Text = string.Empty;
                transpcertificado.Text = string.Empty;
                transplicencia.Text = string.Empty;
                ddnni.Text = string.Empty;
                ddnniname.Text = string.Empty;
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
                glosa.Text = string.Empty;
                txt_status.Text = string.Empty;
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
                numdococ1.Text = VariablesPublicas.perianio;
                fechdoc.Text = DateTime.Today.ToString("d");
                moneda.SelectedValue = "S";
                tcamb.Text = "1";
                tipimptotasa.Text = string.Empty;
                ctacte.Text = string.Empty;
                nmruc.Text = string.Empty;
                ctactename.Text = string.Empty;
                direc.Text = string.Empty;
                mottrasladointid.SelectedIndex = -1;
                direcname.Text = string.Empty;
                direcdeta.Text = string.Empty;
                tipoperacionid.SelectedIndex = -1;
                motivotrasladoid.SelectedIndex = -1;
                tipref.DataSource = null;
                serref.Text = modulo;
                numdococ.Text = string.Empty;
                fechref.Text = string.Empty;
                fechref.CustomFormat = " ";
                fechref.Format = DateTimePickerFormat.Custom;
                tipfac.SelectedIndex = 0;
                serfac.Text = string.Empty;
                numfac.Text = string.Empty;
                tipguia.Text = "GR";
                serguia.Text = string.Empty;
                numguia.Text = string.Empty;
                tipnotac.Text = "NC";
                sernotac.Text = string.Empty;
                numnotac.Text = string.Empty;
                ser_op.Text = string.Empty;
                num_op.Text = string.Empty;
                cencosid.Text = string.Empty;
                cencosname.Text = string.Empty;
                vendperid.Text = string.Empty;
                vendpername.Text = string.Empty;
                fechentrega.Text = string.Empty;
                fechentrega.CustomFormat = " ";
                fechentrega.Format = DateTimePickerFormat.Custom;
                fechpago.Text = string.Empty;
                fechpago.CustomFormat = " ";
                fechpago.Format = DateTimePickerFormat.Custom;
                transpid.Text = string.Empty;
                transpname.Text = string.Empty;
                transpplaca.Text = string.Empty;
                transpcertificado.Text = string.Empty;
                transplicencia.Text = string.Empty;
                ddnni.Text = string.Empty;
                ddnniname.Text = string.Empty;
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
                glosa.Text = string.Empty;
                txt_status.Text = string.Empty;
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
                _cal_Igv();
                if (Tabladetallemov.Rows.Count != 0)
                {
                    itemsT.Text = Tabladetallemov.Rows.Count.ToString();
                    totpzas.Text = Convert.ToDecimal(Tabladetallemov.Compute("sum(cantidad)", string.Empty)).ToString("##,###,##0.00");


                    bruto.Text = Math.Round(Convert.ToDecimal(Tabladetallemov.Compute("sum(importfac)", string.Empty)), 2).ToString("##,###,##0.00");

                    stotal = Math.Round(Convert.ToDecimal(Tabladetallemov.Compute("sum(importfac)", string.Empty)), 2);
                    if (incprec == "S")
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
                }
                else
                {
                    itemsT.Text = Tabladetallemov.Rows.Count.ToString();
                    totpzas.Text = "0";
                    bruto.Text = "0";
                    valventa.Text = "0";
                    totimpto.Text = "0";
                    totimporte.Text = "0";
                }
            }
        }

        private void Recalcular_Detalle()
        {
            Decimal xcant, xprec, xval ;
            foreach (DataGridViewRow row in griddetallemov.Rows)
            {
                xcant = Convert.ToDecimal(griddetallemov.Rows[row.Index].Cells["cantidad"].Value);
                xprec = Convert.ToDecimal(griddetallemov.Rows[row.Index].Cells["precunit"].Value);
                xval = Convert.ToDecimal(griddetallemov.Rows[row.Index].Cells["valor"].Value);

                griddetallemov.Rows[row.Index].Cells["importe"].Value = xcant * xval;
                griddetallemov.Rows[row.Index].Cells["importfac"].Value = xcant * xprec;
            }
        }

        private void nuevo()
        {
            tipodoc.SelectedIndex = 0;
            limpiar_documento();
            form_bloqueado(false);
            get_val_fechadoc();
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_upload.Enabled = true;
            btn_detanadir.Enabled = true;
            btn_deteliminar.Enabled = true;
            btn_attachedfile.Enabled = true;

            ssModo = "NEW";
            tabdatos.SelectedIndex = 0;
            serdoc.Enabled = false;
            numdoc.Enabled = false;
            numdococ.Enabled = false;
        }

        private void Insert()
        {
            _cal_Igv();
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
                        if (!_ValidaDocuOP())
                        {
                            ser_op.Text = string.Empty;
                            num_op.Text = string.Empty;
                            return;
                        }
                        else
                        {
                            if (tcamb.Text.Trim() == "1")
                            {
                                MessageBox.Show("Actualize el Tipo de Cambio !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                if (numdoc.Text.Trim().Length == 10)
                                {
                                    var BL = new tb_60movimientosBL();
                                    var BE = new tb_60movimientos();

                                    var Detalle = new tb_60movimientos.Item();
                                    var ListaItems = new List<tb_60movimientos.Item>();

                                    BE.dominioid = dominio;
                                    BE.moduloid = modulo;
                                    BE.local = local;
                                    BE.tipodoc = tipodoc.SelectedValue.ToString();
                                    BE.serdoc = serdoc.Text.Trim();
                                    BE.numdoc = numdoc.Text.ToString();
                                    BE.fechdoc = Convert.ToDateTime(fechdoc.Text);
                                    BE.moneda = moneda.SelectedValue.ToString().Trim();
                                    BE.tcamb = Convert.ToDecimal(tcamb.Text.Trim());
                                    BE.almacaccionid = almacaccionid.Trim();
                                    BE.tipoperacionid = tipoperacionid.SelectedValue.ToString();
                                    BE.ctacteaccionid = string.Empty;
                                    BE.ctacte = ctacte.Text.Trim().ToUpper();
                                    BE.nmruc = nmruc.Text.Trim();
                                    BE.ctactename = ctactename.Text.Trim().ToUpper();
                                    BE.direc = direc.Text.Trim().ToUpper();
                                    BE.direcnume = direcnume.Trim().ToUpper();
                                    BE.direcname = direcname.Text.Trim().ToUpper();
                                    BE.direcdeta = direcdeta.Text.Trim().ToUpper();
                                    if (tipref.SelectedValue != null && serref.Text.Trim().Length > 0)
                                    {
                                        if (tipref.SelectedValue.ToString() == "OC")
                                        {
                                            BE.tipref = tipref.SelectedValue.ToString();
                                            BE.serref = serref.Text.Trim().PadLeft(4, '0');

                                            BE.numref = numdococ1.Text.Trim() + numdococ.Text.Trim().PadLeft(6, '0');

                                            try
                                            {
                                                BE.fechref = Convert.ToDateTime(fechref.Text.Trim());
                                            }
                                            catch
                                            {
                                                BE.fechref = Convert.ToDateTime("01/01/1900");
                                            }
                                        }
                                        else
                                        {
                                            if (tipref.SelectedValue.ToString() == "SO")
                                            {
                                                BE.tipref = string.Empty;
                                                BE.serref = string.Empty;
                                                BE.numref = string.Empty;
                                                try
                                                {
                                                    BE.fechref = Convert.ToDateTime(fechref.Text.Trim());
                                                }
                                                catch
                                                {
                                                    BE.fechref = Convert.ToDateTime("01/01/1900");
                                                }
                                            }
                                        }
                                    }
                                    if (ser_op.Text.Trim().Length > 0 && num_op.Text.Trim().Length > 0)
                                    {
                                        BE.tip_op = "OP";
                                        BE.ser_op = ser_op.Text.Trim().PadLeft(4, '0');
                                        BE.num_op = num_op.Text.Trim().PadLeft(10, '0');
                                    }
                                    if (serfac.Text.Trim().Length > 0 && numfac.Text.Trim().Length > 0)
                                    {
                                        BE.tipfac = tipfac.SelectedItem.ToString();
                                        BE.serfac = serfac.Text.Trim().ToString().PadLeft(4, '0');
                                        BE.numfac = numfac.Text.Trim().ToString().PadLeft(10, '0');
                                        try
                                        {
                                            BE.fechfac = Convert.ToDateTime(fechfac.Text.Trim());
                                        }
                                        catch
                                        {
                                            BE.fechfac = Convert.ToDateTime("01/01/1900");
                                        }
                                    }
                                    if (serguia.Text.Trim().Length > 0 && numguia.Text.Trim().Length > 0)
                                    {
                                        BE.tipguia = tipguia.Text.Trim();
                                        BE.serguia = serguia.Text.Trim().ToString().PadLeft(4, '0');
                                        BE.numguia = numguia.Text.Trim().ToString().PadLeft(10, '0');
                                        try
                                        {
                                            BE.fechguia = Convert.ToDateTime(fechguia.Text.Trim());
                                        }
                                        catch
                                        {
                                            BE.fechguia = Convert.ToDateTime("01/01/1900");
                                        }
                                    }
                                    if (sernotac.Text.Trim().Length > 0 && numnotac.Text.Trim().Length > 0)
                                    {
                                        BE.tipnotac = tipnotac.Text.Trim();
                                        BE.sernotac = sernotac.Text.Trim().ToString().PadLeft(4, '0');
                                        BE.numnotac = numnotac.Text.Trim().ToString().PadLeft(10, '0');
                                        try
                                        {
                                            BE.fechnotac = Convert.ToDateTime(fechnotac.Text.Trim());
                                        }
                                        catch
                                        {
                                            BE.fechnotac = Convert.ToDateTime("01/01/1900");
                                        }
                                    }
                                    if (vendperid.Text.Trim().Length > 0)
                                    {
                                        BE.perdni = vendperid.Text.Trim().ToString();
                                    }
                                    ;
                                    BE.ubige = "000000";
                                    BE.cencosid = cencosid.Text.Trim().ToString();
                                    BE.estacion = estacion.Text.Trim().ToString();

                                    try
                                    {
                                        BE.totdscto1 = Convert.ToDecimal(totdscto1.Text.Trim());
                                    }
                                    catch
                                    {
                                        BE.totdscto1 = Convert.ToDecimal(0);
                                    }

                                    BE.tipimptoid = tipimptotasa.SelectedValue.ToString().Trim();
                                    BE.incprec = incprec.Trim();
                                    BE.items = Convert.ToDecimal(itemsT.Text.Trim());
                                    BE.totpzas = Convert.ToDecimal(totpzas.Text.Trim());
                                    BE.bruto = Convert.ToDecimal(bruto.Text.Trim());
                                    BE.igv = igv;
                                    BE.totimpto = Convert.ToDecimal(totimpto.Text.Trim());
                                    BE.valventa = Convert.ToDecimal(valventa.Text.Trim());
                                    BE.totimporte = Convert.ToDecimal(totimporte.Text.Trim());
                                    BE.codctadebe = string.Empty;
                                    BE.codctahaber = string.Empty;
                                    BE.glosa = glosa.Text.Trim().ToUpper().ToString();
                                    try
                                    {
                                        BE.fechcancel = Convert.ToDateTime("01/01/1900");
                                    }
                                    catch
                                    {
                                        BE.fechcancel = Convert.ToDateTime("01/01/1900");
                                    }
                                    try
                                    {
                                        BE.fechentrega = Convert.ToDateTime(fechentrega.Text.Trim());
                                    }
                                    catch
                                    {
                                        BE.fechentrega = Convert.ToDateTime("01/01/1900");
                                    }
                                    try
                                    {
                                        BE.fechpago = Convert.ToDateTime(fechpago.Text.Trim());
                                    }
                                    catch
                                    {
                                        BE.fechpago = Convert.ToDateTime("01/01/1900");
                                    }

                                    BE.transpid = transpid.Text.Trim().ToString();
                                    if (motivotrasladoid.SelectedValue != null)
                                    {
                                        BE.motivotrasladoid = motivotrasladoid.SelectedValue.ToString();
                                    }
                                    if (mottrasladointid.SelectedValue != null)
                                    {
                                        BE.mottrasladointid = mottrasladointid.SelectedValue.ToString();
                                    }
                                    BE.ddnni = ddnni.Text.Trim();
                                    BE.tipdid = string.Empty;
                                    BE.statborrado = string.Empty;
                                    BE.clientetipo = string.Empty;
                                    BE.modofactu = string.Empty;
                                    BE.tipodocmanejaserie = tipodocmanejaserie;
                                    Detalle.perianio = fechdoc.Value.Year.ToString();
                                    Detalle.perimes = fechdoc.Value.Month.ToString().PadLeft(2 , '0');
                                    Detalle.status = "0";
                                    Detalle.usuar = VariablesPublicas.Usuar;

                                    var item = 0;
                                    foreach (DataRow fila in Tabladetallemov.Rows)
                                    {
                                        Detalle = new tb_60movimientos.Item();

                                        item++;

                                        Detalle.fechdoc = Convert.ToDateTime(fechdoc.Text);
                                        Detalle.moneda = moneda.SelectedValue.ToString().Trim();
                                        Detalle.tcamb = Convert.ToDecimal(tcamb.Text.Trim());
                                        Detalle.tipoperacionid = tipoperacionid.SelectedValue.ToString();
                                        Detalle.ctacteaccionid = string.Empty;
                                        Detalle.ctacte = ctacte.Text.Trim().ToUpper();
                                        Detalle.ctactename = ctactename.Text.Trim().ToUpper();
                                        Detalle.direcnume = direcnume.Trim().ToUpper();
                                        Detalle.direcname = direcname.Text.Trim().ToUpper();
                                        if (tipref.SelectedValue != null && serref.Text.Trim().Length > 0)
                                        {
                                            Detalle.tipref = tipref.SelectedValue.ToString();
                                            Detalle.serref = serref.Text.Trim().PadLeft(4, '0');
                                            Detalle.numref = numdococ1.Text.Trim() + numdococ.Text.Trim().PadLeft(6, '0');
                                            try
                                            {
                                                Detalle.fechref = Convert.ToDateTime(fechref.Text.Trim());
                                            }
                                            catch
                                            {
                                                Detalle.fechref = Convert.ToDateTime("01/01/1900");
                                            }
                                        }
                                        if (ser_op.Text.Trim().Length > 0 && num_op.Text.Trim().Length > 0)
                                        {
                                            Detalle.tip_op = "OP";
                                            Detalle.ser_op = ser_op.Text.Trim().PadLeft(4, '0');
                                            Detalle.num_op = num_op.Text.Trim().PadLeft(10, '0');
                                        }
                                        if (serfac.Text.Trim().Length > 0 && numfac.Text.Trim().Length > 0)
                                        {
                                            Detalle.tipfac = tipfac.SelectedItem.ToString();
                                            Detalle.serfac = serfac.Text.Trim().ToString().PadLeft(4, '0');
                                            Detalle.numfac = numfac.Text.Trim().ToString().PadLeft(10, '0');
                                            try
                                            {
                                                Detalle.fechfac = Convert.ToDateTime(fechfac.Text.Trim());
                                            }
                                            catch
                                            {
                                                Detalle.fechfac = Convert.ToDateTime("01/01/1900");
                                            }
                                        }
                                        if (serguia.Text.Trim().Length > 0 && numguia.Text.Trim().Length > 0)
                                        {
                                            Detalle.tipguia = tipguia.Text.Trim();
                                            Detalle.serguia = serguia.Text.Trim().ToString().PadLeft(4, '0');
                                            Detalle.numguia = numguia.Text.Trim().ToString().PadLeft(10, '0');
                                            try
                                            {
                                                Detalle.fechguia = Convert.ToDateTime(fechguia.Text.Trim());
                                            }
                                            catch
                                            {
                                                Detalle.fechguia = Convert.ToDateTime("01/01/1900");
                                            }
                                        }
                                        if (sernotac.Text.Trim().Length > 0 && numnotac.Text.Trim().Length > 0)
                                        {
                                            Detalle.tipnotac = tipnotac.Text.Trim();
                                            Detalle.sernotac = sernotac.Text.Trim().ToString().PadLeft(4, '0');
                                            Detalle.numnotac = numnotac.Text.Trim().ToString().PadLeft(10, '0');
                                            try
                                            {
                                                Detalle.fechnotac = Convert.ToDateTime(fechnotac.Text.Trim());
                                            }
                                            catch
                                            {
                                                Detalle.fechnotac = Convert.ToDateTime("01/01/1900");
                                            }
                                        }
                                        Detalle.cencosid = cencosid.Text.Trim();
                                        if (vendperid.Text.Trim().Length > 0)
                                        {
                                            BE.vendorid = vendperid.Text.Trim().ToString();
                                        }
                                        ;
                                        Detalle.itemref = fila["itemref"].ToString();
                                        Detalle.itemsdet = item.ToString().PadLeft(5, '0');
                                        Detalle.rollo = fila["rollo"].ToString();
                                        Detalle.productid = fila["productid"].ToString();
                                        Detalle.productname = fila["productname"].ToString();
                                        Detalle.Ubicacion = fila["ubicacion"].ToString();
                                        Detalle.unmed = fila["unmed"].ToString();
                                        Detalle.nserie = fila["nserie"].ToString().Trim();

                                        Detalle.cantidad = Convert.ToDecimal(fila["cantidad"].ToString());

                                        Detalle.valor = Convert.ToDecimal(fila["valor"].ToString());
                                        Detalle.importe = Convert.ToDecimal(fila["importe"].ToString());

                                        Detalle.precunit = Convert.ToDecimal(fila["precunit"].ToString());
                                        Detalle.importfac = Convert.ToDecimal(fila["importfac"].ToString());
                                        Detalle.totimpto = Convert.ToDecimal(fila["totimpto"].ToString());

                                        Detalle.almacaccionid = almacaccionid;
                                        if (motivotrasladoid.SelectedValue != null)
                                        {
                                            Detalle.motivotrasladoid = motivotrasladoid.SelectedValue.ToString();
                                        }
                                        if (mottrasladointid.SelectedValue != null)
                                        {
                                            Detalle.mottrasladointid = mottrasladointid.SelectedValue.ToString();
                                        }
                                        Detalle.statcostopromed = statcostopromed.Trim();
                                        Detalle.tiptransac = tiptransac.Trim();
                                        Detalle.incprec = incprec.Trim();
                                        Detalle.igv = igv;
                                        Detalle.glosa = glosa.Text.Trim().ToUpper().ToString();
                                        Detalle.codctadebe = string.Empty;
                                        Detalle.codctahaber = string.Empty;

                                        Detalle.perianio = fechdoc.Value.Year.ToString();
                                        Detalle.perimes = fechdoc.Value.Month.ToString().PadLeft(2, '0');
                                        Detalle.status = "0";
                                        Detalle.usuar = VariablesPublicas.Usuar;

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
                        }
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
                        if (tcamb.Text.Trim() == "1")
                        {
                            MessageBox.Show("Actualize el Tipo de Cambio !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            if (numdoc.Text.Trim().Length == 10)
                            {
                                var BL = new tb_60movimientosBL();
                                var BE = new tb_60movimientos();

                                var Detalle = new tb_60movimientos.Item();
                                var ListaItems = new List<tb_60movimientos.Item>();

                                BE.dominioid = dominio;
                                BE.moduloid = modulo;
                                BE.local = local;
                                BE.tipodoc = tipodoc.SelectedValue.ToString();
                                BE.serdoc = serdoc.Text.Trim();
                                BE.numdoc = numdoc.Text.Trim();
                                BE.fechdoc = Convert.ToDateTime(fechdoc.Text);
                                BE.moneda = moneda.SelectedValue.ToString().Trim();
                                BE.tcamb = Convert.ToDecimal(tcamb.Text.Trim());
                                BE.almacaccionid = almacaccionid.Trim();
                                BE.tipoperacionid = tipoperacionid.SelectedValue.ToString();
                                BE.ctacteaccionid = string.Empty;
                                BE.ctacte = ctacte.Text.Trim().ToUpper();
                                BE.nmruc = nmruc.Text.Trim();
                                BE.ctactename = ctactename.Text.Trim().ToUpper();
                                BE.direc = direc.Text.Trim().ToUpper();
                                BE.direcnume = direcnume.Trim().ToUpper();
                                BE.direcname = direcname.Text.Trim().ToUpper();
                                BE.direcdeta = direcdeta.Text.Trim().ToUpper();
                                if (tipref.SelectedValue != null && serref.Text.Trim().Length > 0)
                                {
                                    if (tipref.SelectedValue.ToString() == "OC")
                                    {
                                        BE.tipref = tipref.SelectedValue.ToString();
                                        BE.serref = serref.Text.Trim().PadLeft(4, '0');

                                        BE.numref = numdococ1.Text.Trim() + numdococ.Text.Trim().PadLeft(6, '0');

                                        try
                                        {
                                            BE.fechref = Convert.ToDateTime(fechref.Text.Trim());
                                        }
                                        catch
                                        {
                                            BE.fechref = Convert.ToDateTime("01/01/1900");
                                        }
                                    }
                                    else
                                    {
                                        if (tipref.SelectedValue.ToString() == "SO")
                                        {
                                            BE.tipref = string.Empty;
                                            BE.serref = string.Empty;
                                            BE.numref = string.Empty;
                                            try
                                            {
                                                BE.fechref = Convert.ToDateTime(fechref.Text.Trim());
                                            }
                                            catch
                                            {
                                                BE.fechref = Convert.ToDateTime("01/01/1900");
                                            }
                                        }
                                    }
                                }
                                if (ser_op.Text.Trim().Length > 0 && num_op.Text.Trim().Length > 0)
                                {
                                    BE.tip_op = "OP";
                                    BE.ser_op = ser_op.Text.Trim().PadLeft(4, '0');
                                    BE.num_op = num_op.Text.Trim().PadLeft(10, '0');
                                }
                                if (serfac.Text.Trim().Length > 0 && numfac.Text.Trim().Length > 0)
                                {
                                    BE.tipfac = tipfac.SelectedItem.ToString();
                                    BE.serfac = serfac.Text.Trim().ToString().PadLeft(4, '0');
                                    BE.numfac = numfac.Text.Trim().ToString().PadLeft(10, '0');
                                    try
                                    {
                                        BE.fechfac = Convert.ToDateTime(fechfac.Text.Trim());
                                    }
                                    catch
                                    {
                                        BE.fechfac = Convert.ToDateTime("01/01/1900");
                                    }
                                }
                                if (serguia.Text.Trim().Length > 0 && numguia.Text.Trim().Length > 0)
                                {
                                    BE.tipguia = tipguia.Text.Trim();
                                    BE.serguia = serguia.Text.Trim().ToString().PadLeft(4, '0');
                                    BE.numguia = numguia.Text.Trim().ToString().PadLeft(10, '0');
                                    try
                                    {
                                        BE.fechguia = Convert.ToDateTime(fechguia.Text.Trim());
                                    }
                                    catch
                                    {
                                        BE.fechguia = Convert.ToDateTime("01/01/1900");
                                    }
                                }
                                if (sernotac.Text.Trim().Length > 0 && numnotac.Text.Trim().Length > 0)
                                {
                                    BE.tipnotac = tipnotac.Text.Trim();
                                    BE.sernotac = sernotac.Text.Trim().ToString().PadLeft(4, '0');
                                    BE.numnotac = numnotac.Text.Trim().ToString().PadLeft(10, '0');
                                    try
                                    {
                                        BE.fechnotac = Convert.ToDateTime(fechnotac.Text.Trim());
                                    }
                                    catch
                                    {
                                        BE.fechnotac = Convert.ToDateTime("01/01/1900");
                                    }
                                }
                                if (vendperid.Text.Trim().Length > 0)
                                {
                                    BE.perdni = vendperid.Text.Trim().ToString();
                                }
                                ;
                                BE.ubige = "000000";
                                BE.cencosid = cencosid.Text.Trim().ToString();
                                BE.estacion = estacion.Text.Trim().ToString();

                                try
                                {
                                    BE.totdscto1 = Convert.ToDecimal(totdscto1.Text.Trim());
                                }
                                catch
                                {
                                    BE.totdscto1 = Convert.ToDecimal(0);
                                }
                                BE.tipimptoid = tipimptotasa.SelectedValue.ToString().Trim();
                                BE.incprec = incprec.Trim();
                                BE.items = Convert.ToDecimal(itemsT.Text.Trim());
                                BE.totpzas = Convert.ToDecimal(totpzas.Text.Trim());
                                BE.bruto = Convert.ToDecimal(bruto.Text.Trim());
                                BE.igv = igv;
                                BE.totimpto = Convert.ToDecimal(totimpto.Text.Trim());
                                BE.valventa = Convert.ToDecimal(valventa.Text.Trim());
                                BE.totimporte = Convert.ToDecimal(totimporte.Text.Trim());
                                BE.codctadebe = string.Empty;
                                BE.codctahaber = string.Empty;
                                BE.glosa = glosa.Text.Trim().ToUpper().ToString();
                                try
                                {
                                    BE.fechcancel = Convert.ToDateTime("01/01/1900");
                                }
                                catch
                                {
                                    BE.fechcancel = Convert.ToDateTime("01/01/1900");
                                }
                                try
                                {
                                    BE.fechentrega = Convert.ToDateTime(fechentrega.Text.Trim());
                                }
                                catch
                                {
                                    BE.fechentrega = Convert.ToDateTime("01/01/1900");
                                }
                                try
                                {
                                    BE.fechpago = Convert.ToDateTime(fechpago.Text.Trim());
                                }
                                catch
                                {
                                    BE.fechpago = Convert.ToDateTime("01/01/1900");
                                }
                                BE.transpid = transpid.Text.Trim().ToString();
                                if (motivotrasladoid.SelectedValue != null)
                                {
                                    BE.motivotrasladoid = motivotrasladoid.SelectedValue.ToString();
                                }
                                if (mottrasladointid.SelectedValue != null)
                                {
                                    BE.mottrasladointid = mottrasladointid.SelectedValue.ToString();
                                }
                                BE.ddnni = ddnni.Text.Trim();
                                BE.tipdid = string.Empty;
                                BE.statborrado = string.Empty;
                                BE.clientetipo = string.Empty;
                                BE.modofactu = string.Empty;
                                BE.tipodocmanejaserie = tipodocmanejaserie;

                                BE.perianio = fechdoc.Value.Year.ToString();
                                BE.perimes = fechdoc.Value.Month.ToString().PadLeft(2 , '0');
                                BE.status = "0";
                                BE.usuar = VariablesPublicas.Usuar;

                                var item = 0;
                                foreach (DataRow fila in Tabladetallemov.Rows)
                                {
                                    Detalle = new tb_60movimientos.Item();

                                    item++;

                                    Detalle.fechdoc = Convert.ToDateTime(fechdoc.Text);
                                    Detalle.moneda = moneda.SelectedValue.ToString().Trim();
                                    Detalle.tcamb = Convert.ToDecimal(tcamb.Text.Trim());
                                    Detalle.tipoperacionid = tipoperacionid.SelectedValue.ToString();
                                    Detalle.ctacteaccionid = string.Empty;
                                    Detalle.ctacte = ctacte.Text.Trim().ToUpper();
                                    Detalle.ctactename = ctactename.Text.Trim().ToUpper();
                                    Detalle.direcnume = direcnume.Trim().ToUpper();
                                    Detalle.direcname = direcname.Text.Trim().ToUpper();
                                    if (tipref.SelectedValue != null && serref.Text.Trim().Length > 0)
                                    {
                                        Detalle.tipref = tipref.SelectedValue.ToString();
                                        Detalle.serref = serref.Text.Trim().PadLeft(4, '0');
                                        Detalle.numref = numdococ1.Text.Trim() + numdococ.Text.Trim().PadLeft(6, '0');
                                        try
                                        {
                                            Detalle.fechref = Convert.ToDateTime(fechref.Text.Trim());
                                        }
                                        catch
                                        {
                                            Detalle.fechref = Convert.ToDateTime("01/01/1900");
                                        }
                                    }
                                    if (ser_op.Text.Trim().Length > 0 && num_op.Text.Trim().Length > 0)
                                    {
                                        Detalle.tip_op = "OP";
                                        Detalle.ser_op = ser_op.Text.Trim().PadLeft(4, '0');
                                        Detalle.num_op = num_op.Text.Trim().PadLeft(10, '0');
                                    }
                                    if (serfac.Text.Trim().Length > 0 && numfac.Text.Trim().Length > 0)
                                    {
                                        Detalle.tipfac = tipfac.SelectedItem.ToString();
                                        Detalle.serfac = serfac.Text.Trim().ToString().PadLeft(4, '0');
                                        Detalle.numfac = numfac.Text.Trim().ToString().PadLeft(10, '0');
                                        try
                                        {
                                            Detalle.fechfac = Convert.ToDateTime(fechfac.Text.Trim());
                                        }
                                        catch
                                        {
                                            Detalle.fechfac = Convert.ToDateTime("01/01/1900");
                                        }
                                    }
                                    if (serguia.Text.Trim().Length > 0 && numguia.Text.Trim().Length > 0)
                                    {
                                        Detalle.tipguia = tipguia.Text.Trim();
                                        Detalle.serguia = serguia.Text.Trim().ToString().PadLeft(4, '0');
                                        Detalle.numguia = numguia.Text.Trim().ToString().PadLeft(10, '0');
                                        try
                                        {
                                            Detalle.fechguia = Convert.ToDateTime(fechguia.Text.Trim());
                                        }
                                        catch
                                        {
                                            Detalle.fechguia = Convert.ToDateTime("01/01/1900");
                                        }
                                    }
                                    if (sernotac.Text.Trim().Length > 0 && numnotac.Text.Trim().Length > 0)
                                    {
                                        Detalle.tipnotac = tipnotac.Text.Trim();
                                        Detalle.sernotac = sernotac.Text.Trim().ToString().PadLeft(4, '0');
                                        Detalle.numnotac = numnotac.Text.Trim().ToString().PadLeft(10, '0');
                                        try
                                        {
                                            Detalle.fechnotac = Convert.ToDateTime(fechnotac.Text.Trim());
                                        }
                                        catch
                                        {
                                            Detalle.fechnotac = Convert.ToDateTime("01/01/1900");
                                        }
                                    }
                                    Detalle.cencosid = cencosid.Text.Trim();
                                    if (vendperid.Text.Trim().Length > 0)
                                    {
                                        BE.vendorid = vendperid.Text.Trim().ToString();
                                    }
                                    ;
                                    Detalle.itemref = fila["itemref"].ToString();
                                    Detalle.itemsdet = item.ToString().PadLeft(5, '0');
                                    Detalle.rollo = fila["rollo"].ToString();
                                    Detalle.productid = fila["productid"].ToString();
                                    Detalle.productname = fila["productname"].ToString();

                                    Detalle.cantidad = Convert.ToDecimal(fila["cantidad"].ToString());
                                    Detalle.valor = Convert.ToDecimal(fila["valor"].ToString());
                                    Detalle.precunit = Convert.ToDecimal(fila["precunit"].ToString());
                                    Detalle.importe = Convert.ToDecimal(fila["importe"].ToString());
                                    Detalle.importfac = Convert.ToDecimal(fila["importfac"].ToString());
                                    Detalle.totimpto = Convert.ToDecimal(fila["totimpto"].ToString());
                                    Detalle.Ubicacion = fila["ubicacion"].ToString().ToUpper();
                                    Detalle.unmed = fila["unmed"].ToString().Trim();

                                    Detalle.nserie = fila["nserie"].ToString().Trim();



                                    Detalle.almacaccionid = almacaccionid;
                                    if (motivotrasladoid.SelectedValue != null)
                                    {
                                        Detalle.motivotrasladoid = motivotrasladoid.SelectedValue.ToString();
                                    }
                                    if (mottrasladointid.SelectedValue != null)
                                    {
                                        Detalle.mottrasladointid = mottrasladointid.SelectedValue.ToString();
                                    }
                                    Detalle.statcostopromed = statcostopromed.Trim();
                                    Detalle.tiptransac = tiptransac.Trim();
                                    Detalle.incprec = incprec.Trim();
                                    Detalle.igv = igv;
                                    Detalle.glosa = glosa.Text.Trim().ToUpper().ToString();
                                    Detalle.codctadebe = string.Empty;
                                    Detalle.codctahaber = string.Empty;

                                    Detalle.perianio = fechdoc.Value.Year.ToString();
                                    Detalle.perimes = fechdoc.Value.Month.ToString().PadLeft(2, '0');
                                    Detalle.status = "0";
                                    Detalle.usuar = VariablesPublicas.Usuar;

                                    if (ssModo != "EDIT")
                                    {
                                        fila["productid"].ToString();
                                        fila["cantidad"].ToString();
                                        fila["importfac"].ToString();


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


                                BE.ListaItems = ListaItems;
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
                            var BL = new tb_60movimientosBL();
                            var BE = new tb_60movimientos();

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
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _ActualizarEstadoProducto()
        {
            if (tipoperacionid.SelectedValue.ToString() == "un parametro")
            {
                foreach (DataGridViewRow fila in griddetallemov.Rows)
                {
                    var BL = new tb_60productosBL();
                    var BE = new tb_60productos();

                    BE.moduloid = modulo.Trim();
                    BE.productid = Convert.ToString(griddetallemov.Rows[fila.Index].Cells["productid"].Value);
                    BE.status = string.Empty;
                    BL.Update(EmpresaID, BE);
                }
            }
        }

        private void Frm_movimiento_Load(object sender, EventArgs e)
        {
            modulo = ((APT600100.MainAlmacenPT)MdiParent).moduloid;
            local = ((APT600100.MainAlmacenPT)MdiParent).local;

            if (modulo == "0500")
            {
                pnlsys.Visible = true;
            }
            else
            {
                pnlsys.Visible = false;
            }

            PARAMETROS_TABLA();
            NIVEL_FORMS();

            data_cbo_tipodoc();
            data_cbo_tipodocalt();
            data_cbo_motivotrasladoid();
            data_cbo_moneda();
            _cal_Igv();
            get_tipimptoid();

            Tabladetallemov = new DataTable("detallemov");
            Tabladetallemov.Columns.Add("items", typeof(String));
            Tabladetallemov.Columns.Add("itemref", typeof(String));
            Tabladetallemov.Columns.Add("productid", typeof(String));
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
            Tabladetallemov.Columns.Add("precunit", typeof(Decimal));
            Tabladetallemov.Columns["precunit"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("importfac", typeof(Decimal));
            Tabladetallemov.Columns["importfac"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("totimpto", typeof(Decimal));
            Tabladetallemov.Columns["totimpto"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("almacaccionid", typeof(String));
            Tabladetallemov.Columns.Add("ubicacion", typeof(String));
            Tabladetallemov.Columns.Add("unmed", typeof(String));
            Tabladetallemov.Columns.Add("nserie", typeof(String));

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
        }

        private void Frm_movimiento_KeyDown(object sender, KeyEventArgs e)
        {
            if (tipref.SelectedIndex != 0)
            {
                if (e.KeyCode == Keys.Insert)
                {
                    if (!griddetallemov.ReadOnly)
                    {
                        btn_detanadir_Click(sender, e);
                    }
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
            perianio = string.Empty;
            perimes = string.Empty;
            almacaccionid = string.Empty;
            statcostopromed = string.Empty;
            tiptransac = string.Empty;
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
                    btn_cancelar.Enabled = true;
                    btn_grabar.Enabled = true;
                    btn_upload.Enabled = true;
                    btn_detanadir.Enabled = true;
                    btn_deteliminar.Enabled = true;
                    btn_attachedfile.Enabled = true;
                    ctacte.Focus();
                }
            }
            else
            {
                select_tipodoc();
                numdoc.Text = string.Empty;
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
                AyudaClientes(string.Empty);
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
                AyudaClientesDireccion(string.Empty);
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
                    var BL = new tb_co_tabla12_toperacionalmacenBL();
                    var BE = new tb_co_tabla12_toperacionalmacen();
                    var dt = new DataTable();
                    BE.codigoid = tipoperacionid.SelectedValue.ToString().Trim();
                    dt = BL.GetOne(EmpresaID, BE).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        statcostopromed = dt.Rows[0]["statcostopromed"].ToString().Trim();
                        tiptransac = dt.Rows[0]["tiptransac"].ToString().Trim();
                        if (dt.Rows[0]["mottrasladoint"].ToString().Trim() != string.Empty)
                        {
                            mottrasladointid.SelectedValue = dt.Rows[0]["mottrasladoint"].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta asignar [statcostopromed,tiptransac] !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (tipoperacionid.SelectedValue.ToString() == "02")
                {
                    griddetallemov.Columns["precunit"].ReadOnly = true;
                    ctacte.ReadOnly = true;
                    nmruc.ReadOnly = true;
                }
                else
                {
                    griddetallemov.Columns["precunit"].ReadOnly = false;
                    ctacte.ReadOnly = false;
                    nmruc.ReadOnly = false;
                }
            }
        }

        private void serref_KeyDown(object sender, KeyEventArgs e)
        {
            if (tipref.SelectedIndex != -1)
            {
                if (e.KeyCode == Keys.F1)
                {
                    AyudaDocref(string.Empty);
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
                    var numdo = string.Empty;
                    if (numdococ.Text.Trim().Length > 0)
                    {
                        numdo = numdococ.Text.Trim().PadLeft(6, '0');
                    }

                    numdococ.Text = numdo.ToString();
                    serref.Text = modulo;
                    ValidaDocref();

                    if (modulo.ToString() == "0500")
                    {
                        Tabla_detOC2();
                    }
                    else
                    {
                        Tabla_detOC();
                    }

                    Recalcular_Detalle();
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
            var numdo = string.Empty;
            if (serfac.Text.Trim().Length > 0)
            {
                numdo = serfac.Text.Trim().PadLeft(4, '0');
            }
            serfac.Text = numdo;
        }

        private void numfac_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(numdoc, e);
        }

        private void numfac_LostFocus(object sender, System.EventArgs e)
        {
            var numdo = string.Empty;
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
            var numdo = string.Empty;
            if (numguia.Text.Trim().Length > 0)
            {
                numdo = numguia.Text.Trim().PadLeft(10, '0');
            }
            numguia.Text = numdo;
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
                serfac.Enabled = false;
                serfac.Text = string.Empty;
                numfac.Enabled = false;
                numfac.Text = string.Empty;
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
                tipguia.Enabled = false;
                serguia.Enabled = false;
                serguia.Text = string.Empty;
                numguia.Enabled = false;
                numguia.Text = string.Empty;
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
                tipnotac.Enabled = false;
                sernotac.Enabled = false;
                sernotac.Text = string.Empty;
                numnotac.Enabled = false;
                numnotac.Text = string.Empty;
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
        }

        private void numdococ_LostFocus(object sender, System.EventArgs e)
        {
        }

        public bool _ValidaDocuOP()
        {
            var xsigo = true;

            try
            {
                var BL = new tb_60movimientosdetBL();
                var BE = new tb_60movimientosdet();
                var ds = new DataSet();

                BE.moduloid = modulo;
                BE.local = local;
                BE.ser_op = ser_op.Text.Trim();
                BE.num_op = num_op.Text.Trim();
                BE.tipodoc = tipodoc.SelectedValue.ToString();
                BE.serdoc = serdoc.Text.Trim();
                BE.numdoc = numdoc.Text.Trim();
                BE.almacaccionid = almacaccionid;

                ds = BL.Get_DocOP(EmpresaID, BE);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        var msg = "Error Ord.Prod Habilitado en:\n" +
                                     "----------------------------\n";
                        var msg2 = string.Empty;
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

        private void num_op_LostFocus(object sender, System.EventArgs e)
        {
            var numdo = string.Empty;
            if (num_op.Text.Trim().Length > 0)
            {
                numdo = num_op.Text.Trim().PadLeft(10, '0');
            }

            num_op.Text = numdo;
            if (!_ValidaDocuOP())
            {
                ser_op.Text = string.Empty;
                num_op.Text = string.Empty;
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
                AyudaCentroCosto(string.Empty);
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
        }

        private void vendedorid_LostFocus(object sender, System.EventArgs e)
        {
        }

        private void transpid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaTransportista(string.Empty);
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
                nuevo();
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
                    sw_prosigue = (MessageBox.Show("¿Desea Guardar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
                }
                if (sw_prosigue)
                {
                    Insert();
                }
            }
            else
            {
                if (XNIVEL == "0" || XNIVEL == "1")
                {
                    sw_prosigue = (MessageBox.Show("¿Desea Modificar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

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
                    var miForma = new REPORTES.Frm_reportes();

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
                    var miForma = new REPORTES.Frm_reportes();

                    miForma.dominioid = dominio.Trim();
                    miForma.moduloid = modulo.Trim();
                    miForma.local = local.Trim();

                    miForma.Text = "Reporte Movimientos de Productos";
                    miForma.formulario = "Frm_movimiento_rollos2";
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

        private void data_Tabladetallemovmov()
        {
            try
            {
                Decimal xxprecventa = 0, xxcostoultimo = 0, xxstock = 0, xxcostopromed = 0;
                griddetallemov.AutoGenerateColumns = false;

                var BL = new tb_60movimientosdetBL();
                var BE = new tb_60movimientosdet();
                var dt = new DataTable();
                BE.moduloid = modulo;

                if (modulo == "0500")
                {
                    griddetallemov.Columns[4].Visible = true;
                    griddetallemov.Columns[6].Visible = false;
                    griddetallemov.Width = 1085;
                }
                else
                {
                    if (modulo == "0330")
                    {
                        griddetallemov.Columns[4].Visible = false;
                        griddetallemov.Columns[6].Visible = true;
                    }
                    else
                    {
                        griddetallemov.Columns[4].Visible = false;
                        griddetallemov.Columns[6].Visible = false;
                    }
                }
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
                    var BL2 = new tb_60local_stockBL();
                    var BE2 = new tb_60local_stock();
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
                    row["nserie"] = fila["nserie"].ToString().Trim();
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
            var xproductid = string.Empty;
            Decimal xprecio = 0, xprecunit = 0, xcantidad = 0, xcostoprom = 0, tipcamb = 0;
            var desct1 = 0;
            Decimal imporfac = 0;
            Decimal import = 0;
            Decimal totimpx = 0;

            xproductid = valproductid.Trim();
            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productname"].Value = string.Empty;
            txt_stock.Text = "0";
            txt_valor.Text = "0";
            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["precunit"].Value = "0";
            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["importfac"].Value = "0";

            if (xproductid.Trim().Length == 13)
            {
                var BL = new tb_60local_stockBL();
                var BE = new tb_60local_stock();
                var DT = new DataTable();
                BE.moduloid = modulo.ToString();
                BE.local = local.ToString();
                BE.productid = xproductid;

                DT = BL.GetAll(EmpresaID, BE).Tables[0];

                if (DT.Rows.Count > 0)
                {
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productid"].Value = DT.Rows[0]["productid"].ToString().Trim();
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productname"].Value = DT.Rows[0]["productname"].ToString().Trim();
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["unmed"].Value = DT.Rows[0]["unmed"].ToString().Trim();
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["rollo"].Value = string.Empty;

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
                var BL = new tb_60local_stockBL();
                var BE = new tb_60local_stock();
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
                                AyudaProducto(string.Empty);
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
                        AyudaProducto(string.Empty);
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
                        Decimal precunit = 0, tipcamb = 0;
                        Decimal imporfac = 0;
                        var desct1 = 0;
                        Decimal totimpx = 0;
                        Decimal import = 0;
                        Decimal valor = 0;
                        Decimal xcantidad = 0, xprecio = 0, xstock = 0, xcostopromed = 0;
                        var xproductid = string.Empty;

                        xproductid = Convert.ToString(griddetallemov.Rows[fila.Index].Cells["productid"].Value);
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

                        precunit = Math.Round(Convert.ToDecimal(xprecio), 6);
                        tipcamb = Convert.ToDecimal(tcamb.Text.Trim());

                        if (tipcamb <= 0)
                        {
                            tipcamb = 1;
                        }

                        _cal_Igv();

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


                        if (almacaccionid.Trim().Substring(0, 1) == "2" && almacaccionid.Trim().Substring(0, 1) == "0")
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
                            if (almacaccionid.Trim().Substring(0, 1) == "1" && almacaccionid.Trim().Substring(0, 1) == "0")
                            {
                                valor = precunit;
                            }
                        }

                        var BL = new tb_60local_stockBL();
                        var BE = new tb_60local_stock();
                        var DT = new DataTable();
                        BE.moduloid = modulo;
                        BE.productid = xproductid;
                        DT = BL.GetAll(EmpresaID, BE).Tables[0];



                        if (moneda.SelectedValue.ToString() == "$")
                        {
                            if (tipref.SelectedIndex != -1)
                            {
                                if (tipref.SelectedValue.ToString() == "OC")
                                {
                                    precunit = xprecio;
                                }
                                else
                                {
                                    precunit = precunit * tipcamb;
                                    xprecio = xprecio / tipcamb;
                                }
                            }
                            else
                            {
                                precunit = precunit * tipcamb;
                                xprecio = xprecio / tipcamb;
                            }
                        }
                        else
                        {
                            if (moneda.Text == "S/.")
                            {
                            }
                        }

                        imporfac = Math.Round(xcantidad * Convert.ToDecimal(xprecio), 6);

                        griddetallemov.Rows[fila.Index].Cells["valor"].Value = precunit;
                        griddetallemov.Rows[fila.Index].Cells["importe"].Value = Math.Round(xcantidad * precunit, 6);
                        griddetallemov.Rows[fila.Index].Cells["precunit"].Value = xprecio;
                        griddetallemov.Rows[fila.Index].Cells["dtotimpto"].Value = totimpx;
                        griddetallemov.Rows[fila.Index].Cells["importfac"].Value = Math.Round(imporfac, 2);
                    }
                    calcular_totales();
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
            try
            {
                if (griddetallemov.CurrentRow != null)
                {
                    if (griddetallemov.Columns[e.ColumnIndex].Name.ToUpper() == "productid".ToUpper())
                    {
                        var xrollo = string.Empty;
                        xrollo = (griddetallemov.Rows[griddetallemov.CurrentRow.Index].Cells["rollo"].Value.ToString().Trim()).PadLeft(13, '0');
                        if (xrollo != "0000000000000")
                        {
                            ValidaTabladetallemovmov(xrollo);
                        }
                    }

                    if (griddetallemov.Columns[e.ColumnIndex].Name.ToUpper() == "cantidad".ToUpper() || griddetallemov.Columns[e.ColumnIndex].Name.ToUpper() == "precunit".ToUpper())
                    {
                        Decimal precunit = 0, tipcamb = 0;
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

                        Decimal lsStock = 0, dtCantidad = 0, mvCantidad = 0, dtstock = 0;
                        lsStock = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["stock_old"].Value);
                        dtCantidad = xcantidad;
                        mvCantidad = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad_old"].Value);

                        if (tipref.SelectedIndex != -1)
                        {
                            dtstock = Convert.ToDecimal(lsStock) - Convert.ToDecimal(dtCantidad);
                        }
                        else
                        {
                            if (almacaccionid.Substring(0, 1) == "1" && almacaccionid.Substring(1, 1) == "0")
                            {
                                dtstock = lsStock + dtCantidad - mvCantidad;
                            }
                            else
                            {
                                if (almacaccionid.Substring(0, 1) == "2" && almacaccionid.Substring(1, 1) == "0")
                                {
                                    dtstock = lsStock + mvCantidad;
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

                        precunit = Math.Round(Convert.ToDecimal(xprecio), 6);
                        tipcamb = Convert.ToDecimal(tcamb.Text.Trim());

                        if (almacaccionid.Trim().Substring(0, 1) == "2")
                        {
                            valor = Math.Round(Convert.ToDecimal(xcostopromed), 6);
                        }
                        else
                        {
                            if (almacaccionid.Trim().Substring(0, 1) == "1")
                            {
                                valor = precunit;
                            }
                        }

                        if (tipcamb <= 0)
                        {
                            tipcamb = 1;
                        }



                        Decimal xxvalor = 0;
                        xxvalor = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["valor"].Value);
                        if (xxvalor.ToString().Length == 0)
                        {
                            if (moneda.SelectedValue.ToString() == "$")
                            {
                            }
                        }

                        if (moneda.SelectedValue.ToString() == "$")
                        {
                            if (tipref.SelectedIndex != -1)
                            {
                                if (tipref.SelectedValue.ToString() == "OC")
                                {
                                    precunit = xprecio;
                                }
                                else
                                {
                                    precunit = precunit * tipcamb;
                                }
                            }
                            else
                            {
                                precunit = precunit * tipcamb;
                            }
                        }

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

                        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["valor"].Value = precunit;
                        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["importe"].Value = Math.Round(xcantidad * precunit, 6);

                        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["dtotimpto"].Value = totimpx;
                        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["importfac"].Value = Math.Round(imporfac, 6);
                    }
                }
                calcular_totales();
            }
            catch (Exception ex)
            {
                var error = string.Empty;
                error = ex.GetType().ToString();
                if (error == "System.Data.ConstraintException")
                {
                    MessageBox.Show("Producto ya existe..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (Exception ex)
            {
            }
        }

        private void _cal_Igv()
        {
            var xval_igv = Convert.ToInt32(tipimptotasa.SelectedValue);
            if (xval_igv == 1)
            {
                igv = 18;
            }
            else
            {
                igv = 0;
            }
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
                    var miForma = new REPORTES.Frm_reportes();

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

        private void btn_attachedfile_Click(object sender, EventArgs e)
        {
           
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
                else
                {
                    if (tipref.SelectedValue.ToString() == "OC")
                    {
                        numdococ.Enabled = true;
                        numdococ1.Enabled = true;
                        numdococ.Focus();
                    }
                }
            }
        }

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
                fechfac.Focus();
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
            var Proceso = new Process();
            Proceso.StartInfo.FileName = "calc.exe";
            Proceso.StartInfo.Arguments = string.Empty;
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

        private void Botonera_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }


        private void ser_op_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaOrdenProduccion(string.Empty);
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

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in griddetallemov.Rows)
            {
                var xproductid  = griddetallemov.Rows[fila.Index].Cells["productid"].Value.ToString();
                if (xproductid.Trim().Length == 13)
                {
                    var BL = new tb_60local_stockBL();
                    var BE = new tb_60local_stock();
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

        private void btn_pestacion_Click(object sender, EventArgs e)
        {
            //var frmPersona = new CATALOGO.Frm_persona_cencos();
            //frmPersona.ShowDialog();
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
        }

        private void RecibeProductosCencos(DataTable resultado)
        {
            if (resultado.Rows.Count > 0)
            {
                Tabladetallemov = resultado;
                griddetallemov.DataSource = Tabladetallemov;

                if (tipodoc.SelectedValue.ToString() == "VS" || tipodoc.SelectedValue.ToString() == "GS")
                {
                    var productidold = resultado.Rows[0]["productidold"].ToString();
                    cencosid.Text = Equivalencias.Left(productidold, 5);
                    ValidaCentroCosto(cencosid.Text, false);
                    var estacion = resultado.Rows[0]["estacion"].ToString();
                    ;

                    var BL2 = new tb_co_persona_cencosBL();
                    var BE2 = new tb_co_persona_cencosBE();

                    BE2.cencosid = cencosid.Text.ToString();
                    BE2.cencosestacion = estacion.ToString();
                    var dt2 = new DataTable();
                    dt2 = BL2.GetAll(EmpresaID, BE2).Tables[0];

                    if (dt2.Rows.Count > 0)
                    {
                        vendperid.Text = dt2.Rows[0]["perdni"].ToString();
                        vendpername.Text = dt2.Rows[0]["nombrelargo"].ToString();
                    }
                    else
                    {
                        vendperid.Text = string.Empty;
                        vendpername.Text = string.Empty;
                    }
                }

                _RecalculoGrid();
            }
        }

        private void estacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var numdo = string.Empty;
                if (estacion.Text.Trim().Length > 0)
                {
                    numdo = estacion.Text.Trim().PadLeft(3, '0');
                }
                estacion.Text = numdo;


                var BL2 = new tb_co_persona_cencosBL();
                var BE2 = new tb_co_persona_cencosBE();

                BE2.cencosid = cencosid.Text.ToString();
                BE2.cencosestacion = estacion.Text.ToString();
                var dt2 = new DataTable();
                dt2 = BL2.GetAll(EmpresaID, BE2).Tables[0];

                if (dt2.Rows.Count > 0)
                {
                    vendperid.Text = dt2.Rows[0]["perdni"].ToString();
                    vendpername.Text = dt2.Rows[0]["nombrelargo"].ToString();
                }
                else
                {
                    vendperid.Text = string.Empty;
                    vendpername.Text = string.Empty;
                }

                glosa.Focus();
            }
        }

        private void GenProductidOLD()
        {
            var BL = new tb_60productosBL();
            var BE = new tb_60productos();
            var dt = new DataTable();

            BE.moduloid = modulo.ToString();
            BE.cencosid = cencosid.Text.Trim() + estacion.Text.Trim();
            dt = BL.GenCodigo(EmpresaID, BE).Tables[0];

            dt.Rows[0]["item"].ToString().PadLeft(3, '0');

            foreach (DataGridViewRow fila in griddetallemov.Rows)
            {
                griddetallemov.Rows[fila.Index].Cells["productid"].Value.ToString();
            }
        }

        private void chk_activarColumn_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_activarColumn.Checked)
            {
                griddetallemov.Columns["precunit"].ReadOnly = false;
            }
            else
            {
                griddetallemov.Columns["precunit"].ReadOnly = true;
            }
        }

        private void numdocalt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var n = numdocalt.Text.PadLeft(10, '0').ToString();
                numdocalt.Text = n.ToString();
                form_cargar_datos2(string.Empty, Equivalencias.Left(cmbtipdocalt.SelectedValue.ToString(), 2), numdocalt.Text.ToString());
            }
        }


        private void form_cargar_datos2(String posicion, String tipdocalt, String numdocalt)
        {
            try
            {
                var BL = new tb_60movimientoscabBL();
                var BE = new tb_60movimientoscab();
                var dt = new DataTable();

                BE.moduloid = modulo;
                BE.local = local;
                BE.tipodoc = tipdocalt.ToString();

                if (serdoc.Text.Trim().Length > 0)
                {
                    BE.serdoc = serdoc.Text.Trim().PadLeft(4, '0');
                    BE.numdoc = numdocalt.ToString();
                }
                else
                {
                    if (posicion.Trim().Length > 0)
                    {
                        MessageBox.Show("Seleccionar el Tipo de Documento !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }
                if (numdocalt.ToString().Length > 0)
                {
                    BE.numdoc = numdocalt.ToString();
                }
                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    data_cbo_tiporeferencia(almacaccionid);
                    fechdoc.Text = dt.Rows[0]["fechdoc"].ToString().Trim();

                    tipimptoid = dt.Rows[0]["tipimptoid"].ToString().Trim();
                    direcnume = dt.Rows[0]["direcnume"].ToString().Trim();
                    incprec = dt.Rows[0]["incprec"].ToString().Trim();

                    moneda.SelectedValue = dt.Rows[0]["moneda"].ToString().Trim();
                    txtmoneda.Text = dt.Rows[0]["moneda"].ToString().Trim();
                    tcamb.Text = dt.Rows[0]["tcamb"].ToString().Trim();

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

                        var n = dt.Rows[0]["numref"].ToString().Trim();

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
                        tipfac.SelectedValue = dt.Rows[0]["tipfac"].ToString().Trim();
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
                    ValidaCentroCosto(dt.Rows[0]["cencosid"].ToString(), true);
                    estacion.Text = dt.Rows[0]["estacion"].ToString();
                    ValidaPersona(dt.Rows[0]["perdni"].ToString(), true);

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
                    ValidaTransportista(dt.Rows[0]["transpid"].ToString(), false);
                    ddnni.Text = dt.Rows[0]["ddnni"].ToString().Trim();
                    itemsT.Text = dt.Rows[0]["items"].ToString().Trim();
                    totpzas.Text = dt.Rows[0]["totpzas"].ToString().Trim();
                    bruto.Text = dt.Rows[0]["bruto"].ToString().Trim();
                    totdscto1.Text = dt.Rows[0]["totdscto1"].ToString().Trim();
                    valventa.Text = dt.Rows[0]["valventa"].ToString().Trim();
                    totimpto.Text = dt.Rows[0]["totimpto"].ToString().Trim();
                    totimporte.Text = dt.Rows[0]["totimporte"].ToString().Trim();
                    glosa.Text = dt.Rows[0]["glosa"].ToString().Trim();

                    DetalleMovimiento(tipdocalt.ToString(), numdocalt.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DetalleMovimiento(String xtipodocalt, String xnumdocalt)
        {
            try
            {
                Decimal xxprecventa = 0, xxcostoultimo = 0, xxstock = 0, xxcostopromed = 0;
                griddetallemov.AutoGenerateColumns = false;

                var BL = new tb_60movimientosdetBL();
                var BE = new tb_60movimientosdet();
                var dt = new DataTable();

                BE.moduloid = modulo;

                if (modulo == "0500")
                {
                    griddetallemov.Columns[4].Visible = true;
                    griddetallemov.Columns[6].Visible = false;
                    griddetallemov.Width = 1085;
                }
                else
                {
                    if (modulo == "0330")
                    {
                        griddetallemov.Columns[4].Visible = false;
                        griddetallemov.Columns[6].Visible = true;
                    }
                    else
                    {
                        griddetallemov.Columns[4].Visible = false;
                        griddetallemov.Columns[6].Visible = false;
                    }
                }
                BE.local = local;
                BE.tipodoc = xtipodocalt.ToString();
                BE.serdoc = serdoc.Text.Trim().PadLeft(4, '0');
                BE.numdoc = xnumdocalt.ToString();

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
                    var BL2 = new tb_60local_stockBL();
                    var BE2 = new tb_60local_stock();
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
                    row["nserie"] = fila["nserie"].ToString().Trim();
                    Tabladetallemov.Rows.Add(row);
                }
                griddetallemov.DataSource = Tabladetallemov;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
