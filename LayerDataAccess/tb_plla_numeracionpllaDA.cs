using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_plla_numeracionpllaDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_plla_numeracionplla BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaNumeracionplla_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = BE.perianio;
                    cmd.Parameters.Add("@asiento", SqlDbType.Char).Value = BE.asiento;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char).Value = BE.perimes;
                    cmd.Parameters.Add("@tipoplla", SqlDbType.Char).Value = BE.tipoplla;
                    cmd.Parameters.Add("@planit", SqlDbType.Decimal).Value = BE.planit;
                    cmd.Parameters.Add("@glosa", SqlDbType.VarChar).Value = BE.glosa;
                    cmd.Parameters.Add("@fechaini", SqlDbType.DateTime).Value = BE.fechaini;
                    cmd.Parameters.Add("@fechafin", SqlDbType.DateTime).Value = BE.fechafin;
                    cmd.Parameters.Add("@afect", SqlDbType.Decimal).Value = BE.afect;
                    cmd.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                    cmd.Parameters.Add("@semana", SqlDbType.Decimal).Value = BE.semana;
                    cmd.Parameters.Add("@nsemana", SqlDbType.Decimal).Value = BE.nsemana;
                    cmd.Parameters.Add("@cierre", SqlDbType.Decimal).Value = BE.cierre;
                    cmd.Parameters.Add("@fechasiento", SqlDbType.DateTime).Value = BE.fechasiento;
                    cmd.Parameters.Add("@selec", SqlDbType.Decimal).Value = BE.selec;
                    cmd.Parameters.Add("@status", SqlDbType.Char).Value = BE.status;
                    cmd.Parameters.Add("@fechpini", SqlDbType.DateTime).Value = BE.fechpini;
                    cmd.Parameters.Add("@fechpfin", SqlDbType.DateTime).Value = BE.fechpfin;
                    cmd.Parameters.Add("@fechtareo", SqlDbType.DateTime).Value = BE.fechtareo;
                    cmd.Parameters.Add("@hextra", SqlDbType.Bit).Value = BE.hextra;
                    cmd.Parameters.Add("@reintegro", SqlDbType.Bit).Value = BE.reintegro;
                    cmd.Parameters.Add("@seleche", SqlDbType.Decimal).Value = BE.seleche;
                    cmd.Parameters.Add("@oficial", SqlDbType.Bit).Value = BE.oficial;
                    cmd.Parameters.Add("@tipoquincena", SqlDbType.Char).Value = BE.tipoquincena;
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

        public bool Insert_Update(string empresaid, tb_plla_numeracionplla BE, DataTable Detalle)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                bool xreturn = true;
                int lcont = 0;              
                for (lcont = 0; lcont <= Detalle.Rows.Count - 1; lcont++)
                {
                    using (SqlCommand cmd = new SqlCommand("gspTbPllaNumeracionplla_InsertUpdate", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = Detalle.Rows[lcont]["perianio"];
                        cmd.Parameters.Add("@asiento", SqlDbType.Char).Value = Detalle.Rows[lcont]["asiento"];
                        cmd.Parameters.Add("@perimes", SqlDbType.Char).Value = Detalle.Rows[lcont]["perimes"];
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char).Value = Detalle.Rows[lcont]["tipoplla"];
                        cmd.Parameters.Add("@planit", SqlDbType.Decimal).Value = Detalle.Rows[lcont]["planit"];
                        cmd.Parameters.Add("@glosa", SqlDbType.VarChar).Value = Detalle.Rows[lcont]["glosa"];
                        cmd.Parameters.Add("@fechaini", SqlDbType.DateTime).Value = Detalle.Rows[lcont]["fechaini"];
                        cmd.Parameters.Add("@fechafin", SqlDbType.DateTime).Value = Detalle.Rows[lcont]["fechafin"];
                        cmd.Parameters.Add("@afect", SqlDbType.Decimal).Value = Detalle.Rows[lcont]["afect"];
                        cmd.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = Detalle.Rows[lcont]["tipcamb"];
                        cmd.Parameters.Add("@semana", SqlDbType.Decimal).Value = Detalle.Rows[lcont]["semana"];
                        cmd.Parameters.Add("@nsemana", SqlDbType.Decimal).Value = Detalle.Rows[lcont]["nsemana"];
                        cmd.Parameters.Add("@cierre", SqlDbType.Decimal).Value = Detalle.Rows[lcont]["cierre"];
                        cmd.Parameters.Add("@fechasiento", SqlDbType.DateTime).Value = Detalle.Rows[lcont]["fechasiento"];
                        cmd.Parameters.Add("@selec", SqlDbType.Decimal).Value = Detalle.Rows[lcont]["selec"];
                        cmd.Parameters.Add("@status", SqlDbType.Char).Value = Detalle.Rows[lcont]["status"];
                        cmd.Parameters.Add("@fechpini", SqlDbType.DateTime).Value = Detalle.Rows[lcont]["fechpini"];
                        cmd.Parameters.Add("@fechpfin", SqlDbType.DateTime).Value = Detalle.Rows[lcont]["fechpfin"];
                        cmd.Parameters.Add("@fechtareo", SqlDbType.DateTime).Value = Detalle.Rows[lcont]["fechtareo"];
                        cmd.Parameters.Add("@hextra", SqlDbType.Bit).Value = Detalle.Rows[lcont]["hextra"];
                        cmd.Parameters.Add("@reintegro", SqlDbType.Bit).Value = Detalle.Rows[lcont]["reintegro"];
                        cmd.Parameters.Add("@seleche", SqlDbType.Decimal).Value = Detalle.Rows[lcont]["seleche"];
                        cmd.Parameters.Add("@oficial", SqlDbType.Bit).Value = Detalle.Rows[lcont]["oficial"];
                        cmd.Parameters.Add("@tipoquincena", SqlDbType.Char).Value = Detalle.Rows[lcont]["tipoquincena"];
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

        public bool Update(string empresaid, tb_plla_numeracionplla BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaNumeracionplla_UPDATE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = BE.perianio;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char).Value = BE.asiento;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char).Value = BE.perimes;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char).Value = BE.tipoplla;
                        cmd.Parameters.Add("@planit", SqlDbType.Decimal).Value = BE.planit;
                        cmd.Parameters.Add("@glosa", SqlDbType.VarChar).Value = BE.glosa;
                        cmd.Parameters.Add("@fechaini", SqlDbType.DateTime).Value = BE.fechaini;
                        cmd.Parameters.Add("@fechafin", SqlDbType.DateTime).Value = BE.fechafin;
                        cmd.Parameters.Add("@afect", SqlDbType.Decimal).Value = BE.afect;
                        cmd.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                        cmd.Parameters.Add("@semana", SqlDbType.Decimal).Value = BE.semana;
                        cmd.Parameters.Add("@nsemana", SqlDbType.Decimal).Value = BE.nsemana;
                        cmd.Parameters.Add("@cierre", SqlDbType.Decimal).Value = BE.cierre;
                        cmd.Parameters.Add("@fechasiento", SqlDbType.DateTime).Value = BE.fechasiento;
                        cmd.Parameters.Add("@selec", SqlDbType.Decimal).Value = BE.selec;
                        cmd.Parameters.Add("@status", SqlDbType.Char).Value = BE.status;
                        cmd.Parameters.Add("@fechpini", SqlDbType.DateTime).Value = BE.fechpini;
                        cmd.Parameters.Add("@fechpfin", SqlDbType.DateTime).Value = BE.fechpfin;
                        cmd.Parameters.Add("@fechtareo", SqlDbType.DateTime).Value = BE.fechtareo;
                        cmd.Parameters.Add("@hextra", SqlDbType.Bit).Value = BE.hextra;
                        cmd.Parameters.Add("@reintegro", SqlDbType.Bit).Value = BE.reintegro;
                        cmd.Parameters.Add("@seleche", SqlDbType.Decimal).Value = BE.seleche;
                        cmd.Parameters.Add("@oficial", SqlDbType.Bit).Value = BE.oficial;
                        cmd.Parameters.Add("@tipoquincena", SqlDbType.Char).Value = BE.tipoquincena;
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

        public bool Delete(string empresaid, tb_plla_numeracionplla BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaNumeracionplla_ELIMINAR", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = BE.perianio;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char).Value = BE.asiento;
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
        public bool Eliminar(string empresaid, DataTable Detalle)
        {           
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                bool xreturn = true;
                int lcont = 0;
                for (lcont = 0; lcont <= Detalle.Rows.Count - 1; lcont++)
                {
                    using (SqlCommand cmd = new SqlCommand("gspTbPllaNumeracionplla_ELIMINAR", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = Detalle.Rows[lcont]["perianio"];
                        cmd.Parameters.Add("@asiento", SqlDbType.Char).Value = Detalle.Rows[lcont]["asiento"];
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

        public DataSet GetAll(string empresaid, tb_plla_numeracionplla BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaNumeracionplla_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = BE.perianio;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char).Value = BE.asiento;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char).Value = BE.perimes;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char).Value = BE.tipoplla;
                        //cmd.Parameters.Add("@planit", SqlDbType.Decimal).Value = BE.planit;
                        cmd.Parameters.Add("@glosa", SqlDbType.VarChar).Value = BE.glosa;
                        cmd.Parameters.Add("@fechaini", SqlDbType.DateTime).Value = BE.fechaini;
                        cmd.Parameters.Add("@fechafin", SqlDbType.DateTime).Value = BE.fechafin;
                        //cmd.Parameters.Add("@afect", SqlDbType.Decimal).Value = BE.afect;
                        //cmd.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                        //cmd.Parameters.Add("@semana", SqlDbType.Decimal).Value = BE.semana;
                        //cmd.Parameters.Add("@nsemana", SqlDbType.Decimal).Value = BE.nsemana;
                        //cmd.Parameters.Add("@cierre", SqlDbType.Decimal).Value = BE.cierre;
                        cmd.Parameters.Add("@fechasiento", SqlDbType.DateTime).Value = BE.fechasiento;
                        //cmd.Parameters.Add("@selec", SqlDbType.Decimal).Value = BE.selec;
                        cmd.Parameters.Add("@status", SqlDbType.Char).Value = BE.status;
                        cmd.Parameters.Add("@fechpini", SqlDbType.DateTime).Value = BE.fechpini;
                        cmd.Parameters.Add("@fechpfin", SqlDbType.DateTime).Value = BE.fechpfin;
                        cmd.Parameters.Add("@fechtareo", SqlDbType.DateTime).Value = BE.fechtareo;
                        cmd.Parameters.Add("@hextra", SqlDbType.Bit).Value = BE.hextra;
                        cmd.Parameters.Add("@reintegro", SqlDbType.Bit).Value = BE.reintegro;
                        //cmd.Parameters.Add("@seleche", SqlDbType.Decimal).Value = BE.seleche;
                        cmd.Parameters.Add("@oficial", SqlDbType.Bit).Value = BE.oficial;
                        cmd.Parameters.Add("@tipoquincena", SqlDbType.Char).Value = BE.tipoquincena;
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

        public DataSet GetAll_CONSULTA(string empresaid, tb_plla_numeracionplla BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaNumeracionplla_CONSULTA", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@asiento", string.IsNullOrEmpty(BE.asiento) ? (object)DBNull.Value : BE.asiento);
                        cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                        cmd.Parameters.AddWithValue("@tipoplla", string.IsNullOrEmpty(BE.tipoplla) ? (object)DBNull.Value : BE.tipoplla);
                        cmd.Parameters.AddWithValue("@nomlike1", string.IsNullOrEmpty(BE.nomlike1) ? (object)DBNull.Value : BE.nomlike1);
                        cmd.Parameters.AddWithValue("@nomlike2", string.IsNullOrEmpty(BE.nomlike2) ? (object)DBNull.Value : BE.nomlike2);
                        cmd.Parameters.AddWithValue("@nomlike3", string.IsNullOrEmpty(BE.nomlike3) ? (object)DBNull.Value : BE.nomlike3);
                        cmd.Parameters.Add("@norden", SqlDbType.Int).Value = BE.norden;
                        cmd.Parameters.AddWithValue("@nsemana", string.IsNullOrEmpty(BE.asemana) ? (object)DBNull.Value : BE.asemana);
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
        public DataSet GetAll_CONSULTAIR(string empresaid, tb_plla_numeracionplla BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaNumeracionplla_IR", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@asiento", string.IsNullOrEmpty(BE.asiento) ? (object)DBNull.Value : BE.asiento);
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
 
        public DataSet GetAll_MaxCodigo(string empresaid, tb_plla_numeracionplla BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaNumeracionplla_MAXCODIGO", cnx))
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

        public DataSet CONSULTA_SELECCION(string empresaid, tb_plla_numeracionplla BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaNumeracionplla_BapSoftPlla_CONSULTA", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@tipoplla", string.IsNullOrEmpty(BE.tipoplla) ? (object)DBNull.Value : BE.tipoplla);
                        cmd.Parameters.AddWithValue("@asiento", string.IsNullOrEmpty(BE.asiento) ? (object)DBNull.Value : BE.asiento);
                        cmd.Parameters.Add("@norden", SqlDbType.Int).Value = BE.norden;
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

        public bool Plla_SELECCIONADA(string empresaid, tb_plla_numeracionplla BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaNumeracionplla_PllaSeleccionada", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = BE.perianio;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char).Value = BE.asiento;
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
        public bool Plla_HESELECCIONADA(string empresaid, tb_plla_numeracionplla BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaNumeracionplla_PllaHESeleccionada", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = BE.perianio;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char).Value = BE.asiento;
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



        public DataSet GetOne(string empresaid, tb_plla_numeracionplla BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaNumeracionplla_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = BE.perianio;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char).Value = BE.asiento;
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
