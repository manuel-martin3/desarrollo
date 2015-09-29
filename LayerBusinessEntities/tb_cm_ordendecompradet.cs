using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_cm_ordendecompradet
{ 

   private String _moduloid; 
   public String moduloid{ 
       get { return _moduloid; }

       set { _moduloid = value; }
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

    private String _tipoperacionid;
        public String tipoperacionid
        {
          get { return _tipoperacionid; }
          set { _tipoperacionid = value; }
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

   private String _moduloiddes; 
   public String moduloiddes{ 
       get { return _moduloiddes; }

       set { _moduloiddes = value; }
   }

   private String _localdes; 
   public String localdes{ 
       get { return _localdes; }

       set { _localdes = value; }
   }

   private String _status; 
   public String status{ 
       get { return _status; }

       set { _status = value; }
   }

   private DateTime? _fechdoc; 
   public DateTime? fechdoc{ 
       get { return _fechdoc; }

       set { _fechdoc = value; }
   }

   private String _almacaccionid; 
   public String almacaccionid{ 
       get { return _almacaccionid; }

       set { _almacaccionid = value; }
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

   private String _itemref; 
   public String itemref{ 
       get { return _itemref; }

       set { _itemref = value; }
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

   private String _tipped; 
   public String tipped{ 
       get { return _tipped; }

       set { _tipped = value; }
   }

   private String _serped; 
   public String serped{ 
       get { return _serped; }

       set { _serped = value; }
   }

   private String _numped; 
   public String numped{ 
       get { return _numped; }

       set { _numped = value; }
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

   private Decimal _precinit; 
   public Decimal precinit{ 
       get { return _precinit; }

       set { _precinit = value; }
   }

   private Boolean _chkdcto; 
   public Boolean chkdcto{ 
       get { return _chkdcto; }

       set { _chkdcto = value; }
   }

   private Decimal _pdscto; 
   public Decimal pdscto{ 
       get { return _pdscto; }

       set { _pdscto = value; }
   }

   private Decimal _idscto; 
   public Decimal idscto{ 
       get { return _idscto; }

       set { _idscto = value; }
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

   private String _incprec; 
   public String incprec{ 
       get { return _incprec; }

       set { _incprec = value; }
   }

   private Decimal _totimpto; 
   public Decimal totimpto{ 
       get { return _totimpto; }

       set { _totimpto = value; }
   }

   private Decimal _pigv; 
   public Decimal pigv{ 
       get { return _pigv; }

       set { _pigv = value; }
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

   private String _compradorid; 
   public String compradorid{ 
       get { return _compradorid; }

       set { _compradorid = value; }
   }

   private String _glosa; 
   public String glosa{ 
       get { return _glosa; }

       set { _glosa = value; }
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

   private DateTime? _fechentrega; 
   public DateTime? fechentrega{ 
       get { return _fechentrega; }

       set { _fechentrega = value; }
   }

   private String _aniosemana; 
   public String aniosemana{ 
       get { return _aniosemana; }

       set { _aniosemana = value; }
   }

   private String _aniosemanaconfirm; 
   public String aniosemanaconfirm{ 
       get { return _aniosemanaconfirm; }

       set { _aniosemanaconfirm = value; }
   }

   private Decimal _precioanterior; 
   public Decimal precioanterior{ 
       get { return _precioanterior; }

       set { _precioanterior = value; }
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

    //fecha de inicio 
   public String perimesini { get; set; }
    //fecha fin 
   public String perimesfin { get; set; }

   public String grupoid { get; set; }

   public String pendiente { get; set; }

   public String igv { get; set; }
}
}
