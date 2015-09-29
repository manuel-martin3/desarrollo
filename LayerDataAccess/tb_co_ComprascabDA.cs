using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_co_ComprascabDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_co_Comprascab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoComprascab_INSERT", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local; 
                    cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid; 
                    cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;  
                    cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc; 
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc; 
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc; 
                    cmd.Parameters.Add("@status", SqlDbType.Bit).Value = BE.status;
                    cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte; 
                    cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                    cmd.Parameters.Add("@direc", SqlDbType.VarChar, 70).Value = BE.direc;
                    cmd.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE.ubige;
                    cmd.Parameters.Add("@tipdid", SqlDbType.Char, 1).Value = BE.tipdid;
                    cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                    cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                    cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                    cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                    cmd.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE.fechref;
                    cmd.Parameters.Add("@tipOp", SqlDbType.Char, 2).Value = BE.tipOp;
                    cmd.Parameters.Add("@serOp", SqlDbType.Char, 4).Value = BE.serOp;
                    cmd.Parameters.Add("@numOp", SqlDbType.Char, 10).Value = BE.numOp;
                    cmd.Parameters.Add("@arrayguias", SqlDbType.VarChar, 70).Value = BE.arrayguias;
                    cmd.Parameters.Add("@arrayfechasguia", SqlDbType.VarChar, 50).Value = BE.arrayfechasguia;
                    cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                    cmd.Parameters.Add("@compradorid", SqlDbType.Char, 4).Value = BE.compradorid;
                    cmd.Parameters.Add("@condcompraid", SqlDbType.Char, 4).Value = BE.condcompraid;
                    cmd.Parameters.Add("@bruto", SqlDbType.Decimal).Value = BE.bruto;
                    cmd.Parameters.Add("@dscto3", SqlDbType.Decimal).Value = BE.dscto3;
                    cmd.Parameters.Add("@totdscto3", SqlDbType.Decimal).Value = BE.totdscto3;
                    cmd.Parameters.Add("@transporte", SqlDbType.Decimal).Value = BE.transporte;
                    cmd.Parameters.Add("@embalaje", SqlDbType.Decimal).Value = BE.embalaje;
                    cmd.Parameters.Add("@otros", SqlDbType.Decimal).Value = BE.otros;
                    cmd.Parameters.Add("@tipimptoid", SqlDbType.Char, 1).Value = BE.tipimptoid;
                    cmd.Parameters.Add("@igv", SqlDbType.Decimal).Value = BE.igv;
                    cmd.Parameters.Add("@incprec", SqlDbType.Bit).Value = BE.incprec;
                    cmd.Parameters.Add("@impexo", SqlDbType.Decimal).Value = BE.impexo;
                    cmd.Parameters.Add("@valorcompra1", SqlDbType.Decimal).Value = BE.valorcompra1;
                    cmd.Parameters.Add("@igv1", SqlDbType.Decimal).Value = BE.igv1;
                    cmd.Parameters.Add("@cargo", SqlDbType.Decimal).Value = BE.cargo;
                    cmd.Parameters.Add("@preciocompra1", SqlDbType.Decimal).Value = BE.preciocompra1;
                    cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                    cmd.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                    cmd.Parameters.Add("@codctadebe", SqlDbType.Char, 10).Value = BE.codctadebe;
                    cmd.Parameters.Add("@tipoid", SqlDbType.Char, 2).Value = BE.tipoid;
                    cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 100).Value = BE.glosa;
                    cmd.Parameters.Add("@totpzas", SqlDbType.Decimal).Value = BE.totpzas;
                    cmd.Parameters.Add("@fechentrega", SqlDbType.DateTime).Value = BE.fechentrega;
                    cmd.Parameters.Add("@fechpago", SqlDbType.DateTime).Value = BE.fechpago;
                    cmd.Parameters.Add("@fechcancel", SqlDbType.DateTime).Value = BE.fechcancel;
                    cmd.Parameters.Add("@modofactu", SqlDbType.Char, 1).Value = BE.modofactu;
                    cmd.Parameters.Add("@items", SqlDbType.Decimal).Value = BE.items;
                    cmd.Parameters.Add("@fechregistro", SqlDbType.DateTime).Value = BE.fechregistro;
                    cmd.Parameters.Add("@vinculante", SqlDbType.Char, 1).Value = BE.vinculante;
                    cmd.Parameters.Add("@origen", SqlDbType.Char, 2).Value = BE.origen;
                    cmd.Parameters.Add("@afecdetraccion", SqlDbType.Bit).Value = BE.afecdetraccion;
                    cmd.Parameters.Add("@nconstdetrac", SqlDbType.Char, 10).Value = BE.nconstdetrac;
                    cmd.Parameters.Add("@fechconstdetrac", SqlDbType.DateTime).Value = BE.fechconstdetrac;
                    cmd.Parameters.Add("@detraccionid", SqlDbType.Char, 5).Value = BE.detraccionid;
                    cmd.Parameters.Add("@porcdetraccion", SqlDbType.Decimal).Value = BE.porcdetraccion;
                    cmd.Parameters.Add("@bnctadetraccion", SqlDbType.VarChar, 40).Value = BE.bnctadetraccion;
                    cmd.Parameters.Add("@afectretencion", SqlDbType.Bit).Value = BE.afectretencion;
                    cmd.Parameters.Add("@afecpercepcion", SqlDbType.Bit).Value = BE.afecpercepcion;
                    cmd.Parameters.Add("@serdocpercepcion", SqlDbType.Char, 4).Value = BE.serdocpercepcion;
                    cmd.Parameters.Add("@numdocpercepcion", SqlDbType.Char, 10).Value = BE.numdocpercepcion;
                    cmd.Parameters.Add("@percepcionid", SqlDbType.Char, 2).Value = BE.percepcionid;
                    cmd.Parameters.Add("@afectoigvid", SqlDbType.Bit).Value = BE.afectoigvid;                    
                    cmd.Parameters.Add("@aduanaid", SqlDbType.Char, 3).Value = BE.aduanaid;
                    cmd.Parameters.Add("@aniodua", SqlDbType.Char, 4).Value = BE.aniodua;
                    cmd.Parameters.Add("@numdua", SqlDbType.Char, 10).Value = BE.numdua;
                    cmd.Parameters.Add("@fechembdua", SqlDbType.DateTime).Value = BE.fechembdua;
                    cmd.Parameters.Add("@fechreguldua", SqlDbType.DateTime).Value = BE.fechreguldua;
                    cmd.Parameters.Add("@valorfobdua", SqlDbType.Decimal).Value = BE.valorfobdua;
                    cmd.Parameters.Add("@tipoexportid", SqlDbType.Char, 2).Value = BE.tipoexportid;
                    cmd.Parameters.Add("@valor2", SqlDbType.Decimal).Value = BE.valor2;
                    cmd.Parameters.Add("@dscto2", SqlDbType.Decimal).Value = BE.dscto2;
                    cmd.Parameters.Add("@impexo2", SqlDbType.Decimal).Value = BE.impexo2;
                    cmd.Parameters.Add("@valorcompra2", SqlDbType.Decimal).Value = BE.valorcompra2;
                    cmd.Parameters.Add("@igv2", SqlDbType.Decimal).Value = BE.igv2;
                    cmd.Parameters.Add("@preciocompra2", SqlDbType.Decimal).Value = BE.preciocompra2;
                    cmd.Parameters.Add("@tipersona", SqlDbType.Char, 2).Value = BE.tipersona;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;

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

        public bool Update(string empresaid, tb_co_Comprascab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoComprascab_UPDATE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@status", SqlDbType.Bit).Value = BE.status;
                        cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                        cmd.Parameters.Add("@direc", SqlDbType.VarChar, 70).Value = BE.direc;
                        cmd.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE.ubige;
                        cmd.Parameters.Add("@tipdid", SqlDbType.Char, 1).Value = BE.tipdid;
                        cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                        cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                        cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                        cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                        cmd.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE.fechref;
                        cmd.Parameters.Add("@tipOp", SqlDbType.Char, 2).Value = BE.tipOp;
                        cmd.Parameters.Add("@serOp", SqlDbType.Char, 4).Value = BE.serOp;
                        cmd.Parameters.Add("@numOp", SqlDbType.Char, 10).Value = BE.numOp;
                        cmd.Parameters.Add("@arrayguias", SqlDbType.VarChar, 70).Value = BE.arrayguias;
                        cmd.Parameters.Add("@arrayfechasguia", SqlDbType.VarChar, 50).Value = BE.arrayfechasguia;
                        cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                        cmd.Parameters.Add("@compradorid", SqlDbType.Char, 4).Value = BE.compradorid;
                        cmd.Parameters.Add("@condcompraid", SqlDbType.Char, 4).Value = BE.condcompraid;
                        cmd.Parameters.Add("@bruto", SqlDbType.Decimal).Value = BE.bruto;
                        cmd.Parameters.Add("@dscto3", SqlDbType.Decimal).Value = BE.dscto3;
                        cmd.Parameters.Add("@totdscto3", SqlDbType.Decimal).Value = BE.totdscto3;
                        cmd.Parameters.Add("@transporte", SqlDbType.Decimal).Value = BE.transporte;
                        cmd.Parameters.Add("@embalaje", SqlDbType.Decimal).Value = BE.embalaje;
                        cmd.Parameters.Add("@otros", SqlDbType.Decimal).Value = BE.otros;
                        cmd.Parameters.Add("@tipimptoid", SqlDbType.Char, 1).Value = BE.tipimptoid;
                        cmd.Parameters.Add("@igv", SqlDbType.Decimal).Value = BE.igv;
                        cmd.Parameters.Add("@incprec", SqlDbType.Bit).Value = BE.incprec;
                        cmd.Parameters.Add("@impexo", SqlDbType.Decimal).Value = BE.impexo;
                        cmd.Parameters.Add("@valorcompra1", SqlDbType.Decimal).Value = BE.valorcompra1;
                        cmd.Parameters.Add("@igv1", SqlDbType.Decimal).Value = BE.igv1;
                        cmd.Parameters.Add("@cargo", SqlDbType.Decimal).Value = BE.cargo;
                        cmd.Parameters.Add("@preciocompra1", SqlDbType.Decimal).Value = BE.preciocompra1;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                        cmd.Parameters.Add("@codctadebe", SqlDbType.Char, 10).Value = BE.codctadebe;
                        cmd.Parameters.Add("@tipoid", SqlDbType.Char, 2).Value = BE.tipoid;
                        cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 100).Value = BE.glosa;
                        cmd.Parameters.Add("@totpzas", SqlDbType.Decimal).Value = BE.totpzas;
                        cmd.Parameters.Add("@fechentrega", SqlDbType.DateTime).Value = BE.fechentrega;
                        cmd.Parameters.Add("@fechpago", SqlDbType.DateTime).Value = BE.fechpago;
                        cmd.Parameters.Add("@fechcancel", SqlDbType.DateTime).Value = BE.fechcancel;
                        cmd.Parameters.Add("@modofactu", SqlDbType.Char, 1).Value = BE.modofactu;
                        cmd.Parameters.Add("@items", SqlDbType.Decimal).Value = BE.items;
                        cmd.Parameters.Add("@fechregistro", SqlDbType.DateTime).Value = BE.fechregistro;
                        cmd.Parameters.Add("@vinculante", SqlDbType.Char, 1).Value = BE.vinculante;
                        cmd.Parameters.Add("@origen", SqlDbType.Char, 2).Value = BE.origen;
                        cmd.Parameters.Add("@afecdetraccion", SqlDbType.Bit).Value = BE.afecdetraccion;
                        cmd.Parameters.Add("@nconstdetrac", SqlDbType.Char, 10).Value = BE.nconstdetrac;
                        cmd.Parameters.Add("@fechconstdetrac", SqlDbType.DateTime).Value = BE.fechconstdetrac;
                        cmd.Parameters.Add("@detraccionid", SqlDbType.Char, 5).Value = BE.detraccionid;
                        cmd.Parameters.Add("@porcdetraccion", SqlDbType.Decimal).Value = BE.porcdetraccion;
                        cmd.Parameters.Add("@bnctadetraccion", SqlDbType.VarChar, 40).Value = BE.bnctadetraccion;
                        cmd.Parameters.Add("@afectretencion", SqlDbType.Bit).Value = BE.afectretencion;
                        cmd.Parameters.Add("@afecpercepcion", SqlDbType.Bit).Value = BE.afecpercepcion;
                        cmd.Parameters.Add("@serdocpercepcion", SqlDbType.Char, 4).Value = BE.serdocpercepcion;
                        cmd.Parameters.Add("@numdocpercepcion", SqlDbType.Char, 10).Value = BE.numdocpercepcion;
                        cmd.Parameters.Add("@percepcionid", SqlDbType.Char, 2).Value = BE.percepcionid;
                        cmd.Parameters.Add("@afectoigvid", SqlDbType.Bit).Value = BE.afectoigvid;
                        cmd.Parameters.Add("@aduanaid", SqlDbType.Char, 3).Value = BE.aduanaid;
                        cmd.Parameters.Add("@aniodua", SqlDbType.Char, 4).Value = BE.aniodua;
                        cmd.Parameters.Add("@numdua", SqlDbType.Char, 10).Value = BE.numdua;
                        cmd.Parameters.Add("@fechembdua", SqlDbType.DateTime).Value = BE.fechembdua;
                        cmd.Parameters.Add("@fechreguldua", SqlDbType.DateTime).Value = BE.fechreguldua;
                        cmd.Parameters.Add("@valorfobdua", SqlDbType.Decimal).Value = BE.valorfobdua;
                        cmd.Parameters.Add("@tipoexportid", SqlDbType.Char, 2).Value = BE.tipoexportid;
                        cmd.Parameters.Add("@valor2", SqlDbType.Decimal).Value = BE.valor2;
                        cmd.Parameters.Add("@dscto2", SqlDbType.Decimal).Value = BE.dscto2;
                        cmd.Parameters.Add("@impexo2", SqlDbType.Decimal).Value = BE.impexo2;
                        cmd.Parameters.Add("@valorcompra2", SqlDbType.Decimal).Value = BE.valorcompra2;
                        cmd.Parameters.Add("@igv2", SqlDbType.Decimal).Value = BE.igv2;
                        cmd.Parameters.Add("@preciocompra2", SqlDbType.Decimal).Value = BE.preciocompra2;
                        cmd.Parameters.Add("@tipersona", SqlDbType.Char, 2).Value = BE.tipersona;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
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

        public bool Delete(string empresaid, tb_co_Comprascab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoComprascab_DELETE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
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

        public DataSet GetAll(string empresaid, tb_co_Comprascab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoComprascab_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;  
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@status", SqlDbType.Bit).Value = BE.status;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                        cmd.Parameters.Add("@direc", SqlDbType.VarChar, 70).Value = BE.direc;
                        cmd.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE.ubige;
                        cmd.Parameters.Add("@tipdid", SqlDbType.Char, 1).Value = BE.tipdid;
                        cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                        cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                        cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                        cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                        cmd.Parameters.Add("@tipOp", SqlDbType.Char, 2).Value = BE.tipOp;
                        cmd.Parameters.Add("@serOp", SqlDbType.Char, 4).Value = BE.serOp;
                        cmd.Parameters.Add("@numOp", SqlDbType.Char, 10).Value = BE.numOp;
                        cmd.Parameters.Add("@arrayguias", SqlDbType.VarChar, 70).Value = BE.arrayguias;
                        cmd.Parameters.Add("@arrayfechasguia", SqlDbType.VarChar, 50).Value = BE.arrayfechasguia;
                        cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                        cmd.Parameters.Add("@compradorid", SqlDbType.Char, 4).Value = BE.compradorid;
                        cmd.Parameters.Add("@condcompraid", SqlDbType.Char, 4).Value = BE.condcompraid;
                        cmd.Parameters.Add("@tipimptoid", SqlDbType.Char, 1).Value = BE.tipimptoid;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@codctadebe", SqlDbType.Char, 10).Value = BE.codctadebe;
                        cmd.Parameters.Add("@tipoid", SqlDbType.Char, 2).Value = BE.tipoid;
                        cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 100).Value = BE.glosa;
                        //cmd.Parameters.Add("@totpzas", SqlDbType.Decimal).Value = BE.totpzas;
                        cmd.Parameters.Add("@modofactu", SqlDbType.Char, 1).Value = BE.modofactu;
                        cmd.Parameters.Add("@fechregistro", SqlDbType.DateTime).Value = BE.fechregistro;
                        cmd.Parameters.Add("@vinculante", SqlDbType.Char, 1).Value = BE.vinculante;
                        cmd.Parameters.Add("@origen", SqlDbType.Char, 2).Value = BE.origen;
                        cmd.Parameters.Add("@afecdetraccion", SqlDbType.Bit).Value = BE.afecdetraccion;
                        cmd.Parameters.Add("@nconstdetrac", SqlDbType.Char, 10).Value = BE.nconstdetrac;
                        cmd.Parameters.Add("@fechconstdetrac", SqlDbType.DateTime).Value = BE.fechconstdetrac;
                        cmd.Parameters.Add("@detraccionid", SqlDbType.Char, 5).Value = BE.detraccionid;
                        cmd.Parameters.Add("@bnctadetraccion", SqlDbType.VarChar, 40).Value = BE.bnctadetraccion;
                        cmd.Parameters.Add("@afectretencion", SqlDbType.Bit).Value = BE.afectretencion;
                        cmd.Parameters.Add("@afecpercepcion", SqlDbType.Bit).Value = BE.afecpercepcion;
                        cmd.Parameters.Add("@serdocpercepcion", SqlDbType.Char, 4).Value = BE.serdocpercepcion;
                        cmd.Parameters.Add("@numdocpercepcion", SqlDbType.Char, 10).Value = BE.numdocpercepcion;
                        cmd.Parameters.Add("@percepcionid", SqlDbType.Char, 2).Value = BE.percepcionid;
                        cmd.Parameters.Add("@afectoigvid", SqlDbType.Bit).Value = BE.afectoigvid;
                        cmd.Parameters.Add("@aduanaid", SqlDbType.Char, 3).Value = BE.aduanaid;
                        cmd.Parameters.Add("@aniodua", SqlDbType.Char, 4).Value = BE.aniodua;
                        cmd.Parameters.Add("@numdua", SqlDbType.Char, 10).Value = BE.numdua;
                        cmd.Parameters.Add("@fechembdua", SqlDbType.DateTime).Value = BE.fechembdua;
                        cmd.Parameters.Add("@fechreguldua", SqlDbType.DateTime).Value = BE.fechreguldua;
                        //cmd.Parameters.Add("@valorfobdua", SqlDbType.Decimal).Value = BE.valorfobdua;
                        cmd.Parameters.Add("@tipoexportid", SqlDbType.Char, 2).Value = BE.tipoexportid;
                        //cmd.Parameters.Add("@valor2", SqlDbType.Decimal).Value = BE.valor2;
                        //cmd.Parameters.Add("@dscto2", SqlDbType.Decimal).Value = BE.dscto2;
                        cmd.Parameters.Add("@tipersona", SqlDbType.Char, 2).Value = BE.tipersona;
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

        public DataSet GetAsientoNume(string empresaid, tb_co_Comprascab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoComprascab_SEARCH_asientonume", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
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

        public DataSet GetAsientoRoleo(string empresaid, tb_co_Comprascab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoComprascab_SEARCH_roleo", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
                        cmd.Parameters.Add("@tipo", SqlDbType.Char, 10).Value = BE.tipo;
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

        public DataSet GetOne(string empresaid, tb_co_Comprascab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoComprascab_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
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
    }
}
