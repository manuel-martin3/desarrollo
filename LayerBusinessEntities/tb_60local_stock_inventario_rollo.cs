using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_60local_stock_inventario_rollo
{ 

   private String _moduloid; 
   public String moduloid{ 
       get { return _moduloid; }

       set { _moduloid = value; }
   }

   private Boolean _dif;
   public Boolean dif
   {
       get { return _dif; }
       set { _dif = value; }
   }

   private String _lineaid;
   public String lineaid
   {
       get { return _lineaid; }
       set { _lineaid = value; }
   }

   private String _local; 
   public String local{ 
       get { return _local; }

       set { _local = value; }
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

   private String _rollo; 
   public String rollo{ 
       get { return _rollo; }

       set { _rollo = value; }
   }

   private Decimal _stocklibros; 
   public Decimal stocklibros{ 
       get { return _stocklibros; }

       set { _stocklibros = value; }
   }

   private Decimal _stockfisico; 
   public Decimal stockfisico{ 
       get { return _stockfisico; }

       set { _stockfisico = value; }
   }

   private Decimal _diferencia; 
   public Decimal diferencia{ 
       get { return _diferencia; }

       set { _diferencia = value; }
   }

   private Decimal _costopromlibros;
   public Decimal costopromlibros
   {
       get { return _costopromlibros; }

       set { _costopromlibros = value; }
   }

   private Decimal _costopromfisico;
   public Decimal costopromfisico
   {
       get { return _costopromfisico; }

       set { _costopromfisico = value; }
   }

   private String _codigoubic; 
   public String codigoubic{ 
       get { return _codigoubic; }

       set { _codigoubic = value; }
   }

   private DateTime? _fechatoma; 
   public DateTime? fechatoma{ 
       get { return _fechatoma; }

       set { _fechatoma = value; }
   }

   private String _userinventario; 
   public String userinventario{ 
       get { return _userinventario; }

       set { _userinventario = value; }
   }

   private String _usuar; 
   public String usuar{ 
       get { return _usuar; }

       set { _usuar = value; }
   }

   private DateTime? _feact; 
   public DateTime? feact{ 
       get { return _feact; }

       set { _feact = value; }
   }

}
}
