using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_pt_botapie
{ 

   private String _botapieid; 
   public String botapieid{ 
       get { return _botapieid; }

       set { _botapieid = value; }
   }

   private String _botapiename; 
   public String botapiename{ 
       get { return _botapiename; }

       set { _botapiename = value; }
   }

   private String _botapiedescort; 
   public String botapiedescort{ 
       get { return _botapiedescort; }

       set { _botapiedescort = value; }
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

   private String _posicion;
   public String posicion
   {
       get { return _posicion; }
       set { _posicion = value; }
   }


}
}
