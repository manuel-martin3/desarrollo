using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.D20Comercial
{
    public partial class Frm_Pedido : plantilla
    {
        private String EmpresaID = string.Empty;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;
        private String XNIVEL = string.Empty;
        private String PERFILID = string.Empty;
        private String XGLOSA = string.Empty;
        private DataTable TabladetallePedido, TabladetallePedido2;
        private DataRow row;

        private String ssModo = "NEW";

        public Frm_Pedido()
        {
            InitializeComponent();
            ctacte.LostFocus += new System.EventHandler(ctacte_LostFocus);
            numdoc.LostFocus += new System.EventHandler(numdoc_LostFocus);
        }

        private void PARAMETROS_TABLA()
        {
            var xxferfil = string.Empty;
            var f = (D20Comercial.MainComercial)MdiParent;
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

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData )
        {
            if (keyData == Keys.Enter)
            {
                SendKeys.Send("\t");
                return true;
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

        private void RecibeClientes(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                ctacte.Text = resultado1.Trim();
            }
        }

        private void ctacte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaClientes(string.Empty);
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

        private void nmruc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaClientes(string.Empty);
            }
        }

        private void Frm_Pedido_Load(object sender, EventArgs e)
        {
            EmpresaID = VariablesPublicas.EmpresaID;
            PARAMETROS_TABLA();
            limpiar_documento();
            get_CanalVenta();
            form_bloqueado(false);
            serdoc.Text = VariablesPublicas.perianio;


            TabladetallePedido2 = new DataTable("detallepedido2");
            TabladetallePedido2.Columns.Add("colorid", typeof(String));
            TabladetallePedido2.Columns.Add("prop01", typeof(Decimal));
            TabladetallePedido2.Columns["prop01"].DefaultValue = 0;
            TabladetallePedido2.Columns.Add("prop02", typeof(Decimal));
            TabladetallePedido2.Columns["prop02"].DefaultValue = 0;
            TabladetallePedido2.Columns.Add("prop03", typeof(Decimal));
            TabladetallePedido2.Columns["prop03"].DefaultValue = 0;
            TabladetallePedido2.Columns.Add("prop04", typeof(Decimal));
            TabladetallePedido2.Columns["prop04"].DefaultValue = 0;
            TabladetallePedido2.Columns.Add("prop05", typeof(Decimal));
            TabladetallePedido2.Columns["prop05"].DefaultValue = 0;
            TabladetallePedido2.Columns.Add("prop06", typeof(Decimal));
            TabladetallePedido2.Columns["prop06"].DefaultValue = 0;
            TabladetallePedido2.Columns.Add("prop07", typeof(Decimal));
            TabladetallePedido2.Columns["prop07"].DefaultValue = 0;
            TabladetallePedido2.Columns.Add("prop08", typeof(Decimal));
            TabladetallePedido2.Columns["prop08"].DefaultValue = 0;
            TabladetallePedido2.Columns.Add("prop09", typeof(Decimal));
            TabladetallePedido2.Columns["prop09"].DefaultValue = 0;
            TabladetallePedido2.Columns.Add("prop10", typeof(Decimal));
            TabladetallePedido2.Columns["prop10"].DefaultValue = 0;
            TabladetallePedido2.Columns.Add("prop11", typeof(Decimal));
            TabladetallePedido2.Columns["prop11"].DefaultValue = 0;
            TabladetallePedido2.Columns.Add("prop12", typeof(Decimal));
            TabladetallePedido2.Columns["prop12"].DefaultValue = 0;
            TabladetallePedido2.Columns.Add("panios", typeof(Decimal));
            TabladetallePedido2.Columns["panios"].DefaultValue = 0;
            TabladetallePedido2.Columns.Add("cantot", typeof(Decimal));
            TabladetallePedido2.Columns["cantot"].DefaultValue = 0;
            TabladetallePedido2.Columns.Add("cpromxpda", typeof(Decimal));
            TabladetallePedido2.Columns["cpromxpda"].DefaultValue = 0;
            TabladetallePedido2.Columns.Add("observacion", typeof(String));

            TabladetallePedido2.Columns.Add("talla01", typeof(String));
            TabladetallePedido2.Columns.Add("talla02", typeof(String));
            TabladetallePedido2.Columns.Add("talla03", typeof(String));
            TabladetallePedido2.Columns.Add("talla04", typeof(String));
            TabladetallePedido2.Columns.Add("talla05", typeof(String));
            TabladetallePedido2.Columns.Add("talla06", typeof(String));
            TabladetallePedido2.Columns.Add("talla07", typeof(String));
            TabladetallePedido2.Columns.Add("talla08", typeof(String));
            TabladetallePedido2.Columns.Add("talla09", typeof(String));
            TabladetallePedido2.Columns.Add("talla10", typeof(String));
            TabladetallePedido2.Columns.Add("talla11", typeof(String));
            TabladetallePedido2.Columns.Add("talla12", typeof(String));

            TabladetallePedido = new DataTable("detallepedido");
            TabladetallePedido.Columns.Add("op", typeof(String));
            TabladetallePedido.Columns.Add("telaid", typeof(String));
            TabladetallePedido.Columns.Add("telaname", typeof(String));
            TabladetallePedido.Columns.Add("articidold", typeof(String));
            TabladetallePedido.Columns.Add("articid", typeof(String));
            TabladetallePedido.Columns.Add("colorid", typeof(String));
            TabladetallePedido.Columns.Add("prop01", typeof(Decimal));
            TabladetallePedido.Columns["prop01"].DefaultValue = 0;
            TabladetallePedido.Columns.Add("prop02", typeof(Decimal));
            TabladetallePedido.Columns["prop02"].DefaultValue = 0;
            TabladetallePedido.Columns.Add("prop03", typeof(Decimal));
            TabladetallePedido.Columns["prop03"].DefaultValue = 0;
            TabladetallePedido.Columns.Add("prop04", typeof(Decimal));
            TabladetallePedido.Columns["prop04"].DefaultValue = 0;
            TabladetallePedido.Columns.Add("prop05", typeof(Decimal));
            TabladetallePedido.Columns["prop05"].DefaultValue = 0;
            TabladetallePedido.Columns.Add("prop06", typeof(Decimal));
            TabladetallePedido.Columns["prop06"].DefaultValue = 0;
            TabladetallePedido.Columns.Add("prop07", typeof(Decimal));
            TabladetallePedido.Columns["prop07"].DefaultValue = 0;
            TabladetallePedido.Columns.Add("prop08", typeof(Decimal));
            TabladetallePedido.Columns["prop08"].DefaultValue = 0;
            TabladetallePedido.Columns.Add("prop09", typeof(Decimal));
            TabladetallePedido.Columns["prop09"].DefaultValue = 0;
            TabladetallePedido.Columns.Add("prop10", typeof(Decimal));
            TabladetallePedido.Columns["prop10"].DefaultValue = 0;
            TabladetallePedido.Columns.Add("prop11", typeof(Decimal));
            TabladetallePedido.Columns["prop11"].DefaultValue = 0;
            TabladetallePedido.Columns.Add("prop12", typeof(Decimal));
            TabladetallePedido.Columns["prop12"].DefaultValue = 0;
            TabladetallePedido.Columns.Add("panios", typeof(Decimal));
            TabladetallePedido.Columns["panios"].DefaultValue = 0;
            TabladetallePedido.Columns.Add("cantot", typeof(Decimal));
            TabladetallePedido.Columns["cantot"].DefaultValue = 0;
            TabladetallePedido.Columns.Add("cpromxpda", typeof(Decimal));
            TabladetallePedido.Columns["cpromxpda"].DefaultValue = 0;
            TabladetallePedido.Columns.Add("observacion", typeof(String));
            TabladetallePedido.Columns.Add("tip_op", typeof(String));
            TabladetallePedido.Columns.Add("num_op", typeof(String));
            TabladetallePedido.Columns.Add("articname", typeof(String));

            TabladetallePedido.Columns.Add("talla01", typeof(String));
            TabladetallePedido.Columns.Add("talla02", typeof(String));
            TabladetallePedido.Columns.Add("talla03", typeof(String));
            TabladetallePedido.Columns.Add("talla04", typeof(String));
            TabladetallePedido.Columns.Add("talla05", typeof(String));
            TabladetallePedido.Columns.Add("talla06", typeof(String));
            TabladetallePedido.Columns.Add("talla07", typeof(String));
            TabladetallePedido.Columns.Add("talla08", typeof(String));
            TabladetallePedido.Columns.Add("talla09", typeof(String));
            TabladetallePedido.Columns.Add("talla10", typeof(String));
            TabladetallePedido.Columns.Add("talla11", typeof(String));
            TabladetallePedido.Columns.Add("talla12", typeof(String));

            btn_nuevo.Enabled = true;
            btn_salir.Enabled = true;
        }

        private void limpiar_documento()
        {
            try
            {
                fechdoc.Value = DateTime.Today;
                fechentrega.Value = DateTime.Today;
                ctacte.Text = string.Empty;
                ctactename.Text = string.Empty;
                glosa.Text = string.Empty;

                tela_id.Text = string.Empty;
                tela_name.Text = string.Empty;
                artic_idold.Text = string.Empty;
                artic_name.Text = string.Empty;

                cboCanalventa.SelectedIndex = -1;

                data_TabladetallePedido();

                data_TabladetallePedido2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevo()
        {
            limpiar_documento();
            get_autoCS_numPedido();
            form_bloqueado(true);
            btn_imprimir.Enabled = true;
            btn_cancelar.Enabled = true;

            if (TabladetallePedido2 != null)
            {
                TabladetallePedido2.Clear();
            }

            if (TabladetallePedido != null)
            {
                TabladetallePedido.Clear();
            }
            ssModo = "NEW";
        }

        private void form_bloqueado(Boolean var)
        {
            try
            {
                ctacte.Enabled = var;
                ctactename.Enabled = false;

                fechdoc.Enabled = false;
                fechentrega.Enabled = var;
                serdoc.Enabled = false;
                tipdoc.Enabled = false;

                tip_op.Enabled = false;
                ser_op.Enabled = false;
                num_op.Enabled = false;

                tela_id.Enabled = var;
                tela_name.Enabled = false;
                artic_idold.Enabled = var;
                artic_name.Enabled = false;

                glosa.Enabled = var;
                cboCanalventa.Enabled = var;
                btn_nuevo.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_imprimir.Enabled = false;
                btn_salir.Enabled = false;
                btn_grabar.Enabled = false;
                btn_fijar.Enabled = var;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void get_CanalVenta()
        {
            try
            {
                var BL = new tb_CanalVentaBL();
                var BE = new tb_CanalVenta();

                var dt = new DataTable();

                dt = BL.GetAll(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    cboCanalventa.DataSource = dt;
                    cboCanalventa.ValueMember = "canalventaid";
                    cboCanalventa.DisplayMember = "canalventaname";
                }
                else
                {
                    MessageBox.Show("No Existe Canal de Venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {
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
        }

        private void Insert()
        {
            try
            {
                if (ctacte.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Proveedor/Cliente !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (TabladetallePedido.Rows.Count == 0)
                    {
                        MessageBox.Show("Documento no tiene Items !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (numdoc.Text.Trim().Length == 10)
                        {
                            var BL = new tb_60movimientosBL();
                            var BE = new tb_60movimientos();

                            var Detalle = new tb_60movimientos.Item();
                            var ListaItems = new List<tb_60movimientos.Item>();

                            BE.dominioid = dominio;
                            BE.moduloid = modulo;
                            BE.local = local;
                            BE.tipodoc = tipdoc.Text.ToString();
                            BE.serdoc = serdoc.Text.Trim();
                            BE.numdoc = numdoc.Text.ToString();
                            BE.fechdoc = Convert.ToDateTime(fechdoc.Text);
                            BE.ctacteaccionid = string.Empty;
                            BE.ctacte = ctacte.Text.Trim().ToUpper();
                            BE.ctactename = ctactename.Text.Trim().ToUpper();

                            if (ser_op.Text.Trim().Length > 0 && num_op.Text.Trim().Length > 0)
                            {
                                BE.tip_op = "OP";
                                BE.ser_op = ser_op.Text.Trim().PadLeft(4, '0');
                                BE.num_op = num_op.Text.Trim().PadLeft(10, '0');
                            }

                            BE.codctadebe = string.Empty;
                            BE.codctahaber = string.Empty;
                            BE.glosa = glosa.Text.Trim().ToUpper().ToString();
                            try
                            {
                                BE.fechentrega = Convert.ToDateTime(fechentrega.Text.Trim());
                            }
                            catch
                            {
                                BE.fechentrega = Convert.ToDateTime("01/01/1900");
                            }


                            Detalle.perianio = fechdoc.Value.Year.ToString();
                            Detalle.perimes = fechdoc.Value.Month.ToString().PadLeft(2, '0');
                            Detalle.status = "0";
                            Detalle.usuar = VariablesPublicas.Usuar;

                            var item = 0;
                            foreach (DataRow fila in TabladetallePedido.Rows)
                            {
                                Detalle = new tb_60movimientos.Item();

                                item++;

                                Detalle.fechdoc = Convert.ToDateTime(fechdoc.Text);
                                Detalle.ctacteaccionid = string.Empty;
                                Detalle.ctacte = ctacte.Text.Trim().ToUpper();
                                Detalle.ctactename = ctactename.Text.Trim().ToUpper();
                                if (ser_op.Text.Trim().Length > 0 && num_op.Text.Trim().Length > 0)
                                {
                                    Detalle.tip_op = "OP";
                                    Detalle.ser_op = ser_op.Text.Trim().PadLeft(4, '0');
                                    Detalle.num_op = num_op.Text.Trim().PadLeft(10, '0');
                                }

                                Detalle.itemref = fila["itemref"].ToString();
                                Detalle.itemsdet = item.ToString().PadLeft(5, '0');
                                Detalle.rollo = fila["rollo"].ToString();
                                Detalle.productid = fila["productid"].ToString();
                                Detalle.productname = fila["productname"].ToString();
                                Detalle.Ubicacion = fila["ubicacion"].ToString();

                                Detalle.cantidad = Convert.ToDecimal(fila["cantidad"].ToString());

                                Detalle.valor = Convert.ToDecimal(fila["valor"].ToString());
                                Detalle.importe = Convert.ToDecimal(fila["importe"].ToString());

                                Detalle.precunit = Convert.ToDecimal(fila["precunit"].ToString());
                                Detalle.importfac = Convert.ToDecimal(fila["importfac"].ToString());

                                Detalle.totimpto = Convert.ToDecimal(fila["totimpto"].ToString());

                                Detalle.almacaccionid = fila["almacaccionid"].ToString();
                                Detalle.glosa = glosa.Text.Trim().ToUpper().ToString();
                                Detalle.codctadebe = string.Empty;
                                Detalle.codctahaber = string.Empty;

                                Detalle.perianio = fechdoc.Value.Year.ToString();
                                Detalle.perimes = fechdoc.Value.Month.ToString().PadLeft(2, '0');
                                Detalle.status = "0";
                                Detalle.usuar = VariablesPublicas.Usuar;

                                if (fila["productid"].ToString().Trim().Length == 13 && Convert.ToDecimal(fila["cantidad"]) > 0 && Convert.ToDecimal(fila["importfac"]) > 0)
                                {
                                    ListaItems.Add(Detalle);
                                }
                                else
                                {
                                    MessageBox.Show("Documento DETALLE EN FORMATO INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
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
                                NIVEL_FORMS();
                                MessageBox.Show("Datos grabados correctamente !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                form_bloqueado(false);
                                tipdoc.Enabled = false;

                                btn_nuevo.Enabled = true;
                                btn_imprimir.Enabled = true;
                                btn_salir.Enabled = true;
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

        private void Frm_Pedido_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btn_grabar.Enabled)
            {
                MessageBox.Show("Finalice edición para cerrar formulario", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void form_cargar_datos(String posicion)
        {
            try
            {
                limpiar_documento();
                var BL = new tb_cp_comercialcabBL();
                var BE = new tb_cp_comercialcab();
                var dt = new DataTable();

                BE.moduloid = modulo;
                BE.local = local;
                BE.tipdoc = tipdoc.Text;
                BE.serdoc = serdoc.Text.Trim().PadLeft(4, '0');
                if (numdoc.Text.Trim().Length > 0)
                {
                    BE.numdoc = numdoc.Text.Trim().PadLeft(10, '0');
                }

                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    ssModo = "EDIT";
                    serdoc.Text = dt.Rows[0]["serdoc"].ToString().Trim();
                    numdoc.Text = dt.Rows[0]["numdoc"].ToString().Trim();
                    fechdoc.Text = dt.Rows[0]["fechdoc"].ToString().Trim();
                    ctacte.Text = dt.Rows[0]["ctacte"].ToString().Trim();
                    ctactename.Text = dt.Rows[0]["ctactename"].ToString().Trim();
                    cboCanalventa.SelectedValue = dt.Rows[0]["canalventaid"].ToString().Trim();

                    if (dt.Rows[0]["fechentrega"].ToString().Trim().Substring(0, 10) != "01/01/1900")
                    {
                        fechentrega.Format = DateTimePickerFormat.Short;
                        fechentrega.Text = dt.Rows[0]["fechentrega"].ToString().Trim();
                    }
                    glosa.Text = dt.Rows[0]["observacion"].ToString().Trim();

                    data_TabladetallePedido();
                    if (dt.Rows[0]["status"].ToString().Trim() != "9")
                    {
                        btn_editar.Enabled = true;
                        btn_eliminar.Enabled = true;
                        btn_imprimir.Enabled = true;
                        btn_attachedfile.Enabled = true;

                        btn_salir.Enabled = true;
                        griddetallepedido.Focus();
                        griddetallepedido.Rows[0].Selected = false;
                        ;
                    }
                    else
                    {
                        ssModo = "ANULADO";
                        btn_editar.Enabled = false;
                        btn_eliminar.Enabled = false;
                        btn_imprimir.Enabled = true;
                        btn_salir.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void data_TabladetallePedido()
        {
            try
            {
                griddetallepedido.AutoGenerateColumns = false;
                var BL = new tb_cp_comercialdetBL();
                var BE = new tb_cp_comercialdet();

                var dt = new DataTable();

                BE.moduloid = modulo;
                BE.local = local;
                BE.tipdoc = tipdoc.Text.ToString().Trim();
                BE.serdoc = serdoc.Text.Trim().PadLeft(4, '0');
                BE.numdoc = numdoc.Text.Trim().PadLeft(6, '0');

                dt = BL.GetAll_datosdetalle(EmpresaID, BE).Tables[0];

                if (TabladetallePedido2 != null)
                {
                    TabladetallePedido2.Clear();
                }


                if (TabladetallePedido != null)
                {
                    TabladetallePedido.Clear();
                }

                foreach (DataRow fila in dt.Rows)
                {
                    row = TabladetallePedido.NewRow();
                    row["op"] = fila["ser_op"].ToString() + "-" + Equivalencias.Right(fila["num_op"].ToString(), 5);
                    row["telaid"] = fila["telaid"].ToString();
                    row["telaname"] = fila["telaname"].ToString();
                    row["articidold"] = fila["articidold"].ToString();
                    row["articid"] = fila["articid"].ToString();
                    row["colorid"] = fila["colorid"].ToString();
                    row["prop01"] = fila["prop01"].ToString();
                    row["prop02"] = fila["prop02"].ToString();
                    row["prop03"] = fila["prop03"].ToString();
                    row["prop04"] = fila["prop04"].ToString();
                    row["prop05"] = fila["prop05"].ToString();
                    row["prop06"] = fila["prop06"].ToString();
                    row["prop07"] = fila["prop07"].ToString();
                    row["prop08"] = fila["prop08"].ToString();
                    row["prop09"] = fila["prop09"].ToString();
                    row["prop10"] = fila["prop10"].ToString();
                    row["prop11"] = fila["prop11"].ToString();
                    row["prop12"] = fila["prop12"].ToString();
                    row["panios"] = fila["panios"].ToString();
                    row["cantot"] = fila["cantot"].ToString();
                    row["cpromxpda"] = fila["cpromxpda"].ToString();
                    row["observacion"] = fila["observacion"].ToString();

                    row["tip_op"] = fila["tip_op"].ToString();
                    row["num_op"] = fila["num_op"].ToString();
                    row["articname"] = fila["articname"].ToString();


                    row["talla01"] = fila["talla01"].ToString();
                    row["talla02"] = fila["talla02"].ToString();
                    row["talla03"] = fila["talla03"].ToString();
                    row["talla04"] = fila["talla04"].ToString();
                    row["talla05"] = fila["talla05"].ToString();
                    row["talla06"] = fila["talla06"].ToString();
                    row["talla07"] = fila["talla07"].ToString();
                    row["talla08"] = fila["talla08"].ToString();
                    row["talla09"] = fila["talla09"].ToString();
                    row["talla10"] = fila["talla10"].ToString();
                    row["talla11"] = fila["talla11"].ToString();
                    row["talla12"] = fila["talla12"].ToString();


                    TabladetallePedido.Rows.Add(row);
                }

                griddetallepedido.DataSource = TabladetallePedido;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void data_TabladetallePedido2()
        {
            try
            {
                griddetallepedido2.AutoGenerateColumns = false;

                var BL = new tb_cp_comercialdetBL();
                var BE = new tb_cp_comercialdet();

                var dt = new DataTable();

                BE.moduloid = modulo;
                BE.local = local;
                BE.tipdoc = tipdoc.Text.ToString().Trim();
                BE.serdoc = serdoc.Text.Trim().PadLeft(4, '0');
                BE.numdoc = numdoc.Text.Trim().PadLeft(6, '0');

                dt = BL.GetAll_datosdetalle(EmpresaID, BE).Tables[0];

                if (TabladetallePedido2 != null)
                {
                    TabladetallePedido2.Clear();
                }


                if (TabladetallePedido != null)
                {
                    TabladetallePedido.Clear();
                }

                foreach (DataRow fila in dt.Rows)
                {
                    row = TabladetallePedido2.NewRow();

                    row["colorid"] = fila["colorid"].ToString();
                    row["prop01"] = fila["prop01"].ToString();
                    row["prop02"] = fila["prop02"].ToString();
                    row["prop03"] = fila["prop03"].ToString();
                    row["prop04"] = fila["prop04"].ToString();
                    row["prop05"] = fila["prop05"].ToString();
                    row["prop06"] = fila["prop06"].ToString();
                    row["prop07"] = fila["prop07"].ToString();
                    row["prop08"] = fila["prop08"].ToString();
                    row["prop09"] = fila["prop09"].ToString();
                    row["prop10"] = fila["prop10"].ToString();
                    row["prop11"] = fila["prop11"].ToString();
                    row["prop12"] = fila["prop12"].ToString();
                    row["panios"] = fila["panios"].ToString();
                    row["cantot"] = fila["cantot"].ToString();
                    row["cpromxpda"] = fila["cpromxpda"].ToString();
                    row["observacion"] = fila["observacion"].ToString();

                    row["talla01"] = fila["talla01"].ToString();
                    row["talla02"] = fila["talla02"].ToString();
                    row["talla03"] = fila["talla03"].ToString();
                    row["talla04"] = fila["talla04"].ToString();
                    row["talla05"] = fila["talla05"].ToString();
                    row["talla06"] = fila["talla06"].ToString();
                    row["talla07"] = fila["talla07"].ToString();
                    row["talla08"] = fila["talla08"].ToString();
                    row["talla09"] = fila["talla09"].ToString();
                    row["talla10"] = fila["talla10"].ToString();
                    row["talla11"] = fila["talla11"].ToString();
                    row["talla12"] = fila["talla12"].ToString();

                    TabladetallePedido2.Rows.Add(row);
                }

                griddetallepedido2.DataSource = TabladetallePedido2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void numdoc_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void numdoc_LostFocus(object sender, System.EventArgs e)
        {
            form_cargar_datos(string.Empty);
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            numdoc.Text = string.Empty;
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
                tipdoc.Enabled = false;
                limpiar_documento();
                form_bloqueado(false);
                btn_nuevo.Enabled = true;
                ssModo = "NEW";
            }
        }

        private void griddetallepedido_KeyUp(object sender, KeyEventArgs e)
        {
            for (var i = 5; i <= 16; i++)
            {
                griddetallepedido.Columns[i].HeaderText = griddetallepedido.CurrentRow.Cells[i + 20].Value.ToString();
            }
        }

        private void Frm_Pedido_KeyDown(object sender, KeyEventArgs e)
        {
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

            if (e.KeyCode == Keys.Insert)
            {
                if (!griddetallepedido2.ReadOnly)
                {
                    btn_add_Click(sender, e);
                }
            }

            if (e.KeyCode == Keys.Insert)
            {
                if (!griddetallepedido2.ReadOnly)
                {
                    btn_add_Click(sender, e);
                }
            }


            if (e.KeyCode == Keys.Insert)
            {
                if (!griddetallepedido2.ReadOnly)
                {
                    btn_delete_Click(sender, e);
                }
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quieres cerrar el formulario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void griddetallepedido_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            griddetallepedido[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }

        private void griddetallepedido_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ser_op.Text = Equivalencias.Left(griddetallepedido.CurrentRow.Cells[0].Value.ToString(), 4);
            tela_id.Text = griddetallepedido.CurrentRow.Cells[1].Value.ToString();
            tela_name.Text = griddetallepedido.CurrentRow.Cells[2].Value.ToString();
            artic_idold.Text = griddetallepedido.CurrentRow.Cells[3].Value.ToString();

            tip_op.Text = griddetallepedido.CurrentRow.Cells[22].Value.ToString();
            num_op.Text = griddetallepedido.CurrentRow.Cells[23].Value.ToString();
            artic_name.Text = griddetallepedido.CurrentRow.Cells[24].Value.ToString();


            if (TabladetallePedido2 != null)
            {
                TabladetallePedido2.Clear();
            }

            foreach (DataGridViewRow fila in griddetallepedido.Rows)
            {
                var op = griddetallepedido.CurrentRow.Cells[0].Value.ToString();
                if (Convert.ToString(griddetallepedido.Rows[fila.Index].Cells["op"].Value) == op)
                {
                    row = TabladetallePedido2.NewRow();

                    row["colorid"] = griddetallepedido.Rows[fila.Index].Cells["colorid"].Value;
                    row["prop01"] = griddetallepedido.Rows[fila.Index].Cells["prop01"].Value;
                    row["prop02"] = griddetallepedido.Rows[fila.Index].Cells["prop02"].Value;
                    row["prop03"] = griddetallepedido.Rows[fila.Index].Cells["prop03"].Value;
                    row["prop04"] = griddetallepedido.Rows[fila.Index].Cells["prop04"].Value;
                    row["prop05"] = griddetallepedido.Rows[fila.Index].Cells["prop05"].Value;
                    row["prop06"] = griddetallepedido.Rows[fila.Index].Cells["prop06"].Value;
                    row["prop07"] = griddetallepedido.Rows[fila.Index].Cells["prop07"].Value;
                    row["prop08"] = griddetallepedido.Rows[fila.Index].Cells["prop08"].Value;
                    row["prop09"] = griddetallepedido.Rows[fila.Index].Cells["prop09"].Value;
                    row["prop10"] = griddetallepedido.Rows[fila.Index].Cells["prop10"].Value;
                    row["prop11"] = griddetallepedido.Rows[fila.Index].Cells["prop11"].Value;
                    row["prop12"] = griddetallepedido.Rows[fila.Index].Cells["prop12"].Value;
                    row["panios"] = griddetallepedido.Rows[fila.Index].Cells["panios"].Value;
                    row["cantot"] = griddetallepedido.Rows[fila.Index].Cells["cantot"].Value;
                    row["cpromxpda"] = griddetallepedido.Rows[fila.Index].Cells["cpromxpda"].Value;
                    row["observacion"] = griddetallepedido.Rows[fila.Index].Cells["observacion"].Value;

                    row["talla01"] = griddetallepedido.Rows[fila.Index].Cells["talla01"].Value;
                    row["talla02"] = griddetallepedido.Rows[fila.Index].Cells["talla02"].Value;
                    row["talla03"] = griddetallepedido.Rows[fila.Index].Cells["talla03"].Value;
                    row["talla04"] = griddetallepedido.Rows[fila.Index].Cells["talla04"].Value;
                    row["talla05"] = griddetallepedido.Rows[fila.Index].Cells["talla05"].Value;
                    row["talla06"] = griddetallepedido.Rows[fila.Index].Cells["talla06"].Value;
                    row["talla07"] = griddetallepedido.Rows[fila.Index].Cells["talla07"].Value;
                    row["talla08"] = griddetallepedido.Rows[fila.Index].Cells["talla08"].Value;
                    row["talla09"] = griddetallepedido.Rows[fila.Index].Cells["talla09"].Value;
                    row["talla10"] = griddetallepedido.Rows[fila.Index].Cells["talla10"].Value;
                    row["talla11"] = griddetallepedido.Rows[fila.Index].Cells["talla11"].Value;
                    row["talla12"] = griddetallepedido.Rows[fila.Index].Cells["talla12"].Value;
                    TabladetallePedido2.Rows.Add(row);
                }
            }
            griddetallepedido2.DataSource = TabladetallePedido2;
        }
        private void griddetallepedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (var i = 5; i <= 16; i++)
            {
                griddetallepedido.Columns[i].HeaderText = griddetallepedido.CurrentRow.Cells[i + 20].Value.ToString();
            }
        }

        private void btn_clave_Click(object sender, EventArgs e)
        {
            try
            {
                var miForma = new BapFormulariosNet.Ayudas.Form_user_admin();
                miForma.Owner = this;
                miForma.PasaDatos = RecibePermiso;
                miForma.ShowDialog();
                var sw = false;
                sw = Convert.ToBoolean(miForma.ShowDialog());

                if (sw)
                {
                    serdoc.Enabled = true;
                }
                else
                {
                    serdoc.Enabled = false;
                }
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

        private void griddetallepedido2_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void griddetallepedido2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void get_autoCS_numPedido()
        {
            try
            {
                var BL = new tb_cp_comercialcabBL();
                var BE = new tb_cp_comercialcab();
                var dt = new DataTable();
                BE.moduloid = modulo;
                BE.perianio = VariablesPublicas.perianio;
                BE.serop = ser_op.Text;
                dt = BL.GetAllNuevoNumero(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    serdoc.Text = dt.Rows[0]["perianio"].ToString();
                    numdoc.Text = dt.Rows[0]["Cnum_cp"].ToString();

                    ser_op.Text = dt.Rows[0]["ser_op"].ToString();
                    num_op.Text = dt.Rows[0]["Cnum_op"].ToString();
                }
                else
                {
                    serdoc.Text = string.Empty;
                    numdoc.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_fijar_Click(object sender, EventArgs e)
        {
            fechentrega.Enabled = !fechentrega.Enabled;
            glosa.Enabled = !glosa.Enabled;
            numdoc.Enabled = !numdoc.Enabled;
            ctacte.Enabled = !ctacte.Enabled;
            cboCanalventa.Enabled = !cboCanalventa.Enabled;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (griddetallepedido2.Enabled)
                {
                    if (griddetallepedido2.Rows.Count > 0)
                    {
                        griddetallepedido2.CurrentCell = griddetallepedido2.Rows[griddetallepedido2.RowCount - 1].Cells["color_id"];
                        griddetallepedido2.BeginEdit(true);

                        griddetallepedido2.CurrentCell = griddetallepedido2.Rows[griddetallepedido2.RowCount - 1].Cells["color_id"];
                        griddetallepedido2.BeginEdit(true);
                    }
                    else
                    {
                        TabladetallePedido2.Rows.Add(VariablesPublicas.InsertIntoTable(TabladetallePedido2));
                        griddetallepedido2.CurrentCell = griddetallepedido2.Rows[griddetallepedido2.RowCount - 1].Cells["color_id"];
                        griddetallepedido2.BeginEdit(true);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var lc_cont = 0;
            var xcoditem = string.Empty;
            if ((griddetallepedido2.CurrentRow != null))
            {
                xcoditem = griddetallepedido2.Rows[griddetallepedido2.CurrentCell.RowIndex].Cells["color_id"].Value.ToString();
                for (lc_cont = 0; lc_cont <= TabladetallePedido2.Rows.Count - 1; lc_cont++)
                {
                    if (TabladetallePedido2.Rows[lc_cont]["colorid"].ToString() == xcoditem)
                    {
                        TabladetallePedido2.Rows[lc_cont].Delete();
                        TabladetallePedido2.AcceptChanges();
                        break;
                    }
                }
            }
        }

        private void griddetallepedido2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    if ((griddetallepedido2.CurrentCell != null))
                    {
                        if (griddetallepedido2.Columns[griddetallepedido2.CurrentCell.ColumnIndex].Name.ToUpper() == "colorid".ToUpper())
                        {
                        }

                        if (griddetallepedido2.Columns[griddetallepedido2.CurrentCell.ColumnIndex].Name.ToUpper() == "productname".ToUpper())
                        {
                            Convert.ToString(griddetallepedido2.Rows[griddetallepedido2.CurrentCell.RowIndex].Cells["productid"].Value);
                            Convert.ToString(griddetallepedido2.Rows[griddetallepedido2.CurrentCell.RowIndex].Cells["productname"].Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                BE.moduloid = modulo.ToString();

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();
                        var frmayuda = new Ayudas.Frm_help_general();

                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "Ayuda Color";
                        frmayuda.sqlquery = "select colorid, colorname from tb_" + modd + "_color";
                        frmayuda.sqlinner = string.Empty;
                        frmayuda.sqlwhere = "where";
                        frmayuda.sqland = string.Empty;
                        frmayuda.criteriosbusqueda = new string[] { "COLOR", "CÓDIGO" };
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
            }
        }
    }
}
