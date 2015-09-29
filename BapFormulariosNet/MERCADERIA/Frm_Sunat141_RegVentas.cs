using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;

namespace BapFormulariosNet.MERCADERIA
{
    public partial class Frm_Sunat141_RegVentas : plantilla
    {
        private Genericas fungen = new Genericas();

        private String EmpresaID = string.Empty;
        private String dominio = string.Empty;
        private String modulo = string.Empty;
        private String local = string.Empty;
        private String perianio = string.Empty;
        private String perimes = string.Empty;

        private class Item
        {
            public string Name { get; set; }
            public int Value { get; set; }

            public Item(string name, int value)
            {
                Name = name;
                Value = value;
            }
            public override string ToString()
            {
                return Name;
            }
        }

        public Frm_Sunat141_RegVentas()
        {
            InitializeComponent();
        }

        private void Frm_Sunat141_RegVentas_Load(object sender, EventArgs e)
        {
            EmpresaID = VariablesPublicas.EmpresaID.Trim();
            dominio = ((MERCADERIA.MainMercaderia)MdiParent).dominioid;
            modulo = ((MERCADERIA.MainMercaderia)MdiParent).moduloid;
            local = ((MERCADERIA.MainMercaderia)MdiParent).local;

            fill_cboModuloid();
            fill_cboPerianio();
            fill_cboPerimes();

            //cboModuloid.SelectedValue = modulo;
            cboLocal.SelectedValue = local;

        }

        private void fill_cboModuloid()
        {
            var BL = new sys_dominioBL();
            try
            {
                cboModuloid.DataSource = BL.GetAllDominioModuloPorUsuario(VariablesPublicas.EmpresaID, VariablesPublicas.Usuar, "60").Tables[0];
                cboModuloid.ValueMember = "moduloid";
                cboModuloid.DisplayMember = "moduloname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cboModuloid.SelectedValue = modulo;

            if (cboModuloid.Items.Count > 0)
            {
                fill_cbolocal(dominio, cboModuloid.SelectedValue.ToString());
            }
        }

        private void fill_cbolocal(string dominioid, string moduloid)
        {
            var BL = new usuariomodulolocalBL();
            var BE = new tb_usuariomodulolocal();
            BE.usuar = VariablesPublicas.Usuar.Trim();
            var dt = new DataTable();
            BE.dominioid = dominioid;
            BE.moduloid = moduloid;

            try
            {
                dt = BL.GetAll3(VariablesPublicas.EmpresaID, BE).Tables[0];
                cboLocal.DataSource = dt;
                cboLocal.ValueMember = "local";
                cboLocal.DisplayMember = "localname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fill_cboPerianio()
        {
            int nMinAnio = DateTime.Today.Year-10;
            int nMaxAnio = DateTime.Today.Year;
            string cAnio = string.Empty;

            List<Item> lista = new List<Item>();
            for (int i = nMinAnio; i <= nMaxAnio; i++)
            {
                cAnio = Convert.ToString(i);
                lista.Add(new Item(cAnio, i));
            }

            cboPerianio.DataSource = lista;
            cboPerianio.DisplayMember = "Name";
            cboPerianio.ValueMember = "Value";

            cboPerianio.SelectedValue=DateTime.Today.Year;

            //Vaciar comboBox para que los items que vamos a añadir no se repitan
            //cboPerianio.Items.Clear();

            //Incluir dos items Hombre y Mujer
            //for (int i = nMinAnio; i < nMaxAnio; i++)
            //{
            //    cAnio = Convert.ToString(i);
            //    cboPerianio.Items.Add(new KeyValuePair<string, string>(cAnio, cAnio));
            //}

        }

        private void fill_cboPerimes()
        {
            int nMinMes = 1;
            int nMaxMes = 12;
            string cMes = string.Empty;

            List<Item> lista = new List<Item>();
            for (int i = nMinMes; i <= nMaxMes; i++)
            {
                cMes = Convert.ToString(i);
                lista.Add(new Item(cMes.Trim().PadLeft(2,'0')+"-"+fungen.get_mesCad(cMes.Trim().PadLeft(2,'0')), i));
            }

            cboPerimes.DataSource = lista;
            cboPerimes.DisplayMember = "Name";
            cboPerimes.ValueMember = "Value";

            cboPerimes.SelectedValue = DateTime.Today.Month;
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked)
               cboLocal.Enabled = false;
            else
               cboLocal.Enabled = true;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            var BL = new tb_me_movimientosBL();
            var BE = new tb_me_movimientoscab();
            var TablaDet = new DataTable();

            BE.moduloid = cboModuloid.SelectedValue.ToString();
            if (chkTodos.Checked)
            {
                BE.local = "";
            }
            else
            {
                BE.local = cboLocal.SelectedValue.ToString();
            }
            BE.perianio = cboPerianio.SelectedValue.ToString();
            BE.perimes = cboPerimes.SelectedValue.ToString().Trim().PadLeft(2,'0');

            //TablaMov_ordprod = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            TablaDet = BL.Sunat141_RegVentas(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            if (TablaDet.Rows.Count > 0)
            {
                ExportarExcel(TablaDet);
            }
        }

        private void ExportarExcel(DataTable TablaDet)
        {
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;

            try
            {
                oXL = new Excel.Application();
                oXL.Visible = false;

                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                oSheet.Cells[1, 1] = "status";
                oSheet.Cells[1, 2] = "fechdoc";
                oSheet.Cells[1, 3] = "tipdoc";
                oSheet.Cells[1, 4] = "maqreg";
                oSheet.Cells[1, 5] = "serdoc";
                oSheet.Cells[1, 6] = "numdoc";
                oSheet.Cells[1, 7] = "numdocfinal";
                oSheet.Cells[1, 8] = "tipdid";
                oSheet.Cells[1, 9] = "nmruc";
                oSheet.Cells[1, 10] = "ctactename";
                oSheet.Cells[1, 11] = "afectoigvid";
                oSheet.Cells[1, 12] = "baseimpo";
                oSheet.Cells[1, 13] = "inafecto";
                oSheet.Cells[1, 14] = "pigv";
                oSheet.Cells[1, 15] = "migv";
                oSheet.Cells[1, 16] = "total";
                oSheet.Cells[1, 17] = "estabsunat";
                oSheet.Cells[1, 18] = "cuentaid	";
                oSheet.Cells[1, 19] = "glosa";
                oSheet.Cells[1, 20] = "moneda";
                oSheet.Cells[1, 21] = "tipref";
                oSheet.Cells[1, 22] = "serref";
                oSheet.Cells[1, 23] = "numref";
                oSheet.Cells[1, 24] = "fechref";
                oSheet.Cells[1, 25] = "condicionpago";
                oSheet.Cells[1, 26] = "fechvcto";
                oSheet.Cells[1, 27] = "cencosid";
                oSheet.Cells[1, 28] = "cuentaidt";
                oSheet.Cells[1, 29] = "vendedorid";


                oSheet.get_Range("A1", "AC1").Font.Bold = true;
                oSheet.get_Range("A1", "AC1").Font.Color = Color.White;
                oSheet.get_Range("A1", "AC1").Interior.ColorIndex = 14;
                oSheet.get_Range("A1", "AC1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                var IndiceFila = 2;
                oSheet.Range["V:V"].NumberFormat = "dd/mm/yyyy";
                oSheet.Range["X:X"].NumberFormat = "dd/mm/yyyy";
                oSheet.Range["Z:Z"].NumberFormat = "dd/mm/yyyy";
                oSheet.Range["L:P"].NumberFormat = "_ * #,##0.00_ ;_ * -#,##0.00_ ;_ * -??_ ;_ @_ ";

                foreach (DataRow row in TablaDet.Rows)
                {
                    oSheet.Cells[IndiceFila, 01].Value = "'" + row["status"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 02].Value = "'" + row["fechdoc"];
                    oSheet.Cells[IndiceFila, 03].Value = "'" + row["tipdoc"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 04].Value = "'" + row["maqreg"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 05].Value = "'" + row["serdoc"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 06].Value = "'" + row["numdoc"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 07].Value = "'" + row["numdocfinal"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 08].Value = "'" + row["tipdid"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 09].Value = "'" + row["nmruc"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 10].Value = "'" + row["ctactename"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 11].Value = "'" + row["afectoigvid"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 12].Value = Math.Round(Convert.ToDecimal(row["baseimpo"]),2);
                    oSheet.Cells[IndiceFila, 13].Value = row["inafecto"];
                    oSheet.Cells[IndiceFila, 14].Value = row["pigv"];
                    oSheet.Cells[IndiceFila, 15].Value = Math.Round(Convert.ToDecimal(row["migv"]),2);
                    oSheet.Cells[IndiceFila, 16].Value = row["total"];
                    oSheet.Cells[IndiceFila, 17].Value = "'" + row["estabsunat"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 18].Value = "'" + row["cuentaid"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 19].Value = "'" + row["glosa"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 20].Value = "'" + row["moneda"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 21].Value = "'" + row["tipref"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 22].Value = "'" + row["serref"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 23].Value = "'" + row["numref"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 24].Value = "'" + row["fechref"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 25].Value = "'" + row["condicionpago"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 26].Value = "'" + row["fechvcto"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 27].Value = "'" + row["cencosid"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 28].Value = "'" + row["cuentaidt"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 29].Value = "'" + row["vendedorid"].ToString().Trim();


                    IndiceFila++;
                }

                oRng = oSheet.get_Range("A1", "AC1");
                oRng.EntireColumn.AutoFit();

                oSheet.Cells[2, 1].Select();
                oXL.ActiveWindow.FreezePanes = true;

                oXL.Visible = true;
                oXL.UserControl = true;

                MessageBox.Show("Exportación a Excel culminada", "Aviso");
            }
            catch (Exception ex)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, ex.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, ex.Source);

                MessageBox.Show(errorMessage, "Error");
            }
        }
    }
}
