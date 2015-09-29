using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BapFormulariosNet.Seguridadlog;

namespace BapFormulariosNet.Codigo
{
    public class Frm_Class
    {
        private bool zprocesa = false;
        private object ObjForm;
        public static void ShowError(string msg, System.Windows.Forms.Form frmpapa)
        {
            var oform = new Frm_Errores();
            oform._Mensaje = msg;
            oform.Owner = frmpapa;
            oform.ShowDialog();
        }
        public static void u_NoHayInfo()
        {
            MessageBox.Show("No hay información disponible según requerimientos", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void Frm_Plan_Maestro(System.Windows.Forms.Form frmpapa)
        {
        }
        private void PasaIdentificacionPlanMaestro(string CodUser)
        {
        }
        public static void Frm_EliminacionAsientoContable(System.Windows.Forms.Form frmpapa)
        {
            var oclass = new Frm_Class();
            oclass.zprocesa = false;
            var oformPassword = new Frm_Identificacion();
            oformPassword.TipoProceso = "CO02";
            oformPassword.Owner = frmpapa;
            oclass.ObjForm = frmpapa;
            oformPassword.PasaIdentificacionDelegado = oclass.PasaIdentificacionEliminacion;
            oformPassword.ShowDialog();
        }
        private void PasaIdentificacionEliminacion(string CodUser)
        {
            if (CodUser.Trim().Length > 0)
            {
            }
            else
            {
                MessageBox.Show("NO TIENE ACCESO A ESTA OPCION" + "/r" + CodUser + "/r" + "CONSULTE A SISTEMAS", "Mensaje del Sistema");
            }
        }
        public static void U_Load_Hoja_Consumo(System.Windows.Forms.Form frmpapa)
        {
        }
    }
}
