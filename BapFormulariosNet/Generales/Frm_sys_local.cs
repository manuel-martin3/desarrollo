using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using System.Text.RegularExpressions;

namespace BapFormulariosNet.Generales
{
    public partial class Frm_sys_local : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;

        private DataTable Tablamodulo;
        private String DireccionDeta = string.Empty;
        private Boolean procesado = false;

        private String ssModo = string.Empty;
        private String Nmruc = string.Empty;


        public Frm_sys_local()
        {
            InitializeComponent();
        }

        //private void PARAMETROS_TABLA()
        //{
        //    var xxferfil = string.Empty;
        //    var f = (MainAlmacen)MdiParent;
        //    xxferfil = f.perfil.ToString();
        //    if (xxferfil.Trim().Length != 9)
        //    {
        //        MessageBox.Show("::: NO TIENE PERFIL !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    PERFILID = xxferfil;
        //    var XTABLA_PERFIL = string.Empty;
        //    XTABLA_PERFIL = VariablesPublicas.GET_PARAMETROS_TABLA(xxferfil, Name);
        //    if (XTABLA_PERFIL.Trim().Length > 0 && XTABLA_PERFIL.Trim() != "0")
        //    {
        //        if (XTABLA_PERFIL.Trim().Length == 2)
        //        {
        //            dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
        //        }
        //        else
        //        {
        //            if (XTABLA_PERFIL.Trim().Length == 6)
        //            {
        //                dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
        //                modulo = XTABLA_PERFIL.Trim().Substring(2, 4);
        //            }
        //            else
        //            {
        //                if (XTABLA_PERFIL.Trim().Length == 9)
        //                {
        //                    dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
        //                    modulo = XTABLA_PERFIL.Trim().Substring(2, 4);
        //                    local = XTABLA_PERFIL.Trim().Substring(6, 3);
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("::: No puede accede a FORMULARIO. \n::: Es necesario DOMINIO, MODULO Y LOCAL !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void NIVEL_FORMS()
        {

            switch (this.Parent.Parent.Name)
            {
                case "MainMercaderia":
                    XNIVEL = VariablesPublicas.Get_nivelperfil(((MERCADERIA.MainMercaderia)MdiParent).perfil, Name).Substring(0, 1);
                    break;
                case "MainAlmacen":
                    XNIVEL = VariablesPublicas.Get_nivelperfil(((D60ALMACEN.MainAlmacen)MdiParent).perfil, Name).Substring(0, 1);
                    break;
                default:
                    break;
            }
        
            //XNIVEL = VariablesPublicas.Get_nivelperfil(((D60ALMACEN.MainAlmacen)MdiParent).perfil, Name).Substring(0, 1);
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
                dominioid.Enabled = var;
                dominioname.Enabled = false;
                item.Enabled = false;
                localname.Enabled = var;
                direcnume.Enabled = var;
                moduloid.Enabled = var;
                ctacte.Enabled = var;
                moduloname.Enabled = false;
                ctactename.Enabled = false;
                dgb_local.ReadOnly = true;

                email.Enabled = var;
                rpc.Enabled = var;
                telf.Enabled = var;
                estabsunat.Enabled = var;
                chkmeslocal.Enabled = var;

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
                item.Text = string.Empty;
                btn_nuevo.Enabled = true;
                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;
                btn_salir.Enabled = true;

                ssModo = string.Empty;
            }
        }
        private void form_cargar_datos(String posicion)
        {
            try
            {
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();

                BE.dominioid = dominioid.Text.Trim();
                BE.moduloid = item.Text.Trim();
                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    ssModo = "EDIT";
                    limpiar_documento();
                    dominioid.Text = dt.Rows[0]["dominioid"].ToString().Trim();
                    dominioname.Text = dt.Rows[0]["dominioname"].ToString().Trim();
                    item.Text = dt.Rows[0]["moduloid"].ToString().Trim();
                    localname.Text = dt.Rows[0]["moduloname"].ToString().Trim();

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
                else
                {
                    limpiar_documento();
                    btn_editar.Enabled = false;
                    btn_eliminar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidaDominio()
        {
            if (dominioid.Text.Trim().Length > 0)
            {
                var BL = new sys_dominioBL();
                var BE = new tb_sys_dominio();
                var dt = new DataTable();

                BE.dominioid = dominioid.Text.Trim().PadLeft(2, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    dominioid.Text = dt.Rows[0]["dominioid"].ToString().Trim();
                    dominioname.Text = dt.Rows[0]["dominioname"].ToString().Trim();
                }
                else
                {
                    dominioid.Text = string.Empty;
                    dominioname.Text = string.Empty;
                }
            }
            else
            {
                dominioid.Text = string.Empty;
                dominioname.Text = string.Empty;
            }
        }



        private void ValidaModulo()
        {
            if (dominioid.Text.Trim().Length > 0)
            {
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();

                BE.moduloid = moduloid.Text.Trim();

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    moduloid.Text = dt.Rows[0]["moduloid"].ToString().Trim();
                    moduloname.Text = dt.Rows[0]["moduloname"].ToString().Trim();
                }
                else
                {
                    moduloid.Text = string.Empty;
                    moduloname.Text = string.Empty;
                }
            }
            else
            {
                moduloid.Text = string.Empty;
                moduloname.Text = string.Empty;
            }
        }



        private void ValidaCliente()
        {
            if (dominioid.Text.Trim().Length > 0)
            {
                var BL = new clienteBL();
                var BE = new tb_cliente();

                var dt = new DataTable();

                var cta = ctacte.Text.Trim().PadLeft(7, '0');
                BE.ctacte = cta.ToString();
                ctacte.Text = cta.ToString();

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    ctacte.Text = dt.Rows[0]["ctacte"].ToString().Trim();
                    Nmruc = dt.Rows[0]["nmruc"].ToString().Trim();
                    ctactename.Text = dt.Rows[0]["ctactename"].ToString().Trim();
                }
                else
                {
                    ctacte.Text = string.Empty;
                    Nmruc = string.Empty;
                    ctactename.Text = string.Empty;
                    direcnume.Text = string.Empty;
                }
            }
            else
            {
                ctacte.Text = string.Empty;
                Nmruc = string.Empty;
                ctactename.Text = string.Empty;
                direcnume.Text = string.Empty;
            }
        }





        private void Validamodulo_nuevo()
        {
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



        private void AyudaDominio(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all";
                frmayuda.titulo = "<< AYUDA  TABLA DOMINIO >>";
                frmayuda.sqlquery = "SELECT dominioid, dominioname FROM tb_sys_dominio";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where";
                frmayuda.sqland = string.Empty;
                frmayuda.criteriosbusqueda = new string[] { "DOMINIO", "CODIGO" };
                frmayuda.columbusqueda = "dominioname,dominioid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeDominio;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }


        private void RecibeDominio(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                dominioid.Text = resultado1.Trim();
                dominioname.Text = resultado2.Trim();
            }
        }

        private void Ayudamodulo(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all";
                frmayuda.titulo = "<< AYUDA  TABLA modulo >>";
                frmayuda.sqlquery = "SELECT moduloid, moduloname, moduloshort FROM tb_sys_modulo";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where";
                frmayuda.sqland = string.Empty;
                frmayuda.criteriosbusqueda = new string[] { "modulo", "CODIGO" };
                frmayuda.columbusqueda = "moduloname,moduloid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = Recibemodulo;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }


        private void Recibemodulo(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                moduloid.Text = resultado1.Trim();
                moduloname.Text = resultado2.ToString();
            }
        }


        private void SEGURIDAD_LOG(String accion)
        {
            var xclave = VariablesPublicas.EmpresaID + "/" + ((D60ALMACEN.MainAlmacen)MdiParent).perianio;
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
                BE.detalle = dominioid.Text.Trim() + moduloid.Text.Trim() + "/" + localname.Text.Trim().ToUpper() + "/" + XGLOSA;

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
                dominioid.Text = string.Empty;
                dominioname.Text = string.Empty;
                item.Text = string.Empty;
                moduloid.Text = string.Empty;
                moduloname.Text = string.Empty;
                ctacte.Text = string.Empty;
                ctactename.Text = string.Empty;
                direcnume.Text = string.Empty;
                localname.Text = string.Empty;
                mensaje.Text = string.Empty;

                email.Text = string.Empty;
                rpc.Text = string.Empty;
                telf.Text = string.Empty;
                estabsunat.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevo()
        {
            ssModo = "NEW";

            limpiar_documento();
            form_bloqueado(true);
            dominioid.Focus();
            btn_grabar.Enabled = true;
            btn_cancelar.Enabled = true;
        }


        private void Insert()
        {
            try
            {
                if (dominioid.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese Código de Dominio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (moduloid.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese Código de modulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new sys_localBL();
                    var BE = new tb_sys_local();

                    BE.dominioid = dominioid.Text.Trim();
                    BE.moduloid = moduloid.Text.Trim();
                    BE.local = item.Text.ToString();
                    BE.localname = localname.Text.ToString();
                    BE.localdirec = DireccionDeta.ToString();
                    BE.usuar = VariablesPublicas.Usuar.Trim().ToString();
                    BE.ctacte = ctacte.Text.ToString();
                    BE.direcnume = direcnume.Text.ToString();
                    BE.nmruc = Nmruc.ToString();
                    BE.ctactename = ctactename.Text.ToString();
                    BE.status = "0";

                    if (email_bien_escrito(email.Text.ToString()))
                    {
                        BE.email = email.Text.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Correo en Formato Incorrecto");
                        return;
                    }

                    BE.rpc = rpc.Text.ToString();
                    BE.telf = telf.Text.ToString();
                    BE.estabsunat = estabsunat.Text.ToString();
                    BE.perimeslocal = chkmeslocal.Checked;

                    if (BL.Insert(EmpresaID, BE))
                    {
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

        private Boolean email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void Update()
        {
            try
            {
                if (dominioid.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese Código de Dominio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (moduloid.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese Código de modulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new sys_localBL();
                    var BE = new tb_sys_local();

                    BE.dominioid = dominioid.Text.Trim();
                    BE.moduloid = moduloid.Text.Trim();
                    BE.local = item.Text.ToString();
                    BE.localname = localname.Text.ToString();
                    BE.localdirec = DireccionDeta.ToString();
                    BE.usuar = VariablesPublicas.Usuar.Trim().ToString();
                    BE.ctacte = ctacte.Text.ToString();
                    BE.direcnume = direcnume.Text.ToString();
                    BE.nmruc = Nmruc.ToString();
                    BE.ctactename = ctactename.Text.ToString();
                    BE.status = "0";

                    if (email_bien_escrito(email.Text.ToString()))
                    {
                        BE.email = email.Text.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Correo en Formato Incorrecto");
                        return;
                    }
                    BE.rpc = rpc.Text.ToString();
                    BE.telf = telf.Text.ToString();
                    BE.estabsunat = estabsunat.Text.ToString();
                    BE.perimeslocal = chkmeslocal.Checked;


                    if (BL.Update(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("M");
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
                if (dominioid.Text.Trim().Length != 2)
                {
                    MessageBox.Show("Ingrese Código de Dominio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (item.Text.Trim().Length != 4)
                {
                    MessageBox.Show("Ingrese Código de modulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new sys_localBL();
                    var BE = new tb_sys_local();

                    BE.dominioid = dominioid.Text.Trim();
                    BE.moduloid = moduloid.Text.Trim();
                    BE.local = item.Text.ToString();

                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos Eliminado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        data_Tablamodulo();
                        limpiar_documento();
                        form_bloqueado(false);
                        btn_nuevo.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_sys_modulo_Activated(object sender, EventArgs e)
        {
        }



        private void Frm_sys_modulo_Load(object sender, EventArgs e)
        {
            modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
            local = ((D60ALMACEN.MainAlmacen)MdiParent).local;

            NIVEL_FORMS();

            Tablamodulo = new DataTable();
            data_Tablamodulo();

            limpiar_documento();
            form_bloqueado(false);

            btn_nuevo.Enabled = true;
            btn_primero.Enabled = true;
            btn_anterior.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_ultimo.Enabled = true;
            btn_salir.Enabled = true;
        }
        private void Frm_sys_modulo_KeyDown(object sender, KeyEventArgs e)
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
                if (item.Text.Trim().Length == 3)
                {
                    ssModo = "EDIT";

                    form_bloqueado(true);
                    localname.Focus();

                    btn_cancelar.Enabled = true;
                    btn_grabar.Enabled = true;
                    btn_agregar.Enabled = false;
                    ctacte.Enabled = false;
                }
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
                data_Tablamodulo();
                form_bloqueado(false);

                btn_nuevo.Enabled = true;
                btn_eliminar.Enabled = true;

                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;
                btn_salir.Enabled = true;
                btn_agregar.Enabled = true;
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
                if (Tablamodulo.Rows.Count > 0)
                {
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
            var xclave = VariablesPublicas.EmpresaID + "/" + ((D60ALMACEN.MainAlmacen)MdiParent).perianio;
            oform._Nombre = Name;
            oform._ClaveForm = xclave;
            oform.Owner = this;
            oform.ShowDialog();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void data_Tablamodulo()
        {
            try
            {
                if (Tablamodulo != null)
                {
                    Tablamodulo.Rows.Clear();
                }
                var BL = new sys_localBL();
                var BE = new tb_sys_local();

                BE.dominioid = dominio.ToString();
                BE.moduloid = modulo.ToString();
                ;

                Tablamodulo = BL.GetAll(EmpresaID, BE).Tables[0];

                if (Tablamodulo.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    dgb_local.DataSource = Tablamodulo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgb_local_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgb_local.CurrentRow != null)
                {
                    var xdominioid = string.Empty;
                    var xmoduloid = string.Empty;
                    var xlocal = string.Empty;
                    xdominioid = dgb_local.Rows[e.RowIndex].Cells["gdominioid"].Value.ToString().Trim();
                    xmoduloid = dgb_local.Rows[e.RowIndex].Cells["gmoduloid"].Value.ToString().Trim();
                    xlocal = dgb_local.Rows[e.RowIndex].Cells["loc"].Value.ToString().Trim();
                    data_tipodoc(xdominioid, xmoduloid, xlocal);
                }
            }
            catch (Exception ex)
            {
            }
        }



        private void dgb_local_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xdominioid = string.Empty;
                var xmoduloid = string.Empty;
                var xlocal = string.Empty;
                xdominioid = dgb_local.Rows[dgb_local.CurrentRow.Index].Cells["gdominioid"].Value.ToString().Trim();
                xmoduloid = dgb_local.Rows[dgb_local.CurrentRow.Index].Cells["gmoduloid"].Value.ToString().Trim();
                xlocal = dgb_local.Rows[dgb_local.CurrentRow.Index].Cells["loc"].Value.ToString().Trim();
                data_tipodoc(xdominioid, xmoduloid, xlocal);
            }
        }

        private void dgb_local_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgb_local.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgb_local[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(39, 95, 178);
            dgb_local[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);
        }

        private void dgb_local_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dgb_local[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }

        private void data_tipodoc(String xdominioid, String xmoduloid, String xlocal)
        {
            form_bloqueado(false);
            var rowtipodoc = Tablamodulo.Select("dominioid = '" + xdominioid.Trim() + "' and moduloid='" + xmoduloid.Trim() + "' and local = '" + xlocal.Trim() + "'");
            if (rowtipodoc.Length > 0)
            {
                foreach (DataRow row in rowtipodoc)
                {
                    ssModo = "EDIT";
                    limpiar_documento();

                    dominioid.Text = row["dominioid"].ToString().Trim();
                    dominioname.Text = row["dominioname"].ToString().Trim();
                    moduloid.Text = row["moduloid"].ToString().Trim();
                    moduloname.Text = row["moduloname"].ToString().Trim();
                    ctacte.Text = row["ctacte"].ToString().Trim();
                    ctactename.Text = row["ctactename"].ToString().Trim();
                    direcnume.Text = row["direcnume"].ToString().Trim();
                    localname.Text = row["localname"].ToString().Trim();
                    item.Text = row["local"].ToString().Trim();

                    DireccionDeta = row["localdirec"].ToString().Trim();
                    Nmruc = row["nmruc"].ToString().Trim();

                    estabsunat.Text = row["estabsunat"].ToString().Trim();
                    email.Text = row["email"].ToString().Trim();
                    telf.Text = row["telef"].ToString().Trim();
                    rpc.Text = row["rpc"].ToString().Trim();
                    chkmeslocal.Checked = Convert.ToBoolean(row["perimeslocal"].ToString());
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

        private void ctacte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaCliente(string.Empty);

                ValidaCliente();

                var BL = new sys_localBL();
                var BE = new tb_sys_local();

                var dt = new DataTable();

                BE.ctacte = ctacte.Text.ToString();
                dt = BL.GenCodigo(EmpresaID, BE).Tables[0];
                item.Text = dt.Rows[0]["item"].ToString().PadLeft(3, '0');
                direcnume.Focus();
            }

            if (e.KeyCode == Keys.Enter)
            {
                ValidaCliente();

                var BL = new sys_localBL();
                var BE = new tb_sys_local();

                var dt = new DataTable();

                BE.ctacte = ctacte.Text.ToString();
                dt = BL.GenCodigo(EmpresaID, BE).Tables[0];
                item.Text = dt.Rows[0]["item"].ToString().PadLeft(3, '0');
                direcnume.Focus();
            }
        }

        private void dominioid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaDominio(string.Empty);
            }

            if (e.KeyCode == Keys.Enter)
            {
                ValidaDominio();
                moduloid.Focus();
            }
        }

        private void moduloid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Ayudamodulo(string.Empty);
            }

            if (e.KeyCode == Keys.Enter)
            {
                ValidaModulo();
                ctacte.Focus();
            }
        }


        private void AyudaCliente(String lpdescrlike)
        {
            try
            {
                var modd = string.Empty;
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();

                BE.dominioid = dominioid.Text.ToString();
                BE.moduloid = moduloid.Text.ToString();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();

                        var frmayuda = new Ayudas.Frm_help_general();

                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA TABLA GRUPOS >>";
                        frmayuda.sqlquery = " SELECT ctacte, ctactename ,nmruc  FROM tb_cliente ";
                        frmayuda.sqlinner = string.Empty;
                        frmayuda.sqlwhere = " where ";
                        frmayuda.sqland = string.Empty;
                        frmayuda.criteriosbusqueda = new string[] { "PROVEEDOR", "CODIGO" };
                        frmayuda.columbusqueda = "ctactename,ctacte";
                        frmayuda.returndatos = "0,1,2";

                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeCliente;
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void RecibeCliente(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                ctacte.Text = resultado1.Trim();
                ctactename.Text = resultado2.Trim();
                Nmruc = resultado3.Trim();
            }
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            direcnume.Text = string.Empty;
            localname.Text = string.Empty;
            direcnume.Enabled = true;
            btn_nuevo.Enabled = false;
            var BL = new sys_localBL();
            var BE = new tb_sys_local();

            var dt = new DataTable();

            if (ctacte.Text == string.Empty)
            {
                MessageBox.Show("No Existe la Cuenta Corriente Para Generar el Item !!!");
                return;
            }

            BE.ctacte = ctacte.Text.ToString();
            dt = BL.GenCodigo(EmpresaID, BE).Tables[0];
            item.Text = dt.Rows[0]["item"].ToString().PadLeft(3, '0');
            ssModo = "NEW";
            btn_grabar.Enabled = true;
            estabsunat.Enabled = true;
            telf.Enabled = true;
            rpc.Enabled = true;
            email.Enabled = true;
            direcnume.Focus();
        }

        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            var BL = new sys_localBL();
            var BE = new tb_sys_local();

            var dt = new DataTable();
            BE.dominioid = dominioid.Text.Trim();
            BE.moduloid = moduloid.Text.Trim();
            BE.localname = txt_busqueda.Text.ToString();

            dt = BL.GetAll(EmpresaID, BE).Tables[0];

            if (dt.Rows.Count > 0)
            {
                dgb_local.DataSource = dt;
            }
        }

        private void txt_busqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_busqueda_Click(sender, e);
            }
        }

        private void direcnume_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaClientesDireccion(string.Empty);
            }
        }

        private void AyudaClientesDireccion(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all";
                frmayuda.titulo = "Ayuda Dirección";
                frmayuda.sqlquery = "select direcnume, direcname, direcdeta from tb_cliente_direc";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where ctacte = '" + ctacte.Text.Trim() + "'";
                frmayuda.sqland = "and";
                frmayuda.criteriosbusqueda = new string[] { "NOM DIRECCIÓN", "DIRECCIÓN" };
                frmayuda.columbusqueda = "direcname,direcdeta";
                frmayuda.returndatos = "0,1,2";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeClientesDireccion;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }

        private void RecibeClientesDireccion(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                direcnume.Text = resultado1.Trim();
                localname.Text = resultado2.Trim();
                DireccionDeta = resultado3.Trim();
            }
        }

        private void estabsunat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                email.Focus();
            }
        }

        private void email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                telf.Focus();
            }
        }

        private void telf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                rpc.Focus();
            }
        }
    }
}
