using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LayerBusinessEntities
{
    public class tb_cxc_vendor
    {
        public String vendorid { get; set; }
        public String vendorname { get; set; }
        public String ddnni { get; set; }
        public String nmruc { get; set; }
        public String canalventaid { get; set; }
        public String direccion { get; set; }
        public DateTime? fech_ingre { get; set; }
        public DateTime? fech_cese { get; set; }
        public String motivocese { get; set; }
        public String telefono { get; set; }
        public String usuarweb { get; set; }
        public String status { get; set; }
        public String posicion { get; set; }
        public String parameters { get; set; }
    }
}
