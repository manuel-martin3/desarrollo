using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_plla_turnoscabDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_plla_turnoscab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaTurnoscab_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdiario", SqlDbType.Char).Value = BE.cdiario;
                    cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = BE.descripcion;
                    cmd.Parameters.Add("@evento", SqlDbType.Char).Value = BE.evento;
                    cmd.Parameters.Add("@horaini", SqlDbType.Char).Value = BE.horaini;
                    cmd.Parameters.Add("@horafin", SqlDbType.Char).Value = BE.horafin;
                    cmd.Parameters.Add("@tothor", SqlDbType.Char).Value = BE.tothor;
                    cmd.Parameters.Add("@totmin", SqlDbType.Decimal).Value = BE.totmin;
                    cmd.Parameters.Add("@quiebre", SqlDbType.Char).Value = BE.quiebre;
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
        public bool Insert_Update(string empresaid, tb_plla_turnoscab BE, DataTable Cabecera, DataTable Detalle)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                bool xreturn = true;
                //int lcont = 0;
                int lccontdetalle = 0;
                using (SqlCommand cmd = new SqlCommand("gspTbPllaTurnoscab_InsertUpdated", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@cdiario", SqlDbType.Char).Value = BE.cdiario;
                        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = BE.descripcion;
                        cmd.Parameters.Add("@evento", SqlDbType.Char).Value = BE.evento;
                        cmd.Parameters.Add("@horaini", SqlDbType.Char).Value = BE.horaini;
                        cmd.Parameters.Add("@horafin", SqlDbType.Char).Value = BE.horafin;
                        cmd.Parameters.Add("@tothor", SqlDbType.Char).Value = BE.tothor;
                        cmd.Parameters.Add("@totmin", SqlDbType.Int).Value = BE.totmin;
                        cmd.Parameters.Add("@quiebre", SqlDbType.Char).Value = BE.quiebre;
                        cmd.Parameters.Add("@status", SqlDbType.Int).Value = BE.status;
                        cmd.Parameters.Add("@Tipo_Actualizacion", SqlDbType.Int).Value = BE.Tipo_Actualizacion;
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
                            using (SqlCommand cmd = new SqlCommand("gspTbPllaTurnosdet_InsertUpdated", cnx))
                            {
                                cmd.CommandTimeout = 0;
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@cdiario", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["codigo"];
                                cmd.Parameters.Add("@item", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["item"];
                                cmd.Parameters.Add("@evento", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["cod_evento"];
                                cmd.Parameters.Add("@horaini", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["hora_inicial"];
                                cmd.Parameters.Add("@horafin", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["hora_final"];
                                cmd.Parameters.Add("@tothor", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["total_horas"];
                                cmd.Parameters.Add("@totmin", SqlDbType.Int).Value = Detalle.Rows[lccontdetalle]["total_minutos"];
                                cmd.Parameters.Add("@status", SqlDbType.Int).Value = BE.status;
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

        public bool Update(string empresaid, tb_plla_turnoscab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaTurnoscab_UPDATE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@cdiario", SqlDbType.Char).Value = BE.cdiario;
                        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = BE.descripcion;
                        cmd.Parameters.Add("@evento", SqlDbType.Char).Value = BE.evento;
                        cmd.Parameters.Add("@horaini", SqlDbType.Char).Value = BE.horaini;
                        cmd.Parameters.Add("@horafin", SqlDbType.Char).Value = BE.horafin;
                        cmd.Parameters.Add("@tothor", SqlDbType.Char).Value = BE.tothor;
                        cmd.Parameters.Add("@totmin", SqlDbType.Decimal).Value = BE.totmin;
                        cmd.Parameters.Add("@quiebre", SqlDbType.Char).Value = BE.quiebre;
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

        public bool Delete(string empresaid, tb_plla_turnoscab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaTurnoscab_ELIMINAR", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@cdiario", SqlDbType.Char).Value = BE.cdiario;
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
                    using (SqlCommand cmd = new SqlCommand("gspTbPllaTurnoscab_Eliminar", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@cdiario", SqlDbType.Char).Value = Cabecera.Rows[lcont]["cdiario"];
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

        public DataSet GetAll(string empresaid, tb_plla_turnoscab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaTurnoscab_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@cdiario", string.IsNullOrEmpty(BE.cdiario) ? (object)DBNull.Value : BE.cdiario);
                        cmd.Parameters.AddWithValue("@descripcion", string.IsNullOrEmpty(BE.descripcion) ? (object)DBNull.Value : BE.descripcion);
                        cmd.Parameters.AddWithValue("@evento", string.IsNullOrEmpty(BE.evento) ? (object)DBNull.Value : BE.evento);
                        cmd.Parameters.AddWithValue("@horaini", string.IsNullOrEmpty(BE.horaini) ? (object)DBNull.Value : BE.horaini);
                        cmd.Parameters.AddWithValue("@horafin", string.IsNullOrEmpty(BE.horafin) ? (object)DBNull.Value : BE.horafin);
                        cmd.Parameters.AddWithValue("@tothor", string.IsNullOrEmpty(BE.tothor) ? (object)DBNull.Value : BE.tothor);
                        cmd.Parameters.AddWithValue("@quiebre", string.IsNullOrEmpty(BE.quiebre) ? (object)DBNull.Value : BE.quiebre);
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

        public DataSet GetAll_CONSULTA(string empresaid, tb_plla_turnoscab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaTurnoscab_CONSULTA", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@cdiario", string.IsNullOrEmpty(BE.cdiario) ? (object)DBNull.Value : BE.cdiario);
                        cmd.Parameters.Add("@norden", SqlDbType.Int).Value = BE.norden;
                        cmd.Parameters.Add("@ver_blanco", SqlDbType.Int).Value = BE.ver_blanco;
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
        public DataSet GetAll_GetAllCONSULTA(string empresaid, tb_plla_turnoscab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaTurnoscab_GetAllCONSULTA", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@cdiario", string.IsNullOrEmpty(BE.cdiario) ? (object)DBNull.Value : BE.cdiario);
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

        public DataSet GetAll_MaxRubro(string empresaid, tb_plla_turnoscab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaTurnoscab_MAXCOD_RUBROGENPLLA", cnx))
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

        public DataSet GetOne(string empresaid, tb_plla_turnoscab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaTurnoscab_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@cdiario", SqlDbType.Char).Value = BE.cdiario;
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
