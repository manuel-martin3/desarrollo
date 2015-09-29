using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class pp_ordenproducciondetDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_pp_ordenproducciondet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPpOrdenproducciondet_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd.Parameters.Add("@items", SqlDbType.Char, 5).Value = BE.items;
                    cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@itemref", SqlDbType.Char, 5).Value = BE.itemref;
                    cmd.Parameters.Add("@tipref", SqlDbType.Char, 1).Value = BE.tipref;
                    cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                    cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                    cmd.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE.fechref;
                    cmd.Parameters.Add("@tipoperef", SqlDbType.Char, 2).Value = BE.tipoperef;
                    cmd.Parameters.Add("@lineaid", SqlDbType.Char, 2).Value = BE.lineaid;
                    cmd.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE.marcaid;
                    cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
                    cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                    cmd.Parameters.Add("@articidold", SqlDbType.Char, 7).Value = BE.articidold;
                    cmd.Parameters.Add("@articname", SqlDbType.VarChar, 50).Value = BE.articname;
                    cmd.Parameters.Add("@productname", SqlDbType.VarChar, 70).Value = BE.productname;
                    cmd.Parameters.Add("@colorid", SqlDbType.Char, 3).Value = BE.colorid;
                    cmd.Parameters.Add("@colorname", SqlDbType.VarChar, 7).Value = BE.colorname;
                    cmd.Parameters.Add("@tallaid", SqlDbType.Char, 2).Value = BE.tallaid;
                    cmd.Parameters.Add("@coltalla", SqlDbType.Char, 2).Value = BE.coltalla;
                    cmd.Parameters.Add("@coltallaname", SqlDbType.Char, 4).Value = BE.coltallaname;
                    cmd.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = BE.cantidad;
                    cmd.Parameters.Add("@cantidad1ra", SqlDbType.Decimal).Value = BE.cantidad1ra;
                    cmd.Parameters.Add("@cantidad2da", SqlDbType.Decimal).Value = BE.cantidad2da;
                    cmd.Parameters.Add("@cantidadmerma", SqlDbType.Decimal).Value = BE.cantidadmerma;
                    cmd.Parameters.Add("@cant_pend", SqlDbType.Decimal).Value = BE.cant_pend;
                    cmd.Parameters.Add("@fech_pri_aten", SqlDbType.DateTime).Value = BE.fech_pri_aten;
                    cmd.Parameters.Add("@fech_ult_aten", SqlDbType.DateTime).Value = BE.fech_ult_aten;
                    cmd.Parameters.Add("@canalventaref", SqlDbType.Char, 9).Value = BE.canalventaref;
                    cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 300).Value = BE.glosa;                    
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

        public bool Update(string empresaid, tb_pp_ordenproducciondet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPpOrdenproducciondet_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@items", SqlDbType.Char, 5).Value = BE.items;
                        cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@itemref", SqlDbType.Char, 5).Value = BE.itemref;
                        cmd.Parameters.Add("@tipref", SqlDbType.Char, 1).Value = BE.tipref;
                        cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                        cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                        cmd.Parameters.Add("@fechref", SqlDbType.DateTime).Value = BE.fechref;
                        cmd.Parameters.Add("@tipoperef", SqlDbType.Char, 2).Value = BE.tipoperef;
                        cmd.Parameters.Add("@lineaid", SqlDbType.Char, 2).Value = BE.lineaid;
                        cmd.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE.marcaid;
                        cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@articidold", SqlDbType.Char, 7).Value = BE.articidold;
                        cmd.Parameters.Add("@articname", SqlDbType.VarChar, 50).Value = BE.articname;
                        cmd.Parameters.Add("@productname", SqlDbType.VarChar, 70).Value = BE.productname;
                        cmd.Parameters.Add("@colorid", SqlDbType.Char, 3).Value = BE.colorid;
                        cmd.Parameters.Add("@colorname", SqlDbType.VarChar, 7).Value = BE.colorname;
                        cmd.Parameters.Add("@tallaid", SqlDbType.Char, 2).Value = BE.tallaid;
                        cmd.Parameters.Add("@coltalla", SqlDbType.Char, 2).Value = BE.coltalla;
                        cmd.Parameters.Add("@coltallaname", SqlDbType.Char, 4).Value = BE.coltallaname;
                        cmd.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = BE.cantidad;
                        cmd.Parameters.Add("@cantidad1ra", SqlDbType.Decimal).Value = BE.cantidad1ra;
                        cmd.Parameters.Add("@cantidad2da", SqlDbType.Decimal).Value = BE.cantidad2da;
                        cmd.Parameters.Add("@cantidadmerma", SqlDbType.Decimal).Value = BE.cantidadmerma;
                        cmd.Parameters.Add("@cant_pend", SqlDbType.Decimal).Value = BE.cant_pend;
                        cmd.Parameters.Add("@fech_pri_aten", SqlDbType.DateTime).Value = BE.fech_pri_aten;
                        cmd.Parameters.Add("@fech_ult_aten", SqlDbType.DateTime).Value = BE.fech_ult_aten;
                        cmd.Parameters.Add("@canalventaref", SqlDbType.Char, 9).Value = BE.canalventaref;
                        cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 300).Value = BE.glosa;
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

        public bool Delete(string empresaid, tb_pp_ordenproducciondet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPpOrdenproducciondet_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@items", SqlDbType.Char, 5).Value = BE.items;
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

        public DataSet GetAll(string empresaid, tb_pp_ordenproducciondet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPpOrdenproducciondet_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@items", SqlDbType.Char, 5).Value = BE.items;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@itemref", SqlDbType.Char, 5).Value = BE.itemref;
                        cmd.Parameters.Add("@tipref", SqlDbType.Char, 1).Value = BE.tipref;
                        cmd.Parameters.Add("@serref", SqlDbType.Char, 4).Value = BE.serref;
                        cmd.Parameters.Add("@numref", SqlDbType.Char, 10).Value = BE.numref;
                        cmd.Parameters.Add("@tipoperef", SqlDbType.Char, 2).Value = BE.tipoperef;
                        cmd.Parameters.Add("@lineaid", SqlDbType.Char, 2).Value = BE.lineaid;
                        cmd.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE.marcaid;
                        cmd.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@articidold", SqlDbType.Char, 7).Value = BE.articidold;
                        cmd.Parameters.Add("@articname", SqlDbType.VarChar, 50).Value = BE.articname;
                        cmd.Parameters.Add("@productname", SqlDbType.VarChar, 70).Value = BE.productname;
                        cmd.Parameters.Add("@colorid", SqlDbType.Char, 3).Value = BE.colorid;
                        cmd.Parameters.Add("@colorname", SqlDbType.VarChar, 7).Value = BE.colorname;
                        cmd.Parameters.Add("@tallaid", SqlDbType.Char, 2).Value = BE.tallaid;
                        cmd.Parameters.Add("@coltalla", SqlDbType.Char, 2).Value = BE.coltalla;
                        cmd.Parameters.Add("@coltallaname", SqlDbType.Char, 4).Value = BE.coltallaname;
                        cmd.Parameters.Add("@canalventaref", SqlDbType.Char, 9).Value = BE.canalventaref;
                        cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 300).Value = BE.glosa;
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

        public DataSet GetOne(string empresaid, tb_pp_ordenproducciondet BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPpOrdenproducciondet_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@items", SqlDbType.Char, 5).Value = BE.items;
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
