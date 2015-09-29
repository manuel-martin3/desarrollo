using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_plla_valor_uitDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_plla_valor_uit BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllavalorUIT_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char).Value = BE.perimes;
                    cmd.Parameters.Add("@valoruit", SqlDbType.Decimal).Value = BE.valoruit;
                    cmd.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = BE.cantidad;
                    cmd.Parameters.Add("@porcent", SqlDbType.Decimal).Value = BE.porcent;
                    cmd.Parameters.Add("@mes_cal", SqlDbType.Decimal).Value = BE.mes_cal;
                    cmd.Parameters.Add("@status", SqlDbType.Char).Value = BE.status;
                    cmd.Parameters.Add("@sdomin", SqlDbType.Decimal).Value = BE.sdomin;
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

        public bool Insert_Update(string empresaid, tb_plla_valor_uit BE, DataTable Detalle)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                bool xreturn = true;
                int lcont = 0;              
                for (lcont = 0; lcont <= Detalle.Rows.Count - 1; lcont++)
                {
                    using (SqlCommand cmd = new SqlCommand("gspTbPllavalorUIT_InsertUpdate", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = Detalle.Rows[lcont]["perianio"];
                        cmd.Parameters.Add("@perimes", SqlDbType.Char).Value = Detalle.Rows[lcont]["perimes"];
                        cmd.Parameters.Add("@valoruit", SqlDbType.Decimal).Value = Detalle.Rows[lcont]["valoruit"];
                        cmd.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = Detalle.Rows[lcont]["cantidad"];
                        cmd.Parameters.Add("@porcent", SqlDbType.Decimal).Value = Detalle.Rows[lcont]["porcent"];
                        cmd.Parameters.Add("@mes_cal", SqlDbType.Decimal).Value = Detalle.Rows[lcont]["mes_cal"];
                        cmd.Parameters.Add("@status", SqlDbType.Char).Value = Detalle.Rows[lcont]["status"];
                        cmd.Parameters.Add("@sdomin", SqlDbType.Decimal).Value = Detalle.Rows[lcont]["sdomin"];                        
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

        public bool Update(string empresaid, tb_plla_valor_uit BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("[gspTbPllavalorUIT_UPDATE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char).Value = BE.perimes;
                        cmd.Parameters.Add("@valoruit", SqlDbType.Decimal).Value = BE.valoruit;
                        cmd.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = BE.cantidad;
                        cmd.Parameters.Add("@porcent", SqlDbType.Decimal).Value = BE.porcent;
                        cmd.Parameters.Add("@mes_cal", SqlDbType.Decimal).Value = BE.mes_cal;
                        cmd.Parameters.Add("@status", SqlDbType.Char).Value = BE.status;
                        cmd.Parameters.Add("@sdomin", SqlDbType.Decimal).Value = BE.sdomin;                       
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

        public bool Delete(string empresaid, tb_plla_valor_uit BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("[gspTbPllavalorUIT_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = BE.perianio;
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
                    using (SqlCommand cmd = new SqlCommand("gspTbPllavalorUIT_Eliminar", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = TablaTrab.Rows[lcont]["perianio"];
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

        public DataSet GetAll(string empresaid, tb_plla_valor_uit BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("[gspTbPllavalorUIT_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char).Value = BE.perimes;
                        //cmd.Parameters.Add("@valoruit", SqlDbType.Decimal).Value = BE.valoruit;
                        //cmd.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = BE.cantidad;
                        //cmd.Parameters.Add("@porcent", SqlDbType.Decimal).Value = BE.porcent;
                        //cmd.Parameters.Add("@mes_cal", SqlDbType.Decimal).Value = BE.mes_cal;
                        cmd.Parameters.Add("@status", SqlDbType.Char).Value = BE.status;
                        //cmd.Parameters.Add("@sdomin", SqlDbType.Decimal).Value = BE.sdomin;                        
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

        public DataSet GetAll_CONSULTA(string empresaid, tb_plla_valor_uit BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllavalorUIT_CONSULTA", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        //cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
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
        public DataSet GetAll_CONSULTAIR(string empresaid, tb_plla_valor_uit BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("[gspTbPllavalorUIT_IR", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
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
 
        public DataSet GetAll_MaxCodigo(string empresaid, tb_plla_valor_uit BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("[gspTbPllavalorUIT_MAXCODIGO", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
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

        public DataSet GetOne(string empresaid, tb_plla_valor_uit BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("[gspTbPllavalorUIT_SELECT", cnx))
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
    }
}
