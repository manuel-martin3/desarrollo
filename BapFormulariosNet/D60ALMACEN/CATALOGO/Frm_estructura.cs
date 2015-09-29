using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using System.Net.Mail;
using System.Net;

using System.IO;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.Net.Sockets;

namespace BapFormulariosNet.D60ALMACEN.CATALOGO
{
    public partial class Frm_estructura : plantilla
    {
        /*** variables de cabecera del documento actual ***/
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = "";
        private String local = "";  

        String perianio = "";
        String perimes = "";
        String XNIVEL = "";
        String XGLOSA = "";

        DataTable Tablaestructura;

        Boolean fechadocedit = false;
        Boolean procesado = false;
        Boolean statusDoc = true;

        String ssModo = "NEW";

        public Frm_estructura()
        {
            InitializeComponent();
            estructuraid.LostFocus += new System.EventHandler(estructuraid_LostFocus);
        }

        #region *** Metodos generales
        private void get_tipocambio(String fecha)
        {
            try
            {
                //genera tipo de cambio dependiendo la fech del documento
                tipocambioBL BL = new tipocambioBL();
                tb_tipocambio BE = new tb_tipocambio();
                DataTable dt = new DataTable();

                dt = BL.GetOne(EmpresaID, Convert.ToDateTime(fecha)).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    tcamb.Text = Convert.ToDecimal(dt.Rows[0]["venta"]).ToString("###,##0.0000");
                }
                else
                {
                    tcamb.Text = "1";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void form_bloqueado(Boolean var)
        {
            try
            {

                estructuraid.Enabled = !var;
                estructuraname.Enabled = var;


                tcamb.Enabled = false;
                fechadoc.Enabled = false;

                gridestructura.ReadOnly = true;
                gridestructura.Enabled = !var;
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
            bool sw_prosigue = true;
            if (confirnar == 1)
            {
                sw_prosigue = (MessageBox.Show("Desea cancelar operación...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
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
                estructuraid.Text = "";
                btn_nuevo.Enabled = true;

                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;

                btn_buscar.Enabled = true;
                btn_salir.Enabled = true;

                ssModo = "NEW";
            }
        }
        private void form_cargar_datos(String posicion)
        {
            try
            {
                tb_ta_estructuraBL BL = new tb_ta_estructuraBL();
                tb_ta_estructura BE = new tb_ta_estructura();
                DataTable dt = new DataTable();

                if (estructuraid.Text.Trim().Length > 0)
                {
                    BE.estructuraid = estructuraid.Text.Trim().PadLeft(1, '0');
                }
                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    limpiar_documento();
                    ssModo = "EDIT";

                    estructuraid.Text = dt.Rows[0]["estructuraid"].ToString().Trim();
                    estructuraname.Text = dt.Rows[0]["estructuraname"].ToString().Trim();

                    btn_editar.Enabled = true;
                    btn_eliminar.Enabled = true;
                    btn_imprimir.Enabled = true;

                    btn_primero.Enabled = true;
                    btn_anterior.Enabled = true;
                    btn_siguiente.Enabled = true;
                    btn_ultimo.Enabled = true;

                    btn_buscar.Enabled = true;
                    btn_salir.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region $$$ Llenado de Combobox
        #endregion
        #endregion

        #region *** Eventos
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
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData /*KeyEventArgs keyData*/)
        {
            if (keyData == Keys.Enter)
            {
                if (GetNextControl(ActiveControl, true) != null)
                {
                    //keyData.Handled = true;
                    //MessageBox.Show(ActiveControl.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //GetNextControl(ActiveControl, true).Focus();
                    //SendKeys.Send("{TAB}");
                    SendKeys.Send("\t");
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region *** Metodos que retornan datos
        public bool IsNumeric(String Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        #endregion

        #region *** Grid Ayuda general forms
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

        #endregion

        #region *** Metodos mantenimiento de datos
        private void SEGURIDAD_LOG(String accion)
        {
            String xclave = VariablesPublicas.EmpresaID + "/" + ((D60ALMACEN.MainAlmacen)MdiParent).perianio;
            try
            {
                tb_co_seguridadlogBL BL = new tb_co_seguridadlogBL();
                tb_co_seguridadlog BE = new tb_co_seguridadlog();

                BE.moduloid = Name;
                BE.clave = xclave;
                BE.cuser = VariablesPublicas.Usuar;
                BE.fecha = DateTime.Now;
                BE.pc = VariablesPublicas.userip;
                BE.accion = accion.Trim();
                BE.detalle = estructuraid.Text.Trim() + "/" + estructuraname.Text.Trim().ToUpper() + "/" + XGLOSA;

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
                fechadoc.Value = DateTime.Today;
                get_tipocambio(fechadoc.Text.Trim());
                estructuraid.Text = "";
                estructuraname.Text = "";
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
            estructuraid.Text = "NEW";
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            estructuraname.Focus();

            ssModo = "NEW";
        }
        private void Insert()
        {
            try
            {
                if (estructuraid.Text.Trim().Length != 3)
                {
                    MessageBox.Show("Falta Codigo estructura !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (estructuraname.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese nombre de estructura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    tb_ta_estructuraBL BL = new tb_ta_estructuraBL();
                    tb_ta_estructura BE = new tb_ta_estructura();

                    BE.estructuraid = estructuraid.Text.Trim().PadLeft(1, '0');
                    BE.estructuraname = estructuraname.Text.ToUpper();
                    BE.usuar = VariablesPublicas.Usuar.Trim();

                    if (BL.Insert(EmpresaID, BE))
                    {
                        MessageBox.Show("Datos grabados correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (estructuraid.Text.Trim().Length != 1)
                {
                    MessageBox.Show("Falta Codigo estructura !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (estructuraname.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese nombre de estructura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    tb_ta_estructuraBL BL = new tb_ta_estructuraBL();
                    tb_ta_estructura BE = new tb_ta_estructura();

                    BE.estructuraid = estructuraid.Text.Trim().PadLeft(1, '0');
                    BE.estructuraname = estructuraname.Text.ToUpper();
                    BE.usuar = VariablesPublicas.Usuar.Trim();

                    if (BL.Update(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("M");
                        MessageBox.Show("Datos modificado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        procesado = true;
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
                if (estructuraid.Text.Trim().Length != 1)
                {
                    MessageBox.Show("Falta Codigo estructura !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    tb_ta_estructuraBL BL = new tb_ta_estructuraBL();
                    tb_ta_estructura BE = new tb_ta_estructura();

                    BE.estructuraid = estructuraid.Text.Trim().PadLeft(1, '0');
                    BE.estructuraname = estructuraname.Text.ToUpper();
                    BE.usuar = VariablesPublicas.Usuar.Trim();

                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos eliminados correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        limpiar_documento();
                        data_Tablaestructura();
                        form_bloqueado(false);
                        btn_nuevo.Enabled = true;

                        btn_primero.Enabled = true;
                        btn_anterior.Enabled = true;
                        btn_siguiente.Enabled = true;
                        btn_ultimo.Enabled = true;

                        btn_buscar.Enabled = true;
                        btn_salir.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region *** Controles de usuarios
        private void Frm_estructura_Activated(object sender, EventArgs e)
        {

        }
        private void Frm_estructura_Load(object sender, EventArgs e)
        {
            NIVEL_FORMS();

            modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
            local = ((D60ALMACEN.MainAlmacen)MdiParent).local; 

            Tablaestructura = new DataTable();

            limpiar_documento();
            data_Tablaestructura();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_primero.Enabled = true;
            btn_anterior.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_ultimo.Enabled = true;
            btn_buscar.Enabled = true;
            btn_salir.Enabled = true;
        }
        private void Frm_estructura_KeyDown(object sender, KeyEventArgs e)
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
                if (this.btn_cancelar.Enabled)
                {
                    form_accion_cancelEdicion(1);
                }
                else
                {
                    btn_salir_Click(sender, e);
                }
            }
        }

        private void estructuraid_LostFocus(object sender, System.EventArgs e)
        {
            form_cargar_datos("");
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
            //if (XNIVEL == "0" || XNIVEL == "1")
            if (XNIVEL == "0")
            {
                ssModo = "EDIT";
                form_bloqueado(true);
                estructuraname.Focus();

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
            bool sw_prosigue = false;
            if (ssModo == "NEW")
            {
                if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
                    Insert();
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
                data_Tablaestructura();
                form_bloqueado(false);

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
                bool sw_prosigue = false;
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
                if (Tablaestructura.Rows.Count > 0)
                {
                    REPORTES.Frm_reportes miForma = new REPORTES.Frm_reportes();
                    miForma.Text = "Reporte de estructuras";
                    miForma.formulario = "Frm_estructura";
                    miForma.ShowDialog();
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
            Seguridadlog.FrmSeguridad oform = new Seguridadlog.FrmSeguridad();
            String xclave = VariablesPublicas.EmpresaID + "/" + ((D60ALMACEN.MainAlmacen)MdiParent).perianio;
            oform._Nombre = Name;
            oform._ClaveForm = xclave;
            oform.Owner = this;
            oform.ShowDialog();
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }        

        #region $$$ grid estructura
        private void data_Tablaestructura()
        {
            try
            {
                if (Tablaestructura.Rows.Count > 0)
                    Tablaestructura.Rows.Clear();
                tb_ta_estructuraBL BL = new tb_ta_estructuraBL();
                tb_ta_estructura BE = new tb_ta_estructura();

                BE.estructuraname = txt_criterio.Text.Trim().ToUpper();

                Tablaestructura = BL.GetAll(EmpresaID, BE).Tables[0];
                if (Tablaestructura.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    gridestructura.DataSource = Tablaestructura;
                    gridestructura.Rows[0].Selected = false;
                    gridestructura.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridestructura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridestructura.CurrentRow != null)
                {
                    String xestructuraid = "";
                    xestructuraid = gridestructura.Rows[e.RowIndex].Cells["gestructuraid"].Value.ToString().Trim();
                    data_estructura(xestructuraid);
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void gridestructura_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                String xestructuraid = "";
                xestructuraid = gridestructura.Rows[gridestructura.CurrentRow.Index].Cells["gestructuraid"].Value.ToString().Trim();
                data_estructura(xestructuraid);
            }
        }
        private void gridestructura_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridestructura[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            gridestructura[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            gridestructura.EnableHeadersVisualStyles = false;
            gridestructura.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            gridestructura.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void gridestructura_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            gridestructura[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }

        private void data_estructura(String xestructuraid)
        {
            form_bloqueado(false);
            DataRow[] rowestructuraid = Tablaestructura.Select("estructuraid='" + xestructuraid + "'");
            if (rowestructuraid.Length > 0)
            {
                foreach (DataRow row in rowestructuraid)
                {
                    estructuraid.Text = row["estructuraid"].ToString().Trim();
                    estructuraname.Text = row["estructuraname"].ToString().Trim();
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
                btn_salir.Enabled = true;
            }
        }
        #endregion

        #region $$$ busqueda
        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            data_Tablaestructura();
        }
        #endregion

        #region clave admin
        private void NIVEL_FORMS()
        {
            XNIVEL = VariablesPublicas.Get_nivelperfil(((D60ALMACEN.MainAlmacen)MdiParent).perfil, Name).Substring(0, 1);
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
                Ayudas.Form_user_admin miForma = new Ayudas.Form_user_admin();
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
        #endregion

        #endregion
    }
}