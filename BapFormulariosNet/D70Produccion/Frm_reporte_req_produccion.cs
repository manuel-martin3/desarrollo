using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BapFormulariosNet.D70Produccion
{
    public partial class Frm_reporte_req_produccion : plantilla
    {
        public Frm_reporte_req_produccion()
        {
            InitializeComponent();
            numop_ini.LostFocus += new System.EventHandler(numop_ini_LostFocus);
            //numop_fin.LostFocus += new System.EventHandler(numop_fin_LostFocus);
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
           
            metodo();
        }

        public void metodo()
        {
            
        try
            {
                var miForma = new D70Produccion.Reportes.Frm_reportes();
                miForma.Text = "Reporte por Orden de Producción";
                //miForma.dominioid = dominio.Trim();

                miForma.tipop = "OP";
                miForma.numop = numop_ini.Text.Trim();
                miForma.serop = serop_ini.Text.Trim();
                miForma.moduloid = "0320";
                miForma.local = "002";
                miForma.formulario = "Frm_reporte_req_produccion";
                miForma.Show();


            }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
                      
           
        }

        private void serop_ini_KeyDown(object sender, KeyEventArgs e)
        {        
            if (e.KeyCode == Keys.Enter)
            {
                numop_ini.Focus();
            }       
        }

        private void numop_ini_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_imprimir.PerformClick();
            }
        }

        private void numop_ini_KeyPress(object sender, KeyPressEventArgs e)
        {
            solo_numero_enteros(sender, e);
        }

        private void solo_numero_enteros(object control, KeyPressEventArgs e)
        {
            if (((e.KeyChar) >= '0' && e.KeyChar <= '9') && !(e.KeyChar == '.'))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete && !(e.KeyChar == '.'))
                {
                    e.Handled = false;
                }
                else
                {
                    if ((e.KeyChar) == (char)Keys.Tab)
                    {
                        e.Handled = false;
                    }

                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void serop_ini_TextChanged(object sender, EventArgs e)
        {
            serop_ini.Text = serop_ini.Text.Trim().ToUpper();
           // serop_fin.Text = serop_ini.Text;
        }

        private void numop_ini_LostFocus(object sender, System.EventArgs e)
        {
            var numdo = string.Empty;
            if (numop_ini.Text.Trim().Length > 0)
            {
                numdo = numop_ini.Text.Trim().PadLeft(10, '0');
            }
            numop_ini.Text = numdo;
            //numop_fin.Text = numdo;
        }

    }
}
