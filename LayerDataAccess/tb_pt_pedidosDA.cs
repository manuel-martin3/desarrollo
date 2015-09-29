using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_pt_pedidosDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_pt_pedidos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                SqlTransaction tr = default(SqlTransaction);
                Boolean TransaExito = false;

                using (SqlCommand cmd1 = new SqlCommand("gspTbPtPedidoscab_INSERT", cnx))
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
                    cmd1.Parameters.Add("@direcnume", SqlDbType.Char, 6).Value = BE.direcnume;
                    cmd1.Parameters.Add("@direcname", SqlDbType.VarChar, 25).Value = BE.direcname;
                    cmd1.Parameters.Add("@direcdeta", SqlDbType.VarChar, 70).Value = BE.direcdeta;
                    cmd1.Parameters.Add("@direc", SqlDbType.VarChar, 70).Value = BE.direc;
                    cmd1.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE.almacaccionid;
                    cmd1.Parameters.Add("@ctacteaccionid", SqlDbType.Char, 2).Value = BE.ctacteaccionid;
                    cmd1.Parameters.Add("@tipdid", SqlDbType.Char, 1).Value = BE.tipdid;
                    cmd1.Parameters.Add("@tipref", SqlDbType.Char, 1).Value = BE.tipref;
                    cmd1.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                    cmd1.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                    cmd1.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE.fechref;
                    cmd1.Parameters.Add("@tip_op", SqlDbType.Char, 2).Value = BE.tip_op;
                    cmd1.Parameters.Add("@ser_op", SqlDbType.Char, 4).Value = BE.ser_op;
                    cmd1.Parameters.Add("@num_op", SqlDbType.Char, 10).Value = BE.num_op;
                    cmd1.Parameters.Add("@tipfac", SqlDbType.Char, 2).Value = BE.tipfac;
                    cmd1.Parameters.Add("@serfac", SqlDbType.Char, 4).Value = BE.serfac;
                    cmd1.Parameters.Add("@numfac", SqlDbType.Char, 10).Value = BE.numfac;
                    cmd1.Parameters.Add("@fechfac", SqlDbType.DateTime).Value = BE.fechfac;
                    cmd1.Parameters.Add("@tipguia", SqlDbType.Char, 2).Value = BE.tipguia;
                    cmd1.Parameters.Add("@serguia", SqlDbType.Char, 4).Value = BE.serguia;
                    cmd1.Parameters.Add("@numguia", SqlDbType.Char, 10).Value = BE.numguia;
                    cmd1.Parameters.Add("@fechguia", SqlDbType.DateTime).Value = BE.fechguia;
                    cmd1.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                    cmd1.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE.ubige;
                    cmd1.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                    cmd1.Parameters.Add("@dscto3", SqlDbType.Decimal).Value = BE.dscto3;
                    cmd1.Parameters.Add("@totdscto1", SqlDbType.Decimal).Value = BE.totdscto1;
                    cmd1.Parameters.Add("@totdscto2", SqlDbType.Decimal).Value = BE.totdscto2;
                    cmd1.Parameters.Add("@totdscto3", SqlDbType.Decimal).Value = BE.totdscto3;
                    cmd1.Parameters.Add("@condpago", SqlDbType.Char, 4).Value = BE.condpago;
                    cmd1.Parameters.Add("@transporte", SqlDbType.Decimal).Value = BE.transporte;
                    cmd1.Parameters.Add("@embalaje", SqlDbType.Decimal).Value = BE.embalaje;
                    cmd1.Parameters.Add("@otros", SqlDbType.Decimal).Value = BE.otros;
                    cmd1.Parameters.Add("@tipimptoid", SqlDbType.Char, 1).Value = BE.tipimptoid;
                    cmd1.Parameters.Add("@igv", SqlDbType.Decimal).Value = BE.igv;
                    cmd1.Parameters.Add("@incprec", SqlDbType.Char, 1).Value = BE.incprec;
                    cmd1.Parameters.Add("@tipoperimptoid", SqlDbType.Char, 1).Value = BE.tipoperimptoid;
                    cmd1.Parameters.Add("@abono", SqlDbType.Decimal).Value = BE.abono;
                    cmd1.Parameters.Add("@cargo", SqlDbType.Decimal).Value = BE.cargo;
                    cmd1.Parameters.Add("@tcamb", SqlDbType.Decimal).Value = BE.tcamb;
                    cmd1.Parameters.Add("@fechentrega", SqlDbType.DateTime).Value = BE.fechentrega;
                    cmd1.Parameters.Add("@fechpago", SqlDbType.DateTime).Value = BE.fechpago;
                    cmd1.Parameters.Add("@fechcancel", SqlDbType.DateTime).Value = BE.fechcancel;
                    cmd1.Parameters.Add("@moneda", SqlDbType.Char).Value = BE.moneda;
                    cmd1.Parameters.Add("@statborrado", SqlDbType.Char, 1).Value = BE.statborrado;
                    cmd1.Parameters.Add("@transpid", SqlDbType.Char, 5).Value = BE.transpid;
                    cmd1.Parameters.Add("@transpnume", SqlDbType.VarChar, 40).Value = BE.transpnume;
                    cmd1.Parameters.Add("@transnmruc", SqlDbType.Char, 11).Value = BE.transnmruc;
                    cmd1.Parameters.Add("@placa", SqlDbType.VarChar, 50).Value = BE.placa;
                    cmd1.Parameters.Add("@certificado", SqlDbType.VarChar, 50).Value = BE.certificado;
                    cmd1.Parameters.Add("@licencia", SqlDbType.Char, 11).Value = BE.licencia;
                    cmd1.Parameters.Add("@motivotrasladoid", SqlDbType.Char, 1).Value = BE.motivotrasladoid;
                    cmd1.Parameters.Add("@modofactu", SqlDbType.Char, 1).Value = BE.modofactu;
                    cmd1.Parameters.Add("@clientetipo", SqlDbType.Char, 1).Value = BE.clientetipo;
                    cmd1.Parameters.Add("@ddnni", SqlDbType.Char, 8).Value = BE.ddnni;
                    cmd1.Parameters.Add("@items", SqlDbType.Decimal).Value = BE.items; //*itemscab
                    cmd1.Parameters.Add("@totimpto", SqlDbType.Decimal).Value = BE.totimpto;
                    cmd1.Parameters.Add("@valventa", SqlDbType.Decimal).Value = BE.valventa;
                    cmd1.Parameters.Add("@bruto", SqlDbType.Decimal).Value = BE.bruto;
                    cmd1.Parameters.Add("@totimporte", SqlDbType.Decimal).Value = BE.totimporte;
                    cmd1.Parameters.Add("@totpzas", SqlDbType.Decimal).Value = BE.totpzas;
                    cmd1.Parameters.Add("@fech_aten", SqlDbType.DateTime).Value = BE.fech_aten;
                    cmd1.Parameters.Add("@docu_aten", SqlDbType.Char, 16).Value = BE.docu_aten;
                    cmd1.Parameters.Add("@cantidadcta", SqlDbType.Decimal).Value = BE.cantidadcta;
                    cmd1.Parameters.Add("@cant_pend", SqlDbType.Decimal).Value = BE.cant_pend;
                    cmd1.Parameters.Add("@impo_aten", SqlDbType.Decimal).Value = BE.impo_aten;
                    cmd1.Parameters.Add("@impo_pend", SqlDbType.Decimal).Value = BE.impo_pend;
                    cmd1.Parameters.Add("@user_apr1", SqlDbType.Char, 10).Value = BE.user_apr1;
                    cmd1.Parameters.Add("@fech_apr1", SqlDbType.DateTime).Value = BE.fech_apr1;
                    cmd1.Parameters.Add("@user_apr2", SqlDbType.Char, 10).Value = BE.user_apr2;
                    cmd1.Parameters.Add("@fech_apr2", SqlDbType.DateTime).Value = BE.fech_apr2;
                    cmd1.Parameters.Add("@canalventaref", SqlDbType.Char, 9).Value = BE.canalventaref;
                    cmd1.Parameters.Add("@glosaenvio", SqlDbType.VarChar, 300).Value = BE.glosaenvio;
                    cmd1.Parameters.Add("@glosacredi", SqlDbType.VarChar, 300).Value = BE.glosacredi;
                    cmd1.Parameters.Add("@codctadebe", SqlDbType.Char, 10).Value = BE.codctadebe;
                    cmd1.Parameters.Add("@codctahaber", SqlDbType.Char, 10).Value = BE.codctahaber;
                    cmd1.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd1.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd1.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd1.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;

                    using (SqlCommand cmd2 = new SqlCommand("gspTbPtPedidosdet_INSERT_xml", cnx))
                    {
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.Add("@dominioid", SqlDbType.Char, 2).Value = BE.dominioid;
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

        public bool Update(string empresaid, tb_pt_pedidos BE1, tb_pt_pedidos BE2)
        {
            //BE1: detalle del documento modificado
            //BE2: detalle del documento original

            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                SqlTransaction tr = default(SqlTransaction);
                Boolean TransaExito = false;

                using (SqlCommand cmd1 = new SqlCommand("gspTbPtPedidoscab_UPDATE", cnx))
                {
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@dominioid", SqlDbType.Char, 2).Value = BE1.dominioid;
                    cmd1.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE1.moduloid;
                    cmd1.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE1.local;
                    cmd1.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE1.tipodoc;
                    cmd1.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE1.serdoc;
                    cmd1.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE1.numdoc;
                    cmd1.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE1.fechdoc;
                    cmd1.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE1.ctacte;
                    cmd1.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE1.nmruc;
                    cmd1.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE1.ctactename;
                    cmd1.Parameters.Add("@direcnume", SqlDbType.Char, 6).Value = BE1.direcnume;
                    cmd1.Parameters.Add("@direcname", SqlDbType.VarChar, 25).Value = BE1.direcname;
                    cmd1.Parameters.Add("@direcdeta", SqlDbType.VarChar, 70).Value = BE1.direcdeta;
                    cmd1.Parameters.Add("@direc", SqlDbType.VarChar, 70).Value = BE1.direc;
                    cmd1.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE1.almacaccionid;
                    cmd1.Parameters.Add("@ctacteaccionid", SqlDbType.Char, 2).Value = BE1.ctacteaccionid;
                    cmd1.Parameters.Add("@tipdid", SqlDbType.Char, 1).Value = BE1.tipdid;
                    cmd1.Parameters.Add("@tipref", SqlDbType.Char, 1).Value = BE1.tipref;
                    cmd1.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE1.serref;
                    cmd1.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE1.numref;
                    cmd1.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE1.fechref;
                    cmd1.Parameters.Add("@tip_op", SqlDbType.Char, 2).Value = BE1.tip_op;
                    cmd1.Parameters.Add("@ser_op", SqlDbType.Char, 4).Value = BE1.ser_op;
                    cmd1.Parameters.Add("@num_op", SqlDbType.Char, 10).Value = BE1.num_op;
                    cmd1.Parameters.Add("@tipfac", SqlDbType.Char, 2).Value = BE1.tipfac;
                    cmd1.Parameters.Add("@serfac", SqlDbType.Char, 4).Value = BE1.serfac;
                    cmd1.Parameters.Add("@numfac", SqlDbType.Char, 10).Value = BE1.numfac;
                    cmd1.Parameters.Add("@fechfac", SqlDbType.DateTime).Value = BE1.fechfac;
                    cmd1.Parameters.Add("@tipguia", SqlDbType.Char, 2).Value = BE1.tipguia;
                    cmd1.Parameters.Add("@serguia", SqlDbType.Char, 4).Value = BE1.serguia;
                    cmd1.Parameters.Add("@numguia", SqlDbType.Char, 10).Value = BE1.numguia;
                    cmd1.Parameters.Add("@fechguia", SqlDbType.DateTime).Value = BE1.fechguia;
                    cmd1.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE1.vendorid;
                    cmd1.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE1.ubige;
                    cmd1.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE1.cencosid;
                    cmd1.Parameters.Add("@dscto3", SqlDbType.Decimal).Value = BE1.dscto3;
                    cmd1.Parameters.Add("@totdscto1", SqlDbType.Decimal).Value = BE1.totdscto1;
                    cmd1.Parameters.Add("@totdscto2", SqlDbType.Decimal).Value = BE1.totdscto2;
                    cmd1.Parameters.Add("@totdscto3", SqlDbType.Decimal).Value = BE1.totdscto3;
                    cmd1.Parameters.Add("@condpago", SqlDbType.Char, 4).Value = BE1.condpago;
                    cmd1.Parameters.Add("@transporte", SqlDbType.Decimal).Value = BE1.transporte;
                    cmd1.Parameters.Add("@embalaje", SqlDbType.Decimal).Value = BE1.embalaje;
                    cmd1.Parameters.Add("@otros", SqlDbType.Decimal).Value = BE1.otros;
                    cmd1.Parameters.Add("@tipimptoid", SqlDbType.Char, 1).Value = BE1.tipimptoid;
                    cmd1.Parameters.Add("@igv", SqlDbType.Decimal).Value = BE1.igv;
                    cmd1.Parameters.Add("@incprec", SqlDbType.Char, 1).Value = BE1.incprec;
                    cmd1.Parameters.Add("@tipoperimptoid", SqlDbType.Char, 1).Value = BE1.tipoperimptoid;
                    cmd1.Parameters.Add("@abono", SqlDbType.Decimal).Value = BE1.abono;
                    cmd1.Parameters.Add("@cargo", SqlDbType.Decimal).Value = BE1.cargo;
                    cmd1.Parameters.Add("@tcamb", SqlDbType.Decimal).Value = BE1.tcamb;
                    cmd1.Parameters.Add("@fechentrega", SqlDbType.DateTime).Value = BE1.fechentrega;
                    cmd1.Parameters.Add("@fechpago", SqlDbType.DateTime).Value = BE1.fechpago;
                    cmd1.Parameters.Add("@fechcancel", SqlDbType.DateTime).Value = BE1.fechcancel;
                    cmd1.Parameters.Add("@moneda", SqlDbType.Char).Value = BE1.moneda;
                    cmd1.Parameters.Add("@statborrado", SqlDbType.Char, 1).Value = BE1.statborrado;
                    cmd1.Parameters.Add("@transpid", SqlDbType.Char, 5).Value = BE1.transpid;
                    cmd1.Parameters.Add("@transpnume", SqlDbType.VarChar, 40).Value = BE1.transpnume;
                    cmd1.Parameters.Add("@transnmruc", SqlDbType.Char, 11).Value = BE1.transnmruc;
                    cmd1.Parameters.Add("@placa", SqlDbType.VarChar, 50).Value = BE1.placa;
                    cmd1.Parameters.Add("@certificado", SqlDbType.VarChar, 50).Value = BE1.certificado;
                    cmd1.Parameters.Add("@licencia", SqlDbType.Char, 11).Value = BE1.licencia;
                    cmd1.Parameters.Add("@motivotrasladoid", SqlDbType.Char, 1).Value = BE1.motivotrasladoid;
                    cmd1.Parameters.Add("@modofactu", SqlDbType.Char, 1).Value = BE1.modofactu;
                    cmd1.Parameters.Add("@clientetipo", SqlDbType.Char, 1).Value = BE1.clientetipo;
                    cmd1.Parameters.Add("@ddnni", SqlDbType.Char, 8).Value = BE1.ddnni;
                    cmd1.Parameters.Add("@items", SqlDbType.Decimal).Value = BE1.items; //*itemscab
                    cmd1.Parameters.Add("@totimpto", SqlDbType.Decimal).Value = BE1.totimpto;
                    cmd1.Parameters.Add("@valventa", SqlDbType.Decimal).Value = BE1.valventa;
                    cmd1.Parameters.Add("@bruto", SqlDbType.Decimal).Value = BE1.bruto;
                    cmd1.Parameters.Add("@totimporte", SqlDbType.Decimal).Value = BE1.totimporte;
                    cmd1.Parameters.Add("@totpzas", SqlDbType.Decimal).Value = BE1.totpzas;
                    cmd1.Parameters.Add("@fech_aten", SqlDbType.DateTime).Value = BE1.fech_aten;
                    cmd1.Parameters.Add("@docu_aten", SqlDbType.Char, 16).Value = BE1.docu_aten;
                    cmd1.Parameters.Add("@cantidadcta", SqlDbType.Decimal).Value = BE1.cantidadcta;
                    cmd1.Parameters.Add("@cant_pend", SqlDbType.Decimal).Value = BE1.cant_pend;
                    cmd1.Parameters.Add("@impo_aten", SqlDbType.Decimal).Value = BE1.impo_aten;
                    cmd1.Parameters.Add("@impo_pend", SqlDbType.Decimal).Value = BE1.impo_pend;
                    cmd1.Parameters.Add("@user_apr1", SqlDbType.Char, 10).Value = BE1.user_apr1;
                    cmd1.Parameters.Add("@fech_apr1", SqlDbType.DateTime).Value = BE1.fech_apr1;
                    cmd1.Parameters.Add("@user_apr2", SqlDbType.Char, 10).Value = BE1.user_apr2;
                    cmd1.Parameters.Add("@fech_apr2", SqlDbType.DateTime).Value = BE1.fech_apr2;
                    cmd1.Parameters.Add("@canalventaref", SqlDbType.Char, 9).Value = BE1.canalventaref;
                    cmd1.Parameters.Add("@glosaenvio", SqlDbType.VarChar, 300).Value = BE1.glosaenvio;
                    cmd1.Parameters.Add("@glosacredi", SqlDbType.VarChar, 300).Value = BE1.glosacredi;
                    cmd1.Parameters.Add("@codctadebe", SqlDbType.Char, 10).Value = BE1.codctadebe;
                    cmd1.Parameters.Add("@codctahaber", SqlDbType.Char, 10).Value = BE1.codctahaber;
                    cmd1.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE1.perianio;
                    cmd1.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE1.perimes;
                    cmd1.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE1.status;
                    cmd1.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE1.usuar;

                    using (SqlCommand cmd2 = new SqlCommand("gspTbPtPedidosdet_DELETE_xml", cnx))
                    {
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE2.moduloid;
                        cmd2.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE2.local;
                        cmd2.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE2.tipodoc;
                        cmd2.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE2.serdoc;
                        cmd2.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE2.numdoc;
                        cmd2.Parameters.Add("@XML", SqlDbType.Xml).Value = BE2.GetItemXML2();

                        using (SqlCommand cmd3 = new SqlCommand("gspTbPtPedidosdet_INSERT_xml2", cnx))
                        {
                            cmd3.CommandType = CommandType.StoredProcedure;
                            cmd3.Parameters.Add("@dominioid", SqlDbType.Char, 2).Value = BE1.dominioid;
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

        public bool Update_aprobado(string empresaid, tb_pt_pedidos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                SqlTransaction tr = default(SqlTransaction);
                Boolean TransaExito = false;


                using (SqlCommand cmd1 = new SqlCommand("gspTbPtPedidoscab_UPDATE_aprobado", cnx))
                {
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd1.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd1.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                    cmd1.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd1.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd1.Parameters.Add("@user_apr1", SqlDbType.Char, 15).Value = BE.user_apr1;
                    cmd1.Parameters.Add("@fech_apr1", SqlDbType.DateTime).Value = BE.fech_apr1;
                    cmd1.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd1.Parameters.Add("@glosacredi", SqlDbType.VarChar, 300).Value = BE.glosacredi;

                        try
                        {
                            cnx.Open();
                            tr = cnx.BeginTransaction(IsolationLevel.Serializable);
                            cmd1.Transaction = tr;

                            if (cmd1.ExecuteNonQuery() > 0)
                            {
                                    TransaExito = true;
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

        public bool Delete(string empresaid, tb_pt_pedidos BE2)
        {
            //BE1: ingresa datos en tabla tb_pt_pedidosdet_delete
            //BE2: elimina datos de tabla tb_pt_pedidosdet

            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                SqlTransaction tr = default(SqlTransaction);
                Boolean TransaExito = false;

                using (SqlCommand cmd1 = new SqlCommand("gspTbPtPedidosdet_DELETE_xml", cnx))
                {
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE2.moduloid;
                    cmd1.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE2.local;
                    cmd1.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE2.tipodoc;
                    cmd1.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE2.serdoc;
                    cmd1.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE2.numdoc;
                    cmd1.Parameters.Add("@XML", SqlDbType.Xml).Value = BE2.GetItemXML2();

                    using (SqlCommand cmd2 = new SqlCommand("gspTbPtPedidoscab_DELETE", cnx))
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

        public DataSet GetAll(string empresaid, tb_pt_pedidoscab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {

                using (SqlCommand cmd1 = new SqlCommand("gspTbMpMovimientoscab_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd1.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd1.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd1.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd1.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd1.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                        cmd1.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd1.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                        cmd1.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                        cmd1.Parameters.Add("@direcnume", SqlDbType.Char, 6).Value = BE.direcnume;
                        cmd1.Parameters.Add("@direcname", SqlDbType.VarChar, 25).Value = BE.direcname;
                        cmd1.Parameters.Add("@direcdeta", SqlDbType.VarChar, 70).Value = BE.direcdeta;
                        cmd1.Parameters.Add("@direc", SqlDbType.VarChar, 70).Value = BE.direc;
                        cmd1.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE.almacaccionid;
                        cmd1.Parameters.Add("@ctacteaccionid", SqlDbType.Char, 2).Value = BE.ctacteaccionid;
                        cmd1.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE.almacaccionid;
                        cmd1.Parameters.Add("@ctacteaccionid", SqlDbType.Char, 2).Value = BE.ctacteaccionid;
                        cmd1.Parameters.Add("@tipdid", SqlDbType.Char, 1).Value = BE.tipdid;
                        cmd1.Parameters.Add("@tipref", SqlDbType.Char, 1).Value = BE.tipref;
                        cmd1.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                        cmd1.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                        cmd1.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE.fechref;
                        cmd1.Parameters.Add("@tip_op", SqlDbType.Char, 2).Value = BE.tip_op;
                        cmd1.Parameters.Add("@ser_op", SqlDbType.Char, 4).Value = BE.ser_op;
                        cmd1.Parameters.Add("@num_op", SqlDbType.Char, 10).Value = BE.num_op;
                        cmd1.Parameters.Add("@tipfac", SqlDbType.Char, 2).Value = BE.tipfac;
                        cmd1.Parameters.Add("@serfac", SqlDbType.Char, 4).Value = BE.serfac;
                        cmd1.Parameters.Add("@numfac", SqlDbType.Char, 10).Value = BE.numfac;
                        cmd1.Parameters.Add("@fechfac", SqlDbType.DateTime).Value = BE.fechfac;
                        cmd1.Parameters.Add("@tipguia", SqlDbType.Char, 2).Value = BE.tipguia;
                        cmd1.Parameters.Add("@serguia", SqlDbType.Char, 4).Value = BE.serguia;
                        cmd1.Parameters.Add("@numguia", SqlDbType.Char, 10).Value = BE.numguia;
                        cmd1.Parameters.Add("@fechguia", SqlDbType.DateTime).Value = BE.fechguia;
                        cmd1.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                        cmd1.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE.ubige;
                        cmd1.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                        cmd1.Parameters.Add("@dscto3", SqlDbType.Decimal).Value = BE.dscto3;
                        cmd1.Parameters.Add("@totdscto1", SqlDbType.Decimal).Value = BE.totdscto1;
                        cmd1.Parameters.Add("@totdscto2", SqlDbType.Decimal).Value = BE.totdscto2;
                        cmd1.Parameters.Add("@totdscto3", SqlDbType.Decimal).Value = BE.totdscto3;
                        cmd1.Parameters.Add("@condpago", SqlDbType.Char, 4).Value = BE.condpago;
                        cmd1.Parameters.Add("@transporte", SqlDbType.Decimal).Value = BE.transporte;
                        cmd1.Parameters.Add("@embalaje", SqlDbType.Decimal).Value = BE.embalaje;
                        cmd1.Parameters.Add("@otros", SqlDbType.Decimal).Value = BE.otros;
                        cmd1.Parameters.Add("@tipimptoid", SqlDbType.Char, 1).Value = BE.tipimptoid;
                        cmd1.Parameters.Add("@igv", SqlDbType.Decimal).Value = BE.igv;
                        cmd1.Parameters.Add("@incprec", SqlDbType.Char, 1).Value = BE.incprec;
                        cmd1.Parameters.Add("@tipoperimptoid", SqlDbType.Char, 1).Value = BE.tipoperimptoid;
                        cmd1.Parameters.Add("@abono", SqlDbType.Decimal).Value = BE.abono;
                        cmd1.Parameters.Add("@cargo", SqlDbType.Decimal).Value = BE.cargo;
                        cmd1.Parameters.Add("@tcamb", SqlDbType.Decimal).Value = BE.tcamb;
                        cmd1.Parameters.Add("@fechentrega", SqlDbType.DateTime).Value = BE.fechentrega;
                        cmd1.Parameters.Add("@fechpago", SqlDbType.DateTime).Value = BE.fechpago;
                        cmd1.Parameters.Add("@fechcancel", SqlDbType.DateTime).Value = BE.fechcancel;
                        cmd1.Parameters.Add("@moneda", SqlDbType.Char).Value = BE.moneda;
                        cmd1.Parameters.Add("@statborrado", SqlDbType.Char, 1).Value = BE.statborrado;
                        cmd1.Parameters.Add("@transpid", SqlDbType.Char, 5).Value = BE.transpid;
                        cmd1.Parameters.Add("@transpnume", SqlDbType.VarChar, 40).Value = BE.transpnume;
                        cmd1.Parameters.Add("@transnmruc", SqlDbType.Char, 11).Value = BE.transnmruc;
                        cmd1.Parameters.Add("@placa", SqlDbType.VarChar, 50).Value = BE.placa;
                        cmd1.Parameters.Add("@certificado", SqlDbType.VarChar, 50).Value = BE.certificado;
                        cmd1.Parameters.Add("@licencia", SqlDbType.Char, 11).Value = BE.licencia;
                        cmd1.Parameters.Add("@motivotrasladoid", SqlDbType.Char, 1).Value = BE.motivotrasladoid;
                        cmd1.Parameters.Add("@modofactu", SqlDbType.Char, 1).Value = BE.modofactu;
                        cmd1.Parameters.Add("@clientetipo", SqlDbType.Char, 1).Value = BE.clientetipo;
                        cmd1.Parameters.Add("@ddnni", SqlDbType.Char, 8).Value = BE.ddnni;
                        cmd1.Parameters.Add("@items", SqlDbType.Decimal).Value = BE.items; //*itemscab
                        cmd1.Parameters.Add("@totimpto", SqlDbType.Decimal).Value = BE.totimpto;
                        cmd1.Parameters.Add("@valventa", SqlDbType.Decimal).Value = BE.valventa;
                        cmd1.Parameters.Add("@bruto", SqlDbType.Decimal).Value = BE.bruto;
                        cmd1.Parameters.Add("@totimporte", SqlDbType.Decimal).Value = BE.totimporte;
                        cmd1.Parameters.Add("@totpzas", SqlDbType.Decimal).Value = BE.totpzas;
                        cmd1.Parameters.Add("@fech_aten", SqlDbType.DateTime).Value = BE.fech_aten;
                        cmd1.Parameters.Add("@docu_aten", SqlDbType.Char, 16).Value = BE.docu_aten;
                        cmd1.Parameters.Add("@cantidadcta", SqlDbType.Decimal).Value = BE.cantidadcta;
                        cmd1.Parameters.Add("@cant_pend", SqlDbType.Decimal).Value = BE.cant_pend;
                        cmd1.Parameters.Add("@impo_aten", SqlDbType.Decimal).Value = BE.impo_aten;
                        cmd1.Parameters.Add("@impo_pend", SqlDbType.Decimal).Value = BE.impo_pend;
                        cmd1.Parameters.Add("@user_apr1", SqlDbType.Char, 10).Value = BE.user_apr1;
                        cmd1.Parameters.Add("@fech_apr1", SqlDbType.DateTime).Value = BE.fech_apr1;
                        cmd1.Parameters.Add("@user_apr2", SqlDbType.Char, 10).Value = BE.user_apr2;
                        cmd1.Parameters.Add("@fech_apr2", SqlDbType.DateTime).Value = BE.fech_apr2;
                        cmd1.Parameters.Add("@canalventaref", SqlDbType.Char, 9).Value = BE.canalventaref;
                        cmd1.Parameters.Add("@glosaenvio", SqlDbType.VarChar, 300).Value = BE.glosaenvio;
                        cmd1.Parameters.Add("@glosacredi", SqlDbType.VarChar, 300).Value = BE.glosacredi;
                        cmd1.Parameters.Add("@codctadebe", SqlDbType.Char, 10).Value = BE.codctadebe;
                        cmd1.Parameters.Add("@codctahaber", SqlDbType.Char, 10).Value = BE.codctahaber;
                        cmd1.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd1.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd1.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd1.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
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

        public DataSet GetOne(string empresaid, tb_pt_pedidoscab BE)
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
                    lfech = DateTime.Parse("01/01/1900 12:00:00 a.m.");
                }
            }
            else
            {
                lfech = DateTime.Parse("01/01/1900 12:00:00 a.m.");
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
