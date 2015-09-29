using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.Generales
{
    public partial class Frm_constantesgenerales : plantilla
    {
        private String EmpresaID = string.Empty;
        private String dominio = string.Empty;
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;

        private DataTable Tablatipodoc;
        private DataTable Tablatipodocserie;
        private Boolean procesado = false;

        private String ssModo = string.Empty;
        private String ssModoDET = string.Empty;

        public Frm_constantesgenerales()
        {
            InitializeComponent();
        }

        private void NIVEL_FORMS()
        {
            switch (this.Parent.Parent.Name)
            {
                case "MainMercaderia":
                    XNIVEL = VariablesPublicas.Get_nivelperfil(((MERCADERIA.MainMercaderia)MdiParent).perfil, Name).Substring(0, 1);
                    break;
                case "MainAlmacen":
                    XNIVEL = VariablesPublicas.Get_nivelperfil(((D60ALMACEN.MainAlmacen)MdiParent).perfil, Name).Substring(0, 1);
                    break;
                case "MainLogistica":
                    XNIVEL = VariablesPublicas.Get_nivelperfil(((DL0Logistica.MainLogistica)MdiParent).perfil, Name).Substring(0, 1);
                    break;
                default:
                    break;
            }

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

        private void form_bloqueado(Boolean var)
        {
            try
            {
                dominioid.Enabled = false;
                dominioname.Enabled = false;
                moduloid.Enabled = false;
                moduloname.Enabled = false;
                xlocal.Enabled = false;
                localname.Enabled = false;

                tipodoc.Enabled = !var;
                tipodocname.Enabled = var;
                tipodocmanejaserie.Enabled = var;
                tipodocautomatico.Enabled = var;
                visiblealmac.Enabled = var;
                tipodocnumero.Enabled = var;
                tipodocnumcopias.Enabled = var;
                almacaccionid.Enabled = var;
                tipodoccontratipo.Enabled = var;
                tipodoctipotransac.Enabled = var;
                tipodocstatcostopromed.Enabled = var;
                ctacteaccionid.Enabled = var;
                manejaastocont.Enabled = var;

                txt_dominioid.Enabled = false;
                txt_dominioname.Enabled = false;
                txt_moduloid.Enabled = false;
                txt_moduloname.Enabled = false;
                txt_local.Enabled = false;
                txt_localname.Enabled = false;
                txt_tipodoc.Enabled = false;
                txt_tipodocname.Enabled = false;
                gridtipodocserie.ReadOnly = true;

                gridtipodoc.ReadOnly = true;
                gridtipodoc.Enabled = !var;
                cbo_buscar.Enabled = !var;
                txt_criterio.Enabled = !var;
                btn_busqueda.Enabled = !var;

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

                btn_buscar.Enabled = false;
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
                NIVEL_FORMS();
                limpiar_documento();
                form_bloqueado(false);
                tipodoc.Text = string.Empty;
                btn_nuevo.Enabled = true;
                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;
                btn_buscar.Enabled = true;
                btn_salir.Enabled = true;

                ssModo = string.Empty;
            }
        }
        private void form_cargar_datos(String posicion)
        {
            try
            {
                var BL = new modulo_local_tipodocBL();
                var BE = new tb_modulo_local_tipodoc();
                var dt = new DataTable();

                BE.dominioid = dominioid.Text.Trim();
                BE.moduloid = moduloid.Text.Trim();
                BE.local = xlocal.Text.Trim();
                BE.tipodoc = tipodoc.Text.Trim();
                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    ssModo = "EDIT";
                    limpiar_documento();
                    dominioid.Text = dt.Rows[0]["dominioid"].ToString().Trim();
                    dominioname.Text = dt.Rows[0]["dominioname"].ToString().Trim();
                    moduloid.Text = dt.Rows[0]["moduloid"].ToString().Trim();
                    moduloname.Text = dt.Rows[0]["moduloname"].ToString().Trim();
                    xlocal.Text = dt.Rows[0]["local"].ToString().Trim();
                    localname.Text = dt.Rows[0]["localname"].ToString().Trim();
                    tipodoc.Text = dt.Rows[0]["tipodoc"].ToString().Trim();
                    tipodocname.Text = dt.Rows[0]["tipodocname"].ToString().Trim();
                    if (dt.Rows[0]["tipodocmanejaserie"].ToString().Trim().Length > 0)
                    {
                        tipodocmanejaserie.Checked = Convert.ToBoolean(dt.Rows[0]["tipodocmanejaserie"]);
                        if (tipodocmanejaserie.Checked)
                        {
                            tabControl1.TabPages.Add(tabtipodocserie);
                        }
                    }
                    if (dt.Rows[0]["tipodocautomatico"].ToString().Trim().Length > 0)
                    {
                        tipodocautomatico.Checked = Convert.ToBoolean(dt.Rows[0]["tipodocautomatico"]);
                    }
                    if (dt.Rows[0]["visiblealmac"].ToString().Trim().Length > 0)
                    {
                        visiblealmac.Checked = Convert.ToBoolean(dt.Rows[0]["visiblealmac"]);
                    }
                    tipodocnumero.Text = dt.Rows[0]["tipodocnumero"].ToString().Trim();
                    tipodocnumcopias.Text = dt.Rows[0]["tipodocnumcopias"].ToString().Trim();
                    almacaccionid.Text = dt.Rows[0]["almacaccionid"].ToString().Trim();
                    tipodoccontratipo.Text = dt.Rows[0]["tipodoccontratipo"].ToString().Trim();
                    tipodoctipotransac.Text = dt.Rows[0]["tipodoctipotransac"].ToString().Trim();
                    tipodocstatcostopromed.Text = dt.Rows[0]["tipodocstatcostopromed"].ToString().Trim();
                    ctacteaccionid.Text = dt.Rows[0]["ctacteaccionid"].ToString().Trim();
                    manejaastocont.Text = dt.Rows[0]["manejaastocont"].ToString().Trim();

                    btn_editar.Enabled = true;
                    btn_eliminar.Enabled = true;
                    btn_imprimir.Enabled = true;

                    btn_primero.Enabled = true;
                    btn_anterior.Enabled = true;
                    btn_siguiente.Enabled = true;
                    btn_ultimo.Enabled = true;

                    btn_buscar.Enabled = true;
                    btn_log.Enabled = true;
                    btn_salir.Enabled = true;
                }
                else
                {
                    limpiar_documento();
                    btn_editar.Enabled = false;
                    btn_eliminar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void data_cbo_buscar()
        {
            var test = new Dictionary<string, string>();
            test.Add("01", "NOMBRE DOCUMENTO");
            test.Add("02", "TIPO DOC");
            test.Add("03", "MANEJA SERIE");
            test.Add("04", "ES AUTOMATICO");
            cbo_buscar.DataSource = new BindingSource(test, null);
            cbo_buscar.DisplayMember = "Value";
            cbo_buscar.ValueMember = "Key";
        }
        private void ValidaDominio()
        {
            if (dominioid.Text.Trim().Length > 0)
            {
                var BL = new sys_dominioBL();
                var BE = new tb_sys_dominio();
                var dt = new DataTable();

                BE.dominioid = dominioid.Text.Trim().PadLeft(2, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    dominioid.Text = dt.Rows[0]["dominioid"].ToString().Trim();
                    dominioname.Text = dt.Rows[0]["dominioname"].ToString().Trim();
                }
                else
                {
                    dominioid.Text = string.Empty;
                    dominioname.Text = string.Empty;
                    moduloid.Text = string.Empty;
                    moduloname.Text = string.Empty;
                    xlocal.Text = string.Empty;
                    localname.Text = string.Empty;
                    moduloid.Enabled = false;
                    xlocal.Enabled = false;
                }
            }
            else
            {
                dominioid.Text = string.Empty;
                dominioname.Text = string.Empty;
                moduloid.Text = string.Empty;
                moduloname.Text = string.Empty;
                xlocal.Text = string.Empty;
                localname.Text = string.Empty;
                moduloid.Enabled = false;
                xlocal.Enabled = false;
            }
        }
        private void ValidaModulo()
        {
            if (moduloid.Text.Trim().Length > 0)
            {
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();

                BE.dominioid = dominioid.Text.Trim();
                BE.moduloid = moduloid.Text.Trim().PadLeft(4, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    moduloid.Text = dt.Rows[0]["moduloid"].ToString().Trim();
                    moduloname.Text = dt.Rows[0]["moduloname"].ToString().Trim();
                }
                else
                {
                    moduloid.Text = string.Empty;
                    moduloname.Text = string.Empty;
                    xlocal.Text = string.Empty;
                    localname.Text = string.Empty;
                    xlocal.Enabled = false;
                }
            }
            else
            {
                moduloid.Text = string.Empty;
                moduloname.Text = string.Empty;
                xlocal.Text = string.Empty;
                localname.Text = string.Empty;
                xlocal.Enabled = false;
            }
        }
        private void ValidaLocal()
        {
            if (xlocal.Text.Trim().Length > 0)
            {
                var BL = new sys_localBL();
                var BE = new tb_sys_local();
                var dt = new DataTable();

                BE.dominioid = dominioid.Text.Trim();
                BE.moduloid = moduloid.Text.Trim();
                BE.local = xlocal.Text.Trim().PadLeft(3, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    xlocal.Text = dt.Rows[0]["local"].ToString().Trim();
                    localname.Text = dt.Rows[0]["localname"].ToString().Trim();

                    tipodoc.Enabled = true;
                    tipodoc.Focus();
                }
                else
                {
                    xlocal.Text = string.Empty;
                    localname.Text = string.Empty;
                    xlocal.Enabled = true;
                }
            }
            else
            {
                xlocal.Text = string.Empty;
                localname.Text = string.Empty;
                xlocal.Enabled = true;
            }
        }
        private void ValidaTipodoc_nuevo()
        {
            var BL = new modulo_local_tipodocBL();
            var BE = new tb_modulo_local_tipodoc();
            var dt = new DataTable();

            BE.dominioid = dominioid.Text.Trim();
            BE.moduloid = moduloid.Text.Trim();
            BE.local = xlocal.Text.Trim();
            BE.tipodoc = tipodoc.Text.Trim();

            dt = BL.GetAll(EmpresaID, BE).Tables[0];

            if (dt.Rows.Count == 0)
            {
                mensaje.Text = "VALIDO";
                mensaje.ForeColor = Color.Green;
                form_bloqueado(true);
                tipodocname.Focus();

                dominioid.Enabled = false;
                moduloid.Enabled = false;
                xlocal.Enabled = false;

                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
            }
            else
            {
                mensaje.Text = "YA EXISTE";
                mensaje.ForeColor = Color.Red;
                tipodoc.Text = string.Empty;
            }
        }
        private void ValidaTipodoc_nuevo_serdoc()
        {
            var BL = new modulo_local_tipodocseriesBL();
            var BE = new tb_modulo_local_tipodocseries();
            var dt = new DataTable();

            BE.dominioid = txt_dominioid.Text.Trim();
            BE.moduloid = txt_moduloid.Text.Trim();
            BE.local = txt_local.Text.Trim();
            BE.tipodoc = txt_tipodoc.Text.Trim();
            BE.serdoc = tipodocserie.Text.Trim();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];

            if (dt.Rows.Count == 0 && Convert.ToInt16(tipodocserie.Text.Trim().PadLeft(1, '0')) > 0)
            {
                mensajesd.Text = "VALIDO";
                mensajesd.ForeColor = Color.Green;
                tipodocserienumero.Enabled = true;
                tipodocserienumero.Focus();

                btn_nuevosd.Enabled = false;
                btn_grabarsd.Enabled = true;
                btn_eliminarsd.Enabled = false;
                btn_editarsd.Enabled = false;
                btn_calcelarsd.Enabled = true;
            }
            else
            {
                mensajesd.Text = "YA EXISTE";
                mensajesd.ForeColor = Color.Red;
                tipodocserie.Focus();

                btn_nuevosd.Enabled = false;
                btn_grabarsd.Enabled = false;
                btn_eliminarsd.Enabled = false;
                btn_editarsd.Enabled = false;
                btn_calcelarsd.Enabled = true;
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
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData )
        {
            if (keyData == Keys.Enter)
            {
                if (GetNextControl(ActiveControl, true) != null)
                {
                    SendKeys.Send("\t");
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
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

        private void AyudaDominio(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all";
                frmayuda.titulo = "<< AYUDA  TABLA DOMINIO >>";
                frmayuda.sqlquery = "SELECT dominioid, dominioname FROM tb_sys_dominio";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where";
                frmayuda.sqland = string.Empty;
                frmayuda.criteriosbusqueda = new string[] { "DOMINIO", "CODIGO" };
                frmayuda.columbusqueda = "dominioname,dominioid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeDominio;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
        private void RecibeDominio(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                dominioid.Text = resultado1.Trim();
                dominioname.Text = resultado2.Trim();
            }
        }

        private void AyudaModulo(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all";
                frmayuda.titulo = "<< AYUDA TABLA MODULO >>";
                frmayuda.sqlquery = "SELECT moduloid, moduloname, dominioid FROM tb_sys_modulo";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where dominioid = '" + dominioid.Text.Trim() + "'";
                frmayuda.sqland = "and";
                frmayuda.criteriosbusqueda = new string[] { "MODULO", "CODIGO" };
                frmayuda.columbusqueda = "moduloname,moduloid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeModulo;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
        private void RecibeModulo(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                moduloid.Text = resultado1.Trim();
                moduloname.Text = resultado2.Trim();
            }
        }

        private void AyudaLocal(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all";
                frmayuda.titulo = "<< AYUDA TABLA LOCAL >>";
                frmayuda.sqlquery = "SELECT local, localname, dominioid, moduloid FROM tb_sys_local";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where dominioid = '" + dominioid.Text.Trim() + "' and moduloid = '" + moduloid.Text.Trim() + "'";
                frmayuda.sqland = "and";
                frmayuda.criteriosbusqueda = new string[] { "LOCAL", "CODIGO" };
                frmayuda.columbusqueda = "localname,local";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeLocal;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
        private void RecibeLocal(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                xlocal.Text = resultado1.Trim();
                localname.Text = resultado2.Trim();
            }
        }

        private void AyudaTipodoc(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all";
                frmayuda.titulo = "<< AYUDA TABLA TIPOS DE DOCUMENTOS >>";
                frmayuda.sqlquery = "select ttd.dominioid, ttd.moduloid, ttd.local, ttd.tipodoc, ttd.tipodocname,tsd.dominioname, tsm.moduloname, tsl.localname from tb_modulo_local_tipodoc ttd";
                frmayuda.sqlinner = "inner join tb_sys_dominio tsd on ttd.dominioid = tsd.dominioid " +
                                    "inner join tb_sys_modulo tsm on ttd.dominioid = tsm.dominioid and ttd.moduloid = tsm.moduloid " +
                                    "inner join tb_sys_local tsl on ttd.dominioid = tsl.dominioid and ttd.moduloid = tsl.moduloid and ttd.[local] = tsl.[local]";
                frmayuda.sqlwhere = "where";
                frmayuda.sqland = string.Empty;
                frmayuda.criteriosbusqueda = new string[] { "DOCUMENTO", "CODIGO", "DOMINIO", "MODULO", "LOCAL" };
                frmayuda.columbusqueda = "ttd.tipodocname,ttd.tipodoc,tsd.dominioname,tsm.moduloname,tsl.localname";
                frmayuda.returndatos = "0,1,2,3";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeTipodoc;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
        private void RecibeTipodoc(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length == 2 && resultado2.Trim().Length == 4 && resultado3.Trim().Length == 3 && resultado4.Trim().Length == 2)
            {
                dominioid.Text = resultado1.Trim();
                moduloid.Text = resultado2.Trim();
                xlocal.Text = resultado3.Trim();
                tipodoc.Text = resultado4.Trim();
                form_cargar_datos(string.Empty);
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
                BE.detalle = dominioid.Text.Trim() + moduloid.Text.Trim() + tipodoc.Text.Trim() + "/" + tipodocname.Text.Trim().ToUpper() + "/" + XGLOSA;

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
                tipodoc.Text = string.Empty;
                tipodocname.Text = string.Empty;
                tipodocmanejaserie.Checked = false;
                tipodocautomatico.Checked = false;
                visiblealmac.Checked = true;
                tipodocnumero.Text = "0";
                tipodocnumcopias.Text = "0";
                almacaccionid.Text = string.Empty;
                tipodoccontratipo.Text = string.Empty;
                tipodoctipotransac.Text = string.Empty;
                tipodocstatcostopromed.Text = string.Empty;
                ctacteaccionid.Text = string.Empty;
                manejaastocont.Text = string.Empty;
                mensaje.Text = string.Empty;

                txt_tipodoc.Text = string.Empty;
                txt_tipodocname.Text = string.Empty;
                tipodocserie.Text = string.Empty;
                tipodocserienumero.Text = "0";
                mensajesd.Text = string.Empty;

                tabControl1.TabPages.Remove(tabtipodocserie);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void nuevo()
        {
            ssModo = "NEW";

            limpiar_documento();
            form_bloqueado(false);
            tipodoc.Focus();

            btn_cancelar.Enabled = true;
        }
        private void Insert()
        {
            try
            {
                if (dominioid.Text.Trim().Length != 2 || moduloid.Text.Trim().Length != 4 || xlocal.Text.Trim().Length != 3)
                {
                    MessageBox.Show("Falata datos en Dominio - Modulo - Local !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (tipodoc.Text.Trim().Length != 2)
                    {
                        MessageBox.Show("Falta Tipo de Documento !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (tipodocname.Text.Trim().Length == 0)
                        {
                            MessageBox.Show("Ingrese nombre de Documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            var BL = new modulo_local_tipodocBL();
                            var BE = new tb_modulo_local_tipodoc();

                            BE.dominioid = dominioid.Text.Trim();
                            BE.moduloid = moduloid.Text.Trim();
                            BE.local = xlocal.Text.Trim();
                            BE.tipodoc = tipodoc.Text.Trim().ToUpper();
                            BE.tipodocname = tipodocname.Text.Trim().ToUpper();
                            BE.tipodocmanejaserie = tipodocmanejaserie.Checked;
                            BE.tipodocautomatico = tipodocautomatico.Checked;
                            BE.visiblealmac = visiblealmac.Checked;
                            BE.tipodocnumero = Convert.ToDecimal(tipodocnumero.Text.Trim().PadLeft(1, '0'));
                            BE.tipodocnumcopias = Convert.ToInt16(tipodocnumcopias.Text.Trim().PadLeft(1, '0'));
                            BE.almacaccionid = almacaccionid.Text.Trim().ToUpper();
                            BE.tipodoccontratipo = tipodoccontratipo.Text.Trim().ToUpper();
                            BE.tipodoctipotransac = tipodoctipotransac.Text.Trim().ToUpper();
                            BE.tipodocstatcostopromed = tipodocstatcostopromed.Text.Trim().ToUpper();
                            BE.ctacteaccionid = ctacteaccionid.Text.Trim().ToUpper();
                            BE.manejaastocont = manejaastocont.Text.Trim().ToUpper();
                            BE.usuar = VariablesPublicas.Usuar.Trim();
                            BE.status = "0";

                            if (BL.Insert(EmpresaID, BE))
                            {
                                MessageBox.Show("Datos grabados correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                procesado = true;
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
        private void Insert_serdoc()
        {
            try
            {
                if (txt_dominioid.Text.Trim().Length != 2 || txt_moduloid.Text.Trim().Length != 4 || txt_local.Text.Trim().Length != 3)
                {
                    MessageBox.Show("Falata datos en Dominio - Modulo - Local !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (txt_tipodoc.Text.Trim().Length != 2)
                    {
                        MessageBox.Show("Falta Tipo de Documento !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (tipodocserie.Text.Trim().Length != 4)
                        {
                            MessageBox.Show("Falta Serie de Documento !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            var BL = new modulo_local_tipodocseriesBL();
                            var BE = new tb_modulo_local_tipodocseries();

                            BE.dominioid = txt_dominioid.Text.Trim();
                            BE.moduloid = txt_moduloid.Text.Trim();
                            BE.local = txt_local.Text.Trim();
                            BE.tipodoc = txt_tipodoc.Text.Trim().ToUpper();
                            BE.serdoc = tipodocserie.Text.Trim().PadLeft(4, '0');
                            BE.numero = Convert.ToInt16(tipodocserienumero.Text.Trim().PadLeft(1, '0'));
                            BE.usuar = VariablesPublicas.Usuar.Trim();
                            BE.status = "0";

                            if (BL.Insert(EmpresaID, BE))
                            {
                                MessageBox.Show("Datos grabados correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                procesado = true;
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
            try
            {
                if (dominioid.Text.Trim().Length != 2 || moduloid.Text.Trim().Length != 4 || xlocal.Text.Trim().Length != 3)
                {
                    MessageBox.Show("Falata datos en Dominio - Modulo - Local !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (tipodoc.Text.Trim().Length != 2)
                    {
                        MessageBox.Show("Falta Tipo de Documento !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (tipodocname.Text.Trim().Length == 0)
                        {
                            MessageBox.Show("Ingrese nombre de Documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            var BL = new modulo_local_tipodocBL();
                            var BE = new tb_modulo_local_tipodoc();

                            BE.dominioid = dominioid.Text.Trim();
                            BE.moduloid = moduloid.Text.Trim();
                            BE.local = xlocal.Text.Trim();
                            BE.tipodoc = tipodoc.Text.Trim().ToUpper();
                            BE.tipodocname = tipodocname.Text.Trim().ToUpper();
                            BE.tipodocmanejaserie = tipodocmanejaserie.Checked;
                            BE.tipodocautomatico = tipodocautomatico.Checked;
                            BE.visiblealmac = visiblealmac.Checked;
                            BE.tipodocnumero = Convert.ToDecimal(tipodocnumero.Text.Trim().PadLeft(1, '0'));
                            BE.tipodocnumcopias = Convert.ToInt16(tipodocnumcopias.Text.Trim().PadLeft(1, '0'));
                            BE.almacaccionid = almacaccionid.Text.Trim().ToUpper();
                            BE.tipodoccontratipo = tipodoccontratipo.Text.Trim().ToUpper();
                            BE.tipodoctipotransac = tipodoctipotransac.Text.Trim().ToUpper();
                            BE.tipodocstatcostopromed = tipodocstatcostopromed.Text.Trim().ToUpper();
                            BE.ctacteaccionid = ctacteaccionid.Text.Trim().ToUpper();
                            BE.manejaastocont = manejaastocont.Text.Trim().ToUpper();
                            BE.usuar = VariablesPublicas.Usuar.Trim();
                            BE.status = "0";

                            if (BL.Update(EmpresaID, BE))
                            {
                                SEGURIDAD_LOG("M");
                                MessageBox.Show("Datos modificado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                procesado = true;
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
        private void Update_serdoc()
        {
            try
            {
                if (txt_dominioid.Text.Trim().Length != 2 || txt_moduloid.Text.Trim().Length != 4 || txt_local.Text.Trim().Length != 3)
                {
                    MessageBox.Show("Falata datos en Dominio - Modulo - Local !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (txt_tipodoc.Text.Trim().Length != 2)
                    {
                        MessageBox.Show("Falta Tipo de Documento !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (tipodocserie.Text.Trim().Length != 4)
                        {
                            MessageBox.Show("Falta Serie de Documento !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            var BL = new modulo_local_tipodocseriesBL();
                            var BE = new tb_modulo_local_tipodocseries();

                            BE.dominioid = txt_dominioid.Text.Trim();
                            BE.moduloid = txt_moduloid.Text.Trim();
                            BE.local = txt_local.Text.Trim();
                            BE.tipodoc = txt_tipodoc.Text.Trim().ToUpper();
                            BE.serdoc = tipodocserie.Text.Trim().PadLeft(4, '0');
                            BE.numero = Convert.ToInt16(tipodocserienumero.Text.Trim().PadLeft(1, '0'));
                            BE.usuar = VariablesPublicas.Usuar.Trim();
                            BE.status = "0";

                            if (BL.Update(EmpresaID, BE))
                            {
                                SEGURIDAD_LOG("M");
                                MessageBox.Show("Datos modificado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                procesado = true;
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
                if (dominioid.Text.Trim().Length != 2 || moduloid.Text.Trim().Length != 4 || xlocal.Text.Trim().Length != 3)
                {
                    MessageBox.Show("Falata datos en Dominio - Modulo - Local !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (tipodoc.Text.Trim().Length != 2)
                    {
                        MessageBox.Show("Falta Tipo de Documento !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new modulo_local_tipodocBL();
                        var BE = new tb_modulo_local_tipodoc();

                        BE.dominioid = dominioid.Text.Trim();
                        BE.moduloid = moduloid.Text.Trim();
                        BE.local = xlocal.Text.Trim();
                        BE.tipodoc = tipodoc.Text.Trim().ToUpper();
                        BE.usuar = VariablesPublicas.Usuar.Trim();

                        if (BL.Delete(EmpresaID, BE))
                        {
                            SEGURIDAD_LOG("E");
                            MessageBox.Show("Datos Eliminado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            NIVEL_FORMS();
                            limpiar_documento();
                            form_bloqueado(false);
                            data_Tablatipodoc();
                            btn_nuevo.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Delete_serdoc()
        {
            try
            {
                if (txt_dominioid.Text.Trim().Length != 2 || txt_moduloid.Text.Trim().Length != 4 || txt_local.Text.Trim().Length != 3)
                {
                    MessageBox.Show("Falata datos en Dominio - Modulo - Local !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (txt_tipodoc.Text.Trim().Length != 2)
                    {
                        MessageBox.Show("Falta Tipo de Documento !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (tipodocserie.Text.Trim().Length != 4)
                        {
                            MessageBox.Show("Falta Serie de Documento !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            var BL = new modulo_local_tipodocseriesBL();
                            var BE = new tb_modulo_local_tipodocseries();

                            BE.dominioid = txt_dominioid.Text.Trim();
                            BE.moduloid = txt_moduloid.Text.Trim();
                            BE.local = txt_local.Text.Trim();
                            BE.tipodoc = txt_tipodoc.Text.Trim().ToUpper();
                            BE.serdoc = tipodocserie.Text.Trim().PadLeft(4, '0');
                            BE.usuar = VariablesPublicas.Usuar.Trim();

                            if (BL.Delete(EmpresaID, BE))
                            {
                                SEGURIDAD_LOG("E");
                                MessageBox.Show("Datos Eliminado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                NIVEL_FORMS();

                                data_Tablatipodocserie();
                                tipodocserie.Enabled = false;
                                tipodocserienumero.Enabled = false;
                                mensajesd.Text = string.Empty;

                                btn_nuevosd.Enabled = true;
                                btn_grabarsd.Enabled = false;
                                btn_eliminarsd.Enabled = false;
                                btn_editarsd.Enabled = true;
                                btn_calcelarsd.Enabled = false;
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

        private void Frm_constantesgenerales_Activated(object sender, EventArgs e)
        {
        }
        private void Frm_constantesgenerales_Load(object sender, EventArgs e)
        {
            EmpresaID = VariablesPublicas.EmpresaID;

            switch (this.Parent.Parent.Name)
            {
                case "MainMercaderia":
                    dominio = ((MERCADERIA.MainMercaderia)MdiParent).dominioid;
                    modulo = ((MERCADERIA.MainMercaderia)MdiParent).moduloid;
                    local = ((MERCADERIA.MainMercaderia)MdiParent).local;
                    break;
                case "MainAlmacen":
                    dominio = ((D60ALMACEN.MainAlmacen)MdiParent).dominioid;
                    modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
                    local = ((D60ALMACEN.MainAlmacen)MdiParent).local;
                    break;
                case "MainLogistica":
                    dominio = ((DL0Logistica.MainLogistica)MdiParent).dominioid;
                    modulo = ((DL0Logistica.MainLogistica)MdiParent).moduloid;
                    local = ((DL0Logistica.MainLogistica)MdiParent).local;
                    break;
                default:
                    break;
            }

            NIVEL_FORMS();

            data_cbo_buscar();
            Tablatipodoc = new DataTable();
            Tablatipodocserie = new DataTable();

            dominioid.Text = dominio;
            moduloid.Text = modulo;
            xlocal.Text = local;
            ValidaDominio();
            ValidaModulo();
            ValidaLocal();
            data_Tablatipodoc();

            limpiar_documento();

            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_primero.Enabled = true;
            btn_anterior.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_ultimo.Enabled = true;
            btn_buscar.Enabled = true;
            btn_salir.Enabled = true;
        }
        private void Frm_constantesgenerales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tc = (TabControl)sender;
            var s = string.Empty;
            var tp = tc.TabPages[tc.SelectedIndex];
            s = tp.Name;
            if (s == "tabtipodocserie")
            {
                txt_dominioid.Text = dominioid.Text.Trim().ToUpper();
                txt_dominioname.Text = dominioname.Text.Trim().ToUpper();
                txt_moduloid.Text = moduloid.Text.Trim().ToUpper();
                txt_moduloname.Text = moduloname.Text.Trim().ToUpper();
                txt_local.Text = xlocal.Text.Trim().ToUpper();
                txt_localname.Text = localname.Text.Trim().ToUpper();
                txt_tipodoc.Text = tipodoc.Text.Trim().ToUpper();
                txt_tipodocname.Text = tipodocname.Text.Trim().ToUpper();

                data_Tablatipodocserie();

                tipodocserie.Enabled = false;
                tipodocserienumero.Enabled = false;
                btn_nuevosd.Enabled = true;
                btn_grabarsd.Enabled = false;
                btn_eliminarsd.Enabled = false;
                btn_editarsd.Enabled = false;
                btn_calcelarsd.Enabled = false;
            }
        }

        private void dominioid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaDominio(string.Empty);
            }
        }
        private void dominioid_KeyUp(object sender, KeyEventArgs e)
        {
            if (dominioid.Text.Trim().Length == 2)
            {
                ValidaDominio();
            }
        }
        private void moduloid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaModulo(string.Empty);
            }
        }
        private void moduloid_KeyUp(object sender, KeyEventArgs e)
        {
            if (moduloid.Text.Trim().Length == 4)
            {
                ValidaModulo();
            }
        }
        private void xlocal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaLocal(string.Empty);
            }
        }
        private void xlocal_KeyUp(object sender, KeyEventArgs e)
        {
            if (xlocal.Text.Trim().Length == 3)
            {
                ValidaLocal();
            }
        }
        private void tipodoc_KeyUp(object sender, KeyEventArgs e)
        {
            if (tipodoc.Text.Trim().Length == 2)
            {
                if (ssModo == "NEW")
                {
                    ValidaTipodoc_nuevo();
                }
                else
                {
                    form_cargar_datos(string.Empty);
                }
            }
        }
        private void tipodoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaTipodoc(string.Empty);
            }
        }
        private void tipodocnumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(sender, e);
        }
        private void tipodocnumcopias_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(sender, e);
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
            if (XNIVEL == "0" || XNIVEL == "1")
            {
                ssModo = "EDIT";

                form_bloqueado(true);
                tabControl1.TabPages.Remove(tabtipodocserie);
                dominioid.Enabled = false;
                moduloid.Enabled = false;
                xlocal.Enabled = false;
                tipodocname.Focus();

                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
            }
        }
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            form_accion_cancelEdicion(1);
        }
        private void btn_grabar_Click(object sender, EventArgs e)
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
                data_Tablatipodoc();
                form_bloqueado(false);

                btn_nuevo.Enabled = true;

                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;

                btn_buscar.Enabled = true;
                btn_salir.Enabled = true;

                if (tipodocmanejaserie.Checked)
                {
                    tabControl1.TabPages.Add(tabtipodocserie);
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
                if (Tablatipodoc.Rows.Count > 0)
                {
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
        private void btn_log_Click(object sender, EventArgs e)
        {
            var oform = new Seguridadlog.FrmSeguridad();
            var xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio;
            oform._Nombre = Name;
            oform._ClaveForm = xclave;
            oform.Owner = this;
            oform.ShowDialog();
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void data_Tablatipodoc()
        {
            try
            {
                if (Tablatipodoc.Rows.Count > 0)
                {
                    Tablatipodoc.Rows.Clear();
                }
                var BL = new modulo_local_tipodocBL();
                var BE = new tb_modulo_local_tipodoc();

                BE.dominioid = dominioid.Text.Trim();
                BE.moduloid = moduloid.Text.Trim();
                BE.local = xlocal.Text.Trim();

                switch (cbo_buscar.SelectedValue.ToString())
                {
                    case "01":
                        BE.tipodocname = txt_criterio.Text.Trim();
                        break;
                    case "02":
                        if (txt_criterio.Text.Trim().Length > 0)
                        {
                            BE.tipodoc = txt_criterio.Text.Trim().ToUpper();
                        }
                        break;
                    case "03":
                        BE.tipodocmanejaserie = true;
                        break;
                    case "04":
                        BE.tipodocautomatico = true;
                        break;
                    default:
                        break;
                }

                Tablatipodoc = BL.GetAll(EmpresaID, BE).Tables[0];
                if (Tablatipodoc.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    gridtipodoc.DataSource = Tablatipodoc;
                    gridtipodoc.Rows[0].Selected = false;
                    gridtipodoc.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridtipodoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridtipodoc.CurrentRow != null)
                {
                    var xdominioid = string.Empty;
                    var xmoduloid = string.Empty;
                    var xxlocal = string.Empty;
                    var xtipodoc = string.Empty;
                    xdominioid = gridtipodoc.Rows[e.RowIndex].Cells["gdominioid"].Value.ToString().Trim();
                    xmoduloid = gridtipodoc.Rows[e.RowIndex].Cells["gmoduloid"].Value.ToString().Trim();
                    xxlocal = gridtipodoc.Rows[e.RowIndex].Cells["glocal"].Value.ToString().Trim();
                    xtipodoc = gridtipodoc.Rows[e.RowIndex].Cells["gtipodoc"].Value.ToString().Trim();
                    data_tipodoc(xdominioid, xmoduloid, xxlocal, xtipodoc);
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void gridtipodoc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xdominioid = string.Empty;
                var xmoduloid = string.Empty;
                var xxlocal = string.Empty;
                String xtipodoc;
                xdominioid = gridtipodoc.Rows[gridtipodoc.CurrentRow.Index].Cells["gdominioid"].Value.ToString().Trim();
                xmoduloid = gridtipodoc.Rows[gridtipodoc.CurrentRow.Index].Cells["gmoduloid"].Value.ToString().Trim();
                xxlocal = gridtipodoc.Rows[gridtipodoc.CurrentRow.Index].Cells["glocal"].Value.ToString().Trim();
                xtipodoc = gridtipodoc.Rows[gridtipodoc.CurrentRow.Index].Cells["gtipodoc"].Value.ToString().Trim();
                data_tipodoc(xdominioid, xmoduloid, xxlocal, xtipodoc);
            }
        }

        private void gridtipodoc_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridtipodoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridtipodoc[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(39, 95, 178);
            gridtipodoc[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);
        }

        private void gridtipodoc_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            gridtipodoc[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }
        private void data_tipodoc(String xdominioid, String xmoduloid, String xxlocal, String xtipodoc)
        {
            form_bloqueado(false);
            var rowtipodoc = Tablatipodoc.Select("dominioid='" + xdominioid.Trim() + "' and moduloid= '" + xmoduloid.Trim() +
                                   "' and local='" + xxlocal.Trim() + "' and tipodoc='" + xtipodoc.Trim() + "'");
            if (rowtipodoc.Length > 0)
            {
                foreach (DataRow row in rowtipodoc)
                {
                    ssModo = "EDIT";
                    limpiar_documento();
                    tabControl1.TabPages.Remove(tabtipodocserie);
                    dominioid.Text = row["dominioid"].ToString().Trim();
                    dominioname.Text = row["dominioname"].ToString().Trim();
                    moduloid.Text = row["moduloid"].ToString().Trim();
                    moduloname.Text = row["moduloname"].ToString().Trim();
                    xlocal.Text = row["local"].ToString().Trim();
                    localname.Text = row["localname"].ToString().Trim();
                    tipodoc.Text = row["tipodoc"].ToString().Trim();
                    tipodocname.Text = row["tipodocname"].ToString().Trim().Substring(5);
                    if (row["tipodocmanejaserie"].ToString().Trim().Length > 0)
                    {
                        tipodocmanejaserie.Checked = Convert.ToBoolean(row["tipodocmanejaserie"]);
                        if (tipodocmanejaserie.Checked)
                        {
                            tabControl1.TabPages.Add(tabtipodocserie);
                        }
                    }
                    if (row["tipodocautomatico"].ToString().Trim().Length > 0)
                    {
                        tipodocautomatico.Checked = Convert.ToBoolean(row["tipodocautomatico"]);
                    }
                    if (row["visiblealmac"].ToString().Trim().Length > 0)
                    {
                        visiblealmac.Checked = Convert.ToBoolean(row["visiblealmac"]);
                    }
                    tipodocnumero.Text = row["tipodocnumero"].ToString().Trim();
                    tipodocnumcopias.Text = row["tipodocnumcopias"].ToString().Trim();
                    almacaccionid.Text = row["almacaccionid"].ToString().Trim();
                    tipodoccontratipo.Text = row["tipodoccontratipo"].ToString().Trim();
                    tipodoctipotransac.Text = row["tipodoctipotransac"].ToString().Trim();
                    tipodocstatcostopromed.Text = row["tipodocstatcostopromed"].ToString().Trim();
                    ctacteaccionid.Text = row["ctacteaccionid"].ToString().Trim();
                    manejaastocont.Text = row["manejaastocont"].ToString().Trim();
                }

                btn_nuevo.Enabled = true;
                btn_editar.Enabled = true;
                btn_eliminar.Enabled = true;
                btn_imprimir.Enabled = true;

                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;

                btn_buscar.Enabled = true;
                btn_log.Enabled = true;
                btn_salir.Enabled = true;
            }
        }

        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            data_Tablatipodoc();
        }


        private void tipodocserie_KeyUp(object sender, KeyEventArgs e)
        {
            if (tipodocserie.Text.Trim().Length == 4)
            {
                if (ssModoDET == "NEW")
                {
                    ValidaTipodoc_nuevo_serdoc();
                }
            }
        }
        private void tipodocserienumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(sender, e);
        }
        private void btn_nuevosd_Click(object sender, EventArgs e)
        {
            ssModoDET = "NEW";
            tipodocserie.Text = string.Empty;
            tipodocserienumero.Text = "0";
            tipodocserie.Enabled = true;
            tipodocserienumero.Enabled = false;

            btn_nuevosd.Enabled = false;
            btn_grabarsd.Enabled = false;
            btn_eliminarsd.Enabled = false;
            btn_editarsd.Enabled = false;
            btn_calcelarsd.Enabled = true;
        }
        private void btn_grabarsd_Click(object sender, EventArgs e)
        {
            procesado = false;
            var sw_prosigue = false;
            if (ssModoDET == "NEW")
            {
                if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
                {
                    Insert_serdoc();
                }
            }
            else
            {
                if (XNIVEL == "0" || XNIVEL == "1")
                {
                    sw_prosigue = (MessageBox.Show("¿Desea Modificar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                    if (sw_prosigue)
                    {
                        Update_serdoc();
                    }
                }
            }
            if (procesado)
            {
                NIVEL_FORMS();
                data_Tablatipodocserie();
                tipodocserie.Enabled = false;
                tipodocserienumero.Enabled = false;
                mensajesd.Text = string.Empty;

                btn_nuevosd.Enabled = true;
                btn_grabarsd.Enabled = false;
                btn_eliminarsd.Enabled = false;
                btn_editarsd.Enabled = true;
                btn_calcelarsd.Enabled = false;
            }
        }
        private void btn_eliminarsd_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0")
            {
                var sw_prosigue = false;
                sw_prosigue = (MessageBox.Show("¿Desea Eliminar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                if (sw_prosigue)
                {
                    Delete_serdoc();
                }
            }
        }
        private void btn_editarsd_Click(object sender, EventArgs e)
        {
            tipodocserienumero.Enabled = true;

            btn_nuevosd.Enabled = false;
            btn_grabarsd.Enabled = true;
            btn_eliminarsd.Enabled = true;
            btn_editarsd.Enabled = false;
            btn_calcelarsd.Enabled = true;
        }
        private void btn_calcelarsd_Click(object sender, EventArgs e)
        {
            tipodocserie.Text = string.Empty;
            tipodocserienumero.Text = "0";

            tipodocserie.Enabled = false;
            tipodocserienumero.Enabled = false;
            btn_nuevosd.Enabled = true;
            btn_grabarsd.Enabled = false;
            btn_eliminarsd.Enabled = false;
            btn_editarsd.Enabled = false;
            btn_calcelarsd.Enabled = false;
        }

        private void data_Tablatipodocserie()
        {
            try
            {
                if (Tablatipodocserie != null)
                {
                    Tablatipodocserie.Rows.Clear();
                }
                var BL = new modulo_local_tipodocseriesBL();
                var BE = new tb_modulo_local_tipodocseries();

                BE.dominioid = txt_dominioid.Text.Trim();
                BE.moduloid = txt_moduloid.Text.Trim();
                BE.local = txt_local.Text.Trim();
                BE.tipodoc = txt_tipodoc.Text.Trim();

                Tablatipodocserie = BL.GetAll(EmpresaID, BE).Tables[0];
                if (Tablatipodocserie.Rows.Count > 0)
                {
                    gridtipodocserie.DataSource = Tablatipodocserie;
                    gridtipodocserie.Rows[0].Selected = false;
                    gridtipodocserie.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridtipodocserie_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridtipodocserie.CurrentRow != null)
                {
                    var xserdoc = string.Empty;
                    xserdoc = gridtipodocserie.Rows[e.RowIndex].Cells["serdoc"].Value.ToString().Trim();
                    data_tipodocserie(xserdoc);
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void gridtipodocserie_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xserdoc = string.Empty;
                xserdoc = gridtipodocserie.Rows[gridtipodocserie.CurrentRow.Index].Cells["serdoc"].Value.ToString().Trim();
                data_tipodocserie(xserdoc);
            }
        }
        private void gridtipodocserie_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridtipodocserie.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridtipodocserie[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(39, 95, 178);
            gridtipodocserie[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);
        }
        private void gridtipodocserie_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            gridtipodocserie[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }
        private void data_tipodocserie(String xserdoc)
        {
            var rowtipodoc = Tablatipodocserie.Select("serdoc='" + xserdoc.Trim() + "'");
            if (rowtipodoc.Length > 0)
            {
                foreach (DataRow row in rowtipodoc)
                {
                    ssModoDET = "EDIT";
                    tipodocserie.Text = row["serdoc"].ToString().Trim();
                    tipodocserienumero.Text = row["numero"].ToString().Trim();
                    mensajesd.Text = string.Empty;

                    tipodocserie.Enabled = false;
                    tipodocserienumero.Enabled = false;
                    btn_nuevosd.Enabled = true;
                    btn_grabarsd.Enabled = false;
                    btn_eliminarsd.Enabled = true;
                    btn_editarsd.Enabled = true;
                    btn_calcelarsd.Enabled = false;
                }
            }
        }
    }
}
