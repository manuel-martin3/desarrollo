using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using System.Net.Mail;
using System.IO;
using System.Net;
using System.Web;
using System.Xml;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using BapFormulariosNet;
using System.Diagnostics;

namespace BapFormulariosNet.Popup
{
    public partial class Frm_reniec : plantilla
    {
        DatosReniec myInfo;
        public delegate void PasaDniDelegate(String resultado01, String resultado02, String resultado03, String resultado04, String resultado05);
        public PasaDniDelegate PasaDni;

        #region Variables

        private String _dni;
        public String dni
        {
            get { return _dni; }
            set { _dni = value; }
        }

        private String _nombres;
        public String nombres
        {
            get { return _nombres; }
            set { _nombres = value; }
        }

        private String _apepat;
        public String apepat
        {
            get { return _apepat; }
            set { _apepat = value; }
        }

        private String _apemat;
        public String apemat
        {
            get { return _apemat; }
            set { _apemat = value; }
        }

        private String _pname;
        public String pname
        {
            get { return _pname; }
            set { _pname = value; }
        }

        private String _returndatos;
        public String returndatos
        {
            get { return _returndatos; }

            set { _returndatos = value; }
        }

        #endregion

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

        void CargarImagen()
        {
            if (VariablesPublicas.compruebaConexion() == true)
            {
                try
                {
                    if (myInfo == null)
                        myInfo = new DatosReniec();
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
                this.Close();
                //CargarImagen(); //Comentar esta linea para consultar multiples DNI usando un solo captcha.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        void CaptionResul()
        {
            try
            {
                switch (myInfo.GetResul)
                {
                    case DatosReniec.Resul.Ok:
                        //lblDireccion.Text = String.Format("Nombre(s): {0}" + Environment.NewLine +
                        //                    "Apellidos Paterno: {1}" + Environment.NewLine +
                        //                    "Apellidos Materno: {2}", myInfo.Nombres, myInfo.ApePaterno, myInfo.ApeMaterno);
                        //lblDireccion.Text = "Apellidos y Nombre(s): " + myInfo.ApePaterno + " " + myInfo.ApeMaterno + ", " + myInfo.Nombres;
                        apepat = myInfo.ApePaterno;
                        apemat = myInfo.ApeMaterno;
                        pname = myInfo.Nombres;
                        nombres = myInfo.ApePaterno + " " + myInfo.ApeMaterno + ", " + myInfo.Nombres;
                        this.PasaDni(nombres,apepat,apemat,pname,"");
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
