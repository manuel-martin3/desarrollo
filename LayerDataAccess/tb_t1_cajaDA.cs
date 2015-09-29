using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_t1_cajaDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_t1_caja BE, DataTable DatDetalle)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbT1Caja_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char,4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char,3).Value = BE.local;
                    cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = BE.fecha;
                    cmd.Parameters.Add("@tcambio", SqlDbType.Decimal).Value = BE.tcambio;
                    cmd.Parameters.Add("@adminid", SqlDbType.Char,4).Value = BE.adminid;
                    cmd.Parameters.Add("@cajeroid", SqlDbType.Char,4).Value = BE.cajeroid;
                    cmd.Parameters.Add("@apertura1", SqlDbType.Decimal).Value = BE.apertura1;
                    cmd.Parameters.Add("@apertura2", SqlDbType.Decimal).Value = BE.apertura2;
                    cmd.Parameters.Add("@cierre1", SqlDbType.Decimal).Value = BE.cierre1;
                    cmd.Parameters.Add("@cierre2", SqlDbType.Decimal).Value = BE.cierre2;
                    cmd.Parameters.Add("@cerrado", SqlDbType.Bit).Value = BE.cerrado;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char,15).Value = BE.usuar;

                    // Detalle
                    cmd.Parameters.AddWithValue("@DetalleImp", DatDetalle);
                                
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

        public bool Update(string empresaid, tb_t1_caja BE, DataTable DatDetalle)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbT1Caja_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = BE.fecha;
                        cmd.Parameters.Add("@tcambio", SqlDbType.Decimal).Value = BE.tcambio;
                        cmd.Parameters.Add("@adminid", SqlDbType.Char, 4).Value = BE.adminid;
                        cmd.Parameters.Add("@cajeroid", SqlDbType.Char, 4).Value = BE.cajeroid;
                        cmd.Parameters.Add("@apertura1", SqlDbType.Decimal).Value = BE.apertura1;
                        cmd.Parameters.Add("@apertura2", SqlDbType.Decimal).Value = BE.apertura2;
                        cmd.Parameters.Add("@cierre1", SqlDbType.Decimal).Value = BE.cierre1;
                        cmd.Parameters.Add("@cierre2", SqlDbType.Decimal).Value = BE.cierre2;
                        cmd.Parameters.Add("@cerrado", SqlDbType.Bit).Value = BE.cerrado;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;

                        // Detalle
                        cmd.Parameters.AddWithValue("@DetalleImp", DatDetalle);          
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

        public bool UpdateApertura(string empresaid, tb_t1_caja BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbT1Caja_UPDATE_apertura", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = BE.fecha;
                        cmd.Parameters.Add("@apertura1", SqlDbType.Decimal).Value = BE.apertura1;
                        cmd.Parameters.Add("@apertura2", SqlDbType.Decimal).Value = BE.apertura2;
                        cmd.Parameters.Add("@cerrado", SqlDbType.Bit).Value = BE.cerrado;
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

        public DataSet DetalleActual(string empresaid, tb_t1_caja BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbT1Cajadet_SEARCH_ACT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = BE.fecha;
                        cmd.Parameters.Add("@filtro", SqlDbType.Char, 1).Value = BE.filtro;
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


        public bool Delete(string empresaid, tb_t1_caja BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbT1Tarjeta_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@tarjetaid", SqlDbType.Int).Value = BE.tarjetaid;
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

        public DataSet GetAllCab(string empresaid, tb_t1_caja BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbT1Cajacab_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char,4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char,3).Value = BE.local;
                        cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = BE.fecha;
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

        public DataSet GetAll2(string empresaid, tb_t1_caja BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbT1Tarjeta_SEARCH2", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@tarjetaid", SqlDbType.Int).Value = BE.tarjetaid;
                        //cmd.Parameters.Add("@tarjetaname", SqlDbType.VarChar, 50).Value = BE.tarjetaname;
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

        public DataSet GetAll_paginacion(string empresaid, tb_t1_caja BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbT1Cajacab_SEARCH_paginacion", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = BE.fecha;
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



    }
}
