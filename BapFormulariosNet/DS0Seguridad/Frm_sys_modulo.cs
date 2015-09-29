using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.DS0Seguridad
{
    public partial class Frm_sys_modulo : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable Tablamodulo;
        private Boolean procesado = false;

        private String ssModo = string.Empty;

        public Frm_sys_modulo()
        {
            InitializeComponent();
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
                dominioid.Enabled = !var;
                dominioname.Enabled = false;
                moduloid.Enabled = !var;
                moduloname.Enabled = var;
                moduloshort.Enabled = var;

                gridmodulo.ReadOnly = true;
                gridmodulo.Enabled = !var;

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
                moduloid.Text = string.Empty;
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
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();

                BE.dominioid = dominioid.Text.Trim();
                BE.moduloid = moduloid.Text.Trim();
                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    ssModo = "EDIT";
                    limpiar_documento();
                    dominioid.Text = dt.Rows[0]["dominioid"].ToString().Trim();
                    dominioname.Text = dt.Rows[0]["dominioname"].ToString().Trim();
                    moduloid.Text = dt.Rows[0]["moduloid"].ToString().Trim();
                    moduloname.Text = dt.Rows[0]["moduloname"].ToString().Trim();
                    moduloshort.Text = dt.Rows[0]["moduloshort"].ToString().Trim();

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
                else
                {
                    limpiar_documento();
                    btn_editar.Enabled = false;
                    btn_eliminar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ValidaDominio()
        {
            if (dominioid.Text.Trim().Length > 0)
            {
                var BL = new sys_dominioBL();
                var BE = new tb_sys_dominio();
                var dt = new DataTable();

                BE.dominioid = dominioid.Text.Trim().PadLeft(2, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    dominioid.Text = dt.Rows[0]["dominioid"].ToString().Trim();
                    dominioname.Text = dt.Rows[0]["dominioname"].ToString().Trim();
                    data_Tablamodulo();
                }
                else
                {
                    dominioid.Text = string.Empty;
                    dominioname.Text = string.Empty;
                }
            }
            else
            {
                dominioid.Text = string.Empty;
                dominioname.Text = string.Empty;
            }
        }
        private void Validamodulo_nuevo()
        {
            if (dominioid.Text.Trim().Length == 2)
            {
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();
                BE.dominioid = dominioid.Text.Trim();
                BE.moduloid = moduloid.Text.Trim();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count == 0)
                {
                    mensaje.Text = "VALIDO";
                    mensaje.ForeColor = Color.Green;
                    form_bloqueado(true);
                    moduloname.Focus();

                    btn_cancelar.Enabled = true;
                    btn_grabar.Enabled = true;
                }
                else
                {
                    mensaje.Text = "YA EXISTE";
                    mensaje.ForeColor = Color.Red;
                    moduloid.Focus();
                }
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

        private void AyudaDominio(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all";
                frmayuda.titulo = "<< AYUDA  TABLA DOMINIO >>";
                frmayuda.sqlquery = "SELECT dominioid, dominioname FROM tb_sys_dominio";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where";
                frmayuda.sqland = string.Empty;
                frmayuda.criteriosbusqueda = new string[] { "DOMINIO", "CODIGO" };
                frmayuda.columbusqueda = "dominioname,dominioid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeDominio;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
        private void RecibeDominio(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                dominioid.Text = resultado1.Trim();
                dominioname.Text = resultado2.Trim();
                data_Tablamodulo();
            }
        }

        private void Ayudamodulo(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all";
                frmayuda.titulo = "<< AYUDA  TABLA modulo >>";
                frmayuda.sqlquery = "SELECT moduloid, moduloname, moduloshort FROM tb_sys_modulo";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where";
                frmayuda.sqland = string.Empty;
                frmayuda.criteriosbusqueda = new string[] { "modulo", "CODIGO" };
                frmayuda.columbusqueda = "moduloname,moduloid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = Recibemodulo;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
        private void Recibemodulo(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                moduloid.Text = resultado1.Trim();
                form_cargar_datos(string.Empty);
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
                BE.detalle = dominioid.Text.Trim() + moduloid.Text.Trim() + "/" + moduloname.Text.Trim().ToUpper() + "/" + XGLOSA;

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
                dominioid.Text = string.Empty;
                dominioname.Text = string.Empty;
                moduloid.Text = string.Empty;
                moduloname.Text = string.Empty;
                moduloshort.Text = string.Empty;
                mensaje.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void nuevo()
        {
            ssModo = "NEW";

            limpiar_documento();
            form_bloqueado(false);
            dominioid.Focus();

            btn_cancelar.Enabled = true;
        }
        private void Insert()
        {
            try
            {
                if (dominioid.Text.Trim().Length != 2)
                {
                    MessageBox.Show("Ingrese Código de Dominio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (moduloid.Text.Trim().Length != 4)
                {
                    MessageBox.Show("Ingrese Código de modulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (moduloname.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese nombre de modulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new sys_moduloBL();
                        var BE = new tb_sys_modulo();

                        BE.dominioid = dominioid.Text.Trim();
                        BE.moduloid = moduloid.Text.Trim();
                        BE.moduloname = moduloname.Text.Trim();
                        BE.moduloshort = moduloshort.Text.Trim();

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
                if (dominioid.Text.Trim().Length != 2)
                {
                    MessageBox.Show("Ingrese Código de Dominio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (moduloid.Text.Trim().Length != 4)
                {
                    MessageBox.Show("Ingrese Código de modulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (moduloname.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese nombre de modulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new sys_moduloBL();
                        var BE = new tb_sys_modulo();

                        BE.dominioid = dominioid.Text.Trim();
                        BE.moduloid = moduloid.Text.Trim();
                        BE.moduloname = moduloname.Text.Trim();
                        BE.moduloshort = moduloshort.Text.Trim();

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
                if (dominioid.Text.Trim().Length != 2)
                {
                    MessageBox.Show("Ingrese Código de Dominio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (moduloid.Text.Trim().Length != 4)
                {
                    MessageBox.Show("Ingrese Código de modulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new sys_moduloBL();
                    var BE = new tb_sys_modulo();

                    BE.dominioid = dominioid.Text.Trim();
                    BE.moduloid = moduloid.Text.Trim();

                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos Eliminado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        data_Tablamodulo();
                        limpiar_documento();
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

        private void Frm_sys_modulo_Activated(object sender, EventArgs e)
        {
        }
        private void Frm_sys_modulo_Load(object sender, EventArgs e)
        {
            modulo = ((DS0Seguridad.MainSeguridad)MdiParent).moduloid;
            local = ((DS0Seguridad.MainSeguridad)MdiParent).moduloid;
            PERFILID = ((DS0Seguridad.MainSeguridad)MdiParent).perfil;

            NIVEL_FORMS();

            Tablamodulo = new DataTable();
            data_Tablamodulo();

            limpiar_documento();
            form_bloqueado(false);

            btn_nuevo.Enabled = true;
            btn_primero.Enabled = true;
            btn_anterior.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_ultimo.Enabled = true;
            btn_buscar.Enabled = true;
            btn_salir.Enabled = true;
        }
        private void Frm_sys_modulo_KeyDown(object sender, KeyEventArgs e)
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

        private void dominioid_KeyUp(object sender, KeyEventArgs e)
        {
            if (dominioid.Text.Trim().Length == 2)
            {
                ValidaDominio();
            }

            if (e.KeyCode == Keys.F1)
            {
                AyudaDominio(string.Empty);
            }
        }
        private void moduloid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Ayudamodulo(string.Empty);
            }
        }
        private void moduloid_KeyUp(object sender, KeyEventArgs e)
        {
            if (moduloid.Text.Trim().Length == 4)
            {
                if (ssModo == "NEW")
                {
                    Validamodulo_nuevo();
                }
                else
                {
                    form_cargar_datos(string.Empty);
                }
            }
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
            if (XNIVEL == "0" || XNIVEL == "1")
            {
                if (moduloid.Text.Trim().Length == 4)
                {
                    ssModo = "EDIT";

                    form_bloqueado(true);
                    moduloname.Focus();

                    btn_cancelar.Enabled = true;
                    btn_grabar.Enabled = true;
                }
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
                data_Tablamodulo();
                form_bloqueado(false);

                btn_nuevo.Enabled = true;
                btn_eliminar.Enabled = true;

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
                if (Tablamodulo.Rows.Count > 0)
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

        private void data_Tablamodulo()
        {
            try
            {
                if (Tablamodulo != null)
                {
                    Tablamodulo.Rows.Clear();
                    var BL = new sys_moduloBL();
                    var BE = new tb_sys_modulo();
                    BE.dominioid = dominioid.Text.Trim();
                    Tablamodulo = BL.GetAll(EmpresaID, BE).Tables[0];
                }
                if (Tablamodulo.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    gridmodulo.DataSource = Tablamodulo;
                    gridmodulo.Rows[0].Selected = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridmodulo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridmodulo.CurrentRow != null)
                {
                    var xdominioid = string.Empty;
                    var xmoduloid = string.Empty;
                    xdominioid = gridmodulo.Rows[e.RowIndex].Cells["gdominioid"].Value.ToString().Trim();
                    xmoduloid = gridmodulo.Rows[e.RowIndex].Cells["gmoduloid"].Value.ToString().Trim();
                    data_tipodoc(xdominioid, xmoduloid);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void gridmodulo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xdominioid = string.Empty;
                var xmoduloid = string.Empty;
                xdominioid = gridmodulo.Rows[gridmodulo.CurrentRow.Index].Cells["gdominioid"].Value.ToString().Trim();
                xmoduloid = gridmodulo.Rows[gridmodulo.CurrentRow.Index].Cells["gmoduloid"].Value.ToString().Trim();
                data_tipodoc(xdominioid, xmoduloid);
            }
        }

        private void gridmodulo_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridmodulo[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            gridmodulo[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            gridmodulo.EnableHeadersVisualStyles = false;
            gridmodulo.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            gridmodulo.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void gridmodulo_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            gridmodulo[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }
        private void data_tipodoc(String xdominioid, String xmoduloid)
        {
            form_bloqueado(false);
            var rowtipodoc = Tablamodulo.Select("dominioid = '" + xdominioid.Trim() + "' and moduloid='" + xmoduloid.Trim() + "'");
            if (rowtipodoc.Length > 0)
            {
                foreach (DataRow row in rowtipodoc)
                {
                    ssModo = "EDIT";
                    limpiar_documento();

                    dominioid.Text = row["dominioid"].ToString().Trim();
                    dominioname.Text = row["dominioname"].ToString().Trim();
                    moduloid.Text = row["moduloid"].ToString().Trim();
                    moduloname.Text = row["moduloname"].ToString().Trim();
                    moduloshort.Text = row["moduloshort"].ToString().Trim();
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
    }
}
