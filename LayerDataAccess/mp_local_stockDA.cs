using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class mp_local_stockDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_mp_local_stock BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpLocalStock_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
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
                    cmd.Parameters.Add("@nivelreposicion", SqlDbType.Decimal).Value = BE.nivelreposicion;

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

        public bool Update(string empresaid, tb_mp_local_stock BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpLocalStock_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
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
                        cmd.Parameters.Add("@nivelreposicion", SqlDbType.Decimal).Value = BE.nivelreposicion;
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

        public bool Delete(string empresaid, tb_mp_local_stock BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpLocalStock_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
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

        public DataSet GetAll(string empresaid, tb_mp_local_stock BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpLocalStock_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
                        cmd.Parameters.Add("@productname", SqlDbType.VarChar, 60).Value = BE.productname;
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

        public DataSet GetOne(string empresaid, string moduloid, string local, string productid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpLocalStock_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = local;
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

        public bool ReorgAnioMes(string empresaid, tb_mp_local_stock BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpLocalStock_ReorgAnioMes", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@grabacp", SqlDbType.Char, 2).Value = BE.grabacp;
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

        public bool ReorgAnio(string empresaid, tb_mp_local_stock BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpLocalStock_ReorgAnual", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@grabacp", SqlDbType.Char, 2).Value = BE.grabacp;
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

        public bool CierreDePeriodo(string empresaid, tb_mp_local_stock BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMpLocalStock_CierreMes", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@grabacp", SqlDbType.Char, 2).Value = BE.grabacp;
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
    }
}
