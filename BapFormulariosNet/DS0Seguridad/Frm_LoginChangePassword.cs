using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.DS0Seguridad
{
    public partial class Frm_LoginChangePassword : Form
    {
        private Genericas fungen = new Genericas();
        public string UserNameCC;
        public string Usuar;
        public string NOmbreDominio;
        private String XGLOSA = string.Empty;
        public Form FormOrigen = new Form();

        public Frm_LoginChangePassword()
        {
            InitializeComponent();
            Load += Frm_LoginChangePassword_Load;
            FormClosing += Frm_LoginChangePassword_FormClosing;
        }

        private void Frm_LoginChangePassword_Load(object sender, EventArgs e)
        {
            lblUserName.Text = Usuar.Trim() + " - " + UserNameCC.Trim();
        }
        private void Frm_LoginChangePassword_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
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

                                BE.usuar = Usuar.Trim().ToLower();
                                dt = BL.GetAll(VariablesPublicas.EmpresaID, BE).Tables[0];
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

                                        BE2.usuar = Usuar.ToLower().Trim();
                                        BE2.clave = primero.Trim();
                                        if (BL2.Update_modificarclave(VariablesPublicas.EmpresaID, BE2))
                                        {
                                            SEGURIDAD_LOG("M");
                                            MessageBox.Show("Clave modificado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            Close();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Contáctese con Sistemas !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error al generar Nueva Clave !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                BE.detalle = Usuar.Trim() + " | " + UserNameCC.Trim().ToUpper() + " | " + XGLOSA;

                BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var oform = new Seguridadlog.FrmSeguridad();
            var xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio;
            oform._Nombre = Name;
            oform._ClaveForm = xclave;
            oform.Owner = this;
            oform.ShowDialog();
        }
    }
}
