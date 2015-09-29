using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.DL0Logistica.Catalogo
{
    public partial class Frm_color : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;
        private String dominioiddes = "60";
        private DataTable Tablacolor;
        private Boolean procesado = false;

        private String ssModo = string.Empty;

        public Frm_color()
        {
            InitializeComponent();
        }

        private void PARAMETROS_TABLA()
        {
            var xxferfil = string.Empty;
            var xxgrupo = 0;
            var f = (DL0Logistica.MainLogistica)MdiParent;
            xxferfil = f.perfil.ToString();
            xxgrupo = Convert.ToInt32(f.grupo.ToString());
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


        private void data_cbo_moduloiddes()
        {
            var BL = new sys_moduloBL();
            var BE = new tb_sys_modulo();
            var dt = new DataTable();
            BE.dominioid = dominioiddes.Trim();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];

            if (dt.Rows.Count > 0)
            {
                moduloiddes.DataSource = dt;
                moduloiddes.ValueMember = "moduloid";
                moduloiddes.DisplayMember = "moduloname";
            }
        }

        private void get_dominio_modulo_local(string dominioid, string moduloid)
        {
            if (moduloid.ToString().Length == 4)
            {
                var BL = new usuariomodulolocalBL();
                var BE = new tb_usuariomodulolocal();
                var dt = new DataTable();
                BE.usuar = VariablesPublicas.Usuar.Trim();
                BE.dominioid = dominioid;
                BE.moduloid = moduloid;

                dt = BL.GetAll3(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    localdes.DataSource = dt;
                    localdes.ValueMember = "local";
                    localdes.DisplayMember = "localname";
                }
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
            if (modulo.ToString() == "0100")
            {
                colorid.Enabled = false;
                colorname.Enabled = var;
                gridcolor.ReadOnly = true;
                gridcolor.Enabled = !var;
                txt_criterio.Enabled = !var;
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
                btn_clave.Enabled = true;
                btn_log.Enabled = true;
                btn_salir.Enabled = false;
            }
            else
            {
                moduloiddes.Enabled = false;
                localdes.Enabled = false;

                colorid.Enabled = false;
                colorname.Enabled = var;
                gridcolor.ReadOnly = true;
                gridcolor.Enabled = !var;
                txt_criterio.Enabled = !var;
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
                btn_clave.Enabled = true;
                btn_log.Enabled = true;
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
                NIVEL_FORMS();
                limpiar_documento();
                form_bloqueado(false);
                btn_nuevo.Enabled = true;
                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;
                btn_salir.Enabled = true;

                ssModo = string.Empty;
            }
        }

        private void form_cargar_datos(String posicion)
        {
            try
            {
                var BL = new tb_60colorBL();
                var BE = new tb_60color();
                var dt = new DataTable();

                BE.moduloid = moduloiddes.SelectedValue.ToString();

                if (moduloiddes.SelectedValue.ToString() == "0000")
                {
                    MessageBox.Show("Seleccione Almacen", "Information");
                    return;
                }

                if (colorid.Text.Trim().Length > 0)
                {
                    BE.colorid = colorid.Text.Trim().PadLeft(4, '0');
                }
                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    limpiar_documento();
                    ssModo = "EDIT";

                    colorid.Text = dt.Rows[0]["colorid"].ToString().Trim();
                    colorname.Text = dt.Rows[0]["colorname"].ToString().Trim();

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

        private void ValidaColor_nuevo()
        {
            if (colorid.Text.Trim().Length != 3)
            {
                return;
            }
            var BL = new tb_60colorBL();
            var BE = new tb_60color();
            var dt = new DataTable();
            BE.moduloid = moduloiddes.SelectedValue.ToString();
            if (moduloiddes.SelectedValue.ToString() == "0000")
            {
                MessageBox.Show("Seleccione Almacen", "Information");
                return;
            }

            BE.colorid = colorid.Text.Trim();

            dt = BL.GetOne(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                mensaje.Text = "YA EXISTE";
                mensaje.ForeColor = Color.Red;
                colorname.Text = string.Empty;
            }
            else
            {
                mensaje.Text = "VALIDO";
                mensaje.ForeColor = Color.Green;
                colorid.Text = colorid.Text.Trim().ToUpper();
                form_bloqueado(true);
                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
            }
        }

        private void ValidaColor()
        {
            if (colorid.Text.Trim().Length != 3)
            {
                return;
            }
            var BL = new tb_60colorBL();
            var BE = new tb_60color();
            var dt = new DataTable();
            BE.moduloid = moduloiddes.SelectedValue.ToString();
            if (moduloiddes.SelectedValue.ToString() == "0000")
            {
                MessageBox.Show("Seleccione Almacen", "Information");
                return;
            }
            BE.colorid = colorid.Text.Trim();

            dt = BL.GetOne(EmpresaID, BE).Tables[0];
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
                BE.detalle = colorid.Text.Trim() + "/" + colorname.Text.Trim().ToUpper() + "/" + XGLOSA;

                BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiar_documento()
        {
            if (modulo.ToString() == "0100")
            {
                colorid.Text = string.Empty;
                colorname.Text = string.Empty;
                mensaje.Text = string.Empty;
            }
            else
            {
                moduloiddes.SelectedValue = modulo.ToString();
                localdes.SelectedValue = local.ToString();
                colorid.Text = string.Empty;
                colorname.Text = string.Empty;
                mensaje.Text = string.Empty;
            }
        }

        private void nuevo()
        {
            limpiar_documento();
            form_bloqueado(true);
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_log.Enabled = true;
            colorname.Focus();

            ssModo = "NEW";
        }


        private void Insert()
        {
            try
            {
                if (colorname.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese nombre de color", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_60colorBL();
                    var BE = new tb_60color();

                    BE.moduloid = moduloiddes.SelectedValue.ToString();
                    BE.colorname = colorname.Text.ToUpper();
                    BE.usuar = VariablesPublicas.Usuar.Trim();

                    if (BL.Insert(EmpresaID, BE))
                    {
                        MessageBox.Show("Datos grabados correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (colorname.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese nombre de color", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_60colorBL();
                    var BE = new tb_60color();
                    BE.moduloid = moduloiddes.SelectedValue.ToString();
                    BE.colorid = colorid.Text.ToString();
                    BE.colorname = colorname.Text.ToUpper();
                    BE.usuar = VariablesPublicas.Usuar.Trim();

                    if (BL.Update(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("M");
                        MessageBox.Show("Datos modificado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (colorid.Text.Trim().Length != 3)
                {
                    MessageBox.Show("Falta Codigo color !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_60colorBL();
                    var BE = new tb_60color();
                    BE.moduloid = moduloiddes.SelectedValue.ToString();
                    BE.colorid = colorid.Text.Trim().PadLeft(3, '0');
                    BE.colorname = colorname.Text.ToUpper();
                    BE.usuar = VariablesPublicas.Usuar.Trim();

                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos eliminado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        limpiar_documento();
                        form_bloqueado(false);
                        data_Tablacolor();
                        btn_nuevo.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_color_Load(object sender, EventArgs e)
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

            NIVEL_FORMS();
            Tablacolor = new DataTable();
            data_cbo_moduloiddes();
            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_primero.Enabled = true;
            btn_anterior.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_ultimo.Enabled = true;
            btn_salir.Enabled = true;
        }

        private void Frm_color_KeyDown(object sender, KeyEventArgs e)
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

        private void colorid_KeyUp(object sender, KeyEventArgs e)
        {
            if (colorid.Text.Trim().Length == 3)
            {
                if (ssModo == "NEW")
                {
                    ValidaColor_nuevo();
                }
                else
                {
                    ValidaColor();
                }
            }
        }
        private void colorid_LostFocus(object sender, System.EventArgs e)
        {
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
                colorname.Focus();

                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
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
                data_Tablacolor();
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
                if (Tablacolor.Rows.Count > 0)
                {
                    var miForma = new Reportes.Frm_reportes();

                    miForma.dominioid = dominioiddes.Trim();
                    miForma.moduloid = moduloiddes.SelectedValue.ToString().Trim();
                    miForma.local = local.Trim();

                    miForma.Text = "Reporte de colors";
                    miForma.formulario = "Frm_color";
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

        private void data_Tablacolor()
        {
            try
            {
                if (Tablacolor.Rows.Count > 0)
                {
                    Tablacolor.Rows.Clear();
                }
                var BL = new tb_60colorBL();
                var BE = new tb_60color();

                if (moduloiddes.SelectedValue.ToString() == "0000")
                {
                    MessageBox.Show("Seleccione Almacen", "Information");
                    return;
                }

                BE.moduloid = moduloiddes.SelectedValue.ToString();
                BE.colorname = txt_criterio.Text.Trim().ToUpper();

                Tablacolor = BL.GetAll(EmpresaID, BE).Tables[0];
                if (Tablacolor.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    gridcolor.DataSource = Tablacolor;
                    gridcolor.Rows[0].Selected = false;
                    gridcolor.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridcolor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridcolor.CurrentRow != null)
                {
                    var xcolorid = string.Empty;
                    xcolorid = gridcolor.Rows[e.RowIndex].Cells["gcolorid"].Value.ToString().Trim();
                    data_color(xcolorid);
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void gridcolor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xcolorid = string.Empty;
                xcolorid = gridcolor.Rows[gridcolor.CurrentRow.Index].Cells["gcolorid"].Value.ToString().Trim();
                data_color(xcolorid);
            }
        }
        private void gridcolor_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridcolor[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            gridcolor[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            gridcolor.EnableHeadersVisualStyles = false;
            gridcolor.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            gridcolor.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }
        private void gridcolor_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            gridcolor[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }
        private void data_color(String xcolorid)
        {
            form_bloqueado(false);
            var rowcolorid = Tablacolor.Select("colorid='" + xcolorid + "'");
            if (rowcolorid.Length > 0)
            {
                foreach (DataRow row in rowcolorid)
                {
                    colorid.Text = row["colorid"].ToString().Trim();
                    colorname.Text = row["colorname"].ToString().Trim();
                }
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

        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            data_Tablacolor();
        }

        private void btnfijar_Click(object sender, EventArgs e)
        {
            moduloiddes.Enabled = !moduloiddes.Enabled;
        }

        private void txt_criterio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_busqueda_Click(sender, e);
            }
        }

        private void moduloiddes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (moduloiddes.Items.Count > 0)
            {
                get_dominio_modulo_local(dominio.ToString(), moduloiddes.SelectedValue.ToString());
            }
        }
    }
}
