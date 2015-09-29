using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_vendedor_corporativoDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_vendedor_corporativo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbVendedorCorporativo_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                    cmd.Parameters.Add("@vendorname", SqlDbType.VarChar, 50).Value = BE.vendorname;
                    cmd.Parameters.Add("@docuidentid", SqlDbType.Char, 1).Value = BE.docuidentid;
                    cmd.Parameters.Add("@vendordni", SqlDbType.Char, 10).Value = BE.vendordni;
                    cmd.Parameters.Add("@vendordire", SqlDbType.Char, 100).Value = BE.vendordire;
                    cmd.Parameters.Add("@vendorfeing", SqlDbType.DateTime).Value = BE.vendorfeing;
                    cmd.Parameters.Add("@vendortelef", SqlDbType.VarChar, 15).Value = BE.vendortelef;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@userweb", SqlDbType.VarChar, 15).Value = BE.userweb;
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

        public bool Update(string empresaid, tb_vendedor_corporativo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbVendedorCorporativo_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                        cmd.Parameters.Add("@vendorname", SqlDbType.VarChar, 50).Value = BE.vendorname;
                        cmd.Parameters.Add("@docuidentid", SqlDbType.Char, 1).Value = BE.docuidentid;
                        cmd.Parameters.Add("@vendordni", SqlDbType.Char, 10).Value = BE.vendordni;
                        cmd.Parameters.Add("@vendordire", SqlDbType.Char, 100).Value = BE.vendordire;
                        cmd.Parameters.Add("@vendorfeing", SqlDbType.DateTime).Value = BE.vendorfeing;
                        cmd.Parameters.Add("@vendortelef", SqlDbType.VarChar, 15).Value = BE.vendortelef;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@userweb", SqlDbType.VarChar, 15).Value = BE.userweb;
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

        public bool Delete(string empresaid, tb_vendedor_corporativo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbVendedorCorporativo_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
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

        public DataSet GetAll(string empresaid, tb_vendedor_corporativo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbVendedorCorporativo_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                        cmd.Parameters.Add("@vendorname", SqlDbType.VarChar, 50).Value = BE.vendorname;
                        cmd.Parameters.Add("@docuidentid", SqlDbType.Char, 1).Value = BE.docuidentid;
                        cmd.Parameters.Add("@vendordni", SqlDbType.Char, 10).Value = BE.vendordni;
                        cmd.Parameters.Add("@vendordire", SqlDbType.Char, 100).Value = BE.vendordire;
                        cmd.Parameters.Add("@vendortelef", SqlDbType.VarChar, 15).Value = BE.vendortelef;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@userweb", SqlDbType.VarChar, 15).Value = BE.userweb;
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

        public DataSet GetOne(string empresaid, string vendorid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbVendedorCorporativo_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = vendorid;
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
