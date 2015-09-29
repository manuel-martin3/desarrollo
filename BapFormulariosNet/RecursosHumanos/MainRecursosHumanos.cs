using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.RecursosHumanos
{
    public partial class MainRecursosHumanos : Form
    {
        private string TituloForm = "ERP - Bapsoft.Net - ";
        private System.Reflection.Assembly Ensamblado;  
        internal Int32 grupo { get; set; }

        public string perfil { get; set; }
        public string perianio { get; set; }
        public string perimes { get; set; }
        public DateTime fechdigini { get; set; }
        public DateTime fechdigfin { get; set; }
        public string dominioid { get; set; }
        public string moduloid { get; set; }
        public String moduloname { get; set; }
        public string local { get; set; }
        public string localname { get; set; }
        public string ctacte { get; set; }
        public string ctactename { get; set; }
        public string direcnume { get; set; }
        public bool novalidastock { get; set; }
        public bool editnumdoc { get; set; }
        public string estabsunat { get; set; }
        public DateTime localfeuiv { get; set; }

        public MainRecursosHumanos()
        {
            InitializeComponent();
        }

        private void MainLogistica_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Quieres cerrar el Módulo?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private DataTable dtMenuItems = new DataTable();
        private string appPath = string.Empty;

        private void MainRecursosHumanos_Load(object sender, EventArgs e)
        {
            StatusBar();
            Metodo_VariablesStatic();            
        }

        private void Metodo_VariablesPublicas()
        {
            Ensamblado = System.Reflection.Assembly.GetExecutingAssembly();
            try
            {
                perfil = VariablesPublicas.Perfil;
                appPath = Application.ExecutablePath;

                var usuariosBL = new usuariosBL();
                var COD_USU = Convert.ToString(VariablesPublicas.Usuar);
                dtMenuItems = usuariosBL.GenerarMenuXperfil(VariablesPublicas.EmpresaID, COD_USU, VariablesPublicas.Perfil).Tables[0];

                mainMenu.Items.Clear();
                appPath = appPath.Substring(0, 28) + "Iconos\\";

                for (var nMain = 0; nMain < dtMenuItems.Rows.Count; nMain++)
                {
                    if (dtMenuItems.Rows[nMain]["menid"].Equals(dtMenuItems.Rows[nMain]["padid"]))
                    {
                        var tsmMain = new ToolStripMenuItem(dtMenuItems.Rows[nMain]["descr"].ToString());
                        if (dtMenuItems.Rows[nMain]["icono"].ToString().Trim().Length > 0)
                        {
                            tsmMain.Image = Bitmap.FromFile(appPath + dtMenuItems.Rows[nMain]["icono"].ToString().Trim());
                        }
                        mainMenu.Items.Add(tsmMain);
                        AddSubMenu(dtMenuItems.Rows[nMain]["menid"].ToString(), tsmMain);
                    }
                }
                Controls.Add(mainMenu);
            }
            catch
            {
            }
        }

        private void Metodo_VariablesStatic()
        {
            Ensamblado = System.Reflection.Assembly.GetExecutingAssembly();
            try
            {
                appPath = Application.ExecutablePath;

                var usuariosBL = new usuariosBL();
                var COD_USU = Convert.ToString(VariablesPublicas.Usuar);
                dtMenuItems = usuariosBL.GenerarMenuXperfil(VariablesPublicas.EmpresaID, COD_USU, perfil).Tables[0];

                mainMenu.Items.Clear();
                appPath = appPath.Substring(0, 28) + "Iconos\\";

                for (var nMain = 0; nMain < dtMenuItems.Rows.Count; nMain++)
                {
                    if (dtMenuItems.Rows[nMain]["menid"].Equals(dtMenuItems.Rows[nMain]["padid"]))
                    {
                        var tsmMain = new ToolStripMenuItem(dtMenuItems.Rows[nMain]["descr"].ToString());
                        if (dtMenuItems.Rows[nMain]["icono"].ToString().Trim().Length > 0)
                        {
                            tsmMain.Image = Bitmap.FromFile(appPath + dtMenuItems.Rows[nMain]["icono"].ToString().Trim());
                        }
                        mainMenu.Items.Add(tsmMain);
                        AddSubMenu(dtMenuItems.Rows[nMain]["menid"].ToString(), tsmMain);
                    }
                }
                Controls.Add(mainMenu);
            }
            catch
            {
            }
        }

        private void AddSubMenu(string sId, ToolStripMenuItem main)
        {
            String nameForm;
            foreach (System.Data.DataRow drMenuItem in dtMenuItems.Rows)
            {
                if (drMenuItem["padid"].ToString().Equals(sId) && !drMenuItem["menid"].Equals(drMenuItem["padid"]))
                {
                    var tsmSub = new ToolStripMenuItem(drMenuItem["descr"].ToString());
                    nameForm = drMenuItem["pgurl"].ToString();
                    tsmSub.Tag = drMenuItem["pgurl"].ToString();
                    if (drMenuItem["icono"].ToString().Trim().Length > 0)
                    {
                        tsmSub.Image = Bitmap.FromFile(appPath + drMenuItem["icono"].ToString().Trim());
                    }
                    tsmSub.Name = drMenuItem["pgurl"].ToString();

                    tsmSub.Click += new EventHandler(MenuItemClicked);
                    main.DropDownItems.Add(tsmSub);
                    AddSubMenu(drMenuItem["menid"].ToString(), tsmSub);
                }
            }
        }

        private void MenuItemClicked(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(ToolStripMenuItem))
            {
                var NombreFormulario = ((ToolStripItem)sender).Tag.ToString();
                Object ObjFrm;
                var tipo = Ensamblado.GetType(Ensamblado.GetName().Name + "." + NombreFormulario);
                if (tipo == null)
                {
                    MessageBox.Show("No se encontró el formulario", "Error de ubicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!FormularioEstaAbierto(NombreFormulario))
                    {
                        ObjFrm = Activator.CreateInstance(tipo);
                        var Formulario = (plantilla)ObjFrm;
                        Formulario.MdiParent = this;
                        Formulario.Show();
                    }
                }
            }
        }

        private Boolean FormularioEstaAbierto(String NombreDelFrm)
        {
            if (MdiChildren.Length > 0)
            {
                for (var i = 0; i < MdiChildren.Length; i++)
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
            {
                return false;
            }
        }

        private void abrir_formulario2(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(ToolStripMenuItem))
            {
                var ClickedItemText = ((ToolStripItem)sender).Name;

                MessageBox.Show(ClickedItemText);

                switch (ClickedItemText)
                {
                    case "Exit":
                        Application.Exit();
                        break;
                }
            }
        }

        private void StatusBar()
        {
            lblUsuario.Text = VariablesPublicas.Nombr.Trim();
            lblCompany.Text = VariablesPublicas.EmpresaName.Trim();
            lblPeriodo.Text = perianio;
            lblalmacen.Text = moduloname;

            Text = ((TituloForm + moduloname + " - " + lblCompany.Text + "  »» LOCAL »»  " + localname.ToString()));
        }
    }
}
