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

using System.Data.SqlClient;
using LayerDataAccess;


namespace BapFormulariosNet.D70Produccion
{
    public partial class Frm_orden_servicio : plantilla
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
        private String xarticid = "";
        private String xctacte = "";

        private DataTable TablaOrdenServ;


        public Frm_orden_servicio()
        {
            InitializeComponent();
        }

        private void Frm_orden_servicio_Load(object sender, EventArgs e)
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
            data_cbo_moneda();
            TmpOrdenServ();
            form_bloqueado(false);
            limpiar_documento();
            btn_nuevo.Enabled = true;
            btn_salir.Enabled = true;
            pdtimagen.Visible = false;
        }


        void TmpOrdenServ()
        {
            TablaOrdenServ = new DataTable();
            TablaOrdenServ.Columns.Add("colorid", typeof(String));
            TablaOrdenServ.Columns.Add("colorname", typeof(String));
            TablaOrdenServ.Columns.Add("cantidad", typeof(Int32));
            TablaOrdenServ.Columns.Add("peso", typeof(Decimal));
            TablaOrdenServ.Columns.Add("precunitpeso", typeof(Decimal));
            TablaOrdenServ.Columns.Add("precunit", typeof(Decimal));
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


        private void get_tipocambio(string fecha)
        {
            try
            {
                var BL = new tipocambioBL();
                var dt = new DataTable();
                dt = BL.GetOne(EmpresaID, Convert.ToDateTime(fecha)).Tables[0];
                if (dt.Rows.Count > 0)                
                    tcamb.Text = Convert.ToDecimal(dt.Rows[0]["venta"]).ToString("###,##0.0000");                
                else                
                    tcamb.Text = "1";                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                //txt_ctacte.Focus();
                cmb_estado.SelectedIndex = 0;
                cmb_estado.Enabled = false;
                pdtimagen.Visible = false;
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

        private void limpiar_documento()
        {
            try
            {               
                txt_fechini.Text = DateTime.Today.ToShortDateString();
                get_tipocambio(txt_fechini.Text);
                txt_fechfin.Text = "";
                txt_serop.Text = "";
                txt_numop.Text = "";
                txt_articidold.Text = "";
                txt_articname.Text = "";
                txt_observacion.Text = "";
                txt_servtaller.Text = "";

                txt_serfac.Text = "";
                txt_numfac.Text = "";
                txt_serguia.Text = "";
                txt_numguia.Text = "";
                txt_serfase.Text = "";
                txt_numfase.Text = "";
                
                rdb_servid.SelectedIndex = -1;                
                cmb_moneda.SelectedIndex = -1;
                cmb_secuencia.SelectedIndex = -1;
                cmb_estado.SelectedIndex = -1;


                txt_cantidad.Text = "0";
                txt_peso.Text = "0";
                txt_precunitpeso.Text = "0";
                txt_importe.Text = "0";
                txt_precunit.Text = "0";

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


        private void form_bloqueado(Boolean var)
        {
            try
            {
                txt_fechini.Enabled = false;
                txt_fechfin.Enabled = var;
                txt_serop.Enabled = false;
                txt_numop.Enabled = false;
                txt_articidold.Enabled = false;
                txt_articname.Enabled = false;
                txt_observacion.Enabled = var;
                txt_servtaller.Enabled = false;

                txt_serfac.Enabled = var;
                txt_numfac.Enabled = var;
                txt_serguia.Enabled = var;
                txt_numguia.Enabled = var;
                txt_serfase.Enabled = var;
                txt_numfase.Enabled = var;

                tcamb.Enabled = false;
                cmb_moneda.Enabled = var;
                cmb_secuencia.Enabled = false;
                cmb_estado.Enabled = var;
                cmb_color.Enabled = var;

                btn_agregar.Enabled = var;


                txt_cantidad.Enabled = false;
                txt_peso.Enabled = false;
                txt_precunitpeso.Enabled = false;
                txt_importe.Enabled = false;
                txt_precunit.Enabled = false;
             
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

        private void txt_serop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaOrdProd();
            }
        }

        private void AyudaOrdProd()
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "AYUDA ORDEN DE PRODUCCION";
                frmayuda.sqlquery = "SELECT " +
                                           " serop,numop," +
                                           " cab.articid, " +
                                           " art.articidold,art.articname,art.marcaid,ma.marcaname, " +
                                           " art.lineaid,li.lineaname,art.generoid,ge.generoname " +
                                    "FROM tb_pp_ordenprodcab cab ";

                frmayuda.sqlinner =
                                    "LEFT JOIN tb_pt_articulo art ON cab.articid = art.articid " +
                                    "LEFT JOIN tb_pt_marca ma ON art.marcaid = ma.marcaid " +
                                    "LEFT JOIN tb_pt_linea li ON art.lineaid = li.lineaid " +
                                    "LEFT JOIN tb_pt_genero ge ON art.generoid = ge.generoid ";

                frmayuda.sqlwhere = "WHERE";
                frmayuda.sqland = string.Empty;
                frmayuda.criteriosbusqueda = new string[] { "SERIE", "LINEA", "MARCA" };
                frmayuda.columbusqueda = "serop + numop,li.lineaname,ma.marcaname";
                frmayuda.returndatos = "0,1,2,3,4";
                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeData;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RecibeData(String x1, String x2, String x3, String x4, String x5)
        {
            try
            {
                txt_serop.Text = x1.ToString();
                txt_numop.Text = x2.ToString();
                xarticid = x3.ToString();
                txt_articidold.Text = x4.ToString();
                txt_articname.Text = x5.ToString();

                DataTable dt = new DataTable();
                String Query = " SELECT (CONVERT(VARCHAR, opf.secuencia) + ' = ' + f.fasename) secuencia,opf.faseid,cl.ctactename " +
                               " FROM tb_pp_ordenprodfase opf " +
                               " LEFT JOIN tb_pp_fase f ON opf.faseid = f.faseid " +
                               " LEFT JOIN tb_cliente cl ON opf.ctacte = cl.ctacte " +
                               " WHERE opf.tipop = 'OP'  AND opf.serop = '" + txt_serop.Text + "' AND opf.numop = '" + txt_numop.Text + "'";
                dt = DatosSQL(Query);

                cmb_secuencia.DataSource = dt;
                cmb_secuencia.ValueMember = "faseid";
                cmb_secuencia.DisplayMember = "secuencia";
                cmb_secuencia.SelectedIndex = 0;

                form_bloqueado(true);
                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
                btn_salir.Enabled = true;
                //cmb_tipdoc.Enabled = false;
                txt_numop.Enabled = false;
                //btn_new.Enabled = true;


                /**********************
                 * CARGAMOS EL COMBO DE COLORES       
                 * ******************/
                tb_pp_ordenprodfasemoviBL BL2 = new tb_pp_ordenprodfasemoviBL();
                tb_pp_ordenprodfasemovi BE2 = new tb_pp_ordenprodfasemovi();
                DataTable dt2 = new DataTable();
                BE2.tipop = "OP";
                BE2.serop = txt_serop.Text;
                BE2.numop = txt_numop.Text;
                BE2.filtro = "1";
                dt2 = BL2.GetAll(EmpresaID, BE2).Tables[0];

                cmb_color.DataSource = dt2;
                cmb_color.ValueMember = "colorid";
                cmb_color.DisplayMember = "colorname";
                cmb_color.SelectedIndex = -1;


                /************************
                 * CARGAMOS EL DETALLE                                  
                 * **********************/
                //var BL3 = new tb_pp_ordenprodfasemoviBL();
                //var BE3 = new tb_pp_ordenprodfasemovi();
                //var dt3 = new DataTable();

                //BE3.tipop = "OP";
                //BE3.serop = txt_serop.Text;
                //BE3.numop = txt_numop.Text;
                //BE3.filtro = "1";

                //dt3 = BL3.GetAllPropColor_PIVOT(EmpresaID, BE3).Tables[0];
                //dgv_color.AutoGenerateColumns = false;
                //dgv_color.DataSource = dt3;

                //ValidaArticulo();
                //CalculosTotales();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private DataTable DatosSQL(String query)
        {
            var conex = new ConexionDA();
            var dt = new DataTable();

            using (var cnx = new SqlConnection(conex.empConexion(VariablesPublicas.EmpresaID)))
            {
                using (var cmd = new SqlCommand("gspHelpSQL", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@sqlquery", SqlDbType.VarChar).Value = query;

                    try
                    {
                        cnx.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        return dt;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        private void cmb_secuencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_secuencia.SelectedIndex != -1)
            {
                //if (cmb_secuencia.Text != "System.Data.DataRowView" && cmb_secuencia.SelectedValue.ToString() != "System.Data.DataRowView")
                //{

                //    DataTable dt = new DataTable();
                //    String Query = " SELECT opf.ctacte,cl.ctactename " +
                //                   " FROM tb_pp_ordenprodfase opf  " +
                //                   " LEFT JOIN tb_cliente cl ON opf.ctacte = cl.ctacte " +
                //                   " WHERE opf.tipop = 'OP'  AND opf.serop = '" + txt_serop.Text + "' AND opf.numop = '" + txt_numop.Text + "' " +
                //                   " AND opf.faseid = '" + cmb_secuencia.SelectedValue.ToString() + "'";
                //    dt = DatosSQL(Query);
                //    if (dt.Rows.Count > 0)
                //    {
                //        xctacte = dt.Rows[0]["ctacte"].ToString();
                //        txt_servtaller.Text = dt.Rows[0]["ctactename"].ToString();
                //    }
                //    else
                //    {
                //        xctacte = "";
                //        txt_servtaller.Text = "";
                //    }
                //}
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
                limpiar_documento();
                if (TablaOrdenServ.Rows.Count > 0)
                    TablaOrdenServ.Rows.Clear();                
                if (dgv_ordenserv.RowCount > 0)
                    dgv_ordenserv.DataSource = TablaOrdenServ;               
                form_bloqueado(false);
                btn_nuevo.Enabled = true;
                ssModo = "NEW";
            }
        }

        private void btn_salir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
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
                if (txt_fechfin.Text.Length == 0)
                {
                    MessageBox.Show("Indicar la Fecha de Entrega ...", "Verificar");
                    return;
                }
                else if (cmb_moneda.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccionar El Tipo de Moneda ...", "Verificar");
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
                    BE.fechini = Convert.ToDateTime(txt_fechini.Text);
                    BE.fechfin = Convert.ToDateTime(txt_fechfin.Text);
                    BE.precprenda = rdb_servid.SelectedIndex == 0 ? true : false;
                    BE.cantidad = Convert.ToInt32(txt_totprendas.Text);
                    BE.peso = Convert.ToDecimal(txt_totpeso.Text);
                    BE.moneda = cmb_moneda.SelectedValue.ToString();
                    BE.tcambio = Convert.ToDecimal(tcamb.Text);
                    BE.bimpo = Convert.ToDecimal(txt_subtotal.Text);
                    BE.migv = Convert.ToDecimal(txt_igv.Text);
                    BE.pvent = Convert.ToDecimal(txt_totneto.Text);
                    BE.ctacte = xctacte.ToString();
                    BE.tipop = "OP";
                    BE.serop = txt_serop.Text;
                    BE.numop = txt_numop.Text;
                    BE.secuencia = Convert.ToInt32(Equivalencias.Left(cmb_secuencia.Text, 1));
                    BE.faseid = Convert.ToInt32(cmb_secuencia.SelectedValue.ToString());
                    BE.estado = cmb_estado.SelectedIndex.ToString();
                    BE.tipfac = "FA";
                    BE.serfac = txt_serfac.Text;
                    BE.numfac = txt_numfac.Text;
                    BE.tipgr = "GR";
                    BE.sergr = txt_serguia.Text;
                    BE.numgr = txt_numguia.Text;
                    BE.tipfas = "GI";
                    BE.serfas = txt_serfase.Text;
                    BE.numfas = txt_numfase.Text;              
                    BE.usuar = VariablesPublicas.Usuar.Trim().ToUpper();
                    BE.observacion = txt_observacion.Text;              

                    #endregion

                    if (dgv_ordenserv.Rows.Count > 0 && dgv_ordenserv.ColumnCount > 0)
                    {
                        for (int i = 0; i < dgv_ordenserv.RowCount; i++)
                        {
                            Items = new tb_pp_ordenservicio.Item();                                               
                            Items.colorid = dgv_ordenserv.Rows[i].Cells["gcolorid"].Value.ToString();
                            Items.cantidad = Convert.ToInt32(dgv_ordenserv.Rows[i].Cells["gcantidad"].Value.ToString());
                            Items.peso = Convert.ToDecimal(dgv_ordenserv.Rows[i].Cells["gpeso"].Value.ToString());
                            Items.precunitpeso = Convert.ToDecimal(dgv_ordenserv.Rows[i].Cells["gprecunitpeso"].Value.ToString());
                            Items.precunit = Convert.ToDecimal(dgv_ordenserv.Rows[i].Cells["gprecunit"].Value.ToString());
                            Items.importe = Convert.ToDecimal(dgv_ordenserv.Rows[i].Cells["gimporte"].Value.ToString());
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
                BE.fechini = Convert.ToDateTime(txt_fechini.Text);
                BE.fechfin = Convert.ToDateTime(txt_fechfin.Text);
                BE.precprenda = rdb_servid.SelectedIndex == 0 ? true : false;
                BE.cantidad = Convert.ToInt32(txt_totprendas.Text);
                BE.peso = Convert.ToDecimal(txt_totpeso.Text);
                BE.moneda = cmb_moneda.SelectedValue.ToString();
                BE.tcambio = Convert.ToDecimal(tcamb.Text);
                BE.bimpo = Convert.ToDecimal(txt_subtotal.Text);
                BE.migv = Convert.ToDecimal(txt_igv.Text);
                BE.pvent = Convert.ToDecimal(txt_totneto.Text);
                BE.ctacte = xctacte.ToString();
                BE.tipop = "OP";
                BE.serop = txt_serop.Text;
                BE.numop = txt_numop.Text;
                BE.secuencia = Convert.ToInt32(Equivalencias.Left(cmb_secuencia.Text, 1));
                BE.faseid = Convert.ToInt32(cmb_secuencia.SelectedValue.ToString());
                BE.estado = cmb_estado.SelectedIndex.ToString();
                BE.tipfac = "FA";
                BE.serfac = txt_serfac.Text;
                BE.numfac = txt_numfac.Text;
                BE.tipgr = "GR";
                BE.sergr = txt_serguia.Text;
                BE.numgr = txt_numguia.Text;
                BE.tipfas = "GI";
                BE.serfas = txt_serfase.Text;
                BE.numfas = txt_numfase.Text;
                BE.usuar = VariablesPublicas.Usuar.Trim().ToUpper();
                BE.observacion = txt_observacion.Text;              

                #endregion

                if (dgv_ordenserv.Rows.Count > 0 && dgv_ordenserv.ColumnCount > 0)
                {
                    for (int i = 0; i < dgv_ordenserv.RowCount; i++)
                    {
                        Items = new tb_pp_ordenservicio.Item();
                        Items.colorid = dgv_ordenserv.Rows[i].Cells["gcolorid"].Value.ToString();
                        Items.cantidad = Convert.ToInt32(dgv_ordenserv.Rows[i].Cells["gcantidad"].Value.ToString());
                        Items.peso = Convert.ToDecimal(dgv_ordenserv.Rows[i].Cells["gpeso"].Value.ToString());
                        Items.precunitpeso = Convert.ToDecimal(dgv_ordenserv.Rows[i].Cells["gprecunitpeso"].Value.ToString());
                        Items.precunit = Convert.ToDecimal(dgv_ordenserv.Rows[i].Cells["gprecunit"].Value.ToString());
                        Items.importe = Convert.ToDecimal(dgv_ordenserv.Rows[i].Cells["gimporte"].Value.ToString());
                        ListaItems.Add(Items);
                    }
                }

                BE.ListaItems = ListaItems;

                if (BL.Update(EmpresaID, BE))
                {
                    //SEGURIDAD_LOG("M");
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
                        //SEGURIDAD_LOG("E");
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

        Boolean ValidaDatos()
        {
            Boolean val = true;
            if (cmb_color.Text.ToString().Length == 0)
            {
                val = false;
                MessageBox.Show("Seleccionar un Color Determinado", "Mensaje !!!");
            }
            //else if (txt_colorname.Text.ToString().Length == 0)
            //{
            //    val = false;
            //    MessageBox.Show("Seleccionar un Color Determinado", "Mensaje !!!");
            //}

            return val;
        }

        Boolean ValidaDatos2()
        {
            Boolean valor = true;
            String xcolorid = "";
            foreach (DataGridViewRow fila in dgv_ordenserv.Rows)
            {
                xcolorid = fila.Cells["gcolorid"].Value.ToString();
                if (xcolorid.Equals(cmb_color.SelectedValue.ToString()))
                {
                    valor = false;
                    MessageBox.Show("Existen Datos Iguales en el Detalle ... Cambiarlo", "Mensaje");
                }
            }
            return valor;
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaDatos())
                {
                    if (this.dgv_ordenserv.RowCount > 0)
                    {
                        // SEGUNDA VALIDACIÓN
                        if (ValidaDatos2())
                        {
                            int nFilaAnt = dgv_ordenserv.RowCount - 1;
                            TablaOrdenServ = new DataTable();
                            TmpOrdenServ();

                            foreach (DataGridViewRow fila in dgv_ordenserv.Rows)
                            {
                                row = TablaOrdenServ.NewRow();            
                                row["colorid"] = fila.Cells["gcolorid"].Value;
                                row["colorname"] = fila.Cells["gcolorname"].Value;
                                row["cantidad"] = fila.Cells["gcantidad"].Value;
                                row["peso"] = fila.Cells["gpeso"].Value;
                                row["precunitpeso"] = fila.Cells["gprecunitpeso"].Value;
                                row["precunit"] = fila.Cells["gprecunit"].Value;
                                row["importe"] = fila.Cells["gimporte"].Value;                      
                                TablaOrdenServ.Rows.Add(row);
                            }
                           
                            AddRowTable();
                            dgv_ordenserv.DataSource = TablaOrdenServ;
                            CalculosTotales();
                        }
                    }
                    else
                    {
                        TmpOrdenServ();
                        AddRowTable();
                        dgv_ordenserv.DataSource = TablaOrdenServ;
                        CalculosTotales();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void CalculosTotales()
        {
            if (TablaOrdenServ.Rows != null)
            {
                if (TablaOrdenServ.Rows.Count > 0)
                {
                    txt_totprendas.Text = (dgv_ordenserv.RowCount > 0) ? Convert.ToInt32(TablaOrdenServ.Compute("sum(cantidad)", "")).ToString() : "0";
                    txt_totpeso.Text = (dgv_ordenserv.RowCount > 0) ? Convert.ToInt32(TablaOrdenServ.Compute("sum(peso)", "")).ToString() : "0";
                    txt_subtotal.Text = (dgv_ordenserv.RowCount > 0) ? Convert.ToInt32(TablaOrdenServ.Compute("sum(importe)", "")).ToString("###,##0.0000") : "0";
                    txt_igv.Text =  (Convert.ToDouble(txt_subtotal.Text) * 0.18).ToString("###,##0.0000");
                    txt_totneto.Text = (Convert.ToDouble(txt_subtotal.Text) + Convert.ToDouble(txt_importe.Text)).ToString("###,##0.0000");
                }
            }
        }


        void AddRowTable()
        {
            row = TablaOrdenServ.NewRow();
            row["colorid"] = cmb_color.SelectedValue.ToString();
            row["colorname"] = cmb_color.Text;
            row["cantidad"] = txt_cantidad.Text;
            row["peso"] = txt_peso.Text;
            row["precunitpeso"] = txt_precunit.Text;
            row["precunit"] = txt_precunitpeso.Text;
            row["importe"] = txt_importe.Text;
            TablaOrdenServ.Rows.Add(row);
        }

        private void rdb_servid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdb_servid.SelectedIndex == 0)
            {
                txt_peso.Enabled = false;                
                txt_precunitpeso.Enabled = false;
                txt_precunit.Enabled = true;
                CalImporteLineal();
            }
            else
            {
                txt_peso.Enabled = true;               
                txt_precunitpeso.Enabled = true;
                txt_precunit.Enabled = false;
                CalImporteLineal();
            }


        }

        private void txt_serfac_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(ActiveControl.Text))
            {
                txt_serfac.SelectionStart = 0;
                txt_serfac.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void txt_numfac_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(ActiveControl.Text))
            {
                txt_numfac.SelectionStart = 0;
                txt_numfac.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void txt_serguia_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(ActiveControl.Text))
            {
                txt_serguia.SelectionStart = 0;
                txt_serguia.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void txt_numguia_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(ActiveControl.Text))
            {
                txt_numguia.SelectionStart = 0;
                txt_numguia.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void txt_serfase_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(ActiveControl.Text))
            {
                txt_serfase.SelectionStart = 0;
                txt_serfase.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void txt_numfase_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(ActiveControl.Text))
            {
                txt_numfase.SelectionStart = 0;
                txt_numfase.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void txt_serfac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String xcod = txt_serfac.Text;
                txt_serfac.Text = xcod.PadLeft(4, '0');
                txt_numfac.Focus();
            }
        }

        private void txt_numfac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String xcod = txt_numfac.Text;
                txt_numfac.Text = xcod.PadLeft(10, '0');
                txt_serguia.Focus();
            }
        }

        private void txt_serguia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String xcod = txt_serguia.Text;
                txt_serguia.Text = xcod.PadLeft(4, '0');
                txt_numguia.Focus();
            }
        }

        private void txt_numguia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String xcod = txt_numguia.Text;
                txt_numguia.Text = xcod.PadLeft(10, '0');
                txt_serfase.Focus();
            }
        }

        private void txt_serfase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String xcod = txt_serfase.Text;
                txt_serfase.Text = xcod.PadLeft(4, '0');
                txt_numfase.Focus();
            }

            if (e.KeyCode == Keys.F1)
            {
                AyudaDocMovFase();
                cmb_estado.Enabled = false;
            }
        }

        private void txt_numfase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String xcod = txt_numfase.Text;
                txt_numfase.Text = xcod.PadLeft(10, '0');
                txt_observacion.Focus();
            }
        }


        private void AyudaDocMovFase()
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "AYUDA DOC. MOV. FASE- INGRESOS";
                frmayuda.sqlquery = " SELECT (serdoc+'-'+numdoc)doc,( cab.serop + '-' + cab.numop) op,faseid,art.articidold,art.articname " +
                                    " FROM tb_pp_ordenprodfasemovicab cab ";
                frmayuda.sqlinner = " LEFT JOIN tb_pp_ordenprodcab opf ON cab.tipop = opf.tipop and cab.serop = opf.serop and cab.numop = opf.numop " +
                                    " LEFT JOIN tb_pt_articulo art ON opf.articid = art.articid ";
                frmayuda.sqlwhere = " WHERE almacaccionid = '10' ";
                frmayuda.sqland = " AND ";
                frmayuda.criteriosbusqueda = new string[] { "NUMERO" };
                frmayuda.columbusqueda = "numdoc";
                frmayuda.returndatos = "0,1,2,3,4";
                frmayuda.Owner = this;
                frmayuda.PasaProveedor = Recibe;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void Recibe(String xdoc, String xop, String xfaseid, String xarticidold, String xarticname)
        {
            txt_serfase.Text = Equivalencias.Left(xdoc, 4).ToString();
            txt_numfase.Text = Equivalencias.Right(xdoc, 10).ToString();
            txt_serop.Text = Equivalencias.Left(xop, 4).ToString();
            txt_numop.Text = Equivalencias.Right(xop, 10).ToString();
            txt_articidold.Text = xarticidold.ToString();
            txt_articname.Text = xarticname.ToString();

            CargamosSecuenciaCmb();
            cmb_secuencia.SelectedValue = xfaseid.ToString();

            form_bloqueado(true);
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_salir.Enabled = true;
            //cmb_tipdoc.Enabled = false;
            txt_numop.Enabled = false;
            //btn_new.Enabled = true;

            ///**********************
            // * CARGAMOS EL COMBO DE COLORES       
            // * ******************/
            CargamosColorCmb();

            DataTable datactacte = new DataTable();
            String Query2 = " SELECT (CONVERT(VARCHAR, opf.secuencia) + ' = ' + f.fasename) secuencia,opf.faseid,cl.ctacte,cl.ctactename " +
                           " FROM tb_pp_ordenprodfase opf " +
                           " LEFT JOIN tb_pp_fase f ON opf.faseid = f.faseid " +
                           " LEFT JOIN tb_cliente cl ON opf.ctacte = cl.ctacte " +
                           " WHERE opf.tipop = 'OP'  AND opf.serop = '" + txt_serop.Text + "' AND opf.numop = '" + txt_numop.Text + "' and opf.faseid = '"+xfaseid.ToString()+"'";
            datactacte = DatosSQL(Query2);

            if (datactacte.Rows.Count > 0)
            {
                xctacte = datactacte.Rows[0]["ctacte"].ToString();
                txt_servtaller.Text = datactacte.Rows[0]["ctactename"].ToString();
            }
            else
            {
                xctacte = "";
                txt_servtaller.Text = "";
            }


        }

        private void txt_peso_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(ActiveControl.Text))
            {
                txt_peso.SelectionStart = 0;
                txt_peso.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void txt_precunitpeso_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(ActiveControl.Text))
            {
                txt_precunitpeso.SelectionStart = 0;
                txt_precunitpeso.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void txt_precunit_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(ActiveControl.Text))
            {
                txt_precunit.SelectionStart = 0;
                txt_precunit.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void btn_quitar_Click(object sender, EventArgs e)
        {
            DeleteRowTable();
            CalculosTotales();
        }


        void DeleteRowTable()
        {
            int lc_cont = 0;
            if ((dgv_ordenserv.RowCount > 0))
            {
                var xcolorid = dgv_ordenserv.Rows[dgv_ordenserv.CurrentCell.RowIndex].Cells["gcolorid"].Value.ToString();

                for (lc_cont = 0; lc_cont <= this.TablaOrdenServ.Rows.Count - 1; lc_cont++)
                {
                    // ubique la fila a borrar de acuerdo a los codigos validados
                    if (this.TablaOrdenServ.Rows[lc_cont]["colorid"].ToString() == xcolorid)
                    {
                        this.TablaOrdenServ.Rows[lc_cont].Delete();
                        this.TablaOrdenServ.AcceptChanges();
                        break;
                    }
                }
            }
        }

        private void cmb_color_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_color.SelectedIndex != -1)
            {
                if (cmb_color.Text != "System.Data.DataRowView" && cmb_color.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    try
                    {
                        DataTable dt = new DataTable();
                        String Query = " SELECT colorid,sum(cantidad)cant from tb_pp_ordenprodcolor opf " +
                                        " WHERE opf.tipop = 'OP'  AND opf.serop = '" + txt_serop.Text + "' " +
                                        " AND opf.numop = '" + txt_numop.Text + "' and opf.colorid = '" + cmb_color.SelectedValue.ToString() + "'" +
                                        " GROUP BY colorid  ";
                        dt = DatosSQL(Query);

                        if (dt.Rows.Count > 0)
                            txt_cantidad.Text = dt.Rows[0]["cant"].ToString();
                        else
                            txt_cantidad.Text = "0";
                        
                        CalImporteLineal();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);                   
                    }  
                }
            }
        }

        private void txt_precunit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_importe.Text = (Convert.ToDouble(txt_precunit.Text) * Convert.ToDouble(txt_cantidad.Text)).ToString("###,##0.0000");
            }
        }

        private void txt_precunit_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_precunit.Text.Length > 0)
            {
                txt_importe.Text = (Convert.ToDouble(txt_precunit.Text) * Convert.ToDouble(txt_cantidad.Text)).ToString("###,##0.0000");
            }
        }


        private void txt_peso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalImporteLineal();
                //txt_importe.Text = (Convert.ToDouble(txt_peso.Text) * Convert.ToDouble(txt_precunitpeso.Text)).ToString("###,##0.0000");
                //txt_precunit.Text = (Convert.ToDouble(txt_importe.Text) / Convert.ToInt32(txt_cantidad.Text)).ToString("###,##0.0000");
            }
        }

        private void txt_precunitpeso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalImporteLineal();
                //txt_importe.Text = (Convert.ToDouble(txt_peso.Text) * Convert.ToDouble(txt_precunitpeso.Text)).ToString("###,##0.0000");
                //txt_precunit.Text = (Convert.ToDouble(txt_importe.Text) / Convert.ToInt32(txt_cantidad.Text)).ToString("###,##0.0000");
            }
        }

        private void txt_peso_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_peso.Text.Length > 0)
            {
                CalImporteLineal();
                //txt_importe.Text = (Convert.ToDouble(txt_peso.Text) * Convert.ToDouble(txt_precunitpeso.Text)).ToString("###,##0.0000");
                //txt_precunit.Text = (Convert.ToDouble(txt_importe.Text) / Convert.ToInt32(txt_cantidad.Text)).ToString("###,##0.0000");
            }
        }

        private void txt_precunitpeso_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_precunitpeso.Text.Length > 0)
            {
                CalImporteLineal();
                //txt_importe.Text = (Convert.ToDouble(txt_peso.Text) * Convert.ToDouble(txt_precunitpeso.Text)).ToString("###,##0.0000");
                //txt_precunit.Text = (Convert.ToDouble(txt_importe.Text) / Convert.ToInt32(txt_cantidad.Text)).ToString("###,##0.0000");
            }
        }


        void CalImporteLineal()
        {
            if (txt_precunit.Enabled == false)
            {
                txt_importe.Text = (Convert.ToDouble(txt_peso.Text) * Convert.ToDouble(txt_precunitpeso.Text)).ToString("###,##0.0000");
                txt_precunit.Text = (Convert.ToDouble(txt_importe.Text) / Convert.ToInt32(txt_cantidad.Text)).ToString("###,##0.0000");
            }
            else
            {
                txt_importe.Text = (Convert.ToDouble(txt_precunit.Text) * Convert.ToDouble(txt_cantidad.Text)).ToString("###,##0.0000");
                txt_peso.Text = "0";
                txt_precunitpeso.Text = "0";
            }
        }

        private void dgv_ordenserv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_quitar.Enabled = true;
        }

        private void txt_busqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    String xnumserv = "";
                    xnumserv = txt_busqueda.Text.PadLeft(10, '0');
                    CargarDatosOrdServ(xnumserv);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }   
        }

        void CargamosSecuenciaCmb()
        {
            DataTable dt2 = new DataTable();
            String Query = " SELECT (CONVERT(VARCHAR, opf.secuencia) + ' = ' + f.fasename) secuencia,opf.faseid,cl.ctactename " +
                           " FROM tb_pp_ordenprodfase opf " +
                           " LEFT JOIN tb_pp_fase f ON opf.faseid = f.faseid " +
                           " LEFT JOIN tb_cliente cl ON opf.ctacte = cl.ctacte " +
                           " WHERE opf.tipop = 'OP'  AND opf.serop = '" + txt_serop.Text + "' AND opf.numop = '" + txt_numop.Text + "'";
            dt2 = DatosSQL(Query);
            cmb_secuencia.DataSource = dt2;
            cmb_secuencia.ValueMember = "faseid";
            cmb_secuencia.DisplayMember = "secuencia";
        }

        void CargamosColorCmb()
        {
            tb_pp_ordenprodfasemoviBL BL2 = new tb_pp_ordenprodfasemoviBL();
            tb_pp_ordenprodfasemovi BE2 = new tb_pp_ordenprodfasemovi();
            DataTable dt2 = new DataTable();
            BE2.tipop = "OP";
            BE2.serop = txt_serop.Text;
            BE2.numop = txt_numop.Text;
            BE2.filtro = "1";
            dt2 = BL2.GetAll(EmpresaID, BE2).Tables[0];

            cmb_color.DataSource = dt2;
            cmb_color.ValueMember = "colorid";
            cmb_color.DisplayMember = "colorname";
            cmb_color.SelectedIndex = -1;
        }


        void CargarDatosOrdServ(String xnumserv)
        {
            tb_pp_ordenservicioBL BL = new tb_pp_ordenservicioBL();
            tb_pp_ordenservicio BE = new tb_pp_ordenservicio();
            DataTable dt = new DataTable();
        
            BE.tipos = "OS";
            BE.seros = "2015";
            BE.numos = xnumserv;
            BE.Idx = "CAB"; // BUSCAMOS LA CABECERA

            dt = BL.GetAllCab(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["estado"].ToString().Trim() != "9")
                {
                    txt_seros.Text = dt.Rows[0]["seros"].ToString();
                    txt_numos.Text = dt.Rows[0]["numos"].ToString();
                    txt_fechini.Text = dt.Rows[0]["fechini"].ToString();
                    txt_fechfin.Text = dt.Rows[0]["fechfin"].ToString();
                    
                    txt_serfac.Text = dt.Rows[0]["serfac"].ToString();
                    txt_numfac.Text = dt.Rows[0]["numfac"].ToString();
                    txt_serguia.Text = dt.Rows[0]["sergr"].ToString();
                    txt_numguia.Text = dt.Rows[0]["numgr"].ToString();
                    txt_serop.Text = dt.Rows[0]["serop"].ToString();
                    txt_numop.Text = dt.Rows[0]["numop"].ToString();
                    
                    txt_serfase.Text = dt.Rows[0]["serfas"].ToString();
                    txt_numfase.Text = dt.Rows[0]["numfas"].ToString();

                    txt_articidold.Text = dt.Rows[0]["articidold"].ToString();
                    txt_articname.Text = dt.Rows[0]["articname"].ToString();
                    xctacte = dt.Rows[0]["ctacte"].ToString();                    
                    txt_servtaller.Text = dt.Rows[0]["ctactename"].ToString();

                    CargamosSecuenciaCmb();                  
                    cmb_secuencia.SelectedValue = dt.Rows[0]["faseid"].ToString();
                    CargamosColorCmb();

                    cmb_estado.SelectedIndex = Convert.ToInt32(dt.Rows[0]["estado"].ToString());

                    cmb_moneda.SelectedValue = dt.Rows[0]["moneda"].ToString();
                    tcamb.Text = dt.Rows[0]["tcambio"].ToString();
                    rdb_servid.SelectedIndex = dt.Rows[0]["tcambio"].ToString() == "1" ? 0 : 1;
                    txt_observacion.Text = dt.Rows[0]["observacion"].ToString();

                    txt_totprendas.Text = dt.Rows[0]["cantidad"].ToString();
                    txt_totpeso.Text = dt.Rows[0]["peso"].ToString();
                    txt_subtotal.Text = dt.Rows[0]["bimpo"].ToString();
                    txt_igv.Text = dt.Rows[0]["migv"].ToString();
                    txt_totneto.Text = dt.Rows[0]["pvent"].ToString();


                    BE.Idx = "DET"; //BUSCAMOS EL DETALLE
                    TablaOrdenServ = BL.GetAllDet(EmpresaID, BE).Tables[0];
                    dgv_ordenserv.DataSource = TablaOrdenServ;

                    btn_editar.Enabled = true;
                    btn_eliminar.Enabled = true;
                    btn_imprimir.Enabled = true;
                    btn_salir.Enabled = true;
                    pdtimagen.Visible = false;
                }
                else
                {
                    txt_seros.Text = dt.Rows[0]["seros"].ToString();
                    txt_numos.Text = dt.Rows[0]["numos"].ToString();
                    txt_fechini.Text = dt.Rows[0]["fechini"].ToString();
                    txt_fechfin.Text = dt.Rows[0]["fechfin"].ToString();

                    txt_serfac.Text = dt.Rows[0]["serfac"].ToString();
                    txt_numfac.Text = dt.Rows[0]["numfac"].ToString();
                    txt_serguia.Text = dt.Rows[0]["sergr"].ToString();
                    txt_numguia.Text = dt.Rows[0]["numgr"].ToString();
                    txt_serop.Text = dt.Rows[0]["serop"].ToString();
                    txt_numop.Text = dt.Rows[0]["numop"].ToString();

                    txt_serfase.Text = dt.Rows[0]["serfas"].ToString();
                    txt_numfase.Text = dt.Rows[0]["numfas"].ToString();

                    txt_articidold.Text = dt.Rows[0]["articidold"].ToString();
                    txt_articname.Text = dt.Rows[0]["articname"].ToString();
                    xctacte = dt.Rows[0]["ctacte"].ToString();
                    txt_servtaller.Text = dt.Rows[0]["ctactename"].ToString();

                    CargamosSecuenciaCmb();
                    cmb_secuencia.SelectedValue = dt.Rows[0]["faseid"].ToString();
                    CargamosColorCmb();

                    cmb_estado.SelectedIndex = Convert.ToInt32(dt.Rows[0]["estado"].ToString());

                    cmb_moneda.SelectedValue = dt.Rows[0]["moneda"].ToString();
                    tcamb.Text = dt.Rows[0]["tcambio"].ToString();
                    rdb_servid.SelectedIndex = dt.Rows[0]["tcambio"].ToString() == "1" ? 0 : 1;
                    txt_observacion.Text = dt.Rows[0]["observacion"].ToString();

                    txt_totprendas.Text = dt.Rows[0]["cantidad"].ToString();
                    txt_totpeso.Text = dt.Rows[0]["peso"].ToString();
                    txt_subtotal.Text = dt.Rows[0]["bimpo"].ToString();
                    txt_igv.Text = dt.Rows[0]["migv"].ToString();
                    txt_totneto.Text = dt.Rows[0]["pvent"].ToString();

                    BE.Idx = "DET"; //BUSCAMOS EL DETALLE
                    TablaOrdenServ = BL.GetAllDet(EmpresaID, BE).Tables[0];
                    dgv_ordenserv.DataSource = TablaOrdenServ;

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
                    //ValidaArticulo();
                    btn_cancelar.Enabled = true;
                    btn_grabar.Enabled = true;                   
                    cmb_estado.Enabled = false; // Porque El Estado se Modifica por Otro Lado                                   
                }
            }
        }






    }

}
