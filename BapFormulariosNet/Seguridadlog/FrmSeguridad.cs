using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.Seguridadlog
{
    public partial class FrmSeguridad : Form
    {
        public string _Nombre = string.Empty;
        public string _ClaveForm = string.Empty;

        public FrmSeguridad()
        {
            InitializeComponent();

            Load += FrmSeguridad_Load;
            KeyDown += FrmSeguridad_KeyDown;
        }

        private void FrmSeguridad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnSalir_Click(sender, e);
            }
        }
        private void FrmSeguridad_Load(object sender, EventArgs e)
        {
            Text = "Log View - Modulo : " + _Nombre.Trim() + "   Clave : " + _ClaveForm.Trim();
            GridSeguridad();
            PoneDatos();
            FormBorderStyle = FormBorderStyle.Fixed3D;
            dgSeguridad.Sort(dgSeguridad.Columns["FECHAHORA"], ListSortDirection.Descending);
        }

        public void GridSeguridad()
        {
            var dt = new DataTable();
            var xclave = "...";
            if (_ClaveForm.Trim().Length > 0)
            {
                xclave = _ClaveForm.Trim();
            }
            var BL = new tb_co_seguridadlogBL();
            var BE = new tb_co_seguridadlog();

            BE.moduloid = _Nombre.Trim();
            BE.clave = xclave;
            dt = BL.GetAllSeguridadlog(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            dgSeguridad.AutoGenerateColumns = false;
            dgSeguridad.DataSource = dt;
            txtTotRegistro.Text = dt.Rows.Count.ToString();
        }

        private void PoneDatos()
        {
            if ((dgSeguridad.CurrentRow != null))
            {
                txtFechaHora.Text = dgSeguridad.Rows[dgSeguridad.CurrentRow.Index].Cells["FECHA"].Value.ToString();
                txtClave.Text = dgSeguridad.Rows[dgSeguridad.CurrentRow.Index].Cells["CLAVE"].Value.ToString();
                txtOperacion.Text = dgSeguridad.Rows[dgSeguridad.CurrentRow.Index].Cells["OPERACION"].Value.ToString();
                txtModulo.Text = dgSeguridad.Rows[dgSeguridad.CurrentRow.Index].Cells["MODULO"].Value.ToString();
                txtUsuario.Text = dgSeguridad.Rows[dgSeguridad.CurrentRow.Index].Cells["USUARIO"].Value.ToString().ToUpper();
                txtPC.Text = dgSeguridad.Rows[dgSeguridad.CurrentRow.Index].Cells["PC"].Value.ToString();
                txtDescripcion.Text = dgSeguridad.Rows[dgSeguridad.CurrentRow.Index].Cells["DETALLE"].Value.ToString();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var a = 0;
            for (a = 0; a <= dgSeguridad.Rows.Count - 1; a++)
            {
                if (Convert.ToDateTime(dgSeguridad.Rows[a].Cells["FECHAHORA"].Value).ToShortDateString().Trim() == dtpBusqueda.Value.ToShortDateString().Trim())
                {
                    dgSeguridad.CurrentCell = dgSeguridad.Rows[a].Cells[0];
                    break;
                }
            }
        }

        private void dgSeguridad_SelectionChanged(object sender, EventArgs e)
        {
            PoneDatos();
        }
    }
}
