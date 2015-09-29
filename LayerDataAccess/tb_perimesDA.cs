using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class tb_perimesDA
    {
      ConexionDA conex = new ConexionDA();
      public List<tb_perimes> Get_Mes(string empresaid) 
      {
          using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
          {
              using (SqlCommand cmd = new SqlCommand("tb_perimes_SEARCH", cnx))
              {
                  cmd.CommandType = CommandType.StoredProcedure;
                  List<tb_perimes> lista = new List<tb_perimes>();                
                  try
                  {
                      cnx.Open();
                      using (SqlDataReader dr = cmd.ExecuteReader()) 
                      {
                          while (dr.Read())
                          {
                              tb_perimes BE = new tb_perimes();
                              BE.perimesid = Convert.ToString(dr["perimesid"]);
                              BE.perimesname = Convert.ToString(dr["perimesname"]);

                              lista.Add(BE);
                          }
                          return lista;
                      }
                  }
                  catch (Exception)
                  {                      
                      throw;
                  }                        
              }  
          }
      }





    
    }
}
