using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.RecursosHumanos
{
    public partial class Frm_RegistroTrabjadoresReactivar : plantilla
    {
        public Frm_RegistroTrabjadoresReactivar()
        {
            InitializeComponent();

            Load += Frm_RegistroTrabjadoresReactivar_Load;
            KeyDown += Frm_RegistroTrabjadoresReactivar_KeyDown;
        }

        private void Frm_RegistroTrabjadoresReactivar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true)
            {
                switch (e.KeyCode)
                {
                    case Keys.R:
                        if (btnReingreso.Enabled == true)
                        {
                            btnReingreso_Click(sender, e);
                        }
                        break;
                    case Keys.J:
                        if (btnActivar.Enabled == true)
                        {
                            btnActivar_Click(sender, e);
                        }
                        break;
                    case Keys.S:
                        if (btnSalir.Enabled == true)
                        {
                            btnSalir_Click(sender, e);
                        }
                        break;
                }
            }
            if (e.Control == false & e.KeyCode == Keys.Escape)
            {
                btnSalir_Click(sender, e);
            }
        }
        private void Frm_RegistroTrabjadoresReactivar_Load(object sender, EventArgs e)
        {
            btnReingreso.Enabled = false;
            U_LoadPlanillas(0);
        }

        private void U_LoadPlanillas(Int16 nInit)
        {
            DataGridView1.AutoGenerateColumns = false;
            DataGridView1.Columns[0].DataPropertyName = "nselect";
            DataGridView1.Columns[1].DataPropertyName = "ficha";
            DataGridView1.Columns[2].DataPropertyName = "dficha";
            DataGridView1.Columns[3].DataPropertyName = "f_ingreso";
            DataGridView1.Columns[4].DataPropertyName = "f_cese";
            DataGridView1.Columns[5].DataPropertyName = "planilla";
            DataGridView1.Columns[6].DataPropertyName = "estado";

            var BL = new tb_plla_fichatrabajadoresBL();
            var BE = new tb_plla_fichatrabajadores();
            BE.Ver_inactivos = nInit;
            DataGridView1.DataSource = BL.GetAllTrabajadoresReactivar(VariablesPublicas.EmpresaID, BE).Tables[0];
        }

        public void SeleccionarDegrilla(int opcion)
        {
            var n = 0;
            var i = 0;
            var retorno = false;
            if (chkInactivos.Checked)
            {
                i = 1;
            }
            else
            {
                i = 0;
            }
            if (DataGridView1.Rows.Count > 0)
            {
                for (n = 0; n <= DataGridView1.Rows.Count - 1; n++)
                {
                    if (Convert.ToInt32(DataGridView1.Rows[n].Cells[0].Value) == 1)
                    {
                        var BL = new tb_plla_fichatrabajadoresBL();
                        var BE = new tb_plla_fichatrabajadores();
                        BE.Fichaid = DataGridView1.Rows[n].Cells[1].Value.ToString().Trim();
                        BE.Ntipo = opcion;
                        retorno = BL.ReactivarTrabajadorUpdate(VariablesPublicas.EmpresaID, BE);
                    }
                }
                if (retorno)
                {
                    MessageBox.Show("Accion realizada con exito !!!");
                    U_LoadPlanillas(0);
                }
                else
                {
                    MessageBox.Show("Error al Grabar !!!!");
                }
            }
        }
        public int CuentaSeleccionados()
        {
            var n = 0;
            var i = 0;

            if (DataGridView1.Rows.Count > 0)
            {
                for (n = 0; n <= DataGridView1.Rows.Count - 1; n++)
                {
                    if (Convert.ToInt32(DataGridView1.Rows[n].Cells[0].Value) == 1)
                    {
                        i = i + 1;
                    }
                }
            }
            return i;
        }
        public void pintar()
        {
            try
            {
                var i = 0;
                var j = 0;
                for (i = 0; i <= DataGridView1.Rows.Count - 1; i++)
                {
                    if (DataGridView1[6, i].Value.ToString().Trim() == "CESADO")
                    {
                        for (j = 0; j <= DataGridView1.ColumnCount - 1; j++)
                        {
                            DataGridView1[j, i].Style.ForeColor = Color.Red;
                            DataGridView1[j, i].Style.BackColor = Color.Ivory;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void chkInactivos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInactivos.Checked)
            {
                U_LoadPlanillas(1);
                pintar();
                btnReingreso.Enabled = true;
            }
            else
            {
                U_LoadPlanillas(0);
                btnReingreso.Enabled = false;
            }
        }

        private void btnReingreso_Click(object sender, EventArgs e)
        {
            if (CuentaSeleccionados() > 0)
            {
                if (MessageBox.Show("Esta seguro de Reingresar a los Trabajadores seleccionados ?", "Reingreso de Trabajadores", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SeleccionarDegrilla(1);
                }
            }
            else
            {
                MessageBox.Show("No se ha hecho ninguna seleccion !!!!");
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            if (CuentaSeleccionados() > 0)
            {
                if (MessageBox.Show("Esta seguro de Activar a los Trabajadores seleccionados ?", "Activacion de Trabajadores", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SeleccionarDegrilla(2);
                }
            }
            else
            {
                MessageBox.Show("No se ha hecho ninguna seleccion !!!!");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
