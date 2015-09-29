using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_60local_stock
{

    private String  _status;
    public String  status
    {
        get { return _status; }
        set { _status = value; }
    }
    
   private String _moduloid; 
   public String moduloid{ 
       get { return _moduloid; }

       set { _moduloid = value; }
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

   private String _productidold;
   public String productidold
   {
       get { return _productidold; }
       set { _productidold = value; }
   }

   private String _local; 
   public String local{ 
       get { return _local; }

       set { _local = value; }
   }


   private DateTime _fechdocini;
   public DateTime fechdocini
   {
       get { return _fechdocini; }
       set { _fechdocini = value; }
   }

   private DateTime _fechdocfin;
   public DateTime fechdocfin
   {
       get { return _fechdocfin; }
       set { _fechdocfin = value; }
   }

   private String _productid; 
   public String productid{ 
       get { return _productid; }

       set { _productid = value; }
   }

   private String _productname;
   public String productname
   {
       get { return _productname; }

       set { _productname = value; }
   }

   private Decimal _stockini01; 
   public Decimal stockini01{ 
       get { return _stockini01; }

       set { _stockini01 = value; }
   }

   private Decimal _stockini02; 
   public Decimal stockini02{ 
       get { return _stockini02; }

       set { _stockini02 = value; }
   }

   private Decimal _stockini03; 
   public Decimal stockini03{ 
       get { return _stockini03; }

       set { _stockini03 = value; }
   }

   private Decimal _stockini04; 
   public Decimal stockini04{ 
       get { return _stockini04; }

       set { _stockini04 = value; }
   }

   private Decimal _stockini05; 
   public Decimal stockini05{ 
       get { return _stockini05; }

       set { _stockini05 = value; }
   }

   private Decimal _stockini06; 
   public Decimal stockini06{ 
       get { return _stockini06; }

       set { _stockini06 = value; }
   }

   private Decimal _stockini07; 
   public Decimal stockini07{ 
       get { return _stockini07; }

       set { _stockini07 = value; }
   }

   private Decimal _stockini08; 
   public Decimal stockini08{ 
       get { return _stockini08; }

       set { _stockini08 = value; }
   }

   private Decimal _stockini09; 
   public Decimal stockini09{ 
       get { return _stockini09; }

       set { _stockini09 = value; }
   }

   private Decimal _stockini10; 
   public Decimal stockini10{ 
       get { return _stockini10; }

       set { _stockini10 = value; }
   }

   private Decimal _stockini11; 
   public Decimal stockini11{ 
       get { return _stockini11; }

       set { _stockini11 = value; }
   }

   private Decimal _stockini12; 
   public Decimal stockini12{ 
       get { return _stockini12; }

       set { _stockini12 = value; }
   }

   private Decimal _valorini01; 
   public Decimal valorini01{ 
       get { return _valorini01; }

       set { _valorini01 = value; }
   }

   private Decimal _valorini02; 
   public Decimal valorini02{ 
       get { return _valorini02; }

       set { _valorini02 = value; }
   }

   private Decimal _valorini03; 
   public Decimal valorini03{ 
       get { return _valorini03; }

       set { _valorini03 = value; }
   }

   private Decimal _valorini04; 
   public Decimal valorini04{ 
       get { return _valorini04; }

       set { _valorini04 = value; }
   }

   private Decimal _valorini05; 
   public Decimal valorini05{ 
       get { return _valorini05; }

       set { _valorini05 = value; }
   }

   private Decimal _valorini06; 
   public Decimal valorini06{ 
       get { return _valorini06; }

       set { _valorini06 = value; }
   }

   private Decimal _valorini07; 
   public Decimal valorini07{ 
       get { return _valorini07; }

       set { _valorini07 = value; }
   }

   private Decimal _valorini08; 
   public Decimal valorini08{ 
       get { return _valorini08; }

       set { _valorini08 = value; }
   }

   private Decimal _valorini09; 
   public Decimal valorini09{ 
       get { return _valorini09; }

       set { _valorini09 = value; }
   }

   private Decimal _valorini10; 
   public Decimal valorini10{ 
       get { return _valorini10; }

       set { _valorini10 = value; }
   }

   private Decimal _valorini11; 
   public Decimal valorini11{ 
       get { return _valorini11; }

       set { _valorini11 = value; }
   }

   private Decimal _valorini12; 
   public Decimal valorini12{ 
       get { return _valorini12; }

       set { _valorini12 = value; }
   }

   private Decimal _stockini; 
   public Decimal stockini{ 
       get { return _stockini; }

       set { _stockini = value; }
   }

   private Decimal _valorini; 
   public Decimal valorini{ 
       get { return _valorini; }

       set { _valorini = value; }
   }

   private Decimal _stock; 
   public Decimal stock{ 
       get { return _stock; }

       set { _stock = value; }
   }

   private Decimal _valoractual; 
   public Decimal valoractual{ 
       get { return _valoractual; }

       set { _valoractual = value; }
   }

   private Decimal _pendingreso; 
   public Decimal pendingreso{ 
       get { return _pendingreso; }

       set { _pendingreso = value; }
   }

   private Decimal _pendsalida; 
   public Decimal pendsalida{ 
       get { return _pendsalida; }

       set { _pendsalida = value; }
   }

   private Decimal _costopromed; 
   public Decimal costopromed{ 
       get { return _costopromed; }

       set { _costopromed = value; }
   }

   private Decimal _costoultimo; 
   public Decimal costoultimo{ 
       get { return _costoultimo; }

       set { _costoultimo = value; }
   }

   private String _codigoubic; 
   public String codigoubic{ 
       get { return _codigoubic; }

       set { _codigoubic = value; }
   }

   private Decimal _cantingreso; 
   public Decimal cantingreso{ 
       get { return _cantingreso; }

       set { _cantingreso = value; }
   }

   private Decimal _impoingreso; 
   public Decimal impoingreso{ 
       get { return _impoingreso; }

       set { _impoingreso = value; }
   }

   private Decimal _cantsalida; 
   public Decimal cantsalida{ 
       get { return _cantsalida; }

       set { _cantsalida = value; }
   }

   private Decimal _imposalida; 
   public Decimal imposalida{ 
       get { return _imposalida; }

       set { _imposalida = value; }
   }

   private Decimal _nivelreposicion; 
   public Decimal nivelreposicion{ 
       get { return _nivelreposicion; }

       set { _nivelreposicion = value; }
   }

    //*** OPT
   private String _perianio;
   public String perianio
   {
       get { return _perianio; }

       set { _perianio = value; }
   }

   private String _perimes;
   public String perimes
   {
       get { return _perimes; }

       set { _perimes = value; }
   }

   private String _grabacp;
   public String grabacp
   {
       get { return _grabacp; }

       set { _grabacp = value; }
   }

   private String _lineaid;
   public String lineaid
   {
       get { return _lineaid; }

       set { _lineaid = value; }
   }

   private String _grupoid;
   public String grupoid
   {
       get { return _grupoid; }

       set { _grupoid = value; }
   }

   private String _subgrupoid;
   public String subgrupoid
   {
       get { return _subgrupoid; }

       set { _subgrupoid = value; }
   }

   private String _colorid;
   public String colorid
   {
       get { return _colorid; }

       set { _colorid = value; }
   }

   public Boolean? desdehistorico { get; set; }

}
}
