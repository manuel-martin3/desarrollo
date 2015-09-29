using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_co_tipoventasDA
    {
        ConexionDA conex = new ConexionDA();
        public String Sql_Error = "";

        public bool Insert(string empresaid, tb_co_tipoventas BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTipoventas_INSERT", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tipoid", SqlDbType.Char, 2).Value = BE.tipoid;
                    cmd.Parameters.Add("@tiponame", SqlDbType.VarChar, 100).Value = BE.tiponame;
                    cmd.Parameters.Add("@cuenta1id", SqlDbType.Char, 10).Value = BE.cuenta1id;
                    cmd.Parameters.Add("@cuenta1name", SqlDbType.VarChar, 100).Value = BE.cuenta1name;
                    cmd.Parameters.Add("@cuenta2id", SqlDbType.Char, 10).Value = BE.cuenta2id;
                    cmd.Parameters.Add("@cuenta2name", SqlDbType.VarChar, 100).Value = BE.cuenta2name;
                    cmd.Parameters.Add("@moneda", SqlDbType.VarChar, 1).Value = BE.moneda;

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

        public bool Update(string empresaid, tb_co_tipoventas BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTipoventas_UPDATE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipoid", SqlDbType.Char, 2).Value = BE.tipoid;
                        cmd.Parameters.Add("@tiponame", SqlDbType.VarChar, 100).Value = BE.tiponame;
                        cmd.Parameters.Add("@cuenta1id", SqlDbType.Char, 10).Value = BE.cuenta1id;
                        cmd.Parameters.Add("@cuenta1name", SqlDbType.VarChar, 100).Value = BE.cuenta1name;
                        cmd.Parameters.Add("@cuenta2id", SqlDbType.Char, 10).Value = BE.cuenta2id;
                        cmd.Parameters.Add("@cuenta2name", SqlDbType.VarChar, 100).Value = BE.cuenta2name;
                        cmd.Parameters.Add("@moneda", SqlDbType.VarChar, 1).Value = BE.moneda;
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

        public bool Delete(string empresaid, tb_co_tipoventas BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTipoventas_DELETE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipoid", SqlDbType.Char, 3).Value = BE.tipoid;
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

        public DataSet GetAll(string empresaid, tb_co_tipoventas BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTipoventas_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipoid", SqlDbType.Char, 2).Value = BE.tipoid;
                        cmd.Parameters.Add("@tiponame", SqlDbType.VarChar, 100).Value = BE.tiponame;
                        cmd.Parameters.Add("@cuenta1id", SqlDbType.Char, 10).Value = BE.cuenta1id;
                        cmd.Parameters.Add("@cuenta1name", SqlDbType.VarChar, 100).Value = BE.cuenta1name;
                        cmd.Parameters.Add("@cuenta2id", SqlDbType.Char, 10).Value = BE.cuenta2id;
                        cmd.Parameters.Add("@cuenta2name", SqlDbType.VarChar, 100).Value = BE.cuenta2name;
                        cmd.Parameters.Add("@moneda", SqlDbType.VarChar, 1).Value = BE.moneda;
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

        public DataSet GetAll_IR(string empresaid, tb_co_tipoventas BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTipoventas_SEARCH_IR", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@tipoid", SqlDbType.Char, 2).Value = BE.tipoid;
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

        public String GetNextCod(string empresaid, tb_co_tipoventas BE)
        {
            String newcod = "";

            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTipoventas_SEARCH_nextcod", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        cnx.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            newcod = Convert.ToString(reader["nextcod"]);
                        }
                        return newcod;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public DataSet GetOne(string empresaid, string tipoid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTipoventas_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipoid", SqlDbType.Char, 3).Value = tipoid;
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
