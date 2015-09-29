using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace BapFormulariosNet.D60Tienda.LISTA_PRECIOS
{
    public partial class Frm_lista_precios : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable Tablaprecioslist;
        private DataTable TablaprecioslistDet;

        private Boolean procesado = false;

        private String ssModo = string.Empty;

        public Frm_lista_precios()
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
                listaprecid.Enabled = false;
                listaprecname.Enabled = var;

                articid.Enabled = var;
                articname.Enabled = false;


                ctactelist.Enabled = var;
                ctactelistname.Enabled = false;
                tiendalist.Enabled = var;
                tiendalistname.Enabled = false;
                fechdocini.Enabled = var;
                fechdocfin.Enabled = var;
                precunit1.Enabled = var;
                precunit2.Enabled = var;

                incigv.Enabled = var;
                visible.Enabled = var;
                tcamb.Enabled = var;

                btn_nuevo.Enabled = false;
                btn_editar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_grabar.Enabled = false;
                btn_eliminar.Enabled = false;
                btn_imprimir.Enabled = false;
                btn_save.Enabled = false;
                btn_importar.Enabled = false;
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
                BE.detalle = articid.Text.Trim() + "/" + articname.Text.Trim().ToUpper() + "/" + XGLOSA;

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
                listaprecid.Text = string.Empty;
                listaprecname.Text = string.Empty;
                tiendalist.Text = string.Empty;
                tiendalistname.Text = string.Empty;
                ctactelist.Text = string.Empty;
                ctactelistname.Text = string.Empty;
                tcamb.Text = string.Empty;
                fechdocini.Text = DateTime.Today.ToShortDateString();
                fechdocfin.Text = DateTime.Today.ToShortDateString();
                visible.Checked = false;
                incigv.Checked = false;

                precunit1.Text = string.Empty;
                precunit2.Text = string.Empty;

                articid.Text = string.Empty;
                articname.Text = string.Empty;
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
            listaprecname.Focus();
            pnlcontroldet.Enabled = false;
            ssModo = "NEW";
        }

        private void Nuevo2(Boolean var)
        {
            articid.Text = string.Empty;
            articname.Text = string.Empty;
            precunit1.Text = string.Empty;
            precunit2.Text = string.Empty;
            btn_save.Enabled = var;
            articid.Enabled = var;
            precunit1.Enabled = var;
            precunit2.Enabled = var;
            btn_cancelar.Enabled = true;
            articid.Focus();
            ssModo = "NEW";
        }

        private void Insert()
        {
            try
            {
                if (listaprecname.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Denominación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_me_listaprecioscabBL();
                    var BE = new tb_me_listaprecioscab();
                    BE.listaprecname = listaprecname.Text.Trim();
                    BE.fechaini = Convert.ToDateTime(fechdocini.Text);
                    BE.fechafin = Convert.ToDateTime(fechdocfin.Text);
                    BE.tiendalist = Convert.ToInt32(tiendalist.Text.Trim());
                    BE.ctactelist = Convert.ToInt32(ctactelist.Text.Trim());
                    BE.tcamb = Convert.ToDecimal(tcamb.Text.Trim());
                    BE.incigv = incigv.Checked;
                    BE.visible = visible.Checked;
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
                if (listaprecid.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Codigo Lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_me_listaprecioscabBL();
                    var BE = new tb_me_listaprecioscab();

                    BE.listaprecid = Convert.ToInt32(listaprecid.Text.Trim());
                    BE.listaprecname = listaprecname.Text.Trim();
                    BE.fechaini = Convert.ToDateTime(fechdocini.Text);
                    BE.fechafin = Convert.ToDateTime(fechdocfin.Text);
                    BE.tiendalist = Convert.ToInt32(tiendalist.Text.Trim());
                    BE.ctactelist = Convert.ToInt32(ctactelist.Text.Trim());
                    BE.tcamb = Convert.ToDecimal(tcamb.Text.Trim());
                    BE.incigv = incigv.Checked;
                    BE.visible = visible.Checked;
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
                if (listaprecid.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Falta Codigo Lista !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_me_listaprecioscabBL();
                    var BE = new tb_me_listaprecioscab();

                    BE.listaprecid = Convert.ToInt32(listaprecid.Text.Trim());

                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos Eliminado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        limpiar_documento();
                        form_bloqueado(false);
                        data_Tablaprecioslist();
                        CargarDetalle();
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
            modulo = ((D60Tienda.MainTienda)MdiParent).moduloid;
            local = ((D60Tienda.MainTienda)MdiParent).local;
            PERFILID = ((D60Tienda.MainTienda)MdiParent).perfil;

            NIVEL_FORMS();
            data_Tablaprecioslist();


            TablaprecioslistDet = new DataTable();
            TablaprecioslistDet.Columns.Add("listaprecid", typeof(Int32));
            TablaprecioslistDet.Columns.Add("codigo", typeof(String));
            TablaprecioslistDet.Columns.Add("denominacion", typeof(String));
            TablaprecioslistDet.Columns.Add("precunit1", typeof(Decimal));
            TablaprecioslistDet.Columns.Add("precunit2", typeof(Decimal));
            TablaprecioslistDet.Columns.Add("usuar", typeof(String));
            TablaprecioslistDet.Columns.Add("feact", typeof(DateTime));

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
                pnlcontroldet.Enabled = true;
                btn_del.Enabled = false;
                ssModo = "OTR";
                if (TablaprecioslistDet.Rows.Count > 0)
                {
                    TablaprecioslistDet.Rows.Clear();
                    dgb_listaPrecios.DataSource = TablaprecioslistDet;
                }
                else
                {
                    dgb_listaPrecios.DataSource = TablaprecioslistDet;
                }
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

        private void data_Tablaprecioslist()
        {
            try
            {
                Tablaprecioslist = new DataTable();

                if (Tablaprecioslist.Rows.Count > 0)
                {
                    Tablaprecioslist.Rows.Clear();
                }
                var BL = new tb_me_listaprecioscabBL();
                var BE = new tb_me_listaprecioscab();

                Tablaprecioslist = BL.GetAll(EmpresaID, BE).Tables[0];
                if (Tablaprecioslist.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    Mdi_dgv_precioslist.DataSource = Tablaprecioslist;
                }
                else
                {
                    Mdi_dgv_precioslist.DataSource = Tablaprecioslist;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void data_Tablatiendalistitem()
        {
        }

        private void data_tiendalist(String xlistaprec)
        {
            form_bloqueado(false);
            var rowtiendalistid = Tablaprecioslist.Select("listaprecid='" + xlistaprec + "'");
            if (rowtiendalistid.Length > 0)
            {
                foreach (DataRow row in rowtiendalistid)
                {
                    listaprecid.Text = row["listaprecid"].ToString().Trim();
                    listaprecname.Text = row["listaprecname"].ToString().Trim();
                    tiendalist.Text = row["tiendalist"].ToString().Trim();
                    tiendalistname.Text = row["tiendalistname"].ToString().Trim();
                    ctactelist.Text = row["ctactelist"].ToString().Trim();
                    ctactelistname.Text = row["ctactelistname"].ToString().Trim();
                    fechdocini.Text = row["fechaini"].ToString().Trim();
                    fechdocfin.Text = row["fechafin"].ToString().Trim();
                    tcamb.Text = row["tcamb"].ToString().Trim();
                    incigv.Checked = Convert.ToBoolean(row["incigv"].ToString());
                    visible.Checked = Convert.ToBoolean(row["visible"].ToString());


                    articid.Text = string.Empty;
                    articname.Text = string.Empty;
                    precunit1.Text = string.Empty;
                    precunit2.Text = string.Empty;
                    CargarDetalle();
                }

                btn_nuevo.Enabled = true;
                btn_editar.Enabled = true;
                btn_eliminar.Enabled = true;
                btn_imprimir.Enabled = true;
                btn_log.Enabled = true;
                btn_salir.Enabled = true;
                btn_importar.Enabled = true;
                btn_add.Enabled = true;
                btn_del.Enabled = false;
            }
        }

        private void data_tiendalistitem(String xlocal)
        {
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
                articid.Text = xarticidold.Trim();
                articname.Text = xarticname.Trim();
            }
        }

        private void ValidaArticulo(String xcod)
        {
            var  BE = new tb_pt_articulo();
            var BL = new tb_pt_articuloBL();
            var dt = new DataTable();
            BE.articidold = xcod.Trim();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                articid.Text = dt.Rows[0]["articidold"].ToString();
                articname.Text = dt.Rows[0]["articname"].ToString();
            }
            else
            {
                articid.Text = string.Empty;
                articname.Text = string.Empty;
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
                xcodart = articid.Text.Trim();
                ValidaArticulo(xcodart);
                precunit1.Focus();
            }
        }

        private void btn_nuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
            {
                nuevo();
                if (TablaprecioslistDet != null)
                {
                    TablaprecioslistDet.Rows.Clear();
                    dgb_listaPrecios.DataSource = TablaprecioslistDet;
                }
                get_tipocambio(Convert.ToString(DateTime.Today));
            }
        }

        private void btn_editar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XNIVEL == "0")
            {
                ssModo = "EDIT";
                form_bloqueado(true);
                pnlcontroldet.Enabled = false;
                articid.Enabled = false;
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
                limpiar_documento();
                data_Tablaprecioslist();
                form_bloqueado(false);
                btn_nuevo.Enabled = true;
                btn_salir.Enabled = true;
                pnlcontroldet.Enabled = true;
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

        private void Mdi_dgv_tiendalist_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xtiendalistid = dgv_precioslist.GetRowCellValue(dgv_precioslist.FocusedRowHandle, "listaprecid").ToString();
                data_tiendalist(xtiendalistid);
            }
        }

        private void dgv_tiendalist_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var xtiendalistid = dgv_precioslist.GetRowCellValue(e.RowHandle, "listaprecid").ToString();
            data_tiendalist(xtiendalistid);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            form_bloqueado(false);
            Nuevo2(true);
            btn_cancelar.Enabled = true;
            listaprecname.Enabled = false;
            btn_del.Enabled = false;
            btn_add.Enabled = false;
            articid.Focus();
        }

        private void dgv_tiendalistitem_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
        }

        private void MDI_dgv_tiendalistitem_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if ((dgb_listaPrecios.RowCount != null))
            {
                if (listaprecid.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Falta Codigo de Lista de Precios", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (articid.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Falta Codigo de Artículo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                var BL = new tb_me_listapreciosdetBL();
                var BE = new tb_me_listapreciosdet();
                BE.listaprecid = Convert.ToInt32(listaprecid.Text.Trim());
                BE.codigo = articid.Text.Trim();

                if (BL.Delete(EmpresaID, BE))
                {
                    CargarDetalle();
                    articid.Text = string.Empty;
                    articname.Text = string.Empty;
                    precunit1.Text = string.Empty;
                    precunit2.Text = string.Empty;
                    btn_del.Enabled = false;
                }
            }
        }

        private void btn_importar_Click(object sender, EventArgs e)
        {
            if (listaprecid.Text.ToString().Trim().Length > 0)
            {
                Importar_Excel();
            }
            else
            {
                MessageBox.Show("Seleccione Una Lista de Precios Para Agregar Detalle .. !!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void Importar_Excel()
        {
            var CuadroDialogo = new OpenFileDialog();
            CuadroDialogo.DefaultExt = "xls";
            CuadroDialogo.Filter = "xls file(*.xls)|*.xlsx";
            CuadroDialogo.AddExtension = true;
            CuadroDialogo.RestoreDirectory = true;
            CuadroDialogo.Title = "Seleccionar Archivo";

            if (CuadroDialogo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var excelApp = new Excel.Application();
                    var excelBook = excelApp.Workbooks.Open(CuadroDialogo.FileName, Type.Missing, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    var excelWorksheet = (Excel._Worksheet)excelBook.Worksheets.get_Item(1);
                    excelApp.Visible = false;

                    var x = 2;
                    if (TablaprecioslistDet.Rows.Count > 0)
                    {
                        TablaprecioslistDet.Rows.Clear();
                    }
                    while (excelWorksheet.get_Range("A" + x).Value2 != null)
                    {
                        TablaprecioslistDet.Rows.Add(listaprecid.Text.Trim(),
                                            excelWorksheet.get_Range("A" + x).Value2.ToString(),
                                            excelWorksheet.get_Range("B" + x).Value2.ToString(),
                                            excelWorksheet.get_Range("C" + x).Value2.ToString(),
                                            excelWorksheet.get_Range("D" + x).Value2.ToString(),
                                            VariablesPublicas.Usuar.ToString(),
                                            DateTime.Today.ToShortDateString());
                        x++;
                    }

                    var BL = new tb_me_listapreciosdetBL();
                    var BE = new tb_me_listapreciosdet();

                    var Detalle = new tb_me_listapreciosdet.Item();
                    var ListaItems = new List<tb_me_listapreciosdet.Item>();

                    var item = 0;
                    foreach (DataRow fila in TablaprecioslistDet.Rows)
                    {
                        Detalle = new tb_me_listapreciosdet.Item();
                        item++;
                        Detalle.listaprecid = Convert.ToInt32(listaprecid.Text.ToString());
                        Detalle.codigo = fila["codigo"].ToString();
                        Detalle.precunit1 = Convert.ToDecimal(fila["precunit1"].ToString().Trim());
                        Detalle.precunit2 = Convert.ToDecimal(fila["precunit2"].ToString().Trim());
                        Detalle.usuar = VariablesPublicas.Usuar;
                        Detalle.feact = Convert.ToDateTime(fila["feact"].ToString().Trim());
                        ListaItems.Add(Detalle);
                    }
                    if (ListaItems.Count == 0)
                    {
                        MessageBox.Show("Documento SIN DETALLE Y/O DETALLE INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    BE.listaprecid = Convert.ToInt32(listaprecid.Text.ToString());
                    BE.ListaItems = ListaItems;

                    if (BL.InsertDet(EmpresaID, BE))
                    {
                        MessageBox.Show("Datos Grabados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDetalle();
                        Nuevo2(false);
                        btn_add.Enabled = true;
                    }

                    excelApp.Quit();
                }
                catch (Exception sms)
                {
                    MessageBox.Show(sms.Message);
                }
            }
        }




        private void btn_exportar_Click(object sender, EventArgs e)
        {
            if (dgb_listaPrecios.Rows.Count > 0)
            {
                ExportarExcel();
            }
            else
            {
                MessageBox.Show("No Hay Detalle A Exportar ... !!!");
            }
        }

        private void ExportarExcel()
        {
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;

            try
            {
                oXL = new Excel.Application();
                oXL.Visible = false;

                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                oSheet.Cells[1, 1] = "Codigo";
                oSheet.Cells[1, 2] = "Denominación";
                oSheet.Cells[1, 3] = "Precio-Soles";
                oSheet.Cells[1, 4] = "Precio-Dolar";

                oSheet.get_Range("A1", "D1").Font.Bold = true;
                oSheet.get_Range("A1", "D1").Font.Color = Color.White;
                oSheet.get_Range("A1", "D1").Interior.ColorIndex = 14;
                oSheet.get_Range("A1", "D1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                var IndiceFila = 0;

                oRng = oSheet.get_Range("A2", "D" + TablaprecioslistDet.Rows.Count + 1);
                oRng.NumberFormat = "@";

                foreach (DataRow row in TablaprecioslistDet.Rows)
                {
                    IndiceFila++;
                    for (var column = 1; column < 5; column++)
                    {
                        oSheet.Cells[IndiceFila + 1 , column] = row[column].ToString();
                    }
                }

                oRng = oSheet.get_Range("A1", "D1");
                oRng.EntireColumn.AutoFit();

                oXL.Visible = true;
                oXL.UserControl = true;
            }
            catch (Exception ex)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, ex.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, ex.Source);

                MessageBox.Show(errorMessage, "Error");
            }
        }

        private void get_tipocambio(string fecha)
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

        private void tiendalist_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaTiendaList(string.Empty);
            }

            if (e.KeyCode == Keys.Enter)
            {
                var xcodtiendalist = string.Empty;
                xcodtiendalist = tiendalist.Text.Trim();
                ValidaTiendaList(xcodtiendalist);
                ctactelist.Focus();
            }
        }

        private void AyudaTiendaList(String lpdescrlike)
        {
            var frmayuda = new Ayudas.Frm_help_general();

            frmayuda.tipoo = "sql";
            frmayuda.titulo = "<< AYUDA TABLA LISTA DE TIENDAS >>";
            frmayuda.sqlquery = "SELECT top 100 tiendalist as Codigo, tiendalistname as Denominación FROM tb_me_tiendalist ";
            frmayuda.sqlwhere = "where";
            frmayuda.criteriosbusqueda = new string[] { "NOMBRE", "CODIGO" };
            frmayuda.columbusqueda = "tiendalistname,tiendalist";
            frmayuda.returndatos = "0,1";

            frmayuda.Owner = this;
            frmayuda.PasaProveedor = RecibeTiendaList;
            frmayuda.ShowDialog();
        }

        private void RecibeTiendaList(String xtiendalist, String xtiendalistname, String xarticidold, String resultado4, String resultado5)
        {
            if (xtiendalist.Trim().Length > 0)
            {
                tiendalist.Text = xtiendalist.Trim();
                tiendalistname.Text = xtiendalistname.Trim();
            }
        }

        private void ValidaTiendaList(String xcod)
        {
            var BE = new tb_me_tiendalist();
            var BL = new tb_me_tiendalistBL();
            var dt = new DataTable();
            BE.tiendalist = Convert.ToInt32(xcod.Trim());
            BE.filtro = "4";
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                tiendalist.Text = dt.Rows[0]["tiendalist"].ToString();
                tiendalistname.Text = dt.Rows[0]["tiendalistname"].ToString();
            }
            else
            {
                tiendalist.Text = string.Empty;
                tiendalistname.Text = string.Empty;
            }
        }

        private void ctactelist_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaCtactelist(string.Empty);
            }

            if (e.KeyCode == Keys.Enter)
            {
                var xcodCtactelist = string.Empty;
                xcodCtactelist = ctactelist.Text.Trim();
                ValidaCtactelist(xcodCtactelist);
                fechdocini.Focus();
            }
        }
        private void AyudaCtactelist(String lpdescrlike)
        {
            var frmayuda = new Ayudas.Frm_help_general();

            frmayuda.tipoo = "sql";
            frmayuda.titulo = "<< AYUDA TABLA LISTA DE CLIENTES >>";
            frmayuda.sqlquery = "SELECT top 100 ctactelistid as Codigo, ctactelistname as Denominación FROM tb_me_ctactelist ";
            frmayuda.sqlwhere = "where";
            frmayuda.criteriosbusqueda = new string[] { "NOMBRE", "CODIGO" };
            frmayuda.columbusqueda = "ctactelistname,ctactelistid";
            frmayuda.returndatos = "0,1";

            frmayuda.Owner = this;
            frmayuda.PasaProveedor = RecibeCtactelist;
            frmayuda.ShowDialog();
        }

        private void RecibeCtactelist(String xctactelistid, String xctactelistname, String xarticidold, String resultado4, String resultado5)
        {
            if (xctactelistid.Trim().Length > 0)
            {
                ctactelist.Text = xctactelistid.Trim();
                ctactelistname.Text = xctactelistname.Trim();
            }
        }

        private void ValidaCtactelist(String xcod)
        {
            var BE = new tb_me_ctactelist();
            var BL = new tb_me_ctactelistBL();
            var dt = new DataTable();
            BE.ctactelistid = Convert.ToInt32(xcod.Trim());
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                ctactelist.Text = dt.Rows[0]["ctactelistid"].ToString();
                ctactelistname.Text = dt.Rows[0]["ctactelistname"].ToString();
            }
            else
            {
                ctactelist.Text = string.Empty;
                ctactelistname.Text = string.Empty;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (articid.Text.Length == 0)
            {
                MessageBox.Show("Ingrese Articulo ... !!!");
                return;
            }
            else
            {
                if (precunit1.Text.Length == 0)
                {
                    MessageBox.Show("Ingrese Precio ... !!!");
                    return;
                }
            }
            var BE = new tb_me_listapreciosdet();
            var BL = new tb_me_listapreciosdetBL();

            BE.listaprecid = Convert.ToInt32(listaprecid.Text.Trim());
            BE.codigo = articid.Text.Trim();
            BE.precunit1 = Convert.ToDecimal(precunit1.Text.Trim());
            BE.precunit2 = Convert.ToDecimal(precunit2.Text.Trim());
            BE.usuar = VariablesPublicas.Usuar.ToString().Trim();

            if (BL.Insert(EmpresaID, BE))
            {
                MessageBox.Show("Datos Grabados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDetalle();
                Nuevo2(false);
                btn_add.Enabled = true;
            }
        }

        private void CargarDetalle()
        {
            var BL = new tb_me_listapreciosdetBL();
            var BE = new tb_me_listapreciosdet();
            TablaprecioslistDet = new DataTable();
            if (listaprecid.Text.Trim().Length > 0)
            {
                BE.listaprecid = Convert.ToInt32(listaprecid.Text.Trim());
            }

            TablaprecioslistDet = BL.GetAll(EmpresaID, BE).Tables[0];
            if (TablaprecioslistDet.Rows.Count > 0)
            {
                dgb_listaPrecios.DataSource = TablaprecioslistDet;
            }
            else
            {
                dgb_listaPrecios.DataSource = TablaprecioslistDet;
            }
        }

        private void precunit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                precunit2.Focus();
            }
        }

        private void dgb_listaPrecios_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgb_listaPrecios[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            dgb_listaPrecios[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            dgb_listaPrecios.EnableHeadersVisualStyles = false;
            dgb_listaPrecios.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            dgb_listaPrecios.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void dgb_listaPrecios_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xcodigo = string.Empty;
                xcodigo = dgb_listaPrecios.Rows[dgb_listaPrecios.CurrentRow.Index].Cells["codigo"].Value.ToString().Trim();
                data_Precios(xcodigo);
            }
        }

        private void dgb_listaPrecios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgb_listaPrecios.CurrentRow != null)
            {
                var xcodigo = string.Empty;
                xcodigo = dgb_listaPrecios.Rows[e.RowIndex].Cells["codigo"].Value.ToString().Trim();
                data_Precios(xcodigo);
            }
        }

        private void data_Precios(String xcodigo)
        {
            var rowprecios = TablaprecioslistDet.Select("codigo='" + xcodigo + "'");
            if (rowprecios.Length > 0)
            {
                foreach (DataRow row in rowprecios)
                {
                    articid.Text = row["codigo"].ToString().Trim();
                    articname.Text = row["denominacion"].ToString().Trim();
                    precunit1.Text = row["precunit1"].ToString();
                    precunit2.Text = row["precunit2"].ToString();
                    btn_del.Enabled = true;
                }
            }
        }

        private void listaprecname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tiendalist.Focus();
            }
        }
    }
}
