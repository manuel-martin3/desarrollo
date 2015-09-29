using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.MERCADERIA02.CATALOGO
{
    public partial class Frm_genero : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable Tablagenero;
        private Boolean procesado = false;

        private String ssModo = "NEW";

        public Frm_genero()
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
                generoid.Enabled = false;
                generoname.Enabled = var;
                generodescort.Enabled = var;

                gridgenero.ReadOnly = true;
                gridgenero.Enabled = !var;
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

                ssModo = "NEW";
            }
        }
        private void form_cargar_datos(String posicion)
        {
            try
            {
                var BL = new tb_pt_generoBL();
                var BE = new tb_pt_genero();
                var dt = new DataTable();
                if (generoid.Text.Trim().Length > 0)
                {
                    BE.generoid = generoid.Text.Trim().PadLeft(1, '0');
                }
                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    limpiar_documento();
                    ssModo = "EDIT";

                    generoid.Text = dt.Rows[0]["generoid"].ToString().Trim();
                    generoname.Text = dt.Rows[0]["generoname"].ToString().Trim();
                    generodescort.Text = dt.Rows[0]["generodescort"].ToString().Trim();

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
                BE.detalle = generoid.Text.Trim() + "/" + generoname.Text.Trim().ToUpper()  + "/" + XGLOSA;

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
                generoid.Text = string.Empty;
                generoname.Text = string.Empty;
                generodescort.Text = string.Empty;
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
            generoname.Focus();

            ssModo = "NEW";
        }
        private void Insert()
        {
            try
            {
                if (generoname.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese nombre de Genero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_pt_generoBL();
                    var BE = new tb_pt_genero();

                    BE.generoid = generoid.Text.Trim().PadLeft(1, '0');
                    BE.generoname = generoname.Text.ToUpper().ToUpper();
                    BE.generodescort = generodescort.Text.ToUpper();
                    BE.usuar = VariablesPublicas.Usuar.Trim();

                    if (BL.Insert(EmpresaID, BE))
                    {
                        MessageBox.Show("Datos Grabados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (generoid.Text.Trim().Length != 1)
                {
                    MessageBox.Show("Falta Codigo Genero !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (generoname.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese Nombre de Genero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new tb_pt_generoBL();
                        var BE = new tb_pt_genero();

                        BE.generoid = generoid.Text.Trim().PadLeft(1, '0');
                        BE.generoname = generoname.Text.ToUpper();
                        BE.generodescort = generodescort.Text.ToUpper();
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
                if (generoid.Text.Trim().Length != 1)
                {
                    MessageBox.Show("Falta Codigo Genero !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_pt_generoBL();
                    var BE = new tb_pt_genero();
                    BE.generoid = generoid.Text.Trim().PadLeft(1, '0');

                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos eliminados correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        form_bloqueado(false);
                        data_Tablagenero();
                        btn_nuevo.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_genero_Load(object sender, EventArgs e)
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
            Tablagenero = new DataTable();

            generoname.CharacterCasing = CharacterCasing.Upper;
            data_Tablagenero();
            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_primero.Enabled = true;
            btn_anterior.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_ultimo.Enabled = true;
            btn_salir.Enabled = true;
        }

        private void Frm_genero_KeyDown(object sender, KeyEventArgs e)
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

        private void generoid_LostFocus(object sender, System.EventArgs e)
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
                generoname.Focus();

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
                data_Tablagenero();
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
                if (Tablagenero.Rows.Count > 0)
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

        private void data_Tablagenero()
        {
            try
            {
                if (Tablagenero.Rows.Count > 0)
                {
                    Tablagenero.Rows.Clear();
                }
                var BL = new tb_pt_generoBL();
                var BE = new tb_pt_genero();

                BE.generoname = txt_criterio.Text.Trim().ToUpper();

                Tablagenero = BL.GetAll(EmpresaID, BE).Tables[0];
                if (Tablagenero.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    gridgenero.DataSource = Tablagenero;
                    gridgenero.Rows[0].Selected = false;
                    gridgenero.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridgenero_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridgenero.CurrentRow != null)
                {
                    var xgeneroid = string.Empty;
                    xgeneroid = gridgenero.Rows[e.RowIndex].Cells["ggeneroid"].Value.ToString().Trim();
                    data_genero(xgeneroid);
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void gridgenero_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xgeneroid = string.Empty;
                xgeneroid = gridgenero.Rows[gridgenero.CurrentRow.Index].Cells["ggeneroid"].Value.ToString().Trim();
                data_genero(xgeneroid);
            }
        }

        private void gridgenero_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridgenero[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            gridgenero[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            gridgenero.EnableHeadersVisualStyles = false;
            gridgenero.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            gridgenero.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void gridgenero_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            gridgenero[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }

        private void data_genero(String xgeneroid)
        {
            form_bloqueado(false);
            var rowgeneroid = Tablagenero.Select("generoid='" + xgeneroid + "'");
            if (rowgeneroid.Length > 0)
            {
                foreach (DataRow row in rowgeneroid)
                {
                    generoid.Text = row["generoid"].ToString().Trim();
                    generoname.Text = row["generoname"].ToString().Trim();
                    generodescort.Text = row["generodescort"].ToString().Trim();
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
        }

        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            data_Tablagenero();
        }

        private void txt_criterio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_busqueda_Click(sender, e);
            }
        }
    }
}
