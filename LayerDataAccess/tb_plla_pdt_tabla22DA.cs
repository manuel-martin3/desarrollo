using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_plla_pdt_tabla22DA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_plla_pdt_tabla22 BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPdtTabla22_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@rubroid", SqlDbType.Char, 4).Value = BE.rubroid;
                    cmd.Parameters.Add("@rubroname", SqlDbType.VarChar, 120).Value = BE.rubroname;
                    cmd.Parameters.Add("@eEssaRegu", SqlDbType.Bit).Value = BE.eEssaRegu;
                    cmd.Parameters.Add("@eEssaPesq", SqlDbType.Bit).Value = BE.eEssaPesq;
                    cmd.Parameters.Add("@eEssaAgra", SqlDbType.Bit).Value = BE.eEssaAgra;
                    cmd.Parameters.Add("@eEssaSctr", SqlDbType.Bit).Value = BE.eEssaSctr;
                    cmd.Parameters.Add("@eImpextsolid", SqlDbType.Bit).Value = BE.eImpextsolid;
                    cmd.Parameters.Add("@eFdsartista", SqlDbType.Bit).Value = BE.eFdsartista;
                    cmd.Parameters.Add("@eSenati", SqlDbType.Bit).Value = BE.eSenati;
                    cmd.Parameters.Add("@tSnp", SqlDbType.Bit).Value = BE.tSnp;
                    cmd.Parameters.Add("@tSpp", SqlDbType.Bit).Value = BE.tSpp;
                    cmd.Parameters.Add("@tRenta5", SqlDbType.Bit).Value = BE.tRenta5;
                    cmd.Parameters.Add("@pEssaRegu", SqlDbType.Bit).Value = BE.pEssaRegu;
                    cmd.Parameters.Add("@pEssaCprev", SqlDbType.Bit).Value = BE.pEssaCprev;
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public bool Update(string empresaid, tb_plla_pdt_tabla22 BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPdtTabla22_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@rubroid", SqlDbType.Char, 4).Value = BE.rubroid;
                        cmd.Parameters.Add("@rubroname", SqlDbType.VarChar, 120).Value = BE.rubroname;
                        cmd.Parameters.Add("@eEssaRegu", SqlDbType.Bit).Value = BE.eEssaRegu;
                        cmd.Parameters.Add("@eEssaPesq", SqlDbType.Bit).Value = BE.eEssaPesq;
                        cmd.Parameters.Add("@eEssaAgra", SqlDbType.Bit).Value = BE.eEssaAgra;
                        cmd.Parameters.Add("@eEssaSctr", SqlDbType.Bit).Value = BE.eEssaSctr;
                        cmd.Parameters.Add("@eImpextsolid", SqlDbType.Bit).Value = BE.eImpextsolid;
                        cmd.Parameters.Add("@eFdsartista", SqlDbType.Bit).Value = BE.eFdsartista;
                        cmd.Parameters.Add("@eSenati", SqlDbType.Bit).Value = BE.eSenati;
                        cmd.Parameters.Add("@tSnp", SqlDbType.Bit).Value = BE.tSnp;
                        cmd.Parameters.Add("@tSpp", SqlDbType.Bit).Value = BE.tSpp;
                        cmd.Parameters.Add("@tRenta5", SqlDbType.Bit).Value = BE.tRenta5;
                        cmd.Parameters.Add("@pEssaRegu", SqlDbType.Bit).Value = BE.pEssaRegu;
                        cmd.Parameters.Add("@pEssaCprev", SqlDbType.Bit).Value = BE.pEssaCprev;
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public bool Delete(string empresaid, tb_plla_pdt_tabla22 BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPdtTabla22_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@rubroid", SqlDbType.Char, 4).Value = BE.rubroid;
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public DataSet GetAll(string empresaid, tb_plla_pdt_tabla22 BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPdtTabla22_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@rubroid", SqlDbType.Char, 4).Value = BE.rubroid;
                        cmd.Parameters.Add("@rubroname", SqlDbType.VarChar, 120).Value = BE.rubroname;
                        //cmd.Parameters.Add("@eEssaRegu", SqlDbType.Bit).Value = BE.eEssaRegu;
                        //cmd.Parameters.Add("@eEssaPesq", SqlDbType.Bit).Value = BE.eEssaPesq;
                        //cmd.Parameters.Add("@eEssaAgra", SqlDbType.Bit).Value = BE.eEssaAgra;
                        //cmd.Parameters.Add("@eEssaSctr", SqlDbType.Bit).Value = BE.eEssaSctr;
                        //cmd.Parameters.Add("@eImpextsolid", SqlDbType.Bit).Value = BE.eImpextsolid;
                        //cmd.Parameters.Add("@eFdsartista", SqlDbType.Bit).Value = BE.eFdsartista;
                        //cmd.Parameters.Add("@eSenati", SqlDbType.Bit).Value = BE.eSenati;
                        //cmd.Parameters.Add("@tSnp", SqlDbType.Bit).Value = BE.tSnp;
                        //cmd.Parameters.Add("@tSpp", SqlDbType.Bit).Value = BE.tSpp;
                        //cmd.Parameters.Add("@tRenta5", SqlDbType.Bit).Value = BE.tRenta5;
                        //cmd.Parameters.Add("@pEssaRegu", SqlDbType.Bit).Value = BE.pEssaRegu;
                        //cmd.Parameters.Add("@pEssaCprev", SqlDbType.Bit).Value = BE.pEssaCprev;
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public DataSet GetAll_Consulta(string empresaid, tb_plla_pdt_tabla22 BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPdtTabla22_CONSULTA", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@rubroid", SqlDbType.Char, 4).Value = BE.rubroid;
                        cmd.Parameters.Add("@rubroidlikeleft", SqlDbType.VarChar, 4).Value = BE.rubroidlikeleft;
                        cmd.Parameters.Add("@relrubroidtipo", SqlDbType.VarChar, 100).Value = BE.relrubroidtipo;
                        cmd.Parameters.Add("@rubronamelike1", SqlDbType.VarChar, 120).Value = BE.rubronamelike1;
                        cmd.Parameters.Add("@rubronamelike2", SqlDbType.VarChar, 120).Value = BE.rubronamelike2;
                        cmd.Parameters.Add("@rubronamelike3", SqlDbType.VarChar, 120).Value = BE.rubronamelike3;
                        cmd.Parameters.Add("@detallado", SqlDbType.Int).Value = BE.detallado;
                        cmd.Parameters.Add("@norden", SqlDbType.Int).Value = BE.norden;
                        cmd.Parameters.Add("@incluir_blanco", SqlDbType.Int).Value = BE.incluir_blanco;
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public DataSet GetOne(string empresaid, string rubroid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPdtTabla22_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@rubroid", SqlDbType.Char, 4).Value = rubroid;
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
    }
}
