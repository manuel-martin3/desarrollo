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

namespace BapFormulariosNet.MERCADERIA02.CATALOGO
{
    public partial class Frm_linea : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable Tablalinea;
        private Boolean procesado = false;

        private String ssModo = "NEW";

        public Frm_linea()
        {
            InitializeComponent();
            lineaid.LostFocus += new System.EventHandler(lineaid_LostFocus);
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
                lineaid.Enabled = false;
                lineaname.Enabled = var;
                lineadescort.Enabled = var;
                lineaidold.Enabled = false;

                gridlinea.ReadOnly = true;
                gridlinea.Enabled = !var;
                txt_criterio.Enabled = !var;
                btn_busqueda.Enabled = !var;

                btn_nuevo.Enabled = false;
                btn_editar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_grabar.Enabled = false;
                btn_eliminar.Enabled = false;
                btn_excel.Enabled = false;

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
                lineaid.Text = "NN";
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
                var BL = new tb_pt_lineaBL();
                var BE = new tb_pt_linea();
                var dt = new DataTable();
                if (lineaid.Text.Trim().Length > 0)
                {
                    BE.lineaid = lineaid.Text.Trim().PadLeft(2, '0');
                }
                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    limpiar_documento();
                    ssModo = "EDIT";

                    lineaid.Text = dt.Rows[0]["lineaid"].ToString().Trim();
                    lineaname.Text = dt.Rows[0]["lineaname"].ToString().Trim();
                    lineaidold.Text = dt.Rows[0]["lineaidold"].ToString().Trim();
                    lineadescort.Text = dt.Rows[0]["lineadescort"].ToString().Trim();

                    btn_editar.Enabled = true;
                    btn_eliminar.Enabled = true;
                    btn_excel.Enabled = true;

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
                BE.detalle = lineaid.Text.Trim() + "/" + lineaname.Text.Trim().ToUpper()  + "/" + XGLOSA;

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
                lineaname.Text = string.Empty;
                lineaidold.Text = string.Empty;
                lineadescort.Text = string.Empty;
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
            lineaid.Text = "NN";
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_log.Enabled = true;
            lineaname.Focus();
            GetAll_CODdbf();
            ssModo = "NEW";
        }

        private void GetAll_CODdbf()
        {
            var BL = new tb_pt_lineaBL();
            var BE = new tb_pt_linea();
            var dt = new DataTable();
            dt = BL.GetAll_CODdbf(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                var num = Convert.ToInt32(dt.Rows[0]["lineaidold"].ToString());
                lineaidold.Text = (num + 1).ToString().PadLeft(3, '0');
            }
            else
            {
                lineaidold.Text = string.Empty;
            }
        }


        private void Insert()
        {
            try
            {
                if (lineaid.Text.Trim().Length != 2)
                {
                    MessageBox.Show("Falta Codigo linea !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (lineaname.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese nombre de línea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new tb_pt_lineaBL();
                        var BE = new tb_pt_linea();

                        BE.lineaid = lineaid.Text.Trim().PadLeft(2, '0');
                        BE.lineaname = lineaname.Text.ToUpper().ToUpper();
                        BE.lineaidold = lineaidold.Text.ToUpper();
                        BE.lineadescort = lineadescort.Text.ToUpper();
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

        private void Insert_dbf()
        {
            try
            {
                if (lineaidold.Text.Trim().Length != 3)
                {
                    MessageBox.Show("Falta Codigo Linea !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (lineaname.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese Nombre de Línea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new tb_pt_lineaBL();
                        var BE = new tb_pt_linea();
                        BE.lineaname = lineaname.Text.ToUpper().ToUpper();
                        BE.lineaidold = lineaidold.Text.ToUpper();
                        BE.usuar = VariablesPublicas.Usuar.Trim();

                        if (BL.Insert_dbf(EmpresaID, BE))
                        {
                            MessageBox.Show("Datos Dbf Grabados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (lineaid.Text.Trim().Length != 2)
                {
                    MessageBox.Show("Falta Codigo Linea !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (lineaname.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese Nombre de Línea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new tb_pt_lineaBL();
                        var BE = new tb_pt_linea();

                        BE.lineaid = lineaid.Text.Trim().PadLeft(2, '0');
                        BE.lineaname = lineaname.Text.ToUpper();
                        BE.lineaidold = lineaidold.Text;
                        BE.lineadescort = lineadescort.Text.ToUpper();
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

        private void Update_dbf()
        {
            try
            {
                if (lineaidold.Text.Trim().Length != 3)
                {
                    MessageBox.Show("Falta Codigo_DBF Linea !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (lineaname.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese Nombre de Línea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new tb_pt_lineaBL();
                        var BE = new tb_pt_linea();

                        BE.lineaname = lineaname.Text.ToUpper().ToUpper().Trim();
                        BE.lineaidold = lineaidold.Text.ToUpper().Trim();
                        BE.usuar = VariablesPublicas.Usuar.Trim();

                        if (BL.Update_dbf(EmpresaID, BE))
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
                if (lineaid.Text.Trim().Length != 2)
                {
                    MessageBox.Show("Falta Codigo linea !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_pt_lineaBL();
                    var BE = new tb_pt_linea();
                    BE.lineaid = lineaid.Text.Trim().PadLeft(2, '0');

                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos eliminados correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        form_bloqueado(false);
                        data_Tablalinea();
                        btn_nuevo.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Delete_dbf()
        {
            try
            {
                if (lineaidold.Text.Trim().Length != 3)
                {
                    MessageBox.Show("Falta Codigo_DBF Linea !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_pt_lineaBL();
                    var BE = new tb_pt_linea();

                    BE.lineaname = lineaname.Text.ToUpper().ToUpper();
                    BE.lineaidold = lineaidold.Text.ToUpper();
                    BE.usuar = VariablesPublicas.Usuar.Trim();

                    if (BL.Delete_dbf(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Dato Anulado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        form_bloqueado(false);
                        data_Tablalinea();
                        btn_nuevo.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_linea_Load(object sender, EventArgs e)
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
            Tablalinea = new DataTable();

            lineaname.CharacterCasing = CharacterCasing.Upper;
            data_Tablalinea();
            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_primero.Enabled = true;
            btn_anterior.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_ultimo.Enabled = true;
            btn_salir.Enabled = true;
        }

        private void Frm_linea_KeyDown(object sender, KeyEventArgs e)
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

        private void lineaid_LostFocus(object sender, System.EventArgs e)
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
                lineaname.Focus();

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
                Insert_dbf();
            }
            else
            {
                if (XNIVEL == "0" || XNIVEL == "1")
                {
                    sw_prosigue = (MessageBox.Show("¿Desea Modificar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                    if (sw_prosigue)
                    {
                        Update();
                        Update_dbf();
                    }
                }
            }
            if (procesado)
            {
                NIVEL_FORMS();
                data_Tablalinea();
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
                    Delete_dbf();
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

        private void data_Tablalinea()
        {
            try
            {
                if (Tablalinea.Rows.Count > 0)
                {
                    Tablalinea.Rows.Clear();
                }
                var BL = new tb_pt_lineaBL();
                var BE = new tb_pt_linea();

                BE.lineaname = txt_criterio.Text.Trim().ToUpper();

                Tablalinea = BL.GetAll(EmpresaID, BE).Tables[0];
                if (Tablalinea.Rows.Count > 0)
                {
                    btn_excel.Enabled = true;
                    gridlinea.DataSource = Tablalinea;
                    gridlinea.Rows[0].Selected = false;
                    gridlinea.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridlinea_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridlinea.CurrentRow != null)
                {
                    var xlineaid = string.Empty;
                    xlineaid = gridlinea.Rows[e.RowIndex].Cells["glineaid"].Value.ToString().Trim();
                    data_linea(xlineaid);
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void gridlinea_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xlineaid = string.Empty;
                xlineaid = gridlinea.Rows[gridlinea.CurrentRow.Index].Cells["glineaid"].Value.ToString().Trim();
                data_linea(xlineaid);
            }
        }

        private void gridlinea_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridlinea[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            gridlinea[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            gridlinea.EnableHeadersVisualStyles = false;
            gridlinea.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            gridlinea.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void gridlinea_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            gridlinea[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }

        private void data_linea(String xlineaid)
        {
            form_bloqueado(false);
            var rowlineaid = Tablalinea.Select("lineaid='" + xlineaid + "'");
            if (rowlineaid.Length > 0)
            {
                foreach (DataRow row in rowlineaid)
                {
                    lineaid.Text = row["lineaid"].ToString().Trim();
                    lineaname.Text = row["lineaname"].ToString().Trim();
                    lineaidold.Text = row["lineaidold"].ToString().Trim();
                    lineadescort.Text = row["lineadescort"].ToString().Trim();
                    btn_nuevo.Enabled = true;
                    btn_editar.Enabled = true;
                    btn_eliminar.Enabled = true;
                    btn_excel.Enabled = true;

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
            data_Tablalinea();
        }

        private void txt_criterio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_busqueda_Click(sender, e);
            }
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            if (Tablalinea.Rows.Count > 0)
            {
                ExportarExcel(Tablalinea);
            }
            else
            {
                MessageBox.Show(" ... Falta Obtener las Lineas ... ", "Information");
            }
        }

        private void ExportarExcel(DataTable TablapromoDet)
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


                oSheet.Cells[1, 1] = "CODIDO";
                oSheet.Cells[1, 2] = "LINEA";
                oSheet.Cells[1, 3] = "DESC-CORTA";
                oSheet.Cells[1, 4] = "COD_OLD";

                oSheet.get_Range("A1", "D1").Font.Bold = true;
                oSheet.get_Range("A1", "D1").Font.Color = Color.White;
                oSheet.get_Range("A1", "D1").Interior.ColorIndex = 14;
                oSheet.get_Range("A1", "D1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                var IndiceFila = 2;
                oSheet.Range["A:D"].NumberFormat = "@";

                foreach (DataRow row in TablapromoDet.Rows)
                {
                    oSheet.Cells[IndiceFila, 01].Value = row["lineaid"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 02].Value = row["lineaname"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 03].Value = row["lineadescort"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 04].Value = row["lineaidold"].ToString().Trim();

                    IndiceFila++;
                }

                oRng = oSheet.get_Range("A1", "D1");
                oRng.EntireColumn.AutoFit();

                oSheet.Cells[2, 1].Select();
                oXL.ActiveWindow.FreezePanes = true;

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
    }
}
