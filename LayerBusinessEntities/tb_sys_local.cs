using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_sys_local
{ 

   private String _dominioid; 
   public String dominioid{ 
       get { return _dominioid; }

       set { _dominioid = value; }
   }

   private String _moduloid; 
   public String moduloid{ 
       get { return _moduloid; }

       set { _moduloid = value; }
   }

   private String _local; 
   public String local{ 
       get { return _local; }

       set { _local = value; }
   }

   private String _localname; 
   public String localname{ 
       get { return _localname; }

       set { _localname = value; }
   }

   public String canalventaid { get; set; }

   private String _localdirec; 
   public String localdirec{ 
       get { return _localdirec; }

       set { _localdirec = value; }
   }

   private DateTime? _localfeuiv; 
   public DateTime? localfeuiv{ 
       get { return _localfeuiv; }

       set { _localfeuiv = value; }
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

   private DateTime? _feact; 
   public DateTime? feact{ 
       get { return _feact; }

       set { _feact = value; }
   }

   private String _ctacte;
   public String ctacte
   {
       get { return _ctacte; }
       set { _ctacte = value; }
   }


   private String _direcnume;
   public String direcnume
   {
       get { return _direcnume; }
       set { _direcnume = value; }
   }


   private String _ctactename;
   public String ctactename
   {
       get { return _ctactename; }
       set { _ctactename = value; }
   }


   private String _nmruc;
   public String nmruc
   {
       get { return _nmruc; }
       set { _nmruc = value; }
   }


   private String _email;
   public String email
   {
       get { return _email; }
       set { _email = value; }
   }

   private String _rpc;
   public String rpc
   {
       get { return _rpc; }
       set { _rpc = value; }
   }

   private String _telf;
   public String telf
   {
       get { return _telf; }
       set { _telf = value; }
   }


   private String _estabsunat;
   public String estabsunat
   {
       get { return _estabsunat; }
       set { _estabsunat = value; }
   }

   private Boolean _perimeslocal;
   public Boolean perimeslocal
   {
       get { return _perimeslocal; }
       set { _perimeslocal = value; }
   }


  }

}
