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
    public partial class Frm_recetas : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable TablaColorTall;

        private String xarticid = "";
        private DataRow row;
        private Boolean procesado = false;
        private String ActCtacte = "";

        private String ssModo = "";

        public Frm_recetas()
        {
            InitializeComponent();
        }

        private void Frm_orden_produccion_Load(object sender, EventArgs e)
        {
            if (Parent.Parent.Name == "MainProduccion")
            {
                modulo = ((D70Produccion.MainProduccion)MdiParent).moduloid;
                local = ((D70Produccion.MainProduccion)MdiParent).local;
                PERFILID = ((D70Produccion.MainProduccion)MdiParent).perfil;
            }

            if (Parent.Parent.Name == "MainTienda")
            {
                modulo = ((D60Tienda.MainTienda)MdiParent).moduloid;
                local = ((D60Tienda.MainTienda)MdiParent).local;
                PERFILID = ((D60Tienda.MainTienda)MdiParent).perfil;
            }

            NIVEL_FORMS();

            ArmandoTabla();
            form_bloqueado(false);
            limpiar_documento();
            btn_nuevo.Enabled = true;
            btn_salir.Enabled = true;
                                   
        }

        private void NIVEL_FORMS()
        {
            XNIVEL = VariablesPublicas.Get_nivelperfil(PERFILID, Name).Substring(0, 1);
            if (XNIVEL != "0")
            {
                //btn_clave.Glyph = global::BapFormulariosNet.Properties.Resources.btn_Lock20;
            }
            else
            {
                //btn_clave.Glyph = global::BapFormulariosNet.Properties.Resources.btn_Un_Lock20;
            }
        }

       

        private void form_bloqueado(Boolean var)
        {
            try
            {
                txt_articidold.Enabled = var;

                txt_fechemi.Enabled = var;
                dgv_color.Enabled = var;
                btn_nuevo.Enabled = false;              
                btn_cancelar.Enabled = false;              
                btn_imprimir.Enabled = false;              
                btn_salir.Enabled = false;            
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
                txt_fechemi.Text = DateTime.Today.ToShortDateString();
                xarticid = "";
                txt_articidold.Text = "";
                txt_articname.Text = "";
                txt_version.Text = "";

                txt_articidoldbus.Text = "";
                txt_articnamebus.Text = "";
                txt_versionbus.Text = "";

                if (dgv_color.RowCount > 0)
                    dgv_color.DataSource = TablaColorTall;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ArmandoTabla()
        {
            TablaColorTall = new DataTable();
            TablaColorTall.Columns.Add("colorid", typeof(String));
            TablaColorTall.Columns.Add("colorname", typeof(String));
            TablaColorTall.Columns.Add("talla01", typeof(String));
            TablaColorTall.Columns.Add("talla02", typeof(String));
            TablaColorTall.Columns.Add("talla03", typeof(String));
            TablaColorTall.Columns.Add("talla04", typeof(String));
            TablaColorTall.Columns.Add("talla05", typeof(String));
            TablaColorTall.Columns.Add("talla06", typeof(String));
            TablaColorTall.Columns.Add("talla07", typeof(String));
            TablaColorTall.Columns.Add("talla08", typeof(String));
            TablaColorTall.Columns.Add("talla09", typeof(String));
            TablaColorTall.Columns.Add("talla10", typeof(String));
            TablaColorTall.Columns.Add("talla11", typeof(String));
            TablaColorTall.Columns.Add("talla12", typeof(String));
        }

        private void AyudaArticulo()
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all";
                frmayuda.titulo = "<< AYUDA TABLA ARTICULO >>";
                frmayuda.sqlquery = "SELECT articid,articidold,articname FROM tb_pt_articulo ";
                frmayuda.sqlinner = "";
                frmayuda.sqlwhere = "where ";
                frmayuda.sqland = "";
                frmayuda.criteriosbusqueda = new string[] { "CODIGO", "ARTICULO" };
                frmayuda.columbusqueda = "articidold,articname";
                frmayuda.returndatos = "0,1,2";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeArticulo;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RecibeArticulo(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                xarticid = resultado1.Trim();
                txt_articidold.Text = resultado2.Trim();
                txt_articname.Text = resultado3.Trim();

                           
                ValidaArticulo();
                //PintarCeldas();
            }
        }

        void ValidaArticulo()
        {
            tb_pt_articuloBL BL = new tb_pt_articuloBL();
            tb_pt_articulo BE = new tb_pt_articulo();
            tb_pt_articulo BE2 = new tb_pt_articulo();
            DataTable dt = new DataTable();
            BE.articidold = txt_articidold.Text;
            dt = BL.GetAll(EmpresaID,BE).Tables[0];

            if (dt.Rows.Count > 0)
            {
                txt_articidold.Text = dt.Rows[0]["articidold"].ToString();
                txt_articname.Text = dt.Rows[0]["articname"].ToString();
                BE2.articid = dt.Rows[0]["articid"].ToString();
                xarticid = dt.Rows[0]["articid"].ToString();
                // Aca Generamos el Nuevo Correlativo
                GeneraVersion(dt.Rows[0]["articid"].ToString());
                BE2.top = true;

                if (txt_articidold.Text.ToString().Length == 7 || txt_articidoldbus.Text.ToString().Length == 7)
                {
                    dt = BL.GetAll_Color(EmpresaID, BE2).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        dgv_color.Columns[2].HeaderText = dt.Rows[0]["talla01"].ToString();
                        dgv_color.Columns[3].HeaderText = dt.Rows[0]["talla02"].ToString();
                        dgv_color.Columns[4].HeaderText = dt.Rows[0]["talla03"].ToString();
                        dgv_color.Columns[5].HeaderText = dt.Rows[0]["talla04"].ToString();
                        dgv_color.Columns[6].HeaderText = dt.Rows[0]["talla05"].ToString();
                        dgv_color.Columns[7].HeaderText = dt.Rows[0]["talla06"].ToString();
                        dgv_color.Columns[8].HeaderText = dt.Rows[0]["talla07"].ToString();
                        dgv_color.Columns[9].HeaderText = dt.Rows[0]["talla08"].ToString();
                        dgv_color.Columns[10].HeaderText = dt.Rows[0]["talla09"].ToString();
                        dgv_color.Columns[11].HeaderText = dt.Rows[0]["talla10"].ToString();
                        dgv_color.Columns[12].HeaderText = dt.Rows[0]["talla11"].ToString();
                        dgv_color.Columns[13].HeaderText = dt.Rows[0]["talla12"].ToString();
                        dgv_color.AutoGenerateColumns = false;
                        dgv_color.DataSource = dt;
                        dgv_color.Enabled = true;
                    }
                }
            }
        }


        void ValidaArticulo2()
        {                 
            if (txt_articidoldbus.Text.ToString().Length == 7)
            {
                DataTable Data = new DataTable();
                String Query = " SELECT DISTINCT a.articid,articidold,articname,max(rd.[version])'version' " +
                               " FROM tb_pt_articulo a " +
                               " INNER JOIN tb_pp_recetadet rd ON a.articid = rd.articid " +
                               " WHERE articidold = '" + txt_articidoldbus.Text + "' GROUP BY a.articid,articidold,articname ";
                Data = DatosSQL(Query);

                if (Data.Rows.Count > 0)
                {
                    xarticid = Data.Rows[0]["articid"].ToString();
                    txt_articidoldbus.Text = Data.Rows[0]["articidold"].ToString();
                    txt_articnamebus.Text = Data.Rows[0]["articname"].ToString();
                    txt_versionbus.Text = Data.Rows[0]["version"].ToString();

                    tb_pt_articuloBL BL = new tb_pt_articuloBL();
                    tb_pt_articulo BE = new tb_pt_articulo();
                    DataTable dt = new DataTable();
                    BE.articid = Data.Rows[0]["articid"].ToString();
                    BE.top = true;
                    dt = BL.GetAll_Color(EmpresaID, BE).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        dgv_color.Columns[2].HeaderText = dt.Rows[0]["talla01"].ToString();
                        dgv_color.Columns[3].HeaderText = dt.Rows[0]["talla02"].ToString();
                        dgv_color.Columns[4].HeaderText = dt.Rows[0]["talla03"].ToString();
                        dgv_color.Columns[5].HeaderText = dt.Rows[0]["talla04"].ToString();
                        dgv_color.Columns[6].HeaderText = dt.Rows[0]["talla05"].ToString();
                        dgv_color.Columns[7].HeaderText = dt.Rows[0]["talla06"].ToString();
                        dgv_color.Columns[8].HeaderText = dt.Rows[0]["talla07"].ToString();
                        dgv_color.Columns[9].HeaderText = dt.Rows[0]["talla08"].ToString();
                        dgv_color.Columns[10].HeaderText = dt.Rows[0]["talla09"].ToString();
                        dgv_color.Columns[11].HeaderText = dt.Rows[0]["talla10"].ToString();
                        dgv_color.Columns[12].HeaderText = dt.Rows[0]["talla11"].ToString();
                        dgv_color.Columns[13].HeaderText = dt.Rows[0]["talla12"].ToString();
                        dgv_color.AutoGenerateColumns = false;
                        dgv_color.DataSource = dt;
                        dgv_color.Enabled = true;
                    }

                    PintarCeldas();
                }
                else
                {
                    MessageBox.Show("El Articulo No tiene Recetas...!!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        void PintarCeldas()
        {           
            DataTable dt = new DataTable();
            String Query= " SELECT DISTINCT colorid,coltalla  "+
                          " FROM tb_pp_recetadet where articid = '" + xarticid.ToString() +"' AND [version] = '" + txt_versionbus.Text +"'";
            dt = DatosSQL(Query);                  
            String xcolorid_bd = "", xcoltalla_bd = "";
            foreach (DataRow fila in dt.Rows)
            {
                xcolorid_bd = fila["colorid"].ToString();
                xcoltalla_bd = fila["coltalla"].ToString();

                if (dgv_color.Columns.Count > 0 && dgv_color.Rows.Count > 0)
                {
                    // PINTAMOS LAS CELDAS DE LAS RECETAS YA GENERADAS                  
                    for (int i = 0; i < dgv_color.RowCount; i++)
                    {
                        for (int j = 2; j < dgv_color.ColumnCount - 1; j++)
                        {
                            // Identificamos Primero la Fila
                            if (dgv_color.Rows[i].Cells["colorid"].Value.ToString().Trim() == xcolorid_bd.ToString().Trim())
                            {
                                String x = Equivalencias.Right(dgv_color.Columns[j].Name.ToString(), 2);
                                if (x.Equals(xcoltalla_bd))
                                {
                                    dgv_color.Rows[i].Cells[j].Style.BackColor = Color.Blue;
                                }
                            }
                        }
                    }
                }
            }
        }



        private void btn_nuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XNIVEL == "0")
            {
                nuevo();
                
                if (TablaColorTall != null)
                {
                    TablaColorTall.Rows.Clear();                   
                }
            }
        }

        private void nuevo()
        {
            limpiar_documento();
            txt_articidold.Enabled = true;
            btn_nuevo.Enabled = false;           
            btn_cancelar.Enabled = true;
            pnl_busqueda.Enabled = false;
            ssModo = "NEW";
        }

        void GeneraVersion(String xarticid)
        {
            tb_pp_receta BE = new tb_pp_receta();
            tb_pp_recetaBL BL = new tb_pp_recetaBL();
            DataTable dt = new DataTable();
            BE.articid = xarticid;
            dt = BL.GetAll_Version(EmpresaID,BE).Tables[0];
            if (dt.Rows.Count > 0)
                txt_version.Text = dt.Rows[0]["version"].ToString();
            else
                txt_version.Text = "";
        }



        private void txt_articidold_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaArticulo();
            }

            if (e.KeyCode == Keys.Enter)
            {
                ValidaArticulo();
            }


        }      

        private void dgv_color_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btn_nuevo.Enabled == false)
            {
                String xcolorid, xcolorname, xtallaname, xcoltall;
                xcolorid = (dgv_color.Rows[e.RowIndex].Cells[0].Value.ToString());
                xcolorname = (dgv_color.Rows[e.RowIndex].Cells[1].Value.ToString());

                xcoltall = dgv_color.Columns[e.ColumnIndex - 1].Index.ToString().PadLeft(2, '0');
                xtallaname = dgv_color.Columns[e.ColumnIndex].HeaderText;

                Popup.Frm_Recetabloque frm = new Popup.Frm_Recetabloque();
                frm.articid = xarticid;
                frm.articname = txt_articname.Text;
                frm.colorid = xcolorid;
                frm.colorname = xcolorname;
                frm.coltall = xcoltall;
                frm.tallaname = xtallaname;
                frm.version = txt_version.Text;
                frm.Datos = RecibeDatos;
                frm.ShowDialog();
            }
            else
            {
                String xcolorid, xcolorname, xtallaname, xcoltall;
                xcolorid = (dgv_color.Rows[e.RowIndex].Cells[0].Value.ToString());
                xcolorname = (dgv_color.Rows[e.RowIndex].Cells[1].Value.ToString());

                xcoltall = dgv_color.Columns[e.ColumnIndex - 1].Index.ToString().PadLeft(2, '0');
                xtallaname = dgv_color.Columns[e.ColumnIndex].HeaderText;

                Popup.Frm_Recetabloque frm = new Popup.Frm_Recetabloque();
                frm.articid = xarticid;
                frm.articname = txt_articnamebus.Text;
                frm.colorid = xcolorid;
                frm.colorname = xcolorname;
                frm.coltall = xcoltall;
                frm.tallaname = xtallaname;
                frm.version = txt_versionbus.Text;
                frm.Datos = RecibeDatos;
                frm.ShowDialog();
            }
        }

        private void RecibeDatos(String xarticid, String xcolorid, String xcoltall)
        {
            if (xarticid.Trim().Length > 0)
            {
                for (int i = 0; i < dgv_color.RowCount; i++)
                {
                    for (int j = 0; j < dgv_color.ColumnCount; j++)
                    {
                        // Identificamos Primero la Fila
                        if (dgv_color.Rows[i].Cells["colorid"].Value.ToString() == xcolorid.ToString())
                        {
                            String x =  Equivalencias.Right(dgv_color.Columns[j].Name.ToString(),2);
                            if (x.Equals(xcoltall))
                            {
                                dgv_color.Rows[i].Cells[j].Style.BackColor = Color.Blue;
                            }
                        }
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
                form_bloqueado(false);
                btn_nuevo.Enabled = true;
                pnl_busqueda.Enabled = true;
                ssModo = "NEW";
            }
        }

        private void btn_salir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void txt_articidbus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaArticulo2();
            }

            if (e.KeyCode == Keys.Enter)
            {
                ValidaArticulo2();
            }

        }

        private void AyudaArticulo2()
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all";
                frmayuda.titulo = "<< AYUDA TABLA ARTICULO >>";
                frmayuda.sqlquery = " SELECT DISTINCT a.articid,articidold,articname,max(rd.[version])'version' " +
                                    " FROM tb_pt_articulo a ";
                frmayuda.sqlinner = " INNER JOIN tb_pp_recetadet rd ON a.articid = rd.articid ";
                frmayuda.sqlwhere = " where ";
                frmayuda.sqland = "";
                frmayuda.sqlgroupby = " GROUP BY a.articid,articidold,articname ";
                frmayuda.criteriosbusqueda = new string[] { "CODIGO", "ARTICULO" };
                frmayuda.columbusqueda = "articidold,articname";
                frmayuda.returndatos = "0,1,2,3";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeArticulo2;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RecibeArticulo2(String xxarticid, String xarticidold, String xarticname, String xversion, String resultado5)
        {
            if (xxarticid.Trim().Length > 0)
            {
                xarticid = xxarticid.Trim();
                txt_articidoldbus.Text = xarticidold.Trim();
                txt_articnamebus.Text = xarticname.Trim();
                txt_versionbus.Text = xversion;

                // Aca Generamos el Nuevo Correlativo
                //GeneraVersion(xarticid);
                ValidaArticulo2();
                PintarCeldas();
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
                        //MessageBox.Show(ex.Message, "Error");
                    }
                }
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            PintarCeldas();
        }



        

    }
}
