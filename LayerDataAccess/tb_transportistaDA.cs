using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_transportistaDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_transportista BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTransportista_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@transpid", SqlDbType.Char, 5).Value = BE.transpid;
                    cmd.Parameters.Add("@transpname", SqlDbType.VarChar, 40).Value = BE.transpname;
                    cmd.Parameters.Add("@transpplaca", SqlDbType.VarChar, 20).Value = BE.transpplaca;
                    cmd.Parameters.Add("@transpcertificado", SqlDbType.VarChar, 20).Value = BE.transpcertificado;
                    cmd.Parameters.Add("@transplicencia", SqlDbType.VarChar, 20).Value = BE.transplicencia;
                    cmd.Parameters.Add("@transpnmruc", SqlDbType.Char, 11).Value = BE.transpnmruc;
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

        public bool Update(string empresaid, tb_transportista BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTransportista_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@transpid", SqlDbType.Char, 5).Value = BE.transpid;
                        cmd.Parameters.Add("@transpname", SqlDbType.VarChar, 40).Value = BE.transpname;
                        cmd.Parameters.Add("@transpplaca", SqlDbType.VarChar, 20).Value = BE.transpplaca;
                        cmd.Parameters.Add("@transpcertificado", SqlDbType.VarChar, 20).Value = BE.transpcertificado;
                        cmd.Parameters.Add("@transplicencia", SqlDbType.VarChar, 20).Value = BE.transplicencia;
                        cmd.Parameters.Add("@transpnmruc", SqlDbType.Char, 11).Value = BE.transpnmruc;
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

        public bool Delete(string empresaid, tb_transportista BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTransportista_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@transpid", SqlDbType.Char, 5).Value = BE.transpid;
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

        public DataSet GetAll(string empresaid, tb_transportista BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTransportista_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@transpid", SqlDbType.Char, 5).Value = BE.transpid;
                        cmd.Parameters.Add("@transpname", SqlDbType.VarChar, 40).Value = BE.transpname;
                        cmd.Parameters.Add("@transpplaca", SqlDbType.VarChar, 20).Value = BE.transpplaca;
                        cmd.Parameters.Add("@transpcertificado", SqlDbType.VarChar, 20).Value = BE.transpcertificado;
                        cmd.Parameters.Add("@transplicencia", SqlDbType.VarChar, 20).Value = BE.transplicencia;
                        cmd.Parameters.Add("@transpnmruc", SqlDbType.Char, 11).Value = BE.transpnmruc;
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

        public DataSet GetOne(string empresaid, string transpid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTransportista_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@transpid", SqlDbType.Char, 5).Value = transpid;
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
