using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_claves
{ 

   private String _idcla; 
   public String idcla{ 
       get { return _idcla; }

       set { _idcla = value; }
   }

   private String _clave; 
   public String clave{ 
       get { return _clave; }

       set { _clave = value; }
   }

}
}
