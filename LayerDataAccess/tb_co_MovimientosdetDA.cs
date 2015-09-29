using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_co_MovimientosdetDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_co_Movimientosdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientosdet_INSERT", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                    cmd.Parameters.Add("@asiento", SqlDbType.Char, 8).Value = BE.asiento;
                    cmd.Parameters.Add("@asientoitems", SqlDbType.Char, 5).Value = BE.asientoitems;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@cuentaid", SqlDbType.Char, 10).Value = BE.cuentaid;
                    cmd.Parameters.Add("@cuentaorigen", SqlDbType.Char, 10).Value = BE.cuentaorigen;
                    cmd.Parameters.Add("@cuentaname", SqlDbType.VarChar, 100).Value = BE.cuentaname;
                    cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 100).Value = BE.glosa;
                    cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                    cmd.Parameters.Add("@debehaber", SqlDbType.Char, 5).Value = BE.debehaber;
                    cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                    cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 100).Value = BE.ctactename;
                    cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd.Parameters.Add("@fechregistro", SqlDbType.DateTime).Value = BE.fechregistro;
                    cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                    cmd.Parameters.Add("@fechvenc", SqlDbType.DateTime).Value = BE.fechvenc;
                    cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                    cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                    cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                    cmd.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE.fechref;
                    cmd.Parameters.Add("@importe", SqlDbType.Decimal).Value = BE.importe;
                    cmd.Parameters.Add("@importecambio", SqlDbType.Decimal).Value = BE.importecambio;
                    cmd.Parameters.Add("@soles", SqlDbType.Decimal).Value = BE.soles;
                    cmd.Parameters.Add("@dolares", SqlDbType.Decimal).Value = BE.dolares;
                    cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                    cmd.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                    cmd.Parameters.Add("@tipcambuso", SqlDbType.Char, 1).Value = BE.tipcambuso;
                    cmd.Parameters.Add("@tipcambfech", SqlDbType.DateTime).Value = BE.tipcambfech;
                    cmd.Parameters.Add("@afectoretencion", SqlDbType.Bit).Value = BE.afectoretencion;
                    cmd.Parameters.Add("@afectopercepcion", SqlDbType.Bit).Value = BE.afectopercepcion;
                    cmd.Parameters.Add("@percepcionid", SqlDbType.Char, 2).Value = BE.percepcionid;
                    cmd.Parameters.Add("@serperc", SqlDbType.Char, 4).Value = BE.serperc;
                    cmd.Parameters.Add("@numperc", SqlDbType.Char, 10).Value = BE.numperc;
                    cmd.Parameters.Add("@numdocpago", SqlDbType.Char, 10).Value = BE.numdocpago;
                    cmd.Parameters.Add("@bancoid", SqlDbType.Char, 2).Value = BE.bancoid;
                    cmd.Parameters.Add("@pagocta", SqlDbType.Char, 20).Value = BE.pagocta;
                    cmd.Parameters.Add("@mediopago", SqlDbType.Char, 3).Value = BE.mediopago;
                    cmd.Parameters.Add("@fechpago", SqlDbType.DateTime).Value = BE.fechpago;
                    cmd.Parameters.Add("@flujoefectivo", SqlDbType.Char, 4).Value = BE.flujoefectivo;
                    cmd.Parameters.Add("@asientovinculante", SqlDbType.Char, 10).Value = BE.asientovinculante;
                    cmd.Parameters.Add("@cancelacionvinculante", SqlDbType.Char, 10).Value = BE.cancelacionvinculante;
                    cmd.Parameters.Add("@productid", SqlDbType.VarChar, 25).Value = BE.productid;
                    cmd.Parameters.Add("@pedidoid", SqlDbType.Char, 10).Value = BE.pedidoid;
                    cmd.Parameters.Add("@tipOp", SqlDbType.Char, 2).Value = BE.tipOp;
                    cmd.Parameters.Add("@serOp", SqlDbType.Char, 4).Value = BE.serOp;
                    cmd.Parameters.Add("@numOp", SqlDbType.Char, 10).Value = BE.numOp;
                    cmd.Parameters.Add("@statusdestino", SqlDbType.Char, 1).Value = BE.statusdestino;
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

        public bool Update(string empresaid, tb_co_Movimientosdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientosdet_UPDATE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 8).Value = BE.asiento;
                        cmd.Parameters.Add("@asientoitems", SqlDbType.Char, 5).Value = BE.asientoitems;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@cuentaid", SqlDbType.Char, 10).Value = BE.cuentaid;
                        cmd.Parameters.Add("@cuentaorigen", SqlDbType.Char, 10).Value = BE.cuentaorigen;
                        cmd.Parameters.Add("@cuentaname", SqlDbType.VarChar, 100).Value = BE.cuentaname;
                        cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 100).Value = BE.glosa;
                        cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                        cmd.Parameters.Add("@debehaber", SqlDbType.Char, 5).Value = BE.debehaber;
                        cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                        cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 100).Value = BE.ctactename;
                        cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@fechregistro", SqlDbType.DateTime).Value = BE.fechregistro;
                        cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                        cmd.Parameters.Add("@fechvenc", SqlDbType.DateTime).Value = BE.fechvenc;
                        cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                        cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                        cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                        cmd.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE.fechref;
                        cmd.Parameters.Add("@soles", SqlDbType.Decimal).Value = BE.soles;
                        cmd.Parameters.Add("@dolares", SqlDbType.Decimal).Value = BE.dolares;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                        cmd.Parameters.Add("@tipcambuso", SqlDbType.Char, 1).Value = BE.tipcambuso;
                        cmd.Parameters.Add("@tipcambfech", SqlDbType.DateTime).Value = BE.tipcambfech;
                        cmd.Parameters.Add("@afectoretencion", SqlDbType.Bit).Value = BE.afectoretencion;
                        cmd.Parameters.Add("@afectopercepcion", SqlDbType.Bit).Value = BE.afectopercepcion;
                        cmd.Parameters.Add("@percepcionid", SqlDbType.Char, 2).Value = BE.percepcionid;
                        cmd.Parameters.Add("@serperc", SqlDbType.Char, 4).Value = BE.serperc;
                        cmd.Parameters.Add("@numperc", SqlDbType.Char, 10).Value = BE.numperc;
                        cmd.Parameters.Add("@numdocpago", SqlDbType.Char, 10).Value = BE.numdocpago;
                        cmd.Parameters.Add("@bancoid", SqlDbType.Char, 2).Value = BE.bancoid;
                        cmd.Parameters.Add("@pagocta", SqlDbType.Char, 20).Value = BE.pagocta;
                        cmd.Parameters.Add("@mediopago", SqlDbType.Char, 3).Value = BE.mediopago;
                        cmd.Parameters.Add("@fechpago", SqlDbType.DateTime).Value = BE.fechpago;
                        cmd.Parameters.Add("@flujoefectivo", SqlDbType.Char, 4).Value = BE.flujoefectivo;
                        cmd.Parameters.Add("@asientovinculante", SqlDbType.Char, 10).Value = BE.asientovinculante;
                        cmd.Parameters.Add("@cancelacionvinculante", SqlDbType.Char, 10).Value = BE.cancelacionvinculante;
                        cmd.Parameters.Add("@productid", SqlDbType.VarChar, 25).Value = BE.productid;
                        cmd.Parameters.Add("@pedidoid", SqlDbType.Char, 10).Value = BE.pedidoid;
                        cmd.Parameters.Add("@tipOp", SqlDbType.Char, 2).Value = BE.tipOp;
                        cmd.Parameters.Add("@serOp", SqlDbType.Char, 4).Value = BE.serOp;
                        cmd.Parameters.Add("@numOp", SqlDbType.Char, 10).Value = BE.numOp;
                        cmd.Parameters.Add("@statusdestino", SqlDbType.Char, 1).Value = BE.statusdestino;
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

        public bool Delete(string empresaid, tb_co_Movimientosdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientosdet_DELETE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 8).Value = BE.asiento;
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

        public DataSet GetAll(string empresaid, tb_co_Movimientosdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientosdet_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
                        cmd.Parameters.Add("@asientoitems", SqlDbType.Char, 5).Value = BE.asientoitems;
                        cmd.Parameters.Add("@cuentaid", SqlDbType.Char, 10).Value = BE.cuentaid;
                        cmd.Parameters.Add("@cuentaorigen", SqlDbType.Char, 10).Value = BE.cuentaorigen;
                        cmd.Parameters.Add("@cuentaname", SqlDbType.VarChar, 100).Value = BE.cuentaname;
                        cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 100).Value = BE.glosa;
                        cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                        cmd.Parameters.Add("@debehaber", SqlDbType.Char, 5).Value = BE.debehaber;
                        cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                        cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 100).Value = BE.ctactename;
                        cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@fechregistro", SqlDbType.DateTime).Value = BE.fechregistro;
                        cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                        cmd.Parameters.Add("@fechvenc", SqlDbType.DateTime).Value = BE.fechvenc;
                        cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                        cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                        cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                        cmd.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE.fechref;
                        //cmd.Parameters.Add("@soles", SqlDbType.Decimal).Value = BE.soles;
                        //cmd.Parameters.Add("@dolares", SqlDbType.Decimal).Value = BE.dolares;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        //cmd.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                        cmd.Parameters.Add("@tipcambuso", SqlDbType.Char, 1).Value = BE.tipcambuso;
                        cmd.Parameters.Add("@tipcambfech", SqlDbType.DateTime).Value = BE.tipcambfech;
                        cmd.Parameters.Add("@afectoretencion", SqlDbType.Bit).Value = BE.afectoretencion;
                        cmd.Parameters.Add("@afectopercepcion", SqlDbType.Bit).Value = BE.afectopercepcion;
                        cmd.Parameters.Add("@percepcionid", SqlDbType.Char, 2).Value = BE.percepcionid;
                        cmd.Parameters.Add("@serperc", SqlDbType.Char, 4).Value = BE.serperc;
                        cmd.Parameters.Add("@numperc", SqlDbType.Char, 10).Value = BE.numperc;
                        cmd.Parameters.Add("@numdocpago", SqlDbType.Char, 10).Value = BE.numdocpago;
                        cmd.Parameters.Add("@bancoid", SqlDbType.Char, 2).Value = BE.bancoid;
                        cmd.Parameters.Add("@pagocta", SqlDbType.Char, 20).Value = BE.pagocta;
                        cmd.Parameters.Add("@mediopago", SqlDbType.Char, 3).Value = BE.mediopago;
                        cmd.Parameters.Add("@fechpago", SqlDbType.DateTime).Value = BE.fechpago;
                        cmd.Parameters.Add("@flujoefectivo", SqlDbType.Char, 4).Value = BE.flujoefectivo;
                        cmd.Parameters.Add("@asientovinculante", SqlDbType.Char, 10).Value = BE.asientovinculante;
                        cmd.Parameters.Add("@cancelacionvinculante", SqlDbType.Char, 10).Value = BE.cancelacionvinculante;
                        cmd.Parameters.Add("@productid", SqlDbType.VarChar, 25).Value = BE.productid;
                        cmd.Parameters.Add("@pedidoid", SqlDbType.Char, 10).Value = BE.pedidoid;
                        cmd.Parameters.Add("@tipOp", SqlDbType.Char, 2).Value = BE.tipOp;
                        cmd.Parameters.Add("@serOp", SqlDbType.Char, 4).Value = BE.serOp;
                        cmd.Parameters.Add("@numOp", SqlDbType.Char, 10).Value = BE.numOp;
                        cmd.Parameters.Add("@statusdestino", SqlDbType.Char, 1).Value = BE.statusdestino;
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public DataSet GetAsientoVoucher(string empresaid, tb_co_Movimientosdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientosdet_SEARCH_voucher", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@asientoi", SqlDbType.Char, 6).Value = BE.asientoi;
                        cmd.Parameters.Add("@asientof", SqlDbType.Char, 6).Value = BE.asientof;
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

        public DataSet GetOne(string empresaid, tb_co_Movimientosdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientosdet_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 8).Value = BE.asiento;
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
