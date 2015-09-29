using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class clienteWebDA
    {
        ConexionWeb conex = new ConexionWeb();

        public bool Insert(string empresaid, tb_cliente BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCliente_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                    cmd.Parameters.Add("@docuidentid", SqlDbType.Char, 1).Value = BE.docuidentid;
                    cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                    cmd.Parameters.Add("@tpperson", SqlDbType.Char, 2).Value = BE.tpperson;
                    cmd.Parameters.Add("@agerent", SqlDbType.Bit).Value = BE.agerent;
                    cmd.Parameters.Add("@appat", SqlDbType.VarChar, 20).Value = BE.appat;
                    cmd.Parameters.Add("@apmat", SqlDbType.VarChar, 20).Value = BE.apmat;
                    cmd.Parameters.Add("@nombr", SqlDbType.VarChar, 30).Value = BE.nombr;
                    cmd.Parameters.Add("@direc", SqlDbType.VarChar, 100).Value = BE.direc;
                    cmd.Parameters.Add("@paisid", SqlDbType.Char, 4).Value = BE.paisid;
                    cmd.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE.ubige;
                    cmd.Parameters.Add("@telef1", SqlDbType.VarChar, 12).Value = BE.telef1;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = BE.email;
                    cmd.Parameters.Add("@urweb", SqlDbType.VarChar, 50).Value = BE.urweb;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                    cmd.Parameters.Add("@dscto3", SqlDbType.Decimal).Value = BE.dscto3;
                    cmd.Parameters.Add("@telef2", SqlDbType.VarChar, 12).Value = BE.telef2;
                    cmd.Parameters.Add("@clientetipo", SqlDbType.Char, 1).Value = BE.clientetipo;
                    cmd.Parameters.Add("@contacto", SqlDbType.VarChar, 40).Value = BE.contacto;
                    cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                    cmd.Parameters.Add("@diralter", SqlDbType.Bit).Value = BE.diralter;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    cmd.Parameters.Add("@nctactedetraccion", SqlDbType.Char, 15).Value = BE.nctactedetraccion;
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

        public bool Update(string empresaid, tb_cliente BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCliente_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                        cmd.Parameters.Add("@docuidentid", SqlDbType.Char, 1).Value = BE.docuidentid;
                        cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                        cmd.Parameters.Add("@tpperson", SqlDbType.Char, 2).Value = BE.tpperson;
                        cmd.Parameters.Add("@agerent", SqlDbType.Bit).Value = BE.agerent;
                        cmd.Parameters.Add("@appat", SqlDbType.VarChar, 20).Value = BE.appat;
                        cmd.Parameters.Add("@apmat", SqlDbType.VarChar, 20).Value = BE.apmat;
                        cmd.Parameters.Add("@nombr", SqlDbType.VarChar, 30).Value = BE.nombr;
                        cmd.Parameters.Add("@direc", SqlDbType.VarChar, 100).Value = BE.direc;
                        cmd.Parameters.Add("@paisid", SqlDbType.Char, 4).Value = BE.paisid;
                        cmd.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE.ubige;
                        cmd.Parameters.Add("@telef1", SqlDbType.VarChar, 12).Value = BE.telef1;
                        cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = BE.email;
                        cmd.Parameters.Add("@urweb", SqlDbType.VarChar, 50).Value = BE.urweb;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@dscto3", SqlDbType.Decimal).Value = BE.dscto3;
                        cmd.Parameters.Add("@telef2", SqlDbType.VarChar, 12).Value = BE.telef2;
                        cmd.Parameters.Add("@clientetipo", SqlDbType.Char, 1).Value = BE.clientetipo;
                        cmd.Parameters.Add("@contacto", SqlDbType.VarChar, 40).Value = BE.contacto;
                        cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                        cmd.Parameters.Add("@diralter", SqlDbType.Bit).Value = BE.diralter;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                        cmd.Parameters.Add("@nctactedetraccion", SqlDbType.Char, 15).Value = BE.nctactedetraccion;
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

        public bool Update2(string empresaid, tb_cliente BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCliente_UPDATE2", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@filtro", SqlDbType.Char, 1).Value = BE.filtro;
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

        public bool Delete(string empresaid, tb_cliente BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCliente_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
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

        public DataSet GetAll(string empresaid, tb_cliente BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCliente_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                        cmd.Parameters.Add("@docuidentid", SqlDbType.Char, 2).Value = BE.docuidentid;
                        cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                        cmd.Parameters.Add("@tpperson", SqlDbType.Char, 1).Value = BE.tpperson;
                        cmd.Parameters.Add("@agerent", SqlDbType.Bit).Value = BE.agerent;
                        cmd.Parameters.Add("@appat", SqlDbType.VarChar, 20).Value = BE.appat;
                        cmd.Parameters.Add("@apmat", SqlDbType.VarChar, 20).Value = BE.apmat;
                        cmd.Parameters.Add("@nombr", SqlDbType.VarChar, 30).Value = BE.nombr;
                        cmd.Parameters.Add("@direc", SqlDbType.VarChar, 100).Value = BE.direc;
                        cmd.Parameters.Add("@paisid", SqlDbType.Char, 4).Value = BE.paisid;
                        cmd.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE.ubige;
                        cmd.Parameters.Add("@telef1", SqlDbType.VarChar, 12).Value = BE.telef1;
                        cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = BE.email;
                        cmd.Parameters.Add("@urweb", SqlDbType.VarChar, 50).Value = BE.urweb;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@telef2", SqlDbType.VarChar, 12).Value = BE.telef2;
                        cmd.Parameters.Add("@clientetipo", SqlDbType.Char, 1).Value = BE.clientetipo;
                        cmd.Parameters.Add("@contacto", SqlDbType.VarChar, 40).Value = BE.contacto;
                        cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                        cmd.Parameters.Add("@top20", SqlDbType.Char, 1).Value = BE.filtro;
                        cmd.Parameters.Add("@defacliepub", SqlDbType.Bit).Value = BE.defacliepub;
                        
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

        public DataSet GetAll_direc(string empresaid, tb_cliente BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCliente_SEARCH_direc", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                        cmd.Parameters.Add("@docuidentid", SqlDbType.Char, 1).Value = BE.docuidentid;
                        cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                        cmd.Parameters.Add("@tpperson", SqlDbType.Char, 2).Value = BE.tpperson;
                        cmd.Parameters.Add("@agerent", SqlDbType.Bit).Value = BE.agerent;
                        cmd.Parameters.Add("@appat", SqlDbType.VarChar, 20).Value = BE.appat;
                        cmd.Parameters.Add("@apmat", SqlDbType.VarChar, 20).Value = BE.apmat;
                        cmd.Parameters.Add("@nombr", SqlDbType.VarChar, 30).Value = BE.nombr;
                        cmd.Parameters.Add("@direc", SqlDbType.VarChar, 100).Value = BE.direc;
                        cmd.Parameters.Add("@paisid", SqlDbType.Char, 4).Value = BE.paisid;
                        cmd.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE.ubige;
                        cmd.Parameters.Add("@telef1", SqlDbType.VarChar, 12).Value = BE.telef1;
                        cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = BE.email;
                        cmd.Parameters.Add("@urweb", SqlDbType.VarChar, 50).Value = BE.urweb;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@telef2", SqlDbType.VarChar, 12).Value = BE.telef2;
                        cmd.Parameters.Add("@clientetipo", SqlDbType.Char, 1).Value = BE.clientetipo;
                        cmd.Parameters.Add("@contacto", SqlDbType.VarChar, 40).Value = BE.contacto;
                        cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                        //cmd.Parameters.Add("@diralter", SqlDbType.Bit).Value = BE.diralter;
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

        public String GetNextCod(string empresaid, tb_cliente BE)
        {
            String newcod = "";

            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCliente_SEARCH_nextcod", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        cnx.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            newcod = Convert.ToString(reader["nextcod"]);
                        }
                        return newcod;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public DataSet GetOne(string empresaid, string ctacte)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCliente_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = ctacte;
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
