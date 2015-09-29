using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;

namespace bapFunciones
{
    public class ValidarRuc
    {
        [DebuggerNonUserCode]
        public static bool validarRuc(string ruc)
        {
            bool flag = !ValidarRuc.VAL_RUC(ruc);
            return !flag;
        }
        private static string LeftC(string str, int Length)
        {
            int LenT = str.Length;
            bool flag = LenT <= Length;
            string LeftC;
            if (flag)
            {
                LeftC = str;
            }
            else
            {
                LeftC = str.Substring(0, Length);
            }
            return LeftC;
        }
        private static string RightC(string str, int Length)
        {
            int LenT = str.Length;
            bool flag = LenT <= Length;
            string RightC;
            if (flag)
            {
                RightC = str;
            }
            else
            {
                RightC = str.Substring(checked(LenT - Length));
            }
            return RightC;
        }
        private static bool VAL_RUC(string ruc)
        {
            int[] FACTOR = new int[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            int suma = 0;
            bool flag = !Versioned.IsNumeric(ruc);
            checked
            {
                bool VAL_RUC;
                if (flag)
                {
                    VAL_RUC = false;
                }
                else
                {
                    flag = (ruc.Length != 11);
                    if (flag)
                    {
                        VAL_RUC = false;
                    }
                    else
                    {
                        string[] VAL_DIGIT = new string[] { "20", "17", "15", "10" };
                        string DIGIT = ValidarRuc.LeftC(ruc, 2);
                        Array.Sort<string>(VAL_DIGIT);
                        flag = (Array.BinarySearch<string>(VAL_DIGIT, DIGIT) < 0);
                        if (flag)
                        {
                            VAL_RUC = false;
                        }
                        else
                        {
                            int arg_E0_0 = 0;
                            int num = ruc.Length - 2;
                            int I = arg_E0_0;
                            while (true)
                            {
                                int arg_10B_0 = I;
                                int num2 = num;
                                if (arg_10B_0 > num2)
                                {
                                    break;
                                }
                                suma += int.Parse(ruc.Substring(I, 1)) * FACTOR[I];
                                I++;
                            }
                            int residuo = suma % 11;
                            int resta = 11 - residuo;
                            flag = (resta == 10);
                            int digChk;
                            if (flag)
                            {
                                digChk = 0;
                            }
                            else
                            {
                                flag = (resta == 11);
                                if (flag)
                                {
                                    digChk = 1;
                                }
                                else
                                {
                                    digChk = resta;
                                }
                            }
                            flag = ((double)digChk == Conversions.ToDouble(ValidarRuc.RightC(ruc, 1)));
                            VAL_RUC = flag;
                        }
                    }
                }
                return VAL_RUC;
            }
        }
        public static int getDigito(string nro)
        {
            int[] FACTOR = new int[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            int suma = 0;
            int arg_4E_0 = 0;
            checked
            {
                int num = nro.Length - 1;
                int I = arg_4E_0;
                while (true)
                {
                    int arg_79_0 = I;
                    int num2 = num;
                    if (arg_79_0 > num2)
                    {
                        break;
                    }
                    suma += int.Parse(nro.Substring(I, 1)) * FACTOR[I];
                    I++;
                }
                int residuo = suma % 11;
                int resta = 11 - residuo;
                bool flag = resta == 10;
                int digChk;
                if (flag)
                {
                    digChk = 0;
                }
                else
                {
                    flag = (resta == 11);
                    if (flag)
                    {
                        digChk = 1;
                    }
                    else
                    {
                        digChk = resta;
                    }
                }
                return digChk;
            }
        }
    }
}
