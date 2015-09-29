using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using System.IO;
using System.Drawing;


namespace bapFunciones
{
    public class DatosSunat
    {
        public enum Resul
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

        private Resul state;
        private CookieContainer myCookie;

        private String _Ruc;
        public String Ruc
        {
            get { return _Ruc; }
            set { _Ruc = value; }
        }

        private String _RazonSocial;
        public String RazonSocial
        {
            get { return _RazonSocial; }
            set { _RazonSocial = value; }
        }

        private String _AntiguoRuc;
        public String AntiguoRuc
        {
            get { return _AntiguoRuc; }
            set { _AntiguoRuc = value; }
        }

        private String _Estado;
        public String Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        private String _EsAgenteRetencion;
        public String EsAgenteRetencion
        {
            get { return _EsAgenteRetencion; }
            set { _EsAgenteRetencion = value; }
        }

        private String _NombreComercial;
        public String NombreComercial
        {
            get { return _NombreComercial; }
            set { _NombreComercial = value; }
        }

        public String _Direccion;
        public String Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }

        private String _Telefono;
        public String Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        private String _Dependencia;
        public String Dependencia
        {
            get { return _Dependencia; }
            set { _Dependencia = value; }
        }

        private String _Tipo;
        public String Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        //private String _returndatos;
        //public String returndatos
        //{
        //    get { return _returndatos; }

        //    set { _returndatos = value; }
        //}


        public Image GetCapcha { get { return ReadCapcha(); } }

        /// <summary>
        /// Si no Hubo error en la lectura de datos devuelve los nombres 
        /// de la persona caso contrario devuelve ""
        /// </summary>
        //public string Nombres { get { return _Nombres; } }

        /// <summary>
        /// Si no Hubo error en la lectura de datos devuelve el Apellido Paterno
        /// de la persona caso contrario devuelve ""
        //public string ApePaterno { get { return _ApePaterno; } }

        /// <summary>
        /// Si no Hubo error en la lectura de datos devuelve el Apellido Materno
        /// de la persona caso contrario devuelve ""
        //public string ApeMaterno { get { return _ApeMaterno; } }

        /// <summary>
        /// Devuelve el resultado de la busqueda de DNI
        /// </summary>
        public Resul GetResul { get { return state; } }


        

 
        #region Private

        //private const string urlinforuc = "http://www.sunat.gob.pe/w/wapS01Alias?ruc=";
        private const string urlinforuc = "http://www.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias?accion=consPorRuc&nroRuc=";
        
        private HttpWebRequest _WebRequest;
        private HttpWebResponse _WebResponse;
        private string _WebSource;
        private Info _Info;
        private bool _ok;
        private string _error;

        //private Resul state;
        //private CookieContainer myCookie;

        private bool LoadWebSource(string url)
        {
            _WebRequest = (HttpWebRequest)WebRequest.Create(url);
            _WebRequest.Proxy = null;

            try
            {
                _WebResponse = (HttpWebResponse)_WebRequest.GetResponse();
            }
            catch
            {
                _ok = false;
                _error = "Error al consultar con Sunat";
                return false;
            }

            Stream _Stream = _WebResponse.GetResponseStream();

            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");


            StreamReader _StreamReader = new StreamReader(_Stream, encode);

            _WebSource = HttpUtility.HtmlDecode(_StreamReader.ReadToEnd());

            return true; 
        }

        private bool ParseInfoContribuyente(List<string> _resul,string ruc)
        {
            try
            {
               // _Info = new Info();
               // _Info.Ruc = ruc;
                _Ruc = ruc;
                
                for (int i = 0; i < _resul.Count; i++)
                {
                    switch (_resul[i])
                    {
                        case "Número Ruc.":
                            _RazonSocial = _resul[i + 2].Substring(14);
                            break;
                        case "Antiguo Ruc.":
                            _AntiguoRuc = _resul[i + 5];
                            break;
                        case "Estado.":
                             _Estado = _resul[i + 2];
                            break;
                        case "Agente Retención IGV.":
                            _EsAgenteRetencion = _resul[i + 3];
                            break;
                        case "Nombre Comercial.":
                            _NombreComercial  = _resul[i + 3];
                            break;
                        case "Dirección.":
                            _Direccion = _resul[i + 3];
                            break;
                        case "Teléfono(s).":
                            _Telefono = _resul[i + 3];
                            break;
                        case "Dependencia.":
                             _Dependencia = _resul[i + 3];
                            break;
                        case "Tipo.":
                            _Tipo= _resul[i + 3];
                            break;
                    }
                }
               
                return true;
            }
            catch
            {
                _ok = false;
                _error = "Error al procesar informacion de sunat(Funcion ParseInfo)";
            }
            return false;
        }

        private void LoadInfoContribuyente(string ruc)
        {
            if (LoadWebSource(String.Format("{0}{1}", urlinforuc, ruc)))
            {

                string[] _split = _WebSource.Split(new char[] { '<', '>' });
                List<string> _resul = new List<string>();

                //quitamos todos los caracteres nulos y convertirmos todo  utf8
                for (int i = 0; i < _split.Length; i++)
                {
                    if (!string.IsNullOrEmpty(_split[i].Trim()))
                        _resul.Add(_split[i].Trim());
                }

                string[] _car = null;

                if (_resul.Count == 34) //no es valido o algo salio mal
                {
                    _ok = false;
                    _error = _resul[15];
                }
                else
                {
                    _car = _resul[14].Split(new char[] { '"' });

                    if (_car[1] == "Resultado")
                    {
                        _ok = true;
                    }
                    else
                    {
                        _ok = false;
                        _error = "El servidor de Sunat no devolvio una respuesta conocida(Funcion LoadInfo)";
                    }
                }

                ParseInfoContribuyente(_resul, ruc);
            }
        }

        #endregion

        #region Constructor

        public DatosSunat()
        {
            //LoadInfoContribuyente(ruc);
            try
            {
                myCookie = null;
                myCookie = new CookieContainer();

                //Permitir SSL
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

                ReadCapcha();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
            
        }

        /// <summary>
        /// Inicia la carga de los datos de la persona 
        /// </summary>
        /// <param name="numRuc"></param>
        /// <param name="ImgCapcha"></param>
        public void GetInfo(string numRUC, string ImgCapcha)
        {
            try
            {
                string myUrl = String.Format("http://www.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias?accion=consPorRuc&nroRuc={0}&codigo={1}", numRUC, ImgCapcha);

                HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(myUrl);
                myWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0";//esto creo que lo puse por gusto :/
                myWebRequest.CookieContainer = myCookie;
                myWebRequest.Credentials = CredentialCache.DefaultCredentials;
                myWebRequest.Proxy = null;

                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse();

                Stream myStream = myHttpWebResponse.GetResponseStream();

                StreamReader myStreamReader = new StreamReader(myStream);

                string _WebSource = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd());

                string[] _split = _WebSource.Split(new char[] { '<', '>', '\n', '\r' });

                List<string> _resul = new List<string>();

                //quitamos todos los caracteres nulos
                for (int i = 0; i < _split.Length; i++)
                {
                    if (!string.IsNullOrEmpty(_split[i].Trim()))
                        _resul.Add(_split[i].Trim());
                }

                // Anlizando la el arreglo "_resul" llegamos a la siguiente conclusion
                // 
                // _resul.Count == 217 cuando nos equivocamos en el captcha
                // _resul.Count == 232 cuando todo salio ok
                // _resul.Count == 222 cuando no existe el DNI
                //

                string[] _car = null;

                switch (_resul.Count)
                {
                    case 217:
                        state = Resul.ErrorCapcha;
                        break;
                    case 232:
                        state = Resul.Ok;
                        break;
                    case 222:
                        state = Resul.NoResul;
                        break;
                    default:
                        state = Resul.Error;
                        break;
                }

                //if (state == Resul.Ok)
                //{
                //    //this._Nombres = _resul[185];
                    //this._ApePaterno = _resul[186];
                    //this._ApeMaterno = _resul[187];

                 //}

                _car = _resul[14].Split(new char[] { '"' });

                if (_car[1] == "Resultado")
                {
                    _ok = true;
                }
                else
                {
                    _ok = false;
                    _error = "El servidor de Sunat no devolvio una respuesta conocida(Funcion LoadInfo)";
                }

                ParseInfoContribuyente(_resul, numRUC);


                myHttpWebResponse.Close();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Public

        public string Error
        {
            get 
            {
                if (_ok)
                    return string.Empty;
                else
                    return _error;
            }
        }

        //public Info GetInfo
        //{
        //    get
        //    {
        //        if (_ok)
        //            return _Info;
        //        else
        //            return null;
        //    }

        //}

        #endregion

        /// <summary>
        /// Carga la imagen Capcha
        /// </summary>
        private Image ReadCapcha()
        {
            try
            {
                HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create("http://www.sunat.gob.pe/cl-ti-itmrconsruc/captcha?accion=image");

                myWebRequest.CookieContainer = myCookie;

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
        /// Inicia la carga de los datos de la persona 
        /// </summary>
        /// <param name="numDni"></param>
        /// <param name="ImgCapcha"></param>
        /// 
    /*
        public void GetInfo2(string numDni, string ImgCapcha)
        {
            try
            {
                string myUrl = String.Format("https://cel.reniec.gob.pe/valreg/valreg.do?accion=buscar&nuDni={0}&imagen={1}", numDni, ImgCapcha);

                HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(myUrl);
                myWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0";//esto creo que lo puse por gusto :/
                myWebRequest.CookieContainer = myCookie;
                myWebRequest.Credentials = CredentialCache.DefaultCredentials;
                myWebRequest.Proxy = null;

                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse();

                Stream myStream = myHttpWebResponse.GetResponseStream();

                StreamReader myStreamReader = new StreamReader(myStream);

                string _WebSource = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd());

                string[] _split = _WebSource.Split(new char[] { '<', '>', '\n', '\r' });

                List<string> _resul = new List<string>();

                //quitamos todos los caracteres nulos
                for (int i = 0; i < _split.Length; i++)
                {
                    if (!string.IsNullOrEmpty(_split[i].Trim()))
                        _resul.Add(_split[i].Trim());
                }

                // Anlizando la el arreglo "_resul" llegamos a la siguiente conclusion
                // 
                // _resul.Count == 217 cuando nos equivocamos en el captcha
                // _resul.Count == 232 cuando todo salio ok
                // _resul.Count == 222 cuando no existe el DNI
                //

                switch (_resul.Count)
                {
                    case 217:
                        state = Resul.ErrorCapcha;
                        break;
                    case 232:
                        state = Resul.Ok;
                        break;
                    case 222:
                        state = Resul.NoResul;
                        break;
                    default:
                        state = Resul.Error;
                        break;
                }

                if (state == Resul.Ok)
                {
                    this._Nombres = _resul[185];
                    this._ApePaterno = _resul[186];
                    this._ApeMaterno = _resul[187];
                }

                myHttpWebResponse.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        */

    }
}
