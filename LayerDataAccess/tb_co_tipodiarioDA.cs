using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_co_tipodiarioDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_co_tipodiario BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTipodiario_INSERT", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                    cmd.Parameters.Add("@sigla", SqlDbType.Char, 3).Value = BE.sigla;
                    cmd.Parameters.Add("@diarioname", SqlDbType.VarChar, 100).Value = BE.diarioname;
                    cmd.Parameters.Add("@tesoreria", SqlDbType.Bit).Value = BE.tesoreria;
                    cmd.Parameters.Add("@cuentaid", SqlDbType.Char, 10).Value = BE.cuentaid;
                    cmd.Parameters.Add("@cuentaname", SqlDbType.VarChar, 100).Value = BE.cuentaname;
                    cmd.Parameters.Add("@contabilidad", SqlDbType.Bit).Value = BE.contabilidad;
                    cmd.Parameters.Add("@registrocompra", SqlDbType.Bit).Value = BE.registrocompra;
                    cmd.Parameters.Add("@registroventa", SqlDbType.Bit).Value = BE.registroventa;
                    cmd.Parameters.Add("@almacen", SqlDbType.Bit).Value = BE.almacen;
                    cmd.Parameters.Add("@consolidardiario", SqlDbType.Bit).Value = BE.consolidardiario;
                    cmd.Parameters.Add("@canjeletra", SqlDbType.Bit).Value = BE.canjeletra;
                    cmd.Parameters.Add("@serie", SqlDbType.Bit).Value = BE.serie;
                    cmd.Parameters.Add("@generasientodestino", SqlDbType.Bit).Value = BE.generasientodestino;
                    cmd.Parameters.Add("@status", SqlDbType.Bit).Value = BE.status;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;

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

        public bool Update(string empresaid, tb_co_tipodiario BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTipodiario_UPDATE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@sigla", SqlDbType.Char, 3).Value = BE.sigla;
                        cmd.Parameters.Add("@diarioname", SqlDbType.VarChar, 100).Value = BE.diarioname;
                        cmd.Parameters.Add("@tesoreria", SqlDbType.Bit).Value = BE.tesoreria;
                        cmd.Parameters.Add("@cuentaid", SqlDbType.Char, 10).Value = BE.cuentaid;
                        cmd.Parameters.Add("@cuentaname", SqlDbType.VarChar, 100).Value = BE.cuentaname;
                        cmd.Parameters.Add("@contabilidad", SqlDbType.Bit).Value = BE.contabilidad;
                        cmd.Parameters.Add("@registrocompra", SqlDbType.Bit).Value = BE.registrocompra;
                        cmd.Parameters.Add("@registroventa", SqlDbType.Bit).Value = BE.registroventa;
                        cmd.Parameters.Add("@almacen", SqlDbType.Bit).Value = BE.almacen;
                        cmd.Parameters.Add("@consolidardiario", SqlDbType.Bit).Value = BE.consolidardiario;
                        cmd.Parameters.Add("@canjeletra", SqlDbType.Bit).Value = BE.canjeletra;
                        cmd.Parameters.Add("@serie", SqlDbType.Bit).Value = BE.serie;
                        cmd.Parameters.Add("@generasientodestino", SqlDbType.Bit).Value = BE.generasientodestino;
                        cmd.Parameters.Add("@status", SqlDbType.Bit).Value = BE.status;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
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

        public bool Delete(string empresaid, tb_co_tipodiario BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTipodiario_DELETE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
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

        public DataSet GetAll(string empresaid, tb_co_tipodiario BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTipodiario_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.AddWithValue("@diarioid", string.IsNullOrEmpty(BE.diarioid) ? (object)DBNull.Value : BE.diarioid);
                        //cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@sigla", SqlDbType.Char, 3).Value = BE.sigla;
                        cmd.Parameters.Add("@diarioname", SqlDbType.VarChar, 100).Value = BE.diarioname;
                        cmd.Parameters.Add("@tesoreria", SqlDbType.Bit).Value = BE.tesoreria;
                        cmd.Parameters.Add("@cuentaid", SqlDbType.Char, 10).Value = BE.cuentaid;
                        cmd.Parameters.Add("@cuentaname", SqlDbType.VarChar, 100).Value = BE.cuentaname;
                        cmd.Parameters.Add("@contabilidad", SqlDbType.Bit).Value = BE.contabilidad;
                        cmd.Parameters.Add("@registrocompra", SqlDbType.Bit).Value = BE.registrocompra;
                        cmd.Parameters.Add("@registroventa", SqlDbType.Bit).Value = BE.registroventa;
                        cmd.Parameters.Add("@almacen", SqlDbType.Bit).Value = BE.almacen;
                        cmd.Parameters.Add("@consolidardiario", SqlDbType.Bit).Value = BE.consolidardiario;
                        cmd.Parameters.Add("@canjeletra", SqlDbType.Bit).Value = BE.canjeletra;
                        cmd.Parameters.Add("@serie", SqlDbType.Bit).Value = BE.serie;
                        cmd.Parameters.Add("@generasientodestino", SqlDbType.Bit).Value = BE.generasientodestino;
                        cmd.Parameters.Add("@status", SqlDbType.Bit).Value = BE.status;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@norden", SqlDbType.Int).Value = BE.norden;
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
        public DataSet GetAll_IR(string empresaid, tb_co_tipodiario BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTipodiario_SEARCH_IR", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.AddWithValue("@diarioid", string.IsNullOrEmpty(BE.diarioid) ? (object)DBNull.Value : BE.diarioid);
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

        public DataSet GetOne(string empresaid, tb_co_tipodiario BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTipodiario_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public Boolean Generar(string empresaid, string perianio_ini, string perianio_fin)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTipodiario_GENERAR", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio_ini", SqlDbType.Char, 4).Value = perianio_ini;
                        cmd.Parameters.Add("@perianio_fin", SqlDbType.Char, 4).Value = perianio_fin;
                    }

                    try
                    {
                        cnx.Open();
                        cmd.ExecuteNonQuery();
                        cnx.Close();

                        return true;
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
