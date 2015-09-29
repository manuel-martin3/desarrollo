using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.Ayudas
{
    public partial class Form_user_admin : Form
    {
        public delegate void PasaDatosDelegate(Boolean resultado01, String resultado02);
        public PasaDatosDelegate PasaDatos;
        private Genericas fungen = new Genericas();

        public Form_user_admin()
        {
            InitializeComponent();
        }

        private void Form_user_admin_Load(object sender, EventArgs e)
        {
            Top = (Screen.PrimaryScreen.WorkingArea.Height - Height) / 2;
            Left = (Screen.PrimaryScreen.WorkingArea.Width - Width) / 2;
            txt_usuario.Text = string.Empty;
            txt_clave.Text = string.Empty;
            txt_glosa.Text = string.Empty;
        }
        private void Form_user_admin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btn_cancelar_Click(sender, e);
            }
        }

        private void txt_usuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_clave.Focus();
            }
        }
        private void txt_clave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_login.PerformClick();
            }
        }
        private void txt_glosa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_login.Focus();
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            var usuariosBL = new usuariosBL();
            var tb_usuarios = new tb_usuarios();

            var dt = new DataTable();
            String xClave = null;
            var xadmin = false;
            tb_usuarios.usuar = txt_usuario.Text.Trim().ToLower();

            if (ValidarIngreso())
            {
                try
                {
                    dt = usuariosBL.GetAll(VariablesPublicas.EmpresaID, tb_usuarios).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        xClave = Convert.ToString(dt.Rows[0]["clave"]);
                        xadmin = Convert.ToBoolean(dt.Rows[0]["admin"]);

                        txt_clave.Text = fungen.GetMD5(txt_clave.Text.ToLower()).Substring(0, 10);
                        if (txt_clave.Text.ToUpper() == xClave)
                        {
                            if (xadmin)
                            {
                                PasaDatos(true, txt_glosa.Text.Trim().ToUpper());
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("No tiene permisos suficientes !!!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Usuario o Clave Incorrecto !!!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existe Usuario !!!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool ValidarIngreso()
        {
            var errorProvider1 = new ErrorProvider();
            if (String.IsNullOrEmpty(txt_usuario.Text.Trim()))
            {
                errorProvider1.SetError(txt_usuario, "Escriba el nombre del usuario");
                txt_usuario.Focus();
                return false;
            }
            else
            {
                if (String.IsNullOrEmpty(txt_clave.Text.Trim()))
                {
                    errorProvider1.SetError(txt_clave, "Escriba la contraseña");
                    txt_clave.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
