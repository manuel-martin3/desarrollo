using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using LayerDataAccess;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;

namespace BapFormulariosNet
{
    public partial class Frm_webbrowser_single : plantilla
    {
        
        public Frm_webbrowser_single()
        {
            InitializeComponent();
        }

        private void Frm_webbrowser_single_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape))
            {
                Close();
            }
        }

        private void Frm_webbrowser_single_Load(object sender, EventArgs e)
        {

        }
    }
}
