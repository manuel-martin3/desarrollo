using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.D70Produccion.Costos
{
    public partial class Frm_rubrocosto : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = VariablesPublicas.Dominioid;
        private String modulo = string.Empty;
        private String local = string.Empty;
        private String XNIVEL = string.Empty;

        private String PERFILID = string.Empty;
        private DataTable TablaRubroCosto;
        private Boolean procesado = false;

        private String ssModo = "NEW";

        public Frm_rubrocosto()
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

        private void form_bloqueado(Boolean var)
        {
            try
            {
                cboModuloID.Enabled = true;
                rubroid.Enabled = false;
                rubroname.Enabled = var;

                btn_nuevo.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_imprimir.Enabled = false;
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
                limpiar_documento();
                form_bloqueado(false);
                btn_nuevo.Enabled = true;
                btn_salir.Enabled = true;
                btn_grabar.Enabled = false;

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

        private void limpiar_documento()
        {
            try
            {
                cboModuloID.SelectedIndex = -1;
                rubroid.Text = string.Empty;
                rubroname.Text = string.Empty;
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
            btn_imprimir.Enabled = true;
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            rubroid.Focus();

            ssModo = "NEW";
        }
        private void Frm_reporte_stockrollo_Load(object sender, EventArgs e)
        {
            modulo = ((D70Produccion.MainProduccion)MdiParent).moduloid;
            local = ((D70Produccion.MainProduccion)MdiParent).local;
            PERFILID = ((D70Produccion.MainProduccion)MdiParent).perfil;

            TablaRubroCosto = new DataTable();
            NIVEL_FORMS();
            limpiar_documento();
            get_cbo_modulo();
            form_bloqueado(false);
            Data_TablaConstantes();
            btn_nuevo.Enabled = true;
            btn_salir.Enabled = true;
        }


        private void get_cbo_modulo()
        {
            var BL = new sys_dominioBL();
            try
            {
                cboModuloID.DataSource = BL.GetAllDominioModuloPorUsuario(VariablesPublicas.EmpresaID, VariablesPublicas.Usuar, "60").Tables[0];
                cboModuloID.ValueMember = "moduloid";
                cboModuloID.DisplayMember = "moduloname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Data_TablaConstantes()
        {
            try
            {
                if (cboModuloID.SelectedIndex != -1)
                {
                    if (TablaRubroCosto.Rows.Count > 0)
                    {
                        TablaRubroCosto.Rows.Clear();
                    }
                    var BL = new tb_pp_rubrocostoBL();
                    var BE = new tb_pp_rubrocosto();

                    BE.moduloid = cboModuloID.SelectedValue.ToString();

                    TablaRubroCosto = BL.GetAll(EmpresaID, BE).Tables[0];
                    if (TablaRubroCosto.Rows.Count > 0)
                    {
                        btn_imprimir.Enabled = true;
                        MDI_dgb_rubrocosto.DataSource = TablaRubroCosto;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            form_accion_cancelEdicion(1);
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
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
                form_bloqueado(false);
                Data_TablaConstantes();
                btn_nuevo.Enabled = true;
                btn_salir.Enabled = true;
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            ssModo = "EDIT";
            form_bloqueado(true);
            rubroid.Focus();

            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
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

        private void Insert()
        {
            try
            {
                if (cboModuloID.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccion un Modulo...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_pp_rubrocostoBL();
                    var BE = new tb_pp_rubrocosto();

                    BE.moduloid = cboModuloID.SelectedValue.ToString();
                    BE.rubroname = rubroname.Text.ToUpper();
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
                if (cboModuloID.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccion un Modulo...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_pp_rubrocostoBL();
                    var BE = new tb_pp_rubrocosto();

                    BE.moduloid = cboModuloID.SelectedValue.ToString();
                    BE.rubroid = rubroid.Text;
                    BE.rubroname = rubroname.Text.ToUpper();
                    BE.usuar = VariablesPublicas.Usuar.Trim();

                    if (BL.Update(EmpresaID, BE))
                    {
                        MessageBox.Show("Datos Modificado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (cboModuloID.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccion un Modulo...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_pp_rubrocostoBL();
                    var BE = new tb_pp_rubrocosto();

                    BE.moduloid = cboModuloID.SelectedValue.ToString();
                    BE.rubroid = rubroid.Text;

                    if (BL.Delete(EmpresaID, BE))
                    {
                        MessageBox.Show("Datos Eliminado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        limpiar_documento();
                        form_bloqueado(false);
                        Data_TablaConstantes();
                        btn_nuevo.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void cbo_perianio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModuloID.SelectedIndex != -1)
            {
                Data_TablaConstantes();
                rubroid.Text = string.Empty;
                rubroid.Focus();
            }
        }

        private void MDI_dgb_constantes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xrubroid = dgb_rubrocosto.GetRowCellValue(dgb_rubrocosto.FocusedRowHandle, "rubroid").ToString();
                Data_RubroCosto(xrubroid);
            }
        }

        private void Data_RubroCosto(String xrubroid)
        {
            form_bloqueado(false);
            var rowRubroCosto = TablaRubroCosto.Select("rubroid='" + xrubroid + "'");
            if (rowRubroCosto.Length > 0)
            {
                foreach (DataRow row in rowRubroCosto)
                {
                    cboModuloID.SelectedValue = row["moduloid"].ToString().Trim();
                    rubroid.Text = row["rubroid"].ToString().Trim();
                    rubroname.Text = row["rubroname"].ToString().Trim();
                }

                btn_nuevo.Enabled = true;
                btn_editar.Enabled = true;
                btn_eliminar.Enabled = true;
                btn_imprimir.Enabled = true;
                btn_salir.Enabled = true;
            }
        }

        private void dgb_constantes_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var xrubroid = dgb_rubrocosto.GetRowCellValue(e.RowHandle, "rubroid").ToString();
            Data_RubroCosto(xrubroid);
        }

        private void cboModuloID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModuloID.SelectedIndex != -1)
            {
                Data_TablaConstantes();
            }
        }
    }
}
