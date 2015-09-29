using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class Comercial_Listados_Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        tbl.BorderStyle = BorderStyle.Inset;
        tbl.BorderWidth = Unit.Pixel(1);

        string tablestring="";
        /*
        //dt is datatable object which holds DB results.
         tablestring=tablestring+"<table width="100%"><tr><td>First Column Heading</td><td>Second column Heading</td><td>Third column Heading</td></tr>";
         foreach(datarow dr in dt.rows)
        {
           tablestring=tablestring+"<tr><td>"+dr[0].tostring()+"</td><td>"+dr[1].tostring()+"</td><td>"+dr[2].tostring()+"</td></tr>";
        }
        tablestring=tablestring+"</table>";
 
        divTable.innerHTML=tablestring;
        */

    }
    protected void cmdCreate_Click(object sender, System.EventArgs e)
    {
        tbl.Controls.Clear();

        int rows = Int32.Parse(txtRows.Text);
        int cols = Int32.Parse(txtCols.Text);

        for (int i = 0; i < rows; i++)
        {
            TableRow rowNew = new TableRow();
            tbl.Controls.Add(rowNew);
            for (int j = 0; j < cols; j++)
            {
                TableCell cellNew = new TableCell();
                Label lblNew = new Label();
                lblNew.Text = "(" + i.ToString() + "," + j.ToString() + ")<br />";

                System.Web.UI.WebControls.Image imgNew = new System.Web.UI.WebControls.Image();
                imgNew.ImageUrl = "cellpic.png";

                cellNew.Controls.Add(lblNew);
                cellNew.Controls.Add(imgNew);

                if (chkBorder.Checked == true)
                {
                    cellNew.BorderStyle = BorderStyle.Inset;
                    cellNew.BorderWidth = Unit.Pixel(1);
                }

                rowNew.Controls.Add(cellNew);
            }
        }
    }
}