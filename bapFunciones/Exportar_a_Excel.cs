using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.IO;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using bapFunciones;
using excel = Microsoft.Office.Interop.Excel;
using Interaction = Microsoft.VisualBasic.Interaction;
using System.Reflection;


namespace bapFunciones
{
    public class Exportar_a_Excel
    {
        public static void ExportToExcel(DataTable Tabla, string TituloHoja, string namecolumnafontbold, object[] valorcolumna, string nomfileaguardar)
        {
            // Variables Excel
            excel.Application oExcel;
            excel.Workbook oBook;
            excel.Workbooks oBooks;
            excel.Sheets objSheets;
            excel._Worksheet oSheet;
            excel.Range range;

            int lc_columna = 0;
            TituloHoja = TituloHoja.Replace("-", "");
            TituloHoja = VariablesPublicas.PADR(TituloHoja, 31, " ");
            TituloHoja = TituloHoja.Trim();
            int ROW_FIRST = 4;
            int iContador = 0;
            bool zCreateOKHoja = true;
            string vmxmsgerror = "";
            Form oform = new Form();

            try
            {
                oform.Text = "Espere.... Generando";
                Button btnAdd = new Button();
                btnAdd.AutoSize = true;
                btnAdd.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                btnAdd.Font = new System.Drawing.Font("Tahoma", 20);

                oform.StartPosition = FormStartPosition.CenterScreen;
                oform.ControlBox = false;
                oform.Controls.Add(btnAdd);
                btnAdd.Text = TituloHoja;
                oform.ShowInTaskbar = false;
                oform.Width = btnAdd.Width + 100;
                oform.Height = btnAdd.Height + 100;
                oform.Show();

                // Crear una instancia de Excel e iniciar un nuevo libro.
                oExcel = new excel.Application();
                oBooks = oExcel.Workbooks;
                oBook = oExcel.Workbooks.Add();
                objSheets = oBook.Worksheets;
                oSheet = (excel._Worksheet)objSheets.get_Item(1);

                if (TituloHoja.Trim().Length == 0)
                {
                }
                else
                {
                    oSheet.get_Range("A1", "E3").Font.Bold = true;
                    oSheet.Cells[1, 1] = VariablesPublicas.EmpresaName;
                    oSheet.get_Range("A1", "E1").Merge(Missing.Value);
                    oSheet.Cells[2, 1] = "Nº RUC " + VariablesPublicas.EmpresaRuc;
                    oSheet.get_Range("A2", "E2").Merge(Missing.Value);
                    oSheet.Cells[3,1] = TituloHoja;
                    oSheet.get_Range("A3", "E3").Merge(Missing.Value);                   
                    oSheet.get_Range("A3", "E3").WrapText = true;
                    oSheet.get_Range("A3", "E3").HorizontalAlignment = excel.XlHAlign.xlHAlignCenter;//Alineación horizontal
                    oSheet.get_Range("A3", "E3").VerticalAlignment = excel.XlVAlign.xlVAlignCenter; //Alineación vertical
                    oSheet.Name = TituloHoja;
                }

                // Encabezado
                if (TituloHoja.Trim().Length > 0)
                {
                    for (lc_columna = 0; lc_columna <= Tabla.Columns.Count - 1; lc_columna++)
                    {
                        oSheet.Cells[ROW_FIRST, lc_columna + 1] = Tabla.Columns[lc_columna].ColumnName;

                        oSheet.Cells[ROW_FIRST, lc_columna + 1].Interior.ColorIndex = 14;
                        oSheet.Cells[ROW_FIRST, lc_columna + 1].Interior.Pattern = 1;
                        oSheet.Cells[ROW_FIRST, lc_columna + 1].Font.ColorIndex = 2;

                        oSheet.Cells[ROW_FIRST, lc_columna + 1].borders(1).LineStyle = 1;
                        oSheet.Cells[ROW_FIRST, lc_columna + 1].borders(1).Weight = 2;
                        oSheet.Cells[ROW_FIRST, lc_columna + 1].borders(2).LineStyle = 1;
                        oSheet.Cells[ROW_FIRST, lc_columna + 1].borders(2).Weight = 2;
                        oSheet.Cells[ROW_FIRST, lc_columna + 1].borders(3).LineStyle = 1;
                        oSheet.Cells[ROW_FIRST, lc_columna + 1].borders(3).Weight = 2;
                        oSheet.Cells[ROW_FIRST, lc_columna + 1].borders(4).LineStyle = 1;
                        oSheet.Cells[ROW_FIRST, lc_columna + 1].borders(4).Weight = 2;
                    }
                    //ROW_FIRST = 2;
                    ROW_FIRST = ROW_FIRST + 1;
                }

                bool vmzpintanegrita = false;
                foreach (DataRow MiDataRow in Tabla.Rows)
                {
                    vmzpintanegrita = false;
                    for (lc_columna = 0; lc_columna <= Tabla.Columns.Count - 1; lc_columna++)
                    {
                        oSheet.Cells[ROW_FIRST, lc_columna + 1] = MiDataRow[lc_columna];
                        //oSheet.Cells[ROW_FIRST, lc_columna] = Tabla.Rows[lc_columna]["dfecha"];
                        //lc_columna = lc_columna + 1;
                        //oSheet.Cells[ROW_FIRST, lc_columna] = Tabla.Rows[lc_columna]["compra"];
                        //lc_columna = lc_columna + 1;
                        //oSheet.Cells[ROW_FIRST, lc_columna] = Tabla.Rows[lc_columna]["venta"];
                        //lc_columna = lc_columna + 1;
                        //oSheet.Cells[ROW_FIRST, lc_columna] = Tabla.Rows[lc_columna]["promedio"];


                        if (namecolumnafontbold.Trim().Length > 0)
                        {
                            if (Tabla.Columns[lc_columna].ColumnName.ToUpper() == namecolumnafontbold.ToUpper())
                            {
                                if ((valorcolumna != null))
                                {
                                    for (iContador = 0; iContador <= (valorcolumna.Length - 1); iContador++)
                                    {
                                        if (MiDataRow[lc_columna] == valorcolumna[iContador])
                                        {
                                            vmzpintanegrita = true;
                                        }
                                    }
                                }
                            }
                        }
                        if (vmzpintanegrita)
                        {
                            oSheet.Cells[ROW_FIRST, lc_columna + 1].font.bold = true;
                        }
                    }
                    ROW_FIRST = ROW_FIRST + 1;
                }
                for (lc_columna = 0; lc_columna <= Tabla.Columns.Count - 1; lc_columna++)
                {
                    range = oSheet.Columns[lc_columna + 1];
                    range.Font.Name = "Tahoma";
                    range.Font.Size = 8;
                    range.AutoFit();
                }

                // Control a USuario
                if (nomfileaguardar.Trim().Length == 0)
                {
                    oExcel.Visible = true;
                    oExcel.UserControl = true;
                }
                else
                {
                    if (nomfileaguardar.Trim().Length > 0)
                    {
                        oExcel.Application.DisplayAlerts = false;
                        oSheet.SaveAs(nomfileaguardar);
                        oExcel.Quit();
                        if (MessageBox.Show("Desea abrir archivo " + nomfileaguardar + "...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(nomfileaguardar);
                        }
                    }
                }
                //Cierra Todo
            }
            catch (Exception ex)
            {
                zCreateOKHoja = false;
                vmxmsgerror = ex.Message;
            }
            oBooks = null;
            oBook = null;
            oSheet = null;
            range = null;
            oExcel = null;

            if (zCreateOKHoja)
            {
            }
            else
            {
                MessageBox.Show(vmxmsgerror + '\r' + "ERROR ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            oform.Close();
            oform = null;
        }
    }
}
