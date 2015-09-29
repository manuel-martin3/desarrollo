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

namespace BapFormulariosNet.D60Tienda.Administracion
{
    public partial class Frm_cuota_tienda : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable TablaCuotas;
        private DataTable TablaCuotasDet;

        private Decimal _xtipocambio;
        private Boolean procesado = false;
        private String ssModo = string.Empty;

        public Frm_cuota_tienda()
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
                perianio.Enabled = var;
                cmb_perimes.Enabled = var;
                cuotatot.Enabled = false;
                cmb_local.Enabled = var;
                cuota1.Enabled = var;
                cuota2.Enabled = false;
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
                cmb_perianio.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void get_dominio_modulo_local()
        {
            var BL = new usuariomodulolocalBL();
            var BE = new tb_usuariomodulolocal();
            BE.usuar = VariablesPublicas.Usuar.Trim();
            var dt = new DataTable();
            BE.dominioid = dominio.ToString();
            BE.moduloid = modulo.ToString();

            try
            {
                dt = BL.GetAll3(VariablesPublicas.EmpresaID, BE).Tables[0];
                cmb_local.DataSource = dt;
                cmb_local.ValueMember = "local";
                cmb_local.DisplayMember = "localname";
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
                BE.detalle = perianio.Text.Trim() + "/" + cmb_perimes.Text.Trim().ToUpper() + "/" + XGLOSA;

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
                perianio.Text = string.Empty;
                cmb_perimes.SelectedIndex = -1;
                cmb_local.SelectedIndex = -1;
                cuotatot.Text = string.Empty;
                cuota1.Text = string.Empty;
                cuota2.Text = string.Empty;
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
            ssModo = "NEW";
        }

        private void Nuevo2(Boolean var)
        {
            cuota1.Text = "0";
            cuota2.Text = "0";
            btn_save.Enabled = var;
            cuota1.Enabled = var;
            btn_cancelar.Enabled = true;
            ssModo = "NEW";
        }

        private void Insert()
        {
            try
            {
                if (perianio.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Año", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (cmb_perimes.SelectedIndex == -1)
                    {
                        MessageBox.Show("Seleccione El Mes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (cuota1.Text.ToString().Length == 0)
                        {
                            MessageBox.Show("Ingresar el Valor de La Cuota", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            var BL = new tb_me_cuota_tiendaBL();
                            var BE = new tb_me_cuota_tienda();

                            BE.perianio = perianio.Text.ToString().Trim();
                            BE.perimes = cmb_perimes.SelectedValue.ToString();
                            BE.cuota = Convert.ToDecimal(cuota1.Text.ToString().Trim());
                            BE.local = cmb_local.SelectedValue.ToString();
                            BE.usuar = VariablesPublicas.Usuar.Trim();
                            BE.fecre = Convert.ToDateTime(DateTime.Today.ToShortDateString());
                            BE.feact = Convert.ToDateTime(DateTime.Today.ToShortDateString());

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
                if (perianio.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Año", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (cmb_perimes.SelectedIndex == -1)
                    {
                        MessageBox.Show("Seleccione El Mes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (cuota1.Text.ToString().Length == 0)
                        {
                            MessageBox.Show("Ingresar el Valor de La Cuota", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            var BL = new tb_me_cuota_tiendaBL();
                            var BE = new tb_me_cuota_tienda();

                            BE.perianio = perianio.Text.ToString().Trim();
                            BE.perimes = cmb_perimes.SelectedValue.ToString();
                            BE.cuota = Convert.ToDecimal(cuota1.Text.ToString().Trim());
                            BE.local = cmb_local.SelectedValue.ToString();
                            BE.usuar = VariablesPublicas.Usuar.Trim();
                            BE.fecre = Convert.ToDateTime(DateTime.Today.ToShortDateString());
                            BE.feact = Convert.ToDateTime(DateTime.Today.ToShortDateString());

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
                if (perianio.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Año", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (cmb_perimes.SelectedIndex == -1)
                    {
                        MessageBox.Show("Seleccione El Mes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new tb_me_cuota_tiendaBL();
                        var BE = new tb_me_cuota_tienda();

                        BE.perianio = perianio.Text.ToString().Trim();
                        BE.perimes = cmb_perimes.SelectedValue.ToString();
                        BE.local = cmb_local.SelectedValue.ToString();

                        if (BL.Delete(EmpresaID, BE))
                        {
                            SEGURIDAD_LOG("E");
                            MessageBox.Show("Datos Eliminado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            NIVEL_FORMS();
                            limpiar_documento();
                            form_bloqueado(false);
                            data_TablaCuotas();
                            CargarDetalle();
                            btn_nuevo.Enabled = true;
                        }
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

            NIVEL_FORMS();

            get_dominio_modulo_local();
            get_tipocambio(DateTime.Today.ToShortDateString());
            _CargarAnio();
            _CargarMes();
            data_TablaCuotas();
            TablaCuotasDet = new DataTable();
            TablaCuotasDet.Columns.Add("local", typeof(String));
            TablaCuotasDet.Columns.Add("localname", typeof(String));
            TablaCuotasDet.Columns.Add("cuota", typeof(Decimal));
            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_salir.Enabled = true;
        }

        private void _CargarAnio()
        {
            var BL = new tb_perianioBL();
            List<tb_perianio> LISTA = null;
            LISTA = BL.Get_anio(EmpresaID);
            cmb_perianio.DataSource = LISTA;
            cmb_perianio.DisplayMember = "perianio";
            cmb_perianio.ValueMember = "codigo";
            cmb_perianio.SelectedIndex = 2;
        }

        private void _CargarMes()
        {
            var BL = new tb_perimesBL();
            List<tb_perimes> LISTA = null;
            LISTA = BL.Get_Mes(EmpresaID);
            cmb_perimes.DataSource = LISTA;
            cmb_perimes.ValueMember = "perimesid";
            cmb_perimes.DisplayMember = "perimesname";
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
                btn_del.Enabled = false;
                ssModo = "OTR";
                if (TablaCuotasDet.Rows.Count > 0)
                {
                    TablaCuotasDet.Rows.Clear();
                    dgb_localcuota.DataSource = TablaCuotasDet;
                }
                else
                {
                    dgb_localcuota.DataSource = TablaCuotasDet;
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

        private void data_TablaCuotas()
        {
            try
            {
                TablaCuotas = new DataTable();

                if (TablaCuotas.Rows.Count > 0)
                {
                    TablaCuotas.Rows.Clear();
                }
                var BL = new tb_me_cuota_tiendaBL();
                var BE = new tb_me_cuota_tienda();

                if (cmb_perianio.SelectedIndex != -1)
                {
                    BE.perianio = cmb_perianio.SelectedValue.ToString();
                }

                TablaCuotas = BL.GetAll2(EmpresaID, BE).Tables[0];
                if (TablaCuotas.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    Mdi_dgv_promociones.DataSource = TablaCuotas;
                }
                else
                {
                    Mdi_dgv_promociones.DataSource = TablaCuotas;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void data_perianio(String xperimesid)
        {
            form_bloqueado(false);
            var rowperimes = TablaCuotas.Select("perimesid='" + xperimesid + "'");
            if (rowperimes.Length > 0)
            {
                foreach (DataRow row in rowperimes)
                {
                    perianio.Text = row["perianio"].ToString().Trim();
                    cmb_perimes.SelectedValue = row["perimesid"].ToString().Trim();
                    cuotatot.Text = row["cuota"].ToString().Trim();
                    cmb_local.SelectedIndex = -1;
                    cuota1.Text = string.Empty;
                    cuota2.Text = string.Empty;
                }

                CargarDetalle();

                btn_nuevo.Enabled = true;
                btn_eliminar.Enabled = true;
                btn_imprimir.Enabled = true;
                btn_log.Enabled = true;
                btn_salir.Enabled = true;
                btn_importar.Enabled = true;
                btn_add.Enabled = true;
                btn_del.Enabled = false;
            }
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
        private void btn_nuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
            {
                nuevo();
                if (TablaCuotasDet != null)
                {
                    TablaCuotasDet.Rows.Clear();
                    dgb_localcuota.DataSource = TablaCuotasDet;
                }
            }
        }

        private void btn_editar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XNIVEL == "0")
            {
                ssModo = "EDIT";
                form_bloqueado(false);
                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
                cuota1.Enabled = true;
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
                data_TablaCuotas();
                CargarDetalle();
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

        private void get_tipocambio(string fecha)
        {
            try
            {
                var BL = new tipocambioBL();
                var dt = new DataTable();

                dt = BL.GetOne(EmpresaID, Convert.ToDateTime(fecha)).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    _xtipocambio = Convert.ToDecimal(dt.Rows[0]["venta"]);
                }
                else
                {
                    _xtipocambio = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Mdi_dgv_tiendalist_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xperianio = dgv_promociones.GetRowCellValue(dgv_promociones.FocusedRowHandle, "perimesid").ToString();
                data_perianio(xperianio);
            }
        }

        private void dgv_tiendalist_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var xperianio = dgv_promociones.GetRowCellValue(e.RowHandle, "perimesid").ToString();
            data_perianio(xperianio);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            form_bloqueado(false);
            Nuevo2(true);
            cmb_local.Enabled = true;
            btn_cancelar.Enabled = true;
            btn_del.Enabled = false;
            btn_add.Enabled = false;
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if ((dgb_localcuota.RowCount != null))
            {
                if (perianio.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Año", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (cmb_perimes.SelectedIndex == -1)
                    {
                        MessageBox.Show("Seleccione El Mes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new tb_me_cuota_tiendaBL();
                        var BE = new tb_me_cuota_tienda();

                        BE.perianio = perianio.Text.ToString().Trim();
                        BE.perimes = cmb_perimes.SelectedValue.ToString();
                        BE.local = cmb_local.SelectedValue.ToString();
                        BE.filtro = 1;

                        if (BL.Delete(EmpresaID, BE))
                        {
                            CargarDetalle();
                            cuota1.Text = string.Empty;
                            cuota2.Text = string.Empty;
                            cmb_local.SelectedIndex = -1;
                            btn_del.Enabled = false;
                        }
                    }
                }
            }
        }

        private void btn_importar_Click(object sender, EventArgs e)
        {
            if (perianio.Text.ToString().Trim().Length > 0)
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
                    if (TablaCuotasDet.Rows.Count > 0)
                    {
                        TablaCuotasDet.Rows.Clear();
                    }
                    while (excelWorksheet.get_Range("A" + x).Value2 != null)
                    {
                        TablaCuotasDet.Rows.Add(
                                            excelWorksheet.get_Range("A" + x).Value2.ToString(),
                                            excelWorksheet.get_Range("B" + x).Value2.ToString(),
                                            excelWorksheet.get_Range("C" + x).Value2.ToString());
                        x++;
                    }

                    var BL = new tb_me_cuota_tiendaBL();
                    var BE = new tb_me_cuota_tienda();

                    var Detalle = new tb_me_cuota_tienda.Item();
                    var ListaItems = new List<tb_me_cuota_tienda.Item>();

                    var item = 0;
                    foreach (DataRow fila in TablaCuotasDet.Rows)
                    {
                        Detalle = new tb_me_cuota_tienda.Item();
                        item++;

                        Detalle.perianio = perianio.Text.ToString().Trim();
                        Detalle.perimes = cmb_perimes.SelectedValue.ToString().Trim();
                        Detalle.local = fila["local"].ToString().Trim();
                        Detalle.cuota = Convert.ToDecimal(fila["cuota"].ToString().Trim());
                        Detalle.usuar = VariablesPublicas.Usuar;

                        ListaItems.Add(Detalle);
                    }
                    if (ListaItems.Count == 0)
                    {
                        MessageBox.Show("Documento SIN DETALLE Y/O DETALLE INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    BE.perianio = perianio.Text.ToString().Trim();
                    BE.perimes = cmb_perimes.SelectedValue.ToString().Trim();
                    BE.ListaItems = ListaItems;

                    if (BL.Insert2(EmpresaID, BE))
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
            if (dgb_localcuota.Rows.Count > 0)
            {
                ExportarExcel();
            }
            else
            {
                MessageBox.Show("No Hay Detalle A Exportar ...!!!");
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
                oSheet.Cells[1, 2] = "Local";
                oSheet.Cells[1, 3] = "Cuota Soles";

                oSheet.get_Range("A1", "C1").Font.Bold = true;
                oSheet.get_Range("A1", "C1").Font.Color = Color.White;
                oSheet.get_Range("A1", "C1").Interior.ColorIndex = 14;
                oSheet.get_Range("A1", "C1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                var IndiceFila = 0;
                oRng = oSheet.get_Range("A2", "C" + TablaCuotasDet.Rows.Count + 1);
                oRng.NumberFormat = "@";


                foreach (DataRow row in TablaCuotasDet.Rows)
                {
                    IndiceFila++;
                    for (var column = 0; column < 3; column++)
                    {
                        oSheet.Cells[IndiceFila + 1, column + 1] = row[column].ToString();
                    }
                }
                oRng = oSheet.get_Range("A1", "C1");
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

        private void btn_save_Click(object sender, EventArgs e)
        {
            var BL = new tb_me_cuota_tiendaBL();
            var BE = new tb_me_cuota_tienda();

            BE.perianio = perianio.Text.ToString().Trim();
            BE.perimes = cmb_perimes.SelectedValue.ToString();
            BE.cuota = Convert.ToDecimal(cuota1.Text.ToString().Trim());
            BE.local = cmb_local.SelectedValue.ToString();
            BE.usuar = VariablesPublicas.Usuar.Trim();
            BE.fecre = Convert.ToDateTime(DateTime.Today.ToShortDateString());
            BE.feact = Convert.ToDateTime(DateTime.Today.ToShortDateString());

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
            var BL = new tb_me_cuota_tiendaBL();
            var BE = new tb_me_cuota_tienda();

            TablaCuotasDet = new DataTable();
            if (perianio.Text.Trim().Length > 0)
            {
                BE.perianio = perianio.Text.Trim();
            }
            if (cmb_perimes.SelectedIndex != -1)
            {
                BE.perimes = cmb_perimes.SelectedValue.ToString().Trim();
            }

            TablaCuotasDet = BL.GetAll(EmpresaID, BE).Tables[0];
            if (TablaCuotasDet.Rows.Count > 0)
            {
                dgb_localcuota.DataSource = TablaCuotasDet;
            }
            else
            {
                dgb_localcuota.DataSource = TablaCuotasDet;
            }
        }

        private void precunit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cuota2.Focus();
            }
        }

        private void dgb_listaPrecios_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgb_localcuota[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            dgb_localcuota[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            dgb_localcuota.EnableHeadersVisualStyles = false;
            dgb_localcuota.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            dgb_localcuota.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void dgb_listaPrecios_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xcodigo = string.Empty;
                xcodigo = dgb_localcuota.Rows[dgb_localcuota.CurrentRow.Index].Cells["glocal"].Value.ToString().Trim();
                Data_PromoDet(xcodigo);
            }
        }

        private void dgb_listaPrecios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgb_localcuota.CurrentRow != null)
            {
                var xpromoid = string.Empty;
                xpromoid = dgb_localcuota.Rows[e.RowIndex].Cells["glocal"].Value.ToString().Trim();
                Data_PromoDet(xpromoid);
            }
        }

        private void Data_PromoDet(String xlocal)
        {
            var rowpromodet = TablaCuotasDet.Select("local='" + xlocal + "'");
            if (rowpromodet.Length > 0)
            {
                foreach (DataRow row in rowpromodet)
                {
                    cmb_local.SelectedValue = row["local"].ToString();
                    cuota1.Text = row["cuota"].ToString();
                    cuota2.Text = Convert.ToString(Math.Round(Convert.ToDecimal(row["cuota2"].ToString()), 4));
                    btn_del.Enabled = true;
                    btn_editar.Enabled = true;
                }
            }
        }

        private void cmb_perianio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_perianio.SelectedIndex != -1)
            {
                data_TablaCuotas();
            }
        }
    }
}
