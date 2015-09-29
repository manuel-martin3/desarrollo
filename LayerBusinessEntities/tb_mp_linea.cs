using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_mp_linea
{ 

   private String _lineaid; 
   public String lineaid{ 
       get { return _lineaid; }

       set { _lineaid = value; }
   }

   private String _lineaname; 
   public String lineaname{ 
       get { return _lineaname; }

       set { _lineaname = value; }
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

   private DateTime? _fecre; 
   public DateTime? fecre{ 
       get { return _fecre; }

       set { _fecre = value; }
   }

}
}
