using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 

namespace LayerBusinessEntities 
{ 

public class tb_usuariostablas
{ 

   private String _usuar; 
   public String usuar{ 
       get { return _usuar; }

       set { _usuar = value; }
   }

   private String _idtab; 
   public String idtab{ 
       get { return _idtab; }

       set { _idtab = value; }
   }

   private Boolean? _updat; 
   public Boolean? updat{ 
       get { return _updat; }

       set { _updat = value; }
   }

   private Boolean? _delet; 
   public Boolean? delet{ 
       get { return _delet; }

       set { _delet = value; }
   }

}
}
