using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using BapFormulariosNet.Codigo;

namespace BapFormulariosNet.RecursosHumanos
{
    public partial class Frm_SeleccionaPlanilla : plantilla
    {
        public Frm_SeleccionaPlanilla()
        {
            InitializeComponent();

            Load += Frm_SeleccionaPlanilla_Load;

            cboTipo.LostFocus += new System.EventHandler(cboTipo_LostFocus);
            cboTipo.GotFocus += new System.EventHandler(cboTipo_GotFocus);
        }

        private void Frm_SeleccionaPlanilla_Load(object sender, EventArgs e)
        {
            txtPeriodo.Text = VariablesPublicas.perianio;
            U_LoadPlanillas(1);
            Examinar.MultiSelect = false;
            MaximizeBox = false;
        }

        private void U_LoadPlanillas(int nInit)
        {
            if (nInit == 1)
            {
                cboTipo.Text = "Normal";
            }

            Examinar.AutoGenerateColumns = false;
            var BL = new tb_plla_numeracionpllaBL();
            var BE = new tb_plla_numeracionplla();
            BE.perianio = VariablesPublicas.perianio;
            BE.norden = 1;
            Examinar.DataSource = BL.CONSULTA_SELECCION(VariablesPublicas.EmpresaID, BE).Tables[0];

            VariablesPublicas.PintaEncabezados(Examinar);

            var ncol = 0;
            for (ncol = 0; ncol <= Examinar.ColumnCount - 1; ncol++)
            {
                Examinar.Columns[ncol].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            if (cboTipo.Text.ToUpper() == "NORMAL")
            {
                Examinar.Columns["Column8"].DataPropertyName = "plla_sel";
            }
            else
            {
                Examinar.Columns["Column8"].DataPropertyName = "he_sel";
            }

            Examinar.Columns[6].Visible = false;
            Examinar.Columns[7].Visible = false;
            Examinar.Columns[8].Visible = true;
        }

        private void cboTipo_DropDownClosed(object sender, EventArgs e)
        {
            cboTipo_LostFocus(sender, e);
            SendKeys.Send("\t");
        }
        private void cboTipo_GotFocus(object sender, System.EventArgs e)
        {
            cboTipo.Tag = cboTipo.Text;
        }

        private void cboTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)13:
                    SendKeys.Send("\t");
                    break;
                case (char)32:
                    cboTipo.DroppedDown = true;
                    break;
            }
        }
        private void cboTipo_LostFocus(object sender, System.EventArgs e)
        {
            if (!(cboTipo.Tag == cboTipo.Text))
            {
                U_LoadPlanillas(0);
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            var xmsgerror = string.Empty;
            var BL = new tb_plla_numeracionpllaBL();
            var BE = new tb_plla_numeracionplla();
            BE.perianio = VariablesPublicas.perianio;
            BE.asiento = Examinar.Rows[Examinar.CurrentRow.Index].Cells["asiento"].Value.ToString();
            if (cboTipo.Text.ToUpper() == "NORMAL")
            {
                if (!BL.Plla_SELECCIONADA(VariablesPublicas.EmpresaID, BE))
                {
                    xmsgerror = BL.Sql_Error;
                }
            }
            else
            {
                if (!BL.Plla_HESELECCIONADA(VariablesPublicas.EmpresaID, BE))
                {
                    xmsgerror = BL.Sql_Error;
                }
            }
            if (xmsgerror.Trim().Length == 0)
            {
                btnCancelar_Click(sender, e);
            }
            else
            {
                Frm_Class.ShowError(xmsgerror, this);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
