using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.D60ALMACEN
{
    public partial class Frm_reporte_historialxproductos : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = "";
        private String local = "";   
        private String PERFILID = string.Empty;
        private DataTable TablaStock;
        private DataTable TablaHistorial;
        private DataTable TablaReporte;
        private String xxferfil = string.Empty;

        public Frm_reporte_historialxproductos()
        {
            InitializeComponent();
        }

        private void PARAMETROS_TABLA()
        {
            if (((D60ALMACEN.MainAlmacen)MdiParent).moduloid == "0500")
            {
                xxferfil = "600500000";
            }
            else
            {
                if (((D60ALMACEN.MainAlmacen)MdiParent).moduloid == "0520")
                {
                    xxferfil = "600520000";
                }
                else
                {
                    var f = (MainAlmacen)MdiParent;
                    xxferfil = f.perfil.ToString();
                }
            }
            if (xxferfil.Trim().Length != 9)
            {
                MessageBox.Show("::: NO TIENE PERFIL !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PERFILID = xxferfil;
            var XTABLA_PERFIL = string.Empty;
            XTABLA_PERFIL = VariablesPublicas.GET_PARAMETROS_TABLA(xxferfil, Name);
            if (XTABLA_PERFIL.Trim().Length > 0 && XTABLA_PERFIL.Trim() != "0")
            {
                if (XTABLA_PERFIL.Trim().Length == 2)
                {
                    dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
                }
                else
                {
                    if (XTABLA_PERFIL.Trim().Length == 6)
                    {
                        dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
                        modulo = XTABLA_PERFIL.Trim().Substring(2, 4);
                    }
                    else
                    {
                        if (XTABLA_PERFIL.Trim().Length == 9)
                        {
                            dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
                            modulo = XTABLA_PERFIL.Trim().Substring(2, 4);
                            local = XTABLA_PERFIL.Trim().Substring(6, 3);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("::: No puede accede a FORMULARIO. \n::: Es necesario DOMINIO, MODULO Y LOCAL !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_reporte_historialxestacion_Load(object sender, EventArgs e)
        {
            modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
            local = ((D60ALMACEN.MainAlmacen)MdiParent).local; 

            PARAMETROS_TABLA();

            #region *** TablaHistorial
            TablaReporte = new DataTable();
            TablaReporte.Columns.Add("productid", typeof(String));
            TablaReporte.Columns.Add("productname", typeof(String));
            TablaReporte.Columns.Add("nserie", typeof(String));
            TablaReporte.Columns.Add("fechdoc", typeof(DateTime));
            TablaReporte.Columns.Add("tipodoc", typeof(String));
            TablaReporte.Columns.Add("serdoc", typeof(String));
            TablaReporte.Columns.Add("numdoc", typeof(String));
            TablaReporte.Columns.Add("cantidad", typeof(Decimal));
            TablaReporte.Columns.Add("motivo", typeof(String));
            TablaReporte.Columns.Add("perdni", typeof(String));
            TablaReporte.Columns.Add("nombrelargo", typeof(String));
            TablaReporte.Columns.Add("cencosid", typeof(String));
            TablaReporte.Columns.Add("cencosname", typeof(String));
            TablaReporte.Columns.Add("estacion", typeof(String));
            #endregion

        }

        

        private void dgb_stock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var BL = new tb_60movimientosdetBL();
                var BE = new tb_60movimientosdet();
                if (dgb_stock.CurrentRow != null)
                {
                    var xproductid = string.Empty;
                    xproductid = dgb_stock.Rows[e.RowIndex].Cells["productid"].Value.ToString().Trim();

                    BE.moduloid = modulo;
                    BE.productid = xproductid.ToString();
                    BE.filtro = "2";

                    TablaHistorial = BL.GetAll_HistorialxProducto(EmpresaID, BE).Tables[0];
                    if (TablaHistorial.Rows.Count > 0)
                    {
                        dgb_historial.DataSource = TablaHistorial;
                    }
                    else
                    {
                        dgb_historial.DataSource = TablaHistorial;
                    }
                }
            }
            catch (Exception ex)
            {
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

                BE.dominioid = dominio.Trim();
                BE.moduloid = modulo.Trim();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();

                        var frmayuda = new Ayudas.Frm_help_general();
                        frmayuda.nameform = string.Empty;
                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA  TABLA PRODUCTOS >>";
                        frmayuda.sqlquery = "SELECT tb1.productid, tb1.productname,tb2.lineaname,tb3.gruponame FROM tb_" + modd + "_productos AS tb1 ";
                        frmayuda.sqlinner = "inner join tb_" + modd + "_linea as tb2 on tb1.lineaid = tb2.lineaid " +
                                            "inner join tb_" + modd + "_grupo as tb3 on tb1.grupoid = tb3.grupoid";
                        frmayuda.sqlwhere = "where";
                        frmayuda.sqland = string.Empty;
                        frmayuda.criteriosbusqueda = new string[] { "PRODUCTO", "CODIGO", "LINEA", "GRUPO" };
                        frmayuda.columbusqueda = "tb1.productname,tb1.productid,tb2.lineaname,tb3.gruponame";
                        frmayuda.returndatos = "0,1";

                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeProducto;
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void RecibeProducto(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            try
            {
                if (resultado1.Trim().Length == 13)
                {
                    productid.Text = resultado1;
                    productname.Text = resultado2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            var BL = new tb_60movimientosdetBL();
            var BE = new tb_60movimientosdet();

            BE.moduloid = modulo;
            BE.productid = productid.Text.ToString();
            BE.filtro = "1";

            TablaStock = BL.GetAll_HistorialxProducto(EmpresaID, BE).Tables[0];
            if (TablaStock.Rows.Count > 0)
            {
                dgb_stock.DataSource = TablaStock;
            }
            else
            {
                dgb_stock.DataSource = TablaStock;
            }

            Dgb_historial();
        }

        private void Dgb_historial()
        {
            var BL = new tb_60movimientosdetBL();
            var BE = new tb_60movimientosdet();

            BE.moduloid = modulo;
            BE.productid = productid.Text.ToString();
            BE.filtro = "2";

            TablaHistorial = BL.GetAll_HistorialxProducto(EmpresaID, BE).Tables[0];
            if (TablaHistorial.Rows.Count > 0)
            {
                dgb_historial.DataSource = TablaHistorial;
            }
            else
            {
                dgb_historial.DataSource = TablaHistorial;
            }
        }



        private void productid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaProducto(string.Empty);
                form_cargar_datos(string.Empty);
            }

            if (e.KeyCode == Keys.Enter)
            {
                form_cargar_datos(string.Empty);
                btn_busqueda.PerformClick();
            }
        }

        private void form_cargar_datos(String posicion)
        {
            try
            {
                var BL = new tb_60productosBL();
                var BE = new tb_60productos();
                var dt = new DataTable();

                BE.moduloid = modulo;
                if (productid.Text.Trim().Length > 0)
                {
                    BE.productid = productid.Text.Trim();
                }
                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    productname.Text = dt.Rows[0]["productname"].ToString().Trim();
                }
                else
                {
                    productname.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void productid_TextChanged(object sender, EventArgs e)
        {

        }


        private void btn_print_Click(object sender, EventArgs e)
        {
            tb_60movimientosdetBL BL = new tb_60movimientosdetBL();
            tb_60movimientosdet BE = new tb_60movimientosdet();

            if (productid.Text.ToString() == "")
            {
                MessageBox.Show("Falta el Codigo de Producto ...!!!");
                return;
            }           
            else
            {
                String xproductid = "", xproductname = "";
                if (TablaReporte.Rows.Count > 0) { TablaReporte.Rows.Clear(); }
                foreach (DataRow fila in TablaStock.Rows)
                {
                    xproductid = fila["productid"].ToString();
                    xproductname = fila["productname"].ToString();
                    BE.moduloid = modulo.ToString();
                    BE.productid = xproductid.ToString();
                    BE.filtro = "2";

                    TablaHistorial = BL.GetAll_KardexEstacion(EmpresaID, BE).Tables[0];
                    if (TablaHistorial.Rows.Count > 0)
                    {
                        foreach (DataRow rows in TablaHistorial.Rows)
                        {
                            ////row = TablaReporte.NewRow();
                            ////row["cencosid"] = cencosid.Text.Trim();
                            ////row["cencosname"] = cencosname.Text.Trim();
                            ////row["estacion"] = cmb_estacion.SelectedValue.ToString();
                            ////row["productid"] = xproductid.ToString();
                            ////row["productname"] = xproductname.ToString();
                            ////row["fechdoc"] = rows["fechdoc"].ToString();
                            ////row["tipodoc"] = rows["tipodoc"].ToString();
                            ////row["serdoc"] = rows["serdoc"].ToString();
                            ////row["numdoc"] = rows["numdoc"].ToString();
                            ////row["cantidad"] = rows["cantidad"].ToString();
                            ////row["motivo"] = rows["motivo"].ToString();
                            ////row["perdni"] = rows["perdni"].ToString();
                            ////row["nombrelargo"] = rows["nombrelargo"].ToString();
                            ////TablaReporte.Rows.Add(row);
                        }
                    }
                }


                if (TablaReporte.Rows.Count > 0)
                {
                    //REPORTES.Frm_reportes miForma = new REPORTES.Frm_reportes();
                    //miForma.Table = TablaReporte;
                    //miForma.Text = "Stock x Estaciones";
                    //miForma.formulario = "Frm_reporte_StockEstacion";
                    //miForma.ShowDialog();
                }
            }
        }









    }
}
