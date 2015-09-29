using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_60local_stock_inventario_rolloDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_60local_stock_inventario_rollo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaLocalStockInventarioRollo_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;                    
                    cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                    cmd.Parameters.Add("@rollo", SqlDbType.Char, 10).Value = BE.rollo;
                    cmd.Parameters.Add("@stocklibros", SqlDbType.Decimal).Value = BE.stocklibros;
                    cmd.Parameters.Add("@stockfisico", SqlDbType.Decimal).Value = BE.stockfisico;
                    cmd.Parameters.Add("@diferencia", SqlDbType.Decimal).Value = BE.diferencia;
                    cmd.Parameters.Add("@costopromlibros", SqlDbType.Decimal).Value = BE.costopromlibros;
                    cmd.Parameters.Add("@costopromfisico", SqlDbType.Decimal).Value = BE.costopromfisico;
                    cmd.Parameters.Add("@codigoubic", SqlDbType.Char, 5).Value = BE.codigoubic;
                    cmd.Parameters.Add("@fechatoma", SqlDbType.DateTime).Value = BE.fechatoma;
                    cmd.Parameters.Add("@userinventario", SqlDbType.VarChar, 30).Value = BE.userinventario;
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

        public bool Update(string empresaid, tb_60local_stock_inventario_rollo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaLocalStockInventarioRollo_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@rollo", SqlDbType.Char, 10).Value = BE.rollo;
                        cmd.Parameters.Add("@stocklibros", SqlDbType.Decimal).Value = BE.stocklibros;
                        cmd.Parameters.Add("@stockfisico", SqlDbType.Decimal).Value = BE.stockfisico;
                        cmd.Parameters.Add("@diferencia", SqlDbType.Decimal).Value = BE.diferencia;
                        cmd.Parameters.Add("@costopromlibros", SqlDbType.Decimal).Value = BE.costopromlibros;
                        cmd.Parameters.Add("@costopromfisico", SqlDbType.Decimal).Value = BE.costopromfisico;
                        cmd.Parameters.Add("@codigoubic", SqlDbType.Char, 5).Value = BE.codigoubic;
                        cmd.Parameters.Add("@fechatoma", SqlDbType.DateTime).Value = BE.fechatoma;
                        cmd.Parameters.Add("@userinventario", SqlDbType.VarChar, 30).Value = BE.userinventario;
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

        public bool Update_digitar(string empresaid, tb_60local_stock_inventario_rollo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaLocalStockInventarioRollo_UPDATE_digitar", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@rollo", SqlDbType.Char, 10).Value = BE.rollo;
                        cmd.Parameters.Add("@stocklibros", SqlDbType.Decimal).Value = BE.stocklibros;
                        cmd.Parameters.Add("@stockfisico", SqlDbType.Decimal).Value = BE.stockfisico;
                        cmd.Parameters.Add("@diferencia", SqlDbType.Decimal).Value = BE.diferencia;
                        cmd.Parameters.Add("@costopromlibros", SqlDbType.Decimal).Value = BE.costopromlibros;
                        cmd.Parameters.Add("@costopromfisico", SqlDbType.Decimal).Value = BE.costopromfisico;
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

        public bool Delete(string empresaid, tb_60local_stock_inventario_rollo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaLocalStockInventarioRollo_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@rollo", SqlDbType.Char, 10).Value = BE.rollo;
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

        public DataSet GetAll(string empresaid, tb_60local_stock_inventario_rollo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaLocalStockInventarioRollo_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@productname", SqlDbType.Char, 13).Value = BE.productname;
                        cmd.Parameters.Add("@rollo", SqlDbType.Char, 10).Value = BE.rollo;
                        cmd.Parameters.Add("@codigoubic", SqlDbType.Char, 5).Value = BE.codigoubic;
                        cmd.Parameters.Add("@userinventario", SqlDbType.VarChar, 30).Value = BE.userinventario;
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

        public bool GetAll_TRANSFERIR (string empresaid, tb_60local_stock_inventario_rollo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaLocalStockInventarioRollo_TRANSFERIR", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
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

        public DataSet GetOne(string empresaid, tb_60local_stock_inventario_rollo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaLocalStockInventarioRollo_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@rollo", SqlDbType.Char, 10).Value = BE.rollo;
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



        public DataSet GetAll_Rollo(string empresaid, tb_60local_stock_inventario_rollo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                String SQLQuery = " SELECT 		             "+     
	                              " ttp.rollo,	             "+
	                              " p.productid,             "+
	                              " p.productname,           "+
	                              " ttp.stocklibros,         "+
	                              " ttp.stockfisico,         "+
	                              " ttp.diferencia 	       	 "+        
                                " FROM tb_ta_local_stock_inventario_rollo AS ttp                "+
                                " LEFT JOIN tb_ta_prodrollo AS ttp2 ON ttp.rollo = ttp2.rollo   "+
                                " LEFT JOIN tb_ta_productos AS p ON ttp2.productid = p.productid "+
                                " WHERE ttp.rollo = '"+BE.rollo+"' ";

                using (SqlCommand cmd = new SqlCommand(SQLQuery, cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.Text;                        
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

        public DataSet GetAllDifRollos(string empresaid, tb_60local_stock_inventario_rollo BE)        
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaLocalStockInventarioRollo_SEARCH_Dif", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@lineaid", SqlDbType.Char, 3).Value = BE.lineaid;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@rollo", SqlDbType.Char, 10).Value = BE.rollo;
                        cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = BE.fechatoma;
                        cmd.Parameters.Add("@dif", SqlDbType.Bit).Value = BE.dif;

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

        public DataSet GetAllDifRollos_gen(string empresaid, tb_60local_stock_inventario_rollo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaLocalStockInventarioRollo_SEARCH_Gen", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@rollo", SqlDbType.Char, 10).Value = BE.rollo;
                        cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = BE.fechatoma;
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

        public DataSet GetAllUbigeoRollos(string empresaid, tb_60local_stock_inventario_rollo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaLocalStockUbigeoRollo_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = BE.fechatoma;
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

        public DataSet GetAllUbigeoRollos_gen(string empresaid, tb_60local_stock_inventario_rollo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaLocalStockUbigeoRollo_SEARCH_gen", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = BE.fechatoma;
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
