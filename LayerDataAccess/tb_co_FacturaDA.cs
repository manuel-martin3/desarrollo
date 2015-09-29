using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_co_FacturaDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_co_Factura BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoFactura_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                    cmd.Parameters.Add("@asiento", SqlDbType.Char, 8).Value = BE.asiento;
                    cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd.Parameters.Add("@origen", SqlDbType.Char, 2).Value = BE.origen;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd.Parameters.Add("@ctacteconces", SqlDbType.Char, 7).Value = BE.ctacteconces;
                    cmd.Parameters.Add("@tiperson", SqlDbType.Char, 2).Value = BE.tiperson;
                    cmd.Parameters.Add("@tipdid", SqlDbType.Char, 1).Value = BE.tipdid;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                    cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                    cmd.Parameters.Add("@direc", SqlDbType.VarChar, 70).Value = BE.direc;
                    cmd.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE.ubige;
                    cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                    cmd.Parameters.Add("@fechvcto", SqlDbType.DateTime).Value = BE.fechvcto;
                    cmd.Parameters.Add("@condicionvta", SqlDbType.Char, 2).Value = BE.condicionvta;
                    cmd.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                    cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                    cmd.Parameters.Add("@ordencompra", SqlDbType.Char, 16).Value = BE.ordencompra;
                    cmd.Parameters.Add("@detraccionid", SqlDbType.Char, 5).Value = BE.detraccionid;
                    cmd.Parameters.Add("@porcdetraccion", SqlDbType.Decimal).Value = BE.porcdetraccion;
                    cmd.Parameters.Add("@nctadetraccion", SqlDbType.VarChar, 40).Value = BE.nctadetraccion;
                    cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 100).Value = BE.glosa;
                    cmd.Parameters.Add("@tipoventa", SqlDbType.Char, 2).Value = BE.tipoventa;
                    cmd.Parameters.Add("@afectoigvid", SqlDbType.Char, 1).Value = BE.afectoigvid;
                    cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                    cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                    cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                    cmd.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE.fechref;
                    cmd.Parameters.Add("@aduanaid", SqlDbType.Char, 3).Value = BE.aduanaid;
                    cmd.Parameters.Add("@aniodua", SqlDbType.Char, 4).Value = BE.aniodua;
                    cmd.Parameters.Add("@numdua", SqlDbType.Char, 10).Value = BE.numdua;
                    cmd.Parameters.Add("@fechembdua", SqlDbType.DateTime).Value = BE.fechembdua;
                    cmd.Parameters.Add("@fechreguldua", SqlDbType.DateTime).Value = BE.fechreguldua;
                    cmd.Parameters.Add("@valorfobdua", SqlDbType.Decimal).Value = BE.valorfobdua;
                    cmd.Parameters.Add("@tipoexportid", SqlDbType.Char, 2).Value = BE.tipoexportid;
                    cmd.Parameters.Add("@afectoigv", SqlDbType.Bit).Value = BE.afectoigv;
                    cmd.Parameters.Add("@incprec", SqlDbType.Bit).Value = BE.incprec;
                    cmd.Parameters.Add("@afectretencion", SqlDbType.Bit).Value = BE.afectretencion;
                    cmd.Parameters.Add("@tipincoterms", SqlDbType.Char, 2).Value = BE.tipincoterms;
                    cmd.Parameters.Add("@valor011", SqlDbType.Decimal).Value = BE.valor011;
                    cmd.Parameters.Add("@valor012", SqlDbType.Decimal).Value = BE.valor012;
                    cmd.Parameters.Add("@valor021", SqlDbType.Decimal).Value = BE.valor021;
                    cmd.Parameters.Add("@valor022", SqlDbType.Decimal).Value = BE.valor022;
                    cmd.Parameters.Add("@valor031", SqlDbType.Decimal).Value = BE.valor031;
                    cmd.Parameters.Add("@valor032", SqlDbType.Decimal).Value = BE.valor032;
                    cmd.Parameters.Add("@totfact01", SqlDbType.Decimal).Value = BE.totfact01;
                    cmd.Parameters.Add("@totfact02", SqlDbType.Decimal).Value = BE.totfact02;
                    cmd.Parameters.Add("@terminovta", SqlDbType.VarChar, 50).Value = BE.terminovta;
                    cmd.Parameters.Add("@dpais", SqlDbType.VarChar, 50).Value = BE.dpais;
                    cmd.Parameters.Add("@embarcador", SqlDbType.VarChar, 50).Value = BE.embarcador;
                    cmd.Parameters.Add("@agenteaduana", SqlDbType.VarChar, 50).Value = BE.agenteaduana;
                    cmd.Parameters.Add("@condicionpago", SqlDbType.VarChar, 50).Value = BE.condicionpago;
                    cmd.Parameters.Add("@cartacredito", SqlDbType.VarChar, 50).Value = BE.cartacredito;
                    cmd.Parameters.Add("@viaembarque", SqlDbType.Char, 2).Value = BE.viaembarque;
                    cmd.Parameters.Add("@referencia", SqlDbType.VarChar, 50).Value = BE.referencia;
                    cmd.Parameters.Add("@beneficiodrawback", SqlDbType.VarChar, 200).Value = BE.beneficiodrawback;
                    cmd.Parameters.Add("@marcaprodexport", SqlDbType.VarChar, 200).Value = BE.marcaprodexport;
                    cmd.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = BE.cantidad;
                    cmd.Parameters.Add("@bultos", SqlDbType.VarChar, 20).Value = BE.bultos;
                    cmd.Parameters.Add("@fletes", SqlDbType.VarChar, 20).Value = BE.fletes;
                    cmd.Parameters.Add("@pesoneto", SqlDbType.Decimal).Value = BE.pesoneto;
                    cmd.Parameters.Add("@pesobruto", SqlDbType.Decimal).Value = BE.pesobruto;
                    cmd.Parameters.Add("@porcigv", SqlDbType.Decimal).Value = BE.porcigv;
                    cmd.Parameters.Add("@pdscto", SqlDbType.Decimal).Value = BE.pdscto;
                    cmd.Parameters.Add("@bruto1", SqlDbType.Decimal).Value = BE.bruto1;
                    cmd.Parameters.Add("@dsctopropio1", SqlDbType.Decimal).Value = BE.dsctopropio1;
                    cmd.Parameters.Add("@dsctoconvenio1", SqlDbType.Decimal).Value = BE.dsctoconvenio1;
                    cmd.Parameters.Add("@dsctototal1", SqlDbType.Decimal).Value = BE.dsctototal1;
                    cmd.Parameters.Add("@baseimpo1", SqlDbType.Decimal).Value = BE.baseimpo1;
                    cmd.Parameters.Add("@montoigv1", SqlDbType.Decimal).Value = BE.montoigv1;
                    cmd.Parameters.Add("@precioventa1", SqlDbType.Decimal).Value = BE.precioventa1;           
                    cmd.Parameters.Add("@bruto2", SqlDbType.Decimal).Value = BE.bruto2;
                    cmd.Parameters.Add("@dsctopropio2", SqlDbType.Decimal).Value = BE.dsctopropio2;
                    cmd.Parameters.Add("@dsctoconvenio2", SqlDbType.Decimal).Value = BE.dsctoconvenio2;
                    cmd.Parameters.Add("@dsctototal2", SqlDbType.Decimal).Value = BE.dsctototal2;
                    cmd.Parameters.Add("@baseimpo2", SqlDbType.Decimal).Value = BE.baseimpo2;
                    cmd.Parameters.Add("@montoigv2", SqlDbType.Decimal).Value = BE.montoigv2;
                    cmd.Parameters.Add("@precioventa2", SqlDbType.Decimal).Value = BE.precioventa2;
                    cmd.Parameters.Add("@promoidlist", SqlDbType.Char, 20).Value = BE.promoidlist;
                    cmd.Parameters.Add("@tarjbonus", SqlDbType.Char, 13).Value = BE.tarjbonus;
                    cmd.Parameters.Add("@tarjetaid", SqlDbType.Int).Value = BE.tarjetaid;
                    cmd.Parameters.Add("@tarjgrupoid", SqlDbType.Int).Value = BE.tarjgrupoid;
                    cmd.Parameters.Add("@tarjnumoper", SqlDbType.Char, 3).Value = BE.tarjnumoper;
                    cmd.Parameters.Add("@tarjimporte1", SqlDbType.Decimal).Value = BE.tarjimporte1;
                    cmd.Parameters.Add("@tarjimporte2", SqlDbType.Decimal).Value = BE.tarjimporte2;
                    cmd.Parameters.Add("@motivotrasladoid", SqlDbType.Char, 2).Value = BE.motivotrasladoid;
                    cmd.Parameters.Add("@mottrasladointid", SqlDbType.Char, 2).Value = BE.mottrasladointid;
                    cmd.Parameters.Add("@transpid", SqlDbType.Char, 5).Value = BE.transpid;
                    cmd.Parameters.Add("@fechinitras", SqlDbType.DateTime).Value = BE.fechinitras;
                    cmd.Parameters.Add("@estabsunat", SqlDbType.Char, 4).Value = BE.estabsunat;
                    cmd.Parameters.Add("@cajanume", SqlDbType.Char, 2).Value = BE.cajanume;
                    cmd.Parameters.Add("@ticketeraid", SqlDbType.Char, 15).Value = BE.ticketeraid;
                    cmd.Parameters.Add("@efectivo", SqlDbType.Decimal).Value = BE.efectivo;
                    cmd.Parameters.Add("@vuelto", SqlDbType.Decimal).Value = BE.vuelto;
                    cmd.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE.almacaccionid;
                    cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendedorid;                    
                    cmd.Parameters.Add("@vinculante", SqlDbType.Char, 1).Value = BE.vinculante;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;

                    cmd.Parameters.Add("@XML", SqlDbType.Xml).Value = BE.GetItemXML();

                    try
                    {
                        cnx.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public bool Update(string empresaid, tb_co_Factura BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoFactura_UPDATE", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                    cmd.Parameters.Add("@asiento", SqlDbType.Char, 8).Value = BE.asiento;
                    cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd.Parameters.Add("@origen", SqlDbType.Char, 2).Value = BE.origen;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd.Parameters.Add("@ctacteconces", SqlDbType.Char, 7).Value = BE.ctacteconces;
                    cmd.Parameters.Add("@tiperson", SqlDbType.Char, 2).Value = BE.tiperson;
                    cmd.Parameters.Add("@tipdid", SqlDbType.Char, 1).Value = BE.tipdid;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                    cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                    cmd.Parameters.Add("@direc", SqlDbType.VarChar, 70).Value = BE.direc;
                    cmd.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE.ubige;
                    cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                    cmd.Parameters.Add("@fechvcto", SqlDbType.DateTime).Value = BE.fechvcto;
                    cmd.Parameters.Add("@condicionvta", SqlDbType.Char, 2).Value = BE.condicionvta;
                    cmd.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                    cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                    cmd.Parameters.Add("@ordencompra", SqlDbType.Char, 16).Value = BE.ordencompra;
                    cmd.Parameters.Add("@detraccionid", SqlDbType.Char, 5).Value = BE.detraccionid;
                    cmd.Parameters.Add("@porcdetraccion", SqlDbType.Decimal).Value = BE.porcdetraccion;
                    cmd.Parameters.Add("@nctadetraccion", SqlDbType.VarChar, 40).Value = BE.nctadetraccion;
                    cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 100).Value = BE.glosa;
                    cmd.Parameters.Add("@tipoventa", SqlDbType.Char, 2).Value = BE.tipoventa;
                    cmd.Parameters.Add("@afectoigvid", SqlDbType.Char, 1).Value = BE.afectoigvid;
                    cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                    cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                    cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                    cmd.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE.fechref;
                    cmd.Parameters.Add("@aduanaid", SqlDbType.Char, 3).Value = BE.aduanaid;
                    cmd.Parameters.Add("@aniodua", SqlDbType.Char, 4).Value = BE.aniodua;
                    cmd.Parameters.Add("@numdua", SqlDbType.Char, 10).Value = BE.numdua;
                    cmd.Parameters.Add("@fechembdua", SqlDbType.DateTime).Value = BE.fechembdua;
                    cmd.Parameters.Add("@fechreguldua", SqlDbType.DateTime).Value = BE.fechreguldua;
                    cmd.Parameters.Add("@valorfobdua", SqlDbType.Decimal).Value = BE.valorfobdua;
                    cmd.Parameters.Add("@tipoexportid", SqlDbType.Char, 2).Value = BE.tipoexportid;
                    cmd.Parameters.Add("@afectoigv", SqlDbType.Bit).Value = BE.afectoigv;
                    cmd.Parameters.Add("@incprec", SqlDbType.Bit).Value = BE.incprec;
                    cmd.Parameters.Add("@afectretencion", SqlDbType.Bit).Value = BE.afectretencion;
                    cmd.Parameters.Add("@tipincoterms", SqlDbType.Char, 2).Value = BE.tipincoterms;
                    cmd.Parameters.Add("@valor011", SqlDbType.Decimal).Value = BE.valor011;
                    cmd.Parameters.Add("@valor012", SqlDbType.Decimal).Value = BE.valor012;
                    cmd.Parameters.Add("@valor021", SqlDbType.Decimal).Value = BE.valor021;
                    cmd.Parameters.Add("@valor022", SqlDbType.Decimal).Value = BE.valor022;
                    cmd.Parameters.Add("@valor031", SqlDbType.Decimal).Value = BE.valor031;
                    cmd.Parameters.Add("@valor032", SqlDbType.Decimal).Value = BE.valor032;
                    cmd.Parameters.Add("@totfact01", SqlDbType.Decimal).Value = BE.totfact01;
                    cmd.Parameters.Add("@totfact02", SqlDbType.Decimal).Value = BE.totfact02;
                    cmd.Parameters.Add("@terminovta", SqlDbType.VarChar, 50).Value = BE.terminovta;
                    cmd.Parameters.Add("@dpais", SqlDbType.VarChar, 50).Value = BE.dpais;
                    cmd.Parameters.Add("@embarcador", SqlDbType.VarChar, 50).Value = BE.embarcador;
                    cmd.Parameters.Add("@agenteaduana", SqlDbType.VarChar, 50).Value = BE.agenteaduana;
                    cmd.Parameters.Add("@condicionpago", SqlDbType.VarChar, 50).Value = BE.condicionpago;
                    cmd.Parameters.Add("@cartacredito", SqlDbType.VarChar, 50).Value = BE.cartacredito;
                    cmd.Parameters.Add("@viaembarque", SqlDbType.Char, 2).Value = BE.viaembarque;
                    cmd.Parameters.Add("@referencia", SqlDbType.VarChar, 50).Value = BE.referencia;
                    cmd.Parameters.Add("@beneficiodrawback", SqlDbType.VarChar, 200).Value = BE.beneficiodrawback;
                    cmd.Parameters.Add("@marcaprodexport", SqlDbType.VarChar, 200).Value = BE.marcaprodexport;
                    cmd.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = BE.cantidad;
                    cmd.Parameters.Add("@bultos", SqlDbType.VarChar, 20).Value = BE.bultos;
                    cmd.Parameters.Add("@fletes", SqlDbType.VarChar, 20).Value = BE.fletes;
                    cmd.Parameters.Add("@pesoneto", SqlDbType.Decimal).Value = BE.pesoneto;
                    cmd.Parameters.Add("@pesobruto", SqlDbType.Decimal).Value = BE.pesobruto;
                    cmd.Parameters.Add("@porcigv", SqlDbType.Decimal).Value = BE.porcigv;
                    cmd.Parameters.Add("@pdscto", SqlDbType.Decimal).Value = BE.pdscto;
                    cmd.Parameters.Add("@bruto1", SqlDbType.Decimal).Value = BE.bruto1;
                    cmd.Parameters.Add("@dsctopropio1", SqlDbType.Decimal).Value = BE.dsctopropio1;
                    cmd.Parameters.Add("@dsctoconvenio1", SqlDbType.Decimal).Value = BE.dsctoconvenio1;
                    cmd.Parameters.Add("@dsctototal1", SqlDbType.Decimal).Value = BE.dsctototal1;
                    cmd.Parameters.Add("@baseimpo1", SqlDbType.Decimal).Value = BE.baseimpo1;
                    cmd.Parameters.Add("@montoigv1", SqlDbType.Decimal).Value = BE.montoigv1;
                    cmd.Parameters.Add("@precioventa1", SqlDbType.Decimal).Value = BE.precioventa1;
                    cmd.Parameters.Add("@bruto2", SqlDbType.Decimal).Value = BE.bruto2;
                    cmd.Parameters.Add("@dsctopropio2", SqlDbType.Decimal).Value = BE.dsctopropio2;
                    cmd.Parameters.Add("@dsctoconvenio2", SqlDbType.Decimal).Value = BE.dsctoconvenio2;
                    cmd.Parameters.Add("@dsctototal2", SqlDbType.Decimal).Value = BE.dsctototal2;
                    cmd.Parameters.Add("@baseimpo2", SqlDbType.Decimal).Value = BE.baseimpo2;
                    cmd.Parameters.Add("@montoigv2", SqlDbType.Decimal).Value = BE.montoigv2;
                    cmd.Parameters.Add("@precioventa2", SqlDbType.Decimal).Value = BE.precioventa2;
                    cmd.Parameters.Add("@promoidlist", SqlDbType.Char, 20).Value = BE.promoidlist;
                    cmd.Parameters.Add("@tarjbonus", SqlDbType.Char, 13).Value = BE.tarjbonus;
                    cmd.Parameters.Add("@tarjetaid", SqlDbType.Int).Value = BE.tarjetaid;
                    cmd.Parameters.Add("@tarjgrupoid", SqlDbType.Int).Value = BE.tarjgrupoid;
                    cmd.Parameters.Add("@tarjnumoper", SqlDbType.Char, 3).Value = BE.tarjnumoper;
                    cmd.Parameters.Add("@tarjimporte1", SqlDbType.Decimal).Value = BE.tarjimporte1;
                    cmd.Parameters.Add("@tarjimporte2", SqlDbType.Decimal).Value = BE.tarjimporte2;
                    cmd.Parameters.Add("@motivotrasladoid", SqlDbType.Char, 2).Value = BE.motivotrasladoid;
                    cmd.Parameters.Add("@mottrasladointid", SqlDbType.Char, 2).Value = BE.mottrasladointid;
                    cmd.Parameters.Add("@transpid", SqlDbType.Char, 5).Value = BE.transpid;
                    cmd.Parameters.Add("@fechinitras", SqlDbType.DateTime).Value = BE.fechinitras;
                    cmd.Parameters.Add("@estabsunat", SqlDbType.Char, 4).Value = BE.estabsunat;
                    cmd.Parameters.Add("@cajanume", SqlDbType.Char, 2).Value = BE.cajanume;
                    cmd.Parameters.Add("@ticketeraid", SqlDbType.Char, 15).Value = BE.ticketeraid;
                    cmd.Parameters.Add("@efectivo", SqlDbType.Decimal).Value = BE.efectivo;
                    cmd.Parameters.Add("@vuelto", SqlDbType.Decimal).Value = BE.vuelto;
                    cmd.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE.almacaccionid;
                    cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendedorid;
                    cmd.Parameters.Add("@vinculante", SqlDbType.Char, 1).Value = BE.vinculante;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;

                    cmd.Parameters.Add("@XML", SqlDbType.Xml).Value = BE.GetItemXML();

                    try
                    {
                        cnx.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public bool Delete(string empresaid, tb_co_Factura BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoVentascab_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 8).Value = BE.asiento;
                    }
                    try
                    {
                        cnx.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
        public DataSet GetAll(string empresaid, tb_co_Factura BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoFacturacab_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 8).Value = BE.asiento;
                        cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@origen", SqlDbType.Char, 2).Value = BE.origen;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@ctacteconces", SqlDbType.Char, 7).Value = BE.ctacteconces;
                        cmd.Parameters.Add("@tiperson", SqlDbType.Char, 2).Value = BE.tiperson;
                        cmd.Parameters.Add("@tipdid", SqlDbType.Char, 1).Value = BE.tipdid;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                        cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                        cmd.Parameters.Add("@direc", SqlDbType.VarChar, 70).Value = BE.direc;
                        cmd.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE.ubige;
                        cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                        cmd.Parameters.Add("@fechvcto", SqlDbType.DateTime).Value = BE.fechvcto;
                        cmd.Parameters.Add("@condicionvta", SqlDbType.Char, 2).Value = BE.condicionvta;
                        //cmd.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@ordencompra", SqlDbType.Char, 16).Value = BE.ordencompra;
                        cmd.Parameters.Add("@detraccionid", SqlDbType.Char, 5).Value = BE.detraccionid;
                        //cmd.Parameters.Add("@porcdetraccion", SqlDbType.Decimal).Value = BE.porcdetraccion;
                        cmd.Parameters.Add("@nctadetraccion", SqlDbType.VarChar, 40).Value = BE.nctadetraccion;
                        cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 100).Value = BE.glosa;
                        cmd.Parameters.Add("@tipoventa", SqlDbType.Char, 2).Value = BE.tipoventa;
                        cmd.Parameters.Add("@afectoigvid", SqlDbType.Char, 1).Value = BE.afectoigvid;
                        cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                        cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                        cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                        cmd.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE.fechref;
                        cmd.Parameters.Add("@aduanaid", SqlDbType.Char, 3).Value = BE.aduanaid;
                        cmd.Parameters.Add("@aniodua", SqlDbType.Char, 4).Value = BE.aniodua;
                        cmd.Parameters.Add("@numdua", SqlDbType.Char, 10).Value = BE.numdua;
                        cmd.Parameters.Add("@fechembdua", SqlDbType.DateTime).Value = BE.fechembdua;
                        cmd.Parameters.Add("@fechreguldua", SqlDbType.DateTime).Value = BE.fechreguldua;
                        //cmd.Parameters.Add("@valorfobdua", SqlDbType.Decimal).Value = BE.valorfobdua;
                        cmd.Parameters.Add("@tipoexportid", SqlDbType.Char, 2).Value = BE.tipoexportid;
                        cmd.Parameters.Add("@afectoigv", SqlDbType.Bit).Value = BE.afectoigv;
                        cmd.Parameters.Add("@incprec", SqlDbType.Bit).Value = BE.incprec;
                        cmd.Parameters.Add("@afectretencion", SqlDbType.Bit).Value = BE.afectretencion;
                        cmd.Parameters.Add("@tipincoterms", SqlDbType.Char, 2).Value = BE.tipincoterms;
                        //cmd.Parameters.Add("@valor011", SqlDbType.Decimal).Value = BE.valor011;
                        //cmd.Parameters.Add("@valor012", SqlDbType.Decimal).Value = BE.valor012;
                        //cmd.Parameters.Add("@valor021", SqlDbType.Decimal).Value = BE.valor021;
                        //cmd.Parameters.Add("@valor022", SqlDbType.Decimal).Value = BE.valor022;
                        //cmd.Parameters.Add("@valor031", SqlDbType.Decimal).Value = BE.valor031;
                        //cmd.Parameters.Add("@valor032", SqlDbType.Decimal).Value = BE.valor032;
                        //cmd.Parameters.Add("@totfact01", SqlDbType.Decimal).Value = BE.totfact01;
                        //cmd.Parameters.Add("@totfact02", SqlDbType.Decimal).Value = BE.totfact02;
                        cmd.Parameters.Add("@terminovta", SqlDbType.VarChar, 50).Value = BE.terminovta;
                        cmd.Parameters.Add("@dpais", SqlDbType.VarChar, 50).Value = BE.dpais;
                        cmd.Parameters.Add("@embarcador", SqlDbType.VarChar, 50).Value = BE.embarcador;
                        cmd.Parameters.Add("@agenteaduana", SqlDbType.VarChar, 50).Value = BE.agenteaduana;
                        cmd.Parameters.Add("@condicionpago", SqlDbType.VarChar, 50).Value = BE.condicionpago;
                        cmd.Parameters.Add("@cartacredito", SqlDbType.VarChar, 50).Value = BE.cartacredito;
                        cmd.Parameters.Add("@viaembarque", SqlDbType.Char, 2).Value = BE.viaembarque;
                        cmd.Parameters.Add("@referencia", SqlDbType.VarChar, 50).Value = BE.referencia;
                        cmd.Parameters.Add("@beneficiodrawback", SqlDbType.VarChar, 200).Value = BE.beneficiodrawback;
                        cmd.Parameters.Add("@marcaprodexport", SqlDbType.VarChar, 200).Value = BE.marcaprodexport;
                        //cmd.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = BE.cantidad;
                        cmd.Parameters.Add("@bultos", SqlDbType.VarChar, 20).Value = BE.bultos;
                        cmd.Parameters.Add("@fletes", SqlDbType.VarChar, 20).Value = BE.fletes;
                        cmd.Parameters.Add("@pesoneto", SqlDbType.Decimal).Value = BE.pesoneto;
                        //cmd.Parameters.Add("@pesobruto", SqlDbType.Decimal).Value = BE.pesobruto;
                        //cmd.Parameters.Add("@pigv", SqlDbType.Decimal).Value = BE.pigv;
                        //cmd.Parameters.Add("@pdscto", SqlDbType.Decimal).Value = BE.pdscto;
                        //cmd.Parameters.Add("@bruto1", SqlDbType.Decimal).Value = BE.bruto1;
                        //cmd.Parameters.Add("@dsctopropio1", SqlDbType.Decimal).Value = BE.dsctopropio1;
                        //cmd.Parameters.Add("@dsctoconvenio1", SqlDbType.Decimal).Value = BE.dsctoconvenio1;
                        //cmd.Parameters.Add("@dsctototal1", SqlDbType.Decimal).Value = BE.dsctototal1;
                        //cmd.Parameters.Add("@baseimpo1", SqlDbType.Decimal).Value = BE.baseimpo1;
                        //cmd.Parameters.Add("@montoigv1", SqlDbType.Decimal).Value = BE.montoigv1;
                        //cmd.Parameters.Add("@precioventa1", SqlDbType.Decimal).Value = BE.precioventa1;
                        //cmd.Parameters.Add("@bruto2", SqlDbType.Decimal).Value = BE.bruto2;
                        //cmd.Parameters.Add("@dsctopropio2", SqlDbType.Decimal).Value = BE.dsctopropio2;
                        //cmd.Parameters.Add("@dsctoconvenio2", SqlDbType.Decimal).Value = BE.dsctoconvenio2;
                        //cmd.Parameters.Add("@dsctototal2", SqlDbType.Decimal).Value = BE.dsctototal2;
                        //cmd.Parameters.Add("@baseimpo2", SqlDbType.Decimal).Value = BE.baseimpo2;
                        //cmd.Parameters.Add("@montoigv2", SqlDbType.Decimal).Value = BE.montoigv2;
                        //cmd.Parameters.Add("@precioventa2", SqlDbType.Decimal).Value = BE.precioventa2;
                        cmd.Parameters.Add("@promoidlist", SqlDbType.Char, 20).Value = BE.promoidlist;
                        cmd.Parameters.Add("@tarjbonus", SqlDbType.Char, 13).Value = BE.tarjbonus;
                        //cmd.Parameters.Add("@tarjetaid", SqlDbType.Int).Value = BE.tarjetaid;
                        //cmd.Parameters.Add("@tarjgrupoid", SqlDbType.Int).Value = BE.tarjgrupoid;
                        cmd.Parameters.Add("@tarjnumoper", SqlDbType.Char, 3).Value = BE.tarjnumoper;
                        //cmd.Parameters.Add("@tarjimporte1", SqlDbType.Decimal).Value = BE.tarjimporte1;
                        //cmd.Parameters.Add("@tarjimporte2", SqlDbType.Decimal).Value = BE.tarjimporte2;
                        cmd.Parameters.Add("@motivotrasladoid", SqlDbType.Char, 2).Value = BE.motivotrasladoid;
                        cmd.Parameters.Add("@mottrasladointid", SqlDbType.Char, 2).Value = BE.mottrasladointid;
                        cmd.Parameters.Add("@transpid", SqlDbType.Char, 5).Value = BE.transpid;
                        cmd.Parameters.Add("@fechinitras", SqlDbType.DateTime).Value = BE.fechinitras;
                        cmd.Parameters.Add("@estabsunat", SqlDbType.Char, 4).Value = BE.estabsunat;
                        cmd.Parameters.Add("@cajanume", SqlDbType.Char, 2).Value = BE.cajanume;
                        cmd.Parameters.Add("@ticketeraid", SqlDbType.Char, 15).Value = BE.ticketeraid;
                        //cmd.Parameters.Add("@efectivo", SqlDbType.Decimal).Value = BE.efectivo;
                        //cmd.Parameters.Add("@vuelto", SqlDbType.Decimal).Value = BE.vuelto;
                        cmd.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE.almacaccionid;
                        cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendedorid;
                        cmd.Parameters.Add("@vinculante", SqlDbType.Char, 1).Value = BE.vinculante;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    }
                    try
                    {
                        cnx.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                        }
                        return ds;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
        public DataSet GetAsientoNume(string empresaid, tb_co_Factura BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoFacturacab_SEARCH_asientonume", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                    }
                    try
                    {
                        cnx.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                        }
                        return ds;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public DataSet GetAllDet(string empresaid, tb_co_Factura BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoFacturadet_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 8).Value = BE.asiento;
                        //cmd.Parameters.Add("@asientoitems", SqlDbType.Char, 5).Value = BE.asientoitems;
                        //cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        //cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        //cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        //cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                        //cmd.Parameters.Add("@fechvcto", SqlDbType.DateTime).Value = BE.fechvcto;
                        //cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        //cmd.Parameters.Add("@items", SqlDbType.Char, 5).Value = BE.items;
                        //cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        //cmd.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE.almacaccionid;
                        //cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                        //cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                        //cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                        //cmd.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE.fechref;
                        //cmd.Parameters.Add("@rubroid", SqlDbType.Char, 4).Value = BE.rubroid;
                        //cmd.Parameters.Add("@tip_ped", SqlDbType.Char, 2).Value = BE.tip_ped;
                        //cmd.Parameters.Add("@ser_ped", SqlDbType.Char, 4).Value = BE.ser_ped;
                        //cmd.Parameters.Add("@num_ped", SqlDbType.Char, 10).Value = BE.num_ped;
                        //cmd.Parameters.Add("@tip_op", SqlDbType.Char, 2).Value = BE.tip_op;
                        //cmd.Parameters.Add("@ser_op", SqlDbType.Char, 4).Value = BE.ser_op;
                        //cmd.Parameters.Add("@num_op", SqlDbType.Char, 10).Value = BE.num_op;
                        //cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        //cmd.Parameters.Add("@articidold", SqlDbType.Char, 10).Value = BE.articidold;
                        //cmd.Parameters.Add("@productname", SqlDbType.VarChar, 70).Value = BE.productname;
                        //cmd.Parameters.Add("@colorid", SqlDbType.Char, 3).Value = BE.colorid;
                        //cmd.Parameters.Add("@colorname", SqlDbType.VarChar, 25).Value = BE.colorname;


                        //cmd.Parameters.Add("@condicionvta", SqlDbType.Char, 2).Value = BE.condicionvta;
                        ////cmd.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                        //cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        //cmd.Parameters.Add("@ordencompra", SqlDbType.Char, 16).Value = BE.ordencompra;
                        //cmd.Parameters.Add("@detraccionid", SqlDbType.Char, 5).Value = BE.detraccionid;
                        ////cmd.Parameters.Add("@porcdetraccion", SqlDbType.Decimal).Value = BE.porcdetraccion;
                        //cmd.Parameters.Add("@nctadetraccion", SqlDbType.VarChar, 40).Value = BE.nctadetraccion;
                        //cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 100).Value = BE.glosa;
                        //cmd.Parameters.Add("@tipoventa", SqlDbType.Char, 2).Value = BE.tipoventa;
                        //cmd.Parameters.Add("@afectoigvid", SqlDbType.Char, 1).Value = BE.afectoigvid;                      
                        //cmd.Parameters.Add("@aduanaid", SqlDbType.Char, 3).Value = BE.aduanaid;
                        //cmd.Parameters.Add("@aniodua", SqlDbType.Char, 4).Value = BE.aniodua;
                        //cmd.Parameters.Add("@numdua", SqlDbType.Char, 10).Value = BE.numdua;
                        //cmd.Parameters.Add("@fechembdua", SqlDbType.DateTime).Value = BE.fechembdua;
                        //cmd.Parameters.Add("@fechreguldua", SqlDbType.DateTime).Value = BE.fechreguldua;
                        ////cmd.Parameters.Add("@valorfobdua", SqlDbType.Decimal).Value = BE.valorfobdua;
                        //cmd.Parameters.Add("@tipoexportid", SqlDbType.Char, 2).Value = BE.tipoexportid;
                        //cmd.Parameters.Add("@afectoigv", SqlDbType.Bit).Value = BE.afectoigv;
                        //cmd.Parameters.Add("@incprec", SqlDbType.Bit).Value = BE.incprec;
                        //cmd.Parameters.Add("@afectretencion", SqlDbType.Bit).Value = BE.afectretencion;
                        //cmd.Parameters.Add("@tipincoterms", SqlDbType.Char, 2).Value = BE.tipincoterms;
                        ////cmd.Parameters.Add("@valor011", SqlDbType.Decimal).Value = BE.valor011;
                        ////cmd.Parameters.Add("@valor012", SqlDbType.Decimal).Value = BE.valor012;
                        ////cmd.Parameters.Add("@valor021", SqlDbType.Decimal).Value = BE.valor021;
                        ////cmd.Parameters.Add("@valor022", SqlDbType.Decimal).Value = BE.valor022;
                        ////cmd.Parameters.Add("@valor031", SqlDbType.Decimal).Value = BE.valor031;
                        ////cmd.Parameters.Add("@valor032", SqlDbType.Decimal).Value = BE.valor032;
                        ////cmd.Parameters.Add("@totfact01", SqlDbType.Decimal).Value = BE.totfact01;
                        ////cmd.Parameters.Add("@totfact02", SqlDbType.Decimal).Value = BE.totfact02;
                        //cmd.Parameters.Add("@terminovta", SqlDbType.VarChar, 50).Value = BE.terminovta;
                        //cmd.Parameters.Add("@dpais", SqlDbType.VarChar, 50).Value = BE.dpais;
                        //cmd.Parameters.Add("@embarcador", SqlDbType.VarChar, 50).Value = BE.embarcador;
                        //cmd.Parameters.Add("@agenteaduana", SqlDbType.VarChar, 50).Value = BE.agenteaduana;
                        //cmd.Parameters.Add("@condicionpago", SqlDbType.VarChar, 50).Value = BE.condicionpago;
                        //cmd.Parameters.Add("@cartacredito", SqlDbType.VarChar, 50).Value = BE.cartacredito;
                        //cmd.Parameters.Add("@viaembarque", SqlDbType.Char, 2).Value = BE.viaembarque;
                        //cmd.Parameters.Add("@referencia", SqlDbType.VarChar, 50).Value = BE.referencia;
                        //cmd.Parameters.Add("@beneficiodrawback", SqlDbType.VarChar, 200).Value = BE.beneficiodrawback;
                        //cmd.Parameters.Add("@marcaprodexport", SqlDbType.VarChar, 200).Value = BE.marcaprodexport;
                        ////cmd.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = BE.cantidad;
                        //cmd.Parameters.Add("@bultos", SqlDbType.VarChar, 20).Value = BE.bultos;
                        //cmd.Parameters.Add("@fletes", SqlDbType.VarChar, 20).Value = BE.fletes;
                        //cmd.Parameters.Add("@pesoneto", SqlDbType.Decimal).Value = BE.pesoneto;
                        ////cmd.Parameters.Add("@pesobruto", SqlDbType.Decimal).Value = BE.pesobruto;
                        ////cmd.Parameters.Add("@pigv", SqlDbType.Decimal).Value = BE.pigv;
                        ////cmd.Parameters.Add("@pdscto", SqlDbType.Decimal).Value = BE.pdscto;
                        ////cmd.Parameters.Add("@bruto1", SqlDbType.Decimal).Value = BE.bruto1;
                        ////cmd.Parameters.Add("@dsctopropio1", SqlDbType.Decimal).Value = BE.dsctopropio1;
                        ////cmd.Parameters.Add("@dsctoconvenio1", SqlDbType.Decimal).Value = BE.dsctoconvenio1;
                        ////cmd.Parameters.Add("@dsctototal1", SqlDbType.Decimal).Value = BE.dsctototal1;
                        ////cmd.Parameters.Add("@baseimpo1", SqlDbType.Decimal).Value = BE.baseimpo1;
                        ////cmd.Parameters.Add("@montoigv1", SqlDbType.Decimal).Value = BE.montoigv1;
                        ////cmd.Parameters.Add("@precioventa1", SqlDbType.Decimal).Value = BE.precioventa1;
                        ////cmd.Parameters.Add("@bruto2", SqlDbType.Decimal).Value = BE.bruto2;
                        ////cmd.Parameters.Add("@dsctopropio2", SqlDbType.Decimal).Value = BE.dsctopropio2;
                        ////cmd.Parameters.Add("@dsctoconvenio2", SqlDbType.Decimal).Value = BE.dsctoconvenio2;
                        ////cmd.Parameters.Add("@dsctototal2", SqlDbType.Decimal).Value = BE.dsctototal2;
                        ////cmd.Parameters.Add("@baseimpo2", SqlDbType.Decimal).Value = BE.baseimpo2;
                        ////cmd.Parameters.Add("@montoigv2", SqlDbType.Decimal).Value = BE.montoigv2;
                        ////cmd.Parameters.Add("@precioventa2", SqlDbType.Decimal).Value = BE.precioventa2;
                        //cmd.Parameters.Add("@promoidlist", SqlDbType.Char, 20).Value = BE.promoidlist;
                        //cmd.Parameters.Add("@tarjbonus", SqlDbType.Char, 13).Value = BE.tarjbonus;
                        ////cmd.Parameters.Add("@tarjetaid", SqlDbType.Int).Value = BE.tarjetaid;
                        ////cmd.Parameters.Add("@tarjgrupoid", SqlDbType.Int).Value = BE.tarjgrupoid;
                        //cmd.Parameters.Add("@tarjnumoper", SqlDbType.Char, 3).Value = BE.tarjnumoper;
                        ////cmd.Parameters.Add("@tarjimporte1", SqlDbType.Decimal).Value = BE.tarjimporte1;
                        ////cmd.Parameters.Add("@tarjimporte2", SqlDbType.Decimal).Value = BE.tarjimporte2;
                        //cmd.Parameters.Add("@motivotrasladoid", SqlDbType.Char, 2).Value = BE.motivotrasladoid;
                        //cmd.Parameters.Add("@mottrasladointid", SqlDbType.Char, 2).Value = BE.mottrasladointid;
                        //cmd.Parameters.Add("@transpid", SqlDbType.Char, 5).Value = BE.transpid;
                        //cmd.Parameters.Add("@fechinitras", SqlDbType.DateTime).Value = BE.fechinitras;
                        //cmd.Parameters.Add("@estabsunat", SqlDbType.Char, 4).Value = BE.estabsunat;
                        //cmd.Parameters.Add("@cajanume", SqlDbType.Char, 2).Value = BE.cajanume;
                        //cmd.Parameters.Add("@ticketeraid", SqlDbType.Char, 15).Value = BE.ticketeraid;
                        ////cmd.Parameters.Add("@efectivo", SqlDbType.Decimal).Value = BE.efectivo;
                        ////cmd.Parameters.Add("@vuelto", SqlDbType.Decimal).Value = BE.vuelto;                       
                        //cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendedorid;
                        //cmd.Parameters.Add("@vinculante", SqlDbType.Char, 1).Value = BE.vinculante;
                        //cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    }
                    try
                    {
                        cnx.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                        }
                        return ds;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public DataSet RenameVenta(string empresaid, tb_co_Factura BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_RenameRegVentas", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@periodo", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@regmes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@regdiario", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@regnumero", SqlDbType.Char, 8).Value = BE.asiento;
                        cmd.Parameters.Add("@regmesnuevo", SqlDbType.Char, 2).Value = BE.regmesnuevo;
                        cmd.Parameters.Add("@regdiarionuevo", SqlDbType.Char, 4).Value = BE.regdiarionuevo;
                        cmd.Parameters.Add("@regnumeronuevo", SqlDbType.Char, 8).Value = BE.regnumeronuevo;
                    }
                    try
                    {
                        cnx.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                        }
                        return ds;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
        public DataSet ReporteRegistroVenta(string empresaid, tb_co_Factura BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd1 = new SqlCommand("gspTbCoMovimientos_ReporteRegistroVenta", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd1.Parameters.Add("@fechaini", SqlDbType.Char, 8).Value = BE.fechaini;
                        cmd1.Parameters.Add("@fechafin", SqlDbType.Char, 8).Value = BE.fechafin;
                        cmd1.Parameters.Add("@tipoventa", SqlDbType.Char, 2).Value = BE.tipoventa;
                        cmd1.Parameters.Add("@rubroid", SqlDbType.Char, 4).Value = BE.rubroid;
                        cmd1.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        cmd1.Parameters.Add("@nquiebre", SqlDbType.Int).Value = BE.nquiebre;
                        cmd1.Parameters.Add("@norden", SqlDbType.Int).Value = BE.norden;
                        cmd1.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd1.Parameters.Add("@resumen", SqlDbType.Int).Value = BE.resumen;
                        cmd1.Parameters.Add("@nestado", SqlDbType.Int).Value = BE.nestado;
                        cmd1.Parameters.Add("@fimpresion", SqlDbType.Char, 8).Value = BE.fimpresion;
                    }
                    try
                    {
                        cnx.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
                        {
                            da.Fill(ds);
                        }
                        return ds;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public DataSet GetAllIncoterms_Cab(string empresaid, tb_co_Factura BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoIncoterms_consulta", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@codigoid", string.IsNullOrEmpty(BE.codigoid) ? (object)DBNull.Value : BE.codigoid);
                        cmd.Parameters.AddWithValue("@sigla", string.IsNullOrEmpty(BE.sigla) ? (object)DBNull.Value : BE.sigla);
                        cmd.Parameters.AddWithValue("@norden", SqlDbType.Int).Value = BE.norden;
                        cmd.Parameters.AddWithValue("@incluir_blanco", SqlDbType.Int).Value = BE.incluir_blanco;
                    }
                    try
                    {
                        cnx.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                        }
                        return ds;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
        public DataSet GetAllIncoterms_Det(string empresaid, tb_co_Factura BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoIncoterms_consulta_det", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@codigoid", string.IsNullOrEmpty(BE.codigoid) ? (object)DBNull.Value : BE.codigoid);
                        cmd.Parameters.AddWithValue("@sigla", string.IsNullOrEmpty(BE.sigla) ? (object)DBNull.Value : BE.sigla);
                    }
                    try
                    {
                        cnx.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                        }
                        return ds;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        #region *** validar fecha en formato correcto
        public DateTime fecha(DateTime pfecha)
        {
            //string dia = pfecha.Day.ToString();
            //string mes = pfecha.Month.ToString();
            //string anio = pfecha.Year.ToString();
            //string fecha = anio + "-" + mes + "-" + dia;
            DateTime lfech;
            //DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
            //IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
            if (pfecha != null)
            {
                if (pfecha != DateTime.Parse("01/01/0001 12:00:00 a.m."))
                {
                    lfech = pfecha;
                }
                else
                {
                    lfech = DateTime.Parse("01/01/1900");
                }
            }
            else
            {
                lfech = DateTime.Parse("01/01/1900");
            }

            return lfech;
        }

        public DateTime fecha02(DateTime pfecha)
        {
            String lfech;
            IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
            if (pfecha != null)
            {
                if (pfecha != DateTime.Parse("01/01/0001 12:00:00 a.m.", culture, System.Globalization.DateTimeStyles.AssumeLocal))
                {
                    lfech = pfecha.ToString();
                }
                else
                {
                    lfech = DateTime.Parse("01/01/1900 12:00:00 a.m.").ToString();
                }
            }
            else
            {
                lfech = DateTime.Parse("01/01/1900 12:00:00 a.m.").ToString();
            }
            return DateTime.Parse(lfech, culture, System.Globalization.DateTimeStyles.AssumeLocal);
        }
        #endregion
    }
}
