using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using bapFunciones;

namespace BapFormulariosNet.D60Tienda.Popup
{
    public partial class Frm_reniec : plantilla
    {
        private DatosReniec myInfo;
        public delegate void PasaDniDelegate(String resultado01, String resultado02, String resultado03, String resultado04, String resultado05);
        public PasaDniDelegate PasaDni;
        public String dni { get; set; }
        public String nombres { get; set; }
        public String apepat { get; set; }
        public String apemat { get; set; }
        public String pname { get; set; }
        public String returndatos { get; set; }

        public Frm_reniec()
        {
            InitializeComponent();
        }

        private void cmdReloadCapcha_Click(object sender, EventArgs e)
        {
            try
            {
                CargarImagen();
                txtCapcha.SelectAll();
                txtCapcha.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarImagen()
        {
            if (VariablesPublicas.compruebaConexion() == true)
            {
                try
                {
                    if (myInfo == null)
                    {
                        myInfo = new DatosReniec();
                    }
                    pictureCapcha.Image = myInfo.GetCapcha;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                MessageBox.Show("Sin conexión a Internet", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnextraersunat_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCapcha.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Imagen Correctamente");
                    txtCapcha.SelectAll();
                    txtCapcha.Focus();
                    return;
                }
                if (dni.Trim().Length != 8)
                {
                    MessageBox.Show("Ingrese Dni Válido");
                    return;
                }

                myInfo.GetInfo(dni.Trim(), txtCapcha.Text);
                CaptionResul();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void CaptionResul()
        {
            try
            {
                switch (myInfo.GetResul)
                {
                    case DatosReniec.Resul.Ok:
                        apepat = myInfo.ApePaterno;
                        apemat = myInfo.ApeMaterno;
                        pname = myInfo.Nombres;
                        nombres = myInfo.ApePaterno + " " + myInfo.ApeMaterno + ", " + myInfo.Nombres;
                        PasaDni(nombres, apepat, apemat, pname, "");
                        break;
                    case DatosReniec.Resul.NoResul:
                        MessageBox.Show("No existe DNI");
                        break;
                    case DatosReniec.Resul.ErrorCapcha:
                        txtCapcha.Text = "";
                        CargarImagen();
                        MessageBox.Show("Ingrese imagen correctamente");
                        break;
                    case DatosReniec.Resul.Error:
                        MessageBox.Show("Error Desconocido");
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Frm_reniec_Load(object sender, EventArgs e)
        {
            txtCapcha.Focus();
            CargarImagen();
        }
    }
}
