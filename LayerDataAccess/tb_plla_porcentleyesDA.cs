﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_plla_porcentleyesDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_plla_porcentleyes BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPorcentleyes_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd.Parameters.Add("@onpt", SqlDbType.Decimal).Value = BE.onpt;
                    cmd.Parameters.Add("@essaludt", SqlDbType.Decimal).Value = BE.essaludt;
                    cmd.Parameters.Add("@senatit", SqlDbType.Decimal).Value = BE.senatit;
                    cmd.Parameters.Add("@sctrt", SqlDbType.Decimal).Value = BE.sctrt;
                    cmd.Parameters.Add("@otrost", SqlDbType.Decimal).Value = BE.otrost;
                    cmd.Parameters.Add("@onpe", SqlDbType.Decimal).Value = BE.onpe;
                    cmd.Parameters.Add("@essalude", SqlDbType.Decimal).Value = BE.essalude;
                    cmd.Parameters.Add("@senatie", SqlDbType.Decimal).Value = BE.senatie;
                    cmd.Parameters.Add("@sctre", SqlDbType.Decimal).Value = BE.sctre;
                    cmd.Parameters.Add("@otrose", SqlDbType.Decimal).Value = BE.otrose;
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

        public bool BapSoft_PorcentajesLeyesInsert(string empresaid, tb_plla_porcentleyes BE, DataTable TablaDatos)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                bool xreturn = true;
                int lcont = 0;
                
                for (lcont = 0; lcont <= TablaDatos.Rows.Count - 1; lcont++)
                {
                    using (SqlCommand cmd = new SqlCommand("gspTbPllaPorcentleyesTrabajadorEmpleador_INSERT", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = TablaDatos.Rows[lcont]["perianio"];
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = TablaDatos.Rows[lcont]["perimes"];
                        cmd.Parameters.Add("@onpt", SqlDbType.Decimal).Value = TablaDatos.Rows[lcont]["onpt"];
                        cmd.Parameters.Add("@essaludt", SqlDbType.Decimal).Value = TablaDatos.Rows[lcont]["essaludt"];
                        cmd.Parameters.Add("@senatit", SqlDbType.Decimal).Value = TablaDatos.Rows[lcont]["senatit"];
                        cmd.Parameters.Add("@sctrt", SqlDbType.Decimal).Value = TablaDatos.Rows[lcont]["sctrt"];
                        cmd.Parameters.Add("@otrost", SqlDbType.Decimal).Value = TablaDatos.Rows[lcont]["otrost"];
                        cmd.Parameters.Add("@onpe", SqlDbType.Decimal).Value = TablaDatos.Rows[lcont]["onpe"];
                        cmd.Parameters.Add("@essalude", SqlDbType.Decimal).Value = TablaDatos.Rows[lcont]["essalude"];
                        cmd.Parameters.Add("@senatie", SqlDbType.Decimal).Value = TablaDatos.Rows[lcont]["senatie"];
                        cmd.Parameters.Add("@sctre", SqlDbType.Decimal).Value = TablaDatos.Rows[lcont]["sctre"];
                        cmd.Parameters.Add("@otrose", SqlDbType.Decimal).Value = TablaDatos.Rows[lcont]["otrose"];

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

        public bool Update(string empresaid, tb_plla_porcentleyes BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPorcentleyes_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@onpt", SqlDbType.Decimal).Value = BE.onpt;
                        cmd.Parameters.Add("@essaludt", SqlDbType.Decimal).Value = BE.essaludt;
                        cmd.Parameters.Add("@senatit", SqlDbType.Decimal).Value = BE.senatit;
                        cmd.Parameters.Add("@sctrt", SqlDbType.Decimal).Value = BE.sctrt;
                        cmd.Parameters.Add("@otrost", SqlDbType.Decimal).Value = BE.otrost;
                        cmd.Parameters.Add("@onpe", SqlDbType.Decimal).Value = BE.onpe;
                        cmd.Parameters.Add("@essalude", SqlDbType.Decimal).Value = BE.essalude;
                        cmd.Parameters.Add("@senatie", SqlDbType.Decimal).Value = BE.senatie;
                        cmd.Parameters.Add("@sctre", SqlDbType.Decimal).Value = BE.sctre;
                        cmd.Parameters.Add("@otrose", SqlDbType.Decimal).Value = BE.otrose;
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

        public bool Delete(string empresaid, tb_plla_porcentleyes BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPorcentleyes_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
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

        public DataSet GetAll(string empresaid, tb_plla_porcentleyes BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPorcentleyes_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        //cmd.Parameters.Add("@onpt", SqlDbType.Decimal).Value = BE.onpt;
                        //cmd.Parameters.Add("@essaludt", SqlDbType.Decimal).Value = BE.essaludt;
                        //cmd.Parameters.Add("@senatit", SqlDbType.Decimal).Value = BE.senatit;
                        //cmd.Parameters.Add("@sctrt", SqlDbType.Decimal).Value = BE.sctrt;
                        //cmd.Parameters.Add("@otrost", SqlDbType.Decimal).Value = BE.otrost;
                        //cmd.Parameters.Add("@onpe", SqlDbType.Decimal).Value = BE.onpe;
                        //cmd.Parameters.Add("@essalude", SqlDbType.Decimal).Value = BE.essalude;
                        //cmd.Parameters.Add("@senatie", SqlDbType.Decimal).Value = BE.senatie;
                        //cmd.Parameters.Add("@sctre", SqlDbType.Decimal).Value = BE.sctre;
                        //cmd.Parameters.Add("@otrose", SqlDbType.Decimal).Value = BE.otrose;
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

        public DataSet GetAll_Consulta(string empresaid, tb_plla_porcentleyes BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPorcentleyes_CONSULTA", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        //cmd.Parameters.Add("@onpt", SqlDbType.Decimal).Value = BE.onpt;
                        //cmd.Parameters.Add("@essaludt", SqlDbType.Decimal).Value = BE.essaludt;
                        //cmd.Parameters.Add("@senatit", SqlDbType.Decimal).Value = BE.senatit;
                        //cmd.Parameters.Add("@sctrt", SqlDbType.Decimal).Value = BE.sctrt;
                        //cmd.Parameters.Add("@otrost", SqlDbType.Decimal).Value = BE.otrost;
                        //cmd.Parameters.Add("@onpe", SqlDbType.Decimal).Value = BE.onpe;
                        //cmd.Parameters.Add("@essalude", SqlDbType.Decimal).Value = BE.essalude;
                        //cmd.Parameters.Add("@senatie", SqlDbType.Decimal).Value = BE.senatie;
                        //cmd.Parameters.Add("@sctre", SqlDbType.Decimal).Value = BE.sctre;
                        //cmd.Parameters.Add("@otrose", SqlDbType.Decimal).Value = BE.otrose;
                        //cmd.Parameters.Add("@estado", SqlDbType.Char, 1).Value = BE.estado;
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

        public DataSet GetOne(string empresaid, tb_plla_porcentleyes BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaPorcentleyes_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        //cmd.Parameters.Add("@onpt", SqlDbType.Decimal).Value = BE.onpt;
                        //cmd.Parameters.Add("@essaludt", SqlDbType.Decimal).Value = BE.essaludt;
                        //cmd.Parameters.Add("@senatit", SqlDbType.Decimal).Value = BE.senatit;
                        //cmd.Parameters.Add("@sctrt", SqlDbType.Decimal).Value = BE.sctrt;
                        //cmd.Parameters.Add("@otrost", SqlDbType.Decimal).Value = BE.otrost;
                        //cmd.Parameters.Add("@onpe", SqlDbType.Decimal).Value = BE.onpe;
                        //cmd.Parameters.Add("@essalude", SqlDbType.Decimal).Value = BE.essalude;
                        //cmd.Parameters.Add("@senatie", SqlDbType.Decimal).Value = BE.senatie;
                        //cmd.Parameters.Add("@sctre", SqlDbType.Decimal).Value = BE.sctre;
                        //cmd.Parameters.Add("@otrose", SqlDbType.Decimal).Value = BE.otrose;
                        //cmd.Parameters.Add("@estado", SqlDbType.Char, 1).Value = BE.estado;
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
