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
    public partial class Frm_reporte_mov_ordprod : plantilla
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

        public Frm_reporte_mov_ordprod()
        {
            InitializeComponent();
            numop_ini.LostFocus += new System.EventHandler(numop_ini_LostFocus);
            numop_fin.LostFocus += new System.EventHandler(numop_fin_LostFocus);
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
        private void form_bloqueado(Boolean var)
        {
            try
            {
                almacaccionid.Enabled = var;
                serop_ini.Enabled = var;
                numop_ini.Enabled = var;
                serop_fin.Enabled = var;
                numop_fin.Enabled = var;
                fechdocini.Enabled = var;
                fechdocfin.Enabled = var;

                btn_nuevo.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_imprimir.Enabled = false;
                btn_excel.Enabled = false;

                btn_buscar.Enabled = false;
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

                btn_nuevo.Enabled = true;
                btn_buscar.Enabled = true;
                btn_salir.Enabled = true;

                ssModo = "NEW";
            }
        }
        #region $$$ Llenado de Combobox
        void data_cbo_tipmov()
        {
            Dictionary<string, string> test = new Dictionary<string, string>();
            test.Add(" ", "TODO");
            test.Add("10", "INGRESO");
            test.Add("20", "SALIDA");
            almacaccionid.DataSource = new BindingSource(test, null);
            almacaccionid.DisplayMember = "Value";
            almacaccionid.ValueMember = "Key";
        }
        #endregion
        private void ValidaLinea()
        {
            if (serop_ini.Text.Trim().Length > 0)
            {
                tb_60lineaBL BL = new tb_60lineaBL();
                tb_60linea BE = new tb_60linea();
                DataTable dt = new DataTable();

                BE.moduloid = modulo;
                BE.lineaid = serop_ini.Text.Trim().PadLeft(3, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    serop_ini.Text = dt.Rows[0]["lineaid"].ToString().Trim();
                    numop_ini.Text = dt.Rows[0]["lineaname"].ToString().Trim();
                }
                else
                {
                    serop_ini.Text = "";
                    numop_ini.Text = "";
                }
            }
            else
            {
                serop_ini.Text = "";
                numop_ini.Text = "";
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
                        frmayuda.sqlquery = "SELECT lineaid, lineaname FROM tb_" + modd + "_linea ";
                        frmayuda.sqlinner = ""; //inner
                        frmayuda.sqlwhere = "where"; //where
                        frmayuda.sqland = "";//and
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
                serop_ini.Text = resultado1.Trim();
                numop_ini.Text = resultado2.Trim();
            }
        }
        #endregion

        #region *** Metodos mantenimiento de datos
        private void limpiar_documento()
        {
            try
            {
                almacaccionid.SelectedIndex = 0;
                fechdocini.Text = "01-01-2013";
                serop_ini.Text = "";
                numop_ini.Text = "";
                serop_fin.Text = "";
                numop_fin.Text = "";
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
            serop_ini.Focus();

            ssModo = "NEW";
        }
        #endregion

        #region *** Controles de usuarios
        private void Frm_reporte_mov_ordprod_Activated(object sender, EventArgs e)
        {

        }
        private void Frm_reporte_mov_ordprod_Load(object sender, EventArgs e)
        {
            EmpresaID = VariablesPublicas.EmpresaID;
            //modulo = VariablesPublicas.Moduloid.Trim();
            //local = VariablesPublicas.Local.Trim();
            PARAMETROS_TABLA();

            data_cbo_tipmov();
            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_buscar.Enabled = true;
            btn_salir.Enabled = true;
        }
        private void Frm_reporte_mov_ordprod_KeyDown(object sender, KeyEventArgs e)
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

        private void serop_ini_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(sender, e);
        }

        private void numop_ini_LostFocus(object sender, System.EventArgs e) {
            
            String numdo = "";
            if (numop_ini.Text.Trim().Length > 0)
            {
                numdo = numop_ini.Text.Trim().PadLeft(10, '0');
            }
            numop_ini.Text = numdo;
            numop_fin.Text = numdo;
        }

        private void numop_ini_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(sender, e);
        }
        private void serop_fin_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(sender, e);
        }


        private void numop_fin_LostFocus(object sender, System.EventArgs e)
        {

            String numdo = "";
            if (numop_fin.Text.Trim().Length > 0)
            {
                numdo = numop_fin.Text.Trim().PadLeft(10, '0');
            }
            numop_fin.Text = numdo;
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
            try
            {
                REPORTES.Frm_reportes miForma = new REPORTES.Frm_reportes();
                miForma.Text = "Reporte por Orden de Produccion";
                miForma.dominioid = dominio.Trim();
                miForma.moduloid = modulo.Trim();
                miForma.local = local.Trim();

                miForma.serop_ini = serop_ini.Text.Trim();
                miForma.numop_ini = numop_ini.Text.Trim();
                miForma.serop_fin = serop_ini.Text.Trim();
                miForma.numop_fin = numop_fin.Text.Trim();
                miForma.fechdocini = fechdocini.Text.Trim().Substring(0, 10);
                miForma.fechdocfin = fechdocfin.Text.Trim().Substring(0, 10);
                if (almacaccionid.SelectedIndex != -1 && almacaccionid.SelectedItem.ToString().Trim().Length > 0)
                    miForma.almacaccionid = almacaccionid.SelectedValue.ToString();

                miForma.formulario = "Frm_reporte_mov_ordprod";
                miForma.Show();
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

        private void serop_ini_TextChanged(object sender, EventArgs e)
        {
            serop_ini.Text = serop_ini.Text.Trim().ToUpper();
            serop_fin.Text = serop_ini.Text;
        }

        private void serop_fin_TextChanged(object sender, EventArgs e)
        {
            serop_fin.Text = serop_fin.Text.Trim().ToUpper();
        }

        #region $$$ grid subgrupo
        #endregion

        #region $$$ busqueda
        #endregion
        #endregion
    }
}