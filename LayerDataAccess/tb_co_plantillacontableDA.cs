using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_co_plantillacontableDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_co_plantillacontable BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoPlantillacontable_INSERT", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@creporte", SqlDbType.Char, 2).Value = BE.creporte;
                    cmd.Parameters.Add("@cgrupo", SqlDbType.Char, 2).Value = BE.cgrupo;
                    cmd.Parameters.Add("@dgrupo", SqlDbType.VarChar, 70).Value = BE.dgrupo;
                    cmd.Parameters.Add("@cuentaid", SqlDbType.Char, 10).Value = BE.cuentaid;
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
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
        public bool Insert_XML(string empresaid, tb_co_plantillacontable BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoPlantillacontable_INSERT_xml", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@creporte", SqlDbType.Char, 7).Value = BE.creporte;
                    cmd.Parameters.Add("@XML", SqlDbType.Xml).Value = BE.GetItemXML();
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
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
        public bool Update(string empresaid, tb_co_plantillacontable BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoPlantillacontable_UPDATE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@creporte", SqlDbType.Char, 2).Value = BE.creporte;
                        cmd.Parameters.Add("@cgrupo", SqlDbType.Char, 2).Value = BE.cgrupo;
                        cmd.Parameters.Add("@dgrupo", SqlDbType.VarChar, 70).Value = BE.dgrupo;
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
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        cnx.Close();
                    }
                }
            }
        }

        public bool Delete(string empresaid, tb_co_plantillacontable BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoPlantillacontable_DELETE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@creporte", SqlDbType.Char, 2).Value = BE.creporte;
                        cmd.Parameters.Add("@cgrupo", SqlDbType.Char, 2).Value = BE.cgrupo;
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
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        cnx.Close();
                    }
                }
            }
        }

        public DataSet GetAll(string empresaid, tb_co_plantillacontable BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoPlantillacontable_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@creporte", SqlDbType.Char, 2).Value = BE.creporte;
                        cmd.Parameters.Add("@cgrupo", SqlDbType.Char, 2).Value = BE.cgrupo;
                        cmd.Parameters.Add("@dgrupo", SqlDbType.VarChar, 70).Value = BE.dgrupo;
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
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
        public DataSet GetAll2(string empresaid, tb_co_plantillacontable BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoPlantillacontable_SEARCH2", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@creporte", SqlDbType.Char, 2).Value = BE.creporte;
                        cmd.Parameters.Add("@ntipo", SqlDbType.Int).Value = BE.ntipo;
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
        public DataSet GetOne(string empresaid, tb_co_plantillacontable BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoPlantillacontable_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@creporte", SqlDbType.Char, 2).Value = BE.creporte;
                        cmd.Parameters.Add("@cgrupo", SqlDbType.Char, 2).Value = BE.cgrupo;
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
                    finally
                    {
                        cnx.Close();
                    }
                }
            }
        }

        public DataSet GetAllPlantilla(string empresaid, tb_co_plantillacontable BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCo_PlantillaContable", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@codigo", SqlDbType.Char, 2).Value = BE.codigo;
                        //cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 70).Value = BE.descripcion;
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

        #region //Partidas Estados Financieros
        public DataSet GetAllPartidas(string empresaid, tb_co_plantillacontable BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoPartidas_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@eeffid", SqlDbType.VarChar, 12).Value = BE.eeffid;
                        cmd.Parameters.Add("@eeffname", SqlDbType.VarChar, 100).Value = BE.eeffname;
                        cmd.Parameters.Add("@observacion", SqlDbType.VarChar, 100).Value = BE.observacion;
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
        public DataSet GetAllPartidasEEFF(string empresaid, tb_co_plantillacontable BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoPartidasEEFF_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@eeffid", SqlDbType.VarChar, 12).Value = BE.eeffid;
                        cmd.Parameters.Add("@partidaid", SqlDbType.VarChar, 12).Value = BE.partidaid;
                        cmd.Parameters.Add("@partidaname", SqlDbType.VarChar, 100).Value = BE.partidaname;
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
        public DataSet GetAllPartidasEEFFCuentas(string empresaid, tb_co_plantillacontable BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoPartidasEEFF_Cuenta_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@eeffid", SqlDbType.VarChar, 12).Value = BE.eeffid;
                        cmd.Parameters.Add("@partidaid", SqlDbType.VarChar, 12).Value = BE.partidaid;
                        cmd.Parameters.Add("@cuentaid", SqlDbType.VarChar, 13).Value = BE.cuentaid;                   
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

        #endregion
    }
}
