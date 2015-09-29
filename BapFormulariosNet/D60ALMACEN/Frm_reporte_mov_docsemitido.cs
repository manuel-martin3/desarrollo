using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.D60ALMACEN
{
    public partial class Frm_reporte_mov_docsemitido : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;
        private Int32 modcalculo;
        private String PERFILID = string.Empty;

        private String ssModo = "NEW";

        public Frm_reporte_mov_docsemitido()
        {
            InitializeComponent();
            ctacte.LostFocus += new System.EventHandler(ctacte_LostFocus);
            mottrasladointid.LostFocus += new System.EventHandler(mottrasladointid_LostFocus);
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
            if (modulo.ToString() == "0100" || modulo.ToString() == "0900")
            {
                tipodoc.Enabled = var;
                mottrasladointid.Enabled = var;
                mottrasladointname.Enabled = false;
                ctacte.Enabled = var;
                ctactename.Enabled = false;
                fechdocini.Enabled = var;
                fechdocfin.Enabled = var;

                cbo_moduloides.Enabled = var;
                localdes.Enabled = var;

                btn_nuevo.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_imprimir.Enabled = false;
                btn_excel.Enabled = false;
                btn_salir.Enabled = false;
            }
            else
            {
                tipodoc.Enabled = var;
                mottrasladointid.Enabled = var;
                mottrasladointname.Enabled = false;
                ctacte.Enabled = var;
                ctactename.Enabled = false;
                fechdocini.Enabled = var;
                fechdocfin.Enabled = var;

                cbo_moduloides.Enabled = false;
                localdes.Enabled = false;

                btn_nuevo.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_imprimir.Enabled = false;
                btn_excel.Enabled = false;
                btn_salir.Enabled = false;
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

                btn_nuevo.Enabled = true;
                btn_salir.Enabled = true;

                ssModo = "NEW";
            }
        }

        private void data_cbo_tipodoc()
        {
            if (cbo_moduloides.SelectedValue.ToString().Length == 4)
            {
                if (cbo_moduloides.SelectedValue.ToString() != "0200" && cbo_moduloides.SelectedValue.ToString() != "0000")
                {
                    var BL = new modulo_local_tipodocBL();
                    var BE = new tb_modulo_local_tipodoc();
                    BE.dominioid = "60";
                    BE.moduloid = cbo_moduloides.SelectedValue.ToString();
                    BE.local = localdes.SelectedValue.ToString();
                    BE.visiblealmac = true;
                    BE.status = string.Empty;

                    tipodoc.DataSource = BL.GetAll_mov(EmpresaID, BE).Tables[0];
                    tipodoc.ValueMember = "tipodoc";
                    tipodoc.DisplayMember = "tipodocname";
                }
            }
        }

        private void ValidaCliente()
        {
            if (ctacte.Text.Trim().Length > 0)
            {
                var BL = new clienteBL();
                var BE = new tb_cliente();
                var dt = new DataTable();

                BE.ctacte = ctacte.Text.Trim().PadLeft(7, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    ctacte.Text = dt.Rows[0]["ctacte"].ToString().Trim();
                    ctactename.Text = dt.Rows[0]["ctactename"].ToString().Trim();
                }
                else
                {
                    ctacte.Text = string.Empty;
                    ctactename.Text = string.Empty;
                }
            }
        }

        private void ValidaMottrasladoint()
        {
            if (mottrasladointid.Text.Trim().Length > 0)
            {
                var BL = new tb_mottrasladointBL();
                var BE = new tb_mottrasladoint();
                var dt = new DataTable();

                BE.moduloid = modulo.Trim();
                BE.mottrasladointid = mottrasladointid.Text.Trim().PadLeft(2, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    mottrasladointid.Text = dt.Rows[0]["mottrasladointid"].ToString().Trim();
                    mottrasladointname.Text = dt.Rows[0]["mottrasladointname"].ToString().Trim();
                }
                else
                {
                    mottrasladointid.Text = string.Empty;
                    mottrasladointname.Text = string.Empty;
                }
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

        private void AyudaClientes(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "Ayuda Cliente/Proveedor";
                frmayuda.sqlquery = "select ctacte, ctactename, nmruc, direc from tb_cliente";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where";
                frmayuda.sqland = string.Empty;
                frmayuda.criteriosbusqueda = new string[] { "CLIENTE", "RUC", "CODIGO" };
                frmayuda.columbusqueda = "ctactename,nmruc,ctacte";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeClientes;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
        private void RecibeClientes(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                ctacte.Text = resultado1.Trim();
                ctactename.Text = resultado2.Trim();
            }
        }

        private void AyudaMottrasladoint(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "all";
                frmayuda.titulo = "Ayuda Motivo traslado interno";
                frmayuda.sqlquery = "select Mottrasladointid, Mottrasladointname from tb_Mottrasladoint";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where moduloid = '" + cbo_moduloides.SelectedValue.ToString() + "'";
                frmayuda.sqland = "and";
                frmayuda.criteriosbusqueda = new string[] { "MOTIVO INTERNO", "CODIGO" };
                frmayuda.columbusqueda = "Mottrasladointname,Mottrasladointid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeMottrasladoint;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
        private void RecibeMottrasladoint(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                mottrasladointid.Text = resultado1.Trim();
                mottrasladointname.Text = resultado2.Trim();
            }
        }

        private void limpiar_documento()
        {
            if (modulo.ToString() == "0100" || modulo.ToString() == "0900")
            {
                localdes.SelectedIndex = -1;
                var fechatemp = DateTime.Today;
                var f1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
                fechdocini.Text = f1.ToString();
                fechdocfin.Value = DateTime.Today;
                serdoc.Text = string.Empty;
                mottrasladointid.Text = string.Empty;
                mottrasladointname.Text = string.Empty;
                ctacte.Text = string.Empty;
                ctactename.Text = string.Empty;
            }
            else
            {
                tipodoc.SelectedIndex = -1;
                cbo_moduloides.SelectedValue = modulo.ToString();
                localdes.SelectedValue = local.ToString();
                var fechatemp = DateTime.Today;
                var f1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
                fechdocini.Text = f1.ToString();
                fechdocfin.Value = DateTime.Today;
                serdoc.Text = string.Empty;
                mottrasladointid.Text = string.Empty;
                mottrasladointname.Text = string.Empty;
                ctacte.Text = string.Empty;
                ctactename.Text = string.Empty;
            }
        }

        private void nuevo()
        {
            limpiar_documento();
            form_bloqueado(true);
            btn_imprimir.Enabled = true;
            btn_excel.Enabled = true;
            btn_cancelar.Enabled = true;
            mottrasladointid.Focus();

            ssModo = "NEW";
        }

        private void Frm_reporte_mov_docsemitido_Load(object sender, EventArgs e)
        {
            if (Parent.Parent.Name == "MainAlmacen")
            {
                modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
                local = ((D60ALMACEN.MainAlmacen)MdiParent).local;
            }

            if (Parent.Parent.Name == "MainProduccion")
            {
                modulo = ((D70Produccion.MainProduccion)MdiParent).moduloid;
                local = ((D70Produccion.MainProduccion)MdiParent).local;
            }

            get_cbo_modulo();
            limpiar_documento();
            data_cbo_tipodoc();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_salir.Enabled = true;

            radioListBox1.Items.Clear();
            radioListBox1.Items.AddRange("Ingresos - Egresos,Egresos - Ingresos".Split(new char[] { ',' }));
            radioListBox1.SelectedIndex = 0;
        }


        private void get_cbo_modulo()
        {
            var BL = new sys_moduloBL();
            var BE = new tb_sys_modulo();
            var dt = new DataTable();
            BE.dominioid = dominio.Trim();
            dt = BL.GetAll(EmpresaID, BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                cbo_moduloides.DataSource = dt;
                cbo_moduloides.ValueMember = "moduloid";
                cbo_moduloides.DisplayMember = "moduloname";
            }
        }

        private void get_dominio_modulo_local(string dominioid, string moduloid)
        {
            if (moduloid.ToString().Length == 4)
            {
                var BL = new sys_localBL();
                var BE = new tb_sys_local();
                BE.dominioid = dominioid;
                BE.moduloid = cbo_moduloides.SelectedValue.ToString();

                var dt = new DataTable();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    localdes.DataSource = dt;
                    localdes.ValueMember = "local";
                    localdes.DisplayMember = "localname";
                }
            }
        }



        private void Frm_reporte_mov_docsemitido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
            }

            if (e.Control && e.KeyCode == Keys.N)
            {
                if (btn_nuevo.Enabled)
                {
                    nuevo();
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                if (btn_cancelar.Enabled)
                {
                    form_accion_cancelEdicion(1);
                }
                else
                {
                    btn_salir_Click(sender, e);
                }
            }
        }

        private void serdoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(sender, e);
        }

        private void ctacte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaClientes(string.Empty);
            }
        }

        private void ctacte_LostFocus(object sender, System.EventArgs e)
        {
            ValidaCliente();
        }

        private void mottrasladointid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaMottrasladoint(string.Empty);
            }
        }

        private void mottrasladointid_LostFocus(object sender, System.EventArgs e)
        {
            ValidaMottrasladoint();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            form_accion_cancelEdicion(1);
        }


        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                var miForma = new REPORTES.Frm_reportes();
                miForma.Text = "Reporte de Documentos emitidos";
                miForma.dominioid = dominio.Trim();

                if (cbo_moduloides.SelectedIndex != -1)
                {
                    miForma.moduloid = cbo_moduloides.SelectedValue.ToString();
                }
                else
                {
                    MessageBox.Show("!!!... Seleccione Modulo ...!!!", "Información");
                    return;
                }

                if (localdes.SelectedIndex != -1)
                {
                    miForma.local = localdes.SelectedValue.ToString();
                }
                else
                {
                    MessageBox.Show("!!!... Seleccione Local ...!!!", "Información");
                    return;
                }

                if (tipodoc.SelectedIndex != -1 && tipodoc.SelectedItem.ToString().Trim().Length > 0)
                {
                    miForma.tipdoc = tipodoc.SelectedValue.ToString().Trim();
                }
                miForma.mottrasladointid = mottrasladointid.Text.Trim();
                miForma.ctacte = ctacte.Text.Trim();
                miForma.fechdocini = fechdocini.Text.Trim().Substring(0, 10);
                miForma.fechdocfin = fechdocfin.Text.Trim().Substring(0, 10);
                miForma.modcalculo = modcalculo;
                miForma.almacaccionid = string.Empty;

                miForma.formulario = "Frm_reporte_mov_docsemitido";
                miForma.Show();
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

        private void radioListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            modcalculo = radioListBox1.SelectedIndex;
        }

        private void cbo_moduloides_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_moduloides.Items.Count > 0)
            {
                get_dominio_modulo_local(dominio.ToString(), cbo_moduloides.SelectedValue.ToString());
                data_cbo_tipodoc();
            }
        }
    }
}
