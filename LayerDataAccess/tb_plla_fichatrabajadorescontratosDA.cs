using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_plla_fichatrabajadorescontratosDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_plla_fichatrabajadorescontratos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadorescontratos_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@fichaid", SqlDbType.Char, 7).Value = BE.fichaid;
                    cmd.Parameters.Add("@ncontrato", SqlDbType.Char, 6).Value = BE.ncontrato;
                    cmd.Parameters.Add("@ncomiezo", SqlDbType.Char, 20).Value = BE.ncomiezo;
                    cmd.Parameters.Add("@vlfechaini", SqlDbType.DateTime).Value = BE.vlfechaini;
                    cmd.Parameters.Add("@vlfechafin", SqlDbType.DateTime).Value = BE.vlfechafin;
                    cmd.Parameters.Add("@dcfechaini", SqlDbType.DateTime).Value = BE.dcfechaini;
                    cmd.Parameters.Add("@dcfechafin", SqlDbType.DateTime).Value = BE.dcfechafin;
                    cmd.Parameters.Add("@horarioentrada", SqlDbType.Decimal).Value = BE.horarioentrada;
                    cmd.Parameters.Add("@minutosentrada", SqlDbType.Decimal).Value = BE.minutosentrada;
                    cmd.Parameters.Add("@horariosalida", SqlDbType.Decimal).Value = BE.horariosalida;
                    cmd.Parameters.Add("@minutossalida", SqlDbType.Decimal).Value = BE.minutossalida;
                    cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
                    cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                    cmd.Parameters.Add("@remuneracion", SqlDbType.Decimal).Value = BE.remuneracion;
                    cmd.Parameters.Add("@estado", SqlDbType.Char, 2).Value = BE.estado;
                    cmd.Parameters.Add("@observcese", SqlDbType.Text).Value = BE.observcese;
                    cmd.Parameters.Add("@nuevo", SqlDbType.Char, 1).Value = BE.nuevo;
                    cmd.Parameters.Add("@vigencia", SqlDbType.Bit).Value = BE.vigencia;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd.Parameters.Add("@tipcontratoid", SqlDbType.Char, 2).Value = BE.tipcontratoid;
                    cmd.Parameters.Add("@motfinperiodid", SqlDbType.Char, 2).Value = BE.motfinperiodid;
                    cmd.Parameters.Add("@tipmodalformid", SqlDbType.Char, 2).Value = BE.tipmodalformid;
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

        public bool Insert_Update(string empresaid, tb_plla_fichatrabajadorescontratos BE, DataTable Detalle)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                bool xreturn = true;
                int lcont = 0;              
                for (lcont = 0; lcont <= Detalle.Rows.Count - 1; lcont++)
                {
                    using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadorescontratos_InsertUpdate", cnx))
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

        public bool Update(string empresaid, tb_plla_fichatrabajadorescontratos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadorescontratos_UPDATE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@fichaid", SqlDbType.Char, 7).Value = BE.fichaid;
                        cmd.Parameters.Add("@ncontrato", SqlDbType.Char, 6).Value = BE.ncontrato;
                        cmd.Parameters.Add("@ncomiezo", SqlDbType.Char, 20).Value = BE.ncomiezo;
                        cmd.Parameters.Add("@vlfechaini", SqlDbType.DateTime).Value = BE.vlfechaini;
                        cmd.Parameters.Add("@vlfechafin", SqlDbType.DateTime).Value = BE.vlfechafin;
                        cmd.Parameters.Add("@dcfechaini", SqlDbType.DateTime).Value = BE.dcfechaini;
                        cmd.Parameters.Add("@dcfechafin", SqlDbType.DateTime).Value = BE.dcfechafin;
                        cmd.Parameters.Add("@horarioentrada", SqlDbType.Decimal).Value = BE.horarioentrada;
                        cmd.Parameters.Add("@minutosentrada", SqlDbType.Decimal).Value = BE.minutosentrada;
                        cmd.Parameters.Add("@horariosalida", SqlDbType.Decimal).Value = BE.horariosalida;
                        cmd.Parameters.Add("@minutossalida", SqlDbType.Decimal).Value = BE.minutossalida;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@remuneracion", SqlDbType.Decimal).Value = BE.remuneracion;
                        cmd.Parameters.Add("@estado", SqlDbType.Char, 2).Value = BE.estado;
                        cmd.Parameters.Add("@observcese", SqlDbType.Text).Value = BE.observcese;
                        cmd.Parameters.Add("@nuevo", SqlDbType.Char, 1).Value = BE.nuevo;
                        cmd.Parameters.Add("@vigencia", SqlDbType.Bit).Value = BE.vigencia;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@tipcontratoid", SqlDbType.Char, 2).Value = BE.tipcontratoid;
                        cmd.Parameters.Add("@motfinperiodid", SqlDbType.Char, 2).Value = BE.motfinperiodid;
                        cmd.Parameters.Add("@tipmodalformid", SqlDbType.Char, 2).Value = BE.tipmodalformid;
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

        public bool Delete(string empresaid, tb_plla_fichatrabajadorescontratos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadorescontratos_DELETE", cnx))
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
                    using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadorescontratos_ELIMINAR", cnx))
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

        public DataSet GetAll(string empresaid, tb_plla_fichatrabajadorescontratos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadorescontratos_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@fichaid", SqlDbType.Char, 7).Value = BE.fichaid;
                        cmd.Parameters.Add("@ncontrato", SqlDbType.Char, 6).Value = BE.ncontrato;
                        cmd.Parameters.Add("@ncomiezo", SqlDbType.Char, 20).Value = BE.ncomiezo;
                        cmd.Parameters.Add("@vlfechaini", SqlDbType.DateTime).Value = BE.vlfechaini;
                        cmd.Parameters.Add("@vlfechafin", SqlDbType.DateTime).Value = BE.vlfechafin;
                        cmd.Parameters.Add("@dcfechaini", SqlDbType.DateTime).Value = BE.dcfechaini;
                        cmd.Parameters.Add("@dcfechafin", SqlDbType.DateTime).Value = BE.dcfechafin;
                        //cmd.Parameters.Add("@horarioentrada", SqlDbType.Decimal).Value = BE.horarioentrada;
                        //cmd.Parameters.Add("@minutosentrada", SqlDbType.Decimal).Value = BE.minutosentrada;
                        //cmd.Parameters.Add("@horariosalida", SqlDbType.Decimal).Value = BE.horariosalida;
                        //cmd.Parameters.Add("@minutossalida", SqlDbType.Decimal).Value = BE.minutossalida;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        //cmd.Parameters.Add("@remuneracion", SqlDbType.Decimal).Value = BE.remuneracion;
                        cmd.Parameters.Add("@estado", SqlDbType.Char, 2).Value = BE.estado;
                        cmd.Parameters.Add("@observcese", SqlDbType.Text).Value = BE.observcese;
                        cmd.Parameters.Add("@nuevo", SqlDbType.Char, 1).Value = BE.nuevo;
                        //cmd.Parameters.Add("@vigencia", SqlDbType.Bit).Value = BE.vigencia;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@tipcontratoid", SqlDbType.Char, 2).Value = BE.tipcontratoid;
                        cmd.Parameters.Add("@motfinperiodid", SqlDbType.Char, 2).Value = BE.motfinperiodid;
                        cmd.Parameters.Add("@tipmodalformid", SqlDbType.Char, 2).Value = BE.tipmodalformid;
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

        public DataSet GetAll_CONSULTA(string empresaid, tb_plla_fichatrabajadorescontratos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadorescontratos_CONSULTA", cnx))
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
        public DataSet GetAll_CONSULTAIR(string empresaid, tb_plla_fichatrabajadorescontratos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadorescontratos_IR", cnx))
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

        public DataSet GetAll_MaxCodigo(string empresaid, tb_plla_fichatrabajadorescontratos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadorescontratos_MAXCODIGO", cnx))
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

        public DataSet GetOne(string empresaid, tb_plla_fichatrabajadorescontratos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadorescontratos_SELECT", cnx))
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



        public DataSet GetReport(string empresaid, tb_plla_fichatrabajadorescontratos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadores_Contratos", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = BE.em;
                        cmd.Parameters.Add("@fichaid", SqlDbType.Char, 5).Value = BE.fichaid;
                        cmd.Parameters.Add("@cencosid", SqlDbType.Char, 1).Value = BE.cencosid;
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
                        throw new Exception(ex.Message);
                    }
                }
            }
        }







    }
}
