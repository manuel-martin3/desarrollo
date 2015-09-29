using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Skins;
using System.Diagnostics;

namespace BapAlmacenNet
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            string currPrsName = Process.GetCurrentProcess().ProcessName;
            Process[] allProcessWithThisName 
                 = Process.GetProcessesByName(currPrsName);
                    if (allProcessWithThisName.Length > 1)
            {
                MessageBox.Show("Programa ya está en ejecución");
                Application.Exit();
                //return true; // Yes Previous Instance Exist
            }
            else
            {
                //return false; //No Prev Instance Running

                #region -- Anterior
                //Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);

                //DevExpress.UserSkins.BonusSkins.Register();
                //DevExpress.Skins.SkinManager.EnableFormSkins();
                //DevExpress.Skins.SkinManager.EnableMdiFormSkins();

                //Application.Run(new WelcomeSplash());
                //Application.Run(new BapFormulariosNet.Login.Frm_Login());
                #endregion


                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                DevExpress.UserSkins.BonusSkins.Register();
                DevExpress.LookAndFeel.UserLookAndFeel.Default.UseWindowsXPTheme = false;
                DevExpress.LookAndFeel.UserLookAndFeel.Default.UseDefaultLookAndFeel = true;
                //DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Caramel"; //'For Example!;
                DevExpress.Skins.SkinManager.EnableFormSkins();
                DevExpress.Skins.SkinManager.EnableMdiFormSkins();

                Application.Run(new SplashWelcome());
                Application.Run(new BapFormulariosNet.Login.Frm_Login());



            }
            
            
        }
    }


}
