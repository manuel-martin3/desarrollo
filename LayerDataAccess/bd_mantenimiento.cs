using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class bd_mantenimiento
    {
        ConexionDA conex = new ConexionDA();

        public bool existeTabla(string empresaid, string nombreTabla)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                string sCmd =
                            "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES " +
                            "WHERE TABLE_TYPE = 'BASE TABLE' " +
                            "AND TABLE_NAME = @nombreTabla";
                using (SqlCommand cmd = new SqlCommand(sCmd, cnx))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nombreTabla", nombreTabla);

                    // Comprobamos si está
                    // Devuelve 1 si ya existe
                    // o 0 si no existe

                    try
                    {
                        cnx.Open();
                        if ((int)cmd.ExecuteScalar() > 0)
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

        public bool existeProcedimiento(string empresaid, string nombrePA)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                string sCmd =
                    "SELECT COUNT(*) FROM INFORMATION_SCHEMA.ROUTINES " +
                    "WHERE ROUTINE_TYPE = 'PROCEDURE' " +
                    "AND ROUTINE_NAME = @nombrePA";

                using (SqlCommand cmd = new SqlCommand(sCmd, cnx))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nombrePA", nombrePA);

                    // Comprobamos si está
                    // Devuelve 1 si ya existe
                    // o 0 si no existe

                    try
                    {
                        cnx.Open();
                        if ((int)cmd.ExecuteScalar() > 0)
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

        public bool tb_adm_actadereunion(string empresaid, string nombrePA)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                string sCmd =
                    "SELECT COUNT(*) FROM INFORMATION_SCHEMA.ROUTINES " +
                    "WHERE ROUTINE_TYPE = 'PROCEDURE' " +
                    "AND ROUTINE_NAME = @nombrePA";

                using (SqlCommand cmd = new SqlCommand(sCmd, cnx))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nombrePA", nombrePA);

                    // Comprobamos si está
                    // Devuelve 1 si ya existe
                    // o 0 si no existe

                    try
                    {
                        cnx.Open();
                        if ((int)cmd.ExecuteScalar() > 0)
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
