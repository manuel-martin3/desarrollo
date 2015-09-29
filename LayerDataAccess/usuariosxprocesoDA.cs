using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class usuariosxprocesoDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool UsuariosProcesosInsertUpdated(string empresaid, tb_usuariosxproceso BE, DataTable TablaDatos)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                bool xreturn = true;
                int lcont = 0;
                //BE.ntipo = 0 Borra y Graba 1 Sólo Graba el Registro Actual
                if (BE.ntipo == 0)
                {
                    using (SqlCommand cmd = new SqlCommand("gspTbUsuariosProceso_DELETED", cnx))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@uprocesoid", SqlDbType.Char,4).Value =  BE.procesoid;
                        try
                        {
                            cnx.Open();
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                xreturn = true;
                            }
                            else
                            {
                                xreturn = false;
                            }
                            cnx.Close();
                        }
                        catch (Exception ex)
                        {
                            Sql_Error = ex.Message;
                            //throw new Exception(ex.Message);
                            xreturn = false;
                            cnx.Close();
                        }
                    }
                }
                for (lcont = 0; lcont <= TablaDatos.Rows.Count - 1; lcont++)
                {
                    using (SqlCommand cmd = new SqlCommand("gspTbUsuariosProceso_InsertUpdated", cnx))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@uprocesoid", SqlDbType.Char, 4).Value = TablaDatos.Rows[lcont]["uprocesoid"];
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = TablaDatos.Rows[lcont]["usuar"];
                        cmd.Parameters.Add("@password", SqlDbType.Char, 20).Value = Convert.ToString(TablaDatos.Rows[lcont]["password"]);
                        cmd.Parameters.Add("@firma", SqlDbType.VarChar, 200).Value = TablaDatos.Rows[lcont]["firma"];
                        try
                        {
                            cnx.Open();
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                xreturn = true;
                            }
                            else
                            {
                                xreturn = false;
                            }
                            cnx.Close();
                        }
                        catch (Exception ex)
                        {
                            Sql_Error = ex.Message;
                            //throw new Exception(ex.Message);
                            xreturn = false;
                            cnx.Close();
                        }
                    }
                }
                return xreturn;
            }
        }

        public bool UsuariosProcesos_Replicar(string empresaid, tb_usuariosxproceso BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("gspTbUsuariosProceso_REPLICAR", cnx))
                    {                  
                        cmd.CommandType = CommandType.StoredProcedure;                       
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                        cmd.Parameters.Add("@procesoidorigen", SqlDbType.Char, 4).Value = BE.procesoid;
                        
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
                }
                catch (Exception ex)
                {
                    Sql_Error = ex.Message;
                    throw new Exception(ex.Message);
                }
            }
        }

        public DataSet GetAll_U_P(string empresaid, tb_usuariosxproceso BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbUsuariosProceso_GETALL", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@procesoid", SqlDbType.Char, 4).Value = BE.procesoid;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                        cmd.Parameters.Add("@password", SqlDbType.Char, 20).Value = BE.password;
                        cmd.Parameters.Add("@orden", SqlDbType.Int).Value = BE.norden;
                        cmd.Parameters.Add("@login", SqlDbType.Char, 15).Value = BE.login;
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

        public DataSet GetAll(string empresaid, tb_usuariosxproceso BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbUsuariosTiposProcesos_GETALL", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@procesoid", SqlDbType.Char, 4).Value = BE.procesoid;
                        cmd.Parameters.Add("@norden", SqlDbType.Int).Value = BE.norden;
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
    }
}
