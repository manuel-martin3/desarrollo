using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_co_ConfigcuentasrhredDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_co_Configcuentasrhred BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoConfigcuentasrhred_INSERT", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                    cmd.Parameters.Add("@cuentaidsol", SqlDbType.Char, 10).Value = BE.cuentaidsol;
                    cmd.Parameters.Add("@cuentaiddol", SqlDbType.Char, 10).Value = BE.cuentaiddol;
                    cmd.Parameters.Add("@cuentaidret", SqlDbType.Char, 10).Value = BE.cuentaidret;
                    cmd.Parameters.Add("@cuentaiddifganancia", SqlDbType.Char, 10).Value = BE.cuentaiddifganancia;
                    cmd.Parameters.Add("@cuentaiddifperdida", SqlDbType.Char, 10).Value = BE.cuentaiddifperdida;
                    cmd.Parameters.Add("@cuentaidredondeog", SqlDbType.Char, 10).Value = BE.cuentaidredondeog;
                    cmd.Parameters.Add("@cuentaidredondeop", SqlDbType.Char, 10).Value = BE.cuentaidredondeop;
                    cmd.Parameters.Add("@cuentaidonp", SqlDbType.Char, 10).Value = BE.cuentaidonp;
                    cmd.Parameters.Add("@cuentaidafp", SqlDbType.Char, 10).Value = BE.cuentaidafp;
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

        public bool Update(string empresaid, tb_co_Configcuentasrhred BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoConfigcuentasrhred_UPDATE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@cuentaidsol", SqlDbType.Char, 10).Value = BE.cuentaidsol;
                        cmd.Parameters.Add("@cuentaiddol", SqlDbType.Char, 10).Value = BE.cuentaiddol;
                        cmd.Parameters.Add("@cuentaidret", SqlDbType.Char, 10).Value = BE.cuentaidret;
                        cmd.Parameters.Add("@cuentaiddifganancia", SqlDbType.Char, 10).Value = BE.cuentaiddifganancia;
                        cmd.Parameters.Add("@cuentaiddifperdida", SqlDbType.Char, 10).Value = BE.cuentaiddifperdida;
                        cmd.Parameters.Add("@cuentaidredondeog", SqlDbType.Char, 10).Value = BE.cuentaidredondeog;
                        cmd.Parameters.Add("@cuentaidredondeop", SqlDbType.Char, 10).Value = BE.cuentaidredondeop;
                        cmd.Parameters.Add("@cuentaidonp", SqlDbType.Char, 10).Value = BE.cuentaidonp;
                        cmd.Parameters.Add("@cuentaidafp", SqlDbType.Char, 10).Value = BE.cuentaidafp;
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

        public bool Delete(string empresaid, tb_co_Configcuentasrhred BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoConfigcuentasrhred_DELETE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 1).Value = BE.diarioid;
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

        public DataSet GetAll(string empresaid, tb_co_Configcuentasrhred BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoConfigcuentasrhred_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@cuentaidsol", SqlDbType.Char, 10).Value = BE.cuentaidsol;
                        cmd.Parameters.Add("@cuentaiddol", SqlDbType.Char, 10).Value = BE.cuentaiddol;
                        cmd.Parameters.Add("@cuentaidret", SqlDbType.Char, 10).Value = BE.cuentaidret;
                        cmd.Parameters.Add("@cuentaiddifganancia", SqlDbType.Char, 10).Value = BE.cuentaiddifganancia;
                        cmd.Parameters.Add("@cuentaiddifperdida", SqlDbType.Char, 10).Value = BE.cuentaiddifperdida;
                        cmd.Parameters.Add("@cuentaidredondeog", SqlDbType.Char, 10).Value = BE.cuentaidredondeog;
                        cmd.Parameters.Add("@cuentaidredondeop", SqlDbType.Char, 10).Value = BE.cuentaidredondeop;
                        cmd.Parameters.Add("@cuentaidonp", SqlDbType.Char, 10).Value = BE.cuentaidonp;
                        cmd.Parameters.Add("@cuentaidafp", SqlDbType.Char, 10).Value = BE.cuentaidafp;
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

        public DataSet Consulta_ConfigCuentas(string empresaid, tb_co_Configcuentasrhred BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoConfigcuentasrhred_SEARCH2", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
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

        public DataSet GetOne(string empresaid, string diarioid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoConfigcuentasrhred_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 1).Value = diarioid;
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
