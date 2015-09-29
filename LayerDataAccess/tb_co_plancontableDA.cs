using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_co_plancontableDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_co_plancontable BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoPlancontable_INSERT", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@cuentaid", SqlDbType.Char, 10).Value = BE.cuentaid;
                    cmd.Parameters.Add("@cuentaname", SqlDbType.VarChar, 100).Value = BE.cuentaname;
                    cmd.Parameters.Add("@ordenresulxnatu", SqlDbType.Char, 1).Value = BE.ordenresulxnatu;
                    cmd.Parameters.Add("@ordenresulxfunc", SqlDbType.Char, 1).Value = BE.ordenresulxfunc;
                    cmd.Parameters.Add("@cuentamarredebe", SqlDbType.Char, 10).Value = BE.cuentamarredebe;
                    cmd.Parameters.Add("@cuentamarrehaber", SqlDbType.Char, 10).Value = BE.cuentamarrehaber;
                    cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                    cmd.Parameters.Add("@cuentaelemento", SqlDbType.Char, 1).Value = BE.cuentaelemento;
                    cmd.Parameters.Add("@cuentadigito", SqlDbType.Char, 1).Value = BE.cuentadigito;
                    cmd.Parameters.Add("@escuentaanalitica", SqlDbType.Bit).Value = BE.escuentaanalitica;
                    cmd.Parameters.Add("@escuentabalance", SqlDbType.Bit).Value = BE.escuentabalance;
                    cmd.Parameters.Add("@escuentaigv", SqlDbType.Bit).Value = BE.escuentaigv;
                    cmd.Parameters.Add("@cuentaajuste", SqlDbType.Bit).Value = BE.cuentaajuste;
                    cmd.Parameters.Add("@cuentapresupuesto", SqlDbType.Bit).Value = BE.cuentapresupuesto;
                    cmd.Parameters.Add("@bancoid", SqlDbType.Char, 2).Value = BE.bancoid;
                    cmd.Parameters.Add("@cuentactenume", SqlDbType.Char, 40).Value = BE.cuentactenume;
                    cmd.Parameters.Add("@cuentamoneda", SqlDbType.Char, 1).Value = BE.cuentamoneda;
                    cmd.Parameters.Add("@tipocambio", SqlDbType.Char, 1).Value = BE.tipocambio;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    cmd.Parameters.Add("@useripcre", SqlDbType.VarChar, 50).Value = BE.useripcre;
                    cmd.Parameters.Add("@useripact", SqlDbType.VarChar, 50).Value = BE.useripact;
                    cmd.Parameters.Add("@cuentaiddj", SqlDbType.Char, 10).Value = BE.cuentaiddj;                   
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

        public bool Update(string empresaid, tb_co_plancontable BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoPlancontable_UPDATE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@cuentaid", SqlDbType.Char, 10).Value = BE.cuentaid;
                        cmd.Parameters.Add("@cuentaname", SqlDbType.VarChar, 100).Value = BE.cuentaname;
                        cmd.Parameters.Add("@ordenresulxnatu", SqlDbType.Char, 1).Value = BE.ordenresulxnatu;
                        cmd.Parameters.Add("@ordenresulxfunc", SqlDbType.Char, 1).Value = BE.ordenresulxfunc;
                        cmd.Parameters.Add("@cuentamarredebe", SqlDbType.Char, 10).Value = BE.cuentamarredebe;
                        cmd.Parameters.Add("@cuentamarrehaber", SqlDbType.Char, 10).Value = BE.cuentamarrehaber;
                        cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                        cmd.Parameters.Add("@cuentaelemento", SqlDbType.Char, 1).Value = BE.cuentaelemento;
                        cmd.Parameters.Add("@cuentadigito", SqlDbType.Char, 1).Value = BE.cuentadigito;
                        cmd.Parameters.Add("@escuentaanalitica", SqlDbType.Bit).Value = BE.escuentaanalitica;
                        cmd.Parameters.Add("@escuentabalance", SqlDbType.Bit).Value = BE.escuentabalance;
                        cmd.Parameters.Add("@escuentaigv", SqlDbType.Bit).Value = BE.escuentaigv;
                        cmd.Parameters.Add("@cuentaajuste", SqlDbType.Bit).Value = BE.cuentaajuste;
                        cmd.Parameters.Add("@cuentapresupuesto", SqlDbType.Bit).Value = BE.cuentapresupuesto;
                        cmd.Parameters.Add("@bancoid", SqlDbType.Char, 2).Value = BE.bancoid;
                        cmd.Parameters.Add("@cuentactenume", SqlDbType.Char, 40).Value = BE.cuentactenume;
                        cmd.Parameters.Add("@cuentamoneda", SqlDbType.Char, 1).Value = BE.cuentamoneda;
                        cmd.Parameters.Add("@tipocambio", SqlDbType.Char, 1).Value = BE.tipocambio;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                        //cmd.Parameters.Add("@useripcre", SqlDbType.VarChar, 50).Value = BE.useripcre;
                        cmd.Parameters.Add("@useripact", SqlDbType.VarChar, 50).Value = BE.useripact;
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
        public bool UpdateDJ(string empresaid, tb_co_plancontable BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoPlancontable_UPDATE_DJ", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@cuentaid", SqlDbType.Char, 10).Value = BE.cuentaid;
                        cmd.Parameters.Add("@cuentaiddj", SqlDbType.Char, 10).Value = BE.cuentaiddj;
                        //cmd.Parameters.Add("@cuentanamedj", SqlDbType.VarChar, 100).Value = BE.cuentanamedj;
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

        public bool Delete(string empresaid, tb_co_plancontable BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoPlancontable_DELETE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@cuentaid", SqlDbType.Char, 10).Value = BE.cuentaid;
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

        public DataSet GetAll(string empresaid, tb_co_plancontable BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoPlancontable_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@cuentaid", SqlDbType.Char, 10).Value = BE.cuentaid;
                        cmd.Parameters.Add("@cuentaname", SqlDbType.VarChar, 100).Value = BE.cuentaname;
                        cmd.Parameters.Add("@ordenresulxnatu", SqlDbType.Char, 1).Value = BE.ordenresulxnatu;
                        cmd.Parameters.Add("@ordenresulxfunc", SqlDbType.Char, 1).Value = BE.ordenresulxfunc;
                        cmd.Parameters.Add("@cuentamarredebe", SqlDbType.Char, 10).Value = BE.cuentamarredebe;
                        cmd.Parameters.Add("@cuentamarrehaber", SqlDbType.Char, 10).Value = BE.cuentamarrehaber;
                        cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                        cmd.Parameters.Add("@cuentaelemento", SqlDbType.Char, 1).Value = BE.cuentaelemento;
                        cmd.Parameters.Add("@cuentadigito", SqlDbType.Char, 1).Value = BE.cuentadigito;
                        cmd.Parameters.Add("@bancoid", SqlDbType.Char, 2).Value = BE.bancoid;
                        cmd.Parameters.Add("@cuentactenume", SqlDbType.Char, 40).Value = BE.cuentactenume;
                        cmd.Parameters.Add("@cuentamoneda", SqlDbType.Char, 1).Value = BE.cuentamoneda;
                        cmd.Parameters.Add("@tipocambio", SqlDbType.Char, 1).Value = BE.tipocambio;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                        //opt
                        cmd.Parameters.Add("@parametro01", SqlDbType.Char, 2).Value = BE.parametro01;
                        cmd.Parameters.Add("@parametro02", SqlDbType.Char, 2).Value = BE.parametro02;
                        cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = BE.tipo;
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

        public DataSet GetAll_PCEDJ(string empresaid, tb_co_plancontable BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoPlanContableDJ_CONSULTA", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@cuentaid", SqlDbType.Char, 10).Value = BE.cuentaid;
                        cmd.Parameters.Add("@cuentaname", SqlDbType.VarChar, 100).Value = BE.cuentaname;
                        cmd.Parameters.Add("@norden", SqlDbType.Int).Value = BE.tipo;
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

        public DataSet GetAll_NPCEDJ(string empresaid, tb_co_plancontable BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoPlancontableDJ_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@cuentaid", SqlDbType.Char, 10).Value = BE.cuentaid;
                        cmd.Parameters.Add("@cuentaname", SqlDbType.VarChar, 100).Value = BE.cuentaname;
                        //cmd.Parameters.Add("@norden", SqlDbType.Int).Value = BE.tipo;
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

        public DataSet GetAll_IR(string empresaid, tb_co_plancontable BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoPlancontable_SEARCH_IR", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@cuentaid", SqlDbType.Char, 10).Value = BE.cuentaid;
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

        public DataSet GetOne(string empresaid, tb_co_plancontable BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoPlancontable_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@cuentaid", SqlDbType.Char, 10).Value = BE.cuentaid;
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

        public Boolean Generar(string empresaid, string perianio_ini, string perianio_fin)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoPlancontable_GENERAR", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio_ini", SqlDbType.Char, 4).Value = perianio_ini;
                        cmd.Parameters.Add("@perianio_fin", SqlDbType.Char, 4).Value = perianio_fin;
                    }

                    try
                    {
                        cnx.Open();
                        cmd.ExecuteNonQuery();
                        cnx.Close();

                        return true;
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
