using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_co_retencionCAbDA
    {
        public String Sql_Error = "";
        Conexion conex = new Conexion();

        //public bool Insert(string empresaid, tb_co_retencionCAb BE)
        //{
        //    using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("gspTbCoRetencioncab_INSERT", cnx))
        //        {
        //            cmd.CommandTimeout = 0;
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
        //            cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
        //            cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
        //            cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
        //            cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
        //            cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
        //            cmd.Parameters.AddWithValue("@ctacte", string.IsNullOrEmpty(BE.ctacte) ? (object)DBNull.Value : BE.ctacte);
        //            cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
        //            cmd.Parameters.AddWithValue("@ctactename", string.IsNullOrEmpty(BE.ctactename) ? (object)DBNull.Value : BE.ctactename);
        //            cmd.Parameters.AddWithValue("@tipdoc", string.IsNullOrEmpty(BE.tipdoc) ? (object)DBNull.Value : BE.tipdoc);
        //            cmd.Parameters.AddWithValue("@serdoc", string.IsNullOrEmpty(BE.serdoc) ? (object)DBNull.Value : BE.serdoc);
        //            cmd.Parameters.AddWithValue("@numdoc", string.IsNullOrEmpty(BE.numdoc) ? (object)DBNull.Value : BE.numdoc);
        //            cmd.Parameters.AddWithValue("@fechregistro", SqlDbType.DateTime).Value = BE.fechregistro;
        //            cmd.Parameters.AddWithValue("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
        //            cmd.Parameters.AddWithValue("@moneda", string.IsNullOrEmpty(BE.moneda) ? (object)DBNull.Value : BE.moneda);
        //            cmd.Parameters.AddWithValue("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
        //            cmd.Parameters.AddWithValue("@glosa", string.IsNullOrEmpty(BE.glosa) ? (object)DBNull.Value : BE.glosa);
        //            cmd.Parameters.AddWithValue("@montopago1", SqlDbType.Decimal).Value = BE.montopago1;
        //            cmd.Parameters.AddWithValue("@impretencion1", SqlDbType.Decimal).Value = BE.impretencion1;
        //            cmd.Parameters.AddWithValue("@montopago2", SqlDbType.Decimal).Value = BE.montopago2;
        //            cmd.Parameters.AddWithValue("@impretencion2", SqlDbType.Decimal).Value = BE.montopago1;
        //            cmd.Parameters.AddWithValue("@porcretencion", SqlDbType.Decimal).Value = BE.porcretencion;
        //            cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
        //            cmd.Parameters.AddWithValue("@usuar", string.IsNullOrEmpty(BE.usuar) ? (object)DBNull.Value : BE.usuar);
        //            try
        //            {
        //                cnx.Open();
        //                if (cmd.ExecuteNonQuery() > 0)
        //                {
        //                    return true;
        //                }
        //                else
        //                {
        //                    return false;
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                Sql_Error = ex.Message;
        //                throw new Exception(ex.Message);
        //            }
        //        }
        //    }
        //}

        public bool Insert_Update(string empresaid, DataTable cabecera, DataTable detalle)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                bool xreturn = true;
                int lc_contcab = 0;
                int lccontdetalle = 0;
                for (lc_contcab = 0; lc_contcab <= cabecera.Rows.Count - 1; lc_contcab++)
                {
                    if ((cabecera != null))
                    {
                        using (SqlCommand cmd = new SqlCommand("gspTbCoRetencionDEt_DELETE", cnx))
                        {
                            cmd.CommandTimeout = 0;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = cabecera.Rows[lc_contcab]["perianio"];
                            cmd.Parameters.Add("@perimes", SqlDbType.Char).Value = cabecera.Rows[lc_contcab]["perimes"];
                            cmd.Parameters.Add("@moduloid", SqlDbType.Char).Value = cabecera.Rows[lc_contcab]["moduloid"];
                            cmd.Parameters.Add("@local", SqlDbType.Char).Value = cabecera.Rows[lc_contcab]["local"];
                            cmd.Parameters.Add("@diarioid", SqlDbType.Char).Value = cabecera.Rows[lc_contcab]["diarioid"];
                            cmd.Parameters.Add("@asiento", SqlDbType.Char).Value = cabecera.Rows[lc_contcab]["asiento"];
                            try
                            {
                                cnx.Open();
                                if (cmd.ExecuteNonQuery() > 0)
                                {
                                    xreturn = true;
                                }
                                else
                                {
                                    xreturn = false;
                                }
                                cnx.Close();
                            }
                            catch (Exception ex)
                            {
                                Sql_Error = ex.Message;
                                //throw new Exception(ex.Message);
                                xreturn = false;
                                cnx.Close();
                            }
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand("gspTbCoRetencionCAb_InsertUpdate", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = cabecera.Rows[lc_contcab]["perianio"];
                        cmd.Parameters.Add("@perimes", SqlDbType.Char).Value = cabecera.Rows[lc_contcab]["perimes"];
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char).Value = cabecera.Rows[lc_contcab]["moduloid"];
                        cmd.Parameters.Add("@local", SqlDbType.Char).Value = cabecera.Rows[lc_contcab]["local"];
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char).Value = cabecera.Rows[lc_contcab]["diarioid"];
                        cmd.Parameters.Add("@asiento", SqlDbType.Char).Value = cabecera.Rows[lc_contcab]["asiento"];
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char).Value = cabecera.Rows[lc_contcab]["ctacte"];
                        cmd.Parameters.Add("@nmruc", SqlDbType.Char).Value = cabecera.Rows[lc_contcab]["nmruc"];
                        cmd.Parameters.Add("@ctactename", SqlDbType.VarChar).Value = cabecera.Rows[lc_contcab]["ctactename"];
                        cmd.Parameters.Add("@tipdoc", SqlDbType.Char).Value = cabecera.Rows[lc_contcab]["tipdoc"];
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char).Value = cabecera.Rows[lc_contcab]["serdoc"];
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char).Value = cabecera.Rows[lc_contcab]["numdoc"];
                        cmd.Parameters.Add("@fechregistro", SqlDbType.DateTime).Value = cabecera.Rows[lc_contcab]["fechregistro"];
                        cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = cabecera.Rows[lc_contcab]["fechdoc"];
                        cmd.Parameters.Add("@moneda", SqlDbType.Char).Value = cabecera.Rows[lc_contcab]["moneda"];
                        cmd.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = cabecera.Rows[lc_contcab]["tipcamb"];
                        cmd.Parameters.Add("@glosa", SqlDbType.VarChar).Value = cabecera.Rows[lc_contcab]["glosa"];
                        cmd.Parameters.Add("@montopago1", SqlDbType.Decimal).Value = cabecera.Rows[lc_contcab]["montopago1"];
                        cmd.Parameters.Add("@impretencion1", SqlDbType.Decimal).Value = cabecera.Rows[lc_contcab]["impretencion1"];
                        cmd.Parameters.Add("@montopago2", SqlDbType.Decimal).Value = cabecera.Rows[lc_contcab]["montopago2"];
                        cmd.Parameters.Add("@impretencion2", SqlDbType.Decimal).Value = cabecera.Rows[lc_contcab]["impretencion2"];
                        cmd.Parameters.Add("@porcretencion", SqlDbType.Decimal).Value = cabecera.Rows[lc_contcab]["porcretencion"];
                        cmd.Parameters.Add("@status", SqlDbType.Char).Value = cabecera.Rows[lc_contcab]["status"];
                        cmd.Parameters.Add("@usuar", SqlDbType.Char).Value = cabecera.Rows[lc_contcab]["usuar"];                        
                        try
                        {
                            cnx.Open();
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                xreturn = true;
                            }
                            else
                            {
                                xreturn = false;
                            }
                            cnx.Close();
                        }
                        catch (Exception ex)
                        {
                            Sql_Error = ex.Message;
                            //throw new Exception(ex.Message);
                            xreturn = false;
                            cnx.Close();
                        }
                    }

                    try
                    {
                        if ((detalle != null))
                        {
                            for (lccontdetalle = 0; lccontdetalle <= detalle.Rows.Count - 1; lccontdetalle++)
                            {
                                using (SqlCommand cmd = new SqlCommand("gspTbCoRetencionDEt_InsertUpdate", cnx))
                                {
                                    cmd.CommandTimeout = 0;
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = detalle.Rows[lc_contcab]["perianio"];
                                    cmd.Parameters.Add("@perimes", SqlDbType.Char).Value = detalle.Rows[lc_contcab]["perimes"];
                                    cmd.Parameters.Add("@moduloid", SqlDbType.Char).Value = detalle.Rows[lc_contcab]["moduloid"];
                                    cmd.Parameters.Add("@local", SqlDbType.Char).Value = detalle.Rows[lc_contcab]["local"];
                                    cmd.Parameters.Add("@diarioid", SqlDbType.Char).Value = detalle.Rows[lc_contcab]["diarioid"];
                                    cmd.Parameters.Add("@asiento", SqlDbType.Char).Value = detalle.Rows[lc_contcab]["asiento"];
                                    cmd.Parameters.Add("@asientoitems", SqlDbType.Char).Value = detalle.Rows[lccontdetalle]["asientoitems"];
                                    cmd.Parameters.Add("@rubroid", SqlDbType.Char).Value = detalle.Rows[lccontdetalle]["rubroid"];
                                    cmd.Parameters.Add("@tipdoc", SqlDbType.Char).Value = detalle.Rows[lccontdetalle]["tipdoc"];
                                    cmd.Parameters.Add("@serdoc", SqlDbType.Char).Value = detalle.Rows[lccontdetalle]["serdoc"];
                                    cmd.Parameters.Add("@numdoc", SqlDbType.Char).Value = detalle.Rows[lccontdetalle]["numdoc"];
                                    cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = detalle.Rows[lccontdetalle]["fechdoc"];
                                    cmd.Parameters.Add("@moneda", SqlDbType.Char).Value = detalle.Rows[lccontdetalle]["moneda"];                                   
                                    cmd.Parameters.Add("@montopago1", SqlDbType.Decimal).Value = detalle.Rows[lccontdetalle]["montopago1"];
                                    cmd.Parameters.Add("@montopago2", SqlDbType.Decimal).Value = detalle.Rows[lccontdetalle]["montopago2"];
                                    cmd.Parameters.Add("@impretencion1", SqlDbType.Decimal).Value = detalle.Rows[lccontdetalle]["impretencion1"];
                                    cmd.Parameters.Add("@impretencion2", SqlDbType.Decimal).Value = detalle.Rows[lccontdetalle]["impretencion2"];
                                    cmd.Parameters.Add("@glosa", SqlDbType.VarChar).Value = detalle.Rows[lccontdetalle]["glosa"];
                                    cmd.Parameters.Add("@ctacte", SqlDbType.Char).Value = detalle.Rows[lccontdetalle]["ctacte"];
                                    cmd.Parameters.Add("@nmruc", SqlDbType.Char).Value = detalle.Rows[lccontdetalle]["nmruc"];
                                    cmd.Parameters.Add("@cencosid", SqlDbType.Char).Value = detalle.Rows[lccontdetalle]["cencosid"];
                                    cmd.Parameters.Add("@pedido", SqlDbType.Char).Value = detalle.Rows[lccontdetalle]["pedido"];
                                    cmd.Parameters.Add("@numop", SqlDbType.Char).Value = detalle.Rows[lccontdetalle]["numop"];
                                    cmd.Parameters.Add("@status", SqlDbType.Char).Value = detalle.Rows[lccontdetalle]["status"];
                                    cmd.Parameters.Add("@usuar", SqlDbType.Char).Value = detalle.Rows[lccontdetalle]["usuar"];
                                    try
                                    {
                                        cnx.Open();
                                        if (cmd.ExecuteNonQuery() > 0)
                                        {
                                            xreturn = true;
                                        }
                                        else
                                        {
                                            xreturn = false;
                                        }
                                        cnx.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        Sql_Error = ex.Message;
                                        //throw new Exception(ex.Message);
                                        xreturn = false;
                                        cnx.Close();
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //Sql_Error = ex.Message;
                        //retorno = 0;
                        //break;
                        ex.ToString();
                    }
                }
                return xreturn;
            }
        }
            
        //public bool Update(string empresaid, tb_co_retencionCAb BE)
        //{
        //    using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("gspTbCoRetencioncab_UPDATE", cnx))
        //        {
        //            {
        //                cmd.CommandTimeout = 0;
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
        //                cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
        //                cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
        //                cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
        //                cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
        //                cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
        //                cmd.Parameters.AddWithValue("@ctacte", string.IsNullOrEmpty(BE.ctacte) ? (object)DBNull.Value : BE.ctacte);
        //                cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
        //                cmd.Parameters.AddWithValue("@ctactename", string.IsNullOrEmpty(BE.ctactename) ? (object)DBNull.Value : BE.ctactename);
        //                cmd.Parameters.AddWithValue("@tipdoc", string.IsNullOrEmpty(BE.tipdoc) ? (object)DBNull.Value : BE.tipdoc);
        //                cmd.Parameters.AddWithValue("@serdoc", string.IsNullOrEmpty(BE.serdoc) ? (object)DBNull.Value : BE.serdoc);
        //                cmd.Parameters.AddWithValue("@numdoc", string.IsNullOrEmpty(BE.numdoc) ? (object)DBNull.Value : BE.numdoc);
        //                cmd.Parameters.AddWithValue("@fechregistro", SqlDbType.DateTime).Value = BE.fechregistro;
        //                cmd.Parameters.AddWithValue("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
        //                cmd.Parameters.AddWithValue("@moneda", string.IsNullOrEmpty(BE.moneda) ? (object)DBNull.Value : BE.moneda);
        //                cmd.Parameters.AddWithValue("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
        //                cmd.Parameters.AddWithValue("@glosa", string.IsNullOrEmpty(BE.glosa) ? (object)DBNull.Value : BE.glosa);
        //                cmd.Parameters.AddWithValue("@montopago1", SqlDbType.Decimal).Value = BE.montopago1;
        //                cmd.Parameters.AddWithValue("@impretencion1", SqlDbType.Decimal).Value = BE.impretencion1;
        //                cmd.Parameters.AddWithValue("@montopago2", SqlDbType.Decimal).Value = BE.montopago2;
        //                cmd.Parameters.AddWithValue("@impretencion2", SqlDbType.Decimal).Value = BE.montopago1;
        //                cmd.Parameters.AddWithValue("@porcretencion", SqlDbType.Decimal).Value = BE.porcretencion;
        //                cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
        //                cmd.Parameters.AddWithValue("@usuar", string.IsNullOrEmpty(BE.usuar) ? (object)DBNull.Value : BE.usuar);
        //            }
        //            try
        //            {
        //                cnx.Open();
        //                if (cmd.ExecuteNonQuery() > 0)
        //                {
        //                    return true;
        //                }
        //                else
        //                {
        //                    return false;
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                Sql_Error = ex.Message;
        //                throw new Exception(ex.Message);
        //            }
        //        }
        //    }
        //}

        //public bool Delete(string empresaid, tb_co_retencionCAb BE)
        //{
        //    using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("gspTbCoRetencioncab_DELETE", cnx))
        //        {
        //            {
        //                cmd.CommandTimeout = 0;
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
        //                if (cmd.ExecuteNonQuery() > 0)
        //                {
        //                    return true;
        //                }
        //                else
        //                {
        //                    return false;
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                Sql_Error = ex.Message;
        //                throw new Exception(ex.Message);
        //            }
        //        }
        //    }
        //}
        public bool Eliminar(string empresaid, DataTable cabecera)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                bool xreturn = true;
                int lcont = 0;
                for (lcont = 0; lcont <= cabecera.Rows.Count - 1; lcont++)
                {
                    using (SqlCommand cmd = new SqlCommand("gspTbCoRetencionCAb_DELETE", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = cabecera.Rows[lcont]["perianio"];
                        cmd.Parameters.Add("@perimes", SqlDbType.Char).Value = cabecera.Rows[lcont]["perimes"];
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char).Value = cabecera.Rows[lcont]["moduloid"];
                        cmd.Parameters.Add("@local", SqlDbType.Char).Value = cabecera.Rows[lcont]["local"];
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char).Value = cabecera.Rows[lcont]["diarioid"];
                        cmd.Parameters.Add("@asiento", SqlDbType.Char).Value = cabecera.Rows[lcont]["asiento"];
                        try
                        {
                            cnx.Open();
                            if (cmd.ExecuteNonQuery() > 0)
                            { xreturn = true; }
                            else
                            { xreturn = false; }
                            cnx.Close();
                        }
                        catch (Exception ex)
                        {
                            Sql_Error = ex.Message;
                            //throw new Exception(ex.Message);
                            xreturn = false;
                            cnx.Close();
                        }
                    }
                }
                return xreturn;
            }
        }

        public DataSet GetAll(string empresaid, tb_co_retencionCAb BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRetencionCAb_consulta", cnx))
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
                        //cmd.Parameters.AddWithValue("@ctacte", string.IsNullOrEmpty(BE.ctacte) ? (object)DBNull.Value : BE.ctacte);
                        cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                        //cmd.Parameters.AddWithValue("@ctactename", string.IsNullOrEmpty(BE.ctactename) ? (object)DBNull.Value : BE.ctactename);
                        cmd.Parameters.AddWithValue("@tipdoc", string.IsNullOrEmpty(BE.tipdoc) ? (object)DBNull.Value : BE.tipdoc);
                        cmd.Parameters.AddWithValue("@serdoc", string.IsNullOrEmpty(BE.serdoc) ? (object)DBNull.Value : BE.serdoc);
                        cmd.Parameters.AddWithValue("@numdoc", string.IsNullOrEmpty(BE.numdoc) ? (object)DBNull.Value : BE.numdoc);
                        //cmd.Parameters.AddWithValue("@fechregistro", SqlDbType.DateTime).Value = BE.fechregistro;
                        //cmd.Parameters.AddWithValue("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                        cmd.Parameters.AddWithValue("@fechaini", SqlDbType.DateTime).Value = BE.fechaini;
                        cmd.Parameters.AddWithValue("@fechafin", SqlDbType.DateTime).Value = BE.fechafin;
                        //cmd.Parameters.AddWithValue("@moneda", string.IsNullOrEmpty(BE.moneda) ? (object)DBNull.Value : BE.moneda);
                        //cmd.Parameters.AddWithValue("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                        //cmd.Parameters.AddWithValue("@glosa", string.IsNullOrEmpty(BE.glosa) ? (object)DBNull.Value : BE.glosa);
                        //cmd.Parameters.AddWithValue("@montopago1", SqlDbType.Decimal).Value = BE.montopago1;
                        //cmd.Parameters.AddWithValue("@impretencion1", SqlDbType.Decimal).Value = BE.impretencion1;
                        //cmd.Parameters.AddWithValue("@montopago2", SqlDbType.Decimal).Value = BE.montopago2;
                        //cmd.Parameters.AddWithValue("@impretencion2", SqlDbType.Decimal).Value = BE.montopago1;
                        //cmd.Parameters.AddWithValue("@porcretencion", SqlDbType.Decimal).Value = BE.porcretencion;
                        //cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        //cmd.Parameters.AddWithValue("@usuar", string.IsNullOrEmpty(BE.usuar) ? (object)DBNull.Value : BE.usuar);
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

        public DataSet GetAsientoNume(string empresaid, tb_co_retencionCAb BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRetencion_UltimoNumeroRegRetenciones", cnx))
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
                        //cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
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
        public DataSet GetMaxNumComprobRetencion(string empresaid, tb_co_retencionCAb BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRetencionCAb_MaxNumComprobRetencion", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@generar_ultimo", SqlDbType.Bit).Value = true;
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
        public DataSet GetAsientoRoleo(string empresaid, tb_co_retencionCAb BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRetencionCAb_SEARCH_roleo", cnx))
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
                        cmd.Parameters.Add("@tipo", SqlDbType.Char, 10).Value = BE.tipo;
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
        public DataSet GetGenerarRetencionesCompras(string empresaid, tb_co_retencionCAb BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRetencion_GenerarRetencionesCompras", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                        cmd.Parameters.AddWithValue("@fechaini", SqlDbType.DateTime).Value = BE.fechaini;
                        cmd.Parameters.AddWithValue("@fechafin", SqlDbType.DateTime).Value = BE.fechafin;
                        cmd.Parameters.AddWithValue("@porcretencion", SqlDbType.Decimal).Value = BE.porcretencion;
                        cmd.Parameters.AddWithValue("@tipdoc", string.IsNullOrEmpty(BE.tipdoc) ? (object)DBNull.Value : BE.tipdoc);
                        cmd.Parameters.AddWithValue("@serdoc", string.IsNullOrEmpty(BE.serdoc) ? (object)DBNull.Value : BE.serdoc);
                        cmd.Parameters.AddWithValue("@numdoc", string.IsNullOrEmpty(BE.numdoc) ? (object)DBNull.Value : BE.numdoc);
                        cmd.Parameters.AddWithValue("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
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
        public DataSet FormatoRegistroRegistroRetencion(string empresaid, tb_co_retencionCAb BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRetencion_FormatoRetencionImpr", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                        cmd.Parameters.AddWithValue("@moduloid", string.IsNullOrEmpty(BE.moduloid) ? (object)DBNull.Value : BE.moduloid);
                        cmd.Parameters.AddWithValue("@local", string.IsNullOrEmpty(BE.local) ? (object)DBNull.Value : BE.local);
                        cmd.Parameters.AddWithValue("@diarioid", string.IsNullOrEmpty(BE.diarioid) ? (object)DBNull.Value : BE.diarioid);
                        cmd.Parameters.AddWithValue("@asiento", string.IsNullOrEmpty(BE.asiento) ? (object)DBNull.Value : BE.asiento);
                        cmd.Parameters.AddWithValue("@fechaini", SqlDbType.DateTime).Value = BE.fechaini;
                        cmd.Parameters.AddWithValue("@fechafin", SqlDbType.DateTime).Value = BE.fechafin;
                        cmd.Parameters.AddWithValue("@tipdoc", string.IsNullOrEmpty(BE.tipdoc) ? (object)DBNull.Value : BE.tipdoc);
                        cmd.Parameters.AddWithValue("@serdoc", string.IsNullOrEmpty(BE.serdoc) ? (object)DBNull.Value : BE.serdoc);
                        cmd.Parameters.AddWithValue("@numdoc", string.IsNullOrEmpty(BE.numdoc) ? (object)DBNull.Value : BE.numdoc);
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

        public DataTable GetGeneraAsientoRetencionesIGV_Consulta(string empresaid, tb_co_retencionCAb BE)
        {
            DataTable DT = new DataTable();
            int lcont = 0;
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRetencion_GeneraAsientoRetencionIGV", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                    cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                    cmd.Parameters.AddWithValue("@asientoini", string.IsNullOrEmpty(BE.asientoini) ? (object)DBNull.Value : BE.asientoini);
                    cmd.Parameters.AddWithValue("@asientofin", string.IsNullOrEmpty(BE.asientofin) ? (object)DBNull.Value : BE.asientofin);
                    cmd.Parameters.AddWithValue("@fechaini", SqlDbType.DateTime).Value = BE.fechaini;
                    cmd.Parameters.AddWithValue("@fechafin", SqlDbType.DateTime).Value = BE.fechafin;
                    cmd.Parameters.AddWithValue("@usuar", string.IsNullOrEmpty(BE.usuar) ? (object)DBNull.Value : BE.usuar);
                    //cmd.Parameters.AddWithValue("@moduloid", string.IsNullOrEmpty(BE.moduloid) ? (object)DBNull.Value : BE.moduloid);
                    //cmd.Parameters.AddWithValue("@local", string.IsNullOrEmpty(BE.local) ? (object)DBNull.Value : BE.local);
                    //cmd.Parameters.AddWithValue("@diarioid", string.IsNullOrEmpty(BE.diarioid) ? (object)DBNull.Value : BE.diarioid);
                    //cmd.Parameters.AddWithValue("@asiento", string.IsNullOrEmpty(BE.asiento) ? (object)DBNull.Value : BE.asiento);
                    cmd.Parameters.AddWithValue("@TipOperacion", SqlDbType.Int).Value = BE.TipOperacion;
                    try
                    {
                        cnx.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(DT);
                            for (lcont = 0; lcont <= DT.Columns.Count - 1; lcont++)
                            {
                                DT.Columns[lcont].ReadOnly = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Sql_Error = ex.Message;
                    }
                    cnx.Close();
                }
            }
            return DT;
        }

        public bool GetGeneraAsientoRetencionesIGV_Update(string empresaid, tb_co_retencionCAb BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoRetencion_GeneraAsientoRetencionIGV", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                    cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                    cmd.Parameters.AddWithValue("@asientoini", string.IsNullOrEmpty(BE.asientoini) ? (object)DBNull.Value : BE.asientoini);
                    cmd.Parameters.AddWithValue("@asientofin", string.IsNullOrEmpty(BE.asientofin) ? (object)DBNull.Value : BE.asientofin);
                    cmd.Parameters.AddWithValue("@fechaini", SqlDbType.DateTime).Value = BE.fechaini;
                    cmd.Parameters.AddWithValue("@fechafin", SqlDbType.DateTime).Value = BE.fechafin;
                    cmd.Parameters.AddWithValue("@usuar", string.IsNullOrEmpty(BE.usuar) ? (object)DBNull.Value : BE.usuar);
                    //cmd.Parameters.AddWithValue("@moduloid", string.IsNullOrEmpty(BE.moduloid) ? (object)DBNull.Value : BE.moduloid);
                    //cmd.Parameters.AddWithValue("@local", string.IsNullOrEmpty(BE.local) ? (object)DBNull.Value : BE.local);
                    //cmd.Parameters.AddWithValue("@diarioid", string.IsNullOrEmpty(BE.diarioid) ? (object)DBNull.Value : BE.diarioid);
                    //cmd.Parameters.AddWithValue("@asiento", string.IsNullOrEmpty(BE.asiento) ? (object)DBNull.Value : BE.asiento);
                    cmd.Parameters.AddWithValue("@TipOperacion", SqlDbType.Int).Value = BE.TipOperacion;
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

        //public DataSet GetOne(string empresaid, tb_co_retencionCAb BE)
        //{
        //    using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("gspTbCoRetencioncab_SELECT", cnx))
        //        {
        //            DataSet ds = new DataSet();
        //            {
        //                cmd.CommandTimeout = 0;
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
        //                Sql_Error = ex.Message;
        //                throw new Exception(ex.Message);
        //            }
        //        }
        //    }
        //}
    }
}
