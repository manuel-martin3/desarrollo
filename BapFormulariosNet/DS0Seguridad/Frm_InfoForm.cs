using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;


namespace BapFormulariosNet.DS0Seguridad
{
    public partial class Frm_InfoForm : plantilla
    {
        private DataTable TablaFormulario;
        private String ssModo = "NEW";
        private Boolean procesado = false;


        public Frm_InfoForm()
        {
            InitializeComponent();
        }

        private void Frm_InfoForm_Load(object sender, EventArgs e)
        {
            TablaFormulario = new DataTable("FrmFormulario");
            TablaFormulario.Columns.Add("frmid", typeof(String));
            TablaFormulario.Columns.Add("frmname", typeof(String));
            TablaFormulario.Columns.Add("frmmensaje", typeof(String));

            get_cargarComboDominio();
            limpiar_documento();
            Data_TablaFormulario();
            bloqueo(false);
        }

        private void get_cargarComboDominio()
        {
            var BL = new sys_dominioBL();

            try
            {
                cmb_dominio.DataSource = BL.GetAllDominioPorUsuario(VariablesPublicas.EmpresaID, VariablesPublicas.Usuar).Tables[0];
                cmb_dominio.ValueMember = "dominioid";
                cmb_dominio.DisplayMember = "dominioname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            get_cbo_modulo();
        }

        private void get_cbo_modulo()
        {
            var BL = new sys_dominioBL();
            try
            {
                cmb_modulo.DataSource = BL.GetAllDominioModuloPorUsuario(VariablesPublicas.EmpresaID, VariablesPublicas.Usuar, cmb_dominio.SelectedValue.ToString()).Tables[0];
                cmb_modulo.ValueMember = "moduloid";
                cmb_modulo.DisplayMember = "moduloname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bloqueo(Boolean var)
        {
            cmb_dominio.Enabled = true;
            cmb_modulo.Enabled = true;
            txtnameform.Enabled = var;
            txtfunciones.Enabled = var;
            fechdoc.Enabled = false;

            btn_cancelar.Enabled = false;
            btn_grabar.Enabled = var;
            btn_editar.Enabled = false;
            btn_eliminar.Enabled = false;
            dgv_formularios.ReadOnly = true;
        }
        private void dgv_formularios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            ssModo = "NEW";
            limpiar_documento();
            bloqueo(true);
            btn_nuevo.Enabled = false;
            btn_cancelar.Enabled = true;
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            ssModo = "EDIT";
            bloqueo(true);
            btn_cancelar.Enabled = true;
            btn_eliminar.Enabled = true;
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
                limpiar_documento();
                bloqueo(false);
                btn_nuevo.Enabled = true;
                btn_salir.Enabled = true;
                ssModo = "NEW";
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            form_accion_cancelEdicion(1);
        }

        private void cmb_dominio_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_cbo_modulo();
        }

        private void limpiar_documento()
        {
            txtnameform.Text = string.Empty;
            txtfunciones.Text = string.Empty;
            fechdoc.Text = Convert.ToString(DateTime.Today);
            txtnameform.Focus();
        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {
            procesado = false;
            var sw_prosigue = false;
            if (ssModo == "NEW")
            {
                Insert();
            }
            else
            {
                sw_prosigue = (MessageBox.Show("¿Desea Modificar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
                if (sw_prosigue)
                {
                    Update();
                }
            }
            if (procesado)
            {
                Data_TablaFormulario();
                bloqueo(false);
                btn_nuevo.Enabled = true;
                btn_salir.Enabled = true;
            }
        }

        private void Insert()
        {
            try
            {
                if (txtnameform.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Falta Nombre del Formulario!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (txtfunciones.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Falta Ingresar las Funciones!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BE = new tb_sys_formulario();
                        var BL = new sys_formulariosBL();

                        BE.dominioid = cmb_dominio.SelectedValue.ToString();
                        BE.moduloid = cmb_modulo.SelectedValue.ToString();
                        BE.formname = txtnameform.Text;
                        BE.formfunc = txtfunciones.Text;
                        BE.feact = Convert.ToDateTime(fechdoc.Text);

                        if (BL.Insert(VariablesPublicas.EmpresaID, BE))
                        {
                            MessageBox.Show("Datos Grabados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (txtnameform.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Falta Nombre del Formulario!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (txtfunciones.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Falta Ingresar las Funciones!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BE = new tb_sys_formulario();
                        var BL = new sys_formulariosBL();

                        BE.dominioid = cmb_dominio.SelectedValue.ToString();
                        BE.moduloid = cmb_modulo.SelectedValue.ToString();
                        BE.formname = txtnameform.Text;
                        BE.formfunc = txtfunciones.Text;
                        BE.feact = Convert.ToDateTime(fechdoc.Text);

                        if (BL.Update(VariablesPublicas.EmpresaID, BE))
                        {
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


        private void Data_TablaFormulario()
        {
            try
            {
                if (TablaFormulario.Rows.Count > 0)
                {
                    TablaFormulario.Rows.Clear();
                }
                var BL = new sys_formulariosBL();
                var BE = new tb_sys_formulario();

                BE.dominioid = cmb_dominio.SelectedValue.ToString();
                BE.moduloid = cmb_modulo.SelectedValue.ToString();

                TablaFormulario = BL.GetAll(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (TablaFormulario.Rows.Count > 0)
                {
                    dgv_formularios.DataSource = TablaFormulario;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_formularios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_formularios.CurrentRow != null)
                {
                    var xforname = string.Empty;
                    xforname = dgv_formularios.Rows[e.RowIndex].Cells["formname"].Value.ToString().Trim();
                    Data_Form(xforname);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgv_formularios_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xforname = string.Empty;
                xforname = dgv_formularios.Rows[dgv_formularios.CurrentRow.Index].Cells["formname"].Value.ToString().Trim();
                Data_Form(xforname);
            }
        }

        private void Data_Form(String xforname)
        {
            bloqueo(false);
            var rowforname = TablaFormulario.Select("formname='" + xforname + "'");
            if (rowforname.Length > 0)
            {
                foreach (DataRow row in rowforname)
                {
                    txtnameform.Text = row["formname"].ToString().Trim();
                    txtfunciones.Text = row["formfunc"].ToString().Trim();
                    fechdoc.Text = row["feact"].ToString().Trim();
                }

                btn_nuevo.Enabled = true;
                btn_editar.Enabled = true;
                btn_eliminar.Enabled = true;
                btn_salir.Enabled = true;
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            var sw_prosigue = false;
            sw_prosigue = (MessageBox.Show("¿Desea Eliminar Documento Actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

            if (sw_prosigue)
            {
                Delete();
            }
        }


        private void Delete()
        {
            try
            {
                if (txtnameform.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Falta Nombre del Formulario!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (txtfunciones.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Falta Ingresar las Funciones!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BE = new tb_sys_formulario();
                        var BL = new sys_formulariosBL();

                        BE.dominioid = cmb_dominio.SelectedValue.ToString();
                        BE.moduloid = cmb_modulo.SelectedValue.ToString();
                        BE.formname = txtnameform.Text;

                        if (BL.Delete(VariablesPublicas.EmpresaID, BE))
                        {
                            MessageBox.Show("Datos Eliminado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Data_TablaFormulario();
                            limpiar_documento();
                            bloqueo(false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmb_modulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiar_documento();
            Data_TablaFormulario();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
