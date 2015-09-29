﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_co_retencionesDA
    {
        public String Sql_Error = "";
        Conexion conex = new Conexion();

        public bool Insert(string empresaid, tb_co_retenciones BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRetenciones_INSERT", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                    cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
                    cmd.Parameters.AddWithValue("@tiporegistro", string.IsNullOrEmpty(BE.tiporegistro) ? (object)DBNull.Value : BE.tiporegistro);
                    cmd.Parameters.AddWithValue("@ctacte", string.IsNullOrEmpty(BE.ctacte) ? (object)DBNull.Value : BE.ctacte);
                    cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                    cmd.Parameters.AddWithValue("@ctactename", string.IsNullOrEmpty(BE.ctactename) ? (object)DBNull.Value : BE.ctactename);
                    cmd.Parameters.AddWithValue("@direc", string.IsNullOrEmpty(BE.direc) ? (object)DBNull.Value : BE.direc);
                    cmd.Parameters.AddWithValue("@ubige", string.IsNullOrEmpty(BE.ubige) ? (object)DBNull.Value : BE.ubige);
                    cmd.Parameters.AddWithValue("@tipdoc", string.IsNullOrEmpty(BE.tipdoc) ? (object)DBNull.Value : BE.tipdoc);
                    cmd.Parameters.AddWithValue("@serdoc", string.IsNullOrEmpty(BE.serdoc) ? (object)DBNull.Value : BE.serdoc);
                    cmd.Parameters.AddWithValue("@numdoc", string.IsNullOrEmpty(BE.numdoc) ? (object)DBNull.Value : BE.numdoc);
                    cmd.Parameters.AddWithValue("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                    cmd.Parameters.AddWithValue("@fechvcto", SqlDbType.DateTime).Value = BE.fechvcto;
                    cmd.Parameters.AddWithValue("@moneda", string.IsNullOrEmpty(BE.moneda) ? (object)DBNull.Value : BE.moneda);
                    cmd.Parameters.AddWithValue("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                    cmd.Parameters.AddWithValue("@tipcambuso", string.IsNullOrEmpty(BE.tipcambuso) ? (object)DBNull.Value : BE.tipcambuso);
                    cmd.Parameters.AddWithValue("@glosa", string.IsNullOrEmpty(BE.glosa) ? (object)DBNull.Value : BE.glosa);
                    cmd.Parameters.AddWithValue("@diadioidpago", string.IsNullOrEmpty(BE.diarioidpago) ? (object)DBNull.Value : BE.diarioidpago);
                    cmd.Parameters.AddWithValue("@monedap", string.IsNullOrEmpty(BE.monedap) ? (object)DBNull.Value : BE.monedap);
                    cmd.Parameters.AddWithValue("@numdocpago", string.IsNullOrEmpty(BE.numdocpago) ? (object)DBNull.Value : BE.numdocpago);
                    cmd.Parameters.AddWithValue("@flujoefectivo", string.IsNullOrEmpty(BE.flujoefectivo) ? (object)DBNull.Value : BE.flujoefectivo);
                    cmd.Parameters.AddWithValue("@mediopago", string.IsNullOrEmpty(BE.mediopago) ? (object)DBNull.Value : BE.mediopago);
                    cmd.Parameters.AddWithValue("@importeoriginal", SqlDbType.Decimal).Value = BE.importeoriginal;
                    cmd.Parameters.AddWithValue("@importepago", SqlDbType.Decimal).Value = BE.importepago;
                    cmd.Parameters.AddWithValue("@importeretencion", SqlDbType.Decimal).Value = BE.importeretencion;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd.Parameters.AddWithValue("@usuar", string.IsNullOrEmpty(BE.usuar) ? (object)DBNull.Value : BE.usuar);

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

        public bool Update(string empresaid, tb_co_retenciones BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRetenciones_UPDATE", cnx))
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
                        cmd.Parameters.AddWithValue("@tiporegistro", string.IsNullOrEmpty(BE.tiporegistro) ? (object)DBNull.Value : BE.tiporegistro);
                        cmd.Parameters.AddWithValue("@ctacte", string.IsNullOrEmpty(BE.ctacte) ? (object)DBNull.Value : BE.ctacte);
                        cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                        cmd.Parameters.AddWithValue("@ctactename", string.IsNullOrEmpty(BE.ctactename) ? (object)DBNull.Value : BE.ctactename);
                        cmd.Parameters.AddWithValue("@direc", string.IsNullOrEmpty(BE.direc) ? (object)DBNull.Value : BE.direc);
                        cmd.Parameters.AddWithValue("@ubige", string.IsNullOrEmpty(BE.ubige) ? (object)DBNull.Value : BE.ubige);
                        cmd.Parameters.AddWithValue("@tipdoc", string.IsNullOrEmpty(BE.tipdoc) ? (object)DBNull.Value : BE.tipdoc);
                        cmd.Parameters.AddWithValue("@serdoc", string.IsNullOrEmpty(BE.serdoc) ? (object)DBNull.Value : BE.serdoc);
                        cmd.Parameters.AddWithValue("@numdoc", string.IsNullOrEmpty(BE.numdoc) ? (object)DBNull.Value : BE.numdoc);
                        cmd.Parameters.AddWithValue("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                        cmd.Parameters.AddWithValue("@fechvcto", SqlDbType.DateTime).Value = BE.fechvcto;
                        cmd.Parameters.AddWithValue("@moneda", string.IsNullOrEmpty(BE.moneda) ? (object)DBNull.Value : BE.moneda);
                        cmd.Parameters.AddWithValue("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                        cmd.Parameters.AddWithValue("@tipcambuso", string.IsNullOrEmpty(BE.tipcambuso) ? (object)DBNull.Value : BE.tipcambuso);
                        cmd.Parameters.AddWithValue("@glosa", string.IsNullOrEmpty(BE.glosa) ? (object)DBNull.Value : BE.glosa);
                        cmd.Parameters.AddWithValue("@diadioidpago", string.IsNullOrEmpty(BE.diarioidpago) ? (object)DBNull.Value : BE.diarioidpago);
                        cmd.Parameters.AddWithValue("@monedap", string.IsNullOrEmpty(BE.monedap) ? (object)DBNull.Value : BE.monedap);
                        cmd.Parameters.AddWithValue("@numdocpago", string.IsNullOrEmpty(BE.numdocpago) ? (object)DBNull.Value : BE.numdocpago);
                        cmd.Parameters.AddWithValue("@flujoefectivo", string.IsNullOrEmpty(BE.flujoefectivo) ? (object)DBNull.Value : BE.flujoefectivo);
                        cmd.Parameters.AddWithValue("@mediopago", string.IsNullOrEmpty(BE.mediopago) ? (object)DBNull.Value : BE.mediopago);
                        cmd.Parameters.AddWithValue("@importeoriginal", SqlDbType.Decimal).Value = BE.importeoriginal;
                        cmd.Parameters.AddWithValue("@importepago", SqlDbType.Decimal).Value = BE.importepago;
                        cmd.Parameters.AddWithValue("@importeretencion", SqlDbType.Decimal).Value = BE.importeretencion;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.AddWithValue("@usuar", string.IsNullOrEmpty(BE.usuar) ? (object)DBNull.Value : BE.usuar);

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

        public DataSet ReporteLibroRetenciones(string empresaid, tb_co_retenciones BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRetenciones_ReporteLibroRetencion", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                        cmd.Parameters.AddWithValue("@asientoini", string.IsNullOrEmpty(BE.asientoini) ? (object)DBNull.Value : BE.asientoini);
                        cmd.Parameters.AddWithValue("@asientofin", string.IsNullOrEmpty(BE.asientofin) ? (object)DBNull.Value : BE.asientofin);
                        if (BE.fimpresion == "")
                        { cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = BE.fimpresion; }
                        //cmd.Parameters.AddWithValue("@fimpresion", string.IsNullOrEmpty(BE.fimpresion) ? (object)DBNull.Value : BE.fimpresion);
                        cmd.Parameters.Add("@norden", SqlDbType.Int).Value = BE.norden;
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
        public DataSet ReporteLibroRetencionesResumen(string empresaid, tb_co_retenciones BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRetenciones_ReporteRetencionResumen", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                        cmd.Parameters.AddWithValue("@asientoini", string.IsNullOrEmpty(BE.asientoini) ? (object)DBNull.Value : BE.asientoini);
                        cmd.Parameters.AddWithValue("@asientofin", string.IsNullOrEmpty(BE.asientofin) ? (object)DBNull.Value : BE.asientofin);
                        if (BE.fimpresion == "")
                        { cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = BE.fimpresion; }
                        //cmd.Parameters.AddWithValue("@fimpresion", string.IsNullOrEmpty(BE.fimpresion) ? (object)DBNull.Value : BE.fimpresion);
                        cmd.Parameters.Add("@norden", SqlDbType.Int).Value = BE.norden;
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

        public DataSet GetGeneraPDT0626Retenciones(string empresaid, tb_co_retenciones BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRetenciones_GeneraDataPDTRetenciones", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
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

        public bool Delete(string empresaid, tb_co_retenciones BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRetenciones_DELETE", cnx))
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public DataSet ReporteLibroRetencionesNmruc(string empresaid, tb_co_retenciones BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRetenciones_ReporteLibroRetencion_nmruc", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        if (BE.fechaini == "")
                        { cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = BE.fechaini; }
                        if (BE.fechafin == "")
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = BE.fechafin; }

                        cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                        cmd.Parameters.AddWithValue("@asientoini", string.IsNullOrEmpty(BE.asientoini) ? (object)DBNull.Value : BE.asientoini);
                        cmd.Parameters.AddWithValue("@asientofin", string.IsNullOrEmpty(BE.asientofin) ? (object)DBNull.Value : BE.asientofin);
                        if (BE.fimpresion == "")
                        { cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = BE.fimpresion; }
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

        public DataSet ReporteLibroRetencionesVerificar(string empresaid, tb_co_retenciones BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRetenciones_ReporteLibroRetencion_porc", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        if (BE.fechaini == "")
                        { cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = BE.fechaini; }
                        if (BE.fechafin == "")
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = BE.fechafin; }

                        cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                        cmd.Parameters.AddWithValue("@asientoini", string.IsNullOrEmpty(BE.asientoini) ? (object)DBNull.Value : BE.asientoini);
                        cmd.Parameters.AddWithValue("@asientofin", string.IsNullOrEmpty(BE.asientofin) ? (object)DBNull.Value : BE.asientofin);
                        if (BE.fimpresion == "")
                        { cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = BE.fimpresion; }
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

        //public DataSet GetAll(string empresaid, tb_co_retenciones BE)
        //{
        //    using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("gspTbCoRetenciones_SEARCH", cnx))
        //        {
        //            DataSet ds = new DataSet();
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
        //                cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
        //                cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
        //                cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
        //                cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
        //                cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
        //                cmd.Parameters.AddWithValue("@tiporegistro", string.IsNullOrEmpty(BE.tiporegistro) ? (object)DBNull.Value : BE.tiporegistro);
        //                cmd.Parameters.AddWithValue("@ctacte", string.IsNullOrEmpty(BE.ctacte) ? (object)DBNull.Value : BE.ctacte);
        //                cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
        //                cmd.Parameters.AddWithValue("@ctactename", string.IsNullOrEmpty(BE.ctactename) ? (object)DBNull.Value : BE.ctactename);
        //                cmd.Parameters.AddWithValue("@direc", string.IsNullOrEmpty(BE.direc) ? (object)DBNull.Value : BE.direc);
        //                cmd.Parameters.AddWithValue("@ubige", string.IsNullOrEmpty(BE.ubige) ? (object)DBNull.Value : BE.ubige);
        //                cmd.Parameters.AddWithValue("@tipdoc", string.IsNullOrEmpty(BE.tipdoc) ? (object)DBNull.Value : BE.tipdoc);
        //                cmd.Parameters.AddWithValue("@serdoc", string.IsNullOrEmpty(BE.serdoc) ? (object)DBNull.Value : BE.serdoc);
        //                cmd.Parameters.AddWithValue("@numdoc", string.IsNullOrEmpty(BE.numdoc) ? (object)DBNull.Value : BE.numdoc);
        //                cmd.Parameters.AddWithValue("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
        //                cmd.Parameters.AddWithValue("@fechvcto", SqlDbType.DateTime).Value = BE.fechvcto;
        //                cmd.Parameters.AddWithValue("@moneda", string.IsNullOrEmpty(BE.moneda) ? (object)DBNull.Value : BE.moneda);
        //                //cmd.Parameters.AddWithValue("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
        //                cmd.Parameters.AddWithValue("@tipcambuso", string.IsNullOrEmpty(BE.tipcambuso) ? (object)DBNull.Value : BE.tipcambuso);
        //                cmd.Parameters.AddWithValue("@glosa", string.IsNullOrEmpty(BE.glosa) ? (object)DBNull.Value : BE.glosa);
        //                cmd.Parameters.AddWithValue("@diarioidpago", string.IsNullOrEmpty(BE.diarioidpago) ? (object)DBNull.Value : BE.diarioidpago);
        //                cmd.Parameters.AddWithValue("@monedap", string.IsNullOrEmpty(BE.monedap) ? (object)DBNull.Value : BE.monedap);
        //                cmd.Parameters.AddWithValue("@numdocpago", string.IsNullOrEmpty(BE.numdocpago) ? (object)DBNull.Value : BE.numdocpago);
        //                cmd.Parameters.AddWithValue("@flujoefectivo", string.IsNullOrEmpty(BE.flujoefectivo) ? (object)DBNull.Value : BE.flujoefectivo);
        //                cmd.Parameters.AddWithValue("@mediopago", string.IsNullOrEmpty(BE.mediopago) ? (object)DBNull.Value : BE.mediopago);
        //                //cmd.Parameters.AddWithValue("@importeoriginal", SqlDbType.Decimal).Value = BE.importeoriginal;
        //                //cmd.Parameters.AddWithValue("@importepago", SqlDbType.Decimal).Value = BE.importepago;
        //                //cmd.Parameters.AddWithValue("@importeretencion", SqlDbType.Decimal).Value = BE.importeretencion;
        //                cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
        //                cmd.Parameters.AddWithValue("@usuar", string.IsNullOrEmpty(BE.usuar) ? (object)DBNull.Value : BE.usuar);
        //            }
        //            try
        //            {
        //                cnx.Open();
        //                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        //                {
        //                    da.Fill(ds);
        //                }
        //                return ds;
        //            }
        //            catch (Exception ex)
        //            {
        //                throw new Exception(ex.Message);
        //            }
        //        }
        //    }
        //}

        //public DataSet GetOne(string empresaid, tb_co_retenciones BE)
        //{
        //    using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("gspTbCoRetenciones_SELECT", cnx))
        //        {
        //            DataSet ds = new DataSet();

        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
        //                cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
        //                cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
        //                cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
        //                cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
        //                cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
        //            }

        //            try
        //            {
        //                cnx.Open();
        //                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        //                {
        //                    da.Fill(ds);
        //                }
        //                return ds;
        //            }
        //            catch (Exception ex)
        //            {
        //                throw new Exception(ex.Message);
        //            }
        //        }
        //    }
        //}
    }
}