using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

using System.IO;

namespace BapFormulariosNet.MERCADERIA02.CATALOGO
{
    public partial class Frm_articulo : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;
        private DataTable Tablaarticulo;
        private Boolean procesado = false;
        private String ssModo = "OTR";
        private Genericas fungen = new Genericas();
        private Byte[] vmContenidoFile;
        private string xtmpfile = VariablesPublicas.TmpFile("TMP");
        private String _nombreFoto = string.Empty;

        private String _xmarcadescort = string.Empty, _xlineadescort = string.Empty, _xmodelodescort = string.Empty;
        private String _xbotapiedescort = string.Empty, _xgenerodescort = string.Empty, _xentalledescort = string.Empty;

        private String _estructuraid = string.Empty, _tejidoid = string.Empty;
        private String _xlineaidold = string.Empty, _xmarcaidold = string.Empty;

        public Frm_articulo()
        {
            InitializeComponent();
        }

        private void PARAMETROS_TABLA()
        {
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
                txt_criterio.Enabled = !var;
                btn_busqueda.Enabled = !var;

                txtvariante.Enabled = var;
                txtcodtizados.Enabled = false;

                articname.Enabled = false;
                grupoid.Enabled = var;
                gruponame.Enabled = false;
                lineaid.Enabled = var;
                lineaname.Enabled = false;
                marcaid.Enabled = var;
                marcaname.Enabled = false;
                coleccionid.Enabled = var;
                coleccionname.Enabled = false;
                subcoleccionid.Enabled = var;
                subcoleccionname.Enabled = false;
                modeloid.Enabled = var;
                modeloname.Enabled = false;
                familiatelaid.Enabled = var;
                familiatelaname.Enabled = false;
                articid.Enabled = false;
                articidold.Enabled = false;
                articname.Enabled = false;
                prec_costo.Enabled = var;
                real_costo.Enabled = false;
                precventa_cre_mayor.Enabled = var;
                precventa_cre_menor.Enabled = var;
                precventa_csc_mayor.Enabled = var;
                precventa_csc_menor.Enabled = var;
                precventa_tda_mayor.Enabled = var;
                precventa_tda_menor.Enabled = var;
                prec_etiq.Enabled = var;
                prec_ofer.Enabled = var;

                cmb_botapieid.Enabled = var;
                cmb_categoriaid.Enabled = var;
                cmb_entalleid.Enabled = var;

                cboCanalventaid.Enabled = var;
                cmb_esmercaderia.Enabled = var;
                cmb_estacionid.Enabled = var;
                cmb_estadoid.Enabled = var;
                cmb_generoid.Enabled = var;
                cmb_parteid.Enabled = var;
                cmb_procedenciaid.Enabled = var;
                cmb_tallaid.Enabled = var;
                cmb_temporadaid.Enabled = var;

                chk_ta01.Enabled = var;
                chk_ta02.Enabled = var;
                chk_ta03.Enabled = var;
                chk_ta04.Enabled = var;
                chk_ta05.Enabled = var;
                chk_ta06.Enabled = var;
                chk_ta07.Enabled = var;
                chk_ta08.Enabled = var;
                chk_ta09.Enabled = var;
                chk_ta10.Enabled = var;
                chk_ta11.Enabled = var;
                chk_ta12.Enabled = var;


                btn_nuevo.Enabled = false;
                btn_editar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_grabar.Enabled = false;
                btnVer.Enabled = false;
                btn_foto.Enabled = false;
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
                articid.Text = "NNN";
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

        private void Cargar_cmbProcedencia()
        {
            tb_pt_procedencia BE = new tb_pt_procedencia();
            tb_pt_procedenciaBL BL = new tb_pt_procedenciaBL();
            DataTable dt = new DataTable();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cmb_procedenciaid.DataSource = dt;
                cmb_procedenciaid.ValueMember = "procedenciaid";
                cmb_procedenciaid.DisplayMember = "procedencianame";
            }
        }


        private void Cargar_cmbTalla()
        {
            tb_pt_talla BE = new tb_pt_talla();
            tb_pt_tallaBL BL = new tb_pt_tallaBL();
            DataTable dt = new DataTable();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cmb_tallaid.DataSource = dt;
                cmb_tallaid.ValueMember = "tallaid";
                cmb_tallaid.DisplayMember = "tallaname";
            }
        }

        private void Cargar_cmbCanalventa()
        {
            tb_cp_canalventa BE = new tb_cp_canalventa();
            tb_cp_canalventaBL BL = new tb_cp_canalventaBL();
            DataTable dt = new DataTable();

            BE.digitos = 3;
            dt = BL.GetAll(EmpresaID, BE).Tables[0];

            if (dt.Rows.Count > 0)
            {
                cboCanalventaid.DataSource = dt;
                cboCanalventaid.ValueMember = "canalventaid";
                cboCanalventaid.DisplayMember = "canalventaname";
            }
        }

        private void Cargar_cmbEstacion()
        {
            var BE = new tb_pt_estacion();
            var BL = new tb_pt_estacionBL();
            var dt = new DataTable();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cmb_estacionid.DataSource = dt;
                cmb_estacionid.ValueMember = "estacionid";
                cmb_estacionid.DisplayMember = "estacionname";
            }
        }

        private void Cargar_cmbTemporada()
        {
            var BE = new tb_pt_temporada();
            var BL = new tb_pt_temporadaBL();
            var dt = new DataTable();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cmb_temporadaid.DataSource = dt;
                cmb_temporadaid.ValueMember = "temporadaid";
                cmb_temporadaid.DisplayMember = "temporadaname";
            }
        }

        private void Cargar_cmbEstado()
        {
            var BE = new tb_pt_estado();
            var BL = new tb_pt_estadoBL();
            var dt = new DataTable();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cmb_estadoid.DataSource = dt;
                cmb_estadoid.ValueMember = "estadoid";
                cmb_estadoid.DisplayMember = "estadoname";
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
                BE.detalle = articid.Text.Trim() + "/" + articname.Text.Trim().ToUpper()  + "/" + XGLOSA;

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
                txtvariante.Text = string.Empty;
                txtcodtizados.Text = string.Empty;
                txt_criterio.Text = string.Empty;
                grupoid.Text = string.Empty;
                gruponame.Text = string.Empty;
                articname.Text = string.Empty;
                lineaid.Text = string.Empty;
                lineaname.Text = string.Empty;
                marcaid.Text = string.Empty;
                marcaname.Text = string.Empty;
                coleccionid.Text = string.Empty;
                coleccionname.Text = string.Empty;
                subcoleccionid.Text = string.Empty;
                subcoleccionname.Text = string.Empty;
                modeloid.Text = string.Empty;
                modeloname.Text = string.Empty;
                familiatelaid.Text = string.Empty;
                familiatelaname.Text = string.Empty;
                articid.Text = "0000";
                articidold.Text = string.Empty;
                articname.Text = string.Empty;
                prec_costo.Text = "0.0000";
                real_costo.Text = "0.0000";
                precventa_cre_mayor.Text = "0.0000";
                precventa_cre_menor.Text = "0.0000";
                precventa_csc_mayor.Text = "0.0000";
                precventa_csc_menor.Text = "0.0000";
                precventa_tda_mayor.Text = "0.0000";
                precventa_tda_menor.Text = "0.0000";
                prec_etiq.Text = "0.0000";
                prec_ofer.Text = "0.0000";

                cmb_botapieid.SelectedIndex = -1;
                cmb_categoriaid.SelectedIndex = -1;
                cmb_entalleid.SelectedIndex = -1;
                cmb_esmercaderia.SelectedIndex = -1;

                cboCanalventaid.SelectedIndex = -1;
                cmb_estacionid.SelectedIndex = -1;
                cmb_estadoid.SelectedIndex = -1;
                cmb_generoid.SelectedIndex = -1;
                cmb_parteid.SelectedIndex = -1;
                cmb_procedenciaid.SelectedIndex = -1;
                cmb_tallaid.SelectedIndex = -1;
                cmb_temporadaid.SelectedIndex = -1;

                chk_ta01.Checked = false;
                chk_ta01.Text = string.Empty;
                chk_ta02.Checked = false;
                chk_ta02.Text = string.Empty;
                chk_ta03.Checked = false;
                chk_ta03.Text = string.Empty;
                chk_ta04.Checked = false;
                chk_ta04.Text = string.Empty;
                chk_ta05.Checked = false;
                chk_ta05.Text = string.Empty;
                chk_ta06.Checked = false;
                chk_ta06.Text = string.Empty;
                chk_ta07.Checked = false;
                chk_ta07.Text = string.Empty;
                chk_ta08.Checked = false;
                chk_ta08.Text = string.Empty;
                chk_ta09.Checked = false;
                chk_ta09.Text = string.Empty;
                chk_ta10.Checked = false;
                chk_ta10.Text = string.Empty;
                chk_ta11.Checked = false;
                chk_ta11.Text = string.Empty;
                chk_ta12.Checked = false;
                chk_ta12.Text = string.Empty;

                _xbotapiedescort = string.Empty;
                _xgenerodescort = string.Empty;
                _xlineadescort = string.Empty;
                _xmarcadescort = string.Empty;
                _xentalledescort = string.Empty;
                _xmodelodescort = string.Empty;
                _xlineaidold = string.Empty;
                _xmarcaidold = string.Empty;
                _estructuraid = string.Empty;
                _tejidoid = string.Empty;

                foto.Visible = false;
                foto.ImageLocation = string.Empty;
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
            articid.Text = "0000";
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_foto.Enabled = true;
            btnVer.Enabled = true;
            btn_log.Enabled = true;
            articname.Focus();

            ssModo = "NEW";
        }

        private void Insert()
        {
            try
            {
                if (articid.Text.Trim().Length != 4)
                {
                    MessageBox.Show("Falta Codigo Artículo !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (grupoid.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Falta Codigo de Proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                        if (articidold.Text.Trim().Length == 0)
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
                                                            if (cmb_tallaid.SelectedIndex == -1)
                                                            {
                                                                MessageBox.Show("Falta Seleccionar Talla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                return;
                                                            }
                                                            else
                                                            {
                                                                if (cmb_procedenciaid.SelectedIndex == -1)
                                                                {
                                                                    MessageBox.Show("Falta Seleccionar Procedencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                    return;
                                                                }
                                                                else
                                                                {
                                                                    if (cmb_esmercaderia.SelectedIndex == -1)
                                                                    {
                                                                        MessageBox.Show("Falta Seleccionar Tipo Existencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                        return;
                                                                    }
                                                                    else
                                                                    {
                                                                        if (cmb_estadoid.SelectedIndex == -1)
                                                                        {
                                                                            MessageBox.Show("Falta Seleccionar Situación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                            return;
                                                                        }
                                                                        else
                                                                        {
                                                                            if (prec_costo.Text.Trim().Length == 0)
                                                                            {
                                                                                MessageBox.Show("Falta Ingresar el Prec-Costo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                return;
                                                                            }
                                                                            else
                                                                            {
                                                                                var BL = new tb_pt_articuloBL();
                                                                                var BE = new tb_pt_articulo();

                                                                                BE.articid = articid.Text.Trim();
                                                                                BE.articidold = articidold.Text.Trim();
                                                                                BE.articname = articname.Text.Trim();
                                                                                BE.articdsav = string.Empty;
                                                                                BE.preccosto = Convert.ToDecimal(prec_costo.Text.Trim());
                                                                                BE.real_costo = Convert.ToDecimal(real_costo.Text.Trim());
                                                                                BE.precventa_cre_mayor = Convert.ToDecimal(precventa_cre_mayor.Text.Trim());
                                                                                BE.precventa_cre_menor = Convert.ToDecimal(precventa_cre_menor.Text.Trim());
                                                                                BE.precventa_tda_mayor = Convert.ToDecimal(precventa_tda_mayor.Text.Trim());
                                                                                BE.precventa_tda_menor = Convert.ToDecimal(precventa_tda_menor.Text.Trim());
                                                                                BE.precventa_csc_mayor = Convert.ToDecimal(precventa_csc_mayor.Text.Trim());
                                                                                BE.precventa_csc_menor = Convert.ToDecimal(precventa_csc_menor.Text.Trim());
                                                                                BE.categoriaid = cmb_categoriaid.SelectedValue.ToString();
                                                                                BE.marcaid = marcaid.Text.Trim();
                                                                                BE.lineaid = lineaid.Text.Trim();
                                                                                BE.generoid = cmb_generoid.SelectedValue.ToString();
                                                                                BE.tejidoid = _tejidoid.ToString();
                                                                                BE.familiatelaid = familiatelaid.Text.Trim();
                                                                                BE.botapieid = cmb_botapieid.SelectedValue.ToString();
                                                                                BE.entalleid = cmb_entalleid.SelectedValue.ToString();
                                                                                BE.coleccionid = coleccionid.Text.Trim();
                                                                                BE.subcoleccionid = subcoleccionid.Text.Trim();
                                                                                BE.telaidvfp = string.Empty;
                                                                                BE.modeloid = modeloid.Text.Trim();
                                                                                BE.estructuraid = _estructuraid.ToString();
                                                                                if (cboCanalventaid.SelectedValue != null)
                                                                                {
                                                                                    BE.canalventaid = cboCanalventaid.SelectedValue.ToString();
                                                                                }
                                                                                if (cmb_estacionid.SelectedValue != null)
                                                                                {
                                                                                    BE.estacionid = cmb_estacionid.SelectedValue.ToString();
                                                                                }
                                                                                if (cmb_temporadaid.SelectedValue != null)
                                                                                {
                                                                                    BE.temporadaid = cmb_temporadaid.SelectedValue.ToString();
                                                                                }
                                                                                BE.procedenciaid = cmb_procedenciaid.SelectedValue.ToString();
                                                                                BE.grupoid = grupoid.Text.Trim();
                                                                                BE.rubroid = string.Empty;
                                                                                BE.parte = cmb_parteid.SelectedValue.ToString();
                                                                                BE.tallaid = cmb_tallaid.SelectedValue.ToString();
                                                                                BE.ta01 = chk_ta01.Checked;
                                                                                BE.ta02 = chk_ta02.Checked;
                                                                                BE.ta03 = chk_ta03.Checked;
                                                                                BE.ta04 = chk_ta04.Checked;
                                                                                BE.ta05 = chk_ta05.Checked;
                                                                                BE.ta06 = chk_ta06.Checked;
                                                                                BE.ta07 = chk_ta07.Checked;
                                                                                BE.ta08 = chk_ta08.Checked;
                                                                                BE.ta09 = chk_ta09.Checked;
                                                                                BE.ta10 = chk_ta10.Checked;
                                                                                BE.ta11 = chk_ta11.Checked;
                                                                                BE.ta12 = chk_ta12.Checked;
                                                                                BE.variante = txtvariante.Text.Trim();
                                                                                BE.codinge = txtcodtizados.Text.Trim();
                                                                                BE.prec_etiq = Convert.ToDecimal(prec_etiq.Text.ToString());
                                                                                BE.prec_ofer = Convert.ToDecimal(prec_ofer.Text.ToString());
                                                                                BE.fechpi = DateTime.Today;
                                                                                BE.fechui = DateTime.Today;
                                                                                BE.estado = cmb_estadoid.SelectedValue.ToString();
                                                                                if (cmb_esmercaderia.SelectedIndex != -1)
                                                                                {
                                                                                    BE.es_mercaderia = Convert.ToBoolean(cmb_esmercaderia.SelectedIndex);
                                                                                }
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

        private void Insert_Foto()
        {
            try
            {
                var BL = new tb_pt_articuloBL();
                var BE = new tb_pt_articulo();
                BE.articidold = articidold.Text.Trim();
                BE.docname = _nombreFoto.ToString();
                var ms = new System.IO.MemoryStream();
                if (foto.Image != null)
                {
                    foto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                }

                BE.Foto = ms.GetBuffer();
                BL.Insert_Foto(EmpresaID, BE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Insert_DBF()
        {
            try
            {
                if (articid.Text.Trim().Length != 4)
                {
                    MessageBox.Show("Falta Codigo Artículo !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (grupoid.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Falta Codigo de Proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                        if (articidold.Text.Trim().Length == 0)
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
                                                            if (cmb_tallaid.SelectedIndex == -1)
                                                            {
                                                                MessageBox.Show("Falta Seleccionar Talla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                return;
                                                            }
                                                            else
                                                            {
                                                                if (cmb_procedenciaid.SelectedIndex == -1)
                                                                {
                                                                    MessageBox.Show("Falta Seleccionar Procedencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                    return;
                                                                }
                                                                else
                                                                {
                                                                    if (cmb_esmercaderia.SelectedIndex == -1)
                                                                    {
                                                                        MessageBox.Show("Falta Seleccionar Tipo Existencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                        return;
                                                                    }
                                                                    else
                                                                    {
                                                                        if (cmb_estadoid.SelectedIndex == -1)
                                                                        {
                                                                            MessageBox.Show("Falta Seleccionar Situación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                            return;
                                                                        }
                                                                        else
                                                                        {
                                                                            if (prec_costo.Text.Trim().Length == 0)
                                                                            {
                                                                                MessageBox.Show("Falta Ingresar el Prec-Costo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                return;
                                                                            }
                                                                            else
                                                                            {
                                                                                var BL = new tb_pt_articuloBL();
                                                                                var BE = new tb_pt_articulo();

                                                                                BE.articid = articid.Text.Trim();
                                                                                BE.articidold = articidold.Text.Trim();
                                                                                BE.articname = articname.Text.Trim();
                                                                                BE.articdsav = string.Empty;
                                                                                BE.preccosto = Convert.ToDecimal(prec_costo.Text.Trim());

                                                                                if (real_costo.Text.Length > 0)
                                                                                {
                                                                                    BE.real_costo = Convert.ToDecimal(real_costo.Text.Trim());
                                                                                }
                                                                                else
                                                                                {
                                                                                    BE.real_costo = Convert.ToDecimal("0");
                                                                                }

                                                                                BE.precventa_cre_mayor = Convert.ToDecimal(precventa_cre_mayor.Text.Trim());
                                                                                BE.precventa_cre_menor = Convert.ToDecimal(precventa_cre_menor.Text.Trim());
                                                                                BE.precventa_tda_mayor = Convert.ToDecimal(precventa_tda_mayor.Text.Trim());
                                                                                BE.precventa_tda_menor = Convert.ToDecimal(precventa_tda_menor.Text.Trim());
                                                                                BE.precventa_csc_mayor = Convert.ToDecimal(precventa_csc_mayor.Text.Trim());
                                                                                BE.precventa_csc_menor = Convert.ToDecimal(precventa_csc_menor.Text.Trim());
                                                                                BE.categoriaid = Equivalencias.Right(cmb_categoriaid.SelectedValue.ToString(), 1);

                                                                                BE.marcaid = marcaid.Text.Trim();
                                                                                BE.lineaid = lineaid.Text.Trim();
                                                                                BE.generoid = cmb_generoid.SelectedValue.ToString();

                                                                                if (cmb_generoid.SelectedValue.ToString() == "1".ToString())
                                                                                {
                                                                                    BE.generoid2 = "C".ToString();
                                                                                }
                                                                                if (cmb_generoid.SelectedValue.ToString() == "2".ToString())
                                                                                {
                                                                                    BE.generoid2 = "D".ToString();
                                                                                }
                                                                                if (cmb_generoid.SelectedValue.ToString() == "3".ToString())
                                                                                {
                                                                                    BE.generoid2 = "N".ToString();
                                                                                }

                                                                                BE.tejidoid = _tejidoid.ToString();
                                                                                BE.familiatelaid = familiatelaid.Text.Trim();
                                                                                BE.botapieid = cmb_botapieid.SelectedValue.ToString();
                                                                                BE.entalleid = cmb_entalleid.SelectedValue.ToString();
                                                                                BE.coleccionid = coleccionid.Text.Trim();
                                                                                BE.subcoleccionid = subcoleccionid.Text.Trim();

                                                                                if (cmb_temporadaid.SelectedIndex != -1)
                                                                                {
                                                                                    BE.temporadaid = cmb_temporadaid.SelectedValue.ToString();
                                                                                }
                                                                                else
                                                                                {
                                                                                    BE.temporadaid = string.Empty;
                                                                                }

                                                                                BE.telaidvfp = string.Empty;
                                                                                BE.modeloid = modeloid.Text.Trim();
                                                                                BE.estructuraid = _estructuraid.ToString();
                                                                                if (cmb_estacionid.SelectedValue != null)
                                                                                {
                                                                                    BE.estacionid = cmb_estacionid.SelectedValue.ToString();
                                                                                }
                                                                                else
                                                                                {
                                                                                    BE.estacionid = string.Empty.ToString();
                                                                                }

                                                                                if (cmb_temporadaid.SelectedValue != null)
                                                                                {
                                                                                    BE.temporadaid = cmb_temporadaid.SelectedValue.ToString();
                                                                                }
                                                                                else
                                                                                {
                                                                                    BE.temporadaid = string.Empty.ToString();
                                                                                }

                                                                                BE.procedenciaid = cmb_procedenciaid.SelectedValue.ToString();
                                                                                BE.grupoid = grupoid.Text.Trim();
                                                                                BE.rubroid = string.Empty;
                                                                                BE.parte = cmb_parteid.SelectedValue.ToString();
                                                                                BE.tallaid = cmb_tallaid.SelectedValue.ToString();
                                                                                BE.ta01 = chk_ta01.Checked;
                                                                                BE.ta02 = chk_ta02.Checked;
                                                                                BE.ta03 = chk_ta03.Checked;
                                                                                BE.ta04 = chk_ta04.Checked;
                                                                                BE.ta05 = chk_ta05.Checked;
                                                                                BE.ta06 = chk_ta06.Checked;
                                                                                BE.ta07 = chk_ta07.Checked;
                                                                                BE.ta08 = chk_ta08.Checked;
                                                                                BE.ta09 = chk_ta09.Checked;
                                                                                BE.ta10 = chk_ta10.Checked;
                                                                                BE.ta11 = chk_ta11.Checked;
                                                                                BE.ta12 = chk_ta12.Checked;
                                                                                BE.variante = txtvariante.Text.Trim();
                                                                                BE.codinge = txtcodtizados.Text.Trim();
                                                                                BE.prec_etiq = Convert.ToDecimal(prec_etiq.Text.ToString());
                                                                                BE.prec_ofer = Convert.ToDecimal(prec_ofer.Text.ToString());
                                                                                BE.fechpi = DateTime.Today;
                                                                                BE.fechui = DateTime.Today;

                                                                                if (cmb_estadoid.SelectedValue.ToString() == "SA")
                                                                                {
                                                                                    BE.estado2 = true;
                                                                                }
                                                                                else
                                                                                {
                                                                                    BE.estado2 = false;
                                                                                }
                                                                                BE.estado = cmb_estadoid.SelectedValue.ToString();

                                                                                if (cmb_esmercaderia.SelectedIndex != -1)
                                                                                {
                                                                                    BE.es_mercaderia = Convert.ToBoolean(cmb_esmercaderia.SelectedIndex);
                                                                                }

                                                                                BE.status = "0";
                                                                                BE.usuar = VariablesPublicas.Usuar.Trim();

                                                                                BE.marcaname = marcaname.Text.ToString();
                                                                                BE.lineaidold = _xlineaidold.ToString();
                                                                                BE.marcaidold = _xmarcaidold.ToString();

                                                                                if (BL.Insert_dbf(EmpresaID, BE))
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
                if (articid.Text.Trim().Length != 4)
                {
                    MessageBox.Show("Falta Codigo Artículo !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (grupoid.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Falta Codigo de Proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                if (articidold.Text.Trim().Length == 0)
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
                                            if (cmb_tallaid.SelectedIndex == -1)
                                            {
                                                MessageBox.Show("Falta Seleccionar Talla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                return;
                                            }
                                            else
                                            {
                                                if (cmb_procedenciaid.SelectedIndex == -1)
                                                {
                                                    MessageBox.Show("Falta Seleccionar Procedencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    return;
                                                }
                                                else
                                                {
                                                    if (cmb_estadoid.SelectedIndex == -1)
                                                    {
                                                        MessageBox.Show("Falta Seleccionar Situación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        return;
                                                    }
                                                    else
                                                    {
                                                        if (prec_costo.Text.Trim().Length == 0)
                                                        {
                                                            MessageBox.Show("Falta Ingresar el Prec-Costo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            return;
                                                        }
                                                        else
                                                        {
                                                            var BL = new tb_pt_articuloBL();
                                                            var BE = new tb_pt_articulo();

                                                            BE.articid = articid.Text.Trim();
                                                            BE.articidold = articidold.Text.Trim();
                                                            BE.articname = articname.Text.Trim();
                                                            BE.articdsav = string.Empty;

                                                            BE.preccosto = Convert.ToDecimal(prec_costo.Text.Trim());
                                                            if (real_costo.Text.Length > 0)
                                                            {
                                                                BE.real_costo = Convert.ToDecimal(real_costo.Text.Trim());
                                                            }
                                                            else
                                                            {
                                                                BE.real_costo = Convert.ToDecimal("0");
                                                            }

                                                            BE.precventa_cre_mayor = Convert.ToDecimal(precventa_cre_mayor.Text.Trim());
                                                            BE.precventa_cre_menor = Convert.ToDecimal(precventa_cre_menor.Text.Trim());
                                                            BE.precventa_tda_mayor = Convert.ToDecimal(precventa_tda_mayor.Text.Trim());
                                                            BE.precventa_tda_menor = Convert.ToDecimal(precventa_tda_menor.Text.Trim());
                                                            BE.precventa_csc_mayor = Convert.ToDecimal(precventa_csc_mayor.Text.Trim());
                                                            BE.precventa_csc_menor = Convert.ToDecimal(precventa_csc_menor.Text.Trim());
                                                            BE.categoriaid = cmb_categoriaid.SelectedValue.ToString();
                                                            BE.marcaid = marcaid.Text.Trim();
                                                            BE.lineaid = lineaid.Text.Trim();
                                                            BE.generoid = cmb_generoid.SelectedValue.ToString();
                                                            BE.tejidoid = _tejidoid.ToString();
                                                            BE.familiatelaid = familiatelaid.Text.Trim();
                                                            if (cmb_botapieid.SelectedIndex != -1)
                                                            {
                                                                BE.botapieid = cmb_botapieid.SelectedValue.ToString();
                                                            }
                                                            else
                                                            {
                                                                BE.botapieid = string.Empty.ToString();
                                                            }

                                                            if (cmb_entalleid.SelectedIndex != -1)
                                                            {
                                                                BE.entalleid = cmb_entalleid.SelectedValue.ToString();
                                                            }
                                                            else
                                                            {
                                                                BE.entalleid = string.Empty.ToString();
                                                            }

                                                            BE.coleccionid = coleccionid.Text.Trim();
                                                            BE.subcoleccionid = subcoleccionid.Text.Trim();
                                                            BE.telaidvfp = string.Empty;
                                                            BE.modeloid = modeloid.Text.Trim();
                                                            BE.estructuraid = _estructuraid.ToString();
                                                            if (cboCanalventaid.SelectedValue != null)
                                                            {
                                                                BE.canalventaid = cboCanalventaid.SelectedValue.ToString();
                                                            }
                                                            if (cmb_estacionid.SelectedValue != null)
                                                            {
                                                                BE.estacionid = cmb_estacionid.SelectedValue.ToString();
                                                            }
                                                            if (cmb_temporadaid.SelectedValue != null)
                                                            {
                                                                BE.temporadaid = cmb_temporadaid.SelectedValue.ToString();
                                                            }
                                                            BE.procedenciaid = cmb_procedenciaid.SelectedValue.ToString();
                                                            BE.grupoid = grupoid.Text.Trim();
                                                            BE.rubroid = string.Empty;
                                                            if (cmb_parteid.SelectedIndex != -1)
                                                            {
                                                                BE.parte = cmb_parteid.SelectedValue.ToString();
                                                            }
                                                            else
                                                            {
                                                                BE.parte = string.Empty.ToString();
                                                            }
                                                            BE.tallaid = cmb_tallaid.SelectedValue.ToString();
                                                            BE.ta01 = chk_ta01.Checked;
                                                            BE.ta02 = chk_ta02.Checked;
                                                            BE.ta03 = chk_ta03.Checked;
                                                            BE.ta04 = chk_ta04.Checked;
                                                            BE.ta05 = chk_ta05.Checked;
                                                            BE.ta06 = chk_ta06.Checked;
                                                            BE.ta07 = chk_ta07.Checked;
                                                            BE.ta08 = chk_ta08.Checked;
                                                            BE.ta09 = chk_ta09.Checked;
                                                            BE.ta10 = chk_ta10.Checked;
                                                            BE.ta11 = chk_ta11.Checked;
                                                            BE.ta12 = chk_ta12.Checked;
                                                            BE.variante = txtvariante.Text.Trim();
                                                            BE.codinge = txtcodtizados.Text.Trim();
                                                            BE.prec_etiq = Convert.ToDecimal(prec_etiq.Text.ToString());
                                                            BE.prec_ofer = Convert.ToDecimal(prec_ofer.Text.ToString());
                                                            BE.fechpi = DateTime.Today;
                                                            BE.fechui = DateTime.Today;
                                                            BE.estado = cmb_estadoid.SelectedValue.ToString();
                                                            if (cmb_esmercaderia.SelectedIndex != -1)
                                                            {
                                                                BE.es_mercaderia = Convert.ToBoolean(cmb_esmercaderia.SelectedIndex);
                                                            }
                                                            BE.status = "0";
                                                            BE.usuar = VariablesPublicas.Usuar.Trim();
                                                            BE.nivel = XNIVEL;

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Update_DBF()
        {
            try
            {
                if (articid.Text.Trim().Length != 4)
                {
                    MessageBox.Show("Falta Codigo Artículo !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (grupoid.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Falta Codigo de Proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                if (articidold.Text.Trim().Length == 0)
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
                                            if (cmb_tallaid.SelectedIndex == -1)
                                            {
                                                MessageBox.Show("Falta Seleccionar Talla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                return;
                                            }
                                            else
                                            {
                                                if (cmb_procedenciaid.SelectedIndex == -1)
                                                {
                                                    MessageBox.Show("Falta Seleccionar Procedencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    return;
                                                }
                                                else
                                                {
                                                    if (cmb_estadoid.SelectedIndex == -1)
                                                    {
                                                        MessageBox.Show("Falta Seleccionar Situación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        return;
                                                    }
                                                    else
                                                    {
                                                        if (prec_costo.Text.Trim().Length == 0)
                                                        {
                                                            MessageBox.Show("Falta Ingresar el Prec-Costo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            return;
                                                        }
                                                        else
                                                        {
                                                            var BL = new tb_pt_articuloBL();
                                                            var BE = new tb_pt_articulo();

                                                            BE.articid = articid.Text.Trim();
                                                            BE.articidold = articidold.Text.Trim();
                                                            BE.articname = articname.Text.Trim();
                                                            BE.articdsav = string.Empty;
                                                            BE.preccosto = Convert.ToDecimal(prec_costo.Text.Trim());
                                                            if (real_costo.Text.Length > 0)
                                                            {
                                                                BE.real_costo = Convert.ToDecimal(real_costo.Text.Trim());
                                                            }
                                                            else
                                                            {
                                                                BE.real_costo = Convert.ToDecimal("0.00".ToString());
                                                            }
                                                            BE.precventa_cre_mayor = Convert.ToDecimal(precventa_cre_mayor.Text.Trim());
                                                            BE.precventa_cre_menor = Convert.ToDecimal(precventa_cre_menor.Text.Trim());
                                                            BE.precventa_tda_mayor = Convert.ToDecimal(precventa_tda_mayor.Text.Trim());
                                                            BE.precventa_tda_menor = Convert.ToDecimal(precventa_tda_menor.Text.Trim());
                                                            BE.precventa_csc_mayor = Convert.ToDecimal(precventa_csc_mayor.Text.Trim());
                                                            BE.precventa_csc_menor = Convert.ToDecimal(precventa_csc_menor.Text.Trim());

                                                            BE.categoriaid = Equivalencias.Right(cmb_categoriaid.SelectedValue.ToString(), 1);

                                                            BE.marcaid = marcaid.Text.Trim();
                                                            BE.lineaid = lineaid.Text.Trim();

                                                            BE.generoid = cmb_generoid.SelectedValue.ToString();

                                                            if (cmb_generoid.SelectedValue.ToString() == "1".ToString())
                                                            {
                                                                BE.generoid2 = "C".ToString();
                                                            }
                                                            if (cmb_generoid.SelectedValue.ToString() == "2".ToString())
                                                            {
                                                                BE.generoid2 = "D".ToString();
                                                            }
                                                            if (cmb_generoid.SelectedValue.ToString() == "3".ToString())
                                                            {
                                                                BE.generoid2 = "N".ToString();
                                                            }

                                                            BE.tejidoid = _tejidoid.ToString();
                                                            BE.familiatelaid = familiatelaid.Text.Trim();

                                                            if (cmb_botapieid.SelectedIndex != -1)
                                                            {
                                                                BE.botapieid = cmb_botapieid.SelectedValue.ToString();
                                                            }
                                                            else
                                                            {
                                                                BE.botapieid = string.Empty.ToString();
                                                            }

                                                            if (cmb_entalleid.SelectedIndex != -1)
                                                            {
                                                                BE.entalleid = cmb_entalleid.SelectedValue.ToString();
                                                            }
                                                            else
                                                            {
                                                                BE.entalleid = string.Empty.ToString();
                                                            }

                                                            BE.coleccionid = coleccionid.Text.Trim();
                                                            BE.subcoleccionid = subcoleccionid.Text.Trim();

                                                            if (cmb_temporadaid.SelectedIndex != -1)
                                                            {
                                                                BE.temporadaid = cmb_temporadaid.SelectedValue.ToString();
                                                            }
                                                            else
                                                            {
                                                                BE.temporadaid = string.Empty;
                                                            }


                                                            BE.telaidvfp = string.Empty;
                                                            BE.modeloid = modeloid.Text.Trim();
                                                            BE.estructuraid = _estructuraid.ToString();

                                                            if (cmb_estacionid.SelectedValue != null)
                                                            {
                                                                BE.estacionid = cmb_estacionid.SelectedValue.ToString();
                                                            }
                                                            else
                                                            {
                                                                BE.estacionid = string.Empty.ToString();
                                                            }

                                                            if (cmb_temporadaid.SelectedValue != null)
                                                            {
                                                                BE.temporadaid = cmb_temporadaid.SelectedValue.ToString();
                                                            }
                                                            else
                                                            {
                                                                BE.temporadaid = string.Empty.ToString();
                                                            }

                                                            BE.procedenciaid = cmb_procedenciaid.SelectedValue.ToString();
                                                            BE.grupoid = grupoid.Text.Trim();
                                                            BE.rubroid = string.Empty;
                                                            if (cmb_parteid.SelectedIndex != -1)
                                                            {
                                                                BE.parte = cmb_parteid.SelectedValue.ToString();
                                                            }
                                                            else
                                                            {
                                                                BE.parte = string.Empty.ToString();
                                                            }
                                                            BE.tallaid = cmb_tallaid.SelectedValue.ToString();
                                                            BE.ta01 = chk_ta01.Checked;
                                                            BE.ta02 = chk_ta02.Checked;
                                                            BE.ta03 = chk_ta03.Checked;
                                                            BE.ta04 = chk_ta04.Checked;
                                                            BE.ta05 = chk_ta05.Checked;
                                                            BE.ta06 = chk_ta06.Checked;
                                                            BE.ta07 = chk_ta07.Checked;
                                                            BE.ta08 = chk_ta08.Checked;
                                                            BE.ta09 = chk_ta09.Checked;
                                                            BE.ta10 = chk_ta10.Checked;
                                                            BE.ta11 = chk_ta11.Checked;
                                                            BE.ta12 = chk_ta12.Checked;
                                                            BE.variante = txtvariante.Text.Trim();
                                                            BE.codinge = txtcodtizados.Text.Trim();
                                                            BE.prec_etiq = Convert.ToDecimal(prec_etiq.Text.ToString());
                                                            BE.prec_ofer = Convert.ToDecimal(prec_ofer.Text.ToString());
                                                            BE.fechpi = DateTime.Today;
                                                            BE.fechui = DateTime.Today;

                                                            if (cmb_estadoid.SelectedValue.ToString() == "SA")
                                                            {
                                                                BE.estado2 = true;
                                                            }
                                                            else
                                                            {
                                                                BE.estado2 = false;
                                                            }
                                                            BE.estado = cmb_estadoid.SelectedValue.ToString();

                                                            if (cmb_esmercaderia.SelectedIndex != -1)
                                                            {
                                                                BE.es_mercaderia = Convert.ToBoolean(cmb_esmercaderia.SelectedIndex);
                                                            }

                                                            BE.status = "0";
                                                            BE.usuar = VariablesPublicas.Usuar.Trim();

                                                            BE.marcaname = marcaname.Text.ToString();
                                                            BE.lineaidold = _xlineaidold.ToString();
                                                            BE.marcaidold = _xmarcaidold.ToString();

                                                            if (BL.Update_dbf(EmpresaID, BE))
                                                            {
                                                                MessageBox.Show("Datos Modificados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Update_Foto()
        {
            try
            {
                var BL = new tb_pt_articuloBL();
                var BE = new tb_pt_articulo();
                BE.articidold = articidold.Text.Trim();
                BE.docname = _nombreFoto.ToString();
                var ms = new System.IO.MemoryStream();

                if (foto.Image != null)
                {
                    foto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                }

                BE.Foto = ms.GetBuffer();
                BL.Update_foto(EmpresaID, BE);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Delete()
        {
            try
            {
                if (articid.Text.Trim().Length != 4)
                {
                    MessageBox.Show("Falta Codigo Artículo !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_pt_articuloBL();
                    var BE = new tb_pt_articulo();
                    BE.articid = articid.Text.Trim().PadLeft(4, '0');

                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos Eliminados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        form_bloqueado(false);
                        data_Tablaarticulo();
                        btn_nuevo.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_articulo_Load(object sender, EventArgs e)
        {
            if (Parent.Parent.Name == "MainProduccion")
            {
                modulo = ((D70Produccion.MainProduccion)MdiParent).moduloid;
                local = ((D70Produccion.MainProduccion)MdiParent).local;
                PERFILID = ((D70Produccion.MainProduccion)MdiParent).perfil;
            }

            if (Parent.Parent.Name == "MainMercaderia02")
            {
                modulo = ((MERCADERIA02.MainMercaderia02)MdiParent).moduloid;
                local = ((MERCADERIA02.MainMercaderia02)MdiParent).local;
                PERFILID = ((MERCADERIA02.MainMercaderia02)MdiParent).perfil;
            }

            NIVEL_FORMS();
            Tablaarticulo = new DataTable();

            articname.CharacterCasing = CharacterCasing.Upper;

            Cargar_cmbCategoria();
            Cargar_cmbGenero();
            Cargar_cmbParte();
            Cargar_cmbEntalle();
            Cargar_cmbBotapie();
            Cargar_cmbTalla();

            Cargar_cmbCanalventa();
            Cargar_cmbEstacion();
            Cargar_cmbTemporada();
            Cargar_cmbProcedencia();
            Cargar_cmbEstado();

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
                bloqueo_paneles(false);
                pnl_02.Enabled = false;
                pnl_06.Enabled = false;
                pnl_05.Enabled = true;
                pnl_03.Enabled = false;
                txtvariante.Focus();
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0" || XNIVEL == "1")
            {
                ssModo = "EDIT";
                form_bloqueado(true);
                articname.Focus();

                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
                btn_foto.Enabled = true;
                btnVer.Enabled = true;


                var BE = new tb_pt_marca();
                var BL = new tb_pt_marcaBL();
                var dt = new DataTable();
                BE.marcaid = marcaid.Text.Trim();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    _xmarcadescort = row["marcadescort"].ToString();
                }


                var BE2 = new tb_pt_linea();
                var BL2 = new tb_pt_lineaBL();
                var dt2 = new DataTable();
                BE2.lineaid = lineaid.Text.Trim();
                dt2 = BL2.GetAll(EmpresaID, BE2).Tables[0];
                foreach (DataRow row in dt2.Rows)
                {
                    _xlineadescort = row["lineadescort"].ToString();
                }


                var BE3 = new tb_pt_modelo();
                var BL3 = new tb_pt_modeloBL();
                var dt3 = new DataTable();
                BE3.modeloid = modeloid.Text.Trim();
                dt3 = BL3.GetAll(EmpresaID, BE3).Tables[0];
                foreach (DataRow row in dt3.Rows)
                {
                    _xmodelodescort = row["modelodescort"].ToString();
                }

                if (XNIVEL == "1")
                {
                    bloqueo_paneles(false);
                    pnl_01.Enabled = true;
                    pnl_03.Enabled = true;
                }
                else
                {
                    bloqueo_paneles(true);
                    pnl_02.Enabled = false;
                    pnl_05.Enabled = false;
                    pnl_06.Enabled = false;
                    pnl_03.Enabled = true;
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
                foreach (DataRow row in dt.Rows)
                {
                    if (row["marcadescort"].ToString().Trim() != string.Empty)
                    {
                        _xmarcadescort = row["marcadescort"].ToString();
                    }
                    else
                    {
                        _xmarcadescort = row["marcaname"].ToString();
                    }
                    marcaid.Text = row["marcaid"].ToString();
                    marcaname.Text = row["marcaname"].ToString();
                    _xmarcaidold = row["marcaidold"].ToString();
                }
            }
            else
            {
                _xmarcadescort = string.Empty;
                marcaid.Text = string.Empty;
                marcaname.Text = string.Empty;
                _xmarcaidold = string.Empty;
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
                if (dt2.Rows[0]["lineadescort"].ToString().Trim() != string.Empty)
                {
                    _xlineadescort = dt2.Rows[0]["lineadescort"].ToString();
                }
                else
                {
                    _xlineadescort = dt2.Rows[0]["lineaname"].ToString();
                }

                lineaid.Text = dt2.Rows[0]["lineaid"].ToString();
                lineaname.Text = dt2.Rows[0]["lineaname"].ToString();
                _xlineaidold = dt2.Rows[0]["lineaidold"].ToString();
            }
            else
            {
                _xlineadescort = string.Empty;
                lineaid.Text = string.Empty;
                lineaname.Text = string.Empty;
                _xlineaidold = string.Empty;
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
                if (dt3.Rows[0]["modelodescort"].ToString().Trim() != string.Empty)
                {
                    _xmodelodescort = dt3.Rows[0]["modelodescort"].ToString();
                }
                else
                {
                    _xmodelodescort = dt3.Rows[0]["modeloname"].ToString();
                }


                modeloid.Text = dt3.Rows[0]["modeloid"].ToString();
                modeloname.Text = dt3.Rows[0]["modeloname"].ToString();
            }
            else
            {
                _xmodelodescort = string.Empty;
                modeloid.Text = string.Empty;
                modeloname.Text = string.Empty;
            }
        }

        private void Valida_Grupo(String xcod)
        {
            var BE3 = new tb_pt_grupo();
            var BL3 = new tb_pt_grupoBL();
            var dt3 = new DataTable();
            BE3.grupoid = xcod.Trim();
            dt3 = BL3.GetAll(EmpresaID, BE3).Tables[0];
            if (dt3.Rows.Count > 0)
            {
                grupoid.Text = dt3.Rows[0]["grupoid"].ToString();
                gruponame.Text = dt3.Rows[0]["gruponame"].ToString();
            }
            else
            {
                grupoid.Text = string.Empty;
                gruponame.Text = string.Empty;
            }
        }

        private void Valida_Familia(String xcod)
        {
            var BE = new tb_pt_familia();
            var BL = new tb_pt_familiaBL();
            var dt = new DataTable();
            BE.moduloid = "0320".ToString();
            BE.familiaid = xcod.Trim();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                familiatelaid.Text = dt.Rows[0]["familiaid"].ToString();
                familiatelaname.Text = dt.Rows[0]["familianame"].ToString();
                _estructuraid = dt.Rows[0]["estructuraid"].ToString();
                _tejidoid = dt.Rows[0]["lineaid"].ToString();
            }
            else
            {
                familiatelaid.Text = string.Empty;
                familiatelaname.Text = string.Empty;
                _estructuraid = string.Empty;
                _tejidoid = string.Empty;
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            form_accion_cancelEdicion(1);
            bloqueo_paneles(false);
            pnl_02.Enabled = false;
            pnl_05.Enabled = true;
            pnl_06.Enabled = false;
            pnl_03.Enabled = false;
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
                Insert_Foto();
                ValidaInsert_Update();
            }
            else
            {
                if (XNIVEL == "0" || XNIVEL == "1")
                {
                    sw_prosigue = (MessageBox.Show("¿Desea Modificar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                    if (sw_prosigue)
                    {
                        Update();
                        Update_Foto();
                        ValidaInsert_Update();
                    }
                }
            }
            if (procesado)
            {
                NIVEL_FORMS();
                data_Tablaarticulo();
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


        private void ValidaInsert_Update()
        {
            var BL = new tb_pt_articuloBL();
            var BE = new tb_pt_articulo();
            var dt = new DataTable();
            BE.articidold = articidold.Text.Trim();
            dt = BL.GetAll_CODdbf(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                var n = Convert.ToInt32(dt.Rows[0]["cant"].ToString());
                if (n > 0)
                {
                    Update_DBF();
                }
                else
                {
                    Insert_DBF();
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

        private void data_Tablaarticulo()
        {
            try
            {
                if (Tablaarticulo.Rows.Count > 0)
                {
                    Tablaarticulo.Rows.Clear();
                }

                var BL = new tb_pt_articuloBL();
                var BE = new tb_pt_articulo();

                BE.articname = txt_criterio.Text.Trim().ToUpper();

                Tablaarticulo = BL.GetAll2(EmpresaID, BE).Tables[0];
                if (Tablaarticulo.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    mdi_gridarticulo.DataSource = Tablaarticulo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            data_Tablaarticulo();
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
                var xarticid = gridarticulo.GetRowCellValue(gridarticulo.FocusedRowHandle, "articid").ToString();
                data_articuloid(xarticid);
                act_Nombre();
            }
        }

        private void gridarticulo_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var xarticid = gridarticulo.GetRowCellValue(e.RowHandle, "articid").ToString();
            data_articuloid(xarticid);
            act_Nombre();
        }

        private void data_articuloid(String xarticid)
        {
            form_bloqueado(false);
            var rowarticid = Tablaarticulo.Select("articid='" + xarticid + "'");
            if (rowarticid.Length > 0)
            {
                foreach (DataRow row in rowarticid)
                {
                    articid.Text = row["articid"].ToString().Trim();
                    articidold.Text = row["articidold"].ToString().Trim();
                    grupoid.Text = row["grupoid"].ToString().Trim();
                    gruponame.Text = row["gruponame"].ToString().Trim();
                    articname.Text = row["articname"].ToString().Trim();
                    marcaid.Text = row["marcaid"].ToString().Trim();
                    Valida_Marca(marcaid.Text);
                    marcaname.Text = row["marcaname"].ToString().Trim();
                    lineaid.Text = row["lineaid"].ToString().Trim();
                    Valida_Linea(lineaid.Text);
                    lineaname.Text = row["lineaname"].ToString().Trim();
                    modeloid.Text = row["modeloid"].ToString().Trim();
                    modeloname.Text = row["modeloname"].ToString().Trim();
                    familiatelaid.Text = row["familiatelaid"].ToString().Trim();
                    if (familiatelaid.Text.Length > 0)
                    {
                        Valida_Familia(familiatelaid.Text);
                    }

                    familiatelaname.Text = row["familianame"].ToString().Trim();
                    coleccionid.Text = row["coleccionid"].ToString().Trim();
                    coleccionname.Text = row["coleccionname"].ToString().Trim();
                    cboCanalventaid.SelectedValue = row["canalventaid"].ToString().Trim();
                    cmb_estacionid.SelectedValue = row["estacionid"].ToString().Trim();
                    cmb_temporadaid.SelectedValue = row["temporadaid"].ToString().Trim();
                    cmb_categoriaid.SelectedValue = row["categoriaid"].ToString().Trim();
                    cmb_generoid.SelectedValue = row["generoid"].ToString().Trim();
                    cmb_parteid.SelectedValue = row["parteid"].ToString().Trim();
                    cmb_entalleid.SelectedValue = row["entalleid"].ToString().Trim();
                    cmb_botapieid.SelectedValue = row["botapieid"].ToString().Trim();
                    cmb_tallaid.SelectedValue = row["tallaid"].ToString().Trim();
                    cmb_estadoid.SelectedValue = row["estadoid"].ToString().Trim();
                    var num = Convert.ToBoolean(row["es_mercaderia"].ToString());
                    var n = 0;
                    if (num)
                    {
                        n = 1;
                    }
                    else
                    {
                        if (!num)
                        {
                            n = 0;
                        }
                    }
                    cmb_esmercaderia.SelectedIndex = n;
                    cmb_procedenciaid.SelectedValue = row["procedenciaid"].ToString().Trim();

                    chk_ta01.Checked = Convert.ToBoolean(row["ta01"].ToString().Trim());
                    chk_ta01.Text = row["talla01"].ToString().Trim();
                    chk_ta02.Checked = Convert.ToBoolean(row["ta02"].ToString().Trim());
                    chk_ta02.Text = row["talla02"].ToString().Trim();
                    chk_ta03.Checked = Convert.ToBoolean(row["ta03"].ToString().Trim());
                    chk_ta03.Text = row["talla03"].ToString().Trim();
                    chk_ta04.Checked = Convert.ToBoolean(row["ta04"].ToString().Trim());
                    chk_ta04.Text = row["talla04"].ToString().Trim();
                    chk_ta05.Checked = Convert.ToBoolean(row["ta05"].ToString().Trim());
                    chk_ta05.Text = row["talla05"].ToString().Trim();
                    chk_ta06.Checked = Convert.ToBoolean(row["ta06"].ToString().Trim());
                    chk_ta06.Text = row["talla06"].ToString().Trim();
                    chk_ta07.Checked = Convert.ToBoolean(row["ta07"].ToString().Trim());
                    chk_ta07.Text = row["talla07"].ToString().Trim();
                    chk_ta08.Checked = Convert.ToBoolean(row["ta08"].ToString().Trim());
                    chk_ta08.Text = row["talla08"].ToString().Trim();
                    chk_ta09.Checked = Convert.ToBoolean(row["ta09"].ToString().Trim());
                    chk_ta09.Text = row["talla09"].ToString().Trim();
                    chk_ta10.Checked = Convert.ToBoolean(row["ta10"].ToString().Trim());
                    chk_ta10.Text = row["talla10"].ToString().Trim();
                    chk_ta11.Checked = Convert.ToBoolean(row["ta11"].ToString().Trim());
                    chk_ta11.Text = row["talla11"].ToString().Trim();
                    chk_ta12.Checked = Convert.ToBoolean(row["ta12"].ToString().Trim());
                    chk_ta12.Text = row["talla12"].ToString().Trim();

                    txtvariante.Text = row["variante"].ToString();
                    txtcodtizados.Text = row["codinge"].ToString();

                    prec_costo.Text = row["prec_costo"].ToString();
                    real_costo.Text = row["real_costo"].ToString();
                    precventa_cre_mayor.Text = row["precventa_cre_mayor"].ToString();
                    precventa_cre_menor.Text = row["precventa_cre_menor"].ToString();
                    precventa_tda_mayor.Text = row["precventa_tda_mayor"].ToString();
                    precventa_tda_menor.Text = row["precventa_tda_menor"].ToString();
                    precventa_csc_mayor.Text = row["precventa_csc_mayor"].ToString();
                    precventa_csc_menor.Text = row["precventa_csc_menor"].ToString();
                    prec_etiq.Text = row["prec_etiq"].ToString();
                    prec_ofer.Text = row["prec_ofer"].ToString();


                    var BE = new tb_pt_articulo();
                    var BL = new tb_pt_articuloBL();
                    var dt = new DataTable();
                    BE.articidold = articidold.Text.Trim();
                    dt = BL.GetAll_foto(EmpresaID, BE).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["foto"].ToString() != string.Empty)
                        {
                            var MyData1 = (byte[])null;
                            MyData1 = (byte[])(dt.Rows[0]["foto"]);

                            if (MyData1 != null && MyData1.Length != 0)
                            {
                                vmContenidoFile = MyData1;
                                foto.Visible = true;
                                foto.Image = null;
                                var ms = new System.IO.MemoryStream();
                                _nombreFoto = dt.Rows[0]["docname"].ToString();
                                ms.Write(MyData1, 0, MyData1.Length);
                                foto.Image = Image.FromStream(ms);
                            }
                            else
                            {
                                foto.Visible = false;
                                foto.ImageLocation = string.Empty;
                            }
                        }
                        else
                        {
                            foto.Visible = false;
                            foto.ImageLocation = string.Empty;
                        }
                    }
                    else
                    {
                        foto.Visible = false;
                        foto.ImageLocation = string.Empty;
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

        private void cmb_tallaid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_tallaid.SelectedIndex >= 0)
            {
                var BE = new tb_pt_talla();
                var BL = new tb_pt_tallaBL();
                var dt = new DataTable();
                BE.tallaid = cmb_tallaid.SelectedValue.ToString();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                foreach (DataRow fila in dt.Rows)
                {
                    chk_ta01.Text = fila["talla01"].ToString();
                    chk_ta02.Text = fila["talla02"].ToString();
                    chk_ta03.Text = fila["talla03"].ToString();
                    chk_ta04.Text = fila["talla04"].ToString();
                    chk_ta05.Text = fila["talla05"].ToString();
                    chk_ta06.Text = fila["talla06"].ToString();
                    chk_ta07.Text = fila["talla07"].ToString();
                    chk_ta08.Text = fila["talla08"].ToString();
                    chk_ta09.Text = fila["talla09"].ToString();
                    chk_ta10.Text = fila["talla10"].ToString();
                    chk_ta11.Text = fila["talla11"].ToString();
                    chk_ta12.Text = fila["talla12"].ToString();
                }
            }
        }

        private void _GenerarNombre()
        {
            articname.Text = _xmarcadescort.Trim() + " " +
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
            }

            if (e.KeyCode == Keys.Enter)
            {
                var xcodmar = string.Empty;
                xcodmar = marcaid.Text.PadLeft(2, '0');
                Valida_Marca(xcodmar);
                _GenerarNombre();
                lineaid.Focus();
            }
        }

        private void AyudaMarca(String lpdescrlike)
        {
            var frmayuda = new Ayudas.Frm_help_general();

            frmayuda.tipoo = "sql";
            frmayuda.titulo = "<< AYUDA TABLA MARCA >>";
            frmayuda.sqlquery = "SELECT marcaid as Codigo, marcaname as Marca,marcadescort as Desc_Corta FROM tb_pt_marca ";
            frmayuda.sqlwhere = "where";
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

                if (xdescort.ToString().Trim() != string.Empty)
                {
                    _xmarcadescort = xdescort.ToString().Trim();
                }
                else
                {
                    _xmarcadescort = xmarcaname.ToString().Trim();
                }

                _GenerarNombre();
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

                if (xlineadescort.ToString().Trim() != string.Empty)
                {
                    _xlineadescort = xlineadescort.ToString().Trim();
                }
                else
                {
                    _xlineadescort = xlineaname.ToString().Trim();
                }

                _GenerarNombre();
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
                if (xdescort.ToString().Trim() != string.Empty)
                {
                    _xmodelodescort = xdescort.ToString().Trim();
                }
                else
                {
                    _xmodelodescort = xmodeloname.ToString().Trim();
                }

                _GenerarNombre();
            }
        }

        private void AyudaColeccion(String lpdescrlike)
        {
            var frmayuda = new Ayudas.Frm_help_general();

            frmayuda.tipoo = "sql";
            frmayuda.titulo = "<< AYUDA TABLA COLECCION >>";
            frmayuda.sqlquery = "SELECT coleccionid as Codigo, coleccionname as coleccion FROM tb_pt_coleccion";
            frmayuda.sqlwhere = "where";
            frmayuda.criteriosbusqueda = new string[] { "COLECCION", "CODIGO" };
            frmayuda.columbusqueda = "coleccionname,coleccionid";
            frmayuda.returndatos = "0,1";

            frmayuda.Owner = this;
            frmayuda.PasaProveedor = RecibeColeccion;
            frmayuda.ShowDialog();
        }

        private void RecibeColeccion(String xcoleccionid, String xcoleccionname, String xdescort, String resultado4, String resultado5)
        {
            if (xcoleccionid.Trim().Length > 0)
            {
                coleccionid.Text = xcoleccionid.Trim();
                coleccionname.Text = xcoleccionname.Trim();
            }
        }

        private void AyudaFamilia(String lpdescrlike)
        {
            var frmayuda = new Ayudas.Frm_help_general();

            frmayuda.tipoo = "sql";
            frmayuda.titulo = "<< AYUDA TABLA FAMILIAS >>";
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
                    Combinación_Marca_Modelo_Tela();
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
                articidold.Text = dt.Rows[0]["codigo"].ToString();
                bloqueo_paneles(true);
                pnl_02.Enabled = false;
                pnl_05.Enabled = false;
            }
            else
            {
                MessageBox.Show("Ya Existe Combinación ...!!!");
                limpiar_documento();
                grupoid.Focus();
                bloqueo_paneles(false);
                pnl_02.Enabled = false;
                pnl_05.Enabled = true;
                return;
            }
        }

        private void Combinación_Marca_Modelo_Tela()
        {
            var BE = new tb_pt_articulo();
            var BL = new tb_pt_articuloBL();
            var dt = new DataTable();
            BE.marcaid = marcaid.Text.Trim();
            BE.modeloid = modeloid.Text.Trim();
            BE.familiatelaid = familiatelaid.Text.Trim();

            dt = BL.GeneraCod2(EmpresaID, BE).Tables[0];
            if (dt.Rows[0]["codigo"].ToString() != string.Empty)
            {
                articidold.Text = dt.Rows[0]["codigo"].ToString();
                bloqueo_paneles(true);
                pnl_02.Enabled = false;
                pnl_06.Enabled = false;
                pnl_05.Enabled = false;
                pnl_03.Enabled = true;
            }
            else
            {
                MessageBox.Show("!!!... Ya Existe Combinación ...!!!");
                limpiar_documento();
                grupoid.Focus();
                bloqueo_paneles(false);
                pnl_02.Enabled = false;
                pnl_06.Enabled = false;
                pnl_05.Enabled = false;
                return;
            }
        }

        private void bloqueo_paneles(Boolean bloq)
        {
            pnl_01.Enabled = bloq;
            pnl_02.Enabled = bloq;
            pnl_04.Enabled = bloq;
            pnl_06.Enabled = bloq;
        }

        private void AyudaGrupo(String lpdescrlike)
        {
            var frmayuda = new Ayudas.Frm_help_general();

            frmayuda.tipoo = "sql";
            frmayuda.titulo = "<< AYUDA TABLA GRUPO >>";
            frmayuda.sqlquery = "SELECT grupoid as Codigo, gruponame as Grupo FROM tb_pt_grupo";
            frmayuda.sqlwhere = "where";
            frmayuda.criteriosbusqueda = new string[] { "PROVEEDOR", "CODIGO" };
            frmayuda.columbusqueda = "gruponame,grupoid";
            frmayuda.returndatos = "0,1";

            frmayuda.Owner = this;
            frmayuda.PasaProveedor = Recibegrupo;
            frmayuda.ShowDialog();
        }

        private void Recibegrupo(String xgrupoid, String xgruponame, String xdescort, String resultado4, String resultado5)
        {
            if (xgrupoid.Trim().Length > 0)
            {
                grupoid.Text = xgrupoid.Trim();
                gruponame.Text = xgruponame.Trim();
            }
        }

        private void lineaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaLinea(string.Empty);
            }

            if (e.KeyCode == Keys.Enter)
            {
                var xcodlinea = string.Empty;
                xcodlinea = lineaid.Text.PadLeft(2, '0');
                Valida_Linea(xcodlinea);
                _GenerarNombre();
                modeloid.Focus();
            }
        }

        private void modeloid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaModelo(string.Empty);
            }

            if (e.KeyCode == Keys.Enter)
            {
                var xcodmodelo = string.Empty;
                xcodmodelo = modeloid.Text.PadLeft(4, '0');
                Valida_Modelo(xcodmodelo);
                _GenerarNombre();
                familiatelaid.Focus();
            }
        }

        private void familiatelaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaFamilia(string.Empty);
            }

            if (e.KeyCode == Keys.Enter)
            {
                var xfamiliaid = string.Empty;
                xfamiliaid = familiatelaid.Text.PadLeft(3, '0');
                Valida_Familia(xfamiliaid);
                _GenerarNombre();
                prec_costo.Focus();
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

                        _GenerarNombre();
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
                    foreach (DataRow fila in dt.Rows)
                    {
                        if (fila["generodescort"].ToString().Trim() != string.Empty)
                        {
                            _xgenerodescort = fila["generodescort"].ToString().Trim();
                        }
                        else
                        {
                            _xgenerodescort = fila["generoname"].ToString().Trim();
                        }
                        _GenerarNombre();
                    }
                }
            }
        }

        private void coleccionid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaColeccion(string.Empty);
            }

            if (e.KeyCode == Keys.Enter)
            {
                prec_costo.Focus();
            }
        }

        private void btn_foto_Click(object sender, EventArgs e)
        {
            try
            {
                var myStream = (Stream )null;
                var openFoto = new OpenFileDialog();

                openFoto.InitialDirectory = "c:\\";
                openFoto.Title = "Seleccionar Foto ";
                openFoto.CheckFileExists = true;
                openFoto.CheckPathExists = true;

                openFoto.DefaultExt = "jpg";
                openFoto.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                openFoto.FilterIndex = 1;
                openFoto.RestoreDirectory = true;
                openFoto.ReadOnlyChecked = true;
                openFoto.ShowReadOnly = true;

                var vmnomfile = string.Empty;

                if (openFoto.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = openFoto.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            var originalImage = Image.FromFile(openFoto.FileName);
                            originalImage = fungen.CambiarTamanoImagen(originalImage, 149, 189);

                            foto.Visible = true;
                            foto.Image = originalImage;

                            vmnomfile = openFoto.FileName.Trim();
                            vmContenidoFile = VariablesPublicas.GetFileData(vmnomfile);
                            _nombreFoto = VariablesPublicas.ExtrarNombreArchivo(vmnomfile);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if ((vmContenidoFile != null) & _nombreFoto.Trim().Length > 0)
            {
                u_BorrarFile();
                xtmpfile = VariablesPublicas.TmpFile(VariablesPublicas.GetExtensionFile(_nombreFoto.ToString()));
                if (VariablesPublicas.WriteFileData(xtmpfile, vmContenidoFile))
                {
                    try
                    {
                        System.Diagnostics.Process.Start(xtmpfile);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }
            }
        }

        public void u_BorrarFile()
        {
            try
            {
                System.IO.File.Delete(xtmpfile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void preccosto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                precventa_cre_mayor.Focus();
            }
        }

        private void precventa_cre_mayor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                precventa_cre_menor.Focus();
            }
        }

        private void precventa_cre_menor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                precventa_tda_mayor.Focus();
            }
        }

        private void precventa_tda_mayor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                precventa_tda_menor.Focus();
            }
        }

        private void precventa_tda_menor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                precventa_csc_mayor.Focus();
            }
        }

        private void precventa_csc_mayor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                precventa_csc_menor.Focus();
            }
        }

        private void precventa_csc_menor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                prec_etiq.Focus();
            }
        }

        private void prec_etiq_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                prec_ofer.Focus();
            }
        }

        private void btn_fijar_Click(object sender, EventArgs e)
        {
        }

        private void grupoid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaGrupo(string.Empty);
            }

            if (e.KeyCode == Keys.Enter)
            {
                var xgrupo = string.Empty;
                xgrupo = grupoid.Text.PadLeft(4, '0');
                Valida_Grupo(xgrupo);
                marcaid.Focus();
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
                        _GenerarNombre();
                    }
                }
            }
        }

        private void txtvariante_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaVariante(string.Empty);
            }

            if (e.KeyCode == Keys.Enter)
            {
            }
        }

        private void AyudaVariante(String lpdescrlike)
        {
            var frmayuda = new Ayudas.Frm_help_general();

            frmayuda.tipoo = "sql";
            frmayuda.titulo = "<< AYUDA TABLA VARIANTES >>";
            frmayuda.sqlquery = " SELECT variante,codtizado,variantename " +
                                " FROM tb_pp_variante ";
            frmayuda.sqlwhere = " WHERE ";
            frmayuda.criteriosbusqueda = new string[] { "COD-TIZADOS", "CODIGO", "VARIANTE" };
            frmayuda.columbusqueda = "codtizado,variante,variantename";
            frmayuda.returndatos = "0,1,2";

            frmayuda.Owner = this;
            frmayuda.PasaProveedor = RecibeVariante;
            frmayuda.ShowDialog();
        }


        private void RecibeVariante(String xvariante, String xcodtizado, String xdescort, String resultado4, String resultado5)
        {
            if (xvariante.Trim().Length > 0)
            {
                txtvariante.Text = xvariante.Trim();
                txtcodtizados.Text = xcodtizado.Trim();

                CargarDatosVariantes(xvariante.ToString());
                Valida_Linea(lineaid.Text.ToString());
                Valida_Marca(marcaid.Text.ToString());
                Combinación_Marca_Modelo_Tela();
            }
        }


        private void CargarDatosVariantes(String _xcodvar)
        {
            var BL = new tb_pp_varianteBL();
            var BE = new tb_pp_variante();
            var dt = new DataTable();
            BE.variante = _xcodvar.ToString();

            dt = BL.GetAll(EmpresaID, BE).Tables[0];

            if (dt.Rows.Count > 0)
            {
                articname.Text = dt.Rows[0]["variantename"].ToString();
                cmb_categoriaid.SelectedValue = dt.Rows[0]["categoriaid"].ToString();
                marcaid.Text = dt.Rows[0]["marcaid"].ToString();
                marcaname.Text = dt.Rows[0]["marcaname"].ToString();
                _xmarcadescort = dt.Rows[0]["marcadescort"].ToString();

                lineaid.Text = dt.Rows[0]["lineaid"].ToString();
                lineaname.Text = dt.Rows[0]["lineaname"].ToString();
                if (dt.Rows[0]["lineadescort"].ToString() == string.Empty)
                {
                    _xlineadescort = dt.Rows[0]["lineaname"].ToString();
                }
                else
                {
                    _xlineadescort = dt.Rows[0]["lineadescort"].ToString();
                }

                modeloid.Text = dt.Rows[0]["modeloid"].ToString();
                modeloname.Text = dt.Rows[0]["modeloname"].ToString();
                _xmodelodescort = dt.Rows[0]["modelodescort"].ToString();

                familiatelaid.Text = dt.Rows[0]["familiatelaid"].ToString();
                familiatelaname.Text = dt.Rows[0]["familianame"].ToString();
                cmb_generoid.SelectedValue = dt.Rows[0]["generoid"].ToString();
                cmb_categoriaid.SelectedValue = dt.Rows[0]["categoriaid"].ToString();
                cmb_botapieid.SelectedValue = dt.Rows[0]["botapieid"].ToString();
                cmb_entalleid.SelectedValue = dt.Rows[0]["entalleid"].ToString();
                cmb_parteid.SelectedValue = dt.Rows[0]["parteid"].ToString();
            }
        }

        private void txtcodtizados_TextChanged(object sender, EventArgs e)
        {
        }

        private void toolRegenDenom_Click(object sender, EventArgs e)
        {
            //CargarDatosVariantes(txtvariante.Text.ToString());
            //cmb_generoid_SelectedIndexChanged(sender, e);
            //cmb_entalleid_SelectedIndexChanged(sender, e);
            //cmb_botapieid_SelectedIndexChanged(sender, e);
            var BL = new tb_pt_articuloBL();
            var BE = new tb_pt_articulo();
            DataTable dt = new DataTable();
            BE.variante = txtvariante.Text.ToString().ToUpper().Trim();
            dt = BL.GetAll_DESCORT(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                _xmarcadescort = dt.Rows[0]["marcadescort"].ToString();
                _xlineadescort = dt.Rows[0]["lineadescort"].ToString();
                _xmodelodescort = dt.Rows[0]["modelodescort"].ToString();
                _xentalledescort = dt.Rows[0]["entalledescort"].ToString();
                _xbotapiedescort = dt.Rows[0]["botapiedescort"].ToString();
                _xgenerodescort = dt.Rows[0]["generodescort"].ToString();
                _GenerarNombre();
            }           
        }

        void act_Nombre() {
            var BL = new tb_pt_articuloBL();
            var BE = new tb_pt_articulo();
            DataTable dt = new DataTable();
            BE.variante = txtvariante.Text.ToString().ToUpper().Trim();
            dt = BL.GetAll_DESCORT(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                _xmarcadescort = dt.Rows[0]["marcadescort"].ToString();
                _xlineadescort = dt.Rows[0]["lineadescort"].ToString();
                _xmodelodescort = dt.Rows[0]["modelodescort"].ToString();
                _xentalledescort = dt.Rows[0]["entalledescort"].ToString();
                _xbotapiedescort = dt.Rows[0]["botapiedescort"].ToString();
                _xgenerodescort = dt.Rows[0]["generodescort"].ToString();
                _GenerarNombre();
            }     
        }

        private void precventa_tda_mayor_KeyUp(object sender, KeyEventArgs e)
        {
            Double num = 0;
            if (precventa_tda_mayor.Text.Length > 0)
            {
                num = Convert.ToDouble(precventa_tda_mayor.Text) * 1.033;
                precventa_cre_mayor.Text = Convert.ToString(Math.Round(num,4));
                precventa_cre_menor.Text = Math.Round((num * 1.5625),4).ToString();
            }
            else {
                precventa_cre_mayor.Text = Convert.ToString(num);
                precventa_cre_menor.Text = Convert.ToString(num * 1.5625);
            }
        }

        private void precventa_cre_mayor_KeyUp(object sender, KeyEventArgs e)
        {
            Double num = 0;
            if (precventa_cre_mayor.Text.Length > 0)
            {
                num = Convert.ToDouble(precventa_cre_mayor.Text);             
                precventa_cre_menor.Text = Math.Round((num * 1.5625), 4).ToString();
            }
            else
            {               
                precventa_cre_menor.Text = Convert.ToString(num * 1.5625);
            }
        }

        




    }
}
