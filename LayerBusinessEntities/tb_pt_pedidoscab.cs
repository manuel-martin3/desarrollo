using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
public class tb_pt_pedidoscab
{ 

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

   private String _numdoc; 
   public String numdoc{ 
       get { return _numdoc; }

       set { _numdoc = value; }
   }

   private DateTime? _fechdoc; 
   public DateTime? fechdoc{ 
       get { return _fechdoc; }

       set { _fechdoc = value; }
   }

   private String _ctacte; 
   public String ctacte{ 
       get { return _ctacte; }

       set { _ctacte = value; }
   }

   private String _nmruc; 
   public String nmruc{ 
       get { return _nmruc; }

       set { _nmruc = value; }
   }

   private String _ctactename; 
   public String ctactename{ 
       get { return _ctactename; }

       set { _ctactename = value; }
   }

   private String _direcnume; 
   public String direcnume{ 
       get { return _direcnume; }

       set { _direcnume = value; }
   }

   private String _direcname; 
   public String direcname{ 
       get { return _direcname; }

       set { _direcname = value; }
   }

   private String _direcdeta; 
   public String direcdeta{ 
       get { return _direcdeta; }

       set { _direcdeta = value; }
   }

   private String _direc; 
   public String direc{ 
       get { return _direc; }

       set { _direc = value; }
   }

   private String _almacaccionid; 
   public String almacaccionid{ 
       get { return _almacaccionid; }

       set { _almacaccionid = value; }
   }

   private String _ctacteaccionid; 
   public String ctacteaccionid{ 
       get { return _ctacteaccionid; }

       set { _ctacteaccionid = value; }
   }

   private String _tipdid; 
   public String tipdid{ 
       get { return _tipdid; }

       set { _tipdid = value; }
   }

   private String _tipref; 
   public String tipref{ 
       get { return _tipref; }

       set { _tipref = value; }
   }

   private String _serref; 
   public String serref{ 
       get { return _serref; }

       set { _serref = value; }
   }

   private String _numref; 
   public String numref{ 
       get { return _numref; }

       set { _numref = value; }
   }

   private DateTime? _fechref; 
   public DateTime? fechref{ 
       get { return _fechref; }

       set { _fechref = value; }
   }

   private String _tip_op; 
   public String tip_op{ 
       get { return _tip_op; }

       set { _tip_op = value; }
   }

   private String _ser_op; 
   public String ser_op{ 
       get { return _ser_op; }

       set { _ser_op = value; }
   }

   private String _num_op; 
   public String num_op{ 
       get { return _num_op; }

       set { _num_op = value; }
   }

   private String _tipfac; 
   public String tipfac{ 
       get { return _tipfac; }

       set { _tipfac = value; }
   }

   private String _serfac; 
   public String serfac{ 
       get { return _serfac; }

       set { _serfac = value; }
   }

   private String _numfac; 
   public String numfac{ 
       get { return _numfac; }

       set { _numfac = value; }
   }

   private DateTime? _fechfac; 
   public DateTime? fechfac{ 
       get { return _fechfac; }

       set { _fechfac = value; }
   }

   private String _tipguia; 
   public String tipguia{ 
       get { return _tipguia; }

       set { _tipguia = value; }
   }

   private String _serguia; 
   public String serguia{ 
       get { return _serguia; }

       set { _serguia = value; }
   }

   private String _numguia; 
   public String numguia{ 
       get { return _numguia; }

       set { _numguia = value; }
   }

   private DateTime? _fechguia; 
   public DateTime? fechguia{ 
       get { return _fechguia; }

       set { _fechguia = value; }
   }

   private String _vendorid; 
   public String vendorid{ 
       get { return _vendorid; }

       set { _vendorid = value; }
   }

   private String _brokerid; 
   public String brokerid{ 
       get { return _brokerid; }

       set { _brokerid = value; }
   }

   private String _ubige; 
   public String ubige{ 
       get { return _ubige; }

       set { _ubige = value; }
   }

   private String _cencosid; 
   public String cencosid{ 
       get { return _cencosid; }

       set { _cencosid = value; }
   }

   private Decimal _dscto3; 
   public Decimal dscto3{ 
       get { return _dscto3; }

       set { _dscto3 = value; }
   }

   private Decimal _totdscto1; 
   public Decimal totdscto1{ 
       get { return _totdscto1; }

       set { _totdscto1 = value; }
   }

   private Decimal _totdscto2; 
   public Decimal totdscto2{ 
       get { return _totdscto2; }

       set { _totdscto2 = value; }
   }

   private Decimal _totdscto3; 
   public Decimal totdscto3{ 
       get { return _totdscto3; }

       set { _totdscto3 = value; }
   }

   private String _condpago; 
   public String condpago{ 
       get { return _condpago; }

       set { _condpago = value; }
   }

   private Decimal _transporte; 
   public Decimal transporte{ 
       get { return _transporte; }

       set { _transporte = value; }
   }

   private Decimal _embalaje; 
   public Decimal embalaje{ 
       get { return _embalaje; }

       set { _embalaje = value; }
   }

   private Decimal _otros; 
   public Decimal otros{ 
       get { return _otros; }

       set { _otros = value; }
   }

   private String _tipimptoid; 
   public String tipimptoid{ 
       get { return _tipimptoid; }

       set { _tipimptoid = value; }
   }

   private Decimal _igv; 
   public Decimal igv{ 
       get { return _igv; }

       set { _igv = value; }
   }

   private String _incprec; 
   public String incprec{ 
       get { return _incprec; }

       set { _incprec = value; }
   }

   private String _tipoperimptoid; 
   public String tipoperimptoid{ 
       get { return _tipoperimptoid; }

       set { _tipoperimptoid = value; }
   }

   private Decimal _abono; 
   public Decimal abono{ 
       get { return _abono; }

       set { _abono = value; }
   }

   private Decimal _cargo; 
   public Decimal cargo{ 
       get { return _cargo; }

       set { _cargo = value; }
   }

   private Decimal _tcamb; 
   public Decimal tcamb{ 
       get { return _tcamb; }

       set { _tcamb = value; }
   }

   private DateTime? _fechentrega; 
   public DateTime? fechentrega{ 
       get { return _fechentrega; }

       set { _fechentrega = value; }
   }

   private DateTime? _fechpago; 
   public DateTime? fechpago{ 
       get { return _fechpago; }

       set { _fechpago = value; }
   }

   private DateTime? _fechcancel; 
   public DateTime? fechcancel{ 
       get { return _fechcancel; }

       set { _fechcancel = value; }
   }

   private String _moneda; 
   public String moneda{ 
       get { return _moneda; }

       set { _moneda = value; }
   }

   private String _statborrado; 
   public String statborrado{ 
       get { return _statborrado; }

       set { _statborrado = value; }
   }

   private String _transpid; 
   public String transpid{ 
       get { return _transpid; }

       set { _transpid = value; }
   }

   private String _transpnume; 
   public String transpnume{ 
       get { return _transpnume; }

       set { _transpnume = value; }
   }

   private String _transnmruc; 
   public String transnmruc{ 
       get { return _transnmruc; }

       set { _transnmruc = value; }
   }

   private String _placa; 
   public String placa{ 
       get { return _placa; }

       set { _placa = value; }
   }

   private String _certificado; 
   public String certificado{ 
       get { return _certificado; }

       set { _certificado = value; }
   }

   private String _licencia; 
   public String licencia{ 
       get { return _licencia; }

       set { _licencia = value; }
   }

   private String _motivotrasladoid; 
   public String motivotrasladoid{ 
       get { return _motivotrasladoid; }

       set { _motivotrasladoid = value; }
   }

   private String _modofactu; 
   public String modofactu{ 
       get { return _modofactu; }

       set { _modofactu = value; }
   }

   private String _clientetipo; 
   public String clientetipo{ 
       get { return _clientetipo; }

       set { _clientetipo = value; }
   }

   private String _ddnni; 
   public String ddnni{ 
       get { return _ddnni; }

       set { _ddnni = value; }
   }

   private Decimal _items; 
   public Decimal items{ 
       get { return _items; }

       set { _items = value; }
   }

   private Decimal _totimpto; 
   public Decimal totimpto{ 
       get { return _totimpto; }

       set { _totimpto = value; }
   }

   private Decimal _valventa; 
   public Decimal valventa{ 
       get { return _valventa; }

       set { _valventa = value; }
   }

   private Decimal _bruto; 
   public Decimal bruto{ 
       get { return _bruto; }

       set { _bruto = value; }
   }

   private Decimal _totimporte; 
   public Decimal totimporte{ 
       get { return _totimporte; }

       set { _totimporte = value; }
   }

   private Decimal _totpzas; 
   public Decimal totpzas{ 
       get { return _totpzas; }

       set { _totpzas = value; }
   }

   private DateTime? _fech_aten; 
   public DateTime? fech_aten{ 
       get { return _fech_aten; }

       set { _fech_aten = value; }
   }

   private String _docu_aten; 
   public String docu_aten{ 
       get { return _docu_aten; }

       set { _docu_aten = value; }
   }

   private Decimal _cantidadcta; 
   public Decimal cantidadcta{ 
       get { return _cantidadcta; }

       set { _cantidadcta = value; }
   }

   private Decimal _cant_pend; 
   public Decimal cant_pend{ 
       get { return _cant_pend; }

       set { _cant_pend = value; }
   }

   private Decimal _impo_aten; 
   public Decimal impo_aten{ 
       get { return _impo_aten; }

       set { _impo_aten = value; }
   }

   private Decimal _impo_pend; 
   public Decimal impo_pend{ 
       get { return _impo_pend; }

       set { _impo_pend = value; }
   }

   private String _user_apr1; 
   public String user_apr1{ 
       get { return _user_apr1; }

       set { _user_apr1 = value; }
   }

   private DateTime? _fech_apr1; 
   public DateTime? fech_apr1{ 
       get { return _fech_apr1; }

       set { _fech_apr1 = value; }
   }

   private String _user_apr2; 
   public String user_apr2{ 
       get { return _user_apr2; }

       set { _user_apr2 = value; }
   }

   private DateTime? _fech_apr2; 
   public DateTime? fech_apr2{ 
       get { return _fech_apr2; }

       set { _fech_apr2 = value; }
   }

   private String _canalventaref; 
   public String canalventaref{ 
       get { return _canalventaref; }

       set { _canalventaref = value; }
   }

   private String _glosaenvio; 
   public String glosaenvio{ 
       get { return _glosaenvio; }

       set { _glosaenvio = value; }
   }

   private String _glosacredi; 
   public String glosacredi{ 
       get { return _glosacredi; }

       set { _glosacredi = value; }
   }

   private String _codctadebe; 
   public String codctadebe{ 
       get { return _codctadebe; }

       set { _codctadebe = value; }
   }

   private String _codctahaber; 
   public String codctahaber{ 
       get { return _codctahaber; }

       set { _codctahaber = value; }
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

   private String _perimesini;
   public String perimesini
   {
       get { return _perimesini; }

       set { _perimesini = value; }
   }

   private String _perimesfin;
   public String perimesfin
   {
       get { return _perimesfin; }

       set { _perimesfin = value; }
   }

}
}
