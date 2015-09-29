using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BapFormulariosNet.RecursosHumanos
{
    public partial class Frm_RegistroTrabajadoresBaja : plantilla
    {
        public Frm_RegistroTrabajadoresBaja()
        {
            InitializeComponent();

            Load += Frm_BajaTrabajadores_Load;
            KeyDown += Frm_BajaTrabajadores_KeyDown;
        }

        private void Frm_BajaTrabajadores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnSalir_Click(sender, e);
            }
        }

        private void Frm_BajaTrabajadores_Load(object sender, EventArgs e)
        {
            cbProceso.SelectedItem = cbProceso.Items[0].ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var form = new Frm_RegistroTrabajadoresBajaCese();
            if (cbProceso.SelectedItem.ToString() == cbProceso.Items[0].ToString())
            {
                form.Text = "Baja/Cese de Trabajadores (BAJA/CESAR)";
                form.btnAccion.Text = "Baja/Cesar Trabajador";
                form._varProcesoCesar = 1;
                form.ShowDialog();
            }
            else
            {
                form.Text = "Baja/Cese de Trabajadores (DESACTIVAR)";
                form.btnAccion.Text = "Desactivar Trabajador";
                form._varProcesoCesar = 2;
                form.ShowDialog();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
