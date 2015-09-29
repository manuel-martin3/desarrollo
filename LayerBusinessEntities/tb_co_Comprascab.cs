using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_co_Comprascab
    {
       private String _perianio; 
       public String perianio{ 
           get { return _perianio; }

           set { _perianio = value; }
       }

       private String _perimes;
       public String perimes
       {
           get { return _perimes; }

           set { _perimes = value; }
       }

       private String _diarioid;
       public String diarioid
       {
           get { return _diarioid; }

           set { _diarioid = value; }
       }

       private String _asiento;
       public String asiento
       {
           get { return _asiento; }

           set { _asiento = value; }
       }      

       private String _moduloid;
       public String moduloid
        {
            get { return _moduloid; }

            set { _moduloid = value; }
       }

       private String _local;
       public String local
       {
           get { return _local; }

           set { _local = value; }
       }

       private String _tipodoc;
       public String tipodoc
       {
           get { return _tipodoc; }

           set { _tipodoc = value; }
       }

       private String _serdoc;
       public String serdoc
       {
           get { return _serdoc; }

           set { _serdoc = value; }
       }

       private String _numdoc;
       public String numdoc
       {
           get { return _numdoc; }

           set { _numdoc = value; }
       }

       private String _status;
       public String status
       {
           get { return _status; }

           set { _status = value; }
       }

       private DateTime? _fechdoc;
       public DateTime? fechdoc
       {
           get { return _fechdoc; }

           set { _fechdoc = value; }
       }

       private String _ctacte;
       public String ctacte
       {
           get { return _ctacte; }

           set { _ctacte = value; }
       }

       private String _ctactename;
       public String ctactename
       {
           get { return _ctactename; }

           set { _ctactename = value; }
       }

       private String _direc;
       public String direc
       {
           get { return _direc; }

           set { _direc = value; }
       }

       private String _ubige;
       public String ubige
       {
           get { return _ubige; }

           set { _ubige = value; }
       }

       private String _tipdid;
       public String tipdid
       {
           get { return _tipdid; }

           set { _tipdid = value; }
       }

       private String _nmruc;
       public String nmruc
       {
           get { return _nmruc; }

           set { _nmruc = value; }
       }

       private String _tipref;
       public String tipref
       {
           get { return _tipref; }

           set { _tipref = value; }
       }

       private String _serref;
       public String serref
       {
           get { return _serref; }

           set { _serref = value; }
       }

       private String _numref;
       public String numref
       {
           get { return _numref; }

           set { _numref = value; }
       }

       private DateTime? _fechref;
       public DateTime? fechref
       {
           get { return _fechref; }

           set { _fechref = value; }
       }

       private String _tipOp;
       public String tipOp
       {
           get { return _tipOp; }

           set { _tipOp = value; }
       }

       private String _serOp;
       public String serOp
       {
           get { return _serOp; }

           set { _serOp = value; }
       }

       private String _numOp;
       public String numOp
       {
           get { return _numOp; }

           set { _numOp = value; }
       }

       private String _arrayguias;
       public String arrayguias
       {
           get { return _arrayguias; }

           set { _arrayguias = value; }
       }

       private String _arrayfechasguia;
       public String arrayfechasguia
       {
           get { return _arrayfechasguia; }

           set { _arrayfechasguia = value; }
       }

       private String _cencosid;
       public String cencosid
       {
           get { return _cencosid; }

           set { _cencosid = value; }
       }

       private String _compradorid;
       public String compradorid
       {
           get { return _compradorid; }

           set { _compradorid = value; }
       }

       private String _condcompraid;
       public String condcompraid
       {
           get { return _condcompraid; }

           set { _condcompraid = value; }
       }

       private Decimal _bruto;
       public Decimal bruto
       {
           get { return _bruto; }

           set { _bruto = value; }
       }

       private Decimal _dscto3;
       public Decimal dscto3
       {
           get { return _dscto3; }

           set { _dscto3 = value; }
       }

       private Decimal _totdscto3;
       public Decimal totdscto3
       {
           get { return _totdscto3; }

           set { _totdscto3 = value; }
       }

       private Decimal _transporte;
       public Decimal transporte
       {
           get { return _transporte; }

           set { _transporte = value; }
       }

       private Decimal _embalaje;
       public Decimal embalaje
       {
           get { return _embalaje; }

           set { _embalaje = value; }
       }

       private Decimal _otros;
       public Decimal otros
       {
           get { return _otros; }

           set { _otros = value; }
       }

       private String _tipimptoid;
       public String tipimptoid
       {
           get { return _tipimptoid; }

           set { _tipimptoid = value; }
       }

       private Decimal _igv;
       public Decimal igv
       {
           get { return _igv; }

           set { _igv = value; }
       }

       private Boolean? _incprec;
       public Boolean? incprec
       {
           get { return _incprec; }

           set { _incprec = value; }
       }

       private Decimal _valorcompra1;
       public Decimal valorcompra1
       {
           get { return _valorcompra1; }

           set { _valorcompra1 = value; }
       }

       private Decimal _impexo;
       public Decimal impexo
       {
           get { return _impexo; }

           set { _impexo = value; }
       }

       private Decimal _igv1;
       public Decimal igv1
       {
           get { return _igv1; }

           set { _igv1 = value; }
       }

       private Decimal _cargo;
       public Decimal cargo
       {
           get { return _cargo; }

           set { _cargo = value; }
       }

       private Decimal _preciocompra1;
       public Decimal preciocompra1
       {
           get { return _preciocompra1; }

           set { _preciocompra1 = value; }
       }

       private String _moneda;
       public String moneda
       {
           get { return _moneda; }

           set { _moneda = value; }
       }

       private Decimal _tipcamb;
       public Decimal tipcamb
       {
           get { return _tipcamb; }

           set { _tipcamb = value; }
       }

       private String _codctadebe;
       public String codctadebe
       {
           get { return _codctadebe; }

           set { _codctadebe = value; }
       }

       private String _tipoid;
       public String tipoid
       {
           get { return _tipoid; }

           set { _tipoid = value; }
       }

       private String _glosa;
       public String glosa
       {
           get { return _glosa; }

           set { _glosa = value; }
       }

       private Decimal _totpzas;
       public Decimal totpzas
       {
           get { return _totpzas; }

           set { _totpzas = value; }
       }

       private DateTime? _fechentrega;
       public DateTime? fechentrega
       {
           get { return _fechentrega; }

           set { _fechentrega = value; }
       }

       private DateTime? _fechpago;
       public DateTime? fechpago
       {
           get { return _fechpago; }

           set { _fechpago = value; }
       }

       private DateTime? _fechcancel;
       public DateTime? fechcancel
       {
           get { return _fechcancel; }

           set { _fechcancel = value; }
       }

       private String _modofactu;
       public String modofactu
       {
           get { return _modofactu; }

           set { _modofactu = value; }
       }

       private Decimal _items;
       public Decimal items
       {
           get { return _items; }

           set { _items = value; }
       }

       private DateTime? _fechregistro;
       public DateTime? fechregistro
       {
           get { return _fechregistro; }

           set { _fechregistro = value; }
       }

       private String _vinculante;
       public String vinculante
       {
           get { return _vinculante; }

           set { _vinculante = value; }
       }

       private String _origen;
       public String origen
       {
           get { return _origen; }

           set { _origen = value; }
       }

       private Boolean? _afecdetraccion;
       public Boolean? afecdetraccion
       {
           get { return _afecdetraccion; }

           set { _afecdetraccion = value; }
       }

       private String _nconstdetrac;
       public String nconstdetrac
       {
           get { return _nconstdetrac; }

           set { _nconstdetrac = value; }
       }

       private DateTime? _fechconstdetrac;
       public DateTime? fechconstdetrac
       {
           get { return _fechconstdetrac; }

           set { _fechconstdetrac = value; }
       }

       private String _detraccionid;
       public String detraccionid
       {
           get { return _detraccionid; }

           set { _detraccionid = value; }
       }

       private Decimal _porcdetraccion;
       public Decimal porcdetraccion
       {
           get { return _porcdetraccion; }

           set { _porcdetraccion = value; }
       }

       private String _bnctadetraccion;
       public String bnctadetraccion
       {
           get { return _bnctadetraccion; }

           set { _bnctadetraccion = value; }
       }

       private Boolean? _afectretencion;
       public Boolean? afectretencion
       {
           get { return _afectretencion; }

           set { _afectretencion = value; }
       }

       private Boolean? _afecpercepcion;
       public Boolean? afecpercepcion
       {
           get { return _afecpercepcion; }

           set { _afecpercepcion = value; }
       }

       private String _serdocpercepcion;
       public String serdocpercepcion
       {
           get { return _serdocpercepcion; }

           set { _serdocpercepcion = value; }
       }

       private String _numdocpercepcion;
       public String numdocpercepcion
       {
           get { return _numdocpercepcion; }

           set { _numdocpercepcion = value; }
       }

       private String _percepcionid;
       public String percepcionid
       {
           get { return _percepcionid; }

           set { _percepcionid = value; }
       }

       private Boolean? _afectoigvid;
       public Boolean? afectoigvid
       {
           get { return _afectoigvid; }

           set { _afectoigvid = value; }
       }

       private String _aduanaid;
       public String aduanaid
       {
           get { return _aduanaid; }

           set { _aduanaid = value; }
       }

       private String _aniodua;
       public String aniodua
       {
           get { return _aniodua; }

           set { _aniodua = value; }
       }

       private String _numdua;
       public String numdua
       {
           get { return _numdua; }

           set { _numdua = value; }
       }

       private DateTime? _fechembdua;
       public DateTime? fechembdua
       {
           get { return _fechembdua; }

           set { _fechembdua = value; }
       }

       private DateTime? _fechreguldua;
       public DateTime? fechreguldua
       {
           get { return _fechreguldua; }

           set { _fechreguldua = value; }
       }

       private Decimal _valorfobdua;
       public Decimal valorfobdua
       {
           get { return _valorfobdua; }

           set { _valorfobdua = value; }
       }

       private String _tipoexportid;
       public String tipoexportid
       {
           get { return _tipoexportid; }

           set { _tipoexportid = value; }
       }

       private Decimal _valor2;
       public Decimal valor2
       {
           get { return _valor2; }

           set { _valor2 = value; }
       }

       private Decimal _dscto2;
       public Decimal dscto2
       {
           get { return _dscto2; }

           set { _dscto2 = value; }
       }

       private Decimal _impexo2;
       public Decimal impexo2
       {
           get { return _impexo2; }

           set { _impexo2 = value; }
       }

       private Decimal _valorcompra2;
       public Decimal valorcompra2
       {
           get { return _valorcompra2; }

           set { _valorcompra2 = value; }
       }

       private Decimal _igv2;
       public Decimal igv2
       {
           get { return _igv2; }

           set { _igv2 = value; }
       }

       private Decimal _preciocompra2;
       public Decimal preciocompra2
       {
           get { return _preciocompra2; }

           set { _preciocompra2 = value; }
       }

       private String _tipersona;
       public String tipersona
       {
           get { return _tipersona; }

           set { _tipersona = value; }
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

       private String _tipo;
       public String tipo
       {
           get { return _tipo; }

           set { _tipo = value; }
       }
    }
}
