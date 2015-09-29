using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;


namespace LayerDataAccess
{
    public class cliente_bancoDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert_XML(string empresaid, tb_cliente_banco BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbClienteBanco_INSERT_xml", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
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

        public bool Insert(string empresaid, tb_cliente_banco BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid))){
                using (SqlCommand cmd = new SqlCommand("gspTbClienteBanco_INSERT", cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@bancoid", SqlDbType.Char, 2).Value = BE.bancoid;
                    cmd.Parameters.Add("@ctactemn", SqlDbType.VarChar, 20).Value = BE.ctactemn;
                    cmd.Parameters.Add("@ctacteme", SqlDbType.VarChar, 20).Value = BE.ctacteme;
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

        public bool Update(string empresaid, tb_cliente_banco BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid))){
                using (SqlCommand cmd = new SqlCommand("gspTbClienteBanco_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@bancoid", SqlDbType.Char, 2).Value = BE.bancoid;
                        cmd.Parameters.Add("@ctactemn", SqlDbType.VarChar, 20).Value = BE.ctactemn;
                        cmd.Parameters.Add("@ctacteme", SqlDbType.VarChar, 20).Value = BE.ctacteme;
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

        public bool Delete(string empresaid, tb_cliente_banco BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid))){
                using (SqlCommand cmd = new SqlCommand("gspTbClienteBanco_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@bancoid", SqlDbType.Char, 2).Value = BE.bancoid;
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

        public DataSet GetAll(string empresaid, tb_cliente_banco BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid))){
                using (SqlCommand cmd = new SqlCommand("gspTbClienteBanco_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@bancoid", SqlDbType.Char, 2).Value = BE.bancoid;
                        cmd.Parameters.Add("@ctactemn", SqlDbType.VarChar, 20).Value = BE.ctactemn;
                        cmd.Parameters.Add("@ctacteme", SqlDbType.VarChar, 20).Value = BE.ctacteme;
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

        public DataSet GetOne(string empresaid, string ctacte, string bancoid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid))){
                using (SqlCommand cmd = new SqlCommand("gspTbClienteBanco_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = ctacte;
                        cmd.Parameters.Add("@bancoid", SqlDbType.Char, 2).Value = bancoid;
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
