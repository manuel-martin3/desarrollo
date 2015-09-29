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
using BapFormulariosNet;
using BapFormulariosNet.Seguridadlog;
using BapFormulariosNet.Ayudas;
using BapFormulariosNet.Codigo;
using BapFormulariosNet.Ayudas;
using BapFormulariosNet.RecursosHumanos.Reportes;

namespace BapFormulariosNet.Ayudas
{
    public partial class Frm_PllaAyudaRta5ta : Form
    {
        public delegate void PasaTabajadorDelegate(string codigo, string nombre);
        #region "Fields"
	    // Parámetros
	    //public  _ccia = GlobalVars.GetInstance.Company();
	    public PasaTabajadorDelegate PasaTrabajador;
	    // Variables
	    private Form _formulario;
	    private string _Reten5ta;
		#endregion
	    private string _tipoPlanilla;
	    
        #region "Properties"
	    public Form Formulario {
		    get { return _formulario; }
		    set { _formulario = value; }
	    }

	    public string Reten5ta {
		    get { return _Reten5ta; }
		    set { _Reten5ta = value; }
	    }

	    public string TipoPlanilla {
		    get { return _tipoPlanilla; }
		    set { _tipoPlanilla = value; }
	    }
	    #endregion

	    public DataView dw = new DataView();
        public Frm_PllaAyudaRta5ta()
        {
            InitializeComponent();

            Load += Frm_PllaAyudaRta5ta_Load;
            KeyDown += Frm_PllaAyudaRta5ta_KeyDown;
        }

        private void Frm_PllaAyudaRta5ta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void Frm_PllaAyudaRta5ta_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            tb_plla_fichatrabajadoresBL BL = new tb_plla_fichatrabajadoresBL();
            tb_plla_fichatrabajadores BE = new tb_plla_fichatrabajadores();
            BE.Tipoplla = TipoPlanilla;
            dw = new DataView(BL.GetAll_TrabajadorRetenciones(VariablesPublicas.EmpresaID, BE).Tables[0]);
            dgAyuda.AutoGenerateColumns = false;
            dgAyuda.DataSource = dw;
            dgAyuda.Columns[0].DataPropertyName = "fichaid";
            dgAyuda.Columns[1].DataPropertyName = "nombrelargo";
            dgAyuda.Columns[2].DataPropertyName = "nrodni";
            dgAyuda.Columns[3].DataPropertyName = "estado";
            checks();
        }

        private void ckActivo_CheckedChanged(object sender, EventArgs e)
        {
            checks();
        }

        public void pintar()
        {
            try
            {
                int i = 0;
                int j = 0;
                for (i = 0; i <= dgAyuda.Rows.Count - 1; i++)
                {
                    if (dgAyuda[3, i].Value.ToString().Trim() == "NO ACTIVO")
                    {
                        for (j = 0; j <= dgAyuda.ColumnCount - 1; j++)
                        {
                            dgAyuda[j, i].Style.ForeColor = Color.Red;
                            dgAyuda[j, i].Style.BackColor = Color.Ivory;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        public void checks()
        {
            string xpalabra1 = "";
            string xpalabra2 = "";
            string xpalabra3 = "";
            string xpalabra4 = "";
            if (txtBuscar.Enabled & txtBuscar.Text.Trim().Length > 0)
            {
                xpalabra1 = VariablesPublicas.Palabras(txtBuscar.Text, 1);
                xpalabra2 = VariablesPublicas.Palabras(txtBuscar.Text, 2);
                xpalabra3 = VariablesPublicas.Palabras(txtBuscar.Text, 3);
                xpalabra4 = VariablesPublicas.Palabras(txtBuscar.Text, 4);
            }
            string xcondfiltro = "1=1";
            if (ckActivo.Checked == true)
            {
                xcondfiltro = xcondfiltro + "AND estado like 'ACTIVO'";
            }
            if (xpalabra1.Trim().Length > 0)
            {
                xcondfiltro = xcondfiltro + "AND (nombrelargo like '%" + xpalabra1 + "%')";
            }
            if (xpalabra2.Trim().Length > 0)
            {
                xcondfiltro = xcondfiltro + "AND (nombrelargo like '%" + xpalabra2 + "%')";
            }
            if (xpalabra3.Trim().Length > 0)
            {
                xcondfiltro = xcondfiltro + "AND (nombrelargo like '%" + xpalabra3 + "%')";
            }
            if (xpalabra4.Trim().Length > 0)
            {
                xcondfiltro = xcondfiltro + "AND (nombrelargo like '%" + xpalabra4 + "%')";
            }
            dw.RowFilter = xcondfiltro;
            pintar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            checks();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgAyuda_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PasaTrabajador(dgAyuda.SelectedRows[0].Cells[0].Value.ToString(), dgAyuda.SelectedRows[0].Cells[1].Value.ToString());
            Close();
        }

        private void dgAyuda_KeyDown(object sender, KeyEventArgs e)
        {
            string at = string.Empty;
            Keys k = default(Keys);
            k = e.KeyCode;
            switch (k)
            {
                case Keys.Enter:
                    PasaTrabajador(dgAyuda.SelectedRows[0].Cells[0].Value.ToString(), dgAyuda.SelectedRows[0].Cells[1].Value.ToString());
                    Close();
                    break;
                default:
                    break;
            }
        }
    }
}
