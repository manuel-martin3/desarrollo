using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_comprobante
{ 

   private String _comprobanteid; 
   public String comprobanteid{ 
       get { return _comprobanteid; }

       set { _comprobanteid = value; }
   }

   private String _comprobantename; 
   public String comprobantename{ 
       get { return _comprobantename; }

       set { _comprobantename = value; }
   }

   private String _comprobanteabrev; 
   public String comprobanteabrev{ 
       get { return _comprobanteabrev; }

       set { _comprobanteabrev = value; }
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
