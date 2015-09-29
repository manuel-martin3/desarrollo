using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_pp_ordenservicioDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_pp_ordenservicio BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbpp_ordenserv_INSERT_UPDATE", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tipos", SqlDbType.Char, 2).Value = BE.tipos;
                    cmd.Parameters.Add("@seros", SqlDbType.Char, 4).Value = BE.seros;
                    cmd.Parameters.Add("@numos", SqlDbType.Char, 10).Value = BE.numos;
                    cmd.Parameters.Add("@fechini", SqlDbType.DateTime).Value = BE.fechini;
                    cmd.Parameters.Add("@fechfin", SqlDbType.DateTime).Value = BE.fechfin;
                    cmd.Parameters.Add("@precprenda", SqlDbType.Bit).Value = BE.precprenda;
                    cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = BE.cantidad;
                    cmd.Parameters.Add("@peso", SqlDbType.Decimal).Value = BE.peso;
                    cmd.Parameters.Add("@moneda", SqlDbType.Char).Value = BE.moneda;
                    cmd.Parameters.Add("@tcambio", SqlDbType.Decimal).Value = BE.tcambio;
                    cmd.Parameters.Add("@bimpo", SqlDbType.Decimal).Value = BE.bimpo;
                    cmd.Parameters.Add("@migv", SqlDbType.Decimal).Value = BE.migv;
                    cmd.Parameters.Add("@pvent", SqlDbType.Decimal).Value = BE.pvent;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@tipop", SqlDbType.Char, 2).Value = BE.tipop;
                    cmd.Parameters.Add("@serop", SqlDbType.Char, 4).Value = BE.serop;
                    cmd.Parameters.Add("@numop", SqlDbType.Char, 10).Value = BE.numop;
                    cmd.Parameters.Add("@secuencia", SqlDbType.Int).Value = BE.secuencia;
                    cmd.Parameters.Add("@faseid", SqlDbType.Int).Value = BE.faseid;
                    cmd.Parameters.Add("@estado", SqlDbType.Char, 2).Value = BE.estado;
                    cmd.Parameters.Add("@tipfac", SqlDbType.Char, 2).Value = BE.tipfac;
                    cmd.Parameters.Add("@serfac", SqlDbType.Char, 4).Value = BE.serfac;
                    cmd.Parameters.Add("@numfac", SqlDbType.Char, 10).Value = BE.numfac;
                    cmd.Parameters.Add("@tipgr", SqlDbType.Char, 2).Value = BE.tipgr;
                    cmd.Parameters.Add("@sergr", SqlDbType.Char, 4).Value = BE.sergr;
                    cmd.Parameters.Add("@numgr", SqlDbType.Char, 10).Value = BE.numgr;
                    cmd.Parameters.Add("@tipfas", SqlDbType.Char, 2).Value = BE.tipfas;
                    cmd.Parameters.Add("@serfas", SqlDbType.Char, 4).Value = BE.serfas;
                    cmd.Parameters.Add("@numfas", SqlDbType.Char, 10).Value = BE.numfas;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    cmd.Parameters.Add("@fecre", SqlDbType.DateTime).Value = BE.fecre;
                    cmd.Parameters.Add("@feact", SqlDbType.DateTime).Value = BE.feact;
                    cmd.Parameters.Add("@observacion", SqlDbType.VarChar, 250).Value = BE.observacion;

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

        public bool Update(string empresaid, tb_pp_ordenservicio BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbpp_ordenserv_INSERT_UPDATE", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tipos", SqlDbType.Char, 2).Value = BE.tipos;
                    cmd.Parameters.Add("@seros", SqlDbType.Char, 4).Value = BE.seros;
                    cmd.Parameters.Add("@numos", SqlDbType.Char, 10).Value = BE.numos;
                    cmd.Parameters.Add("@fechini", SqlDbType.DateTime).Value = BE.fechini;
                    cmd.Parameters.Add("@fechfin", SqlDbType.DateTime).Value = BE.fechfin;
                    cmd.Parameters.Add("@precprenda", SqlDbType.Bit).Value = BE.precprenda;
                    cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = BE.cantidad;
                    cmd.Parameters.Add("@peso", SqlDbType.Decimal).Value = BE.peso;
                    cmd.Parameters.Add("@moneda", SqlDbType.Char).Value = BE.moneda;
                    cmd.Parameters.Add("@tcambio", SqlDbType.Decimal).Value = BE.tcambio;
                    cmd.Parameters.Add("@bimpo", SqlDbType.Decimal).Value = BE.bimpo;
                    cmd.Parameters.Add("@migv", SqlDbType.Decimal).Value = BE.migv;
                    cmd.Parameters.Add("@pvent", SqlDbType.Decimal).Value = BE.pvent;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@tipop", SqlDbType.Char, 2).Value = BE.tipop;
                    cmd.Parameters.Add("@serop", SqlDbType.Char, 4).Value = BE.serop;
                    cmd.Parameters.Add("@numop", SqlDbType.Char, 10).Value = BE.numop;
                    cmd.Parameters.Add("@secuencia", SqlDbType.Int).Value = BE.secuencia;
                    cmd.Parameters.Add("@faseid", SqlDbType.Int).Value = BE.faseid;
                    cmd.Parameters.Add("@estado", SqlDbType.Char, 2).Value = BE.estado;
                    cmd.Parameters.Add("@tipfac", SqlDbType.Char, 2).Value = BE.tipfac;
                    cmd.Parameters.Add("@serfac", SqlDbType.Char, 4).Value = BE.serfac;
                    cmd.Parameters.Add("@numfac", SqlDbType.Char, 10).Value = BE.numfac;
                    cmd.Parameters.Add("@tipgr", SqlDbType.Char, 2).Value = BE.tipgr;
                    cmd.Parameters.Add("@sergr", SqlDbType.Char, 4).Value = BE.sergr;
                    cmd.Parameters.Add("@numgr", SqlDbType.Char, 10).Value = BE.numgr;
                    cmd.Parameters.Add("@tipfas", SqlDbType.Char, 2).Value = BE.tipfas;
                    cmd.Parameters.Add("@serfas", SqlDbType.Char, 4).Value = BE.serfas;
                    cmd.Parameters.Add("@numfas", SqlDbType.Char, 10).Value = BE.numfas;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    cmd.Parameters.Add("@fecre", SqlDbType.DateTime).Value = BE.fecre;
                    cmd.Parameters.Add("@feact", SqlDbType.DateTime).Value = BE.feact;
                    cmd.Parameters.Add("@observacion", SqlDbType.VarChar, 250).Value = BE.observacion;

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

        public bool Delete(string empresaid, tb_pp_ordenservicio BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("", cnx))
                {                                  




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

        public DataSet GetAll_NUM(string empresaid, tb_pp_ordenservicio BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbpp_ordenserv_serie_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@dominioid", SqlDbType.Char, 2).Value = BE.dominioid;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.localid;
                        cmd.Parameters.Add("@tipos", SqlDbType.Char, 2).Value = BE.tipos;
                        cmd.Parameters.Add("@seros", SqlDbType.Char, 4).Value = BE.seros;
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

        public DataSet GetAllOrden_PIVOT(string empresaid, tb_pp_ordenservicio BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@tipop", SqlDbType.Char, 2).Value = BE.tipop;
                        //cmd.Parameters.Add("@serop", SqlDbType.Char, 4).Value = BE.serop;
                        //cmd.Parameters.Add("@numop", SqlDbType.Char, 10).Value = BE.numop;
                        //cmd.Parameters.Add("@idx", SqlDbType.Char, 3).Value = BE.idx;    
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

        public DataSet GetAllPropColor_PIVOT(string empresaid, tb_pp_ordenservicio BE1)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd1 = new SqlCommand("", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd1.CommandType = CommandType.StoredProcedure;
                        //cmd1.Parameters.Add("@tipop", SqlDbType.Char, 2).Value = BE1.tipop;
                        //cmd1.Parameters.Add("@serop", SqlDbType.Char, 4).Value = BE1.serop;
                        //cmd1.Parameters.Add("@numop", SqlDbType.Char, 10).Value = BE1.numop;
                    }
                    try
                    {
                        cnx.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
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

        public DataSet GetOne(string empresaid, tb_pp_ordenservicio BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        //cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        //cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        //cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        //cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
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

        public DataSet GetAllCab(string empresaid, tb_pp_ordenservicio BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbpp_ordenserv_CAB_DET_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipos", SqlDbType.Char, 2).Value = BE.tipos;
                        cmd.Parameters.Add("@seros", SqlDbType.Char, 4).Value = BE.seros;
                        cmd.Parameters.Add("@numos", SqlDbType.Char, 10).Value = BE.numos;
                        cmd.Parameters.Add("@Idx", SqlDbType.Char, 3).Value = BE.Idx;
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

        public DataSet GetAllDet(string empresaid, tb_pp_ordenservicio BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbpp_ordenserv_CAB_DET_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipos", SqlDbType.Char, 2).Value = BE.tipos;
                        cmd.Parameters.Add("@seros", SqlDbType.Char, 4).Value = BE.seros;
                        cmd.Parameters.Add("@numos", SqlDbType.Char, 10).Value = BE.numos;
                        cmd.Parameters.Add("@Idx", SqlDbType.Char, 3).Value = BE.Idx;
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
