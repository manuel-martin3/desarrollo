using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;

namespace LayerDataAccess
{
    public class constantesgeneralesDA
    {
        ConexionDA conex = new ConexionDA();

        public bool Insert(string empresaid, tb_constantesgenerales BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbConstantesgenerales_INSERT", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@dominioid", SqlDbType.Char, 2).Value = BE.dominioid;
                    cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                    cmd.Parameters.Add("@local", SqlDbType.VarChar, 3).Value = BE.local;
                    cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                    cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                    cmd.Parameters.Add("@tcamb", SqlDbType.Decimal).Value = BE.tcamb;
                    cmd.Parameters.Add("@igv", SqlDbType.Decimal).Value = BE.igv;
                    cmd.Parameters.Add("@inprec", SqlDbType.Char, 1).Value = BE.inprec;
                    cmd.Parameters.Add("@tipfactura", SqlDbType.Char, 2).Value = BE.tipfactura;
                    cmd.Parameters.Add("@tipboleta", SqlDbType.Char, 2).Value = BE.tipboleta;
                    cmd.Parameters.Add("@tipordprod", SqlDbType.Char, 2).Value = BE.tipordprod;
                    cmd.Parameters.Add("@tipordcomp", SqlDbType.Char, 2).Value = BE.tipordcomp;
                    cmd.Parameters.Add("@tipproforma", SqlDbType.Char, 2).Value = BE.tipproforma;
                    cmd.Parameters.Add("@tipguia1", SqlDbType.Char, 2).Value = BE.tipguia1;
                    cmd.Parameters.Add("@tipguia2", SqlDbType.Char, 2).Value = BE.tipguia2;
                    cmd.Parameters.Add("@tipguia3", SqlDbType.Char, 2).Value = BE.tipguia3;
                    cmd.Parameters.Add("@tipajusteing", SqlDbType.Char, 2).Value = BE.tipajusteing;
                    cmd.Parameters.Add("@tipajustesal", SqlDbType.Char, 2).Value = BE.tipajustesal;
                    cmd.Parameters.Add("@monedn", SqlDbType.Char, 1).Value = BE.monedn;
                    cmd.Parameters.Add("@monede", SqlDbType.Char, 1).Value = BE.monede;
                    cmd.Parameters.Add("@monedu", SqlDbType.Char, 1).Value = BE.monedu;
                    cmd.Parameters.Add("@monednsimbolo", SqlDbType.VarChar, 30).Value = BE.monednsimbolo;
                    cmd.Parameters.Add("@monedesimbolo", SqlDbType.VarChar, 30).Value = BE.monedesimbolo;
                    cmd.Parameters.Add("@posl1", SqlDbType.SmallInt).Value = BE.posl1;
                    cmd.Parameters.Add("@longl1", SqlDbType.SmallInt).Value = BE.longl1;
                    cmd.Parameters.Add("@posl2", SqlDbType.SmallInt).Value = BE.posl2;
                    cmd.Parameters.Add("@longl2", SqlDbType.SmallInt).Value = BE.longl2;
                    cmd.Parameters.Add("@posl3", SqlDbType.SmallInt).Value = BE.posl3;
                    cmd.Parameters.Add("@longl3", SqlDbType.SmallInt).Value = BE.longl3;
                    cmd.Parameters.Add("@descl1", SqlDbType.VarChar, 30).Value = BE.descl1;
                    cmd.Parameters.Add("@descl2", SqlDbType.VarChar, 30).Value = BE.descl2;
                    cmd.Parameters.Add("@descl3", SqlDbType.VarChar, 30).Value = BE.descl3;
                    cmd.Parameters.Add("@fechdigini", SqlDbType.DateTime).Value = BE.fechdigini;
                    cmd.Parameters.Add("@fechdigfin", SqlDbType.DateTime).Value = BE.fechdigfin;

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

        public bool Update(string empresaid, tb_constantesgenerales BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbConstantesgenerales_UPDATE", cnx))
                {

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@dominioid", SqlDbType.Char, 2).Value = BE.dominioid;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.VarChar, 3).Value = BE.local;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        cmd.Parameters.Add("@fechadocedit", SqlDbType.Bit).Value = BE.fechadocedit;
                        cmd.Parameters.Add("@tcamb", SqlDbType.Decimal).Value = BE.tcamb;
                        cmd.Parameters.Add("@igv", SqlDbType.Decimal).Value = BE.igv;
                        cmd.Parameters.Add("@inprec", SqlDbType.Char, 1).Value = BE.inprec;
                        cmd.Parameters.Add("@tipfactura", SqlDbType.Char, 2).Value = BE.tipfactura;
                        cmd.Parameters.Add("@tipboleta", SqlDbType.Char, 2).Value = BE.tipboleta;
                        cmd.Parameters.Add("@tipordprod", SqlDbType.Char, 2).Value = BE.tipordprod;
                        cmd.Parameters.Add("@tipordcomp", SqlDbType.Char, 2).Value = BE.tipordcomp;
                        cmd.Parameters.Add("@tipproforma", SqlDbType.Char, 2).Value = BE.tipproforma;
                        cmd.Parameters.Add("@tipguia1", SqlDbType.Char, 2).Value = BE.tipguia1;
                        cmd.Parameters.Add("@tipguia2", SqlDbType.Char, 2).Value = BE.tipguia2;
                        cmd.Parameters.Add("@tipguia3", SqlDbType.Char, 2).Value = BE.tipguia3;
                        cmd.Parameters.Add("@tipajusteing", SqlDbType.Char, 2).Value = BE.tipajusteing;
                        cmd.Parameters.Add("@tipajustesal", SqlDbType.Char, 2).Value = BE.tipajustesal;
                        cmd.Parameters.Add("@monedn", SqlDbType.Char, 1).Value = BE.monedn;
                        cmd.Parameters.Add("@monede", SqlDbType.Char, 1).Value = BE.monede;
                        cmd.Parameters.Add("@monedu", SqlDbType.Char, 1).Value = BE.monedu;
                        cmd.Parameters.Add("@monednsimbolo", SqlDbType.VarChar, 30).Value = BE.monednsimbolo;
                        cmd.Parameters.Add("@monedesimbolo", SqlDbType.VarChar, 30).Value = BE.monedesimbolo;
                        cmd.Parameters.Add("@posl1", SqlDbType.SmallInt).Value = BE.posl1;
                        cmd.Parameters.Add("@longl1", SqlDbType.SmallInt).Value = BE.longl1;
                        cmd.Parameters.Add("@posl2", SqlDbType.SmallInt).Value = BE.posl2;
                        cmd.Parameters.Add("@longl2", SqlDbType.SmallInt).Value = BE.longl2;
                        cmd.Parameters.Add("@posl3", SqlDbType.SmallInt).Value = BE.posl3;
                        cmd.Parameters.Add("@longl3", SqlDbType.SmallInt).Value = BE.longl3;
                        cmd.Parameters.Add("@descl1", SqlDbType.VarChar, 30).Value = BE.descl1;
                        cmd.Parameters.Add("@descl2", SqlDbType.VarChar, 30).Value = BE.descl2;
                        cmd.Parameters.Add("@descl3", SqlDbType.VarChar, 30).Value = BE.descl3;
                        cmd.Parameters.Add("@fechdigini", SqlDbType.DateTime).Value = BE.fechdigini;
                        cmd.Parameters.Add("@fechdigfin", SqlDbType.DateTime).Value = BE.fechdigfin;
                        cmd.Parameters.Add("@ctactecli", SqlDbType.Char, 7).Value = BE.ctacteclie;
                        cmd.Parameters.Add("@ctacteinv", SqlDbType.Char, 7).Value = BE.ctacteinv;
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

        public bool Delete(string empresaid, tb_constantesgenerales BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbConstantesgenerales_DELETE", cnx))
                {
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@dominioid", SqlDbType.Char, 2).Value = BE.dominioid;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.VarChar, 3).Value = BE.local;
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

        public DataSet GetAll(string empresaid, tb_constantesgenerales BE)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbConstantesgenerales_SEARCH", cnx))
                {
                    DataSet ds = new DataSet();
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@dominioid", SqlDbType.Char, 2).Value = BE.dominioid;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = BE.moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.VarChar, 3).Value = BE.local;
                        cmd.Parameters.Add("@perianio", SqlDbType.Char, 4).Value = BE.perianio;
                        cmd.Parameters.Add("@perimes", SqlDbType.Char, 2).Value = BE.perimes;
                        /*cmd.Parameters.Add("@tcamb", SqlDbType.Decimal).Value = BE.tcamb;
                        cmd.Parameters.Add("@igv", SqlDbType.Decimal).Value = BE.igv;*/
                        cmd.Parameters.Add("@inprec", SqlDbType.Char, 1).Value = BE.inprec;
                        cmd.Parameters.Add("@tipfactura", SqlDbType.Char, 2).Value = BE.tipfactura;
                        cmd.Parameters.Add("@tipboleta", SqlDbType.Char, 2).Value = BE.tipboleta;
                        cmd.Parameters.Add("@tipordprod", SqlDbType.Char, 2).Value = BE.tipordprod;
                        cmd.Parameters.Add("@tipordcomp", SqlDbType.Char, 2).Value = BE.tipordcomp;
                        cmd.Parameters.Add("@tipproforma", SqlDbType.Char, 2).Value = BE.tipproforma;
                        cmd.Parameters.Add("@tipguia1", SqlDbType.Char, 2).Value = BE.tipguia1;
                        cmd.Parameters.Add("@tipguia2", SqlDbType.Char, 2).Value = BE.tipguia2;
                        cmd.Parameters.Add("@tipguia3", SqlDbType.Char, 2).Value = BE.tipguia3;
                        cmd.Parameters.Add("@tipajusteing", SqlDbType.Char, 2).Value = BE.tipajusteing;
                        cmd.Parameters.Add("@tipajustesal", SqlDbType.Char, 2).Value = BE.tipajustesal;
                        cmd.Parameters.Add("@monedn", SqlDbType.Char, 1).Value = BE.monedn;
                        cmd.Parameters.Add("@monede", SqlDbType.Char, 1).Value = BE.monede;
                        cmd.Parameters.Add("@monedu", SqlDbType.Char, 1).Value = BE.monedu;
                        cmd.Parameters.Add("@monednsimbolo", SqlDbType.VarChar, 30).Value = BE.monednsimbolo;
                        cmd.Parameters.Add("@monedesimbolo", SqlDbType.VarChar, 30).Value = BE.monedesimbolo;
                        /*cmd.Parameters.Add("@posl1", SqlDbType.SmallInt).Value = BE.posl1;
                        cmd.Parameters.Add("@longl1", SqlDbType.SmallInt).Value = BE.longl1;
                        cmd.Parameters.Add("@posl2", SqlDbType.SmallInt).Value = BE.posl2;
                        cmd.Parameters.Add("@longl2", SqlDbType.SmallInt).Value = BE.longl2;
                        cmd.Parameters.Add("@posl3", SqlDbType.SmallInt).Value = BE.posl3;
                        cmd.Parameters.Add("@longl3", SqlDbType.SmallInt).Value = BE.longl3;*/
                        cmd.Parameters.Add("@descl1", SqlDbType.VarChar, 30).Value = BE.descl1;
                        cmd.Parameters.Add("@descl2", SqlDbType.VarChar, 30).Value = BE.descl2;
                        cmd.Parameters.Add("@descl3", SqlDbType.VarChar, 30).Value = BE.descl3;
                        /*cmd.Parameters.Add("@fechdigini", SqlDbType.DateTime).Value = BE.fechdigini;
                        cmd.Parameters.Add("@fechdigfin", SqlDbType.DateTime).Value = BE.fechdigfin;*/
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

        public DataSet GetOne(string empresaid, string dominioid, string moduloid, string local)
        {
            using (SqlConnection cnx = new SqlConnection(conex.empConexion(empresaid)))
            {
                using (SqlCommand cmd = new SqlCommand("gspTbConstantesgenerales_SELECT", cnx))
                {
                    DataSet ds = new DataSet();

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@dominioid", SqlDbType.Char, 2).Value = dominioid;
                        cmd.Parameters.Add("@moduloid", SqlDbType.Char, 4).Value = moduloid;
                        cmd.Parameters.Add("@local", SqlDbType.VarChar, 3).Value = local;
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
