using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_pt_entalle
{ 

   private String _entalleid; 
   public String entalleid{ 
       get { return _entalleid; }

       set { _entalleid = value; }
   }

   private String _entallename; 
   public String entallename{ 
       get { return _entallename; }

       set { _entallename = value; }
   }

   private String _entalledescort; 
   public String entalledescort{ 
       get { return _entalledescort; }

       set { _entalledescort = value; }
   }

   private String _usuar; 
   public String usuar{ 
       get { return _usuar; }

       set { _usuar = value; }
   }

   private String _posicion;
   public String posicion
   {
       get { return _posicion; }
       set { _posicion = value; }
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
