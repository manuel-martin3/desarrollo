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

namespace BapFormulariosNet.MERCADERIA
{
    public partial class Frm_reporte_TomaInventario : plantilla
    {
        /*** variables de cabecera del documento actual ***/
        String EmpresaID = "";
        String dominio = "60";
        String modulo = "";
        String local = "";
        String perianio = "";
        String perimes = "";

        String PERFILID = "";

        Boolean fechadocedit = false;
        Boolean procesado = false;
        Boolean statusDoc = true;

        String ssModo = "NEW";

        public Frm_reporte_TomaInventario()
        {
            InitializeComponent();
            lineaid.LostFocus += new System.EventHandler(lineaid_LostFocus);                      
        }

        #region $$$ ADMINISTRADOR
        private void PARAMETROS_TABLA()
        {
            String xxferfil = "";
            MainMercaderia f = (MainMercaderia)this.MdiParent;
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
                lineaid.Enabled = var;
                lineaname.Enabled = false;
                //fechdocini.Enabled = var;
                //fechdocfin.Enabled = var;
                      
                btn_nuevo.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_imprimir.Enabled = false;
                btn_excel.Enabled = false;
                btn_buscar.Enabled = false;
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
                btn_buscar.Enabled = true;
                btn_salir.Enabled = true;

                ssModo = "NEW";
            }
        }
        
        private void ValidaLinea()
        {
            if (lineaid.Text.Trim().Length > 0)
            {
                tb_60lineaBL BL = new tb_60lineaBL();
                tb_60linea BE = new tb_60linea();
                DataTable dt = new DataTable();

                BE.moduloid = modulo;
                BE.lineaid = lineaid.Text.Trim().PadLeft(3, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    lineaid.Text = dt.Rows[0]["lineaid"].ToString().Trim();
                    lineaname.Text = dt.Rows[0]["lineaname"].ToString().Trim();
                }
                else
                {
                    lineaid.Text = "";
                    lineaname.Text = "";
                }
            }
            else
            {
                lineaid.Text = "";
                lineaname.Text = "";
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

        private void AyudaLinea(String lpdescrlike)
        {
            try
            {
                String modd = "";
                sys_moduloBL BL = new sys_moduloBL();
                tb_sys_modulo BE = new tb_sys_modulo();
                DataTable dt = new DataTable();

                BE.dominioid = dominio;
                BE.moduloid = modulo;
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();

                        Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                        frmayuda.tipoo = "sql"; //sql,tabla
                        frmayuda.titulo = "<< AYUDA  TABLA LINEA >>";
                        frmayuda.sqlquery = "SELECT lineaid, lineaname FROM tb_" + modd + "_linea ";
                        frmayuda.sqlinner = ""; //inner
                        frmayuda.sqlwhere = "where"; //where
                        frmayuda.sqland = "";//and
                        frmayuda.criteriosbusqueda = new string[] { "LINEA", "CODIGO" };
                        frmayuda.columbusqueda = "lineaname,lineaid";
                        frmayuda.returndatos = "0,1";

                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeLinea;
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void RecibeLinea(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                lineaid.Text = resultado1.Trim();
                lineaname.Text = resultado2.Trim();
            }
        }        
        
        #endregion

      
        private void limpiar_documento()
        {
            try
            {                
                lineaname.Text = "";               
                lineaid.Text = "";
                lineaname.Text = "";
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
            btn_excel.Enabled = true;
            btn_cancelar.Enabled = true;
            lineaid.Focus();

            ssModo = "NEW";
        }
               
        private void Frm_reporte_stockrollo_Load(object sender, EventArgs e)
        {
            EmpresaID = VariablesPublicas.EmpresaID;
            //modulo = VariablesPublicas.Moduloid.Trim();
            //local = VariablesPublicas.Local.Trim();
            PARAMETROS_TABLA();

            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_buscar.Enabled = true;
            btn_salir.Enabled = true;
        }

       
        private void lineaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaLinea("");
            }
        }
        private void lineaid_LostFocus(object sender, System.EventArgs e)
        {
            ValidaLinea();
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
            #region -- Primera Forma
            //try
            //{
            //    REPORTES.Frm_reportes miForma = new REPORTES.Frm_reportes();
            //    miForma.Text = "Toma de Inventario : Linea";
            //    miForma.dominioid = dominio.Trim();
            //    miForma.moduloid = modulo.Trim();
            //    miForma.local = local.Trim();
            //    miForma.lineaid = lineaid.Text.Trim();
            //    miForma.formulario = "Frm_reporte_tomainventario";
            //    miForma.Show();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            #endregion

            ImpresionTomaInv();
        }

        private void ImpresionTomaInv() {

            DataTable tablaReport = new DataTable();
            tb_60local_stockBL BL = new tb_60local_stockBL();
            tb_60local_stock BE = new tb_60local_stock();

            BE.moduloid = VariablesPublicas.Moduloid;
            BE.local = VariablesPublicas.Local;
            BE.lineaid = lineaid.Text.Trim();
            BE.status = chkTodos.Checked ? "1" : "0";

            tablaReport = BL.GetAll_productostock(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];            
            if (tablaReport.Rows.Count == 0)
            {
                MessageBox.Show("No existe Información Procesada", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Frm_Reportes miForma = new Frm_Reportes();
                REPORTES.CR_tomainventario reporteInventario = new REPORTES.CR_tomainventario();
                miForma.Text = "Toma de Inventario : Linea";
                reporteInventario.DataDefinition.FormulaFields["almacen"].Text = "'" + VariablesPublicas.EmpresaTipo + "'";                
                reporteInventario.DataDefinition.FormulaFields["name"].Text = "'TIENDA : " + VariablesPublicas.Local + "  - " + VariablesPublicas.nombrelocal + "'";
                #region -- Commentado
                //reporteInventario.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                //reporteInventario.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";

                //variables que vamos a modificar
                //reporteRollokardex.DataDefinition.FormulaFields["fechdoc"].Text = "'DE: " + fechdocini.Trim().Substring(0, 10) + "  AL:" + fechdocfin.Trim().Substring(0, 10) + "'";

               //reporteInventario.SetDataSource(tablaReport);
               // miForma.Reporte.ReportSource = reporteInventario;            

                //reporte.PrintOptions.PrinterName = "EPSON LQ-590 ESC/P2";
                //reporte.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                //reporte.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)GetPaperSize("EPSON LQ-590 ESC/P2", "cretencion");

                //reporte.SetDataSource(tablaReport);               
                //reporte.Refresh();
                //reporte.PrintToPrinter(1, false, 0, 0);
                #endregion

                miForma.Table = tablaReport;
                miForma.Reporte = reporteInventario;    
                miForma.Show();
            }
        }



        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {

        }               

    }
}