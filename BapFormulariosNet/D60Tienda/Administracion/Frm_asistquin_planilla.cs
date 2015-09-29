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
    public partial class Frm_asistquin_planilla : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String xmodulo = string.Empty;
        private String xlocal = string.Empty;

        private DataTable TablaAsistQuinPlanilla;


        public Frm_asistquin_planilla()
        {
            InitializeComponent();
        }

        private void Frm_planilla_comision_Load(object sender, EventArgs e)
        {
            xmodulo = ((D60Tienda.MainTienda)MdiParent).moduloid;
            xlocal = ((D60Tienda.MainTienda)MdiParent).local;

            _CargarAnio();
            _CargarMes();
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

        private void Data_TablaAsistQuinPlanilla()
        {
            try
            {
                TablaAsistQuinPlanilla = new DataTable();

                if (TablaAsistQuinPlanilla.Rows.Count > 0)
                {
                    TablaAsistQuinPlanilla.Rows.Clear();
                }
                var BL = new tb_me_asistquinplanillaBL();
                var BE = new tb_me_asistquinplanilla();

                if (cmb_perianio.SelectedIndex != -1 && cmb_perianio.Text.Length == 4 )
                {
                    BE.perianio = cmb_perianio.SelectedValue.ToString();
                }
                if (cmb_perimes2.SelectedIndex != -1 && cmb_perimes2.SelectedIndex > 0)
                {
                    BE.perimes = cmb_perimes2.SelectedValue.ToString();
                }
                if (cmb_quincena.SelectedIndex != -1 && cmb_quincena.Text.Length == 1)
                {
                    BE.quincena = cmb_quincena.Text.ToString().Trim();
                }

                TablaAsistQuinPlanilla = BL.GetAll(EmpresaID, BE).Tables[0];
                if (TablaAsistQuinPlanilla.Rows.Count > 0)
                {
                    MDI_dgb_planillacomision.DataSource = TablaAsistQuinPlanilla;
                }
                else
                {
                    MDI_dgb_planillacomision.DataSource = TablaAsistQuinPlanilla;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarDocumento()
        {
            cmb_perianio.SelectedIndex = -1;
            cmb_perimes2.SelectedIndex = -1;
            cmb_quincena.SelectedIndex = -1;
        }

        private void Bloqueo(Boolean var)
        {
            cmb_perianio.Enabled = var;
            cmb_perimes2.Enabled = var;
            cmb_quincena.Enabled = var;
        }


        private void cmb_perianio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_perianio.SelectedIndex != -1)
            {
                Data_TablaAsistQuinPlanilla();
            }
        }

        private void cmb_perimes2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_perimes2.SelectedIndex != -1)
            {
                Data_TablaAsistQuinPlanilla();
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
                Data_TablaAsistQuinPlanilla();
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
                Data_TablaAsistQuinPlanilla();
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
                Data_TablaAsistQuinPlanilla();
            }
        }

        private void cmb_quincena_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_quincena.SelectedIndex != -1)
            {
                Data_TablaAsistQuinPlanilla();
            }
        }
    }
}
