using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_me_vendedorDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_me_vendedor BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMeVendedor_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                    cmd.Parameters.Add("@vendorname", SqlDbType.VarChar, 50).Value = BE.vendorname;
                    cmd.Parameters.Add("@appat", SqlDbType.VarChar, 20).Value = BE.appat;
                    cmd.Parameters.Add("@apmat", SqlDbType.VarChar, 20).Value = BE.apmat;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 30).Value = BE.nombre;
                    cmd.Parameters.Add("@ddnni", SqlDbType.Char, 8).Value = BE.ddnni;
                    cmd.Parameters.Add("@direcc", SqlDbType.VarChar, 100).Value = BE.direcc;
                    cmd.Parameters.Add("@fechnac", SqlDbType.DateTime).Value = BE.fechnac;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@fechini", SqlDbType.DateTime).Value = BE.fechini;
                    cmd.Parameters.Add("@fechcese", SqlDbType.DateTime).Value = BE.fechcese;
                    cmd.Parameters.Add("@telefono", SqlDbType.Char, 15).Value = BE.telefono;
                    cmd.Parameters.Add("@remunebas", SqlDbType.Decimal).Value = BE.remunebas;
                    cmd.Parameters.Add("@porccomic", SqlDbType.Decimal).Value = BE.porccomic;
                    cmd.Parameters.Add("@cargoid", SqlDbType.Char, 3).Value = BE.cargoid;
                    cmd.Parameters.Add("@fechasig", SqlDbType.DateTime).Value = BE.fechasig;
                    cmd.Parameters.Add("@sexo", SqlDbType.Char).Value = BE.sexo;
                    cmd.Parameters.Add("@conhijos", SqlDbType.Bit).Value = BE.conhijos;
                    cmd.Parameters.Add("@observac", SqlDbType.VarChar, 50).Value = BE.observac;
                    cmd.Parameters.Add("@status", SqlDbType.Char).Value = BE.status;
                    cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                    cmd.Parameters.Add("@comisiona", SqlDbType.Bit).Value = BE.comisiona;	

                    try
                    {
                        cnx.Open();
                        String newProdID = (String)cmd.ExecuteScalar();
                        if (newProdID.Length == 4)
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

        public bool Update(string empresaid, tb_me_vendedor BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMeVendedor_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                        cmd.Parameters.Add("@vendorname", SqlDbType.VarChar, 50).Value = BE.vendorname;
                        cmd.Parameters.Add("@appat", SqlDbType.VarChar, 20).Value = BE.appat;
                        cmd.Parameters.Add("@apmat", SqlDbType.VarChar, 20).Value = BE.apmat;
                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 30).Value = BE.nombre;
                        cmd.Parameters.Add("@ddnni", SqlDbType.Char, 8).Value = BE.ddnni;
                        cmd.Parameters.Add("@direcc", SqlDbType.VarChar, 100).Value = BE.direcc;
                        cmd.Parameters.Add("@fechnac", SqlDbType.DateTime).Value = BE.fechnac;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@fechini", SqlDbType.DateTime).Value = BE.fechini;
                        cmd.Parameters.Add("@fechcese", SqlDbType.DateTime).Value = BE.fechcese;
                        cmd.Parameters.Add("@telefono", SqlDbType.Char, 15).Value = BE.telefono;
                        cmd.Parameters.Add("@remunebas", SqlDbType.Decimal).Value = BE.remunebas;
                        cmd.Parameters.Add("@porccomic", SqlDbType.Decimal).Value = BE.porccomic;
                        cmd.Parameters.Add("@cargoid", SqlDbType.Char, 3).Value = BE.cargoid;
                        cmd.Parameters.Add("@fechasig", SqlDbType.DateTime).Value = BE.fechasig;
                        cmd.Parameters.Add("@sexo", SqlDbType.Char).Value = BE.sexo;
                        cmd.Parameters.Add("@conhijos", SqlDbType.Bit).Value = BE.conhijos;
                        cmd.Parameters.Add("@observac", SqlDbType.VarChar, 50).Value = BE.observac;
                        cmd.Parameters.Add("@status", SqlDbType.Char).Value = BE.status;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                        cmd.Parameters.Add("@comisiona", SqlDbType.Bit).Value = BE.comisiona;
                    }
                    try
                    {
                        cnx.Open();
                        String newProdID = (String)cmd.ExecuteScalar();
                        if (newProdID.Length == 4)
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

        public bool Delete(string empresaid, tb_me_vendedor BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMeVendedor_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
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

        public DataSet GetAll(string empresaid, tb_me_vendedor BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMeVendedor_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@vendorid", SqlDbType.Char, 4).Value = BE.vendorid;
                        cmd.Parameters.Add("@vendorname", SqlDbType.VarChar, 50).Value = BE.vendorname;
                        cmd.Parameters.Add("@appat", SqlDbType.VarChar, 20).Value = BE.appat;
                        cmd.Parameters.Add("@apmat", SqlDbType.VarChar, 20).Value = BE.apmat;
                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 30).Value = BE.nombre;
                        cmd.Parameters.Add("@ddnni", SqlDbType.Char, 8).Value = BE.ddnni;
                        cmd.Parameters.Add("@direcc", SqlDbType.VarChar, 100).Value = BE.direcc;
                        cmd.Parameters.Add("@fechnac", SqlDbType.DateTime).Value = BE.fechnac;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@fechini", SqlDbType.DateTime).Value = BE.fechini;
                        cmd.Parameters.Add("@fechcese", SqlDbType.DateTime).Value = BE.fechcese;
                        cmd.Parameters.Add("@telefono", SqlDbType.Char, 15).Value = BE.telefono;
                        cmd.Parameters.Add("@remunebas", SqlDbType.Decimal).Value = BE.remunebas;
                        cmd.Parameters.Add("@porccomic", SqlDbType.Decimal).Value = BE.porccomic;
                        cmd.Parameters.Add("@cargoid", SqlDbType.Char, 3).Value = BE.cargoid;
                        cmd.Parameters.Add("@fechasig", SqlDbType.DateTime).Value = BE.fechasig;
                        cmd.Parameters.Add("@sexo", SqlDbType.Char).Value = BE.sexo;
                        cmd.Parameters.Add("@conhijos", SqlDbType.Bit).Value = BE.conhijos;
                        cmd.Parameters.Add("@observac", SqlDbType.VarChar, 50).Value = BE.observac;
                        cmd.Parameters.Add("@status", SqlDbType.Char).Value = BE.status;
                        //cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
                        //cmd.Parameters.Add("@comisiona", SqlDbType.Bit).Value = BE.comisiona;
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

        public DataSet GetAll2(string empresaid, tb_me_vendedor BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMeVendedor_SEARCH2", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@parameters", SqlDbType.VarChar).Value = BE.parameters;
                        cmd.Parameters.Add("@activo", SqlDbType.Bit).Value = BE.activo;
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

        public DataSet GetReport(string empresaid, tb_me_vendedor BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        
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

        public DataSet GetOne(string empresaid, tb_me_vendedor BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        //cmd.Parameters.Add("@productid", SqlDbType.Char, 13).Value = BE.productid;
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

        public DataSet GetAll_MaxMin(string empresaid, tb_me_vendedor BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                       
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

        public DataSet GetAll_paginacion(string empresaid, tb_me_vendedor BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;                       
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


        // CLASE DE TB_ME_VENDEDORHISTORY
        public DataSet GetAll_History(string empresaid, tb_me_vendedor BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMeVendedorhistory_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@vendorid", SqlDbType.VarChar).Value = BE.vendorid;
                        //cmd.Parameters.Add("@activo", SqlDbType.Bit).Value = BE.activo;
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


        // CLASE DE TB_ME_VENDEDORFREEZE
        public bool Insert_Freeze(string empresaid, tb_me_vendedor BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbMeVendedorfreeze_INSERT", cnx))
                {                                                
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
