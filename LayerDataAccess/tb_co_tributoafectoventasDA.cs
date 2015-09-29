using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_co_tributoafectoventasDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_co_tributoafectoventas BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTributoafectoventas_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@destinoid", SqlDbType.Char, 1).Value = BE.destinoid;
                    cmd.Parameters.Add("@destinoname", SqlDbType.VarChar, 100).Value = BE.destinoname;
                    cmd.Parameters.Add("@destinoafecto", SqlDbType.Bit).Value = BE.destinoafecto;
                    cmd.Parameters.Add("@destinoafecto1", SqlDbType.Bit).Value = BE.destinoafecto1;
                    cmd.Parameters.Add("@destinodaot", SqlDbType.Bit).Value = BE.destinodaot;
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

        public bool Update(string empresaid, tb_co_tributoafectoventas BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTributoafectoventas_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@destinoid", SqlDbType.Char, 1).Value = BE.destinoid;
                        cmd.Parameters.Add("@destinoname", SqlDbType.VarChar, 100).Value = BE.destinoname;
                        cmd.Parameters.Add("@destinoafecto", SqlDbType.Bit).Value = BE.destinoafecto;
                        cmd.Parameters.Add("@destinoafecto1", SqlDbType.Bit).Value = BE.destinoafecto1;
                        cmd.Parameters.Add("@destinodaot", SqlDbType.Bit).Value = BE.destinodaot;
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

        public bool Delete(string empresaid, tb_co_tributoafectoventas BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTributoafectoventas_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@destinoid", SqlDbType.Char, 1).Value = BE.destinoid;
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

        public DataSet GetAll(string empresaid, tb_co_tributoafectoventas BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTributoafectoventas_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@destinoid", SqlDbType.Char, 1).Value = BE.destinoid;
                        cmd.Parameters.Add("@destinoname", SqlDbType.VarChar, 100).Value = BE.destinoname;
                        cmd.Parameters.Add("@destinoafecto", SqlDbType.Bit).Value = BE.destinoafecto;
                        cmd.Parameters.Add("@destinoafecto1", SqlDbType.Bit).Value = BE.destinoafecto1;
                        cmd.Parameters.Add("@destinodaot", SqlDbType.Bit).Value = BE.destinodaot;
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

        public DataSet GetOne(string empresaid, string destinoid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTributoafectoventas_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@destinoid", SqlDbType.Char, 1).Value = destinoid;
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
