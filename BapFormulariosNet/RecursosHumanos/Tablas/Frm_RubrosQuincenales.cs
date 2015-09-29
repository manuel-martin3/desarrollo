using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using BapFormulariosNet.Seguridadlog;
using BapFormulariosNet.Ayudas;

namespace BapFormulariosNet.RecursosHumanos.Tablas
{
    public partial class Frm_RubrosQuincenales : plantilla
    {
        private string _Company = VariablesPublicas.EmpresaID;
        private DataTable _dtDetalle = new DataTable();

        private TextBox CellPorcentaje = null;
        private int n = 0;

        public Frm_RubrosQuincenales()
        {
            InitializeComponent();

            Load += Frm_RubrosQuincenales_Load;
        }

        public void COMBOPLANILLA()
        {
            cboTipoPlanilla.DisplayMember = "tipopllaname";
            cboTipoPlanilla.ValueMember = "tipoplla";
            var BL = new tb_plla_tab0100BL();
            var BE = new tb_plla_tab0100();
            cboTipoPlanilla.DataSource = BL.Quincenal_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
        }

        public void GRILLARUBROS()
        {
            var BL = new tb_plla_tab0100BL();
            var BE = new tb_plla_tab0100();
            BE.codigo = cboTipoPlanilla.SelectedValue.ToString().Trim();
            BE.norden = 2;
            _dtDetalle = BL.QuincenalRubros_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];

            _dtDetalle.Columns["TIPO_PLANILLA"].AllowDBNull = true;
            _dtDetalle.Columns["COD_RUBRO"].AllowDBNull = true;
            _dtDetalle.Columns["DES_RUBRO"].AllowDBNull = true;
            _dtDetalle.Columns["PORCENTAJE"].AllowDBNull = true;

            _dtDetalle.Columns["TIPO_PLANILLA"].ReadOnly = false;
            _dtDetalle.Columns["COD_RUBRO"].ReadOnly = false;
            _dtDetalle.Columns["DES_RUBRO"].ReadOnly = false;
            _dtDetalle.Columns["PORCENTAJE"].ReadOnly = false;

            dgRubroQuincenal.DataSource = _dtDetalle;

            VariablesPublicas.PintaEncabezados(dgRubroQuincenal);
        }

        public void HABILITARBOTONES(bool b)
        {
            tsEditar.Enabled = b;
            tsEliminar.Enabled = b;
            tsGrabar.Enabled = !b;
            tsCancelar.Enabled = !b;
            GB1.Enabled = !b;
        }

        public void HABILITARCONTROLES(bool b)
        {
            cboTipoPlanilla.Enabled = b;
            dgRubroQuincenal.ReadOnly = b;

            dgRubroQuincenal.Columns["COD_RUBRO"].ReadOnly = true;
            dgRubroQuincenal.Columns["DES_RUBRO"].ReadOnly = true;
        }

        private void cboTipoPlanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cboTipoPlanilla.SelectedValue != null))
            {
                lblDesPlanilla.Text = cboTipoPlanilla.SelectedValue.ToString().Trim();
            }
            else
            {
                lblDesPlanilla.Text = string.Empty;
            }

            if (n == 1)
            {
                GRILLARUBROS();
            }
        }

        private void Frm_RubrosQuincenales_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            COMBOPLANILLA();
            GRILLARUBROS();

            HABILITARBOTONES(true);
            HABILITARCONTROLES(true);

            n = 1;
        }

        private void tsEditar_Click(object sender, EventArgs e)
        {
            HABILITARCONTROLES(false);
            HABILITARBOTONES(false);
            dgRubroQuincenal.Focus();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea Eliminar Todos los Rubros de la Planilla", "Información del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                ELIMINAR();
            }
        }

        public void ELIMINAR()
        {
            var BL = new tb_plla_tab0100BL();
            var BE = new tb_plla_tab0100();
            BE.codigo = cboTipoPlanilla.SelectedValue.ToString().Trim();
            if (BL.QuincenalRubros_DELETED(VariablesPublicas.EmpresaID, BE) == true)
            {
                var BLL = new tb_co_seguridadlogBL();
                var BEL = new tb_co_seguridadlog();
                BEL.moduloid = Name;
                BEL.clave = VariablesPublicas.EmpresaID + cboTipoPlanilla.SelectedValue.ToString().Trim();
                BEL.cuser = VariablesPublicas.Usuar;
                BEL.fecha = DateTime.Now;
                BEL.pc = VariablesPublicas.userip;
                BEL.accion = "B";
                BEL.detalle = "Descripción: " + "Quincena";
                BLL.Insert(VariablesPublicas.EmpresaID.ToString(), BEL);

                LIMPIARDETALLE();
                GRILLARUBROS();

                MessageBox.Show("Los Datos han sido Eliminados", "Información Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                HABILITARBOTONES(true);
                HABILITARCONTROLES(true);
                cboTipoPlanilla.Focus();
            }
        }

        public void LIMPIARDETALLE()
        {
            if (_dtDetalle.Rows.Count > 0)
            {
                _dtDetalle.Rows.Clear();
            }
        }

        private void tsGrabar_Click(object sender, EventArgs e)
        {
            GUARDARACTUALIZAR();
        }
        public void GUARDARACTUALIZAR()
        {
            dgRubroQuincenal.EndEdit();
            btnNuevaFila.Focus();
            _dtDetalle.AcceptChanges();
            var BL = new tb_plla_tab0100BL();
            var BE = new tb_plla_tab0100();
            BE.codigo = cboTipoPlanilla.SelectedValue.ToString().Trim();
            if (BL.QuincenalRubros_InsertUpdate(VariablesPublicas.EmpresaID, BE, _dtDetalle) == true)
            {
                seguridadlog();
                MessageBox.Show("Los Datos han sido Guardados Correctamente !!!", "Información Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HABILITARBOTONES(true);
                HABILITARCONTROLES(true);
                GRILLARUBROS();
                cboTipoPlanilla.Focus();
            }
        }
        private void seguridadlog()
        {
            var xclave = VariablesPublicas.EmpresaID + cboTipoPlanilla.SelectedValue.ToString().Trim();
            try
            {
                var BL = new tb_co_seguridadlogBL();
                var BE = new tb_co_seguridadlog();

                BE.moduloid = Name;
                BE.clave = xclave;
                BE.cuser = VariablesPublicas.Usuar;
                BE.fecha = DateTime.Now;
                BE.pc = VariablesPublicas.userip;
                BE.accion = (n == 1 ? "N" : "M");
                BE.detalle = "Descripción: " + "Quincena";

                BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsCancelar_Click(object sender, EventArgs e)
        {
            dgRubroQuincenal.EndEdit();
            HABILITARCONTROLES(true);
            HABILITARBOTONES(true);
            GRILLARUBROS();
            cboTipoPlanilla.Focus();
        }

        private void tsSeguridad_Click(object sender, EventArgs e)
        {
            var oform = new FrmSeguridad();
            oform._Nombre = Name;
            oform._ClaveForm = _Company.Trim() + cboTipoPlanilla.SelectedValue.ToString().Trim();
            oform.Owner = this;
            oform.ShowDialog();
        }

        public void BORRARFILA()
        {
            dgRubroQuincenal.EndEdit();
            if ((dgRubroQuincenal.CurrentRow != null))
            {
                if (MessageBox.Show("Desea Eliminar este Registro", "Información del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    var row = 0;
                    row = dgRubroQuincenal.CurrentCell.RowIndex;
                    _dtDetalle.Rows.RemoveAt(row);
                }
            }
            else
            {
                MessageBox.Show("Debe Seleccionar un Registro", "iInformación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNuevaFila_Click(object sender, EventArgs e)
        {
            var frm = new Frm_AyudaConfiguracionPlla();
            frm.Owner = this;
            frm.Formulario = this;
            frm.TipoPlanilla = cboTipoPlanilla.SelectedValue.ToString().Trim();
            frm.TipoRubro = "I";
            frm.PasaRubro2 = NUEVAFILA;
            frm.ShowDialog();
        }

        private void btnEliminarFila_Click(object sender, EventArgs e)
        {
            BORRARFILA();
        }

        public void NUEVAFILA(string rubro, string descripcion, int nestado)
        {
            DataRow row = null;
            row = _dtDetalle.NewRow();
            row["TIPO_PLANILLA"] = cboTipoPlanilla.SelectedValue.ToString().Trim();
            row["COD_RUBRO"] = rubro.Trim();
            row["DES_RUBRO"] = descripcion.Trim();

            if (dgRubroQuincenal.Rows.Count > 0)
            {
                row["PORCENTAJE"] = dgRubroQuincenal.Rows[dgRubroQuincenal.Rows.Count - 1].Cells["PORCENTAJE"].Value;
            }
            else
            {
                row["PORCENTAJE"] = "0.00";
            }

            _dtDetalle.Rows.Add(row);
            dgRubroQuincenal.Rows[dgRubroQuincenal.Rows.Count - 1].Cells["COD_RUBRO"].Selected = true;
            dgRubroQuincenal.Focus();
        }

        private void dgRubroQuincenal_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            switch (dgRubroQuincenal.Columns[dgRubroQuincenal.CurrentCell.ColumnIndex].Name.ToString().Trim())
            {
                case "TIPO_PLANILLA":
                    break;
                case "COD_RUBRO":
                    break;
                case "DES_RUBRO":
                    break;
                case "PORCENTAJE":
                    OBTENERPORCENTAJE(e.ColumnIndex, e.RowIndex);
                    break;
            }
        }

        public void OBTENERPORCENTAJE(int colum, int row)
        {
            var Porcen = 0.0;
            Porcen = Convert.ToDouble(dgRubroQuincenal[colum, row].Value);
            if (Porcen >= 1)
            {
                Porcen = Porcen / 100;
            }

            var a = 0;

            for (a = 0; a <= dgRubroQuincenal.Rows.Count - 1; a++)
            {
                dgRubroQuincenal[colum, a].Value = Porcen;
            }
        }

        private void dgRubroQuincenal_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            switch (dgRubroQuincenal.Columns[dgRubroQuincenal.CurrentCell.ColumnIndex].Name.ToString().Trim())
            {
                case "PORCENTAJE":
                    dgRubroQuincenal.CancelEdit();
                    dgRubroQuincenal.EndEdit();
                    dgRubroQuincenal[e.ColumnIndex, e.RowIndex].Value = 0;
                    OBTENERPORCENTAJE(e.ColumnIndex, e.RowIndex);
                    break;
                default:
                    MessageBox.Show(e.Exception.Message);
                    break;
            }
        }

        private void dgRubroQuincenal_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            switch (dgRubroQuincenal.Columns[dgRubroQuincenal.CurrentCell.ColumnIndex].Name.ToString().Trim())
            {
                case "TIPO_PLANILLA":
                    break;
                case "COD_RUBRO":
                    break;
                case "DES_RUBRO":
                    break;
                case "PORCENTAJE":

                    var parPorcentaje = new ParametrosTextBox();

                    parPorcentaje.LengthDecimal = 2;
                    parPorcentaje.CharDecimal = '.';
                    parPorcentaje.LengthReal = 4;
                    parPorcentaje.LengthText = 7;

                    CellPorcentaje = (TextBox)e.Control;
                    CellPorcentaje.Tag = parPorcentaje;
                    CellPorcentaje.MaxLength = 7;
                    CellPorcentaje.Text.Trim();
                    e.Control.TextChanged += VariablesPublicas.TextDecimal_Changed;
                    e.Control.KeyPress += ValidDec;

                    break;
            }
        }

        private void ValidDec(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | e.KeyChar == '8' | e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
