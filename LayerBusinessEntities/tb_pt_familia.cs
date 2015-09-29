using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_pt_familia
{ 

   private String _familiaid; 
   public String familiaid{ 
       get { return _familiaid; }

       set { _familiaid = value; }
   }

   private String _familianame; 
   public String familianame{ 
       get { return _familianame; }

       set { _familianame = value; }
   }

   private String _moduloid;
   public String moduloid
   {
       get { return _moduloid; }
       set { _moduloid = value; }
   }

   private String _unmed;
   public String unmed
   {
       get { return _unmed; }
       set { _unmed = value; }
   }


   private String _familiatelasdescort;
   public String familiatelasdescort
   {
       get { return _familiatelasdescort; }

       set { _familiatelasdescort = value; }
   }

   private String _estructuraid; 
   public String estructuraid{ 
       get { return _estructuraid; }

       set { _estructuraid = value; }
   }

   private String _lineaid;
   public String lineaid
   {
       get { return _lineaid; }
       set { _lineaid = value; }
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
