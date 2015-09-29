using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_pp_hojacostocabDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_pp_hojacostocab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPpHojacostocab_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
                    cmd.Parameters.Add("@version", SqlDbType.Char, 3).Value = BE.version;
                    cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = BE.fecha;
                    cmd.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = BE.cantidad;
                    cmd.Parameters.Add("@costoprimo", SqlDbType.Decimal).Value = BE.costoprimo;
                    cmd.Parameters.Add("@percgadm", SqlDbType.Decimal).Value = BE.percgadm;
                    cmd.Parameters.Add("@percgvta", SqlDbType.Decimal).Value = BE.percgvta;
                    cmd.Parameters.Add("@percgfin", SqlDbType.Decimal).Value = BE.percgfin;
                    cmd.Parameters.Add("@gastoadm", SqlDbType.Decimal).Value = BE.gastoadm;
                    cmd.Parameters.Add("@gastovta", SqlDbType.Decimal).Value = BE.gastovta;
                    cmd.Parameters.Add("@gastofin", SqlDbType.Decimal).Value = BE.gastofin;
                    cmd.Parameters.Add("@gastopera", SqlDbType.Decimal).Value = BE.gastopera;
                    cmd.Parameters.Add("@costototal", SqlDbType.Decimal).Value = BE.costototal;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;

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

        public bool Update(string empresaid, tb_pp_hojacostocab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPpHojacostocab_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
                        cmd.Parameters.Add("@version", SqlDbType.Char, 3).Value = BE.version;
                        cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = BE.fecha;
                        cmd.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = BE.cantidad;
                        cmd.Parameters.Add("@costoprimo", SqlDbType.Decimal).Value = BE.costoprimo;
                        cmd.Parameters.Add("@percgadm", SqlDbType.Decimal).Value = BE.percgadm;
                        cmd.Parameters.Add("@percgvta", SqlDbType.Decimal).Value = BE.percgvta;
                        cmd.Parameters.Add("@percgfin", SqlDbType.Decimal).Value = BE.percgfin;
                        cmd.Parameters.Add("@gastoadm", SqlDbType.Decimal).Value = BE.gastoadm;
                        cmd.Parameters.Add("@gastovta", SqlDbType.Decimal).Value = BE.gastovta;
                        cmd.Parameters.Add("@gastofin", SqlDbType.Decimal).Value = BE.gastofin;
                        cmd.Parameters.Add("@gastopera", SqlDbType.Decimal).Value = BE.gastopera;
                        cmd.Parameters.Add("@costototal", SqlDbType.Decimal).Value = BE.costototal;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
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

        public bool Delete(string empresaid, tb_pp_hojacostocab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPpHojacostocab_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
                        cmd.Parameters.Add("@version", SqlDbType.Char, 3).Value = BE.version;
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

        public DataSet GetAll(string empresaid, tb_pp_hojacostocab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPpHojacostocab_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
                        cmd.Parameters.Add("@articidold", SqlDbType.VarChar, 8).Value = BE.articidold;
                        cmd.Parameters.Add("@version", SqlDbType.Char, 3).Value = BE.version;             
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

        public DataSet GetAll_Version(string empresaid, tb_pp_hojacostocab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPpHojacostocab_SEARCH_Version", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
                        cmd.Parameters.Add("@version", SqlDbType.Char, 3).Value = BE.version;
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

        public DataSet GetOne(string empresaid, string detraccionid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoDetraccion_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@detraccionid", SqlDbType.Char, 5).Value = detraccionid;
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
