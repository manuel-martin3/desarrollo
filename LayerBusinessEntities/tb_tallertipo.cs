using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_tallertipo
{ 

   private String _tallertipoid; 
   public String tallertipoid{ 
       get { return _tallertipoid; }

       set { _tallertipoid = value; }
   }

   private String _tallertiponame; 
   public String tallertiponame{ 
       get { return _tallertiponame; }

       set { _tallertiponame = value; }
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
