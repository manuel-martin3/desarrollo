using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_pt_producto
{ 

   private String _productid; 
   public String productid{ 
       get { return _productid; }

       set { _productid = value; }
   }

   private String _moduloid; 
   public String moduloid{ 
       get { return _moduloid; }

       set { _moduloid = value; }
   }

   private String _lineaid; 
   public String lineaid{ 
       get { return _lineaid; }

       set { _lineaid = value; }
   }

   private String _marcaid; 
   public String marcaid{ 
       get { return _marcaid; }

       set { _marcaid = value; }
   }

   private String _item; 
   public String item{ 
       get { return _item; }

       set { _item = value; }
   }

   private String _colorid; 
   public String colorid{ 
       get { return _colorid; }

       set { _colorid = value; }
   }

   private String _tallaid; 
   public String tallaid{ 
       get { return _tallaid; }

       set { _tallaid = value; }
   }

   private String _status; 
   public String status{ 
       get { return _status; }

       set { _status = value; }
   }

   private String _productname; 
   public String productname{ 
       get { return _productname; }

       set { _productname = value; }
   }

   private String _unmed; 
   public String unmed{ 
       get { return _unmed; }

       set { _unmed = value; }
   }

   private Decimal _peso; 
   public Decimal peso{ 
       get { return _peso; }

       set { _peso = value; }
   }

   private String _unmedpeso; 
   public String unmedpeso{ 
       get { return _unmedpeso; }

       set { _unmedpeso = value; }
   }

   private String _unmedenvase; 
   public String unmedenvase{ 
       get { return _unmedenvase; }

       set { _unmedenvase = value; }
   }

   private Int32 _unidenvase; 
   public Int32 unidenvase{ 
       get { return _unidenvase; }

       set { _unidenvase = value; }
   }

   private Decimal _precioenvase; 
   public Decimal precioenvase{ 
       get { return _precioenvase; }

       set { _precioenvase = value; }
   }

   private String _etiquetaname; 
   public String etiquetaname{ 
       get { return _etiquetaname; }

       set { _etiquetaname = value; }
   }

   private String _color; 
   public String color{ 
       get { return _color; }

       set { _color = value; }
   }

   private String _moneda; 
   public String moneda{ 
       get { return _moneda; }

       set { _moneda = value; }
   }

   private Decimal _precventa; 
   public Decimal precventa{ 
       get { return _precventa; }

       set { _precventa = value; }
   }

   private Decimal _precvent2; 
   public Decimal precvent2{ 
       get { return _precvent2; }

       set { _precvent2 = value; }
   }

   private Decimal _precvent3; 
   public Decimal precvent3{ 
       get { return _precvent3; }

       set { _precvent3 = value; }
   }

   private Decimal _precventant; 
   public Decimal precventant{ 
       get { return _precventant; }

       set { _precventant = value; }
   }

   private String _conce; 
   public String conce{ 
       get { return _conce; }

       set { _conce = value; }
   }

   private String _diluc; 
   public String diluc{ 
       get { return _diluc; }

       set { _diluc = value; }
   }

   private String _ctacte; 
   public String ctacte{ 
       get { return _ctacte; }

       set { _ctacte = value; }
   }

   private String _compo; 
   public String compo{ 
       get { return _compo; }

       set { _compo = value; }
   }

   private String _titulo; 
   public String titulo{ 
       get { return _titulo; }

       set { _titulo = value; }
   }

   private String _foto; 
   public String foto{ 
       get { return _foto; }

       set { _foto = value; }
   }

   private String _productidold; 
   public String productidold{ 
       get { return _productidold; }

       set { _productidold = value; }
   }

   private String _grupoid; 
   public String grupoid{ 
       get { return _grupoid; }

       set { _grupoid = value; }
   }

   private String _subgrupoid; 
   public String subgrupoid{ 
       get { return _subgrupoid; }

       set { _subgrupoid = value; }
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

   private String _categoriaid; 
   public String categoriaid{ 
       get { return _categoriaid; }

       set { _categoriaid = value; }
   }

   private String _generoid; 
   public String generoid{ 
       get { return _generoid; }

       set { _generoid = value; }
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

   private Decimal _precvent4; 
   public Decimal precvent4{ 
       get { return _precvent4; }

       set { _precvent4 = value; }
   }

   private Decimal _precvent5; 
   public Decimal precvent5{ 
       get { return _precvent5; }

       set { _precvent5 = value; }
   }

   private DateTime? _fepialmac; 
   public DateTime? fepialmac{ 
       get { return _fepialmac; }

       set { _fepialmac = value; }
   }

   private DateTime? _feuialmac; 
   public DateTime? feuialmac{ 
       get { return _feuialmac; }

       set { _feuialmac = value; }
   }

}
}
