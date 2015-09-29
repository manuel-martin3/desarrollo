using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_pais
{ 

   private String _paisid; 
   public String paisid{ 
       get { return _paisid; }

       set { _paisid = value; }
   }

   private String _paisname; 
   public String paisname{ 
       get { return _paisname; }

       set { _paisname = value; }
   }

}
}
