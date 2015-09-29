using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using bapFunciones;

//using CaeSoft.Business.Logic;
public class GlobalVars
{
    #region "Fields"
    //Constantes de Excel
    private long _xlCenter = -4108;
    private long _xlBottom = -4107;
    private long _xlLeft = -4131;

    private long _xlContext = -5002;
    private static GlobalVars _instance = null;
    private string _dominio;
    private string _company;
    private string _periodo;
    private bool _PulsaAyudaArticulos = false;
    private bool _PulsaTeclaF2 = false;
    private bool _PulsaTeclaF3 = false;
    // Variables Seguridad Accesos

    public string _AccesoPlanMaestro = "15";
    // Constantes
    public string _TipoComprobanteContableAjuste = "3";
    public string _BackDooruser = "ADMIN";
    public string _BackDoorpassword = "PACIFIC";
    public string _Nia = "1";
    public string _NSa = "2";
    public string _AlmacenAvios = "27";
    public string _AlmacenTelaAcabada = "20";
    public string _AlmacenTelaCruda = "18";
    public string _AlmacenHilado = "05";
    private bool _PulsaFlechaAbajo = false;
    private string _TipoAlmacenPT = "PT";
    private string _TipoRubroPlanillaIngreso = "I";
    private string _TipoRubroPlanillaDescuento = "D";
    private string _TipoRubroPlanillaAportacion = "A";
    private string _TipoRubroPlanillaPermanente = "P";

    private string _codformapagoletra = "111";
    private string _DetoCorteCantProgramado = "1";
    private string _DetoCorteCantCortado = "2";
    private string _DetoCorteCantxCortar = "3";
    private string _DetoCorteProporcion = "4";
    private string _DetoCorteCapas = "5";
    private string _DetoCorteProporcionLiq = "6";
    private string _DetoCorteCapasLiq = "7";
    private string _DetoCortePrendasProg = "8";

    private string _DetoCortePrendasLiq = "9";


    private string _RubrosIngresoRPTS = "01_02_03_10_20_09";
    private string _RubrosDescuentoRPTS = "06_07";

    private string _RubrosAportacionRPTS = "08";

    //private UsuarioLogic _usuario = null;
    private string _RutaServidor;
    private string _UserID;
    private string _UserName;
    private string _FechaD;
    private string _LOGOCAESOFT;
    private string _modulo;

    private string _password;
    public bool _ayudaItemOS = false;
    public bool _ayudaItemOC = false;
    public bool _ayudaItemRC = false;
    public bool _GeneraItemOC = false;
    public bool _GeneraItemOS = false;
    public bool _AyudaRubroRC = false;
    public bool _AyudaSubFasesRC = false;
    public string _UserSigla = string.Empty;
    public int _TipoIngTalleres = 1;
    public int _TipoSalTalleres = 2;
    public string RutaImagenes = "http://blueoceansac.com/archivos/usuarios_sys/"; //My.Settings.rutaimagenes;
    //public string RutaImagenes = My.Settings.rutaimagenes;
    public string _RutaFotoPersonal = "\\\\erpserver\\erpcaesoft$\\FOTOS_PERSONAL\\";
    public string _RutaApps = "\\\\erpserver\\erpcaesoft$\\ERP_VS_90\\";
    public string _Bd_Servidor = "";
    public string _Bd_Usuario = "";
    public string _Bd_Database = "";
    public string _Bd_Password = "";
    private DataTable _CopiarCaracteristicas;
    public string _CompanyGeneral = "01";
    public bool _SwExcesoNIAxCompras = false;
    public string _ListaOrdenesNIAS = "";
    // Tipos Documentos
    public int _TipDocusTodos = 1;
    public int _TipDocusCompras = 3;
    public int _TipDocusVentas = 4;
    public int _TipDocusBancos = 5;
    public int _TipDocusAlmacenes = 6;

    public int _TipDocusPagos = 7;


    // Clasificacion Tipos COnceptos
    public string _TipoConceptoCompras = "1";
    public string _TipoConceptoVentas = "2";
    // Clasificacion Filtro Tipos Documento CAG3i00

    public int _TipoDocumentoContableTodos = 1;
    public int _TipoDocumentoContableTesoreria = 2;
    public int _TipoDocumentoContableContabilidad = 4;
    public int _TipoDocumentoContableTesoreriaContabilidad = 6;
    public string _tipocierremensualcontable = "CON";
    public string _tipocierremensualcompra = "COM";

    public string _tipocierremensualVentas = "VEN";
    // Clasificacion Filtro Tipos Cuentas CAG0200
    public int _CuentasContablesMayor = 1;
    public int _CuentasContablesDetalladas = 2;
    public int _CuentasContablesTodas = 3;
    public int _CuentasContablesImputables = 4;
    // Constantes
    public string _MonedaCodSoles = "01";
    public string _MonedaCoddolares = "02";
    public string _ContabilidadIdCargo = "D";
    public string _ContabilidadIdAbono = "H";
    public string _CodVoucherCompras = "543";
    public string _CodVoucherVentas = "544";
    public string _RelCuentasCancelacionesCobranzas = "12_13_14_15_16_17_18_38_37_41_42_43_44_45_46_47";
    //Public _Cod
    // COntantes para Cancelaciones - TESORERIA 
    public int _CancelacionesDocumentosPendientes = 1;
    public int _CancelacionesDocumentosRelacionadosFACNCR = 2;

    public int _CancelacionesListaDetalles = 3;
    // constantes RHP
    public decimal _TopeMontoRHPRetencion = 700;
    public decimal _POrcentajeRetencion = 10;
    //Constantes cuenta corriente
    public int _CuentaCorrienteReporte = 1;
    public int _CuentaCorrientecac3p00 = 2;
    // Constante tipos Ordenes Servicios
    public string _tipoOrdenServtejeduria = "A1";
    // Constantes Para Roleo de Registros
    public string _TOPRECORD = "TOP";
    public string _BOTTRECORD = "BOTT";
    public string _NEXTRECORD = "SKIP+";
    public string _PREVRECORD = "SKIP-";
    // Tipos Mess
    public int _MESESCALENDARIO = 1;
    public int _MESESTODOS = 2;
    //Usado para grabar nombre de nuevo Archivo 
    public string _NombreArchivoSubido = "";
    // USado para analisar información Cta.Cte.
    public int _CtaCteCUEDETTIPNUM = 1;
    public int _CtaCteCUEDETTIPNUMPEDOPCCOSTo = 2;
    // Constantes Generar Datos PLanilla Electrónica
    public int _RPTS_RHP = 3;
    public int _RPTS_DatosTrab = 2;
    public int _RPTS_DatosPrincipalesTrab = 1;
    public int _RPTS_DatosPeriodosLaborales = 5;
    public int _RPTS_DatosEstablecimientos = 6;
    public int _RPTS_DatosIngAporDctos = 7;
    // Vaiablea de Configuración
    public string _RutaRPT = "";
    // Datos Factura Exportación
    public string _DregimenArancelario = "SE ACOGE  A RESTITUCION DE DERECHOS ARANCELARIOS DRAW BACK D.S. Nº 104-95 EF (Código Nº 13)";
    // Constantes nro Voucher ALMAF
    #endregion
    public string _MesVoucherBVE = "16";

    #region "Constructors"

    private GlobalVars()
    {
        _dominio = _dominio;
    }

    private GlobalVars(string dominio)
    {
        _dominio = dominio;
    }

    private GlobalVars(string dominio, string periodo)
    {
        _dominio = dominio;
        _periodo = periodo;
    }

    #endregion

    #region "Instance"

    public static GlobalVars GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GlobalVars();
        }
        return _instance;
    }

    public static GlobalVars GetInstance(string dominio)
    {
        if (_instance == null)
        {
            _instance = new GlobalVars(dominio);
        }
        return _instance;
    }

    public static GlobalVars GetInstance(string dominio, string periodo)
    {
        if (_instance == null)
        {
            _instance = new GlobalVars(dominio, periodo);
        }
        return _instance;
    }

    #endregion

    #region "Properties"

    public string AlmacenAvios
    {
        get { return _AlmacenAvios; }
        set { _AlmacenAvios = value; }
    }

    public string AlmacenTelaAcabada
    {
        get { return _AlmacenTelaAcabada; }
        set { _AlmacenTelaAcabada = value; }
    }

    public string AlmacenTelaCruda
    {
        get { return _AlmacenTelaCruda; }
        set { _AlmacenTelaCruda = value; }
    }

    public string AlmacenHilado
    {
        get { return _AlmacenHilado; }
        set { _AlmacenHilado = value; }
    }

    public string Dominio
    {
        get
        {
            if (_dominio == string.Empty)
            {
                //_dominio = Settings.Dominio;
            }
            return _dominio;
        }
        set
        {
            //My.Settings.Dominio = value;
            _dominio = value;
        }
    }

    public string Company
    {
        get
        {
            if (_company == string.Empty)
            {
                //_company = My.Settings.company;
            }
            return _company;
        }
        set
        {
            //My.Settings.company = value;
            _company = value;
        }
    }

    public string Periodo
    {
        get
        {
            if (_periodo == string.Empty)
            {
                //_periodo = My.Settings.Periodo;
            }
            return _periodo;
        }
        set
        {
            //My.Settings.Periodo = value;
            _periodo = value;
        }
    }

    //public UsuarioLogic Usuario
    //{
    //    get
    //    {
    //        if (_usuario == null)
    //        {
    //            _usuario = getUsuario();
    //        }
    //        return _usuario;
    //    }
    //    set
    //    {
    //        _usuario = value;
    //        setUsuario(value);
    //    }
    //}
    public string RutaServer
    {
        get
        {
            if (_RutaServidor == null)
            {
                //_RutaServidor = My.Settings.RutaServer;
            }
            return _RutaServidor;
        }
        set
        {
            //My.Settings.RutaServer = value;
            _RutaServidor = value;
        }
    }
    public string UserSigla
    {
        get
        {
            if (_UserSigla == null)
            {
                //_UserSigla = My.Settings.UserSigla;
            }
            return _UserSigla;
        }
        set
        {
            //My.Settings.UserSigla = value;
            _UserSigla = value;
        }
    }

    public string LOGOBAPSOFT
    {
        get
        {
            if (_LOGOCAESOFT == null)
            {
                _LOGOCAESOFT = "ERP .BAPSOFT .NET";
            }
            return _LOGOCAESOFT;
        }
        set { _LOGOCAESOFT = value; }
    }
    public string UserID
    {
        get
        {
            if (_UserID == null)
            {
                //_UserID = My.Settings.UserID;
            }
            return _UserID;
        }
        set
        {
            //My.Settings.UserID = value;
            _UserID = value;
        }
    }

    public string UserName
    {
        get
        {
            if (_UserName == null)
            {
                //_UserName = My.Settings.UserName;
            }
            return _UserName;
        }
        set
        {
            //My.Settings.UserName = value;
            _UserName = value;
        }
    }
    public string modulo
    {
        get
        {
            if (_modulo == null)
            {
                //_modulo = My.Settings.modulo;
            }
            return _modulo;
        }
        set
        {
            //My.Settings.modulo = value;
            _modulo = value;
        }
    }
    public string FechaD
    {
        get
        {
            if (_FechaD == null)
            {
                //_FechaD = My.Settings.FechaD;
            }
            return _FechaD;
        }
        set
        {
            //My.Settings.FechaD = value;
            _FechaD = value;
        }
    }

    public bool PulsaFlechaAbajo
    {

        get { return _PulsaFlechaAbajo; }
        set { _PulsaFlechaAbajo = value; }
    }
    public bool PulsaAyudaArticulos
    {

        get { return _PulsaAyudaArticulos; }
        set { _PulsaAyudaArticulos = value; }
    }
    public string Bd_Servidor
    {
        get { return _Bd_Servidor; }
        set { _Bd_Servidor = value; }
    }
    public string Bd_Usuario
    {
        get { return _Bd_Usuario; }
        set { _Bd_Usuario = value; }
    }
    public string Bd_Database
    {
        get { return _Bd_Database; }
        set { _Bd_Database = value; }
    }
    public string Bd_Password
    {
        get { return _Bd_Password; }
        set { _Bd_Password = value; }
    }
    public DataTable CopiarCaracteristicas
    {
        get { return _CopiarCaracteristicas; }
        set { _CopiarCaracteristicas = value; }
    }
    public string CompanyGeneral
    {
        get { return _CompanyGeneral; }
        set { _CompanyGeneral = value; }
    }
    public bool SwExcesoNIAxCompras
    {
        get { return _SwExcesoNIAxCompras; }
        set { _SwExcesoNIAxCompras = value; }
    }

    public string ListaOrdenesNIAS
    {
        get { return _ListaOrdenesNIAS; }
        set { _ListaOrdenesNIAS = value; }
    }
    public int TipDocusAlmacenes
    {
        get { return _TipDocusAlmacenes; }
        set { _TipDocusAlmacenes = value; }
    }
    public string TipoConceptoCompras
    {
        get { return _TipoConceptoCompras; }
        set { _TipoConceptoCompras = value; }
    }
    public int TipoDocumentoContableTodos
    {
        get { return _TipoDocumentoContableTodos; }
        set { _TipoDocumentoContableTodos = value; }
    }
    public int TipoDocumentoContableTesoreria
    {
        get { return _TipoDocumentoContableTesoreria; }
        set { _TipoDocumentoContableTesoreria = value; }
    }
    public int TipoDocumentoContableContabilidad
    {
        get { return _TipoDocumentoContableContabilidad; }
        set { _TipoDocumentoContableContabilidad = value; }
    }
    public int CuentasContablesMayor
    {
        get { return _CuentasContablesMayor; }
        set { _CuentasContablesMayor = value; }
    }

    public int CuentasContablesDetalladas
    {
        get { return _CuentasContablesDetalladas; }
        set { _CuentasContablesDetalladas = value; }
    }
    public int CuentasContablesTodas
    {
        get { return _CuentasContablesTodas; }
        set { _CuentasContablesTodas = value; }
    }
    public int CuentasContablesImputables
    {
        get { return _CuentasContablesTodas; }
        set { _CuentasContablesImputables = value; }
    }
    public string MonedaCodSoles
    {
        get { return _MonedaCodSoles; }
        set { _MonedaCodSoles = value; }
    }
    public string MonedaCodDolares
    {
        get { return _MonedaCoddolares; }
        set { _MonedaCoddolares = value; }
    }
    public string ContabilidadIdCargo
    {
        get { return _ContabilidadIdCargo; }
        set { _ContabilidadIdCargo = value; }
    }
    public string ContabilidadIdAbono
    {
        get { return _ContabilidadIdAbono; }
        set { _ContabilidadIdAbono = value; }
    }
    public int TipoDocumentoContableTesoreriaContabilidad
    {
        get { return _TipoDocumentoContableTesoreriaContabilidad; }
        set { _TipoDocumentoContableTesoreriaContabilidad = value; }
    }

    public string CodVoucherCompras
    {
        get { return _CodVoucherCompras; }
        set { _CodVoucherCompras = value; }
    }

    public int CancelacionesDocumentosPendientes
    {
        get { return _CancelacionesDocumentosPendientes; }
        set { _CancelacionesDocumentosPendientes = value; }
    }
    public int CancelacionesDocumentosRelacionadosFACNCR
    {
        get { return _CancelacionesDocumentosRelacionadosFACNCR; }
        set { _CancelacionesDocumentosRelacionadosFACNCR = value; }
    }
    public int CancelacionesListaDetalles
    {
        get { return _CancelacionesListaDetalles; }
        set { _CancelacionesListaDetalles = value; }
    }
    public string TipoConceptoVentas
    {
        get { return _TipoConceptoVentas; }
        set { _TipoConceptoVentas = value; }
    }
    public decimal TopeMontoRHPRetencion
    {
        get { return _TopeMontoRHPRetencion; }
        set { _TopeMontoRHPRetencion = value; }
    }
    public string CodVoucherVentas
    {
        get { return _CodVoucherVentas; }
        set { _CodVoucherVentas = value; }
    }
    public decimal POrcentajeRetencion
    {
        get { return _POrcentajeRetencion; }
        set { _POrcentajeRetencion = value; }
    }
    public int CuentaCorrienteReporte
    {
        get { return _CuentaCorrienteReporte; }
        set { _CuentaCorrienteReporte = value; }
    }
    public int CuentaCorrientecac3p00
    {
        get { return _CuentaCorrientecac3p00; }
        set { _CuentaCorrientecac3p00 = value; }
    }
    public string RelCuentasCancelacionesCobranzas
    {
        get { return _RelCuentasCancelacionesCobranzas; }
        set { _RelCuentasCancelacionesCobranzas = value; }
    }
    public string tipoOrdenServtejeduria
    {
        get { return _tipoOrdenServtejeduria; }
        set { _tipoOrdenServtejeduria = value; }
    }
    public string NombreArchivoSubido
    {
        get { return _NombreArchivoSubido; }
        set { _NombreArchivoSubido = value; }
    }
    public int CtaCteCUEDETTIPNUM
    {
        get { return _CtaCteCUEDETTIPNUM; }
        set { _CtaCteCUEDETTIPNUM = value; }
    }
    public int CtaCteCUEDETTIPNUMPEDOPCCOSTO
    {
        get { return _CtaCteCUEDETTIPNUMPEDOPCCOSTo; }
        set { _CtaCteCUEDETTIPNUMPEDOPCCOSTo = value; }
    }
    public int RPTS_RHP
    {
        get { return _RPTS_RHP; }
        set { _RPTS_RHP = value; }
    }
    public int RPTS_DatosPrincipalesTrab
    {
        get { return _RPTS_DatosPrincipalesTrab; }
        set { _RPTS_DatosPrincipalesTrab = value; }
    }
    public int RPTS_DatosTrab
    {
        get { return _RPTS_DatosTrab; }
        set { _RPTS_DatosTrab = value; }
    }
    public string Nia
    {
        get { return _Nia; }
        set { _Nia = value; }
    }
    public string Nsa
    {
        get { return _NSa; }
        set { _NSa = value; }
    }
    public string AccesoPlanMaestro
    {
        get { return _AccesoPlanMaestro; }
        set { _AccesoPlanMaestro = value; }
    }
    public string RutaFotoPersonal
    {
        get { return _RutaFotoPersonal; }
        set { _RutaFotoPersonal = value; }
    }
    public long xlCenter
    {
        get { return _xlCenter; }
    }
    public long xlBottom
    {
        get { return _xlBottom; }
    }
    public long xlLeft
    {
        get { return _xlLeft; }
    }
    public long xlContext
    {
        get { return _xlContext; }
    }
    public string DetoCorteCantCortado
    {
        get { return _DetoCorteCantCortado; }
    }
    public string DetoCorteCantxCortar
    {
        get { return _DetoCorteCantxCortar; }
    }
    public string DetoCorteProporcion
    {
        get { return _DetoCorteProporcion; }
    }
    public string DetoCorteCapas
    {
        get { return _DetoCorteCapas; }
    }
    public string DetoCorteProporcionLiq
    {
        get { return _DetoCorteProporcionLiq; }
    }
    public string DetoCorteCapasLiq
    {
        get { return _DetoCorteCapasLiq; }
    }
    public string DetoCortePrendasProg
    {
        get { return _DetoCortePrendasProg; }
    }

    public string DetoCortePrendasLiq
    {
        get { return _DetoCortePrendasLiq; }
    }
    public string DetoCorteCantProgramado
    {
        get { return _DetoCorteCantProgramado; }
    }
    public string TipoComprobanteContableAjuste
    {
        get { return _TipoComprobanteContableAjuste; }
    }
    public string MesVoucherBVE
    {
        get { return _MesVoucherBVE; }
    }
    #endregion
    #region "Methods"

    //private void setUsuario(UsuarioLogic usuario)
    //{
    //    My.Settings.UserID = usuario.Codigo;
    //    My.Settings.UserName = usuario.UserName;
    //    My.Settings.Password = usuario.Password;
    //}

    //private UsuarioLogic getUsuario()
    //{
    //    UsuarioLogic usu = new UsuarioLogic();

    //    usu.Codigo = My.Settings.UserID;
    //    usu.UserName = My.Settings.UserName;
    //    usu.Password = My.Settings.Password;
    //    return usu;
    //}
    //public string getNameEmpresa()
    //{
    //    EmpresasLogic usu = new EmpresasLogic();
    //    string X_name = null;
    //    int LC_CONT = 0;
    //    X_name = "";
    //    for (LC_CONT = 0; LC_CONT <= usu.EmpresasTable.Rows.Count - 1; LC_CONT++)
    //    {
    //        if (usu.EmpresasTable.Rows(LC_CONT).Item(0) == GlobalVars.GetInstance().Company)
    //        {
    //            X_name = usu.EmpresasTable.Rows(LC_CONT).Item("razon_5");
    //        }
    //    }
    //    return X_name;
    //}
    public bool AyudaItemOS
    {
        get { return _ayudaItemOS; }
        set { _ayudaItemOS = value; }
    }
    public bool AyudaItemOC
    {
        get { return _ayudaItemOC; }
        set { _ayudaItemOC = value; }
    }

    public bool GenerarItemOC
    {
        get { return _GeneraItemOC; }
        set { _GeneraItemOC = value; }
    }

    public bool GenerarItemOS
    {
        get { return _GeneraItemOS; }
        set { _GeneraItemOS = value; }
    }
    public bool AyudaItemRC
    {
        get { return _ayudaItemRC; }
        set { _ayudaItemRC = value; }
    }

    public bool AyudaRubroRC
    {
        get { return _AyudaRubroRC; }
        set { _AyudaRubroRC = value; }
    }

    public bool AyudaSubFasesRC
    {
        get { return _AyudaSubFasesRC; }
        set { _AyudaSubFasesRC = value; }
    }
    //public string NombreMes(string cmes)
    //{
    //    string xreturn = "";
    //    int lc_cont = 0;
    //    System.Data.DataTable oData = new System.Data.DataTable();
    //    oData = MesesLogic.GetAll();
    //    for (lc_cont = 0; lc_cont <= oData.Rows.Count - 1; lc_cont++)
    //    {
    //        if (oData.Rows[lc_cont]["CMES"] == cmes)
    //        {
    //            xreturn = oData.Rows[lc_cont]["DMES"];
    //            break; 
    //        }
    //    }
    //    return xreturn;
    //}
    public int TipDocusTodos
    {
        get { return _TipDocusTodos; }
        set { _TipDocusTodos = value; }
    }
    public int TipDocusCompras
    {
        get { return _TipDocusCompras; }
        set { _TipDocusCompras = value; }
    }
    public int TipDocusVentas
    {
        get { return _TipDocusVentas; }
        set { _TipDocusVentas = value; }
    }
    public int TipDocusBancos
    {
        get { return _TipDocusBancos; }
        set { _TipDocusBancos = value; }
    }
    public int TipDocusPagos
    {
        get { return _TipDocusPagos; }
        set { _TipDocusPagos = value; }
    }
    public bool PulsaTeclaF2
    {
        get { return _PulsaTeclaF2; }
        set { _PulsaTeclaF2 = value; }
    }
    public bool PulsaTeclaF3
    {
        get { return _PulsaTeclaF3; }
        set { _PulsaTeclaF3 = value; }
    }
    
    public string TOPRECORD
    {
        get { return _TOPRECORD; }
        set { _TOPRECORD = value; }
    }
    public string BOTTRECORD
    {
        get { return _BOTTRECORD; }
        set { _BOTTRECORD = value; }
    }
    public string PREVRECORD
    {
        get { return _PREVRECORD; }
        set { _PREVRECORD = value; }
    }
    public string NEXTRECORD
    {
        get { return _NEXTRECORD; }
        set { _NEXTRECORD = value; }
    }
    
    public int MESESCALENDARIO
    {
        get { return _MESESCALENDARIO; }
        set { _MESESCALENDARIO = value; }
    }
    public int MESESTODOS
    {
        get { return _MESESTODOS; }
        set { _MESESTODOS = value; }
    }
    public string TipoAlmacenPT
    {
        get { return _TipoAlmacenPT; }
        set { _TipoAlmacenPT = value; }
    }
    public string TipoRubroPlanillaIngreso
    {
        get { return _TipoRubroPlanillaIngreso; }
        set { _TipoRubroPlanillaIngreso = value; }
    }
    public string RubrosIngresoRPTS
    {
        get { return _RubrosIngresoRPTS; }
        set { _RubrosIngresoRPTS = value; }
    }
    public string RubrosDescuentoRPTS
    {
        get { return _RubrosDescuentoRPTS; }
        set { _RubrosDescuentoRPTS = value; }
    }
    public string TipoRubroPlanillaDescuento
    {
        get { return _TipoRubroPlanillaDescuento; }
        set { _TipoRubroPlanillaDescuento = value; }
    }
    public string RubrosAportacionRPTS
    {
        get { return _RubrosAportacionRPTS; }
        set { _RubrosAportacionRPTS = value; }
    }
    public string TipoRubroPlanillaAportacion
    {
        get { return _TipoRubroPlanillaAportacion; }
        set { _TipoRubroPlanillaAportacion = value; }
    }
    public int RPTS_DatosPeriodosLaborales
    {
        get { return _RPTS_DatosPeriodosLaborales; }
        set { _RPTS_DatosPeriodosLaborales = value; }
    }

    public int RPTS_DatosEstablecimientos
    {
        get { return _RPTS_DatosEstablecimientos; }
        set { _RPTS_DatosEstablecimientos = value; }
    }
    public int RPTS_DatosIngAporDctos
    {
        get { return _RPTS_DatosIngAporDctos; }
        set { _RPTS_DatosIngAporDctos = value; }
    }
    public string RutaRPT
    {
        get { return _RutaRPT; }
        set { _RutaRPT = value; }
    }
    public string RutaApps
    {
        get { return _RutaApps; }
        set { _RutaApps = value; }
    }
    public string DregimenArancelario
    {
        get { return _DregimenArancelario; }
        set { _DregimenArancelario = value; }
    }
    public string TipoRubroPlanillaPermanente
    {
        get { return _TipoRubroPlanillaPermanente; }
        set { _TipoRubroPlanillaPermanente = value; }
    }
    public string codformapagoletra
    {
        get { return _codformapagoletra; }
        set { _codformapagoletra = value; }
    }
    public string tipocierremensualcontable
    {
        get { return _tipocierremensualcontable; }
        set { _tipocierremensualcontable = value; }
    }
    public string tipocierremensualcompra
    {
        get { return _tipocierremensualcompra; }
        set { _tipocierremensualcompra = value; }
    }
    public string tipocierremensualVentas
    {
        get { return _tipocierremensualVentas; }
        set { _tipocierremensualVentas = value; }
    }
    public string BackDooruser
    {
        get { return _BackDooruser; }
        set { _BackDooruser = value; }
    }
    public string BackDoorpassword
    {
        get { return _BackDoorpassword; }
        set { _BackDoorpassword = value; }
    }
    #endregion
}


//namespace bapFunciones
//{
//    class GlobalVars
//    {
//    }
//}
