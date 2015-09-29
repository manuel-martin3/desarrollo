using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml;

namespace LayerBusinessEntities
{
    public class tb_ad_movimientostarj
    {
        public String moduloid{ get; set; }
        public String local{ get; set; }
        public String tipodoc{ get; set; }
        public String serdoc{ get; set; }
        public String numdoc{ get; set; }
        public Int32 tarjetaid{ get; set; }
        public String tarjnumoper{ get; set; }
        public String moneda{ get; set; }
        public Decimal tcamb{ get; set; }
        public Decimal tarjimporte{ get; set; }
        public String status{ get; set; }
        public String usuar{ get; set; }
        public DateTime fecre{ get; set; }
        public DateTime feact { get; set; }
        public String posicion { get; set; }
        /**/
    }
}
