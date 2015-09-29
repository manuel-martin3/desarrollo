using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_pt_modelo
{ 

   private String _modeloid; 
   public String modeloid{ 
       get { return _modeloid; }

       set { _modeloid = value; }
   }

   private String _modeloname; 
   public String modeloname{ 
       get { return _modeloname; }

       set { _modeloname = value; }
   }

   private String _modelodescort; 
   public String modelodescort{ 
       get { return _modelodescort; }

       set { _modelodescort = value; }
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
