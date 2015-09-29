using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_ta_prodrolloDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_ta_prodrollo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaProdrollo_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                    cmd.Parameters.Add("@rollo", SqlDbType.Char, 10).Value = BE.rollo;
                    cmd.Parameters.Add("@rollolote", SqlDbType.VarChar, 10).Value = BE.rollolote;
                    cmd.Parameters.Add("@rolloingre", SqlDbType.Decimal).Value = BE.rolloingre;
                    cmd.Parameters.Add("@rolloegres", SqlDbType.Decimal).Value = BE.rolloegres;
                    cmd.Parameters.Add("@rollovaloractual", SqlDbType.Decimal).Value = BE.rollovaloractual;
                    cmd.Parameters.Add("@rollomedcompra", SqlDbType.Decimal).Value = BE.rollomedcompra;
                    cmd.Parameters.Add("@rollofecompra", SqlDbType.DateTime).Value = BE.rollofecompra;
                    cmd.Parameters.Add("@rolloancho", SqlDbType.Decimal).Value = BE.rolloancho;
                    cmd.Parameters.Add("@rolloencog", SqlDbType.Decimal).Value = BE.rolloencog;
                    cmd.Parameters.Add("@tipofallasid", SqlDbType.Char, 2).Value = BE.tipofallasid;
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

        public bool Update(string empresaid, tb_ta_prodrollo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaProdrollo_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@rollo", SqlDbType.Char, 10).Value = BE.rollo;
                        cmd.Parameters.Add("@rollolote", SqlDbType.VarChar, 10).Value = BE.rollolote;
                        cmd.Parameters.Add("@rollostock", SqlDbType.VarChar, 10).Value = BE.rollostock;
                        cmd.Parameters.Add("@rolloingre", SqlDbType.Decimal).Value = BE.rolloingre;
                        cmd.Parameters.Add("@rolloegres", SqlDbType.Decimal).Value = BE.rolloegres;
                        cmd.Parameters.Add("@rollovaloractual", SqlDbType.Decimal).Value = BE.rollovaloractual;
                        cmd.Parameters.Add("@rollomedcompra", SqlDbType.Decimal).Value = BE.rollomedcompra;
                        cmd.Parameters.Add("@rollofecompra", SqlDbType.DateTime).Value = BE.rollofecompra;
                        cmd.Parameters.Add("@rolloancho", SqlDbType.Decimal).Value = BE.rolloancho;
                        cmd.Parameters.Add("@rolloencog", SqlDbType.Decimal).Value = BE.rolloencog;
                        cmd.Parameters.Add("@tipofallasid", SqlDbType.Char, 2).Value = BE.tipofallasid;
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

        public bool Delete(string empresaid, tb_ta_prodrollo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaProdrollo_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
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

        public DataSet GetAll(string empresaid, tb_ta_prodrollo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaProdrollo_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@rollo", SqlDbType.Char, 10).Value = BE.rollo;
                        cmd.Parameters.Add("@rollolote", SqlDbType.VarChar, 10).Value = BE.rollolote;
                        cmd.Parameters.Add("@tipofallasid", SqlDbType.Char, 2).Value = BE.tipofallasid;
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


        public DataSet Get_Datos_Reporte(string empresaid, tb_ta_prodrollo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaProdrollo_SEARCH_ROLLO", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
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


        public DataSet GetAll_prod(string empresaid, tb_ta_prodrollo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaProdrollo_SEARCH_prod", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@rollo", SqlDbType.Char, 10).Value = BE.rollo;
                        cmd.Parameters.Add("@rollolote", SqlDbType.VarChar, 10).Value = BE.rollolote;
                        cmd.Parameters.Add("@productname", SqlDbType.VarChar, 60).Value = BE.productname;
                        cmd.Parameters.Add("@rollodesde", SqlDbType.Char, 10).Value = BE.rollodesde;
                        cmd.Parameters.Add("@rollohasta", SqlDbType.Char, 10).Value = BE.rollohasta;

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

        public DataSet GetAll_paginacion(string empresaid, tb_ta_prodrollo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaProdrollo_SEARCH_paginacion", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@rollo", SqlDbType.Char, 10).Value = BE.rollo;
                        cmd.Parameters.Add("@rollolote", SqlDbType.VarChar, 10).Value = BE.rollolote;
                        cmd.Parameters.Add("@productname", SqlDbType.VarChar, 60).Value = BE.productname;
                        cmd.Parameters.Add("@rollodesde", SqlDbType.Char, 10).Value = BE.rollodesde;
                        cmd.Parameters.Add("@rollohasta", SqlDbType.Char, 10).Value = BE.rollohasta;
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

        public DataSet GetAll_codbarra(string empresaid, tb_ta_prodrollo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaProdrollo_SEARCH_print", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@rollodesde", SqlDbType.Char, 10).Value = BE.rollodesde;
                        cmd.Parameters.Add("@rollohasta", SqlDbType.Char, 10).Value = BE.rollohasta;
                        cmd.Parameters.Add("@todos", SqlDbType.Bit).Value = false;
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

        //*** OPT ***/
        public DataSet GetAll_numgenerado(string empresaid, tb_ta_prodrollo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaProdrollo_numgenerado", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
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

        public DataSet GetOne(string empresaid, string rollo)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaProdrollo_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@rollo", SqlDbType.Char, 10).Value = rollo;
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

        public DataSet GetAll_Localstock(string empresaid, tb_ta_prodrollo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaProdrollo_SEARCH_localstock", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
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

        public DataSet GetAll_stock(string empresaid, tb_ta_prodrollo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaProdrollo_SEARCH_stock", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
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
    }
}
