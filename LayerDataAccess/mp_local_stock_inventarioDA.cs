using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class mp_local_stock_inventarioDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_mp_local_stock_inventario BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpLocalStockInventario_INSERT", cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                    cmd.Parameters.Add("@stocklibros", SqlDbType.Decimal).Value = BE.stocklibros;
                    cmd.Parameters.Add("@stockfisico", SqlDbType.Decimal).Value = BE.stockfisico;
                    cmd.Parameters.Add("@diferencia", SqlDbType.Decimal).Value = BE.diferencia;
                    cmd.Parameters.Add("@costopromlibros", SqlDbType.Decimal).Value = BE.costopromlibros;
                    cmd.Parameters.Add("@costopromfisico", SqlDbType.Decimal).Value = BE.costopromfisico;
                    cmd.Parameters.Add("@codigoubic", SqlDbType.Char, 5).Value = BE.codigoubic;
                    cmd.Parameters.Add("@fechatoma", SqlDbType.DateTime).Value = BE.fechatoma;
                    cmd.Parameters.Add("@userinventario", SqlDbType.VarChar, 30).Value = BE.userinventario;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    cmd.Parameters.Add("@feact", SqlDbType.DateTime).Value = BE.feact;

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

        public bool Update(string empresaid, tb_mp_local_stock_inventario BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpLocalStockInventario_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
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

        public bool Update_digitar(string empresaid, tb_mp_local_stock_inventario BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpLocalStockInventario_UPDATE_digitar", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
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

        public bool Delete(string empresaid, tb_mp_local_stock_inventario BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpLocalStockInventario_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
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

        public DataSet GetAll(string empresaid, tb_mp_local_stock_inventario BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpLocalStockInventario_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@productname", SqlDbType.VarChar, 60).Value = BE.productname;
                        //cmd.Parameters.Add("@diferencia", SqlDbType.Decimal).Value = BE.diferencia;                     
                        cmd.Parameters.Add("@codigoubic", SqlDbType.Char, 5).Value = BE.codigoubic;
                        cmd.Parameters.Add("@userinventario", SqlDbType.VarChar, 30).Value = BE.userinventario;
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

        public DataSet GetAll_listar(string empresaid, tb_mp_local_stock_inventario BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpLocalStockInventario_LISTAR", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@productidini", SqlDbType.Char, 13).Value = BE.productidini;
                        cmd.Parameters.Add("@productidfin", SqlDbType.Char, 13).Value = BE.productidfin;
                        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = BE.descripcion;
                        cmd.Parameters.Add("@stockmayorcero", SqlDbType.Char, 1).Value = BE.stockmayorcero;
                        cmd.Parameters.Add("@orden", SqlDbType.Char, 1).Value = BE.orden;

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

        public bool GetAll_INICIALIZAR(string empresaid, tb_mp_local_stock_inventario BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpLocalStockInventario_INICIALIZAR", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@fechatoma", SqlDbType.DateTime).Value = BE.fechatoma;
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

        public bool GetAll_AjusteInventario(string empresaid, tb_mp_local_stock_inventario BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpLocalStock_AjusteInventario", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@dominioid", SqlDbType.Char, 2).Value = BE.dominioid;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@fechatoma", SqlDbType.DateTime).Value = BE.fechatoma;
                        cmd.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;                        
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                        cmd.Parameters.Add("@feact", SqlDbType.DateTime).Value = BE.feact;
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

        public DataSet GetOne(string empresaid, tb_mp_local_stock_inventario BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpLocalStockInventario_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
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
