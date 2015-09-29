using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_pt_subcoleccion
{ 

   private String _subcoleccionid; 
   public String subcoleccionid{ 
       get { return _subcoleccionid; }

       set { _subcoleccionid = value; }
   }

   private String _subcoleccionname; 
   public String subcoleccionname{ 
       get { return _subcoleccionname; }

       set { _subcoleccionname = value; }
   }

   private String _coleccionid;
   public String coleccionid
   {
       get { return _coleccionid; }
       set { _coleccionid = value; }
   }

   private String _usuar; 
   public String usuar{ 
       get { return _usuar; }

       set { _usuar = value; }
   }

   private String _posicion;
   public String posicion
   {
       get { return _posicion; }
       set { _posicion = value; }
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
