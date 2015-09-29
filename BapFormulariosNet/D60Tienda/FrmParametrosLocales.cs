using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LayerDataAccess;
using bapFunciones;
using System.Xml;
using System.IO;

namespace BapFormulariosNet.D60Tienda
{
    public partial class FrmParametrosLocales : plantilla
    {
        private ConfigXml mCfg;
        private String _servername = string.Empty, _servername2 = string.Empty;
        private String _database = string.Empty, _database2 = string.Empty;
        private String _user = string.Empty, _user2 = string.Empty;
        private String _password = string.Empty, _password2 = string.Empty;
        private String _cajanume = string.Empty;
        public FrmParametrosLocales()
        {
            InitializeComponent();
        }

        private void FrmParametrosLocales_Load(object sender, EventArgs e)
        {
            _RecuperaAdmConexion();
            _RecuperaEmpConexion();
            llenarNCajas();
            _RecuperarValores();
            _ponerValorCombo();
            _bloqueo(false);
        }

        private void _RecuperarValores()
        {
            var xDoc = new XmlDocument();
            var xArchivo = @"c:\ErpBapSoftNet_Config\BapConfig.cfg";
            xDoc.Load(xArchivo);

            var configuration = xDoc.GetElementsByTagName("configuration");
            var lista = ((XmlElement)configuration[0]).GetElementsByTagName("Paramlocal");

            foreach (XmlElement nodo in lista)
            {
                var i = 0;
                var ncajanume = nodo.GetElementsByTagName("cajanume");
                var nperimes = nodo.GetElementsByTagName("perimes");
                _cajanume = ncajanume[i].InnerText;
                perimes.Text = nperimes[i].InnerText;
            }
        }

        private void _RecuperaAdmConexion()
        {
            var xDoc = new XmlDocument();
            var xArchivo = @"c:\ErpBapSoftNet_Config\BapConfig.cfg";
            xDoc.Load(xArchivo);

            var configuration = xDoc.GetElementsByTagName("configuration");
            var lista = ((XmlElement)configuration[0]).GetElementsByTagName("AdmConexion");

            foreach (XmlElement nodo in lista)
            {
                var i = 0;
                var nservername = nodo.GetElementsByTagName("servername");
                var ndatabase = nodo.GetElementsByTagName("database");
                var nuser = nodo.GetElementsByTagName("user");
                var npassword = nodo.GetElementsByTagName("password");

                _servername = nservername[i].InnerText;
                _database = ndatabase[i].InnerText;
                _user = nuser[i].InnerText;
                _password = npassword[i].InnerText;
            }
        }

        private void _RecuperaEmpConexion()
        {
            var xDoc = new XmlDocument();
            var xArchivo = @"c:\ErpBapSoftNet_Config\BapConfig.cfg";
            xDoc.Load(xArchivo);

            var configuration = xDoc.GetElementsByTagName("configuration");
            var lista = ((XmlElement)configuration[0]).GetElementsByTagName("EmpConexion");

            foreach (XmlElement nodo in lista)
            {
                var i = 0;
                var nservername = nodo.GetElementsByTagName("servername");
                var ndatabase = nodo.GetElementsByTagName("database");
                var nuser = nodo.GetElementsByTagName("user");
                var npassword = nodo.GetElementsByTagName("password");

                _servername2 = nservername[i].InnerText;
                _database2 = ndatabase[i].InnerText;
                _user2 = nuser[i].InnerText;
                _password2 = npassword[i].InnerText;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            var xArchivo = @"c:\ErpBapSoftNet_Config\BapConfig.cfg";

            if (File.Exists(xArchivo))
            {
                System.IO.File.Delete(xArchivo);
            }

            if (!File.Exists(xArchivo))
            {
                var DIR = new DirectoryInfo(@"c:\ErpBapSoftNet_Config");
                if (!DIR.Exists)
                {
                    DIR.Create();
                }
                mCfg = new ConfigXml(xArchivo, true);
                mCfg.SetValue("AdmConexion", "servername", _servername.ToString());
                mCfg.SetValue("AdmConexion", "database", _database.ToString());
                mCfg.SetValue("AdmConexion", "user", _user.ToString());
                mCfg.SetValue("AdmConexion", "password", _password.ToString());

                mCfg.SetValue("EmpConexion", "servername", _servername2.ToString());
                mCfg.SetValue("EmpConexion", "database", _database2.ToString());
                mCfg.SetValue("EmpConexion", "user", _user2.ToString());
                mCfg.SetValue("EmpConexion", "password", _password2.ToString());

                mCfg.SetValue("Paramlocal", "cajanume", cmb_ncaja.Text);
                mCfg.SetValue("Paramlocal", "perimes", perimes.Text);

                mCfg.Save();
                MessageBox.Show("Registro Modificado ...!!!");
                _bloqueo(false);
                var frm = new MainTienda();
                frm.StatusBar();
            }
        }

        private void llenarNCajas()
        {
            var lista = new List<Item>();

            lista.Add(new Item("-----", 00));
            lista.Add(new Item("01", 01));
            lista.Add(new Item("02", 02));
            lista.Add(new Item("03", 03));
            lista.Add(new Item("04", 04));
            lista.Add(new Item("05", 05));
            lista.Add(new Item("06", 06));
            lista.Add(new Item("07", 07));
            lista.Add(new Item("08", 08));
            lista.Add(new Item("09", 09));
            lista.Add(new Item("10", 10));
            cmb_ncaja.DataSource = lista;
            cmb_ncaja.DisplayMember = "Name";
            cmb_ncaja.ValueMember = "Value";
        }

        private void _bloqueo(Boolean var)
        {
            cmb_ncaja.Enabled = var;
            perimes.Enabled = var;
            btn_save.Enabled = var;
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            _bloqueo(true);
        }

        private void _ponerValorCombo()
        {
            if (_cajanume.ToString().Length == 2)
            {
                cmb_ncaja.Text = _cajanume.ToString();
            }
            else
            {
                cmb_ncaja.SelectedIndex = 0;
            }
        }
    }
}
