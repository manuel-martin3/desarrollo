using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_co_conciliacionbancariaDA
    {
        public String Sql_Error = "";
        Conexion conex = new Conexion();

        public bool Insert(string empresaid, tb_co_conciliacionbancaria BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd1 = new SqlCommand("gspTbCoConciliacionbancaria_INSERT_xml", cnx))
                {
                    cmd1.CommandTimeout = 0;
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.Perianio;
                    cmd1.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.Perimes;
                    cmd1.Parameters.Add("@cuentaid", SqlDbType.Char, 13).Value = BE.Cuentaid;
                    cmd1.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.Usuar;
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
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public bool Insert_Update(string empresaid, tb_co_conciliacionbancaria BE, DataTable Detalle)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                bool xreturn = true;
                int lccontdetalle = 0;
                if ((Detalle != null))
                {
                    for (lccontdetalle = 0; lccontdetalle <= Detalle.Rows.Count - 1; lccontdetalle++)
                    {
                        using (SqlCommand cmd = new SqlCommand("gspTbCoConciliacionbancaria_InsertUpdate", cnx))
                        {
                            cmd.CommandTimeout = 0;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["perianio"];
                            cmd.Parameters.Add("@perimes", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["perimes"];
                            cmd.Parameters.Add("@moduloid", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["moduloid"];
                            cmd.Parameters.Add("@local", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["local"];
                            cmd.Parameters.Add("@diarioid", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["diarioid"];
                            cmd.Parameters.Add("@asiento", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["asiento"];
                            cmd.Parameters.Add("@asientoitems", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["asientoitems"];
                            cmd.Parameters.Add("@fechregistro", SqlDbType.DateTime).Value = Detalle.Rows[lccontdetalle]["fechregistro"];
                            cmd.Parameters.Add("@cuentaid", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["cuentaid"];
                            cmd.Parameters.Add("@debehaber", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["debehaber"];
                            cmd.Parameters.Add("@tipdoc", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["tipdoc"];
                            cmd.Parameters.Add("@serdoc", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["serdoc"];
                            cmd.Parameters.Add("@numdoc", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["numdoc"];
                            cmd.Parameters.Add("@mediopago", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["mediopago"];
                            cmd.Parameters.Add("@numdocpago", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["numdocpago"];
                            cmd.Parameters.Add("@ctacte", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["ctacte"];
                            cmd.Parameters.Add("@nmruc", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["nmruc"];
                            cmd.Parameters.Add("@ctactename", SqlDbType.VarChar).Value = Detalle.Rows[lccontdetalle]["ctactename"];
                            cmd.Parameters.Add("@saldo_si", SqlDbType.Decimal).Value = Detalle.Rows[lccontdetalle]["saldo_si"];
                            cmd.Parameters.Add("@cargo", SqlDbType.Decimal).Value = Detalle.Rows[lccontdetalle]["cargo"];
                            cmd.Parameters.Add("@abono", SqlDbType.Decimal).Value = Detalle.Rows[lccontdetalle]["abono"];
                            cmd.Parameters.Add("@saldo", SqlDbType.Decimal).Value = Detalle.Rows[lccontdetalle]["saldo"];
                            cmd.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = Detalle.Rows[lccontdetalle]["tipcamb"];
                            cmd.Parameters.Add("@moneda", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["moneda"];
                            cmd.Parameters.Add("@es_conciliado", SqlDbType.Bit).Value = Detalle.Rows[lccontdetalle]["es_conciliado"];
                            cmd.Parameters.Add("@es_manual", SqlDbType.Bit).Value = Detalle.Rows[lccontdetalle]["es_manual"];
                            cmd.Parameters.Add("@es_otroperiodo", SqlDbType.Bit).Value = Detalle.Rows[lccontdetalle]["es_otroperiodo"];
                            cmd.Parameters.Add("@fechextracto", SqlDbType.DateTime).Value = Detalle.Rows[lccontdetalle]["fechextracto"];
                            cmd.Parameters.Add("@glosa", SqlDbType.VarChar).Value = Detalle.Rows[lccontdetalle]["glosa"];
                            cmd.Parameters.Add("@usuar", SqlDbType.Char).Value = BE.Usuar.Trim();
                            //cmd.Parameters.Add("@usuar", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["usuar"];
                            //cmd.Parameters.Add("@fecre", SqlDbType.DateTime).Value = Detalle.Rows[lccontdetalle]["fecre"];
                            //cmd.Parameters.Add("@feact", SqlDbType.DateTime).Value = Detalle.Rows[lccontdetalle]["feact"];
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
                return xreturn;
            }
        }
        public bool Insert_Update_Conta(string empresaid, tb_co_conciliacionbancaria BE, DataTable Detalle)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                bool xreturn = true;
                int lccontdetalle = 0;
                if (BE.Diarioid != "0000")
                {
                    if ((Detalle != null))
                    {
                        for (lccontdetalle = 0; lccontdetalle <= Detalle.Rows.Count - 1; lccontdetalle++)
                        {
                            if (Detalle.Rows[lccontdetalle]["status"].ToString() == "0")
                            {
                                using (SqlCommand cmd = new SqlCommand("gspTbCoConciliacionbancaria_InsertUpdate", cnx))
                                {
                                    cmd.CommandTimeout = 0;
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.Add("@perianio", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["perianio"];
                                    cmd.Parameters.Add("@perimes", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["perimes"];
                                    cmd.Parameters.Add("@moduloid", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["moduloid"];
                                    cmd.Parameters.Add("@local", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["local"];
                                    cmd.Parameters.Add("@diarioid", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["diarioid"];
                                    cmd.Parameters.Add("@asiento", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["asiento"];
                                    cmd.Parameters.Add("@asientoitems", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["asientoitems"];
                                    cmd.Parameters.Add("@fechregistro", SqlDbType.DateTime).Value = Detalle.Rows[lccontdetalle]["fechregistro"];
                                    cmd.Parameters.Add("@cuentaid", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["cuentaid"];
                                    cmd.Parameters.Add("@debehaber", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["debehaber"];
                                    cmd.Parameters.Add("@tipdoc", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["tipdoc"];
                                    cmd.Parameters.Add("@serdoc", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["serdoc"];
                                    cmd.Parameters.Add("@numdoc", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["numdoc"];
                                    cmd.Parameters.Add("@mediopago", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["mediopago"];
                                    cmd.Parameters.Add("@numdocpago", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["numdocpago"];
                                    cmd.Parameters.Add("@ctacte", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["ctacte"];
                                    cmd.Parameters.Add("@nmruc", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["nmruc"];
                                    cmd.Parameters.Add("@ctactename", SqlDbType.VarChar).Value = Detalle.Rows[lccontdetalle]["ctactename"];
                                    cmd.Parameters.Add("@saldo_si", SqlDbType.Decimal).Value = 0;
                                    if (Detalle.Rows[lccontdetalle]["debehaber"].ToString() == "D")
                                    {
                                        if (Detalle.Rows[lccontdetalle]["moneda"].ToString() == "1")
                                        {
                                            cmd.Parameters.Add("@cargo", SqlDbType.Decimal).Value = Detalle.Rows[lccontdetalle]["soles"];
                                        }
                                        else
                                        {
                                            cmd.Parameters.Add("@cargo", SqlDbType.Decimal).Value = Detalle.Rows[lccontdetalle]["dolares"];
                                        }
                                    }
                                    else
                                    {
                                        cmd.Parameters.Add("@cargo", SqlDbType.Decimal).Value = 0;
                                    }
                                    if (Detalle.Rows[lccontdetalle]["debehaber"].ToString() == "H")
                                    {
                                        if (Detalle.Rows[lccontdetalle]["moneda"].ToString() == "1")
                                        {
                                            cmd.Parameters.Add("@abono", SqlDbType.Decimal).Value = Detalle.Rows[lccontdetalle]["soles"];
                                        }
                                        else
                                        {
                                            cmd.Parameters.Add("@abono", SqlDbType.Decimal).Value = Detalle.Rows[lccontdetalle]["dolares"];
                                        }
                                    }
                                    else
                                    {
                                        cmd.Parameters.Add("@abono", SqlDbType.Decimal).Value = 0;
                                    }
                                    //cmd.Parameters.Add("@cargo", SqlDbType.Decimal).Value = (Detalle.Rows[lccontdetalle]["debehaber"].ToString() == "D" | Detalle.Rows[lccontdetalle]["moneda"].ToString() == "1" ? Detalle.Rows[lccontdetalle]["soles"] : Detalle.Rows[lccontdetalle]["dolares"]);
                                    //cmd.Parameters.Add("@abono", SqlDbType.Decimal).Value = (Detalle.Rows[lccontdetalle]["debehaber"].ToString() == "H" | Detalle.Rows[lccontdetalle]["moneda"].ToString() == "1" ? Detalle.Rows[lccontdetalle]["soles"] : Detalle.Rows[lccontdetalle]["dolares"]);
                                    cmd.Parameters.Add("@saldo", SqlDbType.Decimal).Value = 0;
                                    cmd.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = Detalle.Rows[lccontdetalle]["tipcamb"];
                                    cmd.Parameters.Add("@moneda", SqlDbType.Char).Value = Detalle.Rows[lccontdetalle]["moneda"];
                                    cmd.Parameters.Add("@es_conciliado", SqlDbType.Bit).Value = false;
                                    cmd.Parameters.Add("@es_manual", SqlDbType.Bit).Value = false;
                                    cmd.Parameters.Add("@es_otroperiodo", SqlDbType.Bit).Value = false;
                                    //cmd.Parameters.Add("@fechextracto", SqlDbType.DateTime).Value = Detalle.Rows[lccontdetalle]["fechextracto"];
                                    cmd.Parameters.Add("@glosa", SqlDbType.VarChar).Value = Detalle.Rows[lccontdetalle]["glosa"];
                                    cmd.Parameters.Add("@usuar", SqlDbType.Char).Value = BE.Usuar.Trim();
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
                }
                return xreturn;
            }
        }

        public DataSet ConciliacionBancariaSaldoAnterior(string empresaid, tb_co_conciliacionbancaria BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientos_ConciliacionBancariaSaldoAnterior", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@fechaini", System.Data.SqlDbType.DateTime).Value = BE.Fechaini;
                        cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = BE.Fechafin; 
                        cmd.Parameters.AddWithValue("@cuentaid", string.IsNullOrEmpty(BE.Cuentaid) ? (object)DBNull.Value : BE.Cuentaid);
                        cmd.Parameters.AddWithValue("@moneda", string.IsNullOrEmpty(BE.Moneda) ? (object)DBNull.Value : BE.Moneda);
                        cmd.Parameters.AddWithValue("@es_conciliado", SqlDbType.Bit).Value = BE.EsConciliado;
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
    }
}
