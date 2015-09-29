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
using System.Net.Mail;
using System.Net;

using System.IO;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.Net.Sockets;

namespace BapFormulariosNet.MERCADERIA02.CATALOGO
{
    public partial class Frm_tarjeta : plantilla
    {
        /*** variables de cabecera del documento actual ***/
        String EmpresaID = VariablesPublicas.EmpresaID;
        String dominio = "60";
        String modulo = "";
        String local = "";
        String perianio = "";
        String perimes = "";

        String XNIVEL = "";
        String XGLOSA = "";
        String PERFILID = "";
        Genericas fungen = new Genericas();
        DataTable TablaTarjeta;

        Boolean fechadocedit = false;
        Boolean procesado = false;
        Boolean statusDoc = true;

        String ssModo = "NEW";

        public Frm_tarjeta()
        {
            InitializeComponent();
            tarjetaid.LostFocus += new System.EventHandler(Tarjetaid_LostFocus);
        }

        #region $$$ ADMINISTRADOR
        private void PARAMETROS_TABLA()
        {
            String xxferfil = "";
            MainMercaderia02 f = (MainMercaderia02)this.MdiParent;
            xxferfil = f.perfil.ToString();
            if (xxferfil.Trim().Length != 9)
            {
                MessageBox.Show("::: NO TIENE PERFIL !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PERFILID = xxferfil;
            String XTABLA_PERFIL = "";
            XTABLA_PERFIL = VariablesPublicas.GET_PARAMETROS_TABLA(xxferfil, Name);
            if (XTABLA_PERFIL.Trim().Length > 0 && XTABLA_PERFIL.Trim() != "0")
            {
                if (XTABLA_PERFIL.Trim().Length == 2)
                {
                    dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
                }
                else if (XTABLA_PERFIL.Trim().Length == 6)
                {
                    dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
                    modulo = XTABLA_PERFIL.Trim().Substring(2, 4);
                }
                else if (XTABLA_PERFIL.Trim().Length == 9)
                {
                    dominio = XTABLA_PERFIL.Trim().Substring(0, 2);
                    modulo = XTABLA_PERFIL.Trim().Substring(2, 4);
                    local = XTABLA_PERFIL.Trim().Substring(6, 3);
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
                Ayudas.Form_user_admin miForma = new Ayudas.Form_user_admin();
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
        #endregion

        #region *** Metodos generales

        private void form_bloqueado(Boolean var)
        {
            try
            {

                tarjetaid.Enabled = false;
                tarjetaname.Enabled = var;

                gridTarjeta.ReadOnly = true;
                gridTarjeta.Enabled = !var;
                txt_criterio.Enabled = !var;
                btn_busqueda.Enabled = !var;

                btn_nuevo.Enabled = false;
                btn_editar.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_grabar.Enabled = false;
                btn_eliminar.Enabled = false;
                btn_imprimir.Enabled = false;

                btn_primero.Enabled = false;
                btn_anterior.Enabled = false;
                btn_siguiente.Enabled = false;
                btn_ultimo.Enabled = false;

                btn_clave.Enabled = true;
                btn_log.Enabled = true;
                btn_salir.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void form_accion_cancelEdicion(int confirnar)
        {
            bool sw_prosigue = true;
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
                tarjetaid.Text = "";
                btn_nuevo.Enabled = true;
                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;
                btn_salir.Enabled = true;

                ssModo = "NEW";
            }
        }
        private void form_cargar_datos(String posicion)
        {
            try
            {
                tb_t1_tarjetaBL BL = new tb_t1_tarjetaBL();
                tb_t1_tarjeta BE = new tb_t1_tarjeta();
                DataTable dt = new DataTable();

                //BE.moduloid = modulo;
                //if (tarjetaid.Text.Trim().Length > 0)
                //{
                //    BE.Tarjetaid = tarjetaid.Text.Trim().PadLeft(3, '0');
                //}
                //BE.posicion = posicion.Trim();

                //dt = BL.GetAll_paginacion(EmpresaID, BE).Tables[0];

                //if (dt.Rows.Count > 0)
                //{
                //    limpiar_documento();
                //    ssModo = "EDIT";

                //    tarjetaid.Text = dt.Rows[0]["Tarjetaid"].ToString().Trim();
                //    tarjetaname.Text = dt.Rows[0]["Tarjetaname"].ToString().Trim();

                //    btn_editar.Enabled = true;
                //    btn_eliminar.Enabled = true;
                //    btn_imprimir.Enabled = true;

                //    btn_primero.Enabled = true;
                //    btn_anterior.Enabled = true;
                //    btn_siguiente.Enabled = true;
                //    btn_ultimo.Enabled = true;

                //    btn_log.Enabled = true;
                //    btn_salir.Enabled = true;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region *** Eventos
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
        

        #endregion

        #region *** Metodos que retornan datos
        public bool IsNumeric(String Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        #endregion

        #region *** Grid Ayuda general forms
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
        #endregion

        #region *** Metodos mantenimiento de datos
        private void SEGURIDAD_LOG(String accion)
        {
            String xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio;
            try
            {
                tb_co_seguridadlogBL BL = new tb_co_seguridadlogBL();
                tb_co_seguridadlog BE = new tb_co_seguridadlog();

                BE.moduloid = Name;
                BE.clave = xclave;
                BE.cuser = VariablesPublicas.Usuar;
                BE.fecha = DateTime.Now;
                BE.pc = VariablesPublicas.userip;
                BE.accion = accion.Trim();
                BE.detalle = tarjetaid.Text.Trim() + "/" + tarjetaname.Text.Trim().ToUpper()  + "/" + XGLOSA;

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
                tarjetaid.Text = "";
                tarjetaname.Text = "";
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
            tarjetaid.Text = "NEW";
            btn_cancelar.Enabled = true;
            btn_grabar.Enabled = true;
            btn_log.Enabled = true;
            tarjetaname.Focus();

            ssModo = "NEW";
        }
        private void Insert()
        {
            try
            {
                 if (tarjetaname.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese nombre de Tarjeta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    tb_t1_tarjetaBL BL = new tb_t1_tarjetaBL();
                    tb_t1_tarjeta BE = new tb_t1_tarjeta();

                    BE.tarjetaname = tarjetaname.Text.ToUpper();

                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    if (go_foto.Image != null)
                    {
                        go_foto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    BE.tarjetalogo = ms.GetBuffer();


                    if (BL.Insert(EmpresaID, BE))
                    {
                        MessageBox.Show("Datos Grabados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        procesado = true;
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
                if (tarjetaid.Text.Trim() == "")
                {
                    MessageBox.Show("Falta Codigo Tarjeta !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (tarjetaname.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Nombre de línea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    tb_t1_tarjetaBL BL = new tb_t1_tarjetaBL();
                    tb_t1_tarjeta BE = new tb_t1_tarjeta();

                    BE.tarjetaid = Convert.ToInt32(tarjetaid.Text.Trim());
                    BE.tarjetaname = tarjetaname.Text.ToUpper();

                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    if (go_foto.Image != null)
                    {
                        go_foto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    BE.tarjetalogo = ms.GetBuffer();

                    if (BL.Update(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("M");
                        MessageBox.Show("Datos Modificado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        procesado = true;
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
                if (tarjetaid.Text.Trim() == "" )
                {
                    MessageBox.Show("Falta Codigo Tarjeta !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    tb_t1_tarjetaBL BL = new tb_t1_tarjetaBL();
                    tb_t1_tarjeta BE = new tb_t1_tarjeta();

                    BE.tarjetaid = Convert.ToInt32(tarjetaid.Text.Trim());

                    if (BL.Delete(EmpresaID, BE))
                    {
                        SEGURIDAD_LOG("E");
                        MessageBox.Show("Datos Eliminados Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NIVEL_FORMS();
                        form_bloqueado(false);
                        data_TablaTarjeta();
                        btn_nuevo.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region *** Controles de usuarios

        private void Frm_Tarjeta_Load(object sender, EventArgs e)
        {
            if (this.Parent.Parent.Name == "MainProduccion")
            {
                modulo = ((D70Produccion.MainProduccion)MdiParent).moduloid;
                local = ((D70Produccion.MainProduccion)MdiParent).local;
                PERFILID = ((D70Produccion.MainProduccion)MdiParent).perfil;
            }

            if (this.Parent.Parent.Name == "MainMercaderia02")
            {
                modulo = ((MERCADERIA02.MainMercaderia02)MdiParent).moduloid;
                local = ((MERCADERIA02.MainMercaderia02)MdiParent).local;
                PERFILID = ((MERCADERIA02.MainMercaderia02)MdiParent).perfil;
            }
            NIVEL_FORMS();
            TablaTarjeta = new DataTable();

            tarjetaname.CharacterCasing = CharacterCasing.Upper;
            data_TablaTarjeta();
            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_primero.Enabled = true;
            btn_anterior.Enabled = true;
            btn_siguiente.Enabled = true;
            btn_ultimo.Enabled = true;
            btn_salir.Enabled = true;
        }
        private void Frm_Tarjeta_KeyDown(object sender, KeyEventArgs e)
        {           

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
                if (this.btn_cancelar.Enabled)
                {
                    form_accion_cancelEdicion(1);
                }
                else
                {
                    btn_salir_Click(sender, e);
                }
            }
        }

        private void Tarjetaid_LostFocus(object sender, System.EventArgs e)
        {
            form_cargar_datos("");
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
            // if (XNIVEL == "0" || XNIVEL == "1")
            if (XNIVEL == "0")
            {
                ssModo = "EDIT";
                form_bloqueado(true);
                tarjetaname.Focus();

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
            bool sw_prosigue = false;
            if (ssModo == "NEW")
            {
                if (XNIVEL == "0" || XNIVEL == "1" || XNIVEL == "2")
                    Insert();
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
                data_TablaTarjeta();
                form_bloqueado(false);

                btn_nuevo.Enabled = true;

                btn_primero.Enabled = true;
                btn_anterior.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_ultimo.Enabled = true;

                btn_salir.Enabled = true;
            }
        }
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (XNIVEL == "0")
            {
                bool sw_prosigue = false;
                sw_prosigue = (MessageBox.Show("¿Desea Eliminar Documento actual ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

                if (sw_prosigue)
                {
                    Delete();
                }
            }
        }

        
        private void btn_primero_Click(object sender, EventArgs e)
        {
            form_cargar_datos(Genericas.primero);
        }
        private void btn_anterior_Click(object sender, EventArgs e)
        {
            form_cargar_datos(Genericas.anterior);
        }
        private void btn_siguiente_Click(object sender, EventArgs e)
        {
            form_cargar_datos(Genericas.siguiente);
        }
        private void btn_ultimo_Click(object sender, EventArgs e)
        {
            form_cargar_datos(Genericas.ultimo);
        }
        private void btn_log_Click(object sender, EventArgs e)
        {
            Seguridadlog.FrmSeguridad oform = new Seguridadlog.FrmSeguridad();
            String xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio;
            oform._Nombre = Name;
            oform._ClaveForm = xclave;
            oform.Owner = this;
            oform.ShowDialog();
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region $$$ grid Tarjeta

        private void data_TablaTarjeta()
        {
            try
            {
                if (TablaTarjeta.Rows.Count > 0)
                    TablaTarjeta.Rows.Clear();
                tb_t1_tarjetaBL BL = new tb_t1_tarjetaBL();
                tb_t1_tarjeta BE = new tb_t1_tarjeta();

                BE.tarjetaname = txt_criterio.Text.Trim().ToUpper();

                TablaTarjeta = BL.GetAll2(EmpresaID, BE).Tables[0];
                if (TablaTarjeta.Rows.Count > 0)
                {
                    btn_imprimir.Enabled = true;
                    gridTarjeta.DataSource = TablaTarjeta;
                    gridTarjeta.Rows[0].Selected = false;
                    gridTarjeta.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void gridTarjeta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridTarjeta.CurrentRow != null)
                {
                    String xTarjetaid = "";
                    xTarjetaid = gridTarjeta.Rows[e.RowIndex].Cells["_tarjetaid"].Value.ToString().Trim();
                    data_Tarjeta(xTarjetaid);
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void gridTarjeta_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                String xTarjetaid = "";
                xTarjetaid = gridTarjeta.Rows[gridTarjeta.CurrentRow.Index].Cells["_tarjetaid"].Value.ToString().Trim();
                data_Tarjeta(xTarjetaid);
            }
        }

        private void gridTarjeta_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridTarjeta[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
            gridTarjeta[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);

            gridTarjeta.EnableHeadersVisualStyles = false;
            gridTarjeta.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            gridTarjeta.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void gridTarjeta_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            gridTarjeta[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Teal;
        }

        private void data_Tarjeta(String xTarjetaid)
        {
            form_bloqueado(false);
            DataRow[] rowTarjetaid = TablaTarjeta.Select("Tarjetaid='" + xTarjetaid + "'");
            if (rowTarjetaid.Length > 0)
            {
                foreach (DataRow row in rowTarjetaid)
                {
                    tarjetaid.Text = row["tarjetaid"].ToString().Trim();
                    tarjetaname.Text = row["tarjetaname"].ToString().Trim();

                    String fot = row["tarjetalogo"].ToString();

                    if ((row["tarjetalogo"].ToString()) != "")
                    {
                        go_foto.Visible = true;
                        go_foto.Image = null;
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        byte[] MyData1 = (byte[])(row["tarjetalogo"]);
                        ms.Write(MyData1, 0, MyData1.Length);

                        if (MyData1 != null && MyData1.Length != 0)
                        {
                            go_foto.Visible = true;
                            go_foto.Image = null;
                            // Se utiliza el MemoryStream para extraer la imagen                
                            ms.Write(MyData1, 0, MyData1.Length);
                            go_foto.Image = Image.FromStream(ms);

                        }
                        else
                        {
                            go_foto.Visible = false;
                            go_foto.ImageLocation = "";
                        }
                    }
                    else
                    {
                        go_foto.Visible = false;
                        go_foto.ImageLocation = "";
                    }

                    btn_nuevo.Enabled = true;
                    btn_editar.Enabled = true;
                    btn_eliminar.Enabled = true;
                    btn_imprimir.Enabled = true;

                    btn_primero.Enabled = true;
                    btn_anterior.Enabled = true;
                    btn_siguiente.Enabled = true;
                    btn_ultimo.Enabled = true;

                    btn_log.Enabled = true;
                    btn_salir.Enabled = true;
                }
            }
        }

        #endregion

        #region $$$ busqueda
        private void btn_busqueda_Click(object sender, EventArgs e)
        {
            data_TablaTarjeta();
        }
        #endregion

        private void txt_criterio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_busqueda_Click(sender, e);
            }
        }
        #endregion

        private void txt_criterio_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_foto_Click(object sender, EventArgs e)
        {
            try
            {
                Int16 xHeight = 128;
                Int16 xWidth = 99;
                String xfoto = "";
                String xpath = "";
                String xexts = "";
                String xfilePath = "";

                Stream myStream = null;
                OpenFileDialog openFoto = new OpenFileDialog();

                openFoto.InitialDirectory = "c:\\";
                openFoto.Title = "Seleccionar Foto ";
                openFoto.CheckFileExists = true;
                openFoto.CheckPathExists = true;

                openFoto.DefaultExt = "jpg";
                openFoto.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                openFoto.FilterIndex = 1;
                //openFoto.Multiselect = false;
                openFoto.RestoreDirectory = true;
                openFoto.ReadOnlyChecked = true;
                openFoto.ShowReadOnly = true;

                if (openFoto.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = openFoto.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            Image originalImage = Image.FromFile(openFoto.FileName);
                            originalImage = fungen.CambiarTamanoImagen(originalImage, 75, 94);

                            go_foto.Visible = true;
                            go_foto.Image = originalImage;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridTarjeta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
    }
}