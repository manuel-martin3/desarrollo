using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_60color
{
    private String _moduloid;
    public String moduloid
    {
        get { return _moduloid; }

        set { _moduloid = value; }
    }

   private String _colorid; 
   public String colorid{ 
       get { return _colorid; }

       set { _colorid = value; }
   }

   private String _colorname; 
   public String colorname{ 
       get { return _colorname; }

       set { _colorname = value; }
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
    //*** OPT
   private String _posicion;
   public String posicion
   {
       get { return _posicion; }

       set { _posicion = value; }
   }
}
}
