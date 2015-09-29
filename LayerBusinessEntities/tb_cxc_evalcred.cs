using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LayerBusinessEntities
{
    public class tb_cxc_evalcred
    {
        public String ctacte { get; set; }
        public String ctactename { get; set; }
        public String item { get; set; }
        public String tipdoc { get; set; }
        public String serdoc { get; set; }
        public String numdoc { get; set; }
        public Boolean es_persjuridica { get; set; }
        public Boolean copia_constitucionempresa { get; set; }
        public Boolean copia_ruc { get; set; }
        public Boolean copia_dni { get; set; }
        public Boolean lic_func { get; set; }
        public Boolean titulo_localcom { get; set; }
        public Boolean contra_localcom { get; set; }
        public Boolean recibo_agualuz { get; set; }
        public Boolean tiene_letraprotestada { get; set; }
        public Boolean tiene_morosidad { get; set; }
        public Boolean moroso_infocorp { get; set; }
        public String refe_comerc { get; set; }
        public String refe_banca { get; set; }
        public Boolean bienes_bienmueble { get; set; }
        public Boolean bienes_inmuebles { get; set; }
        public int puntaje { get; set; }
        public String eval_cxcob { get; set; }
        public String obs_cxcob { get; set; }
        public String aprob_gerencial { get; set; }
        public String obs_gerencial { get; set; }
        public String usuar { get; set; }
        public DateTime? fecre { get; set; }
        public DateTime? feact { get; set; }
        public String filtro { get; set; }
        public String posicion { get; set; }
        public String vendorid { get; set; }
        public String vendorname { get; set; }
        public String status { get; set; }

        // Variables de  la Tabla Estado
        public String aprob_status { get; set; }
        public String descripcion { get; set; }
        public String canalventaid { get; set; }



    }
}
