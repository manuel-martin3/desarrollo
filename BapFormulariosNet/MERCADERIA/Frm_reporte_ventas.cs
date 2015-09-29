using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using LayerDataAccess;
using bapFunciones;

using System;
using System.Data;
using System.Data.SqlClient;


namespace BapFormulariosNet.MERCADERIA
{
    public partial class Frm_reporte_ventas : plantilla
    {
        private ConexionDA conex = new ConexionDA();
        private SqlConnection cnx;
        private SqlCommand cmd;
        private DataTable Tabla = new DataTable();

        public Frm_reporte_ventas()
        {
            InitializeComponent();
        }

        private void Frm_reporte_ventas_Load(object sender, EventArgs e)
        {
            data_cbo_moduloiddes();
        }


        private void data_cbo_moduloiddes()
        {
            try
            {
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                BE.dominioid = "60";
                BE.status = "0";

                var dt = new DataTable();
                dt = BL.GetAll(VariablesPublicas.EmpresaID, BE).Tables[0];
                cbo_modulo.DataSource = dt;
                cbo_modulo.ValueMember = "moduloid";
                cbo_modulo.DisplayMember = "moduloname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void _CargarDatos()
        {
            try
            {
                cnx = new SqlConnection(conex.empConexion(VariablesPublicas.EmpresaID));
                cmd = new SqlCommand("Select sl.localname," +
                                               " CONVERT(varchar,md.fechdoc,103) as fechdoc," +
                                               " SUM(cantidad) as cantidad," +
                                               " SUM(importe) as importe," +
                                               " 0 as efectivo," +
                                               " 0 as tarjeta" +
                                        " From tb_me_movimientosdet md " +
                                         "   INNER JOIN tb_me_movimientoscab mc on md.moduloid = mc.moduloid " +
                                             "   AND md.local = mc.local " +
                                             "   AND md.tipodoc = mc.tipodoc" +
                                             "   AND md.serdoc = mc.serdoc " +
                                             "   AND md.numdoc = mc.numdoc " +
                                            " INNER JOIN tb_sys_local sl ON md.moduloid = sl.moduloid " +
                                             "   AND md.local = sl.local " +
                                             "   AND sl.status = '0' " +
                                             "   AND sl.dominioid = '60' " +
                                        " Where md.moduloid = '0100' " +
                                        "      AND md.tipoperacionid = '01' " +
                                        " Group by sl.localname,md.fechdoc,mc.efectivo " +
                                        " ORDER by md.fechdoc ", cnx);

                cnx.Open();
                using (var da = new SqlDataAdapter(cmd))
                {
                    (Tabla).Clear();
                    da.Fill(Tabla);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnx.Close();
            }

            Examinar.DataSource = Tabla;
            Examinar.RefreshDataSource();
        }



        private void exportarAExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfdruta.ShowDialog(this) == DialogResult.OK)
            {
                Examinar3.ExportToXls(sfdruta.FileName);
            }
        }

        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            var BL = new tb_me_movimientosBL();
            var BE = new tb_me_movimientos();

            BE.moduloid = cbo_modulo.SelectedValue.ToString();
            BE.fechdocini = Convert.ToDateTime(fechdocini.Text.Substring(0, 10));
            BE.fechdocfin = Convert.ToDateTime(fechdocfin.Text.Substring(0, 10));
            BE.filtro = "1";

            Tabla = BL.GetReportDetalle(VariablesPublicas.EmpresaID , BE).Tables[0];

            Examinar.DataSource = Tabla;
            Examinar.RefreshDataSource();
        }




        private void cbo_modulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_modulo.SelectedIndex != -1)
            {
                get_dominio_modulo_local("60", cbo_modulo.SelectedValue.ToString());
            }
        }

        private void get_dominio_modulo_local(string dominioid, string moduloid)
        {
            var BL = new usuariomodulolocalBL();
            var BE = new tb_usuariomodulolocal();
            BE.usuar = VariablesPublicas.Usuar.Trim();
            BE.dominioid = dominioid;
            BE.moduloid = moduloid;

            try
            {
                cbo_local.DataSource = BL.GetAll3(VariablesPublicas.EmpresaID, BE).Tables[0];
                cbo_local.ValueMember = "local";
                cbo_local.DisplayMember = "localname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Examinar_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void Examinar_MouseClick(object sender, MouseEventArgs e)
        {
            var xlocal = string.Empty;
            var xmoduloid = string.Empty;
            var BL = new tb_me_movimientosBL();
            var BE = new tb_me_movimientos();
            var dt = new DataTable();

            if (gv_examinar.DataRowCount > 0)
            {
                xlocal = gv_examinar.GetFocusedRowCellValue("local").ToString();
                xmoduloid = gv_examinar.GetFocusedRowCellValue("moduloid").ToString();
                BE.moduloid = xmoduloid.ToString();
                BE.local = xlocal.ToString();
                BE.fechdocini = Convert.ToDateTime(fechdocini.Text.Substring(0, 10));
                BE.fechdocfin = Convert.ToDateTime(fechdocfin.Text.Substring(0, 10));
                BE.filtro = "2";

                dt = BL.GetReportDetalle(VariablesPublicas.EmpresaID, BE).Tables[0];

                Examinar2.DataSource = dt;
                Examinar2.RefreshDataSource();
            }
            else
            {
                Examinar2.DataSource = dt;
                Examinar2.RefreshDataSource();
            }
        }

        private void Examinar2_MouseClick(object sender, MouseEventArgs e)
        {
            var xlocal = string.Empty;
            var xmoduloid = string.Empty;
            var xnumdoc1 = string.Empty;
            var xnumdoc2 = string.Empty;
            var BL = new tb_me_movimientosBL();
            var BE = new tb_me_movimientos();
            var dt = new DataTable();

            if (gv_examinar.DataRowCount > 0)
            {
                xlocal = gv_examinar.GetFocusedRowCellValue("local").ToString();
                xmoduloid = gv_examinar2.GetFocusedRowCellValue("moduloid").ToString();
                xnumdoc1 = gv_examinar2.GetFocusedRowCellValue("numdoc1").ToString();
                xnumdoc2 = gv_examinar2.GetFocusedRowCellValue("numdoc2").ToString();

                BE.moduloid = xmoduloid.ToString();
                BE.local = xlocal.ToString();
                BE.fechdocini = Convert.ToDateTime(fechdocini.Text.Substring(0, 10));
                BE.fechdocfin = Convert.ToDateTime(fechdocfin.Text.Substring(0, 10));
                BE.xnumdoc1 = xnumdoc1.ToString();
                BE.xnumdoc2 = xnumdoc2.ToString();
                BE.filtro = "3";

                dt = BL.GetReportDetalle(VariablesPublicas.EmpresaID, BE).Tables[0];

                Examinar3.DataSource = dt;
                Examinar3.RefreshDataSource();
            }
            else
            {
                Examinar3.DataSource = dt;
                Examinar3.RefreshDataSource();
            }
        }
    }
}
