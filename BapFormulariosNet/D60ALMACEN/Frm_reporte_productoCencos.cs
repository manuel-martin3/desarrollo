using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using bapFunciones;
using LayerBusinessEntities;
using LayerBusinessLogic;

namespace BapFormulariosNet.D60ALMACEN
{
    public partial class Frm_reporte_productoCencos : plantilla
    {
        private String EmpresaID = string.Empty;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;
        private String PERFILID = string.Empty;
        private String dominioiddes = "60";
        public String CodigoCencos = string.Empty;

        public Frm_reporte_productoCencos()
        {
            InitializeComponent();
        }

        private void Frm_personal_cencos_Load(object sender, EventArgs e)
        {
            EmpresaID = VariablesPublicas.EmpresaID;
            PARAMETROS_TABLA();
            data_cbo_almacen();
            cargarReportes();
            limpiar_documento();
            form_bloqueado(false);
            perddnni.Enabled = false;
            btn_nuevo.Enabled = true;
            btn_salir.Enabled = true;
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



        private void data_cbo_almacen()
        {
            try
            {
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                BE.dominioid = dominioiddes.Trim();


                var dt = new DataTable();

                dt = BL.GetAll(EmpresaID, BE).Tables[0];


                cboalmacen.DataSource = dt;
                cboalmacen.ValueMember = "moduloid";
                cboalmacen.DisplayMember = "moduloname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cargarReportes()
        {
            cboreporte.Items.Add("<--SELECCIONE REPORTE-->");
            cboreporte.Items.Add("LISTADO PRODUCTOS POR CENTRO DE COSTOS");
            cboreporte.Items.Add("LISTADO MOVIMIENTO");
        }


        private void nuevo()
        {
            limpiar_documento();
            form_bloqueado(true);
            btn_cancelar.Enabled = true;
            btn_imprimir.Enabled = true;
            cboreporte.Enabled = true;
            cencosid.Focus();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            form_accion_cancelEdicion(1);
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            nuevo();
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
                perddnni.Enabled = false;
                btn_nuevo.Enabled = true;
                btn_salir.Enabled = true;
            }
        }

        private void form_bloqueado(Boolean var)
        {
            try
            {
                fechadoc.Enabled = false;
                cencosid.Enabled = var;

                perddnni.Enabled = var;

                btn_nuevo.Enabled = false;
                cboreporte.Enabled = false;
                cboalmacen.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_imprimir.Enabled = false;

                btn_salir.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiar_documento()
        {
            try
            {
                fechadoc.Value = DateTime.Today;
                cboreporte.SelectedIndex = 0;
                cencosid.Text = string.Empty;
                cencosname.Text = string.Empty;
                cboalmacen.Enabled = false;
                perddnni.Text = string.Empty;
                pername.Text = string.Empty;
                cencosid.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cencosid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaCentroCosto();
            }

            if (e.KeyCode == Keys.Enter)
            {
                ValidaCentrocosto(cencosid.Text.ToString(), false);
            }
        }

        private void AyudaCentroCosto()
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "Ayuda Centro de Costo";
                frmayuda.sqlquery = "select cencosid, cencosname From tb_centrocosto where cencosdivi = 2";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = string.Empty;
                frmayuda.sqland = "and";
                frmayuda.criteriosbusqueda = new string[] { "NOMBRE", "CÓDIGO" };
                frmayuda.columbusqueda = "cencosname,cencosid";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeCentroCosto;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void RecibeCentroCosto(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                cencosid.Text = resultado1.Trim();
                cencosname.Text = resultado2.Trim();
            }
        }

        private void ValidaCentrocosto(String xCencosid, Boolean retrn)
        {
            if (xCencosid.Trim().Length > 0)
            {
                var BL = new tb_co_persona_cencosBL();
                var BE = new tb_co_persona_cencosBE();

                var dt = new DataTable();

                BE.cencosid = xCencosid.Trim().ToString();
                BE.filtro = "1";
                dt = BL.GetDNI(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    cencosid.Text = dt.Rows[0]["cencosid"].ToString().Trim();
                    cencosname.Text = dt.Rows[0]["cencosname"].ToString().Trim();
                }
                else
                {
                    if (!retrn)
                    {
                        cencosid.Text = string.Empty;
                        cencosname.Text = string.Empty;
                        perddnni.Focus();
                    }
                }
            }
        }

        private void perddnni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaPersona();
            }

            if (e.KeyCode == Keys.Enter)
            {
                ValidaPersona(perddnni.Text.ToString(), false);
            }
        }

        private void AyudaPersona()
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "Ayuda Vendedor";
                frmayuda.sqlquery = "select nrodni,nombrelargo from tb_plla_fichatrabajadores";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where cencosid = '" + cencosid.Text + "' ";
                frmayuda.sqland = "and ";
                frmayuda.criteriosbusqueda = new string[] { "NOMBRE", "DNI" };
                frmayuda.columbusqueda = "nombrelargo,nrodni";
                frmayuda.returndatos = "0,1";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibePersona;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RecibePersona(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                perddnni.Text = resultado1.Trim();
                pername.Text = resultado2.Trim();
            }
        }

        private void ValidaPersona(String xPersonadni, Boolean retrn)
        {
            if (xPersonadni.Trim().Length > 0)
            {
                var BL = new tb_co_persona_cencosBL();
                var BE = new tb_co_persona_cencosBE();

                var dt = new DataTable();

                BE.perdni = xPersonadni.Trim().ToString();
                BE.cencosid = cencosid.Text.ToString();
                BE.filtro = "2";

                dt = BL.GetDNI(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    perddnni.Text = dt.Rows[0]["nrodni"].ToString().Trim();
                    pername.Text = dt.Rows[0]["nombrelargo"].ToString().Trim();
                }
                else
                {
                    if (!retrn)
                    {
                        perddnni.Text = string.Empty;
                        pername.Text = string.Empty;
                        perddnni.Focus();
                    }
                }
            }
        }


        private void listadoProductos()
        {
            try
            {
                var miForma = new REPORTES.Frm_reportes();
                miForma.moduloid = modulo.ToString();
                miForma.cencosid = cencosid.Text.Trim();
                miForma.perddnni = perddnni.Text.Trim();
                miForma.operacion = cboreporte.SelectedIndex;
                miForma.Text = "Reporte de Centro Costo";
                miForma.formulario = "Frm_producto_cencos";
                miForma.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            imprimirReporte();
        }

        private void imprimirReporte()
        {
            if (cboreporte.SelectedIndex != 0)
            {
                var reporte = cboreporte.SelectedIndex;
                if (reporte == 2)
                {
                    if (cboalmacen.SelectedIndex != 0)
                    {
                        switch (reporte)
                        {
                            case 2:
                                listadoMovimientoPersonal();
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccione Almacen...");
                    }
                }
                else
                {
                    switch (reporte)
                    {
                        case 1:
                            listadoProductos();
                            break;
                        case 2:
                            listadoMovimientoPersonal();
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione Reporte...");
            }
        }

        private void listadoMovimientoPersonal()
        {
            try
            {
                var miForma = new REPORTES.Frm_reportes();

                miForma.cencosid = cencosid.Text.Trim();
                miForma.perddnni = perddnni.Text.Trim();
                miForma.operacion = cboreporte.SelectedIndex;
                miForma.moduloiddies = cboalmacen.SelectedValue.ToString();
                miForma.Text = "Reporte de Centro Costo";
                miForma.formulario = "Frm_movimiento_personal";
                miForma.ShowDialog();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cboreporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            var reporte = cboreporte.SelectedIndex;

            switch (reporte)
            {
                case 1:
                    cboalmacen.Enabled = false;
                    cboalmacen.SelectedIndex = 0;
                    cencosid.Text = "";
                    cencosname.Text = "";
                    perddnni.Text = "";
                    pername.Text = "";
                    cencosid.Focus();
                    break;
                case 2:
                    cboalmacen.Enabled = true;
                    cboalmacen.SelectedIndex = 0;
                    cencosid.Text = "";
                    cencosname.Text = "";
                    perddnni.Text = "";
                    pername.Text = "";
                    break;
                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Tabla_productos_cencos = new DataTable("Personal_Cencos");
            var BL = new tb_co_persona_cencosBL();
            var BE = new tb_co_persona_cencosBE();

            BE.operacion = 1;
            BE.cencosid = cencosid.Text.Trim();
            BE.perdni = perddnni.Text.Trim();
            BE.moduloid = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;

            Tabla_productos_cencos = BL.GetProductosCencos(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

            if (Tabla_productos_cencos.Rows.Count > 0)
            {
                gridControl1.DataSource = Tabla_productos_cencos;
            }
            else
            {
                gridControl1.DataSource = Tabla_productos_cencos;
            }
        }

        private void btn_printstock_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void GridExport_Click(object sender, EventArgs e)
        {
            if (sfdFile.ShowDialog(this) == DialogResult.OK)
            {
                gridControl1.ExportToXls(sfdFile.FileName);
            }
        }
    }
}
