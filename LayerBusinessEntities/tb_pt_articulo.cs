using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_pt_articulo
{

    public Boolean top { get; set; }

   private String _articid; 
   public String articid{ 
       get { return _articid; }

       set { _articid = value; }
   }

   private String _articidold; 
   public String articidold{ 
       get { return _articidold; }

       set { _articidold = value; }
   }

   private String _nivel;
   public String nivel
   {
       get { return _nivel; }
       set { _nivel = value; }
   }

   private String _filtro;
   public String filtro
   {
       get { return _filtro; }
       set { _filtro = value; }
   }

   private String _procedenciaid;
   public String procedenciaid
   {
       get { return _procedenciaid; }
       set { _procedenciaid = value; }
   }

   private String _docname;
   public String docname
   {
       get { return _docname; }
       set { _docname = value; }
   }

   private String _articname; 
   public String articname{ 
       get { return _articname; }

       set { _articname = value; }
   }

   private String _articdsav; 
   public String articdsav{ 
       get { return _articdsav; }

       set { _articdsav = value; }
   }

   private String _coleccionid;
   public String coleccionid
   {
       get { return _coleccionid; }
       set { _coleccionid = value; }
   }

   private String _subcoleccionid;
   public String subcoleccionid
   {
       get { return _subcoleccionid; }
       set { _subcoleccionid = value; }
   }


   private Decimal _preccosto;
   public Decimal preccosto
   {
       get { return _preccosto; }
       set { _preccosto = value; }
   }

   private Decimal _real_costo;
   public Decimal real_costo
   {
       get { return _real_costo; }
       set { _real_costo = value; }
   }

   private Decimal _precventa_cre_mayor; 
   public Decimal precventa_cre_mayor{ 
       get { return _precventa_cre_mayor; }

       set { _precventa_cre_mayor = value; }
   }

   private Decimal _precventa_cre_menor; 
   public Decimal precventa_cre_menor{ 
       get { return _precventa_cre_menor; }

       set { _precventa_cre_menor = value; }
   }

   private Decimal _precventa_tda_mayor; 
   public Decimal precventa_tda_mayor{ 
       get { return _precventa_tda_mayor; }

       set { _precventa_tda_mayor = value; }
   }

   private Decimal _precventa_tda_menor; 
   public Decimal precventa_tda_menor{ 
       get { return _precventa_tda_menor; }

       set { _precventa_tda_menor = value; }
   }

   private Decimal _precventa_csc_mayor; 
   public Decimal precventa_csc_mayor{ 
       get { return _precventa_csc_mayor; }

       set { _precventa_csc_mayor = value; }
   }

   private Decimal _precventa_csc_menor; 
   public Decimal precventa_csc_menor{ 
       get { return _precventa_csc_menor; }

       set { _precventa_csc_menor = value; }
   }

   private String _categoriaid; 
   public String categoriaid{ 
       get { return _categoriaid; }

       set { _categoriaid = value; }
   }

   private String _marcaid; 
   public String marcaid{ 
       get { return _marcaid; }

       set { _marcaid = value; }
   }

   private String _marcaidold;
   public String marcaidold
   {
       get { return _marcaidold; }
       set { _marcaidold = value; }
   }

   private String _marcaname;
   public String marcaname
   {
       get { return _marcaname; }

       set { _marcaname = value; }
   }

   private String _lineaid; 
   public String lineaid{ 
       get { return _lineaid; }

       set { _lineaid = value; }
   }

   private String _lineaidold;
   public String lineaidold
   {
       get { return _lineaidold; }
       set { _lineaidold = value; }
   }

   private String _lineaname;
   public String lineaname
   {
       get { return _lineaname; }

       set { _lineaname = value; }
   }

   private String _generoid; 
   public String generoid{ 
       get { return _generoid; }

       set { _generoid = value; }
   }

   private String _generoid2;
   public String generoid2
   {
       get { return _generoid2; }
       set { _generoid2 = value; }
   }

   private String _generoname;
   public String generoname
   {
       get { return _generoname; }

       set { _generoname = value; }
   }

   private String _tejidoid; 
   public String tejidoid{ 
       get { return _tejidoid; }

       set { _tejidoid = value; }
   }

   private String _telaid; 
   public String telaid{ 
       get { return _telaid; }

       set { _telaid = value; }
   }

   private String _botapieid;
   public String botapieid
   {
       get { return _botapieid; }

       set { _botapieid = value; }
   }

   private String _entalleid;
   public String entalleid
   {
       get { return _entalleid; }

       set { _entalleid = value; }
   }

   private String _familiatelaid;
   public String familiatelaid
   {
       get { return _familiatelaid; }
       set { _familiatelaid = value; }
   }


   private String _telaidvfp; 
   public String telaidvfp{ 
       get { return _telaidvfp; }

       set { _telaidvfp = value; }
   }

   private String _modeloid; 
   public String modeloid{ 
       get { return _modeloid; }

       set { _modeloid = value; }
   }

   private String _estructuraid; 
   public String estructuraid{ 
       get { return _estructuraid; }

       set { _estructuraid = value; }
   }

   private string _canalventaid;
   public string canalventaid
   {
       get { return _canalventaid; }
       set { _canalventaid = value; }
   }

   private String _estacionid;
   public String estacionid
   {
       get { return _estacionid; }

       set { _estacionid = value; }
   }

   private String _temporadaid; 
   public String temporadaid{ 
       get { return _temporadaid; }

       set { _temporadaid = value; }
   }

   private String _grupoid; 
   public String grupoid{ 
       get { return _grupoid; }

       set { _grupoid = value; }
   }

   private String _rubroid; 
   public String rubroid{ 
       get { return _rubroid; }

       set { _rubroid = value; }
   }

   private String _parte; 
   public String parte{ 
       get { return _parte; }

       set { _parte = value; }
   }

   private String _tallaid; 
   public String tallaid{ 
       get { return _tallaid; }

       set { _tallaid = value; }
   }

   private Boolean? _ta01; 
   public Boolean? ta01{ 
       get { return _ta01; }

       set { _ta01 = value; }
   }

   private Boolean? _ta02; 
   public Boolean? ta02{ 
       get { return _ta02; }

       set { _ta02 = value; }
   }

   private Boolean? _ta03; 
   public Boolean? ta03{ 
       get { return _ta03; }

       set { _ta03 = value; }
   }

   private Boolean? _ta04; 
   public Boolean? ta04{ 
       get { return _ta04; }

       set { _ta04 = value; }
   }

   private Boolean? _ta05; 
   public Boolean? ta05{ 
       get { return _ta05; }

       set { _ta05 = value; }
   }

   private Boolean? _ta06; 
   public Boolean? ta06{ 
       get { return _ta06; }

       set { _ta06 = value; }
   }

   private Boolean? _ta07; 
   public Boolean? ta07{ 
       get { return _ta07; }

       set { _ta07 = value; }
   }

   private Boolean? _ta08; 
   public Boolean? ta08{ 
       get { return _ta08; }

       set { _ta08 = value; }
   }

   private Boolean? _ta09; 
   public Boolean? ta09{ 
       get { return _ta09; }

       set { _ta09 = value; }
   }

   private Boolean? _ta10; 
   public Boolean? ta10{ 
       get { return _ta10; }

       set { _ta10 = value; }
   }

   private Boolean? _ta11;
   public Boolean? ta11
   {
       get { return _ta11; }
       set { _ta11 = value; }
   }

   private Boolean? _ta12;
   public Boolean? ta12
   {
       get { return _ta12; }
       set { _ta12 = value; }
   }


   private String _variante; 
   public String variante{ 
       get { return _variante; }

       set { _variante = value; }
   }

   private String _codinge; 
   public String codinge{ 
       get { return _codinge; }

       set { _codinge = value; }
   }

   private Decimal _prec_etiq; 
   public Decimal prec_etiq{ 
       get { return _prec_etiq; }

       set { _prec_etiq = value; }
   }

   private Decimal _prec_ofer; 
   public Decimal prec_ofer{ 
       get { return _prec_ofer; }

       set { _prec_ofer = value; }
   }

   private DateTime? _fechpi; 
   public DateTime? fechpi{ 
       get { return _fechpi; }

       set { _fechpi = value; }
   }

   private DateTime? _fechui; 
   public DateTime? fechui{ 
       get { return _fechui; }

       set { _fechui = value; }
   }

   private String _estado; 
   public String estado{ 
       get { return _estado; }

       set { _estado = value; }
   }

   private Boolean _estado2;
   public Boolean estado2
   {
       get { return _estado2; }
       set { _estado2 = value; }
   }


   private Boolean? _es_mercaderia; 
   public Boolean? es_mercaderia{ 
       get { return _es_mercaderia; }

       set { _es_mercaderia = value; }
   }

   private Byte[] _foto;
   public Byte[] Foto
   {
       get { return _foto; }
       set { _foto = value; }
   }

   //private String _foto;
   //public String foto
   //{
   //    get { return _foto; }
   //    set { _foto = value; }
   //}

   private String _status; 
   public String status{ 
       get { return _status; }

       set { _status = value; }
   }

   private String _usuar; 
   public String usuar{ 
       get { return _usuar; }

       set { _usuar = value; }
   }

   private DateTime? _fecre; 
   public DateTime? fecre{ 
       get { return _fecre; }

       set { _fecre = value; }
   }

   private DateTime? _feact; 
   public DateTime? feact{ 
       get { return _feact; }

       set { _feact = value; }
   }

}
}
