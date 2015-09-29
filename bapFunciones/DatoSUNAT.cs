using System;
using System.Drawing;
using System.Net;
using System.IO;
using System.Web;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using Microsoft.VisualBasic;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace bapFunciones
{
    public class DatoSUNAT
    {
        public enum ResulSunat
        {
            /// <summary>
            /// Se encontro la persona
            /// </summary>
            Ok = 0,
            /// <summary>
            /// No se encontro la persona
            /// </summary>
            NoResul = 1,
            /// <summary>
            /// la imagen capcha no es valida
            /// </summary>
            ErrorCapcha = 2,
            /// <summary>
            /// Error no especificado
            /// </summary>
            Error = 3,
        }

        private ResulSunat state;

        #region Propiedades
        //private string _Nombres = "";
        //private string _ApePaterno = "";
        //private string _ApeMaterno = "";
        //private string _Pertenece = "";

        private String _Ruc;
        public String Ruc
        {
            get { return _Ruc; }
            set { _Ruc = value; }
        }

        /// <summary>
        /// Si no Hubo error en la lectura de datos devuelve los nombres 
        /// o razón social caso contrario devuelve ""
        /// </summary>
        private String _RazonSocial;
        public String RazonSocial
        {
            get { return _RazonSocial; }
            set { _RazonSocial = value; }
        }

        private String _Estado;
        public String Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        private String _Condicion;
        public String Condicion
        {
            get { return _Condicion; }
            set { _Condicion = value; }
        }

        /// <summary>
        /// Si no Hubo error en la lectura de datos devuelve
        /// la direccion caso contrario devuelve ""
        private String _Direccion;
        public String Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }

        private String _Telefonos;
        public String Telefonos
        {
            get { return _Telefonos; }
            set { _Telefonos = value; }
        }

        private Boolean _AgeRetencion;
        public Boolean AgeRetencion
        {
            get { return _AgeRetencion; }
            set { _AgeRetencion = value; }
        }

        private Boolean _AgePercepcion;
        public Boolean AgePercepcion
        {
            get { return _AgePercepcion; }
            set { _AgePercepcion = value; }
        }

        private Boolean _BuenContribuyente;
        public Boolean BuenContribuyente
        {
            get { return _BuenContribuyente; }
            set { _BuenContribuyente = value; }
        }

        private string _Pertenece = "";
        //public string Pertenece { get { return _Pertenece; } }

        private CookieContainer myCookieSunat;

        /// <summary>
        /// Devuelve la imagen para el reto capcha
        /// </summary>
        public Image GetCapchaSunat { get { return ReadCapchaSunat(); } }

        public string Pertenece { get { return _Pertenece; } }

        /// <summary>
        /// Devuelve el resultado de la busqueda de DNI
        /// </summary>
        public ResulSunat GetResul { get { return state; } }

        #endregion

        #region Constructor

        public DatoSUNAT()
        {
            if (VariablesPublicas.compruebaConexion() == true)
            {
                if (ConexionSunat() == true)
                {
                    try
                    {
                        myCookieSunat = null;
                        myCookieSunat = new CookieContainer();

                        //Permitir SSL
                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(ValidarCertificado);

                        ReadCapchaSunat();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        private Boolean ValidarCertificado(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        #endregion

        /// <summary>
        /// Carga la imagen Capcha
        /// </summary>
        private Image ReadCapchaSunat()
        {
            try
            {
                //if (HttpWebRequest == null)
                //{
                HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create("http://ww1.sunat.gob.pe/cl-ti-itmrconsruc/captcha?accion=image");
                //HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create("http://ww1.sunat.gob.pe/cl-ti-itmrconsruc/captcha?accion=image&magic=2");
                //}

                myWebRequest.CookieContainer = myCookieSunat;

                myWebRequest.Proxy = null;

                myWebRequest.Credentials = CredentialCache.DefaultCredentials;

                HttpWebResponse myWebResponse = (HttpWebResponse)myWebRequest.GetResponse();

                Stream myImgStream = myWebResponse.GetResponseStream();

                //myWebResponse.Close();

                return Image.FromStream(myImgStream);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Inicia la carga de los datos del contribuyente
        /// </summary>
        /// <param name="numRuc"></param>
        /// <param name="ImgCapcha"></param>
        public void GetInfoSunat(string numRuc, string ImgCapcha)
        {
            try
            {
                string NuevoRus = "";
                //string resultado = "";
                string lc_Texto = "";
                int ln_PosIni = 0; int ln_PosFin = 0;
                string _WebSource = string.Empty;
                //string myUrl = String.Format("http://www.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias?accion=consPorRuc&nroRuc=" + numRuc + "&codigo=" + ImgCapcha);
                string myUrl = String.Format("http://www.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias?accion=consPorRuc&nroRuc={0}&codigo={1}", numRuc, ImgCapcha);

                HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(myUrl);
                myWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0";//esto creo que lo puse por gusto :/
                myWebRequest.CookieContainer = myCookieSunat;
                myWebRequest.Credentials = CredentialCache.DefaultCredentials;
                myWebRequest.Proxy = null;

                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
                Stream myStream = myHttpWebResponse.GetResponseStream();
                StreamReader myStreamReader = new StreamReader((myStream), Encoding.GetEncoding("ISO-8859-1"));

                _WebSource = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd());

                ln_PosIni = Strings.InStr(_WebSource, "cellpadding");
                ln_PosFin = Strings.InStr(_WebSource, "select");
                if ((_WebSource.IndexOf("consultado no es válido.") + 1) > 0 | (_WebSource.IndexOf("Surgieron problemas al procesar") + 1) > 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(_WebSource, "Error en búsqueda de Ruc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //numRuc.Focus();
                    return;
                }
                else
                {
                    _BuenContribuyente = Strings.InStr(_WebSource, "Buenos Contribuyentes") > 0 ? true : false;
                    _AgeRetencion = Strings.InStr(_WebSource, "Agentes de Retención") > 0 ? true : false;
                    _AgePercepcion = Strings.InStr(_WebSource, "Agentes de Percepción") > 0 ? true : false;
                    NuevoRus = Strings.InStr(_WebSource, "Afecto al Nuevo RUS:") > 0 ? "Afecto al Nuevo RUS:" : "";
                    lc_Texto = Strings.Mid(_WebSource, ln_PosIni, ln_PosFin - ln_PosIni);
                    lc_Texto = HtmlRemoval.StripTagsRegex(lc_Texto);
                    lc_Texto = HtmlRemoval.StripTagsRegexCompiled(lc_Texto);
                    lc_Texto = HtmlRemoval.StripTagsCharArray(lc_Texto);
                    string[] _split = lc_Texto.Split(new char[] { '<', '>', '\n', '\r' });

                    //string[] _split = _WebSource.Split(new char[] { '<', '>', '\n', '\r' });

                    List<string> _resul = new List<string>();

                    //quitamos todos los caracteres nulos
                    for (int i = 0; i < _split.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(_split[i].Trim()))
                            _resul.Add(_split[i].Trim());
                    }
                    //resultado = lc_Texto;

                    // Anlizando el arreglo "_resul" llegamos a la siguiente conclusion
                    // 
                    // _resul.Count == 217 cuando nos equivocamos en el captcha
                    // _resul.Count == 232 cuando todo salio ok
                    // _resul.Count == 222 cuando no existe el DNI
                    //

                    //switch (_resul.Count)
                    //{
                    //    case 217:
                    //        state = Resul.ErrorCapcha;
                    //        break;
                    //    case 232:
                    //        state = Resul.Ok;
                    //        break;
                    //    case 222:
                    //        state = Resul.NoResul;
                    //        break;
                    //    default:
                    //        state = Resul.Error;
                    //        break;
                    //}

                    //if (state == Resul.Ok)
                    //{
                    //    _Nombres = _resul[185];
                    //    _ApePaterno = _resul[186];
                    //    _ApeMaterno = _resul[187];
                    //}
                    _Ruc = "";
                    _RazonSocial = "";
                    _Estado = "";
                    _Condicion = "";
                    _Direccion = "";
                    _Telefonos = "";

                    if (_resul.Count == 30 | _resul.Count == 31)
                    {
                        _Ruc = Equivalencias.Mid(_resul[2], 1, 11);
                        _RazonSocial = Equivalencias.Mid(_resul[2], 15, Equivalencias.Len(_resul[2]) - 12);
                        _Estado = _resul[12];
                        _Condicion = _resul[14];
                        _Direccion = _resul[16];
                        _Telefonos = _resul[19];
                    }
                    if (_resul.Count == 33 | _resul.Count == 35) //Contribuyente con carnet de extranjeria
                    {
                        if (NuevoRus == "Afecto al Nuevo RUS:")
                        {
                            _Ruc = Equivalencias.Mid(_resul[2], 1, 11);
                            _RazonSocial = Equivalencias.Mid(_resul[2], 15, Equivalencias.Len(_resul[2]) - 12);
                            _Estado = _resul[16];
                            _Condicion = _resul[18];
                            _Direccion = _resul[20];
                            _Telefonos = _resul[23];
                        }
                        else
                        {
                            _Ruc = Equivalencias.Mid(_resul[2], 1, 11);
                            _RazonSocial = Equivalencias.Mid(_resul[2], 15, Equivalencias.Len(_resul[2]) - 12);
                            _Estado = _resul[14];
                            _Condicion = _resul[16];
                            _Direccion = _resul[18];
                            _Telefonos = _resul[21];
                        }
                    }
                    if (_resul.Count == 34)
                    {
                        _Ruc = Equivalencias.Mid(_resul[2], 1, 11);
                        _RazonSocial = Equivalencias.Mid(_resul[2], 15, Equivalencias.Len(_resul[2]) - 12);
                        _Estado = _resul[15];
                        _Condicion = _resul[17];
                        _Direccion = _resul[19];
                        _Telefonos = _resul[22];
                    }
                    if (_resul.Count == 36 & NuevoRus == "")
                    {
                        if (_resul[19].ToString() == "HABIDO" | _resul[19].ToString() == "NO HABIDO" | _resul[19].ToString() == "NO HALLADO")
                        {
                            _Ruc = Equivalencias.Mid(_resul[2], 1, 11);
                            _RazonSocial = Equivalencias.Mid(_resul[2], 15, Equivalencias.Len(_resul[2]) - 12);
                            _Estado = _resul[15];
                            _Condicion = _resul[19];
                            _Direccion = _resul[21];
                            _Telefonos = _resul[24];
                        }
                        else
                        {
                            _Ruc = Equivalencias.Mid(_resul[2], 1, 11);
                            _RazonSocial = Equivalencias.Mid(_resul[2], 15, Equivalencias.Len(_resul[2]) - 12);
                            _Estado = _resul[15];
                            _Condicion = _resul[17];
                            _Direccion = _resul[19];
                            _Telefonos = _resul[22];
                        }
                    }
                    if (_resul.Count == 36 & NuevoRus == "Afecto al Nuevo RUS:") //Contribuyentes del nuevo RUS
                    {
                        _Ruc = Equivalencias.Mid(_resul[2], 1, 11);
                        _RazonSocial = Equivalencias.Mid(_resul[2], 15, Equivalencias.Len(_resul[2]) - 12);
                        _Estado = _resul[17];
                        _Condicion = _resul[19];
                        _Direccion = _resul[21];
                        _Telefonos = _resul[24];
                    }
                    if (_resul.Count == 38)
                    {
                        _Ruc = Equivalencias.Mid(_resul[2], 1, 11);
                        _RazonSocial = Equivalencias.Mid(_resul[2], 15, Equivalencias.Len(_resul[2]) - 12);
                        _Estado = _resul[17];
                        _Condicion = _resul[19];
                        _Direccion = _resul[21];
                        _Telefonos = _resul[24];
                    }
                    if (_resul.Count == 37)
                    {
                        _Ruc = Equivalencias.Mid(_resul[2], 1, 11);
                        _RazonSocial = Equivalencias.Mid(_resul[2], 15, Equivalencias.Len(_resul[2]) - 12);
                        _Estado = _resul[15];
                        _Condicion = _resul[17];
                        _Direccion = _resul[19].Replace("  ", "").Replace("----", "").Replace("\0", "");
                        _Telefonos = _resul[22];
                    }
                    if (_resul.Count == 32)
                    {
                        _Ruc = Equivalencias.Mid(_resul[2], 1, 11);
                        _RazonSocial = Equivalencias.Mid(_resul[2], 15, Equivalencias.Len(_resul[2]) - 12);
                        _Estado = _resul[12];
                        _Condicion = _resul[14];
                        _Direccion = _resul[16].Replace("  ", "").Replace("----", "").Replace("\0", "");
                        _Telefonos = _resul[19];
                    }
                    myHttpWebResponse.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ConexionSunat()
        {
            WebRequest request = null;
            WebResponse response = null;
            Uri Url = new Uri("http://www.sunat.gob.pe");
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

    }
}
