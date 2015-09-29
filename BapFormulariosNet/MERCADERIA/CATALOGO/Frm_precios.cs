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

namespace BapFormulariosNet.MERCADERIA.CATALOGO
{
    public partial class Frm_precios : plantilla
    {
        private String EmpresaID = string.Empty;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable TablaListaPrecios;
        private DataRow row;
        private Boolean procesado = false;

        private String ssModo = "NEW";


        private static object vk_missing = System.Reflection.Missing.Value;
        private static object vk_false = false;
        private static object vk_true = true;
        private object vk_update_links = 0;
        private object vk_read_only = vk_true;
        private object vk_format = 1;
        private object vk_password = vk_missing;
        private object vk_write_res_password = vk_missing;
        private object vk_ignore_read_only_recommend = vk_true;
        private object vk_origin = vk_missing;
        private object vk_delimiter = vk_missing;
        private object vk_editable = vk_false;
        private object vk_notify = vk_false;
        private object vk_converter = vk_missing;
        private object vk_add_to_mru = vk_false;
        private object vk_local = vk_false;
        private object vk_corrupt_load = vk_false;


        public Frm_precios()
        {
            InitializeComponent();
            listaprecid.LostFocus += new System.EventHandler(grupoid_LostFocus);
        }

        private void PARAMETROS_TABLA()
        {
            var xxferfil = string.Empty;
            var f = (MainMercaderia)MdiParent;
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

        private void Llenar_ComboTiendas()
        {
            var BL = new tb_me_tiendaBL();
            var BE = new tb_me_tienda();
            var dt = new DataTable();

            BE.filtro = "1";

            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cboTiendaslist.DataSource = dt;
                cboTiendaslist.DisplayMember = "tiendalistname";
                cboTiendaslist.ValueMember = "tiendalist";
            }
        }



        private void form_bloqueado(Boolean var)
        {
            try
            {
                listaprecid.Enabled = !var;
                listaprecname.Enabled = var;
                fechaini.Enabled = var;
                fechafin.Enabled = var;
                cboTiendaslist.Enabled = var;
                cenestado.Enabled = var;
                tcamb.Enabled = var;

                btn_importar.Enabled = var;
                btn_CargarProductos.Enabled = var;
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
                btn_salir.Enabled = false;
                btn_exportar.Enabled = false;

                dgb_listaPrecios.ReadOnly = !var;
                dgb_listaPrecios.Columns["item"].ReadOnly = true;
                dgb_listaPrecios.Columns["lineaname"].ReadOnly = true;
                dgb_listaPrecios.Columns["gruponame"].ReadOnly = true;
                dgb_listaPrecios.Columns["subgrupoartic"].ReadOnly = true;
                dgb_listaPrecios.Columns["stock"].ReadOnly = true;
                dgb_listaPrecios.Columns["costoultimo"].ReadOnly = true;
                dgb_listaPrecios.Columns["ultcompra"].ReadOnly = true;
                dgb_listaPrecios.Columns["ultventa"].ReadOnly = true;
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
                listaprecid.Text = string.Empty;
                btn_nuevo.Enabled = true;
                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;
                btn_salir.Enabled = true;
                var dt = (DataTable)dgb_listaPrecios.DataSource;
                if (dt != null)
                {
                    dt.Clear();
                }

                if (TablaListaPrecios.Rows.Count > 0)
                {
                    TablaListaPrecios.Rows.Clear();
                    dgb_listaPrecios.DataSource = TablaListaPrecios;
                }
                ssModo = "NEW";
            }
        }

        private void form_cargar_datos(String posicion)
        {
            try
            {
                var BL = new tb_me_ListaPrecioBL();
                var BE = new tb_me_ListaPrecio();
                var dt = new DataTable();

                BE.moduloid = modulo;
                BE.listaprecid = Convert.ToInt32(listaprecid.Text.ToString().Trim() == string.Empty ? "0" : listaprecid.Text.ToString());
                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    limpiar_documento();
                    ssModo = "EDIT";

                    listaprecid.Text = dt.Rows[0]["listaprecid"].ToString().Trim();
                    listaprecname.Text = dt.Rows[0]["listaprecname"].ToString().Trim();

                    fechaini.Text = dt.Rows[0]["fechaini"].ToString().Trim();
                    fechafin.Text = dt.Rows[0]["fechafin"].ToString().Trim();

                    cboTiendaslist.SelectedValue = dt.Rows[0]["tiendalist"].ToString().Trim();
                    tcamb.Text = dt.Rows[0]["tcamb"].ToString().Trim();
                    cenestado.SelectedIndex = Convert.ToInt32(dt.Rows[0]["visible"]) ;

                    data_TablaListaPrecios();

                    btn_editar.Enabled = true;
                    btn_eliminar.Enabled = true;
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
                BE.detalle = listaprecid.Text.Trim() + "/" + listaprecname.Text.Trim().ToUpper() + "/" + XGLOSA;

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
                var fechadoc = Convert.ToString(DateTime.Today);
                get_tipocambio(fechadoc);
                fechaini.Text = Convert.ToString(DateTime.Today);
                fechafin.Text = Convert.ToString(DateTime.Today);
                listaprecid.Text = string.Empty;
                listaprecname.Text = string.Empty;
                listaprecname.Focus();
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
            listaprecid.Text = "NEW";
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            listaprecname.Focus();

            var dt = (DataTable)dgb_listaPrecios.DataSource;
            if (dt != null)
            {
                dt.Clear();
            }

            if (TablaListaPrecios.Rows.Count > 0)
            {
                TablaListaPrecios.Rows.Clear();
                dgb_listaPrecios.DataSource = TablaListaPrecios;
            }

            ssModo = "NEW";
        }

        private void Insert()
        {
            try
            {
                if (listaprecid.Text.ToString() == string.Empty)
                {
                    MessageBox.Show("Falta Codigo Lista !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (listaprecname.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese Nombre de Lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new tb_me_ListaPrecioBL();
                        var BE = new tb_me_ListaPrecio();

                        BE.moduloid = modulo;
                        BE.listaprecname = listaprecname.Text.ToUpper();
                        BE.fechaini = Convert.ToDateTime(fechaini.Text.ToString());
                        BE.fechafin = Convert.ToDateTime(fechafin.Text.ToString());
                        BE.tiendalist = Convert.ToInt32(cboTiendaslist.SelectedValue);
                        BE.estado = cenestado.SelectedIndex;
                        BE.tcamb = Convert.ToDecimal(tcamb.Text.ToString());
                        BE.usuar = VariablesPublicas.Usuar.Trim();


                        var Detalle = new tb_me_ListaPrecio.Item();
                        var ListaItems = new List<tb_me_ListaPrecio.Item>();

                        var item = 0;
                        foreach (DataRow fila in TablaListaPrecios.Rows)
                        {
                            Detalle = new tb_me_ListaPrecio.Item();

                            item++;

                            Detalle.lineaid = fila["lineaid"].ToString();
                            Detalle.grupoid = fila["grupoid"].ToString();
                            Detalle.subgrupoid = fila["subgrupoid"].ToString();
                            Detalle.precunit1 = Convert.ToDecimal(fila["pventa1"].ToString());
                            Detalle.precunit2 = Convert.ToDecimal(fila["pventa2"].ToString());

                            if (Convert.ToDecimal(fila["pventa1"]) > 0)
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
                            MessageBox.Show("Datos grabados correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            procesado = true;
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
                if (listaprecid.Text.ToString() == string.Empty)
                {
                    MessageBox.Show("Falta Codigo Lista !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (listaprecname.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese Nombre de Lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new tb_me_ListaPrecioBL();
                        var BE = new tb_me_ListaPrecio();

                        BE.moduloid = modulo;
                        BE.listaprecid = Convert.ToInt32(listaprecid.Text);
                        BE.listaprecname = listaprecname.Text.ToUpper();
                        BE.fechaini = Convert.ToDateTime(fechaini.Text.ToString());
                        BE.fechafin = Convert.ToDateTime(fechafin.Text.ToString());
                        BE.tiendalist = Convert.ToInt32(cboTiendaslist.SelectedValue);
                        BE.estado = cenestado.SelectedIndex;
                        BE.tcamb = Convert.ToDecimal(tcamb.Text.ToString());
                        BE.usuar = VariablesPublicas.Usuar.Trim();


                        var Detalle = new tb_me_ListaPrecio.Item();
                        var ListaItems = new List<tb_me_ListaPrecio.Item>();

                        var item = 0;
                        foreach (DataRow fila in TablaListaPrecios.Rows)
                        {
                            Detalle = new tb_me_ListaPrecio.Item();

                            item++;

                            Detalle.lineaid = fila["lineaid"].ToString();
                            Detalle.grupoid = fila["grupoid"].ToString();
                            Detalle.subgrupoid = fila["subgrupoid"].ToString();
                            Detalle.precunit1 = Convert.ToDecimal(fila["pventa1"].ToString());
                            Detalle.precunit2 = Convert.ToDecimal(fila["pventa2"].ToString());

                            if (Convert.ToDecimal(fila["pventa1"]) > 0)
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
                            MessageBox.Show("Datos modificado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            procesado = true;
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
                if (listaprecid.Text.ToString() == string.Empty)
                {
                    MessageBox.Show("Falta Codigo Lista !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_me_ListaPrecioBL();
                    var BE = new tb_me_ListaPrecio();

                    BE.moduloid = modulo;
                    BE.listaprecid = Convert.ToInt32(listaprecid.Text.ToString());

                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos Eliminado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        form_bloqueado(false);
                        btn_nuevo.Enabled = true;
                    }
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

        private void Frm_precios_Load(object sender, EventArgs e)
        {
            EmpresaID = VariablesPublicas.EmpresaID;
            PARAMETROS_TABLA();
            NIVEL_FORMS();

            TablaListaPrecios = new DataTable("Detalle_Precios");
            TablaListaPrecios.Columns.Add("item", typeof(String));
            TablaListaPrecios.Columns.Add("lineaid", typeof(String));
            TablaListaPrecios.Columns.Add("grupoid", typeof(String));
            TablaListaPrecios.Columns.Add("subgrupoid", typeof(String));
            TablaListaPrecios.Columns.Add("lineaname", typeof(String));
            TablaListaPrecios.Columns.Add("gruponame", typeof(String));
            TablaListaPrecios.Columns.Add("subgrupoartic", typeof(String));
            TablaListaPrecios.Columns.Add("stock", typeof(Decimal));
            TablaListaPrecios.Columns.Add("costoultimo", typeof(Decimal));
            TablaListaPrecios.Columns.Add("ultcompra", typeof(String));
            TablaListaPrecios.Columns.Add("ultventa", typeof(String));
            TablaListaPrecios.Columns.Add("pventa1", typeof(Decimal));
            TablaListaPrecios.Columns["pventa1"].DefaultValue = 0;
            TablaListaPrecios.Columns.Add("pventa2", typeof(Decimal));
            TablaListaPrecios.Columns["pventa2"].DefaultValue = 0;

            listaprecname.CharacterCasing = CharacterCasing.Upper;
            limpiar_documento();
            Llenar_ComboTiendas();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_primero.Enabled = true;
            btn_anterior.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_ultimo.Enabled = true;
            btn_salir.Enabled = true;


            cenestado.Items.Clear();
            cenestado.Items.AddRange("Oculto,Visible".Split(new char[] { ',' }));
            cenestado.SelectedIndex = 0;
        }

        private void CargarCbo_Precname()
        {
            var BL = new tb_me_ListaPrecioBL();
            var BE = new tb_me_ListaPrecio();

            var dt = new DataTable();
            BE.moduloid = modulo.ToString();
            BE.filtro = "1";

            dt = BL.GetAll(EmpresaID, BE).Tables[0];

            if (dt.Rows.Count > 0)
            {
            }
        }

        private void Frm_grupo_KeyDown(object sender, KeyEventArgs e)
        {
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

        private void grupoid_LostFocus(object sender, System.EventArgs e)
        {
            form_cargar_datos(string.Empty);
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
                listaprecname.Focus();

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
                form_bloqueado(false);

                btn_nuevo.Enabled = true;

                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;
                btn_salir.Enabled = true;
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
                if (TablaListaPrecios.Rows.Count > 0)
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

        private void data_TablaListaPrecios()
        {
            try
            {
                var BL = new tb_me_ListaPrecioBL();
                var BE = new tb_me_ListaPrecio();

                var dt = new DataTable();
                BE.moduloid = modulo;
                BE.listaprecid = Convert.ToInt32(listaprecid.Text.ToString());

                dt = BL.GetAll_datosdetalle(EmpresaID, BE).Tables[0];

                if (TablaListaPrecios != null)
                {
                    TablaListaPrecios.Clear();
                }

                foreach (DataRow fila in dt.Rows)
                {
                    row = TablaListaPrecios.NewRow();
                    row["item"] = fila["item"].ToString();
                    row["lineaid"] = fila["lineaid"].ToString().Trim();
                    row["grupoid"] = fila["grupoid"].ToString().Trim();
                    row["subgrupoid"] = fila["subgrupoid"].ToString().Trim();
                    row["lineaname"] = fila["lineaname"].ToString().Trim();
                    row["gruponame"] = fila["gruponame"].ToString().Trim();
                    row["subgrupoartic"] = fila["subgrupoartic"].ToString().Trim();
                    row["stock"] = Convert.ToDecimal(fila["stock"].ToString().Trim());
                    row["costoultimo"] = Convert.ToDecimal(fila["costoultimo"].ToString().Trim());
                    row["ultcompra"] = fila["ultcompra"].ToString().Trim();
                    row["ultventa"] = fila["ultventa"].ToString().Trim();
                    row["pventa1"] = Convert.ToDecimal(fila["precunit1"].ToString());
                    row["pventa2"] = Convert.ToDecimal(fila["precunit2"].ToString());
                    TablaListaPrecios.Rows.Add(row);
                }
                dgb_listaPrecios.DataSource = TablaListaPrecios;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridgrupo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void gridgrupo_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void gridgrupo_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgb_listaPrecios[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            dgb_listaPrecios[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            dgb_listaPrecios.EnableHeadersVisualStyles = false;
            dgb_listaPrecios.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            dgb_listaPrecios.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void gridgrupo_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void data_listaprec(String xlistaprecid)
        {
            form_bloqueado(false);
            var rowlistaprecid = TablaListaPrecios.Select("listaprecid='" + xlistaprecid + "'");
            if (rowlistaprecid.Length > 0)
            {
                foreach (DataRow row in rowlistaprecid)
                {
                    listaprecid.Text = row["listaprecid"].ToString().Trim();
                    listaprecname.Text = row["listaprecname"].ToString().Trim();
                }
                btn_nuevo.Enabled = true;
                btn_editar.Enabled = true;
                btn_eliminar.Enabled = true;
                btn_imprimir.Enabled = true;

                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;
                btn_salir.Enabled = true;
            }
        }

        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            data_TablaListaPrecios();
        }

        private void btn_CargarProductos_Click(object sender, EventArgs e)
        {
            var BL = new tb_me_productosBL();
            var BE = new tb_me_productos();

            BE.moduloid = modulo.ToString();
            BE.filtro = "3";

            TablaListaPrecios = BL.GetAll(EmpresaID, BE).Tables[0];

            if (TablaListaPrecios.Rows.Count > 0)
            {
                dgb_listaPrecios.DataSource = TablaListaPrecios;
                btn_exportar.Enabled = true;
                btn_CargarProductos.Enabled = false;
                btn_importar.Enabled = false;
                TablaListaPrecios.AcceptChanges();
                MessageBox.Show("Carga de Productos Completada...!!!");
            }
        }

        private void dgb_listaPrecios_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgb_listaPrecios.Columns[e.ColumnIndex].Name.ToUpper() == "pventa1".ToUpper())
            {
                Decimal pventa1 = 0, tipcamb = 0;
                pventa1 = Convert.ToDecimal(dgb_listaPrecios.Rows[dgb_listaPrecios.CurrentCell.RowIndex].Cells["pventa1"].Value);
                tipcamb = Convert.ToDecimal(tcamb.Text.Trim());
                dgb_listaPrecios.Rows[dgb_listaPrecios.CurrentCell.RowIndex].Cells["pventa2"].Value = Math.Round(pventa1 / tipcamb);
            }
        }

        private void btn_filtrar_Click(object sender, EventArgs e)
        {
            var BL = new tb_me_ListaPrecioBL();
            var BE = new tb_me_ListaPrecio();

            var dt = new DataTable();
            BE.moduloid = modulo.ToString();
            BE.listaprecid = Convert.ToInt32(listaprecid.Text.Trim() == string.Empty ? "0" : listaprecid.Text);
            BE.productname = _productname.Text.ToString();
            dt = BL.FiltroProducto(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                dgb_listaPrecios.DataSource = dt;
            }
        }

        private void btn_importar_Click(object sender, EventArgs e)
        {
            btn_CargarProductos.Enabled = false;

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
                    while (excelWorksheet.get_Range("A" + x).Value2 != null)
                    {
                        dgb_listaPrecios.Rows.Add(excelWorksheet.get_Range("A" + x).Value2.ToString(),
                                                  excelWorksheet.get_Range("B" + x).Value2.ToString(),
                                                  excelWorksheet.get_Range("C" + x).Value2.ToString(),
                                                  excelWorksheet.get_Range("D" + x).Value2.ToString(),
                                                  excelWorksheet.get_Range("E" + x).Value2.ToString(),
                                                  excelWorksheet.get_Range("F" + x).Value2.ToString(),
                                                  excelWorksheet.get_Range("G" + x).Text,
                                                  excelWorksheet.get_Range("H" + x).Value2.ToString(),
                                                  excelWorksheet.get_Range("I" + x).Value2.ToString("###,##0.00"),
                                                  excelWorksheet.get_Range("J" + x).Text,
                                                  excelWorksheet.get_Range("K" + x).Text,
                                                  excelWorksheet.get_Range("L" + x).Value2.ToString("###,##0.00"),
                                                  excelWorksheet.get_Range("M" + x).Value2.ToString("###,##0.00"));
                        x++;
                    }

                    excelApp.Quit();

                    CargarTablaLista();

                    MessageBox.Show("Importación Completada ...!!!");
                }
                catch (Exception sms)
                {
                    MessageBox.Show(sms.Message);
                }
            }
        }

        private void CargarTablaLista()
        {
            foreach (DataGridViewRow row in dgb_listaPrecios.Rows)
            {
                var rowdt = TablaListaPrecios.NewRow();
                rowdt["item"] = Convert.ToString(row.Cells["item"].Value);
                rowdt["lineaid"] = Convert.ToString(row.Cells["lineaid"].Value);
                rowdt["grupoid"] = Convert.ToString(row.Cells["grupoid"].Value);
                rowdt["subgrupoid"] = Convert.ToString(row.Cells["subgrupoid"].Value);
                rowdt["lineaname"] = Convert.ToString(row.Cells["lineaname"].Value);
                rowdt["gruponame"] = Convert.ToString(row.Cells["gruponame"].Value);
                rowdt["subgrupoartic"] = Convert.ToString(row.Cells["subgrupoartic"].Value);
                rowdt["stock"] = Convert.ToString(row.Cells["stock"].Value);
                rowdt["costoultimo"] = Convert.ToString(row.Cells["costoultimo"].Value);
                rowdt["ultcompra"] = Convert.ToString(row.Cells["ultcompra"].Value);
                rowdt["ultventa"] = Convert.ToString(row.Cells["ultventa"].Value);
                rowdt["pventa1"] = Convert.ToString(row.Cells["pventa1"].Value);
                rowdt["pventa2"] = Convert.ToString(row.Cells["pventa2"].Value);

                TablaListaPrecios.Rows.Add(rowdt);
            }
        }

        private void Carga1()
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btn_exportar_Click(object sender, EventArgs e)
        {
            if (TablaListaPrecios.Rows.Count > 0)
            {
                ExcelTOTAL();
            }
            else
            {
                MessageBox.Show("No Existe Datos...!!!");
                return;
            }
        }

        private  void ReporteExcel(DataGridView MiDataGrid)
        {
            var letras = new string[27];
            letras[0] = "A";
            letras[1] = "B";
            letras[2] = "C";
            letras[3] = "D";
            letras[4] = "E";
            letras[5] = "F";
            letras[6] = "G";
            letras[7] = "H";
            letras[8] = "I";
            letras[9] = "J";
            letras[10] = "K";
            letras[11] = "L";
            letras[12] = "L";
            letras[13] = "M";
            letras[14] = "N";
            letras[15] = "O";
            letras[16] = "P";
            letras[17] = "Q";
            letras[18] = "R";
            letras[19] = "S";
            letras[20] = "T";
            letras[21] = "U";
            letras[22] = "V";
            letras[23] = "W";
            letras[24] = "X";
            letras[25] = "Y";
            letras[26] = "Z";

            var ruta = Application.StartupPath + @"\MiReporte.xlsx";

            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            var excelBook = excelApp.Workbooks.Open(ruta, vk_update_links, vk_read_only, vk_format, vk_password,
            vk_write_res_password, vk_ignore_read_only_recommend, vk_origin,
            vk_delimiter, vk_editable, vk_notify, vk_converter, vk_add_to_mru,
            vk_local, vk_corrupt_load);
            var excelWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)excelBook.Worksheets.get_Item(1);

            for (var i = 0; i < MiDataGrid.ColumnCount; i++)
            {
                excelWorksheet.Cells[1, letras[i]] = MiDataGrid.Columns[i].HeaderText;
            }

            var fila = 1;
            for (var i = 0; i < MiDataGrid.Rows.Count; i++)
            {
                fila += 1;
                for (var j = 0; j < MiDataGrid.Columns.Count; j++)
                {
                    excelWorksheet.Cells[fila, letras[j]] = MiDataGrid.Rows[i].Cells[j].Value;
                }
            }
            excelApp.Visible = true;
        }

        private void _productname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_filtrar_Click(sender, e);
            }
        }

        private void listaprecid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                form_cargar_datos(string.Empty);
            }
        }

        private void export(DataGridView tabla)
        {
            var excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);

            var IndiceColumna = 0;
            foreach (DataGridViewColumn col in tabla.Columns)
            {
                IndiceColumna++;
                excel.Cells[1, IndiceColumna] = col.Name;
            }

            var IndiceFila = 0;

            foreach (DataGridViewRow row in tabla.Rows)
            {
                IndiceFila++;
                IndiceColumna = 0;
                foreach (DataGridViewColumn col in tabla.Columns)
                {
                    IndiceColumna++;
                    excel.Cells[IndiceFila + 1, IndiceColumna] = row.Cells[col.Name].Value;
                }
            }

            excel.Visible = true;
        }



        private void excel2()
        {
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;

            try
            {
                oXL = new Excel.Application();
                oXL.Visible = true;

                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                oSheet.Cells[1, 1] = "First Name";
                oSheet.Cells[1, 2] = "Last Name";
                oSheet.Cells[1, 3] = "Full Name";
                oSheet.Cells[1, 4] = "Salary";

                oSheet.get_Range("A1", "D1").Font.Bold = true;
                oSheet.get_Range("A1", "D1").VerticalAlignment =
                    Excel.XlVAlign.xlVAlignCenter;

                var saNames = new string[5, 2];

                saNames[0, 0] = "John";
                saNames[0, 1] = "Smith";
                saNames[1, 0] = "Tom";
                saNames[1, 1] = "Brown";
                saNames[2, 0] = "Sue";
                saNames[2, 1] = "Thomas";
                saNames[3, 0] = "Jane";
                saNames[3, 1] = "Jones";
                saNames[4, 0] = "Adam";
                saNames[4, 1] = "Johnson";

                oSheet.get_Range("A2", "B6").Value2 = saNames;

                oRng = oSheet.get_Range("C2", "C6");
                oRng.Formula = "=A2 & \" \" & B2";

                oRng = oSheet.get_Range("D2", "D6");
                oRng.Formula = "=RAND()*100000";
                oRng.NumberFormat = "$0.00";

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

        private void DisplayQuarterlySales(Excel._Worksheet oWS)
        {
            Excel._Workbook oWB;
            Excel.Series oSeries;
            Excel.Range oResizeRange;
            Excel._Chart oChart;
            String sMsg;
            int iNumQtrs;

            for (iNumQtrs = 4; iNumQtrs >= 2; iNumQtrs--)
            {
                sMsg = "Enter sales data for ";
                sMsg = String.Concat(sMsg, iNumQtrs);
                sMsg = String.Concat(sMsg, " quarter(s)?");

                var iRet = MessageBox.Show(sMsg, "Quarterly Sales?",
                    MessageBoxButtons.YesNo);
                if (iRet == DialogResult.Yes)
                {
                    break;
                }
            }

            sMsg = "Displaying data for ";
            sMsg = String.Concat(sMsg, iNumQtrs);
            sMsg = String.Concat(sMsg, " quarter(s).");

            MessageBox.Show(sMsg, "Quarterly Sales");

            oResizeRange = oWS.get_Range("E1", "E1").get_Resize(Missing.Value, iNumQtrs);
            oResizeRange.Formula = "=\"Q\" & COLUMN()-4 & CHAR(10) & \"Sales\"";

            oResizeRange.Orientation = 38;
            oResizeRange.WrapText = true;

            oResizeRange.Interior.ColorIndex = 36;

            oResizeRange = oWS.get_Range("E2", "E6").get_Resize(Missing.Value, iNumQtrs);
            oResizeRange.Formula = "=RAND()*100";
            oResizeRange.NumberFormat = "$0.00";

            oResizeRange = oWS.get_Range("E1", "E6").get_Resize(Missing.Value, iNumQtrs);
            oResizeRange.Borders.Weight = Excel.XlBorderWeight.xlThin;

            oResizeRange = oWS.get_Range("E8", "E8").get_Resize(Missing.Value, iNumQtrs);
            oResizeRange.Formula = "=SUM(E2:E6)";
            oResizeRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle
            = Excel.XlLineStyle.xlDouble;
            oResizeRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).Weight
            = Excel.XlBorderWeight.xlThick;

            oWB = (Excel._Workbook)oWS.Parent;
            oChart = (Excel._Chart)oWB.Charts.Add(Missing.Value, Missing.Value,
                Missing.Value, Missing.Value);

            oResizeRange = oWS.get_Range("E2:E6", Missing.Value).get_Resize(
                Missing.Value, iNumQtrs);
            oChart.ChartWizard(oResizeRange, Excel.XlChartType.xl3DColumn, Missing.Value,
                Excel.XlRowCol.xlColumns, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            oSeries = (Excel.Series)oChart.SeriesCollection(1);
            oSeries.XValues = oWS.get_Range("A2", "A6");
            for (var iRet = 1; iRet <= iNumQtrs; iRet++)
            {
                oSeries = (Excel.Series)oChart.SeriesCollection(iRet);
                String seriesName;
                seriesName = "=\"Q";
                seriesName = String.Concat(seriesName, iRet);
                seriesName = String.Concat(seriesName, "\"");
                oSeries.Name = seriesName;
            }

            oChart.Location(Excel.XlChartLocation.xlLocationAsObject, oWS.Name);

            oResizeRange = (Excel.Range)oWS.Rows.get_Item(10, Missing.Value);
            oWS.Shapes.Item("Chart 1").Top = (float)(double)oResizeRange.Top;
            oResizeRange = (Excel.Range)oWS.Columns.get_Item(2, Missing.Value);
            oWS.Shapes.Item("Chart 1").Left = (float)(double)oResizeRange.Left;
        }




        private void ExcelTOTAL()
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


                var IndiceColumna = 0;
                foreach (DataGridViewColumn col in dgb_listaPrecios.Columns)
                {
                    IndiceColumna++;
                    oSheet.Cells[1, IndiceColumna] = col.HeaderText;
                }

                oSheet.get_Range("A1", "M1").Font.Bold = true;
                oSheet.get_Range("A1", "M1").Font.Color = Color.White;
                oSheet.get_Range("A1", "M1").Interior.ColorIndex = 14;
                oSheet.get_Range("A1", "M1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                var IndiceFila = 0;

                oRng = oSheet.get_Range("A2", "D" + dgb_listaPrecios.Rows.Count + 1);
                oRng.NumberFormat = "@";

                foreach (DataGridViewRow row in dgb_listaPrecios.Rows)
                {
                    IndiceFila++;
                    IndiceColumna = 0;
                    foreach (DataGridViewColumn col in dgb_listaPrecios.Columns)
                    {
                        IndiceColumna++;
                        oSheet.Cells[IndiceFila + 1, IndiceColumna] = row.Cells[col.Name].Value;
                    }
                }

                oRng = oSheet.get_Range("L2", "M" + dgb_listaPrecios.Rows.Count + 1);
                oRng.NumberFormat = "###,##0.00";

                oRng = oSheet.get_Range("I2", "I" + dgb_listaPrecios.Rows.Count + 1);
                oRng.NumberFormat = "###,##0.00";


                oRng = oSheet.get_Range("J2", "K" + dgb_listaPrecios.Rows.Count + 1);
                oRng.NumberFormat = "dd/MM/yyyy";


                oRng = oSheet.get_Range("A1", "M1");
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
    }
}
