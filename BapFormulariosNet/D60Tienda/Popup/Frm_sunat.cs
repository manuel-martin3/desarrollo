using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using bapFunciones;

namespace BapFormulariosNet.D60Tienda.Popup
{
    public partial class Frm_sunat : plantilla
    {
        private DatosSunat myInfo;
        public delegate void PasaRucDelegate(String resultado01, String resultado02, String resultado03, String resultado04, String resultado05, String resultado06, String resultado07, String resultado08, String resultado09, String resultado10);
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

        public Frm_sunat()
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
                        myInfo = new DatosSunat();
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
                if (Ruc.Trim().Length != 11)
                {
                    MessageBox.Show("Ingrese RUC Válido");
                    return;
                }

                myInfo.GetInfo(Ruc.Trim(), txtCapcha.Text);
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
                    case DatosSunat.Resul.Ok:
                        RazonSocial = myInfo.RazonSocial;
                        AntiguoRuc = myInfo.AntiguoRuc;
                        Estado = myInfo.Estado;
                        EsAgenteRetencion = myInfo.EsAgenteRetencion;
                        NombreComercial = myInfo.NombreComercial;
                        Direccion = myInfo.Direccion;
                        Telefono = myInfo.Telefono;
                        Dependencia = myInfo.Dependencia;
                        Tipo = myInfo.Tipo;
                        PasaRuc(RazonSocial, Direccion, Estado, EsAgenteRetencion, NombreComercial, Telefono, Dependencia, Tipo, "", "");
                        break;
                    case DatosSunat.Resul.NoResul:
                        MessageBox.Show("No existe RUC");
                        break;
                    case DatosSunat.Resul.ErrorCapcha:
                        txtCapcha.Text = "";
                        CargarImagen();
                        MessageBox.Show("Ingrese imagen correctamente");
                        break;
                    case DatosSunat.Resul.Error:
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
