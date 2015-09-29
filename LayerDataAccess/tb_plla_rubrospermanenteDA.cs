using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_plla_rubrospermanenteDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_plla_rubrospermanente BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRubrospermanentes_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
                    cmd.Parameters.Add("@tiporubro", SqlDbType.Char, 1).Value = BE.tiporubro;
                    cmd.Parameters.Add("@rubro", SqlDbType.Char, 2).Value = BE.rubro;
                    cmd.Parameters.Add("@rubroname", SqlDbType.VarChar, 60).Value = BE.rubroname;
                    cmd.Parameters.Add("@modalidad", SqlDbType.Char, 1).Value = BE.modalidad;
                    cmd.Parameters.Add("@visible", SqlDbType.Bit).Value = BE.visible;
                    cmd.Parameters.Add("@edita", SqlDbType.Bit).Value = BE.edita;
                    cmd.Parameters.Add("@codrubro", SqlDbType.Char, 3).Value = BE.codrubro;
                    cmd.Parameters.Add("@statusrubro", SqlDbType.Bit).Value = BE.statusrubro;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    //tipoplla [char](1) NOT NULL,
                    //tiporubro [char](1) NOT NULL,
                    //rubro [char](2) NOT NULL,
                    //rubroname [varchar](60) NOT NULL,
                    //modalidad [char](1) NOT NULL,
                    //visible [bit] NOT NULL,
                    //edita [bit] NOT NULL,
                    //codrubro [char](3) NOT NULL,
                    //statusrubro [bit] NOT NULL,
                    //status [char](1) NOT NULL,
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
                    using (SqlCommand cmd = new SqlCommand("gspTbPllaRubrospermanentes_InsertUpdate", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = TablaDatos.Rows[lcont]["tipoplla"];
                        cmd.Parameters.Add("@tiporubro", SqlDbType.Char, 1).Value = TablaDatos.Rows[lcont]["tiporubro"];
                        cmd.Parameters.Add("@rubro", SqlDbType.Char, 2).Value = TablaDatos.Rows[lcont]["rubro"];
                        cmd.Parameters.Add("@rubroname", SqlDbType.VarChar, 60).Value = TablaDatos.Rows[lcont]["rubroname"];
                        cmd.Parameters.Add("@modalidad", SqlDbType.Char, 1).Value = TablaDatos.Rows[lcont]["modalidad"];
                        cmd.Parameters.Add("@visible", SqlDbType.Bit).Value = TablaDatos.Rows[lcont]["visible"];
                        cmd.Parameters.Add("@edita", SqlDbType.Bit).Value = TablaDatos.Rows[lcont]["edita"];
                        cmd.Parameters.Add("@codrubro", SqlDbType.Char, 3).Value = TablaDatos.Rows[lcont]["codrubro"];
                        cmd.Parameters.Add("@statusrubro", SqlDbType.Bit).Value = TablaDatos.Rows[lcont]["statusrubro"];
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

        public bool Update(string empresaid, tb_plla_rubrospermanente BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRubrospermanentes_UPDATE", cnx))
                {
                    {
                        //cmd.Connection.ConnectionTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
                        cmd.Parameters.Add("@tiporubro", SqlDbType.Char, 1).Value = BE.tiporubro;
                        cmd.Parameters.Add("@rubro", SqlDbType.Char, 2).Value = BE.rubro;
                        cmd.Parameters.Add("@rubroname", SqlDbType.VarChar, 60).Value = BE.rubroname;
                        cmd.Parameters.Add("@modalidad", SqlDbType.Char, 1).Value = BE.modalidad;
                        cmd.Parameters.Add("@visible", SqlDbType.Bit).Value = BE.visible;
                        cmd.Parameters.Add("@edita", SqlDbType.Bit).Value = BE.edita;
                        cmd.Parameters.Add("@codrubro", SqlDbType.Char, 3).Value = BE.codrubro;
                        cmd.Parameters.Add("@statusrubro", SqlDbType.Bit).Value = BE.statusrubro;
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
        public bool Copiar(string empresaid, tb_plla_rubrospermanente BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRubrospermanentes_CopiarRubros", cnx))
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
        public bool Delete(string empresaid, tb_plla_rubrospermanente BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRubrospermanentes_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
                        cmd.Parameters.Add("@tiporubro", SqlDbType.Char, 1).Value = BE.tiporubro;
                        cmd.Parameters.Add("@rubro", SqlDbType.Char, 2).Value = BE.rubro;
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
                    using (SqlCommand cmd = new SqlCommand("gspTbPllaRubrospermanentes_Eliminar", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = TablaDatos.Rows[lcont]["tipoplla"];
                        cmd.Parameters.Add("@tiporubro", SqlDbType.Char, 1).Value = TablaDatos.Rows[lcont]["tiporubro"];
                        cmd.Parameters.Add("@rubro", SqlDbType.Char, 2).Value = TablaDatos.Rows[lcont]["rubro"];
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

        public DataSet GetAll(string empresaid, tb_plla_rubrospermanente BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRubrospermanentes_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
                        cmd.Parameters.Add("@tiporubro", SqlDbType.Char, 1).Value = BE.tiporubro;
                        cmd.Parameters.Add("@rubro", SqlDbType.Char, 2).Value = BE.rubro;
                        cmd.Parameters.Add("@rubroname", SqlDbType.VarChar, 60).Value = BE.rubroname;
                        cmd.Parameters.Add("@modalidad", SqlDbType.Char, 1).Value = BE.modalidad;
                        //cmd.Parameters.Add("@visible", SqlDbType.Bit).Value = BE.visible;
                        //cmd.Parameters.Add("@edita", SqlDbType.Bit).Value = BE.edita;
                        cmd.Parameters.Add("@codrubro", SqlDbType.Char, 3).Value = BE.codrubro;
                        //cmd.Parameters.Add("@statusrubro", SqlDbType.Bit).Value = BE.statusrubro;
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

        public DataSet GetAll_CONSULTA(string empresaid, tb_plla_rubrospermanente BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRubrospermanentes_CONSULTA", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@rubro", SqlDbType.Char, 2).Value = BE.rubro;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
                        cmd.Parameters.Add("@descriplike1", SqlDbType.VarChar, 60).Value = BE.descriplike1;
                        cmd.Parameters.Add("@descriplike2", SqlDbType.VarChar, 60).Value = BE.descriplike2;
                        cmd.Parameters.Add("@descriplike3", SqlDbType.VarChar, 60).Value = BE.descriplike3;
                        cmd.Parameters.Add("@norden", SqlDbType.Int).Value = BE.norden;
                        cmd.Parameters.Add("@incluir_blanco", SqlDbType.Int).Value = BE.incluir_blanco;
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
        public DataSet GetAll_CONSULTA1(string empresaid, tb_plla_rubrospermanente BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRubrospermanentes_CONSULTA1", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@rubro", SqlDbType.Char, 2).Value = BE.rubro;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
                        cmd.Parameters.Add("@descriplike1", SqlDbType.VarChar, 60).Value = BE.descriplike1;
                        cmd.Parameters.Add("@descriplike2", SqlDbType.VarChar, 60).Value = BE.descriplike2;
                        cmd.Parameters.Add("@descriplike3", SqlDbType.VarChar, 60).Value = BE.descriplike3;
                        cmd.Parameters.Add("@norden", SqlDbType.Int).Value = BE.norden;
                        cmd.Parameters.Add("@incluir_blanco", SqlDbType.Int).Value = BE.incluir_blanco;
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

        public DataSet GetAll_IR(string empresaid, tb_plla_rubrospermanente BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRubrospermanentes_IR", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@rubro", SqlDbType.Char, 3).Value = BE.rubro;
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

        public DataSet GetMAX_CODIGORUBROPLANILLA(string empresaid, tb_plla_rubrospermanente BE)
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

        public DataSet GetOne(string empresaid, tb_plla_rubrospermanente BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaRubrospermanentes_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.tipoplla;
                        cmd.Parameters.Add("@tiporubro", SqlDbType.Char, 3).Value = BE.tiporubro;
                        cmd.Parameters.Add("@rubro", SqlDbType.Char, 3).Value = BE.rubro;
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
