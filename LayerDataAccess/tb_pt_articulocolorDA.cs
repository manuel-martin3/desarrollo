using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;
using System.Data.OleDb;

namespace LayerDataAccess
{
    public class tb_pt_articulocolorDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_pt_articulocolor BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtArticulocolor_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
                    cmd.Parameters.Add("@colorid", SqlDbType.Char, 3).Value = BE.colorid;
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

        public bool Insert_dbf(string empresaid, tb_pt_articulocolor BE)
        {
            Conex_FoxDA cone = new Conex_FoxDA();
            using (OleDbConnection cnx = new OleDbConnection(cone.AdmConexion()))
            {
                String commandString =
                "INSERT INTO ptema712 (pt712stat ,pt712idar ,pt712idco ,pt712usid ,pt712feac ,ensql ,status) " +
                "VALUES (?, ?, ?, ?, ?, ?, ?) ";

                OleDbCommand cmd = new OleDbCommand(commandString, cnx);
                cmd.Parameters.Add("@pt712stat ", OleDbType.Decimal).Value = 1;
                cmd.Parameters.Add("@pt712idar ", OleDbType.Char, 7).Value = BE.articid.ToString();
                cmd.Parameters.Add("@pt712idco ", OleDbType.Char, 3).Value = BE.colorid.ToString();
                cmd.Parameters.Add("@pt712usid ", OleDbType.Char, 3).Value = BE.usuar.ToString();
                cmd.Parameters.Add("@pt712feac ", OleDbType.Date).Value = DateTime.Today.ToShortDateString();
                cmd.Parameters.Add("@ENSQL ", OleDbType.Boolean).Value = 1;
                cmd.Parameters.Add("@status ", OleDbType.Char, 1).Value = BE.status.ToString();

                cnx.Open();
                try
                {
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
                
        public bool Update(string empresaid, tb_pt_articulocolor BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtArticulocolor_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
                        cmd.Parameters.Add("@colorid", SqlDbType.Char, 3).Value = BE.colorid;
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

        public bool Update_dbf(string empresaid, tb_pt_articulocolor BE)
        {
            Conex_FoxDA cone = new Conex_FoxDA();
            using (OleDbConnection cnx = new OleDbConnection(cone.AdmConexion()))
            {
                String commandString =
                "UPDATE ptema712  SET  pt712idco = ? ,pt712usid = ? ,pt712feac = ? ,ENSQL = ? ,status = ? " +
                " WHERE pt712idar  = ? ";

                OleDbCommand cmd = new OleDbCommand(commandString, cnx);
                //cmd.Parameters.Add("@pt712stat ", OleDbType.Decimal).Value = 1;
                cmd.Parameters.Add("@pt712idar ", OleDbType.Char, 7).Value = BE.articid.ToString();
                cmd.Parameters.Add("@pt712idco ", OleDbType.Char, 3).Value = BE.colorid.ToString();
                cmd.Parameters.Add("@pt712usid ", OleDbType.Char, 3).Value = BE.usuar.ToString();
                cmd.Parameters.Add("@pt712feac ", OleDbType.Date).Value = DateTime.Today.ToShortDateString();
                cmd.Parameters.Add("@ENSQL ", OleDbType.Boolean).Value = 1;
                cmd.Parameters.Add("@status ", OleDbType.Char, 1).Value = BE.status.ToString();

                cnx.Open();
                try
                {
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

        public bool Delete(string empresaid, tb_pt_articulocolor BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtArticulocolor_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
                        cmd.Parameters.Add("@colorid", SqlDbType.Char, 3).Value = BE.colorid;
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

        public DataSet GetAll(string empresaid, tb_pt_articulocolor BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtArticulocolor_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
                        cmd.Parameters.Add("@colorid", SqlDbType.Char, 3).Value = BE.colorid;
                        cmd.Parameters.Add("@colorname", SqlDbType.VarChar, 30).Value = BE.colorname;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@filtro", SqlDbType.Char, 1).Value = BE.filtro;
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

        public DataSet GetOne(string empresaid, string articid, string colorid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtArticulocolor_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = articid;
                        cmd.Parameters.Add("@colorid", SqlDbType.Char, 3).Value = colorid;
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
