using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.IO;
using DevComponents.DotNetBar;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using LayerDataAccess;
//using System.Data.SqlClient;
using System.Deployment.Application;
using System.Net;
using System.Collections;

namespace BapFormulariosNet.Login
{
    public partial class Frm_Login : DevComponents.DotNetBar.OfficeForm
    {
        Genericas fungen = new Genericas();
        SimpleAES funcript = new SimpleAES();

        DataTable tmpcursor = new DataTable();
        DataTable tmptabla = new DataTable();
        DataTable Tdominio = new DataTable();

        private System.Reflection.Assembly Ensamblado;             
        private static string mLocation;

        #region -- Variables Estaticas
        private static string _perfil;
        private static string _perianio;
        private static string _perimes;
        private static DateTime _fechdigini;
        private static DateTime _fechdigfin;
        private static string _dominioid;
        private static string _moduloid;
        private static string _moduloname;
        private static string _local;
        private static string _localname;
        private static string _ctacte;
        private static string _ctactename;
        private static string _direcnume;
        private static bool _novalidastock;
        private static bool _editnumdoc;
        private static string _estabsunat;
        private static DateTime _localfeuiv;
        #endregion

        public static List<string> listaDominioModuloid = new List<string>();
        public static Type GetType(string typeName)
        {
            var type = Type.GetType(typeName);
            if (type != null)
            {
                return type;
            }
            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = a.GetType(typeName);
                if (type != null)
                {
                    return type;
                }
            }
            return null;
        }

        public static SortedList formInstances = new SortedList();
        public static Form AbrirVentana(Type type)
        {
            return AbrirVentana(type, false);
        }

        public static Form AbrirVentana(Type type, bool dialog)
        {
            var ObjMDI = GetType(type.FullName);
            var insertNuevoElemento = listaDominioModuloid.Find(r => r == _dominioid + _moduloid) == null ? true : false;

            Form formulario;

            if (((formulario = (Form)formInstances[type.ToString()]) == null || formulario.IsDisposed) == false)
            {
                if (insertNuevoElemento)
                {
                    listaDominioModuloid.Add(_dominioid + _moduloid);

                    formulario = (Form)Activator.CreateInstance(type);
                    formInstances[type.ToString()] = formulario;
                }
                else
                {
                    MessageBox.Show("Módulo ya abierto, verifique...");
                }
            }


            if ((formulario = (Form)formInstances[type.ToString()]) == null || formulario.IsDisposed)
            {
                listaDominioModuloid.Add(_dominioid + _moduloid);

                formulario = (Form)Activator.CreateInstance(type);
                formInstances[type.ToString()] = formulario;
            }

            formulario.Activate();
            formulario.WindowState = FormWindowState.Normal;

            ObjMDI.GetProperty("perfil").SetValue(formulario, _perfil, null);
            ObjMDI.GetProperty("perianio").SetValue(formulario, _perianio, null);
            ObjMDI.GetProperty("perimes").SetValue(formulario, _perimes, null);
            ObjMDI.GetProperty("fechdigini").SetValue(formulario, _fechdigini, null);
            ObjMDI.GetProperty("fechdigfin").SetValue(formulario, _fechdigfin, null);
            ObjMDI.GetProperty("dominioid").SetValue(formulario, _dominioid, null);
            ObjMDI.GetProperty("moduloid").SetValue(formulario, _moduloid, null);
            ObjMDI.GetProperty("moduloname").SetValue(formulario, _moduloname, null);
            ObjMDI.GetProperty("local").SetValue(formulario, _local, null);
            ObjMDI.GetProperty("localname").SetValue(formulario, _localname, null);
            ObjMDI.GetProperty("ctacte").SetValue(formulario, _ctacte, null);
            ObjMDI.GetProperty("ctactename").SetValue(formulario, _ctactename, null);
            ObjMDI.GetProperty("direcnume").SetValue(formulario, _direcnume, null);
            ObjMDI.GetProperty("novalidastock").SetValue(formulario, _novalidastock, null);
            ObjMDI.GetProperty("editnumdoc").SetValue(formulario, _editnumdoc, null);
            ObjMDI.GetProperty("estabsunat").SetValue(formulario, _estabsunat, null);
            ObjMDI.GetProperty("localfeuiv").SetValue(formulario, _localfeuiv, null);


            if (dialog)
            {
                formulario.ShowDialog();
            }
            else
            {
                formulario.Show();
            }
            return formulario;
        }

        private D60Tienda.MainTienda _MainTienda = null;
        private D60Tienda.MainTienda _MainTiendaInstance
        {
            get
            {
                if (_MainTienda == null)
                {
                    _MainTienda = new D60Tienda.MainTienda();
                    _MainTienda.Disposed += new EventHandler(_MainTienda_Disposed);
                }

                return _MainTienda;
            }
        }

        private void _MainTienda_Disposed(object sender, EventArgs e)
        {
            _MainTienda = null;
        }



        private APT600100.MainAlmacenPT _MainAlmacenPT = null;
        private APT600100.MainAlmacenPT _MainAlmacenPTInstance
        {
            get
            {
                if (_MainAlmacenPT == null)
                {
                    _MainAlmacenPT = new APT600100.MainAlmacenPT();
                    _MainAlmacenPT.Disposed += new EventHandler(_MainAlmacenPT_Disposed);
                }

                return _MainAlmacenPT;
            }
        }

        private void _MainAlmacenPT_Disposed(object sender, EventArgs e)
        {
            _MainAlmacenPT = null;
        }

        //

        private D60ALMACEN.MainAlmacen _MainAlmacen = null;
        private D60ALMACEN.MainAlmacen _MainAlmacenInstance
        {
            get
            {
                if (_MainAlmacen == null)
                {
                    _MainAlmacen = new D60ALMACEN.MainAlmacen();
                    _MainAlmacen.Disposed += new EventHandler(_MainAlmacen_Disposed);
                }

                return _MainAlmacen;
            }
        }

        private void _MainAlmacen_Disposed(object sender, EventArgs e)
        {
            _MainAlmacen = null;
        }

        private DL0Logistica.MainLogistica _MainLogistica = null;
        private DL0Logistica.MainLogistica _MainLogisticaInstance
        {
            get
            {
                if (_MainLogistica == null)
                {
                    _MainLogistica = new DL0Logistica.MainLogistica();
                    _MainLogistica.Disposed += new EventHandler(_MainLogistica_Disposed);
                }

                return _MainLogistica;
            }
        }

        private void _MainLogistica_Disposed(object sender, EventArgs e)
        {
            _MainLogistica = null;
        }

        private D70Produccion.MainProduccion _MainProduccion = null;
        private D70Produccion.MainProduccion _MainProduccionInstance
        {
            get
            {
                if (_MainProduccion == null)
                {
                    _MainProduccion = new D70Produccion.MainProduccion();
                    _MainProduccion.Disposed += new EventHandler(_MainProduccion_Disposed);
                }

                return _MainProduccion;
            }
        }

        private void _MainProduccion_Disposed(object sender, EventArgs e)
        {
            _MainProduccion = null;
        }

        private MERCADERIA.MainMercaderia _MainMercaderia = null;
        private MERCADERIA.MainMercaderia _MainMercaderiaInstance
        {
            get
            {
                if (_MainMercaderia == null)
                {
                    _MainMercaderia = new MERCADERIA.MainMercaderia();
                    _MainMercaderia.Disposed += new EventHandler(_MainMercaderia_Disposed);
                }

                return _MainMercaderia;
            }
        }

        private void _MainMercaderia_Disposed(object sender, EventArgs e)
        {
            _MainMercaderia = null;
        }

        private MERCADERIA02.MainMercaderia02 _MainMercaderia02 = null;
        private MERCADERIA02.MainMercaderia02 _MainMercaderia02Instance
        {
            get
            {
                if (_MainMercaderia02 == null)
                {
                    _MainMercaderia02 = new MERCADERIA02.MainMercaderia02();
                    _MainMercaderia02.Disposed += new EventHandler(_MainMercaderia02_Disposed);
                }

                return _MainMercaderia02;
            }
        }

        private void _MainMercaderia02_Disposed(object sender, EventArgs e)
        {
            _MainMercaderia02 = null;
        }

        private RecursosHumanos.MainRecursosHumanos _MainRecursosHumanos = null;
        private RecursosHumanos.MainRecursosHumanos _MainRecursosHumanosInstance
        {
            get
            {
                if (_MainRecursosHumanos == null)
                {
                    _MainRecursosHumanos = new RecursosHumanos.MainRecursosHumanos();
                    _MainRecursosHumanos.Disposed += new EventHandler(_MainRecursosHumanos_Disposed);
                }

                return _MainRecursosHumanos;
            }
        }

        private void _MainRecursosHumanos_Disposed(object sender, EventArgs e)
        {
            _MainRecursosHumanos = null;
        }

        private D20Comercial.MainComercial _MainComercial = null;
        private D20Comercial.MainComercial _MainComercialInstance
        {
            get
            {
                if (_MainComercial == null)
                {
                    _MainComercial = new D20Comercial.MainComercial();
                    _MainComercial.Disposed += new EventHandler(_MainComercial_Disposed);
                }

                return _MainComercial;
            }
        }

        private void _MainComercial_Disposed(object sender, EventArgs e)
        {
            _MainComercial = null;
        }

        private BapFormulariosNet.DS0Seguridad.MainSeguridad _MainSeguridad = null;
        private BapFormulariosNet.DS0Seguridad.MainSeguridad _MainSeguridadInstance
        {
            get
            {
                if (_MainSeguridad == null)
                {
                    _MainSeguridad = new BapFormulariosNet.DS0Seguridad.MainSeguridad();
                    _MainSeguridad.Disposed += new EventHandler(_MainSeguridad_Disposed);
                }

                return _MainSeguridad;
            }
        }

        private void _MainSeguridad_Disposed(object sender, EventArgs e)
        {
            _MainSeguridad = null;
        }




        public Frm_Login()
        {
            InitializeComponent();
            mLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
            getIdentificarPC();
        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {
            Ensamblado = System.Reflection.Assembly.GetExecutingAssembly();
            llenar_cboEmpresas();
            MessageBoxEx.EnableGlass = false;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                //Version version1 = MyProject.Application.Deployment.CurrentVersion;
                //this.Text += " - [v: " + System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() + "]";
                Version version1 = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
                int i2 = version1.Major;
                int i3 = version1.Minor;
                int i1 = version1.Build;
                int i4 = version1.Revision;
                string s1 = version1.ToString();
                version1 = null;
                object[] objArr1 = new object[] { i2, i3, i1, i4 };
                VariablesPublicas.cVersion = "Versión " + string.Format("{0}.{1}.{2}.{3}", objArr1);
            }
            else
            {
                VariablesPublicas.cVersion = "Versión no Publicada";
            }
            lblVersion.Text = VariablesPublicas.cVersion;
            labelVersion.Text = VariablesPublicas.cVersion;
            label1.Text = "2011  -  " + DateTime.Now.Year.ToString() + "  LIMA-PERÚ - Todos los Derechos Reservados";
            label5.Text = "2011  -  " + DateTime.Now.Year.ToString() + "  LIMA-PERÚ - Todos los Derechos Reservados";
            txtPeriodo.Value = Convert.ToInt32(DateTime.Now.Year);  //.Now; dtpFecha.Value.Year.ToString();
            //txtPeriodo.Value = Convert.ToInt32(VariablesPublicas.perianio);
            Conexion();
        }
        private void Frm_Login_Activated(object sender, EventArgs e)
        {
            if (VariablesPublicas.CerrarSession)
            {
                panelEx2.Visible = false;
                panelEx1.Visible = true;
                VariablesPublicas.CerrarSession = false;
            }
            //cboEmpresa.Focus();
            txtUsuar.Focus();
        }  
        private void Frm_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private String get_iplocal()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

        private void getIdentificarPC()
        {
            string username = String.Format(@"{0}\{1}", Environment.UserDomainName, Environment.UserName);
            System.Security.Principal.WindowsIdentity id = System.Security.Principal.WindowsIdentity.GetCurrent();
            string sid = id.User.AccountDomainSid.ToString();

            VariablesPublicas.userip = username + ' ' + get_iplocal();
            //VariablesPublicas.userip = username;
            lblIp.Text = VariablesPublicas.userip;
        }

        private void llenar_cboEmpresas()
        {
            try
            {
                cboEmpresa.DataSource = NewMethod();
                cboEmpresa.DisplayMember = "Value";
                cboEmpresa.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBoxEx.Show("Ban Muon <font color='#B02B2C'>Thoat</font>", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }
        private BindingSource NewMethod()
        {
            empresasBL BL = new empresasBL();
            tb_empresa BE = new tb_empresa();

            DataTable table = BL.GetAll(BE).Tables[0];
            DataRowCollection rows = table.Rows;

            object[] cell;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            BindingSource binding = new BindingSource();

            foreach (DataRow item in rows)
            {
                cell = item.ItemArray;
                dic.Add(cell[0].ToString(), cell[0].ToString() + " - " + cell[1].ToString());
                cell = null;
            }
            binding.DataSource = dic;
            return binding;
        }

        private void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtUsuar.Text = string.Empty;
                txtClave.Text = string.Empty;
                txtUsuar.Focus();

                empresasBL BL = new empresasBL();
                tb_empresa BE = new tb_empresa();

                DataTable dt2 = new DataTable();

                BE.empresaid = cboEmpresa.Text.Substring(0, 2).Trim().PadLeft(2, '0');

                dt2 = BL.GetAll(BE).Tables[0];

                if (dt2.Rows.Count > 0)
                {
                    VariablesPublicas.EmpresaID = dt2.Rows[0]["empresaid"].ToString();
                    VariablesPublicas.EmpresaName = dt2.Rows[0]["empresaname"].ToString().Trim();
                    VariablesPublicas.EmpresaRuc = dt2.Rows[0]["empresaruc"].ToString();
                    VariablesPublicas.EmpresaDirecc = dt2.Rows[0]["empresadirec"].ToString();
                    VariablesPublicas.EmpresaTelef = dt2.Rows[0]["empresatelef"].ToString();
                    VariablesPublicas.EmpresaSigla = dt2.Rows[0]["empresasigla"].ToString().Trim();

                    if (dt2.Rows[0]["foto"].ToString().Trim().Length != 0)
                    {
                        VariablesPublicas.EmpresaLogo = dt2.Rows[0]["foto"].ToString();
                    }
                    else
                    {
                        VariablesPublicas.EmpresaLogo = "nologoempresa.png";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            usuariosBL usuariosBL = new usuariosBL();
            tb_usuarios tb_usuarios = new tb_usuarios();

            DataTable dt = new DataTable();
            String xClave = null;
            Boolean xadmin = false; Boolean xactivo = false;
            tb_usuarios.usuar = txtUsuar.Text.Trim().ToLower();

            if (ValidarIngreso())
            {
                dt = usuariosBL.GetAll(cboEmpresa.SelectedValue.ToString(), tb_usuarios).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    xClave = Convert.ToString(dt.Rows[0]["CLAVE"]);
                    xadmin = Convert.ToBoolean(dt.Rows[0]["admin"]);
                    xactivo = Convert.ToBoolean(dt.Rows[0]["activo"]);

                    txtClave.Text = fungen.GetMD5(txtClave.Text.ToLower()).Substring(0, 10);
                    if (txtClave.Text.ToUpper() == xClave)
                    {
                        if (xactivo == false)
                        {
                            Empresa();
                            MessageBoxEx.Show("Usuario fue dado de baja !!!" + "\r" + "Consulte con el administrador de sistemas?", "BapSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            Empresa();
                            VariablesPublicas.Usuar = Convert.ToString(dt.Rows[0]["usuar"]).Trim();

                            abrir_perfiles();
                            if (Tdominio.Rows.Count > 0)
                            {
                                get_cargafoto();
                                panelEx1.Visible = false;
                                panelEx2.Visible = true;
                                Text = "Panel de Control - " + VariablesPublicas.SiconexionInternet;
                                cboDominioID.Focus();
                            }
                        }
                        //superValidator1.Enabled = false;
                    }
                    else
                    {
                        MessageBoxEx.Show("Clave Incorrecto !!!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBoxEx.Show("Usuario no Registrado !!!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void Empresa()
        {
            try
            {
                txtUsuar.Text = "";
                txtClave.Text = "";
                txtUsuar.Focus();

                empresasBL BL = new empresasBL();
                tb_empresa BE = new tb_empresa();

                DataTable dt2 = new DataTable();

                BE.empresaid = cboEmpresa.SelectedValue.ToString();
                dt2 = BL.GetAll(BE).Tables[0];

                VariablesPublicas.EmpresaID = dt2.Rows[0]["empresaid"].ToString();
                VariablesPublicas.EmpresaName = dt2.Rows[0]["empresaname"].ToString();
                VariablesPublicas.EmpresaRuc = dt2.Rows[0]["empresaruc"].ToString();

                if (dt2.Rows[0]["foto"].ToString().Trim().Length != 0)
                {
                    VariablesPublicas.EmpresaLogo = dt2.Rows[0]["foto"].ToString();
                }
                else
                {
                    VariablesPublicas.EmpresaLogo = "nologoempresa.png";
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidarIngreso()
        {
            if (String.IsNullOrEmpty(txtUsuar.Text.Trim()))
            {
                errorProvider1.SetError(txtUsuar, "Escriba el nombre del usuario");
                txtUsuar.Focus();
                return false;
            }
            else
            {
                if (String.IsNullOrEmpty(txtClave.Text.Trim()))
                {
                    errorProvider1.SetError(txtClave, "Escriba la contraseña");
                    txtClave.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private void abrir_perfiles()
        {
            get_cargarComboDominio();
        }

        private void get_cargarComboDominio()
        {
            sys_dominioBL BL = new sys_dominioBL();
            tb_sys_dominio BE = new tb_sys_dominio();
            DataTable dt = new DataTable();
            Tdominio = BL.GetAllDominioPorUsuario(VariablesPublicas.EmpresaID, VariablesPublicas.Usuar).Tables[0];
            if (Tdominio.Rows.Count > 0)
            {
                try
                {
                    dt = BL.GetAllDominioPorUsuario(VariablesPublicas.EmpresaID, VariablesPublicas.Usuar).Tables[0];
                    cboDominioID.DataSource = dt;
                    cboDominioID.ValueMember = "dominioid";
                    cboDominioID.DisplayMember = "dominioname";
                }
                catch (Exception ex)
                {
                    MessageBoxEx.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                get_cbo_modulo();
            }
            else
            {
                MessageBoxEx.Show("Usuario no tiene definido Dominio y Módulo... " + "\r" + "Consulte con Sistemas !!!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void get_cbo_modulo()
        {
            sys_dominioBL BL = new sys_dominioBL();
            tb_sys_dominio BE = new tb_sys_dominio();
            DataTable dt = new DataTable();
            try
            {
                dt = BL.GetAllDominioModuloPorUsuario(VariablesPublicas.EmpresaID, VariablesPublicas.Usuar, cboDominioID.SelectedValue.ToString()).Tables[0];
                cboModuloID.DataSource = dt;
                cboModuloID.ValueMember = "moduloid";
                cboModuloID.DisplayMember = "moduloname";
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (cboModuloID.Items.Count > 0)
            {
                get_dominio_modulo_local(cboDominioID.SelectedValue.ToString(), cboModuloID.SelectedValue.ToString());
            }

        }

        private void get_dominio_modulo_local(string dominioid, string moduloid)
        {
            usuariomodulolocalBL BL = new usuariomodulolocalBL();
            tb_usuariomodulolocal BE = new tb_usuariomodulolocal();
            DataTable dt = new DataTable();
            BE.usuar = VariablesPublicas.Usuar;
            BE.dominioid = dominioid;
            BE.moduloid = moduloid;

            try
            {
                dt = BL.GetAll3(VariablesPublicas.EmpresaID, BE).Tables[0];
                cboLocal.DataSource = dt;
                cboLocal.ValueMember = "local";
                cboLocal.DisplayMember = "localname";

                //get_constantesGen(cboDominioID.SelectedValue.ToString(), cboModuloID.SelectedValue.ToString(), cboLocal.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void get_constantesGen(String dominioid, String moduloid, String local)
        {
            constantesgeneralesBL BL = new constantesgeneralesBL();
            tb_constantesgenerales BE = new tb_constantesgenerales();
            DataTable dt = new DataTable();

            try
            {
                dt = BL.GetOne(VariablesPublicas.EmpresaID, dominioid, moduloid, local).Tables[0];
                VariablesPublicas.perianio = dt.Rows[0]["perianio"].ToString().Trim();
                VariablesPublicas.perimes = dt.Rows[0]["perimes"].ToString().Trim();
                VariablesPublicas.igv = dt.Rows[0]["igv"].ToString().Trim();
                VariablesPublicas.fechdigini = dt.Rows[0]["fechdigini"].ToString().Trim();
                VariablesPublicas.fechdigfin = dt.Rows[0]["fechdigfin"].ToString().Trim();
            }
            catch (Exception ex)
            {
                ex.ToString();
                VariablesPublicas.perianio = "";
                VariablesPublicas.perimes = "";
                VariablesPublicas.igv = "";
                VariablesPublicas.fechdigini = "";
                VariablesPublicas.fechdigfin = "";

                MessageBoxEx.Show("Registrar en constantes Generales !!!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void get_cargafoto()
        {
            try
            {
                usuariosBL usuariosBL = new usuariosBL();
                tb_usuarios tb_usuarios = new tb_usuarios();
                DataTable dt = new DataTable();
                tb_usuarios.usuar = VariablesPublicas.Usuar;

                dt = usuariosBL.GetAll(VariablesPublicas.EmpresaID, tb_usuarios).Tables[0];
                txtUsuarName.Text = dt.Rows[0]["nombr"].ToString().PadRight(30, ' ').Substring(0, 30);
                VariablesPublicas.Nombr = dt.Rows[0]["nombr"].ToString().PadRight(30, ' ').Substring(0, 30);

                byte[] bytes = { };

                //cnx = new SqlConnection(conex.empConexion(VariablesPublicas.EmpresaID));
                //cmd = new SqlCommand("Select fotografia From tb_usuarios Where usuar=@usuar;", cnx);
                //cmd.Parameters.AddWithValue("@usuar", VariablesPublicas.Usuar.Trim());
                //SqlDataReader DR = null;
                //cnx.Open();
                //cmd.ExecuteNonQuery();
                //DR = cmd.ExecuteReader();
                if (dt.Rows[0]["foto"].ToString().Length != 0)
                {
                    //if (DR.HasRows)
                    //{
                    //    DR.Read();
                    //    byte[] BytesSQL = (byte[])DR[0];
                    //    MemoryStream Buffer = new MemoryStream(BytesSQL);
                    //    Bitmap Img = new Bitmap(Buffer);
                    //    foto.Image = Img;
                    //}

                    foto.Image = null;
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    byte[] MyData1 = (byte[])(dt.Rows[0]["foto"]);

                    if (!MyData1.SequenceEqual(bytes))
                    {
                        ms.Write(MyData1, 0, MyData1.Length);
                        System.Drawing.Bitmap b = new Bitmap(ms);
                        foto.SizeMode = PictureBoxSizeMode.StretchImage;
                        foto.Image = new System.Drawing.Bitmap(b);
                    }
                }
                //cnx.Close();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboDominioID_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_cbo_modulo();            
        }

        private void cboModuloID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModuloID.SelectedIndex != -1)
            {
                get_dominio_modulo_local(cboDominioID.SelectedValue.ToString(), cboModuloID.SelectedValue.ToString());
            }

            var BE = new tb_sys_modulo();

            BE.moduloid = cboModuloID.SelectedValue.ToString();
            BE.dominioid = cboDominioID.SelectedValue.ToString();

            try
            {
                var BL = new sys_moduloBL();
                var dt2 = new DataTable();
                var empresaid = string.Empty;

                if (Equivalencias.Left(cboEmpresa.Text, 2) == "[0")
                {
                    empresaid = "01";
                }
                else
                {
                    empresaid = Equivalencias.Left(cboEmpresa.Text, 2);
                }

                dt2 = BL.GetAll(empresaid, BE).Tables[0];

                if (dt2.Rows.Count > 0)
                {
                    _moduloname = dt2.Rows[0]["moduloname"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Boolean NoHayFormulariosAbiertos()
        {
            Boolean xRet = true;
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() != typeof(Frm_Login))
                {
                    MessageBox.Show("Hay formularios abiertos, cierrelos para salir...?", "BapSoft");
                    xRet = false;
                    break;
                }
            }
            return xRet;
        }

        private Boolean FormularioEstaAbierto(String NombreDelFrm)
        {
            Form ExisteForm = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == NombreDelFrm).SingleOrDefault<Form>();
            if (ExisteForm != null)
            {
                //XtraMessageBox.Show("El formulario solicitado ya se encuentra abierto...?", "BapSoft");
                for (int i = 0; i <= ExisteForm.ToString().Length - 1; i++)
                {
                    if (ExisteForm.Visible)
                    {
                        ExisteForm.WindowState = FormWindowState.Maximized;
                        ExisteForm.Activate();
                        ExisteForm.Show();
                        break;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnOk2_Click(object sender, EventArgs e)
        {
            Metodo_VariablesStatic();
        }

        private void Metodo_VariablesStatic()
        {
            try
            {
                _dominioid = cboDominioID.SelectedValue.ToString();
                _moduloid = cboModuloID.SelectedValue.ToString();
                _local = cboLocal.SelectedValue.ToString();
                _localname = cboLocal.Text.ToString();
                _moduloname = cboModuloID.Text.ToString();
                _novalidastock = false;
                VariablesPublicas.perianio = txtPeriodo.Text.ToString().Trim();


                var BL1 = new usuariomodulolocalBL();
                var BE1 = new tb_usuariomodulolocal();
                var data = new DataTable();

                BE1.dominioid = cboDominioID.SelectedValue.ToString();
                BE1.moduloid = cboModuloID.SelectedValue.ToString();
                BE1.local = cboLocal.SelectedValue.ToString();

                data = BL1.GetAllDatos(VariablesPublicas.EmpresaID, BE1).Tables[0];
                if (data.Rows.Count > 0)
                {
                    _ctacte = data.Rows[0]["ctacte"].ToString();
                    _direcnume = data.Rows[0]["direcnume"].ToString();
                    _novalidastock = Convert.ToBoolean(data.Rows[0]["novalidastock"].ToString() == "True" ? 1 : 0);
                    _editnumdoc = Convert.ToBoolean(data.Rows[0]["editnumdoc"].ToString() == "True" ? 1 : 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            var xperfil = string.Empty;
            xperfil = cboDominioID.SelectedValue.ToString() + cboModuloID.SelectedValue.ToString();

            var BL = new usuariosBL();
            var BE = new tb_usuarios();
            var dt = new DataTable();

            BE.usuar = VariablesPublicas.Usuar.Trim();
            BE.idper = xperfil.Trim();
            dt = BL.GetAll_perfil(cboEmpresa.Text.Substring(0, 2), BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                _perfil = dt.Rows[0]["idper"].ToString();
            }
            else
            {
                MessageBox.Show("Asignar perfil a usuario !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (VariablesPublicas.EmpresaSigla == "WAMA" || VariablesPublicas.EmpresaSigla == "PRUEBAS")
            {
                if (_dominioid == "L0")
                {
                    if (_moduloid == "0100")
                    {
                        var frm = (DL0Logistica.MainLogistica)AbrirVentana(typeof(DL0Logistica.MainLogistica));
                        frm.perfil = _perfil;
                        frm.perianio = _perianio;
                        frm.perimes = _perimes;
                        frm.fechdigini = _fechdigini;
                        frm.fechdigfin = _fechdigfin;
                        frm.dominioid = _dominioid;
                        frm.moduloid = _moduloid;
                        frm.moduloname = _moduloname;
                        frm.local = _local;
                        frm.localname = _localname;
                        frm.ctacte = _ctacte;
                        frm.ctactename = _ctactename;
                        frm.direcnume = _direcnume;
                        frm.novalidastock = _novalidastock;
                        frm.editnumdoc = _editnumdoc;
                        frm.estabsunat = _estabsunat;
                        frm.localfeuiv = _localfeuiv;
                        frm.Show();
                    }
                }

                if (_dominioid == "70")
                {
                    if (_moduloid == "0900")
                    {
                        var frm = (D70Produccion.MainProduccion)AbrirVentana(typeof(D70Produccion.MainProduccion));
                        frm.Show();
                    }
                }

                if (_dominioid == "60")
                {
                    if (_moduloid == "0310"
                        || _moduloid == "0320"
                        || _moduloid == "0330"
                        || _moduloid == "0340"
                        || _moduloid == "0350"
                        || _moduloid == "0360"
                        || _moduloid == "0370"
                        || _moduloid == "0500"
                        || _moduloid == "0510"
                        || _moduloid == "0520"
                        || _moduloid == "0530"
                        || _moduloid == "0540")
                    {
                        var frm = (D60ALMACEN.MainAlmacen)AbrirVentana(typeof(D60ALMACEN.MainAlmacen));
                        frm.perfil = _perfil;
                        frm.perianio = _perianio;
                        frm.perimes = _perimes;
                        frm.fechdigini = _fechdigini;
                        frm.fechdigfin = _fechdigfin;
                        frm.dominioid = _dominioid;
                        frm.moduloid = _moduloid;
                        frm.moduloname = _moduloname;
                        frm.local = _local;
                        frm.localname = _localname;
                        frm.ctacte = _ctacte;
                        frm.ctactename = _ctactename;
                        frm.direcnume = _direcnume;
                        frm.novalidastock = _novalidastock;
                        frm.editnumdoc = _editnumdoc;
                        frm.estabsunat = _estabsunat;
                        frm.localfeuiv = _localfeuiv;
                        frm.Show();
                    }

                    if (_moduloid == "0100")
                    {
                        // ALMACEN DE DISTRIBUCION
                        var frm = (APT600100.MainAlmacenPT)AbrirVentana(typeof(APT600100.MainAlmacenPT));
                        frm.perfil = _perfil;
                        frm.perianio = _perianio;
                        frm.perimes = _perimes;
                        frm.fechdigini = _fechdigini;
                        frm.fechdigfin = _fechdigfin;
                        frm.dominioid = _dominioid;
                        frm.moduloid = _moduloid;
                        frm.moduloname = _moduloname;
                        frm.local = _local;
                        frm.localname = _localname;
                        frm.ctacte = _ctacte;
                        frm.ctactename = _ctactename;
                        frm.direcnume = _direcnume;
                        frm.novalidastock = _novalidastock;
                        frm.editnumdoc = _editnumdoc;
                        frm.estabsunat = _estabsunat;
                        frm.localfeuiv = _localfeuiv;
                        frm.Show();
                    }

                    if (_moduloid == "0200")
                    {
                        var frm = (D60Tienda.MainTienda)AbrirVentana(typeof(D60Tienda.MainTienda));
                        frm.toolStripTxtDomModLocal.Text = _dominioid + "-" + _moduloid + "-" + _local + "-" + _localname;
                        //frm.perfil = _perfil;
                        //frm.perianio = _perianio;
                        frm.perimes = _perimes;
                        //frm.fechdigini = _fechdigini;
                        //frm.fechdigfin = _fechdigfin;
                        frm.dominioid = _dominioid;
                        //frm.moduloid = _moduloid;
                        //frm.local = _local;
                        //frm.localname = _localname;
                        //frm.ctacte = _ctacte;
                        //frm.ctactename = _ctactename;
                        //frm.direcnume = _direcnume;
                        //frm.novalidastock = _novalidastock;
                        //frm.editnumdoc = _editnumdoc;
                        //frm.estabsunat = _estabsunat;
                        //frm.localfeuiv = _localfeuiv;
                        frm.Show();
                    }
                }
            }

            if (VariablesPublicas.EmpresaSigla == "VIALEX"
                || VariablesPublicas.EmpresaSigla == "MONTANA")
            {
                if (_dominioid == "60")
                {
                    if (_moduloid == "0100"
                        || _moduloid == "0320"
                        || _moduloid == "0330"
                        || _moduloid == "0500")
                    {
                        var frm = (MERCADERIA.MainMercaderia)AbrirVentana(typeof(MERCADERIA.MainMercaderia));
                        frm.toolStripTxtDomModLocal.Text = _dominioid + "-" + _moduloid + "-" + _local + "-" + _localname;
                        frm.Show();
                    }
                }
                if (_dominioid == "L0")
                {
                    if (_moduloid == "0100")
                    {
                        var frm = (DL0Logistica.MainLogistica)AbrirVentana(typeof(DL0Logistica.MainLogistica));
                        frm.Show();
                    }
                }
            }


            if (_dominioid == "RH")
            {
                if (_moduloid == "0100")
                {
                    var frm = (RecursosHumanos.MainRecursosHumanos)AbrirVentana(typeof(RecursosHumanos.MainRecursosHumanos));
                    frm.Show();
                }
            }


            if (_dominioid == "20")
            {
                if (_moduloid == "0130")
                {
                    var frm = (D20Comercial.MainComercial)AbrirVentana(typeof(D20Comercial.MainComercial));
                    frm.perfil = _perfil;
                    frm.perianio = _perianio;
                    frm.perimes = _perimes;
                    frm.fechdigini = _fechdigini;
                    frm.fechdigfin = _fechdigfin;
                    frm.dominioid = _dominioid;
                    frm.moduloid = _moduloid;
                    frm.local = _local;
                    frm.localname = _localname;
                    frm.ctacte = _ctacte;
                    frm.ctactename = _ctactename;
                    frm.direcnume = _direcnume;
                    frm.novalidastock = _novalidastock;
                    frm.editnumdoc = _editnumdoc;
                    frm.estabsunat = _estabsunat;
                    frm.localfeuiv = _localfeuiv;
                    frm.Show();
                }
            }


            if (_dominioid == "S0")
            {
                if (_moduloid == "0100")
                {
                    var frm = (DS0Seguridad.MainSeguridad)AbrirVentana(typeof(DS0Seguridad.MainSeguridad));
                    frm.Show();
                }
            }
        }


        private void btnCancel2_Click(object sender, EventArgs e)
        {
            if (NoHayFormulariosAbiertos() == true)
            {
                panelEx1.Visible = true;
                panelEx2.Visible = false;
                Text = "Login - " + VariablesPublicas.SiconexionInternet;
                //Conexion();
                //superValidator1.Enabled = true;
                txtUsuar.Focus();
            }
        }

        private void cboEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUsuar.Focus();
            }
        }
        private void txtUsuar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtClave.Focus();
            }
        }
        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk.Focus();
            }
        }

        private void cboDominioID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboModuloID.Focus();
            }
        }
        private void cboModuloID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboLocal.Focus();
            }
        }
        private void cboLocal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPeriodo.Focus();
            }
        }
        private void txtPeriodo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk2.Focus();
            }
        }

        private void btnCambClave_Click(object sender, EventArgs e)
        {
            DS0Seguridad.Frm_LoginChangePassword frm = new DS0Seguridad.Frm_LoginChangePassword();
            frm.Usuar = VariablesPublicas.Usuar.ToUpper().Trim();
            frm.UserNameCC = VariablesPublicas.Nombr.ToUpper().Trim();
            frm.Show();
        }

        private void Conexion()
        {
            if (VariablesPublicas.compruebaConexion() == true)
            {
                Text = Text + "  -  " + "Con conexión a Internet";
                VariablesPublicas.SiconexionInternet = "Con conexión a Internet";
            }
            else
            {
                Text = Text + "  -   " + "Sin conexión a Internet";
                VariablesPublicas.SiconexionInternet = "Sin conexión a Internet";
            }
        }

    }
}