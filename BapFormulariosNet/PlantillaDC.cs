using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace BapFormulariosNet
{
    public partial class PlantillaDC : OfficeForm
    {
        private Int32 _id_Perfil;
        public Int32 Id_Perfil
        {
            get { return _id_Perfil; }
            set { _id_Perfil = value; }
        }

        public PlantillaDC()
        {
            InitializeComponent();
        }

        private void PlantillaDC_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
        }

        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}