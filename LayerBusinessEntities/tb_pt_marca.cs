using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_pt_marca
{ 

   private String _marcaid; 
   public String marcaid{ 
       get { return _marcaid; }

       set { _marcaid = value; }
   }

   private String _marcaname; 
   public String marcaname{ 
       get { return _marcaname; }

       set { _marcaname = value; }
   }
   private String _marcadescort;
   public String marcadescort
   {
       get { return _marcadescort; }

       set { _marcadescort = value; }
   }

   private String _marcaidold; 
   public String marcaidold{ 
       get { return _marcaidold; }

       set { _marcaidold = value; }
   }

   private Boolean _marcapropia;
   public Boolean marcapropia
   {
       get { return _marcapropia; }
       set { _marcapropia = value; }
   }

   private String _sigla;
   public String sigla
   {
       get { return _sigla; }
       set { _sigla = value; }
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
