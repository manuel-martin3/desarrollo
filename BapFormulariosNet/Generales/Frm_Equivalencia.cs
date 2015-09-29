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

namespace BapFormulariosNet.Generales
{
    public partial class Frm_Equivalencia : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = "";
        private String local = "";   

        String perianio = "";
        String perimes = "";

        String XNIVEL = "";
        String XGLOSA = "";
        String PERFILID = "";

        DataTable TablaEquivalencia;
        List<tb_cm_equivalencia> lista = null;
        Boolean fechadocedit = false;
        Boolean procesado = false;
        Boolean statusDoc = true;

        String ssModo = "";


        public Frm_Equivalencia()
        {
            InitializeComponent();
        }

        private void Frm_Equivalencia_Load(object sender, EventArgs e)
        {
            modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
            local = ((D60ALMACEN.MainAlmacen)MdiParent).local; 


            lista = new List<tb_cm_equivalencia>();
            data_TablaEquivalencia();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_primero.Enabled = true;
            btn_anterior.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_ultimo.Enabled = true;
            btn_buscar.Enabled = true;
            btn_salir.Enabled = true;
        }

        private void data_TablaEquivalencia()
        {
            try
            {
               
                tb_cm_equivalenciaBL equivalenciaBLL = new tb_cm_equivalenciaBL();
                tb_cm_equivalencia BE = new tb_cm_equivalencia();
             
                    BE.Equiv_name = txt_criterio.Text.Trim();

                    lista = equivalenciaBLL.Get_all(EmpresaID, BE);
                    gridviewEquivalencia.DataSource = lista;
                    //gridviewEquivalencia.Rows[0].Selected = false;
                    //gridviewEquivalencia.Focus();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region "Ayuda"
        private void AyudaUnidadMedida(String lpdescrlike)
        {
            try
            {
                Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql"; //sql,tabla
                frmayuda.titulo = "Ayuda Cliente/Proveedor";
                frmayuda.sqlquery = "select codigoid ,descripcion,sigla from tb_co_tabla06_unidadmedida";
                frmayuda.sqlinner = ""; //inner
                frmayuda.sqlwhere = "where"; //where
                frmayuda.sqland = "";//and
                frmayuda.criteriosbusqueda = new string[] { "DESCRIPCION", "CODIGO" };
                frmayuda.columbusqueda = "descripcion,codigoid";
                frmayuda.returndatos = "0,2,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeGrupo;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        private void AyudaUnidadMedida2(String lpdescrlike)
        {
            try
            {
                Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql"; //sql,tabla
                frmayuda.titulo = "Ayuda Cliente/Proveedor";
                frmayuda.sqlquery = "select codigoid ,descripcion,sigla from tb_co_tabla06_unidadmedida";
                frmayuda.sqlinner = ""; //inner
                frmayuda.sqlwhere = "where"; //where
                frmayuda.sqland = "";//and
                frmayuda.criteriosbusqueda = new string[] { "DESCRIPCION", "CODIGO" };
                frmayuda.columbusqueda = "descripcion,codigoid";
                frmayuda.returndatos = "0,2,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeGrupo2;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }
        private void RecibeGrupo(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                txtcodigoUM.Text = resultado1.Trim();
                txtdescripcionUM.Text = resultado3.Trim();
            }
        }
        private void RecibeGrupo2(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                txtcodigoUM2.Text = resultado1.Trim();
                txtdescripcionUM2.Text = resultado3.Trim();
            }
        }
        #endregion

        private void txtcodigoUM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaUnidadMedida("");
            }
        }

        private void txtcodigoUM2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaUnidadMedida2("");
                unidmname.Text = txtdescripcionUM.Text.ToUpper().Trim() + " A " + txtdescripcionUM2.Text.ToUpper().Trim();
            }
        }

        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            data_TablaEquivalencia();
        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {
            procesado = false;
            bool sw_prosigue = false;
            if (ssModo == "NEW")
            {
                Insert();
            }
            else
            {                
                sw_prosigue = (MessageBox.Show("¿Desea Modificar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                if (sw_prosigue)
                {
                    Update();
                }                
            }

            if (procesado)
            {
                NIVEL_FORMS();
                data_TablaEquivalencia();
                form_bloqueado(false);

                btn_nuevo.Enabled = true;
                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;
                btn_buscar.Enabled = true;
                btn_salir.Enabled = true;
            }
        }

        #region "Metodos"
        private void Insert()
        {
            try
            {
               
                if (unidmname.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese unidad de medida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    tb_cm_equivalenciaBL BL= new tb_cm_equivalenciaBL();
                    tb_cm_equivalencia BE = new tb_cm_equivalencia();

                    //BE.codigoid = undcodigoid.Text.Trim().ToUpper();
                    BE.Unmed1 = txtcodigoUM.Text.ToUpper();
                    BE.Unmed2 = txtcodigoUM2.Text.ToUpper();                    
                    BE.Equiv_name = unidmname.Text.Trim().ToUpper();                    
                    BE.Equivalencia = Equivalencias.getDecimal(txtEquivalencia.Text.ToUpper());
                    if (BL.Insert(EmpresaID, BE))
                    {
                        //txtcodigo.Text = Equivalencias.getValue( BE.Equiv_id);
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
                
                if (unidmname.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese unidad de medida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    tb_cm_equivalenciaBL BL = new tb_cm_equivalenciaBL();
                    tb_cm_equivalencia BE = new tb_cm_equivalencia();
                    BE.Equiv_id= Equivalencias.getInt(txtcodigo.Text );
                    BE.Equiv_name = unidmname.Text.Trim().ToUpper();
                    BE.Unmed1 = txtcodigoUM.Text.ToUpper();
                    BE.Unmed2 = txtcodigoUM2.Text.ToUpper();
                    BE.Equivalencia = Equivalencias.getDecimal(txtEquivalencia.Text.ToUpper());

                    if (BL.Update(EmpresaID, BE))
                    {
                       
                        MessageBox.Show("Datos modificado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                tb_cm_equivalenciaBL BL = new tb_cm_equivalenciaBL();
                tb_cm_equivalencia BE = new tb_cm_equivalencia();
                BE.Equiv_id = Equivalencias.getInt(txtcodigo.Text.ToUpper());


                if (BL.Delete(EmpresaID, BE))
                {

                    MessageBox.Show("Datos eliminado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NIVEL_FORMS();
                    limpiar_documento();
                    form_bloqueado(false);
                    data_TablaEquivalencia();
                    btn_nuevo.Enabled = true;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void data_equivalencia(tb_cm_equivalencia xcodigoid)
        {
            form_bloqueado(false);
            tb_cm_equivalenciaBL equivalenciaBLL = new tb_cm_equivalenciaBL();
            tb_cm_equivalencia BE = new tb_cm_equivalencia();


            lista = equivalenciaBLL.Get_xcodigo(EmpresaID, xcodigoid);
            if (lista.Count > 0)
            {
                foreach (tb_cm_equivalencia row in lista)
                {
                    txtcodigo.Text = Equivalencias.getValue(row.Equiv_id);
                    unidmname.Text = row.Equiv_name;
                    txtEquivalencia.Text = Equivalencias.getValue(row.Equivalencia);
                    txtcodigoUM.Text = row.Unmed1;
                    txtcodigoUM2.Text = row.Unmed2;
                    txtdescripcionUM.Text = row.descripcion1;
                    txtdescripcionUM2.Text = row.descripcion2;
                }
            }


            btn_nuevo.Enabled = true;
            btn_editar.Enabled = true;
            btn_eliminar.Enabled = true;
            btn_imprimir.Enabled = true;

            btn_primero.Enabled = true;
            btn_anterior.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_ultimo.Enabled = true;

            btn_buscar.Enabled = true;
            btn_log.Enabled = true;
            btn_salir.Enabled = true;

        }
        #endregion


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

        private void gridviewEquivalencia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridviewEquivalencia.CurrentRow != null)
                {
                   
                    tb_cm_equivalencia _equivalencia =new tb_cm_equivalencia();

                    _equivalencia.Equiv_id = Equivalencias.getInt(gridviewEquivalencia.Rows[e.RowIndex].Cells["equiv_id"].Value);
                    data_equivalencia(_equivalencia);
                }
            }
            catch (Exception ex)
            {
            }
        }

        

        private void form_bloqueado(Boolean var)
        {
            try
            {

                txtcodigo.ReadOnly = true;
                unidmname.Enabled = var;

                txtEquivalencia.Enabled = var;
                txtdescripcionUM.Enabled = var;
                txtdescripcionUM2.Enabled = var;

                fechadoc.Enabled = false;

                gridviewEquivalencia.ReadOnly = true;
                gridviewEquivalencia.Enabled = !var;
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

                btn_buscar.Enabled = false;
                btn_clave.Enabled = true;
                btn_log.Enabled = true;
                btn_salir.Enabled = false;
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
                fechadoc.Value = DateTime.Today;
                txtcodigo.Text = "";
                txtEquivalencia.Text = "";
                unidmname.Text = "";
                txtcodigoUM.Text = "";
                txtcodigoUM2.Text = "";
                txtdescripcionUM.Text = "";
                txtdescripcionUM2.Text = "";
              
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

            unidmname.Enabled = true;

            txtEquivalencia.Enabled = true;
            txtcodigoUM.Focus();
            ssModo = "NEW";
         }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {

            form_accion_cancelEdicion(1);
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
                txtcodigo.Text = "";
                btn_nuevo.Enabled = true;
                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;
                btn_buscar.Enabled = true;
                btn_salir.Enabled = true;
    
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            ssModo = "EDIT";
            form_bloqueado(true);
            unidmname.Focus();
            txtdescripcionUM.Enabled = false;
            txtdescripcionUM2.Enabled = false;
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
           
                bool sw_prosigue = false;
                sw_prosigue = (MessageBox.Show("¿Desea Eliminar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                if (sw_prosigue)
                {
                    Delete();
                }
            
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txt_criterio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                data_TablaEquivalencia();
            }
        }

        private void gridviewEquivalencia_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridviewEquivalencia[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            gridviewEquivalencia[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            gridviewEquivalencia.EnableHeadersVisualStyles = false;
            gridviewEquivalencia.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            gridviewEquivalencia.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void gridviewEquivalencia_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            gridviewEquivalencia[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }

        
    }

}
