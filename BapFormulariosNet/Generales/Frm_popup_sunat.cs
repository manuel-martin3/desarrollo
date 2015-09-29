using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using bapFunciones;

namespace BapFormulariosNet.Generales
{
    public partial class Frm_popup_sunat : plantilla
    {
        private DatoSUNAT myInfo;
        public delegate void PasaRucDelegate(Info _Info);

        public PasaRucDelegate PasaRuc;
        public String Ruc { get; set; }
        public String RazonSocial { get; set; }
        public String AntiguoRuc { get; set; }
        public String Estado { get; set; }
        public String EsAgenteRetencion { get; set; }
        public String NombreComercial { get; set; }

        public String _Direccion;
        public String Direccion
        {
            get
            {
                return _Direccion;
            }
            set
            {
                _Direccion = value;
            }
        }
        public String Telefono { get; set; }
        public String Dependencia { get; set; }
        public String Tipo { get; set; }
        public String returndatos { get; set; }

        public Frm_popup_sunat()
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
                        myInfo = new DatoSUNAT();
                    }
                    pictureCapcha.Image = myInfo.GetCapchaSunat;
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
                if (Ruc.Trim().Length != 11)
                {
                    MessageBox.Show("Ingrese RUC Válido");
                    return;
                }

                myInfo.GetInfoSunat(Ruc.Trim(), txtCapcha.Text);
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
            var vInfo = new Info();
            try
            {
                switch (myInfo.GetResul)
                {
                    case DatoSUNAT.ResulSunat.Ok:

                        vInfo.RazonSocial = myInfo.RazonSocial;
                        vInfo.Direccion = myInfo.Direccion;
                        vInfo.Telefono = myInfo.Telefonos;
                        vInfo.Estado = myInfo.Estado;
                        vInfo.EsAgenteRetencion = myInfo.AgeRetencion;
                        vInfo.Condicion = myInfo.Condicion;


                        PasaRuc(vInfo);
                        break;
                    case DatoSUNAT.ResulSunat.NoResul:
                        MessageBox.Show("No existe RUC");
                        break;
                    case DatoSUNAT.ResulSunat.ErrorCapcha:
                        txtCapcha.Text = "";
                        CargarImagen();
                        MessageBox.Show("Ingrese imagen correctamente");
                        break;
                    case DatoSUNAT.ResulSunat.Error:
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
