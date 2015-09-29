using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_vendedor_corporativo
{ 

   private String _vendorid; 
   public String vendorid{ 
       get { return _vendorid; }

       set { _vendorid = value; }
   }

   private String _vendorname; 
   public String vendorname{ 
       get { return _vendorname; }

       set { _vendorname = value; }
   }

   private String _docuidentid; 
   public String docuidentid{ 
       get { return _docuidentid; }

       set { _docuidentid = value; }
   }

   private String _vendordni; 
   public String vendordni{ 
       get { return _vendordni; }

       set { _vendordni = value; }
   }

   private String _vendordire; 
   public String vendordire{ 
       get { return _vendordire; }

       set { _vendordire = value; }
   }

   private DateTime? _vendorfeing; 
   public DateTime? vendorfeing{ 
       get { return _vendorfeing; }

       set { _vendorfeing = value; }
   }

   private String _vendortelef; 
   public String vendortelef{ 
       get { return _vendortelef; }

       set { _vendortelef = value; }
   }   

   private String _ctacte; 
   public String ctacte{ 
       get { return _ctacte; }

       set { _ctacte = value; }
   }

   private String _userweb;
   public String userweb
   {
       get { return _userweb; }

       set { _userweb = value; }
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

   private String _status; 
   public String status{ 
       get { return _status; }

       set { _status = value; }
   }

}
}
