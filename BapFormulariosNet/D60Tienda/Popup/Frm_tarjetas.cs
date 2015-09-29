using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using System.ComponentModel;
using System.Drawing;

using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace BapFormulariosNet.D60Tienda.Popup
{
    public partial class Frm_tarjetas : plantilla
    {
        public delegate void PasaDatosDelegate(DataTable dtresultado);
        public PasaDatosDelegate PasaDatos;
        DataTable Tabladet;
        private DataRow row;

        public Frm_tarjetas()
        {
            InitializeComponent();
        }       


        private void Frm_tarjetas_Load(object sender, EventArgs e)
        {
            Tabladet = new DataTable("TablaTarjetas");

            Tabladet.Columns.Add("tarjetaid", typeof(Int32));
            Tabladet.Columns.Add("tarjetaimpo", typeof(Decimal));
            Tabladet.Columns.Add("tarjetanume", typeof(String));
            Tabladet.Columns.Add("ddnni", typeof(String));

            Cargar_ComboTarjeta();
            SetEditValueByIndex(glueTarjeta, 0);

        }

        private void SetEditValueByIndex(GridLookUpEdit edit, int index)
        {
            var keyValue = glueTarjeta.Properties.GetKeyValue(index);
            glueTarjeta.EditValue = keyValue;
        }

        private void limpiarDocumento()
        {
            SetEditValueByIndex(glueTarjeta, 0);
            dnititular.Text = string.Empty;
            numaprovacion.Text = string.Empty;
            nametitular.Text = string.Empty;
            salgifcard.Text = string.Empty;
            importtarj.Text = string.Empty;
        }

        private void Cargar_ComboTarjeta()
        {
            try
            {
                var BL = new tb_t1_tarjetaBL();
                var BE = new tb_t1_tarjeta();
                var ds = new DataSet();
                BE.filtro = "2";
                ds = BL.GetAll2(VariablesPublicas.EmpresaID, BE);


                var dvm = new DataViewManager(ds);

                DataView dvDropDown;
                dvDropDown = dvm.CreateDataView(ds.Tables[0]);

                glueTarjeta.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
                glueTarjeta.Properties.DataSource = dvDropDown;
                glueTarjeta.Properties.DisplayMember = "tarjetaname";
                glueTarjeta.Properties.ValueMember = "tarjetaid";
                

                var col1 = glueTarjeta.Properties.View.Columns.AddField("tarjetalogo");
                col1.VisibleIndex = 0;
                col1.Caption = "logo";
                col1.Width = 20;

                var col2 = glueTarjeta.Properties.View.Columns.AddField("tarjetaname");
                col2.VisibleIndex = 1;
                col2.Caption = "Nombre de Tarjeta";
                col2.Width = 100;

               glueTarjeta.Properties.PopupFormWidth = 1;               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiarDocumento();
        }

        private void numaprovacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                importtarj.Focus();
            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            var _tarjimpo = Convert.ToDecimal(importtarj.Text);

            // Asignamos el valor “Visible” del Contenedor en alguna  variable aunque esto claro esta es mejorable
            string valor = glueTarjeta.EditValue.ToString();                  
            //El control tiene un método que a partir de ese valor seleccionado nos devolverá el registro al que pertenece.
            // Claro que este valor lo busca en el campo identificado como Campo Llave.
            DataRowView dr;
            dr = (DataRowView)glueTarjeta.Properties.GetRowByKeyValue(valor);

            var _tarjid = Convert.ToInt32(valor);  
            var _tarjnume = numaprovacion.Text;
            var _ddnni = dnititular.Text;

            try
            {
                row = Tabladet.NewRow();
                row["tarjetaid"] = _tarjid;
                row["tarjetaimpo"] = _tarjimpo;
                row["tarjetanume"] = _tarjnume;
                row["ddnni"] = _ddnni;

                Tabladet.Rows.Add(row);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            PasaDatos(Tabladet);
            Close();

        }

        private void importtarj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_aceptar_Click(sender, e);
            }
        }

        private void gridLookUpEdit1View_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //numaprovacion.Focus();
        }      

    }
}
