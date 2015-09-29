using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using bapFunciones;
using System.IO.Ports;
using System.IO;



namespace BapFormulariosNet.D60ALMACEN
{
    public partial class Frm_leeCodBar : plantilla
    {
        private DataTable Tempo1;
        private SerialPort MSComm;

        public char Datos;
        private Queue<byte> recievedData = new Queue<byte>();

        public Frm_leeCodBar()
        {
            InitializeComponent();
            MSComm = new SerialPort();
            MSComm.Open();

            MSComm.DataReceived += serialPort_DataReceived;
        }


        private void serialPort_DataReceived(object s, SerialDataReceivedEventArgs e)
        {
            var data = new byte[MSComm.BytesToRead];
            MSComm.Read(data, 0, data.Length);

            data.ToList().ForEach(b => recievedData.Enqueue(b));

            processData();
        }

        private void processData()
        {
            if (recievedData.Count > 50)
            {
                Enumerable.Range(0, 50).Select(i => recievedData.Dequeue());
            }
        }

        public void Dispose()
        {
            if (MSComm != null)
            {
                MSComm.Dispose();
            }
        }










        private void btniniciar_Click(object sender, EventArgs e)
        {
            MSComm = new SerialPort();
            try
            {
                MSComm.PortName = cmbpuerto.Text.ToString();
                MSComm.BaudRate = Convert.ToInt32(cmbbaudios.Text.Trim());
                MSComm.Parity = System.IO.Ports.Parity.None;
                MSComm.DataBits = 8;
                MSComm.StopBits = System.IO.Ports.StopBits.One;
                MSComm.Handshake = System.IO.Ports.Handshake.None;
                MSComm.ReceivedBytesThreshold = 1;

                MSComm.DataReceived += serialPort_DataReceived;
                MSComm.Open();
                btniniciar.Enabled = false;
                btndetener.Enabled = true;
                Cambiar_Estado(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CODBAR.Focus();
        }

        private void btndetener_Click(object sender, EventArgs e)
        {
            if (btndetener.Enabled)
            {
                btniniciar.Enabled = true;
                btndetener.Enabled = false;
                Cambiar_Estado(true);

                MSComm = new SerialPort();
                if (MSComm.IsOpen)
                {
                    MSComm.Close();
                }
            }
        }


        private void Cambiar_Estado(Boolean var)
        {
            cmbpuerto.Enabled = var;
            cmbbaudios.Enabled = var;
        }

        private void Salvar_Config()
        {
            DataTable Tabla_Config;
            String xPuerto, xBaudios;

            xPuerto = cmbpuerto.Text;
            xBaudios = cmbbaudios.Text;

            Tabla_Config = new DataTable();

            try
            {
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Crear_Tabla_Config()
        {
        }

        private void Grabar_Log(String pcDataLog)
        {
            var StrFileLOG = string.Empty;
            var nFile = 0;
            var FilePath = @"\ErpBapSoftNet_almacen\BapFormulariosNet\log";
            StrFileLOG = Path.GetDirectoryName(FilePath);
            if (Equivalencias.Right(StrFileLOG, 1) != @"\")
            {
                StrFileLOG = StrFileLOG + @"\";
                StrFileLOG = StrFileLOG + DateTime.Today + ".XML";
            }

            if (File.Exists(StrFileLOG))
            {
            }
            else
            {
            }


            if (nFile > 0)
            {
            }
        }

        private void Crear_Tabla_Datos()
        {
            Tempo1 = new DataTable();

            try
            {
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Grabar_Datos(String pcData, String StrEOL)
        {
        }

        private void CODBAR_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
        }

        private void btnok_Click(object sender, EventArgs e)
        {
        }

        private void ThreadProcSafe()
        {
            ThreadHelperClass.SetText(this, CODBAR, "This text was set safely.");
        }

        public static class ThreadHelperClass
        {
            private delegate void SetTextCallback(Form f, Control ctrl, string text);
            /// <summary>
            /// Set text property of various controls
            /// </summary>
            /// <param name="form">The calling form</param>
            /// <param name="ctrl"></param>
            /// <param name="text"></param>
            public static void SetText(Form form, Control ctrl, string text)
            {
                if (ctrl.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    form.Invoke(d, new object[] { form, ctrl, text });
                }
                else
                {
                    ctrl.Text = text;
                }
            }
        }

        private void Frm_leeCodBar_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }
    }
}
