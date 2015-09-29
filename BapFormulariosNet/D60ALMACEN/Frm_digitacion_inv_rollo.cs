using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.D60ALMACEN
{
    public partial class Frm_digitacion_inv_rollo : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String perianio = string.Empty;
        private String perimes = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable Tabladetallemov;
        private DataTable DataError;


        private String almacaccionid = string.Empty;
        private DataRow row;
        private Boolean fechadocedit = false;
        private Boolean tipodocautomatico = false;
        private Boolean tipodocmanejaserie = false;
        private Boolean statusDoc = true;

        private String incprec = "N";
        private String ssModo = "NEW";

        public Frm_digitacion_inv_rollo()
        {
            InitializeComponent();
            numdoc.LostFocus += new System.EventHandler(numdoc_LostFocus);
        }

        private void PARAMETROS_TABLA()
        {
            var xxferfil = string.Empty;
            var f = (MainAlmacen)MdiParent;
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
                if (var == false)
                {
                    tipodoc.Enabled = !var;
                    numdoc.Enabled = !var;
                }
                else
                {
                    tipodoc.Enabled = !var;
                    numdoc.Enabled = !var;
                }

                serdoc.Enabled = false;
                fechdoc.Enabled = var;

                ubic.Enabled = var;
                userinventario.Enabled = var;
                ubic.Enabled = var;
                userinventario.Enabled = var;

                itemsT.Enabled = var;
                itemsT.ReadOnly = true;
                totpzas.Enabled = var;
                totpzas.ReadOnly = true;
                totpzas2.Enabled = var;
                totpzas2.ReadOnly = true;
                glosa.Enabled = var;

                griddetallemov.ReadOnly = !var;
                griddetallemov.Columns["productname"].ReadOnly = true;
                griddetallemov.Columns["stocklibros"].ReadOnly = true;
                griddetallemov.Columns["diferencia"].ReadOnly = true;
                griddetallemov.Columns["costopromlibros"].ReadOnly = true;
                griddetallemov.Columns["costopromfisico"].ReadOnly = true;

                btn_nuevo.Enabled = false;
                btn_editar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_grabar.Enabled = false;
                btn_import.Enabled = false;

                btn_eliminar.Enabled = false;
                btnImprimirNoval.Enabled = false;

                btn_primero.Enabled = false;
                btn_anterior.Enabled = false;
                btn_siguiente.Enabled = false;
                btn_ultimo.Enabled = false;

                btn_detanadir.Enabled = false;
                btn_deteliminar.Enabled = false;
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
                limpiar_documento();
                if (Tabladetallemov.Rows.Count > 0)
                {
                    Tabladetallemov.Rows.Clear();
                    griddetallemov.DataSource = Tabladetallemov;
                }

                if (DataError.Rows.Count > 0)
                {
                    DataError.Rows.Clear();
                }

                form_bloqueado(false);
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
                var BL = new tb_60local_stock_inventarioBL();
                var BE = new tb_60local_stock_inventario();

                var dt = new DataTable();

                BE.moduloid = modulo;
                BE.local = local;
                BE.tipodoc = tipodoc.SelectedValue.ToString().Trim();
                if (serdoc.Text.Trim().Length > 0)
                {
                    BE.serdoc = serdoc.Text.Trim().PadLeft(4, '0');
                    BE.numdoc = numdoc.Text.Trim().PadLeft(10, '0');
                }
                else
                {
                    if (posicion.Trim().Length > 0)
                    {
                        MessageBox.Show("Seleccionar el Tipo de Documento !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }
                if (numdoc.Text.Trim().Length > 0)
                {
                    BE.numdoc = numdoc.Text.Trim().PadLeft(10, '0');
                }

                BE.posicion = posicion.Trim();

                dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    ssModo = "EDIT";

                    userinventario.Text = dt.Rows[0]["userinventario"].ToString().Trim();

                    serdoc.Text = dt.Rows[0]["serdoc"].ToString().Trim();
                    numdoc.Text = dt.Rows[0]["numdoc"].ToString().Trim();
                    fechdoc.Text = dt.Rows[0]["fechdoc"].ToString().Trim();

                    totpzas.Text = dt.Rows[0]["totpzasl"].ToString().Trim();
                    totpzas2.Text = dt.Rows[0]["totpzasf"].ToString().Trim();

                    glosa.Text = dt.Rows[0]["glosa"].ToString().Trim();
                    itemsT.Text = dt.Rows[0]["items"].ToString().Trim();

                    data_Tabladetallemovmov();
                    btn_editar.Enabled = true;
                    btn_eliminar.Enabled = true;
                    btnImprimirNoval.Enabled = true;

                    btn_primero.Enabled = true;
                    btn_anterior.Enabled = true;
                    btn_siguiente.Enabled = true;
                    btn_ultimo.Enabled = true;
                    btn_salir.Enabled = true;
                    griddetallemov.Focus();
                    griddetallemov.Rows[0].Selected = false;
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
            if (e.KeyCode == Keys.Enter)
            {
                VariablesPublicas.Enter = true;
                SendKeys.Send("\t");
            }
        }
        private void AyudaProducto(String lpdescrlike)
        {
            try
            {
                griddetallemov.CurrentCell = griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["productname"];
                var prod = Convert.ToString(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productid"].Value);
                var modd = string.Empty;
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();

                BE.dominioid = dominio;
                BE.moduloid = modulo;
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();
                        var frmayuda = new Ayudas.Form_help_stockinventario();

                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< Ayuda Producto Inventariado >>";

                        frmayuda.sqlquery = " select li.productid," +
                                                    " p.productname," +
                                                    " li.stocklibros," +
                                                    " li.stockfisico," +
                                                    " li.diferencia," +
                                                    " li.costopromlibros," +
                                                    " li.costopromfisico " +
                                                    " from tb_" + modd + "_local_stock_inventario li ";
                        frmayuda.sqlinner = " left join tb_" + modd + "_productos p on li.productid = p.productid ";
                        frmayuda.sqlwhere = "where";
                        frmayuda.criteriosbusqueda = new string[] { "PRODUCTO", "CODIGO" };
                        frmayuda.columbusqueda = "p.productname,li.productid";
                        frmayuda.returndatos = "0,1";

                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeProductoRollo;
                        if (prod == string.Empty)
                        {
                            prod = "_";
                        }
                        frmayuda.txt_busqueda.Text = prod;
                        frmayuda.btnbuscar.PerformClick();
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RecibeProductoRollo(DataTable dtresultado)
        {
            try
            {
                if (dtresultado.Rows.Count > 0)
                {
                    var cont = 0;
                    foreach (DataRow fila in dtresultado.Rows)
                    {
                        cont = cont + 1;
                        if (griddetallemov.Rows.Count > 0)
                        {
                            var nFilaAnt = griddetallemov.RowCount - 1;
                            var xProductid = fila["productid"].ToString();
                            var xProductname = fila["productname"].ToString();

                            if (cont > 1)
                            {
                                Tabladetallemov.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetallemov));
                                Tabladetallemov.Rows[Tabladetallemov.Rows.Count - 1]["items"] = VariablesPublicas.CalcMaxField(Tabladetallemov, "items", 5);
                                griddetallemov.Rows[nFilaAnt + 1].Cells["productid"].Value = xProductid;
                                griddetallemov.Rows[nFilaAnt + 1].Cells["productname"].Value = xProductname;
                            }
                            else
                            {
                                griddetallemov.Rows[nFilaAnt].Cells["productid"].Value = xProductid;
                                griddetallemov.Rows[nFilaAnt].Cells["productname"].Value = xProductname;
                            }

                            griddetallemov.CurrentCell = griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["stockfisico"];
                            griddetallemov.BeginEdit(true);
                            ValidaTabladetallemovmov(xProductid);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AyudaRollo(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Form_help_stockinventario_rollo();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "<< Ayuda Rollo Inventariado >>";

                frmayuda.sqlquery = " SELECT " +
                                        " ttp.rollo,	            " +
                                        " p.productid,              " +
                                        " p.productname,            " +
                                        " ttp.stocklibros,          " +
                                        " ttp.stockfisico,          " +
                                        " ttp.diferencia 	        " +
                                    " FROM tb_ta_local_stock_inventario_rollo AS ttp ";

                frmayuda.sqlinner = " LEFT JOIN  tb_ta_prodrollo AS ttp2 ON ttp.rollo = ttp2.rollo " +
                                    " LEFT JOIN tb_ta_productos AS p ON ttp2.productid = p.productid ";
                frmayuda.sqlwhere = " WHERE";
                frmayuda.criteriosbusqueda = new string[] { "PRODUCTO", "ROLLO" };
                frmayuda.columbusqueda = "p.productname,ttp.rollo";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeRollo;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private void RecibeRollo(DataTable dtresultado)
        {
            try
            {
                if (dtresultado.Rows.Count > 0)
                {
                    var cont = 0;
                    foreach (DataRow fila in dtresultado.Rows)
                    {
                        cont = cont + 1;
                        if (griddetallemov.Rows.Count > 0)
                        {
                            var nFilaAnt = griddetallemov.RowCount - 1;
                            var xrollo = fila["rollo"].ToString();

                            var rowrollo = dtresultado.Select("rollo='" + xrollo + "'");
                            if (rowrollo.Length > 0)
                            {
                                MessageBox.Show("Rollo ya existe !!!!!!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            var xproductid = fila["productid"].ToString();
                            var xProductname = fila["productname"].ToString();
                            var xstocklibros = fila["stocklibros"].ToString();
                            var xstockfisico = fila["stockfisico"].ToString();
                            var xdiferencia = fila["diferencia"].ToString();

                            if (cont > 1)
                            {
                                Tabladetallemov.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetallemov));
                                griddetallemov.Rows[nFilaAnt + 1].Cells["rollo"].Value = xrollo;
                                griddetallemov.Rows[nFilaAnt + 1].Cells["productid"].Value = xproductid;
                                griddetallemov.Rows[nFilaAnt + 1].Cells["productname"].Value = xProductname;
                                griddetallemov.Rows[nFilaAnt + 1].Cells["stocklibros"].Value = xstocklibros;
                                griddetallemov.Rows[nFilaAnt + 1].Cells["stockfisico"].Value = xstockfisico;
                                griddetallemov.Rows[nFilaAnt + 1].Cells["diferencia"].Value = xdiferencia;
                            }
                            else
                            {
                                griddetallemov.Rows[nFilaAnt].Cells["rollo"].Value = xrollo;
                                griddetallemov.Rows[nFilaAnt].Cells["productid"].Value = xproductid;
                                griddetallemov.Rows[nFilaAnt].Cells["productname"].Value = xProductname;
                                griddetallemov.Rows[nFilaAnt].Cells["stocklibros"].Value = xstocklibros;
                                griddetallemov.Rows[nFilaAnt].Cells["stockfisico"].Value = xstockfisico;
                                griddetallemov.Rows[nFilaAnt].Cells["diferencia"].Value = xdiferencia;
                            }

                            griddetallemov.CurrentCell = griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["stockfisico"];
                            griddetallemov.BeginEdit(true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void SEGURIDAD_LOG(String accion)
        {
            var xclave = VariablesPublicas.EmpresaID + "-" + modulo + "-" + tipodoc.Text.Trim() + "-" + serdoc.Text.Trim() + "-" + numdoc.Text.Trim();
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
                BE.detalle = tipodoc.Text.Trim() + "-" + serdoc.Text.Trim() + "-" + numdoc.Text.Trim() + "/" + XGLOSA;

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
                NIVEL_FORMS();
                incprec = "N";
                ssModo = "NEW";
                ubic.Text = string.Empty;
                userinventario.Text = string.Empty;
                itemsT.Text = "0";
                totpzas.Text = "0";
                totpzas2.Text = "0";
                data_Tabladetallemovmov();
                glosa.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void calcular_totales()
        {
            if (Tabladetallemov != null)
            {
                if (Tabladetallemov.Rows.Count != 0)
                {
                    itemsT.Text = Tabladetallemov.Rows.Count.ToString();
                    totpzas.Text = Convert.ToDecimal(Tabladetallemov.Compute("sum(stocklibros)", string.Empty)).ToString("##,###,##0.00");
                    totpzas2.Text = Convert.ToDecimal(Tabladetallemov.Compute("sum(stockfisico)", string.Empty)).ToString("##,###,##0.00");
                }
                else
                {
                    itemsT.Text = Tabladetallemov.Rows.Count.ToString();
                    totpzas.Text = "0";
                    totpzas2.Text = "0";
                }
            }
        }

        private void nuevo()
        {
            tipodoc.SelectedIndex = 0;
            limpiar_documento();

            form_bloqueado(false);
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_import.Enabled = true;

            btn_detanadir.Enabled = true;
            btn_deteliminar.Enabled = true;

            ssModo = "NEW";
        }

        private void Insert()
        {
            try
            {
                if (Tabladetallemov.Rows.Count == 0)
                {
                    MessageBox.Show("Documento no tiene Items !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_60local_stock_inventarioBL();
                    var BE = new tb_60local_stock_inventario();

                    var Detalle = new tb_60local_stock_inventario.Item();
                    var ListaItems = new List<tb_60local_stock_inventario.Item>();

                    BE.dominioid = dominio;
                    BE.moduloid = modulo;
                    BE.local = local;
                    BE.tipodoc = tipodoc.SelectedValue.ToString();
                    BE.serdoc = serdoc.Text;
                    BE.numdoc = numdoc.Text;
                    BE.items = itemsT.Text.Trim();
                    BE.totpzasl = totpzas.Text.Trim();
                    BE.totpzasf = totpzas2.Text.Trim();
                    BE.userinventario = userinventario.Text;
                    BE.glosa = glosa.Text.Trim().ToUpper().ToString();
                    BE.fechdoc = Convert.ToDateTime(fechdoc.Text);
                    BE.usuar = VariablesPublicas.Usuar;

                    var item = 0;
                    foreach (DataRow fila in Tabladetallemov.Rows)
                    {
                        Detalle = new tb_60local_stock_inventario.Item();
                        item++;

                        Detalle.rollo = fila["rollo"].ToString();
                        Detalle.productid = fila["productid"].ToString();
                        Detalle.stocklibros = Convert.ToDecimal(fila["stocklibros"].ToString());
                        Detalle.stockfisico = Convert.ToDecimal(fila["stockfisico"].ToString());

                        Detalle.costopromlibros = Convert.ToDecimal("0".ToString());
                        Detalle.costopromfisico = Convert.ToDecimal("0".ToString());

                        Detalle.fechdoc = Convert.ToDateTime(fechdoc.Text);
                        Detalle.userinventariado = userinventario.Text;
                        Detalle.codigoubic = ubic.Text;
                        Detalle.usuar = VariablesPublicas.Usuar.ToUpper();

                        if (fila["rollo"].ToString().Trim().Length == 10 && Convert.ToDecimal(fila["stockfisico"]) > 0)
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
                    if (BL.Insert_Archivo(EmpresaID, BE))
                    {
                        NIVEL_FORMS();
                        MessageBox.Show("Datos Grabados Correctamente !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar_documento();
                        if (Tabladetallemov.Rows.Count > 0)
                        {
                            Tabladetallemov.Rows.Clear();
                            griddetallemov.DataSource = Tabladetallemov;
                        }
                        form_bloqueado(false);
                        btn_nuevo.Enabled = true;
                        btnImprimirNoval.Enabled = true;
                        btn_primero.Enabled = true;
                        btn_anterior.Enabled = true;
                        btn_siguiente.Enabled = true;
                        btn_ultimo.Enabled = true;
                        btn_salir.Enabled = true;
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
                if (Tabladetallemov.Rows.Count == 0)
                {
                    MessageBox.Show("Documento no tiene Items !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new tb_60local_stock_inventarioBL();
                    var BE = new tb_60local_stock_inventario();

                    var Detalle = new tb_60local_stock_inventario.Item();
                    var ListaItems = new List<tb_60local_stock_inventario.Item>();

                    BE.dominioid = dominio;
                    BE.moduloid = modulo;
                    BE.local = local;
                    BE.tipodoc = tipodoc.SelectedValue.ToString();
                    BE.serdoc = serdoc.Text;
                    BE.numdoc = numdoc.Text;
                    BE.items = itemsT.Text.Trim();
                    BE.totpzasl = totpzas.Text.Trim();
                    BE.totpzasf = totpzas2.Text.Trim();
                    BE.userinventario = userinventario.Text;
                    BE.glosa = glosa.Text.Trim().ToUpper().ToString();
                    BE.fechdoc = Convert.ToDateTime(fechdoc.Text);
                    BE.usuar = VariablesPublicas.Usuar;

                    var item = 0;
                    foreach (DataRow fila in Tabladetallemov.Rows)
                    {
                        Detalle = new tb_60local_stock_inventario.Item();
                        item++;

                        Detalle.rollo = fila["rollo"].ToString();
                        Detalle.productid = fila["productid"].ToString();
                        Detalle.stocklibros = Convert.ToDecimal(fila["stocklibros"].ToString());
                        Detalle.stockfisico = Convert.ToDecimal(fila["stockfisico"].ToString());

                        Detalle.costopromlibros = Convert.ToDecimal("0".ToString());
                        Detalle.costopromfisico = Convert.ToDecimal("0".ToString());

                        Detalle.fechdoc = Convert.ToDateTime(fechdoc.Text);
                        Detalle.userinventariado = userinventario.Text;
                        Detalle.codigoubic = ubic.Text;
                        Detalle.usuar = VariablesPublicas.Usuar.ToUpper();

                        if (fila["rollo"].ToString().Trim().Length == 10 && Convert.ToDecimal(fila["stockfisico"]) > 0)
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
                    if (BL.Update_Archivo(EmpresaID, BE))
                    {
                        NIVEL_FORMS();
                        MessageBox.Show("Datos Modificado Correctamente !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar_documento();
                        if (Tabladetallemov.Rows.Count > 0)
                        {
                            Tabladetallemov.Rows.Clear();
                            griddetallemov.DataSource = Tabladetallemov;
                        }
                        form_bloqueado(false);
                        btn_nuevo.Enabled = true;
                        btnImprimirNoval.Enabled = true;
                        btn_primero.Enabled = true;
                        btn_anterior.Enabled = true;
                        btn_siguiente.Enabled = true;
                        btn_ultimo.Enabled = true;
                        btn_salir.Enabled = true;
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
                if (Tabladetallemov.Rows.Count == 0)
                {
                    MessageBox.Show("Documento no tiene Items !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (numdoc.Text.Trim().Length == 10)
                    {
                        var BL = new tb_60local_stock_inventarioBL();
                        var BE = new tb_60local_stock_inventario();
                        BE.moduloid = modulo;
                        BE.local = local;
                        BE.tipodoc = tipodoc.SelectedValue.ToString();
                        BE.serdoc = serdoc.Text.Trim();
                        BE.numdoc = numdoc.Text.Trim();

                        if (BL.Delete(EmpresaID, BE))
                        {
                            SEGURIDAD_LOG("E");
                            NIVEL_FORMS();
                            MessageBox.Show("Datos Eliminados Correctamente !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limpiar_documento();
                            form_bloqueado(false);
                            btn_nuevo.Enabled = true;
                            btn_primero.Enabled = true;
                            btn_anterior.Enabled = true;
                            btn_siguiente.Enabled = true;
                            btn_ultimo.Enabled = true;
                            btn_salir.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_digitacion_inv_Load(object sender, EventArgs e)
        {
            modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
            local = ((D60ALMACEN.MainAlmacen)MdiParent).local;
            PERFILID = ((D60ALMACEN.MainAlmacen)MdiParent).perfil;

            NIVEL_FORMS();
            data_cbo_tipodoc();
            ubic.CharacterCasing = CharacterCasing.Upper;
            userinventario.CharacterCasing = CharacterCasing.Upper;

            fechdoc.Text = Convert.ToString(((D60ALMACEN.MainAlmacen)MdiParent).localfeuiv);

            Tabladetallemov = new DataTable("detallemov");
            Tabladetallemov.Columns.Add("rollo", typeof(String));
            Tabladetallemov.PrimaryKey = new DataColumn[] { Tabladetallemov.Columns["rollo"] };
            Tabladetallemov.Columns["rollo"].Unique = true;
            Tabladetallemov.Columns.Add("productid", typeof(String));
            Tabladetallemov.Columns.Add("productname", typeof(String));
            Tabladetallemov.Columns.Add("stocklibros", typeof(Decimal));
            Tabladetallemov.Columns["stocklibros"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("stockfisico", typeof(Decimal));
            Tabladetallemov.Columns["stockfisico"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("diferencia", typeof(Decimal));
            Tabladetallemov.Columns["diferencia"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("costopromlibros", typeof(Decimal));
            Tabladetallemov.Columns["costopromlibros"].DefaultValue = 0;
            Tabladetallemov.Columns.Add("costopromfisico", typeof(Decimal));
            Tabladetallemov.Columns["costopromfisico"].DefaultValue = 0;

            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_primero.Enabled = true;
            btn_anterior.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_ultimo.Enabled = true;
            btn_salir.Enabled = true;
            ArmandoTablaError();
        }

        private void ArmandoTablaError()
        {
            DataError = new DataTable("Error");
            DataError.Columns.Add("error", typeof(String));
        }


        private void Frm_digitacion_inv_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btn_grabar.Enabled)
            {
                MessageBox.Show("Finalice edición para cerrar formulario", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
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
            if (XNIVEL == "0" || XNIVEL == "1")
            {
                ssModo = "EDIT";
                form_bloqueado(true);

                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
                btn_import.Enabled = true;
                btn_detanadir.Enabled = true;
                btn_deteliminar.Enabled = true;
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            form_accion_cancelEdicion(1);
        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {
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
                if (Tabladetallemov.Rows.Count > 0)
                {
                    var miForma = new REPORTES.Frm_reportes();

                    miForma.dominioid = dominio.Trim();
                    miForma.moduloid = modulo.Trim();
                    miForma.local = local.Trim();

                    miForma.Text = "Reporte Movimientos de Productos";
                    miForma.formulario = "Frm_movimiento_rollos";
                    miForma.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_imprimir2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Tabladetallemov.Rows.Count > 0)
                {
                    var miForma = new REPORTES.Frm_reportes();

                    miForma.dominioid = dominio.Trim();
                    miForma.moduloid = modulo.Trim();
                    miForma.local = local.Trim();

                    miForma.Text = "Reporte Movimientos de Productos";
                    miForma.formulario = "Frm_movimiento_rollos2";
                    miForma.Show();
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

        private void btn_detanadir_Click(object sender, EventArgs e)
        {
            try
            {
                if (griddetallemov.Enabled)
                {
                    if (griddetallemov.Rows.Count > 0)
                    {
                        if (griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["rollo"].Value.ToString().Trim().Length > 0 && griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["productid"].Value.ToString().Trim().Length > 0)
                        {
                            Tabladetallemov.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetallemov));
                            griddetallemov.CurrentCell = griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["rollo"];
                            griddetallemov.BeginEdit(true);
                        }
                        else
                        {
                            MessageBox.Show("Ingrese rollo y/o producto !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        Tabladetallemov.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetallemov));
                        griddetallemov.CurrentCell = griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["rollo"];
                        griddetallemov.BeginEdit(true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_deteliminar_Click(object sender, EventArgs e)
        {
            var lc_cont = 0;
            var xcoditem = string.Empty;
            if ((griddetallemov.CurrentRow != null))
            {
                xcoditem = griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["rollo"].Value.ToString();
                for (lc_cont = 0; lc_cont <= Tabladetallemov.Rows.Count - 1; lc_cont++)
                {
                    if (Tabladetallemov.Rows[lc_cont]["rollo"].ToString() == xcoditem)
                    {
                        Tabladetallemov.Rows[lc_cont].Delete();
                        Tabladetallemov.AcceptChanges();
                        break;
                    }
                }
                calcular_totales();
            }
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quieres cerrar el formulario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void data_Tabladetallemovmov()
        {
            try
            {
                Decimal
                xxdiferencia = 0,
                xxstockfisico = 0,
                xxstocklibros = 0;
                griddetallemov.AutoGenerateColumns = false;

                var BL = new tb_60local_stock_inventarioBL();
                var BE = new tb_60local_stock_inventario();

                var dt = new DataTable();
                BE.moduloid = modulo;
                BE.local = local;
                BE.tipodoc = tipodoc.SelectedValue.ToString().Trim();
                BE.serdoc = serdoc.Text.Trim().PadLeft(4, '0');
                BE.numdoc = numdoc.Text.Trim().PadLeft(10, '0');

                dt = BL.GetAll_Rollo_datosdetalle(EmpresaID, BE).Tables[0];
                if (Tabladetallemov != null)
                {
                    Tabladetallemov.Clear();
                }

                foreach (DataRow fila in dt.Rows)
                {
                    row = Tabladetallemov.NewRow();
                    row["rollo"] = fila["rollo"].ToString();
                    row["productid"] = fila["productid"].ToString().Trim();
                    row["productname"] = fila["productname"].ToString().Trim();
                    row["stocklibros"] = fila["stocklibros"].ToString();
                    row["stockfisico"] = fila["stockfisico"].ToString();
                    xxstocklibros = Convert.ToDecimal(fila["stocklibros"].ToString());
                    xxstockfisico = Convert.ToDecimal(fila["stockfisico"].ToString());
                    xxdiferencia = xxstocklibros - xxstockfisico;
                    ubic.Text = fila["codigoubic"].ToString();
                    row["diferencia"] = xxdiferencia;
                    Tabladetallemov.Rows.Add(row);
                }
                griddetallemov.DataSource = Tabladetallemov;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidaTabladetallemovmov(String xrollo)
        {
            var rowrollo = Tabladetallemov.Select("rollo='" + xrollo + "'");
            if (rowrollo.Length > 0)
            {
                MessageBox.Show("Rollo Ya Existe !!!!!!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Decimal xstocklibros = 0,
            xstockfisico = 0,
            xdiferencia = 0;

            griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productname"].Value = string.Empty;
            if (xrollo.Trim().Length == 10)
            {
                var  BL2 = new tb_60local_stock_inventario_rollo_cargaBL();
                var  BE2 = new tb_60local_stock_inventario_rollo_carga();
                var dt2 = new DataTable();
                BE2.rollo = xrollo;
                dt2 = BL2.GetAll_rollo(EmpresaID, BE2).Tables[0];
                if (dt2.Rows.Count > 0)
                {
                    var Mensaje = "» ROLLO: " + dt2.Rows[0]["rollo"].ToString() + "\n\n" +
                                "     »»  TipDoc: " + dt2.Rows[0]["tipodoc"].ToString() + "\n" +
                                "     »»  SerDoc: " + dt2.Rows[0]["serdoc"].ToString() + "\n" +
                                "     »»  NumDoc: " + dt2.Rows[0]["numdoc"].ToString();
                    MessageBox.Show(Mensaje, "» Rollos Existentes ...");
                    return;
                }

                var BE = new tb_60local_stock_inventario_rollo();
                var BL = new tb_60local_stock_inventario_rolloBL();
                var dt = new DataTable();
                BE.rollo = xrollo;

                dt = BL.GetAll_Rollo(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["rollo"].Value = dt.Rows[0]["rollo"].ToString().Trim();
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productid"].Value = dt.Rows[0]["productid"].ToString().Trim();
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["productname"].Value = dt.Rows[0]["productname"].ToString().Trim();
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["stocklibros"].Value = dt.Rows[0]["stocklibros"].ToString().Trim();
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["stockfisico"].Value = dt.Rows[0]["stockfisico"].ToString().Trim();
                    xstocklibros = Convert.ToDecimal(dt.Rows[0]["stocklibros"].ToString());
                    xstockfisico = Convert.ToDecimal(dt.Rows[0]["stockfisico"].ToString());
                    xdiferencia = xstocklibros - xstockfisico;
                    griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["diferencia"].Value = xdiferencia;
                    Tabladetallemov.AcceptChanges();
                    griddetallemov.CurrentCell = griddetallemov.Rows[griddetallemov.RowCount - 1].Cells["stockfisico"];
                }
                else
                {
                    MessageBox.Show("Rollo no Existe en Tabla Inventario !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Rollo no Existe !!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void griddetallemov_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    if ((griddetallemov.CurrentCell != null))
                    {
                        if (griddetallemov.CurrentCell.ReadOnly == false)
                        {
                            if (griddetallemov.Columns[griddetallemov.CurrentCell.ColumnIndex].Name.ToUpper() == "rollo".ToUpper())
                            {
                                AyudaRollo(string.Empty);
                            }
                        }
                    }
                }


                if (e.KeyCode == (Keys.Back | Keys.LButton))
                {
                    if ((griddetallemov.CurrentCell != null))
                    {
                        if (griddetallemov.CurrentCell.ReadOnly == true)
                        {
                            var xrollo = Convert.ToString(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["rollo"].Value);
                            if (xrollo != string.Empty)
                            {
                                ValidaTabladetallemovmov(xrollo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void griddetallemov_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (VariablesPublicas.PulsaAyudaArticulos)
                {
                    if (griddetallemov.Columns[griddetallemov.CurrentCell.ColumnIndex].Name.ToUpper() == "rollo".ToUpper())
                    {
                        AyudaRollo(string.Empty);
                    }
                    VariablesPublicas.PulsaAyudaArticulos = false;
                    Tabladetallemov.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void griddetallemov_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
        }

        private void griddetallemov_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (griddetallemov.CurrentRow != null)
                {
                    if (griddetallemov.Columns[e.ColumnIndex].Name.ToUpper() == "rollo".ToUpper())
                    {
                        var xrollo = string.Empty;
                        xrollo = (griddetallemov.Rows[griddetallemov.CurrentRow.Index].Cells["rollo"].Value.ToString().Trim()).PadLeft(10, '0');
                        if (xrollo != "0000000000")
                        {
                            ValidaTabladetallemovmov(xrollo);
                        }
                    }

                    if (griddetallemov.Columns[e.ColumnIndex].Name.ToUpper() == "stockfisico".ToUpper())
                    {
                        Decimal xstocklib = 0, xstockfis = 0, diferencia = 0;

                        xstocklib = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["stocklibros"].Value);
                        xstockfis = Convert.ToDecimal(griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["stockfisico"].Value);
                        diferencia = xstocklib - xstockfis;
                        griddetallemov.Rows[griddetallemov.CurrentCell.RowIndex].Cells["diferencia"].Value = diferencia;
                    }
                }

                calcular_totales();
            }
            catch (Exception ex)
            {
                var error = string.Empty;
                error = ex.GetType().ToString();
                if (error == "System.Data.ConstraintException")
                {
                    MessageBox.Show("Producto ya existe!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void griddetallemov_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            griddetallemov[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            griddetallemov[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            griddetallemov.EnableHeadersVisualStyles = false;
            griddetallemov.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            griddetallemov.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void griddetallemov_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            griddetallemov[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }

        private void btnImprimirNoval_Click(object sender, EventArgs e)
        {
            try
            {
                if (Tabladetallemov.Rows.Count > 0)
                {
                    var miForma = new REPORTES.Frm_reportes();

                    miForma.dominioid = dominio.Trim();
                    miForma.moduloid = modulo.Trim();
                    miForma.local = local.Trim();

                    miForma.Text = "Reporte Inventariado Fisico";
                    miForma.formulario = "Frm_reporte_inventariado";
                    miForma.tipdoc = tipodoc.SelectedValue.ToString();
                    miForma.serdoc = serdoc.Text.Trim().PadLeft(4, '0');
                    miForma.numdoc = numdoc.Text.Trim().PadLeft(10, '0');
                    miForma.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tipodoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            perianio = string.Empty;
            perimes = string.Empty;
            fechadocedit = false;

            tipodocautomatico = false;
            tipodocmanejaserie = false;
            statusDoc = true;

            if (btn_nuevo.Enabled == false)
            {
                limpiar_documento();
                select_tipodoc();
                if (statusDoc)
                {
                    form_bloqueado(true);
                    fechdoc.Enabled = false;
                    btn_cancelar.Enabled = true;
                    btn_grabar.Enabled = true;
                    btn_import.Enabled = true;

                    btn_detanadir.Enabled = true;
                    btn_deteliminar.Enabled = true;
                }
            }
            else
            {
                select_tipodoc();
                numdoc.Text = string.Empty;
            }
        }

        private void data_cbo_tipodoc()
        {
            try
            {
                var BL = new modulo_local_tipodocBL();
                var BE = new tb_modulo_local_tipodoc();
                BE.dominioid = dominio;
                BE.moduloid = modulo;
                BE.local = local;
                BE.visiblealmac = true;
                BE.status = "1";

                tipodoc.DataSource = BL.GetAll_mov(EmpresaID, BE).Tables[0];
                tipodoc.ValueMember = "tipodoc";
                tipodoc.DisplayMember = "tipodocname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void select_tipodoc()
        {
            try
            {
                if (tipodoc.SelectedValue.ToString() != "00" && tipodoc.SelectedIndex != 0)
                {
                    var BL = new modulo_local_tipodocBL();
                    var BE = new tb_modulo_local_tipodoc();
                    var dt = new DataTable();

                    BE.dominioid = dominio;
                    BE.moduloid = modulo;
                    BE.local = local;
                    BE.tipodoc = tipodoc.SelectedValue.ToString().Trim();
                    BE.visiblealmac = true;

                    dt = BL.GetAll(EmpresaID, BE).Tables[0];

                    almacaccionid = dt.Rows[0]["almacaccionid"].ToString().Trim();

                    tipodocautomatico = Convert.ToBoolean(dt.Rows[0]["tipodocautomatico"]);
                    tipodocmanejaserie = Convert.ToBoolean(dt.Rows[0]["tipodocmanejaserie"]);

                    if (almacaccionid.Trim().Length > 0)
                    {
                        if (tipodocautomatico)
                        {
                            if (tipodocmanejaserie)
                            {
                                get_autoCS_numMov();
                            }
                            else
                            {
                                MessageBox.Show("Documento debe manejar Serie", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                statusDoc = false;
                            }
                        }
                        else
                        {
                            if (tipodocmanejaserie)
                            {
                                get_autoCS_numMov();
                                numdoc.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("Documento debe manejar Serie", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                statusDoc = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Asignar la Accion del Documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        statusDoc = false;
                    }
                }
                else
                {
                    serdoc.Text = string.Empty;
                    numdoc.Text = string.Empty;
                    statusDoc = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusDoc = false;
            }
        }

        private void get_autoCS_numMov()
        {
            try
            {
                var BL = new modulo_local_tipodocseriesBL();
                var BE = new tb_modulo_local_tipodocseries();
                var dt = new DataTable();
                BE.dominioid = dominio;
                BE.moduloid = modulo;
                BE.local = local;
                BE.tipodoc = tipodoc.SelectedValue.ToString().Trim();

                dt = BL.GetAll_nuevonumero(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    serdoc.Text = dt.Rows[0]["serdoc"].ToString();
                    numdoc.Text = dt.Rows[0]["numero"].ToString();
                }
                else
                {
                    serdoc.Text = string.Empty;
                    numdoc.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
        }

        private void Frm_digitacion_inv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                if (!griddetallemov.ReadOnly)
                {
                    btn_detanadir_Click(sender, e);
                }
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

        private void numdoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(numdoc, e);
        }

        private void numdoc_LostFocus(object sender, System.EventArgs e)
        {
            form_cargar_datos(string.Empty);
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            try
            {
                var frmayuda = new Frm_movimiento_rollos_upload();
                frmayuda.titulo = "CARGA MASIVA ROLLOS DE TELA";
                frmayuda.Owner = this;
                frmayuda.PasarTabla = Recibedetallemov;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }

        private void Recibedetallemov(DataTable resultado)
        {
            if (resultado.Rows.Count > 0)
            {
                if (Tabladetallemov.Rows.Count > 0)
                {
                    Tabladetallemov.Rows.Clear();
                }
                foreach (DataRow fila in resultado.Rows)
                {
                    var BL = new tb_60local_stock_inventario_rollo_cargaBL();
                    var BE = new tb_60local_stock_inventario_rollo_carga();
                    var dt = new DataTable();
                    BE.rollo = fila["rollo"].ToString();
                    dt = BL.GetAll_rollo(EmpresaID, BE).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        row = DataError.NewRow();
                        row["error"] = "» ROLLO: " + dt.Rows[0]["rollo"].ToString() + "    --> " + dt.Rows[0]["tipodoc"].ToString() + " - " +
                                        dt.Rows[0]["serdoc"].ToString() + " - " +
                                        dt.Rows[0]["numdoc"].ToString();
                        DataError.Rows.Add(row);
                    }
                    else
                    {
                        row = Tabladetallemov.NewRow();
                        row["rollo"] = fila["rollo"].ToString();
                        row["productid"] = fila["productid"].ToString();
                        row["productname"] = fila["productname"].ToString();
                        row["stocklibros"] = fila["stocklibros"].ToString();
                        row["stockfisico"] = fila["stockfisico"].ToString();
                        row["diferencia"] = fila["diferencia"].ToString();
                        Tabladetallemov.Rows.Add(row);
                    }
                }
                griddetallemov.DataSource = Tabladetallemov;
                calcular_totales();
            }
        }

        private void btn_error_Click(object sender, EventArgs e)
        {
            var frm = new Cogido.Frm_VistaErrores();
            frm.tabla = DataError;
            frm.ShowDialog();
        }

        private void rollo_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var fieldName = string.Concat("[", Tabladetallemov.Columns[0].ColumnName, "]");
                Tabladetallemov.DefaultView.Sort = fieldName;
                var view = Tabladetallemov.DefaultView;
                view.RowFilter = string.Empty;
                if (rollo_search.Text != string.Empty)
                {
                    view.RowFilter = fieldName + " LIKE '%" + rollo_search.Text + "%'";
                }
                griddetallemov.DataSource = view;
            }
        }

        private void numdoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                form_cargar_datos(string.Empty);
            }
        }
    }
}
