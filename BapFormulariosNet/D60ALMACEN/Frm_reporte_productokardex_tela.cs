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
    public partial class Frm_reporte_productokardex_tela : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;
        private String localname = "";

        private String PERFILID = string.Empty;
        private String direcnume = string.Empty;
        private String ctactedirecc = string.Empty;
        private String ssModo = "NEW";

        public Frm_reporte_productokardex_tela()
        {
            InitializeComponent();
            lineaid.LostFocus += new System.EventHandler(lineaid_LostFocus);
            grupoid.LostFocus += new System.EventHandler(grupoid_LostFocus);
            subgrupoid.LostFocus += new System.EventHandler(subgrupoid_LostFocus);
            productid.LostFocus += new System.EventHandler(productid_LostFocus);
            colorid.LostFocus += new System.EventHandler(colorid_LostFocus);
            ctacte.LostFocus += new System.EventHandler(ctacte_LostFocus);
            mottrasladointid.LostFocus += new System.EventHandler(mottrasladointid_LostFocus);
        }

        private void PARAMETROS_TABLA()
        {
            var xxferfil = string.Empty;
            var f = (MainAlmacen)MdiParent;
            xxferfil = f.perfil.ToString();
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

        private void form_bloqueado(Boolean var)
        {
            if (modulo.ToString() == "0100" || modulo.ToString() == "0900")
            {
                subgrupoid.Enabled = !var;
                subgruponame.Enabled = var;
                productid.Enabled = var;

                cbo_moduloides.Enabled = var;
                localdes.Enabled = var;

                almacaccionid.Enabled = var;
                lineaid.Enabled = var;
                lineaname.Enabled = false;
                grupoid.Enabled = var;
                gruponame.Enabled = false;
                subgrupoid.Enabled = var;
                subgruponame.Enabled = false;
                productid.Enabled = var;
                productname.Enabled = false;
                colorid.Enabled = var;
                colorname.Enabled = false;
                ctacte.Enabled = var;
                ctactename.Enabled = false;
                direcname.Enabled = var;
                direcdeta.Enabled = false;
                fechdocini.Enabled = var;
                fechdocfin.Enabled = var;
                serref.Enabled = var;
                numdococ.Enabled = var;
                numdococ1.Enabled = var;
                produbic.Enabled = var;
                mottrasladointid.Enabled = var;
                mottrasladointname.Enabled = false;

                btn_nuevo.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_imprimir.Enabled = false;
                btn_excel.Enabled = false;

                btn_buscar.Enabled = false;
                btn_salir.Enabled = false;
            }
            else
            {
                subgrupoid.Enabled = !var;
                subgruponame.Enabled = var;
                productid.Enabled = var;

                cbo_moduloides.Enabled = false;
                localdes.Enabled = false;

                almacaccionid.Enabled = var;
                lineaid.Enabled = var;
                lineaname.Enabled = false;
                grupoid.Enabled = var;
                gruponame.Enabled = false;
                subgrupoid.Enabled = var;
                subgruponame.Enabled = false;
                productid.Enabled = var;
                productname.Enabled = false;
                colorid.Enabled = var;
                colorname.Enabled = false;
                ctacte.Enabled = var;
                ctactename.Enabled = false;
                direcname.Enabled = var;
                direcdeta.Enabled = false;
                fechdocini.Enabled = var;
                fechdocfin.Enabled = var;
                serref.Enabled = var;
                numdococ.Enabled = var;
                numdococ1.Enabled = var;
                produbic.Enabled = var;
                mottrasladointid.Enabled = var;
                mottrasladointname.Enabled = false;

                btn_nuevo.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_imprimir.Enabled = false;
                btn_excel.Enabled = false;

                btn_buscar.Enabled = false;
                btn_salir.Enabled = false;
            }
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
                subgrupoid.Text = string.Empty;
                btn_nuevo.Enabled = true;
                btn_buscar.Enabled = true;
                btn_salir.Enabled = true;

                ssModo = "NEW";
            }
        }
        private void data_cbo_tipmov()
        {
            var test = new Dictionary<string, string>();
            test.Add(" ", "TODO");
            test.Add("10", "INGRESO");
            test.Add("20", "SALIDA");
            almacaccionid.DataSource = new BindingSource(test, null);
            almacaccionid.DisplayMember = "Value";
            almacaccionid.ValueMember = "Key";
        }
        private void ValidaLinea()
        {
            if (lineaid.Text.Trim().Length > 0)
            {
                var BL = new tb_60lineaBL();
                var BE = new tb_60linea();
                var dt = new DataTable();

                BE.moduloid = cbo_moduloides.SelectedValue.ToString();
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

                BE.moduloid = cbo_moduloides.SelectedValue.ToString();
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

                BE.moduloid = cbo_moduloides.SelectedValue.ToString();
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

                BE.moduloid = cbo_moduloides.SelectedValue.ToString();
                BE.productid = productid.Text.Trim();
                BE.status = "0";

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
        private void ValidaColor()
        {
            if (colorid.Text.Trim().Length > 0)
            {
                var BL = new tb_60colorBL();
                var BE = new tb_60color();
                var dt = new DataTable();

                BE.moduloid = cbo_moduloides.SelectedValue.ToString();
                BE.colorid = colorid.Text.Trim().PadLeft(3, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    colorid.Text = dt.Rows[0]["colorid"].ToString().Trim();
                    colorname.Text = dt.Rows[0]["colorname"].ToString().Trim();
                }
                else
                {
                    colorid.Text = string.Empty;
                    colorname.Text = string.Empty;
                }
            }
            else
            {
                colorid.Text = string.Empty;
                colorname.Text = string.Empty;
            }
        }
        private void ValidaMotivoint()
        {
            if (mottrasladointid.Text.Trim().Length > 0)
            {
                var BL = new tb_mottrasladointBL();
                var BE = new tb_mottrasladoint();
                var dt = new DataTable();

                BE.moduloid = cbo_moduloides.SelectedValue.ToString();
                BE.mottrasladointid = mottrasladointid.Text.Trim().PadLeft(2, '0');

                dt = BL.GetOne(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    mottrasladointid.Text = dt.Rows[0]["mottrasladointid"].ToString().Trim();
                    mottrasladointname.Text = dt.Rows[0]["mottrasladointname"].ToString().Trim();
                }
                else
                {
                    mottrasladointid.Text = string.Empty;
                    mottrasladointname.Text = string.Empty;
                }
            }
            else
            {
                mottrasladointid.Text = string.Empty;
                mottrasladointname.Text = string.Empty;
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
                BE.moduloid = cbo_moduloides.SelectedValue.ToString();
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
                BE.moduloid = cbo_moduloides.SelectedValue.ToString();

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
                BE.moduloid = cbo_moduloides.SelectedValue.ToString();
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

                BE.dominioid = "60";
                BE.moduloid = cbo_moduloides.SelectedValue.ToString();

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();

                        var frmayuda = new Ayudas.Frm_help_general();

                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA  TABLA PRODUCTOS >>";

                        frmayuda.sqlquery = " select tb1.productid, tb1.productname,tb1.unmed, " +
                                              " tb2.stock, " +
                                              " tb2.costopromed as precventa, tb2.[local] from tb_" + modd + "_productos tb1 ";

                        frmayuda.sqlinner = " LEFT JOIN tb_" + modd + "_local_stock tb2 on tb1.moduloid = tb2.moduloid " +
                                               " AND tb1.productid = tb2.productid ";

                        //frmayuda.sqlquery = " SELECT tb1.productid, tb1.productname,"+
                        //                    " SUM(IIF(mdet.almacaccionid = '10',mdet.cantidad * 1,mdet.cantidad *-1)) AS stock, " +
                        //                    " tb2.costoultimo FROM tb_" + modd + "_productos AS tb1 ";
                        //frmayuda.sqlinner = " INNER JOIN tb_" + modd + "_local_stock as tb2 on tb1.productid = tb2.productid "+
                        //                    " LEFT JOIN tb_" + modd + "_movimientosdet mdet ON tb1.productid = mdet.productid "; 

                        frmayuda.sqlwhere = " Where tb1.status = '0' and tb2.[local] = '" + local.ToString() + "'";
                        frmayuda.sqland = " And";

                        //frmayuda.sqlgroupby = " GROUP BY " +
                        //                      " tb1.productid, tb1.productname, tb2.costoultimo ";

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

        private void AyudaColor(String lpdescrlike)
        {
            try
            {
                var modd = string.Empty;
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();

                BE.dominioid = dominio;
                BE.moduloid = cbo_moduloides.SelectedValue.ToString();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();

                        var frmayuda = new Ayudas.Frm_help_general();

                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA  TABLA COLOR>>";
                        frmayuda.sqlquery = "SELECT colorid, colorname FROM tb_" + modd + "_color ";
                        frmayuda.sqlinner = string.Empty;
                        frmayuda.sqlwhere = "where";
                        frmayuda.sqland = string.Empty;
                        frmayuda.criteriosbusqueda = new string[] { "COLOR", "CODIGO" };
                        frmayuda.columbusqueda = "colorname,colorid";
                        frmayuda.returndatos = "0,1";

                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeColor;
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void RecibeColor(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                colorid.Text = resultado1.Trim();
            }
        }

        private void AyudaMotivoint(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "<< AYUDA  TABLA MOTIVO DE TRASLADO INTERNO>>";
                frmayuda.sqlquery = "SELECT mottrasladointid, mottrasladointname FROM tb_mottrasladoint";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where moduloid = '" + cbo_moduloides.SelectedValue.ToString() + "'";
                frmayuda.sqland = "and";
                frmayuda.criteriosbusqueda = new string[] { "MOTIVO TRASLADO", "CODIGO" };
                frmayuda.columbusqueda = "mottrasladointname,mottrasladointid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeMotivoint;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
        private void RecibeMotivoint(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                mottrasladointid.Text = resultado1.Trim();
            }
        }

        private void limpiar_documento()
        {
            if (modulo.ToString() == "0100" || modulo.ToString() == "0900")
            {
                almacaccionid.SelectedIndex = 0;

                var fechatemp = DateTime.Today;
                var f1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
                fechdocini.Text = f1.ToString();
                fechdocfin.Value = DateTime.Today;

                lineaid.Text = string.Empty;
                lineaname.Text = string.Empty;
                grupoid.Text = string.Empty;
                gruponame.Text = string.Empty;
                subgrupoid.Text = string.Empty;
                subgruponame.Text = string.Empty;
                productid.Text = string.Empty;
                productname.Text = string.Empty;
                colorid.Text = string.Empty;
                ctacte.Text = string.Empty;
                ctactename.Text = string.Empty;
                direcname.Text = string.Empty;
                direcdeta.Text = string.Empty;
                colorname.Text = string.Empty;
                produbic.Text = string.Empty;
                serref.Text = string.Empty;
                numdococ1.Text = string.Empty;
                numdococ.Text = string.Empty;
                mottrasladointid.Text = string.Empty;
                mottrasladointname.Text = string.Empty;
                lineaid.Focus();
            }
            else
            {
                almacaccionid.SelectedIndex = 0;
                cbo_moduloides.SelectedValue = modulo.ToString();
                localdes.SelectedValue = local.ToString();

                var fechatemp = DateTime.Today;
                var f1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
                fechdocini.Text = f1.ToString();
                fechdocfin.Value = DateTime.Today;

                lineaid.Text = string.Empty;
                lineaname.Text = string.Empty;
                grupoid.Text = string.Empty;
                gruponame.Text = string.Empty;
                subgrupoid.Text = string.Empty;
                subgruponame.Text = string.Empty;
                productid.Text = string.Empty;
                productname.Text = string.Empty;
                colorid.Text = string.Empty;
                ctacte.Text = string.Empty;
                ctactename.Text = string.Empty;
                direcname.Text = string.Empty;
                direcdeta.Text = string.Empty;
                colorname.Text = string.Empty;
                produbic.Text = string.Empty;
                serref.Text = string.Empty;
                numdococ1.Text = string.Empty;
                numdococ.Text = string.Empty;
                mottrasladointid.Text = string.Empty;
                mottrasladointname.Text = string.Empty;
                lineaid.Focus();
            }
        }

        private void nuevo()
        {
            limpiar_documento();
            form_bloqueado(true);
            btn_imprimir.Enabled = true;
            btn_excel.Enabled = true;
            btn_cancelar.Enabled = true;
            lineaid.Focus();

            ssModo = "NEW";
        }

        private void Frm_reporte_stockrollo_Activated(object sender, EventArgs e)
        {
        }

        private void Frm_reporte_stockrollo_Load(object sender, EventArgs e)
        {
            if (Parent.Parent.Name == "MainAlmacen")
            {
                modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
                local = ((D60ALMACEN.MainAlmacen)MdiParent).local;
                localname = ((D60ALMACEN.MainAlmacen)MdiParent).localname;
            }

            if (Parent.Parent.Name == "MainProduccion")
            {
                modulo = ((D70Produccion.MainProduccion)MdiParent).moduloid;
                local = ((D70Produccion.MainProduccion)MdiParent).local;
                localname = ((D70Produccion.MainProduccion)MdiParent).localname;
            }

            get_cbo_modulo();
            data_cbo_tipmov();
            produbic.CharacterCasing = CharacterCasing.Upper;
            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_buscar.Enabled = true;
            btn_salir.Enabled = true;
        }

        private void get_cbo_modulo()
        {
            var BL = new sys_moduloBL();
            var BE = new tb_sys_modulo();
            var dt = new DataTable();
            BE.dominioid = dominio.Trim();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cbo_moduloides.DataSource = dt;
                cbo_moduloides.ValueMember = "moduloid";
                cbo_moduloides.DisplayMember = "moduloname";
            }
        }

        private void get_dominio_modulo_local(string dominioid, string moduloid)
        {
            if (moduloid.ToString().Length == 4)
            {
                var BL = new sys_localBL();
                var BE = new tb_sys_local();
                BE.dominioid = dominioid;
                BE.moduloid = moduloid;

                var dt = new DataTable();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    localdes.DataSource = dt;
                    localdes.ValueMember = "local";
                    localdes.DisplayMember = "localname";
                }
            }
        }

        private void Frm_reporte_stockrollo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
            }

            if (e.Control && e.KeyCode == Keys.N)
            {
                if (btn_nuevo.Enabled)
                {
                    nuevo();
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                if (btn_cancelar.Enabled)
                {
                    form_accion_cancelEdicion(1);
                }
                else
                {
                    btn_salir_Click(sender, e);
                }
            }
        }

        private void lineaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaLinea(string.Empty);
            }

            if (e.KeyCode == Keys.Enter)
            {
                grupoid.Focus();
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

            if (e.KeyCode == Keys.Enter)
            {
                subgrupoid.Focus();
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

            if (e.KeyCode == Keys.Enter)
            {
                productid.Focus();
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
            if (e.KeyCode == Keys.Enter)
            {
                colorid.Focus();
            }
        }
        private void productid_LostFocus(object sender, System.EventArgs e)
        {
            ValidaProducto();
        }
        private void colorid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaColor(string.Empty);
            }

            if (e.KeyCode == Keys.Enter)
            {
                serref.Focus();
            }
        }
        private void colorid_LostFocus(object sender, System.EventArgs e)
        {
            ValidaColor();
        }
        private void serref_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(sender, e);
        }
        private void numref_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(sender, e);
        }
        private void mottrasladointid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaMotivoint(string.Empty);
            }

            if (e.KeyCode == Keys.Enter)
            {
                ctacte.Focus();
            }
        }
        private void mottrasladointid_LostFocus(object sender, System.EventArgs e)
        {
            ValidaMotivoint();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            form_accion_cancelEdicion(1);
        }
        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                ImpresionKardexArticulo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ImpresionKardexArticulo()
        {
            var TablaProductokardex_tela = new DataTable();
            var BL = new tb_60movimientosdetBL();
            var BE = new tb_60movimientosdet();

            if (cbo_moduloides.SelectedIndex != -1)
            {
                BE.moduloid = cbo_moduloides.SelectedValue.ToString();
            }
            else
            {
                MessageBox.Show("!!!... Seleccione Modulo ...!!!", "Información");
                return;
            }

            if (localdes.SelectedIndex != -1)
            {
                BE.local = localdes.SelectedValue.ToString();
            }
            else
            {
                MessageBox.Show("!!!... Seleccione Local ...!!!", "Información");
                return;
            }

            BE.lineaid = lineaid.Text.Trim();
            BE.grupoid = grupoid.Text.Trim();
            BE.subgrupoid = subgrupoid.Text.Trim();
            BE.productid = productid.Text.Trim();
            BE.colorid = colorid.Text.Trim();
            BE.mottrasladointid = mottrasladointid.Text.Trim();
            BE.Ubicacion = produbic.Text.Trim();
            BE.ctacte = ctacte.Text.Trim();
            BE.direcnume = direcnume.ToString();
            BE.fechdocini = Convert.ToDateTime(fechdocini.Text.Substring(0, 10));
            BE.fechdocfin = Convert.ToDateTime(fechdocfin.Text.Substring(0, 10));

            BE.serref = serref.Text.Trim();
            BE.numref = numdococ1.Text.Trim() + numdococ.Text.Trim();

            if (almacaccionid.SelectedValue.ToString() != string.Empty)
            {
                BE.almacaccionid = almacaccionid.SelectedValue.ToString();
            }
            TablaProductokardex_tela = BL.GetAll_productokardex_tela(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            if (TablaProductokardex_tela.Rows.Count == 0)
            {
                MessageBox.Show("No existe Información Procesada", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var miForma = new Frm_Reportes();
                var reporteRollokardex = new REPORTES.CR_productokardex();
                miForma.Text = "Reporte de Kardex x Articulo";

                reporteRollokardex.DataDefinition.FormulaFields["fechdoc"].Text = "'DE: " + fechdocini.Text.Substring(0, 10) + "  AL:" + fechdocfin.Text.Substring(0, 10) + "'";
                reporteRollokardex.DataDefinition.FormulaFields["almacen"].Text = "'" + cbo_moduloides.Text+ "'";
                if (modulo.Trim() == "0810")
                {
                    reporteRollokardex.DataDefinition.FormulaFields["name"].Text = "'TIENDA : " + localdes.SelectedValue.ToString() + "  - " + localdes.Text +"'";
                }
                else
                {
                    reporteRollokardex.DataDefinition.FormulaFields["name"].Text = "'LOCAL : " + localdes.SelectedValue.ToString() + "  - " + localdes.Text + "'";
                }

                if (modulo  == "0320")
                {
                    reporteRollokardex.DataDefinition.FormulaFields["varitems"].Text = "'ROLLO'";
                }
                else
                {
                    reporteRollokardex.DataDefinition.FormulaFields["varitems"].Text = "''";
                }
                miForma.Table = TablaProductokardex_tela;
                miForma.Reporte = reporteRollokardex;
                miForma.Show();
            }
        }




        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ctacte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaClientes(string.Empty);
            }
            if (e.KeyCode == Keys.Enter)
            {
                direcname.Focus();
            }
        }

        private void AyudaClientes(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "Ayuda Cliente/Proveedor";
                frmayuda.sqlquery = "select ctacte, ctactename, nmruc, direc from tb_cliente";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where";
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

        private void ctacte_LostFocus(object sender, System.EventArgs e)
        {
            ValidaCliente();
        }

        private void ValidaCliente()
        {
            if (ctacte.Text.Trim().Length > 0)
            {
                var BL = new clienteBL();
                var BE = new tb_cliente();
                var dt = new DataTable();

                BE.ctacte = ctacte.Text.Trim().PadLeft(7, '0');
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    ctacte.Text = dt.Rows[0]["ctacte"].ToString().Trim();
                    ctactename.Text = dt.Rows[0]["ctactename"].ToString().Trim();
                }
                else
                {
                    ctacte.Text = string.Empty;
                    ctactename.Text = string.Empty;
                }
            }
        }




        private void RecibeClientes(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                ctacte.Text = resultado1.Trim();
                ctactename.Text = resultado3.Trim();
            }
        }

        private void direcname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaClientesDireccion(string.Empty);
            }
            if (e.KeyCode == Keys.Enter)
            {
                produbic.Focus();
            }
        }


        private void AyudaClientesDireccion(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all";
                frmayuda.titulo = "Ayuda Dirección";
                frmayuda.sqlquery = "select ctacte,direcnume, direcname, direcdeta from tb_cliente_direc";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where ctacte = '" + ctacte.Text.Trim() + "'";
                frmayuda.sqland = "and";
                frmayuda.criteriosbusqueda = new string[] { "NOM DIRECCIÓN", "DIRECCIÓN" };
                frmayuda.columbusqueda = "direcname,direcdeta";
                frmayuda.returndatos = "0,1,2,3";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeClientesDireccion;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
        private void RecibeClientesDireccion(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                ctactedirecc = resultado1.Trim();
                direcnume = resultado2.Trim();
                direcname.Text = resultado3.Trim();
                direcdeta.Text = resultado4.Trim();
            }
        }

        private void numdococ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var numdo = string.Empty;
                if (numdococ.Text.Trim().Length > 0)
                {
                    numdo = numdococ.Text.Trim().PadLeft(6, '0');
                }

                numdococ.Text = numdo.ToString();
                mottrasladointid.Focus();
            }
        }

        private void numdococ1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var numdo = string.Empty;
                if (numdococ1.Text.Trim().Length > 0)
                {
                    numdo = numdococ1.Text.Trim().PadLeft(4, '0');
                }

                numdococ1.Text = numdo.ToString();
                numdococ.Focus();
            }
        }

        private void produbic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fechdocini.Focus();
            }
        }

        private void fechdocini_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fechdocfin.Focus();
            }
        }

        private void fechdocfin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_imprimir_Click(sender, e);
            }
        }

        private void serref_KeyDown(object sender, KeyEventArgs e)
        {
            var numdo = string.Empty;

            if (e.KeyCode == Keys.Enter)
            {
                if (serref.Text.Trim().Length > 0)
                {
                    numdo = serref.Text.Trim().PadLeft(4, '0');
                }

                serref.Text = numdo.ToString();
                numdococ1.Focus();
            }
        }

        private void cbo_moduloides_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_moduloides.Items.Count > 0)
            {
                get_dominio_modulo_local(dominio.ToString(), cbo_moduloides.SelectedValue.ToString());
            }
        }
    }
}
