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

public partial class Comercial_Frm_PedidoDetalle : System.Web.UI.Page
{
    SimpleAES funcript = new SimpleAES();
    DataTable TablaProd, TablaPedido, TablaTallas;
    DataTable TablaDetalle;
    private DataRow row;

    protected void Page_Load(object sender, EventArgs e)
    {
 
        if (!Page.IsPostBack)
        {
            Session["ssEmpresaID"] = "02";            
        }
    }

    private void ArmadoTablasDetalle()
    {
        TablaDetalle = new DataTable("detalle");
        TablaDetalle.Columns.Add("articid", typeof(String));
        TablaDetalle.Columns.Add("articidold", typeof(String));
        TablaDetalle.Columns.Add("marcaid", typeof(String));
        TablaDetalle.Columns.Add("marcaname", typeof(String));
        TablaDetalle.Columns.Add("articname", typeof(String));

        TablaDetalle.Columns.Add("colorid", typeof(String));
        TablaDetalle.Columns.Add("colorname", typeof(String));
        TablaDetalle.Columns.Add("tallaid", typeof(String));
        TablaDetalle.Columns.Add("talla", typeof(String));

        TablaDetalle.Columns.Add("cantidad", typeof(Decimal));
        TablaDetalle.Columns["cantidad"].DefaultValue = 0;
        TablaDetalle.Columns.Add("precbruto", typeof(Decimal));
        TablaDetalle.Columns["precbruto"].DefaultValue = 0;
        TablaDetalle.Columns.Add("impobruto", typeof(Decimal));
        TablaDetalle.Columns["impobruto"].DefaultValue = 0;
        TablaDetalle.Columns.Add("precneto", typeof(Decimal));
        TablaDetalle.Columns["precneto"].DefaultValue = 0;
        TablaDetalle.Columns.Add("imponeto", typeof(Decimal));
        TablaDetalle.Columns["imponeto"].DefaultValue = 0;
        Session["TablaDetalle"] = TablaDetalle;
    }

    void cargar_grillaProd(String valorfind)
    {

        tb_me_stockdiariocabBL BL = new tb_me_stockdiariocabBL ();
        tb_me_stockdiariocab BE = new tb_me_stockdiariocab();
        DataTable dt = new DataTable();

        BE.valorfind = valorfind.ToString();
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
            for (int i = 0; i < TablaProd.Rows.Count; i++)
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

    private void CargarComboArticuloTallas(String xtallaid)
    {
        //Cargamos el Combo de Tallas ----> Que biene en forma Vertical
        tb_pt_tallaWebBL BL3 = new tb_pt_tallaWebBL();
        tb_pt_talla BE3 = new tb_pt_talla();
        DataTable dt3 = new DataTable();

        BE3.tallaid = xtallaid.ToString();
        TablaTallas = BL3.GetAll_vertical(Session["ssEmpresaID"].ToString(), BE3).Tables[0];

        DataTable dtDatos = new DataTable();
        if (TablaTallas.Rows.Count > 0)
        {
            dtDatos.Columns.Add("tallaid");
            dtDatos.Columns.Add("tallacol");
            dtDatos.Columns.Add("talla");
            string talla0 = " - [ Talla: ";
            string talla1 = ""; 
            for (int i = 0; i < TablaTallas.Rows.Count; i++)
            {
                DataRow dtRow = dtDatos.NewRow();
                dtRow["tallaid"] = TablaTallas.Rows[i]["tallaid"].ToString();                
                talla1 = TablaTallas.Rows[i]["tallacol"].ToString().Substring(5, 2) + talla0.ToString() + TablaTallas.Rows[i]["talla"].ToString() +' '+']';
                dtRow["talla"] = talla1.ToString();
                //dtRow["tallacol"] = TablaTallas.Rows[i]["tallacol"].ToString();
                //dtRow["talla"] = TablaTallas.Rows[i]["talla"].ToString();
                dtDatos.Rows.Add(dtRow);
            }
            
        cmb_tallaid.DataSource = dtDatos;
        cmb_tallaid.DataValueField = "tallaid";        
        cmb_tallaid.DataTextField = "talla";        
        cmb_tallaid.DataBind();

        }
    }

    private void CargarComboArticuloColor(String xarticid)
    {
        // Cargamos el Combo de Colores de Acuerdo al Articulo
        tb_pt_articulocolorWebBL BL2 = new tb_pt_articulocolorWebBL();
        tb_pt_articulocolor BE2 = new tb_pt_articulocolor();
        DataTable dt2 = new DataTable();
        BE2.articid = xarticid.ToString();

        dt2 = BL2.GetAll(Session["ssEmpresaID"].ToString(), BE2).Tables[0];
        cmb_colorid.DataSource = dt2;
        cmb_colorid.DataValueField = "colorid";
        cmb_colorid.DataTextField = "colorname";
        cmb_colorid.DataBind();
    }

    protected void LkBtnNext_Click(object sender, EventArgs e)
    {            
        Response.Redirect("~/Comercial/Frm_PedidoCronograma.aspx");         
    }

    protected void LkBtnPrev_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Comercial/Frm_PedidoRegistro.aspx");                  
    }

    protected void LkBtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Comercial/Frm_PedidoMenu.aspx");
    }
    
    protected void grdDept_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        string strDept = GridViewProd.Rows[e.NewSelectedIndex].Cells[2].Text;
        //lblErr.Text = strDept;
    }

    protected void GridViewProd_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "articidold")
        {
            int index;
            string valor;
            index = int.Parse(e.CommandArgument.ToString());
            valor = GridViewProd.DataKeys[index].Value.ToString();
            //lblErr.Text = valor.ToString();
        }
    }

    protected void BtnOk_Click(object sender, EventArgs e)
    {        
        CargarComboArticuloTallas(HdFtallaid.Value.ToString());
        CargarComboArticuloColor(HdFarticid.Value.ToString());
    }
    protected void BtnEnable_Click(object sender, EventArgs e)
    {
        if (HdFpar.Value.ToString()=="0")
	    {
            
            btn_add.Enabled = false;
        }
        else
        {
            btn_add.Enabled = true;
        }
        
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        cargar_grillaProd(txt_articidold.Text);        
        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "searchPopclick();", true);
    }
    protected void cmb_colorid_SelectedIndexChanged(object sender, EventArgs e)
    {
        stkDisponible();
    }
    protected void cmb_tallaid_SelectedIndexChanged(object sender, EventArgs e)
    {
        stkDisponible();    
    }
    void stkDisponible() {

        string disponible = "";
            
            DataTable Tablastkdisp;
            tb_me_stockdiariocabBL BL1 = new tb_me_stockdiariocabBL();
            tb_me_stockdiariocab BE1 = new tb_me_stockdiariocab();


            string talla = HdFtalla.Value.ToString();
            BE1.articid = HdFarticid.Value.ToString();
            BE1.coltall = cmb_tallaid.SelectedItem.ToString().Substring(0, 2);
            BE1.colorid = cmb_colorid.Text.ToString();
            Tablastkdisp = BL1.GetAllStkDisp(Session["ssEmpresaID"].ToString(), BE1).Tables[0];
           
            if (Tablastkdisp.Rows.Count > 0)
            {
                disponible = Tablastkdisp.Rows[0]["stockdisp"].ToString().Trim();
            }
            else
            {
                disponible = "0";
            }

                txtStkdisp.Text = disponible.ToString();
          
    }

    protected void btn_add_Click(object sender, EventArgs e)
    {

        if (txtStkdisp.Text != "" || txtStkdisp.Text != null)
        {
            cargar_grillaPedido();
            txtStkdisp.CssClass = "btn btn-success";
        }
        
    }


    void cargar_grillaPedido()
    {

        GridViewRow renglon = GridViewPedido.SelectedRow;
        DataTable dtDatos = null;

            if(Session["dt"] != null)
            dtDatos = Session["dt"] as DataTable;
            else
            {
            dtDatos.Columns.Add("articidold");
            dtDatos.Columns.Add("articname");
            //dtDatos.Columns.Add("marcaid");
            dtDatos.Columns.Add("marcaname");
            //dtDatos.Columns.Add("articid");
            dtDatos.Columns.Add("pvt_cremenor");
            }
            DataRow dtRow = dtDatos.NewRow();

            dtRow["articidold"] = txt_articidold.Text;
            dtRow["articname"] = txt_articname.Text;
            //dtRow["marcaid"] = TablaProd.Rows[i]["marcaid"].ToString();
            dtRow["marcaname"] = txt_marcaname.Text;
            //dtRow["articid"] = TablaProd.Rows[i]["articid"].ToString();
            dtRow["pvt_cremenor"] = txt_precventa_cre_menor.Text;
            //dtRow["tallaid"] = TablaProd.Rows[i]["tallaid"].ToString();
            dtDatos.Rows.Add(dtRow);
            GridViewPedido.DataSource = dtDatos;
            GridViewPedido.DataBind();
            Session["dt"] = dtDatos;


    }

    protected void btnStk_Click(object sender, EventArgs e)
    {
            stkDisponible(); 
    }
}
