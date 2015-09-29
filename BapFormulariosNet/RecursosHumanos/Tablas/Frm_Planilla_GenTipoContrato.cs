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

namespace BapFormulariosNet.RecursosHumanos.Tablas
{
    public partial class Frm_Planilla_GenTipoContrato : plantilla
    {
        private DataTable Tabla;
        private bool Sw_LOad = true;
        private int u_n_opsel = 0;
        private DataTable tmpcursor = new DataTable();
        DataTable tmptabla = new DataTable();
        string xnomcampo;
        int lc_cont;

        public Frm_Planilla_GenTipoContrato()
        {
            InitializeComponent();

            KeyDown += Frm_Planilla_GenTipoContrato_KeyDown;
            FormClosing += Frm_Planilla_GenTipoContrato_FormClosing;
            Load += Frm_Planilla_GenTipoContrato_Load;
        }

        #region Llenar Combos
        void llenar_TipoContrato()
        {
            tb_plla_pdt_tabla12BL BL = new tb_plla_pdt_tabla12BL();
            tb_plla_pdt_tabla12 BE = new tb_plla_pdt_tabla12();
            BE.norden = 1;
            BE.incluir_blanco = 1;
            cmbtipcontrato.ValueMember = "tipcontratoid";
            cmbtipcontrato.DisplayMember = "descripcion";
            cmbtipcontrato.DataSource = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
        }

        void llenar_FormatoContrato()
        {
            tb_plla_plantilla_contratosBL BL = new tb_plla_plantilla_contratosBL();
            tb_plla_plantilla_contratos BE = new tb_plla_plantilla_contratos();
            BE.norden = 1;
            BE.ver_blanco = 1;
            BE.vista = 2;
            cmbformatocontrato.ValueMember = "tipocontratoid";
            cmbformatocontrato.DisplayMember = "descripcion";
            cmbformatocontrato.DataSource = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
        }
        #endregion

        private void Frm_Planilla_GenTipoContrato_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            WindowState = FormWindowState.Normal;
            FormBorderStyle = FormBorderStyle.Fixed3D;

            llenar_TipoContrato();
            llenar_FormatoContrato();
            CargaDatos();
            POnedatos();
            Sw_LOad = false;
            if (Examinar.RowCount > 0)
            {
                Examinar.Focus();
                Examinar.BeginEdit(true);
            }
            U_RefrescaControles();
        }

        private void CargaDatos()
        {
            SortOrder sorted = default(SortOrder);
            string xnomcolumna = "";

            if (Examinar.SortedColumn != null)
            {
                xnomcolumna = Examinar.Columns[Examinar.SortedColumn.Index].Name;
                sorted = Examinar.SortOrder;
            }

            tb_plla_tipocontratoBL BL = new tb_plla_tipocontratoBL();
            tb_plla_tipocontrato BE = new tb_plla_tipocontrato();

            BE.norden = 1;
            BE.ver_blanco = 0;
            Tabla = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
            Examinar.AutoGenerateColumns = false;
            Examinar.DataSource = Tabla;
            VariablesPublicas.PintaEncabezados(Examinar);

            if (xnomcolumna.Trim().Length > 0)
            {
                if (sorted == SortOrder.Ascending)
                {
                    Examinar.Sort(Examinar.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Ascending);
                }
                else
                {
                    Examinar.Sort(Examinar.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Descending);
                }
            }
            else
            {
                Examinar.Sort(Examinar.Columns["tipocontratoid"], System.ComponentModel.ListSortDirection.Ascending);
            }
        }

        private void U_RefrescaControles()
        {
            string xcoduser = "";
            decimal npos = -1;
            if ((Examinar.CurrentRow != null))
            {
                xcoduser = Examinar.Rows[Examinar.CurrentCell.RowIndex].Cells["tipocontratoid"].Value.ToString();
                if (xcoduser.Trim().Length > 0)
                {
                    npos = VariablesPublicas.BuscarEnTable(xcoduser, "tipocontratoid", Tabla);
                }
            }
            txtDescripcion.Enabled = u_n_opsel > 0;

            cmbtipcontrato.Enabled = u_n_opsel > 0;
            cmbformatocontrato.Enabled = u_n_opsel > 0;
            txtcodigo.Enabled = u_n_opsel == 1;
            // Botonera
            btnnuevo.Enabled = u_n_opsel == 0;
            btngrabar.Enabled = u_n_opsel > 0;
            btnmod.Enabled = u_n_opsel == 0 & npos > -1;
            btneliminar.Enabled = u_n_opsel == 0 & npos > -1;
            btncancelar.Enabled = u_n_opsel > 0;
            btncerrar.Enabled = u_n_opsel == 0;
            btnload.Enabled = u_n_opsel == 0;
            // Campos 
            Examinar.Enabled = u_n_opsel == 0;
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            U_CancelarEdicion(1);
        }
        private void U_CancelarEdicion(int SwConfirmacion)
        {
            string xtmpuser = "";
            bool sw_prosigue = true;
            if (SwConfirmacion == 1)
            {
                sw_prosigue = (MessageBox.Show("Desea cancelar ingreso de datos...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
            }
            else
            {
                sw_prosigue = true;
            }

            if (sw_prosigue)
            {
                if ((tmpcursor != null))
                {
                    try
                    {
                        int filaactual = 0;
                        filaactual = Examinar.CurrentRow.Index;
                        xtmpuser = Examinar.Rows[filaactual].Cells["tipocontratoid"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        xtmpuser = "..11";
                    }
                }
                u_n_opsel = 0;
                U_RefrescaControles();
                CargaDatos();
                if (Examinar.RowCount > 0)
                {
                    for (lc_cont = 0; lc_cont <= Examinar.Rows.Count - 1; lc_cont++)
                    {
                        if (Examinar.Rows[lc_cont].Cells["tipocontratoid"].Value.ToString() == xtmpuser)
                        {
                            Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["tipocontratoid"];
                            break;
                        }
                    }
                }
                POnedatos();
                Examinar.Focus();
                if ((Examinar.CurrentCell != null))
                {
                    Examinar.BeginEdit(true);
                }
            }    
        }

        private void btngrabar_Click(object sender, EventArgs e)
        {
            save();
        }

        private void Frm_Planilla_GenTipoContrato_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (u_n_opsel > 0)
            {
                MessageBox.Show("Finalice edición para cerrar formulario !!!", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private bool u_Validate()
        {
            string xmsg = "";
            object xobjeto = new object();
            if (txtDescripcion.Enabled & txtDescripcion.Text.Trim().Length == 0)
            {
                xmsg = "Ingrese descripción";
                xobjeto = txtDescripcion;
            }

            if (!(xmsg.Trim().Length == 0))
            {
                MessageBox.Show(xmsg, "VALIDACION");
                if ((xobjeto != null))
                {
                    xobjeto = Focus();
                }
            }
            return xmsg.Trim().Length == 0;
        }

        private void POnedatos()
        {
            Blanquear();
            if ((Examinar.CurrentRow != null))
            {
                txtcodigo.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipocontratoid"].Value.ToString();
                txtDescripcion.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipocontratoname"].Value.ToString();                
                cmbtipcontrato.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["pdttipocontrato"].Value.ToString();
                cmbformatocontrato.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["formatocontrato"].Value.ToString();
            }
        }

        private void Examinar_SelectionChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad & u_n_opsel == 0)
            {
                POnedatos();
                U_RefrescaControles();
            }
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            U_CancelarEdicion(0);
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            Accion(3);
        }

        private void Frm_Planilla_GenTipoContrato_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (btnnuevo.Enabled)
                {
                    Accion(1);
                }
            }
            if (e.KeyCode == Keys.F3)
            {
                if (btnmod.Enabled)
                {
                    Accion(2);
                }
            }
            if (e.KeyCode == Keys.F8)
            {
                if (btneliminar.Enabled)
                {
                    Accion(3);
                }
            }
            if (e.Control & e.KeyCode == Keys.G)
            {
                if (btngrabar.Enabled)
                {
                    save();
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (btncancelar.Enabled)
                {
                    U_CancelarEdicion(1);
                }
                else
                {
                    Close();
                }
            }
            if (e.KeyCode == Keys.F4)
            {
                if (Examinar.Enabled)
                {
                    Examinar.Focus();
                }
            }
            if (e.KeyCode == Keys.F5)
            {
                if (btnload.Enabled)
                {
                    U_CancelarEdicion(0);
                }
            }
        }

        private void Accion(int naccion)
        {
            switch (naccion)
            {
                case 1:
                    u_n_opsel = 1;
                    U_RefrescaControles();
                    Blanquear();
                    tb_plla_tipocontratoBL BL = new tb_plla_tipocontratoBL();
                    tb_plla_tipocontrato BE = new tb_plla_tipocontrato();
                    txtcodigo.Text = BL.GetAll_MaxCodigo(VariablesPublicas.EmpresaID, BE).Tables[0].Rows[0]["maximo_codigo"].ToString();
                    if (Examinar.CurrentRow != null)
                    {
                        Examinar.CurrentRow.Selected = false;
                    }
                    break;
                case 2:
                    POnedatos();
                    u_n_opsel = 2;
                    U_RefrescaControles();
                    Examinar.CurrentRow.Selected = true;
                    break;
                case 3:
                    xnomcampo = "";
                    if ((Examinar.CurrentRow != null))
                    {
                        tb_plla_tipocontratoBL BLIR = new tb_plla_tipocontratoBL();
                        tb_plla_tipocontrato BEIR = new tb_plla_tipocontrato();
                        BEIR.tipocontratoid = Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipocontratoid"].Value.ToString();
                        //tmpcursor = BLIR.GetAll_CONSULTAIR(VariablesPublicas.EmpresaID, BEIR).Tables[0];
                        //tmpcursor = ocapa.IR_PAG1500(GlobalVars.GetInstance.Company, Examinar.Rows(Examinar.CurrentRow.Index).Cells("tipocontratoid").Value);
                        if (BLIR.Sql_Error.Length > 0)
                        {
                            xnomcampo = BLIR.Sql_Error;
                            Frm_Class.ShowError(BLIR.Sql_Error, this);
                        }
                        else
                        {
                            if (tmpcursor.Rows.Count == 0)
                            { }
                            else
                            {
                                for (lc_cont = 0; lc_cont <= tmpcursor.Rows.Count - 1; lc_cont++)
                                {
                                    xnomcampo = xnomcampo + tmpcursor.Rows[lc_cont]["relacion"] + "\r";
                                    if (lc_cont + 1 == 10)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (xnomcampo.Length == 0)
                    {
                        if (MessageBox.Show("Desea Eliminar Registro ..?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            tb_plla_tipocontratoBL BLCO = new tb_plla_tipocontratoBL();
                            tb_plla_tipocontrato BECO = new tb_plla_tipocontrato();
                            BECO.tipocontratoid = Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipocontratoid"].Value.ToString();
                            BECO.norden = 1;
                            BECO.ver_blanco = 0;
                            tmpcursor = BLCO.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BECO).Tables[0];
                            if (BLCO.Sql_Error.Length == 0)
                            {
                                if (BLCO.Eliminar(VariablesPublicas.EmpresaID, tmpcursor))
                                {
                                    for (lc_cont = 0; lc_cont <= Tabla.Rows.Count - 1; lc_cont++)
                                    {
                                        if (Tabla.Rows[lc_cont]["tipocontratoid"] == Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipocontratoid"].Value)
                                        {
                                            Tabla.Rows[lc_cont].Delete();
                                            Tabla.AcceptChanges();
                                            break; 
                                        }
                                    }
                                    Examinar.Refresh();
                                }
                                else
                                {
                                    Frm_Class.ShowError(BLCO.Sql_Error, this);
                                }
                            }
                            else
                            {
                                Frm_Class.ShowError(BLCO.Sql_Error, this);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(xnomcampo, "Imposible Eliminar Registro");
                    }
                    break;
            }
        }
        private void save()
        {
            if (u_Validate())
            {
                tmpcursor = null;
                tb_plla_tipocontratoBL BL = new tb_plla_tipocontratoBL();
                tb_plla_tipocontrato BE = new tb_plla_tipocontrato();

                BE.norden = 1;
                BE.ver_blanco = 0;
                tmpcursor = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                DataRow ofila = tmpcursor.NewRow();
                ofila = VariablesPublicas.InsertIntoTable(tmpcursor);
                if (u_n_opsel == 1)
                {
                    tmptabla = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                    if (tmptabla.Rows.Count > 0)
                    {
                        ofila["tipocontratoid"] = BL.GetAll_MaxCodigo(VariablesPublicas.EmpresaID, BE).Tables[0].Rows[0]["maximo_codigo"].ToString();
                    }
                    else
                    {
                        ofila["tipocontratoid"] = txtcodigo.Text;
                    }
                    ofila["status"] = 1;
                }
                else
                {
                    ofila["tipocontratoid"] = Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipocontratoid"].Value;
                    for (lc_cont = 0; lc_cont <= Examinar.ColumnCount - 1; lc_cont++)
                    {
                        xnomcampo = Examinar.Columns[lc_cont].Name;
                        ofila[xnomcampo] = Examinar.Rows[Examinar.CurrentRow.Index].Cells[lc_cont].Value;
                    }
                }
                ofila["tipocontratoid"] = txtcodigo.Text;
                ofila["tipocontratoname"] = txtDescripcion.Text;
                if ((cmbtipcontrato.SelectedValue != null))
                {
                    ofila["pdttipocontrato"] = cmbtipcontrato.SelectedValue;
                }
                if ((cmbformatocontrato.SelectedValue != null))
                {
                    ofila["formatocontrato"] = cmbformatocontrato.SelectedValue;
                }
                tmpcursor.Rows.Add(ofila);
                if (BL.Insert_Update(VariablesPublicas.EmpresaID, BE, tmpcursor))
                {
                    U_CancelarEdicion(0);
                }
                else
                {
                    Frm_Class.ShowError(BL.Sql_Error, this);
                }
            }
        }

        public void Blanquear()
        {
            txtDescripcion.Text = "";
            txtcodigo.Text = "";
            cmbtipcontrato.Text = "";
            cmbformatocontrato.SelectedValue = "";
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            // Si el control tiene el foco...
            if (keyData == Keys.Enter)
            {
                if ((Examinar.CurrentRow != null))
                {
                    if (Examinar.Focused)
                    {
                        return true;
                    }
                    else
                    {
                        SendKeys.Send("\t");
                        return true;
                    }
                }
                else
                {
                    SendKeys.Send("\t");
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            Accion(1);
        }

        private void btnmod_Click(object sender, EventArgs e)
        {
            Accion(2);
        }

        public void u_LoadComboFormatoContrato()
        {
            tb_plla_plantilla_contratosBL BL = new tb_plla_plantilla_contratosBL();
            tb_plla_plantilla_contratos BE = new tb_plla_plantilla_contratos();
            BE.norden = 1;
            BE.ver_blanco = 1;
            BE.vista = 2;
            cmbformatocontrato.ValueMember = "tipocontratoid";
            cmbformatocontrato.DisplayMember = "descripcion";
            cmbformatocontrato.DataSource = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
        }

        private void cmbformatocontrato_GotFocus(object sender, System.EventArgs e)
        {
        }
    }
}
