using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using BapFormulariosNet.Codigo;

namespace BapFormulariosNet.Ayudas
{
    public partial class Frm_AyudaConfiguracionPlla : Form
    {
        public delegate void PasaRubroDelegate2(string rubro, string descripcion, int nestado);
        public PasaRubroDelegate2 PasaRubro2;
        public string _DescartaRubros = string.Empty;
        private string _tipoPlanilla = string.Empty;
        private string _tiporubro = "I";
        private DataTable tabla;
        private DataTable odata;

        public Form Formulario { get; set; }

        public string TipoPlanilla
        {
            get
            {
                return _tipoPlanilla;
            }
            set
            {
                _tipoPlanilla = value;
            }
        }
        public string TipoRubro
        {
            get
            {
                return _tiporubro;
            }
            set
            {
                _tiporubro = value;
            }
        }

        public Frm_AyudaConfiguracionPlla()
        {
            InitializeComponent();

            KeyDown += myform_KeyDown;
            Load += Frm_AyudaConfiguracionPlla_Load;
            KeyDown += Frm_AyudaConfiguracionPlla_KeyDown;
        }

        private void Frm_AyudaConfiguracionPlla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void Frm_AyudaConfiguracionPlla_Load(object sender, EventArgs e)
        {
            Formulario = Owner;
            Formulario.Activate();
            var BL = new tb_plla_tipoplanillaBL();
            var BE = new tb_plla_tipoplanilla();

            BE.Tipoplla = _tipoPlanilla;
            BE.norden = 1;
            BE.ver_blanco = 0;
            BE.solopdt = 0;
            odata = BL.GetAll_Consulta(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            u_CargaDatos();
        }

        private void dgrRubrosPago_DoubleClick(object sender, EventArgs e)
        {
            PasaDatos();
        }
        private void PasaDatos()
        {
            if (dgrRubrosPago.CurrentRow == null)
            {
                PasaRubro2(string.Empty, string.Empty, 0);
            }
            else
            {
                PasaRubro2(dgrRubrosPago[1, dgrRubrosPago.CurrentRow.Index].Value.ToString(),
                           dgrRubrosPago[2, dgrRubrosPago.CurrentRow.Index].Value.ToString(),
                           Convert.ToInt16(dgrRubrosPago.Rows[dgrRubrosPago.CurrentRow.Index].Cells["status"].Value));
            }
            Close();
        }

        private void dgrRubrosPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PasaDatos();
            }
        }

        public void u_CargaDatos()
        {
            dgrRubrosPago.ReadOnly = true;
            var nestado = 1;
            if (rbestado2.Checked)
            {
                nestado = 2;
            }
            if (rbestado3.Checked)
            {
                nestado = 3;
            }
            if (_tiporubro == "I")
            {
                var BLI = new tb_plla_rubrosingresoBL();
                var BEI = new tb_plla_rubrosingreso();

                BEI.tipoplla = _tipoPlanilla;
                BEI.norden = 1;
                BEI.incluir_blanco = 0;
                BEI.nestado = nestado;
                BEI.descartarrubros = _DescartaRubros;
                tabla = BLI.GetAll_CONSULTA(VariablesPublicas.EmpresaID.ToString(), BEI).Tables[0];
                if (BLI.Sql_Error.Length == 0)
                {
                    dgrRubrosPago.AutoGenerateColumns = false;
                    dgrRubrosPago.DataSource = tabla;
                    dgrRubrosPago.Columns["tipoplla"].DataPropertyName = "tipoplla";
                    dgrRubrosPago.Columns["rubroid"].DataPropertyName = "rubroid";
                    dgrRubrosPago.Columns["rubroname"].DataPropertyName = "rubroname";
                    dgrRubrosPago.Columns["status"].DataPropertyName = "status";
                }
                else
                {
                    Frm_Class.ShowError(BLI.Sql_Error, this);
                }
                Text = "RUBROS INGRESO PERSONAL";
            }

            if (_tiporubro == "D")
            {
                Text = "RUBROS DESCUENTO PERSONAL";
                var BL = new tb_plla_rubrosdescuentosBL();
                var BE = new tb_plla_rubrosdescuentos();

                BE.tipoplla = _tipoPlanilla;
                BE.norden = 1;
                BE.incluir_blanco = 0;
                BE.nestado = nestado;
                tabla = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (BL.Sql_Error.Length == 0)
                {
                    dgrRubrosPago.AutoGenerateColumns = false;
                    dgrRubrosPago.DataSource = tabla;
                    dgrRubrosPago.Columns["tipoplla"].DataPropertyName = "tipoplla";
                    dgrRubrosPago.Columns["rubroid"].DataPropertyName = "rubroid";
                    dgrRubrosPago.Columns["rubroname"].DataPropertyName = "rubroname";
                    dgrRubrosPago.Columns["status"].DataPropertyName = "status";
                }
                else
                {
                    Frm_Class.ShowError(BL.Sql_Error, this);
                }
            }
            if (_tiporubro == "A")
            {
                Text = "RUBROS APORTACIONES PERSONAL";
                var BL = new tb_plla_rubrosaportacionesBL();
                var BE = new tb_plla_rubrosaportaciones();

                BE.tipoplla = _tipoPlanilla;
                BE.norden = 1;
                BE.incluir_blanco = 0;
                BE.nestado = nestado;
                tabla = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (BL.Sql_Error.Length == 0)
                {
                    dgrRubrosPago.AutoGenerateColumns = false;
                    dgrRubrosPago.DataSource = tabla;
                    dgrRubrosPago.Columns["tipoplla"].DataPropertyName = "tipoplla";
                    dgrRubrosPago.Columns["rubroid"].DataPropertyName = "rubroid";
                    dgrRubrosPago.Columns["rubroname"].DataPropertyName = "rubroname";
                    dgrRubrosPago.Columns["status"].DataPropertyName = "status";
                }
                else
                {
                    Frm_Class.ShowError(BL.Sql_Error, this);
                }
            }
            dgrRubrosPago.AllowUserToResizeRows = false;
            var BLTI = new tb_plla_tipoplanillaBL();
            var BETI = new tb_plla_tipoplanilla();

            BETI.Tipoplla = _tipoPlanilla;
            BETI.norden = 1;
            BETI.ver_blanco = 0;
            BETI.solopdt = 0;
            odata = BLTI.GetAll_Consulta(VariablesPublicas.EmpresaID.ToString(), BETI).Tables[0];
            lblplanilla.Text = "PLANILLA : ??????";
            if (BLTI.Sql_Error.Length == 0)
            {
                if (odata.Rows.Count > 0)
                {
                    lblplanilla.Text = "PLANILLA : " + odata.Rows[0]["tipopllaname"];
                }
            }
        }

        private void rbestado1_CheckedChanged(object sender, EventArgs e)
        {
            if (tabla != null)
            {
                u_CargaDatos();
            }
        }

        private void rbestado2_CheckedChanged(object sender, EventArgs e)
        {
            if (tabla != null)
            {
                u_CargaDatos();
            }
        }

        private void rbestado3_CheckedChanged(object sender, EventArgs e)
        {
            if (tabla != null)
            {
                u_CargaDatos();
            }
        }

        private void myform_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
