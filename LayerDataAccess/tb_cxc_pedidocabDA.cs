using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_cxc_pedidocabDA
    {
        ConexionWeb conex = new ConexionWeb();

        public bool Insert(string empresaid, tb_cxc_pedidocab BE)
{
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMePedidoCab_INSERT", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd.Parameters.Add("@canalventaid", SqlDbType.Char, 3).Value = BE.canalventaid;
                    cmd.Parameters.Add("@tipventaid", SqlDbType.Char, 2).Value = BE.tipventaid;
                    cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                    cmd.Parameters.Add("@fechentrega", SqlDbType.DateTime).Value = BE.fechentrega;
                    cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@direcnume", SqlDbType.Char, 3).Value = BE.direcnume;
                    cmd.Parameters.Add("@replegal_dni", SqlDbType.Char, 8).Value = BE.replegal_dni;
                    cmd.Parameters.Add("@replegal_name", SqlDbType.VarChar, 100).Value = BE.replegal_name;
                    cmd.Parameters.Add("@direc_entrega", SqlDbType.VarChar, 100).Value = BE.direc_entrega;
                    cmd.Parameters.Add("@condventaid", SqlDbType.Char, 2).Value = BE.condventaid;
                    cmd.Parameters.Add("@plazoday", SqlDbType.Int).Value = BE.plazoday;
                    cmd.Parameters.Add("@impobruto", SqlDbType.Decimal).Value = BE.impobruto;
                    cmd.Parameters.Add("@rangoid", SqlDbType.Char, 2).Value = BE.rangoid;
                    cmd.Parameters.Add("@tasadescto", SqlDbType.Decimal).Value = BE.tasadescto;
                    cmd.Parameters.Add("@imponeto", SqlDbType.Decimal).Value = BE.imponeto;
                    cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                    cmd.Parameters.Add("@incluye_igv", SqlDbType.Bit).Value = BE.incluye_igv;
                    cmd.Parameters.Add("@observacion", SqlDbType.VarChar,500).Value = BE.observacion;
                    cmd.Parameters.Add("@mediopagoid", SqlDbType.Char, 3).Value = BE.mediopagoid;
                    cmd.Parameters.Add("@numdocs", SqlDbType.Int).Value = BE.numdocs;
                    cmd.Parameters.Add("@aprob_status", SqlDbType.Char, 2).Value = BE.aprob_status;
                    cmd.Parameters.Add("@aprob_obser", SqlDbType.VarChar, 100).Value = BE.aprob_obser;
                    cmd.Parameters.Add("@aprob_fech", SqlDbType.DateTime).Value = BE.aprob_fech;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@accion", SqlDbType.Char, 3).Value = BE.accion;
                    cmd.Parameters.Add("@XML", SqlDbType.Xml).Value = BE.GetItemXML();
                    cmd.Parameters.Add("@XMLC", SqlDbType.Xml).Value = BE.GetCronoXML();
                    cmd.Parameters.Add("@XMLStk", SqlDbType.VarChar).Value = BE.GetStkItemXML();
                    //cmd.Parameters.Add("@XMLStk", SqlDbType.Xml).Value = BE.GetStkItemXML();
                    

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

        public bool Update_Estado(string empresaid, tb_cxc_pedidocab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMePedidoCab_UPDATE_ESTADO", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
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

        public bool Insert_Item(string empresaid, tb_cxc_pedidocab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60Tienda_INSERT_Item", cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    //cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    //cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    //cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;

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

        public bool Update(string empresaid, tb_cxc_pedidocab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMePedidoCab_UPDATE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@canalventaid", SqlDbType.Char, 3).Value = BE.canalventaid;
                        cmd.Parameters.Add("@tipventaid", SqlDbType.Char, 2).Value = BE.tipventaid;
                        cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                        cmd.Parameters.Add("@fechentrega", SqlDbType.DateTime).Value = BE.fechentrega;
                        cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@replegal_dni", SqlDbType.Char, 8).Value = BE.replegal_dni;
                        cmd.Parameters.Add("@replegal_name", SqlDbType.VarChar, 100).Value = BE.replegal_name;
                        cmd.Parameters.Add("@direc_entrega", SqlDbType.VarChar, 100).Value = BE.direc_entrega;
                        cmd.Parameters.Add("@condventaid", SqlDbType.Char, 2).Value = BE.condventaid;
                        cmd.Parameters.Add("@plazoday", SqlDbType.Int).Value = BE.plazoday;
                        cmd.Parameters.Add("@impobruto", SqlDbType.Decimal).Value = BE.impobruto;
                        cmd.Parameters.Add("@rangoid", SqlDbType.Char, 2).Value = BE.rangoid;
                        cmd.Parameters.Add("@tasadescto", SqlDbType.Decimal).Value = BE.tasadescto;
                        cmd.Parameters.Add("@imponeto", SqlDbType.Decimal).Value = BE.imponeto;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@incluye_igv", SqlDbType.Bit).Value = BE.incluye_igv;
                        cmd.Parameters.Add("@observacion", SqlDbType.VarChar, 500).Value = BE.observacion;
                        cmd.Parameters.Add("@mediopagoid", SqlDbType.Char, 3).Value = BE.mediopagoid;
                        cmd.Parameters.Add("@numdocs", SqlDbType.Int).Value = BE.numdocs;
                        cmd.Parameters.Add("@aprob_status", SqlDbType.Char, 2).Value = BE.aprob_status;
                        cmd.Parameters.Add("@aprob_obser", SqlDbType.VarChar, 100).Value = BE.aprob_obser;
                        cmd.Parameters.Add("@aprob_fech", SqlDbType.DateTime).Value = BE.aprob_fech;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                        cmd.Parameters.Add("@XML", SqlDbType.Xml).Value = BE.GetItemXML();
                        cmd.Parameters.Add("@XMLC", SqlDbType.Xml).Value = BE.GetCronoXML();
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

        public bool Delete(string empresaid, tb_cxc_pedidocab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60Tienda_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        //cmd.Parameters.Add("@tiendalist", SqlDbType.Int).Value = BE.tiendalist;
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

        public bool DeleteItem(string empresaid, tb_cxc_pedidocab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60Tienda_DELETE_Item", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        //cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        //cmd.Parameters.Add("@tiendalist", SqlDbType.Int).Value = BE.tiendalist;
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

        public DataSet GetAll(string empresaid, tb_cxc_pedidocab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMePedidoCab_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
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

        public DataSet GetAll2(string empresaid, tb_cxc_pedidocab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMePedidoCab_SEARCH2", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
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

        public DataSet GetNewNumDoc(string empresaid, tb_cxc_pedidocab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCxcDocseries_Nuevonumero", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@canalventaid", SqlDbType.Char, 3).Value = BE.canalventaid;
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

        public DataSet GetAll_paginacion(string empresaid, tb_cxc_pedidocab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60Tienda_SEARCH_paginacion", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        //cmd.Parameters.Add("@tiendalist", SqlDbType.Int).Value = BE.tiendalist;
                        //cmd.Parameters.Add("@posicion", SqlDbType.VarChar, 10).Value = BE.posicion;
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

