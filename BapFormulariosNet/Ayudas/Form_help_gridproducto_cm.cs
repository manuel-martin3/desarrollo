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
using LayerDataAccess;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.Ayudas
{
    public partial class Form_help_gridproducto_cm : Form
    {
        public delegate void PasaProveedorDelegate(DataTable dtresultado);

        public PasaProveedorDelegate PasaProveedor;
        public bool _LeerCombo = true;
        public string _NombreDetalle = "";

        private bool Inicializa = true;
        DataTable Tabladet;
        private DataRow row;

        #region *** Variables generales

        private String _tipoo;
        public String tipoo
        {
            get { return _tipoo; }

            set { _tipoo = value; }
        }

        private Boolean _GetAll;
        public Boolean GetAll
        {
            get { return _GetAll; }

            set { _GetAll = value; }
        }

        public DataTable tabla;

        private String _sqlquery;
        public String sqlquery
        {
            get { return _sqlquery; }

            set { _sqlquery = value; }
        }

        private String _sqlinner;
        public String sqlinner
        {
            get { return _sqlinner; }

            set { _sqlinner = value; }
        }

        
        private String _sqlwhere;
        public String sqlwhere
        {
            get { return _sqlwhere; }

            set { _sqlwhere = value; }
        }

        private String _sqlgroupby;
        public String sqlgroupby
        {
            get { return _sqlgroupby; }
            set { _sqlgroupby = value; }
        }

        private String _sqland;
        public String sqland
        {
            get { return _sqland; }

            set { _sqland = value; }
        }


        private String _sqlor;
        public String sqlor
        {
            get { return _sqlor; }

            set { _sqlor = value; }
        }

        private String[] _criteriosbusqueda;
        public String[] criteriosbusqueda
        {
            get { return _criteriosbusqueda; }

            set { _criteriosbusqueda = value; }
        }

        private String _columbusqueda;
        public String columbusqueda
        {
            get { return _columbusqueda; }

            set { _columbusqueda = value; }
        }

        private String _returndatos;
        public String returndatos
        {
            get { return _returndatos; }

            set { _returndatos = value; }
        }

        private String _resultado01;
        public String resultado01
        {
            get { return _resultado01; }

            set { _resultado01 = value; }
        }

        private String _resultado02;
        public String resultado02
        {
            get { return _resultado02; }

            set { _resultado02 = value; }
        }

        private String _resultado03;
        public String resultado03
        {
            get { return _resultado03; }

            set { _resultado03 = value; }
        }

        private String _resultado04;
        public String resultado04
        {
            get { return _resultado04; }

            set { _resultado04 = value; }
        }

        private String _resultado05;
        public String resultado05
        {
            get { return _resultado05; }

            set { _resultado05 = value; }
        }
        private string _titulo;
        public string titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }
        #endregion

        private String sql = "";

        public Form_help_gridproducto_cm()
        {
            InitializeComponent();
            checkboxColumn();
            gridgeneral.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(gridgeneral_RowHeaderMouseClick);
            cbo_criterios.SelectedIndex = -1;
        }

        #region *** Metodos generales
        private void consulta_tabla()
        {
            DataTable datos = new DataTable();
            datos = tabla.Clone();
            datos.Rows.Clear();
            String[] camposbusqueda = sqlquery.Split(',');
            if (sqlwhere != null && sqlwhere.Trim().Length > 0)
            {
                DataRow[] dr = tabla.Select(sqlwhere);
                if (dr.Length > 0)
                {
                    foreach (DataRow row in dr)
                    {
                        datos.ImportRow(row);
                    }
                }
            }
            else
            {
                datos = tabla.Copy();
            }

            gridgeneral.DataSource = datos.DefaultView.ToTable(false, camposbusqueda);

            //gridgeneral.DataSource = tabla.DefaultView.ToTable(true, "articid", "articname");
        }

        #region **** CheckBoxColumn
        void checkboxColumn() {
            DataGridViewCheckBoxColumn CheckboxColumn = new DataGridViewCheckBoxColumn();
            CheckboxColumn.TrueValue = true;
            CheckboxColumn.FalseValue = false;
            CheckboxColumn.Width = 100;
            CheckboxColumn.Name = "chk";
            gridgeneral.Columns.Add(CheckboxColumn);        
        }
        #endregion

        #region *** Valida Edicion True / False
        private void _recarga()
        {
            gridgeneral.Columns["chk"].ReadOnly = false;
            gridgeneral.Columns["productid"].ReadOnly = true;
            gridgeneral.Columns["productname"].ReadOnly = true;
            gridgeneral.Columns["stock"].ReadOnly = true;
            gridgeneral.Columns["costoultimo"].ReadOnly = true;
            //gridgeneral.Columns["local"].ReadOnly = true; 
        }
        #endregion

        private void consulta_sql()
        {
            try
            {
                if (txt_busqueda.Text.Trim().Length == 0 && GetAll == false)
                {
                    return;
                }

                sql = "";

                String s = txt_busqueda.Text.Trim();

                int parametro = (int)cbo_criterios.SelectedIndex;
                String[] camposbusqueda = columbusqueda.Split(',');
                switch (parametro)
                {
                    case 0:
                        sql = camposbusqueda[0] + " like '%" + s + "%'";
                        break;
                    case 1:
                        sql = camposbusqueda[1] + " like '" + s + "%'";
                        break;
                    case 2:
                        sql = camposbusqueda[2] + " like '%" + s + "%'";
                        break;
                    case 3:
                        sql = camposbusqueda[3] + " like '%" + s + "%'";
                        break;
                    case 4:
                        sql = camposbusqueda[4] + " like '%" + s + "%'";
                        break;
                }
                sql = sqlquery + " " + sqlinner + " " + sqlwhere + " " + sqland + " " + sql + " " + (sqlgroupby==null?"":sqlgroupby);

                datosgeneral(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void consulta_all()
        {
            try
            {

                sql = "";
                String s = txt_busqueda.Text.Trim();
                int parametro = (int)cbo_criterios.SelectedIndex;
                String[] camposbusqueda = columbusqueda.Split(',');
                switch (parametro)
                {
                    case 0:
                        sql = camposbusqueda[0] + " like '%" + s + "%'";
                        break;
                    case 1:
                        sql = camposbusqueda[1] + " like '" + s + "%'";
                        break;
                    case 2:
                        sql = camposbusqueda[2] + " like '%" + s + "%'";
                        break;
                    case 3:
                        sql = camposbusqueda[3] + " like '%" + s + "%'";
                        break;
                    case 4:
                        sql = camposbusqueda[4] + " like '%" + s + "%'";
                        break;
                }
                sql = sqlquery + " " + sqlinner + " " + sqlwhere + " " + sqland + " " + sql;

                datosgeneral(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void datosgeneral(String sqldata)
        {
            ConexionDA conex = new ConexionDA();
            DataSet ds = new DataSet();

            using (SqlConnection cnx = new SqlConnection(conex.empConexion(VariablesPublicas.EmpresaID)))
            {
                using (SqlCommand cmd = new SqlCommand("gspHelpSQL", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@sqlquery", SqlDbType.VarChar).Value = sqldata;
                    }
                    try
                    {
                        cnx.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);

                            if (ds.Tables[0].Rows.Count > 0 && gridgeneral.RowCount > 0)
                            {
                                this.gridgeneral.Focus();
                                this.gridgeneral.BeginEdit(false);
                            }
                            this.gridgeneral.AutoGenerateColumns = true;
                            gridgeneral.DataSource = ds.Tables[0];
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void datos_seleccionados()
        {
            Boolean xselec = false;

            try
            {
                foreach (DataGridViewRow fila in gridgeneral.Rows)
                {
                    xselec = false;
                    foreach (DataGridViewColumn col in gridgeneral.Columns)
                    {
                        if (gridgeneral.Columns[col.Index].Name == "chk")
                        {
                            xselec = (this.gridgeneral.Rows[fila.Index].Cells["chk"].Value!=null? (Boolean)this.gridgeneral.Rows[fila.Index].Cells["chk"].Value: false);
                            break;
                        }
                    }

                    if (xselec == true)
                    {
                        row = Tabladet.NewRow();
                        row["productid"] = this.gridgeneral.Rows[fila.Index].Cells["productid"].Value;
                        row["productname"] = this.gridgeneral.Rows[fila.Index].Cells["productname"].Value;
                        row["stock"] = this.gridgeneral.Rows[fila.Index].Cells["stock"].Value;
                        row["costoultimo"] = this.gridgeneral.Rows[fila.Index].Cells["costoultimo"].Value;
                        //row["unmedenvase"] = this.gridgeneral.Rows[fila.Index].Cells["unmedenvase"].Value;
                        Tabladet.Rows.Add(row);
                    }
                }

                PasaProveedor(Tabladet);
                this.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void datos_seleccionados2()
        {
            if ((this.gridgeneral.CurrentRow != null))
            {
                if ((PasaProveedor != null))
                {
                    int col = 0;
                    String[] columnas = returndatos.Split(',');
                    col = columnas.Length;

                    if (col == 1)
                    {
                        this.PasaProveedor(Tabladet);
                    }
                    else if (col == 2)
                    {
                        this.PasaProveedor(Tabladet);
                    }
                    else if (col == 3)
                    {
                        this.PasaProveedor(Tabladet);
                    }
                    else if (col == 4)
                    {
                        this.PasaProveedor(Tabladet);
                    }
                    else if (col == 5)
                    {
                        this.PasaProveedor(Tabladet);
                    }

                }
                this.Close();
            }
        }
        #endregion



        private void Frm_help_general_Activated(object sender, EventArgs e)
        {
            if (this.Inicializa)
            {               
                this.Inicializa = false;
                this.Text = titulo;

                String[] datos = criteriosbusqueda;
                cbo_criterios.DataSource = datos;
                this.txt_busqueda.Focus();    
            }
        }


        private void Frm_help_general_Load(object sender, EventArgs e)
        {

            Tabladet = new DataTable("detallemov");

            Tabladet.Columns.Add("chk", typeof(Boolean));
            Tabladet.Columns.Add("productid", typeof(String));
            Tabladet.Columns.Add("productname", typeof(String));
            Tabladet.Columns.Add("stock", typeof(Decimal)); Tabladet.Columns["stock"].DefaultValue = 0;
            Tabladet.Columns.Add("costoultimo", typeof(Decimal)); Tabladet.Columns["costoultimo"].DefaultValue = 0;
            //Tabladet.Columns.Add("unmedenvase", typeof(String)); Tabladet.Columns["unmedenvase"].DefaultValue = "";
            //Tabladet.Columns.Add("local", typeof(String));
            this.txt_busqueda.Focus();           

        }

        private void Frm_help_general_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape))
            {
                this.Close();
            }
        }

        private void txt_busqueda_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter)
                {
                    if (tipoo.Trim() == "sql")
                    {
                        consulta_sql();
                    }
                    else if (tipoo.Trim() == "all")
                    {
                        consulta_all();
                    }
                    else
                    {
                        consulta_tabla();
                    }

                    _recarga();
                }

                if (e.KeyCode != Keys.Enter)
                {
                    txt_busqueda.Focus();
                }
                else
                {
                    gridgeneral.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tipoo.Trim() == "sql")
                {
                    consulta_sql();
                }
                else if (tipoo.Trim() == "all")
                {
                    consulta_all();
                }
                else
                {
                    consulta_tabla();
                }

                _recarga();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            this.datos_seleccionados();
        }
        private void gridgeneral_DoubleClick(object sender, EventArgs e)
        {
            //this.datos_seleccionados();
        }
        private void gridgeneral_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //this.datos_seleccionados();
            }
        }
        private void gridgeneral_RowHeaderMouseClick(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            if (this.gridgeneral.CurrentRow != null)
            {
                this.gridgeneral.Rows[this.gridgeneral.CurrentRow.Index].Selected = true;
            }
        }

        void U_pINTAR()
        {
            if (1 == 1)
            {
                int LC_CONT, LC_NCOLUMNA;
                for (LC_CONT = 0; LC_CONT < this.gridgeneral.RowCount; LC_CONT++)
                {
                    if (this.gridgeneral.Rows[LC_CONT].Cells["status"].Value.ToString() == "9")
                    {
                        for (LC_NCOLUMNA = 0; LC_NCOLUMNA < this.gridgeneral.ColumnCount; LC_NCOLUMNA++)
                        {
                            /*this.GridExaminar.Rows[LC_CONT].DefaultCellStyle.BackColor = this.lblregseleccionado.BackColor;
                            this.GridExaminar.Rows[LC_CONT].DefaultCellStyle.ForeColor = this.lblregseleccionado.ForeColor;*/
                        }
                    }
                    else
                    {
                        for (LC_NCOLUMNA = 0; LC_NCOLUMNA < this.gridgeneral.ColumnCount; LC_NCOLUMNA++)
                        {
                            //this.GridExaminar.Rows[LC_CONT].DefaultCellStyle.BackColor = Color.White;
                            //this.GridExaminar.Rows[LC_CONT].DefaultCellStyle.ForeColor = Color.Black;                          
                        }
                    }
                }
            }
        }       
       
    }

}
