using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class perfilitemsDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_perfilitems BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPerfilitems_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idper", SqlDbType.Char, 9).Value = BE.idper;
                    cmd.Parameters.Add("@plataforma", SqlDbType.Char, 1).Value = BE.plataforma;
                    cmd.Parameters.Add("@menid", SqlDbType.Int).Value = BE.menid;
                    cmd.Parameters.Add("@padid", SqlDbType.Int).Value = BE.padid;
                    cmd.Parameters.Add("@posic", SqlDbType.Int).Value = BE.posic;
                    cmd.Parameters.Add("@descr", SqlDbType.VarChar, 100).Value = BE.descr;
                    cmd.Parameters.Add("@icono", SqlDbType.VarChar, 100).Value = BE.icono;
                    cmd.Parameters.Add("@habil", SqlDbType.Bit).Value = BE.habil;
                    cmd.Parameters.Add("@pgurl", SqlDbType.VarChar, 100).Value = BE.pgurl;
                    cmd.Parameters.Add("@nivelacc", SqlDbType.Char, 5).Value = BE.nivelacc;
                    cmd.Parameters.Add("@dominioid", SqlDbType.Char, 2).Value = BE.dominioid;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;

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
        public bool Insert_xml(string empresaid, tb_perfilitems BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPerfilitems_INSERT_xml", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idper", SqlDbType.Char, 9).Value = BE.idper;
                    cmd.Parameters.Add("@plataforma", SqlDbType.Char, 1).Value = BE.plataforma;
                    cmd.Parameters.Add("@menid", SqlDbType.Int).Value = BE.menid;
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

        public bool Update(string empresaid, tb_perfilitems BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPerfilitems_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@idper", SqlDbType.Char, 9).Value = BE.idper;
                        cmd.Parameters.Add("@plataforma", SqlDbType.Char, 1).Value = BE.plataforma;
                        cmd.Parameters.Add("@menid", SqlDbType.Int).Value = BE.menid;
                        cmd.Parameters.Add("@padid", SqlDbType.Int).Value = BE.padid;
                        cmd.Parameters.Add("@posic", SqlDbType.Int).Value = BE.posic;
                        cmd.Parameters.Add("@descr", SqlDbType.VarChar, 100).Value = BE.descr;
                        cmd.Parameters.Add("@icono", SqlDbType.VarChar, 100).Value = BE.icono;
                        cmd.Parameters.Add("@habil", SqlDbType.Bit).Value = BE.habil;
                        cmd.Parameters.Add("@pgurl", SqlDbType.VarChar, 100).Value = BE.pgurl;
                        cmd.Parameters.Add("@nivelacc", SqlDbType.Char, 5).Value = BE.nivelacc;
                        cmd.Parameters.Add("@dominioid", SqlDbType.Char, 2).Value = BE.dominioid;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
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
        public bool Update_propied(string empresaid, tb_perfilitems BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPerfilitems_UPDATE_propied", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@idper", SqlDbType.Char, 9).Value = BE.idper;
                        cmd.Parameters.Add("@plataforma", SqlDbType.Char, 1).Value = BE.plataforma;
                        cmd.Parameters.Add("@menid", SqlDbType.Int).Value = BE.menid;
                        cmd.Parameters.Add("@padid", SqlDbType.Int).Value = BE.padid;
                        cmd.Parameters.Add("@posic", SqlDbType.Int).Value = BE.posic;
                        cmd.Parameters.Add("@descr", SqlDbType.VarChar, 100).Value = BE.descr;
                        cmd.Parameters.Add("@icono", SqlDbType.VarChar, 100).Value = BE.icono;
                        cmd.Parameters.Add("@habil", SqlDbType.Bit).Value = BE.habil;
                        cmd.Parameters.Add("@pgurl", SqlDbType.VarChar, 100).Value = BE.pgurl;
                        cmd.Parameters.Add("@nivelacc", SqlDbType.Char, 5).Value = BE.nivelacc;
                        cmd.Parameters.Add("@dominioid", SqlDbType.Char, 2).Value = BE.dominioid;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
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
        public bool Update_xml(string empresaid, tb_perfilitems BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPerfilitems_UPDATE_xml", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idper", SqlDbType.Char, 9).Value = BE.idper;
                    cmd.Parameters.Add("@plataforma", SqlDbType.Char, 1).Value = BE.plataforma;
                    cmd.Parameters.Add("@menid", SqlDbType.Int).Value = BE.menid;
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

        public bool Delete(string empresaid, tb_perfilitems BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPerfilitems_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@idper", SqlDbType.Char, 9).Value = BE.idper;
                        cmd.Parameters.Add("@plataforma", SqlDbType.Char, 1).Value = BE.plataforma;
                        cmd.Parameters.Add("@menid", SqlDbType.Int).Value = BE.menid;
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

        public DataSet GetAll(string empresaid, tb_perfilitems BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPerfilitems_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@idper", SqlDbType.Char, 9).Value = BE.idper;
                        cmd.Parameters.Add("@plataforma", SqlDbType.Char, 1).Value = BE.plataforma;
                        cmd.Parameters.Add("@menid", SqlDbType.Int).Value = BE.menid;
                        //cmd.Parameters.Add("@padid", SqlDbType.Int).Value = BE.padid;
                        //cmd.Parameters.Add("@posic", SqlDbType.Int).Value = BE.posic;
                        cmd.Parameters.Add("@descr", SqlDbType.VarChar, 100).Value = BE.descr;
                        cmd.Parameters.Add("@icono", SqlDbType.VarChar, 100).Value = BE.icono;
                        //cmd.Parameters.Add("@habil", SqlDbType.Bit).Value = BE.habil;
                        cmd.Parameters.Add("@pgurl", SqlDbType.VarChar, 100).Value = BE.pgurl;
                        cmd.Parameters.Add("@nivelacc", SqlDbType.Char, 5).Value = BE.nivelacc;
                        cmd.Parameters.Add("@dominioid", SqlDbType.Char, 2).Value = BE.dominioid;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
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

        public DataSet GetAll_actives(string empresaid, tb_perfilitems BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPerfilitems_SEARCH_actives", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@idper", SqlDbType.Char, 9).Value = BE.idper;
                        cmd.Parameters.Add("@plataforma", SqlDbType.Char, 1).Value = BE.plataforma;
                        cmd.Parameters.Add("@menid", SqlDbType.Int).Value = BE.menid;
                        cmd.Parameters.Add("@descr", SqlDbType.VarChar, 100).Value = BE.descr;
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

        public DataSet GetOne(string empresaid, tb_perfilitems BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPerfilitems_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@idper", SqlDbType.Char, 9).Value = BE.idper;
                        cmd.Parameters.Add("@plataforma", SqlDbType.Char, 1).Value = BE.plataforma;
                        cmd.Parameters.Add("@menid", SqlDbType.Int).Value = BE.menid;
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

        public DataSet GetAll_nivel_acceso(string empresaid, tb_perfilitems BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPerfilitems_SEARCH_nivel_acceso", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@idper", SqlDbType.Char, 9).Value = BE.idper;
                        cmd.Parameters.Add("@pgurl", SqlDbType.VarChar, 100).Value = BE.pgurl;
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

        public DataSet GetAll_nivel_acceso2(string empresaid, tb_perfilitems BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPerfilitems_SEARCH_nivel_acceso2", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@idper", SqlDbType.Char, 9).Value = BE.idper;
                        cmd.Parameters.Add("@pgurl", SqlDbType.VarChar, 100).Value = BE.pgurl;
                        cmd.Parameters.Add("@grupo", SqlDbType.Int).Value = BE.grupo;
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
