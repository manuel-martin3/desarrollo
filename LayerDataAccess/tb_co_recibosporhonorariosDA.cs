using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_co_recibosporhonorariosDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_co_recibosporhonorarios BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRecibosporhonorarios_INSERT", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                    cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
                    cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd.Parameters.Add("@tiperson", SqlDbType.Char, 2).Value = BE.tiperson;
                    cmd.Parameters.Add("@tipdid", SqlDbType.Char, 1).Value = BE.tipdid;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                    cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                    cmd.Parameters.Add("@fechregistro", SqlDbType.DateTime).Value = BE.fechregistro;
                    cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                    cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                    cmd.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                    cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 100).Value = BE.glosa;
                    cmd.Parameters.Add("@totalh1", SqlDbType.Decimal).Value = BE.totalh1;
                    cmd.Parameters.Add("@pretencion", SqlDbType.Decimal).Value = BE.pretencion;
                    cmd.Parameters.Add("@retencion1", SqlDbType.Decimal).Value = BE.retencion1;
                    cmd.Parameters.Add("@netoh1", SqlDbType.Decimal).Value = BE.netoh1;
                    cmd.Parameters.Add("@totalh2", SqlDbType.Decimal).Value = BE.totalh2;
                    cmd.Parameters.Add("@retencion2", SqlDbType.Decimal).Value = BE.retencion2;
                    cmd.Parameters.Add("@netoh2", SqlDbType.Decimal).Value = BE.netoh2;
                    cmd.Parameters.Add("@cuentaid", SqlDbType.Char, 10).Value = BE.cuentaid;
                    cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    cmd.Parameters.Add("@regpension", SqlDbType.Char, 1).Value = BE.regpension;
                    cmd.Parameters.Add("@afp", SqlDbType.Char, 2).Value = BE.afp;
                    cmd.Parameters.Add("@aporte", SqlDbType.Decimal).Value = BE.aporte;
                    cmd.Parameters.Add("@comision", SqlDbType.Decimal).Value = BE.comision;
                    cmd.Parameters.Add("@pseguro", SqlDbType.Decimal).Value = BE.pseguro;
                    cmd.Parameters.Add("@penaporte1", SqlDbType.Decimal).Value = BE.penaporte1;
                    cmd.Parameters.Add("@pencomision1", SqlDbType.Decimal).Value = BE.pencomision1;
                    cmd.Parameters.Add("@penpseguro1", SqlDbType.Decimal).Value = BE.penpseguro1;
                    cmd.Parameters.Add("@penaporte2", SqlDbType.Decimal).Value = BE.penaporte2;
                    cmd.Parameters.Add("@pencomision2", SqlDbType.Decimal).Value = BE.pencomision2;
                    cmd.Parameters.Add("@penpseguro2", SqlDbType.Decimal).Value = BE.penpseguro2;
                    cmd.Parameters.Add("@totalaporte1", SqlDbType.Decimal).Value = BE.totalaporte1;
                    cmd.Parameters.Add("@totalaporte2", SqlDbType.Decimal).Value = BE.totalaporte2;
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

        public bool Update(string empresaid, tb_co_recibosporhonorarios BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRecibosporhonorarios_UPDATE", cnx))
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
                        cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@tiperson", SqlDbType.Char, 2).Value = BE.tiperson;
                        cmd.Parameters.Add("@tipdid", SqlDbType.Char, 1).Value = BE.tipdid;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                        cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                        cmd.Parameters.Add("@fechregistro", SqlDbType.DateTime).Value = BE.fechregistro;
                        cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                        cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 100).Value = BE.glosa;
                        cmd.Parameters.Add("@totalh1", SqlDbType.Decimal).Value = BE.totalh1;
                        cmd.Parameters.Add("@pretencion", SqlDbType.Decimal).Value = BE.pretencion;
                        cmd.Parameters.Add("@retencion1", SqlDbType.Decimal).Value = BE.retencion1;
                        cmd.Parameters.Add("@netoh1", SqlDbType.Decimal).Value = BE.netoh1;
                        cmd.Parameters.Add("@totalh2", SqlDbType.Decimal).Value = BE.totalh2;
                        cmd.Parameters.Add("@retencion2", SqlDbType.Decimal).Value = BE.retencion2;
                        cmd.Parameters.Add("@netoh2", SqlDbType.Decimal).Value = BE.netoh2;
                        cmd.Parameters.Add("@cuentaid", SqlDbType.Char, 10).Value = BE.cuentaid;
                        cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                        cmd.Parameters.Add("@regpension", SqlDbType.Char, 1).Value = BE.regpension;
                        cmd.Parameters.Add("@afp", SqlDbType.Char, 2).Value = BE.afp;
                        cmd.Parameters.Add("@aporte", SqlDbType.Decimal).Value = BE.aporte;
                        cmd.Parameters.Add("@comision", SqlDbType.Decimal).Value = BE.comision;
                        cmd.Parameters.Add("@pseguro", SqlDbType.Decimal).Value = BE.pseguro;
                        cmd.Parameters.Add("@penaporte1", SqlDbType.Decimal).Value = BE.penaporte1;
                        cmd.Parameters.Add("@pencomision1", SqlDbType.Decimal).Value = BE.pencomision1;
                        cmd.Parameters.Add("@penpseguro1", SqlDbType.Decimal).Value = BE.penpseguro1;
                        cmd.Parameters.Add("@penaporte2", SqlDbType.Decimal).Value = BE.penaporte2;
                        cmd.Parameters.Add("@pencomision2", SqlDbType.Decimal).Value = BE.pencomision2;
                        cmd.Parameters.Add("@penpseguro2", SqlDbType.Decimal).Value = BE.penpseguro2;
                        cmd.Parameters.Add("@totalaporte1", SqlDbType.Decimal).Value = BE.totalaporte1;
                        cmd.Parameters.Add("@totalaporte2", SqlDbType.Decimal).Value = BE.totalaporte2;
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

        public bool Delete(string empresaid, tb_co_recibosporhonorarios BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRecibosporhonorarios_DELETE", cnx))
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

        public DataSet GetAll(string empresaid, tb_co_recibosporhonorarios BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRecibosporhonorarios_SEARCH", cnx))
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
                        cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@tiperson", SqlDbType.Char, 2).Value = BE.tiperson;
                        cmd.Parameters.Add("@tipdid", SqlDbType.Char, 1).Value = BE.tipdid;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                        cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                        cmd.Parameters.Add("@fechregistro", SqlDbType.DateTime).Value = BE.fechregistro;
                        cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        //cmd.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                        cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 100).Value = BE.glosa;
                        //cmd.Parameters.Add("@totalh1", SqlDbType.Decimal).Value = BE.totalh1;
                        //cmd.Parameters.Add("@pretencion", SqlDbType.Decimal).Value = BE.pretencion;
                        //cmd.Parameters.Add("@retencion1", SqlDbType.Decimal).Value = BE.retencion1;
                        //cmd.Parameters.Add("@netoh1", SqlDbType.Decimal).Value = BE.netoh1;
                        //cmd.Parameters.Add("@totalhe", SqlDbType.Decimal).Value = BE.totalh2;
                        //cmd.Parameters.Add("@retencione", SqlDbType.Decimal).Value = BE.retencion2;
                        //cmd.Parameters.Add("@netohe", SqlDbType.Decimal).Value = BE.netoh2;
                        cmd.Parameters.Add("@cuentaid", SqlDbType.Char, 10).Value = BE.cuentaid;
                        cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
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

        public DataSet GetAllAyuda(string empresaid, tb_co_recibosporhonorarios BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRecibosporhonorarios_SEARCH_Ayuda", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        //cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 8).Value = BE.asiento;
                        cmd.Parameters.Add("@fecha_ini", SqlDbType.Char, 8).Value = BE.fechaini;
                        cmd.Parameters.Add("@fecha_fin", SqlDbType.Char, 8).Value = BE.fechafin;
                        cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                        cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 100).Value = BE.glosa;
                        cmd.Parameters.Add("@norden", SqlDbType.Int).Value = BE.nOrden;                                               
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

        public DataSet GetAsientoNume(string empresaid, tb_co_recibosporhonorarios BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRecibosporhonorarios_SEARCH_asientonume", cnx))
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

        public DataSet GetAsientoRoleo(string empresaid, tb_co_recibosporhonorarios BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRecibosporhonorarios_SEARCH_roleo", cnx))
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

        public DataSet GetOne(string empresaid, tb_co_recibosporhonorarios BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRecibosporhonorarios_SELECT", cnx))
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

        public DataSet GetReporteLibroRetenciones(string empresaid, tb_co_recibosporhonorarios BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRecibosporhonorarios_ReporteLibroRetenciones", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        if (BE.fechaini == "")
                        { cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = BE.fechaini; }
                        if (BE.fechafin == "")
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = BE.fechafin; }
                        cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                        cmd.Parameters.Add("@nQuiebre", SqlDbType.Int).Value = BE.nQuiebre;
                        cmd.Parameters.Add("@nOrden", SqlDbType.Int).Value = BE.nOrden;
                        if (BE.f_impresion == "")
                        { cmd.Parameters.Add("@f_impresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@f_impresion", System.Data.SqlDbType.DateTime).Value = BE.f_impresion; }
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

        public DataSet GetReporteCertificadoRetenciones(string empresaid, tb_co_recibosporhonorarios BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRecibosporhonorarios_ReporteCertificadoRetenciones", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = BE.empresaid;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                        if (BE.f_impresion == "")
                        { cmd.Parameters.Add("@f_impresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@f_impresion", System.Data.SqlDbType.DateTime).Value = BE.f_impresion; }
                        cmd.Parameters.Add("@xretencion", SqlDbType.Int).Value = BE.xretencion;
                        cmd.Parameters.Add("@lugar", SqlDbType.VarChar, 40).Value = BE.ctactename;
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
