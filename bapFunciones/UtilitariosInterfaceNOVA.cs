using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.IO;
using System.Net.NetworkInformation;
using System.Windows.Forms;
//using System.Math;
using bapFunciones;
using Excel = Microsoft.Office.Interop.Excel;
using Interaction = Microsoft.VisualBasic.Interaction;

//using Caesoft.DLLS;
//using Caesoft.Business.Logic;

namespace bapFunciones
{
public struct ParametrosTextBox
{
    #region "Fields"
    public int LengthText;
    public int LengthReal;
    public int LengthDecimal;
    public char CharDecimal;
    #endregion
    
    #region "Constructor"
    //public ParametrosTextBox(int _lengthText)
    //{
    //    this.LengthText = _lengthText;
    //}

    //public ParametrosTextBox(int _lengthText, int _lengthDecimal)
    //{
    //    this.LengthText = _lengthText;
    //    this.LengthDecimal = _lengthDecimal;
    //}

    //public ParametrosTextBox(int _lengthText, int _lengthDecimal, char _charDecimal)
    //{
    //    this.LengthText = _lengthText;
    //    this.LengthDecimal = _lengthDecimal;
    //    this.CharDecimal = _charDecimal;
    //}
    #endregion
}

public enum DirectionText
{
    left,
    right
}

public class UtilitariosInterface
{

    #region "Fields"

    #endregion

    #region "Properties"

    public static KeyPressEventHandler NextControl_KeyPress
    {
        get
        {
            KeyPressEventHandler keypress = new KeyPressEventHandler(mNextControl_KeyPress);
            return keypress;
        }
    }
    private static void mIngresaTodo_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        e.Handled = false;
    }
    private static void mCapturatecla_KeyPress(System.Object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F1)
        {
            GlobalVars.GetInstance()._ayudaItemOS = true;
            SendKeys.Send("{TAB}");
        }
        e.Handled = false;
    }
    public static KeyEventHandler CapturaF1_RC_SubFase_KeyPress
    {
        get
        {
            KeyEventHandler keypress = new KeyEventHandler(mCapturateclaRC_SubFase_KeyPress);
            return keypress;
        }
    }

    private static void mCapturateclaRC_KeyPress(System.Object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F1)
        {
            GlobalVars.GetInstance()._ayudaItemRC = true;
            SendKeys.Send("{TAB}");
        }
        e.Handled = false;
    }
    public static KeyEventHandler CapturaF1_OC_KeyPress
    {
        get
        {
            KeyEventHandler keypress = new KeyEventHandler(mCapturateclaOC_KeyPress);
            return keypress;
        }
    }

    private static void mCapturateclaRC_Rubro_KeyPress(System.Object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F1)
        {
            GlobalVars.GetInstance()._AyudaRubroRC = true;
            SendKeys.Send("{TAB}");
        }
        e.Handled = false;
    }
    public static KeyEventHandler CapturaEnter_OC_KeyPress
    {
        get
        {
            KeyEventHandler keypress = new KeyEventHandler(mCapturaEnterOC_KeyPress);
            return keypress;
        }
    }

    private static void mCapturateclaRC_SubFase_KeyPress(System.Object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F1)
        {
            GlobalVars.GetInstance()._AyudaSubFasesRC = true;
            SendKeys.Send("{TAB}");
        }
        e.Handled = false;
    }

    private static void mCapturaEnterOC_KeyPress(System.Object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F2)
        {
            GlobalVars.GetInstance()._GeneraItemOC = true;
            SendKeys.Send("{TAB}");
        }
        e.Handled = false;
    }

    private static void mCapturateclaOC_KeyPress(System.Object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F1)
        {
            GlobalVars.GetInstance()._ayudaItemOC = true;
            SendKeys.Send("{TAB}");
        }
        e.Handled = false;
    }
    public static KeyPressEventHandler IngresaNada_KeyPress
    {
        get
        {
            KeyPressEventHandler keypress = new KeyPressEventHandler(mIngresaNada_KeyPress);
            return keypress;
        }
    }

    private static void mIngresaNada_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        e.Handled = true;
    }

    public static KeyPressEventHandler IngresaTodo_KeyPress
    {
        get
        {
            KeyPressEventHandler keypress = new KeyPressEventHandler(mIngresaTodo_KeyPress);
            return keypress;
        }
    }

    public static KeyPressEventHandler IngresaLetras_KeyPress
    {
        get
        {
            KeyPressEventHandler keypress = new KeyPressEventHandler(mIngresaLetras_KeyPress);
            return keypress;
        }
    }

    public static KeyPressEventHandler IngresaNumero_KeyPress
    {
        get
        {
            KeyPressEventHandler keypress = new KeyPressEventHandler(mIngresaNumero_KeyPress);
            return keypress;
        }
    }

    public static KeyPressEventHandler IngresaMoneda_KeyPress
    {
        get
        {
            KeyPressEventHandler keypress = new KeyPressEventHandler(mIngresaMoneda_KeyPress);
            return keypress;
        }
    }

    public static EventHandler TextDecimal_Changed
    {
        get
        {
            EventHandler textChanged = new EventHandler(mTextDecimal_Changed);
            return textChanged;
        }
    }

    public static KeyPressEventHandler LengthTextBox_KeyPress
    {
        get
        {
            KeyPressEventHandler keypress = new KeyPressEventHandler(mLegthTextBox_KeyPress);
            return keypress;
        }
    }

    #endregion

    #region "Methods"

    private static void mNextControl_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        if (e.KeyChar == Convert.ToChar(Keys.Return))
        {
            SendKeys.Send("{TAB}");
        }
    }

    private static void mIngresaLetras_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        if (char.IsLetter(e.KeyChar))
        {
            e.Handled = false;
        }
        else
        {
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }

    private static void mIngresaNumero_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        if (char.IsDigit(e.KeyChar))
        {
            e.Handled = false;
        }
        else
        {
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }

    private static void mIngresaMoneda_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        TextBox caja = (TextBox)sender;
        string texto = caja.Text;
        ParametrosTextBox para = (ParametrosTextBox)caja.Tag;

        if (!string.IsNullOrEmpty(para.ToString()))
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    if (e.KeyChar == para.CharDecimal)
                    {
                        if (texto.Contains(para.CharDecimal))
                        {
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = false;
                        }
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }
    }
    public static void ExistForm(Form OformPapa, Form OformHijo, bool IsFormPapa)
    {
        int lccont = 0;
        bool noinstanciado = false;
        for (lccont = 0; lccont <= OformPapa.MdiChildren.Length - 1; lccont++)
        {
            if (OformPapa.MdiChildren[lccont].Name.ToUpper() == OformHijo.Name.ToUpper())
            {
                if (OformPapa.MdiChildren[lccont].Visible)
                {
                    OformPapa.MdiChildren[lccont].WindowState = FormWindowState.Normal;
                    OformPapa.MdiChildren[lccont].Activate();
                    OformPapa.MdiChildren[lccont].Show();
                    noinstanciado = true;
                    break; 
                }
            }
        }
        if (!noinstanciado)
        {
            OformHijo.Show();
            if (IsFormPapa)
            {
                if ((OformPapa != null))
                {
                    if ((OformHijo != null))
                    {
                        OformHijo.MdiParent = OformPapa;
                    }
                }
            }
        }
    }
    public static void ExistFormConTable(Form OformPapa, Form OformHijo, bool IsFormPapa, bool ztesoreria, bool zcontabilidad)
    {
        int lccont = 0;
        bool noinstanciado = false;
        for (lccont = 0; lccont <= OformPapa.MdiChildren.Length - 1; lccont++)
        {
            if (OformPapa.MdiChildren[lccont].Name.ToUpper() == OformHijo.Name.ToUpper())
            {
                if (OformPapa.MdiChildren[lccont].Visible)
                {
                    OformPapa.MdiChildren[lccont].WindowState = FormWindowState.Normal;
                    OformPapa.MdiChildren[lccont].Activate();
                    OformPapa.MdiChildren[lccont].Show();
                    noinstanciado = true;
                    break; 
                }
            }
        }
        if (!noinstanciado)
        {
            //OformHijo._tesoreria = ztesoreria;
            //OformHijo._contabilidad = zcontabilidad;

            OformHijo.Show();
            if (IsFormPapa)
            {
                if ((OformPapa != null))
                {
                    if ((OformHijo != null))
                    {
                        OformHijo.MdiParent = OformPapa;
                    }
                }
            }
        }
    }
    public static void ExistFormName(Form OformPapa, Form OformHijo, bool IsFormPapa, string NameHijo)
    {
        int lccont = 0;
        bool noinstanciado = false;
        for (lccont = 0; lccont <= OformPapa.MdiChildren.Length - 1; lccont++)
        {
            if (OformPapa.MdiChildren[lccont].Name.ToUpper() == NameHijo.ToUpper())
            {
                if (OformPapa.MdiChildren[lccont].Visible)
                {
                    OformPapa.MdiChildren[lccont].WindowState = FormWindowState.Normal;
                    OformPapa.MdiChildren[lccont].Show();
                    noinstanciado = true;
                    break; 
                }
            }
        }
        if (!noinstanciado)
        {
            OformHijo.Show();
            if (IsFormPapa)
            {
                if ((OformPapa != null))
                {
                    OformHijo.MdiParent = OformPapa;
                }
            }
        }
    }

    private static void mTextDecimal_Changed(System.Object sender, System.EventArgs e)
    {
        try
        {
            TextBox caja = (TextBox)sender;
            string texto = caja.Text;
            ParametrosTextBox para = (ParametrosTextBox)caja.Tag;

            int pos = texto.IndexOf(para.CharDecimal);

            if (para.LengthDecimal > 0)
            {
                if (texto.Contains(para.CharDecimal))
                {
                    if (texto.Substring(pos).Length > para.LengthDecimal + 1)
                    {
                        SendKeys.Send("{BACKSPACE}");
                    }
                }
            }

            if (texto.Trim() != string.Empty)
            {
                decimal valor = Convert.ToDecimal(texto);

                if (Convert.ToString(Math.Ceiling(valor)).Length > para.LengthReal)
                {
                    SendKeys.Send("{BACKSPACE}");
                }
            }

        }
        catch (Exception ex)
        {
        }
    }

    private static void mLegthTextBox_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        TextBox caja = (TextBox)sender;
        ParametrosTextBox para = (ParametrosTextBox)caja.Tag;

        if (caja.Text.Trim().Length >= para.LengthText)
        {
            e.Handled = true;
        }
    }

    private static string FormateaNumeroaCadena(string S1, int nlen, char cfill)
    {
        int i = 0;
        for (i = 1; i <= nlen - S1.Trim().Length; i++)
        {
            S1 = cfill + S1;
        }
        return S1;
    }
    public static string FormateaNumeroaCadena(string cadena, int length, char charFill, DirectionText directionFill)
    {
        string valor = cadena.Trim();
        if (directionFill == DirectionText.left)
        {
            valor = valor.PadLeft(length, charFill);
        }
        else if (directionFill == DirectionText.right)
        {
            valor = valor.PadRight(length, charFill);
        }
        return valor;
    }

    public static string FormateaNumeroaCadena2(string cadena, int length, char charFill, bool directionLeft)
    {
        string valor = cadena.Trim();

        if (directionLeft)
        {
            valor = valor.PadLeft(length, charFill);
        }
        else
        {
            valor = valor.PadRight(length, charFill);
        }
        return valor;
    }

    public static void CrearXml(DataTable table, string tableName)
    {
        try
        {
            if (table == null)
                return;
            if (!(System.IO.Directory.Exists(Application.StartupPath + "\\Xml\\")))
            {
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\\Xml\\");
            }

            table.TableName = tableName.Trim();
            table.WriteXml(Application.StartupPath + "\\Xml\\" + tableName + ".xml", XmlWriteMode.WriteSchema);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static void CrearXml(DataTable table, string tableName, string fileName)
    {
        if (fileName.Trim().Length == 0)
        {
            fileName = Application.StartupPath + "\\Xml\\";
        }
        if (!(System.IO.Directory.Exists(fileName)))
        {
            System.IO.Directory.CreateDirectory(fileName);
        }

        try
        {
            if (table == null)
                return;
            table.TableName = tableName.Trim();
            table.WriteXml(fileName + tableName + ".xml", XmlWriteMode.WriteSchema);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error al crear archivo de datos en " + fileName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Interaction.MsgBox("Error al crear archivo de datos en " + fileName, 64, "");
        }
    }

    public static void CrearXml(DataSet dataS, string Name)
    {
        try
        {
            if (dataS == null)
                return;
            if (!(System.IO.Directory.Exists(Application.StartupPath + "\\Xml\\")))
            {
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\\Xml\\");
            }

            dataS.DataSetName = Name.Trim();
            dataS.WriteXml(Application.StartupPath + "\\Xml\\" + Name + ".xml", XmlWriteMode.WriteSchema);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static KeyEventHandler CapturaF1_KeyPress
    {
        get
        {
            KeyEventHandler keypress = new KeyEventHandler(mCapturatecla_KeyPress);
            return keypress;
        }
    }

    public static void CrearXml(DataSet dataS, string Name, string fileName)
    {
        try
        {
            if (dataS == null)
                return;
            if (!(System.IO.Directory.Exists(fileName)))
            {
                throw new Exception("No existe la ruta indicada");
            }

            dataS.DataSetName = Name.Trim();
            dataS.WriteXml(fileName + Name + ".xml", XmlWriteMode.WriteSchema);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public static string convierte(string cad, int accion)
    {
        // CAD : ES UN STRING 
        // ACCION ES NUMERo RECIBE 1 SI SE ENCRIPTA    UNA CADENA
        // ACCION ES NUMERo RECIBE 0 SI SE DESENCRIPTA UNA CADENA
        string cadena = null;
        string vcad = null;
        int i = 0;
        cad = cad.ToLower();
        cadena = string.Empty;
        vcad = string.Empty;
        //cad = Strings.LTrim(cad);
        //cad = Strings.RTrim(cad);
        for (i = 1; i <= cad.Length; i++)
        {
            vcad = Equivalencias.Mid(cad, i, 1);
            if (accion == 1)
            {
                if (!((Equivalencias.Asc(vcad) >= 97 & Equivalencias.Asc(vcad) <= 122) | (Equivalencias.Asc(vcad) >= 48 & Equivalencias.Asc(vcad) <= 57)))
                {
                    cadena = " ";
                }
                else
                {
                    cadena = cadena + Equivalencias.Chr(Equivalencias.Asc(vcad) + 65);
                }
            }
            else
            {
                cadena = cadena + Equivalencias.Chr(Equivalencias.Asc(vcad) - 65);
                cadena = cadena.ToUpper();
            }
        }
        return cadena;
    }
    public static KeyEventHandler CapturaF1_RC_Rubro_KeyPress
    {
        get
        {
            KeyEventHandler keypress = new KeyEventHandler(mCapturateclaRC_Rubro_KeyPress);
            return keypress;
        }
    }
    public static KeyEventHandler CapturaF1_RC_KeyPress
    {
        get
        {
            KeyEventHandler keypress = new KeyEventHandler(mCapturateclaRC_KeyPress);
            return keypress;
        }
    }
    public static bool ActivarOpciones(DataTable Tabla, string NomFORM)
    {
        int LC_CONT = 0;
        bool LzRetorno = false;
        for (LC_CONT = 0; LC_CONT <= Tabla.Rows.Count - 1; LC_CONT++)
        {
            if (Tabla.Rows[LC_CONT]["NAMENET"].ToString().ToUpper().Trim() == NomFORM.ToUpper().Trim())
            {
                LzRetorno = true;
                break; 
            }
        }
        return LzRetorno;
    }
    public static void PorImplementar()
    {
        MessageBox.Show("Opción NO HABILITADA","Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //Interaction.MsgBox("Opción NO HABILITADA", 64, "");
    }
    public static object SeekString(System.Data.DataTable oData, string NombreCampo, string oDato)
    {
        bool zFound = false;
        int lcCont = 0;
        for (lcCont = 0; lcCont <= oData.Rows.Count - 1; lcCont++)
        {
            if (oData.Rows[lcCont][NombreCampo] == oDato)
            {
                zFound = true;
                break; 
            }
        }
        return zFound;
    }
    public static int LocateForm(System.Windows.Forms.Form Oform, string NameaBuscar)
    {
        //Me Indica si un Objeto FORM ya Está Instanciado
        //Y Me Devuelve su Posición en el Array de FORMS
        int ValRetorno = -1;
        int lccont = 0;
        for (lccont = 0; lccont <= Oform.MdiChildren.Length - 1; lccont++)
        {
            if (Oform.MdiChildren[lccont].Name.ToUpper() == NameaBuscar.ToUpper() & NameaBuscar.Trim().Length > 0)
            {
                if (Oform.MdiChildren[lccont].Visible)
                {
                    Oform.MdiChildren[lccont].WindowState = FormWindowState.Normal;
                    Oform.MdiChildren[lccont].Show();
                    Oform.MdiChildren[lccont].Activate();
                    ValRetorno = lccont;
                    break; 
                }
            }
        }
        return ValRetorno;
    }
    public static string RIGHT(string Cadena, int Caracteres)
    {
        string xTMpCad = "";
        int lcCont = 0;
        int ncuenta = 0;
        for (lcCont = Cadena.Length; lcCont >= 1; lcCont += -1)
        {
            if (ncuenta < Caracteres)
            {
                xTMpCad = Equivalencias.Mid(Cadena, lcCont, 1) + xTMpCad;
                ncuenta = ncuenta + 1;
            }
            else
            {
                break; 
            }
        }
        return xTMpCad;
    }
    public static string JustificarDocumento(string NumDoc, int LenSerie, int LenDoc, bool ztieneserie)
    {
        int LC_COnt = 0;
        string xtmpCad = "";
        string xSerie = "";
        string xNumero = "";
        bool SwCargaNro = false;
        NumDoc = NumDoc.Trim();
        if (NumDoc.Contains("-"))
        {
            for (LC_COnt = 1; LC_COnt <= NumDoc.Length; LC_COnt++)
            {
                if (!(Equivalencias.Mid(NumDoc, LC_COnt, 1) == "-"))
                {
                    if (!SwCargaNro)
                    {
                        xSerie = xSerie + Equivalencias.Mid(NumDoc, LC_COnt, 1);
                    }
                    else
                    {
                        xNumero = xNumero + Equivalencias.Mid(NumDoc, LC_COnt, 1);
                    }
                }
                else
                {
                    SwCargaNro = true;
                }
            }
            if (ztieneserie)
            {
                xtmpCad = UtilitariosInterface.FormateaNumeroaCadena2(xSerie, LenSerie, '0', true) + "-" + UtilitariosInterface.FormateaNumeroaCadena2(xNumero, LenDoc, '0', true);
            }
            else
            {
                xtmpCad = UtilitariosInterface.FormateaNumeroaCadena2(xNumero, LenDoc, '0', true);
            }

        }
        else
        {
            xtmpCad = NumDoc.Trim();
        }
        return xtmpCad;
    }
    public static string InformacionPC()
    {
        string InfoPC = "";
        //string NomPC = My.Computer.Name.ToString();
        //string NomUser = My.User.Name.ToString;
        //string DirecIP = "";
        //foreach (System.Net.IPAddress IP in System.Net.Dns.GetHostAddresses(NomPC))
        //{
        //    DirecIP = IP.ToString();
        //    break; 
        //}
        //InfoPC = NomPC.Trim() + " | " + NomUser.Trim() + " | " + DirecIP.Trim();
        return InfoPC.Trim();
    }
    public static string ObtenerArchivoOrigen()
    {
        string ArchivoOrigen = "";
        ArchivoOrigen = Application.StartupPath.ToString();
        return ArchivoOrigen.Trim();
    }

    public static string LeerDatosIni(string archivo, string seccion, string clave)
    {
        System.IO.StreamReader oStreamR = null;
        string Path = "";
        string valor = "";
        Path = archivo.Trim();

        //if (My.Computer.FileSystem.FileExists(Path) == true)
        //{
        //    oStreamR = new System.IO.StreamReader(Path, System.Text.Encoding.GetEncoding(850));
        //    int config = 0;
        //    while ((!oStreamR.EndOfStream))
        //    {
        //        string StrLine = oStreamR.ReadLine().ToString().Trim();
        //        string[] StrDatos = StrLine.Split('=');
        //        if (StrDatos[0].Replace("[", "").Replace("]", "").ToUpper().Trim() == seccion.ToUpper().Trim())
        //        {
        //            config = 1;
        //        }
        //        if (config == 1)
        //        {
        //            if (StrDatos[0].Replace(" ", "").ToUpper().Trim() == clave.ToUpper().Trim())
        //            {
        //                valor = StrDatos[1].ToString().Trim();
        //                config = 0;
        //            }
        //        }
        //    }
        //    oStreamR.Close();
        //    return valor.Trim();
        //}
        //else
        //{
            return "";
        //}
    }
    public static void InsertarTablaSeguridad(DataTable dt, string nombre, string clave, string descripcion, string IdUsuario, string accion, string Pc)
    {
        DataRow dr = null;
        dr = dt.NewRow();
        dr["NOMBRE"] = nombre.Trim();
        dr["CLAVE"] = clave.Trim();
        dr["DESCRIPCION"] = descripcion.Trim();
        dr["ID_USUARIO"] = IdUsuario.Trim();
        dr["ACCION"] = accion.Trim();
        dr["PC"] = Pc.Trim();
        dt.Rows.Add(dr);
    }
    public static bool AlmacenSistema(string CoDAlmacen)
    {
        // Verifica si el codigo de Almacen es Código de Almacen de Sistema
        bool zRETORNO = false;
        if (CoDAlmacen == GlobalVars.GetInstance().AlmacenAvios | CoDAlmacen == GlobalVars.GetInstance().AlmacenHilado | CoDAlmacen == GlobalVars.GetInstance().AlmacenTelaAcabada | CoDAlmacen == GlobalVars.GetInstance().AlmacenTelaCruda)
        {
            zRETORNO = true;
        }
        return zRETORNO;
    }
    public static string ColumnaDataString(DataTable oData, string NombreColumna)
    {
        string ZRETORNO = "";
        if (oData.Rows.Count > 0)
        {
            ZRETORNO = oData.Rows[0][NombreColumna].ToString();
        }
        return ZRETORNO;
    }

    public static string Imagen_Aleatoria(string direc, string archivo)
    {
        int a = 0;
        string nom = "";
        try
        {
            for (a = 1; a <= 9999; a++)
            {
                nom = "";
                nom = direc.Trim() + UtilitariosInterface.FormateaNumeroaCadena2(a.ToString(), 4, '0', true).ToString().Trim() + "_" + archivo.Trim();
                //if (My.Computer.FileSystem.FileExists(nom) == false)
                //{
                //    break; 
                //}
            }
        }
        catch (Exception ex)
        {
            nom = direc + archivo;
        }
        return nom;
    }

    //public static bool ValidarCierre(string ccia, string Almacen, string Periodo, string Mes, System.DateTime Fecha, bool znoshowmsg)
    //{
    //    string FechaE = Fecha.ToShortDateString().Trim();
    //    FechaE = Equivalencias.Mid(FechaE, 7, 4) + Equivalencias.Mid(FechaE, 4, 2) + Equivalencias.Mid(FechaE, 1, 2);
    //    oaplilogic ocapa = new oaplilogic();
    //    return ocapa.ValidarCierreAlmacenes(ccia.Trim(), Almacen.Trim(), Periodo.Trim(), "", FechaE.Trim(), znoshowmsg);
    //}

    public static string Encriptar(string cCadena, string cTipo)
    {

        if (cCadena.Trim().Length > 0)
        {
            double nFactor = 0;
            string cResultado = null;
            string VmChar = "";
            int I = 0;
            Random NumberRandom = new Random(0);
            cCadena = cCadena.Trim();
            cTipo = cTipo.ToUpper().Trim();
            if (cTipo == "SI")
            {
                nFactor = NumberRandom.Next(10, 20);
                cResultado = Convert.ToChar(nFactor).ToString();
            }
            else
            {
                nFactor = Equivalencias.Asc(Equivalencias.Mid(cCadena, 1, 1));
                if (nFactor > 20 | nFactor < 10)
                {
                    return "";
                }
                cCadena = Equivalencias.Mid(cCadena, 2, cCadena.Length - 1);
                cResultado = "";
            }
            for (I = 1; I <= cCadena.Trim().Length; I++)
            {
                VmChar = Equivalencias.Mid(cCadena, I, 1);

                if (VmChar.Trim().Length > 0)
                {
                    VmChar = (Convert.ToChar(Equivalencias.Asc(VmChar)).ToString() + (cTipo == "SI" ? nFactor : nFactor * -1));
                }
                cResultado = cResultado + VmChar;
            }
            return (cCadena.Trim().Length == 0 ? cCadena : cResultado);
        }
        else
        {
            return "";
        }
    }
    public static bool u_ValidaStockEnLinea(string ccia, string periodo, string Almacen, string Fecha, string TIpoVoucher, string NumVoucher, System.Data.DataTable Detalle, bool zvalidaringreso)
    {
        //Dim Logic As New MovimientoAlmacenLogic(ccia, periodo, "")
        //oaplilogic logic = new oaplilogic();
        bool SW = true;
        //SW = logic.VERIFICAStockFisicoITEM(ccia, Almacen, Detalle, Fecha, periodo, TIpoVoucher, NumVoucher, zvalidaringreso);
        return SW;
    }


    //public static bool ValidarExistenciaGuias(string ccia, string Serie, string Numero, string Codigo = "")
    //{
        //DataTable dt = new DataTable();
        //string voucher = "";
        //string Orden = "";
        //dt = VigilanciaLogic.ReporteVigilanciaVisadoGuias(ccia, "", "", "", Serie, Numero, 1, 1, 3);
        //if (dt.Rows.Count > 0)
        //{
        //    voucher = dt.Rows[0]["VOUCHER"].ToString().Trim();
        //    Orden = dt.Rows[0]["ORDEN"].ToString().Trim();
        //    if (dt.Rows[0]["ORIGEN"] == "ALM")
        //    {
        //        if (Equivalencias.Mid(voucher.Trim(), 6, 2) != Codigo & Equivalencias.Mid(voucher.Trim(), 6, 2).Trim().Length > 0)
        //        {
        //            MessageBox.Show("Ya Existe una Guia para el Almacen '" + Equivalencias.Mid(voucher.Trim(), 6, 2) + "' con Nª de Serie '" + Orden.Trim() + "'", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else if (dt.Rows[0]["ORIGEN"] == "TAL")
        //    {
        //        if (Codigo.Trim().Length > 0)
        //        {
        //            MessageBox.Show("Ya Existe una Guia para el Taller '" + Equivalencias.Mid(voucher.Trim(), 6, 4) + "' con Nª de Serie '" + Orden.Trim() + "'", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}
        //else
        //{
        //    return false;
        //}
    //}

    public static string DevolverDireccion(string ccia, string Serie)
    {
        if (Serie.Trim().Length == 0)
            Serie = "0";
        string xreturn = "";
        if (ccia.Trim() == "01")
        {
            switch (Convert.ToInt32(Serie.Trim()))
            {
                case 1:
                case 2:
                case 4:
                case 5:
                case 6:
                    xreturn = "JR. PUNKARI NRO. 1772 URB. MANCOMARCA BAJA LIMA - LIMA - SAN JUAN DE LURIGANCHO";
                    break;
                case 3:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                    xreturn = "AV. PORTADA DEL SOL MZ 23 B - Nº 864 URB. ZARATE LIMA - LIMA - SAN JUAN DE LURIGANCHO";
                    break;
                default:
                    xreturn = "";
                    break;
            }
        }
        if (ccia.Trim() == "02")
        {
            switch (Convert.ToInt32(Serie.Trim()))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    xreturn = "JR. PUNKARI NRO. 1772 URB. MANCOMARCA BAJA LIMA - LIMA - SAN JUAN DE LURIGANCHO";
                    break;
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                    xreturn = "AV. PORTADA DEL SOL MZ 23 B - Nº 864 URB. ZARATE LIMA - LIMA - SAN JUAN DE LURIGANCHO";
                    break;
                default:
                    xreturn = "";
                    break;
            }
        }
        if (ccia.Trim() == "04")
        {
            switch (Convert.ToInt32(Serie.Trim()))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    xreturn = "JR. PUNKARI NRO. 1772 URB. MANCOMARCA BAJA LIMA - LIMA - SAN JUAN DE LURIGANCHO";
                    break;
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                    xreturn = "AV. PORTADA DEL SOL MZ 23 B - Nº 864 URB. ZARATE LIMA - LIMA - SAN JUAN DE LURIGANCHO";
                    break;
                default:
                    xreturn = "";
                    break;
            }
        }
        if (ccia.Trim() == "05")
        {
            xreturn = "AVDA. PORADA DEL SOL No. 864 – URB. ZARATE IND. – S.J.L. ";
        }
        return xreturn;
    }

    public static bool ValidarFecha(string Fecha_Cadena)
    {
        bool zreturn = true;
        System.DateTime tmpfechadate = default(System.DateTime);
        if (Fecha_Cadena.Trim().Length > 0)
        {
            try
            {
                tmpfechadate = Convert.ToDateTime(Fecha_Cadena);
            }
            catch (Exception ex)
            {
                zreturn = false;
            }
        }
        return zreturn;
    }
    public static DataRow INSERTINTOTABLE(DataTable vmdata)
    {
        //devuelve una fila en blanco para una tabla
        DataRow filadatos = vmdata.NewRow();
        int xcont = 0;
        object xvalor = new object();
        for (xcont = 0; xcont <= vmdata.Columns.Count - 1; xcont++)
        {
            vmdata.Columns[xcont].AllowDBNull = true;
        }
        for (xcont = 0; xcont <= vmdata.Columns.Count - 1; xcont++)
        {
            if (vmdata.Columns[xcont].DataType.Name.ToUpper() == "STRING" | vmdata.Columns[xcont].DataType.Name.ToUpper() == "CHAR")
            {
                filadatos[xcont] = "";
            }
            if (vmdata.Columns[xcont].DataType.Name.ToUpper() == "DECIMAL" | vmdata.Columns[xcont].DataType.Name.ToUpper() == "DOUBLE" | vmdata.Columns[xcont].DataType.Name.ToUpper() == "INT16" | vmdata.Columns[xcont].DataType.Name.ToUpper() == "INT32" | vmdata.Columns[xcont].DataType.Name.ToUpper() == "TIMESTAMP")
            {
                filadatos[xcont] = 0;
            }
            if (vmdata.Columns[xcont].DataType.Name.ToUpper() == "BOOLEAN")
            {
                filadatos[xcont] = false;
            }
            if (vmdata.Columns[xcont].DataType.Name.ToUpper() == "DATETIME")
            {
                filadatos[xcont] = DBNull.Value;
            }
        }
        return filadatos;
    }
    public static string SELECTMAXSTRING(DataTable vmdata, string namecampo)
    {
        string xmayor = "";
        int nfila = 0;
        for (nfila = 0; nfila <= vmdata.Rows.Count - 1; nfila++)
        {
            try
            {
                if (String.Compare(vmdata.Rows[nfila][namecampo].ToString(), xmayor) > 0)
                {
                    xmayor = vmdata.Rows[nfila][namecampo].ToString();
                }
                // error al encontrar columna
            }
            catch (Exception ex)
            {
                xmayor = "";
                break; 
            }
        }
        if (xmayor.Length > 0)
        {
            xmayor = UtilitariosInterface.FormateaNumeroaCadena2(Convert.ToString(Convert.ToInt32(xmayor) + 1).Trim(), Equivalencias.Len(xmayor), '0', true);
        }
        return xmayor;
    }
    public static DataTable DELETEFROMTABLE(DataTable vmdata, object namecampo)
    {
        return vmdata;
    }
    public static string PADL(string Cadena, int Longitud, string FillChar)
    {
        string xretorno = "";
        int lconta = 0;
        Cadena.Trim();
        if (Longitud > Cadena.Length)
        {
            for (lconta = 1; lconta <= Longitud - Cadena.Length; lconta++)
            {
                xretorno = xretorno + FillChar;
            }
            xretorno = xretorno + Cadena;
        }
        else
        {
            for (lconta = 1; lconta <= Longitud; lconta++)
            {
                xretorno = xretorno + Equivalencias.Mid(Cadena, lconta, 1);
            }
        }
        return xretorno;
    }

    public static string DTOS(DateTime Fecha)
    {
        // devuelve fecha AAAAMMDD
        string stringfecha = null;
        try
        {
            stringfecha = Fecha.Year.ToString() + PADL(Fecha.Month.ToString().Trim(), 2, "0") + PADL(Fecha.Date.ToString().Trim(), 2, "0");
        }
        catch (Exception ex)
        {
            stringfecha = "";
        }
        return stringfecha;
    }
    public static void SeteaBotones(Form oform, ToolStripButton Objeto, string KeyTETX)
    {
        var _with1 = oform;
        Objeto.ToolTipText = "[ " + KeyTETX + " ]-" + Objeto.ToolTipText;
    }
    public static void PintaEncabezados(DataGridView Grilla)
    {
        int contcolumnas = 0;
        for (contcolumnas = 0; contcolumnas <= Grilla.ColumnCount - 1; contcolumnas++)
        {
            if (Grilla.Columns[contcolumnas].Visible == true)
            {
                Grilla.Columns[contcolumnas].HeaderCell.Style.BackColor = System.Drawing.Color.Gray;
                Grilla.Columns[contcolumnas].HeaderCell.Style.ForeColor = System.Drawing.Color.WhiteSmoke;
                Grilla.Columns[contcolumnas].HeaderCell.Style.Font = new System.Drawing.Font("Tahoma", 8, System.Drawing.FontStyle.Bold);
            }
        }
    }
    public static void ProcesaCombo(System.Windows.Forms.ComboBox ObjCombo, System.Windows.Forms.KeyEventArgs e)
    {
        // Permite Abrir/Cerrar una lista de combo cuando se pulsa SPACE y al pulsar ENTER pasa al sig. Objeto
        if (e.KeyCode == Keys.Space)
        {
            ObjCombo.DroppedDown = !ObjCombo.DroppedDown;
        }
        else
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ObjCombo.DroppedDown)
                {
                    ObjCombo.DroppedDown = false;
                }
                else
                {
                    SendKeys.Send("\t");
                }
            }
        }
    }
    public static string CalcMaxField(DataTable data, string Nomcampo, int lencampo)
    {
        int lc_cont = 0;
        int xcont = 0;
        bool zprocesaString = true;
        for (xcont = 0; xcont <= data.Columns.Count - 1; xcont++)
        {
            if (data.Columns[xcont].Namespace.ToUpper() == Nomcampo.ToUpper())
            {
                if (data.Columns[xcont].DataType.Name.ToUpper() == "DECIMAL" | data.Columns[xcont].DataType.Name.ToUpper() == "DOUBLE" | data.Columns[xcont].DataType.Name.ToUpper() == "INT16" | data.Columns[xcont].DataType.Name.ToUpper() == "INT32")
                {
                    zprocesaString = false;
                    break; 
                }
            }
        }
        string xmayor = null;
        xmayor = replicate('0', lencampo);
        if (zprocesaString)
        {
            for (lc_cont = 0; lc_cont <= data.Rows.Count - 1; lc_cont++)
            {
                if (String.Compare(data.Rows[lc_cont][Nomcampo].ToString(), xmayor) > 0)
                {
                    xmayor = data.Rows[lc_cont][Nomcampo].ToString();
                }
            }
            xmayor = PADL(Convert.ToString(Convert.ToInt16(xmayor) + 1).Trim(), lencampo, "0");
        }
        else
        {
            for (lc_cont = 0; lc_cont <= data.Rows.Count - 1; lc_cont++)
            {
                if (Convert.ToInt16(data.Rows[lc_cont][Nomcampo].ToString()) > Convert.ToInt16(xmayor))
                {
                    xmayor = data.Rows[lc_cont][Nomcampo].ToString();
                }
            }
            xmayor = PADL(Convert.ToString(Convert.ToInt16(xmayor) + 1).Trim(), lencampo, "0");
        }
        return xmayor;
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
            GlobalVars.GetInstance().PulsaAyudaArticulos = true;
            SendKeys.Send("\t");
        }
        if (e.KeyCode == Keys.F2)
        {
            GlobalVars.GetInstance().PulsaTeclaF2 = true;
            SendKeys.Send("\t");
        }
        if (e.KeyCode == Keys.F3)
        {
            GlobalVars.GetInstance().PulsaTeclaF3 = true;
            SendKeys.Send("\t");
        }
    }
    public static string PADR(string Cadena, int Longitud, string FillChar)
    {
        string xretorno = "";
        int lconta = 0;
        Cadena.Trim();
        if (Longitud > Cadena.Length)
        {
            for (lconta = 1; lconta <= Longitud - Cadena.Length; lconta++)
            {
                xretorno = xretorno + FillChar;
            }
            xretorno = Cadena + xretorno;
        }
        else
        {
            for (lconta = 1; lconta <= Longitud; lconta++)
            {
                xretorno = xretorno + Equivalencias.Mid(Cadena, lconta, 1);
            }
        }
        return xretorno;
    }
    public static decimal StringtoDecimal(string Numero)
    {
        decimal retorno = 0;
        Numero = Numero.Trim();
        if (Numero.Length > 0)
        {
            try
            {
                retorno = Convert.ToDecimal(Numero);
            }
            catch (Exception ex)
            {
            }
        }
        return retorno;
    }
    public static string replicate(char CharaReplicar, int longitud)
    {
        string xreturn = "";
        int lc_cont = 0;
        for (lc_cont = 1; lc_cont <= longitud; lc_cont++)
        {
            xreturn = xreturn + CharaReplicar;
        }
        return xreturn;
    }

    public static void U_NoHayInfoReporte()
    {
        MessageBox.Show("No hay información según requerimientos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //MsgBox("No hay información según requerimientos", 64, "");
    }
    public static void ConfiguraToolbar(object[] arreglobotones)
    {
        //Respetar Estas Posiciones
        //0 Nuevo
        //1 Modificar
        //2 Grabar
        //3 Cancelar Grabacion
        //4 Eliminar
        //5 Refrescar
        //6 Buscar
        //7 Salir
        int Contador = 0;
        for (Contador = 0; Contador <= arreglobotones.Length - 1; Contador++)
        {
            if ((arreglobotones[Contador] != null))
            {
                switch (Contador)
                {
                    //case 0:
                    //    arreglobotones[Contador].ToolTipText = "[F2] - " + arreglobotones[Contador].ToString().tooltiptext;
                    //    break;
                    //case 1:
                    //    arreglobotones[Contador].tooltiptext = "[F3] - " + arreglobotones[Contador].tooltiptext;
                    //    break;
                    //case 2:
                    //    arreglobotones[Contador].tooltiptext = "[CTRL+G] - " + arreglobotones[Contador].tooltiptext;
                    //    break;
                    //case 3:
                    //    arreglobotones[Contador].tooltiptext = "[ESCAPE] - " + arreglobotones[Contador].tooltiptext;
                    //    break;
                    //case 4:
                    //    arreglobotones[Contador].tooltiptext = "[F8] - " + arreglobotones[Contador].tooltiptext;
                    //    break;
                    //case 5:
                    //    if ((arreglobotones[Contador] != null))
                    //    {
                    //        arreglobotones[Contador].tooltiptext = "[F5] - " + arreglobotones[Contador].tooltiptext;
                    //    }
                    //    break;
                    //case 6:
                    //    arreglobotones[Contador].tooltiptext = "[CTRL+B] - " + arreglobotones[Contador].tooltiptext;
                    //    break;
                    //case 7:
                    //    arreglobotones[Contador].tooltiptext = "[ESCAPE] - " + arreglobotones[Contador].tooltiptext;
                    //    break;
                }
            }
        }

    }
    public static string Palabras(string Par_Cadena, int npalabra)
    {
        string xreturn = "";
        int ncontpalabras = 0;
        int VM_CONT = 0;
        int VM_CUENTA = 0;
        Par_Cadena = Par_Cadena.Trim() + " ";
        for (VM_CONT = 1; VM_CONT <= Par_Cadena.Length; VM_CONT++)
        {
            if (Equivalencias.Mid(Par_Cadena, VM_CONT, 1) == " ")
            {
                if (VM_CUENTA + 1 == npalabra)
                {
                    break; 
                }
                else
                {
                    xreturn = "";
                    VM_CUENTA = VM_CUENTA + 1;
                }
            }
            else
            {
                xreturn = xreturn + Equivalencias.Mid(Par_Cadena, VM_CONT, 1);
            }
        }
        return xreturn;
    }
    public static bool SeekNameColumn(DataTable Table, string namecolumn)
    {
        //Indica si existe un nombre de columna en un TABLE , Los nombre los convierte a MAYUSCULAS
        bool zretorno = false;
        foreach (DataColumn column in Table.Columns)
        {
            if (column.ColumnName.ToUpper() == namecolumn.ToUpper())
            {
                zretorno = true;
                break; 
            }
        }
        return zretorno;
    }
    public static bool ValidaOrdenIngresoAlmace(DataTable TablaDetAlmacen, string Lpxalmacen, string LPxxvoucher)
    {
        //Indica si la cantidad registrada en el detalle de Almacen es menor o igual a la especificada en la orden de compra / servicio
        bool zretorno = false;
        // Aca Consolido Detalle de ALmacen x Articulo + Orden
        DataTable listaordenes = TablaDetAlmacen.Clone();
        string xvmnumeroorden = "";
        DataTable Cursor01 = TablaDetAlmacen.Clone();
        bool zUbicar = false;
        DataRow ofila = null;
        int lc_Cont = 0;
        int lcnContCursor = 0;
        //oaplilogic ocapa = new oaplilogic();
        for (lc_Cont = 0; lc_Cont <= TablaDetAlmacen.Rows.Count - 1; lc_Cont++)
        {
            zUbicar = false;
            for (lcnContCursor = 0; lcnContCursor <= listaordenes.Rows.Count - 1; lcnContCursor++)
            {
                if (listaordenes.Rows[lcnContCursor]["ordens_3a"] == TablaDetAlmacen.Rows[lc_Cont]["ordens_3a"])
                {
                    zUbicar = true;
                    break; 
                }
            }
            if (!zUbicar)
            {
                ofila = TablaDetAlmacen.Rows[lc_Cont];
                listaordenes.Rows.Add(UtilitariosInterface.INSERTINTOTABLE(listaordenes));
                lcnContCursor = listaordenes.Rows.Count - 1;
            }
            listaordenes.Rows[lcnContCursor]["ordens_3a"] = TablaDetAlmacen.Rows[lc_Cont]["ordens_3a"];
        }

        listaordenes.AcceptChanges();
        for (lc_Cont = 0; lc_Cont <= TablaDetAlmacen.Rows.Count - 1; lc_Cont++)
        {
            zUbicar = false;
            for (lcnContCursor = 0; lcnContCursor <= Cursor01.Rows.Count - 1; lcnContCursor++)
            {
                if (Cursor01.Rows[lcnContCursor]["linea_3a"] == TablaDetAlmacen.Rows[lc_Cont]["linea_3a"] & Cursor01.Rows[lcnContCursor]["ordens_3a"] == TablaDetAlmacen.Rows[lc_Cont]["ordens_3a"])
                {
                    zUbicar = true;
                    break; 
                }
            }
            if (!zUbicar)
            {
                Cursor01.Rows.Add(UtilitariosInterface.INSERTINTOTABLE(Cursor01));
                lcnContCursor = Cursor01.Rows.Count - 1;
                Cursor01.Rows[lcnContCursor]["cantk_3a"] = 0;
            }
            Cursor01.Rows[lcnContCursor]["linea_3a"] = TablaDetAlmacen.Rows[lc_Cont]["linea_3a"];
            Cursor01.Rows[lcnContCursor]["ordens_3a"] = TablaDetAlmacen.Rows[lc_Cont]["ordens_3a"];

            Cursor01.Rows[lcnContCursor]["cantk_3a"] = Convert.ToInt16(Cursor01.Rows[lcnContCursor]["cantk_3a"]) + Convert.ToInt16(TablaDetAlmacen.Rows[lc_Cont]["cantk_3a"]);
        }

        Cursor01.AcceptChanges();
        DataTable TablaOrdenes = null;
        double ordentonumero = 0;
        int nquantos = 0;
        int qrptassi = 0;
        GlobalVars.GetInstance().SwExcesoNIAxCompras = false;
        GlobalVars.GetInstance().ListaOrdenesNIAS = "";
        //For contordenes = 0 To listaordenes.Rows.Count - 1

        for (lc_Cont = 0; lc_Cont <= Cursor01.Rows.Count - 1; lc_Cont++)
        {
            ordentonumero = Convert.ToInt16(Cursor01.Rows[lc_Cont]["ordens_3a"]);
            xvmnumeroorden = Cursor01.Rows[lc_Cont]["ordens_3a"].ToString();
            if (xvmnumeroorden.Trim().Length == 0)
            {
                xvmnumeroorden = "...";
            }
            //TablaOrdenes = ocapa.spu_generapendienteocompra(GlobalVars.GetInstance().Company, "", "", "", "", "", "", xvmnumeroorden, xvmnumeroorden, "", 2, 1, (ordentonumero > 0 ? "1" : "2"), Lpxalmacen, LPxxvoucher, null);

            zUbicar = false;
            for (lcnContCursor = 0; lcnContCursor <= TablaOrdenes.Rows.Count - 1; lcnContCursor++)
            {
                if (Cursor01.Rows[lc_Cont]["linea_3a"] == TablaOrdenes.Rows[lcnContCursor]["codarticulo"] & Cursor01.Rows[lc_Cont]["ordens_3a"] == TablaOrdenes.Rows[lcnContCursor]["o_compra"])
                {
                    zUbicar = true;
                    if (Convert.ToInt16(Cursor01.Rows[lc_Cont]["cantk_3a"]) > Convert.ToInt16(TablaOrdenes.Rows[lcnContCursor]["saldo"]))
                    {
                        nquantos = nquantos + 1;
                        if (MessageBox.Show("Te excedes en Item " 
                                + TablaOrdenes.Rows[lcnContCursor]["codarticulo"] 
                                + " Orden " + TablaOrdenes.Rows[lcnContCursor]["o_compra"] 
                                + " " + '\r' + " Cantidad pendiente :" 
                                + TablaOrdenes.Rows[lcnContCursor]["saldo"].ToString().Trim() 
                                + " Cantdidad Ingresada " + Cursor01.Rows[lc_Cont]["cantk_3a"].ToString().Trim() 
                                + " Exceso :" + (Convert.ToInt16(Cursor01.Rows[lc_Cont]["cantk_3a"]) - Convert.ToInt16(TablaOrdenes.Rows[lcnContCursor]["saldo"])).ToString().Trim() 
                                + '\r' + "Desea continuar registrando el ingreso ...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            qrptassi = qrptassi + 1;
                            GlobalVars.GetInstance().ListaOrdenesNIAS = GlobalVars.GetInstance().ListaOrdenesNIAS + TablaOrdenes.Rows[lcnContCursor]["o_compra"] + "_";
                        }

                        zretorno = false;
                    }
                    else
                    {
                        zretorno = true;
                    }
                    break; 
                }
            }
            if (!zUbicar)
            {
                MessageBox.Show("Item " + Cursor01.Rows[lc_Cont]["linea_3a"].ToString() + " No hallado en orden " + Cursor01.Rows[lc_Cont]["ordens_3a"].ToString(), " ",MessageBoxButtons.OK, MessageBoxIcon.Error);
                break; 
            }

        }
        // Hubo Excesos
        if (nquantos + qrptassi > 0)
        {
            // Le Dio SI a los excesos
            if (nquantos == qrptassi)
            {
                GlobalVars.GetInstance().SwExcesoNIAxCompras = true;
                zretorno = true;
                //Que pase el ingreso pero que active el flag de exceso
            }
            else
            {
                zretorno = false;
            }
        }
        return zretorno & zUbicar;
    }
    public static void GeneraNominaCTSTelecredito(string FilePath, DataTable tabladatos)
    {
        int i = 0;
        string Cadena = null;
        try
        {
            StreamWriter strStreamW = new StreamWriter(FilePath);
            for (i = 0; i <= tabladatos.Rows.Count - 1; i++)
            {
                //primera fila se genera Cabecera Registro
                if (i == 0)
                {
                    Cadena = tabladatos.Rows[i]["registro_cab"].ToString() + tabladatos.Rows[i]["cant_abonos"] + tabladatos.Rows[i]["f_proceso"] + tabladatos.Rows[i]["tipo_cuenta_cab"] + tabladatos.Rows[i]["moneda_cab"] + tabladatos.Rows[i]["ccta_cts_empresa"] + tabladatos.Rows[i]["tipo_docu_cab"] + tabladatos.Rows[i]["num_docu_cab"] + tabladatos.Rows[i]["monto_cab"] + tabladatos.Rows[i]["referencia_cab"] + tabladatos.Rows[i]["checksum_cuentas"];
                    strStreamW.WriteLine(Cadena);

                }
                Cadena = tabladatos.Rows[i]["registro_det"].ToString() + tabladatos.Rows[i]["cuenta_abono"] + tabladatos.Rows[i]["tipo_documento"] + tabladatos.Rows[i]["numero_documento"] + tabladatos.Rows[i]["corre_documento"] + tabladatos.Rows[i]["nombre_trabajador"] + tabladatos.Rows[i]["referencia_beneficiario"] + tabladatos.Rows[i]["referencia_empresa"] + tabladatos.Rows[i]["MOneda_Importe"] + tabladatos.Rows[i]["monto_detalle"] + "0001" + tabladatos.Rows[i]["monto_Ultimos6sueldos"];

                strStreamW.WriteLine(Cadena);
            }
            strStreamW.Flush();
            strStreamW.Close();
            MessageBox.Show("El archivo se generó con éxito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "ERROR AL GENERAR ARCHIVO");
        }
    }
    public static string Fechahoy()
    {
        string XFECHA = DTOS(DateTime.Now);
        return Equivalencias.Mid(XFECHA, 7, 2) + "/" + Equivalencias.Mid(XFECHA, 5, 2) + "/" + Equivalencias.Mid(XFECHA, 1, 4);
    }

    public static bool ValidaNumero(string texto)
    {
        bool zok = false;
        decimal nnumer = 0;
        try
        {
            nnumer = Convert.ToDecimal(texto);
            zok = true;
        }
        catch (Exception ex)
        {
            zok = false;
        }
        return zok;
    }
    public static decimal BuscarEnTable(object DatoaBuscar, string nombrecampo, DataTable Tabla)
    {
        int npos = 0;
        decimal nretorno = -1;
        if (DatoaBuscar.GetType().ToString().ToUpper() == "system.STRING".ToUpper())
        {
            for (npos = 0; npos <= Tabla.Rows.Count - 1; npos++)
            {
                if (Tabla.Rows[npos].RowState == DataRowState.Deleted)
                {
                }
                else
                {
                    if (Tabla.Rows[npos][nombrecampo] == DatoaBuscar)
                    {
                        nretorno = npos;
                        break; 
                    }
                }
            }
        }
        return nretorno;
        // Mayor a-1
    }
    public static int MaximoDiames(int nperiodo, int nmes)
    {
        int LastDay = 0;
        //-- Bisiesto
        if (nmes == 2 & ((nperiodo / 4) * 4) == nperiodo)
        {
            LastDay = 29;
        }
        //-- NO Bisiesto
        if (nmes == 2 & !(((nperiodo / 4) * 4) == nperiodo))
        {
            LastDay = 28;
        }
        if (nmes == 4 | nmes == 6 | nmes == 9 | nmes == 11)
        {
            LastDay = 30;
        }
        if (!(nmes == 2) & !(nmes == 4) & !(nmes == 6) & !(nmes == 9) & !(nmes == 11))
        {
            LastDay = 31;
        }
        return LastDay;
    }
    public static bool U_ValidaFechaRegistroProvision(string Periodo_Trabajo, string Reg_Mes, System.DateTime Fecha_Registro)
    {
        bool zReturn = false;
        if (Fecha_Registro.Year.ToString() == Periodo_Trabajo & PADL(Fecha_Registro.Month.ToString(), 2, "0") == Reg_Mes)
        {
            zReturn = true;
        }
        if (!zReturn)
        {
            if (!(Fecha_Registro.Year.ToString() == Periodo_Trabajo))
            {
                MessageBox.Show("Año fecha de Registro  no corresponde al periodo actual de trabajo " + Periodo_Trabajo + '\r' + "VERIFIQUE..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!(PADL(Fecha_Registro.Month.ToString(), 2, "0") == Reg_Mes))
                {
                    MessageBox.Show("Mes de Registro no corresponde al mes de la fecha " + PADL(Fecha_Registro.Month.ToString(), 2, "0") + '\r' + "VERIFIQUE..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        return zReturn;
    }
    public static byte[] ImageToByte(System.Drawing.Image pImagen, bool convierteabmp)
    {
        byte[] mImage = null;
        try
        {
            if ((pImagen != null))
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                if (convierteabmp)
                {
                    pImagen.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    //formato BMP para  que no salga error en crystal
                }
                else
                {
                    pImagen.Save(ms, pImagen.RawFormat);
                    //Formato Predeterminado de la imagen
                }

                mImage = ms.GetBuffer();
                ms.Close();
                return mImage;
            }
        }
        catch
        {
        }
        return null;
    }
    public static void CopyToExcel(DataTable Tabla, string TituloHoja, string namecolumnafontbold, object[] valorcolumna, string nomfileaguardar)
    {
        // Variables Excel
        //object oExcel = null;
        //object oBooks = null;
        //object oBook = null;
        //object oSheet = null;
        //object range = null;
        Excel.Application oExcel;
        Excel.Workbook oBook;

        Excel.Workbooks oBooks;
        Excel.Sheets objSheets;
        Excel._Worksheet oSheet;
        Excel.Range range;

        int lc_columna = 0;
        TituloHoja = TituloHoja.Replace("-", "");
        TituloHoja = PADR(TituloHoja, 31, " ");
        TituloHoja = TituloHoja.Trim();
        int ROW_FIRST = 1;
        int iContador = 0;
        bool zCreateOKHoja = true;
        string vmxmsgerror = "";
        System.Windows.Forms.Form oform = new System.Windows.Forms.Form();

        try
        {
            oform.Text = "Espere.... Generando";
            Button btnAdd = new Button();
            btnAdd.AutoSize = true;
            btnAdd.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAdd.Font = new System.Drawing.Font("Tahoma", 20);

            oform.StartPosition = FormStartPosition.CenterScreen;
            oform.ControlBox = false;
            oform.Controls.Add(btnAdd);
            btnAdd.Text = TituloHoja;
            oform.ShowInTaskbar = false;
            oform.Width = btnAdd.Width + 100;
            oform.Height = btnAdd.Height + 100;
            oform.Show();

            // Crear una instancia de Excel e iniciar un nuevo libro.
            oExcel = new Excel.Application();
            oBooks = oExcel.Workbooks;
            oBook = oExcel.Workbooks.Add();
            objSheets = oBook.Worksheets;
            oSheet = (Excel._Worksheet)objSheets.get_Item(1);

            if (TituloHoja.Trim().Length == 0)
            {
            }
            else
            {
                oSheet.Name = TituloHoja;
            }

            // Encabezado
            if (TituloHoja.Trim().Length > 0)
            {
                for (lc_columna = 0; lc_columna <= Tabla.Columns.Count - 1; lc_columna++)
                {
                    oSheet.Cells[ROW_FIRST, lc_columna + 1] = Tabla.Columns[lc_columna].ColumnName;

                    oSheet.Cells[ROW_FIRST, lc_columna + 1].Interior.ColorIndex = 14;
                    oSheet.Cells[ROW_FIRST, lc_columna + 1].Interior.Pattern = 1;
                    oSheet.Cells[ROW_FIRST, lc_columna + 1].Font.ColorIndex = 2;

                    oSheet.Cells[ROW_FIRST, lc_columna + 1].borders(1).LineStyle = 1;
                    oSheet.Cells[ROW_FIRST, lc_columna + 1].borders(1).Weight = 2;
                    oSheet.Cells[ROW_FIRST, lc_columna + 1].borders(2).LineStyle = 1;
                    oSheet.Cells[ROW_FIRST, lc_columna + 1].borders(2).Weight = 2;
                    oSheet.Cells[ROW_FIRST, lc_columna + 1].borders(3).LineStyle = 1;
                    oSheet.Cells[ROW_FIRST, lc_columna + 1].borders(3).Weight = 2;
                    oSheet.Cells[ROW_FIRST, lc_columna + 1].borders(4).LineStyle = 1;
                    oSheet.Cells[ROW_FIRST, lc_columna + 1].borders(4).Weight = 2;
                }
                ROW_FIRST = 2;
            }

            bool vmzpintanegrita = false;
            foreach (DataRow MiDataRow in Tabla.Rows)
            {
                vmzpintanegrita = false;
                for (lc_columna = 0; lc_columna <= Tabla.Columns.Count - 1; lc_columna++)
                {
                    oSheet.Cells[ROW_FIRST, lc_columna + 1] = MiDataRow[lc_columna];
                    if (namecolumnafontbold.Trim().Length > 0)
                    {
                        if (Tabla.Columns[lc_columna].ColumnName.ToUpper() == namecolumnafontbold.ToUpper())
                        {
                            if ((valorcolumna != null))
                            {
                                for (iContador = 0; iContador <= (valorcolumna.Length - 1); iContador++)
                                {
                                    if (MiDataRow[lc_columna] == valorcolumna[iContador])
                                    {
                                        vmzpintanegrita = true;
                                    }
                                }
                            }
                        }
                    }
                    if (vmzpintanegrita)
                    {
                        oSheet.Cells[ROW_FIRST, lc_columna + 1].font.bold = true;
                    }
                }
                ROW_FIRST = ROW_FIRST + 1;
            }
            for (lc_columna = 0; lc_columna <= Tabla.Columns.Count - 1; lc_columna++)
            {
                range = oSheet.Columns[lc_columna + 1];
                range.Font.Name = "Tahoma";
                range.Font.Size = 8;
                range.AutoFit();
            }

            // Control a USuario
            if (nomfileaguardar.Trim().Length == 0)
            {
                oExcel.Visible = true;
                oExcel.UserControl = true;
            }
            else
            {
                if (nomfileaguardar.Trim().Length > 0)
                {
                    oExcel.Application.DisplayAlerts = false;
                    oSheet.SaveAs(nomfileaguardar);
                    oExcel.Quit();
                    if (MessageBox.Show("Desea abrir archivo " + nomfileaguardar + "...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(nomfileaguardar);
                    }
                }
            }
            //Cierra Todo
        }
        catch (Exception ex)
        {
            zCreateOKHoja = false;
            vmxmsgerror = ex.Message;
        }
        oBooks = null;
        oBook = null;
        oSheet = null;
        range = null;
        oExcel = null;

        if (zCreateOKHoja)
        {
        }
        else
        {
            MessageBox.Show(vmxmsgerror + '\r' + "ERROR ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        oform.Close();
        oform = null;
    }

    public static string Addbs(string NameDirect)
    {
        //Devuelve un nombre de Directorio con su \ al final
        string retorno = "";
        NameDirect = NameDirect.Trim();
        if (NameDirect.Length > 0)
        {
            if (!(Equivalencias.Mid(NameDirect, Equivalencias.Len(NameDirect), 1) == "\\"))
            {
                retorno = NameDirect + "\\";
            }
            else
            {
                retorno = NameDirect;
            }
        }
        return retorno;
    }
    public static string GetExtensionFile(string File)
    {
        //Obtiene la extension de un archivo
        string retorno = "";
        int lc_contador = 0;
        File = File.Trim();
        if (File.Length > 0)
        {
            if (File.IndexOf(".") > 0)
            {
                for (lc_contador = File.Length; lc_contador >= 1; lc_contador += -1)
                {
                    if (Equivalencias.Mid(File, lc_contador, 1) == ".")
                    {
                        break; 
                    }
                    else
                    {
                        retorno = Equivalencias.Mid(File, lc_contador, 1) + retorno;
                    }
                }
            }
        }
        return retorno;
    }
    public static string NombreAleatorio(string direc, string archivo)
    {
        // Genera un nombre aleatorio para un archivo 
        int a = 0;
        string nom = "";
        string xconstante = "PCGIMG";
        try
        {
            for (a = 1; a <= 9999; a++)
            {
                nom = "";
                nom = direc.Trim() + xconstante + PADL(a.ToString(), 4, "0").ToString().Trim() + "." + GetExtensionFile(archivo);
                ////+ "_" + archivo.Trim
                //if (My.Computer.FileSystem.FileExists(nom) == false)
                //{
                //    break; 
                //}
            }
        }
        catch (Exception ex)
        {
            nom = direc + archivo;
            // en caso de error retorna el mismo nombre
        }
        return nom;
    }
    public static bool CopiarArchivo(string xnomfile)
    {
        bool retorno = false;
        //if (xnomfile.Length > 0)
        //{
        //    retorno = false;
        //    string newname = NombreAleatorio(GlobalVars.GetInstance().RutaImagenes, xnomfile);
        //    try
        //    {
        //        System.IO.File.Copy(xnomfile, newname, true);
        //        GlobalVars.GetInstance().NombreArchivoSubido = System.IO.Path.GetFileName(newname);
        //        retorno = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        GlobalVars.GetInstance().NombreArchivoSubido = "";
        //        MessageBox.Show(ex.Message, "Error al Subir Imagen a La Base de Datos");
        //        retorno = false;
        //    }
        //}
        return retorno;
    }
    public static string CurrentNameObject(System.Windows.Forms.Form frm)
    {
        // Retorna el Nombre del objeto actual que tiene el foco en un form
        int x = 0;
        string x_return = "";
        while (x <= frm.Controls.Count - 1)
        {
            if ((frm.Controls[x].Focused))
            {
                x_return = frm.Controls[x].Name.ToUpper();
                break; 
            }
            x += 1;
        }
        return x_return;
    }
    public static void SeteaBotonesArray(Form oform, object[] Objeto, string[] KeyTETX)
    {
        int prvcont = 0;
        string vmxmsg = "";
        var _with2 = oform;
        for (prvcont = 0; prvcont <= Objeto.Length - 1; prvcont++)
        {
            vmxmsg = "";
            if ((KeyTETX[prvcont] != null))
            {
                if ((!object.ReferenceEquals(KeyTETX[prvcont], DBNull.Value)))
                {
                    vmxmsg = KeyTETX[prvcont];
                }
            }
            if ((Objeto[prvcont] != null))
            {
                //Objeto[prvcont].ToolTipText = "[ " + KeyTETX[prvcont] + " ]-" + Objeto[prvcont].ToolTipText;
                Objeto[prvcont] = "[ " + KeyTETX[prvcont] + " ]-" + Objeto[prvcont];
            }
        }
    }
    //public static bool ValidarCierretalleres(string ccia, string Almacen, string Periodo, string Mes, System.DateTime Fecha, bool znoshowmsg)
    //{
    //    string FechaE = Fecha.ToShortDateString().Trim();
    //    FechaE = Equivalencias.Mid(FechaE, 7, 4) + Equivalencias.Mid(FechaE, 4, 2) + Equivalencias.Mid(FechaE, 1, 2);
    //    oaplilogic ocapa = new oaplilogic();
    //    return ocapa.ValidarCierreTalleres(ccia.Trim(), Almacen.Trim(), Periodo.Trim(), "", FechaE.Trim(), znoshowmsg);
    //}
    public static void GeneraArchivoPdbcompras(string FilePath, DataTable tabladatos)
    {
        int i = 0;
        string Cadena = null;

        try
        {
            StreamWriter strStreamW = new StreamWriter(FilePath);
            string xcharseparador = Convert.ToChar(124).ToString();
            for (i = 0; i <= tabladatos.Rows.Count - 1; i++)
            {
                Cadena = tabladatos.Rows[i]["TIPO_COMPRA"] + xcharseparador + tabladatos.Rows[i]["TIPO_COMPROBANTE"] + xcharseparador + tabladatos.Rows[i]["F_EMISION"] + xcharseparador + tabladatos.Rows[i]["SERIE_COMPROBANTE"] + xcharseparador + tabladatos.Rows[i]["NUMERO_COMPROBANTE"] + xcharseparador + tabladatos.Rows[i]["TIPO_PERSONA"] + xcharseparador + tabladatos.Rows[i]["TIPO_IDENTIFICACION"] + xcharseparador + tabladatos.Rows[i]["NUMERO_DOCUMENTO"] + xcharseparador + tabladatos.Rows[i]["RAZON_SOCIAL"] + xcharseparador + tabladatos.Rows[i]["APELLIDO_PATERNO"] + xcharseparador + tabladatos.Rows[i]["APELLIDO_MATERNO"] + xcharseparador + tabladatos.Rows[i]["NOMBRE_1"] + xcharseparador + tabladatos.Rows[i]["NOMBRE_2"] + xcharseparador + tabladatos.Rows[i]["TIPO_MONEDA"] + xcharseparador + tabladatos.Rows[i]["CODIGO_DESTINO"] + xcharseparador + tabladatos.Rows[i]["numero_destino"] + xcharseparador + tabladatos.Rows[i]["BASE_IMPONIBLE"].ToString() + xcharseparador + tabladatos.Rows[i]["ISC"].ToString() + xcharseparador + tabladatos.Rows[i]["MONTO_IGV"].ToString() + xcharseparador + tabladatos.Rows[i]["OTROS"].ToString() + xcharseparador + tabladatos.Rows[i]["INDICADOR_DETRACCION"] + xcharseparador + tabladatos.Rows[i]["CODIGO_DETRACCION"] + xcharseparador + tabladatos.Rows[i]["NUMERO_DETRACCION"] + xcharseparador + tabladatos.Rows[i]["INDICADOR_RETENCION"] + xcharseparador + tabladatos.Rows[i]["TIPO_COMPROBANTE_REF"] + xcharseparador + tabladatos.Rows[i]["SERIE_COMPROBANTE_REF"] + xcharseparador + tabladatos.Rows[i]["NUMERO_COMPROBANTE_REF"] + xcharseparador + tabladatos.Rows[i]["F_EMISION_REF"] + xcharseparador + tabladatos.Rows[i]["BASE_IMPONIBLE_REF"].ToString() + xcharseparador + tabladatos.Rows[i]["MONTO_IGV_REF"].ToString() + xcharseparador;

                strStreamW.WriteLine(Cadena);
            }
            strStreamW.Flush();
            strStreamW.Close();
            MessageBox.Show("El archivo " + FilePath + Convert.ToChar(13) + "se generó con éxito", "",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "ERROR AL GENERAR ARCHIVO PDB-COMPRAS");
        }
    }
    public static void GeneraArchivoPdbTcambio(string FilePath, DataTable tabladatos)
    {
        int i = 0;
        string Cadena = null;
        try
        {
            StreamWriter strStreamW = new StreamWriter(FilePath);
            string xcharseparador = Convert.ToChar(124).ToString();

            for (i = 0; i <= tabladatos.Rows.Count - 1; i++)
            {
                Cadena = tabladatos.Rows[i]["FECHA"] + xcharseparador + tabladatos.Rows[i]["COMPRA"] + xcharseparador + tabladatos.Rows[i]["VENTA"] + xcharseparador;
                strStreamW.WriteLine(Cadena);
            }
            strStreamW.Flush();
            strStreamW.Close();
            MessageBox.Show("El archivo " + FilePath + Convert.ToChar(13) + "se generó con éxito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "ERROR AL GENERAR ARCHIVO TIPO DE CAMBIO");
        }
    }
    public static void GeneraArchivoPdbVentas(string FilePath, DataTable tabladatos)
    {
        int i = 0;
        string Cadena = null;
        try
        {
            StreamWriter strStreamW = new StreamWriter(FilePath);
            string xcharseparador = Convert.ToChar(124).ToString();

            for (i = 0; i <= tabladatos.Rows.Count - 1; i++)
            {
                Cadena = tabladatos.Rows[i]["TIPO_VENTA"] + xcharseparador + tabladatos.Rows[i]["TIPO_COMPROBANTE"] + xcharseparador + tabladatos.Rows[i]["F_EMISION"] + xcharseparador + tabladatos.Rows[i]["SERIE_COMPROBANTE"] + xcharseparador + tabladatos.Rows[i]["NUMERO_COMPROBANTE"] + xcharseparador + tabladatos.Rows[i]["TIPO_PERSONA"] + xcharseparador + tabladatos.Rows[i]["TIPO_IDENTIFICACION"] + xcharseparador + tabladatos.Rows[i]["NUMERO_DOCUMENTO"] + xcharseparador + tabladatos.Rows[i]["RAZON_SOCIAL"] + xcharseparador + tabladatos.Rows[i]["APELLIDO_PATERNO"] + xcharseparador + tabladatos.Rows[i]["APELLIDO_MATERNO"] + xcharseparador + tabladatos.Rows[i]["NOMBRE_1"] + xcharseparador + tabladatos.Rows[i]["NOMBRE_2"] + xcharseparador + tabladatos.Rows[i]["TIPO_MONEDA"] + xcharseparador + tabladatos.Rows[i]["CODIGO_DESTINO"] + xcharseparador + tabladatos.Rows[i]["numero_destino"] + xcharseparador + tabladatos.Rows[i]["BASE_IMPONIBLE"].ToString() + xcharseparador + tabladatos.Rows[i]["ISC"].ToString() + xcharseparador + tabladatos.Rows[i]["MONTO_IGV"].ToString() + xcharseparador + tabladatos.Rows[i]["OTROS"].ToString() + xcharseparador + tabladatos.Rows[i]["INDICADOR_PERCEPCION"] + xcharseparador + tabladatos.Rows[i]["TASA_PERCEPCION"] + xcharseparador + tabladatos.Rows[i]["SERIE_DOC_PERCEPCION"] + xcharseparador + tabladatos.Rows[i]["NUM_DOC_PERCEPCION"] + xcharseparador + tabladatos.Rows[i]["TIPO_COMPROBANTE_REF"] + xcharseparador + tabladatos.Rows[i]["SERIE_COMPROBANTE_REF"] + xcharseparador + tabladatos.Rows[i]["NUMERO_COMPROBANTE_REF"] + xcharseparador + tabladatos.Rows[i]["F_EMISION_REF"] + xcharseparador + tabladatos.Rows[i]["BASE_IMPONIBLE_REF"].ToString() + xcharseparador + tabladatos.Rows[i]["MONTO_IGV_REF"].ToString() + xcharseparador;

                strStreamW.WriteLine(Cadena);
            }
            strStreamW.Flush();
            strStreamW.Close();
            MessageBox.Show("El archivo " + FilePath + Convert.ToChar(13) + "se generó con éxito", "",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "ERROR AL GENERAR ARCHIVO PDB-VENTAS");
        }
    }
    public static void GeneraArchivoPdbFormaPago(string FilePath, DataTable tabladatos)
    {
        int i = 0;
        string Cadena = null;
        try
        {
            StreamWriter strStreamW = new StreamWriter(FilePath);
            string xcharseparador = Convert.ToChar(124).ToString();

            for (i = 0; i <= tabladatos.Rows.Count - 1; i++)
            {
                Cadena = tabladatos.Rows[i]["TIPO_COMPRA"] + xcharseparador + tabladatos.Rows[i]["TIPO_COMPROBANTE"] + xcharseparador + tabladatos.Rows[i]["SERIE_COMPROBANTE"] + xcharseparador + tabladatos.Rows[i]["NUMERO_COMPROBANTE"] + xcharseparador + tabladatos.Rows[i]["TIPO_PERSONA"] + xcharseparador + tabladatos.Rows[i]["TIPO_IDENTIFICACION"] + xcharseparador + tabladatos.Rows[i]["NUMERO_DOCUMENTO"] + xcharseparador + tabladatos.Rows[i]["CODPAGO"] + xcharseparador + tabladatos.Rows[i]["CODBANCO"] + xcharseparador + tabladatos.Rows[i]["NUMPAGO"] + xcharseparador + tabladatos.Rows[i]["F_OPERACION"] + xcharseparador + tabladatos.Rows[i]["Importe_Pago"].ToString() + xcharseparador;

                strStreamW.WriteLine(Cadena);
            }
            strStreamW.Flush();
            strStreamW.Close();
            MessageBox.Show("El archivo " + FilePath + Convert.ToChar(13) + "se generó con éxito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "ERROR AL GENERAR ARCHIVO FORMAS DE PAGO");
        }
    }
    public static void GeneraArchivoPdbDuas(string FilePath, DataTable tabladatos)
    {
        int i = 0;
        string Cadena = null;
        try
        {
            StreamWriter strStreamW = new StreamWriter(FilePath);
            string xcharseparador = Convert.ToChar(124).ToString();

            for (i = 0; i <= tabladatos.Rows.Count - 1; i++)
            {
                Cadena = tabladatos.Rows[i]["cod_aduana"] + xcharseparador + tabladatos.Rows[i]["periodo_dua"] + xcharseparador + tabladatos.Rows[i]["correlativo_dua"] + xcharseparador + tabladatos.Rows[i]["fecha_embarque"] + xcharseparador + tabladatos.Rows[i]["fecha_regularizacion"] + xcharseparador + tabladatos.Rows[i]["dua_fob"].ToString() + xcharseparador;

                strStreamW.WriteLine(Cadena);
            }
            strStreamW.Flush();
            strStreamW.Close();
            MessageBox.Show("El archivo " + FilePath + Convert.ToChar(13) + "se generó con éxito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "ERROR AL GENERAR ARCHIVO DUAS");
        }
    }
    public static void RoleoGrid(System.Windows.Forms.DataGridView Grid, string xTipo, string xnamecolumna)
    {
        int nposreg = 0;
        int ncurrentfila = 0;
        int ncurrentcol = 0;
        try
        {
            nposreg = Grid.CurrentRow.Index;
            ncurrentfila = Grid.CurrentRow.Index;
            ncurrentcol = Grid.CurrentCell.ColumnIndex;
            if (xTipo == GlobalVars.GetInstance().TOPRECORD)
            {
                nposreg = 0;
            }
            if (xTipo == GlobalVars.GetInstance().BOTTRECORD)
            {
                nposreg = Grid.RowCount - 1;
            }
            if (xTipo == GlobalVars.GetInstance().NEXTRECORD)
            {
                if (nposreg < Grid.RowCount - 1)
                {
                    nposreg = nposreg + 1;
                }
            }
            if (xTipo == GlobalVars.GetInstance().PREVRECORD)
            {
                if (nposreg > 0)
                {
                    nposreg = nposreg - 1;
                }
            }
            Grid.CurrentCell = Grid.Rows[nposreg].Cells[Grid.CurrentCell.ColumnIndex];
        }
        catch (Exception ex)
        {
            Grid.CurrentCell = Grid.Rows[ncurrentfila].Cells[ncurrentcol];
        }
    }

    public static void SetKey(DataGridView Grid, string NomColumna, object ValorColumna, string NomColumnaFocus)
    {
        bool zhallado = false;
        int vncont = 0;
        int nfirsline = -1;
        int ncurrentfila = -1;
        int ncurrentcol = -1;
        if ((Grid.CurrentCell != null))
        {
            if (Grid.Rows[Grid.CurrentCell.RowIndex].Cells[NomColumna].Value == ValorColumna)
            {
                ncurrentfila = Grid.CurrentCell.RowIndex;
            }
        }
        Grid.CurrentCell = null;

        for (vncont = 0; vncont <= Grid.Rows.Count - 1; vncont++)
        {
            if (Grid.Rows[vncont].Cells[NomColumna].Value == ValorColumna)
            {
                Grid.Rows[vncont].Visible = true;


                zhallado = true;
                if (nfirsline == -1)
                {
                    nfirsline = vncont;
                }
            }
            else
            {
                Grid.Rows[vncont].Visible = false;

            }
        }
        if (zhallado)
        {
            if (ncurrentfila == -1)
            {
                Grid.CurrentCell = Grid.Rows[nfirsline].Cells[NomColumnaFocus];
            }
            else
            {
                Grid.CurrentCell = Grid.Rows[ncurrentfila].Cells[NomColumnaFocus];
            }
        }
        else
        {
            for (vncont = 0; vncont <= Grid.Rows.Count - 1; vncont++)
            {
                Grid.Rows[vncont].Visible = false;
            }
        }
    }
    public static void SetCurrentCetllVisible(DataGridView Grid, string NomColumna, object ValorColumna, string NomColumnaFocus)
    {
        // Se Ubica en la ultima fila visible
        bool zhallado = false;
        int vncont = 0;
        int nfirsline = -1;
        int ncurrentfila = -1;
        int ncurrentcol = -1;
        for (vncont = 0; vncont <= Grid.Rows.Count - 1; vncont++)
        {
            if (Grid.Rows[vncont].Visible)
            {
                if (ValorColumna == null)
                {
                    zhallado = true;
                    nfirsline = vncont;
                }
                else
                {
                    if (Grid.Rows[vncont].Cells[NomColumna].Value == ValorColumna)
                    {
                        zhallado = true;
                        nfirsline = vncont;
                    }
                }
            }
        }
        if (zhallado)
        {
            Grid.CurrentCell = Grid.Rows[nfirsline].Cells[NomColumnaFocus];
        }
    }
    public static string GeneraArchivoRptsDatosTrab(string FilePath, DataTable tabladatos)
    {
        int i = 0;
        string xmsg = "";
        string Cadena = null;
        try
        {
            StreamWriter strStreamW = new StreamWriter(FilePath);
            string xcharseparador = Convert.ToChar(124).ToString();

            for (i = 0; i <= tabladatos.Rows.Count - 1; i++)
            {
                Cadena = tabladatos.Rows[i]["tipo_docu"] + xcharseparador + tabladatos.Rows[i]["num_doc"] + xcharseparador + tabladatos.Rows[i]["tipo_trabajador"] + xcharseparador + tabladatos.Rows[i]["regimen_laboral"] + xcharseparador + tabladatos.Rows[i]["nivel_educativo"] + xcharseparador + tabladatos.Rows[i]["ocupacion"].ToString() + xcharseparador + tabladatos.Rows[i]["discapacidad"].ToString() + xcharseparador + tabladatos.Rows[i]["regimen_pensionario"] + xcharseparador + tabladatos.Rows[i]["fecinscripcion"] + xcharseparador + tabladatos.Rows[i]["cussp"] + xcharseparador + tabladatos.Rows[i]["esalud"] + xcharseparador + tabladatos.Rows[i]["pension"] + xcharseparador + tabladatos.Rows[i]["tipo_contrato"] + xcharseparador + tabladatos.Rows[i]["sujeto_regimen"] + xcharseparador + tabladatos.Rows[i]["sujeto_jornada_trabajo"] + xcharseparador + tabladatos.Rows[i]["sujeto_hornocturno"] + xcharseparador + tabladatos.Rows[i]["tiene_ingquinta"] + xcharseparador + tabladatos.Rows[i]["sindicato"] + xcharseparador + tabladatos.Rows[i]["periodicidad_remun"] + xcharseparador + tabladatos.Rows[i]["afilado_esp"] + xcharseparador + tabladatos.Rows[i]["codigo_eps"] + xcharseparador + tabladatos.Rows[i]["situacion"] + xcharseparador + tabladatos.Rows[i]["rentas_exoneradas"] + xcharseparador + tabladatos.Rows[i]["sitesptrab"] + xcharseparador + tabladatos.Rows[i]["tipo_pago"] + xcharseparador + tabladatos.Rows[i]["afiliacion_pension"] + xcharseparador + tabladatos.Rows[i]["categocup"] + xcharseparador + tabladatos.Rows[i]["convenio_dobletrib"] + xcharseparador;

                strStreamW.WriteLine(Cadena);
            }
            strStreamW.Flush();
            strStreamW.Close();
            //MsgBox("El archivo " + FilePath + Chr(13) + "se generó con éxito", MsgBoxStyle.Information, "")
        }
        catch (Exception ex)
        {
            xmsg = ex.Message;
        }
        return xmsg;
    }
    public static string GeneraArchivoRptsPeriodosLaborales(string FilePath, DataTable tabladatos)
    {
        int i = 0;
        string xmsgerror = "";
        string Cadena = null;
        try
        {
            StreamWriter strStreamW = new StreamWriter(FilePath);
            string xcharseparador = Convert.ToChar(124).ToString();

            for (i = 0; i <= tabladatos.Rows.Count - 1; i++)
            {
                Cadena = tabladatos.Rows[i]["tipo_docu"] + xcharseparador + tabladatos.Rows[i]["num_doc"] + xcharseparador + tabladatos.Rows[i]["categoria"] + xcharseparador + tabladatos.Rows[i]["fechainicio"] + xcharseparador + tabladatos.Rows[i]["fechafin"] + xcharseparador + tabladatos.Rows[i]["motivocese"].ToString() + xcharseparador + tabladatos.Rows[i]["modalidad"] + xcharseparador;

                strStreamW.WriteLine(Cadena);
            }
            strStreamW.Flush();
            strStreamW.Close();
            //            MsgBox("El archivo " + FilePath + Chr(13) + "se generó con éxito", MsgBoxStyle.Information, "")
        }
        catch (Exception ex)
        {
            xmsgerror = ex.Message;
        }
        return xmsgerror;
    }
    public static string GeneraArchivoRptsRHP(string FilePath, DataTable tabladatos)
    {
        int i = 0;
        string xmsgerror = "";
        string Cadena = null;
        try
        {
            StreamWriter strStreamW = new StreamWriter(FilePath);
            string xcharseparador = Convert.ToChar(124).ToString();

            for (i = 0; i <= tabladatos.Rows.Count - 1; i++)
            {
                Cadena = tabladatos.Rows[i]["tipo_docu"] + xcharseparador + tabladatos.Rows[i]["num_doc"] + xcharseparador + tabladatos.Rows[i]["tipo_comprobante"] + xcharseparador + tabladatos.Rows[i]["serie_comprobante"] + xcharseparador + tabladatos.Rows[i]["numero_comprobante"] + xcharseparador + tabladatos.Rows[i]["monto_total"].ToString() + xcharseparador + tabladatos.Rows[i]["f_emision"] + xcharseparador + tabladatos.Rows[i]["f_pago"] + xcharseparador + tabladatos.Rows[i]["tiene_retencion"].ToString() + xcharseparador;

                strStreamW.WriteLine(Cadena);
            }
            strStreamW.Flush();
            strStreamW.Close();
            //MsgBox("El archivo " + FilePath + Chr(13) + "se generó con éxito", MsgBoxStyle.Information, "")
        }
        catch (Exception ex)
        {
            //MsgBox(ex.Message, 16, "ERROR AL GENERAR ARCHIVO DUAS")
            xmsgerror = ex.Message;
        }
        return xmsgerror;
    }
    public static string GeneraArchivoRptsDatosPrincipalesTrab(string FilePath, DataTable tabladatos)
    {
        int i = 0;
        string Cadena = null;
        string xmsgerrro = "";
        try
        {
            StreamWriter strStreamW = new StreamWriter(FilePath);
            string xcharseparador = Convert.ToChar(124).ToString();

            for (i = 0; i <= tabladatos.Rows.Count - 1; i++)
            {
                Cadena = tabladatos.Rows[i]["tipo_docu"] + xcharseparador + tabladatos.Rows[i]["num_doc"] + xcharseparador + tabladatos.Rows[i]["apellido_pat"] + xcharseparador + tabladatos.Rows[i]["apellido_mat"] + xcharseparador + tabladatos.Rows[i]["nombres"] + xcharseparador + tabladatos.Rows[i]["fechanac"].ToString() + xcharseparador + tabladatos.Rows[i]["sexo"].ToString() + xcharseparador + tabladatos.Rows[i]["nacionalidad"] + xcharseparador + tabladatos.Rows[i]["telefono"] + xcharseparador + tabladatos.Rows[i]["email"] + xcharseparador + tabladatos.Rows[i]["tiene_esalud"] + xcharseparador + tabladatos.Rows[i]["domiciliado"] + xcharseparador + tabladatos.Rows[i]["tipo_via"] + xcharseparador + tabladatos.Rows[i]["nombre_via"] + xcharseparador + tabladatos.Rows[i]["numero_via"] + xcharseparador + tabladatos.Rows[i]["int_via"] + xcharseparador + tabladatos.Rows[i]["tipo_zona"] + xcharseparador + tabladatos.Rows[i]["nombre_zona"] + xcharseparador + tabladatos.Rows[i]["referencia"] + xcharseparador + tabladatos.Rows[i]["ubigeo"] + xcharseparador;

                strStreamW.WriteLine(Cadena);
            }
            strStreamW.Flush();
            strStreamW.Close();
            //¿MsgBox("El archivo " + FilePath + Chr(13) + "se generó con éxito", MsgBoxStyle.Information, "")
        }
        catch (Exception ex)
        {
            //MsgBox(ex.Message, 16, "ERROR AL GENERAR ARCHIVO DUAS")
            xmsgerrro = ex.Message;
        }
        return xmsgerrro;
    }
    public static string GeneraArchivoRptsEstablecimientosLaborables(string FilePath, DataTable tabladatos)
    {
        int i = 0;
        string xmsgerror = "";
        string Cadena = null;
        try
        {
            StreamWriter strStreamW = new StreamWriter(FilePath);
            string xcharseparador = Convert.ToChar(124).ToString();

            for (i = 0; i <= tabladatos.Rows.Count - 1; i++)
            {
                Cadena = tabladatos.Rows[i]["tipo_docu"] + xcharseparador + tabladatos.Rows[i]["num_doc"] + xcharseparador + tabladatos.Rows[i]["ruc_empresa"] + xcharseparador + tabladatos.Rows[i]["cod_establecimiento"] + xcharseparador + (Convert.ToInt16(tabladatos.Rows[i]["tasa_sctr"]) == 0 ? "" : tabladatos.Rows[i]["tasa_sctr"].ToString()) + xcharseparador;

                strStreamW.WriteLine(Cadena);
            }
            strStreamW.Flush();
            strStreamW.Close();
            //            MsgBox("El archivo " + FilePath + Chr(13) + "se generó con éxito", MsgBoxStyle.Information, "")
        }
        catch (Exception ex)
        {
            xmsgerror = ex.Message;
        }
        return xmsgerror;
    }
    public static string GeneraArchivoRptsIngAporDctos(string FilePath, DataTable tabladatos)
    {
        int i = 0;
        string xmsgerror = "";
        string Cadena = null;
        try
        {
            StreamWriter strStreamW = new StreamWriter(FilePath);
            string xcharseparador = Convert.ToChar(124).ToString();

            for (i = 0; i <= tabladatos.Rows.Count - 1; i++)
            {
                Cadena = tabladatos.Rows[i]["tipo_docu"] + xcharseparador + tabladatos.Rows[i]["num_doc"] + xcharseparador + tabladatos.Rows[i]["codconcepto"] + xcharseparador + tabladatos.Rows[i]["monto_devengado"].ToString() + xcharseparador + tabladatos.Rows[i]["monto_pagdesc"].ToString() + xcharseparador;

                strStreamW.WriteLine(Cadena);
            }
            strStreamW.Flush();
            strStreamW.Close();
            //            MsgBox("El archivo " + FilePath + Chr(13) + "se generó con éxito", MsgBoxStyle.Information, "")
        }
        catch (Exception ex)
        {
            xmsgerror = ex.Message;
        }
        return xmsgerror;
    }
    //public static System.Drawing.Image GetImagen(string nameimagen)
    //{
    //    //Diferencia Mayuscula de Minúscula
    //    return My.Resources.ResourceManager.GetObject(nameimagen.Trim());
    //}
    public static string ConvierteFileToBmp(string nombrefile)
    {
        string xtmpfile = "";
        try
        {
            System.Drawing.Image pImagen = System.Drawing.Image.FromFile(nombrefile);
            if ((pImagen != null))
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                xtmpfile = System.IO.Path.GetTempFileName();
                pImagen.Save(xtmpfile, System.Drawing.Imaging.ImageFormat.Bmp);
                //formato BMP para  que no salga error en crystal                
            }
        }
        catch
        {
            xtmpfile = "";
        }
        return xtmpfile;
    }
    public static void GuardarImagen(System.Windows.Forms.PictureBox LpImagen)
    {
        string ruta = "";
        System.Windows.Forms.SaveFileDialog SaveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
        SaveFileDialog1.CheckFileExists = false;
        SaveFileDialog1.Filter = "Archivos de Imagenes (*.jpg)|*.jpg|Archivos de Imagenes (*.gif)|*.gif|Archivos de Imagenes (*.bmp)|*.bmp|Archivos de Imagenes (*.Png)|*.Png";
        SaveFileDialog1.Title = "Exportar Imagen";
        SaveFileDialog1.FileName = LpImagen.ImageLocation;
        if (SaveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            ruta = SaveFileDialog1.FileName;
            try
            {
                LpImagen.Image.Save(ruta);
                MessageBox.Show("Se exportó imagen a " + Convert.ToChar(13) + ruta, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    //public void DataTableToExcel(DataTable pDataTable)
    //{
    //    //x VER
    //    string vFileName = Path.GetTempFileName();

    //    FileSystem.FileOpen(1, vFileName, OpenMode.Output);

    //    string sb = "";
    //    DataColumn dc = null;
    //    foreach (DataColumn dc_loopVariable in pDataTable.Columns)
    //    {
    //        dc = dc_loopVariable;
    //        sb += dc.Caption + Microsoft.VisualBasic.ControlChars.Tab;
    //    }
    //    FileSystem.PrintLine(1, sb);

    //    int i = 0;
    //    DataRow dr = null;
    //    foreach (DataRow dr_loopVariable in pDataTable.Rows)
    //    {
    //        dr = dr_loopVariable;
    //        i = 0;
    //        sb = "";
    //        foreach (DataColumn dc_loopVariable in pDataTable.Columns)
    //        {
    //            dc = dc_loopVariable;
    //            if (!Information.IsDBNull(dr[i]))
    //            {
    //                sb += Convert.ToString(dr[i]) + Microsoft.VisualBasic.ControlChars.Tab;
    //            }
    //            else
    //            {
    //                sb += Microsoft.VisualBasic.ControlChars.Tab;
    //            }
    //            i += 1;
    //        }
    //        FileSystem.PrintLine(1, sb);
    //    }
    //    FileSystem.FileClose(1);
    //}
    public static DataTable Zap(DataTable Table)
    {
        Table.AcceptChanges();
        int vmnrow = 0;
        for (vmnrow = 0; vmnrow <= Table.Rows.Count - 1; vmnrow++)
        {
            Table.Rows[vmnrow].Delete();
        }
        Table.AcceptChanges();
        return Table;
    }
    //public static bool ValidarCierreContables(string ccia, string Almacen, string Periodo, string Mes, System.DateTime Fecha, bool znoshowmsg)
    //{
    //    string FechaE = Fecha.ToShortDateString().Trim();
    //    FechaE = Equivalencias.Mid(FechaE, 7, 4) + Equivalencias.Mid(FechaE, 4, 2) + Equivalencias.Mid(FechaE, 1, 2);
    //    //oaplilogic ocapa = new oaplilogic();
    //    //return ocapa.ValidarCierreAlmacenesContables(ccia.Trim(), Almacen.Trim(), Periodo.Trim(), "", FechaE.Trim(), znoshowmsg);
    //}
    public static string NombreHojaExcel(string file, int nrohoja)
    {
        //Devuelve el nombre de una hoja de un archivo de excel , empieza por el número 1
        object xlApp = null;
        object wb = null;
        int nindicehojas = 0;
        string namehojareturn = "";
        try
        {
            ////Se Crea Objeto Excel
            //xlApp = Interaction.CreateObject("Excel.Application");
            ////Se Abre el archivo
            //wb = xlApp.Workbooks.Open(file);
            //// Recorrermos la colección de hojas de cálculo    
            //for (nindicehojas = 1; nindicehojas <= xlApp.Worksheets.Count; nindicehojas++)
            //{
            //    namehojareturn = xlApp.Sheets(nindicehojas).name;
            //    if (nindicehojas == nrohoja)
            //    {
            //        break;
            //    }
            //}
            //// Cerramos el libro de trabajo.        
            //wb.Close();
            //wb = null;
            ////Cerramos Excel.        
            //xlApp.Quit();
            //xlApp = null;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "ERROR AL OBTENER HOJAS DE EXCEL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return namehojareturn;
    }
    public static DataTable ImportFromExcel(string LpNomfile)
    {
        //Abre una Hoja de Excel y devuelve el contenido en un datatable
        string nombrehojas = "";
        DataSet objdataset = new DataSet();
        DataView tablasetview = null;
        DataTable tablareturn = new DataTable();
        tablareturn = null;
        nombrehojas = NombreHojaExcel(LpNomfile, 1);
        string conexionexcel = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + LpNomfile + ";Extended Properties=\"Excel 8.0;HDR=Yes;\"";
        try
        {
            System.Data.OleDb.OleDbConnection conexion = new System.Data.OleDb.OleDbConnection(conexionexcel);
            conexion.Open();
            System.Data.OleDb.OleDbCommand objcmdselect = new System.Data.OleDb.OleDbCommand("select * from [" + nombrehojas + "$]", conexion);
            System.Data.OleDb.OleDbDataAdapter objadaptador = new System.Data.OleDb.OleDbDataAdapter();
            objadaptador.SelectCommand = objcmdselect;
            objadaptador.Fill(objdataset, "XLDATA");
            tablasetview = objdataset.Tables[0].DefaultView;
            conexion.Close();
            tablareturn = tablasetview.Table;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message + Convert.ToChar(13) + "Problemas al Importar Hoja de Excel ..." + Convert.ToChar(13) + "Reintente y/o reinicie PC" + Convert.ToChar(13) + "De persistir el problema comuníquese con soporte técnico", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return tablareturn;
    }
    //public static void CopyToExcelPlanillaOficial(DataTable Tabla, string TituloHoja, string nomfileaguardar)
    //{
    //    int lc_columna = 0;
    //    int ROW_FIRST = 1;
    //    bool zCreateOKHoja = true;
    //    string vmxmsgerror = "";
    //    System.Windows.Forms.Form oform = new System.Windows.Forms.Form();
    //    string xvmcampo = "";
    //    //Objetos de AutomaTización
    //    object oExcel = null;
    //    object oBooks = null;
    //    object oBook = null;
    //    object oSheet = null;
    //    object range = null;

    //    try
    //    {
    //        oform.Text = "Espere....GENERANDO";
    //        Button btnAdd = new Button();
    //        btnAdd.AutoSize = true;
    //        btnAdd.AutoSizeMode = AutoSizeMode.GrowAndShrink;
    //        btnAdd.Font = new System.Drawing.Font("Tahoma", 20);

    //        oform.StartPosition = FormStartPosition.CenterScreen;
    //        oform.ControlBox = false;
    //        oform.Controls.Add(btnAdd);
    //        btnAdd.Text = TituloHoja;
    //        oform.ShowInTaskbar = false;
    //        oform.Width = btnAdd.Width + 100;
    //        oform.Height = btnAdd.Height + 100;
    //        oform.Show();

    //        oExcel = Interaction.CreateObject("Excel.Application");

    //        oBooks = oExcel.Workbooks;
    //        oBook = oExcel.Workbooks.Add;
    //        oSheet = oBook.Sheets(1);
    //        oSheet.Name = TituloHoja;


    //        oSheet.Cells(ROW_FIRST, 1) = "PLANILLA DE " + Tabla.Rows[0]["planilla"];

    //        ROW_FIRST = 2;
    //        oSheet.Cells(ROW_FIRST, 1) = "Periodo";
    //        oSheet.Cells(ROW_FIRST, 1).Interior.ColorIndex = 14;
    //        oSheet.Cells(ROW_FIRST, 1).Interior.Pattern = 1;
    //        oSheet.Cells(ROW_FIRST, 1).Font.ColorIndex = 2;
    //        oSheet.Cells(ROW_FIRST, 1).borders(1).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 1).borders(1).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 1).borders(2).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 1).borders(2).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 1).borders(3).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 1).borders(3).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 1).borders(4).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 1).borders(4).Weight = 2;

    //        oSheet.Cells(ROW_FIRST, 2) = "Mes";
    //        oSheet.Cells(ROW_FIRST, 2).Interior.ColorIndex = 14;
    //        oSheet.Cells(ROW_FIRST, 2).Interior.Pattern = 1;
    //        oSheet.Cells(ROW_FIRST, 2).Font.ColorIndex = 2;
    //        oSheet.Cells(ROW_FIRST, 2).borders(1).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 2).borders(1).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 2).borders(2).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 2).borders(2).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 2).borders(3).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 2).borders(3).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 2).borders(4).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 2).borders(4).Weight = 2;

    //        oSheet.Cells(ROW_FIRST, 3) = "Ficha";
    //        oSheet.Cells(ROW_FIRST, 3).Interior.ColorIndex = 14;
    //        oSheet.Cells(ROW_FIRST, 3).Interior.Pattern = 1;
    //        oSheet.Cells(ROW_FIRST, 3).Font.ColorIndex = 2;
    //        oSheet.Cells(ROW_FIRST, 3).borders(1).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 3).borders(1).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 3).borders(2).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 3).borders(2).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 3).borders(3).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 3).borders(3).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 3).borders(4).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 3).borders(4).Weight = 2;

    //        oSheet.Cells(ROW_FIRST, 4) = "Apellidos y Nombres";
    //        oSheet.Cells(ROW_FIRST, 4).Interior.ColorIndex = 14;
    //        oSheet.Cells(ROW_FIRST, 4).Interior.Pattern = 1;
    //        oSheet.Cells(ROW_FIRST, 4).Font.ColorIndex = 2;
    //        oSheet.Cells(ROW_FIRST, 4).borders(1).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 4).borders(1).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 4).borders(2).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 4).borders(2).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 4).borders(3).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 4).borders(3).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 4).borders(4).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 4).borders(4).Weight = 2;


    //        oSheet.Cells(ROW_FIRST, 5) = "C.Costo";
    //        oSheet.Cells(ROW_FIRST, 5).Interior.ColorIndex = 14;
    //        oSheet.Cells(ROW_FIRST, 5).Interior.Pattern = 1;
    //        oSheet.Cells(ROW_FIRST, 5).Font.ColorIndex = 2;
    //        oSheet.Cells(ROW_FIRST, 5).borders(1).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 5).borders(1).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 5).borders(2).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 5).borders(2).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 5).borders(3).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 5).borders(3).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 5).borders(4).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 5).borders(4).Weight = 2;

    //        oSheet.Cells(ROW_FIRST, 6) = "Cargo";
    //        oSheet.Cells(ROW_FIRST, 6).Interior.ColorIndex = 14;
    //        oSheet.Cells(ROW_FIRST, 6).Interior.Pattern = 1;
    //        oSheet.Cells(ROW_FIRST, 6).Font.ColorIndex = 2;
    //        oSheet.Cells(ROW_FIRST, 6).borders(1).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 6).borders(1).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 6).borders(2).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 6).borders(2).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 6).borders(3).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 6).borders(3).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 6).borders(4).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 6).borders(4).Weight = 2;

    //        oSheet.Cells(ROW_FIRST, 7) = "Afp";
    //        oSheet.Cells(ROW_FIRST, 7).Interior.ColorIndex = 14;
    //        oSheet.Cells(ROW_FIRST, 7).Interior.Pattern = 1;
    //        oSheet.Cells(ROW_FIRST, 7).Font.ColorIndex = 2;
    //        oSheet.Cells(ROW_FIRST, 7).borders(1).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 7).borders(1).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 7).borders(2).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 7).borders(2).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 7).borders(3).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 7).borders(3).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 7).borders(4).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 7).borders(4).Weight = 2;


    //        oSheet.Cells(ROW_FIRST, 8) = "Cta.AFP";
    //        oSheet.Cells(ROW_FIRST, 8).Interior.ColorIndex = 14;
    //        oSheet.Cells(ROW_FIRST, 8).Interior.Pattern = 1;
    //        oSheet.Cells(ROW_FIRST, 8).Font.ColorIndex = 2;
    //        oSheet.Cells(ROW_FIRST, 8).borders(1).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 8).borders(1).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 8).borders(2).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 8).borders(2).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 8).borders(3).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 8).borders(3).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 8).borders(4).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 8).borders(4).Weight = 2;

    //        int nmaxolumn = 8;
    //        for (lc_columna = 1; lc_columna <= Tabla.Rows[0]["maxrubros"]; lc_columna++)
    //        {
    //            xvmcampo = "desrubro_" + PADL(lc_columna, 2, "0");

    //            oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna) = Tabla.Rows[0][xvmcampo];
    //            oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).Interior.ColorIndex = 14;
    //            oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).Interior.Pattern = 1;
    //            oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).Font.ColorIndex = 2;
    //            oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).borders(1).LineStyle = 1;
    //            oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).borders(1).Weight = 2;
    //            oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).borders(2).LineStyle = 1;
    //            oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).borders(2).Weight = 2;
    //            oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).borders(3).LineStyle = 1;
    //            oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).borders(3).Weight = 2;
    //            oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).borders(4).LineStyle = 1;
    //            oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).borders(4).Weight = 2;
    //        }

    //        oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna) = "Neto";
    //        oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).Interior.ColorIndex = 14;
    //        oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).Interior.Pattern = 1;
    //        oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).Font.ColorIndex = 2;
    //        oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).borders(1).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).borders(1).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).borders(2).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).borders(2).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).borders(3).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).borders(3).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).borders(4).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).borders(4).Weight = 2;

    //        ROW_FIRST = 3;

    //        foreach (DataRow MiDataRow in Tabla.Rows)
    //        {
    //            oSheet.Cells(ROW_FIRST, 1) = MiDataRow["Periodo"];
    //            oSheet.Cells(ROW_FIRST, 2) = MiDataRow["dmes"];
    //            oSheet.Cells(ROW_FIRST, 3) = "' " + MiDataRow["ficha"];
    //            oSheet.Cells(ROW_FIRST, 4) = MiDataRow["dficha"];
    //            oSheet.Cells(ROW_FIRST, 5) = MiDataRow["dcosto"];
    //            oSheet.Cells(ROW_FIRST, 6) = MiDataRow["dcargo"];
    //            oSheet.Cells(ROW_FIRST, 7) = MiDataRow["nomafp"];
    //            oSheet.Cells(ROW_FIRST, 8) = MiDataRow["ctaafp"];

    //            for (lc_columna = 1; lc_columna <= Tabla.Rows[0]["maxrubros"]; lc_columna++)
    //            {
    //                xvmcampo = "importe_" + PADL(lc_columna, 2, "0");
    //                oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).value = MiDataRow[xvmcampo];
    //            }
    //            oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna) = MiDataRow["neto"];
    //            ROW_FIRST = ROW_FIRST + 1;
    //        }
    //        //Sumatoria Celdas al Final
    //        int vmmaxcolumn = nmaxolumn + lc_columna;
    //        oSheet.Cells(ROW_FIRST + 1, 4).value = "** TOTALES **";
    //        oSheet.Cells(ROW_FIRST + 1, 4).font.bold = true;
    //        oSheet.Cells(ROW_FIRST + 1, vmmaxcolumn).value = 0;
    //        foreach (DataRow MiDataRow in Tabla.Rows)
    //        {
    //            //oSheet.Cells(ROW_FIRST + 1, nmaxolumn + lc_columna).value = 0
    //            for (lc_columna = 1; lc_columna <= Tabla.Rows[0]["maxrubros"]; lc_columna++)
    //            {
    //                xvmcampo = "importe_" + PADL(lc_columna, 2, "0");
    //                oSheet.Cells(ROW_FIRST + 1, nmaxolumn + lc_columna).value = oSheet.Cells(ROW_FIRST + 1, nmaxolumn + lc_columna).value + MiDataRow[xvmcampo];
    //                oSheet.Cells(ROW_FIRST + 1, nmaxolumn + lc_columna).font.bold = true;
    //            }
    //            oSheet.Cells(ROW_FIRST + 1, nmaxolumn + lc_columna).value = oSheet.Cells(ROW_FIRST + 1, nmaxolumn + lc_columna).value + MiDataRow["neto"];

    //        }
    //        oSheet.Cells(ROW_FIRST + 1, nmaxolumn + lc_columna).font.bold = true;

    //        oSheet.Range("A1:R1").@select();
    //        var _with3 = oExcel.Application.selection;
    //        _with3.HorizontalAlignment = GlobalVars.GetInstance.xlCenter;
    //        _with3.VerticalAlignment = GlobalVars.GetInstance.xlBottom;
    //        _with3.WrapText = false;
    //        _with3.Orientation = 0;
    //        _with3.AddIndent = false;
    //        _with3.IndentLevel = 0;
    //        _with3.ShrinkToFit = false;
    //        _with3.ReadingOrder = GlobalVars.GetInstance.xlContext;
    //        _with3.MergeCells = false;
    //        _with3.font.Name = "Rockwell Condensed";
    //        _with3.font.Size = 16;

    //        _with3.merge();

    //        for (lc_columna = 0; lc_columna <= Tabla.Columns.Count - 1; lc_columna++)
    //        {
    //            range = oSheet.Columns(lc_columna + 1);
    //            range.Font.Name = "Tahoma";
    //            range.Font.Size = 8;
    //            range.AutoFit();
    //        }

    //        // Control a USuario
    //        if (nomfileaguardar.Trim().Length == 0)
    //        {
    //            oExcel.Visible = true;
    //            oExcel.UserControl = true;
    //        }
    //        else
    //        {
    //            if (nomfileaguardar.Trim().Length > 0)
    //            {
    //                oExcel.Application.DisplayAlerts = false;
    //                oSheet.saveas(nomfileaguardar);
    //                if (Interaction.MsgBox("Desea abrir archivo " + nomfileaguardar + "...?", 4 + 32 + 256, "") == 6)
    //                {
    //                    System.Diagnostics.Process.Start(nomfileaguardar);
    //                }
    //            }
    //        }
    //        //Cierra Todo
    //    }
    //    catch (Exception ex)
    //    {
    //        zCreateOKHoja = false;
    //        vmxmsgerror = ex.Message;
    //    }
    //    oBooks = null;
    //    oBook = null;
    //    oSheet = null;
    //    range = null;
    //    oExcel = null;

    //    if (zCreateOKHoja)
    //    {
    //    }
    //    else
    //    {
    //        Interaction.MsgBox(vmxmsgerror + Strings.Chr(13) + "ERROR ", 16, "");
    //    }
    //    oform.Close();
    //    oform = null;
    //}
    //public static void CopyToExcelPlanillaReal(DataTable Tabla, string TituloHoja, string nomfileaguardar)
    //{
    //    int lc_columna = 0;
    //    int ROW_FIRST = 1;
    //    bool zCreateOKHoja = true;
    //    string vmxmsgerror = "";
    //    System.Windows.Forms.Form oform = new System.Windows.Forms.Form();
    //    string xvmcampo = "";
    //    //Objetos de AutomaTización
    //    object oExcel = null;
    //    object oBooks = null;
    //    object oBook = null;
    //    object oSheet = null;
    //    object range = null;


    //    try
    //    {
    //        oform.Text = "Espere....GENERANDO";
    //        Button btnAdd = new Button();
    //        btnAdd.AutoSize = true;
    //        btnAdd.AutoSizeMode = AutoSizeMode.GrowAndShrink;
    //        btnAdd.Font = new System.Drawing.Font("Tahoma", 20);


    //        oform.StartPosition = FormStartPosition.CenterScreen;
    //        oform.ControlBox = false;
    //        oform.Controls.Add(btnAdd);
    //        btnAdd.Text = TituloHoja;
    //        oform.ShowInTaskbar = false;
    //        oform.Width = btnAdd.Width + 100;
    //        oform.Height = btnAdd.Height + 100;
    //        oform.Show();

    //        oExcel = Interaction.CreateObject("Excel.Application");

    //        oBooks = oExcel.Workbooks;
    //        oBook = oExcel.Workbooks.Add;
    //        oSheet = oBook.Sheets(1);
    //        oSheet.Name = TituloHoja;


    //        oSheet.Cells(ROW_FIRST, 1) = Tabla.Rows[0]["tituloplanilla"];

    //        ROW_FIRST = 2;
    //        oSheet.Cells(ROW_FIRST, 1) = "Ficha";
    //        oSheet.Cells(ROW_FIRST, 1).Interior.ColorIndex = 14;
    //        oSheet.Cells(ROW_FIRST, 1).Interior.Pattern = 1;
    //        oSheet.Cells(ROW_FIRST, 1).Font.ColorIndex = 2;
    //        oSheet.Cells(ROW_FIRST, 1).borders(1).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 1).borders(1).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 1).borders(2).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 1).borders(2).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 1).borders(3).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 1).borders(3).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 1).borders(4).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 1).borders(4).Weight = 2;

    //        oSheet.Cells(ROW_FIRST, 2) = "Apellidos y Nombres";
    //        oSheet.Cells(ROW_FIRST, 2).Interior.ColorIndex = 14;
    //        oSheet.Cells(ROW_FIRST, 2).Interior.Pattern = 1;
    //        oSheet.Cells(ROW_FIRST, 2).Font.ColorIndex = 2;
    //        oSheet.Cells(ROW_FIRST, 2).borders(1).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 2).borders(1).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 2).borders(2).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 2).borders(2).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 2).borders(3).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 2).borders(3).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 2).borders(4).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 2).borders(4).Weight = 2;


    //        oSheet.Cells(ROW_FIRST, 3) = "C.Costo";
    //        oSheet.Cells(ROW_FIRST, 3).Interior.ColorIndex = 14;
    //        oSheet.Cells(ROW_FIRST, 3).Interior.Pattern = 1;
    //        oSheet.Cells(ROW_FIRST, 3).Font.ColorIndex = 2;
    //        oSheet.Cells(ROW_FIRST, 3).borders(1).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 3).borders(1).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 3).borders(2).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 3).borders(2).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 3).borders(3).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 3).borders(3).Weight = 2;
    //        oSheet.Cells(ROW_FIRST, 3).borders(4).LineStyle = 1;
    //        oSheet.Cells(ROW_FIRST, 3).borders(4).Weight = 2;



    //        int nmaxolumn = 3;
    //        for (lc_columna = 1; lc_columna <= Tabla.Rows[0]["maxrubros"]; lc_columna++)
    //        {
    //            xvmcampo = "drubro" + PADL(lc_columna, 2, "0");

    //            oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna) = Tabla.Rows[0][xvmcampo];
    //            oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).Interior.ColorIndex = 14;
    //            oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).Interior.Pattern = 1;
    //            oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).Font.ColorIndex = 2;
    //            oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).borders(1).LineStyle = 1;
    //            oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).borders(1).Weight = 2;
    //            oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).borders(2).LineStyle = 1;
    //            oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).borders(2).Weight = 2;
    //            oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).borders(3).LineStyle = 1;
    //            oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).borders(3).Weight = 2;
    //            oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).borders(4).LineStyle = 1;
    //            oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).borders(4).Weight = 2;

    //        }



    //        ROW_FIRST = 3;
    //        DataTable tabtotales = Tabla.Clone();
    //        tabtotales.Rows.Add(UtilitariosInterface.INSERTINTOTABLE(tabtotales));
    //        string vmgrupo = "";
    //        foreach (DataRow MiDataRow in Tabla.Rows)
    //        {
    //            if (!(vmgrupo == MiDataRow["grupo"]) | vmgrupo.Trim().Length == 0)
    //            {
    //                if (vmgrupo.Trim().Length > 0)
    //                {
    //                    for (lc_columna = 1; lc_columna <= Tabla.Rows[0]["maxrubros"]; lc_columna++)
    //                    {
    //                        xvmcampo = "nrubro" + PADL(lc_columna, 2, "0");
    //                        oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).value = tabtotales.Rows[0][xvmcampo];
    //                        oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).font.bold = true;
    //                        oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).font.size = 10;
    //                        tabtotales.Rows[0][xvmcampo] = 0;
    //                    }
    //                    ROW_FIRST = ROW_FIRST + 1;
    //                }
    //                //oSheet.Cells(ROW_FIRST + 1, 1).value = MiDataRow.Item("grupo")
    //                vmgrupo = MiDataRow["grupo"].ToString().Trim();

    //            }
    //            oSheet.Cells(ROW_FIRST, 1) = "'" + MiDataRow["fich_3"];
    //            oSheet.Cells(ROW_FIRST, 2) = MiDataRow["dficha"];
    //            oSheet.Cells(ROW_FIRST, 3) = "'" + MiDataRow["ccosto"] + "-" + MiDataRow["dcosto"];

    //            for (lc_columna = 1; lc_columna <= Tabla.Rows[0]["maxrubros"]; lc_columna++)
    //            {
    //                xvmcampo = "nrubro" + PADL(lc_columna, 2, "0");
    //                oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).value = MiDataRow[xvmcampo];
    //                tabtotales.Rows[0][xvmcampo] = tabtotales.Rows[0][xvmcampo] + MiDataRow[xvmcampo];
    //            }
    //            ROW_FIRST = ROW_FIRST + 1;

    //        }
    //        if (vmgrupo.Trim().Length > 0)
    //        {
    //            for (lc_columna = 1; lc_columna <= Tabla.Rows[0]["maxrubros"]; lc_columna++)
    //            {
    //                xvmcampo = "nrubro" + PADL(lc_columna, 2, "0");
    //                oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).value = tabtotales.Rows[0][xvmcampo];
    //                oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).font.bold = true;
    //                oSheet.Cells(ROW_FIRST, nmaxolumn + lc_columna).font.size = 10;
    //                tabtotales.Rows[0][xvmcampo] = 0;
    //            }
    //        }
    //        //Sumatoria Celdas al Final
    //        int vmmaxcolumn = nmaxolumn + lc_columna;
    //        oSheet.Cells(ROW_FIRST + 1, 3).value = "** TOTALES **";
    //        oSheet.Cells(ROW_FIRST + 1, 3).font.bold = true;

    //        foreach (DataRow MiDataRow in Tabla.Rows)
    //        {

    //            //oSheet.Cells(ROW_FIRST + 1, nmaxolumn + lc_columna).value = 0
    //            for (lc_columna = 1; lc_columna <= Tabla.Rows[0]["maxrubros"]; lc_columna++)
    //            {
    //                xvmcampo = "nrubro" + PADL(lc_columna, 2, "0");
    //                if (MiDataRow[xvmcampo] != 0)
    //                {
    //                    oSheet.Cells(ROW_FIRST + 1, nmaxolumn + lc_columna).value = oSheet.Cells(ROW_FIRST + 1, nmaxolumn + lc_columna).value + MiDataRow[xvmcampo];
    //                    oSheet.Cells(ROW_FIRST + 1, nmaxolumn + lc_columna).font.bold = true;
    //                }

    //            }
    //        }
    //        oSheet.Range("A1:R1").@select();
    //        var _with4 = oExcel.Application.selection;
    //        _with4.HorizontalAlignment = GlobalVars.GetInstance.xlCenter;
    //        _with4.VerticalAlignment = GlobalVars.GetInstance.xlBottom;
    //        _with4.WrapText = false;
    //        _with4.Orientation = 0;
    //        _with4.AddIndent = false;
    //        _with4.IndentLevel = 0;
    //        _with4.ShrinkToFit = false;
    //        _with4.ReadingOrder = GlobalVars.GetInstance.xlContext;
    //        _with4.MergeCells = false;
    //        _with4.font.Name = "Rockwell Condensed";
    //        _with4.font.Size = 16;

    //        _with4.merge();




    //        for (lc_columna = 0; lc_columna <= Tabla.Columns.Count - 1; lc_columna++)
    //        {
    //            range = oSheet.Columns(lc_columna + 1);
    //            range.Font.Name = "Tahoma";
    //            range.Font.Size = 8;
    //            range.AutoFit();
    //        }

    //        // Control a USuario


    //        if (nomfileaguardar.Trim().Length == 0)
    //        {
    //            oExcel.Visible = true;
    //            oExcel.UserControl = true;
    //        }
    //        else
    //        {
    //            if (nomfileaguardar.Trim().Length > 0)
    //            {
    //                oExcel.Application.DisplayAlerts = false;
    //                oSheet.saveas(nomfileaguardar);
    //                if (Interaction.MsgBox("Desea abrir archivo " + nomfileaguardar + "...?", 4 + 32 + 256, "") == 6)
    //                {
    //                    System.Diagnostics.Process.Start(nomfileaguardar);
    //                }
    //            }
    //        }

    //        //Cierra Todo


    //    }
    //    catch (Exception ex)
    //    {
    //        zCreateOKHoja = false;
    //        vmxmsgerror = ex.Message;
    //    }
    //    oBooks = null;
    //    oBook = null;
    //    oSheet = null;
    //    range = null;
    //    oExcel = null;

    //    if (zCreateOKHoja)
    //    {
    //    }
    //    else
    //    {
    //        Interaction.MsgBox(vmxmsgerror + Strings.Chr(13) + "ERROR ", 16, "");
    //    }
    //    oform.Close();
    //    oform = null;
    //}
    public static decimal FileSize(string path)
    {
        //Obtiene el Tamaño de un fichero
        FileInfo fi = new FileInfo(path);
        if (fi.Exists)
        {
            return fi.Length;
        }
        else
        {
            return -1;
        }
    }
    public static byte[] GetFileData(string nomfile)
    {
        //Obtiene el contenido de un archivo binario
        byte[] objreturn = null;
        try
        {
            //objreturn = My.Computer.FileSystem.ReadAllBytes(nomfile);
        }
        catch (Exception ex)
        {
            objreturn = null;
        }
        return objreturn;
    }
    public static bool WriteFileData(string nomfile, byte[] data)
    {
        //Escribe el contenido de un archivo binario
        bool zok = true;
        try
        {
            //My.Computer.FileSystem.WriteAllBytes(nomfile, data, false);
            zok = true;
        }
        catch (Exception ex)
        {
            //Interaction.MsgBox(ex.Message, 16, "Error En Generación Archivo");
            zok = false;
        }
        return zok;
    }
    public static string ExtrarNombreArchivo(string nomfile)
    {
        //Extrae el nombre de un archivo de una cadena carpeta + Nombre Archivo
        return Path.GetFileName(nomfile);
    }
    public static string TmpFile(string extension)
    {
        //Genera un nombre temporal para archivo en disco
        string vmreturn = System.IO.Path.GetTempPath() + Palabraaleatoria(10) + "." + extension;
        return vmreturn;
    }
    public static string Palabraaleatoria(int longitud)
    {
        //Genera un nombre aleatorio segun una longitud
        string buffer = "";
        //int i = 0;
        //string vmPalabraaleatoria = "";
        //for (i = 1; i <= longitud; i++)
        //{
        //    buffer = Conversion.Int((122 - 97 + 1) * Rnd()) + 97;
        //    vmPalabraaleatoria = vmPalabraaleatoria + Strings.Chr(buffer);
        //}
        return buffer;
    }
    public static bool BorrarFile(string xtmpfile)
    {
        bool zborrar = true;
        try
        {
            System.IO.File.Delete(xtmpfile);
        }
        catch (Exception ex)
        {
            zborrar = false;
        }
        return zborrar & xtmpfile.Trim().Length > 0;
    }
    //public static void u_GeneraFormatoContrato(DataTable tmpdata, DataTable tmpformatos)
    //{
    //    int vmcolummnas = 0;
    //    int nfilaformatocontrato = 0;
    //    int nfiladata = 0;
    //    int vmfilascamposreplace = 0;
    //    object oWord = null;
    //    object oDocument = null;
    //    object loSelection = null;
    //    string cValueToreplace = "";
    //    bool lValue = false;
    //    string cValueTofind = "";
    //    object oDocActive = null;
    //    string vmdirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    //    System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
    //    FolderBrowserDialog1.ShowNewFolderButton = true;

    //    try
    //    {

    //        if (FolderBrowserDialog1.ShowDialog() == DialogResult.OK)
    //        {
    //            vmdirectory = FolderBrowserDialog1.SelectedPath;
    //        }
    //        else
    //        {
    //            vmdirectory = "";
    //        }
    //        if (vmdirectory.Trim().Length == 0)
    //        {
    //            return;
    //        }
    //        vmdirectory = UtilitariosInterface.Addbs(vmdirectory);
    //        bool zloaddirectory = false;
    //        DataTable workTable = new DataTable();
    //        string cDocument = "";
    //        bool zgenerafile = false;
    //        workTable.Columns.Add("nomcampo", Type.GetType("System.String"));
    //        for (vmcolummnas = 0; vmcolummnas <= tmpdata.Columns.Count - 1; vmcolummnas++)
    //        {
    //            if (Equivalencias.Mid(tmpdata.Columns[vmcolummnas].ColumnName.ToUpper(), 1, 3) == "VM_")
    //            {
    //                workTable.Rows.Add(UtilitariosInterface.INSERTINTOTABLE(workTable));
    //                workTable.Rows[workTable.Rows.Count - 1]["nomcampo"] = tmpdata.Columns[vmcolummnas].ColumnName.ToUpper();
    //            }
    //        }
    //        for (nfiladata = 0; nfiladata <= tmpdata.Rows.Count - 1; nfiladata++)
    //        {
    //            for (nfilaformatocontrato = 0; nfilaformatocontrato <= tmpformatos.Rows.Count - 1; nfilaformatocontrato++)
    //            {
    //                if (tmpformatos.Rows[nfilaformatocontrato]["tcon_15"] == tmpdata.Rows[nfiladata]["cod_formatocontrato"])
    //                {
    //                    cDocument = UtilitariosInterface.TmpFile(UtilitariosInterface.GetExtensionFile(tmpformatos.Rows[nfilaformatocontrato]["nomplantillaword"].ToString()));
    //                    //zgenerafile = UtilitariosInterface.WriteFileData(cDocument, tmpformatos.Rows[nfilaformatocontrato]["plantillaword"]);
    //                    break; 
    //                }
    //            }
    //            if (zgenerafile)
    //            {
    //                //COlumnas
    //                oWord = null;
    //                oDocument = null;
    //                loSelection = null;
    //                oDocActive = null;
    //                oWord = Interaction.CreateObject("word.application");
    //                oWord.Visible = false;
    //                oDocument = oWord.Documents.OPEN(cDocument);
    //                for (vmfilascamposreplace = 0; vmfilascamposreplace <= workTable.Rows.Count - 1; vmfilascamposreplace++)
    //                {
    //                    loSelection = oWord.SELECTION;
    //                    cValueTofind = workTable.Rows[vmfilascamposreplace]["nomcampo"].ToString().Trim().ToUpper();

    //                    cValueToreplace = Strings.Space(1) + tmpdata.Rows[nfiladata][cValueTofind] + Strings.Space(1);
    //                    while ((1 == 1))
    //                    {
    //                        var _with5 = loSelection.FIND;
    //                        _with5.TEXT = cValueTofind;
    //                        _with5.Replacement.Text = cValueToreplace;
    //                        _with5.Forward = true;
    //                        _with5.WRAP = 1;
    //                        var _with6 = loSelection;
    //                        lValue = _with6.Find.Execute();
    //                        if (lValue)
    //                        {
    //                            _with6.TEXT = cValueToreplace;
    //                        }
    //                        else
    //                        {
    //                            break; // TODO: might not be correct. Was : Exit While
    //                        }
    //                    }
    //                }
    //                oDocActive = oWord.ActiveDocument;
    //                oWord.ActiveDocument.SaveAs(vmdirectory + tmpdata.Rows[nfiladata]["nomempresa"] + "_" + tmpdata.Rows[nfiladata]["ficha"] + "_" + Strings.Replace(tmpdata.Rows[nfiladata]["vm_nomtrabajador"], " ", "_"));
    //                oWord.Quit();
    //                UtilitariosInterface.BorrarFile(cDocument);
    //                zloaddirectory = true;
    //            }
    //        }
    //        if (zloaddirectory)
    //        {
    //            System.Diagnostics.Process.Start(vmdirectory);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Interaction.MsgBox(ex.Message, 16, "ERROR AL CREAR DOCUMENTO");
    //    }
    //}
    public static void ShellRUn(string lp_comando)
    {
        //object WSHSHELL = null;
        //try
        //{
        //    WSHSHELL = Interaction.CreateObject("WScript.shell");
        //    WSHSHELL.Run(lp_comando, 0);
        //    WSHSHELL = null;
        //}
        //catch (Exception ex)
        //{
        //}

    }
    public static string GeneraArchivoplanillaAFPNET(string FilePath, DataTable tabladatos)
    {
        int i = 0;
        string xmsg = "";
        string Cadena = null;
        try
        {
            StreamWriter strStreamW = new StreamWriter(FilePath);
            string xcharseparador = "";

            for (i = 0; i <= tabladatos.Rows.Count - 1; i++)
            {
                Cadena = tabladatos.Rows[i]["SECUENCIA"] + xcharseparador + tabladatos.Rows[i]["CUSPP"] + xcharseparador + tabladatos.Rows[i]["DOC_IDENTIDAD"] + xcharseparador + tabladatos.Rows[i]["APEPAT"] + xcharseparador + tabladatos.Rows[i]["APEMAT"] + xcharseparador + tabladatos.Rows[i]["NOMBRES"].ToString() + xcharseparador + tabladatos.Rows[i]["TIPMOV"].ToString() + xcharseparador + tabladatos.Rows[i]["FECHAMOV"] + xcharseparador + tabladatos.Rows[i]["REMUNERACION"] + xcharseparador + tabladatos.Rows[i]["APORTE_CF_PREVISIONAL"] + xcharseparador + tabladatos.Rows[i]["APORTE_SF_PREVISIONAL"] + xcharseparador + tabladatos.Rows[i]["APORTE_EMPLEADOR"] + xcharseparador + tabladatos.Rows[i]["RUBRO_RIESGO"] + xcharseparador + tabladatos.Rows[i]["AFP"] + xcharseparador;

                strStreamW.WriteLine(Cadena);
            }
            strStreamW.Flush();
            strStreamW.Close();
            //MsgBox("El archivo " + FilePath + Chr(13) + "se generó con éxito", MsgBoxStyle.Information, "")
        }
        catch (Exception ex)
        {
            xmsg = ex.Message;
        }
        return xmsg;
    }
    public static bool SeekNameColumnGrid(object Objetogrid, string namecolumn)
    {
        //Indica si existe un nombre de columna en GRID
        bool zretorno = false;
        int ncolumna = 0;
        //for (ncolumna = 0; ncolumna <= Objetogrid.Columns.Count - 1; ncolumna++)
        //{
        //    if (Objetogrid.Columns(ncolumna).Name.ToUpper == namecolumn.ToUpper())
        //    {
        //        zretorno = true;
        //        break; 
        //    }
        //}
        return zretorno;
    }
    //public static DataTable ImportaArchivoCSVCUSSPMASIVO(string xArchivo)
    //{
    //    DataTable dtreturn = new DataTable();
    //    int vmindecol = 0;
    //    int lnnrohoja = 1;
    //    int lnCol = 0;
    //    int lnFil = 0;
    //    dtreturn.Columns.Add("CUSPP_DNI", Type.GetType("System.Int32"));
    //    dtreturn.Columns.Add("CUSPP_APEPAT", Type.GetType("System.String"));
    //    dtreturn.Columns.Add("CUSPP_APEMAT", Type.GetType("System.String"));
    //    dtreturn.Columns.Add("CUSPP_NOMBRES", Type.GetType("System.String"));
    //    dtreturn.Columns.Add("CUSPP_CUSPP", Type.GetType("System.String"));
    //    dtreturn.Columns.Add("CUSPP_FICHA", Type.GetType("System.String"));
    //    dtreturn.Columns["CUSPP_CUSPP"].MaxLength = 20;
    //    dtreturn.Columns["CUSPP_FICHA"].MaxLength = 5;
    //    object loExcel = null;
    //    string vmtipodato = null;
    //    if (xArchivo.Trim().Length > 0)
    //    {

    //        try
    //        {
    //            loExcel = Interaction.CreateObject("Excel.Application");
    //            loExcel.DisplayAlerts = false;
    //            var _with7 = loExcel.APPLICATION;
    //            _with7.VISIBLE = false;
    //            //	-- Abro la planilla con datos
    //            _with7.Workbooks.OPEN(xArchivo);
    //            //	-- Cantidad de columnas	
    //            lnCol = _with7.sheets(lnnrohoja).UsedRange.COLUMNS.COUNT + 5;
    //            //*	MESSAGEBOX(ALLTRIM(STR(lnCol )),64,"")
    //            //	*-- Cantidad de filas
    //            //* Se resta la Fila 1 donde estan los campos
    //            lnFil = _with7.sheets(lnnrohoja).UsedRange.ROWS.COUNT - 1;
    //            int lnJ = 0;
    //            int lnI = 0;
    //            object xCampo = null;

    //            //&& 6 fila
    //            for (lnJ = 1; lnJ <= lnFil; lnJ++)
    //            {
    //                dtreturn.Rows.Add(INSERTINTOTABLE(dtreturn));
    //                vmindecol = 1;
    //                for (lnI = 1; lnI <= lnCol; lnI++)
    //                {
    //                    xCampo = _with7.sheets(lnnrohoja).cells(lnJ, lnI).VALUE;
    //                    //&& Nombre del campo destino
    //                    try
    //                    {
    //                        vmtipodato = xCampo.GetType().ToString().ToUpper();
    //                    }
    //                    catch (Exception ex)
    //                    {
    //                        vmtipodato = "";
    //                    }
    //                    int ncontcampos = 0;
    //                    string tmpvalorcampo = null;

    //                    tmpvalorcampo = "";
    //                    if (xCampo == null)
    //                    {
    //                        xCampo = "";
    //                    }
    //                    else
    //                    {
    //                        if ((object.ReferenceEquals(xCampo, DBNull.Value)))
    //                        {
    //                            xCampo = "";
    //                        }
    //                    }
    //                    if (xCampo.ToString().IndexOf(",") == -1)
    //                    {
    //                        tmpvalorcampo = xCampo.ToString();
    //                        if (u_ToCharColExcel(vmindecol) == "B")
    //                        {
    //                            try
    //                            {
    //                                dtreturn.Rows[dtreturn.Rows.Count - 1]["CUSPP_DNI"] = tmpvalorcampo;
    //                            }
    //                            catch (Exception ex)
    //                            {
    //                                dtreturn.Rows[dtreturn.Rows.Count - 1]["CUSPP_DNI"] = Convert.ToInt16(tmpvalorcampo);
    //                            }
    //                        }
    //                        if (u_ToCharColExcel(vmindecol) == "C")
    //                        {
    //                            try
    //                            {
    //                                dtreturn.Rows[dtreturn.Rows.Count - 1]["CUSPP_APEPAT"] = tmpvalorcampo;
    //                            }
    //                            catch (Exception ex)
    //                            {
    //                                dtreturn.Rows[dtreturn.Rows.Count - 1]["CUSPP_APEPAT"] = "";
    //                            }
    //                        }
    //                        if (u_ToCharColExcel(vmindecol) == "D")
    //                        {
    //                            try
    //                            {
    //                                dtreturn.Rows[dtreturn.Rows.Count - 1]["CUSPP_APEMAT"] = tmpvalorcampo;
    //                            }
    //                            catch (Exception ex)
    //                            {
    //                                dtreturn.Rows[dtreturn.Rows.Count - 1]["CUSPP_APEMAT"] = "";
    //                            }
    //                        }
    //                        if (u_ToCharColExcel(vmindecol) == "E")
    //                        {
    //                            try
    //                            {
    //                                dtreturn.Rows[dtreturn.Rows.Count - 1]["CUSPP_NOMBRES"] = tmpvalorcampo;
    //                            }
    //                            catch (Exception ex)
    //                            {
    //                                dtreturn.Rows[dtreturn.Rows.Count - 1]["CUSPP_NOMBRES"] = "";
    //                            }
    //                        }
    //                        if (u_ToCharColExcel(vmindecol) == "F")
    //                        {
    //                            try
    //                            {
    //                                dtreturn.Rows[dtreturn.Rows.Count - 1]["CUSPP_CUSPP"] = tmpvalorcampo;
    //                            }
    //                            catch (Exception ex)
    //                            {
    //                                dtreturn.Rows[dtreturn.Rows.Count - 1]["CUSPP_CUSPP"] = "";
    //                            }
    //                        }
    //                        vmindecol = vmindecol + 1;
    //                    }
    //                    else
    //                    {
    //                        vmindecol = 1;
    //                        for (ncontcampos = 1; ncontcampos <= xCampo.ToString().Length; ncontcampos++)
    //                        {
    //                            if (Strings.Mid(xCampo.ToString(), ncontcampos, 1) == ",")
    //                            {
    //                                if (u_ToCharColExcel(vmindecol) == "B")
    //                                {
    //                                    try
    //                                    {
    //                                        dtreturn.Rows[dtreturn.Rows.Count - 1]["CUSPP_DNI"] = tmpvalorcampo;
    //                                    }
    //                                    catch (Exception ex)
    //                                    {
    //                                        dtreturn.Rows[dtreturn.Rows.Count - 1]["CUSPP_DNI"] = Convert.ToInt16(tmpvalorcampo);
    //                                    }
    //                                }
    //                                if (u_ToCharColExcel(vmindecol) == "C")
    //                                {
    //                                    try
    //                                    {
    //                                        dtreturn.Rows[dtreturn.Rows.Count - 1]["CUSPP_APEPAT"] = tmpvalorcampo;
    //                                    }
    //                                    catch (Exception ex)
    //                                    {
    //                                        dtreturn.Rows[dtreturn.Rows.Count - 1]["CUSPP_APEPAT"] = "";
    //                                    }
    //                                }
    //                                if (u_ToCharColExcel(vmindecol) == "D")
    //                                {
    //                                    try
    //                                    {
    //                                        dtreturn.Rows[dtreturn.Rows.Count - 1]["CUSPP_APEMAT"] = tmpvalorcampo;
    //                                    }
    //                                    catch (Exception ex)
    //                                    {
    //                                        dtreturn.Rows[dtreturn.Rows.Count - 1]["CUSPP_APEMAT"] = "";
    //                                    }
    //                                }
    //                                if (u_ToCharColExcel(vmindecol) == "E")
    //                                {
    //                                    try
    //                                    {
    //                                        dtreturn.Rows[dtreturn.Rows.Count - 1]["CUSPP_NOMBRES"] = tmpvalorcampo;
    //                                    }
    //                                    catch (Exception ex)
    //                                    {
    //                                        dtreturn.Rows[dtreturn.Rows.Count - 1]["CUSPP_NOMBRES"] = "";
    //                                    }
    //                                }
    //                                if (u_ToCharColExcel(vmindecol) == "F")
    //                                {
    //                                    try
    //                                    {
    //                                        dtreturn.Rows[dtreturn.Rows.Count - 1]["CUSPP_CUSPP"] = tmpvalorcampo;
    //                                    }
    //                                    catch (Exception ex)
    //                                    {
    //                                        dtreturn.Rows[dtreturn.Rows.Count - 1]["CUSPP_CUSPP"] = "";
    //                                    }
    //                                }
    //                                tmpvalorcampo = "";
    //                                vmindecol = vmindecol + 1;
    //                            }
    //                            else
    //                            {
    //                                tmpvalorcampo = tmpvalorcampo + Strings.Mid(xCampo.ToString(), ncontcampos, 1);
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //            _with7.Workbooks.CLOSE();
    //            //*-- Salgo de Excel
    //            loExcel.QUIT();
    //            System.Runtime.InteropServices.Marshal.ReleaseComObject(loExcel);

    //        }
    //        catch (Exception ex)
    //        {
    //            Interaction.MsgBox(ex.Message, 16, "ERROR AL TRABAJAR CON ARCHIVO " + xArchivo);
    //        }
    //    }
    //    loExcel = null;
    //    return dtreturn;
    //}

    public static string u_ToCharColExcel(int nColumnas)
    {
        string vm_RETURN = "";
        int q__002 = 0;
        int q_001 = 0;
        string nCol = "";
        vm_RETURN = "";
        q__002 = 0;
        for (q_001 = 1; q_001 <= nColumnas; q_001++)
        {
            if (64 + q_001 <= Equivalencias.Asc("Z"))
            {
                nCol = Convert.ToChar(64 + q_001).ToString();
            }
            else
            {
                q__002 = q__002 + 1;
                nCol = (q__002 == 1 ? "A" : Equivalencias.Left(nCol, 1)) + Convert.ToChar(64 + q__002).ToString();
                if (q__002 == 64 + q__002)
                {
                    q__002 = 0;
                }
            }
        }
        vm_RETURN = nCol;
        return vm_RETURN;
    }
    public static string GeneraArchivortpsdiassubsidiados(string FilePath, DataTable tabladatos)
    {
        int i = 0;
        string xmsgerror = "";
        string Cadena = null;
        try
        {
            StreamWriter strStreamW = new StreamWriter(FilePath);
            string xcharseparador = Convert.ToChar(124).ToString();

            for (i = 0; i <= tabladatos.Rows.Count - 1; i++)
            {
                Cadena = tabladatos.Rows[i]["tipo_docu"] + xcharseparador + tabladatos.Rows[i]["num_doc"] + xcharseparador + tabladatos.Rows[i]["tiposuspension"] + xcharseparador + tabladatos.Rows[i]["citt"].ToString() + xcharseparador + Equivalencias.Mid(tabladatos.Rows[i]["fechainicio"].ToString(), 1, 10) + xcharseparador + Equivalencias.Mid(tabladatos.Rows[i]["fechafinal"].ToString(), 1, 10) + xcharseparador;

                strStreamW.WriteLine(Cadena);
            }
            strStreamW.Flush();
            strStreamW.Close();
            //            MsgBox("El archivo " + FilePath + Chr(13) + "se generó con éxito", MsgBoxStyle.Information, "")
        }
        catch (Exception ex)
        {
            xmsgerror = ex.Message;
        }
        return xmsgerror;
    }
    public static bool u_Cerrado(string lpCCIA, string lpperiodo, string lpmes, string lpctipo, string lptipoplanilla, string lpmensajeabc)
    {
        if (lpmensajeabc.Trim().Length == 0)
        {
            lpmensajeabc = "Modificar ";
        }
        bool zreturn = false;
        DataTable tmp = new DataTable();
        //oaplilogic ocapa = new oaplilogic();
        //tmp = ocapa.cierreConfiguracionplanilla_consulta(lpCCIA, lpperiodo, lpmes, lpctipo, lptipoplanilla);
        //if (ocapa.sql_error.Length == 0)
        //{
        //    if (tmp.Rows.Count > 0)
        //    {
        //        zreturn = Convert.ToBoolean(tmp.Rows[0]["cerrado_cfgpla"]);
        //        if (zreturn)
        //        {
        //            MessageBox.Show("Información Cerrada..Imposible " + lpmensajeabc, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //    else
        //    {
        //        zreturn = false;
        //    }
        //}
        return zreturn;
    }
    #endregion
}



//    public class UtilitariosInterface
//    {

//    }
}
