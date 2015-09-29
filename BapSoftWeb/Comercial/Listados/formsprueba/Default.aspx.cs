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

public partial class Comercial_Listados_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //cargar();
    }

    void cargar()
    {
        DataTable dttempo = new DataTable();
        dttempo = new DataTable();
        dttempo.Columns.Add("key", typeof(string));
        dttempo.Columns.Add("descrip", typeof(string));

        DataRow workRow;
        workRow = dttempo.NewRow();
        workRow["key"] = "00";
        workRow["descrip"] = "SELECT";
        dttempo.Rows.Add(workRow);
        //--
        
        GridViewOrg.AutoGenerateColumns = true;
        GridViewOrg.DataSource = dttempo;
        GridViewOrg.DataBind();
    }

    private void CargarGrillaOrg()
    {

        DataTable dtDatos = new DataTable();
        //List<ReportPMT> m_Organizacion = new List<ReportPMT>();
        // Cuerpo del Reporte
        if (dtDatos.Columns.Count < 1)
        {
            dtDatos.Columns.Add("key", typeof(string));
            dtDatos.Columns.Add("descrip", typeof(string));
            /*
            dtDatos.Columns.Add("sNombre");
            dtDatos.Columns.Add("sDireccion");
            dtDatos.Columns.Add("sDescTipEnt");
             * */
        }
        int a = 1;
        /*
        m_Organizacion = ReportPMTNegocio.ListarOrg(a);
        
        for (int i = 0; i < m_Organizacion.Count(); i++)
        {

            DataRow dtRow = dtDatos.NewRow();
            dtRow["sIdDocumento"] = m_Organizacion[i].sIdDocumento.ToString();
            dtRow["sNumeroDoc"] = m_Organizacion[i].sNumeroDoc.ToString();
         * */
            /*
            dtRow["sNombre"] = m_Organizacion[i].sNombre.ToString();
            dtRow["sDireccion"] = m_Organizacion[i].sDireccion.ToString();
            dtRow["sDescTipEnt"] = m_Organizacion[i].sDescTipEnt.ToString();
             * */
        /*    
        dtDatos.Rows.Add(dtRow);
        }
        GridViewOrg.AutoGenerateColumns = false;
        GridViewOrg.DataSource = dtDatos;
        GridViewOrg.DataBind();
         * */
    }

    protected void GridViewOrg_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "descrip")
        {
            int index;
            string valor;
            index = int.Parse(e.CommandArgument.ToString());
            valor = GridViewOrg.DataKeys[index].Value.ToString();
            lblErr.Text = valor.ToString();
        }
    }
}