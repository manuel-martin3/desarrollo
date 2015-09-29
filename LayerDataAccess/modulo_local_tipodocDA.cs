using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class modulo_local_tipodocDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_modulo_local_tipodoc BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbModuloLocalTipodoc_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@dominioid", SqlDbType.Char, 2).Value = BE.dominioid;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                    cmd.Parameters.Add("@tipodocname", SqlDbType.VarChar, 40).Value = BE.tipodocname;
                    cmd.Parameters.Add("@tipodocmanejaserie", SqlDbType.Bit).Value = BE.tipodocmanejaserie;
                    cmd.Parameters.Add("@tipodocnumero", SqlDbType.Decimal).Value = BE.tipodocnumero;
                    cmd.Parameters.Add("@tipodocautomatico", SqlDbType.Bit).Value = BE.tipodocautomatico;
                    cmd.Parameters.Add("@tipodocnumcopias", SqlDbType.Int).Value = BE.tipodocnumcopias;
                    cmd.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE.almacaccionid;
                    cmd.Parameters.Add("@tipodoccontratipo", SqlDbType.Char, 2).Value = BE.tipodoccontratipo;
                    cmd.Parameters.Add("@tipodoctipotransac", SqlDbType.Char, 1).Value = BE.tipodoctipotransac;
                    cmd.Parameters.Add("@tipodocstatcostopromed", SqlDbType.Char, 1).Value = BE.tipodocstatcostopromed;
                    cmd.Parameters.Add("@ctacteaccionid", SqlDbType.Char, 2).Value = BE.ctacteaccionid;
                    cmd.Parameters.Add("@visiblealmac", SqlDbType.Bit).Value = BE.visiblealmac;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
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

        public bool Update(string empresaid, tb_modulo_local_tipodoc BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbModuloLocalTipodoc_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@dominioid", SqlDbType.Char, 2).Value = BE.dominioid;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@tipodocname", SqlDbType.VarChar, 40).Value = BE.tipodocname;
                        cmd.Parameters.Add("@tipodocmanejaserie", SqlDbType.Bit).Value = BE.tipodocmanejaserie;
                        cmd.Parameters.Add("@tipodocnumero", SqlDbType.Decimal).Value = BE.tipodocnumero;
                        cmd.Parameters.Add("@tipodocautomatico", SqlDbType.Bit).Value = BE.tipodocautomatico;
                        cmd.Parameters.Add("@tipodocnumcopias", SqlDbType.Int).Value = BE.tipodocnumcopias;
                        cmd.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE.almacaccionid;
                        cmd.Parameters.Add("@tipodoccontratipo", SqlDbType.Char, 2).Value = BE.tipodoccontratipo;
                        cmd.Parameters.Add("@tipodoctipotransac", SqlDbType.Char, 1).Value = BE.tipodoctipotransac;
                        cmd.Parameters.Add("@tipodocstatcostopromed", SqlDbType.Char, 1).Value = BE.tipodocstatcostopromed;
                        cmd.Parameters.Add("@ctacteaccionid", SqlDbType.Char, 2).Value = BE.ctacteaccionid;
                        cmd.Parameters.Add("@visiblealmac", SqlDbType.Bit).Value = BE.visiblealmac;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
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

        public bool Delete(string empresaid, tb_modulo_local_tipodoc BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbModuloLocalTipodoc_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@dominioid", SqlDbType.Char, 2).Value = BE.dominioid;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
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

        public DataSet GetAll(string empresaid, tb_modulo_local_tipodoc BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbModuloLocalTipodoc_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@dominioid", SqlDbType.Char, 2).Value = BE.dominioid;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@tipodocname", SqlDbType.VarChar, 40).Value = BE.tipodocname;
                        cmd.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE.almacaccionid;
                        cmd.Parameters.Add("@tipodoccontratipo", SqlDbType.Char, 2).Value = BE.tipodoccontratipo;
                        cmd.Parameters.Add("@tipodoctipotransac", SqlDbType.Char, 1).Value = BE.tipodoctipotransac;
                        cmd.Parameters.Add("@tipodocstatcostopromed", SqlDbType.Char, 1).Value = BE.tipodocstatcostopromed;
                        cmd.Parameters.Add("@ctacteaccionid", SqlDbType.Char, 2).Value = BE.ctacteaccionid;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
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

        public DataSet GetAll_paginacion(string empresaid, tb_modulo_local_tipodoc BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbModuloLocalTipodoc_SEARCH_paginacion", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@dominioid", SqlDbType.Char, 2).Value = BE.dominioid;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@posicion", SqlDbType.VarChar, 10).Value = BE.posicion;
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

        public DataSet GetAll_mov(string empresaid, tb_modulo_local_tipodoc BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbModuloLocalTipodoc_SEARCH_mov", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@dominioid", SqlDbType.Char, 2).Value = BE.dominioid;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@visiblealmac", SqlDbType.Bit).Value = BE.visiblealmac;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@tipodoctipotransac", SqlDbType.Char,1).Value = BE.tipodoctipotransac;
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

        public DataSet GetOne(string empresaid, string dominioid, string moduloid, string local, string tipodoc)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbModuloLocalTipodoc_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@dominioid", SqlDbType.Char, 2).Value = dominioid;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = tipodoc;
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
