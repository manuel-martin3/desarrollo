using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_pp_requerimientoprodDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_pp_requerimientoprod BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbReqProd_INSERT_UPDATE", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tipreq", SqlDbType.Char, 2).Value = BE.tipreq;
                    cmd.Parameters.Add("@serreq", SqlDbType.Char, 4).Value = BE.serreq;
                    cmd.Parameters.Add("@numreq", SqlDbType.Char, 10).Value = BE.numreq;
                    cmd.Parameters.Add("@servcorteid", SqlDbType.Char, 2).Value = BE.servcorteid;                    
                    cmd.Parameters.Add("@fechini", SqlDbType.DateTime).Value = BE.fechini;
                    cmd.Parameters.Add("@fechfin", SqlDbType.DateTime).Value = BE.fechfin;
                    cmd.Parameters.Add("@estado", SqlDbType.Char, 2).Value = BE.estado;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    cmd.Parameters.Add("@observacion", SqlDbType.VarChar, 250).Value = BE.observ;
                    cmd.Parameters.Add("@idx", SqlDbType.Char, 3).Value = BE.idx;

                    cmd.Parameters.Add("@XML", SqlDbType.Xml).Value = BE.GetItemXML();
                    //cmd.Parameters.Add("@XMLColor", SqlDbType.Xml).Value = BE.GetItemXMLColor();

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

        public bool Update(string empresaid, tb_pp_requerimientoprod BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbReqprod_INSERT_UPDATE", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tipreq", SqlDbType.Char, 2).Value = BE.tipreq;
                    cmd.Parameters.Add("@serreq", SqlDbType.Char, 4).Value = BE.serreq;
                    cmd.Parameters.Add("@numreq", SqlDbType.Char, 10).Value = BE.numreq;
                    cmd.Parameters.Add("@servcorteid", SqlDbType.Char, 2).Value = BE.servcorteid;
                    cmd.Parameters.Add("@fechini", SqlDbType.DateTime).Value = BE.fechini;
                    cmd.Parameters.Add("@fechfin", SqlDbType.DateTime).Value = BE.fechfin;
                    cmd.Parameters.Add("@estado", SqlDbType.Char, 2).Value = BE.estado;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    cmd.Parameters.Add("@observacion", SqlDbType.VarChar, 250).Value = BE.observ;
                    cmd.Parameters.Add("@idx", SqlDbType.Char, 3).Value = BE.idx;

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

        public bool Delete(string empresaid, tb_pp_requerimientoprod BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbReqProd_INSERT_UPDATE", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tipreq", SqlDbType.Char, 2).Value = BE.tipreq;
                    cmd.Parameters.Add("@serreq", SqlDbType.Char, 4).Value = BE.serreq;
                    cmd.Parameters.Add("@numreq", SqlDbType.Char, 10).Value = BE.numreq;
                    cmd.Parameters.Add("@servcorteid", SqlDbType.Char, 2).Value = BE.servcorteid;
                    cmd.Parameters.Add("@fechini", SqlDbType.DateTime).Value = BE.fechini;
                    cmd.Parameters.Add("@fechfin", SqlDbType.DateTime).Value = BE.fechfin;
                    cmd.Parameters.Add("@estado", SqlDbType.Char, 2).Value = BE.estado;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    cmd.Parameters.Add("@observacion", SqlDbType.VarChar, 250).Value = BE.observ;
                    cmd.Parameters.Add("@idx", SqlDbType.Char, 3).Value = BE.idx;

                    //cmd.Parameters.Add("@XML", SqlDbType.Xml).Value = BE.GetItemXML();                   

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


        public DataSet GetAll_NUM(string empresaid, tb_pp_requerimientoprod BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbReqProdserie_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@dominioid", SqlDbType.Char, 2).Value = BE.dominioid;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.localid;

                        cmd.Parameters.Add("@tipreq", SqlDbType.Char, 2).Value = BE.tipreq;
                        cmd.Parameters.Add("@serreq", SqlDbType.Char, 4).Value = BE.serreq;
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

        public DataSet GetAllCab(string empresaid, tb_pp_requerimientoprod BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbReqProd_SEARCH_PIVOT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipreq", SqlDbType.Char, 2).Value = BE.tipreq;
                        cmd.Parameters.Add("@serreq", SqlDbType.Char, 4).Value = BE.serreq;
                        cmd.Parameters.Add("@numreq", SqlDbType.Char, 10).Value = BE.numreq;
                        cmd.Parameters.Add("@idx", SqlDbType.Char, 3).Value = BE.idx;
                     
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

        public DataSet GetAllDet(string empresaid, tb_pp_requerimientoprod BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbReqProd_SEARCH_PIVOT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipreq", SqlDbType.Char, 2).Value = BE.tipreq;
                        cmd.Parameters.Add("@serreq", SqlDbType.Char, 4).Value = BE.serreq;
                        cmd.Parameters.Add("@numreq", SqlDbType.Char, 10).Value = BE.numreq;
                        cmd.Parameters.Add("@idx", SqlDbType.Char, 3).Value = BE.idx;
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

        public DataSet GetAllOrden_PIVOT(string empresaid, tb_pp_requerimientoprod BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbReqProd_SEARCH_PIVOT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipop", SqlDbType.Char, 2).Value = BE.tipop;
                        cmd.Parameters.Add("@serop", SqlDbType.Char, 4).Value = BE.serop;
                        cmd.Parameters.Add("@numop", SqlDbType.Char, 10).Value = BE.numop;
                        cmd.Parameters.Add("@idx", SqlDbType.Char, 3).Value = BE.idx;    
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

        public DataSet GetAllPropColor_PIVOT(string empresaid, tb_pp_requerimientoprod BE1)
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


        public DataSet GetOne(string empresaid, tb_pp_requerimientoprod BE)
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


        public DataSet GetAll_RptProd(string empresaid, tb_pp_requerimientoprod BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                //using (SqlCommand cmd = new SqlCommand("gspTb_RptMain_ReqProduccion", cnx))
                using (SqlCommand cmd = new SqlCommand("gspTb_RptMain_ReqProduc", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@tipop", SqlDbType.Char, 2).Value = BE.tipop;
                        //cmd.Parameters.Add("@serop", SqlDbType.Char, 4).Value = BE.serop;
                        //cmd.Parameters.Add("@numop", SqlDbType.Char, 10).Value = BE.numop;   
                        cmd.Parameters.Add("@tipreq", SqlDbType.Char, 2).Value = BE.tipreq;
                        cmd.Parameters.Add("@serreq", SqlDbType.Char, 4).Value = BE.serreq;
                        cmd.Parameters.Add("@numreq", SqlDbType.Char, 10).Value = BE.numreq;  
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


        public DataSet GetOne_Tallaid(string empresaid, tb_pp_requerimientoprod BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb_idTalla", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipreq", SqlDbType.Char, 2).Value = BE.tipreq;
                        cmd.Parameters.Add("@serreq", SqlDbType.Char, 4).Value = BE.serreq;
                        cmd.Parameters.Add("@numreq", SqlDbType.Char, 10).Value = BE.numreq;                       
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
