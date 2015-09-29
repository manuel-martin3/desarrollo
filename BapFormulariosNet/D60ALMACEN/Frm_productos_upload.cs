using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using System.IO;
using System.Threading;

namespace BapFormulariosNet.D60ALMACEN
{
    public partial class Frm_productos_upload : Form
    {
        public delegate void PasaProveedorDelegate(DataTable resultado01);
        public PasaProveedorDelegate PasarTabla;
        private Thread p1;
        private StreamReader sr = null;
        public String titulo { get; set; }
        public String almacaccionid { get; set; }
        public String tipoperacionid { get; set; }
        public String moneda { get; set; }
        public String tcamb { get; set; }
        public String incprec { get; set; }
        public Decimal igv { get; set; }


        private DataTable DataDetalleMov;
        private DataTable dataerror;

        public Frm_productos_upload()
        {
            InitializeComponent();
        }

        private void solo_numero_enteros(object control, KeyPressEventArgs e)
        {
            if (((e.KeyChar) >= '0' & e.KeyChar <= '9') & !(e.KeyChar == '.'))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete && !(e.KeyChar == '.'))
                {
                    e.Handled = false;
                }
                else
                {
                    if ((e.KeyChar) == (char)Keys.Tab)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        public void datos_seleccionados()
        {
            if ((griddetallemov.CurrentRow != null))
            {
                if ((PasarTabla != null))
                {
                    PasarTabla(DataDetalleMov);
                }
                Close();
            }
        }



        private Int16 TotalLines(string filePath)
        {
            using (var r = new StreamReader(filePath))
            {
                Int16 i = 0;
                while (r.ReadLine() != null)
                {
                    i++;
                }
                return i;
            }
        }

        private void Stop()
        {
            if (p1 != null)
            {
                sr.Close();
                p1.Abort();
                p1 = null;
            }
        }

        public void RefreshProgress(Int16 value)
        {
            if (this == null)
            {
                return;
            }
            Invoke(new Action(() => contador.Text = value.ToString()));
        }

        public void Refresh_controles()
        {
            if (this == null)
            {
                return;
            }
            Invoke(new Action(() => btnSeleccion.Enabled = true));
            Invoke(new Action(() => btn_cerrar.Enabled = true));
            Thread.Sleep(1500);
            Invoke(new Action(() => pl_contador.Visible = false));
        }

        public void Refresh_gridgeneral(DataTable value)
        {
        }

        private void enabled_controles(Boolean enabled)
        {
            pl_contador.Visible = !enabled;
            btnSeleccion.Enabled = enabled;
            btn_cerrar.Enabled = enabled;
        }

        private void Frm_productos_upload_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;

            dataerror = new DataTable();
            dataerror.Columns.Add(new DataColumn("idrollo".ToString(), typeof(String)));
            dataerror.Columns.Add(new DataColumn("msgdataerror".ToString(), typeof(String)));

            pl_contador.Visible = false;
            cencosid.Focus();
        }

        private void Frm_movimiento_rollos_upload_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape))
            {
                Close();
            }
        }

        private void Frm_movimiento_rollos_upload_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stop();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            datos_seleccionados();
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Stop();
            Close();
        }

        private void cencosid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaCentroCosto();
            }

            if (e.KeyCode == Keys.Enter)
            {
                estacion.Focus();
            }
        }

        private void AyudaCentroCosto()
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "Ayuda Centro de Costo";
                frmayuda.sqlquery = "select cencosid, cencosname From tb_centrocosto where cencosdivi = 2";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = string.Empty;
                frmayuda.sqland = "and";
                frmayuda.criteriosbusqueda = new string[] { "NOMBRE", "CÓDIGO" };
                frmayuda.columbusqueda = "cencosname,cencosid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeCentroCosto;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RecibeCentroCosto(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                cencosid.Text = resultado1.Trim();
                cencosname.Text = resultado2.Trim();
            }
        }

        private void estacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var numdo = string.Empty;
                if (estacion.Text.Trim().Length > 0)
                {
                    numdo = estacion.Text.Trim().PadLeft(3, '0');
                }
                estacion.Text = numdo;

                var BL = new tb_60productosBL();
                var BE = new tb_60productos();

                BE.moduloid = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
                BE.codigo = cencosid.Text.Trim() + estacion.Text.Trim();
                BE.filtro = "3";

                DataDetalleMov = BL.GetAll(VariablesPublicas.EmpresaID, BE).Tables[0];

                if (DataDetalleMov.Rows.Count > 0)
                {
                    griddetallemov.DataSource = DataDetalleMov;
                }
            }
        }
    }
}
