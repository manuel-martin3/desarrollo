using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_me_listaprecioscabDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_me_listaprecioscab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMeListaprecioscab_INSERT", cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;                 
                    cmd.Parameters.Add("@listaprecname", SqlDbType.Char, 50).Value = BE.listaprecname;
                    cmd.Parameters.Add("@fechaini", SqlDbType.DateTime).Value = BE.fechaini;
                    cmd.Parameters.Add("@fechafin", SqlDbType.DateTime).Value = BE.fechafin;
                    cmd.Parameters.Add("@tiendalist", SqlDbType.Int).Value = BE.tiendalist;
                    cmd.Parameters.Add("@ctactelist", SqlDbType.Int).Value = BE.ctactelist;                    
                    cmd.Parameters.Add("@tcamb", SqlDbType.Decimal).Value = BE.tcamb;
                    cmd.Parameters.Add("@incigv", SqlDbType.Bit).Value = BE.incigv;
                    cmd.Parameters.Add("@visible", SqlDbType.Bit).Value = BE.visible;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    

                    //cmd.Parameters.Add("@XML", SqlDbType.Xml).Value = BE.GetItemXML();

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

        public bool Update(string empresaid, tb_me_listaprecioscab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMeListaprecioscab_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@listaprecid", SqlDbType.Int).Value = BE.listaprecid;
                        cmd.Parameters.Add("@listaprecname", SqlDbType.Char, 50).Value = BE.listaprecname;
                        cmd.Parameters.Add("@fechaini", SqlDbType.DateTime).Value = BE.fechaini;
                        cmd.Parameters.Add("@fechafin", SqlDbType.DateTime).Value = BE.fechafin;
                        cmd.Parameters.Add("@tiendalist", SqlDbType.Int).Value = BE.tiendalist;
                        cmd.Parameters.Add("@ctactelist", SqlDbType.Int).Value = BE.ctactelist;
                        cmd.Parameters.Add("@tcamb", SqlDbType.Decimal).Value = BE.tcamb;
                        cmd.Parameters.Add("@incigv", SqlDbType.Bit).Value = BE.incigv;
                        cmd.Parameters.Add("@visible", SqlDbType.Bit).Value = BE.visible;
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

        public bool Delete(string empresaid, tb_me_listaprecioscab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMeListaprecioscab_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@listaprecid", SqlDbType.Int).Value = BE.listaprecid;
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

        public DataSet GetAll(string empresaid, tb_me_listaprecioscab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMeListaprecioscab_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@listaprecid", SqlDbType.Int).Value = BE.listaprecid;
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

        public DataSet GetVigentes(string empresaid, tb_me_listaprecioscab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMeListaPreciosCab_SEARCH_Vigente", cnx))
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

        public DataSet FiltroProducto(string empresaid, tb_me_listaprecioscab BE)
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

        public DataSet GetAll_paginacion(string empresaid, tb_me_listaprecioscab BE)
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

        public DataSet GetAll_datosdetalle(string empresaid, tb_me_listaprecioscab BE)
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
