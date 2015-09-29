using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_plla_pdt_tabla02DA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_plla_pdt_tabla02 BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPdtTabla02_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tipestabid", SqlDbType.Char, 2).Value = BE.tipestabid;
                    cmd.Parameters.Add("@tipestabname", SqlDbType.VarChar, 35).Value = BE.tipestabname;
                     
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

        public bool Update(string empresaid, tb_plla_pdt_tabla02 BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPdtTabla02_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipestabid", SqlDbType.Char, 2).Value = BE.tipestabid;
                        cmd.Parameters.Add("@tipestabname", SqlDbType.VarChar, 35).Value = BE.tipestabname;
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

        public bool Delete(string empresaid, tb_plla_pdt_tabla02 BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPdtTabla02_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipestabid", SqlDbType.Char, 2).Value = BE.tipestabid;
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

        public DataSet GetAll(string empresaid, tb_plla_pdt_tabla02 BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPdtTabla02_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipestabid", SqlDbType.Char, 2).Value = BE.tipestabid;
                        cmd.Parameters.Add("@tipestabname", SqlDbType.VarChar, 35).Value = BE.tipestabname;
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

        public DataSet GetAll_Consulta(string empresaid, tb_plla_pdt_tabla02 BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPdtTabla02_CONSULTA", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipestabid", SqlDbType.Char, 2).Value = BE.tipestabid;
                        cmd.Parameters.Add("@tipestabname", SqlDbType.VarChar, 35).Value = BE.tipestabname;
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

        public DataSet GetOne(string empresaid, string tipestabid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPdtTabla02_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipestabid", SqlDbType.Char, 2).Value = tipestabid;
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
