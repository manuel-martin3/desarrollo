using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace bapFunciones
{
    public static class RandomHelper
    {
        public static Random random = new Random();
        public static char GerRandomChar()
        {
            return Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
        }
        public static string GetRandomString()
        {
            return GetRandomString(5 + random.Next(20));
        }
        public static string GetRandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 1; i < size; i++)
            {
                ch = GerRandomChar();
                builder.Append(ch);
            }
            return GerRandomChar() + builder.ToString().ToLower();
        }
    }
}
