using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LayerBusinessEntities
{
    public class tb_cxc_pedidodet
    {
        public String tipdoc { get; set; }
        public String serdoc { get; set; }
        public String numdoc { get; set; }
        public String articid { get; set; }
        public String artididold { get; set; }
        public String colorid { get; set; }
        public String tallaid { get; set; }
        public String coltalla { get; set; }
        public Decimal cantidad { get; set; }
        public Decimal precbruto { get; set; }
        public Decimal impobruto { get; set; }
        public Decimal precneto { get; set; }
        public Decimal imponeto { get; set; }
        public String usuar { get; set; }
        public DateTime fecre { get; set; }
        public DateTime feact { get; set; }

    }
}
