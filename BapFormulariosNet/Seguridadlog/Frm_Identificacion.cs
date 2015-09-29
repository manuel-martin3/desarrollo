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
using BapFormulariosNet;
//using BapFormulariosNet.DA0CONTABILIDAD.Ayudas;
using BapFormulariosNet.Ayudas;

namespace BapFormulariosNet.Seguridadlog
{
    public partial class Frm_Identificacion : Form
    {
        Genericas fungen = new Genericas();
        public string TipoProceso = "...";
        public delegate void PasaIdentificacion(string CodUser);
        public PasaIdentificacion PasaIdentificacionDelegado;
        private int Intentos = 0;

        public Frm_Identificacion()
        {
            InitializeComponent();
            Load += Frm_Identificacion_Load;
            KeyDown += Frm_Identificacion_KeyDown;
        }

        private void Frm_Identificacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar_Click(sender, e);
            }
        }

        private void Frm_Identificacion_Load(object sender, EventArgs e)
        {
            Label3.Text = "";
            btnCambiaClave.Enabled = false;
            DataTable Cursor01 = new DataTable();
            
            usuariosxprocesoBL BL = new usuariosxprocesoBL();
            tb_usuariosxproceso BE = new tb_usuariosxproceso();

            BE.procesoid = TipoProceso;
            BE.norden = 1;
            Cursor01 = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            if (Cursor01.Rows.Count > 0)
            {
                Label3.Text = Cursor01.Rows[0]["descripcion"].ToString().Trim();
                Label3.Visible = Label3.Text.Trim().Length > 0;
            }           
            txtUsuario.Focus();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            btnCambiaClave.Enabled = txtUsuario.Text.Trim().Length > 0;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese Usuario...", "Mensaje del Sistema");
                return;
            }
            DataTable OData = new DataTable();
            DataTable DataPassword = new DataTable();
            int Recno = 0;

            usuariosBL BL = new usuariosBL();
            tb_usuarios BE = new tb_usuarios();

            BE.usuar = txtUsuario.Text.Trim().ToLower();
            OData = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            //OData = GetAll("", txtUsuario.Text, 0);
            string LcClave = "";
            //LcClave = fungen.EncryptStr(txtClave.Text.Trim(), "key");
            //LcClave = VariablesPublicas.Encriptar(txtClave.Text.Trim(), "SI");
            LcClave = VariablesPublicas.Encripta(txtClave.Text.Trim());
            DataPassword = null;
            if (OData.Rows.Count > 0)
            {
                usuariosxprocesoBL BL1 = new usuariosxprocesoBL();
                tb_usuariosxproceso BE1 = new tb_usuariosxproceso();

                BE1.procesoid = TipoProceso;
                BE1.usuar = OData.Rows[0]["usuar"].ToString().Trim();
                BE1.password = LcClave;
                BE1.norden = 0;
                DataPassword = BL1.GetAll_U_P(VariablesPublicas.EmpresaID.ToString(), BE1).Tables[0];
                //DataPassword = BL1.GetAll_U_P(TipoProceso, OData.Rows[0]["codigo"], LcClave, 0, "");
                if (DataPassword.Rows.Count > 0)
                {
                    if (!(DataPassword.Rows[0]["password"].ToString().Trim() == Equivalencias.Left(LcClave.Trim(),20)))
                    //if (!(DataPassword.Rows[0]["password"].ToString().Trim() == LcClave.Trim()))
                    {
                        for (Recno = 0; Recno <= DataPassword.Rows.Count - 1; Recno++)
                        {
                            DataPassword.Rows[Recno].Delete();
                        }
                        DataPassword.AcceptChanges();
                    }
                }
                if (DataPassword.Rows.Count > 0)
                {
                    if (DataPassword.Rows[0]["destadousuario"].ToString() == "ACTIVO")
                    {
                        PasaIdentificacionDelegado(OData.Rows[0]["usuar"].ToString());
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("El Usuario No esta Activo..." + "\r" + "Verifique con Administrador del Sistema...?", "Mensaje del Sistema");
                        txtClave.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Password Errado... Verifique?", "Mensaje del Sistema");
                    txtClave.Focus();
                    Intentos = Intentos + 1;
                }
            }
            else
            {
                MessageBox.Show("Usuario No Existe... Verifique?", "Mensaje del Sistema");
                Intentos = Intentos + 1;
            }

            if (Intentos == 3)
            {
                MessageBox.Show("Excedió el máximo de intentos permitidos...?", "Mensaje del Sistema");
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnCambiaClave_Click(object sender, EventArgs e)
        {
            DataTable cursor01 = new DataTable();
            usuariosxprocesoBL BL = new usuariosxprocesoBL();
            tb_usuariosxproceso BE = new tb_usuariosxproceso();

            BE.procesoid = TipoProceso;
            BE.usuar = txtUsuario.Text.Trim().ToLower();
            //BE.password = fungen.EncryptStr(txtClave.Text.ToLower().Trim(),"key");
            //BE.password =  VariablesPublicas.Encriptar(txtClave.Text.Trim(), "SI");
            BE.password = VariablesPublicas.Encripta(txtClave.Text.Trim());
            BE.norden = 1;
            BE.login = txtUsuario.Text.Trim().ToLower();
            cursor01 = BL.GetAll_U_P(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            //cursor01 = IBL.GetAll_U_P(TipoProceso, "", txtClave.Text.Trim(), 1, txtUsuario.Text.Trim());
            if (cursor01.Rows.Count > 0)
            {
                Frm_CambiaClaveAccesoProceso tmpform = new Frm_CambiaClaveAccesoProceso();
                tmpform._LoginUsuario = txtUsuario.Text;
                tmpform._TipoProceso = TipoProceso;
                tmpform.Owner = this;
                tmpform.ShowDialog();
            }
            else
            {
                MessageBox.Show("Verifique usuario o Clave.. Datos Erróneos", "Mensaje del Sistema");
            }
        }
    }
}
