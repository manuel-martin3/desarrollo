using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_plla_rubrospllacabDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_plla_rubrospllacab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllarubrospllacab_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@rubrocod", SqlDbType.Char, 5).Value = BE.rubrocod;
                    cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
                    cmd.Parameters.Add("@tiporubro", SqlDbType.Char, 1).Value = BE.tiporubro;
                    cmd.Parameters.Add("@rubroname", SqlDbType.VarChar, 60).Value = BE.rubroname;
                    cmd.Parameters.Add("@rubroabrev", SqlDbType.VarChar, 30).Value = BE.rubroabrev;
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
        public bool Insert_Update(string empresaid, tb_plla_rubrospllacab BE, DataTable Cabecera, DataTable Detalle)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                bool xreturn = true;
                int lcont = 0;
                int lccontdetalle = 0;
                for (lcont = 0; lcont <= Cabecera.Rows.Count - 1; lcont++)
                {
                    if ((Detalle != null))
                    {
                        using (SqlCommand cmd = new SqlCommand("gspTbPllarubrosplladet_Eliminar", cnx))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@rubrocod", SqlDbType.Char, 5).Value = Cabecera.Rows[lcont]["rubrocod"];
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

                    using (SqlCommand cmd = new SqlCommand("gspTbPllarubrospllacab_InsertUpdate", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@rubrocod", SqlDbType.Char, 5).Value = Cabecera.Rows[lcont]["rubrocod"];
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = Cabecera.Rows[lcont]["tipoplla"];
                        cmd.Parameters.Add("@tiporubro", SqlDbType.Char, 1).Value = Cabecera.Rows[lcont]["tiporubro"];
                        cmd.Parameters.Add("@rubroname", SqlDbType.VarChar, 60).Value = Cabecera.Rows[lcont]["rubroname"];
                        cmd.Parameters.Add("@rubroabrev", SqlDbType.VarChar, 30).Value = Cabecera.Rows[lcont]["rubroabrev"];
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

                    if ((Detalle != null))
                    {
                        for (lccontdetalle = 0; lccontdetalle <= Detalle.Rows.Count - 1; lccontdetalle++)
                        {
                            using (SqlCommand cmd = new SqlCommand("gspTbPllarubrosplladet_InsertUpdate", cnx))
                            {
                                cmd.CommandTimeout = 0;
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@rubrocod", SqlDbType.Char, 5).Value = Detalle.Rows[lccontdetalle]["rubrocod"];
                                cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = Detalle.Rows[lccontdetalle]["empresaid"];
                                cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = Detalle.Rows[lccontdetalle]["tipoplla"];
                                cmd.Parameters.Add("@rubroid", SqlDbType.Char, 3).Value = Detalle.Rows[lccontdetalle]["rubroid"];
                                cmd.Parameters.Add("@norden", SqlDbType.Int).Value = Detalle.Rows[lccontdetalle]["norden"];
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
                    }
                }
                return xreturn;
            }
        }

        //public bool cabRubrosPlanilla_UPDATE(DataTable cabecera, DataTable detalle)
        //{
        //    int lc_contcab = 0;
        //    int lccontdetalle = 0;
        //    int retorno = -1;
        //    if (SQL_CONNECT(true))
        //    {
        //        try
        //        {
        //            retorno = 0;
        //            for (lc_contcab = 0; lc_contcab <= cabecera.Rows.Count - 1; lc_contcab++)
        //            {
        //                if ((detalle != null))
        //                {
        //                    AddStore("detRubrosPlanilla_delete");
        //                    AddParametro("@codigo", SqlDbType.Char, cabecera.Rows[lc_contcab]["codrubro"]);
        //                    retorno = COMANDOSQL.ExecuteNonQuery;
        //                    COMANDOSQL.Parameters.Clear();
        //                }
        //                AddStore("cabRubrosPlanilla_update");
        //                AddParametro("@codrubro", SqlDbType.Char, cabecera.Rows[lc_contcab]["codrubro"]);
        //                AddParametro("@tipoplanilla", SqlDbType.Char, cabecera.Rows[lc_contcab]["tipoplanilla"]);
        //                AddParametro("@tipo", SqlDbType.Char, cabecera.Rows[lc_contcab]["tipo"]);
        //                AddParametro("@desrubro", SqlDbType.VarChar, cabecera.Rows[lc_contcab]["desrubro"]);
        //                AddParametro("@abrevrubro", SqlDbType.VarChar, cabecera.Rows[lc_contcab]["abrevrubro"]);
        //                retorno = COMANDOSQL.ExecuteNonQuery();
        //                COMANDOSQL.Parameters.Clear();

        //                if ((detalle != null))
        //                {
        //                    for (lccontdetalle = 0; lccontdetalle <= detalle.Rows.Count - 1; lccontdetalle++)
        //                    {
        //                        AddStore("DesRubrosPlanilla_update");
        //                        AddParametro("@codrubro", SqlDbType.Char, detalle.Rows[lccontdetalle]["codrubro"]);
        //                        AddParametro("@ccia_pla", SqlDbType.Char, detalle.Rows[lccontdetalle]["ccia_pla"]);
        //                        AddParametro("@tipo_pla", SqlDbType.Char, detalle.Rows[lccontdetalle]["tipo_pla"]);
        //                        AddParametro("@rubro_pla", SqlDbType.Char, detalle.Rows[lccontdetalle]["rubro_pla"]);
        //                        AddParametro("@norden", SqlDbType.Int, detalle.Rows[lccontdetalle]["norden"]);
        //                        retorno = COMANDOSQL.ExecuteNonQuery;
        //                        COMANDOSQL.Parameters.Clear();
        //                    }
        //                }

        //            }
        //            retorno = 1;
        //        }
        //        catch (Exception ex)
        //        {
        //            Sql_Error = ex.Message;
        //            retorno = 0;
        //        }
        //        SQL_DISCONNECT();
        //    }
        //    return retorno == 1;
        //}

        public bool Update(string empresaid, tb_plla_rubrospllacab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllarubrospllacab_UPDATE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@rubrocod", SqlDbType.Char, 5).Value = BE.rubrocod;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
                        cmd.Parameters.Add("@tiporubro", SqlDbType.Char, 1).Value = BE.tiporubro;
                        cmd.Parameters.Add("@rubroname", SqlDbType.VarChar, 60).Value = BE.rubroname;
                        cmd.Parameters.Add("@rubroabrev", SqlDbType.VarChar, 30).Value = BE.rubroabrev;
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
        
        public bool Delete(string empresaid, tb_plla_rubrospllacab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllarubrospllacab_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@rubrocod", SqlDbType.Char, 5).Value = BE.rubrocod;
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
        public bool Eliminar(string empresaid, DataTable Cabecera)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                bool xreturn = true;
                int lcont = 0;
                for (lcont = 0; lcont <= Cabecera.Rows.Count - 1; lcont++)
                {
                    using (SqlCommand cmd = new SqlCommand("gspTbPllarubrosplladet_Eliminar", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@rubrocod", SqlDbType.Char, 5).Value = Cabecera.Rows[lcont]["rubrocod"];
                        try
                        {
                            cnx.Open();
                            if (cmd.ExecuteNonQuery() > 0)
                            { xreturn = true; }
                            else
                            { xreturn = false; }
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

                    using (SqlCommand cmd = new SqlCommand("gspTbPllarubrospllacab_Eliminar", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@rubrocod", SqlDbType.Char, 5).Value = Cabecera.Rows[lcont]["rubrocod"];
                        try
                        {
                            cnx.Open();
                            if (cmd.ExecuteNonQuery() > 0)
                            { xreturn = true; }
                            else
                            { xreturn = false; }
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

        //public bool cabRubrosPlanilla_DELETE(DataTable cabecera)
        //{
        //    int lc_contcab = 0;
        //    int retorno = -1;
        //    if (SQL_CONNECT(true))
        //    {
        //        try
        //        {
        //            retorno = 0;
        //            for (lc_contcab = 0; lc_contcab <= cabecera.Rows.Count - 1; lc_contcab++)
        //            {
        //                AddStore("detRubrosPlanilla_delete");
        //                AddParametro("@codigo", SqlDbType.Char, cabecera.Rows[lc_contcab]["codrubro"]);
        //                retorno = COMANDOSQL.ExecuteNonQuery;
        //                COMANDOSQL.Parameters.Clear();

        //                AddStore("cabRubrosPlanilla_delete");
        //                AddParametro("@codigo", SqlDbType.Char, cabecera.Rows[lc_contcab]["codrubro"]);
        //                retorno = COMANDOSQL.ExecuteNonQuery();
        //                COMANDOSQL.Parameters.Clear();
        //            }
        //            retorno = 1;
        //        }
        //        catch (Exception ex)
        //        {
        //            Sql_Error = ex.Message;
        //            retorno = 0;
        //        }
        //        SQL_DISCONNECT();
        //    }
        //    return retorno == 1;
        //}

        public DataSet GetAll(string empresaid, tb_plla_rubrospllacab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRubrospllacab_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@rubrocod", string.IsNullOrEmpty(BE.rubrocod) ? (object)DBNull.Value : BE.rubrocod);
                        cmd.Parameters.AddWithValue("@tipoplla", string.IsNullOrEmpty(BE.tipoplla) ? (object)DBNull.Value : BE.tipoplla);
                        cmd.Parameters.AddWithValue("@tiporubro", string.IsNullOrEmpty(BE.tiporubro) ? (object)DBNull.Value : BE.tiporubro);
                        cmd.Parameters.AddWithValue("@rubroname", string.IsNullOrEmpty(BE.rubroname) ? (object)DBNull.Value : BE.rubroname);
                        cmd.Parameters.AddWithValue("@rubroabrev", string.IsNullOrEmpty(BE.rubroabrev) ? (object)DBNull.Value : BE.rubroabrev);

                        //cmd.Parameters.Add("@rubrocod", SqlDbType.Char, 5).Value = BE.rubrocod;
                        //cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
                        //cmd.Parameters.Add("@tiporubro", SqlDbType.Char, 1).Value = BE.tiporubro;
                        //cmd.Parameters.Add("@rubroname", SqlDbType.VarChar, 60).Value = BE.rubroname;
                        //cmd.Parameters.Add("@rubroabrev", SqlDbType.VarChar, 30).Value = BE.rubroabrev;
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

        public DataSet GetAll_CONSULTA(string empresaid, tb_plla_rubrospllacab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllarubrospllacab_CONSULTA", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@rubrocod", string.IsNullOrEmpty(BE.rubrocod) ? (object)DBNull.Value : BE.rubrocod);
                        cmd.Parameters.AddWithValue("@tiporubro", string.IsNullOrEmpty(BE.tiporubro) ? (object)DBNull.Value : BE.tiporubro);
                        cmd.Parameters.AddWithValue("@nomlike1", string.IsNullOrEmpty(BE.nomlike1) ? (object)DBNull.Value : BE.nomlike1);
                        cmd.Parameters.AddWithValue("@nomlike2", string.IsNullOrEmpty(BE.nomlike2) ? (object)DBNull.Value : BE.nomlike2);
                        cmd.Parameters.AddWithValue("@nomlike3", string.IsNullOrEmpty(BE.nomlike3) ? (object)DBNull.Value : BE.nomlike3);
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

        public DataSet GetAll_MaxRubro(string empresaid, tb_plla_rubrospllacab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllarubrospllacab_MAXCOD_RUBROGENPLLA", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@rubrocod", SqlDbType.Char, 5).Value = BE.rubrocod;
                        //cmd.Parameters.Add("@tiporubro", SqlDbType.Char, 1).Value = BE.tiporubro;
                        //cmd.Parameters.Add("@nomlike1", SqlDbType.VarChar, 60).Value = BE.nomlike1;
                        //cmd.Parameters.Add("@nomlike2", SqlDbType.VarChar, 60).Value = BE.nomlike2;
                        //cmd.Parameters.Add("@nomlike3", SqlDbType.VarChar, 60).Value = BE.nomlike3;
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

        public DataSet GetOne(string empresaid, tb_plla_rubrospllacab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllarubrospllacab_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@rubrocod", SqlDbType.Char, 4).Value = BE.rubrocod;
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
