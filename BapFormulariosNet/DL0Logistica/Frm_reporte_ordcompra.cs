using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using bapFunciones;
using LayerBusinessEntities;
using LayerBusinessLogic;


namespace BapFormulariosNet.DL0Logistica
{
    public partial class Frm_reporte_ordcompra : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID.Trim();
        private String dominio = "60";
        private String modulo = string.Empty;
        private String moduloiddes = string.Empty;


        private List<tb_perianio> lista = null;
        private String dominioiddes = "60";
        public Frm_reporte_ordcompra()
        {
            InitializeComponent();
        }

        private void Frm_reporte_ordcompra_Load(object sender, EventArgs e)
        {
            if (Parent.Parent.Name == "MainLogistica")
            {
                moduloiddes = ((DL0Logistica.MainLogistica)MdiParent).moduloid;
                modulo = ((DL0Logistica.MainLogistica)MdiParent).moduloid;
            }

            if (Parent.Parent.Name == "MainAlmacen")
            {
                moduloiddes = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
                modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
            }


            if (moduloiddes == "0100")
            {
                limpiar_documento();
                form_bloqueado(false);
                data_cbo_moduloiddes();
                llenarComboMesini();
                llenarComboMesfin();
                combo_anio();

                cenestado.Items.Clear();
                cenestado.Items.AddRange("OK,PENDIENTES".Split(new char[] { ',' }));
            }
            else
            {
                if (moduloiddes == "0330")
                {
                    limpiar_documento();
                    form_bloqueado(false);
                    data_cbo_moduloiddes();
                    cbomodulo.SelectedValue = modulo;
                    cbomodulo.Enabled = false;
                    llenarComboMesini();
                    llenarComboMesfin();
                    /// combo_Cboreporte_Almacen();
                    combo_anio();
                }
                else
                {
                    limpiar_documento();
                    form_bloqueado(false);
                    data_cbo_moduloiddes();
                    cbomodulo.SelectedValue = modulo;
                    cbomodulo.Enabled = false;
                    llenarComboMesini();
                    llenarComboMesfin();
                    combo_anio();
                }
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
        private void combo_Cboreporte()
        {
            cboReporte.Items.Add("<--SELECCIONE-->");
            cboReporte.Items.Add("LISTADO DE ORDENES DE COMPRA");
            cboReporte.Items.Add("LISTADO DE ORDENES DE COMPRA PENDIENTES");
            cboReporte.Items.Add("LISTADO DE ORDENES DE CON STATUS");
        }

        private void combo_Cboreporte_Almacen()
        {
            cboReporte.Items.Add("<--SELECCIONE-->");
            cboReporte.Items.Add("LISTADO DE ORDENES DE COMPRA PENDIENTES");
        }

        private void combo_Cboreporte_listadoAlmacen()
        {
            cboReporte.Items.Add("<--SELECCIONE-->");
            cboReporte.Items.Add("LISTADO DE  ORDEN DE COMPRA  POR ALMACEN");
        }

        private void llenarComboMesini()
        {
            var lista = new List<Item>();

            lista.Add(new Item("Enero", 01));
            lista.Add(new Item("Febrero", 02));
            lista.Add(new Item("Marzo", 03));
            lista.Add(new Item("Abril", 04));
            lista.Add(new Item("Mayo", 05));
            lista.Add(new Item("Junio", 06));
            lista.Add(new Item("Julio", 07));
            lista.Add(new Item("Agosto", 08));
            lista.Add(new Item("Setiembre", 09));
            lista.Add(new Item("Octubre", 10));
            lista.Add(new Item("Noviembre", 11));
            lista.Add(new Item("Diciembre", 12));

            cboMesini.DisplayMember = "Name";
            cboMesini.ValueMember = "Value";
            cboMesini.DataSource = lista;
        }

        private void llenarComboMesfin()
        {
            var lista = new List<Item>();

            lista.Add(new Item("Enero", 01));
            lista.Add(new Item("Febrero", 02));
            lista.Add(new Item("Marzo", 03));
            lista.Add(new Item("Abril", 04));
            lista.Add(new Item("Mayo", 05));
            lista.Add(new Item("Junio", 06));
            lista.Add(new Item("Julio", 07));
            lista.Add(new Item("Agosto", 08));
            lista.Add(new Item("Setiembre", 09));
            lista.Add(new Item("Octubre", 10));
            lista.Add(new Item("Noviembre", 11));
            lista.Add(new Item("Diciembre", 12));

            cboMesfin.DisplayMember = "Name";
            cboMesfin.ValueMember = "Value";
            cboMesfin.DataSource = lista;
        }
        private void data_cbo_moduloiddes()
        {
            try
            {
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                BE.dominioid = dominioiddes.Trim();
                var dt = new DataTable();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                cbomodulo.DataSource = dt;
                cbomodulo.ValueMember = "moduloid";
                cbomodulo.DisplayMember = "moduloname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grupoid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaClientes(string.Empty);
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
                frmayuda.returndatos = "0,2,1,3";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeGrupo;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RecibeGrupo(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                grupoid.Text = resultado1.Trim();
                gruponame.Text = resultado3.Trim();
            }
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            reporte_Ordencompra();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            if (moduloiddes == "0100")
            {
                nuevo();
            }
            else
            {
                nuevo_Almacenes();
            }
        }
        private void nuevo()
        {
            limpiar_documento();
            form_bloqueado(true);
            btn_imprimir.Enabled = true;
            btn_excel.Enabled = true;
            btn_cancelar.Enabled = true;
            cboanio.Enabled = true;
        }

        private void nuevo_Almacenes()
        {
            limpiar_documento();
            form_bloqueado_Almacen(true);
            btn_imprimir.Enabled = true;
            btn_excel.Enabled = true;
            btn_cancelar.Enabled = true;
            cboanio.Enabled = true;
        }

        private void limpiar_documento()
        {
            try
            {
                cboanio.SelectedValue = "0";
                if (moduloiddes == "0100")
                {
                    cbomodulo.SelectedIndex = -1;
                }
                grupoid.Text = string.Empty;
                gruponame.Text = string.Empty;
                productid.Text = string.Empty;
                productname.Text = string.Empty;
                cboMesini.SelectedValue = DateTime.Today.Month;
                cboMesfin.SelectedValue = DateTime.Today.Month;
                cboReporte.SelectedIndex = -1;
                chkigv.Checked = false;
                chkstatus.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void form_bloqueado(Boolean var)
        {
            try
            {
                cboMesini.Enabled = var;
                cboMesfin.Enabled = var;
                cbomodulo.Enabled = var;
                cboReporte.Enabled = var;
                grupoid.Enabled = var;
                gruponame.Enabled = false;
                productid.Enabled = var;
                productname.Enabled = false;

                cboanio.Enabled = false;

                btn_cancelar.Enabled = false;
                btn_imprimir.Enabled = false;
                btn_excel.Enabled = false;
                btn_salir.Enabled = false;
                chkstatus.Enabled = false;
                chkigv.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void form_bloqueado_Almacen(Boolean var)
        {
            try
            {
                cboMesini.Enabled = var;
                cboMesfin.Enabled = var;
                cbomodulo.Enabled = false;
                cboReporte.Enabled = var;
                grupoid.Enabled = var;
                gruponame.Enabled = false;
                cboanio.Enabled = false;

                btn_cancelar.Enabled = false;
                btn_imprimir.Enabled = false;
                btn_excel.Enabled = false;
                btn_salir.Enabled = false;
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
                btn_nuevo.Enabled = true;
                btn_salir.Enabled = true;
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            form_accion_cancelEdicion(1);
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Validar_Combos()
        {
            int mes1, mes2;
            mes1 = Convert.ToInt32(cboMesini.SelectedValue);
            mes2 = Convert.ToInt32(cboMesfin.SelectedValue);

            if (mes1 == mes2)
            {
                Mes_Actual();
                mes_final();
            }
            else
            {
                Mes_Actual();
                mes_final();
            }
        }


        private void Mes_Actual()
        {
            var mes = 0;
            var nmes = string.Empty;
            mes = Convert.ToInt32(cboMesini.SelectedValue);
            switch (mes)
            {
                case 1:
                    nmes = "Enero";
                    break;
                case 2:
                    nmes = "Febrero";
                    break;
                case 3:
                    nmes = "Marzo";
                    break;
                case 4:
                    nmes = "Abril";
                    break;
                case 5:
                    nmes = "Mayo";
                    break;
                case 6:
                    nmes = "Junio";
                    break;
                case 7:
                    nmes = "Julio";
                    break;
                case 8:
                    nmes = "Agosto";
                    break;
                case 9:
                    nmes = "Setiembre";
                    break;
                case 10:
                    nmes = "Octubre";
                    break;
                case 11:
                    nmes = "Noviembre";
                    break;
                default:
                    nmes = "Diciembre";
                    break;
            }
            VariablesPublicas.N_PrimerMes1 = nmes;
        }

        private void mes_final()
        {
            var mes = 0;
            var nmes = string.Empty;
            mes = Convert.ToInt32(cboMesfin.SelectedValue);
            switch (mes)
            {
                case 1:
                    nmes = "Enero";
                    break;
                case 2:
                    nmes = "Febrero";
                    break;
                case 3:
                    nmes = "Marzo";
                    break;
                case 4:
                    nmes = "Abril";
                    break;
                case 5:
                    nmes = "Mayo";
                    break;
                case 6:
                    nmes = "Junio";
                    break;
                case 7:
                    nmes = "Julio";
                    break;
                case 8:
                    nmes = "Agosto";
                    break;
                case 9:
                    nmes = "Setiembre";
                    break;
                case 10:
                    nmes = "Octubre";
                    break;
                case 11:
                    nmes = "Noviembre";
                    break;
                default:
                    nmes = "Diciembre";
                    break;
            }
            VariablesPublicas.N_FinMes1 = nmes;
        }

        private void reporte_Ordencompra()
        {
            int reporte;
            if (cbomodulo.SelectedIndex != -1)
            {
                reporte = Convert.ToInt32(cbomodulo.SelectedIndex);
                if (cboReporte.SelectedIndex != 0)
                {
                    var nombre = Convert.ToString(cboReporte.SelectedItem);
                    if (nombre == "LISTADO DE  ORDEN DE COMPRA  POR ALMACEN")
                    {
                        reporte = Convert.ToInt32(cboReporte.SelectedIndex);
                        if (cboanio.SelectedValue != null)
                        {
                            if (reporte != -1)
                            {
                                if (moduloiddes == "0100")
                                {
                                    switch (reporte)
                                    {
                                        case 1:
                                            reporte_listar_Almacen();
                                            break;
                                        case 2:
                                            reporte_listado_Almacen();
                                            break;
                                        case 3:
                                            reporte_Orden_Pendiente();
                                            break;
                                        case 4:
                                            reporte_Orden_Status();
                                            break;
                                    }
                                }
                                else
                                {
                                    switch (reporte)
                                    {
                                        case 1:
                                            reporte_Orden_Pendiente();
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Seleccione Reporte...");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Seleccione Año...");
                        }
                    }
                    else
                    {
                        reporte = Convert.ToInt32(cboReporte.SelectedIndex);
                        if (cboanio.SelectedValue != "0")
                        {
                            if (reporte != -1)
                            {
                                if (moduloiddes == "0100")
                                {
                                    switch (reporte)
                                    {
                                        case 1:
                                            reporte_listado_Almacen();
                                            break;
                                        case 2:
                                            reporte_Orden_Pendiente();
                                            break;
                                        case 3:
                                            reporte_Orden_Status();
                                            break;
                                    }
                                }
                                else
                                {
                                    switch (reporte)
                                    {
                                        case 1:
                                            reporte_Orden_Pendiente();
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Seleccione Reporte...");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Seleccione Año...");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione Reporte...");
                }
            }
            else
            {
                MessageBox.Show("Seleccione Modulo...");
            }
        }

        private void reporte_listado_Almacen()
        {
            var miForma = new Reportes.Frm_reportes();
            miForma.Text = "Reporte Balance de Stock";

            miForma.moduloiddies = Equivalencias.getValue(cbomodulo.SelectedValue).ToString();
            miForma.perianio = cboanio.Text.ToString();

            var mes1 = Convert.ToInt32(cboMesini.SelectedValue.ToString());
            var mes2 = Convert.ToInt32(cboMesfin.SelectedValue.ToString());

            Validar_Combos();

            if (mes1 < 10)
            {
                miForma.perimesini = "0" + Convert.ToString(cboMesini.SelectedValue.ToString());
                VariablesPublicas.Perimesini = miForma.perimesini;
            }
            else
            {
                miForma.perimesini = Convert.ToString(cboMesini.SelectedValue.ToString());
                VariablesPublicas.Perimesini = miForma.perimesini;
            }

            if (mes2 < 10)
            {
                miForma.perimesfin = "0" + Convert.ToString(cboMesfin.SelectedValue.ToString());
                VariablesPublicas.Perimesfin = miForma.perimesfin;
            }
            else
            {
                miForma.perimesfin = Convert.ToString(cboMesfin.SelectedValue.ToString());
                VariablesPublicas.Perimesfin = miForma.perimesfin;
            }

            miForma.grupoid = grupoid.Text.Trim();
            miForma.productid = productid.Text.Trim();
            miForma.igv = chkigv.Checked ? "1" : "0";
            miForma.formulario = "Frm_listar_almacen";
            miForma.Show();
        }

        private void reporte_Orden_Status()
        {
            var miForma = new Reportes.Frm_reportes();
            miForma.Text = "Reporte Balance de Stock";

            miForma.moduloiddies = Equivalencias.getValue(cbomodulo.SelectedValue).ToString();
            miForma.perianio = cboanio.Text.ToString();

            var mes1 = Convert.ToInt32(cboMesini.SelectedValue.ToString());
            var mes2 = Convert.ToInt32(cboMesfin.SelectedValue.ToString());

            Validar_Combos();

            if (mes1 < 10)
            {
                miForma.perimesini = "0" + Convert.ToString(cboMesini.SelectedValue.ToString());
                VariablesPublicas.Perimesini = miForma.perimesini;
            }
            else
            {
                miForma.perimesini = Convert.ToString(cboMesini.SelectedValue.ToString());
                VariablesPublicas.Perimesini = miForma.perimesini;
            }

            if (mes2 < 10)
            {
                miForma.perimesfin = "0" + Convert.ToString(cboMesfin.SelectedValue.ToString());
                VariablesPublicas.Perimesfin = miForma.perimesfin;
            }
            else
            {
                miForma.perimesfin = Convert.ToString(cboMesfin.SelectedValue.ToString());
                VariablesPublicas.Perimesfin = miForma.perimesfin;
            }

            miForma.pendiente = cenestado.SelectedIndex.ToString();
            miForma.grupoid = grupoid.Text.Trim();
            miForma.formulario = "Frm_orden_status";
            miForma.Show();
        }
        private void reporte_Orden_Pendiente()
        {
            var miForma = new Reportes.Frm_reportes();
            miForma.Text = "Reporte Balance de Stock";

            miForma.moduloiddies = Equivalencias.getValue(cbomodulo.SelectedValue).ToString();
            miForma.perianio = cboanio.Text.ToString();

            var mes1 = Convert.ToInt32(cboMesini.SelectedValue.ToString());
            var mes2 = Convert.ToInt32(cboMesfin.SelectedValue.ToString());

            Validar_Combos();

            if (mes1 < 10)
            {
                miForma.perimesini = "0" + Convert.ToString(cboMesini.SelectedValue.ToString());
                VariablesPublicas.Perimesini = miForma.perimesini;
            }
            else
            {
                miForma.perimesini = Convert.ToString(cboMesini.SelectedValue.ToString());
                VariablesPublicas.Perimesini = miForma.perimesini;
            }

            if (mes2 < 10)
            {
                miForma.perimesfin = "0" + Convert.ToString(cboMesfin.SelectedValue.ToString());
                VariablesPublicas.Perimesfin = miForma.perimesfin;
            }
            else
            {
                miForma.perimesfin = Convert.ToString(cboMesfin.SelectedValue.ToString());
                VariablesPublicas.Perimesfin = miForma.perimesfin;
            }
            miForma.grupoid = grupoid.Text.Trim();
            miForma.pendiente = "1";
            miForma.formulario = "Frm_orden_pendiente";
            miForma.Show();
        }

        private void reporte_listar_Almacen()
        {
            if (cbomodulo.SelectedIndex != -1)
            {
                var miForma = new Reportes.Frm_reportes();
                miForma = new Reportes.Frm_reportes();

                miForma.moduloiddies = Equivalencias.getValue(cbomodulo.SelectedValue).ToString();
                miForma.perianio = cboanio.Text.ToString();

                var mes1 = Convert.ToInt32(cboMesini.SelectedValue.ToString());
                var mes2 = Convert.ToInt32(cboMesfin.SelectedValue.ToString());

                Validar_Combos();

                if (mes1 < 10)
                {
                    miForma.perimesini = "0" + Convert.ToString(cboMesini.SelectedValue.ToString());
                    VariablesPublicas.Perimesini = miForma.perimesini;
                }
                else
                {
                    miForma.perimesini = Convert.ToString(cboMesini.SelectedValue.ToString());
                    VariablesPublicas.Perimesini = miForma.perimesini;
                }

                if (mes2 < 10)
                {
                    miForma.perimesfin = "0" + Convert.ToString(cboMesfin.SelectedValue.ToString());
                    VariablesPublicas.Perimesfin = miForma.perimesfin;
                }
                else
                {
                    miForma.perimesfin = Convert.ToString(cboMesfin.SelectedValue.ToString());
                    VariablesPublicas.Perimesfin = miForma.perimesfin;
                }

                miForma.grupoid = grupoid.Text.Trim();
                miForma.productid = productid.Text.Trim();
                miForma.igv = chkigv.Checked ? "1" : "0";
                miForma.formulario = "Frm_orden_listado";
                miForma.Show();
            }
            else
            {
                MessageBox.Show("Seleccione Modulo...");
            }
        }

        private void cboReporte_SelectedValueChanged(object sender, EventArgs e)
        {
            Int32 reporte;
            var nombre = cboReporte.SelectedItem.ToString();
            reporte = Convert.ToInt32(cboReporte.SelectedIndex);
            if (moduloiddes == "0100")
            {
                switch (reporte)
                {
                    case 0:
                        chkstatus.Enabled = false;
                        chkigv.Enabled = false;
                        chkstatus.Checked = false;
                        chkigv.Checked = false;
                        cenestado.Visible = false;
                        break;
                    case 1:
                        chkstatus.Enabled = false;
                        chkigv.Enabled = true;
                        chkstatus.Checked = false;
                        chkigv.Checked = false;
                        if (nombre == "LISTADO DE  ORDEN DE COMPRA  POR ALMACEN")
                        {
                            grupoid.Enabled = false;
                        }
                        else
                        {
                            grupoid.Enabled = true;
                        }
                        cenestado.Visible = false;
                        break;
                    case 2:
                        chkstatus.Enabled = true;
                        chkigv.Enabled = false;
                        chkstatus.Checked = false;
                        chkigv.Checked = false;
                        cenestado.Visible = false;
                        break;
                    case 3:
                        chkstatus.Enabled = false;
                        chkigv.Enabled = false;
                        chkstatus.Checked = false;
                        chkigv.Checked = false;
                        cenestado.Visible = true;
                        break;
                    case 4:
                        chkstatus.Enabled = true;
                        chkigv.Enabled = false;
                        chkigv.Checked = false;
                        cenestado.Visible = false;
                        break;
                }
            }
            else
            {
                switch (reporte)
                {
                    case 0:
                        chkstatus.Enabled = false;
                        chkigv.Enabled = false;
                        chkstatus.Checked = false;
                        chkigv.Checked = false;
                        break;
                    case 1:
                        chkstatus.Enabled = true;
                        chkigv.Enabled = false;
                        chkstatus.Checked = false;
                        chkigv.Checked = false;
                        break;
                }
            }
        }

        private void cbomodulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var i = cbomodulo.SelectedIndex;
            if (moduloiddes == "0100")
            {
                if (i != 1 ^ i != 2 ^ i != 3 ^ i != 4 ^ i != 5 ^
                    i != 6 ^ i != 7 ^ i != 8 ^ i != 9 ^ i != 10 ^ i != 11 ^ i != 12)
                {
                    cboReporte.Items.Clear();
                    combo_Cboreporte();
                }
                else
                {
                    cboReporte.Items.Clear();
                    combo_Cboreporte_listadoAlmacen();
                }
            }
            else
            {
                cboReporte.Items.Clear();
                combo_Cboreporte_Almacen();
            }
        }

        private void cboReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void productid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaProducto(string.Empty);
            }
        }

        private void AyudaProducto(String lpdescrlike)
        {
            try
            {
                var modd = string.Empty;
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                var dt = new DataTable();

                BE.dominioid = dominio;
                BE.moduloid = cbomodulo.SelectedValue.ToString();
                dt = BL.GetAll(EmpresaID, BE).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();

                        var frmayuda = new Ayudas.Frm_help_general();

                        frmayuda.tipoo = "sql";
                        frmayuda.titulo = "<< AYUDA  TABLA PRODUCTOS >>";
                        frmayuda.sqlquery = "SELECT tb1.productid, tb1.productname, tb2.stock,tb2.costoultimo FROM tb_" + modd + "_productos AS tb1 ";
                        frmayuda.sqlinner = "inner join tb_" + modd + "_local_stock as tb2 on tb1.productid = tb2.productid ";
                        frmayuda.sqlwhere = "where";
                        frmayuda.sqland = string.Empty;
                        frmayuda.criteriosbusqueda = new string[] { "PRODUCTO", "CODIGO" };
                        frmayuda.columbusqueda = "tb1.productname,tb1.productid";
                        frmayuda.returndatos = "0,1";

                        frmayuda.Owner = this;
                        frmayuda.PasaProveedor = RecibeProducto;
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void RecibeProducto(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0 && resultado2.Trim().Length > 0)
            {
                productid.Text = resultado1.Trim();
                productname.Text = resultado2.Trim();
            }
        }
    }
}
