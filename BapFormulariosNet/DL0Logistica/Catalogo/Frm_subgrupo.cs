using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.DL0Logistica.Catalogo
{
    public partial class Frm_subgrupo : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String dominioiddes = "60";
        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable Tablasubgrupo;
        private String _articulo = string.Empty;
        private Boolean procesado = false;

        private String ssModo = "NEW";

        public Frm_subgrupo()
        {
            InitializeComponent();
            subgrupoid.LostFocus += new System.EventHandler(subgrupoid_LostFocus);
            lineaid.LostFocus += new System.EventHandler(lineaid_LostFocus);
            grupoid.LostFocus += new System.EventHandler(grupoid_LostFocus);
            subgrupoartic.TextChanged += new System.EventHandler(subgrupoartic_TextChanged);
        }

        private void PARAMETROS_TABLA()
        {
            var xxferfil = string.Empty;
            var f = (DL0Logistica.MainLogistica)MdiParent;
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
            if (modulo.ToString() == "0100")
            {
                subgrupoid.Enabled = !var;
                subgruponame.Enabled = false;
                subgrupoartic.Enabled = var;
                lineaid.Enabled = var;
                lineaname.Enabled = false;
                grupoid.Enabled = var;
                gruponame.Enabled = false;
                gridsubgrupo.ReadOnly = true;
                gridsubgrupo.Enabled = !var;
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
                btn_clave.Enabled = true;
                btn_log.Enabled = true;
                btn_salir.Enabled = false;
            }
            else
            {
                moduloiddes.Enabled = false;
                localdes.Enabled = false;

                subgrupoid.Enabled = !var;
                subgruponame.Enabled = false;
                subgrupoartic.Enabled = var;
                lineaid.Enabled = var;
                lineaname.Enabled = false;
                grupoid.Enabled = var;
                gruponame.Enabled = false;
                gridsubgrupo.ReadOnly = true;
                gridsubgrupo.Enabled = !var;
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
                btn_clave.Enabled = true;
                btn_log.Enabled = true;
                btn_salir.Enabled = false;
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
                subgrupoid.Text = string.Empty;
                btn_nuevo.Enabled = true;
                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;
                btn_salir.Enabled = true;

                ssModo = "NEW";
            }
        }
        private void form_cargar_datos(String posicion)
        {
            try
            {
                var BL = new tb_60subgrupoBL();
                var BE = new tb_60subgrupo();
                var dt = new DataTable();

                BE.moduloid = moduloiddes.SelectedValue.ToString();
                if (moduloiddes.SelectedValue.ToString() == "0000")
                {
                    MessageBox.Show("Seleccione Almacen", "Information");
                    return;
                }
                BE.lineaid = lineaid.Text.Trim().PadLeft(3, '0');
                BE.grupoid = grupoid.Text.Trim().PadLeft(4, '0');
                if (subgrupoid.Text.Trim().Length > 0)
                {
                    BE.subgrupoid = subgrupoid.Text.Trim().PadLeft(3, '0');
                }
                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    limpiar_documento();
                    ssModo = "EDIT";

                    lineaid.Text = dt.Rows[0]["lineaid"].ToString().Trim();
                    lineaname.Text = dt.Rows[0]["lineaname"].ToString().Trim();
                    grupoid.Text = dt.Rows[0]["grupoid"].ToString().Trim();
                    gruponame.Text = dt.Rows[0]["gruponame"].ToString().Trim();
                    subgrupoid.Text = dt.Rows[0]["subgrupoid"].ToString().Trim();
                    subgruponame.Text = dt.Rows[0]["subgruponame"].ToString().Trim();
                    subgrupoartic.Text = dt.Rows[0]["subgrupoartic"].ToString().Trim();

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void generar_denominacion()
        {
            if (moduloiddes.SelectedValue.ToString() == "0500")
            {
                subgruponame.Text = gruponame.Text.ToString() + _articulo.ToString();
            }
            else
            {
                if (moduloiddes.SelectedValue.ToString() == "0340" ||
                moduloiddes.SelectedValue.ToString() == "0350" ||
                moduloiddes.SelectedValue.ToString() == "0360" ||
                moduloiddes.SelectedValue.ToString() == "0370" ||
                moduloiddes.SelectedValue.ToString() == "0510" ||
                moduloiddes.SelectedValue.ToString() == "0520" ||
                moduloiddes.SelectedValue.ToString() == "0530" ||
                moduloiddes.SelectedValue.ToString() == "0540")
                {
                    subgruponame.Text = lineaname.Text.ToString() + _articulo.ToString();
                }
                else
                {
                    subgruponame.Text = lineaname.Text + " " + gruponame.Text.ToString() + " " + _articulo.ToString();
                }
            }
        }

        private void data_cbo_buscar()
        {
            cbo_buscar.Items.Add(new System.Web.UI.WebControls.ListItem("NOMBRE SUBGRUPO", "01"));
            cbo_buscar.Items.Add(new System.Web.UI.WebControls.ListItem("COD SUBGRUPO", "02"));
            cbo_buscar.Items.Add(new System.Web.UI.WebControls.ListItem("COD GRUPO", "03"));
            cbo_buscar.Items.Add(new System.Web.UI.WebControls.ListItem("COD LINEA", "04"));
            cbo_buscar.SelectedIndex = 0;
        }

        private void ValidaLinea()
        {
            if (lineaid.Text.Trim().Length > 0 && ssModo == "NEW")
            {
                var BL = new tb_60lineaBL();
                var BE = new tb_60linea();
                var dt = new DataTable();

                BE.moduloid = moduloiddes.SelectedValue.ToString();
                if (moduloiddes.SelectedValue.ToString() == "0000")
                {
                    MessageBox.Show("Seleccione Almacen", "Information");
                    return;
                }
                BE.lineaid = lineaid.Text.Trim().PadLeft(3, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    lineaid.Text = dt.Rows[0]["lineaid"].ToString().Trim();
                    lineaname.Text = dt.Rows[0]["lineaname"].ToString().Trim();
                    generar_denominacion();
                }
                else
                {
                    lineaid.Text = string.Empty;
                    lineaname.Text = string.Empty;
                    generar_denominacion();
                }
            }
            if (lineaid.Text.Trim().Length == 0 && ssModo == "NEW")
            {
                lineaid.Text = string.Empty;
                lineaname.Text = string.Empty;
                generar_denominacion();
            }
        }

        private void ValidaGrupo()
        {
            if (grupoid.Text.Trim().Length > 0 && ssModo == "NEW")
            {
                var BL = new tb_60grupoBL();
                var BE = new tb_60grupo();
                var dt = new DataTable();

                BE.moduloid = moduloiddes.SelectedValue.ToString();
                if (moduloiddes.SelectedValue.ToString() == "0000")
                {
                    MessageBox.Show("Seleccione Almacen", "Information");
                    return;
                }
                BE.grupoid = grupoid.Text.Trim().PadLeft(4, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    grupoid.Text = dt.Rows[0]["grupoid"].ToString().Trim();
                    gruponame.Text = dt.Rows[0]["gruponame"].ToString().Trim();
                    generar_denominacion();
                }
                else
                {
                    grupoid.Text = string.Empty;
                    gruponame.Text = string.Empty;
                    generar_denominacion();
                }
            }
            if (grupoid.Text.Trim().Length == 0 && ssModo == "NEW")
            {
                grupoid.Text = string.Empty;
                gruponame.Text = string.Empty;
                generar_denominacion();
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

        private void AyudaLinea(String lpdescrlike)
        {
            try
            {
                var modd = string.Empty;
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();

                BE.dominioid = dominioiddes;
                BE.moduloid = moduloiddes.SelectedValue.ToString();
                if (moduloiddes.SelectedValue.ToString() == "0000")
                {
                    MessageBox.Show("Seleccione Almacen", "Information");
                    return;
                }

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();

                        var frmayuda = new Ayudas.Frm_help_general();

                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA  TABLA LINEA >>";
                        frmayuda.sqlquery = "SELECT lineaid, lineaname FROM tb_" + modd + "_linea ";
                        frmayuda.sqlinner = string.Empty;
                        frmayuda.sqlwhere = "where";
                        frmayuda.sqland = string.Empty;
                        frmayuda.criteriosbusqueda = new string[] { "LINEA", "CODIGO" };
                        frmayuda.columbusqueda = "lineaname,lineaid";
                        frmayuda.returndatos = "0,1";

                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeLinea;
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }


        private void RecibeLinea(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                lineaid.Text = resultado1.Trim();
                lineaname.Text = resultado2.Trim();
            }
        }

        private void AyudaGrupo(String lpdescrlike)
        {
            try
            {
                var modd = string.Empty;
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();

                BE.dominioid = dominioiddes;
                BE.moduloid = moduloiddes.SelectedValue.ToString();
                if (moduloiddes.SelectedValue.ToString() == "0000")
                {
                    MessageBox.Show("Seleccione Almacen", "Information");
                    return;
                }
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();

                        var frmayuda = new Ayudas.Frm_help_general();

                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA TABLA GRUPOS >>";
                        frmayuda.sqlquery = "SELECT grupoid, gruponame FROM tb_" + modd + "_grupo g ";
                        frmayuda.sqlinner = string.Empty;
                        frmayuda.sqlwhere = "where g.status != '9' ";
                        frmayuda.sqland = "and";
                        frmayuda.criteriosbusqueda = new string[] { "GRUPO", "CODIGO" };
                        frmayuda.columbusqueda = "gruponame,grupoid";
                        frmayuda.returndatos = "0,1";

                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeGrupo;
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void RecibeGrupo(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                grupoid.Text = resultado1.Trim();
                gruponame.Text = resultado2.Trim();
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
                BE.detalle = lineaid.Text.Trim() + grupoid.Text.Trim() + subgrupoid.Text.Trim() + "/" + subgruponame.Text.Trim().ToUpper() + "/" + subgrupoartic.Text.Trim() + "/" + XGLOSA;

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
                if (VariablesPublicas.EmpresaSigla == "VIALEX")
                {
                    lblnamesubgrupo.Text = "MODELO";
                }

                if (modulo.ToString() == "0100")
                {
                    lineaid.Text = string.Empty;
                    lineaname.Text = string.Empty;
                    grupoid.Text = string.Empty;
                    gruponame.Text = string.Empty;
                    subgrupoid.Text = string.Empty;
                    subgruponame.Text = string.Empty;
                    subgrupoartic.Text = string.Empty;
                }
                else
                {
                    moduloiddes.SelectedValue = modulo.ToString();
                    localdes.SelectedValue = local.ToString();
                    lineaid.Text = string.Empty;
                    lineaname.Text = string.Empty;
                    grupoid.Text = string.Empty;
                    gruponame.Text = string.Empty;
                    subgrupoid.Text = string.Empty;
                    subgruponame.Text = string.Empty;
                    subgrupoartic.Text = string.Empty;
                }
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
            subgrupoid.Text = "NEW";
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_log.Enabled = true;
            lineaid.Focus();

            ssModo = "NEW";
        }

        private void Insert()
        {
            try
            {
                if (subgrupoid.Text.Trim().Length != 3)
                {
                    MessageBox.Show("Falta Codigo subgrupo !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (subgruponame.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese nombre de subgrupo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new tb_60subgrupoBL();
                        var BE = new tb_60subgrupo();

                        BE.moduloid = moduloiddes.SelectedValue.ToString();
                        BE.lineaid = lineaid.Text.Trim().PadLeft(3, '0');
                        BE.grupoid = grupoid.Text.Trim().PadLeft(4, '0');
                        BE.subgrupoid = subgrupoid.Text.Trim().PadLeft(3, '0');
                        BE.subgruponame = subgruponame.Text.ToUpper();
                        BE.subgrupoartic = subgrupoartic.Text.Trim().ToUpper();
                        BE.usuar = VariablesPublicas.Usuar.Trim();

                        if (BL.Insert(EmpresaID, BE))
                        {
                            MessageBox.Show("Datos grabados correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            procesado = true;
                        }
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
                if (subgrupoid.Text.Trim().Length != 3)
                {
                    MessageBox.Show("Falta Codigo subgrupo !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (subgruponame.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese nombre de subgrupo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new tb_60subgrupoBL();
                        var BE = new tb_60subgrupo();
                        BE.moduloid = moduloiddes.SelectedValue.ToString();
                        BE.lineaid = lineaid.Text.Trim().PadLeft(3, '0');
                        BE.grupoid = grupoid.Text.Trim().PadLeft(4, '0');
                        BE.subgrupoid = subgrupoid.Text.Trim().PadLeft(3, '0');
                        BE.subgruponame = subgruponame.Text.ToUpper();
                        BE.subgrupoartic = subgrupoartic.Text.Trim().ToUpper();

                        BE.usuar = VariablesPublicas.Usuar.Trim();

                        if (BL.Update(EmpresaID, BE))
                        {
                            SEGURIDAD_LOG("M");
                            MessageBox.Show("Datos modificado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            procesado = true;
                        }
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
                if (subgrupoid.Text.Trim().Length != 3)
                {
                    MessageBox.Show("Falta Codigo subgrupo !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_60subgrupoBL();
                    var BE = new tb_60subgrupo();
                    BE.moduloid = moduloiddes.SelectedValue.ToString();
                    BE.lineaid = lineaid.Text.Trim().PadLeft(3, '0');
                    BE.grupoid = grupoid.Text.Trim().PadLeft(4, '0');
                    BE.subgrupoid = subgrupoid.Text.Trim().PadLeft(3, '0');
                    BE.subgruponame = subgruponame.Text.ToUpper();
                    BE.usuar = VariablesPublicas.Usuar.Trim();

                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos Eliminado correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        limpiar_documento();
                        form_bloqueado(false);
                        data_Tablasubgrupo();
                        btn_nuevo.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_subgrupo_Activated(object sender, EventArgs e)
        {
        }
        private void data_cbo_moduloiddes()
        {
            try
            {
                sys_moduloBL BL = new sys_moduloBL();
                tb_sys_modulo BE = new tb_sys_modulo();
                BE.dominioid = dominioiddes.Trim();
                BE.status = "0";

                moduloiddes.DataSource = BL.GetAll(EmpresaID, BE).Tables[0];
                moduloiddes.ValueMember = "moduloid";
                moduloiddes.DisplayMember = "moduloname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_subgrupo_Load(object sender, EventArgs e)
        {
            switch (Parent.Parent.Name)
            {
                case "MainLogistica":
                    modulo = ((DL0Logistica.MainLogistica)MdiParent).moduloid;
                    local = ((DL0Logistica.MainLogistica)MdiParent).local;
                    PERFILID = ((DL0Logistica.MainLogistica)MdiParent).perfil;
                    break;
                case "MainAlmacen":
                    modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
                    local = ((D60ALMACEN.MainAlmacen)MdiParent).local;
                    PERFILID = ((D60ALMACEN.MainAlmacen)MdiParent).perfil;
                    break;
                case "MainMercaderia":
                    modulo = ((MERCADERIA.MainMercaderia)MdiParent).moduloid;
                    local = ((MERCADERIA.MainMercaderia)MdiParent).local;
                    PERFILID = ((MERCADERIA.MainMercaderia)MdiParent).perfil;
                    break;
                default:
                    break;
            }
            //if (Parent.Parent.Name == "MainLogistica")
            //{
            //    modulo = ((DL0Logistica.MainLogistica)MdiParent).moduloid;
            //    local = ((DL0Logistica.MainLogistica)MdiParent).local;
            //    PERFILID = ((DL0Logistica.MainLogistica)MdiParent).perfil;
            //}

            //if (Parent.Parent.Name == "MainAlmacen")
            //{
            //    modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
            //    local = ((D60ALMACEN.MainAlmacen)MdiParent).local;
            //    PERFILID = ((D60ALMACEN.MainAlmacen)MdiParent).perfil;
            //}

            data_cbo_moduloiddes();
            NIVEL_FORMS();
            data_cbo_buscar();
            Tablasubgrupo = new DataTable();
            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_primero.Enabled = true;
            btn_anterior.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_ultimo.Enabled = true;
            btn_salir.Enabled = true;
        }

        private void Frm_subgrupo_KeyDown(object sender, KeyEventArgs e)
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

        private void lineaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaLinea(string.Empty);
            }

            if (e.KeyCode == Keys.Enter)
            {
                grupoid.Focus();
            }
        }

        private void lineaid_LostFocus(object sender, System.EventArgs e)
        {
            ValidaLinea();
        }

        private void grupoid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaGrupo(string.Empty);
            }

            if (e.KeyCode == Keys.Enter)
            {
                subgrupoartic.Focus();
            }
        }

        private void grupoid_LostFocus(object sender, System.EventArgs e)
        {
            ValidaGrupo();
        }

        private void subgrupoid_LostFocus(object sender, System.EventArgs e)
        {
        }

        private void subgrupoartic_TextChanged(object sender, EventArgs e)
        {
            if (subgrupoartic.Text == string.Empty)
            {
                _articulo = string.Empty;
                generar_denominacion();
            }
            else
            {
                _articulo = " " + subgrupoartic.Text.ToString();
                generar_denominacion();
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
                lineaid.Enabled = false;
                grupoid.Enabled = false;
                subgruponame.Focus();

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
                data_Tablasubgrupo();
                form_bloqueado(false);
                subgrupoid.Text = string.Empty;

                btn_nuevo.Enabled = true;
                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;
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
                if (Tablasubgrupo.Rows.Count > 0)
                {
                    var miForma = new Reportes.Frm_reportes();

                    miForma.dominioid = dominioiddes.Trim();
                    miForma.moduloid = moduloiddes.SelectedValue.ToString().Trim();
                    miForma.local = local.Trim();

                    miForma.Text = "Reporte de subgrupos";
                    miForma.formulario = "Frm_subgrupo";
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

        private void data_Tablasubgrupo()
        {
            try
            {
                if (Tablasubgrupo.Rows.Count > 0)
                {
                    Tablasubgrupo.Rows.Clear();
                }
                var BL = new tb_60subgrupoBL();
                var BE = new tb_60subgrupo();

                switch (cbo_buscar.SelectedIndex)
                {
                    case 0:
                        BE.subgruponame = txt_criterio.Text.Trim();
                        break;
                    case 1:
                        if (txt_criterio.Text.Trim().Length > 0)
                        {
                            BE.subgrupoid = txt_criterio.Text.Trim().ToUpper().PadLeft(3, '0');
                        }
                        break;
                    case 2:
                        if (txt_criterio.Text.Trim().Length > 0)
                        {
                            BE.grupoid = txt_criterio.Text.Trim().ToUpper().PadLeft(4, '0');
                        }
                        break;
                    case 3:
                        if (txt_criterio.Text.Trim().Length > 0)
                        {
                            BE.lineaid = txt_criterio.Text.Trim().ToUpper().PadLeft(3, '0');
                        }
                        break;
                    default:
                        break;
                }

                BE.moduloid = moduloiddes.SelectedValue.ToString();
                if (moduloiddes.SelectedValue.ToString() == "0000")
                {
                    MessageBox.Show("Seleccione Almacen", "Information");
                    return;
                }

                Tablasubgrupo = BL.GetAll(EmpresaID, BE).Tables[0];
                if (Tablasubgrupo.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    gridsubgrupo.DataSource = Tablasubgrupo;
                    gridsubgrupo.Rows[0].Selected = false;
                    gridsubgrupo.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridsubgrupo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridsubgrupo.CurrentRow != null)
                {
                    var xsubgrupoid = string.Empty;
                    xsubgrupoid = gridsubgrupo.Rows[e.RowIndex].Cells["codconcat"].Value.ToString().Trim();
                    data_subgrupo(xsubgrupoid);
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void gridsubgrupo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xsubgrupoid = string.Empty;
                xsubgrupoid = gridsubgrupo.Rows[gridsubgrupo.CurrentRow.Index].Cells["codconcat"].Value.ToString().Trim();
                data_subgrupo(xsubgrupoid);
            }
        }

        private void gridsubgrupo_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridsubgrupo[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            gridsubgrupo[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            gridsubgrupo.EnableHeadersVisualStyles = false;
            gridsubgrupo.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            gridsubgrupo.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void gridsubgrupo_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            gridsubgrupo[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }

        private void data_subgrupo(String xsubgrupoid)
        {
            subgrupoartic.TextChanged -= new System.EventHandler(subgrupoartic_TextChanged);
            form_bloqueado(false);
            var rowsubgrupoid = Tablasubgrupo.Select("codconcat='" + xsubgrupoid + "'");
            if (rowsubgrupoid.Length > 0)
            {
                foreach (DataRow row in rowsubgrupoid)
                {
                    lineaid.Text = row["lineaid"].ToString().Trim();
                    lineaname.Text = row["lineaname"].ToString().Trim();
                    grupoid.Text = row["grupoid"].ToString().Trim();
                    gruponame.Text = row["gruponame"].ToString().Trim();

                    subgrupoid.Text = row["subgrupoid"].ToString().Trim();
                    subgruponame.Text = row["subgruponame"].ToString().Trim();
                    subgrupoartic.Text = row["subgrupoartic"].ToString().Trim();
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
            subgrupoartic.TextChanged += new System.EventHandler(subgrupoartic_TextChanged);
        }

        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            data_Tablasubgrupo();
        }

        private void btnfijar_Click(object sender, EventArgs e)
        {
            moduloiddes.Enabled = !moduloiddes.Enabled;
        }

        private void moduloiddes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (moduloiddes.Items.Count > 0)
            {
                get_dominio_modulo_local(dominio.ToString(), moduloiddes.SelectedValue.ToString());
            }
        }

        private void get_dominio_modulo_local(string dominioid, string moduloid)
        {
            if (moduloid.ToString().Length == 4)
            {
                var BL = new usuariomodulolocalBL();
                var BE = new tb_usuariomodulolocal();
                var dt = new DataTable();
                BE.usuar = VariablesPublicas.Usuar.Trim();
                BE.dominioid = dominioid;
                BE.moduloid = moduloid;

                dt = BL.GetAll3(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    localdes.DataSource = dt;
                    localdes.ValueMember = "local";
                    localdes.DisplayMember = "localname";
                }
            }
        }
    }
}
