using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_comprador_corporativoDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_comprador_corporativo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCompradorCorporativo_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@compradorid", SqlDbType.Char, 4).Value = BE.compradorid;
                    cmd.Parameters.Add("@compradorname", SqlDbType.VarChar, 50).Value = BE.compradorname;
                    cmd.Parameters.Add("@docuidentid", SqlDbType.Char, 1).Value = BE.docuidentid;
                    cmd.Parameters.Add("@compradordni", SqlDbType.Char, 10).Value = BE.compradordni;
                    cmd.Parameters.Add("@compradordire", SqlDbType.Char, 100).Value = BE.compradordire;
                    cmd.Parameters.Add("@compradorfeing", SqlDbType.DateTime).Value = BE.compradorfeing;
                    cmd.Parameters.Add("@compradortelef", SqlDbType.VarChar, 15).Value = BE.compradortelef;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
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

        public bool Update(string empresaid, tb_comprador_corporativo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCompradorCorporativo_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@compradorid", SqlDbType.Char, 4).Value = BE.compradorid;
                        cmd.Parameters.Add("@compradorname", SqlDbType.VarChar, 50).Value = BE.compradorname;
                        cmd.Parameters.Add("@docuidentid", SqlDbType.Char, 1).Value = BE.docuidentid;
                        cmd.Parameters.Add("@compradordni", SqlDbType.Char, 10).Value = BE.compradordni;
                        cmd.Parameters.Add("@compradordire", SqlDbType.Char, 100).Value = BE.compradordire;
                        cmd.Parameters.Add("@compradorfeing", SqlDbType.DateTime).Value = BE.compradorfeing;
                        cmd.Parameters.Add("@compradortelef", SqlDbType.VarChar, 15).Value = BE.compradortelef;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
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

        public bool Delete(string empresaid, tb_comprador_corporativo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCompradorCorporativo_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@compradorid", SqlDbType.Char, 4).Value = BE.compradorid;
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

        public DataSet GetAll(string empresaid, tb_comprador_corporativo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCompradorCorporativo_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@compradorid", SqlDbType.Char, 4).Value = BE.compradorid;
                        cmd.Parameters.Add("@compradorname", SqlDbType.VarChar, 50).Value = BE.compradorname;
                        cmd.Parameters.Add("@docuidentid", SqlDbType.Char, 1).Value = BE.docuidentid;
                        cmd.Parameters.Add("@compradordni", SqlDbType.Char, 10).Value = BE.compradordni;
                        cmd.Parameters.Add("@compradordire", SqlDbType.Char, 100).Value = BE.compradordire;
                        cmd.Parameters.Add("@compradortelef", SqlDbType.VarChar, 15).Value = BE.compradortelef;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 15).Value = BE.status;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
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

        public DataSet GetOne(string empresaid, string compradorid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCompradorCorporativo_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@compradorid", SqlDbType.Char, 4).Value = compradorid;
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
