using System;
using System.Collections.Generic;
using System.Data;

using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;

using LayerDataAccess;
using System.Data.SqlClient;

namespace BapFormulariosNet.MERCADERIA
{
    public partial class Frm_liquidacion_importacion : plantilla
    {
        private String EmpresaID = string.Empty;
        private String dominio = "L0";
        private String modulo = string.Empty;
        private String moduloid = string.Empty;
        private String local = string.Empty;
        private String dominioiddes = "60";

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable TablaDetalleImportacion;
        private DataTable TablaDetalleImportacion2;
        private DataRow row;
        private Boolean statusDoc = true;
        private Boolean activeDoc = false;

        private String tipimptoid = string.Empty;
        private String incprec = "N";
        private String ssModo = "NEW";
        private Decimal xvalventa = 0;

        private DataTable Tablabloqueo;
        private DataTable TablaCabeceras;

        private Int32 n1 = 0, n2 = 0, n3 = 0;
        private Int32 d1 = 0, d2 = 0, d3 = 0;
        public Frm_liquidacion_importacion()
        {
            InitializeComponent();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
            {
                activeDoc = true;
                nuevo();
                TableLoadRowLock();
            }
        }

        private void nuevo()
        {
            moduloiddes.SelectedIndex = 0;
            limpiar_documento();
            form_bloqueado(false);
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            pictureEdit1.Visible = false;
            ssModo = "NEW";
            serdoc.Enabled = false;
            numdoc.Enabled = false;
        }

        private void NIVEL_FORMS()
        {
            XNIVEL = VariablesPublicas.Get_nivelperfil(VariablesPublicas.Perfil, Name).Substring(0, 1);
            if (XNIVEL != "0")
            {
                btn_clave.Image = global::BapFormulariosNet.Properties.Resources.btn_Lock20;
            }
            else
            {
                btn_clave.Image = global::BapFormulariosNet.Properties.Resources.btn_Un_Lock20;
            }
        }

        private void limpiar_documento()
        {
            try
            {
                NIVEL_FORMS();

                tipdoc.Text = "LI";

                tipimptoid = string.Empty;
                incprec = "N";
                ssModo = "NEW";

                fechdoc.Text = string.Empty;

                ctacte.Text = string.Empty;
                ctactename.Text = string.Empty;
                paisid.Text = string.Empty;
                paisname.Text = string.Empty;

                tipguia.Text = "GI";
                serguia.Text = "0001";
                numguia.Text = string.Empty;

                tipfac.Text = string.Empty;
                serfac.Text = string.Empty;
                numfac.Text = string.Empty;

                tipref.Text = string.Empty;
                numdococ1.Text = string.Empty;
                numdococ.Text = string.Empty;

                cif.Text = "0.00";
                dua.Text = "0.00";
                gas_impo.Text = "0.00";
                gas_financ.Text = "0.00";
                factorincre.Text = "0.00";

                tot_bimp.Text = "0.00";


                TablaDetalleImportacion2.Rows.Clear();
                dgb_importacion2.DataSource = TablaDetalleImportacion2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void TableLoadRowLock()
        {
            var BE = new tb_cm_conceptos();
            var BL = new tb_cm_conceptoBL();
            BE.filtro = "2";

            if (Tablabloqueo != null)
            {
                Tablabloqueo.Clear();
            }

            Tablabloqueo = BL.Upload_row(EmpresaID, BE).Tables[0];
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

                tipdoc.Enabled = false;
                serdoc.Enabled = false;

                fechdoc.Enabled = false;

                ctacte.Enabled = false;
                ctactename.Enabled = false;
                paisid.Enabled = false;
                paisname.Enabled = false;

                tipguia.Enabled = false;
                serguia.Enabled = false;
                numguia.Enabled = var;

                localdes.Enabled = var;

                tipfac.Enabled = false;
                serfac.Enabled = false;
                numfac.Enabled = false;

                tipref.Enabled = false;
                numdococ1.Enabled = false;
                numdococ.Enabled = false;

                cif.Enabled = false;
                dua.Enabled = false;
                gas_impo.Enabled = false;
                gas_financ.Enabled = false;
                factorincre.Enabled = false;

                tot_bimp.Enabled = false;

                dgb_importacion.ReadOnly = !var;
                dgb_importacion.Columns["conceptoid"].ReadOnly = true;
                dgb_importacion.Columns["conceptoname"].ReadOnly = true;

                dgb_importacion2.Enabled = var;


                btn_nuevo.Enabled = false;
                btn_editar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_grabar.Enabled = false;

                btn_eliminar.Enabled = false;
                btn_imprimir.Enabled = false;

                btn_primero.Enabled = false;
                btn_anterior.Enabled = false;
                btn_siguiente.Enabled = false;
                btn_ultimo.Enabled = false;

                btn_clave.Enabled = true;
                btn_log.Enabled = true;
                btn_salir.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            form_accion_cancelEdicion(1);
        }

        private void form_accion_cancelEdicion(int confirnar)
        {
            var sw_prosigue = true;
            if (confirnar == 1)
            {
                sw_prosigue = (MessageBox.Show("Desea Cancelar iIngreso de Datos...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
            }
            else
            {
                sw_prosigue = true;
            }

            if (sw_prosigue)
            {
                limpiar_documento();
                moduloiddes.SelectedIndex = 0;


                TablaDetalleImportacion2.Clear();
                dgb_importacion2.DataSource = TablaDetalleImportacion2;


                moduloiddes.Enabled = false;
                form_bloqueado(false);
                numdoc.Text = string.Empty;
                btn_nuevo.Enabled = true;
                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;

                btn_salir.Enabled = true;

                ssModo = "NEW";
                fechdoc.Value = DateTime.Today;
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
                    if (numdoc.Text.Trim().Length == 6)
                    {
                        var BL = new tb_cm_liquidadetBL();
                        var BE = new tb_cm_liquidadet();

                        BE.tipdoc = tipdoc.Text.ToString();
                        BE.serdoc = moduloiddes.SelectedValue.ToString();
                        BE.numdoc = serdoc.Text.Trim() + numdoc.Text.Trim();
                        BE.usuar = VariablesPublicas.Usuar.ToString().Trim();

                        if (BL.Delete(EmpresaID, BE))
                        {
                            NIVEL_FORMS();
                            MessageBox.Show("Datos Eliminados Correctamente !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limpiar_documento();
                            form_bloqueado(false);
                            tipdoc.Enabled = false;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0")
            {
                ssModo = "EDIT";
                activeDoc = true;
                form_bloqueado(true);

                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
            }
        }

        private void btn_clave_Click(object sender, EventArgs e)
        {
            try
            {
                var miForma = new Ayudas.Form_user_admin();
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

        private void btn_salir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quieres cerrar el formulario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void PARAMETROS_TABLA()
        {
            var xxferfil = string.Empty;
            var f = (DL0Logistica.MainLogistica)MdiParent;
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

        private void Frm_liquidacion_importacion_Load(object sender, EventArgs e)
        {
            try
            {
                EmpresaID = VariablesPublicas.EmpresaID.Trim();
                moduloid = VariablesPublicas.Moduloid.Trim();
                local = VariablesPublicas.Local.Trim();

                PARAMETROS_TABLA();
                data_cbo_moduloiddes();
                _ArmandoTabla();
                limpiar_documento();
                _MetodoCabeceras();
                TableLoadRowLock();
                form_bloqueado(false);
                btn_nuevo.Enabled = true;
                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;
                btn_salir.Enabled = true;
                numdoc.Text = string.Empty;
                dgb_importacion.Visible = false;
                pictureEdit1.Visible = false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void _ArmandoTabla()
        {
            TablaDetalleImportacion2 = new DataTable("TablaDetalleImportacion2");

            TablaDetalleImportacion2.Columns.Add("tipdoc", typeof(String));
            TablaDetalleImportacion2.Columns.Add("serdoc", typeof(String));
            TablaDetalleImportacion2.Columns.Add("numdoc", typeof(String));
            TablaDetalleImportacion2.Columns.Add("conceptoid", typeof(String));
            TablaDetalleImportacion2.Columns.Add("ctacte", typeof(String));
            TablaDetalleImportacion2.Columns.Add("tipbou", typeof(String));
            TablaDetalleImportacion2.Columns.Add("serbou", typeof(String));
            TablaDetalleImportacion2.Columns.Add("numbou", typeof(String));
            TablaDetalleImportacion2.Columns.Add("fechbou", typeof(DateTime));
            TablaDetalleImportacion2.Columns.Add("bimp_sunat2", typeof(Decimal));
            TablaDetalleImportacion2.Columns["bimp_sunat2"].DefaultValue = 0;
            TablaDetalleImportacion2.Columns.Add("tipcamb", typeof(Decimal));
            TablaDetalleImportacion2.Columns["tipcamb"].DefaultValue = 0;
            TablaDetalleImportacion2.Columns.Add("bimp_sunat1", typeof(Decimal));
            TablaDetalleImportacion2.Columns["bimp_sunat1"].DefaultValue = 0;
            TablaDetalleImportacion2.Columns.Add("pven", typeof(Decimal));
            TablaDetalleImportacion2.Columns["pven"].DefaultValue = 0;
            TablaDetalleImportacion2.Columns.Add("usuar", typeof(String));
            TablaDetalleImportacion2.Columns.Add("status", typeof(String));
        }

        private void data_cbo_moduloiddes()
        {
            try
            {
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                BE.dominioid = dominioiddes.Trim();

                var dt = new DataTable();
                BE.status = "0";
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                moduloiddes.DataSource = dt;
                moduloiddes.ValueMember = "moduloid";
                moduloiddes.DisplayMember = "moduloname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void data_cbo_localdes(String dominioid, String moduloid)
        {
            try
            {
                var BL = new sys_localBL();
                var BE = new tb_sys_local();
                BE.dominioid = dominioid;
                BE.moduloid = moduloid;

                var dt = new DataTable();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    VariablesPublicas.localdirec = dt.Rows[0]["localdirec"].ToString();
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

        private void form_cargar_datos(String posicion)
        {
            try
            {
                limpiar_documento();
                var BL = new tb_cm_liquidacabBL();
                var BE = new tb_cm_liquidacab();
                var dt = new DataTable();

                BE.moduloid = moduloiddes.SelectedValue.ToString();
                BE.local = local.Trim();
                BE.tipdoc = tipdoc.Text.Trim();
                BE.serdoc = moduloiddes.SelectedValue.ToString();

                if (serdoc.Text.Trim().Length == 0)
                {
                    if (posicion.Trim().Length > 0)
                    {
                        MessageBox.Show("Seleccionar el Tipo de Documento !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }

                var n_doc = string.Empty;
                if (numdoc.Text.Trim().Length > 0)
                {
                    n_doc = numdoc.Text.Trim().PadLeft(6, '0');
                }

                BE.numdoc = serdoc.Text.ToString().Trim() + n_doc.ToString().Trim();
                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    activeDoc = false;
                    limpiar_documento();
                    form_bloqueado(false);
                    ssModo = "EDIT";

                    var BL2 = new tb_60movimientoscabBL();
                    var BE2 = new tb_60movimientoscab();
                    var dt2 = new DataTable();

                    var n = dt.Rows[0]["numdoc"].ToString().Trim();

                    serdoc.Text = Equivalencias.Left(n, 4);
                    numdoc.Text = Equivalencias.Right(n, 6);

                    tipguia.Text = dt.Rows[0]["tipref"].ToString().Trim();
                    serguia.Text = dt.Rows[0]["serref"].ToString().Trim();
                    numguia.Text = dt.Rows[0]["numref"].ToString().Trim();

                    cif.Text = dt.Rows[0]["cif"].ToString().Trim();
                    dua.Text = dt.Rows[0]["dua"].ToString().Trim();
                    gas_impo.Text = dt.Rows[0]["gas_impo"].ToString().Trim();
                    gas_financ.Text = dt.Rows[0]["gas_financ"].ToString().Trim();
                    tot_bimp.Text = dt.Rows[0]["tot_bimp"].ToString().Trim();
                    factorincre.Text = dt.Rows[0]["factorincre"].ToString().Trim();

                    moduloiddes.SelectedValue = dt.Rows[0]["moduloid"].ToString().Trim();
                    data_cbo_localdes(dominioiddes, moduloiddes.SelectedValue.ToString());
                    localdes.SelectedValue = dt.Rows[0]["local"].ToString().Trim();

                    BE2.moduloid = moduloiddes.SelectedValue.ToString();
                    BE2.local = localdes.SelectedValue.ToString();
                    BE2.tipodoc = tipguia.Text.ToString();
                    BE2.serdoc = serguia.Text.ToString();
                    BE2.numdoc = numguia.Text;

                    dt2 = BL2.GetAll2(EmpresaID, BE2).Tables[0];

                    if (dt2.Rows.Count > 0)
                    {
                        tipfac.Text = dt2.Rows[0]["tipfac"].ToString();
                        serfac.Text = dt2.Rows[0]["serfac"].ToString();
                        numfac.Text = dt2.Rows[0]["numfac"].ToString();

                        tipref.Text = dt2.Rows[0]["tipref"].ToString();
                        numdococ1.Text = Equivalencias.Left(dt2.Rows[0]["numref"].ToString(), 4);
                        numdococ.Text = Equivalencias.Right(dt2.Rows[0]["numref"].ToString(), 6);
                        ctacte.Text = dt2.Rows[0]["ctacte"].ToString();
                        ctactename.Text = dt2.Rows[0]["ctactename"].ToString();
                    }

                    _CargarDetalleImportacion();

                    if (dt.Rows[0]["status"].ToString().Trim() != "9")
                    {
                        btn_nuevo.Enabled = true;
                        btn_editar.Enabled = true;
                        btn_eliminar.Enabled = true;
                        btn_imprimir.Enabled = true;
                        btn_primero.Enabled = true;
                        btn_anterior.Enabled = true;
                        btn_siguiente.Enabled = true;
                        btn_ultimo.Enabled = true;
                        btn_salir.Enabled = true;
                        pictureEdit1.Visible = false;
                    }
                    else
                    {
                        ssModo = "ANULADO";
                        if (TablaDetalleImportacion2.Rows.Count > 0)
                        {
                            TablaDetalleImportacion2.Clear();
                        }
                        dgb_importacion2.DataSource = TablaDetalleImportacion2;
                        pictureEdit1.Visible = true;
                        btn_editar.Enabled = false;
                        btn_eliminar.Enabled = false;
                        btn_nuevo.Enabled = true;
                        btn_imprimir.Enabled = true;

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

        private void moduloiddes_SelectedIndexChanged(object sender, EventArgs e)
        {
            statusDoc = true;
            localdes.SelectedIndexChanged -= new EventHandler(localdes_SelectedIndexChanged);

            if (btn_nuevo.Enabled == false)
            {
                data_cbo_localdes(dominioiddes, moduloiddes.SelectedValue.ToString());
                moduloid = moduloiddes.SelectedValue.ToString();
                limpiar_documento();
                select_tipodoc();

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
            }
            else
            {
                moduloid = moduloiddes.SelectedValue.ToString();
                select_tipodoc();
                numdoc.Text = string.Empty;
            }
        }

        private void select_tipodoc()
        {
            try
            {
                var BL = new modulo_local_tipodocseriesBL();
                var BE = new tb_modulo_local_tipodocseries();
                var dt = new DataTable();

                BE.moduloid = moduloiddes.SelectedValue.ToString();
                BE.perianio = VariablesPublicas.perianio;

                dt = BL.CmLiqDocSeries_New(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    serdoc.Text = dt.Rows[0]["perianio"].ToString();
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
                statusDoc = false;
            }
        }

        private void get_CmDocSeries_numLiquidacion()
        {
            try
            {
                var BL = new modulo_local_tipodocseriesBL();
                var BE = new tb_modulo_local_tipodocseries();
                var dt = new DataTable();

                BE.dominioid = dominioiddes;
                BE.moduloid = moduloiddes.SelectedValue.ToString();
                BE.local = localdes.SelectedValue.ToString();
                BE.tipodoc = tipdoc.Text.Trim().ToString();

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

                        btn_cancelar.Enabled = true;
                        btn_grabar.Enabled = true;
                        fechdoc.Focus();
                    }
                }
            }
        }

        private void _CargarDetalle()
        {
            var BL = new tb_cm_conceptoBL();
            var BE = new tb_cm_conceptos();
            BE.filtro = "1";
            TablaDetalleImportacion = BL.GetAll(EmpresaID, BE).Tables[0];

            if (TablaDetalleImportacion.Rows.Count > 0)
            {
                dgb_importacion2.DataSource = TablaDetalleImportacion;
            }
        }

        private void _CargarDetalleImportacion()
        {
            var BE = new tb_cm_liquidadet();
            var BL = new tb_cm_liquidadetBL();
            var dt = new DataTable();

            BE.tipdoc = tipdoc.Text.Trim();
            BE.serdoc = moduloiddes.SelectedValue.ToString();

            var n_doc = string.Empty;
            if (numdoc.Text.Trim().Length > 0)
            {
                n_doc = numdoc.Text.Trim().PadLeft(6, '0');
            }
            BE.numdoc = serdoc.Text.ToString().Trim() + n_doc.ToString().Trim();

            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                dgb_importacion2.DataSource = dt;
            }
        }

        private void numguia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var num = string.Empty;
                num = numguia.Text.ToString().PadLeft(10, '0');
                numguia.Text = num;

                var BL = new tb_me_movimientoscabBL();
                var BE = new tb_me_movimientoscab();
                var dt = new DataTable();

                BE.moduloid = moduloiddes.SelectedValue.ToString();
                BE.local = localdes.SelectedValue.ToString();
                BE.tipodoc = tipguia.Text.ToString();
                BE.serdoc = serguia.Text.ToString();
                BE.numdoc = numguia.Text;

                dt = BL.GetAll2(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moneda"].ToString() == "S")
                    {
                        MessageBox.Show("Documento de referencia no puede ser en Moneda Nacional, verifique ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var xfechdoc = Convert.ToDateTime(dt.Rows[0]["fechdoc"]);

                    if (Convert.ToString(xfechdoc.Year) != serdoc.Text.ToString().Trim())
                    {
                        MessageBox.Show("Documento de Referencia NO ES DEL PERIODO ACTUAL, verifique ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    tipfac.Text = dt.Rows[0]["tipfac"].ToString();
                    serfac.Text = dt.Rows[0]["serfac"].ToString();
                    numfac.Text = dt.Rows[0]["numfac"].ToString();

                    tipref.Text = dt.Rows[0]["tipref"].ToString();
                    numdococ1.Text = Equivalencias.Left(dt.Rows[0]["numref"].ToString(), 4);
                    numdococ.Text = Equivalencias.Right(dt.Rows[0]["numref"].ToString(), 6);

                    ctacte.Text = dt.Rows[0]["ctacte"].ToString();
                    ctactename.Text = dt.Rows[0]["ctactename"].ToString();
                    _validaPais();
                }
                else
                {
                    MessageBox.Show("NO SE UBICÓ documento de referencia ó se encuentra ANULADO, verifique ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _CargarDetalle();

                if (dt.Rows.Count > 0)
                {
                    for (var i = 0; i < dgb_importacion1.RowCount; i++)
                    {
                        var codi = dgb_importacion1.GetRowCellValue(i, "conceptoid").ToString();

                        if (codi.Trim() == "101")
                        {
                            dgb_importacion1.SetRowCellValue(i, "ctacte", dt.Rows[0]["ctacte"].ToString());
                            dgb_importacion1.SetRowCellValue(i, "proveedor", dt.Rows[0]["ctactename"].ToString());
                            dgb_importacion1.SetRowCellValue(i, "tipbou", dt.Rows[0]["tipfac"].ToString());
                            dgb_importacion1.SetRowCellValue(i, "serbou", dt.Rows[0]["serfac"].ToString());
                            dgb_importacion1.SetRowCellValue(i, "numbou", dt.Rows[0]["numfac"].ToString());
                            dgb_importacion1.SetRowCellValue(i, "fechbou", dt.Rows[0]["fechfac"].ToString());
                            dgb_importacion1.SetRowCellValue(i, "tipcamb", dt.Rows[0]["tcamb"].ToString());
                            dgb_importacion1.SetRowCellValue(i, "migv", dt.Rows[0]["igv"].ToString());
                            dgb_importacion1.SetRowCellValue(i, "bimp_sunat2", dt.Rows[0]["valventa"].ToString());
                            Decimal ximp_me = 0;
                            var ximp_mn = 0;
                            Decimal xtcamb = 0;
                            ximp_me = Convert.ToDecimal(dt.Rows[0]["valventa"].ToString());
                            xtcamb = Convert.ToDecimal(dt.Rows[0]["tcamb"].ToString());
                            xvalventa = (ximp_me * xtcamb) + ximp_mn;
                            dgb_importacion1.SetRowCellValue(i, "pven", xvalventa);
                        }
                    }
                }
                else
                {
                    limpiar_documento();
                }

                dgb_importacion1.Focus();
            }
        }

        private void _validaPais()
        {
            var Query = " SELECT tc.paisid,tp.paisname FROM tb_cliente AS tc " +
                           " INNER JOIN tb_pais AS tp ON tc.paisid = tp.paisid " +
                           " WHERE tc.ctacte ='" + ctacte.Text.ToString().Trim() + "' ";
            var dt = new DataTable();
            dt = Consultas(Query).Tables[0];
            foreach (DataRow fila in dt.Rows)
            {
                paisid.Text = fila["paisid"].ToString();
                paisname.Text = fila["paisname"].ToString();
            }
        }

        private void _Pintar()
        {
            foreach (DataGridViewRow fila in dgb_importacion.Rows)
            {
                var Cod = dgb_importacion.Rows[fila.Index].Cells["conceptoid"].Value.ToString();

                if (Cod.Trim().Length == 1)
                {
                    dgb_importacion.Rows[fila.Index].DefaultCellStyle.BackColor = Color.FromArgb(25, 25, 112);
                    dgb_importacion.Rows[fila.Index].DefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
                    dgb_importacion.Rows[fila.Index].ReadOnly = true;
                }

                if (Cod.Trim().Length == 3)
                {
                    dgb_importacion.Rows[fila.Index].DefaultCellStyle.BackColor = Color.FromArgb(123, 104, 238);
                    dgb_importacion.Rows[fila.Index].DefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
                }
            }
        }

        private void dgb_importacion_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgb_importacion[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(255, 255, 0);
            dgb_importacion[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(0, 0, 0);
        }

        private void dgb_importacion1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
        }

        private void dgb_importacion1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "pven")
            {
                _AcmImportes();
            }
            if (e.Column.FieldName == "bimp_sunat1")
            {
                _AcmSunat(e.Column.FieldName);
                _CalculandoImporte();
                _CalculaTotales();
            }
            if (e.Column.FieldName == "bimp_sunat2")
            {
                _AcmSunat(e.Column.FieldName);
                _CalculandoImporte();
                _CalculaTotales();
            }
            if (e.Column.FieldName == "tipcamb")
            {
                _CalculandoImporte();
                _CalculaTotales();
            }

            _FactorIncre();
        }

        private void _AcmImportes()
        {
            Decimal ximpo1 = 0, ximpo2 = 0, ximpo3 = 0;

            if (n1 == 0)
            {
                for (var i = 0; i < dgb_importacion1.RowCount; i++)
                {
                    var codi = dgb_importacion1.GetRowCellValue(i, "conceptoid").ToString();

                    if (Equivalencias.Left(codi.Trim(), 1) == TablaCabeceras.Rows[0][0].ToString().Trim())
                    {
                        var n = i + 1;
                        var xn = Convert.ToDecimal(dgb_importacion1.GetRowCellValue(n, "pven").ToString());
                        if (n == Convert.ToInt32(TablaCabeceras.Rows[1][1].ToString().Trim()))
                        {
                            xn = 0;
                        }
                        ximpo1 = ximpo1 + xn;
                    }
                }

                n1 = n1 + 1;
                if (ximpo1 >= 0)
                {
                    dgb_importacion1.SetRowCellValue(Convert.ToInt32(TablaCabeceras.Rows[0][1].ToString()), "pven", ximpo1);
                    n1 = 0;
                    return;
                }
            }


            if (n2 == 0)
            {
                for (var i = 0; i < dgb_importacion1.RowCount; i++)
                {
                    var codi = dgb_importacion1.GetRowCellValue(i, "conceptoid").ToString();

                    if (Equivalencias.Left(codi.Trim(), 1) == TablaCabeceras.Rows[1][0].ToString().Trim())
                    {
                        var n = i + 1;
                        var xn = Convert.ToDecimal(dgb_importacion1.GetRowCellValue(n, "pven").ToString());
                        if (n == Convert.ToInt32(TablaCabeceras.Rows[2][1].ToString().Trim()))
                        {
                            xn = 0;
                        }
                        ximpo2 = ximpo2 + xn;
                    }
                }

                n2 = n2 + 1;
                if (ximpo2 >= 0)
                {
                    dgb_importacion1.SetRowCellValue(Convert.ToInt32(TablaCabeceras.Rows[1][1].ToString()), "pven", ximpo2);
                    n2 = 0;
                    return;
                }
            }

            if (n3 == 0)
            {
                for (var i = 0; i < dgb_importacion1.RowCount; i++)
                {
                    var codi = dgb_importacion1.GetRowCellValue(i, "conceptoid").ToString();

                    if (Equivalencias.Left(codi.Trim(), 1) == TablaCabeceras.Rows[2][0].ToString().Trim())
                    {
                        var n = i + 1;
                        if (n < dgb_importacion1.RowCount)
                        {
                            var xn = Convert.ToDecimal(dgb_importacion1.GetRowCellValue(n, "pven").ToString());
                            ximpo3 = ximpo3 + xn;
                        }
                    }
                }

                n3 = n3 + 1;
                if (ximpo3 >= 0)
                {
                    dgb_importacion1.SetRowCellValue(Convert.ToInt32(TablaCabeceras.Rows[2][1].ToString()), "pven", ximpo3);
                    n3 = 0;
                    return;
                }
            }
        }

        private void _AcmSunat(String Column_Name)
        {
            Decimal xsunat1 = 0, xsunat2 = 0, xsunat3 = 0;

            if (d1 == 0)
            {
                for (var i = 0; i < dgb_importacion1.RowCount; i++)
                {
                    var codi = dgb_importacion1.GetRowCellValue(i, "conceptoid").ToString();
                    if (Equivalencias.Left(codi.Trim(), 1) == TablaCabeceras.Rows[0][0].ToString().Trim())
                    {
                        var n = i + 1;
                        var xn = Convert.ToDecimal(dgb_importacion1.GetRowCellValue(n, Column_Name).ToString());
                        if (n == Convert.ToInt32(TablaCabeceras.Rows[1][1].ToString().Trim()))
                        {
                            xn = 0;
                        }
                        xsunat1 = xsunat1 + xn;
                    }
                }
                d1 = d1 + 1;
                if (xsunat1 >= 0)
                {
                    dgb_importacion1.SetRowCellValue(Convert.ToInt32(TablaCabeceras.Rows[0][1].ToString()), Column_Name, xsunat1);
                    d1 = 0;
                    return;
                }
            }


            if (d2 == 0)
            {
                for (var i = 0; i < dgb_importacion1.RowCount; i++)
                {
                    var codi = dgb_importacion1.GetRowCellValue(i, "conceptoid").ToString();

                    if (Equivalencias.Left(codi.Trim(), 1) == TablaCabeceras.Rows[1][0].ToString().Trim())
                    {
                        var n = i + 1;
                        var xn = Convert.ToDecimal(dgb_importacion1.GetRowCellValue(n, Column_Name).ToString());
                        if (n == Convert.ToInt32(TablaCabeceras.Rows[2][1].ToString().Trim()))
                        {
                            xn = 0;
                        }
                        xsunat2 = xsunat2 + xn;
                    }
                }

                d2 = d2 + 1;
                if (xsunat2 >= 0)
                {
                    dgb_importacion1.SetRowCellValue(Convert.ToInt32(TablaCabeceras.Rows[1][1].ToString()), Column_Name, xsunat2);
                    d2 = 0;
                    return;
                }
            }

            if (d3 == 0)
            {
                for (var i = 0; i < dgb_importacion1.RowCount; i++)
                {
                    var codi = dgb_importacion1.GetRowCellValue(i, "conceptoid").ToString();

                    if (Equivalencias.Left(codi.Trim(), 1) == TablaCabeceras.Rows[2][0].ToString().Trim())
                    {
                        var n = i + 1;
                        if (n < dgb_importacion1.RowCount)
                        {
                            var xn = Convert.ToDecimal(dgb_importacion1.GetRowCellValue(n, Column_Name).ToString());
                            xsunat3 = xsunat3 + xn;
                        }
                    }
                }

                d3 = d3 + 1;
                if (xsunat3 >= 0)
                {
                    dgb_importacion1.SetRowCellValue(Convert.ToInt32(TablaCabeceras.Rows[2][1].ToString()), Column_Name, xsunat3);
                    d3 = 0;
                    return;
                }
            }
        }

        private void _MetodoCabeceras()
        {
            var Query = " SELECT conceptoid,fila  FROM tb_cm_liq_conceptos AS ttc " +
                           " WHERE LEN(ttc.conceptoid) = 1 ";

            TablaCabeceras = Consultas(Query).Tables[0];
        }

        private void dgb_importacion1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "fechbou")
            {
                e.RepositoryItem = repositoryItemDateEdit1;
            }
            if (e.Column.FieldName == "bimp_sunat2")
            {
                e.RepositoryItem = TextEdit1;
            }
            if (e.Column.FieldName == "bimp_sunat1")
            {
                e.RepositoryItem = TextEdit1;
            }
            if (e.Column.FieldName == "tipcamb")
            {
                e.RepositoryItem = TextEdit1;
            }

            for (var i = 0; i < Tablabloqueo.Rows.Count; i++)
            {
                var n = Convert.ToInt32(Tablabloqueo.Rows[i][0].ToString());
                if (e.RowHandle == n)
                {
                    e.RepositoryItem = re_readonly;
                }
            }
        }

        private void exportarExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfdliquidacion.ShowDialog(this) == DialogResult.OK)
            {
                dgb_importacion1.ExportToXls(sfdliquidacion.FileName);
            }
        }

        private void dgb_importacion1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            switch (dgb_importacion1.FocusedColumn.Name)
            {
                case "go_bimp_sunat2":
                    if (Convert.ToDecimal(e.Value) < 0)
                    {
                        e.Valid = false;
                    }
                    break;

                case "go_bimp_sunat1":
                    if (Convert.ToDecimal(e.Value) < 0)
                    {
                        e.Valid = false;
                    }
                    break;
                case "go_tipcamb":
                    if (Convert.ToDecimal(e.Value) < 0)
                    {
                        e.Valid = false;
                    }
                    break;
            }
        }

        private void _CalculandoImporte()
        {
            for (var i = 0; i < dgb_importacion1.RowCount; i++)
            {
                Decimal ximp_me = 0, ximp_mn = 0, xtcamb = 0, xvalventa = 0;
                var codi = dgb_importacion1.GetRowCellValue(i, "conceptoid").ToString();

                if (codi.Trim().Length > 1)
                {
                    ximp_me = Convert.ToDecimal(dgb_importacion1.GetRowCellValue(i, "bimp_sunat2").ToString());
                    xtcamb = Convert.ToDecimal(dgb_importacion1.GetRowCellValue(i, "tipcamb").ToString());
                    ximp_mn = Convert.ToDecimal(dgb_importacion1.GetRowCellValue(i, "bimp_sunat1").ToString());

                    xvalventa = (ximp_me * xtcamb) + ximp_mn;
                    dgb_importacion1.SetRowCellValue(i, "pven", xvalventa);
                }
            }
        }

        private void _CalculaTotales()
        {
            for (var i = 0; i < dgb_importacion1.RowCount; i++)
            {
                var codi = dgb_importacion1.GetRowCellValue(i, "conceptoid").ToString();
                Decimal xtot_cif = 0, xtot_dua = 0, xtot_gimpo = 0, xtot_gfin = 0;
                if (codi.Trim().Length == 1)
                {
                    if (codi.Trim() == "1")
                    {
                        xtot_cif = Convert.ToDecimal(dgb_importacion1.GetRowCellValue(i, "pven").ToString());
                        cif.Text = xtot_cif.ToString("##,###,##0.0000");
                    }
                    if (codi.Trim() == "2")
                    {
                        xtot_dua = Convert.ToDecimal(dgb_importacion1.GetRowCellValue(i, "pven").ToString());
                        dua.Text = xtot_dua.ToString("##,###,##0.0000");
                    }
                    if (codi.Trim() == "3")
                    {
                        xtot_gimpo = Convert.ToDecimal(dgb_importacion1.GetRowCellValue(i, "pven").ToString());
                        gas_impo.Text = xtot_gimpo.ToString("##,###,##0.0000");
                    }
                    if (codi.Trim() == "4")
                    {
                        xtot_gfin = Convert.ToDecimal(dgb_importacion1.GetRowCellValue(i, "pven").ToString());
                        gas_financ.Text = xtot_gfin.ToString("##,###,##0.0000");
                    }
                }
            }
        }

        private void _FactorIncre()
        {
            Decimal FactorIncre = 0;
            if (xvalventa > 0)
            {
                tot_bimp.Text = (Convert.ToDecimal(cif.Text) +
                                Convert.ToDecimal(dua.Text) +
                                Convert.ToDecimal(gas_impo.Text) +
                                Convert.ToDecimal(gas_financ.Text)).ToString("##,###,##0.0000");

                FactorIncre = Convert.ToDecimal(tot_bimp.Text) / xvalventa;
                factorincre.Text = FactorIncre.ToString("##,###,##0.000000");
            }
        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {
            var sw_prosigue = false;
            dgb_importacion1.FocusedColumn = dgb_importacion1.Columns["conceptoid"];
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
                        Modificar();
                    }
                }
            }
        }

        private void Insert()
        {
            try
            {
                var BE = new tb_cm_liquidacab();
                var BL = new tb_cm_liquidacabBL();

                BE.tipdoc = tipdoc.Text.Trim();
                BE.serdoc = moduloiddes.SelectedValue.ToString();
                BE.numdoc = serdoc.Text.Trim() + numdoc.Text.Trim();
                BE.moduloid = moduloiddes.SelectedValue.ToString();
                BE.local = localdes.SelectedValue.ToString();
                BE.tipref = tipguia.Text.Trim();
                BE.serref = serguia.Text.Trim();
                BE.numref = numguia.Text.Trim();
                BE.fecre = Convert.ToDateTime(fechdoc.Text);

                BE.cif = Convert.ToDecimal(cif.Text.Trim());
                BE.dua = Convert.ToDecimal(dua.Text.Trim());
                BE.gas_impo = Convert.ToDecimal(gas_impo.Text.Trim());
                BE.gas_financ = Convert.ToDecimal(gas_financ.Text.Trim());
                BE.tot_bimp = Convert.ToDecimal(tot_bimp.Text.Trim());
                BE.factorincre = Convert.ToDecimal(factorincre.Text.Trim());
                BE.usuar = VariablesPublicas.Usuar.Trim();
                BE.status = "0";


                if (TablaDetalleImportacion2 != null)
                {
                    TablaDetalleImportacion2.Clear();
                }

                for (var i = 0; i < dgb_importacion1.RowCount; i++)
                {
                    row = TablaDetalleImportacion2.NewRow();
                    row["tipdoc"] = tipdoc.Text.Trim();
                    row["serdoc"] = moduloiddes.SelectedValue.ToString();
                    row["numdoc"] = serdoc.Text.Trim() + numdoc.Text.Trim();

                    row["conceptoid"] = dgb_importacion1.GetRowCellValue(i, "conceptoid").ToString().Trim();
                    row["ctacte"] = dgb_importacion1.GetRowCellValue(i, "ctacte").ToString().Trim();
                    row["tipbou"] = dgb_importacion1.GetRowCellValue(i, "tipbou").ToString().Trim();
                    row["serbou"] = dgb_importacion1.GetRowCellValue(i, "serbou").ToString().Trim();
                    row["numbou"] = dgb_importacion1.GetRowCellValue(i, "numbou").ToString().Trim();
                    var fecha = dgb_importacion1.GetRowCellValue(i, "fechbou").ToString().Trim();
                    if (fecha.ToString().Trim().Length > 0 && fecha.ToString().Trim() != "-")
                    {
                        row["fechbou"] = dgb_importacion1.GetRowCellValue(i, "fechbou").ToString().Trim();
                    }
                    row["bimp_sunat2"] = dgb_importacion1.GetRowCellValue(i, "bimp_sunat2").ToString().Trim();
                    row["tipcamb"] = dgb_importacion1.GetRowCellValue(i, "tipcamb").ToString().Trim();
                    row["bimp_sunat1"] = dgb_importacion1.GetRowCellValue(i, "bimp_sunat1").ToString().Trim();
                    row["pven"] = dgb_importacion1.GetRowCellValue(i, "pven").ToString().Trim();
                    row["status"] = "0".ToString().Trim();
                    row["usuar"] = VariablesPublicas.Usuar.Trim();

                    TablaDetalleImportacion2.Rows.Add(row);
                }

                if (BL.Insert(EmpresaID, BE, TablaDetalleImportacion2))
                {
                    MessageBox.Show("Datos Grabados Correctamente !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    form_bloqueado(false);
                    tipdoc.Enabled = false;

                    btn_nuevo.Enabled = true;
                    btn_imprimir.Enabled = true;

                    btn_primero.Enabled = true;
                    btn_anterior.Enabled = true;
                    btn_siguiente.Enabled = true;
                    btn_ultimo.Enabled = true;

                    btn_salir.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Modificar()
        {
            try
            {
                var BE = new tb_cm_liquidacab();
                var BL = new tb_cm_liquidacabBL();

                BE.tipdoc = tipdoc.Text.Trim();
                BE.serdoc = moduloiddes.SelectedValue.ToString();
                BE.numdoc = serdoc.Text.Trim() + numdoc.Text.Trim();
                BE.moduloid = moduloiddes.SelectedValue.ToString();
                BE.local = localdes.SelectedValue.ToString();
                BE.tipref = tipguia.Text.Trim();
                BE.serref = serguia.Text.Trim();
                BE.numref = numguia.Text.Trim();
                BE.fecre = Convert.ToDateTime(fechdoc.Text);
                BE.cif = Convert.ToDecimal(cif.Text.Trim());
                BE.dua = Convert.ToDecimal(dua.Text.Trim());
                BE.gas_impo = Convert.ToDecimal(gas_impo.Text.Trim());
                BE.gas_financ = Convert.ToDecimal(gas_financ.Text.Trim());
                BE.tot_bimp = Convert.ToDecimal(tot_bimp.Text.Trim());
                BE.factorincre = Convert.ToDecimal(factorincre.Text.Trim());
                BE.usuar = VariablesPublicas.Usuar.Trim();
                BE.status = "0";

                if (TablaDetalleImportacion2 != null)
                {
                    TablaDetalleImportacion2.Clear();
                }

                for (var i = 0; i < dgb_importacion1.RowCount; i++)
                {
                    row = TablaDetalleImportacion2.NewRow();
                    row["tipdoc"] = tipdoc.Text.Trim();
                    row["serdoc"] = moduloiddes.SelectedValue.ToString();
                    row["numdoc"] = serdoc.Text.Trim() + numdoc.Text.Trim();

                    row["conceptoid"] = dgb_importacion1.GetRowCellValue(i, "conceptoid").ToString().Trim();
                    row["ctacte"] = dgb_importacion1.GetRowCellValue(i, "ctacte").ToString().Trim();
                    row["tipbou"] = dgb_importacion1.GetRowCellValue(i, "tipbou").ToString().Trim();
                    row["serbou"] = dgb_importacion1.GetRowCellValue(i, "serbou").ToString().Trim();
                    row["numbou"] = dgb_importacion1.GetRowCellValue(i, "numbou").ToString().Trim();
                    var fecha = dgb_importacion1.GetRowCellValue(i, "fechbou").ToString().Trim();
                    if (fecha.ToString().Trim().Length > 0)
                    {
                        row["fechbou"] = dgb_importacion1.GetRowCellValue(i, "fechbou").ToString().Trim();
                    }
                    row["bimp_sunat2"] = dgb_importacion1.GetRowCellValue(i, "bimp_sunat2").ToString().Trim();
                    row["tipcamb"] = dgb_importacion1.GetRowCellValue(i, "tipcamb").ToString().Trim();
                    row["bimp_sunat1"] = dgb_importacion1.GetRowCellValue(i, "bimp_sunat1").ToString().Trim();
                    row["pven"] = dgb_importacion1.GetRowCellValue(i, "pven").ToString().Trim();
                    row["status"] = "0".ToString().Trim();
                    row["usuar"] = VariablesPublicas.Usuar.Trim();

                    TablaDetalleImportacion2.Rows.Add(row);
                }

                if (BL.Update(EmpresaID, BE, TablaDetalleImportacion2))
                {
                    MessageBox.Show("Datos Modificados Correctamente !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    form_bloqueado(false);
                    tipdoc.Enabled = false;

                    btn_nuevo.Enabled = true;
                    btn_imprimir.Enabled = true;

                    btn_primero.Enabled = true;
                    btn_anterior.Enabled = true;
                    btn_siguiente.Enabled = true;
                    btn_ultimo.Enabled = true;

                    btn_salir.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgb_importacion1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    if (dgb_importacion1.FocusedColumn == dgb_importacion1.Columns[3])
                    {
                        AyudaClientes(string.Empty);
                    }
                }

                if (e.KeyCode == Keys.Delete)
                {
                    dgb_importacion1.SetFocusedRowCellValue("ctacte", "-");
                    dgb_importacion1.SetFocusedRowCellValue("proveedor", "-");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dgb_importacion1.SetFocusedRowCellValue("ctacte", resultado1.ToString());
            dgb_importacion1.SetFocusedRowCellValue("proveedor", resultado3.ToString().Trim());
        }

        private void numdoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                form_cargar_datos(string.Empty);
            }
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            dgb_importacion1.PrintDialog();
        }

        private void dgb_importacion1_ShownEditor(object sender, EventArgs e)
        {
            var view = (ColumnView)sender;
            var dt = new DataTable();

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                view.ActiveEditor.Properties.ReadOnly = view.FocusedRowHandle == Convert.ToInt32(dt.Rows[i][0].ToString());
            }
        }

        private DataSet Consultas(String Query)
        {
            var conex = new ConexionDA();
            using (var cnx = new SqlConnection(conex.empConexion(EmpresaID)))
            {
                using (var cmd = new SqlCommand("gspHelpSQL", cnx))
                {
                    var ds = new DataSet();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@sqlquery", SqlDbType.VarChar).Value = Query;
                    try
                    {
                        cnx.Open();
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                        }
                        return ds;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
    }
}
