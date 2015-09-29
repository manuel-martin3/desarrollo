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
using System.Collections;

namespace BapFormulariosNet.D70Produccion.Costos
{
    public partial class Frm_constantes : plantilla
    {
        /*** variables de cabecera del documento actual ***/
        String EmpresaID = VariablesPublicas.EmpresaID;
        String dominio = "60";
        String modulo = "";
        String local = "";

        String perianio = "";
        String perimes = "";
        String XNIVEL = "";

        String PERFILID = "";
        DataTable TablaConstantes;
        List<tb_perianio> lista = null;
        Boolean fechadocedit = false;
        Boolean procesado = false;
        Boolean statusDoc = true;

        String ssModo = "NEW";

        public Frm_constantes()
        {
            InitializeComponent();
        }

        #region $$$ ADMINISTRADOR
        private void PARAMETROS_TABLA()
        {
            String xxferfil = "";
            MainProduccion f = (MainProduccion)this.MdiParent;
            xxferfil = f.perfil.ToString();
            if (xxferfil.Trim().Length != 9)
            {
                MessageBox.Show("::: NO TIENE PERFIL !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PERFILID = xxferfil;
            String XTABLA_PERFIL = "";
            XTABLA_PERFIL = VariablesPublicas.GET_PARAMETROS_TABLA(xxferfil, Name);
            if (XTABLA_PERFIL.Trim().Length > 0 && XTABLA_PERFIL.Trim() != "0")
            {
                if (XTABLA_PERFIL.Trim().Length == 2)
                {
                    dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
                }
                else if (XTABLA_PERFIL.Trim().Length == 6)
                {
                    dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
                    modulo = XTABLA_PERFIL.Trim().Substring(2, 4);
                }
                else if (XTABLA_PERFIL.Trim().Length == 9)
                {
                    dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
                    modulo = XTABLA_PERFIL.Trim().Substring(2, 4);
                    local = XTABLA_PERFIL.Trim().Substring(6, 3);
                }
            }
            else
            {
                MessageBox.Show("::: No puede accede a FORMULARIO. \n::: Es necesario DOMINIO, MODULO Y LOCAL !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region *** Metodos generales
        
        private void form_bloqueado(Boolean var)
        {
            try
            {
                cbo_perianio.Enabled = true;    
                percgadm.Enabled = var;
                percgvta.Enabled = var;
                percgfin.Enabled = var;

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
            bool sw_prosigue = true;
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

        private void limpiar_documento()
        {
            try
            {
                cbo_perianio.SelectedIndex = -1;
                percgadm.Text = "";
                percgvta.Text = "";
                percgfin.Text = "";
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
            percgadm.Focus();

            ssModo = "NEW";
        }
               
        private void Frm_reporte_stockrollo_Load(object sender, EventArgs e)
        {
            modulo = ((D70Produccion.MainProduccion)MdiParent).moduloid;
            local = ((D70Produccion.MainProduccion)MdiParent).local;
            PERFILID = ((D70Produccion.MainProduccion)MdiParent).perfil;   

            TablaConstantes = new DataTable();
            NIVEL_FORMS();
            _CargarComboAnio();
            limpiar_documento();
            form_bloqueado(false);
            Data_TablaConstantes();
            btn_nuevo.Enabled = true;   
            btn_salir.Enabled = true;
        }


        private void Data_TablaConstantes()
        {
            try
            {                
                if (cbo_perianio.SelectedIndex != -1)
                {
                    if (TablaConstantes.Rows.Count > 0)
                        TablaConstantes.Rows.Clear();

                    tb_pp_constantesBL BL = new tb_pp_constantesBL();
                    tb_pp_constantes BE = new tb_pp_constantes();

                    BE.perianio = cbo_perianio.SelectedValue.ToString();

                    TablaConstantes = BL.GetAll(EmpresaID, BE).Tables[0];
                    if (TablaConstantes.Rows.Count > 0)
                    {
                        btn_imprimir.Enabled = true;
                        MDI_dgb_constantes.DataSource = TablaConstantes;
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
                //REPORTES.Frm_reportes miForma = new REPORTES.Frm_reportes();
                //miForma.Text = "Diferencia de Inventario";
                //miForma.dominioid = dominio.Trim();
                //miForma.moduloid = modulo.Trim();
                //miForma.local = local.Trim();            

                //miForma.formulario = "Frm_reporte_diferenciaInv";
                //miForma.Show();
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
            percgadm.Focus();

            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
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

        private void Insert()
        {
            try
            {

                if (cbo_perianio.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccion el Año...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    tb_pp_constantesBL BL = new tb_pp_constantesBL();
                    tb_pp_constantes BE = new tb_pp_constantes();

                    BE.perianio = cbo_perianio.SelectedValue.ToString();
                    BE.percgadm = Convert.ToDecimal(percgadm.Text);
                    BE.percgvta = Convert.ToDecimal(percgvta.Text);
                    BE.percgfin = Convert.ToDecimal(percgfin.Text);
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
                if (cbo_perianio.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccion el Año...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    tb_pp_constantesBL BL = new tb_pp_constantesBL();
                    tb_pp_constantes BE = new tb_pp_constantes();

                    BE.perianio = cbo_perianio.SelectedValue.ToString();
                    BE.percgadm = Convert.ToDecimal(percgadm.Text);
                    BE.percgvta = Convert.ToDecimal(percgvta.Text);
                    BE.percgfin = Convert.ToDecimal(percgfin.Text);
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
                if (cbo_perianio.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione el Año...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    tb_pp_constantesBL BL = new tb_pp_constantesBL();
                    tb_pp_constantes BE = new tb_pp_constantes();

                    BE.perianio = cbo_perianio.SelectedValue.ToString();                 

                    if (BL.Delete(EmpresaID, BE))
                    {
                        MessageBox.Show("Datos eliminado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (cbo_perianio.SelectedIndex != -1)
            {
                Data_TablaConstantes();
                percgadm.Text = "";
                percgvta.Text = "";
                percgfin.Text = "";
                percgadm.Focus();
            }
        }

        private void _CargarComboAnio()
        {
            tb_perianioBL BL = new tb_perianioBL();
            lista = BL.Get_anio(EmpresaID);
            cbo_perianio.DataSource = lista;
            cbo_perianio.DisplayMember = "perianio";
            cbo_perianio.ValueMember = "codigo";
        }

        private void MDI_dgb_constantes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                String xperianio = dgb_constantes.GetRowCellValue(dgb_constantes.FocusedRowHandle, "perianio").ToString();
                Data_ConstantesDet(xperianio);
            }
        }

        private void Data_ConstantesDet(String xperianio)
        {
            form_bloqueado(false);
            DataRow[] rowConstantes = TablaConstantes.Select("perianio='" + xperianio + "'");
            if (rowConstantes.Length > 0)
            {
                foreach (DataRow row in rowConstantes)
                {
                    cbo_perianio.SelectedValue = row["perianio"].ToString().Trim();
                    percgadm.Text = row["percgadm"].ToString().Trim();
                    percgvta.Text = row["percgvta"].ToString().Trim();
                    percgfin.Text = row["percgfin"].ToString().Trim();
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
            String xperianio = dgb_constantes.GetRowCellValue(e.RowHandle, "perianio").ToString();
            Data_ConstantesDet(xperianio);  
        }

        private void percgadm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { percgvta.Focus(); }
        }

        private void percgvta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { percgfin.Focus(); }
        }


    }
}