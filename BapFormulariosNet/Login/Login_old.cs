using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using System.Net;
using System.Collections;

namespace BapFormulariosNet.Login
{
    public partial class Login_old : Form
    {
        private Genericas fungen = new Genericas();

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

        private BapFormulariosNet.DS0Seguridad.MainSeguridad _MainDS0Seguridad = null;
        private BapFormulariosNet.DS0Seguridad.MainSeguridad _MainDS0SeguridadInstance
        {
            get
            {
                if (_MainDS0Seguridad == null)
                {
                    _MainDS0Seguridad = new BapFormulariosNet.DS0Seguridad.MainSeguridad();
                    _MainDS0Seguridad.Disposed += new EventHandler(_MainDS0Seguridad_Disposed);
                }

                return _MainDS0Seguridad;
            }
        }

        private void _MainDS0Seguridad_Disposed(object sender, EventArgs e)
        {
            _MainDS0Seguridad = null;
        }

        public Login_old()
        {
            InitializeComponent();
            getIdentificarPC();
            llenar_cboEmpresas();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private String get_iplocal()
        {
            IPHostEntry host;
            var localIP = string.Empty;
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
            var username = String.Format(@"{0}\{1}", Environment.UserDomainName, Environment.UserName);
            var id = System.Security.Principal.WindowsIdentity.GetCurrent();
            id.User.AccountDomainSid.ToString();

            VariablesPublicas.userip = username + ' ' + get_iplocal();
            lblIp.Text = VariablesPublicas.userip;
        }

        private void llenar_cboEmpresas()
        {
            try
            {
                var BE = new tb_empresa();

                BE.empresaid = null;
                BE.empresaname = null;

                cboEmpresa.DataSource = NewMethod();
                cboEmpresa.DisplayMember = "Value";
                cboEmpresa.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private BindingSource NewMethod()
        {
            var BL = new empresasBL();
            var BE = new tb_empresa();

            var table = BL.GetAll(BE).Tables[0];
            var rows = table.Rows;

            object[] cell;
            var dic = new Dictionary<string, string>();
            var binding = new BindingSource();

            foreach (DataRow item in rows)
            {
                cell = item.ItemArray;
                dic.Add(cell[0].ToString(), cell[0].ToString() + " - " + cell[1].ToString());
                cell = null;
            }
            binding.DataSource = dic;
            return binding;
        }



        private void CrearBaseDatos_sdf()
        {
            var BL = new empresasBL();

            var cod = cboEmpresa.SelectedValue.ToString();

            if (BL.CrearBase_sdf(cod))
            {
            }
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

                BE.empresaid = cboEmpresa.Text.Substring(0, 2).Trim().PadLeft(2,'0');

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
            var usuariosBL = new usuariosBL();
            var tb_usuarios = new tb_usuarios();

            var dt = new DataTable();
            String xClave = null;
            var xadmin = false;
            tb_usuarios.usuar = txtUsuar.Text.Trim().ToLower();

            if (ValidarIngreso())
            {
                try
                {
                    dt = usuariosBL.GetAll(cboEmpresa.Text.Substring(0, 2), tb_usuarios).Tables[0];
                    xClave = Convert.ToString(dt.Rows[0]["CLAVE"]);
                    xadmin = Convert.ToBoolean(dt.Rows[0]["admin"]);

                    txtClave.Text = fungen.GetMD5(txtClave.Text.ToLower()).Substring(0, 10);
                    if (txtClave.Text.ToUpper() == xClave)
                    {
                        cboEmpresa_SelectedIndexChanged(sender, e);
                        VariablesPublicas.Usuar = Convert.ToString(dt.Rows[0]["usuar"]);
                        abrir_perfiles();
                        get_cargafoto();
                        panel1.Visible = false;
                        panel2.Visible = true;
                        Text = "Panel de Control";
                        cboDominioID.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o Clave Incorrecto !!!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            var BL = new sys_dominioBL();

            try
            {
                DataTable dt = new DataTable();
                dt = BL.GetAllDominioPorUsuario(VariablesPublicas.EmpresaID, VariablesPublicas.Usuar).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    cboDominioID.DataSource = dt;
                    cboDominioID.ValueMember = "dominioid";
                    cboDominioID.DisplayMember = "dominioname";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            get_cbo_modulo();
        }

        private void get_cbo_modulo()
        {
            var BL = new sys_dominioBL();
            try
            {
                DataTable dt = new DataTable();
                dt = BL.GetAllDominioModuloPorUsuario(VariablesPublicas.EmpresaID, VariablesPublicas.Usuar, cboDominioID.SelectedValue.ToString()).Tables[0];               
                if (dt.Rows.Count > 0)
                {
                   cboModuloID.DataSource = dt;
                   cboModuloID.ValueMember = "moduloid";
                   cboModuloID.DisplayMember = "moduloname";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (cboModuloID.Items.Count > 0)
            {
                get_dominio_modulo_local(cboDominioID.SelectedValue.ToString(), cboModuloID.SelectedValue.ToString());
            }
        }

        private void get_dominio_modulo_local(string dominioid, string moduloid)
        {
            var BL = new usuariomodulolocalBL();
            var BE = new tb_usuariomodulolocal();
            BE.usuar = VariablesPublicas.Usuar.Trim();
            var dt = new DataTable();
            BE.dominioid = dominioid;
            BE.moduloid = moduloid;

            try
            {
                dt = BL.GetAll3(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    cboLocal.DataSource = dt;
                    cboLocal.ValueMember = "local";
                    cboLocal.DisplayMember = "localname";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void get_constantesGen(String dominioid, String moduloid, String local)
        {
            var BL = new constantesgeneralesBL();
            var dt = new DataTable();

            try
            {
                dt = BL.GetOne(VariablesPublicas.EmpresaID, dominioid, moduloid, local).Tables[0];
                _perianio = dt.Rows[0]["perianio"].ToString().Trim();
                _perimes = dt.Rows[0]["perimes"].ToString().Trim();

                VariablesPublicas.igv = dt.Rows[0]["igv"].ToString().Trim();
                _fechdigini = Convert.ToDateTime(dt.Rows[0]["fechdigini"]);
                _fechdigfin = Convert.ToDateTime(dt.Rows[0]["fechdigfin"]);
            }
            catch (Exception ex)
            {
                _perianio = string.Empty;
                _perimes = string.Empty;
                VariablesPublicas.igv = string.Empty;
                _fechdigini = DateTime.Today;
                _fechdigfin = DateTime.Today;
            }

            txtPerianio.Text = _perianio;
            txtPerimes.Text = fungen.get_mesCad(_perimes);
        }


        private void get_cargafoto()
        {
            try
            {
                var usuariosBL = new usuariosBL();
                var tb_usuarios = new tb_usuarios();
                var dt = new DataTable();
                tb_usuarios.usuar = VariablesPublicas.Usuar;

                dt = usuariosBL.GetAll(VariablesPublicas.EmpresaID, tb_usuarios).Tables[0];
                txtUsuarName.Text = dt.Rows[0]["nombr"].ToString().PadRight(20, ' ').Substring(0, 20);
                VariablesPublicas.Nombr = dt.Rows[0]["nombr"].ToString().PadRight(20, ' ').Substring(0, 20);

                dt.Rows[0]["foto"].ToString();


                var bytes = new byte[] { };

                if (dt.Rows[0]["foto"].ToString() != string.Empty)
                {
                    foto.Visible = true;

                    foto.Image = null;
                    var ms = new System.IO.MemoryStream();
                    var MyData1 = (byte[])(dt.Rows[0]["foto"]);

                    if (!MyData1.SequenceEqual(bytes))
                    {
                        ms.Write(MyData1, 0, MyData1.Length);
                        var b = new Bitmap(ms);
                        foto.SizeMode = PictureBoxSizeMode.StretchImage;
                        foto.Image = new System.Drawing.Bitmap(b);
                    }
                }
                else
                {
                    foto.Visible = false;
                    foto.ImageLocation = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnOk2_Click(object sender, EventArgs e)
        {
            Metodo_VariablesStatic();
        }

        private void Metodo_VariablesPublicas()
        {
            try
            {
                VariablesPublicas.Dominioid = cboDominioID.SelectedValue.ToString();
                VariablesPublicas.Moduloid = cboModuloID.SelectedValue.ToString();

                VariablesPublicas.Local = cboLocal.SelectedValue.ToString();
                VariablesPublicas.nombrelocal = cboLocal.Text.ToString();


                var BL1 = new usuariomodulolocalBL();
                var BE1 = new tb_usuariomodulolocal();
                var data = new DataTable();

                BE1.dominioid = cboDominioID.SelectedValue.ToString();
                BE1.moduloid = cboModuloID.SelectedValue.ToString();
                BE1.local = cboLocal.SelectedValue.ToString();

                data = BL1.GetAllDatos(VariablesPublicas.EmpresaID, BE1).Tables[0];
                if (data.Rows.Count > 0)
                {
                    VariablesPublicas.xctacte = data.Rows[0]["ctacte"].ToString();
                    VariablesPublicas.xdirecnume = data.Rows[0]["direcnume"].ToString();
                    VariablesPublicas.novalidastock = Convert.ToBoolean(data.Rows[0]["novalidastock"].ToString() == "True" ? 1 : 0);
                    VariablesPublicas.editnumdoc = Convert.ToBoolean(data.Rows[0]["editnumdoc"].ToString() == "True" ? 1 : 0);
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
                VariablesPublicas.Perfil = dt.Rows[0]["idper"].ToString();
            }
            else
            {
                MessageBox.Show("Asignar perfil a usuario !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (VariablesPublicas.EmpresaSigla == "WAMA" || VariablesPublicas.EmpresaSigla == "PRUEBAS")
            {
                if (VariablesPublicas.Dominioid == "L0")
                {
                    if (VariablesPublicas.Moduloid == "0100")
                    {
                        var frm = (DL0Logistica.MainLogistica)AbrirVentana(typeof(DL0Logistica.MainLogistica));
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

                if (VariablesPublicas.Dominioid == "70")
                {
                    if (VariablesPublicas.Moduloid == "0900")
                    {
                        var frm = (D70Produccion.MainProduccion)AbrirVentana(typeof(D70Produccion.MainProduccion));
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

                if (VariablesPublicas.Dominioid == "60")
                {
                    if (VariablesPublicas.Moduloid == "0310"
                        || VariablesPublicas.Moduloid == "0320"
                        || VariablesPublicas.Moduloid == "0330"
                        || VariablesPublicas.Moduloid == "0340"
                        || VariablesPublicas.Moduloid == "0350"
                        || VariablesPublicas.Moduloid == "0360"
                        || VariablesPublicas.Moduloid == "0370"
                        || VariablesPublicas.Moduloid == "0500"
                        || VariablesPublicas.Moduloid == "0510"
                        || VariablesPublicas.Moduloid == "0520"
                        || VariablesPublicas.Moduloid == "0530"
                        || VariablesPublicas.Moduloid == "0540")
                    {
                        var frm = (D60ALMACEN.MainAlmacen)AbrirVentana(typeof(D60ALMACEN.MainAlmacen));
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

                    if (VariablesPublicas.Moduloid == "0100")
                    {
                        var frm = (APT600100.MainAlmacenPT)AbrirVentana(typeof(APT600100.MainAlmacenPT));
                        frm.Show();
                    }

                    if (VariablesPublicas.Moduloid == "0200")
                    {
                        // Modificado Para Utilizr solo en el Main de tiendas
                        
                        var frm = (D60Tienda.MainTienda)AbrirVentana(typeof(D60Tienda.MainTienda));
                        frm.toolStripTxtDomModLocal.Text = VariablesPublicas.Dominioid + "-" + VariablesPublicas.Moduloid + "-" + VariablesPublicas.Local + "-" + VariablesPublicas.nombrelocal;

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
                if (VariablesPublicas.Dominioid == "60")
                {
                    if (VariablesPublicas.Moduloid == "0100"
                    || VariablesPublicas.Moduloid == "0320"
                    || VariablesPublicas.Moduloid == "0330"
                    || VariablesPublicas.Moduloid == "0500")
                    {
                        var frm = (MERCADERIA.MainMercaderia)AbrirVentana(typeof(MERCADERIA.MainMercaderia));
                        frm.toolStripTxtDomModLocal.Text = VariablesPublicas.Dominioid + "-" + VariablesPublicas.Moduloid + "-" + VariablesPublicas.Local + "-" + VariablesPublicas.nombrelocal;
                        frm.Show();
                    }
                }
                if (VariablesPublicas.Dominioid == "L0")
                {
                    if (VariablesPublicas.Moduloid == "0100")
                    {
                        var frm = (DL0Logistica.MainLogistica)AbrirVentana(typeof(DL0Logistica.MainLogistica));
                        frm.Show();
                    }
                }
            }


            if (VariablesPublicas.Dominioid == "RH")
            {
                if (VariablesPublicas.Moduloid == "0100")
                {
                    var frm = (RecursosHumanos.MainRecursosHumanos)AbrirVentana(typeof(RecursosHumanos.MainRecursosHumanos));
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


            if (VariablesPublicas.Dominioid == "20")
            {
                if (VariablesPublicas.Moduloid == "0130")
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


            if (VariablesPublicas.Dominioid == "S0")
            {
                if (VariablesPublicas.Moduloid == "0100")
                {
                    var frm = (DS0Seguridad.MainSeguridad)AbrirVentana(typeof(DS0Seguridad.MainSeguridad));
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
                VariablesPublicas.perianio = txtPerianio.Text.ToString().Trim();


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
                    if (   _moduloid == "0310"
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
                        frm.toolStripTxtDomModLocal.Text = _dominioid + "-" + _moduloid + "-" + _local + "-" + _localname ;
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
            panel1.Visible = true;
            panel2.Visible = false;
            Text = "Login";
            txtUsuar.Focus();
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
                btnOk2.Focus();
            }
        }
        private void dtpFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk2.Focus();
            }
        }

        private void cboLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLocal.SelectedIndex != -1)
            {
                get_constantesGen(cboDominioID.SelectedValue.ToString(), cboModuloID.SelectedValue.ToString(), cboLocal.SelectedValue.ToString());
            }

            var BE = new tb_sys_local();

            BE.moduloid = cboModuloID.SelectedValue.ToString();
            BE.dominioid = cboDominioID.SelectedValue.ToString();
            BE.local = cboLocal.SelectedValue.ToString();

            try
            {
                var BL = new sys_localBL();
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
                    _localname = dt2.Rows[0]["localname"].ToString();
                    _localfeuiv = Convert.ToDateTime(dt2.Rows[0]["localfeuiv"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Activated(object sender, EventArgs e)
        {
            if (VariablesPublicas.CerrarSession)
            {
                panel2.Visible = false;
                panel1.Visible = true;
                VariablesPublicas.CerrarSession = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new DS0Seguridad.Frm_LoginChangePassword();
            frm.Usuar = VariablesPublicas.Usuar.ToUpper().Trim();
            frm.UserNameCC = VariablesPublicas.Nombr.ToUpper().Trim();
            frm.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtPerianio.BackColor = Color.Peru;
            txtPerimes.BackColor = Color.Black;
        }

        private void panel2_VisibleChanged(object sender, EventArgs e)
        {
            if (cboModuloID.Items.Count > -1)
            {
                cboModuloID_SelectedIndexChanged(sender, e);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void setvariablesMDI()
        {
        }
    }
}
