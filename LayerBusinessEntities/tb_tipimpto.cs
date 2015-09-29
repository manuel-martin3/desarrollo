using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace LayerBusinessEntities
{
    public class tb_tipimpto
    {

        private String _tipimptoid;
        public String tipimptoid
        {
            get { return _tipimptoid; }

            set { _tipimptoid = value; }
        }

        private String _tipimptotasa;
        public String tipimptotasa
        {
            get { return _tipimptotasa; }

            set { _tipimptotasa = value; }
        }

        private Boolean _status;
        public Boolean status
        {
            get { return _status; }

            set { _status = value; }
        }

    }
}
