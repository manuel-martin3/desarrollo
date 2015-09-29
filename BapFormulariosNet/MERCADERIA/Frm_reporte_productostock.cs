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
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;

namespace BapFormulariosNet.MERCADERIA
{
    public partial class Frm_reporte_productostock : plantilla
    {
        private Genericas fungen = new Genericas();

        private String EmpresaID = string.Empty;
        private String dominio = string.Empty;
        private String modulo = string.Empty;
        private String local = string.Empty;
        private String perianio = string.Empty;
        private String perimes = string.Empty;

        private class Item
        {
            public string Name { get; set; }
            public int Value { get; set; }

            public Item(string name, int value)
            {
                Name = name;
                Value = value;
            }
            public override string ToString()
            {
                return Name;
            }
        }

        public Frm_reporte_productostock()
        {
            InitializeComponent();

            lineaid.LostFocus += new System.EventHandler(lineaid_LostFocus);
            grupoid.LostFocus += new System.EventHandler(grupoid_LostFocus);
            subgrupoid.LostFocus += new System.EventHandler(subgrupoid_LostFocus);
            productid.LostFocus += new System.EventHandler(productid_LostFocus);
        }

        
        
        private void Frm_reporte_VentasEmitidas_Load(object sender, EventArgs e)
        {
            EmpresaID = VariablesPublicas.EmpresaID.Trim();
            dominio = ((MERCADERIA.MainMercaderia)MdiParent).dominioid;
            modulo = ((MERCADERIA.MainMercaderia)MdiParent).moduloid;
            local = ((MERCADERIA.MainMercaderia)MdiParent).local;

            fill_cbolocal(dominio, modulo);

            cboLocal.SelectedValue = local;
            dtiFechFin.Text = DateTime.Today.ToShortDateString();
        }
                
        private void fill_cbolocal(string dominioid, string moduloid)
        {
            var BL = new usuariomodulolocalBL();
            var BE = new tb_usuariomodulolocal();
            BE.usuar = VariablesPublicas.Usuar.Trim();
            var dt = new DataTable();
            BE.dominioid = dominioid;
            BE.moduloid = moduloid;

            try
            {
                dt = BL.GetAll3(VariablesPublicas.EmpresaID, BE).Tables[0];
                cboLocal.DataSource = dt;
                cboLocal.ValueMember = "local";
                cboLocal.DisplayMember = "localname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkTodosLocales_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodosLocales.Checked)
                cboLocal.Enabled = false;
            else
                cboLocal.Enabled = true;
        }
       
        private void solo_numero_enteros(object control, KeyPressEventArgs e)
        {
            if (((e.KeyChar) >= '0' && e.KeyChar <= '9') && !(e.KeyChar == '.'))
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
                    if ((e.KeyChar) == (char)Keys.Tab)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        #region --- LINEA ---
        private void lineaid_LostFocus(object sender, System.EventArgs e)
        {
            ValidaLinea();
         }

        private void ValidaLinea()
        {
            if (lineaid.Text.Trim().Length > 0)
            {
                var BL = new tb_me_lineaBL();
                var BE = new tb_me_linea();
                var dt = new DataTable();

                BE.moduloid = modulo;
                BE.lineaid = lineaid.Text.Trim().PadLeft(3, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    lineaid.Text = dt.Rows[0]["lineaid"].ToString().Trim();
                    lineaname.Text = dt.Rows[0]["lineaname"].ToString().Trim();
                }
                else
                {
                    lineaid.Text = string.Empty;
                    lineaname.Text = string.Empty;
                }
            }
            else
            {
                lineaid.Text = string.Empty;
                lineaname.Text = string.Empty;
            }
        }

        private void lineaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaLinea(string.Empty);
                grupoid.Focus();
            }

            if (e.KeyCode == Keys.Enter)
            {
                ValidaLinea();
            }
        }

        private void AyudaLinea(String lpdescrlike)
        {
            try
            {
                var modd = string.Empty;
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();

                BE.dominioid = dominio;
                BE.moduloid = modulo;
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();

                        var frmayuda = new Ayudas.Frm_help_general();

                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA  TABLA LINEA >>";
                        frmayuda.sqlquery = "SELECT lineaid, lineaname FROM tb_me_linea ";
                        frmayuda.sqlinner = string.Empty;
                        frmayuda.sqlwhere = "where moduloid='" + modulo + "'";
                        frmayuda.sqland = "and";
                        frmayuda.criteriosbusqueda = new string[] { "LINEA", "CODIGO" };
                        frmayuda.columbusqueda = "lineaname,lineaid";
                        frmayuda.returndatos = "0,1";

                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeLinea;
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void RecibeLinea(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                lineaid.Text = resultado1.Trim();
                lineaname.Text = resultado2.Trim();
                grupoid.Focus();
            }
        }
        #endregion

        #region --- GRUPO ---
        private void grupoid_LostFocus(object sender, System.EventArgs e)
        {
            ValidaGrupo();
        }

        private void ValidaGrupo()
        {
            if (grupoid.Text.Trim().Length > 0)
            {
                var BL = new tb_me_grupoBL();
                var BE = new tb_me_grupo();
                var dt = new DataTable();

                BE.moduloid = modulo;
                BE.grupoid = grupoid.Text.Trim().PadLeft(4, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    grupoid.Text = dt.Rows[0]["grupoid"].ToString().Trim();
                    gruponame.Text = dt.Rows[0]["gruponame"].ToString().Trim();
                }
                else
                {
                    grupoid.Text = string.Empty;
                    gruponame.Text = string.Empty;
                }
            }
            else
            {
                grupoid.Text = string.Empty;
                gruponame.Text = string.Empty;
            }
        }

        private void grupoid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaGrupo(string.Empty);
                subgrupoid.Focus();
            }

            if (e.KeyCode == Keys.Enter)
            {
                ValidaGrupo();
            }
        }

        private void AyudaGrupo(String lpdescrlike)
        {
            try
            {
                var modd = string.Empty;
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();

                BE.dominioid = dominio;
                BE.moduloid = modulo;
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();

                        var frmayuda = new Ayudas.Frm_help_general();

                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA TABLA GRUPOS >>";
                        frmayuda.sqlquery = "SELECT grupoid, gruponame FROM tb_me_grupo ";
                        frmayuda.sqlinner = string.Empty;
                        frmayuda.sqlwhere = "where moduloid='" + modulo + "'";
                        frmayuda.sqland = "and";
                        frmayuda.criteriosbusqueda = new string[] { "GRUPO", "CODIGO" };
                        frmayuda.columbusqueda = "gruponame,grupoid";
                        frmayuda.returndatos = "0,1";

                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeGrupo;
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void RecibeGrupo(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                grupoid.Text = resultado1.Trim();
                gruponame.Text = resultado2.Trim();
                subgrupoid.Focus();
            }
        }
        #endregion

        #region --- SUBGRUPO ---
        private void subgrupoid_LostFocus(object sender, System.EventArgs e)
        {
            ValidaSubgrupo();
        }
        private void ValidaSubgrupo()
        {
            if (subgrupoid.Text.Trim().Length > 0 && lineaid.Text.Trim().Length == 3 && grupoid.Text.Trim().Length == 4)
            {
                var BL = new tb_me_subgrupoBL();
                var BE = new tb_me_subgrupo();
                var dt = new DataTable();

                BE.moduloid = modulo;
                BE.lineaid = lineaid.Text.Trim().PadLeft(3, '0');
                BE.grupoid = grupoid.Text.Trim().PadLeft(4, '0');
                BE.subgrupoid = subgrupoid.Text.Trim().PadLeft(3, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    lineaid.Text = dt.Rows[0]["lineaid"].ToString().Trim();
                    lineaname.Text = dt.Rows[0]["lineaname"].ToString().Trim();
                    grupoid.Text = dt.Rows[0]["grupoid"].ToString().Trim();
                    gruponame.Text = dt.Rows[0]["gruponame"].ToString().Trim();
                    subgrupoid.Text = dt.Rows[0]["subgrupoid"].ToString().Trim();
                    subgruponame.Text = dt.Rows[0]["subgruponame"].ToString().Trim();
                }
                else
                {
                    subgrupoid.Text = string.Empty;
                    subgruponame.Text = string.Empty;
                }
            }
            else
            {
                subgrupoid.Text = string.Empty;
                subgruponame.Text = string.Empty;
            }
        }
        
        private void subgrupoid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Ayudasubgrupo(string.Empty);
                productid.Focus();
            }

            if (e.KeyCode == Keys.Enter)
            {
                ValidaSubgrupo();
            }
        }

        private void Ayudasubgrupo(String lpdescrlike)
        {
            try
            {
                var modd = string.Empty;
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();

                BE.dominioid = dominio;
                BE.moduloid = modulo;
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();

                        var frmayuda = new Ayudas.Frm_help_general();

                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA TABLA ARTICULO >>";
                        frmayuda.sqlquery = "SELECT subgrupoid, subgruponame, lineaid, grupoid FROM tb_me_subgrupo ";
                        frmayuda.sqlinner = string.Empty;
                        if (lineaid.Text.Trim().Length > 0 && grupoid.Text.Trim().Length > 0)
                        {
                            frmayuda.sqlwhere = "where moduloid =" + modulo + " and lineaid=" + lineaid.Text + " and grupoid = " + grupoid.Text + " ";
                            frmayuda.sqland = "and";
                        }
                        else
                        {
                            if (lineaid.Text.Trim().Length > 0)
                            {
                                frmayuda.sqlwhere = "where moduloid =" + modulo + " and lineaid = " + lineaid.Text + " ";
                                frmayuda.sqland = "and";
                            }
                            else
                            {
                                if (grupoid.Text.Trim().Length > 0)
                                {
                                    frmayuda.sqlwhere = "where moduloid =" + modulo + " and grupoid = " + grupoid.Text + " ";
                                    frmayuda.sqland = "and";
                                }
                                else
                                {
                                    frmayuda.sqlwhere = "where moduloid ='" + modulo + "'";
                                    frmayuda.sqland = "and";
                                }
                            }
                        }
                        frmayuda.criteriosbusqueda = new string[] { "ARTICULO", "CODIGO" };
                        frmayuda.columbusqueda = "subgruponame,subgrupoid";
                        frmayuda.returndatos = "0,2,3";

                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeSubgrupo;
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void RecibeSubgrupo(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                lineaid.Text = resultado2.Trim();
                grupoid.Text = resultado3.Trim();
                subgrupoid.Text = resultado1.Trim();
                productid.Focus();
            }
        }
        #endregion

        #region --- PRODUCTO ---
        private void productid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaProducto(string.Empty);
                //colorid.Focus();
            }

            if (e.KeyCode == Keys.Enter)
            {
                ValidaProducto();
            }
        }

        private void productid_LostFocus(object sender, System.EventArgs e)
        {
            ValidaProducto();
        }

        private void ValidaProducto()
        {
            if (productid.Text.Trim().Length == 13)
            {
                var BL = new tb_me_productosBL();
                var BE = new tb_me_productos();
                var dt = new DataTable();

                BE.moduloid = modulo;
                BE.productid = productid.Text.Trim();

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    lineaid.Text = dt.Rows[0]["lineaid"].ToString().Trim();
                    lineaname.Text = dt.Rows[0]["lineaname"].ToString().Trim();
                    grupoid.Text = dt.Rows[0]["grupoid"].ToString().Trim();
                    gruponame.Text = dt.Rows[0]["gruponame"].ToString().Trim();
                    subgrupoid.Text = dt.Rows[0]["subgrupoid"].ToString().Trim();
                    subgruponame.Text = dt.Rows[0]["subgruponame"].ToString().Trim();
                    productid.Text = dt.Rows[0]["productid"].ToString().Trim();
                    productname.Text = dt.Rows[0]["productname"].ToString().Trim();
                    //productidold.Text = dt.Rows[0]["productidold"].ToString().Trim();
                }
                else
                {
                    productid.Text = string.Empty;
                    productname.Text = string.Empty;
                }
            }
            else
            {
                productid.Text = string.Empty;
                productname.Text = string.Empty;
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
                BE.moduloid = modulo;
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();

                        var frmayuda = new Ayudas.Frm_help_general();

                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA  TABLA PRODUCTOS >>";
                        frmayuda.sqlquery = "SELECT TOP 100 tb1.productid,tb1.productidold, tb1.productname, tb2.stock,tb2.costoultimo FROM tb_me_productos AS tb1 ";
                        frmayuda.sqlinner = "inner join tb_me_local_stock as tb2 on tb1.productid = tb2.productid ";

                        frmayuda.sqlwhere = "where tb1.moduloid ='" + modulo + "' AND local = '" + local + "' AND tb2.stock > 0 ";
                        frmayuda.sqland = "AND";

                        frmayuda.criteriosbusqueda = new string[] { "PRODUCTO", "CODIGO", "CODIGO_ANT" };
                        frmayuda.columbusqueda = "tb1.productname,tb1.productid,tb1.productidold";
                        frmayuda.returndatos = "0,2";

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
            if (resultado1.Trim().Length > 0 && resultado2.Trim().Length > 0)
            {
                productid.Text = resultado1.Trim();
                //colorid.Focus();
            }
        }
        #endregion

        #region --- IMPRIMIR ---
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var miForma = new REPORTES.Frm_reportes();
                miForma.Text = "STOCK POR ARTICULO";
                miForma.dominioid = dominio.Trim();
                miForma.moduloid = modulo.Trim();
                miForma.local = chkTodosLocales.Checked ? "" : local.Trim();
                miForma.localname = chkTodosLocales.Checked ? "" : cboLocal.Text.Trim();

                miForma.lineaid = lineaid.Text.Trim();
                miForma.grupoid = grupoid.Text.Trim();
                miForma.subgrupoid = subgrupoid.Text.Trim();
                miForma.productid = productid.Text.Trim();
                //miForma.productidold = productidold.Text.Trim();
                //miForma.colorid = colorid.Text.Trim();
                miForma.status = chkTodosStock.Checked ? "1" : "0";
                miForma.formulario = "Frm_reporte_productostock";
                miForma.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
        private void btiStockProducto_Click(object sender, EventArgs e)
        {
            try
            {
                var miForma = new REPORTES.Frm_reportes();
                miForma.Text = "STOCK POR ARTICULO";
                miForma.dominioid = dominio.Trim();
                miForma.moduloid = modulo.Trim();
                miForma.local = chkTodosLocales.Checked ? "" : local.Trim();
                miForma.localname = chkTodosLocales.Checked ? "" : cboLocal.Text.Trim();

                miForma.lineaid = lineaid.Text.Trim();
                miForma.grupoid = grupoid.Text.Trim();
                miForma.subgrupoid = subgrupoid.Text.Trim();
                miForma.productid = productid.Text.Trim();
                //miForma.productidold = productidold.Text.Trim();
                //miForma.colorid = colorid.Text.Trim();
                miForma.status = chkTodosStock.Checked ? "1" : "0";
                miForma.formulario = "Frm_reporte_productostock";
                miForma.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btiStockProductoLocal_Click(object sender, EventArgs e)
        {
            try
            {
                var miForma = new REPORTES.Frm_reportes();
                miForma.Text = "STOCK POR ARTICULO";
                miForma.dominioid = dominio.Trim();
                miForma.moduloid = modulo.Trim();
                miForma.local = chkTodosLocales.Checked ? "" : local.Trim();
                miForma.localname = chkTodosLocales.Checked ? "" : cboLocal.Text.Trim();

                miForma.lineaid = lineaid.Text.Trim();
                miForma.grupoid = grupoid.Text.Trim();
                miForma.subgrupoid = subgrupoid.Text.Trim();
                miForma.productid = productid.Text.Trim();
                //miForma.productidold = productidold.Text.Trim();
                //miForma.colorid = colorid.Text.Trim();
                miForma.status = chkTodosStock.Checked ? "1" : "0";
                miForma.formulario = "Frm_reporte_productostockxlocal";
                miForma.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

    }
}
