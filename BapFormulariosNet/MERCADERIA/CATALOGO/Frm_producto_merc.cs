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
using System.Net;

using System.IO;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.Net.Sockets;

namespace BapFormulariosNet.MERCADERIA.CATALOGO
{
    public partial class Frm_producto_merc : plantilla
    {
        /*** variables de cabecera del documento actual ***/
        String EmpresaID = "";
        String dominio = VariablesPublicas.Dominioid;
        String modulo = VariablesPublicas.Moduloid;
        String local = VariablesPublicas.Local;
        String perianio = "";
        String perimes = "";

        String XNIVEL = "";
        String XGLOSA = "";
        String PERFILID = "";

        DataTable Tablaproducto;

        Boolean fechadocedit = false;
        Boolean procesado = false;
        Boolean statusDoc = true;
        String subgrupoartic = "";

        Genericas fungen = new Genericas();

        String ssModo = "NEW";

        public Frm_producto_merc()
        {
            InitializeComponent();
        }

        #region $$$ ADMINISTRADOR
        private void PARAMETROS_TABLA()
        {
            String xxferfil = "";
            MainMercaderia f = (MainMercaderia)this.MdiParent;
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
                AYUDAS.Form_user_admin miForma = new AYUDAS.Form_user_admin();
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
        
        private void get_nuevo_producto()
        {
            tb_me_productosBL BL = new tb_me_productosBL();
            tb_me_productos BE = new tb_me_productos();
            DataTable DT = new DataTable();
            BE.moduloid = moduloid.Text.Trim();
            BE.lineaid = lineaid.Text.Trim();
            BE.grupoid = grupoid.Text.Trim();
            BE.subgrupoid = subgrupoid.Text.Trim();
            DT = BL.GetAll_nuevocodprod(EmpresaID, BE).Tables[0];
            try
            {
                item.Text = Convert.ToString(Convert.ToInt16(DT.Rows[0]["item"].ToString().Substring(10, 3)) + 1).PadLeft(3, '0');
                productid.Text = lineaid.Text + grupoid.Text + subgrupoid.Text + item.Text;
            }
            catch
            {
                item.Text = "000";
                productid.Text = lineaid.Text + grupoid.Text + subgrupoid.Text + item.Text;
            }
            if (productid.Text.Trim().Length == 13)
            {
                generar_denominacion();
                form_bloqueado(true);
                productname.Focus();

                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
                btn_log.Enabled = true;
            }
        }
        private void generar_denominacion()
        {
            if (ssModo == "NEW")
                productname.Text = subgruponame.Text.ToString();
        }

        private void form_bloqueado(Boolean var)
        {
            try
            {
                fechadoc.Enabled = false;
                moduloid.Enabled = false;
                lineaid.Enabled = false;
                lineaname.Enabled = false;
                grupoid.Enabled = false;
                gruponame.Enabled = false;
                subgrupoid.Enabled = !var;
                subgruponame.Enabled = false;
               

                item.Enabled = false;
                productid.Enabled = false;

                productname.ReadOnly = !var;
                nserie.ReadOnly = !var;
                txt_criterio.Enabled = !var;
                btn_busqueda.Enabled = !var;

                // Desabilitarlos Por El Momento
                    unmed.Enabled = false;
                    precioenvase.Enabled = false;
                    unmedenvase.Enabled = false;
                    unidenvase.Enabled = false;
                    unmedpeso.Enabled = false;
                    peso.Enabled = false;
                    cenestado.Enabled = false;

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
                DataTable dt = new DataTable();
                dgb_productos.DataSource = dt;
                ssModo = "NEW";
            }
        }
        private void form_cargar_datos(String posicion)
        {
            try
            {               
                tb_me_productosBL BL = new tb_me_productosBL();
                tb_me_productos BE = new tb_me_productos();
                DataTable dt = new DataTable();

                BE.moduloid = modulo;
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
                    nserie.Text = dt.Rows[0]["nserie"].ToString().Trim();
                    // Agregado
                    cenestado.SelectedIndex = Convert.ToInt32(dt.Rows[0]["procedenciaid"]);

                    if (dt.Rows[0]["unmed"].ToString().Trim().Length > 0)
                        unmed.SelectedValue = dt.Rows[0]["unmed"].ToString().Trim();

                    precioenvase.Text = dt.Rows[0]["precioenvase"].ToString().Trim().PadLeft(1, '0');

                    if (dt.Rows[0]["unmedenvase"].ToString().Trim().Length > 0)
                        unmedenvase.SelectedValue = dt.Rows[0]["unmedenvase"].ToString().Trim();
                    else
                        unmedenvase.SelectedIndex = -1;

                    unidenvase.Text = dt.Rows[0]["unidenvase"].ToString().Trim();
                    unmedpeso.Text = dt.Rows[0]["unmedpeso"].ToString().Trim();
                    peso.Text = dt.Rows[0]["peso"].ToString().Trim().PadLeft(1, '0');


                    String foto = dt.Rows[0]["foto"].ToString();

                    if (dt.Rows[0]["foto"].ToString() != "")
                    {
                        byte[] MyData1 = null;
                        MyData1 = (byte[])(dt.Rows[0]["foto"]);

                        if (MyData1 != null && MyData1.Length != 0)
                        {
                            go_foto.Visible = true;
                            go_foto.Image = null;
                            System.IO.MemoryStream ms = new System.IO.MemoryStream();
                            // Se utiliza el MemoryStream para extraer la imagen                
                            ms.Write(MyData1, 0, MyData1.Length);
                            go_foto.Image = Image.FromStream(ms);
                        }
                        else
                        {
                            go_foto.Visible = false;
                            go_foto.ImageLocation = "";
                        }
                    }
                    else
                    {
                        go_foto.Visible = false;
                        go_foto.ImageLocation = "";
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
        #region $$$ Llenado de Combobox

        void data_cbo_unmed()
        {
            try
            {
                tb_co_tabla06_unidadmedidaBL BL = new tb_co_tabla06_unidadmedidaBL();
                tb_co_tabla06_unidadmedida BE = new tb_co_tabla06_unidadmedida();
                DataTable dt = new DataTable();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                // Primer Combo Unidad De Medida
                unmed.DataSource = dt;                
                unmed.ValueMember = "sigla";
                unmed.DisplayMember = "descripcion";                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void data_cbo_unmedenvase() {
            try
            {
                tb_co_tabla06_unidadmedidaBL BL = new tb_co_tabla06_unidadmedidaBL();
                tb_co_tabla06_unidadmedida BE = new tb_co_tabla06_unidadmedida();
                DataTable dt = new DataTable();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                // Segundo Combo Unidad de Medida
                unmedenvase.DataSource = dt;
                unmedenvase.ValueMember = "sigla";
                unmedenvase.DisplayMember = "descripcion";
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }
        #endregion


        private void ValidaSubgrupo()
        {
            if (subgrupoid.Text.Trim().Length > 0 && lineaid.Text.Trim().Length == 3 && grupoid.Text.Trim().Length == 4)
            {
                tb_me_subgrupoBL BL = new tb_me_subgrupoBL();
                tb_me_subgrupo BE = new tb_me_subgrupo();
                DataTable dt = new DataTable();

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
                    lineaid.Text = "";
                    lineaname.Text = "";
                    grupoid.Text = "";
                    gruponame.Text = "";
                    subgrupoid.Text = "";
                    subgruponame.Text = "";
                }
            }
            else
            {
                lineaid.Text = "";
                lineaname.Text = "";
                grupoid.Text = "";
                gruponame.Text = "";
                subgrupoid.Text = "";
                subgruponame.Text = "";
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
        
        #endregion

        #region *** Metodos que retornan datos
        public bool IsNumeric(String Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
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

        private void AyudaSubgrupo(String lpdescrlike)
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

                        AYUDAS.Frm_help_general frmayuda = new AYUDAS.Frm_help_general();

                        frmayuda.tipoo = "sql"; //sql,tabla
                        frmayuda.titulo = "<< AYUDA TABLA ARTICULO >>";
                        frmayuda.sqlquery = "SELECT (lineaid + gr.grupoid + subgrupoid) as Codigo,lineaid,gr.grupoid,g.gruponame as Marca,subgrupoid,subgruponame as Modelo  FROM tb_" + modd + "_subgrupo gr ";
                        frmayuda.sqlinner = " inner join tb_" + modd + "_grupo g on gr.grupoid = g.grupoid "; //inner
                        if (lineaid.Text.Trim().Length > 0 && grupoid.Text.Trim().Length > 0)
                        {
                            frmayuda.sqlwhere = "where lineaid = " + lineaid.Text + " and gr.grupoid = " + grupoid.Text + " "; //where
                            frmayuda.sqland = "and";//and
                        }
                        else if (lineaid.Text.Trim().Length > 0)
                        {
                            frmayuda.sqlwhere = "where lineaid = " + lineaid.Text + " "; //where
                            frmayuda.sqland = "and";//and
                        }
                        else if (grupoid.Text.Trim().Length > 0)
                        {
                            frmayuda.sqlwhere = "where gr.grupoid = " + grupoid.Text + " "; //where
                            frmayuda.sqland = "and";//and
                        }
                        else
                        {
                            frmayuda.sqlwhere = "where"; //where
                            frmayuda.sqland = "";//and
                        }

                        frmayuda.criteriosbusqueda = new string[] {"MODELO", "CODIGO" };
                        frmayuda.columbusqueda = "subgruponame,lineaid + gr.grupoid + subgrupoid";
                        //frmayuda.criteriosbusqueda = new string[] { "Buscar" };
                        //frmayuda.columbusqueda = "lineaid,grupoid,subgrupoid";
                        frmayuda.returndatos = "1,2,4";

                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeSubgrupo;
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void RecibeSubgrupo(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                lineaid.Text = resultado1.Trim();
                grupoid.Text = resultado2.Trim();
                subgrupoid.Text = resultado3.Trim();
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

                BE.dominioid = dominio.Trim();
                BE.moduloid = modulo.Trim();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();

                        AYUDAS.Frm_help_general frmayuda = new AYUDAS.Frm_help_general();

                        frmayuda.tipoo = "sql"; //sql,tabla,all
                        frmayuda.titulo = "<< AYUDA  TABLA PRODUCTOS >>";
                        frmayuda.sqlquery = "SELECT tb1.productid as Codigo, tb1.productname as Producto,tb2.lineaname as Linea,tb3.gruponame as Marca FROM tb_" + modd + "_productos AS tb1 ";
                        frmayuda.sqlinner = "inner join tb_" + modd + "_linea as tb2 on tb1.lineaid = tb2.lineaid " +
                                            "inner join tb_" + modd + "_grupo as tb3 on tb1.grupoid = tb3.grupoid"; //inner
                        frmayuda.sqlwhere = "where"; //where
                        frmayuda.sqland = "";//and
                        frmayuda.criteriosbusqueda = new string[] { "PRODUCTO", "CODIGO", "LINEA", "MARCA" };
                        frmayuda.columbusqueda = "tb1.productname,tb1.productid,tb2.lineaname,tb3.gruponame";
                        frmayuda.returndatos = "0,1";

                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeProducto;
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void RecibeProducto(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            try
            {
                if (resultado1.Trim().Length == 13)
                {
                    productid.Text = resultado1;
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
            String xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio + "/" + productid.Text.Trim();
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
                moduloid.Text = VariablesPublicas.Moduloid.Trim();
                subgrupoartic = "";

                lineaid.Text = "";
                lineaname.Text = "";
                grupoid.Text = "";
                gruponame.Text = "";
                subgrupoid.Text = "";
                subgruponame.Text = "";
                nserie.Text = "";
                item.Text = "";
                productid.Text = "";
                productname.Text = "";
                unmed.SelectedValue = "UND";
                unmedenvase.SelectedValue = "UND";
                precioenvase.Text = "0";
                //unmedenvase.Text = "";
                unidenvase.Text = "1";
                unmedpeso.Text = "";
                peso.Text = "0";
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
                else if (productname.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese nombre de producto !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (unmed.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione la unidad de medida !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (unmedenvase.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione la unidad de medida !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (unidenvase.Text == "")
                {
                    MessageBox.Show("Ingrese Equivalente !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    tb_me_productosBL BL = new tb_me_productosBL();
                    tb_me_productos BE = new tb_me_productos();

                    BE.moduloid = modulo.Trim();
                    BE.lineaid = lineaid.Text.Trim();
                    BE.grupoid = grupoid.Text.Trim();
                    BE.subgrupoid = subgrupoid.Text.Trim();
                    BE.item = item.Text.Trim();
                   
                    BE.productid = productid.Text.Trim();
                    BE.productname = productname.Text.Trim().ToUpper();
                    BE.nserie = nserie.Text.ToString();

                    BE.productidold = "0";
                                      
                    if (unmed.SelectedValue != null)
                        BE.unmed = unmed.SelectedValue.ToString();

                    BE.precioenvase = Convert.ToDecimal(precioenvase.Text.Trim().PadLeft(1, '0'));

                    if (unmedenvase.SelectedValue != null)
                        BE.unmedenvase = unmedenvase.SelectedValue.ToString();
                    else
                        unmedenvase.Text = "";

                    BE.procedenciaid = cenestado.SelectedIndex.ToString();

                    BE.unidenvase = Convert.ToDecimal(unidenvase.Text.Trim());
                    BE.unmedpeso = unmedpeso.Text.Trim().ToUpper();
                    BE.peso = Convert.ToDecimal(peso.Text.Trim().PadLeft(0, '0'));
                    BE.status = "0";
                    BE.usuar = VariablesPublicas.Usuar.Trim();

                    // Asignando el valor de la imagen

                    // Stream usado como buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    // Se guarda la imagen en el buffer
                    if (go_foto.Image != null)
                    {
                        go_foto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    // Se extraen los bytes del buffer para asignarlos como valor para el 
                    // parámetro.
                    BE.Foto = ms.GetBuffer();


                    if (BL.Insert(EmpresaID, BE))
                    {
                        MessageBox.Show("Datos grabados correctamente !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (productid.Text.Trim().Length != 13)
                {
                    MessageBox.Show("Código de producto invalido !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (productname.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese nombre de producto !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (unmed.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione la unidad de medida !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (unmedenvase.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione la unidad de medida !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (unidenvase.Text == "")
                {
                    MessageBox.Show("Ingrese Equivalente !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    tb_me_productosBL BL = new tb_me_productosBL();
                    tb_me_productos BE = new tb_me_productos();

                    BE.moduloid = modulo.Trim();
                    BE.lineaid = lineaid.Text.Trim();
                    BE.grupoid = grupoid.Text.Trim();
                    BE.subgrupoid = subgrupoid.Text.Trim();
                    BE.item = item.Text.Trim();
                   
                    BE.productid = productid.Text.Trim();
                    BE.productname = productname.Text.Trim().ToUpper();
                    BE.nserie = nserie.Text.ToString();
                                                          
                    if (unmed.SelectedValue != null)
                        BE.unmed = unmed.SelectedValue.ToString();
                    BE.precioenvase = Convert.ToDecimal(precioenvase.Text.Trim().PadLeft(1, '0'));

                    if (unmedenvase.SelectedValue != null)
                        BE.unmedenvase = unmedenvase.SelectedValue.ToString();

                    BE.procedenciaid = cenestado.SelectedIndex.ToString();
                    BE.unidenvase = Convert.ToDecimal(unidenvase.Text.Trim());
                    BE.unmedpeso = unmedpeso.Text.Trim().ToUpper();
                    BE.peso = Convert.ToDecimal(peso.Text.Trim().PadLeft(0, '0'));
                    BE.status = "0";
                    BE.usuar = VariablesPublicas.Usuar.Trim();

                    // Asignando el valor de la imagen
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    if (go_foto.Image != null)
                    {
                        go_foto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    BE.Foto = ms.GetBuffer();

                    if (BL.Update(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("M");
                        MessageBox.Show("Datos modificado correctamente !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (productid.Text.Trim().Length != 13)
                {
                    MessageBox.Show("Código de producto invalido !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    tb_me_productosBL BL = new tb_me_productosBL();
                    tb_me_productos BE = new tb_me_productos();

                    BE.moduloid = modulo.Trim();
                    BE.productid = productid.Text.Trim();
                    BE.status = "9";
                    BE.usuar = VariablesPublicas.Usuar.Trim();

                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos eliminados correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        #endregion

        #region *** Controles de usuarios
        private void Frm_productos_Activated(object sender, EventArgs e)
        {

        }

        private void Frm_productos_Load(object sender, EventArgs e)
        {
            EmpresaID = VariablesPublicas.EmpresaID;
            //PARAMETROS_TABLA();
            NIVEL_FORMS();
         
            Tablaproducto = new DataTable();
            Tablaproducto.Columns.Add("productid", typeof(String));
            Tablaproducto.Columns.Add("productname", typeof(String));

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

            this.cenestado.Items.Clear();
            this.cenestado.Items.AddRange("Nacional,Importado".Split(new char[] { ',' }));            
            this.cenestado.SelectedIndex = 0;
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

        private void subgrupoid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaSubgrupo("");
            }
            ValidaSubgrupo();
            get_nuevo_producto();
        }

        
        private void productid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaProducto("");
            }

            if (e.KeyCode == Keys.Enter)
            {
                form_cargar_datos("");
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
                    form_cargar_datos("");
                }
            }
        }
        private void titulo_TextChanged(object sender, EventArgs e)
        {
            generar_denominacion();
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
            //if (XNIVEL == "0" || XNIVEL == "1")
            if (XNIVEL == "0")
            {
                ssModo = "EDIT";
                form_bloqueado(true);

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
            bool sw_prosigue = false;
            if (ssModo == "NEW")
            {
                if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
                    Insert();
                    btn_busqueda_Click(sender, e);
            }
            else
            {
                if (XNIVEL == "0" || XNIVEL == "1")
                {
                    sw_prosigue = (MessageBox.Show("¿Desea Modificar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                    if (sw_prosigue)
                    {
                        Update();
                        btn_busqueda_Click(sender, e);
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
                bool sw_prosigue = false;
                sw_prosigue = (MessageBox.Show("¿Desea Eliminar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                if (sw_prosigue)
                {
                    Delete();
                    btn_busqueda_Click(sender, e);
                }
            }
        }
        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                //REPORTES.Frm_reportes miForma = new REPORTES.Frm_reportes();

                //miForma.dominioid = dominio.Trim();
                //miForma.moduloid = modulo.Trim();
                //miForma.local = local.Trim();

                //miForma.Text = "Reporte de Productos";
                //miForma.formulario = "Frm_producto";
                //miForma.ShowDialog();
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
            Seguridadlog.FrmSeguridad oform = new Seguridadlog.FrmSeguridad();
            String xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio + "/" + productid.Text.Trim();
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
            //productname.Text = productname.Text.Trim().ToUpper();
            //productname.CharacterCasing = CharacterCasing.Upper;
        }

        private void unmed_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificamos el codigoid Primer Combo
            tb_co_tabla06_unidadmedidaBL BL = new tb_co_tabla06_unidadmedidaBL();
            tb_co_tabla06_unidadmedida BE = new tb_co_tabla06_unidadmedida();
            DataTable dt = new DataTable();
            String xcodigoid1 = "", xcodigoid2 = "";
            Decimal equiv = 0;       

            BE.sigla = unmed.SelectedValue.ToString();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];

            if (dt.Rows.Count > 0)
            {
                xcodigoid1 = dt.Rows[0]["codigoid"].ToString();

                // Verificamos el Segundo Combo
                tb_co_tabla06_unidadmedidaBL BL2 = new tb_co_tabla06_unidadmedidaBL();
                tb_co_tabla06_unidadmedida BE2 = new tb_co_tabla06_unidadmedida();
                
                DataTable dt2 = new DataTable();

                if (unmedenvase.Text != "")
                {
                    BE2.sigla = unmedenvase.SelectedValue.ToString();
                    dt2 = BL2.GetAll(EmpresaID, BE2).Tables[0];

                    if (dt2.Rows.Count > 0)
                    {
                        xcodigoid2 = dt2.Rows[0]["codigoid"].ToString();

                        // En Esta Parte Recien Verificamos La Igualdad de Codigos :D
                        tb_cm_ordendecompra BE3 = new tb_cm_ordendecompra();
                        tb_cm_ordendecompraBL BL3 = new tb_cm_ordendecompraBL();
                        DataTable dt3 = new DataTable();

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
                            unidenvase.Text = "";
                        }
                    }                    
                }
            }           
        }

        private void unmedenvase_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificamos el codigoid
            tb_co_tabla06_unidadmedidaBL BL = new tb_co_tabla06_unidadmedidaBL();
            tb_co_tabla06_unidadmedida BE = new tb_co_tabla06_unidadmedida();
            DataTable dt = new DataTable();
            String xcodigoid1 = "", xcodigoid2 = "";
            Decimal equiv = 0;   

            BE.sigla = unmed.SelectedValue.ToString();

            dt = BL.GetAll(EmpresaID, BE).Tables[0];

            if (dt.Rows.Count > 0)
            {
                xcodigoid1 = dt.Rows[0]["codigoid"].ToString();

                // Verificamos el Primer Combo
                tb_co_tabla06_unidadmedidaBL BL2 = new tb_co_tabla06_unidadmedidaBL();
                tb_co_tabla06_unidadmedida BE2 = new tb_co_tabla06_unidadmedida();

                DataTable dt2 = new DataTable();

                if (unmedenvase.Text != "")
                {
                    BE2.sigla = unmedenvase.SelectedValue.ToString();
                    dt2 = BL2.GetAll(EmpresaID, BE2).Tables[0];

                    if (dt2.Rows.Count > 0)
                    {
                        xcodigoid2 = dt2.Rows[0]["codigoid"].ToString();

                        // En Esta Parte Recien Verificamos La Igualdad de Codigos :D
                        tb_cm_ordendecompra BE3 = new tb_cm_ordendecompra();
                        tb_cm_ordendecompraBL BL3 = new tb_cm_ordendecompraBL();
                        DataTable dt3 = new DataTable();

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
                            unidenvase.Text = "";
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
            //Frm_producto_est frmEstacion = new Frm_producto_est();
            //frmEstacion.ShowDialog();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txt_criterio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_busqueda_Click(sender, e);
            }
        }

        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            try
            {               
                tb_me_productosBL BL = new tb_me_productosBL();
                tb_me_productos BE = new tb_me_productos();
               // DataTable TablaProducto = new DataTable();

                BE.moduloid = modulo;
                BE.productname = txt_criterio.Text.Trim().ToUpper();

                Tablaproducto = BL.GetAll(EmpresaID, BE).Tables[0];
                if (Tablaproducto.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    dgb_productos.DataSource = Tablaproducto;
                    //dgb_productos.Rows[0].Selected = false;
                    //dgb_productos.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }  

        #endregion

        private void dgb_productos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                String xproductid = "", xdni = "";
                xproductid = dgb_productos.Rows[dgb_productos.CurrentRow.Index].Cells["codigo"].Value.ToString().Trim();
                data_Producto(xproductid);
            }
        }


        private void data_Producto(String xproductid)
        {
            form_bloqueado(false);
            DataRow[] rowgrupoid = Tablaproducto.Select("productid='" + xproductid + "'");
            if (rowgrupoid.Length > 0)
            {
                foreach (DataRow row in rowgrupoid)
                {
                    productid.Text = row["productid"].ToString().Trim();
                    productname.Text = row["productname"].ToString().Trim();
                    lineaid.Text = row["lineaid"].ToString().Trim();
                    lineaname.Text = row["lineaname"].ToString().Trim();
                    grupoid.Text = row["grupoid"].ToString().Trim();
                    gruponame.Text = row["gruponame"].ToString().Trim();
                    subgrupoid.Text = row["subgrupoid"].ToString().Trim();
                    subgruponame.Text = row["subgruponame"].ToString().Trim();
                    item.Text = row["item"].ToString().Trim();
                    nserie.Text = row["nserie"].ToString().Trim();

                    String fot = row["foto"].ToString();

                    if ((row["foto"].ToString()) != "")
                    {
                        go_foto.Visible = true;
                        go_foto.Image = null;
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        byte[] MyData1 = (byte[])(row["foto"]);
                        ms.Write(MyData1, 0, MyData1.Length);

                        if (MyData1 != null && MyData1.Length != 0)
                        {
                            go_foto.Visible = true;
                            go_foto.Image = null;
                            // Se utiliza el MemoryStream para extraer la imagen                
                            ms.Write(MyData1, 0, MyData1.Length);
                            go_foto.Image = Image.FromStream(ms);

                        }
                        else
                        {
                            go_foto.Visible = false;
                            go_foto.ImageLocation = "";
                        }
                    }
                    else
                    {
                        go_foto.Visible = false;
                        go_foto.ImageLocation = "";
                    }
                }

                btn_nuevo.Enabled = true;
                btn_editar.Enabled = true;
                btn_eliminar.Enabled = true;
                btn_imprimir.Enabled = true;
                btn_salir.Enabled = true;
                btn_cancelar.Enabled = true;
            }
        }

        private void dgb_productos_CellClick(object sender, DataGridViewCellEventArgs e)
        {                            
            try
            {
                if (dgb_productos.CurrentRow != null)
                {
                    String xproductid = "";
                    xproductid = dgb_productos.Rows[e.RowIndex].Cells["codigo"].Value.ToString().Trim();
                    data_Producto(xproductid);              
                }
            }
            catch (Exception ex)
            {
              
            }         
        }

        private void nserie_TextChanged(object sender, EventArgs e)
        {
            if (nserie.Text == "")
            {
                productname.Text = subgruponame.Text.ToString();
            }
            else
            {
                generar_denominacion2();
            }
        }

        private void generar_denominacion2()
        {
            if (ssModo == "NEW" || ssModo == "EDIT"){
                productname.Text = subgruponame.Text.ToString() + " N/S: " + nserie.Text.Trim();
            }
        }

        private void btn_foto_Click(object sender, EventArgs e)
        {
            try
            {
                Int16 xHeight = 128;
                Int16 xWidth = 99;
                String xfoto = "";
                String xpath = "";
                String xexts = "";
                String xfilePath = "";

                Stream myStream = null;
                OpenFileDialog openFoto = new OpenFileDialog();

                openFoto.InitialDirectory = "c:\\";
                openFoto.Title = "Seleccionar Foto ";
                openFoto.CheckFileExists = true;
                openFoto.CheckPathExists = true;

                openFoto.DefaultExt = "jpg";
                openFoto.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                openFoto.FilterIndex = 1;
                //openFoto.Multiselect = false;
                openFoto.RestoreDirectory = true;
                openFoto.ReadOnlyChecked = true;
                openFoto.ShowReadOnly = true;

                if (openFoto.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = openFoto.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            Image originalImage = Image.FromFile(openFoto.FileName);
                            originalImage = fungen.CambiarTamanoImagen(originalImage, 75, 94);

                            go_foto.Visible = true;
                            go_foto.Image = originalImage;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void go_foto_DoubleClick(object sender, EventArgs e)
        {
            AYUDAS.Frm_Imagen img = new AYUDAS.Frm_Imagen();


            //String fot = row["foto"].ToString();

            //if ((row["foto"].ToString()) != "")
            //{
            //    go_foto.Visible = true;
            //    go_foto.Image = null;
            //    System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //    byte[] MyData1 = (byte[])(row["foto"]);
            //    ms.Write(MyData1, 0, MyData1.Length);
            //    System.Drawing.Bitmap b = new Bitmap(ms);
            //    go_foto.SizeMode = PictureBoxSizeMode.StretchImage;

            //    go_foto.Image = new System.Drawing.Bitmap(b);
            //}
            //else
            //{
            //    go_foto.Visible = false;
            //    go_foto.ImageLocation = "";
            //}

            img.Show();
            img.Visible = true;
        }

    }
}