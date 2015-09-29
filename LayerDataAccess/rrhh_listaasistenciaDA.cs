using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class rrhh_listaasistenciaDA
    {
        Conexion conex = new Conexion();

        public bool Insert(string empresaid, tb_rrhh_listadeasistencia BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbRrhhListadeasistencia_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = BE.FECHA;

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

        public bool Update(string empresaid, tb_rrhh_listadeasistencia BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbRrhhListadeasistencia_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = BE.FECHA;
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

        public bool Update2(string empresaid, tb_rrhh_listadeasistencia BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbRrhhListadeasistencia_UPDATE2", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = BE.FECHA;
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
                }
            }
        }

        public bool UpdateFaltas(string empresaid, tb_rrhh_listadeasistencia BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbRrhhListadeasistencia_faltas_UPDATE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = BE.FECHA;
                        cmd.Parameters.Add("@ddni", SqlDbType.Char,8).Value = BE.DDNNI;
                        cmd.Parameters.Add("@glosa", SqlDbType.VarChar,100).Value = BE.glosa;
                        cmd.Parameters.Add("@tipasistenciaid", SqlDbType.Char,2).Value = BE.tipasistenciaid;
                        cmd.Parameters.Add("@accion", SqlDbType.Char, 1).Value = BE.Accion;
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
                }
            }
        }

        // Recien Agregado Generar Faltas y Tardanzas

        public bool GetGenera(string empresaid, tb_rrhh_listadeasistencia BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbRrhhPersonal_faltas_tardanzas", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;                        
                        cmd.Parameters.Add("@idcc2", SqlDbType.Char,3).Value = BE.IDCC2;
                        cmd.Parameters.Add("@ddnni", SqlDbType.Char,8).Value = BE.DDNNI;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char,4).Value = BE.perianio;
                        cmd.Parameters.Add("@mesini", SqlDbType.Int).Value = BE.mesini;
                        cmd.Parameters.Add("@mesfin", SqlDbType.Int).Value = BE.mesfin;
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
                }
            }
        }

       
        public DataSet GetAll(string empresaid, tb_rrhh_listadeasistencia BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbRrhhListadeasistencia_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = BE.empresaid;
                        cmd.Parameters.Add("@fech1", SqlDbType.DateTime).Value = BE.FECH1;
                        cmd.Parameters.Add("@fech2", SqlDbType.DateTime).Value = BE.FECH2;
                        cmd.Parameters.Add("@ddnni", SqlDbType.VarChar, 8).Value = BE.DDNNI;
                        cmd.Parameters.Add("@idcc1", SqlDbType.VarChar, 2).Value = BE.IDCC1;
                        cmd.Parameters.Add("@idcc2", SqlDbType.VarChar, 3).Value = BE.IDCC2;
                        cmd.Parameters.Add("@nombs", SqlDbType.VarChar, 50).Value = BE.NOMBS;
                        cmd.Parameters.Add("@flvis", SqlDbType.Bit).Value = BE.flvis;
                        cmd.Parameters.Add("@filtro", SqlDbType.Char, 1).Value = BE.filtro;
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

        public DataSet GetAll2(string empresaid, tb_rrhh_listadeasistencia BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbRrhhListadeasistencia_SEARCH2", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@fech1", SqlDbType.DateTime).Value = BE.FECH1;
                        cmd.Parameters.Add("@fech2", SqlDbType.DateTime).Value = BE.FECH2;
                        cmd.Parameters.Add("@ddnni", SqlDbType.VarChar, 8).Value = BE.DDNNI;
                        cmd.Parameters.Add("@idcc1", SqlDbType.VarChar, 2).Value = BE.IDCC1;
                        cmd.Parameters.Add("@idcc2", SqlDbType.VarChar, 3).Value = BE.IDCC2;
                        cmd.Parameters.Add("@nombs", SqlDbType.VarChar, 50).Value = BE.NOMBS;
                        cmd.Parameters.Add("@flvis", SqlDbType.Bit).Value = BE.flvis;
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

        public DataSet GetAll3(string empresaid, tb_rrhh_listadeasistencia BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbRrhhListadeasistencia_SEARCH3", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = BE.empresaid;
                        cmd.Parameters.Add("@fech1", SqlDbType.DateTime).Value = BE.FECH1;
                        cmd.Parameters.Add("@fech2", SqlDbType.DateTime).Value = BE.FECH2;
                        cmd.Parameters.Add("@ddnni", SqlDbType.VarChar, 8).Value = BE.DDNNI;
                        cmd.Parameters.Add("@idcc1", SqlDbType.VarChar, 2).Value = BE.IDCC1;
                        cmd.Parameters.Add("@idcc2", SqlDbType.VarChar, 3).Value = BE.IDCC2;
                        cmd.Parameters.Add("@nombs", SqlDbType.VarChar, 50).Value = BE.NOMBS;
                        cmd.Parameters.Add("@flvis", SqlDbType.Bit).Value = BE.flvis;
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

        public DataSet GetAll_Tardanzas(string empresaid, tb_rrhh_listadeasistencia BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbRrhhPersonal_SEARCH_tardanzas", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@anio", SqlDbType.Int).Value = BE.perianio;
                        cmd.Parameters.Add("@mesini", SqlDbType.Int).Value = BE.mesini;
                        cmd.Parameters.Add("@mesfin", SqlDbType.Int).Value = BE.mesfin;
                        cmd.Parameters.Add("@fechini", SqlDbType.DateTime).Value = BE.FECH1;
                        cmd.Parameters.Add("@fechfin", SqlDbType.DateTime).Value = BE.FECH2;
                        cmd.Parameters.Add("@IDCC2", SqlDbType.Char, 3).Value = BE.IDCC2;
                        cmd.Parameters.Add("@DDNNI", SqlDbType.Char, 8).Value = BE.DDNNI;
                        cmd.Parameters.Add("@NOMBS", SqlDbType.VarChar, 73).Value = BE.NOMBS;
                        cmd.Parameters.Add("@filtro", SqlDbType.Char, 1).Value = BE.filtro;
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


        public DataSet GetAll_Tardanzas2(string empresaid, tb_rrhh_listadeasistencia BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbRrhhPersonal_SEARCH_tardanzas2", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@anio", SqlDbType.Int).Value = BE.perianio;
                        cmd.Parameters.Add("@mesini", SqlDbType.Int).Value = BE.mesini;
                        cmd.Parameters.Add("@mesfin", SqlDbType.Int).Value = BE.mesfin;
                        cmd.Parameters.Add("@fechini", SqlDbType.DateTime).Value = BE.FECH1;
                        cmd.Parameters.Add("@fechfin", SqlDbType.DateTime).Value = BE.FECH2;
                        cmd.Parameters.Add("@IDCC2", SqlDbType.Char, 3).Value = BE.IDCC2;
                        cmd.Parameters.Add("@DDNNI", SqlDbType.Char, 8).Value = BE.DDNNI;
                        cmd.Parameters.Add("@NOMBS", SqlDbType.VarChar, 73).Value = BE.NOMBS;
                        cmd.Parameters.Add("@filtro", SqlDbType.Char, 1).Value = BE.filtro;
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



        public DataSet GetAll_FALTAS(string empresaid, tb_rrhh_listadeasistencia BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbRrhhPersonal_SEARCH_faltas", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@anio", SqlDbType.Int).Value = BE.perianio;
                        cmd.Parameters.Add("@mesini", SqlDbType.Int).Value = BE.mesini;
                        cmd.Parameters.Add("@mesfin", SqlDbType.Int).Value = BE.mesfin;
                        cmd.Parameters.Add("@fechini", SqlDbType.DateTime).Value = BE.FECH1;
                        cmd.Parameters.Add("@fechfin", SqlDbType.DateTime).Value = BE.FECH2;
                        cmd.Parameters.Add("@IDCC2", SqlDbType.Char, 3).Value = BE.IDCC2;
                        cmd.Parameters.Add("@DDNNI", SqlDbType.Char, 8).Value = BE.DDNNI;
                        cmd.Parameters.Add("@NOMBS", SqlDbType.VarChar, 73).Value = BE.NOMBS;
                        cmd.Parameters.Add("@filtro", SqlDbType.Char, 1).Value = BE.filtro;
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


        public DataSet GetAll_faltas_tardanzas(string empresaid, tb_rrhh_listadeasistencia BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbRrhh_SEARCH_faltas_tardanzas", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IDCC2", SqlDbType.Char, 3).Value = BE.IDCC2;
                        cmd.Parameters.Add("@DDNNI", SqlDbType.Char, 8).Value = BE.DDNNI;
                        cmd.Parameters.Add("@NOMBS", SqlDbType.VarChar, 73).Value = BE.NOMBS;
                        cmd.Parameters.Add("@filtro", SqlDbType.Char, 1).Value = BE.filtro;
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
