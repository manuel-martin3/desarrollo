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
    public class cliente_direcDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert_XML(string empresaid, tb_cliente_direc BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbClienteDirec_INSERT_xml", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@XML", SqlDbType.Xml).Value = BE.GetItemXML();

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

        public bool Insert(string empresaid, tb_cliente_direc BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid))){
                using (SqlCommand cmd = new SqlCommand("gspTbClienteDirec_INSERT", cnx))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                    cmd.Parameters.Add("@direcnume", SqlDbType.Char, 3).Value = BE.direcnume;
                    cmd.Parameters.Add("@direcname", SqlDbType.VarChar, 25).Value = BE.direcname;
                    cmd.Parameters.Add("@direcdeta", SqlDbType.VarChar, 100).Value = BE.direcdeta;
                    cmd.Parameters.Add("@telef", SqlDbType.VarChar, 30).Value = BE.telef;
                    cmd.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE.ubige;
                    cmd.Parameters.Add("@status", SqlDbType.Char).Value = BE.status;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;

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

        public bool Insert_dbf(string empresaid, tb_cliente_direc BE)
        {
            Conex_Fox2DA cone = new Conex_Fox2DA();
            using (OleDbConnection cnx = new OleDbConnection(cone.AdmConexion()))
            {
                String commandString =
                "INSERT INTO faccl605 (CL605STAT , " +
                                      "CL605IDCL ," +
                                      "CL605NDIR ," +
                                      "CL605DIRE ," +
                                      "CL605TELF ," +
                                      "CL605CTTO ," +
                                      "CL605CTDA ," +
                                      "CL605NFAX ," +
                                      "CL605DEPA ," +
                                      "CL605PROV ," +
                                      "CL605DIST ," +
                                      "CL605SITU ," +
                                      "CL605USID ," +
                                      "CL605FEAC " +                                     
                                      ")" +

                " VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                OleDbCommand cmd = new OleDbCommand(commandString, cnx);
                cmd.Parameters.Add("@CL605STAT", OleDbType.Integer).Value = BE.status;
                cmd.Parameters.Add("@CL605IDCL", OleDbType.Char, 4).Value = BE.ctacte;
                cmd.Parameters.Add("@CL605NDIR", OleDbType.Char, 2).Value = BE.direcnume;
                cmd.Parameters.Add("@CL605DIRE", OleDbType.VarChar, 100).Value = BE.direcdeta;
                cmd.Parameters.Add("@CL605TELF", OleDbType.Char ,11).Value = BE.telef;
                cmd.Parameters.Add("@CL605CTTO", OleDbType.VarChar, 30).Value = BE.direcname;
                cmd.Parameters.Add("@CL605CTDA", OleDbType.Char, 2).Value = "".ToString();
                cmd.Parameters.Add("@CL605NFAX", OleDbType.Char, 11).Value = "".ToString();
                cmd.Parameters.Add("@CL605DEPA", OleDbType.Char, 2).Value = BE.ubig1;
                cmd.Parameters.Add("@CL605PROV", OleDbType.Char, 2).Value = BE.ubig2;
                cmd.Parameters.Add("@CL605DIST", OleDbType.Char, 3).Value = BE.ubig3;
                cmd.Parameters.Add("@CL605SITU", OleDbType.Boolean).Value = false;
                cmd.Parameters.Add("@CL605USID", OleDbType.Char, 3).Value = BE.usuar;
                cmd.Parameters.Add("@CL605FEAC", OleDbType.Date).Value = DateTime.Today.ToShortDateString();

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

        public bool Update_dbf(string empresaid, tb_cliente_direc BE)
        {
            Conex_Fox2DA cone = new Conex_Fox2DA();
            using (OleDbConnection cnx = new OleDbConnection(cone.AdmConexion()))
            {
                String commandString =
                "UPDATE faccl605  SET  " +
                                 " CL605STAT = ? ," +
                                 " CL605DIRE = ? ," +
                                 " CL605TELF = ? ," +
                                 " CL605CTTO = ? ," +
                                 " CL605CTDA = ? ," +
                                 " CL605NFAX = ? ," +
                                 " CL605DEPA = ? ," +
                                 " CL605PROV = ? ," +
                                 " CL605DIST = ? ," +
                                 " CL605SITU = ? ," +
                                 " CL605USID = ? ," +
                                 " CL605FEAC = ? " +
                " WHERE CL605IDCL  = ?  AND CL605NDIR = ? ";



                OleDbCommand cmd = new OleDbCommand(commandString, cnx);
                cmd.Parameters.Add("@CL605STAT", OleDbType.Integer).Value = BE.status;               
                cmd.Parameters.Add("@CL605DIRE", OleDbType.VarChar, 100).Value = BE.direcdeta;
                cmd.Parameters.Add("@CL605TELF", OleDbType.Char, 11).Value = BE.telef;
                cmd.Parameters.Add("@CL605CTTO", OleDbType.VarChar, 30).Value = BE.direcname;
                cmd.Parameters.Add("@CL605CTDA", OleDbType.Char, 2).Value = "".ToString();
                cmd.Parameters.Add("@CL605NFAX", OleDbType.Char, 11).Value = "".ToString();
                cmd.Parameters.Add("@CL605DEPA", OleDbType.Char, 2).Value = BE.ubig1;
                cmd.Parameters.Add("@CL605PROV", OleDbType.Char, 2).Value = BE.ubig2;
                cmd.Parameters.Add("@CL605DIST", OleDbType.Char, 3).Value = BE.ubig3;
                cmd.Parameters.Add("@CL605SITU", OleDbType.Boolean).Value = false;
                cmd.Parameters.Add("@CL605USID", OleDbType.Char, 3).Value = BE.usuar;
                cmd.Parameters.Add("@CL605FEAC", OleDbType.Date).Value = DateTime.Today.ToShortDateString();
                cmd.Parameters.Add("@CL605IDCL", OleDbType.Char, 4).Value = BE.ctacte;
                cmd.Parameters.Add("@CL605NDIR", OleDbType.Char, 2).Value = BE.direcnume;

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

        public bool Update(string empresaid, tb_cliente_direc BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid))){
                using (SqlCommand cmd = new SqlCommand("gspTbClienteDirec_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@direcnume", SqlDbType.Char, 3).Value = BE.direcnume;
                        cmd.Parameters.Add("@direcname", SqlDbType.VarChar, 25).Value = BE.direcname;
                        cmd.Parameters.Add("@direcdeta", SqlDbType.VarChar, 100).Value = BE.direcdeta;
                        cmd.Parameters.Add("@telef", SqlDbType.VarChar, 30).Value = BE.telef;
                        cmd.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE.ubige;
                        cmd.Parameters.Add("@status", SqlDbType.Char).Value = BE.status;
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

        public bool Delete(string empresaid, tb_cliente_direc BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid))){
                using (SqlCommand cmd = new SqlCommand("gspTbClienteDirec_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@direcnume", SqlDbType.Char, 3).Value = BE.direcnume;
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

        public bool Delete_dbf(string empresaid, tb_cliente_direc BE)
        {
            Conex_Fox2DA cone = new Conex_Fox2DA();
            using (OleDbConnection cnx = new OleDbConnection(cone.AdmConexion()))
            {
                String commandString =
                "UPDATE faccl605  SET  " +
                                 " CL605STAT = ? " +                                 
                " WHERE CL605IDCL  = ?  AND CL605NDIR = ? ";

                OleDbCommand cmd = new OleDbCommand(commandString, cnx);
                cmd.Parameters.Add("@CL605STAT", OleDbType.Integer).Value = BE.status;  
                cmd.Parameters.Add("@CL605IDCL", OleDbType.Char, 4).Value = BE.ctacte;
                cmd.Parameters.Add("@CL605NDIR", OleDbType.Char, 2).Value = BE.direcnume;
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

        public DataSet GetAll(string empresaid, tb_cliente_direc BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid))){
                using (SqlCommand cmd = new SqlCommand("gspTbClienteDirec_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;
                        cmd.Parameters.Add("@direcnume", SqlDbType.Char, 3).Value = BE.direcnume;
                        cmd.Parameters.Add("@direcname", SqlDbType.VarChar, 25).Value = BE.direcname;
                        cmd.Parameters.Add("@direcdeta", SqlDbType.VarChar, 100).Value = BE.direcdeta;
                        cmd.Parameters.Add("@telef", SqlDbType.VarChar, 30).Value = BE.telef;
                        cmd.Parameters.Add("@ubige", SqlDbType.Char, 6).Value = BE.ubige;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@nombrelike1", SqlDbType.VarChar, 30).Value = BE.nombrelike1;
                        cmd.Parameters.Add("@nombrelike2", SqlDbType.VarChar, 30).Value = BE.nombrelike2;
                        cmd.Parameters.Add("@nombrelike3", SqlDbType.VarChar, 30).Value = BE.nombrelike3;
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

        public DataSet Gen_NumDirecc(string empresaid, tb_cliente_direc BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbGenNumDirec_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = BE.ctacte;         
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

        public DataSet GetAll_CODdbf(string empresaid, tb_cliente_direc BE)
        {
            Conex_FoxDA cone = new Conex_FoxDA();
            using (OleDbConnection cnx = new OleDbConnection(cone.AdmConexion()))
            {
                String commandString =
                "SELECT CL605IDCL,CL605NDIR FROM faccl605 WHERE CL605IDCL = ? AND CL605NDIR = ?";

                using (OleDbCommand cmd = new OleDbCommand(commandString, cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.Add("@CL605IDCL ", OleDbType.Char, 4).Value = BE.ctacte;
                        cmd.Parameters.Add("@CL605NDIR", OleDbType.Char, 2).Value = BE.direcnume;
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

        public DataSet GetOne(string empresaid, string ctacte, string nmdir)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid))){
                using (SqlCommand cmd = new SqlCommand("gspTbClienteDirec_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ctacte", SqlDbType.Char, 7).Value = ctacte;
                        cmd.Parameters.Add("@nmdir", SqlDbType.Char, 3).Value = nmdir;
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
