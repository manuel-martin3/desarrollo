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
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection; //para el valor missing
using System.IO;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.Net.Sockets;

namespace BapFormulariosNet.MERCADERIA02.CATALOGO
{
    public partial class Frm_modelo : plantilla
    {
        /*** variables de cabecera del documento actual ***/
        String EmpresaID = VariablesPublicas.EmpresaID;
        String dominio = VariablesPublicas.Dominioid;
        String modulo = "";
        String local = "";
        String perianio = "";
        String perimes = "";

        String XNIVEL = "";
        String XGLOSA = "";
        String PERFILID = "";

        DataTable Tablamodelo;

        Boolean fechadocedit = false;
        Boolean procesado = false;
        Boolean statusDoc = true;

        String ssModo = "NEW";

        public Frm_modelo()
        {
            InitializeComponent();     
        }

        #region $$$ ADMINISTRADOR
        private void PARAMETROS_TABLA()
        {
            //String xxferfil = "";
            //MainProduccion f = (MainProduccion)this.MdiParent;
            //xxferfil = f.perfil.ToString();
            //if (xxferfil.Trim().Length != 9)
            //{
            //    MessageBox.Show("::: NO TIENE PERFIL !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //PERFILID = xxferfil;
            
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
                modeloid.Enabled = false;
                modeloname.Enabled = var;
                modelodescort.Enabled = var;

                gridmodelo.ReadOnly = true;
                gridmodelo.Enabled = !var;
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
                modeloid.Text = "NNNN";
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
                tb_pt_modeloBL BL = new tb_pt_modeloBL();
                tb_pt_modelo BE = new tb_pt_modelo();
                DataTable dt = new DataTable();
      
                if (modeloid.Text.Trim().Length > 0)
                {
                    BE.modeloid = modeloid.Text.Trim().PadLeft(4, '0');
                }
                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    limpiar_documento();
                    ssModo = "EDIT";

                    modeloid.Text = dt.Rows[0]["modeloid"].ToString().Trim();
                    modeloname.Text = dt.Rows[0]["modeloname"].ToString().Trim();                    
                    modelodescort.Text = dt.Rows[0]["modelodescort"].ToString().Trim();

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
                BE.detalle = modeloid.Text.Trim() + "/" + modeloname.Text.Trim().ToUpper()  + "/" + XGLOSA;

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
                modeloid.Text = "";
                modeloname.Text = "";
                modelodescort.Text = "";

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
            modeloname.Focus();

            ssModo = "NEW";
        }

        private void Insert()
        {
            try
            {
                if (modeloname.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese nombre de Modelo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    tb_pt_modeloBL BL = new tb_pt_modeloBL();
                    tb_pt_modelo BE = new tb_pt_modelo();

                    BE.modeloid = modeloid.Text.Trim().PadLeft(4, '0');
                    BE.modeloname = modeloname.Text.ToUpper().ToUpper();
                    BE.modelodescort = modelodescort.Text.ToUpper();
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
                if (modeloid.Text.Trim().Length != 4)
                {
                    MessageBox.Show("Falta Codigo Modelo !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (modeloname.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Nombre de Modelo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    tb_pt_modeloBL BL = new tb_pt_modeloBL();
                    tb_pt_modelo BE = new tb_pt_modelo();

                    BE.modeloid = modeloid.Text.Trim().PadLeft(4, '0');
                    BE.modeloname = modeloname.Text.ToUpper();                    
                    BE.modelodescort = modelodescort.Text.ToUpper();
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
                if (modeloid.Text.Trim().Length != 4)
                {
                    MessageBox.Show("Falta Codigo Modelo !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    tb_pt_modeloBL BL = new tb_pt_modeloBL();
                    tb_pt_modelo BE = new tb_pt_modelo();
                    //BE.moduloid = modulo;
                    BE.modeloid = modeloid.Text.Trim().PadLeft(4, '0');
                    //BE.modeloname = modeloname.Text.ToUpper();
                    //BE.modeloidold = modeloidold.Text;
                    //BE.usuar = VariablesPublicas.Usuar.Trim();

                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos Eliminados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        form_bloqueado(false);
                        data_Tablamodelo();
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

        private void Frm_modelo_Load(object sender, EventArgs e)
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
            Tablamodelo = new DataTable();

            modeloname.CharacterCasing = CharacterCasing.Upper;
            data_Tablamodelo();
            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_primero.Enabled = true;
            btn_anterior.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_ultimo.Enabled = true;
            btn_salir.Enabled = true;
        }

        private void Frm_modelo_KeyDown(object sender, KeyEventArgs e)
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

        private void modeloid_LostFocus(object sender, System.EventArgs e)
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
            if (XNIVEL == "0")
            {
                ssModo = "EDIT";
                form_bloqueado(true);
                modeloname.Focus();

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
                data_Tablamodelo();
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
                bool sw_prosigue = false;
                sw_prosigue = (MessageBox.Show("¿Desea Eliminar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                if (sw_prosigue)
                {
                    Delete();
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

        #region $$$ grid modelo
        private void data_Tablamodelo()
        {
            try
            {
                if (Tablamodelo.Rows.Count > 0)
                    Tablamodelo.Rows.Clear();
                tb_pt_modeloBL BL = new tb_pt_modeloBL();
                tb_pt_modelo BE = new tb_pt_modelo();

                //BE.moduloid = modulo;
                BE.modeloname = txt_criterio.Text.Trim().ToUpper();

                Tablamodelo = BL.GetAll(EmpresaID, BE).Tables[0];
                if (Tablamodelo.Rows.Count > 0)
                {
                    btn_excel.Enabled = true;
                    gridmodelo.DataSource = Tablamodelo;
                    gridmodelo.Rows[0].Selected = false;
                    gridmodelo.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridmodelo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridmodelo.CurrentRow != null)
                {
                    String xmodeloid = "";
                    xmodeloid = gridmodelo.Rows[e.RowIndex].Cells["gmodeloid"].Value.ToString().Trim();
                    data_modelo(xmodeloid);
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void gridmodelo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                String xmodeloid = "";
                xmodeloid = gridmodelo.Rows[gridmodelo.CurrentRow.Index].Cells["gmodeloid"].Value.ToString().Trim();
                data_modelo(xmodeloid);
            }
        }

        private void gridmodelo_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridmodelo[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            gridmodelo[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            gridmodelo.EnableHeadersVisualStyles = false;
            gridmodelo.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            gridmodelo.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void gridmodelo_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            gridmodelo[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }

        private void data_modelo(String xmodeloid)
        {
            form_bloqueado(false);
            DataRow[] rowmodeloid = Tablamodelo.Select("modeloid='" + xmodeloid + "'");
            if (rowmodeloid.Length > 0)
            {
                foreach (DataRow row in rowmodeloid)
                {
                    modeloid.Text = row["modeloid"].ToString().Trim();
                    modeloname.Text = row["modeloname"].ToString().Trim();                  
                    modelodescort.Text = row["modelodescort"].ToString().Trim();
         
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

        #endregion

        #region $$$ busqueda
        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            data_Tablamodelo();
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

        private void btn_excel_Click(object sender, EventArgs e)
        {
            if (Tablamodelo.Rows.Count > 0)
            { ExportarExcel(Tablamodelo); }
            else { MessageBox.Show(" ... Falta Obtener los Modelos ... ", "Information"); }
        }

        private void ExportarExcel(DataTable TablapromoDet)
        {
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;

            try
            {
                //Start Excel and get Application object.
                oXL = new Excel.Application();
                oXL.Visible = false;

                //Get a new workbook.
                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;


                //**************************** Para Poner Cabeceras Automaticamente
                //int IndiceColumna = 0;
                //// Primero Cargaremos las Cabeceras Desde el DataGridView
                //foreach (DataGridViewColumn col in dgb_listaPrecios.Columns)
                //{
                //    //Add table headers going cell by cell.
                //    IndiceColumna++;
                //    oSheet.Cells[1, IndiceColumna] = col.HeaderText; 
                //    // Le ponemos HederText porque ahi Personalizamos el Nombre Visual
                //}

                // Primero Cargaremos las Cabeceras Estaticas
                oSheet.Cells[1, 1] = "CODIDO";
                oSheet.Cells[1, 2] = "MODELO";
                oSheet.Cells[1, 3] = "DESC-CORTA";       

                oSheet.get_Range("A1", "C1").Font.Bold = true;
                oSheet.get_Range("A1", "C1").Font.Color = Color.White;
                oSheet.get_Range("A1", "C1").Interior.ColorIndex = 14; // 14 = Teal
                oSheet.get_Range("A1", "C1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                int IndiceFila = 2;
                //oSheet.Range["D:D"].NumberFormat = "dd/mm/yyyy";
                oSheet.Range["A:C"].NumberFormat = "@";
                //oSheet.Range["D:E"].NumberFormat = "_ * #,##0.00_ ;_ * -#,##0.00_ ;_ * -??_ ;_ @_ ";

                foreach (DataRow row in TablapromoDet.Rows)
                {
                    oSheet.Cells[IndiceFila, 01].Value = row["modeloid"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 02].Value = row["modeloname"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 03].Value = row["modelodescort"].ToString().Trim();

                    IndiceFila++;
                }

                //AutoFit columns A:F.
                oRng = oSheet.get_Range("A1", "C1");
                oRng.EntireColumn.AutoFit();

                //Inmoviliza Paneles
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