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

namespace BapFormulariosNet.Generales
{
    public partial class Frm_mottrasladoint : plantilla
    {
        /*** variables de cabecera del documento actual ***/
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = "";
        private String local = "";   

        String perianio = "";
        String perimes = "";

        String XNIVEL = "";
        String XGLOSA = "";

        DataTable Tablamottrasladoint;

        Boolean fechadocedit = false;
        Boolean procesado = false;
        Boolean statusDoc = true;

        String ssModo = "NEW";

        public Frm_mottrasladoint()
        {
            InitializeComponent();
            mottrasladointid.LostFocus += new System.EventHandler(mottrasladointid_LostFocus);
        }

        #region $$$ ADMINISTRADOR
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

                moduloid.Enabled = var;
                moduloname.Enabled = false;

                mottrasladointid.Enabled = !var;
                mottrasladointname.Enabled = var;
                codigosunat.Enabled = var;
                escompra.Enabled = var;
                esventa.Enabled = var;
                tipmov1.Enabled = var;
                tipmov2.Enabled = var;
                codigosunat.Enabled = var;

                gridmottrasladoint.ReadOnly = true;
                gridmottrasladoint.Enabled = !var;
                cbo_buscar.Enabled = !var;
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
                mottrasladointid.Text = "";
                btn_nuevo.Enabled = true;
                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;
                btn_buscar.Enabled = true;
                btn_salir.Enabled = true;

                ssModo = "NEW";
            }
        }
        private void form_cargar_datos(String posicion)
        {
            try
            {
                tb_mottrasladointBL BL = new tb_mottrasladointBL();
                tb_mottrasladoint BE = new tb_mottrasladoint();
                DataTable dt = new DataTable();

                BE.moduloid = moduloid.Text.Trim();
                BE.mottrasladointid = mottrasladointid.Text.Trim().PadLeft(2, '0');
                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    limpiar_documento();
                    ssModo = "EDIT";

                    moduloid.Text = dt.Rows[0]["moduloid"].ToString().Trim();
                    moduloname.Text = dt.Rows[0]["moduloname"].ToString().Trim();
                    mottrasladointid.Text = dt.Rows[0]["mottrasladointid"].ToString().Trim();
                    mottrasladointname.Text = dt.Rows[0]["mottrasladointname"].ToString().Trim();
                    codigosunat.Text = dt.Rows[0]["codigosunat"].ToString().Trim();
                    if (dt.Rows[0]["escompra"].ToString().Trim().Length > 0)
                        escompra.Checked = Convert.ToBoolean(dt.Rows[0]["escompra"]);
                    if (dt.Rows[0]["esventa"].ToString().Trim().Length > 0)
                        esventa.Checked = Convert.ToBoolean(dt.Rows[0]["esventa"]);
                    if (dt.Rows[0]["tipmov"].ToString().Trim().Length > 0)
                    {
                        if (dt.Rows[0]["tipmov"].ToString().Trim() == "1")
                            tipmov1.Checked = true;
                        else if (dt.Rows[0]["tipmov"].ToString().Trim() == "2")
                            tipmov2.Checked = true;
                    }
                    else
                    {
                        tipmov1.Checked = false;
                        tipmov2.Checked = false;
                    }


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

                    data_Tablamottrasladoint();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region $$$ Llenado de Combobox
        void data_cbo_buscar()
        {
            cbo_buscar.Items.Add(new System.Web.UI.WebControls.ListItem("MOTIVO INTERNO", "01"));
            cbo_buscar.Items.Add(new System.Web.UI.WebControls.ListItem("CODIGO MOTIVO", "02"));
            cbo_buscar.Items.Add(new System.Web.UI.WebControls.ListItem("MOVIMIENTO", "04"));
            cbo_buscar.SelectedIndex = 0;
        }
        #endregion
        private void ValidaModulo()
        {
            if (moduloid.Text.Trim().Length > 0)
            {
                sys_moduloBL BL = new sys_moduloBL();
                tb_sys_modulo BE = new tb_sys_modulo();
                DataTable dt = new DataTable();

                BE.dominioid = "60";
                BE.moduloid = moduloid.Text.Trim();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    moduloid.Text = dt.Rows[0]["moduloid"].ToString().Trim();
                    moduloname.Text = dt.Rows[0]["moduloname"].ToString().Trim();

                    form_bloqueado(true);
                    moduloid.Enabled = false;

                    btn_cancelar.Enabled = true;
                    btn_grabar.Enabled = true;
                    btn_log.Enabled = true;
                    mottrasladointname.Focus();
                }
                else
                {
                    moduloid.Text = "";
                    moduloname.Text = "";
                }
            }
            else
            {
                moduloid.Text = "";
                moduloname.Text = "";
            }
        }
        private void ValidaMottrasladoint()
        {
            if (mottrasladointid.Text.Trim().Length > 0 && ssModo == "NEW")
            {
                tb_mottrasladointBL BL = new tb_mottrasladointBL();
                tb_mottrasladoint BE = new tb_mottrasladoint();
                DataTable dt = new DataTable();

                BE.moduloid = modulo;
                BE.mottrasladointid = mottrasladointid.Text.Trim().PadLeft(4, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    mottrasladointid.Text = dt.Rows[0]["mottrasladointid"].ToString().Trim();
                    mottrasladointname.Text = dt.Rows[0]["mottrasladointname"].ToString().Trim();
                    mottrasladointname.Text = moduloname.Text.Trim() + " " + dt.Rows[0]["mottrasladointname"].ToString().Trim();
                }
                else
                {
                    mottrasladointid.Text = "";
                    mottrasladointname.Text = "";
                    mottrasladointname.Text = moduloname.Text.Trim();
                }
            }
            if (mottrasladointid.Text.Trim().Length == 0 && ssModo == "NEW")
            {
                mottrasladointid.Text = "";
                mottrasladointname.Text = "";
                mottrasladointname.Text = moduloname.Text.Trim();
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

        private void AyudaModulo(String lpdescrlike)
        {
            try
            {
                Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all"; //sql,tabla
                frmayuda.titulo = "<< AYUDA  TABLA MODULO >>";
                frmayuda.sqlquery = "SELECT moduloid, moduloname FROM tb_sys_modulo";
                frmayuda.sqlinner = ""; //inner
                frmayuda.sqlwhere = "where dominioid='60'"; //where
                frmayuda.sqland = "and";//and
                frmayuda.criteriosbusqueda = new string[] { "MODULO", "CODIGO" };
                frmayuda.columbusqueda = "moduloname,moduloid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeModulo;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }
        private void RecibeModulo(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                moduloid.Text = resultado1.Trim();
                moduloname.Text = resultado2.Trim();
            }
        }

        private void AyudaMottrasladoint(String lpdescrlike)
        {
            try
            {
                Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql"; //sql,tabla
                frmayuda.titulo = "<< AYUDA TABLA GRUPOS >>";
                frmayuda.sqlquery = "SELECT mottrasladointid, mottrasladointname, moduloid FROM tb_mottrasladoint";
                frmayuda.sqlinner = ""; //inner
                frmayuda.sqlwhere = "where"; //where
                frmayuda.sqland = "";//and
                frmayuda.criteriosbusqueda = new string[] { "MOTIVO", "CODIGO" };
                frmayuda.columbusqueda = "mottrasladointname,mottrasladointid";
                frmayuda.returndatos = "0,1,2";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeGrupo;
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
                moduloid.Text = resultado3.Trim();
                mottrasladointid.Text = resultado1.Trim();
                mottrasladointname.Text = resultado2.Trim();
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
                BE.detalle = moduloid.Text.Trim() + mottrasladointid.Text.Trim() + mottrasladointid.Text.Trim() + "/" + mottrasladointname.Text.Trim().ToUpper() + "/" + codigosunat.Text.Trim() + "/" + XGLOSA;

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
                moduloid.Text = "";
                moduloname.Text = "";
                mottrasladointid.Text = "";
                mottrasladointname.Text = "";
                esventa.Checked = false;
                escompra.Checked = false;
                tipmov1.Checked = false;
                tipmov2.Checked = false;
                codigosunat.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void nuevo()
        {
            limpiar_documento();
            form_bloqueado(false);
            moduloid.Enabled = true;
            mottrasladointid.Enabled = false;

            mottrasladointid.Text = "NEW";
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_log.Enabled = true;
            moduloid.Focus();

            ssModo = "NEW";
        }
        private void Insert()
        {
            try
            {
                if (moduloid.Text.Trim().Length != 4)
                {
                    MessageBox.Show("Falta Codigo Modulo !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (mottrasladointid.Text.Trim().Length != 3)
                {
                    MessageBox.Show("Ingrese nuevo motivo de traslado interno !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (mottrasladointname.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese nombre de motivo !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    tb_mottrasladointBL BL = new tb_mottrasladointBL();
                    tb_mottrasladoint BE = new tb_mottrasladoint();

                    BE.moduloid = moduloid.Text.Trim();
                    BE.mottrasladointid = mottrasladointid.Text.Trim().PadLeft(2, '0');
                    BE.mottrasladointname = mottrasladointname.Text.ToUpper();
                    BE.codigosunat = codigosunat.Text.Trim().ToUpper();
                    BE.escompra = escompra.Checked;
                    BE.esventa = esventa.Checked;
                    if (tipmov1.Checked)
                        BE.tipmov = "1";
                    if (tipmov2.Checked)
                        BE.tipmov = "2";

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
        private void Update()
        {
            try
            {
                if (moduloid.Text.Trim().Length != 4)
                {
                    MessageBox.Show("Falta Codigo Modulo !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (mottrasladointid.Text.Trim().Length != 2)
                {
                    MessageBox.Show("Ingrese codigo motivo de traslado interno !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (mottrasladointname.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese nombre de motivo !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    tb_mottrasladointBL BL = new tb_mottrasladointBL();
                    tb_mottrasladoint BE = new tb_mottrasladoint();

                    BE.moduloid = moduloid.Text.Trim();
                    BE.mottrasladointid = mottrasladointid.Text.Trim().PadLeft(2, '0');
                    BE.mottrasladointname = mottrasladointname.Text.ToUpper();
                    BE.codigosunat = codigosunat.Text.Trim().ToUpper();
                    BE.escompra = escompra.Checked;
                    BE.esventa = esventa.Checked;
                    if (tipmov1.Checked)
                        BE.tipmov = "1";
                    if (tipmov2.Checked)
                        BE.tipmov = "2";

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
                if (moduloid.Text.Trim().Length != 4)
                {
                    MessageBox.Show("Falta Codigo Modulo !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (mottrasladointid.Text.Trim().Length != 2)
                {
                    MessageBox.Show("Ingrese nuevo motivo de traslado interno !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    tb_mottrasladointBL BL = new tb_mottrasladointBL();
                    tb_mottrasladoint BE = new tb_mottrasladoint();

                    BE.moduloid = moduloid.Text.Trim();
                    BE.mottrasladointid = mottrasladointid.Text.Trim().PadLeft(2, '0');

                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos Eliminado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        limpiar_documento();
                        form_bloqueado(false);
                        data_Tablamottrasladoint();
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
        private void Frm_mottrasladoint_Activated(object sender, EventArgs e)
        {

        }
        private void Frm_mottrasladoint_Load(object sender, EventArgs e)
        {
            NIVEL_FORMS();

            switch (this.Parent.Parent.Name)
            {
                case "MainMercaderia":
                    modulo = ((MERCADERIA.MainMercaderia)MdiParent).moduloid;
                    local = ((MERCADERIA.MainMercaderia)MdiParent).local;
                    break;
                case "MainAlmacen":
                    modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
                    local = ((D60ALMACEN.MainAlmacen)MdiParent).local;
                    break;
                default:
                    break;
            }

            data_cbo_buscar();
            Tablamottrasladoint = new DataTable();

            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_primero.Enabled = true;
            btn_anterior.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_ultimo.Enabled = true;
            btn_buscar.Enabled = true;
            btn_salir.Enabled = true;
        }
        private void Frm_mottrasladoint_KeyDown(object sender, KeyEventArgs e)
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

        private void moduloid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaModulo("");
            }
        }
        private void moduloid_KeyUp(object sender, KeyEventArgs e)
        {
            if (moduloid.Text.Trim().Length == 4)
            {
                ValidaModulo();
                data_Tablamottrasladoint();
            }
        }
        private void mottrasladointid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaMottrasladoint("");
            }
        }
        private void mottrasladointid_LostFocus(object sender, System.EventArgs e)
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
            if (XNIVEL == "0" || XNIVEL == "1")
            {
                ssModo = "EDIT";
                form_bloqueado(true);
                moduloid.Enabled = false;
                mottrasladointid.Enabled = false;
                mottrasladointname.Focus();

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
                data_Tablamottrasladoint();
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
        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Tablamottrasladoint.Rows.Count > 0)
                {
                    //REPORTES.Frm_reportes miForma = new REPORTES.Frm_reportes();
                    //miForma.Text = "Reporte de subgrupos";
                    //miForma.formulario = "Frm_mottrasladoint";
                    //miForma.ShowDialog();
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

        #region $$$ grid subgrupo
        private void data_Tablamottrasladoint()
        {
            try
            {
                if (Tablamottrasladoint.Rows.Count > 0)
                    Tablamottrasladoint.Rows.Clear();
                tb_mottrasladointBL BL = new tb_mottrasladointBL();
                tb_mottrasladoint BE = new tb_mottrasladoint();
                BE.moduloid = moduloid.Text.Trim();
                switch (cbo_buscar.SelectedIndex)
                {
                    case 0:
                        BE.mottrasladointname = txt_criterio.Text.Trim();
                        break;
                    case 1:
                        if (txt_criterio.Text.Trim().Length > 0)
                        {
                            BE.mottrasladointid = txt_criterio.Text.Trim().ToUpper().PadLeft(3, '0');
                        }
                        break;
                    case 2:
                        if (txt_criterio.Text.Trim().Length > 0)
                        {
                            BE.tipmov = txt_criterio.Text.Trim();
                        }
                        break;
                    default:
                        //**
                        break;
                }

                Tablamottrasladoint = BL.GetAll(EmpresaID, BE).Tables[0];
                if (Tablamottrasladoint.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    gridmottrasladoint.DataSource = Tablamottrasladoint;
                    gridmottrasladoint.Rows[0].Selected = false;
                    gridmottrasladoint.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridmottrasladoint_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridmottrasladoint.CurrentRow != null)
            {
                String xmoduloid = "", xmottrasladointid = "";
                xmoduloid = gridmottrasladoint.Rows[e.RowIndex].Cells["gmoduloid"].Value.ToString().Trim();
                xmottrasladointid = gridmottrasladoint.Rows[e.RowIndex].Cells["gmottrasladointid"].Value.ToString().Trim();
                data_mottrasladoint(xmoduloid, xmottrasladointid);
            }
        }
        private void gridmottrasladoint_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                String xmottrasladointid = "", xmoduloid = "";
                xmoduloid = gridmottrasladoint.Rows[gridmottrasladoint.CurrentRow.Index].Cells["gmoduloid"].Value.ToString().Trim();
                xmottrasladointid = gridmottrasladoint.Rows[gridmottrasladoint.CurrentRow.Index].Cells["gmottrasladointid"].Value.ToString().Trim();
                data_mottrasladoint(xmoduloid, xmottrasladointid);
            }
        }

        private void gridmottrasladoint_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridmottrasladoint[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            gridmottrasladoint[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            gridmottrasladoint.EnableHeadersVisualStyles = false;
            gridmottrasladoint.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            gridmottrasladoint.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }


        private void gridmottrasladoint_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            gridmottrasladoint[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }

        private void data_mottrasladoint(String xmoduloid, String xmottrasladointid)
        {
            try
            {
                form_bloqueado(false);
                DataRow[] rowmottrasladointid = Tablamottrasladoint.Select("moduloid ='" + xmoduloid + "' and mottrasladointid='" + xmottrasladointid + "'");
                if (rowmottrasladointid.Length > 0)
                {
                    foreach (DataRow row in rowmottrasladointid)
                    {
                        moduloid.Text = row["moduloid"].ToString().Trim();
                        moduloname.Text = row["moduloname"].ToString().Trim();
                        mottrasladointid.Text = row["mottrasladointid"].ToString().Trim();
                        mottrasladointname.Text = row["mottrasladointname"].ToString().Trim();
                        codigosunat.Text = row["codigosunat"].ToString().Trim();
                        if (row["escompra"].ToString().Trim().Length > 0)
                            escompra.Checked = Convert.ToBoolean(row["escompra"]);
                        if (row["esventa"].ToString().Trim().Length > 0)
                            esventa.Checked = Convert.ToBoolean(row["esventa"]);
                        if (row["tipmov"].ToString().Trim().Length > 0)
                        {
                            if (row["tipmov"].ToString().Trim() == "1")
                                tipmov1.Checked = true;
                            else if (row["tipmov"].ToString().Trim() == "2")
                                tipmov2.Checked = true;
                        }
                        else
                        {
                            tipmov1.Checked = false;
                            tipmov2.Checked = false;
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
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region $$$ busqueda
        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            data_Tablamottrasladoint();
        }
        #endregion



        #endregion
    }
}