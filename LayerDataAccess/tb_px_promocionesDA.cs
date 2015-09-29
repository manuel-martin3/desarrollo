using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;


namespace LayerDataAccess
{
    public class tb_px_promocionesDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_px_promociones BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPxPromocion_INSERT", cnx))
                {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@promoid", SqlDbType.Int).Value = BE.promoid;
                        cmd.Parameters.Add("@prioridad", SqlDbType.Char).Value = BE.prioridad;
                        cmd.Parameters.Add("@status", SqlDbType.Char).Value = BE.status;
                        cmd.Parameters.Add("@exclusivo", SqlDbType.Char).Value = BE.exclusivo; 
                        cmd.Parameters.Add("@promoname", SqlDbType.VarChar,50).Value = BE.promoname;
                        cmd.Parameters.Add("@tiendalist", SqlDbType.Int).Value = BE.tiendalist;
                        cmd.Parameters.Add("@tarjgroupid", SqlDbType.Int).Value = BE.tarjgrupoid;
                        cmd.Parameters.Add("@tarjetaid", SqlDbType.Int).Value = BE.tarjetaid;
                        cmd.Parameters.Add("@percdscto", SqlDbType.Decimal).Value = BE.percdscto;
                        cmd.Parameters.Add("@alDocum", SqlDbType.Bit).Value = BE.al_docum;
                        cmd.Parameters.Add("@fechaini", SqlDbType.DateTime).Value = BE.fechaini;
                        cmd.Parameters.Add("@fechafin", SqlDbType.DateTime).Value = BE.fechafin;
                        cmd.Parameters.Add("@promotipoid", SqlDbType.Int).Value = BE.promotipoid;
                        cmd.Parameters.Add("@grupopromoid", SqlDbType.Int).Value = BE.grupopromoid;
                        cmd.Parameters.Add("@campaniaid", SqlDbType.Int).Value = BE.campaniaid;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                        cmd.Parameters.Add("@fecre", SqlDbType.DateTime).Value = BE.fecre;
                        cmd.Parameters.Add("@feact", SqlDbType.DateTime).Value = BE.feact;
                        cmd.Parameters.Add("@usuarap", SqlDbType.Char, 15).Value = BE.usuarap;
                        cmd.Parameters.Add("@fechap", SqlDbType.DateTime).Value = BE.fechap;
                        cmd.Parameters.Add("@solodias", SqlDbType.Bit).Value = BE.solodias;
                        cmd.Parameters.Add("@dom", SqlDbType.Bit).Value = BE.dom;
                        cmd.Parameters.Add("@lun", SqlDbType.Bit).Value = BE.lun;
                        cmd.Parameters.Add("@mar", SqlDbType.Bit).Value = BE.mar;
                        cmd.Parameters.Add("@mie", SqlDbType.Bit).Value = BE.mie;
                        cmd.Parameters.Add("@jue", SqlDbType.Bit).Value = BE.jue;
                        cmd.Parameters.Add("@vie", SqlDbType.Bit).Value = BE.vie;
                        cmd.Parameters.Add("@sab", SqlDbType.Bit).Value = BE.sab;
                        cmd.Parameters.Add("@npack", SqlDbType.Int).Value = BE.npack;
                        cmd.Parameters.Add("@impopack", SqlDbType.Decimal).Value = BE.impopack;
                        cmd.Parameters.Add("@aplicini", SqlDbType.Int).Value = BE.aplicini;
                        cmd.Parameters.Add("@aplicfin", SqlDbType.Int).Value = BE.aplicfin;
                        cmd.Parameters.Add("@impodoc", SqlDbType.Decimal).Value = BE.impodoc;

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

        public bool Update(string empresaid, tb_px_promociones BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPxPromocion_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@promoid", SqlDbType.Int).Value = BE.promoid;
                        cmd.Parameters.Add("@prioridad", SqlDbType.Char).Value = BE.prioridad;
                        cmd.Parameters.Add("@status", SqlDbType.Char,1).Value = BE.status;
                        cmd.Parameters.Add("@exclusivo", SqlDbType.Char).Value = BE.exclusivo;
                        cmd.Parameters.Add("@promoname", SqlDbType.VarChar, 50).Value = BE.promoname;
                        cmd.Parameters.Add("@tiendalist", SqlDbType.Int).Value = BE.tiendalist;
                        cmd.Parameters.Add("@tarjgroupid", SqlDbType.Int).Value = BE.tarjgrupoid;
                        cmd.Parameters.Add("@tarjetaid", SqlDbType.Int).Value = BE.tarjetaid;
                        cmd.Parameters.Add("@percdscto", SqlDbType.Decimal).Value = BE.percdscto;
                        cmd.Parameters.Add("@alDocum", SqlDbType.Bit).Value = BE.al_docum;
                        cmd.Parameters.Add("@fechaini", SqlDbType.DateTime).Value = BE.fechaini;
                        cmd.Parameters.Add("@fechafin", SqlDbType.DateTime).Value = BE.fechafin;
                        cmd.Parameters.Add("@promotipoid", SqlDbType.Int).Value = BE.promotipoid;
                        cmd.Parameters.Add("@grupopromoid", SqlDbType.Int).Value = BE.grupopromoid;
                        cmd.Parameters.Add("@campaniaid", SqlDbType.Int).Value = BE.campaniaid;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                        cmd.Parameters.Add("@fecre", SqlDbType.DateTime).Value = BE.fecre;
                        cmd.Parameters.Add("@feact", SqlDbType.DateTime).Value = BE.feact;
                        cmd.Parameters.Add("@usuarap", SqlDbType.Char, 15).Value = BE.usuarap;
                        cmd.Parameters.Add("@fechap", SqlDbType.DateTime).Value = BE.fechap;
                        cmd.Parameters.Add("@solodias", SqlDbType.Bit).Value = BE.solodias;
                        cmd.Parameters.Add("@dom", SqlDbType.Bit).Value = BE.dom;
                        cmd.Parameters.Add("@lun", SqlDbType.Bit).Value = BE.lun;
                        cmd.Parameters.Add("@mar", SqlDbType.Bit).Value = BE.mar;
                        cmd.Parameters.Add("@mie", SqlDbType.Bit).Value = BE.mie;
                        cmd.Parameters.Add("@jue", SqlDbType.Bit).Value = BE.jue;
                        cmd.Parameters.Add("@vie", SqlDbType.Bit).Value = BE.vie;
                        cmd.Parameters.Add("@sab", SqlDbType.Bit).Value = BE.sab;
                        cmd.Parameters.Add("@npack", SqlDbType.Int).Value = BE.npack;
                        cmd.Parameters.Add("@impopack", SqlDbType.Decimal).Value = BE.impopack;
                        cmd.Parameters.Add("@aplicini", SqlDbType.Int).Value = BE.aplicini;
                        cmd.Parameters.Add("@aplicfin", SqlDbType.Int).Value = BE.aplicfin;
                        cmd.Parameters.Add("@impodoc", SqlDbType.Decimal).Value = BE.impodoc;
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

        public bool Delete(string empresaid, tb_px_promociones BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPxPromocion_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@promoid", SqlDbType.Int).Value = BE.promoid;
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

        public DataSet GetAll(string empresaid, tb_px_promociones BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPxPromocion_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@promoid", SqlDbType.Int).Value = BE.promoid;
                        cmd.Parameters.Add("@promoname", SqlDbType.VarChar, 50).Value = BE.promoname;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
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


        public DataSet GetFiltro(string empresaid, tb_px_promociones BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPxPromocion_FILTRO", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = BE.fechaActual;
                        cmd.Parameters.Add("@filtro", SqlDbType.Int).Value = BE.filtro;
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

        public DataSet GetAll_paginacion(string empresaid, tb_px_promociones BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtColor_SEARCH_paginacion", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@grupopromoid", SqlDbType.Int).Value = BE.grupopromoid;
                       // cmd.Parameters.Add("@posicion", SqlDbType.Char, 10).Value = BE.posicion;

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

        public DataSet GetOne(string empresaid, string grupopromoid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPxPromocion_FITLRO", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@grupopromoid", SqlDbType.Int).Value = grupopromoid;
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
