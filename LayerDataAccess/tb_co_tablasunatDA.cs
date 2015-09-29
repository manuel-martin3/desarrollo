using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_co_tablasunatDA
    {
        public String Sql_Error = "";
        Conexion conex = new Conexion();

        public bool Insert(string empresaid, tb_co_tablasunat BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTablaSunat_InsertUpdate", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tablaid", SqlDbType.Char, 10).Value = BE.tablaid;
                    cmd.Parameters.Add("@codigoid", SqlDbType.Char, 4).Value = BE.codigoid;
                    cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 500).Value = BE.descripcion;
                    cmd.Parameters.Add("@sigla", SqlDbType.VarChar, 100).Value = BE.sigla;
                    cmd.Parameters.Add("@docref", SqlDbType.Bit).Value = BE.docref;
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

        public bool Update(string empresaid, tb_co_tablasunat BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTabla10Comprobantes_UPDATE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@codigoid", SqlDbType.Char, 2).Value = BE.codigoid;
                        //cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 100).Value = BE.descripcion;
                        //cmd.Parameters.Add("@sigla", SqlDbType.Char, 3).Value = BE.sigla;
                        //cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                        //cmd.Parameters.Add("@docref", SqlDbType.Bit).Value = BE.docref;
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

        public bool Delete(string empresaid, tb_co_tablasunat BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTablaSunat_ELIMINAR", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tablaid", SqlDbType.Char, 10).Value = BE.tablaid;
                        cmd.Parameters.Add("@codigoid", SqlDbType.Char, 4).Value = BE.codigoid;
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

        public DataSet GetAll(string empresaid, tb_co_tablasunat BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTablaSunat_CONSULTA", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tablaid", SqlDbType.Char, 10).Value = BE.tablaid;
                        cmd.Parameters.Add("@codigoid", SqlDbType.Char, 4).Value = BE.codigoid;
                        cmd.Parameters.Add("@nomlike1", SqlDbType.VarChar, 500).Value = BE.nomlike1;
                        cmd.Parameters.Add("@nomlike2", SqlDbType.VarChar, 500).Value = BE.nomlike2;
                        cmd.Parameters.Add("@nomlike3", SqlDbType.VarChar, 500).Value = BE.nomlike3;
                        cmd.Parameters.Add("@norden", SqlDbType.Int).Value = BE.norden;
                        cmd.Parameters.Add("@incluir_blanco", SqlDbType.Int).Value = BE.incluir_blanco;
                    }
                    cnx.Open();
                    try
                    {                       
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

        public DataSet GetOne(string empresaid, tb_co_tablasunat BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTabla10Comprobantes_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@codigoid", SqlDbType.Char, 2).Value = BE.codigoid;
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
