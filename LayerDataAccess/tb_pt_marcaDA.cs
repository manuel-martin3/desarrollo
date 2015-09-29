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
    public class tb_pt_marcaDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_pt_marca BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtMarca_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE.marcaid;
                    cmd.Parameters.Add("@sigla", SqlDbType.Char, 2).Value = BE.sigla;
                    cmd.Parameters.Add("@marcaname", SqlDbType.VarChar, 20).Value = BE.marcaname;
                    cmd.Parameters.Add("@marcadescort", SqlDbType.VarChar, 10).Value = BE.marcadescort;
                    cmd.Parameters.Add("@marcaidold", SqlDbType.Char, 3).Value = BE.marcaidold;
                    cmd.Parameters.Add("@marcapropia", SqlDbType.Bit).Value = BE.marcapropia;
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

        public bool Insert_dbf(string empresaid, tb_pt_marca BE)
        {
            Conex_FoxDA cone = new Conex_FoxDA();
            using (OleDbConnection cnx = new OleDbConnection(cone.AdmConexion()))
            {
                String commandString =
               "INSERT INTO MARCA001 (MC001STAT ,MC001IDMC ,MC001NAME ,ENSQL " +                                     
                                    " )" +
               " VALUES (?, ?, ?, ? " +     
                        ")";

                using (OleDbCommand cmd = new OleDbCommand(commandString, cnx))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.Add("@MC001STAT ", OleDbType.Decimal).Value = 1;
                    cmd.Parameters.Add("@MC001IDMC ", OleDbType.Char, 2).Value = BE.marcaidold.ToString();
                    cmd.Parameters.Add("@MC001NAME ", OleDbType.VarChar, 20).Value = BE.marcaname.ToString();
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

        public bool Update(string empresaid, tb_pt_marca BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtMarca_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE.marcaid;
                        cmd.Parameters.Add("@sigla", SqlDbType.Char, 2).Value = BE.sigla;
                        cmd.Parameters.Add("@marcaname", SqlDbType.VarChar, 20).Value = BE.marcaname;
                        cmd.Parameters.Add("@marcadescort", SqlDbType.VarChar, 10).Value = BE.marcadescort;
                        cmd.Parameters.Add("@marcaidold", SqlDbType.Char, 3).Value = BE.marcaidold;
                        cmd.Parameters.Add("@marcapropia", SqlDbType.Bit).Value = BE.marcapropia;
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

        public bool Update_dbf(string empresaid, tb_pt_marca BE)
        {
            Conex_FoxDA cone = new Conex_FoxDA();
            using (OleDbConnection cnx = new OleDbConnection(cone.AdmConexion()))
            {
                String commandString =
               " UPDATE MARCA001 SET MC001NAME = ? " +
               " WHERE  MC001IDMC = ? ";
             
                using (OleDbCommand cmd = new OleDbCommand(commandString, cnx))
                {
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        //cmd.Parameters.Add("@MC001STAT", OleDbType.Decimal).Value = 1;
                        cmd.Parameters.Add("@MC001NAME", OleDbType.Char, 20).Value = BE.marcaname.ToString();
                        cmd.Parameters.Add("@MC001IDMC", OleDbType.Char, 2).Value = BE.marcaidold.ToString();    
                        //cmd.Parameters.Add("@ENSQL", OleDbType.Boolean).Value = 1; 
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

        public bool Delete(string empresaid, tb_pt_marca BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtMarca_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE.marcaid;
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

        public bool Delete_dbf(string empresaid, tb_pt_marca BE)
        {
            Conex_FoxDA cone = new Conex_FoxDA();
            using (OleDbConnection cnx = new OleDbConnection(cone.AdmConexion()))
            {
                String commandString =
               " UPDATE MARCA001 SET MC001STAT = ? " +
               " WHERE  MC001IDMC = ? ";

                using (OleDbCommand cmd = new OleDbCommand(commandString, cnx))
                {
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.Add("@MC001STAT", OleDbType.Decimal).Value = 9;
                        //cmd.Parameters.Add("@MC001NAME", OleDbType.Char, 20).Value = BE.marcaname.ToString();
                        cmd.Parameters.Add("@MC001IDMC", OleDbType.Char, 2).Value = BE.marcaidold.ToString();
                        //cmd.Parameters.Add("@ENSQL", OleDbType.Boolean).Value = 1; 
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


        public DataSet GetAll_CODdbf(string empresaid, tb_pt_marca BE)
        {
            Conex_FoxDA cone = new Conex_FoxDA();
            using (OleDbConnection cnx = new OleDbConnection(cone.AdmConexion()))
            {
                String commandString =
               "SELECT MAX(MC001IDMC) AS marcaidold  FROM  MARCA001;";

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

        public DataSet GetAll(string empresaid, tb_pt_marca BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtMarca_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE.marcaid;
                        cmd.Parameters.Add("@marcaname", SqlDbType.VarChar, 20).Value = BE.marcaname;
                        cmd.Parameters.Add("@marcadescort", SqlDbType.VarChar, 10).Value = BE.marcadescort;
                        cmd.Parameters.Add("@marcaidold", SqlDbType.Char, 3).Value = BE.marcaidold;
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

        public DataSet GetAll_paginacion(string empresaid, tb_pt_marca BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtMarca_SEARCH_paginacion", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE.marcaid;
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

        public DataSet GetOne(string empresaid, string marcaid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtMarca_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = marcaid;
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
