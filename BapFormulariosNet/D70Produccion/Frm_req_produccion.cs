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
    public partial class Frm_req_produccion : plantilla
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
        public String tipop_ = "";
        public String serop_ = "";
        public String numop_ = "";

        private DataTable TablaRequerimientoProd;


        public Frm_req_produccion()
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
            CargarSerieOP();
            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_salir.Enabled = true;
            pdtimagen.Visible = false;
            TmpRequerimientoProd();
          
        }


        void TmpRequerimientoProd()
        {
            TablaRequerimientoProd = new DataTable();
            TablaRequerimientoProd.Columns.Add("tipop", typeof(String));
            TablaRequerimientoProd.Columns.Add("serop", typeof(String));
            TablaRequerimientoProd.Columns.Add("numop", typeof(String));

            TablaRequerimientoProd.Columns.Add("tipreq", typeof(String));
            TablaRequerimientoProd.Columns.Add("serreq", typeof(String));
            TablaRequerimientoProd.Columns.Add("numreq", typeof(String));

            TablaRequerimientoProd.Columns.Add("ordenprod", typeof(String));
            TablaRequerimientoProd.Columns.Add("familiatelaid", typeof(String));
            TablaRequerimientoProd.Columns.Add("articid", typeof(String));
            TablaRequerimientoProd.Columns.Add("articidold", typeof(String));

            TablaRequerimientoProd.Columns.Add("colorid", typeof(String));
            TablaRequerimientoProd.Columns.Add("colorname", typeof(String));
            TablaRequerimientoProd.Columns.Add("coltalla", typeof(String));
            TablaRequerimientoProd.Columns.Add("can01", typeof(Int32));
            TablaRequerimientoProd.Columns.Add("can02", typeof(Int32));
            TablaRequerimientoProd.Columns.Add("can03", typeof(Int32));
            TablaRequerimientoProd.Columns.Add("can04", typeof(Int32));
            TablaRequerimientoProd.Columns.Add("can05", typeof(Int32));
            TablaRequerimientoProd.Columns.Add("can06", typeof(Int32));
            TablaRequerimientoProd.Columns.Add("can07", typeof(Int32));
            TablaRequerimientoProd.Columns.Add("can08", typeof(Int32));
            TablaRequerimientoProd.Columns.Add("can09", typeof(Int32));
            TablaRequerimientoProd.Columns.Add("can10", typeof(Int32));
            TablaRequerimientoProd.Columns.Add("can11", typeof(Int32));
            TablaRequerimientoProd.Columns.Add("can12", typeof(Int32));

            TablaRequerimientoProd.Columns.Add("panios", typeof(Int32));
            TablaRequerimientoProd.Columns.Add("totprendas", typeof(Int32));


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
            cmb_serieop.DataSource = dt;
            cmb_serieop.ValueMember = "perianio";
            cmb_serieop.DisplayMember = "ser_op";
        }

        private void btn_nuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XNIVEL == "0")
            {
                nuevo();
                Gen_numReq(); //FALTA GENERAR EL PROCEDIMIENTO
                if (TablaRequerimientoProd != null)
                {
                    TablaRequerimientoProd.Rows.Clear();
                }
                pdtimagen.Visible = false;
            }
        }

        private void Gen_numReq()
        {
            try
            {
                var BL = new tb_pp_requerimientoprodBL();
                var BE = new tb_pp_requerimientoprod();
                var dt = new DataTable();

                BE.dominioid = dominio.ToString();
                BE.moduloid = modulo.ToString();
                BE.localid = local.ToString();
                BE.tipreq = txt_tipreq.Text.ToUpper().Trim();
                BE.serreq = txt_serreq.Text.ToUpper().Trim();

                dt = BL.GetAll_NUM(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    txt_numreq.Text = dt.Rows[0]["numreq"].ToString();
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
            txt_servcorteid.Focus();
        }


        private void btn_editar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XNIVEL == "0") // SEGUN UN USUARIO ADMIN PUEDE TENER ACCESO A UNA MODIFICACION TOTAL
            {
                if (Equivalencias.Left(txt_numreq.Text, 1) == "_")// LE PONGO GUION BAJO CUANDO LIMPIO EL DOCUMENTO
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

        private void form_bloqueado(Boolean var)
        {
            try
            {
                txt_fechini.Enabled = false;
                txt_fechentrega.Enabled = var;
                txt_servcorteid.Enabled = var;
                txt_servcortename.Enabled = false;

                cmb_serieop.Enabled = var;
                txt_numop01.Enabled = var;
                dgv_requerimiento.Enabled = var;

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
                if (TablaRequerimientoProd.Rows.Count > 0)
                    TablaRequerimientoProd.Rows.Clear();

            }
        }

        private void limpiar_documento()
        {
            try
            {
                txt_busqueda.Text = "";
                txt_fechini.Text = DateTime.Today.ToShortDateString();
                txt_fechentrega.Text = "";

                txt_servcorteid.Text = "";
                txt_servcortename.Text = "";
                txt_numop01.Text = "";

                //cmb_ordprod.SelectedIndex = -1;
                txt_numreq.Text = "__________";
                txt_numop01.Focus();
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
                if (TablaRequerimientoProd != null)                
                    TablaRequerimientoProd.Rows.Clear();                
            }
        }

        private void Insert()
        {
            try
            {
                tb_pp_requerimientoprodBL BL = new tb_pp_requerimientoprodBL();
                tb_pp_requerimientoprod BE = new tb_pp_requerimientoprod();
                var Items = new tb_pp_requerimientoprod.Item();
                var ListaItems = new List<tb_pp_requerimientoprod.Item>();


                #region Variables de Requerimiento Cabecera
                BE.tipreq = txt_tipreq.Text;
                BE.serreq = txt_serreq.Text;
                BE.numreq = txt_numreq.Text;
                BE.servcorteid = txt_servcorteid.Text;
                BE.fechini = Convert.ToDateTime(txt_fechini.Text);
                if (txt_fechentrega.Text.Length > 0)
                    BE.fechfin = Convert.ToDateTime(txt_fechentrega.Text);
                BE.usuar = VariablesPublicas.Usuar.ToUpper().Trim();
                BE.estado = "0";
                BE.observ = "N/A";
                BE.idx = "INS";
                #endregion

                if (dgv_requerimiento.Rows.Count > 0 && dgv_requerimiento.ColumnCount > 0)
                {
                    int num = 1;
                    for (int i = 0; i < dgv_requerimiento.RowCount; i++)
                    {
                        for (int j = 13; j < dgv_requerimiento.Columns.Count - 2; j++)
                        {
                            Items = new tb_pp_requerimientoprod.Item();

                            Items.tipreq = txt_tipreq.Text;
                            Items.serreq = txt_serreq.Text;
                            Items.numreq = txt_numreq.Text;

                            Items.tipop = dgv_requerimiento.Rows[i].Cells["tipop"].Value.ToString();
                            Items.serop = dgv_requerimiento.Rows[i].Cells["serop"].Value.ToString();
                            Items.numop = dgv_requerimiento.Rows[i].Cells["numop"].Value.ToString();
                            String xx = dgv_requerimiento.Rows[i].Cells["familiatelaid"].Value.ToString();
                            Items.familiaid = dgv_requerimiento.Rows[i].Cells["familiatelaid"].Value.ToString();                           
                            Items.articidold = dgv_requerimiento.Rows[i].Cells["articidold"].Value.ToString();
                            Items.articid = dgv_requerimiento.Rows[i].Cells["articid"].Value.ToString();
                            Items.coltalla = num.ToString().PadLeft(2, '0');
                            Items.colorid = dgv_requerimiento.Rows[i].Cells["colorid"].Value.ToString();
                            Items.cantreal = Convert.ToInt32(dgv_requerimiento.Rows[i].Cells[j].Value.ToString());

                            Items.panios = Convert.ToInt32(dgv_requerimiento.Rows[i].Cells[dgv_requerimiento.ColumnCount - 2].Value.ToString());
                            Items.estado = "0";
                            Items.totprendas = Convert.ToInt32(dgv_requerimiento.Rows[i].Cells[dgv_requerimiento.ColumnCount - 1].Value.ToString());
                            num++;
                            ListaItems.Add(Items);
                        }
                        num = 1;
                    }
                }

                BE.ListaItems = ListaItems;


                if (BL.Insert(EmpresaID, BE))
                {
                    MessageBox.Show("Datos Grabados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    procesado = true;
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

                tb_pp_requerimientoprodBL BL = new tb_pp_requerimientoprodBL();
                tb_pp_requerimientoprod BE = new tb_pp_requerimientoprod();
                var Items = new tb_pp_requerimientoprod.Item();
                var ListaItems = new List<tb_pp_requerimientoprod.Item>();

                #region Variables de OrdenProdCab
                BE.tipreq = txt_tipreq.Text;
                BE.serreq = txt_serreq.Text;
                BE.numreq = txt_numreq.Text;
                BE.servcorteid = txt_servcorteid.Text;
                BE.fechini = Convert.ToDateTime(txt_fechini.Text);
                if (txt_fechentrega.Text.Length > 0)
                    BE.fechfin = Convert.ToDateTime(txt_fechentrega.Text);
                BE.usuar = VariablesPublicas.Usuar.ToUpper().Trim();
                BE.estado = "0";
                BE.observ = "N/A";
                BE.idx = "UPD";
                #endregion

                if (dgv_requerimiento.Rows.Count > 0 && dgv_requerimiento.ColumnCount > 0)
                {
                    int num = 1;
                    for (int i = 0; i < dgv_requerimiento.RowCount; i++)
                    {
                        for (int j = 13; j < dgv_requerimiento.Columns.Count - 2; j++)
                        {
                            Items = new tb_pp_requerimientoprod.Item();

                            Items.tipreq = txt_tipreq.Text;
                            Items.serreq = txt_serreq.Text;
                            Items.numreq = txt_numreq.Text;

                            Items.tipop = dgv_requerimiento.Rows[i].Cells["tipop"].Value.ToString();
                            Items.serop = dgv_requerimiento.Rows[i].Cells["serop"].Value.ToString();
                            Items.numop = dgv_requerimiento.Rows[i].Cells["numop"].Value.ToString();
                            String xx = dgv_requerimiento.Rows[i].Cells["familiatelaid"].Value.ToString();
                            Items.familiaid = dgv_requerimiento.Rows[i].Cells["familiatelaid"].Value.ToString();
                            Items.articidold = dgv_requerimiento.Rows[i].Cells["articidold"].Value.ToString();
                            Items.articid = dgv_requerimiento.Rows[i].Cells["articid"].Value.ToString();
                            Items.coltalla = num.ToString().PadLeft(2, '0');
                            Items.colorid = dgv_requerimiento.Rows[i].Cells["colorid"].Value.ToString();
                            Items.cantreal = Convert.ToInt32(dgv_requerimiento.Rows[i].Cells[j].Value.ToString());

                            Items.panios = Convert.ToInt32(dgv_requerimiento.Rows[i].Cells[dgv_requerimiento.ColumnCount - 2].Value.ToString());
                            Items.estado = "0";
                            Items.totprendas = Convert.ToInt32(dgv_requerimiento.Rows[i].Cells[dgv_requerimiento.ColumnCount - 1].Value.ToString());
                            num++;
                            ListaItems.Add(Items);
                        }
                        num = 1;
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
                if (txt_numreq.Text.Length == 0)
                {
                    MessageBox.Show("Falta Número de Requerimiento", "Mensaje");
                    return;
                }
                else
                {
                    tb_pp_requerimientoprodBL BL = new tb_pp_requerimientoprodBL();
                    tb_pp_requerimientoprod BE = new tb_pp_requerimientoprod();
                    BE.tipreq = txt_tipreq.Text;
                    BE.serreq = txt_serreq.Text;
                    BE.numreq = txt_numreq.Text;
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
                        if (TablaRequerimientoProd != null)
                            TablaRequerimientoProd.Rows.Clear(); 
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
                BE.detalle = txt_numreq.Text.Trim() + "/" + "OP-" + cmb_serieop.Text + "-" + txt_numop01.Text.Trim().ToUpper() + "/" + XGLOSA;

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
            if (txt_numreq.Text.Trim().Length > 0 && txt_serreq.Text.Trim().Length > 0 && txt_numreq.Text.Trim().Length > 0)
            {
                metodo();
            }
            else
            {
                MessageBox.Show("Porfavor, Seleccionar una Orden de Prod. de la tabla");
            }
            
        }

         public void metodo()
        {
            
        try
            {
                var miForma = new D70Produccion.Reportes.Frm_reportes();
                miForma.Text = "Reporte por Orden de Producción";
                //miForma.dominioid = dominio.Trim();

                //miForma.tipop = "OP";
                //miForma.numop = numop_.ToString().Trim();
                //miForma.serop = serop_.ToString().Trim();
                miForma.tipdoc = txt_tipreq.Text;// "RQ";
                miForma.serdoc = txt_serreq.Text;//"0001";
                miForma.numdoc = txt_numreq.Text;//"0000000004";


                miForma.moduloid = "0320";
                miForma.local = "002";
                miForma.formulario = "Frm_reporte_req_produccion";
                miForma.Show();


            }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

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
                xnumop = txt_numop01.Text.PadLeft(10, '0');

                if (cmb_serieop.SelectedIndex == 0)
                {
                    MessageBox.Show("Seleccione una Serie OP", "Mensaje");
                    return;
                }
                else if (ValidaDet(cmb_serieop.Text,xnumop))
                {
                    // CARGAMOS EL DETALLE                    
                    tb_pp_requerimientoprod BE = new tb_pp_requerimientoprod();
                    tb_pp_requerimientoprodBL BL = new tb_pp_requerimientoprodBL();
                    DataTable dt = new DataTable();
                    BE.tipop = "OP";
                    BE.serop = cmb_serieop.Text;
                    BE.numop = xnumop.ToString();

                    dt = BL.GetAllOrden_PIVOT(EmpresaID, BE).Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["colorid"].ToString() == "" || dt.Rows[0]["totprendas"].ToString() == "0")
                        {
                            MessageBox.Show("No Esta Definido los Colores en la OP ... !!!", "Información").ToString();
                            return;
                        }
                        else
                        {
                            foreach (DataRow fila in dt.Rows)
                            {
                                row = TablaRequerimientoProd.NewRow();
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

                                TablaRequerimientoProd.Rows.Add(row);
                            }
                        }

                        dgv_requerimiento.DataSource = TablaRequerimientoProd;
                    }
                    else
                        MessageBox.Show("NO Existe OP","Mensaje");

                    txt_numop01.Text = "";

                    // LO COMENTO PORQUE YA NO ES NECESARIO HACER NINGUNA INTERACCION CON EL DETALLE

                    //dgv_requerimiento.Enabled = true;
                    //dgv_requerimiento.ReadOnly = false;
                    //for (int j = 0; j < dgv_requerimiento.ColumnCount - 3; j++)                    
                    //    dgv_requerimiento.Columns[j].ReadOnly = true;                                       
                    //dgv_requerimiento.Columns[dgv_requerimiento.ColumnCount - 1].ReadOnly = true;                   
                }
            }
        }

        Boolean ValidaDet(String xserop,String xnumop)
        {
            Boolean valor = true;
            String xseropgrid,xnumopgrid;
            int cont = 0;
            foreach (DataGridViewRow fila in dgv_requerimiento.Rows)
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
                txt_servcorteid.Text = resultado1.Trim();
                txt_servcortename.Text = resultado2.Trim();
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
            tb_pp_servcorte BE = new tb_pp_servcorte();
            tb_pp_servcorteBL BL = new tb_pp_servcorteBL();
            DataTable dt = new DataTable();
            BE.servcorteid = txt_servcorteid.Text;
            BE.servcortename = txt_servcortename.Text;

            try
            {
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    txt_servcorteid.Text = dt.Rows[0]["servcorteid"].ToString();
                    txt_servcortename.Text = dt.Rows[0]["servcortename"].ToString();
                }
                else
                {
                    txt_servcorteid.Text = "";
                    txt_servcortename.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgv_requerimiento_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_requerimiento.Columns[e.ColumnIndex].Name.ToUpper() == "panios".ToUpper())
            {
                Int32 xpanios = 0,xcantidad = 0;
                xpanios = Convert.ToInt32(dgv_requerimiento.Rows[dgv_requerimiento.CurrentCell.RowIndex].Cells["panios"].Value);
                for (int j = 13; j < dgv_requerimiento.Columns.Count - 2; j++)
                {
                    xcantidad = xcantidad + Convert.ToInt32(dgv_requerimiento.Rows[dgv_requerimiento.CurrentCell.RowIndex].Cells[j].Value.ToString());
                }
                dgv_requerimiento.Rows[dgv_requerimiento.CurrentCell.RowIndex].Cells["totprendas"].Value = xpanios * xcantidad;
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
                    txt_numreq.Text = dt.Rows[0]["numreq"].ToString();
                    txt_fechini.Text = dt.Rows[0]["fechini"].ToString();
                    txt_fechentrega.Text = dt.Rows[0]["fechfin"].ToString();
                    txt_servcorteid.Text = dt.Rows[0]["servcorteid"].ToString();
                    txt_servcortename.Text = dt.Rows[0]["servcortename"].ToString();

                    BE.idx = "DET"; //BUSCAMOS EL DETALLE
                    TablaRequerimientoProd = BL.GetAllDet(EmpresaID, BE).Tables[0];
                    dgv_requerimiento.DataSource = TablaRequerimientoProd;
                    dgv_requerimiento.Enabled = true;

                    btn_editar.Enabled = true;
                    btn_eliminar.Enabled = true;
                    btn_imprimir.Enabled = true;
                    btn_salir.Enabled = true;
                    pdtimagen.Visible = false;

                }
                else
                {
                    txt_numreq.Text = dt.Rows[0]["numreq"].ToString();
                    txt_fechini.Text = dt.Rows[0]["fechini"].ToString();
                    txt_fechentrega.Text = dt.Rows[0]["fechfin"].ToString();
                    txt_servcorteid.Text = dt.Rows[0]["servcorteid"].ToString();
                    txt_servcortename.Text = dt.Rows[0]["servcortename"].ToString();

                    BE.idx = "DET"; //BUSCAMOS EL DETALLE
                    TablaRequerimientoProd = BL.GetAllDet(EmpresaID, BE).Tables[0];
                    dgv_requerimiento.DataSource = TablaRequerimientoProd;                    

                    ssModo = "ANULADO";
                    pdtimagen.Visible = true;
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
                if ((dgv_requerimiento.RowCount > 0))
                {
                    // LA ELIMINACION LO MODIFICO POR ORDEN DE PROD Y BLOQUEAMOS EL COLORID
                    var xordenprod = dgv_requerimiento.Rows[dgv_requerimiento.CurrentCell.RowIndex].Cells["ordenprod"].Value.ToString();
                    //var xcolorid = dgv_requerimiento.Rows[dgv_requerimiento.CurrentCell.RowIndex].Cells["colorid"].Value.ToString();

                    for (lc_cont = 0; lc_cont <= this.TablaRequerimientoProd.Rows.Count - 1; lc_cont++)
                    {
                        // UBIQUE la fila a borrar de acuerdo a los codigos validados
                        if (this.TablaRequerimientoProd.Rows[lc_cont]["ordenprod"].ToString() == xordenprod
                            // && this.TablaRequerimientoProd.Rows[lc_cont]["colorid"].ToString() == xcolorid
                            )
                        {
                            this.TablaRequerimientoProd.Rows[lc_cont].Delete();
                            this.TablaRequerimientoProd.AcceptChanges();
                            //break;
                        }
                    }
                }
            }

        }

        private void dgv_requerimiento_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            tb_pp_requerimientoprod BE = new tb_pp_requerimientoprod();
            try
            {
                if (dgv_requerimiento.CurrentRow != null)
                {                    
                    tipop_=dgv_requerimiento.Rows[e.RowIndex].Cells["tipop"].Value.ToString().Trim();
                    serop_=dgv_requerimiento.Rows[e.RowIndex].Cells["serop"].Value.ToString().Trim();
                    numop_=dgv_requerimiento.Rows[e.RowIndex].Cells["numop"].Value.ToString().Trim();
                    //Message  Show("desea imprimir");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

    }
}
