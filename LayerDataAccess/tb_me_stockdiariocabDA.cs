using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_me_stockdiariocabDA
    {
        ConexionDA conex = new ConexionDA();

        public DataSet GetAllStkDisp(string empresaid, tb_me_stockdiariocab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {

                using (SqlCommand cmd1 = new SqlCommand("gspTbMestockdiariocab_SEARCH_stk", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.Add("@articid", SqlDbType.Char, 4).Value = BE.articid;
                        cmd1.Parameters.Add("@colorid", SqlDbType.Char, 3).Value = BE.colorid;
                        cmd1.Parameters.Add("@coltall", SqlDbType.Char, 2).Value = BE.coltall;
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

        public bool InsertStk(string empresaid, tb_me_stockdiariocab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMeStock_INSERT_UPDATE", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@accion", SqlDbType.Char, 3).Value = BE.accion;
                    cmd.Parameters.Add("@Id_det", SqlDbType.VarChar, 200).Value =BE.almacaccionid.ToString() + BE.tipodoc.ToString() + BE.serdoc.ToString() + BE.numdoc.ToString();
                    cmd.Parameters.Add("@XMLStk", SqlDbType.Xml).Value = BE.GetItemXML();
                    
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

        public DataSet GetAll(string empresaid, tb_me_stockdiariocab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtArticulo_SEARCH_web", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@valorfind", SqlDbType.VarChar, 50).Value = BE.valorfind;
                        cmd.Parameters.Add("@articidold", SqlDbType.Char, 7).Value = BE.articidold;
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


        public DataSet GetAll_Grid(string empresaid, tb_me_stockdiariocab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtArticulo_SEARCH_grid", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@filtro", SqlDbType.Char, 1).Value = BE.filtro;
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
   
		public DataSet GetAll_StockDisp(string empresaid, tb_me_stockdiariocab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMeStockDisp_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@marcaid", SqlDbType.VarChar, 2).Value = BE.marcaid;
                        cmd.Parameters.Add("@lineaid", SqlDbType.VarChar, 2).Value = BE.lineaid;
                        cmd.Parameters.Add("@generoid", SqlDbType.VarChar, 1).Value = BE.generoid;
                        cmd.Parameters.Add("@articid", SqlDbType.VarChar, 4).Value = BE.articid;
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


        public DataSet GetAll_StockProdDet(string empresaid, tb_me_stockdiariocab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMeStockProdDet_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE.marcaid;
                        cmd.Parameters.Add("@lineaid", SqlDbType.Char, 2).Value = BE.lineaid;
                        cmd.Parameters.Add("@generoid", SqlDbType.Char, 1).Value = BE.generoid;
                        cmd.Parameters.Add("@articidold", SqlDbType.VarChar, 7).Value = BE.articidold;
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
