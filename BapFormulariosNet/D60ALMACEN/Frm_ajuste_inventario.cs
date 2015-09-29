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

namespace BapFormulariosNet.D60ALMACEN
{
    public partial class Frm_ajuste_inventario : plantilla
    {
        /*** variables de cabecera del documento actual ***/
        String EmpresaID = "";
        String dominio = "60";
        String modulo = "";
        String local = "";
        String perianio = "";
        String perimes = "";

        String PERFILID = "";

        Boolean fechadocedit = false;
        Boolean procesado = false;
        Boolean statusDoc = true;

        String ssModo = "NEW";

        /* Metodos Publicos */
        Genericas fungen = new Genericas();

        public Frm_ajuste_inventario()
        {
            InitializeComponent();
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
        #endregion

        #region *** Metodos generales
        private void form_bloqueado(Boolean var)
        {
            try
            {
                fech_ini.Enabled = var;
                fech_fin.Enabled = var;
                txtLocal.Enabled = var;                
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

                ssModo = "NEW";
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
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData /*KeyEventArgs keyData*/)
        {
            if (keyData == Keys.Enter)
            {
                if (GetNextControl(ActiveControl, true) != null)
                {
                    //keyData.Handled = true;
                    //MessageBox.Show(ActiveControl.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //GetNextControl(ActiveControl, true).Focus();
                    //SendKeys.Send("{TAB}");
                    SendKeys.Send("\t");
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
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

        //private void AyudaLinea(String lpdescrlike)
        //{
        //    try
        //    {
        //        String modd = "";
        //        sys_moduloBL BL = new sys_moduloBL();
        //        tb_sys_modulo BE = new tb_sys_modulo();
        //        DataTable dt = new DataTable();

        //        BE.dominioid = dominio;
        //        BE.moduloid = modulo;
        //        dt = BL.GetAll(EmpresaID, BE).Tables[0];
        //        if (dt.Rows.Count > 0)
        //        {
        //            if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
        //            {
        //                modd = dt.Rows[0]["moduloshort"].ToString().Trim();

        //                AYUDAS.Frm_help_general frmayuda = new AYUDAS.Frm_help_general();

        //                frmayuda.tipoo = "sql"; //sql,tabla
        //                frmayuda.titulo = "<< AYUDA  TABLA LINEA >>";
        //                frmayuda.sqlquery = "SELECT lineaid, lineaname FROM tb_" + modd + "_linea ";
        //                frmayuda.sqlinner = ""; //inner
        //                frmayuda.sqlwhere = "where"; //where
        //                frmayuda.sqland = "";//and
        //                frmayuda.criteriosbusqueda = new string[] { "LINEA", "CODIGO" };
        //                frmayuda.columbusqueda = "lineaname,lineaid";
        //                frmayuda.returndatos = "0,1";

        //                frmayuda.Owner = this;
        //                frmayuda.PasaProveedor = RecibeLinea;
        //                frmayuda.ShowDialog();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
        //private void RecibeLinea(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        //{
        //    if (resultado1.Trim().Length > 0)
        //    {
        //        serop_ini.Text = resultado1.Trim();
        //        numop_ini.Text = resultado2.Trim();
        //    }
        //}
        #endregion

        #region *** Metodos mantenimiento de datos
        private void limpiar_documento()
        {
            try
            {
                fech_ini.Text = "";
                fech_fin.Text = "";
                //txtLocal.Text = "";
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

            ssModo = "NEW";
        }
        private string get_LocalName(string dominioid, string moduloid, string local)
        {
            sys_localBL BL = new sys_localBL();
            tb_sys_local BE = new tb_sys_local();
            DataTable DT = new DataTable();
            try
            {
                DT = BL.GetOne(EmpresaID, dominioid, moduloid, local).Tables[0];
                return fungen.RemoveAccentsWithRegEx(DT.Rows[0]["localname"].ToString());
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }
        #endregion

        #region *** Controles de usuarios
        private void Frm_ajuste_inventario_Load(object sender, EventArgs e)
        {
            EmpresaID = VariablesPublicas.EmpresaID;
            modulo = VariablesPublicas.Moduloid.Trim();
            local = VariablesPublicas.Local.Trim();

            perianio = VariablesPublicas.perianio;
            perimes = VariablesPublicas.perimes;

            PARAMETROS_TABLA();

            txtLocal.Text = get_LocalName(dominio, modulo, local);
            periodo.Text = "AÑO: " + perianio + "  MES: " + fungen.get_mesCad(perimes);

            limpiar_documento();
            form_bloqueado(false);          
        }        
        private void serop_ini_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(sender, e);
        }
        private void numop_ini_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(sender, e);
        }
        private void serop_fin_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(sender, e);
        }
        private void numop_fin_KeyPress(object sender, KeyPressEventArgs e)
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

        }
        
        private void btn_process_Click(object sender, EventArgs e)
        {
            bool sw_prosigue = false;

            String msg2 = "Usuario : " + VariablesPublicas.Nombr +
                         "\nEste Proceso es Irreversible"+
                         "\nUna vez concluído se borrarán datos del archivo de trabajo";

            sw_prosigue = (MessageBox.Show(msg2, "Desea Proseguir !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

            if (sw_prosigue)
            {
                fech_ini.Text = DateTime.Now.Date.ToShortDateString();

                tb_60local_stock_inventarioBL BL = new tb_60local_stock_inventarioBL();
                tb_60local_stock_inventario BE = new tb_60local_stock_inventario();

                BE.dominioid = dominio;
                BE.moduloid = modulo;
                BE.local = local;
                BE.fechdoc = Convert.ToDateTime(fech_ini.Text.ToString());
                try
                {

                    if (BL.Ajuste_Inv(VariablesPublicas.EmpresaID.ToString(), BE))
                    {
                        fech_fin.Text = DateTime.Now.ToLongTimeString();

                        //Eliminar de la Tabla Local Stock Inventario
                        BL.GetAll_New(EmpresaID, BE);

                        MessageBox.Show("Proceso terminado Correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Contactese con Sistema !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

       



        #region $$$ grid subgrupo
        #endregion

        #region $$$ busqueda
        #endregion
        #endregion
    }
}