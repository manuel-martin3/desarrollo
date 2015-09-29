using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_co_MovimientoscabDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_co_Movimientoscab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientoscab_INSERT", cnx))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                    cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
                    cmd.Parameters.Add("@tipooperacion", SqlDbType.Char, 1).Value = BE.tipooperacion;
                    cmd.Parameters.Add("@tipocomprobante", SqlDbType.Char, 1).Value = BE.tipocomprobante;
                    cmd.Parameters.Add("@cuentaid", SqlDbType.Char, 10).Value = BE.cuentaid;
                    cmd.Parameters.Add("@tipomovimiento", SqlDbType.Char, 2).Value = BE.tipomovimiento;
                    cmd.Parameters.Add("@mediopago", SqlDbType.Char, 3).Value = BE.mediopago;
                    cmd.Parameters.Add("@numdocpago", SqlDbType.Char, 10).Value = BE.numdocpago;
                    cmd.Parameters.Add("@bancoid", SqlDbType.Char, 2).Value = BE.bancoid;
                    cmd.Parameters.Add("@fechregistro", SqlDbType.DateTime).Value = BE.fechregistro;
                    cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                    cmd.Parameters.Add("@tipcamuso", SqlDbType.Char, 1).Value = BE.tipcamuso;
                    cmd.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                    cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 100).Value = BE.glosa;
                    cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                    cmd.Parameters.Add("@flujoefectivo", SqlDbType.Char, 4).Value = BE.flujoefectivo;
                    cmd.Parameters.Add("@debesoles", SqlDbType.Decimal).Value = BE.debesoles;
                    cmd.Parameters.Add("@habersoles", SqlDbType.Decimal).Value = BE.habersoles;
                    cmd.Parameters.Add("@debedolares", SqlDbType.Decimal).Value = BE.debedolares;
                    cmd.Parameters.Add("@haberdolares", SqlDbType.Decimal).Value = BE.haberdolares;
                    cmd.Parameters.Add("@difcambio", SqlDbType.Bit).Value = BE.difcambio;
                    cmd.Parameters.Add("@redondeo", SqlDbType.Bit).Value = BE.redondeo;
                    cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
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

        public bool Update(string empresaid, tb_co_Movimientoscab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientoscab_UPDATE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
                        cmd.Parameters.Add("@tipooperacion", SqlDbType.Char, 1).Value = BE.tipooperacion;
                        cmd.Parameters.Add("@tipocomprobante", SqlDbType.Char, 1).Value = BE.tipocomprobante;
                        cmd.Parameters.Add("@cuentaid", SqlDbType.Char, 10).Value = BE.cuentaid;
                        cmd.Parameters.Add("@tipomovimiento", SqlDbType.Char, 2).Value = BE.tipomovimiento;
                        cmd.Parameters.Add("@mediopago", SqlDbType.Char, 3).Value = BE.mediopago;
                        cmd.Parameters.Add("@numdocpago", SqlDbType.Char, 10).Value = BE.numdocpago;
                        cmd.Parameters.Add("@bancoid", SqlDbType.Char, 2).Value = BE.bancoid;
                        cmd.Parameters.Add("@fechregistro", SqlDbType.DateTime).Value = BE.fechregistro;
                        cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                        cmd.Parameters.Add("@tipcamuso", SqlDbType.Char, 1).Value = BE.tipcamuso;
                        cmd.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                        cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 100).Value = BE.glosa;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@flujoefectivo", SqlDbType.Char, 4).Value = BE.flujoefectivo;
                        cmd.Parameters.Add("@debesoles", SqlDbType.Decimal).Value = BE.debesoles;
                        cmd.Parameters.Add("@habersoles", SqlDbType.Decimal).Value = BE.habersoles;
                        cmd.Parameters.Add("@debedolares", SqlDbType.Decimal).Value = BE.debedolares;
                        cmd.Parameters.Add("@haberdolares", SqlDbType.Decimal).Value = BE.haberdolares;
                        cmd.Parameters.Add("@difcambio", SqlDbType.Bit).Value = BE.difcambio;
                        cmd.Parameters.Add("@redondeo", SqlDbType.Bit).Value = BE.redondeo;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
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

        public bool Delete(string empresaid, tb_co_Movimientoscab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientoscab_DELETE", cnx))
                {
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
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

        public DataSet GetAll(string empresaid, tb_co_Movimientoscab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientoscab_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@tipooperacion", SqlDbType.Char, 1).Value = BE.tipooperacion;
                        cmd.Parameters.Add("@tipocomprobante", SqlDbType.Char, 1).Value = BE.tipocomprobante;
                        cmd.Parameters.Add("@cuentaid", SqlDbType.Char, 10).Value = BE.cuentaid;
                        cmd.Parameters.Add("@tipomovimiento", SqlDbType.Char, 2).Value = BE.tipomovimiento;
                        cmd.Parameters.Add("@mediopago", SqlDbType.Char, 3).Value = BE.mediopago;
                        cmd.Parameters.Add("@numdocpago", SqlDbType.Char, 10).Value = BE.numdocpago;
                        cmd.Parameters.Add("@bancoid", SqlDbType.Char, 2).Value = BE.bancoid;
                        cmd.Parameters.Add("@fechregistro", SqlDbType.DateTime).Value = BE.fechregistro;
                        cmd.Parameters.Add("@fechdoc", SqlDbType.DateTime).Value = BE.fechdoc;
                        cmd.Parameters.Add("@tipcamuso", SqlDbType.Char, 1).Value = BE.tipcamuso;
                        //cmd.Parameters.Add("@tipcamb", SqlDbType.Decimal).Value = BE.tipcamb;
                        cmd.Parameters.Add("@glosa", SqlDbType.VarChar, 100).Value = BE.glosa;
                        cmd.Parameters.Add("@moneda", SqlDbType.Char, 1).Value = BE.moneda;
                        cmd.Parameters.Add("@flujoefectivo", SqlDbType.Char, 4).Value = BE.flujoefectivo;
                        //cmd.Parameters.Add("@debesoles", SqlDbType.Decimal).Value = BE.debesoles;
                        //cmd.Parameters.Add("@habersoles", SqlDbType.Decimal).Value = BE.habersoles;
                        //cmd.Parameters.Add("@debedolares", SqlDbType.Decimal).Value = BE.debedolares;
                        //cmd.Parameters.Add("@haberdolares", SqlDbType.Decimal).Value = BE.haberdolares;
                        cmd.Parameters.Add("@difcambio", SqlDbType.Bit).Value = BE.difcambio;
                        cmd.Parameters.Add("@redondeo", SqlDbType.Bit).Value = BE.redondeo;
                        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = BE.status;
                        cmd.Parameters.Add("@usuar", SqlDbType.Char, 15).Value = BE.usuar;
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

        public DataSet GetAsientoNume(string empresaid, tb_co_Movimientoscab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientoscab_SEARCH_asientonume", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
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

        public DataSet GetAsientoRoleo(string empresaid, tb_co_Movimientoscab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientoscab_SEARCH_paginacion", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
                        cmd.Parameters.Add("@tipo", SqlDbType.Char, 10).Value = BE.tipo;
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

        public DataSet GetOne(string empresaid, tb_co_Movimientoscab BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCoMovimientoscab_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@diarioid", SqlDbType.Char, 4).Value = BE.diarioid;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 6).Value = BE.asiento;
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
