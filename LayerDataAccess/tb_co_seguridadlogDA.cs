using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_co_seguridadlogDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_co_seguridadlog BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoSeguridadlog_INSERT", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@moduloid", SqlDbType.VarChar, 70).Value = BE.moduloid;
                    cmd.Parameters.Add("@clave", SqlDbType.VarChar, 150).Value = BE.clave;
                    cmd.Parameters.Add("@cuser", SqlDbType.Char, 20).Value = BE.cuser;
                    cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = BE.fecha;
                    //cmd.Parameters.Add("@correlativo", SqlDbType.Timestamp).Value = BE.@correlativo;
                    cmd.Parameters.Add("@pc", SqlDbType.VarChar, 60).Value = BE.pc;
                    cmd.Parameters.Add("@accion", SqlDbType.Char, 1).Value = BE.accion;
                    cmd.Parameters.Add("@detalle", SqlDbType.VarChar, 150).Value = BE.detalle;

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

        public bool Update(string empresaid, tb_co_seguridadlog BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoSeguridadlog_UPDATE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.VarChar, 70).Value = BE.moduloid;
                        cmd.Parameters.Add("@clave", SqlDbType.VarChar, 150).Value = BE.clave;
                        cmd.Parameters.Add("@cuser", SqlDbType.Char, 20).Value = BE.cuser;
                        cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = BE.fecha;
                        //cmd.Parameters.Add("@correlativo", SqlDbType.Timestamp).Value = BE.@correlativo;
                        cmd.Parameters.Add("@pc", SqlDbType.VarChar, 60).Value = BE.pc;
                        cmd.Parameters.Add("@accion", SqlDbType.Char, 1).Value = BE.accion;
                        cmd.Parameters.Add("@detalle", SqlDbType.VarChar, 150).Value = BE.detalle;
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

        public bool Delete(string empresaid, tb_co_seguridadlog BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoSeguridadlog_DELETE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.VarChar, 70).Value = BE.moduloid;
                        cmd.Parameters.Add("@clave", SqlDbType.VarChar, 150).Value = BE.clave;
                        cmd.Parameters.Add("@cuser", SqlDbType.Char, 20).Value = BE.cuser;
                        cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = BE.fecha;
                        //cmd.Parameters.Add("@correlativo", SqlDbType.Timestamp).Value = BE.@correlativo;
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

        public DataSet GetAll(string empresaid, tb_co_seguridadlog BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoSeguridadlog_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.VarChar, 70).Value = BE.moduloid;
                        cmd.Parameters.Add("@clave", SqlDbType.VarChar, 150).Value = BE.clave;
                        cmd.Parameters.Add("@cuser", SqlDbType.Char, 20).Value = BE.cuser;
                        cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = BE.fecha;
                        //cmd.Parameters.Add("@correlativo", SqlDbType.Timestamp).Value = BE.@correlativo;
                        cmd.Parameters.Add("@pc", SqlDbType.VarChar, 60).Value = BE.pc;
                        cmd.Parameters.Add("@accion", SqlDbType.Char, 1).Value = BE.accion;
                        cmd.Parameters.Add("@detalle", SqlDbType.VarChar, 150).Value = BE.detalle;
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

        public DataSet GetAllListado(string empresaid, tb_co_seguridadlog BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoSeguridadlog_LISTADO", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.VarChar, 70).Value = BE.moduloid;
                        cmd.Parameters.Add("@clave", SqlDbType.VarChar, 150).Value = BE.clave;
                        cmd.Parameters.Add("@cuser", SqlDbType.Char, 20).Value = BE.cuser;
                        cmd.Parameters.Add("@fechaini", SqlDbType.DateTime).Value = BE.fecha;
                        cmd.Parameters.Add("@fechafin", SqlDbType.DateTime).Value = BE.fechafin;
                        //cmd.Parameters.Add("@correlativo", SqlDbType.Timestamp).Value = BE.@correlativo;
                        cmd.Parameters.Add("@pc", SqlDbType.VarChar, 60).Value = BE.pc;
                        cmd.Parameters.Add("@accion", SqlDbType.Char, 1).Value = BE.accion;
                        cmd.Parameters.Add("@detalle", SqlDbType.VarChar, 150).Value = BE.detalle;
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

        public DataSet GetAllSeguridadlog(string empresaid, tb_co_seguridadlog BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoSeguridadlog_SEARCH_consul", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@modulo", SqlDbType.VarChar, 70).Value = BE.moduloid;
                        cmd.Parameters.Add("@clave", SqlDbType.VarChar, 150).Value = BE.clave;
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

        public DataSet GetOne(string empresaid, tb_co_seguridadlog BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoSeguridadlog_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.VarChar, 70).Value = BE.moduloid;
                        cmd.Parameters.Add("@clave", SqlDbType.VarChar, 150).Value = BE.clave;
                        cmd.Parameters.Add("@cuser", SqlDbType.Char, 20).Value = BE.cuser;
                        cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = BE.fecha;
                        //cmd.Parameters.Add("@correlativo", SqlDbType.Timestamp).Value = BE.@correlativo;
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
