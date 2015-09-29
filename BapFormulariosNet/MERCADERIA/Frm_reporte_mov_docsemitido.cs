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
    public partial class Frm_reporte_mov_docsemitido : plantilla
    {
        /*** variables de cabecera del documento actual ***/
        private String EmpresaID = string.Empty;
        private String dominio = string.Empty;
        private String modulo = string.Empty;
        private String local = string.Empty;
        private String perianio = string.Empty;
        private String perimes = string.Empty;

        
        //String EmpresaID = "";
        //String dominio = "60";
        //String modulo = "";
        //String local = "";
        //String perianio = "";
        //String perimes = "";
        Int32 modcalculo;
        String PERFILID = "";

        Boolean fechadocedit = false;
        Boolean procesado = false;
        Boolean statusDoc = true;

        String ssModo = "NEW";

        public Frm_reporte_mov_docsemitido()
        {
            InitializeComponent();
            ctacte.LostFocus += new System.EventHandler(ctacte_LostFocus);
            mottrasladointid.LostFocus += new System.EventHandler(mottrasladointid_LostFocus);

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
                tipodoc.Enabled = var;
                mottrasladointid.Enabled = var;
                mottrasladointname.Enabled = false;
                ctacte.Enabled = var;
                ctactename.Enabled = false;
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
        void data_cbo_tipodoc()
        {
            try
            {
                modulo_local_tipodocBL BL = new modulo_local_tipodocBL();
                tb_modulo_local_tipodoc BE = new tb_modulo_local_tipodoc();
                BE.dominioid = dominio;
                BE.moduloid = modulo;
                BE.local = local;
                BE.visiblealmac = true;
                BE.status = "";

                tipodoc.DataSource = BL.GetAll_mov(EmpresaID, BE).Tables[0];
                tipodoc.ValueMember = "tipodoc";
                tipodoc.DisplayMember = "tipodocname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        private void ValidaCliente()
        {
            if (ctacte.Text.Trim().Length > 0)
            {
                clienteBL BL = new clienteBL();
                tb_cliente BE = new tb_cliente();
                DataTable dt = new DataTable();

                BE.ctacte = ctacte.Text.Trim().PadLeft(7, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    ctacte.Text = dt.Rows[0]["ctacte"].ToString().Trim();
                    ctactename.Text = dt.Rows[0]["ctactename"].ToString().Trim();
                }
                else
                {
                    ctacte.Text = "";
                    ctactename.Text = "";
                }
            }
        }
        private void ValidaMottrasladoint()
        {
            if (mottrasladointid.Text.Trim().Length > 0)
            {
                tb_mottrasladointBL BL = new tb_mottrasladointBL();
                tb_mottrasladoint BE = new tb_mottrasladoint();
                DataTable dt = new DataTable();

                BE.moduloid = modulo.Trim();
                BE.mottrasladointid = mottrasladointid.Text.Trim().PadLeft(2, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    mottrasladointid.Text = dt.Rows[0]["mottrasladointid"].ToString().Trim();
                    mottrasladointname.Text = dt.Rows[0]["mottrasladointname"].ToString().Trim();
                }
                else
                {
                    mottrasladointid.Text = "";
                    mottrasladointname.Text = "";
                }
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

        private void AyudaClientes(String lpdescrlike)
        {
            try
            {
                Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql"; //sql,tabla
                frmayuda.titulo = "Ayuda Cliente/Proveedor";
                frmayuda.sqlquery = "select ctacte, ctactename, nmruc, direc from tb_cliente";
                frmayuda.sqlinner = ""; //inner
                frmayuda.sqlwhere = "where"; //where
                frmayuda.sqland = "";//and
                frmayuda.criteriosbusqueda = new string[] { "CLIENTE", "RUC", "CODIGO" };
                frmayuda.columbusqueda = "ctactename,nmruc,ctacte";
                frmayuda.returndatos = "0,1";

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
            if (resultado1.Trim().Length > 0)
            {
                ctacte.Text = resultado1.Trim();
                ctactename.Text = resultado2.Trim();
            }
        }

        private void AyudaMottrasladoint(String lpdescrlike)
        {
            try
            {
                Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all"; //sql,tabla
                frmayuda.titulo = "Ayuda Motivo traslado interno";
                frmayuda.sqlquery = "select Mottrasladointid, Mottrasladointname from tb_Mottrasladoint";
                frmayuda.sqlinner = ""; //inner
                frmayuda.sqlwhere = "where moduloid = '" + modulo + "'"; //where
                frmayuda.sqland = "and";//and
                frmayuda.criteriosbusqueda = new string[] { "MOTIVO INTERNO", "CODIGO" };
                frmayuda.columbusqueda = "Mottrasladointname,Mottrasladointid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeMottrasladoint;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }
        private void RecibeMottrasladoint(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                mottrasladointid.Text = resultado1.Trim();
                mottrasladointname.Text = resultado2.Trim();
            }
        }

        #endregion

        #region *** Metodos mantenimiento de datos
        private void limpiar_documento()
        {
            try
            {
                tipodoc.SelectedIndex = -1;

                DateTime fechatemp = DateTime.Today;
                DateTime f1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
                fechdocini.Text = f1.ToString();

                //DateTime f2 = new DateTime(fechatemp.Year, fechatemp.Month + 1, 1).AddDays(-1);
                //fechdocfin.Text = f2.ToString();

                fechdocfin.Value = DateTime.Today;


                serdoc.Text = "";
                mottrasladointid.Text = "";
                mottrasladointname.Text = "";
                ctacte.Text = "";
                ctactename.Text = "";
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
            mottrasladointid.Focus();

            ssModo = "NEW";
        }
        #endregion

        #region *** Controles de usuarios
        private void Frm_reporte_mov_docsemitido_Activated(object sender, EventArgs e)
        {

        }
        private void Frm_reporte_mov_docsemitido_Load(object sender, EventArgs e)
        {
            EmpresaID = VariablesPublicas.EmpresaID.Trim();
            dominio = ((MERCADERIA.MainMercaderia)MdiParent).dominioid;
            modulo = ((MERCADERIA.MainMercaderia)MdiParent).moduloid;
            local = ((MERCADERIA.MainMercaderia)MdiParent).local;
            //PARAMETROS_TABLA();

            data_cbo_tipodoc();
            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_buscar.Enabled = true;
            btn_salir.Enabled = true;

            this.radioListBox1.Items.Clear();
            this.radioListBox1.Items.AddRange("Ingresos - Egresos,Egresos - Ingresos".Split(new char[] { ',' }));
            this.radioListBox1.SelectedIndex = 0;
        }
        private void Frm_reporte_mov_docsemitido_KeyDown(object sender, KeyEventArgs e)
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

        private void serdoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(sender, e);
        }
        private void ctacte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaClientes("");
            }
        }
        private void ctacte_LostFocus(object sender, System.EventArgs e)
        {
            ValidaCliente();
        }
        private void mottrasladointid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaMottrasladoint("");
            }
        }
        private void mottrasladointid_LostFocus(object sender, System.EventArgs e)
        {
            ValidaMottrasladoint();
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
                miForma.Text = "Reporte de Documentos emitidos";
                //
                miForma.dominioid = dominio;
                miForma.moduloid = modulo;
                miForma.local = local;

                if (tipodoc.SelectedIndex != -1 && tipodoc.SelectedItem.ToString().Trim().Length > 0)
                    miForma.tipdoc = tipodoc.SelectedValue.ToString().Trim();
                miForma.mottrasladointid = mottrasladointid.Text.Trim();
                miForma.ctacte = ctacte.Text.Trim();
                miForma.fechdocini = fechdocini.Text.Trim().Substring(0, 10);
                miForma.fechdocfin = fechdocfin.Text.Trim().Substring(0, 10);
                miForma.modcalculo = this.modcalculo;
                miForma.almacaccionid = "";

                miForma.formulario = "Frm_reporte_mov_docsemitido";
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

        private void radioListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            modcalculo = radioListBox1.SelectedIndex;
        }

        
        #region $$$ grid subgrupo
        #endregion

        #region $$$ busqueda
        #endregion
        #endregion
    }
}