using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.MERCADERIA
{
    public partial class Frm_reporte_productokardex : plantilla
    {
        private String EmpresaID = string.Empty;
        private String dominio = string.Empty;
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String PERFILID = string.Empty;
        private String direcnume = string.Empty;
        private String ctactedirecc = string.Empty;
        private String ssModo = "NEW";

        public Frm_reporte_productokardex()
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
            var f = (MainMercaderia)MdiParent;
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
            try
            {
                subgrupoid.Enabled = !var;
                subgruponame.Enabled = var;
                productid.Enabled = var;

                almacaccionid.Enabled = var;
                fechadoc.Enabled = false;
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

                btn_salir.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var BL = new tb_me_colorBL();
                var BE = new tb_me_color();
                var dt = new DataTable();

                BE.moduloid = modulo;
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

                BE.moduloid = modulo;
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
                        frmayuda.sqlquery = "SELECT grupoid, gruponame FROM tb_me_grupo ";
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
                        frmayuda.sqlquery = "SELECT subgrupoid, subgruponame, lineaid, grupoid FROM tb_me_subgrupo ";
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

                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA  TABLA PRODUCTOS >>";
                        frmayuda.sqlquery = "SELECT tb1.productid, tb1.productname, tb2.stock,tb2.costoultimo FROM tb_me_productos AS tb1 ";
                        frmayuda.sqlinner = "INNER JOIN tb_me_local_stock as tb2 on tb1.productid = tb2.productid ";
                        frmayuda.sqlwhere = "WHERE tb1.moduloid = '" + modulo + "' AND  local = '" + local + "' ";
                        frmayuda.sqland = "AND";
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
                BE.moduloid = modulo;
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();

                        var frmayuda = new Ayudas.Frm_help_general();

                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA  TABLA COLOR>>";
                        frmayuda.sqlquery = "SELECT colorid, colorname FROM tb_me_color ";
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
                frmayuda.sqlwhere = "where moduloid = '" + modulo + "'";
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
            try
            {
                fechadoc.Value = DateTime.Today;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void Frm_reporte_stockrollo_Load(object sender, EventArgs e)
        {
            EmpresaID = VariablesPublicas.EmpresaID;
            dominio = ((MERCADERIA.MainMercaderia)MdiParent).dominioid;
            modulo = ((MERCADERIA.MainMercaderia)MdiParent).moduloid;
            local = ((MERCADERIA.MainMercaderia)MdiParent).local;

            data_cbo_tipmov();
            produbic.CharacterCasing = CharacterCasing.Upper;
            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_salir.Enabled = true;
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
            var BL = new tb_me_movimientosdetBL();
            var BE = new tb_me_movimientosdet();

            BE.moduloid = modulo;
            BE.local = local;
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
            TablaProductokardex_tela = BL.GetAll_productokardex(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
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
                reporteRollokardex.DataDefinition.FormulaFields["almacen"].Text = "'" + VariablesPublicas.EmpresaTipo + "'";
                if (modulo.Trim() == "0810")
                {
                    reporteRollokardex.DataDefinition.FormulaFields["name"].Text = "'TIENDA : " + VariablesPublicas.Local + "  - " + VariablesPublicas.nombrelocal + "'";
                }
                else
                {
                    reporteRollokardex.DataDefinition.FormulaFields["name"].Text = "'LOCAL : " + VariablesPublicas.Local + "  - " + VariablesPublicas.nombrelocal + "'";
                }

                if (modulo == "0320")
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
    }
}
