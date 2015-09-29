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
    public partial class Frm_familiateladet : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable Tablafamiliateladet;
        private Boolean procesado = false;

        private String ssModo = "NEW";

        public Frm_familiateladet()
        {
            InitializeComponent();
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
                familiatelaid.Enabled = var;
                familiatelaname.Enabled = false;
                productid.Enabled = var;
                productname.Enabled = false;

                estructuraid.Enabled = false;
                tejidoid.Enabled = false;

                gridfamiliateladet.ReadOnly = true;
                gridfamiliateladet.Enabled = !var;
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
                sw_prosigue = (MessageBox.Show("Desea cancelar Ingreso de Datos...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
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
                familiatelaid.Text = string.Empty;
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
                var BL = new tb_pt_familiadetBL();
                var BE = new tb_pt_familiadet();
                var dt = new DataTable();
                if (familiatelaid.Text.Trim().Length > 0)
                {
                    BE.familiaid = familiatelaid.Text.Trim().PadLeft(3, '0');
                }
                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    limpiar_documento();
                    ssModo = "EDIT";

                    familiatelaid.Text = dt.Rows[0]["familiatelaid"].ToString().Trim();
                    familiatelaname.Text = dt.Rows[0]["familiatelaname"].ToString().Trim();
                    estructuraid.SelectedValue = dt.Rows[0]["estructuraid"].ToString().Trim();
                    data_cbo_tejidoid();
                    tejidoid.SelectedValue = dt.Rows[0]["lineaid"].ToString().Trim();

                    btn_editar.Enabled = false;
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
                BE.detalle = familiatelaid.Text.Trim() + "/" + familiatelaname.Text.Trim().ToUpper()  + "/" + XGLOSA;

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
                familiatelaid.Text = string.Empty;
                familiatelaname.Text = string.Empty;
                productid.Text = string.Empty;
                productname.Text = string.Empty;
                estructuraid.SelectedIndex = -1;
                tejidoid.SelectedIndex = -1;
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
            familiatelaid.Text = string.Empty;
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_log.Enabled = true;
            familiatelaname.Focus();

            ssModo = "NEW";
        }

        private void Insert()
        {
            try
            {
                if (familiatelaid.Text.Trim().Length != 3)
                {
                    MessageBox.Show("Falta Codigo Familia !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (familiatelaname.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese Nombre de Familia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new tb_pt_familiadetBL();
                        var BE = new tb_pt_familiadet();

                        BE.familiaid = familiatelaid.Text.Trim().PadLeft(3, '0');
                        BE.productid = productid.Text.ToUpper();
                        if (tejidoid.SelectedValue != null && tejidoid.Text.Trim().Length > 0)
                        {
                            BE.lineaid = tejidoid.SelectedValue.ToString();
                        }
                        BE.usuar = VariablesPublicas.Usuar.Trim();

                        if (BL.Insert(EmpresaID, BE))
                        {
                            MessageBox.Show("Datos Grabados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (familiatelaid.Text.Trim().Length != 3)
                {
                    MessageBox.Show("Falta Codigo Familia !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (familiatelaname.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese Nombre de Familia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new tb_pt_familiadetBL();
                        var BE = new tb_pt_familiadet();

                        BE.familiaid = familiatelaid.Text.Trim().PadLeft(3, '0');
                        if (tejidoid.SelectedValue != null && tejidoid.Text.Trim().Length > 0)
                        {
                            BE.lineaid = tejidoid.SelectedValue.ToString();
                        }
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
                if (familiatelaid.Text.Trim().Length != 3)
                {
                    MessageBox.Show("Falta Codigo Familia !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_pt_familiadetBL();
                    var BE = new tb_pt_familiadet();
                    BE.familiaid = familiatelaid.Text.Trim().PadLeft(3, '0');
                    BE.lineaid = tejidoid.SelectedValue.ToString();
                    BE.productid = productid.Text;
                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos eliminados correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        form_bloqueado(false);
                        data_Tablafamiliateladet();
                        btn_nuevo.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_familiateladet_Load(object sender, EventArgs e)
        {
            modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
            local = ((D60ALMACEN.MainAlmacen)MdiParent).local;

            NIVEL_FORMS();
            Tablafamiliateladet = new DataTable();

            familiatelaname.CharacterCasing = CharacterCasing.Upper;
            data_cbo_estructuraid();
            data_Tablafamiliateladet();
            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_primero.Enabled = true;
            btn_anterior.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_ultimo.Enabled = true;
            btn_salir.Enabled = true;
        }

        private void Frm_familiateladet_KeyDown(object sender, KeyEventArgs e)
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

        private void familiateladetid_LostFocus(object sender, System.EventArgs e)
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
                familiatelaname.Focus();

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
                data_Tablafamiliateladet();
                form_bloqueado(false);
                familiatelaid.Text = string.Empty;
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
                if (Tablafamiliateladet.Rows.Count > 0)
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
        }
        private void btn_anterior_Click(object sender, EventArgs e)
        {
        }
        private void btn_siguiente_Click(object sender, EventArgs e)
        {
        }
        private void btn_ultimo_Click(object sender, EventArgs e)
        {
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

        private void data_Tablafamiliateladet()
        {
            try
            {
                if (Tablafamiliateladet.Rows.Count > 0)
                {
                    Tablafamiliateladet.Rows.Clear();
                }
                var BL = new tb_pt_familiadetBL();
                var BE = new tb_pt_familiadet();

                BE.familianame = txt_criterio.Text.Trim().ToUpper();

                Tablafamiliateladet = BL.GetAll(EmpresaID, BE).Tables[0];
                if (Tablafamiliateladet.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;

                    mdi_dgb_familia.DataSource = Tablafamiliateladet;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridfamiliateladet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridfamiliateladet.CurrentRow != null)
                {
                    var xfamiliateladetid = string.Empty;
                    xfamiliateladetid = gridfamiliateladet.Rows[e.RowIndex].Cells["gfamiliatelaid"].Value.ToString().Trim();
                    data_familiateladet(xfamiliateladetid);
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void gridfamiliateladet_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xfamiliateladetid = string.Empty;
                xfamiliateladetid = gridfamiliateladet.Rows[gridfamiliateladet.CurrentRow.Index].Cells["gfamiliatelaid"].Value.ToString().Trim();
                data_familiateladet(xfamiliateladetid);
            }
        }

        private void gridfamiliateladet_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridfamiliateladet[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.DodgerBlue;
            gridfamiliateladet[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            gridfamiliateladet.EnableHeadersVisualStyles = false;
            gridfamiliateladet.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            gridfamiliateladet.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void gridfamiliateladet_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            gridfamiliateladet[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }

        private void data_familiateladet(String xfamiliateladetid)
        {
            form_bloqueado(false);
            var rowfamiliateladetid = Tablafamiliateladet.Select("familiatelaid='" + xfamiliateladetid + "'");
            if (rowfamiliateladetid.Length > 0)
            {
                foreach (DataRow row in rowfamiliateladetid)
                {
                    familiatelaid.Text = row["familiatelaid"].ToString().Trim();
                    familiatelaname.Text = row["familiatelaname"].ToString().Trim();
                    productid.Text = row["productid"].ToString().Trim();
                    productname.Text = row["productname"].ToString().Trim();
                    estructuraid.SelectedValue = row["estructuraid"].ToString().Trim();
                    data_cbo_tejidoid();
                    tejidoid.SelectedValue = row["lineaid"].ToString().Trim();
                    btn_nuevo.Enabled = true;
                    btn_editar.Enabled = false;
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

        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            data_Tablafamiliateladet();
        }

        private void txt_criterio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_busqueda_Click(sender, e);
            }
        }

        private void data_cbo_estructuraid()
        {
            var BL = new tb_ta_estructuraBL();
            var BE = new tb_ta_estructura();
            try
            {
                estructuraid.DataSource = BL.GetAll(EmpresaID, BE).Tables[0];
                estructuraid.ValueMember = "estructuraid";
                estructuraid.DisplayMember = "estructuraname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void data_cbo_tejidoid()
        {
            var BL = new tb_60lineaBL();
            var BE = new tb_60linea();

            BE.moduloid = "0320";
            BE.estructuraid = estructuraid.SelectedValue.ToString();
            try
            {
                tejidoid.DataSource = BL.GetAll(EmpresaID, BE).Tables[0];
                tejidoid.ValueMember = "lineaid";
                tejidoid.DisplayMember = "lineaname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void estructuraid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (estructuraid.SelectedIndex >= 0)
            {
                data_cbo_tejidoid();
            }
        }

        private void femiliatelaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaFamilia(string.Empty);
            }
        }

        private void productid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaProducto(string.Empty);
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
                BE.moduloid = "0320";
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();

                        var frmayuda = new Ayudas.Frm_help_general();
                        frmayuda.nameform = "color";
                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA TABLA PRODUCTOS >>";
                        frmayuda.sqlquery = "SELECT tb1.productid, tb1.productname,tb2.lineaname,tb3.gruponame,tb1.productidold FROM tb_" + modd + "_productos AS tb1 ";
                        frmayuda.sqlinner = "inner join tb_" + modd + "_linea as tb2 on tb1.lineaid = tb2.lineaid " +
                                            "inner join tb_" + modd + "_grupo as tb3 on tb1.grupoid = tb3.grupoid";
                        frmayuda.sqlwhere = "where tb1.status = '0' ";
                        frmayuda.sqland = "and";
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

        private void RecibeProducto(String xproductid, String xproductname, String resultado3, String resultado4, String resultado5)
        {
            try
            {
                if (xproductid.Trim().Length == 13)
                {
                    productid.Text = xproductid;
                    productname.Text = xproductname;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AyudaFamilia(String lpdescrlike)
        {
            try
            {
                var modd = string.Empty;
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();

                BE.dominioid = dominio.Trim();
                BE.moduloid = "0320";
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();

                        var frmayuda = new Ayudas.Frm_help_general();
                        frmayuda.nameform = "color";
                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA TABLA FAMILIA - TELA >>";
                        frmayuda.sqlquery = " SELECT es.estructuraid,te.lineaid,te.familiatelaid,(es.estructuraname+'-'+li.lineaname+'-'+te.familiatelaname)familia " +
                                            " FROM tb_" + modd + "_familiatela te ";
                        frmayuda.sqlinner = " LEFT JOIN tb_" + modd + "_linea li ON te.lineaid = li.lineaid " +
                                            " LEFT JOIN tb_" + modd + "_estructura es ON es.estructuraid = li.estructuraid ";
                        frmayuda.sqlwhere = " where";
                        frmayuda.criteriosbusqueda = new string[] { "FAMILIA", "CODIGO" };
                        frmayuda.columbusqueda = "te.familiatelaname,te.familiatelaid";
                        frmayuda.returndatos = "0,1,2,3";

                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeFamilia;
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void RecibeFamilia(String xestructuraid, String xlineaid, String xfamiliatelaid, String xfamiliatelaname, String resultado5)
        {
            try
            {
                if (xlineaid.Trim().Length == 3)
                {
                    familiatelaid.Text = xfamiliatelaid;
                    familiatelaname.Text = xfamiliatelaname;
                    estructuraid.SelectedValue = xestructuraid;
                    tejidoid.SelectedValue = xlineaid;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mdi_dgb_familia_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xfamiliateladetid = dgb_familia.GetRowCellValue(dgb_familia.FocusedRowHandle, "familiatelaid").ToString();
                data_familiateladet(xfamiliateladetid);
            }
        }

        private void dgb_familia_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var xfamiliateladetid = dgb_familia.GetRowCellValue(e.RowHandle, "familiatelaid").ToString();
            data_familiateladet(xfamiliateladetid);
        }

        private void ExpGridExcel_Click(object sender, EventArgs e)
        {
            if (sfdfamilia.ShowDialog(this) == DialogResult.OK)
            {
                dgb_familia.ExportToXls(sfdfamilia.FileName);
            }
        }
    }
}
