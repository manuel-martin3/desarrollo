using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

using System.IO;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.Net.Sockets;

namespace BapFormulariosNet.D60ALMACEN.CATALOGO
{
    public partial class Frm_producto_rollos : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String perianio = string.Empty;
        private String perimes = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern SafeFileHandle CreateFile(string lpFileName, FileAccess dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, FileMode dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

        private DataTable Tablaproductorollo;
        private Boolean procesado = false;
        private Boolean statusDoc = true;

        private String ssModo = "NEW";

        public Frm_producto_rollos()
        {
            InitializeComponent();
            productid.LostFocus += new System.EventHandler(productid_LostFocus);
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
        private void NIVEL_FORMS()
        {
            XNIVEL = VariablesPublicas.Get_nivelperfil(PERFILID, Name).Substring(0, 1);
            if (XNIVEL != "0")
            {
                btn_clave.Image = global::BapFormulariosNet.Properties.Resources.btn_Lock20;
            }
            else
            {
                btn_clave.Image = global::BapFormulariosNet.Properties.Resources.btn_Un_Lock20;
            }
        }
        private void btn_clave_Click(object sender, EventArgs e)
        {
            try
            {
                var miForma = new Ayudas.Form_user_admin();
                miForma.Owner = this;
                miForma.PasaDatos = RecibePermiso;
                miForma.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RecibePermiso(Boolean resultado1, String resultado2)
        {
            if (resultado1)
            {
                XNIVEL = "0";
                XGLOSA = resultado2.Trim();
                btn_clave.Image = global::BapFormulariosNet.Properties.Resources.btn_Un_Lock20;
            }
        }

        private void get_nuevorollo()
        {
            var BL = new tb_ta_prodrolloBL();
            var BE = new tb_ta_prodrollo();
            var DT = new DataTable();
            DT = BL.GetAll_numgenerado(EmpresaID, BE).Tables[0];
            if (DT.Rows.Count > 0)
            {
                rollo.Text = (Convert.ToDecimal(DT.Rows[0]["numgenerado"]) + 1).ToString().Trim().PadLeft(10, '0');
                productid.Enabled = true;
            }
        }
        private void get_val_fechadoc()
        {
            try
            {
                var BL = new constantesgeneralesBL();
                var dt = new DataTable();

                dt = BL.GetOne(EmpresaID, dominio, modulo, local).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    perianio = dt.Rows[0]["perianio"].ToString().Trim();
                    perimes = dt.Rows[0]["perimes"].ToString().Trim();
                }
                var fechaactual = DateTime.Today;
                rollofecompra.Value = fechaactual;

                get_tipocambio(rollofecompra.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusDoc = false;
            }
        }
        private void get_tipocambio(String fecha)
        {
            try
            {
                var BL = new tipocambioBL();
                var dt = new DataTable();

                dt = BL.GetOne(EmpresaID, Convert.ToDateTime(fecha)).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    tcamb.Text = Convert.ToDecimal(dt.Rows[0]["venta"]).ToString("###,##0.0000");
                }
                else
                {
                    tcamb.Text = "1";
                }
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
                productid.Enabled = var;
                productname.Enabled = var;
                productname.ReadOnly = true;

                rollo.Enabled = !var;
                rollofecompra.Enabled = var;
                tcamb.Enabled = false;
                rollolote.Enabled = var;
                rolloancho.Enabled = var;
                rolloencog.Enabled = var;
                tipofallasid.Enabled = var;
                docuref.Enabled = false;
                rollostockini.Enabled = false;
                rollovalorini.Enabled = false;
                rollostock.Enabled = false;
                rollovaloractual.Enabled = var;
                rollomedcompra.Enabled = var;
                rolloingre.Enabled = false;
                rolloegres.Enabled = false;

                gridproductorollo.ReadOnly = true;
                gridproductorollo.Enabled = !var;
                cbo_buscar.Enabled = !var;
                txt_criterio.Enabled = !var;
                rollodesde.Enabled = !var;
                rollohasta.Enabled = !var;
                btn_busqueda.Enabled = !var;


                btn_nuevo.Enabled = false;
                btn_editar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_grabar.Enabled = false;
                btn_eliminar.Enabled = false;
                btn_imprimir.Enabled = false;

                btn_primero.Enabled = false;
                btn_anterior.Enabled = false;
                btn_siguiente.Enabled = false;
                btn_ultimo.Enabled = false;

                btn_detanadir.Enabled = false;

                btn_clave.Enabled = true;
                btn_log.Enabled = true;
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
                NIVEL_FORMS();
                limpiar_documento();
                form_bloqueado(false);
                rollo.Text = string.Empty;
                get_val_fechadoc();
                btn_nuevo.Enabled = true;
                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;
                btn_salir.Enabled = true;

                ssModo = "NEW";
            }
        }
        private void form_cargar_datos(String posicion)
        {
            try
            {
                var BL = new tb_ta_prodrolloBL();
                var BE = new tb_ta_prodrollo();
                var dt = new DataTable();

                if (rollo.Text.Trim().Length > 0)
                {
                    BE.rollo = rollo.Text.Trim().PadLeft(10, '0');
                }
                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    limpiar_documento();
                    ssModo = "EDIT";

                    rollofecompra.Text = dt.Rows[0]["rollofecompra"].ToString().Trim();
                    productid.Text = dt.Rows[0]["productid"].ToString().Trim();
                    productname.Text = dt.Rows[0]["productname"].ToString().Trim();
                    rollo.Text = dt.Rows[0]["rollo"].ToString().Trim();

                    rollolote.Text = dt.Rows[0]["rollolote"].ToString().Trim();
                    rolloancho.Text = dt.Rows[0]["rolloancho"].ToString().Trim();
                    rolloencog.Text = dt.Rows[0]["rolloencog"].ToString().Trim();
                    tipofallasid.SelectedValue = dt.Rows[0]["tipofallasid"].ToString().Trim();
                    docuref.Text = dt.Rows[0]["docuref"].ToString().Trim();
                    rollostockini.Text = dt.Rows[0]["rollostockini"].ToString().Trim();
                    rollovalorini.Text = dt.Rows[0]["rollovalorini"].ToString().Trim();
                    rollostock.Text = dt.Rows[0]["rollostock"].ToString().Trim();
                    rollovaloractual.Text = dt.Rows[0]["rollovaloractual"].ToString().Trim();
                    rollomedcompra.Text = dt.Rows[0]["rollomedcompra"].ToString().Trim();
                    rolloingre.Text = dt.Rows[0]["rolloingre"].ToString().Trim();
                    rolloegres.Text = dt.Rows[0]["rolloegres"].ToString().Trim();

                    btn_editar.Enabled = true;
                    btn_eliminar.Enabled = true;
                    btn_imprimir.Enabled = true;

                    btn_primero.Enabled = true;
                    btn_anterior.Enabled = true;
                    btn_siguiente.Enabled = true;
                    btn_ultimo.Enabled = true;

                    btn_log.Enabled = true;
                    btn_salir.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void data_cbo_tipofallasid()
        {
            var BL = new tb_ta_tela_fallasBL();
            var BE = new tb_ta_tela_fallas();
            try
            {
                tipofallasid.DataSource = BL.GetAll(EmpresaID, BE).Tables[0];
                tipofallasid.ValueMember = "fallaid";
                tipofallasid.DisplayMember = "fallaname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void data_cbo_buscar()
        {
            cbo_buscar.Items.Add(new System.Web.UI.WebControls.ListItem("ROLLO", "01"));
            cbo_buscar.Items.Add(new System.Web.UI.WebControls.ListItem("COD PRODUCTO", "02"));
            cbo_buscar.Items.Add(new System.Web.UI.WebControls.ListItem("PRODUCTO", "03"));
            cbo_buscar.SelectedIndex = 0;
        }
        private void ValidaProducto(String xproductid, Boolean retrn)
        {
            if (xproductid.Trim().Length > 0)
            {
                var BL = new tb_60local_stockBL();
                var BE = new tb_60local_stock();
                var DT = new DataTable();
                BE.moduloid = modulo;
                BE.productid = xproductid.Trim();
                DT = BL.GetAll(EmpresaID, BE).Tables[0];

                if (DT.Rows.Count > 0)
                {
                    productid.Text = DT.Rows[0]["productid"].ToString().Trim();
                    productname.Text = DT.Rows[0]["productname"].ToString().Trim();
                    form_bloqueado(true);
                    productid.Enabled = false;
                    btn_cancelar.Enabled = true;
                    btn_grabar.Enabled = true;
                    btn_detanadir.Enabled = true;
                    btn_log.Enabled = true;
                }
                else
                {
                    if (!retrn)
                    {
                        productid.Text = string.Empty;
                        productname.Text = string.Empty;
                        productid.Focus();
                    }
                }
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
        private void AyudaProducto(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "<< AYUDA  TABLA PRODUCTOS >>";
                frmayuda.sqlquery = "SELECT tb1.productid, tb1.productname, tb2.stock,tb2.costoultimo FROM tb_ta_productos AS tb1 ";
                frmayuda.sqlinner = "LEFT JOIN tb_ta_local_stock as tb2 on tb1.productid = tb2.productid  AND tb2.local = '" + local + "'";
                frmayuda.sqlwhere = "where";
                frmayuda.sqland = string.Empty;
                frmayuda.criteriosbusqueda = new string[] { "PRODUCTO", "CODIGO" };
                frmayuda.columbusqueda = "tb1.productname,tb1.productid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeProducto;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }

        private void RecibeProducto(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            try
            {
                if (resultado1.Trim().Length > 0 && resultado2.Trim().Length > 0)
                {
                    ValidaProducto(resultado1.Trim(), false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SEGURIDAD_LOG(String accion)
        {
            var xclave = VariablesPublicas.EmpresaID + "/" + ((D60ALMACEN.MainAlmacen)MdiParent).perianio;
            try
            {
                var BL = new tb_co_seguridadlogBL();
                var BE = new tb_co_seguridadlog();

                BE.moduloid = Name;
                BE.clave = xclave;
                BE.cuser = VariablesPublicas.Usuar;
                BE.fecha = DateTime.Now;
                BE.pc = VariablesPublicas.userip;
                BE.accion = accion.Trim();
                BE.detalle = productid.Text.Trim() + "/" + rollo.Text.Trim() + " MED.COMP:" + rollomedcompra.Text.Trim() + "/" + XGLOSA;

                BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE);
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
                rollofecompra.Value = DateTime.Today;
                get_tipocambio(rollofecompra.Text.Trim());
                rolloencog.Text = "1";
                tipofallasid.SelectedIndex = 0;
                docuref.Text = string.Empty;
                rollostockini.Text = "0";
                rollovalorini.Text = "0";
                rollostock.Text = "0";
                rollovaloractual.Text = "0";
                rollomedcompra.Text = "0";
                rolloingre.Text = "0";
                rolloegres.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevo()
        {
            limpiar_documento();
            form_bloqueado(false);
            get_val_fechadoc();
            get_nuevorollo();
            rollo.Enabled = false;
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_detanadir.Enabled = true;
            btn_log.Enabled = true;
            productid.Focus();

            ssModo = "NEW";
        }
        private void Insert()
        {
            try
            {
                if (rollo.Text.Trim().Length != 10)
                {
                    MessageBox.Show("Falta Codigo Rollo !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (productid.Text.Trim().Length != 13)
                    {
                        MessageBox.Show("Falta Codigo Producto !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (Equivalencias.IsNumeric(rollomedcompra.Text) && Convert.ToDecimal(rollomedcompra.Text) <= 0)
                        {
                            MessageBox.Show("Medida de compra debe ser mayor a  CERO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            var BL = new tb_ta_prodrolloBL();
                            var BE = new tb_ta_prodrollo();

                            BE.rollo = rollo.Text.Trim().PadLeft(10, '0');
                            BE.productid = productid.Text;
                            BE.rollolote = rollolote.Text.Trim().ToUpper();
                            BE.rollofecompra = Convert.ToDateTime(rollofecompra.Text.Trim().PadLeft(1, '0'));
                            BE.rolloingre = Convert.ToDecimal(rolloingre.Text.Trim().PadLeft(1, '0'));
                            BE.rolloegres = Convert.ToDecimal(rolloegres.Text.Trim().PadLeft(1, '0'));
                            BE.rolloancho = Convert.ToDecimal(rolloancho.Text.Trim().PadLeft(1, '0'));
                            BE.rolloencog = Convert.ToDecimal(rolloencog.Text.Trim().PadLeft(1, '0'));
                            BE.rollomedcompra = Convert.ToDecimal(rollomedcompra.Text.Trim().PadLeft(1, '0'));
                            BE.rollovaloractual = Convert.ToDecimal(rollovaloractual.Text.Trim().PadLeft(1, '0'));
                            if (tipofallasid.SelectedIndex != -1)
                            {
                                BE.tipofallasid = tipofallasid.SelectedValue.ToString();
                            }
                            BE.usuar = VariablesPublicas.Usuar.Trim();

                            if (BL.Insert(EmpresaID, BE))
                            {
                                MessageBox.Show("Datos grabados correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                procesado = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Update()
        {
            try
            {
                if (rollo.Text.Trim().Length != 10)
                {
                    MessageBox.Show("Falta Codigo Rollo !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (productid.Text.Trim().Length != 13)
                    {
                        MessageBox.Show("Falta Codigo Producto !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (Equivalencias.IsNumeric(rollomedcompra.Text) && Convert.ToDecimal(rollomedcompra.Text) <= 0)
                        {
                            MessageBox.Show("Medida de compra debe ser mayor a  CERO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            var BL = new tb_ta_prodrolloBL();
                            var BE = new tb_ta_prodrollo();

                            BE.rollo = rollo.Text.Trim().PadLeft(10, '0');
                            BE.productid = productid.Text;
                            BE.rollolote = rollolote.Text.Trim().ToUpper();
                            BE.rollofecompra = Convert.ToDateTime(rollofecompra.Text.Trim().PadLeft(1, '0'));
                            BE.rolloingre = Convert.ToDecimal(rolloingre.Text.Trim().PadLeft(1, '0'));
                            BE.rolloegres = Convert.ToDecimal(rolloegres.Text.Trim().PadLeft(1, '0'));
                            BE.rolloancho = Convert.ToDecimal(rolloancho.Text.Trim().PadLeft(1, '0'));
                            BE.rolloencog = Convert.ToDecimal(rolloencog.Text.Trim().PadLeft(1, '0'));
                            BE.rollomedcompra = Convert.ToDecimal(rollomedcompra.Text.Trim().PadLeft(1, '0'));
                            BE.rollovaloractual = Convert.ToDecimal(rollovaloractual.Text.Trim().PadLeft(1, '0'));
                            if (tipofallasid.SelectedIndex != -1)
                            {
                                BE.tipofallasid = tipofallasid.SelectedValue.ToString();
                            }
                            BE.usuar = VariablesPublicas.Usuar.Trim();

                            if (BL.Update(EmpresaID, BE))
                            {
                                SEGURIDAD_LOG("M");
                                MessageBox.Show("Datos modificado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                procesado = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Delete()
        {
            try
            {
                if (rollo.Text.Trim().Length != 10)
                {
                    MessageBox.Show("Falta Codigo Rollo !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (productid.Text.Trim().Length != 13)
                    {
                        MessageBox.Show("Falta Codigo Producto !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (Equivalencias.IsNumeric(rollomedcompra.Text) && Convert.ToDecimal(rollomedcompra.Text) <= 0)
                        {
                            MessageBox.Show("Medida de compra debe ser mayor a  CERO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            var BL = new tb_ta_prodrolloBL();
                            var BE = new tb_ta_prodrollo();

                            BE.rollo = rollo.Text.Trim().PadLeft(10, '0');

                            if (BL.Delete(EmpresaID, BE))
                            {
                                SEGURIDAD_LOG("E");
                                MessageBox.Show("Rollo eliminado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                limpiar_documento();
                                form_bloqueado(false);

                                btn_nuevo.Enabled = true;

                                btn_primero.Enabled = true;
                                btn_anterior.Enabled = true;
                                btn_siguiente.Enabled = true;
                                btn_ultimo.Enabled = true;

                                btn_salir.Enabled = true;
                                ;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_movimiento_rollos_Activated(object sender, EventArgs e)
        {
        }
        private void Frm_movimiento_rollos_Load(object sender, EventArgs e)
        {
            modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
            local = ((D60ALMACEN.MainAlmacen)MdiParent).local;
            PERFILID = ((D60ALMACEN.MainAlmacen)MdiParent).perfil;

            NIVEL_FORMS();

            data_cbo_tipofallasid();
            data_cbo_buscar();

            Tablaproductorollo = new DataTable("productorollo");
            Tablaproductorollo.Columns.Add("rollo", typeof(String));
            Tablaproductorollo.Columns.Add("productid", typeof(String));
            Tablaproductorollo.Columns.Add("productname", typeof(String));
            Tablaproductorollo.Columns.Add("rollolote", typeof(String));
            Tablaproductorollo.Columns.Add("rollostockini", typeof(Decimal));
            Tablaproductorollo.Columns["rollostockini"].DefaultValue = 0;
            Tablaproductorollo.Columns.Add("rollovalorini", typeof(Decimal));
            Tablaproductorollo.Columns["rollovalorini"].DefaultValue = 0;
            Tablaproductorollo.Columns.Add("rolloingre", typeof(Decimal));
            Tablaproductorollo.Columns["rolloingre"].DefaultValue = 0;
            Tablaproductorollo.Columns.Add("rolloegres", typeof(Decimal));
            Tablaproductorollo.Columns["rolloegres"].DefaultValue = 0;
            Tablaproductorollo.Columns.Add("rollostock", typeof(Decimal));
            Tablaproductorollo.Columns["rollostock"].DefaultValue = 0;
            Tablaproductorollo.Columns.Add("rollovaloractual", typeof(Decimal));
            Tablaproductorollo.Columns["rollovaloractual"].DefaultValue = 0;
            Tablaproductorollo.Columns.Add("rollomedcompra", typeof(Decimal));
            Tablaproductorollo.Columns["rollomedcompra"].DefaultValue = 0;
            Tablaproductorollo.Columns.Add("rollofecompra", typeof(String));
            Tablaproductorollo.Columns.Add("rolloancho", typeof(Decimal));
            Tablaproductorollo.Columns["rolloancho"].DefaultValue = 0;
            Tablaproductorollo.Columns.Add("rolloencog", typeof(Decimal));
            Tablaproductorollo.Columns["rolloencog"].DefaultValue = 0;
            Tablaproductorollo.Columns.Add("tipofallasid", typeof(String));
            Tablaproductorollo.Columns.Add("docuref", typeof(String));
            Tablaproductorollo.Columns.Add("statu", typeof(String));

            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_primero.Enabled = true;
            btn_anterior.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_ultimo.Enabled = true;
            btn_salir.Enabled = true;
            rollo.Focus();
        }
        private void Frm_movimiento_rollos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                if (btn_detanadir.Enabled)
                {
                    btn_detanadir_Click(sender, e);
                }
            }

            if (e.Control && e.KeyCode == Keys.G)
            {
                if (btn_grabar.Enabled)
                {
                    btn_grabar_Click(sender, e);
                }
            }

            if (e.Control && e.KeyCode == Keys.N)
            {
                if (btn_nuevo.Enabled)
                {
                    btn_nuevo_Click(sender, e);
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

        private void rollo_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(rollo, e);
        }

        private void productid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaProducto(string.Empty);
                rollolote.Focus();
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (productid.Text.Length == 13)
                {
                    form_bloqueado(true);
                    rollolote.Focus();
                }
            }
        }

        private void productid_LostFocus(object sender, System.EventArgs e)
        {
            ValidaProducto(productid.Text, false);
        }
        private void rollostockini_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(rollostockini, e);
        }
        private void rollovalorini_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(rollovalorini, e);
        }
        private void rollostock_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(rollostock, e);
        }
        private void rollovaloractual_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_decimal(rollovaloractual, e);
        }
        private void rollomedcompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_decimal(rollomedcompra, e);
        }
        private void rolloingre_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(rolloingre, e);
        }
        private void rolloegres_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(rolloegres, e);
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
            {
                nuevo();
            }
        }
        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0")
            {
                ssModo = "EDIT";
                form_bloqueado(true);
                rollolote.Focus();

                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
                btn_detanadir.Enabled = true;
            }
        }
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            form_accion_cancelEdicion(1);
        }
        private void btn_grabar_Click(object sender, EventArgs e)
        {
            procesado = false;
            var sw_prosigue = false;
            if (ssModo == "NEW")
            {
                if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
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

                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;

                btn_salir.Enabled = true;
            }
        }
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0")
            {
                var sw_prosigue = false;
                sw_prosigue = (MessageBox.Show("¿Desea Eliminar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                if (sw_prosigue)
                {
                    Delete();
                }
            }
        }
        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Tablaproductorollo.Rows.Count > 0)
                {
                    var miForma = new REPORTES.Frm_reportes();
                    miForma.Text = "Reporte de Clientes";
                    miForma.formulario = "Frm_movimiento_rollos";
                    miForma.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_primero_Click(object sender, EventArgs e)
        {
            form_cargar_datos(Genericas.primero);
        }
        private void btn_anterior_Click(object sender, EventArgs e)
        {
            form_cargar_datos(Genericas.anterior);
        }
        private void btn_siguiente_Click(object sender, EventArgs e)
        {
            form_cargar_datos(Genericas.siguiente);
        }
        private void btn_ultimo_Click(object sender, EventArgs e)
        {
            form_cargar_datos(Genericas.ultimo);
        }

        private void btn_detanadir_Click(object sender, EventArgs e)
        {
        }

        private void btn_impcodbar_Click(object sender, EventArgs e)
        {
            var MiProceso = new System.Diagnostics.Process();
            MiProceso.StartInfo.WorkingDirectory = @"C:\BapTools";
            MiProceso.StartInfo.FileName = "printrolloscodbar.exe";
            MiProceso.StartInfo.Arguments = rollodesde.Text.ToString() + " " + rollohasta.Text.ToString();
            MiProceso.Start();
            MiProceso.WaitForExit();
            MiProceso.Close();
            MiProceso.Dispose();
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
            var oform = new Seguridadlog.FrmSeguridad();
            var xclave = VariablesPublicas.EmpresaID + "/" + ((D60ALMACEN.MainAlmacen)MdiParent).perianio;
            oform._Nombre = Name;
            oform._ClaveForm = xclave;
            oform.Owner = this;
            oform.ShowDialog();
        }


        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void data_Tablaproductorollomov()
        {
            try
            {
                var BL = new tb_ta_prodrolloBL();
                var BE = new tb_ta_prodrollo();

                var dt = new DataTable();

                switch (cbo_buscar.SelectedValue.ToString())
                {
                    case "01":
                        BE.productid = txt_criterio.Text.Trim().ToUpper();
                        break;
                    case "02":
                        BE.productname = txt_criterio.Text.Trim().ToUpper();
                        break;
                    case "03":
                        if (txt_criterio.Text.Trim().Length > 0)
                        {
                            BE.rollo = txt_criterio.Text.Trim().ToUpper().PadLeft(10, '0');
                        }
                        break;
                    default:
                        break;
                }

                if (rollodesde.Text.Trim().Length > 0)
                {
                    BE.rollodesde = rollodesde.Text.Trim().PadLeft(10, '0');
                }

                if (rollohasta.Text.Trim().Length > 0)
                {
                    BE.rollohasta = rollohasta.Text.Trim().PadLeft(10, '0');
                }

                dt = BL.GetAll_prod(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    Tablaproductorollo = dt;
                    gridproductorollo.DataSource = Tablaproductorollo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void gridproductorollo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridproductorollo.CurrentRow != null)
                {
                    var xrollo = string.Empty;
                    xrollo = gridproductorollo.Rows[e.RowIndex].Cells["grollo"].Value.ToString().Trim();
                    data_productorollo(xrollo);
                }
            }
            catch (Exception ex)
            {
            }
        }


        private void gridproductorollo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xrollo = string.Empty;
                xrollo = gridproductorollo.Rows[gridproductorollo.CurrentRow.Index].Cells["grollo"].Value.ToString().Trim();
                data_productorollo(xrollo);
            }
        }

        private void gridproductorollo_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridproductorollo[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            gridproductorollo[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            gridproductorollo.EnableHeadersVisualStyles = false;
            gridproductorollo.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            gridproductorollo.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void gridproductorollo_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            gridproductorollo[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }

        private void data_productorollo(String xrollo)
        {
            form_bloqueado(false);
            var rowrollo = Tablaproductorollo.Select("rollo='" + xrollo + "'");
            if (rowrollo.Length > 0)
            {
                foreach (DataRow row in rowrollo)
                {
                    rollo.Text = row["rollo"].ToString();
                    productid.Text = row["productid"].ToString();
                    productname.Text = row["productname"].ToString();
                    rollolote.Text = row["rollolote"].ToString();
                    rollostockini.Text = row["rollostockini"].ToString();
                    rollovalorini.Text = row["rollovalorini"].ToString();
                    rolloingre.Text = row["rolloingre"].ToString();
                    rolloegres.Text = row["rolloegres"].ToString();
                    rollostock.Text = row["rollostock"].ToString();
                    rollovaloractual.Text = row["rollovaloractual"].ToString();
                    rollomedcompra.Text = row["rollomedcompra"].ToString();
                    rollofecompra.Text = row["rollofecompra"].ToString();
                    rolloancho.Text = row["rolloancho"].ToString();
                    rolloencog.Text = row["rolloencog"].ToString();
                    tipofallasid.Text = row["tipofallasid"].ToString();
                    docuref.Text = row["docuref"].ToString();

                    btn_nuevo.Enabled = true;
                    btn_editar.Enabled = true;
                    btn_eliminar.Enabled = true;
                    btn_imprimir.Enabled = true;

                    btn_primero.Enabled = true;
                    btn_anterior.Enabled = true;
                    btn_siguiente.Enabled = true;
                    btn_ultimo.Enabled = true;

                    btn_log.Enabled = true;
                    btn_salir.Enabled = true;
                }
            }
        }

        private void rollodesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(rollodesde, e);
        }
        private void rollohasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(rollohasta, e);
        }
        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            try
            {
                if (Tablaproductorollo.Rows.Count > 0)
                {
                    Tablaproductorollo.Rows.Clear();
                }
                var BL = new tb_ta_prodrolloBL();
                var BE = new tb_ta_prodrollo();

                switch (cbo_buscar.SelectedIndex)
                {
                    case 0:
                        if (txt_criterio.Text.Trim().Length > 0)
                        {
                            BE.rollo = txt_criterio.Text.Trim().ToUpper().PadLeft(10, '0');
                        }
                        break;
                    case 1:
                        BE.productid = txt_criterio.Text.Trim().ToUpper();
                        break;
                    case 2:
                        BE.productname = txt_criterio.Text.Trim().ToUpper();
                        break;
                    default:
                        break;
                }

                if (rollodesde.Text.Trim().Length > 0)
                {
                    BE.rollodesde = rollodesde.Text.Trim().PadLeft(10, '0');
                }

                if (rollohasta.Text.Trim().Length > 0)
                {
                    BE.rollohasta = rollohasta.Text.Trim().PadLeft(10, '0');
                }

                Tablaproductorollo = BL.GetAll_prod(EmpresaID, BE).Tables[0];

                if (Tablaproductorollo.Rows.Count > 0)
                {
                    gridproductorollo.DataSource = Tablaproductorollo;
                    gridproductorollo.Rows[0].Selected = false;
                    gridproductorollo.Focus();
                }


                double sumatoria = 0, sumatoria2 = 0;
                foreach (DataGridViewRow row in gridproductorollo.Rows)
                {
                    sumatoria += Convert.ToDouble(row.Cells["grollostock"].Value);
                    sumatoria2 += Convert.ToDouble(row.Cells["grollomedcompra"].Value);
                }

                txt_metraje.Text = Convert.ToString(sumatoria.ToString("##,###,##0.00"));
                txt_metraje2.Text = Convert.ToString(sumatoria2.ToString("##,###,##0.00"));
                txtnum_rollos.Text = Convert.ToString(gridproductorollo.Rows.Count.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Imprimir_barcode_zebra()
        {
            var BL = new tb_ta_prodrolloBL();
            var BE = new tb_ta_prodrollo();
            var dt = new DataTable();
            if (rollodesde.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese ROLLO DESDE !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (rollohasta.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese ROLLO HASTA !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToInt32(rollohasta.Text) < Convert.ToInt32(rollodesde.Text))
            {
                MessageBox.Show("ROLLO HASTA < ROLLO DESDE !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BE.rollodesde = rollodesde.Text.PadLeft(10, '0');
            BE.rollohasta = rollohasta.Text.PadLeft(10, '0');

            dt = BL.GetAll_codbarra(EmpresaID, BE).Tables[0];


            var CRTLF = Convert.ToString(Equivalencias.Chr(13)) + Convert.ToString(Equivalencias.Chr(10));

            var X11 = "^XA";
            var X12 = "^MCY";
            var X13 = "^XZ";
            var X14 = "^XA";
            var X15 = "^FWN^CFD,24^PW863^LH0,0";
            var X16 = "^CI0^PR2^MNY^MTT^MMT^MD0^PON^PMN^LRN";
            var X17 = "^XZ";
            var X18 = "^XA";
            var X19 = "^MCY";
            var X20 = "^XZ";
            var X21 = "^XA";
            var X22 = "^DFR:TEMP_FMT.ZPL";
            var X23 = "^LRN";

            var X44 = "^XZ";
            var X55 = "^XA";
            var X66 = "^XFR:TEMP_FMT.ZPL";
            var X77 = "^PQ1,0,1,Y";
            var X88 = "^XZ";
            var X99 = "^XA";

            var TW101 = "^A0B,28,18^FO28,43^FD";
            var TW102 = "^A0B,23,20^FO63,186^FD";
            var TW103 = "^A0B,23,18^FO62,33^FD";
            var TW104 = "^A0B,23,16^FO94,66^FD";
            var TW105 = "^BY2^FO118,43^BAB,67,N,N,N^FD";
            var TW106 = "^A0B,34,34^FO185,93^FD";
            var TW107 = "^A0B,23,18^FO220,39^FD";
            var TW108 = "^A0B,23,18^FO253,46^FD";
            var TW109 = "^A0B,23,18^FO281,240^FD";
            var TW110 = "^A0B,23,18^FO341,303^FD";
            var TW111 = "^A0B,23,20^FO283,52^FD";
            var TW112 = "^A0B,23,18^FO311,238^FD";
            var TW113 = "^A0B,23,18^FO312,56^FD";
            var TW114 = "^A0B,39,40^FO345,65^FD";
            var TW115 = "^A0B,23,18^FO371,318^FD";

            var TW201 = "^A0B,28,18^FO452,43^FD";
            var TW202 = "^A0B,23,20^FO487,186^FD";
            var TW203 = "^A0B,23,18^FO486,33^FD";
            var TW204 = "^A0B,23,16^FO518,66^FD";
            var TW205 = "^BY2^FO542,43^BAB,67,N,N,N^FD";
            var TW206 = "^A0B,34,34^FO609,93^FD";
            var TW207 = "^A0B,23,18^FO644,39^FD";
            var TW208 = "^A0B,23,18^FO676,46^FD";
            var TW209 = "^A0B,23,18^FO705,240^FD";
            var TW210 = "^A0B,23,18^FO764,303^FD";
            var TW211 = "^A0B,23,20^FO706,52^FD";
            var TW212 = "^A0B,23,18^FO735,238^FD";
            var TW213 = "^A0B,23,18^FO735,56^FD";
            var TW214 = "^A0B,39,40^FO768,65^FD";
            var TW215 = "^A0B,23,18^FO794,318^FD";

            var pTEXTO = string.Empty;
            var xStick = 0;
            var xComa = "^FS";

            xStick = xStick + 1;

            foreach (DataRow fila in dt.Rows)
            {
                var xTW01 = string.Empty;
                var xTW02 = string.Empty;
                var xTW03 = string.Empty;
                var xTW04 = string.Empty;
                var xTW05 = string.Empty;
                var xTW06 = string.Empty;
                var xTW07 = string.Empty;
                var xTW08 = string.Empty;
                var xTW09 = string.Empty;
                var xTW10 = string.Empty;
                var xTW11 = string.Empty;
                var xTW12 = string.Empty;
                var xTW13 = string.Empty;
                var xTW14 = string.Empty;
                var xTW15 = string.Empty;

                xTW01 = fila["productid"].ToString() + fila["etiquetaname"].ToString().PadRight(30, ' ').Substring(0, 30).Trim() + xComa;
                xTW02 = "ART: " + fila["subgrupoartic"].ToString().PadRight(10, ' ').Substring(0, 10).Trim() + xComa;
                if (fila["rollolote"].ToString().Trim().Length > 0)
                {
                    xTW03 = "LOTE...: " + fila["rollolote"].ToString().PadRight(10, ' ').Substring(0, 10).Trim() + xComa;
                }
                else
                {
                    xTW03 = string.Empty + xComa;
                }
                if (fila["compo"].ToString().Trim().Length > 0)
                {
                    xTW04 = "COMPOS: " + fila["compo"].ToString().PadRight(10, ' ').Substring(0, 10).Trim() + xComa;
                }
                else
                {
                    xTW04 = string.Empty + xComa;
                }
                fila["rollostock"].ToString().Replace(".", string.Empty);
                xTW05 = fila["rollo"].ToString() + Convert.ToDecimal(fila["rollostock"].ToString().Replace(".", string.Empty)).ToString().Trim().PadLeft(5, '0') + xComa;
                xTW06 = fila["rollo"].ToString() + Convert.ToDecimal(fila["rollostock"].ToString().Replace(".", string.Empty)).ToString().Trim().PadLeft(5, '0') + xComa;
                xTW07 = "PROVE: " + fila["gruponame"].ToString().PadRight(30, ' ').Substring(0, 30).Trim() + xComa;
                xTW08 = "CLIEN: " + VariablesPublicas.EmpresaName.ToString().PadRight(30, ' ').Substring(0, 30).Trim() + xComa;
                xTW09 = "ROLLO: " + fila["rollo"].ToString().Trim() + xComa;
                xTW10 = "ONZAJ: " + fila["titulo"].ToString().Trim() + xComa;
                xTW11 = "MED.INICI: " + Convert.ToDecimal(fila["rollomedcompra"].ToString()).ToString("##0.00").Trim() + xComa;
                xTW12 = "COLOR: " + fila["colorname"].ToString().PadRight(10, ' ').Substring(0, 10).Trim() + xComa;
                xTW13 = "MED.DESPA: " + Convert.ToDecimal(fila["rolloegres"].ToString()).ToString("##0.00").Trim() + xComa;
                xTW14 = Convert.ToDecimal(fila["rollostock"].ToString()).ToString("##0.00").Trim() + xComa;
                xTW15 = DateTime.Today.Date.ToString();

                switch (xStick)
                {
                    case 1:
                        pTEXTO = pTEXTO + X11 + CRTLF;
                        pTEXTO = pTEXTO + X12 + CRTLF;
                        pTEXTO = pTEXTO + X13 + CRTLF;
                        pTEXTO = pTEXTO + X14 + CRTLF;
                        pTEXTO = pTEXTO + X15 + CRTLF;
                        pTEXTO = pTEXTO + X16 + CRTLF;
                        pTEXTO = pTEXTO + X17 + CRTLF;
                        pTEXTO = pTEXTO + X18 + CRTLF;
                        pTEXTO = pTEXTO + X19 + CRTLF;
                        pTEXTO = pTEXTO + X20 + CRTLF;
                        pTEXTO = pTEXTO + X21 + CRTLF;
                        pTEXTO = pTEXTO + X22 + CRTLF;
                        pTEXTO = pTEXTO + X23 + CRTLF;

                        pTEXTO = pTEXTO + TW101 + xTW01 + CRTLF;
                        pTEXTO = pTEXTO + TW102 + xTW02 + CRTLF;
                        pTEXTO = pTEXTO + TW103 + xTW03 + CRTLF;
                        pTEXTO = pTEXTO + TW104 + xTW04 + CRTLF;
                        pTEXTO = pTEXTO + TW105 + xTW05 + CRTLF;
                        pTEXTO = pTEXTO + TW106 + xTW06 + CRTLF;
                        pTEXTO = pTEXTO + TW107 + xTW07 + CRTLF;
                        pTEXTO = pTEXTO + TW108 + xTW08 + CRTLF;
                        pTEXTO = pTEXTO + TW109 + xTW09 + CRTLF;
                        pTEXTO = pTEXTO + TW110 + xTW10 + CRTLF;
                        pTEXTO = pTEXTO + TW111 + xTW11 + CRTLF;
                        pTEXTO = pTEXTO + TW112 + xTW12 + CRTLF;
                        pTEXTO = pTEXTO + TW113 + xTW13 + CRTLF;
                        pTEXTO = pTEXTO + TW114 + xTW14 + CRTLF;
                        pTEXTO = pTEXTO + TW115 + xTW15 + CRTLF;
                        xStick = xStick + 1;
                        break;
                    case 2:
                        pTEXTO = pTEXTO + TW201 + xTW01 + CRTLF;
                        pTEXTO = pTEXTO + TW202 + xTW02 + CRTLF;
                        pTEXTO = pTEXTO + TW203 + xTW03 + CRTLF;
                        pTEXTO = pTEXTO + TW204 + xTW04 + CRTLF;
                        pTEXTO = pTEXTO + TW205 + xTW05 + CRTLF;
                        pTEXTO = pTEXTO + TW206 + xTW06 + CRTLF;
                        pTEXTO = pTEXTO + TW207 + xTW07 + CRTLF;
                        pTEXTO = pTEXTO + TW208 + xTW08 + CRTLF;
                        pTEXTO = pTEXTO + TW209 + xTW09 + CRTLF;
                        pTEXTO = pTEXTO + TW210 + xTW10 + CRTLF;
                        pTEXTO = pTEXTO + TW211 + xTW11 + CRTLF;
                        pTEXTO = pTEXTO + TW212 + xTW12 + CRTLF;
                        pTEXTO = pTEXTO + TW213 + xTW13 + CRTLF;
                        pTEXTO = pTEXTO + TW214 + xTW14 + CRTLF;
                        pTEXTO = pTEXTO + TW215 + xTW15 + CRTLF;

                        pTEXTO = pTEXTO + X44 + CRTLF;
                        pTEXTO = pTEXTO + X55 + CRTLF;
                        pTEXTO = pTEXTO + X66 + CRTLF;
                        pTEXTO = pTEXTO + X77 + CRTLF;
                        pTEXTO = pTEXTO + X88 + CRTLF;
                        pTEXTO = pTEXTO + X99 + CRTLF;


                        xStick = 1;
                        break;
                }
            }
            if (xStick == 2)
            {
                pTEXTO = pTEXTO + X44 + CRTLF;
                pTEXTO = pTEXTO + X55 + CRTLF;
                pTEXTO = pTEXTO + X66 + CRTLF;
                pTEXTO = pTEXTO + X77 + CRTLF;
                pTEXTO = pTEXTO + X88 + CRTLF;
                pTEXTO = pTEXTO + X99 + CRTLF;
            }

            try
            {
                try
                {
                    if (File.Exists(@"C:\\reportebarcode.txt"))
                    {
                        File.Delete(@"C:\\reportebarcode.txt");
                    }

                    var escritor = new StreamWriter(@"C:\\reportebarcode.txt");
                    escritor.WriteLine(pTEXTO);
                    escritor.Close();
                }
                catch
                {
                }
            }
            catch
            {
            }
        }
        private void Imprimir_barcode_datamax()
        {
            var BL = new tb_ta_prodrolloBL();
            var BE = new tb_ta_prodrollo();
            var dt = new DataTable();
            if (rollodesde.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese ROLLO DESDE !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (rollohasta.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese ROLLO HASTA !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToInt32(rollohasta.Text) < Convert.ToInt32(rollodesde.Text))
            {
                MessageBox.Show("ROLLO HASTA < ROLLO DESDE !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BE.rollodesde = rollodesde.Text.PadLeft(10, '0');
            BE.rollohasta = rollohasta.Text.PadLeft(10, '0');

            dt = BL.GetAll_codbarra(EmpresaID, BE).Tables[0];


            var CRTLF = Convert.ToString(Equivalencias.Chr(13)) + Convert.ToString(Equivalencias.Chr(10));

            var X11 = Convert.ToString(Equivalencias.Chr(2)) + "qC";
            var X12 = Convert.ToString(Equivalencias.Chr(2)) + "n";
            var X13 = Convert.ToString(Equivalencias.Chr(2)) + "e";
            var X14 = Convert.ToString(Equivalencias.Chr(2)) + "c0000";
            var X15 = Convert.ToString(Equivalencias.Chr(2)) + "RN";
            var X16 = Convert.ToString(Equivalencias.Chr(2)) + "Kf0000";
            var X17 = Convert.ToString(Equivalencias.Chr(2)) + "V0";
            var X18 = Convert.ToString(Equivalencias.Chr(2)) + "M0500";
            var X19 = Convert.ToString(Equivalencias.Chr(2)) + "L";
            var X20 = "A2";
            var X21 = "D11";
            var X22 = "z";
            var X23 = "PD";
            var X24 = "SD";
            var X25 = "H01";

            var X77 = "^01";
            var X88 = "Q0001";
            var X99 = "E";

            var TW101 = "4911S000014002000280018";
            var TW102 = "4911S000014003400230020";
            var TW103 = "4911S000101003400230018";
            var TW104 = "4911S000014005000230016";
            var TW105 = "4o2203400130085";
            var TW106 = "4911S000060009900340034";
            var TW107 = "4911S000014011200230018";
            var TW108 = "4911S000014012800230018";
            var TW109 = "4911S000014014200230018";
            var TW110 = "4911S000014017100230018";
            var TW111 = "4911S000109014300230020";
            var TW112 = "4911S000014015700230018";
            var TW113 = "4911S000109015700230018";
            var TW114 = "4911S000104018000390040";
            var TW115 = "4911S000014018600230018";

            var TW201 = "4911S000014022900280018";
            var TW202 = "4911S000014024300230020";
            var TW203 = "4911S000101024300230018";
            var TW204 = "4911S000014025900230016";
            var TW205 = "4o2203400130294";
            var TW206 = "4911S000060030800340034";
            var TW207 = "4911S000014032100230018";
            var TW208 = "4911S000014033600230018";
            var TW209 = "4911S000014035100230018";
            var TW210 = "4911S000014038000230018";
            var TW211 = "4911S000109035100230020";
            var TW212 = "4911S000014036600230018";
            var TW213 = "4911S000109036600230018";
            var TW214 = "4911S000104038900390040";
            var TW215 = "4911S000014039500230018";


            var pTEXTO = string.Empty;
            var xStick = 0;
            var xComa = string.Empty;

            xStick = xStick + 1;

            foreach (DataRow fila in dt.Rows)
            {
                var xTW01 = string.Empty;
                var xTW02 = string.Empty;
                var xTW03 = string.Empty;
                var xTW04 = string.Empty;
                var xTW05 = string.Empty;
                var xTW06 = string.Empty;
                var xTW07 = string.Empty;
                var xTW08 = string.Empty;
                var xTW09 = string.Empty;
                var xTW10 = string.Empty;
                var xTW11 = string.Empty;
                var xTW12 = string.Empty;
                var xTW13 = string.Empty;
                var xTW14 = string.Empty;
                var xTW15 = string.Empty;

                xTW01 = fila["productid"].ToString() + " " + fila["etiquetaname"].ToString().PadRight(30, ' ').Substring(0, 30).Trim() + xComa;
                xTW02 = "ART: " + fila["subgrupoartic"].ToString().PadRight(10, ' ').Substring(0, 10).Trim() + xComa;
                if (fila["rollolote"].ToString().Trim().Length > 0)
                {
                    xTW03 = "LOTE...: " + fila["rollolote"].ToString().PadRight(10, ' ').Substring(0, 10).Trim() + xComa;
                }
                else
                {
                    xTW03 = string.Empty + xComa;
                }
                if (fila["compo"].ToString().Trim().Length > 0)
                {
                    xTW04 = "COMPOS: " + fila["compo"].ToString().PadRight(10, ' ').Substring(0, 10).Trim() + xComa;
                }
                else
                {
                    xTW04 = string.Empty + xComa;
                }
                fila["rollostock"].ToString().Replace(".", string.Empty);
                xTW05 = fila["rollo"].ToString() + Convert.ToDecimal(fila["rollostock"].ToString().Replace(".", string.Empty)).ToString().Trim().PadLeft(5, '0') + xComa;
                xTW06 = fila["rollo"].ToString() + Convert.ToDecimal(fila["rollostock"].ToString().Replace(".", string.Empty)).ToString("00000").Trim().PadLeft(5, '0') + xComa;
                xTW07 = "PROVE: " + fila["gruponame"].ToString().PadRight(30, ' ').Substring(0, 30).Trim() + xComa;
                xTW08 = "CLIEN: " + VariablesPublicas.EmpresaName.ToString().PadRight(30, ' ').Substring(0, 30).Trim() + xComa;
                xTW09 = "ROLLO: " + fila["rollo"].ToString().Trim() + xComa;
                xTW10 = "ONZAJ: " + fila["titulo"].ToString().Trim() + xComa;
                xTW11 = "MED.INICI: " + Convert.ToDecimal(fila["rollomedcompra"].ToString()).ToString("##0.00").Trim() + xComa;
                xTW12 = "COLOR: " + fila["colorname"].ToString().PadRight(10, ' ').Substring(0, 10).Trim() + xComa;
                xTW13 = "MED.DESPA: " + Convert.ToDecimal(fila["rolloegres"].ToString()).ToString("##0.00").Trim() + xComa;
                xTW14 = Convert.ToDecimal(fila["rollostock"].ToString()).ToString("##0.00").Trim() + xComa;
                xTW15 = DateTime.Today.Date.ToString().Substring(0, 10);

                switch (xStick)
                {
                    case 1:
                        pTEXTO = pTEXTO + X11 + CRTLF;
                        pTEXTO = pTEXTO + X12 + CRTLF;
                        pTEXTO = pTEXTO + X13 + CRTLF;
                        pTEXTO = pTEXTO + X14 + CRTLF;
                        pTEXTO = pTEXTO + X15 + CRTLF;
                        pTEXTO = pTEXTO + X16 + CRTLF;
                        pTEXTO = pTEXTO + X17 + CRTLF;
                        pTEXTO = pTEXTO + X18 + CRTLF;
                        pTEXTO = pTEXTO + X19 + CRTLF;
                        pTEXTO = pTEXTO + X20 + CRTLF;
                        pTEXTO = pTEXTO + X21 + CRTLF;
                        pTEXTO = pTEXTO + X22 + CRTLF;
                        pTEXTO = pTEXTO + X23 + CRTLF;
                        pTEXTO = pTEXTO + X24 + CRTLF;
                        pTEXTO = pTEXTO + X25 + CRTLF;

                        pTEXTO = pTEXTO + TW101 + xTW01 + CRTLF;
                        pTEXTO = pTEXTO + TW102 + xTW02 + CRTLF;
                        pTEXTO = pTEXTO + TW103 + xTW03 + CRTLF;
                        pTEXTO = pTEXTO + TW104 + xTW04 + CRTLF;
                        pTEXTO = pTEXTO + TW105 + xTW05 + CRTLF;
                        pTEXTO = pTEXTO + TW106 + xTW06 + CRTLF;
                        pTEXTO = pTEXTO + TW107 + xTW07 + CRTLF;
                        pTEXTO = pTEXTO + TW108 + xTW08 + CRTLF;
                        pTEXTO = pTEXTO + TW109 + xTW09 + CRTLF;
                        pTEXTO = pTEXTO + TW110 + xTW10 + CRTLF;
                        pTEXTO = pTEXTO + TW111 + xTW11 + CRTLF;
                        pTEXTO = pTEXTO + TW112 + xTW12 + CRTLF;
                        pTEXTO = pTEXTO + TW113 + xTW13 + CRTLF;
                        pTEXTO = pTEXTO + TW114 + xTW14 + CRTLF;
                        pTEXTO = pTEXTO + TW115 + xTW15 + CRTLF;
                        xStick = xStick + 1;
                        break;
                    case 2:
                        pTEXTO = pTEXTO + TW201 + xTW01 + CRTLF;
                        pTEXTO = pTEXTO + TW202 + xTW02 + CRTLF;
                        pTEXTO = pTEXTO + TW203 + xTW03 + CRTLF;
                        pTEXTO = pTEXTO + TW204 + xTW04 + CRTLF;
                        pTEXTO = pTEXTO + TW205 + xTW05 + CRTLF;
                        pTEXTO = pTEXTO + TW206 + xTW06 + CRTLF;
                        pTEXTO = pTEXTO + TW207 + xTW07 + CRTLF;
                        pTEXTO = pTEXTO + TW208 + xTW08 + CRTLF;
                        pTEXTO = pTEXTO + TW209 + xTW09 + CRTLF;
                        pTEXTO = pTEXTO + TW210 + xTW10 + CRTLF;
                        pTEXTO = pTEXTO + TW211 + xTW11 + CRTLF;
                        pTEXTO = pTEXTO + TW212 + xTW12 + CRTLF;
                        pTEXTO = pTEXTO + TW213 + xTW13 + CRTLF;
                        pTEXTO = pTEXTO + TW214 + xTW14 + CRTLF;
                        pTEXTO = pTEXTO + TW215 + xTW15 + CRTLF;

                        pTEXTO = pTEXTO + X77 + CRTLF;
                        pTEXTO = pTEXTO + X88 + CRTLF;
                        pTEXTO = pTEXTO + X99 + CRTLF;


                        xStick = 1;
                        break;
                }
            }
            if (xStick == 2)
            {
                pTEXTO = pTEXTO + X77 + CRTLF;
                pTEXTO = pTEXTO + X88 + CRTLF;
                pTEXTO = pTEXTO + X99 + CRTLF;
            }

            try
            {
                if (File.Exists(@"C:\\reportebarcode.txt"))
                {
                    File.Delete(@"C:\\reportebarcode.txt");
                }

                var escritor = new StreamWriter(@"C:\\reportebarcode.txt");
                escritor.WriteLine(pTEXTO);
                escritor.Close();

                try
                {
                    var buffer = new byte[pTEXTO.Length];
                    buffer = System.Text.Encoding.ASCII.GetBytes(pTEXTO);


                    var printer = CreateFile("LPT1:", FileAccess.Write, 0, IntPtr.Zero, FileMode.OpenOrCreate, 0, IntPtr.Zero);
                    if (!printer.IsInvalid)
                    {
                        var lpt1 = new FileStream(printer, FileAccess.ReadWrite);
                        lpt1.Write(buffer, 0, buffer.Length);
                        lpt1.Close();
                    }
                }
                catch (Exception ex)
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString());
            }
        }


        public static void ReceiveCallback(IAsyncResult AsyncCall)
        {
            var encoding = new System.Text.ASCIIEncoding();
            var message = encoding.GetBytes("I am a little busy, come back later!");

            var listener = (Socket)AsyncCall.AsyncState;
            var client = listener.EndAccept(AsyncCall);

            Console.WriteLine("Received Connection from {0}", client.RemoteEndPoint);
            client.Send(message);

            Console.WriteLine("Ending the connection");
            client.Close();

            listener.BeginAccept(new AsyncCallback(ReceiveCallback), listener);
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void rollolote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rolloancho.Focus();
            }
        }

        private void rolloancho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rollomedcompra.Focus();
            }
        }

        private void rolloencog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tipofallasid.Focus();
            }
        }

        private void tipofallasid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rollovaloractual.Focus();
            }
        }

        private void rollovaloractual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rollomedcompra.Focus();
            }
        }

        private void rollomedcompra_KeyDown(object sender, KeyEventArgs e)
        {
            var sw_prosigue = false;

            if (e.KeyCode == Keys.Enter)
            {
                sw_prosigue = (MessageBox.Show("¿Desea Grabar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                if (sw_prosigue)
                {
                    btn_grabar_Click(sender, e);
                }
            }
        }

        private void txt_criterio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_busqueda_Click(sender, e);
            }
        }

        private void rollodesde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rollohasta.Focus();
            }
        }

        private void rollohasta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_busqueda_Click(sender, e);
            }
        }

        private void gridproductorollo_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txt_metraje_TextChanged(object sender, EventArgs e)
        {
        }

        private void rollo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                form_cargar_datos(string.Empty);
            }
        }
    }
}
