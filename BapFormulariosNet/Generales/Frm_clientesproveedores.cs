using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using System.IO;
using System.Net;

namespace BapFormulariosNet.Generales
{
    public partial class Frm_clientesproveedores : plantilla
    {
        private DatoSUNAT myInfoSunat = new DatoSUNAT();
        private DataTable tablaclientes = new DataTable();
        private string _NameColumn = string.Empty;
        private DataTable TablaAnexos = new DataTable();
        private DataTable TablaBancos = new DataTable();
        private TextBox txtCArti;
        private string j_CodUbigeo = string.Empty;
        private string j_CodBanco = string.Empty;
        private string j_xFiltronom = string.Empty;
        private bool sw_EmpiezaEdicion = false;
        private DataTable tmptabla = new DataTable();
        private bool Sw_LOad = true;
        private bool sw_novaluechange = false;
        private int u_n_opsel = 0;
        private int vmncont;
        private string j_String = string.Empty;
        private string j_Ruc = string.Empty;
        private int cdClave = 0;
        private string j_capcha = "";
        
        private Boolean procesado = false;
        private string ssModo = "";


        public Frm_clientesproveedores()
        {
            InitializeComponent();

            VariablesPublicas.toprecord = "top";
            VariablesPublicas.prevrecord = "skip-";
            VariablesPublicas.nextrecord = "skip+";
            VariablesPublicas.bottrecord = "bott";

            txtCadenaBuscar.LostFocus += new System.EventHandler(txtCadenaBuscar_LostFocus);
            txtCadenaBuscar.GotFocus += new System.EventHandler(txtCadenaBuscar_GotFocus);

            cboCriterioBusqueda.SelectedIndex = 0;
        }

        private void FilBancoID()
        {
            try
            {
                cboBancoID.DataSource = NewMethodoa();
                cboBancoID.DisplayMember = "Value";
                cboBancoID.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private BindingSource NewMethodoa()
        {
            var BL = new bancoBL();
            var BE = new tb_banco();

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

        private void FilResultDocident()
        {
            try
            {
                cboTipdoc.DataSource = NewMethodob();
                cboTipdoc.DisplayMember = "Value";
                cboTipdoc.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethodob()
        {
            var BL = new docuidentBL();
            var BE = new tb_docuident();

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

        private void FillResultDepar(ComboBox cboD, ComboBox cboP, ComboBox cboT)
        {
            var BL = new ubigeoBL();
            var BE = new tb_ubigeo();
            try
            {
                cboD.DataSource = BL.GetAll_depar(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                cboD.ValueMember = "ubige";
                cboD.DisplayMember = "depar";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FillResultProvi(ComboBox cboP, ComboBox cboT, string iddepart)
        {
            var BL = new ubigeoBL();
            var BE = new tb_ubigeo();
            BE.ubige = iddepart;
            try
            {
                cboP.DataSource = BL.GetAll_provi(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                cboP.ValueMember = "ubige";
                cboP.DisplayMember = "provi";

                if (cboP.Items.Count > 0)
                {
                    cboP.SelectedIndex = 0;
                    FillResultDistr(cboT, cboP.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FillResultDistr(ComboBox cboT, string idprovi)
        {
            var BL = new ubigeoBL();
            var BE = new tb_ubigeo();
            BE.ubige = idprovi;
            try
            {
                cboT.DataSource = BL.GetAll_distr(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                cboT.ValueMember = "ubige";
                cboT.DisplayMember = "Distr";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_ClientesProveedores_Activated(object sender, EventArgs e)
        {
            if (Sw_LOad)
            {
                FilResultDocident();
                FillResultDepar(cboDepar, cboProvi, cboDistr);
                FilBancoID();
                CargaDatos();
                U_RefrescaControles();
                var lc_cont = 0;
                for (lc_cont = 0; (lc_cont <= (GridExaminar.ColumnCount - 1)); lc_cont++)
                {
                    GridExaminar.Columns[lc_cont].SortMode = DataGridViewColumnSortMode.Automatic;
                }
                Sw_LOad = false;
            }
        }
        private void Frm_ClientesProveedores_Load(object sender, EventArgs e)
        {
            var arreglobotones = new object[] { btnnew, btnedit, btnsave, btnredo, btndelete, null, btnload, btnexit };
            VariablesPublicas.ConfiguraToolbar(arreglobotones);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            WindowState = FormWindowState.Normal;
            CenterToScreen();
        }
        private void Frm_ClientesProveedores_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F2) & btnnew.Enabled)
            {
                btnnew_Click(sender, e);
            }
            if ((e.KeyCode == Keys.F3) & btnedit.Enabled)
            {
                btnedit_Click(sender, e);
            }
            if ((e.KeyCode == Keys.G) & (e.Control & btnsave.Enabled))
            {
                btnsave_Click(sender, e);
            }
            if ((e.KeyCode == Keys.Escape))
            {
                if (btnredo.Enabled)
                {
                    btnredo_Click(sender, e);
                }
                else
                {
                    btnexit_Click(sender, e);
                }
            }
            if ((e.KeyCode == Keys.F8) & btndelete.Enabled)
            {
                btndelete_Click(sender, e);
            }
            if ((e.KeyCode == Keys.F5) & btnload.Enabled)
            {
                btnload_Click(sender, e);
            }
            if ((e.KeyCode == Keys.F4) & GridExaminar.Enabled)
            {
                TabControl1.SelectedIndex = 0;
                GridExaminar.Focus();
                GridExaminar.BeginEdit(true);
            }
            if ((e.KeyCode == Keys.Down) & (e.Control & (u_n_opsel > 0)))
            {
                if (btnDnuevo.Enabled)
                {
                    btnDnuevo_Click(sender, e);
                }
            }
            if ((e.KeyCode == Keys.Delete) & (e.Control & (u_n_opsel > 0)))
            {
                if (btnDanular.Enabled)
                {
                    btnDanular_Click(sender, e);
                }
            }
        }
        private void Frm_ClientesProveedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((u_n_opsel > 0))
            {
                MessageBox.Show("Finalice edición para cerrar formulario", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quieres cerrar el formulario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void CargaDatos()
        {
            var lc_cont = 0;
            var nposcolumnasortear = string.Empty;
            var PrvSotOrder = default(SortOrder);
            var zordenado = false;
            var xcodcliente = string.Empty;
            var xBuscar = string.Empty;
            if (GridExaminar.CurrentRow != null)
            {
                xcodcliente = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["ctacte"].Value.ToString();
            }
            if ( GridExaminar.SortedColumn != null )
            {
                nposcolumnasortear = GridExaminar.Columns[GridExaminar.SortedColumn.Index].Name;
                PrvSotOrder = GridExaminar.SortOrder;
                zordenado = true;
            }
            if (txtCadenaBuscar.Text.Trim().Length > 0)
            {
                xBuscar = txtCadenaBuscar.Text.Trim().ToUpper();
            }
            else
            {
                xBuscar = string.Empty;
            }
            try
            {
                var BL = new clienteBL();
                var BE = new tb_cliente();

                switch (cboCriterioBusqueda.SelectedItem.ToString())
                {
                    case "Razón Social":
                        BE.ctactename = xBuscar;
                        break;
                    case "Ruc":
                        BE.nmruc = xBuscar;
                        break;
                    case "Código":
                        BE.ctacte = xBuscar;
                        break;
                    default:
                        BE.ctactename = xBuscar;
                        break;
                }
                tablaclientes = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            GridExaminar.AutoGenerateColumns = false;
            GridExaminar.DataSource = tablaclientes;

            VariablesPublicas.PintaEncabezados(GridExaminar);
            if (zordenado)
            {
                if ( PrvSotOrder == SortOrder.Ascending )
                {
                    GridExaminar.Sort(GridExaminar.Columns[nposcolumnasortear], System.ComponentModel.ListSortDirection.Ascending);
                }
                else
                {
                    GridExaminar.Sort(GridExaminar.Columns[nposcolumnasortear], System.ComponentModel.ListSortDirection.Descending);
                }
            }
            else
            {
                GridExaminar.Sort(GridExaminar.Columns["ctacte"], System.ComponentModel.ListSortDirection.Ascending);
            }
            if ( GridExaminar.CurrentRow == null )
            {
                if ( GridExaminar.RowCount > 0 )
                {
                    GridExaminar.CurrentCell = GridExaminar.Rows[0].Cells["ctacte"];
                }
            }
            for (lc_cont = 0; lc_cont < GridExaminar.Rows.Count; lc_cont++)
            {
                if (GridExaminar.Rows[lc_cont].Cells["ctacte"].ToString() == xcodcliente)
                {
                    GridExaminar.CurrentCell = GridExaminar.Rows[lc_cont].Cells["ctacte"];
                    break;
                }
            }
        }

        private void Mostra_ubigeo(string opt, bool actv)
        {
            try
            {
                if (opt == "1")
                {
                    cboDepar.Visible = actv;
                    cboProvi.Visible = actv;
                    cboDistr.Visible = actv;
                }
                if (opt == "2")
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void U_RefrescaControles()
        {
            var xcodcliente = string.Empty;
            if ((GridExaminar.CurrentRow != null))
            {
                xcodcliente = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["ctacte"].Value.ToString();
            }
            txtcoddetalle.Enabled = false;
            txtnomdetalle.Enabled = false;

            gbtncliprov.Enabled = cdClave == 0;

            txtcodigo.Enabled = false;
            cboTipdoc.Enabled = u_n_opsel > 0;
            txtmnruc.Enabled = u_n_opsel > 0;
            opttipopersona.Enabled = u_n_opsel > 0;
            chkretencion.Enabled = u_n_opsel > 0;
            txtreplegaldni.Enabled = u_n_opsel > 0;
            txtreplegalname.Enabled = u_n_opsel > 0;

            txtrazonsocial.Enabled = u_n_opsel > 0 & !rbnatural.Checked;
            txtapepat.Enabled = u_n_opsel > 0 & rbnatural.Checked;
            txtapemat.Enabled = u_n_opsel > 0 & rbnatural.Checked;
            txtnombres.Enabled = u_n_opsel > 0 & rbnatural.Checked;
            txtcanalvtaid.Enabled = u_n_opsel > 0;

            txtdireccion.Enabled = u_n_opsel > 0;
            txtContacto.Enabled = u_n_opsel > 0;
            txtemail.Enabled = u_n_opsel > 0;
            txtweb.Enabled = u_n_opsel > 0;
            txttelefono1.Enabled = u_n_opsel > 0;
            txttelefono2.Enabled = u_n_opsel > 0;
            txttelefono3.Enabled = u_n_opsel > 0;
            txtctadetrac.Enabled = u_n_opsel > 0;
            cboDepar.Enabled = u_n_opsel > 0;
            cboProvi.Enabled = u_n_opsel > 0;
            cboDistr.Enabled = u_n_opsel > 0;
            optestado.Enabled = u_n_opsel > 0;
            btnnew.Enabled = u_n_opsel == 0;
            btnedit.Enabled = u_n_opsel == 0 & xcodcliente.Length > 0;
            btnsave.Enabled = u_n_opsel > 0;
            btnredo.Enabled = u_n_opsel > 0;
            btndelete.Enabled = u_n_opsel == 0 & xcodcliente.Length > 0;
            ;
            btnprint.Enabled = u_n_opsel == 0;
            btnload.Enabled = u_n_opsel == 0;
            btnexit.Enabled = u_n_opsel == 0;
            btninicial.Enabled = u_n_opsel == 0;
            btnultimo.Enabled = u_n_opsel == 0;
            btnsiguiente.Enabled = u_n_opsel == 0;
            btnanterior.Enabled = u_n_opsel == 0;
            btnbuscar.Enabled = u_n_opsel == 0;
            btnextraersunat.Enabled = u_n_opsel > 0;
            btnPais.Enabled = u_n_opsel > 0;
            GridExaminar.Enabled = u_n_opsel == 0;

            gridAnexos.Columns["direcname"].ReadOnly = u_n_opsel == 0;
            gridAnexos.Columns["direcdeta"].ReadOnly = u_n_opsel == 0;
            gridAnexos.Columns["telef"].ReadOnly = u_n_opsel == 0;
            gridAnexos.Columns["ubige"].ReadOnly = u_n_opsel == 0;
            btnDnuevo.Enabled = u_n_opsel > 0;
            btnDanular.Enabled = u_n_opsel > 0 & gridAnexos.Rows.Count > 0;
            gridBancos.Columns["bancoid"].ReadOnly = u_n_opsel == 0;
            gridBancos.Columns["ctactemn"].ReadOnly = u_n_opsel == 0;
            gridBancos.Columns["ctacteme"].ReadOnly = u_n_opsel == 0;
            btnAdicionar.Enabled = u_n_opsel > 0;
            btnEliminar.Enabled = u_n_opsel > 0 & gridBancos.Rows.Count > 0;
        }

        private void blanquear()
        {
            var BL = new clienteBL();
            var BE = new tb_cliente();

            try
            {
                txtcodigo.Text = BL.GetNextCod(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtmnruc.Text = string.Empty;
            rbjuridica.Checked = true;
            chkretencion.Checked = false;
            txtrazonsocial.Text = string.Empty;
            txtapepat.Text = string.Empty;
            txtapemat.Text = string.Empty;
            txtnombres.Text = string.Empty;
            txtdireccion.Text = string.Empty;
            txtContacto.Text = string.Empty;
            txtemail.Text = string.Empty;
            txtweb.Text = string.Empty;
            txttelefono1.Text = string.Empty;
            txttelefono2.Text = string.Empty;
            txttelefono3.Text = string.Empty;
            txtctadetrac.Text = string.Empty;
            txtpaisid.Text = string.Empty;
            txtpaisname.Text = string.Empty;
            lblDireccion.Text = string.Empty;
            rbactivo.Checked = false;
            rbbaja.Checked = false;
            rbanulado.Checked = false;
            txtCondicion.Text = string.Empty;
            txtcoddetalle.Text = string.Empty;
            txtRucAnexo.Text = string.Empty;
            txtnomdetalle.Text = string.Empty;
            txtcanalvtaid.Text = string.Empty;
            txtcanalvtaname.Text = string.Empty;
            txtreplegaldni.Text = string.Empty;
            txtreplegalname.Text = string.Empty;

            if (TablaAnexos != null)
            {
                TablaAnexos.AcceptChanges();
                if (TablaAnexos.Rows.Count > 0)
                {
                    for (vmncont = 0; vmncont < TablaAnexos.Rows.Count; vmncont++)
                    {
                        TablaAnexos.Rows[vmncont].Delete();
                    }
                    TablaAnexos.AcceptChanges();
                }
            }
            txtCodigob.Text = string.Empty;
            txtRucb.Text = string.Empty;
            txtCtactenameb.Text = string.Empty;
            if (TablaBancos != null)
            {
                TablaBancos.AcceptChanges();
                if (TablaBancos.Rows.Count > 0)
                {
                    for (vmncont = 0; vmncont < TablaBancos.Rows.Count; vmncont++)
                    {
                        TablaBancos.Rows[vmncont].Delete();
                    }
                    TablaBancos.AcceptChanges();
                }
            }
        }

        private void TabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if ((u_n_opsel > 0))
            {
                if ((TabControl1.Controls[e.TabPageIndex].Name.ToUpper() == "Pagina1"))
                {
                    e.Cancel = true;
                }
            }
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            u_PintaDatos();
            LimpiarDatosDirecc();
        }

        private void u_PintaDatos()
        {
            var xcodcliente = string.Empty;
            if (!Sw_LOad)
            {
                if (u_n_opsel != 1)
                {
                    if (TabControl1.SelectedIndex == 1)
                    {
                        if ((GridExaminar.CurrentRow != null))
                        {
                            xcodcliente = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["ctacte"].Value.ToString();
                            txtcodigo.Text = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["ctacte"].Value.ToString();
                            cboTipdoc.SelectedValue = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["docuidentid"].Value.ToString();
                            txtmnruc.Text = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["nmruc"].Value.ToString();

                            rbnatural.Checked = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["tpperson"].Value.ToString() == "01";
                            rbjuridica.Checked = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["tpperson"].Value.ToString() == "02";
                            rbnodom.Checked = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["tpperson"].Value.ToString() == "03";

                            if (object.ReferenceEquals(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["agerent"], DBNull.Value))
                            {
                                chkretencion.Checked = Convert.ToBoolean(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["agerent"].Value);
                            }
                            else
                            {
                                chkretencion.Checked = false;
                            }
                            txtrazonsocial.Text = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["ctactename"].Value.ToString();
                            txtapepat.Text = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["appat"].Value.ToString();
                            txtapemat.Text = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["apmat"].Value.ToString();
                            txtnombres.Text = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["nombr"].Value.ToString();

                            txtdireccion.Text = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["direc"].Value.ToString();
                            txtContacto.Text = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["contacto"].Value.ToString();
                            txtemail.Text = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["email"].Value.ToString();
                            txtweb.Text = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["urweb"].Value.ToString();
                            txttelefono1.Text = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["telef1"].Value.ToString();
                            txttelefono2.Text = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["telef2"].Value.ToString();
                            txttelefono3.Text = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["telef3"].Value.ToString();
                            txtctadetrac.Text = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["nctactedetraccion"].Value.ToString();
                            txtpaisid.Text = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["paisid"].Value.ToString();

                            // Agregamos el Canal de Venta
                            txtcanalvtaid.Text = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["canalventaid"].Value.ToString();
                            ValidaCanal(txtcanalvtaid.Text);

                            ValidaPais();
                            if (GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["paisid"].Value.ToString() == "9589")
                            {
                                cboDepar.SelectedValue = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["ubigeo"].Value.ToString().Substring(0, 2);
                                cboProvi.SelectedValue = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["ubigeo"].Value.ToString().Substring(0, 4);
                                cboDistr.SelectedValue = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["ubigeo"].Value.ToString();
                            }
                          

                            rbactivo.Checked = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["status"].Value.ToString() == "0";
                            rbbaja.Checked = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["status"].Value.ToString() == "1";
                            rbanulado.Checked = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["status"].Value.ToString() == "9";
                        }
                        else
                        {
                            blanquear();
                        }
                    }
                    u_CargaAnexos();
                    u_CargaBancos();
                }
                else
                {
                    txtcoddetalle.Text = txtcodigo.Text;
                    txtRucAnexo.Text = txtmnruc.Text;
                    txtnomdetalle.Text = txtrazonsocial.Text;

                    txtCodigob.Text = txtcodigo.Text;
                    txtRucb.Text = txtmnruc.Text;
                    txtCtactenameb.Text = txtrazonsocial.Text;
                }
                U_RefrescaControles();
            }
        }


        void ValidaCanal(String xcod)
        {
            var BL = new tb_cp_canalventaBL();
            var BE = new tb_cp_canalventa();
            DataTable dt = new DataTable();
            BE.parameters = xcod;

            dt = BL.GetAll2(VariablesPublicas.EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                txtcanalvtaname.Text = dt.Rows[0]["canalventaname"].ToString();
            }
        }

        private void txtCadenaBuscar_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_xFiltronom == txtCadenaBuscar.Text))
            {
                CargaDatos();
            }
        }


        private void txtCadenaBuscar_GotFocus(object sender, System.EventArgs e)
        {
            j_xFiltronom = txtCadenaBuscar.Text;
        }


        private void btnbuscar_Click(object sender, EventArgs e)
        {
            CargaDatos();
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            if (!(TabControl1.SelectedIndex == 0))
            {
                TabControl1.SelectedIndex = 0;
            }
            u_n_opsel = 1;
            blanquear();
            TabControl1.SelectedIndex = 0;
            TabControl1.SelectedIndex = 1;
            u_CargaAnexos();
            u_CargaBancos();
            cboTipdoc.SelectedValue = "6";
            txtpaisid.Text = "9589";
            txtpaisname.Text = "PERÚ";
            cboDepar.SelectedValue = "15";
            txtmnruc.Focus();
            j_Ruc = txtmnruc.Text;
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if ((GridExaminar.CurrentRow == null))
            {
                MessageBox.Show("Seleccione registro a modificar", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!(TabControl1.SelectedIndex == 0))
                {
                    TabControl1.SelectedIndex = 0;
                }

                u_n_opsel = 2;
                sw_EmpiezaEdicion = true;
                TabControl1.SelectedIndex = 0;
                TabControl1.SelectedIndex = 1;
                j_Ruc = txtmnruc.Text;
                sw_EmpiezaEdicion = false;
                if (txtrazonsocial.Enabled)
                {
                    txtrazonsocial.Focus();
                }
                else
                {
                    txtapepat.Focus();
                }
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (U_Validacion())
            {
                try
                {
                    if (txtcanalvtaid.Text.Length == 0)
                    {
                        MessageBox.Show("Ingrese el Canal de Venta !!!");
                        return;
                    }

                    var BL = new clienteBL();
                    var BE = new tb_cliente();

                    BE.ctacte = txtcodigo.Text.Trim().ToUpper();
                    BE.ctactename = txtrazonsocial.Text.Trim().ToUpper();
                    BE.docuidentid = cboTipdoc.SelectedValue.ToString();
                    BE.nmruc = txtmnruc.Text.Trim().ToUpper();
                    if (rbnatural.Checked == true)
                    {
                        BE.tpperson = "01";
                    }
                    if (rbjuridica.Checked == true)
                    {
                        BE.tpperson = "02";
                    }
                    if (rbnodom.Checked == true)
                    {
                        BE.tpperson = "03";
                    }
                    BE.agerent = chkretencion.Checked;
                    BE.appat = txtapepat.Text.Trim().ToUpper();
                    BE.apmat = txtapemat.Text.Trim().ToUpper();
                    BE.nombr = txtnombres.Text.Trim().ToUpper();
                    BE.direc = txtdireccion.Text.Trim().ToUpper();
                    BE.paisid = txtpaisid.Text.Trim().ToUpper();
                    if (txtpaisid.Text.Trim() != "9589")
                    {
                        BE.ubige = "000000";
                    }
                    else
                    {
                        BE.ubige = cboDistr.SelectedValue.ToString();
                    }

                    BE.telef1 = txttelefono1.Text.Trim().ToUpper();
                    BE.email = txtemail.Text.Trim().ToUpper();
                    BE.urweb = txtweb.Text.Trim().ToUpper();
                    BE.telef2 = txttelefono2.Text.Trim().ToUpper();
                    BE.telef3 = txttelefono3.Text.Trim().ToUpper();
                    BE.contacto = txtContacto.Text.Trim().ToUpper();
                    BE.nctactedetraccion = txtctadetrac.Text.Trim().ToUpper();
                    BE.canalventaid = txtcanalvtaid.Text;
                    BE.replegaldni = txtreplegaldni.Text;
                    BE.replegalname = txtreplegalname.Text;

                    if (rbactivo.Checked == true)
                    {
                        BE.status = "0";
                    }
                    if (rbbaja.Checked == true)
                    {
                        BE.status = "1";
                    }
                    if (rbanulado.Checked == true)
                    {
                        BE.status = "9";
                    }
                    BE.usuar = VariablesPublicas.Usuar.Trim();

                    if (u_n_opsel == 1)
                    {
                        if (BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE))
                        {
                        }
                        else
                        {
                            MessageBox.Show("Contacte con sistemas", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        ValidaInsert_Update();
                    }
                    else
                    {
                        if (BL.Update(VariablesPublicas.EmpresaID.ToString(), BE))
                        {
                        }
                        else
                        {
                            MessageBox.Show("Contacte con sistemas", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        ValidaInsert_Update();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                #region Direcciones
                //if (gridAnexos.RowCount > 0)
                //{
                //    try
                //    {
                //        var BL = new cliente_direcBL();
                //        var BE = new tb_cliente_direc();

                //        var Detalle = new tb_cliente_direc.Item();
                //        var ListaItems = new List<tb_cliente_direc.Item>();

                //        BE.ctacte = txtcodigo.Text.Trim().ToUpper();
                //        var item = 0;
                //        foreach (DataRow fila in TablaAnexos.Rows)
                //        {
                //            Detalle = new tb_cliente_direc.Item();
                //            item++;
                //            Detalle.direcnume = fila["direcnume"].ToString();
                //            Detalle.direcname = fila["direcname"].ToString();
                //            Detalle.direcdeta = fila["direcdeta"].ToString();
                //            Detalle.telef = fila["telef"].ToString();
                //            Detalle.ubige = fila["ubige"].ToString();
                //            Detalle.usuar = VariablesPublicas.Usuar.ToString();
                //            Detalle.status = "0";

                //            ListaItems.Add(Detalle);
                //        }
                //        BE.ListaItems = ListaItems;

                //        if (BL.Insert_XML(VariablesPublicas.EmpresaID.ToString(), BE))
                //        {
                //        }
                //        else
                //        {
                //            MessageBox.Show("Contacte con sistemas", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        }

                //        InsertDirecc_DBF();

                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}
                #endregion

                #region Cuentas Bancarias
                if (gridBancos.RowCount > 0)
                {
                    try
                    {
                        var BL = new cliente_bancoBL();
                        var BE = new tb_cliente_banco();

                        var Detalle = new tb_cliente_banco.Item();
                        var ListaItems = new List<tb_cliente_banco.Item>();

                        BE.ctacte = txtcodigo.Text.Trim().ToUpper();
                        var item = 0;
                        foreach (DataRow fila in TablaBancos.Rows)
                        {
                            Detalle = new tb_cliente_banco.Item();

                            item++;

                            Detalle.bancoid = fila["bancoid"].ToString();
                            Detalle.ctactemn = fila["ctactemn"].ToString();
                            Detalle.ctacteme = fila["ctacteme"].ToString();
                            Detalle.usuar = VariablesPublicas.Usuar.ToString();

                            ListaItems.Add(Detalle);
                        }
                        BE.ListaItems = ListaItems;

                        if (BL.Insert_XML(VariablesPublicas.EmpresaID.ToString(), BE))
                        {
                            MessageBox.Show("Se grabó con éxito", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Contacte con sistemas", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                #endregion

                U_CancelarEdicion(0);
            }
        }




        private void Insert_DBF()
        {           
            try
            {
                if (txtcanalvtaid.Text.Length == 0)
                {
                    MessageBox.Show("Ingrese el Canal de Venta !!!");
                    return;
                }

                var BL = new clienteBL();
                var BE = new tb_cliente();

                BE.ctacte = txtcodigo.Text.Trim().ToUpper();
                BE.ctactename = txtrazonsocial.Text.Trim().ToUpper();
                BE.docuidentid = cboTipdoc.SelectedValue.ToString();
                BE.nmruc = txtmnruc.Text.Trim().ToUpper();
                if (rbnatural.Checked == true)
                {
                    BE.tpperson = "01";
                }
                if (rbjuridica.Checked == true)
                {
                    BE.tpperson = "02";
                }
                if (rbnodom.Checked == true)
                {
                    BE.tpperson = "03";
                }
                BE.agerent = chkretencion.Checked;
                BE.appat = txtapepat.Text.Trim().ToUpper();
                BE.apmat = txtapemat.Text.Trim().ToUpper();
                BE.nombr = txtnombres.Text.Trim().ToUpper();
                BE.direc = txtdireccion.Text.Trim().ToUpper();
                BE.paisid = txtpaisid.Text.Trim().ToUpper();
                if (txtpaisid.Text.Trim() != "9589")
                {
                    BE.ubige = "000000";
                }
                else
                {
                    BE.ubige = cboDistr.SelectedValue.ToString();
                }

                BE.telef1 = txttelefono1.Text.Trim().ToUpper();
                BE.email = txtemail.Text.Trim().ToUpper();
                BE.urweb = txtweb.Text.Trim().ToUpper();
                BE.telef2 = txttelefono2.Text.Trim().ToUpper();
                BE.telef3 = txttelefono3.Text.Trim().ToUpper();
                BE.contacto = txtContacto.Text.Trim().ToUpper();
                BE.nctactedetraccion = txtctadetrac.Text.Trim().ToUpper();
                BE.canalventaid = txtcanalvtaid.Text;
                BE.replegaldni = txtreplegaldni.Text;
                BE.replegalname = txtreplegalname.Text;

                if (rbactivo.Checked == true)
                {
                    BE.status = "0";
                }
                if (rbbaja.Checked == true)
                {
                    BE.status = "1";
                }
                if (rbanulado.Checked == true)
                {
                    BE.status = "9";
                }
                BE.usuar = VariablesPublicas.Usuar.Trim();

                                         
                if (BE.status == "0")
                    BE.status = "1"; // 1 PARA DBF ES ACTIVO
                BE.ctacte = Equivalencias.Right(txtcodigo.Text.Trim().ToUpper(), 4);
                BE.usuar = Equivalencias.Left(VariablesPublicas.Usuar.Trim(), 3);
                BE.ctactename = Equivalencias.Left(txtrazonsocial.Text.Trim(), 60);
                BE.direc = Equivalencias.Left(txtdireccion.Text.Trim(), 100);
                        
                if (BL.Insert_dbf(VariablesPublicas.EmpresaID.ToString(), BE))
                {
                }
                else
                {
                    MessageBox.Show("Contacte con sistemas", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                                       
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                    
        }

        private void Update_DBF()
        {           
            try
            {
                if (txtcanalvtaid.Text.Length == 0)
                {
                    MessageBox.Show("Ingrese el Canal de Venta !!!");
                    return;
                }

                var BL = new clienteBL();
                var BE = new tb_cliente();

                BE.ctacte = txtcodigo.Text.Trim().ToUpper();
                BE.ctactename = txtrazonsocial.Text.Trim().ToUpper();
                BE.docuidentid = cboTipdoc.SelectedValue.ToString();
                BE.nmruc = txtmnruc.Text.Trim().ToUpper();
                if (rbnatural.Checked == true)
                {
                    BE.tpperson = "01";
                }
                if (rbjuridica.Checked == true)
                {
                    BE.tpperson = "02";
                }
                if (rbnodom.Checked == true)
                {
                    BE.tpperson = "03";
                }
                BE.agerent = chkretencion.Checked;
                BE.appat = txtapepat.Text.Trim().ToUpper();
                BE.apmat = txtapemat.Text.Trim().ToUpper();
                BE.nombr = txtnombres.Text.Trim().ToUpper();
                BE.direc = txtdireccion.Text.Trim().ToUpper();
                BE.paisid = txtpaisid.Text.Trim().ToUpper();
                if (txtpaisid.Text.Trim() != "9589")
                {
                    BE.ubige = "000000";
                }
                else
                {
                    BE.ubige = cboDistr.SelectedValue.ToString();
                }

                BE.telef1 = txttelefono1.Text.Trim().ToUpper();
                BE.email = txtemail.Text.Trim().ToUpper();
                BE.urweb = txtweb.Text.Trim().ToUpper();
                BE.telef2 = txttelefono2.Text.Trim().ToUpper();
                BE.telef3 = txttelefono3.Text.Trim().ToUpper();
                BE.contacto = txtContacto.Text.Trim().ToUpper();
                BE.nctactedetraccion = txtctadetrac.Text.Trim().ToUpper();
                BE.canalventaid = txtcanalvtaid.Text;
                BE.replegaldni = txtreplegaldni.Text;
                BE.replegalname = txtreplegalname.Text;

                if (rbactivo.Checked == true)
                {
                    BE.status = "0";
                }
                if (rbbaja.Checked == true)
                {
                    BE.status = "1";
                }
                if (rbanulado.Checked == true)
                {
                    BE.status = "9";
                }
                BE.usuar = VariablesPublicas.Usuar.Trim();


                if (BE.status == "0")
                    BE.status = "1"; // 1 PARA DBF ES ACTIVO
                BE.ctacte = Equivalencias.Right(txtcodigo.Text.Trim().ToUpper(), 4);
                BE.usuar = Equivalencias.Left(VariablesPublicas.Usuar.Trim(), 3);
                BE.ctactename = Equivalencias.Left(txtrazonsocial.Text.Trim(), 60);
                BE.direc = Equivalencias.Left(txtdireccion.Text.Trim(), 100);

                if (BL.Update_dbf(VariablesPublicas.EmpresaID.ToString(), BE))
                {
                }
                else
                {
                    MessageBox.Show("Contacte con sistemas", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                       
        }

        private Boolean InsertDirecc_DBF()
        {
            Boolean result = false;

            var BL = new cliente_direcBL();
            var BE = new tb_cliente_direc();
          
            BE.ctacte = Equivalencias.Right(txtcoddetalle.Text.Trim(), 4);
            BE.direcnume = Equivalencias.Right(txt_ordenid.Text, 2);
            BE.direcname = txt_denominacion.Text;
            BE.direcdeta = txt_direccion.Text;
            BE.telef = txt_telefono.Text;
            BE.ubig1 = txt_ubigeoid.Text.ToString().Substring(0, 2);
            BE.ubig2 = txt_ubigeoid.Text.ToString().Substring(2, 2);
            BE.ubig3 = txt_ubigeoid.Text.ToString().Substring(4, 2);
            BE.usuar = Equivalencias.Left(VariablesPublicas.Usuar.ToString().Trim(), 3);
            BE.status = "1";
           
            try
            {
                result = BL.Insert_dbf(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;                                                                                                       
        }

        private Boolean UpdateDirecc_DBF()
        {
            Boolean result = false;

            var BL = new cliente_direcBL();
            var BE = new tb_cliente_direc();

            BE.ctacte = Equivalencias.Right(txtcoddetalle.Text.Trim(), 4);
            BE.direcnume = Equivalencias.Right(txt_ordenid.Text, 2);
            BE.direcname = txt_denominacion.Text;
            BE.direcdeta = txt_direccion.Text;
            BE.telef = txt_telefono.Text;
            BE.ubig1 = txt_ubigeoid.Text.ToString().Substring(0, 2);
            BE.ubig2 = txt_ubigeoid.Text.ToString().Substring(2, 2);
            BE.ubig3 = txt_ubigeoid.Text.ToString().Substring(4, 2);
            BE.usuar = Equivalencias.Left(VariablesPublicas.Usuar.ToString().Trim(), 3);
            BE.status = "1";

            try
            {
                result = BL.Update_dbf(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

        private Boolean DeleteDirecc_DBF()
        {
            Boolean result = false;
            var BL = new cliente_direcBL();
            var BE = new tb_cliente_direc();
            BE.ctacte = Equivalencias.Right(txtcoddetalle.Text.Trim(), 4);
            BE.direcnume = Equivalencias.Right(txt_ordenid.Text, 2);
            BE.status = "9";

            try
            {
                result = BL.Delete_dbf(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

        private void ValidaInsert_Update()
        {
            var BL = new clienteBL();
            var BE = new tb_cliente();
            var dt = new DataTable();
            BE.ctacte = Equivalencias.Right(txtcodigo.Text.Trim(),4);
            dt = BL.GetAll_CODdbf(VariablesPublicas.EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                var n = Convert.ToInt32(dt.Rows[0]["cant"].ToString());
                if (n > 0)
                {
                    Update_DBF();
                }
                else
                {
                    Insert_DBF();
                }
            }
        }

        private bool U_Validacion()
        {
            var xmsg = string.Empty;
            var objeto = new object();
            var tmptabla = new DataTable();
            if ((txtrazonsocial.Text.Trim().Length == 0))
            {
                xmsg = "Ingrese Razón Social / Nombres  de cliente";
                objeto = txtrazonsocial;
            }
            else
            {
                if ((txtmnruc.Text.Length > 0))
                {
                    if (((u_n_opsel == 1) || !(j_Ruc == txtmnruc.Text)))
                    {
                        var BL = new clienteBL();
                        var BE = new tb_cliente();

                        BE.nmruc = txtmnruc.Text;
                        tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                        if ((tmptabla.Rows.Count > 0))
                        {
                            xmsg = "RUC ya registrado";
                            objeto = txtmnruc;
                        }
                    }
                }
                if ((u_n_opsel == 1))
                {
                    if ((txtcodigo.Text.Trim().Length == 0))
                    {
                        xmsg = "Ingrese Código";
                        objeto = txtcodigo;
                    }
                    else
                    {
                        var BL = new clienteBL();
                        var BE = new tb_cliente();

                        BE.ctacte = txtcodigo.Text;
                        tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                        if ((tmptabla.Rows.Count > 0))
                        {
                            xmsg = "Código ya registrado";
                            objeto = txtcodigo;
                        }
                    }
                }
            }
            if ((xmsg.Trim().Length > 0))
            {
                MessageBox.Show(xmsg, "Error en Ingreso de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (!(objeto == null))
                {
                    objeto = Focus();
                }
            }
            return xmsg.Trim().Length == 0;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (!(GridExaminar.CurrentRow == null))
            {
                if (MessageBox.Show("Desea eliminar datos de cliente ...?"
                                    + txtmnruc.Text.Trim() + "-" + txtnomdetalle.Text.Trim(), "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        var BL = new clienteBL();
                        var BE = new tb_cliente();

                        BE.ctacte = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["ctacte"].Value.ToString();

                        if (BL.Delete(VariablesPublicas.EmpresaID.ToString(), BE))
                        {
                            GridExaminar.Rows.Remove(GridExaminar.CurrentRow);
                            GridExaminar.Refresh();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            U_RefrescaControles();
        }

        private void btnredo_Click(object sender, EventArgs e)
        {
            U_CancelarEdicion(1);
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            CargaDatos();
            U_RefrescaControles();
        }

        private void U_CancelarEdicion(int SwConfirmacion)
        {
            var sw_prosigue = true;
            int lc_cont;
            if ((SwConfirmacion == 1))
            {
                sw_prosigue = (MessageBox.Show("Desea cancelar ingreso de datos...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
            }
            else
            {
                sw_prosigue = true;
            }
            if (sw_prosigue)
            {
                var xtmpuser = txtcodigo.Text;
                lblDireccion.Text = string.Empty;
                txtCondicion.Text = string.Empty;
                u_n_opsel = 0;
                TabControl1.SelectedIndex = 0;
                U_RefrescaControles();
                CargaDatos();
                if ((GridExaminar.RowCount > 0))
                {
                    for (lc_cont = 0; (lc_cont <= (GridExaminar.Rows.Count - 1)); lc_cont++)
                    {
                        if (GridExaminar.Rows[lc_cont].Cells["ctacte"].ToString() == xtmpuser)
                        {
                            GridExaminar.CurrentCell = GridExaminar.Rows[lc_cont].Cells["ctacte"];
                            break;
                        }
                    }
                }
            }
        }
        private void cboDepar_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillResultProvi(cboProvi, cboDistr, cboDepar.SelectedValue.ToString());
        }
        private void cboProvi_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillResultDistr(cboDistr, cboProvi.SelectedValue.ToString());
        }
        private void cboDpto_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void cboProv_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void rbnatural_CheckedChanged(object sender, EventArgs e)
        {
            if ((!Sw_LOad && u_n_opsel > 0) && !sw_EmpiezaEdicion)
            {
                U_RefrescaControles();
            }
        }
        private void rbjuridica_CheckedChanged(object sender, EventArgs e)
        {
            if ((!Sw_LOad && ((u_n_opsel > 0) && !sw_EmpiezaEdicion)))
            {
                U_RefrescaControles();
                txtapepat.Text = string.Empty;
                txtapemat.Text = string.Empty;
                txtnombres.Text = string.Empty;
            }
        }
        private void rbnodom_CheckedChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad & u_n_opsel > 0 & !sw_EmpiezaEdicion)
            {
                U_RefrescaControles();
                txtapepat.Text = string.Empty;
                txtapemat.Text = string.Empty;
                txtnombres.Text = string.Empty;
            }
        }

        private void GridExaminar_SelectionChanged(object sender, EventArgs e)
        {
            if (!(Sw_LOad) & (u_n_opsel == 0))
            {
            }
        }

        private void btnPais_Click(object sender, EventArgs e)
        {
            var frmayuda = new Ayudas.Frm_help_general();

            frmayuda.tipoo = "sql";
            frmayuda.titulo = "Ayuda Paises";
            frmayuda.sqlquery = "select paisid, paisname from tb_pais";
            frmayuda.sqlinner = string.Empty;
            frmayuda.sqlwhere = "where";
            frmayuda.sqland = string.Empty;
            frmayuda.criteriosbusqueda = new string[] { "PAÍS", "CODIGO" };
            frmayuda.columbusqueda = "paisname,paisid";
            frmayuda.returndatos = "0,1";

            frmayuda.Owner = this;
            frmayuda.PasaProveedor = RecibePais;
            frmayuda.ShowDialog();
        }
        private void RecibePais(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                sw_novaluechange = true;
                txtpaisid.Text = resultado1;
                txtpaisname.Text = resultado2;
                sw_novaluechange = false;
            }
        }
        private void ValidaPais()
        {
            if (txtpaisid.Text.Trim().Length > 0)
            {
                var BL = new paisBL();
                var BE = new tb_pais();

                BE.paisid = txtpaisid.Text;
                var tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                if (tmptabla.Rows.Count == 0)
                {
                    txtpaisid.Text = j_String;
                }
                else
                {
                    txtpaisid.Text = tmptabla.Rows[0]["paisid"].ToString();
                    txtpaisname.Text = tmptabla.Rows[0]["paisname"].ToString();
                }
            }
            else
            {
                txtpaisid.Text = j_String;
            }
        }

        private void btninicial_Click(object sender, EventArgs e)
        {
            u_Roleo(VariablesPublicas.toprecord);
        }
        private void btnanterior_Click(object sender, EventArgs e)
        {
            u_Roleo(VariablesPublicas.prevrecord);
        }
        private void btnsiguiente_Click(object sender, EventArgs e)
        {
            u_Roleo(VariablesPublicas.nextrecord);
        }
        private void btnultimo_Click(object sender, EventArgs e)
        {
            u_Roleo(VariablesPublicas.bottrecord);
        }
        public void u_Roleo(string xTipo)
        {
            RoleoGrid(GridExaminar, xTipo, "ctacte");
            u_PintaDatos();
        }
        public void RoleoGrid(DataGridView Grid, string xTipo, string xnamecolumna)
        {
            var nposreg = 0;
            var ncurrentfila = 0;
            var ncurrentcol = 0;
            try
            {
                nposreg = Grid.CurrentRow.Index;
                ncurrentfila = Grid.CurrentRow.Index;
                ncurrentcol = Grid.CurrentCell.ColumnIndex;
                if (xTipo == VariablesPublicas.toprecord)
                {
                    nposreg = 0;
                }
                if (xTipo == VariablesPublicas.bottrecord)
                {
                    nposreg = Grid.RowCount - 1;
                }
                if (xTipo == VariablesPublicas.nextrecord)
                {
                    if (nposreg < Grid.RowCount - 1)
                    {
                        nposreg = nposreg + 1;
                    }
                }
                if (xTipo == VariablesPublicas.prevrecord)
                {
                    if (nposreg > 0)
                    {
                        nposreg = nposreg - 1;
                    }
                }
                Grid.CurrentCell = Grid.Rows[nposreg].Cells[Grid.CurrentCell.ColumnIndex];
            }
            catch (Exception ex)
            {
                Grid.CurrentCell = Grid.Rows[ncurrentfila].Cells[ncurrentcol];
            }
        }

        private void cboCriterioBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCadenaBuscar.Focus();
            }
        }

        private void txtCadenaBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargaDatos();
                btnbuscar.Focus();
            }
        }

        private void u_CargaAnexos()
        {
            var xcodcliente = txtcodigo.Text;
            try
            {
                var BL = new cliente_direcBL();
                var BE = new tb_cliente_direc();

                BE.ctacte = xcodcliente;
                TablaAnexos = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                gridAnexos.AutoGenerateColumns = false;
                gridAnexos.DataSource = TablaAnexos;
                txtcoddetalle.Text = string.Empty;
                txtRucAnexo.Text = string.Empty;
                txtnomdetalle.Text = string.Empty;
                if ((u_n_opsel == 0))
                {
                    if (!(GridExaminar.CurrentRow == null))
                    {
                        txtcoddetalle.Text = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["ctacte"].Value.ToString();
                        txtRucAnexo.Text = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["nmruc"].Value.ToString();
                        txtnomdetalle.Text = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["ctactename"].Value.ToString();
                    }
                }
                else
                {
                    txtcoddetalle.Text = txtcodigo.Text;
                    txtRucAnexo.Text = txtmnruc.Text;
                    txtnomdetalle.Text = txtrazonsocial.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDnuevo_Click(object sender, EventArgs e)
        {
            TablaAnexos.Rows.Add(VariablesPublicas.InsertIntoTable(TablaAnexos));
            TablaAnexos.Rows[TablaAnexos.Rows.Count - 1]["direcnume"] = VariablesPublicas.CalcMaxField(TablaAnexos, "direcnume", 3);
            gridAnexos.Refresh();
            gridAnexos.CurrentCell = gridAnexos.Rows[gridAnexos.Rows.Count - 1].Cells["direcdeta"];
            gridAnexos.BeginEdit(true);
            TablaAnexos.AcceptChanges();
            U_RefrescaControles();
        }
        private void btnDanular_Click(object sender, EventArgs e)
        {
            if ((TablaAnexos.Rows.Count > 0))
            {
                gridAnexos.Rows.Remove(gridAnexos.CurrentRow);
                TablaAnexos.AcceptChanges();
                gridAnexos.Refresh();
                U_RefrescaControles();
            }
        }
        private void gridAnexos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if ((gridAnexos.Columns[gridAnexos.CurrentCell.ColumnIndex].Name.ToUpper() == "ubigeo".ToUpper()))
            {
                j_CodUbigeo = gridAnexos.CurrentCell.Value.ToString();
            }
        }
        private void gridAnexos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if ((gridAnexos.Columns[gridAnexos.CurrentCell.ColumnIndex].Name.ToUpper() == "direcdeta".ToUpper()))
            {
                txtCArti = (TextBox)e.Control;
                txtCArti.MaxLength = 100;
                txtCArti.CharacterCasing = CharacterCasing.Upper;
                txtCArti.Text.Trim();
                e.Control.KeyDown += VariablesPublicas.CapturarTeclaGRID;
            }
            if ((gridAnexos.Columns[gridAnexos.CurrentCell.ColumnIndex].Name.ToUpper() == "ubige".ToUpper()))
            {
                txtCArti = ((TextBox)(e.Control));
                txtCArti.MaxLength = 6;
                txtCArti.CharacterCasing = CharacterCasing.Normal;
                txtCArti.Text.Trim();
                e.Control.KeyDown += VariablesPublicas.CapturarTeclaGRID;
            }
            _NameColumn = gridAnexos.Columns[gridAnexos.CurrentCell.ColumnIndex].Name.ToUpper();
        }
        private void gridAnexos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if ((_NameColumn.Length > 0))
            {
                switch (_NameColumn)
                {
                    case "ubige":
                        if (VariablesPublicas.PulsaAyudaArticulos)
                        {
                            txtCArti = null;
                            AyudaUbigeoAnexo();
                        }
                        break;
                }
            }
            _NameColumn = string.Empty;
        }
        private void gridAnexos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!Sw_LOad)
            {
                if (!(gridAnexos.CurrentRow == null))
                {
                    sw_novaluechange = true;
                    if ((gridAnexos.Columns[e.ColumnIndex].Name.ToUpper() == "ubige".ToUpper()))
                    {
                        ValidaUbigeo();
                    }
                    sw_novaluechange = false;
                }
            }
        }
        private void gridAnexos_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
            }
            if (((e.KeyCode == Keys.F1) && (u_n_opsel > 0)))
            {
                if (!(gridAnexos.CurrentCell == null))
                {
                    if ((gridAnexos.CurrentCell.ReadOnly == false))
                    {
                        if ((gridAnexos.Columns[gridAnexos.CurrentCell.ColumnIndex].Name.ToUpper() == "ubige".ToUpper()))
                        {
                            AyudaUbigeoAnexo();
                        }
                    }
                }
            }




        }



        private void gridAnexos_SelectionChanged(object sender, EventArgs e)
        {
            if (!(gridAnexos.CurrentCell == null))
            {
                if ((gridAnexos.Columns[gridAnexos.CurrentCell.ColumnIndex].Name.ToUpper() == "ubige".ToUpper()))
                {
                    ValidaUbigeo();
                }
            }
            U_RefrescaControles();
        }

        private void txtapepat_TextChanged(object sender, EventArgs e)
        {
            if ((!Sw_LOad && (u_n_opsel > 0)))
            {
                u_ArmaRazonSocial();
            }
        }
        private void txtapemat_TextChanged(object sender, EventArgs e)
        {
            if ((!Sw_LOad && (u_n_opsel > 0)))
            {
                u_ArmaRazonSocial();
            }
        }
        private void txtnombres_TextChanged(object sender, EventArgs e)
        {
            if ((!Sw_LOad && (u_n_opsel > 0)))
            {
                u_ArmaRazonSocial();
            }
        }
        private void u_ArmaRazonSocial()
        {
            var xprvnom = string.Empty;
            if ((txtapepat.Text.Trim().Length > 0))
            {
                xprvnom = (xprvnom + (txtapepat.Text.Trim() + " "));
            }
            if ((txtapemat.Text.Trim().Length > 0))
            {
                xprvnom = (xprvnom + (txtapemat.Text.Trim() + ", "));
            }
            if ((txtnombres.Text.Trim().Length > 0))
            {
                xprvnom = (xprvnom + (txtnombres.Text.Trim() + " "));
            }
            txtrazonsocial.Text = xprvnom;
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if ((keyData == Keys.Enter))
            {
                if (!(GridExaminar.CurrentCell == null))
                {
                    SendKeys.Send("\t");
                    return true;
                }
                else
                {
                    if ((TabControl1.SelectedIndex == 1))
                    {
                        if (!gridAnexos.IsCurrentCellInEditMode)
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
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtcodigo_LostFocus(object sender, System.EventArgs e)
        {
            if ((u_n_opsel > 0))
            {
                if ((txtcodigo.Text.Trim().Length > 0))
                {
                    txtcodigo.Text = VariablesPublicas.PADR(txtcodigo.Text.Trim(), txtcodigo.MaxLength, " ");
                }
            }
        }
        internal void AyudaUbigeoAnexo()
        {
            var frmayuda = new Ayudas.Frm_help_general();

            frmayuda.tipoo = "sql";
            frmayuda.titulo = "Ayuda Bancos";
            frmayuda.sqlquery = "select ubige, depar, provi, distr  from tb_ubigeo";
            frmayuda.sqlinner = string.Empty;
            frmayuda.sqlwhere = "where";
            frmayuda.sqland = string.Empty;
            frmayuda.criteriosbusqueda = new string[] { "UBIGEO", "CODIGO" };
            frmayuda.columbusqueda = "(depar+provi+distr),codigoid";
            frmayuda.returndatos = "0,1,2,3";

            frmayuda.Owner = this;
            frmayuda.PasaProveedor = RecibeUbigeoAnexo;
            frmayuda.ShowDialog();
        }
        internal void RecibeUbigeoAnexo(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                sw_novaluechange = true;
                gridAnexos.Rows[gridAnexos.CurrentRow.Index].Cells["ubige"].Value = resultado1;
                txtUbigeoanexos.Text = resultado2 + " - " + resultado3 + " - " + resultado4;
                sw_novaluechange = false;
            }
        }
        internal void ValidaUbigeo()
        {
            Int16 lc_cont;
            var zhallado = false;

            var VMNROITEM = gridAnexos.Rows[gridAnexos.CurrentRow.Index].Cells["direcnume"].Value.ToString();
            var xcodartic = "..";
            if (!(gridAnexos.Rows[gridAnexos.CurrentRow.Index].Cells["ubige"].Value == DBNull.Value))
            {
                xcodartic = gridAnexos.Rows[gridAnexos.CurrentRow.Index].Cells["ubige"].Value.ToString();
            }
            if ( xcodartic.Trim().Length == 0 )
            {
                zhallado = true;
            }
            else
            {
                var BL = new ubigeoBL();
                var BE = new tb_ubigeo();

                BE.ubige = xcodartic;
                tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                for (lc_cont = 0; lc_cont < TablaAnexos.Rows.Count; lc_cont++)
                {
                    if (TablaAnexos.Rows[lc_cont]["direcnume"].ToString() == VMNROITEM )
                    {
                        if ( tmptabla.Rows.Count > 0 )
                        {
                            TablaAnexos.Rows[lc_cont]["ubige"] = tmptabla.Rows[0]["ubige"];
                            txtUbigeoanexos.Text = tmptabla.Rows[0]["depar"] + " - " + tmptabla.Rows[0]["provi"] + " - " + tmptabla.Rows[0]["distr"];
                            zhallado = true;
                            break;
                        }
                    }
                }
            }
            if ( ! zhallado )
            {
                gridAnexos.Rows[gridAnexos.CurrentRow.Index].Cells["ubige"].Value = j_CodUbigeo;
            }
            gridAnexos.Refresh();
        }

        private void btnextraersunat_Click(object sender, EventArgs e)
        {
            if (cboTipdoc.SelectedValue.ToString() == "6" & ValidarRuc.validarRuc(txtmnruc.Text.Trim()))
            {
                try
                {
                    if (txtCapcha.Text.Trim().Length == 0)
                    {
                        lblDireccion.Text = "Ingrese imagen correctamente";
                        txtCapcha.SelectAll();
                        txtCapcha.Focus();
                        return;
                    }
                    if (txtmnruc.Text.ToString().Trim().Length != 11)
                    {
                        lblDireccion.Text = "Ingrese RUC Válido";
                        txtmnruc.SelectAll();
                        txtmnruc.Focus();
                        return;
                    }
                    myInfoSunat.GetInfoSunat(txtmnruc.Text.Trim(), txtCapcha.Text.Trim());
                    //txtCapcha.Clear();
                    //ImagenSunat.Image = null;
                    CaptionResulSunat();
                    //CargarImagen();
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("El Número de Ruc no es válido?", "BapConta-" + Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void CaptionResulSunat()
        {
            try
            {
                string btele = "";
                // Rellenando Datos Devueltos
                //txtmnruc.Text = myInfoSunat.Ruc;
                rbjuridica.Checked = (Equivalencias.Left(txtmnruc.Text.Trim(), 1) == "2" ? true : false);
                rbnatural.Checked = !rbjuridica.Checked;
                cboTipdoc.SelectedValue = "6";
                txtrazonsocial.Text = myInfoSunat.RazonSocial;
                if (Equivalencias.Left(txtmnruc.Text.Trim(), 1) == "1")
                {
                    txtapepat.Text = VariablesPublicas.Palabras(myInfoSunat.RazonSocial.Trim(), 1).Trim();
                    txtapemat.Text = VariablesPublicas.Palabras(myInfoSunat.RazonSocial.Trim(), 2).Trim();
                    txtnombres.Text = VariablesPublicas.Palabras(myInfoSunat.RazonSocial.Trim(), 3).Trim() + " " + VariablesPublicas.Palabras(myInfoSunat.RazonSocial.Trim(), 4).Trim() + " " + VariablesPublicas.Palabras(myInfoSunat.RazonSocial.Trim(), 5).Trim() + " " + VariablesPublicas.Palabras(myInfoSunat.RazonSocial.ToString().Trim(), 6).ToString().Trim();
                }
                else
                {
                    txtapemat.Text = "";
                    txtapepat.Text = "";
                    txtnombres.Text = "";
                }
                txtnombres.Text.ToString().Trim();
                txtdireccion.Text = myInfoSunat.Direccion;
                lblDireccion.Text = myInfoSunat.Direccion;
                Text1_Change();

                btele = myInfoSunat.Telefonos.Replace("-</", "").Replace("/ ", "").Replace("--", "").Trim();
                if (btele.Trim().Length > 0)
                {
                    txttelefono1.Text = VariablesPublicas.Palabras(btele.Trim(), 1);
                    txttelefono2.Text = VariablesPublicas.Palabras(btele.Trim(), 2);
                    txttelefono3.Text = VariablesPublicas.Palabras(btele.Trim(), 3);
                }
                //txttelefono1.Text = ((myInfoSunat.Telefonos == "-</") ? string.Empty : myInfoSunat.Telefonos);
                txtpaisid.Text = "9589";
                txtpaisname.Text = "PERÚ";

                rbactivo.Checked = myInfoSunat.Estado.Substring(0, 6) == "ACTIVO";
                rbbaja.Checked = !rbactivo.Checked;
                //txtEstado.Text = myInfoSunat.Estado;

                //rbHabido.Checked = ((myInfoSunat.Condicion.Trim() == "HABIDO" | Equivalencias.Left(myInfoSunat.Condicion.ToUpper().Trim(), 7) == "CONDICI" | Equivalencias.Left(myInfoSunat.Condicion.ToUpper().Trim(), 7) == "CONFIRM") ? true : false);
                //rbNoHallado.Checked = ((myInfoSunat.Condicion.Trim() == "NO HALLADO") ? true : false);
                //rbNoHabido.Checked = ((myInfoSunat.Condicion.Trim() == "NO HABIDO") ? true : false);
                txtCondicion.Text = myInfoSunat.Condicion;

                chkretencion.Checked = myInfoSunat.AgeRetencion;
                //chkbuen.Checked = myInfoSunat.BuenContribuyente;
                //chkagentepercepcion.Checked = myInfoSunat.AgePercepcion;

                txtrazonsocial.Text = myInfoSunat.RazonSocial;

            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }
        private void Text1_Change()
        {
            txtdireccion.Text = txtdireccion.Text.Replace("  ", " ").Trim();
            txtdireccion.SelectionStart = txtdireccion.TextLength;
        }

        private void ExtraerDatosSunat()
        {
            string rucc;
            var cCapcha = "NVAA";

            rucc = txtmnruc.Text;
            var oHTTP = string.Empty;
            try
            {
                var baseUri = ("http://www.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias?accion=consPorRuc&nroRuc=" + rucc + "&codigo=" + cCapcha);
                var connection = (HttpWebRequest)HttpWebRequest.Create(baseUri);
                connection.Method = "GET";
                var response = (HttpWebResponse)connection.GetResponse();
                var sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                oHTTP = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Conectarse a Internet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                oHTTP = string.Empty;
            }

            var p1 = string.Empty;
            var p2 = string.Empty;
            var p3 = string.Empty;
            var p4 = string.Empty;
            var p5 = string.Empty;
            var p6 = string.Empty;
            var p7 = string.Empty;
            var p8 = string.Empty;
            var p9 = string.Empty;
            var F1 = string.Empty;
            var F2 = string.Empty;
            var F3 = string.Empty;
            var F4 = string.Empty;
            var F5 = string.Empty;
            var F6 = string.Empty;
            var F7 = string.Empty;
            var F8 = string.Empty;
            var F9 = string.Empty;
            int P10;
            int P11;
            var besta = string.Empty;
            var baret = string.Empty;

            int P50;
            int P51;
            int P40;
            int P41;
            int P31;
            var braso = string.Empty;
            var bcond = string.Empty;
            int P70;
            int P71;
            int P21;
            int P20;
            var btele = string.Empty;
            var btipo = string.Empty;
            var bfena = string.Empty;
            var bndni = string.Empty;
            var bdire = string.Empty;
            int p90;
            int p30;
            int P60;
            int P61;
            int p80;
            int p81;
            int p91;

            if ((oHTTP.Trim().Length > 0))
            {
                p1 = rucc;
                F1 = " <br/></small>";
                p2 = "Estado.";
                F2 = "Agente";
                p3 = "Situaci";
                F3 = "Tel";
                p4 = "Direcci";
                F4 = "Situaci";
                p5 = "Retenci";
                F5 = "Nombre";
                p6 = "Tipo";
                F6 = "DNI";
                p7 = "Nacimiento.";
                F7 = "Act.";
                p8 = "DNI";
                F8 = "Nacimiento.";
                p9 = "fono(s).";
                F9 = "Dependencia.";
                if (((oHTTP.IndexOf("El numero Ruc ingresado es inv") + 1) > 0))
                {
                    MessageBox.Show(oHTTP, "Error en búsqueda de Ruc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtmnruc.Focus();
                }
                else
                {
                    string pvalornombreComercial;
                    var pglosanombreComercial = "Comercial.</b><br/>";
                    pvalornombreComercial = oHTTP.Substring(((oHTTP.IndexOf(pglosanombreComercial) + 1) + 18));
                    P10 = (oHTTP.IndexOf(p1) + 1);
                    P11 = (oHTTP.IndexOf(F1) + 1);
                    braso = oHTTP.Substring((P10 + 13), ((P11 - P10) - 14));
                    P20 = (oHTTP.IndexOf(p2) + 1);
                    P21 = (oHTTP.IndexOf(F2) + 1);
                    besta = oHTTP.Substring((P20 + 10), ((P21 - P20) - 53));
                    p30 = (oHTTP.IndexOf(p3) + 1);
                    P31 = (oHTTP.IndexOf(F3) + 1);
                    bcond = oHTTP.Substring((p30 + 18), ((P31 - p30) - 54));
                    P40 = (oHTTP.IndexOf(p4) + 1);
                    P41 = (oHTTP.IndexOf(F4) + 1);
                    bdire = oHTTP.Substring((P40 + 23), ((P41 - P40) - 52));
                    P50 = (oHTTP.IndexOf(p5) + 1);
                    P51 = (oHTTP.IndexOf(F5) + 1);
                    baret = oHTTP.Substring((P50 + 57), ((P51 - P50) - 110));
                    if ((rucc.Substring(0, 1) == "1"))
                    {
                        P60 = (oHTTP.IndexOf(p6) + 1);
                        P61 = (oHTTP.IndexOf(F6) + 1);
                        btipo = oHTTP.Substring((P60 + 14), ((P61 - P60) - 66));
                        P70 = (oHTTP.IndexOf(p7) + 1);
                        P71 = (oHTTP.IndexOf(F7) + 1);
                        bfena = oHTTP.Substring((P70 + 15), ((P71 - P70) - 74));
                        p80 = (oHTTP.IndexOf(p8) + 1);
                        p81 = (oHTTP.IndexOf(F8) + 1);
                        bndni = oHTTP.Substring((p80 + 9), ((p81 - p80) - 52));
                    }
                    else
                    {
                        btipo = "PERSONA JURIDICA";
                        bfena = string.Empty;
                        bndni = string.Empty;
                    }
                    p90 = (oHTTP.IndexOf(p9) + 1);
                    p91 = (oHTTP.IndexOf(F9) + 1);
                    btele = oHTTP.Substring((p90 + 16), ((p91 - p90) - 46));
                    rbjuridica.Checked = btipo == "PERSONA JURIDICA";
                    rbnatural.Checked = !rbjuridica.Checked;
                    cboTipdoc.SelectedValue = "6";
                    if ((bndni.Trim().Length > 0))
                    {
                        txtapepat.Text = VariablesPublicas.Palabras(braso, 1);
                        txtapemat.Text = VariablesPublicas.Palabras(braso, 2);
                        txtnombres.Text = (VariablesPublicas.Palabras(braso, 3) + (", " + VariablesPublicas.Palabras(braso, 4)));
                    }
                    else
                    {
                        txtapemat.Text = string.Empty;
                        txtapepat.Text = string.Empty;
                        txtnombres.Text = string.Empty;
                    }
                    txtmnruc.Text = rucc;
                    txtrazonsocial.Text = braso;
                    txtdireccion.Text = bdire;
                    lblDireccion.Text = bdire;
                    rbactivo.Checked = besta.Substring(0, 6) == "ACTIVO";
                    rbbaja.Checked = !rbactivo.Checked;
                    chkretencion.Checked = ((baret == "NO") ? false : true);
                    txttelefono1.Text = ((btele == "-</") ? string.Empty : btele);
                    txtpaisid.Text = "9589";
                    txtpaisname.Text = "PERÚ";
                    txtCondicion.Text = bcond;
                }
            }
        }



        private void u_CargaBancos()
        {
            var xcodcliente = txtcodigo.Text;
            try
            {
                var BL = new cliente_bancoBL();
                var BE = new tb_cliente_banco();

                BE.ctacte = xcodcliente;
                TablaBancos = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                gridBancos.AutoGenerateColumns = false;
                gridBancos.DataSource = TablaBancos;
                txtCodigob.Text = string.Empty;
                txtRucb.Text = string.Empty;
                txtCtactenameb.Text = string.Empty;
                if ((u_n_opsel == 0))
                {
                    if (!(GridExaminar.CurrentRow == null))
                    {
                        txtCodigob.Text = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["ctacte"].Value.ToString();
                        txtRucb.Text = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["nmruc"].Value.ToString();
                        txtCtactenameb.Text = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["ctactename"].Value.ToString();
                    }
                }
                else
                {
                    txtCodigob.Text = txtcodigo.Text;
                    txtRucb.Text = txtmnruc.Text;
                    txtCtactenameb.Text = txtrazonsocial.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            TablaBancos.Rows.Add(VariablesPublicas.InsertIntoTable(TablaBancos));
            gridBancos.Refresh();
            gridBancos.CurrentCell = gridBancos.Rows[gridBancos.Rows.Count - 1].Cells["bancoid"];
            gridBancos.BeginEdit(true);
            TablaBancos.AcceptChanges();
            U_RefrescaControles();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if ((TablaBancos.Rows.Count > 0))
            {
                gridBancos.Rows.Remove(gridBancos.CurrentRow);
                TablaBancos.AcceptChanges();
                gridBancos.Refresh();
                U_RefrescaControles();
            }
        }
        private void gridBancos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if ((gridBancos.Columns[gridBancos.CurrentCell.ColumnIndex].Name.ToUpper() == "bancoid".ToUpper()))
            {
                j_CodBanco = gridBancos.CurrentCell.Value.ToString();
            }
        }
        private void gridBancos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if ((gridBancos.Columns[gridBancos.CurrentCell.ColumnIndex].Name.ToUpper() == "bancoid".ToUpper()))
            {
                txtCArti = ((TextBox)(e.Control));
                txtCArti.MaxLength = 2;
                txtCArti.CharacterCasing = CharacterCasing.Normal;
                txtCArti.Text.Trim();
                e.Control.KeyDown += VariablesPublicas.CapturarTeclaGRID;
            }
            _NameColumn = gridBancos.Columns[gridBancos.CurrentCell.ColumnIndex].Name.ToUpper();
        }
        private void gridBancos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if ((_NameColumn.Length > 0))
            {
                switch (_NameColumn)
                {
                    case "bancoid":
                        if (VariablesPublicas.PulsaAyudaArticulos)
                        {
                            txtCArti = null;
                            AyudaBancos();
                        }
                        break;
                }
            }
            _NameColumn = string.Empty;
        }
        private void gridBancos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!Sw_LOad)
            {
                if (!(gridBancos.CurrentRow == null))
                {
                    sw_novaluechange = true;
                    if ((gridBancos.Columns[e.ColumnIndex].Name.ToUpper() == "bancoid".ToUpper()))
                    {
                        ValidaBancos();
                    }
                    sw_novaluechange = false;
                }
            }
        }
        private void gridBancos_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
            }
            if (((e.KeyCode == Keys.F1) && (u_n_opsel > 0)))
            {
                if (!(gridBancos.CurrentCell == null))
                {
                    if ((gridBancos.CurrentCell.ReadOnly == false))
                    {
                        if ((gridBancos.Columns[gridBancos.CurrentCell.ColumnIndex].Name.ToUpper() == "bancoid".ToUpper()))
                        {
                            AyudaBancos();
                        }
                    }
                }
            }
        }
        private void gridBancos_SelectionChanged(object sender, EventArgs e)
        {
            if (!(gridBancos.CurrentCell == null))
            {
                if ((gridBancos.Columns[gridBancos.CurrentCell.ColumnIndex].Name.ToUpper() == "bancoid".ToUpper()))
                {
                    ValidaBancos();
                }

                cboBancoID.SelectedValue = gridBancos.Rows[gridBancos.CurrentRow.Index].Cells["bancoid"].Value.ToString();
                txtctactesoles.Text = gridBancos.Rows[gridBancos.CurrentRow.Index].Cells["ctactemn"].Value.ToString();
                txtctactedolares.Text = gridBancos.Rows[gridBancos.CurrentRow.Index].Cells["ctacteme"].Value.ToString();
            }
            U_RefrescaControles();
        }

        internal void AyudaBancos()
        {
            var frmayuda = new Ayudas.Frm_help_general();

            frmayuda.tipoo = "sql";
            frmayuda.titulo = "Ayuda Bancos";
            frmayuda.sqlquery = "select codigoid, descripcion from tb_co_tabla03_banco";
            frmayuda.sqlinner = string.Empty;
            frmayuda.sqlwhere = "where";
            frmayuda.sqland = string.Empty;
            frmayuda.criteriosbusqueda = new string[] { "BANCO", "CODIGO" };
            frmayuda.columbusqueda = "descripcion,codigoid";
            frmayuda.returndatos = "0,1";

            frmayuda.Owner = this;
            frmayuda.PasaProveedor = RecibeBancos;
            frmayuda.ShowDialog();
        }
        internal void RecibeBancos(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                sw_novaluechange = true;
                gridBancos.Rows[gridBancos.CurrentRow.Index].Cells["bancoid"].Value = resultado1;
                gridBancos.Rows[gridBancos.CurrentRow.Index].Cells["banconame"].Value = resultado2;
                sw_novaluechange = false;
            }
        }
        internal void ValidaBancos()
        {
            Int16 lc_cont;
            var zhallado = false;

            var VMNROITEM = gridBancos.Rows[gridBancos.CurrentRow.Index].Cells["bancoid"].Value.ToString();
            var xcodartic = "..";
            if (!(gridBancos.Rows[gridBancos.CurrentRow.Index].Cells["bancoid"].Value == DBNull.Value))
            {
                xcodartic = gridBancos.Rows[gridBancos.CurrentRow.Index].Cells["bancoid"].Value.ToString();
            }
            if (xcodartic.Trim().Length == 0)
            {
                zhallado = true;
            }
            else
            {
                var BL = new tb_co_tabla03_bancoBL();
                var BE = new tb_co_tabla03_banco();

                BE.codigoid = xcodartic;
                tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                for (lc_cont = 0; lc_cont < TablaBancos.Rows.Count; lc_cont++)
                {
                    if (TablaBancos.Rows[lc_cont]["bancoid"].ToString() == VMNROITEM)
                    {
                        if (tmptabla.Rows.Count > 0)
                        {
                            TablaBancos.Rows[lc_cont]["bancoid"] = tmptabla.Rows[0]["codigoid"];
                            TablaBancos.Rows[lc_cont]["banconame"] = tmptabla.Rows[0]["descripcion"];
                            zhallado = true;
                            break;
                        }
                    }
                }
            }
            if (!zhallado)
            {
                gridBancos.Rows[gridBancos.CurrentRow.Index].Cells["bancoid"].Value = j_CodBanco;
            }
            gridBancos.Refresh();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
        }

        private void cboTipdoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboTipdoc.SelectedIndex != -1)
            //{
            //    if (cboTipdoc.SelectedValue.ToString() == "1")
            //    {
            //        blanquear();
            //        btnextraersunat.Enabled = true;
            //    }
            //    else
            //    {
            //        if (cboTipdoc.SelectedValue.ToString() == "6")
            //        {
            //            blanquear();
            //            btnextraersunat.Enabled = true;
            //        }
            //        else
            //        {
            //            blanquear();
            //            btnextraersunat.Enabled = false;
            //        }
            //    }
            //}
            string xTipDoc = "...";
            if (cboTipdoc.SelectedValue != null)
            {
                xTipDoc = cboTipdoc.SelectedValue.ToString();
            }
            if (xTipDoc == "1")
            {
                //organo.Text = "Reniec";
                rbnatural.Checked = true;
                //btnextraersunat.Visible = false;
                //btnReniec.Visible = true;
                //groupBox7.Visible = true;
                //txtCapcha.Text = "";
                //CargarImagen();
                //pictureCapcha.Visible = true;
                //ImagenSunat.Visible = false;
            }
            else if (xTipDoc == "6")
            {
                //organo.Text = "Sunat";
                btnextraersunat.Visible = true;
                //btnReniec.Visible = false;
                //groupBox7.Visible = true;
                //pictureCapcha.Visible = false;
                //ImagenSunat.Visible = true;
                //txtCapcha.Text = "";
                CargarImagen();
            }
            else
            {
                //organo.Text = "";
                //btnextraersunat.Visible = false;
                //btnReniec.Visible = false;
                //groupBox7.Visible = false;
                //pictureCapcha.Visible = false;
                //ImagenSunat.Visible = false;
            }
            txtCapcha.Text = (xTipDoc == "1" ? j_capcha : "");
        }

        private void Fmr_ReniecNombres(String lpdescrlike)
        {
            try
            {
                var frmreniec = new MERCADERIA.POPUP.Frm_reniec();
                frmreniec.dni = txtmnruc.Text.ToString();
                frmreniec.PasaDni = RecibeReniec;
                frmreniec.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }

        private void RecibeReniec(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                txtapepat.Text = resultado2.Trim();
                txtapemat.Text = resultado3.Trim();
                txtnombres.Text = resultado4.Trim();
            }
        }

        private void Fmr_SunatNombres(String lpdescrlike)
        {
            try
            {
                var frmsunat = new MERCADERIA.POPUP.Frm_sunat();
                frmsunat.Ruc  = txtmnruc.Text.ToString();
                frmsunat.PasaRuc = RecibeSunat;
                frmsunat.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }

        private void RecibeSunat(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5, String resultado6, String resultado7, String resultado8, String resultado9, String resultad10)
        {
            if (resultado1.Trim().Length > 0)
            {
                txtrazonsocial.Text = resultado2.Trim();
                txtdireccion.Text = resultado3.Trim();
                txtnombres.Text = resultado4.Trim();
            }
        }

        private void txtmnruc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnextraersunat_Click(sender, e);
            }
        }

        private void GridExaminar_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            GridExaminar[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            GridExaminar[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            GridExaminar.EnableHeadersVisualStyles = false;
            GridExaminar.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            GridExaminar.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void GridExaminar_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            GridExaminar[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }

        private void gridAnexos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //gridAnexos[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            //gridAnexos[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            //gridAnexos.EnableHeadersVisualStyles = false;
            //gridAnexos.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            //gridAnexos.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void gridAnexos_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //gridAnexos[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }

        private void gridBancos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridBancos[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            gridBancos[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            gridBancos.EnableHeadersVisualStyles = false;
            gridBancos.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            gridBancos.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void gridBancos_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            gridBancos[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }

        private void cmdReloadCapcha_Click(object sender, EventArgs e)
        {
            try
            {
                var xTipDoc = "...";
                if (cboTipdoc.SelectedValue != null)
                {
                    xTipDoc = cboTipdoc.SelectedValue.ToString();
                }
                if (xTipDoc == "1")
                {
                    CargarImagen();
                    txtCapcha.Text = string.Empty;
                    txtCapcha.Focus();
                    txtCapcha.SelectAll();
                }
                if (xTipDoc == "6")
                {
                    CargarImagen();
                    txtCapcha.Text = string.Empty;
                    txtCapcha.Focus();
                    txtCapcha.SelectAll();
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }
        private void CargarImagen()
        {
            if (VariablesPublicas.compruebaConexion() == true)
            {
                try
                {
                    var xTipDoc = "...";
                    if (cboTipdoc.SelectedValue != null)
                    {
                        xTipDoc = cboTipdoc.SelectedValue.ToString();
                    }
                    if (xTipDoc == "1")
                    {
                    }
                    if (xTipDoc == "6")
                    {
                        myInfoSunat = new DatoSUNAT();
                        ImagenSunat.Image = myInfoSunat.GetCapchaSunat;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
    //                    throw ex;
                }
            }
            else
            {
                lblDireccion.Text = "Sin conexión a Internet";
            }
        }

        private void label28_Click(object sender, EventArgs e)
        {
        }

        private void txtCapcha_TextChanged(object sender, EventArgs e)
        {
        }

        private void ImagenSunat_Click(object sender, EventArgs e)
        {
        }

        private void txtcanalvtaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaCanalVenta("");
            }
        }

        private void AyudaCanalVenta(String lpdescrlike)
        {
            try
            {
                Ayudas.Frm_help_general frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all"; //sql,tabla
                frmayuda.titulo = "<< AYUDA TABLA CANAL VENTA >>";
                frmayuda.sqlquery = "SELECT canalventaid,canalventaname FROM tb_cp_canalventa ";
                frmayuda.sqlinner = ""; //inner
                frmayuda.sqlwhere = "WHERE LEN(canalventaid) = 3"; //where
                frmayuda.sqland = "and";//and
                frmayuda.criteriosbusqueda = new string[] { "CODIGO", "CANAL" };
                frmayuda.columbusqueda = "canalventaid,canalventaname";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeCanalVenta;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void RecibeCanalVenta(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                txtcanalvtaid.Text = resultado1.Trim();
                txtcanalvtaname.Text = resultado2.Trim();
                //data_Tablamodulo();
            }
        }

        private void gridAnexos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridAnexos.CurrentRow != null)
                {
                    txt_ordenid.Text = gridAnexos.Rows[e.RowIndex].Cells["direcnume"].Value.ToString().Trim();                         
                    txt_denominacion.Text = gridAnexos.Rows[e.RowIndex].Cells["direcname"].Value.ToString().Trim();
                    txt_direccion.Text = gridAnexos.Rows[e.RowIndex].Cells["direcdeta"].Value.ToString().Trim();
                    txt_telefono.Text = gridAnexos.Rows[e.RowIndex].Cells["telef"].Value.ToString().Trim();
                    txt_ubigeoid.Text = gridAnexos.Rows[e.RowIndex].Cells["ubige"].Value.ToString().Trim();

                    btn_edit.Enabled = true;
                    btn_delete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridAnexos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                txt_ordenid.Text = gridAnexos.Rows[gridAnexos.CurrentRow.Index].Cells["direcnume"].Value.ToString().Trim();
                txt_denominacion.Text = gridAnexos.Rows[gridAnexos.CurrentRow.Index].Cells["direcname"].Value.ToString().Trim();
                txt_direccion.Text = gridAnexos.Rows[gridAnexos.CurrentRow.Index].Cells["direcdeta"].Value.ToString().Trim();
                txt_telefono.Text = gridAnexos.Rows[gridAnexos.CurrentRow.Index].Cells["telef"].Value.ToString().Trim();
                txt_ubigeoid.Text = gridAnexos.Rows[gridAnexos.CurrentRow.Index].Cells["ubige"].Value.ToString().Trim();
                btn_edit.Enabled = true;
                btn_delete.Enabled = true;
            }
        }

        void LimpiarDatosDirecc()
        {
            txt_ordenid.Text = "";
            txt_denominacion.Text = "";
            txt_direccion.Text = "";
            txt_telefono.Text = "";
            txt_ubigeoid.Text = "";
            txt_ubigeoname.Text = "";
            txt_denominacion.Focus();
        }

        void BloqueoDirecc(bool var)
        {
            txt_ordenid.Enabled = false;
            txt_denominacion.Enabled = var;
            txt_direccion.Enabled = var;
            txt_telefono.Enabled = var;
            txt_ubigeoid.Enabled = var;
            txt_ubigeoname.Enabled = false;


            btn_new.Enabled = var;
            btn_edit.Enabled = var;
            btn_save.Enabled = var;
            btn_cancel.Enabled = var;
            btn_delete.Enabled = var;            
        }
    


        private void btn_new_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcoddetalle.Text.Length > 0)
                {
                    BloqueoDirecc(true);
                    LimpiarDatosDirecc();                    
                    // Vamos Generar El nuevo Codigo de direcciones de Acuerdo a la ctacte
                    tb_cliente_direc BE = new tb_cliente_direc();
                    cliente_direcBL BL = new cliente_direcBL();
                    DataTable dt = new DataTable();
                    BE.ctacte = txtcoddetalle.Text;
                    dt = BL.Gen_NumDirecc(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        txt_ordenid.Text = dt.Rows[0]["direcnume"].ToString();
                    }

                    ssModo = "NEW";
                    gridAnexos.Enabled = false;
                    btn_new.Enabled = false;
                    btn_edit.Enabled = false;                         
                    btn_delete.Enabled = false;
                }
                else {
                    MessageBox.Show("Falta Codigo de Cliente ...!!!","Mensaje");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (txt_ordenid.Text.Length > 0 && txt_ordenid.Text.Length == 3)
            {
                BloqueoDirecc(true);
                btn_delete.Enabled = false;
                btn_new.Enabled = false;
                btn_edit.Enabled = false;
                gridAnexos.Enabled = false;
                ssModo = "EDI";
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            procesado = false;
            var sw_prosigue = false;
            if (ssModo == "NEW")
            {                
              InsertDirecc();                
            }
            else
            {               
                sw_prosigue = (MessageBox.Show("¿Desea Modificar la Dirección ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
                if (sw_prosigue)
                {
                    UpdateDirecc();
                }
                
            }
            if (procesado)
            {
                //Cargar Direcciones
                BloqueoDirecc(false);
                btn_new.Enabled = true;
                gridAnexos.Enabled = true;
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var sw_prosigue = false;
            sw_prosigue = (MessageBox.Show("¿Desea Eliminar Dirección ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

            if (sw_prosigue)
            {
                DeleteDirecc();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_new.Enabled == false)
            {
                BloqueoDirecc(false);
                LimpiarDatosDirecc();              
                gridAnexos.Enabled = true;
                btn_new.Enabled = true;
            }
        }


        void InsertDirecc()
        {
            try
            {
                var BL = new cliente_direcBL();
                var BE = new tb_cliente_direc();

                BE.ctacte = txtcoddetalle.Text.Trim();
                BE.direcnume = txt_ordenid.Text;
                BE.direcname = txt_denominacion.Text.ToUpper();
                BE.direcdeta = txt_direccion.Text.ToUpper();
                BE.telef = txt_telefono.Text;
                BE.ubige = txt_ubigeoid.Text;
                BE.usuar = VariablesPublicas.Usuar.ToUpper().Trim();
                BE.status = "0";

                String xxMessage = "";
                
                if (BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE))
                {
                    xxMessage = "1";
                    // Verificamos en el DBF Si Existe La misma direccion
                    if (SearchCodDbf() > 0)
                    {
                        if (UpdateDirecc_DBF())
                        {
                            xxMessage = xxMessage + " / 2";
                        }
                    }
                    else
                    {
                        if (InsertDirecc_DBF())
                        {
                            xxMessage = xxMessage + " / 2";
                        }
                    }
                    MessageBox.Show("Datos  " + xxMessage + " Grabados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    procesado = true;                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Int32 SearchCodDbf()
        {
            Int32 num = 0;
            cliente_direcBL BL = new cliente_direcBL();
            tb_cliente_direc BE = new tb_cliente_direc();
            DataTable dt = new DataTable();
            BE.ctacte = Equivalencias.Right(txtcoddetalle.Text.Trim(),4);
            BE.direcnume = Equivalencias.Right(txt_ordenid.Text, 2);
            dt = BL.GetAll_CODdbf(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                num = dt.Rows.Count;
            }
            return num;
        }

        void UpdateDirecc()
        {
            try
            {
                var BL = new cliente_direcBL();
                var BE = new tb_cliente_direc();

                BE.ctacte = txtcoddetalle.Text.Trim();
                BE.direcnume = txt_ordenid.Text;
                BE.direcname = txt_denominacion.Text.ToUpper();
                BE.direcdeta = txt_direccion.Text.ToUpper();
                BE.telef = txt_telefono.Text;
                BE.ubige = txt_ubigeoid.Text;
                BE.usuar = VariablesPublicas.Usuar.ToUpper().Trim();
                BE.status = "0";

                String xxMessage = "";

                if (BL.Update(VariablesPublicas.EmpresaID.ToString(), BE))
                {
                    xxMessage = "1";
                    // Verificamos en el DBF Si Existe La misma direccion
                    if (SearchCodDbf() > 0)
                    {
                        if (UpdateDirecc_DBF())
                        {
                            xxMessage = xxMessage + " / 2";
                        }
                    }
                    else
                    {
                        if (InsertDirecc_DBF())
                        {
                            xxMessage = xxMessage + " / 2";
                        }
                    }
                    MessageBox.Show("Datos  " + xxMessage + " Modificado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    procesado = true;   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void DeleteDirecc()
        {
            try
            {
                if (txtcoddetalle.Text.Trim().Length != 7)
                {
                    MessageBox.Show("Ingrese Código de Cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txt_ordenid.Text.Trim().Length != 3)
                {
                    MessageBox.Show("Ingrese Código Dirección", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var BL = new cliente_direcBL();
                    var BE = new tb_cliente_direc();

                    BE.ctacte = txtcoddetalle.Text.Trim();
                    BE.direcnume = txt_ordenid.Text;
                    BE.usuar = VariablesPublicas.Usuar.ToUpper().Trim();

                    String xxMessage = "";

                    if (BL.Delete(VariablesPublicas.EmpresaID.ToString(), BE))
                    {
                        xxMessage = "1";                      
                        if (DeleteDirecc_DBF())
                        {
                            xxMessage = xxMessage + " / 2";
                        }
                        
                        MessageBox.Show("Datos  " + xxMessage + " Eliminado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        procesado = true;   
                                                                                                
                        LimpiarDatosDirecc();
                        BloqueoDirecc(false);
                        btn_new.Enabled = true;                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }





    }
}
