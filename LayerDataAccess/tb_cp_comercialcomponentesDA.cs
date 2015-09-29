using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_cp_comercialcomponentesDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_cp_comercialcomponentes BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCpComercialcomponentes_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@empresa", SqlDbType.Char, 2).Value = BE.empresa;
                    cmd.Parameters.Add("@asiento", SqlDbType.Char, 10).Value = BE.asiento;
                    cmd.Parameters.Add("@items", SqlDbType.Char, 2).Value = BE.items;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@estiloid", SqlDbType.Char, 2).Value = BE.estiloid;
                    cmd.Parameters.Add("@componenteid", SqlDbType.Char, 6).Value = BE.componenteid;
                    cmd.Parameters.Add("@detallecomponente", SqlDbType.VarChar, 50).Value = BE.detallecomponente;
                    cmd.Parameters.Add("@orden", SqlDbType.Int).Value = BE.orden;
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

        public bool Update(string empresaid, tb_cp_comercialcomponentes BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCpComercialcomponentes_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@empresa", SqlDbType.Char, 2).Value = BE.empresa;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 10).Value = BE.asiento;
                        cmd.Parameters.Add("@items", SqlDbType.Char, 2).Value = BE.items;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@estiloid", SqlDbType.Char, 2).Value = BE.estiloid;
                        cmd.Parameters.Add("@componenteid", SqlDbType.Char, 6).Value = BE.componenteid;
                        cmd.Parameters.Add("@detallecomponente", SqlDbType.VarChar, 50).Value = BE.detallecomponente;
                        cmd.Parameters.Add("@orden", SqlDbType.Int).Value = BE.orden;
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

        public bool Delete(string empresaid, tb_cp_comercialcomponentes BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCpComercialcomponentes_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@empresa", SqlDbType.Char, 2).Value = BE.empresa;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 10).Value = BE.asiento;
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

        public DataSet GetAll(string empresaid, tb_cp_comercialcomponentes BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCpComercialcomponentes_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@empresa", SqlDbType.Char, 2).Value = BE.empresa;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 10).Value = BE.asiento;
                        cmd.Parameters.Add("@items", SqlDbType.Char, 2).Value = BE.items;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@estiloid", SqlDbType.Char, 2).Value = BE.estiloid;
                        cmd.Parameters.Add("@componenteid", SqlDbType.Char, 6).Value = BE.componenteid;
                        cmd.Parameters.Add("@detallecomponente", SqlDbType.VarChar, 50).Value = BE.detallecomponente;
                        cmd.Parameters.Add("@orden", SqlDbType.Int).Value = BE.orden;
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

        public DataSet GetOne(string empresaid, tb_cp_comercialcomponentes BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCpComercialcomponentes_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@empresa", SqlDbType.Char, 2).Value = BE.empresa;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 10).Value = BE.asiento;
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
