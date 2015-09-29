using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Comercial_Frm_PedidoResultado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LkBtnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Comercial/Frm_PedidoRegistro.aspx");
    }

    protected void LkBtnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Comercial/Frm_PedidoMenu.aspx");
    }

    protected void LkBtnPrint1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Comercial/Frm_PedidoMenu.aspx");
    }

    protected void LkBtnPrint2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Comercial/Frm_PedidoMenu.aspx");
    }
}
