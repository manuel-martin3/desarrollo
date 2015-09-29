using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.DA0Contabilidad
{
    public partial class MainContabilidad : Form
    {
        string TituloForm = "ERP - BapSoft.Net - Contabilidad - ";

        public string ModuloModuloid = "0110";
        //public string = _Local;

        private System.Reflection.Assembly Ensamblado;

        public MainContabilidad()
        {
            InitializeComponent();

            StatusBar();
        }

        #region  *** EVENTOS DE FORMULARIO

        private void btnexit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainContabilidad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Quieres cerrar el Módulo?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnplancontable_Click(object sender, EventArgs e)
        {
            //Aqui vamos a mostrar el Frm_PlanContable.cs
            //Frm_PlanContable frmNuevo = new Frm_PlanContable();
            //{
            //    frmNuevo.Show();
            //    frmNuevo.MdiParent = this;
            //    frmNuevo.Activate();
            //    frmNuevo.WindowState = FormWindowState.Normal;
            //}
        }

        private void btndiario_Click(object sender, EventArgs e)
        {
            //Aqui vamos a mostrar el Frm_Registro_Contabilidad.cs
            string NombreFormulario = "";
            //Frm_Registro_Contabilidad Frm_Registro_Contabilidad = new Frm_Registro_Contabilidad();
            //string NombreFormulario2 = Frm_Registro_Contabilidad.ToString();
            //string[] parts = NombreFormulario2.Split(new string[] { "." }, StringSplitOptions.None);
            //for (int i = 1; i < parts.Length; i++)
            //{
            //    NombreFormulario += "." + parts[i];
            //}
            NombreFormulario = NombreFormulario.Substring(1);
            //string[] parts2 = NombreFormulario.Split(new string[] { "," }, StringSplitOptions.None);
            //NombreFormulario = parts2[0];

            Object ObjFrm;

            Type tipo = Ensamblado.GetType(Ensamblado.GetName().Name + "." + NombreFormulario);
            if (tipo == null)
            {
                MessageBox.Show("No se encontró el formulario", "Error de ubicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!FormularioEstaAbierto(NombreFormulario))
                {
                    ObjFrm = Activator.CreateInstance(tipo);
                    plantilla Formulario = (plantilla)ObjFrm;
                    //Formulario.Id_Perfil = id_Perfil;
                    Formulario.MdiParent = this;
                    Formulario.Show();
                }

            }

            //Frm_Registro_Contabilidad Frm_Registro_Contabilidad = new Frm_Registro_Contabilidad();
            //{
            //    Frm_Registro_Contabilidad.Show();
            //    Frm_Registro_Contabilidad.MdiParent = this;
            //    Frm_Registro_Contabilidad.Activate();
            //    Frm_Registro_Contabilidad.WindowState = FormWindowState.Normal;
            //}


            //string NombreFormulario = "MainContabilidad";
            //Object ObjFrm;
            ////Type tipo = default(Type);
            //Type tipo = Ensamblado.GetType(Ensamblado.GetName().Name + "." + NombreFormulario);
            //if (tipo == null)
            //{
            //    MessageBox.Show("No se encontró el formulario", "Error de ubicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
            //    if (!FormularioEstaAbierto(NombreFormulario))
            //    {
            //        ObjFrm = Activator.CreateInstance(tipo);
            //        plantilla Formulario = (plantilla)ObjFrm;
            //        //Formulario.Id_Perfil = id_Perfil;
            //        Formulario.MdiParent = this;
            //        Formulario.Show();
            //    }
            //}



        }

        private void DetracMenuItem_Click(object sender, EventArgs e)
        {
            //Aqui vamos a mostrar el Frm_Detracciones.cs
            //Frm_Detracciones frmNuevo = new Frm_Detracciones();
            //{
            //    frmNuevo.Show();
            //    frmNuevo.MdiParent = this;
            //    frmNuevo.Activate();
            //    frmNuevo.WindowState = FormWindowState.Normal;
            //}
        }

        private void PerceMenuItem_Click(object sender, EventArgs e)
        {
            //Aqui vamos a mostrar el Frm_Percepciones.cs
            //Frm_Percepciones frmNuevo = new Frm_Percepciones();
            //{
            //    frmNuevo.Show();
            //    frmNuevo.MdiParent = this;
            //    frmNuevo.Activate();
            //    frmNuevo.WindowState = FormWindowState.Normal;
            //}
        }

        private void ExporMenuItem_Click(object sender, EventArgs e)
        {
            //Aqui vamos a mostrar el Frm_TipoExportacion.cs
            //Frm_TipoExportacion frmNuevo = new Frm_TipoExportacion();
            //{
            //    frmNuevo.Show();
            //    frmNuevo.MdiParent = this;
            //    frmNuevo.Activate();
            //    frmNuevo.WindowState = FormWindowState.Normal;
            //}
        }

        private void btntcambio_Click(object sender, EventArgs e)
        {
            //Aqui vamos a mostrar el TipoCambio.cs
            //Frm_TipoCambio frmNuevo = new Frm_TipoCambio();
            //{
            //    frmNuevo.Show();
            //    frmNuevo.MdiParent = this;
            //    frmNuevo.Activate();
            //    frmNuevo.WindowState = FormWindowState.Normal;
            //}
        }

        private void btncliprov_Click(object sender, EventArgs e)
        {
            //Aqui vamos a mostrar el Frm_ClientesProveedores.cs
            //Frm_ClientesProveedores frmNuevo = new Frm_ClientesProveedores();
            //{
            //    frmNuevo.Show();
            //    frmNuevo.MdiParent = this;
            //    frmNuevo.Activate();
            //    frmNuevo.WindowState = FormWindowState.Normal;
            //}
        }

        private void planContablePCGEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //BapFormulariosNet.DA0CONTABILIDAD.ReportesContabilidad.Frm_ReportePlanContable hijo = new BapFormulariosNet.DA0CONTABILIDAD.ReportesContabilidad.Frm_ReportePlanContable();
            //hijo.MdiParent = this;
            //hijo.Show();
        }

        private void btncierremes_Click(object sender, EventArgs e)
        {
            //Aqui vamos a mostrar el Frm_CierreMensual.cs
            //Frm_CierreMensual frmNuevo = new Frm_CierreMensual();
            //{
            //    frmNuevo.Show();
            //    frmNuevo.MdiParent = this;
            //    frmNuevo.Activate();
            //    frmNuevo.WindowState = FormWindowState.Normal;
            //}
        }

        #endregion

        DataTable dtMenuItems = new DataTable();
        string appPath = "";
        //string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

        private void MainContabilidad_Load(object sender, EventArgs e)
        {
            Ensamblado = System.Reflection.Assembly.GetExecutingAssembly();

            try
            {
                //Nivel de Acceso;


                //perfil items usuario
                usuariosBL usuariosBL = new usuariosBL();
                tb_usuarios tb_usuarios = new tb_usuarios();
                string COD_USU = Convert.ToString(VariablesPublicas.Usuar);
                dtMenuItems = usuariosBL.GenerarMenuXperfil(VariablesPublicas.EmpresaID, COD_USU, VariablesPublicas.Perfil).Tables[0];

                menuContable.Items.Clear();
                //appPath = appPath.Substring(0, 29) + "Iconos\\";

                /*************************************************************************/
                //MenuStrip menu = new MenuStrip(); --nooo
                for (int nMain = 0; nMain < dtMenuItems.Rows.Count; nMain++)
                {
                    if (dtMenuItems.Rows[nMain]["menid"].Equals(dtMenuItems.Rows[nMain]["padid"]))
                    {
                        ToolStripMenuItem tsmMain = new ToolStripMenuItem(dtMenuItems.Rows[nMain]["descr"].ToString());
                        tsmMain.DisplayStyle = ToolStripItemDisplayStyle.Text; //--noooo
                        //if (dtMenuItems.Rows[nMain]["icono"].ToString().Trim().Length > 0)
                        //{
                        //    tsmMain.Image = Bitmap.FromFile(appPath + dtMenuItems.Rows[nMain]["icono"].ToString().Trim());
                        //}
                        menuContable.Items.Add(tsmMain);
                        AddSubMenu(dtMenuItems.Rows[nMain]["menid"].ToString(), tsmMain);
                    }
                }
                Controls.Add(menuContable);
            }
            catch
            {
                //Response.Redirect("~/Login02.aspx");
            }
        }

        #region fuente 03
        private void AddSubMenu(string sId, ToolStripMenuItem main)
        {
            String nameForm;
            foreach (System.Data.DataRow drMenuItem in dtMenuItems.Rows)
            {
                if (drMenuItem["padid"].ToString().Equals(sId) && !drMenuItem["menid"].Equals(drMenuItem["padid"]))
                {
                    ToolStripMenuItem tsmSub = new ToolStripMenuItem(drMenuItem["descr"].ToString());
                    nameForm = drMenuItem["pgurl"].ToString();
                    //tsmSub.DisplayStyle = ToolStripItemDisplayStyle.Text; --nooo
                    tsmSub.Tag = drMenuItem["pgurl"].ToString();
                    //if (drMenuItem["icono"].ToString().Trim().Length > 0)
                    //{
                    //    tsmSub.Image = Bitmap.FromFile(appPath + drMenuItem["icono"].ToString().Trim());
                    //}
                    tsmSub.Name = drMenuItem["pgurl"].ToString();
                    /***  ultimo arbol del menu***/
                    //tsmSub.DropDown.ItemClicked += new ToolStripItemClickedEventHandler(DropDown_ItemClicked); --nooo

                    /*** depende de la carga del arbol ***/
                    tsmSub.Click += new EventHandler(MenuItemClicked);
                    main.DropDownItems.Add(tsmSub);
                    AddSubMenu(drMenuItem["menid"].ToString(), tsmSub);
                }
            }
        }

        private void MenuItemClicked(object sender, EventArgs e)
        {
            // if the sender is a ToolStripMenuItem

            if (sender.GetType() == typeof(ToolStripMenuItem))
            {
                string NombreFormulario = ((ToolStripItem)sender).Tag.ToString();
                Object ObjFrm;
                //Type tipo = default(Type);
                Type tipo = Ensamblado.GetType(Ensamblado.GetName().Name + "." + NombreFormulario);
                if (tipo == null)
                {
                    MessageBox.Show("No se encontró el formulario", "Error de ubicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!FormularioEstaAbierto(NombreFormulario))
                    {
                        ObjFrm = Activator.CreateInstance(tipo);
                        plantilla Formulario = (plantilla)ObjFrm;
                        //Formulario.Id_Perfil = id_Perfil;
                        Formulario.MdiParent = this;
                        Formulario.Show();
                    }
                }
            }
        }

        //public static void ExistFormConTable(Form OformPapa, object OformHijo, bool IsFormPapa, bool ztesoreria, bool zcontabilidad)
        //{
        //    int lccont = 0;
        //    bool noinstanciado = false;
        //    for (lccont = 0; lccont <= OformPapa.MdiChildren.Length - 1; lccont++)
        //    {
        //        if (OformPapa.MdiChildren(lccont).Name.ToUpper == OformHijo.Name.ToUpper)
        //        {
        //            if (OformPapa.MdiChildren(lccont).Visible)
        //            {
        //                OformPapa.MdiChildren(lccont).WindowState = FormWindowState.Normal;
        //                OformPapa.MdiChildren(lccont).Activate();
        //                OformPapa.MdiChildren(lccont).Show();
        //                noinstanciado = true;
        //                break; // TODO: might not be correct. Was : Exit For
        //            }
        //        }
        //    }
        //    if (!noinstanciado)
        //    {
        //        OformHijo._tesoreria = ztesoreria;
        //        OformHijo._contabilidad = zcontabilidad;

        //        OformHijo.Show();
        //        if (IsFormPapa)
        //        {
        //            if ((OformPapa != null))
        //            {
        //                if ((OformHijo != null))
        //                {
        //                    OformHijo.MdiParent = OformPapa;
        //                }
        //            }
        //        }
        //    }
        //}


        private Boolean FormularioEstaAbierto(String NombreDelFrm)
        {
            if (MdiChildren.Length > 0)
            {
                for (int i = 0; i < MdiChildren.Length; i++)
                {
                    if (MdiChildren[i].Name == NombreDelFrm.Substring(NombreDelFrm.IndexOf("Frm_"), NombreDelFrm.Length - NombreDelFrm.IndexOf("Frm_")))
                    {
                        MessageBox.Show("El formulario solicitado ya se encuentra abierto");
                        return true;
                    }
                }
                return false;
            }
            else
                return false;
        }

        private void abrir_formulario2(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(ToolStripMenuItem))
            {
                string ClickedItemText = ((ToolStripItem)sender).Name;

                MessageBox.Show(ClickedItemText);

                switch (ClickedItemText)
                {
                    case "Exit":
                        Application.Exit();
                        break;
                }
            }
        }
        #endregion

        void StatusBar()
        {
            lblUsuario.Text = VariablesPublicas.Nombr;
            lblCompany.Text = VariablesPublicas.EmpresaName.Trim() + " Ruc Nº " + VariablesPublicas.EmpresaRuc;
            //lblCompany.Text = VariablesPublicas.EmpresaName;
            lblPeriodo.Text = VariablesPublicas.perianio;
            Text = ((TituloForm + lblCompany.Text));
            //Text = (VariablesPublicas.EmpresaLogo + (TituloForm + lblCompany.Text));
        }


    }
}
