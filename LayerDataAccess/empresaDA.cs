using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class empresaDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(tb_empresa BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.AdmConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbEmpresa_INSERT", cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = BE.empresaid;
                    cmd.Parameters.Add("@empresadirec", SqlDbType.VarChar, 60).Value = BE.empresadirec;
                    cmd.Parameters.Add("@empresaname", SqlDbType.VarChar, 60).Value = BE.empresaname;
                    cmd.Parameters.Add("@empresaperiodo", SqlDbType.Char, 4).Value = BE.empresaperiodo;
                    cmd.Parameters.Add("@empresaruc", SqlDbType.Char, 11).Value = BE.empresaruc;
                    cmd.Parameters.Add("@empresatelef", SqlDbType.VarChar, 30).Value = BE.empresatelef;
                    cmd.Parameters.Add("@foto", SqlDbType.VarChar, 100).Value = BE.foto;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;

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

        public bool Update(tb_empresa BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.AdmConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbEmpresa_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = BE.empresaid;
                        cmd.Parameters.Add("@empresadirec", SqlDbType.VarChar, 60).Value = BE.empresadirec;
                        cmd.Parameters.Add("@empresaname", SqlDbType.VarChar, 60).Value = BE.empresaname;
                        cmd.Parameters.Add("@empresaperiodo", SqlDbType.Char, 4).Value = BE.empresaperiodo;
                        cmd.Parameters.Add("@empresaruc", SqlDbType.Char, 11).Value = BE.empresaruc;
                        cmd.Parameters.Add("@empresatelef", SqlDbType.VarChar, 30).Value = BE.empresatelef;
                        cmd.Parameters.Add("@foto", SqlDbType.VarChar, 100).Value = BE.foto;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
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

        public bool Delete(tb_empresa BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.AdmConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbEmpresa_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = BE.empresaid;
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

        public DataSet GetAll(tb_empresa BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.AdmConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbEmpresa_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = BE.empresaid;
                        cmd.Parameters.Add("@empresaname", SqlDbType.VarChar, 60).Value = BE.empresaname;
                        cmd.Parameters.Add("@empresaperiodo", SqlDbType.Char, 4).Value = BE.empresaperiodo;
                        //cmd.Parameters.Add("@visible", SqlDbType.Bit).Value = true;
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

        public bool CrearBase_sdf(string BE)
        {
            try
            {
                SqlConnection SqlCon = new SqlConnection(conex.empConexion(BE));                
                String str = "CREATE DATABASE MyDatabase ON PRIMARY " +
                             "(NAME = MyDatabase_Data, " +
                             "FILENAME = 'D:\\MyDatabaseData.mdf', " +
                             "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                             "LOG ON (NAME = MyDatabase_Log, " +
                             "FILENAME = 'D:\\MyDatabaseLog.ldf', " +
                             "SIZE = 1MB, " +
                             "MAXSIZE = 5MB, " +
                             "FILEGROWTH = 10%)";

                SqlCommand cmd = new SqlCommand(str, SqlCon);
                SqlCon.Open();              
                int CreateDatabase = cmd.ExecuteNonQuery();

                if (CreateDatabase > 0)
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
        public DataSet GetOne(string empresaid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.AdmConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbEmpresa_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = empresaid;
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
