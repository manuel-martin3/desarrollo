using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using bapFunciones;
using LayerBusinessEntities;
using LayerBusinessLogic;

namespace BapFormulariosNet.APT600100.REPORTES
{
    public partial class Frm_RequerimientoOC2 : plantilla
    {
        private String EmpresaID = string.Empty;
        private String dominio = "L0";
        private String modulo = string.Empty;
        private String moduloid = string.Empty;
        private String local = string.Empty;
        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;
        private String dominioiddes = "60";
        private TextBox txtCDetalle = null;
        private DataTable Tabladetalleocompra = new DataTable("detallecompra");

        public Frm_RequerimientoOC2()
        {
            InitializeComponent();
        }



        private void PARAMETROS_TABLA()
        {
            var xxferfil = string.Empty;
            var f = (D60ALMACEN.MainAlmacen)MdiParent;
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

        private void btn_detanadir_Click(object sender, EventArgs e)
        {
            try
            {
                if (XNIVEL == "0")
                {
                    if (griddetalleocompra.Enabled)
                    {
                        if (griddetalleocompra.Rows.Count > 0)
                        {
                            var xcantidad = Convert.ToString(griddetalleocompra.CurrentRow.Cells["cantidad"].Value);

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

                            dgb_requerimiento.SetRowCellValue(0, "productid", string.Empty);
                            dgb_requerimiento.FocusedColumn = dgb_requerimiento.Columns[1];
                            dgb_requerimiento.ShowEditor();


                            btn_imprimir.Enabled = true;
                        }
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Frm_Orden_compra_Load(object sender, EventArgs e)
        {
            moduloid =   VariablesPublicas.Moduloid.Trim();
            EmpresaID = VariablesPublicas.EmpresaID.Trim();
            PARAMETROS_TABLA();
            NIVEL_FORMS();

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
                gridControl1.DataSource = Tabladetalleocompra;
            }

            form_bloqueado(false);
            limpiar_documento();
        }

        private void limpiar_documento()
        {
            try
            {
                lineaid.Text = string.Empty;
                lblmensaje.Text = string.Empty;
                grupoid.Text = string.Empty;
                subgrupoid.Text = string.Empty;
                txtobs.Text = string.Empty;
                subgrupoid.Focus();
                subgruponame.Text = string.Empty;
                _item.Text = string.Empty;
                _productid.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                        if (moduloid == "0500")
                        {
                            frmayuda.sqlwhere = "where tb1.status = '0'  and tb1.nserie = ' ' ";
                        }
                        else
                        {
                            frmayuda.sqlwhere = "where tb1.status = '0' ";
                        }
                        frmayuda.sqland = "and";
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
                            griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["obs"].Value = txtobs.Text;
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
            lineaid.Enabled = false;
            grupoid.Enabled = false;
            subgrupoid.Enabled = var;
            txtobs.Enabled = var;
            subgrupoid.Focus();
            subgruponame.Enabled = false;
            _item.Enabled = false;
            _productid.Enabled = false;

            btn_detanadir.Enabled = var;
            btn_agregar.Enabled = false;
            btn_generar.Enabled = var;
            btn_del.Enabled = var;
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
                limpiar_documento();
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

        private void subgrupoid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Ayudasubgrupo(string.Empty);
            }
            ValidaSubgrupo();
            get_nuevo_producto();
        }


        private void ValidaSubgrupo()
        {
            if (subgrupoid.Text.Trim().Length > 0 && lineaid.Text.Trim().Length == 3 && grupoid.Text.Trim().Length == 4)
            {
                var BL = new tb_60subgrupoBL();
                var BE = new tb_60subgrupo();
                var dt = new DataTable();

                BE.moduloid = VariablesPublicas.Moduloid;
                BE.lineaid = lineaid.Text.Trim().PadLeft(3, '0');
                BE.grupoid = grupoid.Text.Trim().PadLeft(4, '0');
                BE.subgrupoid = subgrupoid.Text.Trim().PadLeft(3, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    lineaid.Text = dt.Rows[0]["lineaid"].ToString().Trim();
                    grupoid.Text = dt.Rows[0]["grupoid"].ToString().Trim();
                    subgrupoid.Text = dt.Rows[0]["subgrupoid"].ToString().Trim();
                    subgruponame.Text = dt.Rows[0]["subgruponame"].ToString().Trim();
                }
                else
                {
                    lineaid.Text = string.Empty;
                    grupoid.Text = string.Empty;
                    subgrupoid.Text = string.Empty;
                    subgruponame.Text = string.Empty;
                }
            }
            else
            {
                lineaid.Text = string.Empty;
                grupoid.Text = string.Empty;
                subgrupoid.Text = string.Empty;
                subgruponame.Text = string.Empty;
            }
        }


        private void get_nuevo_producto()
        {
            var BL = new tb_60productosBL();
            var BE = new tb_60productos();
            var DT = new DataTable();
            BE.moduloid = moduloid;
            BE.lineaid = lineaid.Text.Trim();
            BE.grupoid = grupoid.Text.Trim();
            BE.subgrupoid = subgrupoid.Text.Trim();
            DT = BL.GetAll_nuevocodprod(EmpresaID, BE).Tables[0];
            try
            {
                _item.Text = Convert.ToString(Convert.ToInt16(DT.Rows[0]["item"].ToString().Substring(10, 3)) + 1).PadLeft(3, '0');
                _productid.Text = lineaid.Text + grupoid.Text + subgrupoid.Text + _item.Text;
            }
            catch
            {
                _item.Text = "000";
                _productid.Text = lineaid.Text + grupoid.Text + subgrupoid.Text + _item.Text;
            }

            if (_productid.Text.Trim().Length == 13)
            {
                form_bloqueado(true);

                btn_cancelar.Enabled = true;
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

                BE.dominioid = dominio;
                BE.moduloid = modulo;
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();

                        var frmayuda = new Ayudas.Frm_help_general();

                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA TABLA ARTICULO >>";
                        frmayuda.sqlquery = "SELECT (lineaid + gr.grupoid + subgrupoid) as Codigo,lineaid,gr.grupoid,g.gruponame,subgrupoid,subgruponame,g.ctacte  FROM tb_sm_subgrupo gr ";
                        if (modd == "sm")
                        {
                            frmayuda.sqlinner = " Inner Join tb_sm_grupo g on gr.grupoid = g.grupoid and status = '0' ";
                        }
                        else
                        {
                            frmayuda.sqlinner = " Inner Join tb_sm_grupo g on gr.grupoid = g.grupoid ";
                        }

                        if (lineaid.Text.Trim().Length > 0 && grupoid.Text.Trim().Length > 0)
                        {
                            frmayuda.sqlwhere = "where lineaid = " + lineaid.Text + " and gr.grupoid = " + grupoid.Text + " ";
                            frmayuda.sqland = "and";
                        }
                        else
                        {
                            if (lineaid.Text.Trim().Length > 0)
                            {
                                frmayuda.sqlwhere = "where lineaid = " + lineaid.Text + " ";
                                frmayuda.sqland = "and";
                            }
                            else
                            {
                                if (grupoid.Text.Trim().Length > 0)
                                {
                                    frmayuda.sqlwhere = "where gr.grupoid = " + grupoid.Text + " ";
                                    frmayuda.sqland = "and";
                                }
                                else
                                {
                                    frmayuda.sqlwhere = "where";
                                    frmayuda.sqland = string.Empty;
                                }
                            }
                        }
                        frmayuda.criteriosbusqueda = new string[] { "ARTICULO", "CODIGO" };
                        frmayuda.columbusqueda = "subgruponame,lineaid + gr.grupoid + subgrupoid";
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
                lineaid.Text = resultado1.Trim();
                grupoid.Text = resultado2.Trim();
                subgrupoid.Text = resultado3.Trim();
            }
        }

        private void btn_generar_Click(object sender, EventArgs e)
        {
            if (_productid.Text == string.Empty)
            {
                lblmensaje.Text = "»» Falta Codigo ««";
                return;
            }
            else
            {
                var sw_prosigue = false;
                sw_prosigue = (MessageBox.Show("¿Desea Generar Codigo ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
                if (sw_prosigue)
                {
                    Insert();
                    btn_generar.Enabled = false;
                    btn_agregar.Enabled = true;
                    btn_agregar_Click(sender, e);
                }
            }
        }


        private void Insert()
        {
            try
            {
                var BL = new tb_60productosBL();
                var BE = new tb_60productos();
                BE.moduloid = VariablesPublicas.Moduloid;
                BE.lineaid = lineaid.Text.Trim();
                BE.grupoid = grupoid.Text.Trim();
                BE.subgrupoid = subgrupoid.Text.Trim();
                BE.item = _item.Text.Trim();
                BE.moneda = "S";
                BE.productid = _productid.Text.Trim();
                BE.productname = subgruponame.Text.Trim().ToUpper();
                BE.productidold = "0";
                BE.unmed = "UND";
                BE.unmedenvase = "UND";
                BE.procedenciaid = "0";
                BE.unidenvase = 1;
                BE.status = "0";
                BE.usuar = VariablesPublicas.Usuar.Trim();
                var ms = new System.IO.MemoryStream();
                BE.Foto = ms.GetBuffer();

                if (BL.Insert(EmpresaID, BE))
                {
                    lblmensaje.Text = "»» Datos Generados Correctamente ««";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if (griddetalleocompra.Enabled)
            {
                if (griddetalleocompra.Rows.Count > 0)
                {
                    Convert.ToString(griddetalleocompra.CurrentRow.Cells["cantidad"].Value);
                    if (griddetalleocompra.Rows[griddetalleocompra.RowCount - 1].Cells["productid"].Value.ToString().Trim().Length > 0)
                    {
                        griddetalleocompra.Rows[griddetalleocompra.RowCount - 1].Cells["productid"].Value.ToString();
                        griddetalleocompra.Rows[griddetalleocompra.RowCount - 1].Cells["productname"].Value.ToString();
                        Tabladetalleocompra.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetalleocompra));
                        Tabladetalleocompra.Rows[Tabladetalleocompra.Rows.Count - 1]["items"] = VariablesPublicas.CalcMaxField(Tabladetalleocompra, "items", 5);

                        griddetalleocompra.CurrentCell = griddetalleocompra.Rows[griddetalleocompra.RowCount - 1].Cells["productid"];
                        griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["productid"].Value = _productid.Text;
                        griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["productname"].Value = subgruponame.Text;
                        griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["stock"].Value = "0";
                        griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["unmedenvase"].Value = "UND";
                        btn_imprimir.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Ingrese producto !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Tabladetalleocompra.Rows.Add(VariablesPublicas.InsertIntoTable(Tabladetalleocompra));
                    Tabladetalleocompra.Rows[Tabladetalleocompra.Rows.Count - 1]["items"] = VariablesPublicas.CalcMaxField(Tabladetalleocompra, "items", 5);
                    griddetalleocompra.CurrentCell = griddetalleocompra.Rows[griddetalleocompra.RowCount - 1].Cells["productid"];
                    griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["productid"].Value = _productid.Text;
                    griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["productname"].Value = subgruponame.Text;
                    griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["stock"].Value = "0";
                    griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["unmedenvase"].Value = "UND";
                    btn_imprimir.Enabled = true;
                }
            }

            limpiar_documento();
            btn_generar.Enabled = true;
            btn_agregar.Enabled = false;
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            var lc_cont = 0;
            var xcoditem = string.Empty;
            var _productid = string.Empty;
            if ((griddetalleocompra.CurrentRow != null))
            {
                xcoditem = griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["item"].Value.ToString();
                _productid = griddetalleocompra.Rows[griddetalleocompra.CurrentCell.RowIndex].Cells["productid"].Value.ToString();

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

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    if (dgb_requerimiento.FocusedColumn == dgb_requerimiento.Columns[1])
                    {
                        AyudaProducto(string.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgb_requerimiento_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    if (dgb_requerimiento.FocusedColumn == dgb_requerimiento.Columns[1])
                    {
                        AyudaProducto(string.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
