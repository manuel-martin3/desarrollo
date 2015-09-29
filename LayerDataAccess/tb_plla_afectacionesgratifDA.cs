using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_plla_afectacionesgratifDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_plla_afectacionesgratif BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaafectacionesGratif_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd.Parameters.Add("@rubroid", SqlDbType.Char, 3).Value = BE.rubroid;
                    cmd.Parameters.Add("@afecto", SqlDbType.Decimal).Value = BE.afecto;
                    cmd.Parameters.Add("@status", SqlDbType.Decimal).Value = BE.status;
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
        public bool Insert_Update(string empresaid, tb_plla_afectacionesgratif BE, DataTable TablaDatos)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                bool xreturn = true;
                int lcont = 0;
                using (SqlCommand cmd = new SqlCommand("gspTbPllaafectacionesGratif_Eliminar", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
                    try
                    {
                        cnx.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            xreturn = true;
                        }
                        else
                        {
                            xreturn = false;
                        }
                        cnx.Close();
                    }
                    catch (Exception ex)
                    {
                        Sql_Error = ex.Message;
                        //throw new Exception(ex.Message);
                        xreturn = false;
                        cnx.Close();
                    }
                }
                for (lcont = 0; lcont <= TablaDatos.Rows.Count - 1; lcont++)
                {
                    using (SqlCommand cmd = new SqlCommand("gspTbPllaafectacionesGratif_InsertUpdate", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = TablaDatos.Rows[lcont]["tipoplla"];
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = TablaDatos.Rows[lcont]["perianio"];
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = TablaDatos.Rows[lcont]["perimes"];
                        cmd.Parameters.Add("@rubroid", SqlDbType.Char, 3).Value = TablaDatos.Rows[lcont]["rubroid"];
                        cmd.Parameters.Add("@afecto", SqlDbType.Decimal).Value = TablaDatos.Rows[lcont]["afecto"];
                        cmd.Parameters.Add("@status", SqlDbType.Decimal).Value = TablaDatos.Rows[lcont]["status"];
                        try
                        {
                            cnx.Open();
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                xreturn = true;
                            }
                            else
                            {
                                xreturn = false;
                            }
                            cnx.Close();
                        }
                        catch (Exception ex)
                        {
                            Sql_Error = ex.Message;
                            //throw new Exception(ex.Message);
                            xreturn = false;
                            cnx.Close();
                        }
                    }
                }
                return xreturn;
            }
        }

        public bool Update(string empresaid, tb_plla_afectacionesgratif BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaafectacionesGratif_UPDATE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@rubroid", SqlDbType.Char, 3).Value = BE.rubroid;
                        cmd.Parameters.Add("@afecto", SqlDbType.Decimal).Value = BE.afecto;
                        cmd.Parameters.Add("@status", SqlDbType.Decimal).Value = BE.status;
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
        public bool Copiar(string empresaid, tb_plla_afectacionesgratif BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRubrosingreso_CopiarRubros", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipoplanillaorigen", SqlDbType.Char, 1).Value = BE.tipoplanillaorigen;
                        cmd.Parameters.Add("@tipoplanilladestino", SqlDbType.Char, 1).Value = BE.tipoplanilladestino;
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
        public bool Delete(string empresaid, tb_plla_afectacionesgratif BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaafectacionesGratif_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
                        cmd.Parameters.Add("@rubroid", SqlDbType.Char, 3).Value = BE.rubroid;
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
        public bool Eliminar(string empresaid, DataTable TablaDatos)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                bool xreturn = true;
                int lcont = 0;
                for (lcont = 0; lcont <= TablaDatos.Rows.Count - 1; lcont++)
                {
                    using (SqlCommand cmd = new SqlCommand("gspTbPllaafectacionesGratif_DELETE", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = TablaDatos.Rows[lcont]["tipoplla"];
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = TablaDatos.Rows[lcont]["perimes"];
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = TablaDatos.Rows[lcont]["tipoplla"];
                        cmd.Parameters.Add("@rubroid", SqlDbType.Char, 3).Value = TablaDatos.Rows[lcont]["rubroid"];
                        try
                        {
                            cnx.Open();
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                xreturn = true;
                            }
                            else
                            {
                                xreturn = false;
                            }
                            cnx.Close();
                        }
                        catch (Exception ex)
                        {
                            Sql_Error = ex.Message;
                            //throw new Exception(ex.Message);
                            xreturn = false;
                            cnx.Close();
                        }
                    }
                }
                return xreturn;
            }
        }

        public DataSet GetAll(string empresaid, tb_plla_afectacionesgratif BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaafectacionesGratif_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@rubroid", SqlDbType.Char, 3).Value = BE.rubroid;
                        //cmd.Parameters.Add("@afecto", SqlDbType.Decimal).Value = BE.afecto;
                        //cmd.Parameters.Add("@status", SqlDbType.Decimal).Value = BE.status;
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

        public DataSet GetAll_CONSULTA(string empresaid, tb_plla_afectacionesgratif BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaafectacionesGratif_CONSULTA", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
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
        public DataSet GetAll_CONSULTA1(string empresaid, tb_plla_afectacionesgratif BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaafectacionesGratif_CONSULTA1", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@rubroid", SqlDbType.Char, 3).Value = BE.rubroid;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
                        cmd.Parameters.Add("@descriplike1", SqlDbType.VarChar, 60).Value = BE.descriplike1;
                        cmd.Parameters.Add("@descriplike2", SqlDbType.VarChar, 60).Value = BE.descriplike2;
                        cmd.Parameters.Add("@descriplike3", SqlDbType.VarChar, 60).Value = BE.descriplike3;
                        cmd.Parameters.Add("@norden", SqlDbType.Int).Value = BE.norden;
                        cmd.Parameters.Add("@incluir_blanco", SqlDbType.Int).Value = BE.incluir_blanco;
                        cmd.Parameters.Add("@nestado", SqlDbType.Int).Value = BE.nestado;
                        cmd.Parameters.Add("@descartarrubros", SqlDbType.VarChar, 50).Value = BE.descartarrubros;
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

        public DataSet GetOne(string empresaid, tb_plla_afectacionesgratif BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaafectacionesGratif_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
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
