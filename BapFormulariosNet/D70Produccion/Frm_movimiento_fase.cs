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
    public partial class Frm_movimiento_fase : plantilla
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
        private String ssModo = "";
        private String xarticid = "";

        private DataTable TablaMovFases;

        public Frm_movimiento_fase()
        {
            InitializeComponent();
        }
     
        private void Frm_movimiento_fase_Load(object sender, EventArgs e)
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
            CargarTipoDoc();
            CargarCalidad();
            TmpOrdenProdMovFases();
            form_bloqueado(false);
            limpiar_documento();
            btn_nuevo.Enabled = true;
            btn_salir.Enabled = true;    
        }

        void TmpOrdenProdMovFases()
        {
            TablaMovFases = new DataTable();
            TablaMovFases.Columns.Add("primera", typeof(Boolean));
            TablaMovFases.Columns.Add("colorid", typeof(String));
            TablaMovFases.Columns.Add("colorname", typeof(String));
            TablaMovFases.Columns.Add("can01", typeof(Int32));
            TablaMovFases.Columns.Add("can02", typeof(Int32));
            TablaMovFases.Columns.Add("can03", typeof(Int32));
            TablaMovFases.Columns.Add("can04", typeof(Int32));
            TablaMovFases.Columns.Add("can05", typeof(Int32));
            TablaMovFases.Columns.Add("can06", typeof(Int32));
            TablaMovFases.Columns.Add("can07", typeof(Int32));
            TablaMovFases.Columns.Add("can08", typeof(Int32));
            TablaMovFases.Columns.Add("can09", typeof(Int32));
            TablaMovFases.Columns.Add("can10", typeof(Int32));
            TablaMovFases.Columns.Add("can11", typeof(Int32));
            TablaMovFases.Columns.Add("can12", typeof(Int32));
            TablaMovFases.Columns.Add("cantot", typeof(Int32));
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

        void CargarTipoDoc()
        {
            try
            {
                var BL = new modulo_local_tipodocBL();
                var BE = new tb_modulo_local_tipodoc();
                BE.dominioid = dominio;
                BE.moduloid = modulo;
                BE.local = local;
                BE.visiblealmac = true;
                BE.status = string.Empty;
                BE.tipodoctipotransac = "M";

                cmb_tipdoc.DataSource = BL.GetAll_mov(EmpresaID, BE).Tables[0];
                cmb_tipdoc.ValueMember = "almacaccionid";
                cmb_tipdoc.DisplayMember = "tipodoc";
                cmb_tipdoc.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void CargarMotivos()
        {
            try
            {
                var BL = new tb_mottrasladointBL();
                var BE = new tb_mottrasladoint();
                DataTable dt = new DataTable();
                BE.moduloid = modulo;
                BE.tipmov = Equivalencias.Left(cmb_tipdoc.SelectedValue.ToString(),1).ToString();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    cmb_motivo.DataSource = dt;
                    cmb_motivo.ValueMember = "mottrasladointid";
                    cmb_motivo.DisplayMember = "mottrasladointname";
                    cmb_motivo.SelectedIndex = -1;

                    cmb_motivo.Enabled = true;
                    txt_serop.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void CargarCalidad()
        {
            DataTable dt;
            dt = new DataTable("Tabla");

            dt.Columns.Add("calidadid");
            dt.Columns.Add("calidadname");

            DataRow dr;

            dr = dt.NewRow();
            dr["calidadid"] = "1";
            dr["calidadname"] = "PRIMERA";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["calidadid"] = "0";
            dr["calidadname"] = "SEGUNDA";
            dt.Rows.Add(dr);

            cmb_calidad.DataSource = dt;
            cmb_calidad.ValueMember = "calidadid";
            cmb_calidad.DisplayMember = "calidadname";
            cmb_calidad.SelectedIndex = -1;
        }

        private void cmb_tipdoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btn_nuevo.Enabled == false)
            {
                CargarMotivos();
                //
                Gen_numMov();
                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
                btn_salir.Enabled = true;
                cmb_tipdoc.Enabled = false;
            }
        }

        private void Gen_numMov()
        {
            try
            {
                var BL = new tb_pp_ordenprodfasemoviBL();
                var BE = new tb_pp_ordenprodfasemovi();
                var dt = new DataTable();

                BE.dominioid = dominio.ToString();
                BE.moduloid = modulo.ToString();
                BE.tipodoc = cmb_tipdoc.Text.ToString();

                dt = BL.GetAll_num(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    txt_numdoc.Text = dt.Rows[0]["numero"].ToString();
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


        private void btn_nuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XNIVEL == "0")
            {
                nuevo();
                if (TablaMovFases != null)
                {
                    TablaMovFases.Rows.Clear();
                }
            }
        }

        private void nuevo()
        {
            limpiar_documento();
            cmb_tipdoc.Enabled = true;
            cmb_tipdoc.SelectedIndex = -1;
            btn_nuevo.Enabled = false;
            btn_cancelar.Enabled = true;           
            ssModo = "NEW";
        }

        private void limpiar_documento()
        {
            try
            {
                txt_fechdoc.Text = DateTime.Today.ToShortDateString();
                xarticid = "";
                txt_articidold.Text = "";
                txt_articname.Text = "";

                cmb_motivo.SelectedIndex = -1;
                txt_serop.Text = "";
                txt_numop.Text = "";
                txt_servtaller.Text = "";

                cmb_calidad.SelectedIndex = -1;
                cmb_color.SelectedIndex = -1;
                cmb_talla.SelectedIndex = -1;
                cmb_secuencia.SelectedIndex = -1;
                txt_cantidad.Text = "0";
                txt_saldo.Text = "0";

                txt_numdoc.Text = "__________";

                if (dgv_color.RowCount > 0)
                    dgv_color.DataSource = TablaMovFases;

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
                cmb_tipdoc.Enabled = var;
                cmb_motivo.Enabled = var;

                txt_serop.Enabled = var;
                txt_numop.Enabled = var;
                cmb_secuencia.Enabled = var;

                cmb_calidad.Enabled = var;
                cmb_color.Enabled = var;                
                cmb_talla.Enabled = var;

                txt_cantidad.Enabled = var;
                btn_agregar.Enabled = var;

                btn_nuevo.Enabled = false;
                btn_editar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_grabar.Enabled = false;
                btn_eliminar.Enabled = false;
                btn_clave.Enabled = true;   
                btn_salir.Enabled = false;

                btn_agregar.Enabled = false;
                btn_act.Enabled = false;
                btn_quitar.Enabled = false;
                btn_new.Enabled = false;


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

        private void RecibeData(String x1,String x2,String x3,String x4,String x5)
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
                cmb_tipdoc.Enabled = false;
                txt_numop.Enabled = false;
              
                btn_new.Enabled = true;


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
                var BL3 = new tb_pp_ordenprodfasemoviBL();
                var BE3 = new tb_pp_ordenprodfasemovi();
                var dt3 = new DataTable();

                BE3.tipop = "OP";
                BE3.serop = txt_serop.Text;
                BE3.numop = txt_numop.Text;
                BE3.filtro = "1";

                dt3 = BL3.GetAllPropColor_PIVOT(EmpresaID, BE3).Tables[0];
                dgv_color.AutoGenerateColumns = false;
                dgv_color.DataSource = dt3;

                ValidaArticulo();          
                CalculosTotales();
                   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        void ValidaArticulo()
        {
            try
            {
                tb_pt_articuloBL BL = new tb_pt_articuloBL();
                tb_pt_articulo BE = new tb_pt_articulo();
                DataTable dt = new DataTable();
            
                BE.top = true;
                BE.articidold = txt_articidold.Text;
                if (txt_articidold.Text.ToString().Trim().Length == 7)
                {
                    dt = BL.GetAll(EmpresaID, BE).Tables[0];
                    if (dt.Rows.Count > 0)
                    {                        
                        /**************************
                        * PONEMOS NOMBRE A LAS COLUMNAS DEACUERDO A LA TALLAID                 
                        * ***************/
                        tb_pt_tallaBL BL4 = new tb_pt_tallaBL();
                        tb_pt_talla BE4 = new tb_pt_talla();
                        DataTable tall = new DataTable();
                        BE4.tallaid = dt.Rows[0]["tallaid"].ToString();
                        tall = BL4.GetAll(EmpresaID, BE4).Tables[0];

                        dgv_color.Columns[3].HeaderText = tall.Rows[0]["talla01"].ToString();
                        dgv_color.Columns[4].HeaderText = tall.Rows[0]["talla02"].ToString();
                        dgv_color.Columns[5].HeaderText = tall.Rows[0]["talla03"].ToString();
                        dgv_color.Columns[6].HeaderText = tall.Rows[0]["talla04"].ToString();
                        dgv_color.Columns[7].HeaderText = tall.Rows[0]["talla05"].ToString();
                        dgv_color.Columns[8].HeaderText = tall.Rows[0]["talla06"].ToString();
                        dgv_color.Columns[9].HeaderText = tall.Rows[0]["talla07"].ToString();
                        dgv_color.Columns[10].HeaderText = tall.Rows[0]["talla08"].ToString();
                        dgv_color.Columns[11].HeaderText = tall.Rows[0]["talla09"].ToString();
                        dgv_color.Columns[12].HeaderText = tall.Rows[0]["talla10"].ToString();
                        dgv_color.Columns[13].HeaderText = tall.Rows[0]["talla11"].ToString();
                        dgv_color.Columns[14].HeaderText = tall.Rows[0]["talla12"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
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
                if (dgv_color.RowCount > 0)
                    dgv_color.DataSource = TablaMovFases;
                form_bloqueado(false);
                btn_nuevo.Enabled = true;
                ssModo = "NEW";
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
                        //Update();
                    }
                }
            }
            if (procesado)
            {
                NIVEL_FORMS();
                limpiar_documento();
                form_bloqueado(false);
                btn_nuevo.Enabled = true;
                btn_salir.Enabled = true;
                if (TablaMovFases.Rows.Count > 0)
                    TablaMovFases.Clear();
                dgv_color.DataSource = TablaMovFases;

                //Datos(txt_articid.Text, txt_colorid.Text, xcoltalla);
                //Close();
            }
        }

        private void Insert()
        {
            try
            {
                tb_pp_ordenprodfasemoviBL BL = new tb_pp_ordenprodfasemoviBL();
                tb_pp_ordenprodfasemovi BE = new tb_pp_ordenprodfasemovi();

                var Item = new tb_pp_ordenprodfasemovi.Item();
                var ListaItems = new List<tb_pp_ordenprodfasemovi.Item>();

                #region Variables de RecetasCab
                BE.tipodoc = cmb_tipdoc.Text;
                BE.serdoc = txt_serdoc.Text;
                BE.numdoc = txt_numdoc.Text;
                BE.fechdoc = Convert.ToDateTime(txt_fechdoc.Text);
                BE.almacaccionid = cmb_tipdoc.SelectedValue.ToString();
                BE.moduloid = modulo;
                BE.mottrasladointid = cmb_motivo.SelectedValue.ToString();
                BE.tipop = "OP";
                BE.serop = txt_serop.Text;
                BE.numop = txt_numop.Text;
                BE.secuencia =  Convert.ToInt32(Equivalencias.Left(cmb_secuencia.Text, 1));
                BE.faseid = Convert.ToInt32(cmb_secuencia.SelectedValue.ToString());
                BE.status = "0";
                BE.usuar = VariablesPublicas.Usuar.ToUpper().Trim();
                                            
                #endregion                

                var num = 1;
                for (int i = 0; i < dgv_color.RowCount; i++)
                {
                    for (int j = 3; j < dgv_color.Columns.Count - 1; j++)
                    {
                        Item = new tb_pp_ordenprodfasemovi.Item();
                        Boolean dr = Convert.ToBoolean(dgv_color.Rows[i].Cells[0].Value.ToString());
                        Item.primera = Convert.ToBoolean(dgv_color.Rows[i].Cells[0].Value.ToString());
                        Item.colorid = dgv_color.Rows[i].Cells["colorid"].Value.ToString();
                        Item.coltalla = num.ToString().PadLeft(2, '0');
                        Item.cantidad = Convert.ToInt32(dgv_color.Rows[i].Cells[j].Value.ToString());                        
                        num++;
                        ListaItems.Add(Item);
                    }
                    num = 1;
                }

                if (ListaItems.Count == 0)
                {
                    MessageBox.Show("Documento SIN DETALLE Y/O DETALLE INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
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

        private void btn_eliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_salir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btn_editar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void cmb_secuencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_secuencia.SelectedIndex != -1)
            {
                if (cmb_secuencia.Text != "System.Data.DataRowView" && cmb_secuencia.SelectedValue.ToString() != "System.Data.DataRowView")
                {

                    DataTable dt = new DataTable();
                    String Query = " SELECT opf.ctacte,cl.ctactename " +
                                   " FROM tb_pp_ordenprodfase opf  " +
                                   " LEFT JOIN tb_cliente cl ON opf.ctacte = cl.ctacte " +
                                   " WHERE opf.tipop = 'OP'  AND opf.serop = '" + txt_serop.Text + "' AND opf.numop = '" + txt_numop.Text + "' " +
                                   " AND opf.faseid = '" + cmb_secuencia.SelectedValue.ToString() + "'";
                    dt = DatosSQL(Query);
                    if (dt.Rows.Count > 0)
                    {
                        txt_servtaller.Text = dt.Rows[0]["ctactename"].ToString();
                    }
                }
            }
        }

        private void cmb_color_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_color.SelectedIndex != -1)
            { 
                //Segun se Escoge el Color cargar las tallas 
                if (cmb_color.Text != "System.Data.DataRowView" && cmb_color.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    tb_pp_ordenprodfasemoviBL BL = new tb_pp_ordenprodfasemoviBL();
                    tb_pp_ordenprodfasemovi BE = new tb_pp_ordenprodfasemovi();
                    DataTable dt2 = new DataTable();
                    BE.tipop = "OP";
                    BE.serop = txt_serop.Text;
                    BE.numop = txt_numop.Text;
                    BE.colorid = cmb_color.SelectedValue.ToString();
                    BE.filtro = "2";
                    dt2 = BL.GetAll(EmpresaID, BE).Tables[0];

                    cmb_talla.DataSource = dt2;
                    cmb_talla.ValueMember = "coltalla";
                    cmb_talla.DisplayMember = "tallaname";
                    cmb_talla.SelectedIndex = -1;
                }
            }
        }

        private void cmb_talla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_talla.SelectedIndex != -1)
            { 
                //Segun se Escoge la Talla Cargar el Saldo
                if (cmb_talla.Text != "System.Data.DataRowView" && cmb_talla.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    tb_pp_ordenprodfasemoviBL BL = new tb_pp_ordenprodfasemoviBL();
                    tb_pp_ordenprodfasemovi BE = new tb_pp_ordenprodfasemovi();
                    DataTable dt2 = new DataTable();
                    BE.tipop = "OP";
                    BE.serop = txt_serop.Text;
                    BE.numop = txt_numop.Text;
                    BE.colorid = cmb_color.SelectedValue.ToString();
                    BE.coltalla = cmb_talla.SelectedValue.ToString();
                    BE.filtro = "3";
                    dt2 = BL.GetAll(EmpresaID, BE).Tables[0];

                    if (dt2.Rows.Count > 0)
                        txt_saldo.Text = dt2.Rows[0]["cantidad"].ToString();                    
                }

            }
        }

        private void dgv_color_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_color.CurrentRow != null)
                {
                    Boolean xprim = Convert.ToBoolean(dgv_color.Rows[e.RowIndex].Cells["primera"].Value.ToString());
                    if (xprim)
                        cmb_calidad.SelectedIndex = 0;
                    else
                        cmb_calidad.SelectedIndex = 1;

                    cmb_color.SelectedValue = dgv_color.Rows[e.RowIndex].Cells["colorid"].Value.ToString().Trim();
                    if (Equivalencias.Left(dgv_color.Columns[e.ColumnIndex].Name.ToString(), 5) == "talla")
                    {
                        String xcant = dgv_color.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        txt_cantidad.Text = xcant;

                        String xcoltall = Equivalencias.Right(dgv_color.Columns[e.ColumnIndex].Name.ToString(), 2);
                        cmb_talla.SelectedValue = xcoltall.ToString();
                    }

                    btn_agregar.Enabled = false;
                    btn_act.Enabled = true;
                    btn_quitar.Enabled = true;
                    btn_new.Enabled = true;                 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        Boolean ValidaDatos()
        {
            Boolean val = true;
            if (cmb_calidad.SelectedIndex == -1)
            {
                val = false;
                MessageBox.Show("Seleccionar una Calidad", "Mensaje !!!");
            }
            else if (cmb_color.Text.ToString().Length == 0)
            {
                val = false;
                MessageBox.Show("Seleccionar un Color Determinado", "Mensaje !!!");
            }
            else if (cmb_talla.Text.ToString().Length == 0)
            {
                val = false;
                MessageBox.Show("Seleccionar una Talla Determinada", "Mensaje !!!");
            }
            else if (txt_cantidad.Text.ToString().Length == 0)
            {
                val = false;
                MessageBox.Show("Poner una Cantidad", "Mensaje !!!");
            }

            return val;
        }


        Boolean ValidaDatos2()
        {
            Boolean valor = true,xprime,xprimeralocal;
            String  xcolorid = "";
            foreach (DataGridViewRow fila in dgv_color.Rows)
            {
                xprime = Convert.ToBoolean(fila.Cells["primera"].Value.ToString());
                xcolorid = fila.Cells["colorid"].Value.ToString();
                xprimeralocal = cmb_calidad.SelectedIndex == 0 ? true : false;

                if (xprime.Equals(xprimeralocal) && xcolorid.Equals(cmb_color.SelectedValue.ToString()))
                {
                    valor = false;
                    MessageBox.Show("Existen Los Mismos Datos... Cambiarlo", "Mensaje");
                }
                //else if (xcolorid.Equals(cmb_color.SelectedValue.ToString()))
                //{
                //    valor = false;
                //    MessageBox.Show("Existen Datos Iguales en el Detalle ... Cambiarlo", "Mensaje");
                //}
            }
            return valor;
        }


        void AddRowTable()
        {
            row = TablaMovFases.NewRow();
            row["primera"] = cmb_calidad.SelectedIndex == 0 ? true : false;
            row["colorid"] = cmb_color.SelectedValue.ToString();
            row["colorname"] = cmb_color.Text.ToString();
            row["can01"] = cmb_talla.SelectedValue.ToString() == "01" ? txt_cantidad.Text : "0";
            row["can02"] = cmb_talla.SelectedValue.ToString() == "02" ? txt_cantidad.Text : "0";
            row["can03"] = cmb_talla.SelectedValue.ToString() == "03" ? txt_cantidad.Text : "0";
            row["can04"] = cmb_talla.SelectedValue.ToString() == "04" ? txt_cantidad.Text : "0";
            row["can05"] = cmb_talla.SelectedValue.ToString() == "05" ? txt_cantidad.Text : "0";
            row["can06"] = cmb_talla.SelectedValue.ToString() == "06" ? txt_cantidad.Text : "0";
            row["can07"] = cmb_talla.SelectedValue.ToString() == "07" ? txt_cantidad.Text : "0";
            row["can08"] = cmb_talla.SelectedValue.ToString() == "08" ? txt_cantidad.Text : "0";
            row["can09"] = cmb_talla.SelectedValue.ToString() == "09" ? txt_cantidad.Text : "0";
            row["can10"] = cmb_talla.SelectedValue.ToString() == "10" ? txt_cantidad.Text : "0";
            row["can11"] = cmb_talla.SelectedValue.ToString() == "11" ? txt_cantidad.Text : "0";
            row["can12"] = cmb_talla.SelectedValue.ToString() == "12" ? txt_cantidad.Text : "0";
            row["cantot"] = txt_cantidad.Text;
            TablaMovFases.Rows.Add(row);
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaDatos())
                {
                    if (this.dgv_color.RowCount > 0)
                    {
                        // SEGUNDA VALIDACIÓN
                        if (ValidaDatos2())
                        {
                            int nFilaAnt = dgv_color.RowCount - 1;
                            TablaMovFases = new DataTable();
                            TmpOrdenProdMovFases();

                            foreach (DataGridViewRow fila in dgv_color.Rows)
                            {
                                row = TablaMovFases.NewRow();
                                row["primera"] = fila.Cells["primera"].Value;
                                row["colorid"] = fila.Cells["colorid"].Value;
                                row["colorname"] = fila.Cells["colorname"].Value;
                                row["can01"] = fila.Cells["talla01"].Value;
                                row["can02"] = fila.Cells["talla02"].Value;
                                row["can03"] = fila.Cells["talla03"].Value;
                                row["can04"] = fila.Cells["talla04"].Value;
                                row["can05"] = fila.Cells["talla05"].Value;
                                row["can06"] = fila.Cells["talla06"].Value;
                                row["can07"] = fila.Cells["talla07"].Value;
                                row["can08"] = fila.Cells["talla08"].Value;
                                row["can09"] = fila.Cells["talla09"].Value;
                                row["can10"] = fila.Cells["talla10"].Value;
                                row["can11"] = fila.Cells["talla11"].Value;
                                row["can12"] = fila.Cells["talla12"].Value;
                                row["cantot"] = fila.Cells["cantot"].Value;// txt_tacotot.Text;

                                TablaMovFases.Rows.Add(row);

                            }

                            AddRowTable();
                            dgv_color.DataSource = TablaMovFases;
                            CalculosTotales();
                        }
                    }
                    else
                    {
                        TmpOrdenProdMovFases();
                        AddRowTable();
                        dgv_color.DataSource = TablaMovFases;
                        CalculosTotales();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_quitar_Click(object sender, EventArgs e)
        {
            DeleteRowTableColor();
            CalculosTotales();
        }

        void CalculosTotales()
        {
            Boolean xprimera;
            Int32 xtotprimera = 0, xtotsegunda = 0, xcantot = 0;
            try
            {
                if (TablaMovFases.Rows != null)
                {
                    foreach (DataGridViewRow fila in dgv_color.Rows)
                    {
                        xprimera = Convert.ToBoolean(fila.Cells["primera"].Value.ToString());
                        xcantot = Convert.ToInt32(fila.Cells["cantot"].Value.ToString());
                        if (xprimera)
                            xtotprimera = xtotprimera + xcantot;
                        else
                            xtotsegunda = xtotsegunda + xcantot;
                    }

                    txt_totprimeras.Text = xtotprimera.ToString();
                    txt_tot_segundas.Text = xtotsegunda.ToString();

                    //if(TablaMovFases.Rows.Count > 0)
                    //    txt_tottot.Text = (dgv_color.RowCount > 0) ? Convert.ToInt32(TablaMovFases.Compute("sum(cantot)", "")).ToString() : "0";

                    txt_tottot.Text = (xtotprimera + xtotsegunda).ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);            
            }

         
            
        }


        void DeleteRowTableColor()
        {
            int lc_cont = 0;
            if ((dgv_color.RowCount > 0))
            {
                var xcolorid = dgv_color.Rows[dgv_color.CurrentCell.RowIndex].Cells["colorid"].Value.ToString();

                for (lc_cont = 0; lc_cont <= this.TablaMovFases.Rows.Count - 1; lc_cont++)
                {
                    // ubique la fila a borrar de acuerdo a los codigos validados
                    if (this.TablaMovFases.Rows[lc_cont]["colorid"].ToString() == xcolorid)
                    {
                        this.TablaMovFases.Rows[lc_cont].Delete();
                        this.TablaMovFases.AcceptChanges();
                        break;
                    }
                }
            }
        }

        private void txt_cantidad_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(ActiveControl.Text))
            {
                txt_cantidad.SelectionStart = 0;
                txt_cantidad.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            cmb_calidad.SelectedIndex = -1;
            cmb_color.SelectedIndex = -1;
            cmb_talla.SelectedIndex = -1;
            txt_cantidad.Text = "0";
            txt_saldo.Text = "0";

            btn_agregar.Enabled = true;
            btn_act.Enabled = false;
            btn_quitar.Enabled = false;
        }



    }
}
