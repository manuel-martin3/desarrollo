using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.Generales
{
    public partial class Frm_condpago : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;

        private DataTable Tablacondpago;
        private Boolean procesado = false;

        private String ssModo = string.Empty;

        public Frm_condpago()
        {
            InitializeComponent();
        }

        private void NIVEL_FORMS()
        {
            switch (this.Parent.Parent.Name)
            {
                case "MainMercaderia":
                    XNIVEL = VariablesPublicas.Get_nivelperfil(((MERCADERIA.MainMercaderia)MdiParent).perfil, Name).Substring(0, 1);
                    break;
                case "MainAlmacen":
                    XNIVEL = VariablesPublicas.Get_nivelperfil(((D60ALMACEN.MainAlmacen)MdiParent).perfil, Name).Substring(0, 1);
                    break;
                case "MainLogistica":
                    XNIVEL = VariablesPublicas.Get_nivelperfil(((DL0Logistica.MainLogistica)MdiParent).perfil, Name).Substring(0, 1);
                    break;
                default:
                    break;
            }

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
                condpagoid.Enabled = !var;
                condpagoname.Enabled = var;

                gridcondpago.ReadOnly = true;
                gridcondpago.Enabled = !var;

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
                condpagoid.Text = string.Empty;
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
                var BL = new tb_condpagoBL();
                var BE = new tb_condpago();
                var dt = new DataTable();

                BE.condpagoid = condpagoid.Text.Trim();
                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    ssModo = "EDIT";
                    limpiar_documento();
                    condpagoid.Text = dt.Rows[0]["condpagoid"].ToString().Trim();
                    condpagoname.Text = dt.Rows[0]["condpagoname"].ToString().Trim();

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

        private void Ayudacondpago(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all";
                frmayuda.titulo = "<< AYUDA  TABLA condpago >>";
                frmayuda.sqlquery = "SELECT condpagoid, condpagoname FROM tb_condpago";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where";
                frmayuda.sqland = string.Empty;
                frmayuda.criteriosbusqueda = new string[] { "condpago", "CODIGO" };
                frmayuda.columbusqueda = "condpagoname,condpagoid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = Recibecondpago;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
        private void Recibecondpago(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                condpagoid.Text = resultado1.Trim();
                form_cargar_datos(string.Empty);
            }
        }

        private void SEGURIDAD_LOG(String accion)
        {
            var xclave = VariablesPublicas.EmpresaID + "/" + ((D60ALMACEN.MainAlmacen)MdiParent).perianio;
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
                BE.detalle = condpagoid.Text.Trim() + "/" + condpagoname.Text.Trim().ToUpper() + "/" + XGLOSA;

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
                condpagoid.Text = string.Empty;
                condpagoname.Text = string.Empty;
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
            form_bloqueado(true);
            condpagoid.Text = "NEW";
            condpagoname.Focus();

            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
        }
        private void Insert()
        {
            try
            {
                if (condpagoid.Text.Trim().Length != 3)
                {
                    MessageBox.Show("Ingrese Código de condpago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (condpagoname.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese nombre de condpago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new tb_condpagoBL();
                        var BE = new tb_condpago();

                        BE.condpagoid = condpagoid.Text.Trim();
                        BE.condpagoname = condpagoname.Text.Trim().ToUpper();

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
                if (condpagoid.Text.Trim().Length != 3)
                {
                    MessageBox.Show("Ingrese Código de condpago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (condpagoname.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese nombre de condpago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new tb_condpagoBL();
                        var BE = new tb_condpago();

                        BE.condpagoid = condpagoid.Text.Trim();
                        BE.condpagoname = condpagoname.Text.Trim().ToUpper();

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
                if (condpagoid.Text.Trim().Length != 3)
                {
                    MessageBox.Show("Ingrese Código de condpago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_condpagoBL();
                    var BE = new tb_condpago();

                    BE.condpagoid = condpagoid.Text.Trim();

                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos Eliminado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        limpiar_documento();
                        form_bloqueado(false);
                        data_Tablacondpago();
                        btn_nuevo.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_condpago_Activated(object sender, EventArgs e)
        {
        }

        private void Frm_condpago_Load(object sender, EventArgs e)
        {
            switch (this.Parent.Parent.Name)
            {
                case "MainMercaderia":
                    modulo = ((MERCADERIA.MainMercaderia)MdiParent).moduloid;
                    local = ((MERCADERIA.MainMercaderia)MdiParent).local;
                    break;
                case "MainAlmacen":
                    modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
                    local = ((D60ALMACEN.MainAlmacen)MdiParent).local;
                    break;
                case "MainLogistica":
                    modulo = ((DL0Logistica.MainLogistica)MdiParent).moduloid;
                    local = ((DL0Logistica.MainLogistica)MdiParent).local;
                    break;
                default:
                    break;
            }

            NIVEL_FORMS();

            Tablacondpago = new DataTable();
            data_Tablacondpago();
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
        private void Frm_condpago_KeyDown(object sender, KeyEventArgs e)
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

        private void condpagoid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Ayudacondpago(string.Empty);
            }
        }
        private void condpagoid_KeyUp(object sender, KeyEventArgs e)
        {
            if (condpagoid.Text.Trim().Length == 2)
            {
                form_cargar_datos(string.Empty);
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
                if (condpagoid.Text.Trim().Length == 3)
                {
                    ssModo = "EDIT";

                    form_bloqueado(true);
                    condpagoname.Focus();

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
                data_Tablacondpago();
                form_bloqueado(false);
                condpagoid.Text = string.Empty;

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
                if (Tablacondpago.Rows.Count > 0)
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
            var xclave = VariablesPublicas.EmpresaID + "/" + ((D60ALMACEN.MainAlmacen)MdiParent).perianio;
            oform._Nombre = Name;
            oform._ClaveForm = xclave;
            oform.Owner = this;
            oform.ShowDialog();
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void data_Tablacondpago()
        {
            try
            {
                if (Tablacondpago != null)
                {
                    Tablacondpago.Rows.Clear();
                }
                var BL = new tb_condpagoBL();
                var BE = new tb_condpago();

                Tablacondpago = BL.GetAll(EmpresaID, BE).Tables[0];
                if (Tablacondpago.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    gridcondpago.DataSource = Tablacondpago;
                    gridcondpago.Rows[0].Selected = false;
                    gridcondpago.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridcondpago_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridcondpago.CurrentRow != null)
                {
                    var xcondpagoid = string.Empty;
                    xcondpagoid = gridcondpago.Rows[e.RowIndex].Cells["gcondpagoid"].Value.ToString().Trim();
                    data_tipodoc(xcondpagoid);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void gridcondpago_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xcondpagoid = string.Empty;
                xcondpagoid = gridcondpago.Rows[gridcondpago.CurrentRow.Index].Cells["gcondpagoid"].Value.ToString().Trim();
                data_tipodoc(xcondpagoid);
            }
        }

        private void gridcondpago_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridcondpago[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            gridcondpago[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            gridcondpago.EnableHeadersVisualStyles = false;
            gridcondpago.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            gridcondpago.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void gridcondpago_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            gridcondpago[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }

        private void data_tipodoc(String xcondpagoid)
        {
            form_bloqueado(false);
            var rowtipodoc = Tablacondpago.Select("condpagoid='" + xcondpagoid.Trim() + "'");
            if (rowtipodoc.Length > 0)
            {
                foreach (DataRow row in rowtipodoc)
                {
                    ssModo = "EDIT";
                    limpiar_documento();
                    condpagoid.Text = row["condpagoid"].ToString().Trim();
                    condpagoname.Text = row["condpagoname"].ToString().Trim();
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
