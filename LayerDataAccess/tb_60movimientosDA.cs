using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_60movimientosDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert_old(string empresaid, tb_60movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                SqlTransaction tr = default(SqlTransaction);
                Boolean TransaExito = false;

                using (SqlCommand cmd = new SqlCommand("gspTb60Movimientoscab_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@dominioid", SqlDbType.Char, 2).Value = BE.dominioid;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                    cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
                    cmd.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE.almacaccionid;
                    cmd.Parameters.Add("@tipoperacionid", SqlDbType.Char, 2).Value = BE.tipoperacionid;
                    cmd.Parameters.Add("@ctacteaccionid", SqlDbType.Char, 2).Value = BE.ctacteaccionid;
                    cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                    cmd.Parameters.Add("@direcnume", SqlDbType.Char, 6).Value = BE.direcnume;
                    cmd.Parameters.Add("@direcname", SqlDbType.VarChar, 25).Value = BE.direcname;
                    cmd.Parameters.Add("@direcdeta", SqlDbType.VarChar, 70).Value = BE.direcdeta;
                    cmd.Parameters.Add("@direc", SqlDbType.VarChar, 70).Value = BE.direc;
                    cmd.Parameters.Add("@tipdid", SqlDbType.Char, 1).Value = BE.tipdid;
                    cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                    cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                    cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                    cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                    cmd.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE.fechref;
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
                    cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                    cmd.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE.ubige;
                    cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                    cmd.Parameters.Add("@dscto3", SqlDbType.Decimal).Value = BE.dscto3;
                    cmd.Parameters.Add("@totdscto1", SqlDbType.Decimal).Value = BE.totdscto1;
                    cmd.Parameters.Add("@totdscto2", SqlDbType.Decimal).Value = BE.totdscto2;
                    cmd.Parameters.Add("@totdscto3", SqlDbType.Decimal).Value = BE.totdscto3;
                    cmd.Parameters.Add("@condpago", SqlDbType.Char, 4).Value = BE.condpago;
                    cmd.Parameters.Add("@transporte", SqlDbType.Decimal).Value = BE.transporte;
                    cmd.Parameters.Add("@embalaje", SqlDbType.Decimal).Value = BE.embalaje;
                    cmd.Parameters.Add("@otros", SqlDbType.Decimal).Value = BE.otros;
                    cmd.Parameters.Add("@tipimptoid", SqlDbType.Char, 1).Value = BE.tipimptoid;
                    cmd.Parameters.Add("@igv", SqlDbType.Decimal).Value = BE.igv;
                    cmd.Parameters.Add("@incprec", SqlDbType.Char, 1).Value = BE.incprec;
                    cmd.Parameters.Add("@tipoperimptoid", SqlDbType.Char, 1).Value = BE.tipoperimptoid;
                    cmd.Parameters.Add("@totimpto", SqlDbType.Decimal).Value = BE.totimpto;
                    cmd.Parameters.Add("@valventa", SqlDbType.Decimal).Value = BE.valventa;
                    cmd.Parameters.Add("@totimporte", SqlDbType.Decimal).Value = BE.totimporte;
                    cmd.Parameters.Add("@bruto", SqlDbType.Decimal).Value = BE.bruto;
                    cmd.Parameters.Add("@cargo", SqlDbType.Decimal).Value = BE.cargo;
                    cmd.Parameters.Add("@abono", SqlDbType.Decimal).Value = BE.abono;
                    cmd.Parameters.Add("@tcamb", SqlDbType.Decimal).Value = BE.tcamb;
                    cmd.Parameters.Add("@codctadebe", SqlDbType.Char, 10).Value = BE.codctadebe;
                    cmd.Parameters.Add("@codctahaber", SqlDbType.Char, 10).Value = BE.codctahaber;
                    cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 300).Value = BE.glosa;
                    cmd.Parameters.Add("@totpzas", SqlDbType.Decimal).Value = BE.totpzas;
                    cmd.Parameters.Add("@fechentrega", SqlDbType.DateTime).Value = BE.fechentrega;
                    cmd.Parameters.Add("@fechpago", SqlDbType.DateTime).Value = BE.fechpago;
                    cmd.Parameters.Add("@fechcancel", SqlDbType.DateTime).Value = BE.fechcancel;
                    cmd.Parameters.Add("@moneda", SqlDbType.Char).Value = BE.moneda;
                    cmd.Parameters.Add("@statborrado", SqlDbType.Char, 1).Value = BE.statborrado;
                    cmd.Parameters.Add("@transpid", SqlDbType.Char, 5).Value = BE.transpid;
                    cmd.Parameters.Add("@transpname", SqlDbType.VarChar, 40).Value = BE.transpname;
                    cmd.Parameters.Add("@motivotrasladoid", SqlDbType.Char, 2).Value = BE.motivotrasladoid;
                    cmd.Parameters.Add("@mottrasladointid", SqlDbType.Char, 2).Value = BE.mottrasladointid;
                    cmd.Parameters.Add("@modofactu", SqlDbType.Char, 1).Value = BE.modofactu;
                    cmd.Parameters.Add("@clientetipo", SqlDbType.Char, 1).Value = BE.clientetipo;
                    cmd.Parameters.Add("@ddnni", SqlDbType.Char, 8).Value = BE.ddnni;
                    cmd.Parameters.Add("@items", SqlDbType.Decimal).Value = BE.items;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    cmd.Parameters.Add("@perdni", SqlDbType.Char, 8).Value = BE.perdni;

                    //opt
                    cmd.Parameters.Add("@tipodocmanejaserie", SqlDbType.Bit).Value = BE.tipodocmanejaserie;

                    using (SqlCommand cmd2 = new SqlCommand("gspTb60Movimientosdet_INSERT_xml", cnx))
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
                            cmd.Transaction = tr;

                            if (cmd.ExecuteNonQuery() > 0)
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

        public bool Insert(string empresaid, tb_60movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60Movimientos_INSERT", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@dominioid", SqlDbType.Char, 2).Value = BE.dominioid;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    //cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                    //cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
                    cmd.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE.almacaccionid;
                    cmd.Parameters.Add("@tipoperacionid", SqlDbType.Char, 2).Value = BE.tipoperacionid;
                    cmd.Parameters.Add("@ctacteaccionid", SqlDbType.Char, 2).Value = BE.ctacteaccionid;
                    cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = fecha(BE.fechdoc);
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                    cmd.Parameters.Add("@direcnume", SqlDbType.Char, 6).Value = BE.direcnume;
                    cmd.Parameters.Add("@direcname", SqlDbType.VarChar, 25).Value = BE.direcname;
                    cmd.Parameters.Add("@direcdeta", SqlDbType.VarChar, 70).Value = BE.direcdeta;
                    cmd.Parameters.Add("@direc", SqlDbType.VarChar, 70).Value = BE.direc;
                    cmd.Parameters.Add("@tipdid", SqlDbType.Char, 1).Value = BE.tipdid;
                    cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                    cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                    cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                    cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                    cmd.Parameters.Add("@fechref", SqlDbType.DateTime).Value = fecha(BE.fechref);
                    cmd.Parameters.Add("@tip_op", SqlDbType.Char, 2).Value = BE.tip_op;
                    cmd.Parameters.Add("@ser_op", SqlDbType.Char, 4).Value = BE.ser_op;
                    cmd.Parameters.Add("@num_op", SqlDbType.Char, 10).Value = BE.num_op;
                    cmd.Parameters.Add("@tipfac", SqlDbType.Char, 2).Value = BE.tipfac;
                    cmd.Parameters.Add("@serfac", SqlDbType.Char, 4).Value = BE.serfac;
                    cmd.Parameters.Add("@numfac", SqlDbType.Char, 10).Value = BE.numfac;
                    cmd.Parameters.Add("@fechfac", SqlDbType.DateTime).Value = fecha(BE.fechfac);
                    cmd.Parameters.Add("@tipguia", SqlDbType.Char, 2).Value = BE.tipguia;
                    cmd.Parameters.Add("@serguia", SqlDbType.Char, 4).Value = BE.serguia;
                    cmd.Parameters.Add("@numguia", SqlDbType.Char, 10).Value = BE.numguia;
                    cmd.Parameters.Add("@fechguia", SqlDbType.DateTime).Value = fecha(BE.fechguia);
                    cmd.Parameters.Add("@tipnotac", SqlDbType.Char, 2).Value = BE.tipnotac;
                    cmd.Parameters.Add("@sernotac", SqlDbType.Char, 4).Value = BE.sernotac;
                    cmd.Parameters.Add("@numnotac", SqlDbType.Char, 10).Value = BE.numnotac;
                    cmd.Parameters.Add("@fechnotac", SqlDbType.DateTime).Value = fecha(BE.fechnotac);
                    cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                    cmd.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE.ubige;
                    cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                    cmd.Parameters.Add("@estacion", SqlDbType.Char, 3).Value = BE.estacion;
                    cmd.Parameters.Add("@dscto3", SqlDbType.Decimal).Value = BE.dscto3;
                    cmd.Parameters.Add("@totdscto1", SqlDbType.Decimal).Value = BE.totdscto1;
                    cmd.Parameters.Add("@totdscto2", SqlDbType.Decimal).Value = BE.totdscto2;
                    cmd.Parameters.Add("@totdscto3", SqlDbType.Decimal).Value = BE.totdscto3;
                    cmd.Parameters.Add("@condpago", SqlDbType.Char, 4).Value = BE.condpago;
                    cmd.Parameters.Add("@transporte", SqlDbType.Decimal).Value = BE.transporte;
                    cmd.Parameters.Add("@embalaje", SqlDbType.Decimal).Value = BE.embalaje;
                    cmd.Parameters.Add("@otros", SqlDbType.Decimal).Value = BE.otros;
                    cmd.Parameters.Add("@tipimptoid", SqlDbType.Char, 1).Value = BE.tipimptoid;
                    cmd.Parameters.Add("@igv", SqlDbType.Decimal).Value = BE.igv;
                    cmd.Parameters.Add("@incprec", SqlDbType.Char, 1).Value = BE.incprec;
                    cmd.Parameters.Add("@tipoperimptoid", SqlDbType.Char, 1).Value = BE.tipoperimptoid;
                    cmd.Parameters.Add("@totimpto", SqlDbType.Decimal).Value = BE.totimpto;
                    cmd.Parameters.Add("@valventa", SqlDbType.Decimal).Value = BE.valventa;
                    cmd.Parameters.Add("@totimporte", SqlDbType.Decimal).Value = BE.totimporte;
                    cmd.Parameters.Add("@bruto", SqlDbType.Decimal).Value = BE.bruto;
                    cmd.Parameters.Add("@cargo", SqlDbType.Decimal).Value = BE.cargo;
                    cmd.Parameters.Add("@abono", SqlDbType.Decimal).Value = BE.abono;
                    cmd.Parameters.Add("@tcamb", SqlDbType.Decimal).Value = BE.tcamb;
                    cmd.Parameters.Add("@codctadebe", SqlDbType.Char, 10).Value = BE.codctadebe;
                    cmd.Parameters.Add("@codctahaber", SqlDbType.Char, 10).Value = BE.codctahaber;
                    cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 300).Value = BE.glosa;
                    cmd.Parameters.Add("@totpzas", SqlDbType.Decimal).Value = BE.totpzas;
                    cmd.Parameters.Add("@fechentrega", SqlDbType.DateTime).Value = fecha(BE.fechentrega);
                    cmd.Parameters.Add("@fechpago", SqlDbType.DateTime).Value = fecha(BE.fechpago);
                    cmd.Parameters.Add("@fechcancel", SqlDbType.DateTime).Value = fecha(BE.fechcancel);
                    cmd.Parameters.Add("@moneda", SqlDbType.Char).Value = BE.moneda;
                    cmd.Parameters.Add("@statborrado", SqlDbType.Char, 1).Value = BE.statborrado;
                    cmd.Parameters.Add("@transpid", SqlDbType.Char, 5).Value = BE.transpid;
                    cmd.Parameters.Add("@transpname", SqlDbType.VarChar, 40).Value = BE.transpname;
                    cmd.Parameters.Add("@motivotrasladoid", SqlDbType.Char, 2).Value = BE.motivotrasladoid;
                    cmd.Parameters.Add("@mottrasladointid", SqlDbType.Char, 2).Value = BE.mottrasladointid;
                    cmd.Parameters.Add("@modofactu", SqlDbType.Char, 1).Value = BE.modofactu;
                    cmd.Parameters.Add("@clientetipo", SqlDbType.Char, 1).Value = BE.clientetipo;
                    cmd.Parameters.Add("@ddnni", SqlDbType.Char, 8).Value = BE.ddnni;
                    cmd.Parameters.Add("@items", SqlDbType.Decimal).Value = BE.items;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    cmd.Parameters.Add("@perdni", SqlDbType.Char, 8).Value = BE.perdni;
                    //opt
                    cmd.Parameters.Add("@tipodocmanejaserie", SqlDbType.Bit).Value = BE.tipodocmanejaserie;
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

        public bool Update(string empresaid, tb_60movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60Movimientos_UPDATE", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@dominioid", SqlDbType.Char, 2).Value = BE.dominioid;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    //cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                    //cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
                    cmd.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE.almacaccionid;
                    cmd.Parameters.Add("@tipoperacionid", SqlDbType.Char, 2).Value = BE.tipoperacionid;
                    cmd.Parameters.Add("@ctacteaccionid", SqlDbType.Char, 2).Value = BE.ctacteaccionid;
                    cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = fecha(BE.fechdoc);
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                    cmd.Parameters.Add("@direcnume", SqlDbType.Char, 6).Value = BE.direcnume;
                    cmd.Parameters.Add("@direcname", SqlDbType.VarChar, 25).Value = BE.direcname;
                    cmd.Parameters.Add("@direcdeta", SqlDbType.VarChar, 70).Value = BE.direcdeta;
                    cmd.Parameters.Add("@direc", SqlDbType.VarChar, 70).Value = BE.direc;
                    cmd.Parameters.Add("@tipdid", SqlDbType.Char, 1).Value = BE.tipdid;
                    cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                    cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                    cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                    cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                    cmd.Parameters.Add("@fechref", SqlDbType.DateTime).Value = fecha(BE.fechref);
                    cmd.Parameters.Add("@tip_op", SqlDbType.Char, 2).Value = BE.tip_op;
                    cmd.Parameters.Add("@ser_op", SqlDbType.Char, 4).Value = BE.ser_op;
                    cmd.Parameters.Add("@num_op", SqlDbType.Char, 10).Value = BE.num_op;
                    cmd.Parameters.Add("@tipfac", SqlDbType.Char, 2).Value = BE.tipfac;
                    cmd.Parameters.Add("@serfac", SqlDbType.Char, 4).Value = BE.serfac;
                    cmd.Parameters.Add("@numfac", SqlDbType.Char, 10).Value = BE.numfac;
                    cmd.Parameters.Add("@fechfac", SqlDbType.DateTime).Value = fecha(BE.fechfac);
                    cmd.Parameters.Add("@tipguia", SqlDbType.Char, 2).Value = BE.tipguia;
                    cmd.Parameters.Add("@serguia", SqlDbType.Char, 4).Value = BE.serguia;
                    cmd.Parameters.Add("@numguia", SqlDbType.Char, 10).Value = BE.numguia;
                    cmd.Parameters.Add("@fechguia", SqlDbType.DateTime).Value = fecha(BE.fechguia);
                    cmd.Parameters.Add("@tipnotac", SqlDbType.Char, 2).Value = BE.tipnotac;
                    cmd.Parameters.Add("@sernotac", SqlDbType.Char, 4).Value = BE.sernotac;
                    cmd.Parameters.Add("@numnotac", SqlDbType.Char, 10).Value = BE.numnotac;
                    cmd.Parameters.Add("@fechnotac", SqlDbType.DateTime).Value = fecha(BE.fechnotac);
                    cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                    cmd.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE.ubige;
                    cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                    cmd.Parameters.Add("@estacion", SqlDbType.Char, 3).Value = BE.estacion;
                    cmd.Parameters.Add("@dscto3", SqlDbType.Decimal).Value = BE.dscto3;
                    cmd.Parameters.Add("@totdscto1", SqlDbType.Decimal).Value = BE.totdscto1;
                    cmd.Parameters.Add("@totdscto2", SqlDbType.Decimal).Value = BE.totdscto2;
                    cmd.Parameters.Add("@totdscto3", SqlDbType.Decimal).Value = BE.totdscto3;
                    cmd.Parameters.Add("@condpago", SqlDbType.Char, 4).Value = BE.condpago;
                    cmd.Parameters.Add("@transporte", SqlDbType.Decimal).Value = BE.transporte;
                    cmd.Parameters.Add("@embalaje", SqlDbType.Decimal).Value = BE.embalaje;
                    cmd.Parameters.Add("@otros", SqlDbType.Decimal).Value = BE.otros;
                    cmd.Parameters.Add("@tipimptoid", SqlDbType.Char, 1).Value = BE.tipimptoid;
                    cmd.Parameters.Add("@igv", SqlDbType.Decimal).Value = BE.igv;
                    cmd.Parameters.Add("@incprec", SqlDbType.Char, 1).Value = BE.incprec;
                    cmd.Parameters.Add("@tipoperimptoid", SqlDbType.Char, 1).Value = BE.tipoperimptoid;
                    cmd.Parameters.Add("@totimpto", SqlDbType.Decimal).Value = BE.totimpto;
                    cmd.Parameters.Add("@valventa", SqlDbType.Decimal).Value = BE.valventa;
                    cmd.Parameters.Add("@totimporte", SqlDbType.Decimal).Value = BE.totimporte;
                    cmd.Parameters.Add("@bruto", SqlDbType.Decimal).Value = BE.bruto;
                    cmd.Parameters.Add("@cargo", SqlDbType.Decimal).Value = BE.cargo;
                    cmd.Parameters.Add("@abono", SqlDbType.Decimal).Value = BE.abono;
                    cmd.Parameters.Add("@tcamb", SqlDbType.Decimal).Value = BE.tcamb;
                    cmd.Parameters.Add("@codctadebe", SqlDbType.Char, 10).Value = BE.codctadebe;
                    cmd.Parameters.Add("@codctahaber", SqlDbType.Char, 10).Value = BE.codctahaber;
                    cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 300).Value = BE.glosa;
                    cmd.Parameters.Add("@totpzas", SqlDbType.Decimal).Value = BE.totpzas;
                    cmd.Parameters.Add("@fechentrega", SqlDbType.DateTime).Value = fecha(BE.fechentrega);
                    cmd.Parameters.Add("@fechpago", SqlDbType.DateTime).Value = fecha(BE.fechpago);
                    cmd.Parameters.Add("@fechcancel", SqlDbType.DateTime).Value = fecha(BE.fechcancel);
                    cmd.Parameters.Add("@moneda", SqlDbType.Char).Value = BE.moneda;
                    cmd.Parameters.Add("@statborrado", SqlDbType.Char, 1).Value = BE.statborrado;
                    cmd.Parameters.Add("@transpid", SqlDbType.Char, 5).Value = BE.transpid;
                    cmd.Parameters.Add("@transpname", SqlDbType.VarChar, 40).Value = BE.transpname;
                    cmd.Parameters.Add("@motivotrasladoid", SqlDbType.Char, 2).Value = BE.motivotrasladoid;
                    cmd.Parameters.Add("@mottrasladointid", SqlDbType.Char, 2).Value = BE.mottrasladointid;
                    cmd.Parameters.Add("@modofactu", SqlDbType.Char, 1).Value = BE.modofactu;
                    cmd.Parameters.Add("@clientetipo", SqlDbType.Char, 1).Value = BE.clientetipo;
                    cmd.Parameters.Add("@ddnni", SqlDbType.Char, 8).Value = BE.ddnni;
                    cmd.Parameters.Add("@items", SqlDbType.Decimal).Value = BE.items;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    cmd.Parameters.Add("@perdni", SqlDbType.Char, 8).Value = BE.perdni;
                    //opt
                    cmd.Parameters.Add("@XMLnew", SqlDbType.Xml).Value = BE.GetItemXML();
                    cmd.Parameters.Add("@XMLold", SqlDbType.Xml).Value = BE.GetItemXML2();

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

        public bool Delete(string empresaid, tb_60movimientos BE)
        {

            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd1 = new SqlCommand("gspTb60Movimientos_DELETE", cnx))
                {
                    cmd1.CommandTimeout = 0;
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd1.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd1.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                    cmd1.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd1.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd1.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd1.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;

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

        public DataSet GetReport(string empresaid, tb_60movimientos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60Movimientos_REPORT_rollos", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@convalor", SqlDbType.Char, 1).Value = BE.Convalor;                        
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

        public DataSet GetAll(string empresaid, tb_60movimientoscab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaMovimientoscab_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
                        cmd.Parameters.Add("@almacaccionid", SqlDbType.Char, 2).Value = BE.almacaccionid;
                        cmd.Parameters.Add("@tipoperacionid", SqlDbType.Char, 2).Value = BE.tipoperacionid;
                        cmd.Parameters.Add("@ctacteaccionid", SqlDbType.Char, 2).Value = BE.ctacteaccionid;
                        //cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                        cmd.Parameters.Add("@direcnume", SqlDbType.Char, 6).Value = BE.direcnume;
                        cmd.Parameters.Add("@direcname", SqlDbType.VarChar, 25).Value = BE.direcname;
                        cmd.Parameters.Add("@direcdeta", SqlDbType.VarChar, 70).Value = BE.direcdeta;
                        cmd.Parameters.Add("@direc", SqlDbType.VarChar, 70).Value = BE.direc;
                        cmd.Parameters.Add("@tipdid", SqlDbType.Char, 1).Value = BE.tipdid;
                        cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                        cmd.Parameters.Add("@tipref", SqlDbType.Char, 2).Value = BE.tipref;
                        cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                        cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                        //cmd.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE.fechref;
                        cmd.Parameters.Add("@tip_op", SqlDbType.Char, 2).Value = BE.tip_op;
                        cmd.Parameters.Add("@ser_op", SqlDbType.Char, 4).Value = BE.ser_op;
                        cmd.Parameters.Add("@num_op", SqlDbType.Char, 10).Value = BE.num_op;
                        cmd.Parameters.Add("@tipfac", SqlDbType.Char, 2).Value = BE.tipfac;
                        cmd.Parameters.Add("@serfac", SqlDbType.Char, 4).Value = BE.serfac;
                        cmd.Parameters.Add("@numfac", SqlDbType.Char, 10).Value = BE.numfac;
                        //cmd.Parameters.Add("@fechfac", SqlDbType.DateTime).Value = BE.fechfac;
                        cmd.Parameters.Add("@tipguia", SqlDbType.Char, 2).Value = BE.tipguia;
                        cmd.Parameters.Add("@serguia", SqlDbType.Char, 4).Value = BE.serguia;
                        cmd.Parameters.Add("@numguia", SqlDbType.Char, 10).Value = BE.numguia;
                        //cmd.Parameters.Add("@fechguia", SqlDbType.DateTime).Value = BE.fechguia;
                        cmd.Parameters.Add("@tipnotac", SqlDbType.Char, 2).Value = BE.tipnotac;
                        cmd.Parameters.Add("@sernotac", SqlDbType.Char, 4).Value = BE.sernotac;
                        cmd.Parameters.Add("@numnotac", SqlDbType.Char, 10).Value = BE.numnotac;
                        //cmd.Parameters.Add("@fechnotac", SqlDbType.DateTime).Value = BE.fechnotac;
                        cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                        cmd.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE.ubige;
                        cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                        //cmd.Parameters.Add("@dscto3", SqlDbType.Decimal).Value = BE.dscto3;
                        //cmd.Parameters.Add("@totdscto1", SqlDbType.Decimal).Value = BE.totdscto1;
                        //cmd.Parameters.Add("@totdscto2", SqlDbType.Decimal).Value = BE.totdscto2;
                        //cmd.Parameters.Add("@totdscto3", SqlDbType.Decimal).Value = BE.totdscto3;
                        cmd.Parameters.Add("@condpago", SqlDbType.Char, 4).Value = BE.condpago;
                        //cmd.Parameters.Add("@transporte", SqlDbType.Decimal).Value = BE.transporte;
                        //cmd.Parameters.Add("@embalaje", SqlDbType.Decimal).Value = BE.embalaje;
                        //cmd.Parameters.Add("@otros", SqlDbType.Decimal).Value = BE.otros;
                        cmd.Parameters.Add("@tipimptoid", SqlDbType.Char, 1).Value = BE.tipimptoid;
                        //cmd.Parameters.Add("@igv", SqlDbType.Decimal).Value = BE.igv;
                        cmd.Parameters.Add("@incprec", SqlDbType.Char, 1).Value = BE.incprec;
                        cmd.Parameters.Add("@tipoperimptoid", SqlDbType.Char, 1).Value = BE.tipoperimptoid;
                        //cmd.Parameters.Add("@totimpto", SqlDbType.Decimal).Value = BE.totimpto;
                        //cmd.Parameters.Add("@valventa", SqlDbType.Decimal).Value = BE.valventa;
                        //cmd.Parameters.Add("@totimporte", SqlDbType.Decimal).Value = BE.totimporte;
                        //cmd.Parameters.Add("@bruto", SqlDbType.Decimal).Value = BE.bruto;
                        //cmd.Parameters.Add("@cargo", SqlDbType.Decimal).Value = BE.cargo;
                        //cmd.Parameters.Add("@abono", SqlDbType.Decimal).Value = BE.abono;
                        //cmd.Parameters.Add("@tcamb", SqlDbType.Decimal).Value = BE.tcamb;
                        cmd.Parameters.Add("@codctadebe", SqlDbType.Char, 10).Value = BE.codctadebe;
                        cmd.Parameters.Add("@codctahaber", SqlDbType.Char, 10).Value = BE.codctahaber;
                        cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 300).Value = BE.glosa;
                        //cmd.Parameters.Add("@totpzas", SqlDbType.Decimal).Value = BE.totpzas;
                        //cmd.Parameters.Add("@fechentrega", SqlDbType.DateTime).Value = BE.fechentrega;
                        //cmd.Parameters.Add("@fechpago", SqlDbType.DateTime).Value = BE.fechpago;
                        //cmd.Parameters.Add("@fechcancel", SqlDbType.DateTime).Value = BE.fechcancel;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char).Value = BE.moneda;
                        cmd.Parameters.Add("@statborrado", SqlDbType.Char, 1).Value = BE.statborrado;
                        cmd.Parameters.Add("@transpid", SqlDbType.Char, 5).Value = BE.transpid;
                        cmd.Parameters.Add("@transpname", SqlDbType.VarChar, 40).Value = BE.transpname;
                        cmd.Parameters.Add("@motivotrasladoid", SqlDbType.Char, 2).Value = BE.motivotrasladoid;
                        cmd.Parameters.Add("@mottrasladointid", SqlDbType.Char, 2).Value = BE.mottrasladointid;
                        cmd.Parameters.Add("@modofactu", SqlDbType.Char, 1).Value = BE.modofactu;
                        cmd.Parameters.Add("@clientetipo", SqlDbType.Char, 1).Value = BE.clientetipo;
                        cmd.Parameters.Add("@ddnni", SqlDbType.Char, 8).Value = BE.ddnni;
                        //cmd.Parameters.Add("@items", SqlDbType.Decimal).Value = BE.items;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                        cmd.Parameters.Add("@perdni", SqlDbType.Char, 8).Value = BE.perdni;
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

        public DataSet GetOne(string empresaid, tb_60movimientoscab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaMovimientoscab_SELECT", cnx))
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

        public DataSet GetOne2(string empresaid, tb_60movimientoscab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaMovimientoscab_SELECT2", cnx))
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

        public DataSet GetvalidaMov(string empresaid, tb_60movimientoscab BE)
            {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaMovimientosprod", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipop", SqlDbType.Char, 2).Value = BE.tip_op;
                        cmd.Parameters.Add("@serop", SqlDbType.Char, 4).Value = BE.ser_op;
                        cmd.Parameters.Add("@numop", SqlDbType.Char, 10).Value = BE.num_op;
                        cmd.Parameters.Add("@productoid", SqlDbType.VarChar).Value = BE.productoid;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@Idx", SqlDbType.Char, 3).Value = BE.idx;
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
            //string dia = pfecha.Day.ToString();
            //string mes = pfecha.Month.ToString();
            //string anio = pfecha.Year.ToString();
            //string fecha = anio + "-" + mes + "-" + dia;
            DateTime lfech;
            //DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
            //IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
            if (pfecha != null)
            {
                if (pfecha != DateTime.Parse("01/01/0001 12:00:00 a.m.") || pfecha != DateTime.Parse("01/01/0001 00:00:00"))
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

        #endregion

    }
}
