using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LayerBusinessEntities
{
    public class tb_cxc_cronoPagos
    {
        public String tipdoc { get; set; }
        public String serdoc { get; set; }
        public String numdoc { get; set; }
        public String item { get; set; }
        public String num_interno { get; set; }
        public String num_unico { get; set; }
        public Decimal monto { get; set; }
        public DateTime fechven { get; set; }
        public String usuar { get; set; }
        public DateTime? fecre { get; set; }
        public DateTime? feact { get; set; }
    }
}
