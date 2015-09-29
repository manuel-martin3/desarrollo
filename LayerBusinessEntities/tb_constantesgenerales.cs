using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_constantesgenerales
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

   private String _perianio; 
   public String perianio{ 
       get { return _perianio; }

       set { _perianio = value; }
   }

   private String _perimes; 
   public String perimes{ 
       get { return _perimes; }

       set { _perimes = value; }
   }

   private Boolean _fechadocedit;
   public Boolean fechadocedit
   {
       get { return _fechadocedit; }
       set { _fechadocedit = value; }
   }

   private Decimal _tcamb; 
   public Decimal tcamb{ 
       get { return _tcamb; }

       set { _tcamb = value; }
   }

   private Decimal _igv; 
   public Decimal igv{ 
       get { return _igv; }

       set { _igv = value; }
   }

   private String _inprec; 
   public String inprec{ 
       get { return _inprec; }

       set { _inprec = value; }
   }

   private String _tipfactura; 
   public String tipfactura{ 
       get { return _tipfactura; }

       set { _tipfactura = value; }
   }

   private String _tipboleta; 
   public String tipboleta{ 
       get { return _tipboleta; }

       set { _tipboleta = value; }
   }

   private String _tipordprod; 
   public String tipordprod{ 
       get { return _tipordprod; }

       set { _tipordprod = value; }
   }

   private String _tipordcomp; 
   public String tipordcomp{ 
       get { return _tipordcomp; }

       set { _tipordcomp = value; }
   }

   private String _tipproforma; 
   public String tipproforma{ 
       get { return _tipproforma; }

       set { _tipproforma = value; }
   }

   private String _tipguia1; 
   public String tipguia1{ 
       get { return _tipguia1; }

       set { _tipguia1 = value; }
   }

   private String _tipguia2; 
   public String tipguia2{ 
       get { return _tipguia2; }

       set { _tipguia2 = value; }
   }

   private String _tipguia3; 
   public String tipguia3{ 
       get { return _tipguia3; }

       set { _tipguia3 = value; }
   }

   private String _tipajusteing; 
   public String tipajusteing{ 
       get { return _tipajusteing; }

       set { _tipajusteing = value; }
   }

   private String _tipajustesal; 
   public String tipajustesal{ 
       get { return _tipajustesal; }

       set { _tipajustesal = value; }
   }

   private String _monedn; 
   public String monedn{ 
       get { return _monedn; }

       set { _monedn = value; }
   }

   private String _monede; 
   public String monede{ 
       get { return _monede; }

       set { _monede = value; }
   }

   private String _monedu; 
   public String monedu{ 
       get { return _monedu; }

       set { _monedu = value; }
   }

   private String _monednsimbolo; 
   public String monednsimbolo{ 
       get { return _monednsimbolo; }

       set { _monednsimbolo = value; }
   }

   private String _monedesimbolo; 
   public String monedesimbolo{ 
       get { return _monedesimbolo; }

       set { _monedesimbolo = value; }
   }

   private Int16 _posl1; 
   public Int16 posl1{ 
       get { return _posl1; }

       set { _posl1 = value; }
   }

   private Int16 _longl1; 
   public Int16 longl1{ 
       get { return _longl1; }

       set { _longl1 = value; }
   }

   private Int16 _posl2; 
   public Int16 posl2{ 
       get { return _posl2; }

       set { _posl2 = value; }
   }

   private Int16 _longl2; 
   public Int16 longl2{ 
       get { return _longl2; }

       set { _longl2 = value; }
   }

   private Int16 _posl3; 
   public Int16 posl3{ 
       get { return _posl3; }

       set { _posl3 = value; }
   }

   private Int16 _longl3; 
   public Int16 longl3{ 
       get { return _longl3; }

       set { _longl3 = value; }
   }

   private String _descl1; 
   public String descl1{ 
       get { return _descl1; }

       set { _descl1 = value; }
   }

   private String _descl2; 
   public String descl2{ 
       get { return _descl2; }

       set { _descl2 = value; }
   }

   private String _descl3; 
   public String descl3{ 
       get { return _descl3; }

       set { _descl3 = value; }
   }

   private DateTime? _fechdigini; 
   public DateTime? fechdigini{ 
       get { return _fechdigini; }

       set { _fechdigini = value; }
   }

   private DateTime? _fechdigfin; 
   public DateTime? fechdigfin{ 
       get { return _fechdigfin; }

       set { _fechdigfin = value; }
   }

   private String _ctacteclie;
   public String ctacteclie
   {
       get { return _ctacteclie; }
       set { _ctacteclie = value; }
   }

   private String _ctacteinv;
   public String ctacteinv
   {
       get { return _ctacteinv; }
       set { _ctacteinv = value; }
   }

}
}
