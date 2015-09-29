using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_60productosDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_60productos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60Productos_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd.Parameters.Add("@productname", SqlDbType.VarChar, 500).Value = BE.productname;                    
                    cmd.Parameters.Add("@unmed", SqlDbType.Char, 3).Value = BE.unmed;
                    cmd.Parameters.Add("@peso", SqlDbType.Decimal).Value = BE.peso;
                    cmd.Parameters.Add("@unmedpeso", SqlDbType.Char, 3).Value = BE.unmedpeso;
                    cmd.Parameters.Add("@unmedenvase", SqlDbType.Char, 3).Value = BE.unmedenvase;
                    cmd.Parameters.Add("@unidenvase", SqlDbType.Decimal).Value = BE.unidenvase;
                    cmd.Parameters.Add("@precioenvase", SqlDbType.Decimal).Value = BE.precioenvase;
                    cmd.Parameters.Add("@etiquetaname", SqlDbType.VarChar, 40).Value = BE.etiquetaname;
                    cmd.Parameters.Add("@colorid", SqlDbType.Char, 3).Value = BE.colorid;
                    cmd.Parameters.Add("@colorname", SqlDbType.VarChar, 30).Value = BE.colorname;
                    cmd.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE.marcaid;
                    cmd.Parameters.Add("@coleccionid", SqlDbType.Char, 3).Value = BE.coleccionid;
                    cmd.Parameters.Add("@temporadaid", SqlDbType.Char, 1).Value = BE.temporadaid;
                    cmd.Parameters.Add("@categoriaid", SqlDbType.Char, 2).Value = BE.categoriaid;
                    cmd.Parameters.Add("@generoid", SqlDbType.Char, 1).Value = BE.generoid;
                    cmd.Parameters.Add("@tejidoid", SqlDbType.Char, 2).Value = BE.tejidoid;
                    cmd.Parameters.Add("@telaid", SqlDbType.Char, 2).Value = BE.telaid;
                    cmd.Parameters.Add("@tallaid", SqlDbType.Char, 2).Value = BE.tallaid;
                    cmd.Parameters.Add("@coltalla", SqlDbType.Char, 2).Value = BE.coltalla;
                    cmd.Parameters.Add("@coltallaname", SqlDbType.Char, 4).Value = BE.coltallaname;
                    cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                    cmd.Parameters.Add("@precventa", SqlDbType.Decimal).Value = BE.precventa;
                    cmd.Parameters.Add("@precvent2", SqlDbType.Decimal).Value = BE.precvent2;
                    cmd.Parameters.Add("@precvent3", SqlDbType.Decimal).Value = BE.precvent3;
                    cmd.Parameters.Add("@precvent4", SqlDbType.Decimal).Value = BE.precvent4;
                    cmd.Parameters.Add("@precvent5", SqlDbType.Decimal).Value = BE.precvent5;
                    cmd.Parameters.Add("@precventant", SqlDbType.Decimal).Value = BE.precventant;
                    cmd.Parameters.Add("@conce", SqlDbType.VarChar, 30).Value = BE.conce;
                    cmd.Parameters.Add("@diluc", SqlDbType.VarChar, 30).Value = BE.diluc;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@compo", SqlDbType.VarChar, 50).Value = BE.compo;
                    cmd.Parameters.Add("@titulo", SqlDbType.VarChar, 80).Value = BE.titulo;
                    cmd.Parameters.Add("@productidold", SqlDbType.Char, 15).Value = BE.productidold;
                    cmd.Parameters.Add("@lineaid", SqlDbType.Char, 3).Value = BE.lineaid;
                    cmd.Parameters.Add("@grupoid", SqlDbType.Char, 4).Value = BE.grupoid;
                    cmd.Parameters.Add("@subgrupoid", SqlDbType.Char, 3).Value = BE.subgrupoid;
                    cmd.Parameters.Add("@item", SqlDbType.Char, 3).Value = BE.item;
                    cmd.Parameters.Add("@codctadebe", SqlDbType.Char, 10).Value = BE.codctadebe;
                    cmd.Parameters.Add("@codctahaber", SqlDbType.Char, 10).Value = BE.codctahaber;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    cmd.Parameters.Add("@fepialmac", SqlDbType.DateTime).Value = BE.fepialmac;
                    cmd.Parameters.Add("@feuialmac", SqlDbType.DateTime).Value = BE.feuialmac;
                    cmd.Parameters.Add("@procedenciaid", SqlDbType.Char,1).Value = BE.procedenciaid;
                    cmd.Parameters.Add("@nserie", SqlDbType.VarChar, 20).Value = BE.nserie;
                    cmd.Parameters.Add("@foto", SqlDbType.Image).Value = BE.Foto;

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


        public bool Insert_Foto(string empresaid, tb_60productos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60Productos_INSERT_FOTOS", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                    cmd.Parameters.Add("@docname", SqlDbType.VarChar, 100).Value = BE.docname;
                    cmd.Parameters.Add("@foto", SqlDbType.Image).Value = BE.Foto;

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


        public bool Update(string empresaid, tb_60productos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60Productos_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@productname", SqlDbType.VarChar, 500).Value = BE.productname;                        
                        cmd.Parameters.Add("@unmed", SqlDbType.Char, 3).Value = BE.unmed;
                        cmd.Parameters.Add("@peso", SqlDbType.Decimal).Value = BE.peso;
                        cmd.Parameters.Add("@unmedpeso", SqlDbType.Char, 3).Value = BE.unmedpeso;
                        cmd.Parameters.Add("@unmedenvase", SqlDbType.Char, 3).Value = BE.unmedenvase;
                        cmd.Parameters.Add("@unidenvase", SqlDbType.Decimal).Value = BE.unidenvase;
                        cmd.Parameters.Add("@precioenvase", SqlDbType.Decimal).Value = BE.precioenvase;
                        cmd.Parameters.Add("@etiquetaname", SqlDbType.VarChar, 40).Value = BE.etiquetaname;
                        cmd.Parameters.Add("@colorid", SqlDbType.Char, 3).Value = BE.colorid;
                        cmd.Parameters.Add("@colorname", SqlDbType.VarChar, 30).Value = BE.colorname;
                        cmd.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE.marcaid;
                        cmd.Parameters.Add("@coleccionid", SqlDbType.Char, 3).Value = BE.coleccionid;
                        cmd.Parameters.Add("@temporadaid", SqlDbType.Char, 1).Value = BE.temporadaid;
                        cmd.Parameters.Add("@categoriaid", SqlDbType.Char, 2).Value = BE.categoriaid;
                        cmd.Parameters.Add("@generoid", SqlDbType.Char, 1).Value = BE.generoid;
                        cmd.Parameters.Add("@tejidoid", SqlDbType.Char, 2).Value = BE.tejidoid;
                        cmd.Parameters.Add("@telaid", SqlDbType.Char, 2).Value = BE.telaid;
                        cmd.Parameters.Add("@tallaid", SqlDbType.Char, 2).Value = BE.tallaid;
                        cmd.Parameters.Add("@coltalla", SqlDbType.Char, 2).Value = BE.coltalla;
                        cmd.Parameters.Add("@coltallaname", SqlDbType.Char, 4).Value = BE.coltallaname;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@precventa", SqlDbType.Decimal).Value = BE.precventa;
                        cmd.Parameters.Add("@precvent2", SqlDbType.Decimal).Value = BE.precvent2;
                        cmd.Parameters.Add("@precvent3", SqlDbType.Decimal).Value = BE.precvent3;
                        cmd.Parameters.Add("@precvent4", SqlDbType.Decimal).Value = BE.precvent4;
                        cmd.Parameters.Add("@precvent5", SqlDbType.Decimal).Value = BE.precvent5;
                        cmd.Parameters.Add("@precventant", SqlDbType.Decimal).Value = BE.precventant;
                        cmd.Parameters.Add("@conce", SqlDbType.VarChar, 30).Value = BE.conce;
                        cmd.Parameters.Add("@diluc", SqlDbType.VarChar, 30).Value = BE.diluc;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@compo", SqlDbType.VarChar, 50).Value = BE.compo;
                        cmd.Parameters.Add("@titulo", SqlDbType.VarChar, 80).Value = BE.titulo;
                        cmd.Parameters.Add("@productidold", SqlDbType.Char, 15).Value = BE.productidold;
                        cmd.Parameters.Add("@lineaid", SqlDbType.Char, 3).Value = BE.lineaid;
                        cmd.Parameters.Add("@grupoid", SqlDbType.Char, 4).Value = BE.grupoid;
                        cmd.Parameters.Add("@subgrupoid", SqlDbType.Char, 3).Value = BE.subgrupoid;
                        cmd.Parameters.Add("@item", SqlDbType.Char, 3).Value = BE.item;
                        cmd.Parameters.Add("@codctadebe", SqlDbType.Char, 10).Value = BE.codctadebe;
                        cmd.Parameters.Add("@codctahaber", SqlDbType.Char, 10).Value = BE.codctahaber;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                        cmd.Parameters.Add("@fepialmac", SqlDbType.DateTime).Value = BE.fepialmac;
                        cmd.Parameters.Add("@feuialmac", SqlDbType.DateTime).Value = BE.feuialmac;
                        cmd.Parameters.Add("@procedenciaid", SqlDbType.Char, 1).Value = BE.procedenciaid;
                        cmd.Parameters.Add("@nserie", SqlDbType.VarChar, 20).Value = BE.nserie;
                        cmd.Parameters.Add("@foto", SqlDbType.Image).Value = BE.Foto;
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

        public bool Update_Foto(string empresaid, tb_60productos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60Productos_UPDATE_FOTOS", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                    cmd.Parameters.Add("@docname", SqlDbType.VarChar, 100).Value = BE.docname;
                    cmd.Parameters.Add("@foto", SqlDbType.Image).Value = BE.Foto;

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









        public bool Update_CodigoOLD(string empresaid, tb_60productos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60Productos_UPDATE_CodigoOLD", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@productidold", SqlDbType.Char, 15).Value = BE.productidold;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                        cmd.Parameters.Add("@fepialmac", SqlDbType.DateTime).Value = BE.fepialmac;
                        cmd.Parameters.Add("@feuialmac", SqlDbType.DateTime).Value = BE.feuialmac;
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

        public bool Update_fichatecnica(string empresaid, tb_60productos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60Productos_UPDATE_fichatecnica", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@foto", SqlDbType.Image).Value = BE.Foto;
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

        public bool Delete(string empresaid, tb_60productos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60Productos_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
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

        public DataSet GetAll(string empresaid, tb_60productos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60Productos_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@productname", SqlDbType.VarChar, 500).Value = BE.productname;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@lineaid", SqlDbType.Char, 3).Value = BE.lineaid;
                        cmd.Parameters.Add("@grupoid", SqlDbType.Char, 4).Value = BE.grupoid;
                        cmd.Parameters.Add("@subgrupoid", SqlDbType.Char, 3).Value = BE.subgrupoid;
                        cmd.Parameters.Add("@filtro", SqlDbType.Char, 1).Value = BE.filtro;
                        cmd.Parameters.Add("@codigo", SqlDbType.Char, 8).Value = BE.codigo;
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
                        //Console.WriteLine(ex.Message);                       
                    }
                }
            }
        }

        public DataSet GetReport(string empresaid, tb_60productos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60Productos_REPORT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@productname", SqlDbType.VarChar, 500).Value = BE.productname;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@lineaid", SqlDbType.Char, 3).Value = BE.lineaid;
                        cmd.Parameters.Add("@grupoid", SqlDbType.Char, 4).Value = BE.grupoid;
                        cmd.Parameters.Add("@subgrupoid", SqlDbType.Char, 3).Value = BE.subgrupoid;
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

        public DataSet GetAll_nuevocodprod(string empresaid, tb_60productos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60Productos_nuevocodprod", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@lineaid", SqlDbType.Char, 3).Value = BE.lineaid;
                        cmd.Parameters.Add("@grupoid", SqlDbType.Char, 4).Value = BE.grupoid;
                        cmd.Parameters.Add("@subgrupoid", SqlDbType.Char, 3).Value = BE.subgrupoid;
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

        public DataSet GetOne(string empresaid, tb_60productos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60Productos_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
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

        public DataSet GetAll_MaxMin(string empresaid, tb_60productos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60Productos_SEARCH_MaxMin", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
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

        public DataSet GetAll_paginacion(string empresaid, tb_60productos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60Productos_SEARCH_paginacion", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@posicion", SqlDbType.VarChar, 10).Value = BE.posicion;
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

        public DataSet GenCodigo(string empresaid, tb_60productos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60GenNewItem", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@cencosid", SqlDbType.Char, 8).Value = BE.cencosid;
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



        public DataSet GenCodAsoc(string empresaid, tb_60productos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTb60Productos_GenCodAsoc", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@lineaid", SqlDbType.Char, 3).Value = BE.lineaid;
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

   


        #region *** REPORTES ALMACEN 0320
        public DataSet GetAll_stockrollo(string empresaid, tb_60productos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbTaProdrollo_SEARCH_stockrollo", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@lineaid", SqlDbType.Char, 3).Value = BE.lineaid;
                        cmd.Parameters.Add("@grupoid", SqlDbType.Char, 4).Value = BE.grupoid;
                        cmd.Parameters.Add("@subgrupoid", SqlDbType.Char, 10).Value = BE.subgrupoid;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@productidold", SqlDbType.Char, 13).Value = BE.productidold;
                        cmd.Parameters.Add("@productname", SqlDbType.Char, 13).Value = BE.productname;
                        cmd.Parameters.Add("@colorid", SqlDbType.Char, 3).Value = BE.colorid;
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
        #endregion

    }
}
