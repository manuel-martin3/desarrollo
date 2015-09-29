using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_cxc_movimientosDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_cxc_movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb_cxc_movimientocab_INSERT_UPDATE", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                    cmd.Parameters.Add("@fechven", SqlDbType.DateTime).Value = BE.fechven;                    
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                    cmd.Parameters.Add("@condventaid", SqlDbType.Char, 2).Value = BE.condventaid;
                    cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                    cmd.Parameters.Add("@factdescto	", SqlDbType.Decimal).Value = BE.factdescto;                    
                    cmd.Parameters.Add("@impobruto", SqlDbType.Decimal).Value = BE.impobruto;
                    cmd.Parameters.Add("@impodescto", SqlDbType.Decimal).Value = BE.impodescto;
                    cmd.Parameters.Add("@impoventa", SqlDbType.Decimal).Value = BE.impoventa;
                    cmd.Parameters.Add("@impocargo", SqlDbType.Decimal).Value = BE.impocargo;
                    cmd.Parameters.Add("@impoabono", SqlDbType.Decimal).Value = BE.impoabono;
                    cmd.Parameters.Add("@impodevol", SqlDbType.Decimal).Value = BE.impodevol;
                    cmd.Parameters.Add("@impoletra", SqlDbType.Decimal).Value = BE.impoletra;
                    cmd.Parameters.Add("@impodesctoaplic", SqlDbType.Decimal).Value = BE.impodesctoaplic;
                    cmd.Parameters.Add("@imposaldo", SqlDbType.Decimal).Value = BE.imposaldo;
                    cmd.Parameters.Add("@observacion", SqlDbType.VarChar, 100).Value = BE.observacion;
                    cmd.Parameters.Add("@comision", SqlDbType.Decimal).Value = BE.comision;             		
                    cmd.Parameters.Add("@tipcanje", SqlDbType.Char, 2).Value = BE.tipdoc;
                    cmd.Parameters.Add("@sercanje", SqlDbType.Char, 4).Value = BE.sercanje;
                    cmd.Parameters.Add("@numcanje", SqlDbType.Char, 10).Value = BE.numcanje;
                    cmd.Parameters.Add("@tipdocalm", SqlDbType.Char, 2).Value = BE.tipdocalm;
                    cmd.Parameters.Add("@serdocalm", SqlDbType.Char, 4).Value = BE.serdocalm;
                    cmd.Parameters.Add("@numdocalm", SqlDbType.Char, 10).Value = BE.numdocalm;
                    cmd.Parameters.Add("@estadoid", SqlDbType.Char, 2).Value = BE.estadoid;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    cmd.Parameters.Add("@fecre", SqlDbType.DateTime).Value = BE.fecre;
                    cmd.Parameters.Add("@feact", SqlDbType.DateTime).Value = BE.feact;
                    cmd.Parameters.Add("@Idx", SqlDbType.Char, 3).Value = BE.Idx;               
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

        public bool Update(string empresaid, tb_cxc_movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb_cxc_movimientocab_INSERT_UPDATE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                        cmd.Parameters.Add("@fechven", SqlDbType.DateTime).Value = BE.fechven;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                        cmd.Parameters.Add("@condventaid", SqlDbType.Char, 2).Value = BE.condventaid;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@factdescto	", SqlDbType.Decimal).Value = BE.factdescto;
                        cmd.Parameters.Add("@impobruto", SqlDbType.Decimal).Value = BE.impobruto;
                        cmd.Parameters.Add("@impodescto", SqlDbType.Decimal).Value = BE.impodescto;
                        cmd.Parameters.Add("@impoventa", SqlDbType.Decimal).Value = BE.impoventa;
                        cmd.Parameters.Add("@impocargo", SqlDbType.Decimal).Value = BE.impocargo;
                        cmd.Parameters.Add("@impoabono", SqlDbType.Decimal).Value = BE.impoabono;
                        cmd.Parameters.Add("@impodevol", SqlDbType.Decimal).Value = BE.impodevol;
                        cmd.Parameters.Add("@impoletra", SqlDbType.Decimal).Value = BE.impoletra;
                        cmd.Parameters.Add("@impodesctoaplic", SqlDbType.Decimal).Value = BE.impodesctoaplic;
                        cmd.Parameters.Add("@imposaldo", SqlDbType.Decimal).Value = BE.imposaldo;
                        cmd.Parameters.Add("@observacion", SqlDbType.VarChar, 100).Value = BE.observacion;
                        cmd.Parameters.Add("@comision", SqlDbType.Decimal).Value = BE.comision;
                        cmd.Parameters.Add("@tipcanje", SqlDbType.Char, 2).Value = BE.tipdoc;
                        cmd.Parameters.Add("@sercanje", SqlDbType.Char, 4).Value = BE.sercanje;
                        cmd.Parameters.Add("@numcanje", SqlDbType.Char, 10).Value = BE.numcanje;
                        cmd.Parameters.Add("@tipdocalm", SqlDbType.Char, 2).Value = BE.tipdocalm;
                        cmd.Parameters.Add("@serdocalm", SqlDbType.Char, 4).Value = BE.serdocalm;
                        cmd.Parameters.Add("@numdocalm", SqlDbType.Char, 10).Value = BE.numdocalm;
                        cmd.Parameters.Add("@estadoid", SqlDbType.Char, 2).Value = BE.estadoid;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                        cmd.Parameters.Add("@fecre", SqlDbType.DateTime).Value = BE.fecre;
                        cmd.Parameters.Add("@feact", SqlDbType.DateTime).Value = BE.feact;
                        cmd.Parameters.Add("@Idx", SqlDbType.Char, 3).Value = BE.Idx;
                        cmd.Parameters.Add("@XML", SqlDbType.Xml).Value = BE.GetItemXML();
                     
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

        public bool Delete(string empresaid, tb_cxc_movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        
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

        public DataSet GetAll(string empresaid, tb_cxc_movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                       
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

