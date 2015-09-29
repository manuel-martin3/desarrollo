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
    public partial class Frm_UndMedida : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable TablaUnidMed;
        private Boolean procesado = false;

        private String ssModo = string.Empty;

        public Frm_UndMedida()
        {
            InitializeComponent();
            undcodigoid.LostFocus += new System.EventHandler(colorid_LostFocus);
        }

        private void PARAMETROS_TABLA()
        {
            var xxferfil = string.Empty;
            var f = (DL0Logistica.MainLogistica)MdiParent;
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

        private void get_tipocambio(String fecha)
        {
            try
            {
                var BL = new tipocambioBL();
                var dt = new DataTable();

                dt = BL.GetOne(EmpresaID, Convert.ToDateTime(fecha)).Tables[0];
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
                undcodigoid.Enabled = !var;
                unidmname.Enabled = var;
                gridunidmed.ReadOnly = true;
                gridunidmed.Enabled = !var;
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

                btn_buscar.Enabled = false;
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
                undcodigoid.Text = string.Empty;
                btn_nuevo.Enabled = true;
                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;
                btn_buscar.Enabled = true;
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

                BE.moduloid = modulo;
                if (undcodigoid.Text.Trim().Length > 0)
                {
                    BE.colorid = undcodigoid.Text.Trim().PadLeft(4, '0');
                }
                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    limpiar_documento();
                    ssModo = "EDIT";

                    undcodigoid.Text = dt.Rows[0]["colorid"].ToString().Trim();
                    unidmname.Text = dt.Rows[0]["colorname"].ToString().Trim();

                    btn_editar.Enabled = true;
                    btn_eliminar.Enabled = true;
                    btn_imprimir.Enabled = true;

                    btn_primero.Enabled = true;
                    btn_anterior.Enabled = true;
                    btn_siguiente.Enabled = true;
                    btn_ultimo.Enabled = true;

                    btn_buscar.Enabled = true;
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
            if (undcodigoid.Text.Trim().Length != 2)
            {
                return;
            }
            var BL = new tb_co_tabla06_unidadmedidaBL();

            var dt = new DataTable();

            var codigo = undcodigoid.Text.Trim();

            dt = BL.GetOne(EmpresaID, codigo).Tables[0];

            if (dt.Rows.Count > 0)
            {
                mensaje.Text = "YA EXISTE";
                mensaje.ForeColor = Color.Red;
                unidmname.Text = string.Empty;
                siglaname.Text = string.Empty;
            }
            else
            {
                mensaje.Text = "VALIDO";
                mensaje.ForeColor = Color.Green;
                undcodigoid.Text = undcodigoid.Text.Trim().ToUpper();
                unidmname.Focus();
                form_bloqueado(true);
                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
            }
        }

        private void ValidaColor()
        {
            if (undcodigoid.Text.Trim().Length != 2)
            {
                return;
            }
            var BL = new tb_co_tabla06_unidadmedidaBL();
            var dt = new DataTable();

            var codigo = undcodigoid.Text.Trim();

            dt = BL.GetOne(EmpresaID, codigo).Tables[0];
            if (dt.Rows.Count > 0)
            {
                undcodigoid.Text = dt.Rows[0]["codigoid"].ToString().Trim();
                unidmname.Text = dt.Rows[0]["descripcion"].ToString().Trim();
                siglaname.Text = dt.Rows[0]["sigla"].ToString().Trim();
            }
            else
            {
                undcodigoid.Text = string.Empty;
                unidmname.Text = string.Empty;
                siglaname.Text = string.Empty;
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
                BE.detalle = undcodigoid.Text.Trim() + "/" + unidmname.Text.Trim().ToUpper() + "/" + XGLOSA;

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
                undcodigoid.Text = string.Empty;
                unidmname.Text = string.Empty;
                siglaname.Text = string.Empty;
                mensaje.Text = string.Empty;
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
            undcodigoid.Enabled = true;
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_log.Enabled = true;
            unidmname.Focus();

            ssModo = "NEW";
        }
        private void Insert()
        {
            try
            {
                if (undcodigoid.Text.Trim().Length != 2)
                {
                    MessageBox.Show("Falta Codigo !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (unidmname.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese unidad de medida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new tb_co_tabla06_unidadmedidaBL();
                        var BE = new tb_co_tabla06_unidadmedida();

                        BE.codigoid = undcodigoid.Text.Trim().ToUpper();
                        BE.descripcion = unidmname.Text.Trim().ToUpper();
                        BE.sigla = siglaname.Text.ToUpper();
                        BE.usuar = VariablesPublicas.Usuar.Trim();

                        if (BL.Insert(EmpresaID, BE))
                        {
                            MessageBox.Show("Datos grabados correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void Update()
        {
            try
            {
                if (undcodigoid.Text.Trim().Length != 2)
                {
                    MessageBox.Show("Falta Codigo !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (unidmname.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese unidad de medida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new tb_co_tabla06_unidadmedidaBL();
                        var BE = new tb_co_tabla06_unidadmedida();

                        BE.codigoid = undcodigoid.Text.Trim().ToUpper();
                        BE.descripcion = unidmname.Text.Trim().ToUpper();
                        BE.sigla = siglaname.Text.ToUpper();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Delete()
        {
            try
            {
                if (undcodigoid.Text.Trim().Length != 2)
                {
                    MessageBox.Show("Falta Codigo !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_co_tabla06_unidadmedidaBL();
                    var BE = new tb_co_tabla06_unidadmedida();

                    BE.codigoid = undcodigoid.Text.Trim().ToUpper();
                    BE.descripcion = unidmname.Text.Trim().ToUpper();
                    BE.sigla = siglaname.Text.ToUpper();
                    BE.usuar = VariablesPublicas.Usuar.Trim();

                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos eliminado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        limpiar_documento();
                        form_bloqueado(false);
                        data_TablaUnidMed();
                        btn_nuevo.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_color_Activated(object sender, EventArgs e)
        {
        }
        private void Frm_color_Load(object sender, EventArgs e)
        {
            modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
            local = ((D60ALMACEN.MainAlmacen)MdiParent).local;

            undcodigoid.CharacterCasing = CharacterCasing.Upper;
            unidmname.CharacterCasing = CharacterCasing.Upper;

            PARAMETROS_TABLA();
            NIVEL_FORMS();

            TablaUnidMed = new DataTable();

            limpiar_documento();
            data_TablaUnidMed();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_primero.Enabled = true;
            btn_anterior.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_ultimo.Enabled = true;
            btn_buscar.Enabled = true;
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
            if (undcodigoid.Text.Trim().Length == 2)
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
            form_cargar_datos(string.Empty);
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
                unidmname.Focus();

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
                data_TablaUnidMed();
                form_bloqueado(false);

                btn_nuevo.Enabled = true;

                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;

                btn_buscar.Enabled = true;
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
                if (TablaUnidMed.Rows.Count > 0)
                {
                    var miForma = new Reportes.Frm_reportes();

                    miForma.dominioid = dominio.Trim();
                    miForma.moduloid = modulo.Trim();
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

        private void data_TablaUnidMed()
        {
            try
            {
                if (TablaUnidMed.Rows.Count > 0)
                {
                    TablaUnidMed.Rows.Clear();
                }
                var BL = new tb_co_tabla06_unidadmedidaBL();
                var BE = new tb_co_tabla06_unidadmedida();

                BE.descripcion = txt_criterio.Text.Trim().ToUpper();

                TablaUnidMed = BL.GetAll(EmpresaID, BE).Tables[0];
                if (TablaUnidMed.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    gridunidmed.DataSource = TablaUnidMed;
                    gridunidmed.Rows[0].Selected = false;
                    gridunidmed.Focus();
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
                if (gridunidmed.CurrentRow != null)
                {
                    var xcolorid = string.Empty;
                    xcolorid = gridunidmed.Rows[e.RowIndex].Cells["codigoid"].Value.ToString().Trim();
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
                var xcodigoid = string.Empty;
                xcodigoid = gridunidmed.Rows[gridunidmed.CurrentRow.Index].Cells["codigoid"].Value.ToString().Trim();
                data_color(xcodigoid);
            }
        }
        private void gridcolor_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridunidmed.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridunidmed[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(39, 95, 178);
            gridunidmed[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);
        }
        private void gridcolor_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            gridunidmed[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }
        private void data_color(String xcodigoid)
        {
            form_bloqueado(false);
            var rowcolorid = TablaUnidMed.Select("codigoid='" + xcodigoid + "'");
            if (rowcolorid.Length > 0)
            {
                foreach (DataRow row in rowcolorid)
                {
                    undcodigoid.Text = row["codigoid"].ToString().Trim();
                    unidmname.Text = row["descripcion"].ToString().Trim();
                    siglaname.Text = row["sigla"].ToString().Trim();
                }
                btn_nuevo.Enabled = true;
                btn_editar.Enabled = true;
                btn_eliminar.Enabled = true;
                btn_imprimir.Enabled = true;

                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;

                btn_buscar.Enabled = true;
                btn_log.Enabled = true;
                btn_salir.Enabled = true;
            }
        }

        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            data_TablaUnidMed();
        }

        private void siglaname_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
