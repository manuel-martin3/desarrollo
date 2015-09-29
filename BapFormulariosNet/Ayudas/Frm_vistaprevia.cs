using System.Windows.Forms;
using bapFunciones;

using System;
using System.IO;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace BapFormulariosNet.Ayudas
{
    public partial class Frm_vistaprevia : Form
    {
        public String detalle { get; set; }
        public String filtro { get; set; }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern SafeFileHandle CreateFile(string lpFileName, FileAccess dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, FileMode dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);


        public Frm_vistaprevia()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\\ErpBapSoftNet_Config\\tmp\\reportebarcode.txt"))
            {
                File.Delete(@"C:\\ErpBapSoftNet_Config\\tmp\\reportebarcode.txt");
            }

            var escritor = new StreamWriter(@"C:\\ErpBapSoftNet_Config\\tmp\\reportebarcode.txt");
            escritor.WriteLine(detalle);
            escritor.Close();

            try
            {
                var pd = new PrintDialog();
                pd.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
                if (DialogResult.OK == pd.ShowDialog(this))
                {
                    RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, detalle.ToString());
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Frm_vistaprevia_Load(object sender, EventArgs e)
        {
            lst_detalle.Text = string.Empty;
            lst_detalle.Text = detalle.ToString();
            lst_detalle.ReadOnly = true;
        }
    }
}
