using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;
using System.Data.OleDb;



namespace LayerDataAccess
{
    public class tb_pt_articuloDA
    {
        ConexionDA conex = new ConexionDA();
        
        public bool Insert(string empresaid, tb_pt_articulo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtArticulo_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
                    cmd.Parameters.Add("@articidold", SqlDbType.Char, 8).Value = BE.articidold;
                    cmd.Parameters.Add("@articname", SqlDbType.VarChar, 50).Value = BE.articname;
                    cmd.Parameters.Add("@articdsav", SqlDbType.VarChar, 35).Value = BE.articdsav;
                    cmd.Parameters.Add("@prec_costo", SqlDbType.Decimal).Value = BE.preccosto;
                    cmd.Parameters.Add("@real_costo", SqlDbType.Decimal).Value = BE.real_costo;                    
                    cmd.Parameters.Add("@precventaCreMayor", SqlDbType.Decimal).Value = BE.precventa_cre_mayor;
                    cmd.Parameters.Add("@precventaCreMenor", SqlDbType.Decimal).Value = BE.precventa_cre_menor;
                    cmd.Parameters.Add("@precventaTdaMayor", SqlDbType.Decimal).Value = BE.precventa_tda_mayor;
                    cmd.Parameters.Add("@precventaTdaMenor", SqlDbType.Decimal).Value = BE.precventa_tda_menor;
                    cmd.Parameters.Add("@precventaCscMayor", SqlDbType.Decimal).Value = BE.precventa_csc_mayor;
                    cmd.Parameters.Add("@precventaCscMenor", SqlDbType.Decimal).Value = BE.precventa_csc_menor;
                    cmd.Parameters.Add("@categoriaid", SqlDbType.Char, 2).Value = BE.categoriaid;
                    cmd.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE.marcaid;
                    cmd.Parameters.Add("@lineaid", SqlDbType.Char, 2).Value = BE.lineaid;                    
                    cmd.Parameters.Add("@generoid", SqlDbType.Char, 1).Value = BE.generoid;
                    cmd.Parameters.Add("@tejidoid", SqlDbType.Char, 3).Value = BE.tejidoid;
                    cmd.Parameters.Add("@familiatelaid", SqlDbType.Char, 3).Value = BE.familiatelaid;
                    cmd.Parameters.Add("@telaid", SqlDbType.Char, 10).Value = BE.telaid;
                    cmd.Parameters.Add("@botapieid", SqlDbType.Char, 10).Value = BE.botapieid;
                    cmd.Parameters.Add("@entalleid", SqlDbType.Char, 10).Value = BE.entalleid;
                    cmd.Parameters.Add("@coleccionid", SqlDbType.Char, 3).Value = BE.coleccionid;
                    cmd.Parameters.Add("@subcoleccionid", SqlDbType.Char, 2).Value = BE.subcoleccionid;
                    cmd.Parameters.Add("@procedenciaid", SqlDbType.Char, 1).Value = BE.procedenciaid;
                    cmd.Parameters.Add("@telaidvfp", SqlDbType.Char, 10).Value = BE.telaidvfp;
                    cmd.Parameters.Add("@modeloid", SqlDbType.Char, 4).Value = BE.modeloid;
                    cmd.Parameters.Add("@estructuraid", SqlDbType.Char, 1).Value = BE.estructuraid;
                    cmd.Parameters.Add("@canalventaid", SqlDbType.Char, 3).Value = BE.canalventaid;
                    cmd.Parameters.Add("@estacionid", SqlDbType.Char, 1).Value = BE.estacionid;
                    cmd.Parameters.Add("@temporadaid", SqlDbType.Char, 1).Value = BE.temporadaid;
                    cmd.Parameters.Add("@grupoid", SqlDbType.Char, 4).Value = BE.grupoid;
                    //cmd.Parameters.Add("@rubroid", SqlDbType.Char, 2).Value = BE.rubroid;
                    cmd.Parameters.Add("@parteid", SqlDbType.Char, 1).Value = BE.parte;
                    cmd.Parameters.Add("@tallaid", SqlDbType.Char, 2).Value = BE.tallaid;
                    cmd.Parameters.Add("@ta01", SqlDbType.Bit).Value = BE.ta01;
                    cmd.Parameters.Add("@ta02", SqlDbType.Bit).Value = BE.ta02;
                    cmd.Parameters.Add("@ta03", SqlDbType.Bit).Value = BE.ta03;
                    cmd.Parameters.Add("@ta04", SqlDbType.Bit).Value = BE.ta04;
                    cmd.Parameters.Add("@ta05", SqlDbType.Bit).Value = BE.ta05;
                    cmd.Parameters.Add("@ta06", SqlDbType.Bit).Value = BE.ta06;
                    cmd.Parameters.Add("@ta07", SqlDbType.Bit).Value = BE.ta07;
                    cmd.Parameters.Add("@ta08", SqlDbType.Bit).Value = BE.ta08;
                    cmd.Parameters.Add("@ta09", SqlDbType.Bit).Value = BE.ta09;
                    cmd.Parameters.Add("@ta10", SqlDbType.Bit).Value = BE.ta10;
                    cmd.Parameters.Add("@ta11", SqlDbType.Bit).Value = BE.ta11;
                    cmd.Parameters.Add("@ta12", SqlDbType.Bit).Value = BE.ta12;  
                    cmd.Parameters.Add("@variante", SqlDbType.Char, 6).Value = BE.variante;
                    cmd.Parameters.Add("@codinge", SqlDbType.Char, 7).Value = BE.codinge;
                    cmd.Parameters.Add("@precEtiq", SqlDbType.Decimal).Value = BE.prec_etiq;
                    cmd.Parameters.Add("@precOfer", SqlDbType.Decimal).Value = BE.prec_ofer;
                    cmd.Parameters.Add("@fechpi", SqlDbType.DateTime).Value = BE.fechpi;
                    cmd.Parameters.Add("@fechui", SqlDbType.DateTime).Value = BE.fechui;
                    cmd.Parameters.Add("@estadoid", SqlDbType.Char, 2).Value = BE.estado;
                    cmd.Parameters.Add("@esMercaderia", SqlDbType.Bit).Value = BE.es_mercaderia;
                    cmd.Parameters.Add("@foto", SqlDbType.VarChar, 50).Value = BE.docname;
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

        public bool Insert_dbf(string empresaid, tb_pt_articulo BE)
        {
            Conex_FoxDA cone = new Conex_FoxDA();
            using (OleDbConnection cnx = new OleDbConnection(cone.AdmConexion()))
            {
                String commandString =
                "INSERT INTO ptema700 (pt700stat ,pt700idar ,pt700name ,pt700dsav ,pt700pcos ,pt700pma1 ,pt700pme1 ,pt700pma2 ,pt700pme2 ,pt700pma3 " +
                                     ",pt700pme3 ,pt700gene ,pt700tabl ,pt700idta ,pt700marc ,pt700usid ,pt700feac ,pt700idmc ,pt700idli ,pt700idtj " +
                                     ",pt700idgn ,pt700idca ,pt700inge ,pt700petq ,pt700pofe ,pt700fecr ,pt700idtp ,pt700idprv,pt700flsa ,pt700idco " +
                                     ",pt700idrb ,pt700idmd ,pt700idva ,pt700fepi ,pt700feui ,pt700equi ,pt700flac ,pt700idte ,pt700feps ,pt700feus " +
                                     ",pt700artic ,pt700fecho ,temporadaid ,estacionid ,parteid ,estructuraid ,botapieid ,entalleid ,PT700PMA2O, PT700PME2O" +
                                     ",ENSQL ,FECHPITDA " +
                                     " )" +

                " VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?," +
                         "?, ?, ?, ?, ?, ?, ?, ?, ?, ?," +
                         "?, ?, ?, ?, ?, ?, ?, ?, ?, ?," +
                         "?, ?, ?, ?, ?, ?, ?, ?, ?, ?," +
                         "?, ?, ?, ?, ?, ?, ?, ?, ?, ?," +
                         "?, ? " +
                         ")";

                OleDbCommand cmd = new OleDbCommand(commandString, cnx);
                cmd.Parameters.Add("@pt700stat ", OleDbType.Decimal).Value = 1;
                cmd.Parameters.Add("@pt700idar ", OleDbType.Char, 7).Value = BE.articidold.ToString();
                cmd.Parameters.Add("@pt700name ", OleDbType.VarChar, 40).Value = BE.articname.ToString();
                cmd.Parameters.Add("@pt700dsav ", OleDbType.Char, 35).Value = BE.articdsav.ToString();
                cmd.Parameters.Add("@pt700pcos ", OleDbType.Decimal).Value = BE.preccosto.ToString();
                cmd.Parameters.Add("@pt700pma1 ", OleDbType.Decimal).Value = BE.precventa_cre_mayor.ToString();
                cmd.Parameters.Add("@pt700pme1 ", OleDbType.Decimal).Value = BE.precventa_cre_menor.ToString();
                cmd.Parameters.Add("@pt700pma2 ", OleDbType.Decimal).Value = BE.precventa_tda_mayor.ToString();
                cmd.Parameters.Add("@pt700pme2 ", OleDbType.Decimal).Value = BE.precventa_tda_menor.ToString();
                cmd.Parameters.Add("@pt700pma3 ", OleDbType.Decimal).Value = BE.precventa_csc_mayor.ToString();
                cmd.Parameters.Add("@pt700pme3 ", OleDbType.Decimal).Value = BE.precventa_csc_menor.ToString();
                cmd.Parameters.Add("@pt700gene ", OleDbType.Char, 1).Value = BE.generoid.ToString();
                cmd.Parameters.Add("@pt700tabl ", OleDbType.Decimal).Value = 0;
                cmd.Parameters.Add("@pt700idta ", OleDbType.Char, 2).Value = BE.tallaid.ToString();
                cmd.Parameters.Add("@pt700marc ", OleDbType.VarChar, 15).Value = BE.marcaname.ToString();
                cmd.Parameters.Add("@pt700usid ", OleDbType.Char, 3).Value = BE.usuar.ToString();
                cmd.Parameters.Add("@pt700feac ", OleDbType.Date).Value = DateTime.Today.ToShortDateString();
                cmd.Parameters.Add("@pt700idmc ", OleDbType.Char, 2).Value = BE.marcaidold.ToString();
                cmd.Parameters.Add("@pt700idli ", OleDbType.Char, 3).Value = BE.lineaidold.ToString();
                cmd.Parameters.Add("@pt700idtj ", OleDbType.Char, 3).Value = BE.tejidoid.ToString();
                cmd.Parameters.Add("@pt700idgn ", OleDbType.Char, 1).Value = BE.generoid.ToString();                
                cmd.Parameters.Add("@pt700idca ", OleDbType.Char, 1).Value = BE.categoriaid.ToString();  
                cmd.Parameters.Add("@pt700inge ", OleDbType.Char, 7).Value = BE.articidold.ToString();
                cmd.Parameters.Add("@pt700petq ", OleDbType.Decimal).Value = BE.prec_etiq.ToString();
                cmd.Parameters.Add("@pt700pofe ", OleDbType.Decimal).Value = BE.prec_ofer.ToString();
                cmd.Parameters.Add("@pt700fecr ", OleDbType.Date).Value = DateTime.Today.ToShortDateString();
                cmd.Parameters.Add("@pt700idtp ", OleDbType.Char, 2).Value = BE.estado.ToString();
                cmd.Parameters.Add("@pt700idprv", OleDbType.Char, 4).Value = BE.grupoid.ToString();
                cmd.Parameters.Add("@pt700flsa ", OleDbType.Boolean).Value = BE.estado2;
                cmd.Parameters.Add("@pt700idco ", OleDbType.Char, 3).Value = BE.coleccionid.ToString();
                cmd.Parameters.Add("@pt700idrb ", OleDbType.Char, 2).Value = "01".ToString();
                cmd.Parameters.Add("@pt700idmd ", OleDbType.Char, 4).Value = "".ToString();
                cmd.Parameters.Add("@pt700idva ", OleDbType.Char, 6).Value = "".ToString();
                cmd.Parameters.Add("@pt700fepi ", OleDbType.Date).Value = null;
                cmd.Parameters.Add("@pt700feui ", OleDbType.Date).Value = null;
                cmd.Parameters.Add("@pt700equi ", OleDbType.Char, 15).Value = "".ToString();
                cmd.Parameters.Add("@pt700flac ", OleDbType.Boolean).Value = 0;
                cmd.Parameters.Add("@pt700idte ", OleDbType.Char, 8).Value = "".ToString();
                cmd.Parameters.Add("@pt700feps ", OleDbType.Date).Value = null;
                cmd.Parameters.Add("@pt700feus ", OleDbType.Date).Value = null;
                cmd.Parameters.Add("@pt700artic ", OleDbType.Char, 10).Value = "".ToString();
                cmd.Parameters.Add("@pt700fecho ", OleDbType.Date).Value = DateTime.Today.ToShortDateString();
                cmd.Parameters.Add("@temporadaid ", OleDbType.Char, 1).Value = BE.temporadaid.ToString();                
                cmd.Parameters.Add("@estacionid ", OleDbType.Char, 1).Value = BE.estacionid.ToString();
                cmd.Parameters.Add("@parteid ", OleDbType.Char, 1).Value = BE.parte.ToString();
                cmd.Parameters.Add("@estructuraid ", OleDbType.Char, 1).Value = BE.estructuraid.ToString();
                cmd.Parameters.Add("@botapieid ", OleDbType.Char, 2).Value = BE.botapieid.ToString();
                cmd.Parameters.Add("@entalleid ", OleDbType.Char, 2).Value = BE.entalleid.ToString();
                cmd.Parameters.Add("@PT700PMA2O ", OleDbType.Decimal).Value = 0;
                cmd.Parameters.Add("@PT700PME2O ", OleDbType.Decimal).Value = 0;
                cmd.Parameters.Add("@ENSQL ", OleDbType.Boolean).Value = 1;
                cmd.Parameters.Add("@FECHPITDA ", OleDbType.Date).Value = null;

                cnx.Open();                      
                try
                {
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

        public bool Update(string empresaid, tb_pt_articulo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtArticulo_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
                        cmd.Parameters.Add("@articidold", SqlDbType.Char, 8).Value = BE.articidold;
                        cmd.Parameters.Add("@articname", SqlDbType.VarChar, 50).Value = BE.articname;
                        cmd.Parameters.Add("@articdsav", SqlDbType.VarChar, 35).Value = BE.articdsav;
                        cmd.Parameters.Add("@prec_costo", SqlDbType.Decimal).Value = BE.preccosto;
                        cmd.Parameters.Add("@real_costo", SqlDbType.Decimal).Value = BE.real_costo;
                        cmd.Parameters.Add("@precventaCreMayor", SqlDbType.Decimal).Value = BE.precventa_cre_mayor;
                        cmd.Parameters.Add("@precventaCreMenor", SqlDbType.Decimal).Value = BE.precventa_cre_menor;
                        cmd.Parameters.Add("@precventaTdaMayor", SqlDbType.Decimal).Value = BE.precventa_tda_mayor;
                        cmd.Parameters.Add("@precventaTdaMenor", SqlDbType.Decimal).Value = BE.precventa_tda_menor;
                        cmd.Parameters.Add("@precventaCscMayor", SqlDbType.Decimal).Value = BE.precventa_csc_mayor;
                        cmd.Parameters.Add("@precventaCscMenor", SqlDbType.Decimal).Value = BE.precventa_csc_menor;
                        cmd.Parameters.Add("@categoriaid", SqlDbType.Char, 2).Value = BE.categoriaid;                        
                        cmd.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE.marcaid;
                        cmd.Parameters.Add("@lineaid", SqlDbType.Char, 2).Value = BE.lineaid;
                        cmd.Parameters.Add("@generoid", SqlDbType.Char, 1).Value = BE.generoid;
                        cmd.Parameters.Add("@tejidoid", SqlDbType.Char, 3).Value = BE.tejidoid;
                        cmd.Parameters.Add("@familiatelaid", SqlDbType.Char, 3).Value = BE.familiatelaid;
                        cmd.Parameters.Add("@telaid", SqlDbType.Char, 10).Value = BE.telaid;
                        cmd.Parameters.Add("@botapieid", SqlDbType.Char, 10).Value = BE.botapieid;
                        cmd.Parameters.Add("@entalleid", SqlDbType.Char, 10).Value = BE.entalleid;
                        cmd.Parameters.Add("@coleccionid", SqlDbType.Char, 3).Value = BE.coleccionid;
                        cmd.Parameters.Add("@subcoleccionid", SqlDbType.Char, 2).Value = BE.subcoleccionid;
                        cmd.Parameters.Add("@procedenciaid", SqlDbType.Char, 1).Value = BE.procedenciaid;                        
                        cmd.Parameters.Add("@telaidvfp", SqlDbType.Char, 10).Value = BE.telaidvfp;
                        cmd.Parameters.Add("@modeloid", SqlDbType.Char, 4).Value = BE.modeloid;
                        cmd.Parameters.Add("@estructuraid", SqlDbType.Char, 1).Value = BE.estructuraid;
                        cmd.Parameters.Add("@canalventaid", SqlDbType.Char, 3).Value = BE.canalventaid;
                        cmd.Parameters.Add("@estacionid", SqlDbType.Char, 1).Value = BE.estacionid;
                        cmd.Parameters.Add("@temporadaid", SqlDbType.Char, 1).Value = BE.temporadaid;
                        cmd.Parameters.Add("@grupoid", SqlDbType.Char, 4).Value = BE.grupoid;
                        //cmd.Parameters.Add("@rubroid", SqlDbType.Char, 2).Value = BE.rubroid;
                        cmd.Parameters.Add("@parteid", SqlDbType.Char, 1).Value = BE.parte;
                        cmd.Parameters.Add("@tallaid", SqlDbType.Char, 2).Value = BE.tallaid;
                        cmd.Parameters.Add("@ta01", SqlDbType.Bit).Value = BE.ta01;
                        cmd.Parameters.Add("@ta02", SqlDbType.Bit).Value = BE.ta02;
                        cmd.Parameters.Add("@ta03", SqlDbType.Bit).Value = BE.ta03;
                        cmd.Parameters.Add("@ta04", SqlDbType.Bit).Value = BE.ta04;
                        cmd.Parameters.Add("@ta05", SqlDbType.Bit).Value = BE.ta05;
                        cmd.Parameters.Add("@ta06", SqlDbType.Bit).Value = BE.ta06;
                        cmd.Parameters.Add("@ta07", SqlDbType.Bit).Value = BE.ta07;
                        cmd.Parameters.Add("@ta08", SqlDbType.Bit).Value = BE.ta08;
                        cmd.Parameters.Add("@ta09", SqlDbType.Bit).Value = BE.ta09;
                        cmd.Parameters.Add("@ta10", SqlDbType.Bit).Value = BE.ta10;
                        cmd.Parameters.Add("@ta11", SqlDbType.Bit).Value = BE.ta11;
                        cmd.Parameters.Add("@ta12", SqlDbType.Bit).Value = BE.ta12;
                        cmd.Parameters.Add("@variante", SqlDbType.Char, 6).Value = BE.variante;
                        cmd.Parameters.Add("@codinge", SqlDbType.Char, 7).Value = BE.codinge;
                        cmd.Parameters.Add("@precEtiq", SqlDbType.Decimal).Value = BE.prec_etiq;
                        cmd.Parameters.Add("@precOfer", SqlDbType.Decimal).Value = BE.prec_ofer;
                        cmd.Parameters.Add("@fechpi", SqlDbType.DateTime).Value = BE.fechpi;
                        cmd.Parameters.Add("@fechui", SqlDbType.DateTime).Value = BE.fechui;
                        cmd.Parameters.Add("@estadoid", SqlDbType.Char, 2).Value = BE.estado;
                        cmd.Parameters.Add("@esMercaderia", SqlDbType.Bit).Value = BE.es_mercaderia;
                        cmd.Parameters.Add("@foto", SqlDbType.VarChar, 50).Value = BE.docname;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                        cmd.Parameters.Add("@nivel", SqlDbType.Char, 1).Value = BE.nivel;
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

        public bool Update_dbf(string empresaid, tb_pt_articulo BE)
        {
            Conex_FoxDA cone = new Conex_FoxDA();
            using (OleDbConnection cnx = new OleDbConnection(cone.AdmConexion()))
            {
                String commandString =
                "UPDATE ptema700  SET  pt700name = ? ,pt700dsav = ? ,pt700pcos = ? ,pt700pma1 = ? ,pt700pme1 = ? ,pt700pma2 = ? ,pt700pme2 = ? ,pt700pma3  = ? " +
                                     ",pt700pme3 = ? ,pt700gene = ? ,pt700idta = ? ,pt700marc = ? ,pt700usid = ? ,pt700feac = ? ,pt700idmc = ? ,pt700idli  = ? " +
                                     ",pt700idgn = ? ,pt700idca = ? ,pt700inge = ? ,pt700petq = ? ,pt700pofe = ? ,pt700idtp = ? ,pt700idprv = ? " +
                                     ",pt700flsa = ? ,pt700idco = ? ,pt700idtj = ? ,pt700fecho = ? ,temporadaid = ? ,estacionid = ? ,parteid = ? ,estructuraid = ? " +
                                     ",botapieid = ? ,entalleid = ? " +

                " WHERE pt700idar  = ? " ;

                OleDbCommand cmd = new OleDbCommand(commandString, cnx);                
                cmd.Parameters.Add("@pt700name ", OleDbType.VarChar, 40).Value = BE.articname.ToString();
                cmd.Parameters.Add("@pt700dsav ", OleDbType.Char, 35).Value = BE.articdsav.ToString();
                cmd.Parameters.Add("@pt700pcos ", OleDbType.Decimal).Value = BE.preccosto.ToString();
                cmd.Parameters.Add("@pt700pma1 ", OleDbType.Decimal).Value = BE.precventa_cre_mayor.ToString();
                cmd.Parameters.Add("@pt700pme1 ", OleDbType.Decimal).Value = BE.precventa_cre_menor.ToString();
                cmd.Parameters.Add("@pt700pma2 ", OleDbType.Decimal).Value = BE.precventa_tda_mayor.ToString();
                cmd.Parameters.Add("@pt700pme2 ", OleDbType.Decimal).Value = BE.precventa_tda_menor.ToString();
                cmd.Parameters.Add("@pt700pma3 ", OleDbType.Decimal).Value = BE.precventa_csc_mayor.ToString();
                cmd.Parameters.Add("@pt700pme3 ", OleDbType.Decimal).Value = BE.precventa_csc_menor.ToString();
                cmd.Parameters.Add("@pt700gene ", OleDbType.Char, 1).Value = BE.generoid.ToString();    
                cmd.Parameters.Add("@pt700idta ", OleDbType.Char, 2).Value = BE.tallaid.ToString();
                cmd.Parameters.Add("@pt700marc ", OleDbType.VarChar, 15).Value = BE.marcaname.ToString();
                cmd.Parameters.Add("@pt700usid ", OleDbType.Char, 3).Value = BE.usuar.ToString();
                cmd.Parameters.Add("@pt700feac ", OleDbType.Date).Value = DateTime.Today.ToShortDateString();
                cmd.Parameters.Add("@pt700idmc ", OleDbType.Char, 2).Value = BE.marcaidold.ToString();
                cmd.Parameters.Add("@pt700idli ", OleDbType.Char, 3).Value = BE.lineaidold.ToString();
                cmd.Parameters.Add("@pt700idgn ", OleDbType.Char, 1).Value = BE.generoid.ToString();                             
                cmd.Parameters.Add("@pt700idca ", OleDbType.Char, 1).Value = BE.categoriaid.ToString();
                cmd.Parameters.Add("@pt700inge ", OleDbType.Char, 7).Value = BE.articidold.ToString();
                cmd.Parameters.Add("@pt700petq ", OleDbType.Decimal).Value = BE.prec_etiq.ToString();
                cmd.Parameters.Add("@pt700pofe ", OleDbType.Decimal).Value = BE.prec_ofer.ToString();                
                cmd.Parameters.Add("@pt700idtp ", OleDbType.Char, 2).Value = BE.estado.ToString();
                cmd.Parameters.Add("@pt700idprv", OleDbType.Char, 4).Value = BE.grupoid.ToString();
                cmd.Parameters.Add("@pt700flsa ", OleDbType.Boolean).Value = BE.estado2;
                cmd.Parameters.Add("@pt700idco ", OleDbType.Char, 3).Value = BE.coleccionid.ToString();
                cmd.Parameters.Add("@pt700idtj ", OleDbType.Char, 3).Value = BE.tejidoid.ToString();
                cmd.Parameters.Add("@pt700fecho ", OleDbType.Date).Value = DateTime.Today.ToShortDateString();
                cmd.Parameters.Add("@temporadaid ", OleDbType.Char, 1).Value = BE.temporadaid.ToString();
                cmd.Parameters.Add("@estacionid ", OleDbType.Char, 1).Value = BE.estacionid.ToString();
                cmd.Parameters.Add("@parteid ", OleDbType.Char, 1).Value = BE.parte.ToString();
                cmd.Parameters.Add("@estructuraid ", OleDbType.Char, 1).Value = BE.estructuraid.ToString();
                cmd.Parameters.Add("@botapieid ", OleDbType.Char, 2).Value = BE.botapieid.ToString();
                cmd.Parameters.Add("@entalleid ", OleDbType.Char, 2).Value = BE.entalleid.ToString();
                cmd.Parameters.Add("@pt700idar ", OleDbType.Char, 7).Value = BE.articidold.ToString();

                cnx.Open();
                try
                {
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
       
        public bool Delete(string empresaid, tb_pt_articulo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtArticulo_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
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

        public DataSet GetAll(string empresaid, tb_pt_articulo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtArticulo_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
                        cmd.Parameters.Add("@articidold", SqlDbType.Char, 8).Value = BE.articidold;
                        cmd.Parameters.Add("@articname", SqlDbType.VarChar, 50).Value = BE.articname;
                        //cmd.Parameters.Add("@articdsav", SqlDbType.VarChar, 35).Value = BE.articdsav;
                        cmd.Parameters.Add("@categoriaid", SqlDbType.Char, 2).Value = BE.categoriaid;
                        cmd.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE.marcaid;
                        cmd.Parameters.Add("@lineaid", SqlDbType.Char, 2).Value = BE.lineaid;
                        cmd.Parameters.Add("@generoid", SqlDbType.Char, 1).Value = BE.generoid;
                        cmd.Parameters.Add("@tejidoid", SqlDbType.Char, 2).Value = BE.tejidoid;
                        cmd.Parameters.Add("@telaid", SqlDbType.Char, 10).Value = BE.telaid;
                        cmd.Parameters.Add("@telaidvfp", SqlDbType.Char, 10).Value = BE.telaidvfp;
                        cmd.Parameters.Add("@modeloid", SqlDbType.Char, 4).Value = BE.modeloid;
                        cmd.Parameters.Add("@estructuraid", SqlDbType.Char, 1).Value = BE.estructuraid;
                        cmd.Parameters.Add("@estacionid", SqlDbType.Char, 1).Value = BE.estacionid;
                        cmd.Parameters.Add("@temporadaid", SqlDbType.Char, 1).Value = BE.temporadaid;
                        cmd.Parameters.Add("@grupoid", SqlDbType.Char, 4).Value = BE.grupoid;
                        //cmd.Parameters.Add("@rubroid", SqlDbType.Char, 2).Value = BE.rubroid;
                        //cmd.Parameters.Add("@parte", SqlDbType.Char, 1).Value = BE.parte;
                        cmd.Parameters.Add("@tallaid", SqlDbType.Char, 2).Value = BE.tallaid;
                        cmd.Parameters.Add("@variante", SqlDbType.Char, 6).Value = BE.variante;
                        cmd.Parameters.Add("@codinge", SqlDbType.Char, 7).Value = BE.codinge;
                        //cmd.Parameters.Add("@estado", SqlDbType.Char, 2).Value = BE.estado;
                        //cmd.Parameters.Add("@foto", SqlDbType.VarChar, 50).Value = BE.foto;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        //cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                        /*search*/
                        cmd.Parameters.Add("@generoname", SqlDbType.VarChar, 20).Value = BE.generoname;
                        cmd.Parameters.Add("@marcaname", SqlDbType.VarChar, 20).Value = BE.marcaname;
                        cmd.Parameters.Add("@lineaname", SqlDbType.VarChar, 20).Value = BE.lineaname;

                        cmd.Parameters.Add("@top", SqlDbType.Bit).Value = BE.top;

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

        public DataSet GetAll2(string empresaid, tb_pt_articulo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtArticulo_SEARCH2", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
                        cmd.Parameters.Add("@articidold", SqlDbType.Char, 8).Value = BE.articidold;
                        cmd.Parameters.Add("@articname", SqlDbType.VarChar, 50).Value = BE.articname;
                        //cmd.Parameters.Add("@articdsav", SqlDbType.VarChar, 35).Value = BE.articdsav;
                        cmd.Parameters.Add("@categoriaid", SqlDbType.Char, 2).Value = BE.categoriaid;
                        cmd.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE.marcaid;
                        cmd.Parameters.Add("@lineaid", SqlDbType.Char, 2).Value = BE.lineaid;
                        cmd.Parameters.Add("@generoid", SqlDbType.Char, 1).Value = BE.generoid;
                        cmd.Parameters.Add("@tejidoid", SqlDbType.Char, 2).Value = BE.tejidoid;
                        cmd.Parameters.Add("@telaid", SqlDbType.Char, 10).Value = BE.telaid;
                        cmd.Parameters.Add("@telaidvfp", SqlDbType.Char, 10).Value = BE.telaidvfp;
                        cmd.Parameters.Add("@modeloid", SqlDbType.Char, 4).Value = BE.modeloid;
                        cmd.Parameters.Add("@estructuraid", SqlDbType.Char, 1).Value = BE.estructuraid;
                        cmd.Parameters.Add("@estacionid", SqlDbType.Char, 1).Value = BE.estacionid;
                        cmd.Parameters.Add("@temporadaid", SqlDbType.Char, 1).Value = BE.temporadaid;
                        cmd.Parameters.Add("@grupoid", SqlDbType.Char, 4).Value = BE.grupoid;
                        //cmd.Parameters.Add("@rubroid", SqlDbType.Char, 2).Value = BE.rubroid;
                        //cmd.Parameters.Add("@parte", SqlDbType.Char, 1).Value = BE.parte;
                        cmd.Parameters.Add("@tallaid", SqlDbType.Char, 2).Value = BE.tallaid;
                        cmd.Parameters.Add("@variante", SqlDbType.Char, 6).Value = BE.variante;
                        cmd.Parameters.Add("@codinge", SqlDbType.Char, 7).Value = BE.codinge;
                        //cmd.Parameters.Add("@estado", SqlDbType.Char, 2).Value = BE.estado;
                        //cmd.Parameters.Add("@foto", SqlDbType.VarChar, 50).Value = BE.foto;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        //cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                        /*search*/
                        cmd.Parameters.Add("@generoname", SqlDbType.VarChar, 20).Value = BE.generoname;
                        cmd.Parameters.Add("@marcaname", SqlDbType.VarChar, 20).Value = BE.marcaname;
                        cmd.Parameters.Add("@lineaname", SqlDbType.VarChar, 20).Value = BE.lineaname;

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

        public DataSet GetAll_DESCORT(string empresaid, tb_pt_articulo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtArticulo_SEARCH_DESCORT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;                                  
                        cmd.Parameters.Add("@variante", SqlDbType.Char, 6).Value = BE.variante;
          
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

        public DataSet GetAll_Color(string empresaid, tb_pt_articulo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtArticulo_SEARCH_color", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
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

        public DataSet GetAll_CODdbf(string empresaid, tb_pt_articulo BE)
        {
            Conex_FoxDA cone = new Conex_FoxDA();
            using (OleDbConnection cnx = new OleDbConnection(cone.AdmConexion()))
            {
                String commandString =
                "SELECT COUNT(*) cant FROM ptema700 WHERE pt700idar = ?";
                          
                using (OleDbCommand cmd = new OleDbCommand(commandString, cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.Add("@pt700idar ", OleDbType.Char, 7).Value = BE.articidold.ToString();
                    }
                    try
                    {
                        cnx.Open();
                        using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
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

        public DataSet GeneraCod(string empresaid, tb_pt_articulo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtArticulo_GENERA_cod", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE.marcaid;
                        cmd.Parameters.Add("@lineaid", SqlDbType.Char, 2).Value = BE.lineaid;
                        cmd.Parameters.Add("@modeloid", SqlDbType.Char, 4).Value = BE.modeloid;
                        cmd.Parameters.Add("@familiatelaid", SqlDbType.Char, 3).Value = BE.familiatelaid;                       
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

        public DataSet GeneraCod2(string empresaid, tb_pt_articulo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtArticulo_GENERA_cod2", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE.marcaid;
                        cmd.Parameters.Add("@modeloid", SqlDbType.Char, 4).Value = BE.modeloid;
                        cmd.Parameters.Add("@familiatelaid", SqlDbType.Char, 3).Value = BE.familiatelaid;
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

        public DataSet GetOne(string empresaid, string articid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtArticulo_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = articid;
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

        public bool Insert_Foto(string empresaid, tb_pt_articulo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtArticulo_INSERT_foto", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@articidold", SqlDbType.Char, 8).Value = BE.articidold;
                    cmd.Parameters.Add("@docname", SqlDbType.VarChar, 100).Value = BE.docname;
                    cmd.Parameters.Add("@foto", SqlDbType.Image).Value = BE.Foto;

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

        public bool Update_foto(string empresaid, tb_pt_articulo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtArticulo_UPDATE_foto", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@articidold", SqlDbType.Char, 8).Value = BE.articidold;
                        cmd.Parameters.Add("@docname", SqlDbType.VarChar, 100).Value = BE.docname;
                        cmd.Parameters.Add("@foto", SqlDbType.Image).Value = BE.Foto;
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

        public DataSet GetAll_foto(string empresaid, tb_pt_articulo BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtArticulo_SEARCH_foto", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@articidold", SqlDbType.Char, 8).Value = BE.articidold;
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
