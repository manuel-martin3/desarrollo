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
    public partial class Frm_vendedor : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable TablaVendedor;
        private DataTable TablaVendedorDet;

        private Decimal _xtipocambio;
        private Boolean procesado = false;
        private String ssModo = string.Empty;

        public Frm_vendedor()
        {
            InitializeComponent();
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
                txt_vendorid.Enabled = false;
                txt_vendorname.Enabled = false;
                txt_apepat.Enabled = var;
                txt_apemat.Enabled = var;
                txt_nombre.Enabled = var;
                txt_dni.Enabled = var;
                txt_telefono.Enabled = var;
                txt_direcc.Enabled = var;
                txt_fechnac.Enabled = var;
                txt_fechini.Enabled = var;

                txt_local.Enabled = var;
                txt_localname.Enabled = false;
                txt_fechasig.Enabled = var;
                txt_fechcese.Enabled = var;
                txt_cargoid.Enabled = var;
                txt_cargoname.Enabled = false;
                txt_remunebas.Enabled = var;
                rb_sexo.Enabled = var;
                chk_conhijos.Enabled = var;
                chk_comisiona.Enabled = var;
                txt_observ.Enabled = var;

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
                txt_vendorid.Text = "";
                txt_vendorname.Text = "";
                txt_apepat.Text = "";
                txt_apemat.Text = "";
                txt_nombre.Text = "";
                txt_dni.Text = "";
                txt_telefono.Text = "";
                txt_direcc.Text = "";
                txt_fechnac.Text = "";
                txt_fechini.Text = "";
                
                txt_local.Text = "";
                txt_localname.Text = "";
                txt_fechasig.Text = "";
                txt_fechcese.Text = "";
                txt_cargoid.Text = "";
                txt_cargoname.Text = "";
                txt_remunebas.Text = "";
                txt_observ.Text = "";
                rb_sexo.EditValue = null;
                chk_conhijos.Checked = false;
                chk_comisiona.Checked = false;                
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
            txt_apepat.Focus();
            ssModo = "NEW";
        }

        private void Nuevo2(Boolean var)
        {
           
                 
            btn_cancelar.Enabled = true;
            ssModo = "NEW";
        }

        
        Boolean U_Validacion()
        {
            Boolean var = true;
            if (txt_vendorname.Text.Length == 0)
            {
                var = false;
                MessageBox.Show("Ingrese Nombre de Vendedor","Mensaje");
            }
            if (txt_dni.Text.Length != 8)
            {
                var = false;
                MessageBox.Show("Ingrese DNI de Vendedor","Mensaje");
            }
            if (txt_local.Text.Length != 3)
            {
                var = false;
                MessageBox.Show("Ingrese Local a Asignarle", "Mensaje");
            }
            if (txt_cargoid.Text.Length != 3)
            {
                var = false;
                MessageBox.Show("Ingrese Cargo del Vendedor", "Mensaje");
            }
            if (txt_remunebas.Text.Length == 0)
            {
                var = false;
                MessageBox.Show("Ingrese Remuneración Básica", "Mensaje");
            }
            if (txt_fechini.Text.Length == 0)
            {
                var = false;
                MessageBox.Show("Ingrese Fecha de Registro", "Mensaje");
            }
            if (txt_fechasig.Text.Length == 0)
            {
                var = false;
                MessageBox.Show("Ingrese Fecha de Asignación", "Mensaje");
            }

            return var;
        }

        private void Insert()
        {
            try
            {
                if (U_Validacion())
                {
                    // CLASES PARA LA INSERCION DE VENDEDORES
                    var BL = new tb_me_vendedorBL();
                    var BE = new tb_me_vendedor();

                    // CLASES PARA EL LLAMADO DEL INSERCION DE RRHH
                    rrhh_personalBL BLR = new rrhh_personalBL();
                    tb_rrhh_personal BER = new tb_rrhh_personal();

                    BE.vendorname = txt_vendorname.Text.Trim().ToUpper();
                    BE.appat = txt_apepat.Text.ToUpper();
                    BE.apmat = txt_apemat.Text.ToUpper();
                    BE.nombre = txt_nombre.Text.ToUpper();
                    BE.ddnni = txt_dni.Text.Trim();
                    BE.direcc = txt_direcc.Text.Trim();
                    if (txt_fechnac.Text.Length > 0)
                        BE.fechnac = Convert.ToDateTime(txt_fechnac.Text);
                    BE.local = txt_local.Text.Trim();
                    if (txt_fechini.Text.Length > 0)
                        BE.fechini = Convert.ToDateTime(txt_fechini.Text);
                    if (txt_fechcese.Text.Length > 0)
                        BE.fechcese = Convert.ToDateTime(txt_fechcese.Text);
                    BE.telefono = txt_telefono.Text;
                    BE.remunebas = Convert.ToDecimal(txt_remunebas.Text);
                    BE.cargoid = txt_cargoid.Text.Trim();
                    if (txt_fechasig.Text.Length > 0)
                        BE.fechasig = Convert.ToDateTime(txt_fechasig.Text);
                    BE.sexo = rb_sexo.EditValue.ToString();
                    BE.conhijos = chk_conhijos.Checked;
                    BE.comisiona = chk_comisiona.Checked;
                    BE.observac = txt_observ.Text.Trim();
                    BE.status = "0";
                    BE.usuar = VariablesPublicas.Usuar.Trim().ToUpper();

                    String xxMessage = "";

                    if (BL.Insert(EmpresaID, BE))
                    {
                        xxMessage = "1";
                        // Verificamos en el Datapi Si Existe un Personal con el Dni
                        if (SearchWebDNI() > 0)
                        {
                            if (UpdateWeb())
                            {
                                xxMessage = xxMessage + " / 2";
                            }
                        }
                        else 
                        {
                            if (InsertWeb())
                            {
                                xxMessage = xxMessage + " / 2";
                            }
                        }
                        MessageBox.Show("Datos  " + xxMessage + " Grabados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        procesado = true;
                    }
                }                               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }      

        private Boolean InsertWeb()
        {
            Boolean result = false;

            rrhh_personalBL BL = new rrhh_personalBL();
            tb_rrhh_personal BE = new tb_rrhh_personal();

            BE.empresaid = EmpresaID.ToString();
            BE.DDNNI = txt_dni.Text.Trim();
            BE.APPAT = txt_apepat.Text.Trim().ToUpper();
            BE.APMAT = txt_apemat.Text.Trim().ToUpper();
            BE.NOMBR = txt_nombre.Text.Trim().ToUpper();
            BE.NOMBS = txt_vendorname.Text.Trim().ToUpper();
            if (txt_fechnac.Text.Length > 0)
                BE.FENAC = Convert.ToDateTime(txt_fechnac.Text);
            BE.UBIGE = "150101"; // LIMA
            BE.IDEDU = "09";     // EDUCACION TECNICA COMPLETA
            BE.ECIVI = "1";      // SOLTERO
            if (txt_fechini.Text.Length > 0)
                BE.FEING = Convert.ToDateTime(txt_fechini.Text);              
            BE.DIREC = txt_direcc.Text.Trim().ToUpper();
            BE.TELEF = txt_telefono.Text.Trim().ToUpper();

            // NO PASO IDCC2 PORQUE DESDE BD LO VALIDO EN CAMBIO DE ESO MANDO OTRO PARAMETRO @idold
            //BE.IDCC2 = Equivalencias.Right(txt_local.Text,2).Trim();
            BE.idold = Equivalencias.Right(txt_local.Text, 2).Trim();

            BE.BASIC = Convert.ToDouble(txt_remunebas.Text);              
            BE.ASFAM = "N";
            BE.IDAFP = "99";
            BE.NMAFI = "";
            if (txt_fechcese.Text.Length > 0)
                BE.IDSIT = "13"; // CESADO
            else
                BE.IDSIT = "11"; // ACTIVO SUBSIDIADO 

            if (txt_fechcese.Text.Length > 0)
                BE.FECES = Convert.ToDateTime(txt_fechcese.Text);

            if (rb_sexo.EditValue.ToString() == "M")
                BE.SEXXO = "1";
            else
                BE.SEXXO = "2";                
            BE.IDTUR = "01";
            BE.USUAR = VariablesPublicas.Usuar.Trim();
            BE.FEACT = System.DateTime.Now.Date;                
            BE.IDOCU = "572037"; // VENDEDOR, PRENDAS DE VESTIR
            BE.PAISS = "9589";   // PERU
            BE.flvis = false;

            try
            {
                result = BL.Insert(EmpresaID, BE);                                  
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            return result;

        }

        private Boolean UpdateWeb()
        {
            Boolean result = false;

            rrhh_personalBL BL = new rrhh_personalBL();
            tb_rrhh_personal BE = new tb_rrhh_personal();

            BE.empresaid = EmpresaID.ToString();
            BE.DDNNI = txt_dni.Text.Trim();
            BE.APPAT = txt_apepat.Text.Trim().ToUpper();
            BE.APMAT = txt_apemat.Text.Trim().ToUpper();
            BE.NOMBR = txt_nombre.Text.Trim().ToUpper();
            BE.NOMBS = txt_vendorname.Text.Trim().ToUpper();
            if (txt_fechnac.Text.Length > 0)
                BE.FENAC = Convert.ToDateTime(txt_fechnac.Text);
            BE.UBIGE = "150101"; // LIMA
            BE.IDEDU = "09";     // EDUCACION TECNICA COMPLETA
            BE.ECIVI = "1";      // SOLTERO
            if (txt_fechini.Text.Length > 0)
                BE.FEING = Convert.ToDateTime(txt_fechini.Text);
            BE.DIREC = txt_direcc.Text.Trim().ToUpper();
            BE.TELEF = txt_telefono.Text.Trim().ToUpper();

            // NO PASO IDCC2 PORQUE DESDE BD LO VALIDO EN CAMBIO DE ESO MANDO OTRO PARAMETRO @idold
            //BE.IDCC2 = Equivalencias.Right(txt_local.Text,2).Trim();
            BE.idold = Equivalencias.Right(txt_local.Text, 2).Trim();

            BE.BASIC = Convert.ToDouble(txt_remunebas.Text);
            BE.ASFAM = "N";
            BE.IDAFP = "99";
            BE.NMAFI = "";
            if (txt_fechcese.Text.Length > 0)
                BE.IDSIT = "13"; // CESADO
            else
                BE.IDSIT = "11"; // ACTIVO SUBSIDIADO 

            if (txt_fechcese.Text.Length > 0)
                BE.FECES = Convert.ToDateTime(txt_fechcese.Text);

            if (rb_sexo.EditValue.ToString() == "M")
                BE.SEXXO = "1";
            else
                BE.SEXXO = "2";
            BE.IDTUR = "01";
            BE.USUAR = VariablesPublicas.Usuar.Trim();
            BE.FEACT = System.DateTime.Now.Date;
            BE.IDOCU = "572037"; // VENDEDOR, PRENDAS DE VESTIR
            BE.PAISS = "9589";   // PERU
            BE.flvis = false;

            try
            {
                result = BL.Update3(EmpresaID, BE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        private Int32 SearchWebDNI()
        {
            Int32 num = 0;
            rrhh_personalBL BL = new rrhh_personalBL();           
            DataTable dt = new DataTable();            
            dt = BL.GetOne(EmpresaID, txt_dni.Text.Trim()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                num = dt.Rows.Count;
            }
            return num;
        }


        private void Update()
        {
            try
            {
                if (U_Validacion())
                {
                    var BL = new tb_me_vendedorBL();
                    var BE = new tb_me_vendedor();

                    BE.vendorid = txt_vendorid.Text.Trim();
                    BE.vendorname = txt_vendorname.Text.Trim().ToUpper();
                    BE.appat = txt_apepat.Text.ToUpper();
                    BE.apmat = txt_apemat.Text.ToUpper();
                    BE.nombre = txt_nombre.Text.ToUpper();
                    BE.ddnni = txt_dni.Text.Trim();
                    BE.direcc = txt_direcc.Text.Trim();
                    if (txt_fechnac.Text.Length > 0)
                        BE.fechnac = Convert.ToDateTime(txt_fechnac.Text);
                    BE.local = txt_local.Text.Trim();
                    if (txt_fechini.Text.Length > 0)
                        BE.fechini = Convert.ToDateTime(txt_fechini.Text);
                    if (txt_fechcese.Text.Length > 0)
                        BE.fechcese = Convert.ToDateTime(txt_fechcese.Text);
                    BE.telefono = txt_telefono.Text;
                    BE.remunebas = Convert.ToDecimal(txt_remunebas.Text);
                    BE.cargoid = txt_cargoid.Text.Trim();
                    if (txt_fechasig.Text.Length > 0)
                        BE.fechasig = Convert.ToDateTime(txt_fechasig.Text);
                    BE.sexo = rb_sexo.EditValue.ToString();
                    BE.conhijos = chk_conhijos.Checked;
                    BE.comisiona = chk_comisiona.Checked;
                    BE.observac = txt_observ.Text.Trim();
                    BE.status = "0";
                    BE.usuar = VariablesPublicas.Usuar.Trim().ToUpper();

                    String xxMessage ="";
                    if (BL.Update(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("M");
                        xxMessage = " 1";

                        // Verificamos en el Datapi Si Existe un Personal con el Dni
                        if (SearchWebDNI() > 0)
                        {
                            if (UpdateWeb())
                            {
                                xxMessage = xxMessage + " / 2";
                            }
                        }
                        else
                        {
                            if (InsertWeb())
                            {
                                xxMessage = xxMessage + " / 2";
                            }
                        }

                        MessageBox.Show("Datos " + xxMessage + " Modificados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (U_Validacion())
                {
                    var BL = new tb_me_vendedorBL();
                    var BE = new tb_me_vendedor();

                    BE.vendorid = txt_vendorid.Text.Trim();

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

        private void Frm_articulo_tiendalist_Load(object sender, EventArgs e)
        {
            modulo = ((D60Tienda.MainTienda)MdiParent).moduloid;
            local = ((D60Tienda.MainTienda)MdiParent).local;

            NIVEL_FORMS();                      

            TablaVendedor = new DataTable();
            TablaVendedor.Columns.Add("id", typeof(Int32));
            TablaVendedor.Columns.Add("vendorid", typeof(String));
            TablaVendedor.Columns.Add("vendorname", typeof(String));
            TablaVendedor.Columns.Add("local", typeof(String));
            TablaVendedor.Columns.Add("localname", typeof(String));

            data_TablaVendedor();                       

            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_salir.Enabled = true;
        }
           
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
        }

        private void form_accion_cancelEdicion(int confirnar)
        {
            var sw_prosigue = true;
            if (confirnar == 1)
            {
                sw_prosigue = (MessageBox.Show("Desea Cancelar Ingreso de Datos...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
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
                grpanel01.Enabled = true;
                grpanel04.Enabled = true;
                ssModo = "OTR";
                if (TablaVendedorDet != null)
                    TablaVendedorDet.Rows.Clear();                
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0")
            {
                var sw_prosigue = false;
                sw_prosigue = (MessageBox.Show("¿Desea Eliminar Documento Actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

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

        void ValidaVendedor(String xcodvendor)
        {
            tb_me_vendedorBL BL = new tb_me_vendedorBL();
            tb_me_vendedor BE = new tb_me_vendedor();
            DataTable dt = new DataTable();
            BE.vendorid = xcodvendor.ToString();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                txt_vendorid.Text = dt.Rows[0]["vendorid"].ToString();
                txt_vendorname.Text = dt.Rows[0]["vendorname"].ToString();
                txt_apepat.Text = dt.Rows[0]["appat"].ToString();
                txt_apemat.Text = dt.Rows[0]["apmat"].ToString();
                txt_nombre.Text = dt.Rows[0]["nombre"].ToString();
                txt_dni.Text = dt.Rows[0]["ddnni"].ToString();
                txt_direcc.Text = dt.Rows[0]["direcc"].ToString();

                if (dt.Rows[0]["fechnac"].ToString().Length > 0)
                    txt_fechnac.Text = dt.Rows[0]["fechnac"].ToString().Substring(0,10);
                txt_local.Text = dt.Rows[0]["local"].ToString();
                txt_localname.Text = dt.Rows[0]["localname"].ToString();
                txt_fechini.Text = dt.Rows[0]["fechini"].ToString().Substring(0,10);
                if (dt.Rows[0]["fechcese"].ToString().Length > 0)
                    txt_fechcese.Text = dt.Rows[0]["fechcese"].ToString().Substring(0,10);
                txt_telefono.Text = dt.Rows[0]["telefono"].ToString();
                txt_remunebas.Text = dt.Rows[0]["remunebas"].ToString();

                //txt_vendorid.Text = dt.Rows[0]["porccomic"].ToString();
                txt_cargoid.Text = dt.Rows[0]["cargoid"].ToString();
                txt_cargoname.Text = dt.Rows[0]["cargoname"].ToString();
                if (dt.Rows[0]["fechasig"].ToString().Length > 0)
                    txt_fechasig.Text = dt.Rows[0]["fechasig"].ToString().Substring(0,10);
                rb_sexo.EditValue = dt.Rows[0]["sexo"].ToString();

                chk_conhijos.Checked = Convert.ToBoolean(dt.Rows[0]["conhijos"].ToString());
                chk_comisiona.Checked = Convert.ToBoolean(dt.Rows[0]["comisiona"].ToString());
                txt_observ.Text = dt.Rows[0]["observac"].ToString();

             }

            btn_nuevo.Enabled = true;
            btn_editar.Enabled = true;
            btn_eliminar.Enabled = true;
            btn_imprimir.Enabled = true;
            btn_log.Enabled = true;
            btn_salir.Enabled = true;

        }

        void CargarCargoVendedor(String xcod)
        {            
            TablaVendedorDet = new DataTable();
            TablaVendedorDet.Columns.Add("fechasig", typeof(DateTime));
            TablaVendedorDet.Columns.Add("local", typeof(String));
            TablaVendedorDet.Columns.Add("localname", typeof(String));
            TablaVendedorDet.Columns.Add("cargoid", typeof(String));
            TablaVendedorDet.Columns.Add("cargoname", typeof(String));
            TablaVendedorDet.Columns.Add("observac", typeof(String));

            tb_me_vendedorBL BL = new tb_me_vendedorBL();
            tb_me_vendedor BE = new tb_me_vendedor();
            BE.vendorid = xcod.ToString();
            TablaVendedorDet = BL.GetAll_History(EmpresaID, BE).Tables[0];
            MDI_dgb_vendorcargo.DataSource = TablaVendedorDet;

        }

        private void data_TablaVendedor()
        {
            try
            {                
                if (TablaVendedor.Rows.Count > 0)
                {
                    TablaVendedor.Rows.Clear();
                }
                var BL = new tb_me_vendedorBL();
                var BE = new tb_me_vendedor();

                BE.parameters = txt_busqueda.Text.Trim();
                BE.activo = Convert.ToBoolean(rb_tipo.EditValue);

                TablaVendedor = BL.GetAll2(EmpresaID, BE).Tables[0];
                if (TablaVendedor.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    Mdi_dgv_vendedor.DataSource = TablaVendedor;
                    lbl_num.Text = Convert.ToInt32(TablaVendedor.Compute("sum(id)", string.Empty)).ToString();
                }
                else
                {
                    Mdi_dgv_vendedor.DataSource = TablaVendedor;
                    lbl_num.Text = "0";
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                if (TablaVendedorDet != null)
                {
                    TablaVendedorDet.Rows.Clear();                    
                }
                grpanel01.Enabled = false;
                grpanel04.Enabled = false;
            }
        }

        private void btn_editar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XNIVEL == "0")
            {
                ssModo = "EDIT";
                form_bloqueado(true);
                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
                grpanel01.Enabled = false;
                grpanel04.Enabled = false;
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
                data_TablaVendedor();
                //CargarDetalle();
                form_bloqueado(false);
                btn_nuevo.Enabled = true;
                btn_salir.Enabled = true;
                grpanel01.Enabled = true;
                grpanel04.Enabled = true;
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

        private void Mdi_dgv_vendedor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xvendorid = dgv_vendedor.GetRowCellValue(dgv_vendedor.FocusedRowHandle, "vendorid").ToString();
                ValidaVendedor(xvendorid);
                CargarCargoVendedor(xvendorid);
            }
        }

        private void dgv_vendedor_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var xvendorid = dgv_vendedor.GetRowCellValue(e.RowHandle, "vendorid").ToString();    
            ValidaVendedor(xvendorid);
            CargarCargoVendedor(xvendorid);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            form_bloqueado(false);
            Nuevo2(true);           
            btn_cancelar.Enabled = true;
          
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            //if ((dgb_localcuota.RowCount != null))
            //{
            //    if (perianio.Text.Trim().Length == 0)
            //    {
            //        MessageBox.Show("Ingrese Año", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //    else
            //    {
            //        if (cmb_perimes.SelectedIndex == -1)
            //        {
            //            MessageBox.Show("Seleccione El Mes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }
            //        else
            //        {
            //            var BL = new tb_me_cuota_tiendaBL();
            //            var BE = new tb_me_cuota_tienda();

            //            BE.perianio = perianio.Text.ToString().Trim();
            //            BE.perimes = cmb_perimes.SelectedValue.ToString();
            //            BE.local = cmb_local.SelectedValue.ToString();
            //            BE.filtro = 1;

            //            if (BL.Delete(EmpresaID, BE))
            //            {
            //                CargarDetalle();
            //                cuota1.Text = string.Empty;
            //                cuota2.Text = string.Empty;
            //                cmb_local.SelectedIndex = -1;
            //                btn_del.Enabled = false;
            //            }
            //        }
            //    }
            //}
        }

        private void txt_busqueda_KeyUp(object sender, KeyEventArgs e)
        {
            data_TablaVendedor();
        }

        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            data_TablaVendedor();
        }

        private void ArmarNombre()
        {
            txt_vendorname.Text = txt_apepat.Text.Trim() + " " + txt_apemat.Text.Trim() + ", " + txt_nombre.Text.Trim();
        } 

        private void txt_apepat_KeyUp(object sender, KeyEventArgs e)
        {
            ArmarNombre();
        }

        private void txt_apemat_KeyUp(object sender, KeyEventArgs e)
        {
            ArmarNombre();
        }

        private void txt_nombre_KeyUp(object sender, KeyEventArgs e)
        {
            ArmarNombre();
        }


        private void SeleccDatoDet(String xcodigo,DateTime xfechasig)
        {
            var rowcargosid = TablaVendedorDet.Select("local ='" + xcodigo + "' and fechasig = '" + xfechasig + "'");
            if (rowcargosid.Length > 0)
            {
                foreach (DataRow row in rowcargosid)
                {
                    txt_local.Text = row["local"].ToString().Trim();
                    txt_localname.Text = row["localname"].ToString().Trim();
                    txt_fechasig.Text = row["fechasig"].ToString().Trim().Substring(0,10);
                    txt_cargoid.Text = row["cargoid"].ToString().Trim();
                    txt_cargoname.Text = row["cargoname"].ToString().Trim();
                    txt_observ.Text = row["observac"].ToString().Trim();
                }
            }      
        }

        private void MDI_dgb_vendorcargo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                String xcodigo = dgb_vendorcargo.GetRowCellValue(dgb_vendorcargo.FocusedRowHandle, "local").ToString();
                DateTime xfechasig = Convert.ToDateTime(dgb_vendorcargo.GetRowCellValue(dgb_vendorcargo.FocusedRowHandle, "fechasig").ToString());                
                SeleccDatoDet(xcodigo, xfechasig);
            }
        }

        private void dgb_vendorcargo_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            String xcodigo = dgb_vendorcargo.GetRowCellValue(e.RowHandle, "local").ToString();
            DateTime xfechasig = Convert.ToDateTime(dgb_vendorcargo.GetRowCellValue(e.RowHandle, "fechasig").ToString());
            SeleccDatoDet(xcodigo, xfechasig);
        }

        // CARGOS 
        private void AyudaCargo(String lpdescrlike)
        {
            try
            {              
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "<< AYUDA TABLA CARGOS >>";
                frmayuda.sqlquery = "SELECT cargoid, cargoname FROM tb_me_cargo ";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where";
                frmayuda.sqland = string.Empty;
                frmayuda.criteriosbusqueda = new string[] { "CARGO", "CODIGO" };
                frmayuda.columbusqueda = "cargoname,cargoid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeCargo;
                frmayuda.ShowDialog();                  
            }
            catch (Exception ex)
            {
                
            }
        }
        private void RecibeCargo(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                txt_cargoid.Text = resultado1.Trim();
                txt_cargoname.Text = resultado2.Trim();
            }
        }
        void ValidaCargo(String xcod)
        {
            tb_me_cargoBL BL = new tb_me_cargoBL();
            tb_me_cargo BE = new tb_me_cargo();
            DataTable dt = new DataTable();
            BE.cargoid = xcod.ToString();
            dt = BL.GetAll(EmpresaID,BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                txt_cargoid.Text = dt.Rows[0]["cargoid"].ToString();
                txt_cargoname.Text = dt.Rows[0]["cargoname"].ToString();
            }
            else
            {
                txt_cargoid.Text = "";
                txt_cargoname.Text = "";
            }
        }
        private void txt_cargoid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaCargo("");
            }

            if (e.KeyCode == Keys.Enter)
            {
                String xcod = txt_cargoid.Text.PadLeft(3,'0');
                ValidaCargo(xcod);
            }
        }
        private void txt_cargoid_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(ActiveControl.Text))
            {
                txt_cargoid.SelectionStart = 0;
                txt_cargoid.SelectionLength = ActiveControl.Text.Length;
            }
        }
        
        //LOCAL ASIGNADO
        private void AyudaLocal(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all";
                frmayuda.titulo = "<< AYUDA TABLA LOCAL >>";
                frmayuda.sqlquery = "SELECT local, localname, dominioid, moduloid FROM tb_sys_local";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where dominioid = '" + dominio + "' and moduloid = '" + modulo + "'";
                frmayuda.sqland = "and";
                frmayuda.criteriosbusqueda = new string[] { "LOCAL", "CODIGO" };
                frmayuda.columbusqueda = "localname,local";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeLocal;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
        private void RecibeLocal(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                txt_local.Text = resultado1.Trim();
                txt_localname.Text = resultado2.Trim();
            }
        }
        private void ValidaLocal(String xcod)
        {           
            var BL = new sys_localBL();
            var BE = new tb_sys_local();
            var dt = new DataTable();
            BE.dominioid = dominio.ToString();
            BE.moduloid = modulo.ToString();
            BE.local = xcod.ToString();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                txt_local.Text = dt.Rows[0]["local"].ToString().Trim();
                txt_localname.Text = dt.Rows[0]["localname"].ToString().Trim();             
            }
            else
            {
                txt_local.Text = string.Empty;
                txt_localname.Text = string.Empty;
            }           
        }
        private void txt_local_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaLocal("");
            }

            if (e.KeyCode == Keys.Enter)
            {
                String xcod = txt_local.Text.PadLeft(3, '0');
                ValidaLocal(xcod);
            }
        }
        private void txt_local_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(ActiveControl.Text))
            {
                txt_local.SelectionStart = 0;
                txt_local.SelectionLength = ActiveControl.Text.Length;
            }
        }

        private void btn_act_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tb_me_vendedorBL BL = new tb_me_vendedorBL();
            tb_me_vendedor BE = new tb_me_vendedor();
            if (BL.Insert_Freeze(EmpresaID, BE))
            {
                MessageBox.Show("Proceso Terminado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txt_busqueda_TextChanged(object sender, EventArgs e)
        {

        }

       



    }
}
