using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.D60ALMACEN
{
    public partial class Frm_reporte_historialxestacion : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;
        private String PERFILID = string.Empty;
        private DataTable TablaStock;
        private DataTable TablaHistorial;
        private DataTable TablaReporte;
        private DataRow row;

        private String xxferfil = string.Empty;

        public Frm_reporte_historialxestacion()
        {
            InitializeComponent();
        }

        private void PARAMETROS_TABLA()
        {
            if (((D60ALMACEN.MainAlmacen)MdiParent).moduloid == "0500")
            {
                xxferfil = "600500000";
            }
            else
            {
                if (((D60ALMACEN.MainAlmacen)MdiParent).moduloid == "0520")
                {
                    xxferfil = "600520000";
                }
                else
                {
                    var f = (MainAlmacen)MdiParent;
                    xxferfil = f.perfil.ToString();
                }
            }
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

        private void CargarComboEstaciones()
        {
            var BL = new tb_60movimientosdetBL();
            var BE = new tb_60movimientosdet();
            var dt = new DataTable();

            BE.moduloid = modulo;
            BE.codigo = cencosid.Text.ToString();
            BE.filtro = "3";

            dt = BL.GetAll_KardexEstacion(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cmb_estacion.DataSource = dt;
                cmb_estacion.DisplayMember = "estacion";
                cmb_estacion.ValueMember = "estacion";
            }
        }

        private void form_bloqueado(Boolean var)
        {
            try
            {
                cencosid.Enabled = var;
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
                form_bloqueado(false);
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
                cencosid.Text = string.Empty;
                cencosname.Text = string.Empty;
                unmedpeso.Text = string.Empty;
                cencosid.Focus();
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
        }

        private void Frm_reporte_historialxestacion_Load(object sender, EventArgs e)
        {
            modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
            local = ((D60ALMACEN.MainAlmacen)MdiParent).local;

            PARAMETROS_TABLA();
            TablaStock = new DataTable();
            TablaStock.Columns.Add("productid", typeof(String));
            TablaStock.Columns.Add("productname", typeof(String));
            TablaStock.Columns.Add("nserie", typeof(String));
            TablaStock.Columns.Add("stock", typeof(String));
            TablaStock.Columns.Add("fechdoc", typeof(DateTime));

            TablaHistorial = new DataTable();
            TablaHistorial.Columns.Add("fechdoc", typeof(DateTime));
            TablaHistorial.Columns.Add("tipodoc", typeof(String));
            TablaHistorial.Columns.Add("serdoc", typeof(String));
            TablaHistorial.Columns.Add("numdoc", typeof(String));
            TablaHistorial.Columns.Add("cantidad", typeof(Int32));
            TablaHistorial.Columns.Add("motivo", typeof(String));
            TablaHistorial.Columns.Add("perdni", typeof(String));
            TablaHistorial.Columns.Add("nombrelargo", typeof(String));


            TablaReporte = new DataTable();
            TablaReporte.Columns.Add("productid", typeof(String));
            TablaReporte.Columns.Add("productname", typeof(String));
            TablaReporte.Columns.Add("nserie", typeof(String));
            TablaReporte.Columns.Add("fechdoc", typeof(DateTime));
            TablaReporte.Columns.Add("tipodoc", typeof(String));
            TablaReporte.Columns.Add("serdoc", typeof(String));
            TablaReporte.Columns.Add("numdoc", typeof(String));
            TablaReporte.Columns.Add("cantidad", typeof(Decimal));
            TablaReporte.Columns.Add("motivo", typeof(String));
            TablaReporte.Columns.Add("perdni", typeof(String));
            TablaReporte.Columns.Add("nombrelargo", typeof(String));
            TablaReporte.Columns.Add("cencosid", typeof(String));
            TablaReporte.Columns.Add("cencosname", typeof(String));
            TablaReporte.Columns.Add("estacion", typeof(String));
        }
        private void cencosid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaCentroCosto();
                cmb_estacion.Focus();
                CargarComboEstaciones();
                cmb_estacion.SelectedIndex = -1;
            }

            if (e.KeyCode == Keys.Enter)
            {
                ValidaCentrocosto(cencosid.Text.ToString(), false);
                cmb_estacion.Focus();
                CargarComboEstaciones();
                cmb_estacion.SelectedIndex = -1;
            }
        }

        private void AyudaCentroCosto()
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "Ayuda Centro de Costo";
                frmayuda.sqlquery = "select cencosid, cencosname From tb_centrocosto where cencosdivi = 2";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = string.Empty;
                frmayuda.sqland = "and";
                frmayuda.criteriosbusqueda = new string[] { "NOMBRE", "CÓDIGO" };
                frmayuda.columbusqueda = "cencosname,cencosid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeCentroCosto;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ValidaCentrocosto(String xCencosid, Boolean retrn)
        {
            if (xCencosid.Trim().Length > 0)
            {
                var BL = new tb_co_persona_cencosBL();
                var BE = new tb_co_persona_cencosBE();

                var dt = new DataTable();

                BE.cencosid = xCencosid.Trim().ToString();
                BE.filtro = "1";
                dt = BL.GetDNI(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    cencosid.Text = dt.Rows[0]["cencosid"].ToString().Trim();
                    cencosname.Text = dt.Rows[0]["cencosname"].ToString().Trim();
                }
                else
                {
                    if (!retrn)
                    {
                        cencosid.Text = string.Empty;
                        cencosname.Text = string.Empty;
                    }
                }
            }
        }

        private void RecibeCentroCosto(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                cencosid.Text = resultado1.Trim();
                cencosname.Text = resultado2.Trim();
            }
        }

        private void data_Producto(String xproductid)
        {
            var rowgrupoid = TablaStock.Select("productid='" + xproductid + "'");
            if (rowgrupoid.Length > 0)
            {
                foreach (DataRow row in rowgrupoid)
                {
                    cencosid.Text = Equivalencias.Left(row["productidold"].ToString(), 5);
                    cencosname.Text = row["productid"].ToString().Trim();
                }
            }
        }

        private void cmb_estacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_estacion.SelectedIndex != -1)
            {
                var BL = new tb_60movimientosdetBL();
                var BE = new tb_60movimientosdet();

                BE.moduloid = modulo;
                BE.codigo = cencosid.Text.ToString() + cmb_estacion.SelectedValue.ToString();
                BE.filtro = "1";
                TablaStock = BL.GetAll_KardexEstacion(EmpresaID, BE).Tables[0];

                if (TablaStock.Rows.Count > 0)
                {
                    Dgb_ControlStock.DataSource = TablaStock;
                }
                else
                {
                    Dgb_ControlStock.DataSource = TablaStock;
                }
            }

            if (TablaHistorial.Rows.Count > 0)
            {
                TablaHistorial.Clear();
            }
        }



        private void exportarAExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfdhistorial.ShowDialog(this) == DialogResult.OK)
            {
                Examinar_Historial.ExportToXls(sfdhistorial.FileName);
            }
        }

        private void Ext_Stock_Click(object sender, EventArgs e)
        {
            if (sfdhistorial.ShowDialog(this) == DialogResult.OK)
            {
                Dgb_ControlStock.ExportToXls(sfdhistorial.FileName);
            }
        }

        private void Dgb_ControlStock_MouseClick(object sender, MouseEventArgs e)
        {
            var BL = new tb_60movimientosdetBL();
            var BE = new tb_60movimientosdet();

            if (dgb_mainStock.DataRowCount > 0)
            {
                var xproductid = dgb_mainStock.GetFocusedRowCellValue("productid").ToString();

                BE.moduloid = modulo;
                BE.productid = xproductid.ToString();
                BE.filtro = "2";
                TablaHistorial = BL.GetAll_KardexEstacion(EmpresaID, BE).Tables[0];
                if (TablaHistorial.Rows.Count > 0)
                {
                    Examinar_Historial.DataSource = TablaHistorial;
                }
                else
                {
                    Examinar_Historial.DataSource = TablaHistorial;
                }
            }
        }

        private void Dgb_ControlStock_KeyUp(object sender, KeyEventArgs e)
        {
            var BL = new tb_60movimientosdetBL();
            var BE = new tb_60movimientosdet();

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xproductid = string.Empty;
                xproductid = dgb_mainStock.GetFocusedRowCellValue("productid").ToString();

                BE.moduloid = modulo;
                BE.productid = xproductid.ToString();
                BE.filtro = "2";

                TablaHistorial = BL.GetAll_KardexEstacion(EmpresaID, BE).Tables[0];
                if (TablaHistorial.Rows.Count > 0)
                {
                    Examinar_Historial.DataSource = TablaHistorial;
                }
                else
                {
                    Examinar_Historial.DataSource = TablaHistorial;
                }
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            var BL = new tb_60movimientosdetBL();
            var BE = new tb_60movimientosdet();

            if (cencosid.Text.ToString() == string.Empty)
            {
                MessageBox.Show("Indicar el Centro de Costo ...!!!");
                return;
            }
            if (cmb_estacion.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una Estación ...!!!");
                return;
            }
            else
            {
                var xproductid = string.Empty;
                var xproductname = string.Empty;
                if (TablaReporte.Rows.Count > 0)
                {
                    TablaReporte.Rows.Clear();
                }
                foreach (DataRow fila in TablaStock.Rows)
                {
                    xproductid = fila["productid"].ToString();
                    xproductname = fila["productname"].ToString();
                    BE.moduloid = modulo.ToString();
                    BE.productid = xproductid.ToString();
                    BE.filtro = "2";

                    TablaHistorial = BL.GetAll_KardexEstacion(EmpresaID, BE).Tables[0];
                    if (TablaHistorial.Rows.Count > 0)
                    {
                        foreach (DataRow rows in TablaHistorial.Rows)
                        {
                            row = TablaReporte.NewRow();
                            row["cencosid"] = cencosid.Text.Trim();
                            row["cencosname"] = cencosname.Text.Trim();
                            row["estacion"] = cmb_estacion.SelectedValue.ToString();
                            row["productid"] = xproductid.ToString();
                            row["productname"] = xproductname.ToString();
                            row["fechdoc"] = rows["fechdoc"].ToString();
                            row["tipodoc"] = rows["tipodoc"].ToString();
                            row["serdoc"] = rows["serdoc"].ToString();
                            row["numdoc"] = rows["numdoc"].ToString();
                            row["cantidad"] = rows["cantidad"].ToString();
                            row["motivo"] = rows["motivo"].ToString();
                            row["perdni"] = rows["perdni"].ToString();
                            row["nombrelargo"] = rows["nombrelargo"].ToString();
                            TablaReporte.Rows.Add(row);
                        }
                    }
                }

                if (TablaReporte.Rows.Count > 0)
                {
                    var miForma = new REPORTES.Frm_reportes();
                    miForma.Table = TablaReporte;
                    miForma.Text = "Stock x Estaciones";
                    miForma.formulario = "Frm_reporte_StockEstacion";
                    miForma.ShowDialog();
                }
            }
        }
    }
}
