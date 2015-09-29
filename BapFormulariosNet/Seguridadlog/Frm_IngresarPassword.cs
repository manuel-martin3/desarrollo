using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using bapFunciones;

namespace BapFormulariosNet.Seguridadlog
{
    public partial class Frm_IngresarPassword : Form
    {
        public bool _SoloLectura = true;
        public string _Pass = string.Empty;
        public delegate void PasaPasswordDelegate(string Pass);
        public PasaPasswordDelegate PasaPassword;

        public Frm_IngresarPassword()
        {
            InitializeComponent();
            Load += Frm_IngresarPassword_Load;
            KeyDown += Frm_IngresarPassword_KeyDown;
        }

        private void Frm_IngresarPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.Control & Keys.W))
            {
                txtPass.PasswordChar = Convert.ToChar(txtPass.PasswordChar.ToString().Trim().Length == 0 ? "*" : string.Empty);
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void Frm_IngresarPassword_Load(object sender, EventArgs e)
        {
            txtPass.Text = VariablesPublicas.DesEncripta(_Pass.Trim());
            txtPass.ReadOnly = _SoloLectura;
            txtPass.SelectAll();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtPass.ReadOnly == false)
            {
                PasaPassword(VariablesPublicas.Encripta(txtPass.Text.Trim()));
            }
            Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
