using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_transportista
{ 

   private String _transpid; 
   public String transpid{ 
       get { return _transpid; }

       set { _transpid = value; }
   }

   private String _transpname; 
   public String transpname{ 
       get { return _transpname; }

       set { _transpname = value; }
   }

   private String _transpplaca; 
   public String transpplaca{ 
       get { return _transpplaca; }

       set { _transpplaca = value; }
   }

   private String _transpcertificado; 
   public String transpcertificado{ 
       get { return _transpcertificado; }

       set { _transpcertificado = value; }
   }

   private String _transplicencia; 
   public String transplicencia{ 
       get { return _transplicencia; }

       set { _transplicencia = value; }
   }

   private String _transpnmruc; 
   public String transpnmruc{ 
       get { return _transpnmruc; }

       set { _transpnmruc = value; }
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
