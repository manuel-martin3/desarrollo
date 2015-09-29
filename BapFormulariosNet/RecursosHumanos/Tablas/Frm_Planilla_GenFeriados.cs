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
    public partial class Frm_Planilla_GenFeriados : plantilla
    {
        private DataTable tablaclientes;
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

        public Frm_Planilla_GenFeriados()
        {
            InitializeComponent();

            KeyDown += Frm_Planilla_GenFeriados_KeyDown;
            FormClosing += Frm_Planilla_GenFeriados_FormClosing;
            Load += Frm_Planilla_GenFeriados_Load;
            Activated += Frm_Planilla_GenFeriados_Activated;

            txtfiltronombre.LostFocus += new System.EventHandler(txtfiltronombre_LostFocus);
            txtfiltronombre.GotFocus += new System.EventHandler(txtfiltronombre_GotFocus);

            txtdias.LostFocus += new System.EventHandler(txtdias_LostFocus);
        }

        void llenar_cboMeses()
        {
            try
            {
                cmbmes.DataSource = NewMethodMeses();
                cmbmes.DisplayMember = "Value";
                cmbmes.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethodMeses()
        {
            tb_co_mesesBL BL = new tb_co_mesesBL();
            tb_co_meses BE = new tb_co_meses();

            BE.ntipo = 1;
            DataTable table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            DataRowCollection rows = table.Rows;

            object[] cell;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            BindingSource binding = new BindingSource();

            foreach (DataRow item in rows)
            {
                cell = item.ItemArray;
                dic.Add(cell[0].ToString(), cell[0].ToString() + " - " + cell[1].ToString());
                cell = null;
            }
            binding.DataSource = dic;
            return binding;
        }

        private void Frm_Planilla_GenFeriados_Activated(object sender, EventArgs e)
        {
            if (Sw_LOad)
            {
                //cmbperiodo.ValueMember = "periodo";
                //cmbperiodo.DisplayMember = "periodo";
                //cmbperiodo.DataSource = ocapa.Periodos_CONSULTA("");
                //cmbperiodo.SelectedValue = DateAndTime.Now.Year.ToString();
                spnperiodo.Value = DateTime.Now.Year;
                llenar_cboMeses();
                //cmbmes.ValueMember = "mes_cod";
                //cmbmes.DisplayMember = "mes_descripcion";
                //cmbmes.DataSource = ocapa.meses_consulta("", GlobalVars.GetInstance.MESESCALENDARIO);
                U_RefrescaControles();
                CargaDatos();
                U_RefrescaControles();
                Sw_LOad = false;
            }
        }
        private void Frm_Planilla_GenFeriados_Load(object sender, EventArgs e)
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
            //FormBorderStyle = FormBorderStyle.Fixed3D;
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
            string xperiodo = "";
            if (spnperiodo.Enabled)
            {
                //if ((spnperiodo.Value != null))
                //{
                    if ((!object.ReferenceEquals(spnperiodo.Value, DBNull.Value)))
                    {
                        xperiodo = spnperiodo.Value.ToString();
                    }
                //}
            }
            if (txtfiltronombre.Text.Trim().Length > 0)
            {
                xpalabra1 = VariablesPublicas.Palabras(txtfiltronombre.Text, 1);
                xpalabra2 = VariablesPublicas.Palabras(txtfiltronombre.Text, 2);
                xpalabra3 = VariablesPublicas.Palabras(txtfiltronombre.Text, 3);
            }
            if ((Examinar.CurrentRow != null))
            {
                xcodcliente = Examinar.Rows[Examinar.CurrentRow.Index].Cells["d_fecha"].Value.ToString();
            }
            if ((Examinar.SortedColumn != null))
            {
                nposcolumnasortear = Examinar.SortedColumn.Index;
                PrvSotOrder = Examinar.SortOrder;
                zordenado = true;
            }
            tb_plla_feriadosBL BL = new tb_plla_feriadosBL();
            tb_plla_feriados BE = new tb_plla_feriados();
            BE.perianio = xperiodo;
            BE.nomlike1 = xpalabra1;
            BE.nomlike2 = xpalabra2;
            BE.nomlike3 = xpalabra3;
            tablaclientes = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
            //tablaclientes = ocapa.CaeSoft_GetAllFeriados(xperiodo, "", "", xpalabra1, xpalabra2, xpalabra3);
            if (BL.Sql_Error.Length > 0)
            {
                Frm_Class.ShowError(BL.Sql_Error, this);
                return;
            }
            Examinar.AutoGenerateColumns = false;
            Examinar.DataSource = tablaclientes;
            //if (!(txtdescripcion.MaxLength == tablaclientes.Columns["descrip"].MaxLength))
            //{
            //    txtdescripcion.MaxLength = tablaclientes.Columns["descrip"].MaxLength;
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
                Examinar.Sort(Examinar.Columns["d_fecha"], System.ComponentModel.ListSortDirection.Ascending);
            }
            if (Examinar.CurrentRow == null)
            {
                if (Examinar.RowCount > 0)
                {
                    Examinar.CurrentCell = Examinar.Rows[0].Cells["d_fecha"];
                }
            }
            //if (Examinar.RowCount > 0)
            //{
            //    lbltotalregistros.Text = Examinar.RowCount.ToString + " Registro(s)";
            //}
            //else
            //{
            //    lbltotalregistros.Text = "";
            //}
            for (lc_cont = 0; lc_cont <= Examinar.Rows.Count - 1; lc_cont++)
            {
                if (Examinar.Rows[lc_cont].Cells["d_fecha"].Value.ToString() == xcodcliente)
                {
                    Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["descrip"];
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
            btncopiar.Enabled = u_n_opsel == 0;
            txtdias.Enabled = u_n_opsel == 1;
            txtdescripcion.Enabled = u_n_opsel > 0;
            cmbmes.Enabled = u_n_opsel == 1;
            btnload.Enabled = u_n_opsel == 0;
            btnprimero.Enabled = u_n_opsel == 0;
            btnultimo.Enabled = u_n_opsel == 0;
            btnsiguiente.Enabled = u_n_opsel == 0;
            btnanterior.Enabled = u_n_opsel == 0;

            string xcodcliente = "";
            if ((Examinar.CurrentRow != null))
            {
                xcodcliente = Examinar.Rows[Examinar.CurrentCell.RowIndex].Cells["d_fecha"].Value.ToString();
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
            cmbmes.SelectedValue = VariablesPublicas.PADL(DateTime.Now.Month.ToString(), 2, "0");
            txtdias.Text = "";
            txtdescripcion.Focus();
        }

        private void Blanquear()
        {
            txtdias.Text = "";
            txtdescripcion.Text = "";
            cmbmes.SelectedValue = "";
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
                string xtmpuser = spnperiodo.Value.ToString() + cmbmes.SelectedValue + txtdias.Text;
                u_n_opsel = 0;
                TabControl1.SelectedIndex = 0;
                U_RefrescaControles();
                CargaDatos();
                if (Examinar.RowCount > 0)
                {
                    for (lc_cont = 0; lc_cont <= Examinar.Rows.Count - 1; lc_cont++)
                    {
                        if (Examinar.Rows[lc_cont].Cells["d_fecha"].Value.ToString() == xtmpuser)
                        {
                            Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["descrip"];
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
                tb_plla_feriadosBL BL = new tb_plla_feriadosBL();
                tb_plla_feriados BE = new tb_plla_feriados();
                BE.perianio = spnperiodo.Value.ToString();
                BE.perimes = cmbmes.SelectedValue.ToString();
                BE.peridia = txtdias.Text.Trim();
                tmpcursor = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                //tmpcursor = ocapa.CaeSoft_GetAllFeriados(cmbperiodo.SelectedValue, cmbmes.SelectedValue, txtdias.Text, "", "", "");
                if (tmpcursor.Rows.Count == 0)
                {
                    tmpcursor.Rows.Add(VariablesPublicas.InsertIntoTable(tmpcursor));
                }
                tmpcursor.Rows[0]["perianio"] = spnperiodo.Value;
                tmpcursor.Rows[0]["perimes"] = cmbmes.SelectedValue;
                tmpcursor.Rows[0]["peridia"] = txtdias.Text.Trim();                
                tmpcursor.Rows[0]["descrip"] = txtdescripcion.Text.Trim();
                tmpcursor.AcceptChanges();
                if (BL.Insert_Update(VariablesPublicas.EmpresaID, BE, tmpcursor))
                {
                    seguridadlog();
                    //SeguridadLogic.InsertUpdateVariables(Name, cmbperiodo.SelectedValue + cmbmes.SelectedValue + txtdias.Text, "Descripción:" + txtdescripcion.Text, GlobalVars.GetInstance.UserID, "M", UtilitariosInterface.InformacionPC());
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
            string xclave = VariablesPublicas.EmpresaID + spnperiodo.Value.ToString() + cmbmes.SelectedValue + txtdias.Text;
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
                BE.detalle = "Descripción: " + txtdescripcion.Text;

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

                if (xnomcampo.Length == 0)
                {
                    tb_plla_feriadosBL BL = new tb_plla_feriadosBL();
                    tb_plla_feriados BE = new tb_plla_feriados();
                    BE.perianio = Examinar.Rows[Examinar.CurrentRow.Index].Cells["perianio"].Value.ToString();
                    BE.perimes = Examinar.Rows[Examinar.CurrentRow.Index].Cells["perimes"].Value.ToString();
                    BE.peridia = Examinar.Rows[Examinar.CurrentRow.Index].Cells["peridia"].Value.ToString();
                    tmptabla = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
                    //tmptabla = ocapa.CaeSoft_GetAllFeriados(Examinar.Rows(Examinar.CurrentRow.Index).Cells("perianio").Value, Examinar.Rows(Examinar.CurrentRow.Index).Cells("MES").Value, Examinar.Rows(Examinar.CurrentRow.Index).Cells("peridia").Value, "", "", "");
                    if (BL.Sql_Error.Length == 0)
                    {
                        string message = "Desea eliminar datos  " + tmptabla.Rows[0]["perianio"].ToString().Trim() + "/" + tmptabla.Rows[0]["mesdia"].ToString().Trim() + "-" + tmptabla.Rows[0]["descrip"].ToString().Trim() + " ...?";
                        string caption = "Mensaje del Sistema";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;
                        // Muestra el cuadro de mensaje.
                        result = MessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                        //if (Interaction.MsgBox("Desea eliminar datos " + tmptabla.Rows[0]["perianio"].ToString().Trim() + "/" + tmptabla.Rows[0]["MESDIA"].ToString().Trim() + "-" + tmptabla.Rows[0]["descrip"].ToString().Trim(), 4 + 32 + 256, "") == 6)
                        //{
                            BL.Eliminar(VariablesPublicas.EmpresaID, tmptabla);
                            if (BL.Sql_Error.Length == 0)
                            {
                                tb_co_seguridadlogBL BLL = new tb_co_seguridadlogBL();
                                tb_co_seguridadlog BEL = new tb_co_seguridadlog();

                                BEL.moduloid = Name;
                                BEL.clave = VariablesPublicas.EmpresaID + Examinar.Rows[Examinar.CurrentRow.Index].Cells["perianio"].Value.ToString() + Examinar.Rows[Examinar.CurrentRow.Index].Cells["perimes"].Value.ToString() + Examinar.Rows[Examinar.CurrentRow.Index].Cells["peridia"].Value.ToString();
                                BEL.cuser = VariablesPublicas.Usuar;
                                BEL.fecha = DateTime.Now;
                                BEL.pc = VariablesPublicas.userip;
                                BEL.accion = "B";
                                BEL.detalle = "Descripción: " + txtdescripcion.Text;
                                BLL.Insert(VariablesPublicas.EmpresaID.ToString(), BEL);
                                //SeguridadLogic.InsertUpdateVariables(Name, cmbperiodo.SelectedValue + cmbmes.SelectedValue + txtdias.Text, "Descripción:" + txtdescripcion.Text, GlobalVars.GetInstance.UserID, "b", UtilitariosInterface.InformacionPC());
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

        private void Frm_Planilla_GenFeriados_FormClosing(object sender, FormClosingEventArgs e)
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
            string xcoddd = "";
            if (txtdescripcion.Text.Trim().Length == 0)
            {
                xmsg = "Ingrese Descripción";
                objeto = txtdescripcion;
            }
            if (txtdias.Text.Trim().Length == 0)
            {
                xmsg = xmsg + '\r' + "Ingrese Día";
                objeto = txtdias;
            }
            if ((cmbmes.SelectedValue != null))
            {
                if ((!object.ReferenceEquals(cmbmes.SelectedValue, DBNull.Value)))
                {
                    xcoddd = cmbmes.SelectedValue.ToString();
                }
            }
            if (xcoddd.Trim().Length == 0)
            {
                xmsg = xmsg + '\r' + "Ingrese Mes";
                objeto = cmbmes;
            }
            //string xvarrr = "";
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

        private void Frm_Planilla_GenFeriados_KeyDown(object sender, KeyEventArgs e)
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
                oform._ClaveForm = Examinar.Rows[Examinar.CurrentRow.Index].Cells["perianio"].Value.ToString() + Examinar.Rows[Examinar.CurrentRow.Index].Cells["perimes"].Value + Examinar.Rows[Examinar.CurrentRow.Index].Cells["peridia"].Value;
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
            //string xcodcliente = "";
            //decimal npos = -1;
            if (!Sw_LOad)
            {
                if (TabControl1.SelectedIndex == 1)
                {
                    if ((Examinar.CurrentRow != null) & !(u_n_opsel == 1))
                    {
                        txtdescripcion.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["descrip"].Value.ToString();
                        txtdias.Text = Examinar.Rows[Examinar.CurrentRow.Index].Cells["peridia"].Value.ToString();
                        cmbmes.SelectedValue = Examinar.Rows[Examinar.CurrentRow.Index].Cells["perimes"].Value;
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
            VariablesPublicas.RoleoGrid(Examinar, xtipo, "d_fecha");
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

        private void txtdias_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtdias_LostFocus(object sender, System.EventArgs e)
        {
            if (u_n_opsel > 0)
            {
                if (txtdias.Text.Trim().Length > 0)
                {
                    txtdias.Text = VariablesPublicas.PADL(txtdias.Text.Trim(), txtdias.MaxLength, "0");
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

        private void btncopiar_Click(object sender, EventArgs e)
        {
            Frm_Planilla_GenFeriados_Copiar oform = new Frm_Planilla_GenFeriados_Copiar();
            oform.Owner = this;
            oform._LpDelegado = Procesa;
            oform.ShowDialog();
        }
        public void Procesa(bool sw)
        {
            if (sw)
            {
                CargaDatos();
                u_PintaDatos();
            }
        }

        private void spnperiodo_ValueChanged(object sender, EventArgs e)
        {
            if (!sw_EmpiezaEdicion)
            {
                CargaDatos();
            }
        }
    }
}
