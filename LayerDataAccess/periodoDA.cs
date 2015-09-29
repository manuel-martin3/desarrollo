using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;


namespace LayerDataAccess
{
    public class empresaperiodoDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(tb_empresaperiodo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.AdmConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbempresaperiodo_INSERT", cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = BE.empresaid;
                    cmd.Parameters.Add("@periodo", SqlDbType.Char, 4).Value = BE.periodo;
                    cmd.Parameters.Add("@actual", SqlDbType.Bit).Value = BE.actual;
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

        public bool Update(tb_empresaperiodo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.AdmConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbempresaperiodo_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = BE.empresaid;
                        cmd.Parameters.Add("@periodo", SqlDbType.Char, 4).Value = BE.periodo;
                        cmd.Parameters.Add("@actual", SqlDbType.Bit).Value = BE.actual;
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

        public bool Delete(tb_empresaperiodo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.AdmConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbempresaperiodo_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = BE.empresaid;
                        cmd.Parameters.Add("@periodo", SqlDbType.Char, 4).Value = BE.periodo;
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

        public DataSet GetAll(tb_empresaperiodo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.AdmConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbempresaperiodo_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = BE.empresaid;
                        cmd.Parameters.Add("@periodo", SqlDbType.Char, 4).Value = BE.periodo;
                        cmd.Parameters.Add("@actual", SqlDbType.Bit).Value = BE.actual;
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

        public DataSet GetOne(string empresaid, string periodo)
        {
            using (SqlConnection cnx = new SqlConnection(conex.AdmConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbempresaperiodo_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = empresaid;
                        cmd.Parameters.Add("@periodo", SqlDbType.Char, 4).Value = periodo;
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
