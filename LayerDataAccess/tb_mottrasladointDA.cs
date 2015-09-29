using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;


namespace LayerDataAccess
{
    public class tb_mottrasladointDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_mottrasladoint BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMottrasladoint_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@mottrasladointid", SqlDbType.Char, 2).Value = BE.mottrasladointid;
                    cmd.Parameters.Add("@mottrasladointname", SqlDbType.VarChar, 50).Value = BE.mottrasladointname;
                    cmd.Parameters.Add("@tipmov", SqlDbType.Char, 1).Value = BE.tipmov;
                    cmd.Parameters.Add("@esventa", SqlDbType.Bit).Value = BE.esventa;
                    cmd.Parameters.Add("@escompra", SqlDbType.Bit).Value = BE.escompra;
                    cmd.Parameters.Add("@codigosunat", SqlDbType.Char, 2).Value = BE.codigosunat;

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

        public bool Update(string empresaid, tb_mottrasladoint BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMottrasladoint_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@mottrasladointid", SqlDbType.Char, 2).Value = BE.mottrasladointid;
                        cmd.Parameters.Add("@mottrasladointname", SqlDbType.VarChar, 50).Value = BE.mottrasladointname;
                        cmd.Parameters.Add("@tipmov", SqlDbType.Char, 1).Value = BE.tipmov;
                        cmd.Parameters.Add("@esventa", SqlDbType.Bit).Value = BE.esventa;
                        cmd.Parameters.Add("@escompra", SqlDbType.Bit).Value = BE.escompra;
                        cmd.Parameters.Add("@codigosunat", SqlDbType.Char, 2).Value = BE.codigosunat;
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

        public bool Delete(string empresaid, tb_mottrasladoint BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMottrasladoint_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@mottrasladointid", SqlDbType.Char, 2).Value = BE.mottrasladointid;
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

        public DataSet GetAll(string empresaid, tb_mottrasladoint BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMottrasladoint_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@mottrasladointid", SqlDbType.Char, 2).Value = BE.mottrasladointid;
                        cmd.Parameters.Add("@mottrasladointname", SqlDbType.VarChar, 50).Value = BE.mottrasladointname;
                        cmd.Parameters.Add("@tipmov", SqlDbType.Char, 1).Value = BE.tipmov;
                        cmd.Parameters.Add("@visible", SqlDbType.Bit).Value = BE.visible;
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

        public DataSet GetAll_paginacion(string empresaid, tb_mottrasladoint BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMottrasladoint_SEARCH_paginacion", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@mottrasladointid", SqlDbType.Char, 2).Value = BE.mottrasladointid;
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

        public DataSet GetOne(string empresaid, tb_mottrasladoint BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMottrasladoint_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@mottrasladointid", SqlDbType.Char, 2).Value = BE.mottrasladointid;
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
