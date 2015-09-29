using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class mp_movimientosdetDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_mp_movimientosdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpMovimientosdet_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd.Parameters.Add("@items", SqlDbType.Char, 5).Value = BE.items;
                    cmd.Parameters.Add("@status", SqlDbType.Char).Value = BE.status;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                    cmd.Parameters.Add("@direcnume", SqlDbType.VarChar, 3).Value = BE.direcnume;
                    cmd.Parameters.Add("@direcname", SqlDbType.VarChar, 25).Value = BE.direcname;
                    cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                    cmd.Parameters.Add("@productname", SqlDbType.Char, 70).Value = BE.productname;
                    cmd.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE.almacaccionid;
                    cmd.Parameters.Add("@ctacteaccionid", SqlDbType.Char, 2).Value = BE.ctacteaccionid;
                    cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                    cmd.Parameters.Add("@itemref", SqlDbType.Char, 5).Value = BE.itemref;
                    cmd.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = BE.cantidad;
                    cmd.Parameters.Add("@valor", SqlDbType.Decimal).Value = BE.valor;
                    cmd.Parameters.Add("@importe", SqlDbType.Decimal).Value = BE.importe;
                    cmd.Parameters.Add("@cantidadcta", SqlDbType.Decimal).Value = BE.cantidadcta;
                    cmd.Parameters.Add("@cantidadfac", SqlDbType.Decimal).Value = BE.cantidadfac;
                    cmd.Parameters.Add("@precunit", SqlDbType.Decimal).Value = BE.precunit;
                    cmd.Parameters.Add("@importfac", SqlDbType.Decimal).Value = BE.importfac;
                    cmd.Parameters.Add("@dscto1", SqlDbType.Decimal).Value = BE.dscto1;
                    cmd.Parameters.Add("@dscto2", SqlDbType.Decimal).Value = BE.dscto2;
                    cmd.Parameters.Add("@dscto3", SqlDbType.Decimal).Value = BE.dscto3;
                    cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                    cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                    cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                    cmd.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE.fechref;
                    cmd.Parameters.Add("@tipoperef", SqlDbType.Char, 2).Value = BE.tipoperef;
                    cmd.Parameters.Add("@tip_op", SqlDbType.Char, 2).Value = BE.tip_op;
                    cmd.Parameters.Add("@ser_op", SqlDbType.Char, 4).Value = BE.ser_op;
                    cmd.Parameters.Add("@num_op", SqlDbType.Char, 10).Value = BE.num_op;
                    cmd.Parameters.Add("@tipfac", SqlDbType.Char, 2).Value = BE.tipfac;
                    cmd.Parameters.Add("@serfac", SqlDbType.Char, 4).Value = BE.serfac;
                    cmd.Parameters.Add("@numfac", SqlDbType.Char, 10).Value = BE.numfac;
                    cmd.Parameters.Add("@fechfac", SqlDbType.DateTime).Value = BE.fechfac;
                    cmd.Parameters.Add("@tipguia", SqlDbType.Char, 2).Value = BE.tipguia;
                    cmd.Parameters.Add("@serguia", SqlDbType.Char, 4).Value = BE.serguia;
                    cmd.Parameters.Add("@numguia", SqlDbType.Char, 10).Value = BE.numguia;
                    cmd.Parameters.Add("@fechguia", SqlDbType.DateTime).Value = BE.fechguia;
                    cmd.Parameters.Add("@tipnotac", SqlDbType.Char, 2).Value = BE.tipnotac;
                    cmd.Parameters.Add("@sernotac", SqlDbType.Char, 4).Value = BE.sernotac;
                    cmd.Parameters.Add("@numnotac", SqlDbType.Char, 10).Value = BE.numnotac;
                    cmd.Parameters.Add("@fechnotac", SqlDbType.DateTime).Value = BE.fechnotac;
                    cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                    cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                    cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                    cmd.Parameters.Add("@tcamb", SqlDbType.Decimal).Value = BE.tcamb;
                    cmd.Parameters.Add("@tiptransac", SqlDbType.Char, 1).Value = BE.tiptransac;
                    cmd.Parameters.Add("@motivotrasladoid", SqlDbType.Char, 1).Value = BE.motivotrasladoid;
                    cmd.Parameters.Add("@statcostopromed", SqlDbType.Char, 1).Value = BE.statcostopromed;
                    cmd.Parameters.Add("@incprec", SqlDbType.Char, 1).Value = BE.incprec;
                    cmd.Parameters.Add("@igv", SqlDbType.Decimal).Value = BE.igv;
                    cmd.Parameters.Add("@totimpto", SqlDbType.Decimal).Value = BE.totimpto;
                    cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 30).Value = BE.glosa;
                    cmd.Parameters.Add("@rollo", SqlDbType.Char, 10).Value = BE.rollo;
                    cmd.Parameters.Add("@codctadebe", SqlDbType.Char, 10).Value = BE.codctadebe;
                    cmd.Parameters.Add("@codctahaber", SqlDbType.Char, 10).Value = BE.codctahaber;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
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

        public bool Update(string empresaid, tb_mp_movimientosdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpMovimientosdet_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@items", SqlDbType.Char, 5).Value = BE.items;
                        cmd.Parameters.Add("@status", SqlDbType.Char).Value = BE.status;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                        cmd.Parameters.Add("@direcnume", SqlDbType.VarChar, 3).Value = BE.direcnume;
                        cmd.Parameters.Add("@direcname", SqlDbType.VarChar, 25).Value = BE.direcname;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@productname", SqlDbType.Char, 70).Value = BE.productname;
                        cmd.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE.almacaccionid;
                        cmd.Parameters.Add("@ctacteaccionid", SqlDbType.Char, 2).Value = BE.ctacteaccionid;
                        cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                        cmd.Parameters.Add("@itemref", SqlDbType.Char, 5).Value = BE.itemref;
                        cmd.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = BE.cantidad;
                        cmd.Parameters.Add("@valor", SqlDbType.Decimal).Value = BE.valor;
                        cmd.Parameters.Add("@importe", SqlDbType.Decimal).Value = BE.importe;
                        cmd.Parameters.Add("@cantidadcta", SqlDbType.Decimal).Value = BE.cantidadcta;
                        cmd.Parameters.Add("@cantidadfac", SqlDbType.Decimal).Value = BE.cantidadfac;
                        cmd.Parameters.Add("@precunit", SqlDbType.Decimal).Value = BE.precunit;
                        cmd.Parameters.Add("@importfac", SqlDbType.Decimal).Value = BE.importfac;
                        cmd.Parameters.Add("@dscto1", SqlDbType.Decimal).Value = BE.dscto1;
                        cmd.Parameters.Add("@dscto2", SqlDbType.Decimal).Value = BE.dscto2;
                        cmd.Parameters.Add("@dscto3", SqlDbType.Decimal).Value = BE.dscto3;
                        cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                        cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                        cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                        cmd.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE.fechref;
                        cmd.Parameters.Add("@tipoperef", SqlDbType.Char, 2).Value = BE.tipoperef;
                        cmd.Parameters.Add("@tip_op", SqlDbType.Char, 2).Value = BE.tip_op;
                        cmd.Parameters.Add("@ser_op", SqlDbType.Char, 4).Value = BE.ser_op;
                        cmd.Parameters.Add("@num_op", SqlDbType.Char, 10).Value = BE.num_op;
                        cmd.Parameters.Add("@tipfac", SqlDbType.Char, 2).Value = BE.tipfac;
                        cmd.Parameters.Add("@serfac", SqlDbType.Char, 4).Value = BE.serfac;
                        cmd.Parameters.Add("@numfac", SqlDbType.Char, 10).Value = BE.numfac;
                        cmd.Parameters.Add("@fechfac", SqlDbType.DateTime).Value = BE.fechfac;
                        cmd.Parameters.Add("@tipguia", SqlDbType.Char, 2).Value = BE.tipguia;
                        cmd.Parameters.Add("@serguia", SqlDbType.Char, 4).Value = BE.serguia;
                        cmd.Parameters.Add("@numguia", SqlDbType.Char, 10).Value = BE.numguia;
                        cmd.Parameters.Add("@fechguia", SqlDbType.DateTime).Value = BE.fechguia;
                        cmd.Parameters.Add("@tipnotac", SqlDbType.Char, 2).Value = BE.tipnotac;
                        cmd.Parameters.Add("@sernotac", SqlDbType.Char, 4).Value = BE.sernotac;
                        cmd.Parameters.Add("@numnotac", SqlDbType.Char, 10).Value = BE.numnotac;
                        cmd.Parameters.Add("@fechnotac", SqlDbType.DateTime).Value = BE.fechnotac;
                        cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                        cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@tcamb", SqlDbType.Decimal).Value = BE.tcamb;
                        cmd.Parameters.Add("@tiptransac", SqlDbType.Char, 1).Value = BE.tiptransac;
                        cmd.Parameters.Add("@motivotrasladoid", SqlDbType.Char, 1).Value = BE.motivotrasladoid;
                        cmd.Parameters.Add("@statcostopromed", SqlDbType.Char, 1).Value = BE.statcostopromed;
                        cmd.Parameters.Add("@incprec", SqlDbType.Char, 1).Value = BE.incprec;
                        cmd.Parameters.Add("@igv", SqlDbType.Decimal).Value = BE.igv;
                        cmd.Parameters.Add("@totimpto", SqlDbType.Decimal).Value = BE.totimpto;
                        cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 30).Value = BE.glosa;
                        cmd.Parameters.Add("@rollo", SqlDbType.Char, 10).Value = BE.rollo;
                        cmd.Parameters.Add("@codctadebe", SqlDbType.Char, 10).Value = BE.codctadebe;
                        cmd.Parameters.Add("@codctahaber", SqlDbType.Char, 10).Value = BE.codctahaber;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
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

        public bool Delete(string empresaid, tb_mp_movimientosdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpMovimientosdet_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@items", SqlDbType.Char, 5).Value = BE.items;
                        cmd.Parameters.Add("@status", SqlDbType.Char).Value = BE.status;
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

        public DataSet GetAll(string empresaid, tb_mp_movimientosdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpMovimientosdet_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@items", SqlDbType.Char, 5).Value = BE.items;
                        cmd.Parameters.Add("@status", SqlDbType.Char).Value = BE.status;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                        cmd.Parameters.Add("@direcnume", SqlDbType.VarChar, 3).Value = BE.direcnume;
                        cmd.Parameters.Add("@direcname", SqlDbType.VarChar, 25).Value = BE.direcname;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@productname", SqlDbType.Char, 70).Value = BE.productname;
                        cmd.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE.almacaccionid;
                        cmd.Parameters.Add("@ctacteaccionid", SqlDbType.Char, 2).Value = BE.ctacteaccionid;
                        cmd.Parameters.Add("@itemref", SqlDbType.Char, 5).Value = BE.itemref;
                        cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                        cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                        cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                        cmd.Parameters.Add("@tipoperef", SqlDbType.Char, 2).Value = BE.tipoperef;
                        cmd.Parameters.Add("@tip_op", SqlDbType.Char, 2).Value = BE.tip_op;
                        cmd.Parameters.Add("@ser_op", SqlDbType.Char, 4).Value = BE.ser_op;
                        cmd.Parameters.Add("@num_op", SqlDbType.Char, 10).Value = BE.num_op;
                        cmd.Parameters.Add("@tipfac", SqlDbType.Char, 2).Value = BE.tipfac;
                        cmd.Parameters.Add("@serfac", SqlDbType.Char, 2).Value = BE.serfac;
                        cmd.Parameters.Add("@numfac", SqlDbType.Char, 10).Value = BE.numfac;
                        cmd.Parameters.Add("@tipguia", SqlDbType.Char, 2).Value = BE.tipguia;
                        cmd.Parameters.Add("@tipnotac", SqlDbType.Char, 2).Value = BE.tipnotac;
                        cmd.Parameters.Add("@sernotac", SqlDbType.Char, 4).Value = BE.sernotac;
                        cmd.Parameters.Add("@numnotac", SqlDbType.Char, 10).Value = BE.numnotac;
                        cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                        cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@tiptransac", SqlDbType.Char, 1).Value = BE.tiptransac;
                        cmd.Parameters.Add("@motivotrasladoid", SqlDbType.Char, 1).Value = BE.motivotrasladoid;
                        cmd.Parameters.Add("@statcostopromed", SqlDbType.Char, 1).Value = BE.statcostopromed;
                        cmd.Parameters.Add("@incprec", SqlDbType.Char, 1).Value = BE.incprec;
                        cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 30).Value = BE.glosa;
                        cmd.Parameters.Add("@rollo", SqlDbType.Char, 10).Value = BE.rollo;
                        cmd.Parameters.Add("@codctadebe", SqlDbType.Char, 10).Value = BE.codctadebe;
                        cmd.Parameters.Add("@codctahaber", SqlDbType.Char, 10).Value = BE.codctahaber;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
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

        public DataSet GetAll_MpvProd(string empresaid, tb_mp_movimientosdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpMovimientosdet_MOVPROD", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@status", SqlDbType.Char).Value = BE.status;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE.almacaccionid;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
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

        public DataSet GetAll_Rango(string empresaid, tb_mp_movimientosdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpMovimientosdet_SEARCH_Rango", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@perianioini", SqlDbType.Char, 4).Value = BE.perianioini;
                        cmd.Parameters.Add("@perimesini", SqlDbType.Char, 2).Value = BE.perimesini;
                        cmd.Parameters.Add("@perianiofin", SqlDbType.Char, 4).Value = BE.perianiofin;
                        cmd.Parameters.Add("@perimesfin", SqlDbType.Char, 2).Value = BE.perimesfin;
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

        public DataSet GetAll6(string empresaid, tb_mp_movimientosdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpMovimientosdet_SEARCH_rptdoc", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@items", SqlDbType.Char, 5).Value = BE.items;
                        cmd.Parameters.Add("@status", SqlDbType.Char).Value = BE.status;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                        cmd.Parameters.Add("@direcnume", SqlDbType.VarChar, 3).Value = BE.direcnume;
                        cmd.Parameters.Add("@direcname", SqlDbType.VarChar, 25).Value = BE.direcname;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@productname", SqlDbType.Char, 70).Value = BE.productname;
                        cmd.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE.almacaccionid;
                        cmd.Parameters.Add("@ctacteaccionid", SqlDbType.Char, 2).Value = BE.ctacteaccionid;
                        cmd.Parameters.Add("@itemref", SqlDbType.Char, 5).Value = BE.itemref;
                        cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                        cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                        cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                        cmd.Parameters.Add("@tipoperef", SqlDbType.Char, 2).Value = BE.tipoperef;
                        cmd.Parameters.Add("@tip_op", SqlDbType.Char, 2).Value = BE.tip_op;
                        cmd.Parameters.Add("@ser_op", SqlDbType.Char, 4).Value = BE.ser_op;
                        cmd.Parameters.Add("@num_op", SqlDbType.Char, 10).Value = BE.num_op;
                        cmd.Parameters.Add("@tipfac", SqlDbType.Char, 2).Value = BE.tipfac;
                        cmd.Parameters.Add("@serfac", SqlDbType.Char, 2).Value = BE.serfac;
                        cmd.Parameters.Add("@numfac", SqlDbType.Char, 10).Value = BE.numfac;
                        cmd.Parameters.Add("@tipguia", SqlDbType.Char, 2).Value = BE.tipguia;
                        cmd.Parameters.Add("@tipnotac", SqlDbType.Char, 2).Value = BE.tipnotac;
                        cmd.Parameters.Add("@sernotac", SqlDbType.Char, 4).Value = BE.sernotac;
                        cmd.Parameters.Add("@numnotac", SqlDbType.Char, 10).Value = BE.numnotac;
                        cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                        cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@tiptransac", SqlDbType.Char, 1).Value = BE.tiptransac;
                        cmd.Parameters.Add("@motivotrasladoid", SqlDbType.Char, 1).Value = BE.motivotrasladoid;
                        cmd.Parameters.Add("@statcostopromed", SqlDbType.Char, 1).Value = BE.statcostopromed;
                        cmd.Parameters.Add("@incprec", SqlDbType.Char, 1).Value = BE.incprec;
                        cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 30).Value = BE.glosa;
                        cmd.Parameters.Add("@rollo", SqlDbType.Char, 10).Value = BE.rollo;
                        cmd.Parameters.Add("@codctadebe", SqlDbType.Char, 10).Value = BE.codctadebe;
                        cmd.Parameters.Add("@codctahaber", SqlDbType.Char, 10).Value = BE.codctahaber;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
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

        public DataSet GetAll_Balance(string empresaid, tb_mp_movimientosdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpMovimientosdet_SEARCH_Balance", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@lineaid", SqlDbType.Char, 3).Value = BE.lineaid;
                        cmd.Parameters.Add("@grupoid", SqlDbType.Char, 4).Value = BE.grupoid;
                        cmd.Parameters.Add("@subgrupoid", SqlDbType.Char, 10).Value = BE.subgrupoid;
                        cmd.Parameters.Add("@productidini", SqlDbType.Char, 13).Value = BE.productidini;
                        cmd.Parameters.Add("@productidfin", SqlDbType.Char, 13).Value = BE.productidfin;
                        cmd.Parameters.Add("@fechdocini", SqlDbType.DateTime).Value = BE.fechdocini;
                        cmd.Parameters.Add("@fechdocfin", SqlDbType.DateTime).Value = BE.fechdocfin;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@tip_op", SqlDbType.Char, 2).Value = BE.tip_op;
                        cmd.Parameters.Add("@ser_op", SqlDbType.Char, 4).Value = BE.ser_op;
                        cmd.Parameters.Add("@num_op", SqlDbType.Char, 10).Value = BE.num_op;
                        cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                        cmd.Parameters.Add("@stockmayorquecero", SqlDbType.Char, 1).Value = BE.stockmayorquecero;
                        cmd.Parameters.Add("@accion", SqlDbType.Char, 1).Value = BE.accion;
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

        public DataSet GetOne(string empresaid, tb_mp_movimientosdet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpMovimientosdet_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@items", SqlDbType.Char, 5).Value = BE.items;
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
