/*

The MIT License (MIT)
http://opensource.org/licenses/MIT

Copyright (c) 2014 Lester Sánchez (lester@ovicus.com)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

*/

using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using System.Text;
using System.IO;

using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxEditors;
using Word = Microsoft.Office.Interop.Word;

using Microsoft.VisualBasic;
using System.Reflection;


    public partial class Comercial_Listados_formsprueba_Grilla_Organizaciones : System.Web.UI.Page
    {
        SimpleAES funcript = new SimpleAES();
        DataTable TablaProd;
        private DataRow row;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ssEmpresaID"] = "02";
            cargar_grillaProd();
        }

        void cargar_grillaProd()
        {
            //tb_cxc_evalcredBL BL = new tb_cxc_evalcredBL();
            //tb_cxc_evalcred BE = new tb_cxc_evalcred();

            tb_pt_articuloWebBL BL = new tb_pt_articuloWebBL();
            tb_pt_articulo BE = new tb_pt_articulo();
            DataTable dt = new DataTable();
            //BE.articidold = txt_articidold.Text.ToUpper();
            BE.top = true;

            TablaProd = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];

            DataTable dtDatos = new DataTable();
            if (TablaProd.Rows.Count > 0)
            {
                dtDatos.Columns.Add("articidold");
                dtDatos.Columns.Add("articname");
                dtDatos.Columns.Add("marcaid");
                dtDatos.Columns.Add("marcaname");
                dtDatos.Columns.Add("articid");
                dtDatos.Columns.Add("pvt_cremenor");
                dtDatos.Columns.Add("tallaid");


                string canalid = "";
                string canalname = "";
                for (int i = 0; i < TablaProd.Rows.Count - 1; i++)
                {
                    DataRow dtRow = dtDatos.NewRow();
                    dtRow["articidold"] = TablaProd.Rows[i]["articidold"].ToString();
                    dtRow["articname"] = TablaProd.Rows[i]["articname"].ToString();
                    dtRow["marcaid"] = TablaProd.Rows[i]["marcaid"].ToString();
                    dtRow["marcaname"] = TablaProd.Rows[i]["marcaname"].ToString();
                    dtRow["articid"] = TablaProd.Rows[i]["articid"].ToString();
                    dtRow["pvt_cremenor"] = TablaProd.Rows[i]["precventa_cre_menor"].ToString();
                    dtRow["tallaid"] = TablaProd.Rows[i]["tallaid"].ToString();  

                    dtDatos.Rows.Add(dtRow);
                }
                GridViewProd.DataSource = dtDatos;
                GridViewProd.DataBind();
            }
        }

        protected void grdDept_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string strDept = GridViewProd.Rows[e.NewSelectedIndex].Cells[2].Text;
            lblErr.Text = strDept;
        }

        protected void GridViewProd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "articidold")
            {
                int index;
                string valor;
                index = int.Parse(e.CommandArgument.ToString());
                valor = GridViewProd.DataKeys[index].Value.ToString();
                lblErr.Text = valor.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string val = HdF2.Value.ToString();
            if (val.ToString() == "")
            {
                Session["org"] = "";
            }
            else
            {
                Session["org"] = val.ToString();
                Cerrarventana();
            }


        }

        private void Cerrarventana()
        {
            Page.ClientScript.RegisterOnSubmitStatement(typeof(Page), "closePage", "window.onunload = CloseWindow();");
            string close = @"<script type='text/javascript'>
                            window.returnValue = true;
                            window.close();
                            </script>";
            base.Response.Write(close);
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "<script type='text/JavaScript'>window.close();</script>");
        }
                
    }
