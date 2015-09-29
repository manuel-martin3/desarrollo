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
    public class tb_pt_lineaDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_pt_linea BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtLinea_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@lineaid", SqlDbType.Char, 2).Value = BE.lineaid;
                    cmd.Parameters.Add("@lineaname", SqlDbType.VarChar, 20).Value = BE.lineaname;
                    cmd.Parameters.Add("@lineadescort", SqlDbType.Char, 10).Value = BE.lineadescort;
                    cmd.Parameters.Add("@lineaidold", SqlDbType.Char, 3).Value = BE.lineaidold;
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

        public bool Insert_dbf(string empresaid, tb_pt_linea BE)
        {
            Conex_FoxDA cone = new Conex_FoxDA();
            using (OleDbConnection cnx = new OleDbConnection(cone.AdmConexion()))
            {
                String commandString =
               "INSERT INTO LINEA001 (LI001STAT ,LI001IDLI ,LI001NAME ,LI001USID ,LI001FEAC ,ENSQL " +
                                    " )" +
               " VALUES (?, ?, ?, ?, ?, ? " +
                        ")";

                using (OleDbCommand cmd = new OleDbCommand(commandString, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.Add("@LI001STAT ", OleDbType.Decimal).Value = 1;
                    cmd.Parameters.Add("@LI001IDLI ", OleDbType.Char, 32).Value = BE.lineaidold.ToString();
                    cmd.Parameters.Add("@LI001NAME ", OleDbType.Char, 10).Value = BE.lineaname.ToString();
                    cmd.Parameters.Add("@LI001USID ", OleDbType.Char, 3).Value = BE.usuar.ToString();
                    cmd.Parameters.Add("@LI001FEAC ", OleDbType.Date).Value = DateTime.Today.ToShortDateString();
                    cmd.Parameters.Add("@ENSQL ", OleDbType.Boolean).Value = 0;

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


        public bool Update(string empresaid, tb_pt_linea BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtLinea_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@lineaid", SqlDbType.Char, 2).Value = BE.lineaid;
                        cmd.Parameters.Add("@lineaname", SqlDbType.VarChar, 20).Value = BE.lineaname;
                        cmd.Parameters.Add("@lineadescort", SqlDbType.Char, 10).Value = BE.lineadescort;
                        cmd.Parameters.Add("@lineaidold", SqlDbType.Char, 3).Value = BE.lineaidold;
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

        public bool Update_dbf(string empresaid, tb_pt_linea BE)
        {
            Conex_FoxDA cone = new Conex_FoxDA();
            using (OleDbConnection cnx = new OleDbConnection(cone.AdmConexion()))
            {
                String commandString =
               " UPDATE LINEA001 SET LI001NAME = ? " +
               " WHERE  LI001IDLI = ? ";

                using (OleDbCommand cmd = new OleDbCommand(commandString, cnx))
                {
                    {
                        cmd.CommandType = System.Data.CommandType.Text;                           
                        cmd.Parameters.Add("@LI001NAME", OleDbType.VarChar, 10).Value = BE.lineaname.ToString();
                        cmd.Parameters.Add("@LI001IDLI", OleDbType.VarChar, 3).Value = BE.lineaidold.ToString();
                        //cmd.Parameters.Add("@LI001USID ", OleDbType.Char, 3).Value = BE.usuar.ToString();
                        //.Parameters.Add("@LI001FEAC ", OleDbType.Date).Value = DateTime.Today.ToShortDateString();
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


        public bool Delete(string empresaid, tb_pt_linea BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtLinea_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@lineaid", SqlDbType.Char, 2).Value = BE.lineaid;
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

        public bool Delete_dbf(string empresaid, tb_pt_linea BE)
        {
            Conex_FoxDA cone = new Conex_FoxDA();
            using (OleDbConnection cnx = new OleDbConnection(cone.AdmConexion()))
            {
                String commandString =
               " UPDATE LINEA001 SET LI001STAT = ? " +
               " WHERE  LI001IDLI = ? ";

                using (OleDbCommand cmd = new OleDbCommand(commandString, cnx))
                {
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.Add("@LI001STAT", OleDbType.Decimal).Value = 9;                        
                        cmd.Parameters.Add("@LI001IDLI", OleDbType.Char, 3).Value = BE.lineaidold.ToString();                        
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


        public DataSet GetAll(string empresaid, tb_pt_linea BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtLinea_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@lineaid", SqlDbType.Char, 2).Value = BE.lineaid;
                        cmd.Parameters.Add("@lineaname", SqlDbType.VarChar, 20).Value = BE.lineaname;
                        cmd.Parameters.Add("@lineadescort", SqlDbType.Char, 10).Value = BE.lineadescort;
                        cmd.Parameters.Add("@lineaidold", SqlDbType.Char, 3).Value = BE.lineaidold;
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

        public DataSet GetAll_CODdbf(string empresaid, tb_pt_linea BE)
        {
            Conex_FoxDA cone = new Conex_FoxDA();
            using (OleDbConnection cnx = new OleDbConnection(cone.AdmConexion()))
            {
                String commandString =
               "SELECT MAX(LI001IDLI) AS lineaidold  FROM  LINEA001;";

                using (OleDbCommand cmd = new OleDbCommand(commandString, cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                    }
                    try
                    {
                        cnx.Open();
                        using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
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


        public DataSet GetAll_paginacion(string empresaid, tb_pt_linea BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtLinea_SEARCH_paginacion", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@lineaid", SqlDbType.Char, 2).Value = BE.lineaid;
                        cmd.Parameters.Add("@posicion", SqlDbType.VarChar, 10).Value = BE.posicion;
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

        public DataSet GetOne(string empresaid, string lineaid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtLinea_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@lineaid", SqlDbType.Char, 2).Value = lineaid;
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
