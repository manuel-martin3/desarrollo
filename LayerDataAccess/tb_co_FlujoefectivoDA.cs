using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_co_FlujoefectivoDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_co_Flujoefectivo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoFlujoefectivo_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@fefectivoorden", SqlDbType.Char, 1).Value = BE.fefectivoorden;
                    cmd.Parameters.Add("@fefectivoid", SqlDbType.Char, 4).Value = BE.fefectivoid;
                    cmd.Parameters.Add("@fefectivoname", SqlDbType.VarChar, 100).Value = BE.fefectivoname;
                    cmd.Parameters.Add("@fefectivoformula", SqlDbType.VarChar, 100).Value = BE.fefectivoformula;
                    cmd.Parameters.Add("@importe", SqlDbType.Decimal).Value = BE.importe;
                    cmd.Parameters.Add("@fetitulo", SqlDbType.Bit).Value = BE.fetitulo;
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

        public bool Update(string empresaid, tb_co_Flujoefectivo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoFlujoefectivo_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@fefectivoorden", SqlDbType.Char, 1).Value = BE.fefectivoorden;
                        cmd.Parameters.Add("@fefectivoid", SqlDbType.Char, 4).Value = BE.fefectivoid;
                        cmd.Parameters.Add("@fefectivoname", SqlDbType.VarChar, 100).Value = BE.fefectivoname;
                        cmd.Parameters.Add("@fefectivoformula", SqlDbType.VarChar, 100).Value = BE.fefectivoformula;
                        cmd.Parameters.Add("@importe", SqlDbType.Decimal).Value = BE.importe;
                        cmd.Parameters.Add("@fetitulo", SqlDbType.Bit).Value = BE.fetitulo;
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

        public bool Delete(string empresaid, tb_co_Flujoefectivo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoFlujoefectivo_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@fefectivoorden", SqlDbType.Char, 1).Value = BE.fefectivoorden;
                        cmd.Parameters.Add("@fefectivoid", SqlDbType.Char, 4).Value = BE.fefectivoid;
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

        public DataSet GetAll(string empresaid, tb_co_Flujoefectivo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoFlujoefectivo_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@fefectivoorden", SqlDbType.Char, 1).Value = BE.fefectivoorden;
                        cmd.Parameters.Add("@fefectivoid", SqlDbType.Char, 4).Value = BE.fefectivoid;
                        cmd.Parameters.Add("@fefectivoname", SqlDbType.VarChar, 100).Value = BE.fefectivoname;
                        cmd.Parameters.Add("@fefectivoformula", SqlDbType.VarChar, 100).Value = BE.fefectivoformula;
                        //cmd.Parameters.Add("@importe", SqlDbType.Decimal).Value = BE.importe;
                        cmd.Parameters.Add("@fetitulo", SqlDbType.Bit).Value = BE.fetitulo;
                        cmd.Parameters.Add("@incluir_blanco", SqlDbType.Int).Value = BE.incluir_blanco;
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

        public DataSet GetOne(string empresaid, tb_co_Flujoefectivo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoFlujoefectivo_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@fefectivoorden", SqlDbType.Char, 1).Value = BE.fefectivoorden;
                        cmd.Parameters.Add("@fefectivoid", SqlDbType.Char, 4).Value = BE.fefectivoid;
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
