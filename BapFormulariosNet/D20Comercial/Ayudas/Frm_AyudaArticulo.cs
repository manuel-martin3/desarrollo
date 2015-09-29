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
using DevExpress.XtraEditors;

namespace BapFormulariosNet.D20Comercial.Ayudas
{
    public partial class Frm_AyudaArticulo : plantilla
    {
        public delegate void PasaArticulosDelegate(string codigo, string nombre, string und, DataTable Tablaarticulos);
        #region "Fields";
        //private Form _formulario;
        public PasaArticulosDelegate PasaArticulos;
        public bool _ActivaAlmacen = true;
        public string _CodTipoAlmacen = "";
        private DataTable dw = new DataTable();
        public string _LpDescripcionLike = "";
        public string CodAlmacen = "";
        //private bool sw_load = true;
        public bool Habilitar = true;
        public int _SoloComercial = 0;
	    #endregion
        
        public Frm_AyudaArticulo()
        {
            InitializeComponent();
        }

        private void Frm_AyudaArticulo_Load(object sender, EventArgs e)
        {
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            //DevExpress.Skins.SkinManager.EnableFormSkins();
        }
    }
}
