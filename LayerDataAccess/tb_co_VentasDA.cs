using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_co_VentasDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_co_Ventas BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoVentas_INSERT", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                    cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;  
                    cmd.Parameters.Add("@origen", SqlDbType.Char, 2).Value = BE.origen;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
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
                    cmd.Parameters.Add("@terminovta", SqlDbType.VarChar, 50).Value = BE.terminovta;
                    cmd.Parameters.Add("@dpais", SqlDbType.VarChar, 50).Value = BE.dpais;
                    cmd.Parameters.Add("@embarcador", SqlDbType.VarChar, 50).Value = BE.embarcador;
                    cmd.Parameters.Add("@condicionpago", SqlDbType.VarChar, 50).Value = BE.condicionpago;
                    cmd.Parameters.Add("@cartacredito", SqlDbType.VarChar, 50).Value = BE.cartacredito;
                    cmd.Parameters.Add("@viaembarque", SqlDbType.Char, 2).Value = BE.viaembarque;
                    cmd.Parameters.Add("@referencia", SqlDbType.VarChar, 50).Value = BE.referencia;
                    cmd.Parameters.Add("@bultos", SqlDbType.VarChar, 20).Value = BE.bultos;
                    cmd.Parameters.Add("@pesoneto", SqlDbType.Decimal).Value = BE.pesoneto;
                    cmd.Parameters.Add("@pesobruto", SqlDbType.Decimal).Value = BE.pesobruto;
                    cmd.Parameters.Add("@bruto1", SqlDbType.Decimal).Value = BE.bruto1;
                    cmd.Parameters.Add("@dscto1", SqlDbType.Decimal).Value = BE.dscto1;
                    cmd.Parameters.Add("@valorventa1", SqlDbType.Decimal).Value = BE.valorventa1;
                    cmd.Parameters.Add("@igv1", SqlDbType.Decimal).Value = BE.igv1;
                    cmd.Parameters.Add("@total1", SqlDbType.Decimal).Value = BE.total1;
                    cmd.Parameters.Add("@pdscto", SqlDbType.Decimal).Value = BE.pdscto;
                    cmd.Parameters.Add("@pigv", SqlDbType.Decimal).Value = BE.pigv;
                    cmd.Parameters.Add("@bruto2", SqlDbType.Decimal).Value = BE.bruto2;
                    cmd.Parameters.Add("@dscto2", SqlDbType.Decimal).Value = BE.dscto2;
                    cmd.Parameters.Add("@valorventa2", SqlDbType.Decimal).Value = BE.valorventa2;
                    cmd.Parameters.Add("@igv2", SqlDbType.Decimal).Value = BE.igv2;
                    cmd.Parameters.Add("@total2", SqlDbType.Decimal).Value = BE.total2;
                    cmd.Parameters.Add("@tienda", SqlDbType.Char, 3).Value = BE.tienda;
                    cmd.Parameters.Add("@ndias", SqlDbType.Decimal).Value = BE.ndias;
                    cmd.Parameters.Add("@vendedorid", SqlDbType.Char, 4).Value = BE.vendedorid;
                    cmd.Parameters.Add("@porcvta", SqlDbType.Decimal).Value = BE.porcvta;
                    cmd.Parameters.Add("@porcefect", SqlDbType.Decimal).Value = BE.porcefect;
                    cmd.Parameters.Add("@vinculante", SqlDbType.Char, 3).Value = BE.vinculante;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    cmd.Parameters.Add("@maqreg", SqlDbType.Char, 15).Value = BE.maqreg;
                    cmd.Parameters.Add("@numdocfinal", SqlDbType.Char, 10).Value = BE.numdocfinal;
                    cmd.Parameters.Add("@estabsunat", SqlDbType.Char, 4).Value = BE.estabsunat;

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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public bool Insert_ImportaExcel(string empresaid, tb_co_Ventas BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoVentas_INSERT_ImportaExcel", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                    cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
                    cmd.Parameters.Add("@origen", SqlDbType.Char, 2).Value = BE.origen;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
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
                    cmd.Parameters.Add("@terminovta", SqlDbType.VarChar, 50).Value = BE.terminovta;
                    cmd.Parameters.Add("@dpais", SqlDbType.VarChar, 50).Value = BE.dpais;
                    cmd.Parameters.Add("@embarcador", SqlDbType.VarChar, 50).Value = BE.embarcador;
                    cmd.Parameters.Add("@condicionpago", SqlDbType.VarChar, 50).Value = BE.condicionpago;
                    cmd.Parameters.Add("@cartacredito", SqlDbType.VarChar, 50).Value = BE.cartacredito;
                    cmd.Parameters.Add("@viaembarque", SqlDbType.Char, 2).Value = BE.viaembarque;
                    cmd.Parameters.Add("@referencia", SqlDbType.VarChar, 50).Value = BE.referencia;
                    cmd.Parameters.Add("@bultos", SqlDbType.VarChar, 20).Value = BE.bultos;
                    cmd.Parameters.Add("@pesoneto", SqlDbType.Decimal).Value = BE.pesoneto;
                    cmd.Parameters.Add("@pesobruto", SqlDbType.Decimal).Value = BE.pesobruto;
                    cmd.Parameters.Add("@bruto1", SqlDbType.Decimal).Value = BE.bruto1;
                    cmd.Parameters.Add("@dscto1", SqlDbType.Decimal).Value = BE.dscto1;
                    cmd.Parameters.Add("@valorventa1", SqlDbType.Decimal).Value = BE.valorventa1;
                    cmd.Parameters.Add("@igv1", SqlDbType.Decimal).Value = BE.igv1;
                    cmd.Parameters.Add("@total1", SqlDbType.Decimal).Value = BE.total1;
                    cmd.Parameters.Add("@pdscto", SqlDbType.Decimal).Value = BE.pdscto;
                    cmd.Parameters.Add("@pigv", SqlDbType.Decimal).Value = BE.pigv;
                    cmd.Parameters.Add("@bruto2", SqlDbType.Decimal).Value = BE.bruto2;
                    cmd.Parameters.Add("@dscto2", SqlDbType.Decimal).Value = BE.dscto2;
                    cmd.Parameters.Add("@valorventa2", SqlDbType.Decimal).Value = BE.valorventa2;
                    cmd.Parameters.Add("@igv2", SqlDbType.Decimal).Value = BE.igv2;
                    cmd.Parameters.Add("@total2", SqlDbType.Decimal).Value = BE.total2;
                    cmd.Parameters.Add("@tienda", SqlDbType.Char, 3).Value = BE.tienda;
                    cmd.Parameters.Add("@ndias", SqlDbType.Decimal).Value = BE.ndias;
                    cmd.Parameters.Add("@vendedorid", SqlDbType.Char, 4).Value = BE.vendedorid;
                    cmd.Parameters.Add("@porcvta", SqlDbType.Decimal).Value = BE.porcvta;
                    cmd.Parameters.Add("@porcefect", SqlDbType.Decimal).Value = BE.porcefect;
                    cmd.Parameters.Add("@vinculante", SqlDbType.Char, 3).Value = BE.vinculante;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    cmd.Parameters.Add("@maqreg", SqlDbType.Char, 15).Value = BE.maqreg;
                    cmd.Parameters.Add("@numdocfinal", SqlDbType.Char, 10).Value = BE.numdocfinal;
                    cmd.Parameters.Add("@estabsunat", SqlDbType.Char, 4).Value = BE.estabsunat;

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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public bool DELETE_ImportaExcel(string empresaid, tb_co_Ventas BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoVentas_DELETE_ImportaExcel", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;

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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
        
        public bool Delete(string empresaid, tb_co_Ventas BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("gspTbCoVentas_DELETE", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;

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
                }
                catch (Exception ex)
                {
                    Sql_Error = ex.Message;
                    throw new Exception(ex.Message);
                }
            }
        }

        public bool Update(string empresaid, tb_co_Ventas BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoVentas_UPDATE", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                    cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
                    cmd.Parameters.Add("@origen", SqlDbType.Char, 2).Value = BE.origen;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
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
                    cmd.Parameters.Add("@terminovta", SqlDbType.VarChar, 50).Value = BE.terminovta;
                    cmd.Parameters.Add("@dpais", SqlDbType.VarChar, 50).Value = BE.dpais;
                    cmd.Parameters.Add("@embarcador", SqlDbType.VarChar, 50).Value = BE.embarcador;
                    cmd.Parameters.Add("@condicionpago", SqlDbType.VarChar, 50).Value = BE.condicionpago;
                    cmd.Parameters.Add("@cartacredito", SqlDbType.VarChar, 50).Value = BE.cartacredito;
                    cmd.Parameters.Add("@viaembarque", SqlDbType.Char, 2).Value = BE.viaembarque;
                    cmd.Parameters.Add("@referencia", SqlDbType.VarChar, 50).Value = BE.referencia;
                    cmd.Parameters.Add("@bultos", SqlDbType.VarChar, 20).Value = BE.bultos;
                    cmd.Parameters.Add("@pesoneto", SqlDbType.Decimal).Value = BE.pesoneto;
                    cmd.Parameters.Add("@pesobruto", SqlDbType.Decimal).Value = BE.pesobruto;
                    cmd.Parameters.Add("@bruto1", SqlDbType.Decimal).Value = BE.bruto1;
                    cmd.Parameters.Add("@dscto1", SqlDbType.Decimal).Value = BE.dscto1;
                    cmd.Parameters.Add("@valorventa1", SqlDbType.Decimal).Value = BE.valorventa1;
                    cmd.Parameters.Add("@igv1", SqlDbType.Decimal).Value = BE.igv1;
                    cmd.Parameters.Add("@total1", SqlDbType.Decimal).Value = BE.total1;
                    cmd.Parameters.Add("@pdscto", SqlDbType.Decimal).Value = BE.pdscto;
                    cmd.Parameters.Add("@pigv", SqlDbType.Decimal).Value = BE.pigv;
                    cmd.Parameters.Add("@bruto2", SqlDbType.Decimal).Value = BE.bruto2;
                    cmd.Parameters.Add("@dscto2", SqlDbType.Decimal).Value = BE.dscto2;
                    cmd.Parameters.Add("@valorventa2", SqlDbType.Decimal).Value = BE.valorventa2;
                    cmd.Parameters.Add("@igv2", SqlDbType.Decimal).Value = BE.igv2;
                    cmd.Parameters.Add("@total2", SqlDbType.Decimal).Value = BE.total2;
                    cmd.Parameters.Add("@tienda", SqlDbType.Char, 3).Value = BE.tienda;
                    cmd.Parameters.Add("@ndias", SqlDbType.Decimal).Value = BE.ndias;
                    cmd.Parameters.Add("@vendedorid", SqlDbType.Char, 4).Value = BE.vendedorid;
                    cmd.Parameters.Add("@porcvta", SqlDbType.Decimal).Value = BE.porcvta;
                    cmd.Parameters.Add("@porcefect", SqlDbType.Decimal).Value = BE.porcefect;
                    cmd.Parameters.Add("@vinculante", SqlDbType.Char, 3).Value = BE.vinculante;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    cmd.Parameters.Add("@maqreg", SqlDbType.Char, 15).Value = BE.maqreg;
                    cmd.Parameters.Add("@numdocfinal", SqlDbType.Char, 10).Value = BE.numdocfinal;
                    cmd.Parameters.Add("@estabsunat", SqlDbType.Char, 4).Value = BE.estabsunat;

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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public DataSet RenameVenta(string empresaid, tb_co_Ventas BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_RenameRegVentas", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@periodo", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@regmes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@regdiario", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@regnumero", SqlDbType.Char, 6).Value = BE.asiento;
                        cmd.Parameters.Add("@regmesnuevo", SqlDbType.Char, 2).Value = BE.regmesnuevo;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@regdiarionuevo", SqlDbType.Char, 4).Value = BE.regdiarionuevo;
                        cmd.Parameters.Add("@regnumeronuevo", SqlDbType.Char, 6).Value = BE.regnumeronuevo;
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
        public DataSet ReporteRegistroVenta(string empresaid, tb_co_Ventas BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd1 = new SqlCommand("gspTbCoMovimientos_ReporteRegistroVenta", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd1.CommandTimeout = 0;
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        if (BE.fechaini == "")
                        { cmd1.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd1.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = BE.fechaini; }
                        //cmd1.Parameters.Add("@fechaini", SqlDbType.DateTime).Value = BE.fechaini;
                        if (BE.fechafin == "")
                        { cmd1.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd1.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = BE.fechafin; }
                        //cmd1.Parameters.Add("@fechafin", SqlDbType.DateTime).Value = BE.fechafin;
                        cmd1.Parameters.Add("@tipoventa", SqlDbType.Char, 2).Value = BE.tipoventa;
                        cmd1.Parameters.Add("@rubroid", SqlDbType.Char, 4).Value = BE.rubroid;
                        cmd1.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        cmd1.Parameters.Add("@nquiebre", SqlDbType.Int).Value = BE.nquiebre;
                        cmd1.Parameters.Add("@norden", SqlDbType.Int).Value = BE.norden;
                        cmd1.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd1.Parameters.Add("@resumen", SqlDbType.Int).Value = BE.resumen;
                        cmd1.Parameters.Add("@nestado", SqlDbType.Int).Value = BE.nestado;
                        if (BE.fimpresion == "")
                        { cmd1.Parameters.Add("@fImpresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd1.Parameters.Add("@fImpresion", System.Data.SqlDbType.DateTime).Value = BE.fimpresion; }
                        //cmd1.Parameters.Add("@fimpresion", SqlDbType.Char, 8).Value = BE.fimpresion;
                        cmd1.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd1.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd1.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public DataSet ReporteRegVentaResumen(string empresaid, tb_co_Ventas BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd1 = new SqlCommand("gspTbCoMovimientos_ReporteRegVentaResumenCliente", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd1.CommandTimeout = 0;
                        cmd1.CommandType = CommandType.StoredProcedure;
                        if (BE.fechaini == "")
                        { cmd1.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd1.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = BE.fechaini; }
                        //cmd1.Parameters.Add("@fechaini", SqlDbType.DateTime).Value = BE.fechaini;
                        if (BE.fechafin == "")
                        { cmd1.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd1.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = BE.fechafin; }
                        //cmd1.Parameters.Add("@fechafin", SqlDbType.DateTime).Value = BE.fechafin;
                        cmd1.Parameters.AddWithValue("@Almacen", string.IsNullOrEmpty(BE.almacen) ? (object)DBNull.Value : BE.almacen);
                        cmd1.Parameters.AddWithValue("@tipdoc", string.IsNullOrEmpty(BE.tipdoc) ? (object)DBNull.Value : BE.tipdoc);
                        cmd1.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                        cmd1.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd1.Parameters.Add("@TipoResumen", SqlDbType.Int).Value = BE.resumen;
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
        public DataSet ReporteRegVentaAnalitico(string empresaid, tb_co_Ventas BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd1 = new SqlCommand("gspTbCoMovimientos_ReporteRegVentaAnaliticoCliente", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd1.CommandTimeout = 0;
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        if (BE.fechaini == "")
                        { cmd1.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd1.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = BE.fechaini; }
                        //cmd1.Parameters.Add("@fechaini", SqlDbType.DateTime).Value = BE.fechaini;
                        if (BE.fechafin == "")
                        { cmd1.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd1.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = BE.fechafin; }
                        //cmd1.Parameters.Add("@fechafin", SqlDbType.DateTime).Value = BE.fechafin;
                        cmd1.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                        cmd1.Parameters.AddWithValue("@tipdoc", string.IsNullOrEmpty(BE.tipdoc) ? (object)DBNull.Value : BE.tipdoc);
                        cmd1.Parameters.AddWithValue("@productid", string.IsNullOrEmpty(BE.productid) ? (object)DBNull.Value : BE.productid);
                        cmd1.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd1.Parameters.Add("@considerar_docs_sin_producto", SqlDbType.Int).Value = BE.considerar_docs_sin_producto;
                        cmd1.Parameters.Add("@quiebre", SqlDbType.Int).Value = BE.nquiebre;
                        cmd1.Parameters.Add("@orden", SqlDbType.Int).Value = BE.norden;
                        cmd1.Parameters.Add("@docidint", SqlDbType.Char).Value = BE.tipdid;
                        //cmd1.Parameters.Add("@cencosid", SqlDbType.Char, 11).Value = BE.cencosid;
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public DataSet GetGeneraPDT3550(string empresaid, tb_co_Ventas BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_DetalleOperaciones3550", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
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
                        Sql_Error = ex.Message;
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
