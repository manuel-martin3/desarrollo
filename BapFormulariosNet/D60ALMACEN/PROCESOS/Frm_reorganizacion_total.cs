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

namespace BapFormulariosNet.D60ALMACEN.PROCESOS
{
    public partial class Frm_reorganizacion_total : plantilla
    {
        private Genericas fungen = new Genericas();

        private String EmpresaID = string.Empty;
        private String dominio = string.Empty;
        private String modulo = string.Empty;
        private String local = string.Empty;
        private String perianio = string.Empty;
        private String perimes = string.Empty;

        private class Item
        {
            public string Name { get; set; }
            public int Value { get; set; }

            public Item(string name, int value)
            {
                Name = name;
                Value = value;
            }
            public override string ToString()
            {
                return Name;
            }
        }
        
        public Frm_reorganizacion_total()
        {
            InitializeComponent();
        }

        private void Frm_reorganizacion_total_Load(object sender, EventArgs e)
        {
            EmpresaID = VariablesPublicas.EmpresaID.Trim();
            dominio = ((D60ALMACEN.MainAlmacen)MdiParent).dominioid;
            modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
            local = ((D60ALMACEN.MainAlmacen)MdiParent).local;

            fill_cboModuloid();
            fill_cboPerianio();

            cboLocal.SelectedValue = local;
        }

        private void fill_cboModuloid()
        {
            var BL = new sys_dominioBL();
            try
            {
                cboModuloid.DataSource = BL.GetAllDominioModuloPorUsuario(VariablesPublicas.EmpresaID, VariablesPublicas.Usuar, "60").Tables[0];
                cboModuloid.ValueMember = "moduloid";
                cboModuloid.DisplayMember = "moduloname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cboModuloid.SelectedValue = modulo;

            if (cboModuloid.Items.Count > 0)
            {
                fill_cbolocal(dominio, cboModuloid.SelectedValue.ToString());
            }
        }
        private void fill_cbolocal(string dominioid, string moduloid)
        {
            var BL = new usuariomodulolocalBL();
            var BE = new tb_usuariomodulolocal();
            BE.usuar = VariablesPublicas.Usuar.Trim();
            var dt = new DataTable();
            BE.dominioid = dominioid;
            BE.moduloid = moduloid;

            try
            {
                dt = BL.GetAll3(VariablesPublicas.EmpresaID, BE).Tables[0];
                cboLocal.DataSource = dt;
                cboLocal.ValueMember = "local";
                cboLocal.DisplayMember = "localname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void fill_cboPerianio()
        {
            int nMinAnio = DateTime.Today.Year - 10;
            int nMaxAnio = DateTime.Today.Year;
            string cAnio = string.Empty;

            List<Item> lista = new List<Item>();
            for (int i = nMinAnio; i <= nMaxAnio; i++)
            {
                cAnio = Convert.ToString(i);
                lista.Add(new Item(cAnio, i));
            }

            cboPerianio.DataSource = lista;
            cboPerianio.DisplayMember = "Name";
            cboPerianio.ValueMember = "Value";

            cboPerianio.SelectedValue = DateTime.Today.Year;
        }

        private void cboLocal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnReorganizar_Click(object sender, EventArgs e)
        {
            fech_ini.Text = DateTime.Now.ToLongTimeString();

            var BL = new tb_60local_stockBL();
            var BE = new tb_60local_stock();

            BE.moduloid = cboModuloid.SelectedValue.ToString();
            BE.local = cboLocal.SelectedValue.ToString();
            BE.perianio = cboPerianio.SelectedValue.ToString();
            BE.grabacp = "S";
            BE.desdehistorico = chkDesdeHistorico.Checked;
            try
            {
                if (BL.ReorgTotal(VariablesPublicas.EmpresaID.ToString(), BE))
                {
                    fech_fin.Text = DateTime.Now.ToLongTimeString();
                    MessageBox.Show("Proceso terminado Correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Contactese con Sistema !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkSelecAnio_CheckedChanged(object sender, EventArgs e)
        {
            cboPerianio.Enabled = chkSelecAnio.Checked;
        }



    }
}
