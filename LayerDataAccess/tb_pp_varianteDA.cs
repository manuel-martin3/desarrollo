using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_pp_varianteDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_pp_variante  BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPpVariante_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@variante", SqlDbType.Char, 6).Value = BE.variante;
                    cmd.Parameters.Add("@codtizado", SqlDbType.Char, 8).Value = BE.codtizado;
                    cmd.Parameters.Add("@variantename", SqlDbType.VarChar, 50).Value = BE.variantename;
                    cmd.Parameters.Add("@categoriaid", SqlDbType.Char, 2).Value = BE.categoriaid;
                    cmd.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE.marcaid;
                    cmd.Parameters.Add("@lineaid", SqlDbType.Char, 2).Value = BE.lineaid;                    
                    cmd.Parameters.Add("@generoid", SqlDbType.Char, 1).Value = BE.generoid;
                    cmd.Parameters.Add("@tejidoid", SqlDbType.Char, 2).Value = BE.tejidoid;
                    cmd.Parameters.Add("@familiatelaid", SqlDbType.Char, 3).Value = BE.familiatelaid;
                    cmd.Parameters.Add("@botapieid", SqlDbType.Char, 2).Value = BE.botapieid;
                    cmd.Parameters.Add("@entalleid", SqlDbType.Char, 2).Value = BE.entalleid;
                    cmd.Parameters.Add("@modeloid", SqlDbType.Char, 4).Value = BE.modeloid;
                    cmd.Parameters.Add("@parteid", SqlDbType.Char, 1).Value = BE.parteid;
                    cmd.Parameters.Add("@aprobado", SqlDbType.Bit).Value = BE.aprobado;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;                    
                    cmd.Parameters.Add("@disenadorid", SqlDbType.Char, 4).Value = BE.diseñadorid;
                    cmd.Parameters.Add("@fechprese", SqlDbType.DateTime).Value = BE.fechprese;
                    cmd.Parameters.Add("@fechaprob", SqlDbType.DateTime).Value = BE.fechaprob;
                    cmd.Parameters.Add("@tippy", SqlDbType.Char, 2).Value = BE.tippy;
                    cmd.Parameters.Add("@serpy", SqlDbType.Char, 4).Value = BE.serppy;
                    cmd.Parameters.Add("@numpy", SqlDbType.Char, 10).Value = BE.numppy;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
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

        public bool Update(string empresaid, tb_pp_variante BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPpVariante_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@variante", SqlDbType.Char, 6).Value = BE.variante;
                        cmd.Parameters.Add("@codtizado", SqlDbType.Char, 8).Value = BE.codtizado;
                        cmd.Parameters.Add("@variantename", SqlDbType.VarChar, 50).Value = BE.variantename;
                        cmd.Parameters.Add("@categoriaid", SqlDbType.Char, 2).Value = BE.categoriaid;
                        cmd.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE.marcaid;
                        cmd.Parameters.Add("@lineaid", SqlDbType.Char, 2).Value = BE.lineaid;
                        cmd.Parameters.Add("@generoid", SqlDbType.Char, 1).Value = BE.generoid;
                        cmd.Parameters.Add("@tejidoid", SqlDbType.Char, 2).Value = BE.tejidoid;
                        cmd.Parameters.Add("@familiatelaid", SqlDbType.Char, 3).Value = BE.familiatelaid;
                        cmd.Parameters.Add("@botapieid", SqlDbType.Char, 2).Value = BE.botapieid;
                        cmd.Parameters.Add("@entalleid", SqlDbType.Char, 2).Value = BE.entalleid;
                        cmd.Parameters.Add("@modeloid", SqlDbType.Char, 4).Value = BE.modeloid;
                        cmd.Parameters.Add("@parteid", SqlDbType.Char, 1).Value = BE.parteid;
                        cmd.Parameters.Add("@aprobado", SqlDbType.Bit).Value = BE.aprobado;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@disenadorid", SqlDbType.Char, 4).Value = BE.diseñadorid;
                        cmd.Parameters.Add("@fechprese", SqlDbType.DateTime).Value = BE.fechprese;
                        cmd.Parameters.Add("@fechaprob", SqlDbType.DateTime).Value = BE.fechaprob;
                        cmd.Parameters.Add("@tippy", SqlDbType.Char, 2).Value = BE.tippy;
                        cmd.Parameters.Add("@serpy", SqlDbType.Char, 4).Value = BE.serppy;
                        cmd.Parameters.Add("@numpy", SqlDbType.Char, 10).Value = BE.numppy;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
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

        public bool Delete(string empresaid, tb_pp_variante BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPpVariante_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@variante", SqlDbType.Char, 6).Value = BE.variante;
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

        public DataSet GetAll(string empresaid, tb_pp_variante BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPpVariante_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@variante", SqlDbType.Char, 6).Value = BE.variante;
                        cmd.Parameters.Add("@codtizado", SqlDbType.Char, 8).Value = BE.codtizado;
                        cmd.Parameters.Add("@variantename", SqlDbType.VarChar, 50).Value = BE.variantename;                 
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

        public DataSet GeneraCod(string empresaid, tb_pp_variante BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPpVariante_GEN_Codigo", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE.marcaid;                      
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

        public DataSet GetOne(string empresaid, string articid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtArticulo_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = articid;
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

        public bool Insert_Foto(string empresaid, tb_pp_variante BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtArticulo_INSERT_foto", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("@articidold", SqlDbType.Char, 8).Value = BE.articidold;
                    //cmd.Parameters.Add("@docname", SqlDbType.VarChar, 100).Value = BE.docname;
                    //cmd.Parameters.Add("@foto", SqlDbType.Image).Value = BE.Foto;

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

        public bool Update_foto(string empresaid, tb_pp_variante BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtArticulo_UPDATE_foto", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@articidold", SqlDbType.Char, 8).Value = BE.articidold;
                        //cmd.Parameters.Add("@docname", SqlDbType.VarChar, 100).Value = BE.docname;
                        //cmd.Parameters.Add("@foto", SqlDbType.Image).Value = BE.Foto;
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

        public DataSet GetAll_foto(string empresaid, tb_pp_variante BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtArticulo_SEARCH_foto", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@articidold", SqlDbType.Char, 8).Value = BE.articidold;
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
