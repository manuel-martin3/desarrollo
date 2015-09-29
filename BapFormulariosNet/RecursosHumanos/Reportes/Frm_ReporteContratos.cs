using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BapFormulariosNet.Ayudas;

namespace BapFormulariosNet.RecursosHumanos.Reportes
{
    public partial class Frm_ReporteContratos : plantilla
    {
        private int u_n_opsel = 0;


        public Frm_ReporteContratos()
        {
            InitializeComponent();
        }

        private void Frm_PorcentajeLeyTrabajador_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            WindowState = FormWindowState.Normal;
            FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void U_RefrescaControles()
        {
            btn_imprimir.Enabled = u_n_opsel > 0;
            txtccosto.Enabled = u_n_opsel == 0;
            txtccargo.Enabled = u_n_opsel == 0;
            txtdcosto.ReadOnly = false;
            txtdcargo.ReadOnly = false;
        }

        private void txtccosto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaCcosto();
            }
        }

        public void AyudaCcosto()
        {
            var oform = new Frm_AyudaCCostoPlla();
            oform._PasaDelegado = RecibeCCOSTO;
            oform.Owner = this;
            oform.ShowDialog();
        }

        public void RecibeCCOSTO(string Codigo, string nombre)
        {
            txtccosto.Text = Codigo;
            txtdcosto.Text = nombre;
            txtccargo.Text = string.Empty;
            txtdcargo.Text = string.Empty;
        }

        private void txtccargo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaCargos();
            }
        }

        public void AyudaCargos()
        {
            var oform = new Frm_AyudaCargosPlla();
            oform._ccosto = txtccosto.Text.Trim();
            oform._PasaDelegado = RecibeCARGO;
            oform.Owner = this;
            oform.ShowDialog();
        }

        public void RecibeCARGO(string Codigo, string nombre, string codcosto, string nomcosto)
        {
            txtccargo.Text = Codigo;
            txtdcargo.Text = nombre;
            txtccosto.Text = codcosto;
            txtdcosto.Text = nomcosto;
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                var miForma = new Reportes.Frm_reportes();
                miForma.ccencos = txtccosto.Text.Trim();
                miForma.ccargo = txtdcargo.Text.Trim();
                miForma.formulario = "Frm_Contrato";
                miForma.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
