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
    public partial class Frm_Planilla_Cargos : plantilla
    {
        private DataTable tablaclientes;
        DataTable tmpcursor;
        bool sw_EmpiezaEdicion = false;
        private DataTable tmptabla;
        private bool Sw_LOad = true;
        string j_Cargo = "";
        string j_xFiltronom = "";
        private int u_n_opsel = 0;
        int lc_cont;

        public Frm_Planilla_Cargos()
        {
            InitializeComponent();

            KeyDown += Frm_Planilla_Cargos_KeyDown;
            FormClosing += Frm_Planilla_Cargos_FormClosing;
            Load += Frm_Planilla_Cargos_Load;
            Activated += Frm_Planilla_Cargos_Activated;

            txtfiltronombre.GotFocus += new System.EventHandler(txtfiltronombre_GotFocus);
            txtfiltronombre.LostFocus += new System.EventHandler(txtfiltronombre_LostFocus);

            txtcodigo.LostFocus += new System.EventHandler(txtcodigo_LostFocus);

            txtcodrtps.GotFocus += new System.EventHandler(txtcodrtps_GotFocus);
            txtcodrtps.LostFocus += new System.EventHandler(txtcodrtps_LostFocus);
        }

        public void Llenar_Ccosto()
        {
            centrocostoBL BL = new centrocostoBL();
            tb_centrocosto BE = new tb_centrocosto();
            BE.norden = 1;
            BE.ver_blanco = 0;
            cmbccosto.ValueMember = "cencosid";
            cmbccosto.DisplayMember = "descripcion";
            cmbccosto.DataSource = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
        }

        private void Frm_Planilla_Cargos_Activated(object sender, EventArgs e)
        {
            if (Sw_LOad)
            {
                Llenar_Ccosto();
                cmbfiltroccosto.ValueMember = "cencosid";
                cmbfiltroccosto.DisplayMember = "descripcion";
                centrocostoBL BL = new centrocostoBL();
                tb_centrocosto BE = new tb_centrocosto();
                BE.norden = 1;
                BE.ver_blanco = 0;
                tmpcursor = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
                cmbfiltroccosto.SelectedValue = "";

                if (BL.Sql_Error.Length == 0)
                {
                    cmbfiltroccosto.DataSource = tmpcursor;
                    if (tmpcursor.Rows.Count > 0)
                    {
                        cmbfiltroccosto.SelectedValue = tmpcursor.Rows[0]["cencosid"];
                    }
                }
                U_RefrescaControles();
                CargaDatos();
                U_RefrescaControles();
                Sw_LOad = false;
            }
        }
        private void Frm_Planilla_Cargos_Load(object sender, EventArgs e)
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
            MaximizeBox = false;
            WindowState = FormWindowState.Normal;
            //CenterToScreen();
        }

        private void CargaDatos()
        {
            string xtipoplanilla = "";
            if (cmbfiltroccosto.Enabled)
            {
                if ((cmbfiltroccosto.SelectedValue != null))
                {
                    xtipoplanilla = cmbfiltroccosto.SelectedValue.ToString();
                }
            }
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
                xcodcliente = Examinar.Rows[Examinar.CurrentRow.Index].Cells["cargoid"].Value.ToString();
            }
            if ((Examinar.SortedColumn != null))
            {
                nposcolumnasortear = Examinar.SortedColumn.Index;
                PrvSotOrder = Examinar.SortOrder;
                zordenado = true;
            }
            tb_plla_cargosBL BL = new tb_plla_cargosBL();
            tb_plla_cargos BE = new tb_plla_cargos();
            BE.cencosid = xtipoplanilla;
            BE.nomlike1 = xpalabra1;
            BE.nomlike2 = xpalabra2;
            BE.nomlike3 = xpalabra3;
            BE.norden = 0;
            BE.ver_blanco = 0;
            tablaclientes = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
            Examinar.AutoGenerateColumns = false;
            Examinar.DataSource = tablaclientes;
            if (BL.Sql_Error.Length == 0)
            {
                //if (!(txtdescripcion.MaxLength == tablaclientes.Columns["cargoname"].MaxLength))
                //{
                //    txtdescripcion.MaxLength = tablaclientes.Columns["cargoname"].MaxLength;
                //    txtcodigo.MaxLength = tablaclientes.Columns["cargoid"].MaxLength;
                //}
            }
            else
            {
                Frm_Class.ShowError(BL.Sql_Error, this);
            }

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
                Examinar.Sort(Examinar.Columns["cargoid"], System.ComponentModel.ListSortDirection.Ascending);
            }
            if (Examinar.CurrentRow == null)
            {
                if (Examinar.RowCount > 0)
                {
                    Examinar.CurrentCell = Examinar.Rows[0].Cells["cargoid"];
                }
            }
            for (lc_cont = 0; lc_cont <= Examinar.Rows.Count - 1; lc_cont++)
            {
                if (Examinar.Rows[lc_cont].Cells["cargoid"].Value.ToString() == xcodcliente)
                {
                    Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["cargoid"];
                    break; 
                }
            }
            U_RefrescaControles();
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            u_PintaDatos();
        }

        private void U_RefrescaControles()
        {
            cmbfiltroccosto.Enabled = chkccosto.Checked & u_n_opsel == 0;
            txtcodigo.Enabled = u_n_opsel == 1;

            txtdescripcion.Enabled = u_n_opsel > 0;
            chkactivo.Enabled = u_n_opsel > 0;
            rbdirecto.Enabled = u_n_opsel > 0;
            rbindirecto.Enabled = u_n_opsel > 0;
            //cmbccosto.Enabled = u_n_opsel > 0;
            cmbccosto.Enabled = u_n_opsel == 1;

            txtdrtps.Enabled = false;
            txtcodrtps.Enabled = u_n_opsel > 0;

            btnload.Enabled = u_n_opsel == 0;
            btnprimero.Enabled = u_n_opsel == 0;
            btnultimo.Enabled = u_n_opsel == 0;
            btnsiguiente.Enabled = u_n_opsel == 0;
            btnanterior.Enabled = u_n_opsel == 0;

            string xcodcliente = "";
            if ((Examinar.CurrentRow != null))
            {
                xcodcliente = Examinar.Rows[Examinar.CurrentCell.RowIndex].Cells["cargoid"].Value.ToString();
            }

            btnnuevo.Enabled = u_n_opsel == 0;
            btngrabar.Enabled = u_n_opsel > 0;
            btnmod.Enabled = u_n_opsel == 0 & xcodcliente.Length > 0;
            btneliminar.Enabled = u_n_opsel == 0 & xcodcliente.Length > 0;
            btncancelar.Enabled = u_n_opsel > 0;
            btncerrar.Enabled = u_n_opsel == 0;
            barramain.Enabled = true;
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
            string xcodcosto = "";
            if (chkccosto.Checked)
            {
                if ((cmbfiltroccosto.SelectedValue != null))
                {
                    xcodcosto = cmbfiltroccosto.SelectedValue.ToString();
                    cmbccosto.SelectedValue = cmbfiltroccosto.SelectedValue;
                }
            }
            else
            {
                if ((cmbccosto.SelectedValue != null))
                {
                    xcodcosto = cmbccosto.SelectedValue.ToString();
                }
            }
            if (xcodcosto.Trim().Length > 0)
            {
                tb_plla_cargosBL BL = new tb_plla_cargosBL();
                tb_plla_cargos BE = new tb_plla_cargos();
                BE.cencosid = xcodcosto;
                txtcodigo.Text = BL.GetAll_MaxCodigo(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0].Rows[0]["maximo_codigo"].ToString();
            }
            else
            {
                cmbccosto.SelectedValue = "";
                txtcodigo.Text = "";
            }
            chkactivo.Checked = true;
            rbdirecto.Checked = true;
            txtdescripcion.Focus();
        }

        private void Blanquear()
        {
            txtcodrtps.Text = "";
            txtdrtps.Text = "";
            txtcodigo.Text = "";
            txtdescripcion.Text = "";
            chkactivo.Checked = false;
            rbdirecto.Checked = false;
            rbindirecto.Checked = false;
            txtdrtps.Text = "";
            txtcodrtps.Text = "";
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
                        if (Examinar.Rows[lc_cont].Cells["cargoid"].Value.ToString() == xtmpuser)
                        {
                            Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["cargoid"];
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
            txtdescripcion.Focus();
        }

        private void btngrabar_Click(object sender, EventArgs e)
        {
            if (U_Validacion())
            {
                DataTable tmpcursor = new DataTable();
                tb_plla_cargosBL BL = new tb_plla_cargosBL();
                tb_plla_cargos BE = new tb_plla_cargos();
                BE.cencosid = cmbccosto.SelectedValue.ToString();
                BE.cargoid = txtcodigo.Text.Trim();
                BE.norden = 0;
                BE.ver_blanco = 0;
                tmpcursor = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];

                if (u_n_opsel == 1)
                {
                    tmpcursor = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];

                    if (tmpcursor.Rows.Count > 0)
                    {
                        tb_plla_cargosBL BLMX = new tb_plla_cargosBL();
                        tb_plla_cargos BEMX = new tb_plla_cargos();
                        BEMX.cencosid = cmbccosto.SelectedValue.ToString();
                        txtcodigo.Text = BLMX.GetAll_MaxCodigo(VariablesPublicas.EmpresaID.ToString(), BEMX).Tables[0].Rows[0]["maximo_codigo"].ToString();
                    }
                    tmpcursor.Rows.Add(VariablesPublicas.InsertIntoTable(tmpcursor));
                    tmpcursor.Rows[0]["cargoid"] = txtcodigo.Text;
                    tmpcursor.Rows[0]["status"] = 1;
                }
                tmpcursor.Rows[0]["cargoname"] = txtdescripcion.Text;
                tmpcursor.Rows[0]["status"] = (chkactivo.Checked ? 1 : 0);
                tmpcursor.Rows[0]["cencosid"] = cmbccosto.SelectedValue;
                tmpcursor.Rows[0]["ocupaid"] = txtcodrtps.Text;
                tmpcursor.Rows[0]["tipogasto"] = (rbdirecto.Checked ? '1' : '2');
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
            string xclave = VariablesPublicas.EmpresaID + cmbccosto.SelectedValue + txtcodigo.Text.Trim();
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
                BE.detalle = "Cargo: " + txtdescripcion.Text.Trim();

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
                string xnomcampo = "";
                tb_plla_cargosBL BL = new tb_plla_cargosBL();
                tb_plla_cargos BE = new tb_plla_cargos();
                BE.cencosid = Examinar.Rows[Examinar.CurrentRow.Index].Cells["cencosid"].Value.ToString();
                BE.cargoid = Examinar.Rows[Examinar.CurrentRow.Index].Cells["cargoid"].Value.ToString();
                //tmpcursor = BL.GetAll_CONSULTAIR(VariablesPublicas.EmpresaID, BE).Tables[0];
                ////tmpcursor = ocapa.IR_PAG2100(GlobalVars.GetInstance.Company, Examinar.Rows(Examinar.CurrentRow.Index).Cells("ccos_21").Value, Examinar.Rows(Examinar.CurrentRow.Index).Cells("cargoid").Value);
                //if (BL.Sql_Error.Length > 0)
                //{
                //    xnomcampo = BL.Sql_Error;
                //    Frm_Class.ShowError(BL.Sql_Error, this);
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
                //            xnomcampo = xnomcampo + tmpcursor.Rows[lc_cont]["relacion"] + "\r";
                //            if (lc_cont + 1 == 10)
                //            {
                //                break;
                //            }
                //        }
                //    }
                //}
                if (xnomcampo.Length == 0)
                {
                    tb_plla_cargosBL BLEL = new tb_plla_cargosBL();
                    tb_plla_cargos BEEL = new tb_plla_cargos();
                    BEEL.cencosid = Examinar.Rows[Examinar.CurrentRow.Index].Cells["cencosid"].Value.ToString();
                    BEEL.cargoid = Examinar.Rows[Examinar.CurrentRow.Index].Cells["cargoid"].Value.ToString();
                    BEEL.norden = 1;
                    BEEL.ver_blanco = 0;
                    tmptabla = BLEL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BEEL).Tables[0];
                    if (BLEL.Sql_Error.Length == 0)
                    {
                        string message = "Desea eliminar datos del cargo  " + tmptabla.Rows[0]["cargoid"].ToString().Trim() + "-" + tmptabla.Rows[0]["cargoname"].ToString().Trim() + " ...?";
                        string caption = "Mensaje del Sistema";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;
                        // Muestra el cuadro de mensaje.
                        result = MessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                            BLEL.Eliminar(VariablesPublicas.EmpresaID, tmptabla);
                            if (BLEL.Sql_Error.Length == 0)
                            {
                                tb_co_seguridadlogBL BLL = new tb_co_seguridadlogBL();
                                tb_co_seguridadlog BEL = new tb_co_seguridadlog();

                                BEL.moduloid = Name;
                                BEL.clave = VariablesPublicas.EmpresaID + Examinar.Rows[Examinar.CurrentRow.Index].Cells["cencosid"].Value.ToString() + Examinar.Rows[Examinar.CurrentRow.Index].Cells["cargoid"].Value.ToString();
                                BEL.cuser = VariablesPublicas.Usuar;
                                BEL.fecha = DateTime.Now;
                                BEL.pc = VariablesPublicas.userip;
                                BEL.accion = "B";
                                BEL.detalle = "Cargo: " + txtdescripcion.Text.Trim();
                                BLL.Insert(VariablesPublicas.EmpresaID.ToString(), BEL);

                                Examinar.Rows.Remove(Examinar.CurrentRow);
                                Examinar.Refresh();
                                u_PintaDatos();
                            }
                            else
                            {
                                Frm_Class.ShowError(BLEL.Sql_Error, this);
                            }
                        }
                    }
                    else
                    {
                        Frm_Class.ShowError(BLEL.Sql_Error, this);
                    }
                }
                else
                {
                    MessageBox.Show(xnomcampo, "IMPOSIBLE ELIMINAR REGISTRO");
                }
            }
            U_RefrescaControles();
        }

        private void Frm_Planilla_Cargos_FormClosing(object sender, FormClosingEventArgs e)
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
            string xvarrr = "";
            if ((cmbccosto.SelectedValue != null))
            {
                if (cmbccosto.SelectedValue.ToString().Trim().Length > 0)
                {
                    xvarrr = cmbccosto.SelectedValue.ToString();
                }
            }
            if (xvarrr.Trim().Length == 0)
            {
                xmsg = "Ingrese Centro de Costo";
                objeto = cmbccosto;
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

        private void Frm_Planilla_Cargos_KeyDown(object sender, KeyEventArgs e)
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
            if ((Examinar.CurrentRow != null))
            {
                FrmSeguridad oform = new FrmSeguridad();
                oform._Nombre = Name;
                oform._ClaveForm = VariablesPublicas.EmpresaID + Examinar.Rows[Examinar.CurrentRow.Index].Cells["cencosid"].Value + Examinar.Rows[Examinar.CurrentRow.Index].Cells["cargoid"].Value;
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
                        txtdescripcion.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["cargoname"].Value.ToString();
                        chkactivo.Checked = Convert.ToBoolean(Examinar.Rows[Examinar.CurrentRow.Index].Cells["status"].Value);
                        rbdirecto.Checked = Convert.ToInt32(Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipogasto"].Value) == '1';
                        rbindirecto.Checked = Convert.ToInt32(Examinar.Rows[Examinar.CurrentRow.Index].Cells["tipogasto"].Value) == '2';
                        txtcodigo.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["cargoid"].Value.ToString();
                        cmbccosto.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["cencosid"].Value;
                        txtcodrtps.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["ocupaid"].Value.ToString();
                        txtdrtps.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["docupaidpdt"].Value.ToString();
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
            VariablesPublicas.RoleoGrid(Examinar, xtipo, "cargoid");
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
                    txtcodigo.Text = VariablesPublicas.PADL(txtcodigo.Text.Trim(), txtcodigo.MaxLength, "0");
                }
            }
        }
        
        public void U_pINTAR()
        {
            if (1 == 1)
            {
                int LC_NCOLUMNA = 0;
                for (lc_cont = 0; lc_cont <= Examinar.RowCount - 1; lc_cont++)
                {
                    if (Convert.ToBoolean(Examinar.Rows[lc_cont].Cells["status"].Value) == false)
                    {
                        for (LC_NCOLUMNA = 0; LC_NCOLUMNA <= Examinar.ColumnCount - 1; LC_NCOLUMNA++)
                        {
                            Examinar.Rows[lc_cont].DefaultCellStyle.BackColor = lblanulado.BackColor;
                            Examinar.Rows[lc_cont].DefaultCellStyle.ForeColor = lblanulado.ForeColor;
                        }
                    }
                    else
                    {
                        for (LC_NCOLUMNA = 0; LC_NCOLUMNA <= Examinar.ColumnCount - 1; LC_NCOLUMNA++)
                        {
                            Examinar.Rows[lc_cont].DefaultCellStyle.BackColor = Color.White;
                            Examinar.Rows[lc_cont].DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                }
            }
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

        private void cmbfiltroccosto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad)
            {
                CargaDatos();
            }
        }

        private void Examinar_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((Examinar.CurrentRow != null))
            {
                TabControl1.SelectedIndex = 1;
            }
        }

        private void chkccosto_CheckedChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad)
            {
                U_RefrescaControles();
                CargaDatos();
            }
        }

        private void cmbccosto_GotFocus(object sender, System.EventArgs e)
        {
            //if (!Sw_LOad & u_n_opsel > 0)
            //{
            //    RequeryCcosto();
            //}
        }

        private void cmbccosto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (u_n_opsel == 1)
            {
                u_GeneraNuevoCodigo();
            }
        }

        public void u_GeneraNuevoCodigo()
        {
            string xcodcosto = "";
            if ((cmbccosto.SelectedValue != null))
            {
                xcodcosto = cmbccosto.SelectedValue.ToString();
            }
            if (xcodcosto.Trim().Length == 0)
            {
                xcodcosto = "..:";
            }
            tb_plla_cargosBL BL = new tb_plla_cargosBL();
            tb_plla_cargos BE = new tb_plla_cargos();
            BE.cencosid = cmbccosto.SelectedValue.ToString();
            txtcodigo.Text = BL.GetAll_MaxCodigo(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0].Rows[0]["maximo_codigo"].ToString();
            //txtcodigo.Text = ocapa.UFC_MAXCODIGOPAG2100(GlobalVars.GetInstance.Company, xcodcosto);
        }
        public void AyudaccostoRPTS(string ocurrencias)
        {
            txtdrtps.Text = j_Cargo;
            Frm_AyudaPlla_CargosRtps oformayuda = new Frm_AyudaPlla_CargosRtps();
            oformayuda._PasaDelegado = DevuelveCodigo;
            oformayuda._Ocurrencias = ocurrencias;
            oformayuda.Owner = this;
            oformayuda.ShowDialog();

        }
        public void DevuelveCodigo(string codigo, string nombre)
        {
            if (codigo.Trim().Length > 0)
            {
                txtcodrtps.Text = codigo.Trim();
                txtdrtps.Text = nombre.Trim();
            }
        }

        private void txtcodrtps_GotFocus(object sender, System.EventArgs e)
        {
            j_Cargo = txtcodrtps.Text;
        }
        private void txtcodrtps_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_Cargo == txtcodrtps.Text) & u_n_opsel > 0)
            {
                if (txtcodrtps.Text.Trim().Length == 0)
                {
                    txtdrtps.Text = "";
                    txtcodrtps.Text = "";
                }
                else
                {
                    string xnomlike1 = VariablesPublicas.Palabras(txtdrtps.Text, 1);
                    string xnomlike2 = VariablesPublicas.Palabras(txtdrtps.Text, 2);
                    string xnomlike3 = VariablesPublicas.Palabras(txtdrtps.Text, 3);

                    tb_plla_pdt_tabla10BL BL = new tb_plla_pdt_tabla10BL();
                    tb_plla_pdt_tabla10 BE = new tb_plla_pdt_tabla10();
                    BE.ocupaid = txtcodrtps.Text.Trim();
                    //BE.nomlike1 = xnomlike1;
                    //BE.nomlike2 = xnomlike2;
                    //BE.nomlike3 = xnomlike3;
                    BE.norden = 1;
                    BE.ver_blanco = 0;
                    tmptabla = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
                    if (BL.Sql_Error.Length == 0)
                    {
                        if (tmptabla.Rows.Count == 0)
                        {
                            AyudaccostoRPTS("");
                        }
                        else
                        {
                            if (tmptabla.Rows.Count > 0)
                            {
                                txtcodrtps.Text = tmptabla.Rows[0]["ocupaid"].ToString().Trim();
                                txtdrtps.Text = tmptabla.Rows[0]["ocupaname"].ToString();
                            }
                            else
                            {
                                AyudaccostoRPTS(txtcodrtps.Text);
                            }
                        }
                    }
                }
            }
        }

        private void txtcodrtps_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaccostoRPTS("");
            }
            if (e.KeyCode == Keys.Enter)
            {
                j_Cargo = "doperiepo";
            }
        }
    }
}
