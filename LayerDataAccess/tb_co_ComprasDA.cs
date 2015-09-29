using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_co_ComprasDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_co_Compras BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd1 = new SqlCommand("gspTbCoCompras_INSERT", cnx))
                {
                    cmd1.CommandTimeout = 0;
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd1.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd1.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd1.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd1.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                    cmd1.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
                    cmd1.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                    cmd1.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd1.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd1.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd1.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                    cmd1.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd1.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                    cmd1.Parameters.Add("@direc", SqlDbType.VarChar, 70).Value = BE.direc;
                    cmd1.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE.ubige;
                    cmd1.Parameters.Add("@tipdid", SqlDbType.Char, 1).Value = BE.tipdid;
                    cmd1.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                    cmd1.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                    cmd1.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                    cmd1.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                    cmd1.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE.fechref;
                    cmd1.Parameters.Add("@tipOp", SqlDbType.Char, 2).Value = BE.tipOp;
                    cmd1.Parameters.Add("@serOp", SqlDbType.Char, 4).Value = BE.serOp;
                    cmd1.Parameters.Add("@numOp", SqlDbType.Char, 10).Value = BE.numOp;
                    cmd1.Parameters.Add("@arrayguias", SqlDbType.VarChar, 80).Value = BE.arrayguias;
                    cmd1.Parameters.Add("@arrayfechasguia", SqlDbType.VarChar, 50).Value = BE.arrayfechasguia;
                    cmd1.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                    cmd1.Parameters.Add("@compradorid", SqlDbType.Char, 4).Value = BE.compradorid;
                    cmd1.Parameters.Add("@condcompraid", SqlDbType.Char, 4).Value = BE.condcompraid;
                    cmd1.Parameters.Add("@bruto", SqlDbType.Decimal).Value = BE.bruto;
                    cmd1.Parameters.Add("@dscto3", SqlDbType.Decimal).Value = BE.dscto3;
                    cmd1.Parameters.Add("@totdscto3", SqlDbType.Decimal).Value = BE.totdscto3;
                    cmd1.Parameters.Add("@transporte", SqlDbType.Decimal).Value = BE.transporte;
                    cmd1.Parameters.Add("@embalaje", SqlDbType.Decimal).Value = BE.embalaje;
                    cmd1.Parameters.Add("@otros", SqlDbType.Decimal).Value = BE.otros;
                    cmd1.Parameters.Add("@tipimptoid", SqlDbType.Char, 1).Value = BE.tipimptoid;
                    cmd1.Parameters.Add("@igv", SqlDbType.Decimal).Value = BE.igv;
                    cmd1.Parameters.Add("@incprec", SqlDbType.Bit ).Value = BE.incprec;
                    cmd1.Parameters.Add("@impexo", SqlDbType.Decimal).Value=BE.impexo ;
                    cmd1.Parameters.Add("@valorcompra1", SqlDbType.Decimal).Value = BE.valorcompra1;
                    cmd1.Parameters.Add("@igv1", SqlDbType.Decimal).Value = BE.igv1;
                    cmd1.Parameters.Add("@cargo", SqlDbType.Decimal).Value = BE.cargo;
                    cmd1.Parameters.Add("@preciocompra1", SqlDbType.Decimal).Value = BE.preciocompra1;
                    cmd1.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                    cmd1.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb ;
                    cmd1.Parameters.Add("@codctadebe", SqlDbType.Char,10).Value = BE.codctadebe;
                    cmd1.Parameters.Add("@tipoid", SqlDbType.Char,2).Value = BE.tipoid;
                    cmd1.Parameters.Add("@glosa", SqlDbType.VarChar,100).Value = BE.glosa;
                    cmd1.Parameters.Add("@totpzas", SqlDbType.Decimal).Value = BE.totpzas;
                    cmd1.Parameters.Add("@fechentrega", SqlDbType.DateTime).Value = BE.fechentrega;
                    cmd1.Parameters.Add("@fechpago", SqlDbType.DateTime).Value = BE.fechpago;
                    cmd1.Parameters.Add("@fechcancel", SqlDbType.DateTime).Value = BE.fechcancel;
                    cmd1.Parameters.Add("@modofactu", SqlDbType.Char, 1).Value = BE.modofactu;
                    cmd1.Parameters.Add("@items", SqlDbType.Decimal).Value = BE.items;
                    cmd1.Parameters.Add("@fechregistro", SqlDbType.DateTime).Value = BE.fechregistro;
                    cmd1.Parameters.Add("@vinculante", SqlDbType.Char, 1).Value = BE.vinculante;
                    cmd1.Parameters.Add("@origen", SqlDbType.Char,2).Value = BE.origen;
                    cmd1.Parameters.Add("@afecdetraccion", SqlDbType.Bit ).Value = BE.afecdetraccion;
                    cmd1.Parameters.Add("@nconstdetrac", SqlDbType.Char,10).Value = BE.nconstdetrac;
                    cmd1.Parameters.Add("@fechconstdetrac", SqlDbType.DateTime).Value = BE.fechconstdetrac;
                    cmd1.Parameters.Add("@detraccionid", SqlDbType.Char,5).Value = BE.detraccionid;
                    cmd1.Parameters.Add("@porcdetraccion", SqlDbType.Decimal).Value= BE.porcdetraccion;
                    cmd1.Parameters.Add("@bnctadetraccion", SqlDbType.VarChar,40).Value = BE.bnctadetraccion;
                    cmd1.Parameters.Add("@afectretencion", SqlDbType.Bit ).Value = BE.afectretencion;
                    cmd1.Parameters.Add("@afecpercepcion", SqlDbType.Bit ).Value = BE.afecpercepcion;
                    cmd1.Parameters.Add("@serdocpercepcion", SqlDbType.Char,4).Value = BE.serdocpercepcion;
                    cmd1.Parameters.Add("@numdocpercepcion", SqlDbType.Char,10).Value = BE.numdocpercepcion;
                    cmd1.Parameters.Add("@percepcionid", SqlDbType.Char,2).Value = BE.percepcionid;
                    cmd1.Parameters.Add("@afectoigvid", SqlDbType.Bit ).Value = BE.afectoigvid;
                    cmd1.Parameters.Add("@aduanaid", SqlDbType.Char,3).Value = BE.aduanaid;
                    cmd1.Parameters.Add("@aniodua", SqlDbType.Char,4).Value = BE.aniodua;
                    cmd1.Parameters.Add("@numdua", SqlDbType.Char,10).Value = BE.numdua;
                    cmd1.Parameters.Add("@fechembdua", SqlDbType.DateTime).Value = BE.fechembdua;
                    cmd1.Parameters.Add("@fechreguldua", SqlDbType.DateTime).Value = BE.fechreguldua;
                    cmd1.Parameters.Add("@valorfobdua", SqlDbType.Decimal).Value = BE.valorfobdua;
                    cmd1.Parameters.Add("@tipoexportid", SqlDbType.Char, 2).Value = BE.tipoexportid;
                    cmd1.Parameters.Add("@valor2", SqlDbType.Decimal).Value = BE.valor2;
                    cmd1.Parameters.Add("@dscto2", SqlDbType.Decimal).Value = BE.dscto2;
                    cmd1.Parameters.Add("@impexo2", SqlDbType.Decimal).Value = BE.impexo2;
                    cmd1.Parameters.Add("@valorcompra2", SqlDbType.Decimal).Value = BE.valorcompra2;
                    cmd1.Parameters.Add("@igv2", SqlDbType.Decimal).Value = BE.igv2;
                    cmd1.Parameters.Add("@preciocompra2", SqlDbType.Decimal).Value = BE.preciocompra2;
                    cmd1.Parameters.Add("@tipersona", SqlDbType.Char, 2).Value = BE.tipersona;
                    cmd1.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;

                    cmd1.Parameters.Add("@XML", SqlDbType.Xml).Value = BE.GetItemXML();

                    try
                    {
                        cnx.Open();
                        if (cmd1.ExecuteNonQuery() > 0)
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

        public bool Insert_ImportaExcel(string empresaid, tb_co_Compras BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd1 = new SqlCommand("gspTbCoCompras_INSERT_ImportaExcel", cnx))
                {
                    cmd1.CommandTimeout = 0;
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd1.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd1.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd1.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd1.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                    cmd1.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
                    cmd1.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                    cmd1.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd1.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd1.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd1.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                    cmd1.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd1.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                    cmd1.Parameters.Add("@direc", SqlDbType.VarChar, 70).Value = BE.direc;
                    cmd1.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE.ubige;
                    cmd1.Parameters.Add("@tipdid", SqlDbType.Char, 1).Value = BE.tipdid;
                    cmd1.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                    cmd1.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                    cmd1.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                    cmd1.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                    cmd1.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE.fechref;
                    cmd1.Parameters.Add("@tipOp", SqlDbType.Char, 2).Value = BE.tipOp;
                    cmd1.Parameters.Add("@serOp", SqlDbType.Char, 4).Value = BE.serOp;
                    cmd1.Parameters.Add("@numOp", SqlDbType.Char, 10).Value = BE.numOp;
                    cmd1.Parameters.Add("@arrayguias", SqlDbType.VarChar, 80).Value = BE.arrayguias;
                    cmd1.Parameters.Add("@arrayfechasguia", SqlDbType.VarChar, 50).Value = BE.arrayfechasguia;
                    cmd1.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                    cmd1.Parameters.Add("@compradorid", SqlDbType.Char, 4).Value = BE.compradorid;
                    cmd1.Parameters.Add("@condcompraid", SqlDbType.Char, 4).Value = BE.condcompraid;
                    cmd1.Parameters.Add("@bruto", SqlDbType.Decimal).Value = BE.bruto;
                    cmd1.Parameters.Add("@dscto3", SqlDbType.Decimal).Value = BE.dscto3;
                    cmd1.Parameters.Add("@totdscto3", SqlDbType.Decimal).Value = BE.totdscto3;
                    cmd1.Parameters.Add("@transporte", SqlDbType.Decimal).Value = BE.transporte;
                    cmd1.Parameters.Add("@embalaje", SqlDbType.Decimal).Value = BE.embalaje;
                    cmd1.Parameters.Add("@otros", SqlDbType.Decimal).Value = BE.otros;
                    cmd1.Parameters.Add("@tipimptoid", SqlDbType.Char, 1).Value = BE.tipimptoid;
                    cmd1.Parameters.Add("@igv", SqlDbType.Decimal).Value = BE.igv;
                    cmd1.Parameters.Add("@incprec", SqlDbType.Bit).Value = BE.incprec;
                    cmd1.Parameters.Add("@impexo", SqlDbType.Decimal).Value = BE.impexo;
                    cmd1.Parameters.Add("@valorcompra1", SqlDbType.Decimal).Value = BE.valorcompra1;
                    cmd1.Parameters.Add("@igv1", SqlDbType.Decimal).Value = BE.igv1;
                    cmd1.Parameters.Add("@cargo", SqlDbType.Decimal).Value = BE.cargo;
                    cmd1.Parameters.Add("@preciocompra1", SqlDbType.Decimal).Value = BE.preciocompra1;
                    cmd1.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                    cmd1.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                    cmd1.Parameters.Add("@codctadebe", SqlDbType.Char, 10).Value = BE.codctadebe;
                    cmd1.Parameters.Add("@tipoid", SqlDbType.Char, 2).Value = BE.tipoid;
                    cmd1.Parameters.Add("@glosa", SqlDbType.VarChar, 100).Value = BE.glosa;
                    cmd1.Parameters.Add("@totpzas", SqlDbType.Decimal).Value = BE.totpzas;
                    cmd1.Parameters.Add("@fechentrega", SqlDbType.DateTime).Value = BE.fechentrega;
                    cmd1.Parameters.Add("@fechpago", SqlDbType.DateTime).Value = BE.fechpago;
                    cmd1.Parameters.Add("@fechcancel", SqlDbType.DateTime).Value = BE.fechcancel;
                    cmd1.Parameters.Add("@modofactu", SqlDbType.Char, 1).Value = BE.modofactu;
                    cmd1.Parameters.Add("@items", SqlDbType.Decimal).Value = BE.items;
                    cmd1.Parameters.Add("@fechregistro", SqlDbType.DateTime).Value = BE.fechregistro;
                    cmd1.Parameters.Add("@vinculante", SqlDbType.Char, 1).Value = BE.vinculante;
                    cmd1.Parameters.Add("@origen", SqlDbType.Char, 2).Value = BE.origen;
                    cmd1.Parameters.Add("@afecdetraccion", SqlDbType.Bit).Value = BE.afecdetraccion;
                    cmd1.Parameters.Add("@nconstdetrac", SqlDbType.Char, 10).Value = BE.nconstdetrac;
                    cmd1.Parameters.Add("@fechconstdetrac", SqlDbType.DateTime).Value = BE.fechconstdetrac;
                    cmd1.Parameters.Add("@detraccionid", SqlDbType.Char, 5).Value = BE.detraccionid;
                    cmd1.Parameters.Add("@porcdetraccion", SqlDbType.Decimal).Value = BE.porcdetraccion;
                    cmd1.Parameters.Add("@bnctadetraccion", SqlDbType.VarChar, 40).Value = BE.bnctadetraccion;
                    cmd1.Parameters.Add("@afectretencion", SqlDbType.Bit).Value = BE.afectretencion;
                    cmd1.Parameters.Add("@afecpercepcion", SqlDbType.Bit).Value = BE.afecpercepcion;
                    cmd1.Parameters.Add("@serdocpercepcion", SqlDbType.Char, 4).Value = BE.serdocpercepcion;
                    cmd1.Parameters.Add("@numdocpercepcion", SqlDbType.Char, 10).Value = BE.numdocpercepcion;
                    cmd1.Parameters.Add("@percepcionid", SqlDbType.Char, 2).Value = BE.percepcionid;
                    cmd1.Parameters.Add("@afectoigvid", SqlDbType.Bit).Value = BE.afectoigvid;
                    cmd1.Parameters.Add("@aduanaid", SqlDbType.Char, 3).Value = BE.aduanaid;
                    cmd1.Parameters.Add("@aniodua", SqlDbType.Char, 4).Value = BE.aniodua;
                    cmd1.Parameters.Add("@numdua", SqlDbType.Char, 10).Value = BE.numdua;
                    cmd1.Parameters.Add("@fechembdua", SqlDbType.DateTime).Value = BE.fechembdua;
                    cmd1.Parameters.Add("@fechreguldua", SqlDbType.DateTime).Value = BE.fechreguldua;
                    cmd1.Parameters.Add("@valorfobdua", SqlDbType.Decimal).Value = BE.valorfobdua;
                    cmd1.Parameters.Add("@tipoexportid", SqlDbType.Char, 2).Value = BE.tipoexportid;
                    cmd1.Parameters.Add("@valor2", SqlDbType.Decimal).Value = BE.valor2;
                    cmd1.Parameters.Add("@dscto2", SqlDbType.Decimal).Value = BE.dscto2;
                    cmd1.Parameters.Add("@impexo2", SqlDbType.Decimal).Value = BE.impexo2;
                    cmd1.Parameters.Add("@valorcompra2", SqlDbType.Decimal).Value = BE.valorcompra2;
                    cmd1.Parameters.Add("@igv2", SqlDbType.Decimal).Value = BE.igv2;
                    cmd1.Parameters.Add("@preciocompra2", SqlDbType.Decimal).Value = BE.preciocompra2;
                    cmd1.Parameters.Add("@tipersona", SqlDbType.Char, 2).Value = BE.tipersona;
                    cmd1.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;

                    cmd1.Parameters.Add("@XML", SqlDbType.Xml).Value = BE.GetItemXML();

                    try
                    {
                        cnx.Open();
                        if (cmd1.ExecuteNonQuery() > 0)
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

        public bool DELETE_ImportaExcel(string empresaid, tb_co_Compras BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoCompras_DELETE_ImportaExcel", cnx))
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

        public bool Update(string empresaid, tb_co_Compras BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd1 = new SqlCommand("gspTbCoCompras_UPDATE", cnx))
                {
                    cmd1.CommandTimeout = 0;
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd1.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd1.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd1.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd1.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                    cmd1.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
                    cmd1.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                    cmd1.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd1.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd1.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd1.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                    cmd1.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd1.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                    cmd1.Parameters.Add("@direc", SqlDbType.VarChar, 70).Value = BE.direc;
                    cmd1.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE.ubige;
                    cmd1.Parameters.Add("@tipdid", SqlDbType.Char, 1).Value = BE.tipdid;
                    cmd1.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                    cmd1.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                    cmd1.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                    cmd1.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                    cmd1.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE.fechref;
                    cmd1.Parameters.Add("@tipOp", SqlDbType.Char, 2).Value = BE.tipOp;
                    cmd1.Parameters.Add("@serOp", SqlDbType.Char, 4).Value = BE.serOp;
                    cmd1.Parameters.Add("@numOp", SqlDbType.Char, 10).Value = BE.numOp;
                    cmd1.Parameters.Add("@arrayguias", SqlDbType.VarChar, 80).Value = BE.arrayguias;
                    cmd1.Parameters.Add("@arrayfechasguia", SqlDbType.VarChar, 50).Value = BE.arrayfechasguia;
                    cmd1.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                    cmd1.Parameters.Add("@compradorid", SqlDbType.Char, 4).Value = BE.compradorid;
                    cmd1.Parameters.Add("@condcompraid", SqlDbType.Char, 4).Value = BE.condcompraid;
                    cmd1.Parameters.Add("@bruto", SqlDbType.Decimal).Value = BE.bruto;
                    cmd1.Parameters.Add("@dscto3", SqlDbType.Decimal).Value = BE.dscto3;
                    cmd1.Parameters.Add("@totdscto3", SqlDbType.Decimal).Value = BE.totdscto3;
                    cmd1.Parameters.Add("@transporte", SqlDbType.Decimal).Value = BE.transporte;
                    cmd1.Parameters.Add("@embalaje", SqlDbType.Decimal).Value = BE.embalaje;
                    cmd1.Parameters.Add("@otros", SqlDbType.Decimal).Value = BE.otros;
                    cmd1.Parameters.Add("@tipimptoid", SqlDbType.Char, 1).Value = BE.tipimptoid;
                    cmd1.Parameters.Add("@igv", SqlDbType.Decimal).Value = BE.igv;
                    cmd1.Parameters.Add("@incprec", SqlDbType.Bit).Value = BE.incprec;
                    cmd1.Parameters.Add("@impexo", SqlDbType.Decimal).Value = BE.impexo;
                    cmd1.Parameters.Add("@valorcompra1", SqlDbType.Decimal).Value = BE.valorcompra1;
                    cmd1.Parameters.Add("@igv1", SqlDbType.Decimal).Value = BE.igv1;
                    cmd1.Parameters.Add("@cargo", SqlDbType.Decimal).Value = BE.cargo;
                    cmd1.Parameters.Add("@preciocompra1", SqlDbType.Decimal).Value = BE.preciocompra1;
                    cmd1.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                    cmd1.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                    cmd1.Parameters.Add("@codctadebe", SqlDbType.Char, 10).Value = BE.codctadebe;
                    cmd1.Parameters.Add("@tipoid", SqlDbType.Char, 2).Value = BE.tipoid;
                    cmd1.Parameters.Add("@glosa", SqlDbType.VarChar, 100).Value = BE.glosa;
                    cmd1.Parameters.Add("@totpzas", SqlDbType.Decimal).Value = BE.totpzas;
                    cmd1.Parameters.Add("@fechentrega", SqlDbType.DateTime).Value = BE.fechentrega;
                    cmd1.Parameters.Add("@fechpago", SqlDbType.DateTime).Value = BE.fechpago;
                    cmd1.Parameters.Add("@fechcancel", SqlDbType.DateTime).Value = BE.fechcancel;
                    cmd1.Parameters.Add("@modofactu", SqlDbType.Char, 1).Value = BE.modofactu;
                    cmd1.Parameters.Add("@items", SqlDbType.Decimal).Value = BE.items;
                    cmd1.Parameters.Add("@fechregistro", SqlDbType.DateTime).Value = BE.fechregistro;
                    cmd1.Parameters.Add("@vinculante", SqlDbType.Char, 1).Value = BE.vinculante;
                    cmd1.Parameters.Add("@origen", SqlDbType.Char, 2).Value = BE.origen;
                    cmd1.Parameters.Add("@afecdetraccion", SqlDbType.Bit).Value = BE.afecdetraccion;
                    cmd1.Parameters.Add("@nconstdetrac", SqlDbType.Char, 10).Value = BE.nconstdetrac;
                    cmd1.Parameters.Add("@fechconstdetrac", SqlDbType.DateTime).Value = BE.fechconstdetrac;
                    cmd1.Parameters.Add("@detraccionid", SqlDbType.Char, 5).Value = BE.detraccionid;
                    cmd1.Parameters.Add("@porcdetraccion", SqlDbType.Decimal).Value = BE.porcdetraccion;
                    cmd1.Parameters.Add("@bnctadetraccion", SqlDbType.VarChar, 40).Value = BE.bnctadetraccion;
                    cmd1.Parameters.Add("@afectretencion", SqlDbType.Bit).Value = BE.afectretencion;
                    cmd1.Parameters.Add("@afecpercepcion", SqlDbType.Bit).Value = BE.afecpercepcion;
                    cmd1.Parameters.Add("@serdocpercepcion", SqlDbType.Char, 4).Value = BE.serdocpercepcion;
                    cmd1.Parameters.Add("@numdocpercepcion", SqlDbType.Char, 10).Value = BE.numdocpercepcion;
                    cmd1.Parameters.Add("@percepcionid", SqlDbType.Char, 2).Value = BE.percepcionid;
                    cmd1.Parameters.Add("@afectoigvid", SqlDbType.Bit).Value = BE.afectoigvid;
                    cmd1.Parameters.Add("@aduanaid", SqlDbType.Char, 3).Value = BE.aduanaid;
                    cmd1.Parameters.Add("@aniodua", SqlDbType.Char, 4).Value = BE.aniodua;
                    cmd1.Parameters.Add("@numdua", SqlDbType.Char, 10).Value = BE.numdua;
                    cmd1.Parameters.Add("@fechembdua", SqlDbType.DateTime).Value = BE.fechembdua;
                    cmd1.Parameters.Add("@fechreguldua", SqlDbType.DateTime).Value = BE.fechreguldua;
                    cmd1.Parameters.Add("@valorfobdua", SqlDbType.Decimal).Value = BE.valorfobdua;
                    cmd1.Parameters.Add("@tipoexportid", SqlDbType.Char, 2).Value = BE.tipoexportid;
                    cmd1.Parameters.Add("@valor2", SqlDbType.Decimal).Value = BE.valor2;
                    cmd1.Parameters.Add("@dscto2", SqlDbType.Decimal).Value = BE.dscto2;
                    cmd1.Parameters.Add("@impexo2", SqlDbType.Decimal).Value = BE.impexo2;
                    cmd1.Parameters.Add("@valorcompra2", SqlDbType.Decimal).Value = BE.valorcompra2;
                    cmd1.Parameters.Add("@igv2", SqlDbType.Decimal).Value = BE.igv2;
                    cmd1.Parameters.Add("@preciocompra2", SqlDbType.Decimal).Value = BE.preciocompra2;
                    cmd1.Parameters.Add("@tipersona", SqlDbType.Char, 2).Value = BE.tipersona;
                    cmd1.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;

                    cmd1.Parameters.Add("@XML", SqlDbType.Xml).Value = BE.GetItemXML();

                    try
                    {
                        cnx.Open();
                        if (cmd1.ExecuteNonQuery() > 0)
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

        public bool Delete(string empresaid, tb_co_Compras BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("gspTbCoCompras_DELETE", cnx))
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

        public DataSet RenameCompra(string empresaid, tb_co_Compras BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd1 = new SqlCommand("gspTbCoMovimientos_RenameRegCompras", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd1.CommandTimeout = 0;
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.Add("@periodo", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd1.Parameters.Add("@regmes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd1.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd1.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd1.Parameters.Add("@regdiario", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd1.Parameters.Add("@regnumero", SqlDbType.Char, 6).Value = BE.asiento;

                        cmd1.Parameters.Add("@regmesnuevo", SqlDbType.Char, 2).Value = BE.regmesnuevo;
                        cmd1.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd1.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd1.Parameters.Add("@regdiarionuevo", SqlDbType.Char, 4).Value = BE.regdiarionuevo;
                        cmd1.Parameters.Add("@regnumeronuevo", SqlDbType.Char, 6).Value = BE.regnumeronuevo;
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

        public DataSet ReporteRegistroCompra(string empresaid, tb_co_Compras BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd1 = new SqlCommand("gspTbCoMovimientos_ReporteRegistroCompra", cnx))
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
                        cmd1.Parameters.Add("@tipocompra", SqlDbType.Char, 2).Value = BE.tipoid;
                        cmd1.Parameters.Add("@rubroid", SqlDbType.Char, 4).Value = BE.rubroid;
                        cmd1.Parameters.Add("@excl_bventa", SqlDbType.Int).Value = BE.excl_bventa;
                        cmd1.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd1.Parameters.Add("@norden", SqlDbType.Int).Value = BE.norden;
                        cmd1.Parameters.Add("@nquiebre", SqlDbType.Int).Value = BE.nquiebre;
                        cmd1.Parameters.Add("@resumen", SqlDbType.Int).Value = BE.resumen;
                        cmd1.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd1.Parameters.Add("@ntipofecha", SqlDbType.Int).Value = BE.ntipofecha;
                        cmd1.Parameters.Add("@nestado", SqlDbType.Int).Value = BE.nestado;
                        if (BE.fimpresion == "")
                        { cmd1.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd1.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = BE.fimpresion; }
                        //cmd1.Parameters.AddWithValue("@fimpresion", string.IsNullOrEmpty(BE.fimpresion) ? (object)DBNull.Value : BE.fimpresion);
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
        public DataSet ReporteRegCompraAux(string empresaid, tb_co_Compras BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd1 = new SqlCommand("gspTbCoMovimientos_ReporteRegCompraAux", cnx))
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
                        cmd1.Parameters.Add("@rubroid", SqlDbType.Char, 4).Value = BE.rubroid;
                        cmd1.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                        cmd1.Parameters.Add("@cencosid", SqlDbType.Char, 11).Value = BE.cencosid;
                        cmd1.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd1.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd1.Parameters.Add("@norden", SqlDbType.Int).Value = BE.norden;
                        cmd1.Parameters.Add("@nquiebre", SqlDbType.Int).Value = BE.nquiebre;
                        cmd1.Parameters.Add("@ntipofecha", SqlDbType.Int).Value = BE.ntipofecha;
                        cmd1.Parameters.Add("@nestado", SqlDbType.Int).Value = BE.nestado;
                        if (BE.fimpresion == "")
                        { cmd1.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd1.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = BE.fimpresion; }
                        //cmd1.Parameters.AddWithValue("@fimpresion", string.IsNullOrEmpty(BE.fimpresion) ? (object)DBNull.Value : BE.fimpresion);
                        cmd1.Parameters.Add("@afecdetraccion", SqlDbType.Bit).Value = BE.afecdetraccion;
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
        public DataSet ReporteRegCompraAnalitico(string empresaid, tb_co_Compras BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd1 = new SqlCommand("gspTbCoMovimientos_ReporteRegComprasAnaliticoProveedor", cnx))
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
                        cmd1.Parameters.AddWithValue("@tipdoc", string.IsNullOrEmpty(BE.tipodoc) ? (object)DBNull.Value : BE.tipodoc);
                        cmd1.Parameters.AddWithValue("@productid", string.IsNullOrEmpty(BE.productid) ? (object)DBNull.Value : BE.productid);
                        cmd1.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd1.Parameters.Add("@considerar_docs_sin_producto", SqlDbType.Int).Value = BE.considerar_docs_sin_producto;
                        cmd1.Parameters.Add("@quiebre", SqlDbType.Int).Value = BE.nquiebre;
                        cmd1.Parameters.Add("@orden", SqlDbType.Int).Value = BE.norden;                       
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
        public DataSet ReporteRegCompraResumen(string empresaid, tb_co_Compras BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd1 = new SqlCommand("gspTbCoMovimientos_ReporteRegCompraResumenProveedor", cnx))
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
                        cmd1.Parameters.AddWithValue("@tipdoc", string.IsNullOrEmpty(BE.tipodoc) ? (object)DBNull.Value : BE.tipodoc);
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
        public DataSet ReporteRegCompraResumen01(string empresaid, tb_co_Compras BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd1 = new SqlCommand("gspTbCoMovimientos_ReporteRegCompraResumenProveedor01", cnx))
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
                        cmd1.Parameters.AddWithValue("@tipdoc", string.IsNullOrEmpty(BE.tipodoc) ? (object)DBNull.Value : BE.tipodoc);
                        cmd1.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                        cmd1.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd1.Parameters.Add("@TipoResumen", SqlDbType.Int).Value = BE.resumen;
                        cmd1.Parameters.AddWithValue("@rubroid", string.IsNullOrEmpty(BE.rubroid) ? (object)DBNull.Value : BE.rubroid);
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
        public DataSet ReporteRegistroCompraDetracciones(string empresaid, tb_co_Compras BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd1 = new SqlCommand("gspTbCoMovimientos_ReporteRegistroCompraDetracciones", cnx))
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
                        if (BE.fechafin == "")
                        { cmd1.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd1.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = BE.fechafin; }
                        cmd1.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd1.Parameters.Add("@norden", SqlDbType.Int).Value = BE.norden;                       
                        cmd1.Parameters.Add("@ntipofecha", SqlDbType.Int).Value = BE.ntipofecha;
                        cmd1.Parameters.Add("@nestado", SqlDbType.Int).Value = BE.nestado;
                        cmd1.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd1.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd1.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd1.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                        cmd1.Parameters.Add("@percepcion", SqlDbType.Int).Value = BE.percepcion;
                        cmd1.Parameters.Add("@excel", SqlDbType.Int).Value = BE.excel;
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

        #region para depurar
        public bool UpdateOLD2(string empresaid, tb_60movimientos BE1, tb_60movimientos BE2, String cabecera)
        {
            //BE1: detalle del documento modificado
            //BE2: detalle del documento original

            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                //SqlTransaction tr = default(SqlTransaction);
                Boolean TransaExito = false;
                string procedimiento;
                if (cabecera == "CAB")
                {
                    procedimiento = "gspTb60Movimientoscab_UPDATE";
                }
                else
                {
                    procedimiento = "gspTb60Movimientoscab_INSERT";
                }

                using (SqlCommand cmd1 = new SqlCommand(procedimiento, cnx))
                {
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE1.moduloid;
                    cmd1.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE1.local;
                    cmd1.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE1.tipodoc;
                    cmd1.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE1.serdoc;
                    cmd1.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE1.numdoc;
                    cmd1.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE1.status;
                    cmd1.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE1.almacaccionid;
                    cmd1.Parameters.Add("@ctacteaccionid", SqlDbType.Char, 2).Value = BE1.ctacteaccionid;
                    cmd1.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE1.fechdoc;
                    cmd1.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE1.ctacte;
                    cmd1.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE1.ctactename;
                    cmd1.Parameters.Add("@direcnume", SqlDbType.Char, 6).Value = BE1.direcnume;
                    cmd1.Parameters.Add("@direcname", SqlDbType.VarChar, 25).Value = BE1.direcname;
                    cmd1.Parameters.Add("@direcdeta", SqlDbType.VarChar, 70).Value = BE1.direcdeta;
                    cmd1.Parameters.Add("@direc", SqlDbType.VarChar, 70).Value = BE1.direc;
                    cmd1.Parameters.Add("@tipdid", SqlDbType.Char, 1).Value = BE1.tipdid;
                    cmd1.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE1.nmruc;
                    cmd1.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE1.tipref;
                    cmd1.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE1.serref;
                    cmd1.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE1.numref;
                    cmd1.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE1.fechref;
                    cmd1.Parameters.Add("@tip_op", SqlDbType.Char, 2).Value = BE1.tip_op;
                    cmd1.Parameters.Add("@ser_op", SqlDbType.Char, 4).Value = BE1.ser_op;
                    cmd1.Parameters.Add("@num_op", SqlDbType.Char, 10).Value = BE1.num_op;
                    cmd1.Parameters.Add("@tipfac", SqlDbType.Char, 2).Value = BE1.tipfac;
                    cmd1.Parameters.Add("@serfac", SqlDbType.Char, 4).Value = BE1.serfac;
                    cmd1.Parameters.Add("@numfac", SqlDbType.Char, 10).Value = BE1.numfac;
                    cmd1.Parameters.Add("@fechfac", SqlDbType.DateTime).Value = BE1.fechfac;
                    cmd1.Parameters.Add("@tipguia", SqlDbType.Char, 2).Value = BE1.tipguia;
                    cmd1.Parameters.Add("@serguia", SqlDbType.Char, 4).Value = BE1.serguia;
                    cmd1.Parameters.Add("@numguia", SqlDbType.Char, 10).Value = BE1.numguia;
                    cmd1.Parameters.Add("@fechguia", SqlDbType.DateTime).Value = BE1.fechguia;
                    cmd1.Parameters.Add("@tipnotac", SqlDbType.Char, 2).Value = BE1.tipnotac;
                    cmd1.Parameters.Add("@sernotac", SqlDbType.Char, 4).Value = BE1.sernotac;
                    cmd1.Parameters.Add("@numnotac", SqlDbType.Char, 10).Value = BE1.numnotac;
                    cmd1.Parameters.Add("@fechnotac", SqlDbType.DateTime).Value = BE1.fechnotac;
                    cmd1.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE1.vendorid;
                    cmd1.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE1.ubige;
                    cmd1.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE1.cencosid;
                    cmd1.Parameters.Add("@dscto3", SqlDbType.Decimal).Value = BE1.dscto3;
                    cmd1.Parameters.Add("@totdscto1", SqlDbType.Decimal).Value = BE1.totdscto1;
                    cmd1.Parameters.Add("@totdscto2", SqlDbType.Decimal).Value = BE1.totdscto2;
                    cmd1.Parameters.Add("@totdscto3", SqlDbType.Decimal).Value = BE1.totdscto3;
                    cmd1.Parameters.Add("@condpago", SqlDbType.Char, 4).Value = BE1.condpago;
                    cmd1.Parameters.Add("@transporte", SqlDbType.Decimal).Value = BE1.transporte;
                    cmd1.Parameters.Add("@embalaje", SqlDbType.Decimal).Value = BE1.embalaje;
                    cmd1.Parameters.Add("@otros", SqlDbType.Decimal).Value = BE1.otros;
                    cmd1.Parameters.Add("@tipimptoid", SqlDbType.Char, 1).Value = BE1.tipimptoid;
                    cmd1.Parameters.Add("@igv", SqlDbType.Decimal).Value = BE1.igv;
                    cmd1.Parameters.Add("@incprec", SqlDbType.Char, 1).Value = BE1.incprec;
                    cmd1.Parameters.Add("@tipoperimptoid", SqlDbType.Char, 1).Value = BE1.tipoperimptoid;
                    cmd1.Parameters.Add("@totimpto", SqlDbType.Decimal).Value = BE1.totimpto;
                    cmd1.Parameters.Add("@valventa", SqlDbType.Decimal).Value = BE1.valventa;
                    cmd1.Parameters.Add("@totimporte", SqlDbType.Decimal).Value = BE1.totimporte;
                    cmd1.Parameters.Add("@bruto", SqlDbType.Decimal).Value = BE1.bruto;
                    cmd1.Parameters.Add("@cargo", SqlDbType.Decimal).Value = BE1.cargo;
                    cmd1.Parameters.Add("@abono", SqlDbType.Decimal).Value = BE1.abono;
                    cmd1.Parameters.Add("@tcamb", SqlDbType.Decimal).Value = BE1.tcamb;
                    cmd1.Parameters.Add("@codctadebe", SqlDbType.Char, 10).Value = BE1.codctadebe;
                    cmd1.Parameters.Add("@codctahaber", SqlDbType.Char, 10).Value = BE1.codctahaber;
                    cmd1.Parameters.Add("@glosa", SqlDbType.VarChar, 40).Value = BE1.glosa;
                    cmd1.Parameters.Add("@totpzas", SqlDbType.Decimal).Value = BE1.totpzas;
                    cmd1.Parameters.Add("@fechentrega", SqlDbType.DateTime).Value = BE1.fechentrega;
                    cmd1.Parameters.Add("@fechpago", SqlDbType.DateTime).Value = BE1.fechpago;
                    cmd1.Parameters.Add("@fechcancel", SqlDbType.DateTime).Value = BE1.fechcancel;
                    cmd1.Parameters.Add("@moneda", SqlDbType.Char).Value = BE1.moneda;
                    cmd1.Parameters.Add("@statborrado", SqlDbType.Char, 1).Value = BE1.statborrado;
                    cmd1.Parameters.Add("@transpid", SqlDbType.Char, 5).Value = BE1.transpid;
                    cmd1.Parameters.Add("@transpnume", SqlDbType.VarChar, 40).Value = BE1.transpnume;
                    cmd1.Parameters.Add("@transnmruc", SqlDbType.Char, 11).Value = BE1.transnmruc;
                    cmd1.Parameters.Add("@placa", SqlDbType.VarChar, 50).Value = BE1.placa;
                    cmd1.Parameters.Add("@certificado", SqlDbType.VarChar, 50).Value = BE1.certificado;
                    cmd1.Parameters.Add("@licencia", SqlDbType.Char, 11).Value = BE1.licencia;
                    cmd1.Parameters.Add("@motivotrasladoid", SqlDbType.Char, 1).Value = BE1.motivotrasladoid;
                    cmd1.Parameters.Add("@modofactu", SqlDbType.Char, 1).Value = BE1.modofactu;
                    cmd1.Parameters.Add("@clientetipo", SqlDbType.Char, 1).Value = BE1.clientetipo;
                    cmd1.Parameters.Add("@ddnni", SqlDbType.Char, 8).Value = BE1.ddnni;
                    cmd1.Parameters.Add("@items", SqlDbType.Decimal).Value = BE1.items;
                    cmd1.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE1.perianio;
                    cmd1.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE1.perimes;
                    cmd1.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE1.usuar;

                    //opt
                    //cmd1.Parameters.Add("@tipodocmanejaserie", SqlDbType.Bit).Value = BE1.tipodocmanejaserie;


                    using (SqlCommand cmd3 = new SqlCommand("gspTbTaMovimientosdet_UPDATE_xml", cnx))
                    {
                        cmd3.CommandType = CommandType.StoredProcedure;
                        cmd3.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE1.moduloid;
                        cmd3.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE1.local;
                        cmd3.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE1.tipodoc;
                        cmd3.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE1.serdoc;
                        cmd3.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE1.numdoc;
                        cmd3.Parameters.Add("@XMLnew", SqlDbType.Xml).Value = BE1.GetItemXML();
                        cmd3.Parameters.Add("@XMLold", SqlDbType.Xml).Value = BE2.GetItemXML();

                        try
                        {
                            cnx.Open();
                            //tr = cnx.BeginTransaction(IsolationLevel.Serializable);
                            //cmd1.Transaction = tr;

                            if (cmd1.ExecuteNonQuery() > 0)
                            {
                                //cmd3.Transaction = tr;

                                if (cmd3.ExecuteNonQuery() > 0)
                                {
                                    TransaExito = true;
                                }
                            }

                            if (TransaExito == true)
                            {
                                //tr.Commit();
                                return true;
                            }
                            else
                            {
                                //tr.Rollback();
                                return false;
                            }

                        }
                        catch (Exception ex)
                        {
                            //tr.Rollback();
                            throw new Exception(ex.Message);
                        }
                    }
                }
            }
        }

        public bool Update_Old(string empresaid, tb_60movimientos BE1, tb_60movimientos BE2, String cabecera)
        {
            //BE1: detalle del documento modificado
            //BE2: detalle del documento original

            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                SqlTransaction tr = default(SqlTransaction);
                Boolean TransaExito = false;
                string procedimiento;
                if (cabecera == "CAB")
                {
                    procedimiento = "gspTbTaMovimientoscab_UPDATE";
                }
                else
                {
                    procedimiento = "gspTbTaMovimientoscab_INSERT";
                }

                using (SqlCommand cmd1 = new SqlCommand(procedimiento, cnx))
                {
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE1.moduloid;
                    cmd1.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE1.local;
                    cmd1.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE1.tipodoc;
                    cmd1.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE1.serdoc;
                    cmd1.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE1.numdoc;
                    cmd1.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE1.status;
                    cmd1.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE1.almacaccionid;
                    cmd1.Parameters.Add("@ctacteaccionid", SqlDbType.Char, 2).Value = BE1.ctacteaccionid;
                    cmd1.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE1.fechdoc;
                    cmd1.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE1.ctacte;
                    cmd1.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE1.ctactename;
                    cmd1.Parameters.Add("@direcnume", SqlDbType.Char, 6).Value = BE1.direcnume;
                    cmd1.Parameters.Add("@direcname", SqlDbType.VarChar, 25).Value = BE1.direcname;
                    cmd1.Parameters.Add("@direcdeta", SqlDbType.VarChar, 70).Value = BE1.direcdeta;
                    cmd1.Parameters.Add("@direc", SqlDbType.VarChar, 70).Value = BE1.direc;
                    cmd1.Parameters.Add("@tipdid", SqlDbType.Char, 1).Value = BE1.tipdid;
                    cmd1.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE1.nmruc;
                    cmd1.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE1.tipref;
                    cmd1.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE1.serref;
                    cmd1.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE1.numref;
                    cmd1.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE1.fechref;
                    cmd1.Parameters.Add("@tip_op", SqlDbType.Char, 2).Value = BE1.tip_op;
                    cmd1.Parameters.Add("@ser_op", SqlDbType.Char, 4).Value = BE1.ser_op;
                    cmd1.Parameters.Add("@num_op", SqlDbType.Char, 10).Value = BE1.num_op;
                    cmd1.Parameters.Add("@tipfac", SqlDbType.Char, 2).Value = BE1.tipfac;
                    cmd1.Parameters.Add("@serfac", SqlDbType.Char, 4).Value = BE1.serfac;
                    cmd1.Parameters.Add("@numfac", SqlDbType.Char, 10).Value = BE1.numfac;
                    cmd1.Parameters.Add("@fechfac", SqlDbType.DateTime).Value = BE1.fechfac;
                    cmd1.Parameters.Add("@tipguia", SqlDbType.Char, 2).Value = BE1.tipguia;
                    cmd1.Parameters.Add("@serguia", SqlDbType.Char, 4).Value = BE1.serguia;
                    cmd1.Parameters.Add("@numguia", SqlDbType.Char, 10).Value = BE1.numguia;
                    cmd1.Parameters.Add("@fechguia", SqlDbType.DateTime).Value = BE1.fechguia;
                    cmd1.Parameters.Add("@tipnotac", SqlDbType.Char, 2).Value = BE1.tipnotac;
                    cmd1.Parameters.Add("@sernotac", SqlDbType.Char, 4).Value = BE1.sernotac;
                    cmd1.Parameters.Add("@numnotac", SqlDbType.Char, 10).Value = BE1.numnotac;
                    cmd1.Parameters.Add("@fechnotac", SqlDbType.DateTime).Value = BE1.fechnotac;
                    cmd1.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE1.vendorid;
                    cmd1.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE1.ubige;
                    cmd1.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE1.cencosid;
                    cmd1.Parameters.Add("@dscto3", SqlDbType.Decimal).Value = BE1.dscto3;
                    cmd1.Parameters.Add("@totdscto1", SqlDbType.Decimal).Value = BE1.totdscto1;
                    cmd1.Parameters.Add("@totdscto2", SqlDbType.Decimal).Value = BE1.totdscto2;
                    cmd1.Parameters.Add("@totdscto3", SqlDbType.Decimal).Value = BE1.totdscto3;
                    cmd1.Parameters.Add("@condpago", SqlDbType.Char, 4).Value = BE1.condpago;
                    cmd1.Parameters.Add("@transporte", SqlDbType.Decimal).Value = BE1.transporte;
                    cmd1.Parameters.Add("@embalaje", SqlDbType.Decimal).Value = BE1.embalaje;
                    cmd1.Parameters.Add("@otros", SqlDbType.Decimal).Value = BE1.otros;
                    cmd1.Parameters.Add("@tipimptoid", SqlDbType.Char, 1).Value = BE1.tipimptoid;
                    cmd1.Parameters.Add("@igv", SqlDbType.Decimal).Value = BE1.igv;
                    cmd1.Parameters.Add("@incprec", SqlDbType.Char, 1).Value = BE1.incprec;
                    cmd1.Parameters.Add("@tipoperimptoid", SqlDbType.Char, 1).Value = BE1.tipoperimptoid;
                    cmd1.Parameters.Add("@totimpto", SqlDbType.Decimal).Value = BE1.totimpto;
                    cmd1.Parameters.Add("@valventa", SqlDbType.Decimal).Value = BE1.valventa;
                    cmd1.Parameters.Add("@totimporte", SqlDbType.Decimal).Value = BE1.totimporte;
                    cmd1.Parameters.Add("@bruto", SqlDbType.Decimal).Value = BE1.bruto;
                    cmd1.Parameters.Add("@cargo", SqlDbType.Decimal).Value = BE1.cargo;
                    cmd1.Parameters.Add("@abono", SqlDbType.Decimal).Value = BE1.abono;
                    cmd1.Parameters.Add("@tcamb", SqlDbType.Decimal).Value = BE1.tcamb;
                    cmd1.Parameters.Add("@codctadebe", SqlDbType.Char, 10).Value = BE1.codctadebe;
                    cmd1.Parameters.Add("@codctahaber", SqlDbType.Char, 10).Value = BE1.codctahaber;
                    cmd1.Parameters.Add("@glosa", SqlDbType.VarChar, 40).Value = BE1.glosa;
                    cmd1.Parameters.Add("@totpzas", SqlDbType.Decimal).Value = BE1.totpzas;
                    cmd1.Parameters.Add("@fechentrega", SqlDbType.DateTime).Value = BE1.fechentrega;
                    cmd1.Parameters.Add("@fechpago", SqlDbType.DateTime).Value = BE1.fechpago;
                    cmd1.Parameters.Add("@fechcancel", SqlDbType.DateTime).Value = BE1.fechcancel;
                    cmd1.Parameters.Add("@moneda", SqlDbType.Char).Value = BE1.moneda;
                    cmd1.Parameters.Add("@statborrado", SqlDbType.Char, 1).Value = BE1.statborrado;
                    cmd1.Parameters.Add("@transpid", SqlDbType.Char, 5).Value = BE1.transpid;
                    cmd1.Parameters.Add("@transpnume", SqlDbType.VarChar, 40).Value = BE1.transpnume;
                    cmd1.Parameters.Add("@transnmruc", SqlDbType.Char, 11).Value = BE1.transnmruc;
                    cmd1.Parameters.Add("@placa", SqlDbType.VarChar, 50).Value = BE1.placa;
                    cmd1.Parameters.Add("@certificado", SqlDbType.VarChar, 50).Value = BE1.certificado;
                    cmd1.Parameters.Add("@licencia", SqlDbType.Char, 11).Value = BE1.licencia;
                    cmd1.Parameters.Add("@motivotrasladoid", SqlDbType.Char, 1).Value = BE1.motivotrasladoid;
                    cmd1.Parameters.Add("@modofactu", SqlDbType.Char, 1).Value = BE1.modofactu;
                    cmd1.Parameters.Add("@clientetipo", SqlDbType.Char, 1).Value = BE1.clientetipo;
                    cmd1.Parameters.Add("@ddnni", SqlDbType.Char, 8).Value = BE1.ddnni;
                    cmd1.Parameters.Add("@items", SqlDbType.Decimal).Value = BE1.items;
                    cmd1.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE1.perianio;
                    cmd1.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE1.perimes;
                    cmd1.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE1.usuar;

                    //opt
                    //cmd1.Parameters.Add("@tipodocmanejaserie", SqlDbType.Bit).Value = BE1.tipodocmanejaserie;

                    using (SqlCommand cmd2 = new SqlCommand("gspTbTaMovimientosdet_DELETE_xml", cnx))
                    {
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE2.moduloid;
                        cmd2.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE2.local;
                        cmd2.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE2.tipodoc;
                        cmd2.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE2.serdoc;
                        cmd2.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE2.numdoc;
                        cmd2.Parameters.Add("@XML", SqlDbType.Xml).Value = BE2.GetItemXML2();

                        using (SqlCommand cmd3 = new SqlCommand("gspTbTaMovimientosdet_INSERT_xml", cnx))
                        {
                            cmd3.CommandType = CommandType.StoredProcedure;
                            cmd3.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE1.moduloid;
                            cmd3.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE1.local;
                            cmd3.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE1.tipodoc;
                            cmd3.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE1.serdoc;
                            cmd3.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE1.numdoc;
                            cmd3.Parameters.Add("@XML", SqlDbType.Xml).Value = BE1.GetItemXML();

                            try
                            {
                                cnx.Open();
                                tr = cnx.BeginTransaction(IsolationLevel.Serializable);
                                cmd1.Transaction = tr;

                                if (cmd1.ExecuteNonQuery() > 0)
                                {
                                    cmd2.Transaction = tr;

                                    if (cmd2.ExecuteNonQuery() > 0)
                                    {
                                        cmd3.Transaction = tr;

                                        if (cmd3.ExecuteNonQuery() > 0)
                                        {
                                            TransaExito = true;
                                        }
                                    }
                                }

                                if (TransaExito == true)
                                {
                                    tr.Commit();
                                    return true;
                                }
                                else
                                {
                                    tr.Rollback();
                                    return false;
                                }

                            }
                            catch (Exception ex)
                            {
                                tr.Rollback();
                                throw new Exception(ex.Message);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        public DataSet GenPendienteNIAtoRCompra(string empresaid, tb_co_Compras BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd1 = new SqlCommand("gspTbCoMovimientos_GenPendienteNIA_RCompra", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd1.CommandTimeout = 0;
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@almacen", string.IsNullOrEmpty(BE.almacen) ? (object)DBNull.Value : BE.almacen);
                        if (BE.fechaini == "")
                        { cmd1.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd1.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = BE.fechaini; }
                        if (BE.fechafin == "")
                        { cmd1.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd1.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = BE.fechafin; }
                        cmd1.Parameters.AddWithValue("@ctacte", string.IsNullOrEmpty(BE.ctacte) ? (object)DBNull.Value : BE.ctacte);
                        cmd1.Parameters.AddWithValue("@tipdoc", string.IsNullOrEmpty(BE.tipodoc) ? (object)DBNull.Value : BE.tipodoc);
                        cmd1.Parameters.AddWithValue("@numdoc", string.IsNullOrEmpty(BE.numdoc) ? (object)DBNull.Value : BE.numdoc);
                    }
                    cnx.Open();
                    try
                    {  
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

        public DataSet GetAll(string empresaid, tb_60movimientoscab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaMovimientoscab_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE.almacaccionid;
                        cmd.Parameters.Add("@ctacteaccionid", SqlDbType.Char, 2).Value = BE.ctacteaccionid;
                        //cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                        cmd.Parameters.Add("@direcnume", SqlDbType.Char, 6).Value = BE.direcnume;
                        cmd.Parameters.Add("@direcname", SqlDbType.VarChar, 25).Value = BE.direcname;
                        cmd.Parameters.Add("@direcdeta", SqlDbType.VarChar, 70).Value = BE.direcdeta;
                        cmd.Parameters.Add("@direc", SqlDbType.VarChar, 70).Value = BE.direc;
                        cmd.Parameters.Add("@tipdid", SqlDbType.Char, 1).Value = BE.tipdid;
                        cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                        cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                        cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                        cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                        //cmd.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE.fechref;
                        cmd.Parameters.Add("@tip_op", SqlDbType.Char, 2).Value = BE.tip_op;
                        cmd.Parameters.Add("@ser_op", SqlDbType.Char, 4).Value = BE.ser_op;
                        cmd.Parameters.Add("@num_op", SqlDbType.Char, 10).Value = BE.num_op;
                        cmd.Parameters.Add("@tipfac", SqlDbType.Char, 2).Value = BE.tipfac;
                        cmd.Parameters.Add("@serfac", SqlDbType.Char, 4).Value = BE.serfac;
                        cmd.Parameters.Add("@numfac", SqlDbType.Char, 10).Value = BE.numfac;
                        //cmd.Parameters.Add("@fechfac", SqlDbType.DateTime).Value = BE.fechfac;
                        cmd.Parameters.Add("@tipnotac", SqlDbType.Char, 2).Value = BE.tipnotac;
                        cmd.Parameters.Add("@sernotac", SqlDbType.Char, 4).Value = BE.sernotac;
                        cmd.Parameters.Add("@numnotac", SqlDbType.Char, 10).Value = BE.numnotac;
                        cmd.Parameters.Add("@tipguia", SqlDbType.Char, 2).Value = BE.tipguia;
                        cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                        cmd.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE.ubige;
                        cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                        //cmd.Parameters.Add("@dscto3", SqlDbType.Decimal).Value = BE.dscto3;
                        //cmd.Parameters.Add("@totdscto1", SqlDbType.Decimal).Value = BE.totdscto1;
                        //cmd.Parameters.Add("@totdscto2", SqlDbType.Decimal).Value = BE.totdscto2;
                        //cmd.Parameters.Add("@totdscto3", SqlDbType.Decimal).Value = BE.totdscto3;
                        cmd.Parameters.Add("@condpago", SqlDbType.Char, 4).Value = BE.condpago;
                        //cmd.Parameters.Add("@transporte", SqlDbType.Decimal).Value = BE.transporte;
                        //cmd.Parameters.Add("@embalaje", SqlDbType.Decimal).Value = BE.embalaje;
                        //cmd.Parameters.Add("@otros", SqlDbType.Decimal).Value = BE.otros;
                        cmd.Parameters.Add("@tipimptoid", SqlDbType.Char, 1).Value = BE.tipimptoid;
                        //cmd.Parameters.Add("@igv", SqlDbType.Decimal).Value = BE.igv;
                        cmd.Parameters.Add("@incprec", SqlDbType.Char, 1).Value = BE.incprec;
                        cmd.Parameters.Add("@tipoperimptoid", SqlDbType.Char, 1).Value = BE.tipoperimptoid;
                        //cmd.Parameters.Add("@totimpto", SqlDbType.Decimal).Value = BE.totimpto;
                        //cmd.Parameters.Add("@valventa", SqlDbType.Decimal).Value = BE.valventa;
                        //cmd.Parameters.Add("@totimporte", SqlDbType.Decimal).Value = BE.totimporte;
                        //cmd.Parameters.Add("@bruto", SqlDbType.Decimal).Value = BE.bruto;
                        //cmd.Parameters.Add("@cargo", SqlDbType.Decimal).Value = BE.cargo;
                        //cmd.Parameters.Add("@abono", SqlDbType.Decimal).Value = BE.abono;
                        //cmd.Parameters.Add("@tcamb", SqlDbType.Decimal).Value = BE.tcamb;
                        cmd.Parameters.Add("@codctadebe", SqlDbType.Char, 10).Value = BE.codctadebe;
                        cmd.Parameters.Add("@codctahaber", SqlDbType.Char, 10).Value = BE.codctahaber;
                        cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 40).Value = BE.glosa;
                        //cmd.Parameters.Add("@totpzas", SqlDbType.Decimal).Value = BE.totpzas;
                        //cmd.Parameters.Add("@fechentrega", SqlDbType.DateTime).Value = BE.fechentrega;
                        //cmd.Parameters.Add("@fechpago", SqlDbType.DateTime).Value = BE.fechpago;
                        //cmd.Parameters.Add("@fechcancel", SqlDbType.DateTime).Value = BE.fechcancel;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char).Value = BE.moneda;
                        cmd.Parameters.Add("@statborrado", SqlDbType.Char, 1).Value = BE.statborrado;
                        cmd.Parameters.Add("@transpid", SqlDbType.Char, 5).Value = BE.transpid;
                        cmd.Parameters.Add("@transpnume", SqlDbType.VarChar, 40).Value = BE.transpnume;
                        cmd.Parameters.Add("@transnmruc", SqlDbType.Char, 11).Value = BE.transnmruc;
                        cmd.Parameters.Add("@placa", SqlDbType.VarChar, 50).Value = BE.placa;
                        cmd.Parameters.Add("@certificado", SqlDbType.VarChar, 50).Value = BE.certificado;
                        cmd.Parameters.Add("@licencia", SqlDbType.Char, 11).Value = BE.licencia;
                        cmd.Parameters.Add("@motivotrasladoid", SqlDbType.Char, 1).Value = BE.motivotrasladoid;
                        cmd.Parameters.Add("@modofactu", SqlDbType.Char, 1).Value = BE.modofactu;
                        cmd.Parameters.Add("@clientetipo", SqlDbType.Char, 1).Value = BE.clientetipo;
                        cmd.Parameters.Add("@ddnni", SqlDbType.Char, 8).Value = BE.ddnni;
                        //cmd.Parameters.Add("@items", SqlDbType.Decimal).Value = BE.items;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public DataSet GetOne(string empresaid, tb_60movimientoscab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaMovimientoscab_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
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

        public DataSet GetOne2(string empresaid, tb_60movimientoscab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaMovimientoscab_SELECT2", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
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
