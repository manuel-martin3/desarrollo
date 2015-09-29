using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;


namespace LayerDataAccess
{
    public class tb_me_proyeccionDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_me_proyeccion BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMeProyeccion_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.anio;
                    cmd.Parameters.Add("@temporadaid", SqlDbType.Char, 1).Value = BE.temporadaid;
                    cmd.Parameters.Add("@canalventaid", SqlDbType.Char, 3).Value = BE.canalventaid;
                    cmd.Parameters.Add("@cantmod01", SqlDbType.Int).Value = BE.cantmod01;
                    cmd.Parameters.Add("@cantmod02", SqlDbType.Int).Value = BE.cantmod02;
                    cmd.Parameters.Add("@cantmod03", SqlDbType.Int).Value = BE.cantmod03;
                    cmd.Parameters.Add("@cantmod04", SqlDbType.Int).Value = BE.cantmod04;
                    cmd.Parameters.Add("@cantmod05", SqlDbType.Int).Value = BE.cantmod05;
                    cmd.Parameters.Add("@cantmod06", SqlDbType.Int).Value = BE.cantmod06;
                    cmd.Parameters.Add("@canttotal", SqlDbType.BigInt).Value = BE.canttotal;
                    cmd.Parameters.Add("@totalprendas", SqlDbType.BigInt).Value = BE.totalprendas;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 2).Value = BE.status;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
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

        public bool Update(string empresaid, tb_me_proyeccion BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMeProyeccion_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.anio;
                        cmd.Parameters.Add("@temporadaid", SqlDbType.Char, 1).Value = BE.temporadaid;
                        cmd.Parameters.Add("@canalventaid", SqlDbType.Char, 3).Value = BE.canalventaid;
                        cmd.Parameters.Add("@cantmod01", SqlDbType.Int).Value = BE.cantmod01;
                        cmd.Parameters.Add("@cantmod02", SqlDbType.Int).Value = BE.cantmod02;
                        cmd.Parameters.Add("@cantmod03", SqlDbType.Int).Value = BE.cantmod03;
                        cmd.Parameters.Add("@cantmod04", SqlDbType.Int).Value = BE.cantmod04;
                        cmd.Parameters.Add("@cantmod05", SqlDbType.Int).Value = BE.cantmod05;
                        cmd.Parameters.Add("@cantmod06", SqlDbType.Int).Value = BE.cantmod06;
                        cmd.Parameters.Add("@canttotal", SqlDbType.BigInt).Value = BE.canttotal;
                        cmd.Parameters.Add("@totalprendas", SqlDbType.BigInt).Value = BE.totalprendas;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 2).Value = BE.status;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                        cmd.Parameters.Add("@XML", SqlDbType.Xml).Value = BE.GetItemXML();
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

        public bool Delete(string empresaid, tb_me_proyeccion BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMeProyeccion_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perinanio", SqlDbType.Char, 4).Value = BE.anio;
                        cmd.Parameters.Add("@temporadaid", SqlDbType.Char, 1).Value = BE.temporadaid;
                        cmd.Parameters.Add("@canalventaid", SqlDbType.Char, 3).Value = BE.canalventaid;
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

        public DataSet GetAll(string empresaid, tb_me_proyeccion BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMeProyeccion_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.anio;
                        cmd.Parameters.Add("@temporadaid", SqlDbType.Char, 1).Value = BE.temporadaid;
                        cmd.Parameters.Add("@canalventaid", SqlDbType.Char, 3).Value = BE.canalventaid;
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

        public DataSet GetAll_DET(string empresaid, tb_me_proyeccion BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMeProyeccion_SEARCH_DET", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.anio;
                        cmd.Parameters.Add("@temporadaid", SqlDbType.Char, 1).Value = BE.temporadaid;
                        cmd.Parameters.Add("@canalventaid", SqlDbType.Char, 3).Value = BE.canalventaid;                     
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

        public DataSet GetOne(string empresaid, string colorid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMeProyeccion_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@", SqlDbType.Char, 3).Value = colorid;
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
