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

namespace BapFormulariosNet.D70Produccion.Costos
{
    public partial class Frm_hojacosto : plantilla
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
        private DataTable TablaCostoRubro;
        private DataRow row;
        private Boolean procesado = false;
        private String ssModo = string.Empty;

        public Frm_hojacosto()
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
                articidold.Enabled = var;
                articname.Enabled = false;
                version.Enabled = false;
                cantidad.Enabled = var;
                cmb_rubro.Enabled = var;
                cboModuloID.Enabled = false;
                tejidoid.Enabled = false;
                familiaid.Enabled = var;
                familianame.Enabled = false;
                consumo.Enabled = var;
                unmed.Enabled = false;
                precunit.Enabled = false;
                importe.Enabled = false;

                costoprimo.Enabled = false;
                gastoadm.Enabled = false;
                gastovta.Enabled = false;
                gastofin.Enabled = false;
                gastopera.Enabled = false;

                percgadm.Enabled = false;
                percgvta.Enabled = false;
                percgfin.Enabled = false;

                costototal.Enabled = false;


                btn_nuevo.Enabled = false;
                btn_editar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_grabar.Enabled = false;
                btn_eliminar.Enabled = false;
                btn_imprimir.Enabled = false;
                btn_save.Enabled = false;
                btn_del.Enabled = false;
                btn_new.Enabled = false;
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
                BE.detalle = articidold.Text.Trim() + "/" + articname.Text.Trim().ToUpper() + "/" + XGLOSA;

                BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void limpiar_documento()
        {
            try
            {
                articid.Text = string.Empty;
                articidold.Text = string.Empty;
                articname.Text = string.Empty;
                version.Text = string.Empty;
                cantidad.Text = string.Empty;
                cmb_rubro.SelectedIndex = -1;
                cboModuloID.SelectedIndex = -1;
                tejidoid.SelectedIndex = -1;
                familiaid.Text = string.Empty;
                familianame.Text = string.Empty;
                consumo.Text = string.Empty;
                unmed.Text = string.Empty;
                precunit.Text = string.Empty;
                importe.Text = string.Empty;

                costoprimo.Text = string.Empty;
                costototal.Text = string.Empty;
                gastopera.Text = string.Empty;

                percgadm.Text = string.Empty;
                percgvta.Text = string.Empty;
                percgfin.Text = string.Empty;

                if (TablaprecioslistDet != null)
                {
                    TablaprecioslistDet.Rows.Clear();
                    dgb_dethojacosto.DataSource = TablaprecioslistDet;
                }
                if (TablaCostoRubro != null)
                {
                    TablaCostoRubro.Rows.Clear();
                    dgb_hojacostorubro.DataSource = TablaCostoRubro;
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
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_log.Enabled = true;
            btn_save.Enabled = false;
            btn_add.Enabled = true;
            ssModo = "NEW";
        }

        private void Nuevo2(Boolean var)
        {
            articidold.Text = string.Empty;
            articname.Text = string.Empty;
            btn_save.Enabled = var;
            articidold.Enabled = var;
            btn_cancelar.Enabled = true;
            articidold.Focus();
            ssModo = "NEW";
        }

        private void Insert()
        {
            try
            {
                var BL = new tb_pp_hojacostoBL();
                var BE = new tb_pp_hojacosto();

                BE.articid = articid.Text.ToString();
                BE.version = version.Text.ToString();
                BE.fecha = Convert.ToDateTime(DateTime.Today.ToShortDateString());
                BE.cantidad = Convert.ToInt32(cantidad.Text.ToString());
                BE.costoprimo = Convert.ToDecimal(costoprimo.Text.ToString());
                BE.percgadm = Convert.ToDecimal(percgadm.Text.ToString());
                BE.percgvta = Convert.ToDecimal(percgvta.Text.ToString());
                BE.percgfin = Convert.ToDecimal(percgfin.Text.ToString());
                BE.gastoadm = Convert.ToDecimal(gastoadm.Text.ToString());
                BE.gastovta = Convert.ToDecimal(gastovta.Text.ToString());
                BE.gastofin = Convert.ToDecimal(gastofin.Text.ToString());
                BE.gastopera = Convert.ToDecimal(gastopera.Text.ToString());
                BE.costototal = Convert.ToDecimal(costototal.Text.ToString());
                BE.perianio = Convert.ToString(DateTime.Today.Year);
                BE.usuar = VariablesPublicas.Usuar.Trim();

                var Detalle = new tb_pp_hojacosto.Item();
                var ListaItems = new List<tb_pp_hojacosto.Item>();

                var item = 0;
                foreach (DataRow fila in TablaprecioslistDet.Rows)
                {
                    Detalle = new tb_pp_hojacosto.Item();
                    item++;

                    Detalle.articid = fila["articid"].ToString();
                    Detalle.version = fila["version"].ToString();
                    Detalle.rubroid = fila["rubroid"].ToString();
                    Detalle.moduloid = fila["moduloid"].ToString();
                    Detalle.lineaid = fila["lineaid"].ToString().Trim();
                    Detalle.familiaid = fila["familiaid"].ToString();
                    Detalle.valor = Convert.ToDecimal(fila["valor"].ToString());
                    Detalle.consumo = Convert.ToDecimal(fila["consumo"].ToString().Trim());
                    Detalle.unmed = fila["unmed"].ToString().Trim();
                    Detalle.importe = Convert.ToDecimal(fila["importe"].ToString().Trim());
                    Detalle.status = fila["status"].ToString().Trim();
                    Detalle.usuar = fila["usuar"].ToString().Trim();
                    ListaItems.Add(Detalle);
                }

                if (ListaItems.Count == 0)
                {
                    MessageBox.Show("Documento SIN DETALLE Y/O DETALLE INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                BE.ListaItems = ListaItems;

                var Atributos = new tb_pp_hojacosto.Item();
                var ListaItems2 = new List<tb_pp_hojacosto.Item>();
                var item2 = 0;
                foreach (DataRow fila in TablaCostoRubro.Rows)
                {
                    Atributos = new tb_pp_hojacosto.Item();
                    item2++;

                    Atributos.articid = fila["articid"].ToString();
                    Atributos.version = fila["version"].ToString();
                    Atributos.rubroid = fila["rubroid"].ToString();
                    Atributos.moduloid = fila["moduloid"].ToString();
                    Atributos.importe = Convert.ToDecimal(fila["importe"].ToString().Trim());
                    Atributos.usuar = fila["usuar"].ToString().Trim();

                    ListaItems2.Add(Atributos);
                }

                if (ListaItems2.Count == 0)
                {
                    MessageBox.Show("Documento SIN DETALLE Y/O DETALLE INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                BE.ListaItems2 = ListaItems2;

                if (BL.Insert(EmpresaID, BE))
                {
                    MessageBox.Show("Datos Grabados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    procesado = true;
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
                var BL = new tb_pp_hojacostoBL();
                var BE = new tb_pp_hojacosto();

                BE.articid = articid.Text.ToString();
                BE.version = version.Text.ToString();
                BE.fecha = Convert.ToDateTime(DateTime.Today.ToShortDateString());
                BE.cantidad = Convert.ToInt32(cantidad.Text.ToString());
                BE.costoprimo = Convert.ToDecimal(costoprimo.Text.ToString());
                BE.percgadm = Convert.ToDecimal(percgadm.Text.ToString());
                BE.percgvta = Convert.ToDecimal(percgvta.Text.ToString());
                BE.percgfin = Convert.ToDecimal(percgfin.Text.ToString());
                BE.gastoadm = Convert.ToDecimal(gastoadm.Text.ToString());
                BE.gastovta = Convert.ToDecimal(gastovta.Text.ToString());
                BE.gastofin = Convert.ToDecimal(gastofin.Text.ToString());
                BE.gastopera = Convert.ToDecimal(gastopera.Text.ToString());
                BE.costototal = Convert.ToDecimal(costototal.Text.ToString());
                BE.perianio = Convert.ToString(DateTime.Today.Year);
                BE.usuar = VariablesPublicas.Usuar.Trim();

                var Detalle = new tb_pp_hojacosto.Item();
                var ListaItems = new List<tb_pp_hojacosto.Item>();

                var item = 0;
                foreach (DataRow fila in TablaprecioslistDet.Rows)
                {
                    Detalle = new tb_pp_hojacosto.Item();
                    item++;

                    Detalle.articid = fila["articid"].ToString();
                    Detalle.version = fila["version"].ToString();
                    Detalle.rubroid = fila["rubroid"].ToString();
                    Detalle.moduloid = fila["moduloid"].ToString();
                    Detalle.lineaid = fila["lineaid"].ToString().Trim();
                    Detalle.familiaid = fila["familiaid"].ToString();
                    Detalle.valor = Convert.ToDecimal(fila["valor"].ToString());
                    Detalle.consumo = Convert.ToDecimal(fila["consumo"].ToString().Trim());
                    Detalle.unmed = fila["unmed"].ToString().Trim();
                    Detalle.importe = Convert.ToDecimal(fila["importe"].ToString().Trim());
                    Detalle.status = fila["status"].ToString().Trim();
                    Detalle.usuar = fila["usuar"].ToString().Trim();

                    ListaItems.Add(Detalle);
                }

                if (ListaItems.Count == 0)
                {
                    MessageBox.Show("Documento SIN DETALLE Y/O DETALLE INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                BE.ListaItems = ListaItems;

                var Atributos = new tb_pp_hojacosto.Item();
                var ListaItems2 = new List<tb_pp_hojacosto.Item>();
                var item2 = 0;
                foreach (DataRow fila in TablaCostoRubro.Rows)
                {
                    Atributos = new tb_pp_hojacosto.Item();
                    item2++;

                    Atributos.articid = fila["articid"].ToString();
                    Atributos.version = fila["version"].ToString();
                    Atributos.rubroid = fila["rubroid"].ToString();
                    Atributos.moduloid = fila["moduloid"].ToString();
                    Atributos.importe = Convert.ToDecimal(fila["importe"].ToString().Trim());
                    Atributos.usuar = fila["usuar"].ToString().Trim();

                    ListaItems2.Add(Atributos);
                }

                if (ListaItems2.Count == 0)
                {
                    MessageBox.Show("Documento SIN DETALLE Y/O DETALLE INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                BE.ListaItems2 = ListaItems2;

                if (BL.Update(EmpresaID, BE))
                {
                    SEGURIDAD_LOG("M");
                    MessageBox.Show("Datos Modificado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    procesado = true;
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
                var BL = new tb_pp_hojacostocabBL();
                var BE = new tb_pp_hojacostocab();

                BE.articid = articid.Text.Trim();
                BE.version = version.Text.Trim();

                if (BL.Delete(EmpresaID, BE))
                {
                    SEGURIDAD_LOG("E");
                    MessageBox.Show("Datos Eliminado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NIVEL_FORMS();
                    limpiar_documento();
                    form_bloqueado(false);
                    btn_nuevo.Enabled = true;
                    btn_busqueda.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_articulo_tiendalist_Load(object sender, EventArgs e)
        {
            modulo = ((D70Produccion.MainProduccion)MdiParent).moduloid;
            local = ((D70Produccion.MainProduccion)MdiParent).local;
            PERFILID = ((D70Produccion.MainProduccion)MdiParent).perfil;

            NIVEL_FORMS();
            get_cbo_modulo();
            get_cbo_rubro();

            TablaprecioslistDet = new DataTable();
            TablaprecioslistDet.Columns.Add("articid", typeof(String));
            TablaprecioslistDet.Columns.Add("version", typeof(String));

            TablaprecioslistDet.Columns.Add("rubroid", typeof(String));
            TablaprecioslistDet.Columns.Add("rubroname", typeof(String));
            TablaprecioslistDet.Columns.Add("moduloid", typeof(String));
            TablaprecioslistDet.Columns.Add("lineaid", typeof(String));
            TablaprecioslistDet.Columns.Add("familiaid", typeof(String));
            TablaprecioslistDet.Columns.Add("familianame", typeof(String));
            TablaprecioslistDet.Columns.Add("valor", typeof(Decimal));
            TablaprecioslistDet.Columns.Add("consumo", typeof(Decimal));
            TablaprecioslistDet.Columns.Add("unmed", typeof(String));
            TablaprecioslistDet.Columns.Add("importe", typeof(Decimal));
            TablaprecioslistDet.Columns.Add("status", typeof(String));
            TablaprecioslistDet.Columns.Add("usuar", typeof(String));

            TablaCostoRubro = new DataTable();
            TablaCostoRubro.Columns.Add("articid", typeof(String));
            TablaCostoRubro.Columns.Add("version", typeof(String));

            TablaCostoRubro.Columns.Add("rubroid", typeof(String));
            TablaCostoRubro.PrimaryKey = new DataColumn[] { TablaCostoRubro.Columns["rubroid"] };
            TablaCostoRubro.Columns["rubroid"].Unique = true;

            TablaCostoRubro.Columns.Add("rubroname", typeof(String));
            TablaCostoRubro.Columns.Add("moduloid", typeof(String));
            TablaCostoRubro.Columns.Add("importe", typeof(Decimal));
            TablaCostoRubro.Columns.Add("usuar", typeof(String));
            limpiar_documento();
            form_bloqueado(false);
            Data_cbo_tejidoid();
            CargarConstantes();
            btn_nuevo.Enabled = true;
            btn_salir.Enabled = true;


            TablaprecioslistDet.PrimaryKey = new DataColumn[] {
                TablaprecioslistDet.Columns["rubroid"],
                TablaprecioslistDet.Columns["moduloid"],
                TablaprecioslistDet.Columns["lineaid"],
                TablaprecioslistDet.Columns["familiaid"]
            };
        }

        private void CargarConstantes()
        {
            var BE = new tb_pp_constantes();
            var BL = new tb_pp_constantesBL();
            var dt = new DataTable();
            BE.perianio = DateTime.Today.Year.ToString();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                gastoadm.Text = Math.Round(Convert.ToDecimal(dt.Rows[0]["percgadm"]), 2).ToString();
                gastovta.Text = Math.Round(Convert.ToDecimal(dt.Rows[0]["percgvta"]), 2).ToString();
                gastofin.Text = Math.Round(Convert.ToDecimal(dt.Rows[0]["percgfin"]), 2).ToString();
            }
            else
            {
                gastoadm.Text = "0.00";
                gastovta.Text = "0.00";
                gastofin.Text = "0.00";
            }
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
                btn_save.Enabled = false;
                btn_new.Enabled = false;
                ssModo = "OTR";
                if (TablaprecioslistDet.Rows.Count > 0)
                {
                    TablaprecioslistDet.Rows.Clear();
                    dgb_dethojacosto.DataSource = TablaprecioslistDet;
                }
                else
                {
                    dgb_dethojacosto.DataSource = TablaprecioslistDet;
                }

                if (TablaCostoRubro.Rows.Count > 0)
                {
                    TablaCostoRubro.Rows.Clear();
                    dgb_hojacostorubro.DataSource = TablaCostoRubro;
                }
                else
                {
                    dgb_hojacostorubro.DataSource = TablaCostoRubro;
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
                    Mdi_dgv_listahojacosto.DataSource = Tablaprecioslist;
                }
                else
                {
                    Mdi_dgv_listahojacosto.DataSource = Tablaprecioslist;
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

        private void get_cbo_modulo()
        {
            var BL = new sys_dominioBL();
            try
            {
                cboModuloID.DataSource = BL.GetAllDominioModuloPorUsuario(VariablesPublicas.EmpresaID, VariablesPublicas.Usuar, dominio.ToString()).Tables[0];
                cboModuloID.ValueMember = "moduloid";
                cboModuloID.DisplayMember = "moduloname";
                cboModuloID.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Data_cbo_tejidoid()
        {
            var BL = new tb_60lineaBL();
            var BE = new tb_60linea();
            var dt = new DataTable();
            if (cboModuloID.SelectedIndex != -1)
            {
                BE.moduloid = cboModuloID.SelectedValue.ToString();
                try
                {
                    dt = BL.GetAll(EmpresaID, BE).Tables[0];
                    tejidoid.DataSource = dt;
                    tejidoid.ValueMember = "lineaid";
                    tejidoid.DisplayMember = "lineaname";
                    tejidoid.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void get_cbo_rubro()
        {
            var BL = new tb_pp_rubrocostoBL();
            var BE = new tb_pp_rubrocosto();
            var dt = new DataTable();
            try
            {
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                cmb_rubro.DataSource = dt;
                cmb_rubro.ValueMember = "rubroid";
                cmb_rubro.DisplayMember = "rubroname";
                cmb_rubro.SelectedIndex = -1;
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
                BE.moduloid = cboModuloID.SelectedValue.ToString();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();

                        var frmayuda = new Ayudas.Frm_help_general();
                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA TABLA FAMILIA >>";
                        frmayuda.sqlquery = " SELECT Distinct te.lineaid,te.familiaid,(li.lineaname+'-'+te.familianame)familia,fd.unmed " +
                                            " FROM tb_" + modd + "_familia te ";
                        frmayuda.sqlinner = " INNER JOIN tb_" + modd + "_familiadet fd ON te.familiaid = fd.familiaid " +
                                            " AND te.lineaid = fd.lineaid " +
                                            " LEFT JOIN tb_" + modd + "_linea li ON te.lineaid = li.lineaid ";
                        frmayuda.sqlwhere = " Where";
                        frmayuda.criteriosbusqueda = new string[] { "FAMILIA", "CODIGO" };
                        frmayuda.columbusqueda = "te.familianame,te.familiaid";
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



        private void RecibeFamilia(String xlineaid, String xfamiliatelaid, String xfamiliatelaname, String xunmed, String resultado5)
        {
            try
            {
                if (xlineaid.Trim().Length == 3)
                {
                    familiaid.Text = xfamiliatelaid;
                    familianame.Text = xfamiliatelaname;
                    tejidoid.SelectedValue = xlineaid;
                    unmed.Text = xunmed;

                    var BL = new tb_pt_familiadetBL();
                    var BE = new tb_pt_familiadet();
                    var dt = new DataTable();
                    BE.moduloid = cboModuloID.SelectedValue.ToString();
                    BE.familiaid = xfamiliatelaid.ToString();
                    dt = BL.GetAll2(EmpresaID, BE).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        precunit.Text = dt.Rows[0]["precio"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Data_ListaHojaCosto(String xversion, String xarticidold)
        {
            form_bloqueado(false);
            var rowlistaHojacosto = Tablaprecioslist.Select("version='" + xversion + "' and articidold = '" + xarticidold + "' ");
            if (rowlistaHojacosto.Length > 0)
            {
                foreach (DataRow row in rowlistaHojacosto)
                {
                    articid.Text = row["articid"].ToString();
                    articidold.Text = row["articidold"].ToString();
                    articname.Text = row["articname"].ToString();
                    version.Text = row["version"].ToString();
                    cantidad.Text = row["cantidad"].ToString();

                    costoprimo.Text = Math.Round(Convert.ToDecimal(row["costoprimo"].ToString()), 2).ToString();
                    percgadm.Text = Math.Round(Convert.ToDecimal(row["percgadm"].ToString()), 2).ToString();
                    percgfin.Text = Math.Round(Convert.ToDecimal(row["percgfin"].ToString()), 2).ToString();
                    percgvta.Text = Math.Round(Convert.ToDecimal(row["percgvta"].ToString()), 2).ToString();
                    gastoadm.Text = Math.Round(Convert.ToDecimal(row["gastoadm"].ToString()), 2).ToString();
                    gastofin.Text = Math.Round(Convert.ToDecimal(row["gastofin"].ToString()), 2).ToString();
                    gastovta.Text = Math.Round(Convert.ToDecimal(row["gastovta"].ToString()), 2).ToString();
                    gastopera.Text = Math.Round(Convert.ToDecimal(row["gastopera"].ToString()), 2).ToString();
                    costototal.Text = Math.Round(Convert.ToDecimal(row["costototal"].ToString()), 2).ToString();

                    CargarDetalle();
                    CargarDetalle2();
                }

                btn_nuevo.Enabled = true;
                btn_editar.Enabled = true;
                btn_eliminar.Enabled = true;
                btn_imprimir.Enabled = true;
                btn_log.Enabled = true;
                btn_salir.Enabled = true;
                btn_add.Enabled = true;
                btn_del.Enabled = false;
                btn_add.Enabled = false;
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
                articid.Text = xarticid.Trim();
                articidold.Text = xarticidold.Trim();
                articname.Text = xarticname.Trim();
                var BL = new tb_pp_hojacostocabBL();
                var BE = new tb_pp_hojacostocab();
                var dt = new DataTable();

                BE.articid = articid.Text.ToString();
                BE.version = string.Empty;
                dt = BL.GetAll_Version(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    version.Text = dt.Rows[0]["codigo"].ToString();
                }
                else
                {
                    version.Text = string.Empty;
                }
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
                articid.Text = dt.Rows[0]["articid"].ToString();
                articidold.Text = dt.Rows[0]["articidold"].ToString();
                articname.Text = dt.Rows[0]["articname"].ToString();
            }
            else
            {
                articid.Text = string.Empty;
                articidold.Text = string.Empty;
                articname.Text = string.Empty;
            }
        }


        private void articid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaArticulo(string.Empty);
                cantidad.Focus();
            }

            if (e.KeyCode == Keys.Enter)
            {
                var xcodart = string.Empty;
                xcodart = articidold.Text.Trim();
                ValidaArticulo(xcodart);
                cantidad.Focus();
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
                    dgb_dethojacosto.DataSource = TablaprecioslistDet;
                }

                if (TablaCostoRubro != null)
                {
                    TablaCostoRubro.Rows.Clear();
                    dgb_hojacostorubro.DataSource = TablaCostoRubro;
                }
                articidold.Focus();
            }
        }

        private void btn_editar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XNIVEL == "0")
            {
                ssModo = "EDIT";
                form_bloqueado(true);
                articidold.Enabled = false;
                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
                btn_add.Enabled = false;
                btn_new.Enabled = true;
                btn_del.Enabled = false;
                cmb_rubro.Enabled = false;
                familiaid.Enabled = false;
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
                var xversion = dgv_listahojacosto.GetRowCellValue(dgv_listahojacosto.FocusedRowHandle, "version").ToString();
                var xarticidold = dgv_listahojacosto.GetRowCellValue(dgv_listahojacosto.FocusedRowHandle, "articidold").ToString();
                Data_ListaHojaCosto(xversion, xarticidold);
            }
        }

        private void dgv_tiendalist_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var xversion = dgv_listahojacosto.GetRowCellValue(e.RowHandle, "version").ToString();
            var xarticidold = dgv_listahojacosto.GetRowCellValue(e.RowHandle, "articidold").ToString();
            Data_ListaHojaCosto(xversion, xarticidold);
        }


        private void btn_add_Click(object sender, EventArgs e)
        {
            if (articname.Text.Length == 0)
            {
                MessageBox.Show("Falta Agregar un Articulo ..!!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (version.Text.Length == 0)
                {
                    MessageBox.Show("Version no es Correcta ..!!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (cmb_rubro.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe de Tener un Rubro Verifique ..!!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        if (cboModuloID.SelectedIndex == -1)
                        {
                            MessageBox.Show("No Existe Modulo Verifique  ..!!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            if (tejidoid.SelectedIndex == -1)
                            {
                                MessageBox.Show("No Existe una Linea Especifica Verifique ..!!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
                            {
                                if (familianame.Text.Length == 0)
                                {
                                    MessageBox.Show("Falta Agregar una Familia ..!!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                else
                                {
                                    if (consumo.Text.Length == 0 && unmed.Text.Length == 0 && precunit.Text.Length == 0 && importe.Text.Length == 0)
                                    {
                                        MessageBox.Show("Algunos Datos Estan Vacios Verificar ..!!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    else
                                    {
                                        try
                                        {
                                            row = TablaprecioslistDet.NewRow();
                                            row["articid"] = articid.Text.ToString();
                                            row["version"] = version.Text.ToString();
                                            row["rubroid"] = cmb_rubro.SelectedValue.ToString();
                                            row["rubroname"] = cmb_rubro.Text.ToString();
                                            row["moduloid"] = cboModuloID.SelectedValue.ToString();
                                            row["lineaid"] = tejidoid.SelectedValue.ToString();
                                            row["familiaid"] = familiaid.Text.ToString();
                                            row["familianame"] = familianame.Text.ToString();
                                            row["valor"] = precunit.Text.ToString();
                                            row["consumo"] = consumo.Text.ToString();
                                            row["unmed"] = unmed.Text.ToString();
                                            row["importe"] = importe.Text.ToString();
                                            row["status"] = "0";
                                            row["usuar"] = VariablesPublicas.Usuar.ToString();
                                            TablaprecioslistDet.Rows.Add(row);
                                            dgb_dethojacosto.DataSource = TablaprecioslistDet;
                                        }
                                        catch (Exception ex)
                                        {
                                            throw ex;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            CargarFilasdeHojadeRubro();
            btn_add.Enabled = false;
            btn_new.Enabled = true;
        }


        private void CargarFilasdeHojadeRubro()
        {
            if (TablaCostoRubro.Rows.Count > 0)
            {
                TablaCostoRubro.Rows.Clear();
                dgb_hojacostorubro.DataSource = TablaCostoRubro;
            }

            var BL = new tb_pp_rubrocostoBL();
            var BE = new tb_pp_rubrocosto();
            var dt = new DataTable();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];

            var xxrubroname = string.Empty;
            foreach (DataRow fila in dt.Rows)
            {
                var xxrubroid = fila["rubroid"].ToString();
                var xxmoduloid = fila["moduloid"].ToString();
                Decimal AcumImporte = 0;
                var result = TablaprecioslistDet.Select("rubroid = '" + xxrubroid.ToString() + "' AND moduloid = '" + xxmoduloid.ToString() + "' ");

                foreach (DataRow list in result)
                {
                    AcumImporte = AcumImporte + Convert.ToDecimal(list["importe"]);
                    xxrubroname = list["rubroname"].ToString();
                }

                if (AcumImporte > 0)
                {
                    row = TablaCostoRubro.NewRow();
                    row["articid"] = articid.Text.ToString();
                    row["version"] = version.Text.ToString();
                    row["rubroid"] = fila["rubroid"].ToString();
                    row["rubroname"] = xxrubroname.ToString();
                    row["moduloid"] = cboModuloID.SelectedValue.ToString();
                    row["importe"] = AcumImporte.ToString();
                    row["usuar"] = VariablesPublicas.Usuar.ToString();
                    TablaCostoRubro.Rows.Add(row);
                }
            }

            dgb_hojacostorubro.DataSource = TablaCostoRubro;
            _CalculoGastosCostos();
        }


        private void _CalculoGastosCostos()
        {
            if (TablaCostoRubro.Rows.Count > 0)
            {
                costoprimo.Text = Convert.ToDecimal(TablaCostoRubro.Compute("sum(importe)", string.Empty)).ToString("##,###,##0.00");
            }
            else
            {
                costoprimo.Text = "0.00";
            }
            percgadm.Text = Convert.ToString(Math.Round(((Convert.ToDecimal(gastoadm.Text) / 100) * Convert.ToDecimal(costoprimo.Text)), 2));
            percgvta.Text = Convert.ToString(Math.Round(((Convert.ToDecimal(gastovta.Text) / 100) * Convert.ToDecimal(costoprimo.Text)), 2));
            percgfin.Text = Convert.ToString(Math.Round(((Convert.ToDecimal(gastofin.Text) / 100) * Convert.ToDecimal(costoprimo.Text)), 2));

            gastopera.Text = Convert.ToString(Math.Round((Convert.ToDecimal(percgadm.Text) + Convert.ToDecimal(percgvta.Text) + Convert.ToDecimal(percgfin.Text)), 2));

            costototal.Text = Convert.ToString(Math.Round((Convert.ToDecimal(gastopera.Text) + Convert.ToDecimal(costoprimo.Text)), 2));
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
            var lc_cont = 0;
            var xrubroid = string.Empty;
            var xmoduloid = string.Empty;
            var xlineaid = string.Empty;
            var xfamiliaid = string.Empty;
            if ((dgb_dethojacosto.CurrentRow != null))
            {
                xrubroid = dgb_dethojacosto.Rows[dgb_dethojacosto.CurrentCell.RowIndex].Cells["d_rubroid"].Value.ToString();
                xmoduloid = dgb_dethojacosto.Rows[dgb_dethojacosto.CurrentCell.RowIndex].Cells["d_moduloid"].Value.ToString();
                xlineaid = dgb_dethojacosto.Rows[dgb_dethojacosto.CurrentCell.RowIndex].Cells["d_lineaid"].Value.ToString();
                xfamiliaid = dgb_dethojacosto.Rows[dgb_dethojacosto.CurrentCell.RowIndex].Cells["d_familiaid"].Value.ToString();

                for (lc_cont = 0; lc_cont <= TablaprecioslistDet.Rows.Count - 1; lc_cont++)
                {
                    if (TablaprecioslistDet.Rows[lc_cont]["rubroid"].ToString() == xrubroid &&
                        TablaprecioslistDet.Rows[lc_cont]["moduloid"].ToString() == xmoduloid &&
                        TablaprecioslistDet.Rows[lc_cont]["lineaid"].ToString() == xlineaid &&
                        TablaprecioslistDet.Rows[lc_cont]["familiaid"].ToString() == xfamiliaid)
                    {
                        TablaprecioslistDet.Rows[lc_cont].Delete();
                        TablaprecioslistDet.AcceptChanges();
                        break;
                    }
                }
            }

            CargarFilasdeHojadeRubro();
        }

        private void btn_importar_Click(object sender, EventArgs e)
        {
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
            if (dgb_dethojacosto.Rows.Count > 0)
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
        private void btn_save_Click(object sender, EventArgs e)
        {
            var lc_cont = 0;
            var xrubroid = string.Empty;
            var xmoduloid = string.Empty;
            var xlineaid = string.Empty;
            var xfamiliaid = string.Empty;
            if ((dgb_dethojacosto.CurrentRow != null))
            {
                xrubroid = dgb_dethojacosto.Rows[dgb_dethojacosto.CurrentCell.RowIndex].Cells["d_rubroid"].Value.ToString();
                xmoduloid = dgb_dethojacosto.Rows[dgb_dethojacosto.CurrentCell.RowIndex].Cells["d_moduloid"].Value.ToString();
                xlineaid = dgb_dethojacosto.Rows[dgb_dethojacosto.CurrentCell.RowIndex].Cells["d_lineaid"].Value.ToString();
                xfamiliaid = dgb_dethojacosto.Rows[dgb_dethojacosto.CurrentCell.RowIndex].Cells["d_familiaid"].Value.ToString();

                for (lc_cont = 0; lc_cont <= TablaprecioslistDet.Rows.Count - 1; lc_cont++)
                {
                    if (TablaprecioslistDet.Rows[lc_cont]["rubroid"].ToString() == xrubroid &&
                        TablaprecioslistDet.Rows[lc_cont]["moduloid"].ToString() == xmoduloid &&
                        TablaprecioslistDet.Rows[lc_cont]["lineaid"].ToString() == xlineaid &&
                        TablaprecioslistDet.Rows[lc_cont]["familiaid"].ToString() == xfamiliaid)
                    {
                        TablaprecioslistDet.Rows[lc_cont].Delete();
                        TablaprecioslistDet.AcceptChanges();
                        break;
                    }
                }
            }

            row = TablaprecioslistDet.NewRow();
            row["articid"] = articid.Text.ToString();
            row["version"] = version.Text.ToString();
            row["rubroid"] = cmb_rubro.SelectedValue.ToString();
            row["rubroname"] = cmb_rubro.Text.ToString();
            row["moduloid"] = cboModuloID.SelectedValue.ToString();
            row["lineaid"] = tejidoid.SelectedValue.ToString();
            row["familiaid"] = familiaid.Text.ToString();
            row["familianame"] = familianame.Text.ToString();
            row["valor"] = precunit.Text.ToString();
            row["consumo"] = consumo.Text.ToString();
            row["unmed"] = unmed.Text.ToString();
            row["importe"] = importe.Text.ToString();
            row["status"] = "0";
            row["usuar"] = VariablesPublicas.Usuar.ToString();
            TablaprecioslistDet.Rows.Add(row);
            dgb_dethojacosto.DataSource = TablaprecioslistDet;

            CargarFilasdeHojadeRubro();
        }

        private void CargarDetalle()
        {
            var BL = new tb_pp_hojacostodetBL();
            var BE = new tb_pp_hojacostodet();
            TablaprecioslistDet = new DataTable();
            BE.articid = articid.Text.Trim();
            BE.version = version.Text.Trim();
            TablaprecioslistDet = BL.GetAll(EmpresaID, BE).Tables[0];
            if (TablaprecioslistDet.Rows.Count > 0)
            {
                dgb_dethojacosto.DataSource = TablaprecioslistDet;
            }
            else
            {
                dgb_dethojacosto.DataSource = TablaprecioslistDet;
            }
        }

        private void CargarDetalle2()
        {
            var BL = new tb_pp_hojacostorubroBL();
            var BE = new tb_pp_hojacostorubro();
            TablaCostoRubro = new DataTable();
            BE.articid = articid.Text.Trim();
            BE.version = version.Text.Trim();
            TablaCostoRubro = BL.GetAll(EmpresaID, BE).Tables[0];
            if (TablaCostoRubro.Rows.Count > 0)
            {
                dgb_hojacostorubro.DataSource = TablaCostoRubro;
            }
            else
            {
                dgb_hojacostorubro.DataSource = TablaCostoRubro;
            }
        }



        private void precunit1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void dgb_listaPrecios_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgb_dethojacosto[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            dgb_dethojacosto[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            dgb_dethojacosto.EnableHeadersVisualStyles = false;
            dgb_dethojacosto.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            dgb_dethojacosto.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void dgb_listaPrecios_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xcodigo = string.Empty;
                xcodigo = dgb_dethojacosto.Rows[dgb_dethojacosto.CurrentRow.Index].Cells["d_familiaid"].Value.ToString().Trim();
                Data_hojacosto(xcodigo);
            }
        }

        private void dgb_listaPrecios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgb_dethojacosto.CurrentRow != null)
            {
                var xcodigo = string.Empty;
                xcodigo = dgb_dethojacosto.Rows[e.RowIndex].Cells["d_familiaid"].Value.ToString().Trim();
                Data_hojacosto(xcodigo);
            }
        }

        private void Data_hojacosto(String xcodigo)
        {
            var rowhojacosto = TablaprecioslistDet.Select("familiaid='" + xcodigo + "'");
            if (rowhojacosto.Length > 0)
            {
                foreach (DataRow row in rowhojacosto)
                {
                    articid.Text = row["articid"].ToString().Trim();
                    version.Text = row["version"].ToString().Trim();
                    cmb_rubro.SelectedValue = row["rubroid"].ToString().Trim();
                    familiaid.Text = row["familiaid"].ToString().Trim();
                    familianame.Text = row["familianame"].ToString().Trim();
                    cboModuloID.SelectedValue = row["moduloid"].ToString().Trim();
                    tejidoid.SelectedValue = row["lineaid"].ToString().Trim();
                    precunit.Text = row["valor"].ToString().Trim();
                    consumo.Text = row["consumo"].ToString().Trim();
                    unmed.Text = row["unmed"].ToString().Trim();
                    importe.Text = row["importe"].ToString().Trim();
                    btn_add.Enabled = false;
                    if (btn_editar.Enabled == false)
                    {
                        btn_save.Enabled = true;
                        btn_del.Enabled = true;
                    }
                }
            }
        }

        private void familiaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaFamilia(string.Empty);
                _calculaImporte();
                consumo.Focus();
            }
        }

        private void cmb_rubro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_rubro.SelectedIndex >= 0)
            {
                var BL = new tb_pp_rubrocostoBL();
                var BE = new tb_pp_rubrocosto();
                var dt = new DataTable();
                BE.rubroid = cmb_rubro.SelectedValue.ToString();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    cboModuloID.SelectedValue = dt.Rows[0]["moduloid"].ToString();
                }
                familiaid.Focus();
            }
        }

        private void cboModuloID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModuloID.SelectedIndex > 0)
            {
                Data_cbo_tejidoid();
            }
        }

        private void consumo_TextChanged(object sender, EventArgs e)
        {
            _calculaImporte();
        }

        private void _calculaImporte()
        {
            if (consumo.Text.Length > 0)
            {
                importe.Text = Convert.ToString(Convert.ToDecimal(consumo.Text) * Convert.ToDecimal(precunit.Text));
            }
            else
            {
                importe.Text = string.Empty;
            }
        }

        private void cantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboModuloID.Focus();
            }
        }

        private void dgb_hojacostorubro_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgb_hojacostorubro[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            dgb_hojacostorubro[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            dgb_hojacostorubro.EnableHeadersVisualStyles = false;
            dgb_hojacostorubro.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            dgb_hojacostorubro.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            var BE = new tb_pp_hojacostocab();
            var BL = new tb_pp_hojacostocabBL();

            BE.articidold = txt_criterio.Text.ToString().Trim();
            Tablaprecioslist = BL.GetAll(EmpresaID, BE).Tables[0];
            if (Tablaprecioslist.Rows.Count > 0)
            {
                Mdi_dgv_listahojacosto.DataSource = Tablaprecioslist;
            }
            else
            {
                Mdi_dgv_listahojacosto.DataSource = Tablaprecioslist;
            }
        }

        private void txt_criterio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_busqueda.PerformClick();
            }
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            TablaprecioslistDet.PrimaryKey = new DataColumn[] {
                TablaprecioslistDet.Columns["rubroid"],
                TablaprecioslistDet.Columns["moduloid"],
                TablaprecioslistDet.Columns["lineaid"],
                TablaprecioslistDet.Columns["familiaid"]
            };
            cmb_rubro.SelectedIndex = -1;
            cboModuloID.SelectedIndex = -1;
            tejidoid.SelectedIndex = -1;
            familiaid.Text = string.Empty;
            familianame.Text = string.Empty;
            consumo.Text = string.Empty;
            unmed.Text = string.Empty;
            precunit.Text = string.Empty;
            importe.Text = string.Empty;
            cmb_rubro.Enabled = true;
            familiaid.Enabled = true;
            consumo.Enabled = true;
            btn_save.Enabled = false;
            btn_del.Enabled = false;
            btn_add.Enabled = true;
        }
    }
}
