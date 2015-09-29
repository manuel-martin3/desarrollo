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

namespace BapFormulariosNet.Generales
{
    public partial class Frm_reiniciar : Form
    {
        private Genericas fungen = new Genericas();


        public string _perfil { get; set; }
        public string _perianio { get; set; }
        public string _perimes { get; set; }
        public DateTime _fechdigini { get; set; }
        public DateTime _fechdigfin { get; set; }
        public string _dominioid { get; set; }
        public string _moduloid { get; set; }
        public string _local { get; set; }
        public string _localname { get; set; }
        public string _ctacte { get; set; }
        public string _ctactename { get; set; }
        public string _direcnume { get; set; }
        public bool _novalidastock { get; set; }
        public bool _editnumdoc { get; set; }
        public string _estabsunat { get; set; }
        public DateTime _localfeuiv { get; set; }

        public Frm_reiniciar()
        {
            InitializeComponent();
            abrir_perfiles();
            getIdentificarPC();
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
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
                cboDominioID.DataSource = BL.GetAllDominioPorUsuario(VariablesPublicas.EmpresaID, VariablesPublicas.Usuar).Tables[0];
                cboDominioID.ValueMember = "dominioid";
                cboDominioID.DisplayMember = "dominioname";

                if (_dominioid != null)
                {
                    cboDominioID.SelectedValue = _dominioid;
                    get_cbo_modulo();
                }
                else
                {
                    get_cbo_modulo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void get_cbo_modulo()
        {
            var BL = new sys_dominioBL();
            try
            {
                cboModuloID.DataSource = BL.GetAllDominioModuloPorUsuario(VariablesPublicas.EmpresaID, VariablesPublicas.Usuar, cboDominioID.SelectedValue.ToString()).Tables[0];
                cboModuloID.ValueMember = "moduloid";
                cboModuloID.DisplayMember = "moduloname";

                if (_moduloid != null)
                {
                    cboModuloID.SelectedValue = _moduloid;
                    if (cboModuloID.Items.Count > 0)
                    {
                        get_dominio_modulo_local(cboDominioID.SelectedValue.ToString(), cboModuloID.SelectedValue.ToString());
                    }
                }
                else
                {
                    if (cboModuloID.Items.Count > 0)
                    {
                        get_dominio_modulo_local(cboDominioID.SelectedValue.ToString(), cboModuloID.SelectedValue.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                cboLocal.DataSource = dt;
                cboLocal.ValueMember = "local";
                cboLocal.DisplayMember = "localname";
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
                VariablesPublicas.perianio = dt.Rows[0]["perianio"].ToString().Trim();
                VariablesPublicas.perimes = dt.Rows[0]["perimes"].ToString().Trim();
                VariablesPublicas.igv = dt.Rows[0]["igv"].ToString().Trim();
                VariablesPublicas.fechdigini = dt.Rows[0]["fechdigini"].ToString().Trim();
                VariablesPublicas.fechdigfin = dt.Rows[0]["fechdigfin"].ToString().Trim();
            }
            catch (Exception ex)
            {
                VariablesPublicas.perianio = string.Empty;
                VariablesPublicas.perimes = string.Empty;
                VariablesPublicas.igv = string.Empty;
                VariablesPublicas.fechdigini = string.Empty;
                VariablesPublicas.fechdigfin = string.Empty;
            }

            txtPerianio.Text = VariablesPublicas.perianio;
            txtPerimes.Text = fungen.get_mesCad(VariablesPublicas.perimes);
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
                empresaid = VariablesPublicas.EmpresaID;

                dt2 = BL.GetAll(empresaid, BE).Tables[0];

                if (dt2.Rows.Count > 0)
                {
                    VariablesPublicas.EmpresaTipo = dt2.Rows[0]["moduloname"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOk2_Click(object sender, EventArgs e)
        {
            try
            {
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
            dt = BL.GetAll_perfil(VariablesPublicas.EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                VariablesPublicas.Perfil = dt.Rows[0]["idper"].ToString();
            }
            else
            {
                MessageBox.Show("Asignar perfil a usuario !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            Close();
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
                empresaid = VariablesPublicas.EmpresaID;
                dt2 = BL.GetAll(empresaid, BE).Tables[0];

                if (dt2.Rows.Count > 0)
                {
                    VariablesPublicas.EmpresaEstablec = dt2.Rows[0]["localname"].ToString();
                    VariablesPublicas.localfeuiv = dt2.Rows[0]["localfeuiv"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new Seguridadlog.Frm_LoginChangePassword();
            frm.Usuar = VariablesPublicas.Usuar.ToUpper().Trim();
            frm.UserNameCC = VariablesPublicas.Nombr.ToUpper().Trim();
            frm.Show();
        }
        private void Frm_reiniciar_Load(object sender, EventArgs e)
        {
            cboDominioID.SelectedValue = _dominioid;
            cboModuloID.SelectedValue = _moduloid;
            cboLocal.SelectedValue = _local;
            txtPerianio.Text = _perianio;
            txtPerimes.Text = _perimes;
        }
    }
}
