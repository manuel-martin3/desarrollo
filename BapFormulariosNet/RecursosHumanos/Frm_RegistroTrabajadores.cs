using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace BapFormulariosNet.RecursosHumanos
{
    public partial class Frm_RegistroTrabajadores : plantilla
    {
        private DataTable tablaclientes = new DataTable();
        private string _NameColumn = string.Empty;
        private DataTable TablaContratos = new DataTable();
        private TextBox txtCArti;
        private DataTable tmpcursor = new DataTable();
        private string vm_Nombretrabajador = string.Empty;
        private string j_CodUbigeo = string.Empty;
        private string VM_AntiguoValorImagen = string.Empty;
        private string j_xFiltronom = string.Empty;
        private string j_rubro = string.Empty;
        private string VM_mimagen_3 = string.Empty;
        private string j_xfiltrocod = string.Empty;
        private string j_xfiltronumdoc = string.Empty;
        private bool sw_EmpiezaEdicion = false;
        private DataTable tmptabla = new DataTable();
        private string j_ccosto = string.Empty;
        private DataTable TablaRubrosContrato = new DataTable();
        private bool Sw_LOad = true;
        private bool sw_novaluechange = false;
        private decimal j_nvalor = 0;
        private string j_dimporte = string.Empty;
        private int u_n_opsel = 0;
        private int lc_cont = 0;
        private int vmncont;
        private string S_TipoDeta = "TR";
        private string j_String = string.Empty;
        private string j_Ruc = string.Empty;
        private string j_ccargo = string.Empty;

        private int cdClave = 0;

        public Frm_RegistroTrabajadores()
        {
            InitializeComponent();
            KeyDown += Frm_RegistroTrabajadores_KeyDown;
            FormClosing += Frm_RegistroTrabajadores_FormClosing;
            Load += Frm_RegistroTrabajadores_Load;
            Activated += Frm_RegistroTrabajadores_Activated;

            txtfiltronombre.GotFocus += new System.EventHandler(txtfiltronombre_GotFocus);
            txtfiltronombre.LostFocus += new System.EventHandler(txtfiltronombre_LostFocus);

            txtfiltrocodigo.GotFocus += new System.EventHandler(txtfiltrocodigo_GotFocus);
            txtfiltrocodigo.LostFocus += new System.EventHandler(txtfiltrocodigo_LostFocus);

            txtfiltronumdoc.GotFocus += new System.EventHandler(txtfiltronumdoc_GotFocus);
            txtfiltronumdoc.LostFocus += new System.EventHandler(txtfiltronumdoc_LostFocus);

            txtcodigo.LostFocus += new System.EventHandler(txtcodigo_LostFocus);

            txtccosto.GotFocus += new System.EventHandler(txtccosto_GotFocus);
            txtccosto.LostFocus += new System.EventHandler(txtccosto_LostFocus);

            txtccargo.GotFocus += new System.EventHandler(txtccargo_GotFocus);
            txtccargo.LostFocus += new System.EventHandler(txtccargo_LostFocus);

            txtimporte.GotFocus += new System.EventHandler(txtimporte_GotFocus);
            txtimporte.LostFocus += new System.EventHandler(txtimporte_LostFocus);
        }

        public void Llenar_cboTipoDoc()
        {
            try
            {
                cboTipdoc.DataSource = NewMethodoDoc();
                cboTipdoc.DisplayMember = "Value";
                cboTipdoc.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void Llenar_cboVia()
        {
            try
            {
                cboVia.DataSource = NewMethodoVia();
                cboVia.DisplayMember = "Value";
                cboVia.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        public void Llenar_cboZona()
        {
            try
            {
                cboZona.DataSource = NewMethodoZona();
                cboZona.DisplayMember = "Value";
                cboZona.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void Llenar_cboNiveleducativo()
        {
            try
            {
                cboNiveleducativo.DataSource = NewMethoNE();
                cboNiveleducativo.DisplayMember = "Value";
                cboNiveleducativo.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void Llenar_cboTipoPlanilla()
        {
            try
            {
                cboTipoplanilla.DataSource = NewMethoTP();
                cboTipoplanilla.DisplayMember = "Value";
                cboTipoplanilla.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void Llenar_cboTipoPlanillaFil()
        {
            var BL = new tb_plla_tipoplanillaBL();
            var BE = new tb_plla_tipoplanilla();
            BE.norden = 1;
            BE.ver_blanco = 0;
            cmbfiltrotipoplanilla.ValueMember = "tipoplla";
            cmbfiltrotipoplanilla.DisplayMember = "tipopllaname";
            cmbfiltrotipoplanilla.DataSource = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
        }

        private void Llenar_cboCtegOcupacional()
        {
            cmbcategoria.ValueMember = "cateocupid";
            cmbcategoria.DisplayMember = "descripcion";
            var BL = new tb_plla_pdt_tabla24BL();
            var BE = new tb_plla_pdt_tabla24();
            BE.norden = 1;
            BE.ver_blanco = 1;
            cmbcategoria.DataSource = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
        }

        public void LlenarBancodeposito()
        {
            try
            {
                cmbdephaberes.DataSource = NewMethoBcoD();
                cmbdephaberes.DisplayMember = "Value";
                cmbdephaberes.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethoBcoD()
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

        public void LlenarBancoCTS()
        {
            try
            {
                cmbdepcts.DataSource = NewMethoBcoC();
                cmbdepcts.DisplayMember = "Value";
                cmbdepcts.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void Llenar_cboSistPensiones()
        {
            cmbafp.ValueMember = "regipenid";
            cmbafp.DisplayMember = "regipenname";
            var BL = new tb_plla_pdt_tabla11BL();
            var BE = new tb_plla_pdt_tabla11();
            cmbafp.DataSource = BL.GetAll(VariablesPublicas.EmpresaID, BE).Tables[0];
        }

        private void Llenar_cboTipoComisionAFP()
        {
            cboTComision.ValueMember = "cele";
            cboTComision.DisplayMember = "descripcion";

            var BL = new tb_plla_tab0100BL();
            var BE = new tb_plla_tab0100();
            BE.norden = 1;
            BE.ver_blanco = 1;
            cboTComision.DataSource = BL.gspTbPllaTipoComisionAFP(VariablesPublicas.EmpresaID, BE).Tables[0];
        }
        private void Llenar_cboEstadTrabjFil()
        {
            cmbfiltroestado.ValueMember = "cele";
            cmbfiltroestado.DisplayMember = "descripcion";

            var BL = new tb_plla_fichatrabajadoresBL();
            var BE = new tb_plla_fichatrabajadores();

            cmbfiltroestado.DataSource = BL.GetAll_EstadoTrabj(VariablesPublicas.EmpresaID, BE).Tables[0];
        }

        private void Llenar_cboEstadoTrabj()
        {
            cmbestadotrab.ValueMember = "cele";
            cmbestadotrab.DisplayMember = "descripcion";

            var BL = new tb_plla_fichatrabajadoresBL();
            var BE = new tb_plla_fichatrabajadores();

            cmbestadotrab.DataSource = BL.GetAll_EstadoTrabj(VariablesPublicas.EmpresaID, BE).Tables[0];
        }

        private void Llenar_cboTipoRegi()
        {
            cmbtipo.ValueMember = "cele";
            cmbtipo.DisplayMember = "descripcion";

            var BL = new tb_plla_tab0100BL();
            var BE = new tb_plla_tab0100();
            cmbtipo.DataSource = BL.GetAllTiRegi(VariablesPublicas.EmpresaID, BE).Tables[0];
        }

        private void Llenar_cboEstadoCivil()
        {
            cmbestadocivil.ValueMember = "cele";
            cmbestadocivil.DisplayMember = "descripcion";

            var BL = new tb_plla_tab0100BL();
            var BE = new tb_plla_tab0100();
            cmbestadocivil.DataSource = BL.GetAllEstadoCivil(VariablesPublicas.EmpresaID, BE).Tables[0];
        }

        private void Llenar_cboEstadoContrato()
        {
            cmbestado.ValueMember = "cele";
            cmbestado.DisplayMember = "descripcion";

            var BL = new tb_plla_tab0100BL();
            var BE = new tb_plla_tab0100();
            cmbestado.DataSource = BL.GetAllEstadoContrato(VariablesPublicas.EmpresaID, BE).Tables[0];
        }

        public void ModalidadContrato()
        {
            cmbmodalidad.ValueMember = "tipocontratoid";
            cmbmodalidad.DisplayMember = "tipocontratoname";
            var BL = new tb_plla_tipocontratoBL();
            var BE = new tb_plla_tipocontrato();
            cmbmodalidad.DataSource = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
        }

        private void FillResultDepar(ComboBox cboD, ComboBox cboP, ComboBox cboT)
        {
            var BL = new ubigeoBL();
            var BE = new tb_ubigeo();
            try
            {
                cboD.DataSource = BL.GetAll_depar(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                cboD.ValueMember = "ubige";
                cboD.DisplayMember = "depar";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        public void Llenar_cboEps()
        {
            cboEps.ValueMember = "epsid";
            cboEps.DisplayMember = "descripcion";
            var BL = new tb_plla_pdt_tabla14BL();
            var BE = new tb_plla_pdt_tabla14();
            BE.norden = 1;
            BE.incluir_blanco = 1;
            cboEps.DataSource = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
        }

        public void Llenar_cboTpago()
        {
            cboTpago.ValueMember = "tippagoid";
            cboTpago.DisplayMember = "descripcion";
            var BL = new tb_plla_pdt_tabla16BL();
            var BE = new tb_plla_pdt_tabla16();
            cboTpago.DataSource = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
        }

        public void Llenar_cboCtributario()
        {
            cboCtributario.ValueMember = "convendobletribid";
            cboCtributario.DisplayMember = "descripcion";
            var BL = new tb_plla_pdt_tabla25BL();
            var BE = new tb_plla_pdt_tabla25();
            cboCtributario.DataSource = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
        }

        private void Frm_RegistroTrabajadores_Activated(object sender, EventArgs e)
        {
            if (Sw_LOad)
            {
                Llenar_cboTipoPlanillaFil();

                Llenar_cboTipoDoc();
                Llenar_cboVia();
                Llenar_cboZona();
                Llenar_cboNiveleducativo();
                Llenar_cboCtegOcupacional();
                LlenarBancoCTS();
                LlenarBancodeposito();
                for (lc_cont = 0; lc_cont <= examinarrubros.ColumnCount - 1; lc_cont++)
                {
                    examinarrubros.Columns[lc_cont].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                for (lc_cont = 0; lc_cont <= examinaranexos.ColumnCount - 1; lc_cont++)
                {
                    examinaranexos.Columns[lc_cont].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                FillResultDepar(cboDepar, cboProvi, cboDistr);
                FillResultDeparN(cboDeparN, cboProviN, cboDistrN);

                Llenar_cboSistPensiones();

                Llenar_cboTipoRegi();

                Llenar_cboEstadoContrato();

                Llenar_cboEstadTrabjFil();

                Llenar_cboEstadoCivil();

                Llenar_cboEstadoTrabj();

                Llenar_cboTpago();
                Llenar_cboEps();
                Llenar_cboCtributario();

                ModalidadContrato();
                Llenar_cboTipoPlanilla();
                U_RefrescaControles();
                CargaDatos();
                U_RefrescaControles();
                Llenar_cboTipoComisionAFP();
                Sw_LOad = false;
            }
        }

        private void Frm_RegistroTrabajadores_Load(object sender, EventArgs e)
        {
            var arreglobotones = new object[] { btnnuevo,
                    btnmod,
                    btngrabar,
                    btncancelar,
                    btneliminar,
                    btnload,
                    null,
                    btncerrar };

            VariablesPublicas.ConfiguraToolbar(arreglobotones);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            WindowState = FormWindowState.Normal;

            Cargar_Empresaid();

            tcontrato.Items.Clear();
            tcontrato.Items.AddRange("T-Completo,T-Parcial".Split(new char[] { ',' }));
        }


        private void Cargar_Empresaid()
        {
            var BE = new tb_empresa();
            var BL = new empresasBL();

            var dt = new DataTable();

            dt = BL.GetAll(BE).Tables[0];
            cbo_empresaid.DataSource = dt;
            cbo_empresaid.ValueMember = "empresaid";
            cbo_empresaid.DisplayMember = "empresaname";
        }


        private void CargaDatos()
        {
            var xtipoplanilla = string.Empty;
            var xestadotrab = string.Empty;
            var xtipolocal = string.Empty;
            if (cmbfiltroestado.Enabled)
            {
                if (cmbfiltroestado.SelectedValue != null)
                {
                    xestadotrab = cmbfiltroestado.SelectedValue.ToString();
                }
            }
            if (cmbfiltrotipolocal.Enabled)
            {
                if (cmbfiltrotipolocal.SelectedValue != null)
                {
                    xtipolocal = cmbfiltrotipolocal.SelectedValue.ToString();
                }
            }

            if (cmbfiltrotipoplanilla.Enabled)
            {
                if (cmbfiltrotipoplanilla.SelectedValue != null)
                {
                    xtipoplanilla = cmbfiltrotipoplanilla.SelectedValue.ToString();
                }
            }

            var xxxswload = Sw_LOad;
            Sw_LOad = true;
            var BLES = new tb_plla_establecimientosBL();
            var BEES = new tb_plla_establecimientos();
            BEES.empresaid = VariablesPublicas.EmpresaID;
            BEES.norden = 1;
            BEES.ver_blanco = 0;

            cmbfiltrotipolocal.DisplayMember = "estabname";
            cmbfiltrotipolocal.ValueMember = "estabid";
            cmbfiltrotipolocal.DataSource = BLES.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BEES).Tables[0];

            cmbtipolocal.DisplayMember = "estabname";
            cmbtipolocal.ValueMember = "estabid";
            cmbtipolocal.DataSource = BLES.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BEES).Tables[0];

            Sw_LOad = xxxswload;

            var nposcolumnasortear = 0;
            var PrvSotOrder = default(SortOrder);
            var xnumdoclike = txtfiltronumdoc.Text;
            var xcodlike = txtfiltrocodigo.Text;
            var zordenado = false;
            var xcodcliente = "..";
            var xpalabra1 = string.Empty;
            var xpalabra2 = string.Empty;
            var xpalabra3 = string.Empty;
            if (txtfiltronombre.Text.Trim().Length > 0)
            {
                xpalabra1 = VariablesPublicas.Palabras(txtfiltronombre.Text, 1);
                xpalabra2 = VariablesPublicas.Palabras(txtfiltronombre.Text, 2);
                xpalabra3 = VariablesPublicas.Palabras(txtfiltronombre.Text, 3);
            }
            if (Examinar.CurrentRow != null)
            {
                xcodcliente = Examinar.Rows[Examinar.CurrentRow.Index].Cells["fichaid"].Value.ToString();
            }
            if (Examinar.SortedColumn != null)
            {
                nposcolumnasortear = Examinar.SortedColumn.Index;
                PrvSotOrder = Examinar.SortOrder;
                zordenado = true;
            }
            var nestadotrab = 1;
            if (txtfiltronumdoc.Enabled)
            {
                xnumdoclike = txtfiltronumdoc.Text;
            }
            if (chkvercesados.Checked)
            {
                nestadotrab = 0;
            }
            if (txtfiltrocodigo.Enabled)
            {
                xcodlike = txtfiltrocodigo.Text;
            }
            var BL = new tb_plla_fichatrabajadoresBL();
            var BE = new tb_plla_fichatrabajadores();
            BE.Fichaid = xcodlike;
            BE.Nrodni = xnumdoclike;
            BE.Norden = 1;
            BE.Nomlike1 = xpalabra1;
            BE.Nomlike2 = xpalabra2;
            BE.Nomlike3 = xpalabra3;
            BE.Estado_trabaj = nestadotrab;
            BE.Tipoplla = xtipoplanilla;
            BE.Situtrabid = xestadotrab;
            BE.Establec = xtipolocal;

            tablaclientes = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
            lbltotaltrab.Text = string.Empty;
            if (BL.Sql_Error.Length == 0)
            {
                lbltotaltrab.Text = "Total Trabajadores " + tablaclientes.Rows.Count.ToString();
            }
            Examinar.AutoGenerateColumns = false;
            Examinar.DataSource = tablaclientes;

            VariablesPublicas.PintaEncabezados(Examinar);

            if (zordenado)
            {
                if (PrvSotOrder == SortOrder.Ascending)
                {
                    Examinar.Sort(Examinar.Columns[nposcolumnasortear], ListSortDirection.Ascending);
                }
                else
                {
                    Examinar.Sort(Examinar.Columns[nposcolumnasortear], ListSortDirection.Descending);
                }
            }
            else
            {
                Examinar.Sort(Examinar.Columns["nombrelargo"], ListSortDirection.Ascending);
            }
            if (Examinar.CurrentRow == null)
            {
                if (Examinar.RowCount > 0)
                {
                    Examinar.CurrentCell = Examinar.Rows[0].Cells["fichaid"];
                }
            }
            for (lc_cont = 0; lc_cont <= Examinar.Rows.Count - 1; lc_cont++)
            {
                if (Examinar.Rows[lc_cont].Cells["fichaid"].Value.ToString() == xcodcliente)
                {
                    Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["fichaid"];
                    break;
                }
            }
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            u_PintaDatos();
            u_PintaDatos();
        }

        private void U_RefrescaControles()
        {
            var swcierrerem = false;
            var xvmcontrato = string.Empty;
            if (examinaranexos.CurrentRow != null)
            {
                xvmcontrato = examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["ncontrato"].Value.ToString();
                swcierrerem = Convert.ToBoolean(examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["cierreremune"].Value);
            }

            cmbfiltroestado.Enabled = chkestado.Checked;
            cmbfiltrotipolocal.Enabled = chkfiltrotipolocal.Checked;
            cmbfiltrotipoplanilla.Enabled = u_n_opsel == 0 & chkfiltroplanilla.Checked;
            btnficha.Enabled = u_n_opsel == 0;
            cmbestadocivil.Enabled = u_n_opsel > 0;
            cboNiveleducativo.Enabled = u_n_opsel > 0;
            cmbcategoria.Enabled = u_n_opsel > 0;
            rbmasculino.Enabled = u_n_opsel > 0;
            rbsidiscapacitado.Enabled = u_n_opsel > 0;
            rbnodiscapacitado.Enabled = u_n_opsel > 0;
            rbfemenino.Enabled = u_n_opsel > 0;
            cboVia.Enabled = u_n_opsel > 0;
            cboZona.Enabled = u_n_opsel > 0;
            cboDepar.Enabled = u_n_opsel > 0;
            cboProvi.Enabled = u_n_opsel > 0;
            cboDistr.Enabled = u_n_opsel > 0;
            cboDeparN.Enabled = u_n_opsel > 0;
            cboProviN.Enabled = u_n_opsel > 0;
            cboDistrN.Enabled = u_n_opsel > 0;
            cbo_empresaid.Enabled = u_n_opsel > 0;

            btnPais.Enabled = u_n_opsel > 0;

            btnload.Enabled = u_n_opsel == 0;
            grpdatoscontrato.Enabled = u_n_opsel > 0 & !swcierrerem;
            var xpension = string.Empty;
            cmbafp.Enabled = u_n_opsel > 0;
            if (cmbafp.SelectedValue != null)
            {
                if (Equivalencias.Left(cmbafp.SelectedValue.ToString(), 1) == "2")
                {
                    xpension = Equivalencias.Left(cmbafp.SelectedValue.ToString(), 1);
                }
            }
            fafiliacion.Enabled = u_n_opsel > 0 & xpension == "2";
            txtctaafp.Enabled = u_n_opsel > 0 & xpension == "2";
            cboTComision.Enabled = u_n_opsel > 0 & xpension == "2";
            btnprimero.Enabled = u_n_opsel == 0;
            btnultimo.Enabled = u_n_opsel == 0;
            btnsiguiente.Enabled = u_n_opsel == 0;
            btnanterior.Enabled = u_n_opsel == 0;
            var xcodcliente = string.Empty;
            txtdcargo.Enabled = false;
            txtdcosto.Enabled = false;
            txtccargo.Enabled = u_n_opsel > 0;
            txtccosto.Enabled = u_n_opsel > 0;

            if ((Examinar.CurrentRow != null))
            {
                xcodcliente = Examinar.Rows[Examinar.CurrentCell.RowIndex].Cells["fichaid"].Value.ToString();
            }
            btnaddrubro.Enabled = u_n_opsel > 0 & !swcierrerem;
            btndelrubro.Enabled = u_n_opsel > 0 & xvmcontrato.Trim().Length > 0 & !swcierrerem;
            txtcodigo.Enabled = u_n_opsel == 1;
            cbo_empresaid.Enabled = u_n_opsel == 1;
            txtDni.Enabled = u_n_opsel > 0;
            txtcoddetalle.Enabled = false;
            txtnomdetalle.Enabled = false;
            cboTipdoc.Enabled = u_n_opsel > 0;
            cmbtipo.Enabled = false;
            btnnuevo.Enabled = u_n_opsel == 0;
            btngrabar.Enabled = u_n_opsel > 0;
            btnmod.Enabled = u_n_opsel == 0 & xcodcliente.Length > 0;
            btneliminar.Enabled = u_n_opsel == 0 & xcodcliente.Length > 0;
            btncancelar.Enabled = u_n_opsel > 0;
            btncerrar.Enabled = u_n_opsel == 0;
            barramain.Enabled = cdClave == 0;
            Examinar.Enabled = u_n_opsel == 0;
            grpestado.Enabled = u_n_opsel > 0;
            btnlog.Enabled = u_n_opsel == 0;
            cmbestadotrab.Enabled = false;

            cmbestadocivil.Enabled = u_n_opsel > 0;
            cmbtipolocal.Enabled = u_n_opsel > 0;

            btnfoto.Enabled = true;
            chksctr.Enabled = u_n_opsel > 0;
            chkremintegral.Enabled = u_n_opsel > 0;
            chkautocontrol.Enabled = false;
            chkesalud.Enabled = u_n_opsel > 0;
            txtcarnetseguro.Enabled = u_n_opsel > 0;
            txtapemat.Enabled = u_n_opsel > 0;
            txtapepat.Enabled = u_n_opsel > 0;
            txtnombres.Enabled = u_n_opsel > 0;

            txtNombrelargo.Enabled = u_n_opsel > 0 & rbjuridica.Checked;
            opttipopersona.Enabled = u_n_opsel > 0;
            cmbdepcts.Enabled = u_n_opsel > 0 & chkdepcts.Checked;
            cmbdephaberes.Enabled = u_n_opsel > 0 & chkdephaberes.Checked;
            txtctahaberes.Enabled = u_n_opsel > 0 & chkdephaberes.Checked;
            txtctacts.Enabled = u_n_opsel > 0 & chkdepcts.Checked;
            chkdephaberes.Enabled = u_n_opsel > 0;
            chkdepcts.Enabled = u_n_opsel > 0;

            txtdireccion.Enabled = u_n_opsel > 0;
            txtdetallecontable.Enabled = false;
            txtobservaciones.Enabled = u_n_opsel > 0;

            txtemail.Enabled = u_n_opsel > 0;
            txtfax.Enabled = u_n_opsel > 0;

            fIngreso.Enabled = u_n_opsel > 0;
            fnacimiento.Enabled = u_n_opsel > 0;
            txttelefono.Enabled = u_n_opsel > 0;

            cboEps.Enabled = u_n_opsel > 0;
            cboSitutrab.Enabled = u_n_opsel > 0;
            cboTpago.Enabled = u_n_opsel > 0;
            rbsiConvenio.Enabled = u_n_opsel > 0;
            rbnoConvenio.Enabled = u_n_opsel > 0;
            cboCtributario.Enabled = u_n_opsel > 0 & rbsiConvenio.Checked;
            tcontrato.Enabled = u_n_opsel > 0;

            examinaranexos.ReadOnly = true;
            examinarrubros.ReadOnly = u_n_opsel == 0;
            if (swcierrerem)
            {
                examinarrubros.ReadOnly = true;
            }
            else
            {
                examinarrubros.Columns["rubroname"].ReadOnly = true;
                examinarrubros.Columns["ncontrator"].ReadOnly = true;
                examinarrubros.Columns["importemensual"].ReadOnly = true;
            }

            btnadddivision.Enabled = u_n_opsel > 0 & !swcierrerem;
            btndeldivision.Enabled = u_n_opsel > 0 & examinaranexos.Rows.Count > 0 & !swcierrerem;
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            if (!(TabControl1.SelectedIndex == 0))
            {
                TabControl1.SelectedIndex = 0;
            }
            vm_Nombretrabajador = string.Empty;
            u_n_opsel = 1;
            Blanquear();
            TabControl1.SelectedIndex = 0;
            TabControl1.SelectedIndex = 1;
            cbo_empresaid.Enabled = true;
            cbo_empresaid.SelectedIndex = -1;
        }

        private void Blanquear()
        {
            txtcoddetalle.Text = string.Empty;
            txtnomdetalle.Text = string.Empty;
            txtdescripcampo.Text = string.Empty;
            txtcodigo.Text = string.Empty;
            txtNombrelargo.Text = string.Empty;
            txtDni.Text = string.Empty;
            cboTipdoc.SelectedValue = string.Empty;
            cmbtipo.SelectedValue = string.Empty;
            txtnombres.Text = string.Empty;
            rbsidiscapacitado.Checked = false;
            rbnodiscapacitado.Checked = false;
            rbjuridica.Checked = true;
            cmbdephaberes.SelectedValue = string.Empty;
            cmbdepcts.SelectedValue = string.Empty;
            txtctahaberes.Text = string.Empty;
            txtctacts.Text = string.Empty;
            txtapepat.Text = string.Empty;
            VM_mimagen_3 = string.Empty;
            chkdephaberes.Checked = false;
            chkdepcts.Checked = false;
            chksctr.Checked = false;
            chkautocontrol.Checked = false;
            chkesalud.Checked = false;
            chkremintegral.Checked = false;
            cmbestadotrab.SelectedValue = string.Empty;
            cmbestadocivil.SelectedValue = string.Empty;
            txtcarnetseguro.Text = string.Empty;
            cmbtipolocal.SelectedValue = string.Empty;
            txtapemat.Text = string.Empty;
            txtnombres.Text = string.Empty;
            txtdireccion.Text = string.Empty;
            txtdetallecontable.Text = string.Empty;
            txtobservaciones.Text = string.Empty;

            txtemail.Text = string.Empty;
            txtfax.Text = string.Empty;
            cmbcategoria.SelectedValue = string.Empty;
            cboNiveleducativo.SelectedValue = string.Empty;
            fIngreso.Checked = false;

            txttelefono.Text = string.Empty;

            txtctaafp.Text = string.Empty;
            cmbafp.SelectedValue = string.Empty;

            cboEps.SelectedValue = string.Empty;
            cboSitutrab.SelectedValue = string.Empty;
            cboTpago.SelectedValue = string.Empty;
            cboCtributario.SelectedValue = string.Empty;
            rbsiConvenio.Checked = false;
            rbnoConvenio.Checked = false;

            if (TablaContratos != null)
            {
                TablaContratos.AcceptChanges();
                if (TablaContratos.Rows.Count > 0)
                {
                    for (vmncont = 0; vmncont <= TablaContratos.Rows.Count - 1; vmncont++)
                    {
                        TablaContratos.Rows[vmncont].Delete();
                    }
                    TablaContratos.AcceptChanges();
                }
            }

            if (TablaRubrosContrato != null)
            {
                TablaRubrosContrato.AcceptChanges();
                if (TablaRubrosContrato.Rows.Count > 0)
                {
                    for (vmncont = 0; vmncont <= TablaRubrosContrato.Rows.Count - 1; vmncont++)
                    {
                        TablaRubrosContrato.Rows[vmncont].Delete();
                    }
                    TablaRubrosContrato.AcceptChanges();
                }
            }
            txtcoddetalle.Text = string.Empty;
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
                var xtmpuser = txtcodigo.Text;
                u_n_opsel = 0;
                TabControl1.SelectedIndex = 0;
                U_RefrescaControles();
                CargaDatos();

                if (Examinar.RowCount > 0)
                {
                    for (lc_cont = 0; lc_cont <= Examinar.Rows.Count - 1; lc_cont++)
                    {
                        if (Examinar.Rows[lc_cont].Cells["fichaid"].Value.ToString() == xtmpuser)
                        {
                            Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["fichaid"];
                            break;
                        }
                    }
                }
            }
        }

        private void btnmod_Click(object sender, EventArgs e)
        {
            if (!(TabControl1.SelectedIndex == 0))
            {
                TabControl1.SelectedIndex = 0;
            }
            u_n_opsel = 2;
            sw_EmpiezaEdicion = true;
            TabControl1.SelectedIndex = 0;
            TabControl1.SelectedIndex = 1;
            j_Ruc = txtDni.Text;
            sw_EmpiezaEdicion = false;
            VM_AntiguoValorImagen = VM_mimagen_3;
            vm_Nombretrabajador = string.Empty;
            cboEps_SelectedIndexChanged(sender, e);
            if (Examinar.CurrentRow != null)
            {
                vm_Nombretrabajador = Examinar.Rows[Examinar.CurrentRow.Index].Cells["nombrelargo"].Value.ToString().Trim();
            }
            if (txtNombrelargo.Enabled)
            {
                txtNombrelargo.Focus();
            }
            else
            {
                txtapepat.Focus();
            }

            u_PintaDatos();
        }

        private void btngrabar_Click(object sender, EventArgs e)
        {
            if (U_Validacion())
            {
                var tmpcursor = new DataTable();

                if (u_n_opsel == 1)
                {
                    var BL = new tb_plla_fichatrabajadoresBL();
                    var BE = new tb_plla_fichatrabajadores();
                    BE.Fichaid = txtcodigo.Text.Trim();
                    BE.Empresaid = cbo_empresaid.SelectedValue.ToString();
                    BE.Norden = 1;
                    BE.Estado_trabaj = 0;

                    tmpcursor = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
                    if (tmpcursor.Rows.Count > 0)
                    {
                        var BLMX = new tb_plla_fichatrabajadoresBL();
                        var Codigo = cbo_empresaid.SelectedValue.ToString();
                        txtcodigo.Text = BLMX.GetAll_ConsultaMaxCod(VariablesPublicas.EmpresaID.ToString(), Codigo).Tables[0].Rows[0]["maximo_codigo"].ToString();
                    }
                    tmpcursor.Rows.Add(VariablesPublicas.InsertIntoTable(tmpcursor));
                    var BLMX1 = new tb_plla_fichatrabajadoresBL();
                    var Codigo1 = cbo_empresaid.SelectedValue.ToString();

                    tmpcursor.Rows[0]["fichaid"] = BLMX1.GetAll_ConsultaMaxCod(VariablesPublicas.EmpresaID.ToString(), Codigo1).Tables[0].Rows[0]["maximo_codigo"].ToString();
                    tmpcursor.Rows[0]["activo"] = "1";
                    tmpcursor.Rows[0]["status"] = "0";
                    tmpcursor.Rows[0]["motivocese"] = string.Empty;
                    tmpcursor.Rows[0]["fechcese"] = DBNull.Value;
                    tmpcursor.Rows[0]["tipsuspenid"] = string.Empty;
                }
                else
                {
                    var BL = new tb_plla_fichatrabajadoresBL();
                    var BE = new tb_plla_fichatrabajadores();
                    BE.Fichaid = txtcodigo.Text.Trim();
                    BE.Empresaid = cbo_empresaid.SelectedValue.ToString();
                    BE.Norden = 1;
                    BE.Estado_trabaj = 0;
                    tmpcursor = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
                }

                tmpcursor.Rows[0]["empresaid"] = cbo_empresaid.SelectedValue;

                tmpcursor.Rows[0]["fichaid"] = txtcodigo.Text.Trim();
                tmpcursor.Rows[0]["apepat"] = txtapepat.Text.Trim();
                tmpcursor.Rows[0]["apemat"] = txtapemat.Text.Trim();
                tmpcursor.Rows[0]["nombres"] = txtnombres.Text.Trim();
                tmpcursor.Rows[0]["nombrelargo"] = txtNombrelargo.Text.Trim();
                if ((cboTipdoc.SelectedValue != null))
                {
                    tmpcursor.Rows[0]["tipdocid"] = cboTipdoc.SelectedValue;
                }
                tmpcursor.Rows[0]["nrodni"] = txtDni.Text.Trim();
                tmpcursor.Rows[0]["nmruc"] = txtDni.Text.Trim();
                tmpcursor.Rows[0]["ctactename"] = txtNombrelargo.Text.Trim();
                tmpcursor.Rows[0]["direcc"] = txtdireccion.Text.Trim();
                if ((cboDistr.SelectedValue != null))
                {
                    tmpcursor.Rows[0]["ubiged"] = cboDistr.SelectedValue;
                }
                if ((cboDistrN.SelectedValue != null))
                {
                    tmpcursor.Rows[0]["ubigen"] = cboDistrN.SelectedValue;
                }
                if ((cmbestadocivil.SelectedValue != null))
                {
                    tmpcursor.Rows[0]["estadocivil"] = cmbestadocivil.SelectedValue;
                }
                else
                {
                    tmpcursor.Rows[0]["estadocivil"] = string.Empty;
                }
                if (rbmasculino.Checked)
                {
                    tmpcursor.Rows[0]["sexo"] = "M";
                }
                else
                {
                    tmpcursor.Rows[0]["sexo"] = "F";
                }
                tmpcursor.Rows[0]["telef1"] = txttelefono.Text.Trim();
                tmpcursor.Rows[0]["telef2"] = txtfax.Text.Trim();
                tmpcursor.Rows[0]["carnetsegsoc"] = txtcarnetseguro.Text.Trim();
                tmpcursor.Rows[0]["fechnacimiento"] = fnacimiento.Value;
                if (fIngreso.Checked)
                {
                    tmpcursor.Rows[0]["fechingreso"] = fIngreso.Value;
                }
                else
                {
                    tmpcursor.Rows[0]["fechingreso"] = DBNull.Value;
                }
                if ((cmbestadotrab.SelectedValue != null))
                {
                    tmpcursor.Rows[0]["situtrabid"] = cmbestadotrab.SelectedValue;
                }
                tmpcursor.Rows[0]["sctr"] = chksctr.Checked;
                tmpcursor.Rows[0]["remintegral"] = chkremintegral.Checked;
                tmpcursor.Rows[0]["autocontrol"] = chkautocontrol.Checked;
                tmpcursor.Rows[0]["chkdephab"] = chkdephaberes.Checked;
                if ((cmbdephaberes.SelectedValue != null))
                {
                    tmpcursor.Rows[0]["bancoidhab"] = cmbdephaberes.SelectedValue;
                }
                else
                {
                    tmpcursor.Rows[0]["bancoidhab"] = string.Empty;
                }
                tmpcursor.Rows[0]["ctahaberes"] = txtctahaberes.Text.Trim();
                tmpcursor.Rows[0]["chkdepcts"] = chkdepcts.Checked;
                if ((cmbdepcts.SelectedValue != null))
                {
                    tmpcursor.Rows[0]["bancoidcts"] = cmbdepcts.SelectedValue;
                }
                else
                {
                    tmpcursor.Rows[0]["bancoidcts"] = string.Empty;
                }
                tmpcursor.Rows[0]["ctacts"] = txtctacts.Text.Trim();
                if ((cmbtipo.SelectedValue != null))
                {
                    tmpcursor.Rows[0]["tipodeta"] = cmbtipo.SelectedValue;
                }
                tmpcursor.Rows[0]["cencosid"] = txtccosto.Text.Trim();
                tmpcursor.Rows[0]["cargoid"] = txtccargo.Text.Trim();
                tmpcursor.Rows[0]["detallecontable"] = txtdetallecontable.Text.Trim();
                if ((cmbafp.SelectedValue != null))
                {
                    tmpcursor.Rows[0]["regipenid"] = cmbafp.SelectedValue;
                }
                if (Equivalencias.Left(cmbafp.SelectedValue.ToString(), 1) == "2")
                {
                    tmpcursor.Rows[0]["cuspp"] = txtctaafp.Text.Trim();
                    if (fafiliacion.Checked)
                    {
                        tmpcursor.Rows[0]["fechafiliacion"] = fafiliacion.Value;
                    }
                    if ((cboTComision.SelectedValue != null))
                    {
                        tmpcursor.Rows[0]["tipcomisionafp"] = cboTComision.SelectedValue;
                    }
                }
                else
                {
                    tmpcursor.Rows[0]["cuspp"] = string.Empty;
                    tmpcursor.Rows[0]["fechafiliacion"] = DBNull.Value;
                    tmpcursor.Rows[0]["tipcomisionafp"] = string.Empty;
                }
                tmpcursor.Rows[0]["essaludvida"] = chkesalud.Checked;
                tmpcursor.Rows[0]["email"] = txtemail.Text.Trim();
                if ((cboNiveleducativo.SelectedValue != null))
                {
                    tmpcursor.Rows[0]["niveleduid"] = cboNiveleducativo.SelectedValue;
                }
                else
                {
                    tmpcursor.Rows[0]["niveleduid"] = string.Empty;
                }
                if (rbsidiscapacitado.Checked)
                {
                    tmpcursor.Rows[0]["discapacitado"] = rbsidiscapacitado.Checked;
                }
                if (rbnodiscapacitado.Checked)
                {
                    tmpcursor.Rows[0]["discapacitado"] = false;
                }
                tmpcursor.Rows[0]["tipestabid"] = string.Empty;
                if ((cmbtipolocal.SelectedValue != null))
                {
                    tmpcursor.Rows[0]["establec"] = cmbtipolocal.SelectedValue;
                }
                if ((cmbcategoria.SelectedValue != null))
                {
                    tmpcursor.Rows[0]["cateocupid"] = cmbcategoria.SelectedValue;
                }
                else
                {
                    tmpcursor.Rows[0]["cateocupid"] = string.Empty;
                }
                tmpcursor.Rows[0]["fotografia"] = VM_mimagen_3;
                tmpcursor.Rows[0]["observacion"] = txtobservaciones.Text.Trim();
                if (u_n_opsel == 1 | object.ReferenceEquals(tmpcursor.Rows[0]["fechregistro"], DBNull.Value))
                {
                    tmpcursor.Rows[0]["fechregistro"] = DateTime.Now;
                }
                if ((TablaContratos != null))
                {
                    if (TablaContratos.Rows.Count > 0)
                    {
                        if ((!object.ReferenceEquals(TablaContratos.Rows[TablaContratos.Rows.Count - 1]["tipoplla"], DBNull.Value)))
                        {
                            tmpcursor.Rows[0]["tipoplla"] = TablaContratos.Rows[TablaContratos.Rows.Count - 1]["tipoplla"];
                        }
                    }
                }
                if ((cboVia.SelectedValue != null))
                {
                    tmpcursor.Rows[0]["viaid"] = cboVia.SelectedValue;
                }
                else
                {
                    tmpcursor.Rows[0]["viaid"] = string.Empty;
                }
                if ((cboZona.SelectedValue != null))
                {
                    tmpcursor.Rows[0]["zonaid"] = cboZona.SelectedValue;
                }
                else
                {
                    tmpcursor.Rows[0]["zonaid"] = string.Empty;
                }
                if ((cboEps.SelectedValue != null))
                {
                    tmpcursor.Rows[0]["epsid"] = cboEps.SelectedValue;
                }
                else
                {
                    tmpcursor.Rows[0]["epsid"] = string.Empty;
                }
                if ((cboSitutrab.SelectedValue != null))
                {
                    tmpcursor.Rows[0]["situtrab"] = cboSitutrab.SelectedValue;
                }
                else
                {
                    tmpcursor.Rows[0]["situtrab"] = string.Empty;
                }
                if ((cboTpago.SelectedValue != null))
                {
                    tmpcursor.Rows[0]["tippagoid"] = cboTpago.SelectedValue;
                }
                else
                {
                    tmpcursor.Rows[0]["tippagoid"] = string.Empty;
                }
                if (rbsiConvenio.Checked)
                {
                    tmpcursor.Rows[0]["chkconvenio"] = rbsiConvenio.Checked;
                }
                if (rbnoConvenio.Checked)
                {
                    tmpcursor.Rows[0]["chkconvenio"] = false;
                }
                if ((cboCtributario.SelectedValue != null))
                {
                    tmpcursor.Rows[0]["convendobletribid"] = cboCtributario.SelectedValue;
                }
                else
                {
                    tmpcursor.Rows[0]["convendobletribid"] = string.Empty;
                }
                tmpcursor.Rows[0]["paisid"] = txtpaisid.Text.Trim();
                tmpcursor.Rows[0]["status"] = (rbactivo.Checked ? "0" : "9");
                tmpcursor.Rows[0]["usuar"] = VariablesPublicas.Usuar.Trim();

                for (lc_cont = 0; lc_cont <= TablaContratos.Rows.Count - 1; lc_cont++)
                {
                    TablaContratos.Rows[lc_cont]["fichaid"] = txtcodigo.Text.Trim();
                    TablaContratos.Rows[lc_cont]["empresaid"] = cbo_empresaid.SelectedValue;
                }
                for (lc_cont = 0; lc_cont <= TablaRubrosContrato.Rows.Count - 1; lc_cont++)
                {
                    TablaRubrosContrato.Rows[lc_cont]["fichaid"] = txtcodigo.Text.Trim();
                    TablaRubrosContrato.Rows[lc_cont]["empresaid"] = cbo_empresaid.SelectedValue;
                }

                var BLIN = new tb_plla_fichatrabajadoresBL();

                if (BLIN.Insert_Update(VariablesPublicas.EmpresaID, tmpcursor, TablaContratos, TablaRubrosContrato))
                {
                    seguridadlog();
                    U_CancelarEdicion(0);
                }
                else
                {
                    Frm_Class.ShowError(BLIN.Sql_Error, this);
                }
            }
        }
        private void seguridadlog()
        {
            var xclave = VariablesPublicas.EmpresaID + txtcodigo.Text.Trim();
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
                BE.detalle = "Trabajador: " + txtNombrelargo.Text.Trim();

                BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if ((Examinar.CurrentRow != null))
            {
                var xnomcampo = string.Empty;
                if (xnomcampo.Length == 0)
                {
                    var BL = new tb_plla_fichatrabajadoresBL();
                    var BE = new tb_plla_fichatrabajadores();
                    BE.Fichaid = Examinar.Rows[Examinar.CurrentRow.Index].Cells["fichaid"].Value.ToString();
                    BE.Empresaid = Examinar.Rows[Examinar.CurrentRow.Index].Cells["empresaid"].Value.ToString();
                    BE.Norden = 1;
                    BE.Estado_trabaj = 0;
                    tmptabla = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
                    if (BL.Sql_Error.Length == 0)
                    {
                        var message = "Desea eliminar datos de Trabajador " + tmptabla.Rows[0]["fichaid"].ToString().Trim() + " - " + tmptabla.Rows[0]["nombrelargo"].ToString().Trim() + " ...?";
                        var caption = "Mensaje del Sistema";
                        var buttons = MessageBoxButtons.YesNo;
                        DialogResult result;
                        result = MessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                            var BL1 = new tb_plla_fichatrabajadoresBL();
                            if (BL1.Eliminar(VariablesPublicas.EmpresaID, tmptabla))
                            {
                                var BLS = new tb_co_seguridadlogBL();
                                var BES = new tb_co_seguridadlog();

                                BES.moduloid = Name;
                                BES.clave = VariablesPublicas.EmpresaID + Examinar.Rows[Examinar.CurrentRow.Index].Cells["fichaid"].Value.ToString();
                                BES.cuser = VariablesPublicas.Usuar;
                                BES.fecha = DateTime.Now;
                                BES.pc = VariablesPublicas.userip;
                                BES.accion = "B";
                                BES.detalle = "Trabajador:" + txtNombrelargo.Text.Trim();

                                BLS.Insert(VariablesPublicas.EmpresaID.ToString(), BES);
                                Examinar.Rows.Remove(Examinar.CurrentRow);
                                Examinar.Refresh();
                            }
                        }
                    }
                    else
                    {
                        Frm_Class.ShowError(BL.Sql_Error, this);
                    }
                }
                else
                {
                    MessageBox.Show(xnomcampo, "IMPOSIBLE ELIMINAR REGISTRO");
                }
            }
            U_RefrescaControles();
        }

        private void Frm_RegistroTrabajadores_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (u_n_opsel > 0)
            {
                MessageBox.Show("Finalice edición para cerrar formulario", "Mensaje del Sistema");
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
            TabControl1.SelectedIndex = TabControl1.SelectedIndex;
        }

        public bool U_Validacion()
        {
            var xmsg = string.Empty;
            var objeto = new object();
            DataTable tmptabla = null;

            if (txtnombres.Text.Trim().Length == 0)
            {
                xmsg = "Ingrese Apellidos y Nombres del Trabajador";
                objeto = txtNombrelargo;
            }
            else
            {
                if (txtDni.Text.Length > 0)
                {
                    if (u_n_opsel == 1 | (!(j_Ruc == txtDni.Text)))
                    {
                        var BL = new tb_plla_fichatrabajadoresBL();
                        var BE = new tb_plla_fichatrabajadores();
                        BE.Tipdocid = cboTipdoc.SelectedValue.ToString();
                        BE.Nrodni = txtDni.Text.Trim();
                        tmptabla = BL.GetAll(VariablesPublicas.EmpresaID, BE).Tables[0];
                        if (tmptabla.Rows.Count > 0)
                        {
                            xmsg = "DNI ya registrado";
                            objeto = txtDni;
                        }
                    }
                }
                if (u_n_opsel == 1)
                {
                    if (txtcodigo.Text.Trim().Length == 0)
                    {
                        xmsg = "Ingrese Código";
                        objeto = txtcodigo;
                    }
                    else
                    {
                        var BL = new tb_plla_fichatrabajadoresBL();
                        var BE = new tb_plla_fichatrabajadores();
                        BE.Fichaid = txtcodigo.Text.Trim();
                        BE.Empresaid = cbo_empresaid.SelectedValue.ToString();
                        tmptabla = BL.GetAll(VariablesPublicas.EmpresaID, BE).Tables[0];
                        if (tmptabla.Rows.Count > 0)
                        {
                            xmsg = "Código ya registrado";
                            objeto = txtcodigo;
                        }
                    }
                }
            }
            if (fIngreso.Checked == false)
            {
                xmsg = xmsg + "\r" + "Ingrese fecha de ingreso";
                objeto = fIngreso;
            }
            if (xmsg.Trim().Length == 0)
            {
                if (!(VM_AntiguoValorImagen == VM_mimagen_3))
                {
                    if (!VariablesPublicas.CopiarArchivo(VM_mimagen_3))
                    {
                        xmsg = xmsg + "\r" + "Error al Subir Archivo";
                    }
                    else
                    {
                        VM_mimagen_3 = VariablesPublicas.NombreArchivoSubido;
                    }
                }
            }
            if (u_n_opsel == 1 | !(vm_Nombretrabajador == txtapepat.Text.Trim() + " " + txtapemat.Text.Trim() + " " + txtnombres.Text.Trim()))
            {
                string tmpstring = null;
                tmpstring = txtapepat.Text.Trim() + " " + txtapemat.Text.Trim() + " " + txtnombres.Text.Trim();
                var BL = new tb_plla_fichatrabajadoresBL();
                var BE = new tb_plla_fichatrabajadores();
                BE.Nombrelargo = VariablesPublicas.Palabras(tmpstring, 1);
                BE.Nombrelargo = VariablesPublicas.Palabras(tmpstring, 2);
                BE.Nombrelargo = VariablesPublicas.Palabras(tmpstring, 3);
                BE.Nrodni = txtDni.Text.Trim();
                tmpcursor = BL.GetAll(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (BL.Sql_Error.Length > 0)
                {
                    Frm_Class.ShowError(BL.Sql_Error + "\r" + "Error al validar duplicidad de nombres", this);
                    return false;
                }
                if (tmpcursor.Rows.Count > 0)
                {
                    if (u_n_opsel == 1)
                    {
                        xmsg = xmsg + "\r" + "Trabajador ya se encuentra registrado con código " + tmpcursor.Rows[0]["fichaid"] + "-" + tmpcursor.Rows[0]["nombrelargo"];
                        objeto = txtapemat;
                    }
                    else
                    {
                        for (lc_cont = 0; lc_cont <= tmpcursor.Rows.Count - 1; lc_cont++)
                        {
                            if (!(tmpcursor.Rows[lc_cont]["fichaid"].ToString() == txtcodigo.Text))
                            {
                                xmsg = xmsg + "\r" + "Trabajador ya se encuentra registrado con código " + tmpcursor.Rows[lc_cont]["fichaid"] + "-" + tmpcursor.Rows[lc_cont]["nombrelargo"];
                                objeto = txtapemat;
                                break;
                            }
                        }
                    }
                }
            }
            if (xmsg.Trim().Length > 0)
            {
                MessageBox.Show(xmsg.Trim(), "Error en Ingreso de Datos");
                if ((objeto != null))
                {
                    objeto = Focus();
                }
            }
            return xmsg.Trim().Length == 0;
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
            if (e.KeyCode == Keys.F5 & btnload.Enabled)
            {
                btnload_Click(sender, e);
            }
            if (e.KeyCode == Keys.F4 & Examinar.Enabled)
            {
                TabControl1.SelectedIndex = 0;
                Examinar.Focus();
                Examinar.BeginEdit(true);
            }
            if (e.KeyCode == Keys.Down & e.Control & u_n_opsel > 0)
            {
                if (btnadddivision.Enabled)
                {
                    btnadddivision_Click(sender, e);
                }
            }
            if (e.KeyCode == Keys.Delete & e.Control & u_n_opsel > 0)
            {
                if (btndeldivision.Enabled)
                {
                    btndeldivision_Click(sender, e);
                }
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
            examinaranexos.Refresh();
            examinaranexos.CurrentCell = examinaranexos.Rows[examinaranexos.Rows.Count - 1].Cells["ncontrato"];
            examinaranexos.BeginEdit(true);
            TablaContratos.AcceptChanges();
            U_RefrescaControles();
        }

        private void btndeldivision_Click(object sender, EventArgs e)
        {
            if ((examinaranexos != null))
            {
                if (TablaContratos.Rows.Count > 0)
                {
                    var xvmcodigo = examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["ncontrato"].Value.ToString();
                    for (lc_cont = 0; lc_cont <= TablaRubrosContrato.Rows.Count - 1; lc_cont++)
                    {
                        if (xvmcodigo.Trim().Length > 0 & TablaRubrosContrato.Rows[lc_cont]["ncontrato"].ToString() == xvmcodigo)
                        {
                            TablaRubrosContrato.Rows[lc_cont].Delete();
                        }
                    }
                    examinaranexos.Rows.Remove(examinaranexos.CurrentRow);
                    TablaContratos.AcceptChanges();
                    TablaRubrosContrato.AcceptChanges();
                    examinaranexos.Refresh();
                    U_RefrescaControles();
                }
            }
            else
            {
                MessageBox.Show("Seleccione Contrato a Eliminar", "Mensaje del Sistema");
            }
        }

        private void examinaranexos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (examinaranexos.Columns[examinaranexos.CurrentCell.ColumnIndex].Name.ToUpper() == "cod_ubigeo".ToUpper())
            {
                j_CodUbigeo = examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["cod_ubigeo"].Value.ToString();
            }
        }
        private void examinaranexos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            _NameColumn = string.Empty;
            if (examinaranexos.Columns[examinaranexos.CurrentCell.ColumnIndex].Name.ToUpper() == "direcc_10".ToUpper())
            {
                txtCArti = (TextBox)e.Control;
                txtCArti.MaxLength = TablaContratos.Columns["direcc_10"].MaxLength;
                txtCArti.CharacterCasing = CharacterCasing.Normal;
                txtCArti.Text.Trim();
                e.Control.KeyDown += VariablesPublicas.CapturarTeclaGRID;
                _NameColumn = examinaranexos.Columns[examinaranexos.CurrentCell.ColumnIndex].Name.ToUpper();
            }
            if (examinaranexos.Columns[examinaranexos.CurrentCell.ColumnIndex].Name.ToUpper() == "cod_ubigeo".ToUpper())
            {
                txtCArti = (TextBox)e.Control;
                txtCArti.MaxLength = TablaContratos.Columns["cod_ubigeo"].MaxLength;
                txtCArti.CharacterCasing = CharacterCasing.Normal;
                txtCArti.Text.Trim();
                e.Control.KeyDown += VariablesPublicas.CapturarTeclaGRID;
                _NameColumn = examinaranexos.Columns[examinaranexos.CurrentCell.ColumnIndex].Name.ToUpper();
            }
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
        private void examinaranexos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!Sw_LOad)
            {
                if ((examinaranexos.CurrentRow != null))
                {
                    sw_novaluechange = true;
                    if (examinaranexos.Columns[e.ColumnIndex].Name.ToUpper() == "cod_ubigeo".ToUpper())
                    {
                    }
                    sw_novaluechange = false;
                }
            }
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

        private void TabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (u_n_opsel > 0)
            {
                if (TabControl1.Controls[e.TabPageIndex].Name.ToUpper() == "TABPAGE1")
                {
                    e.Cancel = true;
                }
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
            if (txtapepat.Text.Trim().Length > 0)
            {
                xprvnom = xprvnom + txtapepat.Text.Trim() + " ";
            }
            if (txtapemat.Text.Trim().Length > 0)
            {
                xprvnom = xprvnom + txtapemat.Text.Trim() + " ";
            }
            if (txtnombres.Text.Trim().Length > 0)
            {
                xprvnom = xprvnom + txtnombres.Text.Trim() + " ";
            }
            txtNombrelargo.Text = xprvnom;
        }

        private void btnfiltro_Click(object sender, EventArgs e)
        {
            CargaDatos();
        }

        private void examinaranexos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            }
            if (e.KeyCode == Keys.F1 & u_n_opsel > 0)
            {
                if ((examinaranexos.CurrentCell != null))
                {
                    if (examinaranexos.CurrentCell.ReadOnly == false)
                    {
                        if (examinaranexos.Columns[examinaranexos.CurrentCell.ColumnIndex].Name.ToUpper() == "cod_ubigeo".ToUpper())
                        {
                        }
                    }
                }
            }
        }
        private void examinaranexos_SelectionChanged(object sender, EventArgs e)
        {
            txtdescripcampo.Text = string.Empty;
            if (examinaranexos.CurrentCell != null)
            {
                if (examinaranexos.Columns[examinaranexos.CurrentCell.ColumnIndex].Name.ToUpper() == "cod_ubigeo".ToUpper())
                {
                    txtdescripcampo.Text = examinaranexos.Rows[examinaranexos.CurrentCell.RowIndex].Cells["dubigeo_10"].Value.ToString();
                }
            }
            PintadatosContrato();
            U_RefrescaControles();
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if ((Examinar.CurrentCell != null))
                {
                    SendKeys.Send("\t");
                    return true;
                }
                else
                {
                    if (TabControl1.SelectedIndex == 1)
                    {
                        if (!examinaranexos.IsCurrentCellInEditMode)
                        {
                            SendKeys.Send("\t");
                            return true;
                        }
                    }
                    else
                    {
                        SendKeys.Send("\t");
                        return true;
                    }
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public void u_PintaDatos()
        {
            var xcodcliente = string.Empty;
            if (!Sw_LOad)
            {
                if (u_n_opsel != 1)
                {
                    if (Examinar.CurrentRow == null)
                    {
                        xcodcliente = "...";
                        txtcodigo.Text = "..";
                    }
                    else
                    {
                        xcodcliente = Examinar.Rows[Examinar.CurrentRow.Index].Cells["fichaid"].Value.ToString();
                        txtcodigo.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["fichaid"].Value.ToString();
                    }
                    if (TabControl1.SelectedIndex == 1)
                    {
                        if (Examinar.CurrentRow != null)
                        {
                            txtNombrelargo.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["nombrelargo"].Value.ToString();
                            txtapepat.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["apepat"].Value.ToString();
                            txtapemat.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["apemat"].Value.ToString();
                            txtnombres.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["nombres"].Value.ToString();
                            cboTipdoc.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipdocid"].Value;
                            txtDni.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["nrodni"].Value.ToString();
                            cboVia.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["viaid"].Value;
                            cboZona.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["zonaid"].Value;
                            txtdireccion.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["direcc"].Value.ToString();

                            txtpaisid.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["paisid"].Value.ToString();
                            ValidaPais();
                            if (Examinar.Rows[Examinar.CurrentRow.Index].Cells["paisid"].Value.ToString() == "9589")
                            {
                                cboDepar.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["ubiged"].Value.ToString().Substring(0, 2);
                                cboProvi.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["ubiged"].Value.ToString().Substring(0, 4);
                                cboDistr.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["ubiged"].Value.ToString();

                                cboDeparN.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["ubigen"].Value.ToString().Substring(0, 2);
                                cboProviN.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["ubigen"].Value.ToString().Substring(0, 4);
                                cboDistrN.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["ubigen"].Value.ToString();
                            }
                            cmbestadocivil.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["estadocivil"].Value.ToString();
                            rbmasculino.Checked = Examinar.Rows[Examinar.CurrentRow.Index].Cells["sexo"].Value.ToString() == "M";
                            rbfemenino.Checked = Examinar.Rows[Examinar.CurrentRow.Index].Cells["sexo"].Value.ToString() == "F";
                            txttelefono.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["telef1"].Value.ToString();
                            txtfax.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["telef2"].Value.ToString();
                            txtcarnetseguro.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["carnetsegsoc"].Value.ToString();
                            if (!object.ReferenceEquals(Examinar.Rows[Examinar.CurrentRow.Index].Cells["fechnacimiento"].Value, DBNull.Value))
                            {
                                fnacimiento.Value = Convert.ToDateTime(Examinar.Rows[Examinar.CurrentRow.Index].Cells["fechnacimiento"].Value);
                            }
                            if (!object.ReferenceEquals(Examinar.Rows[Examinar.CurrentRow.Index].Cells["fechingreso"].Value, DBNull.Value))
                            {
                                fIngreso.Checked = true;
                                fIngreso.Value = Convert.ToDateTime(Examinar.Rows[Examinar.CurrentRow.Index].Cells["fechingreso"].Value);
                            }
                            else
                            {
                                fIngreso.Checked = false;
                            }

                            cbo_empresaid.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["empresaid"].Value;

                            cmbestadotrab.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["situtrabid"].Value;
                            chksctr.Checked = Convert.ToBoolean(Examinar.Rows[Examinar.CurrentRow.Index].Cells["sctr"].Value);
                            chkremintegral.Checked = Convert.ToBoolean(Examinar.Rows[Examinar.CurrentRow.Index].Cells["remintegral"].Value);
                            chkautocontrol.Checked = Convert.ToBoolean(Examinar.Rows[Examinar.CurrentRow.Index].Cells["autocontrol"].Value);
                            chkdephaberes.Checked = Convert.ToBoolean(Examinar.Rows[Examinar.CurrentRow.Index].Cells["chkdephab"].Value);
                            cmbdephaberes.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["bancoidhab"].Value.ToString();
                            txtctahaberes.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["ctahaberes"].Value.ToString();
                            chkdepcts.Checked = Convert.ToBoolean(Examinar.Rows[Examinar.CurrentRow.Index].Cells["chkdepcts1"].Value);
                            cmbdepcts.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["bancoidcts"].Value;
                            txtctacts.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["ctacts"].Value.ToString();
                            cmbtipo.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipodeta"].Value;
                            txtccosto.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["cencosid"].Value.ToString();
                            txtdcosto.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["cencosname"].Value.ToString();
                            txtccargo.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["cargoid"].Value.ToString();
                            txtdcargo.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["cargoname"].Value.ToString();
                            txtdetallecontable.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["detallecontable"].Value.ToString();
                            cmbafp.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["regipenid"].Value.ToString();
                            txtctaafp.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["cuspp"].Value.ToString();
                            if (!object.ReferenceEquals(Examinar.Rows[Examinar.CurrentRow.Index].Cells["fechafiliacion"].Value, DBNull.Value))
                            {
                                fafiliacion.Checked = true;
                                fafiliacion.Value = Convert.ToDateTime(Examinar.Rows[Examinar.CurrentRow.Index].Cells["fechafiliacion"].Value);
                            }
                            else
                            {
                                fafiliacion.Checked = false;
                            }
                            cboTComision.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipcomisionafp"].Value;
                            chkesalud.Checked = Convert.ToBoolean(Examinar.Rows[Examinar.CurrentRow.Index].Cells["essaludvida"].Value);
                            txtemail.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["email"].Value.ToString();
                            cboNiveleducativo.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["niveleduid"].Value;
                            if (Convert.ToBoolean(Examinar.Rows[Examinar.CurrentRow.Index].Cells["discapacitado"].Value) == true)
                            {
                                rbsidiscapacitado.Checked = true;
                            }
                            else
                            {
                                rbnodiscapacitado.Checked = true;
                            }
                            cmbtipolocal.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["establec"].Value;
                            cmbcategoria.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["cateocupid"].Value;

                            cboEps.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["epsid"].Value;
                            cboSitutrab.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["situtrab"].Value;
                            cboTpago.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["tippagoid"].Value;
                            cboCtributario.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["convendobletribid"].Value;
                            if (Convert.ToBoolean(Examinar.Rows[Examinar.CurrentRow.Index].Cells["chkconvenio"].Value) == true)
                            {
                                rbsiConvenio.Checked = true;
                            }
                            else
                            {
                                rbnoConvenio.Checked = true;
                            }

                            txtobservaciones.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["observacion"].Value.ToString();
                            VM_mimagen_3 = Examinar.Rows[Examinar.CurrentRow.Index].Cells["dfotografia"].Value.ToString();
                            rbactivo.Checked = Examinar.Rows[Examinar.CurrentRow.Index].Cells["status"].Value.ToString() == "0";
                            rbanulado.Checked = Examinar.Rows[Examinar.CurrentRow.Index].Cells["status"].Value.ToString() == "9";
                        }
                        else
                        {
                            Blanquear();
                        }
                    }
                    u_CargaAnexos();
                }
                else
                {
                    txtcoddetalle.Text = txtcodigo.Text;
                    txtnomdetalle.Text = txtapepat.Text.Trim() + " " + txtapemat.Text.Trim() + " " + txtnombres.Text;
                }
                U_RefrescaControles();
            }
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

        private void txtfiltronombre_GotFocus(object sender, System.EventArgs e)
        {
            j_xFiltronom = txtfiltronombre.Text;
        }
        private void txtfiltronombre_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_xFiltronom == txtfiltronombre.Text))
            {
                CargaDatos();
            }
        }
        private void txtfiltrocodigo_GotFocus(object sender, System.EventArgs e)
        {
            j_xfiltrocod = txtfiltrocodigo.Text;
        }
        private void txtfiltrocodigo_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_xfiltrocod == txtfiltrocodigo.Text))
            {
                CargaDatos();
            }
        }
        private void txtfiltronumdoc_GotFocus(object sender, System.EventArgs e)
        {
            j_xfiltronumdoc = txtfiltronumdoc.Text;
        }
        private void txtfiltronumdoc_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_xfiltronumdoc == txtfiltronumdoc.Text))
            {
                CargaDatos();
            }
        }

        public void u_CargaAnexos()
        {
            var xcodcliente = txtcodigo.Text;
            var BL = new tb_plla_fichatrabajadorescontratosBL();
            var BE = new tb_plla_fichatrabajadorescontratos();
            BE.fichaid = (xcodcliente.Length == 0 ? ".." : xcodcliente);
            TablaContratos = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
            var BLRC = new tb_plla_fichatrabajadoresrubrosBL();
            var BERC = new tb_plla_fichatrabajadoresrubros();
            BERC.fichaid = (xcodcliente.Length == 0 ? ".." : xcodcliente);
            TablaRubrosContrato = BLRC.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BERC).Tables[0];
            if (BLRC.Sql_Error.Length > 0)
            {
                Frm_Class.ShowError(BLRC.Sql_Error, this);
            }

            if (BL.Sql_Error.Length > 0)
            {
                Frm_Class.ShowError(BL.Sql_Error, this);
            }

            examinaranexos.AutoGenerateColumns = false;
            examinaranexos.DataSource = TablaContratos;

            examinarrubros.AutoGenerateColumns = false;
            examinarrubros.DataSource = TablaRubrosContrato;
            txtcoddetalle.Text = string.Empty;
            txtnomdetalle.Text = string.Empty;
            if (u_n_opsel == 0)
            {
                if ((Examinar.CurrentRow != null))
                {
                    txtcoddetalle.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["fichaid"].Value.ToString();
                    txtnomdetalle.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["nombrelargo"].Value.ToString();
                }
            }
            else
            {
                txtcoddetalle.Text = txtcodigo.Text;
                txtnomdetalle.Text = txtapepat.Text.Trim() + " " + txtapemat.Text.Trim() + " " + txtnombres.Text;
            }
            PintadatosContrato();
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
        private void txtcodigo_LostFocus(object sender, System.EventArgs e)
        {
            if (u_n_opsel > 0)
            {
                if (txtcodigo.Text.Trim().Length > 0)
                {
                    txtcodigo.Text = VariablesPublicas.PADL(txtcodigo.Text.Trim(), 7, "0");
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
                    if (Examinar.Rows[lc_cont].Cells["activo"].Value.ToString() == "0")
                    {
                        for (LC_NCOLUMNA = 0; LC_NCOLUMNA <= Examinar.ColumnCount - 1; LC_NCOLUMNA++)
                        {
                            Examinar.Rows[lc_cont].DefaultCellStyle.BackColor = lblanulado.BackColor;
                            Examinar.Rows[lc_cont].DefaultCellStyle.ForeColor = Color.White;
                        }
                    }
                    else
                    {
                        for (LC_NCOLUMNA = 0; LC_NCOLUMNA <= Examinar.ColumnCount - 1; LC_NCOLUMNA++)
                        {
                            Examinar.Rows[lc_cont].DefaultCellStyle.BackColor = Color.White;
                            Examinar.Rows[lc_cont].DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                }
            }
        }

        private void Examinar_Paint(object sender, PaintEventArgs e)
        {
            U_pINTAR();
        }

        private void rbnoConvenio_CheckedChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0 & !sw_EmpiezaEdicion)
            {
                U_RefrescaControles();
                if (rbnoConvenio.Checked)
                {
                    cboCtributario.SelectedValue = "0";
                }
            }
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
            var oform = new Frm_AyudaCargosPlla();
            oform._ccosto = txtccosto.Text.Trim();
            oform._PasaDelegado = RecibeCARGO;
            oform.Owner = this;
            oform.ShowDialog();
        }

        public void RecibeCARGO(string Codigo, string nombre, string codcosto, string nomcosto)
        {
            txtccargo.Text = Codigo;
            txtdcargo.Text = nombre;
            txtccosto.Text = codcosto;
            txtdcosto.Text = nomcosto;
        }

        private void btnaddrubro_Click(object sender, EventArgs e)
        {
            if (examinaranexos.CurrentRow != null)
            {
                var xvmcodigo = examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["ncontrato"].Value.ToString();
                TablaRubrosContrato.Rows.Add(VariablesPublicas.InsertIntoTable(TablaRubrosContrato));
                TablaRubrosContrato.Rows[TablaRubrosContrato.Rows.Count - 1]["ncontrato"] = xvmcodigo;
                TablaRubrosContrato.Rows[TablaRubrosContrato.Rows.Count - 1]["consimporte"] = 1;
                examinarrubros.Refresh();
                examinarrubros.CurrentCell = examinarrubros.Rows[examinarrubros.Rows.Count - 1].Cells["rubroid"];
                examinarrubros.BeginEdit(true);
                TablaRubrosContrato.AcceptChanges();
                U_RefrescaControles();
                VariablesPublicas.SetKey(examinarrubros, "ncontrator", examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["ncontrato"].Value, "rubroid");
            }
            else
            {
                MessageBox.Show("Seleccione contrato ", "Mensaje del Sistema");
                examinaranexos.Focus();
            }
        }

        private void btndelrubro_Click(object sender, EventArgs e)
        {
            if ((examinarrubros.CurrentRow != null))
            {
                if (examinarrubros.Rows.Count > 0)
                {
                    examinarrubros.Rows.Remove(examinarrubros.CurrentRow);
                    TablaRubrosContrato.AcceptChanges();
                    examinarrubros.Refresh();
                    VariablesPublicas.SetKey(examinarrubros, "ncontrator", examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["ncontrato"].Value, "rubroid");
                    U_RefrescaControles();
                }
            }
            else
            {
                MessageBox.Show("Seleccione Rubro", "Mensaje del Sistema");
                examinarrubros.Focus();
            }
        }

        private void examinarrubros_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (examinarrubros.Columns[examinarrubros.CurrentCell.ColumnIndex].Name.ToUpper() == "rubroid".ToUpper())
            {
                j_rubro = examinarrubros.Rows[examinarrubros.CurrentRow.Index].Cells["rubroid"].Value.ToString();
            }
            if (examinarrubros.Columns[examinarrubros.CurrentCell.ColumnIndex].Name.ToUpper() == "importediario".ToUpper())
            {
                j_nvalor = Convert.ToDecimal(examinarrubros.CurrentCell.Value);
            }
        }
        private void examinarrubros_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            _NameColumn = string.Empty;
            if (examinarrubros.Columns[examinarrubros.CurrentCell.ColumnIndex].Name.ToUpper() == "rubroid".ToUpper())
            {
                txtCArti = (TextBox)e.Control;
                txtCArti.MaxLength = 4;
                txtCArti.CharacterCasing = CharacterCasing.Upper;
                txtCArti.Text.Trim();
                e.Control.KeyDown += VariablesPublicas.CapturarTeclaGRID;
                _NameColumn = examinarrubros.Columns[examinarrubros.CurrentCell.ColumnIndex].Name.ToUpper();
            }
        }
        private void examinarrubros_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (_NameColumn.Length > 0)
            {
                if (VariablesPublicas.PulsaAyudaArticulos)
                {
                    switch (_NameColumn)
                    {
                        case "rubroid":
                            txtCArti = null;
                            AyudaRubroPlanilla();
                            break;
                    }
                }
                VariablesPublicas.PulsaAyudaArticulos = false;
                _NameColumn = string.Empty;
            }
        }
        private void examinarrubros_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!Sw_LOad)
            {
                if ((examinarrubros.CurrentRow != null))
                {
                    sw_novaluechange = true;
                    if (examinarrubros.Columns[e.ColumnIndex].Name.ToUpper() == "rubroid".ToUpper())
                    {
                        ValidaRubroIngreso();
                    }
                    if (examinarrubros.Columns[e.ColumnIndex].Name.ToUpper() == "importediario".ToUpper())
                    {
                        if (object.ReferenceEquals(examinarrubros.Rows[examinarrubros.CurrentRow.Index].Cells["importediario"].Value, DBNull.Value))
                        {
                            examinarrubros.Rows[examinarrubros.CurrentRow.Index].Cells["importediario"].Value = 0;
                        }
                        var xvmformapago = string.Empty;
                        if ((cboTipoplanilla.SelectedValue != null))
                        {
                            var BL = new tb_plla_tipoplanillaBL();
                            var BE = new tb_plla_tipoplanilla();
                            BE.Tipoplla = cboTipoplanilla.SelectedValue.ToString();
                            BE.norden = 1;
                            BE.ver_blanco = 0;
                            BE.solopdt = 0;
                            tmptabla = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
                            if (BL.Sql_Error.Length == 0)
                            {
                                if (tmptabla.Rows.Count > 0)
                                {
                                    xvmformapago = tmptabla.Rows[0]["formapago"].ToString();
                                }
                            }
                        }
                        examinarrubros.Rows[examinarrubros.CurrentRow.Index].Cells["importediario"].Value = examinarrubros.Rows[examinarrubros.CurrentRow.Index].Cells["importediario"].Value;
                        if (xvmformapago == "3")
                        {
                            examinarrubros.Rows[examinarrubros.CurrentRow.Index].Cells["importemensual"].Value = Math.Round(Convert.ToDecimal(examinarrubros.Rows[examinarrubros.CurrentRow.Index].Cells["importediario"].Value) * 30, 2);
                        }
                        else
                        {
                            examinarrubros.Rows[examinarrubros.CurrentRow.Index].Cells["importemensual"].Value = examinarrubros.Rows[examinarrubros.CurrentRow.Index].Cells["importediario"].Value;
                        }
                        u_SumatoriaImporte();
                    }
                    if (examinarrubros.Columns[e.ColumnIndex].Name.ToUpper() == "consimporte".ToUpper())
                    {
                        if (object.ReferenceEquals(examinarrubros.CurrentCell.Value, DBNull.Value))
                        {
                            examinarrubros.CurrentCell.Value = 0;
                        }
                        u_SumatoriaImporte();
                    }
                    sw_novaluechange = false;
                }
            }
        }
        private void examinarrubros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            }
            if (e.KeyCode == Keys.F1 & u_n_opsel > 0)
            {
                if ((examinarrubros.CurrentCell != null))
                {
                    if (examinarrubros.CurrentCell.ReadOnly == false)
                    {
                        if (examinarrubros.Columns[examinarrubros.CurrentCell.ColumnIndex].Name.ToUpper() == "rubroid".ToUpper())
                        {
                            AyudaRubroPlanilla();
                        }
                    }
                }
            }
        }

        public void AyudaRubroPlanilla()
        {
            var xcodplanilla = "..:";
            if ((!object.ReferenceEquals(examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["tipoplla"].Value, DBNull.Value)))
            {
                xcodplanilla = examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["tipoplla"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione Tipo de Planilla", "Mensaje del Sistema");
                cboTipoplanilla.Focus();
                return;
            }
            var oform = new Frm_AyudaRubroIngresoPlla();
            oform._Planilla = xcodplanilla;
            oform._PasaDelegado = RecibeRubroIngresoPlanilla;
            oform.Owner = this;
            oform.ShowDialog();
        }
        public void RecibeRubroIngresoPlanilla(string Codigo, string nombre, string codcosto, string nomcosto, string ccia)
        {
            if (Codigo.Trim().Length > 0)
            {
                examinarrubros.Rows[examinarrubros.CurrentRow.Index].Cells["rubroid"].Value = Codigo;
            }
        }
        public void ValidaRubroIngreso()
        {
            var zhallado = false;
            var xcodartic = string.Empty;
            xcodartic = examinarrubros.Rows[examinarrubros.CurrentRow.Index].Cells["rubroid"].Value.ToString();
            var xcodplanilla = "...";
            if (object.ReferenceEquals(examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["tipoplla"].Value, DBNull.Value))
            {
            }
            else
            {
                xcodplanilla = examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["tipoplla"].Value.ToString();
            }

            if (xcodartic.Trim().Length == 0)
            {
                examinarrubros.Rows[examinarrubros.CurrentRow.Index].Cells["rubroid"].Value = string.Empty;
                examinarrubros.Rows[examinarrubros.CurrentRow.Index].Cells["rubroname"].Value = string.Empty;
                zhallado = true;
            }
            else
            {
                var BL = new tb_plla_rubrosingresoBL();
                var BE = new tb_plla_rubrosingreso();
                BE.tipoplla = xcodplanilla;
                BE.rubroid = xcodartic;
                tmptabla = BL.GetAll_CONSULTA_PLLA(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (BL.Sql_Error.Length == 0)
                {
                    if (tmptabla.Rows.Count > 0)
                    {
                        zhallado = true;
                        examinarrubros.Rows[examinarrubros.CurrentRow.Index].Cells["rubroid"].Value = tmptabla.Rows[0]["rubroid"].ToString().Trim();
                        examinarrubros.Rows[examinarrubros.CurrentRow.Index].Cells["rubroname"].Value = tmptabla.Rows[0]["rubroname"].ToString().Trim();
                    }
                }
            }
            if (!zhallado)
            {
                examinarrubros.Rows[examinarrubros.CurrentRow.Index].Cells["rubroid"].Value = j_rubro;
            }
            examinarrubros.Refresh();
        }
        public void PintadatosContrato()
        {
            if (examinaranexos.CurrentRow == null)
            {
                blanquearDatosContrato();
                VariablesPublicas.SetKey(examinarrubros, "ncontrator", "jwele", "rubroid");
            }
            else
            {
                VariablesPublicas.SetKey(examinarrubros, "ncontrator", examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["ncontrato"].Value, "rubroid");
                cmbestado.SelectedValue = examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["estado"].Value;

                cboTipoplanilla.SelectedValue = examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["tipoplla"].Value;
                cmbmodalidad.SelectedValue = examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["tipcontratoid"].Value;
                lblestructcerrado.Visible = Convert.ToBoolean(examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["cierreremune"].Value);
                txtimporte.Text = String.Format(examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["remuneracion"].Value.ToString(), "###,###.00").ToString();
                if (!object.ReferenceEquals(examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["dcfechaini"].Value, DBNull.Value))
                {
                    finiciocontrato.Value = Convert.ToDateTime(examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["dcfechaini"].Value);
                    finiciocontrato.Checked = true;
                }
                else
                {
                    finiciocontrato.Checked = false;
                }

                if (!object.ReferenceEquals(examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["dcfechafin"].Value, DBNull.Value))
                {
                    ffinalcontrato.Value = Convert.ToDateTime(examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["dcfechafin"].Value);
                    ffinalcontrato.Checked = true;
                }
                else
                {
                    ffinalcontrato.Checked = false;
                }
                if (!object.ReferenceEquals(examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["vlfechaini"].Value, DBNull.Value))
                {
                    finicioviglab.Value = Convert.ToDateTime(examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["vlfechaini"].Value);
                    finicioviglab.Checked = true;
                }
                else
                {
                    finicioviglab.Checked = false;
                }

                if ((!object.ReferenceEquals(examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["vlfechafin"].Value, DBNull.Value)))
                {
                    ffinalviglab.Value = Convert.ToDateTime(examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["vlfechafin"].Value);
                    ffinalviglab.Checked = true;
                }
                else
                {
                    ffinalviglab.Checked = false;
                }
                horinicio.Value = Convert.ToDecimal(examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["horarioentrada"].Value);
                horfinal.Value = Convert.ToDecimal(examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["horariosalida"].Value);
                MinInicio.Value = Convert.ToDecimal(examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["minutosentrada"].Value);
                minfinal.Value = Convert.ToDecimal(examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["minutossalida"].Value);
                //tcontrato.SelectedIndex = Convert.ToInt32(examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["tparcial"].Value);
            }
        }
        public void blanquearDatosContrato()
        {
            cmbestado.SelectedValue = string.Empty;
            cboTipoplanilla.SelectedValue = string.Empty;
            cmbmodalidad.SelectedValue = string.Empty;
            lblestructcerrado.Visible = false;
            txtimporte.Text = string.Empty;
            horinicio.Value = 0;
            MinInicio.Value = 0;
            horfinal.Value = 0;
            minfinal.Value = 0;
        }

        private void txtimporte_GotFocus(object sender, System.EventArgs e)
        {
            j_dimporte = txtimporte.Text;
        }
        private void txtimporte_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_dimporte == txtimporte.Text) & u_n_opsel > 0)
            {
                var NVAR = VariablesPublicas.StringtoDecimal(txtimporte.Text);
                if (NVAR == 0)
                {
                    txtimporte.Text = string.Empty;
                    examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["remuneracion"].Value = 0;
                }
                else
                {
                    txtimporte.Text = NVAR.ToString("###,###.00");
                    examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["remuneracion"].Value = VariablesPublicas.StringtoDecimal(txtimporte.Text);
                }
            }
        }

        private void finicioviglab_ValueChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0 & (examinaranexos.CurrentRow != null))
            {
                if (finicioviglab.Checked)
                {
                    examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["vlfechaini"].Value = Equivalencias.Mid(finicioviglab.Value.ToString(), 1, 10);
                }
                else
                {
                    examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["vlfechaini"].Value = DBNull.Value;
                }
            }
        }
        private void ffinalviglab_ValueChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0 & (examinaranexos.CurrentRow != null))
            {
                if (ffinalviglab.Checked)
                {
                    examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["vlfechafin"].Value = Equivalencias.Mid(ffinalviglab.Value.ToString(), 1, 10);
                }
                else
                {
                    examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["vlfechafin"].Value = DBNull.Value;
                }
            }
        }

        private void finiciocontrato_ValueChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0 & (examinaranexos.CurrentRow != null))
            {
                if (finiciocontrato.Checked)
                {
                    examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["dcfechaini"].Value = Equivalencias.Mid(finiciocontrato.Value.ToString(), 1, 10);
                }
                else
                {
                    examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["dcfechaini"].Value = DBNull.Value;
                }
            }
        }
        private void ffinalcontrato_ValueChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0 & (examinaranexos.CurrentRow != null))
            {
                if (ffinalcontrato.Checked)
                {
                    examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["dcfechafin"].Value = Equivalencias.Mid(ffinalcontrato.Value.ToString(), 1, 10);
                }
                else
                {
                    examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["dcfechafin"].Value = DBNull.Value;
                }
            }
        }

        private void horinicio_ValueChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0 & (examinaranexos.CurrentRow != null))
            {
                examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["horarioentrada"].Value = horinicio.Value;
            }
        }
        private void horfinal_ValueChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0 & (examinaranexos.CurrentRow != null))
            {
                examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["horariosalida"].Value = horfinal.Value;
            }
        }

        private void MinInicio_ValueChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0 & (examinaranexos.CurrentRow != null))
            {
                examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["minutosentrada"].Value = MinInicio.Value;
            }
        }
        private void minfinal_ValueChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0 & (examinaranexos.CurrentRow != null))
            {
                examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["minutossalida"].Value = minfinal.Value;
            }
        }

        private void cmbmodalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0 & (examinaranexos.CurrentRow != null))
            {
                examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["tipcontratoid"].Value = cmbmodalidad.SelectedValue;
                examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["tipcontratoname"].Value = cmbmodalidad.Text;
            }
        }

        private void cmbestado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0 & (examinaranexos.CurrentRow != null))
            {
                if (cmbestado.SelectedValue != null)
                {
                    examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["estado"].Value = cmbestado.SelectedValue;
                    examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["estadoname"].Value = cmbestado.Text;
                }
            }
        }

        private void cmbtipoplanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0 & (examinaranexos.CurrentRow != null))
            {
                examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["tipoplla"].Value = cboTipoplanilla.SelectedValue;
                examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["tipopllaname"].Value = cboTipoplanilla.Text;
                TablaRubrosContrato.AcceptChanges();

                var nfila = 0;
                DataTable tmptabla = null;
                var xformpago = string.Empty;
                var vmnrocontrato = string.Empty;
                if (examinaranexos.CurrentRow != null)
                {
                    if (!object.ReferenceEquals(examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["ncontrato"], DBNull.Value))
                    {
                        vmnrocontrato = examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["ncontrato"].Value.ToString();
                    }
                }
                var BL = new tb_plla_tipoplanillaBL();
                var BE = new tb_plla_tipoplanilla();
                if (cboTipoplanilla.SelectedValue != null)
                {
                    BE.Tipoplla = cboTipoplanilla.SelectedValue.ToString();
                }
                BE.norden = 1;
                BE.ver_blanco = 0;
                BE.solopdt = 0;
                tmptabla = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (BL.Sql_Error.Length == 0)
                {
                    if (tmptabla.Rows.Count > 0)
                    {
                        xformpago = tmptabla.Rows[0]["formapago"].ToString();
                    }
                }
                if (xformpago.Trim().Length > 0)
                {
                    for (nfila = 0; nfila <= TablaRubrosContrato.Rows.Count - 1; nfila++)
                    {
                        if (TablaRubrosContrato.Rows[nfila]["ncontrato"].ToString() == vmnrocontrato)
                        {
                            TablaRubrosContrato.Rows[nfila]["formapago"] = xformpago;
                        }
                    }
                }
                TablaRubrosContrato.AcceptChanges();
                VariablesPublicas.SetKey(examinarrubros, "ncontrator", examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["ncontrato"].Value, "rubroid");
            }
        }

        private void chkdephaberes_CheckedChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0 & !sw_EmpiezaEdicion)
            {
                txtctahaberes.Text = string.Empty;
                cmbdephaberes.SelectedValue = string.Empty;
                if (chkdephaberes.Checked == true)
                {
                    cboTpago.SelectedValue = "2";
                }
                else
                {
                    cboTpago.SelectedValue = "1";
                }
                U_RefrescaControles();
            }
        }

        private void chkdepcts_CheckedChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0 & !sw_EmpiezaEdicion)
            {
                txtctacts.Text = string.Empty;
                cmbdepcts.SelectedValue = string.Empty;
                U_RefrescaControles();
            }
        }

        private void btnfoto_Click(object sender, EventArgs e)
        {
            var oform = new AYUDA.Frm_VerImagen();
            dynamic XFILE = VM_mimagen_3;
            dynamic XCARPETA = string.Empty;
            if (XFILE.Length > 0)
            {
                try
                {
                    XCARPETA = VariablesPublicas.Addbs(System.IO.Path.GetDirectoryName(XFILE));
                    oform._NombreArchivo = System.IO.Path.GetFileName(XFILE);
                    if (u_n_opsel == 0)
                    {
                        XCARPETA = VariablesPublicas.RutaImagenes;
                    }
                }
                catch (Exception ex)
                {
                    XCARPETA = string.Empty;
                    oform._NombreArchivo = string.Empty;
                }
            }
            oform._DirectorioImagen = XCARPETA;
            oform._Titulo = "Fotografía";
            oform.Owner = this;
            oform.u_n_Opsel = u_n_opsel;
            oform._RetornaImagenXXX = RecibeRutaNameImagen;
            oform.ShowDialog();
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

        private void cmbfiltrotipoplanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad & cmbfiltrotipoplanilla.Enabled)
            {
                CargaDatos();
            }
        }

        private void chkvercesados_CheckedChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad)
            {
                CargaDatos();
            }
        }

        private void cmbniveleducativo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNiveleducativo.SelectedValue != null)
            {
                ToolTip1.SetToolTip(cboNiveleducativo, cboNiveleducativo.Text);
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

        private void examinarrubros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (examinarrubros.Columns[e.ColumnIndex].Name.ToUpper() == "consimporte".ToUpper())
            {
                if (object.ReferenceEquals(examinarrubros.CurrentCell.Value, DBNull.Value))
                {
                    examinarrubros.CurrentCell.Value = 0;
                }
                u_SumatoriaImporte();
            }
        }

        private void txtdetallecontable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                ayudadetallecontable();
            }
        }
        public void ayudadetallecontable()
        {
        }
        private void RecibeProveedor(string codigo, string nombre, string direccion)
        {
            if (codigo.Trim().Length > 0)
            {
                txtdetallecontable.Text = codigo;
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

        public void u_SumatoriaImporte()
        {
            var vmcontrato = string.Empty;
            var ncontfila = 0;
            decimal vmimportetotal = 0;
            if (examinaranexos.CurrentRow != null)
            {
                vmcontrato = examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["ncontrato"].Value.ToString();
            }
            if (vmcontrato.Trim().Length > 0)
            {
                for (ncontfila = 0; ncontfila <= TablaRubrosContrato.Rows.Count - 1; ncontfila++)
                {
                    if (!(TablaRubrosContrato.Rows[ncontfila].RowState == DataRowState.Deleted))
                    {
                        if (TablaRubrosContrato.Rows[ncontfila]["ncontrato"].ToString() == vmcontrato.ToString())
                        {
                            if (object.ReferenceEquals(TablaRubrosContrato.Rows[ncontfila]["consimporte"], DBNull.Value))
                            {
                                TablaRubrosContrato.Rows[ncontfila]["consimporte"] = 0;
                            }
                            if (Convert.ToBoolean(TablaRubrosContrato.Rows[ncontfila]["consimporte"]) == true)
                            {
                                vmimportetotal = vmimportetotal + Convert.ToDecimal(TablaRubrosContrato.Rows[ncontfila]["importemensual"]);
                            }
                        }
                    }
                }
                if (vmimportetotal > 0)
                {
                    txtimporte.Text = String.Format(Convert.ToDecimal(Math.Round(vmimportetotal, 2)).ToString(), "###,###.00");
                    examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["remuneracion"].Value = Math.Round(vmimportetotal, 2);
                }
                else
                {
                    txtimporte.Text = string.Empty;
                    examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["remuneracion"].Value = 0;
                }
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
        private void cmbfiltrotipolocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad & cmbfiltroestado.Enabled)
            {
                CargaDatos();
            }
        }

        private void cmbafp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0 & !sw_EmpiezaEdicion)
            {
                U_RefrescaControles();
                if (cmbafp.SelectedValue != null)
                {
                    if (Equivalencias.Left(cmbafp.SelectedValue.ToString(), 1) != "2")
                    {
                        fafiliacion.Checked = false;
                        cboTComision.SelectedValue = string.Empty;
                        txtctaafp.Text = string.Empty;
                    }
                    else
                    {
                        cboTComision.SelectedValue = "2";
                    }
                }
            }
        }

        private void cboDepar_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillResultProvi(cboProvi, cboDistr, cboDepar.SelectedValue.ToString());
        }
        private void cboProvi_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillResultDistr(cboDistr, cboProvi.SelectedValue.ToString());
        }

        private void cboDeparN_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillResultProviN(cboProviN, cboDistrN, cboDeparN.SelectedValue.ToString());
        }
        private void cboProviN_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillResultDistrN(cboDistrN, cboProviN.SelectedValue.ToString());
        }

        private void btnPais_Click(object sender, EventArgs e)
        {
            var frmNew = new Ayudas.Frm_AyudaPais();
            frmNew.Owner = this;
            frmNew._PasaRegistro = RecibePais;
            frmNew.ShowDialog();
        }
        private void RecibePais(string codigo, string nombre)
        {
            if (codigo.Trim().Length > 0)
            {
                sw_novaluechange = true;
                txtpaisid.Text = codigo;
                txtpaisname.Text = nombre;
                sw_novaluechange = false;
            }
        }
        private void ValidaPais()
        {
            if (txtpaisid.Text.Trim().Length > 0)
            {
                var BL = new paisBL();
                var BE = new tb_pais();

                BE.paisid = txtpaisid.Text;
                var tmptablaPais = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                if (tmptablaPais.Rows.Count == 0)
                {
                    txtpaisid.Text = j_String;
                }
                else
                {
                    txtpaisid.Text = tmptablaPais.Rows[0]["paisid"].ToString();
                    txtpaisname.Text = tmptablaPais.Rows[0]["paisname"].ToString();
                }
            }
            else
            {
                txtpaisid.Text = j_String;
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
            txtdetallecontable.Text = xdet;
        }

        private void cboEps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0 & !sw_EmpiezaEdicion)
            {
                if (cboEps.SelectedValue != null)
                {
                    cboSitutrab.ValueMember = "situtrabid";
                    cboSitutrab.DisplayMember = "descripcion";
                    var BL = new tb_plla_pdt_tabla15BL();
                    var BE = new tb_plla_pdt_tabla15();
                    BE.afiliadoeps = (cboEps.SelectedValue.ToString().Trim().Length > 0 ? "1" : "2");
                    BE.norden = 1;
                    cboSitutrab.DataSource = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
                }
                else
                {
                    cboSitutrab.ValueMember = "situtrabid";
                    cboSitutrab.DisplayMember = "descripcion";
                    var BL = new tb_plla_pdt_tabla15BL();
                    var BE = new tb_plla_pdt_tabla15();
                    BE.afiliadoeps = "2";
                    BE.norden = 1;
                    cboSitutrab.DataSource = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
                }
            }
        }

        private void cbo_empresaid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_empresaid.SelectedIndex != -1)
            {
                var BL = new tb_plla_fichatrabajadoresBL();

                var Codigo = cbo_empresaid.SelectedValue.ToString();

                txtcodigo.Text = BL.GetAll_ConsultaMaxCod(VariablesPublicas.EmpresaID.ToString(), Codigo).Tables[0].Rows[0]["maximo_codigo"].ToString();
                u_CargaAnexos();
                cboTipdoc.SelectedValue = "01";
                cmbestadotrab.SelectedValue = "01";
                cmbtipolocal.SelectedValue = "0000";
                cboDepar.SelectedValue = "15";
                cboDeparN.SelectedValue = "15";
                txtpaisid.Text = "9589";
                ValidaPais();

                cmbtipo.SelectedValue = S_TipoDeta;
                rbnatural.Checked = true;
                txtcodigo.Focus();

                cmbestadocivil.SelectedValue = "S";
                cmbafp.SelectedValue = "02";
                cboNiveleducativo.SelectedValue = "13";
                cmbcategoria.SelectedValue = "3";
                cmbmodalidad.SelectedValue = "02";
                cboTipoplanilla.SelectedValue = "B";
                cmbestado.SelectedValue = "01";

                rbmasculino.Checked = true;
                rbnodiscapacitado.Checked = true;

                cboEps.SelectedValue = string.Empty;
                cboSitutrab.SelectedValue = string.Empty;
                cboEps_SelectedIndexChanged(sender, e);
                cboTpago.SelectedValue = string.Empty;
                cboCtributario.SelectedValue = "0";
                rbnoConvenio.Checked = true;

                if (fIngreso.Checked)
                {
                    fIngreso.Value = DateTime.Now;
                }
                j_Ruc = txtDni.Text;

                cbo_empresaid.Enabled = false;
                txtcodigo.Enabled = false;
            }
        }

        private void tcontrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0 & (examinaranexos.CurrentRow != null))
            {
                var tcont = tcontrato.SelectedIndex;
                examinaranexos.Rows[examinaranexos.CurrentRow.Index].Cells["tparcial"].Value = tcont;
            }
        }
    }
}
