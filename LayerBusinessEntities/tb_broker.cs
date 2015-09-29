using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_broker
{ 

   private String _brokerid; 
   public String brokerid{ 
       get { return _brokerid; }

       set { _brokerid = value; }
   }

   private String _brokername; 
   public String brokername{ 
       get { return _brokername; }

       set { _brokername = value; }
   }

   private String _docuidentid; 
   public String docuidentid{ 
       get { return _docuidentid; }

       set { _docuidentid = value; }
   }

   private String _brokerdni; 
   public String brokerdni{ 
       get { return _brokerdni; }

       set { _brokerdni = value; }
   }

   private String _brokerdire; 
   public String brokerdire{ 
       get { return _brokerdire; }

       set { _brokerdire = value; }
   }

   private DateTime? _brokerfeing; 
   public DateTime? brokerfeing{ 
       get { return _brokerfeing; }

       set { _brokerfeing = value; }
   }

   private String _brokertelef; 
   public String brokertelef{ 
       get { return _brokertelef; }

       set { _brokertelef = value; }
   }

   private String _ctacte; 
   public String ctacte{ 
       get { return _ctacte; }

       set { _ctacte = value; }
   }

   private String _brokerweb; 
   public String brokerweb{ 
       get { return _brokerweb; }

       set { _brokerweb = value; }
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
