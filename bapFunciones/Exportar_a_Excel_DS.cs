using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;

using Microsoft.Office.Interop.Excel;

using System.Reflection;
using config = System.Configuration;
using ficheros = System.IO;


namespace bapFunciones
{
    public class Exportar_a_Excel_DS
    {
        public static void Export(string Titol, string ExcelName, string sheets, DataSet DS)
        {
            // Prevenir conflicto de idiomas. Si no se pone genera :
            // Old format or invalid type library. (Exception from HRESULT: 0x80028018 (TYPE_E_INVDATAREAD))
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

            try
            {
                Application _excel = new Application();
                Workbook _wBook = _excel.Workbooks.Add(Missing.Value);

                int idx = 0;

                while (idx < DS.Tables.Count)
                {
                    Worksheet _sheet = (Worksheet)_wBook.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    _sheet.Name = sheets;

                    ////Insertamos el logo —si tenemos— en A1
                    ////dynamic imagen = _sheet.Pictures.Insert(_UrlLogo); //_UrlLogo = Dirección URL Logo de la empresa
                    //dynamic imagen = _sheet.Pictures(VariablesPublicas.EmpresaLogo); //_UrlLogo = Dirección URL Logo de la empresa
                    //dynamic cell = _sheet.Cells[1, 1];

                    ////Centro en ancho
                    //double ancho = cell.Offset(0, 1).Left - cell.Left;
                    //imagen.Left = cell.Left + ancho / 2 - imagen.Width / 2;
                    //if (imagen.Left < 1)
                    //{ imagen.Left = 1; }
                    ////Centro en alto
                    //double alto = cell.Offset(1, 0).Top - cell.Top;
                    //imagen.Top = cell.Top + alto / 2 - imagen.Height / 2;
                    //if (imagen.Top < 1)
                    //{ imagen.Top = 1; }

                    ////Suponiendo que el logo ocupe cinco filas..., montamos el título del informe en la linea 6 y damos formato
                    //int r = 6; // ojo con logo
                    int r = 1;
                    _sheet.Cells[r, 1] = Titol.ToString();
                    Range rng = ((Range)_sheet.Cells[r, 1]);
                    rng.EntireRow.Font.Bold = true;
                    rng.EntireRow.Font.Size = 20;
                    rng.EntireRow.Interior.ColorIndex = 40;
                    rng.EntireRow.Font.ColorIndex = 30;

                    //Dos lineas más y montamos las cabeceras de las columnas y les damos formato
                    r += 2;
                    int k = 0;
                    while (k < DS.Tables[idx].Columns.Count)
                    {
                        _sheet.Cells[r, k + 1] = DS.Tables[idx].Columns[k].ColumnName.ToString();
                        System.Math.Max(System.Threading.Interlocked.Increment(ref k), k - 1);
                    }
                    rng = (Range)_sheet.Cells[r, DS.Tables[idx].Columns.Count];
                    rng.EntireRow.Font.Bold = true;
                    rng.EntireRow.Interior.ColorIndex = 30;
                    rng.EntireRow.Font.ColorIndex = 40;

                    //Y a partir de ahí, montamos todos los datos del DataSet
                    r = 0;
                    while (r < DS.Tables[idx].Rows.Count)
                    {
                        k = 0;
                        while (k < DS.Tables[idx].Columns.Count)
                        {
                            _sheet.Cells[r + 9, k + 1] = DS.Tables[idx].Rows[r].ItemArray[k];
                            System.Math.Max(System.Threading.Interlocked.Increment(ref k), k - 1);
                        }
                        System.Math.Max(System.Threading.Interlocked.Increment(ref r), r - 1);

                    }
                    System.Math.Max(System.Threading.Interlocked.Increment(ref idx), idx - 1);
                }

                if (System.IO.File.Exists(ExcelName))
                {
                    System.IO.File.Delete(ExcelName);
                }

                //Salimos del Excel 
                _excel.ActiveCell.Worksheet.SaveAs(ExcelName, XlFileFormat.xlOpenXMLWorkbook, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                _excel.Quit();

                // Mostrar el excel
                _excel.Visible = false;

                //Matamos el proceso
                deleteProcess();
            }
            catch (Exception ex)
            {
                string ss = ex.Message;
            }
        }

        private static void deleteProcess()
        {
            System.Diagnostics.Process[] miproceso = System.Diagnostics.Process.GetProcessesByName("EXCEL");

            foreach (System.Diagnostics.Process pc in miproceso)
            {
                pc.Kill();
            }
        }
    }
}
