//*****************************************************************
// AUTOR    : Angel Galarza
// Objetivo : Selecciona Parte Ingreso Almacén/Registrar en Reg.Compras
// Módulo   : ALMACENES
// Updated  : 01.10.2012
//*****************************************************************
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
using BapFormulariosNet.D20Comercial.Ayudas;
using BapFormulariosNet.Ayudas;
using BapFormulariosNet.Codigo;
using DevExpress.XtraEditors;

namespace BapFormulariosNet.D20Comercial.Ayudas
{
    public partial class Frm_AyudaParteingresoalmacen : plantilla
    {
        public delegate void SeleccionaOrdenes(DataTable DataClonada, bool zselecciona);
        bool sw_load = true;
        string j_String = "";
        DataTable tmptabla = new DataTable();
        DataTable pcgtabla = new DataTable();
        string j_Almacen = "";
        bool sw_novaluechange = false;
        // Parámetros
        public string _CodDetalle = "";
        public string _Ruc = "";
        public string _Almacen = "";
        public SeleccionaOrdenes PasarMovimiento;
        private DataTable dw = new DataTable();
        public bool _DesactivaDetalle = false;
        int lc_cont;

        public Frm_AyudaParteingresoalmacen()
        {
            InitializeComponent();
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            //DevExpress.Skins.SkinManager.EnableFormSkins();

            Load += Frm_AyudaParteingresoalmacen_Load;
            KeyDown += Frm_AyudaParteingresoalmacen_KeyDown;
            Activated += Frm_AyudaParteingresoalmacen_Activated;

            txtRuc.LostFocus += new System.EventHandler(txtRuc_LostFocus);
            txtRuc.GotFocus += new System.EventHandler(txtRuc_GotFocus);

            txtTipdoc.LostFocus += new System.EventHandler(txtTipdoc_LostFocus);
            txtTipdoc.GotFocus += new System.EventHandler(txtTipdoc_GotFocus);

            txtSerdoc.LostFocus += new System.EventHandler(txtSerdoc_LostFocus);

            txtNumdoc.LostFocus += new System.EventHandler(txtNumdoc_LostFocus);

            txtcodalmacen.LostFocus += new System.EventHandler(txtcodalmacen_LostFocus);
            txtcodalmacen.GotFocus += new System.EventHandler(txtcodalmacen_GotFocus);           
        }

        private void Frm_AyudaParteingresoalmacen_Activated(object sender, EventArgs e)
        {
            if (sw_load)
            {
                tb_co_tabla10_comprobantesBL BL = new tb_co_tabla10_comprobantesBL();
                tb_co_tabla10_comprobantes BE = new tb_co_tabla10_comprobantes();

                BE.codigoid = "09";
                tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (BL.Sql_Error.Length == 0)
                {
                    if (tmptabla.Rows.Count > 0)
                    {
                        txtTipdoc.Text = tmptabla.Rows[0]["codigoid"].ToString();
                        txtdtipdoc.Text = tmptabla.Rows[0]["descripcion"].ToString();
                    }
                }
                LlenarGridMovimientoAlmacen();
                sw_load = false;
                GridMovimientoAlmacen.Focus();
                if (GridMovimientoAlmacen.RowCount > 0)
                {
                    GridMovimientoAlmacen.BeginEdit(true);
                }
            }
        }
        private void Frm_AyudaParteingresoalmacen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCerrar_Click(sender, e);
            }
            if (e.KeyCode == Keys.F5)
            {
                btnRefrescar_Click(sender, e);
            }
        }
        private void Frm_AyudaParteingresoalmacen_Load(object sender, EventArgs e)
        {
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            //DevExpress.Skins.SkinManager.EnableFormSkins();

            if (!(DateTime.Now.Month == 1))
            {
                Fecha1.Value = Convert.ToDateTime("01/" + Convert.ToInt16(DateTime.Now.Month - 1).ToString().PadLeft(2, '0') + "/" + VariablesPublicas.perianio);
            }
            else
            {
                Fecha1.Value = Convert.ToDateTime("01/01/" + VariablesPublicas.perianio);
            }
            if (_CodDetalle.Trim().Length > 0)
            {
                chkdetalle.Checked = true;
                txtCtacte.Text = _CodDetalle;
                txtRuc.Text = _Ruc;

                Fecha1.Value = Convert.ToDateTime("01/01/" + VariablesPublicas.perianio);
            }
            if (_Almacen.Trim().Length > 0)
            {
                chkalmacen.Checked = true;
                txtcodalmacen.Text = _Almacen;
                ValidaAlmacen();
            }
            U_RefrescaControles();
            VariablesPublicas.PintaEncabezados(GridMovimientoAlmacen);
        }

        public void LlenarGridMovimientoAlmacen()
        {
            btnRefrescar.Enabled = false;
            string xfecha1 = "";
            string xfecha2 = "";
            string xalmacen = "";
            string xctacte = "";
            string xtipdoc = ""; string xserdoc = ""; string xnumdoc = "";
            
            if (Fecha1.Enabled)
            { xfecha1 = VariablesPublicas.DTOS(Fecha1.Value); }
            if (fecha2.Enabled)
            { xfecha2 = VariablesPublicas.DTOS(fecha2.Value); }

            if (txtCtacte.Text.Trim().Length > 0)
            {
                xctacte = txtCtacte.Text;
                ValidaProveedor();
            }

            if (txtSerdoc.Enabled)
            { xserdoc = txtSerdoc.Text.Trim(); }
            if (txtNumdoc.Enabled)
            { xnumdoc = txtNumdoc.Text.Trim(); }

            if (txtcodalmacen.Enabled)
            {
                xalmacen = txtcodalmacen.Text;
            }
            tb_co_ComprasBL BL = new tb_co_ComprasBL();
            tb_co_Compras BE = new tb_co_Compras();

            BE.almacen = xalmacen;
            BE.fechaini = xfecha1;
            BE.fechafin = xfecha2;
            BE.ctacte = xctacte;
            BE.tipodoc = xtipdoc;
            BE.numdoc = (xserdoc.Trim().Length > 0 & xnumdoc.Trim().Length > 0 ? xserdoc.Trim() + "-" + xnumdoc.Trim() : xserdoc.Trim());
            dw = BL.GenPendienteNIAtoRCompra(VariablesPublicas.EmpresaID, BE).Tables[0];
            if (BL.Sql_Error.Length > 0)
            {
                sw_load = false;
                Frm_Class.ShowError(BL.Sql_Error, this);
                return;
            }
            SortOrder sorted = default(SortOrder);
            string xnomcolumna = "";
            if ((GridMovimientoAlmacen.SortedColumn != null))
            {
                xnomcolumna = GridMovimientoAlmacen.Columns[GridMovimientoAlmacen.SortedColumn.Index].Name;
                sorted = GridMovimientoAlmacen.SortOrder;
            }

            GridMovimientoAlmacen.AutoGenerateColumns = false;
            GridMovimientoAlmacen.DataSource = dw;
            for (lc_cont = 0; lc_cont <= GridMovimientoAlmacen.ColumnCount - 1; lc_cont++)
            {
                if (GridMovimientoAlmacen.Columns[lc_cont].Name.ToUpper() == "selecciona".ToUpper())
                {
                    GridMovimientoAlmacen.Columns[lc_cont].ReadOnly = false;
                }
                else
                {
                    GridMovimientoAlmacen.Columns[lc_cont].ReadOnly = true;
                }
            }

            if (xnomcolumna.Trim().Length > 0)
            {
                if (sorted == SortOrder.Ascending)
                {
                    GridMovimientoAlmacen.Sort(GridMovimientoAlmacen.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Ascending);
                }
                else
                {
                    GridMovimientoAlmacen.Sort(GridMovimientoAlmacen.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Descending);
                }
            }
            else
            {
                GridMovimientoAlmacen.Sort(GridMovimientoAlmacen.Columns["d_femisiondoc"], System.ComponentModel.ListSortDirection.Descending);
            }
            btnRefrescar.Enabled = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            PasarMovimiento(pcgtabla, false);
            Close();
        }

        private void GridMovimientoAlmacen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((GridMovimientoAlmacen.CurrentRow != null))
            {
                if (e.RowIndex >= 0)
                {
                    if (!sw_novaluechange)
                    {
                        if (GridMovimientoAlmacen.Columns[e.ColumnIndex].Name.ToUpper() == "selecciona".ToUpper())
                        {
                            GridMovimientoAlmacen.Rows[e.RowIndex].Cells["selecciona"].Value = !Convert.ToBoolean(GridMovimientoAlmacen.Rows[e.RowIndex].Cells["selecciona"].Value);
                        }
                        U_pINTAR();
                    }
                }
            }
        }
        private void GridMovimientoAlmacen_DoubleClick(object sender, EventArgs e)
        {
            if ((GridMovimientoAlmacen.CurrentRow != null))
            {
                seleccionaRegistros();
            }
        }
        private void GridMovimientoAlmacen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (GridMovimientoAlmacen.Columns[GridMovimientoAlmacen.CurrentCell.ColumnIndex].Name.ToUpper() == "selecciona".ToUpper())
                {
                    GridMovimientoAlmacen.Rows[GridMovimientoAlmacen.CurrentRow.Index].Cells["selecciona"].Value = !Convert.ToBoolean(GridMovimientoAlmacen.Rows[GridMovimientoAlmacen.CurrentRow.Index].Cells["selecciona"].Value);
                }
            }
        }

        private void optfechas_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_load)
            {
                U_RefrescaControles();
            }
        }

        public void U_RefrescaControles()
        {
            txtcodalmacen.Enabled = chkalmacen.Checked;
            txtdalmacen.Enabled = false;
            txtdtipdoc.Enabled = false;
            Fecha1.Enabled = optfechas.Checked;
            fecha2.Enabled = optfechas.Checked;
            txtRuc.Enabled = chkdetalle.Checked;
            txtTipdoc.Enabled = optordenes.Checked;
            txtSerdoc.Enabled = optordenes.Checked;
            txtNumdoc.Enabled = optordenes.Checked;
            txtCtacte.Enabled = false;
            txtRuc.ReadOnly = _DesactivaDetalle;
            chkdetalle.Enabled = !_DesactivaDetalle;
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            LlenarGridMovimientoAlmacen();
        }

        private void seleccionaRegistros()
        {
            if (GridMovimientoAlmacen.Visible)
            {
                pcgtabla = dw.Clone();
                if ((GridMovimientoAlmacen.CurrentRow != null))
                {
                    for (lc_cont = 0; lc_cont <= dw.Rows.Count - 1; lc_cont++)
                    {
                        if (Convert.ToBoolean(dw.Rows[lc_cont]["selecciona"]) == true)
                        {
                            pcgtabla.ImportRow(dw.Rows[lc_cont]);
                        }
                    }
                    pcgtabla.AcceptChanges();

                    //if (BL.Sql_Error.Length > 0)
                    //{
                    //    Frm_Class.ShowError(BL.Sql_Error, this);
                    //}
                    //else
                    //{
                        PasarMovimiento(pcgtabla, true);
                        Close();
                    //}
                }
            }
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            seleccionaRegistros();
        }

        private void chkdetalle_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_load)
            {
                U_RefrescaControles();
            }
        }
        private void txtRuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaProveedor();
            }
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("\t");
            }
        }
        private void txtRuc_GotFocus(object sender, System.EventArgs e)
        {
            j_String = txtRuc.Text;
        }
        private void txtRuc_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_String == txtRuc.Text) & !sw_load)
            {
                ValidaProveedor();
            }
        }
        private void AyudaProveedor()
        {
            Frm_AyudaProveedor frmayuda = new Frm_AyudaProveedor();
            frmayuda._Valores = "<< Ayuda Proveedores >>";
            frmayuda.Owner = this;
            frmayuda.PasaProveedor = RecibeProveedor;
            frmayuda.ShowDialog();
        }
        private void RecibeProveedor(string codigo, string nombre, string direccion)
        {
            if (codigo.Trim().Length > 0)
            {
                txtRuc.Text = codigo;
                ValidaProveedor();
            }
        }
        private void ValidaProveedor()
        {
            DataTable tmtabla = null;
            string xcodmotivo = "..";
            if (txtRuc.Text.Trim().Length > 0)
            {
                xcodmotivo = txtRuc.Text.Trim();
            }
            clienteBL BL = new clienteBL();
            tb_cliente BE = new tb_cliente();

            BE.nmruc = xcodmotivo;
            tmtabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            if (tmtabla.Rows.Count == 0)
            {
                txtRuc.Text = j_String;
            }
            else
            {
                txtCtacte.Text = tmtabla.Rows[0]["ctacte"].ToString().Trim();
                txtRuc.Text = tmtabla.Rows[0]["nmruc"].ToString();
                lblnomprov.Text = tmtabla.Rows[0]["ctactename"].ToString();
            }
        }

        // Por Tipo de Documento
        private void optordenes_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_load)
            {
                U_RefrescaControles();
            }
        }
        private void txtTipdoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaTipoDocumento();
            }
        }
        private void txtTipdoc_GotFocus(object sender, System.EventArgs e)
        {
            j_String = txtTipdoc.Text;
        }
        private void txtTipdoc_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_String == txtTipdoc.Text) & !sw_load)
            {
                validaTipoDocumento();
            }
        }
        private void AyudaTipoDocumento()
        {
            Frm_AyudaTipoDocumentos frmayuda = new Frm_AyudaTipoDocumentos();
            frmayuda.Owner = this;
            //frmayuda._LpTipoDocu = GlobalVars.GetInstance.TipDocusAlmacenes;
            frmayuda._PasaValor = RecibeTipoDocumento;
            frmayuda.ShowDialog();
        }
        private void RecibeTipoDocumento(string codigo, string descripcion)
        {
            if (codigo.Trim().Length > 0)
            {
                txtTipdoc.Text = codigo.Trim();
                validaTipoDocumento();
            }
        }
        private void validaTipoDocumento()
        {
            txtTipdoc.Text = VariablesPublicas.PADL(txtTipdoc.Text.Trim(), 2, "0");
            tb_co_tabla10_comprobantesBL BL = new tb_co_tabla10_comprobantesBL();
            tb_co_tabla10_comprobantes BE = new tb_co_tabla10_comprobantes();

            BE.codigoid = (txtTipdoc.Text.Trim().Length == 0 ? ".." : txtTipdoc.Text.Trim());
            tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            if (BL.Sql_Error.Length == 0)
            {
                if (tmptabla.Rows.Count > 0)
                {
                    txtTipdoc.Text = tmptabla.Rows[0]["codigoid"].ToString();
                    txtdtipdoc.Text = tmptabla.Rows[0]["descripcion"].ToString();
                }
                else
                {
                    txtTipdoc.Text = j_String;
                }
            }
        }

        private void txtnumdoclike_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("\t");
            }
        }
        private void txtSerdoc_LostFocus(object sender, System.EventArgs e)
        {
            if (!sw_load)
            {
                if (txtSerdoc.Text.Trim().Length > 0)
                {
                    txtSerdoc.Text = VariablesPublicas.PADL(txtSerdoc.Text.Trim(), 4, "0");
                }
            }
        }
        
        private void txtNumdoc_LostFocus(object sender, System.EventArgs e)
        {
            if (!sw_load)
            {
                if (txtNumdoc.Text.Trim().Length > 0)
                {
                    txtNumdoc.Text = VariablesPublicas.PADL(txtNumdoc.Text.Trim(), 10, "0");
                }
            }
        }

        private void U_pINTAR()
        {
            if (1 == 1)
            {
                int LC_CONT = 0;
                dynamic LC_NCOLUMNA = null;
                for (LC_CONT = 0; LC_CONT <= GridMovimientoAlmacen.RowCount - 1; LC_CONT++)
                {
                    if (Convert.ToBoolean(GridMovimientoAlmacen.Rows[LC_CONT].Cells["selecciona"].Value) == true)
                    {
                        for (LC_NCOLUMNA = 0; LC_NCOLUMNA <= GridMovimientoAlmacen.ColumnCount - 1; LC_NCOLUMNA++)
                        {
                            GridMovimientoAlmacen.Rows[LC_CONT].DefaultCellStyle.BackColor = lblregseleccionado.BackColor;
                            GridMovimientoAlmacen.Rows[LC_CONT].DefaultCellStyle.ForeColor = lblregseleccionado.ForeColor;
                        }
                    }
                    else
                    {
                        for (LC_NCOLUMNA = 0; LC_NCOLUMNA <= GridMovimientoAlmacen.ColumnCount - 1; LC_NCOLUMNA++)
                        {
                            GridMovimientoAlmacen.Rows[LC_CONT].DefaultCellStyle.BackColor = Color.White;
                            GridMovimientoAlmacen.Rows[LC_CONT].DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                }
            }
        }
     
        private void GridMovimientoAlmacen_Paint(object sender, PaintEventArgs e)
        {
            U_pINTAR();
        }

        private void chkalmacen_CheckedChanged(object sender, EventArgs e)
        {
            if (!sw_load)
            {
                U_RefrescaControles();
            }
        }
        private void txtcodalmacen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaAlmacenes();
            }
        }
        private void txtcodalmacen_GotFocus(object sender, System.EventArgs e)
        {
            j_Almacen = txtcodalmacen.Text;
        }
        private void txtcodalmacen_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_Almacen == txtcodalmacen.Text) & !sw_load)
            {
                ValidaAlmacen();
            }
        }
        private void ValidaAlmacen()
        {
            //DataTable otabla = null;
            string xcod = "";
            xcod = txtcodalmacen.Text;
            //otabla = ocapa.mag1500_CONSULTA(xcod, 1, 0, "", "");
            //if (otabla.Rows.Count > 0)
            //{
            //    txtcodalmacen.Text = otabla.Rows[0]["talm_15m"];
            //    txtdalmacen.Text = otabla.Rows[0]["nomb_15m"];
            //}
        }
        private void AyudaAlmacenes()
        {
            //FRMAyudaAlmacen frmayuda = new FRMAyudaAlmacen();
            //frmayuda.Owner = this;
            //frmayuda.PasaAlmacen = RecibeCodAlmacen;
            //frmayuda.ShowDialog();
        }
        private void RecibeCodAlmacen(string cod, string nombre)
        {
            if (cod.Trim().Length > 0)
            {
                txtcodalmacen.Text = cod.Trim();
                ValidaAlmacen();
            }
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            // Si el control tiene el foco...
            if (keyData == Keys.Enter & !btnRefrescar.Focused & !btnSeleccion.Focused & !btnCerrar.Focused)
            {
                SendKeys.Send("\t");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
