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
    public partial class Frm_SeleccionVariosClientes : plantilla
    {
        // Parámetros
        public string _Cuenta = "";
        public delegate void PasaTabla(DataTable tabla);
        public PasaTabla _Delegado;
        public DataTable _TablaProveedores;
        public string _Titulo = "";
        // Variables
        string j_ruc = "";
        bool sw_novaluechange = false;
        bool sw_load = true;
        bool swLoad = true;
        //DataTable TablaDatos = ocapa.CaeSoft_GetAllPendientesCancelaciones("xx", "", "", "xx", 1, GlobalVars.GetInstance.CancelacionesListaDetalles, null);
        DataTable TablaDatos = new DataTable(); //falta generar procedimiento
        DataTable tmptabla = new DataTable();
        int lc_contador;

        public Frm_SeleccionVariosClientes()
        {       
            InitializeComponent();

            txtRuc.GotFocus += new System.EventHandler(txtRuc_GotFocus);
        }

        private void Frm_SeleccionVariosClientes_Activated(object sender, EventArgs e)
        {
            if (swLoad)
            {
                swLoad = false;
                try
                {
                    tb_co_MovimientosBL BL = new tb_co_MovimientosBL();
                    tb_co_Movimientos BE = new tb_co_Movimientos();

                    BE.perianio = "";
                    BE.cuentaini = "";
                    BE.nmruc = "xx";
                    BE.saldos = 1;
                    BE.tipmodal = 3;

                    TablaDatos = BL.GetGeneraCuentaCorrientePC(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Examinar.AutoGenerateColumns = false;
                Examinar.DataSource = TablaDatos;
                Examinar.ReadOnly = true;
            }
            if (sw_load)
            {
                if ((_TablaProveedores != null))
                {
                    TablaDatos = _TablaProveedores;
                }
                sw_load = false;
            }
            txtRuc.Focus();
        }
        private void Frm_SeleccionVariosClientes_Load(object sender, EventArgs e)
        {
            if (_Titulo.Trim().Length > 0)
            {
                Text = Text + " " + _Titulo;
            }           
            u_refrescaControles();
        }

        private void txtRuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ValidaDetalle();
            }
            else
            {
                if (e.KeyCode == Keys.F1)
                {
                    //btnSalir.Focus();
                    //Frm_AyudaProveedor Form = new Frm_AyudaProveedor();
                    //Form.Owner = this;
                    //Form.PasaProveedor = RecibeProveedor;
                    //Form.ShowDialog();
                }
            }
        }
        private void txtRuc_GotFocus(object sender, System.EventArgs e)
        {
            j_ruc = txtRuc.Text;
            txtRuc.SelectAll();
        }
        private void RecibeProveedor(string codigo, string nombre, string Direccion)
        {
            txtRuc.Text = codigo;
            txtCtactename.Text = nombre;
            AnexaDetalle();
            SendKeys.Flush();
        }
        public void ValidaDetalle()
        {
            sw_novaluechange = true;
            Int16 lc_cont = default(Int16);
            bool zhallado = false;
            string xcodartic = "..";
            if (txtRuc.Text.Trim().Length > 0)
            {
                xcodartic = txtRuc.Text;
            }
            if (xcodartic.Trim().Length == 0)
            {
            }
            else
            {
                clienteBL BL = new clienteBL();
                tb_cliente BE = new tb_cliente();

                BE.nmruc = xcodartic;
                tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                //tmptabla = ocapa.cag1000_CONSULTA(GlobalVars.GetInstance.Company, xcodartic, "", "", "", "", "", "", 1, "", 0, "", "");
                if (BL.Sql_Error.Length == 0)
                {
                    if (tmptabla.Rows.Count > 0)
                    {
                        txtRuc.Text = tmptabla.Rows[lc_cont]["nmruc"].ToString();
                        txtCtactename.Text = tmptabla.Rows[lc_cont]["ctactename"].ToString();
                        zhallado = true;
                    }
                }
            }
            if (!zhallado)
            {
                txtRuc.Text = j_ruc;
            }
            else
            {
                AnexaDetalle();
            }
            sw_novaluechange = false;
            txtRuc.Focus();
        }

        public void AnexaDetalle()
        {
            string xcodartic = "..";
            if (txtRuc.Text.Trim().Length > 0)
            {
                xcodartic = txtRuc.Text;
            }
            tb_co_MovimientosBL BL = new tb_co_MovimientosBL();
            tb_co_Movimientos BE = new tb_co_Movimientos();

            BE.perianio = VariablesPublicas.perianio;
            BE.cuentaini = _Cuenta;
            BE.nmruc = xcodartic;
            BE.saldos = 3;
            BE.tipmodal = 3;

            tmptabla = BL.GetGeneraCuentaCorrientePC(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            //tmptabla = ocapa.CaeSoft_GetAllPendientesCancelaciones(GlobalVars.GetInstance.Company, GlobalVars.GetInstance.Periodo, _Cuenta, xcodartic, 3, GlobalVars.GetInstance.CancelacionesListaDetalles, null);
            if (BL.Sql_Error.Length == 0)
            {
                if (tmptabla.Rows.Count > 0)
                {
                    if ((TablaDatos != null))
                    {
                        if (VariablesPublicas.BuscarEnTable(xcodartic, "detalle", TablaDatos) < 0)
                        {
                            TablaDatos.Rows.Add(VariablesPublicas.InsertIntoTable(TablaDatos));
                            for (lc_contador = 0; lc_contador <= TablaDatos.Columns.Count - 1; lc_contador++)
                            {
                                TablaDatos.Rows[TablaDatos.Rows.Count - 1][tmptabla.Columns[lc_contador].ColumnName] = tmptabla.Rows[0][tmptabla.Columns[lc_contador].ColumnName];
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show(txtRuc.Text.Trim() + "-" + txtCtactename.Text + " Ya seleccionado", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Ruc " + xcodartic + " " + txtCtactename.Text + " No registra saldos ", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                TablaDatos.AcceptChanges();
            }
            u_refrescaControles();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if ((_Delegado != null))
            {
                _Delegado(null);
            }
            Close();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (_Delegado != null)
            {
                _Delegado(TablaDatos);
            }
            Close();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if ((Examinar.CurrentRow != null))
            {
                Examinar.Rows.Remove(Examinar.Rows[Examinar.CurrentRow.Index]);
                Examinar.Refresh();
            }
        }

        public void u_refrescaControles()
        {
            bool zhayregistros = false;
            if ((Examinar.DataSource != null))
            {
                if ((Examinar.CurrentRow != null))
                {
                    zhayregistros = true;
                }
            }
            btnEliminar.Enabled = zhayregistros;
        }      
    }
}
