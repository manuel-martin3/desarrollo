using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.D60ALMACEN.CATALOGO
{
    public partial class Frm_producto_est : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable Tablaproducto;
        private Boolean procesado = false;
        private String xxferfil = string.Empty;
        private String ssModo = "NEW";

        public Frm_producto_est()
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


        private void form_bloqueado(Boolean var)
        {
            try
            {
                fechadoc.Enabled = false;
                cencosid.Enabled = var;
                estacion.Enabled = var;
                productid.Enabled = var;
                cbo_estado.Enabled = false;

                productname.ReadOnly = true;
                item.Enabled = false;

                btn_nuevo.Enabled = false;
                btn_editar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_grabar.Enabled = false;
                btn_eliminar.Enabled = false;
                btn_imprimir.Enabled = false;
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
                productid.Enabled = true;

                btn_nuevo.Enabled = true;
                btn_salir.Enabled = true;

                ssModo = "NEW";
            }
        }

        private void form_cargar_datos()
        {
            try
            {
                var BL = new tb_60productosBL();
                var BE = new tb_60productos();

                BE.moduloid = modulo.ToString();
                BE.filtro = "1";
                Tablaproducto = BL.GetAll(EmpresaID, BE).Tables[0];

                if (Tablaproducto.Rows.Count > 0)
                {
                    dgbproductos.DataSource = Tablaproducto;
                    btn_editar.Enabled = true;
                    btn_eliminar.Enabled = true;
                    btn_imprimir.Enabled = true;
                    btn_salir.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA  TABLA PRODUCTOS >>";
                        frmayuda.sqlquery = "SELECT tb1.productid, tb1.productname,tb1.status,tb2.lineaname,tb3.gruponame FROM tb_" + modd + "_productos AS tb1 ";
                        frmayuda.sqlinner = "inner join tb_" + modd + "_linea as tb2 on tb1.lineaid = tb2.lineaid " +
                                            "inner join tb_" + modd + "_grupo as tb3 on tb1.grupoid = tb3.grupoid";
                        frmayuda.sqlwhere = "where tb1.productidold = '0' ";
                        frmayuda.sqland = "and";
                        frmayuda.criteriosbusqueda = new string[] { "PRODUCTO", "CODIGO", "LINEA", "GRUPO" };
                        frmayuda.columbusqueda = "tb1.productname,tb1.productid,tb2.lineaname,tb3.gruponame";
                        frmayuda.returndatos = "0,1,2";

                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeProducto;
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                    cbo_estado.SelectedValue = resultado3;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SEGURIDAD_LOG(String accion)
        {
            var xclave = VariablesPublicas.EmpresaID + "/" + ((D60ALMACEN.MainAlmacen)MdiParent).perianio + "/" + productid.Text.Trim();
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
                BE.detalle = productid.Text.Trim() + "/" + productname.Text.Trim().ToUpper() + "/" + XGLOSA;

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
                fechadoc.Value = DateTime.Today;
                cbo_estado.SelectedIndex = -1;
                cencosid.Text = string.Empty;
                cencosname.Text = string.Empty;
                estacion.Text = string.Empty;
                item.Text = string.Empty;
                productid.Text = string.Empty;
                productname.Text = string.Empty;
                unmedpeso.Text = string.Empty;
                lblnombre.Text = string.Empty;
                cencosid.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevo()
        {
            ssModo = "NEW";
            limpiar_documento();
            form_bloqueado(true);
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_agregar.Enabled = true;
        }

        private void Insert()
        {
            try
            {
                if (productid.Text.Trim().Length != 13)
                {
                    MessageBox.Show("Código de producto invalido !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_60productosBL();
                    var BE = new tb_60productos();

                    BE.moduloid = modulo.ToString();
                    BE.productidold = cencosid.Text.Trim() + estacion.Text.Trim() + item.Text.Trim();
                    BE.productid = productid.Text.ToString();
                    BE.status = cbo_estado.SelectedValue.ToString();
                    BE.usuar = VariablesPublicas.Usuar.Trim();
                    BE.fepialmac = DateTime.Now.Date;
                    BE.feuialmac = DateTime.Now.Date;

                    if (BL.Update_CodigoOLD(EmpresaID, BE))
                    {
                        MessageBox.Show("Datos grabados correctamente !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        procesado = true;
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
                if (productid.Text.Trim().Length != 13)
                {
                    MessageBox.Show("Código de producto invalido !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_60productosBL();
                    var BE = new tb_60productos();

                    BE.moduloid = modulo.ToString();
                    BE.productidold = cencosid.Text.Trim() + estacion.Text.Trim() + item.Text.Trim();
                    BE.productid = productid.Text.ToString();
                    BE.status = cbo_estado.SelectedValue.ToString();
                    BE.usuar = VariablesPublicas.Usuar.Trim();
                    BE.fepialmac = DateTime.Now.Date;
                    BE.feuialmac = DateTime.Now.Date;

                    if (BL.Update_CodigoOLD(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("M");
                        MessageBox.Show("Datos modificado correctamente !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        procesado = true;
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
                if (productid.Text.Trim().Length != 13)
                {
                    MessageBox.Show("Código de producto invalido !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_60productosBL();
                    var BE = new tb_60productos();

                    BE.moduloid = modulo.Trim();
                    BE.productid = productid.Text.Trim();
                    BE.productidold = "0";
                    BE.usuar = VariablesPublicas.Usuar.Trim();
                    BE.fepialmac = DateTime.Now.Date;
                    BE.feuialmac = DateTime.Now.Date;

                    if (BL.Update_CodigoOLD(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos eliminados correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        limpiar_documento();
                        form_bloqueado(false);
                        productid.Enabled = true;
                        btn_nuevo.Enabled = true;
                        btn_salir.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_productos_est_Activated(object sender, EventArgs e)
        {
        }

        private void Frm_productos_est_Load(object sender, EventArgs e)
        {
            modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
            local = ((D60ALMACEN.MainAlmacen)MdiParent).local;

            PARAMETROS_TABLA();
            NIVEL_FORMS();

            Tablaproducto = new DataTable();
            Tablaproducto.Columns.Add("productid", typeof(String));
            Tablaproducto.Columns.Add("productname", typeof(String));
            Tablaproducto.Columns.Add("cencosname", typeof(String));
            Tablaproducto.Columns.Add("productidold", typeof(String));
            Tablaproducto.Columns.Add("estacion", typeof(String));
            Tablaproducto.Columns.Add("status", typeof(String));

            productname.CharacterCasing = CharacterCasing.Upper;
            CargarCombo_Estado();
            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_salir.Enabled = true;
        }

        private void CargarCombo_Estado()
        {
            var BE = new tb_sys_status();
            var BL = new sys_statusBL();
            var dt = new DataTable();
            BE.concepto = "SISTEMAS";
            dt = BL.GetAll(EmpresaID, BE).Tables[0];

            if (dt.Rows.Count > 0)
            {
                cbo_estado.DataSource = dt;
                cbo_estado.DisplayMember = "statusname";
                cbo_estado.ValueMember = "status";
            }
        }

        private void Frm_productos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
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

        private void productid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaProducto(string.Empty);
            }
        }

        private void productid_KeyUp(object sender, KeyEventArgs e)
        {
            if (productid.Text.Trim().Length == 13)
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    return;
                }
                else
                {
                    form_cargar_datos();
                }
            }
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

                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
                cbo_estado.Enabled = true;
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
                    sw_prosigue = (MessageBox.Show("¿Desea Guardar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
                }
                if (sw_prosigue)
                {
                    Insert();
                    form_cargar_datos();
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
                        form_cargar_datos();
                    }
                }
            }

            if (procesado)
            {
                NIVEL_FORMS();
                form_bloqueado(false);

                productid.Enabled = true;
                btn_nuevo.Enabled = true;
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
                    form_cargar_datos();
                }
            }
        }
        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                var miForma = new REPORTES.Frm_reportes();

                miForma.dominioid = dominio.Trim();
                miForma.moduloid = modulo.Trim();
                miForma.local = local.Trim();

                miForma.Text = "Reporte de Productos";
                miForma.formulario = "Frm_producto";
                miForma.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            AyudaProducto(string.Empty);
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
            var oform = new Seguridadlog.FrmSeguridad();
            var xclave = VariablesPublicas.EmpresaID + "/" + ((D60ALMACEN.MainAlmacen)MdiParent).perianio + "/" + productid.Text.Trim();
            oform._Nombre = Name;
            oform._ClaveForm = xclave;
            oform.Owner = this;
            oform.ShowDialog();
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void productname_TextChanged(object sender, EventArgs e)
        {
        }

        private void cencosid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaCentroCosto();
            }

            if (e.KeyCode == Keys.Enter)
            {
                ValidaCentrocosto(cencosid.Text.ToString(), false);
                estacion.Focus();
            }
        }

        private void AyudaCentroCosto()
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "Ayuda Centro de Costo";
                frmayuda.sqlquery = "select cencosid, cencosname From tb_centrocosto where cencosdivi = 2";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = string.Empty;
                frmayuda.sqland = "and";
                frmayuda.criteriosbusqueda = new string[] { "NOMBRE", "CÓDIGO" };
                frmayuda.columbusqueda = "cencosname,cencosid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeCentroCosto;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ValidaCentrocosto(String xCencosid, Boolean retrn)
        {
            if (xCencosid.Trim().Length > 0)
            {
                var BL = new tb_co_persona_cencosBL();
                var BE = new tb_co_persona_cencosBE();

                var dt = new DataTable();

                BE.cencosid = xCencosid.Trim().ToString();
                BE.filtro = "1";
                dt = BL.GetDNI(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    cencosid.Text = dt.Rows[0]["cencosid"].ToString().Trim();
                    cencosname.Text = dt.Rows[0]["cencosname"].ToString().Trim();
                }
                else
                {
                    if (!retrn)
                    {
                        cencosid.Text = string.Empty;
                        cencosname.Text = string.Empty;
                    }
                }
            }
        }

        private void RecibeCentroCosto(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                cencosid.Text = resultado1.Trim();
                cencosname.Text = resultado2.Trim();
            }
        }


        private void estacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var numdo = string.Empty;
                if (estacion.Text.Trim().Length > 0)
                {
                    numdo = estacion.Text.Trim().PadLeft(3, '0');
                }
                estacion.Text = numdo;
                var BL = new tb_60productosBL();
                var BE = new tb_60productos();
                var dt = new DataTable();

                BE.moduloid = modulo.ToString();
                BE.cencosid = cencosid.Text.Trim() + estacion.Text.Trim();
                dt = BL.GenCodigo(EmpresaID, BE).Tables[0];

                item.Text = dt.Rows[0]["item"].ToString().PadLeft(3, '0');


                var BL2 = new tb_co_persona_cencosBL();
                var BE2 = new tb_co_persona_cencosBE();

                BE2.cencosid = cencosid.Text.ToString();
                BE2.cencosestacion = estacion.Text.ToString();
                var dt2 = new DataTable();
                dt2 = BL2.GetAll(EmpresaID, BE2).Tables[0];

                if (dt2.Rows.Count > 0)
                {
                    lblnombre.Text = dt2.Rows[0]["nombrelargo"].ToString();
                }
                else
                {
                    lblnombre.Text = string.Empty;
                }
                productid.Focus();
            }
        }

        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            var BL = new tb_60productosBL();
            var BE = new tb_60productos();

            BE.moduloid = modulo.ToString();
            BE.codigo = cencosid.Text.Trim() + estacion.Text.Trim();
            BE.filtro = "2";
            BE.productname = txt_busqueda.Text.ToString();
            Tablaproducto = BL.GetAll(EmpresaID, BE).Tables[0];

            if (Tablaproducto.Rows.Count > 0)
            {
                dgbproductos.DataSource = Tablaproducto;

                btn_editar.Enabled = true;
                btn_eliminar.Enabled = true;
                btn_imprimir.Enabled = true;
                btn_salir.Enabled = true;
            }
            else
            {
                dgbproductos.DataSource = Tablaproducto;
            }
        }

        private void btn_fijar_Click(object sender, EventArgs e)
        {
            pnl_codigo.Enabled = !pnl_codigo.Enabled;
        }


        private void btn_agregar_Click(object sender, EventArgs e)
        {
            productid.Text = string.Empty;
            productname.Text = string.Empty;

            var BL = new tb_60productosBL();
            var BE = new tb_60productos();
            var dt = new DataTable();

            BE.moduloid = modulo.ToString();
            BE.cencosid = cencosid.Text.Trim() + estacion.Text.Trim();
            dt = BL.GenCodigo(EmpresaID, BE).Tables[0];

            item.Text = dt.Rows[0]["item"].ToString().PadLeft(3, '0');

            ssModo = "NEW";
            btn_grabar.Enabled = true;
            productid.Focus();
        }

        private void dgbproductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgbproductos.CurrentRow != null)
                {
                    var xproductid = string.Empty;
                    xproductid = dgbproductos.Rows[e.RowIndex].Cells["codigo"].Value.ToString().Trim();
                    data_Producto(xproductid);
                    btn_agregar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void data_Producto(String xproductid)
        {
            form_bloqueado(false);
            var rowgrupoid = Tablaproducto.Select("productid='" + xproductid + "'");
            if (rowgrupoid.Length > 0)
            {
                foreach (DataRow row in rowgrupoid)
                {
                    productid.Text = row["productid"].ToString().Trim();
                    productname.Text = row["productname"].ToString().Trim();
                    cencosid.Text = Equivalencias.Left(row["productidold"].ToString(), 5);
                    cencosname.Text = row["cencosname"].ToString().Trim();
                    estacion.Text = row["estacion"].ToString().Trim();
                    item.Text = Equivalencias.Mid(row["productidold"].ToString().Trim(), 9, 3);
                    cbo_estado.SelectedValue = row["status"].ToString().Trim();
                }

                btn_nuevo.Enabled = true;
                btn_editar.Enabled = true;
                btn_eliminar.Enabled = true;
                btn_imprimir.Enabled = true;
                btn_salir.Enabled = true;
            }
        }

        private void txt_busqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btn_busqueda_Click(sender, e);
            }
        }

        private void dgbproductos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xproductid = string.Empty;
                xproductid = dgbproductos.Rows[dgbproductos.CurrentRow.Index].Cells["codigo"].Value.ToString().Trim();
                data_Producto(xproductid);
            }
        }

        private void btn_siguiente_Click(object sender, EventArgs e)
        {
            var frmGuia = new Frm_movimiento();
            frmGuia.ShowDialog();
        }

        private void dgbproductos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgbproductos[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            dgbproductos[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);
            dgbproductos.EnableHeadersVisualStyles = false;
            dgbproductos.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            dgbproductos.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void dgbproductos_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dgbproductos[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }
    }
}
