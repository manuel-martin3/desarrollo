using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_empresaperiodo
{ 

   private String _empresaid; 
   public String empresaid{ 
       get { return _empresaid; }

       set { _empresaid = value; }
   }

   private String _periodo; 
   public String periodo{ 
       get { return _periodo; }

       set { _periodo = value; }
   }

   private Boolean? _actual; 
   public Boolean? actual{ 
       get { return _actual; }

       set { _actual = value; }
   }

}
}
