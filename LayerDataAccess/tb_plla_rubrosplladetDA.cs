using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_plla_rubrosplladetDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_plla_rubrosplladet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllarubrosplladet_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@rubrocod", SqlDbType.Char, 5).Value = BE.rubrocod;
                    cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = BE.empresaid;
                    cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
                    cmd.Parameters.Add("@rubroid", SqlDbType.Char, 3).Value = BE.rubroid;
                    cmd.Parameters.Add("@norden", SqlDbType.Int).Value = BE.norden;
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
        //public bool Insert_Update(string empresaid, tb_plla_rubrosplladet BE, DataTable Cabecera, DataTable Detalle)
        //{
        //    using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
        //    {
        //        bool xreturn = true;
        //        int lcont = 0;
        //        int lccontdetalle = 0;
        //        for (lcont = 0; lcont <= Cabecera.Rows.Count - 1; lcont++)
        //        {
        //            if ((Detalle != null))
        //            {
        //                using (SqlCommand cmd = new SqlCommand("gspTbPllarubrospllacab_Eliminar", cnx))
        //                {
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add("@rubrocod", SqlDbType.Char, 5).Value = Cabecera.Rows[lcont]["rubrocod"];
        //                    try
        //                    {
        //                        cnx.Open();
        //                        if (cmd.ExecuteNonQuery() > 0)
        //                        {
        //                            xreturn = true;
        //                        }
        //                        else
        //                        {
        //                            xreturn = false;
        //                        }
        //                        cnx.Close();
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        Sql_Error = ex.Message;
        //                        //throw new Exception(ex.Message);
        //                        xreturn = false;
        //                        cnx.Close();
        //                    }
        //                }
        //            }

        //            using (SqlCommand cmd = new SqlCommand("gspTbPllarubrospllacab_InsertUpdate", cnx))
        //            {
        //                cmd.CommandTimeout = 0;
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.Add("@rubrocod", SqlDbType.Char, 5).Value = Cabecera.Rows[lcont]["rubrocod"];
        //                cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = Cabecera.Rows[lcont]["tipoplla"];
        //                cmd.Parameters.Add("@tiporubro", SqlDbType.Char, 1).Value = Cabecera.Rows[lcont]["tiporubro"];
        //                cmd.Parameters.Add("@rubroname", SqlDbType.VarChar, 60).Value = Cabecera.Rows[lcont]["rubroname"];
        //                cmd.Parameters.Add("@rubroabrev", SqlDbType.VarChar, 30).Value = Cabecera.Rows[lcont]["rubroabrev"];
        //                try
        //                {
        //                    cnx.Open();
        //                    if (cmd.ExecuteNonQuery() > 0)
        //                    {
        //                        xreturn = true;
        //                    }
        //                    else
        //                    {
        //                        xreturn = false;
        //                    }
        //                    cnx.Close();
        //                }
        //                catch (Exception ex)
        //                {
        //                    Sql_Error = ex.Message;
        //                    //throw new Exception(ex.Message);
        //                    xreturn = false;
        //                    cnx.Close();
        //                }
        //            }

        //            if ((Detalle != null))
        //            {
        //                for (lccontdetalle = 0; lccontdetalle <= Detalle.Rows.Count - 1; lccontdetalle++)
        //                {
        //                    using (SqlCommand cmd = new SqlCommand("gspTbPllarubrosplladet_InsertUpdate", cnx))
        //                    {
        //                        cmd.CommandTimeout = 0;
        //                        cmd.CommandType = CommandType.StoredProcedure;
        //                        cmd.Parameters.Add("@rubrocod", SqlDbType.Char, 5).Value = Detalle.Rows[lcont]["rubrocod"];
        //                        cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = Detalle.Rows[lcont]["empresaid"];
        //                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = Detalle.Rows[lcont]["tipoplla"];
        //                        cmd.Parameters.Add("@rubroid", SqlDbType.Char, 3).Value = Detalle.Rows[lcont]["rubroid"];
        //                        cmd.Parameters.Add("@norden", SqlDbType.Int).Value = Detalle.Rows[lcont]["norden"];
        //                        try
        //                        {
        //                            cnx.Open();
        //                            if (cmd.ExecuteNonQuery() > 0)
        //                            {
        //                                xreturn = true;
        //                            }
        //                            else
        //                            {
        //                                xreturn = false;
        //                            }
        //                            cnx.Close();
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            Sql_Error = ex.Message;
        //                            //throw new Exception(ex.Message);
        //                            xreturn = false;
        //                            cnx.Close();
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        return xreturn;
        //    }
        //}

        public bool Update(string empresaid, tb_plla_rubrosplladet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllarubrosplladet_UPDATE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@rubrocod", SqlDbType.Char, 5).Value = BE.rubrocod;
                        cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = BE.empresaid;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
                        cmd.Parameters.Add("@rubroid", SqlDbType.Char, 3).Value = BE.rubroid;
                        cmd.Parameters.Add("@norden", SqlDbType.Int).Value = BE.norden;
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

        public bool Delete(string empresaid, tb_plla_rubrosplladet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllarubrosplladet_DELETE", cnx))
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
                    using (SqlCommand cmd = new SqlCommand("gspTbPllarubrosplladet_DELETE", cnx))
                    {
                        cmd.CommandTimeout = 0;
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
                return xreturn;
            }
        }

        public DataSet GetAll(string empresaid, tb_plla_rubrosplladet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllarubrosplladet_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.Parameters.Add("@rubrocod", SqlDbType.Char, 5).Value = BE.rubrocod;
                        cmd.Parameters.Add("@rubrocod", SqlDbType.Char, 5).Value = BE.rubrocod;
                        cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = BE.empresaid;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
                        cmd.Parameters.Add("@rubroid", SqlDbType.Char, 3).Value = BE.rubroid;
                        //cmd.Parameters.Add("@norden", SqlDbType.Int).Value = BE.norden;
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

        public DataSet GetAll_CONSULTA(string empresaid, tb_plla_rubrosplladet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllarubrosplladet_CONSULTA", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@rubrocod", SqlDbType.Char, 5).Value = BE.rubrocod;
                        //cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = BE.empresaid;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
                        cmd.Parameters.Add("@rubroid", SqlDbType.Char, 3).Value = BE.rubroid;
                        cmd.Parameters.Add("@nomlike1", SqlDbType.VarChar, 60).Value = BE.nomlike1;
                        cmd.Parameters.Add("@nomlike2", SqlDbType.VarChar, 60).Value = BE.nomlike2;
                        cmd.Parameters.Add("@nomlike3", SqlDbType.VarChar, 60).Value = BE.nomlike3;
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

        public DataSet GetOne(string empresaid, tb_plla_rubrosplladet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllarubrosplladet_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@rubrocod", SqlDbType.Char, 5).Value = BE.rubrocod;
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
