using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class pp_ordenproduccioncabDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_pp_ordenproduccioncab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPpOrdenproduccioncab_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                    cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                    cmd.Parameters.Add("@direcnume", SqlDbType.Char, 3).Value = BE.direcnume;
                    cmd.Parameters.Add("@direcname", SqlDbType.VarChar, 25).Value = BE.direcname;
                    cmd.Parameters.Add("@direcdeta", SqlDbType.VarChar, 70).Value = BE.direcdeta;
                    cmd.Parameters.Add("@tipref", SqlDbType.Char, 1).Value = BE.tipref;
                    cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                    cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                    cmd.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE.fechref;
                    cmd.Parameters.Add("@fechaini", SqlDbType.DateTime).Value = BE.fechaini;
                    cmd.Parameters.Add("@fechafin", SqlDbType.DateTime).Value = BE.fechafin;
                    cmd.Parameters.Add("@lineaid", SqlDbType.Char, 2).Value = BE.lineaid;
                    cmd.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE.marcaid;
                    cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
                    cmd.Parameters.Add("@articname", SqlDbType.Char, 50).Value = BE.articname;
                    cmd.Parameters.Add("@items", SqlDbType.Decimal).Value = BE.items; //*itemscab
                    cmd.Parameters.Add("@totpzas", SqlDbType.Decimal).Value = BE.totpzas;
                    cmd.Parameters.Add("@totpzas1ra", SqlDbType.Decimal).Value = BE.totpzas1ra;
                    cmd.Parameters.Add("@totpzas2da", SqlDbType.Decimal).Value = BE.totpzas2da;
                    cmd.Parameters.Add("@totpzasmerma", SqlDbType.Decimal).Value = BE.totpzasmerma;
                    cmd.Parameters.Add("@totpzaspend", SqlDbType.Decimal).Value = BE.totpzaspend;
                    cmd.Parameters.Add("@fech_pri_aten", SqlDbType.DateTime).Value = BE.fech_pri_aten;
                    cmd.Parameters.Add("@fech_ult_aten", SqlDbType.DateTime).Value = BE.fech_ult_aten;
                    cmd.Parameters.Add("@costoestimado", SqlDbType.Decimal).Value = BE.costoestimado;
                    cmd.Parameters.Add("@costoreal", SqlDbType.Decimal).Value = BE.costoreal;
                    cmd.Parameters.Add("@responsable", SqlDbType.VarChar, 40).Value = BE.responsable;
                    cmd.Parameters.Add("@user_apr1", SqlDbType.Char, 15).Value = BE.user_apr1;
                    cmd.Parameters.Add("@fech_apr1", SqlDbType.DateTime).Value = BE.fech_apr1;
                    cmd.Parameters.Add("@user_apr2", SqlDbType.Char, 15).Value = BE.user_apr2;
                    cmd.Parameters.Add("@fech_apr2", SqlDbType.DateTime).Value = BE.fech_apr2;
                    cmd.Parameters.Add("@canalventaref", SqlDbType.Char, 9).Value = BE.canalventaref;
                    cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 300).Value = BE.glosa;
                    cmd.Parameters.Add("@faseactual", SqlDbType.Char, 2).Value = BE.faseactual;
                    cmd.Parameters.Add("@fasesrealizadas", SqlDbType.Int).Value = BE.fasesrealizadas;
                    cmd.Parameters.Add("@faseactualpzas", SqlDbType.Decimal).Value = BE.faseactualpzas;                    
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd.Parameters.Add("@status_aprob", SqlDbType.Char, 1).Value = BE.status_aprob;
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

        public bool Update(string empresaid, tb_pp_ordenproduccioncab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpMovimientoscab_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                        cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                        cmd.Parameters.Add("@direcnume", SqlDbType.Char, 3).Value = BE.direcnume;
                        cmd.Parameters.Add("@direcname", SqlDbType.VarChar, 25).Value = BE.direcname;
                        cmd.Parameters.Add("@direcdeta", SqlDbType.VarChar, 70).Value = BE.direcdeta;
                        cmd.Parameters.Add("@tipref", SqlDbType.Char, 1).Value = BE.tipref;
                        cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                        cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                        cmd.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE.fechref;
                        cmd.Parameters.Add("@fechaini", SqlDbType.DateTime).Value = BE.fechaini;
                        cmd.Parameters.Add("@fechafin", SqlDbType.DateTime).Value = BE.fechafin;
                        cmd.Parameters.Add("@lineaid", SqlDbType.Char, 2).Value = BE.lineaid;
                        cmd.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE.marcaid;
                        cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
                        cmd.Parameters.Add("@articname", SqlDbType.Char, 50).Value = BE.articname;
                        cmd.Parameters.Add("@items", SqlDbType.Decimal).Value = BE.items; //*itemscab
                        cmd.Parameters.Add("@totpzas", SqlDbType.Decimal).Value = BE.totpzas;
                        cmd.Parameters.Add("@totpzas1ra", SqlDbType.Decimal).Value = BE.totpzas1ra;
                        cmd.Parameters.Add("@totpzas2da", SqlDbType.Decimal).Value = BE.totpzas2da;
                        cmd.Parameters.Add("@totpzasmerma", SqlDbType.Decimal).Value = BE.totpzasmerma;
                        cmd.Parameters.Add("@totpzaspend", SqlDbType.Decimal).Value = BE.totpzaspend;
                        cmd.Parameters.Add("@fech_pri_aten", SqlDbType.DateTime).Value = BE.fech_pri_aten;
                        cmd.Parameters.Add("@fech_ult_aten", SqlDbType.DateTime).Value = BE.fech_ult_aten;
                        cmd.Parameters.Add("@costoestimado", SqlDbType.Decimal).Value = BE.costoestimado;
                        cmd.Parameters.Add("@costoreal", SqlDbType.Decimal).Value = BE.costoreal;
                        cmd.Parameters.Add("@responsable", SqlDbType.VarChar, 40).Value = BE.responsable;
                        cmd.Parameters.Add("@user_apr1", SqlDbType.Char, 15).Value = BE.user_apr1;
                        cmd.Parameters.Add("@fech_apr1", SqlDbType.DateTime).Value = BE.fech_apr1;
                        cmd.Parameters.Add("@user_apr2", SqlDbType.Char, 15).Value = BE.user_apr2;
                        cmd.Parameters.Add("@fech_apr2", SqlDbType.DateTime).Value = BE.fech_apr2;
                        cmd.Parameters.Add("@canalventaref", SqlDbType.Char, 9).Value = BE.canalventaref;
                        cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 300).Value = BE.glosa;
                        cmd.Parameters.Add("@faseactual", SqlDbType.Char, 2).Value = BE.faseactual;
                        cmd.Parameters.Add("@fasesrealizadas", SqlDbType.Int).Value = BE.fasesrealizadas;
                        cmd.Parameters.Add("@faseactualpzas", SqlDbType.Decimal).Value = BE.faseactualpzas;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@status_aprob", SqlDbType.Char, 1).Value = BE.status_aprob;
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

        public bool Delete(string empresaid, tb_pp_ordenproduccioncab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpMovimientoscab_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
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

        public DataSet GetAll(string empresaid, tb_pp_ordenproduccioncab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPpOrdenproduccioncab_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                        cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                        cmd.Parameters.Add("@direcnume", SqlDbType.Char, 3).Value = BE.direcnume;
                        cmd.Parameters.Add("@direcname", SqlDbType.VarChar, 25).Value = BE.direcname;
                        cmd.Parameters.Add("@direcdeta", SqlDbType.VarChar, 70).Value = BE.direcdeta;
                        cmd.Parameters.Add("@tipref", SqlDbType.Char, 1).Value = BE.tipref;
                        cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                        cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                        cmd.Parameters.Add("@lineaid", SqlDbType.Char, 2).Value = BE.lineaid;
                        cmd.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE.marcaid;
                        cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
                        cmd.Parameters.Add("@articname", SqlDbType.VarChar, 50).Value = BE.articname;
                        cmd.Parameters.Add("@responsable", SqlDbType.VarChar, 40).Value = BE.responsable;
                        cmd.Parameters.Add("@user_apr1", SqlDbType.Char, 15).Value = BE.user_apr1;
                        cmd.Parameters.Add("@user_apr2", SqlDbType.Char, 15).Value = BE.user_apr2;
                        cmd.Parameters.Add("@canalventaref", SqlDbType.Char, 9).Value = BE.canalventaref;
                        cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 300).Value = BE.glosa;
                        cmd.Parameters.Add("@faseactual", SqlDbType.Char, 2).Value = BE.faseactual;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@status_aprob", SqlDbType.Char, 1).Value = BE.status_aprob;
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

        public DataSet GetOne(string empresaid, tb_pp_ordenproduccioncab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPpOrdenproduccioncab_SELECT", cnx))
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
        #endregion
    }
}
