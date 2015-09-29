using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using LayerDataAccess;
using bapFunciones;

namespace BapFormulariosNet.Ayudas
{
    public partial class Frm_help_array : Form
    {
        public delegate void PasaProveedorDelegate(String[] resultados);

        public PasaProveedorDelegate PasaProveedor;
        public bool _LeerCombo = true;
        public string _NombreDetalle = string.Empty;

        private bool Inicializa = true;
        public String tipoo { get; set; }
        public Boolean GetAll { get; set; }

        public DataTable tabla;
        public String nameform { get; set; }
        public String sqlquery { get; set; }
        public String sqlinner { get; set; }
        public String sqlwhere { get; set; }
        public String sqland { get; set; }
        public String sqlor { get; set; }
        public String[] criteriosbusqueda { get; set; }
        public String columbusqueda { get; set; }
        public String returndatos { get; set; }
        public String[] resutados { get; set; }
        public int resulcolumnas { get; set; }
        public string titulo { get; set; }

        private String sql = string.Empty;

        public Frm_help_array()
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
                        sql = camposbusqueda[1] + " like '%" + s + "%'";
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
                        sql = camposbusqueda[1] + " like '%" + s + "%'";
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

                            if (nameform == "color")
                            {
                                if (VariablesPublicas.Moduloid == "0500")
                                {
                                    foreach (DataGridViewRow fila in gridgeneral.Rows)
                                    {
                                        var xproductidold = string.Empty;

                                        if (gridgeneral.ColumnCount >= 4)
                                        {
                                            if (gridgeneral.Columns[4].HeaderText == "productidold")
                                            {
                                                xproductidold = Convert.ToString(gridgeneral.Rows[fila.Index].Cells["productidold"].Value);

                                                if (xproductidold.Trim() != "0")
                                                {
                                                    gridgeneral.Rows[fila.Index].DefaultCellStyle.BackColor = Color.MediumSeaGreen;
                                                    gridgeneral.Rows[fila.Index].DefaultCellStyle.ForeColor = Color.White;
                                                }
                                            }
                                        }
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
        }

        public void datos_seleccionados()
        {
            if ((gridgeneral.CurrentRow != null))
            {
                if ((PasaProveedor != null))
                {
                    var col = 0;
                    var columnas = returndatos.Split(',');
                    col = columnas.Length;

                    var xresultado = new String[resulcolumnas];

                    for (var i = 0; i < resulcolumnas; i++)
                    {
                        xresultado[i] = gridgeneral.Rows[gridgeneral.CurrentCell.RowIndex].Cells[i].Value.ToString();
                    }

                    PasaProveedor(xresultado);
                }
                Close();
            }
        }

        private void Frm_help_general_Activated(object sender, EventArgs e)
        {
            if (Inicializa)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                Inicializa = false;
                Text = titulo;

                var datos = criteriosbusqueda;
                cbo_criterios.DataSource = datos;
            }
            txt_busqueda.Focus();
        }
        private void Frm_help_general_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;

            txt_busqueda.Focus();

            if (tipoo.Trim() == "all")
            {
                consulta_all();
            }
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
    }
}
