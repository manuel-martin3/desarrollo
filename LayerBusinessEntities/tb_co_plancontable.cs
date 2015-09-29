using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 

namespace LayerBusinessEntities
{ 
    public class tb_co_plancontable
    { 
       private String _perianio; 
       public String perianio{ 
           get { return _perianio; }

           set { _perianio = value; }
       }

       private String _cuentaid; 
       public String cuentaid{ 
           get { return _cuentaid; }

           set { _cuentaid = value; }
       }

       private String _cuentaname; 
       public String cuentaname{ 
           get { return _cuentaname; }

           set { _cuentaname = value; }
       }

       private String _ordenresulxnatu; 
       public String ordenresulxnatu{ 
           get { return _ordenresulxnatu; }

           set { _ordenresulxnatu = value; }
       }

       private String _ordenresulxfunc; 
       public String ordenresulxfunc{ 
           get { return _ordenresulxfunc; }

           set { _ordenresulxfunc = value; }
       }

       private String _cuentamarredebe; 
       public String cuentamarredebe{ 
           get { return _cuentamarredebe; }

           set { _cuentamarredebe = value; }
       }

       private String _cuentamarrehaber; 
       public String cuentamarrehaber{ 
           get { return _cuentamarrehaber; }

           set { _cuentamarrehaber = value; }
       }

       private String _cencosid; 
       public String cencosid{ 
           get { return _cencosid; }

           set { _cencosid = value; }
       }

       private String _cuentaelemento; 
       public String cuentaelemento{ 
           get { return _cuentaelemento; }

           set { _cuentaelemento = value; }
       }

       private String _cuentadigito; 
       public String cuentadigito{ 
           get { return _cuentadigito; }

           set { _cuentadigito = value; }
       }

       private Boolean? _escuentaanalitica; 
       public Boolean? escuentaanalitica{ 
           get { return _escuentaanalitica; }

           set { _escuentaanalitica = value; }
       }

       private Boolean? _escuentabalance; 
       public Boolean? escuentabalance{ 
           get { return _escuentabalance; }

           set { _escuentabalance = value; }
       }

       private Boolean? _escuentaigv; 
       public Boolean? escuentaigv{ 
           get { return _escuentaigv; }

           set { _escuentaigv = value; }
       }

       private Boolean? _cuentaajuste; 
       public Boolean? cuentaajuste{ 
           get { return _cuentaajuste; }

           set { _cuentaajuste = value; }
       }

       private Boolean? _cuentapresupuesto; 
       public Boolean? cuentapresupuesto{ 
           get { return _cuentapresupuesto; }

           set { _cuentapresupuesto = value; }
       }

       private String _bancoid; 
       public String bancoid{ 
           get { return _bancoid; }

           set { _bancoid = value; }
       }

       private String _cuentactenume; 
       public String cuentactenume{ 
           get { return _cuentactenume; }

           set { _cuentactenume = value; }
       }

       private String _cuentamoneda; 
       public String cuentamoneda{ 
           get { return _cuentamoneda; }

           set { _cuentamoneda = value; }
       }

       private String _tipocambio;
       public String tipocambio
       {
           get { return _tipocambio; }

           set { _tipocambio = value; }
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

       private String _parametro01;
       public String parametro01
       {
           get { return _parametro01; }

           set { _parametro01 = value; }
       }

       private String _parametro02;
       public String parametro02
       {
           get { return _parametro02; }

           set { _parametro02 = value; }
       }

       private String _useripcre;
       public String useripcre
       {
           get { return _useripcre; }

           set { _useripcre = value; }
       }

       private String _useripact;
       public String useripact
       {
           get { return _useripact; }

           set { _useripact = value; }
       }

       private int _tipo;
       public int tipo
       {
           get { return _tipo; }

           set { _tipo = value; }
       }

       private String _cuentaiddj;
       public String cuentaiddj
       {
           get { return _cuentaiddj; }

           set { _cuentaiddj = value; }
       }

       private String _cuentanamedj;
       public String cuentanamedj
       {
           get { return _cuentanamedj; }

           set { _cuentanamedj = value; }
       }
    }
}
