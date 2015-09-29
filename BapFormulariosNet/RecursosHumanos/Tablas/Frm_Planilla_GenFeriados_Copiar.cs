using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using BapFormulariosNet.Codigo;

namespace BapFormulariosNet.RecursosHumanos.Tablas
{
    public partial class Frm_Planilla_GenFeriados_Copiar : Form
    {
        public delegate void Procesa(bool sw);
        public string LpPeriodo = DateTime.Now.Year.ToString();
        public Procesa _LpDelegado;
        private bool Sw_LOad = true;

        public Frm_Planilla_GenFeriados_Copiar()
        {
            InitializeComponent();

            Load += Frm_Planilla_GenFeriados_Copiar_Load;
            KeyDown += Frm_Planilla_GenFeriados_Copiar_KeyDown;
            Activated += Frm_Planilla_GenFeriados_Copiar_Activated;
        }

        private void Frm_Planilla_GenFeriados_Copiar_Activated(object sender, EventArgs e)
        {
            if (Sw_LOad)
            {
                spnperiodo.Value = Convert.ToInt16(VariablesPublicas.perianio);
                spnperiodod.Value = Convert.ToInt16(LpPeriodo);

                U_RefrescaControles();
                Sw_LOad = false;
            }
        }

        private void Frm_Planilla_GenFeriados_Copiar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnSalir_Click(sender, e);
            }
        }

        private void Frm_Planilla_GenFeriados_Copiar_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            if (Owner == null)
            {
                MinimizeBox = false;
            }
            WindowState = FormWindowState.Normal;
        }

        private void U_RefrescaControles()
        {
            spnperiodo.Enabled = true;
            spnperiodod.Enabled = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            if (spnperiodo.Value == spnperiodod.Value)
            {
                MessageBox.Show("Periodos deben ser distintos", "Mensaje del Sistema");
                return;
            }
            var BL = new tb_plla_feriadosBL();
            var BE = new tb_plla_feriados();
            BE.perianioini = spnperiodo.Value.ToString();
            BE.perianiofin = spnperiodod.Value.ToString();
            BE.deleteoall = (chkdel.Checked ? 1 : 0);
            BL.Copiar(VariablesPublicas.EmpresaID, BE);
            if (BL.Sql_Error.Length > 0)
            {
                Frm_Class.ShowError(BL.Sql_Error, this);
            }
            else
            {
                if ((_LpDelegado != null))
                {
                    _LpDelegado(true);
                }
                Close();
            }
        }
    }
}
