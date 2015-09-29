using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_co_motivodeltraslado
    {
        private String _motivotrasladoid;
        public String motivotrasladoid
        {
            get { return _motivotrasladoid; }

            set { _motivotrasladoid = value; }
        }

        private String _motivotrasladoname;
        public String motivotrasladoname
        {
            get { return _motivotrasladoname; }

            set { _motivotrasladoname = value; }
        }

        private String _usuar;
        public String usuar
        {
            get { return _usuar; }

            set { _usuar = value; }
        }
    }
}
