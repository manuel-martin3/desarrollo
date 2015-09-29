using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;


namespace LayerDataAccess
{
    public class tb_pt_tallaWebDA
    {
        ConexionWeb conex = new ConexionWeb();

        public bool Insert(string empresaid, tb_pt_talla BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtTalla_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tallaid", SqlDbType.Char, 2).Value = BE.tallaid;
                    cmd.Parameters.Add("@tallaname", SqlDbType.VarChar, 20).Value = BE.tallaname;
                    cmd.Parameters.Add("@talla01", SqlDbType.Char, 2).Value = BE.talla01;
                    cmd.Parameters.Add("@talla02", SqlDbType.Char, 2).Value = BE.talla02;
                    cmd.Parameters.Add("@talla03", SqlDbType.Char, 2).Value = BE.talla03;
                    cmd.Parameters.Add("@talla04", SqlDbType.Char, 2).Value = BE.talla04;
                    cmd.Parameters.Add("@talla05", SqlDbType.Char, 2).Value = BE.talla05;
                    cmd.Parameters.Add("@talla06", SqlDbType.Char, 2).Value = BE.talla06;
                    cmd.Parameters.Add("@talla07", SqlDbType.Char, 2).Value = BE.talla07;
                    cmd.Parameters.Add("@talla08", SqlDbType.Char, 2).Value = BE.talla08;
                    cmd.Parameters.Add("@talla09", SqlDbType.Char, 2).Value = BE.talla09;
                    cmd.Parameters.Add("@talla10", SqlDbType.Char, 2).Value = BE.talla10;
                    cmd.Parameters.Add("@talla11", SqlDbType.Char, 2).Value = BE.talla11;
                    cmd.Parameters.Add("@talla12", SqlDbType.Char, 2).Value = BE.talla12;
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

        public bool Update(string empresaid, tb_pt_talla BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtTalla_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tallaid", SqlDbType.Char, 2).Value = BE.tallaid;
                        cmd.Parameters.Add("@tallaname", SqlDbType.VarChar, 20).Value = BE.tallaname;
                        cmd.Parameters.Add("@talla01", SqlDbType.Char, 2).Value = BE.talla01;
                        cmd.Parameters.Add("@talla02", SqlDbType.Char, 2).Value = BE.talla02;
                        cmd.Parameters.Add("@talla03", SqlDbType.Char, 2).Value = BE.talla03;
                        cmd.Parameters.Add("@talla04", SqlDbType.Char, 2).Value = BE.talla04;
                        cmd.Parameters.Add("@talla05", SqlDbType.Char, 2).Value = BE.talla05;
                        cmd.Parameters.Add("@talla06", SqlDbType.Char, 2).Value = BE.talla06;
                        cmd.Parameters.Add("@talla07", SqlDbType.Char, 2).Value = BE.talla07;
                        cmd.Parameters.Add("@talla08", SqlDbType.Char, 2).Value = BE.talla08;
                        cmd.Parameters.Add("@talla09", SqlDbType.Char, 2).Value = BE.talla09;
                        cmd.Parameters.Add("@talla10", SqlDbType.Char, 2).Value = BE.talla10;
                        cmd.Parameters.Add("@talla11", SqlDbType.Char, 2).Value = BE.talla11;
                        cmd.Parameters.Add("@talla12", SqlDbType.Char, 2).Value = BE.talla12;
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

        public bool Delete(string empresaid, tb_pt_talla BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtTalla_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tallaid", SqlDbType.Char, 2).Value = BE.tallaid;
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

        public DataSet GetAll(string empresaid, tb_pt_talla BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtTalla_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tallaid", SqlDbType.Char, 2).Value = BE.tallaid;
                        cmd.Parameters.Add("@tallaname", SqlDbType.VarChar, 20).Value = BE.tallaname;
                        cmd.Parameters.Add("@talla01", SqlDbType.Char, 2).Value = BE.talla01;
                        cmd.Parameters.Add("@talla02", SqlDbType.Char, 2).Value = BE.talla02;
                        cmd.Parameters.Add("@talla03", SqlDbType.Char, 2).Value = BE.talla03;
                        cmd.Parameters.Add("@talla04", SqlDbType.Char, 2).Value = BE.talla04;
                        cmd.Parameters.Add("@talla05", SqlDbType.Char, 2).Value = BE.talla05;
                        cmd.Parameters.Add("@talla06", SqlDbType.Char, 2).Value = BE.talla06;
                        cmd.Parameters.Add("@talla07", SqlDbType.Char, 2).Value = BE.talla07;
                        cmd.Parameters.Add("@talla08", SqlDbType.Char, 2).Value = BE.talla08;
                        cmd.Parameters.Add("@talla09", SqlDbType.Char, 2).Value = BE.talla09;
                        cmd.Parameters.Add("@talla10", SqlDbType.Char, 2).Value = BE.talla10;
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

        public DataSet GetAll_paginacion(string empresaid, tb_pt_talla BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtTalla_SEARCH_paginacion", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tallaid", SqlDbType.Char, 2).Value = BE.tallaid;                       
                        cmd.Parameters.Add("@posicion", SqlDbType.Char, 10).Value = BE.posicion;
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

        public DataSet GetAll_vertical(string empresaid, tb_pt_talla BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtTalla_SEARCH_vertical_web", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
                        cmd.Parameters.Add("@colorid", SqlDbType.Char, 3).Value = BE.colorid;
                        cmd.Parameters.Add("@tallaid", SqlDbType.Char, 2).Value = BE.tallaid;
                        //cmd.Parameters.Add("@coltall", SqlDbType.Char, 2).Value = BE.coltall;
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

        public DataSet GetOne(string empresaid, string tallaid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtTalla_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tallaid", SqlDbType.Char, 2).Value = tallaid;
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
