using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using BapFormulariosNet.Codigo;

namespace BapFormulariosNet.RecursosHumanos.Tablas
{
    public partial class Frm_Planilla_PlantillaContratos : plantilla
    {
        private DataTable Tabla;
        private bool Sw_LOad = true;
        private int u_n_opsel = 0;
        private string xtmpfile = VariablesPublicas.TmpFile("TMP");
        private DataTable tmpcursor = new DataTable();
        private DataTable tmptabla = new DataTable();
        private string xnomcampo;
        private int lc_cont;
        private Byte[] vmContenidoFile;

        public Frm_Planilla_PlantillaContratos()
        {
            InitializeComponent();

            KeyDown += Frm_Planilla_PlantillaContratos_KeyDown;
            FormClosing += Frm_Planilla_PlantillaContratos_FormClosing;
            Load += Frm_Planilla_PlantillaContratos_Load;
        }

        private void Frm_Planilla_PlantillaContratos_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            WindowState = FormWindowState.Normal;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            CargaDatos();
            POnedatos();
            Llenar_cboEstadoContrato();
            ModalidadContrato();

            Sw_LOad = false;
            if (Examinar.RowCount > 0)
            {
                Examinar.Focus();
                Examinar.BeginEdit(true);
            }
            U_RefrescaControles();
        }


        private void ModalidadContrato()
        {
            cmb_tipocontrato.ValueMember = "tipocontratoid";
            cmb_tipocontrato.DisplayMember = "tipocontratoname";
            var BL = new tb_plla_tipocontratoBL();
            var BE = new tb_plla_tipocontrato();
            cmb_tipocontrato.DataSource = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
        }

        private void Llenar_cboEstadoContrato()
        {
            cmb_tipoestado.ValueMember = "cele";
            cmb_tipoestado.DisplayMember = "descripcion";

            var BL = new tb_plla_tab0100BL();
            var BE = new tb_plla_tab0100();
            cmb_tipoestado.DataSource = BL.GetAllEstadoContrato(VariablesPublicas.EmpresaID, BE).Tables[0];
        }

        private void CargaDatos()
        {
            var sorted = default(SortOrder);
            var xnomcolumna = string.Empty;
            if (Examinar.SortedColumn != null)
            {
                xnomcolumna = Examinar.Columns[Examinar.SortedColumn.Index].Name;
                sorted = Examinar.SortOrder;
            }
            var BL = new tb_plla_plantilla_contratosBL();
            var BE = new tb_plla_plantilla_contratos();
            BE.norden = 1;
            BE.ver_blanco = 0;
            BE.vista = 1;
            Tabla = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
            Examinar.AutoGenerateColumns = false;
            Examinar.DataSource = Tabla;
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
                Examinar.Sort(Examinar.Columns["plantillaid"], System.ComponentModel.ListSortDirection.Ascending);
            }
        }

        private void U_RefrescaControles()
        {
            btnnombrefile.Enabled = u_n_opsel > 0;
            var xcoduser = string.Empty;
            decimal npos = -1;
            if (Examinar.CurrentRow != null)
            {
                xcoduser = Examinar.Rows[Examinar.CurrentCell.RowIndex].Cells["plantillaid"].Value.ToString();
                if (xcoduser.Trim().Length > 0)
                {
                    npos = VariablesPublicas.BuscarEnTable(xcoduser, "plantillaid", Tabla);
                }
            }
            txtdescripcion.Enabled = u_n_opsel > 0;
            txtnombrearchivo.Enabled = false;
            txtcodigo.Enabled = u_n_opsel == 1;
            btnnuevo.Enabled = u_n_opsel == 0;
            btngrabar.Enabled = u_n_opsel > 0;
            btnmod.Enabled = u_n_opsel == 0 & npos > -1;
            btneliminar.Enabled = u_n_opsel == 0 & npos > -1;
            btncancelar.Enabled = u_n_opsel > 0;
            btncerrar.Enabled = u_n_opsel == 0;
            btnload.Enabled = u_n_opsel == 0;
            Examinar.Enabled = u_n_opsel == 0;
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            U_CancelarEdicion(1);
        }
        private void U_CancelarEdicion(int SwConfirmacion)
        {
            var xtmpuser = string.Empty;
            var sw_prosigue = true;
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
                if (tmpcursor != null)
                {
                    try
                    {
                        var filaactual = 0;
                        filaactual = Examinar.CurrentRow.Index;
                        xtmpuser = Examinar.Rows[filaactual].Cells["plantillaid"].Value.ToString();
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
                        if (Examinar.Rows[lc_cont].Cells["plantillaid"].Value.ToString() == xtmpuser)
                        {
                            Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["plantillaid"];
                            break;
                        }
                    }
                }
            }
            POnedatos();
            Examinar.Focus();
            if (Examinar.CurrentCell != null)
            {
                Examinar.BeginEdit(true);
            }
        }

        private void btngrabar_Click(object sender, EventArgs e)
        {
            save();
        }

        private void Frm_Planilla_PlantillaContratos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (u_n_opsel > 0)
            {
                MessageBox.Show("Finalice edición para cerrar formulario", "Mensaje del Sistema");
                e.Cancel = true;
            }
            else
            {
                u_BorrarFile();
                e.Cancel = false;
            }
        }

        private bool u_Validate()
        {
            var xmsg = string.Empty;
            var xobjeto = new object();
            if (txtdescripcion.Enabled & txtdescripcion.Text.Trim().Length == 0)
            {
                xmsg = "Ingrese descripción";
                xobjeto = txtdescripcion;
            }
            else
            {
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
            if (Examinar.CurrentRow != null)
            {
                txtcodigo.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["plantillaid"].Value.ToString();
                txtdescripcion.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["plantillaname"].Value.ToString();
                txtnombrearchivo.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["plantilladoc"].Value.ToString();
                cmb_tipocontrato.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipocontratoid"].Value.ToString();
                cmb_tipoestado.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipoestado"].Value.ToString();
                if (!object.ReferenceEquals(Examinar.Rows[Examinar.CurrentRow.Index].Cells["plantillaword"].Value, DBNull.Value))
                {
                    vmContenidoFile = (byte[])(Examinar.Rows[Examinar.CurrentRow.Index].Cells["plantillaword"].Value);
                }
                else
                {
                    vmContenidoFile = null;
                }
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

        private void Frm_Planilla_PlantillaContratos_KeyDown(object sender, KeyEventArgs e)
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
                    var BL = new tb_plla_plantilla_contratosBL();
                    var BE = new tb_plla_plantilla_contratos();
                    txtcodigo.Text = BL.GetAll_MaxCodigo(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0].Rows[0]["maximo_codigo"].ToString();
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
                    if (Examinar.CurrentRow != null)
                    {
                        var BLIR = new tb_plla_plantilla_contratosBL();
                        var BEIR = new tb_plla_plantilla_contratos();
                        BEIR.plantillaid = Examinar.Rows[Examinar.CurrentRow.Index].Cells["plantillaid"].Value.ToString().Trim();
                        tmpcursor = BLIR.GetAll_CONSULTAIR(VariablesPublicas.EmpresaID, BEIR).Tables[0];
                        if (BLIR.Sql_Error.Length > 0)
                        {
                            xnomcampo = BLIR.Sql_Error;
                            Frm_Class.ShowError(BLIR.Sql_Error, this);
                        }
                        else
                        {
                            if (tmpcursor.Rows.Count == 0)
                            {
                            }
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
                        var message = "Desea Eliminar Registro  " + Examinar.Rows[Examinar.CurrentRow.Index].Cells["plantillaid"].Value.ToString().Trim() + "-" + Examinar.Rows[Examinar.CurrentRow.Index].Cells["plantillaname"].Value.ToString().Trim() + " ...?";
                        var caption = "Mensaje del Sistema";
                        var buttons = MessageBoxButtons.YesNo;
                        DialogResult result;
                        result = MessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                            var BLE = new tb_plla_plantilla_contratosBL();
                            var BEE = new tb_plla_plantilla_contratos();
                            BEE.plantillaid = Examinar.Rows[Examinar.CurrentRow.Index].Cells["plantillaid"].Value.ToString().Trim();
                            BEE.norden = 1;
                            BEE.ver_blanco = 0;
                            BEE.vista = 1;
                            tmpcursor = BLE.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BEE).Tables[0];
                            if (BLE.Sql_Error.Length == 0)
                            {
                                if (BLE.Eliminar(VariablesPublicas.EmpresaID, tmpcursor))
                                {
                                    for (lc_cont = 0; lc_cont <= Tabla.Rows.Count - 1; lc_cont++)
                                    {
                                        if (Tabla.Rows[lc_cont]["plantillaid"] == Examinar.Rows[Examinar.CurrentRow.Index].Cells["plantillaid"].Value)
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
                                    Frm_Class.ShowError(BLE.Sql_Error, this);
                                }
                            }
                            else
                            {
                                Frm_Class.ShowError(BLE.Sql_Error, this);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(xnomcampo, "IMPOSIBLE ELIMINAR DOCUMENTO");
                    }
                    break;
            }
        }
        private void save()
        {
            if (u_Validate())
            {
                tmpcursor = null;
                var BL = new tb_plla_plantilla_contratosBL();
                var BE = new tb_plla_plantilla_contratos();
                BE.norden = 1;
                BE.ver_blanco = 0;
                BE.vista = 1;
                tmpcursor = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                var ofila = tmpcursor.NewRow();
                ofila = VariablesPublicas.InsertIntoTable(tmpcursor);
                if (u_n_opsel == 1)
                {
                    BE.plantillaid = txtcodigo.Text.Trim();
                    tmptabla = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                    if (tmptabla.Rows.Count > 0)
                    {
                        var BLMX = new tb_plla_plantilla_contratosBL();
                        var BEMX = new tb_plla_plantilla_contratos();
                        ofila["plantillaid"] = BLMX.GetAll_MaxCodigo(VariablesPublicas.EmpresaID.ToString(), BEMX).Tables[0].Rows[0]["maximo_codigo"].ToString();
                    }
                    else
                    {
                        ofila["plantillaid"] = txtcodigo.Text;
                    }
                }
                else
                {
                    ofila["plantillaid"] = Examinar.Rows[Examinar.CurrentRow.Index].Cells["plantillaid"].Value;
                    for (lc_cont = 0; lc_cont <= Examinar.ColumnCount - 1; lc_cont++)
                    {
                        xnomcampo = Examinar.Columns[lc_cont].Name;
                        ofila[xnomcampo] = Examinar.Rows[Examinar.CurrentRow.Index].Cells[lc_cont].Value;
                    }
                }

                ofila["plantillaid"] = txtcodigo.Text.Trim();
                ofila["plantillaname"] = txtdescripcion.Text.Trim();
                ofila["plantilladoc"] = txtnombrearchivo.Text.Trim();
                ofila["tipocontratoid"] = cmb_tipocontrato.SelectedValue.ToString();
                ofila["tipoestado"] = cmb_tipoestado.SelectedValue.ToString();
                ofila["plantillaword"] = vmContenidoFile;

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
            txtdescripcion.Text = string.Empty;
            txtcodigo.Text = string.Empty;
            vmContenidoFile = null;
            txtnombrearchivo.Text = string.Empty;
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
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

        private void btnnombrefile_Click(object sender, EventArgs e)
        {
            var vmnomfile = string.Empty;
            var SaveFileDialog = new OpenFileDialog();

            SaveFileDialog.ShowDialog();
            if (SaveFileDialog.FileName.Trim().Length > 0)
            {
                vmnomfile = SaveFileDialog.FileName.Trim();
                vmContenidoFile = VariablesPublicas.GetFileData(vmnomfile);
                txtnombrearchivo.Text = VariablesPublicas.ExtrarNombreArchivo(vmnomfile);
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if ((vmContenidoFile != null) & txtnombrearchivo.Text.Trim().Length > 0)
            {
                u_BorrarFile();
                xtmpfile = VariablesPublicas.TmpFile(VariablesPublicas.GetExtensionFile(txtnombrearchivo.Text.ToString()));
                if (VariablesPublicas.WriteFileData(xtmpfile, vmContenidoFile))
                {
                    try
                    {
                        System.Diagnostics.Process.Start(xtmpfile);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }
            }
        }

        public void u_BorrarFile()
        {
            try
            {
                System.IO.File.Delete(xtmpfile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
