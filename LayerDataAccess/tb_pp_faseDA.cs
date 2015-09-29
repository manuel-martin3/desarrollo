using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_pp_faseDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_pp_fase BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPpFase_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@faseid", SqlDbType.Int).Value = BE.faseid;
                    cmd.Parameters.Add("@fasename", SqlDbType.VarChar, 30).Value = BE.fasename;
                    cmd.Parameters.Add("@fasedescort", SqlDbType.Char, 5).Value = BE.fasedescort;
                    cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
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

        public bool Update(string empresaid, tb_pp_fase BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPpFase_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@faseid", SqlDbType.Int).Value = BE.faseid;
                        cmd.Parameters.Add("@fasename", SqlDbType.VarChar, 30).Value = BE.fasename;
                        cmd.Parameters.Add("@fasedescort", SqlDbType.Char, 5).Value = BE.fasedescort;
                        cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;   
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
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

        public bool Delete(string empresaid, tb_pp_fase BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPpFase_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@faseid", SqlDbType.Int).Value = BE.faseid;     
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

        public DataSet GetAll(string empresaid, tb_pp_fase BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPpFase_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@faseid", SqlDbType.Int).Value = BE.faseid;
                        cmd.Parameters.Add("@fasename", SqlDbType.VarChar, 30).Value = BE.fasename;
                        cmd.Parameters.Add("@fasedescort", SqlDbType.Char, 5).Value = BE.fasedescort;
                        cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        //cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;            
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

        public DataSet GetOne(string empresaid, string articid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = articid;
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
