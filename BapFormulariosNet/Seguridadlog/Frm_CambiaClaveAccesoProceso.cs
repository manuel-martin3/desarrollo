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
using BapFormulariosNet.Ayudas;

namespace BapFormulariosNet.Seguridadlog
{
    public partial class Frm_CambiaClaveAccesoProceso : Form
    {
        Genericas fungen = new Genericas();
        public string _TipoProceso = "...";
        public string _LoginUsuario = "...";
        private DataTable Cursor01 = new DataTable();

        public Frm_CambiaClaveAccesoProceso()
        {
            InitializeComponent();
            Load += Frm_CambiaClaveAccesoProceso_Load;
        }

        private void Frm_CambiaClaveAccesoProceso_Load(object sender, EventArgs e)
        {
            Label5.Visible = false;
            Label5.Text = "";
            FormBorderStyle = FormBorderStyle.Fixed3D;
            DataTable cursor02 = new DataTable();
            usuariosxprocesoBL BL = new usuariosxprocesoBL();
            tb_usuariosxproceso BE = new tb_usuariosxproceso();

            BE.procesoid = _TipoProceso;
            BE.norden = 1;
            cursor02 = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            //cursor02 = BL.GetAll(_TipoProceso, 1);
            if (cursor02.Rows.Count > 0)
            {
                Label5.Text = cursor02.Rows[0]["descripcion"].ToString();
                Label5.Visible = true;
            }           
            MaximizeBox = false;
            MinimizeBox = false;

            usuariosxprocesoBL BL1 = new usuariosxprocesoBL();
            tb_usuariosxproceso BE1 = new tb_usuariosxproceso();

            BE1.procesoid = _TipoProceso;
            BE1.usuar = _LoginUsuario.ToLower();
            BE1.norden = 1;
            BE1.login = _LoginUsuario;
            Cursor01 = BL1.GetAll_U_P(VariablesPublicas.EmpresaID.ToString(), BE1).Tables[0];
            //Cursor01 = BL1.GetAll_U_P(_TipoProceso, "", "", 1, _LoginUsuario);
            if (Cursor01.Rows.Count > 0)
            {
                txtUsuario.Text = Cursor01.Rows[0]["usuar"].ToString().Trim() + "-" + Cursor01.Rows[0]["nomusuario"];
            }
            txtUsuario.Enabled = Cursor01.Rows.Count == 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            txtClaveNew.Text = txtClaveNew.Text.Trim();
            txtClaveConfNew.Text = txtClaveConfNew.Text.Trim();
            
            //string LcClaveAntigua = fungen.EncryptStr(txtClave.Text.Trim().ToLower(), "key");
            //string LcClaveAntigua = VariablesPublicas.Encriptar(txtClave.Text.Trim(), "SI");
            string LcClaveAntigua = VariablesPublicas.Encripta(txtClave.Text.Trim());

            //string NewClave = fungen.EncryptStr(txtClaveNew.Text.Trim().ToLower(), "key");
            //string NewClave = VariablesPublicas.Encriptar(txtClaveNew.Text.Trim(), "SI");
            string NewClave = VariablesPublicas.Encripta(txtClaveNew.Text.Trim());
            
            //string NewClaveConfirma = fungen.EncryptStr(txtClaveConfNew.Text.Trim().ToLower(), "key");
            //string NewClaveConfirma = VariablesPublicas.Encriptar(txtClaveConfNew.Text.Trim(), "SI");
            string NewClaveConfirma = VariablesPublicas.Encripta(txtClaveConfNew.Text.Trim());
            
            if (!(Equivalencias.Left(LcClaveAntigua,20) == Cursor01.Rows[0]["password"].ToString().Trim()))
            //if (!(LcClaveAntigua == Cursor01.Rows[0]["password"].ToString().Trim()))
            {
                MessageBox.Show("Confirme Clave Antigua...", "Mensaje del Sistema");
                txtClave.Focus();
                return;
            }
            if (!(NewClave == NewClaveConfirma))
            {
                MessageBox.Show("Confirme Nueva Clave...", "Mensaje del Sistema");
                txtClaveConfNew.Focus();
                return;
            }
            Cursor01.Rows[0]["password"] = NewClaveConfirma;
            usuariosxprocesoBL BL = new usuariosxprocesoBL();
            tb_usuariosxproceso BE = new tb_usuariosxproceso();

            BE.procesoid = _TipoProceso;
            BE.ntipo = 1;
            //if (UsuariosProcesosInsertUpdated(_TipoProceso, Cursor01, 1))
            if (BL.UsuariosProcesosInsertUpdated(VariablesPublicas.EmpresaID.ToString(), BE, Cursor01))
            {
                MessageBox.Show("Clave ha sido modificada satisfactoriamente...?", "Mensaje del Sistema");
                Close();
            }
        }
    }
}
