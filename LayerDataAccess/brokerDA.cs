using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class brokerDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_broker BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbBroker_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@brokerid", SqlDbType.Char, 4).Value = BE.brokerid;
                    cmd.Parameters.Add("@brokername", SqlDbType.VarChar, 100).Value = BE.brokername;
                    cmd.Parameters.Add("@docuidentid", SqlDbType.Char, 1).Value = BE.docuidentid;
                    cmd.Parameters.Add("@brokerdni", SqlDbType.Char, 11).Value = BE.brokerdni;
                    cmd.Parameters.Add("@brokerdire", SqlDbType.VarChar, 100).Value = BE.brokerdire;
                    cmd.Parameters.Add("@brokerfeing", SqlDbType.DateTime).Value = BE.brokerfeing;
                    cmd.Parameters.Add("@brokertelef", SqlDbType.VarChar, 15).Value = BE.brokertelef;
                    cmd.Parameters.Add("@brokerweb", SqlDbType.VarChar, 50).Value = BE.brokerweb;
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

        public bool Update(string empresaid, tb_broker BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbBroker_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@brokerid", SqlDbType.Char, 4).Value = BE.brokerid;
                        cmd.Parameters.Add("@brokername", SqlDbType.VarChar, 100).Value = BE.brokername;
                        cmd.Parameters.Add("@docuidentid", SqlDbType.Char, 1).Value = BE.docuidentid;
                        cmd.Parameters.Add("@brokerdni", SqlDbType.Char, 11).Value = BE.brokerdni;
                        cmd.Parameters.Add("@brokerdire", SqlDbType.VarChar, 100).Value = BE.brokerdire;
                        cmd.Parameters.Add("@brokerfeing", SqlDbType.DateTime).Value = BE.brokerfeing;
                        cmd.Parameters.Add("@brokertelef", SqlDbType.VarChar, 15).Value = BE.brokertelef;
                        cmd.Parameters.Add("@brokerweb", SqlDbType.VarChar, 50).Value = BE.brokerweb;
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

        public bool Delete(string empresaid, tb_broker BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbBroker_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@brokerid", SqlDbType.Char, 4).Value = BE.brokerid;
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

        public DataSet GetAll(string empresaid, tb_broker BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbBroker_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@brokerid", SqlDbType.Char, 4).Value = BE.brokerid;
                        cmd.Parameters.Add("@brokername", SqlDbType.VarChar, 100).Value = BE.brokername;
                        cmd.Parameters.Add("@docuidentid", SqlDbType.Char, 1).Value = BE.docuidentid;
                        cmd.Parameters.Add("@brokerdni", SqlDbType.Char, 11).Value = BE.brokerdni;
                        cmd.Parameters.Add("@brokerdire", SqlDbType.VarChar, 100).Value = BE.brokerdire;
                        cmd.Parameters.Add("@brokertelef", SqlDbType.VarChar, 15).Value = BE.brokertelef;
                        cmd.Parameters.Add("@brokerweb", SqlDbType.VarChar, 50).Value = BE.brokerweb;
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

        public DataSet GetOne(string empresaid, string brokerid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbBroker_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@brokerid", SqlDbType.Char, 4).Value = brokerid;
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
