using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BapControles
{
    public partial class List2List : UserControl
    {        
        public ListBox listaizquierda
        {
            get { return lstIzquierda; }
            set { lstIzquierda = value; }
        }

        public ListBox listaderecha
        {
            get { return lstDerecha; }
            set { lstDerecha = value; }
        }
                       
        public List2List()
        {
            InitializeComponent();
            
        }
               
        private void cmdDerecha_Click(object sender, EventArgs e)
        {            
            lstDerecha.Items.Add(lstIzquierda.SelectedItem);
            lstIzquierda.Items.Remove(lstIzquierda.SelectedItem);
        }

        private void cmdIzquierda_Click(object sender, EventArgs e)
        {
            while (lstDerecha.SelectedIndices.Count > 0)
            {
                lstIzquierda.Items.Add(lstDerecha.SelectedItems[0]);
                lstDerecha.Items.Remove(lstDerecha.SelectedItems[0]);
            }
        }

        private void cmdtodosDerecha_Click(object sender, EventArgs e)
        {
            while (lstIzquierda.Items.Count > 0)
            {
                lstDerecha.Items.Add(lstIzquierda.Items[0]);
                lstIzquierda.Items.Remove(lstIzquierda.Items[0]);
            }  
        }

        private void cmdtodosIzquierda_Click(object sender, EventArgs e)
        {
            while (lstDerecha.Items.Count > 0)
            {
                lstIzquierda.Items.Add(lstDerecha.Items[0]);
                lstDerecha.Items.Remove(lstDerecha.Items[0]);
            }
        }

        private void List2List_Load(object sender, EventArgs e)
        {

        }
    }
}
