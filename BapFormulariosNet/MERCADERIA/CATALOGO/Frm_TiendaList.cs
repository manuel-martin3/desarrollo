using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.MERCADERIA.CATALOGO
{
    public partial class Frm_TiendaList : plantilla
    {
        private String EmpresaID = string.Empty;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable TablaTienda;
        private DataTable TablaTiendaItem;
        private Boolean procesado = false;

        private String ssModo = "NEW";

        public Frm_TiendaList()
        {
            InitializeComponent();
            tiendalist.LostFocus += new System.EventHandler(grupoid_LostFocus);
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
                tiendalist.Enabled = !var;
                localname.Enabled = false;
                locid.Enabled = var;
                tiendalistname.Enabled = var;

                tiendalist2.Enabled = false;
                tiendaname2.Enabled = false;

                gridtienda.ReadOnly = true;
                gridtienda.Enabled = !var;


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

                btn_clave.Enabled = true;
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
                tiendalist.Text = string.Empty;
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
                var BL = new tb_me_tiendaBL();
                var BE = new tb_me_tienda();

                var dt = new DataTable();

                if (tiendalist.Text.Trim().Length > 0)
                {
                    BE.tiendalist = Convert.ToInt32(tiendalist.Text);
                }
                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    limpiar_documento();
                    ssModo = "EDIT";

                    tiendalist.Text = dt.Rows[0]["tiendalist"].ToString().Trim();
                    localname.Text = dt.Rows[0]["tiendaname"].ToString().Trim();

                    btn_editar.Enabled = true;
                    btn_eliminar.Enabled = true;
                    btn_imprimir.Enabled = true;

                    btn_primero.Enabled = true;
                    btn_anterior.Enabled = true;
                    btn_siguiente.Enabled = true;
                    btn_ultimo.Enabled = true;
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
                BE.detalle = tiendalist.Text.Trim() + "/" + localname.Text.Trim().ToUpper() + "/" + XGLOSA;

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
                tiendalist.Text = string.Empty;
                tiendalistname.Text = string.Empty;
                tiendalist2.Text = string.Empty;
                tiendaname2.Text = string.Empty;
                localname.Text = string.Empty;
                locid.Text = string.Empty;
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
            tiendalist.Text = "NEW";
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            localname.Focus();

            ssModo = "NEW";
        }
        private void Insert()
        {
            try
            {
                if (tiendalistname.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese Nombre de Tienda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_me_tiendaBL();
                    var BE = new tb_me_tienda();

                    BE.tiendalistname = tiendalistname.Text.Trim().ToString();
                    BE.usuar = VariablesPublicas.Usuar.Trim();
                    BE.local = locid.Text.ToString();

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
                if (tiendalist.Text.ToString() == string.Empty)
                {
                    MessageBox.Show("Falta Codigo Tienda !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (localname.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese Nombre de Tienda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new tb_me_tiendaBL();
                        var BE = new tb_me_tienda();

                        BE.tiendalist = Convert.ToInt32(tiendalist.Text);
                        BE.tiendalistname = tiendalistname.Text.Trim().ToString();
                        BE.usuar = VariablesPublicas.Usuar.Trim();

                        if (BL.Update(EmpresaID, BE))
                        {
                            SEGURIDAD_LOG("M");
                            MessageBox.Show("Datos Modificado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            procesado = true;
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
                if (tiendalist.Text.ToString() == string.Empty)
                {
                    MessageBox.Show("Falta Codigo Tienda !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    var BL = new tb_me_tiendaBL();
                    var BE = new tb_me_tienda();

                    BE.tiendalist = Convert.ToInt32(tiendalist.Text);

                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos Eliminado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        form_bloqueado(false);
                        data_TablaTienda();
                        btn_nuevo.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void Frm_grupo_Activated(object sender, EventArgs e)
        {
        }
        private void Frm_TiendaList_Load(object sender, EventArgs e)
        {
            EmpresaID = VariablesPublicas.EmpresaID;
            switch (Parent.Parent.Name)
            {
                case "MainAlmacen":
                    dominio = ((D60ALMACEN.MainAlmacen)MdiParent).dominioid;
                    modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
                    local = ((D60ALMACEN.MainAlmacen)MdiParent).local;
                    PERFILID = ((D60ALMACEN.MainAlmacen)MdiParent).perfil;
                    break;
                case "MainMercaderia":
                    dominio = ((MERCADERIA.MainMercaderia)MdiParent).dominioid;
                    modulo = ((MERCADERIA.MainMercaderia)MdiParent).moduloid;
                    local = ((MERCADERIA.MainMercaderia)MdiParent).local;
                    PERFILID = ((MERCADERIA.MainMercaderia)MdiParent).perfil;
                    break;
                default:
                    break;
            }
            //PARAMETROS_TABLA();
            NIVEL_FORMS();

            TablaTienda = new DataTable();
            localname.CharacterCasing = CharacterCasing.Upper;
            tiendalistname.CharacterCasing = CharacterCasing.Upper;
            limpiar_documento();
            data_TablaTienda();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_primero.Enabled = true;
            btn_anterior.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_ultimo.Enabled = true;
            btn_salir.Enabled = true;
        }
        private void Frm_TiendaList_KeyDown(object sender, KeyEventArgs e)
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
        }

        private void grupoid_LostFocus(object sender, System.EventArgs e)
        {
            form_cargar_datos(string.Empty);
        }
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
            {
                nuevo();
                btn_new.Enabled = false;
                btn_add.Enabled = false;
                locid.Enabled = false;
                control.SelectedIndex = 0;
                ((Control)tab02).Enabled = false;
            }
        }
        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0")
            {
                ssModo = "EDIT";
                form_bloqueado(true);
                localname.Focus();

                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
            }
        }
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            form_accion_cancelEdicion(1);
            ((Control)tab02).Enabled = true;
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
                               ((Control)tab02).Enabled = true;
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
                data_TablaTienda();
                form_bloqueado(false);
                limpiar_documento();
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
                    if (control.SelectedTab == control.TabPages[0])
                    {
                        Delete();
                    }
                    if (control.SelectedTab == control.TabPages[1])
                    {
                        if (locid.Text.ToString() == string.Empty)
                        {
                            MessageBox.Show("Falta Codigo Local !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            var BL = new tb_me_tiendaBL();
                            var BE = new tb_me_tienda();

                            BE.local = locid.Text.ToString();
                            BE.tiendalist = Convert.ToInt32(tiendalist2.Text);

                            if (BL.DeleteItem(EmpresaID, BE))
                            {
                                SEGURIDAD_LOG("E");
                                MessageBox.Show("Datos Eliminado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                NIVEL_FORMS();
                                form_bloqueado(false);
                                limpiar_documento();
                                data_TablaTiendaItem();
                                btn_nuevo.Enabled = true;
                            }
                        }
                    }
                }
            }
        }
        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (TablaTienda.Rows.Count > 0)
                {
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
        private void btn_log_Click(object sender, EventArgs e)
        {
            var oform = new Seguridadlog.FrmSeguridad();
            var xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio;
            oform._Nombre = Name;
            oform._ClaveForm = xclave;
            oform.Owner = this;
            oform.ShowDialog();
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void data_TablaTienda()
        {
            try
            {
                var BL = new tb_me_tiendaBL();
                var BE = new tb_me_tienda();

                BE.filtro = "1";

                TablaTienda = BL.GetAll(EmpresaID, BE).Tables[0];
                if (TablaTienda.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    gridtienda.DataSource = TablaTienda;
                    gridtienda.Rows[0].Selected = false;
                    gridtienda.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void gridgrupo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridtienda.CurrentRow != null)
                {
                    var xtiendalist = string.Empty;
                    xtiendalist = gridtienda.Rows[e.RowIndex].Cells["g1tiendalist"].Value.ToString().Trim();
                    data_Tienda(xtiendalist);

                    tiendalist.Enabled = false;
                }
            }
            catch (Exception)
            {
            }
        }

        private void gridgrupo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xtiendalist = string.Empty;
                xtiendalist = gridtienda.Rows[gridtienda.CurrentRow.Index].Cells["g1tiendalist"].Value.ToString().Trim();
                data_Tienda(xtiendalist);
                tiendalist.Enabled = false;
            }
        }

        private void gridgrupo_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridtienda[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            gridtienda[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            gridtienda.EnableHeadersVisualStyles = false;
            gridtienda.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            gridtienda.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }
        private void gridgrupo_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            gridtienda[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }
        private void data_Tienda(String xtiendalist)
        {
            form_bloqueado(false);
            var rowtiendalist = TablaTienda.Select("tiendalist='" + xtiendalist + "'");
            if (rowtiendalist.Length > 0)
            {
                foreach (DataRow row in rowtiendalist)
                {
                    tiendalist.Text = row["tiendalist"].ToString().Trim();
                    tiendalistname.Text = row["tiendalistname"].ToString().Trim();

                    tiendalist2.Text = row["tiendalist"].ToString().Trim();
                    tiendaname2.Text = row["tiendalistname"].ToString().Trim();
                }

                LlenarGrid_Tiendalistitem();

                btn_nuevo.Enabled = true;
                btn_editar.Enabled = true;
                btn_eliminar.Enabled = true;
                btn_imprimir.Enabled = true;

                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;
                btn_salir.Enabled = true;
            }
        }

        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            data_TablaTienda();
        }

        private void data_TiendaItem(String xtiendalist, String xlocal)
        {
            form_bloqueado(false);
            var rowtiendalist = TablaTiendaItem.Select("tiendalist='" + xtiendalist + "' and local= '" + xlocal + "' ");
            if (rowtiendalist.Length > 0)
            {
                foreach (DataRow row in rowtiendalist)
                {
                    tiendalist2.Text = row["tiendalist"].ToString().Trim();
                    tiendaname2.Text = row["tiendaname"].ToString().Trim();
                    locid.Text = row["local"].ToString().Trim();
                    localname.Text = row["localname"].ToString().Trim();
                }

                btn_nuevo.Enabled = true;
                btn_editar.Enabled = true;
                btn_eliminar.Enabled = true;
                btn_imprimir.Enabled = true;

                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;
                btn_salir.Enabled = true;
            }
        }

        private void data_TablaTiendaItem()
        {
            try
            {
                var BL = new tb_me_tiendaBL();
                var BE = new tb_me_tienda();

                BE.tiendalist = Convert.ToInt32(tiendalist2.Text);
                BE.filtro = "3";

                TablaTiendaItem = BL.GetAll(EmpresaID, BE).Tables[0];
                if (TablaTiendaItem.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    dgb_tiendaitem.DataSource = TablaTiendaItem;
                    dgb_tiendaitem.Rows[0].Selected = false;
                    dgb_tiendaitem.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void txt_criterio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btn_busqueda_Click(sender, e);
            }
        }

        private void locid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudasysLocal(string.Empty);
            }
        }

        private void AyudasysLocal(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all";
                frmayuda.titulo = "<< AYUDA  TABLA DOMINIO >>";
                frmayuda.sqlquery = "SELECT local,localname FROM tb_sys_local";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where dominioid = '60' and moduloid = '" + modulo.ToString() + "' ";
                frmayuda.sqland = "and";
                frmayuda.criteriosbusqueda = new string[] { "LOCAL", "CODIGO" };
                frmayuda.columbusqueda = "localname,local";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeSysLocal;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }


        private void RecibeSysLocal(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                locid.Text = resultado1.Trim();
                localname.Text = resultado2.ToString();
            }
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            locid.Text = string.Empty;
            localname.Text = string.Empty;
            locid.Enabled = true;
            locid.Focus();
            btn_nuevo.Enabled = false;
            btn_eliminar.Enabled = false;
            btn_imprimir.Enabled = false;

            btn_editar.Enabled = false;
            btn_cancelar.Enabled = true;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Insert_Item();
            data_TablaTiendaItem();

            btn_editar.Enabled = true;
        }

        private void Insert_Item()
        {
            try
            {
                if (tiendalist2.Text == string.Empty)
                {
                    MessageBox.Show("Debe de Seleccionar un Codigo de Tienda Para Asignarle Item !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (locid.Text == string.Empty)
                {
                    MessageBox.Show("Falta Codigo Local !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_me_tiendaBL();
                    var BE = new tb_me_tienda();

                    BE.tiendalist = Convert.ToInt32(tiendalist2.Text);
                    BE.local = locid.Text.ToString();
                    BE.usuar = VariablesPublicas.Usuar.Trim();

                    if (BL.Insert_Item(EmpresaID, BE))
                    {
                        MessageBox.Show("Datos Adicionados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        procesado = true;
                        locid.Text = string.Empty;
                        localname.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void control_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (control.SelectedIndex == 1)
            {
                btn_grabar.Enabled = false;
                btn_new.Enabled = true;
                btn_add.Enabled = true;
            }

            if (control.SelectedIndex == 0)
            {
                if (btn_nuevo.Enabled == false)
                {
                    btn_grabar.Enabled = true;
                }
                data_TablaTienda();
            }
        }

        private void dgb_tiendaitem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgb_tiendaitem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgb_tiendaitem.CurrentRow != null)
                {
                    var xtiendalist = string.Empty;
                    var xlocal = string.Empty;
                    xtiendalist = dgb_tiendaitem.Rows[e.RowIndex].Cells["g2tiendalist"].Value.ToString().Trim();
                    xlocal = dgb_tiendaitem.Rows[e.RowIndex].Cells["g2local"].Value.ToString().Trim();
                    data_TiendaItem(xtiendalist, xlocal);

                    tiendalist.Enabled = false;
                    btn_new.Enabled = false;
                    btn_add.Enabled = false;
                }
            }
            catch (Exception)
            {
            }
        }



        private void dgb_tiendaitem_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xtiendalist = string.Empty;
                var xlocal = string.Empty;
                xtiendalist = dgb_tiendaitem.Rows[dgb_tiendaitem.CurrentRow.Index].Cells["g2tiendalist"].Value.ToString().Trim();
                xlocal = dgb_tiendaitem.Rows[dgb_tiendaitem.CurrentRow.Index].Cells["g2local"].Value.ToString().Trim();
                data_TiendaItem(xtiendalist, xlocal);
                tiendalist.Enabled = false;
                btn_new.Enabled = false;
                btn_add.Enabled = false;
            }
        }



        private void cbo_tienda_SelectedIndexChanged(object sender, EventArgs e)
        {
        }


        private void LlenarGrid_Tiendalistitem()
        {
            try
            {
                var BL = new tb_me_tiendaBL();
                var BE = new tb_me_tienda();

                BE.tiendalist = Convert.ToInt32(tiendalist2.Text);
                BE.filtro = "3";

                TablaTiendaItem = BL.GetAll(EmpresaID, BE).Tables[0];
                if (TablaTiendaItem.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    dgb_tiendaitem.DataSource = TablaTiendaItem;
                    dgb_tiendaitem.Rows[0].Selected = false;
                    dgb_tiendaitem.Focus();
                }
                else
                {
                    dgb_tiendaitem.DataSource = TablaTiendaItem;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
