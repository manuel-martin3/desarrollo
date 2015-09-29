using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;


namespace LayerDataAccess
{
    public class tb_cxc_vendorDA
    {
        ConexionWeb conex = new ConexionWeb();

        public bool Insert(string empresaid, tb_cxc_vendor BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCxcVendedor_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                    cmd.Parameters.Add("@vendorname", SqlDbType.VarChar, 100).Value = BE.vendorname;
                    cmd.Parameters.Add("@ddnni", SqlDbType.Char, 8).Value = BE.ddnni;
                    cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                    cmd.Parameters.Add("@canalventaid", SqlDbType.Char, 3).Value = BE.canalventaid;
                    cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 100).Value = BE.direccion;
                    cmd.Parameters.Add("@fech_ingre", SqlDbType.DateTime).Value = BE.fech_ingre;
                    cmd.Parameters.Add("@fech_cese", SqlDbType.DateTime).Value = BE.fech_cese;
                    cmd.Parameters.Add("@motivocese", SqlDbType.VarChar, 50).Value = BE.motivocese;
                    cmd.Parameters.Add("@telefonos", SqlDbType.VarChar, 20).Value = BE.telefono;
                    cmd.Parameters.Add("@usuarweb", SqlDbType.Char, 15).Value = BE.usuarweb;
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

        public bool Update(string empresaid, tb_cxc_vendor BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCxcVendedor_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                        cmd.Parameters.Add("@vendorname", SqlDbType.VarChar, 100).Value = BE.vendorname;
                        cmd.Parameters.Add("@ddnni", SqlDbType.Char, 8).Value = BE.ddnni;
                        cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                        cmd.Parameters.Add("@canalventaid", SqlDbType.Char, 3).Value = BE.canalventaid;
                        cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 100).Value = BE.direccion;
                        cmd.Parameters.Add("@fech_ingre", SqlDbType.DateTime).Value = BE.fech_ingre;
                        cmd.Parameters.Add("@fech_cese", SqlDbType.DateTime).Value = BE.fech_cese;
                        cmd.Parameters.Add("@motivocese", SqlDbType.VarChar, 50).Value = BE.motivocese;
                        cmd.Parameters.Add("@telefonos", SqlDbType.VarChar, 20).Value = BE.telefono;
                        cmd.Parameters.Add("@usuarweb", SqlDbType.Char, 15).Value = BE.usuarweb;
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

        public bool Delete(string empresaid, tb_cxc_vendor BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCxcVendedor_DELETE", cnx))
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

        public DataSet GetAll(string empresaid, tb_cxc_vendor BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCxcVendedor_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                        cmd.Parameters.Add("@vendorname", SqlDbType.VarChar, 100).Value = BE.vendorname;
                        cmd.Parameters.Add("@ddnni", SqlDbType.Char, 8).Value = BE.ddnni;
                        cmd.Parameters.Add("@usuarweb", SqlDbType.Char, 15).Value = BE.usuarweb;                       
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

        public DataSet GetAll2(string empresaid, tb_cxc_vendor BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCxcVendedor_SEARCH2", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                        //cmd.Parameters.Add("@vendorname", SqlDbType.VarChar, 100).Value = BE.vendorname;
                        //cmd.Parameters.Add("@ddnni", SqlDbType.Char, 8).Value = BE.ddnni;
                        //cmd.Parameters.Add("@usuarweb", SqlDbType.Char, 15).Value = BE.usuarweb;
                        cmd.Parameters.Add("@parameters", SqlDbType.VarChar).Value = BE.parameters;
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

        public DataSet GetAll_paginacion(string empresaid, tb_cxc_vendor BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtColor_SEARCH_paginacion", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@colorid", SqlDbType.Char, 3).Value = BE.colorid;
                        //cmd.Parameters.Add("@posicion", SqlDbType.Char, 10).Value = BE.posicion;
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

        public DataSet GetOne(string empresaid, string colorid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtColor_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
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
