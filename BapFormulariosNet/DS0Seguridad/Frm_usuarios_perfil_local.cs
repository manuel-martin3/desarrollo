using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.DS0Seguridad
{
    public partial class Frm_usuarios_perfil_local : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = string.Empty;
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable Tablausuarioperfil;
        private DataTable Tablausuariomodulolocal;
        private DataTable Tablaperfil;

        private Boolean procesado = false;

        private String ssModo = string.Empty;

        public Frm_usuarios_perfil_local()
        {
            InitializeComponent();
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
                usuarp.Enabled = var;
                nombrp.Enabled = false;
                idperp.Enabled = var;
                nbperp.Enabled = false;
                gridusuarioperfil.ReadOnly = true;
                gridusuarioperfil.Enabled = !var;

                usuarl.Enabled = var;
                nombrl.Enabled = false;
                locall.Enabled = var;
                localname.Enabled = false;
                gridusuariomodulolocal.ReadOnly = true;
                gridusuariomodulolocal.Enabled = !var;

                idper.Enabled = false;
                nbper.Enabled = var;
                nivel.Enabled = var;
                txt_idper.Enabled = var;
                gridperfil.ReadOnly = true;
                gridperfil.Enabled = !var;

                btn_nuevo.Enabled = false;
                btn_editar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_grabar.Enabled = false;
                btn_eliminar.Enabled = false;

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
                form_bloqueado(false);
                btn_nuevo.Enabled = true;
                btn_editar.Enabled = true;
                btn_salir.Enabled = true;

                ssModo = string.Empty;
            }
        }
        private void data_cbo_dominio()
        {
            try
            {
                var BL = new sys_dominioBL();
                var BE = new tb_sys_dominio();

                dominioid.DataSource = BL.GetAll(EmpresaID, BE).Tables[0];
                dominioid.ValueMember = "dominioid";
                dominioid.DisplayMember = "dominioname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void data_cbo_modulo()
        {
            try
            {
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();

                BE.dominioid = dominioid.SelectedValue.ToString().Trim();

                moduloid.DataSource = BL.GetAll(EmpresaID, BE).Tables[0];
                moduloid.ValueMember = "moduloid";
                moduloid.DisplayMember = "moduloname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void data_cbo_perfil()
        {
            var test = new Dictionary<string, string>();
            test.Add("0", "ADMINISTRADOR(TODO)");
            test.Add("1", "REGISTRAR Y MODIFICAR");
            test.Add("2", "REGISTRAR");
            test.Add("3", "CONSULTAR");
            nivel.DataSource = new BindingSource(test, null);
            nivel.DisplayMember = "Value";
            nivel.ValueMember = "Key";
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
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData )
        {
            if (keyData == Keys.Enter)
            {
                if (GetNextControl(ActiveControl, true) != null)
                {
                    SendKeys.Send("\t");
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
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

        private void AyudaUsuario(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all";
                frmayuda.titulo = "<< AYUDA TABLA USUARIOS >>";
                frmayuda.sqlquery = "SELECT usuar, nombr FROM tb_usuarios";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where";
                frmayuda.sqland = string.Empty;
                frmayuda.criteriosbusqueda = new string[] { "USUARIO", "NOMBRE" };
                frmayuda.columbusqueda = "usuar,nombr";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeUsuario;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
        private void RecibeUsuario(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0 && resultado2.Trim().Length > 0)
            {
                usuarp.Text = resultado1.Trim();
                nombrp.Text = resultado2.Trim();
            }
        }

        private void AyudaPerfil(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();
                var perfil = dominioid.SelectedValue.ToString().Trim() + moduloid.SelectedValue.ToString().Trim();
                frmayuda.tipoo = "all";
                frmayuda.titulo = "<< AYUDA TABLA PERFILES >>";
                frmayuda.sqlquery = "SELECT idper, nbper FROM tb_perfil";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where idper like '" + perfil + "%'";
                frmayuda.sqland = "and";
                frmayuda.criteriosbusqueda = new string[] { "USUARIO", "NOMBRE" };
                frmayuda.columbusqueda = "idper,nbper";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibePerfil;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
        private void RecibePerfil(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0 && resultado2.Trim().Length > 0)
            {
                idperp.Text = resultado1.Trim();
                nbperp.Text = resultado2.Trim();
            }
        }

        private void AyudaUsuario_perfil(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();
                var perfil = dominioid.SelectedValue.ToString().Trim() + moduloid.SelectedValue.ToString().Trim();
                frmayuda.tipoo = "all";
                frmayuda.titulo = "<< AYUDA TABLA USUARIOS >>";
                frmayuda.sqlquery = "select tup.*, tu.nombr from tb_usuariosperfil tup";
                frmayuda.sqlinner = "inner join tb_usuarios tu on tup.usuar = tu.usuar";
                frmayuda.sqlwhere = "where idper like '" + perfil + "%'";
                frmayuda.sqland = "AND";
                frmayuda.criteriosbusqueda = new string[] { "USUARIO", "NOMBRE" };
                frmayuda.columbusqueda = "tu.usuar,tu.nombr";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeUsuario_perfil;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
        private void RecibeUsuario_perfil(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0 && resultado2.Trim().Length > 0)
            {
                usuarl.Text = resultado1.Trim();
                nombrl.Text = resultado2.Trim();
            }
        }

        private void AyudaUsuario_local(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();
                var perfil = dominioid.SelectedValue.ToString().Trim() + moduloid.SelectedValue.ToString().Trim();
                frmayuda.tipoo = "all";
                frmayuda.titulo = "<< AYUDA TABLA LOCAL >>";
                frmayuda.sqlquery = "select tl.[local], tl.localname from tb_sys_local tl";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where (tl.dominioid +tl.moduloid) like '" + perfil + "'";
                frmayuda.sqland = "AND";
                frmayuda.criteriosbusqueda = new string[] { "LOCAL", "CODIGO" };
                frmayuda.columbusqueda = "tl.localname,tl.[local]";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeUsuario_local;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
        private void RecibeUsuario_local(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0 && resultado2.Trim().Length > 0)
            {
                locall.Text = resultado1.Trim();
                localname.Text = resultado2.Trim();
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

                BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiar_usuarioperfil()
        {
            try
            {
                usuarp.Text = string.Empty;
                nombrp.Text = string.Empty;
                idperp.Text = string.Empty;
                nbperp.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void limpiar_usuariomodulolocal()
        {
            try
            {
                usuarl.Text = string.Empty;
                nombrl.Text = string.Empty;
                locall.Text = string.Empty;
                localname.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void limpiar_perfil()
        {
            try
            {
                idper.Text = string.Empty;
                nbper.Text = string.Empty;
                txt_idper.Text = string.Empty;
                nivel.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevo_usuarioperfil()
        {
            ssModo = "NEW";

            limpiar_usuarioperfil();
            form_bloqueado(true);

            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
        }
        private void nuevo_usuariomodulolocal()
        {
            ssModo = "NEW";
            limpiar_usuariomodulolocal();
            form_bloqueado(true);

            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
        }
        private void nuevo_perfil()
        {
            ssModo = "NEW";
            limpiar_perfil();
            form_bloqueado(true);

            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
        }

        private void Insert_usuarioperfil()
        {
            try
            {
                if (usuarp.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Usuario !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (idperp.Text.Trim().Length != 9)
                    {
                        MessageBox.Show("Ingrese Perfil !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new usuariosperfilBL();
                        var BE = new tb_usuariosperfil();

                        BE.usuar = usuarp.Text.Trim().ToUpper();
                        BE.idper = idperp.Text.Trim();

                        if (BL.Insert(EmpresaID, BE))
                        {
                            MessageBox.Show("Datos grabados correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            procesado = true;
                            data_Tablausuarioperfil();
                        }
                        else
                        {
                            MessageBox.Show("Contactese con Sistemas !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Insert_usuariomodulolocal()
        {
            try
            {
                if (usuarl.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Usuario !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (locall.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese Local !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new usuariomodulolocalBL();
                        var BE = new tb_usuariomodulolocal();

                        BE.usuar = usuarl.Text.Trim().ToUpper();
                        BE.dominioid = dominioid.SelectedValue.ToString().Trim();
                        BE.moduloid = moduloid.SelectedValue.ToString().Trim();
                        BE.local = locall.Text.Trim();

                        if (BL.Insert(EmpresaID, BE))
                        {
                            MessageBox.Show("Datos grabados correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            procesado = true;
                            data_Tablausuariomodulolocal();
                        }
                        else
                        {
                            MessageBox.Show("Contactese con Sistemas !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Insert_perfil()
        {
            try
            {
                if (idper.Text.Trim().Length != 9)
                {
                    MessageBox.Show("ID Perfil Incorrecto !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (nbper.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese Nombre de Perfil !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new perfilBL();
                        var BE = new tb_perfil();

                        BE.idper = idper.Text.Trim();
                        BE.nbper = nbper.Text.Trim();

                        if (BL.Insert(EmpresaID, BE))
                        {
                            MessageBox.Show("Datos grabados correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            procesado = true;
                            data_Tablaperfil();
                        }
                        else
                        {
                            MessageBox.Show("Contactese con Sistemas !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Update_usuarioperfil()
        {
            try
            {
                if (usuarp.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Usuario !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (idperp.Text.Trim().Length != 9)
                    {
                        MessageBox.Show("Ingrese Perfil !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new usuariosperfilBL();
                        var BE = new tb_usuariosperfil();

                        BE.usuar = usuarp.Text.Trim().ToUpper();
                        BE.idper = idperp.Text.Trim();

                        if (BL.Update(EmpresaID, BE))
                        {
                            MessageBox.Show("Datos modificado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            procesado = true;
                            data_Tablausuarioperfil();
                        }
                        else
                        {
                            MessageBox.Show("Contactese con Sistemas !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Update_usuariomodulolocal()
        {
            try
            {
                if (usuarl.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Usuario !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (locall.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese Local !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new usuariomodulolocalBL();
                        var BE = new tb_usuariomodulolocal();

                        BE.usuar = usuarl.Text.Trim().ToUpper();
                        BE.dominioid = dominioid.SelectedValue.ToString().Trim();
                        BE.moduloid = moduloid.SelectedValue.ToString().Trim();
                        BE.local = locall.Text.Trim();

                        if (BL.Update(EmpresaID, BE))
                        {
                            MessageBox.Show("Datos modificado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            procesado = true;
                            data_Tablausuariomodulolocal();
                        }
                        else
                        {
                            MessageBox.Show("Contactese con Sistemas !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Update_perfil()
        {
            try
            {
                if (idper.Text.Trim().Length != 9)
                {
                    MessageBox.Show("ID Perfil Incorrecto !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (nbper.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese Nombre de Perfil !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new perfilBL();
                        var BE = new tb_perfil();

                        BE.idper = idper.Text.Trim();
                        BE.nbper = nbper.Text.Trim();

                        if (BL.Update(EmpresaID, BE))
                        {
                            MessageBox.Show("Datos modificado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            procesado = true;
                            data_Tablaperfil();
                        }
                        else
                        {
                            MessageBox.Show("Contactese con Sistemas !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Delete_usuarioperfil()
        {
            try
            {
                if (usuarp.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Usuario !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (idperp.Text.Trim().Length != 9)
                    {
                        MessageBox.Show("Ingrese Perfil !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new usuariosperfilBL();
                        var BE = new tb_usuariosperfil();

                        BE.usuar = usuarp.Text.Trim().ToUpper();
                        BE.idper = idperp.Text.Trim();

                        if (BL.Delete(EmpresaID, BE))
                        {
                            SEGURIDAD_LOG("E");
                            MessageBox.Show("Datos Eliminado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            NIVEL_FORMS();
                            data_Tablausuarioperfil();
                            limpiar_usuarioperfil();
                            form_bloqueado(false);

                            btn_nuevo.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Contactese con Sistemas !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Delete_usuariomodulolocal()
        {
            try
            {
                if (usuarl.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Usuario !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (locall.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese Local !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new usuariomodulolocalBL();
                        var BE = new tb_usuariomodulolocal();

                        BE.usuar = usuarl.Text.Trim().ToUpper();
                        BE.dominioid = dominioid.SelectedValue.ToString().Trim();
                        BE.moduloid = moduloid.SelectedValue.ToString().Trim();
                        BE.local = locall.Text.Trim();

                        if (BL.Delete(EmpresaID, BE))
                        {
                            MessageBox.Show("Datos modificado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            procesado = true;
                            NIVEL_FORMS();
                            data_Tablausuariomodulolocal();
                            limpiar_usuarioperfil();
                            form_bloqueado(false);

                            btn_nuevo.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Contactese con Sistemas !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Delete_perfil()
        {
            try
            {
                if (idper.Text.Trim().Length != 9)
                {
                    MessageBox.Show("ID Perfil Incorrecto !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (nbper.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese Nombre de Perfil !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new perfilBL();
                        var BE = new tb_perfil();

                        BE.idper = idper.Text.Trim();
                        BE.nbper = nbper.Text.Trim();

                        if (BL.Delete(EmpresaID, BE))
                        {
                            SEGURIDAD_LOG("E");
                            MessageBox.Show("Datos Eliminado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            NIVEL_FORMS();
                            data_Tablaperfil();
                            limpiar_perfil();
                            form_bloqueado(false);

                            btn_nuevo.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Contactese con Sistemas !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_admin_usuario_perfil_Activated(object sender, EventArgs e)
        {
        }

        private void Frm_admin_usuario_perfil_Load(object sender, EventArgs e)
        {
            dominio = ((DS0Seguridad.MainSeguridad)MdiParent).dominioid;
            modulo = ((DS0Seguridad.MainSeguridad)MdiParent).moduloid;
            local = ((DS0Seguridad.MainSeguridad)MdiParent).local;
            PERFILID = ((DS0Seguridad.MainSeguridad)MdiParent).perfil;

            NIVEL_FORMS();
            data_cbo_dominio();
            dominioid.SelectedValue = dominio.Trim();
            data_cbo_modulo();
            moduloid.SelectedValue = modulo.Trim();

            form_bloqueado(false);
            if (tabcontrol.SelectedIndex == 0)
            {
                data_Tablausuarioperfil();
                btn_nuevo.Enabled = true;
            }
        }
        private void Frm_admin_usuario_perfil_KeyDown(object sender, KeyEventArgs e)
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
                if (tabcontrol.SelectedIndex == 0)
                {
                    nuevo_usuarioperfil();
                }
                if (tabcontrol.SelectedIndex == 1)
                {
                    nuevo_usuariomodulolocal();
                }
                if (tabcontrol.SelectedIndex == 2)
                {
                    nuevo_perfil();
                }
            }
        }
        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0" || XNIVEL == "1")
            {
                if (usuarp.Text.Trim().Length > 0 || usuarl.Text.Trim().Length > 0 || idper.Text.Trim().Length > 0)
                {
                    ssModo = "EDIT";

                    form_bloqueado(true);

                    nivel.Enabled = false;

                    btn_cancelar.Enabled = true;
                    btn_grabar.Enabled = true;
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
                    if (tabcontrol.SelectedIndex == 0)
                    {
                        Insert_usuarioperfil();
                    }
                    if (tabcontrol.SelectedIndex == 1)
                    {
                        Insert_usuariomodulolocal();
                    }
                    if (tabcontrol.SelectedIndex == 2)
                    {
                        Insert_perfil();
                    }
                }
            }
            else
            {
                if (XNIVEL == "0" || XNIVEL == "1")
                {
                    sw_prosigue = (MessageBox.Show("¿Desea Modificar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                    if (sw_prosigue)
                    {
                        if (tabcontrol.SelectedIndex == 0)
                        {
                            Update_usuarioperfil();
                        }
                        if (tabcontrol.SelectedIndex == 1)
                        {
                            Update_usuariomodulolocal();
                        }
                        if (tabcontrol.SelectedIndex == 2)
                        {
                            Update_perfil();
                        }
                    }
                }
            }
            if (procesado)
            {
                NIVEL_FORMS();
                form_bloqueado(false);

                btn_editar.Enabled = true;
                btn_log.Enabled = true;
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
                    if (tabcontrol.SelectedIndex == 0)
                    {
                        Delete_usuarioperfil();
                    }
                    if (tabcontrol.SelectedIndex == 1)
                    {
                        Delete_usuariomodulolocal();
                    }
                    if (tabcontrol.SelectedIndex == 2)
                    {
                        Delete_perfil();
                    }
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
        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tabcontrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tc = (TabControl)sender;
            var s = string.Empty;
            var tp = tc.TabPages[tc.SelectedIndex];
            s = tp.Name;
            form_bloqueado(false);
            if (s == "tabusuarioperfil")
            {
                limpiar_usuarioperfil();
                data_Tablausuarioperfil();
                btn_nuevo.Enabled = true;
            }
            if (s == "tabusuariomodulolocal")
            {
                limpiar_usuariomodulolocal();
                data_Tablausuariomodulolocal();
                btn_nuevo.Enabled = true;
            }
            if (s == "tabperfil")
            {
                data_cbo_perfil();
                limpiar_perfil();
                data_Tablaperfil();
                btn_nuevo.Enabled = true;
            }
        }

        private void usuarp_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaUsuario(string.Empty);
            }
        }
        private void idperp_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaPerfil(string.Empty);
            }
        }
        private void data_Tablausuarioperfil()
        {
            try
            {
                if (Tablausuarioperfil != null)
                {
                    Tablausuarioperfil.Rows.Clear();
                }
                var BL = new usuariosperfilBL();
                var BE = new tb_usuariosperfil();

                BE.idper = dominioid.SelectedValue.ToString().Trim() + moduloid.SelectedValue.ToString().Trim();

                Tablausuarioperfil = BL.GetAll(EmpresaID, BE).Tables[0];
                if (Tablausuarioperfil.Rows.Count > 0)
                {
                    gridusuarioperfil.DataSource = Tablausuarioperfil;
                    gridusuarioperfil.Rows[0].Selected = false;
                    gridusuarioperfil.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridusuarioperfil_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridusuarioperfil.CurrentRow != null)
                {
                    var xusuar = string.Empty;
                    var xidper = string.Empty;
                    xusuar = gridusuarioperfil.Rows[e.RowIndex].Cells["ggusuar"].Value.ToString().Trim();
                    xidper = gridusuarioperfil.Rows[e.RowIndex].Cells["ggidper"].Value.ToString().Trim();
                    data_usuarioperfil(xusuar, xidper);
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void gridusuarioperfil_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xusuar = string.Empty;
                var xidper = string.Empty;
                xusuar = gridusuarioperfil.Rows[gridusuarioperfil.CurrentRow.Index].Cells["ggusuar"].Value.ToString().Trim();
                xidper = gridusuarioperfil.Rows[gridusuarioperfil.CurrentRow.Index].Cells["ggidper"].Value.ToString().Trim();
                data_usuarioperfil(xusuar, xidper);
            }
        }
        private void gridusuarioperfil_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridusuarioperfil.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridusuarioperfil[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(39, 95, 178);
            gridusuarioperfil[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);
        }
        private void gridusuarioperfil_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            gridusuarioperfil[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }
        private void data_usuarioperfil(String xusuar, String xidper)
        {
            form_bloqueado(false);
            var rowtipodoc = Tablausuarioperfil.Select("usuar='" + xusuar.Trim() + "' and idper ='" + xidper.Trim() + "'");
            if (rowtipodoc.Length > 0)
            {
                foreach (DataRow row in rowtipodoc)
                {
                    ssModo = "EDIT";
                    limpiar_usuarioperfil();

                    usuarp.Text = row["usuar"].ToString().Trim();
                    nombrp.Text = row["nombr"].ToString().Trim();
                    idperp.Text = row["idper"].ToString().Trim();
                    nbperp.Text = row["nbper"].ToString().Trim();
                }

                btn_nuevo.Enabled = true;
                if (idperp.Text.Trim().Substring(8) != "0")
                {
                    btn_editar.Enabled = true;
                    btn_eliminar.Enabled = true;
                }
                btn_editar.Enabled = true;
                btn_eliminar.Enabled = true;
                btn_log.Enabled = true;
                btn_salir.Enabled = true;
            }
        }

        private void usuarl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaUsuario_perfil(string.Empty);
            }
        }
        private void locall_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaUsuario_local(string.Empty);
            }
        }
        private void data_Tablausuariomodulolocal()
        {
            try
            {
                if (Tablausuariomodulolocal != null)
                {
                    Tablausuariomodulolocal.Rows.Clear();
                }
                var BL = new usuariomodulolocalBL();
                var BE = new tb_usuariomodulolocal();
                BE.dominioid = dominioid.SelectedValue.ToString().Trim();
                BE.moduloid = moduloid.SelectedValue.ToString().Trim();

                Tablausuariomodulolocal = BL.GetAll(EmpresaID, BE).Tables[0];
                if (Tablausuariomodulolocal.Rows.Count > 0)
                {
                    gridusuariomodulolocal.DataSource = Tablausuariomodulolocal;
                    gridusuariomodulolocal.Rows[0].Selected = false;
                    gridusuariomodulolocal.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridusuariomodulolocal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridusuariomodulolocal.CurrentRow != null)
                {
                    var xusuar = string.Empty;
                    var xlocal = string.Empty;
                    xusuar = gridusuariomodulolocal.Rows[e.RowIndex].Cells["gusuar"].Value.ToString().Trim();
                    xlocal = gridusuariomodulolocal.Rows[e.RowIndex].Cells["glocal"].Value.ToString().Trim();
                    data_usuariomodulolocal(xusuar, xlocal);
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void gridusuariomodulolocal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xusuar = string.Empty;
                var xlocal = string.Empty;
                xusuar = gridusuariomodulolocal.Rows[gridusuariomodulolocal.CurrentRow.Index].Cells["gusuar"].Value.ToString().Trim();
                xlocal = gridusuariomodulolocal.Rows[gridusuariomodulolocal.CurrentRow.Index].Cells["glocal"].Value.ToString().Trim();
                data_usuariomodulolocal(xusuar, xlocal);
            }
        }
        private void gridusuariomodulolocal_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridusuariomodulolocal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridusuariomodulolocal[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(39, 95, 178);
            gridusuariomodulolocal[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);
        }
        private void gridusuariomodulolocal_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            gridusuariomodulolocal[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }
        private void data_usuariomodulolocal(String xusuar, String xlocal)
        {
            form_bloqueado(false);
            var rowtipodoc = Tablausuariomodulolocal.Select("usuar='" + xusuar.Trim() + "' and local ='" + xlocal.Trim() + "'");
            if (rowtipodoc.Length > 0)
            {
                foreach (DataRow row in rowtipodoc)
                {
                    ssModo = "EDIT";
                    limpiar_usuariomodulolocal();

                    usuarl.Text = row["usuar"].ToString().Trim();
                    nombrl.Text = row["nombr"].ToString().Trim();
                    locall.Text = row["local"].ToString().Trim();
                    localname.Text = row["localname"].ToString().Trim();
                }

                btn_nuevo.Enabled = true;
                btn_editar.Enabled = true;
                btn_eliminar.Enabled = true;

                btn_log.Enabled = true;
                btn_salir.Enabled = true;
            }
        }

        private void txt_idper_TextChanged(object sender, EventArgs e)
        {
            if (nivel.SelectedIndex != -1)
            {
                idper.Text = dominioid.SelectedValue.ToString().Trim() + moduloid.SelectedValue.ToString().Trim() +
                                txt_idper.Text.Trim().PadRight(2, '0') +
                                nivel.SelectedValue.ToString().Trim();
            }
            else
            {
                idper.Text = dominioid.SelectedValue.ToString().Trim() + moduloid.SelectedValue.ToString().Trim() +
                                txt_idper.Text.Trim().PadRight(2, '0');
            }
        }
        private void nivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (nivel.SelectedIndex != -1)
            {
                idper.Text = dominioid.SelectedValue.ToString().Trim() + moduloid.SelectedValue.ToString().Trim() +
                             txt_idper.Text.Trim().PadRight(2, '0') +
                             nivel.SelectedValue.ToString().Trim();
            }
        }
        private void data_Tablaperfil()
        {
            try
            {
                if (Tablaperfil != null)
                {
                    Tablaperfil.Rows.Clear();
                }
                var BL = new perfilBL();
                var BE = new tb_perfil();

                var xaa = dominioid.SelectedValue.ToString().Trim() + moduloid.SelectedValue.ToString().Trim();
                BE.idper = xaa;

                Tablaperfil = BL.GetAll(EmpresaID, BE).Tables[0];
                if (Tablaperfil.Rows.Count > 0)
                {
                    gridperfil.DataSource = Tablaperfil;
                    gridperfil.Rows[0].Selected = false;
                    gridperfil.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridperfil_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridperfil.CurrentRow != null)
                {
                    var xidper = string.Empty;
                    xidper = gridperfil.Rows[e.RowIndex].Cells["gidper"].Value.ToString().Trim();
                    data_perfil(xidper);
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void gridperfil_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xidper = string.Empty;
                xidper = gridperfil.Rows[gridperfil.CurrentRow.Index].Cells["gidper"].Value.ToString().Trim();
                data_perfil(xidper);
            }
        }
        private void gridperfil_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridperfil.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridperfil[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(39, 95, 178);
            gridperfil[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);
        }
        private void gridperfil_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            gridperfil[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }
        private void data_perfil(String xidper)
        {
            form_bloqueado(false);
            var rowtipodoc = Tablaperfil.Select("idper='" + xidper.Trim() + "'");
            if (rowtipodoc.Length > 0)
            {
                foreach (DataRow row in rowtipodoc)
                {
                    ssModo = "EDIT";
                    limpiar_perfil();

                    idper.Text = row["idper"].ToString().Trim();
                    nbper.Text = row["nbper"].ToString().Trim();
                    txt_idper.Text = row["idper"].ToString().Trim().Substring(6, 2);
                    nivel.SelectedValue = row["idper"].ToString().Trim().Substring(8);
                }

                btn_nuevo.Enabled = true;
                if (idper.Text.Trim().Substring(8) != "0")
                {
                    btn_editar.Enabled = true;
                    btn_eliminar.Enabled = true;
                }

                btn_log.Enabled = true;
                btn_salir.Enabled = true;
            }
        }

        private void dominioid_SelectedIndexChanged(object sender, EventArgs e)
        {
            data_cbo_modulo();
        }

        private void moduloid_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiar_usuarioperfil();
            data_Tablausuarioperfil();
            limpiar_usuariomodulolocal();
            data_Tablausuariomodulolocal();

            data_cbo_perfil();
            limpiar_perfil();
            data_Tablaperfil();
        }
    }
}
