using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace BapFormulariosNet.D60Tienda.LISTA_PRECIOS
{
    public partial class Frm_promociones : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable Tablapromo;
        private DataTable TablapromoDet;
        private List<tb_perianio> lista = null;
        private Boolean procesado = false;
        private String xx_articid;
        private String ssModo = string.Empty;

        public Frm_promociones()
        {
            InitializeComponent();
        }

        private void PARAMETROS_TABLA()
        {
            var xxferfil = string.Empty;
            var f = (MainTienda)MdiParent;
            xxferfil = f.perfil.ToString();
            if (xxferfil.Trim().Length != 9)
            {
                MessageBox.Show("::: NO TIENE PERFIL !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
                btn_clave.Glyph = global::BapFormulariosNet.Properties.Resources.btn_Lock20;
            }
            else
            {
                btn_clave.Glyph = global::BapFormulariosNet.Properties.Resources.btn_Un_Lock20;
            }
        }
        private void RecibePermiso(Boolean resultado1, String resultado2)
        {
            if (resultado1)
            {
                XNIVEL = "0";
                XGLOSA = resultado2.Trim();
                btn_clave.Glyph = global::BapFormulariosNet.Properties.Resources.btn_Un_Lock20;
            }
        }

        private void form_bloqueado(Boolean var)
        {
            try
            {
                promoid.Enabled = false;
                promoname.Enabled = var;

                cmb_tiendalist.Enabled = var;
                cmb_tarjgrupoid.Enabled = var;
                prioridad.Enabled = var;
                chk_aldocum.Enabled = var;
                chk_aldoc2.Enabled = false;
                cmb_grupopromocion.Enabled = var;

                rdb_estado.Enabled = var;
                perdsctocab.Enabled = var;

                chk_solodias.Enabled = var;
                chk_dom.Enabled = var;
                chk_lun.Enabled = var;
                chk_mar.Enabled = var;
                chk_mie.Enabled = var;
                chk_jue.Enabled = var;
                chk_vie.Enabled = var;
                chk_sab.Enabled = var;
                fechaini.Enabled = var;
                fechafin.Enabled = var;

                npack.Enabled = var;
                impodoc.Enabled = var;
                impopack.Enabled = var;
                aplicini.Enabled = var;
                aplicfin.Enabled = var;
                exclusivo.Enabled = false;

                articid.Enabled = false;
                articname.Enabled = false;
                percdscto.Enabled = false;
                precunit.Enabled = false;
                btn_nuevo.Enabled = false;
                btn_editar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_grabar.Enabled = false;
                btn_eliminar.Enabled = false;
                btn_imprimir.Enabled = false;
                btn_save.Enabled = false;
                btn_update.Enabled = false;
                btn_importar.Enabled = false;
                btn_clave.Enabled = true;
                btn_log.Enabled = true;
                btn_salir.Enabled = false;

                cmb_grupopromocion2.Enabled = false;
                cmb_perianio.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void solo_numero_decimal(object control, KeyPressEventArgs e)
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
                        if (e.KeyChar == '.')
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
        }

        public bool IsNumeric(String Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
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
        }

        private void SEGURIDAD_LOG(String accion)
        {
            var xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio;
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
                BE.detalle = articid.Text.Trim() + "/" + articname.Text.Trim().ToUpper() + "/" + XGLOSA;

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
                promoid.Text = string.Empty;
                promoname.Text = string.Empty;
                cmb_tarjgrupoid.SelectedIndex = -1;
                cmb_tiendalist.SelectedIndex = -1;
                chk_aldocum.Checked = false;
                fechaini.Text = DateTime.Today.ToShortDateString();
                fechafin.Text = DateTime.Today.ToShortDateString();
                cmb_grupopromocion.SelectedIndex = -1;
                cmb_grupopromocion2.SelectedIndex = -1;
                cmb_perianio.SelectedIndex = -1;

                rdb_estado.SelectedIndex = -1;

                chk_solodias.Checked = false;
                chk_dom.Checked = false;
                chk_lun.Checked = false;
                chk_mar.Checked = false;
                chk_mie.Checked = false;
                chk_jue.Checked = false;
                chk_vie.Checked = false;
                chk_sab.Checked = false;

                percdscto.Text = string.Empty;
                precunit.Text = string.Empty;

                articid.Text = string.Empty;
                articname.Text = string.Empty;
                chk_aldoc2.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevo()
        {
            limpiar_documento();
            form_bloqueado(true);
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_log.Enabled = true;
            promoname.Focus();
            pnlcontroldet.Enabled = false;
            ssModo = "NEW";
            rdb_estado.SelectedIndex = 0;
        }

        private void Nuevo2(Boolean var)
        {
            articid.Text = string.Empty;
            articname.Text = string.Empty;
            percdscto.Text = "0";
            precunit.Text = "0";
            btn_save.Enabled = var;
            articid.Enabled = var;
            precunit.Enabled = var;
            btn_cancelar.Enabled = true;
            chk_aldoc2.Checked = !var;
            articid.Focus();
            ssModo = "NEW";
        }

        private void Insert()
        {
            try
            {
                if (promoname.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Denominación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_px_promocionesBL();
                    var BE = new tb_px_promociones();
                    BE.prioridad = prioridad.Text.Trim();
                    var n = rdb_estado.SelectedIndex;
                    if (n == 0)
                    {
                        BE.status = "0";
                    }
                    else
                    {
                        BE.status = "9";
                    }
                    BE.exclusivo = exclusivo.Text.Trim();
                    BE.promoname = promoname.Text.Trim();

                    if (cmb_tiendalist.SelectedIndex != -1)
                    {
                        BE.tiendalist = Convert.ToInt32(cmb_tiendalist.SelectedValue.ToString().Trim());
                    }
                    if (cmb_tarjgrupoid.SelectedIndex != -1)
                    {
                        BE.tarjgrupoid = Convert.ToInt32(cmb_tarjgrupoid.SelectedValue.ToString().Trim());
                    }

                    BE.percdscto = Convert.ToDecimal(perdsctocab.Text.ToString());
                    BE.al_docum = chk_aldocum.Checked;
                    BE.fechaini = Convert.ToDateTime(fechaini.Text);
                    BE.fechafin = Convert.ToDateTime(fechafin.Text);
                    if (cmb_grupopromocion.SelectedIndex != -1)
                    {
                        BE.grupopromoid = Convert.ToInt32(cmb_grupopromocion.SelectedValue.ToString().Trim());
                    }
                    BE.usuar = VariablesPublicas.Usuar.Trim();
                    BE.fecre = Convert.ToDateTime(DateTime.Today.ToShortDateString());
                    BE.feact = Convert.ToDateTime(DateTime.Today.ToShortDateString());
                    BE.usuarap = VariablesPublicas.Usuar.Trim();
                    BE.fechap = Convert.ToDateTime(DateTime.Today.ToShortDateString());
                    BE.solodias = chk_solodias.Checked;
                    BE.dom = chk_dom.Checked;
                    BE.lun = chk_lun.Checked;
                    BE.mar = chk_mar.Checked;
                    BE.mie = chk_mie.Checked;
                    BE.jue = chk_jue.Checked;
                    BE.vie = chk_vie.Checked;
                    BE.sab = chk_sab.Checked;
                    BE.npack = Convert.ToInt32(npack.Text.Trim());
                    BE.impodoc = Convert.ToDecimal(impopack.Text.Trim());
                    BE.aplicini = Convert.ToInt32(aplicini.Text.Trim());
                    BE.aplicfin = Convert.ToInt32(aplicfin.Text.Trim());
                    BE.impodoc = Convert.ToDecimal(impodoc.Text.Trim());

                    if (BL.Insert(EmpresaID, BE))
                    {
                        MessageBox.Show("Datos Grabados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        procesado = true;
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
                if (promoid.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Falta Codigo de Promoción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_px_promocionesBL();
                    var BE = new tb_px_promociones();

                    BE.promoid = Convert.ToInt32(promoid.Text.Trim());
                    BE.prioridad = prioridad.Text.Trim();

                    var n = rdb_estado.SelectedIndex;
                    if (n == 0)
                    {
                        BE.status = "0";
                    }
                    else
                    {
                        BE.status = "9";
                    }
                    BE.exclusivo = exclusivo.Text.Trim();
                    BE.promoname = promoname.Text.Trim();

                    if (cmb_tiendalist.SelectedIndex != -1)
                    {
                        BE.tiendalist = Convert.ToInt32(cmb_tiendalist.SelectedValue.ToString().Trim());
                    }
                    if (cmb_tarjgrupoid.SelectedIndex != -1)
                    {
                        BE.tarjgrupoid = Convert.ToInt32(cmb_tarjgrupoid.SelectedValue.ToString().Trim());
                    }

                    BE.percdscto = Convert.ToDecimal(perdsctocab.Text.Trim());
                    BE.al_docum = chk_aldocum.Checked;
                    BE.fechaini = Convert.ToDateTime(fechaini.Text);
                    BE.fechafin = Convert.ToDateTime(fechafin.Text);
                    if (cmb_grupopromocion.SelectedIndex != -1)
                    {
                        BE.grupopromoid = Convert.ToInt32(cmb_grupopromocion.SelectedValue.ToString().Trim());
                    }
                    BE.usuar = VariablesPublicas.Usuar.Trim();
                    BE.fecre = Convert.ToDateTime(DateTime.Today.ToShortDateString());
                    BE.feact = Convert.ToDateTime(DateTime.Today.ToShortDateString());
                    BE.usuarap = VariablesPublicas.Usuar.Trim();
                    BE.fechap = Convert.ToDateTime(DateTime.Today.ToShortDateString());
                    BE.solodias = chk_solodias.Checked;
                    BE.dom = chk_dom.Checked;
                    BE.lun = chk_lun.Checked;
                    BE.mar = chk_mar.Checked;
                    BE.mie = chk_mie.Checked;
                    BE.jue = chk_jue.Checked;
                    BE.vie = chk_vie.Checked;
                    BE.sab = chk_sab.Checked;
                    BE.npack = Convert.ToInt32(npack.Text.Trim());
                    BE.impodoc = Convert.ToDecimal(impopack.Text.Trim());
                    BE.aplicini = Convert.ToInt32(aplicini.Text.Trim());
                    BE.aplicfin = Convert.ToInt32(aplicfin.Text.Trim());
                    BE.impodoc = Convert.ToDecimal(impodoc.Text.Trim());

                    if (BL.Update(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("M");
                        MessageBox.Show("Datos Modificado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        procesado = true;
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
                if (promoid.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Falta Codigo Lista !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_px_promocionesBL();
                    var BE = new tb_px_promociones();

                    BE.promoid = Convert.ToInt32(promoid.Text.Trim());

                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos Eliminado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        limpiar_documento();
                        form_bloqueado(false);
                        data_Tablapromo();
                        CargarDetalle();
                        btn_nuevo.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_articulo_tiendalist_Load(object sender, EventArgs e)
        {
            modulo = ((D60Tienda.MainTienda)MdiParent).moduloid;
            local = ((D60Tienda.MainTienda)MdiParent).local;
            PERFILID = ((D60Tienda.MainTienda)MdiParent).perfil;

            NIVEL_FORMS();
            data_Tablapromo();
            _CargarListaTiendas();
            _CargarGrupoTarjetas();
            _CargarGrupoPromociones();
            _CargarAnio();

            TablapromoDet = new DataTable();
            TablapromoDet.Columns.Add("promoid", typeof(Int32));
            TablapromoDet.Columns.Add("articid", typeof(String));
            TablapromoDet.Columns.Add("articidold", typeof(String));
            TablapromoDet.Columns.Add("articname", typeof(String));
            TablapromoDet.Columns.Add("es_dscto", typeof(Boolean));
            TablapromoDet.Columns.Add("percdscto", typeof(Decimal));
            TablapromoDet.Columns.Add("precunit", typeof(Decimal));
            TablapromoDet.Columns.Add("cantidad", typeof(Int32));
            TablapromoDet.Columns.Add("usuarIP", typeof(String));
            TablapromoDet.Columns.Add("feact", typeof(DateTime));

            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_salir.Enabled = true;
        }


        private void _CargarListaTiendas()
        {
            var BL = new tb_me_tiendalistBL();
            var BE = new tb_me_tiendalist();
            var dt = new DataTable();

            BE.filtro = "1";
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cmb_tiendalist.DataSource = dt;
                cmb_tiendalist.ValueMember = "tiendalist";
                cmb_tiendalist.DisplayMember = "tiendalistname";
            }
        }

        private void _CargarGrupoTarjetas()
        {
            var BL = new tb_t1_tarjgrupoBL();
            var BE = new tb_t1_tarjgrupo();
            var dt = new DataTable();

            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cmb_tarjgrupoid.DataSource = dt;
                cmb_tarjgrupoid.ValueMember = "tarjgrupoid";
                cmb_tarjgrupoid.DisplayMember = "tarjgruponame";
            }
        }

        private void _CargarGrupoPromociones()
        {
            var BL = new tb_px_grupo_promocionesBL();
            var BE = new tb_px_grupo_promociones();
            var dt = new DataTable();

            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cmb_grupopromocion.DataSource = dt;
                cmb_grupopromocion.ValueMember = "grupopromoid";
                cmb_grupopromocion.DisplayMember = "grupopromoname";

                cmb_grupopromocion2.DataSource = dt;
                cmb_grupopromocion2.ValueMember = "grupopromoid";
                cmb_grupopromocion2.DisplayMember = "grupopromoname";
            }
        }

        private void _CargarAnio()
        {
            var BL = new tb_perianioBL();
            lista = BL.Get_anio(EmpresaID);
            cmb_perianio.DataSource = lista;
            cmb_perianio.DisplayMember = "perianio";
            cmb_perianio.ValueMember = "codigo";
        }



        private void Frm_articulo_tiendalist_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.G)
            {
                if (btn_grabar.Enabled)
                {
                    btn_grabar.PerformClick();
                }
            }

            if (e.Control && e.KeyCode == Keys.N)
            {
                if (btn_nuevo.Enabled)
                {
                    btn_nuevo.PerformClick();
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                if (btn_cancelar.Enabled)
                {
                    form_accion_cancelEdicion(1);
                }
                else
                {
                    btn_salir.PerformClick();
                }
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
                NIVEL_FORMS();
                limpiar_documento();
                form_bloqueado(false);
                btn_nuevo.Enabled = true;
                btn_salir.Enabled = true;
                pnlcontroldet.Enabled = true;
                btn_del.Enabled = false;
                ssModo = "OTR";
                if (TablapromoDet.Rows.Count > 0)
                {
                    TablapromoDet.Rows.Clear();
                    dgb_promodet.DataSource = TablapromoDet;
                }
                else
                {
                    dgb_promodet.DataSource = TablapromoDet;
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

        private void btn_log_Click(object sender, EventArgs e)
        {
            var oform = new Seguridadlog.FrmSeguridad();
            var xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio;
            oform._Nombre = Name;
            oform._ClaveForm = xclave;
            oform.Owner = this;
            oform.ShowDialog();
        }

        private void data_Tablapromo()
        {
            try
            {
                Tablapromo = new DataTable();

                if (Tablapromo.Rows.Count > 0)
                {
                    Tablapromo.Rows.Clear();
                }
                var BL = new tb_px_promocionesBL();
                var BE = new tb_px_promociones();
                Tablapromo = BL.GetAll(EmpresaID, BE).Tables[0];
                if (Tablapromo.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    Mdi_dgv_promociones.DataSource = Tablapromo;
                }
                else
                {
                    Mdi_dgv_promociones.DataSource = Tablapromo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void data_tiendalist(String xpromoid)
        {
            form_bloqueado(false);
            var rowpromoid = Tablapromo.Select("promoid='" + xpromoid + "'");
            if (rowpromoid.Length > 0)
            {
                foreach (DataRow row in rowpromoid)
                {
                    promoid.Text = row["promoid"].ToString().Trim();
                    promoname.Text = row["promoname"].ToString().Trim();
                    cmb_tarjgrupoid.SelectedValue = row["tarjgroupid"].ToString().Trim();
                    cmb_tiendalist.SelectedValue = row["tiendalist"].ToString().Trim();
                    prioridad.Text = row["prioridad"].ToString().Trim();
                    chk_aldocum.Checked = Convert.ToBoolean(row["al_docum"].ToString().Trim());
                    perdsctocab.Text = row["percdscto"].ToString().Trim();
                    fechaini.Text = row["fechaini"].ToString().Trim();
                    fechafin.Text = row["fechafin"].ToString().Trim();
                    exclusivo.Text = row["exclusivo"].ToString().Trim();
                    if (row["grupopromoid"].ToString().Trim().Length == 0)
                    {
                        cmb_grupopromocion.SelectedIndex = -1;
                    }
                    else
                    {
                        cmb_grupopromocion.SelectedValue = row["grupopromoid"].ToString().Trim();
                    }
                    chk_solodias.Checked = Convert.ToBoolean(row["solodias"].ToString().Trim());
                    chk_dom.Checked = Convert.ToBoolean(row["dom"].ToString().Trim());
                    chk_lun.Checked = Convert.ToBoolean(row["lun"].ToString().Trim());
                    chk_mar.Checked = Convert.ToBoolean(row["mar"].ToString().Trim());
                    chk_mie.Checked = Convert.ToBoolean(row["mie"].ToString().Trim());
                    chk_jue.Checked = Convert.ToBoolean(row["jue"].ToString().Trim());
                    chk_vie.Checked = Convert.ToBoolean(row["vie"].ToString().Trim());
                    chk_sab.Checked = Convert.ToBoolean(row["sab"].ToString().Trim());
                    npack.Text = row["npack"].ToString().Trim();
                    impopack.Text = row["impopack"].ToString().Trim();
                    aplicini.Text = row["aplicini"].ToString().Trim();
                    aplicfin.Text = row["aplicfin"].ToString().Trim();
                    impodoc.Text = row["impodoc"].ToString().Trim();

                    var x =  row["status"].ToString().Trim();
                    if (x == "0")
                    {
                        rdb_estado.SelectedIndex = 0;
                    }
                    else
                    {
                        rdb_estado.SelectedIndex = 1;
                    }
                    articid.Text = string.Empty;
                    articname.Text = string.Empty;
                    percdscto.Text = string.Empty;
                    chk_aldoc2.Checked = false;
                    precunit.Text = string.Empty;
                    CargarDetalle();
                }

                btn_nuevo.Enabled = true;
                btn_editar.Enabled = true;
                btn_eliminar.Enabled = true;
                btn_imprimir.Enabled = true;
                btn_log.Enabled = true;
                btn_salir.Enabled = true;
                btn_importar.Enabled = true;
                btn_add.Enabled = true;
                btn_del.Enabled = false;
            }
        }


        private void btn_clave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void AyudaArticulo(String lpdescrlike)
        {
            var frmayuda = new Ayudas.Frm_help_general();

            frmayuda.tipoo = "sql";
            frmayuda.titulo = "<< AYUDA TABLA ARTICULO >>";
            frmayuda.sqlquery = "SELECT top 100 articid as Codigo,articidold as Cod_Ant, articname as Articulo FROM tb_pt_articulo ";
            frmayuda.sqlwhere = "where";
            frmayuda.criteriosbusqueda = new string[] { "ARTICULO", "CODIGO_ANT" };
            frmayuda.columbusqueda = "articname,articidold";
            frmayuda.returndatos = "0,1,2";

            frmayuda.Owner = this;
            frmayuda.PasaProveedor = RecibeArticulo;
            frmayuda.ShowDialog();
        }

        private void RecibeArticulo(String xarticid, String xarticidold, String xarticname, String resultado4, String resultado5)
        {
            if (xarticid.Trim().Length > 0)
            {
                xx_articid = xarticid.Trim();
                articid.Text = xarticidold.Trim();
                articname.Text = xarticname.Trim();
            }
        }

        private void ValidaArticulo(String xcod)
        {
            var  BE = new tb_pt_articulo();
            var BL = new tb_pt_articuloBL();
            var dt = new DataTable();
            BE.articidold = xcod.Trim();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                xx_articid = dt.Rows[0]["articid"].ToString();
                articid.Text = dt.Rows[0]["articidold"].ToString();
                articname.Text = dt.Rows[0]["articname"].ToString();
            }
            else
            {
                xx_articid = string.Empty;
                articid.Text = string.Empty;
                articname.Text = string.Empty;
            }
        }


        private void articid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaArticulo(string.Empty);
            }
            if (e.KeyCode == Keys.Enter)
            {
                var xcodart = string.Empty;
                xcodart = articid.Text.Trim();
                ValidaArticulo(xcodart);
                precunit.Focus();
            }
        }

        private void btn_nuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
            {
                nuevo();
                if (TablapromoDet != null)
                {
                    TablapromoDet.Rows.Clear();
                    dgb_promodet.DataSource = TablapromoDet;
                }
                pnl_dias.Enabled = false;
            }
        }

        private void btn_editar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XNIVEL == "0")
            {
                ssModo = "EDIT";
                form_bloqueado(true);
                pnlcontroldet.Enabled = false;
                articid.Enabled = false;
                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
                pnl_dias.Enabled = false;
            }
        }

        private void btn_grabar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            procesado = false;
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
                    sw_prosigue = (MessageBox.Show("¿Desea Modificar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                    if (sw_prosigue)
                    {
                        Update();
                    }
                }
            }
            if (procesado)
            {
                NIVEL_FORMS();
                limpiar_documento();
                data_Tablapromo();
                form_bloqueado(false);
                btn_nuevo.Enabled = true;
                btn_salir.Enabled = true;
                pnlcontroldet.Enabled = true;
            }
        }

        private void btn_salir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btn_eliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void btn_cancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            form_accion_cancelEdicion(1);
        }

        private void Mdi_dgv_tiendalist_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xtiendalistid = dgv_promociones.GetRowCellValue(dgv_promociones.FocusedRowHandle, "promoid").ToString();
                data_tiendalist(xtiendalistid);
            }
        }

        private void dgv_tiendalist_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var xtiendalistid = dgv_promociones.GetRowCellValue(e.RowHandle, "promoid").ToString();
            data_tiendalist(xtiendalistid);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            form_bloqueado(false);
            Nuevo2(true);
            btn_cancelar.Enabled = true;
            chk_aldoc2.Enabled = true;

            promoname.Enabled = false;
            btn_del.Enabled = false;
            btn_add.Enabled = false;
            articid.Focus();
        }

        private void dgv_tiendalistitem_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
        }

        private void MDI_dgv_tiendalistitem_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if ((dgb_promodet.RowCount != null))
            {
                if (promoid.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Falta Codigo de Lista de Precios", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (articid.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Falta Codigo de Artículo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                var BL = new tb_px_promocionesdetBL();
                var BE = new tb_px_promocionesdet();
                BE.promoid = Convert.ToInt32(promoid.Text.Trim());
                BE.articid = xx_articid.Trim();
                BE.articidold = articid.Text.Trim();

                if (BL.Delete(EmpresaID, BE))
                {
                    CargarDetalle();
                    articid.Text = string.Empty;
                    chk_aldoc2.Checked = false;
                    articname.Text = string.Empty;
                    percdscto.Text = string.Empty;
                    precunit.Text = string.Empty;
                    btn_del.Enabled = false;
                }
            }
        }

        private void btn_importar_Click(object sender, EventArgs e)
        {
            if (promoid.Text.ToString().Trim().Length > 0)
            {
                Importar_Excel();
            }
            else
            {
                MessageBox.Show("Seleccione Una Lista de Precios Para Agregar Detalle .. !!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void Importar_Excel()
        {
            var CuadroDialogo = new OpenFileDialog();
            CuadroDialogo.DefaultExt = "xls";
            CuadroDialogo.Filter = "xls file(*.xls)|*.xlsx";
            CuadroDialogo.AddExtension = true;
            CuadroDialogo.RestoreDirectory = true;
            CuadroDialogo.Title = "Seleccionar Archivo";

            if (CuadroDialogo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var excelApp = new Excel.Application();
                    var excelBook = excelApp.Workbooks.Open(CuadroDialogo.FileName, Type.Missing, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    var excelWorksheet = (Excel._Worksheet)excelBook.Worksheets.get_Item(1);
                    excelApp.Visible = false;

                    var x = 2;
                    if (TablapromoDet.Rows.Count > 0)
                    {
                        TablapromoDet.Rows.Clear();
                    }
                    while (excelWorksheet.get_Range("A" + x).Value2 != null)
                    {
                        TablapromoDet.Rows.Add(promoid.Text.Trim(),
                                            string.Empty,
                                            excelWorksheet.get_Range("A" + x).Value2.ToString(),
                                            excelWorksheet.get_Range("B" + x).Value2.ToString(),
                                            excelWorksheet.get_Range("C" + x).Value2.ToString(),
                                            1,
                                            excelWorksheet.get_Range("D" + x).Value2.ToString(),
                                            excelWorksheet.get_Range("E" + x).Value2.ToString(),
                                            "0",
                                            VariablesPublicas.Usuar.ToString(),
                                            DateTime.Today.ToShortDateString());
                        x++;
                    }

                    var BL = new tb_px_promocionesdetBL();
                    var BE = new tb_px_promocionesdet();

                    var Detalle = new tb_px_promocionesdet.Item();
                    var ListaItems = new List<tb_px_promocionesdet.Item>();

                    var item = 0;
                    foreach (DataRow fila in TablapromoDet.Rows)
                    {
                        Detalle = new tb_px_promocionesdet.Item();
                        item++;

                        Detalle.promoid = Convert.ToInt32(promoid.Text.ToString());
                        Detalle.articid = string.Empty;
                        Detalle.articidold = fila["articidold"].ToString().Trim();
                        Detalle.articname = fila["articname"].ToString().Trim();
                        Detalle.es_dscto = Convert.ToBoolean(fila["es_dscto"].ToString().Trim());
                        Detalle.cantidad = 1;
                        Detalle.percdscto = Convert.ToDecimal(fila["percdscto"].ToString());
                        Detalle.precunit = Convert.ToDecimal(fila["precunit"].ToString());
                        Detalle.status = "0";
                        Detalle.UsuarIP = VariablesPublicas.Usuar;
                        Detalle.feact = Convert.ToDateTime(fila["feact"].ToString().Trim());

                        ListaItems.Add(Detalle);
                    }
                    if (ListaItems.Count == 0)
                    {
                        MessageBox.Show("Documento SIN DETALLE Y/O DETALLE INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    BE.promoid = Convert.ToInt32(promoid.Text.ToString());
                    BE.ListaItems = ListaItems;

                    EliminarDet(Convert.ToInt32(promoid.Text.ToString()));

                    if (BL.InsertDet(EmpresaID, BE))
                    {
                        MessageBox.Show("Datos Grabados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDetalle();
                        Nuevo2(false);
                        btn_add.Enabled = true;
                    }

                    excelApp.Quit();
                }
                catch (Exception sms)
                {
                    MessageBox.Show(sms.Message);
                }
            }
        }

        private bool EliminarDet(Int32 xpromoid)
        {
            var result = false;
            try
            {
                var BL = new tb_px_promocionesdetBL();
                var BE = new tb_px_promocionesdet();
                BE.promoid = xpromoid;

                if (BL.Delete2(EmpresaID, BE))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        private void btn_exportar_Click(object sender, EventArgs e)
        {
            if (dgb_promodet.Rows.Count > 0)
            {
                ExportarExcel();
            }
            else
            {
                MessageBox.Show("No Hay Detalle A Exportar ... !!!");
            }
        }

        private void ExportarExcel()
        {
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;

            try
            {
                oXL = new Excel.Application();
                oXL.Visible = false;

                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                oSheet.Cells[1, 1] = "Codigo";
                oSheet.Cells[1, 2] = "Denominación";
                oSheet.Cells[1, 3] = "Desc?";
                oSheet.Cells[1, 4] = "Precio-Desc";
                oSheet.Cells[1, 5] = "Precio";

                oSheet.get_Range("A1", "E1").Font.Bold = true;
                oSheet.get_Range("A1", "E1").Font.Color = Color.White;
                oSheet.get_Range("A1", "E1").Interior.ColorIndex = 14;
                oSheet.get_Range("A1", "E1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                var IndiceFila = 2;
                oSheet.Range["D:E"].NumberFormat = "_ * #,##0.00_ ;_ * -#,##0.00_ ;_ * -??_ ;_ @_ ";

                foreach (DataRow row in TablapromoDet.Rows)
                {
                    oSheet.Cells[IndiceFila, 01].Value = "'" + row["articidold"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 02].Value = "'" + row["articname"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 03].Value = row["es_dscto"];
                    oSheet.Cells[IndiceFila, 04].Value = row["percdscto"];
                    oSheet.Cells[IndiceFila, 05].Value = row["precunit"].ToString().Trim();

                    IndiceFila++;
                }
                oRng = oSheet.get_Range("A1", "E1");
                oRng.EntireColumn.AutoFit();

                oSheet.Cells[2, 1].Select();
                oXL.ActiveWindow.FreezePanes = true;

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

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (articid.Text.Length == 0)
            {
                MessageBox.Show("Ingrese Articulo ...!!!", "Información");
                return;
            }

            var BL = new tb_px_promocionesdetBL();
            var BE = new tb_px_promocionesdet();

            BE.promoid = Convert.ToInt32(promoid.Text.Trim());
            BE.articid = xx_articid.Trim();
            BE.articidold = articid.Text.Trim();
            BE.articname = articname.Text.Trim();
            BE.es_dscto = chk_aldoc2.Checked;
            BE.percdscto = Convert.ToDecimal(percdscto.Text.Trim());
            BE.cantidad = 1;
            BE.precunit = Convert.ToDecimal(precunit.Text.Trim());
            BE.status = "0";
            BE.UsuarIP = VariablesPublicas.Usuar.ToString().Trim();
            BE.feact = Convert.ToDateTime(DateTime.Today.ToShortDateString());

            if (BL.Insert(EmpresaID, BE))
            {
                MessageBox.Show("Datos Grabados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDetalle();
                Nuevo2(false);
                btn_add.Enabled = true;
                btn_cancelar.PerformClick();
            }
        }

        private void CargarDetalle()
        {
            var BL = new tb_px_promocionesdetBL();
            var BE = new tb_px_promocionesdet();
            TablapromoDet = new DataTable();
            if (promoid.Text.Trim().Length > 0)
            {
                BE.promoid = Convert.ToInt32(promoid.Text.Trim());
            }

            TablapromoDet = BL.GetAll(EmpresaID, BE).Tables[0];
            if (TablapromoDet.Rows.Count > 0)
            {
                dgb_promodet.DataSource = TablapromoDet;
            }
            else
            {
                dgb_promodet.DataSource = TablapromoDet;
            }
        }


        private void precunit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                precunit.Focus();
            }
        }

        private void dgb_listaPrecios_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgb_promodet[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            dgb_promodet[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            dgb_promodet.EnableHeadersVisualStyles = false;
            dgb_promodet.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            dgb_promodet.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void dgb_listaPrecios_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xcodigo = string.Empty;
                xcodigo = dgb_promodet.Rows[dgb_promodet.CurrentRow.Index].Cells["_articidold"].Value.ToString().Trim();
                Data_PromoDet(xcodigo);
            }
        }

        private void dgb_listaPrecios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgb_promodet.CurrentRow != null)
            {
                var xpromoid = string.Empty;
                xpromoid = dgb_promodet.Rows[e.RowIndex].Cells["_articidold"].Value.ToString().Trim();
                Data_PromoDet(xpromoid);
            }
        }

        private void Data_PromoDet(String xarticidold)
        {
            var rowpromodet = TablapromoDet.Select("articidold='" + xarticidold + "'");
            if (rowpromodet.Length > 0)
            {
                foreach (DataRow row in rowpromodet)
                {
                    xx_articid = row["articid"].ToString().Trim();
                    articid.Text = row["articidold"].ToString().Trim();
                    articname.Text = row["articname"].ToString().Trim();
                    chk_aldoc2.Checked = Convert.ToBoolean(row["es_dscto"].ToString());
                    percdscto.Text = row["percdscto"].ToString();
                    precunit.Text = row["precunit"].ToString();
                    btn_del.Enabled = true;
                    btn_update.Enabled = true;
                    precunit.Enabled = true;
                }
            }
        }

        private void promoname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            }
        }

        private void chk_aldoc2_CheckedChanged(object sender, EventArgs e)
        {
            if (btn_add.Enabled == false)
            {
                if (chk_aldoc2.Checked)
                {
                    percdscto.Enabled = true;
                    precunit.Enabled = false;
                    precunit.Text = "0";
                    percdscto.Focus();
                }
                else
                {
                    percdscto.Enabled = false;
                    precunit.Enabled = true;
                    percdscto.Text = "0";
                    precunit.Focus();
                }
            }
        }

        private void chk_solodias_CheckedChanged(object sender, EventArgs e)
        {
            if (btn_nuevo.Enabled == false)
            {
                if (chk_solodias.Checked)
                {
                    pnl_dias.Enabled = true;
                }
                else
                {
                    pnl_dias.Enabled = false;
                    chk_dom.Checked = false;
                    chk_lun.Checked = false;
                    chk_mar.Checked = false;
                    chk_mie.Checked = false;
                    chk_jue.Checked = false;
                    chk_vie.Checked = false;
                    chk_sab.Checked = false;
                }
            }
        }

        private void Group_chks_SelectedIndexChanged(object sender, EventArgs e)
        {
            var BL = new tb_px_promocionesBL();
            var BE = new tb_px_promociones();

            BE.fechaActual = Convert.ToDateTime(DateTime.Today.ToShortDateString());
            if (Group_chks.SelectedIndex == 0)
            {
                BE.filtro = Group_chks.SelectedIndex;
            }
            else
            {
                if (Group_chks.SelectedIndex == 1)
                {
                    BE.filtro = Group_chks.SelectedIndex;
                }
                else
                {
                    if (Group_chks.SelectedIndex == 2)
                    {
                        BE.filtro = Group_chks.SelectedIndex;
                    }
                }
            }
            Tablapromo = BL.GetFiltro(EmpresaID, BE).Tables[0];
            if (Tablapromo.Rows.Count > 0)
            {
                Mdi_dgv_promociones.DataSource = Tablapromo;
            }
            else
            {
                Mdi_dgv_promociones.DataSource = Tablapromo;
            }
        }

        private void npack_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                impopack.Focus();
            }
        }

        private void impopack_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                aplicini.Focus();
            }
        }

        private void aplicini_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                aplicfin.Focus();
            }
        }

        private void aplicfin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                impodoc.Focus();
            }
        }

        private void rollo_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var fieldName = string.Concat("[", TablapromoDet.Columns[2].ColumnName, "]");
                TablapromoDet.DefaultView.Sort = fieldName;
                var view = TablapromoDet.DefaultView;
                view.RowFilter = string.Empty;
                if (rollo_search.Text != string.Empty)
                {
                    view.RowFilter = fieldName + " LIKE '%" + rollo_search.Text + "%'";
                }
                dgb_promodet.DataSource = view;
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (articid.Text.Length == 0)
            {
                MessageBox.Show("Ingrese Articulo ...!!!", "Información");
                return;
            }

            var BL = new tb_px_promocionesdetBL();
            var BE = new tb_px_promocionesdet();

            BE.promoid = Convert.ToInt32(promoid.Text.Trim());
            BE.articid = xx_articid.Trim();
            BE.articidold = articid.Text.Trim();
            BE.articname = articname.Text.Trim();
            BE.es_dscto = chk_aldoc2.Checked;
            BE.percdscto = Convert.ToDecimal(percdscto.Text.Trim());
            BE.cantidad = 1;
            BE.precunit = Convert.ToDecimal(precunit.Text.Trim());
            BE.status = "0";
            BE.UsuarIP = VariablesPublicas.Usuar.ToString().Trim();
            BE.feact = Convert.ToDateTime(DateTime.Today.ToShortDateString());

            if (BL.Update(EmpresaID, BE))
            {
                MessageBox.Show("Datos Modificados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDetalle();
                Nuevo2(false);
                btn_add.Enabled = true;
                btn_update.Enabled = false;
                btn_cancelar.PerformClick();
            }
        }
    }
}
