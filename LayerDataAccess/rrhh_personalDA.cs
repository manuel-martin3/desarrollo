using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;


namespace LayerDataAccess
{
    public class rrhh_personalDA
    {
        ConexionWeb2 conex = new ConexionWeb2();

        public bool Insert(string empresaid, tb_rrhh_personal BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbRrhhPersonal_INSERT", cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = BE.empresaid;
                    cmd.Parameters.Add("@DDNNI", SqlDbType.Char, 8).Value = BE.DDNNI;
                    cmd.Parameters.Add("@APPAT", SqlDbType.VarChar, 20).Value = BE.APPAT;
                    cmd.Parameters.Add("@APMAT", SqlDbType.VarChar, 20).Value = BE.APMAT;
                    cmd.Parameters.Add("@NOMBR", SqlDbType.VarChar, 30).Value = BE.NOMBR;
                    cmd.Parameters.Add("@NOMBS", SqlDbType.VarChar, 73).Value = BE.NOMBS;
                    cmd.Parameters.Add("@FOTOG", SqlDbType.VarChar, 24).Value = BE.FOTOG;
                    cmd.Parameters.Add("@FENAC", SqlDbType.DateTime).Value = BE.FENAC;
                    cmd.Parameters.Add("@UBIGE", SqlDbType.Char, 6).Value = BE.UBIGE;
                    cmd.Parameters.Add("@IDEDU", SqlDbType.Char, 2).Value = BE.IDEDU;
                    cmd.Parameters.Add("@ECIVI", SqlDbType.Char, 1).Value = BE.ECIVI;
                    cmd.Parameters.Add("@FEING", SqlDbType.DateTime).Value = BE.FEING;
                    cmd.Parameters.Add("@DIREC", SqlDbType.VarChar, 70).Value = BE.DIREC;
                    cmd.Parameters.Add("@TELEF", SqlDbType.VarChar, 25).Value = BE.TELEF;
                    cmd.Parameters.Add("@IDCC1", SqlDbType.Char, 2).Value = BE.IDCC1;
                    cmd.Parameters.Add("@IDCC2", SqlDbType.Char, 3).Value = BE.IDCC2;
                    cmd.Parameters.Add("@FEINP", SqlDbType.DateTime).Value = BE.FEINP;
                    cmd.Parameters.Add("@ESSAL", SqlDbType.VarChar, 15).Value = BE.ESSAL;
                    cmd.Parameters.Add("@BASIC", SqlDbType.Float).Value = BE.BASIC;
                    cmd.Parameters.Add("@IDCAO", SqlDbType.Char).Value = BE.IDCAO;
                    cmd.Parameters.Add("@ASFAM", SqlDbType.Char, 1).Value = BE.ASFAM;
                    cmd.Parameters.Add("@IDAFP", SqlDbType.Char, 2).Value = BE.IDAFP;
                    cmd.Parameters.Add("@NMAFI", SqlDbType.VarChar, 15).Value = BE.NMAFI;
                    cmd.Parameters.Add("@IDSIT", SqlDbType.Char, 2).Value = BE.IDSIT;
                    cmd.Parameters.Add("@FECES", SqlDbType.DateTime).Value = BE.FECES;
                    cmd.Parameters.Add("@IDPER", SqlDbType.Char).Value = BE.IDPER;
                    cmd.Parameters.Add("@AFER5", SqlDbType.Char).Value = BE.AFER5;
                    cmd.Parameters.Add("@SEXXO", SqlDbType.Char, 1).Value = BE.SEXXO;
                    cmd.Parameters.Add("@NMCTA", SqlDbType.VarChar, 20).Value = BE.NMCTA;
                    cmd.Parameters.Add("@RETJU", SqlDbType.Float).Value = BE.RETJU;
                    cmd.Parameters.Add("@IDTUR", SqlDbType.Char, 2).Value = BE.IDTUR;
                    cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar, 6).Value = BE.CLAVE;
                    cmd.Parameters.Add("@IDOCU", SqlDbType.Char, 6).Value = BE.IDOCU;
                    cmd.Parameters.Add("@PAISS", SqlDbType.Char, 4).Value = BE.PAISS;
                    cmd.Parameters.Add("@USUAR", SqlDbType.Char, 15).Value = BE.USUAR;
                    //cmd.Parameters.Add("@FEACT", SqlDbType.DateTime).Value = BE.FEACT;
                    //cmd.Parameters.Add("@FLTAG", SqlDbType.Char).Value = BE.FLTAG;
                    cmd.Parameters.Add("@flvis", SqlDbType.Bit).Value = BE.flvis;
                    cmd.Parameters.Add("@idold", SqlDbType.Char, 2).Value = BE.idold;

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

        public bool Update(string empresaid, tb_rrhh_personal BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbRrhhPersonal_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = BE.empresaid;
                        cmd.Parameters.Add("@DDNNI", SqlDbType.Char, 8).Value = BE.DDNNI;
                        cmd.Parameters.Add("@APPAT", SqlDbType.VarChar, 20).Value = BE.APPAT;
                        cmd.Parameters.Add("@APMAT", SqlDbType.VarChar, 20).Value = BE.APMAT;
                        cmd.Parameters.Add("@NOMBR", SqlDbType.VarChar, 30).Value = BE.NOMBR;
                        cmd.Parameters.Add("@NOMBS", SqlDbType.VarChar, 73).Value = BE.NOMBS;
                        cmd.Parameters.Add("@FOTOG", SqlDbType.VarChar, 24).Value = BE.FOTOG;
                        cmd.Parameters.Add("@FENAC", SqlDbType.DateTime).Value = BE.FENAC;
                        cmd.Parameters.Add("@UBIGE", SqlDbType.Char, 6).Value = BE.UBIGE;
                        cmd.Parameters.Add("@IDEDU", SqlDbType.Char, 2).Value = BE.IDEDU;
                        cmd.Parameters.Add("@ECIVI", SqlDbType.Char, 1).Value = BE.ECIVI;
                        cmd.Parameters.Add("@FEING", SqlDbType.DateTime).Value = BE.FEING;
                        cmd.Parameters.Add("@DIREC", SqlDbType.VarChar, 70).Value = BE.DIREC;
                        cmd.Parameters.Add("@TELEF", SqlDbType.VarChar, 25).Value = BE.TELEF;
                        cmd.Parameters.Add("@IDCC1", SqlDbType.Char, 2).Value = BE.IDCC1;
                        cmd.Parameters.Add("@IDCC2", SqlDbType.Char, 3).Value = BE.IDCC2;
                        cmd.Parameters.Add("@FEINP", SqlDbType.DateTime).Value = BE.FEINP;
                        cmd.Parameters.Add("@ESSAL", SqlDbType.VarChar, 15).Value = BE.ESSAL;
                        cmd.Parameters.Add("@BASIC", SqlDbType.Float).Value = BE.BASIC;
                        cmd.Parameters.Add("@IDCAO", SqlDbType.Char).Value = BE.IDCAO;
                        cmd.Parameters.Add("@ASFAM", SqlDbType.Char).Value = BE.ASFAM;
                        cmd.Parameters.Add("@IDAFP", SqlDbType.Char, 2).Value = BE.IDAFP;
                        cmd.Parameters.Add("@NMAFI", SqlDbType.VarChar, 15).Value = BE.NMAFI;
                        cmd.Parameters.Add("@IDSIT", SqlDbType.Char, 2).Value = BE.IDSIT;
                        cmd.Parameters.Add("@FECES", SqlDbType.DateTime).Value = BE.FECES;
                        cmd.Parameters.Add("@IDPER", SqlDbType.Char).Value = BE.IDPER;
                        cmd.Parameters.Add("@AFER5", SqlDbType.Char).Value = BE.AFER5;
                        cmd.Parameters.Add("@SEXXO", SqlDbType.Char).Value = BE.SEXXO;
                        cmd.Parameters.Add("@NMCTA", SqlDbType.VarChar, 20).Value = BE.NMCTA;
                        cmd.Parameters.Add("@RETJU", SqlDbType.Float).Value = BE.RETJU;
                        cmd.Parameters.Add("@IDTUR", SqlDbType.Char, 2).Value = BE.IDTUR;
                        cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar, 6).Value = BE.CLAVE;
                        cmd.Parameters.Add("@IDOCU", SqlDbType.Char, 6).Value = BE.IDOCU;
                        cmd.Parameters.Add("@PAISS", SqlDbType.Char, 4).Value = BE.PAISS;
                        cmd.Parameters.Add("@USUAR", SqlDbType.Char, 15).Value = BE.USUAR;
                        //cmd.Parameters.Add("@FEACT", SqlDbType.DateTime).Value = BE.FEACT;
                        //cmd.Parameters.Add("@FLTAG", SqlDbType.Char).Value = BE.FLTAG;
                        cmd.Parameters.Add("@flvis", SqlDbType.Bit).Value = BE.flvis;
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

        public bool Update2(string empresaid, tb_rrhh_personal BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbRrhhPersonal_UPDATE2", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@DDNNI", SqlDbType.Char, 8).Value = BE.DDNNI;
                        cmd.Parameters.Add("@FLTAG", SqlDbType.Char).Value = BE.FLTAG;
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

        public bool Update_foto(string empresaid, tb_rrhh_personal BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbRrhhPersonal_UPDATE_foto", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@DDNNI", SqlDbType.Char, 8).Value = BE.DDNNI;
                        cmd.Parameters.Add("@FOTOG", SqlDbType.VarChar, 24).Value = BE.FOTOG;
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

        public bool Update3(string empresaid, tb_rrhh_personal BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbRrhhPersonal_UPDATE3", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = BE.empresaid;
                        cmd.Parameters.Add("@DDNNI", SqlDbType.Char, 8).Value = BE.DDNNI;
                        cmd.Parameters.Add("@APPAT", SqlDbType.VarChar, 20).Value = BE.APPAT;
                        cmd.Parameters.Add("@APMAT", SqlDbType.VarChar, 20).Value = BE.APMAT;
                        cmd.Parameters.Add("@NOMBR", SqlDbType.VarChar, 30).Value = BE.NOMBR;
                        cmd.Parameters.Add("@NOMBS", SqlDbType.VarChar, 73).Value = BE.NOMBS;
                        cmd.Parameters.Add("@FOTOG", SqlDbType.VarChar, 24).Value = BE.FOTOG;
                        cmd.Parameters.Add("@FENAC", SqlDbType.DateTime).Value = BE.FENAC;
                        cmd.Parameters.Add("@UBIGE", SqlDbType.Char, 6).Value = BE.UBIGE;
                        cmd.Parameters.Add("@IDEDU", SqlDbType.Char, 2).Value = BE.IDEDU;
                        cmd.Parameters.Add("@ECIVI", SqlDbType.Char, 1).Value = BE.ECIVI;
                        cmd.Parameters.Add("@FEING", SqlDbType.DateTime).Value = BE.FEING;
                        cmd.Parameters.Add("@DIREC", SqlDbType.VarChar, 70).Value = BE.DIREC;
                        cmd.Parameters.Add("@TELEF", SqlDbType.VarChar, 25).Value = BE.TELEF;
                        cmd.Parameters.Add("@IDCC1", SqlDbType.Char, 2).Value = BE.IDCC1;
                        cmd.Parameters.Add("@IDCC2", SqlDbType.Char, 3).Value = BE.IDCC2;
                        cmd.Parameters.Add("@FEINP", SqlDbType.DateTime).Value = BE.FEINP;
                        cmd.Parameters.Add("@ESSAL", SqlDbType.VarChar, 15).Value = BE.ESSAL;
                        cmd.Parameters.Add("@BASIC", SqlDbType.Float).Value = BE.BASIC;
                        cmd.Parameters.Add("@IDCAO", SqlDbType.Char).Value = BE.IDCAO;
                        cmd.Parameters.Add("@ASFAM", SqlDbType.Char).Value = BE.ASFAM;
                        cmd.Parameters.Add("@IDAFP", SqlDbType.Char, 2).Value = BE.IDAFP;
                        cmd.Parameters.Add("@NMAFI", SqlDbType.VarChar, 15).Value = BE.NMAFI;
                        cmd.Parameters.Add("@IDSIT", SqlDbType.Char, 2).Value = BE.IDSIT;
                        cmd.Parameters.Add("@FECES", SqlDbType.DateTime).Value = BE.FECES;
                        cmd.Parameters.Add("@IDPER", SqlDbType.Char).Value = BE.IDPER;
                        cmd.Parameters.Add("@AFER5", SqlDbType.Char).Value = BE.AFER5;
                        cmd.Parameters.Add("@SEXXO", SqlDbType.Char).Value = BE.SEXXO;
                        cmd.Parameters.Add("@NMCTA", SqlDbType.VarChar, 20).Value = BE.NMCTA;
                        cmd.Parameters.Add("@RETJU", SqlDbType.Float).Value = BE.RETJU;
                        cmd.Parameters.Add("@IDTUR", SqlDbType.Char, 2).Value = BE.IDTUR;
                        cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar, 6).Value = BE.CLAVE;
                        cmd.Parameters.Add("@IDOCU", SqlDbType.Char, 6).Value = BE.IDOCU;
                        cmd.Parameters.Add("@PAISS", SqlDbType.Char, 4).Value = BE.PAISS;
                        cmd.Parameters.Add("@USUAR", SqlDbType.Char, 15).Value = BE.USUAR;
                        //cmd.Parameters.Add("@FEACT", SqlDbType.DateTime).Value = BE.FEACT;
                        //cmd.Parameters.Add("@FLTAG", SqlDbType.Char).Value = BE.FLTAG;
                        cmd.Parameters.Add("@flvis", SqlDbType.Bit).Value = BE.flvis;
                        cmd.Parameters.Add("@idold", SqlDbType.Char, 2).Value = BE.idold;
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

        public bool Delete(string empresaid, tb_rrhh_personal BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbRrhhPersonal_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@DDNNI", SqlDbType.Char, 8).Value = BE.DDNNI;
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

        public DataSet GetAll(string empresaid, tb_rrhh_personal BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbRrhhPersonal_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = BE.empresaid;
                        cmd.Parameters.Add("@DDNNI", SqlDbType.Char, 8).Value = BE.DDNNI;
                        cmd.Parameters.Add("@NOMBS", SqlDbType.VarChar, 73).Value = BE.NOMBS;
                        cmd.Parameters.Add("@FLVIS", SqlDbType.Bit).Value = BE.flvis;
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

        public DataSet GetAll_cmdConsumo(string empresaid, tb_rrhh_personal BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbRrhhPersonal_SEARCH_cmdConsumo", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@DDNNI", SqlDbType.Char, 8).Value = BE.DDNNI;
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

        public DataSet GetAll__cumpleanieros_hoy(string empresaid, tb_rrhh_personal BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbRrhhPersonal_SEARCH_cumpleanieros_hoy", cnx))
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
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public DataSet GetAll__cumpleanieros_semana(string empresaid, tb_rrhh_personal BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbRrhhPersonal_SEARCH_cumpleanieros_estasemana", cnx))
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
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public DataSet GetAll2(string empresaid, tb_rrhh_personal BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbRrhhPersonal_SEARCH2", cnx))
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
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public DataSet GetOne(string empresaid, string ddnni)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbRrhhPersonal_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@empresaid", SqlDbType.Char, 2).Value = empresaid;
                        cmd.Parameters.Add("@DDNNI", SqlDbType.Char, 8).Value = ddnni;
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
