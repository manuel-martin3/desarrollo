using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using bapFunciones;
using LayerBusinessEntities;
using LayerBusinessLogic;


namespace BapFormulariosNet.D60ALMACEN
{
    public partial class Frm_reporte_consumo : plantilla
    {
        /*** variables de cabecera del documento actual ***/
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = "";
        private String local = "";   

        String moduloiddes = "";
        List<tb_perianio>lista =null;
        DataTable []ta;
        
        String dominioiddes = "60";
        
        public Frm_reporte_consumo()
        {
            InitializeComponent();
        }

        private void Frm_reporte_ordcompra_Load(object sender, EventArgs e)
        {

            moduloiddes = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;

            modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
            local = ((D60ALMACEN.MainAlmacen)MdiParent).local; 
            /* Restricciones Para Cada Almacen Tipo de Reporte
                * and Fijando el Modulo Por Almacen 
                */

            limpiar_documento();
            form_bloqueado(false);
            data_cbo_moduloiddes();
            cbomodulo.SelectedValue = modulo;
            cbomodulo.Enabled = false;
            llenarComboMesini();
            llenarComboMesfin();
            combo_anio();

            procedenciaid.Items.Clear();
            procedenciaid.Items.AddRange("Todos,Nacional,Importado".Split(new char[] { ',' }));
            procedenciaid.SelectedIndex = 0;
                       
        }


        #region "combo_anio"
        private void combo_anio() 
        {            
            tb_perianioBL BL= new tb_perianioBL();
            lista = BL.Get_anio(EmpresaID);
            cboanio.DataSource = lista;
            cboanio.DisplayMember = "perianio";
            cboanio.ValueMember = "codigo";
        }
        #endregion

        #region Llenar Combo_MesesIni
        private void llenarComboMesini()
        {
            List<Item> lista = new List<Item>();

            lista.Add(new Item("Enero", 01));
            lista.Add(new Item("Febrero", 02));
            lista.Add(new Item("Marzo", 03));
            lista.Add(new Item("Abril", 04));
            lista.Add(new Item("Mayo", 05));
            lista.Add(new Item("Junio", 06));
            lista.Add(new Item("Julio", 07));
            lista.Add(new Item("Agosto", 08));
            lista.Add(new Item("Setiembre", 09));
            lista.Add(new Item("Octubre", 10));
            lista.Add(new Item("Noviembre", 11));
            lista.Add(new Item("Diciembre", 12));

            cboMesini.DisplayMember = "Name";
            cboMesini.ValueMember = "Value";
            cboMesini.DataSource = lista;
        }
        #endregion

        #region Llenar Combo_MeseFin
        private void llenarComboMesfin()
        {
            List<Item> lista = new List<Item>();

            lista.Add(new Item("Enero", 01));
            lista.Add(new Item("Febrero", 02));
            lista.Add(new Item("Marzo", 03));
            lista.Add(new Item("Abril", 04));
            lista.Add(new Item("Mayo", 05));
            lista.Add(new Item("Junio", 06));
            lista.Add(new Item("Julio", 07));
            lista.Add(new Item("Agosto", 08));
            lista.Add(new Item("Setiembre", 09));
            lista.Add(new Item("Octubre", 10));
            lista.Add(new Item("Noviembre", 11));
            lista.Add(new Item("Diciembre", 12));

            cboMesfin.DisplayMember = "Name";
            cboMesfin.ValueMember = "Value";
            cboMesfin.DataSource = lista;
        }
        #endregion

        void data_cbo_moduloiddes()
        {
            try
            {
                sys_moduloBL BL = new sys_moduloBL();
                tb_sys_modulo BE = new tb_sys_modulo();
                BE.dominioid = dominioiddes.Trim();
           
                DataTable dt = new DataTable();
          
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                   
                cbomodulo.DataSource = dt;
                cbomodulo.ValueMember = "moduloid";
                cbomodulo.DisplayMember = "moduloname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                REPORTES.Frm_reportes miForma = new REPORTES.Frm_reportes();
                miForma.moduloid = cbomodulo.SelectedValue.ToString();

                miForma.Peranio = cboanio.Text.ToString();

                Int32 mes1 = Convert.ToInt32(cboMesini.SelectedValue.ToString());

                if (mes1 < 10)
                {
                    miForma.Mesdoini = "0" + Convert.ToString(cboMesini.SelectedValue.ToString());
                    VariablesPublicas.Perimesini = miForma.Mesdoini;
                }
                else
                {
                    miForma.Mesdoini = Convert.ToString(cboMesini.SelectedValue.ToString());
                    VariablesPublicas.Perimesini = miForma.Mesdoini;
                }

                miForma.procedenciaid = procedenciaid.SelectedIndex.ToString();
                miForma.formulario = Name;
                miForma.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

       
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            if (moduloiddes == "0100")
            {
                nuevo();
            }
            else
            {
                nuevo_Almacenes();
            }
        }
    
        private void nuevo()
        {
            limpiar_documento();
            form_bloqueado(true);
            btn_imprimir.Enabled = true;
            btn_cancelar.Enabled = true;
            //cboanio.Enabled = true;
         }

        private void nuevo_Almacenes()
        {
            limpiar_documento();
            form_bloqueado_Almacen(true);
            btn_imprimir.Enabled = true;
            btn_cancelar.Enabled = true;
            //cboanio.Enabled = true;
        }

        private void limpiar_documento()
        {
            try
            {
               // cboanio.SelectedIndex=-1;                
                if (moduloiddes=="0100")
                {
                    cbomodulo.SelectedIndex = -1;
                }

                cboMesini.SelectedValue = DateTime.Today.Month;
                cboMesfin.SelectedValue = DateTime.Today.Month;
                cboanio.SelectedValue = ((D60ALMACEN.MainAlmacen)MdiParent).perianio;

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
                cboanio.Enabled = false;
                cboMesfin.Enabled = var;
                cboMesini.Enabled = var;
                cbomodulo.Enabled = false;               


                btn_cancelar.Enabled = false;
                btn_imprimir.Enabled = false;
                btn_salir.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void form_bloqueado_Almacen(Boolean var)
        {
            try
            {

                cboanio.Enabled = false;
                cboMesfin.Enabled = var;
                cboMesini.Enabled = var;
                cbomodulo.Enabled = false;  

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
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            form_accion_cancelEdicion(1);
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Validar_Combos()
        {

            int mes1, mes2;
            mes1 = Convert.ToInt32(cboMesini.SelectedValue);
            mes2 = Convert.ToInt32(cboMesfin.SelectedValue);

            if (mes1 == mes2)
            {
                Mes_Actual();
                mes_final();
            }
            else
            {
                Mes_Actual();
                mes_final();
            }

        }


        #region _Mes _Inicial_Nombre
        private void Mes_Actual()
        {

            int mes = 0;
            String nmes = "";
            mes = Convert.ToInt32(cboMesini.SelectedValue);
            switch (mes)
            {
                case 1: nmes = "Enero"; break;
                case 2: nmes = "Febrero"; break;
                case 3: nmes = "Marzo"; break;
                case 4: nmes = "Abril"; break;
                case 5: nmes = "Mayo"; break;
                case 6: nmes = "Junio"; break;
                case 7: nmes = "Julio"; break;
                case 8: nmes = "Agosto"; break;
                case 9: nmes = "Setiembre"; break;
                case 10: nmes = "Octubre"; break;
                case 11: nmes = "Noviembre"; break;
                default: nmes = "Diciembre"; break;
            }
            VariablesPublicas.N_PrimerMes1 = nmes;
           
        }
        #endregion

        #region _Mes _Final _Nombre
        private void mes_final()
        {

            int mes = 0;
            String nmes = "";
            mes = Convert.ToInt32(cboMesfin.SelectedValue);
            switch (mes)
            {
                case 1: nmes = "Enero"; break;
                case 2: nmes = "Febrero"; break;
                case 3: nmes = "Marzo"; break;
                case 4: nmes = "Abril"; break;
                case 5: nmes = "Mayo"; break;
                case 6: nmes = "Junio"; break;
                case 7: nmes = "Julio"; break;
                case 8: nmes = "Agosto"; break;
                case 9: nmes = "Setiembre"; break;
                case 10: nmes = "Octubre"; break;
                case 11: nmes = "Noviembre"; break;
                default: nmes = "Diciembre"; break;
            }
            VariablesPublicas.N_FinMes1 = nmes;
        }

        #endregion




    }
}
