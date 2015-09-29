using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_co_canjeletradetDA
    {
        Conexion conex = new Conexion();

        public bool Insert(string empresaid, tb_co_canjeletradet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoCanjeletradet_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                    cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
                    cmd.Parameters.Add("@asientoitems", SqlDbType.Char, 5).Value = BE.asientoitems;
                    cmd.Parameters.AddWithValue("@cuentaid", string.IsNullOrEmpty(BE.cuentaid) ? (object)DBNull.Value : BE.cuentaid);
                    cmd.Parameters.AddWithValue("@ctacte", string.IsNullOrEmpty(BE.ctacte) ? (object)DBNull.Value : BE.ctacte);
                    cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                    cmd.Parameters.AddWithValue("@tipdoc", string.IsNullOrEmpty(BE.tipdoc) ? (object)DBNull.Value : BE.tipdoc);
                    cmd.Parameters.AddWithValue("@serdoc", string.IsNullOrEmpty(BE.serdoc) ? (object)DBNull.Value : BE.serdoc);
                    cmd.Parameters.AddWithValue("@numdoc", string.IsNullOrEmpty(BE.numdoc) ? (object)DBNull.Value : BE.numdoc);
                    cmd.Parameters.AddWithValue("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                    cmd.Parameters.AddWithValue("@fechvcto", SqlDbType.DateTime).Value = BE.fechvcto;
                    cmd.Parameters.AddWithValue("@fechpago", SqlDbType.DateTime).Value = BE.fechpago;
                    cmd.Parameters.AddWithValue("@moneda", string.IsNullOrEmpty(BE.moneda) ? (object)DBNull.Value : BE.moneda);
                    //cmd.Parameters.AddWithValue("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                    //cmd.Parameters.AddWithValue("@tipcambuso", string.IsNullOrEmpty(BE.tipcambuso) ? (object)DBNull.Value : BE.tipcambuso);
                    //cmd.Parameters.AddWithValue("@motivo", string.IsNullOrEmpty(BE.motivo) ? (object)DBNull.Value : BE.motivo);
                    cmd.Parameters.AddWithValue("@importe1", SqlDbType.Decimal).Value = BE.importe1;
                    cmd.Parameters.AddWithValue("@total1", SqlDbType.Decimal).Value = BE.total1;
                    cmd.Parameters.AddWithValue("@importe2", SqlDbType.Decimal).Value = BE.importe2;
                    cmd.Parameters.AddWithValue("@total2", SqlDbType.Decimal).Value = BE.total2;
                    cmd.Parameters.AddWithValue("@ctacte1", string.IsNullOrEmpty(BE.ctacte1) ? (object)DBNull.Value : BE.ctacte1);
                    cmd.Parameters.AddWithValue("@nmruc1", string.IsNullOrEmpty(BE.nmruc1) ? (object)DBNull.Value : BE.nmruc1);
                    cmd.Parameters.AddWithValue("@ctactename1", string.IsNullOrEmpty(BE.ctactename1) ? (object)DBNull.Value : BE.ctactename1);
                    cmd.Parameters.AddWithValue("@direc1", string.IsNullOrEmpty(BE.direc1) ? (object)DBNull.Value : BE.direc1);
                    cmd.Parameters.AddWithValue("@ctacte2", string.IsNullOrEmpty(BE.ctacte2) ? (object)DBNull.Value : BE.ctacte2);
                    cmd.Parameters.AddWithValue("@nmruc2", string.IsNullOrEmpty(BE.nmruc2) ? (object)DBNull.Value : BE.nmruc2);
                    cmd.Parameters.AddWithValue("@ctactename2", string.IsNullOrEmpty(BE.ctactename2) ? (object)DBNull.Value : BE.ctactename2);
                    cmd.Parameters.AddWithValue("@direc2", string.IsNullOrEmpty(BE.direc2) ? (object)DBNull.Value : BE.direc2);
                    cmd.Parameters.AddWithValue("@importeenletras", string.IsNullOrEmpty(BE.importeenletras) ? (object)DBNull.Value : BE.importeenletras);
                    cmd.Parameters.AddWithValue("@telefaval", string.IsNullOrEmpty(BE.telefaval) ? (object)DBNull.Value : BE.telefaval);
                    cmd.Parameters.AddWithValue("@cantletras", SqlDbType.Decimal).Value = BE.cantletras;
                    cmd.Parameters.AddWithValue("@cantdias", SqlDbType.Decimal).Value = BE.cantdias;
                    //cmd.Parameters.AddWithValue("@retencion", SqlDbType.Bit).Value = BE.retencion;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd.Parameters.AddWithValue("@usuar", string.IsNullOrEmpty(BE.usuar) ? (object)DBNull.Value : BE.usuar);

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

        public bool Update(string empresaid, tb_co_canjeletradet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoCanjeletradet_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
                        cmd.Parameters.Add("@asientoitems", SqlDbType.Char, 5).Value = BE.asientoitems;
                        cmd.Parameters.AddWithValue("@cuentaid", string.IsNullOrEmpty(BE.cuentaid) ? (object)DBNull.Value : BE.cuentaid);
                        cmd.Parameters.AddWithValue("@ctacte", string.IsNullOrEmpty(BE.ctacte) ? (object)DBNull.Value : BE.ctacte);
                        cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                        cmd.Parameters.AddWithValue("@tipdoc", string.IsNullOrEmpty(BE.tipdoc) ? (object)DBNull.Value : BE.tipdoc);
                        cmd.Parameters.AddWithValue("@serdoc", string.IsNullOrEmpty(BE.serdoc) ? (object)DBNull.Value : BE.serdoc);
                        cmd.Parameters.AddWithValue("@numdoc", string.IsNullOrEmpty(BE.numdoc) ? (object)DBNull.Value : BE.numdoc);
                        cmd.Parameters.AddWithValue("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                        cmd.Parameters.AddWithValue("@fechvcto", SqlDbType.DateTime).Value = BE.fechvcto;
                        cmd.Parameters.AddWithValue("@fechpago", SqlDbType.DateTime).Value = BE.fechpago;
                        cmd.Parameters.AddWithValue("@moneda", string.IsNullOrEmpty(BE.moneda) ? (object)DBNull.Value : BE.moneda);
                        //cmd.Parameters.AddWithValue("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                        //cmd.Parameters.AddWithValue("@tipcambuso", string.IsNullOrEmpty(BE.tipcambuso) ? (object)DBNull.Value : BE.tipcambuso);
                        //cmd.Parameters.AddWithValue("@motivo", string.IsNullOrEmpty(BE.motivo) ? (object)DBNull.Value : BE.motivo);
                        cmd.Parameters.AddWithValue("@importe1", SqlDbType.Decimal).Value = BE.importe1;
                        cmd.Parameters.AddWithValue("@total1", SqlDbType.Decimal).Value = BE.total1;
                        cmd.Parameters.AddWithValue("@importe2", SqlDbType.Decimal).Value = BE.importe2;
                        cmd.Parameters.AddWithValue("@total2", SqlDbType.Decimal).Value = BE.total2;
                        cmd.Parameters.AddWithValue("@ctacte1", string.IsNullOrEmpty(BE.ctacte1) ? (object)DBNull.Value : BE.ctacte1);
                        cmd.Parameters.AddWithValue("@nmruc1", string.IsNullOrEmpty(BE.nmruc1) ? (object)DBNull.Value : BE.nmruc1);
                        cmd.Parameters.AddWithValue("@ctactename1", string.IsNullOrEmpty(BE.ctactename1) ? (object)DBNull.Value : BE.ctactename1);
                        cmd.Parameters.AddWithValue("@direc1", string.IsNullOrEmpty(BE.direc1) ? (object)DBNull.Value : BE.direc1);
                        cmd.Parameters.AddWithValue("@ctacte2", string.IsNullOrEmpty(BE.ctacte2) ? (object)DBNull.Value : BE.ctacte2);
                        cmd.Parameters.AddWithValue("@nmruc2", string.IsNullOrEmpty(BE.nmruc2) ? (object)DBNull.Value : BE.nmruc2);
                        cmd.Parameters.AddWithValue("@ctactename2", string.IsNullOrEmpty(BE.ctactename2) ? (object)DBNull.Value : BE.ctactename2);
                        cmd.Parameters.AddWithValue("@direc2", string.IsNullOrEmpty(BE.direc2) ? (object)DBNull.Value : BE.direc2);
                        cmd.Parameters.AddWithValue("@importeenletras", string.IsNullOrEmpty(BE.importeenletras) ? (object)DBNull.Value : BE.importeenletras);
                        cmd.Parameters.AddWithValue("@telefaval", string.IsNullOrEmpty(BE.telefaval) ? (object)DBNull.Value : BE.telefaval);
                        cmd.Parameters.AddWithValue("@cantletras", SqlDbType.Decimal).Value = BE.cantletras;
                        cmd.Parameters.AddWithValue("@cantdias", SqlDbType.Decimal).Value = BE.cantdias;
                        //cmd.Parameters.AddWithValue("@retencion", SqlDbType.Bit).Value = BE.retencion;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.AddWithValue("@usuar", string.IsNullOrEmpty(BE.usuar) ? (object)DBNull.Value : BE.usuar);
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

        public bool Delete(string empresaid, tb_co_canjeletradet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoCanjeletradet_DELETE", cnx))
                {
                    {
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

        public DataSet GetAll(string empresaid, tb_co_canjeletradet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoCanjeletradet_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
                        cmd.Parameters.Add("@asientoitems", SqlDbType.Char, 5).Value = BE.asientoitems;
                        cmd.Parameters.AddWithValue("@cuentaid", string.IsNullOrEmpty(BE.cuentaid) ? (object)DBNull.Value : BE.cuentaid);
                        cmd.Parameters.AddWithValue("@ctacte", string.IsNullOrEmpty(BE.ctacte) ? (object)DBNull.Value : BE.ctacte);
                        cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                        cmd.Parameters.AddWithValue("@tipdoc", string.IsNullOrEmpty(BE.tipdoc) ? (object)DBNull.Value : BE.tipdoc);
                        cmd.Parameters.AddWithValue("@serdoc", string.IsNullOrEmpty(BE.serdoc) ? (object)DBNull.Value : BE.serdoc);
                        cmd.Parameters.AddWithValue("@numdoc", string.IsNullOrEmpty(BE.numdoc) ? (object)DBNull.Value : BE.numdoc);
                        cmd.Parameters.AddWithValue("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                        cmd.Parameters.AddWithValue("@fechvcto", SqlDbType.DateTime).Value = BE.fechvcto;
                        cmd.Parameters.AddWithValue("@fechpago", SqlDbType.DateTime).Value = BE.fechpago;
                        cmd.Parameters.AddWithValue("@moneda", string.IsNullOrEmpty(BE.moneda) ? (object)DBNull.Value : BE.moneda);
                        //cmd.Parameters.AddWithValue("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                        //cmd.Parameters.AddWithValue("@tipcambuso", string.IsNullOrEmpty(BE.tipcambuso) ? (object)DBNull.Value : BE.tipcambuso);
                        //cmd.Parameters.AddWithValue("@motivo", string.IsNullOrEmpty(BE.motivo) ? (object)DBNull.Value : BE.motivo);
                        //cmd.Parameters.AddWithValue("@importe1", SqlDbType.Decimal).Value = BE.importe1;
                        //cmd.Parameters.AddWithValue("@total1", SqlDbType.Decimal).Value = BE.total1;
                        //cmd.Parameters.AddWithValue("@importe2", SqlDbType.Decimal).Value = BE.importe2;
                        //cmd.Parameters.AddWithValue("@total2", SqlDbType.Decimal).Value = BE.total2;
                        cmd.Parameters.AddWithValue("@ctacte1", string.IsNullOrEmpty(BE.ctacte1) ? (object)DBNull.Value : BE.ctacte1);
                        cmd.Parameters.AddWithValue("@nmruc1", string.IsNullOrEmpty(BE.nmruc1) ? (object)DBNull.Value : BE.nmruc1);
                        cmd.Parameters.AddWithValue("@ctactename1", string.IsNullOrEmpty(BE.ctactename1) ? (object)DBNull.Value : BE.ctactename1);
                        cmd.Parameters.AddWithValue("@direc1", string.IsNullOrEmpty(BE.direc1) ? (object)DBNull.Value : BE.direc1);
                        cmd.Parameters.AddWithValue("@ctacte2", string.IsNullOrEmpty(BE.ctacte2) ? (object)DBNull.Value : BE.ctacte2);
                        cmd.Parameters.AddWithValue("@nmruc2", string.IsNullOrEmpty(BE.nmruc2) ? (object)DBNull.Value : BE.nmruc2);
                        cmd.Parameters.AddWithValue("@ctactename2", string.IsNullOrEmpty(BE.ctactename2) ? (object)DBNull.Value : BE.ctactename2);
                        cmd.Parameters.AddWithValue("@direc2", string.IsNullOrEmpty(BE.direc2) ? (object)DBNull.Value : BE.direc2);
                        cmd.Parameters.AddWithValue("@importeenletras", string.IsNullOrEmpty(BE.importeenletras) ? (object)DBNull.Value : BE.importeenletras);
                        cmd.Parameters.AddWithValue("@telefaval", string.IsNullOrEmpty(BE.telefaval) ? (object)DBNull.Value : BE.telefaval);
                        //cmd.Parameters.AddWithValue("@cantletras", SqlDbType.Decimal).Value = BE.cantletras;
                        //cmd.Parameters.AddWithValue("@cantdias", SqlDbType.Decimal).Value = BE.cantdias;
                        //cmd.Parameters.AddWithValue("@retencion", SqlDbType.Bit).Value = BE.retencion;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.AddWithValue("@usuar", string.IsNullOrEmpty(BE.usuar) ? (object)DBNull.Value : BE.usuar);
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

        public DataSet GetOne(string empresaid, tb_co_canjeletradet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoCanjeletradet_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
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
