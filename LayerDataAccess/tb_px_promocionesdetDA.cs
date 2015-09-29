using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_px_promocionesdetDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_px_promocionesdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPxProductos_INSERT", cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;                                   
                    cmd.Parameters.Add("@promoid", SqlDbType.Int).Value = BE.promoid;
                    cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
                    cmd.Parameters.Add("@articidold", SqlDbType.VarChar, 20).Value = BE.articidold;
                    cmd.Parameters.Add("@articname", SqlDbType.VarChar, 50).Value = BE.articname;
                    cmd.Parameters.Add("@esDscto", SqlDbType.Bit).Value = BE.es_dscto;
                    cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = BE.cantidad;
                    cmd.Parameters.Add("@percdscto", SqlDbType.Decimal).Value = BE.percdscto;
                    cmd.Parameters.Add("@precunit", SqlDbType.Decimal).Value = BE.precunit;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd.Parameters.Add("@usuarIP", SqlDbType.VarChar, 50).Value = BE.UsuarIP;
                    //cmd.Parameters.Add("@feact", SqlDbType.DateTime).Value = BE.feact;                                        

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

        public bool InsertDet(string empresaid, tb_px_promocionesdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPxProductos_INSERT_xml", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@promoid", SqlDbType.Int).Value = BE.promoid;
                    cmd.Parameters.Add("@XML", SqlDbType.Xml).Value = BE.GetItemXML();

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

        public bool Update(string empresaid, tb_px_promocionesdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPxProductos_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@promoid", SqlDbType.Int).Value = BE.promoid;
                        cmd.Parameters.Add("@articid", SqlDbType.VarChar, 13).Value = BE.articid;
                        cmd.Parameters.Add("@articidold", SqlDbType.VarChar, 20).Value = BE.articidold;
                        cmd.Parameters.Add("@articname", SqlDbType.VarChar, 50).Value = BE.articname;
                        cmd.Parameters.Add("@esDscto", SqlDbType.Bit).Value = BE.es_dscto;
                        cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = BE.cantidad;
                        cmd.Parameters.Add("@percdscto", SqlDbType.Decimal).Value = BE.percdscto;
                        cmd.Parameters.Add("@precunit", SqlDbType.Decimal).Value = BE.precunit;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@usuarIP", SqlDbType.VarChar, 50).Value = BE.UsuarIP;
                        //cmd.Parameters.Add("@feact", SqlDbType.DateTime).Value = BE.feact;
    
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

        public bool Delete(string empresaid, tb_px_promocionesdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPxProductos_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@promoid", SqlDbType.Int).Value = BE.promoid;
                        //cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
                        cmd.Parameters.Add("@articidold", SqlDbType.Char, 20).Value = BE.articidold;
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

        public bool Delete2(string empresaid, tb_px_promocionesdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPxProductos_DELETE2", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@promoid", SqlDbType.Int).Value = BE.promoid;
                        //cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
                        //cmd.Parameters.Add("@articidold", SqlDbType.Char, 20).Value = BE.articidold;
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

        public DataSet GetAll(string empresaid, tb_px_promocionesdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPxProductos_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@promoid", SqlDbType.Int).Value = BE.promoid;
                        //cmd.Parameters.Add("@filtro", SqlDbType.Char, 1).Value = BE.filtro;
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

        public DataSet GetVigentes(string empresaid, tb_px_promocionesdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMeListaPreciosdet_SEARCH_Vigente", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        //cmd.Parameters.Add("@local", SqlDbType.Char,3).Value = BE.local;
                        //cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = BE.fecha;

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

        public DataSet FiltroProducto(string empresaid, tb_px_promocionesdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMeListaPrecios_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        //cmd.Parameters.Add("@listaprecid", SqlDbType.Int).Value = BE.listaprecid;
                        //cmd.Parameters.Add("@productname", SqlDbType.VarChar, 300).Value = BE.productname;
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

        public DataSet GetAll_paginacion(string empresaid, tb_px_promocionesdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMelistaprecios_SEARCH_paginacion", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        //cmd.Parameters.Add("@listaprecid", SqlDbType.Int).Value = BE.listaprecid;
                        //cmd.Parameters.Add("@posicion", SqlDbType.VarChar, 10).Value = BE.posicion;
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

        public DataSet GetAll_datosdetalle(string empresaid, tb_px_promocionesdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMeListaPrecios_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        //cmd.Parameters.Add("@listaprecid", SqlDbType.Int).Value = BE.listaprecid;

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
