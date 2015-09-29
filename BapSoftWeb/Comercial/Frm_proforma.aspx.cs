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

public partial class Comercial_Frm_proforma : System.Web.UI.Page
{
    Genericas fungen = new Genericas();
    SimpleAES funcript = new SimpleAES();
    static string filtro; //filtro de busqueda
    static string clave = "", tabla_accion = ""; //activa la clave dependiendo del formulario
    static decimal xamort; //activa la clave dependiendo del formulario 

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }


    protected void btn_bustrabajador_Click(object sender, ImageClickEventArgs e)
    {
        GridView1.Visible = false;
        GridView1.Columns.Clear();
        filtro = "PS";
        txt_titulo.Text = "en Tabla Personal";
        bus_name.Text = "Buscar por: ";
        txt_filter.Text = "";
       

        ModalPanel1.Update();
        ModalPopupExtender1.Show();
    }
}