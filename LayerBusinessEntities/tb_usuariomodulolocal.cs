using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_usuariomodulolocal
{ 

   private String _usuar; 
   public String usuar{ 
       get { return _usuar; }

       set { _usuar = value; }
   }

   private String _dominioid; 
   public String dominioid{ 
       get { return _dominioid; }

       set { _dominioid = value; }
   }

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

}
}
