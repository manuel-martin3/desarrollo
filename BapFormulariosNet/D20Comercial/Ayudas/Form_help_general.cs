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
using DevExpress.XtraEditors;

namespace BapFormulariosNet.D20Comercial.Ayudas
{
    public partial class Frm_help_general : plantilla
    {
        public delegate void PasaProveedorDelegate(String resultado01, String resultado02, String resultado03, String resultado04, String resultado05);

        public PasaProveedorDelegate PasaProveedor;
        public bool _LeerCombo = true;
        public string _NombreDetalle = "";

        private bool Inicializa = true;

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

        public Frm_help_general()
        {
            InitializeComponent();

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
        private void consulta_sql()
        {
            try
            {
                if (txt_busqueda.Text.Trim().Length == 0 && GetAll ==false)
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
                sql = sqlquery + " " + sqlinner + " " + sqlwhere + " " + sqland + " " + sql;

                datosgeneral(sql);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void consulta_sqlall()
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
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void datosgeneral(String sqldata)
        {
            Conexion conex = new Conexion();
            DataSet ds = new DataSet();

            //using (SqlConnection cnx = new SqlConnection(conex.empConexion("02")))
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
                                gridgeneral.Focus();
                                gridgeneral.BeginEdit(false);
                            }
                            gridgeneral.AutoGenerateColumns = true;
                            gridgeneral.DataSource = ds.Tables[0];
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
        public void datos_seleccionados()
        {
            if ((gridgeneral.CurrentRow != null))
            {
                if ((PasaProveedor != null))
                {
                    int col = 0;
                    String[] columnas = returndatos.Split(',');
                    col = columnas.Length;

                    if (col == 1)
                    {
                        PasaProveedor(
                            gridgeneral.Rows[gridgeneral.CurrentCell.RowIndex].Cells[Convert.ToInt16(columnas[0])].Value.ToString(),
                            null,
                            null,
                            null,
                            null
                        );
                    }
                    else if (col == 2)
                    {
                        PasaProveedor(
                            gridgeneral.Rows[gridgeneral.CurrentCell.RowIndex].Cells[Convert.ToInt16(columnas[0])].Value.ToString(),
                            gridgeneral.Rows[gridgeneral.CurrentCell.RowIndex].Cells[Convert.ToInt16(columnas[1])].Value.ToString(),
                            null,
                            null,
                            null
                        );
                    }
                    else if (col == 3)
                    {
                        PasaProveedor(
                            gridgeneral.Rows[gridgeneral.CurrentCell.RowIndex].Cells[Convert.ToInt16(columnas[0])].Value.ToString(),
                            gridgeneral.Rows[gridgeneral.CurrentCell.RowIndex].Cells[Convert.ToInt16(columnas[1])].Value.ToString(),
                            gridgeneral.Rows[gridgeneral.CurrentCell.RowIndex].Cells[Convert.ToInt16(columnas[2])].Value.ToString(),
                            null,
                            null
                        );
                    }
                    else if (col == 4)
                    {
                        PasaProveedor(
                            gridgeneral.Rows[gridgeneral.CurrentCell.RowIndex].Cells[Convert.ToInt16(columnas[0])].Value.ToString(),
                            gridgeneral.Rows[gridgeneral.CurrentCell.RowIndex].Cells[Convert.ToInt16(columnas[1])].Value.ToString(),
                            gridgeneral.Rows[gridgeneral.CurrentCell.RowIndex].Cells[Convert.ToInt16(columnas[2])].Value.ToString(),
                            gridgeneral.Rows[gridgeneral.CurrentCell.RowIndex].Cells[Convert.ToInt16(columnas[3])].Value.ToString(),
                            null
                        );
                    }
                    else if (col == 5)
                    {
                        PasaProveedor(
                            gridgeneral.Rows[gridgeneral.CurrentCell.RowIndex].Cells[Convert.ToInt16(columnas[0])].Value.ToString(),
                            gridgeneral.Rows[gridgeneral.CurrentCell.RowIndex].Cells[Convert.ToInt16(columnas[1])].Value.ToString(),
                            gridgeneral.Rows[gridgeneral.CurrentCell.RowIndex].Cells[Convert.ToInt16(columnas[2])].Value.ToString(),
                            gridgeneral.Rows[gridgeneral.CurrentCell.RowIndex].Cells[Convert.ToInt16(columnas[3])].Value.ToString(),
                            gridgeneral.Rows[gridgeneral.CurrentCell.RowIndex].Cells[Convert.ToInt16(columnas[4])].Value.ToString()
                        );
                    }

                }
                Close();
            }
        }
        #endregion

        private void Frm_help_general_Activated(object sender, EventArgs e)
        {
            if (Inicializa)
            {
                Inicializa = false;
                Text = titulo;

                String[] datos = criteriosbusqueda;
                cbo_criterios.DataSource = datos;
            }
        }
        private void Frm_help_general_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

            txt_busqueda.Focus();
            VariablesPublicas.PintaEncabezados(gridgeneral);
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
                if (tipoo.Trim() == "sql")
                {
                    consulta_sql();
                }
                else if (tipoo.Trim() == "sqlall")
                {
                    consulta_sqlall();
                }
                else
                {
                    consulta_tabla();
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
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    consulta_tabla();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            datos_seleccionados();
        }
        private void gridgeneral_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                datos_seleccionados();
            }
        }
        private void gridgeneral_RowHeaderMouseClick(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            if (gridgeneral.CurrentRow != null)
            {
                gridgeneral.Rows[gridgeneral.CurrentRow.Index].Selected = true;
            }
        }

        void U_pINTAR()
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
                            /*GridExaminar.Rows[LC_CONT].DefaultCellStyle.BackColor = lblregseleccionado.BackColor;
                            GridExaminar.Rows[LC_CONT].DefaultCellStyle.ForeColor = lblregseleccionado.ForeColor;*/
                        }
                    }
                    else
                    {
                        for (LC_NCOLUMNA = 0; LC_NCOLUMNA < gridgeneral.ColumnCount; LC_NCOLUMNA++)
                        {
                            //GridExaminar.Rows[LC_CONT].DefaultCellStyle.BackColor = Color.White;
                            //GridExaminar.Rows[LC_CONT].DefaultCellStyle.ForeColor = Color.Black;                          
                        }
                    }
                }
            }
        }
    }
}
