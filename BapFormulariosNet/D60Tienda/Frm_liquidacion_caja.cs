using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using LayerDataAccess;
using bapFunciones;

using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace BapFormulariosNet.D60Tienda
{
    public partial class Frm_liquidacion_caja : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = string.Empty;
        private String modulo = string.Empty;
        private String local = string.Empty;
        private DataTable TablaLiquidacion;
        private DataTable TablaLiquidacion_modal;
        private DataTable Tablabloqueo;
        private DataTable TablaCabeceras;
        private String ssModo = "NEW";
        private String XNIVEL = string.Empty;
        private DataRow row;

        private Int32 d1 = 0, d2 = 0, d3 = 0, d4 = 0,
        d5 = 0, d6 = 0, d7 = 0, d8 = 0;

        public Frm_liquidacion_caja()
        {
            InitializeComponent();
        }
        private void Frm_liquidacion_caja_Load(object sender, EventArgs e)
        {
            dominio = ((D60Tienda.MainTienda)MdiParent).dominioid;
            modulo = ((D60Tienda.MainTienda)MdiParent).moduloid;
            local = ((D60Tienda.MainTienda)MdiParent).local;

            _MetodoCabeceras();
            NameLocal();
            bloquear(false);
            _ArmandoTabla();
            limpiar();
            fecha.EditValue = DateTime.Today.ToString("d");
            ConsultaDatos();
            TableLoadRowLock();
            //fecha.EditValue = "21/01/2014";
        }

        private void ConsultaDatos()
        {
            var BE = new tb_t1_caja();
            var BL = new tb_t1_cajaBL();
            var dt = new DataTable();

            BE.moduloid = modulo;
            BE.local = local;
            BE.fecha = Convert.ToDateTime(fecha.Text);

            dt = BL.GetAllCab(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                loc_id.Text = dt.Rows[0]["local"].ToString().Trim();
                ValidaLocal(loc_id.Text);
                idadmin.Text = dt.Rows[0]["adminid"].ToString().Trim();
                ValidaPersona(idadmin.Text);
                idcajero.Text = dt.Rows[0]["cajeroid"].ToString().Trim();
                ValidaPerson2(idcajero.Text);
                chkcerrado.Checked = Convert.ToBoolean( dt.Rows[0]["cerrado"].ToString().Trim());

                btnNew.Enabled = false;
                btnEdit.Enabled = !Convert.ToBoolean(dt.Rows[0]["cerrado"].ToString().Trim());

                idadmin.Enabled = false;
                idcajero.Enabled = false;
                txttcambio.Enabled = false;

            }
            else
            {
                bloquear(false);
            }
            fecha.Enabled = true;
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ssModo = "NEW";
            bloquear(true);
            limpiar();
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            fecha.Enabled = false;
            TableLoadRowLock();
            MDI_dgb_liquidacion.DataSource = _CargarDetalle();
            _CargarVentas(Convert.ToDateTime(fecha.Text));
        }

        private void get_tipocambio(string fecha)
        {
            try
            {
                var BL = new tipocambioBL();
                var dt = new DataTable();

                dt = BL.GetOne(EmpresaID, Convert.ToDateTime(fecha)).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    txttcambio.Text = Convert.ToDecimal(dt.Rows[0]["venta"]).ToString();
                }
                else
                {
                    txttcambio.Text = "1";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NameLocal()
        {
            var dt = new DataTable();
            var Query = " Select * From tb_sys_local where dominioid = '" + dominio + "' " +
                           " and moduloid = '" + modulo + "' and local = '" + local + "' ";
            dt = Consultas(Query).Tables[0];

            if (dt.Rows.Count > 0)
            {
                loc_id.Text = dt.Rows[0]["local"].ToString();
                loc_name.Text = dt.Rows[0]["localname"].ToString();
            }
        }

        private DataSet Consultas(String Query)
        {
            var conex = new ConexionDA();
            using (var cnx = new SqlConnection(conex.empConexion(EmpresaID)))
            {
                using (var cmd = new SqlCommand("gspHelpSQL", cnx))
                {
                    var ds = new DataSet();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@sqlquery", SqlDbType.VarChar).Value = Query;
                    try
                    {
                        cnx.Open();
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                        }
                        return ds;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        private void limpiar()
        {
            NIVEL_FORMS();
            saldome.Equals(string.Empty);
            saldomn.Equals(string.Empty);
            idadmin.Equals(string.Empty);
            nameadmin.Equals(string.Empty);
            idcajero.Equals(string.Empty);
            namecajero.Equals(string.Empty);
            txttcambio.Equals(string.Empty);

            if (TablaLiquidacion != null)
            {
                TablaLiquidacion.Rows.Clear();
            }
            if (Tablabloqueo != null)
            {
                Tablabloqueo.Rows.Clear();
            }

            MDI_dgb_liquidacion.DataSource = TablaLiquidacion;
        }

        private void bloquear(Boolean var)
        {
            loc_id.Enabled = false;
            loc_name.Enabled = false;
            fecha.Enabled = var;
            saldomn.Enabled = false;
            saldome.Enabled = false;
            chkcerrado.Enabled = var;

            idadmin.Enabled = var;
            nameadmin.Enabled = false;
            idcajero.Enabled = var;
            namecajero.Enabled = false;
            txttcambio.Enabled = var;

            btnSave.Enabled = var;
            btnEdit.Enabled = var;
            btnDelete.Enabled = false;
            btnLoad.Enabled = false;
            btnInicio.Enabled = true;
            btnSiguiente.Enabled = true;
            btnAnterior.Enabled = true;
            btnUltimo.Enabled = true;
            btnLog.Enabled = false;
            MDI_dgb_liquidacion.Enabled = var;
        }

        private DataTable _CargarDetalle()
        {
            var BL = new tb_t1_cajaconceptoBL();
            var BE = new tb_t1_cajaconcepto();
            BE.filtro = "1";
            TablaLiquidacion = BL.GetAll(EmpresaID, BE).Tables[0];
            return TablaLiquidacion;
        }

        private void TableLoadRowLock()
        {
            var BE = new tb_t1_cajaconcepto();
            var BL = new tb_t1_cajaconceptoBL();
            var dt = new DataTable();
            BE.filtro = "1";
            dt = BL.GetOne(EmpresaID, BE).Tables[0];

            if (Tablabloqueo != null)
            {
                Tablabloqueo.Clear();
            }

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                row = Tablabloqueo.NewRow();
                row["fila"] = dt.Rows[i][0].ToString();
                Tablabloqueo.Rows.Add(row);
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var sw_prosigue = false;
            dgb_liquidacion.FocusedColumn = dgb_liquidacion.Columns["conceptoid"];
            if (ssModo == "NEW")
            {
                if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
                {
                    sw_prosigue = (MessageBox.Show("¿Desea Guardar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
                }
                if (sw_prosigue)
                {
                    Insert();
                }
            }
            else
            {
                if (XNIVEL == "0" || XNIVEL == "1")
                {
                    sw_prosigue = (MessageBox.Show("¿Desea Modificar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                    if (sw_prosigue)
                    {
                        Modificar();
                    }
                }
            }
        }

        private void NIVEL_FORMS()
        {
            XNIVEL = VariablesPublicas.Get_nivelperfil(VariablesPublicas.Perfil, Name).Substring(0, 1);
            if (XNIVEL != "0")
            {
                btnLock.Glyph = global::BapFormulariosNet.Properties.Resources.btn_Lock20;
            }
            else
            {
                btnLock.Glyph = global::BapFormulariosNet.Properties.Resources.btn_Un_Lock20;
            }
        }

        private void dgb_liquidacion_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
        }

        private void _ArmandoTabla()
        {
            TablaLiquidacion_modal = new DataTable("TablaLiquidacion_modal");
            TablaLiquidacion_modal.Columns.Add("moduloid", typeof(String));
            TablaLiquidacion_modal.Columns.Add("local", typeof(String));
            TablaLiquidacion_modal.Columns.Add("fecha", typeof(DateTime));
            TablaLiquidacion_modal.Columns.Add("conceptoid", typeof(String));
            TablaLiquidacion_modal.Columns.Add("glosa", typeof(String));
            TablaLiquidacion_modal.Columns.Add("cajaaccionid", typeof(String));
            TablaLiquidacion_modal.Columns.Add("importe1", typeof(Decimal));
            TablaLiquidacion_modal.Columns["importe1"].DefaultValue = 0;
            TablaLiquidacion_modal.Columns.Add("importe2", typeof(Decimal));
            TablaLiquidacion_modal.Columns["importe2"].DefaultValue = 0;
            TablaLiquidacion_modal.Columns.Add("usuar", typeof(String));
            TablaLiquidacion_modal.Columns.Add("fecre", typeof(DateTime));
            TablaLiquidacion_modal.Columns.Add("feact", typeof(DateTime));

            Tablabloqueo = new DataTable("TableLoadRowLock");
            Tablabloqueo.Columns.Add("fila", typeof(String));
        }

        private void Insert()
        {
            if (Valido())
            {
                try
                {
                    var BE = new tb_t1_caja();
                    var BL = new tb_t1_cajaBL();

                    BE.moduloid = modulo.ToString();
                    BE.local = local.ToString();
                    BE.fecha = Convert.ToDateTime(fecha.Text);
                    BE.tcambio = Convert.ToDecimal(txttcambio.Text);
                    BE.adminid = idadmin.Text.ToString();
                    BE.cajeroid = idcajero.Text.ToString();
                    BE.apertura1 = Convert.ToDecimal(saldomn.Text);
                    BE.apertura2 = Convert.ToDecimal(saldome.Text);
                    BE.cierre1 = Convert.ToDecimal(saldomn.Text);
                    BE.cierre2 = Convert.ToDecimal(saldome.Text);
                    BE.cerrado = chkcerrado.Checked;
                    BE.usuar = VariablesPublicas.Usuar.Trim();

                    if (TablaLiquidacion_modal != null)
                    {
                        TablaLiquidacion_modal.Clear();
                    }

                    for (var i = 0; i < dgb_liquidacion.RowCount; i++)
                    {
                        row = TablaLiquidacion_modal.NewRow();
                        row["moduloid"] = modulo.ToString();
                        row["local"] = local.ToString();
                        row["fecha"] = Convert.ToDateTime(fecha.Text);
                        row["conceptoid"] = dgb_liquidacion.GetRowCellValue(i, "conceptoid").ToString().Trim();
                        row["glosa"] = dgb_liquidacion.GetRowCellValue(i, "glosa").ToString().Trim();
                        row["cajaaccionid"] = dgb_liquidacion.GetRowCellValue(i, "cajaaccionid").ToString().Trim();
                        row["importe1"] = dgb_liquidacion.GetRowCellValue(i, "importe1").ToString().Trim();
                        row["importe2"] = dgb_liquidacion.GetRowCellValue(i, "importe2").ToString().Trim();
                        row["fecre"] = DateTime.Today;
                        row["feact"] = DateTime.Today;
                        row["usuar"] = VariablesPublicas.Usuar.Trim();

                        TablaLiquidacion_modal.Rows.Add(row);
                    }

                    if (BL.Insert(EmpresaID, BE, TablaLiquidacion_modal))
                    {
                        MessageBox.Show("Datos Grabados Correctamente !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bloquear(false);
                        btnNew.Enabled = true;
                        btnPrint.Enabled = true;
                        btnInicio.Enabled = true;
                        btnAnterior.Enabled = true;
                        btnSiguiente.Enabled = true;
                        btnUltimo.Enabled = true;
                        btnExit.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void Modificar()
        {
            if (Valido())
            {
                try
                {
                    var BE = new tb_t1_caja();
                    var BL = new tb_t1_cajaBL();

                    BE.moduloid = modulo.ToString();
                    BE.local = local.ToString();
                    BE.fecha = Convert.ToDateTime(fecha.Text);
                    BE.tcambio = Convert.ToDecimal(txttcambio.Text);
                    BE.adminid = idadmin.Text.ToString();
                    BE.cajeroid = idcajero.Text.ToString();
                    BE.apertura1 = Convert.ToDecimal(dgb_liquidacion.GetRowCellValue(1, "importe1").ToString().Trim());
                    BE.apertura2 = Convert.ToDecimal(dgb_liquidacion.GetRowCellValue(1, "importe2").ToString().Trim());
                    BE.cierre1 = Convert.ToDecimal(saldomn.Text);
                    BE.cierre2 = Convert.ToDecimal(saldome.Text);
                    BE.cerrado = chkcerrado.Checked;
                    BE.usuar = VariablesPublicas.Usuar.Trim();

                    if (TablaLiquidacion_modal != null)
                    {
                        TablaLiquidacion_modal.Clear();
                    }

                    for (var i = 0; i < dgb_liquidacion.RowCount; i++)
                    {
                        row = TablaLiquidacion_modal.NewRow();
                        row["moduloid"] = modulo.ToString();
                        row["local"] = local.ToString();
                        row["fecha"] = Convert.ToDateTime(fecha.Text);
                        row["conceptoid"] = dgb_liquidacion.GetRowCellValue(i, "conceptoid").ToString().Trim();
                        row["glosa"] = dgb_liquidacion.GetRowCellValue(i, "glosa").ToString().Trim();
                        row["cajaaccionid"] = dgb_liquidacion.GetRowCellValue(i, "cajaaccionid").ToString().Trim();
                        row["importe1"] = dgb_liquidacion.GetRowCellValue(i, "importe1").ToString().Trim();
                        row["importe2"] = dgb_liquidacion.GetRowCellValue(i, "importe2").ToString().Trim();
                        row["usuar"] = VariablesPublicas.Usuar.Trim();

                        TablaLiquidacion_modal.Rows.Add(row);
                    }

                    StringWriter sw = new StringWriter();
                    TablaLiquidacion_modal.WriteXml(sw);
                    string result = sw.ToString();

                    if (BL.Update(EmpresaID, BE, TablaLiquidacion_modal))
                    {
                        MessageBox.Show("Datos Modificados Correctamente !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bloquear(false);
                        btnNew.Enabled = true;
                        btnPrint.Enabled = true;
                        btnInicio.Enabled = true;
                        btnAnterior.Enabled = true;
                        btnSiguiente.Enabled = true;
                        btnUltimo.Enabled = true;
                        btnExit.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void fecha_TextChanged(object sender, EventArgs e)
        {
            get_tipocambio(fecha.Text);
            try
            {
                var BE = new tb_t1_caja();
                var BL = new tb_t1_cajaBL();

                BE.moduloid = modulo.ToString();
                BE.local = local.ToString();
                BE.fecha = Convert.ToDateTime(fecha.Text);
                BE.filtro = "1";

                if (TablaLiquidacion != null)
                {
                    TablaLiquidacion.Clear();
                }

                TablaLiquidacion = BL.DetalleActual(EmpresaID, BE).Tables[0];

                if (TablaLiquidacion.Rows.Count > 0)
                {
                    MDI_dgb_liquidacion.DataSource = TablaLiquidacion;
                }
                else
                {
                    MDI_dgb_liquidacion.DataSource = _CargarDetalle();
                }


                bloquear(true);
                MDI_dgb_liquidacion.Enabled = false;
                btnSave.Enabled = false;
                _CargarVentas(Convert.ToDateTime(fecha.Text));
                ConsultaDatos();
                _CalcularTotales("importe1");
                _CalcularTotales("importe2");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //dgb_liquidacion.ShowPrintPreview();
            try
            {
                if (Valido())
                {
                    var miForma = new Reportes.Frm_reportes();
                    miForma.Text = "LIQUIDACION DE CAJA";

                    miForma.moduloid = modulo;
                    miForma.local = local;
                    miForma.fechafin = fecha.Text;
                    miForma.formulario = "Frm_liquidacion_caja";
                    miForma.Show();
                }
                else
                {
                    MessageBox.Show("No hay datos de detalle ...!!!", "Imformacion", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool Valido()
        {
            bool xValido = true;

            if (dgb_liquidacion.RowCount <= 0)
            {
                MessageBox.Show("No hay datos de detalle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                xValido = false;
            }
            if (Convert.ToDecimal(txttcambio.Text) <= 1)
            {
                MessageBox.Show("Tipo de Cambio no Vàlido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                xValido = false;
            }
            if (Convert.ToDecimal(saldome.Text) < 0)
            {
                MessageBox.Show("Saldo en Moneda Extranjera no Vàlido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                xValido = false;
            }
            if (Convert.ToDecimal(saldomn.Text) < 0)
            {
                MessageBox.Show("Saldo en Moneda Nacional no Vàlido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                xValido = false;
            }
            if (idadmin.Text.Trim().Length < 4)
            {
                MessageBox.Show("Còdigo de Administrador no Vàlido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                xValido = false;
            }
            if (idcajero.Text.Trim().Length < 4)
            {
                MessageBox.Show("Còdigo de Cajero no Vàlido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                xValido = false;
            }

            return xValido;
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var sw_prosigue = false;
            sw_prosigue = (MessageBox.Show("Desea Cancelar Ingreso de Datos...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
            if (sw_prosigue)
            {
                Frm_liquidacion_caja_Load(sender, e);
            }
        }

        private void btnInicio_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            form_cargar_datos(Genericas.primero);
        }

        private void btnAnterior_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            form_cargar_datos(Genericas.anterior);
        }

        private void btnSiguiente_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            form_cargar_datos(Genericas.siguiente);
        }

        private void btnUltimo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            form_cargar_datos(Genericas.ultimo);
        }

        private void form_cargar_datos(String posicion)
        {
            try
            {
                limpiar();
                var BL = new tb_t1_cajaBL();
                var BE = new tb_t1_caja();
                var dt = new DataTable();

                if (fecha.Text.Trim().Length == 0)
                {
                    if (posicion.Trim().Length > 0)
                    {
                        MessageBox.Show("Indicar Una Fecha !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }

                BE.moduloid = modulo.ToString().Trim();
                BE.local = local.Trim();
                BE.fecha = Convert.ToDateTime(fecha.Text);
                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    limpiar();
                    ssModo = "EDIT";

                    loc_id.Text = dt.Rows[0]["local"].ToString().Trim();
                    ValidaLocal(loc_id.Text);
                    idadmin.Text = dt.Rows[0]["adminid"].ToString().Trim();
                    ValidaPersona(idadmin.Text);
                    idcajero.Text = dt.Rows[0]["cajeroid"].ToString().Trim();
                    ValidaPerson2(idcajero.Text);
                    txttcambio.Text = dt.Rows[0]["tcambio"].ToString().Trim();
                    fecha.EditValue = Convert.ToDateTime(dt.Rows[0]["fecha"].ToString());


                    fecha_TextChanged(fecha.Text, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ValidaLocal(String NameLocal)
        {
            if (NameLocal.Trim().Length > 0)
            {
                var BL = new sys_localBL();
                var BE = new tb_sys_local();

                var dt = new DataTable();
                BE.dominioid = dominio.ToString().Trim();
                BE.moduloid = modulo.ToString().Trim();
                BE.local = NameLocal.Trim().ToString();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    loc_id.Text = dt.Rows[0]["local"].ToString().Trim();
                    loc_name.Text = dt.Rows[0]["localname"].ToString().Trim();
                }
                else
                {
                    loc_id.Text = string.Empty;
                    loc_name.Text = string.Empty;
                }
            }
        }

        private void ValidaPersona(String NamePersona)
        {
            if (NamePersona.Trim().Length > 0)
            {
                var BL = new tb_t1_vendedorBL();
                var BE = new tb_t1_vendedor();

                var dt = new DataTable();
                BE.vendorid = idadmin.Text.ToString().Trim();

                dt = BL.GetAll(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    idadmin.Text = dt.Rows[0]["vendorid"].ToString().Trim();
                    nameadmin.Text = dt.Rows[0]["vendorname"].ToString().Trim();
                }
                else
                {
                    idadmin.Text = string.Empty;
                    nameadmin.Text = string.Empty;
                }
            }
        }

        private void ValidaPerson2(String NamePersona)
        {
            if (NamePersona.Trim().Length > 0)
            {
                var BL = new tb_t1_vendedorBL();
                var BE = new tb_t1_vendedor();

                var dt = new DataTable();
                BE.vendorid = idcajero.Text.ToString().Trim();

                dt = BL.GetAll(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    idcajero.Text = dt.Rows[0]["vendorid"].ToString().Trim();
                    namecajero.Text = dt.Rows[0]["vendorname"].ToString().Trim();
                }
                else
                {
                    idcajero.Text = string.Empty;
                    namecajero.Text = string.Empty;
                }
            }
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XNIVEL == "0")
            {
                ssModo = "EDIT";
                bloquear(true);

                btnCancel.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void btnLock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var miForma = new Ayudas.Form_user_admin();
                miForma.Owner = this;
                miForma.PasaDatos = RecibePermiso;
                miForma.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RecibePermiso(Boolean resultado1, String resultado2)
        {
            if (resultado1)
            {
                XNIVEL = "0";
                btnLock.Glyph = global::BapFormulariosNet.Properties.Resources.btn_Un_Lock20;
            }
        }

        private void idadmin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaAdministrador();
            }
        }

        private void AyudaAdministrador()
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "Ayuda Administradores";
                frmayuda.sqlquery = "SELECT vendorid,vendorname,ddnni FROM tb_t1_vendedor";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where";
                frmayuda.sqland = string.Empty;
                frmayuda.criteriosbusqueda = new string[] { "VENDEDOR", "CODIGO" };
                frmayuda.columbusqueda = "vendorname,vendorid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeAdmin;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RecibeAdmin(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            idadmin.Text = resultado1.ToString();
            nameadmin.Text = resultado2.ToString();
        }

        private void AyudaCajero(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "Ayuda Cajeros";
                frmayuda.sqlquery = "SELECT vendorid,vendorname,ddnni FROM tb_t1_vendedor";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where";
                frmayuda.sqland = string.Empty;
                frmayuda.criteriosbusqueda = new string[] { "CAJERO", "CODIGO" };
                frmayuda.columbusqueda = "vendorname,vendorid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeCajero;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RecibeCajero(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            idcajero.Text = resultado1.ToString();
            namecajero.Text = resultado2.ToString();
        }

        private void idcajero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaCajero(string.Empty);
            }
        }

        private void dgb_liquidacion_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            for (var i = 0; i < Tablabloqueo.Rows.Count; i++)
            {
                var n = Convert.ToInt32(Tablabloqueo.Rows[i][0].ToString());
                if (e.RowHandle == n)
                {
                    e.RepositoryItem = re_readonly1;
                }
            }
        }

        private void dgb_liquidacion_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "importe1")
            {
                _AcmImportesMN(e.Column.FieldName);
                _CalcularTotales(e.Column.FieldName);
            }
            if (e.Column.FieldName == "importe2")
            {
                _AcmImportesMN(e.Column.FieldName);
                _CalcularTotales(e.Column.FieldName);
            }
        }


        private void _MetodoCabeceras()
        {
            var Query = " SELECT conceptoid,fila,cajaaccionid FROM tb_t1_cajaconcepto AS ttc " +
                           " WHERE LEN(ttc.conceptoid) = 2 ";

            TablaCabeceras = Consultas(Query).Tables[0];
        }

        private void _AcmImportesMN(String Column_Name)
        {
            Decimal imp01 = 0, imp02 = 0, imp03 = 0, imp04 = 0,
            imp05 = 0, imp06 = 0, imp07 = 0, imp08 = 0;
            var signo = 1;
            if (d1 == 0)
            {
                for (var i = 0; i < dgb_liquidacion.RowCount; i++)
                {
                    var codi = dgb_liquidacion.GetRowCellValue(i, "conceptoid").ToString();
                    if (Equivalencias.Left(codi.Trim(), 2) == TablaCabeceras.Rows[0][0].ToString().Trim())
                    {
                        var n = i + 1;
                        var xn = Convert.ToDecimal(dgb_liquidacion.GetRowCellValue(n, Column_Name).ToString());
                        if (n == Convert.ToInt32(TablaCabeceras.Rows[1][1].ToString().Trim()))
                        {
                            xn = 0;
                        }
                        imp01 = imp01 + xn;
                    }
                }
                d1 = d1 + 1;
                if (imp01 >= 0)
                {
                    dgb_liquidacion.SetRowCellValue(Convert.ToInt32(TablaCabeceras.Rows[0][1].ToString()), Column_Name, imp01);
                    d1 = 0;
                    return;
                }
            }

            if (d2 == 0)
            {
                for (var i = 0; i < dgb_liquidacion.RowCount; i++)
                {
                    var codi = dgb_liquidacion.GetRowCellValue(i, "conceptoid").ToString();
                    if (Equivalencias.Left(codi.Trim(), 2) == TablaCabeceras.Rows[1][0].ToString().Trim())
                    {
                        var acc = dgb_liquidacion.GetRowCellValue(i + 1, "cajaaccionid").ToString();
                        var n = i + 1;

                        if (acc.ToString().Trim() == "10")
                        {
                            signo = 1;
                        }
                        else
                        {
                            signo = -1;
                        }
                        var xn = Convert.ToDecimal(dgb_liquidacion.GetRowCellValue(n, Column_Name).ToString());
                        if (n == Convert.ToInt32(TablaCabeceras.Rows[2][1].ToString().Trim()))
                        {
                            xn = 0;
                        }
                        imp02 = imp02 + (signo * xn);
                    }
                }
                d2 = d2 + 1;
                if (imp02 != null)
                {
                    dgb_liquidacion.SetRowCellValue(Convert.ToInt32(TablaCabeceras.Rows[1][1].ToString()), Column_Name, imp02);
                    d2 = 0;
                    return;
                }
            }

            if (d3 == 0)
            {
                for (var i = 0; i < dgb_liquidacion.RowCount; i++)
                {
                    var codi = dgb_liquidacion.GetRowCellValue(i, "conceptoid").ToString();
                    if (Equivalencias.Left(codi.Trim(), 2) == TablaCabeceras.Rows[2][0].ToString().Trim())
                    {
                        var acc = dgb_liquidacion.GetRowCellValue(i + 1, "cajaaccionid").ToString();
                        var n = i + 1;
                        if (acc.ToString().Trim() == "10")
                        {
                            signo = 1;
                        }
                        else
                        {
                            signo = -1;
                        }
                        var xn = Convert.ToDecimal(dgb_liquidacion.GetRowCellValue(n, Column_Name).ToString());
                        if (n == Convert.ToInt32(TablaCabeceras.Rows[3][1].ToString().Trim()))
                        {
                            xn = 0;
                        }
                        imp03 = imp03 + (signo * xn);
                    }
                }
                d3 = d3 + 1;
                if (imp03 != null)
                {
                    dgb_liquidacion.SetRowCellValue(Convert.ToInt32(TablaCabeceras.Rows[2][1].ToString()), Column_Name, imp03);
                    d3 = 0;
                    return;
                }
            }


            if (d4 == 0)
            {
                for (var i = 0; i < dgb_liquidacion.RowCount; i++)
                {
                    var codi = dgb_liquidacion.GetRowCellValue(i, "conceptoid").ToString();
                    if (Equivalencias.Left(codi.Trim(), 2) == TablaCabeceras.Rows[3][0].ToString().Trim())
                    {
                        var acc = dgb_liquidacion.GetRowCellValue(i + 1, "cajaaccionid").ToString();
                        var n = i + 1;
                        if (acc.ToString().Trim() == "10")
                        {
                            signo = 1;
                        }
                        else
                        {
                            signo = -1;
                        }
                        var xn = Convert.ToDecimal(dgb_liquidacion.GetRowCellValue(n, Column_Name).ToString());
                        if (n == Convert.ToInt32(TablaCabeceras.Rows[4][1].ToString().Trim()))
                        {
                            xn = 0;
                        }
                        imp04 = imp04 + (signo * xn);
                    }
                }
                d4 = d4 + 1;
                if (imp04 != null)
                {
                    dgb_liquidacion.SetRowCellValue(Convert.ToInt32(TablaCabeceras.Rows[3][1].ToString()), Column_Name, imp04);
                    d4 = 0;
                    return;
                }
            }
            if (d5 == 0)
            {
                for (var i = 0; i < dgb_liquidacion.RowCount; i++)
                {
                    var codi = dgb_liquidacion.GetRowCellValue(i, "conceptoid").ToString();
                    if (Equivalencias.Left(codi.Trim(), 2) == TablaCabeceras.Rows[4][0].ToString().Trim())
                    {
                        var acc = dgb_liquidacion.GetRowCellValue(i + 1, "cajaaccionid").ToString();
                        var n = i + 1;
                        if (acc.ToString().Trim() == "10")
                        {
                            signo = 1;
                        }
                        else
                        {
                            signo = -1;
                        }
                        var xn = Convert.ToDecimal(dgb_liquidacion.GetRowCellValue(n, Column_Name).ToString());
                        if (n == Convert.ToInt32(TablaCabeceras.Rows[5][1].ToString().Trim()))
                        {
                            xn = 0;
                        }
                        imp05 = imp05 + (signo * xn);
                    }
                }
                d5 = d5 + 1;
                if (imp05 != null)
                {
                    dgb_liquidacion.SetRowCellValue(Convert.ToInt32(TablaCabeceras.Rows[4][1].ToString()), Column_Name, imp05);
                    d5 = 0;
                    return;
                }
            }


            if (d6 == 0)
            {
                for (var i = 0; i < dgb_liquidacion.RowCount; i++)
                {
                    var codi = dgb_liquidacion.GetRowCellValue(i, "conceptoid").ToString();

                    if (Equivalencias.Left(codi.Trim(), 2) == TablaCabeceras.Rows[5][0].ToString().Trim())
                    {
                        var acc = dgb_liquidacion.GetRowCellValue(i + 1, "cajaaccionid").ToString();
                        var n = i + 1;
                        if (acc.ToString().Trim() == "10")
                        {
                            signo = 1;
                        }
                        else
                        {
                            signo = -1;
                        }
                        var xn = Convert.ToDecimal(dgb_liquidacion.GetRowCellValue(n, Column_Name).ToString());
                        if (n == Convert.ToInt32(TablaCabeceras.Rows[6][1].ToString().Trim()))
                        {
                            xn = 0;
                        }
                        imp06 = imp06 + (signo * xn);
                    }
                }
                d6 = d6 + 1;
                if (imp06 != null)
                {
                    dgb_liquidacion.SetRowCellValue(Convert.ToInt32(TablaCabeceras.Rows[5][1].ToString()), Column_Name, imp06);
                    d6 = 0;
                    return;
                }
            }

            if (d7 == 0)
            {
                for (var i = 0; i < dgb_liquidacion.RowCount; i++)
                {
                    var codi = dgb_liquidacion.GetRowCellValue(i, "conceptoid").ToString();

                    if (Equivalencias.Left(codi.Trim(), 2) == TablaCabeceras.Rows[6][0].ToString().Trim())
                    {
                        var acc = dgb_liquidacion.GetRowCellValue(i + 1, "cajaaccionid").ToString();
                        var n = i + 1;
                        if (acc.ToString().Trim() == "10")
                        {
                            signo = 1;
                        }
                        else
                        {
                            signo = -1;
                        }
                        var xn = Convert.ToDecimal(dgb_liquidacion.GetRowCellValue(n, Column_Name).ToString());
                        if (n == Convert.ToInt32(TablaCabeceras.Rows[7][1].ToString().Trim()))
                        {
                            xn = 0;
                        }
                        imp07 = imp07 + (signo * xn);
                    }
                }
                d7 = d7 + 1;
                if (imp07 != null)
                {
                    dgb_liquidacion.SetRowCellValue(Convert.ToInt32(TablaCabeceras.Rows[6][1].ToString()), Column_Name, imp07);
                    d7 = 0;
                    return;
                }
            }

            if (d8 == 0)
            {
                for (var i = 0; i < dgb_liquidacion.RowCount; i++)
                {
                    var codi = dgb_liquidacion.GetRowCellValue(i, "conceptoid").ToString();

                    if (Equivalencias.Left(codi.Trim(), 2) == TablaCabeceras.Rows[7][0].ToString().Trim())
                    {
                        var acc = dgb_liquidacion.GetRowCellValue(i, "cajaaccionid").ToString();

                        var n = i + 1;
                        if (acc.ToString().Trim() == "10")
                        {
                            signo = 1;
                        }
                        else
                        {
                            signo = -1;
                        }
                        if (n < dgb_liquidacion.RowCount)
                        {
                            var xn = Convert.ToDecimal(dgb_liquidacion.GetRowCellValue(n, Column_Name).ToString());
                            imp08 = imp08 + (signo * xn);
                        }
                    }
                }
                d8 = d8 + 1;
                if (imp07 != null)
                {
                    dgb_liquidacion.SetRowCellValue(Convert.ToInt32(TablaCabeceras.Rows[7][1].ToString()), Column_Name, imp08);
                    d8 = 0;
                    return;
                }
            }
        }


        private void _CalcularTotales(String Column_Name)
        {
            Decimal xsum20mn = 0, xsum10mn = 0;
            for (var i = 0; i < TablaCabeceras.Rows.Count; i++)
            {
                var accion = dgb_liquidacion.GetRowCellValue(i, "cajaaccionid").ToString();
                var fila = Convert.ToInt32(TablaCabeceras.Rows[i][1].ToString());
                if (accion == "10")
                {
                    var importe = Convert.ToDecimal(dgb_liquidacion.GetRowCellValue(fila, Column_Name).ToString());
                    xsum10mn = xsum10mn + importe;
                }

                if (accion == "20")
                {
                    var importe = Convert.ToDecimal(dgb_liquidacion.GetRowCellValue(fila, Column_Name).ToString());
                    xsum20mn = xsum20mn + importe;
                }
            }

            if (Equivalencias.Right(Column_Name.Trim(), 1) == "1")
            {
                saldomn.Text = (xsum10mn + xsum20mn).ToString("###,###,##0.0000");
            }
            else
            {
                saldome.Text = (xsum10mn + xsum20mn).ToString("###,###,##0.0000");
            }
        }

        private void _CargarVentas(DateTime fecha)
        {
            DataTable Dt_glosa, Dt_name;
            var Query = " SELECT tipodoc,('DE : '+MIN(numdoc)+ ' - ' +MAX(numdoc))name,sum(totimporte)total,tmm.fechdoc " +
                           " FROM tb_me_movimientoscab AS tmm	" +
                           " WHERE " +
                           " tmm.moduloid= '" + modulo + "' " +
                           " AND tmm.local= '" + local + "' " +
                           " AND tmm.tipodoc NOT IN('GI','GS','II') " +
                                       " AND tmm.fechdoc = '" + fecha.ToString("yyyyMMdd") + "' " +
                           " GROUP BY tipodoc,tmm.fechdoc ";


            var Query2 = " SELECT conceptoid, " +
                            "  conceptosigla, " +
                            " fila  " +
                            " FROM tb_t1_cajaconcepto AS ttc " +
                            " WHERE	LEFT(conceptoid,2) = '02' AND LEN(conceptoid) > 2 ";

            Dt_glosa = new DataTable();
            Dt_glosa = Consultas(Query).Tables[0];

            if (Dt_glosa.Rows.Count > 0)
            {
                for (var j = 0; j < Dt_glosa.Rows.Count; j++)
                {
                    Dt_name = new DataTable();
                    Dt_name = Consultas(Query2).Tables[0];
                    var tipo_doc = Dt_glosa.Rows[j][0].ToString();
                    for (var i = 0; i < Dt_name.Rows.Count; i++)
                    {
                        if (tipo_doc.Trim() == Dt_name.Rows[i][1].ToString())
                        {
                            dgb_liquidacion.SetRowCellValue(Convert.ToInt32(Dt_name.Rows[i][2].ToString()), "glosa", Dt_glosa.Rows[j][1].ToString());
                            var de = Convert.ToDecimal(Dt_glosa.Rows[j][2].ToString());
                            dgb_liquidacion.SetRowCellValue(Convert.ToInt32(Dt_name.Rows[i][2].ToString()), "importe1", de);
                        }
                    }
                }
            }
        }
    }
}
