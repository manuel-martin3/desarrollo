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

namespace BapFormulariosNet.D70Produccion
{
    public partial class Frm_proyeccion : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable TablaProyeccion;
        private DataRow row;

        private Decimal _xtipocambio;
        private Boolean procesado = false;
        private String ssModo = string.Empty;

        public Frm_proyeccion()
        {
            InitializeComponent();
        }

        private void Frm_articulo_tiendalist_Load(object sender, EventArgs e)
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

            NIVEL_FORMS();

            CargarAnio();           
            CargarCmbTemporada();
            CargarCmbCanalVta();
            CargarCmbMarca();
            CargarCmbLinea();
            CargarCmbEntalle();
            CargarCmbGenero();
            CargarCmbLineaTela();
            ArmadoTablasTmp();            
            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_salir.Enabled = true;
            cmb_perianio.SelectedValue = DateTime.Today.Year.ToString();
        }

        void ArmadoTablasTmp()
        {
            TablaProyeccion = new DataTable();
            TablaProyeccion.Columns.Add("perianio", typeof(String));
            TablaProyeccion.Columns.Add("temporadaid", typeof(String));
            TablaProyeccion.Columns.Add("canalventaid", typeof(String));
            TablaProyeccion.Columns.Add("marcaid", typeof(String));
            TablaProyeccion.Columns.Add("lineaid", typeof(String));
            TablaProyeccion.Columns.Add("entalleid", typeof(String));
            TablaProyeccion.Columns.Add("generoid", typeof(String));
            TablaProyeccion.Columns.Add("lineatelaid", typeof(String));
            TablaProyeccion.Columns.Add("cantmod01", typeof(Int32));
            TablaProyeccion.Columns.Add("cantmod02", typeof(Int32));
            TablaProyeccion.Columns.Add("cantmod03", typeof(Int32));
            TablaProyeccion.Columns.Add("cantmod04", typeof(Int32));
            TablaProyeccion.Columns.Add("cantmod05", typeof(Int32));
            TablaProyeccion.Columns.Add("cantmod06", typeof(Int32));
            TablaProyeccion.Columns.Add("canttotal", typeof(Int32));
            TablaProyeccion.Columns.Add("profundidad", typeof(Int32));
            TablaProyeccion.Columns.Add("totalprendas", typeof(Int32));

            TablaProyeccion.Columns.Add("marcaname", typeof(String));
            TablaProyeccion.Columns.Add("lineaname", typeof(String));
            TablaProyeccion.Columns.Add("entallename", typeof(String));
            TablaProyeccion.Columns.Add("tejidoname", typeof(String));
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
                //cmb_canalvta.Enabled = var;
                //cmb_perianio.Enabled = var;
                //cmb_temporadaid.Enabled = var;

                cmb_marcaid.Enabled = var;
                cmb_lineaid.Enabled = var;
                cmb_generoid.Enabled = var;
                cmb_entalleid.Enabled = var;
                cmb_lineatelaid.Enabled = var;              
                txt_01.Enabled = var;
                txt_02.Enabled = var;
                txt_03.Enabled = var;
                txt_04.Enabled = var;
                txt_05.Enabled = var;
                txt_06.Enabled = var;
                rb_status.Enabled = var;
                txt_totmodels.Enabled = false;
                txt_profun.Enabled = var;
                btn_add.Enabled = var;
                btn_new.Enabled = var;
                txt_totprendas.Enabled = false;

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
                cmb_perianio.SelectedIndex = -1;
                cmb_temporadaid.SelectedIndex = -1;
                cmb_canalvta.SelectedIndex = -1;
                cmb_marcaid.SelectedIndex = -1;
                cmb_lineaid.SelectedIndex = -1;
                cmb_generoid.SelectedIndex = -1;
                cmb_entalleid.SelectedIndex = -1;
                cmb_lineatelaid.SelectedIndex = -1;

                lbl01.Text = "_";
                lbl02.Text = "_";
                lbl03.Text = "_";
                lbl04.Text = "_";
                lbl05.Text = "_";
                lbl06.Text = "_";
                txt_01.Text = "";
                txt_02.Text = "";
                txt_03.Text = "";
                txt_04.Text = "";
                txt_05.Text = "";
                txt_06.Text = "";
                txt_totmodels.Text = "";
                txt_profun.Text = "";
                txt_totprendas.Text = "";

                txt_cantmod01.Text = "";
                txt_cantmod02.Text = "";
                txt_cantmod03.Text = "";
                txt_cantmod04.Text = "";
                txt_cantmod05.Text = "";
                txt_cantmod06.Text = "";
                txt_canttotalcab.Text = "";
                txt_totalprendascab.Text = "";

                if (TablaProyeccion.Rows != null)
                    TablaProyeccion.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevo2()
        {
            cmb_marcaid.SelectedIndex = -1;
            cmb_lineaid.SelectedIndex = -1;
            cmb_generoid.SelectedIndex = -1;
            cmb_entalleid.SelectedIndex = -1;
            cmb_lineatelaid.SelectedIndex = -1;

            lbl01.Text = "_";
            lbl02.Text = "_";
            lbl03.Text = "_";
            lbl04.Text = "_";
            lbl05.Text = "_";
            lbl06.Text = "_";
            txt_01.Text = "";
            txt_02.Text = "";
            txt_03.Text = "";
            txt_04.Text = "";
            txt_05.Text = "";
            txt_06.Text = "";
            txt_totmodels.Text = "";
            txt_profun.Text = "";
            txt_totprendas.Text = "";

            txt_cantmod01.Text = "";
            txt_cantmod02.Text = "";
            txt_cantmod03.Text = "";
            txt_cantmod04.Text = "";
            txt_cantmod05.Text = "";
            txt_cantmod06.Text = "";
            txt_canttotalcab.Text = "";
            txt_totalprendascab.Text = "";

            if (TablaProyeccion != null)
                TablaProyeccion.Clear();
        }



        private void nuevo()
        {
            limpiar_documento();
            form_bloqueado(true);
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_log.Enabled = true;
            ssModo = "NEW";
        }
       

        private void Insert()
        {
            try
            {
                tb_me_proyeccionBL BL = new tb_me_proyeccionBL();
                tb_me_proyeccion BE = new tb_me_proyeccion();

                var Detalle = new tb_me_proyeccion.Item();
                var ListaItems = new List<tb_me_proyeccion.Item>();

                BE.anio = cmb_perianio.SelectedValue.ToString();
                BE.temporadaid = cmb_temporadaid.SelectedValue.ToString();
                BE.canalventaid = cmb_canalvta.SelectedValue.ToString();
                BE.cantmod01 = Convert.ToInt32(txt_cantmod01.Text);
                BE.cantmod02 = Convert.ToInt32(txt_cantmod02.Text);
                BE.cantmod03 = Convert.ToInt32(txt_cantmod03.Text);
                BE.cantmod04 = Convert.ToInt32(txt_cantmod04.Text);
                BE.cantmod05 = Convert.ToInt32(txt_cantmod05.Text);
                BE.cantmod06 = Convert.ToInt32(txt_cantmod06.Text);
                BE.canttotal = Convert.ToInt32(txt_canttotalcab.Text);
                BE.totalprendas = Convert.ToInt32(txt_totalprendascab.Text);
                BE.status = rb_status.EditValue.ToString();
                BE.usuar = VariablesPublicas.Usuar.Trim().ToUpper();

                 var item = 0;
                 foreach (DataRow fila in TablaProyeccion.Rows)
                 {
                     Detalle = new tb_me_proyeccion.Item();
                     item++;
                     Detalle.anio = cmb_perianio.SelectedValue.ToString();
                     Detalle.temporadaid = cmb_temporadaid.SelectedValue.ToString();
                     Detalle.canalventaid = cmb_canalvta.SelectedValue.ToString();
                     Detalle.marcaid = fila["marcaid"].ToString();
                     Detalle.lineaid = fila["lineaid"].ToString();
                     Detalle.entalleid = fila["entalleid"].ToString();
                     Detalle.generoid = fila["generoid"].ToString();
                     Detalle.lineatelaid = fila["lineatelaid"].ToString();
                     Detalle.cantmod01 = Convert.ToInt32(fila["cantmod01"].ToString());
                     Detalle.cantmod02 = Convert.ToInt32(fila["cantmod02"].ToString());
                     Detalle.cantmod03 = Convert.ToInt32(fila["cantmod03"].ToString());
                     Detalle.cantmod04 = Convert.ToInt32(fila["cantmod04"].ToString());
                     Detalle.cantmod05 = Convert.ToInt32(fila["cantmod05"].ToString());
                     Detalle.cantmod06 = Convert.ToInt32(fila["cantmod06"].ToString());
                     Detalle.canttotal = Convert.ToInt32(fila["canttotal"].ToString());
                     Detalle.profundidad = Convert.ToInt32(fila["profundidad"].ToString());
                     Detalle.totalprendas = Convert.ToInt32(fila["totalprendas"].ToString());

                     if (Convert.ToInt32(fila["cantmod01"]) > 0 && Convert.ToInt32(fila["cantmod02"]) > 0 && Convert.ToInt32(fila["cantmod03"]) > 0 &&
                         Convert.ToInt32(fila["cantmod04"]) > 0 && Convert.ToInt32(fila["cantmod05"]) > 0 && Convert.ToInt32(fila["cantmod06"]) > 0)
                     {
                         ListaItems.Add(Detalle);
                     }
                     else
                     {
                         MessageBox.Show("Documento DETALLE EN FORMATO INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         return;
                     }
                 }
                 if (ListaItems.Count == 0)
                 {
                     MessageBox.Show("Documento SIN DETALLE Y/O DETALLE INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return;
                 }
                 BE.ListaItems = ListaItems;

                
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

                tb_me_proyeccionBL BL = new tb_me_proyeccionBL();
                tb_me_proyeccion BE = new tb_me_proyeccion();

                var Detalle = new tb_me_proyeccion.Item();
                var ListaItems = new List<tb_me_proyeccion.Item>();

                BE.anio = cmb_perianio.SelectedValue.ToString();
                BE.temporadaid = cmb_temporadaid.SelectedValue.ToString();
                BE.canalventaid = cmb_canalvta.SelectedValue.ToString();
                BE.cantmod01 = Convert.ToInt32(txt_cantmod01.Text);
                BE.cantmod02 = Convert.ToInt32(txt_cantmod02.Text);
                BE.cantmod03 = Convert.ToInt32(txt_cantmod03.Text);
                BE.cantmod04 = Convert.ToInt32(txt_cantmod04.Text);
                BE.cantmod05 = Convert.ToInt32(txt_cantmod05.Text);
                BE.cantmod06 = Convert.ToInt32(txt_cantmod06.Text);
                BE.canttotal = Convert.ToInt32(txt_canttotalcab.Text);
                BE.totalprendas = Convert.ToInt32(txt_totalprendascab.Text);
                BE.status = rb_status.EditValue.ToString();
                BE.usuar = VariablesPublicas.Usuar.Trim().ToUpper();

                var item = 0;
                foreach (DataRow fila in TablaProyeccion.Rows)
                {
                    Detalle = new tb_me_proyeccion.Item();
                    item++;
                    Detalle.anio = cmb_perianio.SelectedValue.ToString();
                    Detalle.temporadaid = cmb_temporadaid.SelectedValue.ToString();
                    Detalle.canalventaid = cmb_canalvta.SelectedValue.ToString();
                    Detalle.marcaid = fila["marcaid"].ToString();
                    Detalle.lineaid = fila["lineaid"].ToString();
                    Detalle.entalleid = fila["entalleid"].ToString();
                    Detalle.generoid = fila["generoid"].ToString();
                    Detalle.lineatelaid = fila["lineatelaid"].ToString();
                    Detalle.cantmod01 = Convert.ToInt32(fila["cantmod01"].ToString());
                    Detalle.cantmod02 = Convert.ToInt32(fila["cantmod02"].ToString());
                    Detalle.cantmod03 = Convert.ToInt32(fila["cantmod03"].ToString());
                    Detalle.cantmod04 = Convert.ToInt32(fila["cantmod04"].ToString());
                    Detalle.cantmod05 = Convert.ToInt32(fila["cantmod05"].ToString());
                    Detalle.cantmod06 = Convert.ToInt32(fila["cantmod06"].ToString());
                    Detalle.canttotal = Convert.ToInt32(fila["canttotal"].ToString());
                    Detalle.profundidad = Convert.ToInt32(fila["profundidad"].ToString());
                    Detalle.totalprendas = Convert.ToInt32(fila["totalprendas"].ToString());

                    if (Convert.ToInt32(fila["cantmod01"]) > 0 && Convert.ToInt32(fila["cantmod02"]) > 0 &&
                        Convert.ToInt32(fila["cantmod03"]) > 0 && Convert.ToInt32(fila["cantmod04"]) > 0)
                    {
                        ListaItems.Add(Detalle);
                    }
                    else
                    {
                        MessageBox.Show("Documento DETALLE EN FORMATO INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (ListaItems.Count == 0)
                {
                    MessageBox.Show("Documento SIN DETALLE Y/O DETALLE INCORRECTO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                BE.ListaItems = ListaItems;

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
                tb_me_proyeccionBL BL = new tb_me_proyeccionBL();
                tb_me_proyeccion BE = new tb_me_proyeccion();

                BE.anio = cmb_perianio.SelectedValue.ToString();
                BE.temporadaid = cmb_temporadaid.SelectedValue.ToString();
                BE.canalventaid = cmb_canalvta.SelectedValue.ToString();

                if (BL.Delete(EmpresaID, BE))
                {
                    SEGURIDAD_LOG("E");
                    MessageBox.Show("Datos Eliminado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NIVEL_FORMS();
                    limpiar_documento();
                    form_bloqueado(false);
                    //CargarDatos();                    
                    btn_nuevo.Enabled = true;
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarAnio()
        {
            var BL = new tb_perianioBL();
            List<tb_perianio> LISTA = null;
            LISTA = BL.Get_anio(EmpresaID);
            cmb_perianio.DataSource = LISTA;
            cmb_perianio.DisplayMember = "perianio";
            cmb_perianio.ValueMember = "codigo";
            cmb_perianio.SelectedIndex = 2;
        }


        #region Cargamos los Combos de Inicio
        
        void CargarCmbTemporada()
        {
            tb_pt_temporadaBL BL = new tb_pt_temporadaBL();
            tb_pt_temporada BE = new tb_pt_temporada();
            DataTable dt = new DataTable();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0) 
            {
                cmb_temporadaid.DataSource = dt;
                cmb_temporadaid.ValueMember = "temporadaid";
                cmb_temporadaid.DisplayMember = "temporadaname";
            }
        }

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
                cmb_marcaid.DataSource = dt;
                cmb_marcaid.ValueMember = "marcaid";
                cmb_marcaid.DisplayMember = "marcaname";
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
                cmb_lineaid.DataSource = dt;
                cmb_lineaid.ValueMember = "lineaid";
                cmb_lineaid.DisplayMember = "lineaname";
            }
        }

        void CargarCmbEntalle()
        {
            tb_pt_entalleBL BL = new tb_pt_entalleBL();
            tb_pt_entalle BE = new tb_pt_entalle();
            DataTable dt = new DataTable();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cmb_entalleid.DataSource = dt;
                cmb_entalleid.ValueMember = "entalleid";
                cmb_entalleid.DisplayMember = "entallename";
            }
        }

        void CargarCmbGenero()
        {
            tb_pt_generoBL BL = new tb_pt_generoBL();
            tb_pt_genero BE = new tb_pt_genero();
            DataTable dt = new DataTable();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cmb_generoid.DataSource = dt;
                cmb_generoid.ValueMember = "generoid";
                cmb_generoid.DisplayMember = "generoname";
            }
        }

        void CargarCmbLineaTela()
        {
            tb_60lineaBL BL = new tb_60lineaBL();
            tb_60linea BE = new tb_60linea();
            DataTable dt = new DataTable();
            BE.moduloid = "0320";
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cmb_lineatelaid.DataSource = dt;
                cmb_lineatelaid.ValueMember = "lineaid";
                cmb_lineatelaid.DisplayMember = "lineaname";
            }
        }
        #endregion


        private void Frm_articulo_tiendalist_KeyDown(object sender, KeyEventArgs e)
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
                dgv_proyeccion.DeleteRow(dgv_proyeccion.FocusedRowHandle);
                //DeleteRowTable();
            }


        }

        void DeleteRowTable()
        {
            int lc_cont = 0;       
            if ((dgv_proyeccion.RowCount > 0))
            {                               
                var xperianio = dgv_proyeccion.GetRowCellValue(dgv_proyeccion.FocusedRowHandle, "perianio").ToString();
                var xtemporadaid = dgv_proyeccion.GetRowCellValue(dgv_proyeccion.FocusedRowHandle, "temporadaid").ToString();
                var xcanalventaid = dgv_proyeccion.GetRowCellValue(dgv_proyeccion.FocusedRowHandle, "canalventaid").ToString();
                var xmarcaid = dgv_proyeccion.GetRowCellValue(dgv_proyeccion.FocusedRowHandle, "marcaid").ToString();
                var xlineaid = dgv_proyeccion.GetRowCellValue(dgv_proyeccion.FocusedRowHandle, "lineaid").ToString();
                var xentalleid = dgv_proyeccion.GetRowCellValue(dgv_proyeccion.FocusedRowHandle, "entalleid").ToString();
                var xgeneroid = dgv_proyeccion.GetRowCellValue(dgv_proyeccion.FocusedRowHandle, "generoid").ToString();
                var xlineatelaid = dgv_proyeccion.GetRowCellValue(dgv_proyeccion.FocusedRowHandle, "lineatelaid").ToString();


                for (lc_cont = 0; lc_cont <= this.TablaProyeccion.Rows.Count - 1; lc_cont++)
                {
                    // ubique el item a borrar
                    if (this.TablaProyeccion.Rows[lc_cont]["perianio"].ToString() == xperianio &&
                        this.TablaProyeccion.Rows[lc_cont]["temporadaid"].ToString() == xtemporadaid &&
                        this.TablaProyeccion.Rows[lc_cont]["canalventaid"].ToString() == xcanalventaid &&
                        this.TablaProyeccion.Rows[lc_cont]["marcaid"].ToString() == xmarcaid &&
                        this.TablaProyeccion.Rows[lc_cont]["lineaid"].ToString() == xlineaid &&
                        this.TablaProyeccion.Rows[lc_cont]["entalleid"].ToString() == xentalleid &&
                        this.TablaProyeccion.Rows[lc_cont]["generoid"].ToString() == xgeneroid &&
                        this.TablaProyeccion.Rows[lc_cont]["lineatelaid"].ToString() == xlineatelaid)
                    {
                        this.TablaProyeccion.Rows[lc_cont].Delete();
                        this.TablaProyeccion.AcceptChanges();
                        break;
                    }
                }              
                CalculoTotModelos();
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
                ssModo = "OTR";
                if (TablaProyeccion.Rows.Count > 0)
                {
                    TablaProyeccion.Rows.Clear();                  
                }                
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
            if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
            {
                nuevo();
                if (TablaProyeccion != null)
                {
                    TablaProyeccion.Rows.Clear();
                    //dgb_localcuota.DataSource = TablaProyeccionDet;
                }
            }
        }

        private void btn_editar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XNIVEL == "0")
            {
                // Varificamos que Proyeccion se debe de EDITAR

                if (rb_status.EditValue.ToString() == "11")
                {
                    ssModo = "EDIT";
                    form_bloqueado(true);
                    btn_cancelar.Enabled = true;
                    btn_grabar.Enabled = true;
                }
                else 
                {
                    MessageBox.Show("Proyeccion No Puede Ser Editada Verifique su Estado.","Mensaje");
                }

            }
        }

        private void btn_grabar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                limpiar_documento();
                CargarDatos();
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

                BE.anio = dgv_proyeccion.GetRowCellValue(dgv_proyeccion.FocusedRowHandle, "perianio").ToString();
                BE.temporadaid = dgv_proyeccion.GetRowCellValue(dgv_proyeccion.FocusedRowHandle, "temporadaid").ToString();
                BE.canalventaid = dgv_proyeccion.GetRowCellValue(dgv_proyeccion.FocusedRowHandle, "canalventaid").ToString();
                BE.marcaid = dgv_proyeccion.GetRowCellValue(dgv_proyeccion.FocusedRowHandle, "marcaid").ToString();
                BE.lineaid = dgv_proyeccion.GetRowCellValue(dgv_proyeccion.FocusedRowHandle, "lineaid").ToString();
                BE.entalleid = dgv_proyeccion.GetRowCellValue(dgv_proyeccion.FocusedRowHandle, "entalleid").ToString();
                BE.generoid = dgv_proyeccion.GetRowCellValue(dgv_proyeccion.FocusedRowHandle, "generoid").ToString();
                BE.lineatelaid = dgv_proyeccion.GetRowCellValue(dgv_proyeccion.FocusedRowHandle, "lineatelaid").ToString();
                Data_ProyDet(BE);
            }
        }

        private void dgv_tiendalist_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            tb_me_proyeccion BE = new tb_me_proyeccion();
            BE.anio = dgv_proyeccion.GetRowCellValue(e.RowHandle, "perianio").ToString();          
            BE.temporadaid = dgv_proyeccion.GetRowCellValue(e.RowHandle, "temporadaid").ToString();
            BE.canalventaid = dgv_proyeccion.GetRowCellValue(e.RowHandle, "canalventaid").ToString();
            BE.marcaid = dgv_proyeccion.GetRowCellValue(e.RowHandle, "marcaid").ToString();
            BE.lineaid = dgv_proyeccion.GetRowCellValue(e.RowHandle, "lineaid").ToString();
            BE.entalleid = dgv_proyeccion.GetRowCellValue(e.RowHandle, "entalleid").ToString();
            BE.generoid = dgv_proyeccion.GetRowCellValue(e.RowHandle, "generoid").ToString();
            BE.lineatelaid = dgv_proyeccion.GetRowCellValue(e.RowHandle, "lineatelaid").ToString();
            Data_ProyDet(BE);
        }


        void AddRowTable()
        {            
            row = TablaProyeccion.NewRow();
            row["perianio"] = cmb_perianio.SelectedValue.ToString();
            row["temporadaid"] = cmb_temporadaid.SelectedValue.ToString();
            row["canalventaid"] = cmb_canalvta.SelectedValue.ToString();
            row["marcaid"] = cmb_marcaid.SelectedValue.ToString();
            row["lineaid"] = cmb_lineaid.SelectedValue.ToString();
            row["entalleid"] = cmb_entalleid.SelectedValue.ToString();
            row["generoid"] = cmb_generoid.SelectedValue.ToString();
            row["lineatelaid"] = cmb_lineatelaid.SelectedValue.ToString();            
            row["marcaname"] = cmb_marcaid.Text;
            row["lineaname"] = cmb_lineaid.Text;
            row["entallename"] = cmb_entalleid.Text;
            row["tejidoname"] = cmb_lineatelaid.Text;

            row["cantmod01"] = Convert.ToInt32(txt_01.Text.ToString());
            row["cantmod02"] = Convert.ToInt32(txt_02.Text);
            row["cantmod03"] = Convert.ToInt32(txt_03.Text);
            row["cantmod04"] = Convert.ToInt32(txt_04.Text);
            row["cantmod05"] = Convert.ToInt32(txt_05.Text);
            row["cantmod06"] = Convert.ToInt32(txt_06.Text);

            row["canttotal"] = Convert.ToInt32(txt_totmodels.Text);
            row["profundidad"] = Convert.ToInt32(txt_profun.Text);
            row["totalprendas"] = Convert.ToInt32(txt_totprendas.Text);

            TablaProyeccion.Rows.Add(row);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaDatos())
                {                    
                    if (this.dgv_proyeccion.RowCount > 0)
                    {

                        // SEGUNDA VALIDACIÓN
                        if (ValidaDatos2())
                        {
                            int nFilaAnt = dgv_proyeccion.RowCount - 1;
                            TablaProyeccion = new DataTable();
                            ArmadoTablasTmp();
                            for (int j = 0; j < dgv_proyeccion.RowCount; j++)
                            {
                                row = TablaProyeccion.NewRow();
                                row["perianio"] = dgv_proyeccion.GetRowCellValue(j, "perianio").ToString();
                                row["temporadaid"] = dgv_proyeccion.GetRowCellValue(j, "temporadaid").ToString();
                                row["canalventaid"] = dgv_proyeccion.GetRowCellValue(j, "canalventaid").ToString();

                                row["marcaid"] = dgv_proyeccion.GetRowCellValue(j, "marcaid").ToString();
                                row["lineaid"] = dgv_proyeccion.GetRowCellValue(j, "lineaid").ToString();
                                row["entalleid"] = dgv_proyeccion.GetRowCellValue(j, "entalleid").ToString();
                                row["generoid"] = dgv_proyeccion.GetRowCellValue(j, "generoid").ToString();
                                row["lineatelaid"] = dgv_proyeccion.GetRowCellValue(j, "lineatelaid").ToString();

                                row["cantmod01"] = dgv_proyeccion.GetRowCellValue(j, "cantmod01").ToString();
                                row["cantmod02"] = dgv_proyeccion.GetRowCellValue(j, "cantmod02").ToString();
                                row["cantmod03"] = dgv_proyeccion.GetRowCellValue(j, "cantmod03").ToString();
                                row["cantmod04"] = dgv_proyeccion.GetRowCellValue(j, "cantmod04").ToString();
                                row["cantmod05"] = dgv_proyeccion.GetRowCellValue(j, "cantmod05").ToString();
                                row["cantmod06"] = dgv_proyeccion.GetRowCellValue(j, "cantmod06").ToString();

                                row["canttotal"] = dgv_proyeccion.GetRowCellValue(j, "canttotal").ToString();
                                row["profundidad"] = dgv_proyeccion.GetRowCellValue(j, "profundidad").ToString();
                                row["totalprendas"] = dgv_proyeccion.GetRowCellValue(j, "totalprendas").ToString();

                                row["marcaname"] = dgv_proyeccion.GetRowCellValue(j, "marcaname").ToString();
                                row["lineaname"] = dgv_proyeccion.GetRowCellValue(j, "lineaname").ToString();
                                row["entallename"] = dgv_proyeccion.GetRowCellValue(j, "entallename").ToString();
                                row["tejidoname"] = dgv_proyeccion.GetRowCellValue(j, "tejidoname").ToString();

                                TablaProyeccion.Rows.Add(row);
                            }
                            AddRowTable();
                            Mdi_dgv_proyeccion.DataSource = TablaProyeccion;
                            CalculosTotales();
                        }
                    }
                    else
                    {
                        ArmadoTablasTmp();
                        AddRowTable();
                        Mdi_dgv_proyeccion.DataSource = TablaProyeccion;
                        CalculosTotales();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        
        }

        Boolean ValidaDatos()
        {
            Boolean val = true;
            if (cmb_perianio.SelectedIndex == -1)
            {
                val = false;
                MessageBox.Show("Seleccione el Año","Mensaje !!!");
            }
            if (cmb_temporadaid.SelectedIndex == -1)
            {
                val = false;
                MessageBox.Show("Seleccione la Temporada", "Mensaje !!!");
            }

            return val;
        }

        Boolean ValidaDatos2()
        {
            Boolean valor = true;
            String xperianio = "", xtemporadaid = "", xcanalventaid="",
                  xmarcaid = "", xlineaid = "", xentalleid = "", xgeneroid = "", xlineatelaid="";

            for (int j = 0; j < dgv_proyeccion.RowCount; j++)
            {
                xperianio = dgv_proyeccion.GetRowCellValue(j, "perianio").ToString();
                xtemporadaid = dgv_proyeccion.GetRowCellValue(j, "temporadaid").ToString();
                xcanalventaid = dgv_proyeccion.GetRowCellValue(j, "canalventaid").ToString();
                
                xmarcaid = dgv_proyeccion.GetRowCellValue(j, "marcaid").ToString();
                xlineaid = dgv_proyeccion.GetRowCellValue(j, "lineaid").ToString();
                xentalleid = dgv_proyeccion.GetRowCellValue(j, "entalleid").ToString();
                xgeneroid = dgv_proyeccion.GetRowCellValue(j, "generoid").ToString();
                xlineatelaid = dgv_proyeccion.GetRowCellValue(j, "lineatelaid").ToString();

                if (xperianio.Equals(cmb_perianio.SelectedValue.ToString()) &&
                    xtemporadaid.Equals(cmb_temporadaid.SelectedValue.ToString()) &&
                    xcanalventaid.Equals(cmb_canalvta.SelectedValue.ToString()) &&
                    xmarcaid.Equals(cmb_marcaid.SelectedValue.ToString()) &&
                    xlineaid.Equals(cmb_lineaid.SelectedValue.ToString()) &&
                    xentalleid.Equals(cmb_entalleid.SelectedValue.ToString()) &&
                    xgeneroid.Equals(cmb_generoid.SelectedValue.ToString()) &&
                    xlineatelaid.Equals(cmb_lineatelaid.SelectedValue.ToString()) )
                {
                    valor = false;
                    MessageBox.Show("Existen Datos Iguales en el Detalle ... Cambiarlo","Mensaje");
                }
            }
            return valor;            
        }

        void CalculosTotales()
        {
            if (TablaProyeccion.Rows != null)
            {
                txt_cantmod01.Text = Convert.ToInt32(TablaProyeccion.Compute("sum(cantmod01)", "")).ToString();
                txt_cantmod02.Text = Convert.ToInt32(TablaProyeccion.Compute("sum(cantmod02)", "")).ToString();
                txt_cantmod03.Text = Convert.ToInt32(TablaProyeccion.Compute("sum(cantmod03)", "")).ToString();
                txt_cantmod04.Text = Convert.ToInt32(TablaProyeccion.Compute("sum(cantmod04)", "")).ToString();
                txt_cantmod05.Text = Convert.ToInt32(TablaProyeccion.Compute("sum(cantmod05)", "")).ToString();
                txt_cantmod06.Text = Convert.ToInt32(TablaProyeccion.Compute("sum(cantmod06)", "")).ToString();

                txt_canttotalcab.Text = Convert.ToInt32(TablaProyeccion.Compute("sum(canttotal)", "")).ToString();
                txt_totalprendascab.Text = Convert.ToInt32(TablaProyeccion.Compute("sum(totalprendas)", "")).ToString();
            }
        }

        private void Data_ProyDet(tb_me_proyeccion BE)
        {
            var rowproydet = TablaProyeccion.Select(" perianio ='" + BE.anio + "' and temporadaid = '"+BE.temporadaid+"' and canalventaid = '"+BE.canalventaid+"' and "+
                                                    " marcaid = '"+BE.marcaid+"' and lineaid = '"+BE.lineaid+"' and entalleid = '"+BE.entalleid+"' and generoid = '"+BE.generoid+"' and "+
                                                    " lineatelaid = '"+BE.lineatelaid+"' ");
            if (rowproydet.Length > 0)
            {
                foreach (DataRow row in rowproydet)
                {
                    cmb_marcaid.SelectedValue = row["marcaid"].ToString();
                    cmb_lineaid.SelectedValue = row["lineaid"].ToString();
                    cmb_entalleid.SelectedValue = row["entalleid"].ToString();
                    cmb_generoid.SelectedValue = row["generoid"].ToString();
                    cmb_lineatelaid.SelectedValue = row["lineatelaid"].ToString();

                    txt_01.Text = row["cantmod01"].ToString();
                    txt_02.Text = row["cantmod02"].ToString();
                    txt_03.Text = row["cantmod03"].ToString();
                    txt_04.Text = row["cantmod04"].ToString();
                    txt_05.Text = row["cantmod05"].ToString();
                    txt_06.Text = row["cantmod06"].ToString();

                    txt_totmodels.Text = row["canttotal"].ToString();
                    txt_profun.Text = row["profundidad"].ToString();
                    txt_totprendas.Text = row["totalprendas"].ToString();
                    
                    //btn_editar.Enabled = true;
                }
            }
        }

        private void cmb_perianio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_perianio.SelectedIndex != -1)
            {
                CargarDatos();
            }
        }

        private void cmb_temporadaid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_temporadaid.SelectedIndex != -1)
            {
                tb_pt_temporadaBL BL = new tb_pt_temporadaBL();
                tb_pt_temporada BE = new tb_pt_temporada();
                DataTable dt = new DataTable();
                BE.temporadaid = cmb_temporadaid.SelectedValue.ToString();

                try
                {
                    dt = BL.GetAll(EmpresaID, BE).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        lbl01.Text = dt.Rows[0]["mes01"].ToString();
                        lbl02.Text = dt.Rows[0]["mes02"].ToString();
                        lbl03.Text = dt.Rows[0]["mes03"].ToString();
                        lbl04.Text = dt.Rows[0]["mes04"].ToString();
                        lbl05.Text = dt.Rows[0]["mes05"].ToString();
                        lbl06.Text = dt.Rows[0]["mes06"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                CargarDatos();
            }
        }       

        private void txt_01_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { 
                txt_02.Focus();
                if (!String.IsNullOrEmpty(ActiveControl.Text))
                {
                    txt_02.SelectionStart = 0;
                    txt_02.SelectionLength = ActiveControl.Text.Length;
                }            
            }
        }

        void CalculoTotModelos()
        {
            Int32 n1=0,n2=0,n3=0,n4=0,n5=0,n6=0,tot=0;

            if (txt_01.Text.Length > 0)
                n1 = Convert.ToInt32(txt_01.Text);
            if (txt_02.Text.Length > 0)
                n2 = Convert.ToInt32(txt_02.Text);
            if (txt_03.Text.Length > 0)
                n3 = Convert.ToInt32(txt_03.Text);
            if (txt_04.Text.Length > 0)
                n4 = Convert.ToInt32(txt_04.Text);
            if (txt_05.Text.Length > 0)
                n5 = Convert.ToInt32(txt_05.Text);
            if (txt_06.Text.Length > 0)
                n6 = Convert.ToInt32(txt_06.Text);
            
            tot = n1 + n2 + n3 + n4 + n5 + n6;
            txt_totmodels.Text = tot.ToString();
        }

        private void txt_02_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_03.Focus();
                if (!String.IsNullOrEmpty(ActiveControl.Text))
                {
                    txt_03.SelectionStart = 0;
                    txt_03.SelectionLength = ActiveControl.Text.Length;
                }
            }
        }

        private void txt_03_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_04.Focus();
                if (!String.IsNullOrEmpty(ActiveControl.Text))
                {
                    txt_04.SelectionStart = 0;
                    txt_04.SelectionLength = ActiveControl.Text.Length;
                }
            }
        }

        private void txt_04_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_05.Focus();
                if (!String.IsNullOrEmpty(ActiveControl.Text))
                {
                    txt_05.SelectionStart = 0;
                    txt_05.SelectionLength = ActiveControl.Text.Length;
                }
            }
        }

        private void txt_05_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_06.Focus();
                if (!String.IsNullOrEmpty(ActiveControl.Text))
                {
                    txt_06.SelectionStart = 0;
                    txt_06.SelectionLength = ActiveControl.Text.Length;
                }
            }
        }

        private void txt_06_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)               
            {
                txt_profun.Focus();
                if (!String.IsNullOrEmpty(ActiveControl.Text))
                {
                    txt_profun.SelectionStart = 0;
                    txt_profun.SelectionLength = ActiveControl.Text.Length;
                }
            }
        }

        private void txt_01_KeyUp(object sender, KeyEventArgs e)
        {
            CalculoTotModelos();         
        }

        private void txt_02_KeyUp(object sender, KeyEventArgs e)
        {
            CalculoTotModelos();          
        }

        private void txt_03_KeyUp(object sender, KeyEventArgs e)
        {
            CalculoTotModelos();           
        }

        private void txt_04_KeyUp(object sender, KeyEventArgs e)
        {
            CalculoTotModelos();            
        }

        private void txt_05_KeyUp(object sender, KeyEventArgs e)
        {
            CalculoTotModelos();           
        }

        private void txt_06_KeyUp(object sender, KeyEventArgs e)
        {
            CalculoTotModelos();           
        }

        private void txt_profun_KeyUp(object sender, KeyEventArgs e)
        {
            Int32 num = 0,num2 = 0;
            if (txt_totmodels.Text.Length > 0)
                num = Convert.ToInt32(txt_totmodels.Text);
            
            if(txt_profun.Text.Length>0)
                num2 = Convert.ToInt32(txt_profun.Text);

            txt_totprendas.Text = (num * num2).ToString();
        }

        private void txt_01_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(ActiveControl.Text))
            {
                txt_01.SelectionStart = 0;
                txt_01.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void txt_02_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(ActiveControl.Text))
            {
                txt_02.SelectionStart = 0;
                txt_02.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void txt_03_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(ActiveControl.Text))
            {
                txt_03.SelectionStart = 0;
                txt_03.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void txt_04_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(ActiveControl.Text))
            {
                txt_04.SelectionStart = 0;
                txt_04.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void txt_05_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(ActiveControl.Text))
            {
                txt_05.SelectionStart = 0;
                txt_05.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void txt_06_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(ActiveControl.Text))
            {
                txt_06.SelectionStart = 0;
                txt_06.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void txt_profun_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(ActiveControl.Text))
            {
                txt_profun.SelectionStart = 0;
                txt_profun.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void btn_act_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }


        void CargarDatos()
        {
            if (cmb_perianio.SelectedIndex != -1 && cmb_temporadaid.SelectedIndex != -1 && cmb_canalvta.SelectedIndex != -1)
            {                
                tb_me_proyeccionBL BL = new tb_me_proyeccionBL();
                tb_me_proyeccion BE = new tb_me_proyeccion();
                DataTable dt = new DataTable();
                BE.anio = cmb_perianio.SelectedValue.ToString();
                BE.temporadaid = cmb_temporadaid.SelectedValue.ToString();
                BE.canalventaid = cmb_canalvta.SelectedValue.ToString();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    txt_cantmod01.Text = dt.Rows[0]["cantmod01"].ToString();
                    txt_cantmod02.Text = dt.Rows[0]["cantmod02"].ToString();
                    txt_cantmod03.Text = dt.Rows[0]["cantmod03"].ToString();
                    txt_cantmod04.Text = dt.Rows[0]["cantmod04"].ToString();
                    txt_cantmod05.Text = dt.Rows[0]["cantmod05"].ToString();
                    txt_cantmod06.Text = dt.Rows[0]["cantmod06"].ToString();

                    txt_totalprendascab.Text = dt.Rows[0]["totalprendas"].ToString();
                    txt_canttotalcab.Text = dt.Rows[0]["canttotal"].ToString();

                    rb_status.EditValue = dt.Rows[0]["status"].ToString();

                    CargamosDetalle(BE);
                    btn_editar.Enabled = true;
                }
                else
                {
                    nuevo2();
                }                
            }
        }


        void CargamosDetalle(tb_me_proyeccion BE)
        {
            tb_me_proyeccionBL BL = new tb_me_proyeccionBL();
            ArmadoTablasTmp();
            TablaProyeccion = BL.GetAll_DET(EmpresaID, BE).Tables[0];
            Mdi_dgv_proyeccion.DataSource = TablaProyeccion;
            CalculosTotales();
        }

        private void cmb_canalvta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_canalvta.SelectedIndex != -1)
            {
                CargarDatos();
            }
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            cmb_marcaid.SelectedIndex = -1;
            cmb_lineaid.SelectedIndex = -1;
            cmb_generoid.SelectedIndex = -1;
            cmb_entalleid.SelectedIndex = -1;
            cmb_lineatelaid.SelectedIndex = -1;

            //lbl01.Text = "_";
            //lbl02.Text = "_";
            //lbl03.Text = "_";
            //lbl04.Text = "_";
            //lbl05.Text = "_";
            //lbl06.Text = "_";
            txt_01.Text = "0";
            txt_02.Text = "0";
            txt_03.Text = "0";
            txt_04.Text = "0";
            txt_05.Text = "0";
            txt_06.Text = "0";
            txt_totmodels.Text = "0";
            txt_profun.Text = "0";
            txt_totprendas.Text = "0";
        }


    }
}
