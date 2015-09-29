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


namespace BapFormulariosNet.D70Produccion
{
    public partial class Frm_reporte_req_produccion1 : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;
        private DataTable TablaRequerimientoProd;
        private String PERFILID = string.Empty;

        private String ssModo = "NEW";

        public Frm_reporte_req_produccion1()
        {
            InitializeComponent();
            //numop_ini.LostFocus += new System.EventHandler(numop_ini_LostFocus);
            //numop_fin.LostFocus += new System.EventHandler(numop_fin_LostFocus);
        }

        void TmpRequerimientoProd()
        {
            TablaRequerimientoProd = new DataTable();
            TablaRequerimientoProd.Columns.Add("tipop", typeof(String));
            TablaRequerimientoProd.Columns.Add("serop", typeof(String));
            TablaRequerimientoProd.Columns.Add("numop", typeof(String));

            TablaRequerimientoProd.Columns.Add("tipreq", typeof(String));
            TablaRequerimientoProd.Columns.Add("serreq", typeof(String));
            TablaRequerimientoProd.Columns.Add("numreq", typeof(String));

            TablaRequerimientoProd.Columns.Add("ordenprod", typeof(String));
            TablaRequerimientoProd.Columns.Add("familiatelaid", typeof(String));
            TablaRequerimientoProd.Columns.Add("articid", typeof(String));
            TablaRequerimientoProd.Columns.Add("articidold", typeof(String));

            TablaRequerimientoProd.Columns.Add("colorid", typeof(String));
            TablaRequerimientoProd.Columns.Add("colorname", typeof(String));
            TablaRequerimientoProd.Columns.Add("coltalla", typeof(String));
            TablaRequerimientoProd.Columns.Add("can01", typeof(Int32));
            TablaRequerimientoProd.Columns.Add("can02", typeof(Int32));
            TablaRequerimientoProd.Columns.Add("can03", typeof(Int32));
            TablaRequerimientoProd.Columns.Add("can04", typeof(Int32));
            TablaRequerimientoProd.Columns.Add("can05", typeof(Int32));
            TablaRequerimientoProd.Columns.Add("can06", typeof(Int32));
            TablaRequerimientoProd.Columns.Add("can07", typeof(Int32));
            TablaRequerimientoProd.Columns.Add("can08", typeof(Int32));
            TablaRequerimientoProd.Columns.Add("can09", typeof(Int32));
            TablaRequerimientoProd.Columns.Add("can10", typeof(Int32));
            TablaRequerimientoProd.Columns.Add("can11", typeof(Int32));
            TablaRequerimientoProd.Columns.Add("can12", typeof(Int32));

            TablaRequerimientoProd.Columns.Add("panios", typeof(Int32));
            TablaRequerimientoProd.Columns.Add("totprendas", typeof(Int32));


        }


        //private void PARAMETROS_TABLA()
        //{
        //    var xxferfil = string.Empty;
        //    var f = (MainProduccion)MdiParent;
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

        //private void form_bloqueado(Boolean var)
        //{
        //    if (modulo.ToString() == "0100" || modulo.ToString() == "0900")
        //    {
        //        almacaccionid.Enabled = var;
        //        serop_ini.Enabled = var;
        //        numop_ini.Enabled = var;
        //        serop_fin.Enabled = var;
        //        numop_fin.Enabled = var;
        //        fechdocini.Enabled = var;
        //        fechdocfin.Enabled = var;

        //        cbo_moduloides.Enabled = var;
        //        localdes.Enabled = var;

        //        btn_nuevo.Enabled = false;
        //        btn_cancelar.Enabled = false;
        //        btn_imprimir.Enabled = false;
        //        btn_excel.Enabled = false;
        //        btn_salir.Enabled = false;
        //    }
        //    else
        //    {
        //        almacaccionid.Enabled = var;
        //        serop_ini.Enabled = var;
        //        numop_ini.Enabled = var;
        //        serop_fin.Enabled = var;
        //        numop_fin.Enabled = var;
        //        fechdocini.Enabled = var;
        //        fechdocfin.Enabled = var;

        //        cbo_moduloides.Enabled = false;
        //        localdes.Enabled = false;

        //        btn_nuevo.Enabled = false;
        //        btn_cancelar.Enabled = false;
        //        btn_imprimir.Enabled = false;
        //        btn_excel.Enabled = false;
        //        btn_salir.Enabled = false;
        //    }
        //}

        //private void form_accion_cancelEdicion(int confirnar)
        //{
        //    var sw_prosigue = true;
        //    if (confirnar == 1)
        //    {
        //        sw_prosigue = (MessageBox.Show("Desea cancelar ingreso de datos...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
        //    }
        //    else
        //    {
        //        sw_prosigue = true;
        //    }
        //    if (sw_prosigue)
        //    {
        //        limpiar_documento();
        //        form_bloqueado(false);

        //        btn_nuevo.Enabled = true;
        //        btn_salir.Enabled = true;

        //        ssModo = "NEW";
        //    }
        //}
        //private void data_cbo_tipmov()
        //{
        //    var test = new Dictionary<string, string>();
        //    test.Add(" ", "TODO");
        //    test.Add("10", "INGRESO");
        //    test.Add("20", "SALIDA");
        //    almacaccionid.DataSource = new BindingSource(test, null);
        //    almacaccionid.DisplayMember = "Value";
        //    almacaccionid.ValueMember = "Key";
        //}
        //private void ValidaLinea()
        //{
        //    if (serop_ini.Text.Trim().Length > 0)
        //    {
        //        var BL = new tb_60lineaBL();
        //        var BE = new tb_60linea();
        //        var dt = new DataTable();

        //        BE.moduloid = modulo;
        //        BE.lineaid = serop_ini.Text.Trim().PadLeft(3, '0');

        //        dt = BL.GetAll(EmpresaID, BE).Tables[0];
        //        if (dt.Rows.Count > 0)
        //        {
        //            serop_ini.Text = dt.Rows[0]["lineaid"].ToString().Trim();
        //            numop_ini.Text = dt.Rows[0]["lineaname"].ToString().Trim();
        //        }
        //        else
        //        {
        //            serop_ini.Text = string.Empty;
        //            numop_ini.Text = string.Empty;
        //        }
        //    }
        //    else
        //    {
        //        serop_ini.Text = string.Empty;
        //        numop_ini.Text = string.Empty;
        //    }
        //}

        //public bool IsNumeric(String Expression)
        //{
        //    bool isNum;
        //    double retNum;
        //    isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
        //    return isNum;
        //}

        //public static KeyEventHandler CapturarTeclaGRID
        //{
        //    get
        //    {
        //        KeyEventHandler keypress = new KeyEventHandler(LecturaTecla);
        //        return keypress;
        //    }
        //}
        //private static void LecturaTecla(System.Object sender, System.Windows.Forms.KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.F1)
        //    {
        //        VariablesPublicas.PulsaAyudaArticulos = true;
        //        SendKeys.Send("\t");
        //    }
        //    if (e.KeyCode == Keys.F2)
        //    {
        //        VariablesPublicas.PulsaTeclaF2 = true;
        //        SendKeys.Send("\t");
        //    }
        //    if (e.KeyCode == Keys.F3)
        //    {
        //        VariablesPublicas.PulsaTeclaF3 = true;
        //        SendKeys.Send("\t");
        //    }
        //}

        //private void AyudaLinea(String lpdescrlike)
        //{
        //    try
        //    {
        //        var modd = string.Empty;
        //        var BL = new sys_moduloBL();
        //        var BE = new tb_sys_modulo();
        //        var dt = new DataTable();

        //        BE.dominioid = dominio;
        //        BE.moduloid = modulo;
        //        dt = BL.GetAll(EmpresaID, BE).Tables[0];
        //        if (dt.Rows.Count > 0)
        //        {
        //            if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
        //            {
        //                modd = dt.Rows[0]["moduloshort"].ToString().Trim();

        //                var frmayuda = new AYUDAS.Frm_help_general();

        //                frmayuda.tipoo = "sql";
        //                frmayuda.titulo = "<< AYUDA  TABLA LINEA >>";
        //                frmayuda.sqlquery = "SELECT lineaid, lineaname FROM tb_" + modd + "_linea ";
        //                frmayuda.sqlinner = string.Empty;
        //                frmayuda.sqlwhere = "where";
        //                frmayuda.sqland = string.Empty;
        //                frmayuda.criteriosbusqueda = new string[] { "LINEA", "CODIGO" };
        //                frmayuda.columbusqueda = "lineaname,lineaid";
        //                frmayuda.returndatos = "0,1";

        //                frmayuda.Owner = this;
        //                frmayuda.PasaProveedor = RecibeLinea;
        //                frmayuda.ShowDialog();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}
        //private void RecibeLinea(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        //{
        //    if (resultado1.Trim().Length > 0)
        //    {
        //        serop_ini.Text = resultado1.Trim();
        //        numop_ini.Text = resultado2.Trim();
        //    }
        //}

        //private void limpiar_documento()
        //{
        //    if (modulo.ToString() == "0100" || modulo.ToString() == "0900")
        //    {
        //        almacaccionid.SelectedIndex = 0;
        //        fechdocini.Text = "01-01-2013";
        //        serop_ini.Text = string.Empty;
        //        numop_ini.Text = string.Empty;
        //        serop_fin.Text = string.Empty;
        //        numop_fin.Text = string.Empty;
        //    }
        //    else
        //    {
        //        almacaccionid.SelectedIndex = 0;
        //        fechdocini.Text = "01-01-2013";
        //        serop_ini.Text = string.Empty;
        //        numop_ini.Text = string.Empty;
        //        serop_fin.Text = string.Empty;
        //        numop_fin.Text = string.Empty;
        //        cbo_moduloides.SelectedValue = modulo.ToString();
        //        localdes.SelectedValue = local.ToString();
        //    }
        //}

        //private void nuevo()
        //{
        //    limpiar_documento();
        //    form_bloqueado(true);
        //    btn_imprimir.Enabled = true;
        //    btn_excel.Enabled = true;
        //    btn_cancelar.Enabled = true;
        //    serop_ini.Focus();
        //    ssModo = "NEW";
        //}

        private void Frm_reporte_mov_ordprod_Load(object sender, EventArgs e)
        {
            if (Parent.Parent.Name == "MainAlmacen")
            {
                modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
                local = ((D60ALMACEN.MainAlmacen)MdiParent).local;
            }

            if (Parent.Parent.Name == "MainProduccion")
            {
                modulo = ((D70Produccion.MainProduccion)MdiParent).moduloid;
                local = ((D70Produccion.MainProduccion)MdiParent).local;
            }
            //get_cbo_modulo();
            //data_cbo_tipmov();
            //limpiar_documento();
            //form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_salir.Enabled = true;
        }

        //private void get_cbo_modulo()
        //{
        //    var BL = new sys_moduloBL();
        //    var BE = new tb_sys_modulo();
        //    var dt = new DataTable();
        //    BE.dominioid = dominio.Trim();
        //    dt = BL.GetAll(EmpresaID, BE).Tables[0];
        //    if (dt.Rows.Count > 0)
        //    {
        //        cbo_moduloides.DataSource = dt;
        //        cbo_moduloides.ValueMember = "moduloid";
        //        cbo_moduloides.DisplayMember = "moduloname";
        //    }
        //}

        //private void get_dominio_modulo_local(string dominioid, string moduloid)
        //{
        //    if (moduloid.ToString().Length == 4 && moduloid.ToString() != "0000")
        //    {
        //        var BL = new sys_localBL();
        //        var BE = new tb_sys_local();
        //        BE.dominioid = dominioid;
        //        BE.moduloid = moduloid;

        //        var dt = new DataTable();
        //        dt = BL.GetAll(EmpresaID, BE).Tables[0];

        //        if (dt.Rows.Count > 0)
        //        {
        //            localdes.DataSource = dt;
        //            localdes.ValueMember = "local";
        //            localdes.DisplayMember = "localname";
        //        }
        //    }
        //}

        //private void solo_numero_enteros(object control, KeyPressEventArgs e)
        //{
        //    if (((e.KeyChar) >= '0' && e.KeyChar <= '9') && !(e.KeyChar == '.'))
        //    {
        //        e.Handled = false;
        //    }
        //    else
        //    {
        //        if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete && !(e.KeyChar == '.'))
        //        {
        //            e.Handled = false;
        //        }
        //        else
        //        {
        //            if ((e.KeyChar) == (char)Keys.Tab)
        //            {
        //                e.Handled = false;
        //            }

        //            else
        //            {
        //                e.Handled = true;
        //            }
        //        }
        //    }
        //}

        //private void Frm_reporte_req_produccion_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Insert)
        //    {
        //    }

        //    if (e.Control && e.KeyCode == Keys.N)
        //    {
        //        if (btn_nuevo.Enabled)
        //        {
        //            nuevo();
        //        }
        //    }

        //    if (e.KeyCode == Keys.Escape)
        //    {
        //        if (btn_cancelar.Enabled)
        //        {
        //            form_accion_cancelEdicion(1);
        //        }
        //        else
        //        {
        //            btn_salir_Click(sender, e);
        //        }
        //    }
        //}

        //private void serop_ini_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    solo_numero_enteros(sender, e);
        //}

        //private void numop_ini_LostFocus(object sender, System.EventArgs e)
        //{
        //    var numdo = string.Empty;
        //    if (numop_ini.Text.Trim().Length > 0)
        //    {
        //        numdo = numop_ini.Text.Trim().PadLeft(10, '0');
        //    }
        //    numop_ini.Text = numdo;
        //    numop_fin.Text = numdo;
        //}

        //private void numop_ini_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    solo_numero_enteros(sender, e);
        //}

        //private void serop_fin_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    solo_numero_enteros(sender, e);
        //}

        //private void numop_fin_LostFocus(object sender, System.EventArgs e)
        //{
        //    var numdo = string.Empty;
        //    if (numop_fin.Text.Trim().Length > 0)
        //    {
        //        numdo = numop_fin.Text.Trim().PadLeft(10, '0');
        //    }
        //    numop_fin.Text = numdo;
        //}

        //private void numop_fin_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    solo_numero_enteros(sender, e);
        //}

        //private void btn_nuevo_Click(object sender, EventArgs e)
        //{
        //    nuevo();
        //}

        //private void btn_cancelar_Click(object sender, EventArgs e)
        //{
        //    form_accion_cancelEdicion(1);
        //}

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                var miForma = new Reportes.Frm_reportes();
                miForma.Text = "Reporte por Orden de Producción";
                miForma.dominioid = dominio.Trim();
                //if (cbo_moduloides.SelectedIndex != -1)
                //{
                //    miForma.moduloid = cbo_moduloides.SelectedValue.ToString();
                //}
                //else
                //{
                //    MessageBox.Show("!!!... Seleccione Modulo ...!!!", "Información");
                //    return;
                //}
                //if (localdes.SelectedIndex != -1)
                //{
                //    miForma.local = localdes.SelectedValue.ToString();
                //}
                //else
                //{
                //    MessageBox.Show("!!!... Seleccione Local ...!!!", "Información");
                //    return;
                //}

                //miForma.serop_ini = serop_ini.Text.Trim();
                //miForma.numop_ini = numop_ini.Text.Trim();
                //miForma.serop_fin = serop_ini.Text.Trim();
                //miForma.numop_fin = numop_fin.Text.Trim();
                //miForma.fechdocini = fechdocini.Text.Trim().Substring(0, 10);
                //miForma.fechdocfin = fechdocfin.Text.Trim().Substring(0, 10);
                //if (almacaccionid.SelectedIndex != -1 && almacaccionid.SelectedItem.ToString().Trim().Length > 0)
                //{
                //    miForma.almacaccionid = almacaccionid.SelectedValue.ToString();
                //}
                miForma.formulario = "Frm_reporte_req_produccion1";
                miForma.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txt_busqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    String xnumreqb = "";
                    xnumreqb = txt_busqueda.Text.PadLeft(10, '0');
                    CargarDatosReq(xnumreqb);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }       
        }

        void CargarDatosReq(String xnumreq)
        {
            tb_pp_requerimientoprodBL BL = new tb_pp_requerimientoprodBL();
            tb_pp_requerimientoprod BE = new tb_pp_requerimientoprod();
            DataTable dt = new DataTable();
            BE.tipreq = "RQ";
            BE.serreq = "0001";
            BE.numreq = xnumreq;
            BE.idx = "CAB"; // BUSCAMOS LA CABECERA

            dt = BL.GetAllCab(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["estado"].ToString().Trim() != "9")
                {
                    txt_numreq.Text = dt.Rows[0]["numreq"].ToString();
                    txt_fechini.Text = dt.Rows[0]["fechini"].ToString();
                    txt_fechentrega.Text = dt.Rows[0]["fechfin"].ToString();
                    txt_servcorteid.Text = dt.Rows[0]["servcorteid"].ToString();
                    txt_servcortename.Text = dt.Rows[0]["servcortename"].ToString();

                    BE.idx = "DET"; //BUSCAMOS EL DETALLE
                    TablaRequerimientoProd = BL.GetAllDet(EmpresaID, BE).Tables[0];
                    dgv_requerimiento.DataSource = TablaRequerimientoProd;

                    //btn_editar.Enabled = true;
                    //btn_eliminar.Enabled = true;
                    btn_imprimir.Enabled = true;
                    btn_salir.Enabled = true;
                    //pdtimagen.Visible = false;
                }
                else
                {
                    txt_numreq.Text = dt.Rows[0]["numreq"].ToString();
                    txt_fechini.Text = dt.Rows[0]["fechini"].ToString();
                    txt_fechentrega.Text = dt.Rows[0]["fechfin"].ToString();
                    txt_servcorteid.Text = dt.Rows[0]["servcorteid"].ToString();
                    txt_servcortename.Text = dt.Rows[0]["servcortename"].ToString();

                    BE.idx = "DET"; //BUSCAMOS EL DETALLE
                    TablaRequerimientoProd = BL.GetAllDet(EmpresaID, BE).Tables[0];
                    dgv_requerimiento.DataSource = TablaRequerimientoProd;

                    ssModo = "ANULADO";
                    //pdtimagen.Visible = true;
                    //btn_editar.Enabled = false;
                    //btn_eliminar.Enabled = false;
                    btn_imprimir.Enabled = true;
                    btn_salir.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Requerimiento no Encontrado", "Buscando!!!!!");
            }
        }

        private void dgv_requerimiento_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_requerimiento.Columns[e.ColumnIndex].Name.ToUpper() == "panios".ToUpper())
            {
                Int32 xpanios = 0, xcantidad = 0;
                xpanios = Convert.ToInt32(dgv_requerimiento.Rows[dgv_requerimiento.CurrentCell.RowIndex].Cells["panios"].Value);
                for (int j = 13; j < dgv_requerimiento.Columns.Count - 2; j++)
                {
                    xcantidad = xcantidad + Convert.ToInt32(dgv_requerimiento.Rows[dgv_requerimiento.CurrentCell.RowIndex].Cells[j].Value.ToString());
                }
                dgv_requerimiento.Rows[dgv_requerimiento.CurrentCell.RowIndex].Cells["totprendas"].Value = xpanios * xcantidad;
            }
        }

        private void dgv_requerimiento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        //private void serop_ini_TextChanged(object sender, EventArgs e)
        //{
        //    serop_ini.Text = serop_ini.Text.Trim().ToUpper();
        //    serop_fin.Text = serop_ini.Text;
        //}

        //private void serop_fin_TextChanged(object sender, EventArgs e)
        //{
        //    serop_fin.Text = serop_fin.Text.Trim().ToUpper();
        //}

        //private void btn_excel_Click(object sender, EventArgs e)
        //{
        //    var BL = new tb_60movimientosdetBL();
        //    var BE = new tb_60movimientosdet();
        //    var TablaMov_ordprod = new DataTable();
        //    BE.moduloid = modulo.Trim();
        //    BE.local = local.Trim();
        //    BE.fechdocini = Convert.ToDateTime(fechdocini.Text.Trim().Substring(0, 10));
        //    BE.fechdocfin = Convert.ToDateTime(fechdocfin.Text.Trim().Substring(0, 10));
        //    BE.ser_opi = serop_ini.Text.Trim();
        //    BE.num_opi = numop_ini.Text.Trim();
        //    BE.ser_opf = serop_fin.Text.Trim();
        //    BE.num_opf = numop_fin.Text.Trim();
        //    if (almacaccionid.SelectedIndex != -1 && almacaccionid.SelectedItem.ToString().Trim().Length > 0)
        //    {
        //        BE.almacaccionid = almacaccionid.SelectedValue.ToString();
        //    }
        //    BE.filtro = "1";

        //    TablaMov_ordprod = BL.GetAll_ConsumoxOP(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
        //    if (TablaMov_ordprod.Rows.Count > 0)
        //    {
        //        ExportarExcel(TablaMov_ordprod);
        //    }
        //}

        //private void ExportarExcel(DataTable TablapromoDet)
        //{
        //    Excel.Application oXL;
        //    Excel._Workbook oWB;
        //    Excel._Worksheet oSheet;
        //    Excel.Range oRng;

        //    try
        //    {
        //        oXL = new Excel.Application();
        //        oXL.Visible = false;

        //        oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
        //        oSheet = (Excel._Worksheet)oWB.ActiveSheet;


        //        oSheet.Cells[1, 1] = "Num_OP";
        //        oSheet.Cells[1, 2] = "CODIGO";
        //        oSheet.Cells[1, 3] = "PRODUCTO";
        //        oSheet.Cells[1, 4] = "FECHA";
        //        oSheet.Cells[1, 5] = "DOC_REF";
        //        oSheet.Cells[1, 6] = "ROLLO";
        //        oSheet.Cells[1, 7] = "CANTIDAD";
        //        oSheet.Cells[1, 8] = "VALOR";
        //        oSheet.Cells[1, 9] = "IMPORTE";
        //        oSheet.Cells[1, 10] = "MONEDA";
        //        oSheet.Cells[1, 11] = "DESTINO";
        //        oSheet.Cells[1, 12] = "MOTIVO";

        //        oSheet.get_Range("A1", "L1").Font.Bold = true;
        //        oSheet.get_Range("A1", "L1").Font.Color = Color.White;
        //        oSheet.get_Range("A1", "L1").Interior.ColorIndex = 14;
        //        oSheet.get_Range("A1", "L1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

        //        var IndiceFila = 2;
        //        oSheet.Range["D:D"].NumberFormat = "dd/mm/yyyy;@";
        //        oSheet.Range["G:I"].NumberFormat = "_ * #,##0.00_ ;_ * -#,##0.00_ ;_ * -??_ ;_ @_ ";

        //        foreach (DataRow row in TablapromoDet.Rows)
        //        {
        //            oSheet.Cells[IndiceFila, 01].Value = "'" + row["num_op"].ToString().Trim();
        //            oSheet.Cells[IndiceFila, 02].Value = "'" + row["productid"].ToString().Trim();
        //            oSheet.Cells[IndiceFila, 03].Value = row["productname"];
        //            oSheet.Cells[IndiceFila, 04].Value = row["fechdoc"];
        //            oSheet.Cells[IndiceFila, 05].Value = "'" + row["numdoc"].ToString().Trim();
        //            oSheet.Cells[IndiceFila, 06].Value = "'" + row["rollo"].ToString().Trim();
        //            oSheet.Cells[IndiceFila, 07].Value = row["cantidad"];
        //            oSheet.Cells[IndiceFila, 08].Value = row["valor"];
        //            oSheet.Cells[IndiceFila, 09].Value = row["importe"];
        //            oSheet.Cells[IndiceFila, 10].Value = "'" + row["moneda"].ToString().Trim();
        //            oSheet.Cells[IndiceFila, 11].Value = row["ctactename"];
        //            oSheet.Cells[IndiceFila, 12].Value = row["mottrasladointname"];

        //            IndiceFila++;
        //        }


        //        oRng = oSheet.get_Range("A1", "L1");
        //        oRng.EntireColumn.AutoFit();

        //        oSheet.Cells[2, 1].Select();
        //        oXL.ActiveWindow.FreezePanes = true;

        //        oXL.Visible = true;
        //        oXL.UserControl = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        String errorMessage;
        //        errorMessage = "Error: ";
        //        errorMessage = String.Concat(errorMessage, ex.Message);
        //        errorMessage = String.Concat(errorMessage, " Line: ");
        //        errorMessage = String.Concat(errorMessage, ex.Source);

        //        MessageBox.Show(errorMessage, "Error");
        //    }
        //}

        //private void serop_ini_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        numop_ini.Focus();
        //    }
        //}

        //private void numop_ini_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        numop_fin.Focus();
        //    }
        //}

        //private void numop_fin_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        btn_imprimir.PerformClick();
        //    }
        //}

        //private void cbo_moduloides_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cbo_moduloides.Items.Count > 0)
        //    {
        //        get_dominio_modulo_local(dominio.ToString(), cbo_moduloides.SelectedValue.ToString());
        //    }
        //}
    }
}
