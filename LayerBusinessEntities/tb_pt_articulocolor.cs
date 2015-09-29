using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_pt_articulocolor
{

    public String filtro { get; set; }

   private String _articid; 
   public String articid{ 
       get { return _articid; }

       set { _articid = value; }
   }

   private String _colorid; 
   public String colorid{ 
       get { return _colorid; }

       set { _colorid = value; }
   }

   private String _colorname;
   public String colorname
   {
       get { return _colorname; }

       set { _colorname = value; }
   }

   private String _status; 
   public String status{ 
       get { return _status; }

       set { _status = value; }
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

   private DateTime? _feacr; 
   public DateTime? feacr{ 
       get { return _feacr; }

       set { _feacr = value; }
   }

}
}
