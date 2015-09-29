using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BapFormulariosNet.Codigo
{
    public partial class Frm_Errores : Form
    {
        public string _Mensaje = string.Empty;
        public Frm_Errores()
        {
            InitializeComponent();
        }

        private void Frm_Errores_Load(object sender, EventArgs e)
        {
            TextBox1.Text = _Mensaje;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
