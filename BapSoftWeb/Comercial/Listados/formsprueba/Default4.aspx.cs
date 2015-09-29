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

public partial class Comercial_Listados_Default4 : System.Web.UI.Page
{
    DataTable TablaPendAprob;
    private DataRow row;
    protected void Page_Load(object sender, EventArgs e)
    {
        //cargar();
        cargar_grilla();
    }
    
    void cargar()
    {
        /*
        DataTable dttempo = new DataTable();
        dttempo = new DataTable();
        dttempo.Columns.Add("key", typeof(string));
        dttempo.Columns.Add("descrip", typeof(string));

        DataRow workRow;
        workRow = dttempo.NewRow();
        workRow["key"] = "00";
        workRow["descrip"] = "SELECT";
        dttempo.Rows.Add(workRow);
        */
        //---
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[4] { 
                            new DataColumn("Ruc", typeof(int)),  
                            new DataColumn("Cliente", typeof(string)),  
                            new DataColumn("Proforma",typeof(string)), 
                            new DataColumn("Vendedor",typeof(string))
                            
        });

        dt.Rows.Add(1222222222, "Jonathan Orozco", "PF20150001", "Monterrey");
        dt.Rows.Add(1222222222, "Jesus Corona", "PF20150001", "México");
        dt.Rows.Add(1222222222, "Cirilo Zaucedo", "PF20150001", "Tijuana");
        dt.Rows.Add(1222222222, "Jonathan Orozco", "PF20150001", "Monterrey");
        dt.Rows.Add(1222222222, "Jesus Corona", "PF20150001", "México");
        dt.Rows.Add(1222222222, "Cirilo Zaucedo", "PF20150001", "Tijuana");
        dt.Rows.Add(1222222222, "Jonathan Orozco", "PF20150001", "Monterrey");
        dt.Rows.Add(1222222222, "Jesus Corona", "PF20150001", "México");
        dt.Rows.Add(1222222222, "Cirilo Zaucedo", "PF20150001", "Tijuana");
        dt.Rows.Add(1222222222, "Jonathan Orozco", "PF20150001", "Monterrey");
        dt.Rows.Add(1222222222, "Jesus Corona", "PF20150001", "México");
        dt.Rows.Add(1222222222, "Cirilo Zaucedo", "PF20150001", "Tijuana");
        dt.Rows.Add(1222222222, "Jonathan Orozco", "PF20150001", "Monterrey");
        dt.Rows.Add(1222222222, "Jesus Corona", "PF20150001", "México");
        dt.Rows.Add(1222222222, "Cirilo Zaucedo", "PF20150001", "Tijuana");
        dt.Rows.Add(1222222222, "Jonathan Orozco", "PF20150001", "Monterrey");
        dt.Rows.Add(1222222222, "Jesus Corona", "PF20150001", "México");
        dt.Rows.Add(1222222222, "Cirilo Zaucedo", "PF20150001", "Tijuana");
        dt.Rows.Add(1222222222, "Jonathan Orozco", "PF20150001", "Monterrey");
        dt.Rows.Add(1222222222, "Jesus Corona", "PF20150001", "México");
        dt.Rows.Add(1222222222, "Cirilo Zaucedo", "PF20150001", "Tijuana");
        dt.Rows.Add(1222222222, "Jonathan Orozco", "PF20150001", "Monterrey");
        dt.Rows.Add(1222222222, "Jesus Corona", "PF20150001", "México");
        dt.Rows.Add(1222222222, "Cirilo Zaucedo", "PF20150001", "Tijuana");
        /*
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
        */
        GridView.DataSource = dt;
        GridView.DataBind();

        //---
        /*
        GridViewOrg.AutoGenerateColumns = true;
        GridViewOrg.DataSource = dttempo;
        GridViewOrg.DataBind();
         * */
    }
    
    void cargar_grilla()
    {
        tb_cxc_evalcredBL BL = new tb_cxc_evalcredBL();
        tb_cxc_evalcred BE = new tb_cxc_evalcred();
        TablaPendAprob = BL.GetAll_PendAprob("02", BE).Tables[0];
        if (TablaPendAprob.Rows.Count > 0)
        {
            GridView.DataSource = TablaPendAprob;
            GridView.DataBind();
        }
    }

    protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Name")
        {
            int index;
            string valor;
            index = int.Parse(e.CommandArgument.ToString());
            valor = GridView.DataKeys[index].Value.ToString();
            //   lblErr.Text = valor.ToString();
        }
    }
    protected void LkBCancelDel_Click(object sender, EventArgs e)
    {

    }
    protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void LkBSearch_Click(object sender, EventArgs e)
    {

    }
    protected void LkBCancelSer_Click(object sender, EventArgs e)
    {

    }
    protected void LkBUpdate_Click(object sender, EventArgs e)
    {

    }
    protected void LkBCancelUpd_Click(object sender, EventArgs e)
    {

    }
    protected void LkBDelete_Click(object sender, EventArgs e)
    {

    }

}