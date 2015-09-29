using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_co_retencionDEtDA
    {
        public String Sql_Error = "";
        Conexion conex = new Conexion();

        public bool Insert(string empresaid, tb_co_retencionDEt BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRetencionesdet_INSERT", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                    cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
                    cmd.Parameters.Add("@asientoitems", SqlDbType.Char, 5).Value = BE.asientoitems;
                    cmd.Parameters.AddWithValue("@rubroid", string.IsNullOrEmpty(BE.rubroid) ? (object)DBNull.Value : BE.rubroid);
                    cmd.Parameters.AddWithValue("@tipdoc", string.IsNullOrEmpty(BE.tipdoc) ? (object)DBNull.Value : BE.tipdoc);
                    cmd.Parameters.AddWithValue("@serdoc", string.IsNullOrEmpty(BE.serdoc) ? (object)DBNull.Value : BE.serdoc);
                    cmd.Parameters.AddWithValue("@numdoc", string.IsNullOrEmpty(BE.numdoc) ? (object)DBNull.Value : BE.numdoc);
                    cmd.Parameters.AddWithValue("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                    cmd.Parameters.AddWithValue("@montopago1", SqlDbType.Decimal).Value = BE.montopago1;
                    cmd.Parameters.AddWithValue("@montopago2", SqlDbType.Decimal).Value = BE.montopago2;
                    cmd.Parameters.AddWithValue("@impretencion1", SqlDbType.Decimal).Value = BE.impretencion1;
                    cmd.Parameters.AddWithValue("@impretencion2", SqlDbType.Decimal).Value = BE.impretencion2;
                    cmd.Parameters.AddWithValue("@glosa", string.IsNullOrEmpty(BE.glosa) ? (object)DBNull.Value : BE.glosa);
                    cmd.Parameters.AddWithValue("@ctacte", string.IsNullOrEmpty(BE.ctacte) ? (object)DBNull.Value : BE.ctacte);
                    cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                    cmd.Parameters.AddWithValue("@cencosid", string.IsNullOrEmpty(BE.cencosid) ? (object)DBNull.Value : BE.cencosid); 
                    cmd.Parameters.AddWithValue("@pedido", string.IsNullOrEmpty(BE.pedido) ? (object)DBNull.Value : BE.pedido);
                    cmd.Parameters.AddWithValue("@numop", string.IsNullOrEmpty(BE.numop) ? (object)DBNull.Value : BE.numop);
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);                       
                    }
                }
            }
        }

        public bool Update(string empresaid, tb_co_retencionDEt BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRetencionesdet_UPDATE", cnx))
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
                        cmd.Parameters.Add("@asientoitems", SqlDbType.Char, 5).Value = BE.asientoitems;
                        cmd.Parameters.AddWithValue("@rubroid", string.IsNullOrEmpty(BE.rubroid) ? (object)DBNull.Value : BE.rubroid);
                        cmd.Parameters.AddWithValue("@tipdoc", string.IsNullOrEmpty(BE.tipdoc) ? (object)DBNull.Value : BE.tipdoc);
                        cmd.Parameters.AddWithValue("@serdoc", string.IsNullOrEmpty(BE.serdoc) ? (object)DBNull.Value : BE.serdoc);
                        cmd.Parameters.AddWithValue("@numdoc", string.IsNullOrEmpty(BE.numdoc) ? (object)DBNull.Value : BE.numdoc);
                        cmd.Parameters.AddWithValue("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                        cmd.Parameters.AddWithValue("@montopago1", SqlDbType.Decimal).Value = BE.montopago1;
                        cmd.Parameters.AddWithValue("@montopago2", SqlDbType.Decimal).Value = BE.montopago2;
                        cmd.Parameters.AddWithValue("@impretencion1", SqlDbType.Decimal).Value = BE.impretencion1;
                        cmd.Parameters.AddWithValue("@impretencion2", SqlDbType.Decimal).Value = BE.impretencion2;
                        cmd.Parameters.AddWithValue("@glosa", string.IsNullOrEmpty(BE.glosa) ? (object)DBNull.Value : BE.glosa);
                        cmd.Parameters.AddWithValue("@ctacte", string.IsNullOrEmpty(BE.ctacte) ? (object)DBNull.Value : BE.ctacte);
                        cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                        cmd.Parameters.AddWithValue("@cencosid", string.IsNullOrEmpty(BE.cencosid) ? (object)DBNull.Value : BE.cencosid);
                        cmd.Parameters.AddWithValue("@pedido", string.IsNullOrEmpty(BE.pedido) ? (object)DBNull.Value : BE.pedido);
                        cmd.Parameters.AddWithValue("@numop", string.IsNullOrEmpty(BE.numop) ? (object)DBNull.Value : BE.numop);
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public bool Delete(string empresaid, tb_co_retencionDEt BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRetencionesdet_DELETE", cnx))
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public DataSet GetAll(string empresaid, tb_co_retencionDEt BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRetencionDEt_consulta", cnx))
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
                        //cmd.Parameters.Add("@asientoitems", SqlDbType.Char, 5).Value = BE.asientoitems;
                        //cmd.Parameters.AddWithValue("@rubroid", string.IsNullOrEmpty(BE.rubroid) ? (object)DBNull.Value : BE.rubroid);
                        cmd.Parameters.AddWithValue("@tipdoc", string.IsNullOrEmpty(BE.tipdoc) ? (object)DBNull.Value : BE.tipdoc);
                        cmd.Parameters.AddWithValue("@serdoc", string.IsNullOrEmpty(BE.serdoc) ? (object)DBNull.Value : BE.serdoc);
                        cmd.Parameters.AddWithValue("@numdoc", string.IsNullOrEmpty(BE.numdoc) ? (object)DBNull.Value : BE.numdoc);
                        //cmd.Parameters.AddWithValue("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                        cmd.Parameters.AddWithValue("@fechaini", SqlDbType.DateTime).Value = BE.fechaini;
                        cmd.Parameters.AddWithValue("@fechafin", SqlDbType.DateTime).Value = BE.fechafin;
                        //cmd.Parameters.AddWithValue("@montopago1", SqlDbType.Decimal).Value = BE.montopago1;
                        //cmd.Parameters.AddWithValue("@montopago2", SqlDbType.Decimal).Value = BE.montopago2;
                        //cmd.Parameters.AddWithValue("@impretencion1", SqlDbType.Decimal).Value = BE.impretencion1;
                        //cmd.Parameters.AddWithValue("@impretencion2", SqlDbType.Decimal).Value = BE.impretencion2;
                        //cmd.Parameters.AddWithValue("@glosa", string.IsNullOrEmpty(BE.glosa) ? (object)DBNull.Value : BE.glosa);
                        //cmd.Parameters.AddWithValue("@ctacte", string.IsNullOrEmpty(BE.ctacte) ? (object)DBNull.Value : BE.ctacte);
                        //cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                        //cmd.Parameters.AddWithValue("@cencosid", string.IsNullOrEmpty(BE.cencosid) ? (object)DBNull.Value : BE.cencosid);
                        //cmd.Parameters.AddWithValue("@pedido", string.IsNullOrEmpty(BE.pedido) ? (object)DBNull.Value : BE.pedido);
                        //cmd.Parameters.AddWithValue("@numop", string.IsNullOrEmpty(BE.numop) ? (object)DBNull.Value : BE.numop);
                        //cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        //cmd.Parameters.AddWithValue("@usuar", string.IsNullOrEmpty(BE.usuar) ? (object)DBNull.Value : BE.usuar);
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
        public DataSet GetCRetencion(string empresaid, tb_co_retencionDEt BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRetenciones_ReporteCRetencion", cnx))
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
                        //cmd.Parameters.Add("@asientoini", SqlDbType.Char, 6).Value = BE.asientoini;
                        //cmd.Parameters.Add("@asientofin", SqlDbType.Char, 6).Value = BE.asientofin;
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

        public DataSet GetOne(string empresaid, tb_co_retencionDEt BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRetencionesdet_SELECT", cnx))
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);                    
                    }
                }
            }
        }
    }
}
