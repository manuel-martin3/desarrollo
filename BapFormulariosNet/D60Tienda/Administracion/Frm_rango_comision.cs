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
    public partial class Frm_rango_comision : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable Tablarango;
        private Boolean procesado = false;

        private String ssModo = "NEW";

        public Frm_rango_comision()
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
                cmb_cateplan.Enabled = var;
                chk_act.Enabled = var;

                txtperianio.Enabled = var;
                cmb_perimes.Enabled = var;
                txtporcin.Enabled = var;
                txt_porfin.Enabled = var;
                txtcomiclasico.Enabled = var;
                txtcomimoda.Enabled = var;
                txtcomicorriente.Enabled = var;
                txtcomimayorold.Enabled = var;
                txtcomicumplecuota.Enabled = var;
                txtcomicuotaefectivo.Enabled = var;

                dgb_comisiones.ReadOnly = true;
                dgb_comisiones.Enabled = !var;
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
                BE.detalle = txtperianio.Text.Trim() + "/" + cmb_perimes.Text.Trim().ToUpper()  + "/" + XGLOSA;

                BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiar_documento()
        {
            txtperianio.Text = "";
            cmb_perimes.SelectedIndex = -1;
            cmb_cateplan.SelectedIndex = -1;
            chk_act.Checked = false;
            txtporcin.Text = "";
            txt_porfin.Text = "";
            txtcomiclasico.Text = "";
            txtcomimoda.Text = "";
            txtcomicorriente.Text = "";
            txtcomimayorold.Text = "";
            txtcomicumplecuota.Text = "";
            txtcomicuotaefectivo.Text = "";
            txtperianio.Focus();
        }

        private void nuevo()
        {
            limpiar_documento();
            form_bloqueado(true);          
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_log.Enabled = true;
            txtperianio.Text = DateTime.Today.Year.ToString();
            ssModo = "NEW";
        }


        private Boolean ValDatos()
        {
            Boolean val = true;
            if (txtperianio.Text.Length == 0)
            {
                MessageBox.Show("Ingrese Año !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                val = false;
            }else
                if (cmb_perimes.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un Mes !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    val = false;
                }
                else
                    if (cmb_cateplan.SelectedIndex == -1)
                    {
                        MessageBox.Show("Seleccione una Categoria !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        val = false;
                    }
                    else
                        if (txtporcin.Text.Length == 0)
                        {
                            MessageBox.Show("Ingrese PorcIni !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            val = false;
                        }
            return val;
        }


        private void Insert()
        {
            try
            {
                if (ValDatos())
                {
                    var BL = new tb_me_rangocomicBL();
                    var BE = new tb_me_rangocomic();

                    BE.perianio = txtperianio.Text;
                    BE.perimes = cmb_perimes.SelectedValue.ToString();                    
                    if(cmb_cateplan.SelectedIndex != -1)
                        BE.cateplanid = cmb_cateplan.SelectedValue.ToString();
                    BE.porcini = Convert.ToDecimal(txtporcin.Text);
                    BE.porcfin = Convert.ToDecimal(txt_porfin.Text);
                    BE.comiclasico = Convert.ToDecimal(txtcomiclasico.Text);
                    BE.comimoda = Convert.ToDecimal(txtcomimoda.Text);
                    BE.comicorriente = Convert.ToDecimal(txtcomicorriente.Text);
                    BE.comimayorold = Convert.ToDecimal(txtcomimayorold.Text);
                    BE.comicumplecuota = Convert.ToDecimal(txtcomicumplecuota.Text);
                    BE.comicuotaefectivo = Convert.ToDecimal(txtcomicuotaefectivo.Text);

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
                if (ValDatos())
                {

                    var BL = new tb_me_rangocomicBL();
                    var BE = new tb_me_rangocomic();

                    BE.perianio = txtperianio.Text;
                    BE.perimes = cmb_perimes.SelectedValue.ToString();
                    if (cmb_cateplan.SelectedIndex != -1)
                        BE.cateplanid = cmb_cateplan.SelectedValue.ToString();
                    BE.porcini = Convert.ToDecimal(txtporcin.Text);
                    BE.porcfin = Convert.ToDecimal(txt_porfin.Text);
                    BE.comiclasico = Convert.ToDecimal(txtcomiclasico.Text);
                    BE.comimoda = Convert.ToDecimal(txtcomimoda.Text);
                    BE.comicorriente = Convert.ToDecimal(txtcomicorriente.Text);
                    BE.comimayorold = Convert.ToDecimal(txtcomimayorold.Text);
                    BE.comicumplecuota = Convert.ToDecimal(txtcomicumplecuota.Text);
                    BE.comicuotaefectivo = Convert.ToDecimal(txtcomicuotaefectivo.Text);

                    if (BL.Update(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("M");
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
                if (ValDatos())
                {                
                    var BL = new tb_me_rangocomicBL();
                    var BE = new tb_me_rangocomic();
                    BE.perianio = txtperianio.Text;
                    BE.perimes = cmb_perimes.SelectedValue.ToString();
                    BE.cateplanid = cmb_cateplan.SelectedValue.ToString();
                    BE.porcini = Convert.ToDecimal(txtporcin.Text);

                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos Eliminados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        form_bloqueado(false);
                        limpiar_documento();
                        data_Tablarango();
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
            Tablarango = new DataTable();
            _CargarMes();
            CargarCateplan();         
            data_Tablarango();
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
            //cmb_perianio.DataSource = LISTA;
            //cmb_perianio.DisplayMember = "perianio";
            //cmb_perianio.ValueMember = "codigo";
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

        void CargarCateplan()
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
                data_Tablarango();
                form_bloqueado(false);
                //txtcargoid.Text = "NN";
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
                if (Tablarango.Rows.Count > 0)
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

        private void data_Tablarango()
        {
            try
            {
                if (Tablarango.Rows.Count > 0)
                {
                    Tablarango.Rows.Clear();
                }
                var BL = new tb_me_rangocomicBL();
                var BE = new tb_me_rangocomic();

                BE.parameters = txtbusqueda.Text.Trim().ToUpper();

                Tablarango = BL.GetAll2(EmpresaID, BE).Tables[0];
                if (Tablarango.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    dgb_comisiones.DataSource = Tablarango;
                    dgb_comisiones.Rows[0].Selected = false;                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgb_comisiones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgb_comisiones.CurrentRow != null)
                {
                    tb_me_rangocomic BE = new tb_me_rangocomic();
                    BE.perianio = dgb_comisiones.Rows[e.RowIndex].Cells["perianio"].Value.ToString().Trim();
                    BE.perimes = dgb_comisiones.Rows[e.RowIndex].Cells["perimes"].Value.ToString().Trim();
                    BE.cateplanid = dgb_comisiones.Rows[e.RowIndex].Cells["cateplanid"].Value.ToString().Trim();
                    BE.porcini = Convert.ToDecimal(dgb_comisiones.Rows[e.RowIndex].Cells["porcini"].Value.ToString());
                    data_cargos(BE);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
        }

        private void dgb_comisiones_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                tb_me_rangocomic BE = new tb_me_rangocomic();
                BE.perianio = dgb_comisiones.Rows[dgb_comisiones.CurrentRow.Index].Cells["perianio"].Value.ToString().Trim();
                BE.perimes = dgb_comisiones.Rows[dgb_comisiones.CurrentRow.Index].Cells["perimes"].Value.ToString().Trim();
                BE.cateplanid = dgb_comisiones.Rows[dgb_comisiones.CurrentRow.Index].Cells["cateplanid"].Value.ToString().Trim();
                BE.porcini = Convert.ToDecimal(dgb_comisiones.Rows[dgb_comisiones.CurrentRow.Index].Cells["porcini"].Value.ToString());
                data_cargos(BE);
            }
        }

        private void dgb_comisiones_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgb_comisiones[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            dgb_comisiones[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            dgb_comisiones.EnableHeadersVisualStyles = false;
            dgb_comisiones.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            dgb_comisiones.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void dgb_comisiones_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dgb_comisiones[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }

        private void data_cargos(tb_me_rangocomic BE)
        {
            form_bloqueado(false);

            String expresion = " perianio ='" + BE.perianio + "' AND "+                               
                               " perimes ='" + BE.perimes + "' AND "+
                               " cateplanid ='" + BE.cateplanid + "' AND " +
                               " porcini ='" + BE.porcini + "' ";

            var rowcargosid = Tablarango.Select(expresion);
            if (rowcargosid.Length > 0)
            {
                foreach (DataRow row in rowcargosid)
                {
                    txtperianio.Text = row["perianio"].ToString().Trim();
                    cmb_perimes.SelectedValue = row["perimes"].ToString().Trim();
                    cmb_cateplan.SelectedValue = row["cateplanid"].ToString();
                    txtporcin.Text = row["porcini"].ToString();
                    txt_porfin.Text = row["porcfin"].ToString();
                    txtcomiclasico.Text = row["comiclasico"].ToString();
                    txtcomimoda.Text = row["comimoda"].ToString();
                    txtcomicorriente.Text = row["comicorriente"].ToString();
                    txtcomimayorold.Text = row["comimayorold"].ToString();
                    txtcomicumplecuota.Text = row["comicumplecuota"].ToString();
                    txtcomicuotaefectivo.Text = row["comicuotaefectivo"].ToString();

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
            data_Tablarango();
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
            data_Tablarango();
        }

        private void chk_act_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_act.Checked)
                cmb_cateplan.SelectedIndex = -1;
        }

        private void btn_generar_Click(object sender, EventArgs e)
        {
            tb_me_rangocomicBL BL = new tb_me_rangocomicBL();
            tb_me_rangocomic BE = new tb_me_rangocomic();

            if (BL.Generar(EmpresaID, BE))
            {
                MessageBox.Show("Procesos Generados Correctamente");
            }            
        } 
 

    }
}
