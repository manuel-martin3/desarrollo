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

public partial class Comercial_Listados_LstStocks : System.Web.UI.Page
{
    SimpleAES funcript = new SimpleAES();
    DataTable TablaProd, TablaPedido, TablaTallas;
    private DataRow row;
    DataTable dtDatos;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Act_TablaStockdispHorizontal();
            bloqueo("01", false);
            bloqueo("02", false);
            bloqueo("03", false);
            bloqueo("04", false);
        }
    }

    void Act_TablaStockdispHorizontal()
    {
        tb_me_stockdiariocabBL BL = new tb_me_stockdiariocabBL();
        tb_me_stockdiariocab BE = new tb_me_stockdiariocab();
        BE.marcaid = "";
        BE.lineaid = "";
        BE.generoid = "";
        BE.articid = "";
        BL.GetAll_StockDisp(Session["ssEmpresaID"].ToString(), BE);      
    }

    void bloqueo(String btn, Boolean var)
    {
        // Div Articulo
        if (btn.Equals("01"))
        {
            txt_articname.Enabled = var;
            //btn_buscaCliente.CssClass = css;
            btn_buscaArticulo.Visible = var;
        }

        // Div Marca
        if (btn.Equals("02"))
        {
            txt_marcaname.Enabled = var;
            //btn_buscaVendor.CssClass = css;
            btn_buscaMarca.Visible = var;
        }

        // Div Linea
        if (btn.Equals("03"))
        {
            txt_lineaname.Enabled = var;
            //btn_buscaVendor.CssClass = css;
            btn_buscaLinea.Visible = var;
        }

        // Div Genero
        if (btn.Equals("04"))
        {
            txt_generoname.Enabled = var;
            //btn_buscaVendor.CssClass = css;
            btn_buscaGenero.Visible = var;
        }
    }

    // ARTICULOS
    private void data_gridArticulo()
    {
        tb_pt_articuloWebBL BL = new tb_pt_articuloWebBL();
        tb_pt_articulo BE = new tb_pt_articulo();
        DataTable dt = new DataTable();

        switch (cmb_articulo.SelectedValue)
        {
            case "01":
                BE.articidold = txt_buscar.Text.Trim().ToUpper();
                break;
            case "02":
                BE.articname = txt_buscar.Text.Trim().ToUpper();
                break;           
            default:
                //**
                break;
        }
        try
        {
            //Eliminar Columnas Actuales(Opcional):
            dgb_articulo.Columns.Clear();
            dgb_articulo.Width = 535;
            //Objeto Columna:
            CommandField image;
            //Crear Columna:
            image = new CommandField();
            image.ButtonType = ButtonType.Image;
            image.SelectImageUrl = "~/Images/go-search.png";
            image.ShowSelectButton = true;
            image.ItemStyle.Width = 10;
            image.ItemStyle.Wrap = true;
            dgb_articulo.Columns.Add(image);

            BoundField ARTICID;
            ARTICID = new BoundField();
            ARTICID.DataField = "articid";
            ARTICID.HeaderText = "CODIGO";
            ARTICID.ItemStyle.Width = 50;
            dgb_articulo.Columns.Add(ARTICID);

            BoundField ARTICIDOLD;
            ARTICIDOLD = new BoundField();
            ARTICIDOLD.DataField = "articidold";
            ARTICIDOLD.HeaderText = "CODIGO";
            ARTICIDOLD.ItemStyle.Width = 80;
            dgb_articulo.Columns.Add(ARTICIDOLD);

            BoundField ARTICNAME;
            ARTICNAME = new BoundField();
            ARTICNAME.DataField = "articname";
            ARTICNAME.HeaderText = "ARTICULO";
            ARTICNAME.ItemStyle.Width = 250;
            dgb_articulo.Columns.Add(ARTICNAME);
            BE.top = true;
            //BE.vendorid = txt_vendorid.Value.ToString();
            dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                dgb_articulo.DataSource = dt;
                dgb_articulo.DataBind();
                dgb_articulo.Visible = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;// ClientMessage(ex.Message);
        }
    }
    protected void btn_buscar01_Click(object sender, EventArgs e)
    {
        data_gridArticulo();
    }
    protected void dgb_articulo_SelectedIndexChanged(object sender, EventArgs e)
    {        
        hf_articid.Value = dgb_articulo.SelectedRow.Cells[2].Text;
        txt_articname.Text = dgb_articulo.SelectedRow.Cells[3].Text;
    }
    protected void dgb_articulo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgb_articulo.PageIndex = e.NewPageIndex;
        data_gridArticulo();
    }


    // CHK_ACTIVATED
    protected void chk_articulo_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_articulo.Checked)
        {
            bloqueo("01", true);
        }
        else
        {
            bloqueo("01", false);
            hf_articid.Value = "";
            txt_articname.Text = "";
        }
    }
    protected void chk_marca_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_marca.Checked)
        {
            bloqueo("02", true);
        }
        else
        {
            bloqueo("02", false);
            hf_marcaid.Value = "";
            txt_marcaname.Text = "";
        }
    }
    protected void chk_linea_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_linea.Checked)
        {
            bloqueo("03", true);
        }
        else
        {
            bloqueo("03", false);
            hf_lineaid.Value = "";
            txt_lineaname.Text = "";
        }
    }
    protected void chk_genero_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_genero.Checked)
        {
            bloqueo("04", true);
        }
        else
        {
            bloqueo("04", false);
            hf_generoid.Value = "";
            txt_generoname.Text = "";
        }
    }


    // MARCAS
    private void data_gridMarca()
    {
        tb_pt_marcaBL BL = new tb_pt_marcaBL();
        tb_pt_marca BE = new tb_pt_marca();
        DataTable dt = new DataTable();

        switch (cmb_marca.SelectedValue)
        {
            case "01":
                BE.marcaid = txt_buscar2.Text.Trim().ToUpper();
                break;
            case "02":
                BE.marcaname = txt_buscar2.Text.Trim().ToUpper();
                break;
            default:
                //**
                break;
        }
        try
        {
            //Eliminar Columnas Actuales(Opcional):
            dgb_marca.Columns.Clear();
            dgb_marca.Width = 535;
            //Objeto Columna:
            CommandField image;
            //Crear Columna:
            image = new CommandField();
            image.ButtonType = ButtonType.Image;
            image.SelectImageUrl = "~/Images/go-search.png";
            image.ShowSelectButton = true;
            image.ItemStyle.Width = 10;
            image.ItemStyle.Wrap = true;
            dgb_marca.Columns.Add(image);

            BoundField MARCAID;
            MARCAID = new BoundField();
            MARCAID.DataField = "marcaid";
            MARCAID.HeaderText = "CODIGO";
            MARCAID.ItemStyle.Width = 50;
            dgb_marca.Columns.Add(MARCAID);


            BoundField MARCANAME;
            MARCANAME = new BoundField();
            MARCANAME.DataField = "marcaname";
            MARCANAME.HeaderText = "MARCA";
            MARCANAME.ItemStyle.Width = 250;
            dgb_marca.Columns.Add(MARCANAME);
             
            dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                dgb_marca.DataSource = dt;
                dgb_marca.DataBind();
                dgb_marca.Visible = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;// ClientMessage(ex.Message);
        }
    }
    protected void btn_buscar02_Click(object sender, EventArgs e)
    {
        data_gridMarca();
    }
    protected void dgb_marca_SelectedIndexChanged(object sender, EventArgs e)
    {
        hf_marcaid.Value = dgb_marca.SelectedRow.Cells[1].Text;
        txt_marcaname.Text = dgb_marca.SelectedRow.Cells[2].Text;
    }
    protected void dgb_marca_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgb_marca.PageIndex = e.NewPageIndex;
        data_gridMarca();
    }


    // LINEAS
    private void data_gridLinea()
    {
        tb_pt_lineaBL BL = new tb_pt_lineaBL();
        tb_pt_linea BE = new tb_pt_linea();
        DataTable dt = new DataTable();

        switch (cmb_lineas.SelectedValue)
        {
            case "01":
                BE.lineaid = txt_buscar3.Text.Trim().ToUpper();
                break;
            case "02":
                BE.lineaname = txt_buscar3.Text.Trim().ToUpper();
                break;
            default:
                //**
                break;
        }
        try
        {
            //Eliminar Columnas Actuales(Opcional):
            dgb_linea.Columns.Clear();
            dgb_linea.Width = 535;
            //Objeto Columna:
            CommandField image;
            //Crear Columna:
            image = new CommandField();
            image.ButtonType = ButtonType.Image;
            image.SelectImageUrl = "~/Images/go-search.png";
            image.ShowSelectButton = true;
            image.ItemStyle.Width = 10;
            image.ItemStyle.Wrap = true;
            dgb_linea.Columns.Add(image);

            BoundField LINEAID;
            LINEAID = new BoundField();
            LINEAID.DataField = "lineaid";
            LINEAID.HeaderText = "CODIGO";
            LINEAID.ItemStyle.Width = 50;
            dgb_linea.Columns.Add(LINEAID);


            BoundField LINEANAME;
            LINEANAME = new BoundField();
            LINEANAME.DataField = "lineaname";
            LINEANAME.HeaderText = "LINEA";
            LINEANAME.ItemStyle.Width = 250;
            dgb_linea.Columns.Add(LINEANAME);

            dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                dgb_linea.DataSource = dt;
                dgb_linea.DataBind();
                dgb_linea.Visible = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;// ClientMessage(ex.Message);
        }
    }
    protected void btn_buscar03_Click(object sender, EventArgs e)
    {
        data_gridLinea();
    }
    protected void dgb_linea_SelectedIndexChanged(object sender, EventArgs e)
    {
        hf_lineaid.Value = dgb_linea.SelectedRow.Cells[1].Text;
        txt_lineaname.Text = dgb_linea.SelectedRow.Cells[2].Text;
    }
    protected void dgb_linea_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgb_linea.PageIndex = e.NewPageIndex;
        data_gridLinea();
    }


    // GENEROS
    private void data_gridGenero()
    {
        tb_pt_generoBL BL = new tb_pt_generoBL();
        tb_pt_genero BE = new tb_pt_genero();
        DataTable dt = new DataTable();

        switch (cmb_genero.SelectedValue)
        {
            case "01":
                BE.generoid = txt_buscar4.Text.Trim().ToUpper();
                break;
            case "02":
                BE.generoname = txt_buscar4.Text.Trim().ToUpper();
                break;
            default:
                //**
                break;
        }
        try
        {
            //Eliminar Columnas Actuales(Opcional):
            dgb_genero.Columns.Clear();
            dgb_genero.Width = 535;
            //Objeto Columna:
            CommandField image;
            //Crear Columna:
            image = new CommandField();
            image.ButtonType = ButtonType.Image;
            image.SelectImageUrl = "~/Images/go-search.png";
            image.ShowSelectButton = true;
            image.ItemStyle.Width = 10;
            image.ItemStyle.Wrap = true;
            dgb_genero.Columns.Add(image);

            BoundField GENEROID;
            GENEROID = new BoundField();
            GENEROID.DataField = "generoid";
            GENEROID.HeaderText = "CODIGO";
            GENEROID.ItemStyle.Width = 50;
            dgb_genero.Columns.Add(GENEROID);


            BoundField GENERONAME;
            GENERONAME = new BoundField();
            GENERONAME.DataField = "generoname";
            GENERONAME.HeaderText = "LINEA";
            GENERONAME.ItemStyle.Width = 250;
            dgb_genero.Columns.Add(GENERONAME);

            dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                dgb_genero.DataSource = dt;
                dgb_genero.DataBind();
                dgb_genero.Visible = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;// ClientMessage(ex.Message);
        }
    }
    protected void btn_buscar04_Click(object sender, EventArgs e)
    {
        data_gridGenero();
    }
    protected void dgb_genero_SelectedIndexChanged(object sender, EventArgs e)
    {
        hf_generoid.Value = dgb_genero.SelectedRow.Cells[1].Text;
        txt_generoname.Text = dgb_genero.SelectedRow.Cells[2].Text;
    }
    protected void dgb_genero_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgb_genero.PageIndex = e.NewPageIndex;
        data_gridGenero();
    }

}