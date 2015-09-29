using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_comprador_corporativo
{ 

   private String _compradorid; 
   public String compradorid{ 
       get { return _compradorid; }

       set { _compradorid = value; }
   }

   private String _compradorname; 
   public String compradorname{ 
       get { return _compradorname; }

       set { _compradorname = value; }
   }

   private String _docuidentid; 
   public String docuidentid{ 
       get { return _docuidentid; }

       set { _docuidentid = value; }
   }

   private String _compradordni; 
   public String compradordni{ 
       get { return _compradordni; }

       set { _compradordni = value; }
   }

   private String _compradordire; 
   public String compradordire{ 
       get { return _compradordire; }

       set { _compradordire = value; }
   }

   private DateTime? _compradorfeing; 
   public DateTime? compradorfeing{ 
       get { return _compradorfeing; }

       set { _compradorfeing = value; }
   }

   private String _compradortelef; 
   public String compradortelef{ 
       get { return _compradortelef; }

       set { _compradortelef = value; }
   }

   private String _ctacte; 
   public String ctacte{ 
       get { return _ctacte; }

       set { _ctacte = value; }
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
