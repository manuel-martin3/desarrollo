using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_co_percepcionesdetDA
    {
        public String Sql_Error = "";
        Conexion conex = new Conexion();

        public bool Insert(string empresaid, tb_co_percepcionesdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoPercepcionesdet_INSERT", cnx))
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
                    cmd.Parameters.AddWithValue("@importecobrodolares1", SqlDbType.Decimal).Value = BE.importecobrodolares1;
                    cmd.Parameters.AddWithValue("@importecobrodolares2", SqlDbType.Decimal).Value = BE.importecobrodolares2;
                    cmd.Parameters.AddWithValue("@importepercepciondolares", SqlDbType.Decimal).Value = BE.importepercepciondolares;
                    cmd.Parameters.AddWithValue("@importetotaldolares", SqlDbType.Decimal).Value = BE.importetotaldolares;
                    cmd.Parameters.AddWithValue("@importedifcambio", SqlDbType.Decimal).Value = BE.importedifcambio;
                    cmd.Parameters.AddWithValue("@importeorigensoles", SqlDbType.Decimal).Value = BE.importeorigensoles;
                    cmd.Parameters.AddWithValue("@importecobrosoles", SqlDbType.Decimal).Value = BE.importecobrosoles;
                    cmd.Parameters.AddWithValue("@importeorigen", SqlDbType.Decimal).Value = BE.importeorigen;
                    cmd.Parameters.AddWithValue("@importecobranza", SqlDbType.Decimal).Value = BE.importecobranza;
                    cmd.Parameters.AddWithValue("@percepcionid", string.IsNullOrEmpty(BE.percepcionid) ? (object)DBNull.Value : BE.percepcionid);
                    cmd.Parameters.AddWithValue("@porcpercepcion", SqlDbType.Decimal).Value = BE.porcpercepcion;
                    cmd.Parameters.AddWithValue("@importepercepcionsoles", SqlDbType.Decimal).Value = BE.importepercepcionsoles;
                    cmd.Parameters.AddWithValue("@derechocreditofiscal", string.IsNullOrEmpty(BE.derechocreditofiscal) ? (object)DBNull.Value : BE.derechocreditofiscal);
                    cmd.Parameters.AddWithValue("@zonaafectadaterremoto", string.IsNullOrEmpty(BE.zonaafectadaterremoto) ? (object)DBNull.Value : BE.zonaafectadaterremoto);
                    cmd.Parameters.AddWithValue("@sujetoagenteperc", string.IsNullOrEmpty(BE.sujetoagenteperc) ? (object)DBNull.Value : BE.sujetoagenteperc);
                    cmd.Parameters.AddWithValue("@importetotalsoles", SqlDbType.Decimal).Value = BE.importetotalsoles;
                    cmd.Parameters.AddWithValue("@percepcion", SqlDbType.Bit).Value = BE.percepcion;
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

        public bool Update(string empresaid, tb_co_percepcionesdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoPercepcionesdet_UPDATE", cnx))
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
                        cmd.Parameters.AddWithValue("@importecobrodolares1", SqlDbType.Decimal).Value = BE.importecobrodolares1;
                        cmd.Parameters.AddWithValue("@importecobrodolares2", SqlDbType.Decimal).Value = BE.importecobrodolares2;
                        cmd.Parameters.AddWithValue("@importepercepciondolares", SqlDbType.Decimal).Value = BE.importepercepciondolares;
                        cmd.Parameters.AddWithValue("@importetotaldolares", SqlDbType.Decimal).Value = BE.importetotaldolares;
                        cmd.Parameters.AddWithValue("@importedifcambio", SqlDbType.Decimal).Value = BE.importedifcambio;
                        cmd.Parameters.AddWithValue("@importeorigensoles", SqlDbType.Decimal).Value = BE.importeorigensoles;
                        cmd.Parameters.AddWithValue("@importecobrosoles", SqlDbType.Decimal).Value = BE.importecobrosoles;
                        cmd.Parameters.AddWithValue("@importeorigen", SqlDbType.Decimal).Value = BE.importeorigen;
                        cmd.Parameters.AddWithValue("@importecobranza", SqlDbType.Decimal).Value = BE.importecobranza;
                        cmd.Parameters.AddWithValue("@percepcionid", string.IsNullOrEmpty(BE.percepcionid) ? (object)DBNull.Value : BE.percepcionid);
                        cmd.Parameters.AddWithValue("@porcpercepcion", SqlDbType.Decimal).Value = BE.porcpercepcion;
                        cmd.Parameters.AddWithValue("@importepercepcionsoles", SqlDbType.Decimal).Value = BE.importepercepcionsoles;
                        cmd.Parameters.AddWithValue("@derechocreditofiscal", string.IsNullOrEmpty(BE.derechocreditofiscal) ? (object)DBNull.Value : BE.derechocreditofiscal);
                        cmd.Parameters.AddWithValue("@zonaafectadaterremoto", string.IsNullOrEmpty(BE.zonaafectadaterremoto) ? (object)DBNull.Value : BE.zonaafectadaterremoto);
                        cmd.Parameters.AddWithValue("@sujetoagenteperc", string.IsNullOrEmpty(BE.sujetoagenteperc) ? (object)DBNull.Value : BE.sujetoagenteperc);
                        cmd.Parameters.AddWithValue("@importetotalsoles", SqlDbType.Decimal).Value = BE.importetotalsoles;
                        cmd.Parameters.AddWithValue("@percepcion", SqlDbType.Bit).Value = BE.percepcion;
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

        public bool Delete(string empresaid, tb_co_percepcionesdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoPercepcionesdet_DELETE", cnx))
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

        public DataSet GetAll(string empresaid, tb_co_percepcionesdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoPercepcionesdet_SEARCH", cnx))
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
                        //cmd.Parameters.AddWithValue("@importecobrodolares1", SqlDbType.Decimal).Value = BE.importecobrodolares1;
                        //cmd.Parameters.AddWithValue("@importecobrodolares2", SqlDbType.Decimal).Value = BE.importecobrodolares2;
                        //cmd.Parameters.AddWithValue("@importepercepciondolares", SqlDbType.Decimal).Value = BE.importepercepciondolares;
                        //cmd.Parameters.AddWithValue("@importetotaldolares", SqlDbType.Decimal).Value = BE.importetotaldolares;
                        //cmd.Parameters.AddWithValue("@importedifcambio", SqlDbType.Decimal).Value = BE.importedifcambio;
                        //cmd.Parameters.AddWithValue("@importeorigensoles", SqlDbType.Decimal).Value = BE.importeorigensoles;
                        //cmd.Parameters.AddWithValue("@importecobrosoles", SqlDbType.Decimal).Value = BE.importecobrosoles;
                        //cmd.Parameters.AddWithValue("@importeorigen", SqlDbType.Decimal).Value = BE.importeorigen;
                        //cmd.Parameters.AddWithValue("@importecobranza", SqlDbType.Decimal).Value = BE.importecobranza;
                        cmd.Parameters.AddWithValue("@percepcionid", string.IsNullOrEmpty(BE.percepcionid) ? (object)DBNull.Value : BE.percepcionid);
                        //cmd.Parameters.AddWithValue("@porcpercepcion", SqlDbType.Decimal).Value = BE.porcpercepcion;
                        //cmd.Parameters.AddWithValue("@importepercepcionsoles", SqlDbType.Decimal).Value = BE.importepercepcionsoles;
                        cmd.Parameters.AddWithValue("@derechocreditofiscal", string.IsNullOrEmpty(BE.derechocreditofiscal) ? (object)DBNull.Value : BE.derechocreditofiscal);
                        cmd.Parameters.AddWithValue("@zonaafectadaterremoto", string.IsNullOrEmpty(BE.zonaafectadaterremoto) ? (object)DBNull.Value : BE.zonaafectadaterremoto);
                        cmd.Parameters.AddWithValue("@sujetoagenteperc", string.IsNullOrEmpty(BE.sujetoagenteperc) ? (object)DBNull.Value : BE.sujetoagenteperc);
                        //cmd.Parameters.AddWithValue("@importetotalsoles", SqlDbType.Decimal).Value = BE.importetotalsoles;
                        cmd.Parameters.AddWithValue("@percepcion", SqlDbType.Bit).Value = BE.percepcion;
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
        public DataSet GetCPercepcion(string empresaid, tb_co_percepcionesdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoPercepcionesVtaInterna_ImpresionCP", cnx))
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
                        cmd.Parameters.Add("@asientoini", SqlDbType.Char, 6).Value = BE.asientoini;
                        cmd.Parameters.Add("@asientofin", SqlDbType.Char, 6).Value = BE.asientofin;
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

        public DataSet GetOne(string empresaid, tb_co_percepcionesdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoPercepcionesdet_SELECT", cnx))
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
