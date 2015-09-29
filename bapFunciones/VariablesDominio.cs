using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bapFunciones
{
    public static class VariablesDominio
    {
        public static class VarContabilidad
        {
            private static String _Moduloid = "0110";
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
        }

        public static class VarCompras
        {
            private static String _Moduloid = "0120";
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
        }

        public static class VarVentas
        {
            private static String _Moduloid = "0130";
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
        }

        public static class VarTesoreria
        {
            private static String _Moduloid = "0140";
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
        }

        public static class VarComercial
        {
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
        }

        public static class VarActivoFijo
        {
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
        }

        public static class VarLogistica
        {
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
        }

        public static class VarSeguridad
        {
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
        }

        public static class VarRecursosHumanos
        {
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
        }
    }
}
