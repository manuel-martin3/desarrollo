//*****************************************************************
// AUTOR    : Angel Galarza
// Objetivo : CONTROL DE ACCESOS A CIERTOS PROCESO
// Módulo   : SEGURIDAD
// Updated  : 03.06.2013
//*****************************************************************
using Microsoft.VisualBasic;
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
using BapFormulariosNet.Codigo;
using BapFormulariosNet.Ayudas;
using BapFormulariosNet.Seguridadlog;

namespace BapFormulariosNet.DS0Seguridad
{
    public partial class Frm_UsuariosxProcesos : plantilla
    {
        bool sw_load = true;
        DataTable oDetalle = new DataTable();
        private TextBox CellUser = null;
        private string direc = "";

        public Frm_UsuariosxProcesos()
        {
            InitializeComponent();
            Load += Frm_UsuariosxProcesos_Load;
            //KeyDown += Frm_UsuariosxProcesos_KeyDown;
            Activated += Frm_UsuariosxProcesos_Activated;

        }

        #region "Llenado de Combobox"
        void llenar_cbocboProceso()
        {
            try
            {
                cboProceso.DataSource = NewMethodPr();
                cboProceso.DisplayMember = "Value";
                cboProceso.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethodPr()
        {
            usuariosxprocesoBL BL = new usuariosxprocesoBL();
            tb_usuariosxproceso BE = new tb_usuariosxproceso();

            BE.norden = 1;
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
        #endregion

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargaData();
        }
        public void CargaData()
        {
            string CodProceso = "..";
            if (cboProceso.SelectedValue != null)
            {
                CodProceso = cboProceso.SelectedValue.ToString();
            }

            dgOrdenes.DataSource = null;
            
            usuariosxprocesoBL BL = new usuariosxprocesoBL();
            tb_usuariosxproceso BE = new tb_usuariosxproceso();

            BE.procesoid = CodProceso;
            BE.norden = 1;
            oDetalle = BL.GetAll_U_P(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            //oDetalle = ocapa.UsuariosProcesoGetAll(CodProceso, "", "", 1, "");

            dgOrdenes.AutoGenerateColumns = false;
            dgOrdenes.Columns["Column5"].DataPropertyName = "uprocesoid";
            dgOrdenes.Columns["Column1"].DataPropertyName = "usuar";
            dgOrdenes.Columns["Column2"].DataPropertyName = "nomusuario";
            dgOrdenes.Columns["Column3"].DataPropertyName = "password";
            dgOrdenes.Columns["Column6"].DataPropertyName = "firma";

            //Column6
            oDetalle.Columns["uprocesoid"].AllowDBNull = true;
            oDetalle.Columns["usuar"].AllowDBNull = true;
            oDetalle.Columns["nomusuario"].AllowDBNull = true;
            oDetalle.Columns["password"].AllowDBNull = true;
            oDetalle.Columns["FIRMA"].AllowDBNull = true;

            oDetalle.Columns["uprocesoid"].ReadOnly = false;
            oDetalle.Columns["usuar"].ReadOnly = false;
            oDetalle.Columns["nomusuario"].ReadOnly = false;
            oDetalle.Columns["password"].ReadOnly = false;
            oDetalle.Columns["firma"].ReadOnly = false;

            dgOrdenes.DataSource = oDetalle;
        }

        private void Frm_UsuariosxProcesos_Activated(object sender, EventArgs e)
        {
            if (sw_load)
            {
                sw_load = false;
            }
        }
        private void Frm_UsuariosxProcesos_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Fixed3D;
            //DataTable oData = new DataTable();
            //oData = ocapa.UsuariosTiposProcesoGetAll("", 2);
            //cboProceso.DisplayMember = "DESCRIPCION";
            //cboProceso.ValueMember = "CODIGO";
            //cboProceso.DataSource = oData;
            //if (oData.Rows.Count > 0)
            //{
            //    cboProceso.SelectedValue = oData.Rows[0]["CODIGO"];
            //}
            llenar_cbocboProceso();
            HabilitarBotones(true);
            HabilitarControles(true);
            CargaData();
        }

        private void cboProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!sw_load)
            {
                CargaData();
            }
        }

        private void PasaPassword(string Pass)
        {
            dgOrdenes["COLUMN3", dgOrdenes.CurrentCell.RowIndex].Value = Pass.Trim();
        }

        private void dgOrdenes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgOrdenes.Rows.Count > 0)
            {
                if (dgOrdenes.CurrentRow != null)
                {
                    switch (dgOrdenes.Columns[dgOrdenes.CurrentCell.ColumnIndex].Name.ToUpper().Trim())
                    {
                        case "COLUMN1":
                            if (GlobalVars.GetInstance().AyudaItemOC == true)
                            {
                                Frm_AyudaUsuarios frm = new Frm_AyudaUsuarios();
                                frm._PasaUsuarios = PasaUsuarios;
                                frm.ShowDialog();
                                GlobalVars.GetInstance().AyudaItemOC = false;
                            }
                            else
                            {
                                if (dgOrdenes[e.ColumnIndex, e.RowIndex].Value.ToString().Trim().Length > 0)
                                {
                                    //dgOrdenes[e.ColumnIndex, e.RowIndex].Value = VariablesPublicas.FormateaNumeroaCadena2(dgOrdenes[e.ColumnIndex, e.RowIndex].Value.ToString().Trim(), 3, "0", true);
                                }
                                if (ValidarUsuario(e.RowIndex, true) == true)
                                {
                                    ValidarUnicoUsuario(e.RowIndex);
                                }
                            }
                            break;
                    }
                }
            }
        }

        private void dgOrdenes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgOrdenes.Rows.Count > 0)
            {
                if (e.RowIndex > -1)
                {
                    if (dgOrdenes.CurrentRow != null)
                    {
                        if (dgOrdenes.Columns[e.ColumnIndex].Name.ToUpper().Trim() == "COLUMN4")
                        {
                            Frm_IngresarPassword frm = new Frm_IngresarPassword();
                            frm._SoloLectura = dgOrdenes.ReadOnly;
                            frm._Pass = dgOrdenes["COLUMN3", e.RowIndex].Value.ToString().Trim();
                            frm.PasaPassword = PasaPassword;
                            frm.ShowDialog();
                        }

                        if (dgOrdenes.Columns[e.ColumnIndex].Name.ToUpper().Trim() == "COLUMN7")
                        {
                            Frm_SeleccionImagen frm = new Frm_SeleccionImagen();
                            frm.Text = "Elegir Firma";
                            frm._SoloLectura = dgOrdenes.ReadOnly;
                            frm._RutaImagen = dgOrdenes["COLUMN6", e.RowIndex].Value.ToString().Trim();
                            frm._PasaRutaImagen = RutaImagen;
                            frm.ShowDialog();
                        }
                    }
                }
            }
        }

        private void RutaImagen(string RutaImagen)
        {
            dgOrdenes["COLUMN6", dgOrdenes.CurrentCell.RowIndex].Value = RutaImagen.Trim();
        }

        private void btnNuevaFila_Click(object sender, EventArgs e)
        {
            NuevaFila();
        }
        public void NuevaFila()
        {
            oDetalle.Rows.Add(VariablesPublicas.InsertIntoTable(oDetalle));
            dgOrdenes.CurrentCell = dgOrdenes["Column1", dgOrdenes.Rows.Count - 1];
            dgOrdenes.Focus();
            dgOrdenes.BeginEdit(false);
        }

        private void btnEliminarFila_Click(object sender, EventArgs e)
        {
            EliminarFila();
        }
        public void EliminarFila()
        {
            if (dgOrdenes.CurrentRow != null)
            {
                if (MessageBox.Show("Realmente Desea Eliminar la Fila Seleccionada...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    oDetalle.Rows.RemoveAt(dgOrdenes.CurrentRow.Index);
                }
            }
            else
            {
                MessageBox.Show("No Hay una Fila Seleccionada...?", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void HabilitarBotones(bool B)
        {
            btnFiltrar.Enabled = B;
            btnEditar.Enabled = B;
            btnEliminarFila.Enabled = !B;
            btnNuevaFila.Enabled = !B;
            btnCancelar.Enabled = !B;
            btnGuardar.Enabled = !B;
            btnReplicar.Enabled = !btnGuardar.Enabled;
        }
        public void HabilitarControles(bool B)
        {
            cboProceso.Enabled = B;
            //Column2
            dgOrdenes.ReadOnly = B;
            dgOrdenes.Columns["Column2"].ReadOnly = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCelda() == true)
            {
                Guardar();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarBotones(false);
            HabilitarControles(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarBotones(true);
            HabilitarControles(true);
            CargaData();
        }

        public void Guardar()
        {
            int ncont = 0;
            dgOrdenes.EndEdit();
            oDetalle.AcceptChanges();
            for (ncont = 0; ncont <= oDetalle.Rows.Count - 1; ncont++)
            {
                oDetalle.Rows[ncont]["uprocesoid"] = cboProceso.SelectedValue;
            }
            usuariosxprocesoBL BL = new usuariosxprocesoBL();
            tb_usuariosxproceso BE = new tb_usuariosxproceso();

            BE.procesoid = cboProceso.SelectedValue.ToString().Trim();
            BE.ntipo = 0;
            if (BL.UsuariosProcesosInsertUpdated(VariablesPublicas.EmpresaID.ToString(), BE, oDetalle) == true)
            {
                HabilitarBotones(true);
                HabilitarControles(true);
                CargaData();
            }
            else
            {
                Frm_Class.ShowError(BL.Sql_Error, this);
            }
        }

        private void ValidNum(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //if (Information.IsNumeric(e.KeyChar) | String.Asc(e.KeyChar) == 8)
            //{
            //    e.Handled = false;
            //}
            //else
            //{
            //    e.Handled = true;
            //}
        }

        private void dgOrdenes_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            switch (dgOrdenes.Columns[dgOrdenes.CurrentCell.ColumnIndex].Name.ToString().Trim())
            {
                case "COLUMN1":
                    ParametrosTextBox parUser = new ParametrosTextBox();
                    parUser.LengthText = 15;
                    parUser.LengthReal = 15;
                    CellUser = (TextBox)e.Control;
                    CellUser.Tag = parUser;
                    CellUser.MaxLength = 15;
                    CellUser.Text.Trim();
                    e.Control.KeyDown += VariablesPublicas.CapturaF1_OC_KeyPress;
                    //e.Control.KeyPress += ValidNum;

                    break;
            }
        }

        private void PasaUsuarios(string Codigo, string Nombre, string Sigla, string Usuario, string Clave)
        {
            int row = dgOrdenes.CurrentCell.RowIndex;
            dgOrdenes["Column1", row].Value = Codigo.Trim();
            dgOrdenes["Column2", row].Value = Nombre.Trim();

            if (1 == 0)
            {
                dgOrdenes["Column3", row].Value = Clave.Trim();
            }
            else
            {
                dgOrdenes["Column3", row].Value = "";
            }
            ValidarUnicoUsuario(row);
        }

        private bool ValidarUsuario(int row, bool inicializaclave)
        {
            string CodUser = "";
            bool zprocesar = false;
            if (!object.ReferenceEquals(dgOrdenes["Column1", row].Value.ToString().Trim(), DBNull.Value))
            {
                CodUser = dgOrdenes["Column1", row].Value.ToString().Trim();
            }

            if (CodUser.Trim().Length > 0)
            {
                DataTable dt = new DataTable();
                //dt = ocapa.icag06_consulta(CodUser, "", "", "", "", 1, 1);
                
                usuariosBL BL = new usuariosBL();
                tb_usuarios BE = new tb_usuarios();

                BE.usuar = CodUser.ToLower();
                dt = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                //if (BL.Sql_Error.Length == 0)
                //{
                    if (dt.Rows.Count > 0)
                    {
                        zprocesar = true;
                        //dgOrdenes["Column1", row].Value = Equivalencias.Mid(dt.Rows[0]["usuar"].ToString().Trim(), 1, oDetalle.Columns["usuar"].MaxLength);
                        //dgOrdenes["Column2", row].Value = Equivalencias.Mid(dt.Rows[0]["nombr"].ToString().Trim(), 1, oDetalle.Columns["NOMUSUARIO"].MaxLength);
                        dgOrdenes["Column1", row].Value = dt.Rows[0]["usuar"].ToString().Trim();
                        dgOrdenes["Column2", row].Value = dt.Rows[0]["nombr"].ToString().Trim();
                        if (inicializaclave)
                        {
                            dgOrdenes["Column3", row].Value = string.Empty;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El Usuario no Existe...", "Mensaje del Sistema");
                    }
                //}
            }
            if (!zprocesar)
            {
                dgOrdenes["Column1", row].Value = string.Empty;
                dgOrdenes["Column2", row].Value = string.Empty;
                dgOrdenes["Column3", row].Value = string.Empty;
            }
            return zprocesar;
        }

        private void dgOrdenes_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgOrdenes.Rows.Count > 0)
            {
                if (dgOrdenes.CurrentRow != null)
                {
                    if (dgOrdenes.ReadOnly == false)
                    {
                        if (e.KeyCode == Keys.F1)
                        {
                            switch (dgOrdenes.Columns[dgOrdenes.CurrentCell.ColumnIndex].Name.ToUpper().Trim())
                            {
                                case "COLUMN1":
                                    Frm_AyudaUsuarios frm = new Frm_AyudaUsuarios();
                                    frm._PasaUsuarios = PasaUsuarios;
                                    frm.ShowDialog();
                                    break;
                            }
                        }
                    }

                    if (e.KeyCode == Keys.Enter)
                    {
                        switch (dgOrdenes.Columns[dgOrdenes.CurrentCell.ColumnIndex].Name.ToUpper().Trim())
                        {
                            case "COLUMN4":
                                Frm_IngresarPassword frm = new Frm_IngresarPassword();
                                frm._SoloLectura = this.dgOrdenes.ReadOnly;
                                frm._Pass = dgOrdenes["COLUMN3", dgOrdenes.CurrentCell.RowIndex].Value.ToString().Trim();
                                frm.PasaPassword = PasaPassword;
                                frm.ShowDialog();
                                e.Handled = true;
                                break;
                            case "COLUMN7":
                                Frm_SeleccionImagen frm1 = new Frm_SeleccionImagen();
                                frm1.Text = "Elegir Firma";
                                frm1._SoloLectura = dgOrdenes.ReadOnly;
                                frm1._RutaImagen = dgOrdenes["COLUMN6", dgOrdenes.CurrentCell.RowIndex].Value.ToString().Trim();
                                frm1._PasaRutaImagen = RutaImagen;
                                frm1.ShowDialog();
                                e.Handled = true;
                                break;
                        }
                    }
                }
            }
        }

        private bool ValidarCelda()
        {
            dgOrdenes.EndEdit();
            bool Valor = true;

            if (dgOrdenes.Rows.Count > 0)
            {
                int f = 0;
                int c = 0;

                for (f = 0; f <= dgOrdenes.Rows.Count - 1; f++)
                {
                    if (Information.IsDBNull(dgOrdenes["COLUMN1", f].Value) == true)
                    {
                        dgOrdenes["COLUMN1", f].Value = string.Empty;
                    }
                                     
                     if (ValidarUsuario(f, false) == false) 
                     {
                         c = dgOrdenes["COLUMN1", f].ColumnIndex;
                         Valor = false;
                         break;
                     }
                     if (Information.IsDBNull(dgOrdenes["COLUMN2", f].Value) == true)
                     {
                         dgOrdenes["COLUMN2", f].Value = string.Empty;
                     }
                     if (Information.IsDBNull(dgOrdenes["COLUMN3", f].Value) == true) 
                     {
                         dgOrdenes["COLUMN3", f].Value = string.Empty;
                     }
                    //
                     if (Information.IsDBNull(dgOrdenes["COLUMN6", f].Value) == true)
                     {
                         dgOrdenes["COLUMN6", f].Value = String.Empty;
                     }
                }

                if (Valor == false)
                {
                    dgOrdenes[c, f].Selected = true;
                    dgOrdenes.Focus();
                }
            }
            return Valor;
        }

        public void ValidarUnicoUsuario(int row)
        {
            string Cod = null;
            int a = 0;
            Cod = dgOrdenes["COLUMN1", row].Value.ToString().Trim();
            for (a = 0; a <= dgOrdenes.CurrentCell.RowIndex; a++)
            {
                if (a != row)
                {
                    if (this.dgOrdenes["COLUMN1", a].Value.ToString().Trim() == Cod.Trim())
                    {
                        MessageBox.Show("El Usuario " + dgOrdenes["COLUMN2", a].Value.ToString().Trim() + " ya ha Sido Agregado", "Mensaje del Sistema");
                        dgOrdenes["Column1", row].Value = string.Empty;
                        dgOrdenes["Column2", row].Value = string.Empty;
                        dgOrdenes["Column3", row].Value = string.Empty;
                        dgOrdenes.CurrentCell = dgOrdenes.Rows[a].Cells["COLUMN1"];
                        break; 
                    }
                }
            }
        }

        private string ObtenerImagen(string ruta)
        {
            ofdImagen.Filter = "Archivos de Imagenes (*.jpg)|*.jpg|Archivos de Imagenes (*.gif)|*.gif|Archivos de Imagenes (*.bmp)|*.bmp";
            if (ofdImagen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ruta = ofdImagen.FileName;
                string nombre = ObtenerNombreArchivo(ruta);
                string ImagenAleatoria = "";
                if (direc.Trim() != GlobalVars.GetInstance().RutaServer.Trim())
                {
                    try
                    {
                        ImagenAleatoria = VariablesPublicas.Imagen_Aleatoria(GlobalVars.GetInstance().RutaServer.Trim(), nombre);
                    }
                    catch (Exception ex)
                    {
                    }
                    if (System.IO.File.Exists(ImagenAleatoria.Trim()) == false)
                    {
                        System.IO.File.Copy(ruta.Trim(), ImagenAleatoria.Trim());
                    }
                    ruta = ImagenAleatoria.Trim();
                }
            }
            return ruta.ToLower();
        }

        private string ObtenerNombreArchivo(string nom)
        {
            int n = 0;
            int pos = 0;
            for (n = 0; n <= nom.Length; n++)
            {
                if (Equivalencias.Mid(nom, nom.Length - n, 1) == "\\")
                {
                    pos = (nom.Length - n) + 1;
                    break; 
                }
            }
            direc = Equivalencias.Mid(nom, 1, pos - 1);
            return Equivalencias.Mid(nom, pos);
        }

        private void btnReplicar_Click(object sender, EventArgs e)
        {
            if (dgOrdenes.CurrentRow != null)
            {
                string xmensaje = "Usuario :" + dgOrdenes.Rows[dgOrdenes.CurrentRow.Index].Cells["COLUMN2"].Value;

                string message = "Desea replicar datos de " + xmensaje + " En Todos los procesos del sistema...?" + '\r' + "La información de accesos del usuario será reemplazada";
                string caption = "Mensaje del Sistema";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Muestra el cuadro de mensaje.
                result = MessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    usuariosxprocesoBL BL = new usuariosxprocesoBL();
                    tb_usuariosxproceso BE = new tb_usuariosxproceso();

                    BE.usuar = dgOrdenes.Rows[dgOrdenes.CurrentRow.Index].Cells["COLUMN1"].Value.ToString().Trim();
                    BE.procesoid = dgOrdenes.Rows[dgOrdenes.CurrentRow.Index].Cells["COLUMN5"].Value.ToString().Trim();
                    if (!BL.UsuariosProcesos_Replicar(VariablesPublicas.EmpresaID.ToString(), BE))
                    //if (!BL.UsuariosProcesos_Replicar(dgOrdenes.Rows[dgOrdenes.CurrentRow.Index].Cells["COLUMN1"].Value, dgOrdenes.Rows[dgOrdenes.CurrentRow.Index].Cells["COLUMN5"].Value))
                    {
                        Frm_Class.ShowError(BL.Sql_Error, this);
                    }
                    else
                    {
                        MessageBox.Show("Proceso culminado satisfactoriamente", "Mensaje del Sistema");
                    }
                }
            }
        }
    }
}
