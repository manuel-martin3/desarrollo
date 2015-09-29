﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using BapFormulariosNet.Codigo;

namespace BapFormulariosNet.RecursosHumanos.Configuraciones
{
    public partial class Frm_PorcentAFP : plantilla
    {
        private DataTable Tabla;
        private bool Sw_LOad = true;
        private int u_n_opsel = 0;
        private DataTable tmpcursor = new DataTable();
        private int lc_cont;

        public Frm_PorcentAFP()
        {
            InitializeComponent();

            KeyDown += Frm_PorcentAFP_KeyDown;
            FormClosing += Frm_PorcentAFP_FormClosing;
            Load += Frm_PorcentAFP_Load;
            Activated += Frm_PorcentAFP_Activated;
        }

        private void Frm_PorcentAFP_Activated(object sender, EventArgs e)
        {
            if (Sw_LOad)
            {
                spnperiodo.Value = Convert.ToInt16(VariablesPublicas.perianio);
                u_CargaCombos();
                CargaDatos();
                Sw_LOad = false;
                if (Examinar.RowCount > 0)
                {
                    Examinar.Focus();
                    Examinar.BeginEdit(true);
                }
                U_RefrescaControles();
                Sw_LOad = false;
            }
        }
        private void Frm_PorcentAFP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (btnmod.Enabled)
                {
                    Accion(2);
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
        private void Frm_PorcentAFP_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            WindowState = FormWindowState.Normal;

            for (lc_cont = 0; lc_cont <= Examinar.Columns.Count - 1; lc_cont++)
            {
                Examinar.Columns[lc_cont].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        private void CargaDatos()
        {
            var xcodafp = "...";
            var sorted = default(SortOrder);
            var xnomcolumna = string.Empty;
            if (cboAfp.SelectedValue != null)
            {
                xcodafp = cboAfp.SelectedValue.ToString();
            }

            if (Examinar.SortedColumn != null)
            {
                xnomcolumna = Examinar.Columns[Examinar.SortedColumn.Index].Name;
                sorted = Examinar.SortOrder;
            }
            var BL = new tb_plla_porcentafpBL();
            var BE = new tb_plla_porcentafp();

            BE.perianio = spnperiodo.Value.ToString();
            BE.regipenid = xcodafp;
            Tabla = BL.GetAll_Consulta(VariablesPublicas.EmpresaID, BE).Tables[0];
            if (BL.Sql_Error.Length > 0)
            {
                Frm_Class.ShowError(BL.Sql_Error, this);
            }
            Examinar.AutoGenerateColumns = false;
            Examinar.DataSource = Tabla;
        }

        private void U_RefrescaControles()
        {
            btngrabar.Enabled = u_n_opsel > 0;
            btnmod.Enabled = u_n_opsel == 0;
            btncancelar.Enabled = u_n_opsel > 0;
            btncerrar.Enabled = u_n_opsel == 0;
            btnload.Enabled = u_n_opsel == 0;
            spnperiodo.Enabled = u_n_opsel == 0;
            spnperiodo.ReadOnly = false;
            cboAfp.Enabled = u_n_opsel == 0;
            Examinar.Enabled = true;
            Examinar.ReadOnly = u_n_opsel == 0;
            Examinar.Columns["mesname"].ReadOnly = true;
            var zeof = true;
            if (Examinar.DataSource != null)
            {
                if (Examinar.RowCount > 0)
                {
                    zeof = false;
                }
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            U_CancelarEdicion(1);
        }

        private void U_CancelarEdicion(int SwConfirmacion)
        {
            u_CargaCombos();
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
                        xtmpuser = Examinar.Rows[filaactual].Cells["perimes"].Value.ToString();
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
                        if (Examinar.Rows[lc_cont].Cells["perimes"].Value.ToString() == xtmpuser)
                        {
                            Examinar.CurrentCell = Examinar.Rows[lc_cont].Cells["mesname"];
                            break;
                        }
                    }
                }
            }
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

        private void Frm_PorcentAFP_FormClosing(object sender, FormClosingEventArgs e)
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

        private bool u_Validate()
        {
            var xmsg = string.Empty;
            var xobjeto = new object();
            if (!(xmsg.Trim().Length == 0))
            {
                MessageBox.Show(xmsg, "VALIDACION");
                if (xobjeto != null)
                {
                    xobjeto = Focus();
                }
            }
            return xmsg.Trim().Length == 0;
        }

        private void Examinar_SelectionChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad & u_n_opsel == 0)
            {
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

        private void Accion(int naccion)
        {
            switch (naccion)
            {
                case 1:
                    u_n_opsel = 1;
                    U_RefrescaControles();
                    if (Examinar.CurrentRow != null)
                    {
                        Examinar.CurrentRow.Selected = false;
                    }

                    break;
                case 2:
                    u_n_opsel = 2;
                    U_RefrescaControles();
                    Examinar.CurrentRow.Selected = true;
                    break;
                case 3:
                    break;
            }
        }
        private void save()
        {
            if (u_Validate())
            {
                if (Examinar.IsCurrentCellInEditMode)
                {
                    Examinar.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                Tabla.AcceptChanges();
                for (lc_cont = 0; lc_cont <= Tabla.Rows.Count - 1; lc_cont++)
                {
                    Tabla.Rows[lc_cont]["regipenid"] = cboAfp.SelectedValue;
                }
                Tabla.AcceptChanges();

                var BL = new tb_plla_porcentafpBL();
                var BE = new tb_plla_porcentafp();

                BE.regipenid = cboAfp.SelectedValue.ToString();
                BE.perianio = spnperiodo.Value.ToString();
                if (BL.BapSoft_PorcentajesAFPInsert(VariablesPublicas.EmpresaID, BE, Tabla))
                {
                    U_CancelarEdicion(0);
                }
                else
                {
                    Frm_Class.ShowError(BL.Sql_Error, this);
                }
            }
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnmod_Click(object sender, EventArgs e)
        {
            Accion(2);
        }

        private void spnperiodo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("\t");
                U_CancelarEdicion(0);
            }
        }

        private void spnperiodo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
            }
        }

        private void spnperiodo_ValueChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad)
            {
                U_CancelarEdicion(0);
            }
        }

        public void u_CargaCombos()
        {
            object xvalor = null;
            xvalor = null;
            Sw_LOad = true;
            xvalor = null;
            if (cboAfp.SelectedValue != null)
            {
                xvalor = cboAfp.SelectedValue;
            }
            Llenar_Afps();
            if (xvalor != null)
            {
                cboAfp.SelectedValue = xvalor;
            }
            Sw_LOad = false;
        }

        public void Llenar_Afps()
        {
            try
            {
                cboAfp.DataSource = NewMethodoAfp();
                cboAfp.DisplayMember = "Value";
                cboAfp.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethodoAfp()
        {
            var BL = new tb_plla_pdt_tabla11BL();
            var BE = new tb_plla_pdt_tabla11();

            BE.status = "A";
            var table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            var rows = table.Rows;

            object[] cell;
            var dic = new Dictionary<string, string>();
            var binding = new BindingSource();

            foreach (DataRow item in rows)
            {
                cell = item.ItemArray;
                dic.Add(cell[0].ToString(), cell[0].ToString() + " - " + cell[1].ToString());
                cell = null;
            }
            binding.DataSource = dic;
            return binding;
        }

        private void cmbafp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad)
            {
                U_CancelarEdicion(0);
            }
        }
    }
}