using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BapFormulariosNet.Codigo;
using bapFunciones;
using LayerBusinessEntities;
using LayerBusinessLogic;

namespace BapFormulariosNet.DL0Logistica
{
    public partial class Frm_attachedfile : Form
    {
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;
        private String PERFILID = string.Empty;
        private DataTable Tabla;
        private bool Sw_LOad = true;
        private int u_n_opsel = 0;
        private string xtmpfile = VariablesPublicas.TmpFile("TMP");
        private DataTable tmpcursor = new DataTable();
        private DataTable tmptabla = new DataTable();
        private string xnomcampo;
        private int lc_cont;
        private Byte[] vmContenidoFile;

        public String numdoc { get; set; }

        public String serdoc { get; set; }

        public String moduloiddes { get; set; }



        public Frm_attachedfile()
        {
            InitializeComponent();

            KeyDown += Frm_Planilla_PlantillaContratos_KeyDown;
            FormClosing += Frm_Planilla_PlantillaContratos_FormClosing;
            Load += Frm_attachedfile_Load;
        }



        private void CargaDatos()
        {
            var sorted = default(SortOrder);
            var xnomcolumna = string.Empty;
            if (dgvfileatached.SortedColumn != null)
            {
                xnomcolumna = dgvfileatached.Columns[dgvfileatached.SortedColumn.Index].Name;
                sorted = dgvfileatached.SortOrder;
            }


            var BL2 = new tb_cm_ordendecompradocBL();
            var BE2 = new tb_cm_ordendecompradoc();

            BE2.moduloid = VariablesPublicas.Moduloid;
            BE2.local = VariablesPublicas.Local;
            BE2.moduloiddes  = moduloiddes;
            BE2.numdoc = numdoc;
            BE2.serdoc = serdoc;

            Tabla = BL2.GetAll(VariablesPublicas.EmpresaID, BE2).Tables[0];

            if (Tabla.Rows.Count > 0)
            {
                dgvfileatached.AutoGenerateColumns = false;
                dgvfileatached.DataSource = Tabla;


                if (xnomcolumna.Trim().Length > 0)
                {
                    if (sorted == SortOrder.Ascending)
                    {
                        dgvfileatached.Sort(dgvfileatached.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Ascending);
                    }
                    else
                    {
                        dgvfileatached.Sort(dgvfileatached.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Descending);
                    }
                }
                else
                {
                    dgvfileatached.Sort(dgvfileatached.Columns["item"], System.ComponentModel.ListSortDirection.Ascending);
                }
            }
        }

        private void U_RefrescaControles()
        {
            btnnombrefile.Enabled = u_n_opsel > 0;
            var xcoduser = string.Empty;
            decimal npos = -1;
            if (dgvfileatached.CurrentRow != null)
            {
                xcoduser = dgvfileatached.Rows[dgvfileatached.CurrentCell.RowIndex].Cells["item"].Value.ToString();
                if (xcoduser.Trim().Length > 0)
                {
                    npos = VariablesPublicas.BuscarEnTable(xcoduser, "item", Tabla);
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
            dgvfileatached.Enabled = u_n_opsel == 0;
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
                        filaactual = dgvfileatached.CurrentRow.Index;
                        xtmpuser = dgvfileatached.Rows[filaactual].Cells["item"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        xtmpuser = "..11";
                    }
                }
                u_n_opsel = 0;
                U_RefrescaControles();
                CargaDatos();
                if (dgvfileatached.RowCount > 0)
                {
                    for (lc_cont = 0; lc_cont <= dgvfileatached.Rows.Count - 1; lc_cont++)
                    {
                        if (dgvfileatached.Rows[lc_cont].Cells["item"].Value.ToString() == xtmpuser)
                        {
                            dgvfileatached.CurrentCell = dgvfileatached.Rows[lc_cont].Cells["item"];
                            break;
                        }
                    }
                }
            }
            POnedatos();
            dgvfileatached.Focus();
            if (dgvfileatached.CurrentCell != null)
            {
                dgvfileatached.BeginEdit(true);
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
            if (dgvfileatached.CurrentRow != null)
            {
                txtcodigo.Text = dgvfileatached.Rows[dgvfileatached.CurrentRow.Index].Cells["item"].Value.ToString();
                txtdescripcion.Text = dgvfileatached.Rows[dgvfileatached.CurrentRow.Index].Cells["docglosa"].Value.ToString();
                txtnombrearchivo.Text = dgvfileatached.Rows[dgvfileatached.CurrentRow.Index].Cells["docname"].Value.ToString();

                if (!object.ReferenceEquals(dgvfileatached.Rows[dgvfileatached.CurrentRow.Index].Cells["documen"].Value, DBNull.Value))
                {
                    vmContenidoFile = (byte[])(dgvfileatached.Rows[dgvfileatached.CurrentRow.Index].Cells["documen"].Value);
                }
                else
                {
                    vmContenidoFile = null;
                }
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
                if (dgvfileatached.Enabled)
                {
                    dgvfileatached.Focus();
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
                    var BL = new tb_cm_ordendecompradocBL();
                    var BE = new tb_cm_ordendecompradoc();

                    BE.moduloid = VariablesPublicas.Moduloid;
                    BE.local = VariablesPublicas.Local;
                    BE.moduloiddes = moduloiddes;
                    BE.serdoc = serdoc;
                    BE.numdoc = numdoc;

                    txtcodigo.Text = BL.GetAll_MaxCodigo(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0].Rows[0]["maximo_codigo"].ToString();

                    if (dgvfileatached.CurrentRow != null)
                    {
                        dgvfileatached.CurrentRow.Selected = false;
                    }
                    break;
                case 2:
                    POnedatos();
                    u_n_opsel = 2;
                    U_RefrescaControles();
                    dgvfileatached.CurrentRow.Selected = true;
                    break;
                case 3:
                    xnomcampo = "";
                    if (dgvfileatached.CurrentRow != null)
                    {
                        var BLIR = new tb_cm_ordendecompradocBL();
                        var BEIR = new tb_cm_ordendecompradoc();
                        BEIR.items = dgvfileatached.Rows[dgvfileatached.CurrentRow.Index].Cells["item"].Value.ToString().Trim();
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
                        var message = "Desea Eliminar Registro  " + dgvfileatached.Rows[dgvfileatached.CurrentRow.Index].Cells["item"].Value.ToString().Trim() + "-" + dgvfileatached.Rows[dgvfileatached.CurrentRow.Index].Cells["docglosa"].Value.ToString().Trim() + " ...?";
                        var caption = "Mensaje del Sistema";
                        var buttons = MessageBoxButtons.YesNo;
                        DialogResult result;
                        result = MessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                            var BLE = new tb_cm_ordendecompradocBL();
                            var BEE = new tb_cm_ordendecompradoc();
                            BEE.items = dgvfileatached.Rows[dgvfileatached.CurrentRow.Index].Cells["item"].Value.ToString().Trim();
                            BEE.norden = 1;
                            BEE.ver_blanco = 0;
                            BEE.vista = 1;

                            BEE.moduloid = VariablesPublicas.Moduloid;
                            BEE.local = VariablesPublicas.Local;
                            BEE.moduloiddes = moduloiddes;
                            BEE.numdoc = numdoc;
                            BEE.serdoc = serdoc;

                            tmpcursor = BLE.GetAll(VariablesPublicas.EmpresaID, BEE).Tables[0];

                            if (BLE.Sql_Error.Length == 0)
                            {
                                if (BLE.Delete(VariablesPublicas.EmpresaID, BEE))
                                {
                                    for (lc_cont = 0; lc_cont <= Tabla.Rows.Count - 1; lc_cont++)
                                    {
                                        if (Tabla.Rows[lc_cont]["item"] == dgvfileatached.Rows[dgvfileatached.CurrentRow.Index].Cells["item"].Value)
                                        {
                                            Tabla.Rows[lc_cont].Delete();
                                            Tabla.AcceptChanges();
                                            break;
                                        }
                                    }
                                    dgvfileatached.Refresh();
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

        private void PARAMETROS_TABLA()
        {
            var xxferfil = string.Empty;
            var f = (MainLogistica)MdiParent;
            xxferfil = f.perfil.ToString();
            if (xxferfil.Trim().Length != 9)
            {
                MessageBox.Show("::: NO TIENE PERFIL !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PERFILID = xxferfil;
            var XTABLA_PERFIL = string.Empty;
            XTABLA_PERFIL = VariablesPublicas.GET_PARAMETROS_TABLA(xxferfil, Name);
            if (XTABLA_PERFIL.Trim().Length > 0 && XTABLA_PERFIL.Trim() != "0")
            {
                if (XTABLA_PERFIL.Trim().Length == 2)
                {
                    dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
                }
                else
                {
                    if (XTABLA_PERFIL.Trim().Length == 6)
                    {
                        dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
                        modulo = XTABLA_PERFIL.Trim().Substring(2, 4);
                    }
                    else
                    {
                        if (XTABLA_PERFIL.Trim().Length == 9)
                        {
                            dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
                            modulo = XTABLA_PERFIL.Trim().Substring(2, 4);
                            local = XTABLA_PERFIL.Trim().Substring(6, 3);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("::: No puede accede a FORMULARIO. \n::: Es necesario DOMINIO, MODULO Y LOCAL !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void save()
        {
            if (u_Validate())
            {
                var BL = new tb_cm_ordendecompradocBL();
                var BE = new tb_cm_ordendecompradoc();
                BE.norden = 1;
                BE.ver_blanco = 0;
                BE.vista = 1;

                BE.moduloid = VariablesPublicas.Moduloid;
                BE.local = VariablesPublicas.Local;

                BE.moduloiddes = moduloiddes;
                BE.serdoc = serdoc;
                BE.numdoc = numdoc;

                tmpcursor = BL.GetAll(VariablesPublicas.EmpresaID, BE).Tables[0];

                var ofila = tmpcursor.NewRow();

                ofila = VariablesPublicas.InsertIntoTable(tmpcursor);

                if (u_n_opsel == 1)
                {
                    BE.items = txtcodigo.Text.Trim();

                    BE.moduloid = VariablesPublicas.Moduloid;
                    BE.local = VariablesPublicas.Local;
                    BE.moduloiddes = moduloiddes;
                    BE.serdoc = serdoc;
                    BE.numdoc = numdoc;

                    tmptabla = BL.GetAll(VariablesPublicas.EmpresaID, BE).Tables[0];

                    if (tmptabla.Rows.Count > 0)
                    {
                        var BLMX = new tb_cm_ordendecompradocBL();
                        var BEMX = new tb_cm_ordendecompradoc();

                        BEMX.moduloid = VariablesPublicas.Moduloid;
                        BEMX.local = VariablesPublicas.Local;
                        BEMX.moduloiddes = moduloiddes;
                        BEMX.serdoc = serdoc;
                        BEMX.numdoc = numdoc;

                        ofila["item"] = BLMX.GetAll_MaxCodigo(VariablesPublicas.EmpresaID.ToString(), BEMX).Tables[0].Rows[0]["maximo_codigo"].ToString();
                    }
                    else
                    {
                        ofila["item"] = txtcodigo.Text;
                    }
                }
                else
                {
                    ofila["item"] = dgvfileatached.Rows[dgvfileatached.CurrentRow.Index].Cells["item"].Value;
                    for (lc_cont = 0; lc_cont <= dgvfileatached.ColumnCount - 1; lc_cont++)
                    {
                        xnomcampo = dgvfileatached.Columns[lc_cont].Name;
                        ofila[xnomcampo] = dgvfileatached.Rows[dgvfileatached.CurrentRow.Index].Cells[lc_cont].Value;
                    }
                }

                ofila["item"] = txtcodigo.Text.Trim();
                ofila["docglosa"] = txtdescripcion.Text.Trim();
                ofila["docname"] = txtnombrearchivo.Text.Trim();
                ofila["documen"] = vmContenidoFile;
                tmpcursor.Rows.Add(ofila);

                BE.moduloid = VariablesPublicas.Moduloid;
                BE.local = VariablesPublicas.Local;
                BE.moduloiddes = moduloiddes;
                BE.serdoc = serdoc;
                BE.numdoc = numdoc;

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
                if ((dgvfileatached.CurrentRow != null))
                {
                    if (dgvfileatached.Focused)
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

        private void dgvfileatached_SelectionChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad & u_n_opsel == 0)
            {
                POnedatos();
                U_RefrescaControles();
            }
        }

        private void Frm_attachedfile_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            WindowState = FormWindowState.Normal;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            CargaDatos();
            POnedatos();
            Sw_LOad = false;
            if (dgvfileatached.RowCount > 0)
            {
                dgvfileatached.Focus();
                dgvfileatached.BeginEdit(true);
            }
            U_RefrescaControles();
        }
    }
}
