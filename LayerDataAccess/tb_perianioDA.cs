using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using LayerBusinessEntities;

namespace LayerDataAccess
{
  public  class tb_perianioDA
    {
      ConexionDA conex = new ConexionDA();
      public List<tb_perianio> Get_anio(string empresaid ) 
      {
          using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
          {
              using (SqlCommand cmd = new SqlCommand("tb_perianio_SEARCH", cnx))
              {
                  cmd.CommandType = CommandType.StoredProcedure;
                  List<tb_perianio> lista = new List<tb_perianio>();
                  tb_perianio BE = new tb_perianio();
                  BE.Codigo = "0";
                  BE.Perianio = "»» SELECCIONE AÑO ««";
                  lista.Add(BE);
                  try
                  {
                      cnx.Open();
                      using (SqlDataReader dr = cmd.ExecuteReader()) 
                      {
                          while (dr.Read())
                          {
                              tb_perianio _anio = new tb_perianio();
                              _anio.Codigo = Convert.ToString(dr["codigo"]);
                              _anio.Perianio = Convert.ToString(dr["descripcion"]);

                              lista.Add(_anio);
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
