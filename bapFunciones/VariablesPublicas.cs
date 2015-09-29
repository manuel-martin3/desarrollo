using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Net;
using System.IO;
using System.Collections;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using LayerBusinessEntities;
using LayerBusinessLogic;

using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Reflection; 

//using bapFunciones;
//using Interaction = Microsoft.VisualBasic.Interaction;


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

    public static class VariablesPublicas
    {
        private static String _EmpresaID;
        public static String EmpresaID
        {
            get { return _EmpresaID; }

            set { _EmpresaID = value; }
        }

        private static String _tipodoc;
        public static String tipodoc
        {
            get { return VariablesPublicas._tipodoc; }
            set { VariablesPublicas._tipodoc = value; }
        }

        private static string _cVersion;
        public static string cVersion
        {
            get { return _cVersion; }

            set { _cVersion = value; }
        }

        private static String _empresasigla;
        public static String EmpresaSigla
        {
            get { return VariablesPublicas._empresasigla; }
            set { VariablesPublicas._empresasigla = value; }
        }


        private static String _serdoc;
        public static String serdoc
        {
            get { return VariablesPublicas._serdoc; }
            set { VariablesPublicas._serdoc = value; }
        }


        private static String _nombrelocal;
        public static String nombrelocal
        {
            get { return VariablesPublicas._nombrelocal; }
            set { VariablesPublicas._nombrelocal = value; }
        }

        private static string _NombreArchivoSubido;
        public static string NombreArchivoSubido
        {
            get { return _NombreArchivoSubido; }
            set { _NombreArchivoSubido = value; }
        }

        private static String _numdoc;
        public static String numdoc
        {
            get { return VariablesPublicas._numdoc; }
            set { VariablesPublicas._numdoc = value; }
        }

        private static String _EmpresaName;
        public static String EmpresaName
        {
            get { return _EmpresaName; }

            set { _EmpresaName = value; }
        }
        private static String _EmpresaRuc;
        public static String EmpresaRuc
        {
            get { return _EmpresaRuc; }

            set { _EmpresaRuc = value; }
        }

        private static String _EmpresaDirecc;
        public static String EmpresaDirecc
        {
            get { return VariablesPublicas._EmpresaDirecc; }
            set { VariablesPublicas._EmpresaDirecc = value; }
        }


        private static String _EmpresaTelef;
        public static String EmpresaTelef
        {
            get { return VariablesPublicas._EmpresaTelef; }
            set { VariablesPublicas._EmpresaTelef = value; }
        }

        // Agregamos Para mis Formulas
        private static String _EmpresaEstablec;

        public static String EmpresaEstablec
        {
            get { return VariablesPublicas._EmpresaEstablec; }
            set { VariablesPublicas._EmpresaEstablec = value; }
        }

        private static bool _CerrarSession;
        public static bool CerrarSession
        {
            get { return VariablesPublicas._CerrarSession; }
            set { VariablesPublicas._CerrarSession = value; }
        }



        private static Int32 _ndecimalesCant;
        public static Int32 ndecimalesCant
        {
            get { return VariablesPublicas._ndecimalesCant; }
            set { VariablesPublicas._ndecimalesCant = value; }
        }


        private static String _EmpresaTipo;

        public static String EmpresaTipo
        {
            get { return VariablesPublicas._EmpresaTipo; }
            set { VariablesPublicas._EmpresaTipo = value; }
        }

        private static String _EmpresaCodUnMed;

        public static String EmpresaCodUnMed
        {
            get { return VariablesPublicas._EmpresaCodUnMed; }
            set { VariablesPublicas._EmpresaCodUnMed = value; }
        }

        private static String _FechImpresion;

        public static String FechImpresion
        {
            get { return VariablesPublicas._FechImpresion; }
            set { VariablesPublicas._FechImpresion = value; }
        }


        private static String _databasename;
        public static String databasename
        {
            get { return VariablesPublicas._databasename; }
            set { VariablesPublicas._databasename = value; }
        }


        //

        private static String N_PrimerMes;

        public static String N_PrimerMes1
        {
            get { return VariablesPublicas.N_PrimerMes; }
            set { VariablesPublicas.N_PrimerMes = value; }
        }

        private static String N_FinMes;

        public static String N_FinMes1
        {
            get { return VariablesPublicas.N_FinMes; }
            set { VariablesPublicas.N_FinMes = value; }
        }

       

        private static String _EmpresaLogo;
        public static String EmpresaLogo
        {
            get { return _EmpresaLogo; }

            set { _EmpresaLogo = value; }
        }
        private static String _Usuar;
        public static String Usuar
        {
            get { return _Usuar; }

            set { _Usuar = value; }
        }
        private static String _Nombr;
        public static String Nombr
        {
            get { return _Nombr; }

            set { _Nombr = value; }
        }

        private static String _Dominioid;
        public static String Dominioid
        {
            get { return _Dominioid; }

            set { _Dominioid = value; }
        }
        private static String _Moduloid;
        public static String Moduloid
        {
            get { return _Moduloid; }

            set { _Moduloid = value; }
        }
        private static String _Local;
        public static String Local
        {
            get { return _Local; }

            set { _Local = value; }
        }
        private static String _Perfil;
        public static String Perfil
        {
            get { return _Perfil; }

            set { _Perfil = value; }
        }

        private static Int32 _Grupo;
        public static Int32 Grupo
        {
            get { return _Grupo; }

            set { _Grupo = value; }
        }


        private static String _perimes;
        public static String perimes
        {
            get { return _perimes; }

            set { _perimes = value; }
        }
        private static String _perianio;
        public static String perianio
        {
            get { return _perianio; }

            set { _perianio = value; }
        }

        private static String _localdirec;
        public static String localdirec
        {
            get { return VariablesPublicas._localdirec; }
            set { VariablesPublicas._localdirec = value; }
        }

        private static String _numruc;
        public static String numruc
        {
            get { return VariablesPublicas._numruc; }
            set { VariablesPublicas._numruc = value; }
        }

        private static String _telef;
        public static String telef
        {
            get { return VariablesPublicas._telef; }
            set { VariablesPublicas._telef = value; }
        }

        private static String _localfeuiv;
        public static String localfeuiv
        {
            get { return VariablesPublicas._localfeuiv; }
            set { VariablesPublicas._localfeuiv = value; }
        }


        // Agreando perimes
        private static String _perimesini;
        public static String Perimesini
        {
            get { return _perimesini; }
            set { _perimesini = value; }
        }

        private static String _perimesfin;

        public static String Perimesfin
        {
            get { return _perimesfin; }
            set { _perimesfin = value; }
        }
        //

        private static String _igv;
        public static String igv
        {
            get { return _igv; }

            set { _igv = value; }
        }
        private static String _fechsis;
        public static String fechsis
        {
            get { return _fechsis; }

            set { _fechsis = value; }
        }
        private static String _fechdigini;
        public static String fechdigini
        {
            get { return _fechdigini; }

            set { _fechdigini = value; }
        }
        private static String _fechdigfin;
        public static String fechdigfin
        {
            get { return _fechdigfin; }

            set { _fechdigfin = value; }
        }


        private static String _xctacte;
        public static String xctacte
        {
            get { return VariablesPublicas._xctacte; }
            set { VariablesPublicas._xctacte = value; }
        }


        private static String _xdirecnume;
        public static String xdirecnume
        {
            get { return VariablesPublicas._xdirecnume; }
            set { VariablesPublicas._xdirecnume = value; }
        }

        private static Boolean _novalidastock;
        public static Boolean novalidastock
        {
            get { return VariablesPublicas._novalidastock; }
            set { VariablesPublicas._novalidastock = value; }
        }

        private static Boolean _editnumdoc;
        public static Boolean editnumdoc
        {
            get { return VariablesPublicas._editnumdoc; }
            set { VariablesPublicas._editnumdoc = value; }
        }

        //Constantes Para Roleo de Registros
        private static String _toprecord;
        public static String toprecord
        {
            get { return _toprecord; }

            set { _toprecord = value; }
        }
        private static String _bottrecord;
        public static String bottrecord
        {
            get { return _bottrecord; }

            set { _bottrecord = value; }
        }
        private static String _nextrecord;
        public static String nextrecord
        {
            get { return _nextrecord; }

            set { _nextrecord = value; }
        }
        private static String _prevrecord;
        public static String prevrecord
        {
            get { return _prevrecord; }

            set { _prevrecord = value; }
        }

        private static String _userip;
        public static String userip
        {
            get { return _userip; }

            set { _userip = value; }
        }

        //Public RutaImagenes As String = My.Settings.rutaimagenes
        private static String _RutaImagenes;
        public static String RutaImagenes
        {
            get { return _RutaImagenes; }

            set { _RutaImagenes = value; }
        }

        private static bool _PulsaAyudaArticulos;
        public static bool PulsaAyudaArticulos
        {
            get { return _PulsaAyudaArticulos; }

            set { _PulsaAyudaArticulos = value; }
        }

        private static bool _PulsaTeclaF2;
        public static bool PulsaTeclaF2
        {
            get { return _PulsaTeclaF2; }

            set { _PulsaTeclaF2 = value; }
        }

        private static bool _PulsaTeclaF3;
        public static bool PulsaTeclaF3
        {
            get { return _PulsaTeclaF3; }

            set { _PulsaTeclaF3 = value; }
        }

        private static bool _Enter;

        public static bool Enter
        {
            get { return _Enter; }
            set { _Enter = value; }
        }

        private static string _CodVoucherCompras;
        public static string CodVoucherCompras
        {
            get { return _CodVoucherCompras; }

            set { _CodVoucherCompras = value; }
        }

        private static string _CodVoucherVentas;
        public static string CodVoucherVentas
        {
            get { return _CodVoucherVentas; }

            set { _CodVoucherVentas = value; }
        }


        private static DataTable _CopiarCaracteristicas;
        public static DataTable CopiarCaracteristicas
        {
            get { return _CopiarCaracteristicas; }
            set { _CopiarCaracteristicas = value; }
        }

        // Clasificacion Filtro Tipos Documento
        private static string _TipoDocumentoContableTodos = "1";
        public static string TipoDocumentoContableTodos
        {
            get { return _TipoDocumentoContableTodos; }
            set { _TipoDocumentoContableTodos = value; }
        }

        private static string _TipoDocumentoContableTesoreria = "2";
        public static string TipoDocumentoContableTesoreria
        {
            get { return _TipoDocumentoContableTesoreria; }
            set { _TipoDocumentoContableTesoreria = value; }
        }

        private static string _TipoDocumentoContableContabilidad = "4";
        public static string TipoDocumentoContableContabilidad
        {
            get { return _TipoDocumentoContableContabilidad; }
            set { _TipoDocumentoContableContabilidad = value; }
        }

        private static string _TipoDocumentoContableTesoreriaContabilidad = "6";
        public static string TipoDocumentoContableTesoreriaContabilidad
        {
            get { return _TipoDocumentoContableTesoreriaContabilidad; }
            set { _TipoDocumentoContableTesoreriaContabilidad = value; }
        }

        private static string _tipocierremensualcontable = "0110"; //Contabilidad
        public static string tipocierremensualcontable
        {
            get { return _tipocierremensualcontable; }

            set { _tipocierremensualcontable = value; }
        }

        private static string _tipocierremensualcompra = "0120"; //Compras
        public static string tipocierremensualcompra
        {
            get { return _tipocierremensualcompra; }

            set { _tipocierremensualcompra = value; }
        }

        private static string _tipocierremensualVentas = "0130"; //Ventas
        public static string tipocierremensualVentas
        {
            get { return _tipocierremensualVentas; }

            set { _tipocierremensualVentas = value; }
        }

        private static string _tipocierremensualTesoreria = "0140"; //Tesoreria
        public static string tipocierremensualTesoreria
        {
            get { return _tipocierremensualTesoreria; }

            set { _tipocierremensualTesoreria = value; }
        }

        private static string _ContabilidadIdCargo = "D";
        public static string ContabilidadIdCargo
        {
            get { return _ContabilidadIdCargo; }
            set { _ContabilidadIdCargo = value; }
        }

        private static string _ContabilidadIdAbono = "H";
        public static string ContabilidadIdAbono
        {
            get { return _ContabilidadIdAbono; }
            set { _ContabilidadIdAbono = value; }
        }

        private static string _MonedaCodSoles = "1";
        public static string MonedaCodSoles
        {
            get { return _MonedaCodSoles; }
            set { _MonedaCodSoles = value; }
        }

        private static string _MonedaCodDolares = "2";
        public static string MonedaCodDolares
        {
            get { return _MonedaCodDolares; }
            set { _MonedaCodDolares = value; }
        }

        //Usado para analisar información Cta.Cte.
        private static string _relctas = "11_12_13_14_15_16_17_18_19_37_38_41_42_43_44_45_46_47_48_49";
        public static string relctas
        {
            get { return _relctas; }
            set { _relctas = value; }
        }
        //Public _CtaCteCUEDETTIPNUM As Integer = 1
        private static string _CtaCteCUEDETTIPNUM = "1";
        public static string CtaCteCUEDETTIPNUM
        {
            get { return _CtaCteCUEDETTIPNUM; }
            set { _CtaCteCUEDETTIPNUM = value; }
        }

        //Public _CtaCteCUEDETTIPNUMPEDOPCCOSTo As Integer = 2
        private static string _CtaCteCUEDETTIPNUMPEDOPCCOSTo = "2";
        public static string CtaCteCUEDETTIPNUMPEDOPCCOSTo
        {
            get { return _CtaCteCUEDETTIPNUMPEDOPCCOSTo; }
            set { _CtaCteCUEDETTIPNUMPEDOPCCOSTo = value; }
        }

        private static string _codformapagoletra = "011";
        public static string codformapagoletra
        {
            get { return _codformapagoletra; }
            set { _codformapagoletra = value; }
        }


        private static decimal _TopeMontoRHPRetencion = 1500;
        public static decimal TopeMontoRHPRetencion
        {
            get { return _TopeMontoRHPRetencion; }
            set { _TopeMontoRHPRetencion = value; }
        }

        private static decimal _POrcentajeRetencion = 10;
        public static decimal POrcentajeRetencion
        {
            get { return _POrcentajeRetencion; }
            set { _POrcentajeRetencion = value; }
        }

        private static bool _AyudaItemOS = false;
        public static bool AyudaItemOS
        {
            get { return _AyudaItemOS; }
            set { _AyudaItemOS = value; }
        }

        private static string _DregimenArancelario = "SE ACOGE A RESTITUCION DE DERECHOS ARANCELARIOS DRAW BACK D.S. Nº 104-95 EF (Código Nº 13)";
        public static string DregimenArancelario
        {
            get { return _DregimenArancelario; }
            set { _DregimenArancelario = value; }
        }

        private static int _NmrucDigitos = 11;
        public static int NmrucDigitos
        {
            get { return _NmrucDigitos; }
            set { _NmrucDigitos = value; }
        }


        //Meses del Año
        public static String Meses(string xMes)
        {
            string xMeses = "";
            switch (xMes)
            {
                case "00":
                    xMeses = "SALDOS INICIALES";
                    break;
                case "01":
                    xMeses = "ENERO";
                    break;
                case "02":
                    xMeses = "FEBRERO";
                    break;
                case "03":
                    xMeses = "MARZO";
                    break;
                case "04":
                    xMeses = "ABRIL";
                    break;
                case "05":
                    xMeses = "MAYO";
                    break;
                case "06":
                    xMeses = "JUNIO";
                    break;
                case "07":
                    xMeses = "JULIO";
                    break;
                case "08":
                    xMeses = "AGOSTO";
                    break;
                case "09":
                    xMeses = "SEPTIEMBRE";
                    break;
                case "10":
                    xMeses = "OCTUBRE";
                    break;
                case "11":
                    xMeses = "NOVIEMBRE";
                    break;
                case "12":
                    xMeses = "DICIEMBRE";
                    break;
            }
            return xMeses;
        }



        public static DataRow InsertIntoTable(DataTable vmdata)
        {            
            //devuelve una fila en blanco para una tabla
            try
            {
                DataRow filadatos = vmdata.NewRow();
                int xcont;
                object xvalor = new object();
                for (xcont = 0; xcont < vmdata.Columns.Count; xcont++)
                {
                    vmdata.Columns[xcont].AllowDBNull = true;
                }
                for (xcont = 0; xcont < vmdata.Columns.Count; xcont++)
                {
                    //filadatos[xcont] = 1;

                    if (vmdata.Columns[xcont].DataType.Name.ToUpper() == "STRING" | vmdata.Columns[xcont].DataType.Name.ToUpper() == "CHAR")
                    {
                        filadatos[xcont] = "";
                    }
                    if (vmdata.Columns[xcont].DataType.Name.ToUpper() == "DECIMAL" | vmdata.Columns[xcont].DataType.Name.ToUpper() == "DOUBLE" | vmdata.Columns[xcont].DataType.Name.ToUpper() == "INT16" | vmdata.Columns[xcont].DataType.Name.ToUpper() == "TIMESTAMP")
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
            catch (Exception ex)
            {
                
                throw ex;
            }

           
        }

        public static bool WriteFileData(string nomfile, byte[] data)
        {
            //Escribe el contenido de un archivo binario
            bool zok = true;
            try
            {
                System.IO.File.WriteAllBytes(nomfile, data);
                //My.Computer.FileSystem.WriteAllBytes(nomfile, data, false);
                zok = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error En Generación Archivo");
                zok = false;
            }
            return zok;
        }


        public static byte[] GetFileData(string nomfile)
        {
            byte[] objreturn;
            try
            {
                objreturn = System.IO.File.ReadAllBytes(nomfile);
                //objreturn = My.Computer.FileSystem.ReadAllBytes(nomfile);
            }
            catch (Exception ex)
            {
                objreturn = null;
            }
            return objreturn;
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

        public static string Palabraaleatoria(int longitud)
        {
            Random rnd = new Random();
            //Genera un nombre aleatorio seguna una longitud
            string buffer = "";
            int i = 0;
            string vmPalabraaleatoria = "";
            for (i = 1; i <= longitud; i++)
            {
                buffer = Convert.ToInt32(Math.Floor((122 - 97 + 1) * rnd.NextDouble()) + 97).ToString();
                vmPalabraaleatoria = vmPalabraaleatoria + Convert.ToChar(Convert.ToInt32(buffer)).ToString();
            }
            return buffer;
        }

        public static string Encriptar(this string _cadenaAencriptar)
        { // Encripta una cadena
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        // Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public static string DesEncriptar(this string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

        public static string Encripta(string Texto)
        {
            string Clave = null;
            int i = 0;
            string Pass2 = null;
            string CAR = null;
            string Codigo = null;
            Clave = "%ü&/@#$A";
            //Clave = Texto;
            Pass2 = "";

            for (i = 1; i <= Equivalencias.Len(Texto); i++)
            {
                CAR = Strings.Mid(Texto, i, 1);
                Codigo = Strings.Mid(Clave, ((i - 1) % Strings.Len(Clave)) + 1, 1);
                Pass2 = Pass2 + Microsoft.VisualBasic.Strings.Right("0" + Conversion.Hex(Strings.Asc(Codigo) ^ Strings.Asc(CAR)), 2);
            }
            return Pass2;
        }


        public static string DesEncripta(string Texto)
        {
            string Clave = null;
            int i = 0;
            string Pass2 = null;
            string CAR = null;
            string Codigo = null;
            int j = 0;

            Clave = "%ü&/@#$A";
            //Clave = Texto;
            Pass2 = "";
            j = 1;
            for (i = 1; i <= Strings.Len(Texto); i += 2)
            {
                CAR = Strings.Mid(Texto, i, 2);
                Codigo = Strings.Mid(Clave, ((j - 1) % Strings.Len(Clave)) + 1, 1);
                //Pass2 = Pass2 + Strings.Chr(Strings.Asc(Codigo) ^ Equivalencias.Val("&h" + CAR));
                Pass2 = Pass2 + Strings.Chr(Strings.Asc(Codigo) ^ Convert.ToInt16(Conversion.Val("&h" + CAR)));

                j = j + 1;
            }
            return Pass2;
        }
        //Encripta Clave ERP
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
            cad = Strings.LTrim(cad);
            cad = Strings.RTrim(cad);
            for (i = 1; i <= cad.Length; i++)
            {
                vcad = Strings.Mid(cad, i, 1);
                if (accion == 1)
                {
                    if (!((Strings.Asc(vcad) >= 97 & Strings.Asc(vcad) <= 122) | (Strings.Asc(vcad) >= 48 & Strings.Asc(vcad) <= 57)))
                    {
                        cadena = " ";
                    }
                    else
                    {
                        cadena = cadena + Strings.Chr(Strings.Asc(vcad) + 65);
                    }
                }
                else
                {
                    cadena = cadena + Strings.Chr(Strings.Asc(vcad) - 65);
                    cadena = cadena.ToUpper();
                }
            }
            return cadena;
        }

        //public static KeyEventHandler CapturaF1_KeyPress
        //{
        //    get
        //    {
        //        KeyEventHandler keypress = new KeyEventHandler(mCapturatecla_KeyPress);
        //        return keypress;
        //    }
        //}
        public static KeyEventHandler CapturaF1_OC_KeyPress
        {
            get
            {
                KeyEventHandler keypress = new KeyEventHandler(mCapturateclaOC_KeyPress);
                return keypress;
            }
        }

        private static void mCapturateclaOC_KeyPress(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1))
            {
                GlobalVars.GetInstance()._ayudaItemOC = true;
                SendKeys.Send("{TAB}");
            }
            e.Handled = false;
        }
        //**
        public static string Imagen_Aleatoria(string direc, string archivo)
        {
            int a = 0;
            string nom = "";
            try
            {
                for (a = 1; a <= 9999; a++)
                {
                    nom = "";
                    nom = direc.Trim() + FormateaNumeroaCadena2(a.ToString(), 4, '0', true).ToString().Trim() + "_" + archivo.Trim();
                    //if (My.Computer.FileSystem.FileExists(nom) == false)
                    //{
                    //    break;
                    //}

                    if (System.IO.File.Exists(nom) == false)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                nom = direc + archivo;
            }
            return nom;
        }
        //**
        public static void ExistForm(Form OformPapa, Form OformHijo, bool IsFormPapa)
        {
            int lccont;
            bool noinstanciado = false;
            for (lccont = 0; (lccont <= (OformPapa.MdiChildren.Length - 1)); lccont++)
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
                    if (OformPapa != null)
                    {
                        if (OformHijo != null)
                        {
                            OformHijo.MdiParent = OformPapa;
                        }
                    }
                }
            }
        }



        //CalcMaxField
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

        public static Decimal StringtoDecimal(string Numero)
        {
            Decimal retorno = 0;
            Numero = Numero.Trim();
            if ((Numero.Length > 0))
            {
                try
                {
                    retorno = Convert.ToDecimal(Numero);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return retorno;
        }


        #region *** Llenar ceros
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
                    xretorno = (xretorno + Cadena.Substring((lconta - 1), 1));
                }
            }
            return xretorno;
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
        #endregion


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
                    xtmpCad = FormateaNumeroaCadena2(xSerie, LenSerie, '0', true) + "-" + FormateaNumeroaCadena2(xNumero, LenDoc, '0', true);
                }
                else
                {
                    xtmpCad = FormateaNumeroaCadena2(xNumero, LenDoc, '0', true);
                }
            }
            else
            {
                xtmpCad = NumDoc.Trim();
            }
            return xtmpCad;
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

        public static string DTOS(DateTime Fecha)
        { // devuelve fecha DDMMAAAA
            string stringfecha = null;
            try
            {
                stringfecha = PADL(Fecha.Date.ToString().Trim(), 2, "0") + "/" + PADL(Fecha.Month.ToString().Trim(), 2, "0") + "/" + Fecha.Year.ToString();
            }
            catch (Exception ex)
            {
                stringfecha = "";
            }
            return stringfecha;
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

        public static string Addbs(string NameDirect)
        {
            //Devuelve un nombre de Directorio con su \ al final
            string retorno = "";
            NameDirect = NameDirect.Trim();
            if (NameDirect.Length > 0)
            {
                //if (!(Equivalencias.Mid(NameDirect, Len(NameDirect), 1) == "\\"))
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

        public static bool u_Cerrado(string lpCCIA, string lpperiodo, string lpmes, string lpctipo, string lptipoplanilla, string lpmensajeabc)
        {
            if (lpmensajeabc.Trim().Length == 0)
            {
                lpmensajeabc = "Modificar ";
            }
            bool zreturn = false;
            DataTable tmp = new DataTable();
            tb_plla_configuracioncierreBL BL = new tb_plla_configuracioncierreBL();
            tb_plla_configuracioncierre BE = new tb_plla_configuracioncierre();
            BE.perianio = lpperiodo;
            BE.perimes = lpmes;
            BE.tipoafectaciones = lpctipo;
            BE.tipoplla = lptipoplanilla;
            //oaplilogic ocapa = new oaplilogic();
            tmp = BL.GetAll_CONSULTA(VariablesPublicas.EmpresaID, BE).Tables[0];
            //tmp = ocapa.cierreConfiguracionplanilla_consulta(lpCCIA, lpperiodo, lpmes, lpctipo, lptipoplanilla);
            if (BL.Sql_Error.Length == 0)
            {
                if (tmp.Rows.Count > 0)
                {
                    zreturn = Convert.ToBoolean(tmp.Rows[0]["cerrado"]);
                    if (zreturn)
                    {
                        MessageBox.Show("Información Cerrada..Imposible " + lpmensajeabc, "Mensaje del Sistema");
                    }
                }
                else
                {
                    zreturn = false;
                }
            }
            return zreturn;
        }



        public static Boolean U_ValidaFechaRegistroProvision(string Periodo_Trabajo, string Reg_Mes, DateTime Fecha_Registro)
        {
            Boolean zReturn = false;
            object xobjeto = null;
            if (Fecha_Registro.Year.ToString() == Periodo_Trabajo & PADL(Fecha_Registro.Month.ToString(), 2, "0") == Reg_Mes)
            {
                zReturn = true;
            }
            if (!(zReturn))
            {
                if (Fecha_Registro.Year.ToString() != Periodo_Trabajo)
                {
                    xobjeto = ("Año fecha de Registro  no corresponde al periodo actual de trabajo " + Periodo_Trabajo + Equivalencias.Chr(13) + "Verifique..");
                }
                else
                {
                    if (PADL(Fecha_Registro.Month.ToString(), 2, "0") != Reg_Mes)
                    {
                        xobjeto = ("Mes de Registro no corresponde al mes de la fecha " + PADL(Fecha_Registro.Month.ToString(), 2, "0") + Equivalencias.Chr(13) + "Verifique..");
                    }
                }
            }
            return zReturn;
        }

        public static KeyEventHandler CapturaF1_KeyPress
        {
            get
            {
                KeyEventHandler keypress = new KeyEventHandler(mCapturatecla_KeyPress);
                return keypress;
            }
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
        

        public static KeyEventHandler CapturarTeclaGRID
        {
            get
            {
                KeyEventHandler keypress = new KeyEventHandler(LecturaTecla);
                return keypress;
            }
        }
        private static void LecturaTecla(System.Object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                PulsaAyudaArticulos = true;
                SendKeys.Send("\t");
            }
            if (e.KeyCode == Keys.F2)
            {
                PulsaTeclaF2 = true;
                SendKeys.Send("\t");
            }
            if (e.KeyCode == Keys.F3)
            {
                PulsaTeclaF3 = true;
                SendKeys.Send("\t");
            }
        }
        public static KeyPressEventHandler IngresaTodo_KeyPress
        {
            get
            {
                KeyPressEventHandler keypress = new KeyPressEventHandler(mIngresaTodo_KeyPress);
                return keypress;
            }
        }
        private static void mIngresaTodo_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = false;
        }

        public static void PintaEncabezados(DataGridView Grilla)
        {
            int contcolumnas = 0;
            for (contcolumnas = 0; contcolumnas < Grilla.ColumnCount; contcolumnas++)
            {
                if (Grilla.Columns[contcolumnas].Visible == true)
                {
                    Grilla.Columns[contcolumnas].HeaderCell.Style.BackColor = Color.Gray;
                    Grilla.Columns[contcolumnas].HeaderCell.Style.ForeColor = Color.WhiteSmoke;
                    Grilla.Columns[contcolumnas].HeaderCell.Style.Font = new Font("Tahoma", 8, FontStyle.Bold);
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
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return zreturn;
        }

        public static string Palabras(string Par_Cadena, int npalabra)
        {
            string xreturn = "";
            //int ncontpalabras = 0;
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

        public static bool CopiarArchivo(string xnomfile)
        {
            bool retorno = false;
            if (xnomfile.Length > 0)
            {
                retorno = false;
                dynamic newname = NombreAleatorio(RutaImagenes, xnomfile);
                try
                {
                    //System.IO.File.Copy(xnomfile, newname, true);
                    //NombreArchivoSubido = System.IO.Path.GetFileName(newname);
                    retorno = true;
                }
                catch (Exception ex)
                {
                    //GlobalVars.GetInstance.NombreArchivoSubido = "";
                    MessageBox.Show(ex.Message, "Error al Subir Imagen a La Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    retorno = false;
                }
            }
            return retorno;
        }
        public static string NombreAleatorio(string direc, string archivo)
        {
            // Genera un nombre aleatorio para un archivo 
            int a = 0;
            string nom = "";
            dynamic xconstante = "PCGIMG";
            try
            {
                for (a = 1; a <= 9999; a++)
                {
                    nom = "";
                    //nom = direc.Trim() + xconstante + PADL(a.ToString(), 4, "0").ToString().Trim() + "." + GetExtensionFile(archivo);
                    //+ "_" + archivo.Trim
                    //if (My.Computer.FileSystem.FileExists(nom) == false)
                    //{
                    //    break; // 
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
                MessageBox.Show("El archivo " + FilePath + Convert.ToChar(13) + "se generó con éxito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("El archivo " + FilePath + Convert.ToChar(13) + "se generó con éxito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public static KeyPressEventHandler IngresaMoneda_KeyPress
        {
            get
            {
                KeyPressEventHandler keypress = new KeyPressEventHandler(mIngresaMoneda_KeyPress);
                return keypress;
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
        public static EventHandler TextDecimal_Changed
        {
            get
            {
                EventHandler textChanged = new EventHandler(mTextDecimal_Changed);
                return textChanged;
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

        public static KeyPressEventHandler IngresaNumero_KeyPress
        {
            get
            {
                KeyPressEventHandler keypress = new KeyPressEventHandler(mIngresaNumero_KeyPress);
                return keypress;
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

        public static string Get_nivelperfil(String idper, String pgurl)
        {
            string xnivel = "";
            try
            {
                perfilitemsBL BL = new perfilitemsBL();
                tb_perfilitems BE = new tb_perfilitems();
                DataTable dt = new DataTable();
                BE.idper = idper;
                BE.pgurl = pgurl;

                dt = BL.GetAll_nivel_acceso(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    xnivel = dt.Rows[0]["nivelacc"].ToString().Trim();
                    if (xnivel.Trim().Length == 0)
                        xnivel = "00000";
                }
                else
                {
                    xnivel = "00000";
                }

            }
            catch (Exception ex)
            {
                xnivel = "00000";
            }
            return xnivel;
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
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public static string ComboBoxValor(System.Windows.Forms.ComboBox Combo, bool zempty)
        {
            string xfreturn = "";
            if (Combo.SelectedValue == null)
            {
            }
            else
            {
                if (object.ReferenceEquals(Combo.SelectedValue, DBNull.Value))
                {
                }
                else
                {
                    xfreturn = Combo.SelectedValue.ToString();
                }
            }
            return (zempty & xfreturn.Trim().Length == 0 ? "xxx.." : xfreturn);
        }

        public static byte[] ImageToByte(System.Drawing.Image pImagen, bool convierteabmp)
        {
            try
            {
                if ((pImagen != null))
                {
                    byte[] mImage = null;
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
                    ms = null;
                    return mImage;
                }
            }
            catch
            {
            }
            return null;
        }

        public static void u_GeneraFormatoContrato(DataTable tmpdata, DataTable tmpformatos)
        {
            int vmcolummnas = 0;
            int nfilaformatocontrato = 0;
            int nfiladata = 0;
            int vmfilascamposreplace = 0;

            Word.Application oWord;
            Word.Document oDocument;
            Word.Selection loSelection;

            string cValueToreplace = "";
            bool lValue = false;
            string cValueTofind = "";
            object oDocActive = null;
            string vmdirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            FolderBrowserDialog1.ShowNewFolderButton = true;

            try
            {
                if (FolderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    vmdirectory = FolderBrowserDialog1.SelectedPath;
                }
                else
                {
                    vmdirectory = "";
                }
                if (vmdirectory.Trim().Length == 0)
                {
                    return;
                }
                vmdirectory = Addbs(vmdirectory);
                bool zloaddirectory = false;
                DataTable workTable = new DataTable();
                string cDocument = "";
                bool zgenerafile = false;
                workTable.Columns.Add("nomcampo", Type.GetType("System.String"));
                for (vmcolummnas = 0; vmcolummnas <= tmpdata.Columns.Count - 1; vmcolummnas++)
                {
                    if (Strings.Mid(tmpdata.Columns[vmcolummnas].ColumnName.ToUpper(), 1, 3) == "VM_")
                    {
                        workTable.Rows.Add(INSERTINTOTABLE(workTable));
                        workTable.Rows[workTable.Rows.Count - 1]["nomcampo"] = tmpdata.Columns[vmcolummnas].ColumnName.ToUpper();
                    }
                }

                #region Formato_Word
                String FORMTATO = "";
                String _tipcontratoid = "", _tipestado = "";
                Boolean _tipparcial = false;
                _tipcontratoid = tmpdata.Rows[nfiladata]["tipcontratoid"].ToString();
                _tipestado = tmpdata.Rows[nfiladata]["estado"].ToString();
                _tipparcial = Convert.ToBoolean(tmpdata.Rows[nfiladata]["tparcial"].ToString());

                if (_tipcontratoid.ToString() == "01" && _tipestado == "01" && _tipparcial == false)
                {
                    FORMTATO = "01";
                }

                if (_tipcontratoid.ToString() == "04" && _tipestado == "01" && _tipparcial == false)
                {
                    FORMTATO = "01";
                }

                if (_tipcontratoid.ToString() == "04" && _tipestado == "01" && _tipparcial == true)
                {
                    FORMTATO = "02";
                }

                if (_tipcontratoid.ToString() == "04" && _tipestado == "02" && _tipparcial == false)
                {
                    FORMTATO = "03";
                }

                if (_tipcontratoid.ToString() == "04" && _tipestado == "02" && _tipparcial == true)
                {
                    FORMTATO = "03";
                }
                #endregion


                for (nfiladata = 0; nfiladata <= tmpdata.Rows.Count - 1; nfiladata++)
                {
                    for (nfilaformatocontrato = 0; nfilaformatocontrato <= tmpformatos.Rows.Count - 1; nfilaformatocontrato++)
                    {                        
                        if (tmpformatos.Rows[nfilaformatocontrato]["tipoestado"].ToString() == FORMTATO.ToString())
                        {
                            cDocument = TmpFile(GetExtensionFile(tmpformatos.Rows[nfilaformatocontrato]["plantillaname"].ToString()));
                            zgenerafile = WriteFileData(cDocument, (byte[])(tmpformatos.Rows[nfilaformatocontrato]["plantillaword"]));
                            break;
                        }

                    }

                    if (zgenerafile)
                    {
                        //Columnas
                        oWord = null;
                        oDocument = null;
                        loSelection = null;
                        oDocActive = null;
                        oWord = new Word.Application();
                        oWord.Visible = false;
                        oDocument = oWord.Documents.Open(cDocument);
                        for (vmfilascamposreplace = 0; (vmfilascamposreplace <= (workTable.Rows.Count - 1)); vmfilascamposreplace++)
                        {
                            loSelection = oWord.Selection;
                            cValueTofind = workTable.Rows[vmfilascamposreplace]["nomcampo"].ToString().Trim().ToUpper();

                            cValueToreplace = (Strings.Space(1) + (tmpdata.Rows[nfiladata][cValueTofind] + Strings.Space(1)));
                            while ((1 == 1))
                            {
                                var _with1 = loSelection.Find;
                                _with1.Text = cValueTofind;
                                _with1.Replacement.Text = cValueToreplace;
                                _with1.Forward = true;
                                _with1.Wrap = Word.WdFindWrap.wdFindContinue;
                                var _with2 = loSelection;
                                lValue = _with2.Find.Execute();
                                if (lValue)
                                {
                                    _with2.Text = cValueToreplace;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        oDocActive = oWord.ActiveDocument;
                        oWord.ActiveDocument.SaveAs(vmdirectory + tmpdata.Rows[nfiladata]["nomempresa"] + "_" + tmpdata.Rows[nfiladata]["ficha"] + "_" + Strings.Replace(tmpdata.Rows[nfiladata]["vm_nomtrabajador"].ToString(), " ", "_"));
                        oWord.Quit();
                        BorrarFile(cDocument);
                        zloaddirectory = true;
                    }
                }
                if (zloaddirectory)
                {
                    System.Diagnostics.Process.Start(vmdirectory);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR AL CREAR DOCUMENTO");
            }
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
                MessageBox.Show(ex.Message, "Error");
            }
            return zborrar & xtmpfile.Trim().Length > 0;
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

        public static bool EofTable(DataTable lptabladatos)
        {
            bool zeof = true;
            try
            {
                if (lptabladatos.Rows.Count > 0)
                {
                    zeof = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return zeof;
        }

        public static void SetKey(DataGridView Grid, string NomColumna, object ValorColumna, string NomColumnaFocus)
        {
            bool zhallado = false;
            int vncont = 0;
            int nfirsline = -1;
            int ncurrentfila = -1;
            //int ncurrentcol = -1;
            if ((Grid.CurrentCell != null))
            {
                if (Grid.Rows[Grid.CurrentCell.RowIndex].Cells[NomColumna].Value.ToString() == ValorColumna.ToString())
                {
                    ncurrentfila = Grid.CurrentCell.RowIndex;
                }
            }
            Grid.CurrentCell = null;

            for (vncont = 0; vncont <= Grid.Rows.Count - 1; vncont++)
            {
                if (Grid.Rows[vncont].Cells[NomColumna].Value.ToString() == ValorColumna.ToString())
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



        //Saber si hay concexion a internet
        public static bool compruebaConexion()
        {
            WebRequest request = null;
            WebResponse response = null;
            //Uri Url = new Uri("http://www.pabletoreto.blogspot.com");
            Uri Url = new Uri("http://ww1.sunat.gob.pe");
            try
            {
                //Creamos la request
                request = System.Net.WebRequest.Create(Url);
                //POnemos un tiempo limite
                request.Timeout = 5000;
                //ejecutamos la request
                response = request.GetResponse();
                response.Close();
                request = null;
                //label1.Text = System.Environment.MachineName + "si hay conexion a internet";
                return true;
            }
            catch (Exception ex)
            {
                //si ocurre un error, devolvemos error
                request = null;
                //label1.Text = "No hay conexion a internet";
                return false;
            }
        }


        public static string GET_PARAMETROS_TABLA(String idper, String pgurl)
        {
            String xdominioid = "", xmoduloid = "", xlocal = "", xtabla = "";
            try
            {
                perfilitemsBL BL = new perfilitemsBL();
                tb_perfilitems BE = new tb_perfilitems();
                DataTable dt = new DataTable();
                BE.idper = idper;
                BE.pgurl = pgurl;

                dt = BL.GetAll_nivel_acceso(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["dominioid"].ToString().Trim().Length > 0)
                        xdominioid = dt.Rows[0]["dominioid"].ToString().Trim();
                    if (dt.Rows[0]["moduloid"].ToString().Trim().Length > 0)
                        xmoduloid = dt.Rows[0]["moduloid"].ToString().Trim();
                    if (dt.Rows[0]["local"].ToString().Trim().Length > 0)
                        xlocal = dt.Rows[0]["local"].ToString().Trim();
                    xtabla = xdominioid + xmoduloid + xlocal;
                    if (xtabla.Trim().Length > 0)
                    {
                        xtabla = xtabla;
                    }
                    else
                    {
                        xtabla = "0";
                    }
                }
                else
                {
                    xtabla = "0";
                }

            }
            catch (Exception ex)
            {
                xtabla = "0";
            }
            return xtabla;
        }


        public static void REPORTE_WORD_WEB(DataTable tmpdata,String xdoc)
        {
            int vmcolummnas = 0;    
            int nfiladata = 0;
            int vmfilascamposreplace = 0;

            Word.Application oWord;
            Word.Document oDocument;
            Word.Selection loSelection;

            string cValueToreplace = "";
            bool lValue = false;
            string cValueTofind = "";
     
            //string vmdirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            //System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            //FolderBrowserDialog1.ShowNewFolderButton = true;

            try
            {                                
                DataTable workTable = new DataTable();
                string cDocument = "";
                bool zgenerafile = false;
                workTable.Columns.Add("nomcampo", Type.GetType("System.String"));
                for (vmcolummnas = 0; vmcolummnas <= tmpdata.Columns.Count - 1; vmcolummnas++)
                {
                    if (Equivalencias.Left(tmpdata.Columns[vmcolummnas].ColumnName, 2) == "[x")
                    {
                        workTable.Rows.Add(INSERTINTOTABLE(workTable));
                        workTable.Rows[workTable.Rows.Count - 1]["nomcampo"] = tmpdata.Columns[vmcolummnas].ColumnName;
                    }
                }
        
                for (nfiladata = 0; nfiladata <= tmpdata.Rows.Count - 1; nfiladata++)
                {
                    String phat = @"C:\ReporteWeb\CONTRATO_PIEERS_EMP";
             
                    cDocument = phat + ".docx";
                    zgenerafile = true;
                    if (zgenerafile)
                    {
                        //Columnas
                        oWord = null;
                        oDocument = null;
                        loSelection = null;
                        oWord = new Word.Application();
                        oWord.Visible = false;

                        oDocument = oWord.Documents.Open(cDocument);
                        for (vmfilascamposreplace = 0; (vmfilascamposreplace <= (workTable.Rows.Count - 1)); vmfilascamposreplace++)
                        {
                            loSelection = oWord.Selection;
                            cValueTofind = workTable.Rows[vmfilascamposreplace]["nomcampo"].ToString().Trim().ToUpper();

                            cValueToreplace = (Strings.Space(1) + (tmpdata.Rows[nfiladata][cValueTofind] + Strings.Space(1)));
                            while ((1 == 1))
                            {
                                var _with1 = loSelection.Find;
                                _with1.Text = cValueTofind;
                                _with1.Replacement.Text = cValueToreplace;
                                
                                _with1.Forward = true;
                                _with1.Wrap = Word.WdFindWrap.wdFindContinue;
                                var _with2 = loSelection;
                                lValue = _with2.Find.Execute();
                                if (lValue)
                                {
                                    _with2.Text = cValueToreplace;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                       
                        Word.Documents documents = oWord.Documents;
                        Word.Document doc = documents.Add(cDocument);
                        //doc.SaveAs2(@"D:\Contratos\" + xdoc.ToString() + "" + ".pdf", Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF);
                        //doc.SaveAs2(@"D:\Contratos\" + xdoc.ToString() + "" + ".doc");
                        //oWord.Quit();
                       
                        if (((doc != null)))
                        {
                            var _with1 = doc;
                            //_with1.SaveAs(@"D:\Contratos\" + xdoc.ToString() + "" + ".pdf", Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF);
                            _with1.SaveAs(@"D:\Contratos\" + xdoc.ToString() + "" + ".docx");
                            _with1.Close();
                        }

                        // Cerramos Word y liberamos los recursos asociados.
                        //
                        oWord.Quit();
                        oWord = null;
                    }
                }         
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR AL CREAR DOCUMENTO");
            }
        }

        public static bool funConexion()
        {
            HttpWebRequest Req;
            HttpWebResponse res;
            try
            {
                Req = (HttpWebRequest)WebRequest.Create("http://www.sbs.gob.pe");
                res = (HttpWebResponse)Req.GetResponse();
                Req.Abort();

                if (res.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private static String _SiconexionInternet;
        public static String SiconexionInternet
        {
            get { return _SiconexionInternet; }

            set { _SiconexionInternet = value; }
        }
    
    }
}
