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
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.Net.Sockets;

namespace BapFormulariosNet.DS0Seguridad
{
    public partial class Frm_sys_local : plantilla
    {
        /*** variables de cabecera del documento actual ***/
        String EmpresaID = VariablesPublicas.EmpresaID;
        String dominio = "";
        String modulo = "";
        String local = "";
        String perianio = "";
        String perimes = "";

        String XNIVEL = "";
        String XGLOSA = "";
        String PERFILID = "";

        DataTable Tablamodulo;

        Boolean fechadocedit = false;
        Boolean procesado = false;
        Boolean statusDoc = true;

        String ssModo = "";
        String ssModoDET = "";
        String xNmruc = "";
        String xLocalDirec = "";


        public Frm_sys_local()
        {
            InitializeComponent();
        }

        #region $$$ ADMINISTRADOR
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
        private void form_bloqueado(Boolean var)
        {
            try
            {
                dominioid.Enabled = var;
                dominioname.Enabled = false;
                item.Enabled = false;
                localname.Enabled = var;
    
                direcnume.Enabled = var;
                moduloid.Enabled = var;
                ctacte.Enabled = var;
                moduloname.Enabled = false;
                ctactename.Enabled = false;
                canalventaid.Enabled = var;
                dgb_local.ReadOnly = true;
               // dgb_local.Enabled = !var;

                email.Enabled = var;
                rpc.Enabled = var;
                telf.Enabled = var;
                estabsunat.Enabled = var;


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
                item.Text = "";
                btn_nuevo.Enabled = true;
                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;
                btn_salir.Enabled = true;

                ssModo = "";
            }
        }
        private void form_cargar_datos(String posicion)
        {
            try
            {
                sys_moduloBL BL = new sys_moduloBL();
                tb_sys_modulo BE = new tb_sys_modulo();
                DataTable dt = new DataTable();

                BE.dominioid = dominioid.Text.Trim();
                BE.moduloid = item.Text.Trim();
                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    ssModo = "EDIT";
                    limpiar_documento();
                    dominioid.Text = dt.Rows[0]["dominioid"].ToString().Trim();
                    dominioname.Text = dt.Rows[0]["dominioname"].ToString().Trim();
                    item.Text = dt.Rows[0]["moduloid"].ToString().Trim();
                    localname.Text = dt.Rows[0]["moduloname"].ToString().Trim();
                    //moduloshort.Text = dt.Rows[0]["moduloshort"].ToString().Trim();

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
        #region $$$ Llenado de Combobox
        #endregion

        private void ValidaDominio()
        {
            if (dominioid.Text.Trim().Length > 0)
            {
                sys_dominioBL BL = new sys_dominioBL();
                tb_sys_dominio BE = new tb_sys_dominio();
                DataTable dt = new DataTable();

                BE.dominioid = dominioid.Text.Trim().PadLeft(2, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    dominioid.Text = dt.Rows[0]["dominioid"].ToString().Trim();
                    dominioname.Text = dt.Rows[0]["dominioname"].ToString().Trim();
                }
                else
                {
                    dominioid.Text = "";
                    dominioname.Text = "";
                }
            }
            else
            {
                dominioid.Text = "";
                dominioname.Text = "";
            }
        }



        private void ValidaModulo()
        {
            if (dominioid.Text.Trim().Length > 0)
            {
                sys_moduloBL BL = new sys_moduloBL();
                tb_sys_modulo BE = new tb_sys_modulo();
                DataTable dt = new DataTable();

                BE.moduloid = moduloid.Text.Trim();

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    moduloid.Text = dt.Rows[0]["moduloid"].ToString().Trim();
                    moduloname.Text = dt.Rows[0]["moduloname"].ToString().Trim();
                }
                else
                {
                    moduloid.Text = "";
                    moduloname.Text = "";
                }
            }
            else
            {
                moduloid.Text = "";
                moduloname.Text = "";
            }
        }



        private void ValidaCliente()
        {
            if (dominioid.Text.Trim().Length > 0)
            {
                clienteBL BL = new clienteBL();
                tb_cliente BE = new tb_cliente();

                DataTable dt = new DataTable();

                String cta = ctacte.Text.Trim().PadLeft(7, '0');
                BE.ctacte = cta.ToString();
                ctacte.Text = cta.ToString();

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    ctacte.Text = dt.Rows[0]["ctacte"].ToString().Trim();
                    xNmruc = dt.Rows[0]["nmruc"].ToString().Trim();
                    xLocalDirec = dt.Rows[0]["localdirec"].ToString().Trim();
                    ctactename.Text = dt.Rows[0]["ctactename"].ToString().Trim();
                    direcnume.Text = dt.Rows[0]["direcnume"].ToString().Trim();   
                }
                else
                {
                    ctacte.Text = "";
                    xNmruc = "";
                    xLocalDirec = "";
                    ctactename.Text = "";
                    direcnume.Text = "";
                }
            }
            else
            {
                ctacte.Text = "";
                xNmruc = "";
                xLocalDirec = "";
                ctactename.Text = "";
                direcnume.Text = "";
            }
        }


        private void Validamodulo_nuevo()
        {
            //if (dominioid.Text.Trim().Length == 2)
            //{
            //    sys_moduloBL BL = new sys_moduloBL();
            //    tb_sys_modulo BE = new tb_sys_modulo();
            //    DataTable dt = new DataTable();
            //    BE.dominioid = dominioid.Text.Trim();
            //    BE.moduloid = moduloid.Text.Trim();
            //    dt = BL.GetAll(EmpresaID, BE).Tables[0];

            //    if (dt.Rows.Count == 0)
            //    {
            //        mensaje.Text = "VALIDO";
            //        mensaje.ForeColor = Color.Green;
            //        form_bloqueado(true);
            //        localname.Focus();

            //        btn_cancelar.Enabled = true;
            //        btn_grabar.Enabled = true;
            //    }
            //    else
            //    {
            //        mensaje.Text = "YA EXISTE";
            //        mensaje.ForeColor = Color.Red;
            //        moduloid.Focus();
            //    }
            //}
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



        private void AyudaDominio(String lpdescrlike)
        {
            try
            {
                Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all"; //sql,tabla
                frmayuda.titulo = "<< AYUDA  TABLA DOMINIO >>";
                frmayuda.sqlquery = "SELECT dominioid, dominioname FROM tb_sys_dominio";
                frmayuda.sqlinner = ""; //inner
                frmayuda.sqlwhere = "where"; //where
                frmayuda.sqland = "";//and
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
                //data_Tablamodulo();
            }
        }

        private void Ayudamodulo(String lpdescrlike)
        {
            try
            {
                Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all"; //sql,tabla
                frmayuda.titulo = "<< AYUDA  TABLA modulo >>";
                frmayuda.sqlquery = "SELECT moduloid, moduloname, moduloshort FROM tb_sys_modulo";
                frmayuda.sqlinner = ""; //inner
                frmayuda.sqlwhere = "where"; //where
                frmayuda.sqland = "";//and
                frmayuda.criteriosbusqueda = new string[] { "modulo", "CODIGO" };
                frmayuda.columbusqueda = "moduloname,moduloid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = Recibemodulo;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }


        private void Recibemodulo(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {               
                moduloid.Text = resultado1.Trim();
                moduloname.Text = resultado2.ToString();
            }
        }


        #endregion

        #region *** Metodos mantenimiento de datos
        private void SEGURIDAD_LOG(String accion)
        {
            String xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio;
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
                BE.detalle = dominioid.Text.Trim() + moduloid.Text.Trim() + "/" + localname.Text.Trim().ToUpper() + "/" + XGLOSA;

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
               dominioid.Text = "";
               dominioname.Text = "";
               item.Text = "";
               
               moduloid.Text = "";
               moduloname.Text = "";
               ctacte.Text = "";
               ctactename.Text = "";
               direcnume.Text = "";
               localname.Text = "";
               mensaje.Text = "";
               canalventaname.Text = "";
               canalventaid.Text = "";
               xNmruc = "";
               xLocalDirec = "";

               email.Text = "";                    
               rpc.Text = "";
               telf.Text = "";
               estabsunat.Text = "";
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
            form_bloqueado(true);
            dominioid.Focus();
            btn_grabar.Enabled = true;
            btn_cancelar.Enabled = true;
        }


        private void Insert()
        {
            try
            {
                if (dominioid.Text == "")
                {
                    MessageBox.Show("Ingrese Código de Dominio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (moduloid.Text == "")
                {
                    MessageBox.Show("Ingrese Código de modulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //else if (direcnume.Text == "")
                //{
                //    MessageBox.Show("Ingrese Codigo de Local", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                else
                {
                    sys_localBL BL = new sys_localBL();
                    tb_sys_local BE = new tb_sys_local();

                    BE.dominioid = dominioid.Text.Trim();
                    BE.moduloid = moduloid.Text.Trim();
                    BE.local = item.Text.ToString();
                    BE.localname = localname.Text.ToString();
                    BE.usuar = VariablesPublicas.Usuar.Trim().ToString();
                    BE.ctacte = ctacte.Text.ToString();
                    BE.direcnume = direcnume.Text.ToString();
                    BE.nmruc = xNmruc.ToString();
                    BE.localdirec = xLocalDirec.ToString();
                    BE.ctactename = ctactename.Text.ToString();
                    BE.canalventaid = canalventaid.Text.ToString();
                    BE.status = "0";

                    // Informacion                     
                    if (email_bien_escrito(email.Text.ToString()))
                    {
                        BE.email = email.Text.ToString();
                    }
                    else { MessageBox.Show("Correo en Formato Incorrecto"); return; }

                    BE.rpc = rpc.Text.ToString();
                    BE.telf = telf.Text.ToString();
                    BE.estabsunat = estabsunat.Text.ToString();
                    
                    if (BL.Insert(EmpresaID, BE))
                    {
                        MessageBox.Show("Datos grabados correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        procesado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Boolean email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void Update()
        {
            try
            {
                if (dominioid.Text == "")
                {
                    MessageBox.Show("Ingrese Código de Dominio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (moduloid.Text == "")
                {
                    MessageBox.Show("Ingrese Código de modulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //else if (direcnume.Text == "")
                //{
                //    MessageBox.Show("Ingrese Codigo de Local", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                else
                {
                    sys_localBL BL = new sys_localBL();
                    tb_sys_local BE = new tb_sys_local();

                    BE.dominioid = dominioid.Text.Trim();
                    BE.moduloid = moduloid.Text.Trim();
                    BE.local = item.Text.ToString();
                    BE.localname = localname.Text.ToString();
                    BE.usuar = VariablesPublicas.Usuar.Trim().ToString();
                    BE.ctacte = ctacte.Text.ToString();
                    BE.direcnume = direcnume.Text.ToString();
                    BE.nmruc = xNmruc.ToString();
                    BE.localdirec = xLocalDirec.ToString();
                    BE.ctactename = ctactename.Text.ToString();
                    BE.canalventaid = canalventaid.Text.ToString();
                    BE.status = "0";

                    // Informacion 
                    if (email_bien_escrito(email.Text.ToString()))
                    {
                        BE.email = email.Text.ToString();
                    }
                    else { MessageBox.Show("Correo en Formato Incorrecto"); return; }
                    BE.rpc = rpc.Text.ToString();
                    BE.telf = telf.Text.ToString();
                    BE.estabsunat = estabsunat.Text.ToString();

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
                if (dominioid.Text.Trim().Length != 2)
                {
                    MessageBox.Show("Ingrese Código de Dominio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (item.Text.Trim().Length != 4)
                {
                    MessageBox.Show("Ingrese Código de modulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    sys_localBL BL = new sys_localBL();
                    tb_sys_local BE = new tb_sys_local();

                    BE.dominioid = dominioid.Text.Trim();
                    BE.moduloid = moduloid.Text.Trim();
                    BE.local = item.Text.ToString();                  

                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos Eliminado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        data_Tablamodulo();
                        limpiar_documento();
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
        #endregion

        #region *** Controles de usuarios
       
        private void Frm_sys_local_Load(object sender, EventArgs e)
        {
            dominio = ((DS0Seguridad.MainSeguridad)MdiParent).dominioid;
            modulo = ((DS0Seguridad.MainSeguridad)MdiParent).moduloid;
            local = ((DS0Seguridad.MainSeguridad)MdiParent).moduloid;
            PERFILID = ((DS0Seguridad.MainSeguridad)MdiParent).perfil;

            NIVEL_FORMS();

            Tablamodulo = new DataTable();
            data_Tablamodulo();

            limpiar_documento();
            form_bloqueado(false);

            btn_nuevo.Enabled = true;
            btn_primero.Enabled = true;
            btn_anterior.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_ultimo.Enabled = true;
            btn_salir.Enabled = true;
        }
        private void Frm_sys_modulo_KeyDown(object sender, KeyEventArgs e)
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
                if (item.Text.Trim().Length == 3)
                {
                    ssModo = "EDIT";

                    form_bloqueado(true);
                    localname.Focus();

                    btn_cancelar.Enabled = true;
                    btn_grabar.Enabled = true;
                    btn_agregar.Enabled = false;
                    ctacte.Enabled = false;
                }
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
                data_Tablamodulo();
                form_bloqueado(false);

                btn_nuevo.Enabled = true;
                btn_eliminar.Enabled = true;

                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;
                btn_salir.Enabled = true;
                btn_agregar.Enabled = true;
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
                if (Tablamodulo.Rows.Count > 0)
                {
                    //REPORTES.Frm_reportes miForma = new REPORTES.Frm_reportes();

                    //miForma.moduloid = modulo.Trim();
                    //miForma.moduloid = modulo.Trim();
                    //miForma.local = local.Trim();

                    //miForma.Text = "Reporte de subgrupos";
                    //miForma.formulario = "Frm_sys_modulo";
                    //miForma.ShowDialog();
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
            Seguridadlog.FrmSeguridad oform = new Seguridadlog.FrmSeguridad();
            String xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio;
            oform._Nombre = Name;
            oform._ClaveForm = xclave;
            oform.Owner = this;
            oform.ShowDialog();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region $$$ grid subgrupo
        private void data_Tablamodulo()
        {
            try
            {
                if (Tablamodulo != null)

                    Tablamodulo.Rows.Clear();

                sys_localBL BL = new sys_localBL();
                tb_sys_local BE = new tb_sys_local();

                BE.dominioid = dominio.ToString();
                BE.moduloid = modulo.ToString(); ;

                Tablamodulo = BL.GetAll(EmpresaID, BE).Tables[0];

                if (Tablamodulo.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    dgb_local.DataSource = Tablamodulo;
                    dgb_local.Rows[0].Selected = false;
                    dgb_local.Focus();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgb_local_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgb_local.CurrentRow != null)
                {
                    String xdominioid = "", xmoduloid = "";
                    String xlocal = "",xlocid = "";
                    xdominioid = dgb_local.Rows[e.RowIndex].Cells["gdominioid"].Value.ToString().Trim();
                    xmoduloid = dgb_local.Rows[e.RowIndex].Cells["gmoduloid"].Value.ToString().Trim();
                    xlocal = dgb_local.Rows[e.RowIndex].Cells["loc"].Value.ToString().Trim();
                    data_tipodoc(xdominioid, xmoduloid, xlocal);
                }
            }
            catch (Exception ex)
            {

            }

        }



        private void dgb_local_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                String xdominioid = "", xmoduloid = "";
                String xlocal = "", xlocid = "";
                xdominioid = dgb_local.Rows[dgb_local.CurrentRow.Index].Cells["gdominioid"].Value.ToString().Trim();
                xmoduloid = dgb_local.Rows[dgb_local.CurrentRow.Index].Cells["gmoduloid"].Value.ToString().Trim();
                xlocal = dgb_local.Rows[dgb_local.CurrentRow.Index].Cells["loc"].Value.ToString().Trim();
                data_tipodoc(xdominioid, xmoduloid, xlocal);
            }
        }

        private void dgb_local_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgb_local[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            dgb_local[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            dgb_local.EnableHeadersVisualStyles = false;
            dgb_local.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            dgb_local.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void dgb_local_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //dgb_local[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }

        private void data_tipodoc(String xdominioid, String xmoduloid, String xlocal)
        {
            form_bloqueado(false);
            DataRow[] rowtipodoc = Tablamodulo.Select("dominioid = '" + xdominioid.Trim() + "' and moduloid='" + xmoduloid.Trim() + "' and local = '"+ xlocal.Trim() +"'");
            if (rowtipodoc.Length > 0)
            {
                foreach (DataRow row in rowtipodoc)
                {
                    ssModo = "EDIT";
                    limpiar_documento();

                    dominioid.Text = row["dominioid"].ToString().Trim();
                    dominioname.Text = row["dominioname"].ToString().Trim();
                    moduloid.Text = row["moduloid"].ToString().Trim();
                    moduloname.Text = row["moduloname"].ToString().Trim();
                    ctacte.Text = row["ctacte"].ToString().Trim();
                    ctactename.Text = row["ctactename"].ToString().Trim();
                    direcnume.Text = row["direcnume"].ToString().Trim();
                    localname.Text = row["localname"].ToString().Trim();
                    item.Text = row["local"].ToString().Trim();

                    canalventaid.Text = row["canalventaid"].ToString().Trim();
                    canalventaname.Text = row["canalventaname"].ToString().Trim();

                    xNmruc = row["nmruc"].ToString();
                    xLocalDirec = row["localdirec"].ToString();

                    estabsunat.Text = row["estabsunat"].ToString().Trim();
                    email.Text = row["email"].ToString().Trim();
                    telf.Text = row["telef"].ToString().Trim();
                    rpc.Text = row["rpc"].ToString().Trim();
                    
                }


                btn_nuevo.Enabled = true;
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
        #endregion

        private void ctacte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaCliente("");

                // Despues de Que Vuelva del F1

                ValidaCliente();

                sys_localBL BL = new sys_localBL();
                tb_sys_local BE = new tb_sys_local();

                DataTable dt = new DataTable();

                BE.ctacte = ctacte.Text.ToString();
                dt = BL.GenCodigo(EmpresaID, BE).Tables[0];
                item.Text = dt.Rows[0]["item"].ToString().PadLeft(3, '0');
                direcnume.Focus();
            }

            if (e.KeyCode == Keys.Enter)
            {
                // Primero Validar 
                ValidaCliente();

                sys_localBL BL = new sys_localBL();
                tb_sys_local BE = new tb_sys_local();

                DataTable dt = new DataTable();

                BE.ctacte = ctacte.Text.ToString();
                dt = BL.GenCodigo(EmpresaID, BE).Tables[0];
                item.Text = dt.Rows[0]["item"].ToString().PadLeft(3, '0');
                direcnume.Focus();
            }

        }

        private void dominioid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaDominio("");
            }

            if (e.KeyCode == Keys.Enter) {
                ValidaDominio();
                moduloid.Focus();
            }            
        }

        private void moduloid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Ayudamodulo("");
            }

            if (e.KeyCode == Keys.Enter)
            {
                ValidaModulo();
                ctacte.Focus();
            }


        }


        private void AyudaCliente(String lpdescrlike)
        {
            try
            {
                String modd = "";
                sys_moduloBL BL = new sys_moduloBL();
                tb_sys_modulo BE = new tb_sys_modulo();
                DataTable dt = new DataTable();

                BE.dominioid = dominioid.Text.ToString();
                BE.moduloid = moduloid.Text.ToString();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();

                        Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                        frmayuda.tipoo = "sql"; //sql,tabla
                        frmayuda.titulo = "<< AYUDA TABLA GRUPOS >>";
                        frmayuda.sqlquery = " SELECT ctacte, ctactename ,nmruc  FROM tb_cliente ";
                        frmayuda.sqlinner = ""; //inner
                        frmayuda.sqlwhere = " where "; //where
                        frmayuda.sqland = "";//and
                        frmayuda.criteriosbusqueda = new string[] { "PROVEEDOR", "CODIGO" };
                        frmayuda.columbusqueda = "ctactename,ctacte";
                        frmayuda.returndatos = "0,1,2";

                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeCliente;
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void RecibeCliente(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                ctacte.Text = resultado1.Trim();
                ctactename.Text = resultado2.Trim();
                xNmruc = resultado3.Trim();
            }
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            direcnume.Text = "";
            localname.Text = "";
            direcnume.Enabled = true;
            canalventaid.Enabled = true;
            btn_cancelar.Enabled = true;
            btn_nuevo.Enabled = false;
            btn_editar.Enabled = false;
            sys_localBL BL = new sys_localBL();
            tb_sys_local BE = new tb_sys_local();

            DataTable dt = new DataTable();

            if (ctacte.Text == "")
            {
                MessageBox.Show("No Existe la Cuenta Corriente Para Generar el Item !!!");
                return;
            }

            BE.ctacte = ctacte.Text.ToString();
            dt = BL.GenCodigo(EmpresaID, BE).Tables[0];
            item.Text = dt.Rows[0]["item"].ToString().PadLeft(3, '0');
            ssModo = "NEW";
            btn_grabar.Enabled = true;
            estabsunat.Enabled = true;
            telf.Enabled = true;
            rpc.Enabled = true;
            email.Enabled = true;
            direcnume.Focus();
   
        }

        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            sys_localBL BL = new sys_localBL();
            tb_sys_local BE = new tb_sys_local();

            DataTable dt = new DataTable();
           
            //BE.dominioid = dominioid.Text.Trim();
            //BE.moduloid = moduloid.Text.Trim();
            BE.localname = txt_busqueda.Text.ToString();

            dt = BL.GetAll(EmpresaID, BE).Tables[0];

            if (dt.Rows.Count > 0)
            {
                dgb_local.DataSource = dt;
            }

        }

        private void txt_busqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_busqueda_Click(sender,e);    
            }
        }

        private void direcnume_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaClientesDireccion("");
            }
        }

        private void AyudaClientesDireccion(String lpdescrlike)
        {
            try
            {
                Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all"; 
                frmayuda.titulo = "Ayuda Dirección";
                frmayuda.sqlquery = "select direcnume, direcname, direcdeta from tb_cliente_direc";
                frmayuda.sqlinner = ""; 
                frmayuda.sqlwhere = "where ctacte = '" + ctacte.Text.Trim() + "'"; 
                frmayuda.sqland = "and";
                frmayuda.criteriosbusqueda = new string[] { "NOM DIRECCIÓN", "DIRECCIÓN" };
                frmayuda.columbusqueda = "direcname,direcdeta";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeClientesDireccion;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        private void RecibeClientesDireccion(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                direcnume.Text = resultado1.Trim();
                localname.Text = resultado2.Trim();
                //direcdeta.Text = resultado3.Trim();
            }
        }

        private void estabsunat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                email.Focus();    
            }
        }

        private void email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                telf.Focus();
            }
        }

        private void telf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                rpc.Focus();
            }
        }

        private void txt_busqueda_KeyUp(object sender, KeyEventArgs e)
        {
            btn_busqueda_Click(sender, e);
        }

        private void canalventaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaCanalVenta("");
            }
        }


        private void AyudaCanalVenta(String lpdescrlike)
        {
            try
            {
                Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all"; //sql,tabla
                frmayuda.titulo = "<< AYUDA TABLA CANAL VENTA >>";
                frmayuda.sqlquery = "SELECT canalventaid,canalventaname FROM tb_cp_canalventa ";
                frmayuda.sqlinner = ""; //inner
                frmayuda.sqlwhere = "WHERE LEN(canalventaid) = 3"; //where
                frmayuda.sqland = "and";//and
                frmayuda.criteriosbusqueda = new string[] { "CODIGO", "CANAL" };
                frmayuda.columbusqueda = "canalventaid,canalventaname";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeCanalVenta;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }


        private void RecibeCanalVenta(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                canalventaid.Text = resultado1.Trim();
                canalventaname.Text = resultado2.Trim();
                //data_Tablamodulo();
            }
        }
       
        #endregion
    }
}