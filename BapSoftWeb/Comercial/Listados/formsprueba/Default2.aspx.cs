using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;  
public partial class Comercial_Listados_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         if (!this.IsPostBack)  
    {  
        DataTable dt = new DataTable();  
        dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id", typeof(int)),  
                            new DataColumn("Name", typeof(string)),  
                            new DataColumn("Country",typeof(string)) });  
        dt.Rows.Add(1, "Jonathan Orozco", "Monterrey");  
        dt.Rows.Add(2, "Jesus Corona", "México");  
        dt.Rows.Add(3, "Cirilo Zaucedo", "Tijuana");  
        dt.Rows.Add(4, "Humberto Suazo", "Chile");
        dt.Rows.Add(5, "Jonathan Orozco", "Monterrey");
        dt.Rows.Add(6, "Jesus Corona", "México");
        dt.Rows.Add(7, "Cirilo Zaucedo", "Tijuana");
        dt.Rows.Add(8, "Humberto Suazo", "Chile");
        dt.Rows.Add(9, "Jonathan Orozco", "Monterrey");
        dt.Rows.Add(10, "Jesus Corona", "México");
        dt.Rows.Add(11, "Cirilo Zaucedo", "Tijuana");
        dt.Rows.Add(12, "Humberto Suazo", "Chile");
        dt.Rows.Add(13, "Jonathan Orozco", "Monterrey");
        dt.Rows.Add(14, "Jesus Corona", "México");
        dt.Rows.Add(15, "Cirilo Zaucedo", "Tijuana");
        dt.Rows.Add(16, "Humberto Suazo", "Chile");
        dt.Rows.Add(17, "Jonathan Orozco", "Monterrey");
        dt.Rows.Add(18, "Jesus Corona", "México");
        dt.Rows.Add(19, "Cirilo Zaucedo", "Tijuana");
        dt.Rows.Add(20, "Humberto Suazo", "Chile");
        dt.Rows.Add(21, "Jonathan Orozco", "Monterrey");
        dt.Rows.Add(22, "Jesus Corona", "México");
        dt.Rows.Add(23, "Cirilo Zaucedo", "Tijuana");
        dt.Rows.Add(24, "Humberto Suazo", "Chile");
        dt.Rows.Add(25, "Jonathan Orozco", "Monterrey");
        dt.Rows.Add(26, "Jesus Corona", "México");
        dt.Rows.Add(27, "Cirilo Zaucedo", "Tijuana");
        dt.Rows.Add(28, "Humberto Suazo", "Chile");
        dt.Rows.Add(29, "Jonathan Orozco", "Monterrey");
        dt.Rows.Add(30, "Jesus Corona", "México");
        dt.Rows.Add(31, "Cirilo Zaucedo", "Tijuana");
        dt.Rows.Add(32, "Humberto Suazo", "Chile");
        dt.Rows.Add(33, "Jonathan Orozco", "Monterrey");
        dt.Rows.Add(34, "Jesus Corona", "México");
        dt.Rows.Add(35, "Cirilo Zaucedo", "Tijuana");
        dt.Rows.Add(36, "Humberto Suazo", "Chile");
        dt.Rows.Add(37, "Jonathan Orozco", "Monterrey");
        dt.Rows.Add(38, "Jesus Corona", "México");
        dt.Rows.Add(39, "Cirilo Zaucedo", "Tijuana");
        dt.Rows.Add(40, "Humberto Suazo", "Chile");  

        GridView1.DataSource = dt;  
        GridView1.DataBind(); 
    }
    }
}