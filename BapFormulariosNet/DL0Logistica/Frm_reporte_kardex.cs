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
    public partial class Frm_reporte_kardex : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String ssModo = "NEW";

        public Frm_reporte_kardex()
        {
            InitializeComponent();
            grupoid.LostFocus += new System.EventHandler(grupoid_LostFocus);
            productid.LostFocus += new System.EventHandler(productid_LostFocus);
        }

        private void form_bloqueado(Boolean var)
        {
            try
            {
                productid.Enabled = var;

                cbo_almacenes.Enabled = var;
                fechadoc.Enabled = false;
                grupoid.Enabled = var;
                gruponame.Enabled = false;
                productid.Enabled = var;
                serdoc_desde.Enabled = var;
                serdoc_hasta.Enabled = var;
                numdoc_desde.Enabled = var;
                numdoc_hasta.Enabled = var;

                productname.Enabled = false;
                fechdocini.Enabled = var;
                fechdocfin.Enabled = var;

                btn_nuevo.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_imprimir.Enabled = false;
                btn_excel.Enabled = false;

                btn_buscar.Enabled = false;
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
            cbo_almacenes.DataSource = new BindingSource(test, null);
            cbo_almacenes.DisplayMember = "Value";
            cbo_almacenes.ValueMember = "Key";
        }


        private void CargarComboAlmacenes()
        {
            try
            {
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                BE.dominioid = dominio.ToString();
                var dt = new DataTable();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                cbo_almacenes.DataSource = dt;
                cbo_almacenes.ValueMember = "moduloid";
                cbo_almacenes.DisplayMember = "moduloname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void ValidaGrupo()
        {
            if (grupoid.Text.Trim().Length > 0)
            {
                var BL = new tb_60grupoBL();
                var BE = new tb_60grupo();
                var dt = new DataTable();

                BE.moduloid = cbo_almacenes.SelectedValue.ToString();
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

        private void ValidaProducto()
        {
            if (productid.Text.Trim().Length == 13)
            {
                var BL = new tb_60productosBL();
                var BE = new tb_60productos();
                var dt = new DataTable();

                BE.moduloid = cbo_almacenes.SelectedValue.ToString();
                BE.productid = productid.Text.Trim();

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
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

        private void AyudaGrupo(String lpdescrlike)
        {
            try
            {
                var modd = string.Empty;
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();

                BE.dominioid = dominio;
                BE.moduloid = cbo_almacenes.SelectedValue.ToString();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();

                        var frmayuda = new Ayudas.Frm_help_general();

                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA TABLA GRUPOS >>";
                        frmayuda.sqlquery = " SELECT ctacte, ctactename FROM tb_cliente ";
                        frmayuda.sqlinner = string.Empty;
                        frmayuda.sqlwhere = " where ";
                        frmayuda.sqland = string.Empty;
                        frmayuda.criteriosbusqueda = new string[] { "PROVEEDOR", "CODIGO" };
                        frmayuda.columbusqueda = "ctactename,ctacte";
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

        private void AyudaProducto(String lpdescrlike)
        {
            try
            {
                var modd = string.Empty;
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();

                BE.dominioid = dominio;
                BE.moduloid = cbo_almacenes.SelectedValue.ToString();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();

                        var frmayuda = new Ayudas.Frm_help_general();

                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA  TABLA PRODUCTOS >>";
                        frmayuda.sqlquery = " SELECT tb1.productid, tb1.productname,"+
                                            " SUM(IIF(mdet.almacaccionid = '10',mdet.cantidad * 1,mdet.cantidad *-1)) AS stock, " +
                                            " tb2.costoultimo FROM tb_" + modd + "_productos AS tb1 ";
                        frmayuda.sqlinner = " INNER JOIN tb_" + modd + "_local_stock as tb2 on tb1.productid = tb2.productid "+
                                            " LEFT JOIN tb_" + modd + "_movimientosdet mdet ON tb1.productid = mdet.productid ";
                        frmayuda.sqlwhere = " WHERE ";
                        frmayuda.sqland = string.Empty;
                        frmayuda.sqlgroupby = " tb1.productid, tb1.productname,tb2.costoultimo ";
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

        private void limpiar_documento()
        {
            try
            {
                fechadoc.Value = DateTime.Today;
                cbo_almacenes.SelectedIndex = 0;

                var fechatemp = DateTime.Today;
                var f1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
                fechdocini.Text = f1.ToString();
                fechdocfin.Value = DateTime.Today;

                numdoc_desde.Text = string.Empty;
                numdoc_hasta.Text = string.Empty;
                serdoc_desde.Text = string.Empty;
                serdoc_hasta.Text = string.Empty;

                grupoid.Text = string.Empty;
                gruponame.Text = string.Empty;
                productid.Text = string.Empty;
                productname.Text = string.Empty;
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

            ssModo = "NEW";
        }

        private void Frm_reporte_stockrollo_Activated(object sender, EventArgs e)
        {
        }

        private void Frm_reporte_stockrollo_Load(object sender, EventArgs e)
        {
            if (Parent.Parent.Name == "MainLogistica")
            {
                modulo = ((DL0Logistica.MainLogistica)MdiParent).moduloid;
                local = ((DL0Logistica.MainLogistica)MdiParent).local;
            }

            if (Parent.Parent.Name == "MainAlmacen")
            {
                modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
                local = ((D60ALMACEN.MainAlmacen)MdiParent).local;
            }

            CargarComboAlmacenes();
            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_buscar.Enabled = true;
            btn_salir.Enabled = true;
            cbo_almacenes.SelectedIndex = -1;
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
        private void grupoid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaGrupo(string.Empty);
            }

            if (e.KeyCode == Keys.Enter)
            {
                productid.Focus();
            }
        }
        private void grupoid_LostFocus(object sender, System.EventArgs e)
        {
        }
        private void productid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaProducto(string.Empty);
            }

            if (e.KeyCode == Keys.Enter)
            {
                btn_imprimir_Click(sender, e);
            }
        }

        private void productid_LostFocus(object sender, System.EventArgs e)
        {
            ValidaProducto();
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
                var miForma = new Reportes.Frm_reportes();
                miForma.Text = "Reporte de Kardex Orden de Compra";

                if (cbo_almacenes.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione Almacen", "!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                miForma.moduloid = cbo_almacenes.SelectedValue.ToString();
                miForma.num_desde = serdoc_desde.Text.Trim() + numdoc_desde.Text.Trim();
                miForma.num_hasta = serdoc_hasta.Text.Trim() + numdoc_hasta.Text.Trim();
                miForma.grupoid = grupoid.Text.Trim();
                miForma.productid = productid.Text.Trim();
                miForma.formulario = "Frm_reporte_kardex";
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
        private void fechdocini_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fechdocfin.Focus();
            }

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

        private void numdoc_desde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var num = string.Empty;
                if (numdoc_desde.Text.Trim().Length > 0)
                {
                    num = numdoc_desde.Text.Trim().PadLeft(6, '0');
                }
                numdoc_desde.Text = num.ToString();
                numdoc_hasta.Focus();
            }
        }

        private void numdoc_hasta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var num = string.Empty;
                if (numdoc_hasta.Text.Trim().Length > 0)
                {
                    num = numdoc_hasta.Text.Trim().PadLeft(6, '0');
                }
                numdoc_hasta.Text = num.ToString();
                grupoid.Focus();
            }
        }

        private void serdoc_desde_TextChanged(object sender, EventArgs e)
        {
            serdoc_desde.Text = serdoc_desde.Text.Trim().ToUpper();
            serdoc_hasta.Text = serdoc_desde.Text;
        }

        private void serdoc_desde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                numdoc_desde.Focus();
            }
        }

        private void cbo_almacenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            serdoc_desde.Focus();
        }
    }
}
