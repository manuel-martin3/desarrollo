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

namespace BapFormulariosNet.MERCADERIA02.CATALOGO
{
    public partial class Frm_talla : plantilla
    {
        /*** variables de cabecera del documento actual ***/
        String EmpresaID = VariablesPublicas.EmpresaID;
        String dominio = "60";
        String modulo = "";
        String local = "";   

        String XNIVEL = "";
        String XGLOSA = "";
        String PERFILID = "";

        DataTable Tablatalla;
        String _articulo = "";
        Boolean fechadocedit = false;
        Boolean procesado = false;
        Boolean statusDoc = true;

        String ssModo = "NEW";

        public Frm_talla()
        {
            InitializeComponent();
            tallaid.LostFocus += new System.EventHandler(tallaid_LostFocus);          
        }

        #region $$$ ADMINISTRADOR
        private void PARAMETROS_TABLA()
        {
            String xxferfil = "";
            MainMercaderia02 f = (MainMercaderia02)this.MdiParent;
            xxferfil = f.perfil.ToString();
            if (xxferfil.Trim().Length != 9)
            {
                MessageBox.Show("::: NO TIENE PERFIL !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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

        #region *** Metodos generales

        private void form_bloqueado(Boolean var)
        {
            try
            {

                tallaid.Enabled = !var;
                tallaname.Enabled = var;  // var
                talla01.Enabled = var;
                talla02.Enabled = var;
                talla03.Enabled = var;
                talla04.Enabled = var;
                talla05.Enabled = var;
                talla06.Enabled = var;
                talla07.Enabled = var;
                talla08.Enabled = var;
                talla09.Enabled = var;
                talla10.Enabled = var;
                talla11.Enabled = var;
                talla12.Enabled = var;
               
                gridtalla.ReadOnly = true;
                gridtalla.Enabled = !var;
                cbo_buscar.Enabled = !var;
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
                NIVEL_FORMS();
                limpiar_documento();
                form_bloqueado(false);
                tallaid.Text = "NN";
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
                tb_pt_tallaBL BL = new tb_pt_tallaBL();
                tb_pt_talla BE = new tb_pt_talla();
                DataTable dt = new DataTable();
              
                if (tallaid.Text.Trim().Length > 0){
                    BE.tallaid = tallaid.Text.Trim().PadLeft(2, '0');
                }

                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    limpiar_documento();
                    ssModo = "EDIT";
                
                    tallaid.Text = dt.Rows[0]["tallaid"].ToString().Trim();
                    tallaname.Text = dt.Rows[0]["tallaname"].ToString().Trim();
                    talla01.Text = dt.Rows[0]["talla01"].ToString().Trim();
                    talla02.Text = dt.Rows[0]["talla02"].ToString().Trim();
                    talla03.Text = dt.Rows[0]["talla03"].ToString().Trim();
                    talla04.Text = dt.Rows[0]["talla04"].ToString().Trim();
                    talla05.Text = dt.Rows[0]["talla05"].ToString().Trim();
                    talla06.Text = dt.Rows[0]["talla06"].ToString().Trim();
                    talla07.Text = dt.Rows[0]["talla07"].ToString().Trim();
                    talla08.Text = dt.Rows[0]["talla08"].ToString().Trim();
                    talla09.Text = dt.Rows[0]["talla09"].ToString().Trim();
                    talla10.Text = dt.Rows[0]["talla10"].ToString().Trim();
                    talla11.Text = dt.Rows[0]["talla11"].ToString().Trim();
                    talla12.Text = dt.Rows[0]["talla12"].ToString().Trim();                    

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
       
        #region $$$ Llenado de Combobox
        void data_cbo_buscar()
        {
            cbo_buscar.Items.Add(new System.Web.UI.WebControls.ListItem("NOMBRE TALLA", "01"));
            cbo_buscar.Items.Add(new System.Web.UI.WebControls.ListItem("COD TALLA", "02"));
            cbo_buscar.SelectedIndex = 0;
        }
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
            String xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio;
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
                //tallaid.Text = "";
                tallaname.Text = "";
                talla01.Text = "";
                talla02.Text = "";
                talla03.Text = "";
                talla04.Text = "";
                talla05.Text = "";
                talla06.Text = "";
                talla07.Text = "";
                talla08.Text = "";
                talla09.Text = "";
                talla10.Text = "";
                talla11.Text = "";
                talla12.Text = "";                
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
            tallaid.Text = "NN";
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_log.Enabled = true;  

            ssModo = "NEW";
        }

        private void Insert()
        {
            try
            {
                if (tallaid.Text.Trim().Length != 2)
                {
                    MessageBox.Show("Falta Codigo talla !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (tallaname.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese nombre de talla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    tb_pt_tallaBL BL = new tb_pt_tallaBL();
                    tb_pt_talla BE = new tb_pt_talla();

               
                    BE.tallaid = tallaid.Text.Trim().PadLeft(2, '0');
                    BE.tallaname = tallaname.Text.ToUpper();
                    BE.talla01 = talla01.Text;
                    BE.talla02 = talla02.Text;
                    BE.talla03 = talla03.Text;
                    BE.talla04 = talla04.Text;
                    BE.talla05 = talla05.Text;
                    BE.talla06 = talla06.Text;
                    BE.talla07 = talla07.Text;
                    BE.talla08 = talla08.Text;
                    BE.talla09 = talla09.Text;
                    BE.talla10 = talla10.Text;
                    BE.talla11 = talla11.Text;
                    BE.talla12 = talla12.Text;
                    
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
                if (tallaid.Text.Trim().Length != 2)
                {
                    MessageBox.Show("Falta Codigo Talla !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (tallaname.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Nombre de Talla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    tb_pt_tallaBL BL = new tb_pt_tallaBL();
                    tb_pt_talla BE = new tb_pt_talla();
                 
                    BE.tallaid = tallaid.Text.Trim().PadLeft(2, '0');
                    BE.tallaname = tallaname.Text.ToUpper();
                    BE.talla01 = talla01.Text;
                    BE.talla02 = talla02.Text;
                    BE.talla03 = talla03.Text;
                    BE.talla04 = talla04.Text;
                    BE.talla05 = talla05.Text;
                    BE.talla06 = talla06.Text;
                    BE.talla07 = talla07.Text;
                    BE.talla08 = talla08.Text;
                    BE.talla09 = talla09.Text;
                    BE.talla10 = talla10.Text;
                    BE.talla11 = talla11.Text;
                    BE.talla12 = talla12.Text;

                    BE.usuar = VariablesPublicas.Usuar.Trim();

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
                if (tallaid.Text.Trim().Length != 2)
                {
                    MessageBox.Show("Falta Codigo Talla !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    tb_pt_tallaBL BL = new tb_pt_tallaBL();
                    tb_pt_talla BE = new tb_pt_talla();
                  
                    BE.tallaid = tallaid.Text.Trim().PadLeft(2, '0');
                    //BE.tallaname = tallaname.Text.ToUpper();
                    //BE.usuar = VariablesPublicas.Usuar.Trim();

                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos Eliminado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        limpiar_documento();
                        form_bloqueado(false);
                        data_Tablatalla();
                        btn_nuevo.Enabled = true;
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

        private void Frm_talla_Load(object sender, EventArgs e)
        {
            if (this.Parent.Parent.Name == "MainProduccion")
            {
                modulo = ((D70Produccion.MainProduccion)MdiParent).moduloid;
                local = ((D70Produccion.MainProduccion)MdiParent).local;
                PERFILID = ((D70Produccion.MainProduccion)MdiParent).perfil;
            }

            if (this.Parent.Parent.Name == "MainMercaderia02")
            {
                modulo = ((MERCADERIA02.MainMercaderia02)MdiParent).moduloid;
                local = ((MERCADERIA02.MainMercaderia02)MdiParent).local;
                PERFILID = ((MERCADERIA02.MainMercaderia02)MdiParent).perfil;
            }
            NIVEL_FORMS();

            data_cbo_buscar();
            Tablatalla = new DataTable();

            limpiar_documento();
            data_Tablatalla();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_primero.Enabled = true;
            btn_anterior.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_ultimo.Enabled = true;
            btn_salir.Enabled = true;
        }
        private void Frm_talla_KeyDown(object sender, KeyEventArgs e)
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
             
        
        private void tallaid_LostFocus(object sender, System.EventArgs e)
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
                tallaname.Focus();

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
                data_Tablatalla();
                form_bloqueado(false);
                tallaid.Text = "NN";

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
                if (Tablatalla.Rows.Count > 0)
                {
                    //REPORTES.Frm_reportes miForma = new REPORTES.Frm_reportes();

                    //miForma.dominioid = dominio.Trim();
                    //miForma.moduloid = modulo.Trim();
                    //miForma.local = local.Trim();

                    //miForma.Text = "Reporte de tallas";
                    //miForma.formulario = "Frm_talla";
                    //miForma.ShowDialog();
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
            String xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio;
            oform._Nombre = Name;
            oform._ClaveForm = xclave;
            oform.Owner = this;
            oform.ShowDialog();
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region $$$ grid talla
        private void data_Tablatalla()
        {
            try
            {
                if (Tablatalla.Rows.Count > 0)
                    Tablatalla.Rows.Clear();
                tb_pt_tallaBL BL = new tb_pt_tallaBL();
                tb_pt_talla BE = new tb_pt_talla();

                switch (cbo_buscar.SelectedIndex)
                {
                    case 0:
                        BE.tallaname = txt_criterio.Text.Trim();
                        break;
                    case 1:
                        if (txt_criterio.Text.Trim().Length > 0)
                        {
                            BE.tallaid = txt_criterio.Text.Trim().ToUpper().PadLeft(2, '0');
                        }
                        break;                    
                    default:
                        //**
                        break;
                }
            
                Tablatalla = BL.GetAll(EmpresaID, BE).Tables[0];
                if (Tablatalla.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    gridtalla.DataSource = Tablatalla;
                    gridtalla.Rows[0].Selected = false;
                    gridtalla.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridtalla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridtalla.CurrentRow != null)
                {
                    String xtallaid = "";
                    xtallaid = gridtalla.Rows[e.RowIndex].Cells["gtallaid"].Value.ToString().Trim();
                    data_talla(xtallaid);
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void gridtalla_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                String xtallaid = "";
                xtallaid = gridtalla.Rows[gridtalla.CurrentRow.Index].Cells["gtallaid"].Value.ToString().Trim();
                data_talla(xtallaid);
            }
        }
        private void gridtalla_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridtalla[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            gridtalla[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            gridtalla.EnableHeadersVisualStyles = false;
            gridtalla.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            gridtalla.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);

        }
        private void gridtalla_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            gridtalla[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }
        private void data_talla(String xtallaid)
        {
            form_bloqueado(false);
            DataRow[] rowtallaid = Tablatalla.Select("tallaid='" + xtallaid + "'");
            if (rowtallaid.Length > 0)
            {
                foreach (DataRow row in rowtallaid)
                {
                    tallaid.Text = row["tallaid"].ToString().Trim();
                    tallaname.Text = row["tallaname"].ToString().Trim();
                    talla01.Text = row["talla01"].ToString().Trim();
                    talla02.Text = row["talla02"].ToString().Trim();
                    talla03.Text = row["talla03"].ToString().Trim();
                    talla04.Text = row["talla04"].ToString().Trim();
                    talla05.Text = row["talla05"].ToString().Trim();
                    talla06.Text = row["talla06"].ToString().Trim();
                    talla07.Text = row["talla07"].ToString().Trim();
                    talla08.Text = row["talla08"].ToString().Trim();
                    talla09.Text = row["talla09"].ToString().Trim();
                    talla10.Text = row["talla10"].ToString().Trim();
                    talla11.Text = row["talla11"].ToString().Trim();
                    talla12.Text = row["talla12"].ToString().Trim();
                }

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
        #endregion

        #region $$$ busqueda
        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            data_Tablatalla();
        }
        #endregion

        private void txt_criterio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_busqueda_Click(sender, e);
            }
        }

        #endregion

        private void talla01_TextChanged(object sender, EventArgs e)
        {
            if (talla01.Text.Length == 2)
            {
                talla02.Focus();
                talla02.SelectionStart = 0;
                talla02.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void talla02_TextChanged(object sender, EventArgs e)
        {
            if (talla02.Text.Length == 2) { 
                talla03.Focus();
                talla03.SelectionStart = 0;
                talla03.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void talla03_TextChanged(object sender, EventArgs e)
        {
            if (talla03.Text.Length == 2) { 
                talla04.Focus();
                talla04.SelectionStart = 0;
                talla04.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void talla04_TextChanged(object sender, EventArgs e)
        {
            if (talla04.Text.Length == 2) { 
                talla05.Focus();
                talla05.SelectionStart = 0;
                talla05.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void talla05_TextChanged(object sender, EventArgs e)
        {
            if (talla05.Text.Length == 2) { 
                talla06.Focus();
                talla06.SelectionStart = 0;
                talla06.SelectionLength = ActiveControl.Text.Length;
            
            }
        }

        private void talla06_TextChanged(object sender, EventArgs e)
        {
            if (talla06.Text.Length == 2) { 
                talla07.Focus();
                talla07.SelectionStart = 0;
                talla07.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void talla07_TextChanged(object sender, EventArgs e)
        {
            if (talla07.Text.Length == 2) { 
                talla08.Focus();
                talla08.SelectionStart = 0;
                talla08.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void talla08_TextChanged(object sender, EventArgs e)
        {
            if (talla08.Text.Length == 2) { 
                talla09.Focus();
                talla09.SelectionStart = 0;
                talla09.SelectionLength = ActiveControl.Text.Length;            
            }
        }

        private void talla09_TextChanged(object sender, EventArgs e)
        {
            if (talla09.Text.Length == 2) { 
                talla10.Focus();
                talla10.SelectionStart = 0;
                talla10.SelectionLength = ActiveControl.Text.Length;  
            }
        }

        private void talla10_TextChanged(object sender, EventArgs e)
        {
            if (talla10.Text.Length == 2) { 
                talla11.Focus();
                talla11.SelectionStart = 0;
                talla11.SelectionLength = ActiveControl.Text.Length;  
            }
        }

        private void talla11_TextChanged(object sender, EventArgs e)
        {
            if (talla11.Text.Length == 2) { 
                talla12.Focus();
                talla12.SelectionStart = 0;
                talla12.SelectionLength = ActiveControl.Text.Length;  
            }
        }

        private void tallaname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { 
                talla01.Focus();
                talla01.SelectionStart = 0;
                talla01.SelectionLength = ActiveControl.Text.Length;  
            }

        }

    }
}