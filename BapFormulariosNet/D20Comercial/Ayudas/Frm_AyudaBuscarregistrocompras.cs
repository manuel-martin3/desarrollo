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
using DevExpress.XtraEditors;

namespace BapFormulariosNet.D20Comercial.Ayudas
{
    public partial class Frm_AyudaBuscarregistrocompras : plantilla
    {
        bool sw_load = true;
        string j_String = "";
        //string j_codtipdocu = "";
        public string _diario = "";
        //int u_n_Opsel = 0;
        DataTable tmptabla = new DataTable();
        public delegate void PasaRegCOMPRAS(string mes, string diario, string registro);
        public PasaRegCOMPRAS _PasaRegCOMPRAS;
 
        public Frm_AyudaBuscarregistrocompras()
        {
            InitializeComponent();
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            //DevExpress.Skins.SkinManager.EnableFormSkins();

            txtRuc.LostFocus += new System.EventHandler(txtRuc_LostFocus);
            txtRuc.GotFocus += new System.EventHandler(txtRuc_GotFocus);

            txtSerie.LostFocus += new System.EventHandler(txtSerie_LostFocus);
            txtNumero.LostFocus += new System.EventHandler(txtNumero_LostFocus);

            llenar_cboTipdocs();
        }

        private void Frm_AyudaBuscarregistrocompras_Activated(object sender, EventArgs e)
        {
            if (sw_load)
            {
                //RequeryDocumentos();
                sw_load = false;
                refrescacontroles();
            }
        }
        private void Frm_AyudaBuscarregistrocompras_Load(object sender, EventArgs e)
        {
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            //DevExpress.Skins.SkinManager.EnableFormSkins();
        }

        private void AyudaProveedor()
        {
            Frm_AyudaProveedor frmayuda = new Frm_AyudaProveedor();
            frmayuda._Valores = "<< Ayuda Proveedores >>";
            frmayuda.Owner = this;
            frmayuda.PasaProveedor = RecibeProveedor;
            frmayuda.ShowDialog();
        }
        private void RecibeProveedor(string xruc, string xnombre, string xdirec)
        {
            if (xruc.Trim().Length > 0)
            {
                txtRuc.Text = xruc;
                ValidaProveedor();
            }
        }
        private void ValidaProveedor()
        {
            if (txtRuc.Text.Trim().Length > 0)
            {
                clienteBL BL = new clienteBL();
                tb_cliente BE = new tb_cliente();

                BE.nmruc = txtRuc.Text;
                DataTable tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                if ((tmptabla.Rows.Count == 0))
                {
                    txtRuc.Text = j_String;
                }
                else
                {
                    txtRuc.Text = tmptabla.Rows[0]["nmruc"].ToString();
                    txtCtactename.Text = tmptabla.Rows[0]["ctactename"].ToString();
                }
            }
            else
            {
                txtRuc.Text = j_String;
            }
        }

        private void refrescacontroles()
        {
            txtRuc.Enabled = true;
            cboTipdoc.SelectedValue = "01";
            txtSerie.Focus();
        }

        void llenar_cboTipdocs()
        {
            try
            {
                cboTipdoc.DataSource = NewMethodDoc();
                cboTipdoc.DisplayMember = "Value";
                cboTipdoc.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethodDoc()
        {
            tb_co_tabla10_comprobantesBL BL = new tb_co_tabla10_comprobantesBL();
            tb_co_tabla10_comprobantes BE = new tb_co_tabla10_comprobantes();

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

        private void txtRuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaProveedor();
            }
        }
        private void txtRuc_LostFocus(object sender, System.EventArgs e)
        {
            if (!sw_load)
            {
                if (!(j_String == txtRuc.Text))
                {
                    ValidaProveedor();
                }
            }
        }
        private void txtRuc_GotFocus(object sender, System.EventArgs e)
        {
            if (!sw_load)
            {
                j_String = txtRuc.Text;
            }
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            //  Si el control tiene el foco...
            if (btnAceptar.Focused)
            {

            }
            else if (btnCancelar.Focused)
            {

            }
            else if (keyData == Keys.Enter)
            {
                SendKeys.Send("\t");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtSerie_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("\t");
            }
        }
        private void txtSerie_LostFocus(object sender, System.EventArgs e)
        {
            if (!sw_load)
            {
                if (txtSerie.Text.Trim().Length > 0)
                {
                    txtSerie.Text = VariablesPublicas.PADL(txtSerie.Text, 4, "0");
                }
            }
        }
        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("\t");
            }
        }
        private void txtNumero_LostFocus(object sender, System.EventArgs e)
        {
            if (!sw_load)
            {
                if ((txtNumero.Text.Trim().Length > 0))
                {
                    txtNumero.Text = VariablesPublicas.PADL(txtNumero.Text.Trim(), 10, "0");
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            tb_co_ComprascabBL BL = new tb_co_ComprascabBL();
            tb_co_Comprascab BE = new tb_co_Comprascab();

            BE.perianio = VariablesPublicas.perianio;
            BE.nmruc = txtRuc.Text;
            BE.tipodoc = cboTipdoc.SelectedValue.ToString();
            BE.serdoc = txtSerie.Text;
            BE.numdoc = txtNumero.Text;

            tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            //tmptabla = ocapa.KAG0300_consulta(GlobalVars.GetInstance.Company, GlobalVars.GetInstance.Periodo, "", "", "", "", TXTCODCLIENTE.Text, cmbtipdoc.SelectedValue, txtserie.Text, txtnumero.Text);
            //if ((ocapa.sql_error.Length == 0))
            //{
                if (tmptabla.Rows.Count > 0)
                {
                    _PasaRegCOMPRAS(tmptabla.Rows[0]["perimes"].ToString(), 
                                         tmptabla.Rows[0]["diarioid"].ToString(), 
                                         tmptabla.Rows[0]["asiento"].ToString());
                    Close();
                }
            //}
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }       
    }
}
