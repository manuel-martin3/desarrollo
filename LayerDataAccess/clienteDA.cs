using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;
using System.Data.OleDb;

namespace LayerDataAccess
{
    public class clienteDA
    {
        public string Sql_Error = "";
        ConexionDA conex = new ConexionDA();

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
                    cmd.Parameters.Add("@listaprecid", SqlDbType.Int).Value = BE.listaprecid;
                    cmd.Parameters.Add("@replegaldni", SqlDbType.Char, 8).Value = BE.replegaldni;
                    cmd.Parameters.Add("@replegalname", SqlDbType.VarChar, 30).Value = BE.replegalname;
                    cmd.Parameters.Add("@canalventaid", SqlDbType.Char, 3).Value = BE.canalventaid;


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

        public bool Insert_dbf(string empresaid, tb_cliente BE)
        {
            Conex_Fox2DA cone = new Conex_Fox2DA();
            using (OleDbConnection cnx = new OleDbConnection(cone.AdmConexion()))
            {
                String commandString =
                "INSERT INTO faccl600 (CL600STAT , " +
                                      "CL600IDCL ," +
                                      "CL600NAME ," +
                                      "CL600NRUC ," +
                                      "CL600TABL ," +
                                      "CL600TPCL ," +
                                      "CL600SERV ," +
                                      "CL600APCP ," +   
                                      "CL600CALM ," +
                                      "CL600CATE ," +
                                      "CL600REPR ," +
                                      "CL600DOID ," +
                                      "CL600USID ," +
                                      "CL600FEAC ," +         
                                      "CL600IDSC ," +
                                      "CL600TAPI ," +
                                      "CL600DIRE ," +
                                      "CTACTE     " +
                                      ")" +

                " VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                OleDbCommand cmd = new OleDbCommand(commandString, cnx);
                cmd.Parameters.Add("@CL600STAT", OleDbType.Integer).Value = BE.status;
                cmd.Parameters.Add("@CL600IDCL", OleDbType.Char, 4).Value = BE.ctacte;
                cmd.Parameters.Add("@CL600NAME", OleDbType.VarChar, 60).Value = BE.ctactename;
                cmd.Parameters.Add("@CL600NRUC", OleDbType.VarChar, 11).Value = BE.nmruc;
                cmd.Parameters.Add("@CL600TABL", OleDbType.Integer).Value = "0".ToString();
                cmd.Parameters.Add("@CL600TPCL", OleDbType.Char, 1).Value = "P".ToString();
                cmd.Parameters.Add("@CL600SERV", OleDbType.VarChar, 30).Value = "03".ToString();
                cmd.Parameters.Add("@CL600APCP", OleDbType.Char, 2).Value = "05".ToString();
                cmd.Parameters.Add("@CL600CALM", OleDbType.Char, 2).Value = "".ToString();
                cmd.Parameters.Add("@CL600CATE", OleDbType.Char, 1).Value = "M".ToString();                
                cmd.Parameters.Add("@CL600REPR", OleDbType.VarChar, 25).Value = BE.replegalname;
                cmd.Parameters.Add("@CL600DOID", OleDbType.VarChar, 8).Value = BE.replegaldni;
                cmd.Parameters.Add("@CL600USID", OleDbType.Char, 3).Value = BE.usuar;
                cmd.Parameters.Add("@CL600FEAC", OleDbType.Date).Value = DateTime.Today.ToShortDateString();
                cmd.Parameters.Add("@CL600IDSC", OleDbType.Char, 2).Value = "".ToString();
                cmd.Parameters.Add("@CL600TAPI", OleDbType.Boolean).Value = false;
                cmd.Parameters.Add("@CL600DIRE", OleDbType.VarChar, 100).Value = BE.direc;
                cmd.Parameters.Add("@CTACTE", OleDbType.VarChar, 7).Value = BE.ctacte;
               
                cnx.Open();
                try
                {
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
                        cmd.Parameters.Add("@listaprecid", SqlDbType.Int).Value = BE.listaprecid;
                        cmd.Parameters.Add("@replegaldni", SqlDbType.Char, 8).Value = BE.replegaldni;
                        cmd.Parameters.Add("@replegalname", SqlDbType.VarChar, 30).Value = BE.replegalname;
                        cmd.Parameters.Add("@canalventaid", SqlDbType.Char, 3).Value = BE.canalventaid;
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

        public bool Update_dbf(string empresaid, tb_cliente BE)
        {
            Conex_Fox2DA cone = new Conex_Fox2DA();
            using (OleDbConnection cnx = new OleDbConnection(cone.AdmConexion()))
            {
                String commandString =
                "UPDATE faccl600  SET  " +
                                 " CL600STAT = ? ,"+
                                 " CL600NAME = ? ,"+
                                 " CL600NRUC = ? ," +
                                 " CL600TABL = ? ," +
                                 " CL600TPCL = ? ," +
                                 " CL600SERV = ? ," +
                                 " CL600APCP = ? ," +
                                 " CL600CALM = ? ," +
                                 " CL600CATE = ? ," +
                                 " CL600REPR = ? ," +
                                 " CL600DOID = ? ," +
                                 " CL600USID = ? ," +
                                 " CL600FEAC = ? ," +
                                 " CL600IDSC = ? ," +
                                 " CL600TAPI = ? ," +
                                 " CL600DIRE = ? ," +
                                 " CTACTE = ? " +
                " WHERE CL600IDCL  = ? ";



                OleDbCommand cmd = new OleDbCommand(commandString, cnx);
                cmd.Parameters.Add("@CL600STAT", OleDbType.Integer).Value = BE.status;                
                cmd.Parameters.Add("@CL600NAME", OleDbType.VarChar, 60).Value = BE.ctactename;
                cmd.Parameters.Add("@CL600NRUC", OleDbType.VarChar, 11).Value = BE.nmruc;
                cmd.Parameters.Add("@CL600TABL", OleDbType.Integer).Value = "0".ToString();
                cmd.Parameters.Add("@CL600TPCL", OleDbType.Char, 1).Value = "P".ToString();
                cmd.Parameters.Add("@CL600SERV", OleDbType.VarChar, 30).Value = "03".ToString();
                cmd.Parameters.Add("@CL600APCP", OleDbType.Char, 2).Value = "05".ToString();
                cmd.Parameters.Add("@CL600CALM", OleDbType.Char, 2).Value = "".ToString();
                cmd.Parameters.Add("@CL600CATE", OleDbType.Char, 1).Value = "M".ToString();
                cmd.Parameters.Add("@CL600REPR", OleDbType.VarChar, 25).Value = BE.replegalname;
                cmd.Parameters.Add("@CL600DOID", OleDbType.VarChar, 8).Value = BE.replegaldni;
                cmd.Parameters.Add("@CL600USID", OleDbType.Char, 3).Value = BE.usuar;
                cmd.Parameters.Add("@CL600FEAC", OleDbType.Date).Value = DateTime.Today.ToShortDateString();
                cmd.Parameters.Add("@CL600IDSC", OleDbType.Char, 2).Value = "".ToString();
                cmd.Parameters.Add("@CL600TAPI", OleDbType.Boolean).Value = false;
                cmd.Parameters.Add("@CL600DIRE", OleDbType.VarChar, 100).Value = BE.direc;
                cmd.Parameters.Add("@CTACTE", OleDbType.VarChar, 7).Value = BE.ctacte;
                cmd.Parameters.Add("@CL600IDCL", OleDbType.Char, 4).Value = BE.ctacte;

                cnx.Open();
                try
                {
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

        public DataSet GetAll_CODdbf(string empresaid, tb_cliente BE)
        {
            Conex_FoxDA cone = new Conex_FoxDA();
            using (OleDbConnection cnx = new OleDbConnection(cone.AdmConexion()))
            {
                String commandString =
                "SELECT COUNT(*) cant FROM faccl600 WHERE CL600IDCL = ?";

                using (OleDbCommand cmd = new OleDbCommand(commandString, cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.Add("@CL600IDCL ", OleDbType.Char, 4).Value = BE.ctacte;
                    }
                    try
                    {
                        cnx.Open();
                        using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
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


        public string BuscarCrear(string empresaid, tb_cliente BE)
        {
            string newcod = "";
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCliente_BUSCARCREAR", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@ctactename", SqlDbType.VarChar, 70).Value = BE.ctactename;
                        cmd.Parameters.Add("@docuidentid", SqlDbType.Char, 2).Value = BE.docuidentid;
                        cmd.Parameters.Add("@nmruc", SqlDbType.Char, 11).Value = BE.nmruc;
                        cmd.Parameters.Add("@tpperson", SqlDbType.Char, 2).Value = BE.tpperson;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    }

                    try
                    {
                        cnx.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            newcod = Convert.ToString(reader["ctacte"]);
                        }
                        return newcod;
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
