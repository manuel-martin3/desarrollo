using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

using System.Windows.Forms;


namespace BapFormulariosNet.D60ALMACEN
{
    public partial class Frm_reporte_mov_balancestock : plantilla
    {
        private Genericas fungen = new Genericas();

        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
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

        public Frm_reporte_mov_balancestock()
        {
            InitializeComponent();
            lineaid.LostFocus += new System.EventHandler(lineaid_LostFocus);
            grupoid.LostFocus += new System.EventHandler(grupoid_LostFocus);
            subgrupoid.LostFocus += new System.EventHandler(subgrupoid_LostFocus);
            productid.LostFocus += new System.EventHandler(productid_LostFocus);
        }                  
      
        private void Frm_reporte_stockrollo_Load(object sender, EventArgs e)
        {
            dominio = ((D60ALMACEN.MainAlmacen)MdiParent).dominioid;
            modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
            local = ((D60ALMACEN.MainAlmacen)MdiParent).local;
            perianio = ((D60ALMACEN.MainAlmacen)MdiParent).perianio;

            fill_cboModuloid();
            fill_cboPerianio();
            fill_cboPerimesini();
            fill_cboPerimesfin();

            cboLocal.SelectedValue = local;
        }

        private void fill_cboModuloid()
        {
            var BL = new sys_dominioBL();
            try
            {
                cboModuloid.DataSource = BL.GetAllDominioModuloPorUsuario(VariablesPublicas.EmpresaID, VariablesPublicas.Usuar, "60").Tables[0];
                cboModuloid.ValueMember = "moduloid";
                cboModuloid.DisplayMember = "moduloname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cboModuloid.SelectedValue = modulo;

            if (cboModuloid.Items.Count > 0)
            {
                fill_cbolocal(dominio, cboModuloid.SelectedValue.ToString());
            }
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
        private void fill_cboPerianio()
        {
            int nMinAnio = DateTime.Today.Year - 10;
            int nMaxAnio = DateTime.Today.Year;
            string cAnio = string.Empty;

            List<Item> lista = new List<Item>();
            for (int i = nMinAnio; i <= nMaxAnio; i++)
            {
                cAnio = Convert.ToString(i);
                lista.Add(new Item(cAnio, i));
            }

            cboPerianio.DataSource = lista;
            cboPerianio.DisplayMember = "Name";
            cboPerianio.ValueMember = "Value";

            cboPerianio.SelectedValue = DateTime.Today.Year;
        }
        private void fill_cboPerimesini()
        {
            int nMinMes = 1;
            int nMaxMes = 12;
            string cMes = string.Empty;

            List<Item> lista = new List<Item>();
            for (int i = nMinMes; i <= nMaxMes; i++)
            {
                cMes = Convert.ToString(i);
                lista.Add(new Item(cMes.Trim().PadLeft(2, '0') + "-" + fungen.get_mesCad(cMes.Trim().PadLeft(2, '0')), i));
            }

            cboPerimesini.DataSource = lista;
            cboPerimesini.DisplayMember = "Name";
            cboPerimesini.ValueMember = "Value";

            cboPerimesini.SelectedValue = DateTime.Today.Month;
        }
        private void fill_cboPerimesfin()
        {
            int nMinMes = 1;
            int nMaxMes = 12;
            string cMes = string.Empty;

            List<Item> lista = new List<Item>();
            for (int i = nMinMes; i <= nMaxMes; i++)
            {
                cMes = Convert.ToString(i);
                lista.Add(new Item(cMes.Trim().PadLeft(2, '0') + "-" + fungen.get_mesCad(cMes.Trim().PadLeft(2, '0')), i));
            }

            cboPerimesfin.DataSource = lista;
            cboPerimesfin.DisplayMember = "Name";
            cboPerimesfin.ValueMember = "Value";

            cboPerimesfin.SelectedValue = DateTime.Today.Month;
        }

        private void ValidaLinea()
        {
            if (lineaid.Text.Trim().Length > 0)
            {
                var BL = new tb_60lineaBL();
                var BE = new tb_60linea();
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
        private void ValidaGrupo()
        {
            if (grupoid.Text.Trim().Length > 0)
            {
                var BL = new tb_60grupoBL();
                var BE = new tb_60grupo();
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
        private void ValidaSubgrupo()
        {
            if (subgrupoid.Text.Trim().Length > 0 && lineaid.Text.Trim().Length == 3 && grupoid.Text.Trim().Length == 4)
            {
                var BL = new tb_60subgrupoBL();
                var BE = new tb_60subgrupo();
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
        private void ValidaProducto()
        {
            if (productid.Text.Trim().Length == 13)
            {
                var BL = new tb_60productosBL();
                var BE = new tb_60productos();
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
                }
                else
                {
                    productid.Text = string.Empty;
                }
            }
            else
            {
                productid.Text = string.Empty;
            }
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
        private void solo_numero_decimal(object control, KeyPressEventArgs e)
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
                        if (e.KeyChar == '.')
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
        }
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (GetNextControl(ActiveControl, true) != null)
                {
                    SendKeys.Send("\t");
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        public bool IsNumeric(String Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
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
                        frmayuda.sqlquery = "SELECT lineaid, lineaname FROM tb_" + modd + "_linea ";
                        frmayuda.sqlinner = string.Empty;
                        frmayuda.sqlwhere = "where";
                        frmayuda.sqland = string.Empty;
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
                        frmayuda.sqlquery = "SELECT grupoid, gruponame FROM tb_" + modd + "_grupo ";
                        frmayuda.sqlinner = string.Empty;
                        frmayuda.sqlwhere = "where";
                        frmayuda.sqland = string.Empty;
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
                        frmayuda.sqlquery = "SELECT subgrupoid, subgruponame, lineaid, grupoid FROM tb_" + modd + "_subgrupo ";
                        frmayuda.sqlinner = string.Empty;
                        if (lineaid.Text.Trim().Length > 0 && grupoid.Text.Trim().Length > 0)
                        {
                            frmayuda.sqlwhere = "where lineaid = " + lineaid.Text + " and grupoid = " + grupoid.Text + " ";
                            frmayuda.sqland = "and";
                        }
                        else
                        {
                            if (lineaid.Text.Trim().Length > 0)
                            {
                                frmayuda.sqlwhere = "where lineaid = " + lineaid.Text + " ";
                                frmayuda.sqland = "and";
                            }
                            else
                            {
                                if (grupoid.Text.Trim().Length > 0)
                                {
                                    frmayuda.sqlwhere = "where grupoid = " + grupoid.Text + " ";
                                    frmayuda.sqland = "and";
                                }
                                else
                                {
                                    frmayuda.sqlwhere = "where";
                                    frmayuda.sqland = string.Empty;
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

                        frmayuda.nameform = string.Empty;
                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA  TABLA PRODUCTOS >>";
                        frmayuda.sqlquery = " SELECT tb1.productid, tb1.productname," +
                                            " SUM(IIF(mdet.almacaccionid = '10',mdet.cantidad * 1,mdet.cantidad *-1)) AS stock, " +
                                            " tb2.costoultimo FROM tb_" + modd + "_productos AS tb1 ";
                        frmayuda.sqlinner = " INNER JOIN tb_" + modd + "_local_stock as tb2 on tb1.productid = tb2.productid " +
                                            " LEFT JOIN tb_" + modd + "_movimientosdet mdet ON tb1.productid = mdet.productid ";

                        if (lineaid.Text.Trim().Length > 0 && grupoid.Text.Trim().Length > 0 && subgrupoid.Text.Trim().Length > 0)
                        {
                            frmayuda.sqlwhere = "where tb1.lineaid = " + lineaid.Text + " and tb1.grupoid = " + grupoid.Text + " and tb1.subgrupoid = " + subgrupoid.Text + " ";
                            frmayuda.sqland = "and";
                        }
                        else
                        {
                            if (lineaid.Text.Trim().Length > 0 && grupoid.Text.Trim().Length > 0)
                            {
                                frmayuda.sqlwhere = "where tb1.lineaid = " + lineaid.Text + " and tb1.grupoid = " + grupoid.Text + " ";
                                frmayuda.sqland = "and";
                            }
                            else
                            {
                                if (lineaid.Text.Trim().Length > 0)
                                {
                                    frmayuda.sqlwhere = "where lineaid = " + lineaid.Text + " ";
                                    frmayuda.sqland = "and";
                                }
                                else
                                {
                                    if (grupoid.Text.Trim().Length > 0)
                                    {
                                        frmayuda.sqlwhere = "where grupoid = " + grupoid.Text + " ";
                                        frmayuda.sqland = "and";
                                    }
                                    else
                                    {
                                        if (subgrupoid.Text.Trim().Length > 0)
                                        {
                                            frmayuda.sqlwhere = "where subgrupoid = " + subgrupoid.Text + " ";
                                            frmayuda.sqland = "and";
                                        }
                                        else
                                        {
                                            frmayuda.sqlwhere = "where";
                                            frmayuda.sqland = string.Empty;
                                        }
                                    }
                                }
                            }
                        }

                        frmayuda.sqlgroupby = " GROUP BY tb1.productid " +
                                    ", tb1.productname " +
                                    ", tb2.costoultimo ";

                        frmayuda.criteriosbusqueda = new string[] { "PRODUCTO", "CODIGO" };
                        frmayuda.columbusqueda = "tb1.productname,tb1.productid";
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
            if (resultado1.Trim().Length > 0 && resultado2.Trim().Length > 0)
            {
                productid.Text = resultado1.Trim();
            }
        }

        private void AyudaProducto2(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "<< AYUDA  TABLA PRODUCTOS >>";
                frmayuda.sqlquery = "SELECT tb1.productid, tb1.productname, tb2.stock,tb2.costoultimo FROM tb_ta_productos AS tb1 ";
                frmayuda.sqlinner = "inner join tb_ta_local_stock as tb2 on tb1.productid = tb2.productid ";

                if (lineaid.Text.Trim().Length > 0 && grupoid.Text.Trim().Length > 0 && subgrupoid.Text.Trim().Length > 0)
                {
                    frmayuda.sqlwhere = "where tb1.lineaid = " + lineaid.Text + " and tb1.grupoid = " + grupoid.Text + " and tb1.subgrupoid = " + subgrupoid.Text + " ";
                    frmayuda.sqland = "and";
                }
                else
                {
                    if (lineaid.Text.Trim().Length > 0 && grupoid.Text.Trim().Length > 0)
                    {
                        frmayuda.sqlwhere = "where tb1.lineaid = " + lineaid.Text + " and tb1.grupoid = " + grupoid.Text + " ";
                        frmayuda.sqland = "and";
                    }
                    else
                    {
                        if (lineaid.Text.Trim().Length > 0)
                        {
                            frmayuda.sqlwhere = "where lineaid = " + lineaid.Text + " ";
                            frmayuda.sqland = "and";
                        }
                        else
                        {
                            if (grupoid.Text.Trim().Length > 0)
                            {
                                frmayuda.sqlwhere = "where grupoid = " + grupoid.Text + " ";
                                frmayuda.sqland = "and";
                            }
                            else
                            {
                                if (subgrupoid.Text.Trim().Length > 0)
                                {
                                    frmayuda.sqlwhere = "where subgrupoid = " + subgrupoid.Text + " ";
                                    frmayuda.sqland = "and";
                                }
                                else
                                {
                                    frmayuda.sqlwhere = "where";
                                    frmayuda.sqland = string.Empty;
                                }
                            }
                        }
                    }
                }
                frmayuda.criteriosbusqueda = new string[] { "PRODUCTO", "CODIGO" };
                frmayuda.columbusqueda = "tb1.productname,tb1.productid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeProducto2;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
        private void RecibeProducto2(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0 && resultado2.Trim().Length > 0)
            {
            }
        }



        private void Frm_reporte_mov_balancestock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btn_salir_Click(sender, e);
            }
        }

        private void lineaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaLinea(string.Empty);
            }
        }
        private void lineaid_LostFocus(object sender, System.EventArgs e)
        {
            ValidaLinea();
        }
        private void grupoid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaGrupo(string.Empty);
            }
        }
        private void grupoid_LostFocus(object sender, System.EventArgs e)
        {
            ValidaGrupo();
        }
        private void subgrupoid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Ayudasubgrupo(string.Empty);
            }
        }
        private void subgrupoid_LostFocus(object sender, System.EventArgs e)
        {
            ValidaSubgrupo();
        }
        private void productid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaProducto(string.Empty);
            }
        }
        private void productidfin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaProducto2(string.Empty);
            }
        }
        private void productid_LostFocus(object sender, System.EventArgs e)
        {
            ValidaProducto();
        }

        private void rollo_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(sender, e);
        }

        private void Fech_impresion()
        {
            if (chkimpresion.Checked == true)
            {
                var fecha = dtmfecha.Value.ToString("dd-MM-yyyy");
                VariablesPublicas.FechImpresion = fecha;
            }
            else
            {
                VariablesPublicas.FechImpresion = DateTime.Today.ToString("dd-MM-yyyy");
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_imprimir_131_Click(object sender, EventArgs e)
        {
            try
            {
                var miForma = new REPORTES.Frm_reportes();
                miForma.Text = "Reporte balance de stock";
                miForma.dominioid = dominio.Trim();
                miForma.moduloid = modulo.Trim();
                miForma.moduloname = cboModuloid.Text.ToString();
                miForma.local = local.Trim();
                miForma.localname = cboLocal.Text.ToString();
                miForma.lineaid = lineaid.Text.Trim();
                miForma.grupoid = grupoid.Text.Trim();
                miForma.subgrupoid = subgrupoid.Text.Trim();
                miForma.productid = productid.Text.Trim();
                miForma.Peranio = cboPerianio.SelectedValue.ToString();

                var mes1 = Convert.ToInt32(cboPerimesini.SelectedValue);
                var mes2 = Convert.ToInt32(cboPerimesfin.SelectedValue);
                if (mes1 < 10)
                {
                    miForma.Mesdoini = "0" + Convert.ToString(cboPerimesini.SelectedValue);
                    VariablesPublicas.Perimesini = miForma.Mesdoini;
                }
                else
                {
                    miForma.Mesdoini = Convert.ToString(cboPerimesini.SelectedValue);
                    VariablesPublicas.Perimesini = miForma.Mesdoini;
                }

                if (mes2 < 10)
                {
                    miForma.Mesdofin = "0" + Convert.ToString(cboPerimesfin.SelectedValue);
                    VariablesPublicas.Perimesfin = miForma.Mesdofin;
                }
                else
                {
                    miForma.Mesdofin = Convert.ToString(cboPerimesfin.SelectedValue);
                    VariablesPublicas.Perimesfin = miForma.Mesdofin;
                }

                Fech_impresion();
                miForma.formulario = "Frm_reporte_mov_balancestock";
                miForma.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImpresionFormato131()
        {
            var TablaMov_balancestock = new DataTable("mov_balancestock");
            var BL = new tb_60movimientosdetBL();
            var BE = new tb_60movimientosdet();

            var mes1 = Convert.ToInt32(cboPerimesini.SelectedValue.ToString());
            var mes2 = Convert.ToInt32(cboPerimesfin.SelectedValue.ToString());
            BE.moduloid = modulo;
            BE.local = local;
            BE.perianio = ((MERCADERIA.MainMercaderia)MdiParent).perianio;
            if (mes1 < 10)
            {
                BE.perimesini = "0" + Convert.ToString(cboPerimesini.SelectedValue.ToString());
            }
            else
            {
                BE.perimesini = Convert.ToString(cboPerimesini.SelectedValue.ToString());
            }

            if (mes2 < 10)
            {
                BE.perimesfin = "0" + Convert.ToString(cboPerimesfin.SelectedValue.ToString());
            }
            else
            {
                BE.perimesfin = Convert.ToString(cboPerimesfin.SelectedValue.ToString());
            }

            BE.lineaid = lineaid.Text.Trim();
            BE.grupoid = grupoid.Text.Trim();
            BE.subgrupoid = subgrupoid.Text.Trim();
            BE.productidini = productid.Text.Trim();

            var dt = new DataTable();
            dt = BL.GetAll_Balance(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            TablaMov_balancestock = dt;

            if (TablaMov_balancestock.Rows.Count == 0)
            {
                MessageBox.Show("No existe Información Procesada", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var miForma = new Frm_Reportes();
                var reporteBalanceStock = new REPORTES.CR_mov_balancestock();
                miForma.Text = "Reporte Balance de Stock";

                Fech_impresion();
                reporteBalanceStock.DataDefinition.FormulaFields["empresaestable"].Text = "': " + VariablesPublicas.EmpresaEstablec.Trim() + "'";
                reporteBalanceStock.DataDefinition.FormulaFields["empresatipo"].Text = "': " + ((MERCADERIA.MainMercaderia)MdiParent).moduloname + "'";
                reporteBalanceStock.DataDefinition.FormulaFields["empresaperiodo"].Text = "': " + VariablesPublicas.N_PrimerMes1.Trim() + " " + VariablesPublicas.perianio.Trim() + "'";
                if (VariablesPublicas.N_FinMes1 == string.Empty)
                {
                    reporteBalanceStock.DataDefinition.FormulaFields["mesperifin"].Text = string.Empty;
                }
                else
                {
                    reporteBalanceStock.DataDefinition.FormulaFields["mesperifin"].Text = "'-   " + VariablesPublicas.N_FinMes1.Trim() + " " + VariablesPublicas.perianio.Trim() + "'";
                }
                reporteBalanceStock.DataDefinition.FormulaFields["fechaimpresion"].Text = "': " + VariablesPublicas.FechImpresion + "'";
                miForma.Table = TablaMov_balancestock;
                miForma.Reporte = reporteBalanceStock;
                miForma.Show();
            }
        }

        private void btn_imprimir_121_Click(object sender, EventArgs e)
        {
        }

        private void chkimpresion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkimpresion.Checked == true)
            {
                dtmfecha.Enabled = true;
            }
            else
            {
                dtmfecha.Enabled = false;
            }
        }

        private void btnPrint131_Click(object sender, EventArgs e)
        {
            try
            {
                var miForma = new REPORTES.Frm_reportes();
                miForma.Text = "Reporte balance de stock";
                miForma.dominioid = dominio.Trim();
                miForma.moduloid = cboModuloid.SelectedValue.ToString();
                //miForma.moduloid = modulo.Trim();
                miForma.moduloname = cboModuloid.Text;
                //miForma.moduloname = ((MERCADERIA.MainMercaderia)MdiParent).moduloname;
                miForma.local = cboLocal.SelectedValue.ToString();
                miForma.localname = cboLocal.Text;
                //miForma.localname = ((MERCADERIA.MainMercaderia)MdiParent).localname;
                miForma.lineaid = lineaid.Text.Trim();
                miForma.grupoid = grupoid.Text.Trim();
                miForma.subgrupoid = subgrupoid.Text.Trim();
                miForma.productid = productid.Text.Trim();
                miForma.Peranio = cboPerianio.SelectedValue.ToString();
                miForma.Mesdoini = Convert.ToString(cboPerimesini.SelectedIndex + 1).PadLeft(2, '0');
                miForma.Mesdofin = Convert.ToString(cboPerimesfin.SelectedIndex + 1).PadLeft(2, '0');

                if (chkimpresion.Checked == true)
                {
                    miForma.Fechprint = dtmfecha.Value.ToString("dd-MM-yyyy");
                }
                else
                {
                    miForma.Fechprint = DateTime.Today.ToString("dd-MM-yyyy");
                }

                //Fech_impresion();
                miForma.formulario = "Frm_reporte_mov_balancestock";
                miForma.tipreporte = "13.1";
                miForma.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint121_Click(object sender, EventArgs e)
        {
            try
            {
                var miForma = new REPORTES.Frm_reportes();
                miForma.Text = "Reporte balance de stock";
                miForma.dominioid = dominio.Trim();
                miForma.moduloid = cboModuloid.SelectedValue.ToString();
                //miForma.moduloid = modulo.Trim();
                miForma.moduloname = cboModuloid.Text;
                //miForma.moduloname = ((MERCADERIA.MainMercaderia)MdiParent).moduloname;
                miForma.local = cboLocal.SelectedValue.ToString();
                miForma.localname = cboLocal.Text;
                //miForma.localname = ((MERCADERIA.MainMercaderia)MdiParent).localname;
                miForma.lineaid = lineaid.Text.Trim();
                miForma.grupoid = grupoid.Text.Trim();
                miForma.subgrupoid = subgrupoid.Text.Trim();
                miForma.productid = productid.Text.Trim();
                miForma.Peranio = cboPerianio.SelectedValue.ToString();
                miForma.Mesdoini = Convert.ToString(cboPerimesini.SelectedIndex + 1).PadLeft(2, '0');
                miForma.Mesdofin = Convert.ToString(cboPerimesfin.SelectedIndex + 1).PadLeft(2, '0');

                if (chkimpresion.Checked == true)
                {
                    miForma.Fechprint = dtmfecha.Value.ToString("dd-MM-yyyy");
                }
                else
                {
                    miForma.Fechprint = DateTime.Today.ToString("dd-MM-yyyy");
                }

                //Fech_impresion();
                miForma.formulario = "Frm_reporte_mov_balancestock";
                miForma.tipreporte = "12.1";
                miForma.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       
    }
}
