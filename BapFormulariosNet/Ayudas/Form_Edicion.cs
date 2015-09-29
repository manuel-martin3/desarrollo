using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using LayerDataAccess;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.Ayudas
{
    public partial class Form_Edicion : Form
    {

        public delegate void PasaCtacteName(String resultado,String resultado2);
        String cadena;
        public PasaCtacteName PasaName;
        public bool _LeerCombo = true;
        public string _NombreDetalle = "";


        private String _ctactename;
        public String ctactename
        {
            get { return _ctactename; }
            set { _ctactename = value; }
        }

        private String _ctactenamedetalle;
        public String ctactenamedetalle
        {
            get { return _ctactenamedetalle; }
            set { _ctactenamedetalle = value; }
        }

        private String _productid;
        public String productid
        {
            get { return _productid; }
            set { _productid = value; }
        }


        private String _moduloid;
        public String moduloid
        {
            get { return _moduloid; }
            set { _moduloid = value; }
        }

        private String _serdoc;
        public String serdoc
        {
            get { return _serdoc; }
            set { _serdoc = value; }
        }


        private String _numdoc;
        public String numdoc
        {
            get { return _numdoc; }
            set { _numdoc = value; }
        }

        private String _tipodoc;
        public String tipodoc
        {
            get { return _tipodoc; }
            set { _tipodoc = value; }
        }

        public Form_Edicion()
        {
            InitializeComponent();
            editproducto.CharacterCasing = CharacterCasing.Upper;
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            string a = editprod_cab.Text.ToString() + "\r";
            string[] arreglo = editproducto.Text.Split('\n');

            for (int i = 0; i < arreglo.Length; i++)
            {
                cadena = cadena + "." + " " + arreglo[i];
            }
            PasaName(a + cadena, productid);
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            bool prosigue = false;                
            prosigue = MessageBox.Show("Estas Seguro(a) de Cancelar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

            if (prosigue)
            {
                Close();
            }
        }

        private void Form_Edicion_Load(object sender, EventArgs e)
        {
            editprod_cab.Text = ctactename.ToString();
            editproducto.Text = ctactenamedetalle.ToString();  // En esta parte deberia de mostrarme el nombre del producto propiamente dicho            
        }

        private void btn_clean_Click(object sender, EventArgs e)
        {
            editproducto.Clear();
        }
        
    }
}
