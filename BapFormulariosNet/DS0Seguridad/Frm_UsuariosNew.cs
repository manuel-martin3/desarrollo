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

namespace BapFormulariosNet.DS0Seguridad
{
    public partial class Frm_UsuariosNew : plantilla
    {
        /*** variables de cabecera del documento actual ***/
        String EmpresaID = VariablesPublicas.EmpresaID;
        String dominio = VariablesPublicas.Dominioid;
        String modulo = "";
        String local = "";
        String perianio = "";
        String perimes = "";

        String XNIVEL = "";
        String XGLOSA = "";
        String PERFILID = "";

        DataTable Tablausuario;

        Boolean fechadocedit = false;
        Boolean procesado = false;
        Boolean statusDoc = true;

        String ssModo = "";

        Genericas fungen = new Genericas();

        public Frm_UsuariosNew()
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
                usuar.Enabled = !var;
                nombr.Enabled = var;
                clave.Enabled = var;
                clave_2.Enabled = var;
                admin.Enabled = var;
                activo.Enabled = var;

                gridusuario.ReadOnly = true;
                gridusuario.Enabled = !var;

                //btn_nuevo.Enabled = false;
                btn_editar.Enabled = true;
                btn_cancelar.Enabled = false;
                btn_grabar.Enabled = false;
                btn_eliminar.Enabled = false;
                btn_imprimir.Enabled = false;

                btn_primero.Enabled = false;
                btn_anterior.Enabled = false;
                btn_siguiente.Enabled = false;
                btn_ultimo.Enabled = false;

                btn_validar.Enabled = false;
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

                btn_nuevo.Enabled = true;
                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;
                btn_buscar.Enabled = true;
                btn_salir.Enabled = true;

                ssModo = "";
            }
        }
        private void form_cargar_datos(String posicion)
        {
            try
            {
                usuariosBL BL = new usuariosBL();
                tb_usuarios BE = new tb_usuarios();
                DataTable dt = new DataTable();

                BE.usuar = usuar.Text.Trim();
                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    ssModo = "EDIT";
                    limpiar_documento();

                    usuar.Text = dt.Rows[0]["usuar"].ToString().Trim();
                    nombr.Text = dt.Rows[0]["nombr"].ToString().Trim();
                    clave.Text = dt.Rows[0]["clave"].ToString().Trim();
                    if (dt.Rows[0]["admin"].ToString().Trim().Length > 0)
                        admin.Checked = Convert.ToBoolean(dt.Rows[0]["admin"]);
                    if (dt.Rows[0]["activo"].ToString().Trim().Length > 0)
                        activo.Checked = Convert.ToBoolean(dt.Rows[0]["activo"]);


                    String fot = dt.Rows[0]["foto"].ToString();

                    //foto.Image = null;

                    if ((dt.Rows[0]["foto"].ToString()) != "")
                    {
                        foto.Visible = true;
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        byte[] MyData1 = (byte[])(dt.Rows[0]["foto"]);
                        ms.Write(MyData1, 0, MyData1.Length);
                        System.Drawing.Bitmap b = new Bitmap(ms);
                        foto.SizeMode = PictureBoxSizeMode.CenterImage;
                        foto.Image = new System.Drawing.Bitmap(b);
                    }
                    else
                    {
                        foto.Visible = false;
                        foto.ImageLocation = "";
                    }


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
        #region $$$ Llenado de Combobox
        #endregion
        private void Validausuario_nuevo()
        {
            usuariosBL BL = new usuariosBL();
            tb_usuarios BE = new tb_usuarios();
            DataTable dt = new DataTable();

            BE.usuar = usuar.Text.Trim();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];

            if (dt.Rows.Count == 0)
            {
                mensaje.Text = "VALIDO";
                mensaje.ForeColor = Color.Green;
                form_bloqueado(true);
                nombr.Focus();

                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
            }
            else
            {
                mensaje.Text = "YA EXISTE";
                mensaje.ForeColor = Color.Red;
                usuar.Focus();
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

        private void AyudaUsuario(String lpdescrlike)
        {
            try
            {
                Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all"; //sql,tabla
                frmayuda.titulo = "<< AYUDA  TABLA USUARIO >>";
                frmayuda.sqlquery = "SELECT usuar, nombr FROM tb_usuarios";
                frmayuda.sqlinner = ""; //inner
                frmayuda.sqlwhere = "where"; //where
                frmayuda.sqland = "";//and
                frmayuda.criteriosbusqueda = new string[] { "UUSUARIO", "NOMBRE" };
                frmayuda.columbusqueda = "usuar,nombr";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeUsuario;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }
        private void RecibeUsuario(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                usuar.Text = resultado1.Trim();
                form_cargar_datos("");
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
                BE.detalle = usuar.Text.Trim() + "/" + nombr.Text.Trim().ToUpper() + "/" + XGLOSA;

                BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Insert_foto(String xfoto)
        {
            try
            {
                if (xfoto.Trim().Length == 0)
                {
                    MessageBox.Show("No existe foto ?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    usuariosBL BL = new usuariosBL();
                    tb_usuarios BE = new tb_usuarios();
                    BE.usuar = usuar.Text.Trim();
                    //BE.Foto = usuar.Text.Trim() + ".jpg";

                    if (BL.Update_modificarfoto(EmpresaID, BE))
                    {
                        MessageBox.Show("Foto Grabados con Exito ...", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Contacte con sistemas !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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
                usuar.Text = "";
                nombr.Text = "";
                clave.Text = "";
                clave_2.Text = "";
                admin.Checked = false;
                activo.Checked = false;
                mensaje.Text = "";
                foto.ResetText();
                foto.Image = null;

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
            usuar.Focus();

            btn_validar.Enabled = true;
            btn_cancelar.Enabled = true;
        }
        private void Insert()
        {
            try
            {
                if (usuar.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (nombr.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Nombre de Usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (clave.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Tu Clave ?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (clave_2.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Confirmación de Tú Clave ?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (clave.Text.Trim() != clave_2.Text.Trim())
                {
                    MessageBox.Show("No Coinciden las Claves !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    String primero = "";
                    String segundo = "";
                    usuariosBL BL = new usuariosBL();
                    tb_usuarios BE = new tb_usuarios();

                    primero = fungen.GetMD5(clave.Text.Trim().ToLower()).Substring(0, 10).ToUpper();
                    segundo = fungen.GetMD5(clave_2.Text.Trim().ToLower()).Substring(0, 10).ToUpper();

                    if (primero == segundo)
                    {
                        BE.usuar = usuar.Text.Trim();
                        BE.nombr = nombr.Text.Trim().ToUpper();
                        BE.clave = primero.Trim();
                        BE.admin = admin.Checked;
                        BE.activo = activo.Checked;

                        // Asignando el valor de la imagen

                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        if (foto.Image != null)
                        {
                            foto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        BE.Foto = ms.GetBuffer();


                        if (BL.Insert(EmpresaID, BE))
                        {
                            MessageBox.Show("Datos grabados correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            procesado = true;
                        }
                        else
                        {
                            MessageBox.Show("Contáctese con Sistemas !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al Crear Clave", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
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
                if (usuar.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (nombr.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Nombre de Usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (clave.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Tu Clave ?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (clave_2.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Confirmación de Tú Clave ?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (clave.Text.Trim() != clave_2.Text.Trim())
                {
                    MessageBox.Show("No Coinciden las Claves !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    String primero = "";
                    String segundo = "";
                    usuariosBL BL = new usuariosBL();
                    tb_usuarios BE = new tb_usuarios();

                    primero = fungen.GetMD5(clave.Text.Trim().ToLower()).Substring(0, 10).ToUpper();
                    segundo = fungen.GetMD5(clave_2.Text.Trim().ToLower()).Substring(0, 10).ToUpper();

                    if (primero == segundo)
                    {
                        BE.usuar = usuar.Text.Trim();
                        BE.nombr = nombr.Text.Trim().ToUpper();
                        BE.clave = primero.Trim();
                        BE.admin = admin.Checked;
                        BE.activo = activo.Checked;

                        // Asignando el valor de la imagen

                        // Stream usado como buffer
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        // Se guarda la imagen en el buffer
                        if (foto.Image != null)
                        {
                            foto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        // Se extraen los bytes del buffer para asignarlos como valor para el parámetro.
                        BE.Foto = ms.GetBuffer();

                        if (BL.Update(EmpresaID, BE))
                        {
                            SEGURIDAD_LOG("M");
                            MessageBox.Show("Datos modificado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            procesado = true;
                        }
                        else
                        {
                            MessageBox.Show("Contáctese con Sistemas !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al Crear Clave", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
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
                if (usuar.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (nombr.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Nombre de Usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    usuariosBL BL = new usuariosBL();
                    tb_usuarios BE = new tb_usuarios();

                    BE.usuar = usuar.Text.Trim();

                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos Eliminado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        data_Tablausuario();
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region *** Controles de usuarios
        private void Frm_usuarios_Activated(object sender, EventArgs e)
        {

        }
        private void Frm_usuarios_Load(object sender, EventArgs e)
        {

            modulo = ((DS0Seguridad.MainSeguridad)MdiParent).moduloid;
            local = ((DS0Seguridad.MainSeguridad)MdiParent).moduloid;
            PERFILID = ((DS0Seguridad.MainSeguridad)MdiParent).perfil;

            NIVEL_FORMS();

            Tablausuario = new DataTable();
            data_Tablausuario();

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
        private void Frm_usuarios_KeyDown(object sender, KeyEventArgs e)
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
            { }

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

        private void usuar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaUsuario("");
            }

        }
        private void btn_validar_Click(object sender, EventArgs e)
        {
            if (ssModo == "NEW")
            {
                Validausuario_nuevo();
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
            if (XNIVEL == "0" || XNIVEL == "1")
            {
                if (usuar.Text.Trim().Length > 0)
                {
                    ssModo = "EDIT";

                    form_bloqueado(true);
                    nombr.Focus();

                    btn_cancelar.Enabled = true;
                    btn_grabar.Enabled = true;
                    btn_eliminar.Enabled = true;
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
                data_Tablausuario();
                form_bloqueado(false);

                btn_nuevo.Enabled = true;

                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;

                btn_buscar.Enabled = true;
                btn_salir.Enabled = true;
            }
        }
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0")
            {
                bool sw_prosigue = false;
                sw_prosigue = (MessageBox.Show("¿Desea Eliminar Usuario actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

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
                if (Tablausuario.Rows.Count > 0)
                {
                    //REPORTES.Frm_reportes miForma = new REPORTES.Frm_reportes();

                    //miForma.usuar = usuario.Trim();
                    //miForma.moduloid = modulo.Trim();
                    //miForma.local = local.Trim();

                    //miForma.Text = "Reporte de subgrupos";
                    //miForma.formulario = "Frm_usuarios";
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

                            foto.Visible = true;
                            foto.Image = originalImage;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        #region $$$ grid usuarios
        private void data_Tablausuario()
        {
            try
            {
                if (Tablausuario != null)
                    Tablausuario.Rows.Clear();
                usuariosBL BL = new usuariosBL();
                tb_usuarios BE = new tb_usuarios();

                Tablausuario = BL.GetAll(EmpresaID, BE).Tables[0];
                if (Tablausuario.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    gridusuario.DataSource = Tablausuario;
                    gridusuario.Rows[0].Selected = false;
                    gridusuario.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridusuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridusuario.CurrentRow != null)
                {
                    String xusuar = "";
                    xusuar = gridusuario.Rows[e.RowIndex].Cells["gusuar"].Value.ToString().Trim();
                    data_tipodoc(xusuar);
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void gridusuario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                String xusuar = "";
                xusuar = gridusuario.Rows[gridusuario.CurrentRow.Index].Cells["gusuar"].Value.ToString().Trim();
                data_tipodoc(xusuar);
            }
        }
        private void gridusuario_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridusuario[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            gridusuario[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            gridusuario.EnableHeadersVisualStyles = false;
            gridusuario.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            gridusuario.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void gridusuario_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //gridusuario[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }

        private void data_tipodoc(String xusuar)
        {
            form_bloqueado(false);
            DataRow[] rowtipodoc = Tablausuario.Select("usuar='" + xusuar.Trim() + "'");
            if (rowtipodoc.Length > 0)
            {
                foreach (DataRow row in rowtipodoc)
                {
                    ssModo = "EDIT";
                    limpiar_documento();

                    usuar.Text = row["usuar"].ToString().Trim();
                    nombr.Text = row["nombr"].ToString().Trim();
                    clave.Text = row["clave"].ToString().Trim();
                    if (row["admin"].ToString().Trim().Length > 0)
                        admin.Checked = Convert.ToBoolean(row["admin"]);
                    if (row["activo"].ToString().Trim().Length > 0)
                        activo.Checked = Convert.ToBoolean(row["activo"]);

                    String fot = row["foto"].ToString();

                    if ((row["foto"].ToString()) != "")
                    {
                        foto.Visible = true;
                        foto.Image = null;
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        byte[] MyData1 = (byte[])(row["foto"]);
                        ms.Write(MyData1, 0, MyData1.Length);
                        System.Drawing.Bitmap b = new Bitmap(ms);
                        foto.SizeMode = PictureBoxSizeMode.StretchImage;

                        foto.Image = new System.Drawing.Bitmap(b);
                    }
                    else
                    {
                        foto.Visible = false;
                        foto.ImageLocation = "";
                    }

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
        #endregion

        private void txtbusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_busqueda.PerformClick();
            }

        }

        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            tb_usuarios BE = new tb_usuarios();
            usuariosBL BL = new usuariosBL();
            BE.nombr = txtbusqueda.Text.ToString().Trim();
            Tablausuario = BL.BuscarUsuarios(VariablesPublicas.EmpresaID, BE).Tables[0];
            if (Tablausuario.Rows.Count > 0)
            {
                gridusuario.DataSource = Tablausuario;
            }
        }            

        #endregion
    }
}