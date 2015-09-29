using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.D60ALMACEN.POPUP
{
    public partial class Frm_CargaRollo : Form
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;

        public delegate void PasaRollosDelegate(DataTable dtresultado);
        public PasaRollosDelegate PasaRollos;
        private DataTable Tabladet;
        private DataTable Data;
        private DataRow row;

        public Frm_CargaRollo()
        {
            InitializeComponent();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            var BL = new tb_ta_prodrolloBL();
            var BE = new tb_ta_prodrollo();
            try
            {
                if (rollodesde.Text.Trim().Length > 0)
                {
                    BE.rollodesde = rollodesde.Text.Trim().PadLeft(10, '0');
                }

                if (rollohasta.Text.Trim().Length > 0)
                {
                    BE.rollohasta = rollohasta.Text.Trim().PadLeft(10, '0');
                }

                if (chkActivar.Checked)
                {
                    if (precio.Text == string.Empty)
                    {
                        MessageBox.Show("Ingrese Precio !!!");
                        return;
                    }
                }


                Data = BL.GetAll_prod(EmpresaID, BE).Tables[0];

                if (Data.Rows.Count > 0)
                {
                    for (var i = 0; i < Data.Rows.Count; i++)
                    {
                        row = Tabladet.NewRow();
                        row["productid"] = Data.Rows[i]["productid"].ToString();
                        row["productname"] = Data.Rows[i]["productname"].ToString();
                        row["rollo"] = Data.Rows[i]["rollo"].ToString();
                        if (chkActivar.Checked)
                        {
                            row["precio"] = Convert.ToDecimal(precio.Text);
                        }
                        row["check"] = Convert.ToBoolean(chkActivar.Checked);

                        Tabladet.Rows.Add(row);
                    }

                    PasaRollos(Tabladet);
                }
            }
            catch (Exception)
            {
            }

            Close();
        }

        private void Frm_CargaRollo_Load(object sender, EventArgs e)
        {
            Tabladet = new DataTable("Rollos");

            Tabladet.Columns.Add("productid", typeof(String));
            Tabladet.Columns.Add("productname", typeof(String));
            Tabladet.Columns.Add("rollo", typeof(String));
            Tabladet.Columns.Add("precio", typeof(Decimal));
            Tabladet.Columns.Add("check", typeof(Boolean));

            limpiar_documento();
            precio.Enabled = false;
        }

        private void limpiar_documento()
        {
            rollodesde.Text = string.Empty;
            rollohasta.Text = string.Empty;
            precio.Text = string.Empty;
            rollodesde.Focus();
        }

        private void rollodesde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rollohasta.Focus();
            }
        }

        private void rollohasta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                precio.Focus();
            }
        }

        private void precio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnAgregar_Click(sender, e);
            }
        }

        private void chkActivar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActivar.Checked)
            {
                precio.Enabled = true;
                precio.Focus();
            }
            else
            {
                precio.Enabled = false;
            }
        }
    }
}
