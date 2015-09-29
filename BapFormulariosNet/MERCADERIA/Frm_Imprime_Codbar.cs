using System.Text;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using LayerDataAccess;
using bapFunciones;
using System.Net.Mail;
using System.Net;

using System;
using System.Data;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Collections;
using System.Data.SqlClient;

using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Card.ViewInfo;
using DevExpress.XtraGrid.Columns;

using System.Threading;
using System.Net.Sockets;
using System.IO;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace BapFormulariosNet.MERCADERIA
{
    public partial class Frm_Imprime_Codbar : plantilla
    {
        String EmpresaID = VariablesPublicas.EmpresaID;
        String dominio = "60";
        String modulo = VariablesPublicas.Moduloid;
        String local = VariablesPublicas.Local;
        Decimal tipoCAmbio = 0;
        private DataRow row;
        DataTable TablaProductos;


        /*** Impresión***/
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern SafeFileHandle CreateFile(string lpFileName, FileAccess dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, FileMode dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);


        public Frm_Imprime_Codbar()
        {
            InitializeComponent();
        }
      
        private void Frm_Imprime_Codbar_Load(object sender, EventArgs e)
        {
            NameLocal();
            bloquear(false);
            limpiar();
            CargarComboTipodoc();
            ArmarTabla();
        }
            
        private void NameLocal()
        {
            DataTable dt = new DataTable();
            String Query = " Select * From tb_sys_local where dominioid = '" + dominio + "' " +
                           " and moduloid = '" + modulo + "' and local = '" + local + "' ";            
            dt = QueryLocal(Query).Tables[0];

            if (dt.Rows.Count > 0)
            {
                loc_id.Text = dt.Rows[0]["local"].ToString();
                loc_name.Text = dt.Rows[0]["localname"].ToString();
            }
            
        }
              
        private DataSet QueryLocal(String Query)
        {
            ConexionDA conex = new ConexionDA();
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(EmpresaID)))
            {
                using (SqlCommand cmd = new SqlCommand("gspHelpSQL", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@sqlquery", SqlDbType.VarChar).Value = Query;
                    }
                    try
                    {
                        cnx.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                        }
                        return ds;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
            
        private void limpiar()
        {
            _numdoc.Equals("");
            _serdoc.Equals("");
        }

        private void bloquear(Boolean var)
        {
            loc_id.Enabled = false;
            loc_name.Enabled = false;
            _serdoc.Enabled = var;
            _numdoc.Enabled = var;
            rdb_print.Enabled = var;

            btnSiguiente.Enabled = false;
            btnUltimo.Enabled = false;
            btnAnterior.Enabled = false;
            btnInicio.Enabled = false;
            btnLoad.Enabled = false;
            btnLock.Enabled = false;
            btnLog.Enabled = false;
            btnEdit.Enabled = false;
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            
        }

        void CargarComboTipodoc()
        {
            try
            {
                modulo_local_tipodocBL BL = new modulo_local_tipodocBL();
                tb_modulo_local_tipodoc BE = new tb_modulo_local_tipodoc();
                BE.dominioid = dominio;
                BE.moduloid = modulo;
                BE.local = local;
                BE.visiblealmac = true;
                BE.filtro = "1";
                BE.status = "";
                BE.tipodoctipotransac = "A";

                // = BL.GetAll_mov(EmpresaID, BE).Tables[0];
                //cmb_tipodoc.ValueMember = "tipodoc";
                //cmb_tipodoc.DisplayMember = "tipodocname";

                cbo_tipodoc.Properties.DataSource = BL.GetAll_mov(EmpresaID, BE).Tables[0];
                cbo_tipodoc.Properties.ValueMember = "tipodoc";
                cbo_tipodoc.Properties.DisplayMember = "tipodocname";
                cbo_tipodoc.EditValue = 0;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region »» Genera tipo de cambio dependiendo la fech del documento ««
        private void get_tipocambio(string fecha)
        {
            try
            {
                // Genera tipo de cambio dependiendo la fech del documento
                tipocambioBL BL = new tipocambioBL();
                tb_tipocambio BE = new tb_tipocambio();
                DataTable dt = new DataTable();

                dt = BL.GetOne(EmpresaID, Convert.ToDateTime(fecha)).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    tipoCAmbio = Convert.ToDecimal(dt.Rows[0]["venta"]);
                }
                else
                {
                    tipoCAmbio = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bloquear(true);
            limpiar();
            btnNew.Enabled = false;
            btnCancel.Enabled = true;
        }

        void ArmarTabla() 
        {
            TablaProductos = new DataTable();
            TablaProductos.Columns.Add("productid", typeof(String));
            TablaProductos.Columns.Add("productname", typeof(String));
            TablaProductos.Columns.Add("nserie", typeof(String));
            TablaProductos.Columns.Add("lineaid", typeof(String));
            TablaProductos.Columns.Add("lineaname", typeof(String));
            TablaProductos.Columns.Add("grupoid", typeof(String));
            TablaProductos.Columns.Add("gruponame", typeof(String));
            TablaProductos.Columns.Add("subgrupoid", typeof(String));
            TablaProductos.Columns.Add("subgrupoartic", typeof(String));
            TablaProductos.Columns.Add("cantidad", typeof(Decimal));
        }

        void AddRowTable()
        {
            row = TablaProductos.NewRow();
            row["productid"] = "_";
            row["productname"] = "_";
            row["nserie"] = "_";
            row["lineaid"] = "_";
            row["lineaname"] = "_";
            row["grupoid"] = "_";
            row["gruponame"] = "_";
            row["subgrupoid"] = "_";
            row["subgrupoartic"] = "_";
            row["cantidad"] = "1";
            TablaProductos.Rows.Add(row);            
        }

        private void _numdoc_Properties_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                String numdo = "";
                if (_numdoc.Text.Trim().Length > 0)
                {
                    numdo = _numdoc.Text.Trim().PadLeft(10, '0');
                }
                _numdoc.Text = numdo;
                dgb_codigos.Focus();

                Add_Detalle();

                tb_me_movimientosdetBL BL = new tb_me_movimientosdetBL();
                tb_me_movimientosdet BE = new tb_me_movimientosdet();
                DataTable dt = new DataTable();
                BE.moduloid = modulo;
                BE.local = local;
                BE.tipodoc = Equivalencias.Left(cbo_tipodoc.Text,2);
                BE.serdoc = _serdoc.Text.Trim();
                BE.numdoc = _numdoc.Text.Trim();

                dt = BL.GetAll_datosdetalle(EmpresaID, BE).Tables[0];

                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        int cont = 0;
                        foreach (DataRow fila in dt.Rows)
                        {
                            cont = cont + 1;
                            if (this.dgb_codigos.RowCount > 0)
                            {
                                int nFilaAnt = dgb_codigos.RowCount - 1;
                                if (cont > 1)
                                {
                                    TablaProductos = new DataTable();
                                    ArmarTabla();
                                    for (int j = 0; j < dgb_codigos.RowCount; j++)
                                    {
                                        row = TablaProductos.NewRow();
                                        row["productid"] = dgb_codigos.GetRowCellValue(j, "productid").ToString();
                                        row["productname"] = dgb_codigos.GetRowCellValue(j, "productname").ToString();
                                        row["nserie"] = dgb_codigos.GetRowCellValue(j, "nserie").ToString();
                                        row["lineaid"] = dgb_codigos.GetRowCellValue(j, "lineaid").ToString();
                                        row["lineaname"] = dgb_codigos.GetRowCellValue(j, "lineaname").ToString();
                                        row["grupoid"] = dgb_codigos.GetRowCellValue(j, "grupoid").ToString();
                                        row["gruponame"] = dgb_codigos.GetRowCellValue(j, "gruponame").ToString();
                                        row["subgrupoid"] = dgb_codigos.GetRowCellValue(j, "subgrupoid").ToString();
                                        row["subgrupoartic"] = dgb_codigos.GetRowCellValue(j, "subgrupoartic").ToString();
                                        row["cantidad"] = "1".ToString();
                                        TablaProductos.Rows.Add(row);
                                    }
                                    AddRowTable();
                                    mdi_dgbcodigos.DataSource = TablaProductos;

                                    dgb_codigos.SetRowCellValue(nFilaAnt + 1, "productid", fila["productid"].ToString());
                                    dgb_codigos.SetRowCellValue(nFilaAnt + 1, "productname", fila["productname"].ToString());
                                    dgb_codigos.SetRowCellValue(nFilaAnt + 1, "nserie", fila["nserie"].ToString());
                                    dgb_codigos.SetRowCellValue(nFilaAnt + 1, "lineaid", fila["lineaid"].ToString());
                                    dgb_codigos.SetRowCellValue(nFilaAnt + 1, "lineaname", fila["lineaname"].ToString());
                                    dgb_codigos.SetRowCellValue(nFilaAnt + 1, "grupoid", fila["grupoid"].ToString());
                                    dgb_codigos.SetRowCellValue(nFilaAnt + 1, "gruponame", fila["gruponame"].ToString());
                                    dgb_codigos.SetRowCellValue(nFilaAnt + 1, "subgrupoid", fila["subgrupoid"].ToString());
                                    dgb_codigos.SetRowCellValue(nFilaAnt + 1, "subgrupoartic", fila["subgrupoartic"].ToString());
                                    dgb_codigos.SetRowCellValue(nFilaAnt + 1, "cantidad","1".ToString());
                                }
                                else
                                {
                                    dgb_codigos.SetRowCellValue(nFilaAnt, "productid", fila["productid"].ToString());
                                    dgb_codigos.SetRowCellValue(nFilaAnt, "productname", fila["productname"].ToString());
                                    dgb_codigos.SetRowCellValue(nFilaAnt, "nserie", fila["nserie"].ToString());
                                    dgb_codigos.SetRowCellValue(nFilaAnt, "lineaid", fila["lineaid"].ToString());
                                    dgb_codigos.SetRowCellValue(nFilaAnt, "lineaname", fila["lineaname"].ToString());
                                    dgb_codigos.SetRowCellValue(nFilaAnt, "grupoid", fila["grupoid"].ToString());
                                    dgb_codigos.SetRowCellValue(nFilaAnt, "gruponame", fila["gruponame"].ToString());
                                    dgb_codigos.SetRowCellValue(nFilaAnt, "subgrupoid", fila["subgrupoid"].ToString());
                                    dgb_codigos.SetRowCellValue(nFilaAnt, "subgrupoartic", fila["subgrupoartic"].ToString());
                                    dgb_codigos.SetRowCellValue(nFilaAnt, "cantidad", "1".ToString());
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
        }

        private void _serdoc_Properties_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                String numdo = "";
                if (_serdoc.Text.Trim().Length > 0)
                {
                    numdo = _serdoc.Text.Trim().PadLeft(4, '0');
                }
                _serdoc.Text = numdo;
                _numdoc.Focus();
            }
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Add_Detalle();         
        }

        private void Add_Detalle()
        {
            try
            {
                if (this.dgb_codigos.RowCount > 0)
                {
                    int nFilaAnt = dgb_codigos.RowCount - 1;
                    if (dgb_codigos.GetRowCellValue(dgb_codigos.RowCount - 1, "productid").ToString().Trim().Length == 13)
                    {
                        TablaProductos = new DataTable();
                        ArmarTabla();
                        for (int j = 0; j < dgb_codigos.RowCount; j++)
                        {
                            row = TablaProductos.NewRow();
                            row["productid"] = dgb_codigos.GetRowCellValue(j,"productid").ToString();
                            row["productname"] = dgb_codigos.GetRowCellValue(j, "productname").ToString();
                            row["nserie"] = dgb_codigos.GetRowCellValue(j, "nserie").ToString();
                            row["lineaid"] = dgb_codigos.GetRowCellValue(j, "lineaid").ToString();
                            row["lineaname"] = dgb_codigos.GetRowCellValue(j, "lineaname").ToString();
                            row["grupoid"] = dgb_codigos.GetRowCellValue(j, "grupoid").ToString();
                            row["gruponame"] = dgb_codigos.GetRowCellValue(j, "gruponame").ToString();
                            row["subgrupoid"] = dgb_codigos.GetRowCellValue(j, "subgrupoid").ToString();
                            row["subgrupoartic"] = dgb_codigos.GetRowCellValue(j, "subgrupoartic").ToString();
                            row["cantidad"] = "1".ToString();
                            
                            TablaProductos.Rows.Add(row);
                        }
                        AddRowTable();      
                        mdi_dgbcodigos.DataSource = TablaProductos;
                    }
                    else
                    {
                        MessageBox.Show("Ingrese producto !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {           
                    AddRowTable();
                    mdi_dgbcodigos.DataSource = TablaProductos;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dgb_codigos.DeleteRow(dgb_codigos.FocusedRowHandle);
        }

        private void Frm_Imprime_Codbar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)                
            {
                Add_Detalle();
            }    
                     
            if (e.KeyCode == Keys.Delete)
            {
                dgb_codigos.DeleteRow(dgb_codigos.FocusedRowHandle);
            }
        }

        private void mdi_dgbcodigos_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    if (dgb_codigos.FocusedColumn == dgb_codigos.Columns[0])
                    {
                        AyudaProductos("");
                    }
                }

                if (e.KeyCode == Keys.Delete)
                {
                    dgb_codigos.SetFocusedRowCellValue("productid", "_");
                    dgb_codigos.SetFocusedRowCellValue("productname", "_");
                    dgb_codigos.SetFocusedRowCellValue("lineaid", "_");
                    dgb_codigos.SetFocusedRowCellValue("lineaname", "_");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AyudaProductos(String Query)
        {
            try
            {
                Ayudas.HELP_GRID.Frm_help_producto frmayuda = new Ayudas.HELP_GRID.Frm_help_producto();    

                frmayuda.tipoo = "sql"; //sql,tabla
                frmayuda.titulo = "AYUDA PRODUCTOS";
                frmayuda.sqlquery = "SELECT "+
                                        "dbo.tb_me_productos.productid, " +
                                        "dbo.tb_me_productos.productname, " +
                                        "dbo.tb_me_productos.nserie, " +
	                                    "dbo.tb_me_productos.lineaid, "+
	                                    "dbo.tb_me_linea.lineaname, "+
	                                    "dbo.tb_me_productos.grupoid, "+
	                                    "dbo.tb_me_grupo.gruponame, "+
	                                    "dbo.tb_me_productos.subgrupoid, "+
	                                    "dbo.tb_me_subgrupo.subgrupoartic "+	                                    
                                    "FROM "+
	                                    "dbo.tb_me_productos "+
	                                    "INNER JOIN dbo.tb_me_subgrupo ON dbo.tb_me_productos.moduloid = dbo.tb_me_subgrupo.moduloid "+
		                                    "AND dbo.tb_me_productos.lineaid = dbo.tb_me_subgrupo.lineaid "+
		                                    "AND dbo.tb_me_productos.grupoid = dbo.tb_me_subgrupo.grupoid "+
		                                    "AND dbo.tb_me_productos.subgrupoid = dbo.tb_me_subgrupo.subgrupoid "+
	                                    "INNER JOIN dbo.tb_me_linea ON dbo.tb_me_subgrupo.moduloid = dbo.tb_me_linea.moduloid "+
		                                    "AND dbo.tb_me_subgrupo.lineaid = dbo.tb_me_linea.lineaid "+
	                                    "INNER JOIN dbo.tb_me_grupo ON dbo.tb_me_subgrupo.moduloid = dbo.tb_me_grupo.moduloid "+
		                                    "AND dbo.tb_me_subgrupo.grupoid = dbo.tb_me_grupo.grupoid ";

                frmayuda.sqlinner = ""; //inner
                frmayuda.sqlwhere = "WHERE "+
	                                "dbo.tb_me_productos.moduloid = '0100' "; //where
                frmayuda.sqland = "and";//and
                frmayuda.criteriosbusqueda = new string[] { "PRODUCTOS","CODIGO" };
                frmayuda.columbusqueda = "productname,productid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeProductos;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        private void RecibeProductos(DataTable dtresultado)
        {
            try
            {
                if (dtresultado.Rows.Count > 0)
                {
                    int cont = 0;
                    foreach (DataRow fila in dtresultado.Rows)
                    {
                        cont = cont + 1;
                        if (this.dgb_codigos.RowCount > 0)
                        {
                            int nFilaAnt = dgb_codigos.RowCount - 1;                                         
                            if (cont > 1)
                            {
                                TablaProductos = new DataTable();
                                ArmarTabla();
                                for (int j = 0; j < dgb_codigos.RowCount; j++)
                                {
                                    row = TablaProductos.NewRow();
                                    row["productid"] = dgb_codigos.GetRowCellValue(j, "productid").ToString();
                                    row["productname"] = dgb_codigos.GetRowCellValue(j, "productname").ToString();
                                    row["nserie"] = dgb_codigos.GetRowCellValue(j, "nserie").ToString();
                                    row["lineaid"] = dgb_codigos.GetRowCellValue(j, "lineaid").ToString();
                                    row["lineaname"] = dgb_codigos.GetRowCellValue(j, "lineaname").ToString();
                                    row["grupoid"] = dgb_codigos.GetRowCellValue(j, "grupoid").ToString();
                                    row["gruponame"] = dgb_codigos.GetRowCellValue(j, "gruponame").ToString();
                                    row["subgrupoid"] = dgb_codigos.GetRowCellValue(j, "subgrupoid").ToString();
                                    row["subgrupoartic"] = dgb_codigos.GetRowCellValue(j, "subgrupoartic").ToString();
                                    row["cantidad"] = "1".ToString();
                                    TablaProductos.Rows.Add(row);
                                }
                                AddRowTable();
                                mdi_dgbcodigos.DataSource = TablaProductos;

                                dgb_codigos.SetRowCellValue(nFilaAnt + 1, "productid", fila["productid"].ToString());
                                dgb_codigos.SetRowCellValue(nFilaAnt + 1, "productname", fila["productname"].ToString());
                                dgb_codigos.SetRowCellValue(nFilaAnt + 1, "nserie", fila["nserie"].ToString());
                                dgb_codigos.SetRowCellValue(nFilaAnt + 1, "lineaid", fila["lineaid"].ToString());
                                dgb_codigos.SetRowCellValue(nFilaAnt + 1, "lineaname", fila["lineaname"].ToString());
                                dgb_codigos.SetRowCellValue(nFilaAnt + 1, "grupoid", fila["grupoid"].ToString());
                                dgb_codigos.SetRowCellValue(nFilaAnt + 1, "gruponame", fila["gruponame"].ToString());
                                dgb_codigos.SetRowCellValue(nFilaAnt + 1, "subgrupoid", fila["subgrupoid"].ToString());
                                dgb_codigos.SetRowCellValue(nFilaAnt + 1, "subgrupoartic", fila["subgrupoartic"].ToString());
                                dgb_codigos.SetRowCellValue(nFilaAnt + 1, "cantidad", "1".ToString());                                
                            }
                            else
                            {
                                dgb_codigos.SetRowCellValue(nFilaAnt, "productid", fila["productid"].ToString());
                                dgb_codigos.SetRowCellValue(nFilaAnt, "productname", fila["productname"].ToString());
                                dgb_codigos.SetRowCellValue(nFilaAnt, "nserie", fila["nserie"].ToString());
                                dgb_codigos.SetRowCellValue(nFilaAnt, "lineaid", fila["lineaid"].ToString());
                                dgb_codigos.SetRowCellValue(nFilaAnt, "lineaname", fila["lineaname"].ToString());
                                dgb_codigos.SetRowCellValue(nFilaAnt, "grupoid", fila["grupoid"].ToString());
                                dgb_codigos.SetRowCellValue(nFilaAnt, "gruponame", fila["gruponame"].ToString());
                                dgb_codigos.SetRowCellValue(nFilaAnt, "subgrupoid", fila["subgrupoid"].ToString());
                                dgb_codigos.SetRowCellValue(nFilaAnt, "subgrupoartic", fila["subgrupoartic"].ToString());
                                dgb_codigos.SetRowCellValue(nFilaAnt, "cantidad", "1".ToString());                       
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

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            
            if (rdb_print.SelectedIndex == 0)
            {
                Imprimir_barcode_z4000();
            }
            else {
                Imprimir_barcode_EPL();
            }
        }

        IPEndPoint printerIP;
        private void Imprimir_barcode_z4000()
        {           
            #region »» Variables ««
            String CRTLF = Convert.ToString(Equivalencias.Chr(13)) + Convert.ToString(Equivalencias.Chr(10));

            String X11 = "^XA^MCY^XZ";
            String X12 = "^XA";
            String X13 = "^LRN^FWN^CFD,24^LH0,0";
            String X14 = "^CI0^PR2^MNY^MTT^MMT^MD0^PON^PMN";
            String X15 = "^XZ";
            String X16 = "^XA";

            String X55 = "^PQ1,0,1,Y";
            String X66 = "^XZ";
            String X77 = "^XA";

            /*** Variables para Tickets ***/

            String TW101 = "^FT29,28^A0N,20,19^FH\n^FD";
            String TW102 = "^FT29,54^A0N,20,19^FH\n^FD";
            String TW103 = "^FT29,81^A0N,20,19^FH\n^FD";
            String TW104 = "^FT29,106^A0N,20,19^FH\n^FD";
            String TW105 = "^FT102,28^A0N,20,19^FH\n^FD";
            String TW106 = "^FT102,54^A0N,20,19^FH\n^FD";
            String TW107 = "^FT102,81^A0N,20,19^FH\n^FD";
            String TW108 = "^FT102,106^A0N,20,19^FH\n^FD";
            String TW109 = "^BY2,3,48^FT37,167^BAN,,N,N^FD";
            String TW110 = "^FT124,191^A0N,20,19^FH\n^FD";

            String TW201 = "^FT459,28^A0N,20,19^FH\n^FD";
            String TW202 = "^FT459,54^A0N,20,19^FH\n^FD";
            String TW203 = "^FT459,81^A0N,20,19^FH\n^FD";
            String TW204 = "^FT459,106^A0N,20,19^FH\n^FD";
            String TW205 = "^FT532,28^A0N,20,19^FH\n^FD";
            String TW206 = "^FT532,54^A0N,20,19^FH\n^FD";
            String TW207 = "^FT532,81^A0N,20,19^FH\n^FD";
            String TW208 = "^FT532,106^A0N,20,19^FH\n^FD";
            String TW209 = "^BY2,3,48^FT467,167^BAN,,N,N^FD";
            String TW210 = "^FT554,191^A0N,20,19^FH\n^FD";

            #endregion

            String pTEXTO = "";
            Int16 nConFile = 0;
            int xStick = 0;
            String xComa = "";            
            xStick = xStick + 1;

            String xTW01 = "", xTW02 = "", xTW03 = "", xTW04 = "", xTW05 = "",
                      xTW06 = "", xTW07 = "", xTW08 = "", xTW09 = "", xTW10 = "";

            for (int i = 0; i < dgb_codigos.RowCount; i++)
            {
                Int32 xcanti = Convert.ToInt32(dgb_codigos.GetRowCellValue(i, "cantidad").ToString());
                Int32 xnum = 1;
                while (xnum <= xcanti)
                {                   
                    xTW01 = "Linea :";
                    xTW02 = "Marca :";
                    xTW03 = "Modelo:";
                    xTW04 = "Serie :";

                    xTW05 = dgb_codigos.GetRowCellValue(i, "lineaname").ToString();
                    xTW06 = dgb_codigos.GetRowCellValue(i, "gruponame").ToString();
                    xTW07 = dgb_codigos.GetRowCellValue(i, "subgrupoartic").ToString();
                    xTW08 = dgb_codigos.GetRowCellValue(i, "nserie").ToString();
                    xTW09 = dgb_codigos.GetRowCellValue(i, "productid").ToString();
                    xTW10 = dgb_codigos.GetRowCellValue(i, "productid").ToString();

                    switch (xStick)
                    {
                        case 1:
                            /*** Inicializa Impresora ***/
                            pTEXTO = pTEXTO + X11 + CRTLF;
                            pTEXTO = pTEXTO + X12 + CRTLF;
                            pTEXTO = pTEXTO + X13 + CRTLF;
                            pTEXTO = pTEXTO + X14 + CRTLF;
                            pTEXTO = pTEXTO + X15 + CRTLF;
                            pTEXTO = pTEXTO + X16 + CRTLF;

                            pTEXTO = pTEXTO + TW101 + xTW01 + "^FS" + CRTLF;
                            pTEXTO = pTEXTO + TW102 + xTW02 + "^FS" + CRTLF;
                            pTEXTO = pTEXTO + TW103 + xTW03 + "^FS" + CRTLF;
                            pTEXTO = pTEXTO + TW104 + xTW04 + "^FS" + CRTLF;
                            pTEXTO = pTEXTO + TW105 + xTW05 + "^FS" + CRTLF;
                            pTEXTO = pTEXTO + TW106 + xTW06 + "^FS" + CRTLF;
                            pTEXTO = pTEXTO + TW107 + xTW07 + "^FS" + CRTLF;
                            pTEXTO = pTEXTO + TW108 + xTW08 + "^FS" + CRTLF;
                            pTEXTO = pTEXTO + TW109 + xTW09 + "^FS" + CRTLF;
                            pTEXTO = pTEXTO + TW110 + xTW10 + "^FS" + CRTLF;

                            xStick = xStick + 1;
                            break;
                        case 2:
                            pTEXTO = pTEXTO + TW201 + xTW01 + "^FS" + CRTLF;
                            pTEXTO = pTEXTO + TW202 + xTW02 + "^FS" + CRTLF;
                            pTEXTO = pTEXTO + TW203 + xTW03 + "^FS" + CRTLF;
                            pTEXTO = pTEXTO + TW204 + xTW04 + "^FS" + CRTLF;
                            pTEXTO = pTEXTO + TW205 + xTW05 + "^FS" + CRTLF;
                            pTEXTO = pTEXTO + TW206 + xTW06 + "^FS" + CRTLF;
                            pTEXTO = pTEXTO + TW207 + xTW07 + "^FS" + CRTLF;
                            pTEXTO = pTEXTO + TW208 + xTW08 + "^FS" + CRTLF;
                            pTEXTO = pTEXTO + TW209 + xTW09 + "^FS" + CRTLF;
                            pTEXTO = pTEXTO + TW210 + xTW10 + "^FS" + CRTLF;

                            pTEXTO = pTEXTO + X55 + CRTLF;
                            pTEXTO = pTEXTO + X66 + CRTLF;
                            pTEXTO = pTEXTO + X77 + CRTLF;

                            xStick = 1;
                            break;
                    }
                    xnum = xnum + 1;
                }                                             
            }


            if (xStick == 2)
            {
                pTEXTO = pTEXTO + X55 + CRTLF;
                pTEXTO = pTEXTO + X66 + CRTLF;
                pTEXTO = pTEXTO + X77 + CRTLF;
            }

            //*** creando archivo de texto

            try
            {
                // Llamamos al Formulario de Vista Previa
                Ayudas.Frm_vistaprevia frm = new Ayudas.Frm_vistaprevia();
                frm.detalle = pTEXTO.ToString();
                frm.ShowDialog();    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString());
            }
        }

        private void Imprimir_barcode_EPL()
        {
            #region »» Variables ««
            String CRTLF = Convert.ToString(Equivalencias.Chr(13)) + Convert.ToString(Equivalencias.Chr(10));

            String X11 = "I8,A";
            String X12 = "q812";
            String X13 = "OD";
            String X14 = "JF";
            String X15 = "WN";
            String X16 = "ZT";
            String X17 = "Q208,25";
            String X18 = "N";


            String X88 = "P1";
            String X89 = "N";

            /*** Variables para Tickets ***/

            String xComi = "\"";

            String TW101 = "A787,173,2,2,1,1,N," + xComi; 		//Linea:"
            String TW102 = "A699,173,2,2,1,1,N," + xComi;		//MONITOR"
            String TW103 = "A787,149,2,2,1,1,N," + xComi;		//Marca:"
            String TW104 = "A699,149,2,2,1,1,N," + xComi;		//LG"
            String TW105 = "A787,125,2,2,1,1,N," + xComi;		//Modelo:"
            String TW106 = "A699,125,2,2,1,1,N," + xComi;		//FLATRON L17753T"
            String TW107 = "A787,101,2,2,1,1,N," + xComi;		//Serie:"
            String TW108 = "A699,101,2,2,1,1,N," + xComi;		//703NDRFAT5379"
            String TW109 = "B787,79,2,9,2,4,54,N," + xComi;    //0010047001002"
            String TW110 = "A691,21,2,2,1,1,N," + xComi;	    //0010047001002"

            String TW201 = "A369,173,2,2,1,1,N," + xComi;		//Linea:"
            String TW202 = "A281,173,2,2,1,1,N," + xComi;		//MONITOR"
            String TW203 = "A369,149,2,2,1,1,N," + xComi;		//Marca:"
            String TW204 = "A281,149,2,2,1,1,N," + xComi;		//LG"
            String TW205 = "A369,125,2,2,1,1,N," + xComi;		//Modelo:"
            String TW206 = "A281,125,2,2,1,1,N," + xComi;		//FLATRON L17753T"
            String TW207 = "A369,101,2,2,1,1,N," + xComi;		//Serie:"
            String TW208 = "A281,101,2,2,1,1,N," + xComi;		//703NDRFAT5379"
            String TW209 = "B369,79,2,9,2,4,54,N," + xComi;	//0010047001002"
            String TW210 = "A273,21,2,2,1,1,N," + xComi;		//0010047001002"

            #endregion

            String pTEXTO = "";            
            int xStick = 0;           

            xStick = xStick + 1;

            /*** Inicializa Impresora ***/
            pTEXTO = pTEXTO + X11 + CRTLF;
            pTEXTO = pTEXTO + X12 + CRTLF;
            pTEXTO = pTEXTO + X13 + CRTLF;
            pTEXTO = pTEXTO + X14 + CRTLF;
            pTEXTO = pTEXTO + X15 + CRTLF;
            pTEXTO = pTEXTO + X16 + CRTLF;
            pTEXTO = pTEXTO + X17 + CRTLF;
            pTEXTO = pTEXTO + X18 + CRTLF;


            for (int i = 0; i < dgb_codigos.RowCount; i++)
            {
                String xTW01 = "", xTW02 = "", xTW03 = "", xTW04 = "", xTW05 = "",
                       xTW06 = "", xTW07 = "", xTW08 = "", xTW09 = "", xTW10 = "";

                Int32 xcanti = Convert.ToInt32(dgb_codigos.GetRowCellValue(i, "cantidad").ToString());
                Int32 xnum = 1;
                while (xnum <= xcanti)
                {
                    xTW01 = "Linea :";
                    xTW02 = dgb_codigos.GetRowCellValue(i, "lineaname").ToString();
                    xTW03 = "Marca :";
                    xTW04 = dgb_codigos.GetRowCellValue(i, "gruponame").ToString();
                    xTW05 = "Modelo:";
                    xTW06 = dgb_codigos.GetRowCellValue(i, "subgrupoartic").ToString();
                    xTW07 = "Serie :";
                    xTW08 = dgb_codigos.GetRowCellValue(i, "nserie").ToString();
                    xTW09 = dgb_codigos.GetRowCellValue(i, "productid").ToString();
                    xTW10 = dgb_codigos.GetRowCellValue(i, "productid").ToString();

                    switch (xStick)
                    {
                        case 1:

                            pTEXTO = pTEXTO + TW101 + xTW01 + xComi + CRTLF;
                            pTEXTO = pTEXTO + TW102 + xTW02 + xComi + CRTLF;
                            pTEXTO = pTEXTO + TW103 + xTW03 + xComi + CRTLF;
                            pTEXTO = pTEXTO + TW104 + xTW04 + xComi + CRTLF;
                            pTEXTO = pTEXTO + TW105 + xTW05 + xComi + CRTLF;
                            pTEXTO = pTEXTO + TW106 + xTW06 + xComi + CRTLF;
                            pTEXTO = pTEXTO + TW107 + xTW07 + xComi + CRTLF;
                            pTEXTO = pTEXTO + TW108 + xTW08 + xComi + CRTLF;
                            pTEXTO = pTEXTO + TW109 + xTW09 + xComi + CRTLF;
                            pTEXTO = pTEXTO + TW110 + xTW10 + xComi + CRTLF;

                            xStick = xStick + 1;
                            break;
                        case 2:
                            pTEXTO = pTEXTO + TW201 + xTW01 + xComi + CRTLF;
                            pTEXTO = pTEXTO + TW202 + xTW02 + xComi + CRTLF;
                            pTEXTO = pTEXTO + TW203 + xTW03 + xComi + CRTLF;
                            pTEXTO = pTEXTO + TW204 + xTW04 + xComi + CRTLF;
                            pTEXTO = pTEXTO + TW205 + xTW05 + xComi + CRTLF;
                            pTEXTO = pTEXTO + TW206 + xTW06 + xComi + CRTLF;
                            pTEXTO = pTEXTO + TW207 + xTW07 + xComi + CRTLF;
                            pTEXTO = pTEXTO + TW208 + xTW08 + xComi + CRTLF;
                            pTEXTO = pTEXTO + TW209 + xTW09 + xComi + CRTLF;
                            pTEXTO = pTEXTO + TW210 + xTW10 + xComi + CRTLF;
                            pTEXTO = pTEXTO + X88 + CRTLF;
                            pTEXTO = pTEXTO + X89 + CRTLF;

                            xStick = 1;
                            break;
                    }
                    xnum = xnum + 1;
                }
            }


            if (xStick == 2)
            {
                pTEXTO = pTEXTO + X88 + CRTLF;
                pTEXTO = pTEXTO + X89 + CRTLF;
            }

            //*** creando archivo de texto

            try
            {
               // Llamamos al Formulario de Vista Previa
                Ayudas.Frm_vistaprevia frm = new Ayudas.Frm_vistaprevia();
                frm.detalle = pTEXTO.ToString();
                frm.ShowDialog();                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString());
            }
        }

        private void btnUltimo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnNew.Enabled = true;
            btnCancel.Enabled = false;
            limpiar();
            bloquear(false);
        }



    }
}
