using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.D60ALMACEN.PROCESOS
{
    public partial class Frm_Reorg_CostUlt : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;
        private List<tb_perianio> lista = null;
        private String ssModo = "NEW";

        private Genericas fungen = new Genericas();

        public Frm_Reorg_CostUlt()
        {
            InitializeComponent();
        }

        private void form_bloqueado(Boolean var)
        {
            try
            {
                moduloiddes.Enabled = false;
                localdes.Enabled = var;
                cboanio.Enabled = var;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void form_accion_cancelEdicion(int confirnar)
        {
            var sw_prosigue = true;
            if (confirnar == 1)
            {
                sw_prosigue = (MessageBox.Show("Desea cancelar ingreso de datos...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
            }
            else
            {
                sw_prosigue = true;
            }
            if (sw_prosigue)
            {
                limpiar_documento();
                form_bloqueado(false);

                ssModo = "NEW";
            }
        }

        private void limpiar_documento()
        {
            try
            {
                localdes.SelectedIndex = -1;
                cboanio.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevo()
        {
            limpiar_documento();
            form_bloqueado(true);

            ssModo = "NEW";
        }

        private string get_LocalName(string dominioid, string moduloid, string local)
        {
            var BL = new sys_localBL();
            var DT = new DataTable();
            try
            {
                DT = BL.GetOne(EmpresaID, dominioid, moduloid, local).Tables[0];
                return fungen.RemoveAccentsWithRegEx(DT.Rows[0]["localname"].ToString());
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }

        private void Frm_reorganiza_perimes_Load(object sender, EventArgs e)
        {
            modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
            local = ((D60ALMACEN.MainAlmacen)MdiParent).local;

            limpiar_documento();
            form_bloqueado(true);
            data_cbo_moduloiddes();
            moduloiddes.SelectedValue = modulo;
            combo_anio();
            cboanio.SelectedValue = ((D60ALMACEN.MainAlmacen)MdiParent).perianio;
            data_cbo_localdes();
            localdes.SelectedValue = local;
        }

        private void data_cbo_moduloiddes()
        {
            try
            {
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                BE.dominioid = dominio;
                var dt = new DataTable();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];

                moduloiddes.DataSource = dt;
                moduloiddes.ValueMember = "moduloid";
                moduloiddes.DisplayMember = "moduloname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void data_cbo_localdes()
        {
            try
            {
                var BL = new sys_localBL();
                var BE = new tb_sys_local();
                BE.dominioid = dominio.ToString();
                BE.moduloid = moduloiddes.SelectedValue.ToString();

                var dt = new DataTable();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    VariablesPublicas.localdirec = dt.Rows[0]["localdirec"].ToString();
                    VariablesPublicas.telef = dt.Rows[0]["telef"].ToString();
                }

                localdes.DataSource = dt;
                localdes.ValueMember = "local";
                localdes.DisplayMember = "localname";
                localdes.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void combo_anio()
        {
            var BL = new tb_perianioBL();
            lista = BL.Get_anio(EmpresaID);
            cboanio.DataSource = lista;
            cboanio.DisplayMember = "perianio";
            cboanio.ValueMember = "codigo";
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            form_accion_cancelEdicion(1);
        }

        private void btn_process_Click(object sender, EventArgs e)
        {
            try
            {
                if (localdes.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione Local ..!!!");
                    return;
                }
                else
                {
                    if (cboanio.SelectedValue.ToString().Trim().Length != 4)
                    {
                        MessageBox.Show("Seleccione Año ..!!!");
                        return;
                    }
                    else
                    {
                        var BL = new tb_60local_stockBL();
                        var BE = new tb_60local_stock();

                        BE.moduloid = moduloiddes.SelectedValue.ToString();
                        BE.local = localdes.SelectedValue.ToString();
                        BE.perianio = cboanio.SelectedValue.ToString();

                        if (BL.Reorg_CostUlt(VariablesPublicas.EmpresaID.ToString(), BE))
                        {
                            MessageBox.Show("Proceso terminado Correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            nuevo();
                        }
                        else
                        {
                            MessageBox.Show("Contactese con Sistema !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
