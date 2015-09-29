using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;


namespace BapFormulariosNet.D60ALMACEN.CATALOGO
{
    public partial class Frm_GeneraArchivoWork : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;
        private String perianio = string.Empty;
        private String perimes = string.Empty;

        private String PERFILID = string.Empty;

        private String ssModo = "NEW";

        private Genericas fungen = new Genericas();

        public Frm_GeneraArchivoWork()
        {
            InitializeComponent();
        }


        private void PARAMETROS_TABLA()
        {
            var xxferfil = string.Empty;
            var f = (MainAlmacen)MdiParent;
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

        private void form_bloqueado(Boolean var)
        {
            try
            {
                fech_ini.Enabled = var;
                fech_fin.Enabled = var;
                txtLocal.Enabled = var;
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
                Close();
                ssModo = "NEW";
            }
        }

        private void solo_numero_enteros(object control, KeyPressEventArgs e)
        {
            if (((e.KeyChar) >= '0' && e.KeyChar <= '9') && !(e.KeyChar == '.'))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete && !(e.KeyChar == '.'))
                {
                    e.Handled = false;
                }
                else
                {
                    if ((e.KeyChar) == (char)Keys.Tab)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        private void solo_numero_decimal(object control, KeyPressEventArgs e)
        {
            if (((e.KeyChar) >= '0' && e.KeyChar <= '9') && !(e.KeyChar == '.'))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete && !(e.KeyChar == '.'))
                {
                    e.Handled = false;
                }
                else
                {
                    if ((e.KeyChar) == (char)Keys.Tab)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        if (e.KeyChar == '.')
                        {
                            e.Handled = false;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
        }
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData )
        {
            if (keyData == Keys.Enter)
            {
                if (GetNextControl(ActiveControl, true) != null)
                {
                    SendKeys.Send("\t");
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public bool IsNumeric(String Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        public static KeyEventHandler CapturarTeclaGRID
        {
            get
            {
                KeyEventHandler keypress = new KeyEventHandler(LecturaTecla);
                return keypress;
            }
        }
        private static void LecturaTecla(System.Object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                VariablesPublicas.PulsaAyudaArticulos = true;
                SendKeys.Send("\t");
            }
            if (e.KeyCode == Keys.F2)
            {
                VariablesPublicas.PulsaTeclaF2 = true;
                SendKeys.Send("\t");
            }
            if (e.KeyCode == Keys.F3)
            {
                VariablesPublicas.PulsaTeclaF3 = true;
                SendKeys.Send("\t");
            }
        }

        private void limpiar_documento()
        {
            try
            {
                fech_ini.Text = string.Empty;
                fech_fin.Text = string.Empty;
                txtLocal.Text = string.Empty;
                periodo.Text = "PERIODO";
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

            perianio = ((D60ALMACEN.MainAlmacen)MdiParent).perianio;
            perimes = ((D60ALMACEN.MainAlmacen)MdiParent).perimes;

            PARAMETROS_TABLA();
            cargar_linea();
            cargar_lineasiLSI();
            txtLocal.Text = get_LocalName(dominio, modulo, local);
            periodo.Text = "AÑO: " + perianio + "  MES: " + fungen.get_mesCad(perimes);

            form_bloqueado(false);
        }
        private void serop_ini_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(sender, e);
        }
        private void numop_ini_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(sender, e);
        }
        private void serop_fin_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(sender, e);
        }
        private void numop_fin_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(sender, e);
        }
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void cargar_linea()
        {
            try
            {
                var BE = new tb_60linea();
                var BL = new tb_60lineaBL();

                BE.moduloid = modulo;
                BE.local = local;
                var table = BL.GetAllnoLSI(EmpresaID, BE).Tables[0];
                var rows = table.Rows;

                object[] cell;

                foreach (DataRow item in rows)
                {
                    cell = item.ItemArray;
                    list2List1.listaizquierda.Items.Add(cell[0].ToString() + " - " + cell[1].ToString());
                    cell = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargar_lineasiLSI()
        {
            try
            {
                var BE = new tb_60linea();
                var BL = new tb_60lineaBL();

                BE.moduloid = modulo;
                BE.local = local;
                var table = BL.GetAllsiLSI(EmpresaID, BE).Tables[0];


                lstgenerado.DataSource = table;
                lstgenerado.ValueMember = "lineaid";
                lstgenerado.DisplayMember = "lineaname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_generar_Click(object sender, EventArgs e)
        {
            fech_ini.Text = DateTime.Now.ToLongTimeString();
            var BL = new tb_60local_stock_inventarioBL();
            var BE = new tb_60local_stock_inventario();

            var lineaid = string.Empty;
            var max = list2List1.listaderecha.Items.Count;

            try
            {
                if (max > 0)
                {
                    for (var i = 0; i < max; i++)
                    {
                        lineaid = Convert.ToString(list2List1.listaderecha.Items[i]).ToString().Substring(0, 3);

                        BE.moduloid = modulo;
                        BE.local = local;
                        BE.lineaid = lineaid;
                        BE.fechdoc = Convert.ToDateTime(fechatoma.Text.Trim().Substring(0, 10));
                        BE.usuar = VariablesPublicas.Usuar.Trim();

                        if (BL.GetAll_INICIALIZAR(EmpresaID, BE))
                        {
                            fech_fin.Text = DateTime.Now.ToLongTimeString();
                            MessageBox.Show("Proceso terminado Correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            list2List1.listaderecha.Items.Clear();
                            list2List1.listaizquierda.Items.Clear();
                            list2List1.listaizquierda.Refresh();
                            cargar_linea();
                            cargar_lineasiLSI();
                        }
                        else
                        {
                            MessageBox.Show("Proceso Truncado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Agrega Lineas A Generar ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            form_accion_cancelEdicion(1);
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
        }

        private void btndelall_Click(object sender, EventArgs e)
        {
        }

        private void btndel_Click(object sender, EventArgs e)
        {
        }

        private void btnaddall_Click(object sender, EventArgs e)
        {
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var BL = new tb_60local_stock_inventarioBL();
            var BE = new tb_60local_stock_inventario();

            BE.moduloid = modulo;
            BE.local = local;
            var sw_prosigue = false;
            sw_prosigue = (MessageBox.Show("Desea Tomar Nuevo Inventariado...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
            if (sw_prosigue)
            {
                BL.GetAll_New(EmpresaID, BE);
                list2List1.listaizquierda.Items.Clear();
                list2List1.listaizquierda.Refresh();
                cargar_linea();
                cargar_lineasiLSI();
                limpiar_documento();
            }
        }
    }
}
