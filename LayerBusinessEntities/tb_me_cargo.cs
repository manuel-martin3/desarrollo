using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{
    public class tb_me_cargo
    {

        public int? cateplanid { get; set; }

        private String _moduloid;
        public String moduloid
        {
            get { return _moduloid; }

            set { _moduloid = value; }
        }

       private String _cargoid; 
       public String cargoid{ 
           get { return _cargoid; }

           set { _cargoid = value; }
       }

       private String _cargoname; 
       public String cargoname{ 
           get { return _cargoname; }

           set { _cargoname = value; }
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
