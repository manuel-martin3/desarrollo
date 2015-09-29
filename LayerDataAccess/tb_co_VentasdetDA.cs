using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_co_VentasdetDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_co_Ventasdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoVentasdet_INSERT", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                    cmd.Parameters.Add("@asiento", SqlDbType.Char, 8).Value = BE.asiento;
                    cmd.Parameters.Add("@asientoitems", SqlDbType.Char, 5).Value = BE.asientoitems;
                    cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                    cmd.Parameters.Add("@fechvcto", SqlDbType.DateTime).Value = BE.fechvcto;
                    cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                    cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                    cmd.Parameters.Add("@items", SqlDbType.Char, 5).Value = BE.items;
                    cmd.Parameters.Add("@status", SqlDbType.Bit).Value = BE.status;
                    cmd.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE.almacaccionid;
                    cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                    cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                    cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                    cmd.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE.fechref;
                    cmd.Parameters.Add("@rubroid", SqlDbType.Char, 4).Value = BE.rubroid;
                    cmd.Parameters.Add("@tippedido", SqlDbType.Char, 2).Value = BE.tippedido;
                    cmd.Parameters.Add("@serpedido", SqlDbType.Char, 4).Value = BE.serpedido;
                    cmd.Parameters.Add("@numpedido", SqlDbType.Char, 10).Value = BE.numpedido;
                    cmd.Parameters.Add("@tipOp", SqlDbType.Char, 2).Value = BE.tipOp;
                    cmd.Parameters.Add("@serOp", SqlDbType.Char, 4).Value = BE.serOp;
                    cmd.Parameters.Add("@numOp", SqlDbType.Char, 10).Value = BE.numOp;
                    cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                    cmd.Parameters.Add("@productname", SqlDbType.VarChar, 70).Value = BE.productname;
                    cmd.Parameters.Add("@tallacolor", SqlDbType.Char, 6).Value = BE.tallacolor;
                    cmd.Parameters.Add("@unidmedidaid", SqlDbType.Char, 3).Value = BE.unidmedidaid;
                    cmd.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = BE.cantidad;
                    cmd.Parameters.Add("@precunit1", SqlDbType.Decimal).Value = BE.precunit1;
                    cmd.Parameters.Add("@bruto1", SqlDbType.Decimal).Value = BE.bruto1;
                    cmd.Parameters.Add("@dscto1", SqlDbType.Decimal).Value = BE.dscto1;
                    cmd.Parameters.Add("@valorventa1", SqlDbType.Decimal).Value = BE.valorventa1;
                    cmd.Parameters.Add("@igv1", SqlDbType.Decimal).Value = BE.igv1;
                    cmd.Parameters.Add("@total1", SqlDbType.Decimal).Value = BE.total1;
                    cmd.Parameters.Add("@pdscto", SqlDbType.Decimal).Value = BE.pdscto;
                    cmd.Parameters.Add("@pigv", SqlDbType.Decimal).Value = BE.pigv;
                    cmd.Parameters.Add("@precunit2", SqlDbType.Decimal).Value = BE.precunit2;
                    cmd.Parameters.Add("@bruto2", SqlDbType.Decimal).Value = BE.bruto2;
                    cmd.Parameters.Add("@dscto2", SqlDbType.Decimal).Value = BE.dscto2;
                    cmd.Parameters.Add("@valorventa2", SqlDbType.Decimal).Value = BE.valorventa2;
                    cmd.Parameters.Add("@igv2", SqlDbType.Decimal).Value = BE.igv2;
                    cmd.Parameters.Add("@total2", SqlDbType.Decimal).Value = BE.total2;
                    cmd.Parameters.Add("@tipguia", SqlDbType.Char, 2).Value = BE.tipguia;
                    cmd.Parameters.Add("@serguia", SqlDbType.Char, 4).Value = BE.serguia;
                    cmd.Parameters.Add("@numguia", SqlDbType.Char, 10).Value = BE.numguia;
                    cmd.Parameters.Add("@afectoigvid", SqlDbType.Char, 1).Value = BE.afectoigvid;
                    cmd.Parameters.Add("@incprec", SqlDbType.Bit).Value = BE.incprec;
                    cmd.Parameters.Add("@vendedorid", SqlDbType.Char, 4).Value = BE.vendedorid;
                    cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                    cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 100).Value = BE.glosa;
                    cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                    cmd.Parameters.Add("@tcamb", SqlDbType.Decimal).Value = BE.tcamb;
                    cmd.Parameters.Add("@ordencs", SqlDbType.Char, 10).Value = BE.ordencs;
                    cmd.Parameters.Add("@comisionvta", SqlDbType.Decimal).Value = BE.comisionvta;
                    cmd.Parameters.Add("@porcvta", SqlDbType.Decimal).Value = BE.porcvta;
                    cmd.Parameters.Add("@porcefect", SqlDbType.Decimal).Value = BE.porcefect;
                    cmd.Parameters.Add("@observ1", SqlDbType.VarChar, 100).Value = BE.observ1;
                    cmd.Parameters.Add("@observ2", SqlDbType.VarChar, 100).Value = BE.observ2;
                    cmd.Parameters.Add("@observ3", SqlDbType.VarChar, 100).Value = BE.observ3;
                    cmd.Parameters.Add("@observ4", SqlDbType.VarChar, 100).Value = BE.observ4;
                    cmd.Parameters.Add("@observ5", SqlDbType.VarChar, 100).Value = BE.observ5;
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

        public bool Update(string empresaid, tb_co_Ventasdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoVentasdet_UPDATE", cnx))
                {
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
                        cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                        cmd.Parameters.Add("@fechvcto", SqlDbType.DateTime).Value = BE.fechvcto;
                        cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                        cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                        cmd.Parameters.Add("@items", SqlDbType.Char, 5).Value = BE.items;
                        cmd.Parameters.Add("@status", SqlDbType.Bit).Value = BE.status;
                        cmd.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE.almacaccionid;
                        cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                        cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                        cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                        cmd.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE.fechref;
                        cmd.Parameters.Add("@rubroid", SqlDbType.Char, 4).Value = BE.rubroid;
                        cmd.Parameters.Add("@tippedido", SqlDbType.Char, 2).Value = BE.tippedido;
                        cmd.Parameters.Add("@serpedido", SqlDbType.Char, 4).Value = BE.serpedido;
                        cmd.Parameters.Add("@numpedido", SqlDbType.Char, 10).Value = BE.numpedido;
                        cmd.Parameters.Add("@tipOp", SqlDbType.Char, 2).Value = BE.tipOp;
                        cmd.Parameters.Add("@serOp", SqlDbType.Char, 4).Value = BE.serOp;
                        cmd.Parameters.Add("@numOp", SqlDbType.Char, 10).Value = BE.numOp;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@productname", SqlDbType.VarChar, 70).Value = BE.productname;
                        cmd.Parameters.Add("@tallacolor", SqlDbType.Char, 6).Value = BE.tallacolor;
                        cmd.Parameters.Add("@unidmedidaid", SqlDbType.Char, 3).Value = BE.unidmedidaid;
                        cmd.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = BE.cantidad;
                        cmd.Parameters.Add("@precunit1", SqlDbType.Decimal).Value = BE.precunit1;
                        cmd.Parameters.Add("@bruto1", SqlDbType.Decimal).Value = BE.bruto1;
                        cmd.Parameters.Add("@dscto1", SqlDbType.Decimal).Value = BE.dscto1;
                        cmd.Parameters.Add("@valorventa1", SqlDbType.Decimal).Value = BE.valorventa1;
                        cmd.Parameters.Add("@igv1", SqlDbType.Decimal).Value = BE.igv1;
                        cmd.Parameters.Add("@total1", SqlDbType.Decimal).Value = BE.total1;
                        cmd.Parameters.Add("@pdscto", SqlDbType.Decimal).Value = BE.pdscto;
                        cmd.Parameters.Add("@pigv", SqlDbType.Decimal).Value = BE.pigv;
                        cmd.Parameters.Add("@precunit2", SqlDbType.Decimal).Value = BE.precunit2;
                        cmd.Parameters.Add("@bruto2", SqlDbType.Decimal).Value = BE.bruto2;
                        cmd.Parameters.Add("@dscto2", SqlDbType.Decimal).Value = BE.dscto2;
                        cmd.Parameters.Add("@valorventa2", SqlDbType.Decimal).Value = BE.valorventa2;
                        cmd.Parameters.Add("@igv2", SqlDbType.Decimal).Value = BE.igv2;
                        cmd.Parameters.Add("@total2", SqlDbType.Decimal).Value = BE.total2;
                        cmd.Parameters.Add("@tipguia", SqlDbType.Char, 2).Value = BE.tipguia;
                        cmd.Parameters.Add("@serguia", SqlDbType.Char, 4).Value = BE.serguia;
                        cmd.Parameters.Add("@numguia", SqlDbType.Char, 10).Value = BE.numguia;
                        cmd.Parameters.Add("@afectoigvid", SqlDbType.Char, 1).Value = BE.afectoigvid;
                        cmd.Parameters.Add("@incprec", SqlDbType.Bit).Value = BE.incprec;
                        cmd.Parameters.Add("@vendedorid", SqlDbType.Char, 4).Value = BE.vendedorid;
                        cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                        cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 100).Value = BE.glosa;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@tcamb", SqlDbType.Decimal).Value = BE.tcamb;
                        cmd.Parameters.Add("@ordencs", SqlDbType.Char, 10).Value = BE.ordencs;
                        cmd.Parameters.Add("@comisionvta", SqlDbType.Decimal).Value = BE.comisionvta;
                        cmd.Parameters.Add("@porcvta", SqlDbType.Decimal).Value = BE.porcvta;
                        cmd.Parameters.Add("@porcefect", SqlDbType.Decimal).Value = BE.porcefect;
                        cmd.Parameters.Add("@observ1", SqlDbType.VarChar, 100).Value = BE.observ1;
                        cmd.Parameters.Add("@observ2", SqlDbType.VarChar, 100).Value = BE.observ2;
                        cmd.Parameters.Add("@observ3", SqlDbType.VarChar, 100).Value = BE.observ3;
                        cmd.Parameters.Add("@observ4", SqlDbType.VarChar, 100).Value = BE.observ4;
                        cmd.Parameters.Add("@observ5", SqlDbType.VarChar, 100).Value = BE.observ5;
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

        public bool Delete(string empresaid, tb_co_Ventasdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoVentasdet_DELETE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
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

        public DataSet GetAll(string empresaid, tb_co_Ventasdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoVentasdet_SEARCH", cnx))
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
                        cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                        cmd.Parameters.Add("@fechvcto", SqlDbType.DateTime).Value = BE.fechvcto;
                        cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                        cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                        cmd.Parameters.Add("@items", SqlDbType.Char, 5).Value = BE.items;
                        cmd.Parameters.Add("@status", SqlDbType.Bit).Value = BE.status;
                        cmd.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE.almacaccionid;
                        cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                        cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                        cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                        cmd.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE.fechref;
                        cmd.Parameters.Add("@rubroid", SqlDbType.Char, 4).Value = BE.rubroid;
                        cmd.Parameters.Add("@tippedido", SqlDbType.Char, 2).Value = BE.tippedido;
                        cmd.Parameters.Add("@serpedido", SqlDbType.Char, 4).Value = BE.serpedido;
                        cmd.Parameters.Add("@numpedido", SqlDbType.Char, 10).Value = BE.numpedido;
                        cmd.Parameters.Add("@tipOp", SqlDbType.Char, 2).Value = BE.tipOp;
                        cmd.Parameters.Add("@serOp", SqlDbType.Char, 4).Value = BE.serOp;
                        cmd.Parameters.Add("@numOp", SqlDbType.Char, 10).Value = BE.numOp;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@productname", SqlDbType.VarChar, 70).Value = BE.productname;
                        cmd.Parameters.Add("@tallacolor", SqlDbType.Char, 6).Value = BE.tallacolor;
                        cmd.Parameters.Add("@unidmedidaid", SqlDbType.Char, 3).Value = BE.unidmedidaid;
                        //cmd.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = BE.cantidad;
                        //cmd.Parameters.Add("@precunit1", SqlDbType.Decimal).Value = BE.precunit1;
                        //cmd.Parameters.Add("@bruto1", SqlDbType.Decimal).Value = BE.bruto1;
                        //cmd.Parameters.Add("@dscto1", SqlDbType.Decimal).Value = BE.dscto1;
                        //cmd.Parameters.Add("@valorventa1", SqlDbType.Decimal).Value = BE.valorventa1;
                        //cmd.Parameters.Add("@igv1", SqlDbType.Decimal).Value = BE.igv1;
                        //cmd.Parameters.Add("@total1", SqlDbType.Decimal).Value = BE.total1;
                        //cmd.Parameters.Add("@pdscto", SqlDbType.Decimal).Value = BE.pdscto;
                        //cmd.Parameters.Add("@pigv", SqlDbType.Decimal).Value = BE.pigv;
                        //cmd.Parameters.Add("@precunit2", SqlDbType.Decimal).Value = BE.precunit2;
                        //cmd.Parameters.Add("@bruto2", SqlDbType.Decimal).Value = BE.bruto2;
                        //cmd.Parameters.Add("@dscto2", SqlDbType.Decimal).Value = BE.dscto2;
                        //cmd.Parameters.Add("@valorventa2", SqlDbType.Decimal).Value = BE.valorventa2;
                        //cmd.Parameters.Add("@igv2", SqlDbType.Decimal).Value = BE.igv2;
                        //cmd.Parameters.Add("@total2", SqlDbType.Decimal).Value = BE.total2;
                        cmd.Parameters.Add("@tipguia", SqlDbType.Char, 2).Value = BE.tipguia;
                        cmd.Parameters.Add("@serguia", SqlDbType.Char, 4).Value = BE.serguia;
                        cmd.Parameters.Add("@numguia", SqlDbType.Char, 10).Value = BE.numguia;
                        cmd.Parameters.Add("@afectoigvid", SqlDbType.Char, 1).Value = BE.afectoigvid;
                        cmd.Parameters.Add("@incprec", SqlDbType.Bit).Value = BE.incprec;
                        cmd.Parameters.Add("@vendedorid", SqlDbType.Char, 4).Value = BE.vendedorid;
                        cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                        cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 100).Value = BE.glosa;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        //cmd.Parameters.Add("@tcamb", SqlDbType.Decimal).Value = BE.tcamb;
                        cmd.Parameters.Add("@ordencs", SqlDbType.Char, 10).Value = BE.ordencs;
                        //cmd.Parameters.Add("@comisionvta", SqlDbType.Decimal).Value = BE.comisionvta;
                        //cmd.Parameters.Add("@porcvta", SqlDbType.Decimal).Value = BE.porcvta;
                        //cmd.Parameters.Add("@porcefect", SqlDbType.Decimal).Value = BE.porcefect;
                        cmd.Parameters.Add("@observ1", SqlDbType.VarChar, 100).Value = BE.observ1;
                        cmd.Parameters.Add("@observ2", SqlDbType.VarChar, 100).Value = BE.observ2;
                        cmd.Parameters.Add("@observ3", SqlDbType.VarChar, 100).Value = BE.observ3;
                        cmd.Parameters.Add("@observ4", SqlDbType.VarChar, 100).Value = BE.observ4;
                        cmd.Parameters.Add("@observ5", SqlDbType.VarChar, 100).Value = BE.observ5;
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

        public DataSet GetAsientoNume(string empresaid, tb_co_Ventasdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoVentasdet_SEARCH_asientonume", cnx))
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
        

        public DataSet GetOne(string empresaid, tb_co_Ventasdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoVentasdet_SELECT", cnx))
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
