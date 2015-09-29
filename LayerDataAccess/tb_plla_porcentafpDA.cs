using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_plla_porcentafpDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_plla_porcentafp BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPorcentafp_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@regipenid", SqlDbType.Char, 2).Value = BE.regipenid;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd.Parameters.Add("@remmaxaseg", SqlDbType.Decimal).Value = BE.remmaxaseg;
                    cmd.Parameters.Add("@aporteobli", SqlDbType.Decimal).Value = BE.aporteobli;
                    cmd.Parameters.Add("@comisionfija", SqlDbType.Decimal).Value = BE.comisionfija;
                    cmd.Parameters.Add("@comisionflujo", SqlDbType.Decimal).Value = BE.comisionflujo;
                    cmd.Parameters.Add("@comisionmixta", SqlDbType.Decimal).Value = BE.comisionmixta;
                    cmd.Parameters.Add("@primaseguro", SqlDbType.Decimal).Value = BE.primaseguro;
                    cmd.Parameters.Add("@estado", SqlDbType.Char, 1).Value = BE.estado;

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

        public bool BapSoft_PorcentajesAFPInsert(string empresaid, tb_plla_porcentafp BE, DataTable TablaDatos)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                bool xreturn = true;
                int lcont = 0;
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPorcentafp_DELETE", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@regipenid", SqlDbType.Char, 2).Value = BE.regipenid;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
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
                for (lcont = 0; lcont <= TablaDatos.Rows.Count - 1; lcont++)
                {
                    using (SqlCommand cmd = new SqlCommand("gspTbPllaPorcentAFPs_INSERT", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@regipenid", SqlDbType.Char, 2).Value = TablaDatos.Rows[lcont]["regipenid"];
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = TablaDatos.Rows[lcont]["perianio"];
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = TablaDatos.Rows[lcont]["perimes"];
                        cmd.Parameters.Add("@remmaxaseg", SqlDbType.Decimal).Value = TablaDatos.Rows[lcont]["remmaxaseg"];
                        cmd.Parameters.Add("@aporteobli", SqlDbType.Decimal).Value = TablaDatos.Rows[lcont]["aporteobli"];
                        cmd.Parameters.Add("@comisionfija", SqlDbType.Decimal).Value = TablaDatos.Rows[lcont]["comisionfija"];
                        cmd.Parameters.Add("@comisionflujo", SqlDbType.Decimal).Value = TablaDatos.Rows[lcont]["comisionflujo"];
                        cmd.Parameters.Add("@comisionmixta", SqlDbType.Decimal).Value = TablaDatos.Rows[lcont]["comisionmixta"];
                        cmd.Parameters.Add("@primaseguro", SqlDbType.Decimal).Value = TablaDatos.Rows[lcont]["primaseguro"];

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

        public bool Update(string empresaid, tb_plla_porcentafp BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPorcentafp_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@regipenid", SqlDbType.Char, 2).Value = BE.regipenid;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@remmaxaseg", SqlDbType.Decimal).Value = BE.remmaxaseg;
                        cmd.Parameters.Add("@aporteobli", SqlDbType.Decimal).Value = BE.aporteobli;
                        cmd.Parameters.Add("@comisionfija", SqlDbType.Decimal).Value = BE.comisionfija;
                        cmd.Parameters.Add("@comisionflujo", SqlDbType.Decimal).Value = BE.comisionflujo;
                        cmd.Parameters.Add("@comisionmixta", SqlDbType.Decimal).Value = BE.comisionmixta;
                        cmd.Parameters.Add("@primaseguro", SqlDbType.Decimal).Value = BE.primaseguro;
                        cmd.Parameters.Add("@estado", SqlDbType.Char, 1).Value = BE.estado;
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

        public bool Delete(string empresaid, tb_plla_porcentafp BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPorcentafp_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@regipenid", SqlDbType.Char, 2).Value = BE.regipenid;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
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

        public DataSet GetAll(string empresaid, tb_plla_porcentafp BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPorcentafp_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@regipenid", SqlDbType.Char, 2).Value = BE.regipenid;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        //cmd.Parameters.Add("@remmaxaseg", SqlDbType.Decimal).Value = BE.remmaxaseg;
                        //cmd.Parameters.Add("@aporteobli", SqlDbType.Decimal).Value = BE.aporteobli;
                        //cmd.Parameters.Add("@comisionfija", SqlDbType.Decimal).Value = BE.comisionfija;
                        //cmd.Parameters.Add("@comisionflujo", SqlDbType.Decimal).Value = BE.comisionflujo;
                        //cmd.Parameters.Add("@comisionmixta", SqlDbType.Decimal).Value = BE.comisionmixta;
                        //cmd.Parameters.Add("@primaseguro", SqlDbType.Decimal).Value = BE.primaseguro;
                        cmd.Parameters.Add("@estado", SqlDbType.Char, 1).Value = BE.estado;
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

        public DataSet GetAll_Consulta(string empresaid, tb_plla_porcentafp BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPorcentafp_CONSULTA", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@regipenid", SqlDbType.Char, 2).Value = BE.regipenid;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
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

        public DataSet GetOne(string empresaid, tb_plla_porcentafp BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPorcentafp_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@regipenid", SqlDbType.Char, 2).Value = BE.regipenid;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
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
