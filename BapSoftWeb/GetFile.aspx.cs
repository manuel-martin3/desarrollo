using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LayerDataAccess;
using LayerBusinessLogic;

public partial class GetFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        tb_cxc_pedidofilesBL BL = new tb_cxc_pedidofilesBL();
        
        // Get the file id from the query string
        String numdoc = Convert.ToString(Request.QueryString["ID"]);

        // Get the file from the database
        DataTable file = BL.GetAFile("02",numdoc).Tables[0];
        DataRow row = file.Rows[0];

        string name = (string)row["Name"];
        string contentType = (string)row["ContentType"];
        Byte[] data = (Byte[])row["Data"];

        // Send the file to the browser
        Response.AddHeader("Content-type", contentType);
        Response.AddHeader("Content-Disposition", "attachment; filename=" + name);
        Response.BinaryWrite(data);
        Response.Flush();
        Response.End();
    }
}