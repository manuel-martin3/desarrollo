using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.D60Tienda.Administracion
{
    public partial class Frm_planilla_comision_mensual : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String Xmodulo = string.Empty;
        private String Xlocal = string.Empty;
        private String Xdominio = string.Empty;

        private DataTable TablaPlanillaComision;


        public Frm_planilla_comision_mensual()
        {
            InitializeComponent();
        }

        private void Frm_planilla_comision_Load(object sender, EventArgs e)
        {
            Xdominio = ((D60Tienda.MainTienda)MdiParent).dominioid;
            Xmodulo = ((D60Tienda.MainTienda)MdiParent).moduloid;
            Xlocal = ((D60Tienda.MainTienda)MdiParent).local;

            _CargarAnio();
            _CargarMes();
            _CargarLocales();
            _CargarCategoria();
            LimpiarDocumento();
            Bloqueo(false);
        }


        private void _CargarAnio()
        {
            var BL = new tb_perianioBL();
            List<tb_perianio> LISTA = null;

            LISTA = BL.Get_anio(EmpresaID);
            cmb_perianio.DataSource = LISTA;
            cmb_perianio.DisplayMember = "perianio";
            cmb_perianio.ValueMember = "codigo";
        }

        private void _CargarMes()
        {
            var BL = new tb_perimesBL();
            List<tb_perimes> LISTA = null;
            LISTA = BL.Get_Mes(EmpresaID);
            cmb_perimes2.DataSource = LISTA;
            cmb_perimes2.ValueMember = "perimesid";
            cmb_perimes2.DisplayMember = "perimesname";
        }

        private void _CargarCategoria()
        {
            var BL = new tb_me_categoriaplanillaBL();
            var BE = new tb_me_categoriaplanilla();
            var tbCategoria = new DataTable();
            tbCategoria = BL.GetAll(EmpresaID, BE).Tables[0];

            if (tbCategoria.Rows.Count > 0)
            {
                cmb_categoria.DataSource = tbCategoria;
                cmb_categoria.ValueMember = "cateplanid";
                cmb_categoria.DisplayMember = "cateplanname";
            }
        }

        private void _CargarLocales()
        {
            var BL = new usuariomodulolocalBL();
            var BE = new tb_usuariomodulolocal();
            BE.usuar = VariablesPublicas.Usuar.Trim();
            var dt = new DataTable();
            BE.dominioid = Xdominio.ToString();
            BE.moduloid = Xmodulo.ToString();

            try
            {
                dt = BL.GetAll3(VariablesPublicas.EmpresaID, BE).Tables[0];
                cmb_local.DataSource = dt;
                cmb_local.ValueMember = "local";
                cmb_local.DisplayMember = "localname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Data_TablaPlanillaComision()
        {
            try
            {
                TablaPlanillaComision = new DataTable();

                if (TablaPlanillaComision.Rows.Count > 0)
                {
                    TablaPlanillaComision.Rows.Clear();
                }
                var BL = new tb_me_planillacomisionBL();
                var BE = new tb_me_planillacomision();

                if (cmb_perianio.SelectedIndex != -1 && chk_anio.Checked == true)
                {
                    BE.perianio = cmb_perianio.SelectedValue.ToString();
                }
                if (cmb_perimes2.SelectedIndex != -1 && chk_mes.Checked == true)
                {
                    BE.perimes = cmb_perimes2.SelectedValue.ToString();
                }
                if (cmb_categoria.SelectedIndex != -1 && chk_cargo.Checked == true)
                {
                    BE.cateplanid = cmb_categoria.SelectedValue.ToString();
                }

                TablaPlanillaComision = BL.GetAll2(EmpresaID, BE).Tables[0];
                if (TablaPlanillaComision.Rows.Count > 0)
                {
                    MDI_dgb_planillacomision.DataSource = TablaPlanillaComision;
                }
                else
                {
                    MDI_dgb_planillacomision.DataSource = TablaPlanillaComision;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void _OcultandoColumnas()
        {
            dgb_planillacomision.Columns["cateplanname"].Visible = false;
            dgb_planillacomision.Columns["quincena"].Visible = false;
            dgb_planillacomision.Columns["cargoid"].Visible = false;

            if (cmb_categoria.SelectedValue.ToString() == "1" || cmb_categoria.SelectedValue.ToString() == "2")
            {
                dgb_planillacomision.Columns["vtaclasico"].Visible = false;
                dgb_planillacomision.Columns["vtamoda"].Visible = false;
                dgb_planillacomision.Columns["comiclasico"].Visible = false;
                dgb_planillacomision.Columns["comimoda"].Visible = false;
                dgb_planillacomision.Columns["impoclasico"].Visible = false;
                dgb_planillacomision.Columns["impomoda"].Visible = false;

                dgb_planillacomision.Columns["comicorriente"].Visible = true;
                dgb_planillacomision.Columns["comimayorold"].Visible = true;
                dgb_planillacomision.Columns["comicumplecuota"].Visible = true;
                dgb_planillacomision.Columns["impocorriente"].Visible = true;
                dgb_planillacomision.Columns["impomayorold"].Visible = true;
                dgb_planillacomision.Columns["impocumplecuota"].Visible = true;
                dgb_planillacomision.Columns["comicuotaefectivo"].Visible = true;
            }
            if (cmb_categoria.SelectedValue.ToString() == "3")
            {
                dgb_planillacomision.Columns["comicorriente"].Visible = false;
                dgb_planillacomision.Columns["comimayorold"].Visible = false;
                dgb_planillacomision.Columns["comicumplecuota"].Visible = false;
                dgb_planillacomision.Columns["impocorriente"].Visible = false;
                dgb_planillacomision.Columns["impomayorold"].Visible = false;
                dgb_planillacomision.Columns["impocumplecuota"].Visible = false;
                dgb_planillacomision.Columns["comicuotaefectivo"].Visible = false;

                dgb_planillacomision.Columns["vtaclasico"].Visible = true;
                dgb_planillacomision.Columns["vtamoda"].Visible = true;
                dgb_planillacomision.Columns["comiclasico"].Visible = true;
                dgb_planillacomision.Columns["comimoda"].Visible = true;
                dgb_planillacomision.Columns["impoclasico"].Visible = true;
                dgb_planillacomision.Columns["impomoda"].Visible = true;
            }

            if (cmb_categoria.SelectedValue.ToString() == "4")
            {
                dgb_planillacomision.Columns["vtaclasico"].Visible = false;
                dgb_planillacomision.Columns["vtamoda"].Visible = false;
                dgb_planillacomision.Columns["comiclasico"].Visible = false;
                dgb_planillacomision.Columns["comimoda"].Visible = false;
                dgb_planillacomision.Columns["impoclasico"].Visible = false;
                dgb_planillacomision.Columns["impomoda"].Visible = false;
                dgb_planillacomision.Columns["comicorriente"].Visible = false;
                dgb_planillacomision.Columns["comimayorold"].Visible = false;
                dgb_planillacomision.Columns["comicumplecuota"].Visible = false;
                dgb_planillacomision.Columns["impocorriente"].Visible = false;
                dgb_planillacomision.Columns["impomayorold"].Visible = false;
                dgb_planillacomision.Columns["impocumplecuota"].Visible = false;
                dgb_planillacomision.Columns["comicuotaefectivo"].Visible = false;
            }
        }

        private void LimpiarDocumento()
        {
            cmb_categoria.SelectedIndex = -1;
            cmb_local.SelectedIndex = -1;
            cmb_perianio.SelectedIndex = -1;
            cmb_perimes2.SelectedIndex = -1;
            cmb_quincena.SelectedIndex = -1;
        }

        private void Bloqueo(Boolean var)
        {
            cmb_categoria.Enabled = var;
            cmb_local.Enabled = var;
            cmb_perianio.Enabled = var;
            cmb_perimes2.Enabled = var;
            cmb_quincena.Enabled = var;
        }

        private void cmb_perianio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_perianio.SelectedIndex != -1 && chk_anio.Checked == true)
            {
                Data_TablaPlanillaComision();
            }
        }

        private void cmb_perimes2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_perimes2.SelectedIndex != -1 && chk_mes.Checked == true)
            {
                Data_TablaPlanillaComision();
            }
        }

        private void cmb_local_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmb_cargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_categoria.SelectedIndex != -1 && chk_cargo.Checked == true)
            {
                Data_TablaPlanillaComision();
            }
        }

        private void chk_anio_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_anio.Checked)
            {
                cmb_perianio.SelectedIndex = 0;
                cmb_perianio.Enabled = true;
            }
            else
            {
                cmb_perianio.SelectedIndex = -1;
                cmb_perianio.Enabled = false;
                Data_TablaPlanillaComision();
            }
        }

        private void chk_mes_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_mes.Checked)
            {
                cmb_perimes2.SelectedIndex = 0;
                cmb_perimes2.Enabled = true;
            }
            else
            {
                cmb_perimes2.SelectedIndex = -1;
                cmb_perimes2.Enabled = false;
                Data_TablaPlanillaComision();
            }
        }

        private void chk_tienda_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_tienda.Checked)
            {
                cmb_local.SelectedIndex = 0;
                cmb_local.Enabled = true;
            }
            else
            {
                cmb_local.SelectedIndex = -1;
                cmb_local.Enabled = false;
                Data_TablaPlanillaComision();
            }
        }

        private void chk_cargo_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_cargo.Checked)
            {
                cmb_categoria.SelectedIndex = 0;
                cmb_categoria.Enabled = true;
            }
            else
            {
                cmb_categoria.SelectedIndex = -1;
                cmb_categoria.Enabled = false;
                Data_TablaPlanillaComision();
            }
        }

        private void exportarExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfdplanilla.ShowDialog(this) == DialogResult.OK)
            {
                dgb_planillacomision.ExportToXls(sfdplanilla.FileName);
                OpenFile(sfdplanilla.FileName);
            }
        }

        private static void OpenFile(string fileName)
        {
            try
            {
                var process = new System.Diagnostics.Process();
                process.StartInfo.FileName = fileName;
                process.StartInfo.Verb = "Open";
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                process.Start();
            }
            catch
            {
                MessageBox.Show("No se puede encontrar una aplicación en el sistema adecuado para abrir el archivo con datos exportados.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chk_quincena_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_quincena.Checked)
            {
                cmb_quincena.SelectedIndex = 0;
                cmb_quincena.Enabled = true;
            }
            else
            {
                cmb_quincena.SelectedIndex = -1;
                cmb_quincena.Enabled = false;
                Data_TablaPlanillaComision();
            }
        }

        private void cmb_quincena_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_quincena.SelectedIndex != -1)
            {
                Data_TablaPlanillaComision();
            }
        }
    }
}
