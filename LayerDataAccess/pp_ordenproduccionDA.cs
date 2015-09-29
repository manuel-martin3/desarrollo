using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class pp_ordenproduccionDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_pp_ordenproduccion BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                SqlTransaction tr = default(SqlTransaction);
                Boolean TransaExito = false;

                using (SqlCommand cmd1 = new SqlCommand("gspTbPpOrdenproduccioncab_INSERT", cnx))
                {
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@dominioid", SqlDbType.Char, 2).Value = BE.dominioid;
                    cmd1.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd1.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd1.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                    cmd1.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd1.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd1.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                    cmd1.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd1.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                    cmd1.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                    cmd1.Parameters.Add("@direcnume", SqlDbType.Char, 3).Value = BE.direcnume;
                    cmd1.Parameters.Add("@direcname", SqlDbType.VarChar, 25).Value = BE.direcname;
                    cmd1.Parameters.Add("@direcdeta", SqlDbType.VarChar, 70).Value = BE.direcdeta;
                    cmd1.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                    cmd1.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                    cmd1.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                    cmd1.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE.fechref;
                    cmd1.Parameters.Add("@fechaini", SqlDbType.DateTime).Value = BE.fechaini;
                    cmd1.Parameters.Add("@fechafin", SqlDbType.DateTime).Value = BE.fechafin;
                    cmd1.Parameters.Add("@lineaid", SqlDbType.Char, 2).Value = BE.lineaid;
                    cmd1.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE.marcaid;
                    cmd1.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
                    cmd1.Parameters.Add("@articname", SqlDbType.Char, 50).Value = BE.articname;
                    cmd1.Parameters.Add("@items", SqlDbType.Decimal).Value = BE.items; //*itemscab
                    cmd1.Parameters.Add("@totpzas", SqlDbType.Decimal).Value = BE.totpzas;
                    cmd1.Parameters.Add("@totpzas1ra", SqlDbType.Decimal).Value = BE.totpzas1ra;
                    cmd1.Parameters.Add("@totpzas2da", SqlDbType.Decimal).Value = BE.totpzas2da;
                    cmd1.Parameters.Add("@totpzasmerma", SqlDbType.Decimal).Value = BE.totpzasmerma;
                    cmd1.Parameters.Add("@totpzaspend", SqlDbType.Decimal).Value = BE.totpzaspend;
                    cmd1.Parameters.Add("@fech_pri_aten", SqlDbType.DateTime).Value = BE.fech_pri_aten;
                    cmd1.Parameters.Add("@fech_ult_aten", SqlDbType.DateTime).Value = BE.fech_ult_aten;
                    cmd1.Parameters.Add("@costoestimado", SqlDbType.Decimal).Value = BE.costoestimado;
                    cmd1.Parameters.Add("@costoreal", SqlDbType.Decimal).Value = BE.costoreal;
                    cmd1.Parameters.Add("@responsable", SqlDbType.VarChar, 40).Value = BE.responsable;
                    cmd1.Parameters.Add("@user_apr1", SqlDbType.Char, 15).Value = BE.user_apr1;
                    cmd1.Parameters.Add("@fech_apr1", SqlDbType.DateTime).Value = BE.fech_apr1;
                    cmd1.Parameters.Add("@user_apr2", SqlDbType.Char, 15).Value = BE.user_apr2;
                    cmd1.Parameters.Add("@fech_apr2", SqlDbType.DateTime).Value = BE.fech_apr2;
                    cmd1.Parameters.Add("@canalventaref", SqlDbType.Char, 9).Value = BE.canalventaref;
                    cmd1.Parameters.Add("@glosa", SqlDbType.Text).Value = BE.glosa;
                    cmd1.Parameters.Add("@faseactual", SqlDbType.Char, 2).Value = BE.faseactual;
                    cmd1.Parameters.Add("@fasesrealizadas", SqlDbType.Int).Value = BE.fasesrealizadas;
                    cmd1.Parameters.Add("@faseactualpzas", SqlDbType.Decimal).Value = BE.faseactualpzas;
                    cmd1.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd1.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd1.Parameters.Add("@status_aprob", SqlDbType.Char, 1).Value = BE.status_aprob;
                    cmd1.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd1.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;


                    using (SqlCommand cmd2 = new SqlCommand("gspTbPpOrdenproducciondet_INSERT_xml", cnx))
                    {
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd2.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd2.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd2.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd2.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd2.Parameters.Add("@XML", SqlDbType.Xml).Value = BE.GetItemXML();

                        try
                        {
                            cnx.Open();
                            tr = cnx.BeginTransaction(IsolationLevel.Serializable);
                            cmd1.Transaction = tr;

                            if (cmd1.ExecuteNonQuery() > 0)
                            {
                                cmd2.Transaction = tr;

                                if (cmd2.ExecuteNonQuery() > 0)
                                {
                                    TransaExito = true;
                                }
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
        }

        public bool Update(string empresaid, tb_pp_ordenproduccion BE1, tb_pp_ordenproduccion BE2)
        {
            //BE1: detalle del documento modificado
            //BE2: detalle del documento original

            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                SqlTransaction tr = default(SqlTransaction);
                Boolean TransaExito = false;

                using (SqlCommand cmd1 = new SqlCommand("gspTbPpOrdenproduccioncab_UPDATE", cnx))
                {
                    cmd1.CommandType = CommandType.StoredProcedure;
                    //cmd1.Parameters.Add("@dominioid", SqlDbType.Char, 2).Value = BE1.dominioid;
                    cmd1.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE1.moduloid;
                    cmd1.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE1.local;
                    cmd1.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE1.tipodoc;
                    cmd1.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE1.serdoc;
                    cmd1.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE1.numdoc;
                    cmd1.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE1.fechdoc;
                    cmd1.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE1.ctacte;
                    cmd1.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE1.nmruc;
                    cmd1.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE1.ctactename;
                    cmd1.Parameters.Add("@direcnume", SqlDbType.Char, 3).Value = BE1.direcnume;
                    cmd1.Parameters.Add("@direcname", SqlDbType.VarChar, 25).Value = BE1.direcname;
                    cmd1.Parameters.Add("@direcdeta", SqlDbType.VarChar, 70).Value = BE1.direcdeta;
                    cmd1.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE1.tipref;
                    cmd1.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE1.serref;
                    cmd1.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE1.numref;
                    cmd1.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE1.fechref;
                    cmd1.Parameters.Add("@fechaini", SqlDbType.DateTime).Value = BE1.fechaini;
                    cmd1.Parameters.Add("@fechafin", SqlDbType.DateTime).Value = BE1.fechafin;
                    cmd1.Parameters.Add("@lineaid", SqlDbType.Char, 2).Value = BE1.lineaid;
                    cmd1.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE1.marcaid;
                    cmd1.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE1.articid;
                    cmd1.Parameters.Add("@articname", SqlDbType.Char, 50).Value = BE1.articname;
                    cmd1.Parameters.Add("@items", SqlDbType.Decimal).Value = BE1.items; //*itemscab
                    cmd1.Parameters.Add("@totpzas", SqlDbType.Decimal).Value = BE1.totpzas;
                    cmd1.Parameters.Add("@totpzas1ra", SqlDbType.Decimal).Value = BE1.totpzas1ra;
                    cmd1.Parameters.Add("@totpzas2da", SqlDbType.Decimal).Value = BE1.totpzas2da;
                    cmd1.Parameters.Add("@totpzasmerma", SqlDbType.Decimal).Value = BE1.totpzasmerma;
                    cmd1.Parameters.Add("@totpzaspend", SqlDbType.Decimal).Value = BE1.totpzaspend;
                    cmd1.Parameters.Add("@fech_pri_aten", SqlDbType.DateTime).Value = BE1.fech_pri_aten;
                    cmd1.Parameters.Add("@fech_ult_aten", SqlDbType.DateTime).Value = BE1.fech_ult_aten;
                    cmd1.Parameters.Add("@costoestimado", SqlDbType.Decimal).Value = BE1.costoestimado;
                    cmd1.Parameters.Add("@costoreal", SqlDbType.Decimal).Value = BE1.costoreal;
                    cmd1.Parameters.Add("@responsable", SqlDbType.VarChar, 40).Value = BE1.responsable;
                    cmd1.Parameters.Add("@user_apr1", SqlDbType.Char, 15).Value = BE1.user_apr1;
                    cmd1.Parameters.Add("@fech_apr1", SqlDbType.DateTime).Value = BE1.fech_apr1;
                    cmd1.Parameters.Add("@user_apr2", SqlDbType.Char, 15).Value = BE1.user_apr2;
                    cmd1.Parameters.Add("@fech_apr2", SqlDbType.DateTime).Value = BE1.fech_apr2;
                    cmd1.Parameters.Add("@canalventaref", SqlDbType.Char, 9).Value = BE1.canalventaref;
                    cmd1.Parameters.Add("@glosa", SqlDbType.Text).Value = BE1.glosa;
                    cmd1.Parameters.Add("@faseactual", SqlDbType.Char, 2).Value = BE1.faseactual;
                    cmd1.Parameters.Add("@fasesrealizadas", SqlDbType.Int).Value = BE1.fasesrealizadas;
                    cmd1.Parameters.Add("@faseactualpzas", SqlDbType.Decimal).Value = BE1.faseactualpzas;
                    cmd1.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE1.perianio;
                    cmd1.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE1.perimes;
                    cmd1.Parameters.Add("@status_aprob", SqlDbType.Char, 1).Value = BE1.status_aprob;
                    cmd1.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE1.status;
                    cmd1.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE1.usuar;

                    using (SqlCommand cmd2 = new SqlCommand("gspTbPpOrdenproducciondet_DELETE_xml", cnx))
                    {
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE2.moduloid;
                        cmd2.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE2.local;
                        cmd2.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE2.tipodoc;
                        cmd2.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE2.serdoc;
                        cmd2.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE2.numdoc;
                        cmd2.Parameters.Add("@XML", SqlDbType.Xml).Value = BE2.GetItemXML2();

                        using (SqlCommand cmd3 = new SqlCommand("gspTbPpOrdenproducciondet_INSERT_xml", cnx))
                        {
                            cmd3.CommandType = CommandType.StoredProcedure;
                            cmd3.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE1.moduloid;
                            cmd3.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE1.local;
                            cmd3.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE1.tipodoc;
                            cmd3.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE1.serdoc;
                            cmd3.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE1.numdoc;
                            cmd3.Parameters.Add("@XML", SqlDbType.Xml).Value = BE1.GetItemXML();

                            try
                            {
                                cnx.Open();
                                tr = cnx.BeginTransaction(IsolationLevel.Serializable);
                                cmd1.Transaction = tr;

                                if (cmd1.ExecuteNonQuery() > 0)
                                {
                                    cmd2.Transaction = tr;

                                    if (cmd2.ExecuteNonQuery() > 0)
                                    {
                                        cmd3.Transaction = tr;

                                        if (cmd3.ExecuteNonQuery() > 0)
                                        {
                                            TransaExito = true;
                                        }
                                    }
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
            }
        }

        public bool Update_aprobado(string empresaid, tb_pp_ordenproduccion BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                SqlTransaction tr = default(SqlTransaction);
                Boolean TransaExito = false;


                using (SqlCommand cmd1 = new SqlCommand("gspTbPtMovimientoscab_UPDATE_aprobado", cnx))
                {
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@moduloid", SqlDbType.Char, 2).Value = BE.moduloid;
                    cmd1.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd1.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                    cmd1.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd1.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd1.Parameters.Add("@user_apr1", SqlDbType.Char, 15).Value = BE.user_apr1;
                    cmd1.Parameters.Add("@fech_apr1", SqlDbType.DateTime).Value = BE.fech_apr1;
                    cmd1.Parameters.Add("@status_aprob", SqlDbType.Char, 1).Value = BE.status_aprob;
                    cmd1.Parameters.Add("@glosa", SqlDbType.Text).Value = BE.glosa;

                    using (SqlCommand cmd2 = new SqlCommand("gspTbPtMovimientosdet_UPDATE_aprobado", cnx))
                    {
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.Add("@moduloid", SqlDbType.Char, 2).Value = BE.moduloid;
                        cmd2.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd2.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd2.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd2.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd2.Parameters.Add("@user_apr1", SqlDbType.Char, 15).Value = BE.user_apr1;
                        cmd2.Parameters.Add("@fech_apr1", SqlDbType.DateTime).Value = BE.fech_apr1;
                        cmd2.Parameters.Add("@status_aprob", SqlDbType.Char, 1).Value = BE.status_aprob;
                        cmd2.Parameters.Add("@glosa", SqlDbType.Text).Value = BE.glosa;

                        try
                        {
                            cnx.Open();
                            tr = cnx.BeginTransaction(IsolationLevel.Serializable);
                            cmd1.Transaction = tr;

                            if (cmd1.ExecuteNonQuery() > 0)
                            {
                                cmd2.Transaction = tr;

                                if (cmd2.ExecuteNonQuery() > 0)
                                {
                                    TransaExito = true;
                                }
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
        }

        public bool Delete(string empresaid, tb_pp_ordenproduccion BE2)
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
                    cmd1.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE2.moduloid;
                    cmd1.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE2.local;
                    cmd1.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE2.tipodoc;
                    cmd1.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE2.serdoc;
                    cmd1.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE2.numdoc;
                    cmd1.Parameters.Add("@XML", SqlDbType.Xml).Value = BE2.GetItemXML2();

                    using (SqlCommand cmd2 = new SqlCommand("gspTbPpOrdenproduccioncab_ANULAR", cnx))
                    {
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE2.moduloid;
                        cmd2.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE2.local;
                        cmd2.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE2.tipodoc;
                        cmd2.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE2.serdoc;
                        cmd2.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE2.numdoc;

                        try
                        {
                            cnx.Open();
                            tr = cnx.BeginTransaction(IsolationLevel.Serializable);
                            cmd1.Transaction = tr;

                            if (cmd1.ExecuteNonQuery() > 0)
                            {
                                cmd2.Transaction = tr;

                                if (cmd2.ExecuteNonQuery() > 0)
                                {
                                    TransaExito = true;
                                }
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
        }

        public DataSet GetAll(string empresaid, tb_pp_ordenproduccioncab BE1)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {

                using (SqlCommand cmd1 = new SqlCommand("gspTbMpMovimientoscab_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE1.moduloid;
                        cmd1.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE1.local;
                        cmd1.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE1.tipodoc;
                        cmd1.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE1.serdoc;
                        cmd1.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE1.numdoc;
                        cmd1.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE1.ctacte;
                        cmd1.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE1.nmruc;
                        cmd1.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE1.ctactename;
                        cmd1.Parameters.Add("@direcnume", SqlDbType.Char, 3).Value = BE1.direcnume;
                        cmd1.Parameters.Add("@direcname", SqlDbType.VarChar, 25).Value = BE1.direcname;
                        cmd1.Parameters.Add("@direcdeta", SqlDbType.VarChar, 70).Value = BE1.direcdeta;
                        cmd1.Parameters.Add("@tipref", SqlDbType.Char, 1).Value = BE1.tipref;
                        cmd1.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE1.serref;
                        cmd1.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE1.numref;
                        cmd1.Parameters.Add("@lineaid", SqlDbType.Char, 2).Value = BE1.lineaid;
                        cmd1.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE1.marcaid;
                        cmd1.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE1.articid;
                        cmd1.Parameters.Add("@articname", SqlDbType.Char, 50).Value = BE1.articname;
                        cmd1.Parameters.Add("@responsable", SqlDbType.VarChar, 40).Value = BE1.responsable;
                        cmd1.Parameters.Add("@user_apr1", SqlDbType.Char, 15).Value = BE1.user_apr1;
                        cmd1.Parameters.Add("@user_apr2", SqlDbType.Char, 15).Value = BE1.user_apr2;
                        cmd1.Parameters.Add("@canalventaref", SqlDbType.Char, 9).Value = BE1.canalventaref;
                        cmd1.Parameters.Add("@glosa", SqlDbType.Text).Value = BE1.glosa;
                        cmd1.Parameters.Add("@faseactual", SqlDbType.Char, 2).Value = BE1.faseactual;
                        cmd1.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE1.perianio;
                        cmd1.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE1.perimes;
                        cmd1.Parameters.Add("@status_aprob", SqlDbType.Char, 1).Value = BE1.status_aprob;
                        cmd1.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE1.status;
                        cmd1.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE1.usuar;
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

        public DataSet GetOne(string empresaid, tb_pp_ordenproduccioncab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpMovimientoscab_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
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

        #region *** validar fecha en formato correcto
        public DateTime fecha(DateTime pfecha)
        {
            DateTime lfech;

            if (pfecha != null)
            {
                if (pfecha != DateTime.Parse("01/01/0001 12:00:00 a.m."))
                {
                    lfech = pfecha;
                }
                else
                {
                    lfech = DateTime.Parse(null);
                }
            }
            else
            {
                lfech = DateTime.Parse("01/01/1900");
            }
            return lfech;
        }

        public DateTime fecha_02(DateTime pfecha)
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
