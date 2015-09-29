using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_co_canjeletrafacDA
    {
        Conexion conex = new Conexion();

        public bool Insert(string empresaid, tb_co_canjeletrafac BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoCanjeletrafac_INSERT", cnx))
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
                    cmd.Parameters.AddWithValue("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                    cmd.Parameters.AddWithValue("@tipcambuso", string.IsNullOrEmpty(BE.tipcambuso) ? (object)DBNull.Value : BE.tipcambuso);
                    cmd.Parameters.AddWithValue("@motivo", string.IsNullOrEmpty(BE.motivo) ? (object)DBNull.Value : BE.motivo);
                    cmd.Parameters.AddWithValue("@importeorigendolares", SqlDbType.Decimal).Value = BE.importeorigendolares;
                    cmd.Parameters.AddWithValue("@importepagodolares1", SqlDbType.Decimal).Value = BE.importepagodolares1;
                    cmd.Parameters.AddWithValue("@importepagodolares2", SqlDbType.Decimal).Value = BE.importepagodolares2;
                    cmd.Parameters.AddWithValue("@importeretenciondolares", SqlDbType.Decimal).Value = BE.importeretenciondolares;
                    cmd.Parameters.AddWithValue("@importenetodolares", SqlDbType.Decimal).Value = BE.importenetodolares;
                    cmd.Parameters.AddWithValue("@importedifcambio", SqlDbType.Decimal).Value = BE.importedifcambio;
                    cmd.Parameters.AddWithValue("@importeorigensoles", SqlDbType.Decimal).Value = BE.importeorigensoles;
                    cmd.Parameters.AddWithValue("@importepagosoles", SqlDbType.Decimal).Value = BE.importepagosoles;
                    cmd.Parameters.AddWithValue("@importeorigen", SqlDbType.Decimal).Value = BE.importeorigen;
                    cmd.Parameters.AddWithValue("@importepago", SqlDbType.Decimal).Value = BE.importepago;
                    cmd.Parameters.AddWithValue("@importeretencionsoles", SqlDbType.Decimal).Value = BE.importeretencionsoles;
                    cmd.Parameters.AddWithValue("@importenetosoles", SqlDbType.Decimal).Value = BE.importenetosoles;
                    cmd.Parameters.AddWithValue("@retencion", SqlDbType.Bit).Value = BE.retencion;
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

        public bool Update(string empresaid, tb_co_canjeletrafac BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoCanjeletrafac_UPDATE", cnx))
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
                        cmd.Parameters.AddWithValue("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                        cmd.Parameters.AddWithValue("@tipcambuso", string.IsNullOrEmpty(BE.tipcambuso) ? (object)DBNull.Value : BE.tipcambuso);
                        cmd.Parameters.AddWithValue("@motivo", string.IsNullOrEmpty(BE.motivo) ? (object)DBNull.Value : BE.motivo);
                        cmd.Parameters.AddWithValue("@importeorigendolares", SqlDbType.Decimal).Value = BE.importeorigendolares;
                        cmd.Parameters.AddWithValue("@importepagodolares1", SqlDbType.Decimal).Value = BE.importepagodolares1;
                        cmd.Parameters.AddWithValue("@importepagodolares2", SqlDbType.Decimal).Value = BE.importepagodolares2;
                        cmd.Parameters.AddWithValue("@importeretenciondolares", SqlDbType.Decimal).Value = BE.importeretenciondolares;
                        cmd.Parameters.AddWithValue("@importenetodolares", SqlDbType.Decimal).Value = BE.importenetodolares;
                        cmd.Parameters.AddWithValue("@importedifcambio", SqlDbType.Decimal).Value = BE.importedifcambio;
                        cmd.Parameters.AddWithValue("@importeorigensoles", SqlDbType.Decimal).Value = BE.importeorigensoles;
                        cmd.Parameters.AddWithValue("@importepagosoles", SqlDbType.Decimal).Value = BE.importepagosoles;
                        cmd.Parameters.AddWithValue("@importeorigen", SqlDbType.Decimal).Value = BE.importeorigen;
                        cmd.Parameters.AddWithValue("@importepago", SqlDbType.Decimal).Value = BE.importepago;
                        cmd.Parameters.AddWithValue("@importeretencionsoles", SqlDbType.Decimal).Value = BE.importeretencionsoles;
                        cmd.Parameters.AddWithValue("@importenetosoles", SqlDbType.Decimal).Value = BE.importenetosoles;
                        cmd.Parameters.AddWithValue("@retencion", SqlDbType.Bit).Value = BE.retencion;
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

        public bool Delete(string empresaid, tb_co_canjeletrafac BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoCanjeletrafac_DELETE", cnx))
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

        public DataSet GetAll(string empresaid, tb_co_canjeletrafac BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoCanjeletrafac_SEARCH", cnx))
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
                        cmd.Parameters.AddWithValue("@tipcambuso", string.IsNullOrEmpty(BE.tipcambuso) ? (object)DBNull.Value : BE.tipcambuso);
                        cmd.Parameters.AddWithValue("@motivo", string.IsNullOrEmpty(BE.motivo) ? (object)DBNull.Value : BE.motivo);
                        //cmd.Parameters.AddWithValue("@importeorigendolares", SqlDbType.Decimal).Value = BE.importeorigendolares;
                        //cmd.Parameters.AddWithValue("@importepagodolares1", SqlDbType.Decimal).Value = BE.importepagodolares1;
                        //cmd.Parameters.AddWithValue("@importepagodolares2", SqlDbType.Decimal).Value = BE.importepagodolares2;
                        //cmd.Parameters.AddWithValue("@importeretenciondolares", SqlDbType.Decimal).Value = BE.importeretenciondolares;
                        //cmd.Parameters.AddWithValue("@importenetodolares", SqlDbType.Decimal).Value = BE.importenetodolares;
                        //cmd.Parameters.AddWithValue("@importedifcambio", SqlDbType.Decimal).Value = BE.importedifcambio;
                        //cmd.Parameters.AddWithValue("@importeorigensoles", SqlDbType.Decimal).Value = BE.importeorigensoles;
                        //cmd.Parameters.AddWithValue("@importepagosoles", SqlDbType.Decimal).Value = BE.importepagosoles;
                        //cmd.Parameters.AddWithValue("@importeorigen", SqlDbType.Decimal).Value = BE.importeorigen;
                        //cmd.Parameters.AddWithValue("@importepago", SqlDbType.Decimal).Value = BE.importepago;
                        //cmd.Parameters.AddWithValue("@importeretencionsoles", SqlDbType.Decimal).Value = BE.importeretencionsoles;
                        //cmd.Parameters.AddWithValue("@importenetosoles", SqlDbType.Decimal).Value = BE.importenetosoles;
                        cmd.Parameters.AddWithValue("@retencion", SqlDbType.Bit).Value = BE.retencion;
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

        public DataSet GetOne(string empresaid, tb_co_canjeletrafac BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoCanjeletrafac_SELECT", cnx))
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
