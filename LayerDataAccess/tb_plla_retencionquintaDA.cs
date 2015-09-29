using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_plla_retencionquintaDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_plla_retencionquinta BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRetencionQuinta_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = BE.perianio;
                    cmd.Parameters.Add("@fichaid", SqlDbType.Char).Value = BE.fichaid;
                    cmd.Parameters.Add("@retmensual", SqlDbType.Decimal).Value = BE.retmensual;
                    cmd.Parameters.Add("@salxretener", SqlDbType.Decimal).Value = BE.salxretener;
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
        public bool Insert_Update(string empresaid, tb_plla_retencionquinta BE, DataTable TablaDatos)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                bool xreturn = true;
                int lcont = 0;
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRetencionQuinta_Eliminar", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = BE.perianio;
                    cmd.Parameters.Add("@fichaid", SqlDbType.Char).Value = BE.fichaid;
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
                    using (SqlCommand cmd = new SqlCommand("gspTbPllaRetencionQuinta_InsertUpdate", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = TablaDatos.Rows[lcont]["perianio"];
                        cmd.Parameters.Add("@fichaid", SqlDbType.Char).Value = TablaDatos.Rows[lcont]["fichaid"];
                        cmd.Parameters.Add("@retmensual", SqlDbType.Decimal).Value = TablaDatos.Rows[lcont]["retmensual"];
                        cmd.Parameters.Add("@salxretener", SqlDbType.Decimal).Value = TablaDatos.Rows[lcont]["salxretener"];
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

        public bool Update(string empresaid, tb_plla_retencionquinta BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRetencionQuinta_UPDATE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = BE.perianio;
                        cmd.Parameters.Add("@fichaid", SqlDbType.Char).Value = BE.fichaid;
                        cmd.Parameters.Add("@retmensual", SqlDbType.Decimal).Value = BE.retmensual;
                        cmd.Parameters.Add("@salxretener", SqlDbType.Decimal).Value = BE.salxretener;
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
        
        public bool Delete(string empresaid, tb_plla_retencionquinta BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRetencionQuinta_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = BE.perianio;
                        cmd.Parameters.Add("@fichaid", SqlDbType.Char).Value = BE.fichaid;
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
                    using (SqlCommand cmd = new SqlCommand("gspTbPllaRetencionQuinta_DELETE", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = TablaDatos.Rows[lcont]["tipoplla"];
                        cmd.Parameters.Add("@fichaid", SqlDbType.Char).Value = TablaDatos.Rows[lcont]["fichaid"];
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

        public DataSet CalcularRta5ta(string empresaid, tb_plla_retencionquinta BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRetencionQuinta_CalcularRta5ta", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                        cmd.Parameters.AddWithValue("@fichaini", string.IsNullOrEmpty(BE.fichaini) ? (object)DBNull.Value : BE.fichaini);
                        cmd.Parameters.AddWithValue("@fichafin", string.IsNullOrEmpty(BE.fichafin) ? (object)DBNull.Value : BE.fichafin);
                        cmd.Parameters.Add("@ntipo", SqlDbType.Int).Value = BE.ntipo;
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

        public DataSet GetAll(string empresaid, tb_plla_retencionquinta BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRetencionQuinta_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = BE.perianio;
                        cmd.Parameters.Add("@fichaid", SqlDbType.Char).Value = BE.fichaid;
                        //cmd.Parameters.Add("@retmensual", SqlDbType.Decimal).Value = BE.retmensual;
                        //cmd.Parameters.Add("@salxretener", SqlDbType.Decimal).Value = BE.salxretener;
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

        public DataSet GetAll_CONSULTA(string empresaid, tb_plla_retencionquinta BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRetencionQuinta_CONSULTA", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = BE.perianio;
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

        public DataSet GetAll_IR(string empresaid, tb_plla_retencionquinta BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRubrosingreso_IR", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@rubroid", SqlDbType.Char, 4).Value = BE.rubroid;
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

        public DataSet GetOne(string empresaid, tb_plla_retencionquinta BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRetencionQuinta_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = BE.perianio;
                        cmd.Parameters.Add("@fichaid", SqlDbType.Char).Value = BE.fichaid;
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
