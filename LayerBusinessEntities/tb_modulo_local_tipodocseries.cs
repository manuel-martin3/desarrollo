using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_modulo_local_tipodocseries
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


   private Int32 _nlineas;
   public Int32 nlineas
   {
       get { return _nlineas; }
       set { _nlineas = value; }
   }

   private String _sermaq;
   public String sermaq
   {
       get { return _sermaq; }
       set { _sermaq = value; }
   }

   private String _ncaja;
   public String ncaja
   {
       get { return _ncaja; }
       set { _ncaja = value; }
   }

   private String _local; 
   public String local{ 
       get { return _local; }

       set { _local = value; }
   }

   private String _tipodoc; 
   public String tipodoc{ 
       get { return _tipodoc; }

       set { _tipodoc = value; }
   }

   private String _serdoc; 
   public String serdoc{ 
       get { return _serdoc; }

       set { _serdoc = value; }
   }

   private String _serdoc2;
   public String serdoc2
   {
       get { return _serdoc2; }
       set { _serdoc2 = value; }
   }

   private Decimal _numero; 
   public Decimal numero{ 
       get { return _numero; }

       set { _numero = value; }
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

   private String _status; 
   public String status{ 
       get { return _status; }

       set { _status = value; }
   }

   private String _tipodocname;
   public String tipodocname{
       get { return _tipodocname; }

       set { _tipodocname = value; }
   }

   private String _perianio;
   public String perianio
   {
       get { return _perianio; }
       set { _perianio = value; }
   }

}
}
