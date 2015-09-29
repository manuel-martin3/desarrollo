using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_cp_comercialestilosDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_cp_comercialestilos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCpComercialestilo_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@empresa", SqlDbType.Char, 2).Value = BE.empresa;
                    cmd.Parameters.Add("@asiento", SqlDbType.Char, 10).Value = BE.asiento;
                    cmd.Parameters.Add("@itemsestilo", SqlDbType.Char, 2).Value = BE.itemsestilo;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                    cmd.Parameters.Add("@estiloid", SqlDbType.VarChar, 40).Value = BE.estiloid;
                    cmd.Parameters.Add("@sufijo", SqlDbType.VarChar, 30).Value = BE.sufijo;
                    cmd.Parameters.Add("@imagenprenda", SqlDbType.VarChar, 250).Value = BE.imagenprenda;
                    cmd.Parameters.Add("@oproduccion", SqlDbType.Char, 10).Value = BE.oproduccion;
                    cmd.Parameters.Add("@divisionid", SqlDbType.Char, 4).Value = BE.divisionid;
                    cmd.Parameters.Add("@lineaid", SqlDbType.VarChar, 25).Value = BE.lineaid;
                    cmd.Parameters.Add("@observacion", SqlDbType.Text).Value = BE.observacion;
                    cmd.Parameters.Add("@detalleprenda", SqlDbType.VarChar, 70).Value = BE.detalleprenda;
                    cmd.Parameters.Add("@hojaruta", SqlDbType.Text).Value = BE.hojaruta;
                    cmd.Parameters.Add("@tipopedido", SqlDbType.Char, 2).Value = BE.tipopedido;
                    cmd.Parameters.Add("@status", SqlDbType.Bit).Value = BE.status;
                    cmd.Parameters.Add("@terminado", SqlDbType.Bit).Value = BE.terminado;
                    cmd.Parameters.Add("@fechtermino", SqlDbType.DateTime).Value = BE.fechtermino;
                    cmd.Parameters.Add("@estiloorden", SqlDbType.Int).Value = BE.estiloorden;
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

        public bool Update(string empresaid, tb_cp_comercialestilos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCpComercialestilo_UPDATE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@empresa", SqlDbType.Char, 2).Value = BE.empresa;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 10).Value = BE.asiento;
                        cmd.Parameters.Add("@itemsestilo", SqlDbType.Char, 2).Value = BE.itemsestilo;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@estiloid", SqlDbType.VarChar, 40).Value = BE.estiloid;
                        cmd.Parameters.Add("@sufijo", SqlDbType.VarChar, 30).Value = BE.sufijo;
                        cmd.Parameters.Add("@imagenprenda", SqlDbType.VarChar, 250).Value = BE.imagenprenda;
                        cmd.Parameters.Add("@oproduccion", SqlDbType.Char, 10).Value = BE.oproduccion;
                        cmd.Parameters.Add("@divisionid", SqlDbType.Char, 4).Value = BE.divisionid;
                        cmd.Parameters.Add("@lineaid", SqlDbType.VarChar, 25).Value = BE.lineaid;
                        cmd.Parameters.Add("@observacion", SqlDbType.Text).Value = BE.observacion;
                        cmd.Parameters.Add("@detalleprenda", SqlDbType.VarChar, 70).Value = BE.detalleprenda;
                        cmd.Parameters.Add("@hojaruta", SqlDbType.Text).Value = BE.hojaruta;
                        cmd.Parameters.Add("@tipopedido", SqlDbType.Char, 2).Value = BE.tipopedido;
                        cmd.Parameters.Add("@status", SqlDbType.Bit).Value = BE.status;
                        cmd.Parameters.Add("@terminado", SqlDbType.Bit).Value = BE.terminado;
                        cmd.Parameters.Add("@fechtermino", SqlDbType.DateTime).Value = BE.fechtermino;
                        cmd.Parameters.Add("@estiloorden", SqlDbType.Int).Value = BE.estiloorden;
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

        public bool Delete(string empresaid, tb_cp_comercialestilos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCpComercialestilo_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@empresa", SqlDbType.Char, 2).Value = BE.empresa;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 10).Value = BE.asiento;
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

        public DataSet GetAll(string empresaid, tb_cp_comercialestilos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCpComercialestilo_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@empresa", SqlDbType.Char, 2).Value = BE.empresa;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 10).Value = BE.asiento;
                        cmd.Parameters.Add("@itemsestilo", SqlDbType.Char, 2).Value = BE.itemsestilo;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.Char, 3).Value = BE.local;
                        cmd.Parameters.Add("@estiloid", SqlDbType.VarChar, 40).Value = BE.estiloid;
                        cmd.Parameters.Add("@sufijo", SqlDbType.VarChar, 30).Value = BE.sufijo;
                        cmd.Parameters.Add("@imagenprenda", SqlDbType.VarChar, 250).Value = BE.imagenprenda;
                        cmd.Parameters.Add("@oproduccion", SqlDbType.Char, 10).Value = BE.oproduccion;
                        cmd.Parameters.Add("@divisionid", SqlDbType.Char, 4).Value = BE.divisionid;
                        cmd.Parameters.Add("@lineaid", SqlDbType.VarChar, 25).Value = BE.lineaid;
                        cmd.Parameters.Add("@observacion", SqlDbType.Text).Value = BE.observacion;
                        cmd.Parameters.Add("@detalleprenda", SqlDbType.VarChar, 70).Value = BE.detalleprenda;
                        cmd.Parameters.Add("@hojaruta", SqlDbType.Text).Value = BE.hojaruta;
                        cmd.Parameters.Add("@tipopedido", SqlDbType.Char, 2).Value = BE.tipopedido;
                        cmd.Parameters.Add("@status", SqlDbType.Bit).Value = BE.status;
                        cmd.Parameters.Add("@terminado", SqlDbType.Bit).Value = BE.terminado;
                        cmd.Parameters.Add("@fechtermino", SqlDbType.DateTime).Value = BE.fechtermino;
                        cmd.Parameters.Add("@estiloorden", SqlDbType.Int).Value = BE.estiloorden;
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

        public DataSet GetOne(string empresaid, tb_cp_comercialestilos BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbCpComercialestilo_SELECT", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@empresa", SqlDbType.Char, 2).Value = BE.empresa;
                        cmd.Parameters.Add("@asiento", SqlDbType.Char, 10).Value = BE.asiento;
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
