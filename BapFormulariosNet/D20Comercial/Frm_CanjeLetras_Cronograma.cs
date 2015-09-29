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
using BapFormulariosNet.Ayudas;
using BapFormulariosNet.D20Comercial.Ayudas;
using DevExpress.XtraEditors;

namespace BapFormulariosNet.D20Comercial
{
    public partial class Frm_CanjeLetras_Cronograma : plantilla
    {
        public delegate void Pasanumeroletra(string txtnumpagoinicial);
        public Pasanumeroletra _DelegadoLetra;

        public delegate void PasaDatosVoucher(DataTable ListaLetrascac3p00);
        // Parámetros
        public PasaDatosVoucher _PasaDelegado;
        public DataTable _TablaContable;
        public decimal _TotalDeudaSoles = 0;
        public decimal _TotalDeudaDolares = 0;
        public decimal _TipoCambio = 0;
        public string _nMoneda = "";
        public string _xctacte = "";
        public string _LpCodDetalle = "";
        public string _LpNomDetalle = "";
        public bool _LpVariosDetalles = false;
        //Variables
        DataTable tmpTablaContable = new DataTable();
        TextBox txtCArti = null;
        string _NameCOlumna = "";
        DataTable tmptabla = new DataTable();
        private bool sw_load = true;
        bool sw_novaluechange = false;
        string j_txtnumpagoinicial = "";
        //string j_txtSerie = "";
        string j_txttotletras = "";
        string j_dfreferencia = "";
        string j_detalle = "";
        int n_contador = 0;

        public Frm_CanjeLetras_Cronograma()
        {
            InitializeComponent();

            txttotletras.LostFocus += new System.EventHandler(txttotletras_LostFocus);
            txttotletras.GotFocus += new System.EventHandler(txttotletras_GotFocus);

            txtSerie.LostFocus += new System.EventHandler(txtSerie_LostFocus);
            //txtSerie.GotFocus += new System.EventHandler(txtSerie_GotFocus);

            txtnumpagoinicial.LostFocus += new System.EventHandler(txtnumpagoinicial_LostFocus);
            txtnumpagoinicial.GotFocus += new System.EventHandler(txtnumpagoinicial_GotFocus);
        }

        private void Frm_CanjeLetras_Cronograma_Activated(object sender, EventArgs e)
        {
            sw_load = false;
            u_RefrescaControles();
        }
        private void Frm_CanjeLetras_Cronograma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnSalir_Click(sender, e);
            }
        }
        private void Frm_CanjeLetras_Cronograma_Load(object sender, EventArgs e)
        {
            txttotapagarsoles.Text = _TotalDeudaSoles.ToString("###,###,###.00");
            txttotapagardolares.Text = _TotalDeudaDolares.ToString("###,###,###.00");
            txtcambio.Text = _TipoCambio.ToString("##.0000");
            txtnumpagoinicial.MaxLength = 10;

            tmpTablaContable = _TablaContable.Clone();
            Examinar.AutoGenerateColumns = false;
            Examinar.DataSource = tmpTablaContable;
            if (_TablaContable.Rows.Count > 0)
            {
                txttotletras.Text = VariablesPublicas.PADL((_TablaContable.Rows.Count).ToString(), 2, "0");
                txtSerie.Text = _TablaContable.Rows[0]["serdoc"].ToString();
                txtnumpagoinicial.Text = _TablaContable.Rows[0]["numdoc"].ToString();
                fechavenc.Value = Convert.ToDateTime(_TablaContable.Rows[0]["fechvenc"]);
                for (n_contador = 0; n_contador <= _TablaContable.Rows.Count - 1; n_contador++)
                {
                    tmpTablaContable.ImportRow(_TablaContable.Rows[n_contador]);
                }
                tmpTablaContable.AcceptChanges();
            }
            else
            {
                txtSerie.Text = "LT01";
            }
            for (n_contador = 0; n_contador <= Examinar.ColumnCount - 1; n_contador++)
            {
                if (Examinar.Columns[n_contador].Visible)
                {
                    Examinar.Columns[n_contador].SortMode = DataGridViewColumnSortMode.NotSortable;
                    if (!(Examinar.Columns[n_contador].Name.ToUpper() == "fechvenc".ToUpper()) & !(Examinar.Columns[n_contador].Name.ToUpper() == "numdoc".ToUpper()) & !(Examinar.Columns[n_contador].Name.ToUpper() == "importe".ToUpper()))
                    {
                        if (!(Examinar.Columns[n_contador].Name.ToUpper() == "nmruc".ToUpper()))
                        {
                            Examinar.Columns[n_contador].ReadOnly = !_LpVariosDetalles;
                        }
                        else
                        {
                            Examinar.Columns[n_contador].ReadOnly = true;
                        }
                        if (Examinar.Columns[n_contador].ReadOnly)
                        {
                            Examinar.Columns[n_contador].DefaultCellStyle.BackColor = Color.LightGray;
                            Examinar.Columns[n_contador].DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                    else
                    {
                        Examinar.Columns[n_contador].ReadOnly = false;
                    }
                }
            }
            totalizar();
            VariablesPublicas.PintaEncabezados(Examinar);
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (keyData == Keys.Enter & !btngenerarletras.Focused)
            {
                if (Examinar.Focused)
                {
                }
                else
                {
                    SendKeys.Send("\t");
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txttotletras_GotFocus(object sender, System.EventArgs e)
        {
            j_txttotletras = txttotletras.Text;
        }
        private void txttotletras_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_txttotletras == txttotletras.Text) & !sw_load)
            {
                decimal ncuantos = VariablesPublicas.StringtoDecimal(txttotletras.Text);
                if (ncuantos > 0)
                {
                    txttotletras.Text = VariablesPublicas.PADL(ncuantos.ToString(), 2, "0");
                }
                else
                {
                    txttotletras.Text = j_txttotletras;
                }
            }
        }

        private void txtSerie_LostFocus(object sender, System.EventArgs e)
        {
            //if (!(j_txtSerie == txtSerie.Text) & !sw_load)
            //{
                if (txtSerie.Text.Trim().Length > 0)
                {
                    txtSerie.Text = txtSerie.Text.Trim().PadLeft(txtSerie.MaxLength, '0');
                }
                else
                {
                    txtSerie.Text = txtSerie.Text.Trim().PadLeft(txtSerie.MaxLength, '0');
                }
            //}
        }

        private void txtnumpagoinicial_GotFocus(object sender, System.EventArgs e)
        {
            j_txtnumpagoinicial = txtnumpagoinicial.Text;
        }
        private void txtnumpagoinicial_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_txtnumpagoinicial == txtnumpagoinicial.Text) & !sw_load)
            {
                decimal ncuantos = VariablesPublicas.StringtoDecimal(txtnumpagoinicial.Text);
                if (ncuantos > 0)
                {
                    txtnumpagoinicial.Text = VariablesPublicas.PADL(txtnumpagoinicial.Text, 10, "0");
                }
            }
        }
        public void u_RefrescaControles()
        {
            txttotapagardolares.Enabled = false;
            txttotapagarsoles.Enabled = false;
            txtcambio.Enabled = false;
        }

        private bool Validacion()
        {
            string xmsg = "";
            if (_TipoCambio == 0)
            {
                xmsg = "No Registra Tipo de Cambio";
            }
            if (txtnumpagoinicial.Text.Trim().Length == 0)
            {
                xmsg = "Ingrese Número de Letra Inicial";
                txtnumpagoinicial.Focus();
            }
            if (txtSerie.Text.Trim().Length == 0)
            {
                xmsg = "Ingrese la serie de la letra de cambio";
                txtSerie.Focus();
            }
            if (txttotletras.Text.Trim().Length == 0)
            {
                xmsg = "Ingrese la cantidad de Letras a generar";
                txttotletras.Focus();
            }
            if (xmsg.Length > 0)
            {
                XtraMessageBox.Show(xmsg, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            return xmsg.Length == 0;
        }
        private void btngenerarletras_Click(object sender, EventArgs e)
        {
            if (Validacion())
            {
                for (n_contador = 0; n_contador <= tmpTablaContable.Rows.Count - 1; n_contador++)
                {
                    tmpTablaContable.Rows[n_contador].Delete();
                }
                decimal vmtotletras = VariablesPublicas.StringtoDecimal(txttotletras.Text);
                string vmnroletra = "";
                decimal vmfactordolares = 0;
                decimal vmfactorsoles = 0;
                if (_nMoneda == "1")
                {
                    if (!(vmtotletras == 0))
                    {
                        vmfactorsoles = Math.Round((vmtotletras == 0 ? 0 : _TotalDeudaSoles / vmtotletras), 2);
                    }

                    if (_TipoCambio > 0)
                    {
                        vmfactordolares = Math.Round(vmfactorsoles / _TipoCambio, 2);
                    }
                }
                else
                {
                    if (!(vmtotletras == 0))
                    {
                        vmfactordolares = Math.Round((vmtotletras == 0 ? 0 : _TotalDeudaDolares / vmtotletras), 2);
                    }
                    if (_TipoCambio > 0)
                    {
                        vmfactorsoles = Math.Round(vmfactordolares * _TipoCambio, 2);
                    }
                }
                tmpTablaContable.AcceptChanges();
                vmnroletra = txtnumpagoinicial.Text;

                decimal vmsumtotsoles = 0;
                decimal vmsumtotdolares = 0;
                for (n_contador = 1; n_contador <= vmtotletras; n_contador++)
                {
                    tmpTablaContable.Rows.Add(VariablesPublicas.InsertIntoTable(tmpTablaContable));
                    tmpTablaContable.Rows[tmpTablaContable.Rows.Count - 1]["moneda"] = _nMoneda;
                    tmpTablaContable.Rows[tmpTablaContable.Rows.Count - 1]["tipdoc"] = "62";
                    tmpTablaContable.Rows[tmpTablaContable.Rows.Count - 1]["serdoc"] = txtSerie.Text;
                    tmpTablaContable.Rows[tmpTablaContable.Rows.Count - 1]["numdoc"] = vmnroletra;
                    tmpTablaContable.Rows[tmpTablaContable.Rows.Count - 1]["numdocpago"] = vmnroletra;
                    if (_nMoneda == "1")
                    {
                        tmpTablaContable.Rows[tmpTablaContable.Rows.Count - 1]["Importe"] =  Math.Round(vmfactorsoles,2);
                        tmpTablaContable.Rows[tmpTablaContable.Rows.Count - 1]["ImporteCambio"] =  Math.Round(vmfactordolares,2);
                    }
                    else
                    {
                        tmpTablaContable.Rows[tmpTablaContable.Rows.Count - 1]["Importe"] =  Math.Round(vmfactordolares,2);
                        tmpTablaContable.Rows[tmpTablaContable.Rows.Count - 1]["ImporteCambio"] =  Math.Round(vmfactorsoles,2);
                    }
                    tmpTablaContable.Rows[tmpTablaContable.Rows.Count - 1]["fechvenc"] = Equivalencias.Mid(fechavenc.Value.AddDays(30 * (n_contador - 1)).ToString(), 1, 10);
                    tmpTablaContable.Rows[tmpTablaContable.Rows.Count - 1]["ctacte"] = _xctacte;
                    tmpTablaContable.Rows[tmpTablaContable.Rows.Count - 1]["nmruc"] = _LpCodDetalle;
                    tmpTablaContable.Rows[tmpTablaContable.Rows.Count - 1]["ctactename"] = Equivalencias.Mid(_LpNomDetalle, 1);
                    tmpTablaContable.Rows[tmpTablaContable.Rows.Count - 1]["tipcamb"] = _TipoCambio;

                    if (vmnroletra.Trim().Length > 0)
                    {
                        vmnroletra = VariablesPublicas.PADL((VariablesPublicas.StringtoDecimal(vmnroletra) + 1).ToString(), txtnumpagoinicial.MaxLength, "0");
                    }
                }
                tmpTablaContable.AcceptChanges();
                for (n_contador = 0; n_contador <= tmpTablaContable.Rows.Count - 1; n_contador++)
                {
                    if (_nMoneda == "1")
                    {
                        vmsumtotsoles = vmsumtotsoles + Convert.ToDecimal(tmpTablaContable.Rows[n_contador]["Importe"]);
                        vmsumtotdolares = vmsumtotdolares + Convert.ToDecimal(tmpTablaContable.Rows[n_contador]["ImporteCambio"]);
                    }
                    else
                    {
                        vmsumtotsoles = vmsumtotsoles + Convert.ToDecimal(tmpTablaContable.Rows[n_contador]["ImporteCambio"]);
                        vmsumtotdolares = vmsumtotdolares + Convert.ToDecimal(tmpTablaContable.Rows[n_contador]["Importe"]);
                    }
                }
                if (vmtotletras > 0)
                {
                    if (_nMoneda == "1")
                    {
                        //SE AJUSTE AL ULTIMO REGISTRO
                        if (!(vmsumtotsoles == _TotalDeudaSoles))
                        {
                            tmpTablaContable.Rows[tmpTablaContable.Rows.Count - 1]["Importe"] =  Math.Round(Convert.ToDecimal(tmpTablaContable.Rows[tmpTablaContable.Rows.Count - 1]["Importe"]) + (_TotalDeudaSoles - vmsumtotsoles),2);
                        }
                        if (_TipoCambio == 0)
                        {
                            tmpTablaContable.Rows[tmpTablaContable.Rows.Count - 1]["ImporteCambio"] = 0;
                        }
                        else
                        {
                            tmpTablaContable.Rows[tmpTablaContable.Rows.Count - 1]["ImporteCambio"] = Math.Round(Convert.ToDecimal(tmpTablaContable.Rows[tmpTablaContable.Rows.Count - 1]["Importe"]) / _TipoCambio, 2);
                        }
                    }
                    else
                    {
                        //SE AJUSTE AL ULTIMO REGISTRO
                        if (!(vmsumtotdolares == _TotalDeudaDolares))
                        {
                            tmpTablaContable.Rows[tmpTablaContable.Rows.Count - 1]["Importe"] =  Math.Round(Convert.ToDecimal(tmpTablaContable.Rows[tmpTablaContable.Rows.Count - 1]["Importe"]) + (_TotalDeudaDolares - vmsumtotdolares),2);
                        }
                        if (_TipoCambio == 0)
                        {
                            tmpTablaContable.Rows[tmpTablaContable.Rows.Count - 1]["ImporteCambio"] = 0;
                        }
                        else
                        {
                            tmpTablaContable.Rows[tmpTablaContable.Rows.Count - 1]["ImporteCambio"] = Math.Round(Convert.ToDecimal(tmpTablaContable.Rows[tmpTablaContable.Rows.Count - 1]["Importe"]) * _TipoCambio, 2);
                        }
                    }
                }
                tmpTablaContable.AcceptChanges();                
            }
            totalizar();
        }

        private void totalizarItem()
        {
            
            decimal vmimportecambio = 0;
            decimal vmtcambio = _TipoCambio;
            sw_novaluechange = false;
            if (object.ReferenceEquals(Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipcamb"].Value, DBNull.Value))
            {
                Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipcamb"].Value = 0;
            }
            if (Convert.ToDecimal(Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipcamb"].Value) > 0)
            {
                vmtcambio = Convert.ToDecimal(Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipcamb"].Value);
            }
            if (object.ReferenceEquals(Examinar.Rows[Examinar.CurrentRow.Index].Cells["importe"].Value, DBNull.Value))
            {
                Examinar.Rows[Examinar.CurrentRow.Index].Cells["importe"].Value = 0;
            }
            if (Examinar.Rows[Examinar.CurrentRow.Index].Cells["moneda"].Value.ToString() == "1")
            {
                if (vmtcambio == 0)
                {
                    vmimportecambio = 0;
                }
                else
                {
                    vmimportecambio = Math.Round(Convert.ToDecimal(Examinar.Rows[Examinar.CurrentRow.Index].Cells["importe"].Value) / vmtcambio, 2);
                }
            }
            if (Examinar.Rows[Examinar.CurrentRow.Index].Cells["moneda"].Value.ToString() == "2")
            {
                vmimportecambio = Math.Round((vmtcambio == 0 ? 0 : Convert.ToDecimal(Examinar.Rows[Examinar.CurrentRow.Index].Cells["importe"].Value) * vmtcambio), 2);
            }
            Examinar.Rows[Examinar.CurrentRow.Index].Cells["importecambio"].Value = vmimportecambio;
            Examinar.Refresh();
            totalizar();
        }
        private void totalizar()
        {
            decimal vmsumtotsol = 0;
            decimal vmsumtotdol = 0;
            decimal ztotalsoles = 0;
            decimal ztotaldolar = 0;
            for (n_contador = 0; n_contador <= tmpTablaContable.Rows.Count - 1; n_contador++)
            {
                if (_nMoneda == "1")
                {
                    vmsumtotsol = vmsumtotsol + Convert.ToDecimal(tmpTablaContable.Rows[n_contador]["Importe"]);
                    vmsumtotdol = vmsumtotdol + Convert.ToDecimal(tmpTablaContable.Rows[n_contador]["ImporteCambio"]);
                    txtTotaImporte.Text = vmsumtotsol.ToString("###,###,###.00");
                    txtTotalImporteCambio.Text = vmsumtotdol.ToString("###,###,###.00");
                    ztotalsoles = _TotalDeudaSoles - vmsumtotsol;
                    txtDif.Text = ztotalsoles.ToString("###,###,###.00");
                }
                else
                {
                    vmsumtotsol = vmsumtotsol + Convert.ToDecimal(tmpTablaContable.Rows[n_contador]["ImporteCambio"]);
                    vmsumtotdol = vmsumtotdol + Convert.ToDecimal(tmpTablaContable.Rows[n_contador]["Importe"]);
                    txtTotaImporte.Text = vmsumtotdol.ToString("###,###,###.00");
                    txtTotalImporteCambio.Text = vmsumtotsol.ToString("###,###,###.00");
                    ztotaldolar = _TotalDeudaDolares - vmsumtotdol;
                    txtDif.Text = ztotaldolar.ToString("###,###,###.00");
                }
            }
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReporte_Click(object sender, EventArgs e) //Seleccionar
        {
            totalizar();
            if (_nMoneda == "1")
            {
                if (Convert.ToDecimal(txttotapagarsoles.Text) != Convert.ToDecimal(txtTotaImporte.Text))
                {
                    XtraMessageBox.Show("No Cuadra los Totales en Soles... Verifique", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
            }
            else if (Convert.ToDecimal(txttotapagardolares.Text) != Convert.ToDecimal(txtTotaImporte.Text))
            {
                XtraMessageBox.Show("No Cuadra los Totales en Dolares... Verifique", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            if ((_PasaDelegado != null))
            {
                tmpTablaContable.AcceptChanges();
                if (tmpTablaContable.Rows.Count == 0)
                {
                    XtraMessageBox.Show("No hay letras generadas..Verifique", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    for (n_contador = 0; n_contador <= tmpTablaContable.Rows.Count - 1; n_contador++)
                    {
                        if (_nMoneda == "1")
                        {
                            tmpTablaContable.Rows[n_contador]["soles"] = tmpTablaContable.Rows[n_contador]["Importe"];
                            tmpTablaContable.Rows[n_contador]["dolares"] = tmpTablaContable.Rows[n_contador]["ImporteCambio"];
                        }
                        else
                        {
                            tmpTablaContable.Rows[n_contador]["soles"] = tmpTablaContable.Rows[n_contador]["ImporteCambio"];
                            tmpTablaContable.Rows[n_contador]["dolares"] = tmpTablaContable.Rows[n_contador]["Importe"];
                        }
                    }
                    _DelegadoLetra(txtnumpagoinicial.Text);
                    _PasaDelegado(tmpTablaContable);
                    Close();
                }
            }
        }

        private void Examinar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (VariablesPublicas.PulsaAyudaArticulos)
            {
                switch (_NameCOlumna.ToUpper())
                {
                    case "nmruc":
                        AyudaProveedor();
                        break;
                }
            }
            VariablesPublicas.PulsaAyudaArticulos = false;
            if ((Examinar.CurrentCell != null) & 1 == 0)
            {
                int nfila = Examinar.CurrentCell.RowIndex;
                int ncolumna = Examinar.CurrentCell.ColumnIndex;
                tmpTablaContable.AcceptChanges();
                try
                {
                    Examinar.CurrentCell = Examinar.Rows[nfila].Cells[ncolumna];

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "BapSoft");
                }
            }
        }
        private void Examinar_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((Examinar.CurrentRow != null) & !sw_novaluechange)
            {
                if (Examinar.Columns[e.ColumnIndex].Name.ToUpper() == "importe".ToUpper())
                {
                    totalizarItem();
                }
                if (Examinar.Columns[e.ColumnIndex].Name.ToUpper() == "importecambio".ToUpper())
                {
                    totalizar();
                }
                if (Examinar.Columns[e.ColumnIndex].Name.ToUpper() == "fechvenc".ToUpper())
                {
                    validaFechaDetalle();
                    totalizar();
                }
                if (Examinar.Columns[e.ColumnIndex].Name.ToUpper() == "nmruc".ToUpper())
                {
                    ValidaProveedor();
                }
                if (Examinar.Columns[e.ColumnIndex].Name.ToUpper() == "numdoc".ToUpper())
                {
                    ValidaNumDocumento();
                    totalizar();
                }  
            }
        }
        private void Examinar_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if ((Examinar.CurrentRow != null))
            {
                if (Examinar.Columns[e.ColumnIndex].Name.ToUpper() == "fechvenc".ToUpper())
                {
                    j_dfreferencia = Examinar.CurrentCell.Value.ToString();
                }
                if (Examinar.Columns[e.ColumnIndex].Name.ToUpper() == "nmruc".ToUpper())
                {
                    j_detalle = Examinar.CurrentCell.Value.ToString();
                }
            }
        }
        private void Examinar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            }
            // Ayudas
            if (e.KeyCode == Keys.F1)
            {
                if ((Examinar.CurrentCell != null))
                {
                    if (Examinar.CurrentCell.ReadOnly == false)
                    {
                        if (Examinar.Columns[Examinar.CurrentCell.ColumnIndex].Name.ToUpper() == "nmruc".ToUpper())
                        {
                            AyudaProveedor();
                        }
                    }
                }
            }
        }
        private void Examinar_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (Examinar.Columns[Examinar.CurrentCell.ColumnIndex].Name.ToUpper() == "nmruc".ToUpper())
            {
                txtCArti = (TextBox)e.Control;
                txtCArti.MaxLength = 11; // tmpTablaContable.Columns["nmruc"].MaxLength;
                txtCArti.CharacterCasing = CharacterCasing.Upper;
                txtCArti.Text.Trim();
                e.Control.KeyDown += VariablesPublicas.CapturarTeclaGRID;
            }
            if (Examinar.Columns[Examinar.CurrentCell.ColumnIndex].Name.ToUpper() == "numdoc".ToUpper())
            {
                txtCArti = (TextBox)e.Control;
                txtCArti.MaxLength = 10; //tmpTablaContable.Columns["numdoc"].MaxLength;
                txtCArti.CharacterCasing = CharacterCasing.Upper;
                txtCArti.Text.Trim();
                e.Control.KeyDown += VariablesPublicas.CapturarTeclaGRID;
            }
            _NameCOlumna = Examinar.Columns[Examinar.CurrentCell.ColumnIndex].Name.ToUpper();
        }

        private void validaFechaDetalle()
        {
            sw_novaluechange = true;
            bool zhallado = false;
            string VMNROITEM = Examinar.Rows[Examinar.CurrentRow.Index].Cells["asientoitems"].Value.ToString();
            string xcodartic = "..";
            if ((!object.ReferenceEquals(Examinar.Rows[Examinar.CurrentRow.Index].Cells["fechvenc"].Value, DBNull.Value)))
            {
                xcodartic = Examinar.Rows[Examinar.CurrentRow.Index].Cells["fechvenc"].Value.ToString();
            }
            if (xcodartic.Trim().Length == 0)
            {
                tmpTablaContable.Rows[Examinar.CurrentRow.Index]["fechvenc"] = DBNull.Value;
                zhallado = true;
            }
            else
            {
                zhallado = VariablesPublicas.ValidarFecha(xcodartic);

                if (zhallado)
                {
                    tmpTablaContable.Rows[Examinar.CurrentRow.Index]["fechvenc"] = Convert.ToDateTime(xcodartic);
                }
            }
            if (!zhallado & xcodartic.Length > 0)
            {
                Examinar.Rows[Examinar.CurrentRow.Index].Cells["fechvenc"].Value = j_dfreferencia;
            }
            Examinar.Refresh();
            sw_novaluechange = false;
        }
        
        private void ValidaProveedor()
        {
            sw_novaluechange = true;
            Int16 lc_cont = default(Int16);
            bool zhallado = false;
            string VMNROITEM = Examinar.Rows[Examinar.CurrentRow.Index].Cells["asientoitems"].Value.ToString();
            string xcodartic = "..";
            if ((!object.ReferenceEquals(Examinar.Rows[Examinar.CurrentRow.Index].Cells["nmruc"].Value, DBNull.Value)))
            {
                xcodartic = Examinar.Rows[Examinar.CurrentRow.Index].Cells["nmruc"].Value.ToString();
            }
            if (xcodartic.Trim().Length == 0)
            {
                tmpTablaContable.Rows[lc_cont]["nmruc"] = "";
                tmpTablaContable.Rows[lc_cont]["ctactename"] = "";
                zhallado = true;
            }
            else
            {
                clienteBL BL = new clienteBL();
                tb_cliente BE = new tb_cliente();

                BE.nmruc = xcodartic;
                tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                for (lc_cont = 0; lc_cont <= tmpTablaContable.Rows.Count - 1; lc_cont++)
                {
                    if (tmpTablaContable.Rows[lc_cont]["asientoitems"].ToString() == VMNROITEM)
                    {
                        if (tmptabla.Rows.Count > 0)
                        {
                            tmpTablaContable.Rows[lc_cont]["nmruc"] = tmptabla.Rows[0]["nmruc"];
                            tmpTablaContable.Rows[lc_cont]["ctactename"] = tmptabla.Rows[0]["ctactename"];
                            zhallado = true;
                            break; 
                        }
                    }
                }
            }
            if (!zhallado)
            {
                Examinar.Rows[Examinar.CurrentRow.Index].Cells["nmruc"].Value = j_detalle;
            }
            Examinar.Refresh();
            sw_novaluechange = false;
        }

        private void AyudaProveedor()
        {
            //Frm_AyudaProveedor frmayuda = new Frm_AyudaProveedor();
            //frmayuda.Owner = this;
            //frmayuda.PasaProveedor = RecibeProveedor;
            //frmayuda.ShowDialog();
        }
        private void RecibeProveedor(string codigo, string nombre, string direccion)
        {
            if (codigo.Trim().Length > 0)
            {
                Examinar.Rows[Examinar.CurrentRow.Index].Cells["nmruc"].Value = codigo;
            }
        }

        public void ValidaNumDocumento()
        {
            sw_novaluechange = true;
            if ((!object.ReferenceEquals(Examinar.Rows[Examinar.CurrentRow.Index].Cells["numdoc"].Value, DBNull.Value)))
            {
                Examinar.Rows[Examinar.CurrentRow.Index].Cells["nmruc"].Value = Examinar.Rows[Examinar.CurrentRow.Index].Cells["nmruc"].Value.ToString().Trim();
            }
            sw_novaluechange = false;
        }
    }
}
