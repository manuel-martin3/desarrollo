using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.D60ALMACEN.CATALOGO
{
    public partial class Frm_persona_cencos : plantilla
    {
        private String EmpresaID = string.Empty;
        private String dominio = "60";
        private String modulo = string.Empty;
        private String local = string.Empty;

        private String XNIVEL = string.Empty;
        private String XGLOSA = string.Empty;
        private String PERFILID = string.Empty;

        private DataTable TablaPersona;
        private Boolean procesado = false;
        private String ssModo = "NEW";
        public String CodigoCencos = string.Empty;

        public Frm_persona_cencos()
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

        private void NIVEL_FORMS()
        {
            XNIVEL = VariablesPublicas.Get_nivelperfil(PERFILID, Name).Substring(0, 1);
            if (XNIVEL != "0")
            {
                btn_clave.Image = global::BapFormulariosNet.Properties.Resources.btn_Lock20;
            }
            else
            {
                btn_clave.Image = global::BapFormulariosNet.Properties.Resources.btn_Un_Lock20;
            }
        }

        private void btn_clave_Click(object sender, EventArgs e)
        {
            try
            {
                var miForma = new Ayudas.Form_user_admin();
                miForma.Owner = this;
                miForma.PasaDatos = RecibePermiso;
                miForma.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RecibePermiso(Boolean resultado1, String resultado2)
        {
            if (resultado1)
            {
                XNIVEL = "0";
                XGLOSA = resultado2.Trim();
                btn_clave.Image = global::BapFormulariosNet.Properties.Resources.btn_Un_Lock20;
            }
        }
        private void form_bloqueado(Boolean var)
        {
            try
            {
                fechadoc.Enabled = var;
                cencosid.Enabled = true;
                estacion.Enabled = var;
                perddnni.Enabled = var;

                btn_nuevo.Enabled = false;
                btn_editar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_grabar.Enabled = false;
                btn_eliminar.Enabled = false;
                btn_imprimir.Enabled = false;

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
                NIVEL_FORMS();
                limpiar_documento();
                form_bloqueado(false);
                perddnni.Enabled = false;
                btn_nuevo.Enabled = true;
                btn_salir.Enabled = true;

                ssModo = "NEW";
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

        private void SEGURIDAD_LOG(String accion)
        {
            var xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio ;
            try
            {
                var BL = new tb_co_seguridadlogBL();
                var BE = new tb_co_seguridadlog();

                BE.moduloid = Name;
                BE.clave = xclave;
                BE.cuser = VariablesPublicas.Usuar;
                BE.fecha = DateTime.Now;
                BE.pc = VariablesPublicas.userip;
                BE.accion = accion.Trim();

                BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE);
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
                cencosid.Text = string.Empty;
                cencosname.Text = string.Empty;
                estacion.Text = string.Empty;
                perddnni.Text = string.Empty;
                pername.Text = string.Empty;
                unmedpeso.Text = string.Empty;
                peso.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevo()
        {
            ssModo = "NEW";
            limpiar_documento();
            form_bloqueado(true);
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            cencosid.Focus();
        }

        private void Insert()
        {
            try
            {
                if (cencosid.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Ingrese Centro de Costos!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (perddnni.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese DNI del Personal!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new tb_co_persona_cencosBL();
                        var BE = new tb_co_persona_cencosBE();

                        BE.cencosid = cencosid.Text.Trim().ToString();
                        BE.cencosestacion = estacion.Text.Trim();
                        BE.perdni = perddnni.Text.Trim();
                        BE.cencosfecha = Convert.ToDateTime(fechadoc.Text);
                        BE.cencosestado = true;

                        if (BL.Insert(EmpresaID, BE))
                        {
                            MessageBox.Show("Datos grabados correctamente !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            procesado = true;
                            form_bloqueado(false);
                            Data_TablaPersona();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Update()
        {
            try
            {
                if (cencosid.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Ingrese Centro de Costos!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (perddnni.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese DNI del Personal!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new tb_co_persona_cencosBL();
                        var BE = new tb_co_persona_cencosBE();

                        BE.item = Convert.ToInt32(CodigoCencos.ToString());
                        BE.cencosid = cencosid.Text.Trim().ToString();
                        BE.cencosestacion = estacion.Text.Trim();
                        BE.perdni = perddnni.Text.Trim();
                        BE.cencosfecha = Convert.ToDateTime(fechadoc.Text);
                        BE.cencosestado = true;

                        if (BL.Update(EmpresaID, BE))
                        {
                            SEGURIDAD_LOG("M");
                            MessageBox.Show("Datos modificado correctamente !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            procesado = true;
                            form_bloqueado(false);
                            Data_TablaPersona();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Delete()
        {
            try
            {
                if (cencosid.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Ingrese Centro de Costos!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (perddnni.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Ingrese DNI del Personal!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var BL = new tb_co_persona_cencosBL();
                        var BE = new tb_co_persona_cencosBE();
                        BE.item = Convert.ToInt32(CodigoCencos.ToString());
                        BE.cencosid = cencosid.Text.Trim().ToString();
                        BE.cencosestacion = estacion.Text.Trim();
                        BE.perdni = perddnni.Text.Trim();
                        BE.cencosestado = false;

                        if (BL.Delete(EmpresaID, BE))
                        {
                            SEGURIDAD_LOG("E");
                            MessageBox.Show("Datos eliminados correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Data_TablaPersona();
                            NIVEL_FORMS();
                            limpiar_documento();
                            form_bloqueado(false);

                            perddnni.Enabled = false;
                            btn_nuevo.Enabled = true;

                            btn_salir.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_productos_Load(object sender, EventArgs e)
        {
            EmpresaID = VariablesPublicas.EmpresaID;
            NIVEL_FORMS();

            TablaPersona = new DataTable();

            TablaPersona.Columns.Add("CCosto", typeof(String));
            TablaPersona.Columns.Add("Estacion", typeof(String));
            TablaPersona.Columns.Add("DNI", typeof(String));
            TablaPersona.Columns.Add("Persona", typeof(String));
            TablaPersona.Columns.Add("Fecha", typeof(DateTime));

            Data_TablaPersona();

            limpiar_documento();
            form_bloqueado(false);
            perddnni.Enabled = false;
            btn_nuevo.Enabled = true;
            btn_salir.Enabled = true;

            cenestado.Items.Clear();
            cenestado.Items.AddRange("Inactivos,Activos".Split(new char[] { ',' }));
            cenestado.SelectedIndex = 1;
        }

        private void Frm_productos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
            }

            if (e.Control && e.KeyCode == Keys.G)
            {
                if (btn_grabar.Enabled)
                {
                    btn_grabar_Click(sender, e);
                }
            }

            if (e.Control && e.KeyCode == Keys.N)
            {
                if (btn_nuevo.Enabled)
                {
                    btn_nuevo_Click(sender, e);
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

        private void titulo_TextChanged(object sender, EventArgs e)
        {
        }

        private void Data_TablaPersona()
        {
            try
            {
                var BL = new tb_co_persona_cencosBL();
                var BE = new tb_co_persona_cencosBE();

                TablaPersona = BL.GetAll(EmpresaID, BE).Tables[0];

                if (TablaPersona.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    DataPersonaCencos.DataSource = TablaPersona;
                    DataPersonaCencos.Rows[0].Selected = false;
                    DataPersonaCencos.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Busqueda()
        {
            try
            {
                var BL = new tb_co_persona_cencosBL();
                var BE = new tb_co_persona_cencosBE();

                BE.cencosid = cencosid.Text.Trim().ToString();
                BE.pername = txtbuscar.Text.Trim().ToString();
                BE.tipo = cenestado.SelectedIndex;
                BE.cencosname = txtcencosname.Text.Trim().ToString();

                TablaPersona = BL.GetOne(EmpresaID, BE).Tables[0];

                if (TablaPersona.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    DataPersonaCencos.DataSource = TablaPersona;
                    DataPersonaCencos.Rows[0].Selected = false;
                    DataPersonaCencos.Focus();
                }
                else
                {
                    DataPersonaCencos.DataSource = TablaPersona;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
            {
                nuevo();
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0")
            {
                ssModo = "EDIT";
                form_bloqueado(true);
                cencosid.Enabled = false;
                btn_cancelar.Enabled = true;
                btn_grabar.Enabled = true;
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            form_accion_cancelEdicion(1);
        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {
            procesado = false;
            var sw_prosigue = false;
            if (ssModo == "NEW")
            {
                if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
                {
                    Insert();
                }
            }
            else
            {
                if (XNIVEL == "0" || XNIVEL == "1")
                {
                    sw_prosigue = (MessageBox.Show("¿Desea Modificar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                    if (sw_prosigue)
                    {
                        Update();
                    }
                }
            }
            if (procesado)
            {
                NIVEL_FORMS();
                form_bloqueado(false);
                perddnni.Enabled = false;
                btn_nuevo.Enabled = true;
                btn_salir.Enabled = true;
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0")
            {
                var sw_prosigue = false;
                sw_prosigue = (MessageBox.Show("¿Desea Eliminar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                if (sw_prosigue)
                {
                    Delete();
                }
            }
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                var miForma = new REPORTES.Frm_reportes();

                miForma.dominioid = dominio.Trim();
                miForma.moduloid = modulo.Trim();
                miForma.local = local.Trim();

                miForma.Text = "Reporte de Productos";
                miForma.formulario = "Frm_producto";
                miForma.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_log_Click(object sender, EventArgs e)
        {
            var oform = new Seguridadlog.FrmSeguridad();
            var xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio + "/";
            oform._Nombre = Name;
            oform._ClaveForm = xclave;
            oform.Owner = this;
            oform.ShowDialog();
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cencosid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaCentroCosto();
                btn_busqueda.PerformClick();
            }

            if (e.KeyCode == Keys.Enter)
            {
                ValidaCentrocosto(cencosid.Text.ToString(), false);
                btn_busqueda.PerformClick();
                estacion.Focus();
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
                        estacion.Text = string.Empty;
                        perddnni.Text = string.Empty;
                        pername.Text = string.Empty;
                        perddnni.Focus();
                    }
                }
            }
        }

        private void estacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var numdo = string.Empty;
                if (estacion.Text.Trim().Length > 0)
                {
                    numdo = estacion.Text.Trim().PadLeft(3, '0');
                }
                estacion.Text = numdo;
                perddnni.Focus();
            }
        }

        private void DataPersonaCencos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DataPersonaCencos.CurrentRow != null)
                {
                    var xcencosid = string.Empty;
                    var xdni = string.Empty;
                    xcencosid = DataPersonaCencos.Rows[e.RowIndex].Cells["cencosi"].Value.ToString().Trim();
                    xdni = DataPersonaCencos.Rows[e.RowIndex].Cells["dni"].Value.ToString().Trim();
                    CodigoCencos = DataPersonaCencos.Rows[e.RowIndex].Cells["item"].Value.ToString().Trim();
                    data_persona(xcencosid, xdni);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void data_persona(String xcencosid, String xddni)
        {
            form_bloqueado(false);
            var rowcolorid = TablaPersona.Select("cencosid='" + xcencosid + "' and perdni = '" + xddni + " '");
            if (rowcolorid.Length > 0)
            {
                foreach (DataRow row in rowcolorid)
                {
                    cencosid.Text = row["cencosid"].ToString().Trim();
                    cencosname.Text = row["cencosname"].ToString().Trim();
                    estacion.Text = row["cencosestacion"].ToString().Trim();
                    perddnni.Text = row["perdni"].ToString().Trim();
                    pername.Text = row["nombrelargo"].ToString().Trim();
                    fechadoc.Text = row["cencosfecha"].ToString().Trim();
                }

                btn_nuevo.Enabled = true;
                btn_editar.Enabled = true;
                btn_eliminar.Enabled = true;
                btn_imprimir.Enabled = true;
                btn_salir.Enabled = true;
            }
        }

        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            Busqueda();
            btn_editar.Enabled = false;
        }

        private void txtbuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_busqueda_Click(sender, e);
            }
        }

        private void DataPersonaCencos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                var xcencosid = string.Empty;
                var xdni = string.Empty;
                xcencosid = DataPersonaCencos.Rows[DataPersonaCencos.CurrentRow.Index].Cells["cencosi"].Value.ToString().Trim();
                xdni = DataPersonaCencos.Rows[DataPersonaCencos.CurrentRow.Index].Cells["dni"].Value.ToString().Trim();
                CodigoCencos = DataPersonaCencos.Rows[DataPersonaCencos.CurrentRow.Index].Cells["item"].Value.ToString().Trim();
                data_persona(xcencosid, xdni);
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
                txtbuscar.Focus();
            }
        }

        private void DataPersonaCencos_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataPersonaCencos[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }

        private void DataPersonaCencos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataPersonaCencos[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            DataPersonaCencos[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            DataPersonaCencos.EnableHeadersVisualStyles = false;
            DataPersonaCencos.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            DataPersonaCencos.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void txtcencosname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_busqueda.PerformClick();
            }
        }
    }
}
