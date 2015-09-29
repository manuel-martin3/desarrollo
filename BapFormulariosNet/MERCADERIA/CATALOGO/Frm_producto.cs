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

using System.IO;

namespace BapFormulariosNet.MERCADERIA.CATALOGO
{
    public partial class Frm_producto : plantilla
    {
        private String EmpresaID = string.Empty;
        private String dominio = "60";
        private String dominioiddes = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable Tablaproducto;
        private String nom_producto = string.Empty;
        private String set_titulo = string.Empty;
        private String set_color = string.Empty;
        private String set_serie = string.Empty;
        private String set_compo = string.Empty;

        private Genericas fungen = new Genericas();
        private Byte[] vmContenidoFile;
        private string xtmpfile = VariablesPublicas.TmpFile("TMP");
        private Boolean procesado = false;
        private String subgrupoartic = string.Empty;
        private String _ctacte = string.Empty;
        private Boolean _nostock = false;
        private String _nombreFoto = string.Empty;
        private String ssModo = "NEW";

        public Frm_producto()
        {
            InitializeComponent();

            colorid.LostFocus += new System.EventHandler(colorid_LostFocus);
            titulo.TextChanged += new System.EventHandler(titulo_TextChanged);
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

        private void get_nuevo_producto()
        {
            var BL = new tb_me_productosBL();
            var BE = new tb_me_productos();
            var DT = new DataTable();
            BE.moduloid = cbo_moduloides.SelectedValue.ToString();
            BE.lineaid = lineaid.Text.Trim();
            BE.grupoid = grupoid.Text.Trim();
            BE.subgrupoid = subgrupoid.Text.Trim();
            DT = BL.GetAll_nuevocodprod(EmpresaID, BE).Tables[0];
            try
            {
                item.Text = DT.Rows[0]["item"].ToString().Substring(10, 3);
                productid.Text = lineaid.Text + grupoid.Text + subgrupoid.Text + item.Text;
            }
            catch (Exception ex)
            {
                item.Text = "000";
                productid.Text = lineaid.Text + grupoid.Text + subgrupoid.Text + item.Text;
            }

            if (productid.Text.Trim().Length == 13)
            {
                generar_denominacion();
                form_bloqueado(true);
                titulo.Focus();

                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
                btn_log.Enabled = true;
            }
        }


        private void generar_denominacion()
        {
            if (ssModo == "NEW")
            {
                if (modulo == "0330")
                {
                    productname.Text = subgruponame.Text.Trim() + " " + set_titulo.Trim() + " " + set_color.Trim();
                }
                else
                {
                    if (modulo == "0320")
                    {
                        productname.Text = lineaname.Text.Trim() + " " +
                                       subgrupoartic.ToString() + " " +
                                       set_titulo.Trim() + " " +
                                       set_color.Trim() + " " +
                                       gruponame.Text.ToString();
                    }
                    else
                    {
                        if (modulo == "0340" || modulo == "0350" || modulo == "0360" || modulo == "0370")
                        {
                            productname.Text = subgruponame.Text.ToString();
                        }
                        else
                        {
                            if (modulo == "0500")
                            {
                                productname.Text = subgruponame.Text.Trim() + " " + set_compo.ToString() + " " + set_serie.Trim();
                            }
                            else
                            {
                                if (modulo == "0100")
                                {
                                    productname.Text = subgruponame.Text.Trim() + " " + set_serie.Trim();
                                }
                            }
                        }
                    }
                }
            }
        }


        private void form_bloqueado(Boolean var)
        {
            try
            {
                fechadoc.Enabled = false;

                moduloiddes.Enabled = false;
                localdes.Enabled = false;

                cbo_moduloides.Enabled = false;
                cbo_localdes.Enabled = false;

                lineaid.Enabled = false;
                lineaname.Enabled = false;
                grupoid.Enabled = false;
                gruponame.Enabled = false;
                subgrupoid.Enabled = !var;
                subgruponame.Enabled = false;

                item.Enabled = false;
                productid.Enabled = false;
                nserie.Enabled = var;
                productname.Enabled = false;
                productidold.Enabled = false;
                titulo.Enabled = var;
                compo.Enabled = var;
                colorid.Enabled = var;
                procedenciaid.Enabled = false;
                estado.Enabled = var;
                colorname.Enabled = false;
                unmed.Enabled = var;
                unmedenvase.Enabled = var;
                unidenvase.Enabled = var;

                btn_nuevo.Enabled = false;
                btn_editar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_grabar.Enabled = false;
                btn_eliminar.Enabled = false;
                btn_imprimir.Enabled = false;

                btn_actualizar.Enabled = var;

                btn_primero.Enabled = false;
                btn_anterior.Enabled = false;
                btn_siguiente.Enabled = false;
                btn_ultimo.Enabled = false;

                btn_log.Enabled = false;
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

                subgrupoid.Enabled = false;
                productid.Enabled = true;

                btn_nuevo.Enabled = true;

                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;
                btn_salir.Enabled = true;

                ssModo = "NEW";
            }
        }

        private void form_cargar_datos(String posicion)
        {
            try
            {
                var BL = new tb_me_productosBL();
                var BE = new tb_me_productos();
                var dt = new DataTable();

                BE.moduloid = moduloiddes.SelectedValue.ToString();
                if (productid.Text.Trim().Length > 0)
                {
                    BE.productid = productid.Text.Trim();
                }
                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    limpiar_documento();
                    ssModo = "EDIT";

                    lineaid.Text = dt.Rows[0]["lineaid"].ToString().Trim();
                    lineaname.Text = dt.Rows[0]["lineaname"].ToString().Trim();
                    grupoid.Text = dt.Rows[0]["grupoid"].ToString().Trim();
                    gruponame.Text = dt.Rows[0]["gruponame"].ToString().Trim();
                    subgrupoid.Text = dt.Rows[0]["subgrupoid"].ToString().Trim();
                    subgruponame.Text = dt.Rows[0]["subgruponame"].ToString().Trim();
                    item.Text = dt.Rows[0]["item"].ToString().Trim();
                    productid.Text = dt.Rows[0]["productid"].ToString().Trim();
                    productname.Text = dt.Rows[0]["productname"].ToString().Trim();

                    nom_producto = dt.Rows[0]["productname"].ToString().Trim();

                    productidold.Text = dt.Rows[0]["productidold"].ToString().Trim();
                    titulo.Text = dt.Rows[0]["titulo"].ToString().Trim();
                    compo.Text = dt.Rows[0]["compo"].ToString().Trim();
                    colorid.Text = dt.Rows[0]["colorid"].ToString().Trim();
                    colorname.Text = dt.Rows[0]["colorname"].ToString().Trim();

                    procedenciaid.SelectedIndex = Convert.ToInt32(dt.Rows[0]["paisid"]);
                    txt_paisname.Text = dt.Rows[0]["paisname"].ToString().Trim();
                    nserie.Text = dt.Rows[0]["nserie"].ToString().Trim();

                    estado.SelectedIndex = Convert.ToInt32(dt.Rows[0]["status"]);

                    if (dt.Rows[0]["unmed"].ToString().Trim().Length > 0)
                    {
                        unmed.SelectedValue = dt.Rows[0]["unmed"].ToString().Trim();
                    }
                    if (dt.Rows[0]["unmedenvase"].ToString().Trim().Length > 0)
                    {
                        unmedenvase.SelectedValue = dt.Rows[0]["unmedenvase"].ToString().Trim();
                    }
                    else
                    {
                        unmedenvase.SelectedIndex = -1;
                    }
                    unidenvase.Text = dt.Rows[0]["unidenvase"].ToString().Trim();
                    _nombreFoto = dt.Rows[0]["docname"].ToString().ToString();

                    dt.Rows[0]["foto"].ToString();

                    if (dt.Rows[0]["foto"].ToString() != string.Empty)
                    {
                        var MyData1 = (byte[])null;
                        MyData1 = (byte[])(dt.Rows[0]["foto"]);

                        if (MyData1 != null && MyData1.Length != 0)
                        {
                            vmContenidoFile = MyData1;
                            go_foto.Visible = true;
                            go_foto.Image = null;
                            var ms = new System.IO.MemoryStream();
                            ms.Write(MyData1, 0, MyData1.Length);
                            go_foto.Image = Image.FromStream(ms);
                        }
                        else
                        {
                            go_foto.Visible = false;
                            go_foto.ImageLocation = string.Empty;
                        }
                    }
                    else
                    {
                        go_foto.Visible = false;
                        go_foto.ImageLocation = string.Empty;
                    }

                    subgrupoid.Enabled = false;
                    productid.Enabled = true;

                    btn_editar.Enabled = true;
                    btn_eliminar.Enabled = true;
                    btn_imprimir.Enabled = true;

                    btn_primero.Enabled = true;
                    btn_anterior.Enabled = true;
                    btn_siguiente.Enabled = true;
                    btn_ultimo.Enabled = true;

                    btn_log.Enabled = true;
                    btn_salir.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void data_cbo_unmed()
        {
            try
            {
                var BL = new tb_co_tabla06_unidadmedidaBL();
                var BE = new tb_co_tabla06_unidadmedida();
                var dt = new DataTable();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                unmed.DataSource = dt;
                unmed.ValueMember = "sigla";
                unmed.DisplayMember = "descripcion";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void data_cbo_unmedenvase()
        {
            try
            {
                var BL = new tb_co_tabla06_unidadmedidaBL();
                var BE = new tb_co_tabla06_unidadmedida();
                var dt = new DataTable();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                unmedenvase.DataSource = dt;
                unmedenvase.ValueMember = "sigla";
                unmedenvase.DisplayMember = "descripcion";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidaSubgrupo()
        {
            if (subgrupoid.Text.Trim().Length > 0 && lineaid.Text.Trim().Length == 3 && grupoid.Text.Trim().Length == 4)
            {
                var BL = new tb_me_subgrupoBL();
                var BE = new tb_me_subgrupo();
                var dt = new DataTable();

                BE.moduloid = modulo;
                BE.lineaid = lineaid.Text.Trim().PadLeft(3, '0');
                BE.grupoid = grupoid.Text.Trim().PadLeft(4, '0');
                BE.subgrupoid = subgrupoid.Text.Trim().PadLeft(3, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    lineaid.Text = dt.Rows[0]["lineaid"].ToString().Trim();
                    lineaname.Text = dt.Rows[0]["lineaname"].ToString().Trim();
                    grupoid.Text = dt.Rows[0]["grupoid"].ToString().Trim();
                    gruponame.Text = dt.Rows[0]["gruponame"].ToString().Trim();
                    subgrupoid.Text = dt.Rows[0]["subgrupoid"].ToString().Trim();
                    subgruponame.Text = dt.Rows[0]["subgruponame"].ToString().Trim();
                    subgrupoartic = dt.Rows[0]["subgrupoartic"].ToString().Trim();
                }
                else
                {
                    lineaid.Text = string.Empty;
                    lineaname.Text = string.Empty;
                    grupoid.Text = string.Empty;
                    gruponame.Text = string.Empty;
                    subgrupoid.Text = string.Empty;
                    subgruponame.Text = string.Empty;
                }
            }
            else
            {
                lineaid.Text = string.Empty;
                lineaname.Text = string.Empty;
                grupoid.Text = string.Empty;
                gruponame.Text = string.Empty;
                subgrupoid.Text = string.Empty;
                subgruponame.Text = string.Empty;
            }
        }

        private void ValidaColor()
        {
            if (colorid.Text.Trim().Length > 0)
            {
                var BL = new tb_me_colorBL();
                var BE = new tb_me_color();
                var dt = new DataTable();

                BE.moduloid = modulo;
                BE.colorid = colorid.Text.Trim().PadLeft(3, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    colorid.Text = dt.Rows[0]["colorid"].ToString().Trim();
                    colorname.Text = dt.Rows[0]["colorname"].ToString().Trim();
                    generar_denominacion();
                }
                else
                {
                    colorid.Text = string.Empty;
                    colorname.Text = string.Empty;
                    generar_denominacion();
                }
            }
            else
            {
                colorid.Text = string.Empty;
                colorname.Text = string.Empty;
                generar_denominacion();
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

        private void Ayudasubgrupo(String lpdescrlike)
        {
            try
            {
                var modd = string.Empty;
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();

                BE.dominioid = dominio;
                BE.moduloid = moduloiddes.SelectedValue.ToString();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    var frmayuda = new Ayudas.Frm_help_array();

                    frmayuda.tipoo = "sql";
                    frmayuda.titulo = "<< AYUDA TABLA ARTICULO >>";
                    frmayuda.sqlquery = "SELECT " +
                                            "(S.lineaid + S.grupoid + S.subgrupoid) as Codigo " +
                                            ",S.lineaid " +
                                            ",S.grupoid " +
                                            ",G.gruponame " +
                                            ",S.subgrupoid " +
                                            ",S.subgruponame " +
                                            ",G.ctacte " +
                                            ",L.nostock " +
                                            "FROM tb_me_subgrupo S " +
                                            "INNER JOIN tb_me_linea L on S.lineaid = L.lineaid AND  S.moduloid = L.moduloid ";
                    if (modd == "sm")
                    {
                        frmayuda.sqlinner = " INNER JOIN tb_me_grupo G on S.grupoid = G.grupoid and status = '0' ";
                    }
                    else
                    {
                        frmayuda.sqlinner = " INNER JOIN tb_me_grupo G on S.grupoid = G.grupoid AND S.moduloid = G.moduloid";
                    }

                    if (lineaid.Text.Trim().Length > 0 && grupoid.Text.Trim().Length > 0)
                    {
                        frmayuda.sqlwhere = "where S.moduloid=" + moduloiddes.SelectedValue.ToString() + " and S.lineaid = " + lineaid.Text + " and S.grupoid = " + grupoid.Text + " ";
                        frmayuda.sqland = "and ";
                    }
                    else
                    {
                        if (lineaid.Text.Trim().Length > 0)
                        {
                            frmayuda.sqlwhere = "where S.moduloid=" + moduloiddes.SelectedValue.ToString() + " and S.lineaid = " + lineaid.Text + " ";
                            frmayuda.sqland = "and ";
                        }
                        else
                        {
                            if (grupoid.Text.Trim().Length > 0)
                            {
                                frmayuda.sqlwhere = "where S.moduloid=" + moduloiddes.SelectedValue.ToString() + " and S.grupoid = " + grupoid.Text + " ";
                                frmayuda.sqland = "and ";
                            }
                            else
                            {
                                frmayuda.sqlwhere = "where S.moduloid=" + moduloiddes.SelectedValue.ToString();
                                frmayuda.sqland = "and ";
                            }
                        }
                    }
                    frmayuda.criteriosbusqueda = new string[] { "ARTICULO", "CODIGO" };
                    frmayuda.columbusqueda = "S.subgruponame,S.lineaid + S.grupoid + S.subgrupoid";
                    frmayuda.returndatos = "1,2,4,6";
                    frmayuda.resulcolumnas = 8;
                    frmayuda.Owner = this;
                    frmayuda.PasaProveedor = RecibeSubgrupo;
                    frmayuda.ShowDialog();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void RecibeSubgrupo(String[] resultados)
        {
            if (resultados[0].Trim().Length > 0)
            {
                lineaid.Text = resultados[1];
                grupoid.Text = resultados[2];
                subgrupoid.Text = resultados[4];

                _ctacte = resultados[6];
                _nostock = Convert.ToBoolean(resultados[7] ?? "false");
            }
        }


        private void AyudaProducto(String lpdescrlike)
        {
            try
            {
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();

                BE.dominioid = dominio.Trim();

                if (moduloiddes.SelectedIndex != -1)
                {
                    BE.moduloid = moduloiddes.SelectedValue.ToString();
                }
                else
                {
                    MessageBox.Show("!!! ...Seleccione el Módulo ... !!!", "Información");
                    return;
                }

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    var frmayuda = new Ayudas.Frm_help_array();
                    frmayuda.nameform = "Productos";
                    frmayuda.tipoo = "sql";
                    frmayuda.titulo = "<< AYUDA  TABLA PRODUCTOS >>";
                    frmayuda.sqlquery = "SELECT " +
                                            " TOP 100 tb1.productid " +
                                            ",tb1.productname " +
                                            ",tb2.lineaname " +
                                            ",tb3.gruponame " +
                                            ",tb1.productidold  " +
                                            " FROM tb_me_productos AS tb1 ";
                    frmayuda.sqlinner = " INNER JOIN tb_me_linea as tb2 on tb1.lineaid = tb2.lineaid AND tb2.moduloid = tb1.moduloid " +
                                            " INNER JOIN tb_me_grupo as tb3 on tb1.grupoid = tb3.grupoid AND tb3.moduloid = tb1.moduloid ";
                    frmayuda.sqlwhere = " WHERE tb1.status = '0' and tb1.moduloid = " + moduloiddes.SelectedValue.ToString();
                    frmayuda.sqland = " AND ";
                    frmayuda.criteriosbusqueda = new string[] { "PRODUCTO", "CODIGO", "LINEA", "GRUPO" };
                    frmayuda.columbusqueda = "tb1.productname,tb1.productid,tb2.lineaname,tb3.gruponame";
                    frmayuda.returndatos = "0,1";
                    frmayuda.resulcolumnas = 5;
                    frmayuda.Owner = this;
                    frmayuda.PasaProveedor = RecibeProducto;
                    frmayuda.ShowDialog();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void RecibeProducto(String[] resultados)
        {
            if (resultados[0].Trim().Length == 13)
            {
                productid.Text = resultados[0];
            }
        }

        private void AyudaColor(String lpdescrlike)
        {
            try
            {
                var modd = string.Empty;
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();

                BE.dominioid = dominio;
                BE.moduloid = moduloiddes.SelectedValue.ToString();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    modd = dt.Rows[0]["moduloshort"].ToString().Trim();
                    var frmayuda = new Ayudas.Frm_help_array();

                    frmayuda.tipoo = "sql";
                    frmayuda.titulo = "Ayuda Color";
                    frmayuda.sqlquery = " SELECT colorid, colorname from tb_me_color";
                    frmayuda.sqlinner = string.Empty;
                    frmayuda.sqlwhere = "WHERE moduloid = " + moduloiddes.SelectedValue.ToString();
                    frmayuda.sqland = string.Empty;
                    frmayuda.criteriosbusqueda = new string[] { "COLOR", "CÓDIGO" };
                    frmayuda.columbusqueda = "colorname,colorid";
                    frmayuda.returndatos = "0,1";
                    frmayuda.resulcolumnas = 2;

                    frmayuda.Owner = this;
                    frmayuda.PasaProveedor = RecibeColor;
                    frmayuda.ShowDialog();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void RecibeColor(String[] resultados)
        {
            if (resultados[0].Trim().Length > 0)
            {
                colorid.Text = resultados[0];
                colorname.Text = resultados[1];
            }
        }

        private void SEGURIDAD_LOG(String accion)
        {
            var xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio + "/" + productid.Text.Trim();
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
                BE.detalle = productid.Text.Trim() + "/" + productname.Text.Trim().ToUpper() + "/" + XGLOSA;

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
                fechadoc.Value = DateTime.Today;
                moduloiddes.SelectedValue = modulo.ToString();
                localdes.SelectedValue = local.ToString();

                cbo_moduloides.SelectedValue = modulo.ToString();
                cbo_localdes.SelectedValue = local.ToString();

                subgrupoartic = string.Empty;
                lineaid.Text = string.Empty;
                lineaname.Text = string.Empty;
                grupoid.Text = string.Empty;
                gruponame.Text = string.Empty;
                subgrupoid.Text = string.Empty;
                subgruponame.Text = string.Empty;
                nserie.Text = string.Empty;
                item.Text = string.Empty;
                productid.Text = string.Empty;
                productname.Text = string.Empty;
                productidold.Text = string.Empty;
                compo.Text = string.Empty;
                colorid.Text = string.Empty;
                colorname.Text = string.Empty;
                titulo.Text = string.Empty;
                unmed.SelectedValue = "UND";
                unidenvase.Text = "1";
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
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_log.Enabled = true;
            subgrupoid.Focus();
        }

        private void Insert()
        {
            try
            {
                if (productid.Text.Trim().Length != 13)
                {
                    MessageBox.Show("Código de producto invalido !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (productname.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese nombre de producto !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (unmed.SelectedIndex == -1)
                        {
                            MessageBox.Show("Seleccione la unidad de medida !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            if (unmedenvase.SelectedIndex == -1)
                            {
                                MessageBox.Show("Seleccione la unidad de medida !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                if (unidenvase.Text == string.Empty)
                                {
                                    MessageBox.Show("Ingrese Equivalente !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                else
                                {
                                    var BL = new tb_me_productosBL();
                                    var BE = new tb_me_productos();

                                    BE.moduloid = moduloiddes.SelectedValue.ToString();
                                    if (moduloiddes.SelectedValue.ToString() == "0000")
                                    {
                                        MessageBox.Show("Seleccione Almacen", "Information");
                                        return;
                                    }
                                    BE.lineaid = lineaid.Text.Trim();
                                    BE.grupoid = grupoid.Text.Trim();
                                    BE.subgrupoid = subgrupoid.Text.Trim();
                                    BE.item = item.Text.Trim();
                                    BE.productid = productid.Text.Trim();
                                    BE.productname = productname.Text.Trim().ToUpper();
                                    BE.productidold = "0";
                                    BE.titulo = titulo.Text.Trim().ToUpper();
                                    BE.compo = compo.Text.Trim().ToUpper();
                                    BE.colorid = colorid.Text.Trim();
                                    BE.colorname = colorname.Text.Trim().ToUpper();
                                    if (unmed.SelectedValue != null)
                                    {
                                        BE.unmed = unmed.SelectedValue.ToString();
                                    }
                                    if (unmedenvase.SelectedValue != null)
                                    {
                                        BE.unmedenvase = unmedenvase.SelectedValue.ToString();
                                    }
                                    else
                                    {
                                        unmedenvase.Text = string.Empty;
                                    }
                                    BE.procedenciaid = procedenciaid.SelectedIndex.ToString();

                                    BE.unidenvase = Convert.ToDecimal(unidenvase.Text.Trim());
                                    BE.status = estado.SelectedIndex.ToString();
                                    BE.usuar = VariablesPublicas.Usuar.Trim();

                                    BE.nserie = nserie.Text.ToString();
                                    var ms = new System.IO.MemoryStream();
                                    if (modulo == "0500")
                                    {
                                        if (go_foto.Image != null)
                                        {
                                            go_foto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                        }
                                    }
                                    BE.Foto = ms.GetBuffer();

                                    if (BL.Insert(EmpresaID, BE))
                                    {
                                        MessageBox.Show("Datos Grabados Correctamente !!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        procesado = true;
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


        private void Insert_Foto()
        {
            try
            {
                var BL = new tb_me_productosBL();
                var BE = new tb_me_productos();

                BE.moduloid = moduloiddes.SelectedValue.ToString();
                if (moduloiddes.SelectedValue.ToString() == "0000")
                {
                    MessageBox.Show("Seleccione Almacen", "Information");
                    return;
                }
                BE.local = localdes.SelectedValue.ToString();
                BE.productid = productid.Text.Trim();
                BE.docname = _nombreFoto.ToString();
                var ms = new System.IO.MemoryStream();
                if (modulo == "0500")
                {
                    if (go_foto.Image != null)
                    {
                        go_foto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
                BE.Foto = ms.GetBuffer();
                BL.Insert_Foto(EmpresaID, BE);
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void Update()
        {
            try
            {
                if (productid.Text.Trim().Length != 13)
                {
                    MessageBox.Show("Código de producto invalido !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (productname.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese nombre de producto !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (unmed.SelectedIndex == -1)
                        {
                            MessageBox.Show("Seleccione la unidad de medida !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            if (unmedenvase.SelectedIndex == -1)
                            {
                                MessageBox.Show("Seleccione la unidad de medida !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                if (unidenvase.Text == string.Empty)
                                {
                                    MessageBox.Show("Ingrese Equivalente !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                else
                                {
                                    var BL = new tb_me_productosBL();
                                    var BE = new tb_me_productos();

                                    BE.moduloid = moduloiddes.SelectedValue.ToString();
                                    if (moduloiddes.SelectedValue.ToString() == "0000")
                                    {
                                        MessageBox.Show("Seleccione Almacen", "Information");
                                        return;
                                    }
                                    BE.lineaid = lineaid.Text.Trim();
                                    BE.grupoid = grupoid.Text.Trim();
                                    BE.subgrupoid = subgrupoid.Text.Trim();
                                    BE.item = item.Text.Trim();
                                    BE.productid = productid.Text.Trim();
                                    BE.productname = productname.Text.Trim().ToUpper();
                                    BE.productidold = productidold.Text.Trim().ToUpper();
                                    BE.titulo = titulo.Text.Trim().ToUpper();
                                    BE.compo = compo.Text.Trim().ToUpper();
                                    BE.colorid = colorid.Text.Trim();
                                    BE.colorname = colorname.Text.Trim().ToUpper();

                                    if (unmed.SelectedValue != null)
                                    {
                                        BE.unmed = unmed.SelectedValue.ToString();
                                    }
                                    if (unmedenvase.SelectedValue != null)
                                    {
                                        BE.unmedenvase = unmedenvase.SelectedValue.ToString();
                                    }
                                    BE.procedenciaid = procedenciaid.SelectedIndex.ToString();
                                    BE.unidenvase = Convert.ToDecimal(unidenvase.Text.Trim());
                                    BE.status = estado.SelectedIndex.ToString();
                                    BE.usuar = VariablesPublicas.Usuar.Trim();
                                    BE.nserie = nserie.Text.ToString();
                                    var ms = new System.IO.MemoryStream();

                                    if (modulo == "0500")
                                    {
                                        if (go_foto.Image != null)
                                        {
                                            go_foto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                        }
                                    }

                                    BE.Foto = ms.GetBuffer();

                                    if (BL.Update(EmpresaID, BE))
                                    {
                                        SEGURIDAD_LOG("M");
                                        MessageBox.Show("Datos Modificado Correctamente !!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        procesado = true;
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

        private void Update_Foto()
        {
            try
            {
                var BL = new tb_me_productosBL();
                var BE = new tb_me_productos();

                BE.moduloid = moduloiddes.SelectedValue.ToString();
                if (moduloiddes.SelectedValue.ToString() == "0000")
                {
                    MessageBox.Show("Seleccione Almacen", "Information");
                    return;
                }
                BE.local = localdes.SelectedValue.ToString();
                BE.productid = productid.Text.Trim();
                BE.docname = _nombreFoto.ToString();

                var ms = new System.IO.MemoryStream();
                if (modulo == "0500")
                {
                    if (go_foto.Image != null)
                    {
                        go_foto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
                BE.Foto = ms.GetBuffer();
                BL.Update_Foto(EmpresaID, BE);
            }
            catch (Exception)
            {
                throw;
            }
        }



        private void Delete()
        {
            try
            {
                if (productid.Text.Trim().Length != 13)
                {
                    MessageBox.Show("Código de producto invalido !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_me_productosBL();
                    var BE = new tb_me_productos();

                    BE.moduloid = moduloiddes.SelectedValue.ToString();
                    if (moduloiddes.SelectedValue.ToString() == "0000")
                    {
                        MessageBox.Show("Seleccione Almacen", "Information");
                        return;
                    }
                    BE.productid = productid.Text.Trim();
                    BE.status = "9";
                    BE.usuar = VariablesPublicas.Usuar.Trim();

                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos Eliminados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        limpiar_documento();
                        form_bloqueado(false);

                        subgrupoid.Enabled = false;
                        productid.Enabled = true;
                        btn_nuevo.Enabled = true;

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

        private void Frm_productos_Load(object sender, EventArgs e)
        {
            EmpresaID = VariablesPublicas.EmpresaID;
            switch (Parent.Parent.Name)
            {
                case "MainAlmacen":
                    modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
                    local = ((D60ALMACEN.MainAlmacen)MdiParent).local;
                    PERFILID = ((D60ALMACEN.MainAlmacen)MdiParent).perfil;
                    break;
                case "MainMercaderia":
                    modulo = ((MERCADERIA.MainMercaderia)MdiParent).moduloid;
                    local = ((MERCADERIA.MainMercaderia)MdiParent).local;
                    PERFILID = ((MERCADERIA.MainMercaderia)MdiParent).perfil;
                    break;
                default:
                    break;
            }


            CargarCombo_Modulo();
            CargarCombo_Modulo2();
            NIVEL_FORMS();

            Tablaproducto = new DataTable();
            productname.CharacterCasing = CharacterCasing.Upper;
            data_cbo_unmed();
            data_cbo_unmedenvase();
            limpiar_documento();
            form_bloqueado(false);

            subgrupoid.Enabled = false;
            productid.Enabled = true;

            btn_nuevo.Enabled = true;
            btn_primero.Enabled = true;
            btn_anterior.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_ultimo.Enabled = true;
            btn_salir.Enabled = true;

            procedenciaid.Items.Clear();
            procedenciaid.Items.AddRange("Nacional,Importado".Split(new char[] { ',' }));
            procedenciaid.SelectedIndex = 0;

            estado.Items.Clear();
            estado.Items.AddRange("Operativo,Malogrado,Baja".Split(new char[] { ',' }));
            estado.SelectedIndex = 0;
        }



        private void CargarCombo_Modulo()
        {
            var BL = new sys_moduloBL();
            var BE = new tb_sys_modulo();
            var dt = new DataTable();
            BE.dominioid = dominioiddes.Trim();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                moduloiddes.DataSource = dt;
                moduloiddes.ValueMember = "moduloid";
                moduloiddes.DisplayMember = "moduloname";
            }
        }


        private void get_dominio_modulo_local(string dominioid, string moduloid)
        {
            if (moduloid.ToString().Length == 4)
            {
                var BL = new usuariomodulolocalBL();
                var BE = new tb_usuariomodulolocal();
                var dt = new DataTable();
                BE.usuar = VariablesPublicas.Usuar.Trim();
                BE.dominioid = dominioid;
                BE.moduloid = moduloid;

                dt = BL.GetAll3(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    localdes.DataSource = dt;
                    localdes.ValueMember = "local";
                    localdes.DisplayMember = "localname";
                }
            }
        }



        private void CargarCombo_Modulo2()
        {
            var BL = new sys_moduloBL();
            var BE = new tb_sys_modulo();
            var dt = new DataTable();
            BE.dominioid = dominioiddes.Trim();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cbo_moduloides.DataSource = dt;
                cbo_moduloides.ValueMember = "moduloid";
                cbo_moduloides.DisplayMember = "moduloname";
            }
        }


        private void get_dominio_modulo_local2(string dominioid, string moduloid)
        {
            if (moduloid.ToString().Length == 4)
            {
                var BL = new usuariomodulolocalBL();
                var BE = new tb_usuariomodulolocal();
                var dt = new DataTable();
                BE.usuar = VariablesPublicas.Usuar.Trim();
                BE.dominioid = dominioid;
                BE.moduloid = moduloid;

                dt = BL.GetAll3(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    cbo_localdes.DataSource = dt;
                    cbo_localdes.ValueMember = "local";
                    cbo_localdes.DisplayMember = "localname";
                }
            }
        }





        private void Frm_productos_KeyDown(object sender, KeyEventArgs e)
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

        private void subgrupoid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Ayudasubgrupo(string.Empty);
            }

            ValidaSubgrupo();
            get_nuevo_producto();
            ValidamosProcedencia();
        }



        private void GeneraCodAsoc()
        {
        }


        private void ValidamosProcedencia()
        {
            var BL = new clienteBL();
            var BE = new tb_cliente();

            var dt = new DataTable();
            BE.ctacte = _ctacte.ToString();
            BE.filtro = "2";
            dt = BL.GetAll(EmpresaID, BE).Tables[0];

            if (dt.Rows.Count > 0)
            {
                if (modulo.ToString() != "0500")
                {
                    dt.Rows[0]["ctacte"].ToString().Trim();
                    dt.Rows[0]["ctactename"].ToString().Trim();
                    var set_paisname = dt.Rows[0]["paisname"].ToString().Trim();
                    var set_paisid = dt.Rows[0]["paisid"].ToString().Trim();

                    if (set_paisid == "9589")
                    {
                        procedenciaid.SelectedIndex = 0;
                        txt_paisname.Text = set_paisname.ToString();
                    }
                    else
                    {
                        procedenciaid.SelectedIndex = 1;
                        txt_paisname.Text = set_paisname.ToString();
                    }
                }
                else
                {
                    procedenciaid.SelectedIndex = 0;
                    txt_paisname.Text = "PERÚ";
                }
            }
            else
            {
            }
        }

        private void productid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaProducto(string.Empty);
            }

            if (e.KeyCode == Keys.Enter)
            {
                form_cargar_datos(string.Empty);
            }
        }

        private void productid_KeyUp(object sender, KeyEventArgs e)
        {
            if (productid.Text.Trim().Length == 13)
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    return;
                }
                else
                {
                    form_cargar_datos(string.Empty);
                }
            }
        }

        private void titulo_TextChanged(object sender, EventArgs e)
        {
            if (modulo == "0320")
            {
                if (ssModo == "NEW")
                {
                    if (titulo.Text == string.Empty)
                    {
                        set_titulo = string.Empty;
                        generar_denominacion();
                    }
                    else
                    {
                        set_titulo = titulo.Text;
                        generar_denominacion();
                    }
                }
            }
        }

        private void colorid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaColor(string.Empty);

                if (modulo == "0320" || modulo == "0330" )
                {
                    if (ssModo == "NEW")
                    {
                        set_color = " C/ " + colorname.Text.ToString();
                        generar_denominacion();
                    }
                }
                compo.Focus();
            }


            if (e.KeyCode == Keys.Enter)
            {
                compo.Focus();
            }
        }

        private void colorid_LostFocus(object sender, System.EventArgs e)
        {
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
            {
                nuevo();
                pnl_busqueda.Enabled = false;
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0")
            {
                ssModo = "EDIT";
                form_bloqueado(true);
                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
                pnl_busqueda.Enabled = false;
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            form_accion_cancelEdicion(1);
            pnl_busqueda.Enabled = true;
        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {
            procesado = false;
            var sw_prosigue = false;
            if (ssModo == "NEW")
            {
                if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
                {
                    if (modulo == "0320")
                    {
                        if (titulo.Text == string.Empty)
                        {
                            MessageBox.Show("Ingrese Titulo / Onz !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (compo.Text == string.Empty)
                        {
                            MessageBox.Show("Ingrese Composición !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        Insert();
                    }
                    else
                    {
                        Insert();
                        Insert_Foto();
                    }
                }
            }
            else
            {
                if (XNIVEL == "0" || XNIVEL == "1")
                {
                    sw_prosigue = (MessageBox.Show("¿Desea Modificar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                    if (sw_prosigue)
                    {
                        if (modulo == "0320")
                        {
                            if (titulo.Text == string.Empty)
                            {
                                MessageBox.Show("Ingrese Titulo / Onz !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if (compo.Text == string.Empty)
                            {
                                MessageBox.Show("Ingrese Composición !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            Update();
                        }
                        else
                        {
                            Update();
                            Update_Foto();
                        }
                    }
                }
            }
            if (procesado)
            {
                NIVEL_FORMS();
                form_bloqueado(false);

                subgrupoid.Enabled = false;
                productid.Enabled = true;

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
                var miForma = new REPORTES.Frm_reportes();

                miForma.dominioid = dominio.Trim();
                miForma.moduloid = modulo.Trim();
                miForma.local = local.Trim();

                miForma.Text = "Reporte de Productos";
                miForma.formulario = "Frm_producto";
                miForma.ShowDialog();
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

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            AyudaProducto(string.Empty);
        }

        private void btn_ultimo_Click(object sender, EventArgs e)
        {
            form_cargar_datos(Genericas.ultimo);
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
            var oform = new Seguridadlog.FrmSeguridad();
            var xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio + "/" + productid.Text.Trim();
            oform._Nombre = Name;
            oform._ClaveForm = xclave;
            oform.Owner = this;
            oform.ShowDialog();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void productname_TextChanged(object sender, EventArgs e)
        {
        }

        private void unmed_SelectedIndexChanged(object sender, EventArgs e)
        {
            var BL = new tb_co_tabla06_unidadmedidaBL();
            var BE = new tb_co_tabla06_unidadmedida();
            var dt = new DataTable();
            var xcodigoid1 = string.Empty;
            var xcodigoid2 = string.Empty;
            Decimal equiv = 0;

            BE.sigla = unmed.SelectedValue.ToString();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];

            if (dt.Rows.Count > 0)
            {
                xcodigoid1 = dt.Rows[0]["codigoid"].ToString();

                var BL2 = new tb_co_tabla06_unidadmedidaBL();
                var BE2 = new tb_co_tabla06_unidadmedida();
                var dt2 = new DataTable();

                if (unmedenvase.Text != string.Empty)
                {
                    BE2.sigla = unmedenvase.SelectedValue.ToString();
                    dt2 = BL2.GetAll(EmpresaID, BE2).Tables[0];

                    if (dt2.Rows.Count > 0)
                    {
                        xcodigoid2 = dt2.Rows[0]["codigoid"].ToString();

                        var BE3 = new tb_cm_ordendecompra();
                        var BL3 = new tb_cm_ordendecompraBL();
                        var dt3 = new DataTable();

                        BE3.Unmed1 = xcodigoid1;
                        BE3.Unmed2 = xcodigoid2;
                        dt3 = BL3.GetAll(EmpresaID, BE3).Tables[0];

                        if (dt3.Rows.Count > 0)
                        {
                            equiv = Convert.ToDecimal(dt3.Rows[0]["equivalencia"].ToString());
                            unidenvase.Text = Convert.ToString(equiv);
                        }
                        else
                        {
                            unidenvase.Text = string.Empty;
                        }
                    }
                }
            }
        }

        private void unmedenvase_SelectedIndexChanged(object sender, EventArgs e)
        {
            var BL = new tb_co_tabla06_unidadmedidaBL();
            var BE = new tb_co_tabla06_unidadmedida();
            var dt = new DataTable();
            var xcodigoid1 = string.Empty;
            var xcodigoid2 = string.Empty;
            Decimal equiv = 0;

            BE.sigla = unmed.SelectedValue.ToString();

            dt = BL.GetAll(EmpresaID, BE).Tables[0];

            if (dt.Rows.Count > 0)
            {
                xcodigoid1 = dt.Rows[0]["codigoid"].ToString();

                var BL2 = new tb_co_tabla06_unidadmedidaBL();
                var BE2 = new tb_co_tabla06_unidadmedida();

                var dt2 = new DataTable();

                if (unmedenvase.Text != string.Empty)
                {
                    BE2.sigla = unmedenvase.SelectedValue.ToString();
                    dt2 = BL2.GetAll(EmpresaID, BE2).Tables[0];

                    if (dt2.Rows.Count > 0)
                    {
                        xcodigoid2 = dt2.Rows[0]["codigoid"].ToString();

                        var BE3 = new tb_cm_ordendecompra();
                        var BL3 = new tb_cm_ordendecompraBL();
                        var dt3 = new DataTable();

                        BE3.Unmed1 = xcodigoid1;
                        BE3.Unmed2 = xcodigoid2;
                        dt3 = BL3.GetAll(EmpresaID, BE3).Tables[0];

                        if (dt3.Rows.Count > 0)
                        {
                            equiv = Convert.ToDecimal(dt3.Rows[0]["equivalencia"].ToString());
                            unidenvase.Text = Convert.ToString(equiv);
                        }
                        else
                        {
                            unidenvase.Text = string.Empty;
                        }
                    }
                }
            }
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            data_cbo_unmed();
            data_cbo_unmedenvase();
        }

        private void btn_pestacion_Click(object sender, EventArgs e)
        {
        }

        private void nserie_TextChanged(object sender, EventArgs e)
        {
            if (modulo == "0100")
            {
                if (ssModo == "NEW")
                {
                    if (nserie.Text == string.Empty)
                    {
                        set_serie = string.Empty;
                        generar_denominacion();
                    }
                    else
                    {
                        set_serie = " NS:" + nserie.Text;
                        generar_denominacion();
                    }
                }
            }
        }


        private void colorid_TextChanged(object sender, EventArgs e)
        {
            if (modulo == "0320" || modulo == "0330")
            {
                if (ssModo == "NEW")
                {
                    if (colorid.Text == string.Empty)
                    {
                        set_color = string.Empty;
                        colorname.Text = string.Empty;
                        generar_denominacion();
                    }
                }
            }
        }


        private void titulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                colorid.Focus();
            }
        }

        private void compo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nserie.Focus();
            }
        }

        private void btn_foto_Click(object sender, EventArgs e)
        {
            try
            {
                var myStream = (Stream )null;
                var openFoto = new OpenFileDialog();

                openFoto.InitialDirectory = "c:\\";
                openFoto.Title = "Seleccionar Foto ";
                openFoto.CheckFileExists = true;
                openFoto.CheckPathExists = true;

                openFoto.DefaultExt = "jpg";
                openFoto.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                openFoto.FilterIndex = 1;
                openFoto.RestoreDirectory = true;
                openFoto.ReadOnlyChecked = true;
                openFoto.ShowReadOnly = true;

                var vmnomfile = string.Empty;

                if (openFoto.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = openFoto.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            var originalImage = Image.FromFile(openFoto.FileName);
                            originalImage = fungen.CambiarTamanoImagen(originalImage, 75, 94);

                            go_foto.Visible = true;
                            go_foto.Image = originalImage;

                            vmnomfile = openFoto.FileName.Trim();
                            vmContenidoFile = VariablesPublicas.GetFileData(vmnomfile);
                            _nombreFoto = VariablesPublicas.ExtrarNombreArchivo(vmnomfile);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void generar_denominacion2()
        {
            if (modulo == "0330")
            {
                productname.Text = subgruponame.Text.Trim() + " " + set_titulo.Trim() + " " + set_color.Trim();
            }
            else
            {
                if (modulo == "0320")
                {
                    productname.Text = lineaname.Text.Trim() + " " +
                                   subgrupoartic.ToString() + " " +
                                   set_titulo.Trim() + " " +
                                   set_color.Trim() + " " +
                                   gruponame.Text.ToString();
                }
                else
                {
                    if (modulo == "0340" || modulo == "0350" || modulo == "0360" || modulo == "0370")
                    {
                        productname.Text = subgruponame.Text.ToString();
                    }
                    else
                    {
                        if (modulo == "0500" || modulo == "0100")
                        {
                            productname.Text = subgruponame.Text.Trim() + " " + set_compo.ToString() + " " + set_serie.Trim();
                        }
                    }
                }
            }
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            set_titulo = titulo.Text;
            set_color = " C/ " + colorname.Text.ToString();
            set_serie = "NS: " + nserie.Text;
            generar_denominacion2();
        }

        private void compo_TextChanged(object sender, EventArgs e)
        {
            if (modulo == "0500" || modulo == "0100")
            {
                if (ssModo == "NEW")
                {
                    if (compo.Text == string.Empty)
                    {
                        set_compo = string.Empty;
                        generar_denominacion();
                    }
                    else
                    {
                        set_compo = compo.Text;
                        generar_denominacion();
                    }
                }
            }
        }


        private void btnVer_Click(object sender, EventArgs e)
        {
            if ((vmContenidoFile != null) & _nombreFoto.Trim().Length > 0)
            {
                u_BorrarFile();
                xtmpfile = VariablesPublicas.TmpFile(VariablesPublicas.GetExtensionFile(_nombreFoto.ToString()));
                if (VariablesPublicas.WriteFileData(xtmpfile, vmContenidoFile))
                {
                    try
                    {
                        System.Diagnostics.Process.Start(xtmpfile);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }
            }
        }


        public void u_BorrarFile()
        {
            try
            {
                System.IO.File.Delete(xtmpfile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void moduloiddes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (moduloiddes.SelectedIndex != -1)
            {
                if (moduloiddes.SelectedValue.ToString() == "0320" ||
                    moduloiddes.SelectedValue.ToString() == "0330" ||
                    moduloiddes.SelectedValue.ToString() == "0370")
                {
                    lblnombre.Text = "Gram/Onz/Med:";
                    titulo.MaxLength = 10;
                }
                else
                {
                    lblnombre.Text = "»» Detalle:";
                    titulo.MaxLength = 300;
                }
            }

            if (moduloiddes.Items.Count > 0)
            {
                get_dominio_modulo_local("60".ToString(), moduloiddes.SelectedValue.ToString());
            }
        }

        private void cbo_moduloides_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_moduloides.Items.Count > 0)
            {
                get_dominio_modulo_local2("60".ToString(), cbo_moduloides.SelectedValue.ToString());
            }
        }

        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            if (cbo_moduloides.SelectedIndex != -1)
            {
                Llenar_Datos();
            }
            else
            {
                MessageBox.Show("!!!... Seleccionar Almacen ...!!!", "Información");
                return;
            }
        }


        private void Llenar_Datos()
        {
            if (cbo_moduloides.SelectedIndex != -1 &&
                cbo_moduloides.SelectedValue.ToString() != "0000" &&
                cbo_moduloides.SelectedValue.ToString() != "0200")
            {
                var BE = new tb_me_productos();
                var BL = new tb_me_productosBL();

                BE.moduloid = cbo_moduloides.SelectedValue.ToString();
                BE.productname = txtbusqueda.Text.Trim();
                BE.filtro = "4";

                Tablaproducto = BL.GetAll(EmpresaID, BE).Tables[0];
                if (Tablaproducto.Rows.Count > 0)
                {
                    MDI_dgb_productos.DataSource = Tablaproducto;
                }
                else
                {
                    MDI_dgb_productos.DataSource = Tablaproducto;
                }
            }
            else
            {
            }
        }

        private void txtbusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_busqueda.PerformClick();
            }
        }

        private void MDI_dgb_productos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xfamiliateladetid = dgb_productos.GetRowCellValue(dgb_productos.FocusedRowHandle, "productid").ToString();
                Data_Productos(xfamiliateladetid);
            }
        }


        private void Data_Productos(String xproductid)
        {
            var rowproductos = Tablaproducto.Select("productid='" + xproductid + "'");
            if (rowproductos.Length > 0)
            {
                foreach (DataRow row in rowproductos)
                {
                    moduloiddes.SelectedValue = row["moduloid"].ToString().Trim();
                    lineaid.Text = row["lineaid"].ToString().Trim();
                    lineaname.Text = row["lineaname"].ToString().Trim();
                    grupoid.Text = row["grupoid"].ToString().Trim();
                    gruponame.Text = row["gruponame"].ToString().Trim();
                    subgrupoid.Text = row["subgrupoid"].ToString().Trim();
                    subgruponame.Text = row["subgruponame"].ToString().Trim();
                    item.Text = row["item"].ToString().Trim();
                    productid.Text = row["productid"].ToString().Trim();
                    productidold.Text = row["productidold"].ToString().Trim();
                    productname.Text = row["productname"].ToString().Trim();
                    nom_producto = row["productname"].ToString().Trim();
                    ValidaSubgrupo();
                    titulo.Text = row["titulo"].ToString().Trim();
                    compo.Text = row["compo"].ToString().Trim();
                    colorid.Text = row["colorid"].ToString().Trim();
                    colorname.Text = row["colorname"].ToString().Trim();
                    nserie.Text = row["nserie"].ToString().Trim();


                    estado.SelectedIndex = Convert.ToInt32(row["status"]);
                    if (row["unmed"].ToString().Trim().Length > 0)
                    {
                        unmed.SelectedValue = row["unmed"].ToString().Trim();
                    }
                    if (row["unmedenvase"].ToString().Trim().Length > 0)
                    {
                        unmedenvase.SelectedValue = row["unmedenvase"].ToString().Trim();
                    }
                    else
                    {
                        unmedenvase.SelectedIndex = -1;
                    }
                    unidenvase.Text = row["unidenvase"].ToString().Trim();

                    subgrupoid.Enabled = false;
                    productid.Enabled = true;

                    btn_editar.Enabled = true;
                    btn_eliminar.Enabled = true;
                    btn_imprimir.Enabled = true;

                    btn_primero.Enabled = true;
                    btn_anterior.Enabled = true;
                    btn_siguiente.Enabled = true;
                    btn_ultimo.Enabled = true;

                    btn_log.Enabled = true;
                    btn_salir.Enabled = true;
                }
            }
        }

        private void dgb_productos_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var xfamiliateladetid = dgb_productos.GetRowCellValue(e.RowHandle, "productid").ToString();
            Data_Productos(xfamiliateladetid);
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            var BL = new tb_me_productosBL();
            var BE = new tb_me_productos();
            var TablaMov_ordprod = new DataTable();

            BE.moduloid = modulo.Trim();
            BE.filtro = "2";

            TablaMov_ordprod = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            if (TablaMov_ordprod.Rows.Count > 0)
            {
                ExportarExcel(TablaMov_ordprod);
            }
        }

        private void ExportarExcel(DataTable TablapromoDet)
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


                oSheet.Cells[1, 1] = "ITEMS";
                oSheet.Cells[1, 2] = "CODIGO";
                oSheet.Cells[1, 3] = "PRODUCTO";
                oSheet.Cells[1, 4] = "CANTIDAD";
                oSheet.Cells[1, 5] = "PRECIO";
                oSheet.Cells[1, 6] = "U-MEDIDA";

                oSheet.get_Range("A1", "F1").Font.Bold = true;
                oSheet.get_Range("A1", "F1").Font.Color = Color.White;
                oSheet.get_Range("A1", "F1").Interior.ColorIndex = 14;
                oSheet.get_Range("A1", "F1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                var IndiceFila = 2;
                oSheet.Range["D:E"].NumberFormat = "_ * #,##0.00_ ;_ * -#,##0.00_ ;_ * -??_ ;_ @_ ";

                foreach (DataRow row in TablapromoDet.Rows)
                {
                    oSheet.Cells[IndiceFila, 01].Value = "'" + row["item"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 02].Value = "'" + row["productid"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 03].Value = "'" + row["productname"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 04].Value = row["cantidad"];
                    oSheet.Cells[IndiceFila, 05].Value = row["precunit"];
                    oSheet.Cells[IndiceFila, 06].Value = "'" + row["unmed"].ToString().Trim();

                    IndiceFila++;
                }

                oRng = oSheet.get_Range("A1", "F1");
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

        private void btn_notepad_Click(object sender, EventArgs e)
        {
            var BE = new tb_me_productos();
            var BL = new tb_me_productosBL();
            var dt = new DataTable();

            BE.moduloid = modulo.ToString();
            dt = BL.GetAll_Pocket(EmpresaID, BE).Tables[0];

            if (dt.Rows.Count > 0)
            {
                String strDestinationFile;
                strDestinationFile = @"C:\ErpBapSoftNet_almacen\tb_me_productos.txt";
                TextWriter tw = new StreamWriter(strDestinationFile);
                foreach (DataRow row in dt.Rows)
                {
                    var items = new List<string>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        items.Add(row[col.ColumnName].ToString());
                    }
                    var linea = string.Join("|", items.ToArray());
                    tw.WriteLine(linea);
                }
                tw.Close();
                MessageBox.Show("Proceso Terminado", "Información");
            }
        }
    }
}
