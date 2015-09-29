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
using BapFormulariosNet.Ayudas;
using BapFormulariosNet.D20Comercial.Ayudas;

using BapFormulariosNet.Seguridadlog;

namespace BapFormulariosNet.D20Comercial
{
    public partial class Frm_RegistroVentas : PlantillaDC
    {
        DataTable CabFacturacion = new DataTable();
        DataTable DetFacturacion = new DataTable();

        // Variables Locales Para Obtener valor desde el Main
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "";
        private String modulo = "";
        private String local = "";
        private String PERFILID = "";


        int lc_contador = 0;
        string j_colORTALlA = "";
        string _NameCOlumna = "";
        bool sELECCIONAaYUDA = false;
        // Uso esto para que no se ejecuten eventos de interactive change cuando se cambia x codigo
        bool zinteractivechange = true;
        // el valor de un objeto // En Caso Reciba Parámetros
        string j_ValorFob = "";
        string J_PORCDET = "";
        string j_Pedido = "";
        string j_Destino = "";
        string j_TipoVenta = "";
        public string _Mes = "";
        public string _Registro = "";
        string j_widOP = "";
        string j_RUBRO = "";
        string j_Ccosto = "";
        string j_ctipdoc_3a = "";
        string j_cserdoc_3a = "";
        string j_cnumdoc_3a = "";
        bool sw_novaluechange = false;
        // controla si 1 ADICION 2 MODIFICACION
        private int u_n_opsel = 0;
        private string j_String = "";
        //private string j_porcflete = "";
        private bool sw_load = true;
        private string j_codtipdocu = "";
        private TextBox txtCArti = null;
        private string W_KEY0001 = "";
        DataTable pcgcopy = new DataTable();
        DataTable tmptablacab = new DataTable();
        DataTable tmptabladet = new DataTable();

        DataTable tmptabla = new DataTable();
        string _terminoventa = "";
        string _pais = "";
        string _embarque = "";
        string _condpago = "";
        string _cartacredito = "";
        string _codigovia = "";
        string _referencia = "";
        string xnum;

        //Variables de Identidad del Cliente
        private string xtipopersona = "";
        private string xtipodocidentidad = "";
        private string xctacte = "";
        private string xdirec = "";
        private string xubige = "";
        private string xmaqreg = "";
        private string xnumdocfinal = "";
        private string xestabsunat = "";

        public Frm_RegistroVentas()
        {
            InitializeComponent();

            txtMes.LostFocus += new System.EventHandler(txtMes_LostFocus);
            txtMes.GotFocus += new System.EventHandler(txtMes_GotFocus);
            txtAsiento.GotFocus += new System.EventHandler(txtAsiento_GotFocus);

            txtRuc.LostFocus += new System.EventHandler(txtRuc_LostFocus);
            txtRuc.GotFocus += new System.EventHandler(txtRuc_GotFocus);

            txtVenta.LostFocus += new System.EventHandler(txtVenta_LostFocus);
            txtVenta.GotFocus += new System.EventHandler(txtVenta_GotFocus);
            txtPigv.GotFocus += new System.EventHandler(txtPigv_GotFocus);
            txtPigv.LostFocus += new System.EventHandler(txtPigv_LostFocus);

            txtSerie.LostFocus += new System.EventHandler(txtSerie_LostFocus);
            txtNumero.LostFocus += new System.EventHandler(txtNumero_LostFocus);
            txtNumFin.LostFocus += new System.EventHandler(txtNumFin_LostFocus);

            txtSerieref.LostFocus += new System.EventHandler(txtSerieref_LostFocus);
            txtNumeroref.LostFocus += new System.EventHandler(txtNumeroref_LostFocus);

            txtTipoventa.LostFocus += new System.EventHandler(txtTipoventa_LostFocus);
            txtTipoventa.GotFocus += new System.EventHandler(txtTipoventa_GotFocus);

            cboDestinoigv.GotFocus += new System.EventHandler(cboDestinoigv_GotFocus);
            cboDestinoigv.LostFocus += new System.EventHandler(cboDestinoigv_LostFocus);

            aduValorfob.GotFocus += new System.EventHandler(aduValorfob_GotFocus);
            aduValorfob.LostFocus += new System.EventHandler(aduValorfob_LostFocus);
            aduCorrelativo.LostFocus += new System.EventHandler(aduCorrelativo_LostFocus);
            aduPeriodo.LostFocus += new System.EventHandler(aduPeriodo_LostFocus);

            txtPorcdet.GotFocus += new System.EventHandler(txtPorcdet_GotFocus);
            txtPorcdet.LostFocus += new System.EventHandler(txtPorcdet_LostFocus);

            llenar_cboSubdiario();
            txtMes.Text = DateTime.Now.Month.ToString().PadLeft(2, '0');

            tmptablacab = null;
            tmptabladet = null;
        }

        #region "Llenado de Combobox"
        void llenar_cboSubdiario()
        {
            try
            {
                cboSubdiario.DataSource = NewMethod();
                cboSubdiario.DisplayMember = "Value";
                cboSubdiario.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethod()
        {
            tb_co_tipodiarioBL BL = new tb_co_tipodiarioBL();
            tb_co_tipodiario BE = new tb_co_tipodiario();

            BE.perianio = VariablesPublicas.perianio;
            BE.registroventa = true;

            DataTable table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            DataRowCollection rows = table.Rows;

            object[] cell;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            BindingSource binding = new BindingSource();

            foreach (DataRow item in rows)
            {
                cell = item.ItemArray;
                dic.Add(cell[1].ToString(), cell[1].ToString() + " - " + cell[3].ToString());
                cell = null;
            }
            binding.DataSource = dic;
            return binding;
        }


        void llenar_cboTipdocs()
        {
            try
            {
                cboTipdoc.DataSource = NewMethodDoc();
                cboTipdoc.DisplayMember = "Value";
                cboTipdoc.ValueMember = "Key";

                cboTipdocref.DataSource = NewMethodDoc();
                cboTipdocref.DisplayMember = "Value";
                cboTipdocref.ValueMember = "Key";

            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethodDoc()
        {
            tb_co_tabla10_comprobantesBL BL = new tb_co_tabla10_comprobantesBL();
            tb_co_tabla10_comprobantes BE = new tb_co_tabla10_comprobantes();

            DataTable table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
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

        void llenar_cboAduana()
        {
            try
            {
                cboAduana.DataSource = NewMethodAduana();
                cboAduana.DisplayMember = "Value";
                cboAduana.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethodAduana()
        {
            tb_co_tabla11_aduanaBL BL = new tb_co_tabla11_aduanaBL();
            tb_co_tabla11_aduana BE = new tb_co_tabla11_aduana();

            DataTable table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
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

        void llenar_cboServicio()
        {
            try
            {
                cboServicio.DataSource = NewMethodServicio();
                cboServicio.DisplayMember = "Value";
                cboServicio.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethodServicio()
        {
            tb_co_detraccionBL BL = new tb_co_detraccionBL();
            tb_co_detraccion BE = new tb_co_detraccion();

            DataTable table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            DataRowCollection rows = table.Rows;

            object[] cell;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            BindingSource binding = new BindingSource();

            foreach (DataRow item in rows)
            {
                cell = item.ItemArray;
                dic.Add(cell[0].ToString(), cell[0].ToString() + " (" + cell[2].ToString() + "%) - " + cell[1].ToString());
                cell = null;
            }
            binding.DataSource = dic;
            return binding;
        }

        void llenar_cboTipoexportacion()
        {
            try
            {
                cboTipoexportacion.DataSource = NewMethodExport();
                cboTipoexportacion.DisplayMember = "Value";
                cboTipoexportacion.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethodExport()
        {
            tb_co_tipoexportacionBL BL = new tb_co_tipoexportacionBL();
            tb_co_tipoexportacion BE = new tb_co_tipoexportacion();

            DataTable table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
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

        void llenar_cboMoneda()
        {
            try
            {
                cboMoneda.DataSource = NewMethodMoneda();
                cboMoneda.DisplayMember = "Value";
                cboMoneda.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethodMoneda()
        {
            tb_co_tabla04_tipomonedaBL BL = new tb_co_tabla04_tipomonedaBL();
            tb_co_tabla04_tipomoneda BE = new tb_co_tabla04_tipomoneda();

            DataTable table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            DataRowCollection rows = table.Rows;

            object[] cell;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            BindingSource binding = new BindingSource();

            foreach (DataRow item in rows)
            {
                cell = item.ItemArray;
                dic.Add(cell[0].ToString(), cell[0].ToString() + " - " + cell[3].ToString());
                cell = null;
            }
            binding.DataSource = dic;
            return binding;
        }

        void llenar_cboDestinoigv()
        {
            try
            {
                cboDestinoigv.DataSource = NewMethodDestino();
                cboDestinoigv.DisplayMember = "Value";
                cboDestinoigv.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethodDestino()
        {
            tb_co_tributoafectoventasBL BL = new tb_co_tributoafectoventasBL();
            tb_co_tributoafectoventas BE = new tb_co_tributoafectoventas();

            DataTable table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
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
        #endregion

        private void Frm_RegistroVentas_Activated(object sender, EventArgs e)
        {
            if (sw_load)
            {
                // cboOrigen.SelectedIndex = -1;

                //-Tipo de Documentos
                llenar_cboTipdocs();
                //Detracciones
                llenar_cboServicio();
                //-Aduanas
                llenar_cboAduana();
                //Moneda
                llenar_cboMoneda();

                //Afecto al IGV
                llenar_cboDestinoigv();
                //Tipo de Exportacion
                llenar_cboTipoexportacion();

                fRegistro.Value = DateTime.Now;
                txtAsiento.Focus();
                UltimoNumeroRegistro();
                refrescacontroles();
                if (_Registro.Length > 0)
                {
                    txtMes.Text = _Mes;
                    txtAsiento.Text = _Registro;
                    sELECCIONAaYUDA = true;
                    CargaDatos();
                }
                sw_load = false;
            }
        }
        private void Frm_RegistroVentas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (btnEdit.Enabled)
                {
                    btnEdit_Click(sender, e);
                }
            }
            if (e.KeyCode == Keys.F8)
            {
                if (btnDelete.Enabled)
                {
                    btnDelete_Click(sender, e);
                }
            }
            if (e.Control & e.KeyCode == Keys.G)
            {
                if (btnSave.Enabled)
                {
                    Grabar(false);
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (btnRetro.Enabled)
                {
                    U_CancelarEdicion(1);
                }
                else
                {
                    btnExit_Click(sender, e);
                }
            }
            //if (e.KeyCode == Keys.F5)
            //{
            //    if (btnload.Enabled)
            //    {
            //        Accion(5, "", "");
            //    }
            //}
            if (e.KeyCode == Keys.F2 & btnNew.Enabled)
            {
                btnNew_Click(sender, e);
            }

            if (e.KeyCode == Keys.Insert & u_n_opsel > 0 & !GridExaminar.IsCurrentCellInEditMode)
            {
                btnAddfila_Click(sender, e);
            }
            if (e.Control & e.KeyCode == Keys.Delete & !GridExaminar.IsCurrentCellInEditMode & btnDelfila.Enabled)
            {
                btnDelfila_Click(sender, e);
            }
            if (e.Control & e.KeyCode == Keys.B)
            {
                AyudaRegVentas(0);
            }
            if (e.KeyCode == Keys.F6)
            {
                btnPrint_Click(sender, e);
            }
        }
        private void Frm_RegistroVentas_Load(object sender, EventArgs e)
        {
            if (Parent.Parent.Name == "MainComercial")
            {
                dominio = ((D20Comercial.MainComercial)MdiParent).dominioid;
                modulo = ((D20Comercial.MainComercial)MdiParent).moduloid;
                local = ((D20Comercial.MainComercial)MdiParent).local;
                PERFILID = ((D20Comercial.MainComercial)MdiParent).perfil;
            }

            
            PintaEncabezados(GridExaminar);
            // txtMes.Text = DateTime.Now.Month.ToString().PadLeft(2, '0');
            txtMes.Text = VariablesPublicas.PADL(DateTime.Now.Month.ToString(), 2, "0");
        }

        private void refrescacontroles()
        {
            btnInicial.Enabled = u_n_opsel == 0;
            btnAnterior.Enabled = u_n_opsel == 0;
            btnSiguiente.Enabled = u_n_opsel == 0;
            btnUltimo.Enabled = u_n_opsel == 0;

            cboSubdiario.Enabled = u_n_opsel == 0;
            chkDuplicar.Enabled = u_n_opsel > 0;
            string xcondedor = "";
            int contador = 0;
            string XCODDETRAC = "";
            if ((cboServicio.SelectedValue != null))
            {
                XCODDETRAC = cboServicio.SelectedValue.ToString().Trim();
            }

            //string xnroitem = "";
            if ((CabFacturacion != null))
            {
                if (CabFacturacion.Rows.Count > 0)
                {
                    xcondedor = CabFacturacion.Rows[0]["asiento"].ToString().Trim();
                }
            }
            GridExaminar.ReadOnly = u_n_opsel == 0;
            GridExaminar.Columns["drubro"].ReadOnly = true;
            GridExaminar.Columns["valorventa"].ReadOnly = u_n_opsel == 0;
            GridExaminar.Columns["unidmedidaid"].ReadOnly = true;
            GridExaminar.Columns["igvo"].ReadOnly = true;
            GridExaminar.Columns["total"].ReadOnly = true;
            GridExaminar.Columns["asientoitems"].ReadOnly = true;
            GridExaminar.Columns["afectoigvid"].ReadOnly = !((u_n_opsel > 0) & (Equivalencias.Left(cboDestinoigv.Text, 1) == "3"));
            int contador_D;
            if ((!(GridExaminar.CurrentRow == null) & (u_n_opsel > 0) & (Equivalencias.Left(cboDestinoigv.Text, 1) == "1")))
            {
                for (contador_D = 0; (contador_D <= (GridExaminar.Rows.Count - 1)); contador_D++)
                {
                    if (GridExaminar.Rows[contador_D].Cells["afectoigvid"].Value.ToString().Trim() == "2")
                    {
                        GridExaminar.Columns["afectoigvid"].ReadOnly = !((u_n_opsel > 0));
                    }
                }
            }

            GridExaminar.Columns["productid"].ReadOnly = true;
            if ((GridExaminar.CurrentRow != null))
            {
                if (GridExaminar.RowCount > 0)
                {
                    //Me.Examinar.Columns("linea_3a").ReadOnly = Not (Me.u_n_opsel > 0 And Me.Examinar.Rows(Me.Examinar.CurrentRow.Index).Cells("Lee_ITEM").Value = 1)
                }
            }
            //btnFacturaguia.Enabled = u_n_opsel == 1;
            fRegistro.Enabled = u_n_opsel > 0;
            btnSeekdoc.Enabled = u_n_opsel == 0;
            chkActivo.Enabled = u_n_opsel > 0;
            txtAsiento.Enabled = u_n_opsel == 0;
            btnAddfila.Enabled = u_n_opsel > 0;
            txtPigv.Enabled = false;
            // u_n_opsel > 0
            txtVenta.Enabled = u_n_opsel > 0;
            // chkAfecto.Enabled =  u_n_opsel > 0;
            chkAfecto.Enabled = false;
            btnExit.Enabled = u_n_opsel == 0;
            btnBusqueda.Enabled = u_n_opsel == 0;
            cboMoneda.Enabled = u_n_opsel > 0;

            cboOrigen.Enabled = u_n_opsel > 0;
            string xorigen = "";
            if (Equivalencias.Left(cboOrigen.Text, 2) == "02")
            {
                xorigen = cboOrigen.Text.Substring(0, 2);
            }
            cboAduana.Enabled = u_n_opsel > 0 & xorigen == "02";
            btnDatadic.Enabled = xorigen == "02";
            // aduPeriodo.Enabled =  u_n_opsel > 0 & xorigen == "02";
            aduPeriodo.Enabled = false;
            aduValorfob.Enabled = u_n_opsel > 0 & xorigen == "02";
            aduCorrelativo.Enabled = u_n_opsel > 0 & xorigen == "02";
            adufEmbarque.Enabled = u_n_opsel > 0 & xorigen == "02";
            adufRegularizacion.Enabled = u_n_opsel > 0 & xorigen == "02";
            cboTipoexportacion.Enabled = u_n_opsel > 0 & xorigen == "02";
            //if ((xorigen == "02"))
            //{
            //     cboDestinoigv.SelectedValue = "2";
            //}
            //else
            //{
            //     cboDestinoigv.SelectedValue = "1";               
            //}
            chkIncluye.Enabled = u_n_opsel > 0 & chkAfecto.Checked;
            cboDestinoigv.Enabled = u_n_opsel > 0;
            // btnLoad.Enabled =  u_n_opsel == 0;
            txtRuc.Enabled = u_n_opsel > 0;
            cboTipdoc.Enabled = u_n_opsel > 0;
            cboServicio.Enabled = u_n_opsel > 0;

            txtSerie.Enabled = u_n_opsel > 0;
            txtCtadetrac.Enabled = u_n_opsel > 0 & XCODDETRAC.Trim().Length > 0;
            txtGlosa.Enabled = u_n_opsel > 0;
            txtNumeroorden.Enabled = u_n_opsel > 0;
            // txtPorcdet.Enabled =  u_n_opsel > 0 & XCODDETRAC.Trim().Length > 0;
            txtPorcdet.Enabled = false;
            txtTipoventa.Enabled = u_n_opsel > 0;
            txtNumero.Enabled = u_n_opsel > 0;
            txtNumFin.Enabled = false;
            fecVenc.Enabled = u_n_opsel > 0;
            //fechaRefer.Enabled =  u_n_opsel > 0;
            btnProvfactura.Enabled = u_n_opsel > 0;
            txtMes.Enabled = u_n_opsel == 0;

            if ((DetFacturacion != null))
            {
                btnDelfila.Enabled = DetFacturacion.Rows.Count > 0 & u_n_opsel > 0;
            }
            else
            {
                btnDelfila.Enabled = false;
            }
            btnNew.Enabled = u_n_opsel == 0;
            if (CabFacturacion == null)
            {
                btnEdit.Enabled = false;
            }
            else
            {
                btnEdit.Enabled = u_n_opsel == 0 & CabFacturacion.Rows.Count > 0;
            }
            //btnRename.Enabled = btnEdit.Enabled;
            btnActtipocambio.Enabled = btnEdit.Enabled;
            if (CabFacturacion == null)
            {
                btnDelete.Enabled = false;
            }
            else
            {
                btnDelete.Enabled = u_n_opsel == 0 & CabFacturacion.Rows.Count > 0;
            }
            btnSave.Enabled = u_n_opsel > 0;
            btnRetro.Enabled = u_n_opsel > 0;
            btnPrint.Enabled = u_n_opsel == 0 & xcondedor.Trim().Length > 0;
            btnLog.Enabled = u_n_opsel == 0 & xcondedor.Trim().Length > 0;
            //btnCopy.Enabled = u_n_opsel == 1;

            chkRetencion.Enabled = u_n_opsel > 0;
            txtDescripcampo.Enabled = false;
            if ((GridExaminar.CurrentRow != null) & u_n_opsel > 0)
            {
                for (contador = 0; contador <= GridExaminar.Rows.Count - 1; contador++)
                {
                    GridExaminar.Rows[contador].Cells["productid"].ReadOnly = false;
                    GridExaminar.Rows[contador].Cells["productname"].ReadOnly = true;
                }
            }
            txtIgv.Enabled = u_n_opsel > 0;
            //string xcoddocumento = "..";
            //if ((cboTipdoc.SelectedValue != null))
            //{
            //    xcoddocumento =  cboTipdoc.SelectedValue.ToString();
            //}
            //And xcoddocumento = "007"
            Docref();
            // cboTipdocref.Enabled =  u_n_opsel > 0;
            // txtSerieref.Enabled =  cboTipdocref.Enabled;
            // txtNumeroref.Enabled =  cboTipdocref.Enabled;

            txtPigv.Enabled = u_n_opsel > 0;
        }
        void Docref()
        {
            if (u_n_opsel > 0)
            {
                tb_co_tabla10_comprobantesBL BL = new tb_co_tabla10_comprobantesBL();
                tb_co_tabla10_comprobantes BE = new tb_co_tabla10_comprobantes();
                try
                {
                    string xTipodoc = "";
                    if (Equivalencias.Left(cboTipdoc.Text, 2) == "07" | Equivalencias.Left(cboTipdoc.Text, 2) == "08" |
                        Equivalencias.Left(cboTipdoc.Text, 2) == "87" | Equivalencias.Left(cboTipdoc.Text, 2) == "88")
                    {
                        xTipodoc = cboTipdoc.SelectedValue.ToString();
                    }

                    BE.codigoid = xTipodoc;
                    DataTable table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                    if (Convert.ToBoolean(table.Rows[0]["docref"].ToString()) == true)
                    {
                        gpoReferencia.Enabled = (u_n_opsel) > 0;
                    }
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                gpoReferencia.Enabled = false;
            }

            if (u_n_opsel > 0)
            {
                if (Equivalencias.Left(cboTipdoc.Text, 2) == "03" | Equivalencias.Left(cboTipdoc.Text, 2) == "12") // |
                //Equivalencias.Left(cboTipdoc.Text, 2) == "87" | Equivalencias.Left(cboTipdoc.Text, 2) == "88")
                {
                    txtNumFin.Enabled = true;
                }
            }
        }
        private void blanquear(bool Inicializar)
        {
            xtipopersona = "";
            xtipodocidentidad = "";
            xctacte = "";
            xdirec = "";
            xubige = "";
            xmaqreg = "";
            xnumdocfinal = "";
            xestabsunat = "";

            txtRuc.Text = "";
            cboAduana.SelectedValue = "";
            aduPeriodo.Text = "";
            aduValorfob.Text = "";
            aduCorrelativo.Text = "";
            txtCtactename.Text = "";
            adufEmbarque.Value = DateTime.Now;
            adufRegularizacion.Value = DateTime.Now;
            adufEmbarque.ShowCheckBox = false;
            adufRegularizacion.ShowCheckBox = false;
            cboTipoexportacion.SelectedValue = "";
            fechaRefer.ShowCheckBox = false;

            txtSerie.Text = "";
            txtCtadetrac.Text = "";
            txtGlosa.Text = "";
            txtNumeroorden.Text = "";
            cboServicio.SelectedValue = "";

            _terminoventa = "";
            _pais = "";
            _embarque = "";
            _condpago = "";
            _cartacredito = "";
            _codigovia = "";
            _terminoventa = "";
            _pais = "";
            _embarque = "";
            _condpago = "";
            _cartacredito = "";
            _codigovia = "";
            _referencia = "";
            _referencia = "";

            txtPorcdet.Text = "";
            txtSerieref.Text = "";
            txtNumeroref.Text = "";
            lblTipoventa.Text = "";
            txtNumero.Text = "";
            txtNumFin.Text = "";
            txtTipoventa.Text = "";
            // fRegistro.Value = "1/1/1";
            cboOrigen.SelectedValue = "";
            if (Inicializar)
            {
                fRegistro.Value = DateTime.Now;
                cboOrigen.SelectedIndex = 0;
                // tmptabla = ocapa.KAG0600_CONSULTA(GlobalVars.GetInstance.Company, "", GlobalVars.GetInstance.TipoConceptoVentas, 1, GlobalVars.GetInstance.Company, 0);
                //if (ocapa.sql_error.Length == 0)
                //{
                //if (tmptabla.Rows.Count > 0)
                //{
                //     txtTipoventa.Text = tmptabla.Rows[0]["tipoventa"].ToString();

                //}
                //}
                txtTipoventa.Text = "02";
                validaTipoVenta();

                chkActivo.Checked = true;
                chkAfecto.Checked = true;
                chkIncluye.Checked = true;
                tributoIgv();
                cboMoneda.SelectedValue = "1";
                cboTipdoc.SelectedValue = "";
                cboTipdocref.SelectedValue = "";
                actualizatipocambio();
                txtRuc.Text = "";
                txtCtactename.Text = "";
                fecVenc.Value = DateTime.Now;
                // fecVenc.Checked = false;

                fechaRefer.Value = DateTime.Now;
                fechaRefer.ShowCheckBox = false;

                cboTipdoc.SelectedValue = "01";
                cboTipdocref.SelectedValue = "";
                cboAduana.SelectedValue = "";
                cboTipoexportacion.SelectedValue = "";
            }
            else
            {
                cboOrigen.SelectedIndex = -1;
                txtTipoventa.Text = "";
                cboTipdocref.SelectedValue = "";
                cboTipdoc.SelectedValue = "";
                chkAfecto.Checked = false;
                chkIncluye.Checked = false;
                chkActivo.Checked = false;
                // fecVenc.Checked = false;
                fechaRefer.ShowCheckBox = false;
                txtPigv.Text = "";
                cboMoneda.SelectedValue = "";

                fecVenc.Value = DateTime.Now.Date;
                fechaRefer.Value = DateTime.Now.Date;

                cboTipdoc.SelectedValue = "";
                cboTipoexportacion.SelectedValue = "";
                lblMoneda.Text = "";
                txtDescripcampo.Text = "";
            }
            txtDescripcampo.Text = "";
            txtValor.Text = "";
            txtDctos.Text = "";
            txtVenta.Text = "";
            //txtPigv.Text = "";
            txtIgv.Text = "";
            txtTotal.Text = "";
            txtTipocambio.Text = "";
            lblAnulado.Text = "";
            lblUsuar.Text = "";
        }
        private void CargaDatos()
        {
            string xnumero = "..";
            if (txtAsiento.Text.Trim().Length > 0)
            {
                xnumero = txtAsiento.Text;
            }
            if ((tmptablacab != null))
            {
                CabFacturacion = tmptablacab;
            }
            else
            {
                tb_co_VentascabBL BL = new tb_co_VentascabBL();
                tb_co_Ventascab BE = new tb_co_Ventascab();

                BE.perianio = VariablesPublicas.perianio;
                BE.perimes = txtMes.Text;
                BE.moduloid = modulo.ToString();//modulo.ToString();
                BE.local = local.ToString(); //local.ToString();
                BE.diarioid = cboSubdiario.SelectedValue.ToString();
                BE.asiento = xnumero;

                try
                {
                    CabFacturacion = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if ((tmptabladet != null))
            {
                DetFacturacion = tmptabladet;
            }
            else
            {
                //DetFacturacion = tmptabladet;
                tb_co_VentasdetBL BL = new tb_co_VentasdetBL();
                tb_co_Ventasdet BE = new tb_co_Ventasdet();

                BE.perianio = VariablesPublicas.perianio;
                BE.perimes = txtMes.Text;
                BE.moduloid = modulo.ToString();
                BE.local = local.ToString();
                BE.diarioid = cboSubdiario.SelectedValue.ToString();
                BE.asiento = xnumero;

                try
                {
                    DetFacturacion = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if ((CabFacturacion != null))
                if (CabFacturacion.Rows.Count > 0)
                {
                    decimal ximpodua = 0;
                    txtTipoventa.Text = CabFacturacion.Rows[0]["tipoventa"].ToString().Trim();
                    validaTipoVenta();
                    txtRuc.Text = CabFacturacion.Rows[0]["nmruc"].ToString().Trim();
                    ValidaProveedor();
                    // txtCtactename.Text = CabFacturacion.Rows[0]["ctactename"].ToString();
                    // Datos Aduanas
                    cboAduana.SelectedValue = CabFacturacion.Rows[0]["aduanaid"];
                    aduPeriodo.Text = CabFacturacion.Rows[0]["aniodua"].ToString().Trim();
                    aduCorrelativo.Text = CabFacturacion.Rows[0]["numdua"].ToString().Trim();
                    // aduValorfob.Text = System.String.Format(CabFacturacion.Rows[0]["valorfobdua"].ToString(), "###,###,###.00");
                    ximpodua = Convert.ToDecimal(CabFacturacion.Rows[0]["valorfobdua"]);
                    aduValorfob.Text = ximpodua.ToString("###,###,###.00");
                    if ((!object.ReferenceEquals(CabFacturacion.Rows[0]["fechembdua"], DBNull.Value)))
                    {
                        adufEmbarque.ShowCheckBox = true;
                        adufEmbarque.Value = Convert.ToDateTime(CabFacturacion.Rows[0]["fechembdua"]);
                    }
                    else
                    {
                        adufEmbarque.Value = DateTime.Now;
                        adufEmbarque.ShowCheckBox = false;
                    }
                    if ((!object.ReferenceEquals(CabFacturacion.Rows[0]["fechreguldua"], DBNull.Value)))
                    {
                        adufRegularizacion.ShowCheckBox = true;
                        adufRegularizacion.Value = Convert.ToDateTime(CabFacturacion.Rows[0]["fechreguldua"]);
                    }
                    else
                    {
                        adufRegularizacion.Value = DateTime.Now;
                        adufRegularizacion.ShowCheckBox = false;
                    } // FIn Datos Aduanas

                    //chkActivo.Checked = Convert.ToBoolean(CabFacturacion.Rows[0]["status"] = 1);
                    chkActivo.Checked = Convert.ToBoolean(CabFacturacion.Rows[0]["status"].ToString() == "0");
                    txtTipocambio.Text = CabFacturacion.Rows[0]["tipcamb"].ToString();
                    cboMoneda.SelectedValue = CabFacturacion.Rows[0]["moneda"].ToString();
                    if (cboMoneda.SelectedValue.ToString() == "1")
                    {
                        lblMoneda.Text = "S/.";
                        lblMoneda.ForeColor = Color.Blue;
                    }
                    else
                    {
                        lblMoneda.Text = "US$";
                        lblMoneda.ForeColor = Color.Green;
                    }

                    cboDestinoigv.SelectedValue = CabFacturacion.Rows[0]["afectoigvid"].ToString();

                    // cboOrigen.SelectedValue = CabFacturacion.Rows[0]["origen"].ToString();
                    switch (CabFacturacion.Rows[0]["origen"].ToString())
                    {
                        case "01":
                            cboOrigen.SelectedIndex = 0;
                            break;
                        case "02":
                            cboOrigen.SelectedIndex = 1;
                            break;
                    }
                    chkAfecto.Checked = Convert.ToBoolean(CabFacturacion.Rows[0]["afectoigv"].ToString());
                    chkIncluye.Checked = Convert.ToBoolean(CabFacturacion.Rows[0]["incprec"].ToString());
                    chkRetencion.Checked = Convert.ToBoolean(CabFacturacion.Rows[0]["afectretencion"].ToString());
                    // Datos Totalizados de Factura
                    totalizar();
                    // txtValor.Text = System.String.Format(CabFacturacion.Rows[0]["bruto1"].ToString(), "###,###,###.00");
                    // txtDctos.Text = System.String.Format(CabFacturacion.Rows[0]["dscto1"].ToString(), "###,###,###.00");
                    txtPigv.Text = String.Format(CabFacturacion.Rows[0]["pigv"].ToString(), "###.0");
                    // txtVenta.Text = System.String.Format(CabFacturacion.Rows[0]["valorventa1"].ToString(), "###,###,###.00");
                    // txtIgv.Text = System.String.Format(CabFacturacion.Rows[0]["igv1"].ToString(), "###,###,###.00");
                    // txtTotal.Text = System.String.Format(CabFacturacion.Rows[0]["total1"].ToString(), "###,###,###.00");
                    cboTipdoc.SelectedValue = CabFacturacion.Rows[0]["tipdoc"];
                    txtSerie.Text = CabFacturacion.Rows[0]["serdoc"].ToString().Trim();
                    txtNumero.Text = CabFacturacion.Rows[0]["numdoc"].ToString().Trim();
                    txtNumFin.Text = CabFacturacion.Rows[0]["numdocfinal"].ToString().Trim();
                    fRegistro.Value = Convert.ToDateTime(CabFacturacion.Rows[0]["fechdoc"]);
                    // lblTipoventa.Text = CabFacturacion.Rows[0]["dtipoventa"].ToString();
                    txtCtadetrac.Text = CabFacturacion.Rows[0]["nctadetraccion"].ToString().Trim();
                    txtGlosa.Text = CabFacturacion.Rows[0]["glosa"].ToString().Trim();
                    txtNumeroorden.Text = CabFacturacion.Rows[0]["ordencompra"].ToString().Trim();
                    // txtglosa2.Text = CabFacturacion.Rows(0).Item("glob_3");

                    cboTipdocref.SelectedValue = CabFacturacion.Rows[0]["tipref"];
                    txtSerieref.Text = CabFacturacion.Rows[0]["serref"].ToString().Trim();
                    txtNumeroref.Text = CabFacturacion.Rows[0]["numref"].ToString().Trim();

                    cboServicio.SelectedValue = CabFacturacion.Rows[0]["detraccionid"];

                    _terminoventa = CabFacturacion.Rows[0]["terminovta"].ToString().Trim();
                    _pais = CabFacturacion.Rows[0]["dpais"].ToString().Trim();
                    _embarque = CabFacturacion.Rows[0]["embarcador"].ToString().Trim();
                    _condpago = CabFacturacion.Rows[0]["condicionpago"].ToString().Trim();
                    _cartacredito = CabFacturacion.Rows[0]["cartacredito"].ToString().Trim();
                    _codigovia = CabFacturacion.Rows[0]["viaembarque"].ToString().Trim();
                    _referencia = CabFacturacion.Rows[0]["referencia"].ToString().Trim();

                    txtPorcdet.Text = System.String.Format(CabFacturacion.Rows[0]["porcdetraccion"].ToString(), "###.00");
                    if ((!object.ReferenceEquals(CabFacturacion.Rows[0]["fechvcto"], DBNull.Value)))
                    {
                        fecVenc.Value = Convert.ToDateTime(CabFacturacion.Rows[0]["fechvcto"]);
                        fecVenc.ShowCheckBox = true;                      
                    }
                    else
                    {
                        fecVenc.ShowCheckBox = false;
                    }

                    if ((!object.ReferenceEquals(CabFacturacion.Rows[0]["fechref"], DBNull.Value)))
                    {
                        fechaRefer.Value = Convert.ToDateTime(CabFacturacion.Rows[0]["fechref"]);
                        fechaRefer.ShowCheckBox = true;
                    }
                    else
                    {
                        fechaRefer.ShowCheckBox = false;
                    }
                    xmaqreg = CabFacturacion.Rows[0]["maqreg"].ToString().Trim();
                    xnumdocfinal = CabFacturacion.Rows[0]["numdocfinal"].ToString().Trim();
                    xestabsunat = CabFacturacion.Rows[0]["estabsunat"].ToString().Trim();
                }
                else
                {
                    blanquear(false);
                }
            GridExaminar.AutoGenerateColumns = false;
            int LC_CONT;
            for (LC_CONT = 0; LC_CONT <= GridExaminar.ColumnCount - 1; LC_CONT++)
            {
                GridExaminar.Columns[LC_CONT].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            GridExaminar.DataSource = DetFacturacion;
            PintaEncabezados(GridExaminar);
            if ((CabFacturacion != null))
            {
                if (CabFacturacion.Rows.Count > 0)
                {
                    lblAnulado.Text = (chkActivo.Checked ? "" : "ANULADO");
                    lblUsuar.Text = CabFacturacion.Rows[0]["Usuar"].ToString().ToUpper().Trim() + " - " + CabFacturacion.Rows[0]["feact"].ToString().Trim();
                }
            }
            else
            {
                lblAnulado.Text = "";
                lblUsuar.Text = "";
            }
            u_ShowGets();
        }

        #region Validacion de Cuenta Corriente
        private void txtRuc_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1))
            {
                AyudaProveedor();
            }
        }
        private void txtRuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void txtRuc_LostFocus(object sender, System.EventArgs e)
        {
            if (!sw_load)
            {
                if ((u_n_opsel > 0))
                {
                    if (!(j_String == txtRuc.Text))
                    {
                        ValidaProveedor();
                    }
                }
            }
        }
        private void txtRuc_GotFocus(object sender, System.EventArgs e)
        {
            if (!sw_load)
            {
                if ((u_n_opsel > 0))
                {
                    j_String = txtRuc.Text;
                }
            }
        }
        private void AyudaProveedor()
        {
            Ayudas.Frm_AyudaProveedor frmNew = new Ayudas.Frm_AyudaProveedor();
            frmNew._Valores = "<< Ayuda Clientes >>";
            frmNew.Owner = this;
            frmNew.PasaProveedor = RecibeProveedor;
            frmNew.ShowDialog();
        }
        private void RecibeProveedor(string xruc, string xnombre, string xdirec)
        {
            if (xruc.Trim().Length > 0)
            {
                txtRuc.Text = xruc;
                ValidaProveedor();
            }
        }
        private void ValidaProveedor()
        {
            if (txtRuc.Text.Trim().Length > 0)
            {
                clienteBL BL = new clienteBL();
                tb_cliente BE = new tb_cliente();

                BE.nmruc = txtRuc.Text;
                DataTable tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                if (tmptabla.Rows.Count == 0)
                {
                    txtRuc.Text = j_String;
                }
                else
                {
                    xtipopersona = tmptabla.Rows[0]["tpperson"].ToString();
                    xtipodocidentidad = tmptabla.Rows[0]["docuidentid"].ToString();
                    xctacte = tmptabla.Rows[0]["ctacte"].ToString();
                    txtRuc.Text = tmptabla.Rows[0]["nmruc"].ToString();
                    txtCtactename.Text = tmptabla.Rows[0]["ctactename"].ToString();
                    xdirec = tmptabla.Rows[0]["direc"].ToString();
                    xubige = tmptabla.Rows[0]["ubige"].ToString();
                }
            }
            else
            {
                txtRuc.Text = j_String;
            }
        }
        #endregion

        #region Metodos MANTENIMIENTO DE ASIENTO
        private void txtMes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                j_String = "..";
                //txtAsiento.Focus();
                txtMes.Focus();
            }
            if (e.KeyCode == Keys.F1)
            {
                AyudaRegVentas(0);
            }
        }
        private void txtMes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar) >= '0' & e.KeyChar <= '9') & !(e.KeyChar == '.'))
            //if (Strings.Asc(e.KeyChar) >= Strings.Asc("0") & Strings.Asc(e.KeyChar) <= Strings.Asc("9") & !(e.KeyChar == "."))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back | e.KeyChar == (char)Keys.Delete & !(e.KeyChar == '.'))
                //if (Strings.Asc(e.KeyChar) == Keys.Back | Strings.Asc(e.KeyChar) == Keys.Delete & !(e.KeyChar == "."))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
        private void txtMes_GotFocus(object sender, System.EventArgs e)
        {
            j_String = txtMes.Text;
        }
        private void txtMes_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_String == txtMes.Text) & u_n_opsel == 0)
            {
                txtMes.Text = (txtMes.Text.Trim().Length == 0 ? j_String : VariablesPublicas.PADL(txtMes.Text.Trim(), 2, "0"));
                UltimoNumeroRegistro();
                blanquear(false);
                refrescacontroles();
            }
        }
        private void txtAsiento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1)
            {
                AyudaRegVentas(1);
            }
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("\t");
            }
        }
        private void txtAsiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar) >= '0' & e.KeyChar <= '9') & !(e.KeyChar == '.'))
            //if (Strings.Asc(e.KeyChar) >= Strings.Asc("0") & Strings.Asc(e.KeyChar) <= Strings.Asc("9") & !(e.KeyChar == "."))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back | e.KeyChar == (char)Keys.Delete & !(e.KeyChar == '.'))
                //if (Strings.Asc(e.KeyChar) == Keys.Back | Strings.Asc(e.KeyChar) == Keys.Delete & !(e.KeyChar == "."))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
        private void txtAsiento_GotFocus(object sender, System.EventArgs e)
        {
            if ((u_n_opsel == 0))
            {
                if (!(sELECCIONAaYUDA))
                {
                    UltimoNumeroRegistro();
                    CargaDatos();
                }
                else
                {
                    sELECCIONAaYUDA = false;
                }
            }
        }
        #endregion

        #region "Combo de Afecto al IGV"
        private void cboDestinoigv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((u_n_opsel > 0))
            {
                if (cboDestinoigv.Text.Substring(0, 1) == "2")
                {
                    chkAfecto.Checked = false;
                    chkIncluye.Checked = false;
                }
                else
                {
                    chkAfecto.Checked = true;
                    chkIncluye.Checked = true;
                }
                refrescacontroles();
                totalizarItem();
            }
        }
        private void cboDestinoigv_GotFocus(object sender, System.EventArgs e)
        {
            j_String = Equivalencias.Left(cboDestinoigv.Text, 1);
        }
        private void cboDestinoigv_LostFocus(object sender, System.EventArgs e)
        {
            if ((!(j_String == cboDestinoigv.Text) && (!sw_load && (u_n_opsel > 0))))
            {
                validaTipoIgv();
            }
        }
        public void validaTipoIgv()
        {
            string xcodigo = "";
            xcodigo = Equivalencias.Left(cboDestinoigv.Text, 1);
            tb_co_tributoafectoventasBL BL = new tb_co_tributoafectoventasBL();
            tb_co_tributoafectoventas BE = new tb_co_tributoafectoventas();

            BE.destinoid = xcodigo;
            tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            if (tmptabla.Rows.Count > 0)
            {
                xcodigo = tmptabla.Rows[0]["destinoid"].ToString();
                if (!(Equivalencias.Left(cboDestinoigv.Text, 1) == "3"))
                {
                    sw_novaluechange = true;
                    if ((DetFacturacion != null))
                    {
                        if (DetFacturacion.Rows.Count > 0)
                        {
                            DetFacturacion.Rows[lc_contador]["afectoigvid"] = Equivalencias.Left(cboDestinoigv.Text, 1);
                        }
                    }
                    sw_novaluechange = false;
                }
            }
            else
            {
                cboDestinoigv.ValueMember = j_String;
            }
            GridExaminar.Refresh();
            refrescacontroles();
        }
        private void AyudaTipoIgvDetalle()
        {
            Frm_AyudaAfectoigvVentas frmayuda = new Frm_AyudaAfectoigvVentas();
            frmayuda.Owner = this;
            frmayuda._PasaValor = RecibeTipoIgvDetalle;
            frmayuda.ShowDialog();
        }
        private void RecibeTipoIgvDetalle(string codigo)
        {
            if (codigo.Trim().Length > 0)
            {
                GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["afectoigvid"].Value = codigo;
            }
        }
        internal void validaTipoIgvDetalle()
        {
            string xcodigo = "";
            sw_novaluechange = true;
            if (GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["afectoigvid"].Value == DBNull.Value)
            {
                GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["afectoigvid"].Value = "";
            }
            xcodigo = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["afectoigvid"].Value.ToString();
            if (xcodigo.Trim().Length > 0)
            {
                tb_co_tributoafectoventasBL BL = new tb_co_tributoafectoventasBL();
                tb_co_tributoafectoventas BE = new tb_co_tributoafectoventas();

                BE.destinoid = xcodigo;
                tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                if (tmptabla.Rows.Count > 0)
                {
                    GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["afectoigvid"].Value = tmptabla.Rows[0]["destinoid"];
                    // GridExaminar.Rows[ GridExaminar.CurrentRow.Index].Cells["ddestino"].Value = tmptabla.Rows[0]["DESCRIP"];
                    txtDescripcampo.Text = tmptabla.Rows[0]["destinoname"].ToString();
                }
                else
                {
                    GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["afectoigvid"].Value = j_Destino;
                }
            }
            else
            {
                GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["afectoigvid"].Value = j_Destino;
            }
            sw_novaluechange = false;
            totalizarItem();
        }
        #endregion

        //Para activar Doc.Referencia
        private void cboTipdoc_SelectedValueChanged(object sender, EventArgs e)
        {
            tb_co_tabla10_comprobantesBL BL = new tb_co_tabla10_comprobantesBL();
            tb_co_tabla10_comprobantes BE = new tb_co_tabla10_comprobantes();

            if (u_n_opsel > 0)
            {
                try
                {
                    BE.codigoid = cboTipdoc.Text.Substring(0, 2);
                    DataTable table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                    // gpoReferencia.Enabled = Convert.ToBoolean(table.Rows[0]["docref"].ToString())
                    if (Convert.ToBoolean(table.Rows[0]["docref"].ToString()) == true)
                    {
                        gpoReferencia.Enabled = true;
                        cboTipdocref.SelectedIndex = 1;
                        cboTipdocref.Focus();
                    }
                    else
                    {
                        gpoReferencia.Enabled = false;
                        cboTipdocref.SelectedIndex = -1;
                        txtSerieref.Clear();
                        txtNumeroref.Clear();
                    }
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void totalizar()
        {
            int lcont = 0;
            decimal vmventa = 0;
            decimal vmigv = 0;
            decimal vmtotal = 0;
            decimal vmvalor = 0;
            decimal vmdctos = 0;
            for (lcont = 0; lcont <= DetFacturacion.Rows.Count - 1; lcont++)
            {
                vmvalor += Math.Round(Convert.ToDecimal(DetFacturacion.Rows[lcont]["bruto"]), 2);
                vmdctos += Math.Round(Convert.ToDecimal(DetFacturacion.Rows[lcont]["dscto"]), 2);
                vmventa += Math.Round(Convert.ToDecimal(DetFacturacion.Rows[lcont]["valorventa"]), 2);
                vmigv += Math.Round(Convert.ToDecimal(DetFacturacion.Rows[lcont]["igvo"]), 2);
                vmtotal += Math.Round(Convert.ToDecimal(DetFacturacion.Rows[lcont]["total"]), 2);
            }
            txtValor.Text = vmvalor.ToString("###,###,###.00");
            txtDctos.Text = vmdctos.ToString("###,###,###.00");
            txtVenta.Text = vmventa.ToString("###,###,###.00");
            txtIgv.Text = vmigv.ToString("###,###,###.00");
            txtTotal.Text = vmtotal.ToString("###,###,###.00");
        }
        private void totalizarItem()
        {
            if (u_n_opsel > 0)
            {
                sw_novaluechange = true;
                int lccont = 0;
                //decimal ncantidas = 0;
                decimal nprecio = 0;
                decimal NPORCENTAjedcto = 0;
                decimal nporigv = 0;
                if (chkAfecto.Checked)
                {
                    nporigv = VariablesPublicas.StringtoDecimal(txtPigv.Text);
                }
                if ((GridExaminar.CurrentCell != null))
                {
                    for (lccont = 0; lccont <= DetFacturacion.Rows.Count - 1; lccont++)
                    {
                        if (chkIncluye.Checked & GridExaminar.Rows[lccont].Cells["afectoigvid"].Value.ToString() != "2")
                        {
                            nprecio = Convert.ToDecimal(DetFacturacion.Rows[lccont]["precunit"]) / (1 + (nporigv / 100));
                        }
                        else
                        {
                            nprecio = Convert.ToDecimal(DetFacturacion.Rows[lccont]["precunit"]);
                        }
                        NPORCENTAjedcto = 1 - (Convert.ToDecimal(DetFacturacion.Rows[lccont]["pdscto"]) / 100);
                        DetFacturacion.Rows[lccont]["bruto"] = Convert.ToDecimal(DetFacturacion.Rows[lccont]["precunit"]) * (Convert.ToDecimal(DetFacturacion.Rows[lccont]["cantidad"]));
                        DetFacturacion.Rows[lccont]["dscto"] = Math.Round(Convert.ToDecimal(DetFacturacion.Rows[lccont]["bruto"]) * (Convert.ToDecimal(DetFacturacion.Rows[lccont]["pdscto"]) / 100), 2);
                        DetFacturacion.Rows[lccont]["valorventa"] = Math.Round((nprecio * Convert.ToDecimal(DetFacturacion.Rows[lccont]["cantidad"])) * NPORCENTAjedcto, 4);
                        if (GridExaminar.Rows[lccont].Cells["afectoigvid"].Value.ToString() != "2")
                        {
                            DetFacturacion.Rows[lccont]["igvo"] = Math.Round(Convert.ToDecimal(DetFacturacion.Rows[lccont]["valorventa"]) * (nporigv / 100), 2);
                        }
                        else
                        {
                            DetFacturacion.Rows[lccont]["igvo"] = 0;
                        }
                        DetFacturacion.Rows[lccont]["valorventa"] = Math.Round((nprecio * Convert.ToDecimal(DetFacturacion.Rows[lccont]["cantidad"])) * NPORCENTAjedcto, 2);
                        //DetFacturacion.Rows[lccont]["igv1"] = Math.Round((Convert.ToDecimal(DetFacturacion.Rows[lccont]["valorventa1"]) * (nporigv / 100)) * 1, 2);
                        DetFacturacion.Rows[lccont]["total"] = (Convert.ToDecimal(DetFacturacion.Rows[lccont]["valorventa"]) + Convert.ToDecimal(DetFacturacion.Rows[lccont]["igvo"]));
                    }
                }
                sw_novaluechange = false;
                totalizar();
                GridExaminar.Refresh();
            }
        }
        public void CalculaCabecera(Decimal vmventa, Decimal vmigv, Decimal vmtotal)
        {
            decimal nfactorredonde = 0;
            decimal porcentajeigv = 1 + (VariablesPublicas.StringtoDecimal(txtPigv.Text) / 100);
            decimal pflete = 1;

            decimal nporcdcto = 0;
            decimal montodcto = 0;
            // Calculo con porcentaje descuento
            if (nporcdcto >= 0)
            {
                txtVenta.Text = ((vmventa * (1 - (nporcdcto / 100))) * pflete).ToString("###,###.00");
                //Me.txtigv.Text = Format((vmigv * (1 - (nporcdcto / 100))) * pflete, "###,###.00")
                txtTotal.Text = (((((vmtotal - (vmtotal * (nporcdcto / 100)))) * pflete)) + nfactorredonde).ToString("###,###.00");
                txtIgv.Text = (Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtVenta.Text)).ToString("###,###.00");
            }
            // calculo con monto descuento
            if (nporcdcto == 0 & montodcto > 0)
            {
                txtVenta.Text = (((vmtotal - montodcto) / porcentajeigv) * pflete).ToString("###,###.00");
                txtIgv.Text = (((vmtotal - montodcto) - ((vmtotal - montodcto) / porcentajeigv)) * pflete).ToString("###,###.00");
                txtTotal.Text = (((((vmtotal - montodcto))) * pflete) + nfactorredonde).ToString("###,###.00");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (PuedeEditarEliminar("EDITAR", VariablesPublicas.PADL(fRegistro.Value.Month.ToString(), 2, "0")))
            {
                u_n_opsel = 2;
                refrescacontroles();
                W_KEY0001 = txtRuc.Text;
                if ((cboTipdoc.SelectedValue != null))
                {
                    W_KEY0001 = W_KEY0001 + cboTipdoc.SelectedValue;
                }
                W_KEY0001 = W_KEY0001 + txtSerie.Text + txtNumero.Text;
                txtRuc.Focus();
            }
        }

        public bool PuedeEditarEliminar(string glosamensaje, string codmes)
        {
            bool zpuede = true;
            tb_co_cierremensualesBL BL = new tb_co_cierremensualesBL();
            tb_co_cierremensuales BE = new tb_co_cierremensuales();

            BE.periano = VariablesPublicas.perianio;
            BE.moduloid = VariablesPublicas.tipocierremensualVentas;
            BE.perimes = codmes;
            tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            //tmptabla = ocapa.Getall_CierreMensual(GlobalVars.GetInstance.Company, GlobalVars.GetInstance.Periodo, GlobalVars.GetInstance.tipocierremensualVentas, codmes);
            if (BL.Sql_Error.Length > 0)
            {
                zpuede = false;
                Codigo.Frm_Class.ShowError(BL.Sql_Error, this);
            }
            else
            {
                if (tmptabla.Rows.Count > 0)
                {
                    if (!(Convert.ToBoolean(tmptabla.Rows[0]["status"]) == false))
                    {
                        //Interaction.MsgBox("Mes Cerrado ...Imposible " + glosamensaje.Trim(), 64, "");
                        DevExpress.XtraEditors.XtraMessageBox.Show("Mes Cerrado ...Imposible " + glosamensaje.Trim(), "BapSoft", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        zpuede = false;
                    }
                }
                else
                {
                    zpuede = false;
                }
            }
            return zpuede;
        }

        private void chkAfecto_CheckedChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0)
            {
                totalizarItem();
                if (!chkAfecto.Checked)
                {
                    chkIncluye.Checked = false;
                }
                refrescacontroles();
            }
        }
        private void chkIncluye_CheckedChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0)
            {
                totalizarItem();
            }
        }

        private void btnRetro_Click(object sender, EventArgs e)
        {
            U_CancelarEdicion(1);
        }
        private void U_CancelarEdicion(int SwConfirmacion)
        {
            // Ojo Poner este codigo para que al momento de cancelar el ingreso de datos no valide la celda
            if (GridExaminar.IsCurrentCellInEditMode)
            {
                GridExaminar.CancelEdit();
            }
            bool sw_prosigue = true;
            if (SwConfirmacion == 1)
            {
                sw_prosigue = (DevExpress.XtraEditors.XtraMessageBox.Show("Desea cancelar ingreso de datos...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
            }
            else
            {
                sw_prosigue = true;
            }
            if (sw_prosigue)
            {
                u_n_opsel = 0;
                txtAsiento.Enabled = true;
                txtAsiento.Focus();
                CargaDatos();
                refrescacontroles();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Grabar(false);
        }
        private void Grabar(bool nopideimpresion)
        {
            // Forzar a grabar si pulsa el boton sin finalizar edicion del grid
            if (GridExaminar.IsCurrentCellInEditMode)
            {
                GridExaminar.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

            #region ** numeracion
            while (u_n_opsel == 1)
            {
                tb_co_VentascabBL BL = new tb_co_VentascabBL();
                tb_co_Ventascab BE = new tb_co_Ventascab();

                BE.perianio = VariablesPublicas.perianio;
                BE.perimes = txtMes.Text;
                BE.moduloid = modulo.ToString();//modulo.ToString();
                BE.local = local.ToString();   //local.ToString();
                BE.diarioid = cboSubdiario.Text.Substring(0, 4);
                BE.asiento = txtAsiento.Text;
                try
                {
                    tmptablacab = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (tmptablacab.Rows.Count == 0)
                {
                    break;
                }
                UltimoNumeroRegistro();
            }
            #endregion

            #region ** Recapturar Tipo de Cambio
            tributoIgv();
            actualizatipocambio();
            totalizarItem();
            //totalizar();
            #endregion

            if (Validacion())
            {
                // Variables de Cabecera
                tb_co_VentasBL BL = new tb_co_VentasBL();
                tb_co_Ventas BE = new tb_co_Ventas();

                // Variables para Detalle
                tb_co_Ventas.Item Detalle = new tb_co_Ventas.Item();
                List<tb_co_Ventas.Item> ListaItems = new List<tb_co_Ventas.Item>();

                string activo = "0"; //Activo
                string anulad = "9"; //Anulado
                string xMoneda = Equivalencias.Left(cboMoneda.SelectedValue.ToString(), 1);
                xnum = VariablesPublicas.PADL(txtAsiento.Text.Trim(), 6, "0");

                #region **ingreso venta cabecera***
                //caso venta
                BE.perianio = VariablesPublicas.perianio;
                BE.perimes = VariablesPublicas.PADL(txtMes.Text.Trim(), 2, "0");
                BE.moduloid = modulo.ToString();
                BE.local = local.ToString();
                BE.diarioid = VariablesPublicas.PADL(cboSubdiario.SelectedValue.ToString(), 4, "0");
                BE.asiento = VariablesPublicas.PADL(txtAsiento.Text.Trim(), 6, "0");
                BE.origen = cboOrigen.Text.Substring(0, 2);
                if (chkActivo.Checked == true)
                {
                    BE.status = activo;
                }
                if (chkActivo.Checked == false)
                {
                    BE.status = anulad;
                }
                BE.tipdoc = cboTipdoc.Text.Substring(0, 2);
                BE.serdoc = txtSerie.Text;
                BE.numdoc = txtNumero.Text;
                BE.tiperson = xtipopersona;
                BE.tipdid = xtipodocidentidad;
                BE.ctacte = xctacte;
                BE.nmruc = txtRuc.Text.Trim();
                BE.ctactename = txtCtactename.Text.Trim().ToUpper();
                BE.direc = xdirec;
                BE.ubige = xubige;
                BE.fechdoc = Convert.ToDateTime(fRegistro.Text.Trim());
                if (fecVenc.ShowCheckBox)
                {
                    BE.fechvcto = fecVenc.Value;
                }

                BE.condicionvta = "";
                BE.tipcamb = Convert.ToDecimal(txtTipocambio.Text.Trim());
                BE.moneda = cboMoneda.Text.Substring(0, 1);
                BE.ordencompra = txtNumeroorden.Text;
                //Detracciones
                if ((cboServicio.SelectedValue != null))
                {
                    BE.detraccionid = cboServicio.SelectedValue.ToString();
                }
                else
                {
                    BE.detraccionid = DBNull.Value.ToString();
                }
                BE.porcdetraccion = VariablesPublicas.StringtoDecimal(txtPorcdet.Text);
                BE.nctadetraccion = txtCtadetrac.Text;
                BE.glosa = txtGlosa.Text;
                BE.tipoventa = txtTipoventa.Text;
                BE.afectoigvid = cboDestinoigv.Text.Substring(0, 1);

                //datos documento de referencia
                if (cboTipdocref.Enabled)
                {
                    if (cboTipdocref.Text.Length > 0)
                    {
                        BE.tipref = cboTipdocref.Text.Substring(0, 2);
                    }
                    //BE.tipref =  cboTipdocref.Text.Substring(0, 2);
                    BE.serref = txtSerieref.Text.Trim().ToString();
                    BE.numref = txtNumeroref.Text.Trim().ToString();
                    if (fechaRefer.ShowCheckBox)
                    {
                        BE.fechref = fechaRefer.Value;
                    }
                }

                //Aduanas
                if (cboAduana.Enabled)
                {
                    if (!(cboAduana.SelectedValue == null))
                    {
                        BE.aduanaid = cboAduana.SelectedValue.ToString();
                    }
                    BE.aniodua = aduPeriodo.Text;
                    BE.numdua = aduCorrelativo.Text;
                    BE.valorfobdua = VariablesPublicas.StringtoDecimal(aduValorfob.Text);
                    if ((adufEmbarque.ShowCheckBox == true))
                    {
                        BE.fechembdua = adufEmbarque.Value;
                    }
                    if ((adufRegularizacion.ShowCheckBox == true))
                    {
                        BE.fechreguldua = adufRegularizacion.Value;
                    }
                    if (!(cboTipoexportacion.SelectedValue == null))
                    {
                        BE.tipoexportid = cboTipoexportacion.SelectedValue.ToString();
                    }
                }
                BE.afectoigv = chkAfecto.Checked;
                BE.incprec = chkIncluye.Checked;
                BE.afectretencion = chkRetencion.Checked;
                BE.terminovta = _terminoventa;
                BE.dpais = _pais;
                BE.embarcador = _embarque;
                BE.condicionpago = _condpago;
                BE.cartacredito = _cartacredito;
                BE.viaembarque = _codigovia;
                BE.referencia = _referencia;

                BE.bultos = "";
                BE.pesoneto = 0;
                BE.pesobruto = 0;

                switch (xMoneda)
                {
                    case "1":
                        BE.bruto1 = VariablesPublicas.StringtoDecimal(txtValor.Text);
                        BE.dscto1 = VariablesPublicas.StringtoDecimal(txtDctos.Text);
                        BE.valorventa1 = VariablesPublicas.StringtoDecimal(txtVenta.Text);
                        BE.igv1 = VariablesPublicas.StringtoDecimal(txtIgv.Text);
                        BE.total1 = VariablesPublicas.StringtoDecimal(txtTotal.Text);
                        if (BE.tipcamb > 0)
                        {
                            BE.bruto2 = Math.Round(VariablesPublicas.StringtoDecimal(txtValor.Text) / BE.tipcamb, 2);
                            BE.dscto2 = Math.Round(VariablesPublicas.StringtoDecimal(txtDctos.Text) / BE.tipcamb, 2);
                            BE.valorventa2 = Math.Round(VariablesPublicas.StringtoDecimal(txtVenta.Text) / BE.tipcamb, 2);
                            BE.igv2 = Math.Round(VariablesPublicas.StringtoDecimal(txtIgv.Text) / BE.tipcamb, 2);
                            BE.total2 = Math.Round(VariablesPublicas.StringtoDecimal(txtTotal.Text) / BE.tipcamb, 2);

                            BE.valorventa2 = Math.Round(BE.valorventa2, 2);
                            BE.igv2 = Math.Round(BE.igv2, 2);
                            BE.total2 = Math.Round(BE.total2, 2);
                        }

                        break;
                    case "2":
                        BE.bruto2 = VariablesPublicas.StringtoDecimal(txtValor.Text);
                        BE.dscto2 = VariablesPublicas.StringtoDecimal(txtDctos.Text);
                        BE.valorventa2 = VariablesPublicas.StringtoDecimal(txtVenta.Text);
                        BE.igv2 = VariablesPublicas.StringtoDecimal(txtIgv.Text);
                        BE.total2 = VariablesPublicas.StringtoDecimal(txtTotal.Text);
                        if (BE.tipcamb > 0)
                        {
                            BE.bruto1 = Math.Round(VariablesPublicas.StringtoDecimal(txtValor.Text) * BE.tipcamb, 2);
                            BE.dscto1 = Math.Round(VariablesPublicas.StringtoDecimal(txtDctos.Text) * BE.tipcamb, 2);
                            BE.valorventa1 = Math.Round(VariablesPublicas.StringtoDecimal(txtVenta.Text) * BE.tipcamb, 2);
                            BE.igv1 = Math.Round(VariablesPublicas.StringtoDecimal(txtIgv.Text) * BE.tipcamb, 2);
                            BE.total1 = Math.Round(VariablesPublicas.StringtoDecimal(txtTotal.Text) * BE.tipcamb, 2);

                            BE.valorventa1 = Math.Round(BE.valorventa1, 2);
                            BE.igv1 = Math.Round(BE.igv1, 2);
                            BE.total1 = Math.Round(BE.total1, 2);
                        }

                        break;
                }
                BE.valorventa1 = BE.valorventa1 + (BE.total1 - (BE.valorventa1 + BE.igv1)); // S/.
                BE.valorventa2 = BE.valorventa2 + (BE.total2 - (BE.valorventa2 + BE.igv2)); // US$

                BE.pdscto = 0;
                BE.pigv = VariablesPublicas.StringtoDecimal(txtPigv.Text);
                BE.tienda = "";
                BE.ndias = 0;
                BE.vendedorid = "";
                BE.porcvta = 0;
                BE.porcefect = 0;
                BE.vinculante = "";
                BE.usuar = VariablesPublicas.Usuar.ToUpper().Trim();
                BE.maqreg = xmaqreg;
                //BE.numdocfinal = xnumdocfinal;
                BE.numdocfinal = txtNumFin.Text;
                BE.estabsunat = xestabsunat;
                #endregion

                #region ****ingreso movimiento detalle***

                int item = 0;
                foreach (DataRow fila in DetFacturacion.Rows)
                {
                    Detalle = new tb_co_Ventas.Item();

                    item++;

                    Detalle.perianio = VariablesPublicas.perianio;
                    Detalle.perimes = VariablesPublicas.PADL(txtMes.Text.Trim(), 2, "0");
                    Detalle.moduloid = modulo.ToString();
                    Detalle.local = local.ToString();
                    Detalle.diarioid = BE.diarioid;
                    Detalle.asiento = VariablesPublicas.PADL(txtNumero.Text.Trim(), 6, "0");

                    //datos documento cabecera importante [todos]
                    Detalle.tipdoc = cboTipdoc.Text.Substring(0, 2);
                    Detalle.serdoc = txtSerie.Text.Trim().ToString().PadLeft(4, '0');
                    Detalle.numdoc = txtNumero.Text.Trim().ToString().PadLeft(10, '0');
                    Detalle.fechdoc = Convert.ToDateTime(fRegistro.Text.Trim());
                    if (fecVenc.ShowCheckBox)
                    {
                        Detalle.fechvcto = fecVenc.Value;
                    }
                    //datos de cliente o proveedor
                    Detalle.nmruc = txtRuc.Text.Trim().ToUpper();
                    Detalle.ctactename = txtCtactename.Text.Trim().ToUpper();
                    //accion del alamacen dependiendo del tipo de documento
                    Detalle.almacaccionid = fila["almacaccionid"].ToString();
                    if (chkActivo.Checked == true)
                    {
                        Detalle.status = activo;
                    }
                    if (chkActivo.Checked == false)
                    {
                        Detalle.status = anulad;
                    }
                    //datos documento de referencia
                    if (cboTipdocref.Enabled)
                    {
                        if (cboTipdocref.Text.Length > 0)
                        {
                            Detalle.tipref = cboTipdocref.Text.Substring(0, 2);
                        }
                        //Detalle.tipref = cboTipdocref.Text.Substring(0, 2);
                        Detalle.serref = txtSerieref.Text.Trim().ToString();
                        Detalle.numref = txtNumeroref.Text.Trim().ToString();
                        if (fechaRefer.ShowCheckBox)
                        {
                            Detalle.fechref = fechaRefer.Value;
                        }
                    }
                    //datos calculados de detalle de movimiento obtenidos de memoria
                    Detalle.items = fila["items"].ToString();
                    Detalle.asientoitems = item.ToString().PadLeft(5, '0');
                    Detalle.rubroid = fila["rubroid"].ToString();
                    Detalle.tippedido = fila["tippedido"].ToString();
                    Detalle.serpedido = fila["serpedido"].ToString();
                    Detalle.numpedido = fila["numpedido"].ToString();
                    Detalle.tipOp = fila["tip_op"].ToString();
                    Detalle.serOp = fila["ser_op"].ToString();
                    Detalle.numOp = fila["num_op"].ToString();
                    Detalle.productid = fila["productid"].ToString();
                    Detalle.productname = fila["productname"].ToString();
                    Detalle.tallacolor = fila["tallacolor"].ToString();
                    Detalle.unidmedidaid = fila["unidmedidaid"].ToString();
                    Detalle.cantidad = Convert.ToDecimal(fila["cantidad"].ToString());

                    switch (xMoneda)
                    {
                        case "1":
                            Detalle.precunit1 = Convert.ToDecimal(fila["precunit"].ToString());
                            Detalle.bruto1 = Convert.ToDecimal(fila["bruto"].ToString());
                            Detalle.dscto1 = Convert.ToDecimal(fila["dscto"].ToString());
                            Detalle.valorventa1 = Convert.ToDecimal(fila["valorventa"].ToString());
                            Detalle.igv1 = Convert.ToDecimal(fila["igvo"].ToString());
                            Detalle.total1 = Convert.ToDecimal(fila["total"].ToString());
                            if ((BE.tipcamb > 0))
                            {
                                Detalle.precunit2 = Math.Round(Convert.ToDecimal(fila["precunit"]) / BE.tipcamb, 2);
                                Detalle.bruto2 = Math.Round(Convert.ToDecimal(fila["bruto"]) / BE.tipcamb, 2);
                                Detalle.dscto2 = Math.Round(Convert.ToDecimal(fila["dscto"]) / BE.tipcamb, 2);
                                Detalle.valorventa2 = Math.Round(Convert.ToDecimal(fila["valorventa"]) / BE.tipcamb, 2);
                                Detalle.igv2 = Math.Round(Convert.ToDecimal(fila["igvo"]) / BE.tipcamb, 2);
                                Detalle.total2 = Math.Round(Convert.ToDecimal(fila["total"]) / BE.tipcamb, 2);
                                BE.valorventa2 = Math.Round(BE.valorventa2, 2);
                                BE.igv2 = Math.Round(BE.igv2, 2);
                                BE.total2 = Math.Round(BE.total2, 2);
                            }
                            break;
                        case "2":
                            Detalle.precunit2 = Convert.ToDecimal(fila["precunit"].ToString());
                            Detalle.bruto2 = Convert.ToDecimal(fila["bruto"].ToString());
                            Detalle.dscto2 = Convert.ToDecimal(fila["dscto"].ToString());
                            Detalle.valorventa2 = Convert.ToDecimal(fila["valorventa"].ToString());
                            Detalle.igv2 = Convert.ToDecimal(fila["igvo"].ToString());
                            Detalle.total2 = Convert.ToDecimal(fila["total"].ToString());
                            if ((BE.tipcamb > 0))
                            {
                                Detalle.precunit1 = Math.Round(Convert.ToDecimal(fila["precunit"]) * BE.tipcamb, 2);
                                Detalle.bruto1 = Math.Round(Convert.ToDecimal(fila["bruto"]) * BE.tipcamb, 2);
                                Detalle.dscto1 = Math.Round(Convert.ToDecimal(fila["dscto"]) * BE.tipcamb, 2);
                                Detalle.valorventa1 = Math.Round(Convert.ToDecimal(fila["valorventa"]) * BE.tipcamb, 2);
                                Detalle.igv1 = Math.Round(Convert.ToDecimal(fila["igvo"]) * BE.tipcamb, 2);
                                Detalle.total1 = Math.Round(Convert.ToDecimal(fila["total"]) * BE.tipcamb, 2);
                                Detalle.valorventa1 = Math.Round(BE.valorventa1, 2);
                                Detalle.igv1 = Math.Round(BE.igv1, 2);
                                Detalle.total1 = Math.Round(BE.total1, 2);
                            }
                            break;
                    }
                    //Detalle.precunit1 = Convert.ToDecimal(fila["precunit1"].ToString());
                    //Detalle.bruto1 = Convert.ToDecimal(fila["bruto1"].ToString());
                    //Detalle.dscto1 = Convert.ToDecimal(fila["dscto1"].ToString());
                    //Detalle.valorventa1 = Convert.ToDecimal(fila["valorventa1"].ToString());
                    //Detalle.igv1 = Convert.ToDecimal(fila["igv1"].ToString());
                    //Detalle.total1 = Convert.ToDecimal(fila["total1"].ToString());

                    Detalle.pdscto = Convert.ToDecimal(fila["pdscto"].ToString());
                    Detalle.pigv = Convert.ToDecimal(txtPigv.Text.Trim());
                    Detalle.tipguia = fila["tipguia"].ToString();
                    Detalle.serguia = fila["serguia"].ToString();
                    Detalle.numguia = fila["numguia"].ToString();

                    Detalle.afectoigvid = fila["afectoigvid"].ToString();
                    Detalle.incprec = chkIncluye.Checked;
                    Detalle.vendedorid = fila["vendedorid"].ToString();
                    Detalle.cencosid = fila["cencosid"].ToString();
                    Detalle.glosa = txtGlosa.Text.Trim().ToUpper().ToString();
                    Detalle.moneda = Equivalencias.Left(cboMoneda.SelectedValue.ToString(), 1);
                    Detalle.tcamb = Convert.ToDecimal(txtTipocambio.Text.Trim());
                    Detalle.ordencs = fila["ordencs"].ToString();
                    Detalle.comisionvta = Convert.ToDecimal(fila["comisionvta"].ToString());
                    Detalle.porcvta = Convert.ToDecimal(fila["porcvta"].ToString());
                    Detalle.porcefect = Convert.ToDecimal(fila["porcefect"].ToString());
                    Detalle.observ1 = fila["observ1"].ToString();
                    Detalle.observ2 = fila["observ2"].ToString();
                    Detalle.observ3 = fila["observ3"].ToString();
                    Detalle.observ4 = fila["observ4"].ToString();
                    Detalle.observ5 = fila["observ5"].ToString();
                    Detalle.precunit = Convert.ToDecimal(fila["precunit"].ToString());
                    Detalle.bruto = Convert.ToDecimal(fila["bruto"].ToString());
                    Detalle.dscto = Convert.ToDecimal(fila["dscto"].ToString());
                    Detalle.valorventa = Convert.ToDecimal(fila["valorventa"].ToString());
                    Detalle.igvo = Convert.ToDecimal(fila["igvo"].ToString());
                    Detalle.total = Convert.ToDecimal(fila["total"].ToString());

                    Detalle.valorventa = Detalle.valorventa + (Detalle.total - (Detalle.valorventa + Detalle.igvo)); // Origen
                    Detalle.valorventa1 = Detalle.valorventa1 + (Detalle.total1 - (Detalle.valorventa1 + Detalle.igv1)); // S/.
                    Detalle.valorventa2 = Detalle.valorventa2 + (Detalle.total2 - (Detalle.valorventa2 + Detalle.igv2)); // US$

                    Detalle.usuar = VariablesPublicas.Usuar;

                    ListaItems.Add(Detalle);
                }

                BE.ListaItems = ListaItems;
                #endregion

                #region **Save BD
                try
                {
                    if (u_n_opsel == 1)  //Si es nuevo
                    {
                        if (BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE))
                        {
                            seguridadlog("N");
                            if (!nopideimpresion)
                            {
                                string message = "Desea Imprimir Documento Nro: " + local.ToString() + " " + VariablesPublicas.PADL(cboSubdiario.SelectedValue.ToString(), 4, "0") + "/" + txtMes.Text + "-" + txtAsiento.Text + " ...?";
                                string caption = "Impresión";
                                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                                DialogResult result;

                                // Muestra el cuadro de mensaje.
                                result = DevExpress.XtraEditors.XtraMessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                                if (result == DialogResult.Yes)
                                {
                                    Accion(6, "", xnum);
                                }
                            }
                            tmptablacab = null;
                            tmptabladet = null;
                            U_CancelarEdicion(0);
                        }
                    }
                    else if (u_n_opsel == 2)  //Si NO es nuevo
                    {
                        if (BL.Update(VariablesPublicas.EmpresaID.ToString(), BE))
                        {
                            seguridadlog("M");
                            if (!nopideimpresion)
                            {
                                string message = "Desea Imprimir Documento Nro: " + local.ToString() + " " + VariablesPublicas.PADL(cboSubdiario.SelectedValue.ToString(), 4, "0") + "/" + txtMes.Text + "-" + txtAsiento.Text + " ...?";
                                string caption = "Impresión";
                                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                                DialogResult result;

                                // Muestra el cuadro de mensaje.
                                result = DevExpress.XtraEditors.XtraMessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                                if (result == DialogResult.Yes)
                                {
                                    Accion(6, "", xnum);
                                }
                            }
                            tmptablacab = null;
                            tmptabladet = null;
                            U_CancelarEdicion(0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion
            }
        }
        public void seguridadlog(string mTipo)
        {
            //string xclave = VariablesPublicas.EmpresaID + VariablesPublicas.perianio +  cboSubdiario.SelectedValue.ToString() +  txtMes.Text +  txtSerie.Text +  txtNumero.Text;
            string xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio + "/" + cboSubdiario.SelectedValue.ToString() + "/" + txtMes.Text + "-" + txtAsiento.Text;
            try
            {
                tb_co_seguridadlogBL BL = new tb_co_seguridadlogBL();
                tb_co_seguridadlog BE = new tb_co_seguridadlog();

                BE.moduloid = Name;
                BE.clave = xclave;
                BE.cuser = VariablesPublicas.Usuar;
                BE.fecha = DateTime.Now;
                BE.pc = VariablesPublicas.userip;
                BE.accion = mTipo;
                BE.detalle = txtGlosa.Text.Trim() + "/" + cboTipdoc.SelectedValue.ToString() + "-" + txtSerie.Text + "-" + txtNumero.Text + "/" + txtRuc.Text.Trim() + "-" + txtCtactename.Text.Trim();

                BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Validacion()
        {
            object xobjeto = null;
            int lc_cont = 0;
            string xmsgstring = "";
            DataTable tmptabla = new DataTable();
            dynamic xfill = "...";
            if (txtNumero.Text.Trim().Length == 0)
            {
                xmsgstring = xmsgstring + "\r\n" + "Ingrese Número de Comprobante...?";
                xobjeto = txtNumero;
            }
            //if (txtNumFin.Text.Trim().Length == 0)
            //{
            //    xmsgstring = xmsgstring + "\r\n" + "Ingrese Número de Comprobante Final...?";
            //    xobjeto = txtNumFin;
            //}
            if (txtRuc.Text.Trim().Length == 0)
            {
                xmsgstring = xmsgstring + "\r\n" + "Ingrese Cliente...?";
                xobjeto = txtRuc;
            }
            else
            {
                try
                {
                    clienteBL BL = new clienteBL();
                    tb_cliente BE = new tb_cliente();

                    BE.nmruc = txtRuc.Text;
                    if ((BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0]).Rows.Count == 0)
                    {
                        xmsgstring = (xmsgstring + ("\r\n" + "Cliente no existe...?"));
                        xobjeto = txtRuc;
                    }
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (txtTipoventa.Text.Trim().Length == 0)
            {
                xmsgstring = xmsgstring + "\r\n" + "Ingrese Tipo Venta...?";
                xobjeto = txtTipoventa;
            }
            else
            {
            }
            Decimal vmntipocambio = VariablesPublicas.StringtoDecimal(txtTipocambio.Text);
            if (vmntipocambio == 0)
            {
                xmsgstring = xmsgstring + "\r\n" + "Ingrese Tipo de Cambio...?";
                xobjeto = fRegistro;
            }
            if (validaduplicidad())
            {
                xmsgstring = xmsgstring + xfill;
            }
            if ((txtGlosa.Text.Trim()).Trim().Length == 0)
            {
                xmsgstring = xmsgstring + "\r\n" + "Ingrese glosa...?";
                xobjeto = txtGlosa;
            }
            string xcodtmp = "";
            string xcodtmpr = "";
            double canttmp = 0;
            DataTable otabla = new DataTable();
            if (DetFacturacion.Rows.Count == 0)
            {
                xmsgstring = xmsgstring + "\r\n" + "Ingrese detalles al movimiento...?";
                xobjeto = GridExaminar;
            }
            if (xmsgstring.Trim().Length == 0)
            {
                for (lc_cont = 0; lc_cont <= DetFacturacion.Rows.Count - 1; lc_cont++)
                {
                    // Validando Rubro
                    xcodtmp = "";
                    if (!object.ReferenceEquals(DetFacturacion.Rows[lc_cont]["rubroid"], DBNull.Value))
                    {
                        xcodtmpr = DetFacturacion.Rows[lc_cont]["rubroid"].ToString();
                    }
                    if (xcodtmpr.Trim().Length == 0)
                    {
                        xcodtmpr = "...";
                    }
                    if (xcodtmpr.Trim().Length > 0)
                    {
                        try
                        {
                            tb_co_rubroventasBL BL = new tb_co_rubroventasBL();
                            tb_co_rubroventas BE = new tb_co_rubroventas();

                            BE.rubroid = xcodtmpr;
                            tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                            if (tmptabla.Rows.Count == 0)
                            {
                                xmsgstring = (xmsgstring + ("\r\n" + "Rubro de Ventas no Existe...?"));
                                xobjeto = GridExaminar;
                            }
                            if (tmptabla.Rows.Count > 0)
                            {
                                if (tmptabla.Rows[0]["cuentaid"].ToString().Trim().Length != 7)
                                {
                                    xmsgstring = (xmsgstring + ("\r\n" + "Rubro no Asociado a una Cuenta Contable Válida...?"));
                                    xobjeto = GridExaminar;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    // Validando Item
                    if (!object.ReferenceEquals(DetFacturacion.Rows[lc_cont]["productid"], DBNull.Value))
                    {
                        xcodtmp = DetFacturacion.Rows[lc_cont]["productid"].ToString();
                    }
                    else
                    {
                        xcodtmp = "";
                    }
                    if (xcodtmp.Trim().Length > 0)
                    {
                        try
                        {
                            tb_pt_productoBL BL = new tb_pt_productoBL();
                            tb_pt_producto BE = new tb_pt_producto();
                            BE.productid = xcodtmp;
                            otabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                            if (otabla.Rows.Count == 0)
                            {
                                xmsgstring = "Código de Artículo no existe...?";
                                xobjeto = GridExaminar;
                            }
                        }
                        catch (Exception ex)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    // Validando Precios
                    if (!object.ReferenceEquals(DetFacturacion.Rows[lc_cont]["precunit"], DBNull.Value))
                    {
                        canttmp = Convert.ToDouble(DetFacturacion.Rows[lc_cont]["precunit"]);
                    }
                    else
                    {
                        canttmp = 0;
                    }
                    if (canttmp <= 0)
                    {
                        xmsgstring = xmsgstring + "\r\n" + "Ingrese precio...?";
                        xobjeto = GridExaminar;
                    }
                    if (!object.ReferenceEquals(DetFacturacion.Rows[lc_cont]["cantidad"], DBNull.Value))
                    {
                        canttmp = Convert.ToDouble(DetFacturacion.Rows[lc_cont]["cantidad"]);
                    }
                    else
                    {
                        canttmp = 0;
                    }
                    if (canttmp <= 0)
                    {
                        xmsgstring = xmsgstring + "\r\n" + "Ingrese Cantidades...?";
                        xobjeto = GridExaminar;
                    }
                    // Validando Centro de Costo
                    DataTable tmptablarelacionccosto = new DataTable();
                    string vmccosto;
                    vmccosto = "...";
                    if (!(DetFacturacion.Rows[lc_cont]["cencosid"] == DBNull.Value))
                    {
                        if (DetFacturacion.Rows[lc_cont]["cencosid"].ToString().Trim().Length > 0)
                        {
                            vmccosto = DetFacturacion.Rows[lc_cont]["cencosid"].ToString();
                        }
                    }
                    try
                    {
                        centrocostoBL BL = new centrocostoBL();
                        tb_centrocosto BE = new tb_centrocosto();

                        if (xcodtmpr != "...")
                        {
                            BE.cencosdivi = Equivalencias.Mid(tmptabla.Rows[0]["cuentaid"].ToString(), 1, 1);
                            tmptablarelacionccosto = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                        }
                        if (tmptablarelacionccosto.Rows.Count > 0)
                        {
                            int qqqcont;
                            bool zhalladoccosto = false;
                            for (qqqcont = 0; (qqqcont <= (tmptablarelacionccosto.Rows.Count - 1)); qqqcont++)
                            {
                                if (tmptablarelacionccosto.Rows[qqqcont]["cencosid"].ToString() == vmccosto)
                                {
                                    zhalladoccosto = true;
                                    break;
                                }
                            }
                            if (!zhalladoccosto)
                            {
                                xmsgstring = (xmsgstring + ("\r\n" + "Centro de Costo no asociado al Rubro...?"));
                            }
                            else
                            {
                                for (qqqcont = 0; (qqqcont <= (GridExaminar.Rows.Count - 1)); qqqcont++)
                                {
                                    if (GridExaminar.Rows[qqqcont].Cells["asientoitems"].Value == DetFacturacion.Rows[lc_cont]["asientoitems"])
                                    {
                                        if (GridExaminar.CurrentCell == null)
                                        {
                                            GridExaminar.CurrentCell = GridExaminar.Rows[qqqcont].Cells["rubroid"];
                                        }
                                        GridExaminar.CurrentCell.ReadOnly = true;
                                        GridExaminar.CurrentCell = GridExaminar.Rows[qqqcont].Cells["cencosid"];
                                        GridExaminar.BeginEdit(true);
                                        GridExaminar.CurrentCell.ReadOnly = false;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if ((xmsgstring.Trim().Length > 0))
                    {
                        break;
                    }
                }
            }
            if (xmsgstring.Trim().Length == 0)
            {
                if (u_n_opsel == 1 | (W_KEY0001 != txtRuc.Text + cboTipdoc.SelectedValue + txtSerie.Text + txtNumero.Text))
                {
                    tmptabla = null;
                    try
                    {
                        tb_co_VentascabBL BL = new tb_co_VentascabBL();
                        tb_co_Ventascab BE = new tb_co_Ventascab();

                        BE.nmruc = txtRuc.Text;
                        BE.tipdoc = cboTipdoc.SelectedValue.ToString();
                        BE.serdoc = txtSerie.Text;
                        BE.numdoc = txtNumero.Text;

                        tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                        if (!(tmptabla == null))
                        {
                            if (tmptabla.Rows.Count > 0)
                            {
                                xmsgstring = ("Documento Ya registrado en Periodo : " + tmptabla.Rows[0]["perianio"] + " Registro Nº " +
                                             tmptabla.Rows[0]["diarioid"] + "/" +
                                             tmptabla.Rows[0]["perimes"] + "-" + tmptabla.Rows[0]["asiento"]);
                                xobjeto = txtNumero;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            if (xobjeto != null)
            {
                try
                {
                    xobjeto = Focus();
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (xmsgstring.Trim().Length > 0 & xmsgstring.Trim() != xfill)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(xmsgstring, "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (xmsgstring.Trim().Length == 0)
            {
                if (!PuedeEditarEliminar("Grabar Nuevo Registro", VariablesPublicas.PADL(fRegistro.Value.Month.ToString(), 2, "0")))
                {
                    xmsgstring = "...";
                }
            }
            if (xmsgstring.Trim().Length == 0)
            {
                return VariablesPublicas.U_ValidaFechaRegistroProvision(VariablesPublicas.perianio, txtMes.Text, fRegistro.Value);
            }
            else
            {
                return xmsgstring.Trim().Length == 0;
            }
        }
        private bool validaduplicidad()
        {
            bool zduplicado = false;
            string xdesartic = "";
            // duplicidad por codigo  + pedido
            bool zsalirforprincipal = false;
            string xcodartic = "";
            int ncont2 = 0;
            int ncontador = 0;
            object xartictmp = "";

            for (ncontador = 0; ncontador <= GridExaminar.RowCount - 1; ncontador++)
            {
                xcodartic = "";
                if ((!object.ReferenceEquals(GridExaminar.Rows[ncontador].Cells["productid"].Value, DBNull.Value)))
                {
                    xcodartic = GridExaminar.Rows[ncontador].Cells["productid"].Value.ToString();
                    xdesartic = xdesartic + " " + GridExaminar.Rows[ncontador].Cells["productname"].Value.ToString();
                    if (!object.ReferenceEquals(GridExaminar.Rows[ncontador].Cells["productid"].Value, DBNull.Value))
                    {
                        xcodartic = xcodartic + GridExaminar.Rows[ncontador].Cells["productid"].Value.ToString();
                    }
                }
                if ((!object.ReferenceEquals(GridExaminar.Rows[ncontador].Cells["numguia"].Value, DBNull.Value)))
                {
                    xcodartic = xcodartic + GridExaminar.Rows[ncontador].Cells["numguia"].Value;
                    xdesartic = xdesartic + " GRM " + GridExaminar.Rows[ncontador].Cells["numguia"].Value;
                }

                if (xcodartic.Trim().Length > 0)
                {
                    for (ncont2 = 0; ncont2 <= GridExaminar.RowCount - 1; ncont2++)
                    {
                        if (ncont2 != ncontador)
                        {
                            if ((!object.ReferenceEquals(GridExaminar.Rows[ncont2].Cells["productid"].Value, DBNull.Value)))
                            {
                                xartictmp = GridExaminar.Rows[ncont2].Cells["productid"].Value;
                            }
                            else
                            {
                                xartictmp = "";
                            }
                            if ((!object.ReferenceEquals(GridExaminar.Rows[ncont2].Cells["tallacolor"].Value, DBNull.Value)))
                            {
                                xartictmp = xartictmp + GridExaminar.Rows[ncont2].Cells["tallacolor"].Value.ToString();
                            }
                            if ((!object.ReferenceEquals(GridExaminar.Rows[ncont2].Cells["numguia"].Value, DBNull.Value)))
                            {
                                xartictmp = xartictmp + GridExaminar.Rows[ncont2].Cells["numguia"].Value.ToString();
                            }
                            xartictmp = xartictmp.ToString().Trim();
                            xcodartic = xcodartic.Trim();
                            if (xcodartic.Length > 0)
                            {
                                if (xartictmp.ToString() == xcodartic.ToString())
                                {
                                    if (DevExpress.XtraEditors.XtraMessageBox.Show("Duplicado Artículo /GRM "
                                                    + (xcodartic.Trim() + (" - "
                                                    + (xdesartic.Trim() + ('\r' + "Desea continuar grabación...?")))), "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                    {
                                        zduplicado = false;
                                    }
                                    else
                                    {
                                        zduplicado = true;
                                    }
                                    zsalirforprincipal = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (zduplicado)
                    {
                        break;
                    }
                }
                if (zsalirforprincipal)
                {
                    break;
                }
            }
            return zduplicado;
        }

        private void actualizatipocambio()
        {
            if (u_n_opsel == 0)
            {
                return;
            }
            string xfecha = null;
            if (fechaRefer.ShowCheckBox & !(fechaRefer.Text.ToString() == "01/01/1900"))
            {
                xfecha = Convert.ToDateTime(fechaRefer.Text).ToString();
            }
            else
            {
                xfecha = Convert.ToDateTime(fRegistro.Text).ToString();
            }
            tipocambioBL BL = new tipocambioBL();
            tb_tipocambio BE = new tb_tipocambio();

            BE.fecha = Convert.ToDateTime(xfecha);
            DataTable tcambio = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

            if (tcambio.Rows.Count > 0)
            {
                txtTipocambio.Text = tcambio.Rows[0]["venta"].ToString();
            }
            else
            {
                txtTipocambio.Text = "0.00";
                //DevExpress.XtraEditors.XtraMessageBox.Show("Actualice el Tipo de Cambio?", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void conviertemoneda()
        {
            if (u_n_opsel > 0 & zinteractivechange)
            {
                decimal tcambio = VariablesPublicas.StringtoDecimal(txtTipocambio.Text);
                //int lccont = 0;
                //if (cboMoneda.SelectedValue.ToString() == "1")
                //{
                //    for (lccont = 0; lccont <= DetFacturacion.Rows.Count - 1; lccont++)
                //    {
                //DetFacturacion.Rows[lccont]["preun_3a"] *= tcambio;
                //DetFacturacion.Rows[lccont]["vvta_3a"] *= tcambio;
                //DetFacturacion.Rows[lccont]["igv_3a"] *= tcambio;
                //DetFacturacion.Rows[lccont]["tot_3a"] *= tcambio;
                //    }
                //}
                //else
                //{
                //    for (lccont = 0; lccont <= DetFacturacion.Rows.Count - 1; lccont++)
                //    {
                //        if (tcambio == 0)
                //        {
                //DetFacturacion.Rows(lccont).Item("preun_3a") = 0;
                //DetFacturacion.Rows(lccont).Item("vvta_3a") = 0;
                //DetFacturacion.Rows(lccont).Item("igv_3a") = 0;
                //DetFacturacion.Rows(lccont).Item("tot_3a") = 0;
                //}
                //else
                //{
                //DetFacturacion.Rows(lccont).Item("preun_3a") /= tcambio;
                //DetFacturacion.Rows(lccont).Item("vvta_3a") /= tcambio;
                //DetFacturacion.Rows(lccont).Item("igv_3a") /= tcambio;
                //DetFacturacion.Rows(lccont).Item("tot_3a") /= tcambio;
                //        }
                //    }
                //}
                totalizar();
                GridExaminar.Refresh();
            }
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0 & !sw_novaluechange)
            {
                conviertemoneda();
            }

            if ((u_n_opsel > 0))
            {
                if (cboMoneda.Text.Substring(0, 1) == "1")
                {
                    lblMoneda.Text = "S/.";
                    lblMoneda.ForeColor = Color.Blue;
                }
                else
                {
                    lblMoneda.Text = "US$";
                    lblMoneda.ForeColor = Color.Green;
                }
                refrescacontroles();
            }
        }

        private void Accion(int Naccion, string xmes, string xnumero)
        {
            switch (Naccion)
            {
                case 1:
                    UltimoNumeroRegistro();
                    procesanumero();
                    break;
                case 2:
                    CargaDatos();
                    u_n_opsel = 2;
                    refrescacontroles();
                    break;
                case 3:
                    //eliminar
                    DataTable tmptabla = new DataTable();
                    tb_co_VentascabBL BL = new tb_co_VentascabBL();
                    tb_co_Ventascab BE = new tb_co_Ventascab();

                    BE.perianio = VariablesPublicas.perianio;
                    BE.perimes = VariablesPublicas.PADL(txtMes.Text.Trim(), 2, "0");
                    BE.moduloid = modulo.ToString();
                    BE.local = local.ToString();
                    BE.diarioid = cboSubdiario.SelectedValue.ToString();
                    BE.asiento = VariablesPublicas.PADL(txtAsiento.Text.Trim(), 6, "0");

                    tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                    if (tmptabla.Rows.Count > 0)
                    {
                        string message = "Desea eliminar Registro de Ventas " + tmptabla.Rows[0]["perianio"] + "/" + tmptabla.Rows[0]["diarioid"] + "/" + tmptabla.Rows[0]["perimes"] + "-" + tmptabla.Rows[0]["asiento"] + " ...?";
                        string caption = "Mensaje del Sistema";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;
                        // Muestra el cuadro de mensaje.
                        result = DevExpress.XtraEditors.XtraMessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                            tb_co_VentasBL BL1 = new tb_co_VentasBL();
                            tb_co_Ventas BE1 = new tb_co_Ventas();

                            BE1.perianio = VariablesPublicas.perianio;
                            BE1.perimes = txtMes.Text;
                            BE1.moduloid = modulo.ToString();
                            BE1.local = local.ToString();
                            BE1.diarioid = cboSubdiario.SelectedValue.ToString();
                            BE1.asiento = VariablesPublicas.PADL(txtAsiento.Text.Trim(), 6, "0");
                            //if (BL1.Delete(VariablesPublicas.EmpresaID.ToString(), BE1))
                            //{
                            //    txtAsiento.Focus();
                            //}
                            //else
                            //{
                            //    Frm_Class.ShowError(BL1.Sql_Error, this);
                            //}
                        }
                    }
                    CargaDatos();
                    break;
                case 5:
                    CargaDatos();
                    refrescacontroles();
                    break;
                //case 6:
                //    //Impresion
                //    ReportesContabilidad.Frm_ReporteVouchers frm = new ReportesContabilidad.Frm_ReporteVouchers();
                //    //frm._tipComprobante = VariablesPublicas.CodVoucherVentas;
                //    frm._tipComprobante = cboSubdiario.SelectedValue.ToString();
                //    frm._nroComprobante = (xmes.Trim().Length == 0 ? txtMes.Text : xmes) + (xnumero.Trim().Length == 0 ? txtAsiento.Text : xnumero);
                //    frm._xModulo = modulo.ToString();
                //    frm._xLocal = local.ToString();
                //    frm._tipoOperacion = "1";
                //    frm.Owner = this;
                //    frm.ShowInTaskbar = false;
                //    frm.ShowDialog();
                //    break;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AyudaArticulos()
        {
            Ayudas.Frm_AyudaArticulo frmayuda = new Ayudas.Frm_AyudaArticulo();
            frmayuda.Owner = this;
            frmayuda._ActivaAlmacen = true;
            frmayuda.CodAlmacen = "";
            frmayuda.Owner = this;
            frmayuda.PasaArticulos = RecibeCodArticulos;
            frmayuda.ShowDialog();

        }
        private void RecibeCodArticulos(string codigo, string descripcion, string dumd, DataTable Tablaarticulos)
        {
            if (codigo.Trim().Length > 0)
            {
                GridExaminar.Rows[GridExaminar.CurrentCell.RowIndex].Cells["linea_3a"].Value = codigo;
            }
        }
        private void ValidaArticulos()
        {
            sw_novaluechange = true;
            DataTable tmpcursor = new DataTable();
            Int16 lc_cont = default(Int16);
            string VMNROITEM = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["nro_item"].Value.ToString();
            string xcodartic = "..";
            if ((!object.ReferenceEquals(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["linea_3a"].Value, DBNull.Value)))
            {
                xcodartic = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["linea_3a"].Value.ToString();
            }
            //tmpcursor = ocapa.cag1700_consulta(xcodartic, "", 1, "", "", "", "", "", 0, "", "", "");
            for (lc_cont = 0; lc_cont <= DetFacturacion.Rows.Count - 1; lc_cont++)
            {
                if (DetFacturacion.Rows[lc_cont]["nro_item"].ToString() == VMNROITEM)
                {
                    if (tmpcursor.Rows.Count == 0 | xcodartic.Trim().Length == 0)
                    {
                        DetFacturacion.Rows[lc_cont]["linea_3a"] = "";
                        DetFacturacion.Rows[lc_cont]["darticulo"] = "";
                        DetFacturacion.Rows[lc_cont]["dunialm"] = "";
                        DetFacturacion.Rows[lc_cont]["unid_3a"] = "";
                    }
                    else
                    {
                        DetFacturacion.Rows[lc_cont]["linea_3a"] = tmpcursor.Rows[0]["linea_17"].ToString().Trim();
                        DetFacturacion.Rows[lc_cont]["darticulo"] = tmpcursor.Rows[0]["nomb_17"];
                        DetFacturacion.Rows[lc_cont]["dunialm"] = tmpcursor.Rows[0]["dunimed"];
                        DetFacturacion.Rows[lc_cont]["unid_3a"] = tmpcursor.Rows[0]["unid_17"];
                    }
                    break;
                }
            }
            GridExaminar.Refresh();
            sw_novaluechange = false;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Accion(6, "", "");
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            AyudaRegVentas(1);
        }

        private void AyudaRegVentas(int nivel)
        {
            Frm_AyudaRegistroventas Form = new Frm_AyudaRegistroventas();
            Form._Mes = (nivel == 1 ? txtMes.Text.Trim() : "");
            Form._PasaRegVentas = RegVentas;
            Form.Owner = this;
            Form.ShowDialog();
        }
        private void RegVentas(string regmes, string regdiario, string regnumero, string detalle)
        {
            txtAsiento.Text = regnumero;
            txtMes.Text = regmes;
            sELECCIONAaYUDA = true;
            procesanumero();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (1 == 1)
            {
                Frm_Identificacion xxxform = new Frm_Identificacion();
                xxxform.TipoProceso = "CO02"; //Eliminar Asiento Contable
                xxxform.Owner = this;
                xxxform.PasaIdentificacionDelegado = PasaIdentificacionXX;
                xxxform.ShowDialog();
            }
            else
            {
                //Frm_RegistroVentas OFORM = new Frm_RegistroVentas();
                //VariablesPublicas.ExistForm(this, OFORM, true);
            }
            //if (PuedeEditarEliminar("ELIMINAR", VariablesPublicas.PADL(fRegistro.Value.Month.ToString(), 2, "0")))
            //{
            //    Accion(3, "", "");
            //}
        }
        private void PasaIdentificacionXX(string CodUSer)
        {
            //Aca Llamar a Eliminar Asiento Contable
            //DataTable xData = new DataTable();
            if (CodUSer.Trim().Length > 0)
            {
                if (PuedeEditarEliminar("ELIMINAR", VariablesPublicas.PADL(fRegistro.Value.Month.ToString(), 2, "0")))
                {
                    seguridadlog("E");
                    Accion(3, "", "");
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Usuario No Autorizado... Consulte a Sistemas?", "BapSoft");
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (u_n_opsel == 0)
            {
                Seguridadlog.FrmSeguridad oform = new Seguridadlog.FrmSeguridad();
                //string xclave = VariablesPublicas.perianio +  txtMes.Text +  txtNumero.Text;
                //string xclave = VariablesPublicas.EmpresaID + VariablesPublicas.perianio +  cboSubdiario.SelectedValue.ToString() +  txtMes.Text +  txtSerie.Text +  txtNumero.Text;
                string xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio + "/" + cboSubdiario.SelectedValue.ToString() + "/" + txtMes.Text + "-" + txtAsiento.Text;
                oform._Nombre = Name;
                oform._ClaveForm = xclave;
                oform.Owner = this;
                oform.ShowDialog();
            }
        }

        private void procesanumero()
        {
            bool zprocede = false;
            if (VariablesPublicas.StringtoDecimal(txtMes.Text) > 0 & VariablesPublicas.StringtoDecimal(txtAsiento.Text) > 0)
            {
                zprocede = true;
            }
            if (zprocede)
            {
                txtAsiento.Text = VariablesPublicas.PADL(txtAsiento.Text.Trim(), txtAsiento.MaxLength, "0");
                CargaDatos();
                refrescacontroles();
                if (CabFacturacion.Rows.Count == 0)
                {
                    u_n_opsel = 1;
                    refrescacontroles();
                    blanquear(true);
                    actualizatipocambio();
                    cboTipdoc.Focus();
                }
            }
            else
            {
                if (VariablesPublicas.StringtoDecimal(txtMes.Text) == 0)
                {
                    txtMes.Text = VariablesPublicas.PADL(DateTime.Now.Month.ToString(), 2, "0");
                }
                if (VariablesPublicas.StringtoDecimal(txtAsiento.Text) == 0)
                {
                    UltimoNumeroRegistro();
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Accion(1, "", "");
        }

        private void txtPigv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("\t");
            }
        }
        private void txtPigv_GotFocus(object sender, System.EventArgs e)
        {
            j_String = txtPigv.Text;
        }
        private void txtPigv_LostFocus(System.Object sender, System.EventArgs e)
        {
            if (!(j_String == txtPigv.Text) & u_n_opsel > 0)
            {
                decimal numero = default(decimal);
                numero = VariablesPublicas.StringtoDecimal(txtPigv.Text);
                txtPigv.Text = System.String.Format(numero.ToString(), "###.00");
                totalizarItem();
            }
        }

        private void cboMoneda_KeyDown(object sender, KeyEventArgs e)
        {
            ProcesaCombo(cboMoneda, e);
        }

        private void Frm_RegistroVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (u_n_opsel > 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Finalice edición para cerrar formulario", "BapSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void UltimoNumeroRegistro()
        {
            tb_co_VentascabBL BL = new tb_co_VentascabBL();
            tb_co_Ventascab BE = new tb_co_Ventascab();

            BE.perianio = VariablesPublicas.perianio;
            BE.perimes = txtMes.Text;
            BE.moduloid = modulo.ToString();//modulo.ToString();
            BE.local = local.ToString();//local.ToString();
            BE.diarioid = cboSubdiario.Text.Substring(0, 4);

            try
            {
                txtAsiento.Text = BL.GetAsientoNume(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0].Rows[0]["asiento"].ToString();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Controles para la grilla Detalle
        private void GridExaminar_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if ((GridExaminar.CurrentRow != null))
            {
                if ((GridExaminar.Columns[e.ColumnIndex].Name.ToUpper() == "rubroid".ToUpper()))
                {
                    j_RUBRO = GridExaminar.CurrentCell.Value.ToString();
                }
                if ((GridExaminar.Columns[e.ColumnIndex].Name.ToUpper() == "afectoigvid".ToUpper()))
                {
                    j_Destino = GridExaminar.CurrentCell.Value.ToString();
                }
                if ((GridExaminar.Columns[e.ColumnIndex].Name.ToUpper() == "cencosid".ToUpper()))
                {
                    j_Ccosto = GridExaminar.CurrentCell.Value.ToString();
                }
                if (GridExaminar.Columns[e.ColumnIndex].Name.ToUpper() == "num_op")
                {
                    j_widOP = GridExaminar.CurrentCell.Value.ToString();
                }
                if (GridExaminar.Columns[e.ColumnIndex].Name.ToUpper() == "tippedido")
                {
                    j_Pedido = GridExaminar.CurrentCell.Value.ToString();
                }
                if (GridExaminar.Columns[e.ColumnIndex].Name.ToUpper() == "colortalla".ToUpper())
                {
                    j_colORTALlA = GridExaminar.CurrentCell.Value.ToString();
                }
                if ((GridExaminar.Columns[e.ColumnIndex].Name.ToUpper() == "tipguia".ToUpper()))
                {
                    j_ctipdoc_3a = GridExaminar.CurrentCell.Value.ToString();
                }
                if ((GridExaminar.Columns[e.ColumnIndex].Name.ToUpper() == "serguia".ToUpper()))
                {
                    j_cserdoc_3a = GridExaminar.CurrentCell.Value.ToString();
                }
                if ((GridExaminar.Columns[e.ColumnIndex].Name.ToUpper() == "numguia".ToUpper()))
                {
                    j_cnumdoc_3a = GridExaminar.CurrentCell.Value.ToString();
                }
            }
        }
        private void GridExaminar_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((GridExaminar.CurrentRow != null) & !sw_novaluechange)
            {
                sw_novaluechange = true;
                if (GridExaminar.Columns[e.ColumnIndex].Name.ToUpper() == "productid".ToUpper())
                {
                    ValidaArticulos();
                }
                if (GridExaminar.Columns[e.ColumnIndex].Name.ToUpper() == "colortalla".ToUpper())
                {
                    ValidaColorTALLA();
                }
                if (GridExaminar.Columns[e.ColumnIndex].Name.ToUpper() == "afectoigvid".ToUpper())
                {
                    validaTipoIgvDetalle();
                }
                if (GridExaminar.Columns[e.ColumnIndex].Name.ToUpper() == "pdscto".ToUpper())
                {
                    if (object.ReferenceEquals(GridExaminar.Rows[e.RowIndex].Cells["pdscto"].Value, DBNull.Value))
                    {
                        GridExaminar.Rows[e.RowIndex].Cells["pdscto"].Value = 0;
                    }
                    totalizarItem();
                }
                if (GridExaminar.Columns[e.ColumnIndex].Name.ToUpper() == "precunit".ToUpper())
                {
                    if (object.ReferenceEquals(GridExaminar.Rows[e.RowIndex].Cells["precunit"].Value, DBNull.Value))
                    {
                        GridExaminar.Rows[e.RowIndex].Cells["precunit"].Value = 0;
                    }
                    totalizarItem();
                }
                if (GridExaminar.Columns[e.ColumnIndex].Name.ToUpper() == "cantidad".ToUpper())
                {
                    if (object.ReferenceEquals(GridExaminar.Rows[e.RowIndex].Cells["cantidad"].Value, DBNull.Value))
                    {
                        GridExaminar.Rows[e.RowIndex].Cells["cantidad"].Value = 0;
                    }
                    totalizarItem();
                }
                if (GridExaminar.Columns[e.ColumnIndex].Name.ToUpper() == "valorventa".ToUpper())
                {
                    totalizaritemigv();
                }
                if (GridExaminar.Columns[e.ColumnIndex].Name.ToUpper() == "igvo".ToUpper())
                {
                    totalizaritemtotal();
                }
                if (GridExaminar.Columns[e.ColumnIndex].Name.ToUpper() == "rubroid".ToUpper())
                {
                    ValidarubroVenta();
                }
                if (GridExaminar.Columns[e.ColumnIndex].Name.ToUpper() == "cencosid".ToUpper())
                {
                    validaCentroCosto();
                }

                if (GridExaminar.Columns[e.ColumnIndex].Name.ToUpper() == "num_op".ToUpper())
                {
                    validaOp();
                }
                if (GridExaminar.Columns[e.ColumnIndex].Name.ToUpper() == "numpedido".ToUpper())
                {
                    ValidaPedido();
                }
                if (GridExaminar.Columns[e.ColumnIndex].Name.ToUpper() == "tipguia".ToUpper())
                {
                    validaTipoDocumento();
                }
                if (GridExaminar.Columns[e.ColumnIndex].Name.ToUpper() == "serguia".ToUpper())
                {
                    validaSerieDocumento();
                }
                if (GridExaminar.Columns[e.ColumnIndex].Name.ToUpper() == "numguia".ToUpper())
                {
                    validaNUmeroDocumento();
                }

                //if (GridExaminar.Columns[e.ColumnIndex].Name.ToUpper() == "numguia".ToUpper())
                //{
                //    string xvmguia = "";
                //    if ((!object.ReferenceEquals(GridExaminar.Rows[ GridExaminar.CurrentRow.Index].Cells["numguia"].Value, DBNull.Value)))
                //    {
                //        xvmguia =  GridExaminar.Rows[ GridExaminar.CurrentRow.Index].Cells["numguia"].Value.ToString();
                //    }
                //    if (xvmguia.Trim().Length > 0)
                //    {
                //         GridExaminar.Rows[ GridExaminar.CurrentRow.Index].Cells["numguia"].Value = VariablesPublicas.JustificarDocumento(xvmguia, 1, 10, true);
                //    }
                //}
            }
            sw_novaluechange = false;
        }
        private void GridExaminar_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (GridExaminar.Columns[GridExaminar.CurrentCell.ColumnIndex].Name.ToUpper() == "productid".ToUpper())
            {
                txtCArti = (TextBox)e.Control;
                txtCArti.MaxLength = 25;
                txtCArti.CharacterCasing = CharacterCasing.Upper;
                txtCArti.Text.Trim();
                e.Control.KeyDown += CapturarTeclaGRID;
            }
            if (GridExaminar.Columns[GridExaminar.CurrentCell.ColumnIndex].Name.ToUpper() == "rubroid".ToUpper())
            {
                txtCArti = (TextBox)e.Control;
                txtCArti.MaxLength = 4;
                txtCArti.CharacterCasing = CharacterCasing.Upper;
                txtCArti.Text.Trim();
                e.Control.KeyDown += CapturarTeclaGRID;
            }
            if ((GridExaminar.Columns[GridExaminar.CurrentCell.ColumnIndex].Name.ToUpper() == "afectoigvid".ToUpper()))
            {
                txtCArti = ((TextBox)(e.Control));
                txtCArti.MaxLength = 1;
                txtCArti.CharacterCasing = CharacterCasing.Upper;
                txtCArti.Text.Trim();
                //e.Control.KeyDown += CapturarTeclaGRID;
            }
            if ((GridExaminar.Columns[GridExaminar.CurrentCell.ColumnIndex].Name.ToUpper() == "cencosid".ToUpper()))
            {
                txtCArti = ((TextBox)(e.Control));
                txtCArti.MaxLength = 5;
                txtCArti.CharacterCasing = CharacterCasing.Upper;
                txtCArti.Text.Trim();
                e.Control.KeyDown += CapturarTeclaGRID;
            }
            if (GridExaminar.Columns[GridExaminar.CurrentCell.ColumnIndex].Name.ToUpper() == "numpedido".ToUpper())
            {
                txtCArti = (TextBox)e.Control;
                txtCArti.MaxLength = 10;
                txtCArti.CharacterCasing = CharacterCasing.Upper;
                txtCArti.Text.Trim();
                e.Control.KeyDown += CapturarTeclaGRID;
            }
            if ((GridExaminar.Columns[GridExaminar.CurrentCell.ColumnIndex].Name.ToUpper() == "tipguia".ToUpper()))
            {
                txtCArti = ((TextBox)(e.Control));
                txtCArti.MaxLength = 2;
                txtCArti.CharacterCasing = CharacterCasing.Upper;
                txtCArti.Text.Trim();
                e.Control.KeyDown += CapturarTeclaGRID;
            }
            //if (GridExaminar.Columns[GridExaminar.CurrentCell.ColumnIndex].Name.ToUpper() == "numguia".ToUpper())
            //{
            //    txtCArti = (TextBox)e.Control;
            //    txtCArti.MaxLength = 10;
            //    txtCArti.CharacterCasing = CharacterCasing.Upper;
            //    txtCArti.Text.Trim();
            //    e.Control.KeyDown += CapturarTeclaGRID;
            //}
            if (GridExaminar.Columns[GridExaminar.CurrentCell.ColumnIndex].Name.ToUpper() == "tallacolor".ToUpper())
            {
                txtCArti = (TextBox)e.Control;
                txtCArti.MaxLength = 6;
                txtCArti.CharacterCasing = CharacterCasing.Upper;
                txtCArti.Text.Trim();
                e.Control.KeyDown += CapturarTeclaGRID;
            }
            _NameCOlumna = GridExaminar.Columns[GridExaminar.CurrentCell.ColumnIndex].Name.ToUpper();
        }
        private void GridExaminar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((GridExaminar.CurrentCell != null))
                {
                    if (GridExaminar.Columns[GridExaminar.CurrentCell.ColumnIndex].Name.ToUpper() == "COL_OBS")
                    {
                        muestraobservaciones();
                    }
                    else
                    {
                        if (GridExaminar.Columns[GridExaminar.CurrentCell.ColumnIndex].Name.ToUpper() == "numguia".ToUpper())
                        {
                            btnAddfila_Click(sender, e);
                        }
                    }
                }
            }   // Ayudas
            if (e.KeyCode == Keys.F1 & u_n_opsel > 0)
            {
                if ((GridExaminar.CurrentCell != null))
                {
                    if (GridExaminar.CurrentCell.ReadOnly == false)
                    {   // Artículos
                        if (GridExaminar.Columns[GridExaminar.CurrentCell.ColumnIndex].Name.ToUpper() == "productid".ToUpper())
                        {
                            AyudaArticulos();
                        }
                        if (GridExaminar.Columns[GridExaminar.CurrentCell.ColumnIndex].Name.ToUpper() == "tallacolor".ToUpper())
                        {
                            ayudaColorTallaOP();
                        }
                        if (GridExaminar.Columns[GridExaminar.CurrentCell.ColumnIndex].Name.ToUpper() == "rubroid".ToUpper())
                        {
                            AyudaRubroVentas();
                        }
                        if (GridExaminar.Columns[GridExaminar.CurrentCell.ColumnIndex].Name.ToUpper() == "afectoigvid".ToUpper())
                        {
                            AyudaTipoIgvDetalle();
                        }
                        if (GridExaminar.Columns[GridExaminar.CurrentCell.ColumnIndex].Name.ToUpper() == "cencosid".ToUpper())
                        {
                            AyudaCentroCosto();
                        }
                        if (GridExaminar.Columns[GridExaminar.CurrentCell.ColumnIndex].Name.ToUpper() == "num_op".ToUpper())
                        {
                            AyudaOP();
                        }
                        if (GridExaminar.Columns[GridExaminar.CurrentCell.ColumnIndex].Name.ToUpper() == "tipguia".ToUpper())
                        {
                            AyudaTipoDocumento();
                        }
                    }
                }
            }
        }
        private void GridExaminar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (VariablesPublicas.PulsaAyudaArticulos)
            {
                if (_NameCOlumna.ToUpper() == "rubroid".ToUpper())
                {
                    AyudaRubroVentas();
                }
                else
                {
                    if (GridExaminar.Columns[GridExaminar.CurrentCell.ColumnIndex].Name.ToUpper() == "tallacolor".ToUpper())
                    {
                        ayudaColorTallaOP();
                    }
                    else
                    {
                        if (_NameCOlumna.ToUpper() == "afectoigvid".ToUpper())
                        {
                            AyudaTipoIgvDetalle();
                        }
                        else
                        {
                            if (_NameCOlumna.ToUpper() == "num_op".ToUpper())
                            {
                                AyudaOP();
                            }
                            else
                            {
                                if (_NameCOlumna.ToUpper() == "numpedido".ToUpper())
                                {
                                    AyudaPedidos();
                                }
                                else
                                {
                                    if (1 == 1)
                                    {
                                        AyudaArticulos();
                                    }
                                }
                            }
                        }
                    }
                }
                if (_NameCOlumna.ToUpper() == "cencosid".ToUpper())
                {
                    AyudaCentroCosto();
                }
                if (_NameCOlumna.ToUpper() == "tipguia".ToUpper())
                {
                    AyudaTipoDocumento();
                }
            }
            VariablesPublicas.PulsaAyudaArticulos = false;
            if ((GridExaminar.CurrentCell != null))
            {
                int nfila = GridExaminar.CurrentCell.RowIndex;
                int ncolumna = GridExaminar.CurrentCell.ColumnIndex;
                DetFacturacion.AcceptChanges();
                try
                {
                    GridExaminar.CurrentCell = GridExaminar.Rows[nfila].Cells[ncolumna];
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void GridExaminar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GridExaminar.RowCount > 0)
            {
                if (GridExaminar.Columns[e.ColumnIndex].Name.ToUpper() == "COL_OBS".ToUpper())
                {
                    muestraobservaciones();
                    refrescacontroles();
                }
            }
        }
        private void GridExaminar_SelectionChanged(object sender, EventArgs e)
        {
            txtDescripcampo.Text = "";
            if ((GridExaminar.CurrentCell != null))
            {
                if (GridExaminar.Columns[GridExaminar.CurrentCell.ColumnIndex].Name.ToUpper() == "rubroid".ToUpper())
                {
                    ValidarubroVenta();
                    // txtDescripcampo.Text =  GridExaminar.Rows[ GridExaminar.CurrentCell.RowIndex].Cells["DRUBRO"].Value.ToString();
                }
                if ((GridExaminar.Columns[GridExaminar.CurrentCell.ColumnIndex].Name.ToUpper() == "afectoigvid".ToUpper()))
                {
                    validaTipoIgvDetalle();
                    // txtDescripcampo.Text =  GridExaminar.Rows[ GridExaminar.CurrentCell.RowIndex].Cells["ddestino"].Value.ToString();
                }
                if ((GridExaminar.Columns[GridExaminar.CurrentCell.ColumnIndex].Name.ToUpper() == "cencosid".ToUpper()))
                {
                    validaCentroCosto();
                    // txtdescripcampo.Text =  GridExaminar.Rows[ GridExaminar.CurrentCell.RowIndex].Cells["cencosname"].Value.ToString();
                }
                if ((GridExaminar.Columns[GridExaminar.CurrentCell.ColumnIndex].Name.ToUpper() == "tipguia".ToUpper()))
                {
                    validaTipoDocumento();
                    // txtdescripcampo.Text =  GridExaminar.Rows[ GridExaminar.CurrentCell.RowIndex].Cells["descripcion"].Value.ToString();
                }
                refrescacontroles();
            }
        }
        private void muestraobservaciones()
        {
            string xnroitem = "---";
            Int16 lc_cont = 0;
            string xdesartic = "";
            string xcodartic = "";
            string vmop = "";
            if (!(GridExaminar.CurrentRow == null))
            {
                if (!(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["num_op"].Value == DBNull.Value))
                {
                    vmop = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["num_op"].Value.ToString();
                }
                if (!(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["rubroid"].Value == DBNull.Value))
                {
                    xcodartic = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["rubroid"].Value.ToString();
                    ValidarubroVenta();
                    xdesartic = txtDescripcampo.Text;
                }
                if (!(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["drubro"].Value == DBNull.Value))
                {
                    xdesartic =  GridExaminar.Rows[ GridExaminar.CurrentRow.Index].Cells["drubro"].Value.ToString();                 
                }
            }
            if (!(GridExaminar.CurrentCell == null))
            {
                xnroitem = GridExaminar.Rows[GridExaminar.CurrentCell.RowIndex].Cells["asientoitems"].Value.ToString();
            }
            tmptabla = DetFacturacion.Clone();
            for (lc_cont = 0; (lc_cont <= (DetFacturacion.Rows.Count - 1)); lc_cont++)
            {
                if ((DetFacturacion.Rows[lc_cont]["asientoitems"].ToString().Trim() == xnroitem))
                {
                    tmptabla.ImportRow(DetFacturacion.Rows[lc_cont]);
                    break;
                }
            }
            //Frm_RegistroVentasObs oform = new Frm_RegistroVentasObs();
            //oform._TablaDetalle = tmptabla;
            //oform._Op = vmop;
            //oform._pcgcopy = pcgcopy;
            //oform._codRubro = xcodartic;
            //oform._DRubro = xdesartic;
            //oform.DelegadoEjecucionXXX = Recibetabla;
            //oform.Owner = this;
            //oform.u_n_opsel = u_n_opsel;
            //oform.ShowDialog();
        }

        public void Recibetabla(DataTable Tabla)
        {
            DetFacturacion = Tabla;
            GridExaminar.Refresh();
        }

        public static KeyEventHandler CapturarTeclaGRID
        {
            get
            {
                KeyEventHandler keypress = new KeyEventHandler(LecturaTecla);
                return keypress;
            }
        }
        private static void LecturaTecla(System.Object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                VariablesPublicas.PulsaAyudaArticulos = true;
                SendKeys.Send("\t");
            }
            if (e.KeyCode == Keys.F2)
            {
                VariablesPublicas.PulsaTeclaF2 = true;
                SendKeys.Send("\t");
            }
            if (e.KeyCode == Keys.F3)
            {
                VariablesPublicas.PulsaTeclaF3 = true;
                SendKeys.Send("\t");
            }
        }
        private static void PintaEncabezados(DataGridView Grilla)
        {
            int contcolumnas = 0;
            for (contcolumnas = 0; contcolumnas < Grilla.ColumnCount; contcolumnas++)
            {
                if (Grilla.Columns[contcolumnas].Visible == true)
                {
                    Grilla.Columns[contcolumnas].HeaderCell.Style.BackColor = Color.Gray;
                    Grilla.Columns[contcolumnas].HeaderCell.Style.ForeColor = Color.WhiteSmoke;
                    Grilla.Columns[contcolumnas].HeaderCell.Style.Font = new Font("Tahoma", 7, FontStyle.Bold);
                    //Grilla.Columns[contcolumnas].HeaderCell.Style.Font = new Font("Tahoma", 8);
                }
            }
        }

        private void AyudaTipoDocumento()
        {
            Ayudas.Frm_AyudaTipoDocumentos frmayuda = new Ayudas.Frm_AyudaTipoDocumentos();
            frmayuda.Owner = this;
            //frmayuda._LpTipoDocu = GlobalVars.GetInstance.TipDocusAlmacenes;
            frmayuda._PasaValor = RecibeTipoDocumento;
            frmayuda.ShowDialog();
        }
        private void RecibeTipoDocumento(string codigo, string descripcion)
        {
            if (codigo.Trim().Length > 0)
            {
                GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["tipguia"].Value = codigo;
            }
        }
        private void validaTipoDocumento()
        {
            sw_novaluechange = true;
            string vmxtipdoc = "";
            if (!(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["tipguia"].Value == DBNull.Value))
            {
                vmxtipdoc = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["tipguia"].Value.ToString();
            }
            if ((vmxtipdoc.Trim().Length == 0))
            {
                return;
            }
            if ((VariablesPublicas.StringtoDecimal(vmxtipdoc) > 0))
            {
                vmxtipdoc = VariablesPublicas.PADL(vmxtipdoc, 2, "0");
            }

            tb_co_tabla10_comprobantesBL BL = new tb_co_tabla10_comprobantesBL();
            tb_co_tabla10_comprobantes BE = new tb_co_tabla10_comprobantes();

            BE.codigoid = vmxtipdoc;
            DataTable tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

            if ((tmptabla.Rows.Count > 0))
            {
                GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["tipguia"].Value = tmptabla.Rows[0]["codigoid"].ToString();
                txtDescripcampo.Text = tmptabla.Rows[0]["descripcion"].ToString();
            }
            else
            {
                GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["tipguia"].Value = j_ctipdoc_3a;
            }
            sw_novaluechange = false;
        }

        private void validaSerieDocumento()
        {
            sw_novaluechange = true;
            string vmxtipdoc = "";
            if (!(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["serguia"].Value == DBNull.Value))
            {
                vmxtipdoc = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["serguia"].Value.ToString();
            }
            vmxtipdoc = vmxtipdoc.Trim();
            if ((vmxtipdoc.Trim().Length == 0))
            {
                return;
            }
            if ((VariablesPublicas.StringtoDecimal(vmxtipdoc) > 0))
            {
                vmxtipdoc = VariablesPublicas.PADL(vmxtipdoc, 4, "0");
            }
            GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["serguia"].Value = vmxtipdoc;
            sw_novaluechange = false;
        }
        private void validaNUmeroDocumento()
        {
            sw_novaluechange = true;
            string vmxtipdoc = "";
            if (!(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["numguia"].Value == DBNull.Value))
            {
                vmxtipdoc = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["numguia"].Value.ToString();
            }
            vmxtipdoc = vmxtipdoc.Trim();
            if ((vmxtipdoc.Trim().Length == 0))
            {
                return;
            }
            if ((VariablesPublicas.StringtoDecimal(vmxtipdoc) > 0))
            {
                vmxtipdoc = VariablesPublicas.PADL(vmxtipdoc, 10, "0");
            }
            GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["numguia"].Value = vmxtipdoc;
            sw_novaluechange = false;
        }
        #endregion

        private void AyudaCentroCosto()
        {
            string xcodrubro = "";
            string xcodcuenta = "";
            if (GridExaminar.CurrentRow != null)
            {
                if (!(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["rubroid"].Value == DBNull.Value))
                {
                    xcodrubro = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["rubroid"].Value.ToString();

                    tb_co_rubroventasBL BL = new tb_co_rubroventasBL();
                    tb_co_rubroventas BE = new tb_co_rubroventas();

                    BE.rubroid = xcodrubro;
                    tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                    if (tmptabla.Rows.Count > 0)
                    {
                        xcodcuenta = Equivalencias.Mid(tmptabla.Rows[0]["cuentaid"].ToString(), 1, 2);
                    }
                    else
                    {
                        xcodcuenta = "...";
                    }
                }
            }
            Ayudas.Frm_AyudaCentrocosto frmayuda = new Ayudas.Frm_AyudaCentrocosto();
            frmayuda.Owner = this;
            frmayuda.Owner = this;
            frmayuda._ClaseCuenta = xcodcuenta;
            frmayuda.PasaCentroCosto = RecibeCcosto;
            frmayuda.ShowDialog();
        }
        private void RecibeCcosto(string codigo, string descripcion, string sigla)
        {
            if (codigo.Trim().Length > 0)
            {
                GridExaminar.Rows[GridExaminar.CurrentCell.RowIndex].Cells["cencosid"].Value = codigo;
            }
        }
        private void validaCentroCosto()
        {
            DataTable tmpccosto = new DataTable();
            sw_novaluechange = true;
            Int16 lc_cont;
            bool zhallado = false;
            string VMNROITEM = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["asientoitems"].Value.ToString();
            string xcodartic = "..";
            string xcodrubro = "....";
            if (!(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["rubroid"].Value == DBNull.Value))
            {
                xcodrubro = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["rubroid"].Value.ToString();

                tb_co_rubroventasBL BL = new tb_co_rubroventasBL();
                tb_co_rubroventas BE = new tb_co_rubroventas();
                BE.rubroid = xcodrubro;
                tmpccosto = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            }

            string xcodcuenta = "..";
            xcodcuenta = "";
            if (tmpccosto.Rows.Count > 0)
            {
                xcodcuenta = Equivalencias.Mid(tmpccosto.Rows[0]["cuentaid"].ToString(), 1, 2);
            }

            if (!(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["cencosid"].Value == DBNull.Value))
            {
                xcodartic = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["cencosid"].Value.ToString();
            }
            if (xcodartic.Trim().Length == 0)
            {
                // DetFacturacion.Rows[lc_cont]["cencosid"] = "";
                // DetFacturacion.Rows[lc_cont]["dccosto"] = "";
                zhallado = true;
            }
            else
            {
                centrocostoBL BL = new centrocostoBL();
                tb_centrocosto BE = new tb_centrocosto();

                BE.cencosid = xcodartic;
                tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                for (lc_cont = 0; lc_cont < DetFacturacion.Rows.Count; lc_cont++)
                {
                    if (DetFacturacion.Rows[lc_cont]["asientoitems"].ToString() == VMNROITEM)
                    {
                        if (tmptabla.Rows.Count > 0)
                        {
                            DetFacturacion.Rows[lc_cont]["cencosid"] = tmptabla.Rows[0]["cencosid"];
                            // DetFacturacion.Rows[lc_cont]["dccosto"] = Equivalencias.Mid(tmptabla.Rows[0]["descrip_a"], 1,  DetFacturacion.Columns["dccosto"].MaxLength);
                            txtDescripcampo.Text = tmptabla.Rows[0]["cencosname"].ToString();
                            zhallado = true;
                            break;
                        }
                    }
                }
            }
            if (!zhallado)
            {
                GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["cencosid"].Value = j_Ccosto;
            }
            GridExaminar.Refresh();
            sw_novaluechange = false;
        }

        private void txtSerie_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("\t");
            }
        }
        private void txtSerie_LostFocus(object sender, System.EventArgs e)
        {
            if (u_n_opsel > 0)
            {
                if (txtSerie.Text.Trim().Length > 0)
                {
                    txtSerie.Text = VariablesPublicas.PADL(txtSerie.Text, txtSerie.MaxLength, "0");
                }
            }
        }

        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("\t");
            }
            if (e.KeyCode == Keys.F1)
            {
                AyudaRegVentas(1);
            }
        }

        private void txtNumero_LostFocus(object sender, System.EventArgs e)
        {
            if (u_n_opsel > 0)
            {
                if (txtNumero.Text.Trim().Length > 0)
                {
                    txtNumero.Text = VariablesPublicas.PADL(txtNumero.Text.Trim(), txtNumero.MaxLength, "0");
                }
            }
        }

        private void txtNumFin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("\t");
            }
        }

        private void txtNumFin_LostFocus(object sender, System.EventArgs e)
        {
            if (u_n_opsel > 0)
            {
                if (txtNumFin.Text.Trim().Length > 0)
                {
                    txtNumFin.Text = VariablesPublicas.PADL(txtNumFin.Text.Trim(), txtNumFin.MaxLength, "0");
                }
            }
        }

        private void txtSerieref_LostFocus(object sender, System.EventArgs e)
        {
            if (u_n_opsel > 0)
            {
                if (txtSerieref.Text.Trim().Length > 0)
                {
                    txtSerieref.Text = VariablesPublicas.PADL(txtSerieref.Text.Trim(), txtSerieref.MaxLength, "0");
                }
            }
        }
        private void txtNumeroref_LostFocus(object sender, System.EventArgs e)
        {
            if (u_n_opsel > 0)
            {
                if (txtNumeroref.Text.Trim().Length > 0)
                {
                    txtNumeroref.Text = VariablesPublicas.PADL(txtNumeroref.Text.Trim(), txtNumeroref.MaxLength, "0");
                }
            }
        }

        public void u_ShowGets()
        {
            lblAnulado.Text = "";
            if ((CabFacturacion != null))
            {
                if (CabFacturacion.Rows.Count > 0)
                {
                    lblAnulado.Text = (chkActivo.Checked ? "" : "ANULADO");
                }
            }
            lblAnulado.Visible = !chkActivo.Checked & lblAnulado.Text.Trim().Length > 0;

            lblUsuar.Text = "";
            if (!(CabFacturacion == null))
            {
                if ((CabFacturacion.Rows.Count > 0))
                {
                    lblUsuar.Text = CabFacturacion.Rows[0]["Usuar"].ToString().ToUpper().Trim() + " - " + CabFacturacion.Rows[0]["feact"].ToString();
                }
            }
            lblUsuar.Visible = (lblUsuar.Text.Trim().Length > 0);
        }

        private void chkActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0)
            {
                u_ShowGets();
            }
        }

        private void cboTipdoc_KeyDown(object sender, KeyEventArgs e)
        {
            ProcesaCombo(cboTipdoc, e);
        }

        public static void ProcesaCombo(ComboBox ObjCombo, KeyEventArgs e)
        {
            //  Permite Abrir/Cerrar una lista de combo cuando se pulsa SPACE y al pulsar ENTER pasa al sig. Objeto
            if ((e.KeyCode == Keys.Space))
            {
                ObjCombo.DroppedDown = !ObjCombo.DroppedDown;
            }
            else if ((e.KeyCode == Keys.Enter))
            {
                if (ObjCombo.DroppedDown)
                {
                    ObjCombo.DroppedDown = false;
                }
                else
                {
                    SendKeys.Send("\t");
                }
            }
        }

        private void txtGlosa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("\t");
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            //Frm_CopiarRegistroVentas oform = new Frm_CopiarRegistroVentas();
            //oform._diarioid = cboSubdiario.SelectedValue.ToString();
            //oform.Owner = this;
            //oform._PasaRegVENTAS = RecibeTablaaCopiar;
            //oform.ShowDialog();
        }
        void RecibeTablaaCopiar(string mes, string diario, string numero)
        {
            if ((mes.Trim().Length > 0))
            {
                try
                {
                    tb_co_VentascabBL BL = new tb_co_VentascabBL();
                    tb_co_Ventascab BE = new tb_co_Ventascab();

                    BE.perianio = VariablesPublicas.perianio;
                    BE.perimes = mes;
                    BE.moduloid = modulo.ToString();
                    BE.local = local.ToString();
                    BE.diarioid = diario;
                    BE.asiento = numero;

                    tmptablacab = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                    // tmptablacab = ocapa.KAG0300_consulta(GlobalVars.GetInstance.Company, GlobalVars.GetInstance.Periodo, mes, numero, "", "", "", "", "", "");
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                try
                {
                    tb_co_VentasdetBL BL = new tb_co_VentasdetBL();
                    tb_co_Ventasdet BE = new tb_co_Ventasdet();

                    BE.perianio = VariablesPublicas.perianio;
                    BE.perimes = mes;
                    BE.moduloid = modulo.ToString();
                    BE.local = local.ToString();
                    BE.diarioid = diario;
                    BE.asiento = numero;

                    tmptabladet = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                    // tmptabladet = ocapa.KAP0300_consulta(GlobalVars.GetInstance.Company, GlobalVars.GetInstance.Periodo, mes, numero, "", "");
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                CargaDatos();
                tmptablacab = null;
                tmptabladet = null;
            }
        }

        //public void RecibeTablaaCopiar(DataTable Cabecera, DataTable Detalle)
        //{
        //    if ((Cabecera != null))
        //    {
        //        if ((Detalle != null))
        //        {
        //             tmptablacab = Cabecera;
        //             tmptabladet = Detalle;
        //             CargaDatos();
        //             tmptablacab = null;
        //             tmptabladet = null;
        //        }
        //    }
        //}

        public void calcularigvmanual()
        {
            decimal nvalorigv = VariablesPublicas.StringtoDecimal(txtIgv.Text);
            totalizar();
            decimal igvmanual = VariablesPublicas.StringtoDecimal(txtIgv.Text);
            decimal ndif = nvalorigv - igvmanual;
            txtIgv.Text = nvalorigv.ToString("###,###.00");
            txtTotal.Text = System.String.Format(VariablesPublicas.StringtoDecimal(txtTotal.Text) + ndif.ToString(), "###,###.00");
        }

        private void txtIgv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '\r'))
            {
                calcularigvmanual();
            }
        }

        private void txtVenta_GotFocus(object sender, System.EventArgs e)
        {
            j_String = txtVenta.Text;
        }

        private void txtVenta_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_String == txtVenta.Text) & u_n_opsel > 0)
            {
                decimal prvvalorigv = 0;
                dynamic prvporvigv = VariablesPublicas.StringtoDecimal(txtPigv.Text);
                decimal prvvalorventa = 0;
                prvvalorventa = VariablesPublicas.StringtoDecimal(txtVenta.Text);
                prvvalorigv = prvvalorventa * (prvporvigv / 100);
                CalculaCabecera(prvvalorventa, prvvalorigv, prvvalorventa + prvvalorigv);
            }
        }

        private void cboTipdoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0 & !sw_load)
            {
                if (!(j_codtipdocu == cboTipdoc.SelectedValue.ToString()))
                {
                    j_codtipdocu = cboTipdoc.SelectedValue.ToString();
                }
                cboTipdocref.SelectedValue = "";
                txtSerieref.Text = "";
                txtNumeroref.Text = "";
                refrescacontroles();
            }
        }

        private void txtTipoventa_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1))
            {
                AyudaTipoVenta();
            }
        }
        private void txtTipoventa_GotFocus(object sender, System.EventArgs e)
        {
            j_TipoVenta = txtTipoventa.Text;
        }
        private void txtTipoventa_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_TipoVenta == txtTipoventa.Text) & !sw_load & u_n_opsel > 0)
            {
                validaTipoVenta();
            }
        }
        private void AyudaTipoVenta()
        {
            Frm_AyudaTipoventa frmayuda = new Frm_AyudaTipoventa();
            frmayuda.Owner = this;
            //frmayuda._LpTipoDocu = TipoConceptoVentas;
            frmayuda.PasaTipoventa = RecibeTipoVenta;
            //frmayuda._ActivaTipoConcepto = false;
            frmayuda.ShowDialog();
        }
        private void RecibeTipoVenta(string codigo, string nombre)
        {
            if (codigo.Trim().Length > 0)
            {
                txtTipoventa.Text = codigo;
                validaTipoVenta();
            }
        }
        public void validaTipoVenta()
        {
            txtTipoventa.Text = txtTipoventa.Text.PadLeft(2, '0');
            if (txtTipoventa.Text.Trim().Length > 0)
            {
                tb_co_tipoventasBL BL = new tb_co_tipoventasBL();
                tb_co_tipoventas BE = new tb_co_tipoventas();

                BE.tipoid = txtTipoventa.Text.Trim();
                DataTable tventa = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                if (tventa.Rows.Count == 0)
                {
                    txtTipoventa.Text = j_String;
                }
                else
                {
                    txtTipoventa.Text = tventa.Rows[0]["tipoid"].ToString().Trim();
                    lblTipoventa.Text = tventa.Rows[0]["tiponame"].ToString().Trim();
                    cboMoneda.SelectedValue = tventa.Rows[0]["moneda"].ToString().Trim();
                }
            }
            else
            {
                txtTipoventa.Text = j_String;
            }

            // txtTipoventa.Text = VariablesPublicas.PADL(txtTipoventa.Text.Trim(),  txtTipoventa.MaxLength, "0");
            // tmptabla = ocapa.KAG0600_CONSULTA((txtTipoventa.Text.Trim().Length == 0 ? ".." :  txtTipoventa.Text.Trim()), "", GlobalVars.GetInstance.TipoConceptoVentas, 1, GlobalVars.GetInstance.Company, 0);
            //if (ocapa.sql_error.Length == 0)
            //{
            //if (tmptabla.Rows.Count > 0)
            //{
            //     txtTipoventa.Text =  tmptabla.Rows[0]["tipoc_6k"].ToString();
            //     lblTipoventa.Text =  tmptabla.Rows[0]["nomb_6k"].ToString();
            //}
            //else
            //{
            //     txtTipoventa.Text =  j_TipoVenta;
            //}
            //}
        }

        public void AyudaRubroVentas()
        {
            Frm_AyudaRubroventa frmayuda = new Frm_AyudaRubroventa();
            frmayuda.Owner = this;
            frmayuda._PasaValor = RecibeRubroVentas;
            frmayuda.ShowDialog();
        }
        private void RecibeRubroVentas(string Codigo)
        {
            if (Codigo.Trim().Length > 0)
            {
                GridExaminar.Rows[GridExaminar.CurrentCell.RowIndex].Cells["rubroid"].Value = Codigo;
                ValidarubroVenta();
            }
        }
        public void ValidarubroVenta()
        {
            string xcodigo = "";
            sw_novaluechange = true;
            if (object.ReferenceEquals(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["rubroid"].Value, DBNull.Value))
            {
                GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["rubroid"].Value = "";
            }
            xcodigo = Equivalencias.Mid(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["rubroid"].Value.ToString(), 1, 4);
            if (xcodigo.Trim().Length > 0)
            {
                xcodigo = VariablesPublicas.PADL(xcodigo.Trim(), 4, "0");
                try
                {
                    tb_co_rubroventasBL BL = new tb_co_rubroventasBL();
                    tb_co_rubroventas BE = new tb_co_rubroventas();

                    BE.rubroid = xcodigo;
                    tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (tmptabla.Rows.Count > 0)
                {
                    GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["rubroid"].Value = tmptabla.Rows[0]["rubroid"];
                    GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["drubro"].Value = tmptabla.Rows[0]["rubroname"];
                    
                    txtDescripcampo.Text = tmptabla.Rows[0]["cuentaid"].ToString().Trim() + " - " + tmptabla.Rows[0]["cuentaname"].ToString().Trim();
                }
                else
                {
                    GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["rubroid"].Value = j_RUBRO;
                }
            }
            else
            {
                GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["rubroid"].Value = j_RUBRO;
            }
            sw_novaluechange = false;
        }

        //private void AyudaTipoDestinoDetalle()
        //{
        //    //frmayudatipodestino frmayuda = new frmayudatipodestino();
        //    //frmayuda.Owner = this;
        //    //frmayuda._PasaValor = RecibeTipoDestinoDetalle;
        //    //frmayuda.ShowDialog();
        //}
        //private void RecibeTipoDestinoDetalle(string codigo)
        //{
        //    if (codigo.Trim().Length > 0)
        //    {
        //         GridExaminar.Rows[ GridExaminar.CurrentRow.Index].Cells["dest_3a"].Value = codigo;
        //    }
        //}
        //public void validaTipoDestinoDetalle()
        //{
        //    string xcodigo = "";
        //     sw_novaluechange = true;
        //    if (object.ReferenceEquals(GridExaminar.Rows[ GridExaminar.CurrentRow.Index].Cells["dest_3a"].Value, DBNull.Value))
        //    {
        //         GridExaminar.Rows[ GridExaminar.CurrentRow.Index].Cells["dest_3a"].Value = "";
        //    }
        //     GridExaminar.Rows[ GridExaminar.CurrentRow.Index].Cells["dest_3a"].Value = VariablesPublicas.PADL(GridExaminar.Rows[ GridExaminar.CurrentRow.Index].Cells["dest_3a"].Value.ToString().Trim(),  DetFacturacion.Columns["dest_3a"].MaxLength, "0");
        //    xcodigo =  GridExaminar.Rows[ GridExaminar.CurrentRow.Index].Cells["dest_3a"].Value.ToString();
        //    if (xcodigo.Trim().Length > 0)
        //    {
        //        // tmptabla = ocapa.CaeSoft_GetAllTipoDestino(GlobalVars.GetInstance.CompanyGeneral, xcodigo);

        //        //if (ocapa.sql_error.Length == 0)
        //        //{
        //            if (tmptabla.Rows.Count > 0)
        //            {
        //                 GridExaminar.Rows[ GridExaminar.CurrentRow.Index].Cells["dest_3a"].Value = tmptabla.Rows[0]["codigo"];
        //                 GridExaminar.Rows[ GridExaminar.CurrentRow.Index].Cells["ddestino"].Value = tmptabla.Rows[0]["DESCRIP"];

        //            }
        //        //}
        //    }
        //    else
        //    {
        //         GridExaminar.Rows[ GridExaminar.CurrentRow.Index].Cells["dest_3a"].Value =  j_Destino;
        //    }

        //     sw_novaluechange = false;
        //     totalizarItem();
        //}

        public void totalizaritemigv()
        {
            sw_novaluechange = true;
            if (object.ReferenceEquals(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["valorventa"].Value, DBNull.Value))
            {
                GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["valorventa"].Value = 0;
            }
            string xdestino = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["afectoigvid"].Value.ToString();
            decimal nporcigv = VariablesPublicas.StringtoDecimal(txtPigv.Text);
            if (xdestino == "2" | !chkAfecto.Checked)
            {
                GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["igvo"].Value = 0;
            }
            else
            {
                GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["igvo"].Value = Math.Round(Convert.ToDecimal(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["valorventa"].Value) * (nporcigv / 100), 2);
            }
            GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["total"].Value = Math.Round(Convert.ToDecimal(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["igvo"].Value) + Convert.ToDecimal(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["valorventa"].Value), 2);
            totalizar();
            sw_novaluechange = false;
        }
        public void totalizaritemtotal()
        {
            sw_novaluechange = true;
            if (object.ReferenceEquals(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["igvo"].Value, DBNull.Value))
            {
                GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["igvo"].Value = 0;
            }
            GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["total"].Value = Math.Round(Convert.ToDecimal(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["igvo"].Value) + Convert.ToDecimal(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["valorventa"].Value), 2);
            totalizar();
            sw_novaluechange = false;
        }

        private void btnAddfila_Click(object sender, EventArgs e)
        {
            string xcurritrm = "";
            DetFacturacion.AcceptChanges();            
            if ((GridExaminar.CurrentRow != null))
            {
                xcurritrm = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["asientoitems"].Value.ToString();
                if (xcurritrm.Trim().Length > 0)
                {
                    for (lc_contador = 0; lc_contador <= DetFacturacion.Rows.Count - 1; lc_contador++)
                    {
                        if (DetFacturacion.Rows[lc_contador]["asientoitems"].ToString().Trim() == xcurritrm)
                        {
                            xcurritrm = lc_contador.ToString();
                            break;
                        }
                    }
                }
            }
            if (chkDuplicar.Checked & xcurritrm.Trim().Length > 0)
            {
                DetFacturacion.ImportRow(DetFacturacion.Rows[Convert.ToInt16(xcurritrm)]);
            }
            else
            {
                DetFacturacion.Rows.Add(VariablesPublicas.InsertIntoTable(DetFacturacion));
                DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["asientoitems"] = 0;
                //DetFacturacion.Rows[ DetFacturacion.Rows.Count - 1]["lee_item"] = 0;
            }
            DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["asientoitems"] = VariablesPublicas.CalcMaxField(DetFacturacion, "asientoitems", 5);
            if (cboDestinoigv.Text.Substring(0, 1) == "3")
            {
                DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["afectoigvid"] = "2";
            }
            else
            {
                DetFacturacion.Rows[DetFacturacion.Rows.Count - 1]["afectoigvid"] = Equivalencias.Left(cboDestinoigv.Text, 1);
            }
            GridExaminar.CurrentCell = GridExaminar.Rows[GridExaminar.RowCount - 1].Cells["rubroid"];
            GridExaminar.BeginEdit(true);
            totalizar();
            refrescacontroles();
        }
        private void btnDelfila_Click(object sender, EventArgs e)
        {
            string xcoditem = "";
            Int16 lc_cont = default(Int16);
            if ((GridExaminar.CurrentRow != null))
            {
                xcoditem = GridExaminar.Rows[GridExaminar.CurrentCell.RowIndex].Cells["asientoitems"].Value.ToString();
                for (lc_cont = 0; lc_cont <= DetFacturacion.Rows.Count - 1; lc_cont++)
                {
                    // ubique el item a borrar
                    if (DetFacturacion.Rows[lc_cont]["asientoitems"].ToString().Trim() == xcoditem)
                    {
                        DetFacturacion.Rows[lc_cont].Delete();
                        DetFacturacion.AcceptChanges();
                        break;
                    }
                }
                // regenerar el nro de item
                for (lc_cont = 0; lc_cont <= DetFacturacion.Rows.Count - 1; lc_cont++)
                {
                    DetFacturacion.Rows[lc_cont]["asientoitems"] = VariablesPublicas.PADL(Convert.ToString(lc_cont + 1), 5, "0");
                }
                totalizar();
                refrescacontroles();
            }
        }

        private void fRegistro_ValueChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0)
            {
                //txtPigv.Text = ocapa.ufc_Extraeigv(UtilitariosInterface.DTOS(fregistro.Value));
                tributoIgv();
                actualizatipocambio();
                totalizarItem();
                totalizar();
                fecVenc.Text = fRegistro.Text;
            }
        }

        private void tributoIgv()
        {
            DataTable ttributo = new DataTable();
            tributotasaBL BL = new tributotasaBL();
            tb_tributotasa BE = new tb_tributotasa();

            BE.tributoid = "1011";
            BE.tributofecha = Convert.ToDateTime(fRegistro.Text);

            ttributo = BL.GetAll2(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            decimal xtasaigv = 0;
            if ((ttributo.Rows.Count > 0))
            {
                xtasaigv += Convert.ToDecimal(ttributo.Rows[0]["tributotasa"]);
                //txtPigv.Text = ttributo.Rows[0]["tributotasa"].ToString();
                txtPigv.Text = xtasaigv.ToString("##.00");
            }
            else
            {
                txtPigv.Text = "";
            }
        }

        private void btnSeekdoc_Click(object sender, EventArgs e)
        {
            //Frm_AyudaBuscarregistroventas oform = new Frm_AyudaBuscarregistroventas();
            //oform._diario = cboSubdiario.SelectedValue.ToString();
            //oform.Owner = this;
            //oform._PasaRegVENTAS = reciberegistroVentas;
            //oform.ShowDialog();
        }
        public void reciberegistroVentas(string mes, string diario, string numero)
        {
            if (mes.Trim().Length > 0)
            {
                sELECCIONAaYUDA = true;
                txtMes.Text = mes;
                txtAsiento.Text = numero;
                procesanumero();
            }
        }

        private void btnActtipocambio_Click(object sender, EventArgs e)
        {
            if (DevExpress.XtraEditors.XtraMessageBox.Show("Desea Actualizar el tipo de cambio del movimiento ...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                actualizatipocambio();
                W_KEY0001 = txtRuc.Text.Trim();
                if ((cboTipdoc.SelectedValue != null))
                {
                    W_KEY0001 = W_KEY0001 + cboTipdoc.SelectedValue.ToString();
                }
                W_KEY0001 = W_KEY0001 + txtSerie.Text.Trim() + txtNumero.Text.Trim();
                Grabar(true);
            }
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            // Si el control tiene el foco...
            if (keyData == Keys.Enter & !txtAsiento.Focused)
            {
                if ((GridExaminar.CurrentCell != null))
                {
                    if (GridExaminar.Columns[GridExaminar.CurrentCell.ColumnIndex].Name.ToUpper() == "COL_OBS".ToUpper())
                    {
                    }
                    else
                    {
                        if (GridExaminar.Columns[GridExaminar.CurrentCell.ColumnIndex].Name.ToUpper() == "numguia".ToUpper())
                        {
                        }
                        else
                        {
                            SendKeys.Send("\t");
                            return true;
                        }
                    }
                }
                else
                {
                    SendKeys.Send("\t");
                    return true;
                }
            }
            else
            {
                if (txtAsiento.Focused)
                {
                    if (keyData == Keys.Tab)
                    {
                        procesanumero();
                    }
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void Recibetabla(DataTable tabla, DataTable tablaacopiar)
        {
            int lc_cont = 0;
            string xnroitem = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["asientoitems"].Value.ToString();
            if (tabla.Rows.Count > 0)
            {
                for (lc_cont = 0; lc_cont <= DetFacturacion.Rows.Count - 1; lc_cont++)
                {
                    if (DetFacturacion.Rows[lc_cont]["asientoitems"].ToString() == xnroitem)
                    {
                        DetFacturacion.Rows[lc_cont]["observ1"] = tabla.Rows[0]["observ1"];
                        DetFacturacion.Rows[lc_cont]["observ2"] = tabla.Rows[0]["observ2"];
                        DetFacturacion.Rows[lc_cont]["observ3"] = tabla.Rows[0]["observ3"];
                        DetFacturacion.Rows[lc_cont]["observ4"] = tabla.Rows[0]["observ4"];
                        DetFacturacion.Rows[lc_cont]["observ5"] = tabla.Rows[0]["observ5"];
                    }
                }
            }
            pcgcopy = tablaacopiar;
        }

        private void AyudaOP()
        {
            //string XNUMPEDIDOComercial = "";
            //FrmAyudaOp frmayuda = new FrmAyudaOp();
            //frmayuda.Owner = this;
            //if ((!object.ReferenceEquals(GridExaminar.Rows[ GridExaminar.CurrentRow.Index].Cells["pedido_3a"].Value, DBNull.Value)))
            //{
            //    XNUMPEDIDOComercial =  GridExaminar.Rows[ GridExaminar.CurrentRow.Index].Cells["pedido_3a"].Value.ToString();
            //}
            //frmayuda._Pedido = XNUMPEDIDOComercial;
            //frmayuda.PasaPedido = RecibeOP;
            //frmayuda.ShowDialog();
        }
        private void RecibeOP(string codigo)
        {
            if (codigo.Trim().Length > 0)
            {
                GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["num_op"].Value = codigo;
            }
        }
        public void validaOp()
        {
            sw_novaluechange = true;
            string xcodigo = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["num_op"].Value.ToString();
            if (xcodigo.Trim().Length > 0)
            {
                xcodigo = VariablesPublicas.PADL(xcodigo, DetFacturacion.Columns["num_op"].MaxLength, "0");
                // tmptabla = ocapa.CaeSoft_GetallPedidosComercialCabecera(GlobalVars.GetInstance.CompanyGeneral, xcodigo, "", "", "", 1, "", "", "", "");
                //if (ocapa.sql_error.Length == 0)
                //{
                if (tmptabla.Rows.Count > 0)
                {
                    xcodigo = tmptabla.Rows[0]["numpedido"].ToString();
                }
                else
                {
                    xcodigo = j_widOP;
                }
                //}
                if (xcodigo.Trim().Length == 0)
                {
                    GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["num_op"].Value = j_widOP;
                }
                else
                {
                    GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["num_op"].Value = xcodigo;
                }
            }
            sw_novaluechange = false;
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            //Frm_RenameRegistroVentas oform = new Frm_RenameRegistroVentas();
            //oform._RegMes = txtMes.Text;
            //oform._RegDiarioid = cboSubdiario.SelectedValue.ToString();
            //oform._RegNumero = txtAsiento.Text;
            //oform.ShowInTaskbar = false;
            //oform._PasaRegVENTAS = RecibeParametrosRename;
            //oform.Owner = this;
            //oform.ShowDialog();
        }
        private void RecibeParametrosRename(string newmes, string newdiarioid, string newregistro)
        {
            if (newmes.Trim().Length > 0)
            {
                // a Renombrar
                tb_co_VentasBL BL = new tb_co_VentasBL();
                tb_co_Ventas BE = new tb_co_Ventas();

                BE.perianio = VariablesPublicas.perianio;
                BE.perimes = txtMes.Text;
                BE.diarioid = cboSubdiario.SelectedValue.ToString();
                BE.asiento = txtAsiento.Text;
                BE.regmesnuevo = newmes;
                BE.regdiarionuevo = newdiarioid;
                BE.regnumeronuevo = newregistro;

                BL.RenameVenta(VariablesPublicas.EmpresaID.ToString(), BE);
                ////ocapa.spu_renameregVentas(GlobalVars.GetInstance.Company, GlobalVars.GetInstance.Periodo,  txtmes.Text,  txtregistro.Text, newmes, newregistro);
                if (BL.Sql_Error.Length == 0)
                {
                    sELECCIONAaYUDA = true;
                    txtMes.Text = newmes;
                    txtAsiento.Text = newregistro;
                    procesanumero();
                    DevExpress.XtraEditors.XtraMessageBox.Show("Registro Renombrado Satisfactoriamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    Codigo.Frm_Class.ShowError(BL.Sql_Error, this);
                }
            }
        }

        private void AyudaPedidos()
        {
            //FrmAyudaPedidoComercial frmayuda = new FrmAyudaPedidoComercial();
            //frmayuda.Owner = this;
            //frmayuda.PasaPedidoFC = RecibePedido;
            //frmayuda.ShowDialog();
        }
        private void RecibePedido(string codigo)
        {
            if (codigo.Trim().Length > 0)
            {
                GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["pedido_3a"].Value = codigo;
                ValidaPedido();
            }
        }
        private void ValidaPedido()
        {
            if (GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["pedido_3a"].Value == DBNull.Value)
            {
                GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["pedido_3a"].Value = "";
            }
            string xcodigo = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["pedido_3a"].Value.ToString();
            if (xcodigo.Trim().Length > 0)
            {
                xcodigo = VariablesPublicas.PADL(xcodigo, 10, "0");
                // tmptabla = ocapa.spu_AyudaPedidos(GlobalVars.GetInstance.CompanyGeneral, "", "", "", xcodigo, xcodigo, "", "", "", 1);
                //if ((ocapa.sql_error.Length == 0))
                //{
                if (tmptabla.Rows.Count > 0)
                {
                    xcodigo = tmptabla.Rows[0]["pedido"].ToString();
                }
                else
                {
                    xcodigo = j_Pedido;
                }
                //}
                if (xcodigo.Trim().Length == 0)
                {
                    GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["pedido_3a"].Value = j_Pedido;
                }
                else
                {
                    GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["pedido_3a"].Value = xcodigo;
                }
            }
        }

        private void btnFacturaguia_Click(object sender, EventArgs e)
        {
            if (txtRuc.Text.Trim().Length == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Ingrese Número de Ruc del Cliente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRuc.Focus();
                return;
            }
            //Frm_SeleccionGraFacturar oform = new Frm_SeleccionGraFacturar();
            //oform.Owner = this;
            //oform._DesactivaDetalle = true;
            //oform._CodDetalle = txtRuc.Text;
            //oform.PasarMovimiento = RecibeDataAlmacen;
            //oform.ShowDialog();
        }
        public void RecibeDataAlmacen(DataTable DataClonada, bool zselecciona, bool zanexar)
        {
            if (zselecciona)
            {
                DataRow ofila = null;
                int nfila = 0;
                int lccontcampos = 0;
                DetFacturacion.AcceptChanges();
                if (!zanexar)
                {
                    // se deletean filas del detalle
                    // y se anexan los registros seleccionados
                }
                for (nfila = 0; nfila <= DetFacturacion.Rows.Count - 1; nfila++)
                {
                    DetFacturacion.Rows[nfila].Delete();
                }
                DetFacturacion.AcceptChanges();

                string xmsgerror = "";
                try
                {
                    for (nfila = 0; nfila <= DataClonada.Rows.Count - 1; nfila++)
                    {
                        ofila = null;
                        ofila = VariablesPublicas.InsertIntoTable(DetFacturacion);

                        for (lccontcampos = 0; lccontcampos <= DetFacturacion.Columns.Count - 1; lccontcampos++)
                        {
                            ofila[DetFacturacion.Columns[lccontcampos].ColumnName] = DataClonada.Rows[nfila][DetFacturacion.Columns[lccontcampos].ColumnName];
                        }
                        DetFacturacion.Rows.Add(ofila);
                    }

                }
                catch (Exception ex)
                {
                    xmsgerror = ex.Message;
                }
                DetFacturacion.AcceptChanges();
                for (nfila = 0; nfila <= DetFacturacion.Rows.Count - 1; nfila++)
                {
                    DetFacturacion.Rows[nfila]["nro_item"] = VariablesPublicas.PADL(Convert.ToString(nfila + 1), DetFacturacion.Columns["NRO_item"].MaxLength, "0");
                }
                DetFacturacion.AcceptChanges();
                GridExaminar.Refresh();
                if (xmsgerror.Trim().Length > 0)
                {
                    Codigo.Frm_Class.ShowError(xmsgerror + "\r\n" + "ERROR AL enlazar Registro de Compras con documentos registradas en almacén ", this);
                }
            }
        }

        public void ayudaColorTallaOP()
        {
            string xOP = "";
            if ((GridExaminar.CurrentRow != null))
            {
                if ((!object.ReferenceEquals(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["ordenp_3a"].Value, DBNull.Value)))
                {
                    xOP = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["ordenp_3a"].Value.ToString();
                }
            }
            //frm_ayuda_opcolortalla oform = new frm_ayuda_opcolortalla();
            //oform._OP = xOP;
            //oform._PasaRegistro = RecibeOpColorTalla;
            //oform.Owner = this;
            //oform.ShowDialog();
        }
        public void RecibeOpColorTalla(string OP, string cod_articulo, string des_articulo)
        {
            if (cod_articulo.Trim().Length > 0)
            {
                GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["linea2_3a"].Value = cod_articulo;
            }
        }
        private void ValidaColorTALLA()
        {
            sw_novaluechange = true;
            DataTable tmpcursor = new DataTable();
            Int16 lc_cont = default(Int16);
            string VMNROITEM = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["nro_item"].Value.ToString();
            string XOP = "";
            string xcodartic = "";
            if ((!object.ReferenceEquals(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["LINEA2_3A"].Value, DBNull.Value)))
            {
                xcodartic = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["LINEA2_3A"].Value.ToString();
            }
            if ((!object.ReferenceEquals(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["ordenp_3a"].Value, DBNull.Value)))
            {
                XOP = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["ordenp_3a"].Value.ToString();
            }
            if (xcodartic.Trim().Length == 0)
            {
                xcodartic = "..";
            }
            if (XOP.Trim().Length == 0)
            {
                XOP = "..";
            }
            //tmpcursor = ocapa.cag170L_consulta(XOP, xcodartic, "", "", "", "", "");
            for (lc_cont = 0; lc_cont <= DetFacturacion.Rows.Count - 1; lc_cont++)
            {
                if (DetFacturacion.Rows[lc_cont]["nro_item"].ToString() == VMNROITEM)
                {
                    if (tmpcursor.Rows.Count == 0 | xcodartic.Trim().Length == 0)
                    {
                        DetFacturacion.Rows[lc_cont]["LINEA2_3A"] = j_colORTALlA;
                    }
                    else
                    {
                        DetFacturacion.Rows[lc_cont]["LINEA2_3A"] = tmpcursor.Rows[0]["COD_ARTICULO"];
                        DetFacturacion.Rows[lc_cont]["darticulo"] = Equivalencias.Mid(tmpcursor.Rows[0]["nomb_17L"].ToString(), 1, DetFacturacion.Columns["darticulo"].MaxLength);
                        DetFacturacion.Rows[lc_cont]["linea_3a"] = tmpcursor.Rows[0]["lineat_17L"];
                    }
                    break;
                }
            }
            sw_novaluechange = false;
        }

        private void cboOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0)
            {
                cboAduana.SelectedValue = "";
                adufEmbarque.ShowCheckBox = false;
                adufRegularizacion.ShowCheckBox = false;
                aduValorfob.Text = "";
                aduPeriodo.Text = (cboOrigen.Text.Substring(0, 2) == "02" ? VariablesPublicas.perianio : "");
                aduCorrelativo.Text = "";
                adufRegularizacion.ShowCheckBox = false;
                adufEmbarque.ShowCheckBox = false;
                cboTipoexportacion.SelectedValue = "";
                _terminoventa = "";
                _pais = "";
                _embarque = "";
                _condpago = "";
                _cartacredito = "";
                _codigovia = "";
                _referencia = "";

                refrescacontroles();
            }
        }
        private void aduValorfob_GotFocus(object sender, System.EventArgs e)
        {
            j_ValorFob = aduValorfob.Text;
        }
        private void aduValorfob_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_ValorFob == aduValorfob.Text))
            {
                decimal nnnvalor = VariablesPublicas.StringtoDecimal(aduValorfob.Text);
                if (nnnvalor == 0)
                {
                    aduValorfob.Text = "0.00";
                }
                else
                {
                    aduValorfob.Text = System.String.Format(nnnvalor.ToString(), "###,###,###.00");
                }
            }
        }
        private void aduCorrelativo_LostFocus(object sender, System.EventArgs e)
        {
            if (aduCorrelativo.Text.Trim().Length > 0)
            {
                aduCorrelativo.Text = aduCorrelativo.Text.Trim();
            }
        }
        private void aduPeriodo_LostFocus(object sender, System.EventArgs e)
        {
            if (aduPeriodo.Text.Trim().Length > 0)
            {
                aduPeriodo.Text = aduPeriodo.Text.Trim();
            }
        }

        private void cboServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (u_n_opsel > 0)
            {
                bool VMZOK = false;
                if (cboServicio.SelectedValue.ToString().Trim().Length == 0)
                {
                    txtPorcdet.Text = "";
                }
                else
                {
                    try
                    {
                        tb_co_detraccionBL BL = new tb_co_detraccionBL();
                        tb_co_detraccion BE = new tb_co_detraccion();

                        BE.detraccionid = cboServicio.SelectedValue.ToString();
                        tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                        // tmptabla = ocapa.CaeSoft_GetAllCuentaDetraccion(cmbservicio.SelectedValue, 0, "", "", "", 2);
                        if (BL.Sql_Error.Length == 0)
                        {
                            if (tmptabla.Rows.Count > 0)
                            {
                                txtPorcdet.Text = tmptabla.Rows[0]["detraccionporcent"].ToString();
                                VMZOK = true;
                            }
                        }
                        if (!VMZOK)
                        {
                            txtPorcdet.Text = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                refrescacontroles();
            }
        }

        private void txtPorcdet_GotFocus(object sender, System.EventArgs e)
        {
            J_PORCDET = txtPorcdet.Text;
        }
        private void txtPorcdet_LostFocus(object sender, System.EventArgs e)
        {
            if (!(J_PORCDET == txtPorcdet.Text))
            {
                decimal nnnvalor = VariablesPublicas.StringtoDecimal(txtPorcdet.Text);
                if (nnnvalor == 0 | nnnvalor > 999)
                {
                    txtPorcdet.Text = "0.00";
                }
                else
                {
                    txtPorcdet.Text = System.String.Format(nnnvalor.ToString(), "###,###,###.00");
                }
            }
        }

        private void btnDatadic_Click(object sender, EventArgs e)
        {
            //Frm_RegistroVentasExt oform = new Frm_RegistroVentasExt();
            //oform.Owner = this;
            //oform._CabVentas = CabFacturacion;
            //oform.DelegadoEjecucionXXX = RecibeDatosAdicionales;
            //oform.u_n_opsel = u_n_opsel;
            //oform._terminoventa = _terminoventa;
            //oform._pais = _pais;
            //oform._embarque = _embarque;
            //oform._condpago = _condpago;
            //oform._cartacredito = _cartacredito;
            //oform._codigovia = _codigovia;
            //oform._referencia = _referencia;
            //oform.ShowDialog();
        }

        private void RecibeDatosAdicionales(string lpterminoventa, string lppais, string lpembarque, string lpcondpago, string lpcartacredito, string lpcodigovia, string lpreferencia, bool zaceptar)
        {
            if (zaceptar)
            {
                _terminoventa = lpterminoventa;
                _pais = lppais;
                _embarque = lpembarque;
                _condpago = lpcondpago;
                _cartacredito = lpcartacredito;
                _codigovia = lpcodigovia;
                _referencia = lpreferencia;
            }
        }

        private void btnProvfactura_Click(object sender, EventArgs e)
        {
            //Frm_CopiarFactura oform = new Frm_CopiarFactura();
            //oform._Titulo = "Selecciona Factura a Provisionar";
            //oform._PasaRegVENTAS = RecibeTablaProvisionar;
            //oform.Owner = this;
            //oform.ShowDialog();
        }
        public void RecibeTablaProvisionar(DataTable LpCabecera, DataTable LpDetalle)
        {
            if (LpCabecera != null)
            {
                if (LpDetalle != null)
                {
                    int nfila = 0;
                    DataRow ofila = null;
                    int lccontcampos = 0;
                    CabFacturacion.AcceptChanges();
                    DetFacturacion.AcceptChanges();
                    for (nfila = 0; nfila <= CabFacturacion.Rows.Count - 1; nfila++)
                    {
                        CabFacturacion.Rows[nfila].Delete();
                    }
                    for (nfila = 0; nfila <= DetFacturacion.Rows.Count - 1; nfila++)
                    {
                        DetFacturacion.Rows[nfila].Delete();
                    }
                    sw_novaluechange = true;
                    CabFacturacion.AcceptChanges();
                    DetFacturacion.AcceptChanges();
                    for (nfila = 0; nfila <= LpCabecera.Rows.Count - 1; nfila++)
                    {
                        ofila = null;
                        ofila = VariablesPublicas.InsertIntoTable(CabFacturacion);
                        for (lccontcampos = 0; lccontcampos <= LpCabecera.Columns.Count - 1; lccontcampos++)
                        {
                            if (VariablesPublicas.SeekNameColumn(CabFacturacion, LpCabecera.Columns[lccontcampos].ColumnName))
                            {
                                ofila[CabFacturacion.Columns[lccontcampos].ColumnName] = LpCabecera.Rows[nfila][LpCabecera.Columns[lccontcampos].ColumnName];
                            }
                        }
                        if (ofila != null)
                        {
                            CabFacturacion.Rows.Add(ofila);
                        }
                    }

                    for (nfila = 0; nfila <= LpDetalle.Rows.Count - 1; nfila++)
                    {
                        ofila = null;
                        ofila = VariablesPublicas.InsertIntoTable(DetFacturacion);
                        for (lccontcampos = 0; lccontcampos <= LpDetalle.Columns.Count - 1; lccontcampos++)
                        {
                            if (VariablesPublicas.SeekNameColumn(DetFacturacion, LpDetalle.Columns[lccontcampos].ColumnName))
                            {
                                ofila[DetFacturacion.Columns[lccontcampos].ColumnName] = LpDetalle.Rows[nfila][LpDetalle.Columns[lccontcampos].ColumnName];
                            }
                        }
                        if (ofila != null)
                        {
                            DetFacturacion.Rows.Add(ofila);
                        }
                    }
                    tmptablacab = CabFacturacion;
                    tmptabladet = DetFacturacion;
                    tmptablacab.AcceptChanges();
                    tmptabladet.AcceptChanges();

                    CargaDatos();
                    sw_novaluechange = false;
                    tmptablacab = null;
                    tmptabladet = null;
                }
            }
        }

        private void fechaRefer_ValueChanged(object sender, EventArgs e)
        {
            if (u_n_opsel == 0)
            {
                return;
            }
            actualizatipocambio();
            totalizarItem();
            totalizar();
        }

        private void btnInicial_Click(object sender, EventArgs e)
        {
            u_Roleo(Genericas.toprecord);
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            u_Roleo(Genericas.prevrecord);
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            u_Roleo(Genericas.nextrecord);
        }
        private void btnUltimo_Click(object sender, EventArgs e)
        {
            //u_Roleo(GlobalVars.GetInstance.BOTTRECORD)
            u_Roleo(Genericas.bottrecord);
        }
        public void u_Roleo(string xtipo)
        {
            string vmnum = "";
            tb_co_VentascabBL BL = new tb_co_VentascabBL();
            tb_co_Ventascab BE = new tb_co_Ventascab();

            BE.perianio = VariablesPublicas.perianio;
            BE.perimes = txtMes.Text;
            BE.moduloid = modulo.ToString();
            BE.local = local.ToString();
            BE.diarioid = cboSubdiario.Text.Substring(0, 4);
            BE.asiento = txtAsiento.Text;
            BE.tipo = xtipo;
            try
            {
                vmnum = BL.GetAsientoRoleo(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0].Rows[0]["numero"].ToString();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (vmnum.Trim().Length > 0)
            {
                txtMes.Focus();
                txtAsiento.Text = vmnum;
                procesanumero();
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan 
                    e.Handled = true;
                }
            }
        }

        private void txtNumFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan 
                    e.Handled = true;
                }
            }
        }
    }
}
