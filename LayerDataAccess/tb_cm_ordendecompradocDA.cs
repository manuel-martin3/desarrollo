using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using LayerBusinessEntities;

namespace LayerDataAccess
{
  public  class tb_cm_ordendecompradocDA
    {
        public String Sql_Error = "";
        ConexionDA conex = new ConexionDA();

     
        public bool Insert(string empresaid, tb_cm_ordendecompradoc BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60Movimientosdoc_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@tipodoc", SqlDbType.Char, 2).Value = BE.tipodoc;
                    cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                    cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;

                    cmd.Parameters.Add("@item", SqlDbType.Char, 2).Value = BE.items;
                    //cmd.Parameters.Add("@docglosa", SqlDbType.VarChar, 100).Value = BE.docglosa;
                    //cmd.Parameters.Add("@docname", SqlDbType.VarChar, 100).Value = BE.docname;
                    //cmd.Parameters.Add("@documen", SqlDbType.Image).Value = BE.documen;

                    //cmd.Parameters.Add("@tipocontratoid", SqlDbType.Char, 2).Value = BE.tipocontratoid;
                    //cmd.Parameters.Add("@tipocontratoname", SqlDbType.VarChar, 100).Value = BE.tipocontratoname;
                    //cmd.Parameters.Add("@nomplantillaword", SqlDbType.VarChar, 100).Value = BE.nomplantillaword;
                    //cmd.Parameters.Add("@plantillaword", SqlDbType.VarBinary).Value = BE.plantillaword;

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

        public bool Insert_Update(string empresaid, tb_cm_ordendecompradoc BE, DataTable Detalle)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                bool xreturn = true;
                int lcont = 0;
                for (lcont = 0; lcont <= Detalle.Rows.Count - 1; lcont++)
                {
                    using (SqlCommand cmd = new SqlCommand("gspTbCmOrdencompradoc_INSERT", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@moduloiddes", SqlDbType.Char, 4).Value = BE.moduloiddes;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;

                        cmd.Parameters.Add("@item", SqlDbType.Char, 2).Value = Detalle.Rows[lcont]["item"];
                        cmd.Parameters.Add("@docglosa", SqlDbType.VarChar, 100).Value = Detalle.Rows[lcont]["docglosa"];
                        cmd.Parameters.Add("@docname", SqlDbType.VarChar, 100).Value = Detalle.Rows[lcont]["docname"];
                        cmd.Parameters.Add("@documen", SqlDbType.Image).Value = Detalle.Rows[lcont]["documen"];
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
                return xreturn;
            }
        }

        public bool Update(string empresaid, tb_cm_ordendecompradoc BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60attachedfile_UPDATE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@tipocontratoid", SqlDbType.Char, 2).Value = BE.tipocontratoid;
                        //cmd.Parameters.Add("@tipocontratoname", SqlDbType.VarChar, 100).Value = BE.tipocontratoname;
                        //cmd.Parameters.Add("@nomplantillaword", SqlDbType.VarChar, 100).Value = BE.nomplantillaword;
                        //cmd.Parameters.Add("@plantillaword", SqlDbType.Image).Value = BE.plantillaword;
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

        public bool Delete(string empresaid, tb_cm_ordendecompradoc BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCmOrdencompradoc_ELIMINAR", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@item", SqlDbType.Char, 2).Value = BE.items;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@moduloiddes", SqlDbType.Char, 4).Value = BE.moduloiddes;
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
                        Sql_Error = ex.Message;
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public bool Eliminar(string empresaid, DataTable TablaTrab)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                bool xreturn = true;
                int lcont = 0;
                for (lcont = 0; lcont <= TablaTrab.Rows.Count - 1; lcont++)
                {
                    using (SqlCommand cmd = new SqlCommand("gspTb60Movimientosdoc_ELIMINAR", cnx))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@item", SqlDbType.Char, 2).Value = TablaTrab.Rows[lcont]["item"];

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

        public DataSet GetAll(string empresaid, tb_cm_ordendecompradoc BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCmOrdencompradoc_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@moduloiddes", SqlDbType.Char, 4).Value = BE.moduloiddes;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;

                        //cmd.Parameters.Add("@plantillaword", SqlDbType.Image).Value = BE.plantillaword;
                    }
                    try
                    {
                        cnx.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            //if (ds.Tables.Count > 0)
                            //{
                                da.Fill(ds);
                            //}
                            //else return null;
                            
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

        public DataSet GetAll_CONSULTA(string empresaid, tb_cm_ordendecompradoc BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbcmattachedfile_CONSULTA", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@item", string.IsNullOrEmpty(BE.items) ? (object)DBNull.Value : BE.items);
                        cmd.Parameters.AddWithValue("@nomlike1", string.IsNullOrEmpty(BE.nomlike1) ? (object)DBNull.Value : BE.nomlike1);
                        cmd.Parameters.AddWithValue("@nomlike2", string.IsNullOrEmpty(BE.nomlike2) ? (object)DBNull.Value : BE.nomlike2);
                        cmd.Parameters.AddWithValue("@nomlike3", string.IsNullOrEmpty(BE.nomlike3) ? (object)DBNull.Value : BE.nomlike3);
                        cmd.Parameters.Add("@norden", SqlDbType.Int).Value = BE.norden;
                        cmd.Parameters.Add("@ver_blanco", SqlDbType.Int).Value = BE.ver_blanco;
                        cmd.Parameters.Add("@vista", SqlDbType.Int).Value = BE.vista;
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

        public DataSet GetAll_CONSULTAIR(string empresaid, tb_cm_ordendecompradoc BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbmaattachedfile_IR", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@tipocontratoid", string.IsNullOrEmpty(BE.items) ? (object)DBNull.Value : BE.items);
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

        //public DataSet GetAll_CONSULTACCOSTO(string empresaid, tb_plla_plantilla_contratos BE)
        //{
        //    using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("gspTbPllaCcostogen_CONSULTASelectAll", cnx))
        //        {
        //            DataSet ds = new DataSet();
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@empresaid", string.IsNullOrEmpty(BE.empresaid) ? (object)DBNull.Value : BE.empresaid);
        //                cmd.Parameters.AddWithValue("@nomlike1", string.IsNullOrEmpty(BE.nomlike1) ? (object)DBNull.Value : BE.nomlike1);
        //                cmd.Parameters.AddWithValue("@nomlike2", string.IsNullOrEmpty(BE.nomlike2) ? (object)DBNull.Value : BE.nomlike2);
        //                cmd.Parameters.AddWithValue("@nomlike3", string.IsNullOrEmpty(BE.nomlike3) ? (object)DBNull.Value : BE.nomlike3);
        //                cmd.Parameters.AddWithValue("@ccostodescartar", string.IsNullOrEmpty(BE.ccostodescartar) ? (object)DBNull.Value : BE.ccostodescartar);
        //            }
        //            try
        //            {
        //                cnx.Open();
        //                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        //                {
        //                    da.Fill(ds);
        //                }
        //                return ds;
        //            }
        //            catch (Exception ex)
        //            {
        //                Sql_Error = ex.Message;
        //                throw new Exception(ex.Message);
        //            }
        //        }
        //    }
        //}

        public DataSet GetAll_MaxCodigo(string empresaid, tb_cm_ordendecompradoc BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCmOrdencompradoc_MaxCodigo", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@numdoc", SqlDbType.Char, 10).Value = BE.numdoc;
                        cmd.Parameters.Add("@moduloiddes", SqlDbType.Char, 4).Value = BE.moduloiddes;
                        cmd.Parameters.Add("@serdoc", SqlDbType.Char, 4).Value = BE.serdoc;
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

        public DataSet GetOne(string empresaid, tb_cm_ordendecompradoc BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60attachedfile_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@tipocontratoid", SqlDbType.Char, 2).Value = BE.items;
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



       
    }
}
