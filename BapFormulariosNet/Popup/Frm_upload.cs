using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace BapFormulariosNet.Popup
{
    public partial class Frm_upload : plantilla
    {
        public delegate void PasaProveedorDelegate(DataTable resultado01);
        public PasaProveedorDelegate PasarTabla;
        
        String dominio = VariablesPublicas.Dominioid;
        String modulo = VariablesPublicas.Moduloid;
        String local = VariablesPublicas.Local;
        DataTable DataDetalleProductos;
        DataRow row;

        #region »» Variables
        private String _moneda;
        public String moneda
        {
            get { return _moneda; }
            set { _moneda = value; }
        }

        private Int32 _listaprecid;
        public Int32 listaprecid
        {
            get { return _listaprecid; }
            set { _listaprecid = value; }
        }

        #endregion

        public Frm_upload()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            this.datos_seleccionados();
        }

        public void datos_seleccionados()
        {
            if ((this.dgb_listaproductos.CurrentRow != null))
            {
                if ((PasarTabla != null))
                {
                    this.PasarTabla(DataDetalleProductos);
                }
                this.Close();
            }
        }

        void bloqueo(Boolean var)
        {
            tot_importe.Enabled = false;
            tot_items.Enabled = false;
            dgb_listaproductos.ReadOnly = true;            
        }

        private void Frm_upload_Load(object sender, EventArgs e)
        {
           
            DataDetalleProductos = new DataTable("DataDetalleProductos");
            DataDetalleProductos.Columns.Add("productid", typeof(String));
            DataDetalleProductos.Columns.Add("productname", typeof(String));
            DataDetalleProductos.Columns.Add("precunit", typeof(Decimal));

            limpiar();
            bloqueo(false);
        }

        private void Frm_upload_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void cod_productid_TextChanged(object sender, EventArgs e)
        {
            if (cod_productid.Text.Length == 13)
            {
                //Consultaremos la Query Para Cargar los Productos                
                tb_me_productos BE = new tb_me_productos();
                tb_me_productosBL BL = new tb_me_productosBL();
                DataTable dt = new DataTable();

                BE.moduloid = modulo.ToString();
                BE.local = local.ToString();
                BE.productid = cod_productid.Text.ToString().Trim();
                BE.moneda = moneda.ToString();
                BE.listaprecid = listaprecid;

                dt = BL.GetPrecList(VariablesPublicas.EmpresaID, BE).Tables[0];

                foreach (DataRow fila in dt.Rows)
                {
                    row = DataDetalleProductos.NewRow();
                    row["productid"] = fila["productid"].ToString();
                    row["productname"] = fila["productname"].ToString();
                    row["precunit"] = fila["precunit"].ToString();
                    DataDetalleProductos.Rows.Add(row);
                    calcular_totales();
                }
                dgb_listaproductos.DataSource = DataDetalleProductos;

                limpiar();                
            }
        }

        void limpiar()
        {
            cod_productid.Text = "";
            cod_productid.Focus();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            int lc_cont = 0;
            String xproductid = "";
            if ((dgb_listaproductos.CurrentRow != null))
            {
                xproductid = this.dgb_listaproductos.Rows[this.dgb_listaproductos.CurrentCell.RowIndex].Cells["productid"].Value.ToString();
                for (lc_cont = 0; lc_cont <= this.DataDetalleProductos.Rows.Count - 1; lc_cont++)
                {
                    // Ubique el Producto a Borrar
                    if (this.DataDetalleProductos.Rows[lc_cont]["productid"].ToString() == xproductid)
                    {
                        this.DataDetalleProductos.Rows[lc_cont].Delete();
                        this.DataDetalleProductos.AcceptChanges();
                        break;
                    }
                }              
                calcular_totales();
            }
        }

        void calcular_totales()
        {
            tot_items.Text = dgb_listaproductos.Rows.Count.ToString();
            tot_importe.Text = Convert.ToDecimal(DataDetalleProductos.Compute("sum(precunit)", "")).ToString("##,###,##0.00");            
        }

        private void dgb_listaproductos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgb_listaproductos[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            dgb_listaproductos[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            dgb_listaproductos.EnableHeadersVisualStyles = false;
        }
    }
}
