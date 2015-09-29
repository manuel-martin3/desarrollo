//************************************************
// AUTOR    : Miguel Ayte
// Objetivo : Tipo de Cambio - SUNAT
// Módulo   : ADMINISTRATIVO
// Updated  : SABADO 31.03.2012
//************************************************
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
using System.Web;
using System.Net;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
//using BapFormulariosNet.DA0CONTABILIDAD.ReportesContabilidad;
using BapFormulariosNet.Codigo;
using DevExpress.XtraEditors;
//using MSXML2;

namespace BapFormulariosNet.Generales
{
    public partial class Frm_tipocambio : plantilla
    {
        DataTable Tabla = new DataTable();
        bool Sw_LOad = true;
        int u_n_opsel = 0;
        private int Fase = 0;
        string j_Fecha = "";
        DataTable tmpcursor = new DataTable();
        DataTable tmptabla = new DataTable();
        string xnomcampo = "";
        string j_comprA = "";
        string J_VENTA = "";
        int lc_cont = 0;
        string j_Sigla = "";
        private CookieContainer myCookie;
        private string sMes = "";
        private string sAnho = "";
        //const string baseUrisbs = "http://www.sbs.gob.pe/0/modulos/jer/jer_interna.aspx?are=0&pfl=0&jer=147";
        const string baseUrisbs = "http://www.sbs.gob.pe";

        public Frm_tipocambio()
        {
            Fase = 0;
            InitializeComponent();

            //panel1.Visible = false;
            //panel2.Visible = false;

            txtfecha.LostFocus += new System.EventHandler(txtfecha_LostFocus);
            txtfecha.GotFocus += new System.EventHandler(txtfecha_GotFocus);

            txtcompra.LostFocus += new System.EventHandler(txtcompra_LostFocus);
            txtcompra.GotFocus += new System.EventHandler(txtcompra_GotFocus);

            txtventa.LostFocus += new System.EventHandler(txtventa_LostFocus);
            txtventa.GotFocus += new System.EventHandler(txtventa_GotFocus);
        }

        public void configurarGrid()
        {
            GridExaminar.RowsDefaultCellStyle.BackColor = Color.FromArgb(221, 236, 254); //Color.LightYellow;
            GridExaminar.AlternatingRowsDefaultCellStyle.BackColor = Color.White; // Color.FromArgb(132, 171, 228); //Color.FromArgb(224, 224, 224); //Color.LightGreen; //

            GridTipocambio.RowsDefaultCellStyle.BackColor = Color.LightYellow;
            GridTipocambio.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGreen;
        }

        private Boolean ValidarCertificado(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        private void Frm_TipoCambio_Load(object sender, EventArgs e)
        {
            Text = "Tipo de Cambio  -  " + VariablesPublicas.SiconexionInternet;
            configurarGrid();
            CargaDatos();
            POnedatos();
            Sw_LOad = false;
            if (GridExaminar.RowCount > 0)
            {
                GridExaminar.Focus();
                GridExaminar.BeginEdit(true);
            }
            U_RefrescaControles();
            VariablesPublicas.PintaEncabezados(GridExaminar);
            VariablesPublicas.PintaEncabezados(GridTipocambio);

            try
            {
                dpConsulta.Format = DateTimePickerFormat.Custom;
                dpConsulta.CustomFormat = "MM-yyyy";
                dpConsulta.Value = DateTime.Now;

                sAnho = dpConsulta.Value.ToString("yyyy");
                sMes = dpConsulta.Value.ToString("MM");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (VariablesPublicas.funConexion() == true)
            {
                webbrowser_link();
                try
                {
                    myCookie = null;
                    myCookie = new CookieContainer();

                    //Permitir SSL
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(ValidarCertificado);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                string lc_Texto = "";
                int ln_PosIni = 0; int ln_PosFin = 0;
                string codeHtmlsbs = string.Empty;
                
                HttpWebRequest connection = (HttpWebRequest)HttpWebRequest.Create(baseUrisbs);
                connection.Method = "GET";
                connection.CookieContainer = myCookie;
                connection.Credentials = CredentialCache.DefaultCredentials;
                connection.Proxy = null;
                HttpWebResponse response = (HttpWebResponse)connection.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                codeHtmlsbs = HttpUtility.HtmlDecode(sr.ReadToEnd());

                ln_PosIni = Strings.InStr(codeHtmlsbs, "WEB_CONTE_datos");
                ln_PosFin = Strings.InStr(codeHtmlsbs, "WEB_CONTE_cabeceraInferior");

                if (ln_PosIni != 0 | ln_PosFin != 0)
                {
                    lc_Texto = Strings.Mid(codeHtmlsbs, ln_PosIni, ln_PosFin - ln_PosIni);
                    lc_Texto = HtmlRemoval.StripTagsRegex(lc_Texto);
                    lc_Texto = HtmlRemoval.StripTagsRegexCompiled(lc_Texto);
                    lc_Texto = HtmlRemoval.StripTagsCharArray(lc_Texto);
                    string[] _split = lc_Texto.Split(new char[] { '<', '>', '\n', '\r' });
                    List<string> _resul = new List<string>();

                    //quitamos todos los caracteres nulos y convertirmos todo utf8
                    for (int i = 0; i < _split.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(_split[i].Trim()))
                        {
                            _resul.Add(_split[i].Trim());
                        }
                    }
                    lblTitulo.Text = _resul[1];
                    lblFecha.Text = _resul[2];
                    lblMoneda.Text = _resul[3] + " " + _resul[4];
                    txtCompra_SBS.Text = Convert.ToDecimal(_resul[6]).ToString("#0.0000");
                    txtVenta_SBS.Text = Convert.ToDecimal(_resul[8]).ToString("#0.0000");
                    sr.Close();
                }
                else
                {
                    lblTitulo.Text = "No se obtuvo datos";
                    lblFecha.Text = "";
                    lblMoneda.Text = "";
                    txtCompra_SBS.Text = "0.0000";
                    txtVenta_SBS.Text = "0.0000";
                }
            }
            else
            {
                wbTipoCambioSunat.Navigate("");
            }
        }
        
        private void Frm_TipoCambio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (btnnew.Enabled)
                {
                    Accion(1);
                }
            }
            if (e.KeyCode == Keys.F3)
            {
                if (btnedit.Enabled)
                {
                    Accion(2);
                }
            }
            if (e.KeyCode == Keys.F8)
            {
                if (btndelete.Enabled)
                {
                    Accion(3);
                }
            }
            if (e.Control & e.KeyCode == Keys.G)
            {
                if (btnsave.Enabled)
                {
                    save();
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (btnredo.Enabled)
                {
                    U_CancelarEdicion(1);
                }
                else
                {
                    Close();
                }
            }
            if (e.KeyCode == Keys.F4)
            {
                if (GridExaminar.Enabled)
                {
                    GridExaminar.Focus();
                }
            }
            if (e.KeyCode == Keys.F5)
            {
                if (btnLoad.Enabled)
                {
                    U_CancelarEdicion(0);
                }
            }
        }
        private void Frm_TipoCambio_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (u_n_opsel > 0)
            {
                XtraMessageBox.Show("Finalice edición para cerrar formulario", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void llenar_gridtipocambio()
        {
            try
            {
                tipocambioBL BL = new tipocambioBL();
                tb_tipocambio BE = new tb_tipocambio();

                BE.perianio = VariablesPublicas.perianio.ToString();

                Tabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargaDatos()
        {
            SortOrder sorted = default(SortOrder);
            string xnomcolumna = "";
            if ((GridExaminar.SortedColumn != null))
            {
                xnomcolumna = GridExaminar.Columns[GridExaminar.SortedColumn.Index].Name;
                sorted = GridExaminar.SortOrder;
            }

            llenar_gridtipocambio();
            GridExaminar.AutoGenerateColumns = false;
            GridExaminar.DataSource = Tabla;
            if (xnomcolumna.Trim().Length > 0)
            {
                if (sorted == SortOrder.Descending)
                {
                    GridExaminar.Sort(GridExaminar.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Descending);
                }
                else
                {
                    GridExaminar.Sort(GridExaminar.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Ascending);
                }
            }
            else
            {
                GridExaminar.Sort(GridExaminar.Columns["fecha"], System.ComponentModel.ListSortDirection.Descending);
            }
        }
        private void POnedatos()
        {
            Blanquear();
            if ((GridExaminar.CurrentRow != null))
            {
                txtfecha.Text = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["fecha"].Value.ToString();
                txtcompra.Text = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["compra"].Value.ToString();
                txtventa.Text = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["venta"].Value.ToString();
                txtpromedio.Text = GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["promedio"].Value.ToString();
            }
        }
        private void U_RefrescaControles()
        {
            string xcoduser = "";
            decimal npos = -1;
            if ((GridExaminar.CurrentRow != null))
            {
                xcoduser = GridExaminar.Rows[GridExaminar.CurrentCell.RowIndex].Cells["fecha"].Value.ToString();
                if (xcoduser.Trim().Length > 0)
                {
                    npos = VariablesPublicas.BuscarEnTable(xcoduser, "fecha", Tabla);
                }
            }

            txtfecha.Enabled = u_n_opsel == 1;
            txtcompra.Enabled = u_n_opsel > 0;
            txtventa.Enabled = u_n_opsel > 0;
            txtpromedio.Enabled = false;
            // Botonera
            btnnew.Enabled = u_n_opsel == 0;
            btnedit.Enabled = u_n_opsel == 0; // &npos > -1;
            btnsave.Enabled = u_n_opsel > 0;
            btnredo.Enabled = u_n_opsel > 0;
            btndelete.Enabled = u_n_opsel == 0; // & npos > -1;
            btnprint.Enabled = u_n_opsel == 0;
            btnLoad.Enabled = u_n_opsel == 0;
            btnexit.Enabled = u_n_opsel == 0;
            
            //btnInicial.Enabled = u_n_opsel == 0;
            //btnAnterior.Enabled = u_n_opsel == 0;
            //btnSiguiente.Enabled = u_n_opsel == 0;
            //btnUltimo.Enabled = u_n_opsel == 0;
            // Campos 
            GridExaminar.Enabled = u_n_opsel == 0;
            btngrabartcambiosunat.Enabled = GridTipocambio.RowCount > 0;
        }
        public void Blanquear()
        {
            txtfecha.Text = "";
            txtcompra.Text = "";
            txtventa.Text = "";
            txtpromedio.Text = "";
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Quieres cerrar el formulario?", "Mensaje de Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            Accion(1);
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            Accion(2);
        }

        private void Accion(int naccion)
        {
            switch (naccion)
            {
                case 1:
                    u_n_opsel = 1;
                    U_RefrescaControles();
                    Blanquear();
                    txtfecha.Text = Equivalencias.Mid(DateTime.Now.ToString(), 1, 10);
                    if ((GridExaminar.CurrentRow != null))
                    {
                        GridExaminar.CurrentRow.Selected = false;
                    }
                    txtcompra.Focus();
                    break;
                case 2:
                    j_Fecha = txtfecha.Text;
                    POnedatos();
                    u_n_opsel = 2;
                    U_RefrescaControles();
                    GridExaminar.CurrentRow.Selected = true;
                    j_Sigla = txtcompra.Text;
                    txtcompra.Focus();
                    break;
                case 3:
                    xnomcampo = "";
                    if ((GridExaminar.CurrentRow != null))
                    {
                        if (xnomcampo.Length == 0)
                        {
                            if (XtraMessageBox.Show("Desea Eliminar Registro ...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                for (lc_cont = 0; lc_cont <= Tabla.Rows.Count - 1; lc_cont++)
                                {
                                    if (Tabla.Rows[lc_cont]["fecha"] == GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["fecha"].Value)
                                    {
                                        Tabla.Rows[lc_cont].Delete();
                                        Tabla.AcceptChanges();
                                        break;
                                    }
                                }

                                if ((GridExaminar.CurrentRow != null))
                                {
                                    try
                                    {
                                        tipocambioBL BL = new tipocambioBL();
                                        tb_tipocambio BE = new tb_tipocambio();

                                        BE.anio = Convert.ToInt16(VariablesPublicas.perianio.ToString());
                                        BE.fecha = Convert.ToDateTime(GridExaminar.Rows[GridExaminar.CurrentRow.Index].Cells["fecha"].Value.ToString());

                                        if (!BL.Delete(VariablesPublicas.EmpresaID.ToString(), BE))
                                        {
                                            XtraMessageBox.Show("Contacte con sistemas", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                                //GridExaminar.Rows.Remove(GridExaminar.Rows[GridExaminar.CurrentRow.Index]);
                                GridExaminar.Refresh();
                                Tabla.AcceptChanges();
                                U_CancelarEdicion(0);
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show(xnomcampo, "Imposible eliminar documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            save();
        }
        private void save()
        {
            if (u_Validate())
            {
                try
                {
                    tipocambioBL BL = new tipocambioBL();
                    tb_tipocambio BE = new tb_tipocambio();

                    DateTime zfecha=Convert.ToDateTime(txtfecha.Text);

                    BE.fecha = zfecha;
                    BE.perianio = VariablesPublicas.PADL(zfecha.Date.Year.ToString(), 4, "0");
                    BE.perimes = VariablesPublicas.PADL(zfecha.Date.Month.ToString(), 2, "0");
                    
                    BE.compra = Convert.ToDecimal(txtcompra.Text);
                    BE.venta = Convert.ToDecimal(txtventa.Text);
                    BE.promedio = (BE.compra + BE.venta) / 2;
                    BE.usuar = VariablesPublicas.Usuar.Trim();

                    if (u_n_opsel == 1)
                    {
                        if (BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE))
                        {
                            U_CancelarEdicion(0);
                            //MessageBox.Show("Se grabó con éxito", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Contacte con sistemas", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        if (BL.Update(VariablesPublicas.EmpresaID.ToString(), BE))
                        {
                            U_CancelarEdicion(0);
                            //MessageBox.Show("Se grabó con éxito", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("Contacte con sistemas", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }                   
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool u_Validate()
        {
            string xmsg = "";
            object xobjeto = new object();
            if (txtfecha.Text.Trim().Length == 0)
            {
                xmsg = xmsg + "Ingrese fecha" + Equivalencias.Chr(13);
                xobjeto = txtfecha;
            }
            if (txtfecha.Text.Trim().Length > 0)
            {
                if (!Equivalencias.IsDate(txtfecha.Text))
                {
                    xmsg = xmsg + "Fecha inválida" + Equivalencias.Chr(13);
                    xobjeto = txtfecha;
                }
                xobjeto = txtfecha;
            }
            if (!Equivalencias.IsNumeric(txtcompra.Text.Trim()))
            {
                xmsg = xmsg + "Falta tipo de cambio compra" + Equivalencias.Chr(13);
                xobjeto = txtcompra;
            }

            if (!Equivalencias.IsNumeric(txtventa.Text.Trim()))
            {
                xmsg = xmsg + "Falta tipo de cambio venta" + Equivalencias.Chr(13);
                xobjeto = txtventa;
            }
            if (u_n_opsel == 1 | !(txtfecha.Text == j_Fecha))
            {
                try
                {
                    tipocambioBL BL = new tipocambioBL();
                    tb_tipocambio BE = new tb_tipocambio();

                    BE.anio = Convert.ToInt16(VariablesPublicas.perianio.ToString());
                    BE.fecha = Convert.ToDateTime(txtfecha.Text);

                    tmpcursor = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                    if (tmpcursor.Rows.Count > 0)
                    {
                        xmsg = "Fecha ya registrada";
                        xobjeto = txtfecha;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (!(xmsg.Trim().Length == 0))
            {
                XtraMessageBox.Show(xmsg, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if ((xobjeto != null))
                {
                    xobjeto = Focus();
                }
                if (Controls.ContainsKey("txtfecha"))
                {
                    Controls["txtfecha"].Focus();
                }
            }
            return xmsg.Trim().Length == 0;
        }

        private void btnredo_Click(object sender, EventArgs e)
        {
            U_CancelarEdicion(1);
        }
        private void U_CancelarEdicion(int SwConfirmacion)
        {
            string xtmpuser = "";
            bool sw_prosigue = true;
            if (SwConfirmacion == 1)
            {
                sw_prosigue = (XtraMessageBox.Show("Desea cancelar ingreso de datos...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
            }
            else
            {
                sw_prosigue = true;
            }

            if (sw_prosigue)
            {
                if ((tmpcursor != null))
                {
                    tmpcursor = Tabla;
                    try
                    {
                        int filaactual = 0;
                        filaactual = GridExaminar.CurrentRow.Index;
                        xtmpuser = GridExaminar.Rows[filaactual].Cells["fecha"].ToString();
                    }
                    catch (Exception ex)
                    {
                        xtmpuser = "..11";
                        XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                u_n_opsel = 0;
                U_RefrescaControles();
                CargaDatos();
                if (GridExaminar.RowCount > 0)
                {
                    for (lc_cont = 0; lc_cont <= GridExaminar.Rows.Count - 1; lc_cont++)
                    {
                        if (GridExaminar.Rows[lc_cont].Cells["fecha"].ToString() == xtmpuser)
                        {
                            GridExaminar.CurrentCell = GridExaminar.Rows[lc_cont].Cells["fecha"];
                            break;
                        }
                    }
                }
            }
            POnedatos();
            GridExaminar.Focus();
            if ((GridExaminar.CurrentCell != null))
            {
                GridExaminar.BeginEdit(true);
            }
        }

        private void gridtipocambio_SelectionChanged(object sender, EventArgs e)
        {
            if (!Sw_LOad & u_n_opsel == 0)
            {
                POnedatos();
                U_RefrescaControles();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            Accion(3);
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            U_CancelarEdicion(0);
        }
        
        private void txtfecha_GotFocus(object sender, System.EventArgs e)
        {
            j_Fecha = txtfecha.Text;
        }
        private void txtfecha_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_Fecha == txtfecha.Text) & !Sw_LOad)
            {
            }
        }

        private void txtcompra_GotFocus(object sender, System.EventArgs e)
        {
            j_comprA = txtcompra.Text;
        }
        private void txtcompra_LostFocus(object sender, System.EventArgs e)
        {
            if (!(j_comprA == txtcompra.Text) & !Sw_LOad)
            {
                decimal vmalor = VariablesPublicas.StringtoDecimal(txtcompra.Text);
                if (vmalor == 0)
                {
                    txtcompra.Text = "";
                }
                else
                {
                    txtcompra.Text = System.String.Format(vmalor.ToString(), "##.####");
                }
                u_CalculaPromedio();
            }
        }

        private void txtventa_GotFocus(object sender, System.EventArgs e)
        {
            J_VENTA = txtventa.Text;
        }
        private void txtventa_LostFocus(object sender, System.EventArgs e)
        {
            if (!(J_VENTA == txtventa.Text) & !Sw_LOad)
            {
                decimal vmalor = VariablesPublicas.StringtoDecimal(txtventa.Text);
                if (vmalor == 0)
                {
                    txtventa.Text = "";
                }
                else
                {
                    txtventa.Text = String.Format(vmalor.ToString(), "##.####");
                }
                u_CalculaPromedio();
            }
        }
        public void u_CalculaPromedio()
        {
            decimal vmalor1 = VariablesPublicas.StringtoDecimal(txtcompra.Text);
            decimal vmalor2 = VariablesPublicas.StringtoDecimal(txtventa.Text);
            decimal vmalor3 = Math.Round((vmalor1 + vmalor2) / 2, 4);
            if (vmalor3 == 0)
            {
                txtpromedio.Text = "";
            }
            else
            {
                txtpromedio.Text = String.Format(vmalor3.ToString(), "##.####");
            }
        }

        private void txtfecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtcompra.Focus();
            }
        }
        private void txtcompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtventa.Focus();
            }
        }
        private void txtventa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtfecha.Focus();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.sunat.gob.pe/cl-at-ittipcam/tcS01Alias");
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            // Si el control tiene el foco...
            if (keyData == Keys.Enter)
            {
                if (u_n_opsel > 0)
                {
                    SendKeys.Send("\t");
                    return true;
                }
                else
                {
                    if ((GridExaminar.CurrentRow != null))
                    {
                        if (GridExaminar.Focused)
                        {
                            return true;
                        }
                        else
                        {
                            SendKeys.Send("\t");
                            return true;
                        }
                    }
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnextraertcambio_Click(object sender, EventArgs e)
        {
            if (VariablesPublicas.compruebaConexion() == true)
            {
                Fase = 0;
                wbTipoCambioSunat.Navigate("http://www.sunat.gob.pe/cl-at-ittipcam/tcS01Alias");
            }
            #region Codigo Directo Consulta tipo de cambio mes actual
            //string lc_Texto = "";
            //int ln_PosIni = 0;
            //int ln_PosFin = 0;
            //int K = 0;

            //string codeHtml = string.Empty;
            //try
            //{
            //    String baseUri = "http://www.sunat.gob.pe/cl-at-ittipcam/tcS01Alias";
            //    HttpWebRequest connection = (HttpWebRequest)HttpWebRequest.Create(baseUri);
            //    connection.Method = "GET";
            //    HttpWebResponse response = (HttpWebResponse)connection.GetResponse();
            //    StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            //    codeHtml = sr.ReadToEnd();

            //    ln_PosIni = Strings.InStr(codeHtml, "D�a");
            //    ln_PosFin = Strings.InStr(codeHtml, "Para efectos");
            //    lc_Texto = Strings.Mid(codeHtml, ln_PosIni, ln_PosFin - ln_PosIni);
            //    ln_PosIni = Strings.InStrRev(lc_Texto, "Venta");
            //    lc_Texto = (Strings.Mid(lc_Texto, ln_PosIni + 6).Trim() + " ").Replace("\n", " ");
            //    ln_PosIni = Strings.InStrRev(lc_Texto, "/td>  ");
            //    lc_Texto = (Strings.Mid(lc_Texto, ln_PosIni + 5).Trim() + " ").Replace("\n", " ");
            //    lc_Texto = lc_Texto.Replace("\r", "");

            //    lc_Texto = HtmlRemoval.StripTagsRegex(lc_Texto);
            //    lc_Texto = HtmlRemoval.StripTagsRegexCompiled(lc_Texto);
            //    lc_Texto = HtmlRemoval.StripTagsCharArray(lc_Texto);
            //    lc_Texto = lc_Texto.Replace("                	  			                   		  ", "");
            //    lc_Texto = lc_Texto.Replace("														  ", "");
            //    lc_Texto = lc_Texto.Replace("                              		  ", " ");
            //    lc_Texto = lc_Texto.Replace("                         			                   		  ", " ");
            //    lc_Texto = lc_Texto.Replace("                              		  ", " ");
            //    lc_Texto = lc_Texto.Replace("                         			                                                             		  ", " ");
            //    lc_Texto = lc_Texto.Replace("                         			                                ", " ");
            //    lc_Texto = lc_Texto.Replace("                                        ", " ");
            //    lc_Texto = lc_Texto.Replace("          ", " ");

            //    sr.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error al Conectarse a Internet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    codeHtml = "";
            //}

            //SendKeys.Flush();

            //tmptabla = Tabla.Clone();
            //string lc_Cadena = "";
            //string xfecha = "";
            //int ln_Contador = 0;
            //int mes = DateTime.Now.Month;
            //int ano = DateTime.Now.Year;
            //string Zdia = null;
            //int vmfila = 0;
            //for (ln_Contador = 1; ln_Contador <= DateTime.Now.Day; ln_Contador++)
            //{
            //    tmptabla.Rows.Add(VariablesPublicas.InsertIntoTable(tmptabla));
            //    tmptabla.Rows[tmptabla.Rows.Count - 1]["fecha"] = ln_Contador.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            //}
            //ln_Contador = 0;
            //int vmposfila = -1;

            //for (K = 1; (K <= lc_Texto.Length); K++)
            //{
            //    if (Equivalencias.Mid(lc_Texto, K, 1) == " ")
            //    {
            //        ln_Contador = (ln_Contador + 1);
            //        if (ln_Contador == 1 & K != lc_Texto.Length)
            //        {
            //            if (lc_Cadena.Length > 0)
            //            {
            //                if ((decimal.Parse(lc_Cadena) == 0))
            //                {
            //                    xfecha = "";
            //                }
            //                else
            //                {
            //                    Zdia = decimal.Parse(lc_Cadena).ToString();
            //                    DateTime xfecha2 = new DateTime(ano, mes, Convert.ToInt16(Zdia.ToString()), 0, 0, 0, 0);
            //                    xfecha = Convert.ToString(xfecha2);
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show("No hay Información para la Actualización", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //            }

            //            if ((xfecha.Trim().Length > 0))
            //            {
            //                for (vmfila = 0; (vmfila <= (tmptabla.Rows.Count - 1)); vmfila++)
            //                {
            //                    if (Convert.ToString(tmptabla.Rows[vmfila]["fecha"].ToString()) == xfecha)
            //                    {
            //                        vmposfila = vmfila;
            //                        break;
            //                    }
            //                }
            //            }
            //        }

            //        if (((ln_Contador == 2) && (vmposfila >= 0)))
            //        {
            //            tmptabla.Rows[vmposfila]["compra"] = double.Parse(lc_Cadena);
            //        }
            //        if (((ln_Contador == 3) && (vmposfila >= 0)))
            //        {
            //            tmptabla.Rows[vmposfila]["venta"] = double.Parse(lc_Cadena);
            //            tmptabla.Rows[vmposfila]["promedio"] = Math.Round(((Convert.ToDecimal(tmptabla.Rows[vmposfila]["compra"]) + Convert.ToDecimal(tmptabla.Rows[vmposfila]["venta"])) / 2), 4);
            //            ln_Contador = 0;
            //            vmposfila = -1;
            //        }
            //        lc_Cadena = "";
            //    }
            //    else
            //    {
            //        lc_Cadena = lc_Cadena + Equivalencias.Mid(lc_Texto, K, 1);
            //    }
            //}
            //tmptabla.AcceptChanges();

            //Decimal xcompra = Convert.ToDecimal(tmptabla.Rows[0]["compra"]);
            //Decimal xventa = Convert.ToDecimal(tmptabla.Rows[0]["venta"]);
            //Decimal xpromedio = Convert.ToDecimal(tmptabla.Rows[0]["promedio"]);

            //for (vmfila = 0; vmfila <= tmptabla.Rows.Count - 1; vmfila++)
            //{
            //    if ((Convert.ToDecimal(tmptabla.Rows[vmfila]["compra"]) == 0) & (Convert.ToDateTime(tmptabla.Rows[vmfila]["fecha"]) != DateAndTime.Now.Date))
            //    {
            //        tmptabla.Rows[vmfila]["compra"] = xcompra;
            //        tmptabla.Rows[vmfila]["venta"] = xventa;
            //        tmptabla.Rows[vmfila]["promedio"] = xpromedio;
            //    }

            //    xcompra = Convert.ToDecimal(tmptabla.Rows[vmfila]["compra"]);
            //    xventa = Convert.ToDecimal(tmptabla.Rows[vmfila]["venta"]);
            //    xpromedio = Convert.ToDecimal(tmptabla.Rows[vmfila]["promedio"]);

            //    //tmptabla.Rows[vmfila]["perianio"] = VariablesPublicas.perianio;
            //    ////BE.perianio = VariablesPublicas.PADL(DateTime.Now.Date.Year.ToString(), 4, "0");
            //    tmptabla.Rows[vmfila]["perianio"] = VariablesPublicas.PADL(Convert.ToDateTime(tmptabla.Rows[vmfila]["fecha"]).Year.ToString(), 4, "0");
            //    //tmptabla.Rows[vmfila]["perimes"] = VariablesPublicas.PADL(DateTime.Now.Date.Month.ToString(), 2, "0");
            //    tmptabla.Rows[vmfila]["perimes"] = VariablesPublicas.PADL(Convert.ToDateTime(tmptabla.Rows[vmfila]["fecha"]).Month.ToString(), 2, "0");
            //    tmptabla.Rows[vmfila]["usuar"] = VariablesPublicas.Usuar.Trim();
            //    if (Convert.ToDecimal(tmptabla.Rows[vmfila]["compra"]) == 0)
            //    {
            //        tmptabla.Rows[vmfila].Delete();
            //    }
            //}
            //tmptabla.AcceptChanges();
            //if (tmptabla.Rows.Count > 0)
            //{
            //    SortOrder sorted = default(SortOrder);
            //    string xnomcolumna = "";
            //    if ((GridTipocambio.SortedColumn != null))
            //    {
            //        xnomcolumna = GridTipocambio.Columns[GridTipocambio.SortedColumn.Index].Name;
            //        sorted = GridTipocambio.SortOrder;
            //    }

            //    GridTipocambio.AutoGenerateColumns = false;
            //    GridTipocambio.DataSource = tmptabla;

            //    if (xnomcolumna.Trim().Length > 0)
            //    {
            //        if (sorted == SortOrder.Descending)
            //        {
            //            GridTipocambio.Sort(GridTipocambio.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Descending);
            //        }
            //        else
            //        {
            //            GridTipocambio.Sort(GridTipocambio.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Ascending);
            //        }
            //    }
            //    else
            //    {
            //        GridTipocambio.Sort(GridTipocambio.Columns["fechaE"], System.ComponentModel.ListSortDirection.Descending);
            //    }
            //}
            #endregion
        }

        private void btngrabartcambiosunat_Click(object sender, EventArgs e)
        {
            save_internet();
            #region antiguo
            //bool zprocesaok = false;
            //if ((GridTipocambio.DataSource != null))
            //{
            //    if (GridTipocambio.RowCount > 0)
            //    {
            //        zprocesaok = true;
            //        if (MessageBox.Show("Desea grabar información extraida de la sunat...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            //        {
            //            // Variables de Cabecera
            //            tipocambioBL BL = new tipocambioBL();
            //            tb_tipocambio BE = new tb_tipocambio();

            //            // Variables para Detalle
            //            tb_tipocambio.Item Detalle = new tb_tipocambio.Item();
            //            List<tb_tipocambio.Item> ListaItems = new List<tb_tipocambio.Item>();

            //            BE.perianio = VariablesPublicas.PADL(DateTime.Now.Date.Year.ToString(), 4, "0");
            //            BE.perimes = VariablesPublicas.PADL(DateTime.Now.Date.Month.ToString(), 2, "0");

            //            int item = 0;
            //            foreach (DataRow fila in tmptabla.Rows)
            //            {
            //                Detalle = new tb_tipocambio.Item();

            //                item++;

            //                Detalle.fecha = Convert.ToDateTime(fila["fecha"].ToString());
            //                Detalle.compra = Convert.ToDecimal(fila["compra"].ToString());
            //                Detalle.venta = Convert.ToDecimal(fila["venta"].ToString());
            //                Detalle.promedio = Convert.ToDecimal(fila["promedio"].ToString());
            //                Detalle.usuar = VariablesPublicas.Usuar;

            //                ListaItems.Add(Detalle);
            //            }

            //            BE.ListaItems = ListaItems;
                        
            //            try
            //            {
            //                if (BL.Insert_XML(VariablesPublicas.EmpresaID.ToString(), BE))
            //                {
            //                    U_CancelarEdicion(0);
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }
            //        TabControl1.SelectedIndex = 0;
            //    }
            //}
            //if (!zprocesaok)
            //{
            //    MessageBox.Show("Extraiga información", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    btnextraertcambio.Focus();
            //}
            #endregion
        }

        private void save_internet()
        {
            bool zprocesaok = false;
            if ((GridTipocambio.DataSource != null))
            {
                if (GridTipocambio.RowCount > 0)
                {
                    zprocesaok = true;

                    if (XtraMessageBox.Show("Desea grabar información extraida de la Sunat...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        tipocambioBL BL = new tipocambioBL();
                        tb_tipocambio BE = new tb_tipocambio();

                        if (BL.Insert_Update(VariablesPublicas.EmpresaID, tmptabla))
                        {
                            U_CancelarEdicion(0);
                        }
                        else
                        {
                            Frm_Class.ShowError(BL.Sql_Error, this);
                        }
                    }
                    TabControl1.SelectedIndex = 0;
                }
            }
            if (!zprocesaok)
            {
                XtraMessageBox.Show("Extraiga información", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnextraertcambio.Focus();
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            ////Aqui vamos a mostrar el Frm_ReporteTipoCambio.cs
            ////Llamamos al formulario como hijo
            //Frm_ReporteTipoCambio frmNew = new Frm_ReporteTipoCambio();
            //frmNew.MdiParent = MdiParent;
            //frmNew.Show();
            //frmNew.Activate();
        }

        private void webbrowser_link()
        {
            var url1 = "http://www.sunat.gob.pe/cl-at-ittipcam/tcS01Alias";
            var textFromFile1 = (new WebClient()).DownloadString(url1);
            //txtContenidoWeb.Text = textFromFile;
            wbTipoCambioSunat.Navigate(new Uri(url1).ToString());
        }
        private bool Conexion()
        {
            bool xvalor = false;
            if (VariablesPublicas.compruebaConexion() == true)
            {
                //Text = Text + " " + System.Environment.MachineName + "Con conexión a Internet";
                Text = Text + " - " + "Con conexión a Internet";
                //MessageBox.Show("Con conexión a Internet", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                xvalor = true;
            }
            else
            {
                //Text = Text + " " + System.Environment.MachineName + "Sin conexión a Internet";
                Text = Text + " - " + "Sin conexión a Internet";
                //MessageBox.Show("Sin conexión a Internet", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                xvalor = false;
            }
            return xvalor;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.sbs.gob.pe/0/modulos/jer/jer_interna.aspx?are=0&pfl=0&jer=147");
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            //txt.Visible = !txt.Visible;
            panel1.Visible = !panel1.Visible;
            panel2.Visible = !panel2.Visible;
        }

        private void panel1_VisibleChanged(object sender, EventArgs e)
        {
            btnExpand.Text = panel1.Visible ? "Contraer" : "Expandir";
        }

        private void wbTipoCambioSunat_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (VariablesPublicas.compruebaConexion() == true)
            {
                string lc_Texto = "";
                int ln_PosIni = 0;
                int ln_PosFin = 0;
                int K = 0;
                int nYear; int nMes; int nDay;

                string codeHtml = string.Empty;
                try
                {
                    nYear = dpConsulta.Value.Year;
                    nMes = dpConsulta.Value.Month;

                    if (nMes == DateTime.Now.Month && nYear == DateTime.Now.Year)
                    {
                        nYear = DateTime.Now.Year;
                        nMes = DateTime.Now.Month;
                        nDay = DateTime.Now.Day;
                    }
                    else
                    {
                        int ld = DateTime.DaysInMonth(dpConsulta.Value.Year, dpConsulta.Value.Month);
                        nDay = DateTime.DaysInMonth(nYear, nMes);
                    }

                    bool flag = Fase != 0;
                    if (!flag)
                    {
                        Fase = 1;
                        codeHtml = wbTipoCambioSunat.DocumentText.Remove(0).ToString();
                        wbTipoCambioSunat.Document.GetElementById("mes").SetAttribute("Value", Convert.ToString(nMes).PadLeft(2, '0'));
                        wbTipoCambioSunat.Document.GetElementById("anho").SetAttribute("Value", Convert.ToString(nYear));
                        wbTipoCambioSunat.Navigate("JavaScript:CheckSubmit()");
                    }
                    else
                    {
                        flag = Fase != 1;
                        if (!flag)
                        {
                            codeHtml = wbTipoCambioSunat.DocumentText;

                            ln_PosIni = Strings.InStr(codeHtml, "D�a");
                            ln_PosFin = Strings.InStr(codeHtml, "Notas:");
                            //ln_PosFin = Strings.InStr(codeHtml, "Para efectos");
                            lc_Texto = Strings.Mid(codeHtml, ln_PosIni, ln_PosFin - ln_PosIni);
                            ln_PosIni = Strings.InStrRev(lc_Texto, "Venta");
                            lc_Texto = (Strings.Mid(lc_Texto, ln_PosIni + 6).Trim() + " ").Replace("\n", " ");
                            ln_PosIni = Strings.InStrRev(lc_Texto, "/td>  ");
                            lc_Texto = (Strings.Mid(lc_Texto, ln_PosIni + 5).Trim() + " ").Replace("\n", " ");
                            lc_Texto = lc_Texto.Replace("\r", "");

                            lc_Texto = HtmlRemoval.StripTagsRegex(lc_Texto);
                            lc_Texto = HtmlRemoval.StripTagsRegexCompiled(lc_Texto);
                            lc_Texto = HtmlRemoval.StripTagsCharArray(lc_Texto);
                            lc_Texto = lc_Texto.Replace("                	  			                   		  ", "");
                            lc_Texto = lc_Texto.Replace("														  ", "");
                            lc_Texto = lc_Texto.Replace("                              		  ", " ");
                            lc_Texto = lc_Texto.Replace("                         			                   		  ", " ");
                            lc_Texto = lc_Texto.Replace("                              		  ", " ");
                            lc_Texto = lc_Texto.Replace("                         			                                                             		  ", " ");
                            lc_Texto = lc_Texto.Replace("                         			                                ", " ");
                            lc_Texto = lc_Texto.Replace("                                        ", " ");
                            lc_Texto = lc_Texto.Replace("          ", " ");

                            SendKeys.Flush();

                            (tmptabla).Clear();
                            tmptabla = Tabla.Clone();
                            string lc_Cadena = "";
                            string xfecha = "";
                            int ln_Contador = 0;

                            string Zdia = null;
                            int vmfila = 0;
                            for (ln_Contador = 1; ln_Contador <= nDay; ln_Contador++)
                            {
                                tmptabla.Rows.Add(VariablesPublicas.InsertIntoTable(tmptabla));
                                tmptabla.Rows[tmptabla.Rows.Count - 1]["fecha"] = ln_Contador.ToString() + "/" + nMes.ToString() + "/" + nYear.ToString(); // + dpConsulta.Value.Month.ToString() + "/" + dpConsulta.Value.Year.ToString();
                            }
                            ln_Contador = 0;
                            int vmposfila = -1;

                            for (K = 1; (K <= lc_Texto.Length); K++)
                            {
                                if (Equivalencias.Mid(lc_Texto, K, 1) == " ")
                                {
                                    ln_Contador = (ln_Contador + 1);
                                    if (ln_Contador == 1 & K != lc_Texto.Length)
                                    {
                                        if (lc_Cadena.Length > 0)
                                        {
                                            if ((decimal.Parse(lc_Cadena) == 0))
                                            {
                                                xfecha = "";
                                            }
                                            else
                                            {
                                                Zdia = decimal.Parse(lc_Cadena).ToString();
                                                DateTime xfecha2 = new DateTime(nYear, nMes, Convert.ToInt16(Zdia.ToString()), 0, 0, 0, 0);
                                                xfecha = Convert.ToString(xfecha2);
                                            }
                                        }
                                        else
                                        {
                                            XtraMessageBox.Show("No hay Información para Actualizar...?", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Question);
                                        }

                                        if ((xfecha.Trim().Length > 0))
                                        {
                                            for (vmfila = 0; (vmfila <= (tmptabla.Rows.Count - 1)); vmfila++)
                                            {
                                                if (Convert.ToString(tmptabla.Rows[vmfila]["fecha"].ToString()) == xfecha)
                                                {
                                                    vmposfila = vmfila;
                                                    break;
                                                }
                                            }
                                        }
                                    }

                                    if (((ln_Contador == 2) && (vmposfila >= 0)))
                                    {
                                        tmptabla.Rows[vmposfila]["compra"] = double.Parse(lc_Cadena);
                                    }
                                    if (((ln_Contador == 3) && (vmposfila >= 0)))
                                    {
                                        tmptabla.Rows[vmposfila]["venta"] = double.Parse(lc_Cadena);
                                        tmptabla.Rows[vmposfila]["promedio"] = Math.Round(((Convert.ToDecimal(tmptabla.Rows[vmposfila]["compra"]) + Convert.ToDecimal(tmptabla.Rows[vmposfila]["venta"])) / 2), 4);
                                        ln_Contador = 0;
                                        vmposfila = -1;
                                    }
                                    lc_Cadena = "";
                                }
                                else
                                {
                                    lc_Cadena = lc_Cadena + Equivalencias.Mid(lc_Texto, K, 1);
                                }
                            }
                            tmptabla.AcceptChanges();

                            Decimal xcompra = Convert.ToDecimal(tmptabla.Rows[0]["compra"]);
                            Decimal xventa = Convert.ToDecimal(tmptabla.Rows[0]["venta"]);
                            Decimal xpromedio = Convert.ToDecimal(tmptabla.Rows[0]["promedio"]);

                            for (vmfila = 0; vmfila <= tmptabla.Rows.Count - 1; vmfila++)
                            {
                                if ((Convert.ToDecimal(tmptabla.Rows[vmfila]["compra"]) == 0) & (Convert.ToDateTime(tmptabla.Rows[vmfila]["fecha"]) != dpConsulta.Value))//DateAndTime.Now.Date))
                                {
                                    tmptabla.Rows[vmfila]["compra"] = xcompra;
                                    tmptabla.Rows[vmfila]["venta"] = xventa;
                                    tmptabla.Rows[vmfila]["promedio"] = xpromedio;
                                }

                                xcompra = Convert.ToDecimal(tmptabla.Rows[vmfila]["compra"]);
                                xventa = Convert.ToDecimal(tmptabla.Rows[vmfila]["venta"]);
                                xpromedio = Convert.ToDecimal(tmptabla.Rows[vmfila]["promedio"]);

                                tmptabla.Rows[vmfila]["perianio"] = VariablesPublicas.PADL(Convert.ToDateTime(tmptabla.Rows[vmfila]["fecha"]).Year.ToString(), 4, "0");
                                tmptabla.Rows[vmfila]["perimes"] = VariablesPublicas.PADL(Convert.ToDateTime(tmptabla.Rows[vmfila]["fecha"]).Month.ToString(), 2, "0");
                                tmptabla.Rows[vmfila]["usuar"] = VariablesPublicas.Usuar.Trim();
                                if (Convert.ToDecimal(tmptabla.Rows[vmfila]["compra"]) == 0)
                                {
                                    tmptabla.Rows[vmfila].Delete();
                                }
                            }
                            tmptabla.AcceptChanges();
                            if (tmptabla.Rows.Count > 0)
                            {
                                SortOrder sorted = default(SortOrder);
                                string xnomcolumna = "";
                                if ((GridTipocambio.SortedColumn != null))
                                {
                                    xnomcolumna = GridTipocambio.Columns[GridTipocambio.SortedColumn.Index].Name;
                                    sorted = GridTipocambio.SortOrder;
                                }

                                GridTipocambio.AutoGenerateColumns = false;
                                GridTipocambio.DataSource = tmptabla;

                                if (xnomcolumna.Trim().Length > 0)
                                {
                                    if (sorted == SortOrder.Descending)
                                    {
                                        GridTipocambio.Sort(GridTipocambio.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Descending);
                                    }
                                    else
                                    {
                                        GridTipocambio.Sort(GridTipocambio.Columns[xnomcolumna], System.ComponentModel.ListSortDirection.Ascending);
                                    }
                                }
                                else
                                {
                                    GridTipocambio.Sort(GridTipocambio.Columns["fechaE"], System.ComponentModel.ListSortDirection.Descending);
                                }
                            }
                        }
                    }
                    U_RefrescaControles();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error al Conectarse a Internet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    codeHtml = "";
                }
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dtFechaElegida = dpConsulta.Value;
                dpConsulta.Value = dtFechaElegida.AddMonths(-1);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdelante_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dtFechaElegida = dpConsulta.Value;
                dpConsulta.Value = dtFechaElegida.AddMonths(1);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }      
    }
}
