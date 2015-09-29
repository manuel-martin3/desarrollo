using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_tipooperacion
{ 

   private String _operacionid; 
   public String operacionid{ 
       get { return _operacionid; }

       set { _operacionid = value; }
   }

   private String _operacionname; 
   public String operacionname{ 
       get { return _operacionname; }

       set { _operacionname = value; }
   }

   private String _operaciontpmov; 
   public String operaciontpmov{ 
       get { return _operaciontpmov; }

       set { _operaciontpmov = value; }
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
