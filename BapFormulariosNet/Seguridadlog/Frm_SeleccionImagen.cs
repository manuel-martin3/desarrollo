using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using bapFunciones;

namespace BapFormulariosNet.Seguridadlog
{
    public partial class Frm_SeleccionImagen : Form
    {
        public delegate void PasaRutaImagen(string RutaImagen);
        public PasaRutaImagen _PasaRutaImagen;
        public string _RutaImagen = string.Empty;
        public bool _SoloLectura;
        private string direc = string.Empty;

        public Frm_SeleccionImagen()
        {
            InitializeComponent();
            Load += Frm_SeleccionImagen_Load;
        }

        private void Frm_SeleccionImagen_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Fixed3D;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            GroupBox1.Enabled = !_SoloLectura;
            txtImagen.Text = _RutaImagen.Trim();
            if (txtImagen.Text != string.Empty)
            {
                try
                {
                    PicturePrenda.Image = Image.FromFile(txtImagen.Text.Trim());
                }
                catch (Exception ex)
                {
                }
            }
        }

        private string ObtenerImagen(PictureBox Img, string ruta)
        {
            OFDFoto.Filter = "Archivos de Imagenes (*.jpg)|*.jpg|Archivos de Imagenes (*.gif)|*.gif|Archivos de Imagenes (*.bmp)|*.bmp";
            if (OFDFoto.ShowDialog() == DialogResult.OK)
            {
                Img.Image = Image.FromFile(OFDFoto.FileName);
                ruta = OFDFoto.FileName;
                var nombre = ObtenerNombreArchivo(ruta);
                var ImagenAleatoria = string.Empty;
                if (direc.Trim() != GlobalVars.GetInstance().RutaImagenes.Trim())
                {
                    try
                    {
                        ImagenAleatoria = VariablesPublicas.Imagen_Aleatoria(GlobalVars.GetInstance().RutaImagenes.Trim(), nombre);
                    }
                    catch (Exception ex)
                    {
                    }

                    if (System.IO.File.Exists(ImagenAleatoria.Trim()) == false)
                    {
                    }
                    ruta = ImagenAleatoria.Trim();
                }
            }
            return ruta;
        }

        private string ObtenerNombreArchivo(string nom)
        {
            var n = 0;
            var pos = 0;
            for (n = 0; n <= nom.Length; n++)
            {
                if (Equivalencias.Mid(nom, nom.Length - n, 1) == "\\")
                {
                    pos = (nom.Length - n) + 1;
                    break;
                }
            }
            direc = Equivalencias.Mid(nom, 1, pos - 1);
            return Equivalencias.Mid(nom, pos);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            _PasaRutaImagen(txtImagen.Text.Trim());
            Close();
        }

        private void btnAjuntarFoto_Click(object sender, EventArgs e)
        {
            txtImagen.Text = ObtenerImagen(PicturePrenda, txtImagen.Text.Trim());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            txtImagen.Text = string.Empty;

            PicturePrenda.Image = null;
        }
    }
}
