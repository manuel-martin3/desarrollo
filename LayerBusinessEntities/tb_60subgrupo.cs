using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_60subgrupo
{

    public String parameters { get; set; }
    public String marcaid { get; set; }

    
    private String _moduloid;
    public String moduloid
    {
        get { return _moduloid; }

        set { _moduloid = value; }
    }

   private String _lineaid; 
   public String lineaid{ 
       get { return _lineaid; }

       set { _lineaid = value; }
   }

   private String _grupoid; 
   public String grupoid{ 
       get { return _grupoid; }

       set { _grupoid = value; }
   }

   private String _subgrupoid; 
   public String subgrupoid{ 
       get { return _subgrupoid; }

       set { _subgrupoid = value; }
   }

   private String _subgrupoartic; 
   public String subgrupoartic{ 
       get { return _subgrupoartic; }

       set { _subgrupoartic = value; }
   }

   private String _subgruponame; 
   public String subgruponame{ 
       get { return _subgruponame; }

       set { _subgruponame = value; }
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
