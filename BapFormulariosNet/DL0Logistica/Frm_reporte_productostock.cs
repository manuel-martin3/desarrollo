using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.DL0Logistica
{
    public partial class Frm_reporte_productostock : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String PERFILID = string.Empty;

        private String ssModo = "NEW";

        public Frm_reporte_productostock()
        {
            InitializeComponent();
            lineaid.LostFocus += new System.EventHandler(lineaid_LostFocus);
            grupoid.LostFocus += new System.EventHandler(grupoid_LostFocus);
            subgrupoid.LostFocus += new System.EventHandler(subgrupoid_LostFocus);
            productid.LostFocus += new System.EventHandler(productid_LostFocus);
            colorid.LostFocus += new System.EventHandler(colorid_LostFocus);
        }

        private void PARAMETROS_TABLA()
        {
        }

        private void form_bloqueado(Boolean var)
        {
            if (modulo.ToString() == "0100" || modulo.ToString() == "0900")
            {
                subgrupoid.Enabled = !var;
                subgruponame.Enabled = var;
                productid.Enabled = var;
                productidold.Enabled = var;
                cbomodulo.Enabled = var;
                localdes.Enabled = var;
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
                btn_nuevo.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_imprimir.Enabled = false;
                btn_excel.Enabled = false;
                btn_salir.Enabled = false;
            }
            else
            {
                subgrupoid.Enabled = !var;
                subgruponame.Enabled = var;
                productid.Enabled = var;
                productidold.Enabled = var;
                cbomodulo.Enabled = false;
                localdes.Enabled = false;
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
                btn_nuevo.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_imprimir.Enabled = false;
                btn_excel.Enabled = false;
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
                btn_salir.Enabled = true;

                ssModo = "NEW";
            }
        }
        private void ValidaLinea()
        {
            if (lineaid.Text.Trim().Length > 0)
            {
                var BL = new tb_60lineaBL();
                var BE = new tb_60linea();
                var dt = new DataTable();

                BE.moduloid = cbomodulo.SelectedValue.ToString();
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

                BE.moduloid = cbomodulo.SelectedValue.ToString();
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

                BE.moduloid = cbomodulo.SelectedValue.ToString();
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

                BE.moduloid = cbomodulo.SelectedValue.ToString();
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
                    productidold.Text = dt.Rows[0]["productidold"].ToString().Trim();
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

                BE.moduloid = cbomodulo.SelectedValue.ToString();
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
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData )
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

                BE.dominioid = "60";
                BE.moduloid = cbomodulo.SelectedValue.ToString();
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

                BE.dominioid = "60";
                BE.moduloid = cbomodulo.SelectedValue.ToString();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();

                        var frmayuda = new Ayudas.Frm_help_general();

                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA TABLA GRUPOS >>";
                        frmayuda.sqlquery = "SELECT grupoid, gruponame FROM tb_" + modd + "_grupo g ";
                        frmayuda.sqlinner = string.Empty;
                        frmayuda.sqlwhere = "where g.status != '9' ";
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

                BE.dominioid = "60";
                BE.moduloid = cbomodulo.SelectedValue.ToString();
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
                BE.moduloid = cbomodulo.SelectedValue.ToString();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();

                        var frmayuda = new Ayudas.Frm_help_general();

                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA  TABLA PRODUCTOS >>";
                        frmayuda.sqlquery = " SELECT tb1.productid,tb1.productidold, tb1.productname,"+
                                            " SUM(IIF(mdet.almacaccionid = '10',mdet.cantidad * 1,mdet.cantidad *-1)) AS stock, " +
                                            " tb2.costoultimo FROM tb_" + modd + "_productos AS tb1 ";
                        frmayuda.sqlinner = " INNER JOIN tb_" + modd + "_local_stock as tb2 on tb1.productid = tb2.productid "+
                                            " LEFT JOIN tb_" + modd + "_movimientosdet mdet ON tb1.productid = mdet.productid "; 
                        frmayuda.sqlwhere = " WHERE ";
                        frmayuda.sqland = string.Empty;
                        frmayuda.sqlgroupby = " GROUP BY tb1.productid,tb1.productidold, tb1.productname,tb2.costoultimo ";

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

                BE.dominioid = "60";
                BE.moduloid = cbomodulo.SelectedValue.ToString();
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

        private void limpiar_documento()
        {
            if (modulo.ToString() == "0100" || modulo.ToString() == "0900")
            {
                fechadoc.Value = DateTime.Today;
                lineaid.Text = string.Empty;
                lineaname.Text = string.Empty;
                grupoid.Text = string.Empty;
                gruponame.Text = string.Empty;
                subgrupoid.Text = string.Empty;
                subgruponame.Text = string.Empty;
                productid.Text = string.Empty;
                productidold.Text = string.Empty;
                productname.Text = string.Empty;
                colorid.Text = string.Empty;
                colorname.Text = string.Empty;
            }
            else
            {
                fechadoc.Value = DateTime.Today;
                lineaid.Text = string.Empty;
                lineaname.Text = string.Empty;
                grupoid.Text = string.Empty;
                gruponame.Text = string.Empty;
                subgrupoid.Text = string.Empty;
                subgruponame.Text = string.Empty;
                productid.Text = string.Empty;
                productidold.Text = string.Empty;
                productname.Text = string.Empty;
                colorid.Text = string.Empty;
                colorname.Text = string.Empty;
                cbomodulo.SelectedValue = modulo.ToString();
                localdes.SelectedValue = local.ToString();
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
            if (Parent.Parent.Name == "MainLogistica")
            {
                modulo = ((DL0Logistica.MainLogistica)MdiParent).moduloid;
                local = ((DL0Logistica.MainLogistica)MdiParent).local;
                PERFILID = ((DL0Logistica.MainLogistica)MdiParent).perfil;
            }

            if (Parent.Parent.Name == "MainAlmacen")
            {
                modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
                local = ((D60ALMACEN.MainAlmacen)MdiParent).local;
                PERFILID = ((D60ALMACEN.MainAlmacen)MdiParent).perfil;
            }

            if (Parent.Parent.Name == "MainProduccion")
            {
                modulo = ((D70Produccion.MainProduccion)MdiParent).moduloid;
                local = ((D70Produccion.MainProduccion)MdiParent).local;
                PERFILID = ((D70Produccion.MainProduccion)MdiParent).perfil;
            }


            get_cbo_modulo();

            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_salir.Enabled = true;

            procedenciaid.Items.Clear();
            procedenciaid.Items.AddRange("Todos,Nacional,Importado".Split(new char[] { ',' }));
            procedenciaid.SelectedIndex = 0;
        }

        private void get_cbo_modulo()
        {
            var BL = new sys_dominioBL();
            try
            {
                cbomodulo.DataSource = BL.GetAllDominioModuloPorUsuario(EmpresaID, VariablesPublicas.Usuar, dominio).Tables[0];
                cbomodulo.ValueMember = "moduloid";
                cbomodulo.DisplayMember = "moduloname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (e.KeyCode == Keys.Enter)
            {
                ValidaProducto();
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
                var miForma = new D60ALMACEN.REPORTES.Frm_reportes();
                miForma.Text = "STOCK POR ARTICULO";
                miForma.dominioid = "60".Trim();

                if (cbomodulo.SelectedIndex != -1)
                {
                    miForma.moduloid = cbomodulo.SelectedValue.ToString();
                }
                else
                {
                    MessageBox.Show("!!! ...Seleccione el Módulo ... !!!", "Información");
                    return;
                }

                if (cbomodulo.SelectedValue.ToString() == "0200")
                {
                    MessageBox.Show("!!! ...Seleccione Otro Módulo ... !!!", "Información");
                    return;
                }

                if (localdes.SelectedIndex != -1)
                {
                    miForma.local = localdes.SelectedValue.ToString();
                }
                else
                {
                    MessageBox.Show("!!!... Seleccione Local ...!!!", "Información");
                    return;
                }

                miForma.lineaid = lineaid.Text.Trim();
                miForma.grupoid = grupoid.Text.Trim();
                miForma.subgrupoid = subgrupoid.Text.Trim();
                miForma.productid = productid.Text.Trim();
                miForma.productidold = productidold.Text.Trim();
                miForma.colorid = colorid.Text.Trim();
                miForma.procedenciaid = procedenciaid.SelectedIndex.ToString();
                miForma.status = chkTodos.Checked ? "1" : "0";

                miForma.formulario = "Frm_reporte_productostock";
                miForma.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            var TablaProductostock = new DataTable("Productostock");
            try
            {
                var BL = new tb_60local_stockBL();
                var BE = new tb_60local_stock();

                BE.moduloid = modulo.Trim();
                BE.local = local.Trim();
                BE.lineaid = lineaid.Text.Trim();
                BE.grupoid = grupoid.Text.Trim();
                BE.subgrupoid = subgrupoid.Text.Trim();
                BE.productid = productid.Text.Trim();
                BE.colorid = colorid.Text.Trim();
                BE.status = chkTodos.Checked ? "1" : "0";

                TablaProductostock = BL.GetAll_productostock(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (TablaProductostock != null)
                {
                    Examinar3.DataSource = TablaProductostock;
                    Examinar3.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            var TablaProductostock = new DataTable("Productostock");
            try
            {
                var BL = new tb_60local_stockBL();
                var BE = new tb_60local_stock();

                if (cbomodulo.SelectedIndex != -1)
                {
                    BE.moduloid = cbomodulo.SelectedValue.ToString();
                }
                else
                {
                    MessageBox.Show("!!! ...Seleccione el Módulo ... !!!", "Información");
                    return;
                }

                if (cbomodulo.SelectedValue.ToString() == "0200")
                {
                    MessageBox.Show("!!! ...Seleccione Otro Módulo ... !!!", "Información");
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
                BE.status = chkTodos.Checked ? "1" : "0";
                TablaProductostock = BL.GetAll_productostock(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (TablaProductostock != null)
                {
                    Examinar3.DataSource = TablaProductostock;
                    Examinar3.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exportarExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfdliquidacion.ShowDialog(this) == DialogResult.OK)
            {
                Examinar3.ExportToXls(sfdliquidacion.FileName);
                OpenFile(sfdliquidacion.FileName);
            }
        }

        private static void OpenFile(string fileName)
        {
            try
            {
                var process = new System.Diagnostics.Process();
                process.StartInfo.FileName = fileName;
                process.StartInfo.Verb = "Open";
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                process.Start();
            }
            catch
            {
                MessageBox.Show("No se puede encontrar una aplicación en el sistema adecuado para abrir el archivo con datos exportados.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbomodulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbomodulo.Items.Count > 0)
            {
                get_dominio_modulo_local(dominio.ToString(), cbomodulo.SelectedValue.ToString());
            }
        }
    }
}
