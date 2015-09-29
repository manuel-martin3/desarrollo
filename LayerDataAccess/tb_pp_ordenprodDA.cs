using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_pp_ordenprodDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_pp_ordenprod BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("TbPpOrdenprodcab_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;                  
                    cmd.Parameters.Add("@tipop", SqlDbType.Char, 2).Value = BE.tipop;                    
                    cmd.Parameters.Add("@serop", SqlDbType.Char, 4).Value = BE.serop;
                    cmd.Parameters.Add("@numop", SqlDbType.Char, 10).Value = BE.numop;
                    cmd.Parameters.Add("@fechemi", SqlDbType.DateTime).Value = BE.fechemi;                    
                    cmd.Parameters.Add("@fechini", SqlDbType.DateTime).Value = BE.fechini;                            
                    cmd.Parameters.Add("@fechfin", SqlDbType.DateTime).Value = BE.fechfin;   
                    cmd.Parameters.Add("@estado", SqlDbType.Char, 2).Value = BE.estado;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
                    cmd.Parameters.Add("@canalventaid", SqlDbType.Char, 3).Value = BE.canalventaid;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                    cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                    cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                    cmd.Parameters.Add("@observacion", SqlDbType.VarChar, 250).Value = BE.observacion;
                    cmd.Parameters.Add("@cantprog", SqlDbType.Int).Value = BE.cantprog;
                    cmd.Parameters.Add("@cantreal", SqlDbType.Int).Value = BE.cantreal;
                    cmd.Parameters.Add("@ejecutorid", SqlDbType.Int).Value = BE.ejecutorid;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;

                    cmd.Parameters.Add("@XMLProp", SqlDbType.Xml).Value = BE.GetItemXMLProp();
                    cmd.Parameters.Add("@XMLColor", SqlDbType.Xml).Value = BE.GetItemXMLColor();

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

        public bool InsertFase(string empresaid, tb_pp_ordenprod BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("TbPpOrdenprodfase_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tipop", SqlDbType.Char, 2).Value = BE.tipop;
                    cmd.Parameters.Add("@serop", SqlDbType.Char, 4).Value = BE.serop;
                    cmd.Parameters.Add("@numop", SqlDbType.Char, 10).Value = BE.numop;
                    cmd.Parameters.Add("@secuencia", SqlDbType.Int).Value = BE.secuencia;
                    cmd.Parameters.Add("@faseid", SqlDbType.Int).Value = BE.faseid;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@fechprogIni", SqlDbType.DateTime).Value = BE.fechprogini;
                    cmd.Parameters.Add("@fechprogFin", SqlDbType.DateTime).Value = BE.fechprogfin;
                    cmd.Parameters.Add("@estado", SqlDbType.Char, 2).Value = BE.estado;
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

        public bool InsertMaterial(string empresaid, tb_pp_ordenprod BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("TbPpOrdenprodtela_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tipop", SqlDbType.Char, 2).Value = BE.tipop;
                    cmd.Parameters.Add("@serop", SqlDbType.Char, 4).Value = BE.serop;
                    cmd.Parameters.Add("@numop", SqlDbType.Char, 10).Value = BE.numop;
                    cmd.Parameters.Add("@partepdaid", SqlDbType.Int).Value = BE.partepdaid;
                    cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;

                    cmd.Parameters.Add("@ancho", SqlDbType.Char, 10).Value = BE.ancho; //falta modifica el tipo de dato
                    cmd.Parameters.Add("@gramaje", SqlDbType.Char, 10).Value = BE.gramaje;
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

        public bool Update(string empresaid, tb_pp_ordenprod BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("TbPpOrdenprodcab_UPDATE", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tipop", SqlDbType.Char, 2).Value = BE.tipop;
                    cmd.Parameters.Add("@serop", SqlDbType.Char, 4).Value = BE.serop;
                    cmd.Parameters.Add("@numop", SqlDbType.Char, 10).Value = BE.numop;
                    cmd.Parameters.Add("@fechemi", SqlDbType.DateTime).Value = BE.fechemi;
                    cmd.Parameters.Add("@fechini", SqlDbType.DateTime).Value = BE.fechini;
                    cmd.Parameters.Add("@fechfin", SqlDbType.DateTime).Value = BE.fechfin;
                    //cmd.Parameters.Add("@estado", SqlDbType.Char, 2).Value = BE.estado;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
                    cmd.Parameters.Add("@canalventaid", SqlDbType.Char, 3).Value = BE.canalventaid;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                    cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                    cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                    cmd.Parameters.Add("@observacion", SqlDbType.VarChar, 250).Value = BE.observacion;
                    cmd.Parameters.Add("@cantprog", SqlDbType.Int).Value = BE.cantprog;
                    cmd.Parameters.Add("@cantreal", SqlDbType.Int).Value = BE.cantreal;
                    cmd.Parameters.Add("@ejecutorid", SqlDbType.Int).Value = BE.ejecutorid;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;

                    cmd.Parameters.Add("@XMLProp", SqlDbType.Xml).Value = BE.GetItemXMLProp();
                    cmd.Parameters.Add("@XMLColor", SqlDbType.Xml).Value = BE.GetItemXMLColor();

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

        public bool UpdateFase(string empresaid, tb_pp_ordenprod BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("TbPpOrdenprodfase_UPDATE", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tipop", SqlDbType.Char, 2).Value = BE.tipop;
                    cmd.Parameters.Add("@serop", SqlDbType.Char, 4).Value = BE.serop;
                    cmd.Parameters.Add("@numop", SqlDbType.Char, 10).Value = BE.numop;
                    cmd.Parameters.Add("@secuencia", SqlDbType.Int).Value = BE.secuencia;
                    cmd.Parameters.Add("@faseid", SqlDbType.Int).Value = BE.faseid;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@fechprogIni", SqlDbType.DateTime).Value = BE.fechprogini;
                    cmd.Parameters.Add("@fechprogFin", SqlDbType.DateTime).Value = BE.fechprogfin;
                    //cmd.Parameters.Add("@estado", SqlDbType.Char, 2).Value = BE.estado;
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

        public bool UpdateMaterial(string empresaid, tb_pp_ordenprod BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("TbPpOrdenprodtela_UPDATE", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tipop", SqlDbType.Char, 2).Value = BE.tipop;
                    cmd.Parameters.Add("@serop", SqlDbType.Char, 4).Value = BE.serop;
                    cmd.Parameters.Add("@numop", SqlDbType.Char, 10).Value = BE.numop;
                    cmd.Parameters.Add("@partepdaid", SqlDbType.Int).Value = BE.partepdaid;
                    cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;

                    cmd.Parameters.Add("@ancho", SqlDbType.Char, 10).Value = BE.ancho; //falta modifica el tipo de dato
                    cmd.Parameters.Add("@gramaje", SqlDbType.DateTime).Value = BE.gramaje; 
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

        public bool Update_aprobado(string empresaid, tb_pp_ordenprod BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                SqlTransaction tr = default(SqlTransaction);
                Boolean TransaExito = false;

                using (SqlCommand cmd1 = new SqlCommand("gspTbPtMovimientoscab_UPDATE_aprobado", cnx))
                {
                    cmd1.CommandType = CommandType.StoredProcedure;
                    //cmd1.Parameters.Add("@moduloid", SqlDbType.Char, 2).Value = BE.moduloid;
                    //cmd1.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    //cmd1.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                    //cmd1.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    //cmd1.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    //cmd1.Parameters.Add("@user_apr1", SqlDbType.Char, 15).Value = BE.user_apr1;
                    //cmd1.Parameters.Add("@fech_apr1", SqlDbType.DateTime).Value = BE.fech_apr1;
                    //cmd1.Parameters.Add("@status_aprob", SqlDbType.Char, 1).Value = BE.status_aprob;
                    //cmd1.Parameters.Add("@glosa", SqlDbType.Text).Value = BE.glosa;
                  
                    try
                    {
                        cnx.Open();
                        tr = cnx.BeginTransaction(IsolationLevel.Serializable);
                        cmd1.Transaction = tr;

                        if (TransaExito == true)
                        {
                            tr.Commit();
                            return true;
                        }
                        else
                        {
                            tr.Rollback();
                            return false;
                        }

                    }
                    catch (Exception ex)
                    {
                        tr.Rollback();
                        throw new Exception(ex.Message);
                    }                    
                }
            }
        }

        public bool Delete(string empresaid, tb_pp_ordenprod BE2)
        {
            //BE1: ingresa datos en tabla tb_pp_ordenproducciondet_delete
            //BE2: elimina datos de tabla tb_pp_ordenproducciondet

            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                SqlTransaction tr = default(SqlTransaction);
                Boolean TransaExito = false;

                using (SqlCommand cmd1 = new SqlCommand("gspTbPpOrdenproducciondet_ANULAR_xml", cnx))
                {
                    cmd1.CommandType = CommandType.StoredProcedure;
                    //cmd1.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE2.moduloid;
                    //cmd1.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE2.local;
                    //cmd1.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE2.tipodoc;
                    //cmd1.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE2.serdoc;
                    //cmd1.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE2.numdoc;
                    //cmd1.Parameters.Add("@XML", SqlDbType.Xml).Value = BE2.GetItemXML2();
                   

                        try
                        {
                            cnx.Open();
                            tr = cnx.BeginTransaction(IsolationLevel.Serializable);
                            cmd1.Transaction = tr;

                            if (cmd1.ExecuteNonQuery() > 0)
                            {
                               
                            }

                            if (TransaExito == true)
                            {
                                tr.Commit();
                                return true;
                            }
                            else
                            {
                                tr.Rollback();
                                return false;
                            }

                        }
                        catch (Exception ex)
                        {
                            tr.Rollback();
                            throw new Exception(ex.Message);
                        }
                 }                
            }
        }

        public bool DeleteFase(string empresaid, tb_pp_ordenprod BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("TbPpOrdenprodfase_DELETE", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tipop", SqlDbType.Char, 2).Value = BE.tipop;
                    cmd.Parameters.Add("@serop", SqlDbType.Char, 4).Value = BE.serop;
                    cmd.Parameters.Add("@numop", SqlDbType.Char, 10).Value = BE.numop;
                    cmd.Parameters.Add("@secuencia", SqlDbType.Int).Value = BE.secuencia;
                    cmd.Parameters.Add("@faseid", SqlDbType.Int).Value = BE.faseid;
                    //cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;


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

        public bool DeleteMaterial(string empresaid, tb_pp_ordenprod BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("TbPpOrdenprodtela_DELETE", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tipop", SqlDbType.Char, 2).Value = BE.tipop;
                    cmd.Parameters.Add("@serop", SqlDbType.Char, 4).Value = BE.serop;
                    cmd.Parameters.Add("@numop", SqlDbType.Char, 10).Value = BE.numop;
                    cmd.Parameters.Add("@partepdaid", SqlDbType.Int).Value = BE.partepdaid;
                    cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;

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

        public DataSet GetAll(string empresaid, tb_pp_ordenprod BE1)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {

                using (SqlCommand cmd1 = new SqlCommand("TbPpOrdenprodcab_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd1.CommandType = CommandType.StoredProcedure;
                        //cmd1.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE1.tipodoc;
                        //cmd1.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE1.serdoc;
                        //cmd1.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE1.numdoc;
                        //cmd1.Parameters.Add("@lineaid", SqlDbType.Char, 2).Value = BE1.lineaid;
                        //cmd1.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE1.marcaid;
                        //cmd1.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE1.articid;
                        //cmd1.Parameters.Add("@articname", SqlDbType.Char, 50).Value = BE1.articname;                                      
                        cmd1.Parameters.Add("@parameters", SqlDbType.VarChar).Value = BE1.parameters; 
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

        public DataSet ListarOrden(string empresaid, tb_pp_ordenprod BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPpOrdenproddetalle_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serop", SqlDbType.Char, 4).Value = BE.serop;
                        cmd.Parameters.Add("@numop", SqlDbType.Char, 10).Value = BE.numop;                                                       
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

        public DataSet GetAll_Fase(string empresaid, tb_pp_ordenprod BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("TbPpOrdenprodfase_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipop", SqlDbType.Char, 2).Value = BE.tipop;
                        cmd.Parameters.Add("@serop", SqlDbType.Char, 4).Value = BE.serop;
                        cmd.Parameters.Add("@numop", SqlDbType.Char, 10).Value = BE.numop;                                                                   
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

        public DataSet GetAll_Material(string empresaid, tb_pp_ordenprod BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("TbPpOrdenprodtela_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipop", SqlDbType.Char, 2).Value = BE.tipop;
                        cmd.Parameters.Add("@serop", SqlDbType.Char, 4).Value = BE.serop;
                        cmd.Parameters.Add("@numop", SqlDbType.Char, 10).Value = BE.numop;
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

        public DataSet GetAllProp_PIVOT(string empresaid, tb_pp_ordenprod BE1)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd1 = new SqlCommand("TbPpOrdenprodprop_SEARCH_PIVOT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.Add("@tipop", SqlDbType.Char, 2).Value = BE1.tipop;
                        cmd1.Parameters.Add("@serop", SqlDbType.Char, 4).Value = BE1.serop;
                        cmd1.Parameters.Add("@numop", SqlDbType.Char, 10).Value = BE1.numop;       
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

        public DataSet GetAllPropColor_PIVOT(string empresaid, tb_pp_ordenprod BE1)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd1 = new SqlCommand("TbPpOrdenprodcolor_SEARCH_PIVOT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.Add("@tipop", SqlDbType.Char, 2).Value = BE1.tipop;
                        cmd1.Parameters.Add("@serop", SqlDbType.Char, 4).Value = BE1.serop;
                        cmd1.Parameters.Add("@numop", SqlDbType.Char, 10).Value = BE1.numop;
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

        public DataSet GetOne(string empresaid, tb_pp_ordenprod BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpMovimientoscab_SELECT", cnx))
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
        
        
        
        /**********
         * Cargar Explosion
         * *********/

        public DataSet GetAll_Explosion(string empresaid, tb_pp_ordenprod BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbpp_search_explosion", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@parameters", SqlDbType.VarChar).Value = BE.parameters;
                        cmd.Parameters.Add("@explosion", SqlDbType.Char, 1).Value = BE.explosion;                        
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
      
        public bool Gen_Explosion(string empresaid, tb_pp_ordenprod BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbpp_tb_pp_explomatdet_INSERT_UPDATE", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tipop", SqlDbType.Char, 2).Value = BE.tipop;
                    cmd.Parameters.Add("@serop", SqlDbType.Char, 4).Value = BE.serop;
                    cmd.Parameters.Add("@numop", SqlDbType.Char, 10).Value = BE.numop;
                    cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
                    cmd.Parameters.Add("@version", SqlDbType.Char, 4).Value = BE.version;

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

        public DataSet GetAllDet_Explosion(string empresaid, tb_pp_ordenprod BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbpp_tb_pp_explomatdet_rpt", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipop", SqlDbType.Char, 2).Value = BE.tipop;
                        cmd.Parameters.Add("@serop", SqlDbType.Char, 4).Value = BE.serop;
                        cmd.Parameters.Add("@numop", SqlDbType.Char, 10).Value = BE.numop;
                        cmd.Parameters.Add("@tallaid", SqlDbType.Char, 2).Value = BE.tallaid;
                        cmd.Parameters.Add("@Idx", SqlDbType.Char, 3).Value = BE.idx;
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



        /*************
         * Consumo Tela 
         * ***********/

        public bool GenConsumo(string empresaid, tb_pp_ordenprod BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbpp_ordenprodconsumo_INSERT_UPDATE", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tipop", SqlDbType.Char, 2).Value = BE.tipop;
                    cmd.Parameters.Add("@serop", SqlDbType.Char, 4).Value = BE.serop;
                    cmd.Parameters.Add("@numop", SqlDbType.Char, 10).Value = BE.numop;
                    cmd.Parameters.Add("@partepdaid", SqlDbType.Int).Value = BE.partepdaid;
                    cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                    cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;                    
                    cmd.Parameters.Add("@largtizado", SqlDbType.Decimal).Value = BE.largtizado;
                    cmd.Parameters.Add("@pdasxpano", SqlDbType.Decimal).Value = BE.pdasxpano;
                    cmd.Parameters.Add("@numpanos", SqlDbType.Int).Value = BE.numpanos;
                    cmd.Parameters.Add("@porcentolerancia", SqlDbType.Decimal).Value = BE.porcentolerancia;
                    cmd.Parameters.Add("@cantreal", SqlDbType.Int).Value = BE.cantreal;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    cmd.Parameters.Add("@Idx", SqlDbType.Char, 3).Value = BE.idx;

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


        public DataSet LstConsumoTelas(string empresaid, tb_pp_ordenprod BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbpp_ordenprodconsumo_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipop", SqlDbType.Char, 2).Value = BE.tipop;
                        cmd.Parameters.Add("@serop", SqlDbType.Char, 4).Value = BE.serop;
                        cmd.Parameters.Add("@numop", SqlDbType.Char, 10).Value = BE.numop;
                        cmd.Parameters.Add("@partepdaid", SqlDbType.Int).Value = BE.partepdaid;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        //cmd.Parameters.Add("@tallaid", SqlDbType.Char, 2).Value = BE.tallaid;
                        cmd.Parameters.Add("@Idx", SqlDbType.Char, 3).Value = BE.idx;
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
