using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_60local_stock_inventario_rollo_cargaDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_60local_stock_inventario_rollo_carga BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                SqlTransaction tr = default(SqlTransaction);
                Boolean TransaExito = false;

                using (SqlCommand cmd = new SqlCommand("gspTb60LocalStockInventarioRolloCarga_INSERT_xml", cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd.Parameters.Add("@XML", SqlDbType.Xml).Value = BE.GetItemXML();

                    try
                    {
                        cnx.Open();
                        tr = cnx.BeginTransaction(IsolationLevel.Serializable);
                        cmd.Transaction = tr;

                        if (cmd.ExecuteNonQuery() > 0)
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

        public bool Update(string empresaid, tb_60local_stock_inventario_rollo_carga BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                SqlTransaction tr = default(SqlTransaction);
                Boolean TransaExito = false;

                using (SqlCommand cmd = new SqlCommand("gspTb60LocalStockInventarioRolloCarga_Update_xml", cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd.Parameters.Add("@XML", SqlDbType.Xml).Value = BE.GetItemXML();

                    try
                    {
                        cnx.Open();
                        tr = cnx.BeginTransaction(IsolationLevel.Serializable);
                        cmd.Transaction = tr;

                        if (cmd.ExecuteNonQuery() > 0)
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

        public bool Delete(string empresaid, tb_60local_stock_inventario_rollo_carga BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60LocalStockInventarioRolloCarga_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@rollo", SqlDbType.Char, 10).Value = BE.rollo;
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

        public DataSet GetAll(string empresaid, tb_60local_stock_inventario_rollo_carga BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60LocalStockInventarioRolloCarga_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@rollo", SqlDbType.Char, 10).Value = BE.rollo;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@codigoubic", SqlDbType.Char, 5).Value = BE.codigoubic;
                        cmd.Parameters.Add("@userinventario", SqlDbType.VarChar, 30).Value = BE.userinventario;
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

        public DataSet GetAll_DISTINDOC(string empresaid, tb_60local_stock_inventario_rollo_carga BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60LocalStockInventarioRolloCarga_DISTINDOC", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@fechatoma", SqlDbType.DateTime).Value = BE.fechatoma;
                        cmd.Parameters.Add("@userinventario", SqlDbType.VarChar, 30).Value = BE.userinventario;
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

        public DataSet GetOne(string empresaid, tb_60local_stock_inventario_rollo_carga BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60LocalStockInventarioRolloCarga_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@rollo", SqlDbType.Char, 10).Value = BE.rollo;
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

        public DataSet GetOne_rollodoc(string empresaid, tb_60local_stock_inventario_rollo_carga BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60LocalStockInventarioRolloCarga_SELECT_rollodoc", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@fechatoma", SqlDbType.DateTime).Value = BE.fechatoma;
                        cmd.Parameters.Add("@rollo", SqlDbType.Char, 10).Value = BE.rollo;
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

        public DataSet GetAll_rollo(string empresaid, tb_60local_stock_inventario_rollo_carga BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                String SQLQuery = " SELECT * FROM tb_ta_local_stock_inventario_rollo_carga_det "+
                                  " WHERE ROLLO = '" + BE.rollo.ToString() + "' ";

                using (SqlCommand cmd = new SqlCommand(SQLQuery, cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.Text;                              
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

        public DataSet GetAll_fechas(string empresaid, tb_60local_stock_inventario_rollo_carga BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                String SQLQuery = " SELECT DISTINCT CONVERT(VARCHAR,fechdoc,103) AS fecha  " +
                                  " FROM tb_ta_local_stock_inventario_rollo_carga_cab ";

                using (SqlCommand cmd = new SqlCommand(SQLQuery, cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.Text;
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
                    lfech = DateTime.Parse("01/01/1900");
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
