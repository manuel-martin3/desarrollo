using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.D60Tienda.LISTA_PRECIOS
{
    public partial class Frm_lista_clientes : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable Tablactactelist;
        private DataTable TablactactelistItem;
        private Boolean procesado = false;

        private String ssModo = string.Empty;

        public Frm_lista_clientes()
        {
            InitializeComponent();
        }

        private void PARAMETROS_TABLA()
        {
            var xxferfil = string.Empty;
            var f = (MainTienda)MdiParent;
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
                btn_clave.Glyph = global::BapFormulariosNet.Properties.Resources.btn_Lock20;
            }
            else
            {
                btn_clave.Glyph = global::BapFormulariosNet.Properties.Resources.btn_Un_Lock20;
            }
        }
        private void RecibePermiso(Boolean resultado1, String resultado2)
        {
            if (resultado1)
            {
                XNIVEL = "0";
                XGLOSA = resultado2.Trim();
                btn_clave.Glyph = global::BapFormulariosNet.Properties.Resources.btn_Un_Lock20;
            }
        }

        private void form_bloqueado(Boolean var)
        {
            try
            {
                ctacteid.Enabled = var;
                ctactename.Enabled = false;

                ctactelistid.Enabled = false;
                ctactelistname.Enabled = var;
                btn_nuevo.Enabled = false;
                btn_editar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_grabar.Enabled = false;
                btn_eliminar.Enabled = false;
                btn_imprimir.Enabled = false;

                btn_clave.Enabled = true;
                btn_log.Enabled = true;
                btn_salir.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void form_cargar_datos(String posicion)
        {
            try
            {
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

        private void SEGURIDAD_LOG(String accion)
        {
            var xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio;
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
                BE.detalle = ctacteid.Text.Trim() + "/" + ctactename.Text.Trim().ToUpper() + "/" + XGLOSA;

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
                ctactelistid.Text = "N";
                ctactelistname.Text = string.Empty;
                ctacteid.Text = string.Empty;
                ctactename.Text = string.Empty;
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
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_log.Enabled = true;
            ctactelistname.Focus();

            ssModo = "NEW";
        }

        private void Nuevo2()
        {
            ctacteid.Text = string.Empty;
            ctactename.Text = string.Empty;
            form_bloqueado(true);
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_log.Enabled = true;
            ctacteid.Focus();
            ssModo = "NEW";
        }

        private void Insert()
        {
            try
            {
                if (ctactelistname.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Denominación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_me_ctactelistBL();
                    var BE = new tb_me_ctactelist();
                    BE.ctactelistname = ctactelistname.Text.Trim();
                    BE.usuar = VariablesPublicas.Usuar.Trim();

                    if (BL.Insert(EmpresaID, BE))
                    {
                        MessageBox.Show("Datos Grabados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (ctactelistid.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Codigo Lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_me_ctactelistBL();
                    var BE = new tb_me_ctactelist();

                    BE.ctactelistid = Convert.ToInt32(ctactelistid.Text.Trim());
                    BE.ctactelistname = ctactelistname.Text.Trim();
                    BE.usuar = VariablesPublicas.Usuar.Trim();

                    if (BL.Update(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("M");
                        MessageBox.Show("Datos Modificado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (ctactelistid.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Falta Codigo Lista !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_me_ctactelistBL();
                    var BE = new tb_me_ctactelist();

                    BE.ctactelistid = Convert.ToInt32(ctactelistid.Text.Trim());
                    BE.ctactelistname = ctactelistname.Text.Trim();
                    BE.usuar = VariablesPublicas.Usuar.Trim();

                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos Eliminado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        limpiar_documento();
                        form_bloqueado(false);
                        data_Tablactactelist();
                        data_Tablactactelistitem();
                        btn_nuevo.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_articulo_ctactelist_Load(object sender, EventArgs e)
        {
            modulo = ((D60Tienda.MainTienda)MdiParent).moduloid;
            local = ((D60Tienda.MainTienda)MdiParent).local;
            PERFILID = ((D60Tienda.MainTienda)MdiParent).perfil;
            NIVEL_FORMS();
            data_Tablactactelist();

            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_salir.Enabled = true;
        }

        private void Frm_articulo_ctactelist_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.G)
            {
                if (btn_grabar.Enabled)
                {
                    btn_grabar.PerformClick();
                }
            }

            if (e.Control && e.KeyCode == Keys.N)
            {
                if (btn_nuevo.Enabled)
                {
                    btn_nuevo.PerformClick();
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
                    btn_salir.PerformClick();
                }
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
                btn_nuevo.Enabled = true;
                btn_salir.Enabled = true;
                btn_del.Enabled = false;
                ssModo = "OTR";
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

        private void btn_log_Click(object sender, EventArgs e)
        {
            var oform = new Seguridadlog.FrmSeguridad();
            var xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio;
            oform._Nombre = Name;
            oform._ClaveForm = xclave;
            oform.Owner = this;
            oform.ShowDialog();
        }

        private void data_Tablactactelist()
        {
            try
            {
                Tablactactelist = new DataTable();

                if (Tablactactelist.Rows.Count > 0)
                {
                    Tablactactelist.Rows.Clear();
                }
                var BL = new tb_me_ctactelistBL();
                var BE = new tb_me_ctactelist();
                Tablactactelist = BL.GetAll(EmpresaID, BE).Tables[0];
                if (Tablactactelist.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    Mdi_dgv_ctactelist.DataSource = Tablactactelist;
                }
                else
                {
                    Mdi_dgv_ctactelist.DataSource = Tablactactelist;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void data_Tablactactelistitem()
        {
            TablactactelistItem = new DataTable();
            if (TablactactelistItem.Rows.Count > 0)
            {
                TablactactelistItem.Rows.Clear();
            }
            var BL = new tb_me_ctactelistitemBL();
            var BE = new tb_me_ctactelistitem();
            BE.ctactelistid = Convert.ToInt32(ctactelistid.Text.Trim());
            TablactactelistItem = BL.GetAll(EmpresaID, BE).Tables[0];
            if (TablactactelistItem.Rows.Count > 0)
            {
                MDI_dgv_ctactelistitem.DataSource = TablactactelistItem;
            }
            else
            {
                MDI_dgv_ctactelistitem.DataSource = TablactactelistItem;
            }
        }

        private void data_ctactelist(String xctactelistid)
        {
            form_bloqueado(false);
            var rowctactelistid = Tablactactelist.Select("ctactelistid='" + xctactelistid + "'");
            if (rowctactelistid.Length > 0)
            {
                foreach (DataRow row in rowctactelistid)
                {
                    ctactelistid.Text = row["ctactelistid"].ToString().Trim();
                    ctactelistname.Text = row["ctactelistname"].ToString().Trim();

                    ctacteid.Text = string.Empty;
                    ctactename.Text = string.Empty;
                    data_Tablactactelistitem();
                }

                btn_nuevo.Enabled = true;
                btn_editar.Enabled = true;
                btn_eliminar.Enabled = true;
                btn_imprimir.Enabled = true;
                btn_log.Enabled = true;
                btn_salir.Enabled = true;
                btn_add.Enabled = true;
                btn_del.Enabled = false;
            }
        }

        private void data_ctactelistitem(String xctacte)
        {
            form_bloqueado(false);
            var rowctactelistid = TablactactelistItem.Select("ctacte='" + xctacte + "'");
            if (rowctactelistid.Length > 0)
            {
                foreach (DataRow row in rowctactelistid)
                {
                    ctacteid.Text = row["ctacte"].ToString().Trim();
                    ctactename.Text = row["ctactename"].ToString().Trim();
                }

                btn_nuevo.Enabled = true;
                btn_editar.Enabled = true;
                btn_eliminar.Enabled = true;
                btn_imprimir.Enabled = true;
                btn_log.Enabled = true;
                btn_salir.Enabled = true;
                btn_del.Enabled = true;
            }
        }



        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            data_Tablactactelist();
        }

        private void btn_clave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void AyudaArticulo(String lpdescrlike)
        {
            var frmayuda = new Ayudas.Frm_help_general();

            frmayuda.tipoo = "sql";
            frmayuda.titulo = "<< AYUDA TABLA ARTICULO >>";
            frmayuda.sqlquery = "SELECT top 100 articid as Codigo,articidold as Cod_Ant, articname as Articulo FROM tb_pt_articulo ";
            frmayuda.sqlwhere = "where";
            frmayuda.criteriosbusqueda = new string[] { "ARTICULO", "CODIGO" };
            frmayuda.columbusqueda = "articname,articid";
            frmayuda.returndatos = "0,1,2";

            frmayuda.Owner = this;
            frmayuda.PasaProveedor = RecibeArticulo;
            frmayuda.ShowDialog();
        }

        private void RecibeArticulo(String xarticid, String xarticidold, String xarticname, String resultado4, String resultado5)
        {
            if (xarticid.Trim().Length > 0)
            {
                ctactelistid.Text = xarticid.Trim();
                ctactelistname.Text = xarticname.Trim();
                data_Tablactactelist();
            }
        }

        private void ValidaArticulo(String xcod)
        {
            var  BE = new tb_pt_articulo();
            var BL = new tb_pt_articuloBL();
            var dt = new DataTable();
            BE.articid = xcod.Trim();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                ctactelistid.Text = dt.Rows[0]["articid"].ToString();
                ctactelistname.Text = dt.Rows[0]["articname"].ToString();
            }
            else
            {
                ctactelistid.Text = string.Empty;
                ctactelistname.Text = string.Empty;
            }
        }

        private void Validactactelist()
        {
        }

        private void AyudaCliente(String lpdescrlike)
        {
            var frmayuda = new Ayudas.Frm_help_general();

            frmayuda.tipoo = "sql";
            frmayuda.titulo = "<< AYUDA TABLA CLIENTE >>";
            frmayuda.sqlquery = "SELECT ctacte as Codigo, ctactename as Cliente FROM tb_cliente ";
            frmayuda.sqlwhere = "where";
            frmayuda.criteriosbusqueda = new string[] { "CLIENTE", "CODIGO" };
            frmayuda.columbusqueda = "ctactename,ctacte";
            frmayuda.returndatos = "0,1";

            frmayuda.Owner = this;
            frmayuda.PasaProveedor = RecibeCliente;
            frmayuda.ShowDialog();
        }

        private void RecibeCliente(String xctacte, String xctactename, String resultado4, String resultado5, String otro)
        {
            if (xctacte.Trim().Length > 0)
            {
                ctacteid.Text = xctacte.Trim();
                ctactename.Text = xctactename.Trim();
                var BL = new tb_me_ctactelistitemBL();
                var BE = new tb_me_ctactelistitem();

                BE.ctactelistid = Convert.ToInt32(ctactelistid.Text.Trim());
                BE.ctacte = ctacteid.Text.Trim();
                BE.usuar = VariablesPublicas.Usuar.Trim();
                BE.status = "0";
                BE.feact = DateTime.Today;

                if (BL.Insert(EmpresaID, BE))
                {
                    data_Tablactactelistitem();
                }
            }
        }

        private void articid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaArticulo(string.Empty);
            }

            if (e.KeyCode == Keys.Enter)
            {
                var xcodart = string.Empty;
                xcodart = ctactelistid.Text.PadLeft(4, '0');
                ValidaArticulo(xcodart);
                data_Tablactactelist();
            }
        }

        private void ctactelistid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaCliente(string.Empty);
            }
        }

        private void btn_nuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
            {
                nuevo();
            }
        }

        private void btn_editar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XNIVEL == "0")
            {
                ssModo = "EDIT";
                form_bloqueado(true);
                ctacteid.Enabled = false;
                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
            }
        }

        private void btn_grabar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                data_Tablactactelist();
                form_bloqueado(false);
                btn_nuevo.Enabled = true;
                btn_salir.Enabled = true;
            }
        }

        private void btn_salir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btn_eliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void btn_cancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            form_accion_cancelEdicion(1);
        }

        private void articid_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Mdi_dgv_ctactelist_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xctactelistid = dgv_ctactelist.GetRowCellValue(dgv_ctactelist.FocusedRowHandle, "ctactelistid").ToString();
                data_ctactelist(xctactelistid);
            }
        }

        private void dgv_ctactelist_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var xctactelistid = dgv_ctactelist.GetRowCellValue(e.RowHandle, "ctactelistid").ToString();
            data_ctactelist(xctactelistid);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            form_bloqueado(true);
            ctacteid.Text = string.Empty;
            ctactename.Text = string.Empty;
            btn_cancelar.Enabled = true;
            ctactelistname.Enabled = false;
            btn_del.Enabled = false;
            ctacteid.Focus();
        }

        private void dgv_ctactelistitem_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var xctacte = dgv_ctactelistitem.GetRowCellValue(e.RowHandle, "ctacte").ToString();
            data_ctactelistitem(xctacte);
        }

        private void MDI_dgv_ctactelistitem_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xctacte = dgv_ctactelistitem.GetRowCellValue(dgv_ctactelistitem.FocusedRowHandle, "ctacte").ToString();
                data_ctactelistitem(xctacte);
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            var xcoditem = string.Empty;
            if ((dgv_ctactelistitem.RowCount != null))
            {
                xcoditem = dgv_ctactelistitem.GetRowCellValue(dgv_ctactelistitem.FocusedRowHandle, "ctacte").ToString();
                var BL = new tb_me_ctactelistitemBL();
                var BE = new tb_me_ctactelistitem();
                BE.ctactelistid = Convert.ToInt32(ctactelistid.Text.Trim());
                BE.ctacte = ctacteid.Text.Trim();

                if (BL.Delete(EmpresaID, BE))
                {
                    data_Tablactactelistitem();
                }
            }
        }
    }
}
