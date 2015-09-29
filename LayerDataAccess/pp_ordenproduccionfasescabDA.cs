using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class pp_ordenproduccionfasescabDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_pp_ordenproduccionfasescab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPpOrdenproduccionfasescab_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd.Parameters.Add("@secuencia", SqlDbType.Char, 2).Value = BE.secuencia;
                    cmd.Parameters.Add("@faseid", SqlDbType.Char, 3).Value = BE.faseid;
                    cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                    cmd.Parameters.Add("@fasedescort", SqlDbType.Char, 5).Value = BE.fasedescort;
                    cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                    cmd.Parameters.Add("@tallertipoid", SqlDbType.Char, 2).Value = BE.tallertipoid;
                    cmd.Parameters.Add("@tallerid", SqlDbType.Char, 5).Value = BE.tallerid;
                    cmd.Parameters.Add("@fech_ini", SqlDbType.DateTime).Value = BE.fech_ini;
                    cmd.Parameters.Add("@fech_fin", SqlDbType.DateTime).Value = BE.fech_fin;
                    cmd.Parameters.Add("@totpzas", SqlDbType.Decimal).Value = BE.totpzas;
                    cmd.Parameters.Add("@totpzascta", SqlDbType.Decimal).Value = BE.totpzascta;
                    cmd.Parameters.Add("@totpzaspend", SqlDbType.Decimal).Value = BE.totpzaspend;
                    cmd.Parameters.Add("@fech_pri_aten", SqlDbType.DateTime).Value = BE.fech_pri_aten;
                    cmd.Parameters.Add("@fech_ult_aten", SqlDbType.DateTime).Value = BE.fech_ult_aten;
                    cmd.Parameters.Add("@costoestimado", SqlDbType.Decimal).Value = BE.costoestimado;
                    cmd.Parameters.Add("@costoreal", SqlDbType.Decimal).Value = BE.costoreal;
                    cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 300).Value = BE.glosa;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
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

        public bool Update(string empresaid, tb_pp_ordenproduccionfasescab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPpOrdenproduccionfasescab_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@secuencia", SqlDbType.Char, 2).Value = BE.secuencia;
                        cmd.Parameters.Add("@faseid", SqlDbType.Char, 3).Value = BE.faseid;
                        cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                        cmd.Parameters.Add("@fasedescort", SqlDbType.Char, 5).Value = BE.fasedescort;
                        cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                        cmd.Parameters.Add("@tallertipoid", SqlDbType.Char, 2).Value = BE.tallertipoid;
                        cmd.Parameters.Add("@tallerid", SqlDbType.Char, 5).Value = BE.tallerid;
                        cmd.Parameters.Add("@fech_ini", SqlDbType.DateTime).Value = BE.fech_ini;
                        cmd.Parameters.Add("@fech_fin", SqlDbType.DateTime).Value = BE.fech_fin;
                        cmd.Parameters.Add("@totpzas", SqlDbType.Decimal).Value = BE.totpzas;
                        cmd.Parameters.Add("@totpzascta", SqlDbType.Decimal).Value = BE.totpzascta;
                        cmd.Parameters.Add("@totpzaspend", SqlDbType.Decimal).Value = BE.totpzaspend;
                        cmd.Parameters.Add("@fech_pri_aten", SqlDbType.DateTime).Value = BE.fech_pri_aten;
                        cmd.Parameters.Add("@fech_ult_aten", SqlDbType.DateTime).Value = BE.fech_ult_aten;
                        cmd.Parameters.Add("@costoestimado", SqlDbType.Decimal).Value = BE.costoestimado;
                        cmd.Parameters.Add("@costoreal", SqlDbType.Decimal).Value = BE.costoreal;
                        cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 300).Value = BE.glosa;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
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

        public bool Delete(string empresaid, tb_pp_ordenproduccionfasescab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPpOrdenproduccionfasescab_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@secuencia", SqlDbType.Char, 2).Value = BE.secuencia;
                        cmd.Parameters.Add("@faseid", SqlDbType.Char, 3).Value = BE.faseid;
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

        public DataSet GetAll(string empresaid, tb_pp_ordenproduccionfasescab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPpOrdenproduccionfasescab_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@secuencia", SqlDbType.Char, 2).Value = BE.secuencia;
                        cmd.Parameters.Add("@faseid", SqlDbType.Char, 3).Value = BE.faseid;
                        cmd.Parameters.Add("@cencosid", SqlDbType.Char, 5).Value = BE.cencosid;
                        cmd.Parameters.Add("@fasedescort", SqlDbType.Char, 5).Value = BE.fasedescort;
                        cmd.Parameters.Add("@tallertipoid", SqlDbType.Char, 2).Value = BE.tallertipoid;
                        cmd.Parameters.Add("@tallerid", SqlDbType.Char, 5).Value = BE.tallerid;
                        cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 300).Value = BE.glosa;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
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

        public DataSet GetOne(string empresaid, tb_pp_ordenproduccionfasescab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPpOrdenproduccionfasescab_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@secuencia", SqlDbType.Char, 2).Value = BE.secuencia;
                        cmd.Parameters.Add("@faseid", SqlDbType.Char, 3).Value = BE.faseid;
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
        #endregion
    }
}
