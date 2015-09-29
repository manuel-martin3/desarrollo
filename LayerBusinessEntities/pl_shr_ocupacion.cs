using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class pl_shr_ocupacion
{ 

   private String _IdOcupa; 
   public String IdOcupa{ 
       get { return _IdOcupa; }

       set { _IdOcupa = value; }
   }

   private String _Descrip; 
   public String Descrip{ 
       get { return _Descrip; }

       set { _Descrip = value; }
   }

}
}
