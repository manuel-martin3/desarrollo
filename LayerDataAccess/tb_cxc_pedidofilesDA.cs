using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_cxc_pedidofilesDA
    {
        ConexionWeb conex = new ConexionWeb();

        public bool Insert(string empresaid, tb_cxc_pedidofiles BE, byte[] data)
        {            
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                try
                {
                    if (cnx.State == ConnectionState.Closed)
                    {
                        cnx.Open();
                    }

                    SqlCommand cmd = new SqlCommand(" INSERT INTO tb_cxc_proformafiles (tipdoc,serdoc,numdoc,Name,ContentType,Size,Data) " +
                                                    " VALUES(@tipdoc,@serdoc,@numdoc,@name,@contenttype,@size,@data) ", cnx);

                    cmd.Parameters.AddWithValue("@tipdoc", BE.tipdoc.ToString());
                    cmd.Parameters.AddWithValue("@serdoc", BE.serdoc.ToString());
                    cmd.Parameters.AddWithValue("@numdoc", BE.numdoc.ToString());
                    cmd.Parameters.AddWithValue("@name", BE.name.ToString());
                    cmd.Parameters.AddWithValue("@contenttype", BE.contenttype.ToString());
                    cmd.Parameters.AddWithValue("@size", BE.size.ToString());
                    cmd.Parameters.AddWithValue("@data", data);

                    int affectedRows = cmd.ExecuteNonQuery();

                    if (affectedRows > 0)
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

        public bool Update(string empresaid, tb_cxc_pedidofiles BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60Movimientoscab_UPDATE", cnx))
                {
                    {
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        //cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        //cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        //cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                        //cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        //cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                        //cmd.Parameters.Add("@fechentrega", SqlDbType.DateTime).Value = BE.fechentrega;
                        //cmd.Parameters.Add("@moneda", SqlDbType.Char).Value = BE.moneda;
                        //cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
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

        public bool Delete(string empresaid, tb_cxc_pedidofiles BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60Movimientoscab_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;                      
                        //cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        //cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        //cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        //cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
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

        public DataSet GetAll(string empresaid, tb_cxc_pedidofiles BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                try
                {
                    DataSet ds = new DataSet();
                    String SQL = " SELECT numdoc, Name, ContentType, Size FROM tb_cxc_proformafiles";
                    cnx.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(SQL, cnx))
                    {
                        da.Fill(ds);
                    }
                    return ds;
                }
                catch (SqlException e)
                {
                    return null;
                }
                finally
                {
                    cnx.Close();
                }
            }
        }

        public DataSet GetAFile(string empresaid, String numdoc)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                try
                {
                    DataSet ds = new DataSet();
                    String SQL = " SELECT numdoc, Name, ContentType, Size, Data FROM tb_cxc_proformafiles "
                                + " WHERE (numdoc = '" + numdoc + "') ";

                    cnx.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(SQL, cnx))
                    {
                        da.Fill(ds);
                    }
                    return ds;
                }
                catch (SqlException e)
                {
                    return null;
                }
                finally
                {
                    cnx.Close();
                }
            }
        }


    }
}
