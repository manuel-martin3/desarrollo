using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_cm_liquidacabDA
    {
        ConexionDA conex = new ConexionDA();

        public List<tb_cm_liquidacab> Get_equivalencia(string empresaid, tb_cm_liquidacab BE)
       {
           using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
           {
               using (SqlCommand cmd = new SqlCommand("gspTbCmequivalencia_SEARCH", cnx))
               {
                   
                   //cmd.CommandType = CommandType.StoredProcedure;
                   //cmd.Parameters.Add("@Equiv_id", SqlDbType.Decimal,10).Value = BE.Equiv_id;

                   List<tb_cm_liquidacab> list = new List<tb_cm_liquidacab>().ToList();
                   try
                   {
                       cnx.Open();
                       using (SqlDataReader dr = cmd.ExecuteReader())
                       {
                           if (dr.Read())
                           {
                               //tb_cm_liquidacab be  = new tb_cm_liquidacab();
                               //be.Equivalencia = Convert.ToInt32(dr["equivalencia"]);
                               //Int32 a = Convert.ToInt32(dr["equivalencia"]);
                               //list.Add(be);
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

        public bool Insert(string empresaid, tb_cm_liquidacab BE, DataTable DatDetalle)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCmLiquida_INSERT", cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    // Parametros de Cabecera
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                    cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                    cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                    cmd.Parameters.Add("@fecre", SqlDbType.DateTime).Value = BE.fecre;
                    cmd.Parameters.Add("@tot_bimp", SqlDbType.Decimal).Value = BE.tot_bimp;
                    cmd.Parameters.Add("@cif", SqlDbType.Decimal).Value = BE.cif;
                    cmd.Parameters.Add("@dua", SqlDbType.Decimal).Value = BE.dua;
                    cmd.Parameters.Add("@gas_impo", SqlDbType.Decimal).Value = BE.gas_impo;
                    cmd.Parameters.Add("@gas_financ", SqlDbType.Decimal).Value = BE.gas_financ;
                    cmd.Parameters.Add("@factorincre", SqlDbType.Decimal).Value = BE.factorincre;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;

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

        public bool Update(string empresaid, tb_cm_liquidacab BE, DataTable DatDetalle)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCmLiquida_UPDATE", cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parametros de Cabecera
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                    cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                    cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                    cmd.Parameters.Add("@fecre", SqlDbType.DateTime).Value = BE.fecre;
                    cmd.Parameters.Add("@tot_bimp", SqlDbType.Decimal).Value = BE.tot_bimp;
                    cmd.Parameters.Add("@cif", SqlDbType.Decimal).Value = BE.cif;
                    cmd.Parameters.Add("@dua", SqlDbType.Decimal).Value = BE.dua;
                    cmd.Parameters.Add("@gas_impo", SqlDbType.Decimal).Value = BE.gas_impo;
                    cmd.Parameters.Add("@gas_financ", SqlDbType.Decimal).Value = BE.gas_financ;
                    cmd.Parameters.Add("@factorincre", SqlDbType.Decimal).Value = BE.factorincre;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;

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

        public bool Delete(string empresaid, tb_cm_liquidacab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCmequivalencia_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@Equiv_id", SqlDbType.Char, 2).Value = BE.Equiv_id;
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

        public DataSet GetAll_paginacion(string empresaid, tb_cm_liquidacab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCmLiquidacab_SEARCH_paginacion", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
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

        public List<tb_cm_liquidacab> Get_xcodigo(string empresaid, tb_cm_liquidacab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCmequivalencia_SEARCH", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@Equiv_id", BE.Equiv_id);
                    List<tb_cm_liquidacab> list = new List<tb_cm_liquidacab>();
                    try
                    {
                        cnx.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                tb_cm_liquidacab be = new tb_cm_liquidacab();

                                //be.Equiv_id = Convert.ToInt32(dr["Equiv_id"]);
                                //be.Equiv_name = Convert.ToString(dr["Equiv_name"]);
                                //be.Equivalencia = Convert.ToDecimal(dr["equivalencia"]);
                                //be.Unmed1 = Convert.ToString(dr["unmed1"]);
                                //be.Unmed2 = Convert.ToString(dr["unmed2"]);

                                //be.descripcion1 = Convert.ToString(dr["descripcion1"]);
                                //be.descripcion2 = Convert.ToString(dr["descripcion2"]);

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
       
        public List<tb_cm_liquidacab> Get_all(string empresaid, tb_cm_liquidacab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCmequivalencia_SEARCH", cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@descripcion", BE.Equiv_name);
                    List<tb_cm_liquidacab> list = new List<tb_cm_liquidacab>();
                    try
                    {
                        cnx.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                tb_cm_liquidacab be = new tb_cm_liquidacab();
                                //be.Equiv_id = Convert.ToInt32(dr["Equiv_id"]);
                                //be.Equiv_name = Convert.ToString(dr["Equiv_name"]);
                                //be.Unmed1 = Convert.ToString(dr["unmed1"]);
                                //be.Unmed2 = Convert.ToString(dr["unmed2"]);
                                //be.Equivalencia = Convert.ToDecimal(dr["equivalencia"]);
                                //be.descripcion1 = Convert.ToString(dr["descripcion1"]);
                                //be.descripcion2 = Convert.ToString(dr["descripcion2"]);
                                //list.Add(be);
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
