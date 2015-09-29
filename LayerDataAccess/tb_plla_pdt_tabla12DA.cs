using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_plla_pdt_tabla12DA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_plla_pdt_tabla12 BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPdtTabla12_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tipcontratoid", SqlDbType.Char, 2).Value = BE.tipcontratoid;
                    cmd.Parameters.Add("@tipcontratoname", SqlDbType.VarChar, 50).Value = BE.tipcontratoname;
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

        public bool Update(string empresaid, tb_plla_pdt_tabla12 BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPdtTabla12_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipcontratoid", SqlDbType.Char, 2).Value = BE.tipcontratoid;
                        cmd.Parameters.Add("@tipcontratoname", SqlDbType.VarChar, 50).Value = BE.tipcontratoname;
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

        public bool Delete(string empresaid, tb_plla_pdt_tabla12 BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPdtTabla12_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipcontratoid", SqlDbType.Char, 2).Value = BE.tipcontratoid;
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

        public DataSet GetAll(string empresaid, tb_plla_pdt_tabla12 BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPdtTabla12_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipcontratoid", SqlDbType.Char, 2).Value = BE.tipcontratoid;
                        cmd.Parameters.Add("@tipcontratoname", SqlDbType.VarChar, 50).Value = BE.tipcontratoname;
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

        public DataSet GetAll_Consulta(string empresaid, tb_plla_pdt_tabla12 BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPdtTabla12_CONSULTA", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@tipcontratoid", string.IsNullOrEmpty(BE.tipcontratoid) ? (object)DBNull.Value : BE.tipcontratoid);
                        cmd.Parameters.AddWithValue("@relcodigotipo", string.IsNullOrEmpty(BE.relcodigotipo) ? (object)DBNull.Value : BE.relcodigotipo);
                        cmd.Parameters.AddWithValue("@descriplike1", string.IsNullOrEmpty(BE.descriplike1) ? (object)DBNull.Value : BE.descriplike1);
                        cmd.Parameters.AddWithValue("@descriplike2", string.IsNullOrEmpty(BE.descriplike2) ? (object)DBNull.Value : BE.descriplike2);
                        cmd.Parameters.AddWithValue("@descriplike3", string.IsNullOrEmpty(BE.descriplike3) ? (object)DBNull.Value : BE.descriplike3);
                        cmd.Parameters.Add("@norden", SqlDbType.Int).Value = BE.norden;
                        cmd.Parameters.Add("@incluir_blanco", SqlDbType.Int).Value = BE.incluir_blanco;
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

        public DataSet GetOne(string empresaid, string tipcontratoid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPdtTabla12_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipcontratoid", SqlDbType.Char, 2).Value = tipcontratoid;
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
