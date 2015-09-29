using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.APT600100.CATALOGO
{
    public partial class Frm_vendedores : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable TablaVendedor;
        private Boolean procesado = false;
        private String xapepat, xapemat, xnombres = "";

        private String ssModo = "NEW";

        public Frm_vendedores()
        {
            InitializeComponent();            
        }

        private void PARAMETROS_TABLA()
        {
            var xxferfil = string.Empty;
            var f = (MainAlmacenPT)MdiParent;
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
                txtvendorid.Enabled = false;
                txtapemat.Enabled = var;
                txtapepat.Enabled = var;
                txtnombres.Enabled = var;
                txtNombrelargo.Enabled = false;
                txtdni.Enabled = var;
                txtruc.Enabled = var;
                txtcanalvtaid.Enabled = var;
                txttelefono.Enabled = var;
                txtcanalvtaname.Enabled = false;                
                txtdireccion.Enabled = var;

                fIngreso.Enabled = var;
                fCese.Enabled = var;
                txtmotcese.Enabled = var;
                txtusuarweb.Enabled = var;

                dgb_vendedores.ReadOnly = true;
                dgb_vendedores.Enabled = !var;
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
                txtvendorid.Text = string.Empty;
                btn_nuevo.Enabled = true;
           
                btn_salir.Enabled = true;

                ssModo = "NEW";
            }
        }

        private void form_cargar_datos(String posicion)
        {
            try
            {
                var BL = new tb_cxc_vendorBL();
                var BE = new tb_cxc_vendor();
                var dt = new DataTable();
                              
                BE.vendorid = txtvendorid.Text.Trim().PadLeft(4, '0');               
                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    limpiar_documento();
                    ssModo = "EDIT";

                    txtvendorid.Text = dt.Rows[0]["grupoid"].ToString().Trim();
                    //gruponame.Text = dt.Rows[0]["gruponame"].ToString().Trim();
                    //ctacte.Text = dt.Rows[0]["ctacte"].ToString().Trim();
                    //ctactename.Text = dt.Rows[0]["ctactename"].ToString().Trim();

                    btn_editar.Enabled = true;
                    btn_eliminar.Enabled = true;
                    btn_imprimir.Enabled = true;
                

                    btn_log.Enabled = true;
                    btn_salir.Enabled = true;
                }
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

        private void AyudaClientes(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "Ayuda Proveedor";
                frmayuda.sqlquery = "select ctacte, ctactename, nmruc, direc from tb_cliente";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where";
                frmayuda.sqland = string.Empty;
                frmayuda.criteriosbusqueda = new string[] { "CLIENTE", "RUC", "CODIGO" };
                frmayuda.columbusqueda = "ctactename,nmruc,ctacte";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeClientes;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
        private void RecibeClientes(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                //ctacte.Text = resultado1.Trim();
                //ctactename.Text = resultado2.Trim();
                //gruponame.Text = resultado2.Trim();
            }
        }

        private void SEGURIDAD_LOG(String accion)
        {
            var xclave = VariablesPublicas.EmpresaID + "/" + ((APT600100.MainAlmacenPT)MdiParent).perianio;
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
                //BE.detalle = grupoid.Text.Trim() + "/" + gruponame.Text.Trim().ToUpper() + "/" + XGLOSA;

                BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiar_documento()
        {           
            txtvendorid.Text = "";
            txtapepat.Text = "";
            txtapemat.Text = "";
            txtnombres.Text = "";
            txtNombrelargo.Text = "";
            txtdni.Text = "";
            txtruc.Text = "";
            txttelefono.Text = "";
            txtcanalvtaid.Text = "";
            txtcanalvtaname.Text = "";
            txtdireccion.Text = "";
            fIngreso.Checked = false;
            fCese.Checked = false;
            txtmotcese.Text = "";
            txtusuarweb.Text = "";
        }

        private void nuevo()
        {
            limpiar_documento();
            form_bloqueado(true);
            txtvendorid.Text = "NEW";
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_log.Enabled = true;
            txtapepat.Focus();
            ssModo = "NEW";
        }


        private Boolean ValidaDatos()
        {
            Boolean val = true;

            if (txtNombrelargo.Text.Length == 0)
            {
                MessageBox.Show("Falta Ingresar Nombre del Vendedor !!!","Mensaje");
                val = false;
            }
            else
                if (txtcanalvtaid.Text.Length == 0)
                {
                    MessageBox.Show("Falta Ingresar Canal de Venta !!!", "Mensaje");
                    val = false; 
                }

            return val;
        }


        private void Insert()
        {
            try
            {
                if (ValidaDatos())
                {           
                    var BL = new tb_cxc_vendorBL();
                    var BE = new tb_cxc_vendor();

                    BE.vendorname = txtNombrelargo.Text.ToUpper();
                    BE.ddnni = txtdni.Text.Trim();
                    BE.nmruc = txtruc.Text.Trim();
                    BE.telefono = txttelefono.Text.Trim();
                    BE.canalventaid = txtcanalvtaid.Text;
                    BE.direccion = txtdireccion.Text.ToUpper();
                    if(fIngreso.Checked) 
                        BE.fech_ingre = Convert.ToDateTime(fIngreso.Text);
                    if (fCese.Checked) 
                        BE.fech_cese = Convert.ToDateTime(fCese.Text);
                    BE.motivocese = txtmotcese.Text;
                    BE.usuarweb = txtusuarweb.Text.ToUpper();

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
                if (ValidaDatos())
                {          
                    var BL = new tb_cxc_vendorBL();
                    var BE = new tb_cxc_vendor();
                    BE.vendorid = txtvendorid.Text.Trim();
                    BE.vendorname = txtNombrelargo.Text.ToUpper();
                    BE.ddnni = txtdni.Text.Trim();
                    BE.nmruc = txtruc.Text.Trim();
                    BE.telefono = txttelefono.Text.Trim();
                    BE.canalventaid = txtcanalvtaid.Text;
                    BE.direccion = txtdireccion.Text.ToUpper();
                    if (fIngreso.Checked)
                        BE.fech_ingre = Convert.ToDateTime(fIngreso.Text);
                    if (fCese.Checked)
                        BE.fech_cese = Convert.ToDateTime(fCese.Text);
                    BE.motivocese = txtmotcese.Text;
                    BE.usuarweb = txtusuarweb.Text.ToUpper();

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
                if (txtvendorid.Text.Trim().Length != 4)
                {
                    MessageBox.Show("Falta Codigo Vendedor !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_cxc_vendorBL();
                    var BE = new tb_cxc_vendor();
                    BE.vendorid = txtvendorid.Text;                   
                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos Eliminado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        limpiar_documento();
                        form_bloqueado(false);
                        data_TablaVendedor();
                        btn_nuevo.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_vendedores_Activated(object sender, EventArgs e)
        {

        }

        void ValidaCanalVta(String xcanal)
        {
            tb_cp_canalventaBL BL = new tb_cp_canalventaBL();
            tb_cp_canalventa BE = new tb_cp_canalventa();
            DataTable dt = new DataTable();
            BE.canalventaid = xcanal;
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                txtcanalvtaname.Text = dt.Rows[0]["canalventaname"].ToString();
            }

        }

        

        private void Frm_vendedores_Load(object sender, EventArgs e)
        {
            modulo = ((APT600100.MainAlmacenPT)MdiParent).moduloid;
            local = ((APT600100.MainAlmacenPT)MdiParent).local;

            PARAMETROS_TABLA();
            NIVEL_FORMS();

            TablaVendedor = new DataTable();

            limpiar_documento();
            data_TablaVendedor();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;         
            btn_salir.Enabled = true;
        }

        private void Frm_vendedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
            }

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
               // gruponame.Focus();

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
                    sw_prosigue = (MessageBox.Show("¿Desea Modificar Documento Actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                    if (sw_prosigue)
                    {
                        Update();
                    }
                }
            }

            if (procesado)
            {
                NIVEL_FORMS();
                data_TablaVendedor();
                form_bloqueado(false);
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
                if (TablaVendedor.Rows.Count > 0)
                {
                    var miForma = new REPORTES.Frm_reportes();

                    miForma.dominioid = dominio.Trim();
                    miForma.moduloid = modulo.Trim();
                    miForma.local = local.Trim();

                    miForma.Text = "Reporte de grupos";
                    miForma.formulario = "Frm_vendedores";
                    miForma.ShowDialog();
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
            var oform = new Seguridadlog.FrmSeguridad();
            var xclave = VariablesPublicas.EmpresaID + "/" + ((APT600100.MainAlmacenPT)MdiParent).perianio;
            oform._Nombre = Name;
            oform._ClaveForm = xclave;
            oform.Owner = this;
            oform.ShowDialog();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void data_TablaVendedor()
        {            
            if (TablaVendedor.Rows.Count > 0)
            {
                TablaVendedor.Rows.Clear();
            }
            var BL = new tb_cxc_vendorBL();
            var BE = new tb_cxc_vendor();
              
            BE.parameters = txtbusqueda.Text.Trim().ToUpper();
            TablaVendedor = BL.GetAll(EmpresaID, BE).Tables[0];
            if (TablaVendedor.Rows.Count > 0)
            {
                btn_imprimir.Enabled = true;
                dgb_vendedores.DataSource = TablaVendedor;
                dgb_vendedores.Rows[0].Selected = false;               
            }           
        }

        private void dgb_vendedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgb_vendedores.CurrentRow != null)
            {
                var xvendorid = string.Empty;
                xvendorid = dgb_vendedores.Rows[e.RowIndex].Cells["vendorid"].Value.ToString().Trim();
                data_Vendedor(xvendorid);
            }
        }

        private void dgb_vendedores_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xvendorid = string.Empty;
                xvendorid = dgb_vendedores.Rows[dgb_vendedores.CurrentRow.Index].Cells["vendorid"].Value.ToString().Trim();
                data_Vendedor(xvendorid);
            }
        }

        private void dgb_vendedores_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgb_vendedores[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            dgb_vendedores[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            dgb_vendedores.EnableHeadersVisualStyles = false;
            dgb_vendedores.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            dgb_vendedores.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void dgb_vendedores_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dgb_vendedores[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }

        private void data_Vendedor(String xvendorid)
        {
            form_bloqueado(false);
            var rowvendorid = TablaVendedor.Select("vendorid='" + xvendorid + "'");
            if (rowvendorid.Length > 0)
            {
                foreach (DataRow row in rowvendorid)
                {
                    txtvendorid.Text = row["vendorid"].ToString().Trim();
                    txtNombrelargo.Text = row["vendorname"].ToString().Trim();
                    txtdni.Text = row["ddnni"].ToString().Trim();
                    txtruc.Text = row["nmruc"].ToString().Trim();
                    txtcanalvtaid.Text = row["canalventaid"].ToString().Trim();
                    ValidaCanalVta(txtcanalvtaid.Text.Trim());
                    //txtcanalvtaname.Text = row["canalventaid"].ToString().Trim();
                    txtdireccion.Text = row["direccion"].ToString().Trim();
                    fIngreso.Text = row["fech_ingre"].ToString().Trim();
                    fCese.Text = row["fech_cese"].ToString().Trim();
                    txtmotcese.Text = row["motivocese"].ToString().Trim();
                    txttelefono.Text = row["telefonos"].ToString().Trim();
                    txtusuarweb.Text = row["usuarweb"].ToString().Trim();
                }

                btn_nuevo.Enabled = true;
                btn_editar.Enabled = true;
                btn_eliminar.Enabled = true;
                btn_imprimir.Enabled = true;            
                btn_log.Enabled = true;
                btn_salir.Enabled = true;
            }
        }

        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            data_TablaVendedor();
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
            data_TablaVendedor();
        }

        private void txtcanalvtaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaCanalVenta("");
            }
        }

        private void AyudaCanalVenta(String lpdescrlike)
        {
            try
            {
                Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all"; //sql,tabla
                frmayuda.titulo = "<< AYUDA TABLA CANAL VENTA >>";
                frmayuda.sqlquery = "SELECT canalventaid,canalventaname FROM tb_cp_canalventa ";
                frmayuda.sqlinner = ""; //inner
                frmayuda.sqlwhere = "WHERE LEN(canalventaid) = 3"; //where
                frmayuda.sqland = "and";//and
                frmayuda.criteriosbusqueda = new string[] { "CODIGO", "CANAL" };
                frmayuda.columbusqueda = "canalventaid,canalventaname";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeCanalVenta;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }


        private void RecibeCanalVenta(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                txtcanalvtaid.Text = resultado1.Trim();
                txtcanalvtaname.Text = resultado2.Trim();              
            }
        }

        private void ArmarNombre()
        {
            txtNombrelargo.Text = txtapepat.Text.Trim() + " " + txtapemat.Text.Trim() +" , "+ txtnombres.Text.Trim();
        }      

        private void txtapemat_KeyUp(object sender, KeyEventArgs e)
        {
            ArmarNombre();
        }

        private void txtnombres_KeyUp(object sender, KeyEventArgs e)
        {
            ArmarNombre();
        }

        private void txtapepat_KeyUp(object sender, KeyEventArgs e)
        {
            ArmarNombre();
        }

    }
}
