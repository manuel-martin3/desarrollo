using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

using System.IO;

namespace BapFormulariosNet.DS0Seguridad
{
    public partial class Frm_usuarios_panel : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private Boolean procesado = false;

        private String ssModo = string.Empty;

        private Genericas fungen = new Genericas();

        public Frm_usuarios_panel()
        {
            InitializeComponent();
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

        private void form_bloqueado(Boolean var)
        {
            try
            {
                usuar.Enabled = false;
                nombr.Enabled = false;
                clave.Enabled = var;
                clave_nuevo.Enabled = var;
                clave_nuevo2.Enabled = var;

                btn_editar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_grabar.Enabled = false;

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
                form_cargar_datos(string.Empty);
                form_bloqueado(false);
                btn_editar.Enabled = true;
                btn_salir.Enabled = true;

                ssModo = string.Empty;
            }
        }
        private void form_cargar_datos(String posicion)
        {
            try
            {
                var BL = new usuariosBL();
                var BE = new tb_usuarios();
                var dt = new DataTable();

                BE.usuar = VariablesPublicas.Usuar.Trim();

                dt = BL.GetAll(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    ssModo = "EDIT";
                    limpiar_documento();
                    usuar.Text = dt.Rows[0]["usuar"].ToString().Trim();
                    nombr.Text = dt.Rows[0]["nombr"].ToString().Trim();
                    dt.Rows[0]["foto"].ToString();

                    if ((dt.Rows[0]["foto"].ToString()) != string.Empty)
                    {
                        foto.Visible = true;
                        var ms = new System.IO.MemoryStream();
                        var MyData1 = (byte[])(dt.Rows[0]["foto"]);
                        ms.Write(MyData1, 0, MyData1.Length);
                        var b = new Bitmap(ms);
                        foto.SizeMode = PictureBoxSizeMode.CenterImage;
                        foto.Image = new System.Drawing.Bitmap(b);
                    }
                    else
                    {
                        foto.Visible = false;
                        foto.ImageLocation = string.Empty;
                    }

                    btn_editar.Enabled = true;
                    btn_log.Enabled = true;
                    btn_salir.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void imagen()
        {
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
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData )
        {
            if (keyData == Keys.Enter)
            {
                if (GetNextControl(ActiveControl, true) != null)
                {
                    SendKeys.Send("\t");
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
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
                BE.detalle = usuar.Text.Trim() + " | " + nombr.Text.Trim().ToUpper() + " | " + XGLOSA;

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
                usuar.Text = string.Empty;
                nombr.Text = string.Empty;
                clave.Text = string.Empty;
                clave_nuevo.Text = string.Empty;
                clave_nuevo2.Text = string.Empty;
                foto.ResetText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void nuevo()
        {
            form_bloqueado(false);
            form_cargar_datos(string.Empty);
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
                    var BL = new usuariosBL();
                    var BE = new tb_usuarios();
                    BE.usuar = usuar.Text.Trim();

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
        private void Insert()
        {
        }
        private void Update()
        {
            try
            {
                if (clave.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Tu Clave ?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (clave_nuevo.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese Tú Nueva Clave ?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (clave_nuevo2.Text.Trim().Length == 0)
                        {
                            MessageBox.Show("Ingrese Confirmación de Tú Nueva Clave ?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            if (clave_nuevo.Text.Trim() != clave_nuevo2.Text.Trim())
                            {
                                MessageBox.Show("No Coincide Tú Nueva Clave !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                var xClave = string.Empty;
                                var primero = string.Empty;
                                var segundo = string.Empty;

                                var BL = new usuariosBL();
                                var BE = new tb_usuarios();
                                var dt = new DataTable();

                                BE.usuar = usuar.Text.Trim().ToLower();
                                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                                if (dt.Rows.Count > 0)
                                {
                                    xClave = dt.Rows[0]["clave"].ToString().ToUpper();
                                }
                                else
                                {
                                    xClave = "ERROR";
                                }

                                clave.Text = fungen.GetMD5(clave.Text.ToLower()).Substring(0, 10);

                                if (clave.Text.ToUpper() == xClave)
                                {
                                    primero = fungen.GetMD5(clave_nuevo.Text.Trim().ToLower()).Substring(0, 10).ToUpper();
                                    segundo = fungen.GetMD5(clave_nuevo2.Text.Trim().ToLower()).Substring(0, 10).ToUpper();

                                    if (primero == segundo)
                                    {
                                        var BL2 = new usuariosBL();
                                        var BE2 = new tb_usuarios();

                                        BE2.usuar = usuar.Text.Trim();
                                        BE2.clave = primero.Trim();
                                        if (BL2.Update_modificarclave(EmpresaID, BE2))
                                        {
                                            SEGURIDAD_LOG("M");
                                            MessageBox.Show("Clave modificado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                        MessageBox.Show("Error al generar  Nueva Clave !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Usuario o Clave Incorrecto !!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
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
        private void Delete()
        {
        }

        private void Frm_usuarios_Activated(object sender, EventArgs e)
        {
        }
        private void Frm_usuarios_Load(object sender, EventArgs e)
        {
            modulo = ((DS0Seguridad.MainSeguridad)MdiParent).moduloid;
            local = ((DS0Seguridad.MainSeguridad)MdiParent).moduloid;
            PERFILID = ((DS0Seguridad.MainSeguridad)MdiParent).perfil;

            NIVEL_FORMS();

            limpiar_documento();
            nuevo();
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
            {
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

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0" || XNIVEL == "1")
            {
                if (usuar.Text.Trim().Length > 0)
                {
                    ssModo = "EDIT";

                    form_bloqueado(true);
                    clave.Focus();

                    btn_cancelar.Enabled = true;
                    btn_grabar.Enabled = true;
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

                btn_editar.Enabled = true;
                btn_log.Enabled = true;
                btn_salir.Enabled = true;
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

                if (openFoto.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = openFoto.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            var originalImage = Image.FromFile(openFoto.FileName);
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
    }
}
