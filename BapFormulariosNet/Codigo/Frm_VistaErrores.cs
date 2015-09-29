using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BapFormulariosNet.Cogido
{
    public partial class Frm_VistaErrores : Form
    {
        public string _Mensaje = string.Empty;
        public DataTable tabla;

        public Frm_VistaErrores()
        {
            InitializeComponent();
        }

        private void Frm_VistaErrores_Load(object sender, EventArgs e)
        {
            if (tabla.Rows.Count > 0)
            { dgb_errores.DataSource = tabla; }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }      
      
    }
}
