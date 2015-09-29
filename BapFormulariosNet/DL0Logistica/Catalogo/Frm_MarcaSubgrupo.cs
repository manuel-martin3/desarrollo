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
    public partial class Frm_MarcaSubgrupo : plantilla
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

        public Frm_MarcaSubgrupo()
        {
            InitializeComponent();
            txt_subgrupoid.LostFocus += new System.EventHandler(subgrupoid_LostFocus);
            txt_lineaid.LostFocus += new System.EventHandler(lineaid_LostFocus);
            txt_grupoid.LostFocus += new System.EventHandler(grupoid_LostFocus);
            txt_marcaname.TextChanged += new System.EventHandler(subgrupoartic_TextChanged);
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
                txt_lineaid.Enabled = false;
                txt_lineaname.Enabled = false;
                txt_subgrupoid.Enabled = var;
                txt_subgruponame.Enabled = false;               
               
                txt_grupoid.Enabled = false;
                txt_gruponame.Enabled = false;
                txt_marcaid.Enabled = var;
                txt_marcaname.Enabled = false;


                gridsubgrupo.ReadOnly = true;
                gridsubgrupo.Enabled = !var;             
                txt_criterio.Enabled = !var;
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
            else
            {
                moduloiddes.Enabled = false;
                localdes.Enabled = false;

                txt_lineaid.Enabled = false;
                txt_lineaname.Enabled = false;
                txt_subgrupoid.Enabled = var;
                txt_subgruponame.Enabled = false;

                txt_grupoid.Enabled = false;
                txt_gruponame.Enabled = false;
                txt_marcaid.Enabled = var;
                txt_marcaname.Enabled = false;

                gridsubgrupo.ReadOnly = true;
                gridsubgrupo.Enabled = !var;               
                txt_criterio.Enabled = !var;
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
                BE.lineaid = txt_lineaid.Text.Trim().PadLeft(3, '0');
                BE.grupoid = txt_grupoid.Text.Trim().PadLeft(4, '0');
                if (txt_subgrupoid.Text.Trim().Length > 0)
                {
                    BE.subgrupoid = txt_subgrupoid.Text.Trim().PadLeft(3, '0');
                }
                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    limpiar_documento();
                    ssModo = "EDIT";

                    txt_lineaid.Text = dt.Rows[0]["lineaid"].ToString().Trim();
                    txt_lineaname.Text = dt.Rows[0]["lineaname"].ToString().Trim();
                    txt_grupoid.Text = dt.Rows[0]["grupoid"].ToString().Trim();
                    txt_gruponame.Text = dt.Rows[0]["gruponame"].ToString().Trim();
                    txt_subgrupoid.Text = dt.Rows[0]["subgrupoid"].ToString().Trim();
                    txt_subgruponame.Text = dt.Rows[0]["subgruponame"].ToString().Trim();
                    txt_marcaname.Text = dt.Rows[0]["subgrupoartic"].ToString().Trim();

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
        private void generar_denominacion()
        {
            //if (moduloiddes.SelectedValue.ToString() == "0500")
            //{
            //    txt_subgruponame.Text = txt_gruponame.Text.ToString() + _articulo.ToString();
            //}
            //else
            //{
            //    if (moduloiddes.SelectedValue.ToString() == "0340" ||
            //    moduloiddes.SelectedValue.ToString() == "0350" ||
            //    moduloiddes.SelectedValue.ToString() == "0360" ||
            //    moduloiddes.SelectedValue.ToString() == "0370" ||
            //    moduloiddes.SelectedValue.ToString() == "0510" ||
            //    moduloiddes.SelectedValue.ToString() == "0520" ||
            //    moduloiddes.SelectedValue.ToString() == "0530" ||
            //    moduloiddes.SelectedValue.ToString() == "0540")
            //    {
            //        txt_subgruponame.Text = txt_lineaname.Text.ToString() + _articulo.ToString();
            //    }
            //    else
            //    {
            //        txt_subgruponame.Text = txt_lineaname.Text + " " + txt_gruponame.Text.ToString() + " " + _articulo.ToString();
            //    }
            //}
        }
      
        private void ValidaLinea()
        {
            if (txt_lineaid.Text.Trim().Length > 0 && ssModo == "NEW")
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
                BE.lineaid = txt_lineaid.Text.Trim().PadLeft(3, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    txt_lineaid.Text = dt.Rows[0]["lineaid"].ToString().Trim();
                    txt_lineaname.Text = dt.Rows[0]["lineaname"].ToString().Trim();
                    //generar_denominacion();
                }
                else
                {
                    txt_lineaid.Text = string.Empty;
                    txt_lineaname.Text = string.Empty;
                    //generar_denominacion();
                }
            }
            if (txt_lineaid.Text.Trim().Length == 0 && ssModo == "NEW")
            {
                txt_lineaid.Text = string.Empty;
                txt_lineaname.Text = string.Empty;
                //generar_denominacion();
            }
        }

        private void ValidaGrupo()
        {
            if (txt_grupoid.Text.Trim().Length > 0 && ssModo == "NEW")
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
                BE.grupoid = txt_grupoid.Text.Trim().PadLeft(4, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    txt_grupoid.Text = dt.Rows[0]["grupoid"].ToString().Trim();
                    txt_gruponame.Text = dt.Rows[0]["gruponame"].ToString().Trim();
                    //generar_denominacion();
                }
                else
                {
                    txt_grupoid.Text = string.Empty;
                    txt_gruponame.Text = string.Empty;
                    //generar_denominacion();
                }
            }
            if (txt_grupoid.Text.Trim().Length == 0 && ssModo == "NEW")
            {
                txt_grupoid.Text = string.Empty;
                txt_gruponame.Text = string.Empty;
                //generar_denominacion();
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
                        frmayuda.sqlquery = " SELECT sg.lineaid,li.lineaname "+
                                            " FROM tb_" + modd + "_subgrupo sg " +
                                            " LEFT JOIN tb_" + modd + "_linea li on sg.lineaid = li.lineaid ";
                        frmayuda.sqlinner = string.Empty;
                        frmayuda.sqlwhere = "WHERE sg.subgrupoid = '"+txt_subgrupoid.Text+"' and grupoid = '"+txt_grupoid.Text+"' ";
                        frmayuda.sqland = "AND";
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
                txt_lineaid.Text = resultado1.Trim();
                txt_lineaname.Text = resultado2.Trim();
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
                        frmayuda.sqlquery = "SELECT sg.grupoid,g.gruponame,sg.subgrupoid "+
                                            " FROM tb_" + modd + "_subgrupo sg " +
                                            " LEFT JOIN tb_" + modd + "_grupo g on sg.grupoid = g.grupoid " ;
                        frmayuda.sqlinner = string.Empty;
                        frmayuda.sqlwhere = "WHERE sg.subgrupoid = '"+txt_subgrupoid.Text+"' ";
                        frmayuda.sqland = "AND";
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
                txt_grupoid.Text = resultado1.Trim();
                txt_gruponame.Text = resultado2.Trim();
            }
        }

        private void Ayudasubgrupo(String lpdescrlike)
        {
            try
            {
                var modd = string.Empty;
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();

                BE.dominioid = "60";
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
                        frmayuda.titulo = "<< AYUDA TABLA ARTICULO >>";
                        frmayuda.sqlquery = "SELECT (lineaid + gr.grupoid + subgrupoid) as Codigo,lineaid,gr.grupoid,g.gruponame,subgrupoid,subgruponame,g.ctacte  FROM tb_" + modd + "_subgrupo gr ";

                        if (modd == "sm")
                        {
                            frmayuda.sqlinner = " Inner Join tb_" + modd + "_grupo g on gr.grupoid = g.grupoid and gr.status = '0' ";
                        }
                        else
                        {
                            frmayuda.sqlinner = " Inner Join tb_" + modd + "_grupo g on gr.grupoid = g.grupoid and gr.status = '0' ";
                        }

                        //if (txt_lineaid.Text.Trim().Length > 0 && txt_grupoid.Text.Trim().Length > 0)
                        //{
                        //    frmayuda.sqlwhere = "where lineaid = " + txt_lineaid.Text + " and g.grupoid = " + txt_grupoid.Text + " ";
                        //    frmayuda.sqland = "and";
                        //}
                        //else
                        //{
                        //    if (txt_lineaid.Text.Trim().Length > 0)
                        //    {
                        //        frmayuda.sqlwhere = "where lineaid = " + txt_lineaid.Text + " ";
                        //        frmayuda.sqland = "and";
                        //    }
                        //    else
                        //    {
                        //        if (txt_grupoid.Text.Trim().Length > 0)
                        //        {
                        //            frmayuda.sqlwhere = "where g.grupoid = " + txt_grupoid.Text + " ";
                        //            frmayuda.sqland = "and";
                        //        }
                        //        else
                        //        {
                                    frmayuda.sqlwhere = "where";
                                    frmayuda.sqland = string.Empty;
                            //    }
                            //}
                        //}
                        frmayuda.criteriosbusqueda = new string[] { "ARTICULO", "CODIGO" };
                        frmayuda.columbusqueda = "subgruponame,subgrupoid";
                        frmayuda.returndatos = "1,2,4,6";


                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeSubgrupo;
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void RecibeSubgrupo(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                txt_lineaid.Text = resultado1.Trim();
                txt_grupoid.Text = resultado2.Trim();
                txt_subgrupoid.Text = resultado3.Trim();             
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
                BE.detalle = txt_lineaid.Text.Trim() + txt_grupoid.Text.Trim() + txt_subgrupoid.Text.Trim() + "/" + txt_subgruponame.Text.Trim().ToUpper() + "/" + txt_marcaname.Text.Trim() + "/" + XGLOSA;

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
                if (modulo.ToString() == "0100")
                {
                    if (!chk_fijar.Checked)
                    {
                        txt_lineaid.Text = string.Empty;
                        txt_lineaname.Text = string.Empty;
                        txt_grupoid.Text = string.Empty;
                        txt_gruponame.Text = string.Empty;
                        txt_subgrupoid.Text = string.Empty;
                        txt_subgruponame.Text = string.Empty;
                        txt_marcaid.Text = string.Empty;
                        txt_marcaname.Text = string.Empty;
                    }
                }
                else
                {
                    if (!chk_fijar.Checked)
                    {
                        moduloiddes.SelectedValue = modulo.ToString();
                        localdes.SelectedValue = local.ToString();
                        txt_lineaid.Text = string.Empty;
                        txt_lineaname.Text = string.Empty;
                        txt_grupoid.Text = string.Empty;
                        txt_gruponame.Text = string.Empty;
                        txt_subgrupoid.Text = string.Empty;
                        txt_subgruponame.Text = string.Empty;
                        txt_marcaid.Text = string.Empty;
                        txt_marcaname.Text = string.Empty;
                    }
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
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_log.Enabled = true;
            txt_subgrupoid.Focus();
            ssModo = "NEW";
        }

        private void Insert()
        {
            try
            {
                if (txt_subgrupoid.Text.Trim().Length != 3)
                {
                    MessageBox.Show("Falta Codigo subgrupo !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (txt_subgruponame.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese nombre de subgrupo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new tb_60subgrupoBL();
                        var BE = new tb_60subgrupo();

                        BE.moduloid = moduloiddes.SelectedValue.ToString();
                        BE.lineaid = txt_lineaid.Text.Trim().PadLeft(3, '0');
                        BE.grupoid = txt_grupoid.Text.Trim().PadLeft(4, '0');
                        BE.subgrupoid = txt_subgrupoid.Text.Trim().PadLeft(3, '0');
                        BE.marcaid = txt_marcaid.Text.ToUpper();
                        BE.usuar = VariablesPublicas.Usuar.Trim();

                        if (BL.Insert_Marca(EmpresaID, BE))
                        {
                            MessageBox.Show("Datos Grabados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (txt_subgrupoid.Text.Trim().Length != 3)
                {
                    MessageBox.Show("Falta Codigo subgrupo !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (txt_subgruponame.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese nombre de subgrupo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new tb_60subgrupoBL();
                        var BE = new tb_60subgrupo();

                        BE.moduloid = moduloiddes.SelectedValue.ToString();
                        BE.lineaid = txt_lineaid.Text.Trim().PadLeft(3, '0');
                        BE.grupoid = txt_grupoid.Text.Trim().PadLeft(4, '0');
                        BE.subgrupoid = txt_subgrupoid.Text.Trim().PadLeft(3, '0');
                        BE.marcaid = txt_marcaid.Text.ToUpper();
                        BE.usuar = VariablesPublicas.Usuar.Trim();

                        if (BL.Update_Marca(EmpresaID, BE))
                        {
                            SEGURIDAD_LOG("M");
                            MessageBox.Show("Datos Modificado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (txt_subgrupoid.Text.Trim().Length != 3)
                {
                    MessageBox.Show("Falta Codigo Subgrupo !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_60subgrupoBL();
                    var BE = new tb_60subgrupo();
                    BE.moduloid = moduloiddes.SelectedValue.ToString();
                    BE.lineaid = txt_lineaid.Text.Trim().PadLeft(3, '0');
                    BE.grupoid = txt_grupoid.Text.Trim().PadLeft(4, '0');
                    BE.subgrupoid = txt_subgrupoid.Text.Trim().PadLeft(3, '0');
                    BE.marcaid = txt_marcaid.Text.Trim();

                    if (BL.Delete_Marca(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos Eliminado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            data_cbo_moduloiddes();
            NIVEL_FORMS();
            Tablasubgrupo = new DataTable();
            //data_Tablasubgrupo();
            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;        
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
                txt_grupoid.Focus();
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
                txt_marcaname.Focus();
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
            //if (txt_marcaname.Text == string.Empty)
            //{
            //    _articulo = string.Empty;
            //    generar_denominacion();
            //}
            //else
            //{
            //    _articulo = " " + txt_marcaname.Text.ToString();
            //    generar_denominacion();
            //}
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
                txt_lineaid.Enabled = false;
                txt_grupoid.Enabled = false;
                txt_subgruponame.Focus();

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
                limpiar_documento();
                btn_nuevo.Enabled = true;              
                btn_salir.Enabled = true;
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

                BE.parameters = txt_criterio.Text.Trim();
                BE.moduloid = moduloiddes.SelectedValue.ToString();
                if (moduloiddes.SelectedValue.ToString() == "0000")
                {
                    MessageBox.Show("Seleccione Almacen", "Information");
                    return;
                }

                Tablasubgrupo = BL.GetAll2(EmpresaID, BE).Tables[0];
                if (Tablasubgrupo.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    gridsubgrupo.DataSource = Tablasubgrupo;
                    gridsubgrupo.Rows[0].Selected = false;                    
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
                    String xsubgrupoid = "", xgrupoid = "", xlineaid = "",xmarcaid = "";
                    xsubgrupoid = gridsubgrupo.Rows[e.RowIndex].Cells["subgrupoid"].Value.ToString().Trim();
                    xgrupoid = gridsubgrupo.Rows[e.RowIndex].Cells["grupoid"].Value.ToString().Trim();
                    xlineaid = gridsubgrupo.Rows[e.RowIndex].Cells["lineaid"].Value.ToString().Trim();
                    xmarcaid = gridsubgrupo.Rows[e.RowIndex].Cells["marcaid"].Value.ToString().Trim();

                    data_subgrupo(xsubgrupoid, xgrupoid, xlineaid, xmarcaid);
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
                String xsubgrupoid = "", xgrupoid = "", xlineaid = "", xmarcaid = "";
                xsubgrupoid = gridsubgrupo.Rows[gridsubgrupo.CurrentRow.Index].Cells["subgrupoid"].Value.ToString().Trim();
                xgrupoid = gridsubgrupo.Rows[gridsubgrupo.CurrentRow.Index].Cells["grupoid"].Value.ToString().Trim();
                xlineaid = gridsubgrupo.Rows[gridsubgrupo.CurrentRow.Index].Cells["lineaid"].Value.ToString().Trim();
                xmarcaid = gridsubgrupo.Rows[gridsubgrupo.CurrentRow.Index].Cells["marcaid"].Value.ToString().Trim();

                data_subgrupo(xsubgrupoid, xgrupoid, xlineaid, xmarcaid);
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

        private void data_subgrupo(String xsubgrupoid,String xgrupoid,String xlineaid,String xmarcaid)
        {        
            form_bloqueado(false);
            var rowsubgrupoid = Tablasubgrupo.Select("subgrupoid='" + xsubgrupoid + "' and grupoid = '"+xgrupoid+"' and lineaid = '"+xlineaid+"' and marcaid = '"+xmarcaid+"'");
            if (rowsubgrupoid.Length > 0)
            {
                foreach (DataRow row in rowsubgrupoid)
                {
                    txt_lineaid.Text = row["lineaid"].ToString().Trim();
                    txt_lineaname.Text = row["lineaname"].ToString().Trim();
                    txt_grupoid.Text = row["grupoid"].ToString().Trim();
                    txt_gruponame.Text = row["gruponame"].ToString().Trim();

                    txt_subgrupoid.Text = row["subgrupoid"].ToString().Trim();
                    txt_subgruponame.Text = row["subgruponame"].ToString().Trim();
                    txt_marcaid.Text = row["marcaid"].ToString().Trim();
                    txt_marcaname.Text = row["marcaname"].ToString().Trim();
                }

                btn_nuevo.Enabled = true;
                btn_editar.Enabled = true;
                btn_eliminar.Enabled = true;
                btn_imprimir.Enabled = true;
          
                btn_log.Enabled = true;
                btn_salir.Enabled = true;
            }
            //txt_marcaname.TextChanged += new System.EventHandler(subgrupoartic_TextChanged);
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

        private void txt_subgrupoid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Ayudasubgrupo(string.Empty);
            }           
            ValidaSubgrupo();
            //get_nuevo_producto();
            //ValidamosProcedencia();
            //GeneraCodAsoc();
        }

        private void ValidaSubgrupo()
        {
            if (txt_subgrupoid.Text.Trim().Length > 0 && txt_lineaid.Text.Trim().Length == 3 && txt_grupoid.Text.Trim().Length == 4)
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
                BE.lineaid = txt_lineaid.Text.Trim().PadLeft(3, '0');
                BE.grupoid = txt_grupoid.Text.Trim().PadLeft(4, '0');
                BE.subgrupoid = txt_subgrupoid.Text.Trim().PadLeft(3, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    txt_lineaid.Text = dt.Rows[0]["lineaid"].ToString().Trim();
                    txt_lineaname.Text = dt.Rows[0]["lineaname"].ToString().Trim();
                    txt_grupoid.Text = dt.Rows[0]["grupoid"].ToString().Trim();
                    txt_gruponame.Text = dt.Rows[0]["gruponame"].ToString().Trim();
                    txt_subgrupoid.Text = dt.Rows[0]["subgrupoid"].ToString().Trim();
                    txt_subgruponame.Text = dt.Rows[0]["subgruponame"].ToString().Trim();                    
                }
                else
                {
                    txt_lineaid.Text = string.Empty;
                    txt_lineaname.Text = string.Empty;
                    txt_grupoid.Text = string.Empty;
                    txt_gruponame.Text = string.Empty;
                    txt_subgrupoid.Text = string.Empty;
                    txt_subgruponame.Text = string.Empty;
                }
            }
            else
            {
                txt_lineaid.Text = string.Empty;
                txt_lineaname.Text = string.Empty;
                txt_grupoid.Text = string.Empty;
                txt_gruponame.Text = string.Empty;
                txt_subgrupoid.Text = string.Empty;
                txt_subgruponame.Text = string.Empty;
            }
        }

        private void txt_marcaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaMarca(string.Empty);
            }

            if (e.KeyCode == Keys.Enter)
            {
                var xcodmar = string.Empty;
                xcodmar = txt_marcaid.Text.PadLeft(2, '0');
                Valida_Marca(xcodmar);
                //_GenerarNombre();
                txt_lineaid.Focus();
            }
        }

        private void AyudaMarca(String lpdescrlike)
        {
            var frmayuda = new Ayudas.Frm_help_general();

            frmayuda.tipoo = "sql";
            frmayuda.titulo = "<< AYUDA TABLA MARCA >>";
            frmayuda.sqlquery = "SELECT marcaid as Codigo, marcaname as Marca,marcadescort as Desc_Corta FROM tb_pt_marca ";
            frmayuda.sqlwhere = "where";
            frmayuda.criteriosbusqueda = new string[] { "MARCA", "CODIGO" };
            frmayuda.columbusqueda = "marcaname,marcaid";
            frmayuda.returndatos = "0,1,2";

            frmayuda.Owner = this;
            frmayuda.PasaProveedor = RecibeMarca;
            frmayuda.ShowDialog();
        }

        private void RecibeMarca(String xmarcaid, String xmarcaname, String xdescort, String resultado4, String resultado5)
        {
            if (xmarcaid.Trim().Length > 0)
            {
                txt_marcaid.Text = xmarcaid.Trim();
                txt_marcaname.Text = xmarcaname.Trim();

                //if (xdescort.ToString().Trim() != string.Empty)
                //{
                //    _xmarcadescort = xdescort.ToString().Trim();
                //}
                //else
                //{
                //    _xmarcadescort = xmarcaname.ToString().Trim();
                //}
                //_GenerarNombre();
            }
        }

        private void Valida_Marca(String xcod)
        {
            var BE = new tb_pt_marca();
            var BL = new tb_pt_marcaBL();
            var dt = new DataTable();
            BE.marcaid = xcod.Trim();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    //if (row["marcadescort"].ToString().Trim() != string.Empty)
                    //{
                    //    _xmarcadescort = row["marcadescort"].ToString();
                    //}
                    //else
                    //{
                    //    _xmarcadescort = row["marcaname"].ToString();
                    //}
                    txt_marcaid.Text = row["marcaid"].ToString();
                    txt_marcaname.Text = row["marcaname"].ToString();
                 //   _xmarcaidold = row["marcaidold"].ToString();
                }
            }
            else
            {
                //_xmarcadescort = string.Empty;
                txt_marcaid.Text = string.Empty;
                txt_marcaname.Text = string.Empty;
                //_xmarcaidold = string.Empty;
            }
        }

        private void txt_criterio_KeyUp(object sender, KeyEventArgs e)
        {
            data_Tablasubgrupo();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {          
            //txt_marcaid.Focus();
            nuevo();
            txt_marcaid.Text = "";
            txt_marcaname.Text = "";
            txt_marcaid.Focus();

        }



       
    }
}
