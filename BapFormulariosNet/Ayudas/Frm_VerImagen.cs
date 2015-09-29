using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using bapFunciones;

namespace BapFormulariosNet.AYUDA
{
    public partial class Frm_VerImagen : Form
    {
        public string _DirectorioImagen = string.Empty;
        public string _NombreArchivo = string.Empty;
        public delegate void RetornaImagen(string ArchivoCompleto, bool zmodificaImagen);
        public string _Titulo = "Imagen";
        public int u_n_Opsel = 0;
        public RetornaImagen _RetornaImagenXXX;
        private string PrvSaveRuta = string.Empty;
        private string PrvSaveFile = string.Empty;

        private bool zmodificaImagen = false;

        public Frm_VerImagen()
        {
            InitializeComponent();
            Resize += Frm_VerImagen_Resize;
            Load += Frm_VerImagen_Load;
            KeyDown += Frm_VerImagen_KeyDown;
        }

        private void Frm_VerImagen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
        }

        private void Frm_VerImagen_Load(object sender, EventArgs e)
        {
            var xvmfile = _DirectorioImagen + _NombreArchivo;
            try
            {
                if (!System.IO.File.Exists(xvmfile))
                {
                    _DirectorioImagen = string.Empty;
                }
            }
            catch (Exception ex)
            {
                _DirectorioImagen = string.Empty;
            }

            if (_DirectorioImagen == string.Empty)
            {
                _DirectorioImagen = VariablesPublicas.RutaImagenes;
            }
            try
            {
                MuestraImagen.Image = System.Drawing.Image.FromFile(_DirectorioImagen + _NombreArchivo);
                MuestraImagen.Visible = true;
            }
            catch (Exception ex)
            {
                MuestraImagen.Visible = false;
            }
            MinimizeBox = false;
            PrvSaveRuta = _DirectorioImagen;
            PrvSaveFile = _NombreArchivo;

            FormBorderStyle = FormBorderStyle.Fixed3D;
            Text = _Titulo;
            RefrescaControles();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregarimagen_Click(object sender, EventArgs e)
        {
            var ruta = string.Empty;
            var fileDialog = new OpenFileDialog();
            fileDialog.Title = "Abrir el archivo imagen";

            fileDialog.Filter = "Archivos de Imagenes (*.bmp;*.jpg;*.gif;*.png;*.tif)|*.bmp;*.jpg;*.gif;*.png;*.tif";
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ruta = fileDialog.FileName;
                try
                {
                    MuestraImagen.ImageLocation = ruta;
                    MuestraImagen.Visible = true;
                    zmodificaImagen = true;
                }
                catch (Exception ex)
                {
                    MuestraImagen.Visible = false;
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!zmodificaImagen | u_n_Opsel == 0)
            {
                _RetornaImagenXXX(string.Empty, zmodificaImagen);
            }
            else
            {
                if ((MuestraImagen.ImageLocation != null))
                {
                    _RetornaImagenXXX(MuestraImagen.ImageLocation, zmodificaImagen);
                }
                else
                {
                    if ((_NombreArchivo).Trim().Length > 0)
                    {
                        _RetornaImagenXXX(_DirectorioImagen + _NombreArchivo, zmodificaImagen);
                    }
                    else
                    {
                        _RetornaImagenXXX(string.Empty, zmodificaImagen);
                    }
                }
            }
            btnCancelar_Click(sender, e);
        }

        public void RefrescaControles()
        {
            btnAgregarimagen.Enabled = u_n_Opsel > 0;
            btnAceptar.Enabled = u_n_Opsel > 0;
            btnCancelar.Enabled = true;
            btnQuitarimagen.Enabled = u_n_Opsel > 0;
        }

        private void Frm_VerImagen_Resize(object sender, EventArgs e)
        {
        }

        private void btnQuitarimagen_Click(object sender, EventArgs e)
        {
            MuestraImagen.ImageLocation = string.Empty;
            MuestraImagen.Visible = false;
            zmodificaImagen = true;
        }

        private void MuestraImagen_DoubleClick(object sender, EventArgs e)
        {
            var ruta = string.Empty;
            var fileDialog = new SaveFileDialog();
            fileDialog.CheckFileExists = false;
            fileDialog.Filter = "Archivos de Imagenes (*.bmp;*.jpg;*.gif;*.png;*.tif)|*.bmp;*.jpg;*.gif;*.png;*.tif";
            fileDialog.Title = "Exportar Imagen";
            fileDialog.FileName = _NombreArchivo;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ruta = fileDialog.FileName;
                try
                {
                    MuestraImagen.Image.Save(ruta);
                    MessageBox.Show("Se exportó imagen a " + ruta, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
