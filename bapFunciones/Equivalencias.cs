using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace bapFunciones
{
    /// <summary>
    /// Funciones con equivalencias de VB a C#
    /// </summary>
    static public class Equivalencias
    {
        /// <summary>
        /// Comprueba si el parámetro es de tipo DateTime
        /// </summary>
        /// <typeparam name="T">
        /// El tipo de datos a comprobar
        /// </typeparam>
        /// <param name="fecha">
        /// El valor a comprobar si es una fecha válida
        /// </param>
        /// <returns>
        /// Un valor verdadero o falso según el parámetro sea una fecha
        /// </returns>
        static public bool IsDate<T>(T fecha) //where T: IConvertible
        {
            // Si no queremos aceptar como válido un valor nulo
            // ya que Convert.ToDateTime devolverá DateTime.MinValue
            // cuando el parámetro es null
            if (fecha == null)
            {
                return false;
            }
#if DEBUG
            Console.WriteLine("    El tipo de fecha es: {0}", fecha.GetType().Name);
#endif

            // Aportación de Harvey Triana con fecha 11/Ago/2007
            // en el grupo de noticias microsoft.public.es.csharp
            if (fecha is DateTime)
            {
                return true;
            }

            try
            {
                DateTime fecha1 = Convert.ToDateTime(fecha);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Comprueba si el parámetro es un número
        /// </summary>
        /// <typeparam name="T">
        /// El tipo de datos a comprobar
        /// </typeparam>
        /// <param name="numero">
        /// El valor a comprobar si es un número
        /// </param>
        /// <returns>
        /// Un valor verdadero o falso según el parámetro sea un número,
        /// en realidad se comprueba si es convertible a Double.
        /// </returns>
        static public bool IsNumeric<T>(T numero) //where T : IConvertible
        {
            // Si es un valor nulo, devolver directamente true
            if (numero == null)
            {
                return true;
            }
#if DEBUG
            Console.WriteLine("    El tipo de numero es: {0}", numero.GetType().Name);
#endif
            // Salvo excepciones, todos los números se pueden convertir a Double
            try
            {
                double num = Convert.ToDouble(numero);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// El valor numérico ASCII del carácter indicado
        /// </summary>
        /// <param name="valor">
        /// El valor de tipo Char a convertir en número ASCII
        /// </param>
        /// <returns>
        /// El valor entero del carácter indicado
        /// </returns>
        static public int Asc(char valor)
        {
            return (int)valor;
        }

        /// <summary>
        /// El valor numérico ASCII de la cadena indicada
        /// (se comprobará el primer carácter de la cadena)
        /// </summary>
        /// <param name="valor">
        /// El valor de tipo String a convertir a número ASCII
        /// </param>
        /// <returns>
        /// El valor entero del primer carácter de la cadena indicada
        /// </returns>
        static public int Asc(string valor)
        {
            if (string.IsNullOrEmpty(valor) || valor.Length < 1)
                return 0;

            return (int)valor[0];
        }

        /// <summary>
        /// Convierte un número en un Char
        /// </summary>
        /// <param name="valor">
        /// El valor numérico a convertir
        /// </param>
        /// <returns>
        /// El valor de tipo Char del número indicado
        /// </returns>
        static public char ChrW(int valor)
        {
            return (char)valor;
        }

        /// <summary>
        /// Convierte un número en un Char
        /// </summary>
        /// <param name="valor">
        /// El valor numérico a convertir
        /// </param>
        /// <returns>
        /// El valor de tipo Char del número indicado
        /// </returns>
        static public char Chr(int valor)
        {
            return (char)valor;
        }

        //---------------------------------------------------------------------
        // Funciones de manipulación de cadenas
        //---------------------------------------------------------------------

        /// <summary>
        /// Devuelve la longitud de <paramref name="cadena"/>
        /// (si es un valor nulo devolverá cero)
        /// </summary>
        /// <param name="cadena">
        /// La cadena de la que se quiere averiguar el tamaño
        /// </param>
        /// <returns>
        /// La cantidad de caracteres de la cadena o cero si es nulo
        /// </returns>
        static public int Len(string cadena)
        {
            if (string.IsNullOrEmpty(cadena))
                return 0;
            return cadena.Length;
        }

        /// <summary>
        /// Devuelve la posición de la cadena2 en cadena1
        /// empezando por el carácter en la posición start
        /// (por compatibilidad con Visual Basic,
        /// la posición del primer carácter se considera que es 1)
        /// </summary>
        /// <param name="start">
        /// La posición del carácter (en base 1)
        /// a partir del que se comprobará
        /// </param>
        /// <param name="cadena1">
        /// La cadena en la que se hará la búsqueda
        /// </param>
        /// <param name="cadena2">
        /// La cadena que queremos comprobar si está en la primera
        /// </param>
        /// <param name="binaria">
        /// True si se diferencian las mayúsculas de minúsculas
        /// </param>
        /// <returns>
        /// Devuelve la posición de cadena2 en cadena1.
        /// Si la cadena no existe devuelve cero
        /// </returns>
        static public int InStr(int start, string cadena1, string cadena2, bool binaria)
        {
            if (string.IsNullOrEmpty(cadena1) ||
                string.IsNullOrEmpty(cadena2) ||
                start > cadena1.Length)
            {
                return 0;
            }
            // Restar uno a la posición y usar cero si es menor de cero
            if (--start < 0)
                start = 0;

            if (binaria)
            {
                return cadena1.IndexOf(cadena2, start) + 1;
            }
            else
            {
                return cadena1.IndexOf(cadena2, start,
                    StringComparison.CurrentCultureIgnoreCase) + 1;
            }
        }

        /// <summary>
        /// Devuelve la posición de la cadena2 en cadena1
        /// empezando por el carácter en la posición start
        /// (por compatibilidad con Visual Basic,
        /// la posición del primer carácter se considera que es 1)
        /// </summary>
        /// <param name="start">
        /// La posición del carácter (en base 1)
        /// a partir del que se comprobará
        /// </param>
        /// <param name="cadena1">
        /// La cadena en la que se hará la búsqueda
        /// </param>
        /// <param name="cadena2">
        /// La cadena que queremos comprobar si está en la primera
        /// </param>
        /// <returns>
        /// Devuelve la posición con índice 1 de cadena2 dentro de cadena1,
        /// comprobando desde el carácter de la posición start.
        /// Si no está, devolverá cero.
        /// </returns>
        static public int InStr(int start, string cadena1, string cadena2)
        {
            return InStr(start, cadena1, cadena2, true);
        }

        /// <summary>
        /// Devuelve la posición de la cadena2 en cadena1
        /// empezando por el primer carácter
        /// (por compatibilidad con Visual Basic,
        /// la posición del primer carácter se considera que es 1)
        /// </summary>
        /// <param name="cadena1">
        /// La cadena en la que se hará la búsqueda
        /// </param>
        /// <param name="cadena2">
        /// La cadena que queremos comprobar si está en la primera
        /// </param>
        /// <param name="binaria">
        /// True si se diferencian las mayúsculas de minúsculas
        /// </param>
        /// <returns>
        /// Devuelve la posición de cadena2 en cadena1.
        /// Si la cadena no existe devuelve cero
        /// </returns>
        static public int InStr(string cadena1, string cadena2, bool binaria)
        {
            return InStr(1, cadena1, cadena2, binaria);
        }

        /// <summary>
        /// Devuelve la posición de la cadena2 en cadena1
        /// (por compatibilidad con Visual Basic,
        /// la posición del primer carácter se considera que es 1)
        /// </summary>
        /// <param name="cadena1">
        /// La cadena en la que se hará la búsqueda
        /// </param>
        /// <param name="cadena2">
        /// La cadena que queremos comprobar si está en la primera
        /// </param>
        /// <returns>
        /// Devuelve la posición con índice 1 de cadena2 dentro de cadena1.
        /// Si no está, devolverá cero.
        /// </returns>
        static public int InStr(string cadena1, string cadena2)
        {
            return InStr(1, cadena1, cadena2);
        }

        /// <summary>
        /// Devuelve la posición de <paramref name="cadena2"/>
        /// dentro de <paramref name="cadena1"/>
        /// empezando por el caracter de la posición <paramref name="start"/>
        /// (se comprueba desde el final de la cadena)
        /// </summary>
        /// <param name="start">
        /// La posición del carácter (en base 1)
        /// a partir del que se comprobará
        /// </param>
        /// <param name="cadena1">
        /// La cadena en la que se hará la búsqueda
        /// </param>
        /// <param name="cadena2">
        /// La cadena que queremos comprobar si está en la primera
        /// </param>
        /// <param name="binaria">
        /// True si se diferencian las mayúsculas de minúsculas
        /// </param>
        /// <returns>
        /// Devuelve la posición de cadena2 en cadena1.
        /// Si la cadena no existe devuelve cero
        /// </returns>
        static public int InStrRev(int start, string cadena1, string cadena2, bool binaria)
        {
            if (string.IsNullOrEmpty(cadena1) ||
                string.IsNullOrEmpty(cadena2) ||
                start > cadena1.Length)
            {
                return 0;
            }
            // Restar uno a la posición y usar cero si es menor de cero
            if (--start < 0)
                start = 0;
            // Si se hace comparación binaria o no
            if (binaria)
            {
                return cadena1.LastIndexOf(cadena2, start) + 1;
            }
            else
            {
                return cadena1.LastIndexOf(cadena2, start,
                    StringComparison.CurrentCultureIgnoreCase) + 1;
            }
        }





        public static int CountStringOccurrences(string pattern , string text)
        {
            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }
            return count;
        }
       


        /// <summary>
        /// Devuelve la posición de <paramref name="cadena2"/>
        /// dentro de <paramref name="cadena1"/>
        /// empezando por el caracter de la posición <paramref name="start"/>
        /// (se comprueba desde el final de la cadena)
        /// </summary>
        /// <param name="start">
        /// La posición del carácter (en base 1)
        /// a partir del que se comprobará
        /// </param>
        /// <param name="cadena1">
        /// La cadena en la que se hará la búsqueda
        /// </param>
        /// <param name="cadena2">
        /// La cadena que queremos comprobar si está en la primera
        /// </param>
        /// <returns>
        /// Devuelve la posición de cadena2 en cadena1.
        /// Si la cadena no existe devuelve cero
        /// </returns>
        static public int InStrRev(int start, string cadena1, string cadena2)
        {
            return InStrRev(start, cadena1, cadena2, true);
        }

        /// <summary>
        /// Devuelve la posición de <paramref name="cadena2"/>
        /// dentro de <paramref name="cadena1"/>
        /// empezando por el último carácter
        /// (se comprueba desde el final de la cadena)
        /// </summary>
        /// <param name="cadena1">
        /// La cadena en la que se hará la búsqueda
        /// </param>
        /// <param name="cadena2">
        /// La cadena que queremos comprobar si está en la primera
        /// </param>
        /// <returns>
        /// Devuelve la posición de cadena2 en cadena1.
        /// Si la cadena no existe devuelve cero
        /// </returns>
        static public int InStrRev(string cadena1, string cadena2)
        {
            return InStrRev(1, cadena1, cadena2);
        }

        /// <summary>
        /// Devuelve los primeros caracteres de la cadena
        /// </summary>
        /// <param name="cadena">
        /// La cadena de la que se obtendrán los caracteres
        /// </param>
        /// <param name="length">
        /// El total de caracteres a devolver
        /// </param>
        /// <returns>
        /// Devuelve una cadena con los primeros length caracteres
        /// </returns>
        static public string Left(string cadena, int length)
        {
            if (string.IsNullOrEmpty(cadena) || length < 1)
                return "";

            // Comprobar que no nos pasamos
            if (length > cadena.Length)
            {
                length = cadena.Length;
            }
            return cadena.Substring(0, length);
        }

        /// <summary>
        /// Devuelve los últimos <paramref name="length"/> caracteres de la cadena
        /// </summary>
        /// <param name="cadena">
        /// La cadena de la que se obtendrán los caracteres
        /// </param>
        /// <param name="length">
        /// El total de caracteres a devolver
        /// </param>
        /// <returns>
        /// Devuelve una cadena con los últimos length caracteres
        /// </returns>
        static public string Right(string cadena, int length)
        {
            if (string.IsNullOrEmpty(cadena) || length < 1)
                return "";

            int n = cadena.Length;
            // Comprobar que no nos pasamos
            if (length > n)
            {
                length = n;
            }
            return cadena.Substring(n - length, length);
        }

        /// <summary>
        /// Devuelve <paramref name="length"/> caracteres de la cadena indicada 
        /// empezando por el carácter de la posición <paramref name="start"/>
        /// </summary>
        /// <param name="cadena">
        /// La cadena de la que se obtendrán los caracteres
        /// </param>
        /// <param name="start">
        /// Posición de inicio (en base 1) desde donde se tomará la cadena
        /// </param>
        /// <param name="length">
        /// Número de caracteres que se devolverán
        /// </param>
        /// <returns></returns>
        static public string Mid(string cadena, int start, int length)
        {
            if (string.IsNullOrEmpty(cadena) || length < 1 || start > cadena.Length)
                return "";
            // Comprobar que no nos pasamos
            if (length > cadena.Length - start)
            {
                length = cadena.Length - start + 1;
            }
            return cadena.Substring(start - 1, length);
        }

        /// <summary>
        /// Devuelve los caracteres desde la posición <paramref name="start"/>
        /// </summary>
        /// <param name="cadena">
        /// La cadena de la que se obtendrán los caracteres
        /// </param>
        /// <param name="start">
        /// Posición desde la que se devolverá la cadena
        /// </param>
        /// <returns></returns>
        static public string Mid(string cadena, int start)
        {
            if (string.IsNullOrEmpty(cadena))
                return "";

            return Mid(cadena, start, cadena.Length);
        }

        /// <summary>
        /// Sustituye en <paramref name="cadena"/> 
        /// los caracteres indicados desde <paramref name="start"/>
        /// con una longitud de <paramref name="length"/> y pone
        /// el contenido de <paramref name="cadena2"/>
        /// </summary>
        /// <param name="cadena">
        /// La cadena a la que se asignarán los caracteres
        /// </param>
        /// <param name="cadena2">
        /// La cadena a poner en cadena1
        /// </param>
        /// <param name="start">
        /// Posición desde la que se devolverá la cadena
        /// </param>
        /// <param name="length"></param>
        static public void Mid(ref string cadena, string cadena2, int start, int length)
        {
            if (string.IsNullOrEmpty(cadena))
            {
                throw new ArgumentNullException("cadena",
                        "La cadena de destino no puede tener un valor nulo.");
            }
            int n = cadena.Length;
            if (start >= n)
            {
                throw new ArgumentOutOfRangeException("start",
                        "La posición de inicio debe estar dentro de la cadena original.");
            }
            cadena = Left(Left(cadena, start - 1) +
                     Left(cadena2, length) + Mid(cadena, start + length), n);
        }

        /// <summary>
        /// Sustituye en <paramref name="cadena"/> 
        /// los caracteres indicados desde <paramref name="start"/>
        /// con una longitud de <paramref name="length"/> y pone
        /// el contenido de <paramref name="cadena2"/>
        /// </summary>
        /// <param name="cadena">
        /// La cadena a la que se asignarán los caracteres
        /// </param>
        /// <param name="start">
        /// Posición desde la que se devolverá la cadena
        /// </param>
        /// <param name="length">
        /// El número de caracteres que se sustituirán
        /// </param>
        /// <param name="cadena2">
        /// La cadena a poner en cadena1
        /// </param>
        static public void Mid(ref string cadena, int start, int length, string cadena2)
        {
            Mid(ref cadena, cadena2, start, length);
        }

        /// <summary>
        /// Sustituye en <paramref name="cadena"/> 
        /// los caracteres indicados desde <paramref name="start"/>
        /// y pone el contenido de <paramref name="cadena2"/>
        /// </summary>
        /// <param name="cadena">
        /// La cadena a la que se asignarán los caracteres
        /// </param>
        /// <param name="cadena2">
        /// La cadena a poner en cadena1
        /// </param>
        /// <param name="start">
        /// Posición desde la que se devolverá la cadena
        /// </param>
        static public void Mid(ref string cadena, string cadena2, int start)
        {
            Mid(ref cadena, start, cadena2);
        }

        /// <summary>
        /// Sustituye en <paramref name="cadena"/> 
        /// los caracteres indicados desde <paramref name="start"/>
        /// y pone el contenido de <paramref name="cadena2"/>
        /// </summary>
        /// <param name="cadena">
        /// La cadena a la que se asignarán los caracteres
        /// </param>
        /// <param name="start">
        /// Posición desde la que se devolverá la cadena
        /// </param>
        /// <param name="cadena2">
        /// La cadena a poner en cadena1
        /// </param>
        static public void Mid(ref string cadena, int start, string cadena2)
        {
            Mid(ref cadena, cadena2, start, cadena2.Length);
        }

        static public int Val(string value)
        {
            string returnVal = string.Empty;
            MatchCollection collection = Regex.Matches(value, "\\d+");
            foreach (Match match in collection)
            {
                returnVal += match.ToString();
            }
            return Convert.ToInt32(returnVal);
        }

        //static public int Val(string value)
        //{
        //    string returnVal = string.Empty;
        //    int tryInt = 0;

        //    // specifies that the match has to start at the start of the string
        //    //Trim() trims both ends of the string before matching

        //    MatchCollection collection = Regex.Matches(value.Trim(), "^\\d+");

        //    foreach (Match match in collection)
        //    {
        //        returnVal += match.ToString();
        //    }
        //    return (int)returnVal;
        //}


        //static public string Replace(string input, string replacement)
        //{
        //    string errString = "This docment uses 3 other docments to docment the docmentation";

        //    Console.WriteLine("The original string is:{0}'{1}'{0}", Environment.NewLine, errString);

        //    // Correct the spelling of "document".

        //    string correctString = errString.Replace("docment", "document");

        //    Console.WriteLine("After correcting the string, the result is:{0}'{1}'", Environment.NewLine, correctString);
        //}

        #region "validacion"
        public static bool isNull(Object obj)
        {

            if (obj == null)
            {
                return true;
            }
            return false;
        }
        public static bool isEmpaty(Object obj)
        {
            if (!isNull(obj))
            {
                if (obj.Equals("")||obj.ToString().Length==0)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool getbool(Object obj)
        {
            if (!isNull(obj))
            {
                if (!isEmpaty(obj))
                {
                    return true;
                }
            }
            return false;

        }

        public static string getValue(Object obj)
        {
            if (!isNull(obj))
            {
                if (!isEmpaty(obj))
                {
                    return obj.ToString();
                }
            }
            return "";

        }

        public static Decimal getDecimal(Object obj)
        {
            if (!isNull(obj))
            {
                if (!isEmpaty(obj))
                {
                    return Convert.ToDecimal (obj);
                }
            }
            return 0;

        }

        public static int getInt(Object obj)
        {
            if (!isNull(obj))
            {
                if (!isEmpaty(obj))
                {
                    return int.Parse(obj.ToString());
                }
            }
            return 0;

        }

        #endregion


    }
}
