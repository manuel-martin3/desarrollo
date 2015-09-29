using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using BapFormulariosNet.Ayudas;

namespace BapFormulariosNet.RecursosHumanos
{
    public partial class Frm_RegistroTrabajadoresBajaCese : plantilla
    {
        public int _varProcesoCesar = 0;
        private int swB = 0;
        private DataView vistaDatos = new DataView();
        private string j_Valor = " ";

        public Frm_RegistroTrabajadoresBajaCese()
        {
            InitializeComponent();

            Load += Frm_TrabajadoresBaja_Load;

            txtjefe.GotFocus += new System.EventHandler(txtjefe_GotFocus);
            txtjefe.LostFocus += new System.EventHandler(txtjefe_LostFocus);
        }

        private void Frm_TrabajadoresBaja_Load(object sender, EventArgs e)
        {
            EnlazarControles();
            txtjefe.Enabled = true;
            txtjefe.ReadOnly = false;
            var BL = new tb_plla_pdt_tabla17BL();
            var BE = new tb_plla_pdt_tabla17();
            cbMotivoCese.DisplayMember = "descripcion";
            cbMotivoCese.ValueMember = "motfinperiodid";
            cbMotivoCese.DataSource = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
        }

        private void EnlazarControles()
        {
            swB = 2;
            var BindingTable = new DataTable();
            var BL = new tb_plla_fichatrabajadoresBL();
            var BE = new tb_plla_fichatrabajadores();
            BE.Ntipo = _varProcesoCesar;
            BindingTable = BL.GetAll_ActivosCesados(VariablesPublicas.EmpresaID, BE).Tables[0];
            vistaDatos = new DataView(BindingTable);
            dgTrabProceso.AutoGenerateColumns = false;
            dgTrabProceso.DataSource = vistaDatos;

            Llenar_cboEstadoContrato();
        }

        private void Llenar_cboEstadoContrato()
        {
            cbEstado.ValueMember = "cele";
            cbEstado.DisplayMember = "descripcion";
            var BL = new tb_plla_tab0100BL();
            var BE = new tb_plla_tab0100();
            cbEstado.DataSource = BL.GetAllEstadoContrato(VariablesPublicas.EmpresaID, BE).Tables[0];
        }

        private void DesEnlazaControles()
        {
            swB = 1;
            lblFicha.DataBindings.Clear();
            lblContratoVigente.DataBindings.Clear();
            txtinicio1.DataBindings.Clear();
            txtTermino1.DataBindings.Clear();
            txtInicio2.DataBindings.Clear();
            txtTermino2.DataBindings.Clear();
            txtTipo.DataBindings.Clear();
            txtDtipo.DataBindings.Clear();
            txtModal.DataBindings.Clear();
            txtDmodal.DataBindings.Clear();
            cbEstado.DataBindings.Clear();
        }

        private void txtBucar_TextChanged(object sender, EventArgs e)
        {
            vistaDatos.RowFilter = "dficha like '" + txtBucar.Text.Trim().ToString() + "%'";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void validacion_panel(bool valor)
        {
            dgTrabProceso.Enabled = valor;
            btnAccion.Enabled = valor;
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            string ficha = null;
            string nombre = null;
            string empresa = null;
            if ((dgTrabProceso.CurrentRow != null))
            {
                ficha = dgTrabProceso["ficha", dgTrabProceso.CurrentRow.Index].Value.ToString();
                empresa = dgTrabProceso["empresa", dgTrabProceso.CurrentRow.Index].Value.ToString();
                nombre = dgTrabProceso["dficha", dgTrabProceso.CurrentRow.Index].Value.ToString().Trim();
                if (_varProcesoCesar == 1)
                {
                    Panel.Visible = true;
                    validacion_panel(false);
                }
                if (_varProcesoCesar == 2)
                {
                    if (MessageBox.Show("Desea Desactivar al trabajador (" + ficha + ") " + nombre, string.Empty, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var retorno = false;
                        var BL = new tb_plla_fichatrabajadoresBL();
                        var BE = new tb_plla_fichatrabajadores();
                        BE.Fichaid = ficha.Trim();
                        BE.Empresaid = empresa.Trim();
                        retorno = BL.DesactivarTrabajadorUpdate(VariablesPublicas.EmpresaID, BE);
                        if (retorno)
                        {
                            MessageBox.Show("Desactivado Correctamente !!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (swB == 2)
                            {
                                DesEnlazaControles();
                            }
                            if (swB == 1)
                            {
                                EnlazarControles();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Hubo problemas al momento de Desactivar, cierra la ventana e intente de nuevo", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            limpiar();
            Panel.Visible = false;
            validacion_panel(true);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string ficha = null;
            string nombre = null;
            string empresa = null;
            if ((dgTrabProceso.CurrentRow != null))
            {
                if (string.IsNullOrEmpty(txtjefe.Text.Trim()))
                {
                    MessageBox.Show("Ingrese a un Jefe para Poder Cesar", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                ficha = dgTrabProceso["ficha", dgTrabProceso.CurrentRow.Index].Value.ToString();
                empresa = dgTrabProceso["empresa", dgTrabProceso.CurrentRow.Index].Value.ToString();
                nombre = dgTrabProceso["dficha", dgTrabProceso.CurrentRow.Index].Value.ToString().Trim();
                if (MessageBox.Show("Desea Cesar al trabajador (" + ficha + ") " + nombre, string.Empty, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var retorno = false;
                    var BL = new tb_plla_fichatrabajadoresBL();
                    var BE = new tb_plla_fichatrabajadores();

                    BE.Empresaid = empresa.Trim();
                    BE.Fichaid = ficha.Trim();
                    BE.Jefe = txtjefe.Text.Trim().ToString();
                    BE.Fechcese = dtpFechaCese.Value;
                    BE.Motivocese = cbMotivoCese.SelectedValue.ToString();
                    BE.Observacion = txtObs.Text.Trim();
                    retorno = BL.CesarTrabajadorUpdate(VariablesPublicas.EmpresaID, BE);
                    if (retorno)
                    {
                        MessageBox.Show("Cesado Correctamente !!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        validacion_panel(true);
                        Panel.Visible = false;
                        if (swB == 2)
                        {
                            DesEnlazaControles();
                        }
                        if (swB == 1)
                        {
                            EnlazarControles();
                        }
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Hubo problemas al momento de Cesar, cierra la ventana e intente de nuevo", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void limpiar()
        {
            txtjefe.Text = string.Empty;
            txtDjefe.Text = string.Empty;
            txtObs.Text = string.Empty;
        }

        private void txtjefe_GotFocus(object sender, System.EventArgs e)
        {
            j_Valor = txtjefe.Text;
        }
        private void txtjefe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                var f = new Frm_PllaAyudaRta5ta();
                f.Owner = this;
                f.PasaTrabajador = trabajador;
                f.ShowDialog();
            }
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("\t");
            }
        }
        private void trabajador(string codigo, string nombre)
        {
            txtjefe.Text = codigo.Trim();
            txtDjefe.Text = nombre.Trim();
        }
        private void txtjefe_LostFocus(object sender, System.EventArgs e)
        {
            if (txtjefe.Text.Trim().Length > 0)
            {
                txtjefe.Text = VariablesPublicas.PADL(txtjefe.Text.Trim(), 7, "0");
            }
            if (!(j_Valor == txtjefe.Text))
            {
                var odata = new DataTable();
                var BL = new tb_plla_fichatrabajadoresBL();
                var BE = new tb_plla_fichatrabajadores();
                BE.Fichaid = txtjefe.Text.Trim();
                BE.Norden = 1;
                odata = BL.GetAll_GETTRABAJADORES(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (odata.Rows.Count > 0)
                {
                    txtDjefe.Text = odata.Rows[0]["nombrelargo"].ToString();
                    txtjefe.Text = odata.Rows[0]["fichaid"].ToString();
                }
                else
                {
                    txtDjefe.Text = string.Empty;
                    txtjefe.Text = string.Empty;
                }
            }
        }

        private void dgTrabProceso_SelectionChanged(object sender, EventArgs e)
        {
            POnedatos();
        }
        private void POnedatos()
        {
            DesEnlazaControles();
            if ((dgTrabProceso.CurrentRow != null))
            {
                lblFicha.Text = dgTrabProceso.Rows[dgTrabProceso.CurrentRow.Index].Cells["ficha"].Value.ToString();
                lblContratoVigente.Text = dgTrabProceso.Rows[dgTrabProceso.CurrentRow.Index].Cells["contrato"].Value.ToString();
                txtinicio1.Text = dgTrabProceso.Rows[dgTrabProceso.CurrentRow.Index].Cells["FVIGLAB_I"].Value.ToString();
                txtTermino1.Text = dgTrabProceso.Rows[dgTrabProceso.CurrentRow.Index].Cells["FVIGLAB_F"].Value.ToString();
                txtInicio2.Text = dgTrabProceso.Rows[dgTrabProceso.CurrentRow.Index].Cells["FDURCON_I"].Value.ToString();
                txtTermino2.Text = dgTrabProceso.Rows[dgTrabProceso.CurrentRow.Index].Cells["FDURCON_F"].Value.ToString();
                txtTipo.Text = dgTrabProceso.Rows[dgTrabProceso.CurrentRow.Index].Cells["TIPLA"].Value.ToString();
                txtDtipo.Text = dgTrabProceso.Rows[dgTrabProceso.CurrentRow.Index].Cells["DTIPLA"].Value.ToString();
                txtModal.Text = dgTrabProceso.Rows[dgTrabProceso.CurrentRow.Index].Cells["CMODAL"].Value.ToString();
                txtDmodal.Text = dgTrabProceso.Rows[dgTrabProceso.CurrentRow.Index].Cells["DMODAL"].Value.ToString();
                cbEstado.SelectedValue = dgTrabProceso.Rows[dgTrabProceso.CurrentRow.Index].Cells["estado"].Value.ToString();
            }
        }
    }
}
