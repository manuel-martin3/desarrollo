using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace BapFormulariosNet.D60Tienda.Administracion
{
    public partial class Frm_orden_produccion : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;


        private DataTable TablaOrdenProdCab;
        private DataTable TablaOrdenProdColor;
        private DataTable TablaOrdenProdProp;
        private DataTable TablaOrdenProdFase;
        
        
        DataTable TablaGrilla;   
        private String xarticid = "";
        private DataRow row;
        private Boolean procesado = false;
        private String ActCtacte = "";
        
        private String ssModo = string.Empty;
        private String ssModoII = "";

        public Frm_orden_produccion()
        {
            InitializeComponent();
        }      

        private void Frm_orden_produccion_Load(object sender, EventArgs e)
        {           
            if (Parent.Parent.Name == "MainProduccion")
            {
                modulo = ((D70Produccion.MainProduccion)MdiParent).moduloid;
                local = ((D70Produccion.MainProduccion)MdiParent).local;
                PERFILID = ((D70Produccion.MainProduccion)MdiParent).perfil;
            }

            if (Parent.Parent.Name == "MainTienda")
            {
                modulo = ((D60Tienda.MainTienda)MdiParent).moduloid;
                local = ((D60Tienda.MainTienda)MdiParent).local;
                PERFILID = ((D60Tienda.MainTienda)MdiParent).perfil;
            }

            //PARAMETROS_TABLA();

            NIVEL_FORMS();

            #region Panel Busqueda
            CargarAnio2();
            CargarSerieOP2();
            CargarCmbMarca();
            CargarCmbLinea();
            CargarEstado2();
            #endregion

            #region Panel Datos
            CargarAnio();
            CargarSerieOP();
            CargarEstado();           
            CargarEjecutor();
            CargarCmbCanalVta();
            CargarFase();
            #endregion      

            TmpOrdenProdColor();
            TmpOrdenProdFase();
            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_salir.Enabled = true;
            
            ArmaGrilla();
            TmpOrdenProdCab();
            DataOrdenProduccion();
        }

        // CARGAMOS LAS ORDENES DE PRODUCCION EMITIDAS        




        #region Cargamos los Combos de Inicio

        void CargarCmbCanalVta()
        {
            tb_cp_canalventaBL BL = new tb_cp_canalventaBL();
            tb_cp_canalventa BE = new tb_cp_canalventa();
            DataTable dt = new DataTable();
            BE.digitos = 3;
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cmb_canalvta.DataSource = dt;
                cmb_canalvta.ValueMember = "canalventaid";
                cmb_canalvta.DisplayMember = "canalventaname";
                cmb_canalvta.SelectedIndex = -1;
            }
        }

        void CargarCmbMarca()
        {
            tb_pt_marcaBL BL = new tb_pt_marcaBL();
            tb_pt_marca BE = new tb_pt_marca();
            DataTable dt = new DataTable();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cmb_marca01.DataSource = dt;
                cmb_marca01.ValueMember = "marcaid";
                cmb_marca01.DisplayMember = "marcaname";
                cmb_marca01.SelectedIndex = -1;
            }
        }

        void CargarCmbLinea()
        {
            tb_pt_lineaBL BL = new tb_pt_lineaBL();
            tb_pt_linea BE = new tb_pt_linea();
            DataTable dt = new DataTable();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cmb_linea01.DataSource = dt;
                cmb_linea01.ValueMember = "lineaid";
                cmb_linea01.DisplayMember = "lineaname";
                cmb_linea01.SelectedIndex = -1;
            }
        }

        void CargarAnio()
        {
            var BL = new tb_perianioBL();
            List<tb_perianio> LISTA = null;
            LISTA = BL.Get_anio(EmpresaID);
            cmb_perianio.DataSource = LISTA;
            cmb_perianio.DisplayMember = "perianio";
            cmb_perianio.ValueMember = "codigo";
            cmb_perianio.SelectedIndex = -1;
        }

        void CargarAnio2()
        {
            var BL = new tb_perianioBL();
            List<tb_perianio> LISTA = null;
            LISTA = BL.Get_anio(EmpresaID);
            cmb_anio01.DataSource = LISTA;
            cmb_anio01.DisplayMember = "perianio";
            cmb_anio01.ValueMember = "codigo";
            cmb_anio01.SelectedIndex = -1;
        }

        void CargarSerieOP()
        {
            tb_pp_ordenserieBL BL = new tb_pp_ordenserieBL();
            tb_pp_ordenserie BE = new tb_pp_ordenserie();
            DataTable dt = new DataTable();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            cmb_ordprod.DataSource = dt;
            cmb_ordprod.ValueMember = "perianio";
            cmb_ordprod.DisplayMember = "ser_op";
        }

        void CargarSerieOP2()
        {
            tb_pp_ordenserieBL BL = new tb_pp_ordenserieBL();
            tb_pp_ordenserie BE = new tb_pp_ordenserie();
            DataTable dt = new DataTable();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            cmb_serie01.DataSource = dt;
            cmb_serie01.ValueMember = "perianio";
            cmb_serie01.DisplayMember = "ser_op";
        }

        void CargarEstado()
        {
            tb_estadoBL BL = new tb_estadoBL();
            tb_estado BE = new tb_estado();
            DataTable dt = new DataTable();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            cmb_estado.DataSource = dt;
            cmb_estado.ValueMember = "estado";
            cmb_estado.DisplayMember = "estadoname";
        }

        void CargarEstado2()
        {
            tb_estadoBL BL = new tb_estadoBL();
            tb_estado BE = new tb_estado();
            DataTable dt = new DataTable();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            cmb_estado01.DataSource = dt;
            cmb_estado01.ValueMember = "estado";
            cmb_estado01.DisplayMember = "estadoname";
        }

        void CargarEjecutor()
        {
            tb_pp_ejecutorBL BL = new tb_pp_ejecutorBL();
            tb_pp_ejecutor BE = new tb_pp_ejecutor();
            DataTable dt = new DataTable();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            cmb_ejecutor.DataSource = dt;
            cmb_ejecutor.ValueMember = "ejecutorid";
            cmb_ejecutor.DisplayMember = "ejecutorname";
        }

        void CargarFase()
        {
            tb_pp_faseBL BL = new tb_pp_faseBL();
            tb_pp_fase BE = new tb_pp_fase();
            DataTable dt = new DataTable();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cmb_fase.DataSource = dt;
                cmb_fase.ValueMember = "faseid";
                cmb_fase.DisplayMember = "fasename";
                cmb_fase.SelectedIndex = 0;
            }
                 
        }


        #endregion


        void TmpOrdenProdCab()
        {
            TablaOrdenProdCab = new DataTable();
            TablaOrdenProdCab.Columns.Add("tipop", typeof(String));
            TablaOrdenProdCab.Columns.Add("serop", typeof(String));
            TablaOrdenProdCab.Columns.Add("numop", typeof(String));
            TablaOrdenProdCab.Columns.Add("fechemi", typeof(DateTime));
            TablaOrdenProdCab.Columns.Add("fechini", typeof(DateTime));
            TablaOrdenProdCab.Columns.Add("fechfin", typeof(DateTime));
            TablaOrdenProdCab.Columns.Add("estado", typeof(String));
            TablaOrdenProdCab.Columns.Add("perianio", typeof(String));
            TablaOrdenProdCab.Columns.Add("articid", typeof(String));
            TablaOrdenProdCab.Columns.Add("canalventaid", typeof(String));
            TablaOrdenProdCab.Columns.Add("ctacte", typeof(String));
            TablaOrdenProdCab.Columns.Add("tipref", typeof(String));
            TablaOrdenProdCab.Columns.Add("serref", typeof(String));
            TablaOrdenProdCab.Columns.Add("numref", typeof(String));
            TablaOrdenProdCab.Columns.Add("observacion", typeof(String));
            TablaOrdenProdCab.Columns.Add("cantprog", typeof(Int32));
            TablaOrdenProdCab.Columns.Add("cantreal", typeof(Int32));
            TablaOrdenProdCab.Columns.Add("ejecutorid", typeof(Int32));

            TablaOrdenProdCab.Columns.Add("marcaname", typeof(String));
            TablaOrdenProdCab.Columns.Add("ordenprod", typeof(String));

            TablaOrdenProdCab.Columns.Add("articidold", typeof(String));
            TablaOrdenProdCab.Columns.Add("articname", typeof(String));
            TablaOrdenProdCab.Columns.Add("variante", typeof(String));
            TablaOrdenProdCab.Columns.Add("lineaname", typeof(String));
            TablaOrdenProdCab.Columns.Add("generoname", typeof(String));
            TablaOrdenProdCab.Columns.Add("temporadaname", typeof(String));
            TablaOrdenProdCab.Columns.Add("coleccionname", typeof(String));
            TablaOrdenProdCab.Columns.Add("estadoname", typeof(String));

            TablaOrdenProdCab.Columns.Add("familianame", typeof(String));
            TablaOrdenProdCab.Columns.Add("ctactename", typeof(String));
        }

        void ArmaGrilla()
        {
            TablaGrilla = new DataTable();
            TablaGrilla.Columns.Add("nombre", typeof(String));
            TablaGrilla.Columns.Add("ta01", typeof(Int32));
            TablaGrilla.Columns.Add("ta02", typeof(Int32));
            TablaGrilla.Columns.Add("ta03", typeof(Int32));
            TablaGrilla.Columns.Add("ta04", typeof(Int32));
            TablaGrilla.Columns.Add("ta05", typeof(Int32));
            TablaGrilla.Columns.Add("ta06", typeof(Int32));
            TablaGrilla.Columns.Add("ta07", typeof(Int32));
            TablaGrilla.Columns.Add("ta08", typeof(Int32));
            TablaGrilla.Columns.Add("ta09", typeof(Int32));
            TablaGrilla.Columns.Add("ta10", typeof(Int32));
            TablaGrilla.Columns.Add("ta11", typeof(Int32));
            TablaGrilla.Columns.Add("ta12", typeof(Int32));

            row = TablaGrilla.NewRow();
            row["nombre"] = "1-Proporción";
            row["ta01"] = 0;row["ta02"] = 0;row["ta03"] = 0;row["ta04"] = 0;
            row["ta05"] = 0;row["ta06"] = 0;row["ta07"] = 0;row["ta08"] = 0;
            row["ta09"] = 0; row["ta10"] = 0;row["ta11"] = 0;row["ta12"] = 0;            
            TablaGrilla.Rows.Add(row);

            row = TablaGrilla.NewRow();
            row["nombre"] = "2-Cant.Programada";
            row["ta01"] = 0; row["ta02"] = 0; row["ta03"] = 0; row["ta04"] = 0;
            row["ta05"] = 0; row["ta06"] = 0; row["ta07"] = 0; row["ta08"] = 0;
            row["ta09"] = 0; row["ta10"] = 0; row["ta11"] = 0; row["ta12"] = 0;
            TablaGrilla.Rows.Add(row);

            row = TablaGrilla.NewRow();
            row["nombre"] = "3-Cant.Real";
            row["ta01"] = 0; row["ta02"] = 0; row["ta03"] = 0; row["ta04"] = 0;
            row["ta05"] = 0; row["ta06"] = 0; row["ta07"] = 0; row["ta08"] = 0;
            row["ta09"] = 0; row["ta10"] = 0; row["ta11"] = 0; row["ta12"] = 0;
            TablaGrilla.Rows.Add(row);

            dgv_grilla.DataSource = TablaGrilla;
        }
        
        void TmpOrdenProdColor()
        {                        
            TablaOrdenProdColor = new DataTable();
            TablaOrdenProdColor.Columns.Add("tipop", typeof(String));
            TablaOrdenProdColor.Columns.Add("serop", typeof(String));
            TablaOrdenProdColor.Columns.Add("numop", typeof(String));
            TablaOrdenProdColor.Columns.Add("colorid", typeof(String));
            TablaOrdenProdColor.Columns.Add("colorname", typeof(String));
            TablaOrdenProdColor.Columns.Add("coltalla", typeof(String));
            TablaOrdenProdColor.Columns.Add("can01", typeof(Int32));
            TablaOrdenProdColor.Columns.Add("can02", typeof(Int32));
            TablaOrdenProdColor.Columns.Add("can03", typeof(Int32));
            TablaOrdenProdColor.Columns.Add("can04", typeof(Int32));
            TablaOrdenProdColor.Columns.Add("can05", typeof(Int32));
            TablaOrdenProdColor.Columns.Add("can06", typeof(Int32));
            TablaOrdenProdColor.Columns.Add("can07", typeof(Int32));
            TablaOrdenProdColor.Columns.Add("can08", typeof(Int32));
            TablaOrdenProdColor.Columns.Add("can09", typeof(Int32));
            TablaOrdenProdColor.Columns.Add("can10", typeof(Int32));
            TablaOrdenProdColor.Columns.Add("can11", typeof(Int32));
            TablaOrdenProdColor.Columns.Add("can12", typeof(Int32));
            TablaOrdenProdColor.Columns.Add("cantot", typeof(Int32));           
        }

        void TmpOrdenProdProp()
        {
            TablaOrdenProdProp = new DataTable();
            TablaOrdenProdProp.Columns.Add("tipop", typeof(String));
            TablaOrdenProdProp.Columns.Add("serop", typeof(String));
            TablaOrdenProdProp.Columns.Add("numop", typeof(String));
            TablaOrdenProdProp.Columns.Add("coltalla", typeof(String));
            TablaOrdenProdProp.Columns.Add("proporcion", typeof(Int32));
            TablaOrdenProdProp.Columns.Add("cantprog", typeof(Int32));
            TablaOrdenProdProp.Columns.Add("cantreal", typeof(Int32));
        }

        void TmpOrdenProdFase() 
        {
            TablaOrdenProdFase = new DataTable();
            TablaOrdenProdFase.Columns.Add("tipop", typeof(String));
            TablaOrdenProdFase.Columns.Add("serop", typeof(String));
            TablaOrdenProdFase.Columns.Add("numop", typeof(String));
            TablaOrdenProdFase.Columns.Add("secuencia", typeof(Int32));
            TablaOrdenProdFase.Columns.Add("faseid", typeof(Int32));
            TablaOrdenProdFase.Columns.Add("fasename", typeof(String));
            TablaOrdenProdFase.Columns.Add("ctacte", typeof(String));
            TablaOrdenProdFase.Columns.Add("ctactename", typeof(String));
            TablaOrdenProdFase.Columns.Add("fechprog_ini", typeof(DateTime));            
            TablaOrdenProdFase.Columns.Add("fechprog_fin", typeof(DateTime));            
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
            var XTABLA_PERFIL = string.Empty;
            PERFILID = xxferfil;
            //XTABLA_PERFIL = VariablesPublicas.GET_PARAMETROS_TABLA(xxferfil, Name);
            //PERFILID = VariablesPublicas.GET_PARAMETROS_TABLA(xxferfil, Name);
            //if (XTABLA_PERFIL.Trim().Length > 0 && XTABLA_PERFIL.Trim() != "0")
            //{
            //    if (XTABLA_PERFIL.Trim().Length == 2)
            //    {
            //        dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
            //    }
            //    else
            //    {
            //        if (XTABLA_PERFIL.Trim().Length == 6)
            //        {
            //            dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
            //            modulo = XTABLA_PERFIL.Trim().Substring(2, 4);
            //        }
            //        else
            //        {
            //            if (XTABLA_PERFIL.Trim().Length == 9)
            //            {
            //                dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
            //                modulo = XTABLA_PERFIL.Trim().Substring(2, 4);
            //                local = XTABLA_PERFIL.Trim().Substring(6, 3);
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("::: No puede accede a FORMULARIO. \n::: Es necesario DOMINIO, MODULO Y LOCAL !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        
        private void NIVEL_FORMS()
        {
            XNIVEL = VariablesPublicas.Get_nivelperfil(PERFILID, Name).Substring(0, 1);
            if (XNIVEL != "0")
            {
                btn_clave.Glyph = global::BapFormulariosNet.Properties.Resources.btn_Lock20;
            }
            else
            {
                btn_clave.Glyph = global::BapFormulariosNet.Properties.Resources.btn_Un_Lock20;
            }
        }
       
        private void RecibePermiso(Boolean resultado1, String resultado2)
        {
            if (resultado1)
            {
                XNIVEL = "0";
                XGLOSA = resultado2.Trim();
                btn_clave.Glyph = global::BapFormulariosNet.Properties.Resources.btn_Un_Lock20;
            }
        }

        private void form_bloqueado(Boolean var)
        {
            try
            {
                cmb_ordprod.Enabled = var;

                txt_fechemi.Enabled = var;
                txt_fechini.Enabled = var;
                txt_fechfin.Enabled = var;
                cmb_estado.Enabled = var;                
                cmb_ejecutor.Enabled = var;
                txt_articid.Enabled = var;

                txt_observacion.Enabled = var;
                txt_ctacte.Enabled = var;
                txt_tipref.Enabled = var;
                txt_serref.Enabled = var;
                txt_numref.Enabled = var;

                txt_colorid.Enabled = var;

                dgv_grilla.Enabled = var;
                dgv_ordenprodcolor.Enabled = var;

                //txt_taco01.Enabled = var;
                //txt_taco02.Enabled = var;
                //txt_taco03.Enabled = var;
                //txt_taco04.Enabled = var;
                //txt_taco05.Enabled = var;
                //txt_taco06.Enabled = var;
                //txt_taco07.Enabled = var;
                //txt_taco08.Enabled = var;
                //txt_taco09.Enabled = var;
                //txt_taco10.Enabled = var;
                //txt_taco11.Enabled = var;
                //txt_taco12.Enabled = var;

                btn_nuevo.Enabled = false;
                btn_editar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_grabar.Enabled = false;
                btn_eliminar.Enabled = false;
                btn_imprimir.Enabled = false;               
                btn_clave.Enabled = true;
                btn_log.Enabled = true;
                btn_salir.Enabled = false;

                btn_add.Enabled = var;
                btn_quitar.Enabled = var;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        //protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData /*KeyEventArgs keyData*/)
        //{
        //    if (keyData == Keys.Enter)
        //    {
        //        if (GetNextControl(ActiveControl, true) != null)
        //        {
        //            //keyData.Handled = true;
        //            //MessageBox.Show(ActiveControl.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            //GetNextControl(ActiveControl, true).Focus();
        //            //SendKeys.Send("{TAB}");
        //            SendKeys.Send("\t");
        //            return true;
        //        }
        //    }

        //    return base.ProcessCmdKey(ref msg, keyData);
        //}

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
                //BE.detalle = perianio.Text.Trim() + "/" + cmb_perimes.Text.Trim().ToUpper() + "/" + XGLOSA;

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

                txt_fechemi.Text = DateTime.Today.ToShortDateString();
                txt_fechini.Text = "";
                txt_fechfin.Text = "";
                cmb_estado.SelectedIndex = 0; // Verificar todabia a que estado ponerlo fijo
                cmb_perianio.SelectedIndex = -1; // depende de la serie que le pongamos
                cmb_ejecutor.SelectedIndex = -1;

                txt_articid.Text = "";
                txt_articname.Text = "";
                txt_variante.Text = "";
                txt_marcaname.Text = "";
                txt_lineaname.Text = "";
                txt_generoname.Text = "";
                txt_temporadaname.Text = "";
                txt_familiatelaname.Text = "";

                cmb_canalvta.SelectedIndex = -1;
                txt_observacion.Text = "";
                txt_ctacte.Text = "";
                txt_ctactename.Text = "";
                txt_tipref.Text = "";
                txt_serref.Text = "";
                txt_numref.Text = "";
                txt_cantprog.Text = "0";
                txt_cantreal.Text = "0";

                txt_colorid.Text = "";
                txt_colorname.Text = "";
                txt_taco01.Text = "0";
                txt_taco02.Text = "0";
                txt_taco03.Text = "0";
                txt_taco04.Text = "0";
                txt_taco05.Text = "0";
                txt_taco06.Text = "0";
                txt_taco07.Text = "0";
                txt_taco08.Text = "0";
                txt_taco09.Text = "0";
                txt_taco10.Text = "0";
                txt_taco11.Text = "0";
                txt_taco12.Text = "0";

                txt_tacotot.Text = "";

                txt_tottaco01.Text = "";
                txt_tottaco02.Text = "";
                txt_tottaco03.Text = "";
                txt_tottaco04.Text = "";
                txt_tottaco05.Text = "";
                txt_tottaco06.Text = "";
                txt_tottaco07.Text = "";
                txt_tottaco08.Text = "";
                txt_tottaco09.Text = "";
                txt_tottaco10.Text = "";
                txt_tottaco11.Text = "";
                txt_tottaco12.Text = "";
                txt_tottot.Text = "";

                txt_numop01.Text = "";
                txt_articname01.Text = "";

                //cmb_ordprod.SelectedIndex = -1;
                txt_numop.Text = "__________";

                txt_tipop03.Text = "__";
                txt_serop03.Text = "____";
                txt_numop03.Text = "__________";





                ArmaGrilla();

                if (TablaOrdenProdColor.Rows != null)
                    TablaOrdenProdColor.Clear();

                if (TablaOrdenProdFase.Rows != null)
                    TablaOrdenProdFase.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevo()
        {
            limpiar_documento();
            //form_bloqueado(true);
            xtraTabControl1.SelectedTabPage = tab_02;
            cmb_ordprod.SelectedIndex = -1;
            cmb_ordprod.Enabled = true;

            btn_nuevo.Enabled = false;
            btn_editar.Enabled = false;
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_log.Enabled = true;
            ssModo = "NEW";

            // bloqueamos los tab 
            tab_01.PageEnabled = false;
            tab_03.PageEnabled = false;
        }
       
        private void Insert()
        {
            try
            {
                tb_pp_ordenprodBL BL = new tb_pp_ordenprodBL();
                tb_pp_ordenprod BE = new tb_pp_ordenprod();

                var ItemProp = new tb_pp_ordenprod.ItemProp();
                var ItemColor = new tb_pp_ordenprod.ItemColor();
                var ListaItemsProp = new List<tb_pp_ordenprod.ItemProp>();
                var ListaItemsColor = new List<tb_pp_ordenprod.ItemColor>();

                #region Variables de OrdenProdCab
                BE.tipop = "PP";
                BE.serop = cmb_ordprod.Text;
                BE.numop = txt_numop.Text.Trim().ToString();
                if (txt_fechemi.Text.ToString().Length > 0)
                    BE.fechemi = Convert.ToDateTime(txt_fechemi.Text);
                if (txt_fechini.Text.ToString().Length > 0)
                    BE.fechini = Convert.ToDateTime(txt_fechini.Text);
                if (txt_fechfin.Text.ToString().Length > 0)
                    BE.fechfin = Convert.ToDateTime(txt_fechfin.Text);
                BE.estado = cmb_estado.SelectedValue.ToString();
                BE.perianio = cmb_perianio.SelectedValue.ToString();
                BE.articid = xarticid.ToString();
                BE.canalventaid = cmb_canalvta.SelectedValue.ToString();
                BE.ctacte = txt_ctacte.Text;
                BE.tipref = txt_tipref.Text;
                BE.serref = txt_serref.Text;
                BE.numref = txt_numref.Text;
                BE.observacion = txt_observacion.Text;
                BE.cantprog = Convert.ToInt32(txt_cantprog.Text);
                BE.cantreal = Convert.ToInt32(txt_cantreal.Text);
                BE.ejecutorid = Convert.ToInt32(cmb_ejecutor.SelectedValue.ToString());
                BE.usuar = VariablesPublicas.Usuar.ToUpper().Trim();
                #endregion
                
                if (dgv_grilla.Rows.Count > 0 && dgv_grilla.ColumnCount > 0)
                {                       
                    for (int i = 1; i < dgv_grilla.ColumnCount; i++)
                    {
                        ItemProp = new tb_pp_ordenprod.ItemProp();
                        ItemProp.tipop = "PP";
                        ItemProp.serop = cmb_ordprod.Text;
                        ItemProp.numop = txt_numop.Text;
                        ItemProp.coltalla = i.ToString().PadLeft(2,'0');
                        ItemProp.proporcion = Convert.ToInt32(dgv_grilla.Rows[0].Cells[i].Value.ToString());
                        ItemProp.cantprog = Convert.ToInt32(dgv_grilla.Rows[1].Cells[i].Value.ToString());
                        ItemProp.cantreal = Convert.ToInt32(dgv_grilla.Rows[2].Cells[i].Value.ToString());
                        ListaItemsProp.Add(ItemProp);  
                    }                   
                }
                             
                BE.ListaItemProp = ListaItemsProp;
                
                var num = 1;
                for (int i = 0; i < dgv_ordenprodcolor.RowCount; i++)
                {
                    for (int j = 6; j < dgv_ordenprodcolor.Columns.Count - 1; j++)
                    {
                        ItemColor = new tb_pp_ordenprod.ItemColor();
                        ItemColor.tipop = "PP";
                        ItemColor.serop = cmb_ordprod.Text;
                        ItemColor.numop = txt_numop.Text;
                        ItemColor.colorid = dgv_ordenprodcolor.Rows[i].Cells["colorid"].Value.ToString();
                        ItemColor.coltalla = num.ToString().PadLeft(2, '0');
                        ItemColor.cantidad = Convert.ToInt32(dgv_ordenprodcolor.Rows[i].Cells[j].Value.ToString());
                        ItemColor.status = "0";
                        ItemColor.usuar = VariablesPublicas.Usuar.ToUpper().Trim();
                        num++;
                        ListaItemsColor.Add(ItemColor); 
                    }
                    num = 1;
                }
                BE.ListaItemColor = ListaItemsColor;
                                        
                if (BL.Insert(EmpresaID, BE))
                {
                    MessageBox.Show("Datos Grabados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    procesado = true;
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

                tb_pp_ordenprodBL BL = new tb_pp_ordenprodBL();
                tb_pp_ordenprod BE = new tb_pp_ordenprod();

                var ItemProp = new tb_pp_ordenprod.ItemProp();
                var ItemColor = new tb_pp_ordenprod.ItemColor();
                var ListaItemsProp = new List<tb_pp_ordenprod.ItemProp>();
                var ListaItemsColor = new List<tb_pp_ordenprod.ItemColor>();

                #region Variables de OrdenProdCab
                BE.tipop = "PP";
                BE.serop = cmb_ordprod.Text;
                BE.numop = txt_numop.Text.Trim().ToString();
                if (txt_fechemi.Text.ToString().Length > 0)
                    BE.fechemi = Convert.ToDateTime(txt_fechemi.Text);
                if (txt_fechini.Text.ToString().Length > 0)
                    BE.fechini = Convert.ToDateTime(txt_fechini.Text);
                if (txt_fechfin.Text.ToString().Length > 0)
                    BE.fechfin = Convert.ToDateTime(txt_fechfin.Text);
                
                // NO LE PASAMOS ESTADO PORQUE ESO SE MODIFICA POR OTRO CAMINO
                //BE.estado = cmb_estado.SelectedValue.ToString();      
          
                BE.perianio = cmb_perianio.SelectedValue.ToString();
                BE.articid = xarticid.ToString();
                BE.canalventaid = cmb_canalvta.SelectedValue.ToString();
                BE.ctacte = txt_ctacte.Text;
                BE.tipref = txt_tipref.Text;
                BE.serref = txt_serref.Text;
                BE.numref = txt_numref.Text;
                BE.observacion = txt_observacion.Text;
                BE.cantprog = Convert.ToInt32(txt_cantprog.Text);
                BE.cantreal = Convert.ToInt32(txt_cantreal.Text);
                BE.ejecutorid = Convert.ToInt32(cmb_ejecutor.SelectedValue.ToString());
                BE.usuar = VariablesPublicas.Usuar.ToUpper().Trim();
                #endregion

                if (dgv_grilla.Rows.Count > 0 && dgv_grilla.ColumnCount > 0)
                {
                    for (int i = 1; i < dgv_grilla.ColumnCount; i++)
                    {
                        ItemProp = new tb_pp_ordenprod.ItemProp();
                        ItemProp.tipop = "PP";
                        ItemProp.serop = cmb_ordprod.Text;
                        ItemProp.numop = txt_numop.Text;
                        ItemProp.coltalla = i.ToString().PadLeft(2, '0');
                        ItemProp.proporcion = Convert.ToInt32(dgv_grilla.Rows[0].Cells[i].Value.ToString());
                        ItemProp.cantprog = Convert.ToInt32(dgv_grilla.Rows[1].Cells[i].Value.ToString());
                        ItemProp.cantreal = Convert.ToInt32(dgv_grilla.Rows[2].Cells[i].Value.ToString());
                        ListaItemsProp.Add(ItemProp);
                    }
                }

                BE.ListaItemProp = ListaItemsProp;

                var num = 1;
                for (int i = 0; i < dgv_ordenprodcolor.RowCount; i++)
                {
                    for (int j = 6; j < dgv_ordenprodcolor.Columns.Count - 1; j++)
                    {
                        ItemColor = new tb_pp_ordenprod.ItemColor();
                        ItemColor.tipop = "PP";
                        ItemColor.serop = cmb_ordprod.Text;
                        ItemColor.numop = txt_numop.Text;
                        ItemColor.colorid = dgv_ordenprodcolor.Rows[i].Cells["colorid"].Value.ToString();
                        ItemColor.coltalla = num.ToString().PadLeft(2, '0');
                        ItemColor.cantidad = Convert.ToInt32(dgv_ordenprodcolor.Rows[i].Cells[j].Value.ToString());
                        ItemColor.status = "0";
                        ItemColor.usuar = VariablesPublicas.Usuar.ToUpper().Trim();
                        num++;
                        ListaItemsColor.Add(ItemColor);
                    }
                    num = 1;
                }
                BE.ListaItemColor = ListaItemsColor;
                              
                if (BL.Update(EmpresaID, BE))
                {
                    SEGURIDAD_LOG("M");
                    MessageBox.Show("Datos Modificado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    procesado = true;
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
                //tb_me_proyeccionBL BL = new tb_me_proyeccionBL();
                //tb_me_proyeccion BE = new tb_me_proyeccion();

                //BE.anio = cmb_perianio.SelectedValue.ToString();               
                //BE.canalventaid = cmb_canalvta.SelectedValue.ToString();

                //if (BL.Delete(EmpresaID, BE))
                //{
                //    SEGURIDAD_LOG("E");
                //    MessageBox.Show("Datos Eliminado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    NIVEL_FORMS();
                //    limpiar_documento();
                //    form_bloqueado(false);
                //    //CargarDatos();                    
                //    btn_nuevo.Enabled = true;
                //}
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void Frm_orden_produccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.G)
            {
                if (btn_grabar.Enabled)
                {
                    btn_grabar.PerformClick();
                }
            }

            if (e.Control && e.KeyCode == Keys.N)
            {
                if (btn_nuevo.Enabled)
                {
                    btn_nuevo.PerformClick();
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
                    btn_salir.PerformClick();
                }
            }

            if (e.KeyCode == Keys.Delete)
            {
                //dgv_proyeccion.DeleteRow(dgv_proyeccion.FocusedRowHandle);
                //DeleteRowTable();
            }

            //if (e.KeyCode == Keys.Down)            
            //    SendKeys.Send("{TAB}");   
            
            //if (e.KeyCode == Keys.Up)            
            //    SendKeys.Send("+{TAB}");
            
        }


        void DeleteRowTableFase()
        {
            int lc_cont = 0;
            if ((dgv_ordenprodfase.RowCount > 0))
            {
                var xsecuencia = dgv_ordenprodfase.Rows[dgv_ordenprodfase.CurrentCell.RowIndex].Cells["secuencia"].Value.ToString();
                var xfaseid = dgv_ordenprodfase.Rows[dgv_ordenprodfase.CurrentCell.RowIndex].Cells["faseid"].Value.ToString();

                for (lc_cont = 0; lc_cont <= this.TablaOrdenProdFase.Rows.Count - 1; lc_cont++)
                {
                    // ubique la fila a borrar de acuerdo a los codigos validados
                    if (this.TablaOrdenProdFase.Rows[lc_cont]["secuencia"].ToString() == xsecuencia &&
                        this.TablaOrdenProdFase.Rows[lc_cont]["faseid"].ToString() == xfaseid)
                    {
                        this.TablaOrdenProdFase.Rows[lc_cont].Delete();
                        this.TablaOrdenProdFase.AcceptChanges();
                        break;
                    }
                }            
            }
        }

        void DeleteRowTableColor()
        {
            int lc_cont = 0;
            if ((dgv_ordenprodcolor.RowCount > 0))
            {
                var xcolorid = dgv_ordenprodcolor.Rows[dgv_ordenprodcolor.CurrentCell.RowIndex].Cells["colorid"].Value.ToString();

                for (lc_cont = 0; lc_cont <= this.TablaOrdenProdColor.Rows.Count - 1; lc_cont++)
                {
                    // ubique la fila a borrar de acuerdo a los codigos validados
                    if (this.TablaOrdenProdColor.Rows[lc_cont]["colorid"].ToString() == xcolorid)
                    {
                        this.TablaOrdenProdColor.Rows[lc_cont].Delete();
                        this.TablaOrdenProdColor.AcceptChanges();
                        break;
                    }
                }
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
                BloqueoBotones(false);
                btn_edit.Enabled = true;
                btn_nuevo.Enabled = true;
                btn_salir.Enabled = true;               
                ssModo = "OTR";
                if (TablaOrdenProdColor.Rows.Count > 0)                
                    TablaOrdenProdColor.Rows.Clear();                                                 
                tab_01.PageEnabled = true;
                tab_03.PageEnabled = true;            
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

        private void btn_log_Click(object sender, EventArgs e)
        {
            var oform = new Seguridadlog.FrmSeguridad();
            var xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio;
            oform._Nombre = Name;
            oform._ClaveForm = xclave;
            oform.Owner = this;
            oform.ShowDialog();
        }        

        private void btn_clave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void btn_nuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
            if (XNIVEL == "0")
            {
                nuevo();
                if (TablaOrdenProdColor != null)
                {
                    TablaOrdenProdColor.Rows.Clear();
                    //dgb_localcuota.DataSource = TablaOrdenProdColorDet;
                }
            }


        }

        private void btn_editar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XNIVEL == "0") // SEGUN UN USUARIO ADMIN PUEDE TENER ACCESO A UNA MODIFICACION TOTAL
            {
                if (Equivalencias.Left(txt_numop.Text, 1) == "_")// LE PONGO GUION BAJO CUANDO LIMPIO EL DOCUMENTO
                {
                    MessageBox.Show("No Existe Numero de Doc. a Modificar ..!!!", "Mensaje");
                    xtraTabControl1.SelectedTabPage = tab_01;
                }
                else
                {
                    ssModo = "EDIT";
                    form_bloqueado(true);
                    //ValidaArticulo();
                    btn_cancelar.Enabled = true;
                    btn_grabar.Enabled = true;
                    cmb_ordprod.Enabled = false;
                    btn_add.Enabled = false;
                    txt_fechemi.Enabled = false;
                    cmb_estado.Enabled = false; // Porque El Estado se Modifica por Otro Lado
                    cmb_ejecutor.Enabled = false; // Se Carga De Acuerdo al Usuario Cuando Hacemos Click_Nuevo 
                        
                    // bloqueamos los tab 
                    tab_01.PageEnabled = false;
                    tab_03.PageEnabled = false;
                }
            }

            if (XNIVEL == "1") // SEGUN UN USUARIO ADMIN PUEDE TENER ACCESO A UNA MODIFICACION TOTAL
            {
                if (Equivalencias.Left(txt_numop.Text, 1) == "_")// LE PONGO GUION BAJO CUANDO LIMPIO EL DOCUMENTO
                {
                    MessageBox.Show("No Existe Numero de Doc. a Modificar ..!!!", "Mensaje");
                    xtraTabControl1.SelectedTabPage = tab_01;
                }
                else
                {
                    ssModo = "EDIT";
                    form_bloqueado(false);
                    //ValidaArticulo();
                    txt_colorid.Enabled = true;
                    btn_cancelar.Enabled = true;
                    btn_grabar.Enabled = true;
                    cmb_ordprod.Enabled = false;
                    btn_add.Enabled = false;
                    cmb_estado.Enabled = false; // Porque El Estado se Modifica por Otro Lado
                    cmb_ejecutor.Enabled = false;

                    //PROGRAMAR SOLO PARA QUE SE DESABILITE UNA FILA DE LA GRILLA PARA PONER LAS CANTIDADES REALES
                    dgv_grilla.Enabled = true;

                    dgv_grilla.Rows[0].ReadOnly = true;
                    dgv_grilla.Rows[1].ReadOnly = true;                                   
                    dgv_ordenprodcolor.Enabled = true;

                    // bloqueamos los tab 
                    tab_01.PageEnabled = false;
                    tab_03.PageEnabled = false;
                }
            }
        }


        private void btn_grabar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            procesado = false;
            var sw_prosigue = false;
            if (ssModo == "NEW")
            {
                //if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
                if (XNIVEL == "0") // EL UNICO QUE PUEDE HACER UN NUEVO PEDIDO CUANDO ES XNIVEL = 0
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
                limpiar_documento();
                ArmaGrilla();
                TmpOrdenProdCab();
                DataOrdenProduccion();
                xtraTabControl1.SelectedTabPage = tab_01;
                tab_01.PageEnabled = true;
                tab_02.PageEnabled = true;
                tab_03.PageEnabled = true;
                form_bloqueado(false);
                btn_nuevo.Enabled = true;
                btn_salir.Enabled = true;
                
            }
        }


        private void btn_salir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btn_eliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void btn_cancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            form_accion_cancelEdicion(1);
        }
     
        private void Mdi_dgv_tiendalist_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                tb_me_proyeccion BE = new tb_me_proyeccion();

                //BE.anio = dgv_proyeccion.GetRowCellValue(dgv_proyeccion.FocusedRowHandle, "perianio").ToString();
                //BE.temporadaid = dgv_proyeccion.GetRowCellValue(dgv_proyeccion.FocusedRowHandle, "temporadaid").ToString();
                //BE.canalventaid = dgv_proyeccion.GetRowCellValue(dgv_proyeccion.FocusedRowHandle, "canalventaid").ToString();
                //BE.marcaid = dgv_proyeccion.GetRowCellValue(dgv_proyeccion.FocusedRowHandle, "marcaid").ToString();
                //BE.lineaid = dgv_proyeccion.GetRowCellValue(dgv_proyeccion.FocusedRowHandle, "lineaid").ToString();
                //BE.entalleid = dgv_proyeccion.GetRowCellValue(dgv_proyeccion.FocusedRowHandle, "entalleid").ToString();
                //BE.generoid = dgv_proyeccion.GetRowCellValue(dgv_proyeccion.FocusedRowHandle, "generoid").ToString();
                //BE.lineatelaid = dgv_proyeccion.GetRowCellValue(dgv_proyeccion.FocusedRowHandle, "lineatelaid").ToString();
                Data_ProyDet(BE);
            }
        }

        private void dgv_tiendalist_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            tb_me_proyeccion BE = new tb_me_proyeccion();
            //BE.anio = dgv_proyeccion.GetRowCellValue(e.RowHandle, "perianio").ToString();          
            //BE.temporadaid = dgv_proyeccion.GetRowCellValue(e.RowHandle, "temporadaid").ToString();
            //BE.canalventaid = dgv_proyeccion.GetRowCellValue(e.RowHandle, "canalventaid").ToString();
            //BE.marcaid = dgv_proyeccion.GetRowCellValue(e.RowHandle, "marcaid").ToString();
            //BE.lineaid = dgv_proyeccion.GetRowCellValue(e.RowHandle, "lineaid").ToString();
            //BE.entalleid = dgv_proyeccion.GetRowCellValue(e.RowHandle, "entalleid").ToString();
            //BE.generoid = dgv_proyeccion.GetRowCellValue(e.RowHandle, "generoid").ToString();
            //BE.lineatelaid = dgv_proyeccion.GetRowCellValue(e.RowHandle, "lineatelaid").ToString();
            Data_ProyDet(BE);
        }


        void AddRowTable()
        {            
            row = TablaOrdenProdColor.NewRow();
            row["tipop"] = "PP";
            row["serop"] = cmb_ordprod.Text;
            row["numop"] = txt_numop.Text;
            row["colorid"] = txt_colorid.Text;
            row["colorname"] = txt_colorname.Text;
            row["coltalla"] = "";
            row["can01"] = txt_taco01.Text;
            row["can02"] = txt_taco02.Text;
            row["can03"] = txt_taco03.Text;
            row["can04"] = txt_taco04.Text;
            row["can05"] = txt_taco05.Text;
            row["can06"] = txt_taco06.Text;
            row["can07"] = txt_taco07.Text;
            row["can08"] = txt_taco08.Text;
            row["can09"] = txt_taco09.Text;
            row["can10"] = txt_taco10.Text;
            row["can11"] = txt_taco11.Text;
            row["can12"] = txt_taco12.Text;
            row["cantot"] = txt_tacotot.Text;             
            TablaOrdenProdColor.Rows.Add(row);
        }

        void AddRowTableFase()
        {
            row = TablaOrdenProdFase.NewRow();
            row["tipop"] = "PP";
            row["serop"] = cmb_ordprod.Text;
            row["numop"] = txt_numop.Text;
            row["secuencia"] = txt_secuencia.Value.ToString();
            row["faseid"] = cmb_fase.SelectedValue.ToString();
            row["fasename"] = cmb_fase.Text;
            row["ctacte"] = txt_ctacte03.Text.Trim();
            row["ctactename"] = txt_ctactename03.Text.Trim().ToUpper();
            if (txt_fechini03.Text.Length > 0)
                row["fechprog_ini"] = txt_fechini03.Text;
            if (txt_fechentrega03.Text.Length > 0)
                row["fechprog_fin"] = txt_fechentrega03.Text;
            TablaOrdenProdFase.Rows.Add(row);
        }
      

        Boolean ValidaDatos()
        {
            Boolean val = true;
            if (txt_colorid.Text.ToString().Length == 0)
            {
                val = false;
                MessageBox.Show("Seleccionar un Color Determinado", "Mensaje !!!");
            }
            else if (txt_colorname.Text.ToString().Length == 0)
            {
                val = false;
                MessageBox.Show("Seleccionar un Color Determinado", "Mensaje !!!");
            } 
                              
            return val;
        }        

        Boolean ValidaDatosFase2()
        {
            Boolean valor = true;
            String xfaseid = "",xsec = "";
            foreach (DataGridViewRow fila in dgv_ordenprodfase.Rows)
            {
                xfaseid = fila.Cells["faseid"].Value.ToString();
                xsec = fila.Cells["secuencia"].Value.ToString();

                if (xsec.Equals(txt_secuencia.Value.ToString()))
                {
                    valor = false;
                    MessageBox.Show("Existen La Misma Secuencia ... Cambiarlo", "Mensaje");
                }
                else if (xfaseid.Equals(cmb_fase.SelectedValue.ToString()))
                {
                    valor = false;
                    MessageBox.Show("Existen Datos Iguales en el Detalle ... Cambiarlo", "Mensaje");
                }
            }
            return valor;
        }

        Boolean ValidaDatos2()
        {
            Boolean valor = true;
            String xcolorid = "";
            foreach (DataGridViewRow fila in dgv_ordenprodcolor.Rows)
            {               
                xcolorid = fila.Cells["colorid"].Value.ToString();
                if (xcolorid.Equals(txt_colorid.Text))
                {
                    valor = false;
                    MessageBox.Show("Existen Datos Iguales en el Detalle ... Cambiarlo", "Mensaje");
                }
            }          
            return valor;            
        }

        void CalculosTotales()
        {
            if (TablaOrdenProdColor.Rows != null)
            {                
                txt_tottaco01.Text = (dgv_ordenprodcolor.RowCount > 0) ? Convert.ToInt32(TablaOrdenProdColor.Compute("sum(can01)", "")).ToString() : "0";
                txt_tottaco02.Text = (dgv_ordenprodcolor.RowCount > 0) ? Convert.ToInt32(TablaOrdenProdColor.Compute("sum(can02)", "")).ToString() : "0";
                txt_tottaco03.Text = (dgv_ordenprodcolor.RowCount > 0) ? Convert.ToInt32(TablaOrdenProdColor.Compute("sum(can03)", "")).ToString() : "0";
                txt_tottaco04.Text = (dgv_ordenprodcolor.RowCount > 0) ? Convert.ToInt32(TablaOrdenProdColor.Compute("sum(can04)", "")).ToString() : "0";
                txt_tottaco05.Text = (dgv_ordenprodcolor.RowCount > 0) ? Convert.ToInt32(TablaOrdenProdColor.Compute("sum(can05)", "")).ToString() : "0";
                txt_tottaco06.Text = (dgv_ordenprodcolor.RowCount > 0) ? Convert.ToInt32(TablaOrdenProdColor.Compute("sum(can06)", "")).ToString() : "0";
                txt_tottaco07.Text = (dgv_ordenprodcolor.RowCount > 0) ? Convert.ToInt32(TablaOrdenProdColor.Compute("sum(can07)", "")).ToString() : "0";
                txt_tottaco08.Text = (dgv_ordenprodcolor.RowCount > 0) ? Convert.ToInt32(TablaOrdenProdColor.Compute("sum(can08)", "")).ToString() : "0";
                txt_tottaco09.Text = (dgv_ordenprodcolor.RowCount > 0) ? Convert.ToInt32(TablaOrdenProdColor.Compute("sum(can09)", "")).ToString() : "0";
                txt_tottaco10.Text = (dgv_ordenprodcolor.RowCount > 0) ? Convert.ToInt32(TablaOrdenProdColor.Compute("sum(can10)", "")).ToString() : "0";
                txt_tottaco11.Text = (dgv_ordenprodcolor.RowCount > 0) ? Convert.ToInt32(TablaOrdenProdColor.Compute("sum(can11)", "")).ToString() : "0";
                txt_tottaco12.Text = (dgv_ordenprodcolor.RowCount > 0) ? Convert.ToInt32(TablaOrdenProdColor.Compute("sum(can12)", "")).ToString() : "0";
                txt_tottot.Text = (dgv_ordenprodcolor.RowCount > 0) ? Convert.ToInt32(TablaOrdenProdColor.Compute("sum(cantot)", "")).ToString() : "0";               
            }
        }        

        void SumCantidadColor()
        {
            Int32 tacotot = 0;
            Int32 tacon01 = (txt_taco01.Text.ToString().Length) > 0 ? Convert.ToInt32(txt_taco01.Text) : 0;
            Int32 tacon02 = (txt_taco02.Text.ToString().Length) > 0 ? Convert.ToInt32(txt_taco02.Text) : 0;
            Int32 tacon03 = (txt_taco03.Text.ToString().Length) > 0 ? Convert.ToInt32(txt_taco03.Text) : 0;
            Int32 tacon04 = (txt_taco04.Text.ToString().Length) > 0 ? Convert.ToInt32(txt_taco04.Text) : 0;
            Int32 tacon05 = (txt_taco05.Text.ToString().Length) > 0 ? Convert.ToInt32(txt_taco05.Text) : 0;
            Int32 tacon06 = (txt_taco06.Text.ToString().Length) > 0 ? Convert.ToInt32(txt_taco06.Text) : 0;
            Int32 tacon07 = (txt_taco07.Text.ToString().Length) > 0 ? Convert.ToInt32(txt_taco07.Text) : 0;
            Int32 tacon08 = (txt_taco08.Text.ToString().Length) > 0 ? Convert.ToInt32(txt_taco08.Text) : 0;
            Int32 tacon09 = (txt_taco09.Text.ToString().Length) > 0 ? Convert.ToInt32(txt_taco09.Text) : 0;
            Int32 tacon10 = (txt_taco10.Text.ToString().Length) > 0 ? Convert.ToInt32(txt_taco10.Text) : 0;
            Int32 tacon11 = (txt_taco11.Text.ToString().Length) > 0 ? Convert.ToInt32(txt_taco11.Text) : 0;
            Int32 tacon12 = (txt_taco12.Text.ToString().Length) > 0 ? Convert.ToInt32(txt_taco12.Text) : 0;

            tacotot = tacon01 + tacon02 + tacon03 + tacon04 + tacon05 + tacon06 + tacon07 + tacon08 + tacon09 + tacon10 + tacon11 + tacon12;
            txt_tacotot.Text = tacotot.ToString("###,###,###"); ;
        }

        private void Data_ProyDet(tb_me_proyeccion BE)
        {
            var rowproydet = TablaOrdenProdColor.Select(" perianio ='" + BE.anio + "' and temporadaid = '"+BE.temporadaid+"' and canalventaid = '"+BE.canalventaid+"' and "+
                                                    " marcaid = '"+BE.marcaid+"' and lineaid = '"+BE.lineaid+"' and entalleid = '"+BE.entalleid+"' and generoid = '"+BE.generoid+"' and "+
                                                    " lineatelaid = '"+BE.lineatelaid+"' ");
            if (rowproydet.Length > 0)
            {
                foreach (DataRow row in rowproydet)
                {
                    //cmb_marcaid.SelectedValue = row["marcaid"].ToString();
                    //cmb_lineaid.SelectedValue = row["lineaid"].ToString();
                    //cmb_entalleid.SelectedValue = row["entalleid"].ToString();
                    //cmb_generoid.SelectedValue = row["generoid"].ToString();
                    //cmb_lineatelaid.SelectedValue = row["lineatelaid"].ToString();

                    //txt_01.Text = row["cantmod01"].ToString();
                    //txt_02.Text = row["cantmod02"].ToString();
                    //txt_03.Text = row["cantmod03"].ToString();
                    //txt_04.Text = row["cantmod04"].ToString();
                    //txt_05.Text = row["cantmod05"].ToString();
                    //txt_06.Text = row["cantmod06"].ToString();

                    //txt_totmodels.Text = row["canttotal"].ToString();
                    //txt_profun.Text = row["profundidad"].ToString();
                    //txt_totprendas.Text = row["totalprendas"].ToString();
                    
                    //btn_editar.Enabled = true;
                }
            }
        }

        private void AyudaArticulo()
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all";
                frmayuda.titulo = "<< AYUDA TABLA ARTICULO >>";
                frmayuda.sqlquery = "SELECT articid,articidold,articname FROM tb_pt_articulo ";
                frmayuda.sqlinner = "";
                frmayuda.sqlwhere = "where ";
                frmayuda.sqland = "";
                frmayuda.criteriosbusqueda = new string[] { "ARTICULO", "CODIGO" };
                frmayuda.columbusqueda = "articname,articidold";
                frmayuda.returndatos = "0,1,2";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeArticulo;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RecibeArticulo(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                xarticid = resultado1.Trim();
                txt_articid.Text = resultado2.Trim();
                txt_articname.Text = resultado3.Trim();

                ValidaArticulo();
            }
        }

        private void txt_articid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaArticulo();
                txt_ctacte.Focus();
            }

            if (e.KeyCode == Keys.Enter)
            {                
                ValidaArticulo();
                txt_ctacte.Focus();
            }
        }


        void ValidaArticulo()
        {
            tb_pt_articuloBL BL = new tb_pt_articuloBL();
            tb_pt_articulo BE = new tb_pt_articulo();
            DataTable dt = new DataTable();

            ArmaGrilla();

            BE.top = true;
            BE.articidold = txt_articid.Text.ToString().ToUpper();
            if (txt_articid.Text.ToString().Length == 7)
            {
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    xarticid = dt.Rows[0]["articid"].ToString();
                    txt_marcaname.Text = dt.Rows[0]["marcaname"].ToString();
                    txt_lineaname.Text = dt.Rows[0]["lineaname"].ToString();
                    txt_generoname.Text = dt.Rows[0]["generoname"].ToString();
                    txt_temporadaname.Text = dt.Rows[0]["temporadaname"].ToString();
                    txt_familiatelaname.Text = dt.Rows[0]["familianame"].ToString();
                    cmb_canalvta.SelectedValue = dt.Rows[0]["canalventaid"].ToString();
                    txt_variante.Text = dt.Rows[0]["variante"].ToString();
                   

                    tb_pt_tallaBL BL2 = new tb_pt_tallaBL();
                    tb_pt_talla BE2 = new tb_pt_talla();
                    DataTable tall = new DataTable();
                    BE2.tallaid = dt.Rows[0]["tallaid"].ToString();
                    tall = BL2.GetAll(EmpresaID, BE2).Tables[0];
                   

                    dgv_grilla.Columns[1].HeaderText = tall.Rows[0]["talla01"].ToString();
                    dgv_grilla.Columns[2].HeaderText = tall.Rows[0]["talla02"].ToString();
                    dgv_grilla.Columns[3].HeaderText = tall.Rows[0]["talla03"].ToString();
                    dgv_grilla.Columns[4].HeaderText = tall.Rows[0]["talla04"].ToString();
                    dgv_grilla.Columns[5].HeaderText = tall.Rows[0]["talla05"].ToString();
                    dgv_grilla.Columns[6].HeaderText = tall.Rows[0]["talla06"].ToString();
                    dgv_grilla.Columns[7].HeaderText = tall.Rows[0]["talla07"].ToString();
                    dgv_grilla.Columns[8].HeaderText = tall.Rows[0]["talla08"].ToString();
                    dgv_grilla.Columns[9].HeaderText = tall.Rows[0]["talla09"].ToString();
                    dgv_grilla.Columns[10].HeaderText = tall.Rows[0]["talla10"].ToString();
                    dgv_grilla.Columns[11].HeaderText = tall.Rows[0]["talla11"].ToString();
                    dgv_grilla.Columns[12].HeaderText = tall.Rows[0]["talla12"].ToString();

                    dgv_grilla.Columns[1].ReadOnly = !Convert.ToBoolean(dt.Rows[0]["ta01"]);
                    dgv_grilla.Columns[1].DefaultCellStyle.BackColor = !(Convert.ToBoolean(dt.Rows[0]["ta01"])) == true ? Color.LightSteelBlue : Color.Teal;
                    dgv_grilla.Columns[2].ReadOnly = !Convert.ToBoolean(dt.Rows[0]["ta02"]);
                    dgv_grilla.Columns[2].DefaultCellStyle.BackColor = !(Convert.ToBoolean(dt.Rows[0]["ta02"])) == true ? Color.LightSteelBlue : Color.Teal;
                    dgv_grilla.Columns[3].ReadOnly = !Convert.ToBoolean(dt.Rows[0]["ta03"]);
                    dgv_grilla.Columns[3].DefaultCellStyle.BackColor = !(Convert.ToBoolean(dt.Rows[0]["ta03"])) == true ? Color.LightSteelBlue : Color.Teal;
                    dgv_grilla.Columns[4].ReadOnly = !Convert.ToBoolean(dt.Rows[0]["ta04"]);
                    dgv_grilla.Columns[4].DefaultCellStyle.BackColor = !(Convert.ToBoolean(dt.Rows[0]["ta04"])) == true ? Color.LightSteelBlue : Color.Teal;
                    dgv_grilla.Columns[5].ReadOnly = !Convert.ToBoolean(dt.Rows[0]["ta05"]);
                    dgv_grilla.Columns[5].DefaultCellStyle.BackColor = !(Convert.ToBoolean(dt.Rows[0]["ta05"])) == true ? Color.LightSteelBlue : Color.Teal;
                    dgv_grilla.Columns[6].ReadOnly = !Convert.ToBoolean(dt.Rows[0]["ta06"]);
                    dgv_grilla.Columns[6].DefaultCellStyle.BackColor = !(Convert.ToBoolean(dt.Rows[0]["ta06"])) == true ? Color.LightSteelBlue : Color.Teal;
                    dgv_grilla.Columns[7].ReadOnly = !Convert.ToBoolean(dt.Rows[0]["ta07"]);
                    dgv_grilla.Columns[7].DefaultCellStyle.BackColor = !(Convert.ToBoolean(dt.Rows[0]["ta07"])) == true ? Color.LightSteelBlue : Color.Teal;
                    dgv_grilla.Columns[8].ReadOnly = !Convert.ToBoolean(dt.Rows[0]["ta08"]);
                    dgv_grilla.Columns[8].DefaultCellStyle.BackColor = !(Convert.ToBoolean(dt.Rows[0]["ta08"])) == true ? Color.LightSteelBlue : Color.Teal;
                    dgv_grilla.Columns[9].ReadOnly = !Convert.ToBoolean(dt.Rows[0]["ta09"]);
                    dgv_grilla.Columns[9].DefaultCellStyle.BackColor = !(Convert.ToBoolean(dt.Rows[0]["ta09"])) == true ? Color.LightSteelBlue : Color.Teal;
                    dgv_grilla.Columns[10].ReadOnly = !Convert.ToBoolean(dt.Rows[0]["ta10"]);
                    dgv_grilla.Columns[10].DefaultCellStyle.BackColor = !(Convert.ToBoolean(dt.Rows[0]["ta10"])) == true ? Color.LightSteelBlue : Color.Teal;
                    dgv_grilla.Columns[11].ReadOnly = !Convert.ToBoolean(dt.Rows[0]["ta11"]);
                    dgv_grilla.Columns[11].DefaultCellStyle.BackColor = !(Convert.ToBoolean(dt.Rows[0]["ta11"])) == true ? Color.LightSteelBlue : Color.Teal;
                    dgv_grilla.Columns[12].ReadOnly = !Convert.ToBoolean(dt.Rows[0]["ta12"]);
                    dgv_grilla.Columns[12].DefaultCellStyle.BackColor = !(Convert.ToBoolean(dt.Rows[0]["ta12"])) == true ? Color.LightSteelBlue : Color.Teal;


                    lbltaco01.Text = tall.Rows[0]["talla01"].ToString();
                    lbltaco02.Text = tall.Rows[0]["talla02"].ToString();
                    lbltaco03.Text = tall.Rows[0]["talla03"].ToString();
                    lbltaco04.Text = tall.Rows[0]["talla04"].ToString();
                    lbltaco05.Text = tall.Rows[0]["talla05"].ToString();
                    lbltaco06.Text = tall.Rows[0]["talla06"].ToString();
                    lbltaco07.Text = tall.Rows[0]["talla07"].ToString();
                    lbltaco08.Text = tall.Rows[0]["talla08"].ToString();
                    lbltaco09.Text = tall.Rows[0]["talla09"].ToString();
                    lbltaco10.Text = tall.Rows[0]["talla10"].ToString();
                    lbltaco11.Text = tall.Rows[0]["talla11"].ToString();
                    lbltaco12.Text = tall.Rows[0]["talla12"].ToString();


                    txt_taco01.Enabled = Convert.ToBoolean(dt.Rows[0]["ta01"]);
                    txt_taco01.BackColor = (Convert.ToBoolean(dt.Rows[0]["ta01"])) == true ? Color.Teal : Color.White;
                    txt_taco01.ForeColor = (Convert.ToBoolean(dt.Rows[0]["ta01"])) == true ? Color.White : Color.Black;
                    txt_taco02.Enabled = Convert.ToBoolean(dt.Rows[0]["ta02"]);
                    txt_taco02.BackColor = (Convert.ToBoolean(dt.Rows[0]["ta02"])) == true ? Color.Teal : Color.White;
                    txt_taco02.ForeColor = (Convert.ToBoolean(dt.Rows[0]["ta02"])) == true ? Color.White : Color.Black;
                    txt_taco03.Enabled = Convert.ToBoolean(dt.Rows[0]["ta03"]);
                    txt_taco03.BackColor = (Convert.ToBoolean(dt.Rows[0]["ta03"])) == true ? Color.Teal : Color.White;
                    txt_taco03.ForeColor = (Convert.ToBoolean(dt.Rows[0]["ta03"])) == true ? Color.White : Color.Black;
                    txt_taco04.Enabled = Convert.ToBoolean(dt.Rows[0]["ta04"]);
                    txt_taco04.BackColor = (Convert.ToBoolean(dt.Rows[0]["ta04"])) == true ? Color.Teal : Color.White;
                    txt_taco04.ForeColor = (Convert.ToBoolean(dt.Rows[0]["ta04"])) == true ? Color.White : Color.Black;
                    txt_taco05.Enabled = Convert.ToBoolean(dt.Rows[0]["ta05"]);
                    txt_taco05.BackColor = (Convert.ToBoolean(dt.Rows[0]["ta05"])) == true ? Color.Teal : Color.White;
                    txt_taco05.ForeColor = (Convert.ToBoolean(dt.Rows[0]["ta05"])) == true ? Color.White : Color.Black;
                    txt_taco06.Enabled = Convert.ToBoolean(dt.Rows[0]["ta06"]);
                    txt_taco06.BackColor = (Convert.ToBoolean(dt.Rows[0]["ta06"])) == true ? Color.Teal : Color.White;
                    txt_taco06.ForeColor = (Convert.ToBoolean(dt.Rows[0]["ta06"])) == true ? Color.White : Color.Black;
                    txt_taco07.Enabled = Convert.ToBoolean(dt.Rows[0]["ta07"]);
                    txt_taco07.BackColor = (Convert.ToBoolean(dt.Rows[0]["ta07"])) == true ? Color.Teal : Color.White;
                    txt_taco07.ForeColor = (Convert.ToBoolean(dt.Rows[0]["ta07"])) == true ? Color.White : Color.Black;
                    txt_taco08.Enabled = Convert.ToBoolean(dt.Rows[0]["ta08"]);
                    txt_taco08.BackColor = (Convert.ToBoolean(dt.Rows[0]["ta08"])) == true ? Color.Teal : Color.White;
                    txt_taco08.ForeColor = (Convert.ToBoolean(dt.Rows[0]["ta08"])) == true ? Color.White : Color.Black;
                    txt_taco09.Enabled = Convert.ToBoolean(dt.Rows[0]["ta09"]);
                    txt_taco09.BackColor = (Convert.ToBoolean(dt.Rows[0]["ta09"])) == true ? Color.Teal : Color.White;
                    txt_taco09.ForeColor = (Convert.ToBoolean(dt.Rows[0]["ta09"])) == true ? Color.White : Color.Black;
                    txt_taco10.Enabled = Convert.ToBoolean(dt.Rows[0]["ta10"]);
                    txt_taco10.BackColor = (Convert.ToBoolean(dt.Rows[0]["ta10"])) == true ? Color.Teal : Color.White;
                    txt_taco10.ForeColor = (Convert.ToBoolean(dt.Rows[0]["ta10"])) == true ? Color.White : Color.Black;
                    txt_taco11.Enabled = Convert.ToBoolean(dt.Rows[0]["ta11"]);
                    txt_taco11.BackColor = (Convert.ToBoolean(dt.Rows[0]["ta11"])) == true ? Color.Teal : Color.White;
                    txt_taco11.ForeColor = (Convert.ToBoolean(dt.Rows[0]["ta11"])) == true ? Color.White : Color.Black;
                    txt_taco12.Enabled = Convert.ToBoolean(dt.Rows[0]["ta12"]);
                    txt_taco12.BackColor = (Convert.ToBoolean(dt.Rows[0]["ta12"])) == true ? Color.Teal : Color.White;
                    txt_taco12.ForeColor = (Convert.ToBoolean(dt.Rows[0]["ta12"])) == true ? Color.White : Color.Black;


                    //dgv_grilla.Columns[12].HeaderText = tall.Rows[0]["talla12"].ToString();                   
                    dgv_ordenprodcolor.Columns[6].HeaderText = tall.Rows[0]["talla01"].ToString();
                    dgv_ordenprodcolor.Columns[7].HeaderText = tall.Rows[0]["talla02"].ToString();
                    dgv_ordenprodcolor.Columns[8].HeaderText = tall.Rows[0]["talla03"].ToString();
                    dgv_ordenprodcolor.Columns[9].HeaderText = tall.Rows[0]["talla04"].ToString();
                    dgv_ordenprodcolor.Columns[10].HeaderText = tall.Rows[0]["talla05"].ToString();
                    dgv_ordenprodcolor.Columns[11].HeaderText = tall.Rows[0]["talla06"].ToString();
                    dgv_ordenprodcolor.Columns[12].HeaderText = tall.Rows[0]["talla07"].ToString();
                    dgv_ordenprodcolor.Columns[13].HeaderText = tall.Rows[0]["talla08"].ToString();
                    dgv_ordenprodcolor.Columns[14].HeaderText = tall.Rows[0]["talla09"].ToString();
                    dgv_ordenprodcolor.Columns[15].HeaderText = tall.Rows[0]["talla10"].ToString();
                    dgv_ordenprodcolor.Columns[16].HeaderText = tall.Rows[0]["talla11"].ToString();
                    dgv_ordenprodcolor.Columns[17].HeaderText = tall.Rows[0]["talla12"].ToString();


                }
            }

        }

        private void cmb_ordprod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btn_nuevo.Enabled == false)
            {
                limpiar_documento();
                select_tipodoc();
                //get_val_fechadoc();
                if (true) // Falta agregar una condicion tipo bool
                {
                    form_bloqueado(true);
                    txt_fechemi.Text = DateTime.Today.ToShortDateString();
                    btn_cancelar.Enabled = true;
                    btn_grabar.Enabled = true;                    
                    cmb_ordprod.Enabled = false;
                    txt_articid.Focus();
                }
            }
            else
            {
                //select_tipodoc();
                //txt_numop.Text = string.Empty;            
            }
        }

        private void select_tipodoc()
        {
            try
            {
                if (cmb_ordprod.SelectedIndex != -1 && cmb_ordprod.SelectedIndex != 0)
                {
                    var BL = new tb_pp_ordenserieBL();
                    var BE = new tb_pp_ordenserie();
                    var dt = new DataTable();
                                     
                    BE.perianio = cmb_ordprod.SelectedValue.ToString().Trim();
                    BE.ser_op = cmb_ordprod.Text.ToString().Trim();
                    dt = BL.GetAll_NUM(EmpresaID, BE).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        txt_numop.Text = dt.Rows[0]["numop"].ToString();
                        cmb_perianio.SelectedValue = cmb_ordprod.SelectedValue.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Asignar la Accion del Documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                   
                    }
                }
                else
                {    
                    txt_numop.Text = string.Empty;      
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }


        private void AyudaClientes()
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "Ayuda Cliente/Proveedor";
                frmayuda.sqlquery = "select ctacte, ctactename, nmruc, direc from tb_cliente";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where";
                frmayuda.sqland = string.Empty;
                frmayuda.criteriosbusqueda = new string[] { "CLIENTE", "RUC", "CODIGO" };
                frmayuda.columbusqueda = "ctactename,nmruc,ctacte";
                frmayuda.returndatos = "0,2,1,3";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeClientes;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }      


        private void ValidaCliente()
        {
            if (txt_ctacte.Text.Trim().Length > 0)
            {
                var BL = new clienteBL();
                var BE = new tb_cliente();
                var dt = new DataTable();

                BE.ctacte = txt_ctacte.Text.Trim().PadLeft(7, '0');
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    txt_ctacte.Text = dt.Rows[0]["ctacte"].ToString().Trim();
                    txt_ctactename.Text = dt.Rows[0]["ctactename"].ToString().Trim();
                }
                else
                {
                    txt_ctacte.Text = string.Empty;
                    txt_ctactename.Text = string.Empty;
                }
            }
        }



        private void RecibeClientes(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                if (ActCtacte.Equals("02"))
                {
                    txt_ctacte.Text = resultado1.Trim();
                    txt_ctactename.Text = resultado3.Trim();
                }

                if (ActCtacte.Equals("03"))
                {
                    txt_ctacte03.Text = resultado1.Trim();
                    txt_ctactename03.Text = resultado3.Trim();
                }
            }
        }

        private void txt_ctacte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaClientes();
                txt_tipref.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                ValidaCliente();
                txt_tipref.Focus();
            }
        }

        private void txt_serref_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String cod = txt_serref.Text;
                txt_serref.Text = cod.PadLeft(4,'0');
                txt_numref.Focus();
            }
        }

        private void txt_numref_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String cod = txt_numref.Text;
                txt_numref.Text = cod.PadLeft(10, '0');
                txt_observacion.Focus();
            }
        }

        private void txt_tipref_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {               
                txt_serref.Focus();
            }
        }                
        
        private void DataOrdenProduccion()
        {
            tb_pp_ordenprodBL BL = new tb_pp_ordenprodBL();
            tb_pp_ordenprod BE = new tb_pp_ordenprod();           
            BE.parameters = txt_articname01.Text.ToUpper().Trim();
            TablaOrdenProdCab = BL.GetAll(EmpresaID, BE).Tables[0];
            Mdi_dgv_ordenproduccion.DataSource = TablaOrdenProdCab;  
        }

        private void chk_serie01_CheckedChanged(object sender, EventArgs e)
        {          
            if (chk_serie01.Checked)
            {
                cmb_serie01.SelectedIndex = 0;
                cmb_serie01.Enabled = true;
            }
            else
            {
                cmb_serie01.SelectedIndex = -1;
                cmb_anio01.SelectedIndex = -1;
                cmb_serie01.Enabled = false;
                DataOrdenProduccion();
            }
        }

        private void chk_marca01_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_marca01.Checked)
            {
                cmb_marca01.SelectedIndex = 0;
                cmb_marca01.Enabled = true;
            }
            else
            {
                cmb_marca01.SelectedIndex = -1;
                cmb_marca01.Enabled = false;
                DataOrdenProduccion();
            }
        }

        private void chk_linea01_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_linea01.Checked)
            {
                cmb_linea01.SelectedIndex = 0;
                cmb_linea01.Enabled = true;
            }
            else
            {
                cmb_linea01.SelectedIndex = -1;
                cmb_linea01.Enabled = false;
                DataOrdenProduccion();
            }
        }

        private void chk_estado01_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_estado01.Checked)
            {
                cmb_estado01.SelectedIndex = 0;
                cmb_estado01.Enabled = true;
            }
            else
            {
                cmb_estado01.SelectedIndex = -1;
                cmb_estado01.Enabled = false;
                DataOrdenProduccion();
            }
        }

        private void cmb_serie01_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_serie01.SelectedIndex != -1)
            {
                cmb_anio01.SelectedValue = cmb_serie01.SelectedValue.ToString();
                DataOrdenProduccion();
            }
        }

        private void cmb_marca01_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_marca01.SelectedIndex != -1)
            {
                DataOrdenProduccion();
            }
        }

        private void cmb_linea01_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_linea01.SelectedIndex != -1)
            {
                DataOrdenProduccion();
            }
        }

        private void cmb_estado01_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_estado01.SelectedIndex != -1)
            {
                DataOrdenProduccion();
            }
        }

        private void txt_numop01_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String cod = txt_numop01.Text;
                txt_numop01.Text = cod.PadLeft(10, '0');
                DataOrdenProduccion();
            }
        }

        private void txt_articname01_KeyUp(object sender, KeyEventArgs e)
        {
            DataOrdenProduccion();
        }        

        private void txt_colorid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaArticuloColor();               
            }

            if (e.KeyCode == Keys.Enter)
            {
                ValidaArticuloColor();
                txt_taco01.Focus();
            }
        }

        private void AyudaArticuloColor()
        {
            var frmayuda = new Ayudas.Frm_help_general();

            frmayuda.tipoo = "sql";
            frmayuda.titulo = "<< AYUDA TABLA ARTICULO-COLOR >>";
            frmayuda.sqlquery = " SELECT ac.colorid,c.colorname "+
                                " FROM tb_pt_articulocolor ac "+
                                " LEFT JOIN tb_pt_color c ON ac.colorid = c.colorid ";
            frmayuda.sqlwhere = " WHERE articid = '" + xarticid.ToString() + "' AND [status] = '0' ";
            frmayuda.sqland = " AND ";
            frmayuda.criteriosbusqueda = new string[] { "COLOR", "CODIGO" };
            frmayuda.columbusqueda = "c.colorname,ac.colorid";
            frmayuda.returndatos = "0,1";

            frmayuda.Owner = this;
            frmayuda.PasaProveedor = RecibeArticuloColor;
            frmayuda.ShowDialog();
        }

        private void RecibeArticuloColor(String xcolorid, String xcolorname, String resultado3, String resultado4, String resultado5)
        {
            if (xcolorid.Trim().Length > 0)
            {
                txt_colorid.Text = xcolorid.ToString();
                txt_colorname.Text = xcolorname.ToString();
                btn_add.Enabled = true;
            }
        }

        void ValidaArticuloColor()
        {
            if (xarticid.Length == 0)
            {
                MessageBox.Show("Seleccione Primero Un Articulo !!!", "Información");
                return;
            }
            else
            {
                tb_pt_articulocolorBL BL = new tb_pt_articulocolorBL();
                tb_pt_articulocolor BE = new tb_pt_articulocolor();
                DataTable dt = new DataTable();
                BE.articid = xarticid.ToString();
                BE.colorid = txt_colorid.Text.ToString().ToUpper();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    txt_colorid.Text = dt.Rows[0]["colorid"].ToString();
                    txt_colorname.Text = dt.Rows[0]["colorname"].ToString();
                    btn_add.Enabled = true;
                }
            }
        }

        private void txt_numop01_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(ActiveControl.Text))
            {
                txt_numop01.SelectionStart = 0;
                txt_numop01.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void txt_articname01_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(ActiveControl.Text))
            {
                txt_articname01.SelectionStart = 0;
                txt_articname01.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void txt_numref_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(ActiveControl.Text))
            {
                txt_numref.SelectionStart = 0;
                txt_numref.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void txt_serref_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(ActiveControl.Text))
            {
                txt_serref.SelectionStart = 0;
                txt_serref.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void txt_tipref_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(ActiveControl.Text))
            {
                txt_tipref.SelectionStart = 0;
                txt_tipref.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void txt_ctacte_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(ActiveControl.Text))
            {
                txt_ctacte.SelectionStart = 0;
                txt_ctacte.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void txt_articid_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(ActiveControl.Text))
            {
                txt_articid.SelectionStart = 0;
                txt_articid.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void txt_colorid_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(ActiveControl.Text))
            {
                txt_colorid.SelectionStart = 0;
                txt_colorid.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void txt_taco01_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_taco02.Focus();
                if (!String.IsNullOrEmpty(ActiveControl.Text))
                {
                    txt_taco02.SelectionStart = 0;
                    txt_taco02.SelectionLength = ActiveControl.Text.Length;
                }
            }
        }

        private void txt_taco02_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_taco03.Focus();
                if (!String.IsNullOrEmpty(ActiveControl.Text))
                {
                    txt_taco03.SelectionStart = 0;
                    txt_taco03.SelectionLength = ActiveControl.Text.Length;
                }
            }
        }

        private void txt_taco03_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_taco04.Focus();
                if (!String.IsNullOrEmpty(ActiveControl.Text))
                {
                    txt_taco04.SelectionStart = 0;
                    txt_taco04.SelectionLength = ActiveControl.Text.Length;
                }
            }
        }

        private void txt_taco04_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_taco05.Focus();
                if (!String.IsNullOrEmpty(ActiveControl.Text))
                {
                    txt_taco05.SelectionStart = 0;
                    txt_taco05.SelectionLength = ActiveControl.Text.Length;
                }
            }
        }

        private void txt_taco05_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_taco06.Focus();
                if (!String.IsNullOrEmpty(ActiveControl.Text))
                {
                    txt_taco06.SelectionStart = 0;
                    txt_taco06.SelectionLength = ActiveControl.Text.Length;
                }
            }
        }

        private void txt_taco06_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_taco07.Focus();
                if (!String.IsNullOrEmpty(ActiveControl.Text))
                {
                    txt_taco07.SelectionStart = 0;
                    txt_taco07.SelectionLength = ActiveControl.Text.Length;
                }
            }
        }

        private void txt_taco07_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_taco08.Focus();
                if (!String.IsNullOrEmpty(ActiveControl.Text))
                {
                    txt_taco08.SelectionStart = 0;
                    txt_taco08.SelectionLength = ActiveControl.Text.Length;
                }
            }
        }

        private void txt_taco08_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_taco09.Focus();
                if (!String.IsNullOrEmpty(ActiveControl.Text))
                {
                    txt_taco09.SelectionStart = 0;
                    txt_taco09.SelectionLength = ActiveControl.Text.Length;
                }
            }
        }

        private void txt_taco09_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_taco10.Focus();
                if (!String.IsNullOrEmpty(ActiveControl.Text))
                {
                    txt_taco10.SelectionStart = 0;
                    txt_taco10.SelectionLength = ActiveControl.Text.Length;
                }
            }
        }

        private void txt_taco10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_taco11.Focus();
                if (!String.IsNullOrEmpty(ActiveControl.Text))
                {
                    txt_taco11.SelectionStart = 0;
                    txt_taco11.SelectionLength = ActiveControl.Text.Length;
                }
            }
        }

        private void txt_taco11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_taco12.Focus();
                if (!String.IsNullOrEmpty(ActiveControl.Text))
                {
                    txt_taco12.SelectionStart = 0;
                    txt_taco12.SelectionLength = ActiveControl.Text.Length;
                }
            }
        }

        private void txt_taco12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
            }
        }

        private void txt_taco01_KeyUp(object sender, KeyEventArgs e)
        {
            SumCantidadColor();
        }

        private void txt_taco02_KeyUp(object sender, KeyEventArgs e)
        {
            SumCantidadColor();
        }

        private void txt_taco03_KeyUp(object sender, KeyEventArgs e)
        {
            SumCantidadColor();
        }

        private void txt_taco04_KeyUp(object sender, KeyEventArgs e)
        {
            SumCantidadColor();
        }

        private void txt_taco05_KeyUp(object sender, KeyEventArgs e)
        {
            SumCantidadColor();
        }

        private void txt_taco06_KeyUp(object sender, KeyEventArgs e)
        {
            SumCantidadColor();
        }

        private void txt_taco07_KeyUp(object sender, KeyEventArgs e)
        {
            SumCantidadColor();
        }

        private void txt_taco08_KeyUp(object sender, KeyEventArgs e)
        {
            SumCantidadColor();
        }

        private void txt_taco09_KeyUp(object sender, KeyEventArgs e)
        {
            SumCantidadColor();
        }

        private void txt_taco10_KeyUp(object sender, KeyEventArgs e)
        {
            SumCantidadColor();
        }

        private void txt_taco11_KeyUp(object sender, KeyEventArgs e)
        {
            SumCantidadColor();
        }

        private void txt_taco12_KeyUp(object sender, KeyEventArgs e)
        {
            SumCantidadColor();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaDatos())
                {
                    if (this.dgv_ordenprodcolor.RowCount > 0)
                    {
                        // SEGUNDA VALIDACIÓN
                        if (ValidaDatos2())
                        {
                            int nFilaAnt = dgv_ordenprodcolor.RowCount - 1;
                            TablaOrdenProdColor = new DataTable();
                            TmpOrdenProdColor();

                            foreach (DataGridViewRow fila in dgv_ordenprodcolor.Rows)
                            {
                                row = TablaOrdenProdColor.NewRow();
                                row["tipop"] = "PP";
                                row["serop"] = cmb_ordprod.Text;
                                row["numop"] = txt_numop.Text;                               
                                row["colorid"] = fila.Cells["colorid"].Value;
                                row["colorname"] = fila.Cells["colorname"].Value;
                                row["can01"] = fila.Cells["can01"].Value;
                                row["can02"] = fila.Cells["can02"].Value;
                                row["can03"] = fila.Cells["can03"].Value;
                                row["can04"] = fila.Cells["can04"].Value;
                                row["can05"] = fila.Cells["can05"].Value;
                                row["can06"] = fila.Cells["can06"].Value;
                                row["can07"] = fila.Cells["can07"].Value;
                                row["can08"] = fila.Cells["can08"].Value;
                                row["can09"] = fila.Cells["can09"].Value;
                                row["can10"] = fila.Cells["can10"].Value;
                                row["can11"] = fila.Cells["can11"].Value;
                                row["can12"] = fila.Cells["can12"].Value;
                                row["cantot"] = txt_tacotot.Text;

                                TablaOrdenProdColor.Rows.Add(row);

                            }

                            #region 2Da Forma CargaDatos
                            //for (int j = 0; j < dgv_ordenprodcolor.RowCount; j++)
                            //{
                            //    row = TablaOrdenProdColor.NewRow();                                
                            //    row["tipop"] = "PP";
                            //    row["serop"] = cmb_ordprod.Text;
                            //    row["numop"] = txt_numop.Text;                               
                            //    row["colorid"] = dgv_ordenprodcolor.Rows[j].Cells[0].ToString();
                            //    row["colorname"] = dgv_ordenprodcolor.Rows[j].Cells[1].ToString();
                            //    row["can01"] = dgv_ordenprodcolor.Rows[j].Cells[2].ToString();
                            //    row["can02"] = dgv_ordenprodcolor.Rows[j].Cells[3].ToString();
                            //    row["can03"] = dgv_ordenprodcolor.Rows[j].Cells[4].ToString();
                            //    row["can04"] = dgv_ordenprodcolor.Rows[j].Cells[5].ToString();
                            //    row["can05"] = dgv_ordenprodcolor.Rows[j].Cells[6].ToString();
                            //    row["can06"] = dgv_ordenprodcolor.Rows[j].Cells[7].ToString();
                            //    row["can07"] = dgv_ordenprodcolor.Rows[j].Cells[8].ToString();
                            //    row["can08"] = dgv_ordenprodcolor.Rows[j].Cells[9].ToString();
                            //    row["can09"] = dgv_ordenprodcolor.Rows[j].Cells[10].ToString();
                            //    row["can10"] = dgv_ordenprodcolor.Rows[j].Cells[11].ToString();
                            //    row["can11"] = dgv_ordenprodcolor.Rows[j].Cells[12].ToString();
                            //    row["can12"] = dgv_ordenprodcolor.Rows[j].Cells[13].ToString();
                            //    row["cantot"] = txt_tacotot.Text;   

                            //    TablaOrdenProdColor.Rows.Add(row);
                            //}
                            #endregion

                            AddRowTable();
                            dgv_ordenprodcolor.DataSource = TablaOrdenProdColor;
                            CalculosTotales();
                        }
                    }
                    else
                    {
                        TmpOrdenProdColor();
                        AddRowTable();
                        dgv_ordenprodcolor.DataSource = TablaOrdenProdColor;
                        CalculosTotales();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_articid_KeyUp(object sender, KeyEventArgs e)
        {
            ValidaArticulo();
        }

        private void dgv_grilla_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_grilla.Rows.Count > 0 && dgv_grilla.ColumnCount > 0)
                {
                    Int32 n = 0, tot_cantprog = 0,tot_cantreal=0;
                    for (int i = 1; i < dgv_grilla.ColumnCount; i++)
                    {                      
                        if (Convert.ToInt32(dgv_grilla.Rows[1].Cells[i].Value.ToString()) > 0)
                        {
                            n = Convert.ToInt32(dgv_grilla.Rows[1].Cells[i].Value.ToString());
                            tot_cantprog = tot_cantprog + n;
                        }

                        if (Convert.ToInt32(dgv_grilla.Rows[2].Cells[i].Value.ToString()) > 0)
                        {
                            n = Convert.ToInt32(dgv_grilla.Rows[2].Cells[i].Value.ToString());
                            tot_cantreal = tot_cantreal + n;
                        }
                    }
                    txt_cantprog.Text = tot_cantprog.ToString();
                    txt_cantreal.Text = tot_cantreal.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }                                   
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == tab_01)
            {
                lblbusqueda.Visible = true;
                txt_articname01.Visible = true;
                btn_editar.Enabled = false;
            }
            else
            {
                lblbusqueda.Visible = false;
                txt_articname01.Visible = false;               
            }

            if (e.Page == tab_02)
            {
                ActCtacte = "02";
                btn_editar.Enabled = true;
            }

            if (e.Page == tab_03)
            {
                ActCtacte = "03";
                btn_new.Enabled = true;
                btn_edit.Enabled = false;
                btn_editar.Enabled = false;
                dgv_ordenprodfase.Enabled = true;
            }



        }

        private void Mdi_dgv_ordenproduccion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                tb_pp_ordenprod BE = new tb_pp_ordenprod();             
                BE.serop = dgv_ordenproduccion.GetRowCellValue(dgv_ordenproduccion.FocusedRowHandle, "serop").ToString();
                BE.numop = dgv_ordenproduccion.GetRowCellValue(dgv_ordenproduccion.FocusedRowHandle, "numop").ToString();
                Data_OrdenProdCab(BE);
                form_bloqueado(false);
                btn_nuevo.Enabled = true;
            }
        }
       
        private void dgv_ordenproduccion_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            tb_pp_ordenprod BE = new tb_pp_ordenprod();
            BE.serop = dgv_ordenproduccion.GetRowCellValue(e.RowHandle, "serop").ToString();
            BE.numop = dgv_ordenproduccion.GetRowCellValue(e.RowHandle, "numop").ToString();
            Data_OrdenProdCab(BE);
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
        }


        private void Data_OrdenProdCab(tb_pp_ordenprod BE)
        {
            BE.tipop = "PP";
            var rowprodcab = TablaOrdenProdCab.Select(" serop ='" + BE.serop + "' and numop = '" + BE.numop +"'");
            if (rowprodcab.Length > 0)
            {
                foreach (DataRow row in rowprodcab)
                {
                    cmb_ordprod.Text = row["serop"].ToString();
                    txt_numop.Text = row["numop"].ToString();
                    
                    txt_fechemi.Text = Equivalencias.Left(row["fechemi"].ToString(),10);
                    txt_fechini.Text = Equivalencias.Left(row["fechini"].ToString(), 10);
                    txt_fechfin.Text = Equivalencias.Left(row["fechfin"].ToString(), 10);

                    cmb_estado.SelectedValue = row["estado"].ToString();
                    cmb_perianio.SelectedValue = row["perianio"].ToString();
                    cmb_ejecutor.SelectedValue = row["ejecutorid"].ToString();
                    cmb_canalvta.SelectedValue = row["canalventaid"].ToString();                    

                    xarticid = row["articid"].ToString();
                    txt_articid.Text = row["articidold"].ToString();
                    txt_articname.Text = row["articname"].ToString();
                    txt_variante.Text = row["variante"].ToString();

                    txt_marcaname.Text = row["marcaname"].ToString();
                    txt_lineaname.Text = row["lineaname"].ToString();
                    txt_generoname.Text = row["generoname"].ToString();
                    txt_temporadaname.Text = row["temporadaname"].ToString();
                    txt_familiatelaname.Text = row["familianame"].ToString();
                    txt_ctacte.Text = row["ctacte"].ToString();
                    txt_ctactename.Text = row["ctactename"].ToString();

                    txt_tipref.Text = row["tipref"].ToString();
                    txt_serref.Text = row["serref"].ToString();
                    txt_numref.Text = row["numref"].ToString();                    
                    txt_observacion.Text = row["observacion"].ToString();
                   
                    ValidaArticulo();
                    CargarGrilla(BE);
                    CargarOrdenProdColor(BE);
                    CalculosTotales();

                    txt_cantprog.Text = row["cantprog"].ToString();
                    txt_cantreal.Text = row["cantreal"].ToString();

                    // PINTANDO DATOS EN LA PESTAÑA DE FASES
                    txt_tipop03.Text = "PP";
                    txt_serop03.Text = row["serop"].ToString();
                    txt_numop03.Text = row["numop"].ToString();

                    // CARGAMOS EL DETALLE DE LAS FASES A EDITAR
                    CargarFaseOrdenProd(txt_tipop03.Text, txt_serop03.Text, txt_numop03.Text);

                } 
              
            }
        }

        void CargarGrilla(tb_pp_ordenprod BE)
        {
            tb_pp_ordenprodBL BL = new tb_pp_ordenprodBL();
            TablaGrilla = BL.GetAllProp_PIVOT(EmpresaID, BE).Tables[0];
            dgv_grilla.DataSource = TablaGrilla;
        }

        void CargarOrdenProdColor(tb_pp_ordenprod BE)
        {
            tb_pp_ordenprodBL BL = new tb_pp_ordenprodBL();
            TablaOrdenProdColor = BL.GetAllPropColor_PIVOT(EmpresaID, BE).Tables[0];
            dgv_ordenprodcolor.DataSource = TablaOrdenProdColor;
        }

        
        // TAB_FASES
        private void txt_ctacte03_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaClientes();
            }
        }

        private void btn_add2_Click(object sender, EventArgs e)
        {
            // Agregamos las Fases :
            try
            {
                if (ValidaDatosFase())
                {
                    if (this.dgv_ordenprodfase.RowCount > 0)
                    {
                        // SEGUNDA VALIDACIÓN
                        if (ValidaDatosFase2())
                        {
                            int nFilaAnt = dgv_ordenprodfase.RowCount - 1;
                            TablaOrdenProdFase = new DataTable();
                            TmpOrdenProdFase();

                            foreach (DataGridViewRow fila in dgv_ordenprodfase.Rows)
                            {
                                row = TablaOrdenProdFase.NewRow();
                                row["tipop"] = "PP";
                                row["serop"] = cmb_ordprod.Text;
                                row["numop"] = txt_numop.Text;
                                row["secuencia"] = fila.Cells["secuencia"].Value;
                                row["faseid"] = fila.Cells["faseid"].Value;
                                row["fasename"] = fila.Cells["fasename"].Value;
                                row["ctacte"] = fila.Cells["ctacte"].Value;
                                row["ctactename"] = fila.Cells["ctactename"].Value;
                                row["fechprog_ini"] = fila.Cells["fechprog_ini"].Value;
                                row["fechprog_fin"] = fila.Cells["fechprog_fin"].Value;
                                TablaOrdenProdFase.Rows.Add(row);
                            }
                            AddRowTableFase();
                            dgv_ordenprodfase.DataSource = TablaOrdenProdFase;                  
                        }
                    }
                    else
                    {
                        TmpOrdenProdFase();
                        AddRowTableFase();
                        dgv_ordenprodfase.DataSource = TablaOrdenProdFase;                       
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        
        void BloqueoBotones(Boolean var)
        {
            pnl_edit.Enabled = var;
            pnl_edit2.Enabled = var;
            btn_new.Enabled = var;
            btn_add.Enabled = var;
            btn_delete.Enabled = var;
            btn_cancel.Enabled = var;
            btn_edit.Enabled = var;
            dgv_ordenprodfase.Enabled = var;
            btn_save.Enabled = var;
        }


        private void dgv_ordenprodfase_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_ordenprodfase.CurrentRow != null)
                {
                    txt_secuencia.Text = dgv_ordenprodfase.Rows[e.RowIndex].Cells["secuencia"].Value.ToString().Trim();
                    cmb_fase.SelectedValue = dgv_ordenprodfase.Rows[e.RowIndex].Cells["faseid"].Value.ToString().Trim();
                    txt_ctacte03.Text = dgv_ordenprodfase.Rows[e.RowIndex].Cells["ctacte"].Value.ToString().Trim();
                    txt_ctactename03.Text = dgv_ordenprodfase.Rows[e.RowIndex].Cells["ctactename"].Value.ToString().Trim();                                       

                    btn_edit.Enabled = true;
                    if (XNIVEL == "0")            
                        btn_delete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgv_ordenprodfase_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                txt_secuencia.Text = dgv_ordenprodfase.Rows[dgv_ordenprodfase.CurrentRow.Index].Cells["secuencia"].Value.ToString().Trim();
                cmb_fase.SelectedValue = dgv_ordenprodfase.Rows[dgv_ordenprodfase.CurrentRow.Index].Cells["faseid"].Value.ToString().Trim();
                txt_ctacte03.Text = dgv_ordenprodfase.Rows[dgv_ordenprodfase.CurrentRow.Index].Cells["ctacte"].Value.ToString().Trim();
                txt_ctactename03.Text = dgv_ordenprodfase.Rows[dgv_ordenprodfase.CurrentRow.Index].Cells["ctactename"].Value.ToString().Trim();
                
                btn_edit.Enabled = true;
                if (XNIVEL == "0")
                    btn_delete.Enabled = true;
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            //editar de acuerdo al usuario 
            if (XNIVEL == "0") // SEGUN UN USUARIO ADMIN PUEDE TENER ACCESO A UNA MODIFICACION TOTAL
            {
                BloqueoBotones(false);
                ssModoII = "EDI";
                btn_cancel.Enabled = true;
                btn_save.Enabled = true;
                pnl_edit.Enabled = true;
                pnl_edit2.Enabled = true;
            }

            if (XNIVEL == "1") // SEGUN UN USUARIO ADMIN PUEDE TENER ACCESO A UNA MODIFICACION TOTAL
            {
                BloqueoBotones(false);
                ssModoII = "EDI";
                btn_cancel.Enabled = true;
                btn_save.Enabled = true;             
                pnl_edit2.Enabled = true;
            }

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            BloqueoBotones(false);
            ssModoII = "EDI";
            btn_new.Enabled = true;
            dgv_ordenprodfase.Enabled = true;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DeleteRowTableFase();
        }

        private void btn_quitar_Click(object sender, EventArgs e)
        {
            DeleteRowTableColor();
            CalculosTotales();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            procesado = false;
            var sw_prosigue = false;
            if (ssModoII == "NEW")
            {
                if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
                {
                    InsertFase();
                }
            }
            else
            {
                if (XNIVEL == "0" || XNIVEL == "1")
                {
                    sw_prosigue = (MessageBox.Show("¿Desea Modificar Documento Actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                    if (sw_prosigue)
                    {
                        UpdateFase();
                    }
                }
            }
            if (procesado)
            {
                NIVEL_FORMS();

                txt_ctacte03.Text = "";
                txt_ctactename03.Text = "";
                txt_fechini03.Text = "";
                txt_fechentrega03.Text = "";                                        
                
                DataOrdenProduccion();

                BloqueoBotones(false);
                btn_new.Enabled = true;
                dgv_ordenprodfase.Enabled = true;
            }
        }

        void InsertFase()
        {
            tb_pp_ordenprod BE = new tb_pp_ordenprod();
            tb_pp_ordenprodBL BL = new tb_pp_ordenprodBL();

            try
            {
                // PREVIA VALIDACION
                if (ValidaDatosFase())
                {
                    // Segunda Validacion solo Para Inserción
                    if (ValidaDatosFase2())
                    {
                        BE.tipop = "PP";
                        BE.serop = txt_serop03.Text;
                        BE.numop = txt_numop03.Text;
                        BE.secuencia = Convert.ToInt32(txt_secuencia.Value.ToString());
                        BE.faseid = Convert.ToInt32(cmb_fase.SelectedValue.ToString());
                        BE.ctacte = txt_ctacte03.Text;
                        if (txt_fechini03.Text.Length > 0)
                            BE.fechprogini = Convert.ToDateTime(txt_fechini03.Text);
                        if (txt_fechentrega03.Text.Length > 0)
                            BE.fechprogfin = Convert.ToDateTime(txt_fechentrega03.Text);
                        BE.estado = "11";
                        BE.usuar = VariablesPublicas.Usuar.ToUpper().Trim();

                        if (BL.InsertFase(EmpresaID, BE))
                        {
                            CargarFaseOrdenProd("PP", txt_serop03.Text, txt_numop03.Text);
                            //MessageBox.Show("Datos Modificado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            procesado = true;
                        }
                        else
                            MessageBox.Show("Fase no Registrada !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        bool ValidaDatosFase()
        {
            bool result = true;
            if (txt_tipop03.Text.Length != 2)
            {
                result = false;
                MessageBox.Show("Falta el Tipo de OP", "Confirmación !!!");
            }
            else if (txt_serop03.Text.Length != 4)
            {
                result = false;
                MessageBox.Show("Falta la Serie de OP", "Confirmación !!!");
            }
            else if (txt_numop03.Text.Length != 10)
            {
                result = false;
                MessageBox.Show("Falta la Numero de OP", "Confirmación !!!");
            }           
            else if (txt_secuencia.Value.ToString() == "0")
            {
                result = false;
                MessageBox.Show("Secuencia Mayor a : 0", "Confirmación !!!");
            }
            else if (cmb_fase.SelectedIndex < 0)
            {
                result = false;
                MessageBox.Show("Seleccionar una Proceso/Fase", "Confirmación !!!");
            }

            return result;
        }



        void UpdateFase()
        {
            tb_pp_ordenprod BE = new tb_pp_ordenprod();
            tb_pp_ordenprodBL BL = new tb_pp_ordenprodBL();
            try
            {
                // PREVIA VALIDACION
                if (ValidaDatosFase())
                {
                    BE.tipop = "PP";
                    BE.serop = txt_serop03.Text;
                    BE.numop = txt_numop03.Text;
                    BE.secuencia = Convert.ToInt32(txt_secuencia.Value.ToString());
                    BE.faseid = Convert.ToInt32(cmb_fase.SelectedValue.ToString());
                    BE.ctacte = txt_ctacte03.Text;
                    if (txt_fechini03.Text.Length > 0)
                        BE.fechprogini = Convert.ToDateTime(txt_fechini03.Text);
                    if (txt_fechentrega03.Text.Length > 0)
                        BE.fechprogfin = Convert.ToDateTime(txt_fechentrega03.Text);
                    //BE.estado = "11";
                    BE.usuar = VariablesPublicas.Usuar.ToUpper().Trim();

                    if (BL.UpdateFase(EmpresaID, BE))
                    {
                        CargarFaseOrdenProd("PP", txt_serop03.Text, txt_numop03.Text);
                        //MessageBox.Show("Datos Modificado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        procesado = true;
                    }
                    else
                        MessageBox.Show("Fase no Modificada !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        void CargarFaseOrdenProd(String xtipdop, String xserdop, String xnumop)
        {
            tb_pp_ordenprod BE = new tb_pp_ordenprod();
            tb_pp_ordenprodBL BL = new tb_pp_ordenprodBL();
            BE.tipop = xtipdop;
            BE.serop = xserdop;
            BE.numop = xnumop;
            TablaOrdenProdFase = BL.GetAll_Fase(EmpresaID, BE).Tables[0];
            dgv_ordenprodfase.DataSource = TablaOrdenProdFase;
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0")
            {
                if (Equivalencias.Left(txt_tipop03.Text, 1) == "_" ||
                    Equivalencias.Left(txt_serop03.Text, 1) == "_" ||
                    Equivalencias.Left(txt_numop03.Text, 1) == "_")
                {
                    MessageBox.Show("No Existe Numero de Doc...!!!", "Verificar");
                    xtraTabControl1.SelectedTabPage = tab_01;
                }
                else
                {
                    BloqueoBotones(false);                    
                    ssModoII = "NEW";
                    btn_cancel.Enabled = true;
                    pnl_edit.Enabled = true;
                    pnl_edit2.Enabled = true;
                    btn_save.Enabled = true;
                }
            }
        }

        private void dgv_ordenprodcolor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_ordenprodcolor.Enabled != false)
            {
                btn_quitar.Enabled = true;
            }
            else 
            {
                btn_quitar.Enabled = false;
            }
        }

        





    }
}
