using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_pp_ordenproduccioncab
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

   private DateTime? _fechdoc; 
   public DateTime? fechdoc{ 
       get { return _fechdoc; }

       set { _fechdoc = value; }
   }

   private String _ctacte; 
   public String ctacte{ 
       get { return _ctacte; }

       set { _ctacte = value; }
   }

   private String _nmruc; 
   public String nmruc{ 
       get { return _nmruc; }

       set { _nmruc = value; }
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

   private String _direcdeta; 
   public String direcdeta{ 
       get { return _direcdeta; }

       set { _direcdeta = value; }
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

   private DateTime? _fechaini; 
   public DateTime? fechaini{ 
       get { return _fechaini; }

       set { _fechaini = value; }
   }

   private DateTime? _fechafin; 
   public DateTime? fechafin{ 
       get { return _fechafin; }

       set { _fechafin = value; }
   }

   private Decimal _items; 
   public Decimal items{ 
       get { return _items; }

       set { _items = value; }
   }

   private Decimal _totpzas; 
   public Decimal totpzas{ 
       get { return _totpzas; }

       set { _totpzas = value; }
   }

   private Decimal _totpzas1ra; 
   public Decimal totpzas1ra{ 
       get { return _totpzas1ra; }

       set { _totpzas1ra = value; }
   }

   private Decimal _totpzas2da; 
   public Decimal totpzas2da{ 
       get { return _totpzas2da; }

       set { _totpzas2da = value; }
   }

   private Decimal _totpzasmerma; 
   public Decimal totpzasmerma{ 
       get { return _totpzasmerma; }

       set { _totpzasmerma = value; }
   }

   private Decimal _totpzaspend; 
   public Decimal totpzaspend{ 
       get { return _totpzaspend; }

       set { _totpzaspend = value; }
   }

   private DateTime? _fech_pri_aten; 
   public DateTime? fech_pri_aten{ 
       get { return _fech_pri_aten; }

       set { _fech_pri_aten = value; }
   }

   private DateTime? _fech_ult_aten; 
   public DateTime? fech_ult_aten{ 
       get { return _fech_ult_aten; }

       set { _fech_ult_aten = value; }
   }

   private Decimal _costoestimado; 
   public Decimal costoestimado{ 
       get { return _costoestimado; }

       set { _costoestimado = value; }
   }

   private Decimal _costoreal; 
   public Decimal costoreal{ 
       get { return _costoreal; }

       set { _costoreal = value; }
   }

   private String _responsable; 
   public String responsable{ 
       get { return _responsable; }

       set { _responsable = value; }
   }

   private String _user_apr1; 
   public String user_apr1{ 
       get { return _user_apr1; }

       set { _user_apr1 = value; }
   }

   private DateTime? _fech_apr1; 
   public DateTime? fech_apr1{ 
       get { return _fech_apr1; }

       set { _fech_apr1 = value; }
   }

   private String _user_apr2; 
   public String user_apr2{ 
       get { return _user_apr2; }

       set { _user_apr2 = value; }
   }

   private DateTime? _fech_apr2; 
   public DateTime? fech_apr2{ 
       get { return _fech_apr2; }

       set { _fech_apr2 = value; }
   }

   private String _canalventaref; 
   public String canalventaref{ 
       get { return _canalventaref; }

       set { _canalventaref = value; }
   }

   private String _glosa; 
   public String glosa{ 
       get { return _glosa; }

       set { _glosa = value; }
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

   private String _articid; 
   public String articid{ 
       get { return _articid; }

       set { _articid = value; }
   }

   private String _articname; 
   public String articname{ 
       get { return _articname; }

       set { _articname = value; }
   }

   private String _faseactual; 
   public String faseactual{ 
       get { return _faseactual; }

       set { _faseactual = value; }
   }

   private Int32 _fasesrealizadas; 
   public Int32 fasesrealizadas{ 
       get { return _fasesrealizadas; }

       set { _fasesrealizadas = value; }
   }

   private Decimal _faseactualpzas; 
   public Decimal faseactualpzas{ 
       get { return _faseactualpzas; }

       set { _faseactualpzas = value; }
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

   private String _status_aprob; 
   public String status_aprob{ 
       get { return _status_aprob; }

       set { _status_aprob = value; }
   }

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
