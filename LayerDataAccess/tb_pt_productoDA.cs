using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_pt_productoDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_pt_producto BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtProducto_INSERT", cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@lineaid", SqlDbType.Char, 2).Value = BE.lineaid;
                    cmd.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE.marcaid;
                    cmd.Parameters.Add("@item", SqlDbType.Char, 4).Value = BE.item;
                    cmd.Parameters.Add("@colorid", SqlDbType.Char, 3).Value = BE.colorid;
                    cmd.Parameters.Add("@tallaid", SqlDbType.Char, 2).Value = BE.colorid;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd.Parameters.Add("@productname", SqlDbType.VarChar, 60).Value = BE.productname;
                    cmd.Parameters.Add("@unmed", SqlDbType.Char, 3).Value = BE.unmed;
                    cmd.Parameters.Add("@peso", SqlDbType.Decimal).Value = BE.peso;
                    cmd.Parameters.Add("@unmedpeso", SqlDbType.Char, 3).Value = BE.unmedpeso;
                    cmd.Parameters.Add("@unmedenvase", SqlDbType.Char, 3).Value = BE.unmedenvase;
                    cmd.Parameters.Add("@unidenvase", SqlDbType.Int).Value = BE.unidenvase;
                    cmd.Parameters.Add("@precioenvase", SqlDbType.Decimal).Value = BE.precioenvase;
                    cmd.Parameters.Add("@etiquetaname", SqlDbType.VarChar, 40).Value = BE.etiquetaname;
                    cmd.Parameters.Add("@color", SqlDbType.VarChar, 15).Value = BE.color;
                    cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                    cmd.Parameters.Add("@precventa", SqlDbType.Decimal).Value = BE.precventa;
                    cmd.Parameters.Add("@precvent2", SqlDbType.Decimal).Value = BE.precvent2;
                    cmd.Parameters.Add("@precvent3", SqlDbType.Decimal).Value = BE.precvent3;
                    cmd.Parameters.Add("@precventant", SqlDbType.Decimal).Value = BE.precventant;
                    cmd.Parameters.Add("@conce", SqlDbType.VarChar, 30).Value = BE.conce;
                    cmd.Parameters.Add("@diluc", SqlDbType.VarChar, 30).Value = BE.diluc;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@compo", SqlDbType.VarChar, 50).Value = BE.compo;
                    cmd.Parameters.Add("@titulo", SqlDbType.VarChar, 10).Value = BE.titulo;
                    cmd.Parameters.Add("@foto", SqlDbType.VarChar, 100).Value = BE.foto;
                    cmd.Parameters.Add("@productidold", SqlDbType.Char, 15).Value = BE.productidold;
                    cmd.Parameters.Add("@grupoid", SqlDbType.Char, 4).Value = BE.grupoid;
                    cmd.Parameters.Add("@subgrupoid", SqlDbType.Char, 3).Value = BE.subgrupoid;
                    cmd.Parameters.Add("@stockini01", SqlDbType.Decimal).Value = BE.stockini01;
                    cmd.Parameters.Add("@stockini02", SqlDbType.Decimal).Value = BE.stockini02;
                    cmd.Parameters.Add("@stockini03", SqlDbType.Decimal).Value = BE.stockini03;
                    cmd.Parameters.Add("@stockini04", SqlDbType.Decimal).Value = BE.stockini04;
                    cmd.Parameters.Add("@stockini05", SqlDbType.Decimal).Value = BE.stockini05;
                    cmd.Parameters.Add("@stockini06", SqlDbType.Decimal).Value = BE.stockini06;
                    cmd.Parameters.Add("@stockini07", SqlDbType.Decimal).Value = BE.stockini07;
                    cmd.Parameters.Add("@stockini08", SqlDbType.Decimal).Value = BE.stockini08;
                    cmd.Parameters.Add("@stockini09", SqlDbType.Decimal).Value = BE.stockini09;
                    cmd.Parameters.Add("@stockini10", SqlDbType.Decimal).Value = BE.stockini10;
                    cmd.Parameters.Add("@stockini11", SqlDbType.Decimal).Value = BE.stockini11;
                    cmd.Parameters.Add("@stockini12", SqlDbType.Decimal).Value = BE.stockini12;
                    cmd.Parameters.Add("@valorini01", SqlDbType.Decimal).Value = BE.valorini01;
                    cmd.Parameters.Add("@valorini02", SqlDbType.Decimal).Value = BE.valorini02;
                    cmd.Parameters.Add("@valorini03", SqlDbType.Decimal).Value = BE.valorini03;
                    cmd.Parameters.Add("@valorini04", SqlDbType.Decimal).Value = BE.valorini04;
                    cmd.Parameters.Add("@valorini05", SqlDbType.Decimal).Value = BE.valorini05;
                    cmd.Parameters.Add("@valorini06", SqlDbType.Decimal).Value = BE.valorini06;
                    cmd.Parameters.Add("@valorini07", SqlDbType.Decimal).Value = BE.valorini07;
                    cmd.Parameters.Add("@valorini08", SqlDbType.Decimal).Value = BE.valorini08;
                    cmd.Parameters.Add("@valorini09", SqlDbType.Decimal).Value = BE.valorini09;
                    cmd.Parameters.Add("@valorini10", SqlDbType.Decimal).Value = BE.valorini10;
                    cmd.Parameters.Add("@valorini11", SqlDbType.Decimal).Value = BE.valorini11;
                    cmd.Parameters.Add("@valorini12", SqlDbType.Decimal).Value = BE.valorini12;
                    cmd.Parameters.Add("@stockini", SqlDbType.Decimal).Value = BE.stockini;
                    cmd.Parameters.Add("@valorini", SqlDbType.Decimal).Value = BE.valorini;
                    cmd.Parameters.Add("@stock", SqlDbType.Decimal).Value = BE.stock;
                    cmd.Parameters.Add("@valoractual", SqlDbType.Decimal).Value = BE.valoractual;
                    cmd.Parameters.Add("@pendingreso", SqlDbType.Decimal).Value = BE.pendingreso;
                    cmd.Parameters.Add("@pendsalida", SqlDbType.Decimal).Value = BE.pendsalida;
                    cmd.Parameters.Add("@costopromed", SqlDbType.Decimal).Value = BE.costopromed;
                    cmd.Parameters.Add("@costoultimo", SqlDbType.Decimal).Value = BE.costoultimo;
                    cmd.Parameters.Add("@codigoubic", SqlDbType.Char, 5).Value = BE.codigoubic;
                    cmd.Parameters.Add("@cantingreso", SqlDbType.Decimal).Value = BE.cantingreso;
                    cmd.Parameters.Add("@impoingreso", SqlDbType.Decimal).Value = BE.impoingreso;
                    cmd.Parameters.Add("@cantsalida", SqlDbType.Decimal).Value = BE.cantsalida;
                    cmd.Parameters.Add("@imposalida", SqlDbType.Decimal).Value = BE.imposalida;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    cmd.Parameters.Add("@categoriaid", SqlDbType.Char, 2).Value = BE.categoriaid;
                    cmd.Parameters.Add("@generoid", SqlDbType.Char, 1).Value = BE.generoid;
                    cmd.Parameters.Add("@tejidoid", SqlDbType.Char, 2).Value = BE.tejidoid;
                    cmd.Parameters.Add("@telaid", SqlDbType.Char, 2).Value = BE.telaid;
                    cmd.Parameters.Add("@tallaid", SqlDbType.Char, 2).Value = BE.tallaid;
                    cmd.Parameters.Add("@precvent4", SqlDbType.Decimal).Value = BE.precvent4;
                    cmd.Parameters.Add("@precvent5", SqlDbType.Decimal).Value = BE.precvent5;
                    cmd.Parameters.Add("@fepialmac", SqlDbType.DateTime).Value = BE.fepialmac;
                    cmd.Parameters.Add("@feuialmac", SqlDbType.DateTime).Value = BE.feuialmac;

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

        public bool Update(string empresaid, tb_pt_producto BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtProducto_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@lineaid", SqlDbType.Char, 2).Value = BE.lineaid;
                        cmd.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE.marcaid;
                        cmd.Parameters.Add("@item", SqlDbType.Char, 4).Value = BE.item;
                        cmd.Parameters.Add("@colorid", SqlDbType.Char, 3).Value = BE.colorid;
                        cmd.Parameters.Add("@tallaid", SqlDbType.Char, 2).Value = BE.colorid;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@productname", SqlDbType.VarChar, 60).Value = BE.productname;
                        cmd.Parameters.Add("@unmed", SqlDbType.Char, 3).Value = BE.unmed;
                        cmd.Parameters.Add("@peso", SqlDbType.Decimal).Value = BE.peso;
                        cmd.Parameters.Add("@unmedpeso", SqlDbType.Char, 3).Value = BE.unmedpeso;
                        cmd.Parameters.Add("@unmedenvase", SqlDbType.Char, 3).Value = BE.unmedenvase;
                        cmd.Parameters.Add("@unidenvase", SqlDbType.Int).Value = BE.unidenvase;
                        cmd.Parameters.Add("@precioenvase", SqlDbType.Decimal).Value = BE.precioenvase;
                        cmd.Parameters.Add("@etiquetaname", SqlDbType.VarChar, 40).Value = BE.etiquetaname;
                        cmd.Parameters.Add("@color", SqlDbType.VarChar, 15).Value = BE.color;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@precventa", SqlDbType.Decimal).Value = BE.precventa;
                        cmd.Parameters.Add("@precvent2", SqlDbType.Decimal).Value = BE.precvent2;
                        cmd.Parameters.Add("@precvent3", SqlDbType.Decimal).Value = BE.precvent3;
                        cmd.Parameters.Add("@precventant", SqlDbType.Decimal).Value = BE.precventant;
                        cmd.Parameters.Add("@conce", SqlDbType.VarChar, 30).Value = BE.conce;
                        cmd.Parameters.Add("@diluc", SqlDbType.VarChar, 30).Value = BE.diluc;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@compo", SqlDbType.VarChar, 50).Value = BE.compo;
                        cmd.Parameters.Add("@titulo", SqlDbType.VarChar, 10).Value = BE.titulo;
                        cmd.Parameters.Add("@foto", SqlDbType.VarChar, 100).Value = BE.foto;
                        cmd.Parameters.Add("@productidold", SqlDbType.Char, 15).Value = BE.productidold;
                        cmd.Parameters.Add("@grupoid", SqlDbType.Char, 4).Value = BE.grupoid;
                        cmd.Parameters.Add("@subgrupoid", SqlDbType.Char, 3).Value = BE.subgrupoid;
                        cmd.Parameters.Add("@stockini01", SqlDbType.Decimal).Value = BE.stockini01;
                        cmd.Parameters.Add("@stockini02", SqlDbType.Decimal).Value = BE.stockini02;
                        cmd.Parameters.Add("@stockini03", SqlDbType.Decimal).Value = BE.stockini03;
                        cmd.Parameters.Add("@stockini04", SqlDbType.Decimal).Value = BE.stockini04;
                        cmd.Parameters.Add("@stockini05", SqlDbType.Decimal).Value = BE.stockini05;
                        cmd.Parameters.Add("@stockini06", SqlDbType.Decimal).Value = BE.stockini06;
                        cmd.Parameters.Add("@stockini07", SqlDbType.Decimal).Value = BE.stockini07;
                        cmd.Parameters.Add("@stockini08", SqlDbType.Decimal).Value = BE.stockini08;
                        cmd.Parameters.Add("@stockini09", SqlDbType.Decimal).Value = BE.stockini09;
                        cmd.Parameters.Add("@stockini10", SqlDbType.Decimal).Value = BE.stockini10;
                        cmd.Parameters.Add("@stockini11", SqlDbType.Decimal).Value = BE.stockini11;
                        cmd.Parameters.Add("@stockini12", SqlDbType.Decimal).Value = BE.stockini12;
                        cmd.Parameters.Add("@valorini01", SqlDbType.Decimal).Value = BE.valorini01;
                        cmd.Parameters.Add("@valorini02", SqlDbType.Decimal).Value = BE.valorini02;
                        cmd.Parameters.Add("@valorini03", SqlDbType.Decimal).Value = BE.valorini03;
                        cmd.Parameters.Add("@valorini04", SqlDbType.Decimal).Value = BE.valorini04;
                        cmd.Parameters.Add("@valorini05", SqlDbType.Decimal).Value = BE.valorini05;
                        cmd.Parameters.Add("@valorini06", SqlDbType.Decimal).Value = BE.valorini06;
                        cmd.Parameters.Add("@valorini07", SqlDbType.Decimal).Value = BE.valorini07;
                        cmd.Parameters.Add("@valorini08", SqlDbType.Decimal).Value = BE.valorini08;
                        cmd.Parameters.Add("@valorini09", SqlDbType.Decimal).Value = BE.valorini09;
                        cmd.Parameters.Add("@valorini10", SqlDbType.Decimal).Value = BE.valorini10;
                        cmd.Parameters.Add("@valorini11", SqlDbType.Decimal).Value = BE.valorini11;
                        cmd.Parameters.Add("@valorini12", SqlDbType.Decimal).Value = BE.valorini12;
                        cmd.Parameters.Add("@stockini", SqlDbType.Decimal).Value = BE.stockini;
                        cmd.Parameters.Add("@valorini", SqlDbType.Decimal).Value = BE.valorini;
                        cmd.Parameters.Add("@stock", SqlDbType.Decimal).Value = BE.stock;
                        cmd.Parameters.Add("@valoractual", SqlDbType.Decimal).Value = BE.valoractual;
                        cmd.Parameters.Add("@pendingreso", SqlDbType.Decimal).Value = BE.pendingreso;
                        cmd.Parameters.Add("@pendsalida", SqlDbType.Decimal).Value = BE.pendsalida;
                        cmd.Parameters.Add("@costopromed", SqlDbType.Decimal).Value = BE.costopromed;
                        cmd.Parameters.Add("@costoultimo", SqlDbType.Decimal).Value = BE.costoultimo;
                        cmd.Parameters.Add("@codigoubic", SqlDbType.Char, 5).Value = BE.codigoubic;
                        cmd.Parameters.Add("@cantingreso", SqlDbType.Decimal).Value = BE.cantingreso;
                        cmd.Parameters.Add("@impoingreso", SqlDbType.Decimal).Value = BE.impoingreso;
                        cmd.Parameters.Add("@cantsalida", SqlDbType.Decimal).Value = BE.cantsalida;
                        cmd.Parameters.Add("@imposalida", SqlDbType.Decimal).Value = BE.imposalida;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                        cmd.Parameters.Add("@categoriaid", SqlDbType.Char, 2).Value = BE.categoriaid;
                        cmd.Parameters.Add("@generoid", SqlDbType.Char, 1).Value = BE.generoid;
                        cmd.Parameters.Add("@tejidoid", SqlDbType.Char, 2).Value = BE.tejidoid;
                        cmd.Parameters.Add("@telaid", SqlDbType.Char, 2).Value = BE.telaid;
                        cmd.Parameters.Add("@tallaid", SqlDbType.Char, 2).Value = BE.tallaid;
                        cmd.Parameters.Add("@precvent4", SqlDbType.Decimal).Value = BE.precvent4;
                        cmd.Parameters.Add("@precvent5", SqlDbType.Decimal).Value = BE.precvent5;
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

        public bool Delete(string empresaid, tb_pt_producto BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtProducto_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

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

        public DataSet GetAll(string empresaid, tb_pt_producto BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtProducto_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@lineaid", SqlDbType.Char, 2).Value = BE.lineaid;
                        cmd.Parameters.Add("@marcaid", SqlDbType.Char, 2).Value = BE.marcaid;
                        cmd.Parameters.Add("@item", SqlDbType.Char, 4).Value = BE.item;
                        cmd.Parameters.Add("@colorid", SqlDbType.Char, 3).Value = BE.colorid;
                        cmd.Parameters.Add("@tallaid", SqlDbType.Char, 2).Value = BE.colorid;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@productname", SqlDbType.VarChar, 60).Value = BE.productname;
                        cmd.Parameters.Add("@unmed", SqlDbType.Char, 3).Value = BE.unmed;
                        cmd.Parameters.Add("@unmedpeso", SqlDbType.Char, 3).Value = BE.unmedpeso;
                        cmd.Parameters.Add("@unmedenvase", SqlDbType.Char, 3).Value = BE.unmedenvase;
                        cmd.Parameters.Add("@etiquetaname", SqlDbType.VarChar, 40).Value = BE.etiquetaname;
                        cmd.Parameters.Add("@color", SqlDbType.VarChar, 15).Value = BE.color;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@conce", SqlDbType.VarChar, 30).Value = BE.conce;
                        cmd.Parameters.Add("@diluc", SqlDbType.VarChar, 30).Value = BE.diluc;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@compo", SqlDbType.VarChar, 50).Value = BE.compo;
                        cmd.Parameters.Add("@titulo", SqlDbType.VarChar, 10).Value = BE.titulo;
                        cmd.Parameters.Add("@foto", SqlDbType.VarChar, 100).Value = BE.foto;
                        cmd.Parameters.Add("@productidold", SqlDbType.Char, 15).Value = BE.productidold;
                        cmd.Parameters.Add("@grupoid", SqlDbType.Char, 4).Value = BE.grupoid;
                        cmd.Parameters.Add("@codigoubic", SqlDbType.Char, 5).Value = BE.codigoubic;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                        cmd.Parameters.Add("@categoriaid", SqlDbType.Char, 2).Value = BE.categoriaid;
                        cmd.Parameters.Add("@generoid", SqlDbType.Char, 1).Value = BE.generoid;
                        cmd.Parameters.Add("@tejidoid", SqlDbType.Char, 2).Value = BE.tejidoid;
                        cmd.Parameters.Add("@telaid", SqlDbType.Char, 2).Value = BE.telaid;
                        cmd.Parameters.Add("@tallaid", SqlDbType.Char, 2).Value = BE.tallaid;
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

        public DataSet GetOne(string empresaid, string productid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbPtProducto_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = productid;
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
