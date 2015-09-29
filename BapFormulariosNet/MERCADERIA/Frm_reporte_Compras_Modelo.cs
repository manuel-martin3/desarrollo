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
using System.Collections;

namespace BapFormulariosNet.MERCADERIA
{
    public partial class Frm_reporte_Compras_Modelo : plantilla
    {
        /*** variables de cabecera del documento actual ***/
        String EmpresaID = "";
        String dominio = "60";
        String modulo = VariablesPublicas.Moduloid;
        String local = VariablesPublicas.Local;
        String perianio = "";
        String perimes = "";

        String PERFILID = "";

        Boolean fechadocedit = false;
        Boolean procesado = false;
        Boolean statusDoc = true;

        String ssModo = "NEW";

        public Frm_reporte_Compras_Modelo()
        {
            InitializeComponent();
            lineaid.LostFocus += new System.EventHandler(lineaid_LostFocus);
            grupoid.LostFocus += new System.EventHandler(grupoid_LostFocus);
            subgrupoid.LostFocus += new System.EventHandler(subgrupoid_LostFocus);          

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
        #endregion

        #region *** Metodos generales
        private void get_tipocambio(String fecha)
        {
            try
            {
                //genera tipo de cambio dependiendo la fech del documento
                tipocambioBL BL = new tipocambioBL();
                tb_tipocambio BE = new tb_tipocambio();
                DataTable dt = new DataTable();

                dt = BL.GetOne(EmpresaID, Convert.ToDateTime(fecha)).Tables[0];

                //if (dt.Rows.Count > 0)
                //{
                //    tcamb.Text = Convert.ToDecimal(dt.Rows[0]["venta"]).ToString("###,##0.0000");
                //}
                //else
                //{
                //    tcamb.Text = "1";
                //}

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
                subgrupoid.Enabled = !var;
                subgruponame.Enabled = var;
                fechini.Enabled = var;
                fechfin.Enabled = var;

                lineaid.Enabled = var;
                cboModuloID.Enabled = var;
                lineaname.Enabled = false;
                grupoid.Enabled = var;
                gruponame.Enabled = false;
                subgrupoid.Enabled = var;
                subgruponame.Enabled = false;         

                btn_nuevo.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_imprimir.Enabled = false;
                btn_excel.Enabled = false;
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
                form_bloqueado(false);
                subgrupoid.Text = "";
                btn_nuevo.Enabled = true;
                btn_salir.Enabled = true;

                ssModo = "NEW";
            }
        }

        #region $$$ Llenado de Combobox
        #endregion
        private void ValidaLinea()
        {
            if (lineaid.Text.Trim().Length > 0)
            {
                tb_me_lineaBL BL = new tb_me_lineaBL();
                tb_me_linea BE = new tb_me_linea();
                DataTable dt = new DataTable();

                BE.moduloid = modulo;
                BE.lineaid = lineaid.Text.Trim().PadLeft(3, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    lineaid.Text = dt.Rows[0]["lineaid"].ToString().Trim();
                    lineaname.Text = dt.Rows[0]["lineaname"].ToString().Trim();
                }
                else
                {
                    lineaid.Text = "";
                    lineaname.Text = "";
                }
            }
            else
            {
                lineaid.Text = "";
                lineaname.Text = "";
            }
        }

        private void ValidaGrupo()
        {
            if (grupoid.Text.Trim().Length > 0)
            {
                tb_me_grupoBL BL = new tb_me_grupoBL();
                tb_me_grupo BE = new tb_me_grupo();
                DataTable dt = new DataTable();

                BE.moduloid = modulo;
                BE.grupoid = grupoid.Text.Trim().PadLeft(4, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    grupoid.Text = dt.Rows[0]["grupoid"].ToString().Trim();
                    gruponame.Text = dt.Rows[0]["gruponame"].ToString().Trim();
                }
                else
                {
                    grupoid.Text = "";
                    gruponame.Text = "";
                }
            }
            else
            {
                grupoid.Text = "";
                gruponame.Text = "";
            }
        }
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
                }
                else
                {
                    subgrupoid.Text = "";
                    subgruponame.Text = "";
                }
            }
            else
            {
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

        private void AyudaLinea(String lpdescrlike)
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
                        frmayuda.titulo = "<< AYUDA  TABLA LINEA >>";
                        frmayuda.sqlquery = "SELECT lineaid, lineaname FROM tb_me_linea ";
                        frmayuda.sqlinner = ""; //inner
                        frmayuda.sqlwhere = "where moduloid='" + modulo + "'"; //where
                        frmayuda.sqland = "and";//and
                        frmayuda.criteriosbusqueda = new string[] { "LINEA", "CODIGO" };
                        frmayuda.columbusqueda = "lineaname,lineaid";
                        frmayuda.returndatos = "0,1";

                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeLinea;
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void RecibeLinea(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                lineaid.Text = resultado1.Trim();
                lineaname.Text = resultado2.Trim();
                grupoid.Focus();
            }
        }

        private void AyudaGrupo(String lpdescrlike)
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
                        frmayuda.titulo = "<< AYUDA TABLA GRUPOS >>";
                        frmayuda.sqlquery = "SELECT grupoid, gruponame FROM tb_me_grupo ";
                        frmayuda.sqlinner = ""; //inner
                        frmayuda.sqlwhere = "where moduloid='" + modulo + "'"; //where
                        frmayuda.sqland = "and";//and
                        frmayuda.criteriosbusqueda = new string[] { "GRUPO", "CODIGO" };
                        frmayuda.columbusqueda = "gruponame,grupoid";
                        frmayuda.returndatos = "0,1";

                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeGrupo;
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void RecibeGrupo(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                grupoid.Text = resultado1.Trim();
                gruponame.Text = resultado2.Trim();
                subgrupoid.Focus();
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
                        frmayuda.sqlquery = "SELECT subgrupoid, subgruponame, lineaid, grupoid FROM tb_me_subgrupo ";
                        frmayuda.sqlinner = ""; //inner
                        if (lineaid.Text.Trim().Length > 0 && grupoid.Text.Trim().Length > 0)
                        {
                            frmayuda.sqlwhere = "where moduloid =" + modulo + " and lineaid=" + lineaid.Text + " and grupoid = " + grupoid.Text + " "; //where
                            frmayuda.sqland = "and";//and
                        }
                        else if (lineaid.Text.Trim().Length > 0)
                        {
                            frmayuda.sqlwhere = "where moduloid =" + modulo + " and lineaid = " + lineaid.Text + " "; //where
                            frmayuda.sqland = "and";//and
                        }
                        else if (grupoid.Text.Trim().Length > 0)
                        {
                            frmayuda.sqlwhere = "where moduloid =" + modulo + " and grupoid = " + grupoid.Text + " "; //where
                            frmayuda.sqland = "and";//and
                        }
                        else
                        {
                            frmayuda.sqlwhere = "where moduloid ='" + modulo + "'"; //where
                            frmayuda.sqland = "and";//and
                        }

                        frmayuda.criteriosbusqueda = new string[] { "ARTICULO", "CODIGO" };
                        frmayuda.columbusqueda = "subgruponame,subgrupoid";
                        frmayuda.returndatos = "0,2,3";

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
                lineaid.Text = resultado2.Trim();
                grupoid.Text = resultado3.Trim();
                subgrupoid.Text = resultado1.Trim();
            }
        }

        #endregion

        #region *** Metodos mantenimiento de datos
        private void limpiar_documento()
        {
            try
            {
                DateTime fechatemp = DateTime.Today;
                DateTime f1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);

                cboModuloID.SelectedIndex = -1;
                lineaid.Text = "";
                lineaname.Text = "";
                grupoid.Text = "";
                gruponame.Text = "";
                subgrupoid.Text = "";
                subgruponame.Text = "";         
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
            btn_imprimir.Enabled = true;
            btn_excel.Enabled = true;
            btn_cancelar.Enabled = true;
            lineaid.Focus();

            ssModo = "NEW";
        }

        #endregion

        #region *** Controles de usuarios
        

        private void Frm_reporte_stockrollo_Load(object sender, EventArgs e)
        {
            EmpresaID = VariablesPublicas.EmpresaID;
            limpiar_documento();
            get_cbo_modulo();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_salir.Enabled = true;
        }
        private void Frm_reporte_stockrollo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {

            }

            if (e.Control && e.KeyCode == Keys.N)
            {
                if (btn_nuevo.Enabled)
                {
                    nuevo();
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

        private void lineaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaLinea("");
                grupoid.Focus();
            }
        }
        private void lineaid_LostFocus(object sender, System.EventArgs e)
        {
            ValidaLinea();
        }

        private void grupoid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaGrupo("");
                subgrupoid.Focus();
            }
        }

        private void grupoid_LostFocus(object sender, System.EventArgs e)
        {
            ValidaGrupo();
        }

        private void subgrupoid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Ayudasubgrupo("");
                lineaid.Focus();
            }
        }

        private void subgrupoid_LostFocus(object sender, System.EventArgs e)
        {
            ValidaSubgrupo();
        }      
       

        private void serref_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(sender, e);
        }
        private void numref_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(sender, e);
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            form_accion_cancelEdicion(1);
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            try
            {

                if (cboModuloID.SelectedIndex != -1)
                {
                    REPORTES.Frm_reportes miForma = new REPORTES.Frm_reportes();
                    miForma.Text = "LISTADO DE COMPRAS POR MODELO";

                    miForma.moduloid = cboModuloID.SelectedValue.ToString();
                    miForma.lineaid = lineaid.Text.Trim();
                    miForma.lineaname = lineaname.Text.Trim();
                    miForma.grupoid = grupoid.Text.Trim();
                    miForma.gruponame = gruponame.Text.Trim();
                    miForma.subgrupoid = subgrupoid.Text.Trim();
                    miForma.subgruponame = subgruponame.Text.Trim();
                    miForma.fechdocini = fechini.Text;
                    miForma.fechdocfin = fechfin.Text;
                    miForma.formulario = "Frm_reporte_Compras_Modelo";
                    miForma.Show();
                }
                else {
                    MessageBox.Show("Seleccione un Modulo..!!","Imformacion",MessageBoxButtons.OK);
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void get_cbo_modulo()
        {
            sys_dominioBL BL = new sys_dominioBL();
            tb_sys_dominio BE = new tb_sys_dominio();
            try
            {
                cboModuloID.DataSource = BL.GetAllDominioModuloPorUsuario(VariablesPublicas.EmpresaID, VariablesPublicas.Usuar,"60").Tables[0];
                cboModuloID.ValueMember = "moduloid";
                cboModuloID.DisplayMember = "moduloname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }


        #endregion

        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            DataTable TablaProductostock = new DataTable("Productostock");
            try
            {
                tb_me_local_stockBL BL = new tb_me_local_stockBL();
                tb_me_local_stock BE = new tb_me_local_stock();

                BE.moduloid = modulo.Trim();
                BE.local = local.Trim();
                BE.lineaid = lineaid.Text.Trim();
                BE.grupoid = grupoid.Text.Trim();
                BE.subgrupoid = subgrupoid.Text.Trim();          

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exportarExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfdconsolidado.ShowDialog(this) == DialogResult.OK)
            {
                //Examinar3.ExportToXls(sfdconsolidado.FileName);
                OpenFile(sfdconsolidado.FileName);
            }
            
        }

        private static void OpenFile(string fileName)
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.FileName = fileName;
                process.StartInfo.Verb = "Open";
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                process.Start();
            }
            catch
            {
                MessageBox.Show("No se puede encontrar una aplicación en el sistema adecuado para abrir el archivo con datos exportados.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }        
        }             
    }
}