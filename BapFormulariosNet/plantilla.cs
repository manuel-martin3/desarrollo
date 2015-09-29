using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BapFormulariosNet
{
    public partial class plantilla : DevExpress.XtraEditors.XtraForm
    {
        public plantilla()
        {
            InitializeComponent();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            DevExpress.Skins.SkinManager.EnableFormSkins();
        }
        public String Id_Perfil { get; set; }

        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void plantilla_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
        }
    }
}
