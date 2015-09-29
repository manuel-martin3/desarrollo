using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;


namespace BapFormulariosNet.D70Produccion
{
    public partial class Frm_orden_servicio_old : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "";
        private String modulo = "";
        private String local = "";

        private String XNIVEL = "";
        private String XGLOSA = "";
        private String PERFILID = "";
        private DataRow row;
        private Boolean procesado = false;
        private String ActCtacte = "";
        private String ssModo = "";
   
        private DataTable TablaOrdenServ;


        public Frm_orden_servicio_old()
        {
            InitializeComponent();
        }

        private void Frm_req_produccion_Load(object sender, EventArgs e)
        {
            if (Parent.Parent.Name == "MainProduccion")
            {
                dominio = ((D70Produccion.MainProduccion)MdiParent).dominioid;
                modulo = ((D70Produccion.MainProduccion)MdiParent).moduloid;
                local = ((D70Produccion.MainProduccion)MdiParent).local;
                PERFILID = ((D70Produccion.MainProduccion)MdiParent).perfil;
            }

            if (Parent.Parent.Name == "MainTienda")
            {
                dominio = ((D60Tienda.MainTienda)MdiParent).dominioid;
                modulo = ((D60Tienda.MainTienda)MdiParent).moduloid;
                local = ((D60Tienda.MainTienda)MdiParent).local;
                PERFILID = ((D60Tienda.MainTienda)MdiParent).perfil;
            }

            NIVEL_FORMS();
            //CargarSerieOP();
            data_cbo_moneda();
            CargarTipoOrden();
            CargarformaPago();
            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_salir.Enabled = true;                     
            TmpTablaOrdenProd();
          
        }


        void CargarTipoOrden()
        {
            DataTable dt;
            dt = new DataTable("Tabla");

            dt.Columns.Add("tipordenid");
            dt.Columns.Add("tipordenname");

            DataRow dr;

            dr = dt.NewRow();
            dr["tipordenid"] = "I";
            dr["tipordenname"] = "Interno";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["tipordenid"] = "E";
            dr["tipordenname"] = "Externo";
            dt.Rows.Add(dr);

            this.cmb_tiporden.DataSource = dt;
            this.cmb_tiporden.ValueMember = "tipordenid";
            this.cmb_tiporden.DisplayMember = "tipordenname";  
        }
        
        void CargarformaPago()
        {
            tb_condpago BE = new tb_condpago();
            tb_condpagoBL BL = new tb_condpagoBL();
            DataTable dt = new DataTable();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            cmb_formapago.DataSource = dt;
            cmb_formapago.DisplayMember = "condpagoname";
            cmb_formapago.ValueMember = "condpagoid";
        }

        private void data_cbo_moneda()
        {
            try
            {
                var BL = new tb_co_tabla04_tipomonedaBL();
                var BE = new tb_co_tabla04_tipomoneda();
                var dt = new DataTable();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                cmb_moneda.DataSource = dt;
                cmb_moneda.ValueMember = "monedaid";
                cmb_moneda.DisplayMember = "sigla";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void TmpTablaOrdenProd()
        {
            TablaOrdenServ = new DataTable();
            TablaOrdenServ.Columns.Add("proceso", typeof(String));
            TablaOrdenServ.Columns.Add("ordenprod", typeof(String));
            TablaOrdenServ.Columns.Add("articid", typeof(String));
            TablaOrdenServ.Columns.Add("articidold", typeof(String));
            TablaOrdenServ.Columns.Add("articname", typeof(String));
            TablaOrdenServ.Columns.Add("colorid", typeof(String));
            TablaOrdenServ.Columns.Add("cantidad", typeof(Int32));
            TablaOrdenServ.Columns.Add("marca", typeof(String));
            TablaOrdenServ.Columns.Add("peso", typeof(Decimal));
            TablaOrdenServ.Columns.Add("precuni", typeof(Decimal));
            TablaOrdenServ.Columns.Add("precunipeso", typeof(Decimal));
            TablaOrdenServ.Columns.Add("importe", typeof(Decimal));
        }


        private void NIVEL_FORMS()
        {
            XNIVEL = VariablesPublicas.Get_nivelperfil(PERFILID, Name).Substring(0, 1);
            if (XNIVEL != "0")
            {
                btn_clave.Glyph = global::BapFormulariosNet.Properties.Resources.btn_Lock20;
            }
            else
            {
                btn_clave.Glyph = global::BapFormulariosNet.Properties.Resources.btn_Un_Lock20;
            }
        }

        void CargarSerieOP()
        {
            tb_pp_ordenserieBL BL = new tb_pp_ordenserieBL();
            tb_pp_ordenserie BE = new tb_pp_ordenserie();
            DataTable dt = new DataTable();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            //cmb_serieop.DataSource = dt;
            //cmb_serieop.ValueMember = "perianio";
            //cmb_serieop.DisplayMember = "ser_op";
        }

        private void btn_nuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XNIVEL == "0")
            {
                nuevo();
                Gen_numReq(); 
                //txt_numos.Text = "0000000001";

                if (TablaOrdenServ != null)
                {
                    TablaOrdenServ.Rows.Clear();
                }
                //pdtimagen.Visible = false;
                txt_ctacte.Focus();
            }
        }

        private void Gen_numReq()
        {
            try
            {
                var BL = new tb_pp_ordenservicioBL();
                var BE = new tb_pp_ordenservicio();
                var dt = new DataTable();

                BE.dominioid = dominio.ToString();
                BE.moduloid = modulo.ToString();
                BE.localid = local.ToString();
                BE.tipos = txt_tipos.Text.ToUpper().Trim();
                BE.seros = txt_seros.Text.ToUpper().Trim();

                dt = BL.GetAll_NUM(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    txt_numos.Text = dt.Rows[0]["numordserv"].ToString();
                }
                else
                {
                    MessageBox.Show("Asignar la Accion del Documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void nuevo()
        {
            limpiar_documento();
            form_bloqueado(true);
            btn_nuevo.Enabled = false;
            btn_editar.Enabled = false;
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_log.Enabled = true;
            ssModo = "NEW";
            
        }


        private void btn_editar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XNIVEL == "0") // SEGUN UN USUARIO ADMIN PUEDE TENER ACCESO A UNA MODIFICACION TOTAL
            {
                if (Equivalencias.Left(txt_numos.Text, 1) == "_")// LE PONGO GUION BAJO CUANDO LIMPIO EL DOCUMENTO
                {
                    MessageBox.Show("No Existe Numero de Doc. a Modificar ..!!!", "Mensaje");
                }
                else
                {
                    ssModo = "EDIT";
                    form_bloqueado(true);
                    btn_cancelar.Enabled = true;
                    btn_grabar.Enabled = true;
                    btn_eliminar.Enabled = true;

                    // LO COMENTO PORQUE YA NO ES NECESARIO HACER NINGUNA INTERACCION CON EL DETALLE

                    //dgv_requerimiento.ReadOnly = false;
                    //for (int j = 0; j < dgv_requerimiento.ColumnCount - 3; j++)                    
                    //    dgv_requerimiento.Columns[j].ReadOnly = true;                    
                    //dgv_requerimiento.Columns[dgv_requerimiento.ColumnCount - 1].ReadOnly = true;
                }
            }
        }

       private void AyudaClientes()
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "Ayuda Cliente/Proveedor";
                frmayuda.sqlquery = "SELECT ctacte, ctactename, nmruc, direc FROM tb_cliente";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "WHERE";
                frmayuda.sqland = string.Empty;
                frmayuda.criteriosbusqueda = new string[] { "CLIENTE", "RUC", "CODIGO" };
                frmayuda.columbusqueda = "ctactename,nmruc,ctacte";
                frmayuda.returndatos = "0,2,1,3";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeClientes;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }

        private void ValidaCliente()
        {
            if (txt_ctacte.Text.Trim().Length > 0)
            {
                var BL = new clienteBL();
                var BE = new tb_cliente();
                var dt = new DataTable();

                BE.ctacte = txt_ctacte.Text.Trim().PadLeft(7, '0');
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    txt_ctacte.Text = dt.Rows[0]["ctacte"].ToString().Trim();
                    txt_ctactename.Text = dt.Rows[0]["ctactename"].ToString().Trim();
                    txt_nmruc.Text = dt.Rows[0]["nmruc"].ToString().Trim();
                    txt_direcc.Text = dt.Rows[0]["direc"].ToString().Trim();
                    txt_telef.Text = dt.Rows[0]["telef1"].ToString().Trim();
                }
                else
                {
                    txt_ctacte.Text = string.Empty;
                    txt_ctactename.Text = string.Empty;
                    txt_nmruc.Text = "";
                    txt_direcc.Text = "";
                    txt_telef.Text = "";
                }
            }
        }

        private void RecibeClientes(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {                
                txt_ctacte.Text = resultado1.Trim();
                txt_ctactename.Text = resultado3.Trim();
                ValidaCliente();
            }
        }

        private void form_bloqueado(Boolean var)
        {
            try
            {
                txt_fechini.Enabled = false;
                txt_fechentrega.Enabled = var;
                txt_ctacte.Enabled = var;

                cmb_tiporden.Enabled = var;
                cmb_formapago.Enabled = var;
                cmb_moneda.Enabled = var;
                cmb_tipdocsalida.Enabled = var;
                cmb_tipgr.Enabled = var;

                dgv_ordenservicio.Enabled = var;

                btn_agregarOP.Enabled = var;

                gr_tipos.Enabled = false;
                btn_nuevo.Enabled = false;
                btn_editar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_grabar.Enabled = false;
                btn_eliminar.Enabled = false;
                btn_imprimir.Enabled = false;
                btn_clave.Enabled = true;
                btn_log.Enabled = true;
                btn_salir.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            form_accion_cancelEdicion(1);
        }

        private void form_accion_cancelEdicion(int confirnar)
        {
            var sw_prosigue = true;
            if (confirnar == 1)
            {
                sw_prosigue = (MessageBox.Show("Desea cancelar ingreso de datos...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
            }
            else
            {
                sw_prosigue = true;
            }
            if (sw_prosigue)
            {
                NIVEL_FORMS();
                limpiar_documento();
                form_bloqueado(false);
                btn_nuevo.Enabled = true;
                btn_salir.Enabled = true;
                ssModo = "OTR";
                if (TablaOrdenServ.Rows.Count > 0)
                    TablaOrdenServ.Rows.Clear();

            }
        }

        private void limpiar_documento()
        {
            try
            {
                txt_busqueda.Text = "";
                txt_fechini.Text = DateTime.Today.ToShortDateString();
                txt_fechentrega.Text = "";

                txt_ctacte.Text = "";
                txt_ctactename.Text = "";
                txt_nmruc.Text = "";
                txt_telef.Text = "";
                txt_direcc.Text = "";

                txt_autorizaid.Text = "";
                txt_autorizaname.Text = "";

                rdb_servid.SelectedIndex = -1;

                txt_observacion.Text = "";
                cmb_tipgr.SelectedIndex = -1;
                txt_numgr.Text = "";
                txt_numdocsalida.Text = "";
                cmb_tiporden.SelectedIndex = -1;
                cmb_formapago.SelectedIndex = -1;
                cmb_moneda.SelectedIndex = -1;
                cmb_tipdocsalida.SelectedIndex = -1;

                txt_totprendas.Text = "0";
                txt_totpeso.Text = "0.0";
                txt_subtotal.Text = "0.0";
                txt_igv.Text = "0.0";
                txt_totneto.Text = "0.0";
                              
                txt_numos.Text = "__________";                
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_grabar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            procesado = false;
            var sw_prosigue = false;
            if (ssModo == "NEW")
            {
                //if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
                if (XNIVEL == "0") // EL UNICO QUE PUEDE HACER UN NUEVO PEDIDO CUANDO ES XNIVEL = 0
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
                        Update();
                    }
                }
            }
            if (procesado)
            {
                NIVEL_FORMS();
                limpiar_documento();
                //DataOrdenProduccion();                            
                form_bloqueado(false);
                btn_nuevo.Enabled = true;
                btn_salir.Enabled = true;
                if (TablaOrdenServ != null)                
                    TablaOrdenServ.Rows.Clear();                
            }
        }


        private void Insert()
        {
            try
            {
                if (txt_fechentrega.Text.Length == 0)
                {
                    MessageBox.Show("Indicar la Fecha de Entrega ...","Verificar");
                    return;
                }
                else
                {
                    tb_pp_ordenservicioBL BL = new tb_pp_ordenservicioBL();
                    tb_pp_ordenservicio BE = new tb_pp_ordenservicio();
                    var Items = new tb_pp_ordenservicio.Item();
                    var ListaItems = new List<tb_pp_ordenservicio.Item>();

                    #region Variables de Orden-Servicio Cabecera
                    BE.tipos = txt_tipos.Text;
                    BE.seros = txt_seros.Text;
                    BE.numos = txt_numos.Text;
                    BE.tipfac = cmb_tipdocsalida.Text;
                    BE.serfac = "0001";
                    BE.numfac = txt_numdocsalida.Text;
                    BE.tipgr = "";
                    BE.sergr = "";
                    BE.numgr = "";
                    //BE.tipdoc = cmb_tipgr.Text;
                    //BE.serdoc = "0001";
                    //BE.numdoc = txt_numgr.Text;
                    //BE.fechini = Convert.ToDateTime(txt_fechini.Text);
                    //BE.fechfin = Convert.ToDateTime(txt_fechentrega.Text);
                    //BE.ctacteprov = txt_ctacte.Text;
                    //BE.tiporden = cmb_tiporden.SelectedValue.ToString();
                    //BE.condpagoid = cmb_formapago.SelectedValue.ToString();
                    //BE.monedaid = cmb_moneda.SelectedValue.ToString();
                    //BE.fechautoriza = Convert.ToDateTime(txt_fechautori.Text);
                    //BE.estado = "0";
                    //BE.totalcant = Convert.ToInt32(txt_totprendas.Text);
                    //BE.totalpeso = Convert.ToDecimal(txt_totpeso.Text);
                    //BE.totalimp = Convert.ToDecimal(txt_subtotal.Text);
                    //BE.totaligv = Convert.ToDecimal(txt_igv.Text);
                    //BE.totalneto = Convert.ToDecimal(txt_totneto.Text);
                    //BE.usuar = VariablesPublicas.Usuar.Trim().ToUpper();
                    //BE.observacion = txt_observacion.Text;
                    //BE.servid = rdb_servid.EditValue.ToString();

                    #endregion

                    if (dgv_ordenservicio.Rows.Count > 0 && dgv_ordenservicio.ColumnCount > 0)
                    {
                        for (int i = 0; i < dgv_ordenservicio.RowCount; i++)
                        {
                            Items = new tb_pp_ordenservicio.Item();
                            Items.proceso = dgv_ordenservicio.Rows[i].Cells["proceso"].Value.ToString();
                            Items.tipop = "OP";
                            string xserdoc = Equivalencias.Left(dgv_ordenservicio.Rows[i].Cells["ordenprod"].Value.ToString(), 4);
                            string xnumop = Equivalencias.Right(dgv_ordenservicio.Rows[i].Cells["ordenprod"].Value.ToString(), 1).PadLeft(10, '0');
                            Items.serop = xserdoc;
                            Items.numop = xnumop;
                            Items.marcaid = dgv_ordenservicio.Rows[i].Cells["marcaid"].Value.ToString();
                            Items.articid = dgv_ordenservicio.Rows[i].Cells["articid"].Value.ToString();          
                            Items.colorid = dgv_ordenservicio.Rows[i].Cells["colorid"].Value.ToString();
                            Items.cantidad = Convert.ToInt32(dgv_ordenservicio.Rows[i].Cells["cantidad"].Value.ToString());
                            Items.unmed = dgv_ordenservicio.Rows[i].Cells["unmed"].Value.ToString();
                            Items.peso = Convert.ToDecimal(dgv_ordenservicio.Rows[i].Cells["peso"].Value.ToString());
                            //Items.precuni = Convert.ToDecimal(dgv_ordenservicio.Rows[i].Cells["precuni"].Value.ToString());
                            //Items.precunipeso = Convert.ToDecimal(dgv_ordenservicio.Rows[i].Cells["precunipeso"].Value.ToString());
                            Items.importe = Convert.ToDecimal(dgv_ordenservicio.Rows[i].Cells["importe"].Value.ToString());
                            ListaItems.Add(Items);
                        }
                    }

                    BE.ListaItems = ListaItems;

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

        private void Update()
        {
            try
            {

                tb_pp_ordenservicioBL BL = new tb_pp_ordenservicioBL();
                tb_pp_ordenservicio BE = new tb_pp_ordenservicio();
                var Items = new tb_pp_ordenservicio.Item();
                var ListaItems = new List<tb_pp_ordenservicio.Item>();


                #region Variables de Orden-Servicio Cabecera

                BE.tipos = txt_tipos.Text;
                BE.seros = txt_seros.Text;
                BE.numos = txt_numos.Text;
                BE.tipfac = cmb_tipdocsalida.Text;
                BE.serfac = "0001";
                BE.numfac = txt_numdocsalida.Text;
                BE.tipgr = "";
                BE.sergr = "";
                BE.numgr = "";
                //BE.tipdoc = cmb_tipgr.Text;
                //BE.serdoc = "0001";
                //BE.numdoc = txt_numgr.Text;
                //BE.fechini = Convert.ToDateTime(txt_fechini.Text);
                //BE.fechfin = Convert.ToDateTime(txt_fechentrega.Text);
                //BE.ctacteprov = txt_ctacte.Text;
                //BE.tiporden = cmb_tiporden.SelectedValue.ToString();
                //BE.condpagoid = cmb_formapago.SelectedValue.ToString();
                //BE.monedaid = cmb_moneda.SelectedValue.ToString();
                //BE.fechautoriza = Convert.ToDateTime(txt_fechautori.Text);
                //BE.estado = "0";
                //BE.totalcant = Convert.ToInt32(txt_totprendas.Text);
                //BE.totalpeso = Convert.ToDecimal(txt_totpeso.Text);
                //BE.totalimp = Convert.ToDecimal(txt_subtotal.Text);
                //BE.totaligv = Convert.ToDecimal(txt_igv.Text);
                //BE.totalneto = Convert.ToDecimal(txt_totneto.Text);
                //BE.usuar = VariablesPublicas.Usuar.Trim().ToUpper();
                //BE.observacion = txt_observacion.Text;
                //BE.servid = rdb_servid.EditValue.ToString();

                #endregion

                if (dgv_ordenservicio.Rows.Count > 0 && dgv_ordenservicio.ColumnCount > 0)
                {
                    for (int i = 0; i < dgv_ordenservicio.RowCount; i++)
                    {
                        Items = new tb_pp_ordenservicio.Item();
                        Items.proceso = dgv_ordenservicio.Rows[i].Cells["proceso"].Value.ToString();
                        Items.marcaid = dgv_ordenservicio.Rows[i].Cells["marca"].Value.ToString();
                        Items.articid = dgv_ordenservicio.Rows[i].Cells["articid"].Value.ToString();
                        Items.coltalla = dgv_ordenservicio.Rows[i].Cells["coltalla"].Value.ToString();
                        Items.colorid = dgv_ordenservicio.Rows[i].Cells["colorid"].Value.ToString();
                        Items.cantidad = Convert.ToInt32(dgv_ordenservicio.Rows[i].Cells["cantidad"].Value.ToString());
                        Items.unmed = dgv_ordenservicio.Rows[i].Cells["unmed"].Value.ToString();
                        Items.peso = Convert.ToDecimal(dgv_ordenservicio.Rows[i].Cells["peso"].Value.ToString());
                        //Items.precuni = Convert.ToDecimal(dgv_ordenservicio.Rows[i].Cells["precuni"].Value.ToString());
                        //Items.precunipeso = Convert.ToDecimal(dgv_ordenservicio.Rows[i].Cells["precunipeso"].Value.ToString());
                        Items.importe = Convert.ToDecimal(dgv_ordenservicio.Rows[i].Cells["importe"].Value.ToString());
                        ListaItems.Add(Items);
                    }
                }

                BE.ListaItems = ListaItems;

                if (BL.Update(EmpresaID, BE))
                {
                    SEGURIDAD_LOG("M");
                    MessageBox.Show("Datos Modificado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    procesado = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Delete()
        {
            try
            {
                if (txt_numos.Text.Length == 0)
                {
                    MessageBox.Show("Falta Número de Requerimiento", "Mensaje");
                    return;
                }
                else
                {
                    tb_pp_requerimientoprodBL BL = new tb_pp_requerimientoprodBL();
                    tb_pp_requerimientoprod BE = new tb_pp_requerimientoprod();
                    BE.tipreq = txt_tipos.Text;
                    BE.serreq = txt_seros.Text;
                    BE.numreq = txt_numos.Text;
                    BE.idx = "DEL";


                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos Eliminado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        limpiar_documento();
                        form_bloqueado(false);
                        //CargarDatos();                    
                        btn_nuevo.Enabled = true;
                        if (TablaOrdenServ != null)
                            TablaOrdenServ.Rows.Clear(); 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SEGURIDAD_LOG(String accion)
        {
            var xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio;
            try
            {
                var BL = new tb_co_seguridadlogBL();
                var BE = new tb_co_seguridadlog();

                BE.moduloid = Name;
                BE.clave = xclave;
                BE.cuser = VariablesPublicas.Usuar;
                BE.fecha = DateTime.Now;
                BE.pc = VariablesPublicas.userip;
                BE.accion = accion.Trim();
                //BE.detalle = txt_numreq.Text.Trim() + "/" + "PP-" + cmb_serieop.Text + "-" + txt_numop01.Text.Trim().ToUpper() + "/" + XGLOSA;

                BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_eliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XNIVEL == "0")
            {
                var sw_prosigue = false;
                sw_prosigue = (MessageBox.Show("¿Desea Eliminar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                if (sw_prosigue)
                {
                    Delete();
                }
            }
        }

        private void btn_imprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_log_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_clave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                XGLOSA = resultado2.Trim();
                btn_clave.Glyph = global::BapFormulariosNet.Properties.Resources.btn_Un_Lock20;
            }
        }

        private void btn_salir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void txt_numop01_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String xnumop = "";
                //xnumop = txt_numop01.Text.PadLeft(10, '0');

                //if (cmb_serieop.SelectedIndex == 0)
                //{
                //    MessageBox.Show("Seleccione una Serie OP", "Mensaje");
                //    return;
                //}
                //else if (ValidaDet(cmb_serieop.Text,xnumop))
                //{
                    // CARGAMOS EL DETALLE                    
                    tb_pp_requerimientoprod BE = new tb_pp_requerimientoprod();
                    tb_pp_requerimientoprodBL BL = new tb_pp_requerimientoprodBL();
                    DataTable dt = new DataTable();
                    BE.tipop = "PP";
                    //BE.serop = cmb_serieop.Text;
                    BE.numop = xnumop.ToString();

                    dt = BL.GetAllOrden_PIVOT(EmpresaID, BE).Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow fila in dt.Rows)
                        {
                            row = TablaOrdenServ.NewRow();
                            //dgv_requerimiento.Rows[cont + 1].Cells["ordenprod"].Value = fila["ordenprod"].ToString().Trim();
                            //cont++;
                            row["tipop"] = fila["tipop"].ToString();
                            row["serop"] = fila["serop"].ToString();
                            row["numop"] = fila["numop"].ToString().Trim();

                            row["ordenprod"] = fila["ordenprod"].ToString().Trim();
                            row["familiatelaid"] = fila["familiatelaid"].ToString().Trim();
                            row["articid"] = fila["articid"].ToString().Trim();
                            row["articidold"] = fila["articidold"].ToString().Trim();

                            row["colorid"] = fila["colorid"].ToString().Trim();
                            row["colorname"] = fila["colorname"].ToString().Trim();

                            row["can01"] = fila["can01"].ToString().Trim();
                            row["can02"] = fila["can02"].ToString().Trim();
                            row["can03"] = fila["can03"].ToString().Trim();
                            row["can04"] = fila["can04"].ToString().Trim();
                            row["can05"] = fila["can05"].ToString().Trim();
                            row["can06"] = fila["can06"].ToString().Trim();
                            row["can07"] = fila["can07"].ToString().Trim();
                            row["can08"] = fila["can08"].ToString().Trim();
                            row["can09"] = fila["can09"].ToString().Trim();
                            row["can10"] = fila["can10"].ToString().Trim();
                            row["can11"] = fila["can11"].ToString().Trim();
                            row["can12"] = fila["can12"].ToString().Trim();

                            row["panios"] = fila["panios"].ToString().Trim();
                            row["totprendas"] = fila["totprendas"].ToString().Trim();

                            TablaOrdenServ.Rows.Add(row);
                        }

                        dgv_ordenservicio.DataSource = TablaOrdenServ;
                    }
                    else
                        MessageBox.Show("NO Existe OP","Mensaje");

                    //txt_numop01.Text = "";

                    // LO COMENTO PORQUE YA NO ES NECESARIO HACER NINGUNA INTERACCION CON EL DETALLE

                    //dgv_requerimiento.Enabled = true;
                    //dgv_requerimiento.ReadOnly = false;
                    //for (int j = 0; j < dgv_requerimiento.ColumnCount - 3; j++)                    
                    //    dgv_requerimiento.Columns[j].ReadOnly = true;                                       
                    //dgv_requerimiento.Columns[dgv_requerimiento.ColumnCount - 1].ReadOnly = true;                   
                //}
            }
        }

        Boolean ValidaDet(String xserop,String xnumop)
        {
            Boolean valor = true;
            String xseropgrid,xnumopgrid;
            int cont = 0;
            foreach (DataGridViewRow fila in dgv_ordenservicio.Rows)
            {
                xseropgrid = fila.Cells["serop"].Value.ToString();
                xnumopgrid = fila.Cells["numop"].Value.ToString();
                if (xserop.Equals(xseropgrid) && xnumop.Equals(xnumopgrid))
                {
                    valor = false;
                    cont++;
                    if(cont == 1)
                        MessageBox.Show("Existen Datos Iguales en el Detalle ... Cambiarlo", "Mensaje");
                }
            }

            return valor;
        }        


        private void txt_servcorteid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Ayudaservicio();
            }

            if (e.KeyCode == Keys.Enter)
            {
                ValidaServicio();
            }
        }


        private void Ayudaservicio()
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "<< AYUDA TABLA SERVICIO CORTE >>";
                frmayuda.sqlquery = "SELECT servcorteid,servcortename FROM tb_pp_servcorte ";
                frmayuda.sqlinner = "";
                frmayuda.sqlwhere = "where";
                frmayuda.sqland = "";
                frmayuda.criteriosbusqueda = new string[] { "CORTE", "CODIGO" };
                frmayuda.columbusqueda = "servcortename,servcorteid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeServicio;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RecibeServicio(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                //txt_servcorteid.Text = resultado1.Trim();
                //txt_servcortename.Text = resultado2.Trim();
            }
        }

        private void txt_servcorteid_KeyUp(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (txt_servcorteid.Text.Length == 2)
            //        ValidaServicio();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}            
        }

        void ValidaServicio()
        {
            //tb_pp_servcorte BE = new tb_pp_servcorte();
            //tb_pp_servcorteBL BL = new tb_pp_servcorteBL();
            //DataTable dt = new DataTable();
            //BE.servcorteid = txt_servcorteid.Text;
            //BE.servcortename = txt_servcortename.Text;

            //try
            //{
            //    dt = BL.GetAll(EmpresaID, BE).Tables[0];
            //    if (dt.Rows.Count > 0)
            //    {
            //        txt_servcorteid.Text = dt.Rows[0]["servcorteid"].ToString();
            //        txt_servcortename.Text = dt.Rows[0]["servcortename"].ToString();
            //    }
            //    else
            //    {
            //        txt_servcorteid.Text = "";
            //        txt_servcortename.Text = "";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void dgv_requerimiento_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // PRIMERO VERIFICAMOS EL RDB_SERVID 
            if (rdb_servid.SelectedIndex == 1)
            {
                if (dgv_ordenservicio.Columns[e.ColumnIndex].Name.ToUpper() == "precuni".ToUpper())
                {
                    Int32  xcantidad = 0;
                    Decimal xprecuni = 0, ximporte = 0;
                    xcantidad = Convert.ToInt32(dgv_ordenservicio.Rows[dgv_ordenservicio.CurrentCell.RowIndex].Cells["cantidad"].Value);
                    xprecuni = Convert.ToDecimal(dgv_ordenservicio.Rows[dgv_ordenservicio.CurrentCell.RowIndex].Cells["precuni"].Value);
                    dgv_ordenservicio.Rows[dgv_ordenservicio.CurrentCell.RowIndex].Cells["importe"].Value = xcantidad * xprecuni;
                    CalculosTot();
                }
            }


        }



        void CalculosTot()
        {
            if (TablaOrdenServ.Rows.Count > 0)
            {
                txt_totprendas.Text = Convert.ToInt32(TablaOrdenServ.Compute("SUM(cantidad)", string.Empty)).ToString();
                txt_totpeso.Text = Convert.ToDecimal(TablaOrdenServ.Compute("SUM(peso)", string.Empty)).ToString("##,###,##0.00");
                txt_subtotal.Text = Convert.ToDecimal(TablaOrdenServ.Compute("SUM(importe)", string.Empty)).ToString("##,###,##0.00");
                txt_igv.Text = (Convert.ToDecimal(txt_subtotal.Text) * Convert.ToDecimal(0.18)).ToString("##,###,##0.00");
                txt_totneto.Text = (Convert.ToDecimal(txt_subtotal.Text) - Convert.ToDecimal(txt_igv.Text)).ToString("##,###,##0.00");
            }
            else
            {
                txt_totprendas.Text = "0";
                txt_totpeso.Text = "0.0";
                txt_subtotal.Text = "0.0";
                txt_igv.Text = "0.0";
                txt_totneto.Text = "0.0";
            }
        }



        private void txt_busqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {                    
                    String xnumreqb = "";
                    xnumreqb = txt_busqueda.Text.PadLeft(10, '0');
                    CargarDatosReq(xnumreqb);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }                                                
            }            
        }

        void CargarDatosReq(String xnumreq)
        {
            tb_pp_requerimientoprodBL BL = new tb_pp_requerimientoprodBL();
            tb_pp_requerimientoprod BE = new tb_pp_requerimientoprod();
            DataTable dt = new DataTable();
            BE.tipreq = "RQ";
            BE.serreq = "0001";
            BE.numreq = xnumreq;
            BE.idx = "CAB"; // BUSCAMOS LA CABECERA

            dt = BL.GetAllCab(EmpresaID,BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["estado"].ToString().Trim() != "9")
                {
                    txt_numos.Text = dt.Rows[0]["numreq"].ToString();
                    txt_fechini.Text = dt.Rows[0]["fechini"].ToString();
                    txt_fechentrega.Text = dt.Rows[0]["fechfin"].ToString();
                    //txt_servcorteid.Text = dt.Rows[0]["servcorteid"].ToString();
                    //txt_servcortename.Text = dt.Rows[0]["servcortename"].ToString();

                    BE.idx = "DET"; //BUSCAMOS EL DETALLE
                    TablaOrdenServ = BL.GetAllDet(EmpresaID, BE).Tables[0];
                    dgv_ordenservicio.DataSource = TablaOrdenServ;
                    
                    btn_editar.Enabled = true;
                    btn_eliminar.Enabled = true;
                    btn_imprimir.Enabled = true;
                    btn_salir.Enabled = true;
                    //pdtimagen.Visible = false;
                }
                else
                {
                    txt_numos.Text = dt.Rows[0]["numreq"].ToString();
                    txt_fechini.Text = dt.Rows[0]["fechini"].ToString();
                    txt_fechentrega.Text = dt.Rows[0]["fechfin"].ToString();
                    //txt_servcorteid.Text = dt.Rows[0]["servcorteid"].ToString();
                    //txt_servcortename.Text = dt.Rows[0]["servcortename"].ToString();

                    BE.idx = "DET"; //BUSCAMOS EL DETALLE
                    TablaOrdenServ = BL.GetAllDet(EmpresaID, BE).Tables[0];
                    dgv_ordenservicio.DataSource = TablaOrdenServ;                    

                    ssModo = "ANULADO";
                   // pdtimagen.Visible = true;
                    btn_editar.Enabled = false;
                    btn_eliminar.Enabled = false;
                    btn_imprimir.Enabled = true;
                    btn_salir.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Requerimiento no Encontrado", "Buscando!!!!!");
            }                                   
        }


        private void ValidaDetalle(String numop)
        {
            #region
            //var xrollo = string.Empty;
            //var xproductid = string.Empty;
            //Decimal xpreciorollo = 0, xprecunit = 0, xcantidad = 0, xcostoprom = 0, tipcamb = 0;
            //Decimal desct1 = 0;
            //Decimal imporfac = 0;
            //Decimal import = 0;
            //Decimal totimpx = 0;

            //xrollo = valrollo.Trim();

            //var rowrollo = Tabladetallemov.Select("rollo='" + xrollo + "'");
            //if (rowrollo.Length > 0)
            //{
            //    MessageBox.Show("Rollo ya existe !!!!!!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productname"].Value = string.Empty;
            //txt_stock.Text = "0";
            //txt_valor.Text = "0";
            //griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad"].Value = "0";
            //griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["precunit"].Value = "0";
            //griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["importfac"].Value = "0";

            //var BLR = new tb_ta_prodrolloBL();
            //var DTR = new DataTable();
            //DTR = BLR.GetOne(EmpresaID, xrollo).Tables[0];
            //if (DTR.Rows.Count > 0)
            //{
            //    xproductid = DTR.Rows[0]["productid"].ToString();
            //    if (xproductid.Trim().Length == 13)
            //    {
            //        var BL = new tb_60local_stockBL();
            //        var BE = new tb_60local_stock();
            //        var DT = new DataTable();
            //        BE.moduloid = modulo;
            //        BE.productid = xproductid;
            //        DT = BL.GetAll(EmpresaID, BE).Tables[0];
            //        if (DT.Rows.Count > 0)
            //        {
            //            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productid"].Value = DT.Rows[0]["productid"].ToString().Trim();
            //            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productname"].Value = DT.Rows[0]["productname"].ToString().Trim();
            //            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["rollo"].Value = DTR.Rows[0]["rollo"].ToString().Trim();
            //            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["stock"].Value = Convert.ToDecimal(DTR.Rows[0]["rollostock"].ToString().Trim().PadLeft(1, '0'));
            //            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["dalmacaccionid"].Value = almacaccionid.ToString().Trim();
            //            txt_stock.Text = Math.Round(Convert.ToDecimal(DTR.Rows[0]["rollostock"].ToString().Trim().PadLeft(1, '0')), 2).ToString();

            //            if (almacaccionid.Substring(0, 1) == "2")
            //            {
            //                xprecventa = Convert.ToDecimal(Convert.ToDecimal(DT.Rows[0]["precventa"]).ToString("###,###,##0.000000"));
            //                xpreciorollo = Convert.ToDecimal(Convert.ToDecimal(DT.Rows[0]["costoultimo"]).ToString("###,###,##0.000000"));
            //                txt_valor.Text = Convert.ToDecimal(DT.Rows[0]["costopromed"].ToString().Trim().PadLeft(1, '0')).ToString("###,###,##0.0000");
            //                xcostoprom = Convert.ToDecimal(DT.Rows[0]["costopromed"].ToString().Trim().PadLeft(1, '0'));
            //            }
            //            else
            //            {
            //                if (almacaccionid.Substring(0, 1) == "1")
            //                {
            //                    xcostoultimo = Convert.ToDecimal(Convert.ToDecimal(DT.Rows[0]["costoultimo"]).ToString("###,###,##0.000000"));
            //                    xpreciorollo = Convert.ToDecimal(Convert.ToDecimal(DT.Rows[0]["costoultimo"]).ToString("###,###,##0.000000"));
            //                    txt_valor.Text = Convert.ToDecimal(DT.Rows[0]["costoultimo"].ToString().Trim().PadLeft(1, '0')).ToString("###,###,##0.0000");
            //                }
            //            }
            //            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["precventa"].Value = xprecventa;
            //            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["costoultimo"].Value = xcostoultimo;
            //            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["costopromed"].Value = xcostoprom;

            //            if (tipoperacionid.SelectedValue.ToString() == "02")
            //            {
            //                xcantidad = Convert.ToDecimal(DTR.Rows[0]["rollomedcompra"].ToString().Trim().PadLeft(1, '0'));
            //            }
            //            else
            //            {
            //                xcantidad = Convert.ToDecimal(DTR.Rows[0]["rollostock"].ToString().Trim().PadLeft(1, '0'));
            //            }

            //            tipcamb = Convert.ToDecimal(tcamb.Text.Trim());
            //            if (tipcamb <= 0)
            //            {
            //                tipcamb = 1;
            //            }

            //            if (moneda.SelectedValue.ToString() == "S")
            //            {
            //                xprecunit = xpreciorollo;
            //            }
            //            else
            //            {
            //                xprecunit = xpreciorollo / tipcamb;
            //            }

            //            if (tipoperacionid.SelectedValue.ToString() == "02" && Convert.ToDecimal(DTR.Rows[0]["rollovaloractual"].ToString().Trim().PadLeft(1, '0')) > 0)
            //            {
            //                xprecunit = Convert.ToDecimal(DTR.Rows[0]["rollovaloractual"].ToString().Trim().PadLeft(1, '0'));
            //            }

            //            imporfac = Math.Round(xcantidad * Convert.ToDecimal(xPrecio), 6);

            //            _cal_Igv();

            //            desct1 = 0;
            //            import = imporfac * (1 - (desct1 / 100));
            //            if (incprec.Trim() == "S")
            //            {
            //                totimpx = Math.Round(import * (Convert.ToDecimal(igv) / (100 + Convert.ToDecimal(igv))), 6);
            //            }
            //            else
            //            {
            //                totimpx = Math.Round(import * (Convert.ToDecimal(igv) / 100), 6);
            //            }

            //            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["valor"].Value = xpreciorollo;
            //            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["importe"].Value = Math.Round(xcantidad * xPrecio, 6);
            //            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["dtotimpto"].Value = totimpx;

            //            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["cantidad"].Value = xcantidad;
            //            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["precunit"].Value = xPrecio;
            //            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["importfac"].Value = Math.Round(imporfac, 2);
            //            Tabladetallemov.AcceptChanges();
            //            griddetallemov.CurrentCell = griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["cantidad"];
            //        }
            //        else
            //        {
            //            MessageBox.Show("Producto no existe en tabla LOCAL_STOCK !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Producto no Existe !!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Rollo no Existe !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            #endregion
        }

        private void Frm_req_produccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteRowTable();
            }
        }

        void DeleteRowTable()
        {
            if (btn_editar.Enabled == false)
            {
                int lc_cont = 0;
                if ((dgv_ordenservicio.RowCount > 0))
                {
                    // LA ELIMINACION LO MODIFICO POR ORDEN DE PROD Y BLOQUEAMOS EL COLORID
                    var xordenprod = dgv_ordenservicio.Rows[dgv_ordenservicio.CurrentCell.RowIndex].Cells["ordenprod"].Value.ToString();
                    //var xcolorid = dgv_requerimiento.Rows[dgv_requerimiento.CurrentCell.RowIndex].Cells["colorid"].Value.ToString();

                    for (lc_cont = 0; lc_cont <= this.TablaOrdenServ.Rows.Count - 1; lc_cont++)
                    {
                        // UBIQUE la fila a borrar de acuerdo a los codigos validados
                        if (this.TablaOrdenServ.Rows[lc_cont]["ordenprod"].ToString() == xordenprod
                            // && this.TablaOrdenServ.Rows[lc_cont]["colorid"].ToString() == xcolorid
                            )
                        {
                            this.TablaOrdenServ.Rows[lc_cont].Delete();
                            this.TablaOrdenServ.AcceptChanges();
                            //break;
                        }
                    }
                    CalculosTot();
                }
            }

        }

        private void txt_ctacte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaClientes();               
            }
            if (e.KeyCode == Keys.Enter)
            {
                ValidaCliente();               
            }
        }

        private void btn_agregarOP_Click(object sender, EventArgs e)
        {
            var frmayuda = new Ayudas.Form_help_ordenprod();

            frmayuda.tipoo = "sql";
            frmayuda.titulo = "AYUDA ORDEN DE PRODUCCION";
            frmayuda.sqlquery = "SELECT "+
	                                   " (serop +'-'+RIGHT(numop,4)) as ordenprod, "+
	                                   " cab.articid, "+
	                                   " art.articidold,art.articname,art.marcaid,ma.marcaname, "+
	                                   " art.lineaid,li.lineaname,art.generoid,ge.generoname "+
                                "FROM tb_pp_ordenprodcab cab ";

            frmayuda.sqlinner = 
                                "LEFT JOIN tb_pt_articulo art ON cab.articid = art.articid "+
                                "LEFT JOIN tb_pt_marca ma ON art.marcaid = ma.marcaid "+
                                "LEFT JOIN tb_pt_linea li ON art.lineaid = li.lineaid "+
                                "LEFT JOIN tb_pt_genero ge ON art.generoid = ge.generoid ";

            frmayuda.sqlwhere = "WHERE";
            frmayuda.sqland = string.Empty;
            frmayuda.criteriosbusqueda = new string[] { "SERIE", "LINEA", "MARCA" };
            frmayuda.columbusqueda = "serop + numop,li.lineaname,ma.marcaname";            
            //frmayuda.returndatos = "0,2,1,3";
            frmayuda.Owner = this;
            frmayuda.PasaData = RecibeData;
            frmayuda.ShowDialog();
        }



        private void RecibeData(DataTable dtresultado)
        {
            try
            {
                if (dtresultado.Rows.Count > 0)
                {                   
                    foreach (DataRow fila in dtresultado.Rows)
                    {                      
                        var xordenprod = fila["ordenprod"].ToString();
                        var xarticid = fila["articid"].ToString();
                        String xserop = Equivalencias.Left(xordenprod, 4).ToString();
                        String xnumop = Equivalencias.Right(xordenprod, 1).PadLeft(10, '0').ToString();

                        tb_pp_ordenprodBL BL = new tb_pp_ordenprodBL();
                        tb_pp_ordenprod BE = new tb_pp_ordenprod();
                        DataTable dt = new DataTable();
                        BE.serop = xserop.ToString();
                        BE.numop = xnumop.ToString();
                        TablaOrdenServ = BL.ListarOrden(EmpresaID, BE).Tables[0];
                        //dgv_ordenservicio.AutoGenerateColumns = false;
                        dgv_ordenservicio.DataSource = TablaOrdenServ;                  
                        dgv_ordenservicio.Enabled = false;
                        dgv_ordenservicio.ReadOnly = false;

                        CalculosTot();                      
                    }
                    gr_tipos.Enabled = true;
                    btn_agregarOP.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_autorizaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaClientesAuto();
                txt_observacion.Focus();
            }          
        }

        private void AyudaClientesAuto()
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "Ayuda Cliente/Proveedor";
                frmayuda.sqlquery = "SELECT ctacte, ctactename, nmruc, direc FROM tb_cliente";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "WHERE";
                frmayuda.sqland = string.Empty;
                frmayuda.criteriosbusqueda = new string[] { "CLIENTE", "RUC", "CODIGO" };
                frmayuda.columbusqueda = "ctactename,nmruc,ctacte";
                frmayuda.returndatos = "0,2,1,3";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeClientesAuto;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }       
        
        private void RecibeClientesAuto(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                txt_autorizaid.Text = resultado1.Trim();
                txt_autorizaname.Text = resultado3.Trim();
                //ValidaCliente();
            }
        }

        private void txt_numgr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String xcod = txt_numgr.Text;
                txt_numgr.Text = xcod.PadLeft(10, '0').ToString();
                txt_numdocsalida.Focus();
            }
        }

        private void txt_numdocsalida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String xcod = txt_numdocsalida.Text;
                txt_numdocsalida.Text = xcod.PadLeft(10, '0').ToString();
            }
        }

        private void rdb_opera_Click(object sender, EventArgs e)
        {
            //if (rdb_opera.SelectedIndex == 0)
            //{
            //    dgv_ordenservicio.Columns[11].ReadOnly = false; // PESO
            //    dgv_ordenservicio.Columns[12].ReadOnly = false; // PRECUNI
            //    dgv_ordenservicio.Columns[13].ReadOnly = false; // PRECUNIPESO
            //}
            //else
            //{
            //    dgv_ordenservicio.Columns[11].ReadOnly = true;
            //    dgv_ordenservicio.Columns[12].ReadOnly = false;
            //    dgv_ordenservicio.Columns[13].ReadOnly = true;
            //}
        }

        private void rdb_servid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdb_servid.SelectedIndex == 0)
            {
                dgv_ordenservicio.Enabled = true;

                for (int i = 0; i < 11; i++)
                {
                    dgv_ordenservicio.Columns[i].ReadOnly = true;
                }                                
                dgv_ordenservicio.Columns[11].ReadOnly = false;
                dgv_ordenservicio.Columns[12].ReadOnly = false;
                dgv_ordenservicio.Columns[13].ReadOnly = false;
                dgv_ordenservicio.Columns[14].ReadOnly = true;
            }
            else
            {
                dgv_ordenservicio.Enabled = true;

                for (int i = 0; i < 11; i++)
                {
                    dgv_ordenservicio.Columns[i].ReadOnly = true;
                }
                dgv_ordenservicio.Columns[11].ReadOnly = true;
                dgv_ordenservicio.Columns[12].ReadOnly = false;
                dgv_ordenservicio.Columns[13].ReadOnly = true;
                dgv_ordenservicio.Columns[14].ReadOnly = true;

            }
        }     


    }
}
