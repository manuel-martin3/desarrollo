using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.D60Tienda.Popup
{
    public partial class Frm_upload : plantilla
    {
        public delegate void PasaProveedorDelegate(DataTable resultado01);
        public PasaProveedorDelegate PasarTabla;
        private String modulo = VariablesPublicas.Moduloid;
        private String local = VariablesPublicas.Local;
        private DataTable DataDetalleProductos;
        private DataRow row;

        private String _moneda;
        public String moneda
        {
            get
            {
                return _moneda;
            }
            set
            {
                _moneda = value;
            }
        }

        private Int32 _listaprecid;
        public Int32 listaprecid
        {
            get
            {
                return _listaprecid;
            }
            set
            {
                _listaprecid = value;
            }
        }

        public Frm_upload()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            datos_seleccionados();
        }

        public void datos_seleccionados()
        {
            if ((dgb_listaproductos.CurrentRow != null))
            {
                if ((PasarTabla != null))
                {
                    PasarTabla(DataDetalleProductos);
                }
                Close();
            }
        }

        private void bloqueo(Boolean var)
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
                Close();
            }
        }

        private void cod_productid_TextChanged(object sender, EventArgs e)
        {
            if (cod_productid.Text.Length == 13)
            {
                var BE = new tb_me_productos();
                var BL = new tb_me_productosBL();
                var dt = new DataTable();

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

        private void limpiar()
        {
            cod_productid.Text = string.Empty;
            cod_productid.Focus();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            var lc_cont = 0;
            var xproductid = string.Empty;
            if ((dgb_listaproductos.CurrentRow != null))
            {
                xproductid = dgb_listaproductos.Rows[dgb_listaproductos.CurrentCell.RowIndex].Cells["productid"].Value.ToString();
                for (lc_cont = 0; lc_cont <= DataDetalleProductos.Rows.Count - 1; lc_cont++)
                {
                    if (DataDetalleProductos.Rows[lc_cont]["productid"].ToString() == xproductid)
                    {
                        DataDetalleProductos.Rows[lc_cont].Delete();
                        DataDetalleProductos.AcceptChanges();
                        break;
                    }
                }
                calcular_totales();
            }
        }

        private void calcular_totales()
        {
            tot_items.Text = dgb_listaproductos.Rows.Count.ToString();
            tot_importe.Text = Convert.ToDecimal(DataDetalleProductos.Compute("sum(precunit)", string.Empty)).ToString("##,###,##0.00");
        }

        private void dgb_listaproductos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgb_listaproductos[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            dgb_listaproductos[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            dgb_listaproductos.EnableHeadersVisualStyles = false;
        }
    }
}
