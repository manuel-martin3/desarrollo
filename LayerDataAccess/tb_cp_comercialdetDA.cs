using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_cp_comercialdetDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_cp_comercialdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCpComercialdet_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@empresa", SqlDbType.Char, 2).Value = BE.empresa;
                    cmd.Parameters.Add("@asiento", SqlDbType.Char, 10).Value = BE.asiento;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@fechemision", SqlDbType.DateTime).Value = BE.fechemision;
                    cmd.Parameters.Add("@fechtermino", SqlDbType.DateTime).Value = BE.fechtermino;
                    cmd.Parameters.Add("@mnruc", SqlDbType.Char, 11).Value = BE.mnruc;
                    cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 80).Value = BE.ctactename;
                    cmd.Parameters.Add("@vendedorid", SqlDbType.Char, 4).Value = BE.vendedorid;
                    cmd.Parameters.Add("@brokerid", SqlDbType.Char, 4).Value = BE.brokerid;
                    cmd.Parameters.Add("@paisid", SqlDbType.Char, 4).Value = BE.paisid;
                    cmd.Parameters.Add("@mercadoid", SqlDbType.Char, 1).Value = BE.mercadoid;
                    cmd.Parameters.Add("@marcaid", SqlDbType.Char, 4).Value = BE.marcaid;
                    cmd.Parameters.Add("@proforma", SqlDbType.Text).Value = BE.proforma;
                    cmd.Parameters.Add("@status", SqlDbType.Bit).Value = BE.status;
                    cmd.Parameters.Add("@usuar", SqlDbType.VarChar, 200).Value = BE.usuar;
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

        public bool Update(string empresaid, tb_cp_comercialdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCpComercialdet_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@empresa", SqlDbType.Char, 2).Value = BE.empresa;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 10).Value = BE.asiento;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@fechemision", SqlDbType.DateTime).Value = BE.fechemision;
                        cmd.Parameters.Add("@fechtermino", SqlDbType.DateTime).Value = BE.fechtermino;
                        cmd.Parameters.Add("@mnruc", SqlDbType.Char, 11).Value = BE.mnruc;
                        cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 80).Value = BE.ctactename;
                        cmd.Parameters.Add("@vendedorid", SqlDbType.Char, 4).Value = BE.vendedorid;
                        cmd.Parameters.Add("@brokerid", SqlDbType.Char, 4).Value = BE.brokerid;
                        cmd.Parameters.Add("@paisid", SqlDbType.Char, 4).Value = BE.paisid;
                        cmd.Parameters.Add("@mercadoid", SqlDbType.Char, 1).Value = BE.mercadoid;
                        cmd.Parameters.Add("@marcaid", SqlDbType.Char, 4).Value = BE.marcaid;
                        cmd.Parameters.Add("@proforma", SqlDbType.Text).Value = BE.proforma;
                        cmd.Parameters.Add("@status", SqlDbType.Bit).Value = BE.status;
                        cmd.Parameters.Add("@usuar", SqlDbType.VarChar, 200).Value = BE.usuar;
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

        public bool Delete(string empresaid, tb_cp_comercialdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCpComercialdet_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@empresa", SqlDbType.Char, 2).Value = BE.empresa;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 10).Value = BE.asiento;
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

        public DataSet GetAll(string empresaid, tb_cp_comercialdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCpComercialdet_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@empresa", SqlDbType.Char, 2).Value = BE.empresa;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 10).Value = BE.asiento;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@fechemision", SqlDbType.DateTime).Value = BE.fechemision;
                        cmd.Parameters.Add("@fechtermino", SqlDbType.DateTime).Value = BE.fechtermino;
                        cmd.Parameters.Add("@mnruc", SqlDbType.Char, 11).Value = BE.mnruc;
                        cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 80).Value = BE.ctactename;
                        cmd.Parameters.Add("@vendedorid", SqlDbType.Char, 4).Value = BE.vendedorid;
                        cmd.Parameters.Add("@brokerid", SqlDbType.Char, 4).Value = BE.brokerid;
                        cmd.Parameters.Add("@paisid", SqlDbType.Char, 4).Value = BE.paisid;
                        cmd.Parameters.Add("@mercadoid", SqlDbType.Char, 1).Value = BE.mercadoid;
                        cmd.Parameters.Add("@marcaid", SqlDbType.Char, 4).Value = BE.marcaid;
                        cmd.Parameters.Add("@proforma", SqlDbType.Text).Value = BE.proforma;
                        cmd.Parameters.Add("@usuar", SqlDbType.VarChar, 200).Value = BE.usuar;
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

        public DataSet GetAsientoNume(string empresaid, tb_cp_comercialdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCpComercialdet_SEARCH_asientonume", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
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

        public DataSet GetAsientoRoleo(string empresaid, tb_cp_comercialdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCpComercialdet_SEARCH_roleo", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 10).Value = BE.asiento;
                        cmd.Parameters.Add("@tipo", SqlDbType.Char, 10).Value = BE.tipo;
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

        public DataSet GetOne(string empresaid, tb_cp_comercialdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCpComercialdet_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 10).Value = BE.asiento;
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

        public DataSet GetAll_datosdetalle(string empresaid, tb_cp_comercialdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCpComercial_SEARCH_datosdetalle", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
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
