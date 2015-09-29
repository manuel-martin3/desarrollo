using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_plla_fichatrabajadoresrubrosDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_plla_fichatrabajadoresrubros BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadoresrubros_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@fichaid", SqlDbType.Char, 7).Value = BE.fichaid;
                    cmd.Parameters.Add("@ncontrato", SqlDbType.Char, 6).Value = BE.ncontrato;
                    cmd.Parameters.Add("@rubroid", SqlDbType.Char, 4).Value = BE.rubroid;
                    cmd.Parameters.Add("@importediario", SqlDbType.Decimal).Value = BE.importediario;
                    cmd.Parameters.Add("@importemensual", SqlDbType.Decimal).Value = BE.importemensual;
                    cmd.Parameters.Add("@fijo", SqlDbType.Char, 1).Value = BE.fijo;
                    cmd.Parameters.Add("@consimporte", SqlDbType.Bit).Value = BE.consimporte;
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

        public bool Insert_Update(string empresaid, tb_plla_fichatrabajadoresrubros BE, DataTable Detalle)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                bool xreturn = true;
                int lcont = 0;              
                for (lcont = 0; lcont <= Detalle.Rows.Count - 1; lcont++)
                {
                    using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadoresrubros_InsertUpdate", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipocontratoid", SqlDbType.Char, 2).Value = Detalle.Rows[lcont]["tipocontratoid"];
                        cmd.Parameters.Add("@tipocontratoname", SqlDbType.VarChar, 80).Value = Detalle.Rows[lcont]["tipocontratoname"];
                        cmd.Parameters.Add("@status", SqlDbType.Int).Value = Detalle.Rows[lcont]["status"];
                        cmd.Parameters.Add("@pdttipocontrato", SqlDbType.Char, 2).Value = Detalle.Rows[lcont]["pdttipocontrato"];
                        cmd.Parameters.Add("@formatocontrato", SqlDbType.Char, 2).Value = Detalle.Rows[lcont]["formatocontrato"];
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

        public bool Update(string empresaid, tb_plla_fichatrabajadoresrubros BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadoresrubros_UPDATE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@fichaid", SqlDbType.Char, 7).Value = BE.fichaid;
                        cmd.Parameters.Add("@ncontrato", SqlDbType.Char, 6).Value = BE.ncontrato;
                        cmd.Parameters.Add("@rubroid", SqlDbType.Char, 4).Value = BE.rubroid;
                        cmd.Parameters.Add("@importediario", SqlDbType.Decimal).Value = BE.importediario;
                        cmd.Parameters.Add("@importemensual", SqlDbType.Decimal).Value = BE.importemensual;
                        cmd.Parameters.Add("@fijo", SqlDbType.Char, 1).Value = BE.fijo;
                        cmd.Parameters.Add("@consimporte", SqlDbType.Bit).Value = BE.consimporte;
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

        public bool Delete(string empresaid, tb_plla_fichatrabajadoresrubros BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadoresrubros_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@fichaid", SqlDbType.Char, 7).Value = BE.fichaid;
                        cmd.Parameters.Add("@ncontrato", SqlDbType.Char, 6).Value = BE.ncontrato;
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
                    using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadoresrubros_ELIMINAR", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipocontratoid", SqlDbType.Char, 2).Value = TablaTrab.Rows[lcont]["tipocontratoid"];
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

        public DataSet GetAll(string empresaid, tb_plla_fichatrabajadoresrubros BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadoresrubros_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@fichaid", SqlDbType.Char, 7).Value = BE.fichaid;
                        cmd.Parameters.Add("@ncontrato", SqlDbType.Char, 6).Value = BE.ncontrato;
                        cmd.Parameters.Add("@rubroid", SqlDbType.Char, 4).Value = BE.rubroid;
                        //cmd.Parameters.Add("@importediario", SqlDbType.Decimal).Value = BE.importediario;
                        //cmd.Parameters.Add("@importemensual", SqlDbType.Decimal).Value = BE.importemensual;
                        cmd.Parameters.Add("@fijo", SqlDbType.Char, 1).Value = BE.fijo;
                        //cmd.Parameters.Add("@consimporte", SqlDbType.Bit).Value = BE.consimporte;
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

        public DataSet GetAll_CONSULTA(string empresaid, tb_plla_fichatrabajadoresrubros BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadoresrubros_CONSULTA", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@fichaid", string.IsNullOrEmpty(BE.fichaid) ? (object)DBNull.Value : BE.fichaid);
                        cmd.Parameters.AddWithValue("@ncontrato", string.IsNullOrEmpty(BE.ncontrato) ? (object)DBNull.Value : BE.ncontrato);
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
        public DataSet GetAll_CONSULTAIR(string empresaid, tb_plla_fichatrabajadoresrubros BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadoresrubros_IR", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@tipocontratoid", string.IsNullOrEmpty(BE.tipocontratoid) ? (object)DBNull.Value : BE.tipocontratoid);
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
        //public DataSet GetAll_CONSULTACCOSTO(string empresaid, tb_plla_plantilla_contratos BE)
        //{
        //    using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("gspTbPllaCcostogen_CONSULTASelectAll", cnx))
        //        {
        //            DataSet ds = new DataSet();
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@empresaid", string.IsNullOrEmpty(BE.empresaid) ? (object)DBNull.Value : BE.empresaid);                        
        //                cmd.Parameters.AddWithValue("@nomlike1", string.IsNullOrEmpty(BE.nomlike1) ? (object)DBNull.Value : BE.nomlike1);
        //                cmd.Parameters.AddWithValue("@nomlike2", string.IsNullOrEmpty(BE.nomlike2) ? (object)DBNull.Value : BE.nomlike2);
        //                cmd.Parameters.AddWithValue("@nomlike3", string.IsNullOrEmpty(BE.nomlike3) ? (object)DBNull.Value : BE.nomlike3);
        //                cmd.Parameters.AddWithValue("@ccostodescartar", string.IsNullOrEmpty(BE.ccostodescartar) ? (object)DBNull.Value : BE.ccostodescartar);
        //            }
        //            try
        //            {
        //                cnx.Open();
        //                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        //                {
        //                    da.Fill(ds);
        //                }
        //                return ds;
        //            }
        //            catch (Exception ex)
        //            {
        //                Sql_Error = ex.Message;
        //                throw new Exception(ex.Message);
        //            }
        //        }
        //    }
        //}

        public DataSet GetAll_MaxCodigo(string empresaid, tb_plla_fichatrabajadoresrubros BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadoresrubros_MAXCODIGO", cnx))
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

        public DataSet GetOne(string empresaid, tb_plla_fichatrabajadoresrubros BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadoresrubros_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@fichaid", SqlDbType.Char, 7).Value = BE.fichaid;
                        cmd.Parameters.Add("@ncontrato", SqlDbType.Char, 6).Value = BE.ncontrato;
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
