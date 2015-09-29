using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.D70Produccion.UDP
{
    public partial class Frm_variante : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;
        private DataTable TablaVariante;
        private Boolean procesado = false;
        private String ssModo = "OTR";
        private List<tb_perimes> listaMes = null;
        private List<tb_perianio> listaAnio = null;

        private String _estructuraid = string.Empty, _tejidoid = string.Empty;

        private String _xmarcadescort = string.Empty, _xlineadescort = string.Empty, _xmodelodescort = string.Empty;
        private String _xbotapiedescort = string.Empty, _xgenerodescort = string.Empty, _xentalledescort = string.Empty;


        public Frm_variante()
        {
            InitializeComponent();
        }

        private void PARAMETROS_TABLA()
        {
            var xxferfil = string.Empty;
            var f = (MainProduccion)MdiParent;
            xxferfil = f.perfil.ToString();
            if (xxferfil.Trim().Length != 9)
            {
                MessageBox.Show("::: NO TIENE PERFIL !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PERFILID = xxferfil;
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
                txt_criterio.Enabled = true;
                variante.Enabled = false;
                variantename.Enabled = false;
                codtizado.Enabled = var;
                cmb_categoriaid.Enabled = var;
                marcaid.Enabled = var;
                marcaname.Enabled = false;
                lineaid.Enabled = var;
                lineaname.Enabled = false;
                cmb_generoid.Enabled = var;
                familiatelaid.Enabled = var;
                familiatelaname.Enabled = false;
                cmb_botapieid.Enabled = var;
                cmb_entalleid.Enabled = var;
                modeloid.Enabled = var;
                modeloname.Enabled = false;
                cmb_parteid.Enabled = var;
                chk_aprobado.Enabled = false;
                cboanio.Enabled = var;
                cboMesini.Enabled = var;
                cmb_disenadorid.Enabled = var;
                fech_prese.Enabled = var;
                fech_aprob.Enabled = var;

                tip_py.Enabled = false;
                ser_py.Enabled = var;
                num_py.Enabled = var;

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

                btn_act_botapie.Enabled = var;
                btn_act_categoria.Enabled = var;
                btn_act_genero.Enabled = var;
                btn_act_entalle.Enabled = var;
                btn_act_diseñador.Enabled = var;
                btn_act_parte.Enabled = var;
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
                btn_nuevo.Enabled = true;
                btn_primero.Enabled = false;
                btn_anterior.Enabled = false;
                btn_siguiente.Enabled = false;
                btn_ultimo.Enabled = false;
                btn_salir.Enabled = true;

                ssModo = "OTR";
            }
        }




        private void Cargar_cmbCategoria()
        {
            var BE = new tb_pt_categoria();
            var BL = new tb_pt_categoriaBL();
            var dt = new DataTable();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cmb_categoriaid.DataSource = dt;
                cmb_categoriaid.ValueMember = "categoriaid";
                cmb_categoriaid.DisplayMember = "categorianame";
            }
        }


        private void Cargar_cmbGenero()
        {
            var BE = new tb_pt_genero();
            var BL = new tb_pt_generoBL();
            var dt = new DataTable();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cmb_generoid.DataSource = dt;
                cmb_generoid.ValueMember = "generoid";
                cmb_generoid.DisplayMember = "generoname";
            }
        }


        private void Cargar_cmbParte()
        {
            var BE = new tb_pt_parte();
            var BL = new tb_pt_parteBL();
            var dt = new DataTable();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cmb_parteid.DataSource = dt;
                cmb_parteid.ValueMember = "parteid";
                cmb_parteid.DisplayMember = "partename";
            }
        }


        private void Cargar_cmbEntalle()
        {
            var BE = new tb_pt_entalle();
            var BL = new tb_pt_entalleBL();
            var dt = new DataTable();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cmb_entalleid.DataSource = dt;
                cmb_entalleid.ValueMember = "entalleid";
                cmb_entalleid.DisplayMember = "entallename";
            }
        }

        private void Cargar_cmbBotapie()
        {
            var BE = new tb_pt_botapie();
            var BL = new tb_pt_botapieBL();
            var dt = new DataTable();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cmb_botapieid.DataSource = dt;
                cmb_botapieid.ValueMember = "botapieid";
                cmb_botapieid.DisplayMember = "botapiename";
            }
        }

        private void Cargar_cmbDisenador()
        {
            var BE = new tb_pp_diseñador();
            var BL = new tb_pp_diseñadorBL();
            var dt = new DataTable();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cmb_disenadorid.DataSource = dt;
                cmb_disenadorid.ValueMember = "disenadorid";
                cmb_disenadorid.DisplayMember = "disenadorname";
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
                BE.detalle = variante.Text.Trim() + "/" + variantename.Text.Trim().ToUpper()  + "/" + XGLOSA;

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
                txt_criterio.Text = string.Empty;
                variante.Text = string.Empty;
                variantename.Text = string.Empty;
                codtizado.Text = string.Empty;
                cmb_categoriaid.SelectedIndex = -1;
                marcaid.Text = string.Empty;
                marcaname.Text = string.Empty;
                lineaid.Text = string.Empty;
                lineaname.Text = string.Empty;
                cmb_generoid.SelectedIndex = -1;
                familiatelaid.Text = string.Empty;
                familiatelaname.Text = string.Empty;
                cmb_botapieid.SelectedIndex = -1;
                cmb_entalleid.SelectedIndex = -1;
                modeloid.Text = string.Empty;
                modeloname.Text = string.Empty;
                cmb_parteid.SelectedIndex = -1;
                chk_aprobado.Checked = false;
                cboanio.SelectedValue = DateTime.Today.Year.ToString();
                cboMesini.SelectedValue = DateTime.Today.Month.ToString().PadLeft(2, '0');
                cmb_disenadorid.SelectedIndex = -1;
                fech_prese.Text = DateTime.Today.ToShortDateString();
                fech_prese.Checked = false;
                fech_aprob.Checked = false;
                tip_py.Text = "PY";
                ser_py.Text = string.Empty;
                num_py.Text = string.Empty;

                _estructuraid = string.Empty;
                _tejidoid = string.Empty;

                _xmarcadescort = string.Empty;
                _xlineadescort = string.Empty;
                _xmodelodescort = string.Empty;
                _xbotapiedescort = string.Empty;
                _xentalledescort = string.Empty;
                _xgenerodescort = string.Empty;
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
            marcaid.Focus();

            ssModo = "NEW";
        }

        private void Insert()
        {
            try
            {
                if (variante.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Falta Codigo Variante !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (marcaid.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Falta Codigo de Marca", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (lineaid.Text.Trim().Length == 0)
                        {
                            MessageBox.Show("Falta Codigo de Linea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            if (modeloid.Text.Trim().Length == 0)
                            {
                                MessageBox.Show("Falta Codigo de Modelo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                if (familiatelaid.Text.Trim().Length == 0)
                                {
                                    MessageBox.Show("Falta Codigo de FamiliaTelas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                else
                                {
                                    if (codtizado.Text.Trim().Length == 0)
                                    {
                                        MessageBox.Show("Falta Codigo de Articulo-Generado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    else
                                    {
                                        if (cmb_categoriaid.SelectedIndex == -1)
                                        {
                                            MessageBox.Show("Falta Seleccionar La Categoria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                        else
                                        {
                                            if (cmb_generoid.SelectedIndex == -1)
                                            {
                                                MessageBox.Show("Falta Seleccionar el Genero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                return;
                                            }
                                            else
                                            {
                                                if (cmb_parteid.SelectedIndex == -1)
                                                {
                                                    MessageBox.Show("Falta Seleccionar Parte ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    return;
                                                }
                                                else
                                                {
                                                    if (cmb_entalleid.SelectedIndex == -1)
                                                    {
                                                        MessageBox.Show("Falta Seleccionar Entalle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        return;
                                                    }
                                                    else
                                                    {
                                                        var BL = new tb_pp_varianteBL();
                                                        var BE = new tb_pp_variante();

                                                        BE.variante = variante.Text.ToString();
                                                        BE.codtizado = codtizado.Text.ToString();
                                                        BE.variantename = variantename.Text.ToString();
                                                        BE.categoriaid = cmb_categoriaid.SelectedValue.ToString();
                                                        BE.marcaid = marcaid.Text.Trim();
                                                        BE.lineaid = lineaid.Text.Trim();
                                                        BE.generoid = cmb_generoid.SelectedValue.ToString();
                                                        BE.tejidoid = _tejidoid.ToString();
                                                        BE.familiatelaid = familiatelaid.Text.Trim();
                                                        BE.botapieid = cmb_botapieid.SelectedValue.ToString();
                                                        BE.entalleid = cmb_entalleid.SelectedValue.ToString();
                                                        BE.modeloid = modeloid.Text.Trim();
                                                        BE.parteid = cmb_parteid.SelectedValue.ToString();
                                                        BE.aprobado = chk_aprobado.Checked;
                                                        BE.perianio = cboanio.SelectedValue.ToString();
                                                        BE.perimes = cboMesini.SelectedValue.ToString();
                                                        BE.diseñadorid = cmb_disenadorid.SelectedValue.ToString();
                                                        if (fech_prese.Checked)
                                                        {
                                                            BE.fechprese = Convert.ToDateTime(fech_prese.Text);
                                                        }
                                                        if (fech_aprob.Checked)
                                                        {
                                                            BE.fechaprob = Convert.ToDateTime(fech_aprob.Text);
                                                        }
                                                        BE.tippy = tip_py.Text.ToString();
                                                        BE.serppy = ser_py.Text.ToString();
                                                        BE.numppy = num_py.Text.ToString();
                                                        BE.status = "0";
                                                        BE.usuar = VariablesPublicas.Usuar.Trim();

                                                        if (BL.Insert(EmpresaID, BE))
                                                        {
                                                            MessageBox.Show("Datos Grabados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            procesado = true;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
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

        private void Update()
        {
            try
            {
                if (variante.Text.Trim().Length != 6)
                {
                    MessageBox.Show("Falta Codigo Variante !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (marcaid.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Falta Codigo de Marca", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (lineaid.Text.Trim().Length == 0)
                        {
                            MessageBox.Show("Falta Codigo de Linea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            if (modeloid.Text.Trim().Length == 0)
                            {
                                MessageBox.Show("Falta Codigo de Modelo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                if (familiatelaid.Text.Trim().Length == 0)
                                {
                                    MessageBox.Show("Falta Codigo de FamiliaTelas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                else
                                {
                                    if (codtizado.Text.Trim().Length == 0)
                                    {
                                        MessageBox.Show("Falta Codigo de Articulo-Generado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    else
                                    {
                                        if (cmb_categoriaid.SelectedIndex == -1)
                                        {
                                            MessageBox.Show("Falta Seleccionar La Categoria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                        else
                                        {
                                            if (cmb_generoid.SelectedIndex == -1)
                                            {
                                                MessageBox.Show("Falta Seleccionar el Genero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                return;
                                            }
                                            else
                                            {
                                                if (cmb_parteid.SelectedIndex == -1)
                                                {
                                                    MessageBox.Show("Falta Seleccionar Parte ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    return;
                                                }
                                                else
                                                {
                                                    if (cmb_entalleid.SelectedIndex == -1)
                                                    {
                                                        MessageBox.Show("Falta Seleccionar Entalle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        return;
                                                    }
                                                    else
                                                    {
                                                        var BL = new tb_pp_varianteBL();
                                                        var BE = new tb_pp_variante();

                                                        BE.variante = variante.Text.ToString();
                                                        BE.codtizado = codtizado.Text.ToString();
                                                        BE.variantename = variantename.Text.ToString();
                                                        BE.categoriaid = cmb_categoriaid.SelectedValue.ToString();
                                                        BE.marcaid = marcaid.Text.Trim();
                                                        BE.lineaid = lineaid.Text.Trim();
                                                        BE.generoid = cmb_generoid.SelectedValue.ToString();
                                                        BE.tejidoid = _tejidoid.ToString();
                                                        BE.familiatelaid = familiatelaid.Text.Trim();
                                                        BE.botapieid = cmb_botapieid.SelectedValue.ToString();
                                                        BE.entalleid = cmb_entalleid.SelectedValue.ToString();
                                                        BE.modeloid = modeloid.Text.Trim();
                                                        BE.parteid = cmb_parteid.SelectedValue.ToString();
                                                        BE.aprobado = chk_aprobado.Checked;
                                                        BE.perianio = cboanio.SelectedValue.ToString();
                                                        BE.perimes = cboMesini.SelectedValue.ToString();
                                                        BE.diseñadorid = cmb_disenadorid.SelectedValue.ToString();
                                                        if (fech_prese.Checked)
                                                        {
                                                            BE.fechprese = Convert.ToDateTime(fech_prese.Text);
                                                        }
                                                        if (fech_aprob.Checked)
                                                        {
                                                            BE.fechaprob = Convert.ToDateTime(fech_aprob.Text);
                                                        }
                                                        BE.tippy = tip_py.Text.ToString();
                                                        BE.serppy = ser_py.Text.ToString();
                                                        BE.numppy = num_py.Text.ToString();
                                                        BE.status = "0";
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
                                        }
                                    }
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

        private void Delete()
        {
            try
            {
                if (variante.Text.Trim().Length != 6)
                {
                    MessageBox.Show("Falta Codigo Variante !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_pp_varianteBL();
                    var BE = new tb_pp_variante();

                    BE.variante = variante.Text.ToString();
                    BE.codtizado = codtizado.Text.ToString();

                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos Eliminados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        form_bloqueado(false);
                        data_TablaVariante();
                        btn_nuevo.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarMes()
        {
            var BL = new tb_perimesBL();
            listaMes = BL.Get_Mes(EmpresaID);
            cboMesini.DataSource = listaMes;
            cboMesini.DisplayMember = "perimesname";
            cboMesini.ValueMember = "perimesid";
        }

        private void CargarAnio()
        {
            var BL = new tb_perianioBL();
            listaAnio = BL.Get_anio(EmpresaID);
            cboanio.DataSource = listaAnio;
            cboanio.DisplayMember = "perianio";
            cboanio.ValueMember = "codigo";
        }

        private void Frm_articulo_Load(object sender, EventArgs e)
        {
            modulo = ((D70Produccion.MainProduccion)MdiParent).moduloid;
            local = ((D70Produccion.MainProduccion)MdiParent).local;
            PERFILID = ((D70Produccion.MainProduccion)MdiParent).perfil;

            NIVEL_FORMS();

            TablaVariante = new DataTable();
            variantename.CharacterCasing = CharacterCasing.Upper;

            Cargar_cmbCategoria();
            Cargar_cmbGenero();
            Cargar_cmbParte();
            Cargar_cmbEntalle();
            Cargar_cmbBotapie();
            Cargar_cmbDisenador();
            CargarAnio();
            CargarMes();

            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;

            btn_primero.Enabled = false;
            btn_anterior.Enabled = false;
            btn_siguiente.Enabled = false;
            btn_ultimo.Enabled = false;

            btn_salir.Enabled = true;
        }

        private void Frm_articulo_KeyDown(object sender, KeyEventArgs e)
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

        private void articuloid_LostFocus(object sender, System.EventArgs e)
        {
            form_cargar_datos(string.Empty);
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
            {
                nuevo();
                pnl_02.Enabled = true;
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0")
            {
                ssModo = "EDIT";
                form_bloqueado(true);
                variantename.Focus();

                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
                btn_nuevo.Enabled = false;
                btn_editar.Enabled = false;

                Valida_Marca(marcaid.Text.Trim());
                Valida_Linea(lineaid.Text.Trim());
                Valida_Modelo(modeloid.Text.Trim());
                Valida_Genero(cmb_generoid.SelectedValue.ToString());
                _GeneraNombre();
            }
            else
            {
                if (XNIVEL == "1")
                {
                    fech_prese.Enabled = true;
                    fech_aprob.Enabled = true;
                    btn_cancelar.Enabled = true;
                    btn_grabar.Enabled = true;
                    btn_nuevo.Enabled = false;
                    btn_editar.Enabled = false;
                }
            }
        }

        private void Valida_Marca(String xcod)
        {
            var BE = new tb_pt_marca();
            var BL = new tb_pt_marcaBL();
            var dt = new DataTable();
            BE.marcaid = xcod.Trim();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                marcaid.Text = dt.Rows[0]["marcaid"].ToString();
                marcaname.Text = dt.Rows[0]["marcaname"].ToString();

                if (dt.Rows[0]["marcadescort"].ToString().Trim() == string.Empty)
                {
                    _xmarcadescort = dt.Rows[0]["marcaname"].ToString();
                }
                else
                {
                    _xmarcadescort = dt.Rows[0]["marcadescort"].ToString();
                }
            }
            else
            {
                _xmarcadescort = string.Empty;
                marcaid.Text = string.Empty;
                marcaname.Text = string.Empty;
            }
        }

        private void Valida_Linea(String xcod)
        {
            var BE2 = new tb_pt_linea();
            var BL2 = new tb_pt_lineaBL();
            var dt2 = new DataTable();
            BE2.lineaid = xcod.Trim();
            dt2 = BL2.GetAll(EmpresaID, BE2).Tables[0];
            if (dt2.Rows.Count > 0)
            {
                lineaid.Text = dt2.Rows[0]["lineaid"].ToString();
                lineaname.Text = dt2.Rows[0]["lineaname"].ToString();
                if (dt2.Rows[0]["lineadescort"].ToString().Trim() == string.Empty)
                {
                    _xlineadescort = dt2.Rows[0]["lineaname"].ToString();
                }
                else
                {
                    _xlineadescort = dt2.Rows[0]["lineadescort"].ToString();
                }
            }
            else
            {
                _xlineadescort = string.Empty;
                lineaid.Text = string.Empty;
                lineaname.Text = string.Empty;
            }
        }

        private void Valida_Modelo(String xcod)
        {
            var BE3 = new tb_pt_modelo();
            var BL3 = new tb_pt_modeloBL();
            var dt3 = new DataTable();
            BE3.modeloid = xcod.Trim();
            dt3 = BL3.GetAll(EmpresaID, BE3).Tables[0];
            if (dt3.Rows.Count > 0)
            {
                modeloid.Text = dt3.Rows[0]["modeloid"].ToString();
                modeloname.Text = dt3.Rows[0]["modeloname"].ToString();
                if (dt3.Rows[0]["modelodescort"].ToString().Trim() == string.Empty)
                {
                    _xmodelodescort = dt3.Rows[0]["modeloname"].ToString();
                }
                else
                {
                    _xmodelodescort = dt3.Rows[0]["modelodescort"].ToString();
                }
            }
            else
            {
                _xmodelodescort = string.Empty;
                modeloid.Text = string.Empty;
                modeloname.Text = string.Empty;
            }
        }
        private void Valida_Familia(String xcod)
        {
            var BE3 = new tb_pt_familia();
            var BL3 = new tb_pt_familiaBL();
            var dt3 = new DataTable();
            BE3.familiaid = xcod.Trim();
            dt3 = BL3.GetAll(EmpresaID, BE3).Tables[0];
            if (dt3.Rows.Count > 0)
            {
                familiatelaid.Text = dt3.Rows[0]["familiatelaid"].ToString();
                familiatelaname.Text = dt3.Rows[0]["familiatelaname"].ToString();
                _estructuraid = dt3.Rows[0]["estructuraid"].ToString();
                _tejidoid = dt3.Rows[0]["lineaid"].ToString();
            }
            else
            {
                familiatelaid.Text = string.Empty;
                familiatelaname.Text = string.Empty;
                _estructuraid = string.Empty;
                _tejidoid = string.Empty;
            }
        }

        private void Valida_Genero(String xcod)
        {
            var BE = new tb_pt_genero();
            var BL = new tb_pt_generoBL();
            var dt = new DataTable();
            BE.generoid = xcod.ToString();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["generodescort"].ToString() == string.Empty)
                {
                    _xgenerodescort = dt.Rows[0]["generoname"].ToString();
                }
                else
                {
                    _xgenerodescort = dt.Rows[0]["generodescort"].ToString();
                }
            }
        }


        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            form_accion_cancelEdicion(1);
            pnl_02.Enabled = true;
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
                data_TablaVariante();
                form_bloqueado(false);
                limpiar_documento();
                btn_nuevo.Enabled = true;
                btn_primero.Enabled = false;
                btn_anterior.Enabled = false;
                btn_siguiente.Enabled = false;
                btn_ultimo.Enabled = false;
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

        private void data_TablaVariante()
        {
            try
            {
                if (TablaVariante.Rows.Count > 0)
                {
                    TablaVariante.Rows.Clear();
                }
                var BL = new tb_pp_varianteBL();
                var BE = new tb_pp_variante();

                BE.variantename = txt_criterio.Text.ToString();

                TablaVariante = BL.GetAll(EmpresaID, BE).Tables[0];
                if (TablaVariante.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    MDI_gridvariante.DataSource = TablaVariante;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            data_TablaVariante();
        }

        private void txt_criterio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_busqueda_Click(sender, e);
            }
        }

        private void mdi_gridarticulo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xarticid = gridvariante.GetRowCellValue(gridvariante.FocusedRowHandle, "variante").ToString();
                data_articuloid(xarticid);
            }
        }

        private void gridarticulo_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var xarticid = gridvariante.GetRowCellValue(e.RowHandle, "variante").ToString();
            data_articuloid(xarticid);
        }

        private void data_articuloid(String xvariante)
        {
            form_bloqueado(false);
            var rowarticid = TablaVariante.Select("variante='" + xvariante + "'");
            if (rowarticid.Length > 0)
            {
                foreach (DataRow row in rowarticid)
                {
                    variante.Text = row["variante"].ToString().Trim();
                    codtizado.Text = row["codtizado"].ToString().Trim();
                    variantename.Text = row["variantename"].ToString().Trim();
                    marcaid.Text = row["marcaid"].ToString().Trim();
                    marcaname.Text = row["marcaname"].ToString().Trim();
                    lineaid.Text = row["lineaid"].ToString().Trim();
                    lineaname.Text = row["lineaname"].ToString().Trim();
                    modeloid.Text = row["modeloid"].ToString().Trim();
                    modeloname.Text = row["modeloname"].ToString().Trim();
                    familiatelaid.Text = row["familiatelaid"].ToString().Trim();
                    familiatelaname.Text = row["familianame"].ToString().Trim();
                    cmb_categoriaid.SelectedValue = row["categoriaid"].ToString().Trim();
                    cmb_generoid.SelectedValue = row["generoid"].ToString().Trim();
                    cmb_parteid.SelectedValue = row["parteid"].ToString().Trim();
                    cmb_entalleid.SelectedValue = row["entalleid"].ToString().Trim();
                    cmb_botapieid.SelectedValue = row["botapieid"].ToString().Trim();

                    cboanio.SelectedValue = row["perianio"].ToString().Trim();
                    cboMesini.SelectedValue = row["perimes"].ToString().Trim();
                    cmb_disenadorid.SelectedValue = row["disenadorid"].ToString().Trim();
                    fech_prese.Text = row["fech_prese"].ToString().Trim();
                    fech_aprob.Text = row["fech_aprob"].ToString().Trim();
                    tip_py.Text = row["tip_py"].ToString().Trim();
                    ser_py.Text = row["ser_py"].ToString().Trim();
                    num_py.Text = row["num_py"].ToString().Trim();

                    chk_aprobado.Checked = Convert.ToBoolean(row["aprobado"].ToString().Trim());
                    if (chk_aprobado.Checked)
                    {
                        fech_aprob.Checked = true;
                    }


                    btn_nuevo.Enabled = true;
                    btn_editar.Enabled = true;
                    btn_eliminar.Enabled = true;
                    btn_imprimir.Enabled = true;

                    btn_primero.Enabled = false;
                    btn_anterior.Enabled = false;
                    btn_siguiente.Enabled = false;
                    btn_ultimo.Enabled = false;

                    btn_log.Enabled = true;
                    btn_salir.Enabled = true;
                }
            }
        }


        private void _GenerarCodigo()
        {
            var BE = new tb_pp_variante();
            var BL = new tb_pp_varianteBL();
            var dt = new DataTable();
            BE.marcaid = marcaid.Text.Trim().ToString();
            dt = BL.GeneraCod(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                variante.Text = dt.Rows[0]["Codigo"].ToString();
            }
            else
            {
                variante.Text = "ERROR";
            }
        }

        private void _GeneraNombre()
        {
            variantename.Text = _xmarcadescort.Trim() + " " +
                                _xlineadescort.Trim() + " " +
                                _xmodelodescort.Trim() + " " +
                                _xentalledescort.Trim() + " " +
                                _xbotapiedescort.Trim() + " " +
                                _xgenerodescort.Trim();
        }


        private void marcaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaMarca(string.Empty);
                _GenerarCodigo();
                _GeneraNombre();
                codtizado.Focus();
            }

            if (e.KeyCode == Keys.Enter)
            {
                var xcodmar = string.Empty;
                xcodmar = marcaid.Text.PadLeft(2, '0');
                Valida_Marca(xcodmar);
                _GenerarCodigo();
                _GeneraNombre();
                codtizado.Focus();
            }
        }




        private void AyudaMarca(String lpdescrlike)
        {
            var frmayuda = new Ayudas.Frm_help_general();

            frmayuda.tipoo = "sql";
            frmayuda.titulo = "<< AYUDA TABLA MARCA >>";
            frmayuda.sqlquery = "SELECT marcaid as Codigo, marcaname as Marca,marcadescort as Desc_Corta FROM tb_pt_marca ";
            frmayuda.sqlwhere = "WHERE";
            frmayuda.criteriosbusqueda = new string[] { "MARCA", "CODIGO" };
            frmayuda.columbusqueda = "marcaname,marcaid";
            frmayuda.returndatos = "0,1,2";

            frmayuda.Owner = this;
            frmayuda.PasaProveedor = RecibeMarca;
            frmayuda.ShowDialog();
        }

        private void RecibeMarca(String xmarcaid, String xmarcaname, String xdescort, String resultado4, String resultado5)
        {
            if (xmarcaid.Trim().Length > 0)
            {
                marcaid.Text = xmarcaid.Trim();
                marcaname.Text = xmarcaname.Trim();
                if (xdescort.Trim() == string.Empty)
                {
                    _xmarcadescort = xmarcaname.Trim();
                }
                else
                {
                    _xmarcadescort = xdescort.Trim();
                }
            }
        }

        private void AyudaLinea(String lpdescrlike)
        {
            var frmayuda = new Ayudas.Frm_help_general();

            frmayuda.tipoo = "sql";
            frmayuda.titulo = "<< AYUDA TABLA LINEA >>";
            frmayuda.sqlquery = "SELECT lineaid as Codigo, lineaname as Linea, lineadescort as Desc_Corta FROM tb_pt_linea ";
            frmayuda.sqlwhere = "where";
            frmayuda.criteriosbusqueda = new string[] { "LINEA", "CODIGO" };
            frmayuda.columbusqueda = "lineaname,lineaid";
            frmayuda.returndatos = "0,1,2";

            frmayuda.Owner = this;
            frmayuda.PasaProveedor = RecibeLinea;
            frmayuda.ShowDialog();
        }

        private void RecibeLinea(String xlineaid, String xlineaname, String xlineadescort, String resultado4, String resultado5)
        {
            if (xlineaid.Trim().Length > 0)
            {
                lineaid.Text = xlineaid.Trim();
                lineaname.Text = xlineaname.Trim();
                if (xlineadescort.Trim() == string.Empty)
                {
                    _xlineadescort = xlineaname.Trim();
                }
                else
                {
                    _xlineadescort = xlineadescort.Trim();
                }
            }
        }

        private void AyudaModelo(String lpdescrlike)
        {
            var frmayuda = new Ayudas.Frm_help_general();

            frmayuda.tipoo = "sql";
            frmayuda.titulo = "<< AYUDA TABLA MODELO >>";
            frmayuda.sqlquery = "SELECT modeloid as Codigo, modeloname as Modelo,modelodescort as Desc_Corta FROM tb_pt_modelo";
            frmayuda.sqlwhere = "where";
            frmayuda.criteriosbusqueda = new string[] { "MODELO", "CODIGO" };
            frmayuda.columbusqueda = "modeloname,modeloid";
            frmayuda.returndatos = "0,1,2";

            frmayuda.Owner = this;
            frmayuda.PasaProveedor = RecibeModelo;
            frmayuda.ShowDialog();
        }

        private void RecibeModelo(String xmodeloid, String xmodeloname, String xdescort, String resultado4, String resultado5)
        {
            if (xmodeloid.Trim().Length > 0)
            {
                modeloid.Text = xmodeloid.Trim();
                modeloname.Text = xmodeloname.Trim();
                if (xdescort.Trim() == string.Empty)
                {
                    _xmodelodescort = xdescort.Trim();
                }
                else
                {
                    _xmodelodescort = xmodeloname.Trim();
                }
            }
        }

        private void AyudaFamilia(String lpdescrlike)
        {
            var frmayuda = new Ayudas.Frm_help_general();

            frmayuda.tipoo = "sql";
            frmayuda.titulo = "<< AYUDA TABLA FAMILIA - TELA >>";
            frmayuda.sqlquery = " SELECT es.estructuraid,te.lineaid,te.familiaid,(es.estructuraname+'-'+li.lineaname+'-'+te.familianame)familia " +
                                " FROM tb_ta_familia te ";
            frmayuda.sqlinner = " LEFT JOIN tb_ta_linea li ON te.lineaid = li.lineaid " +
                                " LEFT JOIN tb_ta_estructura es ON es.estructuraid = li.estructuraid ";
            frmayuda.sqlwhere = " where";
            frmayuda.criteriosbusqueda = new string[] { "FAMILIA", "CODIGO" };
            frmayuda.columbusqueda = "te.familianame,te.familiaid";
            frmayuda.returndatos = "0,1,2,3";

            frmayuda.Owner = this;
            frmayuda.PasaProveedor = RecibeFamilia;
            frmayuda.ShowDialog();
        }

        private void RecibeFamilia(String xestructuraid, String xlineaid, String xfamiliatelaid, String xfamiliatelaname, String resultado5)
        {
            try
            {
                if (xlineaid.Trim().Length == 3)
                {
                    familiatelaid.Text = xfamiliatelaid;
                    familiatelaname.Text = xfamiliatelaname;
                    _estructuraid = xestructuraid.Trim();
                    _tejidoid = xlineaid.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidamosCombinación()
        {
            var BE = new tb_pt_articulo();
            var BL = new tb_pt_articuloBL();
            var dt = new DataTable();
            BE.marcaid = marcaid.Text.Trim();
            BE.lineaid = lineaid.Text.Trim();
            BE.modeloid = modeloid.Text.Trim();
            BE.familiatelaid = familiatelaid.Text.Trim();
            dt = BL.GeneraCod(EmpresaID, BE).Tables[0];
            if (dt.Rows[0]["codigo"].ToString() != string.Empty)
            {
                codtizado.Text = dt.Rows[0]["codigo"].ToString();
                pnl_02.Enabled = false;
            }
            else
            {
                MessageBox.Show("Ya Existe Combinación ...!!!");
                limpiar_documento();
                pnl_02.Enabled = true;
                return;
            }
        }
        private void lineaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaLinea(string.Empty);
                _GeneraNombre();
                modeloid.Focus();
            }

            if (e.KeyCode == Keys.Enter)
            {
                var xcodlinea = string.Empty;
                xcodlinea = lineaid.Text.PadLeft(2, '0');
                Valida_Linea(xcodlinea);
                _GeneraNombre();
                modeloid.Focus();
            }
        }

        private void modeloid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaModelo(string.Empty);
                _GeneraNombre();
                familiatelaid.Focus();
            }

            if (e.KeyCode == Keys.Enter)
            {
                var xcodmodelo = string.Empty;
                xcodmodelo = modeloid.Text.PadLeft(4, '0');
                Valida_Modelo(xcodmodelo);
                _GeneraNombre();
                familiatelaid.Focus();
            }
        }

        private void familiatelaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaFamilia(string.Empty);
                cboanio.Focus();
            }

            if (e.KeyCode == Keys.Enter)
            {
                var xfamiliaid = string.Empty;
                xfamiliaid = familiatelaid.Text.PadLeft(3, '0');
                Valida_Familia(xfamiliaid);
                cboanio.Focus();
            }
        }

        private void cmb_botapieid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ssModo == "EDIT" || ssModo == "NEW")
            {
                if (cmb_botapieid.SelectedIndex >= 0)
                {
                    var BE = new tb_pt_botapie();
                    var BL = new tb_pt_botapieBL();
                    var dt = new DataTable();
                    BE.botapieid = cmb_botapieid.SelectedValue.ToString();
                    dt = BL.GetAll(EmpresaID, BE).Tables[0];
                    foreach (DataRow fila in dt.Rows)
                    {
                        _xbotapiedescort = fila["botapiedescort"].ToString().Trim();
                        _GeneraNombre();
                    }
                }
            }
        }

        private void cmb_generoid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ssModo == "EDIT" || ssModo == "NEW")
            {
                if (cmb_generoid.SelectedIndex >= 0)
                {
                    var BE = new tb_pt_genero();
                    var BL = new tb_pt_generoBL();
                    var dt = new DataTable();
                    BE.generoid = cmb_generoid.SelectedValue.ToString();
                    dt = BL.GetAll(EmpresaID, BE).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["generodescort"].ToString() == string.Empty)
                        {
                            _xgenerodescort = dt.Rows[0]["generoname"].ToString();
                        }
                        else
                        {
                            _xgenerodescort = dt.Rows[0]["generodescort"].ToString();
                        }
                        _GeneraNombre();
                    }
                }
            }
        }
        private void cmb_entalleid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ssModo == "EDIT" || ssModo == "NEW")
            {
                if (cmb_entalleid.SelectedIndex >= 0)
                {
                    var BE = new tb_pt_entalle();
                    var BL = new tb_pt_entalleBL();
                    var dt = new DataTable();
                    BE.entalleid = cmb_entalleid.SelectedValue.ToString();
                    dt = BL.GetAll(EmpresaID, BE).Tables[0];
                    foreach (DataRow fila in dt.Rows)
                    {
                        _xentalledescort = fila["entalledescort"].ToString().Trim();
                        _GeneraNombre();
                    }
                }
            }
        }

        private void variantename_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                codtizado.Focus();
            }
        }

        private void codtizado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lineaid.Focus();
            }
        }

        private void anio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboMesini.Focus();
            }
        }

        private void tip_py_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ser_py.Focus();
            }
        }

        private void ser_py_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var xnum = ser_py.Text.PadLeft(4, '0');
                ser_py.Text = xnum;
                num_py.Focus();
            }
        }

        private void fech_aprob_ValueChanged(object sender, EventArgs e)
        {
            if (fech_aprob.Checked)
            {
                chk_aprobado.Checked = true;
            }
            else
            {
                chk_aprobado.Checked = false;
            }
        }

        private void num_py_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var xnum = num_py.Text.PadLeft(10, '0');
                num_py.Text = xnum;
            }
        }

        private void btn_act_diseñador_Click(object sender, EventArgs e)
        {
            Cargar_cmbDisenador();
        }

        private void btn_act_categoria_Click(object sender, EventArgs e)
        {
            Cargar_cmbCategoria();
        }

        private void btn_act_genero_Click(object sender, EventArgs e)
        {
            Cargar_cmbGenero();
        }

        private void btn_act_parte_Click(object sender, EventArgs e)
        {
            Cargar_cmbParte();
        }

        private void btn_act_entalle_Click(object sender, EventArgs e)
        {
            Cargar_cmbEntalle();
        }

        private void btn_act_botapie_Click(object sender, EventArgs e)
        {
            Cargar_cmbBotapie();
        }
    }
}
