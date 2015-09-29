using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_docuident
{ 

   private String _docuidentid; 
   public String docuidentid{ 
       get { return _docuidentid; }

       set { _docuidentid = value; }
   }

   private String _docuidentname; 
   public String docuidentname{ 
       get { return _docuidentname; }

       set { _docuidentname = value; }
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
