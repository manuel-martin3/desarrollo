using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_cm_ordendecompracabDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_cm_ordendecompracab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60Movimientoscab_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd.Parameters.Add("@moduloiddes", SqlDbType.Char, 4).Value = BE.moduloiddes;
                    cmd.Parameters.Add("@localdes", SqlDbType.Char, 3).Value = BE.localdes;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = fecha(BE.fechdoc);
                    cmd.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE.almacaccionid;
                    cmd.Parameters.Add("@ctacteaccionid", SqlDbType.Char, 2).Value = BE.ctacteaccionid;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                    cmd.Parameters.Add("@direc", SqlDbType.VarChar, 70).Value = BE.direc;
                    cmd.Parameters.Add("@tipdid", SqlDbType.Char, 1).Value = BE.tipdid;
                    cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                    cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                    cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                    cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                    cmd.Parameters.Add("@fechref", SqlDbType.DateTime).Value = fecha(BE.fechref);
                    cmd.Parameters.Add("@tipped", SqlDbType.Char, 2).Value = BE.tipped;
                    cmd.Parameters.Add("@serped", SqlDbType.Char, 4).Value = BE.serped;
                    cmd.Parameters.Add("@numped", SqlDbType.Char, 10).Value = BE.numped;
                    cmd.Parameters.Add("@compradorid", SqlDbType.Char, 4).Value = BE.compradorid;
                    cmd.Parameters.Add("@condpagoid", SqlDbType.Char, 3).Value = BE.condpagoid;
                    cmd.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE.ubige;
                    cmd.Parameters.Add("@bruto", SqlDbType.Decimal).Value = BE.bruto;
                    cmd.Parameters.Add("@pdscto", SqlDbType.Decimal).Value = BE.pdscto;
                    cmd.Parameters.Add("@idscto", SqlDbType.Decimal).Value = BE.idscto;
                    cmd.Parameters.Add("@afectoigv", SqlDbType.Bit).Value = BE.afectoigv;
                    cmd.Parameters.Add("@pigv", SqlDbType.Decimal).Value = BE.pigv;
                    cmd.Parameters.Add("@incprec", SqlDbType.Char, 1).Value = BE.incprec;
                    cmd.Parameters.Add("@moneda", SqlDbType.Char).Value = BE.moneda;
                    cmd.Parameters.Add("@tcamb", SqlDbType.Decimal).Value = BE.tcamb;
                    cmd.Parameters.Add("@valventa", SqlDbType.Decimal).Value = BE.valventa;
                    cmd.Parameters.Add("@totimpto", SqlDbType.Decimal).Value = BE.totimpto;
                    cmd.Parameters.Add("@totimporte", SqlDbType.Decimal).Value = BE.totimporte;
                    cmd.Parameters.Add("@valor_ocompra", SqlDbType.Decimal).Value = BE.valor_ocompra;
                    cmd.Parameters.Add("@valor_guiado", SqlDbType.Decimal).Value = BE.valor_guiado;
                    cmd.Parameters.Add("@valor_facturado", SqlDbType.Decimal).Value = BE.valor_facturado;
                    cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 100).Value = BE.glosa;
                    cmd.Parameters.Add("@totpzas", SqlDbType.Decimal).Value = BE.totpzas;
                    cmd.Parameters.Add("@fechentrega", SqlDbType.DateTime).Value = fecha(BE.fechentrega);
                    cmd.Parameters.Add("@fechpago", SqlDbType.DateTime).Value = fecha(BE.fechpago);
                    cmd.Parameters.Add("@fechcancel", SqlDbType.DateTime).Value = fecha(BE.fechcancel);
                    cmd.Parameters.Add("@items", SqlDbType.Decimal).Value = BE.items;
                    cmd.Parameters.Add("@afecdetraccion", SqlDbType.Bit).Value = BE.afecdetraccion;
                    cmd.Parameters.Add("@detraccionid", SqlDbType.Char, 5).Value = BE.detraccionid;
                    cmd.Parameters.Add("@pdetraccion", SqlDbType.Decimal).Value = BE.pdetraccion;
                    cmd.Parameters.Add("@atencion", SqlDbType.VarChar, 100).Value = BE.atencion;
                    cmd.Parameters.Add("@puntollegada", SqlDbType.VarChar, 100).Value = BE.puntollegada;
                    cmd.Parameters.Add("@visado", SqlDbType.Bit).Value = BE.visado;
                    cmd.Parameters.Add("@usuarvisado", SqlDbType.Char, 15).Value = BE.usuarvisado;
                    cmd.Parameters.Add("@observacionvisado", SqlDbType.VarChar, 50).Value = BE.observacionvisado;
                    cmd.Parameters.Add("@fechvisado", SqlDbType.DateTime).Value = fecha(BE.fechvisado);
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
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

        public bool Update(string empresaid, tb_cm_ordendecompracab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60Movimientoscab_UPDATE", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd.Parameters.Add("@moduloiddes", SqlDbType.Char, 4).Value = BE.moduloiddes;
                    cmd.Parameters.Add("@localdes", SqlDbType.Char, 3).Value = BE.localdes;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = fecha(BE.fechdoc);
                    cmd.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE.almacaccionid;
                    cmd.Parameters.Add("@ctacteaccionid", SqlDbType.Char, 2).Value = BE.ctacteaccionid;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                    cmd.Parameters.Add("@direc", SqlDbType.VarChar, 70).Value = BE.direc;
                    cmd.Parameters.Add("@tipdid", SqlDbType.Char, 1).Value = BE.tipdid;
                    cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                    cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                    cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                    cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                    cmd.Parameters.Add("@fechref", SqlDbType.DateTime).Value = fecha(BE.fechref);
                    cmd.Parameters.Add("@tipped", SqlDbType.Char, 2).Value = BE.tipped;
                    cmd.Parameters.Add("@serped", SqlDbType.Char, 4).Value = BE.serped;
                    cmd.Parameters.Add("@numped", SqlDbType.Char, 10).Value = BE.numped;
                    cmd.Parameters.Add("@compradorid", SqlDbType.Char, 4).Value = BE.compradorid;
                    cmd.Parameters.Add("@condpagoid", SqlDbType.Char, 3).Value = BE.condpagoid;
                    cmd.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE.ubige;
                    cmd.Parameters.Add("@bruto", SqlDbType.Decimal).Value = BE.bruto;
                    cmd.Parameters.Add("@pdscto", SqlDbType.Decimal).Value = BE.pdscto;
                    cmd.Parameters.Add("@idscto", SqlDbType.Decimal).Value = BE.idscto;
                    cmd.Parameters.Add("@afectoigv", SqlDbType.Bit).Value = BE.afectoigv;
                    cmd.Parameters.Add("@pigv", SqlDbType.Decimal).Value = BE.pigv;
                    cmd.Parameters.Add("@incprec", SqlDbType.Char, 1).Value = BE.incprec;
                    cmd.Parameters.Add("@moneda", SqlDbType.Char).Value = BE.moneda;
                    cmd.Parameters.Add("@tcamb", SqlDbType.Decimal).Value = BE.tcamb;
                    cmd.Parameters.Add("@valventa", SqlDbType.Decimal).Value = BE.valventa;
                    cmd.Parameters.Add("@totimpto", SqlDbType.Decimal).Value = BE.totimpto;
                    cmd.Parameters.Add("@totimporte", SqlDbType.Decimal).Value = BE.totimporte;
                    cmd.Parameters.Add("@valor_ocompra", SqlDbType.Decimal).Value = BE.valor_ocompra;
                    cmd.Parameters.Add("@valor_guiado", SqlDbType.Decimal).Value = BE.valor_guiado;
                    cmd.Parameters.Add("@valor_facturado", SqlDbType.Decimal).Value = BE.valor_facturado;
                    cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 100).Value = BE.glosa;
                    cmd.Parameters.Add("@totpzas", SqlDbType.Decimal).Value = BE.totpzas;
                    cmd.Parameters.Add("@fechentrega", SqlDbType.DateTime).Value = fecha(BE.fechentrega);
                    cmd.Parameters.Add("@fechpago", SqlDbType.DateTime).Value = fecha(BE.fechpago);
                    cmd.Parameters.Add("@fechcancel", SqlDbType.DateTime).Value = fecha(BE.fechcancel);
                    cmd.Parameters.Add("@items", SqlDbType.Decimal).Value = BE.items;
                    cmd.Parameters.Add("@afecdetraccion", SqlDbType.Bit).Value = BE.afecdetraccion;
                    cmd.Parameters.Add("@detraccionid", SqlDbType.Char, 5).Value = BE.detraccionid;
                    cmd.Parameters.Add("@pdetraccion", SqlDbType.Decimal).Value = BE.pdetraccion;
                    cmd.Parameters.Add("@atencion", SqlDbType.VarChar, 100).Value = BE.atencion;
                    cmd.Parameters.Add("@puntollegada", SqlDbType.VarChar, 100).Value = BE.puntollegada;
                    cmd.Parameters.Add("@visado", SqlDbType.Bit).Value = BE.visado;
                    cmd.Parameters.Add("@usuarvisado", SqlDbType.Char, 15).Value = BE.usuarvisado;
                    cmd.Parameters.Add("@observacionvisado", SqlDbType.VarChar, 50).Value = BE.observacionvisado;
                    cmd.Parameters.Add("@fechvisado", SqlDbType.DateTime).Value = fecha(BE.fechvisado);
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
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

        public bool Delete(string empresaid, tb_cm_ordendecompracab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60Movimientoscab_DELETE", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;

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

        public DataSet GetAll_paginacion(string empresaid, tb_cm_ordendecompracab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCmOrdendecompracab_SEARCH_paginacion", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@posicion", SqlDbType.VarChar, 10).Value = BE.posicion;
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

        //*** OPT
        public DataSet GetAll(string empresaid, tb_cm_ordendecompracab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60Movimientoscab_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd.Parameters.Add("@moduloiddes", SqlDbType.Char, 4).Value = BE.moduloiddes;
                    cmd.Parameters.Add("@localdes", SqlDbType.Char, 3).Value = BE.localdes;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = fecha(BE.fechdoc);
                    cmd.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE.almacaccionid;
                    cmd.Parameters.Add("@ctacteaccionid", SqlDbType.Char, 2).Value = BE.ctacteaccionid;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                    cmd.Parameters.Add("@direc", SqlDbType.VarChar, 70).Value = BE.direc;
                    cmd.Parameters.Add("@tipdid", SqlDbType.Char, 1).Value = BE.tipdid;
                    cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                    cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                    cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                    cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                    cmd.Parameters.Add("@fechref", SqlDbType.DateTime).Value = fecha(BE.fechref);
                    cmd.Parameters.Add("@tipped", SqlDbType.Char, 2).Value = BE.tipped;
                    cmd.Parameters.Add("@serped", SqlDbType.Char, 4).Value = BE.serped;
                    cmd.Parameters.Add("@numped", SqlDbType.Char, 10).Value = BE.numped;
                    cmd.Parameters.Add("@compradorid", SqlDbType.Char, 4).Value = BE.compradorid;
                    cmd.Parameters.Add("@condpagoid", SqlDbType.Char, 3).Value = BE.condpagoid;
                    cmd.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE.ubige;
                    cmd.Parameters.Add("@bruto", SqlDbType.Decimal).Value = BE.bruto;
                    cmd.Parameters.Add("@pdscto", SqlDbType.Decimal).Value = BE.pdscto;
                    cmd.Parameters.Add("@idscto", SqlDbType.Decimal).Value = BE.idscto;
                    cmd.Parameters.Add("@afectoigv", SqlDbType.Bit).Value = BE.afectoigv;
                    cmd.Parameters.Add("@pigv", SqlDbType.Decimal).Value = BE.pigv;
                    cmd.Parameters.Add("@incprec", SqlDbType.Char, 1).Value = BE.incprec;
                    cmd.Parameters.Add("@moneda", SqlDbType.Char).Value = BE.moneda;
                    cmd.Parameters.Add("@tcamb", SqlDbType.Decimal).Value = BE.tcamb;
                    cmd.Parameters.Add("@valventa", SqlDbType.Decimal).Value = BE.valventa;
                    cmd.Parameters.Add("@totimpto", SqlDbType.Decimal).Value = BE.totimpto;
                    cmd.Parameters.Add("@totimporte", SqlDbType.Decimal).Value = BE.totimporte;
                    cmd.Parameters.Add("@valor_ocompra", SqlDbType.Decimal).Value = BE.valor_ocompra;
                    cmd.Parameters.Add("@valor_guiado", SqlDbType.Decimal).Value = BE.valor_guiado;
                    cmd.Parameters.Add("@valor_facturado", SqlDbType.Decimal).Value = BE.valor_facturado;
                    cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 100).Value = BE.glosa;
                    cmd.Parameters.Add("@totpzas", SqlDbType.Decimal).Value = BE.totpzas;
                    cmd.Parameters.Add("@fechentrega", SqlDbType.DateTime).Value = fecha(BE.fechentrega);
                    cmd.Parameters.Add("@fechpago", SqlDbType.DateTime).Value = fecha(BE.fechpago);
                    cmd.Parameters.Add("@fechcancel", SqlDbType.DateTime).Value = fecha(BE.fechcancel);
                    cmd.Parameters.Add("@items", SqlDbType.Decimal).Value = BE.items;
                    cmd.Parameters.Add("@afecdetraccion", SqlDbType.Bit).Value = BE.afecdetraccion;
                    cmd.Parameters.Add("@detraccionid", SqlDbType.Char, 5).Value = BE.detraccionid;
                    cmd.Parameters.Add("@pdetraccion", SqlDbType.Decimal).Value = BE.pdetraccion;
                    cmd.Parameters.Add("@atencion", SqlDbType.VarChar, 100).Value = BE.atencion;
                    cmd.Parameters.Add("@puntollegada", SqlDbType.VarChar, 100).Value = BE.puntollegada;
                    cmd.Parameters.Add("@visado", SqlDbType.Bit).Value = BE.visado;
                    cmd.Parameters.Add("@usuarvisado", SqlDbType.Char, 15).Value = BE.usuarvisado;
                    cmd.Parameters.Add("@observacionvisado", SqlDbType.VarChar, 50).Value = BE.observacionvisado;
                    cmd.Parameters.Add("@fechvisado", SqlDbType.DateTime).Value = fecha(BE.fechvisado);
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;

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

        public DataSet GetAll_CabDet(string empresaid, tb_cm_ordendecompracab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCmOrdencompra_SEARCH_CabDet", cnx))
                {
                    DataSet ds = new DataSet();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@moduloiddes", SqlDbType.Char, 4).Value = BE.moduloiddes;
                    cmd.Parameters.Add("@localdes", SqlDbType.Char, 3).Value = BE.localdes;
                    cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 60).Value = BE.ctactename;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;

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

        public DataSet GetOne(string empresaid, tb_cm_ordendecompracab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCmOrdendecompracab_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
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



        public DataSet GetOne_Shear(string empresaid, tb_cm_ordendecompradet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCmOrdendecompradet_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
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


        public DataSet GetOne_numdocs(string empresaid, tb_cm_ordendecompracab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCmOrdendecompracab_SELECT_numdocs", cnx))
                {
                    DataSet ds = new DataSet();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;


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
                if (pfecha != DateTime.Parse("01/01/0001 12:00:00 a.m.") || pfecha != DateTime.Parse("01/01/0001 00:00:00"))
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

        #endregion
    }
}
