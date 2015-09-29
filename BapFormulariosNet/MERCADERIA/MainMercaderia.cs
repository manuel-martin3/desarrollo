using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerDataAccess;
using LayerBusinessLogic;
using bapFunciones;
using System.Xml;
using System.IO;

namespace BapFormulariosNet.MERCADERIA
{
    public partial class MainMercaderia : DevExpress.XtraEditors.XtraForm
    {
        private System.Reflection.Assembly Ensamblado;
        private ConfigXml mCfg;

        private string TituloForm = string.Empty;
        private String _servername = string.Empty, _servername2 = string.Empty;
        private String _database = string.Empty, _database2 = string.Empty;
        private String _user = string.Empty, _user2 = string.Empty;
        private String _password = string.Empty, _password2 = string.Empty;
        private String _cajanume = string.Empty;
        //private String _perimes = string.Empty;

        #region Variables Publicas para este MDI

        private string _perfil;
        public string perfil
        {
            get { return _perfil; }
            set { _perfil = value; }
        }

        private string _perianio;
        public string perianio
        {
            get { return _perianio; }
            set { _perianio = value; }
        }

        private string _perimes;
        public string perimes
        {
            get { return _perimes; }
            set { _perimes = value; }
        }

        private DateTime _fechdigini;
        public DateTime fechdigini
        {
            get { return _fechdigini; }
            set { _fechdigini = value; }
        }

        private DateTime _fechdigfin;
        public DateTime fechdigfin
        {
            get { return _fechdigfin; }
            set { _fechdigfin = value; }
        }

        private string _dominioid;
        public string dominioid
        {
            get { return _dominioid; }
            set { _dominioid = value; }
        }

        private string _moduloid;
        public string moduloid
        {
            get { return _moduloid; }
            set { _moduloid = value; }
        }

        private String _moduloname;
        public String moduloname
        {
            get { return _moduloname; }
            set { _moduloname = value; }
        }

        private string _local;
        public string local
        {
            get { return _local; }
            set { _local = value; }
        }

        private string _localname;
        public string localname
        {
            get { return _localname; }
            set { _localname = value; }
        }

        private string _ctacte;
        public string ctacte
        {
            get { return _ctacte; }
            set { _ctacte = value; }
        }

        private string _ctactename;
        public string ctactename
        {
            get { return _ctactename; }
            set { _ctactename = value; }
        }


        private string _direcnume;
        public string direcnume
        {
            get { return _direcnume; }
            set { _direcnume = value; }
        }

        private bool _novalidastock;
        public bool novalidastock
        {
            get { return _novalidastock; }
            set { _novalidastock = value; }
        }

        private bool _editnumdoc;
        public bool editnumdoc
        {
            get { return _editnumdoc; }
            set { _editnumdoc = value; }
        }

        private string _estabsunat;
        public string estabsunat
        {
            get { return _estabsunat; }
            set { _estabsunat = value; }
        }

        private DateTime _localfeuiv;
        public DateTime localfeuiv
        {
            get { return _localfeuiv; }
            set { _localfeuiv = value; }
        }

        

        #endregion
     

        public MainMercaderia()
        {
            InitializeComponent();

            _RecuperaAdmConexion();
            _RecuperaEmpConexion();

            _RecuperarNcaja();
            StatusBar();
        }

        private void MainMenuAlmacen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Quieres cerrar el Módulo?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private DataTable dtMenuItems = new DataTable();
        private string appPath = string.Empty;

        private void MainMercaderia_Load(object sender, EventArgs e)
        {
            //Metodo_VariablesPublicas();
            Metodo_VariablesStatic();

            //Ensamblado = System.Reflection.Assembly.GetExecutingAssembly();
            //try
            //{
            //    perfil = VariablesPublicas.Perfil;
            //    appPath = Application.ExecutablePath;

            //    var usuariosBL = new usuariosBL();
            //    var COD_USU = Convert.ToString(VariablesPublicas.Usuar);
            //    dtMenuItems = usuariosBL.GenerarMenuXperfil(VariablesPublicas.EmpresaID, COD_USU, VariablesPublicas.Perfil).Tables[0];

            //    mainMenu.Items.Clear();
            //    appPath = appPath.Substring(0, 28) + "Iconos\\";

            //    for (var nMain = 0; nMain < dtMenuItems.Rows.Count; nMain++)
            //    {
            //        if (dtMenuItems.Rows[nMain]["menid"].Equals(dtMenuItems.Rows[nMain]["padid"]))
            //        {
            //            var tsmMain = new ToolStripMenuItem(dtMenuItems.Rows[nMain]["descr"].ToString());
            //            if (dtMenuItems.Rows[nMain]["icono"].ToString().Trim().Length > 0)
            //            {
            //                tsmMain.Image = Bitmap.FromFile(appPath + dtMenuItems.Rows[nMain]["icono"].ToString().Trim());
            //            }
            //            mainMenu.Items.Add(tsmMain);
            //            AddSubMenu(dtMenuItems.Rows[nMain]["menid"].ToString(), tsmMain);
            //        }
            //    }
            //    Controls.Add(mainMenu);
            //}
            //catch
            //{
            //}
        }

        private void Metodo_VariablesPublicas()
        {
            Ensamblado = System.Reflection.Assembly.GetExecutingAssembly();
            try
            {
                perfil = VariablesPublicas.Perfil;
                appPath = Application.ExecutablePath;

                //perfil items Usuario
                usuariosBL usuariosBL = new usuariosBL();
                tb_usuarios tb_usuarios = new tb_usuarios();
                string COD_USU = Convert.ToString(VariablesPublicas.Usuar);
                dtMenuItems = usuariosBL.GenerarMenuXperfil(VariablesPublicas.EmpresaID, COD_USU, VariablesPublicas.Perfil).Tables[0];

                mainMenu.Items.Clear();
                appPath = appPath.Substring(0, 28) + "Iconos\\";

                /*************************************************************************/
                //MenuStrip menu = new MenuStrip();
                for (int nMain = 0; nMain < dtMenuItems.Rows.Count; nMain++)
                {
                    if (dtMenuItems.Rows[nMain]["menid"].Equals(dtMenuItems.Rows[nMain]["padid"]))
                    {
                        ToolStripMenuItem tsmMain = new ToolStripMenuItem(dtMenuItems.Rows[nMain]["descr"].ToString());
                        //tsmMain.DisplayStyle = ToolStripItemDisplayStyle.Text;
                        if (dtMenuItems.Rows[nMain]["icono"].ToString().Trim().Length > 0)
                        {
                            tsmMain.Image = Bitmap.FromFile(appPath + dtMenuItems.Rows[nMain]["icono"].ToString().Trim());
                        }
                        mainMenu.Items.Add(tsmMain);
                        AddSubMenu(dtMenuItems.Rows[nMain]["menid"].ToString(), tsmMain);
                    }
                }
                this.Controls.Add(mainMenu);
            }
            catch
            {
                //Response.Redirect("~/Login02.aspx");
            }
        }

        private void Metodo_VariablesStatic()
        {
            Ensamblado = System.Reflection.Assembly.GetExecutingAssembly();
            try
            {
                appPath = Application.ExecutablePath;

                //perfil items Usuario
                usuariosBL usuariosBL = new usuariosBL();
                tb_usuarios tb_usuarios = new tb_usuarios();
                string COD_USU = Convert.ToString(VariablesPublicas.Usuar);
                dtMenuItems = usuariosBL.GenerarMenuXperfil(VariablesPublicas.EmpresaID, COD_USU, _perfil).Tables[0];

                mainMenu.Items.Clear();
                appPath = appPath.Substring(0, 28) + "Iconos\\";

                /*************************************************************************/
                //MenuStrip menu = new MenuStrip();
                for (int nMain = 0; nMain < dtMenuItems.Rows.Count; nMain++)
                {
                    if (dtMenuItems.Rows[nMain]["menid"].Equals(dtMenuItems.Rows[nMain]["padid"]))
                    {
                        ToolStripMenuItem tsmMain = new ToolStripMenuItem(dtMenuItems.Rows[nMain]["descr"].ToString());
                        //tsmMain.DisplayStyle = ToolStripItemDisplayStyle.Text;
                        if (dtMenuItems.Rows[nMain]["icono"].ToString().Trim().Length > 0)
                        {
                            tsmMain.Image = Bitmap.FromFile(appPath + dtMenuItems.Rows[nMain]["icono"].ToString().Trim());
                        }
                        mainMenu.Items.Add(tsmMain);
                        AddSubMenu(dtMenuItems.Rows[nMain]["menid"].ToString(), tsmMain);
                    }
                }
                this.Controls.Add(mainMenu);
            }
            catch
            {
                //Response.Redirect("~/Login02.aspx");
            }
        }

        private void MainAlmacen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Quieres cerrar el Módulo?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void AddSubMenu(string sId, ToolStripMenuItem main)
        {
            String nameForm;
            foreach (System.Data.DataRow drMenuItem in dtMenuItems.Rows)
            {
                if (drMenuItem["padid"].ToString().Equals(sId) && !drMenuItem["menid"].Equals(drMenuItem["padid"]))
                {
                    var tsmSub = new ToolStripMenuItem(drMenuItem["descr"].ToString());
                    nameForm = drMenuItem["pgurl"].ToString();
                    tsmSub.Tag = drMenuItem["pgurl"].ToString();
                    if (drMenuItem["icono"].ToString().Trim().Length > 0)
                    {
                        tsmSub.Image = Bitmap.FromFile(appPath + drMenuItem["icono"].ToString().Trim());
                    }
                    tsmSub.Name = drMenuItem["pgurl"].ToString();

                    tsmSub.Click += new EventHandler(MenuItemClicked);
                    main.DropDownItems.Add(tsmSub);
                    AddSubMenu(drMenuItem["menid"].ToString(), tsmSub);
                }
            }
        }

        private void MenuItemClicked(object sender, EventArgs e)
        {
            try
            {
                if (sender.GetType() == typeof(ToolStripMenuItem))
                {
                    var NombreFormulario = ((ToolStripItem)sender).Tag.ToString();
                    Object ObjFrm;
                    var tipo = Ensamblado.GetType(Ensamblado.GetName().Name + "." + NombreFormulario);
                    if (tipo == null)
                    {
                    }
                    else
                    {
                        if (!FormularioEstaAbierto(NombreFormulario))
                        {
                            ObjFrm = Activator.CreateInstance(tipo);
                            var Formulario = (plantilla)ObjFrm;
                            Formulario.MdiParent = this;
                            Formulario.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private Boolean FormularioEstaAbierto(String NombreDelFrm)
        {
            if (MdiChildren.Length > 0)
            {
                for (var i = 0; i < MdiChildren.Length; i++)
                {
                    if (MdiChildren[i].Name == NombreDelFrm.Substring(NombreDelFrm.IndexOf("Frm_"), NombreDelFrm.Length - NombreDelFrm.IndexOf("Frm_")))
                    {
                        MessageBox.Show("El formulario solicitado ya se encuentra abierto");
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        private void abrir_formulario2(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(ToolStripMenuItem))
            {
                var ClickedItemText = ((ToolStripItem)sender).Name;

                MessageBox.Show(ClickedItemText);

                switch (ClickedItemText)
                {
                    case "Exit":
                        Application.Exit();
                        break;
                }
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

        private void FijarParametrosLocales()
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

                mCfg.SetValue("Paramlocal", "cajanume", "01");
                //mCfg.SetValue("Paramlocal", "perimes", VariablesPublicas.perimes);
                mCfg.SetValue("Paramlocal", "perimes", _perimes);

                mCfg.Save();
                MessageBox.Show("Se fijaron parametros locales por default.  Verifique ...!!!");
            }
        }

        private void _RecuperarNcaja()
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

                if (nperimes[i] == null)
                {
                    FijarParametrosLocales();
                    _RecuperarNcaja();
                }
                _cajanume = ncajanume[i] == null ? "01" : ncajanume[i].InnerText;
                //_perimes = nperimes[i] == null ? VariablesPublicas.perimes : nperimes[i].InnerText;
                _perimes = nperimes[i] == null ? _perimes : nperimes[i].InnerText;
            }
        }


        public void StatusBar()
        {
            lblUsuario.Text = VariablesPublicas.Nombr;
            lblCompany.Text = VariablesPublicas.EmpresaName;
            lblPeriodo.Text = _perianio;    //VariablesPublicas.perianio;


            var BL2 = new sys_localBL();
            var BE2 = new tb_sys_local();
            var dt2 = new DataTable();
            BE2.dominioid = _dominioid; // VariablesPublicas.Dominioid.ToString();
            BE2.moduloid = _moduloid; //VariablesPublicas.Moduloid.ToString();
            BE2.local = _local; //VariablesPublicas.Local.ToString();
            dt2 = BL2.GetAll(VariablesPublicas.EmpresaID, BE2).Tables[0];
            if (dt2.Rows.Count > 0)
            {
                var xxmesid = string.Empty;
                if (Convert.ToBoolean(dt2.Rows[0]["perimeslocal"]))
                {
                    xxmesid = _perimes;
                    lblncaja.Text = _cajanume.ToString();
                }
                else
                {
                    xxmesid = _perimes; //VariablesPublicas.perimes.ToString();
                    lblncaja.Text = _cajanume.ToString();
                }
                var BL = new tb_co_mesesBL();
                var dt = new DataTable();
                dt = BL.GetOne(VariablesPublicas.EmpresaID, xxmesid.ToString()).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    lblperimes.Text = dt.Rows[0]["mesname"].ToString();
                }
            }


            //lblalmacen.Text = VariablesPublicas.EmpresaTipo;
            lblalmacen.Text = _moduloname;
            lblVersion.Text = ProductVersion;

            TituloForm = "ERP - Bapsoft.Net - " + _moduloname + " - ";
            //Text = ((TituloForm + lblCompany.Text + "  »» LOCAL »»  " + VariablesPublicas.nombrelocal.ToString()));
            Text = ((TituloForm + lblCompany.Text + "  »» LOCAL »»  " + _localname));
        }

        private void btnPedidoAlmacen_Click(object sender, EventArgs e)
        {
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_precios_Click(object sender, EventArgs e)
        {
            try
            {
                var modd = string.Empty;
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();

                BE.dominioid = _dominioid;  //VariablesPublicas.Dominioid;
                BE.moduloid = _moduloid;    //VariablesPublicas.Moduloid;
                dt = BL.GetAll(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();
                        var frmayuda = new Ayudas.Form_help_productoprecio();

                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = " << *** Ayudas *** >>";
                        frmayuda.sqlquery =
                                "SELECT tb1.productid " +
                                ", tb2.productname " +
                                ", tb1.stock " +
                                ", tb1.costopromed " +
                                ", tb1.valoractual as StockValor " +
                                ", tb1.costoultimo as CostoSoles " +
                                ", tb3.compra as Tcamb" +
                                ", cast(tb1.costoultimo/cast(tb3.compra as decimal(10,4)) as decimal (10,4))as CostoDolar " +
                                " FROM  tb_" + modd + "_local_stock as tb1 ";
                        frmayuda.sqlinner =
                            "INNER JOIN tb_" + modd + "_productos as tb2 ON tb1.productid = tb2.productid " +
                            "INNER JOIN tb_tipocambio as tb3 ON tb3.fecha = CONVERT(date, GETDATE(), 103) ";
                        frmayuda.sqlwhere =
                            "Where " +
                            //"tb1.local = '" + VariablesPublicas.Local + "'" +
                            "tb1.local = '" + _local + "'" +
                            "and tb2.status= 0 ";
                        frmayuda.sqland = "and";
                        frmayuda.criteriosbusqueda = new string[] { "PRODUCTO", "CODIGO" };
                        frmayuda.columbusqueda = "tb2.productname,tb1.productid";
                        frmayuda.returndatos = "0,1";
                        frmayuda.Owner = this;
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btn_InforProd_Click(object sender, EventArgs e)
        {
        }

        private void btn_information_Click(object sender, EventArgs e)
        {
            var BL = new sys_formulariosBL();
            var BE = new tb_sys_formulario();
            var DataFunc = new DataTable();

            BE.dominioid = _dominioid;  //VariablesPublicas.Dominioid;
            BE.moduloid = _moduloid;    //VariablesPublicas.Moduloid;
            BE.formname = Name;
            DataFunc = BL.GetAll(VariablesPublicas.EmpresaID, BE).Tables[0];

            if (DataFunc.Rows.Count > 0)
            {
                var frm = new POPUP.Frm_webbrowser_single();
                frm.webBrowser1.DocumentText = DataFunc.Rows[0]["formfunc"].ToString().Trim();
                frm.ShowDialog();
            }
        }
    }
}
