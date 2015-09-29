using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

using System.IO;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.Net.Sockets;

namespace BapFormulariosNet.D60ALMACEN
{
    public partial class Frm_reporte_rollocodbar : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;
        private String perianio = string.Empty;
        private String perimes = string.Empty;

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern SafeFileHandle CreateFile(string lpFileName, FileAccess dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, FileMode dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

        private DataTable Tablaproductorollo;

        private Boolean fechadocedit = false;
        private Boolean statusDoc = true;

        private String ssModo = "NEW";

        public Frm_reporte_rollocodbar()
        {
            InitializeComponent();

            productid.LostFocus += new System.EventHandler(productid_LostFocus);
        }

        private void get_val_fechadoc()
        {
            try
            {
                var BL = new constantesgeneralesBL();
                var dt = new DataTable();

                dt = BL.GetOne(EmpresaID, dominio, modulo, local).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    perianio = dt.Rows[0]["perianio"].ToString().Trim();
                    perimes = dt.Rows[0]["perimes"].ToString().Trim();
                    fechadocedit = Convert.ToBoolean(dt.Rows[0]["fechadocedit"]);
                }

                var fechaactual = DateTime.Today;
                rollofecompra.Value = fechaactual;

                get_tipocambio(rollofecompra.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusDoc = false;
            }
        }
        private void get_tipocambio(String fecha)
        {
            try
            {
                var BL = new tipocambioBL();
                var dt = new DataTable();

                dt = BL.GetOne(EmpresaID, Convert.ToDateTime(fecha)).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    tcamb.Text = Convert.ToDecimal(dt.Rows[0]["venta"]).ToString("###,##0.0000");
                }
                else
                {
                    tcamb.Text = "1";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void form_bloqueado(Boolean var)
        {
            try
            {
                rollofecompra.Enabled = var;
                tcamb.Enabled = false;


                gridproductorollo.ReadOnly = true;
                gridproductorollo.Enabled = var;
                productid.Enabled = var;
                productname.Enabled = false;
                rollodesde.Enabled = var;
                rollohasta.Enabled = var;
                btn_busqueda.Enabled = var;


                btn_nuevo.Enabled = false;
                btn_editar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_impcodbar.Enabled = false;
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
                form_bloqueado(false);
                get_val_fechadoc();
                btn_nuevo.Enabled = true;
                btn_salir.Enabled = true;

                ssModo = "NEW";
            }
        }
        private void ValidaProducto()
        {
            if (productid.Text.Trim().Length == 13)
            {
                var BL = new tb_60productosBL();
                var BE = new tb_60productos();
                var dt = new DataTable();

                BE.moduloid = modulo;
                BE.productid = productid.Text.Trim();

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    productid.Text = dt.Rows[0]["productid"].ToString().Trim();
                    productname.Text = dt.Rows[0]["productname"].ToString().Trim();
                }
                else
                {
                    productid.Text = string.Empty;
                    productname.Text = string.Empty;
                }
            }
            else
            {
                productid.Text = string.Empty;
                productname.Text = string.Empty;
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

        private void AyudaProducto(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "<< AYUDA  TABLA PRODUCTOS >>";
                frmayuda.sqlquery = "SELECT tb1.productid, tb1.productname, tb2.stock,tb2.costoultimo FROM tb_ta_productos AS tb1 ";
                frmayuda.sqlinner = "inner join tb_ta_local_stock as tb2 on tb1.productid = tb2.productid ";
                frmayuda.sqlwhere = "where";
                frmayuda.sqland = string.Empty;
                frmayuda.criteriosbusqueda = new string[] { "PRODUCTO", "CODIGO" };
                frmayuda.columbusqueda = "tb1.productname,tb1.productid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeProducto;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
        private void RecibeProducto(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0 && resultado2.Trim().Length > 0)
            {
                productid.Text = resultado1.Trim();
                productname.Text = resultado2.Trim();
            }
        }

        private void limpiar_documento()
        {
            try
            {
                productid.Text = string.Empty;
                productname.Text = string.Empty;
                rollodesde.Text = string.Empty;
                rollohasta.Text = string.Empty;
                rollofecompra.Value = DateTime.Today;
                get_tipocambio(rollofecompra.Text.Trim());
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
            get_val_fechadoc();
            btn_cancelar.Enabled = true;

            ssModo = "NEW";
        }
        private void Delete()
        {
        }

        private void Frm_movimiento_rollos_Activated(object sender, EventArgs e)
        {
        }
        private void Frm_movimiento_rollos_Load(object sender, EventArgs e)
        {
            modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
            local = ((D60ALMACEN.MainAlmacen)MdiParent).local;

            Tablaproductorollo = new DataTable("productorollo");
            Tablaproductorollo.Columns.Add("rollo", typeof(String));
            Tablaproductorollo.Columns.Add("productid", typeof(String));
            Tablaproductorollo.Columns.Add("productname", typeof(String));
            Tablaproductorollo.Columns.Add("rollolote", typeof(String));
            Tablaproductorollo.Columns.Add("rollostockini", typeof(Decimal));
            Tablaproductorollo.Columns["rollostockini"].DefaultValue = 0;
            Tablaproductorollo.Columns.Add("rollovalorini", typeof(Decimal));
            Tablaproductorollo.Columns["rollovalorini"].DefaultValue = 0;
            Tablaproductorollo.Columns.Add("rolloingre", typeof(Decimal));
            Tablaproductorollo.Columns["rolloingre"].DefaultValue = 0;
            Tablaproductorollo.Columns.Add("rolloegres", typeof(Decimal));
            Tablaproductorollo.Columns["rolloegres"].DefaultValue = 0;
            Tablaproductorollo.Columns.Add("rollostock", typeof(Decimal));
            Tablaproductorollo.Columns["rollostock"].DefaultValue = 0;
            Tablaproductorollo.Columns.Add("rollovaloractual", typeof(Decimal));
            Tablaproductorollo.Columns["rollovaloractual"].DefaultValue = 0;
            Tablaproductorollo.Columns.Add("rollomedcompra", typeof(Decimal));
            Tablaproductorollo.Columns["rollomedcompra"].DefaultValue = 0;
            Tablaproductorollo.Columns.Add("rollofecompra", typeof(String));
            Tablaproductorollo.Columns.Add("rolloancho", typeof(Decimal));
            Tablaproductorollo.Columns["rolloancho"].DefaultValue = 0;
            Tablaproductorollo.Columns.Add("rolloencog", typeof(Decimal));
            Tablaproductorollo.Columns["rolloencog"].DefaultValue = 0;
            Tablaproductorollo.Columns.Add("tipofallasid", typeof(String));
            Tablaproductorollo.Columns.Add("docuref", typeof(String));
            Tablaproductorollo.Columns.Add("statu", typeof(String));

            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_salir.Enabled = true;
        }
        private void Frm_movimiento_rollos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
            }

            if (e.Control && e.KeyCode == Keys.N)
            {
                if (btn_nuevo.Enabled)
                {
                    nuevo();
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

        private void productid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaProducto(string.Empty);
            }
        }
        private void productid_LostFocus(object sender, System.EventArgs e)
        {
            ValidaProducto();
        }
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }
        private void btn_editar_Click(object sender, EventArgs e)
        {
            ssModo = "EDIT";
            form_bloqueado(true);

            btn_cancelar.Enabled = true;
        }
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            form_accion_cancelEdicion(1);
        }
        private void btn_impcodbar_Click(object sender, EventArgs e)
        {
            Imprimir_barcode_datamax();
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void data_Tablaproductorollomov()
        {
            try
            {
                var BL = new tb_ta_prodrolloBL();
                var BE = new tb_ta_prodrollo();

                var dt = new DataTable();
                BE.productid = productid.Text.Trim().ToUpper();
                if (rollodesde.Text.Trim().Length > 0)
                {
                    BE.rollodesde = rollodesde.Text.Trim().PadLeft(10, '0');
                }

                if (rollohasta.Text.Trim().Length > 0)
                {
                    BE.rollohasta = rollohasta.Text.Trim().PadLeft(10, '0');
                }

                dt = BL.GetAll_prod(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    Tablaproductorollo = dt;
                    gridproductorollo.DataSource = Tablaproductorollo;
                    gridproductorollo.Rows[0].Selected = false;
                    gridproductorollo.Focus();
                    btn_impcodbar.Enabled = true;
                    btn_nuevo.Enabled = true;
                }
                else
                {
                    Tablaproductorollo = dt;
                    gridproductorollo.DataSource = Tablaproductorollo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridproductorollo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridproductorollo.CurrentRow != null)
                {
                    var xrollo = string.Empty;
                    xrollo = gridproductorollo.Rows[e.RowIndex].Cells["grollo"].Value.ToString().Trim();
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void gridproductorollo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xrollo = string.Empty;
                xrollo = gridproductorollo.Rows[gridproductorollo.CurrentRow.Index].Cells["grollo"].Value.ToString().Trim();
            }
        }
        private void gridproductorollo_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridproductorollo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridproductorollo[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(194, 224, 254);
            gridproductorollo[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(0, 0, 0);
        }
        private void gridproductorollo_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            gridproductorollo[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }
        private void rollodesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(rollodesde, e);
        }
        private void rollohasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(rollohasta, e);
        }
        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            data_Tablaproductorollomov();
        }
        private void Imprimir_barcode_zebra()
        {
            var BL = new tb_ta_prodrolloBL();
            var BE = new tb_ta_prodrollo();
            var dt = new DataTable();
            if (rollodesde.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese ROLLO DESDE !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (rollohasta.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese ROLLO HASTA !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToInt32(rollohasta.Text) < Convert.ToInt32(rollodesde.Text))
            {
                MessageBox.Show("ROLLO HASTA < ROLLO DESDE !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BE.rollodesde = rollodesde.Text.PadLeft(10, '0');
            BE.rollohasta = rollohasta.Text.PadLeft(10, '0');

            dt = BL.GetAll_codbarra(EmpresaID, BE).Tables[0];


            var CRTLF = Convert.ToString(Equivalencias.Chr(13)) + Convert.ToString(Equivalencias.Chr(10));

            var X11 = "^XA";
            var X12 = "^MCY";
            var X13 = "^XZ";
            var X14 = "^XA";
            var X15 = "^FWN^CFD,24^PW863^LH0,0";
            var X16 = "^CI0^PR2^MNY^MTT^MMT^MD0^PON^PMN^LRN";
            var X17 = "^XZ";
            var X18 = "^XA";
            var X19 = "^MCY";
            var X20 = "^XZ";
            var X21 = "^XA";
            var X22 = "^DFR:TEMP_FMT.ZPL";
            var X23 = "^LRN";

            var X44 = "^XZ";
            var X55 = "^XA";
            var X66 = "^XFR:TEMP_FMT.ZPL";
            var X77 = "^PQ1,0,1,Y";
            var X88 = "^XZ";
            var X99 = "^XA";

            var TW101 = "^A0B,28,18^FO28,43^FD";
            var TW102 = "^A0B,23,20^FO63,186^FD";
            var TW103 = "^A0B,23,18^FO62,33^FD";
            var TW104 = "^A0B,23,16^FO94,66^FD";
            var TW105 = "^BY2^FO118,43^BAB,67,N,N,N^FD";
            var TW106 = "^A0B,34,34^FO185,93^FD";
            var TW107 = "^A0B,23,18^FO220,39^FD";
            var TW108 = "^A0B,23,18^FO253,46^FD";
            var TW109 = "^A0B,23,18^FO281,240^FD";
            var TW110 = "^A0B,23,18^FO341,303^FD";
            var TW111 = "^A0B,23,20^FO283,52^FD";
            var TW112 = "^A0B,23,18^FO311,238^FD";
            var TW113 = "^A0B,23,18^FO312,56^FD";
            var TW114 = "^A0B,39,40^FO345,65^FD";
            var TW115 = "^A0B,23,18^FO371,318^FD";

            var TW201 = "^A0B,28,18^FO452,43^FD";
            var TW202 = "^A0B,23,20^FO487,186^FD";
            var TW203 = "^A0B,23,18^FO486,33^FD";
            var TW204 = "^A0B,23,16^FO518,66^FD";
            var TW205 = "^BY2^FO542,43^BAB,67,N,N,N^FD";
            var TW206 = "^A0B,34,34^FO609,93^FD";
            var TW207 = "^A0B,23,18^FO644,39^FD";
            var TW208 = "^A0B,23,18^FO676,46^FD";
            var TW209 = "^A0B,23,18^FO705,240^FD";
            var TW210 = "^A0B,23,18^FO764,303^FD";
            var TW211 = "^A0B,23,20^FO706,52^FD";
            var TW212 = "^A0B,23,18^FO735,238^FD";
            var TW213 = "^A0B,23,18^FO735,56^FD";
            var TW214 = "^A0B,39,40^FO768,65^FD";
            var TW215 = "^A0B,23,18^FO794,318^FD";

            var pTEXTO = string.Empty;
            var xStick = 0;
            var xComa = "^FS";

            xStick = xStick + 1;

            foreach (DataRow fila in dt.Rows)
            {
                var xTW01 = string.Empty;
                var xTW02 = string.Empty;
                var xTW03 = string.Empty;
                var xTW04 = string.Empty;
                var xTW05 = string.Empty;
                var xTW06 = string.Empty;
                var xTW07 = string.Empty;
                var xTW08 = string.Empty;
                var xTW09 = string.Empty;
                var xTW10 = string.Empty;
                var xTW11 = string.Empty;
                var xTW12 = string.Empty;
                var xTW13 = string.Empty;
                var xTW14 = string.Empty;
                var xTW15 = string.Empty;

                xTW01 = fila["productid"].ToString() + fila["etiquetaname"].ToString().PadRight(30, ' ').Substring(0, 30).Trim() + xComa;
                xTW02 = "ART: " + fila["subgrupoartic"].ToString().PadRight(10, ' ').Substring(0, 10).Trim() + xComa;
                if (fila["rollolote"].ToString().Trim().Length > 0)
                {
                    xTW03 = "LOTE...: " + fila["rollolote"].ToString().PadRight(10, ' ').Substring(0, 10).Trim() + xComa;
                }
                else
                {
                    xTW03 = string.Empty + xComa;
                }
                if (fila["compo"].ToString().Trim().Length > 0)
                {
                    xTW04 = "COMPOS: " + fila["compo"].ToString().PadRight(10, ' ').Substring(0, 10).Trim() + xComa;
                }
                else
                {
                    xTW04 = string.Empty + xComa;
                }
                fila["rollostock"].ToString().Replace(".", string.Empty);
                xTW05 = fila["rollo"].ToString() + Convert.ToDecimal(fila["rollostock"].ToString().Replace(".", string.Empty)).ToString().Trim().PadLeft(5, '0') + xComa;
                xTW06 = fila["rollo"].ToString() + Convert.ToDecimal(fila["rollostock"].ToString().Replace(".", string.Empty)).ToString().Trim().PadLeft(5, '0') + xComa;
                xTW07 = "PROVE: " + fila["gruponame"].ToString().PadRight(30, ' ').Substring(0, 30).Trim() + xComa;
                xTW08 = "CLIEN: " + VariablesPublicas.EmpresaName.ToString().PadRight(30, ' ').Substring(0, 30).Trim() + xComa;
                xTW09 = "ROLLO: " + fila["rollo"].ToString().Trim() + xComa;
                xTW10 = "ONZAJ: " + fila["titulo"].ToString().Trim() + xComa;
                xTW11 = "MED.INICI: " + Convert.ToDecimal(fila["rollomedcompra"].ToString()).ToString("##0.00").Trim() + xComa;
                xTW12 = "COLOR: " + fila["colorname"].ToString().PadRight(10, ' ').Substring(0, 10).Trim() + xComa;
                xTW13 = "MED.DESPA: " + Convert.ToDecimal(fila["rolloegres"].ToString()).ToString("##0.00").Trim() + xComa;
                xTW14 = Convert.ToDecimal(fila["rollostock"].ToString()).ToString("##0.00").Trim() + xComa;
                xTW15 = DateTime.Today.Date.ToString();

                switch (xStick)
                {
                    case 1:
                        pTEXTO = pTEXTO + X11 + CRTLF;
                        pTEXTO = pTEXTO + X12 + CRTLF;
                        pTEXTO = pTEXTO + X13 + CRTLF;
                        pTEXTO = pTEXTO + X14 + CRTLF;
                        pTEXTO = pTEXTO + X15 + CRTLF;
                        pTEXTO = pTEXTO + X16 + CRTLF;
                        pTEXTO = pTEXTO + X17 + CRTLF;
                        pTEXTO = pTEXTO + X18 + CRTLF;
                        pTEXTO = pTEXTO + X19 + CRTLF;
                        pTEXTO = pTEXTO + X20 + CRTLF;
                        pTEXTO = pTEXTO + X21 + CRTLF;
                        pTEXTO = pTEXTO + X22 + CRTLF;
                        pTEXTO = pTEXTO + X23 + CRTLF;

                        pTEXTO = pTEXTO + TW101 + xTW01 + CRTLF;
                        pTEXTO = pTEXTO + TW102 + xTW02 + CRTLF;
                        pTEXTO = pTEXTO + TW103 + xTW03 + CRTLF;
                        pTEXTO = pTEXTO + TW104 + xTW04 + CRTLF;
                        pTEXTO = pTEXTO + TW105 + xTW05 + CRTLF;
                        pTEXTO = pTEXTO + TW106 + xTW06 + CRTLF;
                        pTEXTO = pTEXTO + TW107 + xTW07 + CRTLF;
                        pTEXTO = pTEXTO + TW108 + xTW08 + CRTLF;
                        pTEXTO = pTEXTO + TW109 + xTW09 + CRTLF;
                        pTEXTO = pTEXTO + TW110 + xTW10 + CRTLF;
                        pTEXTO = pTEXTO + TW111 + xTW11 + CRTLF;
                        pTEXTO = pTEXTO + TW112 + xTW12 + CRTLF;
                        pTEXTO = pTEXTO + TW113 + xTW13 + CRTLF;
                        pTEXTO = pTEXTO + TW114 + xTW14 + CRTLF;
                        pTEXTO = pTEXTO + TW115 + xTW15 + CRTLF;
                        xStick = xStick + 1;
                        break;
                    case 2:
                        pTEXTO = pTEXTO + TW201 + xTW01 + CRTLF;
                        pTEXTO = pTEXTO + TW202 + xTW02 + CRTLF;
                        pTEXTO = pTEXTO + TW203 + xTW03 + CRTLF;
                        pTEXTO = pTEXTO + TW204 + xTW04 + CRTLF;
                        pTEXTO = pTEXTO + TW205 + xTW05 + CRTLF;
                        pTEXTO = pTEXTO + TW206 + xTW06 + CRTLF;
                        pTEXTO = pTEXTO + TW207 + xTW07 + CRTLF;
                        pTEXTO = pTEXTO + TW208 + xTW08 + CRTLF;
                        pTEXTO = pTEXTO + TW209 + xTW09 + CRTLF;
                        pTEXTO = pTEXTO + TW210 + xTW10 + CRTLF;
                        pTEXTO = pTEXTO + TW211 + xTW11 + CRTLF;
                        pTEXTO = pTEXTO + TW212 + xTW12 + CRTLF;
                        pTEXTO = pTEXTO + TW213 + xTW13 + CRTLF;
                        pTEXTO = pTEXTO + TW214 + xTW14 + CRTLF;
                        pTEXTO = pTEXTO + TW215 + xTW15 + CRTLF;

                        pTEXTO = pTEXTO + X44 + CRTLF;
                        pTEXTO = pTEXTO + X55 + CRTLF;
                        pTEXTO = pTEXTO + X66 + CRTLF;
                        pTEXTO = pTEXTO + X77 + CRTLF;
                        pTEXTO = pTEXTO + X88 + CRTLF;
                        pTEXTO = pTEXTO + X99 + CRTLF;


                        xStick = 1;
                        break;
                }
            }
            if (xStick == 2)
            {
                pTEXTO = pTEXTO + X44 + CRTLF;
                pTEXTO = pTEXTO + X55 + CRTLF;
                pTEXTO = pTEXTO + X66 + CRTLF;
                pTEXTO = pTEXTO + X77 + CRTLF;
                pTEXTO = pTEXTO + X88 + CRTLF;
                pTEXTO = pTEXTO + X99 + CRTLF;
            }

            try
            {
                try
                {
                    if (File.Exists(@"C:\\reportebarcode.txt"))
                    {
                        File.Delete(@"C:\\reportebarcode.txt");
                    }

                    var escritor = new StreamWriter(@"C:\\reportebarcode.txt");
                    escritor.WriteLine(pTEXTO);
                    escritor.Close();



                    try
                    {
                        var buffer = new byte[pTEXTO.Length];
                        buffer = System.Text.Encoding.ASCII.GetBytes(pTEXTO);


                        var printer = CreateFile("LPT1:", FileAccess.Write, 0, IntPtr.Zero, FileMode.OpenOrCreate, 0, IntPtr.Zero);
                        if (!printer.IsInvalid)
                        {
                            var lpt1 = new FileStream(printer, FileAccess.ReadWrite);
                            lpt1.Write(buffer, 0, buffer.Length);
                            lpt1.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                catch
                {
                }
            }
            catch
            {
            }
        }
        private void Imprimir_barcode_datamax()
        {
            var BL = new tb_ta_prodrolloBL();
            var BE = new tb_ta_prodrollo();
            var dt = new DataTable();
            if (rollodesde.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese ROLLO DESDE !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (rollohasta.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese ROLLO HASTA !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToInt32(rollohasta.Text) < Convert.ToInt32(rollodesde.Text))
            {
                MessageBox.Show("ROLLO HASTA < ROLLO DESDE !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BE.rollodesde = rollodesde.Text.PadLeft(10, '0');
            BE.rollohasta = rollohasta.Text.PadLeft(10, '0');

            dt = BL.GetAll_codbarra(EmpresaID, BE).Tables[0];


            var CRTLF = Convert.ToString(Equivalencias.Chr(13)) + Convert.ToString(Equivalencias.Chr(10));

            var X11 = Convert.ToString(Equivalencias.Chr(2)) + "qC";
            var X12 = Convert.ToString(Equivalencias.Chr(2)) + "n";
            var X13 = Convert.ToString(Equivalencias.Chr(2)) + "e";
            var X14 = Convert.ToString(Equivalencias.Chr(2)) + "c0000";
            var X15 = Convert.ToString(Equivalencias.Chr(2)) + "RN";
            var X16 = Convert.ToString(Equivalencias.Chr(2)) + "Kf0000";
            var X17 = Convert.ToString(Equivalencias.Chr(2)) + "V0";
            var X18 = Convert.ToString(Equivalencias.Chr(2)) + "M0500";
            var X19 = Convert.ToString(Equivalencias.Chr(2)) + "L";
            var X20 = "A2";
            var X21 = "D11";
            var X22 = "z";
            var X23 = "PD";
            var X24 = "SD";
            var X25 = "H01";

            var X77 = "^01";
            var X88 = "Q0001";
            var X99 = "E";

            var TW101 = "4911S000014002000280018";
            var TW102 = "4911S000014003400230020";
            var TW103 = "4911S000101003400230018";
            var TW104 = "4911S000014005000230016";
            var TW105 = "4o2203400130085";
            var TW106 = "4911S000060009900340034";
            var TW107 = "4911S000014011200230018";
            var TW108 = "4911S000014012800230018";
            var TW109 = "4911S000014014200230018";
            var TW110 = "4911S000014017100230018";
            var TW111 = "4911S000109014300230020";
            var TW112 = "4911S000014015700230018";
            var TW113 = "4911S000109015700230018";
            var TW114 = "4911S000104018000390040";
            var TW115 = "4911S000014018600230018";

            var TW201 = "4911S000014022900280018";
            var TW202 = "4911S000014024300230020";
            var TW203 = "4911S000101024300230018";
            var TW204 = "4911S000014025900230016";
            var TW205 = "4o2203400130294";
            var TW206 = "4911S000060030800340034";
            var TW207 = "4911S000014032100230018";
            var TW208 = "4911S000014033600230018";
            var TW209 = "4911S000014035100230018";
            var TW210 = "4911S000014038000230018";
            var TW211 = "4911S000109035100230020";
            var TW212 = "4911S000014036600230018";
            var TW213 = "4911S000109036600230018";
            var TW214 = "4911S000104038900390040";
            var TW215 = "4911S000014039500230018";


            var pTEXTO = string.Empty;
            var xStick = 0;
            var xComa = string.Empty;

            xStick = xStick + 1;

            foreach (DataRow fila in dt.Rows)
            {
                var xTW01 = string.Empty;
                var xTW02 = string.Empty;
                var xTW03 = string.Empty;
                var xTW04 = string.Empty;
                var xTW05 = string.Empty;
                var xTW06 = string.Empty;
                var xTW07 = string.Empty;
                var xTW08 = string.Empty;
                var xTW09 = string.Empty;
                var xTW10 = string.Empty;
                var xTW11 = string.Empty;
                var xTW12 = string.Empty;
                var xTW13 = string.Empty;
                var xTW14 = string.Empty;
                var xTW15 = string.Empty;

                xTW01 = fila["productid"].ToString() + " " + fila["etiquetaname"].ToString().PadRight(30, ' ').Substring(0, 30).Trim() + xComa;
                xTW02 = "ART: " + fila["subgrupoartic"].ToString().PadRight(10, ' ').Substring(0, 10).Trim() + xComa;
                if (fila["rollolote"].ToString().Trim().Length > 0)
                {
                    xTW03 = "LOTE...: " + fila["rollolote"].ToString().PadRight(10, ' ').Substring(0, 10).Trim() + xComa;
                }
                else
                {
                    xTW03 = string.Empty + xComa;
                }
                if (fila["compo"].ToString().Trim().Length > 0)
                {
                    xTW04 = "COMPOS: " + fila["compo"].ToString().PadRight(10, ' ').Substring(0, 10).Trim() + xComa;
                }
                else
                {
                    xTW04 = string.Empty + xComa;
                }
                fila["rollostock"].ToString().Replace(".", string.Empty);
                xTW05 = fila["rollo"].ToString() + Convert.ToDecimal(fila["rollostock"].ToString().Replace(".", string.Empty)).ToString().Trim().PadLeft(5, '0') + xComa;
                xTW06 = fila["rollo"].ToString() + Convert.ToDecimal(fila["rollostock"].ToString().Replace(".", string.Empty)).ToString("00000").Trim().PadLeft(5, '0') + xComa;
                xTW07 = "PROVE: " + fila["gruponame"].ToString().PadRight(30, ' ').Substring(0, 30).Trim() + xComa;
                xTW08 = "CLIEN: " + VariablesPublicas.EmpresaName.ToString().PadRight(30, ' ').Substring(0, 30).Trim() + xComa;
                xTW09 = "ROLLO: " + fila["rollo"].ToString().Trim() + xComa;
                xTW10 = "ONZAJ: " + fila["titulo"].ToString().Trim() + xComa;
                xTW11 = "MED.INICI: " + Convert.ToDecimal(fila["rollomedcompra"].ToString()).ToString("##0.00").Trim() + xComa;
                xTW12 = "COLOR: " + fila["colorname"].ToString().PadRight(10, ' ').Substring(0, 10).Trim() + xComa;
                xTW13 = "MED.DESPA: " + Convert.ToDecimal(fila["rolloegres"].ToString()).ToString("##0.00").Trim() + xComa;
                xTW14 = Convert.ToDecimal(fila["rollostock"].ToString()).ToString("##0.00").Trim() + xComa;
                xTW15 = DateTime.Today.Date.ToString().Substring(0, 10);

                switch (xStick)
                {
                    case 1:
                        pTEXTO = pTEXTO + X11 + CRTLF;
                        pTEXTO = pTEXTO + X12 + CRTLF;
                        pTEXTO = pTEXTO + X13 + CRTLF;
                        pTEXTO = pTEXTO + X14 + CRTLF;
                        pTEXTO = pTEXTO + X15 + CRTLF;
                        pTEXTO = pTEXTO + X16 + CRTLF;
                        pTEXTO = pTEXTO + X17 + CRTLF;
                        pTEXTO = pTEXTO + X18 + CRTLF;
                        pTEXTO = pTEXTO + X19 + CRTLF;
                        pTEXTO = pTEXTO + X20 + CRTLF;
                        pTEXTO = pTEXTO + X21 + CRTLF;
                        pTEXTO = pTEXTO + X22 + CRTLF;
                        pTEXTO = pTEXTO + X23 + CRTLF;
                        pTEXTO = pTEXTO + X24 + CRTLF;
                        pTEXTO = pTEXTO + X25 + CRTLF;

                        pTEXTO = pTEXTO + TW101 + xTW01 + CRTLF;
                        pTEXTO = pTEXTO + TW102 + xTW02 + CRTLF;
                        pTEXTO = pTEXTO + TW103 + xTW03 + CRTLF;
                        pTEXTO = pTEXTO + TW104 + xTW04 + CRTLF;
                        pTEXTO = pTEXTO + TW105 + xTW05 + CRTLF;
                        pTEXTO = pTEXTO + TW106 + xTW06 + CRTLF;
                        pTEXTO = pTEXTO + TW107 + xTW07 + CRTLF;
                        pTEXTO = pTEXTO + TW108 + xTW08 + CRTLF;
                        pTEXTO = pTEXTO + TW109 + xTW09 + CRTLF;
                        pTEXTO = pTEXTO + TW110 + xTW10 + CRTLF;
                        pTEXTO = pTEXTO + TW111 + xTW11 + CRTLF;
                        pTEXTO = pTEXTO + TW112 + xTW12 + CRTLF;
                        pTEXTO = pTEXTO + TW113 + xTW13 + CRTLF;
                        pTEXTO = pTEXTO + TW114 + xTW14 + CRTLF;
                        pTEXTO = pTEXTO + TW115 + xTW15 + CRTLF;
                        xStick = xStick + 1;
                        break;
                    case 2:
                        pTEXTO = pTEXTO + TW201 + xTW01 + CRTLF;
                        pTEXTO = pTEXTO + TW202 + xTW02 + CRTLF;
                        pTEXTO = pTEXTO + TW203 + xTW03 + CRTLF;
                        pTEXTO = pTEXTO + TW204 + xTW04 + CRTLF;
                        pTEXTO = pTEXTO + TW205 + xTW05 + CRTLF;
                        pTEXTO = pTEXTO + TW206 + xTW06 + CRTLF;
                        pTEXTO = pTEXTO + TW207 + xTW07 + CRTLF;
                        pTEXTO = pTEXTO + TW208 + xTW08 + CRTLF;
                        pTEXTO = pTEXTO + TW209 + xTW09 + CRTLF;
                        pTEXTO = pTEXTO + TW210 + xTW10 + CRTLF;
                        pTEXTO = pTEXTO + TW211 + xTW11 + CRTLF;
                        pTEXTO = pTEXTO + TW212 + xTW12 + CRTLF;
                        pTEXTO = pTEXTO + TW213 + xTW13 + CRTLF;
                        pTEXTO = pTEXTO + TW214 + xTW14 + CRTLF;
                        pTEXTO = pTEXTO + TW215 + xTW15 + CRTLF;

                        pTEXTO = pTEXTO + X77 + CRTLF;
                        pTEXTO = pTEXTO + X88 + CRTLF;
                        pTEXTO = pTEXTO + X99 + CRTLF;


                        xStick = 1;
                        break;
                }
            }
            if (xStick == 2)
            {
                pTEXTO = pTEXTO + X77 + CRTLF;
                pTEXTO = pTEXTO + X88 + CRTLF;
                pTEXTO = pTEXTO + X99 + CRTLF;
            }

            try
            {
                if (File.Exists(@"C:\\reportebarcode.txt"))
                {
                    File.Delete(@"C:\\reportebarcode.txt");
                }

                var escritor = new StreamWriter(@"C:\\reportebarcode.txt");
                escritor.WriteLine(pTEXTO);
                escritor.Close();

                try
                {
                    var buffer = new byte[pTEXTO.Length];
                    buffer = System.Text.Encoding.ASCII.GetBytes(pTEXTO);


                    var printer = CreateFile("LPT1:", FileAccess.Write, 0, IntPtr.Zero, FileMode.OpenOrCreate, 0, IntPtr.Zero);
                    if (!printer.IsInvalid)
                    {
                        var lpt1 = new FileStream(printer, FileAccess.ReadWrite);
                        lpt1.Write(buffer, 0, buffer.Length);
                        lpt1.Close();
                    }
                }
                catch (Exception ex)
                {
                }
            }
            catch
            {
            }
        }
        public static void ReceiveCallback(IAsyncResult AsyncCall)
        {
            var encoding = new System.Text.ASCIIEncoding();
            var message = encoding.GetBytes("I am a little busy, come back later!");

            var listener = (Socket)AsyncCall.AsyncState;
            var client = listener.EndAccept(AsyncCall);

            Console.WriteLine("Received Connection from {0}", client.RemoteEndPoint);
            client.Send(message);

            Console.WriteLine("Ending the connection");
            client.Close();

            listener.BeginAccept(new AsyncCallback(ReceiveCallback), listener);
        }
    }
}
