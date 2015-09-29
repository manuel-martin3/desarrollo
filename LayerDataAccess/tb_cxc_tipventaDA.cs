using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;


namespace LayerDataAccess
{
    public class tb_cxc_tipventaDA
    {
        ConexionWeb conex = new ConexionWeb();

        public bool Insert(string empresaid, tb_cxc_tipventa BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("", cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tipventaid", SqlDbType.Char, 2).Value = BE.tipventaid;
                    cmd.Parameters.Add("@tipventaname", SqlDbType.VarChar, 20).Value = BE.tipventaname;                    

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

        public bool Update(string empresaid, tb_cxc_tipventa BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipventaid", SqlDbType.Char, 2).Value = BE.tipventaid;
                        cmd.Parameters.Add("@tipventaname", SqlDbType.VarChar, 20).Value = BE.tipventaname;                    
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
                    finally
                    {
                        cnx.Close();
                    }
                }
            }
        }

        public bool Delete(string empresaid, tb_cxc_tipventa BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipventaid", SqlDbType.Char, 2).Value = BE.tipventaid;
                        cmd.Parameters.Add("@tipventaname", SqlDbType.VarChar, 20).Value = BE.tipventaname;                    
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

        public DataSet GetAll(string empresaid, tb_cxc_tipventa BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCxcTipVenta_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipventaid", SqlDbType.Char, 2).Value = BE.tipventaid;
                        cmd.Parameters.Add("@tipventaname", SqlDbType.VarChar, 20).Value = BE.tipventaname;                    
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

        public DataSet GetAll_paginacion(string empresaid, tb_cxc_tipventa BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipventaid", SqlDbType.Char, 2).Value = BE.tipventaid;
                        cmd.Parameters.Add("@tipventaname", SqlDbType.VarChar, 20).Value = BE.tipventaname;                    
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

        public DataSet GetReport(string empresaid, tb_cxc_tipventa BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipventaid", SqlDbType.Char, 2).Value = BE.tipventaid;
                        cmd.Parameters.Add("@tipventaname", SqlDbType.VarChar, 20).Value = BE.tipventaname;                    
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

        public DataSet GetOne(string empresaid, tb_cxc_tipventa BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipventaid", SqlDbType.Char, 2).Value = BE.tipventaid;
                        cmd.Parameters.Add("@tipventaname", SqlDbType.VarChar, 20).Value = BE.tipventaname;                    

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
}
