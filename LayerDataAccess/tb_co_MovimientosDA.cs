using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_co_MovimientosDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd1 = new SqlCommand("gspTbCoMovimientos_INSERT", cnx))
                {
                    cmd1.CommandTimeout = 0;
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd1.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd1.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd1.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd1.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                    cmd1.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
                    cmd1.Parameters.Add("@tipooperacion", SqlDbType.Char, 1).Value = BE.tipooperacion;
                    cmd1.Parameters.Add("@tipocomprobante", SqlDbType.Char, 1).Value = BE.tipocomprobante;
                    cmd1.Parameters.Add("@cuentaid", SqlDbType.Char, 10).Value = BE.cuentaid;
                    cmd1.Parameters.Add("@tipomovimiento", SqlDbType.Char, 2).Value = BE.tipomovimiento;
                    cmd1.Parameters.Add("@mediopago", SqlDbType.Char, 3).Value = BE.mediopago;
                    cmd1.Parameters.Add("@numdocpago", SqlDbType.Char, 10).Value = BE.numdocpago;
                    cmd1.Parameters.Add("@bancoid", SqlDbType.Char, 2).Value = BE.bancoid;
                    cmd1.Parameters.Add("@fechregistro", SqlDbType.DateTime).Value = BE.fechregistro;
                    cmd1.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                    cmd1.Parameters.Add("@tipcamuso", SqlDbType.Char, 1).Value = BE.tipcamuso;
                    cmd1.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                    cmd1.Parameters.Add("@glosa", SqlDbType.VarChar, 100).Value = BE.glosa;
                    cmd1.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                    cmd1.Parameters.Add("@flujoefectivo", SqlDbType.Char, 4).Value = BE.flujoefectivo;
                    cmd1.Parameters.Add("@debesoles", SqlDbType.Decimal).Value = BE.debesoles;
                    cmd1.Parameters.Add("@habersoles", SqlDbType.Decimal).Value = BE.habersoles;
                    cmd1.Parameters.Add("@debedolares", SqlDbType.Decimal).Value = BE.debedolares;
                    cmd1.Parameters.Add("@haberdolares", SqlDbType.Decimal).Value = BE.haberdolares;
                    cmd1.Parameters.Add("@difcambio", SqlDbType.Bit).Value = BE.difcambio;
                    cmd1.Parameters.Add("@redondeo", SqlDbType.Bit).Value = BE.redondeo;
                    cmd1.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd1.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;

                    cmd1.Parameters.Add("@XML", SqlDbType.Xml).Value = BE.GetItemXML();

                    try
                    {
                        cnx.Open();
                        if (cmd1.ExecuteNonQuery() > 0)
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
        public bool Update(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd1 = new SqlCommand("gspTbCoMovimientos_UPDATE", cnx))
                {
                    cmd1.CommandTimeout = 0;
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd1.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd1.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd1.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd1.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                    cmd1.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
                    cmd1.Parameters.Add("@tipooperacion", SqlDbType.Char, 1).Value = BE.tipooperacion;
                    cmd1.Parameters.Add("@tipocomprobante", SqlDbType.Char, 1).Value = BE.tipocomprobante;
                    cmd1.Parameters.Add("@cuentaid", SqlDbType.Char, 10).Value = BE.cuentaid;
                    cmd1.Parameters.Add("@tipomovimiento", SqlDbType.Char, 2).Value = BE.tipomovimiento;
                    cmd1.Parameters.Add("@mediopago", SqlDbType.Char, 3).Value = BE.mediopago;
                    cmd1.Parameters.Add("@numdocpago", SqlDbType.Char, 10).Value = BE.numdocpago;
                    cmd1.Parameters.Add("@bancoid", SqlDbType.Char, 2).Value = BE.bancoid;
                    cmd1.Parameters.Add("@fechregistro", SqlDbType.DateTime).Value = BE.fechregistro;
                    cmd1.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                    cmd1.Parameters.Add("@tipcamuso", SqlDbType.Char, 1).Value = BE.tipcamuso;
                    cmd1.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                    cmd1.Parameters.Add("@glosa", SqlDbType.VarChar, 100).Value = BE.glosa;
                    cmd1.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                    cmd1.Parameters.Add("@flujoefectivo", SqlDbType.Char, 4).Value = BE.flujoefectivo;
                    cmd1.Parameters.Add("@debesoles", SqlDbType.Decimal).Value = BE.debesoles;
                    cmd1.Parameters.Add("@habersoles", SqlDbType.Decimal).Value = BE.habersoles;
                    cmd1.Parameters.Add("@debedolares", SqlDbType.Decimal).Value = BE.debedolares;
                    cmd1.Parameters.Add("@haberdolares", SqlDbType.Decimal).Value = BE.haberdolares;
                    cmd1.Parameters.Add("@difcambio", SqlDbType.Bit).Value = BE.difcambio;
                    cmd1.Parameters.Add("@redondeo", SqlDbType.Bit).Value = BE.redondeo;
                    cmd1.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd1.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    cmd1.Parameters.Add("@XML", SqlDbType.Xml).Value = BE.GetItemXML();
                    try
                    {
                        cnx.Open();
                        if (cmd1.ExecuteNonQuery() > 0)
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

        public bool Insert_Update(string empresaid, DataTable Cabecera, DataTable Detalle)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                bool xreturn = true;
                int lc_contcab = 0;
                int lccontdetalle = 0;
                for (lc_contcab = 0; lc_contcab <= Cabecera.Rows.Count - 1; lc_contcab++)
                {
                    if ((Cabecera != null))
                    {
                        using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientosdet_DELETE", cnx))
                        {
                            cmd.CommandTimeout = 0;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = Cabecera.Rows[lc_contcab]["perianio"];
                            cmd.Parameters.Add("@perimes", SqlDbType.Char).Value = Cabecera.Rows[lc_contcab]["perimes"];
                            cmd.Parameters.Add("@moduloid", SqlDbType.Char).Value = Cabecera.Rows[lc_contcab]["moduloid"];
                            cmd.Parameters.Add("@local", SqlDbType.Char).Value = Cabecera.Rows[lc_contcab]["local"];
                            cmd.Parameters.Add("@diarioid", SqlDbType.Char).Value = Cabecera.Rows[lc_contcab]["diarioid"];
                            cmd.Parameters.Add("@asiento", SqlDbType.Char).Value = Cabecera.Rows[lc_contcab]["asiento"];
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

                    if ((Cabecera != null))
                    {
                        using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientoscab_InsertUpdate", cnx))
                        {
                            cmd.CommandTimeout = 0;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = Cabecera.Rows[lc_contcab]["perianio"];
                            cmd.Parameters.Add("@perimes", SqlDbType.Char).Value = Cabecera.Rows[lc_contcab]["perimes"];
                            cmd.Parameters.Add("@moduloid", SqlDbType.Char).Value = Cabecera.Rows[lc_contcab]["moduloid"];
                            cmd.Parameters.Add("@local", SqlDbType.Char).Value = Cabecera.Rows[lc_contcab]["local"];
                            cmd.Parameters.Add("@diarioid", SqlDbType.Char).Value = Cabecera.Rows[lc_contcab]["diarioid"];
                            cmd.Parameters.Add("@asiento", SqlDbType.Char).Value = Cabecera.Rows[lc_contcab]["asiento"];
                            cmd.Parameters.Add("@tipooperacion", SqlDbType.Char).Value = Cabecera.Rows[lc_contcab]["tipooperacion"];
                            cmd.Parameters.Add("@tipocomprobante", SqlDbType.Char).Value = Cabecera.Rows[lc_contcab]["tipocomprobante"];
                            cmd.Parameters.Add("@cuentaid", SqlDbType.Char).Value = Cabecera.Rows[lc_contcab]["cuentaid"].ToString().Trim();
                            cmd.Parameters.Add("@tipomovimiento", SqlDbType.Char).Value = Cabecera.Rows[lc_contcab]["tipomovimiento"];
                            cmd.Parameters.Add("@mediopago", SqlDbType.Char).Value = Cabecera.Rows[lc_contcab]["mediopago"];
                            cmd.Parameters.Add("@numdocpago", SqlDbType.Char).Value = Cabecera.Rows[lc_contcab]["numdocpago"];
                            cmd.Parameters.Add("@bancoid", SqlDbType.Char).Value = Cabecera.Rows[lc_contcab]["bancoid"];
                            cmd.Parameters.Add("@fechregistro", SqlDbType.DateTime).Value = Cabecera.Rows[lc_contcab]["fechregistro"];
                            cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = Cabecera.Rows[lc_contcab]["fechdoc"];
                            cmd.Parameters.Add("@tipcamuso", SqlDbType.Char).Value = Cabecera.Rows[lc_contcab]["tipcamuso"];
                            cmd.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = Cabecera.Rows[lc_contcab]["tipcamb"];
                            cmd.Parameters.Add("@glosa", SqlDbType.VarChar).Value = Cabecera.Rows[lc_contcab]["glosa"];
                            cmd.Parameters.Add("@moneda", SqlDbType.Char).Value = Cabecera.Rows[lc_contcab]["moneda"];
                            cmd.Parameters.Add("@flujoefectivo", SqlDbType.Char).Value = Cabecera.Rows[lc_contcab]["flujoefectivo"];
                            cmd.Parameters.Add("@debesoles", SqlDbType.Decimal).Value = Cabecera.Rows[lc_contcab]["debesoles"];
                            cmd.Parameters.Add("@habersoles", SqlDbType.Decimal).Value = Cabecera.Rows[lc_contcab]["habersoles"];
                            cmd.Parameters.Add("@debedolares", SqlDbType.Decimal).Value = Cabecera.Rows[lc_contcab]["debedolares"];
                            cmd.Parameters.Add("@haberdolares", SqlDbType.Decimal).Value = Cabecera.Rows[lc_contcab]["haberdolares"];
                            cmd.Parameters.Add("@difcambio", SqlDbType.Bit).Value = Cabecera.Rows[lc_contcab]["difcambio"];
                            cmd.Parameters.Add("@redondeo", SqlDbType.Bit).Value = Cabecera.Rows[lc_contcab]["redondeo"];
                            cmd.Parameters.Add("@status", SqlDbType.Char).Value = Cabecera.Rows[lc_contcab]["status"];
                            cmd.Parameters.Add("@usuar", SqlDbType.Char).Value = Cabecera.Rows[lc_contcab]["usuar"];
                            cmd.Parameters.Add("@fecre", SqlDbType.DateTime).Value = Cabecera.Rows[lc_contcab]["fecre"];
                            cmd.Parameters.Add("@feact", SqlDbType.DateTime).Value = Cabecera.Rows[lc_contcab]["feact"];
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

                    try
                    {
                        if ((Detalle != null))
                        {
                            for (lccontdetalle = 0; lccontdetalle <= Detalle.Rows.Count - 1; lccontdetalle++)
                            {
                                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientosdet_InsertUpdate", cnx))
                                {
                                    cmd.CommandTimeout = 0;
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["perianio"].ToString().Trim();
                                    cmd.Parameters.Add("@perimes", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["perimes"].ToString().Trim();
                                    cmd.Parameters.Add("@moduloid", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["moduloid"].ToString().Trim();
                                    cmd.Parameters.Add("@local", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["local"].ToString().Trim();
                                    cmd.Parameters.Add("@diarioid", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["diarioid"].ToString().Trim();
                                    cmd.Parameters.Add("@asiento", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["asiento"].ToString().Trim();
                                    cmd.Parameters.Add("@asientoitems", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["asientoitems"].ToString().Trim();                                   
                                    cmd.Parameters.Add("@cuentaid", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["cuentaid"].ToString().Trim();
                                    cmd.Parameters.Add("@cuentaorigen", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["cuentaorigen"].ToString().Trim();
                                    cmd.Parameters.Add("@cuentaname", SqlDbType.VarChar).Value = Detalle.Rows[lccontdetalle]["cuentaname"].ToString().Trim();
                                    cmd.Parameters.Add("@glosa", SqlDbType.VarChar).Value = Detalle.Rows[lccontdetalle]["glosa"].ToString().Trim();
                                    cmd.Parameters.Add("@cencosid", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["cencosid"].ToString().Trim();
                                    cmd.Parameters.Add("@debehaber", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["debehaber"].ToString().Trim();
                                    cmd.Parameters.Add("@ctacte", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["ctacte"].ToString().Trim();
                                    cmd.Parameters.Add("@nmruc", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["nmruc"].ToString().Trim();
                                    cmd.Parameters.Add("@ctactename", SqlDbType.VarChar).Value = Detalle.Rows[lccontdetalle]["ctactename"].ToString().Trim();
                                    cmd.Parameters.Add("@tipdoc", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["tipdoc"].ToString().Trim();
                                    cmd.Parameters.Add("@serdoc", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["serdoc"].ToString().Trim();
                                    cmd.Parameters.Add("@numdoc", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["numdoc"].ToString().Trim();
                                    cmd.Parameters.Add("@fechregistro", SqlDbType.DateTime).Value = Detalle.Rows[lccontdetalle]["fechregistro"];
                                    cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = Detalle.Rows[lccontdetalle]["fechdoc"];
                                    cmd.Parameters.Add("@fechvenc", SqlDbType.DateTime).Value = Detalle.Rows[lccontdetalle]["fechvenc"];
                                    cmd.Parameters.Add("@tipref", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["tipref"];
                                    cmd.Parameters.Add("@serref", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["serref"];
                                    cmd.Parameters.Add("@numref", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["numref"];
                                    cmd.Parameters.Add("@fechref", SqlDbType.DateTime).Value = Detalle.Rows[lccontdetalle]["fechref"];
                                    cmd.Parameters.Add("@importe", SqlDbType.Decimal).Value = Detalle.Rows[lccontdetalle]["importe"];
                                    cmd.Parameters.Add("@importecambio", SqlDbType.Decimal).Value = Detalle.Rows[lccontdetalle]["importecambio"];
                                    cmd.Parameters.Add("@soles", SqlDbType.Decimal).Value = Detalle.Rows[lccontdetalle]["soles"];
                                    cmd.Parameters.Add("@dolares", SqlDbType.Decimal).Value = Detalle.Rows[lccontdetalle]["dolares"];
                                    cmd.Parameters.Add("@moneda", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["moneda"].ToString().Trim();
                                    cmd.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = Detalle.Rows[lccontdetalle]["tipcamb"];
                                    cmd.Parameters.Add("@tipcambuso", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["tipcambuso"];
                                    cmd.Parameters.Add("@tipcambfech", SqlDbType.DateTime).Value = Detalle.Rows[lccontdetalle]["tipcambfech"];
                                    cmd.Parameters.Add("@afectoretencion", SqlDbType.Bit).Value = Detalle.Rows[lccontdetalle]["afectoretencion"];
                                    cmd.Parameters.Add("@afectopercepcion", SqlDbType.Bit).Value = Detalle.Rows[lccontdetalle]["afectopercepcion"];
                                    cmd.Parameters.Add("@percepcionid", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["percepcionid"];
                                    cmd.Parameters.Add("@serperc", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["serperc"];
                                    cmd.Parameters.Add("@numperc", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["numperc"];
                                    cmd.Parameters.Add("@numdocpago", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["numdocpago"];
                                    cmd.Parameters.Add("@bancoid", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["bancoid"].ToString().Trim();
                                    cmd.Parameters.Add("@pagocta", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["pagocta"].ToString().Trim();
                                    cmd.Parameters.Add("@mediopago", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["mediopago"].ToString().Trim();
                                    cmd.Parameters.Add("@fechpago", SqlDbType.DateTime).Value = Detalle.Rows[lccontdetalle]["fechpago"];
                                    cmd.Parameters.Add("@flujoefectivo", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["flujoefectivo"].ToString().Trim();
                                    cmd.Parameters.Add("@asientovinculante", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["asientovinculante"].ToString().Trim();
                                    cmd.Parameters.Add("@cancelacionvinculante", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["cancelacionvinculante"].ToString().Trim();
                                    cmd.Parameters.Add("@productid", SqlDbType.VarChar).Value = Detalle.Rows[lccontdetalle]["productid"].ToString().Trim();
                                    cmd.Parameters.Add("@pedidoid", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["pedidoid"].ToString().Trim();
                                    cmd.Parameters.Add("@tipOp", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["tip_op"].ToString().Trim();
                                    cmd.Parameters.Add("@serOp", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["ser_op"].ToString().Trim();
                                    cmd.Parameters.Add("@numOp", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["num_op"].ToString().Trim();
                                    cmd.Parameters.Add("@tipooperacion", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["tipooperacion"].ToString().Trim();
                                    cmd.Parameters.Add("@tipocomprobante", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["tipocomprobante"].ToString().Trim();
                                    cmd.Parameters.Add("@tipomovimiento", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["tipomovimiento"].ToString().Trim();
                                    cmd.Parameters.Add("@statusdestino", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["statusdestino"];
                                    cmd.Parameters.Add("@status", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["status"];
                                    cmd.Parameters.Add("@usuar", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["usuar"];
                                    cmd.Parameters.Add("@fecre", SqlDbType.DateTime).Value = Detalle.Rows[lccontdetalle]["fecre"];
                                    cmd.Parameters.Add("@feact", SqlDbType.DateTime).Value = Detalle.Rows[lccontdetalle]["feact"];
                                    cmd.Parameters.Add("@detraccionid", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["detraccionid"];
                                    cmd.Parameters.Add("@porcdetraccion", SqlDbType.Decimal).Value = Detalle.Rows[lccontdetalle]["porcdetraccion"];
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
                        //retorno = 1;
                    }
                    catch (Exception ex)
                    {
                        Sql_Error = ex.Message;
                        //retorno = 0;
                        //break;
                    }
                }
                return xreturn;
            }
        }
        public bool GetAllAsientoAutomaticoDestino(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_AsientoAutomaticoDestino", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                    cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                    cmd.Parameters.AddWithValue("@moduloid", string.IsNullOrEmpty(BE.moduloid) ? (object)DBNull.Value : BE.moduloid);
                    cmd.Parameters.AddWithValue("@local", string.IsNullOrEmpty(BE.local) ? (object)DBNull.Value : BE.local);
                    cmd.Parameters.AddWithValue("@diarioid", string.IsNullOrEmpty(BE.diarioid) ? (object)DBNull.Value : BE.diarioid);
                    cmd.Parameters.AddWithValue("@asiento", string.IsNullOrEmpty(BE.asiento) ? (object)DBNull.Value : BE.asiento);
                    cmd.Parameters.Add("@TipoOperacion", SqlDbType.Int).Value = BE.tipmodal;
                    if (BE.fechaini == "")
                    { cmd.Parameters.Add("@FechaIni", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                    else
                    { cmd.Parameters.Add("@FechaIni", System.Data.SqlDbType.DateTime).Value = BE.fechaini; }
                    if (BE.fechafin == "")
                    { cmd.Parameters.Add("@FechaFin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                    else
                    { cmd.Parameters.Add("@FechaFin", System.Data.SqlDbType.DateTime).Value = BE.fechafin; }
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

        public bool Delete(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_DELETE", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;

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
                }
                catch (Exception ex)
                {
                    Sql_Error = ex.Message;
                    throw new Exception(ex.Message);
                }
            }
        }
        
        public DataSet GetGeneraVoucherContable(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_ReporteVoucherContable", cnx))
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
                        cmd.Parameters.Add("@asientoini", SqlDbType.Char, 6).Value = BE.cmesini;
                        cmd.Parameters.Add("@asientofin", SqlDbType.Char, 6).Value = BE.cmesfin;
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

        public DataSet GetGeneraIgv(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_GeneraSaldocuentasigv", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@cmesini", SqlDbType.Char, 2).Value = BE.cmesini;
                        cmd.Parameters.Add("@cmesfin", SqlDbType.Char, 2).Value = BE.cmesfin;
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
        public DataSet GetGeneraSaldoCuenta(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_GeneraSaldocuentas", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@cmesini", SqlDbType.Char, 2).Value = BE.cmesini;
                        cmd.Parameters.Add("@cmesfin", SqlDbType.Char, 2).Value = BE.cmesfin;
                        cmd.Parameters.Add("@cuentamay", SqlDbType.Char, 2).Value = BE.cuentaid;
                        cmd.Parameters.Add("@cuentaini", SqlDbType.Char, 10).Value = BE.cuentaini;
                        cmd.Parameters.Add("@cuentafin", SqlDbType.Char, 10).Value = BE.cuentafin;
                        cmd.Parameters.Add("@relctas", SqlDbType.Char, 2).Value = BE.relctas;
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

        public DataSet GetGeneraReporteChequesGirados(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_ReporteChequesGirados", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TipoFecha", SqlDbType.Int).Value = BE.tiprepo;
                        if (BE.fechaini == "")
                        { cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = BE.fechaini; }
                        //cmd.Parameters.AddWithValue("@fechaini", string.IsNullOrEmpty(BE.fechaini) ? (object)DBNull.Value : BE.fechaini);
                        if (BE.fechafin == "")
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = BE.fechafin; }                       
                        //cmd.Parameters.AddWithValue("@fechafin", string.IsNullOrEmpty(BE.fechafin) ? (object)DBNull.Value : BE.fechafin);
                        cmd.Parameters.AddWithValue("@cuentaini", string.IsNullOrEmpty(BE.cuentaini) ? (object)DBNull.Value : BE.cuentaini);
                        cmd.Parameters.AddWithValue("@cuentafin", string.IsNullOrEmpty(BE.cuentafin) ? (object)DBNull.Value : BE.cuentafin);
                        cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                        cmd.Parameters.AddWithValue("@ver_cheq_anul", SqlDbType.Int).Value = BE.origen;
                        cmd.Parameters.AddWithValue("@orden", SqlDbType.Int).Value = BE.modalidad;   
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

        public DataSet GetGeneraHojaTrabajo(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_BalanceComprobacion", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@cuenta_ini", SqlDbType.Char, 2).Value =BE.cuentaini;
                        cmd.Parameters.Add("@cuenta_fin", SqlDbType.Char, 2).Value = BE.cuentafin;
                        cmd.Parameters.Add("@cantdigitos", SqlDbType.Char, 2).Value = BE.cantdigitos;
                        cmd.Parameters.Add("@solohastacantdigitos", SqlDbType.Int).Value = BE.solohastacantdigitos;
                        cmd.Parameters.Add("@saldos", SqlDbType.Int).Value = BE.saldos;
                        if (BE.fimpresion == "")
                        { cmd.Parameters.Add("@fechaimpresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechaimpresion", System.Data.SqlDbType.DateTime).Value = BE.fimpresion; }
                        //cmd.Parameters.AddWithValue("@fechaimpresion", string.IsNullOrEmpty(BE.fimpresion) ? (object)DBNull.Value : BE.fimpresion);
                        cmd.Parameters.Add("@mostrar69", SqlDbType.Int).Value = BE.mostrar69;
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
        public DataSet GetGeneraBalanceComprobacionDJ(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_BalanceComprobacionDJ", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@cuenta_ini", SqlDbType.Char, 2).Value = BE.cuentaini;
                        cmd.Parameters.Add("@cuenta_fin", SqlDbType.Char, 2).Value = BE.cuentafin;
                        cmd.Parameters.Add("@cantdigitos", SqlDbType.Char, 2).Value = BE.cantdigitos;
                        cmd.Parameters.Add("@solohastacantdigitos", SqlDbType.Int).Value = BE.solohastacantdigitos;
                        cmd.Parameters.Add("@saldos", SqlDbType.Int).Value = BE.saldos;
                        if (BE.fimpresion == "")
                        { cmd.Parameters.Add("@fechaimpresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechaimpresion", System.Data.SqlDbType.DateTime).Value = BE.fimpresion; }
                        //cmd.Parameters.AddWithValue("@fechaimpresion", string.IsNullOrEmpty(BE.fimpresion) ? (object)DBNull.Value : BE.fimpresion);
                        cmd.Parameters.Add("@mostrar69", SqlDbType.Int).Value = BE.mostrar69;
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
        
        public DataSet GetGeneraBalanceGeneral(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_BalanceGeneral", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@CPERIODO", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@CMES", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@nMoneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@CUENTA_MAYORINI", SqlDbType.Char, 2).Value = BE.cuentaini;
                        cmd.Parameters.Add("@CUENTA_MAYORFIN", SqlDbType.Char, 2).Value = BE.cuentafin;
                        cmd.Parameters.Add("@CantDigitos", SqlDbType.Char, 2).Value = BE.cantdigitos;
                        cmd.Parameters.Add("@solohastacantdigitos", SqlDbType.Int).Value = BE.solohastacantdigitos;
                        cmd.Parameters.Add("@Saldos", SqlDbType.Int).Value = BE.saldos;
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
        public DataSet GetGeneraAnexosBalanceGeneral(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_AnexosBalanceGeneral", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                        cmd.Parameters.AddWithValue("@ctamayini", string.IsNullOrEmpty(BE.ctamayini) ? (object)DBNull.Value : BE.ctamayini);
                        cmd.Parameters.AddWithValue("@ctamayfin", string.IsNullOrEmpty(BE.ctamayfin) ? (object)DBNull.Value : BE.ctamayfin);
                        cmd.Parameters.AddWithValue("@cuentaini", string.IsNullOrEmpty(BE.cuentaini) ? (object)DBNull.Value : BE.cuentaini);
                        cmd.Parameters.AddWithValue("@cuentafin", string.IsNullOrEmpty(BE.cuentafin) ? (object)DBNull.Value : BE.cuentafin);
                        cmd.Parameters.AddWithValue("@moneda", string.IsNullOrEmpty(BE.moneda) ? (object)DBNull.Value : BE.moneda);
                        cmd.Parameters.AddWithValue("@Saldos", SqlDbType.Int).Value = BE.origen;
                        if (BE.fimpresion == "")
                        { cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = BE.fimpresion; }
                        //cmd.Parameters.AddWithValue("@fimpresion", string.IsNullOrEmpty(BE.fimpresion) ? (object)DBNull.Value : BE.fimpresion);
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

        public DataSet GetGeneraBalanceGeneralBapSoft(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_BalanceGeneralBapSoft", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@ctamayini", SqlDbType.Char, 2).Value = BE.ctamayini;
                        cmd.Parameters.Add("@ctamayfin", SqlDbType.Char, 2).Value = BE.ctamayfin;
                        cmd.Parameters.Add("@nivel", SqlDbType.Int).Value = BE.solohastacantdigitos;
                        cmd.Parameters.Add("@saldos", SqlDbType.Int).Value = BE.saldos;
                        cmd.Parameters.Add("@opc", SqlDbType.Char).Value = BE.tipo;
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
        public DataSet GetGeneraAnexosBalanceGeneralBapSoft(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_AnexosBalanceGeneralBapSoft", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@ctamayini", SqlDbType.Char, 2).Value = BE.ctamayini;
                        cmd.Parameters.Add("@ctamayfin", SqlDbType.Char, 2).Value = BE.ctamayfin;
                        cmd.Parameters.Add("@saldos", SqlDbType.Int).Value = BE.saldos;
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
        
        public DataSet GetGeneraEstadoGananciasPerdidas(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_GenerarReportesEEFF", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@CPERIODO", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@MES", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@COD_REPORTE", SqlDbType.Char, 2).Value = BE.tipreporte;
                        cmd.Parameters.Add("@nMoneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@FECHA_INICIAL", SqlDbType.Char, 8).Value = BE.fechaini;
                        cmd.Parameters.Add("@FECHA_FINAL", SqlDbType.Char, 8).Value = BE.fechafin;
                        cmd.Parameters.Add("@NIVEL", SqlDbType.Char, 2).Value = BE.nivel;
                        cmd.Parameters.Add("@cuenta", SqlDbType.Char, 2).Value = BE.cuentaid;
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
        
        public DataSet GetGeneraEEFFmensual(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_GenerarEEFF_Mensual", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@saldos", SqlDbType.Int).Value = BE.saldos;
                        cmd.Parameters.Add("@CodReporte", SqlDbType.Char, 2).Value = BE.tipreporte;
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

        public DataSet GetGeneraBalancexCcosto(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_BalancexCentroCosto", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.AddWithValue("@cuentaid", string.IsNullOrEmpty(BE.cuentaid) ? (object)DBNull.Value : BE.cuentaid);
                        cmd.Parameters.AddWithValue("@cuentaini", string.IsNullOrEmpty(BE.cuentaini) ? (object)DBNull.Value : BE.cuentaini);
                        cmd.Parameters.AddWithValue("@cuentafin", string.IsNullOrEmpty(BE.cuentafin) ? (object)DBNull.Value : BE.cuentafin);
                        cmd.Parameters.AddWithValue("@ccostoini", string.IsNullOrEmpty(BE.cencosini) ? (object)DBNull.Value : BE.cencosini);
                        cmd.Parameters.AddWithValue("@ccostofin", string.IsNullOrEmpty(BE.cencosfin) ? (object)DBNull.Value : BE.cencosfin);
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        if (BE.fimpresion == "")
                        { cmd.Parameters.Add("@f_impresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@f_impresion", System.Data.SqlDbType.DateTime).Value = BE.fimpresion; }
                        cmd.Parameters.Add("@NAcumularMovMes", SqlDbType.Int).Value = BE.saldos;
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
        public DataSet GetGeneraBalancexCcostoMensual(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_BalancexCentroCosto_Mensual", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.AddWithValue("@cuentaid", string.IsNullOrEmpty(BE.cuentaid) ? (object)DBNull.Value : BE.cuentaid);
                        cmd.Parameters.AddWithValue("@cuentaini", string.IsNullOrEmpty(BE.cuentaini) ? (object)DBNull.Value : BE.cuentaini);
                        cmd.Parameters.AddWithValue("@cuentafin", string.IsNullOrEmpty(BE.cuentafin) ? (object)DBNull.Value : BE.cuentafin);
                        cmd.Parameters.AddWithValue("@ccostoini", string.IsNullOrEmpty(BE.cencosini) ? (object)DBNull.Value : BE.cencosini);
                        cmd.Parameters.AddWithValue("@ccostofin", string.IsNullOrEmpty(BE.cencosfin) ? (object)DBNull.Value : BE.cencosfin);
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        if (BE.fimpresion == "")
                        { cmd.Parameters.Add("@f_impresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@f_impresion", System.Data.SqlDbType.DateTime).Value = BE.fimpresion; }
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
        public DataSet GetGeneraBalancexCcostoGeneral(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_BalancexCentroCosto_General", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@perimesfin", SqlDbType.Char, 2).Value = BE.cmesfin;
                        cmd.Parameters.AddWithValue("@cuentaid", string.IsNullOrEmpty(BE.cuentaid) ? (object)DBNull.Value : BE.cuentaid);
                        cmd.Parameters.AddWithValue("@ccostoini", string.IsNullOrEmpty(BE.cuentaini) ? (object)DBNull.Value : BE.cuentaini);
                        cmd.Parameters.AddWithValue("@ccostofin", string.IsNullOrEmpty(BE.cuentafin) ? (object)DBNull.Value : BE.cuentafin);
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        if (BE.fimpresion == "")
                        { cmd.Parameters.Add("@f_impresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@f_impresion", System.Data.SqlDbType.DateTime).Value = BE.fimpresion; }
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
        public DataSet GetGeneraBalancexCcostoPlantilla(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_GenerarReporteCCCC", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimesini", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@perimesfin", SqlDbType.Char, 2).Value = BE.cmesfin;
                        cmd.Parameters.AddWithValue("@eeffid", string.IsNullOrEmpty(BE.tipo) ? (object)DBNull.Value : BE.tipo);
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.AddWithValue("@cencosini", string.IsNullOrEmpty(BE.cuentaini) ? (object)DBNull.Value : BE.cuentaini);
                        cmd.Parameters.AddWithValue("@cencosfin", string.IsNullOrEmpty(BE.cuentafin) ? (object)DBNull.Value : BE.cuentafin);
                        cmd.Parameters.AddWithValue("@nivel", string.IsNullOrEmpty(BE.nivel) ? (object)DBNull.Value : BE.nivel);
                        cmd.Parameters.AddWithValue("@cuentaid", string.IsNullOrEmpty(BE.cuentaid) ? (object)DBNull.Value : BE.cuentaid);
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

        public DataSet GetGeneraAnalisisCcosto(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_AnalisisCentroCosto", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        if (BE.fechaini == "")
                        { cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = BE.fechaini; }
                        if (BE.fechafin == "")
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = BE.fechafin; }
                        cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                        cmd.Parameters.AddWithValue("@cuentaini", string.IsNullOrEmpty(BE.cuentaini) ? (object)DBNull.Value : BE.cuentaini);
                        cmd.Parameters.AddWithValue("@cuentafin", string.IsNullOrEmpty(BE.cuentafin) ? (object)DBNull.Value : BE.cuentafin);
                        cmd.Parameters.AddWithValue("@ccostoini", string.IsNullOrEmpty(BE.cencosid) ? (object)DBNull.Value : BE.cencosid);
                        cmd.Parameters.AddWithValue("@ccostofin", string.IsNullOrEmpty(BE.ctamayfin) ? (object)DBNull.Value : BE.ctamayfin);
                        cmd.Parameters.Add("@orden", SqlDbType.Int).Value = BE.tipmodal;
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
      
        public DataSet GetGeneraLibroCajaBancos(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_ReporteLibroCajaBancos", cnx))
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
                        //cmd.Parameters.AddWithValue("@fechaini", string.IsNullOrEmpty(BE.fechaini) ? (object)DBNull.Value : BE.fechaini);
                        if (BE.fechafin == "")
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = BE.fechafin; }
                        //cmd.Parameters.AddWithValue("@fechafin", string.IsNullOrEmpty(BE.fechafin) ? (object)DBNull.Value : BE.fechafin);
                        cmd.Parameters.AddWithValue("@cuentaid", string.IsNullOrEmpty(BE.cuentaid) ? (object)DBNull.Value : BE.cuentaid);
                        cmd.Parameters.AddWithValue("@moneda", string.IsNullOrEmpty(BE.moneda) ? (object)DBNull.Value : BE.moneda);
                        cmd.Parameters.AddWithValue("@norden", SqlDbType.Int).Value = BE.origen;
                        if (BE.fimpresion == "")
                        { cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = BE.fimpresion; }
                        //cmd.Parameters.AddWithValue("@fimpresion", string.IsNullOrEmpty(BE.fimpresion) ? (object)DBNull.Value : BE.fimpresion);
                        cmd.Parameters.AddWithValue("@exp_excel", SqlDbType.Int).Value = BE.exp_excel;
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
        public DataSet GetGeneraDataConciliacionBanacaria(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_ConciliacionBancaria", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                        cmd.Parameters.AddWithValue("@cuentaid", string.IsNullOrEmpty(BE.cuentaid) ? (object)DBNull.Value : BE.cuentaid);
                        cmd.Parameters.AddWithValue("@moneda", string.IsNullOrEmpty(BE.moneda) ? (object)DBNull.Value : BE.moneda);
                        //cmd.Parameters.AddWithValue("@es_conciliado", SqlDbType.Bit).Value = BE.origen;
                        //cmd.Parameters.AddWithValue("@es_manual", SqlDbType.Bit).Value = BE.origen;
                        //cmd.Parameters.AddWithValue("@es_otroperiodo", SqlDbType.Bit).Value = BE.origen;
                        //cmd.Parameters.AddWithValue("@fechaini", string.IsNullOrEmpty(BE.fechaini) ? (object)DBNull.Value : BE.fechaini);
                        //cmd.Parameters.AddWithValue("@fechafin", string.IsNullOrEmpty(BE.fechafin) ? (object)DBNull.Value : BE.fechafin);                     
                        //cmd.Parameters.AddWithValue("@norden", SqlDbType.Int).Value = BE.origen;
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
        public DataSet GetGeneraDataConsultaConciliacionBanacaria(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_ConsultaConciliacionBancaria", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                        cmd.Parameters.AddWithValue("@cuentaid", string.IsNullOrEmpty(BE.cuentaid) ? (object)DBNull.Value : BE.cuentaid);
                        cmd.Parameters.AddWithValue("@moneda", string.IsNullOrEmpty(BE.moneda) ? (object)DBNull.Value : BE.moneda);
                        //cmd.Parameters.AddWithValue("@es_conciliado", SqlDbType.Bit).Value = BE.origen;
                        //cmd.Parameters.AddWithValue("@es_manual", SqlDbType.Bit).Value = BE.origen;
                        //cmd.Parameters.AddWithValue("@es_otroperiodo", SqlDbType.Bit).Value = BE.origen;
                        //cmd.Parameters.AddWithValue("@fechaini", string.IsNullOrEmpty(BE.fechaini) ? (object)DBNull.Value : BE.fechaini);
                        //cmd.Parameters.AddWithValue("@fechafin", string.IsNullOrEmpty(BE.fechafin) ? (object)DBNull.Value : BE.fechafin);                     
                        //cmd.Parameters.AddWithValue("@norden", SqlDbType.Int).Value = BE.origen;
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

        public DataSet GetGeneraLibroDiarioGeneral(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_ReporteLibroDiario", cnx))
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
                        //cmd.Parameters.AddWithValue("@fechaini", string.IsNullOrEmpty(BE.fechaini) ? (object)DBNull.Value : BE.fechaini);
                        if (BE.fechafin == "")
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = BE.fechafin; }
                        //cmd.Parameters.AddWithValue("@fechafin", string.IsNullOrEmpty(BE.fechafin) ? (object)DBNull.Value : BE.fechafin);
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@cuentamay", SqlDbType.Char, 2).Value = BE.cuentaid;
                        cmd.Parameters.Add("@cuentaini", SqlDbType.Char, 10).Value = BE.cuentaini;
                        cmd.Parameters.Add("@cuentafin", SqlDbType.Char, 10).Value = BE.cuentafin;
                        if (BE.fimpresion == "")
                        { cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = BE.fimpresion; }
                        //cmd.Parameters.AddWithValue("@fimpresion", string.IsNullOrEmpty(BE.fimpresion) ? (object)DBNull.Value : BE.fimpresion);
                        cmd.Parameters.Add("@exportadata", SqlDbType.Int).Value = BE.saldos; 
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
        public DataSet GetGeneraLibroDiarioF51(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_ReporteLibroDiario_F51", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                        cmd.Parameters.AddWithValue("@diarioid", string.IsNullOrEmpty(BE.diarioid) ? (object)DBNull.Value : BE.diarioid);
                        cmd.Parameters.AddWithValue("@cuentamay", string.IsNullOrEmpty(BE.cuentaid) ? (object)DBNull.Value : BE.cuentaid);
                        cmd.Parameters.AddWithValue("@moneda", string.IsNullOrEmpty(BE.moneda) ? (object)DBNull.Value : BE.moneda);
                        if (BE.fimpresion == "")
                        { cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = BE.fimpresion; }
                        //cmd.Parameters.AddWithValue("@fimpresion", string.IsNullOrEmpty(BE.fimpresion) ? (object)DBNull.Value : BE.fimpresion);
                        cmd.Parameters.Add("@exportadata", SqlDbType.Int).Value = BE.saldos;
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
        public DataSet GetGeneraLibroDiarioSimplificadoF52(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_ReporteLibroDiarioSimplificadoF52", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                        cmd.Parameters.AddWithValue("@diarioid", string.IsNullOrEmpty(BE.diarioid) ? (object)DBNull.Value : BE.diarioid);
                        cmd.Parameters.AddWithValue("@cuentamay", string.IsNullOrEmpty(BE.cuentaid) ? (object)DBNull.Value : BE.cuentaid);
                        cmd.Parameters.AddWithValue("@moneda", string.IsNullOrEmpty(BE.moneda) ? (object)DBNull.Value : BE.moneda);
                        //if (BE.fimpresion == "")
                        //{ cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        //else
                        //{ cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = BE.fimpresion; }

                        //cmd.Parameters.AddWithValue("@fimpresion", string.IsNullOrEmpty(BE.fimpresion) ? (object)DBNull.Value : BE.fimpresion);
                        cmd.Parameters.Add("@exportadata", SqlDbType.Int).Value = BE.saldos;
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

        public DataSet GetGeneraLibroMayorGeneral(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_ReporteLibroMayor", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@ctamayini", SqlDbType.Char, 2).Value = BE.cuentaini;
                        cmd.Parameters.Add("@ctamayfin", SqlDbType.Char, 2).Value = BE.cuentafin;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        if (BE.fimpresion == "")
                        { cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = BE.fimpresion; }
                        //cmd.Parameters.AddWithValue("@fimpresion", string.IsNullOrEmpty(BE.fimpresion) ? (object)DBNull.Value : BE.fimpresion);
                        cmd.Parameters.Add("@fechaini", SqlDbType.Char, 8).Value = BE.fechaini;
                        cmd.Parameters.Add("@fechafin", SqlDbType.Char, 8).Value = BE.fechafin;
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
        public DataSet GetGeneraLibroMayorF61(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_ReporteLibroMayor_F61", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.AddWithValue("@ctamayini", string.IsNullOrEmpty(BE.cuentaini) ? (object)DBNull.Value : BE.cuentaini);
                        cmd.Parameters.AddWithValue("@ctamayfin", string.IsNullOrEmpty(BE.cuentafin) ? (object)DBNull.Value : BE.cuentafin);
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        if (BE.fimpresion == "")
                        { cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = BE.fimpresion; }
                        //cmd.Parameters.AddWithValue("@fimpresion", string.IsNullOrEmpty(BE.fimpresion) ? (object)DBNull.Value : BE.fimpresion);
                        cmd.Parameters.AddWithValue("@fechaini", string.IsNullOrEmpty(BE.fechaini) ? (object)DBNull.Value : BE.fechaini);
                        cmd.Parameters.AddWithValue("@fechafin", string.IsNullOrEmpty(BE.fechafin) ? (object)DBNull.Value : BE.fechafin);
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

        public DataSet GetGeneraLibroInventariosyBalances(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_Inventariosybalances", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@ctamayini", SqlDbType.Char, 2).Value = BE.cuentaini;
                        cmd.Parameters.Add("@ctamayfin", SqlDbType.Char, 2).Value = BE.cuentafin;                       
                        cmd.Parameters.Add("@saldos", SqlDbType.Int).Value = BE.saldos;
                        if (BE.fimpresion == "")
                        { cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = BE.fimpresion; }
                        //cmd.Parameters.Add("@fimpresion", SqlDbType.Char, 8).Value = BE.fimpresion;
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
        public DataSet GetAnalisiscuenta(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_analisiscuenta", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@ctamayini", SqlDbType.Char, 2).Value = BE.ctamayini;
                        cmd.Parameters.Add("@ctamayfin", SqlDbType.Char, 2).Value = BE.ctamayfin;
                        cmd.Parameters.Add("@cuentaini", SqlDbType.Char, 10).Value = BE.cuentaini;
                        cmd.Parameters.Add("@cuentafin", SqlDbType.Char, 10).Value = BE.cuentafin;
                        cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                        if (BE.fechaini == "")
                        { cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = BE.fechaini; }
                        //cmd.Parameters.AddWithValue("@fechaini", string.IsNullOrEmpty(BE.fechaini) ? (object)DBNull.Value : BE.fechaini);
                        if (BE.fechafin == "")
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = BE.fechafin; }
                        //cmd.Parameters.AddWithValue("@fechafin", string.IsNullOrEmpty(BE.fechafin) ? (object)DBNull.Value : BE.fechafin);
                        cmd.Parameters.Add("@hastames", SqlDbType.Char, 2).Value = BE.perimes;
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
        public DataSet GetGeneraLibroMayorAuxiliar(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_ReporteLibroMayorAuxiliar", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.AddWithValue("@cmesini", string.IsNullOrEmpty(BE.cmesini) ? (object)DBNull.Value : BE.cmesini);
                        cmd.Parameters.AddWithValue("@cmesfin", string.IsNullOrEmpty(BE.cmesfin) ? (object)DBNull.Value : BE.cmesfin);
                        cmd.Parameters.AddWithValue("@ctamayini", string.IsNullOrEmpty(BE.ctamayini) ? (object)DBNull.Value : BE.ctamayini);
                        cmd.Parameters.AddWithValue("@cuentaini", string.IsNullOrEmpty(BE.cuentaini) ? (object)DBNull.Value : BE.cuentaini);
                        cmd.Parameters.AddWithValue("@cuentafin", string.IsNullOrEmpty(BE.cuentafin) ? (object)DBNull.Value : BE.cuentafin);
                        cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@norden", SqlDbType.Int).Value = BE.tipmodal;
                        if (BE.fechaini == "")
                        { cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = BE.fechaini; }
                        //cmd.Parameters.AddWithValue("@fechaini", string.IsNullOrEmpty(BE.fechaini) ? (object)DBNull.Value : BE.fechaini);
                        if (BE.fechafin == "")
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = BE.fechafin; }
                        //cmd.Parameters.AddWithValue("@fechafin", string.IsNullOrEmpty(BE.fechafin) ? (object)DBNull.Value : BE.fechafin);
                        if (BE.fimpresion == "")
                        { cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = BE.fimpresion; }
                        //cmd.Parameters.AddWithValue("@fimpresion", string.IsNullOrEmpty(BE.fimpresion) ? (object)DBNull.Value : BE.fimpresion);
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
        public DataSet GetGeneraDocIngresados(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_ReporteContabilidadDocIngresados", cnx))
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
                        //cmd.Parameters.AddWithValue("@fechaini", string.IsNullOrEmpty(BE.fechaini) ? (object)DBNull.Value : BE.fechaini);
                        if (BE.fechafin == "")
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = BE.fechafin; }
                        //cmd.Parameters.AddWithValue("@fechafin", string.IsNullOrEmpty(BE.fechafin) ? (object)DBNull.Value : BE.fechafin);
                        cmd.Parameters.AddWithValue("@cuentaini", string.IsNullOrEmpty(BE.cuentaini) ? (object)DBNull.Value : BE.cuentaini);
                        cmd.Parameters.AddWithValue("@cuentafin", string.IsNullOrEmpty(BE.cuentafin) ? (object)DBNull.Value : BE.cuentafin);
                        cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                        cmd.Parameters.AddWithValue("@diarioid", string.IsNullOrEmpty(BE.diarioid) ? (object)DBNull.Value : BE.diarioid);
                        cmd.Parameters.AddWithValue("@voucher", string.IsNullOrEmpty(BE.asiento) ? (object)DBNull.Value : BE.asiento);
                        cmd.Parameters.AddWithValue("@mostrarDescuadre", SqlDbType.Int).Value = BE.tipmodal;
                        cmd.Parameters.AddWithValue("@nmodalidad", SqlDbType.Int).Value = BE.modalidad;
                        cmd.Parameters.AddWithValue("@ver_cta_blanco", SqlDbType.Int).Value = BE.origen;
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
        public DataSet GetGeneraDiarioGeneralDocumentos(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_ReporteDiarioGeneralDocumentos", cnx))
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
                        //cmd.Parameters.AddWithValue("@fechaini", string.IsNullOrEmpty(BE.fechaini) ? (object)DBNull.Value : BE.fechaini);
                        if (BE.fechafin == "")
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = BE.fechafin; }
                        //cmd.Parameters.AddWithValue("@fechafin", string.IsNullOrEmpty(BE.fechafin) ? (object)DBNull.Value : BE.fechafin);
                        cmd.Parameters.AddWithValue("@diarioid", string.IsNullOrEmpty(BE.diarioid) ? (object)DBNull.Value : BE.diarioid);
                        cmd.Parameters.AddWithValue("@norden", SqlDbType.Int).Value = BE.modalidad;

                        //cmd.Parameters.AddWithValue("@cuentaini", string.IsNullOrEmpty(BE.cuentaini) ? (object)DBNull.Value : BE.cuentaini);
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

        public DataSet GetGeneraDiarioGeneralVouchersAnulados(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_ReporteVouchersAnulados", cnx))
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
                        //cmd.Parameters.AddWithValue("@fechaini", string.IsNullOrEmpty(BE.fechaini) ? (object)DBNull.Value : BE.fechaini);
                        if (BE.fechafin == "")
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = BE.fechafin; }
                        //cmd.Parameters.AddWithValue("@fechafin", string.IsNullOrEmpty(BE.fechafin) ? (object)DBNull.Value : BE.fechafin);
                        cmd.Parameters.AddWithValue("@diarioid", string.IsNullOrEmpty(BE.diarioid) ? (object)DBNull.Value : BE.diarioid);
                        cmd.Parameters.AddWithValue("@norden", SqlDbType.Int).Value = BE.modalidad;

                        //cmd.Parameters.AddWithValue("@cuentaini", string.IsNullOrEmpty(BE.cuentaini) ? (object)DBNull.Value : BE.cuentaini);
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

        public DataSet GetGeneraAnalisisGastosxFuncionAnalitico(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_ReporteGastosxFuncionAnalitico", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        if (BE.fechaini == "")
                        { cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = BE.fechaini; }
                        //cmd.Parameters.Add("@fechaini", SqlDbType.DateTime).Value = BE.fechaini;
                        if (BE.fechafin == "")
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = BE.fechafin; }
                        //cmd.Parameters.Add("@fechafin", SqlDbType.DateTime).Value = BE.fechafin;
                        cmd.Parameters.AddWithValue("@cta_origini", string.IsNullOrEmpty(BE.ctamayini) ? (object)DBNull.Value : BE.ctamayini);
                        cmd.Parameters.AddWithValue("@cta_origfin", string.IsNullOrEmpty(BE.ctamayfin) ? (object)DBNull.Value : BE.ctamayfin);
                        cmd.Parameters.AddWithValue("@cta_destini", string.IsNullOrEmpty(BE.cuentaini) ? (object)DBNull.Value : BE.cuentaini);
                        cmd.Parameters.AddWithValue("@cta_destifin", string.IsNullOrEmpty(BE.cuentafin) ? (object)DBNull.Value : BE.cuentafin);
                        cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                        cmd.Parameters.AddWithValue("@diarioid", string.IsNullOrEmpty(BE.diarioid) ? (object)DBNull.Value : BE.diarioid);
                        cmd.Parameters.AddWithValue("@nro_voucher", string.IsNullOrEmpty(BE.asiento) ? (object)DBNull.Value : BE.asiento);
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@ndestino", SqlDbType.Int).Value = BE.tanalisis;
                        cmd.Parameters.Add("@norden", SqlDbType.Int).Value = BE.tipmodal;
                        if (BE.fimpresion == "")
                        { cmd.Parameters.Add("@fechaimpresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechaimpresion", System.Data.SqlDbType.DateTime).Value = BE.fimpresion; }
                        //cmd.Parameters.AddWithValue("@fechaimpresion", string.IsNullOrEmpty(BE.fimpresion) ? (object)DBNull.Value : BE.fimpresion);
                        cmd.Parameters.AddWithValue("@cencosid", string.IsNullOrEmpty(BE.cencosid) ? (object)DBNull.Value : BE.cencosid);
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
        public DataSet GetGeneraAnalisisGastosxFuncionResumen(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_ReporteGastosxFuncionResumen", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        if (BE.fechaini == "")
                        { cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = BE.fechaini; }
                        //cmd.Parameters.Add("@fechaini", SqlDbType.DateTime).Value = BE.fechaini;
                        if (BE.fechafin == "")
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = BE.fechafin; }
                        //cmd.Parameters.Add("@fechafin", SqlDbType.DateTime).Value = BE.fechafin;
                        cmd.Parameters.AddWithValue("@ctamay_origini", string.IsNullOrEmpty(BE.ctamayini) ? (object)DBNull.Value : BE.ctamayini);
                        cmd.Parameters.AddWithValue("@ctamay_origfin", string.IsNullOrEmpty(BE.ctamayfin) ? (object)DBNull.Value : BE.ctamayfin);
                        cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                        cmd.Parameters.AddWithValue("@diarioid", string.IsNullOrEmpty(BE.diarioid) ? (object)DBNull.Value : BE.diarioid);
                        cmd.Parameters.AddWithValue("@nro_voucher", string.IsNullOrEmpty(BE.asiento) ? (object)DBNull.Value : BE.asiento);
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@nNaturaleza", SqlDbType.Int).Value = BE.tanalisis;
                        cmd.Parameters.Add("@nMostrarMayorizada", SqlDbType.Int).Value = BE.tipmodal;
                        if (BE.fimpresion == "")
                        { cmd.Parameters.Add("@fechaimpresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechaimpresion", System.Data.SqlDbType.DateTime).Value = BE.fimpresion; }
                        //cmd.Parameters.AddWithValue("@fechaimpresion", string.IsNullOrEmpty(BE.fimpresion) ? (object)DBNull.Value : BE.fimpresion);
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

        public DataSet GetGeneraCuadroMensualSaldoDetalle(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_ReporteCuadroMensualSaldoDetalle", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@mesini", SqlDbType.Char, 2).Value = BE.cmesini;
                        cmd.Parameters.Add("@mesfin", SqlDbType.Char, 2).Value = BE.cmesfin;
                        cmd.Parameters.AddWithValue("@CTA_MAYOR", string.IsNullOrEmpty(BE.ctamayini) ? (object)DBNull.Value : BE.ctamayini);
                        cmd.Parameters.AddWithValue("@CTAINI", string.IsNullOrEmpty(BE.cuentaini) ? (object)DBNull.Value : BE.cuentaini);
                        cmd.Parameters.AddWithValue("@CTAFIN", string.IsNullOrEmpty(BE.cuentafin) ? (object)DBNull.Value : BE.cuentafin); 
                        cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                        cmd.Parameters.Add("@naturaleza", SqlDbType.Int).Value = BE.tipmodal;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@ConsiderarAsientosCierre", SqlDbType.Int).Value = BE.origen;
                        cmd.Parameters.Add("@nOrden", SqlDbType.Int).Value = BE.modalidad;
                        if (BE.fimpresion == "")
                        { cmd.Parameters.Add("@fechaimpresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechaimpresion", System.Data.SqlDbType.DateTime).Value = BE.fimpresion; }
                        //cmd.Parameters.AddWithValue("@fechaimpresion", string.IsNullOrEmpty(BE.fimpresion) ? (object)DBNull.Value : BE.fimpresion);
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
        public DataSet GetGeneraCuadroMensualSaldoGeneral(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_ReporteCuadroMensualSaldoGeneral", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@CMESINI", string.IsNullOrEmpty(BE.cmesini) ? (object)DBNull.Value : BE.cmesini);
                        cmd.Parameters.AddWithValue("@CMESFIN", string.IsNullOrEmpty(BE.cmesfin) ? (object)DBNull.Value : BE.cmesfin);
                        cmd.Parameters.AddWithValue("@CTAINI", string.IsNullOrEmpty(BE.cuentaini) ? (object)DBNull.Value : BE.cuentaini);
                        cmd.Parameters.AddWithValue("@CTAFIN", string.IsNullOrEmpty(BE.cuentafin) ? (object)DBNull.Value : BE.cuentafin);
                        cmd.Parameters.Add("@naturaleza", SqlDbType.Int).Value = BE.tipmodal;
                        cmd.Parameters.Add("@nMoneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@VerResumen", SqlDbType.Int).Value = BE.saldos;
                        cmd.Parameters.AddWithValue("@CantDigitos", string.IsNullOrEmpty(BE.tipo) ? (object)DBNull.Value : BE.tipo);
                        cmd.Parameters.Add("@ConsiderarAsientosCierre", SqlDbType.Int).Value = BE.origen;
                        if (BE.fimpresion == "")
                        { cmd.Parameters.Add("@fechaimpresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechaimpresion", System.Data.SqlDbType.DateTime).Value = BE.fimpresion; }
                        //cmd.Parameters.AddWithValue("@fechaimpresion", string.IsNullOrEmpty(BE.fimpresion) ? (object)DBNull.Value : BE.fimpresion);
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

        public DataSet GetGeneraCuentaCorriente(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_CuentaCorriente", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        //int lcont = 0;
                        //DataTable tabla_proveedor = new DataTable();
                        //tabla_proveedor = BE.tabla_proveedores;
                        //if ((tabla_proveedor != null))
                        //{
                        //    for (lcont = 0; lcont <= tabla_proveedor.Rows.Count - 1; lcont++)
                        //    {
                        //        cmd.CommandType = CommandType.StoredProcedure;
                        //        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        //        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        //        cmd.Parameters.Add("@tiprepo", SqlDbType.Int).Value = BE.tiprepo;
                        //        cmd.Parameters.AddWithValue("@fechaini", string.IsNullOrEmpty(BE.fechaini) ? (object)DBNull.Value : BE.fechaini);
                        //        cmd.Parameters.AddWithValue("@fechafin", string.IsNullOrEmpty(BE.fechafin) ? (object)DBNull.Value : BE.fechafin);
                        //        //cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                        //        //cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.tabla_proveedores.Rows[lcont]["detalle"];
                        //        cmd.Parameters.Add("@ctamayini", SqlDbType.Char, 2).Value = BE.cuentaini;
                        //        cmd.Parameters.Add("@ctamayfin", SqlDbType.Char, 2).Value = BE.cuentafin;
                        //        cmd.Parameters.Add("@cuentaid", SqlDbType.Char, 10).Value = BE.cuentaid;
                        //        cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        //        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        //        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        //        cmd.Parameters.Add("@tipsaldo", SqlDbType.Int).Value = BE.saldos;
                        //        cmd.Parameters.Add("@tipmodal", SqlDbType.Int).Value = BE.tipmodal;
                        //        cmd.Parameters.Add("@tanalisis", SqlDbType.Int).Value = BE.tanalisis;
                        //        cmd.Parameters.Add("@relctas", SqlDbType.Char, 150).Value = BE.relctas;
                        //    }
                        //}
                        //else
                        //{
                            cmd.CommandTimeout = 0;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                            cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                            cmd.Parameters.Add("@tiprepo", SqlDbType.Int).Value = BE.tiprepo;
                            //cmd.Parameters.Add("@fechaini", SqlDbType.DateTime).Value = BE.fechaini;
                            //cmd.Parameters.Add("@fechafin", SqlDbType.DateTime).Value = BE.fechafin;
                            //cmd.Parameters.AddWithValue("@fechaini", string.IsNullOrEmpty(BE.fechaini) ? (object)DBNull.Value : BE.fechaini);
                            //cmd.Parameters.AddWithValue("@fechafin", string.IsNullOrEmpty(BE.fechafin) ? (object)DBNull.Value : BE.fechafin);
                            if (BE.fechaini == "")
                            { cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; } 
                            else
                            { cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = BE.fechaini; }

                            if (BE.fechafin == "")
	                        {cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null;}
                            else
                            {cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = BE.fechafin;}

                            //cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null : BE.fechafin);
                            cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                            cmd.Parameters.AddWithValue("@ctamayini", string.IsNullOrEmpty(BE.cuentaini) ? (object)DBNull.Value : BE.cuentaini);
                            cmd.Parameters.AddWithValue("@ctamayfin", string.IsNullOrEmpty(BE.cuentafin) ? (object)DBNull.Value : BE.cuentafin);
                            cmd.Parameters.AddWithValue("@cuentaid", string.IsNullOrEmpty(BE.cuentaid) ? (object)DBNull.Value : BE.cuentaid);
                            cmd.Parameters.AddWithValue("@tipdoc", string.IsNullOrEmpty(BE.tipdoc) ? (object)DBNull.Value : BE.tipdoc);
                            cmd.Parameters.AddWithValue("@serdoc", string.IsNullOrEmpty(BE.serdoc) ? (object)DBNull.Value : BE.serdoc);
                            cmd.Parameters.AddWithValue("@numdoc", string.IsNullOrEmpty(BE.numdoc) ? (object)DBNull.Value : BE.numdoc);
                            cmd.Parameters.Add("@tipsaldo", SqlDbType.Int).Value = BE.saldos;
                            cmd.Parameters.Add("@tipmodal", SqlDbType.Int).Value = BE.tipmodal;
                            cmd.Parameters.Add("@tanalisis", SqlDbType.Int).Value = BE.tanalisis;
                            cmd.Parameters.AddWithValue("@relctas", string.IsNullOrEmpty(BE.relctas) ? (object)DBNull.Value : BE.relctas);
                            cmd.Parameters.AddWithValue("@glosa", string.IsNullOrEmpty(BE.glosa) ? (object)DBNull.Value : BE.glosa);
                        //}
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
        public DataSet GetGeneraCuentaCorrientePC(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_CuentaCorrientePendCancel", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@cuentaini", SqlDbType.Char, 10).Value = BE.cuentaini;
                        cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                        cmd.Parameters.Add("@forma", SqlDbType.Int).Value = BE.saldos;
                        cmd.Parameters.Add("@tipodata", SqlDbType.Int).Value = BE.tipmodal;
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
        public DataSet GetGeneraCuentaCorrienteCajaChica(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_CuentaCorriente_cajachica", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                            cmd.CommandTimeout = 0;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                            cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);                       
                            if (BE.fechaini == "")
                            { cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                            else
                            { cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = BE.fechaini; }

                            if (BE.fechafin == "")
                            { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                            else
                            { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = BE.fechafin; }
                            cmd.Parameters.AddWithValue("@ctamayini", string.IsNullOrEmpty(BE.cuentaini) ? (object)DBNull.Value : BE.cuentaini);
                            cmd.Parameters.AddWithValue("@ctamayfin", string.IsNullOrEmpty(BE.cuentafin) ? (object)DBNull.Value : BE.cuentafin);
                            cmd.Parameters.Add("@tipsaldo", SqlDbType.Int).Value = BE.saldos;
                            cmd.Parameters.Add("@tipmodal", SqlDbType.Int).Value = BE.tipmodal;
                            cmd.Parameters.Add("@tanalisis", SqlDbType.Int).Value = BE.tanalisis;
                            cmd.Parameters.AddWithValue("@relctas", string.IsNullOrEmpty(BE.relctas) ? (object)DBNull.Value : BE.relctas);
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
        public DataSet GetGeneraCuentaCorrienteCajaChica_CC(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_CuentaCorriente_cajachica_CC", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                        if (BE.fechaini == "")
                        { cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = BE.fechaini; }

                        if (BE.fechafin == "")
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = BE.fechafin; }
                        cmd.Parameters.AddWithValue("@ctamayini", string.IsNullOrEmpty(BE.cuentaini) ? (object)DBNull.Value : BE.cuentaini);
                        cmd.Parameters.AddWithValue("@ctamayfin", string.IsNullOrEmpty(BE.cuentafin) ? (object)DBNull.Value : BE.cuentafin);
                        cmd.Parameters.Add("@tipsaldo", SqlDbType.Int).Value = BE.saldos;
                        cmd.Parameters.Add("@tipmodal", SqlDbType.Int).Value = BE.tipmodal;
                        cmd.Parameters.Add("@tanalisis", SqlDbType.Int).Value = BE.tanalisis;
                        cmd.Parameters.AddWithValue("@relctas", string.IsNullOrEmpty(BE.relctas) ? (object)DBNull.Value : BE.relctas);
                        cmd.Parameters.AddWithValue("@tipdoc", string.IsNullOrEmpty(BE.tipdoc) ? (object)DBNull.Value : BE.tipdoc);
                        cmd.Parameters.AddWithValue("@serdoc", string.IsNullOrEmpty(BE.serdoc) ? (object)DBNull.Value : BE.serdoc);
                        cmd.Parameters.AddWithValue("@numdoc", string.IsNullOrEmpty(BE.numdoc) ? (object)DBNull.Value : BE.numdoc);
                        cmd.Parameters.AddWithValue("@cencosid", string.IsNullOrEmpty(BE.cencosid) ? (object)DBNull.Value : BE.cencosid);
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
        public DataSet GetGeneraCuentaCorrienteCajaChica_4010106(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_CuentaCorriente_cajachica_4010106", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                        if (BE.fechaini == "")
                        { cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = BE.fechaini; }

                        if (BE.fechafin == "")
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = BE.fechafin; }
                        cmd.Parameters.AddWithValue("@ctamayini", string.IsNullOrEmpty(BE.cuentaini) ? (object)DBNull.Value : BE.cuentaini);
                        cmd.Parameters.AddWithValue("@ctamayfin", string.IsNullOrEmpty(BE.cuentafin) ? (object)DBNull.Value : BE.cuentafin);
                        cmd.Parameters.Add("@tipsaldo", SqlDbType.Int).Value = BE.saldos;
                        cmd.Parameters.Add("@tipmodal", SqlDbType.Int).Value = BE.tipmodal;
                        cmd.Parameters.Add("@tanalisis", SqlDbType.Int).Value = BE.tanalisis;
                        cmd.Parameters.AddWithValue("@relctas", string.IsNullOrEmpty(BE.relctas) ? (object)DBNull.Value : BE.relctas);
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
        
        public DataSet GetGeneraReporteVcmtoLetras(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_ReporteVcmtoLetras", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@cuentaini", string.IsNullOrEmpty(BE.cuentaini) ? (object)DBNull.Value : BE.cuentaini);
                        cmd.Parameters.AddWithValue("@cuentafin", string.IsNullOrEmpty(BE.cuentafin) ? (object)DBNull.Value : BE.cuentafin);
                        cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                        if (BE.fechaini == "")
                        { cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = BE.fechaini; }
                        //cmd.Parameters.AddWithValue("@fechaini", string.IsNullOrEmpty(BE.fechaini) ? (object)DBNull.Value : BE.fechaini);
                        if (BE.fechafin == "")
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = BE.fechafin; }
                        //cmd.Parameters.AddWithValue("@fechafin", string.IsNullOrEmpty(BE.fechafin) ? (object)DBNull.Value : BE.fechafin);
                        cmd.Parameters.AddWithValue("@veranalisisdoc", SqlDbType.Int).Value = BE.origen;
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

        public DataSet GetGeneraPDBFormasPago(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_GeneraDataPDBFormasPago", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
        public DataSet GetGeneraDAOTComprasVentas(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_GeneraDataDAOT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        //if (BE.fechaini == "")
                        //{ cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        //else
                        //{ cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = BE.fechaini; }
                        cmd.Parameters.Add("@fechaini", SqlDbType.DateTime).Value = BE.fechaini;
                        //if (BE.fechafin == "")
                        //{ cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        //else
                        //{ cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = BE.fechafin; }
                        cmd.Parameters.Add("@fechafin", SqlDbType.DateTime).Value = BE.fechafin;
                        //cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                        cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                        cmd.Parameters.Add("@moneda", SqlDbType.Char).Value = BE.moneda;
                        cmd.Parameters.Add("@origen", SqlDbType.Int).Value = BE.origen;
                        cmd.Parameters.Add("@modalidad", SqlDbType.Int).Value = BE.modalidad;
                        cmd.Parameters.Add("@IncValorVta", SqlDbType.Int).Value = BE.IncValorVta;
                        cmd.Parameters.Add("@nValorVenta", SqlDbType.Decimal).Value = BE.nValorVenta;
                        if (BE.fimpresion == "")
                        { cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = BE.fimpresion; }
                        //cmd.Parameters.Add("@fimpresion", SqlDbType.Char, 8).Value = BE.fimpresion;
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
        public DataSet GetGeneraRankingComprasVentas(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_GeneraDataRankingCV", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@fechaini", SqlDbType.DateTime).Value = BE.fechaini;
                        cmd.Parameters.Add("@fechafin", SqlDbType.DateTime).Value = BE.fechafin;
                        cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                        cmd.Parameters.Add("@origen", SqlDbType.Int).Value = BE.origen;
                        cmd.Parameters.AddWithValue("@rubroini", string.IsNullOrEmpty(BE.rubroini) ? (object)DBNull.Value : BE.rubroini);
                        cmd.Parameters.AddWithValue("@rubrofin", string.IsNullOrEmpty(BE.rubrofin) ? (object)DBNull.Value : BE.rubrofin);
                        cmd.Parameters.Add("@moneda", SqlDbType.Char).Value = BE.moneda;                        
                        cmd.Parameters.Add("@modalidad", SqlDbType.Int).Value = BE.modalidad;
                        cmd.Parameters.Add("@IncValorVta", SqlDbType.Int).Value = BE.IncValorVta;
                        cmd.Parameters.Add("@nValorVenta", SqlDbType.Decimal).Value = BE.nValorVenta;
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public DataSet GetGeneraPDT0601Rta4taCag(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_GeneraDatosRTPS", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ccia", string.IsNullOrEmpty(BE.tipdoc) ? (object)DBNull.Value : BE.tipdoc);
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                        cmd.Parameters.AddWithValue("@ntipo", SqlDbType.Int).Value = BE.modalidad;
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

        public DataSet GetVerificaCtaDestinoEnAsiento(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_verificactadestinoenasiento", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                        cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = BE.tiprepo;
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

        public bool GetGeneraAjusteAsientos_tabla(string empresaid, tb_co_Movimientos BE, DataTable TablaDatos)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                bool xreturn = true;
                int lcont = 0;
                for (lcont = 0; lcont <= TablaDatos.Rows.Count - 1; lcont++)
                {
                    using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_AjustarAsientos", cnx))
                    {                   
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = TablaDatos.Rows[lcont]["perianio"].ToString(); //BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = TablaDatos.Rows[lcont]["perimes"].ToString();
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = TablaDatos.Rows[lcont]["moduloid"].ToString();
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = TablaDatos.Rows[lcont]["local"].ToString();
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = TablaDatos.Rows[lcont]["diarioid"].ToString();
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = TablaDatos.Rows[lcont]["voucher"].ToString();
                        //cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null;
                        //cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null;
                        cmd.Parameters.Add("@bloquear", SqlDbType.Int).Value = 0;
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
                return xreturn; 
            }
        }
        public bool GetGeneraAjusteAsientos(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_AjustarAsientos", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                    cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
                    //cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null;
                    //cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null;
                    cmd.Parameters.Add("@bloquear", SqlDbType.Int).Value = 1;

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
                        return false;
                        //throw new Exception(ex.Message);
                    }
                }
            }
        }

        public bool GetGeneraAsientosAutomaticos_Destinos(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_AsientoAutomaticoDestino", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                    cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                    cmd.Parameters.AddWithValue("@moduloid", string.IsNullOrEmpty(BE.moduloid) ? (object)DBNull.Value : BE.moduloid);
                    cmd.Parameters.AddWithValue("@local", string.IsNullOrEmpty(BE.local) ? (object)DBNull.Value : BE.local);
                    cmd.Parameters.AddWithValue("@diarioid", string.IsNullOrEmpty(BE.diarioid) ? (object)DBNull.Value : BE.diarioid);
                    cmd.Parameters.AddWithValue("@asiento", string.IsNullOrEmpty(BE.asiento) ? (object)DBNull.Value : BE.asiento);
                    cmd.Parameters.Add("@TipoOperacion", SqlDbType.Int).Value = BE.tipmodal;
                    if (BE.fechaini == "")
                    { cmd.Parameters.Add("@FechaIni", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                    else
                    { cmd.Parameters.Add("@FechaIni", System.Data.SqlDbType.DateTime).Value = BE.fechaini; }
                    if (BE.fechafin == "")
                    { cmd.Parameters.Add("@FechaFin", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                    else
                    { cmd.Parameters.Add("@FechaFin", System.Data.SqlDbType.DateTime).Value = BE.fechafin; }
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
                        return false;
                        //throw new Exception(ex.Message);
                    }
                }
            }
        }

        public DataSet GetDetermina_IGV_Renta(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_Determina_IGV_Renta", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                        cmd.Parameters.AddWithValue("@moneda", string.IsNullOrEmpty(BE.moneda) ? (object)DBNull.Value : BE.moneda);
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
        public DataSet GetReporte_IGV_Renta(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbColiquidacionigvrtadet_Consulta", cnx))
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public DataSet GetGenera_CuadroMensualVe_Co(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_CuadroMensualVe_Co", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                        cmd.Parameters.AddWithValue("@moneda", string.IsNullOrEmpty(BE.moneda) ? (object)DBNull.Value : BE.moneda);
                        cmd.Parameters.AddWithValue("@cuentaid", string.IsNullOrEmpty(BE.cuentaid) ? (object)DBNull.Value : BE.cuentaid);
                        cmd.Parameters.AddWithValue("@cuentafin", string.IsNullOrEmpty(BE.cuentafin) ? (object)DBNull.Value : BE.cuentafin);
                        cmd.Parameters.AddWithValue("@tipo", string.IsNullOrEmpty(BE.tipreporte) ? (object)DBNull.Value : BE.tipreporte);
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

        public DataSet GetGenera_AnalisisVentas(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_ReporteRegistroVenta_Analisis", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@perimesini", string.IsNullOrEmpty(BE.cmesini) ? (object)DBNull.Value : BE.cmesini);
                        cmd.Parameters.AddWithValue("@perimesfin", string.IsNullOrEmpty(BE.cmesfin) ? (object)DBNull.Value : BE.cmesfin);
                        cmd.Parameters.AddWithValue("@cencosid", string.IsNullOrEmpty(BE.cencosini) ? (object)DBNull.Value : BE.cencosini);
                        //cmd.Parameters.AddWithValue("@cencosid", string.IsNullOrEmpty(BE.cencosfin) ? (object)DBNull.Value : BE.cencosfin);
                        //cmd.Parameters.AddWithValue("@diarioid", string.IsNullOrEmpty(BE.diarioid) ? (object)DBNull.Value : BE.diarioid);
                        cmd.Parameters.AddWithValue("@moneda", string.IsNullOrEmpty(BE.moneda) ? (object)DBNull.Value : BE.moneda);
                        cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = BE.tipmodal;	
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

        public DataSet GetGenera_ConsultaSunat(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_ConsultaRuc", cnx))
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
        public DataSet GetGenera_ConsultaSunatRXH(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_ConsultaRucRXH", cnx))
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public DataSet GetGenera_ConsultaSunatAct(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_ExtraerCliPro", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@tipdoc", string.IsNullOrEmpty(BE.tipdoc) ? (object)DBNull.Value : BE.tipdoc);
                        cmd.Parameters.AddWithValue("@diarioid", string.IsNullOrEmpty(BE.diarioid) ? (object)DBNull.Value : BE.diarioid);
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

        #region Detalle Inventarios y Balances
        public DataSet GetGeneraFlujoEfectivo(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_FlujoEfectivo", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                        cmd.Parameters.AddWithValue("@moneda", string.IsNullOrEmpty(BE.moneda) ? (object)DBNull.Value : BE.moneda);
                        cmd.Parameters.Add("@saldos", SqlDbType.Int).Value = BE.saldos;
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
        public DataSet GetGeneraFEfectivo_Consulta(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_FlujoEfectivo_Consulta", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@cmesini", string.IsNullOrEmpty(BE.cmesini) ? (object)DBNull.Value : BE.cmesini);
                        cmd.Parameters.AddWithValue("@cmesfin", string.IsNullOrEmpty(BE.cmesfin) ? (object)DBNull.Value : BE.cmesfin);
                        cmd.Parameters.AddWithValue("@flujoid", string.IsNullOrEmpty(BE.flujoefectivo) ? (object)DBNull.Value : BE.flujoefectivo);
                        cmd.Parameters.AddWithValue("@diarioid", string.IsNullOrEmpty(BE.diarioid) ? (object)DBNull.Value : BE.diarioid);
                        cmd.Parameters.AddWithValue("@cuentaid", string.IsNullOrEmpty(BE.cuentaid) ? (object)DBNull.Value : BE.cuentaid);
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
        public DataSet GetGeneraFlujoEfectivo_Comparativo(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_FlujoEfectivo_Comparativo", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                        cmd.Parameters.AddWithValue("@moneda", string.IsNullOrEmpty(BE.moneda) ? (object)DBNull.Value : BE.moneda);
                        cmd.Parameters.Add("@saldos", SqlDbType.Int).Value = BE.saldos;
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
        
        public DataSet GetGeneraF32DetalleCajaBancos(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_Formato32DetalleCajaBancos", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                        cmd.Parameters.AddWithValue("@moneda", string.IsNullOrEmpty(BE.moneda) ? (object)DBNull.Value : BE.moneda);
                        cmd.Parameters.AddWithValue("@cuentaid", string.IsNullOrEmpty(BE.cuentaid) ? (object)DBNull.Value : BE.cuentaid);
                        cmd.Parameters.Add("@saldos", SqlDbType.Int).Value = BE.saldos;
                        //if (BE.fimpresion == "")
                        //{ cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        //else
                        //{ cmd.Parameters.Add("@fimpresion", System.Data.SqlDbType.DateTime).Value = BE.fimpresion; }
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
        public DataSet GetGeneraFDetalleCuentas(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_Formato33DetalleSaldoCta12", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                        cmd.Parameters.AddWithValue("@moneda", string.IsNullOrEmpty(BE.moneda) ? (object)DBNull.Value : BE.moneda);
                        cmd.Parameters.AddWithValue("@cuentaid", string.IsNullOrEmpty(BE.cuentaid) ? (object)DBNull.Value : BE.cuentaid);
                        cmd.Parameters.Add("@saldo", SqlDbType.Int).Value = BE.saldos;
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
        #endregion

        #region Ajustes-Redondeos y Ajuste Dif.Cambio
        public DataSet GetGeneraAsientoAjusteDifRedondeo(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_AjustesDiferenciaRedondeo", cnx))
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

                        cmd.Parameters.AddWithValue("@ctamayini", string.IsNullOrEmpty(BE.ctamayini) ? (object)DBNull.Value : BE.ctamayini);
                        cmd.Parameters.AddWithValue("@ctamayfin", string.IsNullOrEmpty(BE.ctamayfin) ? (object)DBNull.Value : BE.ctamayfin);
                        cmd.Parameters.AddWithValue("@cuentaini", string.IsNullOrEmpty(BE.cuentaini) ? (object)DBNull.Value : BE.cuentaini);
                        cmd.Parameters.AddWithValue("@cuentafin", string.IsNullOrEmpty(BE.cuentafin) ? (object)DBNull.Value : BE.cuentafin);
                        cmd.Parameters.AddWithValue("@moneda", string.IsNullOrEmpty(BE.moneda) ? (object)DBNull.Value : BE.moneda);
                        cmd.Parameters.Add("@modalidad", SqlDbType.Int).Value = BE.modalidad;
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
        }
        public DataSet GetGeneraAsientoAjusteDifCambio(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_AjustesDiferenciaCambio", cnx))
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

                        cmd.Parameters.AddWithValue("@ctamayini", string.IsNullOrEmpty(BE.ctamayini) ? (object)DBNull.Value : BE.ctamayini);
                        cmd.Parameters.AddWithValue("@ctamayfin", string.IsNullOrEmpty(BE.ctamayfin) ? (object)DBNull.Value : BE.ctamayfin);
                        cmd.Parameters.AddWithValue("@cuentaini", string.IsNullOrEmpty(BE.cuentaini) ? (object)DBNull.Value : BE.cuentaini);
                        cmd.Parameters.AddWithValue("@cuentafin", string.IsNullOrEmpty(BE.cuentafin) ? (object)DBNull.Value : BE.cuentafin);
                        cmd.Parameters.AddWithValue("@moneda", string.IsNullOrEmpty(BE.moneda) ? (object)DBNull.Value : BE.moneda);
                        cmd.Parameters.Add("@modalidad", SqlDbType.Int).Value = BE.modalidad;
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
        }       
        #endregion

        #region  Apertura, Ajustes Dif.Cambio al cierre y Cierre del Ejercicio
        public bool GetGeneraAsientoApertura(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_AsientoApertura", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                    cmd.Parameters.AddWithValue("@newperiodo", string.IsNullOrEmpty(BE.newperianio) ? (object)DBNull.Value : BE.newperianio);
                    cmd.Parameters.AddWithValue("@diarioid", string.IsNullOrEmpty(BE.diarioid) ? (object)DBNull.Value : BE.diarioid);
                    cmd.Parameters.Add("@fechaapertura", System.Data.SqlDbType.DateTime).Value = BE.fechaini;
                    cmd.Parameters.AddWithValue("@ctaresultado", string.IsNullOrEmpty(BE.cuentaid) ? (object)DBNull.Value : BE.cuentaid);
                    cmd.Parameters.AddWithValue("@usuar", string.IsNullOrEmpty(BE.usuar) ? (object)DBNull.Value : BE.usuar);
                    cmd.Parameters.AddWithValue("@ctacte", string.IsNullOrEmpty(BE.ctacte) ? (object)DBNull.Value : BE.ctacte);
                    cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                    cmd.Parameters.AddWithValue("@ctactename", string.IsNullOrEmpty(BE.ctactename) ? (object)DBNull.Value : BE.ctactename);

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
                        return false;
                        //throw new Exception(ex.Message);
                    }
                }
            }
        }
        
        public bool GetGeneraAsientoDifCambioCierre(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_AsientoDifCambioCierreEjercicio", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                    cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                    cmd.Parameters.AddWithValue("@diarioid", string.IsNullOrEmpty(BE.diarioid) ? (object)DBNull.Value : BE.diarioid);
                    //cmd.Parameters.AddWithValue("@ctamayini", string.IsNullOrEmpty(BE.ctamayini) ? (object)DBNull.Value : BE.ctamayini);
                    cmd.Parameters.Add("@ctamayini", SqlDbType.Char, 2).Value = (BE.ctamayini.Trim().Length == 0 ? (object)DBNull.Value : BE.ctamayini);
                    //cmd.Parameters.AddWithValue("@ctamayfin", string.IsNullOrEmpty(BE.ctamayfin) ? (object)DBNull.Value : BE.ctamayfin);
                    cmd.Parameters.Add("@ctamayfin", SqlDbType.Char, 2).Value = (BE.ctamayfin.Trim().Length == 0 ? (object)DBNull.Value : BE.ctamayfin);
                    //cmd.Parameters.AddWithValue("@cuentaini", string.IsNullOrEmpty(BE.cuentaini) ? (object)DBNull.Value : BE.cuentaini);
                    cmd.Parameters.Add("@cuentaini", SqlDbType.Char, 10).Value = (BE.cuentaini.Trim().Length == 0 ? (object)DBNull.Value : BE.cuentaini);
                    //cmd.Parameters.AddWithValue("@cuentafin", string.IsNullOrEmpty(BE.cuentafin) ? (object)DBNull.Value : BE.cuentafin);
                    cmd.Parameters.Add("@cuentafin", SqlDbType.Char, 10).Value = (BE.cuentafin.Trim().Length == 0 ? (object)DBNull.Value : BE.cuentafin);
                    //cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                    cmd.Parameters.Add("@nmruc", SqlDbType.Char,11).Value = (BE.nmruc.Trim().Length == 0 ? (object)DBNull.Value : BE.nmruc);
                    if (BE.fechaini == "")
                    { cmd.Parameters.Add("@f_voucher", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                    else
                    { cmd.Parameters.Add("@f_voucher", System.Data.SqlDbType.DateTime).Value = BE.fechaini; }
                    cmd.Parameters.Add("@tc_activo", SqlDbType.Decimal).Value = BE.tipcambtc;
                    cmd.Parameters.Add("@tc_pasivo", SqlDbType.Decimal).Value = BE.tipcambtv;
                    cmd.Parameters.Add("@usuario", SqlDbType.Char, 15).Value = BE.usuar;
                    //cmd.Parameters.Add("@ngraba", SqlDbType.Int).Value = BE.tipmodal = 1;

                    //if (SQL_CONNECT(false))
                    //{
                    //    try
                    //    {
                    //        AddStore("spu_asientodifcambiocierreejercicio");
                    //        AddParametro("@ccia", SqlDbType.Char, CCIA);
                    //        AddParametro("@CPERIODO", SqlDbType.Char, CPERIODO);
                    //        AddParametro("@ctipvoucher", SqlDbType.Char, (ctipvoucher.Trim().Length == 0 ? DBNull.Value : ctipvoucher));
                    //        AddParametro("@CUENTAMAYOR", SqlDbType.Char, (CUENTAMAYOR.Trim().Length == 0 ? DBNull.Value : CUENTAMAYOR));
                    //        AddParametro("@CUENTAMAYORFIN", SqlDbType.Char, (CUENTAMAYORFIN.Trim().Length == 0 ? DBNull.Value : CUENTAMAYORFIN));
                    //        AddParametro("@CUENTAINI", SqlDbType.Char, (CUENTAINI.Trim().Length == 0 ? DBNull.Value : CUENTAINI));
                    //        AddParametro("@CUENTAFIN", SqlDbType.Char, (CUENTAFIN.Trim().Length == 0 ? DBNull.Value : CUENTAFIN));
                    //        AddParametro("@DETALLE", SqlDbType.Char, (DETALLE.Trim().Length == 0 ? DBNull.Value : DETALLE));
                    //        AddParametro("@f_voucher", SqlDbType.Char, (f_voucher.Trim().Length == 0 ? DBNull.Value : f_voucher));
                    //        AddParametro("@tc_activo", SqlDbType.Decimal, tc_activo);
                    //        AddParametro("@tc_pasivo", SqlDbType.Decimal, tc_pasivo);
                    //        AddParametro("@usuario", SqlDbType.Char, usuario);
                    //        retorno = COMANDOSQL.ExecuteNonQuery;
                    //        COMANDOSQL.Parameters.Clear();

                    //        retorno = 1;
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        Sql_Error = ex.Message;
                    //        retorno = 0;
                    //    }
                    //    SQL_DISCONNECT();
                    //}
                    //return retorno == 1;
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
        public DataSet GetGeneraAsientoDifCambioCierreConsulta(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_AsientoDifCambioCierreEjercicio", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                        cmd.Parameters.AddWithValue("@perimes", string.IsNullOrEmpty(BE.perimes) ? (object)DBNull.Value : BE.perimes);
                        cmd.Parameters.AddWithValue("@diarioid", string.IsNullOrEmpty(BE.diarioid) ? (object)DBNull.Value : BE.diarioid);
                        cmd.Parameters.AddWithValue("@ctamayini", string.IsNullOrEmpty(BE.ctamayini) ? (object)DBNull.Value : BE.ctamayini);
                        cmd.Parameters.AddWithValue("@ctamayfin", string.IsNullOrEmpty(BE.ctamayfin) ? (object)DBNull.Value : BE.ctamayfin);
                        cmd.Parameters.AddWithValue("@cuentaini", string.IsNullOrEmpty(BE.cuentaini) ? (object)DBNull.Value : BE.cuentaini);
                        cmd.Parameters.AddWithValue("@cuentafin", string.IsNullOrEmpty(BE.cuentafin) ? (object)DBNull.Value : BE.cuentafin);
                        cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                        if (BE.fechaini == "")
                        { cmd.Parameters.Add("@f_voucher", System.Data.SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null; }
                        else
                        { cmd.Parameters.Add("@f_voucher", System.Data.SqlDbType.DateTime).Value = BE.fechaini; }
                        cmd.Parameters.Add("@tc_activo", SqlDbType.Decimal).Value = BE.tipcambtc;
                        cmd.Parameters.Add("@tc_pasivo", SqlDbType.Decimal).Value = BE.tipcambtv;
                        cmd.Parameters.Add("@usuario", SqlDbType.Char, 15).Value = BE.usuar;
                        cmd.Parameters.Add("@ngraba", SqlDbType.Int).Value = BE.tipmodal = 0;
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
       
        public bool GetGeneraAsientoCierreEjercicio(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_AsientoCierreEjercicio", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@perianio", string.IsNullOrEmpty(BE.perianio) ? (object)DBNull.Value : BE.perianio);
                    cmd.Parameters.AddWithValue("@diarioid", string.IsNullOrEmpty(BE.diarioid) ? (object)DBNull.Value : BE.diarioid);
                    cmd.Parameters.AddWithValue("@cta_ganancia", string.IsNullOrEmpty(BE.cta_ganancia) ? (object)DBNull.Value : BE.cta_ganancia);
                    cmd.Parameters.AddWithValue("@cta_perdida", string.IsNullOrEmpty(BE.cta_perdida) ? (object)DBNull.Value : BE.cta_perdida);
                    cmd.Parameters.AddWithValue("@cta_resultado", string.IsNullOrEmpty(BE.cuentaid) ? (object)DBNull.Value : BE.cuentaid);
                    cmd.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                    cmd.Parameters.AddWithValue("@usuar", string.IsNullOrEmpty(BE.usuar) ? (object)DBNull.Value : BE.usuar);
                    cmd.Parameters.AddWithValue("@ctacte", string.IsNullOrEmpty(BE.ctacte) ? (object)DBNull.Value : BE.ctacte);
                    cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.nmruc) ? (object)DBNull.Value : BE.nmruc);
                    cmd.Parameters.AddWithValue("@ctactename", string.IsNullOrEmpty(BE.ctactename) ? (object)DBNull.Value : BE.ctactename);

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
                        return false;
                        //throw new Exception(ex.Message);
                    }
                }
            }
        }
        #endregion

        #region  LIBROS ELECTRONICOS
        public DataSet GetGeneraPLE_Sunat101(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_SunatLibroPLE_101CajaBancos", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
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
        public DataSet GetGeneraPLE_Sunat102(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_SunatLibroPLE_102CajaBancos", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
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

        public DataSet GetGeneraPLE_Sunat301(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_SunatLibroPLE_301BalanceGerl", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
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
        public DataSet GetGeneraPLE_Sunat302(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_SunatLibroPLE_302EfecyEquEfectivo", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
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

        public DataSet GetGeneraPLE_Sunat041(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_SunatLibroPLE_401RetencionesIR", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public DataSet GetGeneraPLE_SunatLibroDiario51(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_SunatLibroDiario51", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
        public DataSet GetGeneraPLE_SunatLibroDiarioPC53(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoPlancontable_PLE53", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@codigopc", SqlDbType.Char, 2).Value = BE.codigopc;
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

        public DataSet GetGeneraPLE_SunatLibroMayor61(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_SunatLibroMayor61", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
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
        
        public DataSet GetGeneraPLE_SunatRegistroCompra81(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_SunatRegistroCompra81", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
        public DataSet GetGeneraPLE_SunatRegistroVentas141(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_SunatRegistroVenta141", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
        #endregion

        #region // LIBROS Y/O REGISTROS FISCALIZACION
        public DataSet GetGeneraLibroDiario_Fiscalizacion(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_SunatLibroDiario5_Fiscalizacion", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
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
        public DataSet GetGeneraLibroMayor_Fiscalizacion(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_SunatLibroMayor6_Fiscalizacion", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
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

        public DataSet GetGeneraRegistroCompra_Fiscalizacion(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_SunatRegistroCompra8_Fiscalizacion", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
        public DataSet GetGeneraRegistroVentas_Fiscalizacion(string empresaid, tb_co_Movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_SunatRegistroVenta14_Fiscalizacion", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
        #endregion

        #region *** validar fecha en formato correcto
        public DateTime fecha(DateTime pfecha)
        {
            //string dia = pfecha.Day.ToString();
            //string mes = pfecha.Month.ToString();
            //string anio = pfecha.Year.ToString();
            //string fecha = anio + "-" + mes + "-" + dia;
            DateTime lfech;
            //DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
            //IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
            if (pfecha != null)
            {
                if (pfecha != DateTime.Parse("01/01/0001 12:00:00 a.m."))
                {
                    lfech = pfecha;
                }
                else
                {
                    lfech = DateTime.Parse("01/01/1900");
                }
            }
            else
            {
                lfech = DateTime.Parse("01/01/1900");
            }

            return lfech;
        }
        public DateTime fecha02(DateTime pfecha)
        {
            String lfech;
            IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
            if (pfecha != null)
            {
                if (pfecha != DateTime.Parse("01/01/0001 12:00:00 a.m.", culture, System.Globalization.DateTimeStyles.AssumeLocal))
                {
                    lfech = pfecha.ToString();
                }
                else
                {
                    lfech = DateTime.Parse("01/01/1900 12:00:00 a.m.").ToString();
                }
            }
            else
            {
                lfech = DateTime.Parse("01/01/1900 12:00:00 a.m.").ToString();
            }
            return DateTime.Parse(lfech, culture, System.Globalization.DateTimeStyles.AssumeLocal);
        }
        #endregion
    }
}
