using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_mp_movimientosdet_delete
{ 

   private String _tipoalmac; 
   public String tipoalmac{ 
       get { return _tipoalmac; }

       set { _tipoalmac = value; }
   }

   private String _local; 
   public String local{ 
       get { return _local; }

       set { _local = value; }
   }

   private String _tipodoc; 
   public String tipodoc{ 
       get { return _tipodoc; }

       set { _tipodoc = value; }
   }

   private String _serdoc; 
   public String serdoc{ 
       get { return _serdoc; }

       set { _serdoc = value; }
   }

   private String _numdoc; 
   public String numdoc{ 
       get { return _numdoc; }

       set { _numdoc = value; }
   }

   private String _items; 
   public String items{ 
       get { return _items; }

       set { _items = value; }
   }

   private String _status; 
   public String status{ 
       get { return _status; }

       set { _status = value; }
   }

   private String _ctacte; 
   public String ctacte{ 
       get { return _ctacte; }

       set { _ctacte = value; }
   }

   private String _ctactename; 
   public String ctactename{ 
       get { return _ctactename; }

       set { _ctactename = value; }
   }

   private String _direcnume; 
   public String direcnume{ 
       get { return _direcnume; }

       set { _direcnume = value; }
   }

   private String _direcname; 
   public String direcname{ 
       get { return _direcname; }

       set { _direcname = value; }
   }

   private String _productid; 
   public String productid{ 
       get { return _productid; }

       set { _productid = value; }
   }

   private String _productname; 
   public String productname{ 
       get { return _productname; }

       set { _productname = value; }
   }

   private String _almacaccionid; 
   public String almacaccionid{ 
       get { return _almacaccionid; }

       set { _almacaccionid = value; }
   }

   private String _ctacteaccionid; 
   public String ctacteaccionid{ 
       get { return _ctacteaccionid; }

       set { _ctacteaccionid = value; }
   }

   private DateTime? _fechdoc; 
   public DateTime? fechdoc{ 
       get { return _fechdoc; }

       set { _fechdoc = value; }
   }

   private String _itemref; 
   public String itemref{ 
       get { return _itemref; }

       set { _itemref = value; }
   }

   private Decimal _cantidad; 
   public Decimal cantidad{ 
       get { return _cantidad; }

       set { _cantidad = value; }
   }

   private Decimal _valor; 
   public Decimal valor{ 
       get { return _valor; }

       set { _valor = value; }
   }

   private Decimal _importe; 
   public Decimal importe{ 
       get { return _importe; }

       set { _importe = value; }
   }

   private Decimal _cantidadcta; 
   public Decimal cantidadcta{ 
       get { return _cantidadcta; }

       set { _cantidadcta = value; }
   }

   private Decimal _cantidadfac; 
   public Decimal cantidadfac{ 
       get { return _cantidadfac; }

       set { _cantidadfac = value; }
   }

   private Decimal _precunit; 
   public Decimal precunit{ 
       get { return _precunit; }

       set { _precunit = value; }
   }

   private Decimal _importfac; 
   public Decimal importfac{ 
       get { return _importfac; }

       set { _importfac = value; }
   }

   private Decimal _dscto1; 
   public Decimal dscto1{ 
       get { return _dscto1; }

       set { _dscto1 = value; }
   }

   private Decimal _dscto2; 
   public Decimal dscto2{ 
       get { return _dscto2; }

       set { _dscto2 = value; }
   }

   private Decimal _dscto3; 
   public Decimal dscto3{ 
       get { return _dscto3; }

       set { _dscto3 = value; }
   }

   private String _tipref; 
   public String tipref{ 
       get { return _tipref; }

       set { _tipref = value; }
   }

   private String _serref; 
   public String serref{ 
       get { return _serref; }

       set { _serref = value; }
   }

   private String _numref; 
   public String numref{ 
       get { return _numref; }

       set { _numref = value; }
   }

   private DateTime? _fechref; 
   public DateTime? fechref{ 
       get { return _fechref; }

       set { _fechref = value; }
   }

   private String _tipoperef; 
   public String tipoperef{ 
       get { return _tipoperef; }

       set { _tipoperef = value; }
   }

   private String _ordenprod; 
   public String ordenprod{ 
       get { return _ordenprod; }

       set { _ordenprod = value; }
   }

   private String _tipfac; 
   public String tipfac{ 
       get { return _tipfac; }

       set { _tipfac = value; }
   }

   private String _serfac; 
   public String serfac{ 
       get { return _serfac; }

       set { _serfac = value; }
   }

   private String _numfac; 
   public String numfac{ 
       get { return _numfac; }

       set { _numfac = value; }
   }

   private DateTime? _fechfac; 
   public DateTime? fechfac{ 
       get { return _fechfac; }

       set { _fechfac = value; }
   }

   private String _tipguia; 
   public String tipguia{ 
       get { return _tipguia; }

       set { _tipguia = value; }
   }

   private String _serguia; 
   public String serguia{ 
       get { return _serguia; }

       set { _serguia = value; }
   }

   private String _numguia; 
   public String numguia{ 
       get { return _numguia; }

       set { _numguia = value; }
   }

   private DateTime? _fechguia; 
   public DateTime? fechguia{ 
       get { return _fechguia; }

       set { _fechguia = value; }
   }

   private String _cencosid; 
   public String cencosid{ 
       get { return _cencosid; }

       set { _cencosid = value; }
   }

   private String _vendorid; 
   public String vendorid{ 
       get { return _vendorid; }

       set { _vendorid = value; }
   }

   private String _moneda; 
   public String moneda{ 
       get { return _moneda; }

       set { _moneda = value; }
   }

   private Decimal _tcamb; 
   public Decimal tcamb{ 
       get { return _tcamb; }

       set { _tcamb = value; }
   }

   private String _tiptransac; 
   public String tiptransac{ 
       get { return _tiptransac; }

       set { _tiptransac = value; }
   }

   private String _motivotrasladoid; 
   public String motivotrasladoid{ 
       get { return _motivotrasladoid; }

       set { _motivotrasladoid = value; }
   }

   private String _statcostopromed; 
   public String statcostopromed{ 
       get { return _statcostopromed; }

       set { _statcostopromed = value; }
   }

   private String _incprec; 
   public String incprec{ 
       get { return _incprec; }

       set { _incprec = value; }
   }

   private Decimal _igv; 
   public Decimal igv{ 
       get { return _igv; }

       set { _igv = value; }
   }

   private Decimal _totimpto; 
   public Decimal totimpto{ 
       get { return _totimpto; }

       set { _totimpto = value; }
   }

   private String _glosa; 
   public String glosa{ 
       get { return _glosa; }

       set { _glosa = value; }
   }

   private String _rollo; 
   public String rollo{ 
       get { return _rollo; }

       set { _rollo = value; }
   }

   private String _codctadebe; 
   public String codctadebe{ 
       get { return _codctadebe; }

       set { _codctadebe = value; }
   }

   private String _codctahaber; 
   public String codctahaber{ 
       get { return _codctahaber; }

       set { _codctahaber = value; }
   }

   private String _perianio; 
   public String perianio{ 
       get { return _perianio; }

       set { _perianio = value; }
   }

   private String _perimes; 
   public String perimes{ 
       get { return _perimes; }

       set { _perimes = value; }
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
