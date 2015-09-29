using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class usuariosDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_usuarios BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbUsuarios_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@USUAR", SqlDbType.Char, 15).Value = BE.usuar;
                    cmd.Parameters.Add("@NOMBR", SqlDbType.VarChar, 30).Value = BE.nombr;
                    cmd.Parameters.Add("@CLAVE", SqlDbType.Char, 10).Value = BE.clave;
                    cmd.Parameters.Add("@admin", SqlDbType.Bit).Value = BE.admin;
                    cmd.Parameters.Add("@activo", SqlDbType.Bit).Value = BE.activo;
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

        public bool Update(string empresaid, tb_usuarios BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbUsuarios_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@USUAR", SqlDbType.Char, 15).Value = BE.usuar;
                        cmd.Parameters.Add("@NOMBR", SqlDbType.VarChar, 30).Value = BE.nombr;
                        cmd.Parameters.Add("@CLAVE", SqlDbType.Char, 10).Value = BE.clave;
                        cmd.Parameters.Add("@admin", SqlDbType.Bit).Value = BE.admin;
                        cmd.Parameters.Add("@activo", SqlDbType.Bit).Value = BE.activo;
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

        public bool Update_modificarclave(string empresaid, tb_usuarios BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbUsuarios_UPDATE_modificarclave", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@USUAR", SqlDbType.Char, 15).Value = BE.usuar;
                        cmd.Parameters.Add("@CLAVE", SqlDbType.Char, 10).Value = BE.clave;
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

        public bool Update_modificarfoto(string empresaid, tb_usuarios BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbUsuarios_UPDATE_modificarfoto", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@USUAR", SqlDbType.Char, 15).Value = BE.usuar;
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

        public bool Delete(string empresaid, tb_usuarios BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbUsuarios_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@USUAR", SqlDbType.Char, 15).Value = BE.usuar;
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

        public DataSet GetAll(string empresaid, tb_usuarios BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbUsuarios_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@USUAR", SqlDbType.Char, 15).Value = BE.usuar;
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

        public DataSet BuscarUsuarios(string empresaid, tb_usuarios BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbUsuarios_SEARCH_2", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@nombr", SqlDbType.VarChar, 30).Value = BE.nombr;
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


        public DataSet GetAll_paginacion(string empresaid, tb_usuarios BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbUsuarios_SEARCH_paginacion", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@USUAR", SqlDbType.Char, 15).Value = BE.usuar;
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

        public DataSet GetAll_perfil(string empresaid, tb_usuarios BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbUsuarios_SEARCH_perfil", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@USUAR", SqlDbType.Char, 15).Value = BE.usuar;
                        cmd.Parameters.Add("@idper", SqlDbType.Char, 9).Value = BE.idper;
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

        public DataSet GetAll2(string empresaid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbUsuariosperfil_SEARCH2", cnx))
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

        public DataSet GetOne(string empresaid, string usuar)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbUsuarios_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@USUAR", SqlDbType.Char, 15).Value = usuar;
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
        //procedure listar usuarios sin perfil
        public DataTable GetSinPerfil(string empresaid)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbUsuariosperfil_SEARCH2", cnx))
                {
                    DataTable dt = new DataTable();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                    }

                    try
                    {
                        cnx.Open();
                        dt.Load(cmd.ExecuteReader());
                        return dt;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        //logueo usuario
        public DataSet ValidarUsuario(string empresaid, string usuar, string CLAVE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("SP_VALIDARLOGIN", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@usuario", SqlDbType.Char, 15));
                        cmd.Parameters["@usuario"].Direction = ParameterDirection.Input;
                        cmd.Parameters["@usuario"].Value = usuar;

                        cmd.Parameters.Add(new SqlParameter("@PASSWORD", SqlDbType.Char, 10));
                        cmd.Parameters["@PASSWORD"].Direction = ParameterDirection.Input;
                        cmd.Parameters["@PASSWORD"].Value = CLAVE;
                    }

                    try
                    {
                        cnx.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds, "UsuarioValidado");
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

        //GenerarMenuXperfil
        public DataSet GenerarMenuXperfil(string empresaid, string COD_USU, string idper)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerOpcionesMenu", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@USUARIO", SqlDbType.Char, 15).Value = COD_USU;
                        cmd.Parameters.Add("@idper", SqlDbType.Char, 9).Value = idper;
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

        public DataSet GenerarMenuXperfil_child(string empresaid, string COD_USU, string idper)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerOpcionesMenu_node", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@USUARIO", SqlDbType.Char, 15).Value = COD_USU;
                        cmd.Parameters.Add("@idper", SqlDbType.Char, 9).Value = idper;
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
