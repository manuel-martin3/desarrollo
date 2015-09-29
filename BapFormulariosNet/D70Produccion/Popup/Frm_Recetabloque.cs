using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using LayerDataAccess;
using LayerBusinessEntities;
using LayerBusinessLogic;

using bapFunciones;

namespace BapFormulariosNet.D70Produccion.Popup
{
    public partial class Frm_Recetabloque : Form
    {
        public delegate void PasaDataDelegate(DataTable dtresultado);
        public PasaDataDelegate PasaData;

        public delegate void ValorBoolean(Boolean var);
        public ValorBoolean valor;

        public delegate void DatosValidar(String xval1,String xval2,String xval3);
        public DatosValidar Datos;

        
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;


        public String articid { get; set; }
        public String articname { get; set; }

        public String colorid { get; set; }
        public String colorname { get; set; }
        public String coltall { get; set; }
        public String tallaname { get; set; }
        public String version { get; set; }        
        String xcoltalla = "";
        String xarticid = "";
        private String ssModo = "NEW";
        private Boolean procesado = false;

        private DataTable Tabladetallecolor;
        private DataTable Tabladetallecolor2;

        private DataTable Tabla;
        private DataRow row;


        public Frm_Recetabloque()
        {
            InitializeComponent();
        }

        private void Frm_Recetabloque_Load(object sender, EventArgs e)
        {
            //if (Parent.Parent.Name == "MainProduccion")
            //{
            //    modulo = ((D70Produccion.MainProduccion)MdiParent).moduloid;
            //    local = ((D70Produccion.MainProduccion)MdiParent).local;
            //    //PERFILID = ((D70Produccion.MainProduccion)MdiParent).perfil;
            //}

            //if (Parent.Parent.Name == "MainTienda")
            //{
            //    modulo = ((D60Tienda.MainTienda)MdiParent).moduloid;
            //    local = ((D60Tienda.MainTienda)MdiParent).local;
            //    //PERFILID = ((D60Tienda.MainTienda)MdiParent).perfil;
            //}

            NIVEL_FORMS();                           
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_salir.Enabled = true;
           
            CargarDatos();
            cmb_estado.SelectedIndex = 0;
            CargarBloqueHoja();
            CargarBloqueHoja2();
        }

        void CargarBloqueHoja()
        {
            tb_pp_bloqhojacosto BE = new tb_pp_bloqhojacosto();
            tb_pp_bloqhojacostoBL BL = new tb_pp_bloqhojacostoBL();
            DataTable dt = new DataTable();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cmb_bloquehoja.DataSource = dt;
                cmb_bloquehoja.ValueMember = "bloqcostid";
                cmb_bloquehoja.DisplayMember = "bloqcostname";
            }
            txt_busqueda.Focus();
        }

        void CargarBloqueHoja2()
        {
            tb_pp_bloqhojacosto BE = new tb_pp_bloqhojacosto();
            tb_pp_bloqhojacostoBL BL = new tb_pp_bloqhojacostoBL();
            DataTable dt = new DataTable();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cmb_bloquehoja2.DataSource = dt;
                cmb_bloquehoja2.ValueMember = "bloqcostid";
                cmb_bloquehoja2.DisplayMember = "bloqcostname";
                cmb_bloquehoja2.SelectedIndex = -1;
            }          
        }

        private void NIVEL_FORMS()
        {
            XNIVEL = VariablesPublicas.Get_nivelperfil(PERFILID, Name).Substring(0, 1);
            if (XNIVEL != "0")
            {
                //btn_clave.Image = global::BapFormulariosNet.Properties.Resources.btn_Lock20;
            }
            else
            {
                //btn_clave.Image = global::BapFormulariosNet.Properties.Resources.btn_Un_Lock20;
            }
        }


        private void datosgeneral(String sqldata)
        {
            var conex = new ConexionDA();
            var dt = new DataTable();

            using (var cnx = new SqlConnection(conex.empConexion(VariablesPublicas.EmpresaID)))
            {
                using (var cmd = new SqlCommand("gspHelpSQL", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@sqlquery", SqlDbType.VarChar).Value = sqldata;
                    try
                    {
                        cnx.Open();
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                gridgeneral.AutoGenerateColumns = true;
                                gridgeneral.DataSource = dt;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        void CargarDatos()
        {
            txt_fechemi.Text = DateTime.Today.ToShortDateString();
            txt_articid.Text = articid;
            txt_articname.Text = articname;
            txt_colorid.Text = colorid;
            txt_colorname.Text = colorname;
            xcoltalla = coltall;
            txt_tallaname.Text = tallaname;
            txt_version.Text = version;
            xarticid = articid;

            Tabladetallecolor = new DataTable("detalle");
            Tabladetallecolor.Columns.Add("items", typeof(String));
            Tabladetallecolor.Columns.Add("bloqueid", typeof(String));
            Tabladetallecolor.Columns.Add("bloquename", typeof(String));
            Tabladetallecolor.Columns.Add("productid", typeof(String));
            Tabladetallecolor.Columns.Add("productname", typeof(String));                        
            Tabladetallecolor.Columns.Add("Cantidad", typeof(Int32));


            Tabladetallecolor2 = new DataTable("detalle2");
            Tabladetallecolor2.Columns.Add("items", typeof(String));
            Tabladetallecolor2.Columns.Add("bloqueid", typeof(String));
            Tabladetallecolor2.Columns.Add("bloquename", typeof(String));
            Tabladetallecolor2.Columns.Add("productid", typeof(String));
            Tabladetallecolor2.Columns.Add("productname", typeof(String));
            Tabladetallecolor2.Columns.Add("Cantidad", typeof(Int32));


            // Cargamos el Detalle Cuando una Receta ya haya sido Generada            
            if (Tabladetallecolor != null)
            {
                Tabladetallecolor.Rows.Clear();
                dgv_productos.DataSource = Tabladetallecolor;
            }

            tb_pp_recetaBL BL = new tb_pp_recetaBL();
            tb_pp_receta BE = new tb_pp_receta();
            DataTable dt = new DataTable();
            BE.articid = xarticid;
            BE.colorid = txt_colorid.Text;
            BE.version = txt_version.Text;
            BE.coltalla = xcoltalla;

            dt = BL.GetAll_Detalle(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                pnl_carga.Enabled = false;
                btn_nuevo.Enabled = true; // cambio a true
                btn_editar.Enabled = true;
                dgv_productos.ReadOnly = true;             
                txt_fechemi.Text = dt.Rows[0]["fechemi"].ToString();
                dgv_productos.DataSource = dt;
            }
            else
            {
                pnl_carga.Enabled = false;
                btn_nuevo.Enabled = true;                
                dgv_productos.ReadOnly = true;
                btn_editar.Enabled = false;
            }

        }

        private void form_bloqueado(Boolean var)
        {
            btn_add.Enabled = var;
            btn_cancelar.Enabled = var;
            dgv_productos.Columns["items"].ReadOnly = true;
            dgv_productos.Columns["bloqueid"].ReadOnly = true;
            dgv_productos.Columns["bloquename"].ReadOnly = true;            
            dgv_productos.Columns["productname"].ReadOnly = true;
            dgv_productos.Columns["cantidad"].ReadOnly = false;

            
            btn_nuevo.Enabled = false;
            btn_editar.Enabled = false;
            btn_cancelar.Enabled = false;
            btn_grabar.Enabled = false;
            btn_add.Enabled = false;
            btn_del.Enabled = false;    
            btn_clave.Enabled = true;         
            btn_salir.Enabled = false;
        }

      
        private void dgv_productos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                //if ((dgv_productos.CurrentCell != null))
                //{
                //    if (dgv_productos.CurrentCell.ReadOnly == false)
                //    {
                        if (dgv_productos.Columns[dgv_productos.CurrentCell.ColumnIndex].Name.ToUpper() == "productid".ToUpper())
                        {
                            AyudaProducto(string.Empty);
                        }
                //    }
                //}
            }
        }

        private void AyudaProducto(String lpdescrlike)
        {
            try
            {
                var modd = string.Empty;
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();

                BE.dominioid = dominio;
                BE.moduloid = "0330";
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();
                        var frmayuda = new Ayudas.Form_help_producto_bloque();
                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA PRODUCTO >>";                       
                        frmayuda.sqlquery = " SELECT tb1.productid, tb1.productname, 1 cantidad"+
                                            " FROM tb_" + modd + "_productos tb1 ";
                        frmayuda.sqlinner = "";                                                
                        frmayuda.sqlwhere = "WHERE tb1.status = '0' ";               
                        frmayuda.sqland = "AND";                      
                        frmayuda.sqlgroupby = "";                        

                        frmayuda.criteriosbusqueda = new string[] { "CODIGO", "PRODUCTO" };
                        frmayuda.columbusqueda = "tb1.productid,tb1.productname";
                        frmayuda.returndatos = "0,1,2";

                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeProducto;
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RecibeProducto(DataTable dtresultado)
        {
            try
            {
                if (dtresultado.Rows.Count > 0)
                {
                    var cont = 0;
                    foreach (DataRow fila in dtresultado.Rows)
                    {
                        cont = cont + 1;
                        if (dgv_productos.Rows.Count > 0)
                        {
                            var nFilaAnt = dgv_productos.RowCount - 1;
                            var xProductid = fila["productid"].ToString();
                            var xProductname = fila["productname"].ToString();
                            var xcantidad = fila["cantidad"].ToString();
                            var xbloqueid = fila["bloqueid"].ToString();
                            var xbloquename = fila["bloquename"].ToString();
                            var xnserie = string.Empty;

                            if (cont > 1)
                            {
                                Tabladetallecolor.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetallecolor));
                                Tabladetallecolor.Rows[Tabladetallecolor.Rows.Count - 1]["items"] = VariablesPublicas.CalcMaxField(Tabladetallecolor, "items", 5);
                                dgv_productos.Rows[nFilaAnt + 1].Cells["productid"].Value = xProductid;
                                dgv_productos.Rows[nFilaAnt + 1].Cells["productname"].Value = xProductname;
                                dgv_productos.Rows[nFilaAnt + 1].Cells["cantidad"].Value = xcantidad;
                                dgv_productos.Rows[nFilaAnt + 1].Cells["bloqueid"].Value = xbloqueid;
                                dgv_productos.Rows[nFilaAnt + 1].Cells["bloquename"].Value = xbloquename;
                            }
                            else
                            {
                                dgv_productos.Rows[nFilaAnt].Cells["productid"].Value = xProductid;
                                dgv_productos.Rows[nFilaAnt].Cells["productname"].Value = xProductname;
                                dgv_productos.Rows[nFilaAnt].Cells["cantidad"].Value = xcantidad;
                                dgv_productos.Rows[nFilaAnt].Cells["bloqueid"].Value = xbloqueid;
                                dgv_productos.Rows[nFilaAnt].Cells["bloquename"].Value = xbloquename;
                            }
                            //dgv_productos.CurrentCell = dgv_productos.Rows[dgv_productos.RowCount - 1].Cells["cantidad"];
                            //dgv_productos.BeginEdit(true);
                            //ValidaTabladetallemovmov(xProductid);
                        }
                        else
                        {
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btn_nuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Boolean sw_prosigue = false;
            if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
            {
                sw_prosigue = (MessageBox.Show("¿Desea Generar un Duplicado de Receta...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
                if (sw_prosigue)
                {
                    pnl_carga.Enabled = true;
                    txt_tallaname.Enabled = true;
                    btn_del.Enabled = true;
                    btn_salir.Enabled = true;
                    btn_cancelar.Enabled = true;
                    btn_grabar.Enabled = true;
                    btn_nuevo.Enabled = false;
                    btn_editar.Enabled = false;

                    ssModo = "NEW";
                }
                else
                {
                    nuevo();
                }
                
            }                                  
        }

        private void nuevo()
        {
            form_bloqueado(false);


            cmb_bloquehoja.SelectedIndex = -1;
            txt_busqueda.Text = "";
            if (Tabladetallecolor2.Rows.Count > 0)
                Tabladetallecolor2.Clear();

            pnl_carga.Enabled = true;
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_add.Enabled = true;
            btn_del.Enabled = true;
            ssModo = "NEW";
        }

        private void btn_add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (dgv_productos.Enabled)
                {
                    if (dgv_productos.Rows.Count > 0)
                    {
                        var xcantidad = Convert.ToString(dgv_productos.CurrentRow.Cells["cantidad"].Value);
                        if (xcantidad != "0" && xcantidad != string.Empty)
                        {
                            if (dgv_productos.Rows[dgv_productos.RowCount - 1].Cells["productid"].Value.ToString().Trim().Length > 0)
                            {
                                dgv_productos.Rows[dgv_productos.RowCount - 1].Cells["productid"].Value.ToString();
                                dgv_productos.Rows[dgv_productos.RowCount - 1].Cells["productname"].Value.ToString();
                                Tabladetallecolor.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetallecolor));
                                Tabladetallecolor.Rows[Tabladetallecolor.Rows.Count - 1]["items"] = VariablesPublicas.CalcMaxField(Tabladetallecolor, "items", 5);

                                dgv_productos.CurrentCell = dgv_productos.Rows[dgv_productos.RowCount - 1].Cells["productid"];
                                //dgv_productos.BeginEdit(true);                             
                            }
                            else
                            {
                                MessageBox.Show("Ingrese producto !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ingrese Cantidad  !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        dgv_productos.Columns["productid"].ReadOnly = false;
                        Tabladetallecolor.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetallecolor));
                        Tabladetallecolor.Rows[Tabladetallecolor.Rows.Count - 1]["items"] = VariablesPublicas.CalcMaxField(Tabladetallecolor, "items", 5);
                        dgv_productos.CurrentCell = dgv_productos.Rows[dgv_productos.RowCount - 1].Cells["productid"];
                        //dgv_productos.BeginEdit(true);                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_del_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var lc_cont = 0;
            var xcoditem = string.Empty;
            if ((dgv_productos.CurrentRow != null))
            {
                xcoditem = dgv_productos.Rows[dgv_productos.CurrentCell.RowIndex].Cells["items"].Value.ToString();
                for (lc_cont = 0; lc_cont <= Tabladetallecolor.Rows.Count - 1; lc_cont++)
                {
                    if (Tabladetallecolor.Rows[lc_cont]["items"].ToString() == xcoditem)
                    {
                        Tabladetallecolor.Rows[lc_cont].Delete();
                        Tabladetallecolor.AcceptChanges();
                        break;
                    }
                }
                for (lc_cont = 0; lc_cont <= Tabladetallecolor.Rows.Count - 1; lc_cont++)
                {
                    Tabladetallecolor.Rows[lc_cont]["items"] = VariablesPublicas.PADL(Convert.ToString(lc_cont + 1), 5, "0");
                }
                //calcular_totales();
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
                //limpiar_documento();
                if (dgv_productos.RowCount > 0)
                    dgv_productos.DataSource = Tabladetallecolor;


                cmb_bloquehoja.SelectedIndex = -1;
                txt_busqueda.Text = "";
                if (Tabladetallecolor2.Rows.Count > 0)
                    Tabladetallecolor2.Clear();

                pnl_carga.Enabled = false;
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
                        Update();
                    }
                }
            }
            if (procesado)
            {
                NIVEL_FORMS();               
                form_bloqueado(false);
                btn_nuevo.Enabled = true;
                btn_salir.Enabled = true;
                Datos(txt_articid.Text, txt_colorid.Text, xcoltalla);
                Close();              
            }
        }

        private void Insert()
        {
            try
            {
                tb_pp_recetaBL BL = new tb_pp_recetaBL();
                tb_pp_receta BE = new tb_pp_receta();

                var Item = new tb_pp_receta.Item();
                var ListaItems = new List<tb_pp_receta.Item>();

                #region Variables de RecetasCab
                BE.articid = xarticid.ToString();
                BE.version = txt_version.Text;
                BE.fechemi = Convert.ToDateTime(txt_fechemi.Text);
                BE.estado = cmb_estado.SelectedIndex.ToString();                
                BE.usuar = VariablesPublicas.Usuar.ToUpper().Trim();
                #endregion

                if (dgv_productos.Rows.Count > 0 && dgv_productos.ColumnCount > 0)
                {
                    for (int i = 0; i < dgv_productos.RowCount; i++)
                    {                       
                        Item = new tb_pp_receta.Item();
                        Item.articid = xarticid.ToString();
                        Item.version = txt_version.Text;
                        Item.colorid = txt_colorid.Text;
                        Item.coltalla = xcoltalla.ToString();                      
                        Item.bloqcostid = dgv_productos.Rows[i].Cells["bloqueid"].Value.ToString();
                        Item.productid = dgv_productos.Rows[i].Cells["productid"].Value.ToString();
                        Item.cantidad = Convert.ToInt32(dgv_productos.Rows[i].Cells["cantidad"].Value.ToString());
                        Item.estado = "0";
                        Item.usuar = VariablesPublicas.Usuar.ToUpper().Trim();
                        ListaItems.Add(Item);                        
                    }
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

        private void btn_salir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btn_seleccionar_Click(object sender, EventArgs e)
        {
            var xselec = false;
            try
            {

                Tabladetallecolor.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetallecolor));
                Tabladetallecolor.Rows[Tabladetallecolor.Rows.Count - 1]["items"] = VariablesPublicas.CalcMaxField(Tabladetallecolor, "items", 5);
                dgv_productos.CurrentCell = dgv_productos.Rows[dgv_productos.RowCount - 1].Cells["productid"];

                foreach (DataGridViewRow fila in gridgeneral.Rows)
                {
                    xselec = false;
                    foreach (DataGridViewColumn col in gridgeneral.Columns)
                    {
                        if (gridgeneral.Columns[col.Index].Name == "chk")
                        {
                            xselec = (gridgeneral.Rows[fila.Index].Cells["chk"].Value != null ? (Boolean)gridgeneral.Rows[fila.Index].Cells["chk"].Value : false);
                            break;
                        }
                    }

                    if (xselec == true)
                    {
                        row = Tabladetallecolor2.NewRow();
                        row["productid"] = gridgeneral.Rows[fila.Index].Cells["gproductid"].Value;
                        row["productname"] = gridgeneral.Rows[fila.Index].Cells["gproductname"].Value;
                        row["cantidad"] = gridgeneral.Rows[fila.Index].Cells["gcantidad"].Value;
                        row["bloqueid"] = cmb_bloquehoja.SelectedValue.ToString();
                        row["bloquename"] = cmb_bloquehoja.Text.ToString();
                        Tabladetallecolor2.Rows.Add(row);
                    }
                }
                RecibeProducto(Tabladetallecolor2);
                Tabladetallecolor2.Clear();
                gridgeneral.AutoGenerateColumns = false;
                gridgeneral.DataSource = Tabladetallecolor2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_busqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    String Query = " SELECT TOP 50 tb1.productid, tb1.productname, 1 cantidad " +
                            " FROM tb_av_productos tb1 " +
                            " WHERE tb1.[status] = '0' AND " +
                            " (ISNULL(tb1.productid,'')+ISNULL(tb1.productname,'')) LIKE '%" + txt_busqueda.Text + "%'";
                    datosgeneral(Query);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Error");
                }              
            }
        }

        private void txt_busqueda_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                String Query = " SELECT TOP 50 tb1.productid, tb1.productname, 1 cantidad " +
                        " FROM tb_av_productos tb1 " +
                        " WHERE tb1.[status] = '0' AND " +
                        " (ISNULL(tb1.productid,'')+ISNULL(tb1.productname,'')) LIKE '%" + txt_busqueda.Text + "%'";
                datosgeneral(Query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }   
        }

        private void chk_fijar_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_fijar.Checked)
            {
                cmb_bloquehoja.Enabled = false;
            }
            else
            {
                cmb_bloquehoja.Enabled = true;
            }
        }

        private void btn_editar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cmb_estado.Enabled = true;
            txt_fechemi.Enabled = true;
            pnl_carga.Enabled = true;

            
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_editar.Enabled = false;
            ssModo = "EDI";
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {

        }

        private void dgv_productos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String xcod = dgv_productos.Rows[dgv_productos.CurrentRow.Index].Cells["bloqueid"].Value.ToString();
            cmb_bloquehoja2.SelectedValue = xcod;            
        }

        private void btn_actbloq_Click(object sender, EventArgs e)
        {
            var sw_prosigue = false;
            sw_prosigue = (MessageBox.Show("¿Desea Modificar Bloque...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
            if (sw_prosigue)
            {
                dgv_productos.Rows[dgv_productos.CurrentRow.Index].Cells["bloqueid"].Value = cmb_bloquehoja2.SelectedValue.ToString();
                dgv_productos.Rows[dgv_productos.CurrentRow.Index].Cells["bloquename"].Value = cmb_bloquehoja2.Text.ToString();
            }           
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void labelControl9_Click(object sender, EventArgs e)
        {

        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
