using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_cp_canalventaDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_cp_canalventa BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCpCanalventa_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@canalventaid", SqlDbType.Char, 3).Value = BE.canalventaid;
                    cmd.Parameters.Add("@canalventaname", SqlDbType.VarChar, 50).Value = BE.canalventaname;
                    cmd.Parameters.Add("@digitos", SqlDbType.Int).Value = BE.digitos;
                    cmd.Parameters.Add("@chk_apt", SqlDbType.Bit).Value = BE.chk_apt;
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

        public bool Update(string empresaid, tb_cp_canalventa BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCpCanalventa_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@canalventaid", SqlDbType.Char, 3).Value = BE.canalventaid;
                        cmd.Parameters.Add("@canalventaname", SqlDbType.VarChar, 50).Value = BE.canalventaname;
                        cmd.Parameters.Add("@digitos", SqlDbType.Int).Value = BE.digitos;
                        cmd.Parameters.Add("@chk_apt", SqlDbType.Bit).Value = BE.chk_apt;
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

        public bool Delete(string empresaid, tb_cp_canalventa BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCpCanalventa_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@canalventaid", SqlDbType.Char, 3).Value = BE.canalventaid;
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

        public DataSet GetAll(string empresaid, tb_cp_canalventa BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCpCanalventa_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@canalventaid", SqlDbType.Char, 3).Value = BE.canalventaid;
                        cmd.Parameters.Add("@canalventaname", SqlDbType.VarChar, 50).Value = BE.canalventaname;
                        cmd.Parameters.Add("@digitos", SqlDbType.Int).Value = BE.digitos;
                        //cmd.Parameters.Add("@parameters", SqlDbType.VarChar).Value = BE.parameters;
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

        public DataSet GetAll2(string empresaid, tb_cp_canalventa BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCpCanalventa_SEARCH2", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@canalventaid", SqlDbType.Char, 3).Value = BE.canalventaid;
                        //cmd.Parameters.Add("@canalventaname", SqlDbType.VarChar, 50).Value = BE.canalventaname;
                        //cmd.Parameters.Add("@digitos", SqlDbType.Int).Value = BE.digitos;
                        cmd.Parameters.Add("@parameters", SqlDbType.VarChar).Value = BE.parameters;
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

        public DataSet GetOne(string empresaid, tb_cp_canalventa BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCpCanalventa_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@canalventaid", SqlDbType.Char, 3).Value = BE.canalventaid;
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
