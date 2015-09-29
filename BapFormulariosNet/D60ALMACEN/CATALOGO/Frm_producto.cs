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

namespace BapFormulariosNet.D60ALMACEN.CATALOGO
{
    public partial class Frm_producto : plantilla
    {
        /*** variables de cabecera del documento actual ***/
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = "";
        private String local = "";     
        String perianio = "";
        String perimes = "";

        String XNIVEL = "";
        String XGLOSA = "";
        String PERFILID = "";

        DataTable Tablaproducto;
        String nom_producto = "";
        String set_titulo = "";
        String set_color = "";
        String set_serie = "";
        String set_compo = "";

        Genericas fungen = new Genericas();
        
        Byte[] vmContenidoFile;
        private string xtmpfile = VariablesPublicas.TmpFile("TMP");

        Boolean fechadocedit = false;
        Boolean procesado = false;
        Boolean statusDoc = true;
        String subgrupoartic = "";
        String _ctacte = "";
        String _nombreFoto = "";
        String ssModo = "NEW";

        public Frm_producto()
        {
            InitializeComponent();

            colorid.LostFocus += new System.EventHandler(colorid_LostFocus);
            marcaid.LostFocus += new System.EventHandler(marcaid_LostFocus);           
            titulo.TextChanged += new System.EventHandler(titulo_TextChanged);
        }

        #region $$$ ADMINISTRADOR

        private void PARAMETROS_TABLA()
        {
            String xxferfil = "";
            MainAlmacen f = (MainAlmacen)this.MdiParent;
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

        private void get_nuevo_producto()
        {
            tb_60productosBL BL = new tb_60productosBL();
            tb_60productos BE = new tb_60productos();
            DataTable DT = new DataTable();
            BE.moduloid = moduloid.Text.Trim();
            BE.lineaid = lineaid.Text.Trim();
            BE.grupoid = grupoid.Text.Trim();
            BE.subgrupoid = subgrupoid.Text.Trim();
            DT = BL.GetAll_nuevocodprod(EmpresaID, BE).Tables[0];
            try
            {
                //item.Text = Convert.ToString(Convert.ToInt16(DT.Rows[0]["item"].ToString().Substring(10, 3)) + 1).PadLeft(3, '0');
                //productid.Text = lineaid.Text + grupoid.Text + subgrupoid.Text + item.Text;
                item.Text = DT.Rows[0]["productid"].ToString().Substring(10, 3);
                productid.Text = DT.Rows[0]["productid"].ToString();
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
                titulo.Focus();

                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
                btn_log.Enabled = true;
            }
        }


        private void generar_denominacion()
        {
            if (ssModo == "NEW" && btn_nuevo.Enabled == false)
            {
                if (modulo == "0330")
                {
                    productname.Text = subgruponame.Text.Trim() + " " + set_titulo.Trim() + " " + set_color.Trim();
                }
                else if (modulo == "0320")
                {
                    productname.Text = lineaname.Text.Trim() + " " +
                                       subgrupoartic.ToString() + " " +
                                       set_titulo.Trim() + " " +
                                       set_color.Trim() + " " +
                                       gruponame.Text.ToString();
                }
                else if (modulo == "0340" || modulo == "0350" || modulo == "0360" || modulo == "0370")
                {                    
                    productname.Text = subgruponame.Text.ToString();
                }
                else if (modulo == "0500")
                {                   
                    //productname.Text = subgruponame.Text.Trim() + " " + compo.Text.ToString() + " " + "NS: "+nserie.Text.ToString();
                    productname.Text = subgruponame.Text.Trim() + " " + set_compo.ToString() + " " + set_serie.Trim();
                }
            }            

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

                nserie.Enabled = var;
                productname.Enabled = false; //Cambiamos Por var

                productidold.Enabled = false;
                titulo.Enabled = var;
                compo.Enabled = var;
                colorid.Enabled = var;
                procedenciaid.Enabled = false;
                estado.Enabled = var;
                colorname.Enabled = false;
                marcaid.Enabled = var;
                marcaname.Enabled = false;
                coleccionid.Enabled = var;
                generoid.Enabled = var;
                temporadaid.Enabled = var;
               
                unmed.Enabled = var;              
                unmedenvase.Enabled = var;
                unidenvase.Enabled = var;
                unmedpeso.Enabled = var;
                peso.Enabled = var;

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

                ssModo = "NEW";
            }
        }

        private void form_cargar_datos(String posicion)
        {
            try
            {
                tb_60productosBL BL = new tb_60productosBL();
                tb_60productos BE = new tb_60productos();
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
                    nom_producto = dt.Rows[0]["productname"].ToString().Trim();
                    
                    productidold.Text = dt.Rows[0]["productidold"].ToString().Trim();
                    titulo.Text = dt.Rows[0]["titulo"].ToString().Trim();
                    compo.Text = dt.Rows[0]["compo"].ToString().Trim();
                    colorid.Text = dt.Rows[0]["colorid"].ToString().Trim();
                    colorname.Text = dt.Rows[0]["colorname"].ToString().Trim();
                    marcaid.Text = dt.Rows[0]["marcaid"].ToString().Trim();
                    marcaname.Text = dt.Rows[0]["marcaname"].ToString().Trim();
                    if (dt.Rows[0]["coleccionid"].ToString().Trim().Length > 0)
                        coleccionid.SelectedValue = dt.Rows[0]["coleccionid"].ToString().Trim();
                    if (dt.Rows[0]["generoid"].ToString().Trim().Length > 0)
                        generoid.SelectedValue = dt.Rows[0]["generoid"].ToString().Trim();
                    if (dt.Rows[0]["temporadaid"].ToString().Trim().Length > 0)
                        temporadaid.SelectedValue = dt.Rows[0]["temporadaid"].ToString().Trim();                  
                    
                    // Agregado

                    procedenciaid.SelectedIndex = Convert.ToInt32(dt.Rows[0]["paisid"]);
                    txt_paisname.Text = dt.Rows[0]["paisname"].ToString().Trim();
                    nserie.Text = dt.Rows[0]["nserie"].ToString().Trim();

                    estado.SelectedIndex = Convert.ToInt32(dt.Rows[0]["status"]);

                
                    if (dt.Rows[0]["unmed"].ToString().Trim().Length > 0)
                        unmed.SelectedValue = dt.Rows[0]["unmed"].ToString().Trim();
                
                    if (dt.Rows[0]["unmedenvase"].ToString().Trim().Length > 0)
                        unmedenvase.SelectedValue = dt.Rows[0]["unmedenvase"].ToString().Trim();
                    else
                        unmedenvase.SelectedIndex = -1;

                    unidenvase.Text = dt.Rows[0]["unidenvase"].ToString().Trim();
                    unmedpeso.Text = dt.Rows[0]["unmedpeso"].ToString().Trim();
                    peso.Text = dt.Rows[0]["peso"].ToString().Trim().PadLeft(1, '0');
                    _nombreFoto = dt.Rows[0]["docname"].ToString().ToString();                   

                    String foto = dt.Rows[0]["foto"].ToString();

                    if (dt.Rows[0]["foto"].ToString() != "")
                    {
                        byte[] MyData1 = null;
                        MyData1 = (byte[])(dt.Rows[0]["foto"]);

                        if (MyData1 != null && MyData1.Length != 0)
                        {
                            vmContenidoFile = MyData1;
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
       
        void data_cbo_coleccionid()
        {
            try
            {
                tb_pt_coleccionBL BL = new tb_pt_coleccionBL();
                tb_pt_coleccion BE = new tb_pt_coleccion();
                coleccionid.DataSource = BL.GetAll(EmpresaID, BE).Tables[0];
                coleccionid.ValueMember = "coleccionid";
                coleccionid.DisplayMember = "coleccionname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void data_cbo_generoid()
        {
            try
            {
                tb_pt_generoBL BL = new tb_pt_generoBL();
                tb_pt_genero BE = new tb_pt_genero();
                generoid.DataSource = BL.GetAll(EmpresaID, BE).Tables[0];
                generoid.ValueMember = "generoid";
                generoid.DisplayMember = "generoname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void data_cbo_temporadaid()
        {
            try
            {
                tb_pt_temporadaBL BL = new tb_pt_temporadaBL();
                tb_pt_temporada BE = new tb_pt_temporada();
                temporadaid.DataSource = BL.GetAll(EmpresaID, BE).Tables[0];
                temporadaid.ValueMember = "temporadaid";
                temporadaid.DisplayMember = "temporadaname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
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
                tb_60subgrupoBL BL = new tb_60subgrupoBL();
                tb_60subgrupo BE = new tb_60subgrupo();
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

        private void ValidaColor()
        {
            if (colorid.Text.Trim().Length > 0)
            {
                tb_60colorBL BL = new tb_60colorBL();
                tb_60color BE = new tb_60color();
                DataTable dt = new DataTable();

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
                    colorid.Text = "";
                    colorname.Text = "";
                    generar_denominacion();
                }
            }
            else
            {
                colorid.Text = "";
                colorname.Text = "";
                generar_denominacion();
            }
        }

        private void ValidaMarca()
        {
            if (marcaid.Text.Trim().Length > 0)
            {
                tb_pt_marcaBL BL = new tb_pt_marcaBL();
                tb_pt_marca BE = new tb_pt_marca();
                DataTable dt = new DataTable();

                BE.marcaid = marcaid.Text.Trim().PadLeft(2, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    marcaid.Text = dt.Rows[0]["marcaid"].ToString().Trim();
                    marcaname.Text = dt.Rows[0]["marcaname"].ToString().Trim();
                }
                else
                {
                    marcaid.Text = "";
                    marcaname.Text = "";
                }
            }
            else
            {
                marcaid.Text = "";
                marcaname.Text = "";
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

        private void Ayudasubgrupo(String lpdescrlike)
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

                        Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                        frmayuda.tipoo = "sql"; //sql,tabla
                        frmayuda.titulo = "<< AYUDA TABLA ARTICULO >>";
                        frmayuda.sqlquery = "SELECT (lineaid + gr.grupoid + subgrupoid) as Codigo,lineaid,gr.grupoid,g.gruponame,subgrupoid,subgruponame,g.ctacte  FROM tb_" + modd + "_subgrupo gr ";
                        
                        if (modd == "sm")
                        {frmayuda.sqlinner = " Inner Join tb_" + modd + "_grupo g on gr.grupoid = g.grupoid and gr.status = '0' ";}
                        else { frmayuda.sqlinner = " Inner Join tb_" + modd + "_grupo g on gr.grupoid = g.grupoid and gr.status = '0' "; }

                        if (lineaid.Text.Trim().Length > 0 && grupoid.Text.Trim().Length > 0)
                        {
                            frmayuda.sqlwhere = "WHERE lineaid = " + lineaid.Text + " and gr.grupoid = " + grupoid.Text + " "; //where
                            frmayuda.sqland = "and";//and
                        }
                        else if (lineaid.Text.Trim().Length > 0)
                        {
                            frmayuda.sqlwhere = "WHERE lineaid = " + lineaid.Text + " "; //where
                            frmayuda.sqland = "and";//and
                        }
                        else if (grupoid.Text.Trim().Length > 0)
                        {
                            frmayuda.sqlwhere = "WHERE gr.grupoid = " + grupoid.Text + " "; //where
                            frmayuda.sqland = "and";//and
                        }
                        else
                        {
                            frmayuda.sqlwhere = "where"; //where
                            frmayuda.sqland = "";//and
                        }

                        frmayuda.criteriosbusqueda = new string[] {"ARTICULO", "CODIGO" };
                        frmayuda.columbusqueda = "subgruponame,lineaid + gr.grupoid + subgrupoid";
                        frmayuda.returndatos = "1,2,4,6";

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

                _ctacte = resultado4.ToString();

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

                        Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();
                        frmayuda.nameform = "color";
                        frmayuda.tipoo = "sql"; //sql,tabla,all
                        frmayuda.titulo = "<< AYUDA  TABLA PRODUCTOS >>";
                        frmayuda.sqlquery = "SELECT tb1.productid, tb1.productname,tb2.lineaname,tb3.gruponame,tb1.productidold FROM tb_" + modd + "_productos AS tb1 ";
                        frmayuda.sqlinner = "inner join tb_" + modd + "_linea as tb2 on tb1.lineaid = tb2.lineaid " +
                                            "inner join tb_" + modd + "_grupo as tb3 on tb1.grupoid = tb3.grupoid"; //inner
                        frmayuda.sqlwhere = "where tb1.status = '0' "; //where
                        frmayuda.sqland = "and";//and
                        frmayuda.criteriosbusqueda = new string[] { "PRODUCTO", "CODIGO", "LINEA", "GRUPO" };
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

        private void AyudaColor(String lpdescrlike)
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
                        Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                        frmayuda.tipoo = "sql"; //sql,tabla,all
                        frmayuda.titulo = "Ayuda Color";
                        frmayuda.sqlquery = "select colorid, colorname from tb_" + modd + "_color";
                        frmayuda.sqlinner = ""; //inner
                        frmayuda.sqlwhere = "where"; //where
                        frmayuda.sqland = "";//and
                        frmayuda.criteriosbusqueda = new string[] { "COLOR", "CÓDIGO" };
                        frmayuda.columbusqueda = "colorname,colorid";
                        frmayuda.returndatos = "0,1";

                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeColor;
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void RecibeColor(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                colorid.Text = resultado1.Trim();
                colorname.Text = resultado2.Trim();
            }
        }

        private void AyudaMarca(String lpdescrlike)
        {
            try
            {
                Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql"; //sql,tabla,all
                frmayuda.titulo = "Ayuda Marca";
                frmayuda.sqlquery = "select marcaid, marcaname from tb_pt_marca";
                frmayuda.sqlinner = ""; //inner
                frmayuda.sqlwhere = "where"; //where
                frmayuda.sqland = "";//and
                frmayuda.criteriosbusqueda = new string[] { "MARCA", "CÓDIGO" };
                frmayuda.columbusqueda = "marcaname,marcaid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeMarca;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        private void RecibeMarca(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                marcaid.Text = resultado1.Trim();
                marcaname.Text = resultado2.Trim();
            }
        }

        #endregion

        #region *** Metodos mantenimiento de datos

        private void SEGURIDAD_LOG(String accion)
        {
            String xclave = VariablesPublicas.EmpresaID + "/" + ((D60ALMACEN.MainAlmacen)MdiParent).perianio + "/" + productid.Text.Trim();
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
                moduloid.Text = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
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
                productidold.Text = "";
                compo.Text = "";
                colorid.Text = "";
                colorname.Text = "";
                marcaid.Text = "";
                marcaname.Text = "";
                titulo.Text = "";
                coleccionid.SelectedIndex = -1;
                generoid.SelectedIndex = -1;
                temporadaid.SelectedIndex = -1;              
                unmed.SelectedValue = "UND";
                unmedenvase.SelectedValue = "UND";
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
                    tb_60productosBL BL = new tb_60productosBL();
                    tb_60productos BE = new tb_60productos();

                    BE.moduloid = modulo.Trim();
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
                    BE.marcaid = marcaid.Text.Trim();
                    if (coleccionid.SelectedValue != null)
                        BE.coleccionid = coleccionid.SelectedValue.ToString();
                    if (generoid.SelectedValue != null)
                        BE.generoid = generoid.SelectedValue.ToString();
                    if (temporadaid.SelectedValue != null)
                        BE.temporadaid = temporadaid.SelectedValue.ToString();
                  
                    if (unmed.SelectedValue != null)
                        BE.unmed = unmed.SelectedValue.ToString();

                  

                    if (unmedenvase.SelectedValue != null)
                        BE.unmedenvase = unmedenvase.SelectedValue.ToString();
                    else
                        unmedenvase.Text = "";

                    BE.procedenciaid = procedenciaid.SelectedIndex.ToString();

                    BE.unidenvase = Convert.ToDecimal(unidenvase.Text.Trim());
                    BE.unmedpeso = unmedpeso.Text.Trim().ToUpper();
                    BE.peso = Convert.ToDecimal(peso.Text.Trim().PadLeft(0, '0'));
                    BE.status = estado.SelectedIndex.ToString();
                    BE.usuar = VariablesPublicas.Usuar.Trim();

                    BE.nserie = nserie.Text.ToString();
                    // Asignando el valor de la imagen
                    // Stream usado como buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    // Se guarda la imagen en el buffer
                    if (modulo == "0500")
                    {
                        if (go_foto.Image != null)
                        {
                            go_foto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                    }
                    // Se extraen los bytes del buffer para asignarlos como valor para el 
                    // parámetro.
                    BE.Foto = ms.GetBuffer();

                    if (BL.Insert(EmpresaID, BE))
                    {
                        MessageBox.Show("Datos Grabados Correctamente !!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        procesado = true;
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
                tb_60productosBL BL = new tb_60productosBL();
                tb_60productos BE = new tb_60productos();

                BE.moduloid = modulo.Trim();
                BE.local = local.Trim();    
                BE.productid = productid.Text.Trim();
                BE.docname = _nombreFoto.ToString();
            
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                // Se guarda la imagen en el buffer
                if (modulo == "0500")
                {
                    if (go_foto.Image != null)
                    {
                        go_foto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
                // Se extraen los bytes del buffer para asignarlos como valor para el 
                // parámetro.
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
                                     
                    tb_60productosBL BL = new tb_60productosBL();
                    tb_60productos BE = new tb_60productos();

                    BE.moduloid = modulo.Trim();
                    BE.lineaid = lineaid.Text.Trim();
                    BE.grupoid = grupoid.Text.Trim();
                    BE.subgrupoid = subgrupoid.Text.Trim();
                    BE.item = item.Text.Trim();                   
                    BE.productname = productname.Text.Trim().ToUpper();
                    BE.productidold = productidold.Text.Trim().ToUpper();
                    BE.titulo = titulo.Text.Trim().ToUpper();
                    BE.compo = compo.Text.Trim().ToUpper();
                    BE.colorid = colorid.Text.Trim();
                    BE.colorname = colorname.Text.Trim().ToUpper();
                    BE.marcaid = marcaid.Text.Trim();
                    if (coleccionid.SelectedValue != null)
                        BE.coleccionid = coleccionid.SelectedValue.ToString();
                    if (generoid.SelectedValue != null)
                        BE.generoid = generoid.SelectedValue.ToString();
                    if (temporadaid.SelectedValue != null)
                        BE.temporadaid = temporadaid.SelectedValue.ToString();                   
                    if (unmed.SelectedValue != null)
                        BE.unmed = unmed.SelectedValue.ToString();                  
                    if (unmedenvase.SelectedValue != null)
                        BE.unmedenvase = unmedenvase.SelectedValue.ToString();

                    BE.procedenciaid = procedenciaid.SelectedIndex.ToString();
                    BE.unidenvase = Convert.ToDecimal(unidenvase.Text.Trim());
                    BE.unmedpeso = unmedpeso.Text.Trim().ToUpper();
                    BE.peso = Convert.ToDecimal(peso.Text.Trim().PadLeft(0, '0'));
                    BE.status = estado.SelectedIndex.ToString();
                    BE.usuar = VariablesPublicas.Usuar.Trim();
                    BE.nserie = nserie.Text.ToString();
                    // Asignando el valor de la imagen
                    // Stream usado como buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    // Se guarda la imagen en el buffer

                    if (modulo == "0500")
                    {
                        if (go_foto.Image != null)
                        {
                            go_foto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                    }

                    // Se extraen los bytes del buffer para asignarlos como valor para el 
                    // parámetro.
                    BE.Foto = ms.GetBuffer();

                    if (BL.Update(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("M");
                        MessageBox.Show("Datos Modificado Correctamente !!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        procesado = true;
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
                tb_60productosBL BL = new tb_60productosBL();
                tb_60productos BE = new tb_60productos();

                BE.moduloid = modulo.Trim();
                BE.local = local.Trim();
                BE.productid = productid.Text.Trim();
                BE.docname = _nombreFoto.ToString();

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                // Se guarda la imagen en el buffer
                if (modulo == "0500")
                {
                    if (go_foto.Image != null)
                    {
                        go_foto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
                // Se extraen los bytes del buffer para asignarlos como valor para el 
                // parámetro.
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
                    tb_60productosBL BL = new tb_60productosBL();
                    tb_60productos BE = new tb_60productos();

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
        

        private void Frm_productos_Load(object sender, EventArgs e)
        {
            modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
            local = ((D60ALMACEN.MainAlmacen)MdiParent).local;      

            PARAMETROS_TABLA();
            NIVEL_FORMS();


            Tablaproducto = new DataTable();
            productname.CharacterCasing = CharacterCasing.Upper;
            data_cbo_coleccionid();
            data_cbo_generoid();
            data_cbo_temporadaid();
            data_cbo_unmed();
            data_cbo_unmedenvase();
            limpiar_documento();
            form_bloqueado(false);
            Llenar_Datos();
            subgrupoid.Enabled = false;
            productid.Enabled = true;

            btn_nuevo.Enabled = true;
            btn_primero.Enabled = true;
            btn_anterior.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_ultimo.Enabled = true;
            btn_salir.Enabled = true;

            this.procedenciaid.Items.Clear();
            this.procedenciaid.Items.AddRange("Nacional,Importado".Split(new char[] { ',' }));
            this.procedenciaid.SelectedIndex = 0;

            this.estado.Items.Clear();
            this.estado.Items.AddRange("Operativo,Malogrado,Baja".Split(new char[] {','}));
            this.estado.SelectedIndex = 0;
            
        }

        private void Llenar_Datos()
        {
            tb_60productos BE = new tb_60productos();
            tb_60productosBL BL = new tb_60productosBL();
            BE.moduloid = modulo.ToString();
            Tablaproducto = BL.GetAll(EmpresaID, BE).Tables[0];
            if (Tablaproducto.Rows.Count > 0)
            {
                MDI_dgb_productos.DataSource = Tablaproducto;
            }
            else { MDI_dgb_productos.DataSource = Tablaproducto; }
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
                Ayudasubgrupo("");
            }

            ValidaSubgrupo();
            get_nuevo_producto();
            ValidamosProcedencia();
            //GeneraCodAsoc();
        }



        private void GeneraCodAsoc() 
        {
            //tb_60productosBL BL = new tb_60productosBL();
            //tb_60productos BE = new tb_60productos();
            //DataTable DT = new DataTable();

            //BE.moduloid = moduloid.Text.Trim();
            //BE.lineaid = lineaid.Text.Trim();

            //DT = BL.GenCodAsoc(EmpresaID, BE).Tables[0];

            //if (DT.Rows.Count > 0)
            //{
            //    String _item = Convert.ToString(Convert.ToInt32(DT.Rows[0]["item"].ToString()) + 1);
            //    productidold.Text = lineaid.Text + _item.ToString();
            //}
            
        }


        private void ValidamosProcedencia()
        {
            clienteBL BL = new clienteBL();
            tb_cliente BE = new tb_cliente();

            DataTable dt = new DataTable();
            BE.ctacte = _ctacte.ToString();
            BE.filtro = "2";
            dt = BL.GetAll(EmpresaID, BE).Tables[0];

            if (dt.Rows.Count > 0)
            {
                if (modulo.ToString() != "0500") // Diferente Porque No Diferenciamos su Proveedor
                {
                    String set_ctacte = dt.Rows[0]["ctacte"].ToString().Trim();
                    String set_ctactename = dt.Rows[0]["ctactename"].ToString().Trim();
                    String set_paisname = dt.Rows[0]["paisname"].ToString().Trim();
                    String set_paisid = dt.Rows[0]["paisid"].ToString().Trim();

                    if (set_paisid == "9589") // Codigo de Peru
                    {
                        this.procedenciaid.SelectedIndex = 0;
                        txt_paisname.Text = set_paisname.ToString();
                    }
                    else
                    {
                        this.procedenciaid.SelectedIndex = 1;
                        txt_paisname.Text = set_paisname.ToString();
                    }
                }
                else
                {
                    this.procedenciaid.SelectedIndex = 0;
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
            if (modulo == "0320")
            {
                if (ssModo == "NEW")
                {
                    if (titulo.Text == "")
                    {
                        set_titulo = "";
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
                AyudaColor("");

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
            //ValidaColor();
        }

        private void marcaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaMarca("");
            }
        }

        private void marcaid_LostFocus(object sender, System.EventArgs e)
        {
            ValidaMarca();
        }                 

      

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
            {
                nuevo();
                MDI_dgb_productos.Enabled = false;
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
            MDI_dgb_productos.Enabled = true;
        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {
            procesado = false;
            bool sw_prosigue = false;
            if (ssModo == "NEW")
            {
                if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")

                    if (modulo == "0320")
                    {
                        if (titulo.Text == "")
                        {
                            MessageBox.Show("Ingrese Titulo / Onz !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (compo.Text == "")
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
            else
            {
                if (XNIVEL == "0" || XNIVEL == "1")
                {
                    sw_prosigue = (MessageBox.Show("¿Desea Modificar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                    if (sw_prosigue)
                    {
                        if (modulo == "0320")
                        {
                            if (titulo.Text == "")
                            {
                                MessageBox.Show("Ingrese Titulo / Onz !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if (compo.Text == "")
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
                REPORTES.Frm_reportes miForma = new REPORTES.Frm_reportes();

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
            AyudaProducto("");
        }

        private void btn_ultimo_Click(object sender, EventArgs e)
        {
            form_cargar_datos(Genericas.ultimo);
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
            Seguridadlog.FrmSeguridad oform = new Seguridadlog.FrmSeguridad();
            String xclave = VariablesPublicas.EmpresaID + "/" + ((D60ALMACEN.MainAlmacen)MdiParent).perianio + "/" + productid.Text.Trim();
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
            Frm_producto_est frmEstacion = new Frm_producto_est();
            frmEstacion.ShowDialog();
        }

        private void nserie_TextChanged(object sender, EventArgs e)
        {
            if (modulo == "0500")
            {
                if (ssModo == "NEW")
                {
                    if (nserie.Text == "")
                    {
                        set_serie = "";
                        generar_denominacion();
                    }
                    else
                    {
                        set_serie = " NS: " + nserie.Text;
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
                    if (colorid.Text == "")
                    {
                        set_color = "";
                        colorname.Text = "";
                        generar_denominacion();
                    }
                }
            }


        }


        #endregion

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

                string vmnomfile = "";

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
            else if (modulo == "0320")
            {
                productname.Text = lineaname.Text.Trim() + " " +
                                   subgrupoartic.ToString() + " " +
                                   set_titulo.Trim() + " " +
                                   set_color.Trim() + " " +
                                   gruponame.Text.ToString();
            }
            else if (modulo == "0340" || modulo == "0350" || modulo == "0360" || modulo == "0370")
            {
                productname.Text = subgruponame.Text.ToString();
            }
            else if (modulo == "0500")
            {                
                productname.Text = subgruponame.Text.Trim() + " " + compo.Text.ToString() + " " + "NS: " + nserie.Text.ToString();
            }
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            tb_60subgrupoBL BL = new tb_60subgrupoBL();
            tb_60subgrupo BE = new tb_60subgrupo();
            DataTable dt = new DataTable();

            BE.moduloid = modulo;
            BE.lineaid = lineaid.Text.Trim().PadLeft(3, '0');
            BE.grupoid = grupoid.Text.Trim().PadLeft(4, '0');
            BE.subgrupoid = subgrupoid.Text.Trim().PadLeft(3, '0');

            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                subgrupoartic = dt.Rows[0]["subgrupoartic"].ToString().Trim();
            }

            set_titulo = titulo.Text;
            set_color = " C/ " + colorname.Text.ToString();
            set_serie = nserie.Text;
            generar_denominacion2();
        }

        private void compo_TextChanged(object sender, EventArgs e)
        {
            if (modulo == "0500")
            {
                if (ssModo == "NEW")
                {
                    if (compo.Text == "")
                    {
                        set_compo = "";
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

        private void dgb_productos_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            String xfamiliateladetid = dgb_productos.GetRowCellValue(e.RowHandle, "productid").ToString();
            Data_Productos(xfamiliateladetid);  
        }

        private void MDI_dgb_productos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                String xfamiliateladetid = dgb_productos.GetRowCellValue(dgb_productos.FocusedRowHandle, "productid").ToString();
                Data_Productos(xfamiliateladetid);
            }
        }

        private void Data_Productos(String xproductid)
        {
            DataRow[] rowproductos = Tablaproducto.Select("productid='" + xproductid + "'");
            if (rowproductos.Length > 0)
            {
                foreach (DataRow row in rowproductos)
                {
                    moduloid.Text = row["moduloid"].ToString().Trim();
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
                    marcaid.Text = row["marcaid"].ToString().Trim();
                    marcaname.Text = row["marcaname"].ToString().Trim();
                    nserie.Text = row["nserie"].ToString().Trim();

                    if (row["coleccionid"].ToString().Trim().Length > 0)
                        coleccionid.SelectedValue = row["coleccionid"].ToString().Trim();
                    if (row["generoid"].ToString().Trim().Length > 0)
                        generoid.SelectedValue = row["generoid"].ToString().Trim();
                    if (row["temporadaid"].ToString().Trim().Length > 0)
                        temporadaid.SelectedValue = row["temporadaid"].ToString().Trim();

                    // Agregado
                    procedenciaid.SelectedIndex = Convert.ToInt32(row["paisid"]);
                    txt_paisname.Text = row["paisname"].ToString().Trim();                 
                    estado.SelectedIndex = Convert.ToInt32(row["status"]);
                    if (row["unmed"].ToString().Trim().Length > 0)
                        unmed.SelectedValue = row["unmed"].ToString().Trim();

                    if (row["unmedenvase"].ToString().Trim().Length > 0)
                        unmedenvase.SelectedValue = row["unmedenvase"].ToString().Trim();
                    else
                        unmedenvase.SelectedIndex = -1;

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


    }
}