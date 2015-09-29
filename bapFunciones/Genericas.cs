using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Microsoft.VisualBasic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace bapFunciones
{
    public class Genericas
    {

        public Image CambiarTamanoImagen(Image pImagen, int pAncho, int pAlto)
        {
            //creamos un bitmap con el nuevo tamaño
            Bitmap vBitmap = new Bitmap(pAncho, pAlto);
            //creamos un graphics tomando como base el nuevo Bitmap
            using (Graphics vGraphics = Graphics.FromImage((Image)vBitmap))
            {
                //especificamos el tipo de transformación, se escoge esta para no perder calidad.
                vGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                //Se dibuja la nueva imagen
                vGraphics.DrawImage(pImagen, 0, 0, pAncho, pAlto);
            }
            //retornamos la nueva imagen
            return (Image)vBitmap;
        }


        public string RemoveAccentsWithRegEx(string inputString)
        {
            Regex replace_a_Accents = new Regex("[Á|á|à|ä|â]", RegexOptions.Compiled);
            Regex replace_e_Accents = new Regex("[É|é|è|ë|ê]", RegexOptions.Compiled);
            Regex replace_i_Accents = new Regex("[Í|í|ì|ï|î]", RegexOptions.Compiled);
            Regex replace_o_Accents = new Regex("[Ó|ó|ò|ö|ô]", RegexOptions.Compiled);
            Regex replace_u_Accents = new Regex("[Ú|ú|ù|ü|û]", RegexOptions.Compiled);
            Regex replace_Apostrofe = new Regex("['|´|`]", RegexOptions.Compiled);
            Regex replace_Ampersand = new Regex("[&]", RegexOptions.Compiled);
            inputString = replace_a_Accents.Replace(inputString, "a");
            inputString = replace_e_Accents.Replace(inputString, "e");
            inputString = replace_i_Accents.Replace(inputString, "i");
            inputString = replace_o_Accents.Replace(inputString, "o");
            inputString = replace_u_Accents.Replace(inputString, "u");
            inputString = replace_Apostrofe.Replace(inputString, "");
            inputString = replace_Ampersand.Replace(inputString, "Y");
            return inputString;
        }

        public string RemoveCaracteres(string inputString)
        {
            String replace_A_Accents = "&#193;";
            inputString = inputString.Replace(replace_A_Accents, "Á");
            String replace_E_Accents = "&#201;";
            inputString = inputString.Replace(replace_E_Accents, "É");
            String replace_I_Accents = "&#205;";
            inputString = inputString.Replace(replace_I_Accents, "Í");
            String replace_O_Accents = "&#211;";
            inputString = inputString.Replace(replace_O_Accents, "Ó");
            String replace_U_Accents = "&#218;";
            inputString = inputString.Replace(replace_U_Accents, "Ú");
            String replace_ESP_Accents = "&nbsp;";
            inputString = inputString.Replace(replace_ESP_Accents, " ");

            return inputString;
        }

        public string RemoveAccentsWithNormalization(string inputString)
        {
            string normalizedString = inputString.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < normalizedString.Length; i++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(normalizedString[i]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(normalizedString[i]);
                }
            }
            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }


        //****************************************************************************
        //                            ENCRIPTAR CADENA
        //**********************************oo******************************************
        public string EncryptStr(string S, string P)
        {
            //Encripta una cadena de caracteres.
            //S = Cadena a encriptar
            //P = Password
            string R;
            int C1;
            int C2;
            int maxI;

            R = "";
            if (Equivalencias.Len(P) > 0)
            {
                maxI = Equivalencias.Len(S);
                for (int I = 1; I < maxI; I++)
                {
                    C1 = Equivalencias.Asc(Equivalencias.Mid(S, I, 1));
                    if (I > Equivalencias.Len(P))
                    {
                        C2 = Equivalencias.Asc(Equivalencias.Mid(P, I % Equivalencias.Len(P) + 1, 1));
                    }
                    else
                    {
                        C2 = Equivalencias.Asc(Equivalencias.Mid(P, I, 1));
                    }
                    C1 = C1 + C2 + 64;
                    if (C1 > 255) { C1 = C1 - 256; };
                    R = R + Equivalencias.Chr(C1);
                }

            }
            else
            {
                R = S;
            }
            return R;
        }


        //****************************************************************************
        //                            DESENCRIPTAR CADENA
        //**********************************oo******************************************
        public string UnEncryptStr(string S, string P)
        {
            //Desencripta una cadena de caracteres.
            //S = Cadena a desencriptar
            //P = Password
            string R;
            int C1;
            int C2;
            int maxI;

            R = "";
            if (Equivalencias.Len(P) > 0)
            {
                maxI = Equivalencias.Len(S);
                for (int I = 1; I < maxI; I++)
                {
                    C1 = Equivalencias.Asc(Equivalencias.Mid(S, I, 1));
                    if (I > Equivalencias.Len(P))
                    {
                        C2 = Equivalencias.Asc(Equivalencias.Mid(P, I % Equivalencias.Len(P) + 1, 1));
                    }
                    else
                    {
                        C2 = Equivalencias.Asc(Equivalencias.Mid(P, I, 1));
                    }
                    C1 = C1 - C2 - 64;
                    if (Math.Sign(C1) == -1) { C1 = 256 + C1; }
                    R = R + Equivalencias.Chr(C1);
                }

            }
            else
            {
                R = S;
            }
            return R;
        }


        public bool EsNumerico(string cadena)
        {
            long Dft = 0;
            return long.TryParse(cadena, out Dft);
        }

        //****************************************************************************
        //                               VALIDAR RUC 
        //**********************************oo******************************************
        public bool ValidationRUC(string RUC)
        {
            try
            {
                if (!EsNumerico(RUC))
                {
                    throw new Exception("El valor no es numerico");
                }
                if (RUC.Length != 11)
                {
                    throw new Exception("Numero de digitos invalido");
                }
                int dig01 = Convert.ToInt32(RUC.Substring(0, 1)) * 5;
                int dig02 = Convert.ToInt32(RUC.Substring(1, 1)) * 4;
                int dig03 = Convert.ToInt32(RUC.Substring(2, 1)) * 3;
                int dig04 = Convert.ToInt32(RUC.Substring(3, 1)) * 2;
                int dig05 = Convert.ToInt32(RUC.Substring(4, 1)) * 7;
                int dig06 = Convert.ToInt32(RUC.Substring(5, 1)) * 6;
                int dig07 = Convert.ToInt32(RUC.Substring(6, 1)) * 5;
                int dig08 = Convert.ToInt32(RUC.Substring(7, 1)) * 4;
                int dig09 = Convert.ToInt32(RUC.Substring(8, 1)) * 3;
                int dig10 = Convert.ToInt32(RUC.Substring(9, 1)) * 2;
                int dig11 = Convert.ToInt32(RUC.Substring(10, 1));
                int suma = dig01 + dig02 + dig03 + dig04 + dig05 + dig06 + dig07 + dig08 + dig09 + dig10;
                int residuo = suma % 11;
                int resta = 11 - residuo;
                int digChk = 0;
                if (resta == 10)
                {
                    digChk = 0;
                }
                else if (resta == 11)
                {
                    digChk = 1;
                }
                else
                {
                    digChk = resta;
                }
                if (dig11 == digChk)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //****************************************************************************
        //                               VALIDAR FECHA 
        //****************************************************************************
        public string Md5AddSecret(string strChange)
        {
            //Change the syllable into UTF8 code
            byte[] pass = Encoding.UTF8.GetBytes(strChange);

            MD5 md5 = new MD5CryptoServiceProvider();
            string strPassword = Encoding.UTF8.GetString(md5.ComputeHash(pass));
            return strPassword;
        }

        public string GetMD5(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i <= stream.Length - 1; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }
            return sb.ToString();
        }

        public string Fechahoy()
        {
            object XFECHA = DateTime.Now;
            return (XFECHA.ToString().Substring(6, 2) + ("/" + (XFECHA.ToString().Substring(4, 2) + ("/" + XFECHA.ToString().Substring(0, 4)))));
        }
 
        //****************************************************************************
        //                               VALIDAR FECHA 
        //****************************************************************************
        //valido una fecha
        //espero recibir tres strings con el dia, el mes y el año
        public bool ValidarFecha(string dia, string mes, string ano)
        {
            bool functionReturnValue = false;
            //Dim validarFecha As Boolean
            //elimino posibles espacios a los lados de los números que recibo por parámetro

            dia = dia.Trim();
            mes = mes.Trim();
            ano = ano.Trim();

            //compruebo nº de caracteres que recibo en cada parámetro son los permitidos
            //El año puede tener hasta 4 caracteres

            if (dia.Length == 0 | dia.Length > 2 | mes.Length == 0 | mes.Length > 2 | ano.Length == 0 | ano.Length > 4)
            {
                functionReturnValue = false;
                return functionReturnValue;
            }

            //compruebo que los caracteres de los parámetros son números

            if ((EsNumerico(dia)) | (EsNumerico(mes)) | (EsNumerico(ano)))
            {
                functionReturnValue = false;
                return functionReturnValue;
            }

            //El mes no puede ser mayor que 12 ni menor que 1

            if (Convert.ToInt32(mes) > 12 | Convert.ToInt32(mes) < 1)
            {
                functionReturnValue = false;
                return functionReturnValue;
            }

            //El día no puede ser menor que 1

            if (Convert.ToInt32(dia) < 1)
            {
                functionReturnValue = false;
                return functionReturnValue;
            }

            //El dia, dependiendo del mes que sea, puede tener unos u otros valores


            if (Convert.ToInt32(mes) == 1 | Convert.ToInt32(mes) == 3 | Convert.ToInt32(mes) == 5 | Convert.ToInt32(mes) == 7 | Convert.ToInt32(mes) == 8 | Convert.ToInt32(mes) == 10 | Convert.ToInt32(mes) == 12)
            {
                //en estos meses puede haber 31 dias

                if (Convert.ToInt32(dia) > 31)
                {
                    functionReturnValue = false;
                    return functionReturnValue;
                }

            }
            else if (Convert.ToInt32(mes) == 2)
            {
                //en febrero tenemos que ver si es año bisiesto
                //consigo el numero de año de 4 cifras.
                //si nos dan un valor de 2 cifras < 31 se refiere a 2000 más ese valor

                if (Convert.ToInt32(ano) < 31)
                {
                    ano = ano + 2000;

                    //si nos dan un valor de 2 cifras > 31 se refiere a 1900 más ese valor

                }
                else if (Convert.ToInt32(ano) < 100)
                {
                    ano = ano + 1900;
                }

                //calculo si el año es bisiesto
                //si es divisible por cuatro y (no divisible por 100 o divisible por 400)


                if (((Convert.ToInt32(ano) % 4) == 0) & ((Convert.ToInt32(ano) % 100) != 0 | (Convert.ToInt32(ano) % 400) == 0))
                {
                    //es bisiesto

                    if (Convert.ToInt32(dia) > 29)
                    {
                        functionReturnValue = false;
                        return functionReturnValue;
                    }

                }
                else
                {
                    //NO es bisiesto

                    if (Convert.ToInt32(dia) > 28)
                    {
                        functionReturnValue = false;
                        return functionReturnValue;
                    }
                }

            }
            else
            {
                //en todos los demás meses llegan a tener 30 dias

                if (Convert.ToInt32(dia) > 30)
                {
                    functionReturnValue = false;
                    return functionReturnValue;
                }
            }

            //si estoy aquí es que todas las comprobaciones han sido positivas

            functionReturnValue = true;
            return functionReturnValue;
        }

        //****************************************************************************
        //                    CONVERTIR STRING A FLOAT 
        //****************************************************************************
        public float StringToFloat(string stringVal)
        {
            float singleVal = 0;

            try
            {
                singleVal = System.Convert.ToSingle(singleVal);
                //System.Console.WriteLine("The string as a single is {0}.", _
                //                          singleVal)
            }
            catch (System.OverflowException exception)
            {
                System.Console.WriteLine("Overflow in string-to-single conversion.");
            }
            catch (System.FormatException exception)
            {
                System.Console.WriteLine("The string is not formatted as a Single.");
            }
            catch (System.ArgumentException exception)
            {
                System.Console.WriteLine("The string is null.");
            }

            // Single to string conversion will not overflow.
            stringVal = System.Convert.ToString(singleVal);
            //System.Console.WriteLine("The single as a string is {0}.", _
            //                          stringVal)
            return (singleVal);
        }

        //****************************************************************************
        //                               OBTENER CADENA DE MES 
        //****************************************************************************
        public string get_mesCad(string strmes)
        {
            string get_mes = "";
            //obtener mes en cadena
            switch (strmes)
            {
                case "01":
                    get_mes = "ENERO"; break;
                case "02":
                    get_mes = "FEBRERO"; break;
                case "03":
                    get_mes = "MARZO"; break;
                case "04":
                    get_mes = "ABRIL"; break;
                case "05":
                    get_mes = "MAYO"; break;
                case "06":
                    get_mes = "JUNIO"; break;
                case "07":
                    get_mes = "JULIO"; break;
                case "08":
                    get_mes = "AGOSTO"; break;
                case "09":
                    get_mes = "SEPTIEMBRE"; break;
                case "10":
                    get_mes = "OCTUBRE"; break;
                case "11":
                    get_mes = "NOVIEMBRE"; break;
                case "12":
                    get_mes = "DICIEMBRE"; break;
            }
            return get_mes;
        }

        //*****************************************************************************

        //                               OBTENER NUMERO DE DIAS Y SI ES BISIESTO
        //****************************************************************************
        public Int16 NumDias(int mes, int anno)
        {
            /*
            Los meses 1,3,5,7,8,10,12 siempre tienen 31 días
            Los meses 4,6,9,11 siempre tienen 30 días
            El único problema es el mes de febrero dependiendo del año puede tener 28 o 29 días
            */
            if ((mes == 1) || (mes == 3) || (mes == 5) || (mes == 7) || (mes == 8) || (mes == 10) || (mes == 12))
            {
                return 31;
            }
            else if ((mes == 4) || (mes == 6) || (mes == 9) || (mes == 11))
            {
                return 30;
            }
            else if (mes == 2)
            {
                if ((anno % 4 == 0) && (anno % 100 != 0) || (anno % 400 == 0))
                {
                    return 29;
                }
                else
                {
                    return 28;
                }
            }
            else
            {
                return 28;
            }

        }
        //**************************************************************************

        #region *** validar fecha en formato correcto
        public DateTime fecha(DateTime pfecha)
        {
            DateTime lfech;

            if (pfecha != null)
            {
                if (pfecha.ToString().Substring(0, 10) != "01/01/0001")
                {
                    lfech = pfecha;
                }
                else
                {
                    lfech = Convert.ToDateTime("01/01/1900");
                }
            }
            else
            {
                lfech = Convert.ToDateTime("01/01/1900");
            }
            return (lfech);
        }
        #endregion

        //' Constantes Para Roleo de Registros
        public static string toprecord = "TOP";//toprecord
        public static string bottrecord = "BOTT";//bottrecord
        public static string nextrecord = "SKIP+";//nextrecord
        public static string prevrecord = "SKIP-";//prevrecord

        #region *** Variables de recorrido de documentos(registros)
        public static string primero = "primero";//toprecord
        public static string anterior = "anterior";//bottrecord
        public static string siguiente = "siguiente";//nextrecord
        public static string ultimo = "ultimo";//prevrecord
        #endregion
    }
}
