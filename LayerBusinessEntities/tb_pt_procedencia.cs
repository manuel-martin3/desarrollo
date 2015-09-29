using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_pt_procedencia
{ 

   private String _procedenciaid; 
   public String procedenciaid{ 
       get { return _procedenciaid; }

       set { _procedenciaid = value; }
   }

   private String _procedencianame; 
   public String procedencianame{ 
       get { return _procedencianame; }

       set { _procedencianame = value; }
   }

   private String _procedenciadescort;
   public String procedenciadescort
   {
       get { return _procedenciadescort; }
       set { _procedenciadescort = value; }
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
