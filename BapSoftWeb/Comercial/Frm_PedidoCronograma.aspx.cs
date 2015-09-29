using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Comercial_Frm_PedidoCronograma : System.Web.UI.Page
{    
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LkBtnPrev_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Comercial/Frm_PedidoDetalle.aspx");    
    }

    protected void LkBtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Comercial/Frm_PedidoMenu.aspx");
    }

    protected void LkBtnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Comercial/Frm_PedidoResultado.aspx");
    }
}
