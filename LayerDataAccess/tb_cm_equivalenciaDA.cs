using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using LayerBusinessEntities;

namespace LayerDataAccess
{
   public  class tb_cm_equivalenciaDA
    {
        ConexionDA conex = new ConexionDA();

        public List<tb_cm_equivalencia> Get_equivalencia(string empresaid, tb_cm_equivalencia BE)
       {
           using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
           {
               using (SqlCommand cmd = new SqlCommand("gspTbCmequivalencia_SEARCH", cnx))
               {
                   
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add("@Equiv_id", SqlDbType.Decimal,10).Value = BE.Equiv_id;

                   List<tb_cm_equivalencia> list = new List<tb_cm_equivalencia>().ToList();
                   try
                   {
                       cnx.Open();
                       using (SqlDataReader dr = cmd.ExecuteReader())
                       {
                           if (dr.Read())
                           {
                               tb_cm_equivalencia be  = new tb_cm_equivalencia();
                               be.Equivalencia = Convert.ToInt32(dr["equivalencia"]);
                               Int32 a = Convert.ToInt32(dr["equivalencia"]);
                               list.Add(be);
                                // return BE;
                           }
                          
                           return list;
                             
                       }
                       
                   }
                   catch (Exception ex)
                   {
                       throw new Exception(ex.Message);
                   }
               }
           }
       }

        public DataTable GetOne_Shear(string empresaid, Decimal BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCmequivalencia_SEARCH", cnx))
                {
                    DataTable ds = new DataTable();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Equiv_id", SqlDbType.Decimal, 10).Value = BE;
                   
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

        public bool Insert(string empresaid, tb_cm_equivalencia BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCmequivalencia__INSERT", cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@equiv_name", SqlDbType.VarChar, 50).Value = BE.Equiv_name;
                    cmd.Parameters.Add("@unmed1", SqlDbType.Char, 2).Value = BE.Unmed1;
                    cmd.Parameters.Add("@unmed2", SqlDbType.Char, 2).Value = BE.Unmed2;
                    cmd.Parameters.Add("@equivalencia", SqlDbType.Decimal, 10).Value = BE.Equivalencia;

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

        public bool Update(string empresaid, tb_cm_equivalencia BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCmequivalencia_UPDATE", cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@equiv_id", SqlDbType.Int).Value = BE.Equiv_id;
                    cmd.Parameters.Add("@equiv_name", SqlDbType.VarChar, 50).Value = BE.Equiv_name;
                    cmd.Parameters.Add("@unmed1", SqlDbType.Char, 2).Value = BE.Unmed1;
                    cmd.Parameters.Add("@unmed2", SqlDbType.Char, 2).Value = BE.Unmed2;
                    cmd.Parameters.Add("@equivalencia", SqlDbType.Decimal, 10).Value = BE.Equivalencia;

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

        public bool Delete(string empresaid, tb_cm_equivalencia BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCmequivalencia_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Equiv_id", SqlDbType.Char, 2).Value = BE.Equiv_id;
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

        public List<tb_cm_equivalencia> Get_xcodigo(string empresaid, tb_cm_equivalencia BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCmequivalencia_SEARCH", cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Equiv_id", BE.Equiv_id);
                    List<tb_cm_equivalencia> list = new List<tb_cm_equivalencia>();
                    try
                    {
                        cnx.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                tb_cm_equivalencia be = new tb_cm_equivalencia();

                                be.Equiv_id = Convert.ToInt32(dr["Equiv_id"]);
                                be.Equiv_name = Convert.ToString(dr["Equiv_name"]);
                                be.Equivalencia = Convert.ToDecimal(dr["equivalencia"]);
                                be.Unmed1 = Convert.ToString(dr["unmed1"]);
                                be.Unmed2 = Convert.ToString(dr["unmed2"]);

                                be.descripcion1 = Convert.ToString(dr["descripcion1"]);
                                be.descripcion2 = Convert.ToString(dr["descripcion2"]);

                                list.Add(be);
                            }
                            return list;
                        }

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
       
        public List<tb_cm_equivalencia> Get_all(string empresaid, tb_cm_equivalencia BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCmequivalencia_SEARCH", cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descripcion", BE.Equiv_name);
                    List<tb_cm_equivalencia> list = new List<tb_cm_equivalencia>();
                    try
                    {
                        cnx.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                tb_cm_equivalencia be = new tb_cm_equivalencia();
                                be.Equiv_id = Convert.ToInt32(dr["Equiv_id"]);
                                be.Equiv_name = Convert.ToString(dr["Equiv_name"]);
                                be.Unmed1 = Convert.ToString(dr["unmed1"]);
                                be.Unmed2 = Convert.ToString(dr["unmed2"]);
                                be.Equivalencia = Convert.ToDecimal(dr["equivalencia"]);
                                be.descripcion1 = Convert.ToString(dr["descripcion1"]);
                                be.descripcion2 = Convert.ToString(dr["descripcion2"]);
                                list.Add(be);
                            }
                            return list;
                        }

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
