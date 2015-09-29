using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.D60Tienda.Administracion
{
    public partial class Frm_cargos : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable Tablacargos;
        private Boolean procesado = false;

        private String ssModo = "NEW";

        public Frm_cargos()
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
                txtcargoid.Enabled = false;
                txtcargoname.Enabled = var;
                
                cmb_cateplan.Enabled = var;
                chk_act.Enabled = var;
                
                dgb_cargos.ReadOnly = true;
                dgb_cargos.Enabled = !var;
                txtbusqueda.Enabled = !var;
                btn_busqueda.Enabled = !var;

                btn_nuevo.Enabled = false;
                btn_editar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_grabar.Enabled = false;
                btn_eliminar.Enabled = false;
                btn_imprimir.Enabled = false;

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
                btn_salir.Enabled = true;
                ssModo = "NEW";
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
                BE.detalle = txtcargoid.Text.Trim() + "/" + txtcargoname.Text.Trim().ToUpper()  + "/" + XGLOSA;

                BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiar_documento()
        {
            txtcargoid.Text = "";
            txtcargoname.Text = "";
            cmb_cateplan.SelectedIndex = -1;
            chk_act.Checked = false;
        }

        private void nuevo()
        {
            limpiar_documento();
            form_bloqueado(true);          
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_log.Enabled = true;
            txtcargoid.Focus();
            ssModo = "NEW";
        }

        private void Insert()
        {
            try
            {
                
                if (txtcargoname.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Nombre de Cargo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_me_cargoBL();
                    var BE = new tb_me_cargo();

                    //BE.cargoid = txtcargoid.Text.ToString();
                    BE.cargoname = txtcargoname.Text.ToString();
                    if(cmb_cateplan.SelectedIndex != -1)
                        BE.cateplanid = Convert.ToInt32(cmb_cateplan.SelectedValue.ToString());                            

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
                if (txtcargoid.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Falta Codigo de Cargo !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (txtcargoname.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese Nombre de Cargo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new tb_me_cargoBL();
                        var BE = new tb_me_cargo();

                        BE.cargoid = txtcargoid.Text.ToString();
                        BE.cargoname = txtcargoname.Text.ToString();
                        if (cmb_cateplan.SelectedIndex != -1)
                            BE.cateplanid = Convert.ToInt32(cmb_cateplan.SelectedValue.ToString());     

                        if (BL.Update(EmpresaID, BE))
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
                if (txtcargoid.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Falta Codigo Cargo !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_me_cargoBL();
                    var BE = new tb_me_cargo();
                    BE.cargoid = txtcargoid.Text.ToString();

                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos Eliminados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        form_bloqueado(false);
                        limpiar_documento();
                        data_Tablacargos();
                        btn_nuevo.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_cargos_Load(object sender, EventArgs e)
        {                       
            modulo = ((D60Tienda.MainTienda)MdiParent).moduloid;
            local = ((D60Tienda.MainTienda)MdiParent).local;
            PERFILID = ((D60Tienda.MainTienda)MdiParent).perfil;            

            NIVEL_FORMS();
            Tablacargos = new DataTable();
            CargarCatPanilla();
            txtcargoname.CharacterCasing = CharacterCasing.Upper;
            data_Tablacargos();
            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;            
            btn_salir.Enabled = true;
        }

        void CargarCatPanilla()
        {
            tb_me_categoriaplanillaBL BL = new tb_me_categoriaplanillaBL();
            tb_me_categoriaplanilla BE = new tb_me_categoriaplanilla();
            DataTable dt = new DataTable();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cmb_cateplan.DataSource = dt;
                cmb_cateplan.DisplayMember = "cateplanname";
                cmb_cateplan.ValueMember = "cateplanid";
            }
        }


        private void Frm_cargos_KeyDown(object sender, KeyEventArgs e)
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
                txtcargoname.Focus();

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
                data_Tablacargos();
                form_bloqueado(false);
                txtcargoid.Text = "NN";
                btn_nuevo.Enabled = true;             

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
                if (Tablacargos.Rows.Count > 0)
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

        private void data_Tablacargos()
        {
            try
            {
                if (Tablacargos.Rows.Count > 0)
                {
                    Tablacargos.Rows.Clear();
                }
                var BL = new tb_me_cargoBL();
                var BE = new tb_me_cargo();

                BE.cargoname = txtbusqueda.Text.Trim().ToUpper();

                Tablacargos = BL.GetAll(EmpresaID, BE).Tables[0];
                if (Tablacargos.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    dgb_cargos.DataSource = Tablacargos;
                    dgb_cargos.Rows[0].Selected = false;                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgb_cargos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgb_cargos.CurrentRow != null)
                {
                    var xcargosid = string.Empty;
                    xcargosid = dgb_cargos.Rows[e.RowIndex].Cells["cargoid"].Value.ToString().Trim();
                    data_cargos(xcargosid);
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void dgb_cargos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xcargosid = string.Empty;
                xcargosid = dgb_cargos.Rows[dgb_cargos.CurrentRow.Index].Cells["cargoid"].Value.ToString().Trim();
                data_cargos(xcargosid);
            }
        }

        private void dgb_cargos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgb_cargos[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            dgb_cargos[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            dgb_cargos.EnableHeadersVisualStyles = false;
            dgb_cargos.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            dgb_cargos.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void dgb_cargos_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dgb_cargos[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }

        private void data_cargos(String xcargosid)
        {
            form_bloqueado(false);
            var rowcargosid = Tablacargos.Select("cargoid='" + xcargosid + "'");
            if (rowcargosid.Length > 0)
            {
                foreach (DataRow row in rowcargosid)
                {
                    txtcargoid.Text = row["cargoid"].ToString().Trim();
                    txtcargoname.Text = row["cargoname"].ToString().Trim();
                    cmb_cateplan.SelectedValue = row["cateplanid"].ToString();

                    btn_nuevo.Enabled = true;
                    btn_editar.Enabled = true;
                    btn_eliminar.Enabled = true;
                    btn_imprimir.Enabled = true;
                    btn_log.Enabled = true;
                    btn_salir.Enabled = true;
                }
            }
        }

        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            data_Tablacargos();
        }

        private void txt_criterio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_busqueda_Click(sender, e);
            }
        }

        private void txtbusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            data_Tablacargos();
        }

        private void chk_act_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_act.Checked)
                cmb_cateplan.SelectedIndex = -1;
        }      


    }
}
