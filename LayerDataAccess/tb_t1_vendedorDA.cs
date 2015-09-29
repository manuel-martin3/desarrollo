using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_t1_vendedorDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_t1_vendedor BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbT1Vendedor_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ddnni", SqlDbType.Char, 8).Value = BE.ddnni;
                    cmd.Parameters.Add("@vendorname", SqlDbType.VarChar, 50).Value = BE.vendorname;
                    cmd.Parameters.Add("@direcc", SqlDbType.VarChar, 70).Value = BE.direcc;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@telefono", SqlDbType.Char, 11).Value = BE.telefono;
                    cmd.Parameters.Add("@fechnac", SqlDbType.DateTime).Value = BE.fechanac;
                    cmd.Parameters.Add("@generoid", SqlDbType.Char).Value = BE.generoid;
                    cmd.Parameters.Add("@cargoid", SqlDbType.Char, 2).Value = BE.ccargoid;
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

        public bool Update(string empresaid, tb_t1_vendedor BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbT1Vendedor_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                        cmd.Parameters.Add("@ddnni", SqlDbType.Char, 8).Value = BE.ddnni;
                        cmd.Parameters.Add("@vendorname", SqlDbType.VarChar, 50).Value = BE.vendorname;
                        cmd.Parameters.Add("@direcc", SqlDbType.VarChar, 70).Value = BE.direcc;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@telefono", SqlDbType.Char, 11).Value = BE.telefono;
                        cmd.Parameters.Add("@fechnac", SqlDbType.DateTime).Value = BE.fechanac;
                        cmd.Parameters.Add("@generoid", SqlDbType.Char).Value = BE.generoid;
                        cmd.Parameters.Add("@cargoid", SqlDbType.Char, 2).Value = BE.ccargoid;
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

        public bool Delete(string empresaid, tb_t1_vendedor BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                //using (SqlCommand cmd = new SqlCommand("gspTbVendedorCorporativo_DELETE", cnx))
                using (SqlCommand cmd = new SqlCommand("gspTbT1Vendedor_DELETE", cnx))
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

        public DataSet GetAll(string empresaid, tb_t1_vendedor BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbT1Vendedor_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                        cmd.Parameters.Add("@vendorname", SqlDbType.VarChar, 50).Value = BE.vendorname;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;                        
                        cmd.Parameters.Add("@ddnni", SqlDbType.Char, 8).Value = BE.ddnni;
                        cmd.Parameters.Add("@generoid", SqlDbType.Char, 1).Value = BE.generoid;
                        cmd.Parameters.Add("@cargoid", SqlDbType.Char, 2).Value = BE.ccargoid;
                        //cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        //cmd.Parameters.Add("@userweb", SqlDbType.VarChar, 15).Value = BE.userweb;
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
                using (SqlCommand cmd = new SqlCommand("gspTbT1Vendedor_SELECT", cnx))
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
