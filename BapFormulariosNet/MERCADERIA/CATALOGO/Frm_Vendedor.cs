using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using BapFormulariosNet.Seguridadlog;
using BapFormulariosNet.Ayudas;
using BapFormulariosNet.Codigo;
using BapFormulariosNet.RecursosHumanos.Reportes;

namespace BapFormulariosNet.MERCADERIA.CATALOGO
{
    public partial class Frm_Vendedor : plantilla
    {
        private DataTable tablaVendedor = new DataTable();
        private string _NameColumn = string.Empty;
        private DataTable TablaContratos = new DataTable();
        private TextBox txtCArti;
        private DataTable tmpcursor = new DataTable();
        private string vm_Nombretrabajador = string.Empty;
        private String EmpresaID = string.Empty;
        private String ssModo = "NEW";
        private Boolean procesado = false;
        private string VM_mimagen_3 = string.Empty;
        private bool sw_EmpiezaEdicion = false;
        private DataTable tmptabla = new DataTable();
        private string j_ccosto = string.Empty;
        private bool Sw_LOad = true;
        private String XNIVEL = string.Empty;
        private String PERFILID = string.Empty;
        private int u_n_opsel = 0;
        private int lc_cont = 0;
        private string j_ccargo = string.Empty;

        private int cdClave = 0;

        public Frm_Vendedor()
        {
            InitializeComponent();
            KeyDown += Frm_RegistroTrabajadores_KeyDown;
            FormClosing += Frm_RegistroTrabajadores_FormClosing;
            Load += Frm_RegistroTrabajadores_Load;
            Activated += Frm_RegistroTrabajadores_Activated;
            txtccargo.GotFocus += new System.EventHandler(txtccargo_GotFocus);
            txtccargo.LostFocus += new System.EventHandler(txtccargo_LostFocus);
        }

        private void NIVEL_FORMS()
        {
            XNIVEL = VariablesPublicas.Get_nivelperfil(PERFILID, Name).Substring(0, 1);
            if (XNIVEL != "0")
            {
            }
            else
            {
            }
        }

        private BindingSource NewMethodoDoc()
        {
            var BL = new tb_plla_pdt_tabla03BL();
            var BE = new tb_plla_pdt_tabla03();

            var table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
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

        private BindingSource NewMethodoVia()
        {
            var BL = new tb_plla_pdt_tabla05BL();
            var BE = new tb_plla_pdt_tabla05();

            var table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
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

        private BindingSource NewMethodoZona()
        {
            var BL = new tb_plla_pdt_tabla06BL();
            var BE = new tb_plla_pdt_tabla06();

            var table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
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

        private BindingSource NewMethoNE()
        {
            var BL = new tb_plla_pdt_tabla09BL();
            var BE = new tb_plla_pdt_tabla09();

            var table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
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

        private BindingSource NewMethoTP()
        {
            var BL = new tb_plla_tipoplanillaBL();
            var BE = new tb_plla_tipoplanilla();

            var table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
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

        private BindingSource NewMethoBcoC()
        {
            var BL = new tb_co_tabla03_bancoBL();
            var BE = new tb_co_tabla03_banco();

            var table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
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

        private void FillResultProvi(ComboBox cboP, ComboBox cboT, string iddepart)
        {
            var BL = new ubigeoBL();
            var BE = new tb_ubigeo();
            BE.ubige = iddepart;
            try
            {
                cboP.DataSource = BL.GetAll_provi(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                cboP.ValueMember = "ubige";
                cboP.DisplayMember = "provi";
                if (cboP.Items.Count > 0)
                {
                    cboP.SelectedIndex = 0;
                    FillResultDistr(cboT, cboP.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FillResultDistr(ComboBox cboT, string idprovi)
        {
            var BL = new ubigeoBL();
            var BE = new tb_ubigeo();
            BE.ubige = idprovi;
            try
            {
                cboT.DataSource = BL.GetAll_distr(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                cboT.ValueMember = "ubige";
                cboT.DisplayMember = "Distr";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillResultDeparN(ComboBox cboDN, ComboBox cboPN, ComboBox cboTN)
        {
            var BL = new ubigeoBL();
            var BE = new tb_ubigeo();
            try
            {
                cboDN.DataSource = BL.GetAll_depar(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                cboDN.ValueMember = "ubige";
                cboDN.DisplayMember = "depar";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FillResultProviN(ComboBox cboPN, ComboBox cboTN, string iddepartN)
        {
            var BL = new ubigeoBL();
            var BE = new tb_ubigeo();
            BE.ubige = iddepartN;
            try
            {
                cboPN.DataSource = BL.GetAll_provi(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                cboPN.ValueMember = "ubige";
                cboPN.DisplayMember = "provi";
                if (cboPN.Items.Count > 0)
                {
                    cboPN.SelectedIndex = 0;
                    FillResultDistrN(cboTN, cboPN.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FillResultDistrN(ComboBox cboTN, string idproviN)
        {
            var BL = new ubigeoBL();
            var BE = new tb_ubigeo();
            BE.ubige = idproviN;
            try
            {
                cboTN.DataSource = BL.GetAll_distr(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                cboTN.ValueMember = "ubige";
                cboTN.DisplayMember = "Distr";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_RegistroTrabajadores_Activated(object sender, EventArgs e)
        {
            if (Sw_LOad)
            {
                U_RefrescaControles();
                CargaDatos();
                U_RefrescaControles();
                Sw_LOad = false;
                NIVEL_FORMS();
            }
        }

        private void Frm_RegistroTrabajadores_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            WindowState = FormWindowState.Normal;
            EmpresaID = VariablesPublicas.EmpresaID;
            _CargarGenero();
            form_bloqueado(false);
            btnnuevo.Enabled = true;
            btncerrar.Enabled = true;
        }


        private void CargaDatos()
        {
            var BL = new tb_t1_vendedorBL();
            var BE = new tb_t1_vendedor();

            BE.vendorname = txtfiltronombre.Text;
            BE.ddnni = txtfiltronumdoc.Text;

            tablaVendedor = BL.GetAll(VariablesPublicas.EmpresaID, BE).Tables[0];

            Examinar.AutoGenerateColumns = false;
            Examinar.DataSource = tablaVendedor;
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            u_PintaDatos();
            u_PintaDatos();
        }

        private void U_RefrescaControles()
        {
            var xcodcliente = string.Empty;
            txtdcargo.Enabled = false;
            txtdcosto.Enabled = false;
            txtccargo.Enabled = u_n_opsel > 0;
            txtccosto.Enabled = u_n_opsel > 0;
            txtDni.Enabled = u_n_opsel > 0;
            cbogenero.Enabled = u_n_opsel > 0;
            btnnuevo.Enabled = u_n_opsel == 0;
            btngrabar.Enabled = u_n_opsel > 0;
            btnmod.Enabled = u_n_opsel == 0 & xcodcliente.Length > 0;
            btneliminar.Enabled = u_n_opsel == 0 & xcodcliente.Length > 0;
            btncancelar.Enabled = u_n_opsel > 0;
            btncerrar.Enabled = u_n_opsel == 0;
            barramain.Enabled = cdClave == 0;
            Examinar.Enabled = u_n_opsel == 0;
            btnlog.Enabled = u_n_opsel == 0;
            txtnombres.Enabled = u_n_opsel > 0;
            txtdireccion.Enabled = u_n_opsel > 0;
            fIngreso.Enabled = u_n_opsel > 0;
            fnacimiento.Enabled = u_n_opsel > 0;
            txttelefono.Enabled = u_n_opsel > 0;
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void nuevo()
        {
            vm_Nombretrabajador = string.Empty;
            Blanquear();
            form_bloqueado(true);
            btncancelar.Enabled = true;
            btngrabar.Enabled = true;
            ssModo = "NEW";
        }

        private void _CargarGenero()
        {
            try
            {
                var BL = new tb_pt_generoBL();
                var BE = new tb_pt_genero();
                var dt = new DataTable();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                cbogenero.DataSource = dt;
                cbogenero.ValueMember = "generoid";
                cbogenero.DisplayMember = "generoname";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void Blanquear()
        {
            txtDni.Text = string.Empty;
            lblvendorid.Text = string.Empty;
            txtnombres.Text = string.Empty;
            VM_mimagen_3 = string.Empty;
            txtnombres.Text = string.Empty;
            txtdireccion.Text = string.Empty;
            fIngreso.Checked = false;
            txttelefono.Text = string.Empty;
            txtccargo.Text = string.Empty;
            txtdcargo.Text = string.Empty;
            txtccosto.Text = string.Empty;
            txtdcosto.Text = string.Empty;
            cbogenero.SelectedIndex = -1;
            fnacimiento.Text = System.DateTime.Now.ToString();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            U_CancelarEdicion(1);
        }

        private void U_CancelarEdicion(int SwConfirmacion)
        {
            var sw_prosigue = true;

            if ((SwConfirmacion == 1))
            {
                sw_prosigue = (MessageBox.Show("Desea cancelar ingreso de datos...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
            }
            else
            {
                sw_prosigue = true;
            }

            if (sw_prosigue)
            {
                Blanquear();
                form_bloqueado(false);
                btnnuevo.Enabled = true;
                btncerrar.Enabled = true;
                ssModo = "NEW";
                CargaDatos();
            }
        }

        private void btnmod_Click(object sender, EventArgs e)
        {
            ssModo = "EDIT";
            form_bloqueado(true);
            txtDni.Focus();
            btncancelar.Enabled = true;
            btngrabar.Enabled = true;
        }

        private void btngrabar_Click(object sender, EventArgs e)
        {
            procesado = false;
            var sw_prosigue = false;
            if (ssModo == "NEW")
            {
                Insert();
            }
            else
            {
                sw_prosigue = (MessageBox.Show("¿Desea Modificar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                if (sw_prosigue)
                {
                    _Update();
                }
            }
            if (procesado)
            {
                NIVEL_FORMS();
                form_bloqueado(false);
                CargaDatos();
                btnnuevo.Enabled = true;
                btncerrar.Enabled = true;
            }
        }


        private void form_bloqueado(Boolean var)
        {
            try
            {
                txtDni.Enabled = var;
                txtnombres.Enabled = var;
                txttelefono.Enabled = var;
                txtdireccion.Enabled = var;
                cbogenero.Enabled = var;
                fnacimiento.Enabled = var;
                fIngreso.Enabled = var;
                txtccosto.Enabled = false;
                txtccargo.Enabled = var;
                txtdcosto.Enabled = false;
                txtdcargo.Enabled = false;

                btnnuevo.Enabled = false;
                btnmod.Enabled = false;
                btncancelar.Enabled = false;
                btngrabar.Enabled = false;
                btneliminar.Enabled = false;
                btncerrar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Insert()
        {
            try
            {
                if (U_Validacion())
                {
                    var BL = new tb_t1_vendedorBL();
                    var BE = new tb_t1_vendedor();

                    BE.ddnni = txtDni.Text.ToString();
                    BE.vendorname = txtnombres.Text;
                    BE.direcc = txtdireccion.Text;
                    BE.telefono = txttelefono.Text;
                    BE.local = txtccosto.Text;
                    BE.fechanac = Convert.ToDateTime(fnacimiento.Text);
                    BE.fechasig = Convert.ToDateTime(fIngreso.Text);
                    if (cbogenero.SelectedValue is DBNull)
                    {
                        BE.generoid = cbogenero.SelectedValue.ToString();
                    }
                    else
                    {
                        BE.generoid = "1";
                    }
                    BE.ccargoid = txtccargo.Text;
                    BE.status = "0";
                    BE.usuar = VariablesPublicas.Usuar.Trim();

                    if (BL.Insert(EmpresaID, BE))
                    {
                        MessageBox.Show("Datos Grabados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        procesado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void _Update()
        {
            try
            {
                if (lblvendorid.Text != string.Empty)
                {
                    var BL = new tb_t1_vendedorBL();
                    var BE = new tb_t1_vendedor();

                    BE.vendorid = lblvendorid.Text;
                    BE.ddnni = txtDni.Text.ToString();
                    BE.vendorname = txtnombres.Text;
                    BE.direcc = txtdireccion.Text;
                    BE.telefono = txttelefono.Text;
                    BE.local = txtccosto.Text;
                    BE.fechanac = Convert.ToDateTime(fnacimiento.Text);
                    BE.fechasig = Convert.ToDateTime(fIngreso.Text);
                    if (cbogenero.SelectedValue is DBNull)
                    {
                        BE.generoid = "1";
                    }
                    else
                    {
                        BE.generoid = cbogenero.SelectedValue.ToString();
                    }
                    BE.ccargoid = txtccargo.Text;
                    BE.status = "0";
                    BE.usuar = VariablesPublicas.Usuar.Trim();

                    if (BL.Update(EmpresaID, BE))
                    {
                        MessageBox.Show("Datos Modificado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        procesado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void seguridadlog()
        {
            var xclave = VariablesPublicas.EmpresaID;
            try
            {
                var BL = new tb_co_seguridadlogBL();
                var BE = new tb_co_seguridadlog();

                BE.moduloid = Name;
                BE.clave = xclave;
                BE.cuser = VariablesPublicas.Usuar;
                BE.fecha = DateTime.Now;
                BE.pc = VariablesPublicas.userip;
                BE.accion = (u_n_opsel == 1 ? "N" : "M");
                BE.detalle = "Trabajador: " + txtnombres.Text.ToString();
                BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            var sw_prosigue = false;
            sw_prosigue = (MessageBox.Show("¿Desea Eliminar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

            if (sw_prosigue)
            {
                Delete();
            }
        }

        private void Delete()
        {
            try
            {
                if (lblvendorid.Text == string.Empty)
                {
                    MessageBox.Show("Falta Codigo Vendedor !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_t1_vendedorBL();
                    var BE = new tb_t1_vendedor();
                    BE.vendorid = lblvendorid.Text;
                    if (BL.Delete(EmpresaID, BE))
                    {
                        MessageBox.Show("Datos Eliminado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        form_bloqueado(false);
                        btnnuevo.Enabled = true;
                        CargaDatos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Frm_RegistroTrabajadores_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (u_n_opsel > 0)
            {
                MessageBox.Show("Finalice Edición para cerrar Formulario", "Mensaje del Sistema");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            CargaDatos();
            U_RefrescaControles();
        }

        private bool U_Validacion()
        {
            var obj = true;
            if (txtnombres.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese Apellidos y Nombres del Trabajador");
                obj = false;
            }
            else
            {
                if (txtDni.Text.Length == 0)
                {
                    MessageBox.Show("Ingrese DNI ...! ");
                    obj = false;
                }
            }
            return obj;
        }

        private void Frm_RegistroTrabajadores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 & btnnuevo.Enabled)
            {
                btnnuevo_Click(sender, e);
            }
            if (e.KeyCode == Keys.F3 & btnmod.Enabled)
            {
                btnmod_Click(sender, e);
            }
            if (e.KeyCode == Keys.G & e.Control & btngrabar.Enabled)
            {
                btngrabar_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (btncancelar.Enabled)
                {
                    btncancelar_Click(sender, e);
                }
                else
                {
                    btncerrar_Click(sender, e);
                }
            }
            if (e.KeyCode == Keys.F8 & btneliminar.Enabled)
            {
                btneliminar_Click(sender, e);
            }
        }

        private void btnadddivision_Click(object sender, EventArgs e)
        {
            TablaContratos.AcceptChanges();
            TablaContratos.Rows.Add(VariablesPublicas.INSERTINTOTABLE(TablaContratos));
            TablaContratos.Rows[TablaContratos.Rows.Count - 1]["ncontrato"] = VariablesPublicas.CalcMaxField(TablaContratos, "ncontrato", 6);
            TablaContratos.Rows[TablaContratos.Rows.Count - 1]["moneda"] = "1";
            TablaContratos.Rows[TablaContratos.Rows.Count - 1]["estado"] = "01";
            TablaContratos.Rows[TablaContratos.Rows.Count - 1]["nuevo"] = "1";
            TablaContratos.Rows[TablaContratos.Rows.Count - 1]["vigencia"] = 1;
            TablaContratos.Rows[TablaContratos.Rows.Count - 1]["status"] = "0";
            TablaContratos.AcceptChanges();
            U_RefrescaControles();
        }

        private void examinaranexos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (_NameColumn.Length > 0)
            {
                switch (_NameColumn)
                {
                    case "COD_UBIGEO":
                        if (GlobalVars.GetInstance().PulsaAyudaArticulos)
                        {
                            txtCArti = null;
                        }
                        break;
                }
            }
            _NameColumn = string.Empty;
        }


        private void btnlog_Click(object sender, EventArgs e)
        {
            if ((Examinar.CurrentRow != null))
            {
                var oform = new FrmSeguridad();
                oform._Nombre = Name;
                oform._ClaveForm = VariablesPublicas.EmpresaID + Examinar.Rows[Examinar.CurrentRow.Index].Cells["fichaid"].Value;
                oform.Owner = this;
                oform.ShowDialog();
            }
        }

        private void txtapepat_TextChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad & u_n_opsel > 0)
            {
                u_ArmaRazonSocial();
            }
        }
        private void txtapemat_TextChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad & u_n_opsel > 0)
            {
                u_ArmaRazonSocial();
            }
        }
        private void txtnombres_TextChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad & u_n_opsel > 0)
            {
                u_ArmaRazonSocial();
            }
        }
        public void u_ArmaRazonSocial()
        {
            var xprvnom = string.Empty;

            if (txtnombres.Text.Trim().Length > 0)
            {
                xprvnom = xprvnom + txtnombres.Text.Trim() + " ";
            }
        }

        private void btnfiltro_Click(object sender, EventArgs e)
        {
            CargaDatos();
        }
        public void u_PintaDatos()
        {
            if (!Sw_LOad)
            {
                if (u_n_opsel != 1)
                {
                    if (Examinar.CurrentRow != null)
                    {
                        txtnombres.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["_vendorname"].Value.ToString();
                        txtDni.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["_ddnni"].Value.ToString();
                        txtdireccion.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["direcc"].Value.ToString();
                        txttelefono.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["_telefono"].Value.ToString();

                        if (!object.ReferenceEquals(Examinar.Rows[Examinar.CurrentRow.Index].Cells["_fnacimiento"].Value, DBNull.Value))
                        {
                            fnacimiento.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["_fnacimiento"].Value.ToString();
                        }

                        if (!object.ReferenceEquals(Examinar.Rows[Examinar.CurrentRow.Index].Cells["_fechasig"].Value, DBNull.Value))
                        {
                            fIngreso.Checked = true;
                            fIngreso.Value = Convert.ToDateTime(Examinar.Rows[Examinar.CurrentRow.Index].Cells["_fechasig"].Value);
                        }
                        else
                        {
                            fIngreso.Checked = false;
                        }
                    }
                    else
                    {
                        Blanquear();
                    }
                }
            }
            U_RefrescaControles();
        }

        private void btnprimero_Click(object sender, EventArgs e)
        {
            u_Roleo(GlobalVars.GetInstance().TOPRECORD);
        }
        private void btnanterior_Click(object sender, EventArgs e)
        {
            u_Roleo(GlobalVars.GetInstance().PREVRECORD);
        }
        private void btnsiguiente_Click(object sender, EventArgs e)
        {
            u_Roleo(GlobalVars.GetInstance().NEXTRECORD);
        }
        private void btnultimo_Click(object sender, EventArgs e)
        {
            u_Roleo(GlobalVars.GetInstance().BOTTRECORD);
        }
        public void u_Roleo(string xtipo)
        {
            VariablesPublicas.RoleoGrid(Examinar, xtipo, "fichaid");
            u_PintaDatos();
        }

        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar) >= '0' & e.KeyChar <= '9') & !(e.KeyChar == '.'))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete && !(e.KeyChar == '.'))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        public void U_pINTAR()
        {
            if (1 == 1)
            {
                var LC_NCOLUMNA = 0;
                for (lc_cont = 0; lc_cont <= Examinar.RowCount - 1; lc_cont++)
                {
                    for (LC_NCOLUMNA = 0; LC_NCOLUMNA <= Examinar.ColumnCount - 1; LC_NCOLUMNA++)
                    {
                        Examinar.Rows[lc_cont].DefaultCellStyle.BackColor = Color.White;
                        Examinar.Rows[lc_cont].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void Examinar_Paint(object sender, PaintEventArgs e)
        {
            U_pINTAR();
        }
        private void rbsiConvenio_CheckedChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0 & !sw_EmpiezaEdicion)
            {
                U_RefrescaControles();
            }
        }


        private void txtccosto_GotFocus(object sender, System.EventArgs e)
        {
            j_ccosto = txtccosto.Text;
        }


        private void txtccosto_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_ccosto == txtccosto.Text) & u_n_opsel > 0)
            {
                ValidaCcosto();
            }
        }


        public void ValidaCcosto()
        {
            if (txtccosto.Text.Trim().Length == 0)
            {
                txtdcosto.Text = string.Empty;
            }
            else
            {
                txtccosto.Text = VariablesPublicas.PADL(txtccosto.Text.Trim(), txtccosto.MaxLength, "0");
                var BL = new centrocostoBL();
                var BE = new tb_centrocosto();
                BE.cencosid = txtccosto.Text.Trim();
                BE.norden = 1;
                BE.ver_blanco = 0;
                tmptabla = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (BL.Sql_Error.Length == 0)
                {
                    if (tmptabla.Rows.Count > 0)
                    {
                        txtccosto.Text = tmptabla.Rows[0]["cencosid"].ToString();
                        txtdcosto.Text = tmptabla.Rows[0]["cencosname"].ToString();
                        txtccargo.Text = string.Empty;
                        txtdcargo.Text = string.Empty;
                    }
                    else
                    {
                        txtccosto.Text = j_ccosto;
                    }
                }
                else
                {
                    txtccosto.Text = j_ccosto;
                }
            }
        }


        private void txtccosto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaCcosto();
            }
        }


        public void AyudaCcosto()
        {
            var oform = new Frm_AyudaCCostoPlla();
            oform._PasaDelegado = RecibeCCOSTO;
            oform.Owner = this;
            oform.ShowDialog();
        }

        public void RecibeCCOSTO(string Codigo, string nombre)
        {
            txtccosto.Text = Codigo;
            txtdcosto.Text = nombre;
            txtccargo.Text = string.Empty;
            txtdcargo.Text = string.Empty;
        }

        private void txtccargo_GotFocus(object sender, System.EventArgs e)
        {
            j_ccargo = txtccargo.Text;
        }

        private void txtccargo_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_ccargo == txtccargo.Text) & u_n_opsel > 0)
            {
                ValidaCcargo();
            }
        }

        public void ValidaCcargo()
        {
            if (txtccargo.Text.Trim().Length == 0)
            {
                txtdcargo.Text = string.Empty;
            }
            else
            {
                txtccargo.Text = VariablesPublicas.PADL(txtccargo.Text.Trim(), txtccargo.MaxLength, "0");
                var BL = new tb_plla_cargosBL();
                var BE = new tb_plla_cargos();
                BE.cencosid = txtccosto.Text.Trim();
                BE.cargoid = txtccargo.Text.Trim();
                tmptabla = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (BL.Sql_Error.Length == 0)
                {
                    if (tmptabla.Rows.Count > 0)
                    {
                        txtccargo.Text = tmptabla.Rows[0]["cargoid"].ToString();
                        txtdcargo.Text = tmptabla.Rows[0]["cargoname"].ToString();
                    }
                    else
                    {
                        txtccargo.Text = j_ccargo;
                    }
                }
                else
                {
                    txtccargo.Text = j_ccargo;
                }
            }
        }

        private void txtccargo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaCargos();
            }
        }

        public void AyudaCargos()
        {
            var frmayuda = new Ayudas.Frm_help_general();

            frmayuda.tipoo = "sql";
            frmayuda.titulo = "<< AYUDA  TABLA CARGOS >>";
            frmayuda.sqlquery = "SELECT cargoid, cargoname FROM tb_t1_planicargo ";
            frmayuda.sqlinner = string.Empty;
            frmayuda.sqlwhere = "where";
            frmayuda.sqland = string.Empty;
            frmayuda.criteriosbusqueda = new string[] { "CARGO", "CODIGO" };
            frmayuda.columbusqueda = "cargoname,cargoid";
            frmayuda.returndatos = "0,1";

            frmayuda.Owner = this;
            frmayuda.PasaProveedor = RecibeCARGO;
            frmayuda.ShowDialog();
        }

        public void RecibeCARGO(string Codigo, string nombre, string codcosto, string nomcosto, string n)
        {
            txtccargo.Text = Codigo;
            txtdcargo.Text = nombre;
        }

        public void RecibeRutaNameImagen(string rutaname, bool zmodificaimagen)
        {
            if (zmodificaimagen)
            {
                VM_mimagen_3 = rutaname;
            }
        }

        private void chkfiltroplanilla_CheckedChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad)
            {
                U_RefrescaControles();
                CargaDatos();
            }
        }
        private void btnficha_Click(object sender, EventArgs e)
        {
            if (u_n_opsel == 0 & (Examinar.CurrentRow != null))
            {
                var xficha = Examinar.Rows[Examinar.CurrentRow.Index].Cells["fichaid"].Value.ToString();
                var xempresa = Examinar.Rows[Examinar.CurrentRow.Index].Cells["empresaid"].Value.ToString();
                var xfichero = string.Empty;
                DataTable dt = null;
                var ncont = 0;
                var zprocesafoto = false;

                var BL = new tb_plla_fichatrabajadoresBL();
                var BE = new tb_plla_fichatrabajadores();
                BE.FichaidIni = xficha;
                BE.FichaidFin = xficha;
                BE.Empresaid = xempresa;
                BE.Norden = 2;
                dt = BL.GetAll_FichaDatos(VariablesPublicas.EmpresaID, BE).Tables[0];
                VariablesPublicas.CrearXml(dt, "fichadatos");
                if (BL.Sql_Error.Trim().Length == 0)
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (ncont = 0; ncont <= dt.Rows.Count - 1; ncont++)
                        {
                            xfichero = string.Empty;
                            zprocesafoto = false;
                            if (dt.Rows[ncont]["fotografia"].ToString().Trim().Length > 0)
                            {
                                xfichero = GlobalVars.GetInstance().RutaFotoPersonal + dt.Rows[ncont]["fotografia"].ToString().Trim();
                                if (System.IO.File.Exists(xfichero))
                                {
                                    try
                                    {
                                        dt.Rows[ncont]["gfoto"] = VariablesPublicas.ImageToByte(System.Drawing.Image.FromFile(GlobalVars.GetInstance().RutaFotoPersonal + dt.Rows[ncont]["fotografia"].ToString().Trim()), true);
                                        zprocesafoto = true;
                                    }
                                    catch (Exception ex)
                                    {
                                        dt.Rows[ncont]["fotografia"] = string.Empty;
                                    }
                                }
                            }
                            else
                            {
                                zprocesafoto = true;
                            }
                            if (!zprocesafoto)
                            {
                                dt.Rows[ncont]["gfoto"] = VariablesPublicas.ImageToByte(BapFormulariosNet.Properties.Resources.error, false);
                                dt.Rows[ncont]["fotografia"] = "ERROR";
                            }
                        }

                        var frmreporte = new Frm_Reportes();
                        frmreporte.Table = dt;
                        frmreporte.Reporte = new Crpt_FichaTrabajador();
                        frmreporte.Show();
                    }
                    else
                    {
                        MessageBox.Show("No existe Información a Procesar", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btncontrato_Click(object sender, EventArgs e)
        {
            DataTable tmpdata = null;
            var xcodestado = string.Empty;
            var xcodficha = "...";
            if ((Examinar.CurrentRow != null))
            {
                xcodficha = Examinar.Rows[Examinar.CurrentRow.Index].Cells["fichaid"].Value.ToString();
            }

            var BL = new tb_plla_fichatrabajadoresBL();
            var BE = new tb_plla_fichatrabajadores();
            BE.Empresaid = Examinar.Rows[Examinar.CurrentRow.Index].Cells["empresaid"].Value.ToString();
            ;
            BE.FichaidIni = xcodficha;
            BE.FichaidFin = xcodficha;
            BE.Situtrabid = xcodestado;
            tmpdata = BL.GetAll_GeneraDatosFormatoContrato(VariablesPublicas.EmpresaID, BE).Tables[0];
            if (BL.Sql_Error.Length > 0)
            {
                Frm_Class.ShowError(BL.Sql_Error, this);
                return;
            }
            var BLPC = new tb_plla_plantilla_contratosBL();
            var BEPC = new tb_plla_plantilla_contratos();
            BEPC.norden = 1;
            BEPC.ver_blanco = 0;
            BEPC.vista = 1;
            tmpcursor = BLPC.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BEPC).Tables[0];
            if (BLPC.Sql_Error.Length > 0)
            {
                Frm_Class.ShowError(BLPC.Sql_Error, this);
                return;
            }
            if (tmpcursor.Rows.Count == 0)
            {
                MessageBox.Show("No hay formatos creados !!!", "Mensaje del Sistema");
                return;
            }
            if (tmpdata.Rows.Count == 0)
            {
                MessageBox.Show("No hay información seleccionada !!!", "Mensaje del Sistema");
                return;
            }
            var xmsgerror = string.Empty;
            if (tmpdata.Rows[0]["VM_SUELDOTRABAJADOR"].ToString().Trim().Length == 0)
            {
                xmsgerror = xmsgerror + "\r" + "Trabajador no tiene remuneración definida !!!";
            }
            else
            {
                if (tmpdata.Rows[0]["msgvalidafecha"].ToString().Trim().Length > 0)
                {
                    xmsgerror = xmsgerror + "\r" + tmpdata.Rows[0]["msgvalidafecha"];
                }
                else
                {
                    if (tmpdata.Rows[0]["VM_NROMESESYDIAS"].ToString().Trim().Length == 0)
                    {
                        xmsgerror = xmsgerror + "\r" + "Trabajador no tiene fechas definidas en el contrato !!!";
                    }
                    else
                    {
                        if (tmpdata.Rows[0]["VM_CENTROCOSTOTRABAJADOR"].ToString().Trim().Length == 0)
                        {
                            xmsgerror = xmsgerror + "\r" + "Trabajador no tiene definido centro de costo !!!";
                        }
                        else
                        {
                            if (tmpdata.Rows[0]["VM_CARGOTRABAJADOR"].ToString().Trim().Length == 0)
                            {
                                xmsgerror = xmsgerror + "\r" + "Trabajador no tiene definido cargo !!!";
                            }
                            else
                            {
                            }
                        }
                    }
                }
            }
            if (xmsgerror.Trim().Length == 0)
            {
                VariablesPublicas.u_GeneraFormatoContrato(tmpdata, tmpcursor);
            }
            else
            {
                MessageBox.Show(xmsgerror, "Mensaje del Sistema");
            }
        }



        private void chkestado_CheckedChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad)
            {
                U_RefrescaControles();
            }
        }

        private void cmbfiltroestado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad)
            {
                CargaDatos();
            }
        }

        private void chkfiltrotipolocal_CheckedChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad)
            {
                U_RefrescaControles();
                CargaDatos();
            }
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            var xdet = string.Empty;
            if (!Sw_LOad & u_n_opsel > 0)
            {
                if (txtDni.Text.Trim().Length > 0)
                {
                    xdet = xdet + txtDni.Text.Trim();
                }
            }
        }

        private void txtfiltronombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnfiltro_Click(sender, e);
            }
        }

        private void txtfiltronumdoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnfiltro_Click(sender, e);
            }
        }

        private void Examinar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Examinar.CurrentRow != null)
                {
                    var xvendorid = string.Empty;
                    xvendorid = Examinar.Rows[e.RowIndex].Cells["_vendorid"].Value.ToString().Trim();
                    data_Vendedor(xvendorid);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void data_Vendedor(String xvendedor)
        {
            u_n_opsel = 0;
            U_RefrescaControles();
            var rowgrupoid = tablaVendedor.Select("vendorid ='" + xvendedor + "'");
            if (rowgrupoid.Length > 0)
            {
                foreach (DataRow row in rowgrupoid)
                {
                    lblvendorid.Text = row["vendorid"].ToString().Trim();
                    txtnombres.Text = row["vendorname"].ToString().Trim();
                    txtccargo.Text = row["cargoid"].ToString().Trim();
                    txttelefono.Text = row["telefono"].ToString().Trim();
                    cbogenero.SelectedValue = row["generoid"].ToString().Trim();
                    txtDni.Text = row["ddnni"].ToString().Trim();
                    txtdireccion.Text = row["direcc"].ToString().Trim();
                    fnacimiento.Text = row["fechnac"].ToString().Trim();
                    fIngreso.Text = row["fechasig"].ToString().Trim();
                }
            }

            btnmod.Enabled = true;
            btnnuevo.Enabled = true;
            btneliminar.Enabled = true;
            btncerrar.Enabled = true;
        }

        private void Examinar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xvendedor = string.Empty;
                xvendedor = Examinar.Rows[Examinar.CurrentRow.Index].Cells["_vendorid"].Value.ToString().Trim();
                data_Vendedor(xvendedor);
            }
        }

        private void Examinar_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Examinar[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            Examinar[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            Examinar.EnableHeadersVisualStyles = false;
            Examinar.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            Examinar.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }
    }
}
