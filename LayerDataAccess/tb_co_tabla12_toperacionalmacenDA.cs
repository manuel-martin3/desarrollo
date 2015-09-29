using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;


namespace LayerDataAccess
{
    public class tb_co_tabla12_toperacionalmacenDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_co_tabla12_toperacionalmacen BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTabla12Toperacionalmacen_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@codigoid", SqlDbType.Char, 2).Value = BE.codigoid;
                    cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 100).Value = BE.descripcion;
                    cmd.Parameters.Add("@sigla", SqlDbType.Char, 3).Value = BE.sigla;
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

        public bool Update(string empresaid, tb_co_tabla12_toperacionalmacen BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTabla12Toperacionalmacen_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@codigoid", SqlDbType.Char, 2).Value = BE.codigoid;
                        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 100).Value = BE.descripcion;
                        cmd.Parameters.Add("@sigla", SqlDbType.Char, 3).Value = BE.sigla;
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
                    finally
                    {
                        cnx.Close();
                    }
                }
            }
        }

        public bool Delete(string empresaid, tb_co_tabla12_toperacionalmacen BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTabla12Toperacionalmacen_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@codigoid", SqlDbType.Char, 2).Value = BE.codigoid;
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

        public DataSet GetAll(string empresaid, tb_co_tabla12_toperacionalmacen BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTabla12Toperacionalmacen_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@codigoid", SqlDbType.Char, 2).Value = BE.codigoid;
                        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 100).Value = BE.descripcion;
                        cmd.Parameters.Add("@sigla", SqlDbType.Char, 3).Value = BE.sigla;
                        cmd.Parameters.Add("@almacenaccionid", SqlDbType.Char, 2).Value = BE.almacenaccionid;
                        cmd.Parameters.Add("@docureq", SqlDbType.Char, 2).Value = BE.docureq;
                        cmd.Parameters.Add("@contratipo", SqlDbType.Char, 2).Value = BE.contratipo;
                        cmd.Parameters.Add("@tiptransac", SqlDbType.Char, 1).Value = BE.tiptransac;
                        cmd.Parameters.Add("@statcostopromed", SqlDbType.Char, 1).Value = BE.statcostopromed;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;                        
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


        public List<tb_co_tabla12_toperacionalmacen> CargarCombo(string empresaid, tb_co_tabla12_toperacionalmacen BE1)
        {           
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTabla12Toperacionalmacen_SEARCH", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@codigoid", SqlDbType.Char, 2).Value = BE1.codigoid;
                    cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 100).Value = BE1.descripcion;
                    cmd.Parameters.Add("@sigla", SqlDbType.Char, 3).Value = BE1.sigla;
                    cmd.Parameters.Add("@almacenaccionid", SqlDbType.Char, 2).Value = BE1.almacenaccionid;
                    cmd.Parameters.Add("@docureq", SqlDbType.Char, 2).Value = BE1.docureq;
                    cmd.Parameters.Add("@contratipo", SqlDbType.Char, 2).Value = BE1.contratipo;
                    cmd.Parameters.Add("@tiptransac", SqlDbType.Char, 1).Value = BE1.tiptransac;
                    cmd.Parameters.Add("@statcostopromed", SqlDbType.Char, 1).Value = BE1.statcostopromed;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE1.usuar;
                    cmd.Parameters.Add("@visible", SqlDbType.Bit).Value = BE1.visible;

                    List<tb_co_tabla12_toperacionalmacen> lista = new List<tb_co_tabla12_toperacionalmacen>();
                    tb_co_tabla12_toperacionalmacen BE = new tb_co_tabla12_toperacionalmacen();
                    BE.codigoid = "0";
                    BE.descripcion = "»» SELECCIONE ««";
                    lista.Add(BE);
                    try
                    {
                        cnx.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {                                
                                tb_co_tabla12_toperacionalmacen BE2 = new tb_co_tabla12_toperacionalmacen();
                                BE.cabecera = dr.GetString(0);
                                BE2.codigoid = Convert.ToString(dr["codigoid"]);
                                BE2.descripcion = Convert.ToString(dr["descripcion"]);

                                lista.Add(BE2);
                            }
                            return lista;
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }                                                          
                }
            }  
        }


        public DataSet GetOne(string empresaid, tb_co_tabla12_toperacionalmacen BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoTabla12Toperacionalmacen_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@codigoid", SqlDbType.Char, 2).Value = BE.codigoid;

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
}
