using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_pt_categoria
{ 

   private String _categoriaid; 
   public String categoriaid{ 
       get { return _categoriaid; }

       set { _categoriaid = value; }
   }

   private String _categorianame; 
   public String categorianame{ 
       get { return _categorianame; }

       set { _categorianame = value; }
   }

   private Boolean? _es_saldo; 
   public Boolean? es_saldo{ 
       get { return _es_saldo; }

       set { _es_saldo = value; }
   }

   private String _posicion;
   public String posicion
   {
       get { return _posicion; }
       set { _posicion = value; }
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
