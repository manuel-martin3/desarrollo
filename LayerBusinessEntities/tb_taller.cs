using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_taller
{ 

   private String _tallertipoid; 
   public String tallertipoid{ 
       get { return _tallertipoid; }

       set { _tallertipoid = value; }
   }

   private String _tallerid; 
   public String tallerid{ 
       get { return _tallerid; }

       set { _tallerid = value; }
   }

   private String _tallername; 
   public String tallername{ 
       get { return _tallername; }

       set { _tallername = value; }
   }

   private String _tallernmruc; 
   public String tallernmruc{ 
       get { return _tallernmruc; }

       set { _tallernmruc = value; }
   }

   private String _ctacte; 
   public String ctacte{ 
       get { return _ctacte; }

       set { _ctacte = value; }
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
