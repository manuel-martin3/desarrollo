using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.MERCADERIA.LISTA_PRECIOS
{
    public partial class Frm_lista_tiendas : plantilla
    {
        private String EmpresaID = string.Empty;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable Tablatiendalist;
        private DataTable TablatiendalistItem;
        private Boolean procesado = false;

        private String ssModo = string.Empty;

        public Frm_lista_tiendas()
        {
            InitializeComponent();
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
                tiendaid.Enabled = var;
                tiendaname.Enabled = false;

                tiendalistid.Enabled = false;
                tiendalistname.Enabled = var;
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
                BE.detalle = tiendaid.Text.Trim() + "/" + tiendaname.Text.Trim().ToUpper() + "/" + XGLOSA;

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
                tiendalistid.Text = "N";
                tiendalistname.Text = string.Empty;
                tiendaid.Text = string.Empty;
                tiendaname.Text = string.Empty;
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
            tiendalistname.Focus();

            ssModo = "NEW";
        }

        private void Nuevo2()
        {
            tiendaid.Text = string.Empty;
            tiendaname.Text = string.Empty;
            form_bloqueado(true);
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_log.Enabled = true;
            tiendaid.Focus();
            ssModo = "NEW";
        }

        private void Insert()
        {
            try
            {
                if (tiendalistname.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Denominación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_me_tiendalistBL();
                    var BE = new tb_me_tiendalist();
                    BE.tiendalistname = tiendalistname.Text.Trim();
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
                if (tiendalistid.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Codigo Lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_me_tiendalistBL();
                    var BE = new tb_me_tiendalist();

                    BE.tiendalist = Convert.ToInt32(tiendalistid.Text.Trim());
                    BE.tiendalistname = tiendalistname.Text.Trim();
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
                if (tiendalistid.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Falta Codigo Lista !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_me_tiendalistBL();
                    var BE = new tb_me_tiendalist();

                    BE.tiendalist = Convert.ToInt32(tiendalistid.Text.Trim());

                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos Eliminado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        limpiar_documento();
                        form_bloqueado(false);
                        data_Tablatiendalist();
                        data_Tablatiendalistitem();
                        btn_nuevo.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_articulo_tiendalist_Load(object sender, EventArgs e)
        {
            EmpresaID = VariablesPublicas.EmpresaID;
            modulo = VariablesPublicas.Moduloid.Trim();
            local = VariablesPublicas.Local.Trim();
            PARAMETROS_TABLA();
            NIVEL_FORMS();
            data_Tablatiendalist();

            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_salir.Enabled = true;
        }

        private void Frm_articulo_tiendalist_KeyDown(object sender, KeyEventArgs e)
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

        private void data_Tablatiendalist()
        {
            try
            {
                Tablatiendalist = new DataTable();

                if (Tablatiendalist.Rows.Count > 0)
                {
                    Tablatiendalist.Rows.Clear();
                }
                var BL = new tb_me_tiendalistBL();
                var BE = new tb_me_tiendalist();
                BE.filtro = "1";

                Tablatiendalist = BL.GetAll(EmpresaID, BE).Tables[0];
                if (Tablatiendalist.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    Mdi_dgv_tiendalist.DataSource = Tablatiendalist;
                }
                else
                {
                    Mdi_dgv_tiendalist.DataSource = Tablatiendalist;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void data_Tablatiendalistitem()
        {
            TablatiendalistItem = new DataTable();
            if (TablatiendalistItem.Rows.Count > 0)
            {
                TablatiendalistItem.Rows.Clear();
            }
            var BL = new tb_me_tiendalistBL();
            var  BE = new tb_me_tiendalist();
            BE.tiendalist = Convert.ToInt32(tiendalistid.Text.Trim());
            BE.filtro = "3";
            TablatiendalistItem = BL.GetAll(EmpresaID, BE).Tables[0];
            if (TablatiendalistItem.Rows.Count > 0)
            {
                MDI_dgv_tiendalistitem.DataSource = TablatiendalistItem;
            }
            else
            {
                MDI_dgv_tiendalistitem.DataSource = TablatiendalistItem;
            }
        }

        private void data_tiendalist(String xtiendalist)
        {
            form_bloqueado(false);
            var rowtiendalistid = Tablatiendalist.Select("tiendalist='" + xtiendalist + "'");
            if (rowtiendalistid.Length > 0)
            {
                foreach (DataRow row in rowtiendalistid)
                {
                    tiendalistid.Text = row["tiendalist"].ToString().Trim();
                    tiendalistname.Text = row["tiendalistname"].ToString().Trim();

                    tiendaid.Text = string.Empty;
                    tiendaname.Text = string.Empty;
                    data_Tablatiendalistitem();
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

        private void data_tiendalistitem(String xlocal)
        {
            form_bloqueado(false);
            var rowtiendalistid = TablatiendalistItem.Select("local='" + xlocal + "'");
            if (rowtiendalistid.Length > 0)
            {
                foreach (DataRow row in rowtiendalistid)
                {
                    tiendaid.Text = row["local"].ToString().Trim();
                    tiendaname.Text = row["localname"].ToString().Trim();
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
            data_Tablatiendalist();
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
                tiendalistid.Text = xarticid.Trim();
                tiendalistname.Text = xarticname.Trim();
                data_Tablatiendalist();
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
                tiendalistid.Text = dt.Rows[0]["articid"].ToString();
                tiendalistname.Text = dt.Rows[0]["articname"].ToString();
            }
            else
            {
                tiendalistid.Text = string.Empty;
                tiendalistname.Text = string.Empty;
            }
        }

        private void Validatiendalist()
        {
        }

        private void AyudaLocal(String lpdescrlike)
        {
            var frmayuda = new Ayudas.Frm_help_general();

            frmayuda.tipoo = "sql";
            frmayuda.titulo = "<< AYUDA TABLA LOCAL >>";
            frmayuda.sqlquery = "SELECT local as Codigo, localname as Cliente FROM tb_sys_local ";
            frmayuda.sqlwhere = "where dominioid = '" + VariablesPublicas.Dominioid + "' and moduloid  = '" + VariablesPublicas.Moduloid + "'";
            frmayuda.sqland = "and";
            frmayuda.criteriosbusqueda = new string[] { "LOCAL", "CODIGO" };
            frmayuda.columbusqueda = "localname,local";
            frmayuda.returndatos = "0,1";

            frmayuda.Owner = this;
            frmayuda.PasaProveedor = RecibeLocal;
            frmayuda.ShowDialog();
        }

        private void RecibeLocal(String xlocal, String xlocalname, String resultado4, String resultado5, String otro)
        {
            if (xlocal.Trim().Length > 0)
            {
                tiendaid.Text = xlocal.Trim();
                tiendaname.Text = xlocalname.Trim();
                var BL = new tb_me_tiendalistitemBL();
                var BE = new tb_me_tiendalistitem();

                BE.tiendalist = Convert.ToInt32(tiendalistid.Text.Trim());
                BE.localid = tiendaid.Text.Trim();
                BE.usuar = VariablesPublicas.Usuar.Trim();
                BE.status = "0";
                BE.feact = DateTime.Today;

                if (BL.Insert(EmpresaID, BE))
                {
                    data_Tablatiendalistitem();
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
                xcodart = tiendalistid.Text.PadLeft(4, '0');
                ValidaArticulo(xcodart);
                data_Tablatiendalist();
            }
        }

        private void tiendalistid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaLocal(string.Empty);
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
                tiendaid.Enabled = false;
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
                data_Tablatiendalist();
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

        private void Mdi_dgv_tiendalist_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xtiendalistid = dgv_tiendalist.GetRowCellValue(dgv_tiendalist.FocusedRowHandle, "tiendalist").ToString();
                data_tiendalist(xtiendalistid);
            }
        }

        private void dgv_tiendalist_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var xtiendalistid = dgv_tiendalist.GetRowCellValue(e.RowHandle, "tiendalist").ToString();
            data_tiendalist(xtiendalistid);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            form_bloqueado(true);
            tiendaid.Text = string.Empty;
            tiendaname.Text = string.Empty;
            btn_cancelar.Enabled = true;
            tiendalistname.Enabled = false;
            btn_del.Enabled = false;
            tiendaid.Focus();
        }

        private void dgv_tiendalistitem_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var xtienda = dgv_tiendalistitem.GetRowCellValue(e.RowHandle, "local").ToString();
            data_tiendalistitem(xtienda);
        }

        private void MDI_dgv_tiendalistitem_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xtienda = dgv_tiendalistitem.GetRowCellValue(dgv_tiendalistitem.FocusedRowHandle, "local").ToString();
                data_tiendalistitem(xtienda);
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if ((dgv_tiendalistitem.RowCount != null))
            {
                var BL = new tb_me_tiendalistitemBL();
                var BE = new tb_me_tiendalistitem();
                BE.tiendalist = Convert.ToInt32(tiendalistid.Text.Trim());
                BE.localid = tiendaid.Text.Trim();

                if (BL.Delete(EmpresaID, BE))
                {
                    data_Tablatiendalistitem();
                    tiendaid.Text = string.Empty;
                    tiendaname.Text = string.Empty;
                }
            }
        }
    }
}
