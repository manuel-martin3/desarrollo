using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_plla_rubrosdescuentosDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_plla_rubrosdescuentos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRubrosdescuentos_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
                    cmd.Parameters.Add("@rubroid", SqlDbType.Char, 3).Value = BE.rubroid;
                    cmd.Parameters.Add("@rubroname", SqlDbType.VarChar, 60).Value = BE.rubroname;
                    cmd.Parameters.Add("@tiporubro", SqlDbType.Char, 3).Value = BE.tiporubro;
                    cmd.Parameters.Add("@visible", SqlDbType.Bit).Value = BE.visible;
                    cmd.Parameters.Add("@edita", SqlDbType.Bit).Value = BE.edita;
                    cmd.Parameters.Add("@modalidad", SqlDbType.Char, 2).Value = BE.modalidad;
                    cmd.Parameters.Add("@redondeo", SqlDbType.Decimal).Value = BE.redondeo;
                    cmd.Parameters.Add("@montofijo", SqlDbType.Decimal).Value = BE.montofijo;
                    cmd.Parameters.Add("@tipocalculo", SqlDbType.Char, 2).Value = BE.tipocalculo;
                    cmd.Parameters.Add("@visibleq", SqlDbType.Bit).Value = BE.visibleq;
                    cmd.Parameters.Add("@editaq", SqlDbType.Bit).Value = BE.editaq;
                    cmd.Parameters.Add("@rubropdt", SqlDbType.Char, 4).Value = BE.rubropdt;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;

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
        public bool Insert_Update(string empresaid, DataTable TablaDatos)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                bool xreturn = true;
                int lcont = 0;
                for (lcont = 0; lcont <= TablaDatos.Rows.Count - 1; lcont++)
                {
                    using (SqlCommand cmd = new SqlCommand("gspTbPllaRubrosdescuentos_InsertUpdate", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = TablaDatos.Rows[lcont]["tipoplla"];
                        cmd.Parameters.Add("@rubroid", SqlDbType.Char, 3).Value = TablaDatos.Rows[lcont]["rubroid"];
                        cmd.Parameters.Add("@rubroname", SqlDbType.VarChar, 60).Value = TablaDatos.Rows[lcont]["rubroname"];
                        cmd.Parameters.Add("@tiporubro", SqlDbType.Char, 3).Value = TablaDatos.Rows[lcont]["tiporubro"];
                        cmd.Parameters.Add("@visible", SqlDbType.Bit).Value = TablaDatos.Rows[lcont]["visible"];
                        cmd.Parameters.Add("@edita", SqlDbType.Bit).Value = TablaDatos.Rows[lcont]["edita"];
                        cmd.Parameters.Add("@modalidad", SqlDbType.Char, 2).Value = TablaDatos.Rows[lcont]["modalidad"];
                        cmd.Parameters.Add("@redondeo", SqlDbType.Decimal).Value = TablaDatos.Rows[lcont]["redondeo"];
                        cmd.Parameters.Add("@montofijo", SqlDbType.Decimal).Value = TablaDatos.Rows[lcont]["montofijo"];
                        cmd.Parameters.Add("@tipocalculo", SqlDbType.Char, 2).Value = TablaDatos.Rows[lcont]["tipocalculo"];
                        cmd.Parameters.Add("@visibleq", SqlDbType.Bit).Value = TablaDatos.Rows[lcont]["visibleq"];
                        cmd.Parameters.Add("@editaq", SqlDbType.Bit).Value = TablaDatos.Rows[lcont]["editaq"];
                        cmd.Parameters.Add("@rubropdt", SqlDbType.Char, 4).Value = TablaDatos.Rows[lcont]["rubropdt"];
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = TablaDatos.Rows[lcont]["status"];
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

        public bool Update(string empresaid, tb_plla_rubrosdescuentos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRubrosdescuentos_UPDATE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
                        cmd.Parameters.Add("@rubroid", SqlDbType.Char, 3).Value = BE.rubroid;
                        cmd.Parameters.Add("@rubroname", SqlDbType.VarChar, 60).Value = BE.rubroname;
                        cmd.Parameters.Add("@tiporubro", SqlDbType.Char, 3).Value = BE.tiporubro;
                        cmd.Parameters.Add("@visible", SqlDbType.Bit).Value = BE.visible;
                        cmd.Parameters.Add("@edita", SqlDbType.Bit).Value = BE.edita;
                        cmd.Parameters.Add("@modalidad", SqlDbType.Char, 2).Value = BE.modalidad;
                        cmd.Parameters.Add("@redondeo", SqlDbType.Decimal).Value = BE.redondeo;
                        cmd.Parameters.Add("@montofijo", SqlDbType.Decimal).Value = BE.montofijo;
                        cmd.Parameters.Add("@tipocalculo", SqlDbType.Char, 2).Value = BE.tipocalculo;
                        cmd.Parameters.Add("@visibleq", SqlDbType.Bit).Value = BE.visibleq;
                        cmd.Parameters.Add("@editaq", SqlDbType.Bit).Value = BE.editaq;
                        cmd.Parameters.Add("@rubropdt", SqlDbType.Char, 4).Value = BE.rubropdt;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
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
        public bool Copiar(string empresaid, tb_plla_rubrosdescuentos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRubrosdescuentos_CopiarRubros", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipoplanillaorigen", SqlDbType.Char, 1).Value = BE.tipoplanillaorigen;
                        cmd.Parameters.Add("@tipoplanilladestino", SqlDbType.Char, 1).Value = BE.tipoplanilladestino;
                        cmd.Parameters.Add("@tiporubro", SqlDbType.Char, 1).Value = BE.tiporubro;
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
        public bool Delete(string empresaid, tb_plla_rubrosdescuentos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRubrosdescuentos_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
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
                    using (SqlCommand cmd = new SqlCommand("gspTbPllaRubrosdescuentos_Eliminar", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
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

        public DataSet GetAll(string empresaid, tb_plla_rubrosdescuentos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRubrosdescuentos_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
                        cmd.Parameters.Add("@rubroid", SqlDbType.Char, 3).Value = BE.rubroid;
                        cmd.Parameters.Add("@rubroname", SqlDbType.VarChar, 60).Value = BE.rubroname;
                        cmd.Parameters.Add("@tiporubro", SqlDbType.Char, 3).Value = BE.tiporubro;
                        //cmd.Parameters.Add("@visible", SqlDbType.Bit).Value = BE.visible;
                        //cmd.Parameters.Add("@edita", SqlDbType.Bit).Value = BE.edita;
                        cmd.Parameters.Add("@modalidad", SqlDbType.Char, 2).Value = BE.modalidad;
                        //cmd.Parameters.Add("@redondeo", SqlDbType.Decimal).Value = BE.redondeo;
                        //cmd.Parameters.Add("@montofijo", SqlDbType.Decimal).Value = BE.montofijo;
                        cmd.Parameters.Add("@tipocalculo", SqlDbType.Char, 2).Value = BE.tipocalculo;
                        //cmd.Parameters.Add("@visibleq", SqlDbType.Bit).Value = BE.visibleq;
                        //cmd.Parameters.Add("@editaq", SqlDbType.Bit).Value = BE.editaq;
                        cmd.Parameters.Add("@rubropdt", SqlDbType.Char, 4).Value = BE.rubropdt;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
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

        public DataSet GetAll_CONSULTA(string empresaid, tb_plla_rubrosdescuentos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRubrosdescuentos_CONSULTA", cnx))
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
                        cmd.Parameters.Add("@tipocalculo", SqlDbType.Char, 2).Value = BE.tipocalculo;
                        cmd.Parameters.Add("@nestado", SqlDbType.Int).Value = BE.nestado;
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
        public DataSet GetAll_CONSULTA1(string empresaid, tb_plla_rubrosdescuentos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRubrosdescuentos_CONSULTA1", cnx))
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
                        cmd.Parameters.Add("@tipocalculo", SqlDbType.Char, 2).Value = BE.tipocalculo;
                        cmd.Parameters.Add("@nestado", SqlDbType.Int).Value = BE.nestado;
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

        public DataSet GetAll_IR(string empresaid, tb_plla_rubrosdescuentos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRubrosdescuentos_IR", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@rubroid", SqlDbType.Char, 4).Value = BE.rubroid;
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

        public DataSet GetAll_CONSULTA_PLLA(string empresaid, tb_plla_rubrosdescuentos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRubrosdescuentosPlla_CONSULTA", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@tipoplla", string.IsNullOrEmpty(BE.tipoplla) ? (object)DBNull.Value : BE.tipoplla);
                        cmd.Parameters.AddWithValue("@rubroid", string.IsNullOrEmpty(BE.rubroid) ? (object)DBNull.Value : BE.rubroid);
                        cmd.Parameters.AddWithValue("@desclike1", string.IsNullOrEmpty(BE.descriplike1) ? (object)DBNull.Value : BE.descriplike1);
                        cmd.Parameters.AddWithValue("@desclike2", string.IsNullOrEmpty(BE.descriplike2) ? (object)DBNull.Value : BE.descriplike2);
                        cmd.Parameters.AddWithValue("@desclike3", string.IsNullOrEmpty(BE.descriplike3) ? (object)DBNull.Value : BE.descriplike3);
                        cmd.Parameters.AddWithValue("@LPdescartacciatiporubro", string.IsNullOrEmpty(BE.LPdescartacciatiporubro) ? (object)DBNull.Value : BE.LPdescartacciatiporubro);
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

        public DataSet GetMAX_CODIGORUBROPLANILLA(string empresaid, tb_plla_rubrosdescuentos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRubrosingreso_MAXCODIGORUBROPLANILLA", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipo", SqlDbType.Char, 1).Value = BE.tipo;
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

        public DataSet GetOne(string empresaid, tb_plla_rubrosdescuentos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRubrosdescuentos_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
                        cmd.Parameters.Add("@rubroid", SqlDbType.Char, 3).Value = BE.rubroid;
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
