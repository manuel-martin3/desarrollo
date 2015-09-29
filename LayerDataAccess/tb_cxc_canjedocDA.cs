using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;


namespace LayerDataAccess
{
    public class tb_cxc_canjedocDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_cxc_canjedoc BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb_cxc_canjedoccab_INSERT_UPDATE", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tipcanje", SqlDbType.Char, 2).Value = BE.tipcanje;
                    cmd.Parameters.Add("@sercanje", SqlDbType.Char, 4).Value = BE.sercanje;
                    cmd.Parameters.Add("@numcanje", SqlDbType.Char, 10).Value = BE.numcanje;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@fechcanje", SqlDbType.DateTime).Value = BE.fechcanje;
                    cmd.Parameters.Add("@impocanje", SqlDbType.Decimal).Value = BE.impocanje;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    cmd.Parameters.Add("@Idx", SqlDbType.Char, 3).Value = BE.Idx;
                    cmd.Parameters.Add("@XML", SqlDbType.Xml).Value = BE.GetItemXML();  

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

        public bool Update(string empresaid, tb_cxc_canjedoc BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb_cxc_canjedoccab_INSERT_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipcanje", SqlDbType.Char, 2).Value = BE.tipcanje;
                        cmd.Parameters.Add("@sercanje", SqlDbType.Char, 4).Value = BE.sercanje;
                        cmd.Parameters.Add("@numcanje", SqlDbType.Char, 10).Value = BE.numcanje;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@fechcanje", SqlDbType.DateTime).Value = BE.fechcanje;
                        cmd.Parameters.Add("@impocanje", SqlDbType.Decimal).Value = BE.impocanje;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                        cmd.Parameters.Add("@Idx", SqlDbType.Char, 3).Value = BE.Idx;
                        cmd.Parameters.Add("@XML", SqlDbType.Xml).Value = BE.GetItemXML();  
                   
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

        public bool Delete(string empresaid, tb_cxc_canjedoc BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb_cxc_canjedoccab_INSERT_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipcanje", SqlDbType.Char, 2).Value = BE.tipcanje;
                        cmd.Parameters.Add("@sercanje", SqlDbType.Char, 4).Value = BE.sercanje;
                        cmd.Parameters.Add("@numcanje", SqlDbType.Char, 10).Value = BE.numcanje;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@fechcanje", SqlDbType.DateTime).Value = BE.fechcanje;
                        cmd.Parameters.Add("@impocanje", SqlDbType.Decimal).Value = BE.impocanje;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                        cmd.Parameters.Add("@Idx", SqlDbType.Char, 3).Value = BE.Idx;
                        cmd.Parameters.Add("@XML", SqlDbType.Xml).Value = BE.GetItemXML();  
                                           
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

        public DataSet GetAll(string empresaid, tb_cxc_canjedoc BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@tipventaid", SqlDbType.Char, 2).Value = BE.tipventaid;
                        //cmd.Parameters.Add("@tipventaname", SqlDbType.VarChar, 20).Value = BE.tipventaname;                    
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
