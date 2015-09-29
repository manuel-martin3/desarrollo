using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;


namespace LayerDataAccess
{
    public class tb_cxc_evalcredDA
    {
        ConexionWeb conex = new ConexionWeb();

        public bool Insert(string empresaid, tb_cxc_evalcred BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCxcEvalCred_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@item", SqlDbType.Char, 5).Value = BE.item;
                    cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                    cmd.Parameters.Add("@es_persjuridica", SqlDbType.Bit).Value = BE.es_persjuridica;
                    cmd.Parameters.Add("@copia_constitucionempresa", SqlDbType.Bit).Value = BE.copia_constitucionempresa;
                    cmd.Parameters.Add("@copia_ruc", SqlDbType.Bit).Value = BE.copia_ruc;
                    cmd.Parameters.Add("@copia_dni", SqlDbType.Bit).Value = BE.copia_dni;
                    cmd.Parameters.Add("@lic_func", SqlDbType.Bit).Value = BE.lic_func;
                    cmd.Parameters.Add("@titulo_localcom", SqlDbType.Bit).Value = BE.titulo_localcom;
                    cmd.Parameters.Add("@contra_localcom", SqlDbType.Bit).Value = BE.contra_localcom;
                    cmd.Parameters.Add("@recibo_agualuz", SqlDbType.Bit).Value = BE.recibo_agualuz;
                    cmd.Parameters.Add("@tiene_letraprotestada", SqlDbType.Bit).Value = BE.tiene_letraprotestada;
                    cmd.Parameters.Add("@tiene_morosidad", SqlDbType.Bit).Value = BE.tiene_morosidad;
                    cmd.Parameters.Add("@moroso_infocorp", SqlDbType.Bit).Value = BE.moroso_infocorp;
                    cmd.Parameters.Add("@refe_comerc", SqlDbType.Char, 3).Value = BE.refe_comerc;
                    cmd.Parameters.Add("@refe_banca", SqlDbType.Char, 3).Value = BE.refe_banca;
                    cmd.Parameters.Add("@bienes_bienmueble", SqlDbType.Bit).Value = BE.bienes_bienmueble;
                    cmd.Parameters.Add("@bienes_inmuebles", SqlDbType.Bit).Value = BE.bienes_inmuebles;
                    cmd.Parameters.Add("@puntaje", SqlDbType.Int).Value = BE.puntaje;
                    cmd.Parameters.Add("@eval_cxcob", SqlDbType.Char, 3).Value = BE.eval_cxcob;
                    cmd.Parameters.Add("@obs_cxcob", SqlDbType.VarChar, 100).Value = BE.obs_cxcob;
                    cmd.Parameters.Add("@aprob_gerencial", SqlDbType.Char, 1).Value = BE.aprob_gerencial;
                    cmd.Parameters.Add("@obs_gerencial", SqlDbType.VarChar, 100).Value = BE.obs_gerencial;
                    cmd.Parameters.Add("@usuar", SqlDbType.VarChar, 20).Value = BE.usuar;

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

        public bool Update(string empresaid, tb_cxc_evalcred BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCxcEvalCred_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@item", SqlDbType.Char, 5).Value = BE.item;
                        cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@es_persjuridica", SqlDbType.Bit).Value = BE.es_persjuridica;
                        cmd.Parameters.Add("@copia_constitucionempresa", SqlDbType.Bit).Value = BE.copia_constitucionempresa;
                        cmd.Parameters.Add("@copia_ruc", SqlDbType.Bit).Value = BE.copia_ruc;
                        cmd.Parameters.Add("@copia_dni", SqlDbType.Bit).Value = BE.copia_dni;
                        cmd.Parameters.Add("@lic_func", SqlDbType.Bit).Value = BE.lic_func;
                        cmd.Parameters.Add("@titulo_localcom", SqlDbType.Bit).Value = BE.titulo_localcom;
                        cmd.Parameters.Add("@contra_localcom", SqlDbType.Bit).Value = BE.contra_localcom;
                        cmd.Parameters.Add("@recibo_agualuz", SqlDbType.Bit).Value = BE.recibo_agualuz;
                        cmd.Parameters.Add("@tiene_letraprotestada", SqlDbType.Bit).Value = BE.tiene_letraprotestada;
                        cmd.Parameters.Add("@tiene_morosidad", SqlDbType.Bit).Value = BE.tiene_morosidad;
                        cmd.Parameters.Add("@moroso_infocorp", SqlDbType.Bit).Value = BE.moroso_infocorp;
                        cmd.Parameters.Add("@refe_comerc", SqlDbType.Char, 3).Value = BE.refe_comerc;
                        cmd.Parameters.Add("@refe_banca", SqlDbType.Char, 3).Value = BE.refe_banca;
                        cmd.Parameters.Add("@bienes_bienmueble", SqlDbType.Bit).Value = BE.bienes_bienmueble;
                        cmd.Parameters.Add("@bienes_inmuebles", SqlDbType.Bit).Value = BE.bienes_inmuebles;
                        cmd.Parameters.Add("@puntaje", SqlDbType.Int).Value = BE.puntaje;
                        cmd.Parameters.Add("@eval_cxcob", SqlDbType.Char, 3).Value = BE.eval_cxcob;
                        cmd.Parameters.Add("@obs_cxcob", SqlDbType.VarChar, 100).Value = BE.obs_cxcob;
                        cmd.Parameters.Add("@aprob_gerencial", SqlDbType.Char, 1).Value = BE.aprob_gerencial;
                        cmd.Parameters.Add("@obs_gerencial", SqlDbType.VarChar, 100).Value = BE.obs_gerencial;
                        cmd.Parameters.Add("@usuar", SqlDbType.VarChar, 20).Value = BE.usuar;
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

        public bool UpdatePendAprob(string empresaid, tb_cxc_evalcred BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCxcEvalCredPendAprob_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;                        
                        cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 2).Value = BE.status;
                        cmd.Parameters.Add("@obser", SqlDbType.VarChar, 100).Value = BE.obs_gerencial;
                        //cmd.Parameters.Add("@usuar", SqlDbType.VarChar, 20).Value = BE.usuar;
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

        public bool Delete(string empresaid, tb_cxc_evalcred BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtColor_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@item", SqlDbType.Char, 5).Value = BE.item;
                        cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
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

        public DataSet GetAll(string empresaid, tb_cxc_evalcred BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCxcEvalCred_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;                       
                        cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;                        
                        cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                        cmd.Parameters.Add("@aprob_gerencial", SqlDbType.Char, 2).Value = BE.aprob_gerencial;                       
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

		 public DataSet GetAll_Filtro(string empresaid, tb_cxc_evalcred BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCxcEvalCred_SEARCH_FILTRO", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 50).Value = BE.ctactename;
                        cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                        cmd.Parameters.Add("@vendorname", SqlDbType.VarChar, 50).Value = BE.vendorname;
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

         public DataSet GetAll_Estados(string empresaid, tb_cxc_evalcred BE)
         {
             using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
             {
                 using (SqlCommand cmd = new SqlCommand("gspTbMeStatus_SEARCH", cnx))
                 {
                     DataSet ds = new DataSet();
                     {
                         cmd.CommandType = CommandType.StoredProcedure;
                         cmd.Parameters.Add("@aprob_status", SqlDbType.Char, 2).Value = BE.aprob_status;
                         cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = BE.descripcion;
                         cmd.Parameters.Add("@canalventaid", SqlDbType.Char, 3).Value = BE.canalventaid;
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


		
        /** Martin MMS listas*/
        public DataSet GetAll_PendAprob(string empresaid, tb_cxc_evalcred BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCxcEvalCredPendAprob_SEARCH", cnx))
                {
                    
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                        cmd.Parameters.Add("@aprob_gerencial", SqlDbType.Char, 2).Value = BE.aprob_gerencial;
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

        public bool Update_1(string empresaid, tb_cxc_evalcred BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCxcEvalCred_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;                        
                        cmd.Parameters.Add("@obser", SqlDbType.VarChar, 100).Value = BE.obs_gerencial;
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


        /*End*/
        public DataSet GetAll_paginacion(string empresaid, tb_cxc_evalcred BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCxcEvalCred_SEARCH_paginacion", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipdoc", SqlDbType.Char, 2).Value = BE.tipdoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@item", SqlDbType.Char, 5).Value = BE.item;
                        cmd.Parameters.Add("@posicion", SqlDbType.Char, 10).Value = BE.posicion;
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

        public DataSet GetOne(string empresaid, string colorid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtColor_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@colorid", SqlDbType.Char, 3).Value = colorid;
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
