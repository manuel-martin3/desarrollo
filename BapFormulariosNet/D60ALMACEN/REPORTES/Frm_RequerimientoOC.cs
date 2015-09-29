using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using bapFunciones;
using LayerBusinessEntities;
using LayerBusinessLogic;

namespace BapFormulariosNet.D60ALMACEN.REPORTES
{
    public partial class Frm_RequerimientoOC : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID.ToString();
        private String modulo = string.Empty;
        private String moduloid = string.Empty;
        private String dominioiddes = "60";
        private TextBox txtCDetalle = null;
        private DataTable Tabladetalleocompra = new DataTable("detallecompra");

        public Frm_RequerimientoOC()
        {
            InitializeComponent();
        }

        private void btn_detanadir_Click(object sender, EventArgs e)
        {
            try
            {
                if (griddetalleocompra.Enabled)
                {
                    if (griddetalleocompra.Rows.Count > 0)
                    {
                        var  xcantidad = Convert.ToString(griddetalleocompra.CurrentRow.Cells["cantidad"].Value);
                        if (xcantidad != "0" && xcantidad != string.Empty)
                        {
                            if (griddetalleocompra.Rows[griddetalleocompra.RowCount - 1].Cells["productid"].Value.ToString().Trim().Length > 0)
                            {
                                griddetalleocompra.Rows[griddetalleocompra.RowCount - 1].Cells["productid"].Value.ToString();
                                griddetalleocompra.Rows[griddetalleocompra.RowCount - 1].Cells["productname"].Value.ToString();
                                Tabladetalleocompra.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetalleocompra));
                                Tabladetalleocompra.Rows[Tabladetalleocompra.Rows.Count - 1]["items"] = VariablesPublicas.CalcMaxField(Tabladetalleocompra, "items", 5);

                                griddetalleocompra.CurrentCell = griddetalleocompra.Rows[griddetalleocompra.RowCount - 1].Cells["productid"];
                                griddetalleocompra.BeginEdit(true);
                                btn_imprimir.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("Ingrese producto !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ingrese Cantidad  !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        Tabladetalleocompra.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetalleocompra));
                        Tabladetalleocompra.Rows[Tabladetalleocompra.Rows.Count - 1]["items"] = VariablesPublicas.CalcMaxField(Tabladetalleocompra, "items", 5);
                        griddetalleocompra.CurrentCell = griddetalleocompra.Rows[griddetalleocompra.RowCount - 1].Cells["productid"];
                        griddetalleocompra.BeginEdit(true);
                        btn_imprimir.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_Orden_compra_Load(object sender, EventArgs e)
        {
            moduloid = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;


            Tabladetalleocompra = new DataTable("detallocompra");
            Tabladetalleocompra.Columns.Add("items", typeof(String));
            Tabladetalleocompra.Columns.Add("productid", typeof(String));
            Tabladetalleocompra.Columns.Add("productname", typeof(String));
            Tabladetalleocompra.Columns.Add("Stock", typeof(Decimal));
            Tabladetalleocompra.Columns["stock"].DefaultValue = 0;
            Tabladetalleocompra.Columns.Add("unmedenvase", typeof(String));
            Tabladetalleocompra.Columns["unmedenvase"].DefaultValue = string.Empty;
            Tabladetalleocompra.Columns.Add("Cantidad", typeof(Decimal));
            if (Tabladetalleocompra != null)
            {
                Tabladetalleocompra.Rows.Clear();
                griddetalleocompra.DataSource = Tabladetalleocompra;
            }

            form_bloqueado(false);
        }

        private void AyudaProducto(String lpdescrlike)
        {
            try
            {
                var modd = string.Empty;
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();

                BE.dominioid = dominioiddes.Trim();
                BE.moduloid = moduloid;
                dt = BL.GetAll(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();

                        var frmayuda = new Ayudas.Form_help_requerimiento();

                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA  TABLA PRODUCTOS >>";
                        frmayuda.sqlquery = "SELECT tb1.productid, tb1.productname, tb2.stock, tb1.unmedenvase as unmedenvase ,tb2.costoultimo  FROM tb_" + modd + "_productos AS tb1 ";
                        frmayuda.sqlinner = "inner join tb_" + modd + "_local_stock as tb2 on tb1.productid = tb2.productid ";
                        frmayuda.sqlwhere = "where ";
                        frmayuda.sqland = string.Empty;
                        frmayuda.criteriosbusqueda = new string[] { "PRODUCTO", "CODIGO" };
                        frmayuda.columbusqueda = "tb1.productname,tb1.productid";
                        frmayuda.returndatos = "0,1,2,3";

                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeProducto;
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RecibeProducto(DataTable dtresultado)
        {
            try
            {
                if (dtresultado.Rows.Count > 0)
                {
                    var cont = 0;
                    foreach (DataRow fila in dtresultado.Rows)
                    {
                        cont = cont + 1;
                        if (griddetalleocompra.Rows.Count > 0)
                        {
                            var nFilaAnt = griddetalleocompra.RowCount - 1;
                            var xProductid = fila["productid"].ToString();
                            var xProductname = fila["productname"].ToString();
                            ;
                            var xstock = fila["stock"].ToString();
                            var xUM = fila["unmedenvase"].ToString();
                            if (cont > 1)
                            {
                                Tabladetalleocompra.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetalleocompra));
                                Tabladetalleocompra.Rows[griddetalleocompra.Rows.Count - 1]["items"] = VariablesPublicas.CalcMaxField(Tabladetalleocompra, "items", 5);
                                griddetalleocompra.Rows[nFilaAnt + 1].Cells["productid"].Value = xProductid;
                                griddetalleocompra.Rows[nFilaAnt + 1].Cells["productname"].Value = xProductname;
                                griddetalleocompra.Rows[nFilaAnt + 1].Cells["stock"].Value = xstock;
                                griddetalleocompra.Rows[nFilaAnt + 1].Cells["unmedenvase"].Value = xUM;
                            }
                            else
                            {
                                griddetalleocompra.Rows[nFilaAnt].Cells["productid"].Value = xProductid;
                                griddetalleocompra.Rows[nFilaAnt].Cells["productname"].Value = xProductname;
                                griddetalleocompra.Rows[nFilaAnt].Cells["stock"].Value = xstock;
                                griddetalleocompra.Rows[nFilaAnt].Cells["unmedenvase"].Value = xUM;
                            }
                            griddetalleocompra.CurrentCell = griddetalleocompra.Rows[griddetalleocompra.RowCount - 1].Cells["cantidad"];
                            griddetalleocompra.BeginEdit(true);
                            btn_deteliminar.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Tabladetalleocompra.Rows.Count > 0)
                {
                    String xproductid, xcantidad;
                    xproductid = Convert.ToString(griddetalleocompra.CurrentRow.Cells["productid"].Value);
                    xcantidad = Convert.ToString(griddetalleocompra.CurrentRow.Cells["cantidad"].Value);
                    if (xproductid != string.Empty)
                    {
                        if (xcantidad != "0" && xcantidad != string.Empty)
                        {
                            var miForma = new REPORTES.Frm_reportes();
                            miForma.Text = "Reporte Orden de Compra";
                            miForma.formulario = "Frm_requerimiento";
                            miForma.Table = Tabladetalleocompra;
                            miForma.moduloid = modulo.ToString();
                            miForma.Show();
                        }
                        else
                        {
                            MessageBox.Show("Ingrese Cantidad", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            griddetalleocompra.CurrentCell = griddetalleocompra.Rows[griddetalleocompra.RowCount - 1].Cells["cantidad"];
                            griddetalleocompra.BeginEdit(true);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese Producto", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese Producto", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_Orden_compra_Activated(object sender, EventArgs e)
        {
        }

        private void Frm_Orden_compra_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btn_cancelar.Enabled)
            {
                MessageBox.Show("Finalice edición para cerrar formulario", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void griddetalleocompra_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    if ((griddetalleocompra.CurrentCell != null))
                    {
                        if (griddetalleocompra.CurrentCell.ReadOnly == false)
                        {
                            if (griddetalleocompra.Columns[griddetalleocompra.CurrentCell.ColumnIndex].Name.ToUpper() == "productid".ToUpper())
                            {
                                AyudaProducto(string.Empty);
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

        private void btn_deteliminar_Click(object sender, EventArgs e)
        {
            var lc_cont = 0;
            var xcoditem = string.Empty;
            if ((griddetalleocompra.CurrentRow != null))
            {
                xcoditem = griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["item"].Value.ToString();
                for (lc_cont = 0; lc_cont <= griddetalleocompra.Rows.Count - 1; lc_cont++)
                {
                    if (Tabladetalleocompra.Rows[lc_cont]["items"].ToString() == xcoditem)
                    {
                        Tabladetalleocompra.Rows[lc_cont].Delete();
                        Tabladetalleocompra.AcceptChanges();
                        break;
                    }
                }
                for (lc_cont = 0; lc_cont <= Tabladetalleocompra.Rows.Count - 1; lc_cont++)
                {
                    Tabladetalleocompra.Rows[lc_cont]["items"] = VariablesPublicas.PADL(Convert.ToString(lc_cont + 1), 5, "0");
                }
                if (Tabladetalleocompra.Rows.Count == 0)
                {
                    btn_deteliminar.Enabled = false;
                }
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quieres cerrar el formulario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void form_bloqueado(Boolean var)
        {
            btn_detanadir.Enabled = var;
            btn_cancelar.Enabled = var;
            btn_detanadir.Enabled = var;
            btn_deteliminar.Enabled = var;
            btn_cancelar.Enabled = var;
            btn_imprimir.Enabled = false;
            griddetalleocompra.ReadOnly = !var;
            griddetalleocompra.Columns["item"].ReadOnly = true;
            griddetalleocompra.Columns["productname"].ReadOnly = true;
            griddetalleocompra.Columns["stock"].ReadOnly = true;
            griddetalleocompra.Columns["unmedenvase"].ReadOnly = true;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            form_bloqueado(true);
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            cancelar(1);
        }

        private void cancelar(int confirmar)
        {
            var sw_prosigue = true;
            if (confirmar == 1)
            {
                sw_prosigue = (MessageBox.Show("Desea cancelar ingreso de datos...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
            }
            else
            {
                sw_prosigue = true;
            }
            if (sw_prosigue)
            {
                form_bloqueado(false);
                var dt = griddetalleocompra.DataSource as DataTable;
                if (dt.Rows.Count > 0)
                {
                    dt.Rows.Clear();
                }
            }
        }

        private void griddetalleocompra_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (VariablesPublicas.PulsaAyudaArticulos)
                {
                    if (griddetalleocompra.Columns[griddetalleocompra.CurrentCell.ColumnIndex].Name.ToUpper() == "productid".ToUpper())
                    {
                        AyudaProducto(string.Empty);
                    }
                    VariablesPublicas.PulsaAyudaArticulos = false;
                    Tabladetalleocompra.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void griddetalleocompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void griddetalleocompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                var cantidad = griddetalleocompra.Columns[griddetalleocompra.CurrentCell.ColumnIndex].Name.ToUpper() == "cantidad".ToUpper();

                if (cantidad)
                {
                    griddetalleocompra.CurrentRow.ReadOnly = true;
                }
            }
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

        private void griddetalleocompra_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (griddetalleocompra.Columns[griddetalleocompra.CurrentCell.ColumnIndex].Name.ToUpper() == "productid".ToUpper())
            {
                txtCDetalle = (TextBox)e.Control;
                txtCDetalle.MaxLength = 13;
                txtCDetalle.CharacterCasing = CharacterCasing.Upper;
                txtCDetalle.Text.Trim();
                e.Control.KeyDown += CapturarTeclaGRID;
            }
        }

        private void griddetalleocompra_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            griddetalleocompra[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            griddetalleocompra[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            griddetalleocompra.EnableHeadersVisualStyles = false;
            griddetalleocompra.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            griddetalleocompra.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void griddetalleocompra_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            griddetalleocompra[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }

        private void Frm_RequerimientoOC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                if (!griddetalleocompra.ReadOnly)
                {
                    btn_detanadir_Click(sender, e);
                }
            }

            if (e.KeyCode == Keys.Delete)
            {
                if (!griddetalleocompra.ReadOnly)
                {
                    btn_deteliminar_Click(sender, e);
                }
            }
        }
    }
}
