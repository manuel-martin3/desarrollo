using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet.D60ALMACEN
{
    public partial class MainAlmacen : DevExpress.XtraEditors.XtraForm //DevComponents.DotNetBar.OfficeForm
    {
        string TituloForm = "ERP - Bapsoft.Net - ";
        private System.Reflection.Assembly Ensamblado;

        #region Variables Publicas para este MDI

        private string _perfil;
        public string perfil
        {
            get { return _perfil; }
            set { _perfil = value; }
        }

        private string _perianio;
        public string perianio
        {
            get { return _perianio; }
            set { _perianio = value; }
        }

        private string _perimes;
        public string perimes
        {
            get { return _perimes; }
            set { _perimes = value; }
        }

        private DateTime _fechdigini;
        public DateTime fechdigini
        {
            get { return _fechdigini; }
            set { _fechdigini = value; }
        }

        private DateTime _fechdigfin;
        public DateTime fechdigfin
        {
            get { return _fechdigfin; }
            set { _fechdigfin = value; }
        }

        private string _dominioid;
        public string dominioid 
        {
            get { return _dominioid; }
            set { _dominioid = value; }
        }

        private string _moduloid;
        public string moduloid
        {
            get { return _moduloid; }
            set { _moduloid = value; }
        }

        private String _moduloname;
        public String moduloname
        {
            get { return _moduloname; }
            set { _moduloname = value; }
        }

        private string _local;
        public string local
        {
            get { return _local; }
            set { _local = value; }
        }

        private string _localname;
        public string localname
        {
            get { return _localname; }
            set { _localname = value; }
        }

        private string _ctacte;
        public string ctacte
        {
            get { return _ctacte; }
            set { _ctacte = value; }
        }

        private string _ctactename;
        public string ctactename
        {
            get { return _ctactename; }
            set { _ctactename = value; }
        }
        

        private string _direcnume;
        public string direcnume
        {
            get { return _direcnume; }
            set { _direcnume = value; }
        }

        private bool _novalidastock;
        public bool novalidastock
        {
            get { return _novalidastock; }
            set { _novalidastock = value; }
        }

        private bool _editnumdoc;
        public bool editnumdoc
        {
            get { return _editnumdoc; }
            set { _editnumdoc = value; }
        }

        private string _estabsunat;
        public string estabsunat
        {
            get { return _estabsunat; }
            set { _estabsunat = value; }
        }

        private DateTime _localfeuiv;
        public DateTime localfeuiv
        {
            get { return _localfeuiv; }
            set { _localfeuiv = value; }
        }
        
        #endregion
     
        public MainAlmacen()
        {
            InitializeComponent();            
        }

        #region  *** EVENTOS DE FORMULARIO

        private void MainMenuAlmacen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (XtraMessageBox.Show("Quieres cerrar el Módulo?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                int i = Login.Login_old.listaDominioModuloid.BinarySearch(dominioid + moduloid);
                if (i >= 0) Login.Login_old.listaDominioModuloid.RemoveAt(i);
            }
        }

        #endregion

        DataTable dtMenuItems = new DataTable();
        string appPath = "";

        private void MainAlmacen_Load(object sender, EventArgs e)
        {
            StatusBar();
            //Metodo_VariablesPublicas();
            Metodo_VariablesStatic();
        }


        private void Metodo_VariablesPublicas()
        {
            Ensamblado = System.Reflection.Assembly.GetExecutingAssembly();
            try
            {
                perfil = VariablesPublicas.Perfil;
                appPath = Application.ExecutablePath;

                //perfil items Usuario
                usuariosBL usuariosBL = new usuariosBL();
                tb_usuarios tb_usuarios = new tb_usuarios();
                string COD_USU = Convert.ToString(VariablesPublicas.Usuar);
                dtMenuItems = usuariosBL.GenerarMenuXperfil(VariablesPublicas.EmpresaID, COD_USU, VariablesPublicas.Perfil).Tables[0];

                mainMenu.Items.Clear();
                appPath = appPath.Substring(0, 28) + "Iconos\\";

                /*************************************************************************/
                //MenuStrip menu = new MenuStrip();
                for (int nMain = 0; nMain < dtMenuItems.Rows.Count; nMain++)
                {
                    if (dtMenuItems.Rows[nMain]["menid"].Equals(dtMenuItems.Rows[nMain]["padid"]))
                    {
                        ToolStripMenuItem tsmMain = new ToolStripMenuItem(dtMenuItems.Rows[nMain]["descr"].ToString());
                        //tsmMain.DisplayStyle = ToolStripItemDisplayStyle.Text;
                        if (dtMenuItems.Rows[nMain]["icono"].ToString().Trim().Length > 0)
                        {
                            tsmMain.Image = Bitmap.FromFile(appPath + dtMenuItems.Rows[nMain]["icono"].ToString().Trim());
                        }
                        mainMenu.Items.Add(tsmMain);
                        AddSubMenu(dtMenuItems.Rows[nMain]["menid"].ToString(), tsmMain);
                    }
                }
                this.Controls.Add(mainMenu);
            }
            catch
            {
                //Response.Redirect("~/Login02.aspx");
            }
        }

        private void Metodo_VariablesStatic()
        {
            Ensamblado = System.Reflection.Assembly.GetExecutingAssembly();
            try
            {                
                appPath = Application.ExecutablePath;

                //perfil items Usuario
                usuariosBL usuariosBL = new usuariosBL();
                tb_usuarios tb_usuarios = new tb_usuarios();
                string COD_USU = Convert.ToString(VariablesPublicas.Usuar);
                dtMenuItems = usuariosBL.GenerarMenuXperfil(VariablesPublicas.EmpresaID, COD_USU, _perfil).Tables[0];

                mainMenu.Items.Clear();
                appPath = appPath.Substring(0, 28) + "Iconos\\";

                /*************************************************************************/
                //MenuStrip menu = new MenuStrip();
                for (int nMain = 0; nMain < dtMenuItems.Rows.Count; nMain++)
                {
                    if (dtMenuItems.Rows[nMain]["menid"].Equals(dtMenuItems.Rows[nMain]["padid"]))
                    {
                        ToolStripMenuItem tsmMain = new ToolStripMenuItem(dtMenuItems.Rows[nMain]["descr"].ToString());
                        //tsmMain.DisplayStyle = ToolStripItemDisplayStyle.Text;
                        if (dtMenuItems.Rows[nMain]["icono"].ToString().Trim().Length > 0)
                        {
                            tsmMain.Image = Bitmap.FromFile(appPath + dtMenuItems.Rows[nMain]["icono"].ToString().Trim());
                        }
                        mainMenu.Items.Add(tsmMain);
                        AddSubMenu(dtMenuItems.Rows[nMain]["menid"].ToString(), tsmMain);
                    }
                }
                this.Controls.Add(mainMenu);
            }
            catch
            {
                //Response.Redirect("~/Login02.aspx");
            }
        }

        private void MainAlmacen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (XtraMessageBox.Show("Quieres cerrar el Módulo?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                int i = Login.Login_old.listaDominioModuloid.BinarySearch(dominioid + moduloid);
                if (i >= 0) Login.Login_old.listaDominioModuloid.RemoveAt(i);
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
                    //tsmSub.DisplayStyle = ToolStripItemDisplayStyle.Text;
                    tsmSub.Tag = drMenuItem["pgurl"].ToString();
                    if (drMenuItem["icono"].ToString().Trim().Length > 0)
                    {
                        tsmSub.Image = Bitmap.FromFile(appPath + drMenuItem["icono"].ToString().Trim());
                    }
                    tsmSub.Name = drMenuItem["pgurl"].ToString();
                    /***  ultimo arbol del menu***/
                    //tsmSub.DropDown.ItemClicked += new ToolStripItemClickedEventHandler(DropDown_ItemClicked);

                    /*** depende de la carga del arbol ***/
                    tsmSub.Click += new EventHandler(this.MenuItemClicked);
                    main.DropDownItems.Add(tsmSub);
                    AddSubMenu(drMenuItem["menid"].ToString(), tsmSub);
                }
            }
        }

        private void MenuItemClicked(object sender, EventArgs e)
        {
            try
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
                        //XtraMessageBox.Show("No se encontró el formulario", "Error de ubicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (!this.FormularioEstaAbierto(NombreFormulario))
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Boolean FormularioEstaAbierto(String NombreDelFrm)
        {
            if (this.MdiChildren.Length > 0)
            {
                for (int i = 0; i < this.MdiChildren.Length; i++)
                {
                    if (this.MdiChildren[i].Name == NombreDelFrm.Substring(NombreDelFrm.IndexOf("Frm_"), NombreDelFrm.Length - NombreDelFrm.IndexOf("Frm_")))
                    {
                        XtraMessageBox.Show("El formulario solicitado ya se encuentra abierto");
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

                XtraMessageBox.Show(ClickedItemText);

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
            this.lblUsuario.Text = VariablesPublicas.Nombr.Trim();
            this.lblCompany.Text = VariablesPublicas.EmpresaName.Trim();
            this.lblPeriodo.Text = _perianio;
            this.lblalmacen.Text = _moduloname;

            Text = ((TituloForm + _moduloname +" - "+ lblCompany.Text + "  »» LOCAL »»  " + _localname.ToString()));
        }

        private void btnPedidoAlmacen_Click(object sender, EventArgs e)
        {
            //Frm_PedidoAlmacen Formulario = new Frm_PedidoAlmacen();
            ////plantilla Formulario = (plantilla)ObjFrm;
            ////Formulario.Id_Perfil = id_Perfil;
            //Formulario.MdiParent = this;
            //Formulario.Show();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            //DialogResult userAnswer = XtraMessageBox.Show("Desea Cerrar Aplicación ?", "CLOSE ALL FORMS",
            //MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (userAnswer == DialogResult.Yes)
            //{
            //    this.Dispose();
            //    Application.Exit();
            //}
            this.Close();
        }

        private void btn_precios_Click(object sender, EventArgs e)
        {
            try
            {
                String modd = "";
                sys_moduloBL BL = new sys_moduloBL();
                tb_sys_modulo BE = new tb_sys_modulo();
                DataTable dt = new DataTable();

                BE.dominioid = _dominioid;
                BE.moduloid = _moduloid;
                dt = BL.GetAll(VariablesPublicas.EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["moduloshort"].ToString().Trim().Length == 2)
                    {
                        modd = dt.Rows[0]["moduloshort"].ToString().Trim();
                        Ayudas.Form_help_productoprecio frmayuda = new Ayudas.Form_help_productoprecio();

                        frmayuda.tipoo = "sql"; //sql,tabla
                        frmayuda.titulo = " << *** Ayudas *** >>"; 
                        frmayuda.sqlquery = 
                                "SELECT tb1.productid "+
                                ", tb2.productname "+
                                ", SUM(IIF(mdet.almacaccionid = '10',mdet.cantidad * 1,mdet.cantidad *-1)) AS stock " +
                                ", tb1.costopromed " +
                                ", tb1.valoractual as StockValor " +                                
                                ", tb1.costoultimo as CostoSoles " +
                                ", tb3.compra as Tcamb" +
                                ", cast(tb1.costoultimo/cast(tb3.compra as decimal(10,4)) as decimal (10,4))as CostoDolar "+
                                " FROM  tb_" + modd + "_local_stock as tb1 ";
                        frmayuda.sqlinner =
                            "INNER JOIN tb_" + modd + "_productos as tb2 ON tb1.productid = tb2.productid " +
                            "INNER JOIN tb_tipocambio as tb3 ON tb3.fecha = CONVERT(date, GETDATE(), 103) " +
                            "LEFT JOIN tb_" + modd + "_movimientosdet mdet ON tb2.productid = mdet.productid ";
                        frmayuda.sqlwhere =
                            "WHERE " +
                            " tb1.local = '" + _local + "'" +
                            " and tb2.status= 0 ";
                        frmayuda.sqland = " and ";
                        frmayuda.sqlgroupby = " GROUP BY tb1.productid " +
                                ", tb2.productname " +
                                ", tb1.costopromed " +
                                ", tb1.valoractual " +
                                ", tb1.costoultimo " +
                                ", tb3.compra " +
                                ", tb1.costoultimo ";
                        frmayuda.criteriosbusqueda = new string[] { "PRODUCTO", "CODIGO" };
                        frmayuda.columbusqueda = "tb2.productname,tb1.productid";
                        frmayuda.returndatos = "0,1";
                        frmayuda.Owner = this;
                        frmayuda.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btn_InforProd_Click(object sender, EventArgs e)
        {
            Frm_TProductos frmproducto = new Frm_TProductos();
            frmproducto.dominio = _dominioid.ToString();
            frmproducto.modulo = _moduloid.ToString();
            frmproducto.local = _local.ToString();
            frmproducto.ShowDialog();
        }

        private void btn_reiniciar_Click(object sender, EventArgs e)
        {
            Generales.Frm_reiniciar frm = new Generales.Frm_reiniciar();
            frm._dominioid = _dominioid.ToString();
            frm._moduloid = _moduloid.ToString();
            frm._local = _local.ToString();
            frm._perianio = _perianio.ToString();
            frm._perimes = _perimes.ToString();
            frm._perfil = _perfil.ToString();
            frm.ShowDialog();
        }

        




    }
}
