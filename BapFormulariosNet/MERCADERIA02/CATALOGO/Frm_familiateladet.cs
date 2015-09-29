using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.MERCADERIA02.CATALOGO
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

        private DataTable Tablafamiliadet;
        private DataTable Tablafamilia;
        private DataRow row;
        private Boolean procesado = false;

        private String ssModo = "NEW";

        public Frm_familiateladet()
        {
            InitializeComponent();
        }

        private void PARAMETROS_TABLA()
        {
            var xxferfil = string.Empty;
            var f = (MainMercaderia02)MdiParent;
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
                familiaid.Enabled = false;
                familianame.Enabled = var;
                cboModuloID.Enabled = var;
                tejidoid.Enabled = var;
                unmed.Enabled = var;

                txt_criterio.Enabled = !var;
                btn_busqueda.Enabled = !var;
                btn_save.Enabled = false;

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
                familiaid.Text = string.Empty;
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

                BE.moduloid = cboModuloID.SelectedValue.ToString();
                if (familiaid.Text.Trim().Length > 0)
                {
                    BE.familiaid = familiaid.Text.Trim().PadLeft(3, '0');
                }
                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    limpiar_documento();
                    ssModo = "EDIT";

                    familiaid.Text = dt.Rows[0]["familiatelaid"].ToString().Trim();
                    familianame.Text = dt.Rows[0]["familiatelaname"].ToString().Trim();
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
                BE.detalle = familiaid.Text.Trim() + "/" + familianame.Text.Trim().ToUpper()  + "/" + XGLOSA;

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
                cboModuloID.SelectedIndex = -1;
                tejidoid.SelectedIndex = -1;
                familiaid.Text = string.Empty;
                familianame.Text = string.Empty;
                unmed.Text = string.Empty;

                if (Tablafamiliadet.Rows.Count > 0)
                {
                    Tablafamiliadet.Rows.Clear();
                    mdi_dgb_familia.DataSource = Tablafamiliadet;
                }
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
            familiaid.Text = string.Empty;
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_log.Enabled = true;
            familianame.Focus();

            ssModo = "NEW";
        }

        private void Insert()
        {
            try
            {
                if (cboModuloID.SelectedIndex == -1)
                {
                    MessageBox.Show("Falta Escoger el Modulo !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (familianame.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese Nombre de Familia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (unmed.Text.Trim().Length == 0)
                        {
                            MessageBox.Show("Ingrese Unidad de Medida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            var BL = new tb_pt_familiaBL();
                            var BE = new tb_pt_familia();

                            BE.moduloid = cboModuloID.SelectedValue.ToString();
                            BE.familiaid = familiaid.Text.Trim().PadLeft(3, '0');
                            BE.familianame = familianame.Text.ToUpper().ToUpper();
                            if (tejidoid.SelectedValue != null && tejidoid.Text.Trim().Length > 0)
                            {
                                BE.lineaid = tejidoid.SelectedValue.ToString();
                            }
                            BE.usuar = VariablesPublicas.Usuar.Trim();
                            BE.unmed = unmed.Text.Trim();

                            if (BL.Insert(EmpresaID, BE))
                            {
                                MessageBox.Show("Datos Grabados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (familiaid.Text.Trim().Length != 3)
                {
                    MessageBox.Show("Falta Codigo Familia !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (familianame.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese Nombre de Familia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (unmed.Text.Trim().Length == 0)
                        {
                            MessageBox.Show("Ingrese Unidad de Medida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            var BL = new tb_pt_familiaBL();
                            var BE = new tb_pt_familia();

                            BE.moduloid = cboModuloID.SelectedValue.ToString();
                            BE.familiaid = familiaid.Text.Trim().PadLeft(3, '0');
                            BE.familianame = familianame.Text.ToUpper();
                            if (tejidoid.SelectedValue != null && tejidoid.Text.Trim().Length > 0)
                            {
                                BE.lineaid = tejidoid.SelectedValue.ToString();
                            }
                            BE.usuar = VariablesPublicas.Usuar.Trim();
                            BE.unmed = unmed.Text.Trim();

                            if (BL.Update(EmpresaID, BE))
                            {
                                SEGURIDAD_LOG("M");
                                MessageBox.Show("Datos Modificado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (familiaid.Text.Trim().Length != 3)
                {
                    MessageBox.Show("Falta Codigo Familia !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_pt_familiaBL();
                    var BE = new tb_pt_familia();

                    BE.moduloid = cboModuloID.SelectedValue.ToString();
                    BE.familiaid = familiaid.Text.Trim().PadLeft(3, '0');
                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos eliminados correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        Data_Tablafamilia();
                        form_bloqueado(false);
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
            if (Parent.Parent.Name == "MainProduccion")
            {
                modulo = ((D70Produccion.MainProduccion)MdiParent).moduloid;
                local = ((D70Produccion.MainProduccion)MdiParent).local;
                PERFILID = ((D70Produccion.MainProduccion)MdiParent).perfil;
            }

            if (Parent.Parent.Name == "MainTienda")
            {
                modulo = ((MERCADERIA02.MainMercaderia02)MdiParent).moduloid;
                local = ((MERCADERIA02.MainMercaderia02)MdiParent).local;
                PERFILID = ((MERCADERIA02.MainMercaderia02)MdiParent).perfil;
            }

            NIVEL_FORMS();
            ArmarTabla();
            Tablafamilia = new DataTable();

            familianame.CharacterCasing = CharacterCasing.Upper;
            get_cbo_modulo();
            get_cbo_modulo2();
            limpiar_documento();
            form_bloqueado(false);
            Data_cbo_tejidoid();
            btn_nuevo.Enabled = true;
            btn_primero.Enabled = true;
            btn_anterior.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_ultimo.Enabled = true;
            btn_salir.Enabled = true;
        }


        private void get_cbo_modulo()
        {
            var BL = new sys_dominioBL();
            var dt = new DataTable();
            try
            {
                dt = BL.GetAllDominioModuloPorUsuario(VariablesPublicas.EmpresaID, VariablesPublicas.Usuar, "60").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    cboModuloID.DataSource = dt;
                    cboModuloID.ValueMember = "moduloid";
                    cboModuloID.DisplayMember = "moduloname";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void get_cbo_modulo2()
        {
            var BL = new sys_dominioBL();
            var dt = new DataTable();
            try
            {
                dt = BL.GetAllDominioModuloPorUsuario(VariablesPublicas.EmpresaID, VariablesPublicas.Usuar, "60").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    cboModuloID2.DataSource = dt;
                    cboModuloID2.ValueMember = "moduloid";
                    cboModuloID2.DisplayMember = "moduloname";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                pnl_02.Enabled = false;
                pnl_01.Enabled = true;
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0")
            {
                ssModo = "EDIT";
                form_bloqueado(true);
                familianame.Focus();
                cboModuloID.Enabled = false;
                pnl_01.Enabled = true;
                pnl_02.Enabled = false;
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
                Data_Tablafamilia();
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
                    Delete();
                }
            }
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Tablafamiliadet.Rows.Count > 0)
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Data_Tablafamiliadet()
        {
            try
            {
                if (Tablafamiliadet.Rows.Count > 0)
                {
                    Tablafamiliadet.Rows.Clear();
                }
                var BL = new tb_pt_familiadetBL();
                var BE = new tb_pt_familiadet();

                if (cboModuloID.SelectedIndex != -1)
                {
                    BE.moduloid = cboModuloID.SelectedValue.ToString();
                    BE.lineaid = tejidoid.SelectedValue.ToString();
                    BE.familiaid = familiaid.Text.ToString();
                    Tablafamiliadet = BL.GetAll(EmpresaID, BE).Tables[0];
                    if (Tablafamiliadet.Rows.Count > 0)
                    {
                        btn_imprimir.Enabled = true;
                        mdi_dgb_familia.DataSource = Tablafamiliadet;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Data_Tablafamilia()
        {
            try
            {
                if (Tablafamilia.Rows.Count > 0)
                {
                    Tablafamilia.Rows.Clear();
                }
                var BL = new tb_pt_familiaBL();
                var BE = new tb_pt_familia();

                if (cboModuloID2.SelectedIndex != -1)
                {
                    BE.moduloid = cboModuloID2.SelectedValue.ToString();
                    BE.familianame = txt_criterio.Text.Trim().ToUpper();

                    Tablafamilia = BL.GetAll(EmpresaID, BE).Tables[0];
                    if (Tablafamilia.Rows.Count > 0)
                    {
                        btn_imprimir.Enabled = true;
                        MDI_dgb_familia1.DataSource = Tablafamilia;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void data_familiateladet(String xproductid)
        {
            form_bloqueado(false);
            var rowfamiliadet = Tablafamiliadet.Select("productid='" + xproductid + "'");
            if (rowfamiliadet.Length > 0)
            {
                foreach (DataRow row in rowfamiliadet)
                {
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


        private void Data_familiadet(String xfamiliadetid)
        {
            form_bloqueado(false);
            var rowfamiliadetid = Tablafamilia.Select("familiaid='" + xfamiliadetid + "'");
            if (rowfamiliadetid.Length > 0)
            {
                foreach (DataRow row in rowfamiliadetid)
                {
                    cboModuloID.SelectedValue = cboModuloID2.SelectedValue.ToString();
                    Data_cbo_tejidoid();
                    tejidoid.SelectedValue = row["lineaid"].ToString().Trim();
                    familiaid.Text = row["familiaid"].ToString().Trim();
                    familianame.Text = row["familianame"].ToString().Trim();
                    unmed.Text = row["unmed"].ToString().Trim();
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
            Data_Tablafamilia();
        }

        private void txt_criterio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_busqueda_Click(sender, e);
            }
        }

        private void Data_cbo_tejidoid()
        {
            var BL = new tb_60lineaBL();
            var BE = new tb_60linea();

            if (cboModuloID.SelectedIndex != -1)
            {
                BE.moduloid = cboModuloID.SelectedValue.ToString();
                try
                {
                    if (BE.moduloid.Length == 4 && BE.moduloid != "0200")
                    {
                        tejidoid.DataSource = BL.GetAll(EmpresaID, BE).Tables[0];
                        tejidoid.ValueMember = "lineaid";
                        tejidoid.DisplayMember = "lineaname";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void femiliatelaid_KeyDown(object sender, KeyEventArgs e)
        {
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

                BE.dominioid = "60";
                BE.moduloid = cboModuloID.SelectedValue.ToString();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();

                        var frmayuda = new Ayudas.Form_help_gridproducto();
                        frmayuda.xfamiliaid = familiaid.Text;
                        frmayuda.xmoduloid = modulo.ToString();
                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA TABLA PRODUCTOS >>";
                        frmayuda.sqlquery = "select tb1.productid, tb1.productname,tb1.unmed,tb2.stock, tb2.costoultimo as precventa, tb2.[local] from tb_" + modd + "_productos tb1 ";
                        frmayuda.sqlinner = "left join tb_" + modd + "_local_stock tb2 on tb1.moduloid=tb2.moduloid and tb1.productid=tb2.productid";
                        frmayuda.sqlwhere = "where local ='" + local + "' and tb1.status = '0' ";
                        frmayuda.sqland = "and";
                        frmayuda.criteriosbusqueda = new string[] { "PRODUCTO", "CODIGO" };
                        frmayuda.columbusqueda = "tb1.productname,tb1.productid";
                        frmayuda.returndatos = "0,1";

                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeProductos;
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        Boolean ValidaDatos2(String xcod)
        {
            Boolean valor = true;
            String xproductid = "";
            for (int j = 0; j < dgb_familia.RowCount; j++)
            {
                xproductid = dgb_familia.GetRowCellValue(j, "productid").ToString();

                if (xproductid.Equals(xcod.ToString()))
                {
                    valor = false;
                    MessageBox.Show("Existen Datos Iguales en el Detalle ... Cambiarlo", "Mensaje");
                }
            }

            return valor;
        }


        private void RecibeProductos(DataTable dtresultado)
        {
            try
            {
                if (dtresultado.Rows.Count > 0)
                {
                    var cont = 0;
                    foreach (DataRow fila in dtresultado.Rows)
                    {
                        cont = cont + 1;
                        if (dgb_familia.RowCount > 0)
                        {
                            if (ValidaDatos2(fila["productid"].ToString()))
                            {
                                var nFilaAnt = dgb_familia.RowCount - 1;
                                if (cont > 1)
                                {
                                    Tablafamiliadet = new DataTable();
                                    ArmarTabla();
                                    for (var j = 0; j < dgb_familia.RowCount; j++)
                                    {
                                        row = Tablafamiliadet.NewRow();
                                        row["productid"] = dgb_familia.GetRowCellValue(j, "productid").ToString();
                                        row["productname"] = dgb_familia.GetRowCellValue(j, "productname").ToString();
                                        row["unmed"] = dgb_familia.GetRowCellValue(j, "unmed").ToString();
                                        Tablafamiliadet.Rows.Add(row);
                                    }
                                    AddRowTable();
                                    mdi_dgb_familia.DataSource = Tablafamiliadet;
                                    dgb_familia.SetRowCellValue(nFilaAnt + 1, "productid", fila["productid"].ToString());
                                    dgb_familia.SetRowCellValue(nFilaAnt + 1, "productname", fila["productname"].ToString());
                                    dgb_familia.SetRowCellValue(nFilaAnt + 1, "unmed", fila["unmed"].ToString());
                                }
                                else
                                {
                                    dgb_familia.SetRowCellValue(nFilaAnt, "productid", fila["productid"].ToString());
                                    dgb_familia.SetRowCellValue(nFilaAnt, "productname", fila["productname"].ToString());
                                    dgb_familia.SetRowCellValue(nFilaAnt, "unmed", fila["unmed"].ToString());
                                }
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


        private void ArmarTabla()
        {
            Tablafamiliadet = new DataTable();
            Tablafamiliadet.Columns.Add("productid", typeof(String));
            Tablafamiliadet.Columns.Add("productname", typeof(String));
            Tablafamiliadet.Columns.Add("unmed", typeof(String));
        }

        private void AddRowTable()
        {
            row = Tablafamiliadet.NewRow();
            row["productid"] = "_";
            row["productname"] = "_";
            row["unmed"] = "_";
            Tablafamiliadet.Rows.Add(row);
        }

        private void AyudaFamilia(String lpdescrlike)
        {
            try
            {
                var modd = string.Empty;
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();

                BE.dominioid = "60";
                BE.moduloid = cboModuloID.SelectedValue.ToString();
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
                    familiaid.Text = xfamiliatelaid;
                    familianame.Text = xfamiliatelaname;
                    tejidoid.SelectedValue = xlineaid;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExpGridExcel_Click(object sender, EventArgs e)
        {
            if (sfdfamilia.ShowDialog(this) == DialogResult.OK)
            {
                dgb_familia.ExportToXls(sfdfamilia.FileName);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                var BL = new tb_pt_familiadetBL();
                var BE = new tb_pt_familiadet();
                BE.lineaid = tejidoid.SelectedValue.ToString();
                BE.moduloid = cboModuloID.SelectedValue.ToString();
                BE.familiaid = familiaid.Text.Trim().PadLeft(3, '0');

                var Detalle = new tb_pt_familiadet.Item();
                var ListaItems = new List<tb_pt_familiadet.Item>();

                var item = 0;
                foreach (DataRow fila in Tablafamiliadet.Rows)
                {
                    Detalle = new tb_pt_familiadet.Item();
                    item++;

                    Detalle.moduloid = cboModuloID.SelectedValue.ToString();
                    Detalle.lineaid = tejidoid.SelectedValue.ToString();
                    Detalle.familiaid = familiaid.Text.Trim().PadLeft(3, '0');
                    Detalle.productid = fila["productid"].ToString();
                    Detalle.unmed = fila["unmed"].ToString();
                    Detalle.status = "0";
                    Detalle.usuar = VariablesPublicas.Usuar.Trim();

                    ListaItems.Add(Detalle);
                }

                if (ListaItems.Count == 0)
                {
                    MessageBox.Show("Documento SIN DETALLE Y/O DETALLE INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                BE.ListaItems = ListaItems;

                if (BL.Insert(EmpresaID, BE))
                {
                    MessageBox.Show("Datos Actualizados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    procesado = true;
                    limpiar_documento();
                    Data_Tablafamiliadet();
                    btn_save.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void MDI_dgb_familia1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xfamiliaid = dgb_familia1.GetRowCellValue(dgb_familia1.FocusedRowHandle, "familiaid").ToString();
                Data_familiadet(xfamiliaid);
                pnl_01.Enabled = false;
                pnl_02.Enabled = true;
                btn_editar.Enabled = true;
                Data_Tablafamiliadet();
            }
        }

        private void dgb_familia1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var xfamiliaid = dgb_familia1.GetRowCellValue(e.RowHandle, "familiaid").ToString();
            Data_familiadet(xfamiliaid);
            pnl_01.Enabled = false;
            pnl_02.Enabled = true;
            btn_editar.Enabled = true;
            Data_Tablafamiliadet();
        }

        private void cboModuloID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data_cbo_tejidoid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add_Detalle();
            btn_save.Enabled = true;
        }


        private void Add_Detalle()
        {
            try
            {
                if (dgb_familia.RowCount > 0)
                {
                    if (dgb_familia.GetRowCellValue(dgb_familia.RowCount - 1, "productid").ToString().Trim().Length == 13)
                    {
                        Tablafamiliadet = new DataTable();
                        ArmarTabla();
                        for (var j = 0; j < dgb_familia.RowCount; j++)
                        {
                            row = Tablafamiliadet.NewRow();
                            row["productid"] = dgb_familia.GetRowCellValue(j, "productid").ToString();
                            row["productname"] = dgb_familia.GetRowCellValue(j, "productname").ToString();
                            row["unmed"] = dgb_familia.GetRowCellValue(j, "unmed").ToString();
                            Tablafamiliadet.Rows.Add(row);
                        }
                        AddRowTable();
                        mdi_dgb_familia.DataSource = Tablafamiliadet;
                    }
                    else
                    {
                        MessageBox.Show("Ingrese producto !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    AddRowTable();
                    mdi_dgb_familia.DataSource = Tablafamiliadet;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            dgb_familia.DeleteRow(dgb_familia.FocusedRowHandle);
        }

        private void mdi_dgb_familia_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    if (dgb_familia.FocusedColumn == dgb_familia.Columns[0])
                    {
                        AyudaProducto(string.Empty);
                    }
                }

                if (e.KeyCode == Keys.Delete)
                {
                    dgb_familia.SetFocusedRowCellValue("productid", "_");
                    dgb_familia.SetFocusedRowCellValue("productname", "_");
                    dgb_familia.SetFocusedRowCellValue("unmed", "_");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgb_familia_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            btn_save.Enabled = true;
        }

        private void mdi_dgb_familia_KeyUp(object sender, KeyEventArgs e)
        {
            btn_save.Enabled = true;
        }
    }
}
