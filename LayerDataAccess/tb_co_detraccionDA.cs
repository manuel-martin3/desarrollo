using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_co_detraccionDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_co_detraccion BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoDetraccion_INSERT", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@detraccionid", SqlDbType.Char, 5).Value = BE.detraccionid;
                    cmd.Parameters.Add("@detraccionname", SqlDbType.VarChar, 100).Value = BE.detraccionname;
                    cmd.Parameters.Add("@detraccionporcent", SqlDbType.Decimal).Value = BE.detraccionporcent;
                    cmd.Parameters.Add("@fechini", SqlDbType.DateTime).Value = BE.fechini;
                    cmd.Parameters.Add("@fechfin", SqlDbType.DateTime).Value = BE.fechfin;
                    cmd.Parameters.Add("@status", SqlDbType.Bit).Value = BE.status;

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

        public bool Update(string empresaid, tb_co_detraccion BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoDetraccion_UPDATE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@detraccionid", SqlDbType.Char, 5).Value = BE.detraccionid;
                        cmd.Parameters.Add("@detraccionname", SqlDbType.VarChar, 100).Value = BE.detraccionname;
                        cmd.Parameters.Add("@detraccionporcent", SqlDbType.Decimal).Value = BE.detraccionporcent;
                        cmd.Parameters.Add("@fechini", SqlDbType.DateTime).Value = BE.fechini;
                        cmd.Parameters.Add("@fechfin", SqlDbType.DateTime).Value = BE.fechfin;
                        cmd.Parameters.Add("@status", SqlDbType.Bit).Value = BE.status;
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

        public bool Delete(string empresaid, tb_co_detraccion BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoDetraccion_DELETE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@detraccionid", SqlDbType.Char, 5).Value = BE.detraccionid;
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

        public DataSet GetAll(string empresaid, tb_co_detraccion BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoDetraccion_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@detraccionid", SqlDbType.Char, 5).Value = BE.detraccionid;
                        cmd.Parameters.Add("@detraccionname", SqlDbType.VarChar, 100).Value = BE.detraccionname;
                        cmd.Parameters.Add("@detraccionporcent", SqlDbType.Decimal).Value = BE.detraccionporcent;
                        cmd.Parameters.Add("@fechini", SqlDbType.DateTime).Value = BE.fechini;
                        cmd.Parameters.Add("@fechfin", SqlDbType.DateTime).Value = BE.fechfin;
                        cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = BE.tipo;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
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

        public DataSet GetOne(string empresaid, string detraccionid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoDetraccion_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@detraccionid", SqlDbType.Char, 5).Value = detraccionid;
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
