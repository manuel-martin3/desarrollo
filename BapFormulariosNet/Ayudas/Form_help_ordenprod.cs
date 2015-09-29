using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using LayerDataAccess;
using LayerBusinessEntities;
using LayerBusinessLogic;

using bapFunciones;

namespace BapFormulariosNet.Ayudas
{
    public partial class Form_help_ordenprod : Form
    {
        public delegate void PasaDataDelegate(DataTable dtresultado);

        public PasaDataDelegate PasaData;
        public bool _LeerCombo = true;
        public string _NombreDetalle = string.Empty;

        private bool Inicializa = true;
        private DataTable Tabladet;
        private DataRow row;
        public String tipoo { get; set; }
        public Boolean GetAll { get; set; }

        public DataTable tabla;
        public String sqlquery { get; set; }
        public String sqlinner { get; set; }
        public String sqlwhere { get; set; }
        public String sqland { get; set; }
        public String sqlgroupby { get; set; }
        public String sqlor { get; set; }
        public String[] criteriosbusqueda { get; set; }
        public String columbusqueda { get; set; }
        public String returndatos { get; set; }
        public String resultado01 { get; set; }
        public String resultado02 { get; set; }
        public String resultado03 { get; set; }
        public String resultado04 { get; set; }
        public String resultado05 { get; set; }
        public string titulo { get; set; }
        public String xfamiliaid { get; set; }
        public String xmoduloid { get; set; }

        private String sql = string.Empty;

        public Form_help_ordenprod()
        {
            InitializeComponent();          
            gridgeneral.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(gridgeneral_RowHeaderMouseClick);
            cbo_criterios.SelectedIndex = -1;
        }

        private void consulta_tabla()
        {
            var datos = new DataTable();
            datos = tabla.Clone();
            datos.Rows.Clear();
            var camposbusqueda = sqlquery.Split(',');
            if (sqlwhere != null && sqlwhere.Trim().Length > 0)
            {
                var dr = tabla.Select(sqlwhere);
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
        }     

        private void _recarga()
        {
            gridgeneral.Columns["chk"].ReadOnly = false;
            gridgeneral.Columns["ordenprod"].ReadOnly = true;
            gridgeneral.Columns["articidold"].ReadOnly = true;
            gridgeneral.Columns["articname"].ReadOnly = true;
            gridgeneral.Columns["marcaname"].ReadOnly = true;
            gridgeneral.Columns["lineaname"].ReadOnly = true;
            gridgeneral.Columns["generoname"].ReadOnly = true;            
        }

        private void consulta_sql()
        {
            try
            {
                if (txt_busqueda.Text.Trim().Length == 0 && GetAll == false)
                {
                    return;
                }

                sql = string.Empty;
                var s = txt_busqueda.Text.Trim();

                var parametro = (int)cbo_criterios.SelectedIndex;
                var camposbusqueda = columbusqueda.Split(',');
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
                sql = sqlquery + " " + sqlinner + " " + sqlwhere + " " + sqland + " " + sql + " " + sqlgroupby;

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
                sql = string.Empty;
                var s = txt_busqueda.Text.Trim();
                var parametro = (int)cbo_criterios.SelectedIndex;
                var camposbusqueda = columbusqueda.Split(',');
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
                sql = sqlquery + " " + sqlinner + " " + sqlwhere + " " + sqland + " " + sql + " " + sqlgroupby;

                datosgeneral(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void datosgeneral(String sqldata)
        {
            var conex = new ConexionDA();
            var dt = new DataTable();

            using (var cnx = new SqlConnection(conex.empConexion(VariablesPublicas.EmpresaID)))
            {
                using (var cmd = new SqlCommand("gspHelpSQL", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@sqlquery", SqlDbType.VarChar).Value = sqldata;
                    try
                    {
                        cnx.Open();
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                gridgeneral.AutoGenerateColumns = true;
                                gridgeneral.DataSource = dt;
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

        private DataTable ProdMov(String Query)
        {
            var conex = new ConexionDA();
            var dt = new DataTable();
            using (var cnx = new SqlConnection(conex.empConexion(VariablesPublicas.EmpresaID)))
            {
                using (var cmd = new SqlCommand("gspHelpSQL", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@sqlquery", SqlDbType.VarChar).Value = Query;

                    try
                    {
                        cnx.Open();
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            return dt;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        private void datos_seleccionados()
        {
            var xselec = false;

            try
            {
                
                foreach (DataGridViewRow fila in gridgeneral.Rows)
                {
                    xselec = false;
                    foreach (DataGridViewColumn col in gridgeneral.Columns)
                    {
                        if (gridgeneral.Columns[col.Index].Name == "chk")
                        {
                            xselec = (gridgeneral.Rows[fila.Index].Cells["chk"].Value != null ? (Boolean)gridgeneral.Rows[fila.Index].Cells["chk"].Value : false);
                            break;
                        }
                    }

                    if (xselec == true)
                    {
                        row = Tabladet.NewRow();
                        row["ordenprod"] = gridgeneral.Rows[fila.Index].Cells["ordenprod"].Value;
                        row["articid"] = gridgeneral.Rows[fila.Index].Cells["articid"].Value;
                        row["articidold"] = gridgeneral.Rows[fila.Index].Cells["articidold"].Value;
                        row["articname"] = gridgeneral.Rows[fila.Index].Cells["articname"].Value;
                        row["marcaid"] = gridgeneral.Rows[fila.Index].Cells["marcaid"].Value;
                        row["marcaname"] = gridgeneral.Rows[fila.Index].Cells["marcaname"].Value;
                        row["lineaid"] = gridgeneral.Rows[fila.Index].Cells["lineaid"].Value;
                        row["lineaname"] = gridgeneral.Rows[fila.Index].Cells["lineaname"].Value;
                        row["generoid"] = gridgeneral.Rows[fila.Index].Cells["generoid"].Value;
                        row["generoname"] = gridgeneral.Rows[fila.Index].Cells["generoname"].Value;
                        Tabladet.Rows.Add(row);
                    }
                }

                PasaData(Tabladet);
                Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void datos_seleccionados2()
        {
            if ((gridgeneral.CurrentRow != null))
            {
                if ((PasaData != null))
                {
                    var col = 0;
                    var columnas = returndatos.Split(',');
                    col = columnas.Length;

                    if (col == 1)
                    {
                        PasaData(Tabladet);
                    }
                    else
                    {
                        if (col == 2)
                        {
                            PasaData(Tabladet);
                        }
                        else
                        {
                            if (col == 3)
                            {
                                PasaData(Tabladet);
                            }
                            else
                            {
                                if (col == 4)
                                {
                                    PasaData(Tabladet);
                                }
                                else
                                {
                                    if (col == 5)
                                    {
                                        PasaData(Tabladet);
                                    }
                                }
                            }
                        }
                    }
                }
                Close();
            }
        }

        private void Frm_help_general_Activated(object sender, EventArgs e)
        {
            if (Inicializa)
            {
                //FormBorderStyle = FormBorderStyle.Sizable;
                //Inicializa = false;
                Text = titulo;

                var datos = criteriosbusqueda;
                cbo_criterios.DataSource = datos;
            }
        }

        private void Frm_help_general_Load(object sender, EventArgs e)
        {          
           
            Tabladet = new DataTable("detallemov");

            Tabladet.Columns.Add("chk", typeof(Boolean));
            Tabladet.Columns.Add("ordenprod", typeof(String));
            Tabladet.Columns.Add("articid", typeof(String));
            Tabladet.Columns.Add("articidold", typeof(String));
            Tabladet.Columns.Add("articname", typeof(String));
            Tabladet.Columns.Add("marcaid", typeof(String));
            Tabladet.Columns.Add("marcaname", typeof(String));
            Tabladet.Columns.Add("lineaid", typeof(String));
            Tabladet.Columns.Add("lineaname", typeof(String));
            Tabladet.Columns.Add("generoid", typeof(String));
            Tabladet.Columns.Add("generoname", typeof(String));            

            //FormBorderStyle = FormBorderStyle.Fixed3D;
            //MaximizeBox = false;
            //MinimizeBox = false;

            txt_busqueda.Focus();

            if (tipoo.Trim() == "all")
            {
                consulta_all();
            }
            txt_busqueda.Focus();
        }       

        private void Frm_help_general_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape))
            {
                Close();
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
                    else
                    {
                        if (tipoo.Trim() == "all")
                        {
                            consulta_all();
                        }
                        else
                        {
                            consulta_tabla();
                        }
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
                else
                {
                    if (tipoo.Trim() == "all")
                    {
                        consulta_all();
                    }
                    else
                    {
                        consulta_tabla();
                    }
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
            Close();
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            datos_seleccionados();
        }

        private void gridgeneral_DoubleClick(object sender, EventArgs e)
        {
        }

        private void gridgeneral_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            }
        }
       
        private void gridgeneral_RowHeaderMouseClick(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            if (gridgeneral.CurrentRow != null)
            {
                gridgeneral.Rows[gridgeneral.CurrentRow.Index].Selected = true;
            }
        }

        private void U_pINTAR()
        {
            if (1 == 1)
            {
                int LC_CONT, LC_NCOLUMNA;
                for (LC_CONT = 0; LC_CONT < gridgeneral.RowCount; LC_CONT++)
                {
                    if (gridgeneral.Rows[LC_CONT].Cells["status"].Value.ToString() == "9")
                    {
                        for (LC_NCOLUMNA = 0; LC_NCOLUMNA < gridgeneral.ColumnCount; LC_NCOLUMNA++)
                        {
                        }
                    }
                    else
                    {
                        for (LC_NCOLUMNA = 0; LC_NCOLUMNA < gridgeneral.ColumnCount; LC_NCOLUMNA++)
                        {
                        }
                    }
                }
            }
        }

        private void txt_busqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (tipoo.Trim() == "sql")
                    {
                        consulta_sql();
                    }
                    else
                    {
                        if (tipoo.Trim() == "all")
                        {
                            consulta_all();
                        }
                        else
                        {
                            consulta_tabla();
                        }
                    }
                    _recarga();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



    }
}
