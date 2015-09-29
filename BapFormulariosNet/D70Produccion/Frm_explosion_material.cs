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

// DevExpress
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Menu;


namespace BapFormulariosNet.D70Produccion
{
    public partial class Frm_explosion_materiales : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "";
        private String modulo = "";
        private String local = "";

        private String XNIVEL = "";
        private String XGLOSA = "";
        private String PERFILID = "";
        private DataRow row;
        private Boolean procesado = false;
        private String ActCtacte = "";
        private String ssModo = "";
   
        private DataTable TablaExplosion;


        public Frm_explosion_materiales()
        {
            InitializeComponent();
        }

        private void Frm_req_produccion_Load(object sender, EventArgs e)
        {
            if (Parent.Parent.Name == "MainProduccion")
            {
                dominio = ((D70Produccion.MainProduccion)MdiParent).dominioid;
                modulo = ((D70Produccion.MainProduccion)MdiParent).moduloid;
                local = ((D70Produccion.MainProduccion)MdiParent).local;
                PERFILID = ((D70Produccion.MainProduccion)MdiParent).perfil;
            }

            if (Parent.Parent.Name == "MainTienda")
            {
                dominio = ((D60Tienda.MainTienda)MdiParent).dominioid;
                modulo = ((D60Tienda.MainTienda)MdiParent).moduloid;
                local = ((D60Tienda.MainTienda)MdiParent).local;
                PERFILID = ((D60Tienda.MainTienda)MdiParent).perfil;
            }

            NIVEL_FORMS();
            limpiar_documento();
            //form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_salir.Enabled = true;                     
            TmpTablaOrdenProd();
            CargarCmbExplosion();
            CargarDatos();
           
        }



        void TmpTablaOrdenProd()
        {
            TablaExplosion = new DataTable();
            TablaExplosion.Columns.Add("orden", typeof(String));
            TablaExplosion.Columns.Add("articid", typeof(String));
            TablaExplosion.Columns.Add("articidold", typeof(String));
            TablaExplosion.Columns.Add("articname", typeof(String));
            TablaExplosion.Columns.Add("explosion", typeof(Boolean));
            TablaExplosion.Columns.Add("fecre", typeof(DateTime));
        }


        void CargarDatos()
        {
            tb_pp_ordenprodBL BL = new tb_pp_ordenprodBL();
            tb_pp_ordenprod BE = new tb_pp_ordenprod();

            if (cmb_explosion.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione Tipo", "Mensaje !!!");
                return;
            }
            else
            {
                BE.parameters = txt_busqueda.Text;
                BE.explosion = cmb_explosion.SelectedValue.ToString();
                TablaExplosion = BL.GetAll_Explosion(EmpresaID, BE).Tables[0];
                Mdi_dgv_explosion.DataSource = TablaExplosion;               
            }
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


        void CargarCmbExplosion()
        {
            DataTable dt;
            dt = new DataTable("Tabla");

            dt.Columns.Add("explosionid");
            dt.Columns.Add("explosionname");

            DataRow dr;

            dr = dt.NewRow();
            dr["explosionid"] = "0";
            dr["explosionname"] = "<< TODOS >>";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["explosionid"] = "1";
            dr["explosionname"] = "EXPLOTADOS";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["explosionid"] = "2";
            dr["explosionname"] = "NO EXPLOTADOS";
            dt.Rows.Add(dr);

            cmb_explosion.DataSource = dt;
            cmb_explosion.ValueMember = "explosionid";
            cmb_explosion.DisplayMember = "explosionname";
            cmb_explosion.SelectedIndex = 0;
        }


        private void btn_nuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XNIVEL == "0")
            {
                //nuevo();
              
                //if (TablaExplosion != null)
                //{
                //    TablaExplosion.Rows.Clear();
                //}            
            }
        }
      

        private void nuevo()
        {
            limpiar_documento();
            form_bloqueado(true);
            btn_nuevo.Enabled = false;        
            btn_cancelar.Enabled = true;         
            btn_log.Enabled = true;
            ssModo = "NEW";            
        }

        private void form_bloqueado(Boolean var)
        {
            try
            {
                txt_busqueda.Enabled = var;
                btn_buscar.Enabled = var;
                cmb_explosion.Enabled = var;

                btn_nuevo.Enabled = false;              
                btn_cancelar.Enabled = false;                      
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

        private void btn_cancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            form_accion_cancelEdicion(1);
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
                if (TablaExplosion.Rows.Count > 0)
                    TablaExplosion.Rows.Clear();

            }
        }

        private void limpiar_documento()
        {
            try
            {
                txt_busqueda.Text = "";                     
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }            

        private void btn_salir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
              
        private void btn_neo_Click(object sender, EventArgs e)
        {
            Popup.Frm_gen_explosion_materiales frm = new Popup.Frm_gen_explosion_materiales();
            frm.ShowDialog();
        }


        private void btn_ver_Click(object sender, EventArgs e)
        {
            Popup.Frm_detalle_explosion_material frm = new Popup.Frm_detalle_explosion_material();
            frm.ShowDialog();
        }     

        private void dgv_explosion_DoubleClick(object sender, EventArgs e)
        {                                    
            Popup.Frm_detalle_explosion_material frm = new Popup.Frm_detalle_explosion_material();
            frm.xtipop = "OP";
            frm.xserop = Equivalencias.Left(dgv_explosion.GetRowCellValue(dgv_explosion.FocusedRowHandle, "orden").ToString(), 4);
            frm.xnumop = Equivalencias.Right(dgv_explosion.GetRowCellValue(dgv_explosion.FocusedRowHandle, "orden").ToString(), 5).PadLeft(10,'0');
            frm.xarticid = dgv_explosion.GetRowCellValue(dgv_explosion.FocusedRowHandle, "articid").ToString();
            frm.xarticidold = dgv_explosion.GetRowCellValue(dgv_explosion.FocusedRowHandle, "articidold").ToString();
            frm.xarticname = dgv_explosion.GetRowCellValue(dgv_explosion.FocusedRowHandle, "articname").ToString();
            frm.ShowDialog();
        }

        private void txt_busqueda_KeyUp(object sender, KeyEventArgs e)
        {
            CargarDatos();
        }

        private void cmb_explosion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void Frm_explosion_materiales_Activated(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void dgv_explosion_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                e.Menu.Items.Add(new DXMenuItem("Generar Explosion", GenExplocion_Click));
            }           
        }
         
        void GenExplocion_Click(object sender, EventArgs e)
        {
            String xorden = dgv_explosion.GetRowCellValue(dgv_explosion.FocusedRowHandle, "orden").ToString();
            String xarticid = dgv_explosion.GetRowCellValue(dgv_explosion.FocusedRowHandle, "articid").ToString();
            String xversion = dgv_explosion.GetRowCellValue(dgv_explosion.FocusedRowHandle, "version").ToString();
            String xfecha = dgv_explosion.GetRowCellValue(dgv_explosion.FocusedRowHandle, "fecre").ToString();

            if (xfecha.Length > 0)
            {
                MessageBox.Show("Orden Ya Tiene Explosion ... Escoge Otra Orden", "Information", MessageBoxButtons.OK);
                return;
            }
            else
            {
                tb_pp_ordenprodBL BL = new tb_pp_ordenprodBL();
                tb_pp_ordenprod BE = new tb_pp_ordenprod();
                DataTable dt = new DataTable();

                try
                {
                    if (xversion.ToString().Length == 0)
                    {
                        MessageBox.Show("El Articulo no Tiene Una Receta", "Information", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        BE.tipop = "OP";
                        BE.serop = Equivalencias.Left(xorden, 4).ToString();
                        BE.numop = Equivalencias.Right(xorden, 4).PadLeft(10, '0').ToString();
                        BE.articid = xarticid.ToString();
                        BE.version = xversion.ToString();

                        if (BL.Gen_Explosion(EmpresaID, BE))
                        {
                            MessageBox.Show("Explosion Generado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarDatos();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        



    }
}
