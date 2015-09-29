using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace LayerBusinessEntities
{
    public class tb_co_tributoafectocompras
    {       
        private String _destinoid;
        public String destinoid
        {
            get { return _destinoid; }

            set { _destinoid = value; }
        }

        private String _destinoname;
        public String destinoname
        {
            get { return _destinoname; }

            set { _destinoname = value; }
        }

        private Boolean? _destinoafecto; 
        public Boolean? destinoafecto{ 
        get { return _destinoafecto; }

        set { _destinoafecto = value; }
   }

        private Boolean? _destinoafecto1; 
        public Boolean? destinoafecto1{ 
        get { return _destinoafecto1; }

        set { _destinoafecto1 = value; }
   }

        private Boolean? _destinodaot; 
        public Boolean? destinodaot{ 
        get { return _destinodaot; }

        set { _destinodaot = value; }
   }
    }
}
