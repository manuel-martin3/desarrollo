using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_plla_fichatrabajadoresDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_plla_fichatrabajadores BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadores_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@fichaid", SqlDbType.Char, 7).Value = BE.Fichaid;
                    cmd.Parameters.Add("@apepat", SqlDbType.VarChar, 20).Value = BE.Apepat;
                    cmd.Parameters.Add("@apemat", SqlDbType.VarChar, 20).Value = BE.Apemat;
                    cmd.Parameters.Add("@nombres", SqlDbType.VarChar, 20).Value = BE.Nombres;
                    cmd.Parameters.Add("@nombrelargo", SqlDbType.VarChar, 60).Value = BE.Nombrelargo;
                    cmd.Parameters.Add("@tipdocid", SqlDbType.Char, 2).Value = BE.Tipdocid;
                    cmd.Parameters.Add("@nrodni", SqlDbType.Char, 8).Value = BE.Nrodni;
                    cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.Nmruc;
                    cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 60).Value = BE.Ctactename;
                    cmd.Parameters.Add("@direcc", SqlDbType.VarChar, 60).Value = BE.Direcc;
                    cmd.Parameters.Add("@ubiged", SqlDbType.Char, 6).Value = BE.Ubiged;
                    cmd.Parameters.Add("@ubigen", SqlDbType.Char, 6).Value = BE.Ubigen;
                    cmd.Parameters.Add("@estadocivil", SqlDbType.Char, 1).Value = BE.Estadocivil;
                    cmd.Parameters.Add("@sexo", SqlDbType.Char, 1).Value = BE.Sexo;
                    cmd.Parameters.Add("@telef1", SqlDbType.VarChar, 20).Value = BE.Telef1;
                    cmd.Parameters.Add("@telef2", SqlDbType.VarChar, 20).Value = BE.Telef2;
                    cmd.Parameters.Add("@carnetsegsoc", SqlDbType.VarChar, 20).Value = BE.Carnetsegsoc;
                    cmd.Parameters.Add("@fechnacimiento", SqlDbType.DateTime).Value = BE.Fechnacimiento;
                    cmd.Parameters.Add("@fechingreso", SqlDbType.DateTime).Value = BE.Fechingreso;
                    cmd.Parameters.Add("@situtrabid", SqlDbType.Char, 2).Value = BE.Situtrabid;
                    cmd.Parameters.Add("@sctr", SqlDbType.Bit).Value = BE.Sctr;
                    cmd.Parameters.Add("@remintegral", SqlDbType.Bit).Value = BE.Remintegral;
                    cmd.Parameters.Add("@autocontrol", SqlDbType.Bit).Value = BE.Autocontrol;
                    cmd.Parameters.Add("@chkdephab", SqlDbType.Bit).Value = BE.Chkdephab;
                    cmd.Parameters.Add("@bancoidhab", SqlDbType.Char, 2).Value = BE.Bancoidhab;
                    cmd.Parameters.Add("@ctahaberes", SqlDbType.VarChar, 24).Value = BE.Ctahaberes;
                    cmd.Parameters.Add("@chkdepcts", SqlDbType.Bit).Value = BE.Chkdepcts;
                    cmd.Parameters.Add("@bancoidcts", SqlDbType.Char, 2).Value = BE.Bancoidcts;
                    cmd.Parameters.Add("@ctacts", SqlDbType.VarChar, 24).Value = BE.Ctacts;
                    cmd.Parameters.Add("@tipodeta", SqlDbType.Char, 2).Value = BE.Tipodeta;
                    cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.Cencosid;
                    cmd.Parameters.Add("@cargoid", SqlDbType.Char, 3).Value = BE.Cargoid;
                    cmd.Parameters.Add("@detallecontable", SqlDbType.Char, 11).Value = BE.Detallecontable;
                    cmd.Parameters.Add("@regipenid", SqlDbType.Char, 2).Value = BE.Regipenid;
                    cmd.Parameters.Add("@cuspp", SqlDbType.Char, 15).Value = BE.Cuspp;
                    cmd.Parameters.Add("@fechafiliacion", SqlDbType.DateTime).Value = BE.Fechafiliacion;
                    cmd.Parameters.Add("@tipcomisionafp", SqlDbType.Char, 1).Value = BE.Tipcomisionafp;
                    cmd.Parameters.Add("@essaludvida", SqlDbType.Bit).Value = BE.Essaludvida;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar, 60).Value = BE.Email;
                    cmd.Parameters.Add("@niveleduid", SqlDbType.Char, 2).Value = BE.Niveleduid;
                    cmd.Parameters.Add("@discapacitado", SqlDbType.Bit).Value = BE.Discapacitado;
                    cmd.Parameters.Add("@tipestabid", SqlDbType.Char, 2).Value = BE.Tipestabid;
                    cmd.Parameters.Add("@cateocupid", SqlDbType.Char, 1).Value = BE.Cateocupid;
                    cmd.Parameters.Add("@fotografia", SqlDbType.VarChar, 254).Value = BE.Fotografia;
                    cmd.Parameters.Add("@observacion", SqlDbType.Text).Value = BE.Observacion;
                    cmd.Parameters.Add("@fechregistro", SqlDbType.DateTime).Value = BE.Fechregistro;
                    cmd.Parameters.Add("@activo", SqlDbType.Char, 1).Value = BE.Activo;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.Status;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.Usuar;
                    cmd.Parameters.Add("@viaid", SqlDbType.Char, 2).Value = BE.Viaid;
                    cmd.Parameters.Add("@zonaid", SqlDbType.Char, 2).Value = BE.Zonaid;
                    cmd.Parameters.Add("@epsid", SqlDbType.Char, 1).Value = BE.Epsid;
                    cmd.Parameters.Add("@tippagoid", SqlDbType.Char, 1).Value = BE.Tippagoid;
                    cmd.Parameters.Add("@convendobletribid", SqlDbType.Char, 1).Value = BE.Convendobletribid;
                    cmd.Parameters.Add("@tipsuspenid", SqlDbType.Char, 2).Value = BE.Tipsuspenid;
                    //cmd.Parameters.Add("@fecre", SqlDbType.DateTime).Value = BE.Fecre;
                    //cmd.Parameters.Add("@feact", SqlDbType.DateTime).Value = BE.Feact;
                     
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

        public bool Insert_Update(string empresaid, DataTable tablatrabajadores, DataTable tablacontratos, DataTable tablarubroscontrato)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                bool xreturn = true;
                int lc_contcab = 0;
                int lccontdetalle = 0;
                for (lc_contcab = 0; lc_contcab <= tablatrabajadores.Rows.Count - 1; lc_contcab++)
                {
                    if ((tablacontratos != null))
                    {
                        using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadorescontratos_ELIMINAR", cnx))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@fichaid", SqlDbType.Char, 7).Value = tablatrabajadores.Rows[lc_contcab]["fichaid"];
                            cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = tablatrabajadores.Rows[lc_contcab]["empresaid"];
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

                    if ((tablarubroscontrato != null))
                    {
                        using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadoresrubros_ELIMINAR", cnx))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@fichaid", SqlDbType.Char, 7).Value = tablatrabajadores.Rows[lc_contcab]["fichaid"];
                            cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = tablatrabajadores.Rows[lc_contcab]["empresaid"];
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

                    using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadores_InsertUpdate", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@empresaid", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["empresaid"];
                        cmd.Parameters.Add("@fichaid", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["fichaid"];
                        cmd.Parameters.Add("@apepat", SqlDbType.VarChar).Value = tablatrabajadores.Rows[lc_contcab]["apepat"];
                        cmd.Parameters.Add("@apemat", SqlDbType.VarChar).Value = tablatrabajadores.Rows[lc_contcab]["apemat"];
                        cmd.Parameters.Add("@nombres", SqlDbType.VarChar).Value = tablatrabajadores.Rows[lc_contcab]["nombres"];
                        cmd.Parameters.Add("@nombrelargo", SqlDbType.VarChar).Value = tablatrabajadores.Rows[lc_contcab]["nombrelargo"];
                        cmd.Parameters.Add("@tipdocid", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["tipdocid"];
                        cmd.Parameters.Add("@nrodni", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["nrodni"];
                        cmd.Parameters.Add("@nmruc", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["nmruc"];
                        cmd.Parameters.Add("@ctactename", SqlDbType.VarChar).Value = tablatrabajadores.Rows[lc_contcab]["ctactename"];
                        cmd.Parameters.Add("@direcc", SqlDbType.VarChar).Value = tablatrabajadores.Rows[lc_contcab]["direcc"];
                        cmd.Parameters.Add("@ubiged", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["ubiged"];
                        cmd.Parameters.Add("@ubigen", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["ubigen"];
                        cmd.Parameters.Add("@estadocivil", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["estadocivil"];
                        cmd.Parameters.Add("@sexo", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["sexo"];
                        cmd.Parameters.Add("@telef1", SqlDbType.VarChar).Value = tablatrabajadores.Rows[lc_contcab]["telef1"];
                        cmd.Parameters.Add("@telef2", SqlDbType.VarChar).Value = tablatrabajadores.Rows[lc_contcab]["telef2"];
                        cmd.Parameters.Add("@carnetsegsoc", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["carnetsegsoc"];
                        cmd.Parameters.Add("@fechnacimiento", SqlDbType.DateTime).Value = tablatrabajadores.Rows[lc_contcab]["fechnacimiento"];
                        cmd.Parameters.Add("@fechingreso", SqlDbType.DateTime).Value = tablatrabajadores.Rows[lc_contcab]["fechingreso"];
                        cmd.Parameters.Add("@situtrabid", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["situtrabid"];
                        cmd.Parameters.Add("@sctr", SqlDbType.Bit).Value = tablatrabajadores.Rows[lc_contcab]["sctr"];
                        cmd.Parameters.Add("@remintegral", SqlDbType.Bit).Value = tablatrabajadores.Rows[lc_contcab]["remintegral"];
                        cmd.Parameters.Add("@autocontrol", SqlDbType.Bit).Value = tablatrabajadores.Rows[lc_contcab]["autocontrol"];
                        cmd.Parameters.Add("@chkdephab", SqlDbType.Bit).Value = tablatrabajadores.Rows[lc_contcab]["chkdephab"];
                        cmd.Parameters.Add("@bancoidhab", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["bancoidhab"];
                        cmd.Parameters.Add("@ctahaberes", SqlDbType.VarChar).Value = tablatrabajadores.Rows[lc_contcab]["ctahaberes"];
                        cmd.Parameters.Add("@chkdepcts", SqlDbType.Bit).Value = tablatrabajadores.Rows[lc_contcab]["chkdepcts"];
                        cmd.Parameters.Add("@bancoidcts", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["bancoidcts"];
                        cmd.Parameters.Add("@ctacts", SqlDbType.VarChar).Value = tablatrabajadores.Rows[lc_contcab]["ctacts"];
                        cmd.Parameters.Add("@tipodeta", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["tipodeta"];
                        cmd.Parameters.Add("@cencosid", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["cencosid"];
                        cmd.Parameters.Add("@cargoid", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["cargoid"];
                        cmd.Parameters.Add("@detallecontable", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["detallecontable"];
                        cmd.Parameters.Add("@regipenid", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["regipenid"];
                        cmd.Parameters.Add("@cuspp", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["cuspp"];
                        cmd.Parameters.Add("@fechafiliacion", SqlDbType.DateTime).Value = tablatrabajadores.Rows[lc_contcab]["fechafiliacion"];
                        cmd.Parameters.Add("@tipcomisionafp", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["tipcomisionafp"];
                        cmd.Parameters.Add("@essaludvida", SqlDbType.Bit).Value = tablatrabajadores.Rows[lc_contcab]["essaludvida"];
                        cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = tablatrabajadores.Rows[lc_contcab]["email"];
                        cmd.Parameters.Add("@niveleduid", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["niveleduid"];
                        cmd.Parameters.Add("@discapacitado", SqlDbType.Bit).Value = tablatrabajadores.Rows[lc_contcab]["discapacitado"];
                        cmd.Parameters.Add("@tipestabid", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["tipestabid"];
                        cmd.Parameters.Add("@establec", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["establec"];
                        cmd.Parameters.Add("@cateocupid", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["cateocupid"];                           
                        cmd.Parameters.Add("@fotografia", SqlDbType.VarChar).Value = tablatrabajadores.Rows[lc_contcab]["fotografia"];
                        cmd.Parameters.Add("@observacion", SqlDbType.Text).Value = tablatrabajadores.Rows[lc_contcab]["observacion"];
                        cmd.Parameters.Add("@fechregistro", SqlDbType.DateTime).Value = tablatrabajadores.Rows[lc_contcab]["fechregistro"];
                        cmd.Parameters.Add("@tipoplla", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["tipoplla"];
                        cmd.Parameters.Add("@motivocese", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["motivocese"];
                        cmd.Parameters.Add("@fechcese", SqlDbType.DateTime).Value = tablatrabajadores.Rows[lc_contcab]["fechcese"];
                        cmd.Parameters.Add("@activo", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["activo"];
                        cmd.Parameters.Add("@viaid", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["viaid"];
                        cmd.Parameters.Add("@zonaid", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["zonaid"];
                        cmd.Parameters.Add("@epsid", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["epsid"];
                        cmd.Parameters.Add("@situtrab", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["situtrab"];
                        cmd.Parameters.Add("@tippagoid", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["tippagoid"];
                        cmd.Parameters.Add("@chkconvenio", SqlDbType.Bit).Value = tablatrabajadores.Rows[lc_contcab]["chkconvenio"];
                        cmd.Parameters.Add("@convendobletribid", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["convendobletribid"];
                        cmd.Parameters.Add("@tipsuspenid", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["tipsuspenid"];
                        cmd.Parameters.Add("@paisid", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["paisid"];
                        cmd.Parameters.Add("@status", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["status"];
                        cmd.Parameters.Add("@usuar", SqlDbType.Char).Value = tablatrabajadores.Rows[lc_contcab]["usuar"];
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
                        //AddStore("spu_creadetallestrabajadores");
                        //AddParametro("@ccia", SqlDbType.Char, tablatrabajadores.Rows[lc_contcab]["ccia"]);
                        //AddParametro("@fichaini", SqlDbType.Char, tablatrabajadores.Rows[lc_contcab]["fichp_10"]);
                        //AddParametro("@fichafin", SqlDbType.Char, tablatrabajadores.Rows[lc_contcab]["fichp_10"]);
                        //retorno = COMANDOSQL.ExecuteNonQuery();
                        //COMANDOSQL.Parameters.Clear();

                        if ((tablacontratos != null))
                        {
                            for (lccontdetalle = 0; lccontdetalle <= tablacontratos.Rows.Count - 1; lccontdetalle++)
                            {
                                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadorescontratos_InsertUpdate", cnx))
                                {
                                    cmd.CommandTimeout = 0;
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.Add("@empresaid", SqlDbType.Char).Value = tablacontratos.Rows[lccontdetalle]["empresaid"];
                                    cmd.Parameters.Add("@fichaid", SqlDbType.Char).Value = tablacontratos.Rows[lccontdetalle]["fichaid"];
                                    cmd.Parameters.Add("@ncontrato", SqlDbType.Char).Value = tablacontratos.Rows[lccontdetalle]["ncontrato"];
                                    cmd.Parameters.Add("@ncomiezo", SqlDbType.Char).Value = tablacontratos.Rows[lccontdetalle]["ncomiezo"];
                                    cmd.Parameters.Add("@vlfechaini", SqlDbType.DateTime).Value = tablacontratos.Rows[lccontdetalle]["vlfechaini"];
                                    cmd.Parameters.Add("@vlfechafin", SqlDbType.DateTime).Value = tablacontratos.Rows[lccontdetalle]["vlfechafin"];
                                    cmd.Parameters.Add("@dcfechaini", SqlDbType.DateTime).Value = tablacontratos.Rows[lccontdetalle]["dcfechaini"];
                                    cmd.Parameters.Add("@dcfechafin", SqlDbType.DateTime).Value = tablacontratos.Rows[lccontdetalle]["dcfechafin"];
                                    cmd.Parameters.Add("@horarioentrada", SqlDbType.Decimal).Value = tablacontratos.Rows[lccontdetalle]["horarioentrada"];
                                    cmd.Parameters.Add("@minutosentrada", SqlDbType.Decimal).Value = tablacontratos.Rows[lccontdetalle]["minutosentrada"];
                                    cmd.Parameters.Add("@horariosalida", SqlDbType.Decimal).Value = tablacontratos.Rows[lccontdetalle]["horariosalida"];
                                    cmd.Parameters.Add("@minutossalida", SqlDbType.Decimal).Value = tablacontratos.Rows[lccontdetalle]["minutossalida"];
                                    cmd.Parameters.Add("@tipoplla", SqlDbType.Char).Value = tablacontratos.Rows[lccontdetalle]["tipoplla"];
                                    cmd.Parameters.Add("@moneda", SqlDbType.Char).Value = tablacontratos.Rows[lccontdetalle]["moneda"];
                                    cmd.Parameters.Add("@remuneracion", SqlDbType.Decimal).Value = tablacontratos.Rows[lccontdetalle]["remuneracion"];
                                    cmd.Parameters.Add("@estado", SqlDbType.Char).Value = tablacontratos.Rows[lccontdetalle]["estado"];
                                    cmd.Parameters.Add("@observcese", SqlDbType.Text).Value = tablacontratos.Rows[lccontdetalle]["observcese"];
                                    cmd.Parameters.Add("@nuevo", SqlDbType.Char).Value = tablacontratos.Rows[lccontdetalle]["nuevo"];
                                    cmd.Parameters.Add("@vigencia", SqlDbType.Bit).Value = tablacontratos.Rows[lccontdetalle]["vigencia"];
                                    cmd.Parameters.Add("@status", SqlDbType.Char).Value = tablacontratos.Rows[lccontdetalle]["status"];
                                    cmd.Parameters.Add("@tipcontratoid", SqlDbType.Char).Value = tablacontratos.Rows[lccontdetalle]["tipcontratoid"];
                                    cmd.Parameters.Add("@motfinperiodid", SqlDbType.Char).Value = tablacontratos.Rows[lccontdetalle]["motfinperiodid"];
                                    cmd.Parameters.Add("@tipmodalformid", SqlDbType.Char).Value = tablacontratos.Rows[lccontdetalle]["tipmodalformid"];
                                    cmd.Parameters.Add("@tparcial", SqlDbType.Bit).Value = tablacontratos.Rows[lccontdetalle]["tparcial"];

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

                        if ((tablarubroscontrato != null))
                        {
                            for (lccontdetalle = 0; lccontdetalle <= tablarubroscontrato.Rows.Count - 1; lccontdetalle++)
                            {
                                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadoresrubros_InsertUpdate", cnx))
                                {
                                    cmd.CommandTimeout = 0;
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.Add("@empresaid", SqlDbType.Char).Value = tablarubroscontrato.Rows[lccontdetalle]["empresaid"];
                                    cmd.Parameters.Add("@fichaid", SqlDbType.Char).Value = tablarubroscontrato.Rows[lccontdetalle]["fichaid"];
                                    cmd.Parameters.Add("@ncontrato", SqlDbType.Char).Value = tablarubroscontrato.Rows[lccontdetalle]["ncontrato"];
                                    cmd.Parameters.Add("@rubroid", SqlDbType.Char).Value = tablarubroscontrato.Rows[lccontdetalle]["rubroid"];
                                    cmd.Parameters.Add("@importediario", SqlDbType.Decimal).Value = tablarubroscontrato.Rows[lccontdetalle]["importediario"];
                                    cmd.Parameters.Add("@importemensual", SqlDbType.Decimal).Value = tablarubroscontrato.Rows[lccontdetalle]["importemensual"];
                                    cmd.Parameters.Add("@fijo", SqlDbType.Char).Value = tablarubroscontrato.Rows[lccontdetalle]["fijo"];
                                    cmd.Parameters.Add("@consimporte", SqlDbType.Bit).Value = tablarubroscontrato.Rows[lccontdetalle]["consimporte"];
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
                        //Sql_Error = ex.Message;
                        //retorno = 0;
                        //break;
                    }
                }
                return xreturn;
            }
        }

        public bool Update(string empresaid, tb_plla_fichatrabajadores BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadores_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = BE.Empresaid;
                        cmd.Parameters.Add("@fichaid", SqlDbType.Char, 7).Value = BE.Fichaid;
                        cmd.Parameters.Add("@apepat", SqlDbType.VarChar, 20).Value = BE.Apepat;
                        cmd.Parameters.Add("@apemat", SqlDbType.VarChar, 20).Value = BE.Apemat;
                        cmd.Parameters.Add("@nombres", SqlDbType.VarChar, 20).Value = BE.Nombres;
                        cmd.Parameters.Add("@nombrelargo", SqlDbType.VarChar, 60).Value = BE.Nombrelargo;
                        cmd.Parameters.Add("@tipdocid", SqlDbType.Char, 2).Value = BE.Tipdocid;
                        cmd.Parameters.Add("@nrodni", SqlDbType.Char, 8).Value = BE.Nrodni;
                        cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.Nmruc;
                        cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 60).Value = BE.Ctactename;
                        cmd.Parameters.Add("@direcc", SqlDbType.VarChar, 60).Value = BE.Direcc;
                        cmd.Parameters.Add("@ubiged", SqlDbType.Char, 6).Value = BE.Ubiged;
                        cmd.Parameters.Add("@ubigen", SqlDbType.Char, 6).Value = BE.Ubigen;
                        cmd.Parameters.Add("@estadocivil", SqlDbType.Char, 1).Value = BE.Estadocivil;
                        cmd.Parameters.Add("@sexo", SqlDbType.Char, 1).Value = BE.Sexo;
                        cmd.Parameters.Add("@telef1", SqlDbType.VarChar, 20).Value = BE.Telef1;
                        cmd.Parameters.Add("@telef2", SqlDbType.VarChar, 20).Value = BE.Telef2;
                        cmd.Parameters.Add("@carnetsegsoc", SqlDbType.VarChar, 20).Value = BE.Carnetsegsoc;
                        cmd.Parameters.Add("@fechnacimiento", SqlDbType.DateTime).Value = BE.Fechnacimiento;
                        cmd.Parameters.Add("@fechingreso", SqlDbType.DateTime).Value = BE.Fechingreso;
                        cmd.Parameters.Add("@situtrabid", SqlDbType.Char, 2).Value = BE.Situtrabid;
                        cmd.Parameters.Add("@sctr", SqlDbType.Bit).Value = BE.Sctr;
                        cmd.Parameters.Add("@remintegral", SqlDbType.Bit).Value = BE.Remintegral;
                        cmd.Parameters.Add("@autocontrol", SqlDbType.Bit).Value = BE.Autocontrol;
                        cmd.Parameters.Add("@chkdephab", SqlDbType.Bit).Value = BE.Chkdephab;
                        cmd.Parameters.Add("@bancoidhab", SqlDbType.Char, 2).Value = BE.Bancoidhab;
                        cmd.Parameters.Add("@ctahaberes", SqlDbType.VarChar, 24).Value = BE.Ctahaberes;
                        cmd.Parameters.Add("@chkdepcts", SqlDbType.Bit).Value = BE.Chkdepcts;
                        cmd.Parameters.Add("@bancoidcts", SqlDbType.Char, 2).Value = BE.Bancoidcts;
                        cmd.Parameters.Add("@ctacts", SqlDbType.VarChar, 24).Value = BE.Ctacts;
                        cmd.Parameters.Add("@tipodeta", SqlDbType.Char, 2).Value = BE.Tipodeta;
                        cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.Cencosid;
                        cmd.Parameters.Add("@cargoid", SqlDbType.Char, 3).Value = BE.Cargoid;
                        cmd.Parameters.Add("@detallecontable", SqlDbType.Char, 11).Value = BE.Detallecontable;
                        cmd.Parameters.Add("@regipenid", SqlDbType.Char, 2).Value = BE.Regipenid;
                        cmd.Parameters.Add("@cuspp", SqlDbType.Char, 15).Value = BE.Cuspp;
                        cmd.Parameters.Add("@fechafiliacion", SqlDbType.DateTime).Value = BE.Fechafiliacion;
                        cmd.Parameters.Add("@tipcomisionafp", SqlDbType.Char, 1).Value = BE.Tipcomisionafp;
                        cmd.Parameters.Add("@essaludvida", SqlDbType.Bit).Value = BE.Essaludvida;
                        cmd.Parameters.Add("@email", SqlDbType.VarChar, 60).Value = BE.Email;
                        cmd.Parameters.Add("@niveleduid", SqlDbType.Char, 2).Value = BE.Niveleduid;
                        cmd.Parameters.Add("@discapacitado", SqlDbType.Bit).Value = BE.Discapacitado;
                        cmd.Parameters.Add("@tipestabid", SqlDbType.Char, 2).Value = BE.Tipestabid;
                        cmd.Parameters.Add("@cateocupid", SqlDbType.Char, 1).Value = BE.Cateocupid;
                        cmd.Parameters.Add("@fotografia", SqlDbType.VarChar, 254).Value = BE.Fotografia;
                        cmd.Parameters.Add("@observacion", SqlDbType.Text).Value = BE.Observacion;
                        cmd.Parameters.Add("@fechregistro", SqlDbType.DateTime).Value = BE.Fechregistro;
                        cmd.Parameters.Add("@activo", SqlDbType.Char, 1).Value = BE.Activo;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.Status;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.Usuar;
                        cmd.Parameters.Add("@viaid", SqlDbType.Char, 2).Value = BE.Viaid;
                        cmd.Parameters.Add("@zonaid", SqlDbType.Char, 2).Value = BE.Zonaid;
                        cmd.Parameters.Add("@epsid", SqlDbType.Char, 1).Value = BE.Epsid;
                        cmd.Parameters.Add("@tippagoid", SqlDbType.Char, 1).Value = BE.Tippagoid;
                        cmd.Parameters.Add("@convendobletribid", SqlDbType.Char, 1).Value = BE.Convendobletribid;
                        cmd.Parameters.Add("@tipsuspenid", SqlDbType.Char, 2).Value = BE.Tipsuspenid;
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

        public bool Delete(string empresaid, tb_plla_fichatrabajadores BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadores_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@fichaid", SqlDbType.Char, 7).Value = BE.Fichaid;
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
        public bool Eliminar(string empresaid, DataTable tablatrabajadores)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                bool xreturn = true;
                int lcont = 0;
                for (lcont = 0; lcont <= tablatrabajadores.Rows.Count - 1; lcont++)
                {
                    using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadores_ELIMINAR", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@fichaid", SqlDbType.Char).Value = tablatrabajadores.Rows[lcont]["fichaid"];
                        cmd.Parameters.Add("@empresaid", SqlDbType.Char).Value = tablatrabajadores.Rows[lcont]["empresaid"];
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

        public DataSet GetAll(string empresaid, tb_plla_fichatrabajadores BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadores_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@empresaid", SqlDbType.Char, 7).Value = BE.Empresaid;
                        cmd.Parameters.Add("@fichaid", SqlDbType.Char, 7).Value = BE.Fichaid;
                        cmd.Parameters.Add("@apepat", SqlDbType.VarChar, 20).Value = BE.Apepat;
                        cmd.Parameters.Add("@apemat", SqlDbType.VarChar, 20).Value = BE.Apemat;
                        cmd.Parameters.Add("@nombres", SqlDbType.VarChar, 20).Value = BE.Nombres;
                        cmd.Parameters.Add("@nombrelargo", SqlDbType.VarChar, 60).Value = BE.Nombrelargo;
                        cmd.Parameters.Add("@tipdocid", SqlDbType.Char, 2).Value = BE.Tipdocid;
                        cmd.Parameters.Add("@nrodni", SqlDbType.Char, 8).Value = BE.Nrodni;
                        cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.Nmruc;
                        cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 60).Value = BE.Ctactename;
                        cmd.Parameters.Add("@direcc", SqlDbType.VarChar, 60).Value = BE.Direcc;
                        cmd.Parameters.Add("@ubiged", SqlDbType.Char, 6).Value = BE.Ubiged;
                        cmd.Parameters.Add("@ubigen", SqlDbType.Char, 6).Value = BE.Ubigen;
                        cmd.Parameters.Add("@estadocivil", SqlDbType.Char, 1).Value = BE.Estadocivil;
                        cmd.Parameters.Add("@sexo", SqlDbType.Char, 1).Value = BE.Sexo;
                        cmd.Parameters.Add("@telef1", SqlDbType.VarChar, 20).Value = BE.Telef1;
                        cmd.Parameters.Add("@telef2", SqlDbType.VarChar, 20).Value = BE.Telef2;
                        cmd.Parameters.Add("@carnetsegsoc", SqlDbType.VarChar, 20).Value = BE.Carnetsegsoc;
                        //cmd.Parameters.Add("@fechnacimiento", SqlDbType.DateTime).Value = BE.Fechnacimiento;
                        //cmd.Parameters.Add("@fechingreso", SqlDbType.DateTime).Value = BE.Fechingreso;
                        cmd.Parameters.Add("@situtrabid", SqlDbType.Char, 2).Value = BE.Situtrabid;
                        //cmd.Parameters.Add("@sctr", SqlDbType.Bit).Value = BE.Sctr;
                        //cmd.Parameters.Add("@remintegral", SqlDbType.Bit).Value = BE.Remintegral;
                        //cmd.Parameters.Add("@autocontrol", SqlDbType.Bit).Value = BE.Autocontrol;
                        //cmd.Parameters.Add("@chkdephab", SqlDbType.Bit).Value = BE.Chkdephab;
                        cmd.Parameters.Add("@bancoidhab", SqlDbType.Char, 2).Value = BE.Bancoidhab;
                        cmd.Parameters.Add("@ctahaberes", SqlDbType.VarChar, 24).Value = BE.Ctahaberes;
                        //cmd.Parameters.Add("@chkdepcts", SqlDbType.Bit).Value = BE.Chkdepcts;
                        cmd.Parameters.Add("@bancoidcts", SqlDbType.Char, 2).Value = BE.Bancoidcts;
                        cmd.Parameters.Add("@ctacts", SqlDbType.VarChar, 24).Value = BE.Ctacts;
                        cmd.Parameters.Add("@tipodeta", SqlDbType.Char, 2).Value = BE.Tipodeta;
                        cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.Cencosid;
                        cmd.Parameters.Add("@cargoid", SqlDbType.Char, 3).Value = BE.Cargoid;
                        cmd.Parameters.Add("@detallecontable", SqlDbType.Char, 11).Value = BE.Detallecontable;
                        cmd.Parameters.Add("@regipenid", SqlDbType.Char, 2).Value = BE.Regipenid;
                        cmd.Parameters.Add("@cuspp", SqlDbType.Char, 15).Value = BE.Cuspp;
                        //cmd.Parameters.Add("@fechafiliacion", SqlDbType.DateTime).Value = BE.Fechafiliacion;
                        cmd.Parameters.Add("@tipcomisionafp", SqlDbType.Char, 1).Value = BE.Tipcomisionafp;
                        //cmd.Parameters.Add("@essaludvida", SqlDbType.Bit).Value = BE.Essaludvida;
                        cmd.Parameters.Add("@email", SqlDbType.VarChar, 60).Value = BE.Email;
                        cmd.Parameters.Add("@niveleduid", SqlDbType.Char, 2).Value = BE.Niveleduid;
                        //cmd.Parameters.Add("@discapacitado", SqlDbType.Bit).Value = BE.Discapacitado;
                        cmd.Parameters.Add("@tipestabid", SqlDbType.Char, 2).Value = BE.Tipestabid;
                        cmd.Parameters.Add("@cateocupid", SqlDbType.Char, 1).Value = BE.Cateocupid;
                        //cmd.Parameters.Add("@fotografia", SqlDbType.VarChar, 254).Value = BE.Fotografia;
                        //cmd.Parameters.Add("@observacion", SqlDbType.Text).Value = BE.Observacion;
                        //cmd.Parameters.Add("@fechregistro", SqlDbType.DateTime).Value = BE.Fechregistro;
                        cmd.Parameters.Add("@activo", SqlDbType.Char, 1).Value = BE.Activo;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.Status;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.Usuar;
                        cmd.Parameters.Add("@viaid", SqlDbType.Char, 2).Value = BE.Viaid;
                        cmd.Parameters.Add("@zonaid", SqlDbType.Char, 2).Value = BE.Zonaid;
                        cmd.Parameters.Add("@epsid", SqlDbType.Char, 1).Value = BE.Epsid;
                        cmd.Parameters.Add("@tippagoid", SqlDbType.Char, 1).Value = BE.Tippagoid;
                        cmd.Parameters.Add("@convendobletribid", SqlDbType.Char, 1).Value = BE.Convendobletribid;
                        cmd.Parameters.Add("@tipsuspenid", SqlDbType.Char, 2).Value = BE.Tipsuspenid;
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

        public DataSet GetAll_Consulta(string empresaid, tb_plla_fichatrabajadores BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadores_CONSULTA", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@empresaid", string.IsNullOrEmpty(BE.Empresaid) ? (object)DBNull.Value : BE.Empresaid);
                        cmd.Parameters.AddWithValue("@fichaid", string.IsNullOrEmpty(BE.Fichaid) ? (object)DBNull.Value : BE.Fichaid);
                        cmd.Parameters.AddWithValue("@tipdocid", string.IsNullOrEmpty(BE.Tipdocid) ? (object)DBNull.Value : BE.Tipdocid);
                        cmd.Parameters.AddWithValue("@nrodni", string.IsNullOrEmpty(BE.Nrodni) ? (object)DBNull.Value : BE.Nrodni);
                        cmd.Parameters.AddWithValue("@nmruc", string.IsNullOrEmpty(BE.Nmruc) ? (object)DBNull.Value : BE.Nmruc);
                        cmd.Parameters.Add("@norden", SqlDbType.Int).Value = BE.Norden;
                        cmd.Parameters.AddWithValue("@nomlike1", string.IsNullOrEmpty(BE.Nomlike1) ? (object)DBNull.Value : BE.Nomlike1);
                        cmd.Parameters.AddWithValue("@nomlike2", string.IsNullOrEmpty(BE.Nomlike2) ? (object)DBNull.Value : BE.Nomlike2);
                        cmd.Parameters.AddWithValue("@nomlike3", string.IsNullOrEmpty(BE.Nomlike3) ? (object)DBNull.Value : BE.Nomlike3);
                        cmd.Parameters.Add("@estado_trabaj", SqlDbType.Int).Value = BE.Estado_trabaj;
                        cmd.Parameters.AddWithValue("@tipo_plla", string.IsNullOrEmpty(BE.Tipoplla) ? (object)DBNull.Value : BE.Tipoplla);
                        cmd.Parameters.AddWithValue("@estadotrab", string.IsNullOrEmpty(BE.Situtrabid) ? (object)DBNull.Value : BE.Situtrabid);
                        cmd.Parameters.AddWithValue("@tipolocal", string.IsNullOrEmpty(BE.Establec) ? (object)DBNull.Value : BE.Establec);
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
        public DataSet GetAll_ConsultaMaxCod(string empresaid, String Codigo)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllafichatrabajadores_MaxCodigo", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@codigo", string.IsNullOrEmpty(Codigo) ? (object)DBNull.Value : Codigo);
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

        public DataSet GetAll_FichaDatos(string empresaid, tb_plla_fichatrabajadores BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadores_FichaDatos", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@empresaid", string.IsNullOrEmpty(BE.Empresaid) ? (object)DBNull.Value : BE.Empresaid);
                        cmd.Parameters.AddWithValue("@fichaidIni", string.IsNullOrEmpty(BE.FichaidIni) ? (object)DBNull.Value : BE.FichaidIni);
                        cmd.Parameters.AddWithValue("@fichaidFin", string.IsNullOrEmpty(BE.FichaidFin) ? (object)DBNull.Value : BE.FichaidFin);
                        cmd.Parameters.AddWithValue("@cencosid", string.IsNullOrEmpty(BE.Cencosid) ? (object)DBNull.Value : BE.Cencosid);
                        cmd.Parameters.Add("@nOrden", SqlDbType.Int).Value = BE.Norden;
                        cmd.Parameters.AddWithValue("@situtrabid", string.IsNullOrEmpty(BE.Situtrabid) ? (object)DBNull.Value : BE.Situtrabid);
                        cmd.Parameters.AddWithValue("@tipoplla", string.IsNullOrEmpty(BE.Tipoplla) ? (object)DBNull.Value : BE.Tipoplla);
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

        public DataSet GetAll_GeneraDatosFormatoContrato(string empresaid, tb_plla_fichatrabajadores BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadores_GeneraDatosFormatoContrato", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@empresaid", string.IsNullOrEmpty(BE.Empresaid) ? (object)DBNull.Value : BE.Empresaid);
                        cmd.Parameters.AddWithValue("@fichaini", string.IsNullOrEmpty(BE.FichaidIni) ? (object)DBNull.Value : BE.FichaidIni);
                        cmd.Parameters.AddWithValue("@fichafin", string.IsNullOrEmpty(BE.FichaidFin) ? (object)DBNull.Value : BE.FichaidFin);
                        cmd.Parameters.AddWithValue("@cencosid", string.IsNullOrEmpty(BE.Cencosid) ? (object)DBNull.Value : BE.Cencosid);
                        cmd.Parameters.AddWithValue("@cargoid", string.IsNullOrEmpty(BE.Cargoid) ? (object)DBNull.Value : BE.Cargoid);
                        cmd.Parameters.AddWithValue("@situtrabid", string.IsNullOrEmpty(BE.Situtrabid) ? (object)DBNull.Value : BE.Situtrabid);
                        cmd.Parameters.AddWithValue("@F_suscripcion", string.IsNullOrEmpty(BE.F_suscripcion) ? (object)DBNull.Value : BE.F_suscripcion);
                        cmd.Parameters.AddWithValue("@xlistacodigos", string.IsNullOrEmpty(BE.Xlistacodigos) ? (object)DBNull.Value : BE.Xlistacodigos);
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

        public DataSet GetOne(string empresaid, tb_plla_fichatrabajadores BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadores_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@fichaid", SqlDbType.Char, 2).Value = BE.Fichaid;
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

        public DataSet GetAll_EstadoTrabj(string empresaid, tb_plla_fichatrabajadores BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllatab0100_GetAllEstadoTrabajador", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
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

        public DataSet GetAll_GETTRABAJADORES(string empresaid, tb_plla_fichatrabajadores BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadores_GETTRABAJADORES", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@fichaid", string.IsNullOrEmpty(BE.Fichaid) ? (object)DBNull.Value : BE.Fichaid);
                        cmd.Parameters.AddWithValue("@nomlike", string.IsNullOrEmpty(BE.Nomlike1) ? (object)DBNull.Value : BE.Nomlike1);
                        cmd.Parameters.Add("@norden", SqlDbType.Int).Value = BE.Norden;
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
        public DataSet GetAll_TrabajadorRetenciones(string empresaid, tb_plla_fichatrabajadores BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadores_TrabajadorRetenciones", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@tipoplla", string.IsNullOrEmpty(BE.Tipoplla) ? (object)DBNull.Value : BE.Tipoplla);
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

        public DataSet GetAll_ActivosCesados(string empresaid, tb_plla_fichatrabajadores BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadores_ActivosCesados", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ntipo", SqlDbType.Int).Value = BE.Ntipo;
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
        public bool CesarTrabajadorUpdate(string empresaid, tb_plla_fichatrabajadores BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadores_CesarTrabajadorUpdate", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@empresaid", string.IsNullOrEmpty(BE.Empresaid) ? (object)DBNull.Value : BE.Empresaid);
                        cmd.Parameters.AddWithValue("@fichaid", string.IsNullOrEmpty(BE.Fichaid) ? (object)DBNull.Value : BE.Fichaid);
                        cmd.Parameters.AddWithValue("@jefe", string.IsNullOrEmpty(BE.Jefe) ? (object)DBNull.Value : BE.Jefe);
                        cmd.Parameters.Add("@fec_cese", SqlDbType.DateTime).Value = BE.Fechcese;
                        cmd.Parameters.AddWithValue("@motivo", string.IsNullOrEmpty(BE.Motivocese) ? (object)DBNull.Value : BE.Motivocese);
                        cmd.Parameters.Add("@observ", SqlDbType.Text).Value = BE.Observacion;
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
        public bool DesactivarTrabajadorUpdate(string empresaid, tb_plla_fichatrabajadores BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadores_DesactivarTrabajadorUpdate", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@fichaid", SqlDbType.Char, 7).Value = BE.Fichaid;
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
        public DataSet GetAllTrabajadoresReactivar(string empresaid, tb_plla_fichatrabajadores BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadores_GetAllTrabajadoresReactivar", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ver_inactivos", SqlDbType.Int).Value = BE.Ver_inactivos;
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
        public bool ReactivarTrabajadorUpdate(string empresaid, tb_plla_fichatrabajadores BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPllaFichatrabajadores_ReactivarUpdate", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@fichaid", string.IsNullOrEmpty(BE.Fichaid) ? (object)DBNull.Value : BE.Fichaid);
                        cmd.Parameters.Add("@ntipo", SqlDbType.Int).Value = BE.Ntipo;
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
    }
}
