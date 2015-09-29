using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BapAlmacenNet
{
    public partial class plantilla : Form
    {
        public plantilla()
        {
            InitializeComponent();
        }

        private Int32 _id_Perfil;
        public Int32 Id_Perfil
        {
            get { return _id_Perfil; }
            set { _id_Perfil = value; }
        }

        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void plantilla_Load(object sender, EventArgs e)
        {

        }
    }
}
