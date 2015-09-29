using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_plla_establecimientosDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_plla_establecimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaEstablecimientos_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = BE.empresaid;
                    cmd.Parameters.Add("@estabid", SqlDbType.Char, 4).Value = BE.estabid;
                    cmd.Parameters.Add("@estabname", SqlDbType.VarChar, 100).Value = BE.estabname;
                    cmd.Parameters.Add("@estabrtps", SqlDbType.Char, 2).Value = BE.estabrtps;
                    cmd.Parameters.Add("@status", SqlDbType.Bit).Value = BE.status;
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

        public bool Insert_Update(string empresaid, tb_plla_establecimientos BE, DataTable Detalle)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                bool xreturn = true;
                int lcont = 0;              
                for (lcont = 0; lcont <= Detalle.Rows.Count - 1; lcont++)
                {
                    using (SqlCommand cmd = new SqlCommand("gspTbPllaEstablecimientos_InsertUpdate", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = Detalle.Rows[lcont]["empresaid"];
                        cmd.Parameters.Add("@estabid", SqlDbType.Char, 4).Value = Detalle.Rows[lcont]["estabid"];
                        cmd.Parameters.Add("@estabname", SqlDbType.VarChar, 100).Value = Detalle.Rows[lcont]["estabname"];
                        cmd.Parameters.Add("@estabrtps", SqlDbType.Char, 2).Value = Detalle.Rows[lcont]["estabrtps"];
                        cmd.Parameters.Add("@status", SqlDbType.Bit).Value = Detalle.Rows[lcont]["status"];
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

        public bool Update(string empresaid, tb_plla_establecimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaEstablecimientos_UPDATE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = BE.empresaid;
                        cmd.Parameters.Add("@estabid", SqlDbType.Char, 4).Value = BE.estabid;
                        cmd.Parameters.Add("@estabname", SqlDbType.VarChar, 100).Value = BE.estabname;
                        cmd.Parameters.Add("@estabrtps", SqlDbType.Char, 2).Value = BE.estabrtps;
                        cmd.Parameters.Add("@status", SqlDbType.Bit).Value = BE.status;
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

        public bool Delete(string empresaid, tb_plla_establecimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaEstablecimientos_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = BE.empresaid;
                        cmd.Parameters.Add("@estabid", SqlDbType.Char, 4).Value = BE.estabid;
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
        public bool Eliminar(string empresaid, DataTable TablaTrab)
        {           
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                bool xreturn = true;
                int lcont = 0;
                for (lcont = 0; lcont <= TablaTrab.Rows.Count - 1; lcont++)
                {
                    using (SqlCommand cmd = new SqlCommand("gspTbPllaEstablecimientos_ELIMINAR", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = TablaTrab.Rows[lcont]["empresaid"];
                        cmd.Parameters.Add("@estabid", SqlDbType.Char, 4).Value = TablaTrab.Rows[lcont]["estabid"];
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

        public DataSet GetAll(string empresaid, tb_plla_establecimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaEstablecimientos_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = BE.empresaid;
                        cmd.Parameters.Add("@estabid", SqlDbType.Char, 4).Value = BE.estabid;
                        cmd.Parameters.Add("@estabname", SqlDbType.VarChar, 100).Value = BE.estabname;
                        cmd.Parameters.Add("@estabrtps", SqlDbType.Char, 2).Value = BE.estabrtps;
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

        public DataSet GetAll_CONSULTA(string empresaid, tb_plla_establecimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaEstablecimientos_CONSULTA", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@empresaid", string.IsNullOrEmpty(BE.empresaid) ? (object)DBNull.Value : BE.empresaid);
                        cmd.Parameters.AddWithValue("@estabid", string.IsNullOrEmpty(BE.estabid) ? (object)DBNull.Value : BE.estabid);
                        cmd.Parameters.AddWithValue("@nomlike1", string.IsNullOrEmpty(BE.nomlike1) ? (object)DBNull.Value : BE.nomlike1);
                        cmd.Parameters.AddWithValue("@nomlike2", string.IsNullOrEmpty(BE.nomlike2) ? (object)DBNull.Value : BE.nomlike2);
                        cmd.Parameters.AddWithValue("@nomlike3", string.IsNullOrEmpty(BE.nomlike3) ? (object)DBNull.Value : BE.nomlike3);
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
        
        public DataSet GetAll_CONSULTAIR(string empresaid, tb_plla_establecimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaEstablecimientos_IR", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@empresaid", string.IsNullOrEmpty(BE.empresaid) ? (object)DBNull.Value : BE.empresaid);
                        cmd.Parameters.AddWithValue("@estabid", string.IsNullOrEmpty(BE.estabid) ? (object)DBNull.Value : BE.estabid);
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
 
        public DataSet GetAll_MaxCodigo(string empresaid, tb_plla_establecimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaEstablecimientos_MaxCodigo", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@empresaid", SqlDbType.Char, 5).Value = BE.empresaid;
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

        public DataSet GetOne(string empresaid, tb_plla_establecimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaEstablecimientos_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = BE.empresaid;
                        cmd.Parameters.Add("@estabid", SqlDbType.Char, 4).Value = BE.estabid;
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
