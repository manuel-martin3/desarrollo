using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{
    public class tb_pt_parte
{ 

   private String _parteid; 
   public String parteid{ 
       get { return _parteid; }

       set { _parteid = value; }
   }

   private String _partename; 
   public String partename{ 
       get { return _partename; }

       set { _partename = value; }
   }

   private String _partedescort;
   public String partedescort
   {
       get { return _partedescort; }

       set { _partedescort = value; }
   }

   private String _parteidold; 
   public String parteidold{ 
       get { return _parteidold; }

       set { _parteidold = value; }
   }

   private String _usuar; 
   public String usuar{ 
       get { return _usuar; }

       set { _usuar = value; }
   }

   private DateTime? _feact; 
   public DateTime? feact{ 
       get { return _feact; }

       set { _feact = value; }
   }

   private DateTime? _fecre; 
   public DateTime? fecre{ 
       get { return _fecre; }

       set { _fecre = value; }
   }

   private String _posicion;
   public String posicion
   {
       get { return _posicion; }
       set { _posicion = value; }
   }

}
}
