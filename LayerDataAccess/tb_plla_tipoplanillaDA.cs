using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_plla_tipoplanillaDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_plla_tipoplanilla BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaTipoplla_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.Tipoplla;
                    cmd.Parameters.Add("@tipopllaname", SqlDbType.VarChar, 60).Value = BE.Tipopllaname;
                    cmd.Parameters.Add("@modoplla", SqlDbType.Char, 2).Value = BE.Modoplla;
                    cmd.Parameters.Add("@formapago", SqlDbType.Char, 1).Value = BE.Formapago;
                    cmd.Parameters.Add("@diasplla", SqlDbType.Decimal).Value = BE.Diasplla;
                    cmd.Parameters.Add("@tituloboleta", SqlDbType.VarChar, 60).Value = BE.Tituloboleta;
                    cmd.Parameters.Add("@tipopllaemple", SqlDbType.VarChar, 60).Value = BE.Tipopllaemple;
                    cmd.Parameters.Add("@gratificacion", SqlDbType.Bit).Value = BE.Gratificacion;
                    cmd.Parameters.Add("@pdt", SqlDbType.Bit).Value = BE.Pdt;
                    cmd.Parameters.Add("@cts", SqlDbType.Bit).Value = BE.Cts;
                    cmd.Parameters.Add("@tiptrabid", SqlDbType.Char, 2).Value = BE.Tiptrabid;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.Status;

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

        public bool Update(string empresaid, tb_plla_tipoplanilla BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaTipoplla_UPDATE", cnx))
                {
                    {
                        //cmd.Connection.ConnectionTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.Tipoplla;
                        cmd.Parameters.Add("@tipopllaname", SqlDbType.VarChar, 60).Value = BE.Tipopllaname;
                        cmd.Parameters.Add("@modoplla", SqlDbType.Char, 2).Value = BE.Modoplla;
                        cmd.Parameters.Add("@formapago", SqlDbType.Char, 1).Value = BE.Formapago;
                        cmd.Parameters.Add("@diasplla", SqlDbType.Decimal).Value = BE.Diasplla;
                        cmd.Parameters.Add("@tituloboleta", SqlDbType.VarChar, 60).Value = BE.Tituloboleta;
                        cmd.Parameters.Add("@tipopllaemple", SqlDbType.VarChar, 60).Value = BE.Tipopllaemple;
                        cmd.Parameters.Add("@gratificacion", SqlDbType.Bit).Value = BE.Gratificacion;
                        cmd.Parameters.Add("@pdt", SqlDbType.Bit).Value = BE.Pdt;
                        cmd.Parameters.Add("@cts", SqlDbType.Bit).Value = BE.Cts;
                        cmd.Parameters.Add("@tiptrabid", SqlDbType.Char, 2).Value = BE.Tiptrabid;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.Status;
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

        public bool Delete(string empresaid, tb_plla_tipoplanilla BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaTipoplla_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.Tipoplla;
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

        public DataSet GetAll(string empresaid, tb_plla_tipoplanilla BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaTipoplla_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.Tipoplla;
                        cmd.Parameters.Add("@tipopllaname", SqlDbType.VarChar, 60).Value = BE.Tipopllaname;
                        cmd.Parameters.Add("@modoplla", SqlDbType.Char, 2).Value = BE.Modoplla;
                        cmd.Parameters.Add("@formapago", SqlDbType.Char, 1).Value = BE.Formapago;
                        //cmd.Parameters.Add("@diasplla", SqlDbType.Decimal).Value = BE.Diasplla;
                        cmd.Parameters.Add("@tituloboleta", SqlDbType.VarChar, 60).Value = BE.Tituloboleta;
                        cmd.Parameters.Add("@tipopllaemple", SqlDbType.VarChar, 60).Value = BE.Tipopllaemple;
                        //cmd.Parameters.Add("@gratificacion", SqlDbType.Bit).Value = BE.Gratificacion;
                        //cmd.Parameters.Add("@pdt", SqlDbType.Bit).Value = BE.Pdt;
                        //cmd.Parameters.Add("@cts", SqlDbType.Bit).Value = BE.Cts;
                        cmd.Parameters.Add("@tiptrabid", SqlDbType.Char, 2).Value = BE.Tiptrabid;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.Status;
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

        public DataSet GetAll_Consulta(string empresaid, tb_plla_tipoplanilla BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaTipoplla_CONSULTA", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.Tipoplla;
                        cmd.Parameters.Add("@nomlike1", SqlDbType.VarChar, 50).Value = BE.nomlike1;
                        cmd.Parameters.Add("@nomlike2", SqlDbType.VarChar, 50).Value = BE.nomlike2;
                        cmd.Parameters.Add("@nomlike3", SqlDbType.VarChar, 50).Value = BE.nomlike3;
                        cmd.Parameters.Add("@norden", SqlDbType.Int).Value = BE.norden;
                        cmd.Parameters.Add("@ver_blanco", SqlDbType.Int).Value = BE.ver_blanco;
                        cmd.Parameters.Add("@solopdt", SqlDbType.Int).Value = BE.solopdt;
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

        public DataSet GetAll_ConsultaTipo(string empresaid, tb_plla_tipoplanilla BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaTipoPlanilla_CONSULTA", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = BE.Tipoplla;
                        //cmd.Parameters.Add("@norden", SqlDbType.Int).Value = BE.norden;
                        //cmd.Parameters.Add("@consolidar", SqlDbType.Int).Value = BE.consolidar;
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
        
        public DataSet GetOne(string empresaid, string tipoplla)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaTipoplla_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char, 1).Value = tipoplla;
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
