using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
    public class tb_centrocosto
    { 

       private String _cencosid; 
       public String cencosid{ 
           get { return _cencosid; }

           set { _cencosid = value; }
       }

       private String _cencosname; 
       public String cencosname{ 
           get { return _cencosname; }

           set { _cencosname = value; }
       }

       private String _cencosdivi; 
       public String cencosdivi{ 
           get { return _cencosdivi; }

           set { _cencosdivi = value; }
       }

       private Boolean? _cencosanalitica; 
       public Boolean? cencosanalitica{ 
           get { return _cencosanalitica; }

           set { _cencosanalitica = value; }
       }

       private Boolean? _status;
       public Boolean? status
       {
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

       private DateTime? _feact; 
       public DateTime? feact{ 
           get { return _feact; }

           set { _feact = value; }
       }

       private String _nomlike1;
       public String nomlike1
       {
           get { return _nomlike1; }

           set { _nomlike1 = value; }
       }

       private String _nomlike2;
       public String nomlike2
       {
           get { return _nomlike2; }

           set { _nomlike2 = value; }
       }

       private String _nomlike3;
       public String nomlike3
       {
           get { return _nomlike3; }

           set { _nomlike3 = value; }
       }

       private int _norden;
       public int norden
       {
           get { return _norden; }

           set { _norden = value; }
       }

       private int _ver_blanco;
       public int ver_blanco
       {
           get { return _ver_blanco; }

           set { _ver_blanco = value; }
       }
    }
}
