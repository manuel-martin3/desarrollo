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
    public partial class Frm_Planilla_GenEventosPermiso : plantilla
    {
        private DataTable tablaclientes;
	    //private string _NameColumn = "";
	    string xnomcampo = "";
	    string VM_DESCRIPCION = "";
	    DataTable tmpcursor;
        string j_xFiltronom = "";
        bool sw_EmpiezaEdicion = false;
	    private DataTable tmptabla;
	    private bool Sw_LOad = true;
	    private int u_n_opsel = 0;
	    int lc_cont;
	    private int cdClave = 0;

        public Frm_Planilla_GenEventosPermiso()
        {
            InitializeComponent();

            KeyDown += Frm_Planilla_GenEventosPermiso_KeyDown;
            FormClosing += Frm_Planilla_GenEventosPermiso_FormClosing;
            Load += Frm_Planilla_GenEventosPermiso_Load;
            Activated += Frm_Planilla_GenEventosPermiso_Activated;

            txtfiltronombre.LostFocus += new System.EventHandler(txtfiltronombre_LostFocus);
            txtfiltronombre.GotFocus += new System.EventHandler(txtfiltronombre_GotFocus);

            txtcodigo.LostFocus += new System.EventHandler(txtcodigo_LostFocus);
        }

        private void Frm_Planilla_GenEventosPermiso_Activated(object sender, EventArgs e)
        {
            if (Sw_LOad)
            {
                //cmbtipo.ValueMember = "cele";
                //cmbtipo.DisplayMember = "dele";
                //cmbtipo.DataSource = ocapa.CaeSoft_GetAllTipoEventoPermiso;
                tb_plla_geneventospermisoBL BL = new tb_plla_geneventospermisoBL();
                tb_plla_geneventospermiso BE = new tb_plla_geneventospermiso();
                cmbtipo.ValueMember = "cele";
                cmbtipo.DisplayMember = "descripcion";
                cmbtipo.DataSource = BL.GetAllTipoEvento(VariablesPublicas.EmpresaID, BE).Tables[0];
                U_RefrescaControles();
                CargaDatos();
                U_RefrescaControles();
                Sw_LOad = false;
            }
        }
        private void Frm_Planilla_GenEventosPermiso_Load(object sender, EventArgs e)
        {
            object[] arreglobotones = {
			btnnuevo,
			btnmod,
			btngrabar,
			btncancelar,
			btneliminar,
			btnload,
			null,
			btncerrar };
            VariablesPublicas.ConfiguraToolbar(arreglobotones);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            //cmbcodsunat.DataSource = ocapa.PDT_TABLATIPOSUSPENSIONRELLAB_CONSULTA("", "", "", "", "", 2, 1);
            //cmbcodsunat.ValueMember = "codigo";
            //cmbcodsunat.DisplayMember = "Descripcion";
            tb_plla_pdt_tabla21BL BL = new tb_plla_pdt_tabla21BL();
            tb_plla_pdt_tabla21 BE = new tb_plla_pdt_tabla21();
            BE.norden = 1;
            BE.incluir_blanco = 1;
            cmbcodsunat.DataSource = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
            cmbcodsunat.ValueMember = "tipsuspenid";
            cmbcodsunat.DisplayMember = "Descripcion";

            MaximizeBox = false;
            WindowState = FormWindowState.Normal;
            //CenterToScreen();
        }

        private void CargaDatos()
        {
            int nposcolumnasortear = 0;
            SortOrder PrvSotOrder = default(SortOrder);
            bool zordenado = false;
            string xcodcliente = "..";
            string xpalabra1 = "";
            string xpalabra2 = "";
            string xpalabra3 = "";
            if (txtfiltronombre.Text.Trim().Length > 0)
            {
                xpalabra1 = VariablesPublicas.Palabras(txtfiltronombre.Text, 1);
                xpalabra2 = VariablesPublicas.Palabras(txtfiltronombre.Text, 2);
                xpalabra3 = VariablesPublicas.Palabras(txtfiltronombre.Text, 3);
            }
            if ((Examinar.CurrentRow != null))
            {
                xcodcliente = Examinar.Rows[Examinar.CurrentRow.Index].Cells["eventoperid"].Value.ToString();
            }
            if ((Examinar.SortedColumn != null))
            {
                nposcolumnasortear = Examinar.SortedColumn.Index;
                PrvSotOrder = Examinar.SortOrder;
                zordenado = true;
            }
            tb_plla_geneventospermisoBL BL = new tb_plla_geneventospermisoBL();
            tb_plla_geneventospermiso BE = new tb_plla_geneventospermiso();
            BE.norden = 1;
            BE.nomlike1 = xpalabra1;
            BE.nomlike2 = xpalabra2;
            BE.nomlike3 = xpalabra3;
            tablaclientes = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
            if (BL.Sql_Error.Length > 0)
            {
                Frm_Class.ShowError(BL.Sql_Error, this);
                return;
            }
            Examinar.AutoGenerateColumns = false;
            Examinar.DataSource = tablaclientes;

            //if (!(txtdescripcion.MaxLength == tablaclientes.Columns["eventopername"].MaxLength))
            //{
            //    txtdescripcion.MaxLength = tablaclientes.Columns["eventopername"].MaxLength;
            //}

            VariablesPublicas.PintaEncabezados(Examinar);

            if (zordenado)
            {
                if (PrvSotOrder == SortOrder.Ascending)
                {
                    Examinar.Sort(Examinar.Columns[nposcolumnasortear], System.ComponentModel.ListSortDirection.Ascending);
                }
                else
                {
                    Examinar.Sort(Examinar.Columns[nposcolumnasortear], System.ComponentModel.ListSortDirection.Descending);
                }
            }
            else
            {
                Examinar.Sort(Examinar.Columns["eventoperid"], System.ComponentModel.ListSortDirection.Ascending);
            }
            if (Examinar.CurrentRow == null)
            {
                if (Examinar.RowCount > 0)
                {
                    Examinar.CurrentCell = Examinar.Rows[0].Cells["eventoperid"];
                }
            }
            for (lc_cont = 0; lc_cont <= Examinar.Rows.Count - 1; lc_cont++)
            {
                if (Examinar.Rows[lc_cont].Cells["eventoperid"].Value.ToString() == xcodcliente)
                {
                    Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["eventoperid"];
                    break; 
                }
            }
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            u_PintaDatos();
        }

        private void U_RefrescaControles()
        {
            cmbcodsunat.Enabled = u_n_opsel > 0;
            txtcodigo.Enabled = u_n_opsel == 1;
            txtdescripcion.Enabled = u_n_opsel > 0;
            cmbtipo.Enabled = u_n_opsel > 0;
            chkactivo.Enabled = u_n_opsel > 0;
            btnload.Enabled = u_n_opsel == 0;
            btnprimero.Enabled = u_n_opsel == 0;
            btnultimo.Enabled = u_n_opsel == 0;
            btnsiguiente.Enabled = u_n_opsel == 0;
            btnanterior.Enabled = u_n_opsel == 0;

            string xcodcliente = "";
            if ((Examinar.CurrentRow != null))
            {
                xcodcliente = Examinar.Rows[Examinar.CurrentCell.RowIndex].Cells["eventoperid"].Value.ToString();
            }

            btnnuevo.Enabled = u_n_opsel == 0;
            btngrabar.Enabled = u_n_opsel > 0;
            btnmod.Enabled = u_n_opsel == 0 & xcodcliente.Length > 0;
            btneliminar.Enabled = u_n_opsel == 0 & xcodcliente.Length > 0;
            btncancelar.Enabled = u_n_opsel > 0;
            btncerrar.Enabled = u_n_opsel == 0;
            barramain.Enabled = cdClave == 0;
            Examinar.Enabled = u_n_opsel == 0;
            btnlog.Enabled = u_n_opsel == 0;

        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            if (!(TabControl1.SelectedIndex == 0))
            {
                TabControl1.SelectedIndex = 0;
            }
            u_n_opsel = 1;
            Blanquear();
            U_RefrescaControles();
            TabControl1.SelectedIndex = 0;
            TabControl1.SelectedIndex = 1;
            tb_plla_geneventospermisoBL BL = new tb_plla_geneventospermisoBL();
            tb_plla_geneventospermiso BE = new tb_plla_geneventospermiso();
            txtcodigo.Text = BL.GetAll_MaxCodigo(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0].Rows[0]["maximo_codigo"].ToString();
            chkactivo.Checked = true;
            cmbtipo.SelectedValue = "N";
            txtdescripcion.Focus();
        }

        private void Blanquear()
        {
            cmbcodsunat.SelectedValue = "";
            txtcodigo.Text = "";
            txtdescripcion.Text = "";
            chkactivo.Checked = false;
            cmbtipo.SelectedValue = "";
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            U_CancelarEdicion(1);
        }
        private void U_CancelarEdicion(int SwConfirmacion)
        {
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
                string xtmpuser = txtcodigo.Text;
                u_n_opsel = 0;
                TabControl1.SelectedIndex = 0;
                U_RefrescaControles();
                CargaDatos();
                if (Examinar.RowCount > 0)
                {
                    for (lc_cont = 0; lc_cont <= Examinar.Rows.Count - 1; lc_cont++)
                    {
                        if (Examinar.Rows[lc_cont].Cells["eventoperid"].Value.ToString() == xtmpuser)
                        {
                            Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["eventoperid"];
                            break; 
                        }
                    }
                }
            }
        }

        private void btnmod_Click(object sender, EventArgs e)
        {
            if (!(TabControl1.SelectedIndex == 0))
            {
                TabControl1.SelectedIndex = 0;
            }
            u_n_opsel = 2;
            sw_EmpiezaEdicion = true;
            TabControl1.SelectedIndex = 1;
            sw_EmpiezaEdicion = false;
            U_RefrescaControles();
            VM_DESCRIPCION = txtdescripcion.Text;
            txtdescripcion.Focus();
        }

        private void btngrabar_Click(object sender, EventArgs e)
        {
            if (U_Validacion())
            {
                tb_plla_geneventospermisoBL BL = new tb_plla_geneventospermisoBL();
                tb_plla_geneventospermiso BE = new tb_plla_geneventospermiso();
                BE.eventoperid = txtcodigo.Text.Trim();
                BE.norden = 1;
                tmpcursor = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (u_n_opsel == 1)
                {
                    while (1 == 1)
                    {
                        tmpcursor = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                        if (BL.Sql_Error.Length > 0)
                        {
                            Frm_Class.ShowError(BL.Sql_Error + "\r" + "Error al buscar código", this);
                            return;
                        }
                        if (tmpcursor.Rows.Count > 0)
                        {
                            tb_plla_geneventospermisoBL BLMX = new tb_plla_geneventospermisoBL();
                            tb_plla_geneventospermiso BEMX = new tb_plla_geneventospermiso();
                            txtcodigo.Text = BLMX.GetAll_MaxCodigo(VariablesPublicas.EmpresaID.ToString(), BEMX).Tables[0].Rows[0]["maximo_codigo"].ToString();
                        }
                        else
                        {
                            break; 
                        }
                    }
                    tmpcursor = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                    tmpcursor.Rows.Add(VariablesPublicas.InsertIntoTable(tmpcursor));
                    tmpcursor.Rows[0]["eventoperid"] = txtcodigo.Text.Trim();
                }
                tmpcursor.Rows[0]["eventopername"] = txtdescripcion.Text.Trim();
                tmpcursor.Rows[0]["planilla"] = 1;
                tmpcursor.Rows[0]["status"] = (chkactivo.Checked ? 1 : 0);
                tmpcursor.Rows[0]["rtpssunat"] = cmbcodsunat.SelectedValue;
                if (cmbtipo.SelectedValue != null)
                {
                    tmpcursor.Rows[0]["tipoevento"] = cmbtipo.SelectedValue;
                }
                tmpcursor.AcceptChanges();
                if (BL.Insert_Update(VariablesPublicas.EmpresaID, BE, tmpcursor))
                {
                    seguridadlog();
                    U_CancelarEdicion(0);
                }
                else
                {
                    Frm_Class.ShowError(BL.Sql_Error, this);
                }
            }
        }
        void seguridadlog()
        {
            string xclave = VariablesPublicas.EmpresaID + txtcodigo.Text.Trim();
            try
            {
                tb_co_seguridadlogBL BL = new tb_co_seguridadlogBL();
                tb_co_seguridadlog BE = new tb_co_seguridadlog();

                BE.moduloid = Name;
                BE.clave = xclave;
                BE.cuser = VariablesPublicas.Usuar;
                BE.fecha = DateTime.Now;
                BE.pc = VariablesPublicas.userip;
                BE.accion = (u_n_opsel == 1 ? "N" : "M");
                BE.detalle = "Descripción: " + txtdescripcion.Text.Trim();

                BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if ((Examinar.CurrentRow != null))
            {                
                xnomcampo = "";
                tb_plla_geneventospermisoBL BLEP = new tb_plla_geneventospermisoBL();
                tb_plla_geneventospermiso BEEP = new tb_plla_geneventospermiso();
                BEEP.eventoperid = Examinar.Rows[Examinar.CurrentRow.Index].Cells["eventoperid"].Value.ToString();
                //tmpcursor = BLEP.GetAll_CONSULTAIR(VariablesPublicas.EmpresaID, BEEP).Tables[0];
                //tmpcursor = ocapa.IR_EVENTOSPERMISO(GlobalVars.GetInstance.Company, Examinar.Rows(Examinar.CurrentRow.Index).Cells("eventoperid").Value);
                if (BLEP.Sql_Error.Length > 0)
                {
                    xnomcampo = BLEP.Sql_Error;
                    Frm_Class.ShowError(BLEP.Sql_Error, this);
                }
                else
                {
                    //if (tmpcursor.Rows.Count == 0)
                    //{
                    //}
                    //else
                    //{
                    //    for (lc_cont = 0; lc_cont <= tmpcursor.Rows.Count - 1; lc_cont++)
                    //    {
                    //        xnomcampo = xnomcampo + tmpcursor.Rows[lc_cont]["relacion"] + "\r";
                    //        if (lc_cont + 1 == 10)
                    //        {
                    //            break;
                    //        }
                    //    }
                    //}
                }
                if (xnomcampo.Length == 0)
                {
                    tb_plla_geneventospermisoBL BL = new tb_plla_geneventospermisoBL();
                    tb_plla_geneventospermiso BE = new tb_plla_geneventospermiso();
                    BE.eventoperid = Examinar.Rows[Examinar.CurrentRow.Index].Cells["eventoperid"].Value.ToString().Trim();
                    BE.norden = 1;
                    tmptabla = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                    if (BL.Sql_Error.Length == 0)
                    {
                        string message = "Desea eliminar datos  " + tmptabla.Rows[0]["eventoperid"].ToString().Trim() + "-" + tmptabla.Rows[0]["eventopername"].ToString().Trim() + " ...?";
                        string caption = "Mensaje del Sistema";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;
                        // Muestra el cuadro de mensaje.
                        result = MessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                            BL.Eliminar(VariablesPublicas.EmpresaID, tmptabla);
                            if (BL.Sql_Error.Length == 0)
                            {
                                tb_co_seguridadlogBL BLL = new tb_co_seguridadlogBL();
                                tb_co_seguridadlog BEL = new tb_co_seguridadlog();

                                BEL.moduloid = Name;
                                BEL.clave = VariablesPublicas.EmpresaID + Examinar.Rows[Examinar.CurrentRow.Index].Cells["eventoperid"].Value.ToString();
                                BEL.cuser = VariablesPublicas.Usuar;
                                BEL.fecha = DateTime.Now;
                                BEL.pc = VariablesPublicas.userip;
                                BEL.accion = "B";
                                BEL.detalle = "Descripción: " + txtdescripcion.Text.Trim();
                                BLL.Insert(VariablesPublicas.EmpresaID.ToString(), BEL);
                                Examinar.Rows.Remove(Examinar.CurrentRow);
                                Examinar.Refresh();
                                u_PintaDatos();
                            }
                            else
                            {
                                Frm_Class.ShowError(BL.Sql_Error, this);
                            }
                        }
                    }
                    else
                    {
                        Frm_Class.ShowError(BL.Sql_Error, this);
                    }
                }
                else
                {
                    MessageBox.Show(xnomcampo, "IMPOSIBLE ELIMINAR REGISTRO");
                }
            }
            U_RefrescaControles();
        }

        private void Frm_Planilla_GenEventosPermiso_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (u_n_opsel > 0)
            {
                MessageBox.Show("Finalice edición para cerrar formulario", "Mensaje del Sistema");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            CargaDatos();
            u_PintaDatos();
        }

        public bool U_Validacion()
        {
            string xmsg = "";
            object objeto = new object();


            if (txtdescripcion.Text.Trim().Length == 0)
            {
                xmsg = "Ingrese Descripción";
                objeto = txtdescripcion;
            }
            if (!(VM_DESCRIPCION == txtdescripcion.Text) & u_n_opsel > 1)
            {
                xnomcampo = "";
                //tmpcursor = ocapa.IR_MOTIVOSTIPOPRESTAMO(txtcodigo.Text);
                //if (ocapa.sql_error.Length > 0)
                //{
                //    xnomcampo = ocapa.sql_error;
                //    Frm_Class.ShowError(ocapa.sql_error, this);
                //    return false;
                //}
                //else
                //{
                //    if (tmpcursor.Rows.Count == 0)
                //    {
                //    }
                //    else
                //    {
                //        for (lc_cont = 0; lc_cont <= tmpcursor.Rows.Count - 1; lc_cont++)
                //        {
                //            xnomcampo = xnomcampo + tmpcursor.Rows[lc_cont]["relacion"] + Strings.Chr(13);
                //            if (lc_cont + 1 == 10)
                //            {
                //                break; 
                //            }
                //        }
                //    }
                //}
                if (xnomcampo.Length > 0)
                {
                    if (!(MessageBox.Show("DESCRIPCION ANTERIOR :" + VM_DESCRIPCION + " SE USA EN " + "\r" + xnomcampo + "\r" + "DESEA REEMPLAZAR DESCRIPCION ...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                    {
                        return false;
                    }
                }
            }
            if (xmsg.Trim().Length > 0)
            {
                MessageBox.Show(xmsg.Trim(), "Error en Ingreso de Datos");
                if ((objeto != null))
                {
                    objeto = Focus();
                }
            }
            return xmsg.Trim().Length == 0;
        }

        private void Frm_Planilla_GenEventosPermiso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 & btnnuevo.Enabled)
            {
                btnnuevo_Click(sender, e);
            }
            if (e.KeyCode == Keys.F3 & btnmod.Enabled)
            {
                btnmod_Click(sender, e);
            }
            if (e.KeyCode == Keys.G & e.Control & btngrabar.Enabled)
            {
                btngrabar_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (btncancelar.Enabled)
                {
                    btncancelar_Click(sender, e);
                }
                else
                {
                    btncerrar_Click(sender, e);
                }
            }
            if (e.KeyCode == Keys.F8 & btneliminar.Enabled)
            {
                btneliminar_Click(sender, e);
            }
            if (e.KeyCode == Keys.F5 & btnload.Enabled)
            {
                btnload_Click(sender, e);
            }
            if (e.KeyCode == Keys.F4 & Examinar.Enabled)
            {
                TabControl1.SelectedIndex = 0;
                Examinar.Focus();
                Examinar.BeginEdit(true);
            }
        }

        private void btnlog_Click(object sender, EventArgs e)
        {
            if (Examinar.CurrentRow != null)
            {
                FrmSeguridad oform = new FrmSeguridad();
                oform._Nombre = Name;
                oform._ClaveForm = VariablesPublicas.EmpresaID + Examinar.Rows[Examinar.CurrentRow.Index].Cells["eventoperid"].Value.ToString();
                oform.Owner = this;
                oform.ShowDialog();
            }
        }

        private void TabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (u_n_opsel > 0)
            {
                if (TabControl1.Controls[e.TabPageIndex].Name.ToUpper() == "TABPAGE1")
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnfiltro_Click(object sender, EventArgs e)
        {
            CargaDatos();
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            // Si el control tiene el foco...
            if (keyData == Keys.Enter)
            {
                if ((Examinar.CurrentCell != null))
                {
                    SendKeys.Send("\t");
                    return true;
                }
                else
                {
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void u_PintaDatos()
        {
            if (!Sw_LOad)
            {
                if (TabControl1.SelectedIndex == 1)
                {
                    if ((Examinar.CurrentRow != null) & !(u_n_opsel == 1))
                    {
                        txtdescripcion.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["eventopername"].Value.ToString();
                        txtcodigo.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["eventoperid"].Value.ToString();
                        chkactivo.Checked = Convert.ToInt16(Examinar.Rows[Examinar.CurrentRow.Index].Cells["status"].Value) == 1;
                        cmbtipo.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipoevento"].Value;
                        cmbcodsunat.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["rtpssunat"].Value;
                    }
                }
            }
        }

        private void btnprimero_Click(object sender, EventArgs e)
        {
            u_Roleo(GlobalVars.GetInstance().TOPRECORD);
        }
        private void btnanterior_Click(object sender, EventArgs e)
        {
            u_Roleo(GlobalVars.GetInstance().PREVRECORD);
        }
        private void btnsiguiente_Click(object sender, EventArgs e)
        {
            u_Roleo(GlobalVars.GetInstance().NEXTRECORD);
        }
        private void btnultimo_Click(object sender, EventArgs e)
        {
            u_Roleo(GlobalVars.GetInstance().BOTTRECORD);
        }
        public void u_Roleo(string xtipo)
        {
            VariablesPublicas.RoleoGrid(Examinar, xtipo, "eventoperid");
            u_PintaDatos();
        }

        private void txtfiltronombre_GotFocus(object sender, System.EventArgs e)
        {
            j_xFiltronom = txtfiltronombre.Text;
        }
        private void txtfiltronombre_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_xFiltronom == txtfiltronombre.Text) & !Sw_LOad)
            {
                CargaDatos();
            }
        }

        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' & e.KeyChar <= '9')
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back | e.KeyChar == (char)Keys.Delete)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void txtcodigo_LostFocus(object sender, System.EventArgs e)
        {
            if (u_n_opsel > 0)
            {
                if (txtcodigo.Text.Trim().Length > 0)
                {
                    //txtcodigo.Text = VariablesPublicas.PADL(txtcodigo.Text.Trim(), txtcodigo.MaxLength, "0")
                }
            }
        }
        public void U_pINTAR()
        {
        }

        private void Examinar_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((Examinar.CurrentRow != null))
            {
                TabControl1.SelectedIndex = 1;
            }
        }

        private void Examinar_Paint(object sender, PaintEventArgs e)
        {
            U_pINTAR();
        }
    }
}
